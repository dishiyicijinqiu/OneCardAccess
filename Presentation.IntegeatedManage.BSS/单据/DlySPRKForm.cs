using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface;
using System;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class DlySPRKForm : DlySPRKForm_Design
    {
        public string NdxId { get; set; }
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
        public DlySPRKForm(string ndxId)
            : base()
        {
            NdxId = ndxId;
        }

        private void DlySPRK_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new DlySPRKFormFacade(this);
                this.Facade.SetData();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
                this.formLoadErrorExit1.LoadError();
            }
        }

        internal void SetData(SPRKDlyCGNdxEntity entity)
        {
            this.bindbaseDataLayoutControl1.DataSource = entity;
        }

        private void JSRNamePopupContainerEdit_Properties_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as BasePopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as ISingleEmployeeSelect;
                if (!singleSelect.IsSelect) return;
                var result = singleSelect.GetResult();
                var entity = this.bindbaseDataLayoutControl1.DataSource as SPRKDlyNdxEntity;
                if (result == null)
                {
                    entity.JSRId = string.Empty;
                    entity.JSRName = string.Empty;
                }
                else
                {
                    entity.JSRId = result.EmpId;
                    entity.JSRName = result.EmpName;
                }
                e.Value = entity.JSRName;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void StockName1PopupContainerEdit_Properties_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as BasePopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as ISingleStockSelect;
                if (!singleSelect.IsSelect) return;
                var result = singleSelect.GetResult();
                var entity = this.bindbaseDataLayoutControl1.DataSource as SPRKDlyNdxEntity;
                if (result == null)
                {
                    entity.StockId1 = 0;
                    entity.StockName1 = string.Empty;
                }
                else
                {
                    entity.StockId1 = result.StockId;
                    entity.StockName1 = result.StockName;
                }
                e.Value = entity.StockName1;
                
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
    }
    public class DlySPRKForm_Design : Base_Form<DlySPRKFormFacade>
    {
    }
    public class DlySPRKFormFacade : ActualBase<DlySPRKForm>
    {
        private IDlyNdxService _DlyNdxService = ServiceProxyFactory.Create<IDlyNdxService>();
        public DlySPRKFormFacade(DlySPRKForm actual)
            : base(actual) { }

        internal void SetData()
        {
            if (string.IsNullOrWhiteSpace(this.Actual.NdxId))
            {
                var entity = new SPRKDlyCGNdxEntity();
                entity.DlyNo = _DlyNdxService.GetNewDlyNo(FengSharp.OneCardAccess.Application.Config.DlyConfig.SPRKDlyTypeId);
                entity.DlyDate = _DlyNdxService.GetDlyDate();
                this.Actual.SetData(entity);
            }
            else
            {

            }
        }
    }
}