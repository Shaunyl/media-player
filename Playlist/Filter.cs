using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq.Expressions;
using System.Xml;
using System.Linq;

using Shauni.Database;

namespace Shauni.Playlist
{
    public class Filter<V>
        where V : IMedia
    {
        public List<Song> Media { get; private set; }
        public Comparison Comparison { get; private set; }
        public FilterType Type { get; private set; }

        public Filter(string filter, string condition, string value)
        {
            this.Media = new List<Song>();
            this.Comparison = (Comparison)Enum.Parse(typeof(Comparison), condition, true);
            this.Type = (FilterType)Enum.Parse(typeof(FilterType), filter, true);
            this.Parse(Type, value);
        }

        public Filter(FilterType filter, Comparison condition, string value)
        {
            this.Media = new List<Song>();
            this.Comparison = condition;
            this.Type = filter;
            this.Parse(filter, value);
        }

        public bool Matches()
        {
            if (Media.Count > 0)
                return true;

            return false;
        }

        public bool Matches<T>(T data)
            where T : IMedia
        {
            if(Media.Cast<T>().Count() > 0)
                return true;

            return false;
        }

        public void Parse(FilterType filter, string value) //Stars
        {
            switch (filter)
            {
                case FilterType.Stars:
                    {
                        Filtrate<byte>(SharedData.Database.Song.Select(s => (byte)s.Duration).ToList(), byte.Parse(value))
                            .ToList().ForEach(s => Media.Add(SharedData.Database.Song.Where(song => song.Duration == s).FirstOrDefault()));
                    } break;
                case FilterType.Title:
                    {
                        Filtrate<string>(SharedData.Database.Song.Select(s => s.Name).ToList(), value)
                            .ToList().ForEach(s => Media.Add(SharedData.Database.Song.Where(song => song.Name == s).FirstOrDefault()));
                    } break;
                case FilterType.Count:
                    {
                        Filtrate<int>(SharedData.Database.Song.Select(s => s.Counter).ToList(), int.Parse(value))
                            .ToList().ForEach(s => Media.Add(SharedData.Database.Song.Where(song => song.Counter == s).FirstOrDefault()));
                    } break;
                case FilterType.Duration:
                    {
                        Filtrate<int>(SharedData.Database.Song.Select(s => (int)s.Duration).ToList(), int.Parse(value))
                            .ToList().ForEach(s => Media.Add(SharedData.Database.Song.Where(song => song.Duration == s).FirstOrDefault()));
                    } break;
                case FilterType.Favourite:
                    {
                        Filtrate<bool>(SharedData.Database.Song.Select(s => (bool)s.Favourite).ToList(), bool.Parse(value))
                            .ToList().ForEach(s => Media.Add(SharedData.Database.Song.Where(song => song.Favourite == s).FirstOrDefault()));
                    } break;
                default: // Artist
                    {
                        Filtrate<string>(SharedData.Database.Song.Select(s => s.Artist.Name).ToList(), value)
                            .ToList().ForEach(s => Media.Add(SharedData.Database.Song.Where(song => song.Artist.Name == s).FirstOrDefault()));
                    } break;
            }
        }

        private List<T> Filtrate<T>(List<T> query, T value)
            where T : IComparable
        {
            List<T> result = null;

            switch (this.Comparison)
            {
                case Comparison.EqualTo: {
                        result = query.Where(s => s.CompareTo(value) == 0).ToList(); } break;
                case Comparison.GreaterThan: {
                        result = query.Where(s => s.CompareTo(value) > 0).ToList(); } break;
                case Comparison.GreaterThanOrEqualTo: {
                        result = query.Where(s => s.CompareTo(value) >= 0).ToList(); } break;
                case Comparison.LessThan: {
                        result = query.Where(s => s.CompareTo(value) < 0).ToList(); } break;
                case Comparison.LessThanOrEqualTo: { 
                        result = query.Where(s => s.CompareTo(value) <= 0).ToList(); } break;
                default: { //NotEqualTo
                        result = query.Where(s => s.CompareTo(value) != 0).ToList(); } break;
            }

            return result;
        }

    }

    public class FilterCollection<T, V> : List<T>, IList
        where T : Filter<V>
        where V : IMedia
    {
    }

    [Flags]
    public enum Comparison : byte
    {
        GreaterThan = 0x50, //0101.0000 //>Q ... Trance
        LessThan = 0x12, //0001.0010 //<Q ... Pop & House
        EqualTo = 0x81, //1000.0001 //=Trance ... Trance
        NotEqualTo = GreaterThan | LessThan, //0101.0010 //!=Trance ... Pop & House
        LessThanOrEqualTo = LessThan | EqualTo, //1001.0011 //>= P ... Pop & Trance
        GreaterThanOrEqualTo = GreaterThan | EqualTo, //1101.0001 <= P ... Pop & House
    }

    public enum FilterType
    {
        Artist,
        Stars,
        Title,
        Count,
        Favourite,
        Duration
    }
}
