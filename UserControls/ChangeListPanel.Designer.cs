namespace Shauni.UserControls
{
    partial class ChangeListPanel
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
            this.lblListShowed = new System.Windows.Forms.Label();
            this.BtnScrollToTheRight = new Shauni.UserControls.TileButton();
            this.BtnScrollToTheLeft = new Shauni.UserControls.TileButton();
            ((System.ComponentModel.ISupportInitialize)(this.BtnScrollToTheRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnScrollToTheLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // lblListShowed
            // 
            this.lblListShowed.AutoSize = true;
            this.lblListShowed.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListShowed.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblListShowed.Location = new System.Drawing.Point(101, 1);
            this.lblListShowed.Name = "lblListShowed";
            this.lblListShowed.Size = new System.Drawing.Size(42, 16);
            this.lblListShowed.TabIndex = 2;
            this.lblListShowed.Tag = "";
            this.lblListShowed.Text = "Songs";
            this.lblListShowed.Resize += new System.EventHandler(this.lblListShowed_Resize);
            // 
            // BtnScrollToTheRight
            // 
            this.BtnScrollToTheRight.CurrentTileIndex = 0;
            this.BtnScrollToTheRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnScrollToTheRight.HoverTileIndex = 1;
            this.BtnScrollToTheRight.IdleTileIndex = 0;
            this.BtnScrollToTheRight.Image = global::Shauni.Properties.Resources.ButtonScrollRight;
            this.BtnScrollToTheRight.Location = new System.Drawing.Point(243, 0);
            this.BtnScrollToTheRight.Name = "BtnScrollToTheRight";
            this.BtnScrollToTheRight.PressedTileIndex = 4;
            this.BtnScrollToTheRight.Size = new System.Drawing.Size(24, 23);
            this.BtnScrollToTheRight.TabIndex = 4;
            this.BtnScrollToTheRight.TabStop = false;
            this.BtnScrollToTheRight.Click += new System.EventHandler(this.BtnScrollToTheRight_Click);
            this.BtnScrollToTheRight.MouseLeave += new System.EventHandler(this.BtnScrollToTheRight_MouseLeave);
            // 
            // BtnScrollToTheLeft
            // 
            this.BtnScrollToTheLeft.CurrentTileIndex = 0;
            this.BtnScrollToTheLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnScrollToTheLeft.Enabled = false;
            this.BtnScrollToTheLeft.HoverTileIndex = 1;
            this.BtnScrollToTheLeft.IdleTileIndex = 0;
            this.BtnScrollToTheLeft.Image = global::Shauni.Properties.Resources.ButtonScroll;
            this.BtnScrollToTheLeft.Location = new System.Drawing.Point(0, 0);
            this.BtnScrollToTheLeft.Name = "BtnScrollToTheLeft";
            this.BtnScrollToTheLeft.PressedTileIndex = 4;
            this.BtnScrollToTheLeft.Size = new System.Drawing.Size(24, 23);
            this.BtnScrollToTheLeft.TabIndex = 3;
            this.BtnScrollToTheLeft.TabStop = false;
            this.BtnScrollToTheLeft.Click += new System.EventHandler(this.BtnScrollToTheLeft_Click);
            this.BtnScrollToTheLeft.MouseLeave += new System.EventHandler(this.BtnScrollToTheLeft_MouseLeave);
            // 
            // ChangeListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.BtnScrollToTheRight);
            this.Controls.Add(this.BtnScrollToTheLeft);
            this.Controls.Add(this.lblListShowed);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ChangeListPanel";
            this.Size = new System.Drawing.Size(267, 23);
            this.Resize += new System.EventHandler(this.ChangeListPanel_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.BtnScrollToTheRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnScrollToTheLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListShowed;
        private TileButton BtnScrollToTheLeft;
        private TileButton BtnScrollToTheRight;
    }
}
