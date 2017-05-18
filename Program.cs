using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Shauni
{
    using Shauni.Forms;

    static class Program 
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (var mutex = new Mutex(false, "Shauni"))
            {
                // Wait a few seconds if contended, in case another instance
                // of the program is still in the process of shutting down.
                if (!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
                {
                    MessageBox.Show("A Shauni instance is already running!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CheckForArgs(args);

                RunShauni();
            }
        }

        static void CheckForArgs(string[] args)
        {
            String path = Paths.CurrentPlaylist + "currentPLaudio.txt";

            if (args.Length != 0)
            {
                if (args[0].Equals("--ENQUEUE"))
                {
                    File.AppendAllLines(path, args.Skip(1));
                    Shauni.Properties.Settings.Default.PlayAtStartUp = false;
                    Shauni.Properties.Settings.Default.Save();
                }
                else if (args[0].Equals("--PLAY"))
                {
                    File.WriteAllText(path, String.Empty);
                    File.AppendAllLines(path, args.Skip(1));

                    Shauni.Properties.Settings.Default.PlayAtStartUp = true;
                    Shauni.Properties.Settings.Default.Save();
                }
            }
        }

        static void RunShauni()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
