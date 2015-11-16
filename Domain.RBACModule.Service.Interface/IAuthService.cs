using FengSharp.OneCardAccess.Infrastructure;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        [ApplicationContextBehavior(true, false)]
        AuthPrincipal Login(string UserNo, string UserPassWord);
    }
}
