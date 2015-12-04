using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS.Interface;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.CRM.Interface;
using FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR.Interface;
using System;
using System.Linq;


namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class DlySPXSForm : DlySPXSForm_Design
    {
        public string NdxId { get; set; }
        private short TotalInputLevel = 0;
        public DlySPXSForm()
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

                var qtyFBNPopupContainerControl = ServiceLoader.LoadService<IProductFBNSelect>("ProductFBNSelect") as PopupContainerControl;
                qtyFBNPopupContainerControl.Width = 600;
                qtyFBNPopupContainerControl.Height = 600;
                qtyFBNRepItemPopupContainerEdit.PopupControl = qtyFBNPopupContainerControl;

                var qtySNPopupContainerControl = ServiceLoader.LoadService<IProductSNSelect>("ProductSNSelect") as PopupContainerControl;
                qtySNPopupContainerControl.Width = 600;
                qtySNPopupContainerControl.Height = 600;
                qtySNRepItemPopupContainerEdit.PopupControl = qtySNPopupContainerControl;

                var companyopupContainerControl = ServiceLoader.LoadService<ISingleCompanySelect>("SingleCompanyControlSelect") as PopupContainerControl;
                companyopupContainerControl.Width = 600;
                companyopupContainerControl.Height = 600;
                this.CompanyPopupContainerEdit.Properties.PopupControl = companyopupContainerControl;
            }
            for (int i = 0; i < this.gridView1.Columns.Count; i++)
            {
                var col = this.gridView1.Columns[i];
                if (col == colProductNo)
                    continue;
                col.RealColumnEdit.EditValueChanging += RealColumnEdit_EditValueChanging;
            }
            this.gridControl1.DataSource = this.bindingSource1;
        }
        public DlySPXSForm(string ndxId)
            : this()
        {
            NdxId = ndxId;
        }
        private void RealColumnEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedColumn == colProductNo) return;
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PDlyBakFullNameEntity;
                if (row == null || row.ProductId <= 0)
                {
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void DlySPXSForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new DlySPXSFormFacade(this);
                this.Facade.SetData();
                this.Facade.SetTotalInputLevel();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
                this.formLoadErrorExit1.LoadError();
            }
        }
        internal void SetData(SPXSDlyCGNdxEntity entity)
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
                var entity = this.bindbaseDataLayoutControl1.DataSource as SPXSDlyCGNdxEntity;
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
                var entity = this.bindbaseDataLayoutControl1.DataSource as SPXSDlyCGNdxEntity;
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
        private void CompanyPopupContainerEdit_Properties_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {

            try
            {
                var basePopupContainerEdit = sender as BasePopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as ISingleCompanySelect;
                if (!singleSelect.IsSelect) return;
                var result = singleSelect.GetResult();
                var entity = this.bindbaseDataLayoutControl1.DataSource as SPXSDlyCGNdxEntity;
                if (result == null)
                {
                    entity.CompanyId = 0;
                    entity.CompanyNo = string.Empty;
                    entity.CompanyName = string.Empty;
                }
                else
                {
                    entity.CompanyId = result.CompanyId;
                    entity.CompanyNo = result.CompanyNo;
                    entity.CompanyName = result.CompanyName;
                }
                e.Value = entity.CompanyName;
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
                    row.QtyMode = ((short)0);
                }
                else
                {
                    row.ProductId = result.ProductId;
                    row.ProductName = result.ProductName;
                    row.Spec = result.Spec;
                    row.GoodCode = result.GoodCode;
                    row.Unit = result.Unit;
                    row.ProductNo = result.ProductNo;
                    row.QtyMode = result.QtyMode;
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

            this.PreferTextEdit.DataBindings[0].WriteValue();
            var entity = this.bindbaseDataLayoutControl1.DataSource as SPXSDlyCGNdxEntity;
            entity.Qty = data.Sum(t => t.Qty);
            entity.Total = data.Sum(t => t.Total);
            entity.AfterPreferTotal = entity.Total - entity.Prefer;
            this.QtyTextEdit.DataBindings[0].ReadValue();
            this.TotalTextEdit.DataBindings[0].ReadValue();
            this.AfterPreferTotalTextEdit.DataBindings[0].ReadValue();

            //this.QtyTextEdit.EditValue = data.Sum(t => t.Qty);
            //this.TotalTextEdit.EditValue = data.Sum(t => t.Total);
            //this.AfterPreferTotalTextEdit.EditValue = Convert.ToDecimal(this.TotalTextEdit.EditValue) - Convert.ToDecimal(this.PreferTextEdit.EditValue);
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
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PDlyBakFullNameEntity;
                if (row != null)
                    row.Total = decimal.Parse(e.Value.ToString()) * (decimal)row.Qty;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            try
            {
                if (e.Column == colQty)
                {
                    var row = this.gridView1.GetRow(e.RowHandle) as PDlyBakFullNameEntity;
                    if (row == null)
                        return;
                    if (row.QtyMode == 1)
                    {
                        e.RepositoryItem = qtySNRepItemPopupContainerEdit;
                    }
                    else if (row.QtyMode == 2)
                    {
                        e.RepositoryItem = qtyFBNRepItemPopupContainerEdit;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void qtyFBNRepItemPopupContainerEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as PopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as IProductFBNSelect;
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PDlyBakFullNameEntity;
                if (row == null)
                {
                    e.Cancel = true;
                    return;
                }
                int sortno = 0;
                row.PFBNBaks.ForEach((entity) =>
                {
                    entity.SortNo = sortno++;
                });
                var dlyentity = this.bindbaseDataLayoutControl1.DataSource as SPXSDlyCGNdxEntity;
                singleSelect.BindData(row.PFBNBaks.ToArray(), dlyentity.StockId1, row.ProductId, row.BN);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void qtyFBNRepItemPopupContainerEdit_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as PopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as IProductFBNSelect;
                e.Value = singleSelect.Qty;
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PDlyBakFullNameEntity;
                row.PFBNBaks.Clear();
                row.PFBNBaks.AddRange(singleSelect.EntityResults);
                row.Total = decimal.Parse(e.Value.ToString()) * (decimal)row.Price;
                row.BN = singleSelect.BN;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void qtySNRepItemPopupContainerEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as PopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as IProductSNSelect;
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PDlyBakFullNameEntity;
                if (row == null)
                {
                    e.Cancel = true;
                    return;
                }
                int sortno = 0;
                row.PSNBaks.ForEach((entity) =>
                {
                    entity.SortNo = sortno++;
                });
                var dlyentity = this.bindbaseDataLayoutControl1.DataSource as SPXSDlyCGNdxEntity;
                singleSelect.BindData(row.PSNBaks.ToArray(), dlyentity.StockId1, row.ProductId, row.BN);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void qtySNRepItemPopupContainerEdit_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            try
            {
                var basePopupContainerEdit = sender as PopupContainerEdit;
                var singleSelect = basePopupContainerEdit.Properties.PopupControl as IProductSNSelect;
                e.Value = singleSelect.Qty;
                var row = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as PDlyBakFullNameEntity;
                row.PSNBaks.Clear();
                row.PSNBaks.AddRange(singleSelect.EntityResults);
                row.Total = decimal.Parse(e.Value.ToString()) * (decimal)row.Price;
                row.BN = singleSelect.BN;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (this.formLoadErrorExit1.GetLoadError(this))
                    return;
                var diaResult = DJMessageBox.Show();
                if (diaResult == DialogResultEx.存入草稿)
                {
                    var data = this.bindbaseDataLayoutControl1.DataSource as SPXSDlyCGNdxEntity;
                    var entity = new PDlyNdxCGEntity();
                    FengSharp.Tool.Reflect.ClassValueCopier.Copy(entity, data);
                    this.Facade.SaveBak(entity);
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
                }
                else if (diaResult == DialogResultEx.保存单据)
                {
                    var data = this.bindbaseDataLayoutControl1.DataSource as SPXSDlyCGNdxEntity;
                    var entity = new PDlyNdxCGEntity();
                    FengSharp.Tool.Reflect.ClassValueCopier.Copy(entity, data);
                    this.Facade.SaveDly(entity);
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
                }
                else if (diaResult == DialogResultEx.取消操作)
                {
                    e.Cancel = true;
                }
                base.OnClosing(e);
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBoxEx.Error(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
        }

        private void SHRNameButtonEdit_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.NdxId))
                {
                    MessageBoxEx.Info("单据未保存");
                    return;
                }
                ButtonEdit btn = sender as ButtonEdit;
                short inputlevel = (short)btn.Properties.Tag;
                if (this.TotalInputLevel < inputlevel)
                {
                    MessageBoxEx.Info("未启用该审核级别");
                    return;
                }
                var spxsDlyCGNdxEntity = this.bindbaseDataLayoutControl1.DataSource as SPXSDlyCGNdxEntity;
                var property = spxsDlyCGNdxEntity.GetType().GetProperty(string.Format("SHRId{0}", inputlevel));
                var shrid = property.GetValue(spxsDlyCGNdxEntity, null).ToString();
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.OK)
                {
                    if (!DJSHChecker.CheckPreInputLevel(spxsDlyCGNdxEntity, inputlevel))
                    {
                        MessageBoxEx.Info("前面的审核流程未完成");
                        return;
                    }
                    if (DJSHChecker.CheckAfterInputLevel(spxsDlyCGNdxEntity, this.TotalInputLevel, inputlevel))
                    {
                        MessageBoxEx.Info("后面的审核流程已完成");
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(shrid))
                    {
                        MessageBoxEx.Info("单据已审核");
                        return;
                    }
                    this.Facade.SHDJ(inputlevel);
                    property.SetValue(spxsDlyCGNdxEntity, AuthPrincipal.CurrentAuthPrincipal.AuthIdentity.UserId, null);
                    btn.EditValue = AuthPrincipal.CurrentAuthPrincipal.AuthIdentity.UserName;
                }
                else
                {
                    if (!DJSHChecker.CheckPreInputLevel(spxsDlyCGNdxEntity, inputlevel))
                    {
                        MessageBoxEx.Info("前面的审核流程未完成");
                        return;
                    }
                    if (DJSHChecker.CheckAfterInputLevel(spxsDlyCGNdxEntity, this.TotalInputLevel, inputlevel))
                    {
                        MessageBoxEx.Info("后面的审核流程已完成");
                        return;
                    }
                    if (string.Compare(shrid, AuthPrincipal.CurrentAuthPrincipal.AuthIdentity.UserId, true) != 0)
                    {
                        MessageBoxEx.Info("与审核不是同一个人，不可反审");
                        return;
                    }
                    this.Facade.FSDJ(inputlevel);
                    property.SetValue(spxsDlyCGNdxEntity, string.Empty, null);
                    btn.EditValue = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        internal void SetTotalInputLevel(short totalInputLevel)
        {
            TotalInputLevel = totalInputLevel;
            this.ItemForSHRName2.Visibility = totalInputLevel >= 2 ?
                DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.ItemForSHRName3.Visibility = totalInputLevel >= 3 ?
                DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.ItemForSHRName4.Visibility = totalInputLevel >= 4 ?
                DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.ItemForSHRName5.Visibility = totalInputLevel >= 5 ?
                DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
    }
    public class DlySPXSForm_Design : Base_Form<DlySPXSFormFacade>
    {
    }
    public class DlySPXSFormFacade : ActualBase<DlySPXSForm>
    {
        private IDlyNdxService _DlyNdxService = ServiceProxyFactory.Create<IDlyNdxService>();
        private IInputLevelService _InputLevelService = ServiceProxyFactory.Create<IInputLevelService>();
        public DlySPXSFormFacade(DlySPXSForm actual)
            : base(actual)
        { }
        internal void SetData()
        {
            if (string.IsNullOrWhiteSpace(this.Actual.NdxId))
            {
                if (!_InputLevelService.CheckInputLevel(FengSharp.OneCardAccess.Application.Config.DlyConfig.SPXSDlyTypeId, ((short)1)))
                {
                    throw new BusinessException("您不是一级审核人");
                }
                var entity = new SPXSDlyCGNdxEntity();
                entity.DlyNo = _DlyNdxService.GetNewDlyNo(FengSharp.OneCardAccess.Application.Config.DlyConfig.SPXSDlyTypeId);
                entity.DlyDate = _DlyNdxService.GetDlyDate();
                AuthIdentity authidentity = AuthPrincipal.CurrentAuthPrincipal.AuthIdentity;
                entity.ZDRId = authidentity.UserId;
                entity.ZDRName = authidentity.UserName;
                entity.DlyTypeId = FengSharp.OneCardAccess.Application.Config.DlyConfig.SPXSDlyTypeId;
                entity.SHRId1 = authidentity.UserId;
                entity.SHRName1 = authidentity.UserName;
                //var dlybak = new PDlyBakFullNameEntity();
                //dlybak.PFBNBaks.Add(new PFBNBakEntity());
                //dlybak.PSNBaks.Add(new PSNBakEntity());
                //entity.PDlyBaks.Add(dlybak);
                this.Actual.SetData(entity);
            }
            else
            {
                SPXSDlyCGNdxEntity entity = _DlyNdxService.GetSPXSDlyCGNdxEntity(this.Actual.NdxId);
                if (entity == null) throw new BusinessException("单据不存在");
                if (string.IsNullOrWhiteSpace(entity.ZDRId))
                {
                    AuthIdentity authidentity = AuthPrincipal.CurrentAuthPrincipal.AuthIdentity;
                    entity.ZDRId = authidentity.UserId;
                    entity.ZDRName = authidentity.UserName;
                }
                this.Actual.SetData(entity);
            }
        }

        internal void SetTotalInputLevel()
        {
            short totalInputLevel = _InputLevelService.GetTotalInputLevel(FengSharp.OneCardAccess.Application.Config.DlyConfig.SPXSDlyTypeId);
            this.Actual.SetTotalInputLevel(totalInputLevel);
        }

        internal void SaveBak(PDlyNdxCGEntity entity)
        {
            //验证操作
            string oldid = entity.DlyNdxId;
            string newid = this._DlyNdxService.SavPBak(entity);
            DlyNdxCGManageForm.RefreshRowId(oldid, newid);
        }

        internal void SaveDly(PDlyNdxCGEntity entity)
        {
            this._DlyNdxService.SavePDly(entity);
        }

        internal void SHDJ(short inputlevel)
        {
            _InputLevelService.SHDJ(FengSharp.OneCardAccess.Application.Config.DlyConfig.SPXSDlyTypeId, inputlevel, this.Actual.NdxId);
        }

        internal void FSDJ(short inputlevel)
        {
            _InputLevelService.FSDJ(FengSharp.OneCardAccess.Application.Config.DlyConfig.SPXSDlyTypeId, inputlevel, this.Actual.NdxId);
        }
    }
}