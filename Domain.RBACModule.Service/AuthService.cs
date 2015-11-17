using FengSharp.OneCardAccess.Application.IntegeatedManageServer.Config;
using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Caching_Handling;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class AuthService : ServiceBase, IAuthService
    {
        public AuthPrincipal Login(string UserNo, string UserPassWord)
        {
            UserPassWord = FengSharp.OneCardAccess.Infrastructure.SecurityCryptography.SecurityProvider.MD5Encrypt(UserPassWord);
            DbCommand cmd = base.Database.GetStoredProcCommand("P_AuthPrincipal");
            base.Database.AddInParameter(cmd, "UserNo", DbType.String, UserNo);
            base.Database.AddInParameter(cmd, "UserPassWord", DbType.String, UserPassWord);
            base.Database.AddOutParameter(cmd, "UserId", DbType.String, 36);
            base.Database.AddOutParameter(cmd, "UserName", DbType.String, 50);
            base.Database.ExecuteNonQuery(cmd);
            string userid = base.Database.GetParameterValue(cmd, "UserId").ToString();
            string username = base.Database.GetParameterValue(cmd, "UserName").ToString();
            // 创建用户身份验证票
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, userid, DateTime.Now, DateTime.Now.AddDays(10), true, string.Empty);
            // 加密用户身份验证票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            ApplicationContext.Current.Ticket = encryptedTicket;
            ApplicationContext.Current["ServerTime"] = DateTime.Now;
            CacheProvider.Add(encryptedTicket, ticket, TimeSpan.FromMinutes(ApplicationConfig.SessionTimeOutMinutes), cacheManagerName: ApplicationConfig.SessionCacheName);
            return new AuthPrincipal(new AuthIdentity(userid, UserNo, username));
        }
        public string GetUserIdByTicket(string ticketstring = null)
        {
            if (string.IsNullOrWhiteSpace(ticketstring))
                ticketstring = ApplicationContext.Current.Ticket;
            FormsAuthenticationTicket ticket = CacheProvider.Get<FormsAuthenticationTicket>(ApplicationContext.Current.Ticket,
              cacheManagerName: FengSharp.OneCardAccess.Application.IntegeatedManageServer.Config.ApplicationConfig.SessionCacheName);
            if (ticket == null) throw new BusinessException("非法登录");
            return ticket.Name;
        }

        //public bool VerifyAuth(string userid, Auth auth)
        //{
        //    var metadatas = auth.GetType().GetCustomAttributes(typeof(ActionNoAttribute), true);
        //    if (metadatas.Length <= 0)
        //        throw new BusinessException("未设置全系按代码");
        //    string actionno = (metadatas[0] as ActionNoAttribute).ActionNo;
        //    DbCommand cmd = this.Helper.GetStoredProcCommond("P_UserAuth");
        //    this.Helper.AddOutParameter(cmd, "IsAuth", DbType.Boolean, 2);
        //    this.Helper.AddInParameter(cmd, "UserId", DbType.String, userid);
        //    this.Helper.AddInParameter(cmd, "ActionNo", DbType.String, actionno);
        //    this.Helper.AddReturnParameter(cmd, "ReturnValue", DbType.Int32);
        //    this.Helper.ExecuteNonQuery(cmd);
        //    int code = (int)this.Helper.GetParameter(cmd, "ReturnValue").Value;
        //    if (code == -101)
        //    {
        //        throw new BusinessException("没有找到对应的权限");
        //    }
        //    else if (code != 0)
        //    {
        //        throw new Exception(FengSharp.OneCardAccess.Common.Properties.Resources.UnknowException);
        //    }
        //    object result = this.Helper.GetParameter(cmd, "IsAuth").Value;
        //    return (bool)result;
        //}
    }
}
