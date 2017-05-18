using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Shauni;
using Shauni.Graphic;

namespace Shauni.Forms
{
    public partial class FastSearchDialog : Form
    {
        public FastSearchDialog()
        {
            InitializeComponent();

            ToolStripOwnRenderer renderer = new ToolStripOwnRenderer();
            this.toolStripSearch.Renderer = renderer;
            renderer.ToolTipGradientBegin = Color.GhostWhite;
            renderer.ToolTipGradientEnd = Color.Lavender;
        }
    }
}
