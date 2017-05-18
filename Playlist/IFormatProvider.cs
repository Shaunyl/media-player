using System;

using Shauni.Database;

namespace Shauni.Playlist
{
    /// <summary>
    /// Represents the implementation of a format provider.
    /// </summary>
    public interface IFormatProvider<V>
        where V : IMedia
    {
        /// <summary>
        /// Returns a collection of all the strongly connected components in the graph.
        /// </summary>
        void Save<T>(String filename)
            where T : IPlaylist<V>, new();

        T Load<T>(String filename)
            where T : IPlaylist<V>, new();
    }
}