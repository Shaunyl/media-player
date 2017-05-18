using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Shauni.UserControls
{
    public class IconPackListBox : ShauniListBox
    {
        public IconPackListBox()
        {
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (isNormal)
                return;

            if (item == null) return;

            int Xpadding = e.Bounds.X + this.IconPadding.X;
            int Ypadding = e.Bounds.Y + this.IconPadding.Y;

            if (e.State.HasFlag(DrawItemState.Selected))
            {
                Xpadding += 1;
                Ypadding += 1;
                lgb = new LinearGradientBrush(e.Bounds, _backColorCheckedGradientStart, _backColorCheckedGradientEnd, 90, true);
                brdCol = _borderCheckedColor;
            }
            else
            {
                lgb = new LinearGradientBrush(e.Bounds, _backColorGradientStart, _backColorGradientEnd, 1, true);
                brdCol = this._borderColor;
            }

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

            lgb.Dispose();
        }
    }
}
