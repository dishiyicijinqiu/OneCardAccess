namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.DevelopClient
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.pictureBox_Plate = new System.Windows.Forms.PictureBox();
            this.txtUserNo = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.lblUserNo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Plate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Plate
            // 
            this.pictureBox_Plate.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Plate.Image")));
            this.pictureBox_Plate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_Plate.Location = new System.Drawing.Point(12, 24);
            this.pictureBox_Plate.Name = "pictureBox_Plate";
            this.pictureBox_Plate.Size = new System.Drawing.Size(140, 148);
            this.pictureBox_Plate.TabIndex = 2;
            this.pictureBox_Plate.TabStop = false;
            // 
            // txtUserNo
            // 
            this.txtUserNo.EditValue = "S001";
            this.dxValidationProvider.SetIconAlignment(this.txtUserNo, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtUserNo.Location = new System.Drawing.Point(229, 34);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Properties.NullValuePrompt = "请输入用户账号...";
            this.txtUserNo.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtUserNo.Size = new System.Drawing.Size(196, 20);
            this.txtUserNo.TabIndex = 3;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider.SetValidationRule(this.txtUserNo, conditionValidationRule1);
            // 
            // txtPassword
            // 
            this.txtPassword.EditValue = "123";
            this.dxValidationProvider.SetIconAlignment(this.txtPassword, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtPassword.Location = new System.Drawing.Point(229, 81);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.NullValuePrompt = "请输入登录口令...";
            this.txtPassword.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(196, 20);
            this.txtPassword.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.dxValidationProvider.SetValidationRule(this.txtPassword, conditionValidationRule2);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(327, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 31);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消(&Esc)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(181, 127);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(116, 31);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录(&Enter)";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblUserNo
            // 
            this.lblUserNo.Location = new System.Drawing.Point(175, 37);
            this.lblUserNo.Name = "lblUserNo";
            this.lblUserNo.Size = new System.Drawing.Size(48, 13);
            this.lblUserNo.TabIndex = 7;
            this.lblUserNo.Text = "用户名：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(187, 85);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "密码：";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 187);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblUserNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserNo);
            this.Controls.Add(this.pictureBox_Plate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "欢迎使用苏州康力一卡通系统--系统登录";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Plate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Plate;
        private DevExpress.XtraEditors.TextEdit txtUserNo;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.LabelControl lblUserNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
    }
}