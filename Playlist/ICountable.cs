using System;
using System.Collections.Generic;
using System.Collections;

namespace Shauni.Playlist
{
    public interface ICountable : IEnumerable
    {
        long Count { get; }
    }

    public interface ICountable<TItem> : IEnumerable<TItem>, ICountable, IEnumerable { }
}
