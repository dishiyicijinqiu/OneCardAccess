using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public partial class RoleRawMateControl : RoleRawMateControl_Design
    {
        internal string guidflag = Guid.NewGuid().ToString();
        internal string lastBindRoleId;
        internal bool IsdataChanged = false;
        public RoleRawMateControl()
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
            layoutControlItem5.ContentVisible = true;
            if (!enable)
                layoutControlItem5.ContentVisible = false;
            if (this.TreeLevel.Level_Deep <= 0)
                layoutControlItem5.ContentVisible = false;
            if (this.Facade != null)
            {
                this.Facade.NewBindData(roleentity);
            }
        }

        private void RoleRawMateControl_Load(object sender, EventArgs e)
        {

            if (!this.DesignMode)
            {
                this.Facade = new RoleRawMateControlFacade(this);
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
            this.Facade.DelRawMateTempData();
        }
        public bool IsPageIndexChanging
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
                var datas = this.bindingSource1.DataSource as List<RawMateInfoRightStatusTempEntity>;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var datas = this.bindingSource1.DataSource as List<RawMateInfoRightStatusTempEntity>;
                this.Facade.SaveRightData(datas);
                this.IsdataChanged = false;
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
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
                var datas = this.bindingSource1.DataSource as List<RawMateInfoRightStatusTempEntity>;
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
        #region TreeLevelForm
        public override void DeepIn(int pid)
        {
            this.Facade.BindData(this.currentbindentity, pid);
            base.DeepIn(pid);
        }

        public override void DeepOut(int pid)
        {
            pid = this.Facade.BindFaterData(this.currentbindentity, pid);
            base.DeepOut(pid);
        }
        public override void TreeLevel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Level_Deep")
            {
                var btns = this.Controls.Find("btnCancel", true);
                if (btns.Length > 0)
                {
                    var btn = btns[0] as SimpleButton;
                    btn.Text = TreeLevel.Level_Deep > 0 ?
                        FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnReturn :
                        FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages.btnCancel;
                }
                if (TreeLevel.Level_Deep <= 0)
                {
                    layoutControlItem5.ContentVisible = false;
                }
                else
                {
                    layoutControlItem5.ContentVisible = true;
                }
            }
        }
        #endregion
        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TreeLevel.PId <= 0)
                    return;
                this.DeepOut(this.TreeLevel.PId);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        internal void BindData(RawMateInfoRightStatusTempEntity[] entitys)
        {
            this.bindingSource1.DataSource = new List<RawMateInfoRightStatusTempEntity>(entitys);
            this.gridControl1.DataSource = this.bindingSource1;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks != 2 || this.gridView1.FocusedRowHandle < 0)
                    return;
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as RawMateInfoRightStatusTempEntity;
                if (entity.HasCate)
                {
                    this.DeepIn(entity.RawMateId);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
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
                    var entity = gv.GetRow(e.RowHandle) as RawMateInfoRightStatusTempEntity;
                    if (entity == null)
                        return;
                    bool check = !entity.Status;
                    this.Facade.SaveTempData(new RawMateInfoRightStatusTempEntity[] { entity }, check);
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

    public class RoleRawMateControl_Design : TreeLevelUserControl<RoleRawMateControlFacade>
    {
    }
    public class RoleRawMateControlFacade : ActualBase<RoleRawMateControl>
    {
        IAccessService _AccessService = ServiceProxyFactory.Create<IAccessService>();
        IRawMateService _RawMateService = ServiceProxyFactory.Create<IRawMateService>();
        public RoleRawMateControlFacade(RoleRawMateControl actual)
            : base(actual) { }

        internal void NewBindData(RoleEntity roleEntity)
        {
            if (roleEntity == null)
                return;
            if (this.Actual.lastBindRoleId == roleEntity.RoleId)
                return;
            this.Actual.TreeLevel.Level_Deep = 0;
            this.Actual.TreeLevel.PId = 0;
            string newguidflag = Guid.NewGuid().ToString();
            RawMateInfoRightStatusTempEntity[] entitys =
                _AccessService.GetNewRawMateBaseRight(roleEntity.RoleId, newguidflag, this.Actual.guidflag);
            this.Actual.BindData(entitys);
            this.Actual.guidflag = newguidflag;
            this.Actual.lastBindRoleId = roleEntity.RoleId;
        }
        internal void BindData(RoleEntity roleEntity, int pid)
        {
            if (roleEntity == null)
                return;
            RawMateInfoRightStatusTempEntity[] entitys =
                _AccessService.GetRawMateBaseRight(roleEntity.RoleId, this.Actual.guidflag, pid);
            this.Actual.BindData(entitys);
            this.Actual.lastBindRoleId = roleEntity.RoleId;
        }

        internal int BindFaterData(RoleEntity roleEntity, int pid)
        {
            var pEntity = this._RawMateService.GetRawMateById(pid);
            if (pEntity != null)
            {
                this.BindData(roleEntity, pEntity.PId);
                return pEntity.PId;
            }
            return 0;
        }

        internal void SaveRightData(List<RawMateInfoRightStatusTempEntity> datas)
        {
            _AccessService.SaveRawMateRightData(datas);
        }

        internal void DelRawMateTempData()
        {
            _AccessService.DelRawMateRightTempData(this.Actual.guidflag);
        }

        internal void SaveTempData(RawMateInfoRightStatusTempEntity[] rawMateInfoRightStatusTempEntity, bool check)
        {
            if (this.Actual.CurrentBindEntity == null) throw new BusinessException("角色不可为空");
            _AccessService.SaveRawMateRightTempData(this.Actual.CurrentBindEntity.RoleId,
                rawMateInfoRightStatusTempEntity.Select(t => t.RawMateId).ToArray(), 
                this.Actual.guidflag, check);
        }
    }
}
