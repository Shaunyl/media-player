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
    public class ImageListBox : ShauniListBox
    {
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

            Bitmap image = alives.Contains(e.Index) ? Properties.Resources.Attention : Properties.Resources.Picture;

            Rectangle photoRct = new Rectangle(Xpadding, Ypadding, image.Width, image.Height);
            e.Graphics.DrawImage(image, photoRct);

            string text = ((IMedia)item).Name.ToProperCase();

            for (int i = 0; i < 2; i++)
                e.Graphics.DrawString(text, this.Font, stringBrushes[i],
                    Xpadding + image.Width + 22 - i,
                    2 - i + Ypadding - this.IconPadding.Y - 1 + (e.Bounds.Height - this.Font.Height) / 2);

            image.Dispose();

            lgb.Dispose();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }
    }
}
