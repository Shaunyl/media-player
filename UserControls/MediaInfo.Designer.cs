namespace Shauni.UserControls
{
    partial class MediaInfo
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
            this.mediaInfoPanel = new Shauni.UserControls.MediaPanel();
            this.lblMediaArtist = new System.Windows.Forms.Label();
            this.ratingBarFavourite = new Shauni.UserControls.RatingBar();
            this.ratingBarStars = new Shauni.UserControls.RatingBar();
            this.lblMediaTitle = new System.Windows.Forms.Label();
            this.mediaInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mediaInfoPanel
            // 
            this.mediaInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaInfoPanel.BackColor = System.Drawing.Color.Transparent;
            this.mediaInfoPanel.BorderColor = System.Drawing.Color.Silver;
            this.mediaInfoPanel.BorderWidth = 1;
            this.mediaInfoPanel.Controls.Add(this.lblMediaArtist);
            this.mediaInfoPanel.Controls.Add(this.ratingBarFavourite);
            this.mediaInfoPanel.Controls.Add(this.ratingBarStars);
            this.mediaInfoPanel.Controls.Add(this.lblMediaTitle);
            this.mediaInfoPanel.ForeColor = System.Drawing.Color.Red;
            this.mediaInfoPanel.GradientEndColor = System.Drawing.Color.GhostWhite;
            this.mediaInfoPanel.GradientStartColor = System.Drawing.Color.GhostWhite;
            this.mediaInfoPanel.Image = global::Shauni.Properties.Resources.share32;
            this.mediaInfoPanel.ImageLocation = new System.Drawing.Point(12, 7);
            this.mediaInfoPanel.Location = new System.Drawing.Point(3, 3);
            this.mediaInfoPanel.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.mediaInfoPanel.Name = "mediaInfoPanel";
            this.mediaInfoPanel.RoundCornerRadius = 6;
            this.mediaInfoPanel.ShadowOffSet = 3;
            this.mediaInfoPanel.Size = new System.Drawing.Size(240, 94);
            this.mediaInfoPanel.TabIndex = 5;
            // 
            // lblMediaArtist
            // 
            this.lblMediaArtist.AutoEllipsis = true;
            this.lblMediaArtist.AutoSize = true;
            this.lblMediaArtist.Font = new System.Drawing.Font("Miramonte", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblMediaArtist.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblMediaArtist.Location = new System.Drawing.Point(88, 12);
            this.lblMediaArtist.Name = "lblMediaArtist";
            this.lblMediaArtist.Size = new System.Drawing.Size(0, 19);
            this.lblMediaArtist.TabIndex = 1;
            this.lblMediaArtist.UseMnemonic = false;
            // 
            // ratingBarFavourite
            // 
            this.ratingBarFavourite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ratingBarFavourite.BackColor = System.Drawing.Color.Transparent;
            this.ratingBarFavourite.BarBackColor = System.Drawing.Color.Transparent;
            this.ratingBarFavourite.Gap = ((byte)(1));
            this.ratingBarFavourite.IconEmpty = global::Shauni.Properties.Resources.whiteheart;
            this.ratingBarFavourite.IconFull = global::Shauni.Properties.Resources.FavMedia;
            this.ratingBarFavourite.IconHalf = global::Shauni.Properties.Resources.FavMedia;
            this.ratingBarFavourite.IconsCount = ((byte)(1));
            this.ratingBarFavourite.Location = new System.Drawing.Point(194, 61);
            this.ratingBarFavourite.Name = "ratingBarFavourite";
            this.ratingBarFavourite.Rate = 0F;
            this.ratingBarFavourite.Size = new System.Drawing.Size(35, 23);
            this.ratingBarFavourite.TabIndex = 4;
            this.ratingBarFavourite.RateChanging += new System.EventHandler<Shauni.UserControls.MediaRatedEventArgs>(this.ratingBarFavourite_RateChanging);
            // 
            // ratingBarStars
            // 
            this.ratingBarStars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ratingBarStars.BackColor = System.Drawing.Color.Transparent;
            this.ratingBarStars.BarBackColor = System.Drawing.Color.Transparent;
            this.ratingBarStars.Gap = ((byte)(1));
            this.ratingBarStars.IconEmpty = global::Shauni.Properties.Resources.StarEmpty3;
            this.ratingBarStars.IconFull = global::Shauni.Properties.Resources.StarFull3;
            this.ratingBarStars.IconHalf = global::Shauni.Properties.Resources.StarFull3;
            this.ratingBarStars.IconsCount = ((byte)(5));
            this.ratingBarStars.Location = new System.Drawing.Point(83, 62);
            this.ratingBarStars.Name = "ratingBarStars";
            this.ratingBarStars.Rate = 0F;
            this.ratingBarStars.Size = new System.Drawing.Size(94, 19);
            this.ratingBarStars.TabIndex = 0;
            this.ratingBarStars.Text = "ratingBar";
            this.ratingBarStars.RateChanging += new System.EventHandler<Shauni.UserControls.MediaRatedEventArgs>(this.ratingBarStars_RateChanging);
            // 
            // lblMediaTitle
            // 
            this.lblMediaTitle.AutoEllipsis = true;
            this.lblMediaTitle.AutoSize = true;
            this.lblMediaTitle.Font = new System.Drawing.Font("Miramonte", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediaTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblMediaTitle.Location = new System.Drawing.Point(113, 28);
            this.lblMediaTitle.Name = "lblMediaTitle";
            this.lblMediaTitle.Size = new System.Drawing.Size(0, 16);
            this.lblMediaTitle.TabIndex = 3;
            this.lblMediaTitle.UseMnemonic = false;
            // 
            // MediaInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.mediaInfoPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MediaInfo";
            this.Size = new System.Drawing.Size(246, 101);
            this.mediaInfoPanel.ResumeLayout(false);
            this.mediaInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RatingBar ratingBarStars;
        private System.Windows.Forms.Label lblMediaArtist;
        private System.Windows.Forms.Label lblMediaTitle;
        private RatingBar ratingBarFavourite;
        private MediaPanel mediaInfoPanel;
    }
}
