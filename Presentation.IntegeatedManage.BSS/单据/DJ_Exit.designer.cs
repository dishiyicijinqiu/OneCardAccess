namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    partial class DJ_Exit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DJ_Exit));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnFQTC = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveCG = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnSaveDJ = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(110, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(283, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "请选择对本单据的处理，按《ESC》键放弃本次处理！";
            // 
            // btnFQTC
            // 
            this.btnFQTC.Image = ((System.Drawing.Image)(resources.GetObject("btnFQTC.Image")));
            this.btnFQTC.Location = new System.Drawing.Point(275, 95);
            this.btnFQTC.Name = "btnFQTC";
            this.btnFQTC.Size = new System.Drawing.Size(96, 31);
            this.btnFQTC.TabIndex = 12;
            this.btnFQTC.Text = "废弃退出(&C)";
            this.btnFQTC.Click += new System.EventHandler(this.btnFQTC_Click);
            // 
            // btnSaveCG
            // 
            this.btnSaveCG.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveCG.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCG.Image")));
            this.btnSaveCG.Location = new System.Drawing.Point(33, 95);
            this.btnSaveCG.Name = "btnSaveCG";
            this.btnSaveCG.Size = new System.Drawing.Size(96, 31);
            this.btnSaveCG.TabIndex = 11;
            this.btnSaveCG.Text = "存入草稿(&D)";
            this.btnSaveCG.Click += new System.EventHandler(this.btnSaveCG_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(11, 15);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Size = new System.Drawing.Size(93, 52);
            this.pictureEdit1.TabIndex = 13;
            // 
            // btnSaveDJ
            // 
            this.btnSaveDJ.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveDJ.Image")));
            this.btnSaveDJ.Location = new System.Drawing.Point(154, 95);
            this.btnSaveDJ.Name = "btnSaveDJ";
            this.btnSaveDJ.Size = new System.Drawing.Size(96, 31);
            this.btnSaveDJ.TabIndex = 10;
            this.btnSaveDJ.Text = "保存单据(&S)";
            this.btnSaveDJ.Click += new System.EventHandler(this.btnSaveDJ_Click);
            // 
            // DJ_Exit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 149);
            this.Controls.Add(this.btnSaveDJ);
            this.Controls.Add(this.btnSaveCG);
            this.Controls.Add(this.btnFQTC);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DJ_Exit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "过账提示";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnFQTC;
        private DevExpress.XtraEditors.SimpleButton btnSaveCG;
        private DevExpress.XtraEditors.SimpleButton btnSaveDJ;
    }
}