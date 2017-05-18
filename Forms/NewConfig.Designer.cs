namespace Shauni.Forms
{
    partial class NewConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewConfig));
            this.tabControlOwn = new Shauni.UserControls.TabControlOwn();
            this.tbFolderProcessor = new System.Windows.Forms.TabPage();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbLogger = new System.Windows.Forms.TabPage();
            this.tbIcons = new System.Windows.Forms.TabPage();
            this.tabControlOwn.SuspendLayout();
            this.tbFolderProcessor.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.tabControlOwn.Size = new System.Drawing.Size(705, 389);
            this.tabControlOwn.TabIndex = 4;
            // 
            // tbFolderProcessor
            // 
            this.tbFolderProcessor.Controls.Add(this.statusStrip);
            this.tbFolderProcessor.Location = new System.Drawing.Point(4, 21);
            this.tbFolderProcessor.Name = "tbFolderProcessor";
            this.tbFolderProcessor.Padding = new System.Windows.Forms.Padding(3);
            this.tbFolderProcessor.Size = new System.Drawing.Size(697, 364);
            this.tbFolderProcessor.TabIndex = 1;
            this.tbFolderProcessor.Text = "Folder Processor    ";
            this.tbFolderProcessor.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.SlateGray;
            this.statusStrip.Font = new System.Drawing.Font("Miramonte", 9F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText});
            this.statusStrip.Location = new System.Drawing.Point(3, 335);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(691, 24);
            this.statusStrip.TabIndex = 0;
            // 
            // statusText
            // 
            this.statusText.Image = global::Shauni.Properties.Resources.save;
            this.statusText.Name = "statusText";
            this.statusText.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.statusText.Size = new System.Drawing.Size(22, 17);
            // 
            // tbLogger
            // 
            this.tbLogger.Location = new System.Drawing.Point(4, 21);
            this.tbLogger.Name = "tbLogger";
            this.tbLogger.Size = new System.Drawing.Size(697, 364);
            this.tbLogger.TabIndex = 2;
            this.tbLogger.Text = "Logger";
            this.tbLogger.UseVisualStyleBackColor = true;
            // 
            // tbIcons
            // 
            this.tbIcons.Location = new System.Drawing.Point(4, 21);
            this.tbIcons.Name = "tbIcons";
            this.tbIcons.Size = new System.Drawing.Size(697, 364);
            this.tbIcons.TabIndex = 3;
            this.tbIcons.Text = "Icons";
            this.tbIcons.UseVisualStyleBackColor = true;
            // 
            // NewConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(705, 389);
            this.Controls.Add(this.tabControlOwn);
            this.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.tabControlOwn.ResumeLayout(false);
            this.tbFolderProcessor.ResumeLayout(false);
            this.tbFolderProcessor.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.TabControlOwn tabControlOwn;
        private System.Windows.Forms.TabPage tbFolderProcessor;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.TabPage tbLogger;
        private System.Windows.Forms.TabPage tbIcons;
    }
}