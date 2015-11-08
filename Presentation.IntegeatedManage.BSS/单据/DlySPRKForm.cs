using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface;
using System;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class DlySPRKForm : DlySPRKForm_Design
    {
        public DlySPRKForm()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                var popupContainerControl = ServiceLoader.LoadService<ISingleEmployeeSelect>("SingleEmployeeControlSelect") as PopupContainerControl;
                popupContainerControl.Width = 800;
                popupContainerControl.Height = 500;
                this.JSRNamePopupContainerEdit.Properties.PopupControl = popupContainerControl;

                var stockPopupContainerControl = ServiceLoader.LoadService<ISingleStockSelect>("SingleStockControlSelect") as PopupContainerControl;
                stockPopupContainerControl.Width = 800;
                stockPopupContainerControl.Height = 500;
                this.StockName1PopupContainerEdit.Properties.PopupControl = stockPopupContainerControl;
            }
        }

        private void DlySPRK_Load(object sender, EventArgs e)
        {

        }
    }
    public class DlySPRKForm_Design : Base_Form<DlySPRKFormFacade>
    {
    }
    public class DlySPRKFormFacade : ActualBase<DlySPRKForm>
    {
        public DlySPRKFormFacade(DlySPRKForm actual)
            : base(actual) { }
    }
}