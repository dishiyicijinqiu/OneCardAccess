using FengSharp.OneCardAccess.Domain.RBACModule.Entity;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.Interface
{
    public interface IClientUserSerice
    {
        [Infrastructure.Caching_Handling.Caching(true)]
        UserEntity FindUserByIdFromCache(string UserId);
    }
}
