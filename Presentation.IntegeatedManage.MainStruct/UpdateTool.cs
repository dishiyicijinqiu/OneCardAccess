using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct.Interface;
using NAppUpdate.Framework;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Sources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinFormsSampleApp;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct
{
    public class CheckUpdateTool
    {
        internal static void Init()
        {
            UpdateManager updManager = UpdateManager.Instance;
            updManager.UpdateSource = new SimpleWebSource(System.Configuration.ConfigurationManager.AppSettings["UpdateURL"]);
            updManager.Config.TempFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Presentation.IntegeatedManage.MainStruct\\Updates");
            updManager.ReinstateIfRestarted();
        }
        internal static void StartCheck()
        {
            Thread thread = new Thread(new ParameterizedThreadStart(RunCheckUpdates));
            thread.IsBackground = true;
            thread.Start(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }

        static void RunCheckUpdates(object para)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Assign(para as DevExpress.LookAndFeel.UserLookAndFeel);
            while (true)
            {
                try
                {
                    UpdateManager updManager = UpdateManager.Instance;
                    try
                    {
                        if (updManager.State != UpdateManager.UpdateProcessState.NotChecked) return;
                        updManager.CleanUp();
                        updManager.CheckForUpdates();
                    }
                    catch (Exception ex)
                    {
                        if (ex is NAppUpdateException) MessageBoxEx.Error("更新数据有误", owner: GetOwnerForm());
                        else MessageBoxEx.Error(ex, owner: GetOwnerForm());
                    }
                    if (updManager.UpdatesAvailable <= 0) return;
                    DialogResult dr = MessageBoxEx.YesNoInfo(string.Format("软件有{0}个更新，是否现在下载更新？", updManager.UpdatesAvailable), owner: GetOwnerForm());
                    if (dr == DialogResult.Yes) updManager.BeginPrepareUpdates(OnPrepareUpdatesCompleted, para);
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000 * 20 * 1);
            }
        }
        static DevExpress.XtraEditors.XtraForm GetOwnerForm()
        {
            var ilogin = ServiceLoader.LoadService<ILogin>();
            while (ilogin.IsLoading)
            {
                Thread.Sleep(100);
            }
            var loginform = ilogin as DevExpress.XtraEditors.XtraForm;
            if (loginform.Visible)
                return loginform;
            var mainform = ServiceLoader.LoadService<IMainForm>() as DevExpress.XtraEditors.XtraForm;
            Thread.Sleep(3000);
            return mainform;
        }
        public static void CheckUpdates()
        {
            UpdateManager updManager = UpdateManager.Instance;
            try
            {
                updManager.CleanUp();
                updManager.CheckForUpdates();
            }
            catch (Exception ex)
            {
                if (ex is NAppUpdateException) MessageBoxEx.Error("更新数据有误", owner: GetOwnerForm());
                else MessageBoxEx.Error(ex, owner: GetOwnerForm());
                return;
            }
            if (updManager.UpdatesAvailable <= 0) { MessageBoxEx.Info("没有可用的更新", owner: GetOwnerForm()); return; }
            DialogResult dr = MessageBoxEx.YesNoInfo(string.Format("软件有{0}个更新，是否现在下载更新？", updManager.UpdatesAvailable), owner: GetOwnerForm());
            if (dr == DialogResult.Yes) updManager.BeginPrepareUpdates(OnPrepareUpdatesCompleted, DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }

        private static void OnPrepareUpdatesCompleted(IAsyncResult asyncResult)
        {
            var para = asyncResult.AsyncState as DevExpress.LookAndFeel.UserLookAndFeel;
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Assign(para);
            try
            {
                ((UpdateProcessAsyncResult)asyncResult).EndInvoke();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(string.Format("更新失败，请重新检查更新.{0}{1}", Environment.NewLine, ex), owner: GetOwnerForm());
                return;
            }
            UpdateManager updManager = UpdateManager.Instance;
            DialogResult dr = MessageBoxEx.YesNoInfo("更新准备完成，是否现在安装？", owner: GetOwnerForm());
            if (dr != DialogResult.Yes) { updManager.CleanUp(); return; }
            try
            {
                updManager.ApplyUpdates(true, false, false);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(string.Format("安装失败{0}{1}", Environment.NewLine, ex), owner: GetOwnerForm());
            }
        }
    }
}
