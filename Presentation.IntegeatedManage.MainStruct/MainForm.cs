using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTabbedMdi;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct.Interface;
using System;
using System.Linq;
using System.Windows.Forms;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            new ThumbnailHintHelper(this.xtraTabbedMdiManager);
        }
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.Visible = false;
                var login = FengSharp.OneCardAccess.Infrastructure.ServiceLoader.LoadService<ILogin>();
                if (login.Login())
                {
                    this.Visible = true;
                    FengSharp.OneCardAccess.Infrastructure.WinForm.Controls.BarTimeItem.ServerTime =
                    (DateTime)FengSharp.OneCardAccess.Infrastructure.ApplicationContext.Current["ServerTime"];
                    MenuHelper.LoadMenu(this.ribbon);
                    MenuHelper.SetUserMenu(this.ribbon);
                    this.barItemUser.Caption = FengSharp.OneCardAccess.Infrastructure.AuthPrincipal.CurrentAuthPrincipal.AuthIdentity.UserName;
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                Application.Exit();
            }
        }



        #region 子窗体关闭菜单，事件
        private void xtraTabbedMdiManager_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            XtraTabbedMdiManager tabManage = sender as XtraTabbedMdiManager;
            BaseTabHitInfo hint = tabManage.CalcHitInfo(e.Location);
            if (hint.IsValid && (hint.Page != null))
            {
                if (tabManage.SelectedPage.MdiChild != null)
                {
                    this.popupMenu.ShowPopup(MousePosition);
                }
            }
        }

        private void btnCloseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = xtraTabbedMdiManager.Pages.Count - 1; i >= 0; i--)
            {
                var page = xtraTabbedMdiManager.Pages[i];
                page.MdiChild.Close();
            }
        }

        private void btnCloseCurrent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraTabbedMdiManager.SelectedPage.MdiChild.Close();
        }

        private void btnCloseOther_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int pageIndex = xtraTabbedMdiManager.Pages.IndexOf(xtraTabbedMdiManager.SelectedPage);
            for (int i = xtraTabbedMdiManager.Pages.Count - 1; i >= 0; i--)
            {
                if (i == pageIndex)
                    continue;
                var page = xtraTabbedMdiManager.Pages[i];
                page.MdiChild.Close();
            }
        }
        #endregion

        const int WM_SYSCOMMAND = 0x0112;
        const int SC_CLOSE = 0xF060;
        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
                {
                    var diaResult = FengSharp.WinForm.Dev.Forms.ExitMessageBox.Show();
                    if (diaResult == System.Windows.Forms.DialogResult.Retry)
                    {
                        SafeRestart();
                    }
                    else if (diaResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        SafeExit();
                    }
                    return;
                }
                base.WndProc(ref m);
            }
            catch (Exception ex)
            {
                FengSharp.OneCardAccess.Infrastructure.WinForm.Controls.MessageBoxEx.Error(ex);
            }
        }

        void SafeRestart()
        {
            if (!CloseAllMdiChild())
                return;
            Program.RunMutex.Close();
            Application.Restart();
        }
        bool CloseAllMdiChild()
        {
            for (int i = xtraTabbedMdiManager.Pages.Count - 1; i >= 0; i--)
            {
                var page = xtraTabbedMdiManager.Pages[i];
                if (!CloseMdiChild(page.MdiChild))
                {
                    return false;
                }
            }
            return true;
        }
        bool CloseMdiChild(Form mdiChild)
        {
            mdiChild.Close();
            return !mdiChild.Visible;
        }
        void SafeExit()
        {
            if (!CloseAllMdiChild())
                return;
            Program.RunMutex.Close();
            Application.Exit();
        }

        public void ReLoad()
        {
        }


        public T[] FindForms<T>() where T : class
        {
            return xtraTabbedMdiManager.Pages.Where(t => t.MdiChild is T).Select(m => m.MdiChild as T).ToArray();
        }
    }
}
