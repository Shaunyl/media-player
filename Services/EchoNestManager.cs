using System;
using System.Collections.Generic;
using System.Linq;

using EchoNest;
using EchoNest.Song;
using EchoNest.Playlist;

using Shauni.Properties;
using Shauni.Database;

namespace Shauni.Services
{
    public class EchoNestManager
    {
        private const String ApiKey = "RYAM5GUEXMPEOF5SR";//"1FAKXDUWTOOQI0CEN";
        private EchoNestSession echo;

        protected ShauniDatabase database;

        public EchoNestManager(ShauniDatabase database)
        {
            this.echo = new EchoNestSession(ApiKey);
            this.database = database;
        }

        public void FindBySong(Song song, SongBucket bucket)
        {
            var result = echo.Query<Search>().Execute(new SearchArgument
            {
                Title = song.Name,
                Artist = song.Artist.Name,
                Bucket = bucket
            });

            if (result.Status.Code != ResponseCode.Success) return;

            TheEchoNest echosong = database.TheEchoNest.FindBySongName(song.Name);

            if (echosong == null)
                return;

            var track = result.Songs.FirstOrDefault();
            this.UpdateAudioProperties(echosong, track);
            echosong.Song = song;

            SaveIntoDatabase();
        }

        private void SaveIntoDatabase() //non qua, è un metodo generale, non riferito esclusivamente a echomanager
        {
            try
            {
                database.SaveChanges();
            }
            catch (System.Data.UpdateException ue)
            {
                database.DeleteObject(ue.StateEntries[0].Entity);
                return;
            }
        }

        private PlaylistResponse Execute(String genre, int results)
        {
            return echo.Query<Static>().Execute(new StaticArgument()
            {
                Genre = genre,
                Results = results,
                Variety = 1,
                Type = "genre-radio",
                Bucket = PlaylistBucket.AudioSummary
            });
        }

        private PlaylistResponse Execute()
        {
            TermList styleTerms = new TermList();
            string[] styles = Settings.Default.SearchParametersForLearning.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (styles.Length == 0)
                return new PlaylistResponse() { Songs = null
                    , Status = new ResponseStatus() { Code = ResponseCode.MissingParameter
                        , Message = "Missing parameters for the search.", Version = null }  };

            foreach (string s in styles)
                styleTerms.Add(s.Trim());

            StaticArgument staticArgument = new StaticArgument()
            {
                Results = 15,
                Variety = 1,
                Type = "artist-description",
                Bucket = PlaylistBucket.AudioSummary
            };

            staticArgument.Styles.AddRange(styleTerms);

            return echo.Query<Static>().Execute(staticArgument);
        }

        public String UpdateTestSetFromUserDemand()
        {
            PlaylistResponse result = this.Execute();

            if (result.Status.Code == ResponseCode.Success)
                InsertSongs(result, null);

            return result.Status.Message;
        }

        private void InsertSongs(PlaylistResponse result, string genre)
        {
            for (int i = 0; i < result.Songs.Count; i++)
            {
                var track = result.Songs[i];

                Song song = database.Song.FindByName(track.Title);
                this.UpdateSong(song, track.ArtistName, genre);

                TheEchoNest echosong = database.TheEchoNest.FindBySongName(song.Name);

                if (echosong == null)
                    continue;

                this.UpdateAudioProperties(echosong, track);
                echosong.Song = song;

                SaveIntoDatabase();
            }
        }

        public void UpdateTestSetByGenre(String genre)
        {
            PlaylistResponse result = this.Execute(genre, 15);

            if (result.Status.Code != ResponseCode.Success) return;

            InsertSongs(result, genre);
        }

        private void UpdateSong(Song song, string artist, string genre)
        {
            song.Artist = database.Artist.FindByName(artist);
            song.Album = database.Album.AddDefaultValue("Unknown");

            try
            {
                if (genre == null)
                    song.Genre = database.Genre.Single(genres => genres.ID == 13);
                else
                    song.Genre = database.Genre.FindByName(genre);
            }
            catch (InvalidOperationException ioe)
            {
               // SharedData.Database.Genre.UpdateFromEnum(typeof(Tagger.MusicalGenres));
              //  SharedData.Database.SaveChanges();
            }

            song.Album.Genre = song.Genre;
        }

        private void UpdateAudioProperties(TheEchoNest song, SongBucketItem properties)
        {
            if (properties != null)
            {
                song.Tempo = properties.AudioSummary.Tempo;
                song.Loudness = properties.AudioSummary.Loudness;
                song.Key = properties.AudioSummary.Key;
                song.Mode = properties.AudioSummary.Mode;
                song.Energy = properties.AudioSummary.Energy;
                song.Danceability = properties.AudioSummary.Danceability;
            }
        }
    }
}
