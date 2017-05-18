namespace Shauni.Forms
{
    partial class LanguagesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguagesForm));
            this.listViewLanguages = new System.Windows.Forms.ListView();
            this.cHLogo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsLanguages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNotifyLangChanging = new System.Windows.Forms.Label();
            this.cmsLanguages.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewLanguages
            // 
            this.listViewLanguages.BackColor = System.Drawing.Color.White;
            this.listViewLanguages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cHLogo,
            this.cHName,
            this.cHVersion,
            this.cHAuthor});
            this.listViewLanguages.Font = new System.Drawing.Font("Miramonte", 11.25F);
            this.listViewLanguages.ForeColor = System.Drawing.Color.Gray;
            this.listViewLanguages.FullRowSelect = true;
            this.listViewLanguages.GridLines = true;
            this.listViewLanguages.Location = new System.Drawing.Point(12, 12);
            this.listViewLanguages.Name = "listViewLanguages";
            this.listViewLanguages.OwnerDraw = true;
            this.listViewLanguages.Size = new System.Drawing.Size(682, 302);
            this.listViewLanguages.TabIndex = 2;
            this.listViewLanguages.TileSize = new System.Drawing.Size(20, 20);
            this.listViewLanguages.UseCompatibleStateImageBehavior = false;
            this.listViewLanguages.View = System.Windows.Forms.View.Details;
            this.listViewLanguages.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewPlugin_DrawColumnHeader);
            this.listViewLanguages.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewPlugin_DrawItem);
            this.listViewLanguages.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listViewPlugin_DrawSubItem);
            this.listViewLanguages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewLanguages_MouseDown);
            // 
            // cHLogo
            // 
            this.cHLogo.Text = "Flag";
            this.cHLogo.Width = 42;
            // 
            // cHName
            // 
            this.cHName.Text = "Language";
            this.cHName.Width = 250;
            // 
            // cHVersion
            // 
            this.cHVersion.Text = "Version";
            this.cHVersion.Width = 65;
            // 
            // cHAuthor
            // 
            this.cHAuthor.Text = "Author";
            this.cHAuthor.Width = 380;
            // 
            // cmsLanguages
            // 
            this.cmsLanguages.Font = new System.Drawing.Font("Miramonte", 8.25F);
            this.cmsLanguages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseToolStripMenuItem});
            this.cmsLanguages.Name = "cmsLanguages";
            this.cmsLanguages.Size = new System.Drawing.Size(117, 26);
            // 
            // chooseToolStripMenuItem
            // 
            this.chooseToolStripMenuItem.Name = "chooseToolStripMenuItem";
            this.chooseToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.chooseToolStripMenuItem.Text = "Choose..";
            this.chooseToolStripMenuItem.Click += new System.EventHandler(this.chooseToolStripMenuItem_Click);
            // 
            // lblNotifyLangChanging
            // 
            this.lblNotifyLangChanging.AutoSize = true;
            this.lblNotifyLangChanging.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifyLangChanging.ForeColor = System.Drawing.Color.Black;
            this.lblNotifyLangChanging.Location = new System.Drawing.Point(9, 328);
            this.lblNotifyLangChanging.Name = "lblNotifyLangChanging";
            this.lblNotifyLangChanging.Size = new System.Drawing.Size(0, 16);
            this.lblNotifyLangChanging.TabIndex = 3;
            // 
            // LanguagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 353);
            this.Controls.Add(this.lblNotifyLangChanging);
            this.Controls.Add(this.listViewLanguages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LanguagesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select a new language..";
            this.cmsLanguages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewLanguages;
        private System.Windows.Forms.ColumnHeader cHLogo;
        private System.Windows.Forms.ColumnHeader cHName;
        private System.Windows.Forms.ColumnHeader cHVersion;
        private System.Windows.Forms.ColumnHeader cHAuthor;
        private System.Windows.Forms.ContextMenuStrip cmsLanguages;
        private System.Windows.Forms.ToolStripMenuItem chooseToolStripMenuItem;
        private System.Windows.Forms.Label lblNotifyLangChanging;
    }
}