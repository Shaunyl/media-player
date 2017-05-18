using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

using Shauni.Database;

namespace Shauni.Playlist
{
    public class AutoPlaylist<V> : IPlaylist<V>, IFilterable<Filter<V>, V>, IEnumerable<V>
        where V : class, IMedia, new()
    {
        internal IFormatProvider<V> formatProvider;

        public event EventHandler PlaylistSaved;

        /// <summary>
        /// Gets the type of this Playlist.
        /// </summary>
        public PlaylistType Type { get { return PlaylistType.AutomaticPlaylist; } }

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
            get { return ToIEnumerable<V>(this.GetEnumerator()); }
        }

        IFormatProvider<V> IPlaylist<V>.FormatProvider
        {
            get
            {
                if (formatProvider == null)
                    formatProvider = WplProvider.Create(this);
                return formatProvider;
            }
            set
            {
                formatProvider = value;
            }
        }

        public FilterCollection<Filter<V>, V> FilterMap
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the instance of this object.
        /// </summary>
        public IPlaylist<V> Playlist
        {
            get { return this; }
        }

        public AutoPlaylist()
        {
            this.FilterMap = new FilterCollection<Filter<V>, V>();
            this.ID = Guid.NewGuid();
            this.Name = "Automatic Playlist " + this.ID.ToString();
        }

        public AutoPlaylist(String filename) : this()
        {
            this.Filename = filename;
            this.Name = System.IO.Path.GetFileNameWithoutExtension(filename);
        }


        public IEnumerator<V> GetEnumerator()
        {
            var lists = new List<IEnumerable<V>>();

            if (typeof(V) == typeof(Song))
            {
                foreach (var filter in this.FilterMap)
                {
                    if (filter.Matches())
                        lists.Add((IEnumerable<V>)filter.Media);
                }

                if (lists.Count != 0)
                    return lists.Where(x => x.Any()).Aggregate(Enumerable.Intersect).ToList().GetEnumerator();
                else
                    return null;
            }
            else
                return null; //temporary...
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerable<T> ToIEnumerable<T>(IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public void SaveToFile(String filename)
        {
            ((IPlaylist<V>)this).FormatProvider.Save<AutoPlaylist<V>>(filename);

            if (PlaylistSaved != null)
                PlaylistSaved(this, EventArgs.Empty);
        }

        public void SaveToFile(String filename, IFormatProvider<V> formatProvider)
        {
            ((IPlaylist<V>)this).FormatProvider = formatProvider;

            this.SaveToFile(filename);
        }

        public static AutoPlaylist<V> LoadFromFile(String filename)
        {
            AutoPlaylist<V> autoPlaylist = new AutoPlaylist<V>(filename);
            XmlReader reader = XmlReader.Create(filename);

            try
            {
                reader.ReadToFollowing("Filter");
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.MoveToAttribute(0);
                    string filter = reader.Value;
                    reader.MoveToAttribute(1);
                    string condition = reader.Value;

                    autoPlaylist.FilterMap.Add(new Filter<V>(filter, condition, reader.ReadString()));
                }
            }
            catch
            {
                throw new ArgumentException("Some of the data in the graph are invalid or corrupted.");
            }
            finally
            {
                reader.Close();
            }

            return autoPlaylist;
        }

        public static IEnumerable<AutoPlaylist<V>> LoadFromDirectory(String filename, String formatExtension = "*.*")
        {
            return System.IO.Directory.EnumerateFiles(filename, formatExtension).Select(path => LoadFromFile(path));
        }

        /*public static AutoPlaylist<V> LoadFromFile(String filename)
        {
            AutoPlaylist<V> Playlist = new AutoPlaylist<V>(filename);
                return WplProvider<V>.Create(Playlist).Load<AutoPlaylist<V>>();
        }

        public static IEnumerable<AutoPlaylist<V>> LoadFromDirectory(String filename, String formatExtension = "*.*")
        {
            return System.IO.Directory.EnumerateFiles(filename, formatExtension).Select(path => LoadFromFile(path));
        }*/
    }
}