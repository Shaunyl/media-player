using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Shauni.Database;
using Tagger.ID3v1;

namespace Shauni.UserControls
{
    using Resources = Shauni.Properties.Resources;

    public partial class TaggerTab : UserControl, IMessageFilter
    {
        private const int WM_KEYUP = 0x101;
        private bool isFormFieldChanged = false;
        private IMedia currentMedia = null;

        [Description("Prova.")]
        public event EventHandler<MediaTagsLoadedEventArgs> MediaLoaded;

        public TaggerTab()
        {
            Application.AddMessageFilter(this);
            InitializeComponent();
        }

        protected void OnMediaLoaded(MediaTagsLoadedEventArgs e)
        {
            if (MediaLoaded != null)
                MediaLoaded(this, e);
        }

        private void TaggerTab_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
                return;
            else
            {
                MediaTagsLoadedEventArgs ple = new MediaTagsLoadedEventArgs();
                this.OnMediaLoaded(ple);

                this.Update(ple.Media);
            }
        }

        public bool PreFilterMessage(ref Message m)
        {
            bool ret = true;
            if (m.Msg == WM_KEYUP)
            {
                if (this.ActiveControl is TextBox)
                {
                    isFormFieldChanged = true;
                    ret = true;
                    this.EnableSaving();
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        private void EnableSaving()
        {
            this.btnSave.Enabled = true;
        }

        public void Update(IMedia media)
        {
            if (DesignMode)
                return;

            this.lblStandard.Text = SharedData.Id3SongCreator.UseNewStandard ? "ID3 v2" : "ID3 v1";

            if (media == null)
                return;

            this.currentMedia = media;

            this.tbCounter.Text = media.Counter.ToString();
            this.tbTitle.Text = media.Name;
            this.tbFilename.Text = media.Filename;
            this.rbStars.Rate = (float)media.Stars;
            this.pbFavourite.Image = media.Favourite == true ? Resources.FavMedia : Resources.whiteheart;
            try
            {
                float average = (float)SharedData.Database.Song.Where(s => s.Artist.Name == ((Song)media).Artist.Name).Select(r => r.Stars).Average(a => a);
                this.rbArtistStars.Rate = average;
            }
            catch
            {

            }

            if (media is Song)
            {
                Song song = media as Song;
                this.tbArtist.Text = song.Artist.Name;
                this.tbAlbum.Text = song.Album.Name == "Unknown" ? String.Empty : song.Album.Name;
                this.tbGenre.Text = song.Genre.Name;
                this.tbTrack.Text = song.Album.TrackNumber.ToString();
                this.tbYear.Text = String.Format("{0:MM/dd/yyyy}", song.Album.Year); ;

                if (song.Duration != null)
                    this.tbDuration.Text = Utility.ParseDuration((int)song.Duration);

                if (song.Format != null)
                {
                    this.tbBitRate.Text = ((double)song.Format.BitRate).ToString() + " kbps";
                    this.tbSamplingRate.Text = song.Format.SamplingRate.ToString() + " Hz";
                    this.tbFileSize.Text = (Math.Round((double)song.Format.Size / (1024 * 1024), 2)).ToString() + " MB";
                    this.tbAudioFormat.Text = song.Format.Name;
                }
                else
                {
                    this.tbFileSize.Text = Math.Round((double)new System.IO.FileInfo(song.Filename).Length / (1024 * 1024), 2).ToString() + " MB";
                    this.tbBitRate.Text = String.Empty;
                    this.tbSamplingRate.Text = String.Empty;
                    this.tbFileSize.Text = String.Empty;
                    this.tbAudioFormat.Text = String.Empty;
                }
            }
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            this.pnlMain.Visible = false;
            this.pnlUser.Visible = false;
        }

        private void btnPrevFromAdvancedTab_Click(object sender, EventArgs e)
        {
            this.pnlUser.Visible = true;
            this.pnlMain.Visible = true;
        }

        private void btnPrevFromUserTab_Click(object sender, EventArgs e)
        {
            this.pnlMain.Visible = true;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            this.pnlMain.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveToFile();
            this.SaveToDatabase();

            this.btnSave.Enabled = false;
        }

        private void SaveToDatabase()
        {
            Song song = SharedData.Database.Song.Where(s => s.Filename.Equals(this.currentMedia.Filename)).FirstOrDefault();
            song.Name = this.tbTitle.Text.Trim();
            song.Artist.Name = this.tbArtist.Text.Trim();
            song.Album.Name = this.tbAlbum.Text.Trim();
            song.Genre.Name = this.tbGenre.Text.Trim();
            song.Album.Year = this.tbYear.Text.Trim();

            string track = this.tbTrack.Text.Trim();
            int trackOk;
            if (int.TryParse(track, out trackOk))
                song.Album.TrackNumber = (short?)trackOk;

            SharedData.Database.SaveChanges();
        }

        private void SaveToFile()
        {
            ID3TagV1 id3v1 = new ID3TagV1();
            id3v1.Read(this.currentMedia.Filename);

            id3v1.Title = this.tbTitle.Text.Trim();
            id3v1.Artist = this.tbArtist.Text.Trim();
            id3v1.Album = this.tbAlbum.Text.Trim();

            string genre = this.tbGenre.Text.Trim();
            if (Enum.IsDefined(typeof(Tagger.MusicalGenres), genre))
                id3v1.Genre = (Tagger.MusicalGenres)Enum.Parse(typeof(Tagger.MusicalGenres), genre, true);

            id3v1.Year = this.tbYear.Text;

            string track = this.tbTrack.Text.Trim();
            int trackOk;
            if (int.TryParse(track, out trackOk))
                id3v1.Track = trackOk;

            id3v1.Write();
        }

        public void Translate(System.Resources.ResourceManager resourceManager, System.Globalization.CultureInfo culture)
        {
            this.lblAlbumTag.Text = resourceManager.GetString("lblAlbumTag.Text", culture);
            this.lblArtistTag.Text = resourceManager.GetString("lblArtistTag.Text", culture);
            this.lblGenreTag.Text = resourceManager.GetString("lblGenreTag.Text", culture);
            this.lblTitleTag.Text = resourceManager.GetString("lblTitleTag.Text", culture);
            this.lblTrackNTag.Text = resourceManager.GetString("lblTrackNTag.Text", culture);
            this.lblYearTag.Text = resourceManager.GetString("lblYearTag.Text", culture);
            this.lblIsFavourite.Text = resourceManager.GetString("lblIsFavourite.Text", culture);
            this.lblRating.Text = resourceManager.GetString("lblRating.Text", culture);
            this.lblSamplingRate.Text = resourceManager.GetString("lblSamplingRate.Text", culture);
            this.lblFileSize.Text = resourceManager.GetString("lblFileSize.Text", culture);
            this.lblFilename.Text = resourceManager.GetString("lblFilename.Text", culture);
            this.lblDuration.Text = resourceManager.GetString("lblDuration.Text", culture);
            this.lblCounter.Text = resourceManager.GetString("lblCounter.Text", culture);
            this.lblBitRate.Text = resourceManager.GetString("lblBitRate.Text", culture);
            this.lblAudioFormat.Text = resourceManager.GetString("lblAudioFormat.Text", culture);
        }
    }

    public class MediaTagsLoadedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the path to the file being loaded by the browse dialog.
        /// </summary>
        public IMedia Media { get; set; }

        public MediaTagsLoadedEventArgs() { }
    }
}
