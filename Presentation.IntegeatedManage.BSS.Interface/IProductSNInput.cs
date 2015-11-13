using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface IProductSNInput
    {
        void BindData(SNInputEntity[] entitys);
        SNInputEntity[] EntityResults { get; }
        int Qty { get; }
        string BN { get; }
    }
}
