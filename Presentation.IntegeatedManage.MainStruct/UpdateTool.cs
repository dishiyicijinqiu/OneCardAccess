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
            DevExpress.XtraEditors.XtraForm mainform = ServiceLoader.LoadService<IMainForm>() as DevExpress.XtraEditors.XtraForm;
            DevExpress.XtraEditors.XtraForm login = ServiceLoader.LoadService<ILogin>() as DevExpress.XtraEditors.XtraForm;
            UpdateManager updManager = UpdateManager.Instance;
            try
            {
                updManager.CleanUp();
                updManager.CheckForUpdates();
            }
            catch (Exception ex)
            {
                if (ex is NAppUpdateException) MessageBoxEx.Error("更新数据有误", owner: mainform.Visible ? mainform : login);
                else MessageBoxEx.Error(ex, owner: mainform.Visible ? mainform : login);
            }
            if (updManager.UpdatesAvailable <= 0) return;
            DialogResult dr = MessageBoxEx.YesNoInfo(string.Format("软件有{0}个更新，是否现在下载更新？", updManager.UpdatesAvailable), owner: mainform.Visible ? mainform : login);
            if (dr == DialogResult.Yes) updManager.BeginPrepareUpdates(OnPrepareUpdatesCompleted, para);
        }
        public static void CheckUpdates()
        {
            DevExpress.XtraEditors.XtraForm mainform = ServiceLoader.LoadService<IMainForm>() as DevExpress.XtraEditors.XtraForm;
            DevExpress.XtraEditors.XtraForm login = ServiceLoader.LoadService<ILogin>() as DevExpress.XtraEditors.XtraForm;
            UpdateManager updManager = UpdateManager.Instance;
            try
            {
                updManager.CleanUp();
                updManager.CheckForUpdates();
            }
            catch (Exception ex)
            {
                if (ex is NAppUpdateException) MessageBoxEx.Error("更新数据有误", owner: mainform.Visible ? mainform : login);
                else MessageBoxEx.Error(ex, owner: mainform.Visible ? mainform : login);
                return;
            }
            if (updManager.UpdatesAvailable <= 0) { MessageBoxEx.Info("没有可用的更新", owner: mainform.Visible ? mainform : login); return; }
            DialogResult dr = MessageBoxEx.YesNoInfo(string.Format("软件有{0}个更新，是否现在下载更新？", updManager.UpdatesAvailable), owner: mainform.Visible ? mainform : login);
            if (dr == DialogResult.Yes) updManager.BeginPrepareUpdates(OnPrepareUpdatesCompleted, DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }

        private static void OnPrepareUpdatesCompleted(IAsyncResult asyncResult)
        {
            var para = asyncResult.AsyncState as DevExpress.LookAndFeel.UserLookAndFeel;
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Assign(para);
            DevExpress.XtraEditors.XtraForm mainform = ServiceLoader.LoadService<IMainForm>() as DevExpress.XtraEditors.XtraForm;
            DevExpress.XtraEditors.XtraForm login = ServiceLoader.LoadService<ILogin>() as DevExpress.XtraEditors.XtraForm;
            try
            {
                ((UpdateProcessAsyncResult)asyncResult).EndInvoke();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(string.Format("更新失败，请重新检查更新.{0}{1}", Environment.NewLine, ex), owner: mainform.Visible ? mainform : login);
                return;
            }
            UpdateManager updManager = UpdateManager.Instance;
            DialogResult dr = MessageBoxEx.YesNoInfo("更新准备完成，是否现在安装？", owner: mainform.Visible ? mainform : login);
            if (dr != DialogResult.Yes) return;
            try
            {
                updManager.ApplyUpdates(true, false, false);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(string.Format("安装失败{0}{1}", Environment.NewLine, ex), owner: mainform.Visible ? mainform : login);
            }
        }
    }
}
