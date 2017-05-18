using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using System.Diagnostics;
using System.Threading;

using Shauni.Properties;
using Shauni.Database;
using Shauni.Services;

namespace Shauni.Forms
{
    partial class AboutForm : Form
    {
        private List<string> information = null;
        private Thread workerThread = null;

        public AboutForm()
        {
            InitializeComponent();

            this.Text = String.Format("{0}", AssemblyTitle);
            this.lblName.Text = AssemblyProduct;
            this.textBoxDescription.Text = '.'.Halve(Space.Right, AssemblyCompany, AssemblyCopyright, "\r\n\r\n" + AssemblyDescription);

            this.LoadSatelliteAssembly();
        }

        private void LoadSatelliteAssembly()
        {
            ResourceManager resourceManager = new ResourceManager("Shauni.Languages.Culture", typeof(AboutForm).Assembly);
            CultureInfo culture = Utility.DetectLanguage(false);

            if (resourceManager.GetResourceSet(culture, true, false) == null)
            {
                this.lblVersion.Text = String.Format("{0}", AssemblyVersion);
                return;
            }

            this.Translate(resourceManager, culture);
        }

        private void Translate(ResourceManager resourceManager, CultureInfo culture)
        {
            String version = resourceManager.GetString("lblVersion", culture);

            this.lblVersion.Text = '-'.Halve(Space.Around, String.Format(version + " {0}", AssemblyVersion), "Alpha");
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void btnViewChangeLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Paths.ChangeLogPath);
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            workerThread = new System.Threading.Thread(delegate() { SearchForUpdates(); });
            workerThread.Start();
        }

        private void SearchForUpdates()
        {
            this.EnableLoadingCircle(true);

            try
            {
                information = Downloader.GetResponseString(Paths.UpdatesLink)
                    .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[1]
                    .Split('|').ToList();
            }
            catch (Exception) {
                UpdateLabel(true); return;
            }
            finally {
                this.EnableLoadingCircle(false);
            }

            if (information != null)
                if (decimal.Parse(information[1]) > decimal.Parse(AssemblyVersion))
                {
                    UpdateLabel(false);
                    return;
                }

            UpdateLabel(true);
        }

        private void UpdateLabel(bool check)
        {
            this.Invoke(new Action(() =>
            {
                label1.Text = check ? "Shauni is up to date" : "A new update is available";
                if (!check) this.linkLabel.Visible = true;
            }));
        }

        private void EnableLoadingCircle(bool enable)
        {
            this.Invoke(new Action(() =>
            {
                this.loadingCircle.Visible = enable;
                this.loadingCircle.Active = enable;
            }));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.UpdateApp();
        }

        private void UpdateApp()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = Application.StartupPath + @"\Updater.exe",
                                                                  Arguments = BuildCommandLine(),
                                                                  UseShellExecute = false
            };

            Process.Start(startInfo);
        }

        private String BuildCommandLine()
        {
            string cmd = String.Empty;

            cmd += "|downloadFile|" + information[4]; 
            cmd += "|URL|" + information[3];
            cmd += "|destinationFolder|" + ("\"" + Application.StartupPath + "\\");
            cmd += "|processToEnd|" + Application.ProductName;
            cmd += "|postProcess|" + (Application.ExecutablePath);
            cmd += "|command|" + @" / " + "updated";

            return cmd;
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
