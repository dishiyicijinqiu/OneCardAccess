using FengSharp.OneCardAccess.Infrastructure.Caching_Handling;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web.Security;

namespace FengSharp.OneCardAccess.Infrastructure
{
    public class ApplicationContextCallContextInitializer : ICallContextInitializer
    {
        public bool IsBidirectional
        { get; set; }
        public bool SessionCheck
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isBidirectional">是否为双向传递</param>
        /// <param name="sessionCheck">是否检测会话状态</param>
        public ApplicationContextCallContextInitializer(bool isBidirectional = false, bool sessionCheck = true)
        {
            IsBidirectional = isBidirectional;
            SessionCheck = sessionCheck;
        }

        public void AfterInvoke(object correlationState)
        {
            if (!this.IsBidirectional)
            {
                return;
            }
            ApplicationContext context = correlationState as ApplicationContext;
            if (context == null)
            {
                return;
            }
            MessageHeader<ApplicationContext> contextHeader = new MessageHeader<ApplicationContext>(context);
            OperationContext.Current.OutgoingMessageHeaders.Add(contextHeader.GetUntypedHeader(ApplicationContext.ContextHeaderLocalName, ApplicationContext.ContextHeaderNamespace));
            ApplicationContext.Current = null;
        }

        public object BeforeInvoke(InstanceContext instanceContext, IClientChannel channel, Message message)
        {
            ApplicationContext context = message.Headers.GetHeader<ApplicationContext>(ApplicationContext.ContextHeaderLocalName, ApplicationContext.ContextHeaderNamespace);
            if (context == null)
            {
                if (this.SessionCheck)
                    throw new BusinessException("服务设置为会话检测，但当前上下文不可用");
                return null;
            }
            //context.Ticket
            if (this.SessionCheck)
            {
                //var ticket = CacheProvider.Get<FormsAuthenticationTicket>(context.Ticket, cacheManagerName: SessionCacheName);
                //if (ticket == null || ticket.Expired)
                //    throw new LoginTimeOutException();
                //CacheProvider.Add(context.Ticket, ticket, TimeSpan.FromMinutes(SessionTimeOutMinutes), cacheManagerName: SessionCacheName);
            }
            ApplicationContext.Current = context;
            return ApplicationContext.Current;
        }

        private static int _SessionTimeOutMinutes = -1;
        static int SessionTimeOutMinutes
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
        static string SessionCacheName
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
