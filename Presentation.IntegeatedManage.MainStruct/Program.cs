using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Plug_in_Extension;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
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
