using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Xml;
using System.Text;

using Shauni.Playlist;

namespace Shauni.Database
{
    public static class ObjectSetExtensions
    {
        private static Dictionary<String, Int32> availableIDs = new Dictionary<String, Int32>();

        /// <summary>
        /// Returns a new valid ID for the current object set.
        /// </summary>
        public static Int32 GetNextID<T>(this ObjectSet<T> set)
            where T : class, IIdentifiable<int>
        {
            String key = set.CommandText;

            if (availableIDs.ContainsKey(key))
                return ++availableIDs[key];

            Int32 maxID = 0;
            if (set.Count() > 0)
                maxID = set.Max(item => item.ID);
            availableIDs[key] = maxID + 1;

            return maxID + 1;
        }

        public static AudioStatistic AddValue(this ObjectSet<AudioStatistic> itemSet, int counter, int artistID, int timingID)
        {
            AudioStatistic newEntry = new AudioStatistic() { ID = itemSet.GetNextID(), Counter = counter, ArtistID = artistID, TimeLineID = timingID };
            itemSet.AddObject(newEntry);
            return newEntry;
        }
    }

    public static class IStronglyTraceableExtensions
    {
        public static void SavePlaylist<T>(this SimplePlaylist<T> itemSet, string name, T[] items)
            where T : class, IStronglyTraceable<int>, IMedia, new()
        {
            Shauni.Playlist.SimplePlaylist<T> simpleplaylist
                = new Shauni.Playlist.SimplePlaylist<T>(name, null);

            if (items.Length > 0)
            {
                try
                {
                    simpleplaylist.AddMoreMedia(items.Cast<T>().ToArray());
                    simpleplaylist.SaveToFile(Paths.CurrentPlaylist);
                }
                catch { }
            }
            else // bug when wmp is playing, or is open
            {
                string filename = Paths.CurrentPlaylist + name + ".txt";

                File.WriteAllText(filename, ""); //bug due to the non-generic format provider. Maybe it is fixed...
            }
        }
    }

    public static class IDatableSetExtensions
    {
        /// <summary>
        /// Searches for a record with the given DateTime in terms of days in the current object set. If a record exists,
        /// a valid entity is returned. Otherwise, a new record is created and then returned.
        /// </summary>
        /// <param name="date">The date to search for. Cannot be empty (in that case, an exception is thrown).</param>
        public static T FindByDate<T>(this ObjectSet<T> itemSet, DateTime date)
           where T : class, IDatable, new()
        {
            if (date == null)
                throw new ArgumentException("Searching parameters cannot be null.", "date");

            var match = (from item in itemSet where item.Date.Day == date.Day select item).FirstOrDefault();

            if (match != null)
                return match;

            T newEntry = new T() { ID = itemSet.GetNextID(), Date = date };
            itemSet.AddObject(newEntry);
            return newEntry;
        }
    }

    public static class ITraceableSetExtensions
    {
        public static T FindByFilename<T>(this ObjectSet<T> itemSet, string filename)
            where T : class, IStronglyTraceable<int>, new()
        {
            if (string.IsNullOrEmpty(filename.Trim()))
                throw new ArgumentException("Searching parameters cannot be null.", "filename");

            var match =
                (from item in itemSet
                 where item.Filename.ToLower() == filename.ToLower()
                 select item)
                 .FirstOrDefault();

            return match;
        }

        public static TheEchoNest FindBySongName(this ObjectSet<TheEchoNest> itemSet, String name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
                throw new ArgumentException("Searching parameters cannot be null.", "name");

            var match =
                    (from item in itemSet
                     where item.Song.Name == name.ToLower()
                     select item)
                     .FirstOrDefault();

            if (match != null)
                return match;

            TheEchoNest newEntry = new TheEchoNest() { ID = itemSet.GetNextID() };
            itemSet.AddObject(newEntry);
            return newEntry;
        }

        /// <summary>
        /// Searches for a record with the given name in the current object set. If a record exists,
        /// a valid entity is returned. Otherwise, a new record is created and then returned.
        /// </summary>
        /// <param name="name">The name to search for. Cannot be empty (in that case, an exception is thrown).</param>
        public static T FindByName<T>(this ObjectSet<T> itemSet, string name)
            where T : class, ITraceable<int>, new()
        {
            if (string.IsNullOrEmpty(name.Trim()))
                throw new ArgumentException("Searching parameters cannot be null.", "name");

            var match =
                (from item in itemSet
                 where item.Name.ToLower() == name.ToLower()
                 select item)
                 .FirstOrDefault();

            if (match != null)
                return match;

            T newEntry = new T() { ID = itemSet.GetNextID(), Name = name };
            itemSet.AddObject(newEntry);
            return newEntry;
        }
        /// <summary>
        /// A new record is created and then returned even if it already exists.
        /// </summary>
        /// <param name="name">The name of the record to create. Cannot be empty (in that case, an exception is thrown).</param>
        public static T AddDefaultValue<T>(this ObjectSet<T> itemSet, string name)
            where T : class, ITraceable<int>, new()
        {
            if (string.IsNullOrEmpty(name.Trim()))
                throw new ArgumentException("Search parameters cannot be null.", "name");

            T newEntry = new T() { ID = itemSet.GetNextID(), Name = name };
            itemSet.AddObject(newEntry);
            return newEntry;
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order in the current object set, according to a key.
        /// </summary>
        public static IEnumerable<T> OrderByName<T>(this ObjectSet<T> set)
            where T : class, ITraceable<int>
        {
            return set.OrderBy(item => item.Name);
        }
        /// <summary>
        /// Creates a new set of records from an enum set.
        /// </summary>
        /// <param name="enumSet">The type of the enum from which to create the record set.</param>
        public static T[] UpdateFromEnum<T>(this ObjectSet<T> itemSet, Type enumSet)
            where T : class, ITraceable<int>, new()
        {
            string[] values = Enum.GetNames(enumSet);
            T[] newEntries = new T[values.Length];

            foreach (var value in values)
                itemSet.FindByName(value);
            
            return newEntries;
        }
    }

    public static class XmlElementExtensions
    {
        public static T GetValue<T>(this XmlElement element, String xpath)
        {
            try
            {
                XmlNode node = element.SelectSingleNode(xpath);
                return (T)Convert.ChangeType(node.InnerText.Trim(), typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }

    public static class MemoryStreamExtensions
    {
        public static Byte[] ToByteArray(this MemoryStream stream)
        {
            Byte[] buffer = new Byte[stream.Length];
            stream.Position = 0;
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }

    public static class ImageExtensions
    {
        public static Byte[] ToByteArray(this System.Drawing.Image image)
        {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            Byte[] buffer = stream.ToArray();

            return buffer;
        }
    }

    public static class ByteArrayExtensions
    {
        public static Image ToImage(this Byte[] byteArray)
        {
            if (byteArray == null)
                return null;

            MemoryStream stream = new MemoryStream(byteArray);
            return Image.FromStream(stream);
        }

        public static String ToText(this Byte[] byteArray)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(byteArray);
        }
    }

    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Returns the index of item in the collection. If item isn't found, IndexOf returns -1.
        /// </summary>
        public static Int32 IndexOf<T>(this IEnumerable<T> collection, T item)
            where T : IEquatable<T>
        {
            Int32 index = 0;
            foreach (T element in collection)
            {
                if (element.Equals(item))
                    return index;
                index++;
            }

            return -1;
        }
    }
}