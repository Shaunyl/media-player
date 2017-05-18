namespace Shauni.UserControls
{
    partial class AdvisePopup
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
            this.learningPopup = new Shauni.UserControls.MediaPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblAdvise = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLearningMessage = new Shauni.UserControls.TileButton();
            this.learningPopup.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLearningMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // learningPopup
            // 
            this.learningPopup.BackColor = System.Drawing.Color.GhostWhite;
            this.learningPopup.BorderColor = System.Drawing.Color.LightGray;
            this.learningPopup.BorderWidth = 1;
            this.learningPopup.Controls.Add(this.panel1);
            this.learningPopup.Controls.Add(this.panel2);
            this.learningPopup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.learningPopup.GradientEndColor = System.Drawing.Color.WhiteSmoke;
            this.learningPopup.GradientStartColor = System.Drawing.Color.GhostWhite;
            this.learningPopup.Image = global::Shauni.Properties.Resources.share21;
            this.learningPopup.ImageLocation = new System.Drawing.Point(6, 7);
            this.learningPopup.Location = new System.Drawing.Point(0, 0);
            this.learningPopup.Name = "learningPopup";
            this.learningPopup.RoundCornerRadius = 12;
            this.learningPopup.ShadowOffSet = 1;
            this.learningPopup.Size = new System.Drawing.Size(276, 35);
            this.learningPopup.TabIndex = 0;
            this.learningPopup.Resize += new System.EventHandler(this.learningPopup_Resize);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.lblAdvise);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 3, 0, 0);
            this.panel1.Size = new System.Drawing.Size(244, 35);
            this.panel1.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDescription.Location = new System.Drawing.Point(151, 8);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(4, 1, 0, 0);
            this.lblDescription.Size = new System.Drawing.Size(164, 16);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Welcome to Shauni universe!";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAdvise
            // 
            this.lblAdvise.AutoSize = true;
            this.lblAdvise.BackColor = System.Drawing.Color.Transparent;
            this.lblAdvise.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAdvise.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvise.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblAdvise.Location = new System.Drawing.Point(20, 3);
            this.lblAdvise.Name = "lblAdvise";
            this.lblAdvise.Padding = new System.Windows.Forms.Padding(8, 3, 0, 0);
            this.lblAdvise.Size = new System.Drawing.Size(69, 22);
            this.lblAdvise.TabIndex = 4;
            this.lblAdvise.Text = "Shauni:";
            this.lblAdvise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnLearningMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(244, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 35);
            this.panel2.TabIndex = 7;
            // 
            // btnLearningMessage
            // 
            this.btnLearningMessage.BackColor = System.Drawing.Color.Transparent;
            this.btnLearningMessage.CurrentTileIndex = 0;
            this.btnLearningMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLearningMessage.HoverTileIndex = 1;
            this.btnLearningMessage.IdleTileIndex = 0;
            this.btnLearningMessage.Image = global::Shauni.Properties.Resources.Close2;
            this.btnLearningMessage.Location = new System.Drawing.Point(11, 12);
            this.btnLearningMessage.Name = "btnLearningMessage";
            this.btnLearningMessage.PressedTileIndex = 0;
            this.btnLearningMessage.Size = new System.Drawing.Size(9, 9);
            this.btnLearningMessage.TabIndex = 3;
            this.btnLearningMessage.TabStop = false;
            this.btnLearningMessage.TilesNumber = 2;
            this.btnLearningMessage.Click += new System.EventHandler(this.btnLearningMessage_Click);
            // 
            // AdvisePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.learningPopup);
            this.Location = new System.Drawing.Point(6, 10);
            this.Name = "AdvisePopup";
            this.Size = new System.Drawing.Size(276, 35);
            this.learningPopup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLearningMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MediaPanel learningPopup;
        private TileButton btnLearningMessage;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblAdvise;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
