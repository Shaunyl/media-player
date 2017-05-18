using System;
using System.Linq;
using System.IO;
using Shauni.Database;

namespace Shauni.Playlist
{
    public class TxtProvider
    {
        public static TxtProvider<V> Create<V>(IPlaylist<V> playlist)
            where V : class, IMedia, new()
        {
            return new TxtProvider<V>(playlist);
        }
    }

    public class TxtProvider<V> : TxtProvider, IFormatProvider<V>
        where V : class, IMedia, new()
    {
        protected IPlaylist<V> playlist;
        private String formatPattern = "*.txt";

        public String FormatPattern { get { return formatPattern; } }

        public TxtProvider(IPlaylist<V> playlist)
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
            StreamWriter writer = new StreamWriter(filename + "\\" + playlist.Name + ".txt");

            foreach (var media in playlist.Media)
                writer.WriteLine(media.Filename);

            writer.Close();
        }

        private IPlaylist<V> LoadFromFile<T>(String filename)
            where T : IPlaylist<V>, new()
        {
            StreamReader reader = new StreamReader(filename);

            playlist.Name = Path.GetFileNameWithoutExtension(filename);

            String line = null;
            while ((line = reader.ReadLine()) != null)
            {
                if (line == string.Empty) continue;

                IMedia media = new V() { Filename = line };

                if (typeof(T) == typeof(SimplePlaylist<V>))
                    ((SimplePlaylist<V>)playlist).AddMedia((V)media);
            }

            reader.Close();

            return playlist;
        }
    }
}
