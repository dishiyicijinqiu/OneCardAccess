using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace FengSharp.OneCardAccess.Application.IntegeatedManageServer
{
    public class DefaultServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new ServiceHost(serviceType, baseAddresses);
        }
    }
}