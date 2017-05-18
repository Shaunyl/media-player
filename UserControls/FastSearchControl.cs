using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Shauni.Database;

/*
 Di default la ricerca consiste nel ricercare artisti sulla base del nome dell'artista.
    Esempio: digito s e ottengo Sherwood - Home, etc ...
 Possibilità di ricercare una canzone a partire dal titolo.
    Esempio: digito h e ottengo Home - Sherwood, etc ...
 Possibilità di ricercare una canzone a partire dal rating (stelle).
    Esempio: mostrerà solo le canzoni col numero di stelle esplicitato.
  Possibilità di ricercare una canzone a partire dal flag di favorita.
    Esempio: mostrerà solo le canzoni col flag di favorita attivo.
 * 
 * Uso: FAV => 'true', STARS => '4', PATTERN => 'TITLE'
 * Azione: mostra sole le canzoni favorite con 4 stelle a partire dal titolo.
 * 
 * Possibilità di estendere il tool di ricerca. Ad esempio inserendo vincoli sul nome dell'album, ecc.
 * 
 * 
 * Creare una textbox personalizzata che supporti la variazione di font in atto di selezione.
 */


namespace Shauni.UserControls
{
    public enum MediaType
    {
        Song,
        Picture
    }

    public partial class FastSearchControl : UserControl
    {
        private AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
        private MediaType mediaType;

        public event EventHandler<MediaSearchedEventArgs> FileSearched;

        public FastSearchControl()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected void OnFileSearched(MediaSearchedEventArgs e)
        {
            e.MediaType = mediaType;

            if (FileSearched != null)
                FileSearched(this, e);
        }

        private void ImportMedia()
        {
            MediaSearchedEventArgs fbe = new MediaSearchedEventArgs(tbSearch.Text);
            OnFileSearched(fbe);
        }

        public void UpdateSource(string[] items, MediaType type)
        {
            this.mediaType = (type == MediaType.Picture) ? MediaType.Picture : MediaType.Song;

            autoComplete.Clear();
            autoComplete.AddRange(items);

            this.tbSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbSearch.AutoCompleteCustomSource = autoComplete;
        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            this.tbSearch.Font = new Font("Sergoe UI", 11f, FontStyle.Regular);
            this.tbSearch.ForeColor = Color.Black;

            if (this.tbSearch.Text == "Search for a media by artist...")
                this.tbSearch.Text = string.Empty;
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            this.tbSearch.Font = new Font("Sergoe UI", 11f, FontStyle.Italic);
            this.tbSearch.ForeColor = Color.DarkGray;

            if (this.tbSearch.Text.Length == 0)
                this.tbSearch.Text = "Search for a media by artist...";
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length == 0 | tbSearch.Text.Equals("Search for a media by artist..."))
            {
                //this.btnPlay.Enabled = false;
                return;
            }

            //if (!this.btnPlay.Enabled)
            //{
            //    this.btnPlay.Enabled = true;
            this.tbSearch.Font = new Font("Sergoe UI", 11f, FontStyle.Regular);
                this.tbSearch.ForeColor = Color.Black;
            //}
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter..
                this.ImportMedia();
        }
    }

    public class MediaSearchedEventArgs : EventArgs
    {
        public MediaType MediaType { get; set; }
        /// <summary>
        /// Allows the callee to set the player's CurrentMedia property to the media object that the selected path is referring to.
        /// </summary>
        public String Media { get; private set; }

        public MediaSearchedEventArgs(String media)
        {
            this.Media = media;
        }
    }
}
