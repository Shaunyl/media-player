namespace Shauni.Forms
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.loadingCircle = new MRG.Controls.UI.LoadingCircle();
            this.tabControlOwn1 = new Shauni.UserControls.TabControlOwn();
            this.tbOverall = new System.Windows.Forms.TabPage();
            this.wbBio = new System.Windows.Forms.WebBrowser();
            this.lblTextArtist = new System.Windows.Forms.Label();
            this.pbMedia = new System.Windows.Forms.PictureBox();
            this.tbOther = new System.Windows.Forms.TabPage();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.lblTextAlbum = new System.Windows.Forms.Label();
            this.lblTextDuration = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.pbAlbum = new System.Windows.Forms.PictureBox();
            this.lblTextGenre = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.tbLyrics = new System.Windows.Forms.TabPage();
            this.rtbLyrics = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mediaListBox = new Shauni.UserControls.AudioListBox();
            this.tabControlOwn1.SuspendLayout();
            this.tbOverall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).BeginInit();
            this.tbOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbum)).BeginInit();
            this.tbLyrics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.White;
            this.tbSearch.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSearch.Location = new System.Drawing.Point(12, 22);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(373, 23);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.Text = "Search for a media...";
            this.tbSearch.Click += new System.EventHandler(this.tbSearch_Click);
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.Black;
            this.lblSearch.Location = new System.Drawing.Point(12, 552);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(0, 16);
            this.lblSearch.TabIndex = 3;
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = false;
            this.loadingCircle.BackColor = System.Drawing.Color.Transparent;
            this.loadingCircle.Color = System.Drawing.Color.SlateGray;
            this.loadingCircle.InnerCircleRadius = 8;
            this.loadingCircle.Location = new System.Drawing.Point(389, 24);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 24;
            this.loadingCircle.OuterCircleRadius = 9;
            this.loadingCircle.RotationSpeed = 60;
            this.loadingCircle.Size = new System.Drawing.Size(75, 23);
            this.loadingCircle.SpokeThickness = 4;
            this.loadingCircle.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.IE7;
            this.loadingCircle.TabIndex = 18;
            this.loadingCircle.Visible = false;
            // 
            // tabControlOwn1
            // 
            this.tabControlOwn1.Controls.Add(this.tbOverall);
            this.tabControlOwn1.Controls.Add(this.tbOther);
            this.tabControlOwn1.Controls.Add(this.tbLyrics);
            this.tabControlOwn1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControlOwn1.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlOwn1.ItemSize = new System.Drawing.Size(0, 22);
            this.tabControlOwn1.Location = new System.Drawing.Point(466, 0);
            this.tabControlOwn1.Margin = new System.Windows.Forms.Padding(9);
            this.tabControlOwn1.Name = "tabControlOwn1";
            this.tabControlOwn1.Padding = new System.Drawing.Point(9, 9);
            this.tabControlOwn1.SelectedIndex = 0;
            this.tabControlOwn1.Size = new System.Drawing.Size(446, 580);
            this.tabControlOwn1.TabIndex = 17;
            // 
            // tbOverall
            // 
            this.tbOverall.Controls.Add(this.wbBio);
            this.tbOverall.Controls.Add(this.lblTextArtist);
            this.tbOverall.Controls.Add(this.pbMedia);
            this.tbOverall.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOverall.ForeColor = System.Drawing.Color.DimGray;
            this.tbOverall.Location = new System.Drawing.Point(4, 26);
            this.tbOverall.Name = "tbOverall";
            this.tbOverall.Padding = new System.Windows.Forms.Padding(3);
            this.tbOverall.Size = new System.Drawing.Size(438, 550);
            this.tbOverall.TabIndex = 0;
            this.tbOverall.Text = "Overall       ";
            this.tbOverall.UseVisualStyleBackColor = true;
            // 
            // wbBio
            // 
            this.wbBio.Location = new System.Drawing.Point(24, 294);
            this.wbBio.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBio.Name = "wbBio";
            this.wbBio.Size = new System.Drawing.Size(397, 248);
            this.wbBio.TabIndex = 17;
            // 
            // lblTextArtist
            // 
            this.lblTextArtist.AutoSize = true;
            this.lblTextArtist.Font = new System.Drawing.Font("Miramonte", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextArtist.ForeColor = System.Drawing.Color.Black;
            this.lblTextArtist.Location = new System.Drawing.Point(19, 18);
            this.lblTextArtist.Name = "lblTextArtist";
            this.lblTextArtist.Size = new System.Drawing.Size(105, 26);
            this.lblTextArtist.TabIndex = 5;
            this.lblTextArtist.Text = "Unknown";
            // 
            // pbMedia
            // 
            this.pbMedia.BackColor = System.Drawing.Color.White;
            this.pbMedia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMedia.Location = new System.Drawing.Point(24, 47);
            this.pbMedia.Name = "pbMedia";
            this.pbMedia.Size = new System.Drawing.Size(397, 241);
            this.pbMedia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMedia.TabIndex = 0;
            this.pbMedia.TabStop = false;
            // 
            // tbOther
            // 
            this.tbOther.Controls.Add(this.lblAlbum);
            this.tbOther.Controls.Add(this.lblTextAlbum);
            this.tbOther.Controls.Add(this.lblTextDuration);
            this.tbOther.Controls.Add(this.lblGenre);
            this.tbOther.Controls.Add(this.pbAlbum);
            this.tbOther.Controls.Add(this.lblTextGenre);
            this.tbOther.Controls.Add(this.lblDuration);
            this.tbOther.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOther.ForeColor = System.Drawing.Color.DimGray;
            this.tbOther.Location = new System.Drawing.Point(4, 26);
            this.tbOther.Name = "tbOther";
            this.tbOther.Padding = new System.Windows.Forms.Padding(3);
            this.tbOther.Size = new System.Drawing.Size(438, 550);
            this.tbOther.TabIndex = 1;
            this.tbOther.Text = "Info";
            this.tbOther.UseVisualStyleBackColor = true;
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Font = new System.Drawing.Font("Miramonte", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlbum.ForeColor = System.Drawing.Color.Black;
            this.lblAlbum.Location = new System.Drawing.Point(22, 18);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(75, 26);
            this.lblAlbum.TabIndex = 8;
            this.lblAlbum.Text = "Album";
            // 
            // lblTextAlbum
            // 
            this.lblTextAlbum.AutoSize = true;
            this.lblTextAlbum.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextAlbum.ForeColor = System.Drawing.Color.Black;
            this.lblTextAlbum.Location = new System.Drawing.Point(22, 58);
            this.lblTextAlbum.Name = "lblTextAlbum";
            this.lblTextAlbum.Size = new System.Drawing.Size(18, 19);
            this.lblTextAlbum.TabIndex = 9;
            this.lblTextAlbum.Tag = "";
            this.lblTextAlbum.Text = "...";
            // 
            // lblTextDuration
            // 
            this.lblTextDuration.AutoSize = true;
            this.lblTextDuration.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextDuration.ForeColor = System.Drawing.Color.Black;
            this.lblTextDuration.Location = new System.Drawing.Point(22, 143);
            this.lblTextDuration.Name = "lblTextDuration";
            this.lblTextDuration.Size = new System.Drawing.Size(18, 19);
            this.lblTextDuration.TabIndex = 13;
            this.lblTextDuration.Text = "...";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Miramonte", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenre.ForeColor = System.Drawing.Color.Black;
            this.lblGenre.Location = new System.Drawing.Point(22, 188);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(69, 26);
            this.lblGenre.TabIndex = 10;
            this.lblGenre.Text = "Genre";
            // 
            // pbAlbum
            // 
            this.pbAlbum.BackColor = System.Drawing.Color.White;
            this.pbAlbum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAlbum.Location = new System.Drawing.Point(23, 278);
            this.pbAlbum.Name = "pbAlbum";
            this.pbAlbum.Size = new System.Drawing.Size(395, 260);
            this.pbAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAlbum.TabIndex = 16;
            this.pbAlbum.TabStop = false;
            // 
            // lblTextGenre
            // 
            this.lblTextGenre.AutoSize = true;
            this.lblTextGenre.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextGenre.ForeColor = System.Drawing.Color.Black;
            this.lblTextGenre.Location = new System.Drawing.Point(22, 228);
            this.lblTextGenre.Name = "lblTextGenre";
            this.lblTextGenre.Size = new System.Drawing.Size(18, 19);
            this.lblTextGenre.TabIndex = 11;
            this.lblTextGenre.Text = "...";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Miramonte", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.ForeColor = System.Drawing.Color.Black;
            this.lblDuration.Location = new System.Drawing.Point(22, 103);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(98, 26);
            this.lblDuration.TabIndex = 12;
            this.lblDuration.Text = "Duration";
            // 
            // tbLyrics
            // 
            this.tbLyrics.Controls.Add(this.rtbLyrics);
            this.tbLyrics.Controls.Add(this.label1);
            this.tbLyrics.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbLyrics.Location = new System.Drawing.Point(4, 26);
            this.tbLyrics.Name = "tbLyrics";
            this.tbLyrics.Size = new System.Drawing.Size(438, 550);
            this.tbLyrics.TabIndex = 2;
            this.tbLyrics.Text = "Lyrics    ";
            this.tbLyrics.UseVisualStyleBackColor = true;
            // 
            // rtbLyrics
            // 
            this.rtbLyrics.BackColor = System.Drawing.Color.White;
            this.rtbLyrics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLyrics.Location = new System.Drawing.Point(27, 62);
            this.rtbLyrics.Name = "rtbLyrics";
            this.rtbLyrics.Size = new System.Drawing.Size(390, 476);
            this.rtbLyrics.TabIndex = 10;
            this.rtbLyrics.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miramonte", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 26);
            this.label1.TabIndex = 9;
            this.label1.Tag = "";
            this.label1.Text = "Lyrics";
            // 
            // mediaListBox
            // 
            this.mediaListBox.AllowDrop = true;
            this.mediaListBox.BackColor = System.Drawing.Color.White;
            this.mediaListBox.BackColorCheckedGradientEnd = System.Drawing.Color.White;
            this.mediaListBox.BackColorCheckedGradientStart = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.mediaListBox.BackColorGradientEnd = System.Drawing.Color.White;
            this.mediaListBox.BackColorGradientStart = System.Drawing.Color.White;
            this.mediaListBox.BorderCheckedColor = System.Drawing.Color.DarkGray;
            this.mediaListBox.BorderColor = System.Drawing.Color.Gainsboro;
            this.mediaListBox.BorderRoundedAngle = 9;
            this.mediaListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mediaListBox.BorderType = Shauni.UserControls.ShauniListBox.BorderTypes.Rounded;
            this.mediaListBox.DisplayMember = "Name";
            this.mediaListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.mediaListBox.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediaListBox.ForeColor = System.Drawing.Color.Black;
            this.mediaListBox.FormattingEnabled = true;
            this.mediaListBox.IconPadding = new System.Drawing.Point(6, 6);
            this.mediaListBox.ItemHeight = 36;
            this.mediaListBox.Location = new System.Drawing.Point(12, 68);
            this.mediaListBox.Name = "mediaListBox";
            this.mediaListBox.Size = new System.Drawing.Size(436, 468);
            this.mediaListBox.TabIndex = 2;
            this.mediaListBox.ValueMember = "Name";
            this.mediaListBox.ItemClicked += new System.EventHandler<Shauni.UserControls.ItemClickedEventArgs>(this.mediaListBox_ItemClicked);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(912, 580);
            this.Controls.Add(this.loadingCircle);
            this.Controls.Add(this.tabControlOwn1);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.mediaListBox);
            this.Controls.Add(this.tbSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Search";
            this.tabControlOwn1.ResumeLayout(false);
            this.tbOverall.ResumeLayout(false);
            this.tbOverall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).EndInit();
            this.tbOther.ResumeLayout(false);
            this.tbOther.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbum)).EndInit();
            this.tbLyrics.ResumeLayout(false);
            this.tbLyrics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private UserControls.AudioListBox mediaListBox;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.PictureBox pbMedia;
        private System.Windows.Forms.Label lblTextArtist;
        private System.Windows.Forms.Label lblTextAlbum;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Label lblTextGenre;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblTextDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.PictureBox pbAlbum;
        private UserControls.TabControlOwn tabControlOwn1;
        private System.Windows.Forms.TabPage tbOverall;
        private System.Windows.Forms.TabPage tbOther;
        private System.Windows.Forms.WebBrowser wbBio;
        private System.Windows.Forms.TabPage tbLyrics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbLyrics;
        private MRG.Controls.UI.LoadingCircle loadingCircle;
    }
}