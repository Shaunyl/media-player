using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shauni.UserControls
{
    public partial class ChangeListPanel : UserControl
    {
        [Description("Occurs after a directional button is pressed.")]
        public event EventHandler<ListChangedEventArgs> ListChanged;

        public ChangeListPanel()
        {
            InitializeComponent();
            this.BtnScrollToTheLeft.IdleTileIndex = 2;
            this.BtnScrollToTheRight.CurrentTileIndex = 0;
            this.BtnScrollToTheRight.PressedTileIndex = 4;
        }

        protected void OnListChanged(ListChangedEventArgs e)
        {
            if (ListChanged != null)
                ListChanged(this, e);
        }

        private void BtnScrollToTheLeft_Click(object sender, EventArgs e)
        {
            ListChangedEventArgs fbe = new ListChangedEventArgs(Scrolling.ToTheLeft);
            this.OnListChanged(fbe);

            this.lblListShowed.Text = "Songs";
            this.BtnScrollToTheLeft.Enabled = false;
            this.BtnScrollToTheRight.Enabled = true;
        }

        private void BtnScrollToTheRight_Click(object sender, EventArgs e)
        {
            ListChangedEventArgs fbe = new ListChangedEventArgs(Scrolling.ToTheRight);
            this.OnListChanged(fbe);

            this.lblListShowed.Text = "Pictures";
            this.BtnScrollToTheRight.Enabled = false;
            this.BtnScrollToTheLeft.Enabled = true;
        }

        private void lblListShowed_Resize(object sender, EventArgs e)
        {
            //this.lblListShowed.Left = (this.Width + this.BtnScrollToTheLeft.Width) / 2;
        }

        private void ChangeListPanel_Resize(object sender, EventArgs e)
        {
            this.lblListShowed.Left = (int)((this.Width) / 2.4);
        }

        private void BtnScrollToTheRight_MouseLeave(object sender, EventArgs e)
        {

        }

        private void BtnScrollToTheLeft_MouseLeave(object sender, EventArgs e)
        {

        }
    }

    public class ListChangedEventArgs : EventArgs
    {
        public Scrolling Scrolling { get; private set; }

        public ListChangedEventArgs(Scrolling scrolling)
        {
            this.Scrolling = scrolling;
        }
    }

    public enum Scrolling
    {
        ToTheLeft,
        ToTheRight
    }
}
