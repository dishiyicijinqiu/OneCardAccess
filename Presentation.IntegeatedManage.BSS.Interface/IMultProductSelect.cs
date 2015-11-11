using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Events;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface IMultProductSelect
    {
        event VEventHandler<CEventArgs<ProductCateEntity[]>> BeforeBind;
        ProductCateEntity[] GetResults();
        bool IsSelect { get; }
    }
}
