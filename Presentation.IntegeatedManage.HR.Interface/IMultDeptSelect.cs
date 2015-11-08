using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface
{
    public interface IMultDeptSelect
    {
        event VEventHandler<CEventArgs<DeptCMCateEntity[]>> BeforeBind;
        DeptCMCateEntity[] GetResults();
        bool IsSelect { get; }
    }
}
