using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using Shauni.Database;

namespace Shauni.UserControls
{
    public enum RatingType
    {
        Stars,
        Favourite
    }

    public class RatingBar : Control
    {
        [Description("Occurs when the rate changes.")]
        public event EventHandler<MediaRatedEventArgs> RateChanging;

        private PictureBox picture;
        private Bitmap tb;

        private byte gap = 1, iconsCount = 10;
        private float rate = 0, tempRateHolder = 0;
        private bool readOnly = false, rateOnce = false, isVoted = false;

        private ContentAlignment alignment = ContentAlignment.MiddleCenter;

        protected Image iconEmpty;
        [Category("Icons")]
        [Browsable(true), Description("Gets or sets the image of the empty state.")]
        public Image IconEmpty
        {
            get { return this.iconEmpty; }
            set { this.iconEmpty = value; }
        }

        protected Image iconHalf;
        [Category("Icons")]
        [Browsable(true), Description("Gets or sets the image of the empty state.")]
        public Image IconHalf
        {
            get { return this.iconHalf; }
            set { this.iconHalf = value; }
        }

        protected Image iconFull;
        [Category("Icons")]
        [Browsable(true), Description("Gets or sets the image of the empty state.")]
        public Image IconFull
        {
            get { return this.iconFull; }
            set { this.iconFull = value; }
        }

        public RatingBar()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            picture = new PictureBox();
            picture.BackgroundImageLayout = ImageLayout.None;
            picture.MouseMove += new MouseEventHandler(picture_MouseMove);
            picture.MouseLeave += new EventHandler(picture_MouseLeave);
            picture.MouseClick += new MouseEventHandler(picture_MouseClick);
            picture.Cursor = Cursors.Hand;
            this.Controls.Add(picture);
            UpdateIcons();
            UpdateBarSize();

            // Drawing empty icons
            using (tb = new Bitmap(picture.Width, picture.Height))
            {
                using (Graphics g = Graphics.FromImage(Properties.Resources.blues))
                   // DrawEmptyIcons(g, 0, iconsCount);
                    //g.DrawImage(iconHalf, 0, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                //x += gap + iconEmpty.Width;

                picture.BackgroundImage = tb;
            }
        }

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (readOnly || (rateOnce && isVoted))
                return;

            int x = 0;
            float trate = 0;
            byte ticonsCount = iconsCount; // temporary variable to hold the iconsCount value, because we're decreasing it on each loop

            tb.Dispose();
            tb = new Bitmap(picture.Width, picture.Height);
            Graphics g = Graphics.FromImage(tb);
            picture.BackgroundImage = tb;

            for (int a = 0; a < iconsCount; a++)
            {
                if (e.X > x && e.X <= x + iconEmpty.Width / 2)
                {
                    g.DrawImage(iconHalf, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                    trate += 0.5f;
                }
                else if (e.X > x)
                {
                    g.DrawImage(iconFull, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                    trate += 1.0f;
                }
                else
                    break;
                ticonsCount--;
            }
            tempRateHolder = trate;
            DrawEmptyIcons(g, x, ticonsCount);
            g.Dispose();
        }

        private void picture_MouseLeave(object sender, EventArgs e)
        {
            if (readOnly || (rateOnce && isVoted))
                return;

            tb.Dispose();
            tb = new Bitmap(picture.Width, picture.Height);
            Graphics g = Graphics.FromImage(tb);
            picture.BackgroundImage = tb;

            int x = 0;
            byte ticonsCount = iconsCount;
            float trate = rate;
            while (trate > 0)
            {
                if (trate > 0.5f)
                {
                    g.DrawImage(iconFull, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                }
                else if (trate == 0.5f)
                {
                    g.DrawImage(iconHalf, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                }
                else
                    break;
                ticonsCount--;
                trate--;
            }
            DrawEmptyIcons(g, x, ticonsCount);

            g.Dispose();
        }

        private void picture_MouseClick(object sender, MouseEventArgs e)
        {
            float toldRate = rate;

            if (e.Button == MouseButtons.Left)
            {
                rate = tempRateHolder;
                isVoted = true;

                if (rateOnce)
                    picture.Cursor = Cursors.Default;
            }
            else if (e.Button == MouseButtons.Right)
            {
                rate = tempRateHolder = 0;
                isVoted = false;
            }

            MediaRatedEventArgs mre = new MediaRatedEventArgs(false, rate, toldRate);

            this.OnRateChanging(mre);

            if (mre.Media == null)
                return;

            if (mre.Type == RatingType.Stars)
                mre.Media.Stars = Convert.ToByte(mre.NewRate);
            else
                mre.Media.Favourite = mre.NewRate == 0 ? false : true;

            SharedData.Database.SaveChanges();
        }

        #region --- Override Functions ---
        protected override void OnResize(EventArgs e)
        {
            UpdateBarLocation();
            base.OnResize(e);
        }
        #endregion

        #region --- Custom Functions ---

        private void DrawIcons()
        {
            int x = 0;
            byte ticonsCount = iconsCount;
            float trate = rate;

            tb.Dispose();
            tb = new Bitmap(picture.Width, picture.Height);
            Graphics g = Graphics.FromImage(tb);
            picture.BackgroundImage = tb;

            while (trate > 0)
            {
                if (trate > 0.5f)
                {
                    g.DrawImage(iconFull, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                }
                else if (trate == 0.5f)
                {
                    g.DrawImage(iconHalf, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                }
                else
                 break;
                
                ticonsCount--;
                trate--;
            }

            DrawEmptyIcons(g, x, ticonsCount);
            g.Dispose();
        }

        private void DrawEmptyIcons(Graphics g, int x, byte count)
        {
            for (byte a = 0; a < count; a++)
            {
                /*g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(iconEmpty, x, 0);
                x += gap + iconEmpty.Width;*/
                g.DrawImage(iconEmpty, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                x += gap + iconEmpty.Width;
            }
        }

        private void UpdateBarSize()
        {
            picture.Size = new Size((iconEmpty.Width * iconsCount) + (gap * (iconsCount - 1)), iconEmpty.Height); // Last icon wont need gap, therefore we need to use -1
            UpdateBarLocation();
        }

        private void UpdateBarLocation()
        {
            if (alignment == ContentAlignment.TopLeft) { }// Leave it blank, Since we're calling this from Resize Event then we dont need to set same point again and again
            else if (alignment == ContentAlignment.TopRight)
                picture.Location = new Point(this.Width - picture.Width, 0);
            else if (alignment == ContentAlignment.TopCenter)
                picture.Location = new Point(this.Width / 2 - picture.Width / 2, 0);
            else if (alignment == ContentAlignment.BottomLeft)
                picture.Location = new Point(0, this.Height - picture.Height);
            else if (alignment == ContentAlignment.BottomRight)
                picture.Location = new Point(this.Width - picture.Width, this.Height - picture.Height);
            else if (alignment == ContentAlignment.BottomCenter)
                picture.Location = new Point(this.Width / 2 - picture.Width / 2, this.Height - picture.Height);
            else if (alignment == ContentAlignment.MiddleLeft)
                picture.Location = new Point(0, this.Height / 2 - picture.Height / 2);
            else if (alignment == ContentAlignment.MiddleRight)
                picture.Location = new Point(this.Width - picture.Width, this.Height / 2 - picture.Height / 2);
            else if (alignment == ContentAlignment.MiddleCenter)
                picture.Location = new Point(this.Width / 2 - picture.Width / 2, this.Height / 2 - picture.Height / 2);
        }

        private void UpdateIcons()
        {
            this.iconEmpty = Properties.Resources.StarEmpty2;
            this.iconFull = Properties.Resources.StarFull;
            this.iconHalf = Properties.Resources.Starhalffull;
        }
        #endregion

        #region --- Properties ---
        public byte Gap
        {
            get { return gap; }
            set { gap = value; }
        }
        public byte IconsCount
        {
            get { return iconsCount; }
            set { if (value <= 10) { iconsCount = value; UpdateBarSize(); } }
        }
        [DefaultValue(typeof(ContentAlignment), "middlecenter")]
        public ContentAlignment Alignment
        {
            get { return alignment; }
            set
            {
                alignment = value;
                if (value == ContentAlignment.TopLeft)
                    picture.Location = new Point(0, 0);
                else UpdateBarLocation();
            }
        }

        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; if (value)picture.Cursor = Cursors.Default; else picture.Cursor = Cursors.Hand; }
        }

        [DefaultValue(false)]
        public bool RateOnce
        {
            get { return rateOnce; }
            set { rateOnce = value; if (!value) picture.Cursor = Cursors.Hand; /* Set hand cursor, if false is set from true*/ }
        }

        [Browsable(false)]
        public float Rate
        {
            get { return rate; }
            set
            {
                if (value >= 0 && value <= (float)iconsCount)
                {
                    float toldRate = rate;
                    rate = value;
                    DrawIcons();
                    OnRateChanging(new MediaRatedEventArgs(true, value, toldRate));
                }
                else
                    throw new ArgumentOutOfRangeException("Rate", "Value '" + value + "' is not valid for 'Rate'. Value must be Non-negative and less than or equals to '" + iconsCount + "'");
            }
        }

        public Color BarBackColor
        {
            get { return picture.BackColor; }
            set { picture.BackColor = value; }
        }

        #endregion

        protected void OnRateChanging(MediaRatedEventArgs e)
        {
            if (RateChanging != null && e.NewRate != e.OldRate)
                RateChanging(this, e);
        }
    }

    public class MediaRatedEventArgs : CancelEventArgs
    {
        /// <summary>
        /// Gets the new rate of the media.
        /// </summary>
        public float NewRate { get; private set; }

        /// <summary>
        /// Gets the old rate of the media.
        /// </summary>
        public float OldRate { get; private set; }

        /// <summary>
        /// Allows the caller to set the rating bar's CurrentSelectedMedia property to the media object that the selected path is referring to.
        /// </summary>
        public IMedia Media { get; set; }

        public RatingType Type { get; set; }

        public MediaRatedEventArgs(bool cancel, float newRate, float oldRate)
            : base(cancel)
        {
            this.NewRate = newRate;
            this.OldRate = oldRate;
        }
    }
}