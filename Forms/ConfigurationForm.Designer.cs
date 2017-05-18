namespace Shauni.Forms
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Basics");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Plugins");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Learning");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Network");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Logging");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Settings", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cmsPlugins = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipLangDetection = new System.Windows.Forms.ToolTip(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelNetwork = new System.Windows.Forms.Panel();
            this.cbArtistImage = new System.Windows.Forms.CheckBox();
            this.paragraphe4 = new Shauni.UserControls.Paragraphe();
            this.label8 = new System.Windows.Forms.Label();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.chBoxEnableLogger = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chEnableScrobbling = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFolderProcessorDefDir = new System.Windows.Forms.TextBox();
            this.chBoxEnableAutoLangDetection = new System.Windows.Forms.CheckBox();
            this.chBoxRestartLanguage = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlaylistSaveAs = new System.Windows.Forms.Label();
            this.cbPlaylistSaveAs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.paragraphe3 = new Shauni.UserControls.Paragraphe();
            this.panelExtensions = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.chBoxEnablePlugin = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.paragraphe2 = new Shauni.UserControls.Paragraphe();
            this.label11 = new System.Windows.Forms.Label();
            this.listViewPlugin = new System.Windows.Forms.ListView();
            this.cHLogo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelLearning = new System.Windows.Forms.Panel();
            this.loadingCircle = new Shauni.UserControls.LoadingCircle();
            this.paragraphe1 = new Shauni.UserControls.Paragraphe();
            this.label6 = new System.Windows.Forms.Label();
            this.chBoxAutoSearchParams = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbLearningType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chLearningAudio = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSearchParams = new System.Windows.Forms.TextBox();
            this.treeWiewSettings = new System.Windows.Forms.TreeView();
            this.panelLogging = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.paragraphe5 = new Shauni.UserControls.Paragraphe();
            this.label14 = new System.Windows.Forms.Label();
            this.cmsPlugins.SuspendLayout();
            this.panelNetwork.SuspendLayout();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.panelExtensions.SuspendLayout();
            this.panelLearning.SuspendLayout();
            this.panelLogging.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmsPlugins
            // 
            this.cmsPlugins.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem});
            this.cmsPlugins.Name = "cmsPlugins";
            this.cmsPlugins.Size = new System.Drawing.Size(102, 26);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.runToolStripMenuItem.Text = "Run..";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // toolTipLangDetection
            // 
            this.toolTipLangDetection.BackColor = System.Drawing.Color.White;
            this.toolTipLangDetection.ForeColor = System.Drawing.Color.Black;
            this.toolTipLangDetection.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipLangDetection.ToolTipTitle = "Info";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panelNetwork
            // 
            this.panelNetwork.Controls.Add(this.cbArtistImage);
            this.panelNetwork.Controls.Add(this.paragraphe4);
            this.panelNetwork.Controls.Add(this.label8);
            this.panelNetwork.Location = new System.Drawing.Point(408, 460);
            this.panelNetwork.Name = "panelNetwork";
            this.panelNetwork.Size = new System.Drawing.Size(137, 84);
            this.panelNetwork.TabIndex = 25;
            this.panelNetwork.Visible = false;
            // 
            // cbArtistImage
            // 
            this.cbArtistImage.AutoSize = true;
            this.cbArtistImage.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbArtistImage.ForeColor = System.Drawing.Color.DimGray;
            this.cbArtistImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbArtistImage.Location = new System.Drawing.Point(80, 118);
            this.cbArtistImage.Name = "cbArtistImage";
            this.cbArtistImage.Size = new System.Drawing.Size(235, 23);
            this.cbArtistImage.TabIndex = 12;
            this.cbArtistImage.Text = "  Get artist image from Last.fm";
            this.cbArtistImage.UseVisualStyleBackColor = true;
            // 
            // paragraphe4
            // 
            this.paragraphe4.BackColor = System.Drawing.Color.White;
            this.paragraphe4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("paragraphe4.BackgroundImage")));
            this.paragraphe4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.paragraphe4.Location = new System.Drawing.Point(6, 12);
            this.paragraphe4.MaximumSize = new System.Drawing.Size(0, 47);
            this.paragraphe4.MinimumSize = new System.Drawing.Size(479, 54);
            this.paragraphe4.Name = "paragraphe4";
            this.paragraphe4.Size = new System.Drawing.Size(479, 54);
            this.paragraphe4.TabIndex = 0;
            this.paragraphe4.TextColor = System.Drawing.Color.Navy;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(62, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 24);
            this.label8.TabIndex = 21;
            this.label8.Text = "System";
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.chBoxEnableLogger);
            this.panelSettings.Controls.Add(this.label15);
            this.panelSettings.Controls.Add(this.numericUpDown);
            this.panelSettings.Controls.Add(this.label12);
            this.panelSettings.Controls.Add(this.label13);
            this.panelSettings.Controls.Add(this.chEnableScrobbling);
            this.panelSettings.Controls.Add(this.label2);
            this.panelSettings.Controls.Add(this.tbFolderProcessorDefDir);
            this.panelSettings.Controls.Add(this.chBoxEnableAutoLangDetection);
            this.panelSettings.Controls.Add(this.chBoxRestartLanguage);
            this.panelSettings.Controls.Add(this.label5);
            this.panelSettings.Controls.Add(this.label1);
            this.panelSettings.Controls.Add(this.lblPlaylistSaveAs);
            this.panelSettings.Controls.Add(this.cbPlaylistSaveAs);
            this.panelSettings.Controls.Add(this.label3);
            this.panelSettings.Controls.Add(this.paragraphe3);
            this.panelSettings.Location = new System.Drawing.Point(179, 13);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(140, 51);
            this.panelSettings.TabIndex = 24;
            this.panelSettings.Visible = false;
            // 
            // chBoxEnableLogger
            // 
            this.chBoxEnableLogger.AutoSize = true;
            this.chBoxEnableLogger.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxEnableLogger.ForeColor = System.Drawing.Color.DimGray;
            this.chBoxEnableLogger.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chBoxEnableLogger.Location = new System.Drawing.Point(91, 508);
            this.chBoxEnableLogger.Name = "chBoxEnableLogger";
            this.chBoxEnableLogger.Size = new System.Drawing.Size(83, 23);
            this.chBoxEnableLogger.TabIndex = 4;
            this.chBoxEnableLogger.Text = "  Enable";
            this.chBoxEnableLogger.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(87, 431);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 19);
            this.label15.TabIndex = 30;
            this.label15.Text = "Time to (%):";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown.ForeColor = System.Drawing.Color.DimGray;
            this.numericUpDown.Location = new System.Drawing.Point(239, 430);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(173, 27);
            this.numericUpDown.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(63, 472);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 24);
            this.label12.TabIndex = 29;
            this.label12.Text = "Logger";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(63, 361);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 24);
            this.label13.TabIndex = 28;
            this.label13.Text = "Scrobbling";
            // 
            // chEnableScrobbling
            // 
            this.chEnableScrobbling.AutoSize = true;
            this.chEnableScrobbling.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chEnableScrobbling.ForeColor = System.Drawing.Color.DimGray;
            this.chEnableScrobbling.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chEnableScrobbling.Location = new System.Drawing.Point(91, 397);
            this.chEnableScrobbling.Name = "chEnableScrobbling";
            this.chEnableScrobbling.Size = new System.Drawing.Size(83, 23);
            this.chEnableScrobbling.TabIndex = 4;
            this.chEnableScrobbling.Text = "  Enable";
            this.chEnableScrobbling.UseVisualStyleBackColor = true;
            this.chEnableScrobbling.CheckedChanged += new System.EventHandler(this.chEnableScrobbling_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(63, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Folder processor";
            // 
            // tbFolderProcessorDefDir
            // 
            this.tbFolderProcessorDefDir.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFolderProcessorDefDir.ForeColor = System.Drawing.Color.DimGray;
            this.tbFolderProcessorDefDir.Location = new System.Drawing.Point(239, 320);
            this.tbFolderProcessorDefDir.Name = "tbFolderProcessorDefDir";
            this.tbFolderProcessorDefDir.Size = new System.Drawing.Size(173, 27);
            this.tbFolderProcessorDefDir.TabIndex = 10;
            this.tbFolderProcessorDefDir.Click += new System.EventHandler(this.tbFolderProcessorDefDir_Click);
            // 
            // chBoxEnableAutoLangDetection
            // 
            this.chBoxEnableAutoLangDetection.AutoSize = true;
            this.chBoxEnableAutoLangDetection.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxEnableAutoLangDetection.ForeColor = System.Drawing.Color.DimGray;
            this.chBoxEnableAutoLangDetection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chBoxEnableAutoLangDetection.Location = new System.Drawing.Point(90, 236);
            this.chBoxEnableAutoLangDetection.Name = "chBoxEnableAutoLangDetection";
            this.chBoxEnableAutoLangDetection.Size = new System.Drawing.Size(257, 23);
            this.chBoxEnableAutoLangDetection.TabIndex = 10;
            this.chBoxEnableAutoLangDetection.Text = "  Enable auto language detection";
            this.chBoxEnableAutoLangDetection.UseVisualStyleBackColor = true;
            this.chBoxEnableAutoLangDetection.CheckedChanged += new System.EventHandler(this.chBoxEnableAutoLangDetection_CheckedChanged);
            // 
            // chBoxRestartLanguage
            // 
            this.chBoxRestartLanguage.AutoSize = true;
            this.chBoxRestartLanguage.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxRestartLanguage.ForeColor = System.Drawing.Color.DimGray;
            this.chBoxRestartLanguage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chBoxRestartLanguage.Location = new System.Drawing.Point(90, 205);
            this.chBoxRestartLanguage.Name = "chBoxRestartLanguage";
            this.chBoxRestartLanguage.Size = new System.Drawing.Size(258, 23);
            this.chBoxRestartLanguage.TabIndex = 12;
            this.chBoxRestartLanguage.Text = "  Restart after changing language";
            this.chBoxRestartLanguage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(63, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "Language";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(87, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Default directory:";
            // 
            // lblPlaylistSaveAs
            // 
            this.lblPlaylistSaveAs.AutoSize = true;
            this.lblPlaylistSaveAs.Font = new System.Drawing.Font("Miramonte", 12F);
            this.lblPlaylistSaveAs.ForeColor = System.Drawing.Color.DimGray;
            this.lblPlaylistSaveAs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPlaylistSaveAs.Location = new System.Drawing.Point(86, 119);
            this.lblPlaylistSaveAs.Name = "lblPlaylistSaveAs";
            this.lblPlaylistSaveAs.Size = new System.Drawing.Size(65, 19);
            this.lblPlaylistSaveAs.TabIndex = 6;
            this.lblPlaylistSaveAs.Text = "Save As:";
            // 
            // cbPlaylistSaveAs
            // 
            this.cbPlaylistSaveAs.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlaylistSaveAs.FormattingEnabled = true;
            this.cbPlaylistSaveAs.Items.AddRange(new object[] {
            "WPL",
            "M3U",
            "TXT"});
            this.cbPlaylistSaveAs.Location = new System.Drawing.Point(239, 115);
            this.cbPlaylistSaveAs.Name = "cbPlaylistSaveAs";
            this.cbPlaylistSaveAs.Size = new System.Drawing.Size(173, 27);
            this.cbPlaylistSaveAs.TabIndex = 5;
            this.cbPlaylistSaveAs.SelectedIndexChanged += new System.EventHandler(this.cbPlaylistSaveAs_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(63, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "Playlist";
            // 
            // paragraphe3
            // 
            this.paragraphe3.BackColor = System.Drawing.Color.White;
            this.paragraphe3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("paragraphe3.BackgroundImage")));
            this.paragraphe3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.paragraphe3.Location = new System.Drawing.Point(6, 12);
            this.paragraphe3.MaximumSize = new System.Drawing.Size(0, 59);
            this.paragraphe3.MinimumSize = new System.Drawing.Size(479, 54);
            this.paragraphe3.Name = "paragraphe3";
            this.paragraphe3.Size = new System.Drawing.Size(479, 59);
            this.paragraphe3.TabIndex = 0;
            this.paragraphe3.TextColor = System.Drawing.Color.Navy;
            // 
            // panelExtensions
            // 
            this.panelExtensions.Controls.Add(this.label7);
            this.panelExtensions.Controls.Add(this.chBoxEnablePlugin);
            this.panelExtensions.Controls.Add(this.btnUpdate);
            this.panelExtensions.Controls.Add(this.paragraphe2);
            this.panelExtensions.Controls.Add(this.label11);
            this.panelExtensions.Controls.Add(this.listViewPlugin);
            this.panelExtensions.Location = new System.Drawing.Point(403, 361);
            this.panelExtensions.Name = "panelExtensions";
            this.panelExtensions.Size = new System.Drawing.Size(89, 55);
            this.panelExtensions.TabIndex = 23;
            this.panelExtensions.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(63, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 24);
            this.label7.TabIndex = 23;
            this.label7.Text = "System";
            // 
            // chBoxEnablePlugin
            // 
            this.chBoxEnablePlugin.AutoSize = true;
            this.chBoxEnablePlugin.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxEnablePlugin.ForeColor = System.Drawing.Color.DimGray;
            this.chBoxEnablePlugin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chBoxEnablePlugin.Location = new System.Drawing.Point(90, 118);
            this.chBoxEnablePlugin.Name = "chBoxEnablePlugin";
            this.chBoxEnablePlugin.Size = new System.Drawing.Size(180, 23);
            this.chBoxEnablePlugin.TabIndex = 4;
            this.chBoxEnablePlugin.Text = "  Enable plugin system";
            this.chBoxEnablePlugin.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.DimGray;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(646, 469);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(77, 31);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Refresh";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // paragraphe2
            // 
            this.paragraphe2.BackColor = System.Drawing.Color.White;
            this.paragraphe2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("paragraphe2.BackgroundImage")));
            this.paragraphe2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.paragraphe2.Location = new System.Drawing.Point(6, 12);
            this.paragraphe2.MaximumSize = new System.Drawing.Size(0, 54);
            this.paragraphe2.MinimumSize = new System.Drawing.Size(479, 54);
            this.paragraphe2.Name = "paragraphe2";
            this.paragraphe2.Size = new System.Drawing.Size(479, 54);
            this.paragraphe2.TabIndex = 3;
            this.paragraphe2.TextColor = System.Drawing.Color.Navy;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(63, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 24);
            this.label11.TabIndex = 22;
            this.label11.Text = "List of all plugins";
            // 
            // listViewPlugin
            // 
            this.listViewPlugin.BackColor = System.Drawing.Color.White;
            this.listViewPlugin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cHLogo,
            this.cHName,
            this.cHVersion,
            this.cHDescription});
            this.listViewPlugin.Font = new System.Drawing.Font("Miramonte", 11.25F);
            this.listViewPlugin.ForeColor = System.Drawing.Color.DimGray;
            this.listViewPlugin.FullRowSelect = true;
            this.listViewPlugin.GridLines = true;
            this.listViewPlugin.Location = new System.Drawing.Point(90, 192);
            this.listViewPlugin.Name = "listViewPlugin";
            this.listViewPlugin.OwnerDraw = true;
            this.listViewPlugin.Size = new System.Drawing.Size(632, 260);
            this.listViewPlugin.TabIndex = 1;
            this.listViewPlugin.TileSize = new System.Drawing.Size(20, 20);
            this.listViewPlugin.UseCompatibleStateImageBehavior = false;
            this.listViewPlugin.View = System.Windows.Forms.View.Details;
            this.listViewPlugin.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewPlugin_DrawColumnHeader);
            this.listViewPlugin.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewPlugin_DrawItem);
            this.listViewPlugin.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listViewPlugin_DrawSubItem);
            this.listViewPlugin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewPlugin_MouseDown);
            // 
            // cHLogo
            // 
            this.cHLogo.Text = "Icon";
            this.cHLogo.Width = 42;
            // 
            // cHName
            // 
            this.cHName.Text = "Name";
            this.cHName.Width = 130;
            // 
            // cHVersion
            // 
            this.cHVersion.Text = "Version";
            this.cHVersion.Width = 65;
            // 
            // cHDescription
            // 
            this.cHDescription.Text = "Description";
            this.cHDescription.Width = 390;
            // 
            // panelLearning
            // 
            this.panelLearning.Controls.Add(this.loadingCircle);
            this.panelLearning.Controls.Add(this.paragraphe1);
            this.panelLearning.Controls.Add(this.label6);
            this.panelLearning.Controls.Add(this.chBoxAutoSearchParams);
            this.panelLearning.Controls.Add(this.label10);
            this.panelLearning.Controls.Add(this.cbLearningType);
            this.panelLearning.Controls.Add(this.label4);
            this.panelLearning.Controls.Add(this.chLearningAudio);
            this.panelLearning.Controls.Add(this.label9);
            this.panelLearning.Controls.Add(this.tbSearchParams);
            this.panelLearning.Location = new System.Drawing.Point(372, 15);
            this.panelLearning.Name = "panelLearning";
            this.panelLearning.Size = new System.Drawing.Size(473, 319);
            this.panelLearning.TabIndex = 1;
            this.panelLearning.Visible = false;
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = false;
            this.loadingCircle.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle.InnerCircleRadius = 11;
            this.loadingCircle.Location = new System.Drawing.Point(56, 407);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 45;
            this.loadingCircle.OuterCircleRadius = 10;
            this.loadingCircle.Size = new System.Drawing.Size(45, 27);
            this.loadingCircle.SpokeThickness = 2;
            this.loadingCircle.StylePreset = Shauni.UserControls.LoadingCircle.StylePresets.Shauni;
            this.loadingCircle.TabIndex = 27;
            this.loadingCircle.Text = "loadingCircle";
            this.loadingCircle.Visible = false;
            // 
            // paragraphe1
            // 
            this.paragraphe1.BackColor = System.Drawing.Color.White;
            this.paragraphe1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("paragraphe1.BackgroundImage")));
            this.paragraphe1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.paragraphe1.Location = new System.Drawing.Point(6, 12);
            this.paragraphe1.MaximumSize = new System.Drawing.Size(0, 47);
            this.paragraphe1.MinimumSize = new System.Drawing.Size(479, 54);
            this.paragraphe1.Name = "paragraphe1";
            this.paragraphe1.Size = new System.Drawing.Size(479, 54);
            this.paragraphe1.TabIndex = 0;
            this.paragraphe1.TextColor = System.Drawing.Color.Navy;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(62, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "System";
            // 
            // chBoxAutoSearchParams
            // 
            this.chBoxAutoSearchParams.AutoSize = true;
            this.chBoxAutoSearchParams.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxAutoSearchParams.ForeColor = System.Drawing.Color.DimGray;
            this.chBoxAutoSearchParams.Location = new System.Drawing.Point(80, 268);
            this.chBoxAutoSearchParams.Name = "chBoxAutoSearchParams";
            this.chBoxAutoSearchParams.Size = new System.Drawing.Size(266, 23);
            this.chBoxAutoSearchParams.TabIndex = 3;
            this.chBoxAutoSearchParams.Text = "  Defined by the system automatically";
            this.chBoxAutoSearchParams.UseVisualStyleBackColor = true;
            this.chBoxAutoSearchParams.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(77, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(200, 19);
            this.label10.TabIndex = 26;
            this.label10.Text = "Activate learning system on:";
            // 
            // cbLearningType
            // 
            this.cbLearningType.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLearningType.FormattingEnabled = true;
            this.cbLearningType.Items.AddRange(new object[] {
            "Naive Bayes",
            "Decision Tree"});
            this.cbLearningType.Location = new System.Drawing.Point(174, 178);
            this.cbLearningType.Name = "cbLearningType";
            this.cbLearningType.Size = new System.Drawing.Size(252, 27);
            this.cbLearningType.TabIndex = 22;
            this.cbLearningType.SelectedIndexChanged += new System.EventHandler(this.cbLearningType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(62, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Search parameters";
            // 
            // chLearningAudio
            // 
            this.chLearningAudio.AutoSize = true;
            this.chLearningAudio.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chLearningAudio.ForeColor = System.Drawing.Color.Black;
            this.chLearningAudio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chLearningAudio.Location = new System.Drawing.Point(174, 143);
            this.chLearningAudio.Name = "chLearningAudio";
            this.chLearningAudio.Size = new System.Drawing.Size(73, 23);
            this.chLearningAudio.TabIndex = 24;
            this.chLearningAudio.Text = "  Audio";
            this.chLearningAudio.UseVisualStyleBackColor = true;
            this.chLearningAudio.CheckedChanged += new System.EventHandler(this.chLearningAudio_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(77, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 19);
            this.label9.TabIndex = 23;
            this.label9.Text = "Type:";
            // 
            // tbSearchParams
            // 
            this.tbSearchParams.BackColor = System.Drawing.Color.White;
            this.tbSearchParams.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchParams.ForeColor = System.Drawing.Color.Black;
            this.tbSearchParams.Location = new System.Drawing.Point(80, 298);
            this.tbSearchParams.Multiline = true;
            this.tbSearchParams.Name = "tbSearchParams";
            this.tbSearchParams.Size = new System.Drawing.Size(345, 74);
            this.tbSearchParams.TabIndex = 1;
            this.tbSearchParams.TextChanged += new System.EventHandler(this.tbSearchParams_TextChanged);
            // 
            // treeWiewSettings
            // 
            this.treeWiewSettings.BackColor = System.Drawing.Color.White;
            this.treeWiewSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeWiewSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeWiewSettings.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeWiewSettings.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeWiewSettings.ForeColor = System.Drawing.Color.Black;
            this.treeWiewSettings.LineColor = System.Drawing.Color.DimGray;
            this.treeWiewSettings.Location = new System.Drawing.Point(10, 10);
            this.treeWiewSettings.Name = "treeWiewSettings";
            treeNode1.Name = "Basics";
            treeNode1.Text = "Basics";
            treeNode2.Name = "Plugins";
            treeNode2.Text = "Plugins";
            treeNode3.Name = "Learning";
            treeNode3.Text = "Learning";
            treeNode4.Name = "Network";
            treeNode4.Text = "Network";
            treeNode5.Name = "Logging";
            treeNode5.Text = "Logging";
            treeNode6.Name = "Settings";
            treeNode6.Text = "Settings";
            this.treeWiewSettings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treeWiewSettings.Size = new System.Drawing.Size(141, 591);
            this.treeWiewSettings.TabIndex = 0;
            this.treeWiewSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeWiewSettings_AfterSelect);
            // 
            // panelLogging
            // 
            this.panelLogging.Controls.Add(this.groupBox1);
            this.panelLogging.Controls.Add(this.textBox3);
            this.panelLogging.Controls.Add(this.comboBox1);
            this.panelLogging.Controls.Add(this.paragraphe5);
            this.panelLogging.Controls.Add(this.label14);
            this.panelLogging.Location = new System.Drawing.Point(185, 100);
            this.panelLogging.Name = "panelLogging";
            this.panelLogging.Size = new System.Drawing.Size(168, 415);
            this.panelLogging.TabIndex = 26;
            this.panelLogging.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(93, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 203);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create a new account";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Miramonte", 12F);
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(15, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 19);
            this.label16.TabIndex = 25;
            this.label16.Text = "User:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(21, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(327, 27);
            this.textBox2.TabIndex = 30;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(22, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(326, 27);
            this.textBox1.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Miramonte", 12F);
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(15, 94);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 19);
            this.label18.TabIndex = 29;
            this.label18.Text = "Password:";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(273, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 24;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Gray;
            this.textBox3.Location = new System.Drawing.Point(93, 178);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(371, 27);
            this.textBox3.TabIndex = 27;
            this.textBox3.Text = "Password";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("Miramonte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "universal",
            "admin"});
            this.comboBox1.Location = new System.Drawing.Point(93, 141);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(371, 27);
            this.comboBox1.TabIndex = 22;
            // 
            // paragraphe5
            // 
            this.paragraphe5.BackColor = System.Drawing.Color.White;
            this.paragraphe5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("paragraphe5.BackgroundImage")));
            this.paragraphe5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.paragraphe5.Location = new System.Drawing.Point(6, 12);
            this.paragraphe5.MaximumSize = new System.Drawing.Size(0, 47);
            this.paragraphe5.MinimumSize = new System.Drawing.Size(479, 54);
            this.paragraphe5.Name = "paragraphe5";
            this.paragraphe5.Size = new System.Drawing.Size(479, 54);
            this.paragraphe5.TabIndex = 0;
            this.paragraphe5.TextColor = System.Drawing.Color.Navy;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Miramonte", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(74, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 24);
            this.label14.TabIndex = 21;
            this.label14.Text = "Accounts";
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(896, 611);
            this.Controls.Add(this.panelExtensions);
            this.Controls.Add(this.panelNetwork);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelLearning);
            this.Controls.Add(this.panelLogging);
            this.Controls.Add(this.treeWiewSettings);
            this.Font = new System.Drawing.Font("Miramonte", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.cmsPlugins.ResumeLayout(false);
            this.panelNetwork.ResumeLayout(false);
            this.panelNetwork.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.panelExtensions.ResumeLayout(false);
            this.panelExtensions.PerformLayout();
            this.panelLearning.ResumeLayout(false);
            this.panelLearning.PerformLayout();
            this.panelLogging.ResumeLayout(false);
            this.panelLogging.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.CheckBox chEnableScrobbling;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.CheckBox chBoxEnableLogger;
        private System.Windows.Forms.CheckBox chBoxEnablePlugin;
        private System.Windows.Forms.ListView listViewPlugin;
        private System.Windows.Forms.ColumnHeader cHName;
        private System.Windows.Forms.ColumnHeader cHVersion;
        private System.Windows.Forms.ColumnHeader cHLogo;
        private System.Windows.Forms.ColumnHeader cHDescription;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ContextMenuStrip cmsPlugins;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.CheckBox chBoxEnableAutoLangDetection;
        private System.Windows.Forms.ToolTip toolTipLangDetection;
        private System.Windows.Forms.Label lblPlaylistSaveAs;
        private System.Windows.Forms.ComboBox cbPlaylistSaveAs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFolderProcessorDefDir;
        private System.Windows.Forms.CheckBox cbArtistImage;
        private System.Windows.Forms.CheckBox chBoxRestartLanguage;
        private System.Windows.Forms.TreeView treeWiewSettings;
        private UserControls.Paragraphe paragraphe1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSearchParams;
        private System.Windows.Forms.CheckBox chBoxAutoSearchParams;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chLearningAudio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbLearningType;
        private System.Windows.Forms.Label label6;
        private UserControls.Paragraphe paragraphe2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer;
        private UserControls.LoadingCircle loadingCircle;
        private System.Windows.Forms.Panel panelLearning;
        private System.Windows.Forms.Panel panelExtensions;
        private System.Windows.Forms.Panel panelSettings;
        private UserControls.Paragraphe paragraphe3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelNetwork;
        private UserControls.Paragraphe paragraphe4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panelLogging;
        private System.Windows.Forms.ComboBox comboBox1;
        private UserControls.Paragraphe paragraphe5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
    }
}