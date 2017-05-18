using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Shauni.Database;

using Graph;

namespace Shauni.UserControls
{
    public partial class ChartTab : UserControl
    {
        public ChartTab()
        {
            InitializeComponent();
        }

        public void VisualizeChart(Song song)
        {
            SharedData.ChartInteractor.CreateMainChart(song, this.chart);
        }
    }
}
