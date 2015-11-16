using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
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

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public partial class UserEditForm : UserEditForm_Design
    {
        #region ctor
        public UserEditForm(ViewType viewtype = ViewType.Add, string id = null)
        {
            InitializeComponent();
            this.EntityId = id;
            this.ViewType = viewtype;
        }
        #endregion
        #region fileds
        public event VEventHandler<CEventArgs<ViewType, string>> AfterEdit;
        public string EntityId { get; set; }
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
                this.dataLayoutControl1.SetReadOnly(isreadonly, new Control[] {
                    this.CreateNameTextEdit,this.CreateDateTextEdit,this.LastModifyNameTextEdit,this.LastModifyDateTextEdit
                });
                this.btnSave.Enabled = !isreadonly;
                //this.chkIsAdmin.ReadOnly = true;
                viewtype = value;
            }
        }
        #endregion

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew((para) =>
            {
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.Assign(para as DevExpress.LookAndFeel.UserLookAndFeel);
                this.Facade = new UserEditFormFacade(this);
                this.Facade.SetData();
            }, DevExpress.LookAndFeel.UserLookAndFeel.Default).ContinueWith(new Action<System.Threading.Tasks.Task>
            ((t) =>
            {
                if (t.Exception != null)
                {
                    this.formLoadErrorExit1.LoadError();
                    MessageBoxEx.Error(t.Exception.InnerException);
                    this.Close();
                }
            })
            );
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
                    this.bindingSource1.EndEdit();
                    var bindEntity = this.bindingSource1.DataSource as UserWithCreateAndModify;
                    var entity = new UserEntity();
                    FengSharp.Tool.Reflect.ClassValueCopier.Copy(entity, bindEntity);
                    Infrastructure.EntityTool.CopyModify(entity);
                    switch (this.ViewType)
                    {
                        case ViewType.Add:
                        case ViewType.CopyAdd:
                            this.EntityId = this.Facade.AddUser(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.AddSuccess);
                            break;
                        case ViewType.Edit:
                            this.Facade.UpdateUser(entity);
                            MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
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
        private void OnAfterEdit()
        {
            if (AfterEdit != null) this.AfterEdit(new CEventArgs<ViewType, string>(this.viewtype, this.EntityId));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public void SetData(UserEntity entity)
        {
            this.Invoke(new Action(() =>
            {
                this.bindingSource1.DataSource = entity;
            }));
        }
    }
    public class UserEditForm_Design : Base_Form<UserEditFormFacade>
    { }
    public class UserEditFormFacade : ActualBase<UserEditForm>
    {
        private IUserService _Service = ServiceProxyFactory.Create<IUserService>();
        public UserEditFormFacade(UserEditForm actual)
            : base(actual)
        { }

        public string AddUser(UserEntity entity)
        {
            AuthIdentity authidentity = AuthPrincipal.CurrentAuthPrincipal.AuthIdentity;
            entity.CreateId = authidentity.UserId;
            entity.CreateDate = DateTime.Now;
            entity.LastModifyId = authidentity.UserId;
            entity.LastModifyDate = DateTime.Now;
            return _Service.CreateUser(entity);
        }

        public void UpdateUser(UserEntity entity)
        {
            AuthIdentity authidentity = AuthPrincipal.CurrentAuthPrincipal.AuthIdentity;
            entity.LastModifyId = authidentity.UserId;
            entity.LastModifyDate = DateTime.Now;
            _Service.UpdateUser(entity);
        }

        public void SetData()
        {
            switch (this.Actual.ViewType)
            {
                case ViewType.Add:
                    {
                        #region Add
                        UserEntity entity = new UserEntity();
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        UserWithCreateAndModify bindentity = new UserWithCreateAndModify();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.CopyAdd:
                    {
                        #region CopyAdd
                        UserEntity entity = this._Service.FindUserById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        Infrastructure.EntityTool.CopyCreateAndModify(entity);
                        UserWithCreateAndModify bindentity = new UserWithCreateAndModify();
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
                        UserEntity entity = this._Service.FindUserById(this.Actual.EntityId);
                        if (entity == null)
                            throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ObjectCannotFind);
                        UserWithCreateAndModify bindentity = new UserWithCreateAndModify();
                        FengSharp.Tool.Reflect.ClassValueCopier.Copy(bindentity, entity);
                        bindentity.CreateName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.CreateId).UserName;
                        bindentity.LastModifyName = ServiceProxyFactory.Create<IUserService>().FindUserById(bindentity.LastModifyId).UserName;
                        this.Actual.SetData(bindentity);
                        #endregion
                    }
                    break;
                case ViewType.Kind:
                case ViewType.AddChild:
                default:
                    throw new BusinessException(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.ErrorType);
            }

        }
    }
}
