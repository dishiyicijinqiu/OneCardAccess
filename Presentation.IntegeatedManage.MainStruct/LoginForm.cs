using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
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
        private bool _IsLoading = false;
        public bool IsLoading
        {
            get
            {
                return _IsLoading;
            }
        }

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
                this._IsLoading = true;
                if (!this.dxValidationProvider.Validate())
                    return;
                if (!splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.Infomation_Title);
                splashScreenManager1.SetWaitFormDescription(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.LoadingDataPleaseWait);
                Login(this.txtUserNo.Text, this.txtPassword.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();
                Infrastructure.WinForm.Controls.MessageBoxEx.Error(ex);
            }
            finally
            {
                this._IsLoading = false;
                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();
            }
        }

        public bool Login()
        {
            this.Text = "欢迎使用苏州康力一卡通系统--系统登录";
            bool result = InterLogin();
            FengSharp.OneCardAccess.Infrastructure.WinForm.Controls.BarTimeItem.ServerTime =
            (DateTime)FengSharp.OneCardAccess.Infrastructure.ApplicationContext.Current["ServerTime"];
            MenuHelper.LoadMenu((ServiceLoader.LoadService<IMainForm>() as MainForm).ribbon);
            MenuHelper.SetUserMenu((ServiceLoader.LoadService<IMainForm>() as MainForm).ribbon);
            return result;
        }
        private bool InterLogin()
        {
            this.txtUserNo.EditValue = Application.IntegeatedManage.Config.Properties.Settings.Default.UserNo;
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            Application.IntegeatedManage.Config.Properties.Settings.Default.UserNo =
                this.txtUserNo.EditValue == null ? string.Empty : this.txtUserNo.EditValue.ToString();
            Application.IntegeatedManage.Config.Properties.Settings.Default.Save();
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
