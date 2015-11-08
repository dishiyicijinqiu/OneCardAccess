namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Forms
{
    partial class PictureExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureExplorer));
            this.picProductImage = new FengSharp.OneCardAccess.Infrastructure.WinForm.Forms.ExplorerPicture();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picProductImage
            // 
            this.picProductImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picProductImage.Location = new System.Drawing.Point(0, 0);
            this.picProductImage.Name = "picProductImage";
            this.picProductImage.Properties.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picProductImage.Properties.ErrorImage")));
            this.picProductImage.Properties.ShowScrollBars = true;
            this.picProductImage.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            this.picProductImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.picProductImage.Size = new System.Drawing.Size(817, 601);
            this.picProductImage.TabIndex = 32;
            // 
            // PictureExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 601);
            this.Controls.Add(this.picProductImage);
            this.Name = "PictureExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图片查看器";
            this.Load += new System.EventHandler(this.PictureExplorer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ExplorerPicture picProductImage;
    }
}