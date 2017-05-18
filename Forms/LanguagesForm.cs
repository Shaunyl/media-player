using System;
using System.Collections.Generic;
using System.Resources;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Shauni.Graphic;
using Shauni.Properties;
using Shauni.Database;

namespace Shauni.Forms
{
    public partial class LanguagesForm : Form
    {
        private ResourceManager resourceManager = null;
        private List<Image> flags = null;
        private CultureInfo culture = null;

        private readonly string APPLIED = "           [Applied]";
        private bool englishApplied = false;

        private string notify = string.Empty;

        public LanguagesForm()
        {
            InitializeComponent();

            this.flags = new List<Image>();

            this.cmsLanguages.Renderer = new ToolStripOwnRenderer();

            this.LoadSatelliteAssembly();
            this.FillLanguagesListView();
        }

        private void LoadSatelliteAssembly()
        {
            resourceManager = new ResourceManager("Shauni.Languages.Culture", typeof(LanguagesForm).Assembly);
            culture = Utility.DetectLanguage(false);

            if (resourceManager.GetResourceSet(culture, true, false) == null)
                return;

            this.Translate(resourceManager, culture);
        }

        private void AddDefaultLanguage()
        {
            this.flags.Add(Properties.Resources.flag);
            ListViewItem english = new ListViewItem(string.Empty, 0);
            english.Tag = "en";

            if (culture.Name == "en")
            {
                englishApplied = true;
                english.SubItems.Add("English" + APPLIED);
            }
            else
                english.SubItems.Add("English");

            english.SubItems.Add("1.0.1");
            english.SubItems.Add("Filippo Testino");

            listViewLanguages.Items.Add(english);
        }

        private void FillLanguagesListView()
        {
            this.AddDefaultLanguage();

            List<CultureInfo> cultures = new List<CultureInfo>(Utility.EnumSatelliteLanguages("Shauni.Languages.Culture"));

            foreach (CultureInfo cultureInfo in cultures)
            {
                this.flags.Add((Image)resourceManager.GetObject("flag", cultureInfo));

                ListViewItem item = new ListViewItem(string.Empty, 0);
                item.Tag = cultureInfo.Name;

                if (culture.Equals(cultureInfo) && !englishApplied)
                    item.SubItems.Add(cultureInfo.TextInfo.ToTitleCase(cultureInfo.NativeName + APPLIED));
                else
                    item.SubItems.Add(cultureInfo.TextInfo.ToTitleCase(cultureInfo.NativeName));

                item.SubItems.Add(resourceManager.GetString("*VersionOfLanguage", cultureInfo));
                item.SubItems.Add(resourceManager.GetString("*AuthorOfLanguage", cultureInfo));

                listViewLanguages.Items.Add(item);
            }
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

        private void listViewPlugin_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
            e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
        }

        private void listViewPlugin_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.DrawImage(flags[e.ItemIndex], e.Bounds.X + 13, e.Bounds.Y + 2, 16, 16);
            }
            else
                e.DrawDefault = true;
        }

        private void listViewLanguages_MouseDown(object sender, MouseEventArgs e)
        {
            var item = listViewLanguages.HitTest(e.X, e.Y).Item; // Single selection.

            if (item != null)
            {
                if (e.Button == MouseButtons.Right)
                    this.cmsLanguages.Show(this.listViewLanguages, e.X, e.Y);
            }
        }

        private void chooseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lblNotifyLangChanging.Text = "";

            var item = this.listViewLanguages.SelectedItems[0];

            String nativeName = item.Tag.ToString();

            if (Settings.Default.Language == nativeName)
            {
                this.lblNotifyLangChanging.Text = "The language is already applied.";
                    return;
            }

            Settings.Default.Language = nativeName;
            Settings.Default.FlagImage = System.Convert.ToBase64String(this.flags[item.Index].ToByteArray());
            Settings.Default.Save();

            if (Settings.Default.RestartLanguage)
                Application.Restart();

            this.lblNotifyLangChanging.Text = this.notify == ""
                ? "Requires a restart of Shauni to work properly." : notify;
        }

        private void Translate(ResourceManager resourceManager, CultureInfo culture)
        {
            this.Text = resourceManager.GetString("lblNotifyLangChanging.Text", culture);
            this.notify = resourceManager.GetString("formLang", culture);
        }
    }
}
