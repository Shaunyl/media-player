namespace Shauni.UserControls
{
    partial class ChartTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Graph.DataSeries dataSeries2 = new Graph.DataSeries();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartTab));
            Graph.SymbolStyle symbolStyle2 = new Graph.SymbolStyle();
            this.chart = new Graph.Chart2D();
            this.SuspendLayout();
            // 
            // chart2D1
            // 
            this.chart.AutoMode = true;
            this.chart.AxisOffset = 0F;
            dataSeries2.Dash = System.Drawing.Drawing2D.DashStyle.Solid;
            dataSeries2.IsLineVisible = false;
            dataSeries2.LineColor = System.Drawing.Color.Empty;
            dataSeries2.MaxX = 0F;
            dataSeries2.MaxY = 0F;
            dataSeries2.MinX = 0F;
            dataSeries2.MinY = 0F;
            dataSeries2.Name = null;
            dataSeries2.PointList = ((System.Collections.Generic.List<System.Drawing.PointF>)(resources.GetObject("dataSeries2.PointList")));
            symbolStyle2.BorderColor = System.Drawing.Color.DarkRed;
            symbolStyle2.BorderThickness = 1F;
            symbolStyle2.FillColor = System.Drawing.Color.Red;
            symbolStyle2.IsVisible = false;
            symbolStyle2.SymbolSize = 10F;
            symbolStyle2.SymbolType = Graph.SymbolStyle.SymbolTypeEnum.Circle;
            dataSeries2.SymbolStyle = symbolStyle2;
            dataSeries2.Thickness = 0F;
            this.chart.DataSeries = dataSeries2;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart2D1";
            this.chart.Size = new System.Drawing.Size(286, 362);
            this.chart.TabIndex = 0;
            // 
            // ChartTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chart);
            this.Name = "ChartTab";
            this.Size = new System.Drawing.Size(286, 362);
            this.ResumeLayout(false);

        }

        #endregion

        private Graph.Chart2D chart;
    }
}
