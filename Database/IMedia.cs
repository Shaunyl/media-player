using System;

namespace Shauni.Database
{
    /// <summary>
    /// Represents an identifiable object. Exposes its ID of type V.
    /// </summary>
    public interface IIdentifiable<V>
        where V : struct
    {
        V ID { get; set; }
    }

    /// <summary>
    /// Represents a traceable object. Exposes its ID (of type T) and Name.
    /// </summary>
    public interface ITraceable<V> : IIdentifiable<V>
        where V : struct
    {
        string Name { get; set; }
    }

    /// <summary>
    /// Represents a datable object. Exposes its ID (of type System.Int32) and DateTime.
    /// </summary>
    public interface IDatable : IIdentifiable<int>
    {
        DateTime Date { get; set; }
    }

    /// <summary>
    /// Represents a rateable object. Exposes its number of Stars, its View Count and its Favourite flag.
    /// </summary>
    public interface IRateable
    {
        byte? Stars { get; set; }
        int Counter { get; set; }
        bool? Favourite { get; set; }
    }

    /// <summary>
    /// Represents a strongly traceable object. Implements ITraceable and in more exposes its Filename and Author.
    /// </summary>
    public interface IStronglyTraceable<V> : ITraceable<V>
        where V : struct
    {
        string Filename { get; set; }
        string Author { get; set; }
    }

    public interface IPlayable
    {
        bool IsPlaying { get; set; }
    }

    public interface IDurationable
    {
        int? Duration { get; set; }
    }

    /// <summary>
    /// Represents a generic media object (for example a song, a movie or a picture).
    /// </summary>
    public interface IMedia : IStronglyTraceable<int>, IRateable
    {
    }

    public partial class TheEchoNest : IIdentifiable<int>
    {
    }

    public partial class Song : IMedia, IPlayable, IDurationable
    {
        public bool IsPlaying { get; set; }

        /*protected T Execute<T>(string url, params object[] arguments)
            where T : class
        {
            url = string.Format(url, arguments);
            HttpResponseMessage response = HttpClient.GetAsync(url).Result;
            return GetObject<T>(response);
        }*/
    }

    public partial class Picture : IMedia
    {
    }

    public partial class Album : ITraceable<int> { }

    public partial class Format : ITraceable<int> { }

    public partial class Genre : ITraceable<int> { }

    public partial class Artist : ITraceable<int> { }

    public partial class Lyric : IIdentifiable<int> { }

    public partial class Cover : IIdentifiable<int> { }

    public partial class TimeLine : IDatable { }

    public partial class AudioStatistic : IIdentifiable<int> { }
}
