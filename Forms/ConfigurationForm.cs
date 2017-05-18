using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using System.Resources;
using System.Globalization;
using System.Xml;

using Shauni.Properties;
using Shauni.Database;
using Shauni.TracingV1;
using Shauni.Graphic;

namespace Shauni.Forms
{
    public partial class ConfigurationForm : Form
    {
        private MainForm mainForm;
        private bool pluginTabOpened = false;
        private bool changed = false;

        private List<Image> pluginIcons = new List<Image>();
        private string ToolTipLangNotesText = string.Empty;

        public ConfigurationForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            this.BuildToolStrip();
            this.LoadIcons();
            this.UpdateParagraphe();
            this.PanelSettingsSelected();
            this.UpdateTreeView();
            this.EnableScrobblingControls();

            this.LoadSatelliteAssembly();
            this.treeWiewSettings.DrawNode += new DrawTreeNodeEventHandler(treeWiewSettings_DrawNode);
        }

        void treeWiewSettings_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            TreeNodeStates state = e.State;
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color fore = Color.DimGray;
            //if (fore == Color.Empty) fore = e.Node.TreeView.ForeColor;
            if (e.Node == e.Node.TreeView.SelectedNode)
            {
                fore = Color.DimGray;
                e.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), e.Bounds);
                //e.Graphics.FillEllipse(new SolidBrush(Color.AliceBlue), e.Bounds);
                //ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, fore, Color.Red);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, Color.WhiteSmoke, TextFormatFlags.PathEllipsis);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding);
            }
        }

        private void UpdateParagraphe()
        {
            this.paragraphe1.Text = "Machine Learning";
            this.paragraphe1.TextColor = Color.SteelBlue;
            this.paragraphe1.Color = Color.Gainsboro;
            this.paragraphe1.BackgroundImage = Resources.index;

            this.paragraphe2.Text = "Extensions";
            this.paragraphe2.TextColor = Color.SteelBlue;
            this.paragraphe2.Color = Color.Gainsboro;
            this.paragraphe2.BackgroundImage = Resources.Plugins32;

            this.paragraphe3.Text = "Basics";
            this.paragraphe3.TextColor = Color.SteelBlue;
            this.paragraphe3.Color = Color.Gainsboro;
            this.paragraphe3.BackgroundImage = Resources.Settings48;

            this.paragraphe4.Text = "Network";
            this.paragraphe4.TextColor = Color.SteelBlue;
            this.paragraphe4.Color = Color.Gainsboro;
            this.paragraphe4.BackgroundImage = Resources.Network;

            this.paragraphe5.Text = "Logging";
            this.paragraphe5.TextColor = Color.SteelBlue;
            this.paragraphe5.Color = Color.Gainsboro;
            this.paragraphe5.BackgroundImage = Resources.OxleyLetter2;
        }

        private void LoadSatelliteAssembly()
        {
            ResourceManager resourceManager = new ResourceManager("Shauni.Languages.Culture", typeof(ConfigurationForm).Assembly);
            CultureInfo culture = Utility.DetectLanguage(false);

            if (resourceManager.GetResourceSet(culture, true, false) == null)
                return;

            this.Translate(resourceManager, culture);
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            this.LoadSettings();

            this.tbSearchParams.Enabled = chLearningAudio.Checked;
            this.tbSearchParams.Enabled = !chBoxAutoSearchParams.Checked;
            this.chBoxAutoSearchParams.Enabled = chLearningAudio.Checked;
            this.cbLearningType.Enabled = chLearningAudio.Checked;

            init = 0;

            this.LoadPlugins(false);
        }

        private void SaveSettings()
        {
            Settings.Default.TimeToCount = (int)numericUpDown.Value;
            Settings.Default.LoggerEnabled = this.chBoxEnableLogger.Checked;
            Settings.Default.PluginsEnabled = this.chBoxEnablePlugin.Checked;
            Settings.Default.AutoLangDetection = this.chBoxEnableAutoLangDetection.Checked;
            Settings.Default.ScrobblingEnabled = this.chEnableScrobbling.Checked;
            Settings.Default.FolderProcessorDefaultDir = this.tbFolderProcessorDefDir.Text;
            Settings.Default.ArtistImageFromInternet = this.cbArtistImage.Checked;
            Settings.Default.LearnAudio = this.chLearningAudio.Checked;
            Settings.Default.RestartLanguage = this.chBoxRestartLanguage.Checked;
            Settings.Default.AutoSearchParams = this.chBoxAutoSearchParams.Checked;
            Settings.Default.SearchParametersForLearning = this.tbSearchParams.Text;
            Settings.Default.SettingsTreeIndex = this.treeWiewSettings.SelectedNode.Index;

            Settings.Default.Save();
        }

        private void LoadSettings()
        {
            this.numericUpDown.Value = Settings.Default.TimeToCount;
            this.chBoxEnableLogger.Checked = Settings.Default.LoggerEnabled;
            this.chBoxEnablePlugin.Checked = Settings.Default.PluginsEnabled;
            this.chBoxEnableAutoLangDetection.Checked = Settings.Default.AutoLangDetection;
            this.chEnableScrobbling.Checked = Settings.Default.ScrobblingEnabled;
            this.tbFolderProcessorDefDir.Text = Settings.Default.FolderProcessorDefaultDir;
            this.cbArtistImage.Checked = Settings.Default.ArtistImageFromInternet;
            this.chLearningAudio.Checked = Settings.Default.LearnAudio;
            this.chBoxRestartLanguage.Checked = Settings.Default.RestartLanguage;
            this.cbPlaylistSaveAs.SelectedItem = Settings.Default.PlaylistFormat.ToUpper();
            this.cbLearningType.SelectedItem = Settings.Default.LearningSystem;
            this.tbSearchParams.Text = Settings.Default.SearchParametersForLearning;
            this.chBoxAutoSearchParams.Checked = Settings.Default.AutoSearchParams;
        }

        private void btnApplyAdvanced_Click(object sender, EventArgs e)
        {
            this.btnApply_Click(sender, e);
        }

        private void LoadIcons()
        {
           /*this.imageList.Images.Add(Properties.Resources.dtag);
            this.imageList.Images.Add(Properties.Resources.Settings);
            this.imageList.Images.Add(Properties.Resources.plugin);
            this.imageList.Images.Add(Properties.Resources.share21);
            this.imageList.Images.Add(Properties.Resources.Networkoff);*/

            //this.tabControlOwn.ImageList = this.imageList;
            /*this.tabControlOwn.TabPages["tbSettings"].ImageIndex = 0;
            this.tabControlOwn.TabPages["tbAdvancedSettings"].ImageIndex = 0;
            this.tabControlOwn.TabPages["tbPlugins"].ImageIndex = 1;
            this.tabControlOwn.TabPages["tbLearning"].ImageIndex = 2;*/
        }

        private void UpdateTreeView()
        {
            //this.treeWiewSettings.SelectedNode = this.treeWiewSettings.Nodes[0];
            this.treeWiewSettings.ExpandAll();

            //this.treeWiewSettings.ImageList = this.imageList;
            //this.treeWiewSettings.Nodes[0].ImageIndex = 0;
           // this.treeWiewSettings.Nodes[0].SelectedImageIndex = 0;
            /*this.treeWiewSettings.Nodes[0].Nodes[0].ImageIndex = 1;
            this.treeWiewSettings.Nodes[0].Nodes[0].SelectedImageIndex = 1;
            this.treeWiewSettings.Nodes[0].Nodes[1].ImageIndex = 2;
            this.treeWiewSettings.Nodes[0].Nodes[1].SelectedImageIndex = 2;
            this.treeWiewSettings.Nodes[0].Nodes[2].ImageIndex = 3;
            this.treeWiewSettings.Nodes[0].Nodes[2].SelectedImageIndex = 3;
            this.treeWiewSettings.Nodes[0].Nodes[3].ImageIndex = 4;
            this.treeWiewSettings.Nodes[0].Nodes[3].SelectedImageIndex = 4;*/

            this.treeWiewSettings.SelectedNode = treeWiewSettings.Nodes[0].Nodes[Settings.Default.SettingsTreeIndex];
            this.treeWiewSettings.Select();

            this.treeWiewSettings.Focus();
        }

        private void BuildToolStrip()
        {
            ToolStripOwnRenderer renderer = new ToolStripOwnRenderer();
            renderer.Art = false;
            this.cmsPlugins.Renderer = new ToolStripOwnRenderer();
        }

        private void LoadPlugins(bool forceReload)
        {
            if (pluginTabOpened && !forceReload)
                return;

            int i = 0;
            foreach (Plugin.IPlugin plugin in SharedData.PluginManager(mainForm).Plugins.Values)
            {
                pluginIcons.Add(plugin.Image);
                ListViewItem item = new ListViewItem(string.Empty, i++);
                item.SubItems.Add(plugin.Name);
                item.SubItems.Add(plugin.Version);
                item.SubItems.Add(plugin.Description);

                listViewPlugin.Items.Add(item);

                if (plugin.AtStartup)
                    plugin.Run();
            }
        }

        private void tabControlOwn_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* TabPage current = (sender as TabControl).SelectedTab;

            if (current.Text.Equals("TEMP"))
            {
                this.LoadPlugins(false);
                pluginTabOpened = true;
            }*/
        }

        private void listViewPlugin_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        private void listViewPlugin_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;

                // Draw the standard header background.
                e.DrawBackground();

                // Draw the header text.
                using (Font headerFont = new Font("Miramonte", 12, FontStyle.Bold)) //Font size!!!!
                {
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black
                        , new RectangleF(e.Bounds.X, e.Bounds.Y - 1, e.Bounds.Width, e.Bounds.Height), sf);
                }
            }
            return;
        }

        private void listViewPlugin_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.DrawImage(pluginIcons[e.ItemIndex], e.Bounds.X + 13, e.Bounds.Y + 2, 16, 16);
            }
            else
                e.DrawDefault = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.pluginIcons.Clear();
            this.listViewPlugin.Items.Clear();

            //SharedData.pluginManager = null;
            this.LoadPlugins(true);
        }

        private void listViewPlugin_MouseDown(object sender, MouseEventArgs e)
        {
            var item = listViewPlugin.HitTest(e.X, e.Y).Item; // Single selection.

            if (item != null)
            {
                if (e.Button == MouseButtons.Right)
                    this.cmsPlugins.Show(this.listViewPlugin, e.X, e.Y);
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Loads the plugin
            var item = this.listViewPlugin.SelectedItems[0];

            if (item == null)
                return;

            String pluginame = item.SubItems[1].Text;

            bool result = false;
            foreach (Plugin.IPlugin plugin in SharedData.PluginManager(mainForm).Plugins.Values)
            {
                if (plugin.Name == pluginame)
                {
                    try {  plugin.Run();  }
                    catch (Exception ex)
                    {
                        SharedData.Logger.Append(
                            String.Format("An exception occured in the Plugin: {0}. Message: {1}{2}"
                            , plugin.Name, ex.Message, ex.StackTrace), 1);
                    }
                    result = true;
                }
            }

            if (!result)
                SharedData.Logger.Append("The plugin '" + pluginame + "' was not found.");
        }

        private void chBoxEnableAutoLangDetection_CheckedChanged(object sender, EventArgs e)
        {
            String toolTipText = this.ToolTipLangNotesText == ""
                ? "Requires a restart of Shauni to work properly."
                : ToolTipLangNotesText;

            if (this.chBoxEnableAutoLangDetection.Checked)
                this.toolTipLangDetection.Show(toolTipText, this.chBoxEnableAutoLangDetection);
        }

        private void Translate(ResourceManager resourceManager, CultureInfo culture)
        {
            //this.btnApply.Text = resourceManager.GetString("btnApply.Text", culture);
            this.btnUpdate.Text = resourceManager.GetString("btnUpdate.Text", culture);
            //this.gBGeneral.Text = resourceManager.GetString("gBGeneral.Text", culture);
            //this.gBPlugins.Text = resourceManager.GetString("gBPlugins.Text", culture);
            //this.gBTime2Count.Text = resourceManager.GetString("gBTime2Count.Text", culture);
            //this.lblAllowInfoLastfm.Text = resourceManager.GetString("lblAllowInfoLastfm.Text", culture);
            this.ToolTipLangNotesText = resourceManager.GetString("ToolTipLangNotesText", culture);
            //this.lblEnableLogger.Text = resourceManager.GetString("lblEnableLogger.Text", culture);
            //this.lblEnableScrobbling.Text = resourceManager.GetString("lblEnableScrobbling.Text", culture);
            //this.lblLoadPrevPlaylist.Text = resourceManager.GetString("lblLoadPrevPlaylist.Text", culture);
            //this.lblPlayAtStartup.Text = resourceManager.GetString("lblPlayAtStartup.Text", culture);
            //this.lblPrgsBarVis.Text = resourceManager.GetString("lblPrgsBarVis.Text", culture);
           // this.lblTime2.Text = resourceManager.GetString("lblTime2.Text", culture);
            //this.lblEnableAutoLangDetection.Text = resourceManager.GetString("lblEnableAutoLangDetection.Text", culture);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //this.SaveSettings();
            //this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //this.SaveSettings();
        }

        private void chEnableScrobbling_CheckedChanged(object sender, EventArgs e)
        {
            EnableScrobblingControls();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            //this.SaveSettings();
            //this.Close();
        }

        private void btnOkAdvanced_Click(object sender, EventArgs e)
        {
            //this.SaveSettings();
            //this.Close();
        }

        private void EnableScrobblingControls()
        {
            this.numericUpDown.Enabled = this.chEnableScrobbling.Checked ? true : false;
            //this.chProgressBarVisibility.Enabled = this.chEnableScrobbling.Checked ? true : false;
        }

        private void tbFolderProcessorDefDir_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.tbFolderProcessorDefDir.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void cbPlaylistSaveAs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.PlaylistFormat = this.cbPlaylistSaveAs.SelectedItem.ToString().ToLower();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            InitializeLoading();
            this.tbSearchParams.Enabled = !chBoxAutoSearchParams.Checked;
        }

        private int init = 1;

        private void tbSearchParams_TextChanged(object sender, EventArgs e)
        {
            InitializeLoading();
        }

        private void InitializeLoading()
        {
            if (init == 0)
            {
                changed = true;
                this.EnableLoadingCircle(true);
                timer.Start();
            }
        }

        private void EnableLoadingCircle(bool enable)
        {
            this.loadingCircle.Visible = enable;
            this.loadingCircle.Active = enable;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (changed)
            {
                this.EnableLoadingCircle(false);
                timer.Stop();
                changed = false;
            }
        }

        private void ConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveSettings();
        }

        private void cbLearningType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeLoading();
            Settings.Default.LearningSystem = this.cbLearningType.SelectedItem.ToString();
        }

        private void chLearningAudio_CheckedChanged(object sender, EventArgs e)
        {
            InitializeLoading();
            Settings.Default.LearnAudio = this.chLearningAudio.Checked;

            this.tbSearchParams.Enabled = chLearningAudio.Checked;
            this.chBoxAutoSearchParams.Enabled = chLearningAudio.Checked;
            this.cbLearningType.Enabled = chLearningAudio.Checked;
        }

        private void treeWiewSettings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "Learning")
            {
                this.panelNetwork.Visible = false;
                this.panelSettings.Visible = false;
                this.panelExtensions.Visible = false;
                this.panelLogging.Visible = false;
                this.panelLearning.Visible = true;
                this.panelLearning.Dock = DockStyle.Fill;
            }
            else if (e.Node.Name == "Plugins")
            {
                this.panelNetwork.Visible = false;
                this.panelSettings.Visible = false;
                this.panelLogging.Visible = false;
                this.panelLearning.Visible = false;
                this.panelExtensions.Visible = true;
                this.panelExtensions.Dock = DockStyle.Fill;
            }
            else if (e.Node.Name == "Network")
            {
                this.panelSettings.Visible = false;
                this.panelExtensions.Visible = false;
                this.panelLogging.Visible = false;
                this.panelLearning.Visible = false;
                this.panelNetwork.Visible = true;
                this.panelNetwork.Dock = DockStyle.Fill;
            }
            else if (e.Node.Name == "Logging")
            {
                this.panelSettings.Visible = false;
                this.panelExtensions.Visible = false;
                this.panelLearning.Visible = false;
                this.panelNetwork.Visible = false;
                this.panelLogging.Visible = true;
                this.panelLogging.Dock = DockStyle.Fill;
            }
            else if (e.Node.Name == "Basics" || e.Node.Name == "Settings")
            {
                this.PanelSettingsSelected();
            }
        }

        private void PanelSettingsSelected()
        {
            this.panelLogging.Visible = false;
            this.panelNetwork.Visible = false;
            this.panelLearning.Visible = false;
            this.panelExtensions.Visible = false;
            this.panelSettings.Visible = true;
            this.panelSettings.Dock = DockStyle.Fill;
        }
    }
}
