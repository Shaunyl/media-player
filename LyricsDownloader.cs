using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using Shauni.Database;

namespace Shauni
{
    public class LyricsDownloader
    {
        public String FindLyric(Song song)
        {
            var plugin = SharedData.PluginManager(null).Plugins.Values.Where(plug => plug.Name.Equals("LyricsManager")).FirstOrDefault();
            if (plugin != null)
                return (String)plugin.Run("LyricsMania", song.Artist.Name, song.Name);
            else return null;
        }

        public void FindLyric(Song song, Action<String> callback)
        {
            new Thread(delegate() { callback(this.FindLyric(song)); }).Start();
        }
    }
}
