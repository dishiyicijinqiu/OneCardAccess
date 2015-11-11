using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface ISingleProductSelect
    {
        event VEventHandler<CEventArgs<ProductCateEntity[]>> BeforeBind;
        ProductCateEntity GetResult();
        bool IsSelect { get; }
    }
}
