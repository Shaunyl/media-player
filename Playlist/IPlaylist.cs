using System;
using System.Collections.Generic;
using System.IO;

using Shauni.Database;

namespace Shauni.Playlist
{
    public enum PlaylistType
    {
        SimplePlaylist,
        AutomaticPlaylist
    }

    public interface IPlaylist<V> : IStronglyTraceable<Guid>
            where V : IMedia
    {
        IEnumerable<V> Media { get; }
        IFormatProvider<V> FormatProvider { get; set; }
        PlaylistType Type { get; }

        event EventHandler PlaylistSaved;

        void SaveToFile(String filename);
        void SaveToFile(String filename, IFormatProvider<V> formatProvider);
    }
}
