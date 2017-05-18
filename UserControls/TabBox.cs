﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;

namespace Shauni.UserControls
{
    [ToolboxBitmap(typeof(TabControl))]
    public class TabControlOwn : TabControl
    {
        public TabControlOwn()
            : base()
        {
            if (this._DisplayManager.Equals(TabControlDisplayManager.Custom))
            {
                this.SetStyle(ControlStyles.UserPaint, true);
                this.ItemSize = new Size(0, 15);
                this.Padding = new Point(9, 0);
            }

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.ResizeRedraw = true;
        }

        TabControlDisplayManager _DisplayManager = TabControlDisplayManager.Custom;

        [DefaultValue(typeof(TabControlDisplayManager), "Custom")]
        public TabControlDisplayManager DisplayManager
        {
            get
            {
                return this._DisplayManager;
            }
            set
            {
                if (this._DisplayManager != value)
                {
                    if (this._DisplayManager.Equals(TabControlDisplayManager.Custom))
                    {
                        this.SetStyle(ControlStyles.UserPaint, true);
                        this.ItemSize = new Size(0, 15);
                        this.Padding = new Point(9, 0);
                    }
                    else
                    {
                        this.ItemSize = new Size(0, 0);
                        this.Padding = new Point(6, 3);
                        this.SetStyle(ControlStyles.UserPaint, false);
                    }
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (this.DesignMode == true)
            {
                LinearGradientBrush backBrush = new LinearGradientBrush(
                            this.Bounds,
                            SystemColors.ControlLightLight,
                            SystemColors.ControlLight,
                            LinearGradientMode.Vertical);
                pevent.Graphics.FillRectangle(backBrush, this.Bounds);
                backBrush.Dispose();
            }
            else
                this.PaintTransparentBackground(pevent.Graphics, this.ClientRectangle);
        }

        protected void PaintTransparentBackground(Graphics g, Rectangle clipRect)
        {
            if ((this.Parent != null))
            {
                clipRect.Offset(this.Location);
                PaintEventArgs e = new PaintEventArgs(g, clipRect);
                GraphicsState state = g.Save();
                g.SmoothingMode = SmoothingMode.HighSpeed;
                try
                {
                    g.TranslateTransform((float)-this.Location.X, (float)-this.Location.Y);
                    this.InvokePaintBackground(this.Parent, e);
                    this.InvokePaint(this.Parent, e);
                }

                finally
                {
                    g.Restore(state);
                    clipRect.Offset(-this.Location.X, -this.Location.Y);
                }
            }
            else
            {
                LinearGradientBrush backBrush = new LinearGradientBrush(this.Bounds, SystemColors.ControlLightLight, SystemColors.ControlLight, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                g.FillRectangle(backBrush, this.Bounds);
                backBrush.Dispose();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            //Paint the Background
            this.PaintTransparentBackground(e.Graphics, this.ClientRectangle);

            this.PaintAllTheTabs(e);
            this.PaintTheTabPageBorder(e);
            this.PaintTheSelectedTab(e);
        }

        private void PaintAllTheTabs(PaintEventArgs e)
        {
            if (this.TabCount > 0)
            {
                for (int index = 0; index < this.TabCount; index++)
                {
                    this.PaintTab(e, index);
                }
            }
        }

        private void PaintTab(PaintEventArgs e, int index)
        {
            GraphicsPath path = this.GetPath(index);
            this.PaintTabBackground(e.Graphics, index, path);
            this.PaintTabBorder(e.Graphics, index, path);
            this.PaintTabText(e.Graphics, index);
            this.PaintTabImage(e.Graphics, index);
        }

        private void PaintTabBackground(System.Drawing.Graphics graph, int index, GraphicsPath path)
        {
            Rectangle rect = this.GetTabRect(index);
            Brush buttonBrush = new LinearGradientBrush(rect, Color.WhiteSmoke, Color.WhiteSmoke,
                    LinearGradientMode.Vertical);

            if (index == this.SelectedIndex)
                buttonBrush = new SolidBrush(SystemColors.ControlLightLight);

            graph.FillPath(buttonBrush, path);
            buttonBrush.Dispose();
        }

        private void PaintTabBorder(System.Drawing.Graphics graph, int index, GraphicsPath path)
        {
            Pen borderPen = (index == this.SelectedIndex) ? new Pen(Color.Silver) : new Pen(Color.LightGray);
            graph.DrawPath(borderPen, path);

            borderPen.Dispose();
        }
        void PaintTabImage(Graphics graph, int index)
        {
            Image tabImage = null;

            if (this.TabPages[index].ImageIndex > -1 && this.ImageList != null)
                tabImage = this.ImageList.Images[this.TabPages[index].ImageIndex];

            else if (this.TabPages[index].ImageKey.Trim().Length > 0 && this.ImageList != null)
                tabImage = this.ImageList.Images[this.TabPages[index].ImageKey];

            if (tabImage != null && TabPages.Count > 1)
            {
                Rectangle rect = this.GetTabRect(index);
                graph.DrawImage(tabImage, rect.Right - rect.Height - 4, 4, rect.Height - 2, rect.Height - 2);
            }
        }

        private void PaintTabText(Graphics graph, int index)
        {
            Rectangle rect = this.GetTabRect(index);
            Rectangle rect2 = new Rectangle(rect.Left + 8, rect.Top + 1, rect.Width - 6, rect.Height);

            if (index == 0)
                rect2 = new Rectangle(rect.Left + rect.Height, rect.Top + 1, rect.Width - rect.Height, rect.Height);

            string tabtext = this.TabPages[index].Text;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;

            Brush forebrush = null;

            if (this.TabPages[index].Enabled == false)
                forebrush = Brushes.Red;
            else
                forebrush = index == this.SelectedIndex ? Brushes.Black : Brushes.Navy;

            Font tabFont = this.Font;
            if (index == this.SelectedIndex)
            {
                tabFont = new Font(this.Font, FontStyle.Bold);

                if (index == 0)
                    rect2 = new Rectangle(rect.Left + rect.Height, rect.Top + 1, rect.Width - rect.Height + 5, rect.Height);
            }

            graph.DrawString(tabtext, tabFont, forebrush, rect2, format);

        }

        private void PaintTheTabPageBorder(PaintEventArgs e)
        {
            if (this.TabCount > 0)
            {
                Rectangle borderRect = new Rectangle(this.TabPages[0].Bounds.X,
                    this.TabPages[0].Bounds.Y, this.TabPages[0].Bounds.Width,
                    this.TabPages[0].Bounds.Height);
                borderRect.Inflate(1, 1);
                ControlPaint.DrawBorder(e.Graphics, borderRect, Color.LightGray, ButtonBorderStyle.Solid);
            }
        }

        private void PaintTheSelectedTab(System.Windows.Forms.PaintEventArgs e)
        {
            Rectangle selrect;
            int selrectRight = 0;

            switch (this.SelectedIndex)
            {
                case -1:
                    break;
                case 0:
                    selrect = this.GetTabRect(this.SelectedIndex);
                    selrectRight = selrect.Right;
                    e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect.Left + 2, selrect.Bottom + 1, selrectRight - 2, selrect.Bottom + 1);
                    break;
                default:
                    selrect = this.GetTabRect(this.SelectedIndex);
                    selrectRight = selrect.Right;
                    e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect.Left + 18 - selrect.Height, selrect.Bottom + 1, selrectRight - 2, selrect.Bottom + 1);
                    break;
            }
        }

        private GraphicsPath GetPath(int index)
        {
            GraphicsPath path = new GraphicsPath();
            path.Reset();

            Rectangle rect = this.GetTabRect(index);

            if (index == 0) //prima tab...
            {
                path.AddLine(rect.Left + 1, rect.Bottom + 1, rect.Left + rect.Height, rect.Top + 2);
                path.AddLine(rect.Left + rect.Height + 4, rect.Top, rect.Right - 3, rect.Top);
                path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
            }
            else //tutte le altre tab...
            {
                if (index == this.SelectedIndex)
                {
                    path.AddLine(rect.Left + 1, rect.Top + 5, rect.Left + 4, rect.Top + 2);
                    path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top);
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
                    path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left + 1, rect.Bottom + 1);
                }
                else
                {
                    path.AddLine(rect.Left, rect.Top + 6, rect.Left + 4, rect.Top + 2);
                    path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top);
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
                    path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left, rect.Bottom + 1);
                }

            }
            return path;
        }

        public enum TabControlDisplayManager
        {
            Default,
            Custom
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_SETFONT = 0x30;
        private const int WM_FONTCHANGE = 0x1d;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.OnFontChanged(EventArgs.Empty);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            IntPtr hFont = this.Font.ToHfont();
            SendMessage(this.Handle, WM_SETFONT, hFont, (IntPtr)(-1));
            SendMessage(this.Handle, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);
            this.UpdateStyles();
            this.ItemSize = new Size(0, this.Font.Height + 2);
        }
    }

    /*public class ThemedColors
    {
        private const string NormalColor = "NormalColor";
        private const string HomeStead = "HomeStead";
        private const string Metallic = "Metallic";
        private const string NoTheme = "NoTheme";
        private static Color[] _toolBorder;

        public static int CurrentThemeIndex
        {
            get
            {
                return ThemedColors.GetCurrentThemeIndex();
            }
        }

        public static string CurrentThemeName
        {
            get
            {
                return ThemedColors.GetCurrentThemeName();
            }
        }

        public static Color ToolBorder
        {
            get
            {
                return ThemedColors._toolBorder[ThemedColors.CurrentThemeIndex];
            }
        }

        private ThemedColors()
        {
        }

        static ThemedColors()
        {
            Color[] colorArray1;
            colorArray1 = new Color[] { Color.FromArgb(127, 157, 185), Color.FromArgb(164, 185, 127), Color.FromArgb(165, 172, 178), Color.FromArgb(132, 130, 132) };
            ThemedColors._toolBorder = colorArray1;
        }

        private static int GetCurrentThemeIndex()
        {
            int theme = (int)ColorScheme.NoTheme;
            if (VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser && Application.RenderWithVisualStyles)
            {
                switch (VisualStyleInformation.ColorScheme)
                {
                    case NormalColor:
                        theme = (int)ColorScheme.NormalColor;
                        break;
                    case HomeStead:
                        theme = (int)ColorScheme.HomeStead;
                        break;
                    case Metallic:
                        theme = (int)ColorScheme.Metallic;
                        break;
                    default:
                        theme = (int)ColorScheme.NoTheme;
                        break;
                }
            }
            return theme;
        }

        private static string GetCurrentThemeName()
        {
            string theme = NoTheme;
            if (VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser && Application.RenderWithVisualStyles)
            {
                theme = VisualStyleInformation.ColorScheme;
            }
            return theme;
        }

        public enum ColorScheme
        {
            NormalColor = 0,
            HomeStead = 1,
            Metallic = 2,
            NoTheme = 3
        }
    }*/
}