using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface ISingleDlyTypeSelect
    {
        event VEventHandler<CEventArgs<DlyTypeCateEntity[]>> BeforeBind;
        DlyTypeCateEntity GetResult();
        bool IsSelect { get; }
    }
}
