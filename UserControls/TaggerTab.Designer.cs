namespace Shauni.UserControls
{
    partial class TaggerTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaggerTab));
            this.lblFilename = new System.Windows.Forms.Label();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblTitleTag = new System.Windows.Forms.Label();
            this.tbArtist = new System.Windows.Forms.TextBox();
            this.lblArtistTag = new System.Windows.Forms.Label();
            this.tbAlbum = new System.Windows.Forms.TextBox();
            this.lblAlbumTag = new System.Windows.Forms.Label();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.lblGenreTag = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.lblYearTag = new System.Windows.Forms.Label();
            this.tbTrack = new System.Windows.Forms.TextBox();
            this.lblTrackNTag = new System.Windows.Forms.Label();
            this.tbDuration = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblStandard = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.tbCounter = new System.Windows.Forms.TextBox();
            this.btnPrevFromUserTab = new System.Windows.Forms.Button();
            this.lblIsFavourite = new System.Windows.Forms.Label();
            this.pbFavourite = new System.Windows.Forms.PictureBox();
            this.lblArtistStars = new System.Windows.Forms.Label();
            this.pnlAdvanced = new System.Windows.Forms.Panel();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.tbFileSize = new System.Windows.Forms.TextBox();
            this.tbAudioFormat = new System.Windows.Forms.TextBox();
            this.tbSamplingRate = new System.Windows.Forms.TextBox();
            this.lblAudioFormat = new System.Windows.Forms.Label();
            this.btnPrevFromAdvancedTab = new System.Windows.Forms.Button();
            this.lblBitRate = new System.Windows.Forms.Label();
            this.tbBitRate = new System.Windows.Forms.TextBox();
            this.lblSamplingRate = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.Panel();
            this.rbStars = new Shauni.UserControls.RatingBar();
            this.rbArtistStars = new Shauni.UserControls.RatingBar();
            this.pnlMain.SuspendLayout();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).BeginInit();
            this.pnlAdvanced.SuspendLayout();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.Location = new System.Drawing.Point(16, 113);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(59, 16);
            this.lblFilename.TabIndex = 0;
            this.lblFilename.Text = "Filename";
            // 
            // tbFilename
            // 
            this.tbFilename.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFilename.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilename.Location = new System.Drawing.Point(113, 106);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.ReadOnly = true;
            this.tbFilename.Size = new System.Drawing.Size(155, 21);
            this.tbFilename.TabIndex = 1;
            // 
            // tbTitle
            // 
            this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.tbTitle.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(98, 64);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(187, 21);
            this.tbTitle.TabIndex = 3;
            // 
            // lblTitleTag
            // 
            this.lblTitleTag.AutoSize = true;
            this.lblTitleTag.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTag.Location = new System.Drawing.Point(16, 71);
            this.lblTitleTag.Name = "lblTitleTag";
            this.lblTitleTag.Size = new System.Drawing.Size(32, 16);
            this.lblTitleTag.TabIndex = 2;
            this.lblTitleTag.Text = "Title";
            // 
            // tbArtist
            // 
            this.tbArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.tbArtist.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbArtist.Location = new System.Drawing.Point(98, 22);
            this.tbArtist.Name = "tbArtist";
            this.tbArtist.Size = new System.Drawing.Size(187, 21);
            this.tbArtist.TabIndex = 5;
            // 
            // lblArtistTag
            // 
            this.lblArtistTag.AutoSize = true;
            this.lblArtistTag.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtistTag.Location = new System.Drawing.Point(16, 29);
            this.lblArtistTag.Name = "lblArtistTag";
            this.lblArtistTag.Size = new System.Drawing.Size(41, 16);
            this.lblArtistTag.TabIndex = 4;
            this.lblArtistTag.Text = "Artist";
            // 
            // tbAlbum
            // 
            this.tbAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.tbAlbum.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAlbum.Location = new System.Drawing.Point(98, 106);
            this.tbAlbum.Name = "tbAlbum";
            this.tbAlbum.Size = new System.Drawing.Size(187, 21);
            this.tbAlbum.TabIndex = 7;
            // 
            // lblAlbumTag
            // 
            this.lblAlbumTag.AutoSize = true;
            this.lblAlbumTag.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlbumTag.Location = new System.Drawing.Point(16, 113);
            this.lblAlbumTag.Name = "lblAlbumTag";
            this.lblAlbumTag.Size = new System.Drawing.Size(44, 16);
            this.lblAlbumTag.TabIndex = 6;
            this.lblAlbumTag.Text = "Album";
            // 
            // tbGenre
            // 
            this.tbGenre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGenre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.tbGenre.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGenre.Location = new System.Drawing.Point(98, 148);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(187, 21);
            this.tbGenre.TabIndex = 9;
            // 
            // lblGenreTag
            // 
            this.lblGenreTag.AutoSize = true;
            this.lblGenreTag.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenreTag.Location = new System.Drawing.Point(16, 155);
            this.lblGenreTag.Name = "lblGenreTag";
            this.lblGenreTag.Size = new System.Drawing.Size(43, 16);
            this.lblGenreTag.TabIndex = 8;
            this.lblGenreTag.Text = "Genre";
            // 
            // tbYear
            // 
            this.tbYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.tbYear.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbYear.Location = new System.Drawing.Point(183, 191);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(102, 21);
            this.tbYear.TabIndex = 11;
            // 
            // lblYearTag
            // 
            this.lblYearTag.AutoSize = true;
            this.lblYearTag.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearTag.Location = new System.Drawing.Point(16, 197);
            this.lblYearTag.Name = "lblYearTag";
            this.lblYearTag.Size = new System.Drawing.Size(32, 16);
            this.lblYearTag.TabIndex = 10;
            this.lblYearTag.Text = "Year";
            // 
            // tbTrack
            // 
            this.tbTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(237)))), ((int)(((byte)(248)))));
            this.tbTrack.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTrack.Location = new System.Drawing.Point(183, 234);
            this.tbTrack.Name = "tbTrack";
            this.tbTrack.Size = new System.Drawing.Size(102, 21);
            this.tbTrack.TabIndex = 13;
            // 
            // lblTrackNTag
            // 
            this.lblTrackNTag.AutoSize = true;
            this.lblTrackNTag.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackNTag.Location = new System.Drawing.Point(16, 239);
            this.lblTrackNTag.Name = "lblTrackNTag";
            this.lblTrackNTag.Size = new System.Drawing.Size(53, 16);
            this.lblTrackNTag.TabIndex = 12;
            this.lblTrackNTag.Text = "Track N.";
            // 
            // tbDuration
            // 
            this.tbDuration.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDuration.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDuration.Location = new System.Drawing.Point(198, 231);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.ReadOnly = true;
            this.tbDuration.Size = new System.Drawing.Size(70, 21);
            this.tbDuration.TabIndex = 15;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(19, 236);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(56, 16);
            this.lblDuration.TabIndex = 14;
            this.lblDuration.Text = "Duration";
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdvanced.Image = ((System.Drawing.Image)(resources.GetObject("btnAdvanced.Image")));
            this.btnAdvanced.Location = new System.Drawing.Point(220, 289);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(26, 23);
            this.btnAdvanced.TabIndex = 17;
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // btnUser
            // 
            this.btnUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.Location = new System.Drawing.Point(252, 289);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(26, 23);
            this.btnUser.TabIndex = 16;
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlMain.Controls.Add(this.lblStandard);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.btnAdvanced);
            this.pnlMain.Controls.Add(this.btnUser);
            this.pnlMain.Controls.Add(this.lblTitleTag);
            this.pnlMain.Controls.Add(this.tbTitle);
            this.pnlMain.Controls.Add(this.lblArtistTag);
            this.pnlMain.Controls.Add(this.tbTrack);
            this.pnlMain.Controls.Add(this.tbArtist);
            this.pnlMain.Controls.Add(this.lblTrackNTag);
            this.pnlMain.Controls.Add(this.lblAlbumTag);
            this.pnlMain.Controls.Add(this.tbYear);
            this.pnlMain.Controls.Add(this.tbAlbum);
            this.pnlMain.Controls.Add(this.lblYearTag);
            this.pnlMain.Controls.Add(this.lblGenreTag);
            this.pnlMain.Controls.Add(this.tbGenre);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(292, 318);
            this.pnlMain.TabIndex = 18;
            // 
            // lblStandard
            // 
            this.lblStandard.AutoSize = true;
            this.lblStandard.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandard.ForeColor = System.Drawing.Color.Black;
            this.lblStandard.Location = new System.Drawing.Point(240, 4);
            this.lblStandard.Name = "lblStandard";
            this.lblStandard.Size = new System.Drawing.Size(0, 14);
            this.lblStandard.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(19, 289);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(26, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlUser.Controls.Add(this.pnlMain);
            this.pnlUser.Controls.Add(this.rbStars);
            this.pnlUser.Controls.Add(this.lblRating);
            this.pnlUser.Controls.Add(this.lblCounter);
            this.pnlUser.Controls.Add(this.tbCounter);
            this.pnlUser.Controls.Add(this.btnPrevFromUserTab);
            this.pnlUser.Controls.Add(this.lblIsFavourite);
            this.pnlUser.Controls.Add(this.pbFavourite);
            this.pnlUser.Controls.Add(this.lblArtistStars);
            this.pnlUser.Controls.Add(this.rbArtistStars);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUser.Location = new System.Drawing.Point(0, 0);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(292, 318);
            this.pnlUser.TabIndex = 19;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.Location = new System.Drawing.Point(16, 29);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(47, 16);
            this.lblRating.TabIndex = 0;
            this.lblRating.Text = "Rating";
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.Location = new System.Drawing.Point(16, 113);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(52, 16);
            this.lblCounter.TabIndex = 2;
            this.lblCounter.Text = "Counter";
            // 
            // tbCounter
            // 
            this.tbCounter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCounter.Enabled = false;
            this.tbCounter.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCounter.Location = new System.Drawing.Point(183, 108);
            this.tbCounter.Name = "tbCounter";
            this.tbCounter.ReadOnly = true;
            this.tbCounter.Size = new System.Drawing.Size(85, 21);
            this.tbCounter.TabIndex = 3;
            // 
            // btnPrevFromUserTab
            // 
            this.btnPrevFromUserTab.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevFromUserTab.Image")));
            this.btnPrevFromUserTab.Location = new System.Drawing.Point(259, 289);
            this.btnPrevFromUserTab.Name = "btnPrevFromUserTab";
            this.btnPrevFromUserTab.Size = new System.Drawing.Size(26, 23);
            this.btnPrevFromUserTab.TabIndex = 16;
            this.btnPrevFromUserTab.UseVisualStyleBackColor = true;
            this.btnPrevFromUserTab.Click += new System.EventHandler(this.btnPrevFromUserTab_Click);
            // 
            // lblIsFavourite
            // 
            this.lblIsFavourite.AutoSize = true;
            this.lblIsFavourite.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsFavourite.Location = new System.Drawing.Point(16, 71);
            this.lblIsFavourite.Name = "lblIsFavourite";
            this.lblIsFavourite.Size = new System.Drawing.Size(70, 16);
            this.lblIsFavourite.TabIndex = 4;
            this.lblIsFavourite.Text = "Is Favourite";
            // 
            // pbFavourite
            // 
            this.pbFavourite.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbFavourite.Location = new System.Drawing.Point(252, 71);
            this.pbFavourite.Name = "pbFavourite";
            this.pbFavourite.Size = new System.Drawing.Size(16, 16);
            this.pbFavourite.TabIndex = 19;
            this.pbFavourite.TabStop = false;
            // 
            // lblArtistStars
            // 
            this.lblArtistStars.AutoSize = true;
            this.lblArtistStars.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtistStars.Location = new System.Drawing.Point(20, 167);
            this.lblArtistStars.Name = "lblArtistStars";
            this.lblArtistStars.Size = new System.Drawing.Size(74, 16);
            this.lblArtistStars.TabIndex = 20;
            this.lblArtistStars.Text = "Artist Rating";
            // 
            // pnlAdvanced
            // 
            this.pnlAdvanced.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlAdvanced.Controls.Add(this.pnlUser);
            this.pnlAdvanced.Controls.Add(this.tbFilename);
            this.pnlAdvanced.Controls.Add(this.lblFileSize);
            this.pnlAdvanced.Controls.Add(this.tbFileSize);
            this.pnlAdvanced.Controls.Add(this.lblFilename);
            this.pnlAdvanced.Controls.Add(this.tbDuration);
            this.pnlAdvanced.Controls.Add(this.tbAudioFormat);
            this.pnlAdvanced.Controls.Add(this.lblDuration);
            this.pnlAdvanced.Controls.Add(this.tbSamplingRate);
            this.pnlAdvanced.Controls.Add(this.lblAudioFormat);
            this.pnlAdvanced.Controls.Add(this.btnPrevFromAdvancedTab);
            this.pnlAdvanced.Controls.Add(this.lblBitRate);
            this.pnlAdvanced.Controls.Add(this.tbBitRate);
            this.pnlAdvanced.Controls.Add(this.lblSamplingRate);
            this.pnlAdvanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdvanced.Location = new System.Drawing.Point(0, 0);
            this.pnlAdvanced.Name = "pnlAdvanced";
            this.pnlAdvanced.Size = new System.Drawing.Size(292, 318);
            this.pnlAdvanced.TabIndex = 20;
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileSize.Location = new System.Drawing.Point(16, 71);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(52, 16);
            this.lblFileSize.TabIndex = 19;
            this.lblFileSize.Text = "File Size";
            // 
            // tbFileSize
            // 
            this.tbFileSize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbFileSize.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileSize.Location = new System.Drawing.Point(113, 64);
            this.tbFileSize.Name = "tbFileSize";
            this.tbFileSize.ReadOnly = true;
            this.tbFileSize.Size = new System.Drawing.Size(155, 21);
            this.tbFileSize.TabIndex = 20;
            this.tbFileSize.Text = "71.496 Byte   (69 KB)";
            // 
            // tbAudioFormat
            // 
            this.tbAudioFormat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbAudioFormat.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAudioFormat.Location = new System.Drawing.Point(113, 22);
            this.tbAudioFormat.Name = "tbAudioFormat";
            this.tbAudioFormat.ReadOnly = true;
            this.tbAudioFormat.Size = new System.Drawing.Size(155, 21);
            this.tbAudioFormat.TabIndex = 17;
            // 
            // tbSamplingRate
            // 
            this.tbSamplingRate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbSamplingRate.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSamplingRate.Location = new System.Drawing.Point(198, 150);
            this.tbSamplingRate.Name = "tbSamplingRate";
            this.tbSamplingRate.ReadOnly = true;
            this.tbSamplingRate.Size = new System.Drawing.Size(70, 21);
            this.tbSamplingRate.TabIndex = 18;
            // 
            // lblAudioFormat
            // 
            this.lblAudioFormat.AutoSize = true;
            this.lblAudioFormat.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioFormat.Location = new System.Drawing.Point(16, 29);
            this.lblAudioFormat.Name = "lblAudioFormat";
            this.lblAudioFormat.Size = new System.Drawing.Size(87, 16);
            this.lblAudioFormat.TabIndex = 0;
            this.lblAudioFormat.Text = "Audio format";
            // 
            // btnPrevFromAdvancedTab
            // 
            this.btnPrevFromAdvancedTab.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevFromAdvancedTab.Image")));
            this.btnPrevFromAdvancedTab.Location = new System.Drawing.Point(259, 289);
            this.btnPrevFromAdvancedTab.Name = "btnPrevFromAdvancedTab";
            this.btnPrevFromAdvancedTab.Size = new System.Drawing.Size(26, 23);
            this.btnPrevFromAdvancedTab.TabIndex = 16;
            this.btnPrevFromAdvancedTab.UseVisualStyleBackColor = true;
            this.btnPrevFromAdvancedTab.Click += new System.EventHandler(this.btnPrevFromAdvancedTab_Click);
            // 
            // lblBitRate
            // 
            this.lblBitRate.AutoSize = true;
            this.lblBitRate.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBitRate.Location = new System.Drawing.Point(16, 197);
            this.lblBitRate.Name = "lblBitRate";
            this.lblBitRate.Size = new System.Drawing.Size(50, 16);
            this.lblBitRate.TabIndex = 2;
            this.lblBitRate.Text = "Bit Rate";
            // 
            // tbBitRate
            // 
            this.tbBitRate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbBitRate.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBitRate.Location = new System.Drawing.Point(198, 192);
            this.tbBitRate.Name = "tbBitRate";
            this.tbBitRate.ReadOnly = true;
            this.tbBitRate.Size = new System.Drawing.Size(70, 21);
            this.tbBitRate.TabIndex = 3;
            // 
            // lblSamplingRate
            // 
            this.lblSamplingRate.AutoSize = true;
            this.lblSamplingRate.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamplingRate.Location = new System.Drawing.Point(16, 155);
            this.lblSamplingRate.Name = "lblSamplingRate";
            this.lblSamplingRate.Size = new System.Drawing.Size(87, 16);
            this.lblSamplingRate.TabIndex = 4;
            this.lblSamplingRate.Text = "Sampling Rate";
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.Color.GhostWhite;
            this.container.Controls.Add(this.pnlAdvanced);
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(292, 318);
            this.container.TabIndex = 21;
            // 
            // rbStars
            // 
            this.rbStars.BarBackColor = System.Drawing.Color.GhostWhite;
            this.rbStars.Enabled = false;
            this.rbStars.Gap = ((byte)(1));
            this.rbStars.IconEmpty = ((System.Drawing.Image)(resources.GetObject("rbStars.IconEmpty")));
            this.rbStars.IconFull = ((System.Drawing.Image)(resources.GetObject("rbStars.IconFull")));
            this.rbStars.IconHalf = ((System.Drawing.Image)(resources.GetObject("rbStars.IconHalf")));
            this.rbStars.IconsCount = ((byte)(5));
            this.rbStars.Location = new System.Drawing.Point(183, 22);
            this.rbStars.Name = "rbStars";
            this.rbStars.Rate = 0F;
            this.rbStars.Size = new System.Drawing.Size(85, 23);
            this.rbStars.TabIndex = 18;
            this.rbStars.Text = "ratingBar1";
            // 
            // rbArtistStars
            // 
            this.rbArtistStars.BarBackColor = System.Drawing.Color.GhostWhite;
            this.rbArtistStars.Enabled = false;
            this.rbArtistStars.Gap = ((byte)(1));
            this.rbArtistStars.IconEmpty = ((System.Drawing.Image)(resources.GetObject("rbArtistStars.IconEmpty")));
            this.rbArtistStars.IconFull = ((System.Drawing.Image)(resources.GetObject("rbArtistStars.IconFull")));
            this.rbArtistStars.IconHalf = ((System.Drawing.Image)(resources.GetObject("rbArtistStars.IconHalf")));
            this.rbArtistStars.IconsCount = ((byte)(5));
            this.rbArtistStars.Location = new System.Drawing.Point(187, 160);
            this.rbArtistStars.Name = "rbArtistStars";
            this.rbArtistStars.Rate = 0F;
            this.rbArtistStars.Size = new System.Drawing.Size(85, 23);
            this.rbArtistStars.TabIndex = 21;
            this.rbArtistStars.Text = "ratingBar1";
            // 
            // TaggerTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.container);
            this.Name = "TaggerTab";
            this.Size = new System.Drawing.Size(292, 318);
            this.VisibleChanged += new System.EventHandler(this.TaggerTab_VisibleChanged);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).EndInit();
            this.pnlAdvanced.ResumeLayout(false);
            this.pnlAdvanced.PerformLayout();
            this.container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lblTitleTag;
        private System.Windows.Forms.TextBox tbArtist;
        private System.Windows.Forms.Label lblArtistTag;
        private System.Windows.Forms.TextBox tbAlbum;
        private System.Windows.Forms.Label lblAlbumTag;
        private System.Windows.Forms.TextBox tbGenre;
        private System.Windows.Forms.Label lblGenreTag;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.Label lblYearTag;
        private System.Windows.Forms.TextBox tbTrack;
        private System.Windows.Forms.Label lblTrackNTag;
        private System.Windows.Forms.TextBox tbDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Button btnPrevFromUserTab;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.TextBox tbCounter;
        private System.Windows.Forms.Label lblIsFavourite;
        private RatingBar rbStars;
        private System.Windows.Forms.PictureBox pbFavourite;
        private System.Windows.Forms.Panel pnlAdvanced;
        private System.Windows.Forms.Label lblAudioFormat;
        private System.Windows.Forms.Button btnPrevFromAdvancedTab;
        private System.Windows.Forms.Label lblBitRate;
        private System.Windows.Forms.TextBox tbBitRate;
        private System.Windows.Forms.Label lblSamplingRate;
        private System.Windows.Forms.TextBox tbAudioFormat;
        private System.Windows.Forms.TextBox tbSamplingRate;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.TextBox tbFileSize;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Label lblStandard;
        private RatingBar rbArtistStars;
        private System.Windows.Forms.Label lblArtistStars;
    }
}
