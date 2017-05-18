using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shauni.UserControls
{
    public partial class MediaPanel : Panel
    {
        public MediaPanel()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
        }

        private int borderWidth = 2;
        [Browsable(true), Description("Gets or sets the border width."), Category("Advanced")]
        [DefaultValue(2)]
        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; Invalidate(); }
        }

        int shadowOffSet = 5;
        [Browsable(true), Description("Gets or sets the shadow offset."), Category("Advanced")]
        [DefaultValue(5)]
        public int ShadowOffSet
        {
            get { return shadowOffSet; }
            set { shadowOffSet = Math.Abs(value); Invalidate(); }
        }

        int roundCornerRadius = 1;
        [Browsable(true), Description("Gets or sets the round corner radius."), Category("Advanced")]
        [DefaultValue(1)]
        public int RoundCornerRadius
        {
            get { return roundCornerRadius; }
            set { roundCornerRadius = Math.Abs(value); Invalidate(); }
        }

        Image image;
        [Browsable(true), Description("Gets or sets the image drawned into the panel."), Category("Advanced")]
        public Image Image
        {
            get { return image; }
            set { image = value; Invalidate(); }
        }

        Point imageLocation = new Point(4, 4);
        [Browsable(true), Description("Gets or sets the location of the image contained into the panel."), Category("Advanced")]
        [DefaultValue("4, 4")]
        public Point ImageLocation
        {
            get { return imageLocation; }
            set { imageLocation = value; Invalidate(); }
        }

        Color borderColor = Color.Gray;
        [Browsable(true), Description("Gets or sets the color of the border."), Category("Advanced")]
        [DefaultValue("Color.Gray")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        Color gradientStartColor = Color.AliceBlue;
        [Browsable(true), Description("Gets or sets the background gradient star color."), Category("Advanced")]
        [DefaultValue("Color.AliceBlue")]
        public Color GradientStartColor
        {
            get { return gradientStartColor; }
            set { gradientStartColor = value; Invalidate(); }
        }

        Color gradientEndColor = Color.Lavender;
        [Browsable(true), Description("Gets or sets the background gradient end color."), Category("Advanced")]
        [DefaultValue("Color.Lavender")]
        public Color GradientEndColor
        {
            get { return gradientEndColor; }
            set { gradientEndColor = value; Invalidate(); }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            int tmpShadowOffSet = Math.Min(Math.Min(shadowOffSet, this.Width - 2), this.Height - 2);
            int tmpSoundCornerRadius = Math.Min(Math.Min(roundCornerRadius, this.Width - 2), this.Height - 2);
            if (this.Width > 1 && this.Height > 1)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, this.Width - tmpShadowOffSet - 1, this.Height - tmpShadowOffSet - 1);
                Rectangle rectShadow = new Rectangle(tmpShadowOffSet, tmpShadowOffSet, this.Width - tmpShadowOffSet - 1, this.Height - tmpShadowOffSet - 1);

                GraphicsPath graphPathShadow = this.GetRoundPath(rectShadow, tmpSoundCornerRadius);
                GraphicsPath graphPath = this.GetRoundPath(rect, tmpSoundCornerRadius);

                if (tmpSoundCornerRadius > 0)
                {
                    using (PathGradientBrush gBrush = new PathGradientBrush(graphPathShadow))
                    {
                        gBrush.WrapMode = WrapMode.Clamp;
                        ColorBlend colorBlend = new ColorBlend(3);
                        colorBlend.Colors = new Color[]{Color.Transparent, 
													Color.FromArgb(180, Color.DimGray), 
													Color.FromArgb(180, Color.DimGray)};

                        colorBlend.Positions = new float[] { 0f, .1f, 1f };

                        gBrush.InterpolationColors = colorBlend;
                        e.Graphics.FillPath(gBrush, graphPathShadow);
                    }
                }

                // Draw backgroup
                LinearGradientBrush brush = new LinearGradientBrush(rect,
                    this.gradientStartColor,
                    this.gradientEndColor,
                    LinearGradientMode.BackwardDiagonal);
                e.Graphics.FillPath(brush, graphPath);
                e.Graphics.DrawPath(new Pen(Color.FromArgb(180, this.borderColor), borderWidth), graphPath);

                // Draw Image
                if (image != null)
                    e.Graphics.DrawImageUnscaled(image, imageLocation);
            }
        }

        private GraphicsPath GetRoundPath(Rectangle r, int depth)
        {
            GraphicsPath graphPath = new GraphicsPath();

            graphPath.AddArc(r.X, r.Y, depth, depth, 180, 90);
            graphPath.AddArc(r.X + r.Width - depth, r.Y, depth, depth, 270, 90);
            graphPath.AddArc(r.X + r.Width - depth, r.Y + r.Height - depth, depth, depth, 0, 90);
            graphPath.AddArc(r.X, r.Y + r.Height - depth, depth, depth, 90, 90);
            graphPath.AddLine(r.X, r.Y + r.Height - depth, r.X, r.Y + depth / 2);

            return graphPath;
        }
    }
}
