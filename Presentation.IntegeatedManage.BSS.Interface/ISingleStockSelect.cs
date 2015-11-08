using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface ISingleStockSelect
    {
        event VEventHandler<CEventArgs<StockCMEntity[]>> BeforeBind;
        StockCMEntity GetResult();
        bool IsSelect { get; }
    }
}
