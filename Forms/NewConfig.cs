using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Shauni.Graphic;

namespace Shauni.Forms
{
    public partial class NewConfig : Form
    {
        public NewConfig()
        {
            InitializeComponent();
            this.BuildToolStrip();
        }

        private void BuildToolStrip()
        {
            ToolStripOwnRenderer renderer = new ToolStripOwnRenderer();
            renderer.Art = false;
            this.statusStrip.Renderer = renderer;
        }
    }
}
