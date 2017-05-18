using System;
using System.Windows.Forms;

namespace Shauni
{
    public static class Paths
    {
        /// <summary>
        /// Path to the SQL Server Compact music database. (@AppPath\Learning\decisionTree.bin).
        /// </summary>
        public static String DecisionTree
        {
            get { return Application.StartupPath + @"\Learning\decisionTree.bin"; }
        }
        /// <summary>
        /// Path to the SQL Server Compact music database. (@AppPath\Database\shauni.sdf).
        /// </summary>
        public static String Database
        {
            get { return Application.StartupPath + @"\Database\shauni.sdf"; }
        }
        /// <summary>
        /// Path to the application. (@AppPath).
        /// </summary>
        public static String ApplicationPath
        {
            get { return Application.StartupPath; }
        }
        /// <summary>
        /// Path to the change log file. (@AppPath\Change Log.txt).
        /// </summary>
        public static String ChangeLogPath
        {
            get { return Application.StartupPath + @"\Change Log.txt"; }
        }
        /// <summary>
        /// Path to the playlists application folder. (@AppPath\Playlists\..).
        /// </summary>
        public static String PlaylistFolder
        {
            get { return Application.StartupPath + @"\Playlists"; }
        }
        /// <summary>
        /// Path to the automatic playlists application folder. (@AppPath\Playlists\..).
        /// </summary>
        public static String AutomaticPlaylistFolder
        {
            get { return PlaylistFolder + @"\Automatic Playlist\"; }
        }
        /// <summary>
        /// Path to the current playlist application folder. (@AppPath\Playlists\Current\..).
        /// </summary>
        public static String CurrentPlaylist
        {
            get { return Application.StartupPath + @"\Playlists\Current\"; }
        }
        /// <summary>
        /// Path to the log application folder. (@AppPath\Log\..).
        /// </summary>
        public static String Log
        {
            get { return Application.StartupPath + @"\Log\"; }
        }
        /// <summary>
        /// Path to the Plugins folder. (@AppPath\Plugins\..).
        /// </summary>
        public static String Plugins
        {
            get { return Application.StartupPath + @"\Plugins\"; }
        }
        /// <summary>
        /// Path to the Icon Packs folder, or to a specified Icon Pack.
        /// </summary>
        /// <param name="name">String.Empty for the Icon Packs folder.</param>
        public static String IconPacks(String name)
        {
            return Application.StartupPath + @"\IconPacks\" + name;
        }
        /// <summary>
        /// Path to the pipe delimited file that contains the updates for Shauni
        /// </summary>
        public static String UpdatesLink
        {
            get { return "http://dl.dropbox.com/u/38091577/shauni.txt"; }
        }
    }
}
