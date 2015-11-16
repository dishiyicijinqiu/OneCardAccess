using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace FengSharp.OneCardAccess.Infrastructure.Session_Policy
{
    public class SessionClientBehavior : IEndpointBehavior
    {
        private SessionMessageHeaderInfo messageHeaderInfo;
        public const string DefaultNamespace = "http://www.fengsharp.com/session";
        public const string DefaultTicketName = "TicketName";
        public string Namespace { get; set; }
        public string TicketName { get; set; }
        public SessionClientBehavior()
        {
            messageHeaderInfo = new SessionMessageHeaderInfo
            {
                Namespace = DefaultNamespace,
                TicketName = DefaultTicketName,
            };
        }
        #region IEndpointBehavior
        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new SessionClientMessageInspector(messageHeaderInfo));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
        #endregion
    }
}
