using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class ProductFBNSelectUserControl : ProductFBNSelectUserControl_Design
    {
        public ProductFBNSelectUserControl()
        {
            InitializeComponent();
        }

        private void ProductFBNSelectUserControl_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.DesignMode)
                    return;
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                    return;
                CreateFacade();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void CreateFacade()
        {
            if (this.Facade == null)
                this.Facade = new ProductFBNSelectUserControlFacade(this);
        }

        public PFBNBakEntity[] EntityResults
        {
            get
            {
                return (bindingSource1.DataSource as List<FBNSelectEntity>).Where(t => t.Qty > 0).
                    Select(t =>
                    new PFBNBakEntity()
                    {
                        BN = t.BN,
                        FullBN = t.FullBN,
                        Qty = t.Qty,
                        SortNo = t.SortNo,
                        Remark = t.Remark
                    }
                    ).ToArray();
            }
        }
        internal void BindData(PFBNBakEntity[] entitys, int StockId, int ProductId, string BN)
        {
            var data = new List<FBNSelectEntity>();
            PFBNInventEntity[] inventEntitys = this.Facade.GetBindEntitys(StockId, ProductId, BN);

            data.AddRange(
                inventEntitys.Select(
                    t => new FBNSelectEntity()
                    {
                        BN = t.BN,
                        FullBN = t.FullBN,
                        Qty = (int)t.Qty,
                        Remark = string.Empty,
                        SelectQty = 0,
                        SortNo = int.MaxValue
                    }
                )
                );
            foreach (var item in entitys)
            {
                var dataitem = data.FirstOrDefault(t => t.FullBN == item.FullBN);
                if (dataitem == null)
                {
                    dataitem = new FBNSelectEntity()
                    {
                        BN = item.BN,
                        FullBN = item.FullBN,
                        Qty = 0,
                        Remark = string.Empty,
                        SelectQty = 0,
                        SortNo = 0
                    };
                    data.Add(dataitem);
                }
                dataitem.SelectQty = (int)item.Qty;
                dataitem.Remark = item.Remark;
                dataitem.SortNo = item.SortNo;
            }
            data.Sort(new FBNSelectComparer());
            this.bindingSource1.DataSource = data;
            this.gridControl1.DataSource = bindingSource1;
        }
        class FBNSelectComparer : IComparer<FBNSelectEntity>
        {
            public int Compare(FBNSelectEntity x, FBNSelectEntity y)
            {
                if (x.SortNo == y.SortNo)
                    return 0;
                else if (x.SortNo > y.SortNo)
                    return 1;
                return -1;
            }
        }
    }
    public class ProductFBNSelectUserControl_Design : Base_UserControl<ProductFBNSelectUserControlFacade>
    {

    }
    public class ProductFBNSelectUserControlFacade : ActualBase<ProductFBNSelectUserControl>
    {
        private IDlyNdxService _DlyNdxService = ServiceProxyFactory.Create<IDlyNdxService>();
        public ProductFBNSelectUserControlFacade(ProductFBNSelectUserControl actual)
            : base(actual)
        { }

        internal PFBNInventEntity[] GetBindEntitys(int stockId, int productId, string bn)
        {
            return _DlyNdxService.GetPFBNInventEntity(stockId, productId, bn);
        }
    }
}
