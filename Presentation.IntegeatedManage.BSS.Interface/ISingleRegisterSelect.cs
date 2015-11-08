using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface ISingleRegisterSelect
    {
        event VEventHandler<CEventArgs<RegisterCMEntity[]>> BeforeBind;
        RegisterCMEntity GetResult();
        bool IsSelect { get; }
    }
}