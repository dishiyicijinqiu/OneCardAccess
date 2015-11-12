using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
