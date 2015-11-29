using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Plug_in_Extension;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct.Interface;
using NAppUpdate.Framework;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Sources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct
{
    static class Program
    {
        public static System.Threading.Mutex RunMutex;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isNotRun = false;
            RunMutex = new System.Threading.Mutex(true, "一卡通管理系统", out isNotRun);
            if (!isNotRun) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region 语言设置
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-cn");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-cn");
            #endregion
            #region 异常处理
            //处理未捕获的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常  
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常  
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            #endregion

            UpdateManager updManager = UpdateManager.Instance;
            updManager.UpdateSource = new SimpleWebSource("http://www.kangli.com/Update/SampleUpdateFeed.xml");
            updManager.Config.TempFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Presentation.IntegeatedManage.MainStruct\\Updates");
            // If you don't call this method, the updater.exe will continually attempt to connect the named pipe and get stuck.
            // Therefore you should always implement this method call.  
            updManager.ReinstateIfRestarted();
            //string feedXml = File.ReadAllText("SampleUpdateFeed.xml");
            //IUpdateSource feedSource = new MemorySource(feedXml);
            CheckForUpdates(updManager.UpdateSource);
            //CheckUpdateTool.Run();

            #region 加载插件路径
            PlugExtensionFactory.AppendPrivatePath();
            #endregion
            #region 注册DevExpress皮肤
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
            #endregion
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(StartSplashScreen));
            MainForm mainform = ServiceLoader.LoadService<IMainForm>() as MainForm;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
            Application.Run(mainform);
        }
        static void CheckForUpdates(IUpdateSource source)
        {
            // Get a local pointer to the UpdateManager instance
            UpdateManager updManager = UpdateManager.Instance;

            // Only check for updates if we haven't done so already
            if (updManager.State != UpdateManager.UpdateProcessState.NotChecked)
            {
                MessageBox.Show("Update process has already initialized; current state: " + updManager.State.ToString());
                return;
            }

            try
            {

                // Check for updates - returns true if relevant updates are found (after processing all the tasks and
                // conditions)
                // Throws exceptions in case of bad arguments or unexpected results
                updManager.CheckForUpdates(source);
            }
            catch (Exception ex)
            {
                if (ex is NAppUpdateException)
                {
                    // This indicates a feed or network error; ex will contain all the info necessary
                    // to deal with that 
                }
                else MessageBox.Show(ex.ToString());
                return;
            }

            DialogResult dr = MessageBox.Show(string.Format("Updates are available to your software ({0} total). Do you want to download and prepare them now? You can always do this at a later time.", updManager.UpdatesAvailable), "Software updates available", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes) updManager.BeginPrepareUpdates(OnPrepareUpdatesCompleted, null);
        }

        private static void OnPrepareUpdatesCompleted(IAsyncResult asyncResult)
        {
            try
            {
                ((UpdateProcessAsyncResult)asyncResult).EndInvoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Updates preperation failed. Check the feed and try again.{0}{1}", Environment.NewLine, ex));
                return;
            }

            // Get a local pointer to the UpdateManager instance
            UpdateManager updManager = UpdateManager.Instance;

            DialogResult dr = MessageBox.Show("Updates are ready to install. Do you wish to install them now?", "Software updates ready", MessageBoxButtons.YesNo);

            if (dr != DialogResult.Yes) return;
            // This is a synchronous method by design, make sure to save all user work before calling
            // it as it might restart your application
            try
            {
                updManager.ApplyUpdates(true, true, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error while trying to install software updates{0}{1}", Environment.NewLine, ex));
            }
        }

        #region 处理未捕获异常的挂钩函数
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception error = e.Exception as Exception;
            if (error != null)
            {
                MessageBoxEx.Error(error, FengSharp.OneCardAccess.Infrastructure.ResourceMessages.UnKnowErrorTitle);
            }
            else
            {
                MessageBoxEx.Error(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.UnKnowErrorTitle);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = e.ExceptionObject as Exception;
            if (error != null)
            {
                MessageBoxEx.Error(error, FengSharp.OneCardAccess.Infrastructure.ResourceMessages.UnKnowErrorTitle);
            }
            else
            {
                MessageBoxEx.Error(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.UnKnowErrorTitle);
            }
        }

        #endregion
    }
}
