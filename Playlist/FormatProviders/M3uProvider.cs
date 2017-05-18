using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Shauni.Database;

namespace Shauni.Playlist
{
    public class M3uProvider
    {
        public static M3uProvider<V> Create<V>(IPlaylist<V> playlist)
            where V : class, IMedia, new()
        {
            return new M3uProvider<V>(playlist);
        }
    }

    public class M3uProvider<V> : M3uProvider, IFormatProvider<V>
        where V : class, IMedia, new()
    {
        protected IPlaylist<V> playlist;

        public M3uProvider(IPlaylist<V> playlist)
        {
            this.playlist = playlist;
        }

        public void Save<T>(String filename)
            where T : IPlaylist<V>, new()
        {
            this.SaveToFile<T>(filename);
        }

        public T Load<T>()
            where T : IPlaylist<V>, new()
        {
            return (T)this.LoadFromFile<T>(playlist.Filename);
        }

        public T Load<T>(String filename)
            where T : IPlaylist<V>, new()
        {
            return (T)this.LoadFromFile<T>(filename);
        }

        private void SaveToFile<T>(String filename)
            where T : IPlaylist<V>, new()
        {
            using (StreamWriter writer = new StreamWriter(filename + "\\" + playlist.Name + ".m3u"))
            {
                String file = BuiltStructure();
                writer.WriteLine(file);
            }
        }

        private String BuiltStructure()
        {
            String header = "#EXTM3U\r\n\r\n", tag = "#EXTINF:", file = header;
            playlist.Media.ToList().ForEach(media => file += tag + ((IDurationable)media).Duration + "," + media.Name + "\r\n" + media.Filename + "\r\n");

            return file;
        }

        private IPlaylist<V> LoadFromFile<T>(String filename)
            where T : IPlaylist<V>, new()
        {
            StreamReader reader = new StreamReader(filename);

            playlist.Name = Path.GetFileNameWithoutExtension(filename);

            String line = null;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (line == string.Empty || line.Equals("#EXTM3U") || line.StartsWith("#EXTINF:")) continue;

                IMedia media = new V() { Filename = line };

                if (typeof(T) == typeof(SimplePlaylist<V>))
                    ((SimplePlaylist<V>)playlist).AddMedia((V)media);
            }

            reader.Close();
            reader.Dispose();

            return playlist;
        }
    }
}
