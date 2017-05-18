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
    public class ShauniListBox : ListBox
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

        protected Brush[] stringBrushes;
        protected Color brdCol;
        protected int Xpadding, Ypadding;
        protected LinearGradientBrush lgb;
        protected bool isNormal = false;
        protected Object item;
        protected List<int> alives = new List<int>();

        private bool dragDropAllIn = false;
        private Rectangle dragOriginBox = Rectangle.Empty;

        public ShauniListBox()
            : base()
        {
            this.DisplayMember = "Name";
            this.ValueMember = "Name";
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.BorderStyle = BorderStyle.FixedSingle;
            stringBrushes = new Brush[2] { Brushes.Gainsboro, new SolidBrush(this.ForeColor) };

            this.AllowDrop = true;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }

        protected int GetStringWidth(Graphics g, String text)
        {
            return (int)g.MeasureString(text, this.Font).Width;
        }

        private void DrawNormalItem(DrawItemEventArgs e)
        {
            lgb = new LinearGradientBrush(e.Bounds, _backColorGradientStart, _backColorGradientEnd, 1, true);

            e.Graphics.FillRectangle(lgb, e.Bounds);
            string text = this.Items[e.Index].ToString();

            e.Graphics.DrawString(text, this.Font, Brushes.DimGray,
                    e.Bounds.X, e.Bounds.Y + (e.Bounds.Height - this.Font.Height) / 2);

            isNormal = true;

            lgb.Dispose();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ((e.Index < 0) || (e.Index >= this.Items.Count))
            {
                item = null;
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            item = this.Items[e.Index];

            if (item is String)
                this.DrawNormalItem(e);

            else isNormal = false;
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
            int index = this.IndexFromPoint(e.X, e.Y);

            if (index != -1)
            {
                IMedia media = (this.SelectedItem = this.Items[index]) as IMedia;
                IconPack pack = null;

                if (media == null)
                {
                    pack = (this.SelectedItem = this.Items[index]) as IconPack;
                    if(pack == null)
                        return;
                }
                this.Select();

                e.Media = media;
                e.IsOutSide = false;
            }
            else
                e.IsOutSide = true;

            e.CurrentIndex = index;

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

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.SelectedIndex != -1 && alives.Contains(this.SelectedIndex))
                alives.Remove(this.SelectedIndex);

            base.OnKeyDown(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            ItemClickedEventArgs fbe = new ItemClickedEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta);
            this.OnItemClicked(fbe);

            if (fbe.Media != null)
                CurrentSelectedMedia = fbe.Media;

            int clickedItemIndex = IndexFromPoint(e.Location);
            // Remember start position of possible drag operation.
            Size dragSize = SystemInformation.DragSize; // Size that the mouse must move before a drag operation starts.
            dragOriginBox = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);

            if (!fbe.IsItemAlive)
            {
                if (!alives.Contains(SelectedIndex))
                    alives.Add(SelectedIndex);
            }

            this.Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (dragOriginBox != Rectangle.Empty && !dragOriginBox.Contains(e.X, e.Y))
            { // Initiate drag-and-drop
                DoDragDrop(new DataObject(this), DragDropEffects.All);
                dragOriginBox = Rectangle.Empty;
                dragDropAllIn = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            dragOriginBox = Rectangle.Empty; // Reset drag drop.
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            ItemDoubleClickedEventArgs idc = new ItemDoubleClickedEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta);
            this.OnItemDoubleClicked(idc);
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            FileDraggedEventArgs fde = new FileDraggedEventArgs(drgevent.Data,
                drgevent.KeyState, drgevent.X, drgevent.Y, drgevent.AllowedEffect, drgevent.Effect);

            this.OnFileDragged(fde);

            if (SelectedItem == null) return;

            if (dragDropAllIn)
            {
                this.DragDropIn(drgevent);
                dragDropAllIn = false;
            }
        }

        private void DragDropIn(DragEventArgs drgevent)
        {
            object item = SelectedItem;

            // If the list box is sorted, we don't know where the items will be inserted
            // and we will have troubles selecting the inserted items. So let's disable sorting here.
            bool sortedSave = Sorted;
            Sorted = false;

            // Insert at the currently hovered row.
            int row = DropIndex(drgevent.Y);
            int insertPoint = row;
            if (row >= Items.Count)
                Items.Add(item); // Append item to the end.
            else
                Items.Insert(row++, item); // Insert items before row.

            if (drgevent.Effect == DragDropEffects.Move)
            {
                int adjustedInsertPoint = insertPoint;
                for (int i = SelectedIndices.Count - 1; i >= 0; i--)
                {
                    int index = SelectedIndices[i];
                    this.Items.RemoveAt(index);

                    if (index < adjustedInsertPoint)
                        adjustedInsertPoint--;  // Adjust index pointing to stuff behind the delete position.
                }

                insertPoint = adjustedInsertPoint;
            }

            this.ClearSelected();
            SelectedIndex = insertPoint;
            Sorted = sortedSave;
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);

            DragDropEffects effect = DragDropEffects.None;
            if (!this.Sorted)
                effect = DragDropEffects.Move;

            drgevent.Effect = effect;

            if (drgevent.Effect == DragDropEffects.None)
                return;
        }

        private int DropIndex(int yScreen)
        {
            // The DragEventArgs gives us screen coordinates. Convert the screen coordinates to client coordinates.
            int y = PointToClient(new Point(0, yScreen)).Y;

            // Make sure we are inside of the client rectangle.
            // If we are on the border of the ListBox, then IndexFromPoint does not return a match.
            if (y < 0)
                y = 0;
            else if (y > ClientRectangle.Bottom - 1)
                y = ClientRectangle.Bottom - 1;


            int index = IndexFromPoint(0, y); // The x-coordinate doesn't make any difference.
            if (index == ListBox.NoMatches)
            { // Not hovering over an item
                return Items.Count;  // Append to the end of the list.
            }

            // If hovering below the middle of the item, then insert after the item.
            Rectangle rect = GetItemRectangle(index);
            if (y > rect.Top + rect.Height / 2)
            {
                index++;
            }

            int lastFullyVisibleItemIndex = TopIndex + ClientRectangle.Height / ItemHeight;
            if (index > lastFullyVisibleItemIndex)
            { // Do not insert after the last fully visible item
                return lastFullyVisibleItemIndex;
            }
            return index;
        }

        public enum BorderTypes
        {
            None,
            Square,
            Rounded
        }
    }

    public class FileDraggedEventArgs : DragEventArgs
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
        public int CurrentIndex { get; set; }
        public Boolean IsOutSide { get; set; }
        public Boolean IsItemAlive { get; set; }
        /// <summary>
        /// Allows the callee to set the player's CurrentMedia property to the media object that the selected path is referring to.
        /// </summary>
        public IMedia Media { get; set; }

        public ItemClickedEventArgs(MouseButtons mb, int clicks, int x, int y, int delta)
            : base(mb, clicks, x, y, delta)
        {
            IsItemAlive = true;
            IsOutSide = false;
            CurrentIndex = -1;
        }
    }

    public class ItemDoubleClickedEventArgs : ItemClickedEventArgs
    {
        public ItemDoubleClickedEventArgs(MouseButtons mb, int clicks, int x, int y, int delta)
            : base(mb, clicks, x, y, delta)
        { }
    }
}