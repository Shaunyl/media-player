namespace Shauni.UserControls
{
    partial class PlaylistTab
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Playlist");
            this.treeView = new System.Windows.Forms.TreeView();
            this.playlistTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPlaylistName = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cntMnStrpMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SimplePlaylistTlStrpMnItm = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoPlaylistTlStrpMnItm = new System.Windows.Forms.ToolStripMenuItem();
            this.cntMnStrpSimplePlaylist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cntMnStrpAutomaticPlaylist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.cntMnStrpMain.SuspendLayout();
            this.cntMnStrpSimplePlaylist.SuspendLayout();
            this.cntMnStrpAutomaticPlaylist.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.Color.GhostWhite;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeView.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.Name = "NodePlaylist";
            treeNode1.Text = "Playlist";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView.Size = new System.Drawing.Size(286, 263);
            this.treeView.TabIndex = 8;
            this.treeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseUp);
            // 
            // playlistTextBox
            // 
            this.playlistTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistTextBox.BackColor = System.Drawing.Color.White;
            this.playlistTextBox.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playlistTextBox.Location = new System.Drawing.Point(7, 55);
            this.playlistTextBox.Name = "playlistTextBox";
            this.playlistTextBox.Size = new System.Drawing.Size(273, 23);
            this.playlistTextBox.TabIndex = 15;
            this.playlistTextBox.Visible = false;
            this.playlistTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.playlistTextBox_KeyPress);
            this.playlistTextBox.Leave += new System.EventHandler(this.playlistTextBox_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblPlaylistName);
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Controls.Add(this.playlistTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 101);
            this.panel1.TabIndex = 16;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStatus.Location = new System.Drawing.Point(4, 81);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Visible = false;
            // 
            // lblPlaylistName
            // 
            this.lblPlaylistName.AutoSize = true;
            this.lblPlaylistName.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaylistName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPlaylistName.Location = new System.Drawing.Point(75, 28);
            this.lblPlaylistName.Name = "lblPlaylistName";
            this.lblPlaylistName.Size = new System.Drawing.Size(0, 15);
            this.lblPlaylistName.TabIndex = 10;
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = global::Shauni.Properties.Resources.save;
            this.saveBtn.Location = new System.Drawing.Point(7, 22);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(57, 27);
            this.saveBtn.TabIndex = 9;
            this.saveBtn.Text = "Save";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cntMnStrpMain
            // 
            this.cntMnStrpMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SimplePlaylistTlStrpMnItm,
            this.AutoPlaylistTlStrpMnItm});
            this.cntMnStrpMain.Name = "cntMnStrpMain";
            this.cntMnStrpMain.Size = new System.Drawing.Size(213, 48);
            // 
            // SimplePlaylistTlStrpMnItm
            // 
            this.SimplePlaylistTlStrpMnItm.BackColor = System.Drawing.SystemColors.Control;
            this.SimplePlaylistTlStrpMnItm.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.SimplePlaylistTlStrpMnItm.Name = "SimplePlaylistTlStrpMnItm";
            this.SimplePlaylistTlStrpMnItm.Size = new System.Drawing.Size(212, 22);
            this.SimplePlaylistTlStrpMnItm.Text = "Create a Simple Playlist";
            this.SimplePlaylistTlStrpMnItm.Click += new System.EventHandler(this.SimplePlaylistTlStrpMnItm_Click);
            // 
            // AutoPlaylistTlStrpMnItm
            // 
            this.AutoPlaylistTlStrpMnItm.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.AutoPlaylistTlStrpMnItm.Name = "AutoPlaylistTlStrpMnItm";
            this.AutoPlaylistTlStrpMnItm.Size = new System.Drawing.Size(212, 22);
            this.AutoPlaylistTlStrpMnItm.Text = "Create an Automatic Playlist";
            this.AutoPlaylistTlStrpMnItm.Click += new System.EventHandler(this.AutoPlaylistTlStrpMnItm_Click);
            // 
            // cntMnStrpSimplePlaylist
            // 
            this.cntMnStrpSimplePlaylist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.saveToFileToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cntMnStrpSimplePlaylist.Name = "cntMnStrpSimplePlaylist";
            this.cntMnStrpSimplePlaylist.Size = new System.Drawing.Size(131, 92);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.saveToFileToolStripMenuItem.Text = "Save To File";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cntMnStrpAutomaticPlaylist
            // 
            this.cntMnStrpAutomaticPlaylist.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.cntMnStrpAutomaticPlaylist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem1,
            this.modifyToolStripMenuItem,
            this.modifyToolStripMenuItem1,
            this.renameToolStripMenuItem1,
            this.deleteToolStripMenuItem1});
            this.cntMnStrpAutomaticPlaylist.Name = "cntMnStrpAutomaticPlaylist";
            this.cntMnStrpAutomaticPlaylist.Size = new System.Drawing.Size(131, 114);
            // 
            // playToolStripMenuItem1
            // 
            this.playToolStripMenuItem1.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Bold);
            this.playToolStripMenuItem1.Name = "playToolStripMenuItem1";
            this.playToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.playToolStripMenuItem1.Text = "Play";
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.modifyToolStripMenuItem.Text = "Save To File";
            // 
            // modifyToolStripMenuItem1
            // 
            this.modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
            this.modifyToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.modifyToolStripMenuItem1.Text = "Modify";
            // 
            // renameToolStripMenuItem1
            // 
            this.renameToolStripMenuItem1.Name = "renameToolStripMenuItem1";
            this.renameToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.renameToolStripMenuItem1.Text = "Rename";
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            // 
            // PlaylistTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView);
            this.Name = "PlaylistTab";
            this.Size = new System.Drawing.Size(286, 362);
            this.VisibleChanged += new System.EventHandler(this.PlaylistTab_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cntMnStrpMain.ResumeLayout(false);
            this.cntMnStrpSimplePlaylist.ResumeLayout(false);
            this.cntMnStrpAutomaticPlaylist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox playlistTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cntMnStrpMain;
        private System.Windows.Forms.ToolStripMenuItem SimplePlaylistTlStrpMnItm;
        private System.Windows.Forms.ToolStripMenuItem AutoPlaylistTlStrpMnItm;
        private System.Windows.Forms.ContextMenuStrip cntMnStrpSimplePlaylist;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblPlaylistName;
        private System.Windows.Forms.ContextMenuStrip cntMnStrpAutomaticPlaylist;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.Label lblStatus;
    }
}
