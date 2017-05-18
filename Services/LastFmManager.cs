using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing;

using Shauni.Database;

namespace Shauni.Services
{
    /// <summary>
    /// Contains a valid audioscrobbler image format.
    /// </summary>
    public enum ImageFormat
    {
        Small,
        Medium,
        Large,
        ExtraLarge,
        ExtraExtraLarge
    }

    /// <summary>
    /// Exception thrown when the audioscrobbler service fails to complete a query.
    /// </summary>
    public class NoMatchFound : Exception
    {
        public NoMatchFound(String message) : base(message) { }
    }

    /// <summary>
    /// Represents a synchronous file downloader.
    /// </summary>
    public class Downloader
    {
        /// <summary>
        /// Sends a web request for the given URI and retrieves the respone as a network stream. Network streams do not support lookup.
        /// </summary>
        public static Stream GetResponseStream(String uri)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response.GetResponseStream();
        }

        /// <summary>
        /// Sends a web request for the given URI and retrieves the respone as a string.
        /// </summary>
        public static String GetResponseString(String uri)
        {
            Stream stream = GetResponseStream(uri);
            MemoryStream mem = new MemoryStream();
            stream.CopyTo(mem);
            mem.Position = 0;
            StreamReader reader = new StreamReader(mem);
            String result = reader.ReadToEnd();
            reader.Close();
            return result;
        }

        /// <summary>
        /// Sends a web request for the given URI and retrieves the respone as a local memory stream.
        /// </summary>
        public static MemoryStream GetResponseMemoryStream(String uri)
        {
            Stream stream = GetResponseStream(uri);
            MemoryStream result = new MemoryStream();
            Byte[] buffer = new Byte[4096];
            Int32 bytesRead = 0;

            bytesRead = stream.Read(buffer, 0, buffer.Length);
            while (bytesRead > 0)
            {
                result.Write(buffer, 0, bytesRead);
                bytesRead = stream.Read(buffer, 0, buffer.Length);
            }

            stream.Close();
            buffer = null;

            return result;
        }
    }

    /// <summary>
    /// Represents a synchronous xml downloader.
    /// </summary>
    public class XmlDownloader : Downloader
    {
        /// <summary>
        /// Sends a web request for the given URI and tries to parse the respone in a valid xml document.
        /// </summary>
        public static XmlDocument GetResponseXml(String uri)
        {
            String content = GetResponseString(uri);
            XmlDocument document = new XmlDocument();
            document.LoadXml(content);
            return document;
        }
    }

    /// <summary>
    /// Represents a synchronous xml downloader that is able to parse audioscrobbler's output documents
    /// to retrieve common informations about songs, artists and albums stored in last.fm databases.
    /// </summary>
    public class EntityDownloader : XmlDownloader
    {
        private static readonly String baseUrl = "http://ws.audioscrobbler.com/2.0";
        private static readonly String[] imageFormats = Enum.GetNames(typeof(ImageFormat)).Select(value => value.ToLower()).ToArray();

        protected ShauniDatabase database;

        /// <summary>
        /// Gets or sets the preferred format for downloaded image, such as artists' photos and albums' covers.
        /// If the preferred image format is not present in the result data, a similar format is chosen instead.
        /// </summary>
        public ImageFormat PreferredImageFormat { get; set; }

        /// <summary>
        /// Initializes and entity downloader that adds downloaded information to the given database.
        /// </summary>
        public EntityDownloader(ShauniDatabase database)
        {
            this.database = database;
            this.PreferredImageFormat = ImageFormat.ExtraExtraLarge;
        }

        /// <summary>
        /// Attempts to find and download the song duration, album and artist.
        /// </summary>
        public Song FindSong(String songName, String artistName)
        {
            XmlDocument document;
            try
            {
                document = GetResponseXml(String.Format("{0}/track/info.xml?track={1}&artist={2}", baseUrl, songName, artistName));
            }
            catch { /*throw new NoMatchFound(String.Format("Nessun match trovato per '{0}' di '{1}'.", songName, artistName));*/
                return null;
            }

            XmlElement root = document.DocumentElement;
            Int32 duration = root.GetValue<Int32>("/track/duration") / 1000;
            String albumTitle = root.GetValue<String>("/track/album/title");

            //String listeners = root.GetValue<String>("/track/listeners");
            //String playcount = root.GetValue<String>("/track/playcount");

            Song result = database.Song.FindByName(songName);
            result.Duration = duration;

            //if (result.ArtistID == 0)
                try
                {
                    result.Artist = this.FindArtist(artistName, true);
                }
                catch { }

            //if (result.AlbumID == 0)
                try
                {
                    if (albumTitle == null)
                        albumTitle = result.Album.Name;
                    result.Album = this.FindAlbum(albumTitle, artistName);
                }
                catch { }

            //database.SaveChanges();
            return result;
        }

        /// <summary>
        /// Attempts to find and download the album's publication date, description, number of tracks and cover image.
        /// </summary>
        public Album FindAlbum(String albumTitle, String artistName)
        {
            XmlDocument document;
            try
            {
                document = GetResponseXml(String.Format("{0}/album/info.xml?album={1}&artist={2}", baseUrl, albumTitle, artistName));
            }
            catch { throw new NoMatchFound(String.Format("Nessun match trovato per '{0}' di '{1}'.", albumTitle, artistName)); }

            XmlElement root = document.DocumentElement;

            XmlNode node = root.SelectSingleNode("/album/releasedate");

            DateTime publicationDate = DateTime.Parse(node.InnerText.Trim(), System.Globalization.CultureInfo.GetCultureInfo("en"));

            String description = root.GetValue<String>("/album/wiki/content");
            Int32 tracksNumber = root.SelectSingleNode("/album/tracks").ChildNodes.Count;

            Album result = database.Album.FindByName(albumTitle);
            result.TrackNumber = (Byte)tracksNumber;
            result.Notes = description;
            result.PublicationDate = publicationDate;

            Byte[] coverImage = this.DownloadBinaryImage(root, "/album/image");

            if (coverImage != null)
            {
                Cover cover = Cover.CreateCover(database.Covers.GetNextID(), result.ID);
                cover.Front = coverImage;
                database.AddToCovers(cover);
            }

            //database.SaveChanges();
            return result;
        }

        /// <summary>
        /// Attempts to find and download the artist's biography and image, then saves all data in the database according to the flag.
        /// </summary>
        /// <param name="save">if true, all data found are saved into the database, else they are not.</param>
        public Artist FindArtist(String artistName, bool save)
        {
            XmlDocument document;
            try
            {
                document = GetResponseXml(String.Format("{0}/artist/info.xml?artist={1}", baseUrl, artistName));
            }
            catch { throw new NoMatchFound(String.Format("Nessun match trovato per '{0}'.", artistName)); }

            XmlElement root = document.DocumentElement;
            String biography = root.GetValue<String>("/artist/bio/content");

            Byte[] image = this.DownloadBinaryImage(root, "/artist/image");

            Artist artist;

            if (save)
            {
                artist = database.Artist.FindByName(artistName);

                artist.Biography = biography.Length > 4000 ?
                    biography.Take(4000).ToString() : artist.Biography = biography;

                artist.Image = image;

                //database.SaveChanges();
            }
            else
            {
                artist = new Artist();
                artist.Biography = biography;
                artist.Image = image;
            }

            return artist;
        }

        public Byte[] FindImageByArtist(String artistName, bool save)
        {
            XmlDocument document;
            try
            {
                document = GetResponseXml(String.Format("{0}/artist/info.xml?artist={1}", baseUrl, artistName));
            }
            catch { throw new NoMatchFound(String.Format("Nessun match trovato per '{0}'.", artistName)); }

            XmlElement root = document.DocumentElement;
            return this.DownloadBinaryImage(root, "/artist/image");
        }

        public void FindImageByArtist(String artistName, Action<Byte[]> callback)
        {
            new Thread(delegate() { callback(this.FindImageByArtist(artistName, true)); }).Start();
        }

        /// <summary>
        /// Asynchronous method that attempts to find and download any song related info. Before returning,
        /// it invokes the callback function on the Song result.
        /// </summary>
        public void FindSong(String songName, String artistName, Action<Song> callback)
        {
            new Thread(delegate() { callback(this.FindSong(songName, artistName)); }).Start();
        }

        /// <summary>
        /// Asynchronous method that attempts to find and download any album related info. Before returning,
        /// it invokes the callback function on the Album result.
        /// </summary>
        public void FindAlbum(String albumTitle, String artistName, Action<Album> callback)
        {
            new Thread(delegate() { callback(this.FindAlbum(albumTitle, artistName)); }).Start();
        }

        /// <summary>
        /// Asynchronous method that attempts to find and download any artist related info. Before returning,
        /// it invokes the callback function on the Artist result.
        /// </summary>
        public void FindArtist(String artistName, Action<Artist> callback)
        {
            new Thread(delegate() { callback(this.FindArtist(artistName, false)); }).Start();
        }

        private Int32 GetArtistID(String artistName)
        {
            var matches = from artist in database.Artist
                          where artist.Name == artistName
                          select artist.ID;
            return matches.FirstOrDefault();
        }

        private Int32 GetAlbumID(String albumTitle)
        {
            var matches = from album in database.Album
                          where album.Name == albumTitle
                          select album.ID;
            return matches.FirstOrDefault();
        }

        private String GetImageUrl(XmlElement root, String imagePath)
        {
            var imageNodes = root.SelectNodes(imagePath);
            Dictionary<ImageFormat, String> imageUrls = new Dictionary<ImageFormat, String>();
            String result = String.Empty;

            for (Int32 i = 0; i < imageNodes.Count; i++)
            {
                XmlNode node = imageNodes.Item(i);
                Int32 format = imageFormats.IndexOf(node.Attributes["size"].Value);
                imageUrls.Add((ImageFormat)format, node.InnerText);
            }

            if (imageUrls.Count == 0)
                return String.Empty;

            if (imageUrls.ContainsKey(this.PreferredImageFormat))
                return imageUrls[this.PreferredImageFormat];

            ImageFormat bestFormat = ImageFormat.Small;
            // Prende il formato più simile a quello desiderato. Sfrutta il fatto che i valori
            // dell'enumeratore ImageFormat sono disposti in ordine.
            foreach (ImageFormat format in imageUrls.Keys)
                if (Math.Abs((Int32)format - (Int32)this.PreferredImageFormat) < Math.Abs((Int32)bestFormat - (Int32)this.PreferredImageFormat))
                    bestFormat = format;

            return imageUrls[bestFormat];
        }

        private Byte[] DownloadBinaryImage(XmlElement root, String imagePath)
        {
            String address = this.GetImageUrl(root, imagePath);

            if (address != String.Empty)
                try
                {
                    return GetResponseMemoryStream(address).ToByteArray();
                }
                catch { }

            return null;
        }
    }
}
