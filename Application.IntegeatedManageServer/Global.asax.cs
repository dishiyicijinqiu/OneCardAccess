using FengSharp.OneCardAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace FengSharp.OneCardAccess.Application.IntegeatedManageServer
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Logger.Write("一卡通应用程序服务端启动服务", "ApplicationLog", -1, -1, System.Diagnostics.TraceEventType.Information, "服务启动");
            LogHelper.Write("一卡通应用程序服务端启动服务", "ApplicationLog", "服务启动");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Logger.Write("一卡通应用程序服务端发生了错误", "ApplicationLog", 1, -1, System.Diagnostics.TraceEventType.Critical, "服务遇到错误");
            LogHelper.Write("一卡通应用程序服务端发生了错误", "ApplicationLog", "服务遇到错误", System.Diagnostics.TraceEventType.Critical, 1);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            LogHelper.Write("一卡通应用程序服务端停止服务", "ApplicationLog", "服务停止");
            //Logger.Write("一卡通应用程序服务端停止服务", "ApplicationLog", -1, -1, System.Diagnostics.TraceEventType.Information, "服务停止");
        }
    }
}