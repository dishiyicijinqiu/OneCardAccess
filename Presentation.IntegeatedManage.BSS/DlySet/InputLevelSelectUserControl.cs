using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class InputLevelSelectUserControl : InputLevelSelectUserControl_Design
    {
        public event VEventHandler<EventArgs> OKClick;
        public event VEventHandler<EventArgs> CancelClick;
        public InputLevelSelectUserControl()
        {
            InitializeComponent();
            this.Bind(new DlyInputLevelInputerEntity[] { });
        }
        private void InputLevelSelectUserControl_Load(object sender, EventArgs e)
        {
            EntityResult = null;
            this.Facade = new InputLevelSelectUserControlFacade(this);
        }
        public DlyInputLevelInputerEntity EntityResult { get; private set; }
        internal void Bind(DlyInputLevelInputerEntity[] entitys)
        {
            this.bindingSource1.DataSource = new List<DlyInputLevelInputerEntity>(entitys);
            this.gridControl1.DataSource = this.bindingSource1;
        }

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

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            EntityResult = null;
            if (CancelClick != null)
            {
                this.CancelClick(new EventArgs());
            }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle < 0)
            {
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.List_AtLeastOne);
                return;
            }
            if (this.gridView1.FocusedRowHandle >= 0)
            {
                EntityResult = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as DlyInputLevelInputerEntity;
            }
            if (OKClick != null)
            {
                this.OKClick(new EventArgs());
            }
        }

        internal void AddEntity(DlyInputLevelInputerEntity entity)
        {
            var datas = this.bindingSource1.DataSource as List<DlyInputLevelInputerEntity>;
            datas.Add(entity);
            this.bindingSource1.ResetBindings(false);
        }

        internal void RemoveEntity(string entityid)
        {
            var datas = this.bindingSource1.DataSource as List<DlyInputLevelInputerEntity>;
            var entity = datas.First(t => t.InputerId == entityid);
            datas.Remove(entity);
            this.bindingSource1.ResetBindings(false);
        }

        internal List<DlyInputLevelInputerEntity> GetData()
        {
            return this.bindingSource1.DataSource as List<DlyInputLevelInputerEntity>;
        }
    }

    public class InputLevelSelectUserControl_Design : Base_UserControl<InputLevelSelectUserControlFacade>
    {
    }
    public class InputLevelSelectUserControlFacade : ActualBase<InputLevelSelectUserControl>
    {
        private IInputLevelService _InputLevelService = ServiceProxyFactory.Create<IInputLevelService>();
        public InputLevelSelectUserControlFacade(InputLevelSelectUserControl actual)
            : base(actual) { }
        //internal void BindData(int pid)
        //{
        //    DlyTypeCateEntity[] entitys = this._DlyTypeService.GetDlyTypeTree(pid);
        //    if (entitys == null)
        //        entitys = new DlyTypeCateEntity[0];
        //    this.Actual.Bind(entitys);
        //}

        //internal int BindFaterData(int pid)
        //{
        //    var pEntity = this._DlyTypeService.GetDlyTypeById(pid);
        //    if (pEntity != null)
        //    {
        //        this.BindData(pEntity.PId);
        //        return pEntity.PId;
        //    }
        //    return 0;
        //}

        //internal DlyTypeCateEntity FindEntity(int id)
        //{
        //    var entity = this._DlyTypeService.GetDlyTypeById(id);
        //    if (entity == null)
        //        return null;
        //    var cateentity = new DlyTypeCateEntity();
        //    FengSharp.Tool.Reflect.ClassValueCopier.Copy(cateentity, entity);
        //    cateentity.HasCate = cateentity.Level_Num > 0;
        //    return cateentity;
        //}
    }
}
