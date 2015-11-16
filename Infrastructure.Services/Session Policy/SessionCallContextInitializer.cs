using FengSharp.OneCardAccess.Application.IntegeatedManageServer.Config;
using FengSharp.OneCardAccess.Infrastructure.Caching_Handling;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web.Security;

namespace FengSharp.OneCardAccess.Infrastructure.Services.Session_Policy
{
    internal class SessionCallContextInitializer : ICallContextInitializer//, IDispatchMessageInspector
    {
        internal static IDictionary<string, bool> NoSessions = new Dictionary<string, bool>();
        private SessionMessageHeaderInfo messageHeaderInfo;
        public SessionCallContextInitializer(SessionMessageHeaderInfo messageHeaderInfo)
        {
            this.messageHeaderInfo = messageHeaderInfo;
        }
        public void AfterInvoke(object correlationState)
        {

        }

        public object BeforeInvoke(InstanceContext instanceContext, IClientChannel channel, Message message)
        {
            if (message.Headers.Action == null)
                return null;
            string actionname = message.Headers.Action.ToLower();
            int ticketheaderindex = message.Headers.FindHeader(messageHeaderInfo.TicketName, messageHeaderInfo.Namespace);
            if (ticketheaderindex > -1)
            {
                var ticketstring = message.Headers.GetHeader<string>(messageHeaderInfo.TicketName, messageHeaderInfo.Namespace);
                var ticket = CacheProvider.Get<FormsAuthenticationTicket>(ticketstring, cacheManagerName: ApplicationConfig.SessionCacheName);
                if (ticket == null)
                {
                    if (NoSessions.ContainsKey(actionname) && NoSessions[actionname])
                        return null;
                    throw new LoginTimeOutException();
                }
                if (ticket.Expired)
                    throw new LoginTimeOutException();
                //刷新过期时间
                CacheProvider.Add(ticketstring, ticket, TimeSpan.FromMinutes(ApplicationConfig.SessionTimeOutMinutes), cacheManagerName: ApplicationConfig.SessionCacheName);
            }
            else
            {
                if (!NoSessions.ContainsKey(actionname))
                {
                    throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.InvalidTicket);
                }
                if (!NoSessions[actionname])
                {
                    throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.InvalidTicket);
                }
            }
            return null;
        }

        //private string _ticketstring = null;
        //public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        //{
        //    int ticketheaderindex = request.Headers.FindHeader(messageHeaderInfo.TicketName, messageHeaderInfo.Namespace);
        //    if (ticketheaderindex > -1)
        //    {
        //        _ticketstring = request.Headers.GetHeader<string>(messageHeaderInfo.TicketName, messageHeaderInfo.Namespace);
        //    }
        //    else
        //    {
        //        _ticketstring = null;
        //    }
        //    return null;
        //}

        //public void BeforeSendReply(ref Message reply, object correlationState)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrWhiteSpace(_ticketstring))
        //        {
        //            var ticket = CacheProvider.Get<FormsAuthenticationTicket>(_ticketstring, cacheManagerName: ApplicationConfig.SessionCacheName);
        //            CacheProvider.Remove(_ticketstring, cacheManagerName: ApplicationConfig.SessionCacheName);

        //            // 创建用户身份验证票,过期时间30分钟
        //            ticket = new FormsAuthenticationTicket(ticket.Name, false, ApplicationConfig.SessionTimeOutMinutes);
        //            // 加密用户身份验证票
        //            string newticketstring = FormsAuthentication.Encrypt(ticket);

        //            CacheProvider.Add(newticketstring, ticket,
        //                System.TimeSpan.FromMinutes(ApplicationConfig.SessionTimeOutMinutes), cacheManagerName: ApplicationConfig.SessionCacheName);

        //            reply.Headers.Add(MessageHeader.CreateHeader(this.messageHeaderInfo.TicketName,
        //          this.messageHeaderInfo.Namespace, newticketstring));
        //            _ticketstring = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //}
    }
}
