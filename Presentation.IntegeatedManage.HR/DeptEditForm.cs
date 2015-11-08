using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using FengSharp.OneCardAccess.Domain.HRModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.Events;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    public partial class DeptEditForm : DeptEditForm_Design
    {
        public DeptEditForm(int pid, ViewType viewtype = ViewType.Add, int id = 0)
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
                this.layoutControl1.SetReadOnly(isreadonly, new Control[]{
                    this.CreateDateTextEdit,this.CreateNameTextEdit,this.LastModifyNameTextEdit,this.LastModifyDateTextEdit
                });
                this.btnSave.Enabled = !isreadonly;
                viewtype = value;
            }
        }
        private void DeptEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Facade = new DeptEditFormFacade(this);
                this.Facade.SetData();
            }
            catch (Exception ex)
            {
                this.formLoadErrorExit1.LoadError();
                MessageBoxEx.Error(ex);
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
                    this.bindlayoutControl1.EndEdit();
                    var entity = new DeptEntity();
                    FengSharp.Tool.Reflect.ClassValueCopier.Copy(entity, this.bindlayoutControl1.DataSource);
                    Infrastructure.EntityTool.CopyModify(entity);
                    switch (this.ViewType)
                    {
                        case ViewType.Add:
                        case ViewType.CopyAdd:
                            this.EntityId = this.Facade.CreateDept(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.AddSuccess);
                            break;
                        case ViewType.Edit:
                            this.Facade.UpdateDept(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
                            break;
                        case ViewType.Kind:
                            this.EntityId = this.Facade.CreateDept(entity);
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

        internal void SetData(DeptCMEntity bindentity)
        {
            this.bindlayoutControl1.DataSource = bindentity;
        }
    }
    public class DeptEditForm_Design : Base_Form<DeptEditFormFacade>
    {
    }
    public class DeptEditFormFacade : ActualBase<DeptEditForm>
    {
        private IDeptService _DeptService = ServiceProxyFactory.Create<IDeptService>();

        public DeptEditFormFacade(DeptEditForm actual)
            : base(actual) { }

        internal int CreateDept(DeptEntity entity)
        {
            return this._DeptService.CreateDept(entity);
        }

        internal void UpdateDept(DeptEntity entity)
        {
            this._DeptService.UpdateDept(entity);
        }

        internal void SetData()
        {
            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                    {
                        #region Add
                        DeptEntity entity = new DeptEntity();
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        entity.PId = this.Actual.PId;
                        DeptCMEntity bindentity = new DeptCMEntity();
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
                        DeptEntity entity = this._DeptService.GetDeptById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        entity.PId = this.Actual.PId;
                        DeptCMEntity bindentity = new DeptCMEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.Edit:
                case ViewType.ReadOnly:
                    {
                        #region Edit,ReadOnly
                        DeptEntity entity = this._DeptService.GetDeptById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        DeptCMEntity bindentity = new DeptCMEntity();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.AddChild:
                    break;
                default:
                    break;
            }
        }
    }
}