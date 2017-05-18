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
    public partial class AdvisePopup : UserControl
    {//17; 42; 230 advise message...
        public AdvisePopup()
        {
            InitializeComponent();
            AdaptLabels();
        }

        public void SetText(String advise, String description)
        {
            this.lblAdvise.Text = advise + ':';
            this.lblDescription.Text = description;
            AdaptLabels();
            SetImageByName(advise);
        }

        private void SetImageByName(String advise)
        {
            switch (advise)
            {
                case "System": this.learningPopup.Image = Properties.Resources.Customize; break;
                case "Learning": this.learningPopup.Image = Properties.Resources.share21; break;
            }
        }

        private void learningPopup_Resize(object sender, EventArgs e)
        {
            AdaptLabels();
        }

        private void AdaptLabels()
        {
            this.lblDescription.Location = new Point(lblAdvise.Location.X + lblAdvise.Size.Width, lblDescription.Location.Y);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void btnLearningMessage_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Dispose();
        }
    }
}
