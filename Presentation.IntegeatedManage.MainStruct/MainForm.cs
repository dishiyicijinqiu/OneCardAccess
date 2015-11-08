using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTabbedMdi;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct.Interface;
using System;
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
                    MenuHelper.LoadMenu(this.ribbon);
                    MenuHelper.SetUserMenu(this.ribbon);
                    this.Visible = true;
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                case CloseReason.WindowsShutDown:
                case CloseReason.TaskManagerClosing:
                    break;
                case CloseReason.FormOwnerClosing:
                case CloseReason.MdiFormClosing:
                case CloseReason.None:
                case CloseReason.UserClosing:
                    FengSharp.WinForm.Dev.Forms.Form_Exit form = new WinForm.Dev.Forms.Form_Exit();
                    var diaResult = form.ShowDialog();
                    if (diaResult == System.Windows.Forms.DialogResult.Retry)
                    {
                        Application.Restart();
                    }
                    else if (diaResult == System.Windows.Forms.DialogResult.Yes)
                    {

                    }
                    else
                    {
                        e.Cancel = true;
                    }
                    break;
            }
        }

        public void ReLoad()
        {
        }
    }
}
