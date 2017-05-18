namespace Shauni.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsBtnEsc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnPlaylist = new System.Windows.Forms.ToolStripButton();
            this.tsBtnTagLyrics = new System.Windows.Forms.ToolStripButton();
            this.tsBtnTagEditor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.tsBtnStatistics = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLearning = new System.Windows.Forms.ToolStripButton();
            this.tsBtnChart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tssBtnDataSetting = new System.Windows.Forms.ToolStripSplitButton();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnAbout = new System.Windows.Forms.ToolStripButton();
            this.cmsAudioLBnoitem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fastSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.playerControl = new Shauni.UserControls.PlayerControl();
            this.cmsAudioLBitem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reccomandedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.fastSearchControl = new Shauni.UserControls.FastSearchControl();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.playlistTab = new Shauni.UserControls.PlaylistTab();
            this.chartTab = new Shauni.UserControls.ChartTab();
            this.taggerTab = new Shauni.UserControls.TaggerTab();
            this.lyricsTab = new Shauni.UserControls.LyricsTab();
            this.loadingCircle = new MRG.Controls.UI.LoadingCircle();
            this.mediaPanel = new Shauni.UserControls.MediaPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.audioListBox = new Shauni.UserControls.AudioListBox();
            this.imageListBox = new Shauni.UserControls.ImageListBox();
            this.panelChangeList = new System.Windows.Forms.Panel();
            this.changeListPanel1 = new Shauni.UserControls.ChangeListPanel();
            this.mediaInfo = new Shauni.UserControls.MediaInfo();
            this.mainToolStrip.SuspendLayout();
            this.cmsAudioLBnoitem.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.cmsAudioLBitem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.mediaPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelChangeList.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.BackColor = System.Drawing.Color.White;
            this.mainToolStrip.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnEsc,
            this.toolStripSeparator1,
            this.tsBtnPlaylist,
            this.tsBtnTagLyrics,
            this.tsBtnTagEditor,
            this.toolStripSeparator2,
            this.toolStripSplitButton1,
            this.tsBtnStatistics,
            this.tsBtnLearning,
            this.tsBtnChart,
            this.toolStripSeparator3,
            this.tssBtnDataSetting,
            this.tsBtnAbout});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(606, 25);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // tsBtnEsc
            // 
            this.tsBtnEsc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnEsc.Image = global::Shauni.Properties.Resources.Esc;
            this.tsBtnEsc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEsc.Margin = new System.Windows.Forms.Padding(13, 1, 0, 2);
            this.tsBtnEsc.Name = "tsBtnEsc";
            this.tsBtnEsc.Size = new System.Drawing.Size(23, 22);
            this.tsBtnEsc.Text = "Quit";
            this.tsBtnEsc.ToolTipText = "Quit";
            this.tsBtnEsc.Click += new System.EventHandler(this.tsBtnEsc_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnPlaylist
            // 
            this.tsBtnPlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPlaylist.Font = new System.Drawing.Font("Miramonte", 9F);
            this.tsBtnPlaylist.Image = global::Shauni.Properties.Resources.MailArr;
            this.tsBtnPlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPlaylist.Name = "tsBtnPlaylist";
            this.tsBtnPlaylist.Size = new System.Drawing.Size(23, 22);
            this.tsBtnPlaylist.Text = "Playlist";
            this.tsBtnPlaylist.Click += new System.EventHandler(this.tsBtnPlaylist_Click);
            // 
            // tsBtnTagLyrics
            // 
            this.tsBtnTagLyrics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnTagLyrics.Image = global::Shauni.Properties.Resources.Lyric;
            this.tsBtnTagLyrics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnTagLyrics.Name = "tsBtnTagLyrics";
            this.tsBtnTagLyrics.Size = new System.Drawing.Size(23, 22);
            this.tsBtnTagLyrics.Text = "Show Lyric";
            this.tsBtnTagLyrics.Click += new System.EventHandler(this.tsBtnTagLyrics_Click);
            // 
            // tsBtnTagEditor
            // 
            this.tsBtnTagEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnTagEditor.Image = global::Shauni.Properties.Resources.Settings;
            this.tsBtnTagEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnTagEditor.Name = "tsBtnTagEditor";
            this.tsBtnTagEditor.Size = new System.Drawing.Size(23, 22);
            this.tsBtnTagEditor.Text = "Tag Editor";
            this.tsBtnTagEditor.Click += new System.EventHandler(this.tsBtnTagEditor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Enabled = false;
            this.toolStripSplitButton1.Image = global::Shauni.Properties.Resources.Networkoff;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "Others";
            // 
            // tsBtnStatistics
            // 
            this.tsBtnStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnStatistics.Enabled = false;
            this.tsBtnStatistics.Image = global::Shauni.Properties.Resources.Database;
            this.tsBtnStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStatistics.Name = "tsBtnStatistics";
            this.tsBtnStatistics.Size = new System.Drawing.Size(23, 22);
            this.tsBtnStatistics.Text = "Statistics";
            // 
            // tsBtnLearning
            // 
            this.tsBtnLearning.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnLearning.Image = global::Shauni.Properties.Resources.share;
            this.tsBtnLearning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLearning.Name = "tsBtnLearning";
            this.tsBtnLearning.Size = new System.Drawing.Size(23, 22);
            this.tsBtnLearning.Text = "Learning";
            this.tsBtnLearning.Click += new System.EventHandler(this.tsBtnLearning_Click);
            // 
            // tsBtnChart
            // 
            this.tsBtnChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnChart.Image = global::Shauni.Properties.Resources.Statistics;
            this.tsBtnChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnChart.Name = "tsBtnChart";
            this.tsBtnChart.Size = new System.Drawing.Size(23, 22);
            this.tsBtnChart.Text = "Chart";
            this.tsBtnChart.Click += new System.EventHandler(this.tsBtnChart_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tssBtnDataSetting
            // 
            this.tssBtnDataSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssBtnDataSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.selectLanguageToolStripMenuItem});
            this.tssBtnDataSetting.Image = global::Shauni.Properties.Resources.MyMusic;
            this.tssBtnDataSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssBtnDataSetting.Name = "tssBtnDataSetting";
            this.tssBtnDataSetting.Size = new System.Drawing.Size(32, 22);
            this.tssBtnDataSetting.Text = "Data & Settings";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Font = new System.Drawing.Font("Miramonte", 9F);
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.toolsToolStripMenuItem.Image = global::Shauni.Properties.Resources.tools;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.statisticsToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Font = new System.Drawing.Font("Miramonte", 9F);
            this.configurationToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.configurationToolStripMenuItem.Image = global::Shauni.Properties.Resources.Configuration;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Font = new System.Drawing.Font("Miramonte", 9F);
            this.searchToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.searchToolStripMenuItem.Image = global::Shauni.Properties.Resources.Search;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.searchToolStripMenuItem.Text = "Advanced search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // selectLanguageToolStripMenuItem
            // 
            this.selectLanguageToolStripMenuItem.Font = new System.Drawing.Font("Miramonte", 9F);
            this.selectLanguageToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.selectLanguageToolStripMenuItem.Image = global::Shauni.Properties.Resources.flag;
            this.selectLanguageToolStripMenuItem.Name = "selectLanguageToolStripMenuItem";
            this.selectLanguageToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.selectLanguageToolStripMenuItem.Text = "Select language";
            this.selectLanguageToolStripMenuItem.Click += new System.EventHandler(this.selectLanguageToolStripMenuItem_Click);
            // 
            // tsBtnAbout
            // 
            this.tsBtnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAbout.Image = global::Shauni.Properties.Resources.Home16;
            this.tsBtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAbout.Name = "tsBtnAbout";
            this.tsBtnAbout.Size = new System.Drawing.Size(23, 22);
            this.tsBtnAbout.Text = "About";
            this.tsBtnAbout.Click += new System.EventHandler(this.tsBtnAbout_Click);
            // 
            // cmsAudioLBnoitem
            // 
            this.cmsAudioLBnoitem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fastSearchToolStripMenuItem});
            this.cmsAudioLBnoitem.Name = "cmsMediaListBox";
            this.cmsAudioLBnoitem.Size = new System.Drawing.Size(152, 26);
            // 
            // fastSearchToolStripMenuItem
            // 
            this.fastSearchToolStripMenuItem.Name = "fastSearchToolStripMenuItem";
            this.fastSearchToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.fastSearchToolStripMenuItem.Text = "Quick search...";
            this.fastSearchToolStripMenuItem.Click += new System.EventHandler(this.fastSearchToolStripMenuItem_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.AliceBlue;
            this.panelTop.Controls.Add(this.mainToolStrip);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(606, 25);
            this.panelTop.TabIndex = 12;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.playerControl);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 364);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(606, 68);
            this.panelBottom.TabIndex = 13;
            // 
            // playerControl
            // 
            this.playerControl.BackColor = System.Drawing.Color.Black;
            this.playerControl.BackgroundImage = global::Shauni.Properties.Resources.PanelResizable;
            this.playerControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playerControl.Location = new System.Drawing.Point(0, 1);
            this.playerControl.LoopEnabled = false;
            this.playerControl.MaximumSize = new System.Drawing.Size(1920, 67);
            this.playerControl.MinimumSize = new System.Drawing.Size(563, 67);
            this.playerControl.Name = "playerControl";
            this.playerControl.PercentageToCount = 0;
            this.playerControl.Size = new System.Drawing.Size(606, 67);
            this.playerControl.TabIndex = 0;
            this.playerControl.FileBrowsed += new System.EventHandler<Shauni.UserControls.FileBrowsedEventArgs>(this.playerControl_FileBrowsed);
            this.playerControl.MediaPlayingEnded += new System.EventHandler<Shauni.UserControls.MediaPlayingEndedEventArgs>(this.playerControl_MediaPlayingEnded);
            // 
            // cmsAudioLBitem
            // 
            this.cmsAudioLBitem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileLocationToolStripMenuItem,
            this.reccomandedToolStripMenuItem});
            this.cmsAudioLBitem.Name = "cmsAudioLBitem";
            this.cmsAudioLBitem.Size = new System.Drawing.Size(178, 48);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.openFileLocationToolStripMenuItem.Text = "Open file location...";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // reccomandedToolStripMenuItem
            // 
            this.reccomandedToolStripMenuItem.Image = global::Shauni.Properties.Resources.Learning;
            this.reccomandedToolStripMenuItem.Name = "reccomandedToolStripMenuItem";
            this.reccomandedToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.reccomandedToolStripMenuItem.Text = "Recommended";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.BackgroundImage = global::Shauni.Properties.Resources.BordRight;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(596, 25);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(10, 339);
            this.panelRight.TabIndex = 4;
            // 
            // panelLeft
            // 
            this.panelLeft.BackgroundImage = global::Shauni.Properties.Resources.BordLeft;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 25);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(10, 339);
            this.panelLeft.TabIndex = 2;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(10, 25);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.splitContainer.Panel1.Controls.Add(this.fastSearchControl);
            this.splitContainer.Panel1.Controls.Add(this.mainPictureBox);
            this.splitContainer.Panel1.Controls.Add(this.playlistTab);
            this.splitContainer.Panel1.Controls.Add(this.chartTab);
            this.splitContainer.Panel1.Controls.Add(this.taggerTab);
            this.splitContainer.Panel1.Controls.Add(this.lyricsTab);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(6, 10, 6, 10);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.GhostWhite;
            this.splitContainer.Panel2.Controls.Add(this.loadingCircle);
            this.splitContainer.Panel2.Controls.Add(this.mediaPanel);
            this.splitContainer.Panel2.Controls.Add(this.panelChangeList);
            this.splitContainer.Panel2.Controls.Add(this.mediaInfo);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.splitContainer.Size = new System.Drawing.Size(586, 339);
            this.splitContainer.SplitterDistance = 293;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 11;
            // 
            // fastSearchControl
            // 
            this.fastSearchControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fastSearchControl.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastSearchControl.Location = new System.Drawing.Point(6, 308);
            this.fastSearchControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastSearchControl.Name = "fastSearchControl";
            this.fastSearchControl.Size = new System.Drawing.Size(281, 21);
            this.fastSearchControl.TabIndex = 6;
            this.fastSearchControl.Visible = false;
            this.fastSearchControl.FileSearched += new System.EventHandler<Shauni.UserControls.MediaSearchedEventArgs>(this.fastSearchControl_FileSearched);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.Color.GhostWhite;
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Image = global::Shauni.Properties.Resources.ShauniLogo;
            this.mainPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mainPictureBox.Location = new System.Drawing.Point(6, 10);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(281, 319);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mainPictureBox.TabIndex = 1;
            this.mainPictureBox.TabStop = false;
            // 
            // playlistTab
            // 
            this.playlistTab.BackColor = System.Drawing.Color.GhostWhite;
            this.playlistTab.CurrentPlaylist = null;
            this.playlistTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistTab.Location = new System.Drawing.Point(6, 10);
            this.playlistTab.Name = "playlistTab";
            this.playlistTab.SaveButtonEnabled = false;
            this.playlistTab.Size = new System.Drawing.Size(281, 319);
            this.playlistTab.TabIndex = 0;
            this.playlistTab.Visible = false;
            this.playlistTab.PlaylistSelected += new System.EventHandler<Shauni.UserControls.PlaylistSelectedEventArgs>(this.playlistTab_TreeViewItemClicked);
            this.playlistTab.PlaylistImported += new System.EventHandler<Shauni.UserControls.PlaylistImportedEventArgs>(this.playlistTab_PlaylistImported);
            this.playlistTab.PlaylistMediaLoaded += new System.EventHandler<Shauni.UserControls.PlaylistMediaLoadedEventArgs>(this.playlistTab_PlaylistMediaLoaded);
            this.playlistTab.PlaylistNodeSelected += new System.EventHandler(this.playlistTab_PlaylistNodeSelected);
            this.playlistTab.AllowDropChanged += new System.EventHandler<Shauni.UserControls.AllowDropChangedEventArgs>(this.playlistTab_AllowDropChanged);
            // 
            // chartTab
            // 
            this.chartTab.BackColor = System.Drawing.Color.GhostWhite;
            this.chartTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTab.Location = new System.Drawing.Point(6, 10);
            this.chartTab.Name = "chartTab";
            this.chartTab.Size = new System.Drawing.Size(281, 319);
            this.chartTab.TabIndex = 2;
            this.chartTab.Visible = false;
            // 
            // taggerTab
            // 
            this.taggerTab.BackColor = System.Drawing.Color.GhostWhite;
            this.taggerTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taggerTab.Location = new System.Drawing.Point(6, 10);
            this.taggerTab.Name = "taggerTab";
            this.taggerTab.Size = new System.Drawing.Size(281, 319);
            this.taggerTab.TabIndex = 3;
            this.taggerTab.Visible = false;
            this.taggerTab.MediaLoaded += new System.EventHandler<Shauni.UserControls.MediaTagsLoadedEventArgs>(this.taggerTab_MediaLoaded);
            // 
            // lyricsTab
            // 
            this.lyricsTab.AutoScroll = true;
            this.lyricsTab.BackColor = System.Drawing.Color.White;
            this.lyricsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lyricsTab.Location = new System.Drawing.Point(6, 10);
            this.lyricsTab.Name = "lyricsTab";
            this.lyricsTab.Size = new System.Drawing.Size(281, 319);
            this.lyricsTab.TabIndex = 7;
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = false;
            this.loadingCircle.BackColor = System.Drawing.Color.Transparent;
            this.loadingCircle.Color = System.Drawing.Color.DodgerBlue;
            this.loadingCircle.InnerCircleRadius = 8;
            this.loadingCircle.Location = new System.Drawing.Point(16, 65);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 24;
            this.loadingCircle.OuterCircleRadius = 9;
            this.loadingCircle.RotationSpeed = 60;
            this.loadingCircle.Size = new System.Drawing.Size(75, 23);
            this.loadingCircle.SpokeThickness = 4;
            this.loadingCircle.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.IE7;
            this.loadingCircle.TabIndex = 7;
            this.loadingCircle.Visible = false;
            // 
            // mediaPanel
            // 
            this.mediaPanel.BackColor = System.Drawing.Color.White;
            this.mediaPanel.BorderColor = System.Drawing.Color.Silver;
            this.mediaPanel.BorderWidth = 1;
            this.mediaPanel.Controls.Add(this.panel1);
            this.mediaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPanel.GradientEndColor = System.Drawing.Color.GhostWhite;
            this.mediaPanel.GradientStartColor = System.Drawing.Color.AliceBlue;
            this.mediaPanel.Image = null;
            this.mediaPanel.ImageLocation = new System.Drawing.Point(4, 4);
            this.mediaPanel.Location = new System.Drawing.Point(5, 124);
            this.mediaPanel.Name = "mediaPanel";
            this.mediaPanel.Padding = new System.Windows.Forms.Padding(6, 6, 10, 6);
            this.mediaPanel.RoundCornerRadius = 6;
            this.mediaPanel.ShadowOffSet = 4;
            this.mediaPanel.Size = new System.Drawing.Size(286, 215);
            this.mediaPanel.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.audioListBox);
            this.panel1.Controls.Add(this.imageListBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 203);
            this.panel1.TabIndex = 7;
            // 
            // audioListBox
            // 
            this.audioListBox.AllowDrop = true;
            this.audioListBox.BackColor = System.Drawing.Color.GhostWhite;
            this.audioListBox.BackColorCheckedGradientEnd = System.Drawing.Color.AliceBlue;
            this.audioListBox.BackColorCheckedGradientStart = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.audioListBox.BackColorGradientEnd = System.Drawing.Color.GhostWhite;
            this.audioListBox.BackColorGradientStart = System.Drawing.Color.AliceBlue;
            this.audioListBox.BorderCheckedColor = System.Drawing.Color.GhostWhite;
            this.audioListBox.BorderColor = System.Drawing.Color.Gainsboro;
            this.audioListBox.BorderRoundedAngle = 9;
            this.audioListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.audioListBox.BorderType = Shauni.UserControls.ShauniListBox.BorderTypes.Rounded;
            this.audioListBox.DisplayMember = "Name";
            this.audioListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.audioListBox.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioListBox.ForeColor = System.Drawing.Color.MidnightBlue;
            this.audioListBox.FormattingEnabled = true;
            this.audioListBox.IconPadding = new System.Drawing.Point(6, 2);
            this.audioListBox.ItemHeight = 22;
            this.audioListBox.Location = new System.Drawing.Point(0, 0);
            this.audioListBox.Name = "audioListBox";
            this.audioListBox.Size = new System.Drawing.Size(270, 203);
            this.audioListBox.TabIndex = 5;
            this.audioListBox.ValueMember = "Name";
            this.audioListBox.FileDragged += new System.EventHandler<Shauni.UserControls.FileDraggedEventArgs>(this.audioListBox_FileDragged);
            this.audioListBox.ItemClicked += new System.EventHandler<Shauni.UserControls.ItemClickedEventArgs>(this.audioListBox_ItemClicked);
            this.audioListBox.ItemDoubleClicked += new System.EventHandler<Shauni.UserControls.ItemDoubleClickedEventArgs>(this.audioListBox_ItemDoubleClicked);
            this.audioListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.audioListBox_DragEnter);
            this.audioListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.audioListBox_KeyDown);
            // 
            // imageListBox
            // 
            this.imageListBox.AllowDrop = true;
            this.imageListBox.BackColor = System.Drawing.Color.GhostWhite;
            this.imageListBox.BackColorCheckedGradientEnd = System.Drawing.Color.AliceBlue;
            this.imageListBox.BackColorCheckedGradientStart = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.imageListBox.BackColorGradientEnd = System.Drawing.Color.GhostWhite;
            this.imageListBox.BackColorGradientStart = System.Drawing.Color.AliceBlue;
            this.imageListBox.BorderCheckedColor = System.Drawing.Color.GhostWhite;
            this.imageListBox.BorderColor = System.Drawing.Color.Gainsboro;
            this.imageListBox.BorderRoundedAngle = 9;
            this.imageListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imageListBox.BorderType = Shauni.UserControls.ShauniListBox.BorderTypes.Rounded;
            this.imageListBox.DisplayMember = "Name";
            this.imageListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imageListBox.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageListBox.ForeColor = System.Drawing.Color.MidnightBlue;
            this.imageListBox.FormattingEnabled = true;
            this.imageListBox.IconPadding = new System.Drawing.Point(5, 3);
            this.imageListBox.ItemHeight = 24;
            this.imageListBox.Location = new System.Drawing.Point(0, 0);
            this.imageListBox.Name = "imageListBox";
            this.imageListBox.Size = new System.Drawing.Size(270, 203);
            this.imageListBox.TabIndex = 6;
            this.imageListBox.ValueMember = "Name";
            this.imageListBox.FileDragged += new System.EventHandler<Shauni.UserControls.FileDraggedEventArgs>(this.imageListBox_FileDragged);
            this.imageListBox.ItemClicked += new System.EventHandler<Shauni.UserControls.ItemClickedEventArgs>(this.imageListBox_ItemClicked);
            this.imageListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.imageListBox_DragEnter);
            this.imageListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imageListBox_KeyDown);
            // 
            // panelChangeList
            // 
            this.panelChangeList.BackColor = System.Drawing.Color.LightGreen;
            this.panelChangeList.Controls.Add(this.changeListPanel1);
            this.panelChangeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelChangeList.Location = new System.Drawing.Point(5, 103);
            this.panelChangeList.Name = "panelChangeList";
            this.panelChangeList.Size = new System.Drawing.Size(286, 21);
            this.panelChangeList.TabIndex = 10;
            // 
            // changeListPanel1
            // 
            this.changeListPanel1.BackColor = System.Drawing.Color.GhostWhite;
            this.changeListPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changeListPanel1.ForeColor = System.Drawing.Color.Black;
            this.changeListPanel1.Location = new System.Drawing.Point(0, 0);
            this.changeListPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.changeListPanel1.Name = "changeListPanel1";
            this.changeListPanel1.Size = new System.Drawing.Size(286, 21);
            this.changeListPanel1.TabIndex = 10;
            this.changeListPanel1.ListChanged += new System.EventHandler<Shauni.UserControls.ListChangedEventArgs>(this.changeListPanel_ListChanged);
            // 
            // mediaInfo
            // 
            this.mediaInfo.BackColor = System.Drawing.Color.Transparent;
            this.mediaInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.mediaInfo.FavouriteRate = false;
            this.mediaInfo.ForeColor = System.Drawing.Color.DimGray;
            this.mediaInfo.Location = new System.Drawing.Point(5, 0);
            this.mediaInfo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.mediaInfo.Name = "mediaInfo";
            this.mediaInfo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.mediaInfo.Size = new System.Drawing.Size(286, 103);
            this.mediaInfo.StarsRate = 0F;
            this.mediaInfo.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(606, 432);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1763, 1763);
            this.MinimumSize = new System.Drawing.Size(622, 470);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shauni";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.cmsAudioLBnoitem.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.cmsAudioLBitem.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.mediaPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelChangeList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.PlayerControl playerControl;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton tsBtnEsc;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private UserControls.AudioListBox audioListBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnPlaylist;
        private System.Windows.Forms.ToolStripButton tsBtnTagLyrics;
        private System.Windows.Forms.ToolStripButton tsBtnTagEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnAbout;
        private UserControls.MediaInfo mediaInfo;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripButton tsBtnStatistics;
        private System.Windows.Forms.ToolStripButton tsBtnLearning;
        private System.Windows.Forms.ToolStripButton tsBtnChart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton tssBtnDataSetting;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private UserControls.MediaPanel mediaPanel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private UserControls.PlaylistTab playlistTab;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private UserControls.ChartTab chartTab;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsAudioLBnoitem;
        private System.Windows.Forms.ToolStripMenuItem fastSearchToolStripMenuItem;
        private UserControls.FastSearchControl fastSearchControl;
        private System.Windows.Forms.ToolStripMenuItem selectLanguageToolStripMenuItem;
        private UserControls.TaggerTab taggerTab;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private UserControls.ImageListBox imageListBox;
        private System.Windows.Forms.Panel panel1;
        private UserControls.ChangeListPanel changeListPanel1;
        private System.Windows.Forms.Panel panelChangeList;
        private System.Windows.Forms.ContextMenuStrip cmsAudioLBitem;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reccomandedToolStripMenuItem;
        private MRG.Controls.UI.LoadingCircle loadingCircle;
        private UserControls.LyricsTab lyricsTab;
    }
}

