/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Diagnostics;

using Microsoft.Win32;

namespace Shauni
{
    public static class RegisterManager
    {
        private static RegistryKeyPermissionCheck grant = RegistryKeyPermissionCheck.ReadWriteSubTree;
        private static string executablePath;

        static RegisterManager()
        {
            executablePath = System.IO.Path.GetFileName(Application.ExecutablePath).ToLower();
        }

        public static void SetAppPath()
        {
            string KeyToAppPaths = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
            RegistryKey temp = Registry.LocalMachine.OpenSubKey(KeyToAppPaths + "\\" + executablePath);

            if (temp == null)
            {
                RegistryKey regkey = Registry.LocalMachine.OpenSubKey(KeyToAppPaths, true);
                RegistryKey shauniexe = regkey.CreateSubKey(executablePath);
                shauniexe.SetValue("Path", Application.StartupPath, RegistryValueKind.String);
                shauniexe.SetValue("", Application.StartupPath + "\\" + executablePath, RegistryValueKind.String);
                regkey.Close();
            }
            if (temp != null)
                temp.Close();
        }

        /// <summary>
        /// Get default application for particolar extensions
        /// </summary>
        /// <param name="fileExtension">extensions file</param>
        /// <returns>List of default application opening extensions file</returns>
        public static List<string> GetDefaultApplication(params string[] fileExtension)
        {
            String defolt = String.Empty;
            string appexe = String.Empty;
            List<String> exes = new List<string>();
            foreach (string filex in fileExtension)
            {
                try
                {
                    RegistryKey prog = Registry.ClassesRoot.OpenSubKey(filex);
                    defolt = prog.GetValue(null).ToString(); //mp3file
                    prog.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("The extension hasn't been found! " + e.Message);
                }

                try
                {
                    RegistryKey opnex = Registry.ClassesRoot.OpenSubKey(defolt + @"\shell\open\command");
                    appexe = opnex.GetValue(null).ToString();
                    opnex.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("The file extension association hasn't been found! " + e.Message);
                }

                String[] subs = appexe.Split(new String[] { "\"" }, StringSplitOptions.RemoveEmptyEntries);

                if (subs.Length >= 0)
                {
                    appexe = subs[0];
                    string[] subs2 = appexe.Split('\\');
                    string AppName = subs2[subs2.Length - 1].TrimEnd();

                    if (AppName.LastIndexOf(' ') > 0)
                        AppName = AppName.Substring(0, AppName.LastIndexOf(' '));

                    exes.Add(AppName);
                }
            }
            return exes;
        }

        /// <summary>
        /// Set Shauni as default application for MP3 file
        /// </summary>
        public static void SetAsDefaultApplication()
        {
            RegistryKey RegKey = Registry.ClassesRoot.OpenSubKey(@".mp3\OpenWithList\" + executablePath, true);
            if (RegKey == null)
            {
                RegKey = Registry.ClassesRoot.OpenSubKey(@".mp3\OpenWithList", true);
                RegKey.CreateSubKey(executablePath, grant);
                RegKey.Close();
            }
            RegistryKey RegKey2 = Registry.ClassesRoot.OpenSubKey(@".mp3", true);
            if (!RegKey2.GetValue("").ToString().Equals("Shauni.mp3"))
                RegKey2.SetValue("", "Shauni.mp3");
            RegKey2.Close();

            if (Registry.ClassesRoot.OpenSubKey("Shauni.mp3") == null)
            {
                RegistryKey regk = Registry.ClassesRoot.CreateSubKey("Shauni.mp3", grant);
                regk.SetValue("", "Audio formato MP3");
                RegistryKey path = regk.CreateSubKey(@"shell\open\command", grant);
                path.SetValue("", String.Format("\"{0}\" \"%1\"", Application.StartupPath + "\\" + executablePath));
                RegistryKey riproduciConShauni = Registry.ClassesRoot.OpenSubKey(@"Shauni.mp3\shell", true);
                riproduciConShauni.SetValue("", "Play");
                RegistryKey tmp = riproduciConShauni.CreateSubKey(@"Play", grant);
                RegistryKey tmp3 = riproduciConShauni.CreateSubKey(@"Enqueue", grant);
                riproduciConShauni.Close();
                tmp.SetValue("", "&Riproduci con Shauni");
                tmp3.SetValue("", "&Accoda in Shauni");
                RegistryKey tmp4 = tmp3.CreateSubKey("command", grant);
                tmp4.SetValue("", String.Format("\"{0}\" --ENQUEUE \"%1\"", Application.StartupPath + "\\" + executablePath));
                RegistryKey tmp2 = tmp.CreateSubKey("command", grant);
                tmp2.SetValue("", String.Format("\"{0}\" --PLAY \"%1\"", Application.StartupPath + "\\" + executablePath));
            }
        }

        /// <summary>
        /// Reset settings opening mp3 with Shauni
        /// </summary>
        public static void ResetApplicationVoices()
        {
            RegistryKey RegKey = Registry.ClassesRoot.OpenSubKey(@".mp3\OpenWithList\" + executablePath, true);
            if (RegKey != null)
            {
                RegKey = Registry.ClassesRoot.OpenSubKey(@".mp3\OpenWithList", true);
                RegKey.DeleteSubKey("Shauni.exe", true); //eccezione
                RegKey.Close();
            }
            RegistryKey RegKey2 = Registry.ClassesRoot.OpenSubKey(@".mp3", true);
            if (RegKey2.GetValue("").ToString().Equals("Shauni.mp3"))
                RegKey2.SetValue("", "mp3file");
            RegKey2.Close();
            if (Registry.ClassesRoot.OpenSubKey("Shauni.mp3") != null)
            {
                RegistryKey tmp = Registry.ClassesRoot.OpenSubKey(@"Shauni.mp3\shell\open", true);
                tmp.DeleteSubKey("command", true);
                tmp = Registry.ClassesRoot.OpenSubKey(@"Shauni.mp3\shell", true);
                tmp.DeleteSubKey("open", true);

                tmp = Registry.ClassesRoot.OpenSubKey(@"Shauni.mp3\shell\Play", true);
                tmp.DeleteSubKey("command", true);
                tmp = Registry.ClassesRoot.OpenSubKey(@"Shauni.mp3\shell", true);
                tmp.DeleteSubKey("Play", true);

                tmp = Registry.ClassesRoot.OpenSubKey(@"Shauni.mp3\shell\Enqueue", true);
                tmp.DeleteSubKey("command", true);
                tmp = Registry.ClassesRoot.OpenSubKey(@"Shauni.mp3\shell", true);
                tmp.DeleteSubKey("Enqueue", true);

                tmp = Registry.ClassesRoot.OpenSubKey("Shauni.mp3", true);
                tmp.DeleteSubKey("shell", true);
                tmp = Registry.ClassesRoot;
                tmp.DeleteSubKey("Shauni.mp3", true);
                tmp.Close();
            }
        }
    }
}
*/