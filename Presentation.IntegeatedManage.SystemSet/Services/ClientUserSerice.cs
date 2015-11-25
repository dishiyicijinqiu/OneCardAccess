using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.Interface;
using System;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public class ClientUserSerice : IClientUserSerice
    {
        public UserEntity FindUserByIdFromCache(string UserId)
        {
            return ServiceProxyFactory.Create<IUserService>().FindUserById(UserId);
        }
    }
}
