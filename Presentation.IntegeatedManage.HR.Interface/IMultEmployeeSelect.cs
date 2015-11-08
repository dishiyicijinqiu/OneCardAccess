using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface
{
    public interface IMultEmployeeSelect
    {
        event VEventHandler<CEventArgs<EmployeeCMDeptEntity[]>> BeforeBind;
        EmployeeCMDeptEntity[] GetResults();
        bool IsSelect { get; }
    }
}
