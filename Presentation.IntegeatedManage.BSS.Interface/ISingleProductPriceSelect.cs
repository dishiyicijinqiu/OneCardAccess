using FengSharp.OneCardAccess.Infrastructure.Events;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface ISingleProductPriceSelect
    {
        void BindData(int entityid);
        double GetResult();
        bool IsSelect { get; }
    }
}
