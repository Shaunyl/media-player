using System;
using System.Windows.Forms;
using System.Drawing;

namespace Shauni.Graphic
{
    public class ColorTable
    {
        public class ShauniColorTable : ProfessionalColorTable
        {
            public override System.Drawing.Color ButtonCheckedGradientBegin
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonCheckedGradientBegin;
                    return Color.FromArgb(255, 223, 154);
                }
            }

            public override System.Drawing.Color ButtonCheckedGradientEnd
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonCheckedGradientEnd;
                    return Color.FromArgb(255, 166, 76);
                }
            }
            public override System.Drawing.Color ButtonCheckedGradientMiddle
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonCheckedGradientMiddle;
                    return Color.FromArgb(255, 195, 116);
                }
            }
            public override System.Drawing.Color ButtonCheckedHighlight
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonCheckedHighlight;
                    return Color.FromArgb(195, 211, 237);
                }
            }
            public override System.Drawing.Color ButtonCheckedHighlightBorder
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonCheckedHighlightBorder;
                    return Color.FromArgb(49, 106, 197);
                }
            }
            public override System.Drawing.Color ButtonPressedBorder //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonPressedBorder;
                    return Color.DarkGray;
                }
            }
            public override System.Drawing.Color ButtonPressedGradientBegin //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonPressedGradientBegin;
                    return Color.White;
                }
            }
            public override System.Drawing.Color ButtonPressedGradientEnd //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonPressedGradientEnd;
                    return Color.GhostWhite;
                }
            }
            /*public override System.Drawing.Color ButtonPressedGradientMiddle
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonPressedGradientMiddle;
                    return Color.Linen;
                }
            }*/
            public override System.Drawing.Color ButtonPressedHighlight
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonPressedHighlight;
                    return Color.Yellow;
                }
            }
            public override System.Drawing.Color ButtonPressedHighlightBorder
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonPressedHighlightBorder;
                    return Color.FromArgb(49, 106, 197);
                }
            }
            public override System.Drawing.Color ButtonSelectedBorder //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonSelectedBorder;
                    return Color.DarkGray;
                }
            }
            public override System.Drawing.Color ButtonSelectedGradientBegin //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonSelectedGradientBegin;
                    return Color.GhostWhite;
                }
            }
            public override System.Drawing.Color ButtonSelectedGradientEnd //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonSelectedGradientEnd;
                    return Color.Lavender;
                }
            }
            public override System.Drawing.Color ButtonSelectedGradientMiddle //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonSelectedGradientMiddle;
                    return Color.Lavender;
                }
            }
            public override System.Drawing.Color ButtonSelectedHighlight
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonSelectedHighlight;
                    return Color.FromArgb(195, 211, 237);
                }
            }
            public override System.Drawing.Color ButtonSelectedHighlightBorder
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ButtonSelectedHighlightBorder;
                    return Color.FromArgb(0, 0, 128);
                }
            }
            public override System.Drawing.Color CheckBackground
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.CheckBackground;
                    return Color.FromArgb(23, 168, 255);
                }
            }
            public override System.Drawing.Color CheckPressedBackground
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.CheckPressedBackground;
                    return Color.FromArgb(254, 128, 62);
                }
            }
            public override System.Drawing.Color CheckSelectedBackground
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.CheckSelectedBackground;
                    return Color.FromArgb(254, 128, 62);
                }
            }
            public override System.Drawing.Color GripDark
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.GripDark;
                    return Color.FromArgb(39, 65, 118);
                }
            }
            public override System.Drawing.Color GripLight
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.GripLight;
                    return Color.FromArgb(255, 255, 255);
                }
            }
            public override System.Drawing.Color ImageMarginGradientBegin //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ImageMarginGradientBegin;
                    return Color.FromArgb(248, 248, 255);
                }
            }
            public override System.Drawing.Color ImageMarginGradientEnd //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ImageMarginGradientEnd;
                    return Color.AliceBlue;
                }
            }
            /*public override System.Drawing.Color ImageMarginGradientMiddle
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ImageMarginGradientMiddle;
                    return Color.FromArgb(203, 225, 252);
                }
            }*/
            public override System.Drawing.Color ImageMarginRevealedGradientBegin
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ImageMarginRevealedGradientBegin;
                    return Color.FromArgb(203, 221, 246);
                }
            }
            public override System.Drawing.Color ImageMarginRevealedGradientEnd
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ImageMarginRevealedGradientEnd;
                    return Color.FromArgb(114, 155, 215);
                }
            }
            public override System.Drawing.Color ImageMarginRevealedGradientMiddle
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ImageMarginRevealedGradientMiddle;
                    return Color.FromArgb(161, 197, 249);
                }
            }
            public override System.Drawing.Color MenuBorder
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.MenuBorder;
                    return Color.FromArgb(0, 45, 150);
                }
            }
            public override System.Drawing.Color MenuItemBorder
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.MenuItemBorder;
                    return Color.FromArgb(0, 0, 128);
                }
            }
            public override System.Drawing.Color MenuItemPressedGradientBegin //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.MenuItemPressedGradientBegin;
                    return Color.GhostWhite;
                }
            }
            public override System.Drawing.Color MenuItemPressedGradientEnd //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.MenuItemPressedGradientEnd;
                    return Color.FromArgb(240, 248, 255);
                }
            }
            public override System.Drawing.Color MenuItemPressedGradientMiddle
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.MenuItemPressedGradientMiddle;
                    return Color.FromArgb(161, 197, 249);
                }
            }
            public override System.Drawing.Color MenuItemSelected
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.MenuItemSelected;
                    return Color.FromArgb(255, 238, 194);
                }
            }
            public override System.Drawing.Color MenuItemSelectedGradientBegin //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.MenuItemSelectedGradientBegin;
                    return Color.White;
                }
            }
            public override System.Drawing.Color MenuItemSelectedGradientEnd //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.MenuItemSelectedGradientEnd;
                    return Color.GhostWhite;
                }
            }
            public override System.Drawing.Color MenuStripGradientBegin
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.MenuStripGradientBegin;
                    return Color.FromArgb(158, 190, 245);
                }
            }
            public override System.Drawing.Color MenuStripGradientEnd
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.MenuStripGradientEnd;
                    return Color.FromArgb(196, 218, 250);
                }
            }
            public override System.Drawing.Color OverflowButtonGradientBegin
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.OverflowButtonGradientBegin;
                    return Color.FromArgb(127, 177, 250);
                }
            }
            public override System.Drawing.Color OverflowButtonGradientEnd
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.OverflowButtonGradientEnd;
                    return Color.FromArgb(0, 53, 145);
                }
            }
            public override System.Drawing.Color OverflowButtonGradientMiddle
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.OverflowButtonGradientMiddle;
                    return Color.FromArgb(82, 127, 208);
                }
            }
            public override System.Drawing.Color RaftingContainerGradientBegin
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.RaftingContainerGradientBegin;
                    return Color.FromArgb(158, 190, 245);
                }
            }
            public override System.Drawing.Color RaftingContainerGradientEnd
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.RaftingContainerGradientEnd;
                    return Color.FromArgb(196, 218, 250);
                }
            }
            public override System.Drawing.Color SeparatorDark
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.SeparatorDark;
                    return Color.Black;
                }
            }
            public override System.Drawing.Color SeparatorLight
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.SeparatorLight;
                    return Color.Gray;
                }
            }
            public override System.Drawing.Color StatusStripGradientBegin
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.StatusStripGradientBegin;
                    return Color.GhostWhite;
                }
            }
            public override System.Drawing.Color StatusStripGradientEnd
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.StatusStripGradientEnd;
                    return Color.AliceBlue;
                }
            }
            public override System.Drawing.Color ToolStripBorder
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripBorder;
                    return Color.FromArgb(59, 97, 156);
                }
            }
            public override System.Drawing.Color ToolStripContentPanelGradientBegin
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripContentPanelGradientBegin;
                    return Color.FromArgb(158, 190, 245);
                }
            }
            public override System.Drawing.Color ToolStripContentPanelGradientEnd
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripContentPanelGradientEnd;
                    return Color.FromArgb(196, 218, 250);
                }
            }
            /*public override System.Drawing.Color ToolStripDropDownBackground
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripDropDownBackground;
                    return Color.FromArgb(246, 246, 246);
                }
            }*/

            public Color ToolStripMenuGradientBegin //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripDropDownBackground;
                    return Color.White;
                }
            }

            public Color ToolStripMenuGradientEnd //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripDropDownBackground;
                    return Color.GhostWhite;
                }
            }

            public Color ToolStripVerticalLine
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripDropDownBackground;
                    return Color.Gray;
                }
            }

            public override System.Drawing.Color ToolStripGradientBegin //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripGradientBegin;
                    //return Color.AliceBlue;
                    //return Color.Black;
                    return Color.FromArgb(232, 241, 250);
                }
            }

            public override System.Drawing.Color ToolStripGradientMiddle //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripGradientMiddle;
                    //return Color.FromArgb(40, 40, 40);
                    //return Color.GhostWhite;
                    return Color.FromArgb(226, 236, 248);
                }
            }

            public override System.Drawing.Color ToolStripGradientEnd //
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripGradientEnd;
                    //return Color.FromArgb(80, 80, 80);
                    return Color.FromArgb(226, 236, 248);
                    //return Color.White;
                }
            }

            public override System.Drawing.Color ToolStripPanelGradientBegin
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripPanelGradientBegin;
                    return Color.FromArgb(158, 190, 245);
                }
            }
            public override System.Drawing.Color ToolStripPanelGradientEnd
            {
                get
                {
                    if (this.UseSystemColors)
                        return base.ToolStripPanelGradientEnd;
                    return Color.FromArgb(196, 218, 250);
                }
            }
        }
    }
}
