using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Base;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    public partial class RoleActionControl : RoleActionControl_Design
    {
        private string lastbindroleid;
        public RoleActionControl()
        {
            InitializeComponent();
            this.VisibleChanged += RoleActionControl_VisibleChanged;
        }

        void RoleActionControl_VisibleChanged(object sender, EventArgs e)
        {
            this.ResetRoleEntity(this.currentbindentity);
        }

        private void RoleActionControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.Facade = new RoleActionControlFacade(this);
                this.Facade.BindActions();
            }
        }


        private void SetAllCheckedStatus(bool ischecked)
        {
            foreach (Control ctl in this.layoutControl1.Controls)
            {
                CheckEdit checkedit = ctl as CheckEdit;
                if (checkedit == null)
                    continue;
                checkedit.EditValue = ischecked;
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            if (currentbindentity == null) return;
            if (currentbindentity.IsSuper) return;
            SetAllCheckedStatus(true);
        }

        private void btnUnAll_Click(object sender, EventArgs e)
        {
            if (currentbindentity == null) return;
            if (currentbindentity.IsSuper) return;
            SetAllCheckedStatus(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> actionnos = new List<string>();
                foreach (Control ctl in this.layoutControl1.Controls)
                {
                    CheckEdit checkedit = ctl as CheckEdit;
                    if (checkedit == null)
                        continue;
                    if (checkedit.Checked)
                    {
                        string actionno = checkedit.Name.Replace("chk", string.Empty);
                        actionnos.Add(actionno);
                    }
                }
                this.Facade.SaveRoleActions(currentbindentity.RoleId, actionnos.ToArray());
                MessageBoxEx.Info(FengSharp.OneCardAccess.Infrastructure.ResourceMessages.SaveSuccess);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
        }

        public void BindActions(ActionEntity[] entitys)
        {
            this.layoutControl1.BeginUpdate();
            try
            {
                this.lgroupAction.Clear();
                RoleActionHelper.CreateItems(this.lgroupAction, entitys.ToList(), 3);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex);
            }
            finally
            {
                layoutControl1.EndUpdate();
            }
            this.layoutControl1.BestFit();
        }

        public void SetRoleActions(RoleActionEntity[] entitys)
        {
            foreach (Control ctl in this.layoutControl1.Controls)
            {
                CheckEdit checkedit = ctl as CheckEdit;
                if (checkedit == null)
                    continue;
                var roleaction = entitys.FirstOrDefault(t => ctl.Name.EndsWith(t.ActionNo));
                checkedit.EditValue = roleaction != null;
            }
        }

        private void ResetRoleEntity(RoleEntity roleentity)
        {
            bool enable = true;
            if (roleentity == null)
                enable = false;
            else
                enable = ((!roleentity.IsSuper));
            this.btnSave.Enabled = this.btnAll.Enabled = this.btnUnAll.Enabled = enable;
            this.layoutControl1.SetReadOnly(!enable);

            this.layoutControl1.Items.ToList().ForEach((item) =>
            {
                if (item is DevExpress.XtraLayout.LayoutGroup)
                {
                    var group = item as DevExpress.XtraLayout.LayoutGroup;
                    group.CustomHeaderButtons.ForEach((button) =>
                    {
                        button.Properties.Enabled = enable;
                    });
                }
            });
            if (roleentity == null)
            {
                SetAllCheckedStatus(false);
                lastbindroleid = null;
            }
            else
            {
                if (roleentity.RoleId == lastbindroleid)
                    return;
                if (!roleentity.IsSuper && this.Facade != null)
                    this.Facade.SetRoleActions(roleentity);
                else
                    SetAllCheckedStatus(true);
                lastbindroleid = roleentity.RoleId;
            }
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
    }

    public partial class RoleActionControl_Design : Base_UserControl<RoleActionControlFacade>
    {
    }
    public class RoleActionControlFacade : ActualBase<RoleActionControl>
    {
        IAccessService _AccessService = ServiceProxyFactory.Create<IAccessService>();
        IActionService _ActionService = ServiceProxyFactory.Create<IActionService>();
        public RoleActionControlFacade(RoleActionControl actual)
            : base(actual)
        {
        }
        public void BindActions()
        {
            var actions = _ActionService.GetAllEntity();
            this.Actual.BindActions(actions);
        }

        public void SetRoleActions(RoleEntity entity)
        {
            if (entity == null)
                return;
            var roleactions = _ActionService.GetRoleActions(entity.RoleId);
            this.Actual.SetRoleActions(roleactions);
        }

        public void SaveRoleActions(string roleid, string[] actionnos)
        {
            _AccessService.SaveRoleActions(roleid, actionnos);
        }
    }

    internal class RoleActionHelper
    {
        internal static void CreateItems(LayoutControlGroup group, List<ActionEntity> entitys, int perrowcount)
        {
            var menuentitys = entitys.Where(t => string.IsNullOrWhiteSpace(t.ParentActionNo)).ToList();
            List<BaseLayoutItemHolder> childHolders = new List<BaseLayoutItemHolder>();
            foreach (var menuentity in menuentitys)
            {
                BaseLayoutItemHolder holder = CreateHolder(menuentity);
                var childentitys = entitys.Where(t => t.ActionNo != menuentity.ActionNo && t.ActionNo.StartsWith(menuentity.ActionNo)).ToList();
                CreateChildItems(holder.BaseLayoutItem, menuentity.ActionNo, childentitys);
                childHolders.Add(holder);
            }
            var groups = childHolders.OrderBy(t => t.Order).Select(t => t.BaseLayoutItem).ToArray();
            group.AddRange(groups);
            int grouplen = groups.Length;
            for (int i = 1; i < grouplen; i++)
            {
                if (i % perrowcount != 0)
                {
                    groups[i].Move(groups[i - 1], DevExpress.XtraLayout.Utils.InsertType.Right);
                }
                else
                {
                    var rightemptyspaceitem = new DevExpress.XtraLayout.EmptySpaceItem();
                    rightemptyspaceitem.AllowHotTrack = false;
                    rightemptyspaceitem.TextSize = new System.Drawing.Size(0, 0);
                    group.Items.AddRange(new BaseLayoutItem[] { rightemptyspaceitem });
                    rightemptyspaceitem.Move(groups[i - 1], DevExpress.XtraLayout.Utils.InsertType.Right);
                }
            }
        }

        static void CreateChildItems(BaseLayoutItem baseLayoutItem, string parentno, List<ActionEntity> entitys)
        {
            var menuentitys = entitys.Where(t => t.ParentActionNo == parentno).ToList();
            List<BaseLayoutItemHolder> childHolders = new List<BaseLayoutItemHolder>();

            foreach (var menuentity in menuentitys)
            {
                BaseLayoutItemHolder holder = CreateHolder(menuentity);
                var childentitys = entitys.Where(t => t.ActionNo != menuentity.ActionNo && t.ActionNo.StartsWith(menuentity.ActionNo)).ToList();
                CreateChildItems(holder.BaseLayoutItem, menuentity.ActionNo, childentitys);
                childHolders.Add(holder);
            }
            if (baseLayoutItem is LayoutControlGroup)
            {
                var groups = childHolders.OrderBy(t => t.Order).Select(t => t.BaseLayoutItem).ToArray();
                (baseLayoutItem as LayoutControlGroup).AddRange(groups);
            }
        }

        static BaseLayoutItemHolder CreateHolder(ActionEntity childentity)
        {
            BaseLayoutItemHolder holder = new BaseLayoutItemHolder();
            holder.Order = childentity.Order;
            string controltype = childentity.ActionType;
            if (controltype == "auth")
            {
                LayoutControlItem item = new LayoutControlItem();
                item.SizeConstraintsType = SizeConstraintsType.Custom;
                item.ControlMaxSize = new System.Drawing.Size(200, 16);
                item.ControlMinSize = new System.Drawing.Size(200, 16);
                item.TextVisible = false;
                item.Name = "item" + childentity.ActionNo;
                item.Text = childentity.ActionName;
                CheckEdit chk = new CheckEdit();
                chk.Name = "chk" + childentity.ActionNo;
                chk.Text = childentity.ActionName;
                item.Control = chk;
                holder.BaseLayoutItem = item;
            }
            else
            {
                LayoutControlGroup group = new LayoutControlGroup();
                group.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
                group.MaxSize = new System.Drawing.Size(200, 100);
                var groupboxbutton = new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton();
                groupboxbutton.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png");
                groupboxbutton.Style = DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton;
                groupboxbutton.UseCaption = false;
                groupboxbutton.VisibleIndex = 0;
                groupboxbutton.Tag = "A" + childentity.ActionNo;
                group.CustomHeaderButtons.Add(groupboxbutton);

                var groupboxbutton1 = new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton();
                groupboxbutton1.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png");
                groupboxbutton1.Style = DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton;
                groupboxbutton1.UseCaption = false;
                groupboxbutton1.VisibleIndex = 1;
                groupboxbutton1.Tag = "C" + childentity.ActionNo;
                group.CustomHeaderButtons.Add(groupboxbutton1);

                group.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
                group.Name = "item" + childentity.ActionNo;
                group.Text = childentity.ActionName;
                group.CustomButtonClick += group_CustomButtonClick;
                holder.BaseLayoutItem = group;
            }
            return holder;
        }

        static void group_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            LayoutControlGroup group = sender as LayoutControlGroup;
            var layoutcontrol = group.Owner as LayoutControl;
            if (layoutcontrol == null)
                return;
            var roleActionControl = (RoleActionControl)(layoutcontrol.Parent);
            if (roleActionControl == null)
                return;
            if (roleActionControl.CurrentBindEntity == null) return;
            if (roleActionControl.CurrentBindEntity.IsSuper) return;
            if (e.Button.Properties.Tag == null) return;
            string tagstring = e.Button.Properties.Tag.ToString();
            bool chkchecked = tagstring.Substring(0, 1) == "A";
            string menuno = tagstring.Substring(1);
            foreach (Control ctl in layoutcontrol.Controls)
            {
                CheckEdit checkedit = ctl as CheckEdit;
                if (checkedit == null)
                    continue;
                string chkMenuno = checkedit.Name.Substring(3);
                if (chkMenuno.StartsWith(menuno))
                {
                    checkedit.EditValue = chkchecked;
                }
            }
        }

        class BaseLayoutItemHolder
        {
            public int Order { get; set; }
            public BaseLayoutItem BaseLayoutItem { get; set; }
        }
    }
}
