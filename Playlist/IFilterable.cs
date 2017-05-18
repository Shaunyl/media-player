using System;

using Shauni.Database;

namespace Shauni.Playlist
{
    public interface IFilterable<T, V> where T : Filter<V>
        where V : IMedia
    {
        FilterCollection<T, V> FilterMap { get; }
    }
}
