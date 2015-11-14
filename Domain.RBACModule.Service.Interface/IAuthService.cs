using FengSharp.OneCardAccess.Infrastructure;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        AuthPrincipal GetAuthPrincipal(string UserNo, string UserPassWord);
    }
}
