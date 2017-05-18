using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Shauni
{
    public class IconPackManager
    {
        private IconPack iconPack = null;
        private ToolStrip mainToolStrip = null;

        public IconPackManager(ToolStrip mainToolStrip)
        {
            this.mainToolStrip = mainToolStrip;
        }

        public IconPack IconPack
        {
            get { return iconPack; }
            set
            {
                if (iconPack != null)
                {
                    iconPack.OperationCompleted -= new EventHandler<IconLoadedEventArgs>(iconPack_OperationCompleted);
                }

                if (value != null)
                {
                    iconPack = value;
                    iconPack.OperationCompleted += new EventHandler<IconLoadedEventArgs>(iconPack_OperationCompleted);
                }
                else
                    iconPack = null;
            }
        }

        public void LoadIconPack(string iconPackName)
        {
            if (iconPackName == null)
                return;

            IconPack = new IconPack(Properties.Resources.Shauni, iconPackName);
            IconPack.LoadFromFile(Paths.IconPacks(iconPackName));
        }

        private void iconPack_OperationCompleted(object sender, IconLoadedEventArgs e)
        {
            int j = 0;
            for (int i = 0; i < this.mainToolStrip.Items.Count; i++)
            {
                if (this.mainToolStrip.Items[i] is ToolStripSeparator)
                    continue;

                this.mainToolStrip.Items[i].Image = e.Image[j++];
            }
        }
    }
}
