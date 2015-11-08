using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Application.IntegeatedManageServer.Config
{
    public class ApplicationConfig
    {
        public static readonly int SessionTimeOutMinutes = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SessionTimeOutMinutes"]);
        public static readonly string SessionCacheName = System.Configuration.ConfigurationManager.AppSettings["SessionCacheName"];
    }
}
