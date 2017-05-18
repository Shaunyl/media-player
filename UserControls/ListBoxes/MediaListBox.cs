using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Shauni.Database;

namespace Shauni.UserControls
{
    public class MediaListBox : ListBox
    {
        [Description("Occurs after a file is dragged and dropped on the list box and reports which file is going to be loaded.")]
        public event EventHandler<FileDraggedEventArgs> FileDragged;

        [Description("Occurs after an item is clicked or selected in the list box and reports which file is going to be loaded.")]
        public event EventHandler<ItemClickedEventArgs> ItemClicked;

        [Description("Occurs after an item is clicked twice or selected in the list box and reports which file is going to be loaded.")]
        public event EventHandler<ItemDoubleClickedEventArgs> ItemDoubleClicked;

        protected Point _iconPadding = new Point(4, 0);
        [Category("Item")]
        [Browsable(true), Description("Choose to either have no border, or a border with square or rounded edges")]
        public Point IconPadding
        {
            get { return this._iconPadding; }
            set { this._iconPadding = value; }
        }

        protected BorderTypes _borderType = BorderTypes.Square;
        [Category("Item")]
        [Browsable(true), Description("Choose to either have no border, or a border with square or rounded edges")]
        public BorderTypes BorderType
        {
            get { return this._borderType; }
            set { this._borderType = value; }
        }

        protected int _borderRoundedAngle = 6;
        [Category("Item")]
        [Browsable(true), Description("Gets or sets the angle of rounded edges")]
        [DefaultValue(6)]
        [Range(1, 15, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int BorderRoundedAngle
        {
            get { return this._borderRoundedAngle; }
            set { this._borderRoundedAngle = value; }
        }

        protected Color _borderColor = Color.DimGray;
        [Category("Item")]
        [Browsable(true), Description("Gets or sets the color of the border.")]
        public Color BorderColor
        {
            get { return this._borderColor; }
            set { this._borderColor = value; }
        }

        protected Color _borderCheckedColor = Color.Black;
        [Category("Item")]
        [Browsable(true), Description("Gets or sets the border color of the checked item.")]
        public Color BorderCheckedColor
        {
            get { return this._borderCheckedColor; }
            set { this._borderCheckedColor = value; }
        }

        protected Color _backColorGradientStart = Color.AliceBlue;
        [Category("Item")]
        [Browsable(true), Description("Gets or sets the start gradient color of the item.")]
        public Color BackColorGradientStart
        {
            get { return this._backColorGradientStart; }
            set { this._backColorGradientStart = value; }
        }

        protected Color _backColorGradientEnd = Color.GhostWhite;
        [Category("Item")]
        [Browsable(true), Description("Gets or sets the end gradient color of the item.")]
        public Color BackColorGradientEnd
        {
            get { return this._backColorGradientEnd; }
            set { this._backColorGradientEnd = value; }
        }

        protected Color _backColorCheckedGradientStart = Color.GhostWhite;
        [Category("Item")]
        [Browsable(true), Description("Gets or sets the start gradient color of the item checked.")]
        public Color BackColorCheckedGradientStart
        {
            get { return this._backColorCheckedGradientStart; }
            set { this._backColorCheckedGradientStart = value; }
        }

        protected Color _backColorCheckedGradientEnd = Color.AliceBlue;
        [Category("Item")]
        [Browsable(true), Description("Gets or sets the end gradient color of the item checked.")]
        public Color BackColorCheckedGradientEnd
        {
            get { return this._backColorCheckedGradientEnd; }
            set { this._backColorCheckedGradientEnd = value; }
        }

        public static IMedia CurrentSelectedMedia { get; private set; }

        public MediaListBox()
            : base()
        {
            this.DisplayMember = "Name";
            this.ValueMember = "Name";
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }

        private int GetStringWidth(Graphics g, String text)
        {
            return (int)g.MeasureString(text, this.Font).Width;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ((e.Index < 0) || (e.Index >= this.Items.Count))
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //Gradient for background
            LinearGradientBrush lgb = new LinearGradientBrush(e.Bounds,
                _backColorGradientStart, _backColorGradientEnd, 1, true);

            var item = this.Items[e.Index];
            int Xpadding = e.Bounds.X + this.IconPadding.X;
            int Ypadding = e.Bounds.Y + this.IconPadding.Y;

            Color brdCol = this._borderColor;

            if (e.State.HasFlag(DrawItemState.Selected))
            {
                Xpadding += 1;
                Ypadding += 1;
                lgb = new LinearGradientBrush(e.Bounds,
                _backColorCheckedGradientStart, _backColorCheckedGradientEnd, 1, true);
                brdCol = _borderCheckedColor;
            }

            //Draw photo image
            Bitmap image = Properties.Resources.Attention;

            string text = "";

            if (item is Song)
            {
                using (GraphicsPath gp = DrawBorder(e, brdCol))
                    e.Graphics.FillPath(lgb, gp);

                image = Properties.Resources.AudioFormat;
                Rectangle photoRct = new Rectangle(Xpadding, Ypadding, image.Width, image.Height);
                e.Graphics.DrawImage(image, photoRct);

                text = ((IMedia)item).Name.ToProperCase();

                Brush[] brush = new Brush[2] { Brushes.Gainsboro, new SolidBrush(this.ForeColor) };

                for (int i = 0; i < 2; i++)
                    e.Graphics.DrawString(text, this.Font, brush[i],
                        Xpadding + image.Width + 22 - i,
                        2 - i + Ypadding - this.IconPadding.Y - 1 + (e.Bounds.Height - this.Font.Height) / 2);

                /*if (((IMedia)item).IsPlaying)
                {
                    int width = this.GetStringWidth(e.Graphics, text);

                    Image image2 = Properties.Resources.isPlaying;
                    Rectangle isPlayingRct = new Rectangle(width + photoRct.Width + 2 * Xpadding + image.Width + 22, Ypadding + 2, 12, 12);
                    e.Graphics.DrawImage(image2, isPlayingRct);
                }*/
            }
            else if (item is IconPack)
            {
                using (GraphicsPath gp = DrawBorder(e, brdCol))
                    e.Graphics.FillPath(lgb, gp);

                IconPack iconPack = ((IconPack)item);

                //text = "'" + iconPack.Name + "'.     Version: " + iconPack.Version + ".     Author: " + iconPack.Author;
                Brush[] brush = new Brush[2] { Brushes.Gainsboro, new SolidBrush(this.ForeColor) };

                Image im = iconPack.Image;
                Rectangle photoRct = new Rectangle(Xpadding, Ypadding, im.Width, im.Height);
                e.Graphics.DrawImage(im, photoRct);

                //int Xoffset = Xpadding + im.Width + 22;

                //for (int i = 0; i < 2; i++)
                //e.Graphics.DrawString(text, this.Font, brush[i],
                //    Xpadding + im.Width + 22 - i,
                //    2 - i + Ypadding - this.IconPadding.Y - 1 + (e.Bounds.Height - this.Font.Height) / 2);
            }
            else
            {
                e.Graphics.FillRectangle(lgb, e.Bounds);
                text = this.Items[e.Index].ToString();

                e.Graphics.DrawString(text, this.Font, Brushes.DimGray,
                        e.Bounds.X, e.Bounds.Y + (e.Bounds.Height - this.Font.Height) / 2);
            }

            lgb.Dispose();
        }

        protected GraphicsPath DrawBorder(DrawItemEventArgs e, Color borderColor)
        {
            Rectangle rct = e.Bounds;
            GraphicsPath gp = new GraphicsPath();

            rct.Width -= 1;

            int ArcWidth = this.BorderRoundedAngle;

            if (_borderType == BorderTypes.Square)
            {
                gp.AddRectangle(rct);
                e.Graphics.DrawRectangle(new Pen(borderColor, 1), rct);
            }
            else if (_borderType == BorderTypes.Rounded)
            {
                Rectangle arcRct = new Rectangle(rct.X, rct.Y, ArcWidth, ArcWidth);
                Point pt1 = new Point(rct.X + ArcWidth, rct.Y);
                Point pt2 = new Point(rct.X + rct.Width - ArcWidth, rct.Y);

                gp.AddArc(arcRct, 180, 90);
                gp.AddLine(pt1, pt2);

                arcRct.Location = pt2;
                gp.AddArc(arcRct, 270, 90);

                pt1 = new Point(rct.X + rct.Width, rct.Y + ArcWidth);
                pt2 = new Point(rct.X + rct.Width, rct.Y + rct.Height - ArcWidth);
                gp.AddLine(pt1, pt2);

                arcRct.Y = pt2.Y;
                gp.AddArc(arcRct, 0, 90);

                pt1 = new Point(rct.X + rct.Width - ArcWidth, rct.Y + rct.Height);
                pt2 = new Point(rct.X + ArcWidth, rct.Y + rct.Height);
                gp.AddLine(pt1, pt2);

                arcRct.X = rct.X;
                gp.AddArc(arcRct, 90, 90);

                gp.CloseFigure();

                e.Graphics.DrawPath(new Pen(borderColor, 1), gp);
            }

            return gp;
        }

        protected void OnItemClicked(ItemClickedEventArgs e)
        {
            if (ItemClicked != null)
                ItemClicked(this, e);
        }

        protected void OnItemDoubleClicked(ItemDoubleClickedEventArgs e)
        {
            if (ItemDoubleClicked != null)
                ItemDoubleClicked(this, e);
        }

        protected void OnFileDragged(FileDraggedEventArgs e)
        {
            if (FileDragged != null)
                FileDragged(this, e);

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            ItemClickedEventArgs fbe = new ItemClickedEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta);
            this.OnItemClicked(fbe);

            if (fbe.Media != null)
                CurrentSelectedMedia = fbe.Media;
            //base.OnMouseDown(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            ItemDoubleClickedEventArgs idc = new ItemDoubleClickedEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta);
            this.OnItemDoubleClicked(idc);

            /*if (idc.Media != null)
                idc.Media.IsPlaying */
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            FileDraggedEventArgs fde = new FileDraggedEventArgs(drgevent.Data,
                drgevent.KeyState, drgevent.X, drgevent.Y, drgevent.AllowedEffect, drgevent.Effect);

            this.OnFileDragged(fde);
        }

        public enum BorderTypes
        {
            None,
            Square,
            Rounded
        }
    }

    /*public class FileDraggedEventArgs : DragEventArgs
    {
        /// <summary>
        /// Gets the path to the file beign loaded by the browse dialog.
        /// </summary>
        public string[] Filenames { get; private set; }
        /// <summary>
        /// Allows the callee to set the player's CurrentMedia property to the media object that the selected path is referring to.
        /// </summary>
        public IMedia Media { get; set; }

        public FileDraggedEventArgs(IDataObject filename, int keyState, int X, int Y, DragDropEffects Allowed, DragDropEffects Effect)
            : base(filename, keyState, X, Y, Allowed, Effect)
        {
            if (filename.GetDataPresent(DataFormats.FileDrop))
                this.Filenames = (string[])filename.GetData(DataFormats.FileDrop);
        }
    }

    public class ItemClickedEventArgs : MouseEventArgs
    {
        /// <summary>
        /// Allows the caller to set the player's CurrentMedia property to the media object that the selected path is referring to.
        /// </summary>
        public IMedia Media { get; set; }

        public ItemClickedEventArgs(MouseButtons mb, int clicks, int x, int y, int delta)
            : base(mb, clicks, x, y, delta)
        { }
    }

    public class ItemDoubleClickedEventArgs : ItemClickedEventArgs
    {
        public ItemDoubleClickedEventArgs(MouseButtons mb, int clicks, int x, int y, int delta)
            : base(mb, clicks, x, y, delta)
        { }
    }*/
}