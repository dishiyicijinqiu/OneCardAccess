using FengSharp.OneCardAccess.Domain.BSSModule.Entity;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface IProductFBNSelect
    {
        void BindData(PFBNBakEntity[] entitys, int StockId, int ProductId, string BN);
        PFBNBakEntity[] EntityResults { get; }
        int Qty { get; }
        string BN { get; }
    }
}
