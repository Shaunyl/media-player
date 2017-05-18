using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Shauni.Graphic
{
    using ShauniColors = ColorTable.ShauniColorTable;

    public class ToolStripOwnRenderer : ToolStripProfessionalRenderer
    {
        private ShauniColors colorTable = new ShauniColors();
        private ToolTip _toolTip;

        public Boolean Art
        {
            get;
            set;
        }

        public string ArtString
        {
            get;
            set;
        }

        public ToolStripOwnRenderer()
        {

        }

        public new ProfessionalColorTable ColorTable
        {
            get { return this.colorTable; }
        }

        protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            Rectangle bounds = e.AffectedBounds;

            drawSolidStatusGrip(e.Graphics, e.AffectedBounds);
        }

        private void drawSolidStatusGrip(Graphics g, Rectangle bounds)
        {
            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
            {
                using (Pen inner = new Pen(Color.DarkGray), outer = new Pen(Color.Black))
                {
                    //outer line
                    g.DrawLine(outer, new Point(bounds.Width - 14, bounds.Height - 6),
                        new Point(bounds.Width - 4, bounds.Height - 16));
                    g.DrawLine(inner, new Point(bounds.Width - 13, bounds.Height - 6),
                        new Point(bounds.Width - 4, bounds.Height - 15));
                    // line
                    g.DrawLine(outer, new Point(bounds.Width - 12, bounds.Height - 6),
                        new Point(bounds.Width - 4, bounds.Height - 14));
                    g.DrawLine(inner, new Point(bounds.Width - 11, bounds.Height - 6),
                        new Point(bounds.Width - 4, bounds.Height - 13));
                    // line
                    g.DrawLine(outer, new Point(bounds.Width - 10, bounds.Height - 6),
                        new Point(bounds.Width - 4, bounds.Height - 12));
                    g.DrawLine(inner, new Point(bounds.Width - 9, bounds.Height - 6),
                        new Point(bounds.Width - 4, bounds.Height - 11));
                    // line
                    g.DrawLine(outer, new Point(bounds.Width - 8, bounds.Height - 6),
                        new Point(bounds.Width - 4, bounds.Height - 10));
                    g.DrawLine(inner, new Point(bounds.Width - 7, bounds.Height - 6),
                        new Point(bounds.Width - 4, bounds.Height - 9));
                    // inner line
                    g.DrawLine(outer, new Point(bounds.Width - 6, bounds.Height - 6),
                        new Point(bounds.Width - 4, bounds.Height - 8));
                    g.DrawLine(inner, new Point(bounds.Width - 5, bounds.Height - 6),
                        new Point(bounds.Width - 4, bounds.Height - 7));
                }
            }
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            Rectangle imageRect = e.ImageRectangle;
            Image image = e.Image;

            if (e.Item is ToolStripMenuItem)
            {
                ToolStripMenuItem item = e.Item as ToolStripMenuItem;
                if (item.CheckState != CheckState.Unchecked)
                {
                    ToolStripDropDownMenu dropDownMenu = item.GetCurrentParent() as ToolStripDropDownMenu;
                    if (dropDownMenu != null && !dropDownMenu.ShowCheckMargin && dropDownMenu.ShowImageMargin)
                    {
                        RenderCheckBackground(e);
                    }
                }
            }

            if (imageRect != Rectangle.Empty && image != null)
            {
                if (!e.Item.Enabled)
                {
                    base.OnRenderItemImage(e);
                    return;
                }

                // Since office images dont scoot one px we have to override all painting but enabled = false;
                if (e.Item.ImageScaling == ToolStripItemImageScaling.None)
                {
                    e.Graphics.DrawImage(image, imageRect, new Rectangle(Point.Empty, imageRect.Size), GraphicsUnit.Pixel);
                }
                else
                {
                    e.Graphics.DrawImage(image, imageRect);
                }
            }
        }

        private void RenderCheckBackground(ToolStripItemImageRenderEventArgs e)
        {
            Rectangle bounds = new Rectangle(e.ImageRectangle.Left - 2, 1, e.ImageRectangle.Width + 4, e.Item.Height - 2);
            Graphics g = e.Graphics;

            if (colorTable.UseSystemColors)
            {
                Color fill = (e.Item.Selected) ? colorTable.CheckSelectedBackground : colorTable.CheckBackground;
                fill = (e.Item.Pressed) ? colorTable.CheckPressedBackground : fill;
                using (Brush b = new SolidBrush(fill))
                {
                    g.FillRectangle(b, bounds);
                }

                using (Pen p = new Pen(colorTable.ButtonSelectedBorder))
                {
                    g.DrawRectangle(p, bounds.X + 1, bounds.Y, bounds.Width, bounds.Height - 1);
                }
            }
            else
            {
                if (e.Item.Pressed)
                {
                    RenderPressedButtonFill(g, bounds);
                }
                else
                {
                    RenderSelectedButtonFill(g, bounds);
                }
                g.DrawRectangle(new Pen(Brushes.Gainsboro, 1), bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
            }
        }

        private void RenderPressedButtonFill(Graphics g, Rectangle bounds)
        {

            if ((bounds.Width == 0) || (bounds.Height == 0))
            {
                return;  // can't new up a linear gradient brush with no dimension.
            }
            if (!colorTable.UseSystemColors)
            {
                using (Brush b = new LinearGradientBrush(bounds, colorTable.ButtonPressedGradientBegin, colorTable.ButtonPressedGradientEnd, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(b, bounds);
                }
            }
            else
            {

                Color fillColor = colorTable.ButtonPressedHighlight;
                using (Brush b = new SolidBrush(fillColor))
                {
                    g.FillRectangle(b, bounds);
                }
            }
        } 

        protected override void OnRenderSplitButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
        {
            ToolStripSplitButton item = (ToolStripSplitButton)e.Item;
            Graphics g = e.Graphics;

            Rectangle itemRect = new Rectangle(new Point(1, 1), new Size(item.Bounds.Width - 2, item.Bounds.Height - 2));
            dynamic itemBorderRect = new Rectangle(0, 0, itemRect.Width + 1, itemRect.Height + 1);

            int btnAreaRight = item.ButtonBounds.Right;

            if (item.Pressed)
            {
                itemRect.Height -= 1;
                itemBorderRect.Height -= 1;

                LinearGradientBrush br = new LinearGradientBrush(itemRect, colorTable.ButtonPressedGradientBegin, colorTable.ButtonPressedGradientEnd, LinearGradientMode.Vertical);
                g.FillRectangle(br, itemRect);
                br.Dispose();
                DrawRoundBorder(g, itemBorderRect, colorTable.ButtonPressedBorder);

                //vertical line
                g.DrawLine(new Pen(colorTable.ToolStripVerticalLine), btnAreaRight, itemBorderRect.Y + 3, btnAreaRight, itemBorderRect.Bottom - 3);
            }
            else
            {
                if (item.Selected)
                {
                    LinearGradientBrush br = new LinearGradientBrush(itemRect, Color.Empty, Color.Empty, LinearGradientMode.Vertical);

                    ColorBlend cd = new ColorBlend(4);
                    cd.Colors = new Color[] {
			                                    colorTable.ButtonSelectedGradientBegin,
			                                    colorTable.ButtonSelectedGradientMiddle,
                                                colorTable.ButtonSelectedGradientEnd
		                                    };
                    cd.Positions = new float[] {
			                                    0.0f,
			                                    0.5f,
                                                1.0f
		                                    };

                    br.InterpolationColors = cd;
                    g.FillRectangle(br, itemRect);

                    br.Dispose();
                    DrawRoundBorder(g, itemBorderRect, colorTable.ButtonSelectedBorder);

                    //vertical line
                    g.DrawLine(new Pen(colorTable.ToolStripVerticalLine), btnAreaRight, itemBorderRect.Y + 3, btnAreaRight, itemBorderRect.Bottom - 3);
                }
                else if (item.ButtonPressed)
                {
                    Rectangle btnRect = Rectangle.FromLTRB(itemRect.Left, itemRect.Top, btnAreaRight, itemRect.Bottom);
                    LinearGradientBrush br = new LinearGradientBrush(btnRect, colorTable.ButtonSelectedGradientBegin, colorTable.ButtonSelectedGradientEnd, LinearGradientMode.Vertical);

                    br.SetSigmaBellShape(0.5f, 0.7f);
                    g.FillRectangle(br, btnRect);

                    br.Dispose();

                    DrawRoundBorder(g, itemBorderRect, colorTable.ButtonPressedBorder);

                    item.ImageAlign = ContentAlignment.MiddleCenter;
                }
            }

            //La freccia del dropdown devo fargliela disegnare chiamando mybase.drawarrow
            ToolStripArrowRenderEventArgs tsarEventsArgs = new ToolStripArrowRenderEventArgs(e.Graphics, item, item.DropDownButtonBounds, Color.Black, ArrowDirection.Down);
            base.DrawArrow(tsarEventsArgs);
        }

        private void DrawText(Graphics g, Font font, Rectangle rect, int height)
        {
            g.DrawString(ArtString, new Font("Miramonte", (float)9.75,
                        FontStyle.Bold | FontStyle.Bold, GraphicsUnit.Point),
                        new LinearGradientBrush(rect, Color.CornflowerBlue/*Color.FromArgb(114, 202, 250)*/
                            , Color.CornflowerBlue/*Color.FromArgb(40, 113, 239)*/, LinearGradientMode.Vertical)
                        , new Point(rect.Width - 156, rect.Location.Y + 5), StringFormat.GenericTypographic);
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle rect = new Rectangle(Point.Empty, e.AffectedBounds.Size);
            LinearGradientBrush b = new LinearGradientBrush(rect, Color.Empty, Color.Empty, LinearGradientMode.Vertical);

            ColorBlend blend = new ColorBlend(4);
            blend.Colors = new Color[] {
			                                    colorTable.ToolStripGradientBegin,
			                                    colorTable.ToolStripGradientMiddle,
                                                colorTable.ToolStripGradientEnd
		                                    };
            blend.Positions = new float[] { 0.0f, 0.5f, 1.0f };

            b.InterpolationColors = blend;
            g.FillRectangle(b, rect);
            b.Dispose();
            
            if(this.Art)
                this.DrawText(g, e.ToolStrip.Font, rect, e.ToolStrip.Height);

            if (e.ToolStrip.IsDropDown)
            {
                int ellipseRectNord = 4;
                int ellipseRectSE = 6;
                int ellipseRectSO = 10;
                int mnuRectX = e.AffectedBounds.X;
                int mnuRectY = e.AffectedBounds.Y;
                int mnuRectRight = e.AffectedBounds.Right;
                int mnuRectBottom = e.AffectedBounds.Bottom;

                g.SmoothingMode = SmoothingMode.AntiAlias;

                //Nuova forma del menustrip
                GraphicsPath gp = new GraphicsPath();

                gp.StartFigure();

                //NB l'ordine è fondamentale perchè la figura sia chiusa correttamente
                //gli angoli bassi sono smussati poco
                //Sud-Est
                gp.AddArc(mnuRectRight - ellipseRectSO, mnuRectBottom - ellipseRectSO, ellipseRectSO, ellipseRectSO, 0, 90);
                //Sud-Ovest
                gp.AddArc(mnuRectX, mnuRectBottom - ellipseRectSE, ellipseRectSE, ellipseRectSE, 90, 90);
                //Nord-Ovest
                gp.AddArc(mnuRectX, mnuRectY, ellipseRectNord, ellipseRectNord, 180, 90);
                //Nord_Est
                gp.AddArc(mnuRectRight - ellipseRectNord, mnuRectY, ellipseRectNord, ellipseRectNord, 270, 90);

                gp.CloseFigure();

                //Riduco l'area del menù a discesa
                e.ToolStrip.Region = new Region(gp);
                g.SmoothingMode = SmoothingMode.Default;

                gp.Dispose();
            }
            else
                base.OnRenderToolStripBackground(e);
        }

        protected override void OnRenderSeparator(System.Windows.Forms.ToolStripSeparatorRenderEventArgs e)
        {
            if (!e.Vertical || (e.Item as ToolStripSeparator) == null)
                base.OnRenderSeparator(e);
            else
            {
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                bounds.Y += 3;
                bounds.Height = Math.Max(0, bounds.Height - 6);
                if (bounds.Height >= 4) bounds.Inflate(0, -2);
                int x = bounds.Width / 2;
                using (Pen pen = new Pen(colorTable.SeparatorLight))
                    e.Graphics.DrawLine(pen, x, bounds.Top, x, bounds.Bottom - 1);
            }
        }

        protected override void OnRenderButtonBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
        {
            Graphics g = e.Graphics;

            ToolStripButton button = e.Item as ToolStripButton;
            if (button.Pressed || button.Checked)
            {
                Rectangle rect = new Rectangle(new Point(1, 1), new Size(button.Bounds.Width - 2, button.Bounds.Height - 2));

                dynamic buttonBorderRect = new Rectangle(0, 0, rect.Width + 1, rect.Height + 1);

                Brush b = new LinearGradientBrush(rect, colorTable.ButtonPressedGradientBegin, colorTable.ButtonPressedGradientEnd
                    , LinearGradientMode.Vertical);

                g.FillRectangle(b, rect);
                DrawRoundBorder(g, buttonBorderRect, colorTable.ButtonPressedBorder);

                b.Dispose();
            }
            else if (button.Selected)
            {
                Rectangle rect = new Rectangle(1, 1, button.Width - 2, button.Height - 2);
                dynamic buttonBorderRect = new Rectangle(0, 0, rect.Width + 1, rect.Height + 1);

                LinearGradientBrush b = new LinearGradientBrush(rect, colorTable.ButtonSelectedGradientBegin, colorTable.ButtonSelectedGradientEnd
                    , LinearGradientMode.Vertical);

                g.FillRectangle(b, rect);
                DrawRoundBorder(g, buttonBorderRect, colorTable.ButtonSelectedBorder);

                b.Dispose();
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle itemRect = new Rectangle(e.AffectedBounds.X, e.AffectedBounds.Y, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1);
            DrawRoundBorder(g, itemRect, Color.Silver);
        }

        protected override void OnRenderMenuItemBackground(System.Windows.Forms.ToolStripItemRenderEventArgs e)
        {
            //base.OnRenderMenuItemBackground(e);

            if (e.Item.Pressed)
            {
                Graphics g = e.Graphics;

                Rectangle rect = new Rectangle(3, 2, e.Item.Width - 6, e.Item.Height - 4);
                Rectangle rect_top_bottom = new Rectangle(3, 1, e.Item.Width - 5, e.Item.Height - 2);
                //Rectangle rect_sides = new Rectangle(2, 1, e.Item.Width - 4, e.Item.Height - 2);

                SolidBrush b2 = new SolidBrush(Color.LightGray);
                //g.FillRectangle(b2, rect_sides);
                g.FillRectangle(b2, rect_top_bottom);

                LinearGradientBrush b = new LinearGradientBrush(rect, colorTable.MenuItemPressedGradientBegin
                    , colorTable.MenuItemPressedGradientEnd, LinearGradientMode.Vertical);
                g.FillRectangle(b, rect);
            }
            else if (e.Item.Selected)
            {
                Graphics g = e.Graphics;

                Rectangle rect = new Rectangle(3, 2, e.Item.Width - 6, e.Item.Height - 4);
                Rectangle rect_top_bottom = new Rectangle(3, 1, e.Item.Width - 5, e.Item.Height - 2);

                /*Rectangle rect_sides = new Rectangle(2, 1, e.Item.Width - 4, e.Item.Height - 2);
                g.FillRectangle(Brushes.WhiteSmoke, rect_sides);*/

                g.FillRectangle(Brushes.Gainsboro, rect_top_bottom);

                LinearGradientBrush b = new LinearGradientBrush(rect, colorTable.MenuItemSelectedGradientBegin
                    , colorTable.MenuItemSelectedGradientEnd, LinearGradientMode.Vertical);
                g.FillRectangle(b, rect);

                //g.DrawRectangle(new Pen(Brushes.Black, 3), e.Item.Bounds);

                /*Rectangle rectLeft = new Rectangle(3, 2, 22, e.Item.Height - 4);
                g.FillRectangle(Brushes.Lavender, rectLeft);*/
            }
            if (((ToolStripMenuItem)e.Item).Checked)
            {
                Graphics g = e.Graphics;

                Rectangle rect = new Rectangle(3, 2, e.Item.Width - 6, e.Item.Height - 4);
                Rectangle rect_top_bottom = new Rectangle(3, 1, e.Item.Width - 5, e.Item.Height - 2);

                g.FillRectangle(Brushes.Gainsboro, rect_top_bottom);

                LinearGradientBrush b = new LinearGradientBrush(rect, Color.FromArgb(229, 237, 250)
                    , Color.FromArgb(248, 248, 255), LinearGradientMode.Vertical);
                g.FillRectangle(b, rect);
            }
        }

        private void RenderSelectedButtonFill(Graphics g, Rectangle bounds)
        {
            if ((bounds.Width == 0) || (bounds.Height == 0))
            {
                return;  // can't new up a linear gradient brush with no dimension.
            }

            if (colorTable.UseSystemColors)
            {
                using (Brush b = new LinearGradientBrush(bounds, ColorTable.ButtonSelectedGradientBegin, ColorTable.ButtonSelectedGradientEnd, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(b, bounds);
                }
            }
            else
            {
                Color fillColor = ColorTable.ButtonSelectedHighlight;
                using (Brush b = new SolidBrush(fillColor))
                {
                    g.FillRectangle(b, bounds);
                }
            }
        } 

        protected override void OnRenderImageMargin(System.Windows.Forms.ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip.IsDropDown)
            {
                Graphics g = e.Graphics;

                Rectangle rect3 = new Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Height);
                LinearGradientBrush menuBack = new LinearGradientBrush(rect3, colorTable.ToolStripMenuGradientBegin, colorTable.ToolStripMenuGradientEnd
                    , LinearGradientMode.Horizontal);

                g.FillRectangle(menuBack, rect3);
                menuBack.Dispose();

                //// Draw ImageMargin background gradient
                LinearGradientBrush b = new LinearGradientBrush(e.AffectedBounds, colorTable.ImageMarginGradientBegin
                    , colorTable.ImageMarginGradientEnd, LinearGradientMode.Vertical);
                g.FillRectangle(b, e.AffectedBounds);
                b.Dispose();

                //// Shadow at the right of image margin
                SolidBrush CentralLine = new SolidBrush(Color.Gray);
                SolidBrush AroundLines = new SolidBrush(Color.LightGray);
                Rectangle rect = new Rectangle(e.AffectedBounds.Width, 0, 1, e.AffectedBounds.Height);
                Rectangle rect2 = new Rectangle(e.AffectedBounds.Width + 1, 0, 1, e.AffectedBounds.Height);
                g.FillRectangle(AroundLines, rect);
                g.FillRectangle(CentralLine, rect2);

                CentralLine.Dispose();
                AroundLines.Dispose();
            }
            else
                base.OnRenderImageMargin(e);
        }

        private void DrawRoundBorder(Graphics g, Rectangle itemRect, Color col)
        {
            int ellipseRect = 6; //side of ellyx
            int ellipseRadius = Convert.ToInt32(ellipseRect / 2); //radius of angle
            Pen penBorder = new Pen(col, 0.5f);
            int rectX = itemRect.X;
            int rectY = itemRect.Y;
            int rectRight = itemRect.Right;
            int rectBottom = itemRect.Bottom;

            g.SmoothingMode = SmoothingMode.HighQuality;

            g.DrawArc(penBorder, rectRight - ellipseRect, rectBottom - ellipseRect, ellipseRect, ellipseRect, 0, 90); //Sud-Est
            g.DrawArc(penBorder, rectX, rectBottom - ellipseRect, ellipseRect, ellipseRect, 90, 90); //Sud-Ovest
            g.DrawArc(penBorder, rectX, rectY, ellipseRect, ellipseRect, 180, 90); //Nord-Ovest
            g.DrawArc(penBorder, rectRight - ellipseRect, rectY, ellipseRect, ellipseRect, 270, 90); //Nord-Est   
            //penBorder.Color = Color.Black;             
            g.DrawLine(penBorder, rectX + ellipseRadius, rectY, rectRight - ellipseRadius, rectY); //top
            //penBorder.Color = col;
            g.DrawLine(penBorder, rectX + ellipseRadius, rectBottom, rectRight - ellipseRadius, rectBottom); //bottom
            g.DrawLine(penBorder, rectX, ellipseRadius, rectX, rectBottom - ellipseRadius); //left
            g.DrawLine(penBorder, rectRight, ellipseRadius, rectRight, rectBottom - ellipseRadius); //right

            penBorder.Dispose();
            g.SmoothingMode = SmoothingMode.Default;
        }

        private bool _toolTipEnable = false;
        private int _toolTipMaximumLength = 200;
        private int _toolTipDelayTime = 1000;
        private int _toolTipVisibleTime = 2000;
        private Color _toolTipGradientBegin;
        private Color _toolTipGradientEnd;
        private Color _toolTipForeColor;
        private Dictionary<ToolStripItem, string> _toolTipText = new Dictionary<ToolStripItem, string>();

        #region ToolTip
        /// <summary>
        /// The amount of time in milliseconds before the ToolTip appears.
        /// </summary>
        public int ToolTipDelayTime
        {
            get { return _toolTipDelayTime; }
            set
            {
                _toolTipDelayTime = value;
                if (_toolTip != null)
                    _toolTip.DelayTime = value;
            }
        }
        /// <summary>
        /// Get/Set the ToolStrip enabled property.
        /// </summary>
        public bool ToolTipEnable
        {
            get { return _toolTipEnable; }
            set { _toolTipEnable = value; }
        }
        /// <summary>
        /// Get/Set the forecolor of drop down menu items.
        /// </summary>
        public Color ToolTipForeColor
        {
            get { return _toolTipForeColor; }
            set
            {
                _toolTipForeColor = value;
                if (_toolTip != null)
                    _toolTip.ForeColor = value;
            }
        }
        /// <summary>
        /// Get/Set the starting color of the gradient.
        /// </summary>
        public Color ToolTipGradientBegin
        {
            get { return _toolTipGradientBegin; }
            set
            {
                _toolTipGradientBegin = value;
                if (_toolTip != null)
                    _toolTip.GradientBegin = value;
            }
        }
        /// <summary>
        /// Get/Set the ending color of the gradient.
        /// </summary>
        public Color ToolTipGradientEnd
        {
            get { return _toolTipGradientEnd; }
            set
            {
                _toolTipGradientEnd = value;
                if (_toolTip != null)
                    _toolTip.GradientEnd = value;
            }
        }
        /// <summary>
        /// The maximum length of the ToolTip in pixels.
        /// </summary>
        public int ToolTipMaximumLength
        {
            get { return _toolTipMaximumLength; }
            set
            {
                _toolTipMaximumLength = value;
                if (_toolTip != null)
                    _toolTip.MaximumLength = value;
            }
        }
        /// <summary>
        /// The length of time in milliseconds that the ToolTip remains visible.
        /// </summary>
        public int ToolTipVisibleTime
        {
            get { return _toolTipVisibleTime; }
            set
            {
                _toolTipVisibleTime = value;
                if (_toolTip != null)
                    _toolTip.VisibleTime = value;
            }
        }

        public void UseCustomToolTips(ToolStrip toolStrip)
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (!String.IsNullOrEmpty(item.ToolTipText))
                {
                    _toolTipText.Add(item, item.ToolTipText);
                    item.ToolTipText = "";
                    item.AutoToolTip = false;
                    item.MouseEnter += new EventHandler(Item_MouseEnter);
                    item.MouseLeave += new EventHandler(Item_MouseLeave);
                    item.MouseDown += new MouseEventHandler(item_MouseDown);
                }
            }
            if (_toolTipText.Count > 0)
            {
                _toolTip = new ToolTip(toolStrip.Handle);
                ToolTipEnable = true;
            }
        }

        private void item_MouseDown(object sender, MouseEventArgs e)
        {
            if (_toolTip != null)
                _toolTip.Stop();
        }

        private void Item_MouseEnter(object sender, EventArgs e)
        {
            if ((_toolTip != null) && (ToolTipEnable))
            {
                ToolStripItem item = (ToolStripItem)sender;
                Rectangle bounds = new Rectangle();
                if (_toolTipText.ContainsKey(item))
                {
                    string caption = _toolTipText[item];
                    if (item.Owner.Orientation == Orientation.Horizontal)
                    {
                        bounds.Y = item.Bounds.Height + 10;
                        bounds.X = item.Bounds.X + 10;
                        bounds.Width = ToolTipMaximumLength;
                        bounds.Height = 20;
                    }
                    else
                    {
                        bounds.Y = item.Bounds.Y + 10;
                        bounds.X = item.Bounds.Width + 10;
                        bounds.Width = ToolTipMaximumLength;
                        bounds.Height = 20;
                    }
                    Size imageSize = item.Owner.ImageScalingSize;
                    _toolTip.Start(caption, bounds);
                }
            }
        }

        private void Item_MouseLeave(object sender, EventArgs e)
        {
            if (_toolTip != null)
                _toolTip.Stop();
        }

        #endregion

        #region GraphicsMode
        internal class GraphicsMode : IDisposable
        {
            private Graphics _graphicCopy;
            private SmoothingMode _oldMode;

            public GraphicsMode(Graphics g, SmoothingMode mode)
            {
                _graphicCopy = g;
                _oldMode = _graphicCopy.SmoothingMode;
                _graphicCopy.SmoothingMode = mode;
            }
            public void Dispose()
            {
                _graphicCopy.SmoothingMode = _oldMode;
            }
        }
        #endregion

        #region ToolTip
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        internal class ToolTip : NativeWindow
        {
            #region Constants
            // setwindowpos
            static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
            static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
            static readonly IntPtr HWND_TOP = new IntPtr(0);
            static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
            // size/move
            internal const uint SWP_NOSIZE = 0x0001;
            internal const uint SWP_NOMOVE = 0x0002;
            internal const uint SWP_NOZORDER = 0x0004;
            internal const uint SWP_NOREDRAW = 0x0008;
            internal const uint SWP_NOACTIVATE = 0x0010;
            internal const uint SWP_FRAMECHANGED = 0x0020;
            internal const uint SWP_SHOWWINDOW = 0x0040;
            internal const uint SWP_HIDEWINDOW = 0x0080;
            internal const uint SWP_NOCOPYBITS = 0x0100;
            internal const uint SWP_NOOWNERZORDER = 0x0200;
            internal const uint SWP_NOSENDCHANGING = 0x0400;
            // styles
            internal const int TTS_ALWAYSTIP = 0x01;
            internal const int TTS_NOPREFIX = 0x02;
            internal const int TTS_NOANIMATE = 0x10;
            internal const int TTS_NOFADE = 0x20;
            internal const int TTS_BALLOON = 0x40;
            internal const int TTS_CLOSE = 0x80;
            internal const int TTS_USEVISUALSTYLE = 0x100;
            // window messages
            internal const int WM_NOTIFY = 0x4E;
            internal const int WM_REFLECT = 0x2000;
            internal const int WM_PAINT = 0xF;
            internal const int WM_SIZE = 0x5;
            internal const int WM_MOVE = 0x3;
            internal const int WM_SETFONT = 0x30;
            internal const int WM_GETFONT = 0x31;
            internal const int WM_SHOWWINDOW = 0x18;
            internal const int WM_MOUSEMOVE = 0x200;
            internal const int WM_MOUSELEAVE = 0x2A3;
            internal const int WM_LBUTTONDOWN = 0x201;
            internal const int WM_LBUTTONUP = 0x202;
            internal const int WM_LBUTTONDBLCLK = 0x203;
            internal const int WM_RBUTTONDOWN = 0x204;
            internal const int WM_RBUTTONUP = 0x205;
            internal const int WM_RBUTTONDBLCLK = 0x206;
            internal const int WM_MBUTTONDOWN = 0x207;
            internal const int WM_MBUTTONUP = 0x208;
            internal const int WM_MBUTTONDBLCLK = 0x209;
            internal const int WM_MOUSEWHEEL = 0x20A;
            internal const int WM_TIMER = 0x113;
            internal const int WM_NCPAINT = 0x85;
            internal const int WM_DESTROY = 0x2;
            internal const int WM_SETFOCUS = 0x7;
            internal const int WM_KILLFOCUS = 0x8;
            internal const int WM_IME_NOTIFY = 0x282;
            internal const int WM_IME_SETCONTEXT = 0x281;
            internal const int WM_ACTIVATE = 0x6;
            internal const int WM_NCACTIVATE = 0x86;
            internal const int WM_STYLECHANGED = 0x7d;
            internal const int WM_STYLECHANGING = 0x7c;
            internal const int WM_WINDOWPOSCHANGING = 0x46;
            internal const int WM_WINDOWPOSCHANGED = 0x47;
            internal const int WM_NCCALCSIZE = 0x83;
            internal const int WM_CTLCOLOR = 0x3d8d610;
            // window styles
            internal const int GWL_STYLE = (-16);
            internal const int GWL_EXSTYLE = (-20);
            internal const int SS_OWNERDRAW = 0xD;
            internal const int WS_OVERLAPPED = 0x0;
            internal const int WS_TABSTOP = 0x10000;
            internal const int WS_THICKFRAME = 0x40000;
            internal const int WS_HSCROLL = 0x100000;
            internal const int WS_VSCROLL = 0x200000;
            internal const int WS_BORDER = 0x800000;
            internal const int WS_CLIPCHILDREN = 0x2000000;
            internal const int WS_CLIPSIBLINGS = 0x4000000;
            internal const int WS_VISIBLE = 0x10000000;
            internal const int WS_CHILD = 0x40000000;
            internal const int WS_POPUP = -2147483648;
            // window extended styles
            internal const int WS_EX_LTRREADING = 0x0;
            internal const int WS_EX_LEFT = 0x0;
            internal const int WS_EX_RIGHTSCROLLBAR = 0x0;
            internal const int WS_EX_DLGMODALFRAME = 0x1;
            internal const int WS_EX_NOPARENTNOTIFY = 0x4;
            internal const int WS_EX_TOPMOST = 0x8;
            internal const int WS_EX_ACCEPTFILES = 0x10;
            internal const int WS_EX_TRANSPARENT = 0x20;
            internal const int WS_EX_MDICHILD = 0x40;
            internal const int WS_EX_TOOLWINDOW = 0x80;
            internal const int WS_EX_WINDOWEDGE = 0x100;
            internal const int WS_EX_CLIENTEDGE = 0x200;
            internal const int WS_EX_CONTEXTHELP = 0x400;
            internal const int WS_EX_RIGHT = 0x1000;
            internal const int WS_EX_RTLREADING = 0x2000;
            internal const int WS_EX_LEFTSCROLLBAR = 0x4000;
            internal const int WS_EX_CONTROLPARENT = 0x10000;
            internal const int WS_EX_STATICEDGE = 0x20000;
            internal const int WS_EX_APPWINDOW = 0x40000;
            internal const int WS_EX_NOACTIVATE = 0x8000000;
            internal const int WS_EX_LAYERED = 0x80000;
            #endregion

            #region Structs
            [StructLayout(LayoutKind.Sequential)]
            internal struct RECT
            {
                internal RECT(int X, int Y, int Width, int Height)
                {
                    this.Left = X;
                    this.Top = Y;
                    this.Right = Width;
                    this.Bottom = Height;
                }
                internal int Left;
                internal int Top;
                internal int Right;
                internal int Bottom;
            }
            #endregion

            #region API
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern IntPtr CreateWindowEx(int exstyle, string lpClassName, string lpWindowName, int dwStyle,
                int x, int y, int nWidth, int nHeight, IntPtr hwndParent, IntPtr Menu, IntPtr hInstance, IntPtr lpParam);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool DestroyWindow(IntPtr hWnd);

            [DllImport("user32.dll", SetLastError = false)]
            private static extern IntPtr GetDesktopWindow();

            [DllImport("user32.dll", ExactSpelling = true)]
            internal static extern IntPtr SetTimer(IntPtr hWnd, int nIDEvent, uint uElapse, IntPtr lpTimerFunc);

            [DllImport("user32.dll", ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool KillTimer(IntPtr hWnd, uint uIDEvent);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint flags);

            [DllImport("user32.dll")]
            internal static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

            [DllImport("user32.dll")]
            internal static extern int GetWindowLong(IntPtr hwnd, int nIndex);

            [DllImport("user32.dll")]
            internal static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool GetCursorPos(ref Point lpPoint);

            [DllImport("user32.dll")]
            internal static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);

            [DllImport("user32.dll")]
            internal static extern IntPtr GetDC(IntPtr handle);

            [DllImport("user32.dll")]
            internal static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
            #endregion

            internal bool _timerActive = false;
            internal bool _tipShowing = false;
            internal int _timerTick = 0;
            internal int _horzOffset = 4;
            internal int _vertOffset = 4;
            internal int _delayTime = 1000;
            internal int _visibleTime = 1000;
            internal string _text = String.Empty;
            internal Color _foreColor = Color.Black;
            internal Color _gradientBegin = Color.White;
            internal Color _gradientEnd = Color.Silver;
            internal IntPtr _hTipWnd = IntPtr.Zero;
            internal IntPtr _hInstance = IntPtr.Zero;
            internal IntPtr _hParentWnd = IntPtr.Zero;
            internal Rectangle _clientBounds = new Rectangle();
            internal Font _textFont = new Font("Tahoma", 8.25f, FontStyle.Regular);

            public ToolTip(IntPtr hParentWnd)
            {
                Type t = typeof(ToolTip);
                Module m = t.Module;
                _hInstance = Marshal.GetHINSTANCE(m);
                _hParentWnd = hParentWnd;
                // create window
                _hTipWnd = CreateWindowEx(WS_EX_TOPMOST | WS_EX_TOOLWINDOW, "STATIC", ""
                    , SS_OWNERDRAW | WS_CHILD | WS_CLIPSIBLINGS | WS_OVERLAPPED, 0, 0, 0, 0
                    , GetDesktopWindow(), IntPtr.Zero, _hInstance, IntPtr.Zero);
                // set starting position
                SetWindowPos(_hTipWnd, HWND_TOP, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_NOOWNERZORDER);

                this.AssignHandle(_hTipWnd);
            }

            internal Rectangle Bounds
            {
                get { return _clientBounds; }
                set { _clientBounds = value; }
            }

            internal string Caption
            {
                get { return _text; }
                set { _text = value; }
            }

            internal int DelayTime
            {
                get { return _delayTime; }
                set { _delayTime = value; }
            }
            internal Color ForeColor
            {
                get { return _foreColor; }
                set { _foreColor = value; }
            }

            internal Color GradientBegin
            {
                get { return _gradientBegin; }
                set { _gradientBegin = value; }
            }

            internal Color GradientEnd
            {
                get { return _gradientEnd; }
                set { _gradientEnd = value; }
            }

            public int MaximumLength
            {
                set { _clientBounds.Width = value; }
            }

            internal int VisibleTime
            {
                get { return _visibleTime; }
                set { _visibleTime = value; }
            }

            #region Public Methods
            internal void Start(string caption, Rectangle bounds)
            {
                if (_timerActive)
                    Stop();
                Caption = caption;
                Bounds = bounds;
                SetTimer(_hTipWnd, 1, 100, IntPtr.Zero);
            }

            internal void Stop()
            {
                // kill the timer
                KillTimer(_hTipWnd, 1);
                // hide the window
                showWindow(false);
                // reset properties
                Caption = String.Empty;
                //ItemImage = null;
                Bounds = Rectangle.Empty;
                // reset timer values
                _timerTick = 0;
                _tipShowing = false;
                _timerActive = false;
            }

            public void Dispose()
            {
                if (_hTipWnd != IntPtr.Zero)
                {
                    this.ReleaseHandle();
                    if (_textFont != null)
                        _textFont.Dispose();
                    DestroyWindow(_hTipWnd);
                    _hTipWnd = IntPtr.Zero;
                }
            }
            #endregion

            #region Internal Methods
            internal Rectangle calculateSize()
            {
                Rectangle bounds = new Rectangle();
                int offset = 0;
                int width = Bounds.Width;
                SizeF captionSize = calcTextSize(Caption, _textFont, width - offset);
                bounds.Height = (int)captionSize.Height + 10;
                bounds.Width = (int)captionSize.Width + 12 + offset;

                return bounds;
            }

            private SizeF calcTextSize(string text, Font font, int width)
            {
                SizeF sF = new SizeF();
                IntPtr hdc = GetDC(_hTipWnd);
                Graphics g = Graphics.FromHdc(hdc);
                if (width > 0)
                    sF = g.MeasureString(text, font, width);
                else
                    sF = g.MeasureString(text, font);
                ReleaseDC(_hTipWnd, hdc);
                g.Dispose();
                return sF;
            }

            internal void copyBackground(Graphics g)
            {
                RECT windowRect = new RECT();
                GetWindowRect(_hTipWnd, ref windowRect);
                g.CopyFromScreen(windowRect.Left, windowRect.Top, 0, 0, new Size(windowRect.Right - windowRect.Left, windowRect.Bottom - windowRect.Top), CopyPixelOperation.SourceCopy);
            }

            internal GraphicsPath createRoundRectanglePath(Graphics g, float X, float Y, float width, float height, float radius)
            {
                // create a path
                GraphicsPath pathBounds = new GraphicsPath();
                pathBounds.AddLine(X + radius, Y, X + width - (radius * 2), Y);
                pathBounds.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
                pathBounds.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
                pathBounds.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
                pathBounds.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
                pathBounds.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
                pathBounds.AddLine(X, Y + height - (radius * 2), X, Y + radius);
                pathBounds.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
                pathBounds.CloseFigure();
                return pathBounds;
            }

            internal void drawBackground(IntPtr hdc)
            {
                // create the graphics instance
                Graphics g = Graphics.FromHdc(hdc);
                // copy in the background to mimic transparency
                copyBackground(g);
                // create the shadow rect
                Rectangle shadowArea = new Rectangle(3, Bounds.Height - 3, Bounds.Width - 3, Bounds.Height);
                // draw the bottom shadow
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
                {
                    using (GraphicsPath shadowPath = createRoundRectanglePath(g, 4, Bounds.Height - 5, Bounds.Width - 4, Bounds.Height, 1f))
                    {
                        using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea
                            , Color.FromArgb(50, 0x99, 0x99, 0x99)
                            , Color.FromArgb(40, 0x99, 0x99, 0x99)
                            , LinearGradientMode.Horizontal))
                        {
                            Blend blend = new Blend();
                            blend.Positions = new float[] { 0f, .1f, .2f, 1f };
                            blend.Factors = new float[] { 0f, .5f, .6f, .9f };
                            shadowBrush.Blend = blend;
                            g.FillPath(shadowBrush, shadowPath);
                        }
                    }
                    // draw the right shadow
                    using (GraphicsPath shadowPath = createRoundRectanglePath(g, Bounds.Height - 5, 4, Bounds.Width - 4, Bounds.Height - 8, 4f))
                    {
                        using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea
                            , Color.FromArgb(50, 0x99, 0x99, 0x99)
                            , Color.FromArgb(40, 0x99, 0x99, 0x99)
                            , LinearGradientMode.Horizontal))
                        {
                            Blend blend = new Blend();
                            blend.Positions = new float[] { 0f, .1f, .2f, 1f };
                            blend.Factors = new float[] { 0f, .5f, .6f, .7f };
                            shadowBrush.Blend = blend;
                            g.FillPath(shadowBrush, shadowPath);
                        }
                    }
                    // adjust the bounds
                    Rectangle fillBounds = new Rectangle(0, 0, Bounds.Width - 4, Bounds.Height - 4);
                    using (GraphicsPath fillPath = createRoundRectanglePath(g, fillBounds.X, fillBounds.Y, fillBounds.Width, fillBounds.Height, 4f))
                    {
                        using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea, GradientBegin, GradientEnd, LinearGradientMode.Vertical))
                        {
                            // draw the frame
                            using (Pen fillPen = new Pen(Color.FromArgb(250, 0x44, 0x44, 0x44)))
                                g.DrawPath(fillPen, fillPath);
                            // fill the body
                            Blend blend = new Blend();
                            blend.Positions = new float[] { 0f, .4f, .6f, 1f };
                            blend.Factors = new float[] { 0f, .3f, .6f, .8f };
                            shadowBrush.Blend = blend;
                            g.FillPath(shadowBrush, fillPath);
                        }
                    }
                }
                g.Dispose();
            }

            internal void drawCaption(IntPtr hdc)
            {
                Graphics g = Graphics.FromHdc(hdc);
                using (StringFormat sF = new StringFormat())
                {
                    sF.Alignment = StringAlignment.Near;
                    sF.LineAlignment = StringAlignment.Near;
                    using (Brush captionBrush = new SolidBrush(ForeColor))
                        g.DrawString(Caption, _textFont, captionBrush, new RectangleF(3, 3, Bounds.Width, Bounds.Height), sF);
                }
                g.Dispose();
            }

            internal void positionWindow()
            {
                if (_hTipWnd != IntPtr.Zero)
                {
                    // offset with screen position
                    RECT windowRect = new RECT();
                    GetWindowRect(_hParentWnd, ref windowRect);
                    windowRect.Left += Bounds.X;
                    windowRect.Top += Bounds.Y;
                    // position the window
                    SetWindowPos(_hTipWnd, HWND_TOPMOST, windowRect.Left, windowRect.Top, Bounds.Width, Bounds.Height, SWP_SHOWWINDOW | SWP_NOACTIVATE);
                }
            }

            internal void renderTip()
            {
                if ((Caption != String.Empty) && (Bounds != Rectangle.Empty))
                {
                    // create the canvas
                    _clientBounds.Height = 50;
                    Rectangle bounds = calculateSize();
                    bounds.X = Bounds.X;
                    bounds.Y = Bounds.Y;
                    Bounds = bounds;
                    cStoreDc drawDc = new cStoreDc();
                    drawDc.Width = Bounds.Width;
                    drawDc.Height = Bounds.Height;
                    positionWindow();
                    showWindow(true); // show the window
                    drawBackground(drawDc.Hdc); // draw the background to the temp dc
                    drawCaption(drawDc.Hdc); //draw text
                    IntPtr hdc = GetDC(_hTipWnd); // draw the tempdc to the window
                    BitBlt(hdc, 0, 0, Bounds.Width, Bounds.Height, drawDc.Hdc, 0, 0, 0xCC0020);
                    ReleaseDC(_hTipWnd, hdc);
                    drawDc.Dispose();
                }
            }

            internal void showWindow(bool show)
            {
                if (show)
                    SetWindowPos(_hTipWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_SHOWWINDOW | SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
                else
                    SetWindowPos(_hTipWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_HIDEWINDOW | SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
            }
            #endregion

            #region WndProc
            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_TIMER:
                        _timerTick++;
                        if (_timerTick > (DelayTime / 100))
                            if (!_tipShowing)
                            {
                                _tipShowing = true;
                                renderTip();
                            }
                        if (_timerTick > ((DelayTime + VisibleTime) / 100))
                            Stop();
                        base.WndProc(ref m);
                        break;

                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
            #endregion
        }
        #endregion
    }
    
    #region StoreDc
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class cStoreDc
    {
        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateDCA([MarshalAs(UnmanagedType.LPStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPStr)]string lpszOutput, int lpInitData);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateDCW([MarshalAs(UnmanagedType.LPWStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPWStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPWStr)]string lpszOutput, int lpInitData);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, int lpInitData);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true)]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr hObject);

        internal int _Height = 0;
        internal int _Width = 0;
        internal IntPtr _Hdc = IntPtr.Zero;
        internal IntPtr _Bmp = IntPtr.Zero;
        internal IntPtr _BmpOld = IntPtr.Zero;

        public IntPtr Hdc
        {
            get { return _Hdc; }
        }

        public IntPtr HBmp
        {
            get { return _Bmp; }
        }

        public int Height
        {
            get { return _Height; }
            set
            {
                if (_Height != value)
                {
                    _Height = value;
                    ImageCreate(_Width, _Height);
                }
            }
        }

        public int Width
        {
            get { return _Width; }
            set
            {
                if (_Width != value)
                {
                    _Width = value;
                    ImageCreate(_Width, _Height);
                }
            }
        }

        internal void ImageCreate(int Width, int Height)
        {
            IntPtr pHdc = IntPtr.Zero;

            ImageDestroy();
            pHdc = CreateDCA("DISPLAY", "", "", 0);
            _Hdc = CreateCompatibleDC(pHdc);
            _Bmp = CreateCompatibleBitmap(pHdc, _Width, _Height);
            _BmpOld = SelectObject(_Hdc, _Bmp);
            if (_BmpOld == IntPtr.Zero)
            {
                ImageDestroy();
            }
            else
            {
                _Width = Width;
                _Height = Height;
            }
            DeleteDC(pHdc);
            pHdc = IntPtr.Zero;
        }

        internal void ImageDestroy()
        {
            if (_BmpOld != IntPtr.Zero)
            {
                SelectObject(_Hdc, _BmpOld);
                _BmpOld = IntPtr.Zero;
            }
            if (_Bmp != IntPtr.Zero)
            {
                DeleteObject(_Bmp);
                _Bmp = IntPtr.Zero;
            }
            if (_Hdc != IntPtr.Zero)
            {
                DeleteDC(_Hdc);
                _Hdc = IntPtr.Zero;
            }
        }

        public void Dispose()
        {
            ImageDestroy();
        }
    }
    #endregion
}
