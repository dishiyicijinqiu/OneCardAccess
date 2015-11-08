using FengSharp.OneCardAccess.Infrastructure.Caching_Handling;
using FengSharp.OneCardAccess.Infrastructure.Session_Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        [NoSession]
        string GetAuthorizationTicket(string UserNo, string UserPassWord);
    }
}
