namespace Shauni.Forms
{
    partial class ToolsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolsForm));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.cmsMediaListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectThisIconPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControlOwn = new Shauni.UserControls.TabControlOwn();
            this.tbFolderProcessor = new System.Windows.Forms.TabPage();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.clmnArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbLogger = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblLoggerState = new System.Windows.Forms.Label();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listViewLogger = new System.Windows.Forms.ListView();
            this.chSeriousness = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbIcons = new System.Windows.Forms.TabPage();
            this.lblListOfThemes = new System.Windows.Forms.Label();
            this.gBInfo = new System.Windows.Forms.GroupBox();
            this.lblCurrentlyApplied = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAuthorLink = new System.Windows.Forms.TextBox();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.tbCredits = new System.Windows.Forms.TextBox();
            this.iconsListBox = new Shauni.UserControls.IconPackListBox();
            this.lblCurrentTheme = new System.Windows.Forms.Label();
            this.pBcurrentTheme = new System.Windows.Forms.PictureBox();
            this.cmsMediaListBox.SuspendLayout();
            this.tabControlOwn.SuspendLayout();
            this.tbFolderProcessor.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tbLogger.SuspendLayout();
            this.tbIcons.SuspendLayout();
            this.gBInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBcurrentTheme)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsMediaListBox
            // 
            this.cmsMediaListBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectThisIconPackToolStripMenuItem});
            this.cmsMediaListBox.Name = "contextMenuStrip";
            this.cmsMediaListBox.Size = new System.Drawing.Size(182, 26);
            // 
            // selectThisIconPackToolStripMenuItem
            // 
            this.selectThisIconPackToolStripMenuItem.Name = "selectThisIconPackToolStripMenuItem";
            this.selectThisIconPackToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.selectThisIconPackToolStripMenuItem.Text = "Apply this icon pack";
            this.selectThisIconPackToolStripMenuItem.Click += new System.EventHandler(this.selectThisIconPackToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabControlOwn
            // 
            this.tabControlOwn.Controls.Add(this.tbFolderProcessor);
            this.tabControlOwn.Controls.Add(this.tbLogger);
            this.tabControlOwn.Controls.Add(this.tbIcons);
            this.tabControlOwn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOwn.Font = new System.Drawing.Font("Miramonte", 9F);
            this.tabControlOwn.ItemSize = new System.Drawing.Size(0, 17);
            this.tabControlOwn.Location = new System.Drawing.Point(0, 0);
            this.tabControlOwn.Name = "tabControlOwn";
            this.tabControlOwn.Padding = new System.Drawing.Point(9, 0);
            this.tabControlOwn.SelectedIndex = 0;
            this.tabControlOwn.Size = new System.Drawing.Size(668, 365);
            this.tabControlOwn.TabIndex = 3;
            this.tabControlOwn.SelectedIndexChanged += new System.EventHandler(this.tabControlOwn_SelectedIndexChanged);
            // 
            // tbFolderProcessor
            // 
            this.tbFolderProcessor.Controls.Add(this.btnBrowse);
            this.tbFolderProcessor.Controls.Add(this.statusStrip);
            this.tbFolderProcessor.Controls.Add(this.dataGridView);
            this.tbFolderProcessor.Location = new System.Drawing.Point(4, 21);
            this.tbFolderProcessor.Name = "tbFolderProcessor";
            this.tbFolderProcessor.Padding = new System.Windows.Forms.Padding(3);
            this.tbFolderProcessor.Size = new System.Drawing.Size(660, 340);
            this.tbFolderProcessor.TabIndex = 1;
            this.tbFolderProcessor.Text = "Folder Processor    ";
            this.tbFolderProcessor.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Image = global::Shauni.Properties.Resources.Folder;
            this.btnBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowse.Location = new System.Drawing.Point(577, 283);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.SlateGray;
            this.statusStrip.Font = new System.Drawing.Font("Miramonte", 9F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText});
            this.statusStrip.Location = new System.Drawing.Point(3, 315);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(654, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // statusText
            // 
            this.statusText.Image = global::Shauni.Properties.Resources.save;
            this.statusText.Name = "statusText";
            this.statusText.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.statusText.Size = new System.Drawing.Size(22, 17);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnArtist,
            this.clmnTitle,
            this.clmnFilename});
            this.dataGridView.Location = new System.Drawing.Point(8, 6);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(644, 269);
            this.dataGridView.TabIndex = 1;
            // 
            // clmnArtist
            // 
            this.clmnArtist.HeaderText = "Artist";
            this.clmnArtist.Name = "clmnArtist";
            this.clmnArtist.ReadOnly = true;
            this.clmnArtist.Width = 150;
            // 
            // clmnTitle
            // 
            this.clmnTitle.HeaderText = "Title";
            this.clmnTitle.Name = "clmnTitle";
            this.clmnTitle.ReadOnly = true;
            this.clmnTitle.Width = 150;
            // 
            // clmnFilename
            // 
            this.clmnFilename.HeaderText = "Filename";
            this.clmnFilename.Name = "clmnFilename";
            this.clmnFilename.ReadOnly = true;
            this.clmnFilename.Width = 300;
            // 
            // tbLogger
            // 
            this.tbLogger.Controls.Add(this.btnClear);
            this.tbLogger.Controls.Add(this.lblLoggerState);
            this.tbLogger.Controls.Add(this.btnResume);
            this.tbLogger.Controls.Add(this.btnPause);
            this.tbLogger.Controls.Add(this.btnCancel);
            this.tbLogger.Controls.Add(this.listViewLogger);
            this.tbLogger.Location = new System.Drawing.Point(4, 21);
            this.tbLogger.Name = "tbLogger";
            this.tbLogger.Size = new System.Drawing.Size(660, 340);
            this.tbLogger.TabIndex = 2;
            this.tbLogger.Text = "Logger";
            this.tbLogger.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.Image = global::Shauni.Properties.Resources.delete;
            this.btnClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClear.Location = new System.Drawing.Point(264, 302);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblLoggerState
            // 
            this.lblLoggerState.AutoSize = true;
            this.lblLoggerState.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLoggerState.Location = new System.Drawing.Point(16, 306);
            this.lblLoggerState.Name = "lblLoggerState";
            this.lblLoggerState.Size = new System.Drawing.Size(0, 15);
            this.lblLoggerState.TabIndex = 4;
            // 
            // btnResume
            // 
            this.btnResume.Image = global::Shauni.Properties.Resources.ResumeLog;
            this.btnResume.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResume.Location = new System.Drawing.Point(461, 302);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 23);
            this.btnResume.TabIndex = 3;
            this.btnResume.Text = "Resume";
            this.btnResume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResume.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnPause
            // 
            this.btnPause.Image = global::Shauni.Properties.Resources.PauseLog;
            this.btnPause.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPause.Location = new System.Drawing.Point(356, 302);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Shauni.Properties.Resources.CancelLog;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(565, 302);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // listViewLogger
            // 
            this.listViewLogger.BackColor = System.Drawing.Color.GhostWhite;
            this.listViewLogger.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSeriousness,
            this.chDate,
            this.chMessage});
            this.listViewLogger.GridLines = true;
            this.listViewLogger.Location = new System.Drawing.Point(19, 13);
            this.listViewLogger.Name = "listViewLogger";
            this.listViewLogger.Size = new System.Drawing.Size(621, 283);
            this.listViewLogger.TabIndex = 0;
            this.listViewLogger.UseCompatibleStateImageBehavior = false;
            this.listViewLogger.View = System.Windows.Forms.View.Details;
            // 
            // chSeriousness
            // 
            this.chSeriousness.Text = "Seriousness";
            this.chSeriousness.Width = 76;
            // 
            // chDate
            // 
            this.chDate.Text = "Date";
            this.chDate.Width = 120;
            // 
            // chMessage
            // 
            this.chMessage.Text = "Message";
            this.chMessage.Width = 450;
            // 
            // tbIcons
            // 
            this.tbIcons.Controls.Add(this.lblListOfThemes);
            this.tbIcons.Controls.Add(this.gBInfo);
            this.tbIcons.Controls.Add(this.iconsListBox);
            this.tbIcons.Controls.Add(this.lblCurrentTheme);
            this.tbIcons.Controls.Add(this.pBcurrentTheme);
            this.tbIcons.Location = new System.Drawing.Point(4, 21);
            this.tbIcons.Name = "tbIcons";
            this.tbIcons.Size = new System.Drawing.Size(660, 340);
            this.tbIcons.TabIndex = 3;
            this.tbIcons.Text = "Icons";
            this.tbIcons.UseVisualStyleBackColor = true;
            // 
            // lblListOfThemes
            // 
            this.lblListOfThemes.AutoSize = true;
            this.lblListOfThemes.Font = new System.Drawing.Font("Miramonte", 11F, System.Drawing.FontStyle.Bold);
            this.lblListOfThemes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListOfThemes.Location = new System.Drawing.Point(351, 83);
            this.lblListOfThemes.Name = "lblListOfThemes";
            this.lblListOfThemes.Size = new System.Drawing.Size(131, 19);
            this.lblListOfThemes.TabIndex = 23;
            this.lblListOfThemes.Text = "Avialable themes:";
            // 
            // gBInfo
            // 
            this.gBInfo.Controls.Add(this.lblCurrentlyApplied);
            this.gBInfo.Controls.Add(this.label2);
            this.gBInfo.Controls.Add(this.label7);
            this.gBInfo.Controls.Add(this.tbName);
            this.gBInfo.Controls.Add(this.tbAuthorLink);
            this.gBInfo.Controls.Add(this.tbAuthor);
            this.gBInfo.Controls.Add(this.label5);
            this.gBInfo.Controls.Add(this.label1);
            this.gBInfo.Controls.Add(this.tbVersion);
            this.gBInfo.Controls.Add(this.label4);
            this.gBInfo.Controls.Add(this.label6);
            this.gBInfo.Controls.Add(this.rtbDescription);
            this.gBInfo.Controls.Add(this.tbCredits);
            this.gBInfo.Location = new System.Drawing.Point(13, 4);
            this.gBInfo.Name = "gBInfo";
            this.gBInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gBInfo.Size = new System.Drawing.Size(322, 328);
            this.gBInfo.TabIndex = 22;
            this.gBInfo.TabStop = false;
            // 
            // lblCurrentlyApplied
            // 
            this.lblCurrentlyApplied.AutoSize = true;
            this.lblCurrentlyApplied.Font = new System.Drawing.Font("Miramonte", 6.75F);
            this.lblCurrentlyApplied.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentlyApplied.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCurrentlyApplied.Location = new System.Drawing.Point(245, 12);
            this.lblCurrentlyApplied.Name = "lblCurrentlyApplied";
            this.lblCurrentlyApplied.Size = new System.Drawing.Size(0, 14);
            this.lblCurrentlyApplied.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(29, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pack Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(30, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "AuthorLink:";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.Location = new System.Drawing.Point(22, 36);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(278, 22);
            this.tbName.TabIndex = 7;
            // 
            // tbAuthorLink
            // 
            this.tbAuthorLink.BackColor = System.Drawing.Color.White;
            this.tbAuthorLink.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.tbAuthorLink.Location = new System.Drawing.Point(22, 171);
            this.tbAuthorLink.Name = "tbAuthorLink";
            this.tbAuthorLink.ReadOnly = true;
            this.tbAuthorLink.Size = new System.Drawing.Size(278, 21);
            this.tbAuthorLink.TabIndex = 19;
            // 
            // tbAuthor
            // 
            this.tbAuthor.BackColor = System.Drawing.Color.White;
            this.tbAuthor.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.tbAuthor.Location = new System.Drawing.Point(22, 80);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.ReadOnly = true;
            this.tbAuthor.Size = new System.Drawing.Size(278, 21);
            this.tbAuthor.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(30, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Version:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(30, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Author:";
            // 
            // tbVersion
            // 
            this.tbVersion.BackColor = System.Drawing.Color.White;
            this.tbVersion.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.tbVersion.Location = new System.Drawing.Point(22, 124);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.ReadOnly = true;
            this.tbVersion.Size = new System.Drawing.Size(87, 21);
            this.tbVersion.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(30, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Description:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(30, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Credits:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.BackColor = System.Drawing.Color.White;
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDescription.Location = new System.Drawing.Point(23, 262);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.Size = new System.Drawing.Size(277, 55);
            this.rtbDescription.TabIndex = 14;
            this.rtbDescription.Text = "..";
            // 
            // tbCredits
            // 
            this.tbCredits.BackColor = System.Drawing.Color.White;
            this.tbCredits.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.tbCredits.Location = new System.Drawing.Point(23, 217);
            this.tbCredits.Name = "tbCredits";
            this.tbCredits.ReadOnly = true;
            this.tbCredits.Size = new System.Drawing.Size(277, 21);
            this.tbCredits.TabIndex = 15;
            // 
            // iconsListBox
            // 
            this.iconsListBox.AllowDrop = true;
            this.iconsListBox.BackColor = System.Drawing.Color.White;
            this.iconsListBox.BackColorCheckedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(248)))));
            this.iconsListBox.BackColorCheckedGradientStart = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(236)))), ((int)(((byte)(248)))));
            this.iconsListBox.BackColorGradientEnd = System.Drawing.Color.GhostWhite;
            this.iconsListBox.BackColorGradientStart = System.Drawing.Color.GhostWhite;
            this.iconsListBox.BorderCheckedColor = System.Drawing.Color.Navy;
            this.iconsListBox.BorderColor = System.Drawing.Color.Gainsboro;
            this.iconsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconsListBox.BorderType = Shauni.UserControls.ShauniListBox.BorderTypes.Square;
            this.iconsListBox.DisplayMember = "Name";
            this.iconsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.iconsListBox.FormattingEnabled = true;
            this.iconsListBox.IconPadding = new System.Drawing.Point(0, 1);
            this.iconsListBox.ItemHeight = 24;
            this.iconsListBox.Location = new System.Drawing.Point(368, 114);
            this.iconsListBox.Name = "iconsListBox";
            this.iconsListBox.Size = new System.Drawing.Size(269, 218);
            this.iconsListBox.TabIndex = 2;
            this.iconsListBox.ValueMember = "Name";
            this.iconsListBox.ItemClicked += new System.EventHandler<Shauni.UserControls.ItemClickedEventArgs>(this.iconsListBox_ItemClicked);
            // 
            // lblCurrentTheme
            // 
            this.lblCurrentTheme.AutoSize = true;
            this.lblCurrentTheme.Font = new System.Drawing.Font("Miramonte", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTheme.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCurrentTheme.Location = new System.Drawing.Point(351, 10);
            this.lblCurrentTheme.Name = "lblCurrentTheme";
            this.lblCurrentTheme.Size = new System.Drawing.Size(114, 19);
            this.lblCurrentTheme.TabIndex = 1;
            this.lblCurrentTheme.Text = "Current theme:";
            // 
            // pBcurrentTheme
            // 
            this.pBcurrentTheme.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pBcurrentTheme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBcurrentTheme.Image = ((System.Drawing.Image)(resources.GetObject("pBcurrentTheme.Image")));
            this.pBcurrentTheme.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pBcurrentTheme.Location = new System.Drawing.Point(368, 41);
            this.pBcurrentTheme.Name = "pBcurrentTheme";
            this.pBcurrentTheme.Size = new System.Drawing.Size(269, 24);
            this.pBcurrentTheme.TabIndex = 0;
            this.pBcurrentTheme.TabStop = false;
            // 
            // ToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(668, 365);
            this.Controls.Add(this.tabControlOwn);
            this.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tools";
            this.cmsMediaListBox.ResumeLayout(false);
            this.tabControlOwn.ResumeLayout(false);
            this.tbFolderProcessor.ResumeLayout(false);
            this.tbFolderProcessor.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tbLogger.ResumeLayout(false);
            this.tbLogger.PerformLayout();
            this.tbIcons.ResumeLayout(false);
            this.tbIcons.PerformLayout();
            this.gBInfo.ResumeLayout(false);
            this.gBInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBcurrentTheme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.TabControlOwn tabControlOwn;
        private System.Windows.Forms.TabPage tbFolderProcessor;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFilename;
        private System.Windows.Forms.TabPage tbLogger;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblLoggerState;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView listViewLogger;
        private System.Windows.Forms.ColumnHeader chSeriousness;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chMessage;
        private System.Windows.Forms.TabPage tbIcons;
        private System.Windows.Forms.Label lblListOfThemes;
        private System.Windows.Forms.GroupBox gBInfo;
        private System.Windows.Forms.Label lblCurrentlyApplied;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbAuthorLink;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.TextBox tbCredits;
        private UserControls.IconPackListBox iconsListBox;
        private System.Windows.Forms.Label lblCurrentTheme;
        private System.Windows.Forms.PictureBox pBcurrentTheme;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ContextMenuStrip cmsMediaListBox;
        private System.Windows.Forms.ToolStripMenuItem selectThisIconPackToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
    }
}