using DevExpress.XtraGrid.Views.Grid;
using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public partial class RoleStockControl : RoleStockControl_Design
    {
        internal string guidflag = Guid.NewGuid().ToString();
        internal string lastBindRoleId;
        internal bool IsdataChanged = false;
        public RoleStockControl()
        {
            InitializeComponent();
        }

        private RoleEntity currentbindentity;
        public RoleEntity CurrentBindEntity
        {
            get
            {
                return currentbindentity;
            }
            set
            {
                if (this.DesignMode)
                    return;
                if (this.Visible)
                {
                    ResetRoleEntity(value);
                }
                currentbindentity = value;
            }
        }
        private void ResetRoleEntity(RoleEntity roleentity)
        {
            bool enable = true;
            if (roleentity == null)
                enable = false;
            else
            {
                //if (this.currentbindentity != null && roleentity.RoleId != this.currentbindentity.RoleId && this.IsdataChanged)
                if (this.IsdataChanged)
                {
                    if (MessageBoxEx.YesNoInfo("数据已发生改变，是否保存？") == DialogResult.Yes)
                    {
                        this.btnSave_Click(null, null);
                    }
                    IsdataChanged = false;
                }
                enable = ((!roleentity.IsSuper));
            }
            this.btnSave.Enabled = this.btnAll.Enabled = this.btnUnAll.Enabled = enable;
            if (this.Facade != null)
                this.Facade.NewBindData(roleentity);
        }
        private void RoleStockControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.Facade = new RoleStockControlFacade(this);
                var form = this.FindForm();
                if (form != null)
                {
                    form.FormClosing += form_FormClosing;
                }
                this.ResetRoleEntity(this.currentbindentity);
            }
        }
        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Facade.DelStockTempData();
        }
        public bool IsPageIndexShow
        {
            set
            {
                if (value)
                {
                    this.ResetRoleEntity(this.currentbindentity);
                }
            }
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                var datas = this.bindingSource1.DataSource as List<StockInfoRightTempStatusEntity>;
                this.Facade.SaveTempData(datas.ToArray(), true);
                datas.ForEach((data) =>
                {
                    if (!data.Status) IsdataChanged = true;
                    data.Status = true;
                });
                IsdataChanged = true;
                this.gridView1.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnUnAll_Click(object sender, EventArgs e)
        {

            try
            {
                var datas = this.bindingSource1.DataSource as List<StockInfoRightTempStatusEntity>;
                this.Facade.SaveTempData(datas.ToArray(), false);
                datas.ForEach((data) =>
                {
                    if (data.Status) IsdataChanged = true;
                    data.Status = false;
                });
                this.gridView1.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var datas = this.bindingSource1.DataSource as List<StockInfoRightTempStatusEntity>;
                this.Facade.SaveRightData(datas);
                this.IsdataChanged = false;
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
        internal void BindData(StockInfoRightTempStatusEntity[] entitys)
        {
            this.bindingSource1.DataSource = new List<StockInfoRightTempStatusEntity>(entitys);
            this.gridControl1.DataSource = this.bindingSource1;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.RowHandle < 0)
                        return;
                    var gv = sender as GridView;
                    if (e.Column.FieldName != "Status")
                        return;
                    if (this.currentbindentity == null)
                        return;
                    if (this.currentbindentity.IsSuper)
                        return;
                    var entity = gv.GetRow(e.RowHandle) as StockInfoRightTempStatusEntity;
                    if (entity == null)
                        return;
                    bool check = !entity.Status;
                    this.Facade.SaveTempData(new StockInfoRightTempStatusEntity[] { entity }, check);
                    entity.Status = check;
                    IsdataChanged = true;
                    this.gridView1.RefreshRow(e.RowHandle);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
    }

    public partial class RoleStockControl_Design : Base_UserControl<RoleStockControlFacade>
    {
    }
    public class RoleStockControlFacade : ActualBase<RoleStockControl>
    {
        IAccessService _AccessService = ServiceProxyFactory.Create<IAccessService>();
        public RoleStockControlFacade(RoleStockControl actual)
            : base(actual) { }

        internal void NewBindData(RoleEntity roleEntity)
        {
            if (roleEntity == null)
                return;
            if (this.Actual.lastBindRoleId == roleEntity.RoleId)
                return;
            string newguidflag = Guid.NewGuid().ToString();
            StockInfoRightTempStatusEntity[] entitys =
                _AccessService.GetStockBaseRight(roleEntity.RoleId, newguidflag, this.Actual.guidflag);
            this.Actual.BindData(entitys);
            this.Actual.guidflag = newguidflag;
            this.Actual.lastBindRoleId = roleEntity.RoleId;
        }
        //internal void BindData()
        //{
        //    if (this.Actual.CurrentBindEntity == null)
        //        return;
        //    if (this.Actual.lastBindRoleId == this.Actual.CurrentBindEntity.RoleId)
        //        return;
        //    StockInfoRightTempStatusEntity[] entitys =
        //        _AccessService.GetStockBaseRight(this.Actual.CurrentBindEntity.RoleId, this.Actual.guidflag);
        //    this.Actual.BindData(entitys);
        //    this.Actual.lastBindRoleId = this.Actual.CurrentBindEntity.RoleId;
        //}

        internal void SaveRightData(List<StockInfoRightTempStatusEntity> datas)
        {
            _AccessService.SaveStockRightData(datas);
        }
        internal void DelStockTempData()
        {
            _AccessService.DelStockRightTempData(this.Actual.guidflag);
        }

        internal void SaveTempData(StockInfoRightTempStatusEntity[] stockInfoRightTempStatusEntity, bool check)
        {
            if (this.Actual.CurrentBindEntity == null) throw new BusinessException("角色不可为空");
            _AccessService.SaveStockRightTempData(this.Actual.CurrentBindEntity.RoleId, stockInfoRightTempStatusEntity.Select(t => t.StockId).ToArray(), this.Actual.guidflag, check);
        }
    }
}
