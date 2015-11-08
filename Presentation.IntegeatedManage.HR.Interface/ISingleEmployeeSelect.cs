using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface
{
    public interface ISingleEmployeeSelect
    {
        event VEventHandler<CEventArgs<EmployeeCMDeptEntity[]>> BeforeBind;
        EmployeeCMDeptEntity GetResult();
        bool IsSelect { get; }
    }
}
