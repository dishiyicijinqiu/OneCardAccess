using FengSharp.OneCardAccess.Domain.BSSModule.Entity;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface IProductSNSelect
    {
        void BindData(PSNBakEntity[] entitys, int StockId, int ProductId, string BN);
        PSNBakEntity[] EntityResults { get; }
        int Qty { get; }
        string BN { get; }
    }
}
