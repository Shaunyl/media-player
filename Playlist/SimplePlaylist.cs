using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Threading;

using Shauni.Database;

namespace Shauni.Playlist
{
    public class SimplePlaylist<V> : IPlaylist<V>, ICountable<V>
                where V : class, IMedia, new()
    {
        internal List<V> media;
        internal IFormatProvider<V> formatProvider;

        public event EventHandler PlaylistSaved;

        /// <summary>
        /// Gets the type of this Playlist.
        /// </summary>
        public PlaylistType Type { get { return PlaylistType.SimplePlaylist; } }

        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the playlist.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the filename of the playlist.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the author of the playlist.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Returns an enumerable collection of media contained in the playlist.
        /// </summary>
        public IEnumerable<V> Media
        {
            get { return this.media; }
        }

        /// <summary>
        /// Gets the instance of this object.
        /// </summary>
        public IPlaylist<V> Playlist
        {
            get { return this; }
        }

        /// <summary>
        /// Gets the number of media actually contained in the playlist.
        /// </summary>
        public long Count
        {
            get { return media.Count; }
        }

        IFormatProvider<V> IPlaylist<V>.FormatProvider
        {
            get
            {
                if (formatProvider == null)
                    formatProvider = TxtProvider.Create(this);
                return formatProvider;
            }
            set
            {
                formatProvider = value;
            }
        }

        public IEnumerator<V> GetEnumerator()
        {
            return this.media.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public SimplePlaylist()
        {
            this.media = new List<V>();
            this.ID = Guid.NewGuid();
            this.Name = "Simple Playlist " + ID.ToString();
        }

        public SimplePlaylist(string filename)
            : this()
        {
            this.Filename = filename;
        }

        public SimplePlaylist(string name, IFormatProvider<V> formatProvider)
            : this()
        {
            this.Name = name;
            this.Playlist.FormatProvider = formatProvider;
        }

        public virtual IMedia AddMedia(V data)
        {
            media.Add(data);

            return data;
        }

        public virtual void AddMoreMedia(params V[] data)
        {
            foreach (V media in data)
                this.AddMedia(media);
        }

        /// <summary>
        /// Removes a vertex from the graph, provided its index.
        /// </summary>
        /// <param name="index">Indicates the index of the vertex being removed.</param>
        public virtual void RemoveMedia(Int32 index)
        {
            if (index < 0 || index >= media.Count)
                throw new IndexOutOfRangeException();
            this.RemoveMoreMedia(new V[] { (V)media[index] });
        }

        /// <summary>
        /// Removes a vertex from the graph.
        /// </summary>
        /// <param name="vertex">The vertex being removed.</param>
        public virtual void RemoveMedia(IMedia data)
        {
            this.RemoveMoreMedia(new V[] { (V)data });
        }

        /// <summary>
        /// Removes all the vertices that match a given content from the graph.
        /// </summary>
        /// <param name="data">Indicates the data a vertex must posses to be deleted from the graph.</param>
        public virtual void RemoveMoreMedia(V data)
        {
            this.RemoveMoreMedia((from m in media where m.Equals(data) select (V)m).ToArray());
        }

        /// <summary>
        /// Removes a range of vertices.
        /// </summary>
        /// <param name="startIndex">The vertex index at which to start removing vertices.</param>
        /// <param name="count">The number of vertices being removed.</param>
        public virtual void RemoveMoreMedia(Int32 startIndex, Int32 count)
        {
            List<V> m = media.GetRange(startIndex, count) as List<V>;
            this.RemoveMoreMedia(m);
        }

        private void RemoveMoreMedia(IEnumerable<V> matches)
        {
            foreach (var data in matches)
                media.Remove(data);
        }

        public void SaveToFile(String filename)
        {
            this.GetFormat();
            ((IPlaylist<V>)this).FormatProvider.Save<SimplePlaylist<V>>(filename);

            if (PlaylistSaved != null)
                PlaylistSaved(this, EventArgs.Empty);
        }

        public void SaveToFile(String filename, IFormatProvider<V> formatProvider)
        {
            ((IPlaylist<V>)this).FormatProvider = formatProvider;

            this.SaveToFile(filename);
        }

        private void GetFormat()
        {
            String format = Properties.Settings.Default.PlaylistFormat;

            switch(format)
            {
                case "txt": this.formatProvider = TxtProvider.Create(this); break;
                case "m3u": this.formatProvider = M3uProvider.Create(this); break;
                case "wpl": this.formatProvider = WplProvider.Create(this); break;
            }
        }

        public static SimplePlaylist<V> LoadFromFile(String filename)
        {
            String format = GuessFormat(filename);
            SimplePlaylist<V> Playlist = new SimplePlaylist<V>(filename);

            return format == "txt" ? (TxtProvider<V>.Create(Playlist).Load<SimplePlaylist<V>>())
                : (M3uProvider<V>.Create(Playlist).Load<SimplePlaylist<V>>());
        }

        public static IEnumerable<IPlaylist<V>> LoadFromDirectory(String filename, String formatExtension = "*.*")
        {
            return System.IO.Directory.GetFiles(filename, formatExtension).Select(path => LoadFromFile(path));
        }

        private static String GuessFormat(String filename)
        {
            StreamReader reader = new StreamReader(filename);
            String line = String.Empty, result = String.Empty;

            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (!string.IsNullOrWhiteSpace(line))
                    if (line == "#EXTM3U" || line.StartsWith("#EXTINF:"))
                        return "m3u";
            }
            reader.Close();
            reader.Dispose();

            return "txt";
        }
    }
}
