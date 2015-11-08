namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    partial class UserSelectForm
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
            this.userSelectUserControl1 = new FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.UserSelectUserControl();
            this.SuspendLayout();
            // 
            // userSelectUserControl1
            // 
            this.userSelectUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSelectUserControl1.Facade = null;
            this.userSelectUserControl1.Location = new System.Drawing.Point(0, 0);
            this.userSelectUserControl1.Name = "userSelectUserControl1";
            this.userSelectUserControl1.Size = new System.Drawing.Size(513, 550);
            this.userSelectUserControl1.TabIndex = 0;
            // 
            // UserSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 550);
            this.Controls.Add(this.userSelectUserControl1);
            this.Name = "UserSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户选择";
            this.Load += new System.EventHandler(this.UserSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserSelectUserControl userSelectUserControl1;

    }
}