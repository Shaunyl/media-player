using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Shauni.Database;
using System.IO;
using System.Linq;

namespace Shauni.UserControls
{
    public partial class MediaInfo : UserControl
    {
        public new string Text
        {
            get { return '-'.Halve(Space.Around, this.lblMediaArtist.Text, this.lblMediaTitle.Text); }
            set {

                string all = value;
                var artistTitle = all.Split('-');
                if (artistTitle.Count() > 1)
                {
                    this.lblMediaArtist.Text = artistTitle[0] + " -";
                    this.lblMediaTitle.Text = artistTitle[1];
                }
                else if (artistTitle.Count() == 1)
                {
                    this.lblMediaArtist.Text = artistTitle[0];
                    this.lblMediaTitle.Text = "";
                }
            }
        }

        public float StarsRate
        {
            get { return this.ratingBarStars.Rate; }
            set { this.ratingBarStars.Rate = value; }
        }

        public bool? FavouriteRate
        {
            get
            {
                if (this.ratingBarFavourite.Rate == 1) return true;
                else return false;
            }
            set
            {
                if (value == true)
                    this.ratingBarFavourite.Rate = 1;
                else this.ratingBarFavourite.Rate = 0;
            }
        }
        Graphics graphics;
        public MediaInfo()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
        }

        private void ratingBarStars_RateChanging(object sender, MediaRatedEventArgs e)
        {
            e.Media = ShauniListBox.CurrentSelectedMedia;
            e.Type = RatingType.Stars;
        }

        private void ratingBarFavourite_RateChanging(object sender, MediaRatedEventArgs e)
        {
            e.Media = ShauniListBox.CurrentSelectedMedia;
            e.Type = RatingType.Favourite;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.Width < 230)
            {
                this.ratingBarStars.Hide();
                this.ratingBarFavourite.Hide();
                lblMediaTitle.Hide();
                this.lblMediaArtist.Hide();

                ratingBarIsHidden = true;
            }
            else
            {
                if (ratingBarIsHidden)
                {
                    this.ratingBarStars.Show();
                    this.ratingBarFavourite.Show();
                    lblMediaTitle.Show();
                    this.lblMediaArtist.Show();

                    ratingBarIsHidden = false;
                }
            }
        }

        private bool ratingBarIsHidden = false;
    }
}
