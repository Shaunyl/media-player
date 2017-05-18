namespace Shauni.Forms
{
    partial class AutoPlaylistEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoPlaylistEditor));
            this.autoPlaylistPanel = new Shauni.UserControls.AutoPlaylistPanel();
            this.SuspendLayout();
            // 
            // autoPlaylistPanel
            // 
            this.autoPlaylistPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.autoPlaylistPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoPlaylistPanel.Location = new System.Drawing.Point(0, 0);
            this.autoPlaylistPanel.Name = "autoPlaylistPanel";
            this.autoPlaylistPanel.Size = new System.Drawing.Size(732, 356);
            this.autoPlaylistPanel.TabIndex = 0;
            // 
            // AutoPlaylistEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(732, 356);
            this.Controls.Add(this.autoPlaylistPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoPlaylistEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatic Playlist Editor";
            this.Load += new System.EventHandler(this.AutoPlaylistEditor_Load);
            this.Shown += new System.EventHandler(this.AutoPlaylistEditor_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.AutoPlaylistPanel autoPlaylistPanel;
    }
}