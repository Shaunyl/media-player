using System;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using Shauni.Database;

namespace Shauni.Playlist
{
    public class WplProvider
    {
        public static WplProvider<V> Create<V>(IPlaylist<V> playlist)
            where V : IMedia
        {
            return new WplProvider<V>(playlist);
        }
    }

    public class WplProvider<V> : WplProvider, IFormatProvider<V>
        where V : IMedia
    {
        protected IPlaylist<V> playlist;

        public WplProvider(IPlaylist<V> playlist)
        {
            this.playlist = playlist;
        }

        public void Save<T>(String filename)
            where T : IPlaylist<V>, new()
        {
            this.SaveToFile(filename);
        }

        public T Load<T>()
             where T : IPlaylist<V>, new()
        {
            return (T)this.LoadFromFile<T>(playlist.Filename);
        }

        public T Load<T>(String filename)
            where T : IPlaylist<V>, new()
        {
            return new T();
        }

        private void SaveToFile(String filename)
        {
            XDocument doc =
                  new XDocument(
                      new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("smil",
                        new XElement("head",
                            new XElement("meta", new XAttribute("name", "Generator"), new XAttribute("content", "Shauni --  v" + System.Reflection.Assembly.LoadFile(Paths.ApplicationPath).GetName().Version.ToString())),
                            new XElement("meta", new XAttribute("name", "AverageRating"), new XAttribute("content", playlist.Media.Sum(p => ((Song)(object)p).Duration))),
                            new XElement("meta", new XAttribute("name", "TotalDuration"), new XAttribute("content", playlist.Media.Sum(p => ((Song)(object)p).Duration))),
                            new XElement("meta", new XAttribute("name", "ItemCount"), new XAttribute("content", playlist.Media.Count())),
                            new XElement("author", playlist.Author),
                            new XElement("title", playlist.Name)),
                        new XElement("body",
                            new XElement("seq",
                                playlist.Media.Select(x => new XElement("media", new XAttribute("src", x.Filename)))))));

            doc.Save(filename + "\\" + playlist.Name + ".wpl");
        }

        private IPlaylist<V> LoadFromFile<T>(String filename)
            where T : IPlaylist<V>, new()
        {
            //XmlReader reader = XmlReader.Create(filename);

            IPlaylist<V> playlist = new T();

            /*try
            {
                reader.ReadToFollowing("Filter");
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    TreeNode newNode = new TreeNode();
                    reader.MoveToAttribute(0);
                    newNode.Text = "Filter: " + reader.Value;
                    reader.MoveToAttribute(1);
                    newNode.Text += "; Condition: " + reader.Value + "; Value: ";
                    newNode.Text += reader.ReadString();

                    treeView.Add(newNode);
                }
            }
            catch
            {
                throw new ArgumentException("Some of the data in the graph are invalid or corrupted.");
            }
            finally
            {
                reader.Close();
            }*/

            return playlist;
        }
    }
}
