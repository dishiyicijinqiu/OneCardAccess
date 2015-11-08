using System;

namespace FengSharp.OneCardAccess.Infrastructure.Exceptions
{
    [System.Serializable]
    public class LoginTimeOutException : Exception
    {
        public override string Message
        {
            get
            {
                return "登录超时";
            }
        }
    }
}
