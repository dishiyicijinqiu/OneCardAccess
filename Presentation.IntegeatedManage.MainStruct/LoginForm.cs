﻿using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct.Interface;
using System;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct
{
    public partial class LoginForm : LoginForm_Design, ILogin, ITimeOutLogin
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //ServiceProxyFactory.Create<IMenuService>().GetAllEntity();
            this.Facade = new LoginFormFacade(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.dxValidationProvider.Validate())
                    return;
                Login(this.txtUserNo.Text, this.txtPassword.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                FengSharp.OneCardAccess.Infrastructure.WinForm.Controls.MessageBoxEx.Error(ex);
            }
        }

        public bool Login()
        {
            this.Text = "欢迎使用苏州康力一卡通系统--系统登录";
            return InterLogin();
        }
        private bool InterLogin()
        {
            var result = this.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                return true;
            }
            else
                return false;
        }

        #region ILoginPresenter
        public void Login(string userNo, string userPassword)
        {
            this.Facade.Login(userNo, userPassword);
        }
        #endregion

        private void btnCanCle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public bool TimeOutLogin()
        {
            this.Text = "登录超时，请重新登录";
            return InterLogin();
        }
    }


    public partial class LoginForm_Design : Base_Form<LoginFormFacade>
    {
    }


    public class LoginFormFacade : ActualBase<LoginForm>
    {
        IAuthService iauth = ServiceProxyFactory.Create<IAuthService>();
        public LoginFormFacade(LoginForm actual)
            : base(actual)
        { }

        public void Login(string userNo, string userPassword)
        {
            try
            {
                AuthPrincipal.CurrentAuthPrincipal = iauth.Login(userNo, userPassword);
            }
            catch (Exception ex)
            {
                AuthPrincipal.CurrentAuthPrincipal = null;
                throw ex;
            }
        }
    }
}
