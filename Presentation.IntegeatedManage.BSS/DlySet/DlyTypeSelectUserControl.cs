using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class DlyTypeSelectUserControl : DlyTypeSelectUserControl_Design
    {
        public event VEventHandler<CEventArgs<DlyTypeCateEntity[]>> BeforeBind;
        public event VEventHandler<EventArgs> OKClick;
        public event VEventHandler<EventArgs> CancelClick;
        private bool isMulSelect = false;
        private bool isCateCanSelect = false;
        public DlyTypeSelectUserControl()
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
        public bool IsCateCanSelect
        {
            get
            {
                return isCateCanSelect;
            }
            internal set
            {
                isCateCanSelect = value;
            }
        }
        private void DlyTypeSelectUserControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;
            EntityResult = null;
            EntityResults = null;
            this.gridView1.OptionsSelection.MultiSelect = this.isMulSelect;
            this.Facade = new DlyTypeSelectUserControlFacade(this);
            this.Facade.BindData(this.TreeLevel.PId);
        }
        #region TreeLevelForm
        public override void DeepIn(int pid)
        {
            this.Facade.BindData(pid);
            base.DeepIn(pid);
        }
        public override void DeepOut(int pid)
        {
            pid = this.Facade.BindFaterData(pid);
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
                if (TreeLevel.Level_Deep < 0)
                {
                    if (CancelClick != null)
                    {
                        this.CancelClick(new EventArgs());
                    }
                }
            }
        }
        #endregion

        internal void Bind(DlyTypeCateEntity[] entitys)
        {
            if (BeforeBind != null)
            {
                var args = new CEventArgs<DlyTypeCateEntity[]>(entitys);
                this.BeforeBind(args);
                entitys = args.Para1;
            }
            this.bindingSource1.DataSource = new List<DlyTypeCateEntity>(entitys);
            this.gridControl1.DataSource = this.bindingSource1;
        }

        public DlyTypeCateEntity EntityResult { get; private set; }

        public DlyTypeCateEntity[] EntityResults { get; private set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DeepOut(this.TreeLevel.PId);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle < 0)
                return;
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                EntityResult = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as DlyTypeCateEntity;
                if (EntityResult.HasCate && !this.isCateCanSelect)
                {
                    MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.NotLastNodeCanSelect);
                    return;
                }
                EntityResults = this.gridView1.GetSelectedRows().Select(
                    t => this.gridView1.GetRow(t) as DlyTypeCateEntity
                    ).Where(m => (this.isCateCanSelect || (!m.HasCate && !this.isCateCanSelect))).ToArray();
            }
            if (OKClick != null)
            {
                this.OKClick(new EventArgs());
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks != 2 || this.gridView1.FocusedRowHandle < 0)
                    return;
                var entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as DlyTypeCateEntity;
                if (entity.HasCate)
                {
                    this.DeepIn(entity.DlyTypeId);
                }
                else
                {
                    this.btnOK_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }
    }
    public class DlyTypeSelectUserControl_Design : TreeLevelUserControl<DlyTypeSelectUserControlFacade>
    {
    }
    public class DlyTypeSelectUserControlFacade : ActualBase<DlyTypeSelectUserControl>
    {
        private IDlyTypeService _DlyTypeService = ServiceProxyFactory.Create<IDlyTypeService>();
        public DlyTypeSelectUserControlFacade(DlyTypeSelectUserControl actual)
            : base(actual) { }
        internal void BindData(int pid)
        {
            DlyTypeCateEntity[] entitys = this._DlyTypeService.GetDlyTypeTree(pid);
            if (entitys == null)
                entitys = new DlyTypeCateEntity[0];
            this.Actual.Bind(entitys);
        }

        internal int BindFaterData(int pid)
        {
            var pEntity = this._DlyTypeService.GetDlyTypeById(pid);
            if (pEntity != null)
            {
                this.BindData(pEntity.PId);
                return pEntity.PId;
            }
            return 0;
        }

        internal DlyTypeCateEntity FindEntity(int id)
        {
            var entity = this._DlyTypeService.GetDlyTypeById(id);
            if (entity == null)
                return null;
            var cateentity = new DlyTypeCateEntity();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(cateentity, entity);
            cateentity.HasCate = cateentity.Level_Num > 0;
            return cateentity;
        }
    }
}
