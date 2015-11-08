using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface ISingleInputLevelSelect
    {
        event VEventHandler<CEventArgs<DlyInputLevelInputerEntity[]>> BeforeBind;
        DlyInputLevelInputerEntity GetResult();
        bool IsSelect { get; }
    }
}
