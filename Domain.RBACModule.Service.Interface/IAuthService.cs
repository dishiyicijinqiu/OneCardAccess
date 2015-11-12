using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Session_Policy;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        [NoSession]
        AuthPrincipal GetAuthPrincipal(string UserNo, string UserPassWord);
    }
}
