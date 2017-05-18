using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;

using Shauni.Graphic;
using Shauni.TracingV1;
using Shauni.Properties;
using Shauni.Database;

namespace Shauni.Forms
{
    public delegate void UpdateIconsHandler(String iconPackName);

    public partial class ToolsForm : Form
    {
        public event UpdateIconsHandler UpdateIcons;

        private SynchronizationContext context;
        private bool threadCancel = false;
        private DataLoader loader = null;
        private Stopwatch stopwatch = new Stopwatch();
        private IList<IMedia> mediaList = new List<IMedia>();
        private MainForm mainForm;

        public DataLoader Loader
        {
            get { return loader; }
            set
            {
                if (loader != null)
                {
                    loader.FileLoaded -= Loader_FileLoaded;
                    loader.OperationCompleted -= Loader_OperationCompleted;
                }

                if (value != null)
                {
                    loader = value;
                    loader.FileLoaded += Loader_FileLoaded;
                    loader.OperationCompleted += Loader_OperationCompleted;
                }
                else
                    loader = null;
            }
        }

        private void Loader_FileLoaded(Object sender, FileLoadedEventArgs e)
        {
            mediaList.Add(e.Media);
            this.Invoke(new Action(SetStatusLabel));
        }

        private void Loader_OperationCompleted(Object sender, EventArgs e)
        {
            if (Loader.TotalFileLoaded == 0)
            {
                this.statusText.Text = "The " + Loader.TotalFileScanned.ToString() + " file scanned are already into the database.";
                return;
            }

            this.stopwatch.Stop();
            this.stopwatch.Reset();
            this.Invoke(new Action(UpdateGridView));
        }

        public ToolsForm(System.Drawing.Image currentIconPack, MainForm mainForm = null)
            : this()
        {
            this.pBcurrentTheme.Image = currentIconPack;
            this.mainForm = mainForm;
        }

        public ToolsForm()
        {
            InitializeComponent();

            this.dataGridView.AutoGenerateColumns = true;

            this.BuildToolStrip();
            this.UpdateTabIcons();


            IconPack defaultPack = new IconPack(Properties.Resources.Shauni, "Shauni", "1.0.0", "Filippo Testino")
            {
                Description = "Default icons pack for Shauni v1.1.0.0+",
                Tag = new Tag() { AuthorLink = "No link!", Credits = "www.Veryicon.com" }
            };
            this.iconsListBox.Items.Add(defaultPack);

            var directories = System.IO.Directory.GetDirectories(Paths.IconPacks(string.Empty));

            foreach(string dir in directories)
            {
                IconPack pack = new IconPack();
                var lastFolderName = new System.IO.FileInfo(dir).Name;

                try
                {
                    IconPack pack2 = pack.LoadFromFile(Paths.IconPacks(lastFolderName));
                    this.iconsListBox.Items.Add(pack2);
                }
                catch
                {
                    SharedData.Logger.Append("The Icon Pack '" + lastFolderName + "' is corrupted or invalid and has not been loaded.", 1);
                }
            }

            this.LoadSatelliteAssembly();       
        }

        private void UpdateTabIcons()
        {
            this.imageList.Images.Add(Properties.Resources.Folder);
            this.imageList.Images.Add(Properties.Resources.Logger);
            this.imageList.Images.Add(Properties.Resources.colors);

            this.tabControlOwn.ImageList = this.imageList;
            this.tabControlOwn.TabPages["tbFolderProcessor"].ImageIndex = 0;
            this.tabControlOwn.TabPages["tbLogger"].ImageIndex = 1;
            this.tabControlOwn.TabPages["tbIcons"].ImageIndex = 2;
        }

        private void BuildToolStrip()
        {
            ToolStripOwnRenderer renderer = new ToolStripOwnRenderer();
            renderer.Art = false;
            this.statusStrip.Renderer = renderer;
            this.cmsMediaListBox.Renderer = new ToolStripOwnRenderer();
        }

        private void LoadSatelliteAssembly()
        {
            ResourceManager resourceManager = new ResourceManager("Shauni.Languages.Culture", typeof(ConfigurationForm).Assembly);
            CultureInfo culture = Utility.DetectLanguage(false);

            if (resourceManager.GetResourceSet(culture, true, false) == null)
                return;

            this.Translate(resourceManager, culture);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.mediaList.Clear();
            this.dataGridView.Rows.Clear();

            this.folderBrowserDialog.SelectedPath = Settings.Default.FolderProcessorDefaultDir;
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Loader = new DataLoader(SharedData.Database);
                Loader.LoadAllAsync(System.IO.Directory.EnumerateFiles(folderBrowserDialog.SelectedPath));

                stopwatch.Start();
            }
        }

        private void SetStatusLabel()
        {
            long n = loader.TotalFileLoaded;
            long m = loader.TotalFileScanned;
            this.statusText.Text = n.ToString() + '/' + m + " media have been loaded into the database in "
                + String.Format("{0:N2}", stopwatch.Elapsed.TotalSeconds) + " seconds!";
        }

        private void UpdateGridView()
        {
            try
            {
                for (int i = 0; i < mediaList.Count; i++)
                {
                    this.dataGridView.Rows.Add();
                    this.dataGridView.Rows[i].Cells["clmnArtist"].Value = ((Song)mediaList[i]).Artist.Name;
                    this.dataGridView.Rows[i].Cells["clmnTitle"].Value = mediaList[i].Name;
                    this.dataGridView.Rows[i].Cells["clmnFilename"].Value = mediaList[i].Filename;
                }
            }
            catch (NullReferenceException e)
            {
                this.statusText.Text = "Some data are corrupted! See the logger for further information.";
                //SharedData.Logger.Append(e.Message);
            }
        }

        private void Logger_OperationStarted(object sender, EventArgs e)
        {
            context.Post(new SendOrPostCallback(delegate(object state)
            {
                this.btnPause.Enabled = true;
                this.btnResume.Enabled = true;
                this.btnCancel.Enabled = true;
            }), null);
            SharedData.Logger.OperationStarted -= new EventHandler(Logger_OperationStarted);
        }

        private void Logger_OperationCompleted(object sender, EventArgs e)
        {
            context.Post(new SendOrPostCallback(delegate(object state)
            {
                this.btnPause.Enabled = false;
                this.btnResume.Enabled = false;
                this.btnCancel.Enabled = false;

                if (this.listViewLogger.Items.Count > 0)
                    this.lblLoggerState.Text += " successfully!";
                else
                    this.lblLoggerState.Text = "No logs were found.";

            }), null);
            SharedData.Logger.OperationCompleted -= new EventHandler(Logger_OperationCompleted);
        }

        private void Logger_LogAppended(object sender, LogLoadedCancelEventArgs e)
        {
            // Marshal call to UI thread
            context.Post(new SendOrPostCallback(delegate(object state)
            {
                ListViewItem row = new ListViewItem(e.Log.Seriousness.ToString());
                row.SubItems.Add(e.Log.Date.ToString());
                row.SubItems.Add(e.Log.Message);
                DateTime.Now.ToString("M/d/yyyy");

                if (e.Log.Date.ToString("M/d/yyyy").Equals(DateTime.Today.ToString("M/d/yyyy")))
                    row.BackColor = System.Drawing.Color.AliceBlue;

                this.listViewLogger.Items.Add(row);

                this.lblLoggerState.Text = this.listViewLogger.Items.Count + " logs have been read";

            }), null);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int count = this.listViewLogger.Items.Count;

            if (count == 0)
            {
                this.lblLoggerState.Text = "No logs to be deleted!";
                return;
            }

            //Clear all the voices in the logger.
            System.IO.File.WriteAllText(SharedData.Logger.Dir, String.Empty);

            this.listViewLogger.Items.Clear();

            this.lblLoggerState.Text = count + " have been deleted successfully!";
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            SharedData.Logger.Pause();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            SharedData.Logger.Resume();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            threadCancel = true;
        }

        private void iconsListBox_ItemClicked(object sender, UserControls.ItemClickedEventArgs e)
        {
            int index = iconsListBox.IndexFromPoint(e.X, e.Y);

            if (index != -1)
            {
                iconsListBox.SelectedItem = iconsListBox.Items[iconsListBox.IndexFromPoint(e.X, e.Y)];
                iconsListBox.Select();

                IconPack pack = (IconPack)iconsListBox.SelectedItem;

                this.UpdateIconsPackGroupBox(pack);

                if (e.Button == MouseButtons.Right)
                    this.cmsMediaListBox.Show(this.iconsListBox, e.X, e.Y);
            }
        }

        private void UpdateIconsPackGroupBox(IconPack pack)
        {
            if (Settings.Default.IconPackName == "" && pack.Name == "Shauni")
                this.lblCurrentlyApplied.Text = "Currently applied";
            else
                this.lblCurrentlyApplied.Text = Settings.Default.IconPackName.Equals(pack.Name) ? "Currently applied"
                    : String.Empty;

            this.tbName.Text = "";
            this.tbAuthor.Text = "";
            this.tbAuthorLink.Text = "";
            this.tbCredits.Text = "";
            this.tbVersion.Text = "";
            this.rtbDescription.Text = "";

            this.tbName.Text = pack.Name;
            this.tbAuthor.Text = pack.Author;

            if (pack.Tag != null)
            {
                this.tbAuthorLink.Text = pack.Tag.AuthorLink;
                this.tbCredits.Text = pack.Tag.Credits;
            }
            this.tbVersion.Text = pack.Version;
            this.rtbDescription.Text = pack.Description;
        }

        private void selectThisIconPackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = ((IconPack)this.iconsListBox.SelectedItem).Name;

            Settings.Default.IconPackName = name.Equals("Shauni") ? "" : name;
            Settings.Default.Save();

            if (UpdateIcons != null)
                UpdateIcons(name);

            this.pBcurrentTheme.Image = (name == "Shauni") ? Shauni.Properties.Resources.Shauni
                : ((IconPack)this.iconsListBox.SelectedItem).Image;

            this.lblCurrentlyApplied.Text = "Currently Applied";
        }

        private void Translate(ResourceManager resourceManager, CultureInfo culture)
        {
            this.btnBrowse.Text = resourceManager.GetString("btnBrowse.Text", culture);
            this.btnCancel.Text = resourceManager.GetString("btnCancel.Text", culture);
            this.btnClear.Text = resourceManager.GetString("btnClear.Text", culture);
            this.btnPause.Text = resourceManager.GetString("btnPause.Text", culture);
            this.btnResume.Text = resourceManager.GetString("btnResume.Text", culture);
            this.lblCurrentTheme.Text = resourceManager.GetString("lblCurrentIcon.Text", culture);
            this.lblListOfThemes.Text = resourceManager.GetString("lblListOfThemes.Text", culture);
        }

        private void tabControlOwn_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            if (current.Text.Equals("Logger"))
            {
                this.listViewLogger.Items.Clear();
                this.lblLoggerState.Text = String.Empty;

                SharedData.Logger.OperationStarted += new EventHandler(Logger_OperationStarted);

                context = SynchronizationContext.Current;
                SharedData.Logger.Read();
                SharedData.Logger.LogLoaded += new LogLoadedEventhandler(Logger_LogAppended);
                this.threadCancel = false;

                SharedData.Logger.OperationCompleted += new EventHandler(Logger_OperationCompleted);
            }
            else if (current.Text.Equals("Icons"))
            {
                SharedData.Logger.LogLoaded -= new LogLoadedEventhandler(Logger_LogAppended);

                foreach (var item in this.iconsListBox.Items)
                {
                    if (((IconPack)item).Name == "Shauni" && Settings.Default.IconPackName == "")
                        this.UpdateIconsPackGroupBox((IconPack)item);
                    else if (Settings.Default.IconPackName == ((IconPack)item).Name)
                        this.UpdateIconsPackGroupBox((IconPack)item);
                }
            }
            else
            {
                SharedData.Logger.LogLoaded -= new LogLoadedEventhandler(Logger_LogAppended);
            }
        }
    }
}
