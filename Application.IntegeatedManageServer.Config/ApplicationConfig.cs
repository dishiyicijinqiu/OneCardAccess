using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Application.IntegeatedManageServer.Config
{
    public class ApplicationConfig
    {
        private static int _SessionTimeOutMinutes = -1;
        public static int SessionTimeOutMinutes
        {
            get
            {
                if (_SessionTimeOutMinutes == -1)
                {
                    _SessionTimeOutMinutes = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SessionTimeOutMinutes"]);
                }
                return _SessionTimeOutMinutes;
            }
        }
        private static string _SessionCacheName;
        public static string SessionCacheName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_SessionCacheName))
                {
                    _SessionCacheName = System.Configuration.ConfigurationManager.AppSettings["SessionCacheName"];
                }
                return _SessionCacheName;
            }
        }
    }
}
