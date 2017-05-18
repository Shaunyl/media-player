#define LOGGERV2

using System;
using System.Diagnostics;

using Graph;
using Shauni.Services;

namespace Shauni.Database
{
    using Tracing =
#if LOGGERV2
                Shauni.TracingV2;
#else
                Shauni.TracingV1;
#endif

    /// <summary>
    /// Exposes common data to the application.
    /// </summary>
    public static class SharedData
    {
        /// <summary>
        /// Gets the version of the assembly.
        /// </summary>
        public static String AssemblyVersion { get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }
        /// <summary>
        /// Contains a list of some common audio extensions, most of which are supported by the AudioVideoPlayback library.
        /// </summary>
        public static readonly string[] AudioFormats = { ".mp3", ".wav"/*, ".wma", ".ogg", ".aiff", ".aac", ".flac", ".m4p"*/ };
        /// <summary>
        /// Contains a list of some common video extensions, most of which are supported by the AudioVideoPlayback library.
        /// </summary>
        public static readonly string[] VideoFormats = { ".wmv", ".mp3", ".avi", ".mov", ".mpg" };
        /// <summary>
        /// Contains a list of some common image extensions.
        /// </summary>
        public static readonly string[] ImageFormats = { ".png", ".jpg", ".jpeg", ".bmp", ".giff" };

        private static ShauniDatabase database;
        private static Id3SongCreator id3SongCreator;
        private static EntityDownloader downloader;
        private static ChartCreator chartCreator;
#if LOGGERV2
        private static Tracing.Tracer logger;
#else
        private static Tracing.Logger logger;
#endif
        private static DataLoader dataLoader;
        internal static PluginManager pluginManager;
        private static LyricsDownloader lyricDownloader;
        private static EchoNestManager echoNestManager;

        /// <summary>
        /// Returns the default music database.
        /// </summary>
        public static ShauniDatabase Database
        {
            get {
                return (database == null) ? (database = new ShauniDatabase()) : database; }
        }

        /// <summary>
        /// Returns the default ID3 song reader, based on the default database.
        /// </summary>
        public static Id3SongCreator Id3SongCreator
        {
            get { return (id3SongCreator == null) ? (id3SongCreator = new Id3SongCreator(Database)) : id3SongCreator; }
        }

        public static ChartCreator ChartInteractor
        {
            get { return (chartCreator == null) ? (chartCreator = new ChartCreator(Database)) : chartCreator; }
        }

        public static LyricsDownloader LyricsDownloader
        {
            get { return (lyricDownloader == null) ? (lyricDownloader = new LyricsDownloader()) : lyricDownloader; }
        }

#if LOGGERV2
        public static Tracing.Tracer Logger
        {
            get { return (logger == null) ? (logger = new Tracing.Tracer()) : logger; }
        }
#else
        public static Tracing.Logger Logger
        {
            get { return (logger == null) ? (logger = new Tracing.Logger()) : logger; }
        }
#endif

        public static DataLoader DataLoader
        {
            get { return (dataLoader == null) ? (dataLoader = new DataLoader(Database)) : dataLoader; }
        }

        public static EntityDownloader Downloader
        {
            get { return (downloader == null) ? (downloader = new EntityDownloader(Database)) : downloader; }
        }

        /// <summary>
        /// Returns the default plugin manager.
        /// </summary>
        internal static PluginManager PluginManager(Shauni.Forms.MainForm mainForm = null)
        {
            return (pluginManager == null) ? (pluginManager = new PluginManager(mainForm)) : pluginManager;
        }

        public static EchoNestManager EchoNestManager
        {
            get { return (echoNestManager == null) ? (echoNestManager = new EchoNestManager(Database)) : echoNestManager; }
        }
    }
}
