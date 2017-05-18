using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Shauni.Database;

namespace Shauni.Forms
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void DatabaseSearching()
        {
            this.mediaListBox.BeginUpdate();
            this.mediaListBox.Items.Clear();

            string key = this.tbSearch.Text;

            var songs = SharedData.Database.Song.Where(s => s.Name.Contains(key)
                | s.Artist.Name.Contains(key) | s.Genre.Name.Contains(key)
                | s.Album.Name.Contains(key));

            foreach (Song song in songs)
                this.mediaListBox.Items.Add(song);

            this.mediaListBox.EndUpdate();

            this.lblSearch.Text = this.mediaListBox.Items.Count + " media have been found!";
        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            this.tbSearch.Font = new Font("Miramonte", 9.75f, FontStyle.Regular);
            this.tbSearch.ForeColor = Color.Black;

            if (this.tbSearch.Text == "Search for a media in the shauni database...")
                this.tbSearch.Text = string.Empty;
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            this.tbSearch.Font = new Font("Miramonte", 9.75f, FontStyle.Italic);
            this.tbSearch.ForeColor = Color.DarkGray;

            if (this.tbSearch.Text.Length == 0)
                this.tbSearch.Text = "Search for a media in the shauni database...";
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length == 0 | tbSearch.Text.Equals("Search for a media in the shauni database..."))
            {
                return;
            }

            if (!this.tbSearch.Enabled)
            {
                //tbSearch.Enabled = true;
                this.tbSearch.Font = new Font("Miramonte", 9.75f, FontStyle.Regular);
                this.tbSearch.ForeColor = Color.Black;
            }
        }

        private void mediaListBox_ItemClicked(object sender, UserControls.ItemClickedEventArgs e)
        {
            if (this.mediaListBox.SelectedItem != null && this.mediaListBox.Items.Count > 0)
            {
                IMedia media = mediaListBox.SelectedItem as IMedia;

                if (media == null)
                    return;

                if (media is Song)
                {
                    Song sng = (Song)media;

                    string artistName = sng.Artist.Name;

                    if (!artistName.Equals(this.lblTextArtist.Text)) //bug..
                    {
                        this.lblTextArtist.Text = artistName;

                        SharedData.Downloader.PreferredImageFormat = Shauni.Services.ImageFormat.ExtraLarge;
                        try
                        {
                            EnableLoadingCircle(true);
                            SharedData.Downloader.FindSong(sng.Name, artistName, med => UpdateInformation(artistName, med));
                        }
                        catch
                        {
                            this.lblSearch.Text = artistName + " - " + sng.Name + " is not contained in the last.fm databases";
                            return;
                        }
                    }

                    this.lblTextAlbum.Text = sng.Album.Name;
                    this.lblTextDuration.Text = Utility.ParseDuration((int)sng.Duration);
                    this.lblTextGenre.Text = sng.Genre.Name;
                }
            }
        }

        private void UpdateAlbumCover(Song song)
        {
            var cover = song.Album.Covers.FirstOrDefault();
            if (cover != null)
                this.pbAlbum.Image = cover.Front.ToImage();
            else
                this.pbAlbum.Image = null;
        }

        private void UpdateArtistImage(Song song)
        {
            Image image = song.Artist.Image.ToImage();
            if (image != null)
                this.pbMedia.Image = image;
            else
                this.pbMedia.Image = null;
        }

        private void UpdateInformation(String artist, Song song)
        {
            if (song == null)
                return;

            var plugin = SharedData.PluginManager(null).Plugins.Values.Where(plug => plug.Name.Equals("LyricsManager")).FirstOrDefault();

            if (plugin != null & plugin.WorkableData)
            {
                Lyric l = new Lyric() { ID = SharedData.Database.Lyrics.GetNextID() };

                Lyric lyric = SharedData.Database.Lyrics.CreateObject();
                song.Lyric = lyric;
                song.Lyric.Text = (String)plugin.Run("LyricsMania", song.Artist.Name, song.Name);
                this.Invoke(new Action(() => this.UpdateLyrics(song)));
            }

            this.UpdateArtistImage(song);
            this.UpdateAlbumCover(song);

            this.Invoke(new Action(() => this.wbBio.DocumentText = song.Artist.Biography));
            this.Invoke(new Action(() => this.EnableLoadingCircle(false)));
        }

        private void EnableLoadingCircle(bool enable)
        {
            this.loadingCircle.Visible = enable;
            this.loadingCircle.Active = enable;
        }

        private void UpdateLyrics(Song song)
        {
            this.rtbLyrics.Text = song.Lyric.Text;
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter..
                this.DatabaseSearching();
        }
    }
}
