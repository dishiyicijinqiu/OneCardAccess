namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    partial class DlyTypeSelectForm
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
            FengSharp.OneCardAccess.Infrastructure.TreeLevel treeLevel1 = new FengSharp.OneCardAccess.Infrastructure.TreeLevel();
            this.dlyTypeSelectUserControl1 = new FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.DlyTypeSelectUserControl();
            this.formLoadErrorExit1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormLoadErrorExit(this.components);
            this.SuspendLayout();
            // 
            // dlyTypeSelectUserControl1
            // 
            this.dlyTypeSelectUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlyTypeSelectUserControl1.Facade = null;
            this.dlyTypeSelectUserControl1.Location = new System.Drawing.Point(0, 0);
            this.dlyTypeSelectUserControl1.Name = "dlyTypeSelectUserControl1";
            this.dlyTypeSelectUserControl1.Size = new System.Drawing.Size(633, 465);
            this.dlyTypeSelectUserControl1.TabIndex = 0;
            treeLevel1.Level_Deep = 0;
            treeLevel1.PId = 0;
            this.dlyTypeSelectUserControl1.TreeLevel = treeLevel1;
            // 
            // DlyTypeSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 465);
            this.Controls.Add(this.dlyTypeSelectUserControl1);
            this.formLoadErrorExit1.SetEnableLoadError(this, true);
            this.Name = "DlyTypeSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "单据类型选择";
            this.Load += new System.EventHandler(this.DlyTypeSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DlyTypeSelectUserControl dlyTypeSelectUserControl1;
        private Infrastructure.WinForm.Components.FormLoadErrorExit formLoadErrorExit1;
    }
}