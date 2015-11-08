using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
using System;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet.Interface
{
    public interface IMultiUserSelect
    {
        event VEventHandler<CEventArgs<UserEntity[]>> BeforeBind;
        UserEntity[] GetResults();
        bool IsSelect { get; }
    }
    
}
