using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface
{
    public interface ISingleDeptSelect
    {
        event VEventHandler<CEventArgs<DeptCMCateEntity[]>> BeforeBind;
        DeptCMCateEntity GetResult();
        bool IsSelect { get; }
    }
}