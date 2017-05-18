using System;
using System.Linq;

using Shauni.Database;

namespace Shauni.Learning
{
    public enum Attribute
    {
        Tempo,
        Danceability,
        Energy,
        Key
    }

    public class TrainingSetRecord
    {
        public double Tempo { get; set; }
        public int Key { get; set; }
        public double Energy { get; set; }
        public double Danceability { get; set; }
        public IGrouping<object, Song> Grouping { get; set; }
    }
}
