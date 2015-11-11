using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
using System.Linq;

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

                var productPopupContainerControl = ServiceLoader.LoadService<ISingleProductSelect>("SingleProductControlSelect") as PopupContainerControl;
                productPopupContainerControl.Width = 800;
                productPopupContainerControl.Height = 500;
                productNoRepItemPopupContainerEdit.PopupControl = productPopupContainerControl;

                var productPricePopupContainerControl = ServiceLoader.LoadService<ISingleProductPriceSelect>("SingleProductPriceControlSelect") as PopupContainerControl;
                productPricePopupContainerControl.Width = 300;
                productPricePopupContainerControl.Height = 200;
                priceRepItemPopupContainerEdit.PopupControl = productPricePopupContainerControl;
            }
            this.gridControl1.DataSource = this.bindingSource1;
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
            if (entity == null)
                this.bindingSource1.DataSource = typeof(PDlyBakFullNameEntity);
            else
                this.bindingSource1.DataSource = entity.PDlyBaks;
        }

        private void JSRNamePopupContainerEdit_Properties_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as BasePopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as ISingleEmployeeSelect;
                if (!singleSelect.IsSelect) return;
                var result = singleSelect.GetResult();
                var entity = this.bindbaseDataLayoutControl1.DataSource as SPRKDlyCGNdxEntity;
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
                var entity = this.bindbaseDataLayoutControl1.DataSource as SPRKDlyCGNdxEntity;
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

        private void productNoRepItemPopupContainerEdit_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as PopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as ISingleProductSelect;
                if (!singleSelect.IsSelect) return;
                var result = singleSelect.GetResult();
                if (result == null)
                {
                    e.Value = string.Empty;
                }
                else
                {
                    e.Value = result.ProductNo;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void productNoRepItemPopupContainerEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as PopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as ISingleProductSelect;
                if (!singleSelect.IsSelect) return;
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PDlyBakFullNameEntity;
                if (row == null) return;
                var result = singleSelect.GetResult();
                if (result == null)
                {
                    row.ProductId = 0;
                    row.ProductName = string.Empty;
                    row.Spec = string.Empty;
                    row.GoodCode = string.Empty;
                    row.Unit = string.Empty;
                    row.ProductNo = string.Empty;
                    //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "ProductId", 0);
                    //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "ProductName", string.Empty);
                    //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "Spec", string.Empty);
                    //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "GoodCode", string.Empty);
                    //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "Unit", string.Empty);
                }
                else
                {
                    //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "ProductId", result.ProductId);
                    //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "ProductName", result.ProductName);
                    //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "Spec", result.Spec);
                    //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "GoodCode", result.GoodCode);
                    //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "Unit", result.Unit);
                    row.ProductId = result.ProductId;
                    row.ProductName = result.ProductName;
                    row.Spec = result.Spec;
                    row.GoodCode = result.GoodCode;
                    row.Unit = result.Unit;
                    row.ProductNo = result.ProductNo;
                }
                this.gridView1.RefreshRow(this.gridView1.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        public void SummaryChange()
        {
            var data = this.bindingSource1.DataSource as System.Collections.Generic.List<PDlyBakFullNameEntity>;
            if (data == null) return;
            this.QtyTextEdit.EditValue = data.Sum(t => t.Qty);
            this.TotalTextEdit.EditValue = data.Sum(t => t.Total);
            this.AfterPreferTotalTextEdit.EditValue = Convert.ToDecimal(this.TotalTextEdit.EditValue) - Convert.ToDecimal(this.PreferTextEdit.EditValue);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colPrice || e.Column == colQty || e.Column == colTotal)
                {
                    SummaryChange();
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void PreferTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SummaryChange();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void priceRepItemPopupContainerEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as PopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as ISingleProductPriceSelect;
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PDlyBakFullNameEntity;
                if (row == null)
                {
                    e.Cancel = true;
                    return;
                }
                singleSelect.BindData(row.ProductId);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void priceRepItemPopupContainerEdit_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as PopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as ISingleProductPriceSelect;
                if (!singleSelect.IsSelect) return;
                e.Value = singleSelect.GetResult();
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
                AuthPrincipal authprincipal = System.Threading.Thread.CurrentPrincipal as AuthPrincipal;
                AuthIdentity authidentity = authprincipal.Identity as AuthIdentity;
                entity.ZDRId = authidentity.UserId;
                entity.ZDRName = authidentity.UserName;
                //var dlybak = new PDlyBakFullNameEntity();
                //dlybak.PFBNBaks.Add(new PFBNBakEntity());
                //dlybak.PSNBaks.Add(new PSNBakEntity());
                //entity.PDlyBaks.Add(dlybak);
                this.Actual.SetData(entity);
            }
            else
            {

            }
        }
    }
}