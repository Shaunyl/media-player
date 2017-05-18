using System;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace Shauni
{
    [Serializable()]
    public class Tag
    {
        public String AuthorLink { get; set; }
        public String Credits { get; set; }
    }

    [Serializable]
    public class IconPack
    {
        private List<Image> icons = new List<Image>();

        public event EventHandler<IconLoadedEventArgs> OperationCompleted;

        public Image Image { get; set; }

        public String Author { get; set; }
        public String Version { get; set; }
        public String Name { get; set; }
        public String Filename { get; set; }
        public String Description { get; set; }
        public Tag Tag { get; set; }

        public List<Image> Icons { get { return this.icons; } }

        public IconPack()
        {
        }

        public IconPack(Image image, string name, string version = "1.0.0", string author = "Unknown")
        {
            this.Image = image;
            this.Name = name;
            this.Filename = Paths.IconPacks(name);
            this.Version = version;
            this.Author = author;
        }

        public IconPack LoadFromFile(String filename)
        {
            try
            {
                string preview = Directory.GetFiles(filename + "\\Preview")[0];
                this.Image = new Bitmap(preview);
            }
            catch
            {
                return null;
            }

            this.Filename = filename;

            string xmlFile = filename + "\\" + filename.Substring(filename.LastIndexOf('\\')) + ".xml";

            if (File.Exists(xmlFile))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFile);

                XmlReaderSettings settings = new XmlReaderSettings();

                this.Name = doc.DocumentElement.Name;

                this.Version = doc.DocumentElement.Attributes["Version"].Value;
                this.Author = doc.DocumentElement.Attributes["Author"].Value;

                this.Description = doc.SelectSingleNode(this.Name + "/Description").InnerText;
                XmlNode tagNode = doc.SelectSingleNode(this.Name + "/Tags");

                String authorLink = tagNode.SelectSingleNode("AuthorLink").InnerText;
                String credits = tagNode.SelectSingleNode("Credits").InnerText;

                this.Tag = new Tag() { AuthorLink = authorLink, Credits = credits };

                foreach (XmlNode node in doc.SelectNodes(this.Name + "/Icon"))  //XPath
                {
                    string Key = node.SelectSingleNode("Key").InnerText.ToLower();
                    string FullName = node.SelectSingleNode("FullName").InnerText;

                    if (File.Exists(string.Concat(Filename, "\\", FullName)))
                    {
                        Image image = new Bitmap(string.Concat(Filename, "\\", FullName));
                        icons.Add(image);
                    }
                }

                IconLoadedEventArgs ile = new IconLoadedEventArgs(icons);

                if (OperationCompleted != null)
                    OperationCompleted(this, ile);
            }

            return this;
        }
    }

    public class IconLoadedEventArgs : EventArgs
    {
        /// <summary>
        /// Allows the callee to set the player's CurrentMedia property to the media object that the selected path is referring to.
        /// </summary>
        public List<Image> Image { get; private set; }

        public IconLoadedEventArgs(List<Image> image)
        {
            this.Image = image;
        }
    }
}
