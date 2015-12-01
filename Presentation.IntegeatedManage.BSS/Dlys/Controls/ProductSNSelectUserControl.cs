using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class ProductSNSelectUserControl : ProductSNSelectUserControl_Design
    {
        public ProductSNSelectUserControl()
        {
            InitializeComponent();
        }

        private void ProductSNSelectUserControl_Load(object sender, EventArgs e)
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
                this.Facade = new ProductSNSelectUserControlFacade(this);
        }
        public PSNBakEntity[] EntityResults
        {
            get
            {
                return (bindingSource1.DataSource as List<SNSelectEntity>).Where(t => t.IsSelect).
                    Select(t =>
                    new PSNBakEntity()
                    {
                        BN = t.BN,
                        SN = t.SN,
                        SortNo = t.SortNo,
                        Remark = t.Remark
                    }
                    ).ToArray();
            }
        }
        internal void BindData(PSNBakEntity[] entitys, int StockId, int ProductId, string BN)
        {
            CreateFacade();
            var data = new List<SNSelectEntity>();
            PSNInventEntity[] inventEntitys = this.Facade.GetBindEntitys(StockId, ProductId, BN);
            data.AddRange(
                inventEntitys.Select(
                    t => new SNSelectEntity()
                    {
                        BN = t.BN,
                        IsSelect = false,
                        SN = t.SN,
                        IsStock = true,
                        Remark = string.Empty,
                        SortNo = int.MaxValue
                    }
                )
                );

            foreach (var item in entitys)
            {
                var dataitem = data.FirstOrDefault(t => t.SN == item.SN);
                if (dataitem == null)
                {
                    dataitem = new SNSelectEntity()
                    {
                        BN = item.BN,
                        IsSelect = true,
                        SN = item.SN,
                        IsStock = false,
                        Remark = string.Empty,
                        SortNo = 0
                    };
                    data.Add(dataitem);
                }
                dataitem.IsSelect = true;
                dataitem.Remark = item.Remark;
                dataitem.SortNo = item.SortNo;
            }
            data.Sort(new SNSelectComparer());
            this.bindingSource1.DataSource = data;
            this.gridControl1.DataSource = bindingSource1;
        }
        class SNSelectComparer : IComparer<SNSelectEntity>
        {
            public int Compare(SNSelectEntity x, SNSelectEntity y)
            {
                if (x.SortNo == y.SortNo)
                    return 0;
                else if (x.SortNo > y.SortNo)
                    return 1;
                return -1;
            }
        }

        DevExpress.Utils.AppearanceDefault appRed = new DevExpress.Utils.AppearanceDefault
         (Color.Black, Color.Red, Color.Empty, Color.SeaShell, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colSN)
            {
                bool isstock = (bool)this.gridView1.GetRowCellValue(e.RowHandle, "IsStock");
                if (!isstock)
                {
                    DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appRed);
                }
            }
        }
    }
    public class ProductSNSelectUserControl_Design : Base_UserControl<ProductSNSelectUserControlFacade>
    {

    }
    public class ProductSNSelectUserControlFacade : ActualBase<ProductSNSelectUserControl>
    {
        private IDlyNdxService _DlyNdxService = ServiceProxyFactory.Create<IDlyNdxService>();
        public ProductSNSelectUserControlFacade(ProductSNSelectUserControl actual)
            : base(actual)
        { }

        internal PSNInventEntity[] GetBindEntitys(int stockId, int productId, string bn)
        {
            return _DlyNdxService.GetPSNInventEntity(stockId, productId, bn);
        }
    }
}
