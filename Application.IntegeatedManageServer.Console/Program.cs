using FengSharp.OneCardAccess.Domain.BSSModule.Service;
using FengSharp.OneCardAccess.Domain.CRMModule.Service;
using FengSharp.OneCardAccess.Domain.HRModule.Service;
using FengSharp.OneCardAccess.Domain.RBACModule.Service;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Application.IntegeatedManageServer
{
    class Program
    {
        static ServiceHost[] ServiceHosts = new ServiceHost[] { 
            new ServiceHost(typeof(AuthService)),
            new ServiceHost(typeof(AccessService)),
            new ServiceHost(typeof(MenuService)),
            new ServiceHost(typeof(ActionService)),
            new ServiceHost(typeof(UserService)),
            new ServiceHost(typeof(RoleService)),
            new ServiceHost(typeof(DeptService)),
            new ServiceHost(typeof(EmployeeService)),
            new ServiceHost(typeof(DicDataService)),
            new ServiceHost(typeof(ProductService)),
            new ServiceHost(typeof(RegisterService)),
            new ServiceHost(typeof(CompanyService)),
            new ServiceHost(typeof(RawMateService)),
            new ServiceHost(typeof(StockService)),
            new ServiceHost(typeof(DlyTypeService)),
            new ServiceHost(typeof(InputLevelService)),
            new ServiceHost(typeof(DlyNdxService)),
            new ServiceHost(typeof(PFBNSNRuleService)),
        };
        public static System.Threading.Mutex RunMutex;
        static void Main(string[] args)
        {
            bool isNotRun = false;
            RunMutex = new System.Threading.Mutex(true, "一卡通管理系统服务端", out isNotRun);
            if (!isNotRun) return;
            System.Windows.Forms.Application.ApplicationExit += Application_ApplicationExit;
            //处理未捕获的异常
            System.Windows.Forms.Application.SetUnhandledExceptionMode(System.Windows.Forms.UnhandledExceptionMode.CatchException);
            //处理UI线程异常  
            System.Windows.Forms.Application.ThreadException += Application_ThreadException;
            //处理非UI线程异常  
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            for (int i = 0; i < ServiceHosts.Length; i++)
            {
                try
                {
                    ServiceHosts[i].Opened += Program_Opened;
                    ServiceHosts[i].Closed += Program_Closed;
                    ServiceHosts[i].Faulted += Program_Faulted;
                    ServiceHosts[i].Open();
                }
                catch (Exception ex)
                {
                    LogHelper.Write(ex.Message, "ServiceHostConsole", "服务启动遇到错误", System.Diagnostics.TraceEventType.Critical, 1);
                }
            }
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Form1());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            for (int i = 0; i < ServiceHosts.Length; i++)
            {
                try
                {
                    if (ServiceHosts[i].State == CommunicationState.Opened)
                        ServiceHosts[i].Close();
                }
                catch (Exception ex)
                {
                    LogHelper.Write(ex.Message, "ServiceHostConsole", "服务关闭遇到错误", System.Diagnostics.TraceEventType.Critical, 1);
                }
            }
        }

        static void Program_Faulted(object sender, EventArgs e)
        {
            var host = sender as ServiceHost;
            if (host != null)
                //Logger.Write(string.Format("{0}宿主遇到错误", host.Description.ServiceType), "ServiceHostLog", 2, -1, System.Diagnostics.TraceEventType.Error, "宿主遇到错误");
                LogHelper.Write(string.Format("{0}宿主遇到错误", host.Description.ServiceType), "ServiceHostLog", "宿主遇到错误", System.Diagnostics.TraceEventType.Error, 2);
        }

        static void Program_Closed(object sender, EventArgs e)
        {
            var host = sender as ServiceHost;
            if (host != null)
                LogHelper.Write(string.Format("{0}宿主关闭", host.Description.ServiceType), "ServiceHostLog", "宿主关闭");
            //Logger.Write(string.Format("{0}宿主关闭", host.Description.ServiceType), "ServiceHostLog", -1, -1, System.Diagnostics.TraceEventType.Information, "宿主关闭");
        }

        static void Program_Opened(object sender, EventArgs e)
        {
            var host = sender as ServiceHost;
            if (host != null)
                LogHelper.Write(string.Format("{0}宿主启动", host.Description.ServiceType), "ServiceHostLog", "宿主启动");
        }
    }
}
