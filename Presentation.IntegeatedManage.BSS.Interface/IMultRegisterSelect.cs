using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface
{
    public interface IMultRegisterSelect
    {
        event VEventHandler<CEventArgs<RegisterCMEntity[]>> BeforeBind;
        RegisterCMEntity[] GetResults();
        bool IsSelect { get; }
    }
}
