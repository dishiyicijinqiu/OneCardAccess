namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    partial class DeptSelectForm
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
            this.deptSelectUserControl1 = new FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.DeptSelectUserControl();
            this.formStyleSelect1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormStyleSelect(this.components);
            this.SuspendLayout();
            // 
            // deptSelectUserControl1
            // 
            this.deptSelectUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptSelectUserControl1.Facade = null;
            this.deptSelectUserControl1.Location = new System.Drawing.Point(0, 0);
            this.deptSelectUserControl1.Name = "deptSelectUserControl1";
            this.deptSelectUserControl1.Size = new System.Drawing.Size(660, 469);
            this.deptSelectUserControl1.TabIndex = 0;
            // 
            // formStyleSelect1
            // 
            this.formStyleSelect1.Form = this;
            // 
            // DeptSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 469);
            this.Controls.Add(this.deptSelectUserControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeptSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "部门选择";
            this.Load += new System.EventHandler(this.DeptSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DeptSelectUserControl deptSelectUserControl1;
        private Infrastructure.WinForm.Components.FormStyleSelect formStyleSelect1;
    }
}