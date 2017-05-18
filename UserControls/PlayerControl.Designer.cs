namespace Shauni.UserControls
{
    partial class PlayerControl
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tmrPositionUpdate = new System.Windows.Forms.Timer(this.components);
            this.pnlStandardControls = new System.Windows.Forms.Panel();
            this.lblTrackPos = new System.Windows.Forms.Label();
            this.trkPosition = new Shauni.UserControls.Track();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.btnPlay = new Shauni.UserControls.TileButton();
            this.trkVolume = new Shauni.UserControls.Track();
            this.btnPause = new Shauni.UserControls.TileButton();
            this.btnStop = new Shauni.UserControls.TileButton();
            this.btnBrowse = new Shauni.UserControls.TileButton();
            this.btnRepeat = new Shauni.UserControls.TileButton();
            this.btnRandom = new Shauni.UserControls.TileButton();
            this.pnlStandardControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRepeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRandom)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // tmrPositionUpdate
            // 
            this.tmrPositionUpdate.Enabled = true;
            this.tmrPositionUpdate.Tick += new System.EventHandler(this.tmrPositionUpdate_Tick);
            // 
            // pnlStandardControls
            // 
            this.pnlStandardControls.BackgroundImage = global::Shauni.Properties.Resources.Player;
            this.pnlStandardControls.Controls.Add(this.lblTrackPos);
            this.pnlStandardControls.Controls.Add(this.trkPosition);
            this.pnlStandardControls.Controls.Add(this.lblCurrentFile);
            this.pnlStandardControls.Controls.Add(this.btnPlay);
            this.pnlStandardControls.Controls.Add(this.trkVolume);
            this.pnlStandardControls.Controls.Add(this.btnPause);
            this.pnlStandardControls.Controls.Add(this.btnStop);
            this.pnlStandardControls.Controls.Add(this.btnBrowse);
            this.pnlStandardControls.Controls.Add(this.btnRepeat);
            this.pnlStandardControls.Controls.Add(this.btnRandom);
            this.pnlStandardControls.Location = new System.Drawing.Point(1, 0);
            this.pnlStandardControls.Name = "pnlStandardControls";
            this.pnlStandardControls.Size = new System.Drawing.Size(571, 67);
            this.pnlStandardControls.TabIndex = 13;
            // 
            // lblTrackPos
            // 
            this.lblTrackPos.AutoEllipsis = true;
            this.lblTrackPos.BackColor = System.Drawing.Color.Transparent;
            this.lblTrackPos.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackPos.ForeColor = System.Drawing.Color.DimGray;
            this.lblTrackPos.Image = global::Shauni.Properties.Resources.sound_grey;
            this.lblTrackPos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTrackPos.Location = new System.Drawing.Point(411, 30);
            this.lblTrackPos.Name = "lblTrackPos";
            this.lblTrackPos.Size = new System.Drawing.Size(16, 15);
            this.lblTrackPos.TabIndex = 10;
            this.lblTrackPos.Click += new System.EventHandler(this.lblTrackPos_Click);
            // 
            // trkPosition
            // 
            this.trkPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trkPosition.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.trkPosition.BackgroundImage = global::Shauni.Properties.Resources.trackPosBackg;
            this.trkPosition.FormatValue = null;
            this.trkPosition.Location = new System.Drawing.Point(18, 0);
            this.trkPosition.Margin = new System.Windows.Forms.Padding(0);
            this.trkPosition.Maximum = 100D;
            this.trkPosition.Minimum = 0D;
            this.trkPosition.MinimumSize = new System.Drawing.Size(14, 9);
            this.trkPosition.Name = "trkPosition";
            this.trkPosition.Size = new System.Drawing.Size(536, 13);
            this.trkPosition.TabIndex = 8;
            this.trkPosition.Value = 0D;
            this.trkPosition.ThumbMouseUp += new System.EventHandler(this.trkPosition_ThumbMouseUp);
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.AutoEllipsis = true;
            this.lblCurrentFile.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentFile.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentFile.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCurrentFile.Location = new System.Drawing.Point(3, 48);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(152, 15);
            this.lblCurrentFile.TabIndex = 9;
            this.lblCurrentFile.Text = "Ready!";
            // 
            // btnPlay
            // 
            this.btnPlay.CurrentTileIndex = 0;
            this.btnPlay.HoverTileIndex = 4;
            this.btnPlay.IdleTileIndex = 0;
            this.btnPlay.Image = global::Shauni.Properties.Resources.ButtonStart;
            this.btnPlay.Location = new System.Drawing.Point(216, 14);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.PressedTileIndex = 0;
            this.btnPlay.Size = new System.Drawing.Size(48, 50);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.TabStop = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // trkVolume
            // 
            this.trkVolume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(248)))));
            this.trkVolume.BackgroundImage = global::Shauni.Properties.Resources.trkVolume1;
            this.trkVolume.ForeColor = System.Drawing.Color.Red;
            this.trkVolume.FormatValue = null;
            this.trkVolume.Location = new System.Drawing.Point(466, 49);
            this.trkVolume.Margin = new System.Windows.Forms.Padding(0);
            this.trkVolume.Maximum = 100D;
            this.trkVolume.Minimum = 0D;
            this.trkVolume.MinimumSize = new System.Drawing.Size(14, 9);
            this.trkVolume.Name = "trkVolume";
            this.trkVolume.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.trkVolume.Size = new System.Drawing.Size(91, 14);
            this.trkVolume.TabIndex = 7;
            this.trkVolume.Value = 100D;
            this.trkVolume.ValueChanged += new System.EventHandler(this.trkVolume_ValueChanged);
            // 
            // btnPause
            // 
            this.btnPause.CurrentTileIndex = 0;
            this.btnPause.HoverTileIndex = 4;
            this.btnPause.IdleTileIndex = 0;
            this.btnPause.Image = global::Shauni.Properties.Resources.ButtonPause;
            this.btnPause.Location = new System.Drawing.Point(270, 14);
            this.btnPause.Name = "btnPause";
            this.btnPause.PressedTileIndex = 0;
            this.btnPause.Size = new System.Drawing.Size(48, 50);
            this.btnPause.TabIndex = 1;
            this.btnPause.TabStop = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.CurrentTileIndex = 0;
            this.btnStop.HoverTileIndex = 1;
            this.btnStop.IdleTileIndex = 0;
            this.btnStop.Image = global::Shauni.Properties.Resources.ButtonStop;
            this.btnStop.Location = new System.Drawing.Point(175, 25);
            this.btnStop.Name = "btnStop";
            this.btnStop.PressedTileIndex = 4;
            this.btnStop.Size = new System.Drawing.Size(25, 25);
            this.btnStop.TabIndex = 2;
            this.btnStop.TabStop = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.CurrentTileIndex = 0;
            this.btnBrowse.HoverTileIndex = 1;
            this.btnBrowse.IdleTileIndex = 0;
            this.btnBrowse.Image = global::Shauni.Properties.Resources.ButtonBrowse;
            this.btnBrowse.Location = new System.Drawing.Point(18, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.PressedTileIndex = 4;
            this.btnBrowse.Size = new System.Drawing.Size(25, 25);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.TabStop = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnRepeat
            // 
            this.btnRepeat.CurrentTileIndex = 0;
            this.btnRepeat.HoverTileIndex = 1;
            this.btnRepeat.IdleTileIndex = 0;
            this.btnRepeat.Image = global::Shauni.Properties.Resources.ButtonRepeat;
            this.btnRepeat.Location = new System.Drawing.Point(334, 25);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.PressedTileIndex = 4;
            this.btnRepeat.Size = new System.Drawing.Size(25, 25);
            this.btnRepeat.TabIndex = 3;
            this.btnRepeat.TabStop = false;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.CurrentTileIndex = 0;
            this.btnRandom.HoverTileIndex = 1;
            this.btnRandom.IdleTileIndex = 0;
            this.btnRandom.Image = global::Shauni.Properties.Resources.ButtonRandom;
            this.btnRandom.Location = new System.Drawing.Point(370, 25);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.PressedTileIndex = 4;
            this.btnRandom.Size = new System.Drawing.Size(25, 25);
            this.btnRandom.TabIndex = 4;
            this.btnRandom.TabStop = false;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pnlStandardControls);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(573, 68);
            this.pnlStandardControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRepeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRandom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel pnlStandardControls;
        private Track trkPosition;
        private TileButton btnPlay;
        private Track trkVolume;
        private TileButton btnPause;
        private TileButton btnStop;
        private TileButton btnBrowse;
        private TileButton btnRepeat;
        private TileButton btnRandom;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Timer tmrPositionUpdate;
        private System.Windows.Forms.Label lblTrackPos;
    }
}
