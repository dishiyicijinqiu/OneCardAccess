using FengSharp.OneCardAccess.Infrastructure.Session_Policy;
using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace FengSharp.OneCardAccess.Infrastructure.Services.Session_Policy
{
    public class SessionServerBehavior : IServiceBehavior//, IContractBehavior, IOperationBehavior, IEndpointBehavior
    {
        private SessionMessageHeaderInfo messageHeaderInfo;
        public const string DefaultNamespace = "http://www.fengsharp.com/session";
        public const string DefaultTicketName = "TicketName";
        public string Namespace { get; set; }
        public string TicketName { get; set; }
        public SessionServerBehavior()
        {
            messageHeaderInfo = new SessionMessageHeaderInfo
            {
                Namespace = DefaultNamespace,
                TicketName = DefaultTicketName,
            };
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase,
            System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            foreach (ServiceEndpoint endpoint in serviceDescription.Endpoints)
            {
                var type = endpoint.Contract.ContractType;
                foreach (OperationDescription operation in endpoint.Contract.Operations)
                {
                    var method = operation.SyncMethod;
                    foreach (MessageDescription msg in operation.Messages)
                    {
                        string actionname = msg.Action.ToLower();
                        var nosessions = method.GetCustomAttributes(typeof(NoSessionAttribute), true);
                        if (nosessions == null || nosessions.Length == 0)
                            SessionCallContextInitializer.NoSessions.Add(actionname, false);
                        else
                            SessionCallContextInitializer.NoSessions.Add(actionname, true);
                    }
                }
            }
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpoint in channelDispatcher.Endpoints)
                {
                    //endpoint.DispatchRuntime.MessageInspectors.Add(new SessionCallContextInitializer(messageHeaderInfo));
                    foreach (DispatchOperation operation in endpoint.DispatchRuntime.Operations)
                    {
                        operation.CallContextInitializers.Add(new SessionCallContextInitializer(messageHeaderInfo));
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }
    }
}
