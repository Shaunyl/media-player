namespace Shauni.UserControls
{
    partial class Track
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
            this.components = new System.ComponentModel.Container();
            this.ttVolumeValue = new System.Windows.Forms.ToolTip(this.components);
            this.blueCursor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.blueCursor)).BeginInit();
            this.SuspendLayout();
            // 
            // blueCursor
            // 
            this.blueCursor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.blueCursor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.blueCursor.BackgroundImage = global::Shauni.Properties.Resources.trackCursor;
            this.blueCursor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.blueCursor.InitialImage = null;
            this.blueCursor.Location = new System.Drawing.Point(110, 1);
            this.blueCursor.Margin = new System.Windows.Forms.Padding(0);
            this.blueCursor.Name = "blueCursor";
            this.blueCursor.Size = new System.Drawing.Size(13, 14);
            this.blueCursor.TabIndex = 1;
            this.blueCursor.TabStop = false;
            this.blueCursor.Visible = false;
            this.blueCursor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.THUMB_MouseDown);
            this.blueCursor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.THUMB_MouseMove);
            this.blueCursor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.THUMB_MouseUp);
            // 
            // Track
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.blueCursor);
            this.Name = "Track";
            this.Size = new System.Drawing.Size(220, 15);
            this.Load += new System.EventHandler(this.TRACK_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TRACK_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.THUMB_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.THUMB_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.blueCursor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox blueCursor;
        private System.Windows.Forms.ToolTip ttVolumeValue;
    }
}
