using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class ProductSNLookUserControl : ProductSNLookUserControl_Design
    {
        public ProductSNLookUserControl()
        {
            InitializeComponent();
        }

        private void ProductSNLookUserControl_Load(object sender, EventArgs e)
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
                this.Facade = new ProductSNLookUserControlFacade(this);
        }
        internal void BindData(PSNInOutDetailsEntity[] data)
        {
            CreateFacade();
            this.bindingSource1.DataSource = data;
            this.gridControl1.DataSource = bindingSource1;
        }
    }
    public class ProductSNLookUserControl_Design : Base_UserControl<ProductSNLookUserControlFacade>
    {

    }
    public class ProductSNLookUserControlFacade : ActualBase<ProductSNLookUserControl>
    {
        //private IDlyNdxService _DlyNdxService = ServiceProxyFactory.Create<IDlyNdxService>();
        public ProductSNLookUserControlFacade(ProductSNLookUserControl actual)
            : base(actual)
        { }

        //internal PSNInOutDetailsEntity[] GetBindEntitys(string pinoutdetailid)
        //{
        //    return _DlyNdxService.GetPSNInOutDetailsEntity(pinoutdetailid);
        //}
    }
}
