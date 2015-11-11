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
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class ProductPriceSelectUserControl : ProductPriceSelectUserControl_Design
    {
        public event VEventHandler<EventArgs> OKClick;
        public event VEventHandler<EventArgs> CancelClick;
        private bool isMulSelect = false;
        public ProductPriceSelectUserControl()
        {
            InitializeComponent();
        }
        public bool IsMulSelect
        {
            get
            {
                return isMulSelect;
            }
            internal set
            {
                isMulSelect = value;
            }
        }

        private void ProductPriceSelectUserControl_Load(object sender, EventArgs e)
        {

            if (this.DesignMode)
                return;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;
            EntityResult = 0;
            EntityResults = null;
            this.gridView1.OptionsSelection.MultiSelect = this.isMulSelect;
            CreateFacade();
        }

        private void CreateFacade()
        {
            if (this.Facade == null)
                this.Facade = new ProductPriceSelectUserControlFacade(this);
        }

        public double EntityResult { get; private set; }

        public double[] EntityResults { get; private set; }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks != 2 || this.gridView1.FocusedRowHandle < 0)
                    return;
                this.btnOK_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            if (this.gridView1.FocusedRowHandle < 0)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                return;
            }
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                EntityResult = (this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as GoodPrice).Price;
                EntityResults = this.gridView1.GetSelectedRows().Select(
                    t => (this.gridView1.GetRow(t) as GoodPrice).Price
                    ).ToArray();
            }
            if (OKClick != null)
            {
                this.OKClick(new EventArgs());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EntityResult = 0;
            EntityResults = null;
            if (CancelClick != null)
            {
                this.CancelClick(new EventArgs());
            }
        }

        internal void Bind(List<GoodPrice> entitys)
        {
            this.bindingSource1.DataSource = entitys;
            this.gridControl1.DataSource = this.bindingSource1;
        }
        public void BindData(int entityid)
        {
            CreateFacade();
            this.Facade.BindData(entityid);
        }
    }
    public class ProductPriceSelectUserControl_Design : Base_UserControl<ProductPriceSelectUserControlFacade>
    {

    }
    public class ProductPriceSelectUserControlFacade : ActualBase<ProductPriceSelectUserControl>
    {
        private IProductService _ProductService = ServiceProxyFactory.Create<IProductService>();
        public ProductPriceSelectUserControlFacade(ProductPriceSelectUserControl actual)
            : base(actual) { }

        internal void BindData(int entityid)
        {
            var entity = _ProductService.GetProductById(entityid);
            if (entity == null)
            {
                throw new BusinessException("商品不存在");
            }
            List<GoodPrice> listPrices = new List<GoodPrice>();
            listPrices.Add(new GoodPrice("预设价格1", (double)entity.preprice1));
            listPrices.Add(new GoodPrice("预设价格2", (double)entity.preprice2));
            listPrices.Add(new GoodPrice("预设价格3", (double)entity.preprice3));
            listPrices.Add(new GoodPrice("零售价", (double)entity.preprice4));
            listPrices.Add(new GoodPrice("最近进价", (double)entity.recprice));
            //listPrices.Add(new GoodPrice("库存均价", (double)instance3.GetGoodPrice(goodType, goodId)));
            this.Actual.Bind(listPrices);
        }
    }
    public class GoodPrice
    {
        /// <summary>
        /// 价格类型
        /// </summary>
        public string PriceType { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public double Price { get; set; }
        public GoodPrice(string _PriceType, double _Price)
        {
            PriceType = _PriceType;
            Price = _Price;
        }
    }
}
