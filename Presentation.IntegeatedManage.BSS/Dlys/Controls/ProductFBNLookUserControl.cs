using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class ProductFBNLookUserControl : ProductFBNLookUserControl_Design
    {
        public ProductFBNLookUserControl()
        {
            InitializeComponent();
        }

        private void ProductFBNLookUserControl_Load(object sender, EventArgs e)
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
                this.Facade = new ProductFBNLookUserControlFacade(this);
        }
        internal void BindData(PFBNInOutDetailsEntity[] data)
        {
            CreateFacade();
            this.bindingSource1.DataSource = data;
            this.gridControl1.DataSource = bindingSource1;
        }
    }

    public class ProductFBNLookUserControl_Design : Base_UserControl<ProductFBNLookUserControlFacade>
    {

    }
    public class ProductFBNLookUserControlFacade : ActualBase<ProductFBNLookUserControl>
    {
        //private IDlyNdxService _DlyNdxService = ServiceProxyFactory.Create<IDlyNdxService>();
        public ProductFBNLookUserControlFacade(ProductFBNLookUserControl actual)
            : base(actual)
        { }

        //internal PFBNInOutDetailsEntity[] GetBindEntitys(string pinoutdetailid)
        //{
        //    return _DlyNdxService.GetPFBNInOutDetailsEntity(pinoutdetailid);
        //}
    }
}
