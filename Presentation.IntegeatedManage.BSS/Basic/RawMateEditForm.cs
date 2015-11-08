using DevExpress.XtraEditors;
using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services.Interface;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Windows.Forms;
using System.Linq;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Helper;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public partial class RawMateEditForm : RawMateEditForm_Design
    {
        public RawMateEditForm(int pid, ViewType viewtype = ViewType.Add, int id = 0)
        {
            InitializeComponent();
            this.EntityId = id;
            this.PId = pid;
            this.ViewType = viewtype;
        }
        public event VEventHandler<CEventArgs<ViewType, int, int>> AfterEdit;
        public int EntityId { get; set; }
        public int PId { get; set; }
        ViewType viewtype = ViewType.ReadOnly;
        public ViewType ViewType
        {
            get
            {
                return viewtype;
            }
            set
            {
                bool isreadonly = value == ViewType.ReadOnly;
                this.baseDataLayoutControl1.SetReadOnly(isreadonly, new Control[]{
                    this.CreateDateTextEdit,this.CreateNameTextEdit,this.LastModifyNameTextEdit,this.LastModifyDateTextEdit
                });
                this.btnSave.Enabled = !isreadonly;
                viewtype = value;
            }
        }
        private void RawMateEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new RawMateEditFormFacade(this);
                this.Facade.SetData();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
                this.formLoadErrorExit1.LoadError();
            }
        }

        private void OnAfterEdit()
        {
            if (AfterEdit != null)
                this.AfterEdit(new CEventArgs<ViewType, int, int>(this.viewtype, this.EntityId, this.PId));
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ViewType == ViewType.ReadOnly)
                {

                }
                else
                {
                    this.bindbaseDataLayoutControl1.EndEdit();
                    var entity = new RawMateEntity();
                    FengSharp.Tool.Reflect.ClassValueCopier.Copy(entity, this.bindbaseDataLayoutControl1.DataSource);
                    Infrastructure.EntityTool.CopyModify(entity);
                    switch (this.ViewType)
                    {
                        case ViewType.Add:
                        case ViewType.CopyAdd:
                            this.EntityId = this.Facade.CreateRawMate(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.AddSuccess);
                            break;
                        case ViewType.Edit:
                            this.Facade.UpdateRawMate(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
                            break;
                        case ViewType.Kind:
                            this.EntityId = this.Facade.CreateRawMate(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.CateSuccess);
                            break;
                    }
                }
                OnAfterEdit();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
        internal void SetData(RawMateCMCateEntity bindentity)
        {
            this.bindbaseDataLayoutControl1.DataSource = bindentity;
        }

        internal void BindUnit(DicDataEntity[] RUnits)
        {
            new PopupContainerEditPopupListBoxHelper(this.UnitPopupContainerEdit.Properties)
            {
                DataSource = RUnits,
                DisplayMember = "DicValue",
                ValueMember = "DicValue"
            };
        }

        private void QtyModeImageComboBoxEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.UnitPopupContainerEdit.Properties.PopupControl == null)
            {
                this.Facade.BindData(); return;
            }
            var ctl = this.UnitPopupContainerEdit.Properties.PopupControl.Controls[0];
            var p = ctl.GetType().GetProperty("DataSource");
            if (p.GetValue(ctl, null) == null)
                this.Facade.BindData();
        }
    }

    public class RawMateEditForm_Design : Base_Form<RawMateEditFormFacade>
    {

    }
    public class RawMateEditFormFacade : ActualBase<RawMateEditForm>
    {
        private IRawMateService _RawMateService = ServiceProxyFactory.Create<IRawMateService>();
        public RawMateEditFormFacade(RawMateEditForm actual)
            : base(actual) { }

        internal RawMateCMCateEntity FindEntity(int entityId)
        {
            var entity = this._RawMateService.GetRawMateById(entityId);
            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                case ViewType.CopyAdd:
                    if (entity == null)
                        return null;
                    AuthIdentity authidentity = (System.Threading.Thread.CurrentPrincipal as AuthPrincipal).Identity as AuthIdentity;
                    entity.CreateId = authidentity.UserId;
                    entity.CreateDate = DateTime.Now;
                    entity.LastModifyDate = DateTime.Now;
                    entity.LastModifyId = authidentity.UserId;
                    break;
                case ViewType.Edit:
                case ViewType.ReadOnly:
                case ViewType.Kind:
                default:
                    if (entity == null)
                        throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                    break;
            }
            var cmcateentity = new RawMateCMCateEntity();
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(cmcateentity, entity);
            cmcateentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(cmcateentity.CreateId).UserName;
            cmcateentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(cmcateentity.LastModifyId).UserName;
            //注册证信息赋值
            //cmcateentity.RegisterNo
            //图纸信息赋值
            //cmcateentity.DrawingName
            return cmcateentity;
        }

        internal int CreateRawMate(RawMateEntity entity)
        {
            return this._RawMateService.CreateRawMate(entity);
        }

        internal void UpdateRawMate(RawMateEntity entity)
        {
            this._RawMateService.UpdateRawMate(entity);
        }

        internal void BindData()
        {
            DicDataEntity[] entitys = ServiceProxyFactory.Create<IDicDataService>().GetDataByDicTypes(
             new string[] { 
                        "RUnit"//,"Duty", "Title","Origin","Nation"
                    }
                );
            var RUnits = entitys.Where(t => string.Compare(t.DicType, "RUnit", true) == 0).ToArray();
            this.Actual.BindUnit(RUnits);
        }

        internal void SetData()
        {
            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                    {
                        #region Add
                        RawMateEntity entity = new RawMateEntity();
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        entity.PId = this.Actual.PId;
                        RawMateCMCateEntity bindentity = new RawMateCMCateEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.CopyAdd:
                case ViewType.Kind:
                    {
                        #region CopyAdd,Kind
                        RawMateEntity entity = this._RawMateService.GetRawMateById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        entity.PId = this.Actual.PId;
                        RawMateCMCateEntity bindentity = new RawMateCMCateEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        bindentity.Remark1 = string.Empty;
                        bindentity.Remark2 = string.Empty;
                        bindentity.Remark3 = string.Empty;
                        bindentity.Remark4 = string.Empty;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.Edit:
                case ViewType.ReadOnly:
                    {
                        #region Edit,ReadOnly
                        RawMateEntity entity = this._RawMateService.GetRawMateById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        RawMateCMCateEntity bindentity = new RawMateCMCateEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.AddChild:
                default:
                    throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ErrorType);
            }
        }
    }
}