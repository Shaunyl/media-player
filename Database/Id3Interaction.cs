using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

using Tagger;
using Tagger.Mpeg.AudioFrameHeader;
using Tagger.ID3v1;
using Tagger.ID3v2;
using Tagger.IDWav;

namespace Shauni.Database
{
    using Tag = Tagger.Tag;
    using ImagePurpose = AttachedImageFrame.ImagePurpose;

    /// <summary>
    /// Implements an id3 reader based on the DeepTagger library. It is capable of adding information
    /// to a database direclty from mp3 tags. Here it is a list of all supported data: lyric, lyric's author,
    /// song duration, album title, album publisher, album tracks number, album publication date, album cover images (front/back), author or composer,
    /// composer image, main artist, main artist image, musical genre, group/band/orchestra.
    /// </summary>
    public class Id3SongCreator
    {
        private static readonly Regex genreExp = new Regex(@"\((?<Code>\w+)\)");

        private long sizeId3v1, sizeId3v2 = 0;

        protected ShauniDatabase database;
        protected ID3TagV1 id3v1;
        protected ID3TagV2 id3v2;
        protected MpegHeader mpegHeader;
        protected IDWav idwav;

        /// <summary>
        /// Determines whether to parse ID3v1.1 tags (old) or ID3v2.3 tags (new).
        /// </summary>
        public Boolean UseNewStandard { get; set; }

        /// <summary>
        /// Initializes an object that reads informations from an mp3 file and stores them into the given database.
        /// </summary>
        public Id3SongCreator(ShauniDatabase database)
        {
            this.database = database;
            this.id3v1 = new ID3TagV1();
            this.id3v2 = new ID3TagV2();
            this.mpegHeader = new MpegHeader();
            this.UseNewStandard = false;

            this.idwav = new IDWav();
        }

        /// <summary>
        /// Creates a Song object reading its data from the file's ID3 tags and adds it to the database if it is not already present.
        /// </summary>
        /// <param name="filename">Path to any mp3 file. Other types of files are not rejected if a valid ID3 tag is found within them.</param>
        public Song CreateFromFile(string filename)
        {
            Song song = (this.UseNewStandard) ? this.CreateFromNewId3Standard(filename) : this.CreateFromOldId3Standard(filename);

            if (song != null)
            {
                int? duration = song.Duration;
                song.Format = this.CreateFromAudioFrameHeader(filename, ref duration);
                song.Duration = duration;
                database.SaveChanges();
                return song;
            }
            else
                song = this.CreateFromWaveTagger(filename);

            if (song == null)
            {
                Song zeroInfoSong = database.Song.FindByName(GuessSongName(filename));
                zeroInfoSong.Filename = filename;

                return zeroInfoSong;
            }

            return song;
        }

        private Format CreateFromAudioFrameHeader(String filename, ref Int32? duration)
        {
            if (mpegHeader.Read(filename) != ReadingResult.Success)
                return null;

            if (!duration.HasValue || duration.Value == 0)
                duration = mpegHeader.Duration;

            Format format = database.Format.FindByName(mpegHeader.MpegFormat);
            format.BitRate = mpegHeader.BitRate;
            format.SamplingRate = mpegHeader.SamplingRate;
            format.Size = (int)mpegHeader.FileSize;

            return format;
        }

        #region Ricerca informazioni in file .Wav

        private Song CreateFromWaveTagger(String filename)
        {
            ReadingResult result = ReadingResult.Failure;
            try
            {
                result = idwav.Read(filename);
            }
            catch
            {
                return null;
            }
            if (result != Tagger.ReadingResult.Success)
                return null;

            String title = GetTextVoice("INAM");
            Song song = database.Song.FindByName(title);
            song.Filename = filename;
            song.Duration = (int)idwav.Duration;

            String artist = GetTextVoice("IART");
            song.Artist = database.Artist.FindByName(artist);

            String album = GetTextVoice("IPRD");
            song.Album = !string.IsNullOrEmpty(album) ? database.Album.FindByName(album)
                : database.Album.AddDefaultValue("Unknown");

            String genre = GetTextVoice("IGNR");
            try { song.Genre = database.Genre.Single(ignr => ignr.Name == genre); }
            catch { song.Genre = database.Genre.Single(ignr => ignr.ID == 13); }

            if (song.Album != null)
                song.Album.Genre = song.Genre;

            this.database.SaveChanges();

            return song;
        }

        #endregion

        #region Ricerca informazioni nel tag ID3v2.3

        private Song CreateFromNewId3Standard(string filename)
        {
            var result = id3v2.Read(filename);

            this.sizeId3v2 = this.id3v2.Size;

            if (result != Tagger.ReadingResult.Success)
            {
                this.id3v2.Frames.Clear();
                return null;
            }

            int duration = this.LookForDuration();

            Genre genre = this.LookForGenre();
            Artist artist = this.LookForArtist();
            Album album = this.LookForAlbum(genre);

            Song song = this.LookForSong(filename, genre, album, artist);
            song.Duration = duration;

            //this.database.SaveChanges();
            this.id3v2.Frames.Clear();

            return song;
        }

        private Song LookForSong(String filename, Genre genre, Album album, Artist artist)
        {
            var titleFrame = this.GetTextFrame("TIT2");
            String songTitle = titleFrame != null ? titleFrame.Text : GuessSongName(filename);

            Song song = database.Song.FindByName(songTitle);
            song.Filename = filename;
            song.Favourite = false;
            song.Stars = 0;

            song.Genre = genre;
            song.Album = album;
            song.Artist = artist;

            return song;
        }

        private int LookForDuration()
        {
            var durationFrame = this.GetTextFrame("TLEN");
            return (durationFrame != null) ? Convert.ToInt32(durationFrame.Text) / 1000 : 0;
        }

        private Album LookForAlbum(Genre genre)
        {
            var albumFrame = this.GetTextFrame("TALB");
            Album album = null;

            if (albumFrame != null)
            {
                album = !string.IsNullOrEmpty(albumFrame.Text) ? database.Album.FindByName(albumFrame.Text)
                    : database.Album.AddDefaultValue("Unknown");
            }
            else
                album = database.Album.AddDefaultValue("Unknown");

            this.LookForAlbumTrack(album);
            this.LookForAlbumYear(album);

            album.Genre = genre;
            this.database.SaveChanges();

            return album;
        }

        private void LookForAlbumTrack(Album album)
        {
            var trackFrame = this.GetTextFrame("TRCK");
            if ((trackFrame != null) && (trackFrame.Text.Contains('-')))
            {
                int trackCount = Convert.ToInt32(trackFrame.Text.Split('-')[1].Trim());
                album.TrackNumber = (short)trackCount;
            }
        }

        private void LookForAlbumYear(Album album)
        {
            var yearFrame = this.GetTextFrame("TYER");

            if (yearFrame != null)
                album.Year = new DateTime(Convert.ToInt32(yearFrame.Text), 1, 1).Year.ToString();
        }

        private void LookForAuthorImage(Artist artist)
        {
            var imageFrame = this.GetImageFrame(ImagePurpose.Composer);
            if (imageFrame != null)
                artist.Image = imageFrame.ImageData;
        }

        private Artist LookForArtist()
        {
            var artistFrame = this.GetTextFrame("TPE1");
            Artist artist = null;

            if (artistFrame != null)
            {
                if (!string.IsNullOrEmpty(artistFrame.Text))
                    artist = database.Artist.FindByName(ParseMainArtist(artistFrame.Text));
            }

            this.LookForArtistImage(artist);

            return artist;
        }

        private void LookForArtistImage(Artist artist)
        {
            var imageFrame = this.GetImageFrame(ImagePurpose.MainArtist, ImagePurpose.ArtistLogo, ImagePurpose.Artists);
            if (imageFrame != null)
                artist.Image = imageFrame.ImageData;
        }

        private Genre LookForGenre()
        {
            var genreFrame = this.GetTextFrame("TCON");
            Genre genre = null;

            if (genreFrame != null)
            {
                int id = ParseGenreID(genreFrame.Text);

                try { genre = database.Genre.Single(genres => genres.ID == id); }
                catch
                {
                    genre = database.Genre.Single(genres => genres.ID == 13);
                }
            }
            else
                genre = database.Genre.Single(genres => genres.ID == 13);

            return genre;
        }

        #endregion

        #region Ricerca informazioni nel tag ID3v1

        private Song CreateFromOldId3Standard(String filename) 
        {
            ReadingResult result = ReadingResult.Failure;

            try
            {
                result = id3v1.Read(filename);
            }
            catch
            {
                return null;
            }

            if (result != Tagger.ReadingResult.Success)
                return null;

            this.sizeId3v1 = id3v1.Size;

            Genre genre;
            this.LookForGenre(out genre);

            String songTitle = string.IsNullOrEmpty(id3v1.Title) ? GuessSongName(filename) : id3v1.Title;
            Song song = database.Song.FindByName(songTitle);
            song.Filename = filename;
            song.Genre = genre;

            this.LookForArtist(song);
            //this.LookForGenre(song);
            this.LookForAlbum(song);

            try
            {
                database.SaveChanges();
            }
            catch (System.Data.UpdateException ue)
            {
                //IMedia imedia = ((Song)ue.StateEntries[0].Entity);
                database.DeleteObject(ue.StateEntries[0].Entity);

                return null;
            }

            return song;
        }

        private void LookForArtist(Song song)
        {
            //Se non c'è artista, non può esservi la canzone.
            if (!string.IsNullOrEmpty(id3v1.Artist))
                song.Artist = database.Artist.FindByName(id3v1.Artist);
        }

        private void LookForAlbum(Song song)
        {
            //Se non c'è un album, non può esservi la canzone (però qui ci metto Unknown).
            song.Album = !string.IsNullOrEmpty(id3v1.Album) ? database.Album.FindByName(id3v1.Album)
                : database.Album.AddDefaultValue("Unknown");

            song.Album.TrackNumber = (short)id3v1.Track;
            song.Album.Year = id3v1.Year;

            if (song.Album != null)
                song.Album.Genre = song.Genre;
        }

        private Genre LookForGenre(out Genre genre)
        {
            int id = (Int32)id3v1.Genre + 1;

            try { genre = database.Genre.Single(g => g.ID == id); }
            catch
            {
                if (database.Genre.Count() == 0)
                {
                    database.Genre.UpdateFromEnum(typeof(Tagger.MusicalGenres));
                    database.SaveChanges();
                }

                genre = database.Genre.Single(g => g.ID == 13);
            }

            return genre;
        }

        /*private void LookForGenre(Song song)
        {
            int id = (Int32)id3v1.Genre + 1;

            try { song.Genre = database.Genre.Single(genre => genre.ID == id); }
            catch (InvalidOperationException)
            {
                SharedData.Database.Genre.UpdateFromEnum(typeof(Tagger.MusicalGenres));
                SharedData.Database.AcceptAllChanges();
                song.Genre = database.Genre.Single(genre => genre.ID == id);
            }
            catch
            {
                song.Genre = database.Genre.Single(genre => genre.ID == 13);
            }
        }*/

        #endregion

        private TextFrame GetTextFrame(string id)
        {
            return this.id3v2.Frames
                               .OfType<TextFrame>()
                               .Where(frame => frame.Header.Identifier == id)
                               .Where(frame => !string.IsNullOrEmpty(frame.Text.Trim()))
                               .FirstOrDefault();
        }

        private AttachedImageFrame GetImageFrame(params ImagePurpose[] purposes)
        {
            return id3v2.Frames
                                .OfType<AttachedImageFrame>()
                                .Where(frame => purposes.Any(purpose => frame.ImageType == purpose))
                                .FirstOrDefault();
        }

        private String GetTextVoice(String voiceID)
        {
            int index = this.idwav.AssociatedDataList.infoTag.Voices.FindIndex(voice => voice.ID == voiceID);
            return idwav.AssociatedDataList.infoTag.Voices[index].Name;
        }

        #region Metodi per il parsing

        private static string ParseMainArtist(string artists)
        {
            return artists.Split('/')
                          .Where(part => !string.IsNullOrEmpty(part.Trim()))
                          .FirstOrDefault();
        }

        private static int ParseGenreID(string genres)
        {
            var matches = genreExp.Matches(genres);

            if (matches.Count == 0)
                return 0;

            string genreCode = matches[0].Groups["Code"].Value;
            try
            {
                return Convert.ToInt32(genreCode) + 1;
            }
            catch
            {
                return 0;
            }
        }

        private static string GuessSongName(string filename)
        {
            string name = Path.GetFileNameWithoutExtension(filename);

            if (name.Contains('-'))
            {
                string[] parts = name.Split('-');
                if (!string.IsNullOrEmpty(parts[1]))
                    return parts[1].Trim();
            }

            return name;
        }

        #endregion
    }
}
