using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using System;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.DevelopClient
{
    public partial class LoginForm : LoginForm_Design
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }


    public class LoginForm_Design : FengSharp.OneCardAccess.Infrastructure.WinForm.Base.Base_Form<LoginFormFacade>// XtraForm, IFacadeBase<LoginFormFacade>
    {
        //private LoginFormFacade _Facade;
        //public LoginFormFacade Facade
        //{
        //    get
        //    {
        //        if (_Facade == null)
        //            _Facade = new LoginFormFacade(this);
        //        return _Facade;
        //    }
        //}
    }


    public class LoginFormFacade : ActualBase<LoginForm_Design>
    {
        public LoginFormFacade(LoginForm_Design actual)
            : base(actual)
        { }

        private void GetAuthorizationTicket()
        {
            try
            {
                IAuthService iauth = ServiceProxyFactory.Create<IAuthService>();
                AuthPrincipal authprincipal = System.Threading.Thread.CurrentPrincipal as AuthPrincipal;
                AuthIdentity authidentity = authprincipal.Identity as AuthIdentity;
                authprincipal.Ticket = iauth.GetAuthorizationTicket(authidentity.UserNo, authidentity.PassWord);
                if (string.IsNullOrWhiteSpace(authprincipal.Ticket))
                {
                    throw new BusinessException(ResourceMessages.WCFExceptionType_AuthenticationException);
                }
                IAccessService iaccessservice = ServiceProxyFactory.Create<IAccessService>();
                UserEntity newUser = iaccessservice.FindUserByTicket((System.Threading.Thread.CurrentPrincipal as AuthPrincipal).Ticket);
                if (newUser == null)
                    throw new BusinessException(ResourceMessages.WCFExceptionType_AuthenticationException);
                authidentity = new AuthIdentity(newUser.UserId, newUser.UserNo, newUser.UserName, authidentity.PassWord);
                System.Threading.Thread.CurrentPrincipal = new AuthPrincipal(authidentity) { Ticket = authprincipal.Ticket };
            }
            catch (Exception ex)
            {
                System.Threading.Thread.CurrentPrincipal = null;
                throw ex;
            }
        }
        public void Login(string userNo, string userPassword)
        {
            AuthIdentity authidentity = new AuthIdentity(userNo, userPassword);
            AuthPrincipal authprincipal = new AuthPrincipal(authidentity);
            System.Threading.Thread.CurrentPrincipal = authprincipal;
            GetAuthorizationTicket();
        }
    }
}
