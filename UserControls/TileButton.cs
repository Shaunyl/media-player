using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Shauni.UserControls
{
    /// <summary>
    /// Represents a button with customized graphics. In order to draw its different states, a tileset is
    /// required, stored in the common property Image. The tileset is formed by an array of images
    /// positioned side by side and saved as a single image.
    /// </summary>
    public class TileButton : PictureBox
    {
        private int tilesNumber = 5, idleTileIndex, hoverTileIndex, pressedTileIndex;
        private int currentTileIndex;

        [Browsable(false)]
        public int CurrentTileIndex
        {
            get { return currentTileIndex; }
            set { currentTileIndex = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the tile image needed to draw this button.
        /// </summary>
        public new Image Image
        {
            get { return base.Image; }
            set { base.Image = value; this.ResetSize(); this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the tile-index of the image representing the button "idle" state.
        /// </summary>
        [Browsable(true), Description("Determinates the tile-index of the image representing the button \"idle\" state."), Category("Tiles")]
        [DefaultValue(2)]
        public int IdleTileIndex
        {
            get { return this.ClampValue(idleTileIndex); }
            set { idleTileIndex = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the tile-index of the image representing the button "hover" state (mouse cursor is on the button).
        /// </summary>
        [Browsable(true), Description("Determinates the tile-index of the image representing the button \"hover\" state."), Category("Tiles")]
        [DefaultValue(0)]
        public int HoverTileIndex
        {
            get { return this.ClampValue(hoverTileIndex); }
            set { hoverTileIndex = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the tile-index of the image representing the button "pressed" state (mouse cursor is on the button and left mouse button is pressed).
        /// </summary>
        [Browsable(true), Description("Determinates the tile-index of the image representing the button \"pressed\" state."), Category("Tiles")]
        [DefaultValue(1)]
        public int PressedTileIndex
        {
            get { return this.ClampValue(pressedTileIndex); }
            set { pressedTileIndex = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the number of tiles which the Image property must be divided in.
        /// </summary>
        [Browsable(true), Description("Determinates the number of tiles which the Image property must be divided in."), Category("Tiles")]
        [DefaultValue(5)]
        public int TilesNumber
        {
            get { return tilesNumber; }
            set { tilesNumber = value > 0 ? value : 1; this.ResetSize(); this.Invalidate(); }
        }

        /// <summary>
        /// Returns the width of a single tile, i.e. the width of the tileset divided by the number of tiles.
        /// </summary>
        [Browsable(false)]
        public int TileWidth
        {
            get { return this.Image != null ? (int)((double)this.Image.Width / tilesNumber) : 1; }
        }

        private int ClampValue(int value)
        {
            return (value >= 0 && value < tilesNumber) ? value : 0;
        }

        private void ResetSize()
        {
            if (this.Image == null)
                return;
            this.Size = new Size((int)((double)this.Image.Width / tilesNumber), this.Image.Height);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseHover(e);
            currentTileIndex = this.HoverTileIndex; this.Invalidate();
            //this.Refresh();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            currentTileIndex = this.Enabled == true ? 0 : 2;
            this.IdleTileIndex = this.Enabled == true ? 0 : 2; this.Invalidate();
            //this.Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            currentTileIndex = this.IdleTileIndex; this.Invalidate();
            //this.Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            currentTileIndex = this.PressedTileIndex; this.Invalidate();
            //this.Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            currentTileIndex = 0;/*this.HoverTileIndex;*/ this.Invalidate();
            //this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Image == null)
            {
                base.OnPaint(e);
                return;
            }
            this.DrawOnBackbuffer(e.Graphics);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 0x14)
            {
                base.WndProc(ref m);
                return;
            }

            Graphics controlGraphics = Graphics.FromHdc(m.WParam);
            this.DrawOnBackbuffer(controlGraphics);
            controlGraphics.Flush();
            controlGraphics.Dispose();
        }

        private void DrawOnBackbuffer(Graphics controlGraphics)
        {
            Bitmap temp = new Bitmap(this.TileWidth, this.Height);

            using (Graphics backBuffer = Graphics.FromImage(temp))
                this.DrawTile(backBuffer, new Rectangle(new Point(), temp.Size));

            controlGraphics.DrawImage(temp, 0, 0);

            temp.Dispose();
        }

        private void DrawTile(Graphics graphics, Rectangle destination)
        {
            if (this.Image != null)
            {
                Rectangle source = new Rectangle();
                source.X = currentTileIndex * this.TileWidth;
                source.Y = 0;
                source.Width = this.TileWidth;
                source.Height = this.Image.Height;

                // Draw the current active tile
                graphics.DrawImage(this.Image, destination, source, GraphicsUnit.Pixel);
            }
        }
    }
}
