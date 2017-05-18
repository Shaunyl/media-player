using System;
using System.Collections.Generic;
using System.Linq;

using Maths.Learning;
using Maths.Graphs;
using Maths;

using Shauni.Learning;

namespace Shauni.Database
{
    public class BusinessLogicLayer
    {
        public String GetBestGenre()
        {
            var genre =
                (from p in SharedData.Database.Song.Where(s => s.Favourite == true)
                 group p by p.Genre.Name into g
                 select new { Genre = g.Key, Counter = g.Sum(p => p.Counter) });

            if (genre.Count() == 0)
                return null;

            return genre.OrderByDescending(s => s.Counter).FirstOrDefault().Genre.ToLower();
        }

        private Song CreateSongById3(String filename)
        {
            return SharedData.Id3SongCreator.CreateFromFile(filename);
        }

        public Song GetSongByFilename(String filename)
        {
            Song song = SharedData.Database.Song.FindByFilename(filename);

            return song != null ? song : this.CreateSongById3(filename);
        }

        public Song GetSongByName(String name)
        {
            return SharedData.Database.Song.Where(m => m.Name == name).FirstOrDefault();
        }

        public IEnumerable<TrainingSetRecord> ExtractDataForLearning()
        {
            return (from song in SharedData.Database.Song.Where(s => s.Favourite.HasValue).Where(s => s.EchoNest.Tempo != null && s.Filename != null)
                    group song by new { song.EchoNest.Tempo, song.EchoNest.Danceability, song.EchoNest.Energy, song.EchoNest.Key } into datas
                    select new TrainingSetRecord
                    {
                        Tempo = datas.Key.Tempo.Value,
                        Danceability = datas.Key.Danceability.Value,
                        Energy = datas.Key.Energy.Value,
                        Key = datas.Key.Key,
                        Grouping = datas
                    }).ToList();
        }

        public Song ExtractSongRandomly()
        {
            var songs = SharedData.Database.Song.Where(f => f.Filename == null).ToList();
            if (songs.Count == 0)
                return null;
            return songs[new Random().Next(songs.Count() - 1)];
        }
    }
}

