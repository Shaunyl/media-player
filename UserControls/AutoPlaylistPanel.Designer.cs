namespace Shauni.UserControls
{
    partial class AutoPlaylistPanel
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Create an automatic list that includes the following:");
            this.tbName = new System.Windows.Forms.TextBox();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.autoPlaylistTreeView = new Shauni.UserControls.AutoPlaylistTreeView();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.ForeColor = System.Drawing.Color.DarkGray;
            this.tbName.Location = new System.Drawing.Point(18, 40);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(704, 22);
            this.tbName.TabIndex = 1;
            this.tbName.Text = "Write the name of your Automatic Playlist...";
            this.tbName.Click += new System.EventHandler(this.tbName_Click);
            this.tbName.Leave += new System.EventHandler(this.tbName_Leave);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemove.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemove.Location = new System.Drawing.Point(18, 348);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(75, 23);
            this.BtnRemove.TabIndex = 2;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("Miramonte", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(647, 348);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // autoPlaylistTreeView
            // 
            this.autoPlaylistTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.autoPlaylistTreeView.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoPlaylistTreeView.Location = new System.Drawing.Point(18, 72);
            this.autoPlaylistTreeView.Name = "autoPlaylistTreeView";
            treeNode1.Name = "Root";
            treeNode1.Text = "Create an automatic list that includes the following:";
            this.autoPlaylistTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.autoPlaylistTreeView.Size = new System.Drawing.Size(704, 266);
            this.autoPlaylistTreeView.TabIndex = 0;
            this.autoPlaylistTreeView.ValueModified += new System.EventHandler<Shauni.UserControls.AutoPlaylistTreeView.TreeViewUpdatedEventArgs>(this.autoPlaylistTreeView_ValueModified);
            this.autoPlaylistTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.autoPlaylistTreeView_NodeMouseClick);
            this.autoPlaylistTreeView.Leave += new System.EventHandler(this.autoPlaylistTreeView_Leave);
            // 
            // AutoPlaylistPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.autoPlaylistTreeView);
            this.Name = "AutoPlaylistPanel";
            this.Size = new System.Drawing.Size(740, 380);
            this.Load += new System.EventHandler(this.AutoPlaylistPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AutoPlaylistTreeView autoPlaylistTreeView;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ImageList imageList;
    }
}
