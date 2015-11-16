using FengSharp.OneCardAccess.Domain.BSSModule.Entity;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface
{
    public interface IProductFBNInput
    {
        void BindData(FBNInputEntity[] entitys);
        FBNInputEntity[] EntityResults { get; }
        int Qty { get; }
        string BN { get; }
    }
}
