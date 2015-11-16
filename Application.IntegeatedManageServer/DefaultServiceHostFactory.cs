using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace FengSharp.OneCardAccess.Application.IntegeatedManageServer
{
    public class DefaultServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var host = new ServiceHost(serviceType, baseAddresses);
            host.Closed += host_Closed;
            host.Faulted += host_Faulted;
            return host;
        }

        void host_Faulted(object sender, EventArgs e)
        {
        }

        void host_Closed(object sender, EventArgs e)
        {
        }
    }
}