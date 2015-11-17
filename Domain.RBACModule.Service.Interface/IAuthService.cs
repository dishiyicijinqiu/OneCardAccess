using FengSharp.OneCardAccess.Infrastructure;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        [ApplicationContextBehavior(true, false)]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        AuthPrincipal Login(string UserNo, string UserPassWord);
        string GetUserIdByTicket(string ticketstring = null);
    }
}
