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
    public partial class Paragraphe : UserControl
    {
        public Paragraphe()
        {
            InitializeComponent();
        }

        public new String Text
        {
            set { this.title.Text = value; }
            get { return this.title.Text; }
        }

        public new Font Font
        {
            set { this.title.Font = value; }
            get { return this.title.Font; }
        }

        public new Image BackgroundImage
        {
            set { this.pictureBox1.Image = value; }
            get { return this.pictureBox1.Image; }
        }

        public Color Color
        {
            set { this.panel1.BackColor = value; }
            get { return this.panel1.BackColor; }
        }

        public Color TextColor
        {
            set { this.title.ForeColor = value; }
            get { return this.title.ForeColor; }
        }
        
        private void Paragraphe_Resize(object sender, EventArgs e)
        {
            this.panel1.Width = 300 + (this.Width - 352);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
