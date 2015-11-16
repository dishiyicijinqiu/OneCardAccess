using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
namespace FengSharp.OneCardAccess.Infrastructure
{
    public class ApplicationContextBehavior : IEndpointBehavior
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
        public ApplicationContextBehavior(bool isBidirectional = false, bool sessionCheck = true)
        {
            IsBidirectional = isBidirectional;
            SessionCheck = sessionCheck;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new ApplicationContextClientMessageInspector(this.IsBidirectional));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (var operation in endpointDispatcher.DispatchRuntime.Operations)
            {
                operation.CallContextInitializers.Add(new ApplicationContextCallContextInitializer(this.IsBidirectional, this.SessionCheck));
            }
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
