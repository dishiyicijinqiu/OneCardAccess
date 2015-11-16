namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    partial class RoleEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleEditForm));
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.baseDataLayoutControl1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseDataLayoutControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.RoleNoTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.bindbaseDataLayoutControl1 = new System.Windows.Forms.BindingSource(this.components);
            this.RoleNameTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.IsLockCheckEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseCheckEdit();
            this.IsSuperCheckEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseCheckEdit();
            this.RemarkMemoEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseMemoEdit();
            this.CreateNameTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.CreateDateTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.LastModifyNameTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.LastModifyDateTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForRoleNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIsLock = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRemark = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCreateName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLastModifyName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRoleName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIsSuper = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForCreateDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLastModifyDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.formLoadErrorExit1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormLoadErrorExit(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.baseDataLayoutControl1)).BeginInit();
            this.baseDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindbaseDataLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsLockCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsSuperCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemarkMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRoleNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRoleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsSuper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyDate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClose.Location = new System.Drawing.Point(378, 245);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.StyleController = this.baseDataLayoutControl1;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // baseDataLayoutControl1
            // 
            this.baseDataLayoutControl1.Controls.Add(this.btnClose);
            this.baseDataLayoutControl1.Controls.Add(this.btnSave);
            this.baseDataLayoutControl1.Controls.Add(this.RoleNoTextEdit);
            this.baseDataLayoutControl1.Controls.Add(this.RoleNameTextEdit);
            this.baseDataLayoutControl1.Controls.Add(this.IsLockCheckEdit);
            this.baseDataLayoutControl1.Controls.Add(this.IsSuperCheckEdit);
            this.baseDataLayoutControl1.Controls.Add(this.RemarkMemoEdit);
            this.baseDataLayoutControl1.Controls.Add(this.CreateNameTextEdit);
            this.baseDataLayoutControl1.Controls.Add(this.CreateDateTextEdit);
            this.baseDataLayoutControl1.Controls.Add(this.LastModifyNameTextEdit);
            this.baseDataLayoutControl1.Controls.Add(this.LastModifyDateTextEdit);
            this.baseDataLayoutControl1.DataSource = this.bindbaseDataLayoutControl1;
            this.baseDataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseDataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.baseDataLayoutControl1.Name = "baseDataLayoutControl1";
            this.baseDataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(378, 160, 371, 436);
            this.baseDataLayoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AlignInGroups;
            this.baseDataLayoutControl1.Root = this.layoutControlGroup1;
            this.baseDataLayoutControl1.Size = new System.Drawing.Size(484, 277);
            this.baseDataLayoutControl1.TabIndex = 8;
            this.baseDataLayoutControl1.Text = "baseDataLayoutControl1";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(274, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 26);
            this.btnSave.StyleController = this.baseDataLayoutControl1;
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // RoleNoTextEdit
            // 
            this.RoleNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindbaseDataLayoutControl1, "RoleNo", true));
            this.RoleNoTextEdit.Location = new System.Drawing.Point(81, 6);
            this.RoleNoTextEdit.Name = "RoleNoTextEdit";
            this.RoleNoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.RoleNoTextEdit.Size = new System.Drawing.Size(158, 20);
            this.RoleNoTextEdit.StyleController = this.baseDataLayoutControl1;
            this.RoleNoTextEdit.TabIndex = 4;
            // 
            // bindbaseDataLayoutControl1
            // 
            this.bindbaseDataLayoutControl1.DataSource = typeof(FengSharp.OneCardAccess.Domain.RBACModule.Entity.RoleWithCreateAndModify);
            // 
            // RoleNameTextEdit
            // 
            this.RoleNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindbaseDataLayoutControl1, "RoleName", true));
            this.RoleNameTextEdit.Location = new System.Drawing.Point(318, 6);
            this.RoleNameTextEdit.Name = "RoleNameTextEdit";
            this.RoleNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.RoleNameTextEdit.Size = new System.Drawing.Size(160, 20);
            this.RoleNameTextEdit.StyleController = this.baseDataLayoutControl1;
            this.RoleNameTextEdit.TabIndex = 5;
            // 
            // IsLockCheckEdit
            // 
            this.IsLockCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindbaseDataLayoutControl1, "IsLock", true));
            this.IsLockCheckEdit.Location = new System.Drawing.Point(81, 30);
            this.IsLockCheckEdit.Name = "IsLockCheckEdit";
            this.IsLockCheckEdit.Properties.Caption = "是否锁定";
            this.IsLockCheckEdit.Size = new System.Drawing.Size(159, 19);
            this.IsLockCheckEdit.StyleController = this.baseDataLayoutControl1;
            this.IsLockCheckEdit.TabIndex = 6;
            // 
            // IsSuperCheckEdit
            // 
            this.IsSuperCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindbaseDataLayoutControl1, "IsSuper", true));
            this.IsSuperCheckEdit.Location = new System.Drawing.Point(319, 30);
            this.IsSuperCheckEdit.Name = "IsSuperCheckEdit";
            this.IsSuperCheckEdit.Properties.Caption = "是否是超级管理员角色";
            this.IsSuperCheckEdit.Properties.ReadOnly = true;
            this.IsSuperCheckEdit.Size = new System.Drawing.Size(159, 19);
            this.IsSuperCheckEdit.StyleController = this.baseDataLayoutControl1;
            this.IsSuperCheckEdit.TabIndex = 7;
            // 
            // RemarkMemoEdit
            // 
            this.RemarkMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindbaseDataLayoutControl1, "Remark", true));
            this.RemarkMemoEdit.Location = new System.Drawing.Point(81, 53);
            this.RemarkMemoEdit.Name = "RemarkMemoEdit";
            this.RemarkMemoEdit.Size = new System.Drawing.Size(397, 140);
            this.RemarkMemoEdit.StyleController = this.baseDataLayoutControl1;
            this.RemarkMemoEdit.TabIndex = 8;
            // 
            // CreateNameTextEdit
            // 
            this.CreateNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindbaseDataLayoutControl1, "CreateName", true));
            this.CreateNameTextEdit.Location = new System.Drawing.Point(81, 197);
            this.CreateNameTextEdit.Name = "CreateNameTextEdit";
            this.CreateNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.CreateNameTextEdit.Properties.ReadOnly = true;
            this.CreateNameTextEdit.Size = new System.Drawing.Size(159, 20);
            this.CreateNameTextEdit.StyleController = this.baseDataLayoutControl1;
            this.CreateNameTextEdit.TabIndex = 9;
            // 
            // CreateDateTextEdit
            // 
            this.CreateDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindbaseDataLayoutControl1, "CreateDate", true));
            this.CreateDateTextEdit.Location = new System.Drawing.Point(319, 197);
            this.CreateDateTextEdit.Name = "CreateDateTextEdit";
            this.CreateDateTextEdit.Properties.DisplayFormat.FormatString = "d";
            this.CreateDateTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateDateTextEdit.Properties.EditFormat.FormatString = "d";
            this.CreateDateTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateDateTextEdit.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.CreateDateTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.CreateDateTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.CreateDateTextEdit.Properties.ReadOnly = true;
            this.CreateDateTextEdit.Size = new System.Drawing.Size(159, 20);
            this.CreateDateTextEdit.StyleController = this.baseDataLayoutControl1;
            this.CreateDateTextEdit.TabIndex = 10;
            // 
            // LastModifyNameTextEdit
            // 
            this.LastModifyNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindbaseDataLayoutControl1, "LastModifyName", true));
            this.LastModifyNameTextEdit.Location = new System.Drawing.Point(81, 221);
            this.LastModifyNameTextEdit.Name = "LastModifyNameTextEdit";
            this.LastModifyNameTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.LastModifyNameTextEdit.Properties.ReadOnly = true;
            this.LastModifyNameTextEdit.Size = new System.Drawing.Size(159, 20);
            this.LastModifyNameTextEdit.StyleController = this.baseDataLayoutControl1;
            this.LastModifyNameTextEdit.TabIndex = 11;
            // 
            // LastModifyDateTextEdit
            // 
            this.LastModifyDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindbaseDataLayoutControl1, "LastModifyDate", true));
            this.LastModifyDateTextEdit.Location = new System.Drawing.Point(319, 221);
            this.LastModifyDateTextEdit.Name = "LastModifyDateTextEdit";
            this.LastModifyDateTextEdit.Properties.DisplayFormat.FormatString = "d";
            this.LastModifyDateTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.LastModifyDateTextEdit.Properties.EditFormat.FormatString = "d";
            this.LastModifyDateTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.LastModifyDateTextEdit.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.LastModifyDateTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.LastModifyDateTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.LastModifyDateTextEdit.Properties.ReadOnly = true;
            this.LastModifyDateTextEdit.Size = new System.Drawing.Size(159, 20);
            this.LastModifyDateTextEdit.StyleController = this.baseDataLayoutControl1;
            this.LastModifyDateTextEdit.TabIndex = 12;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForRoleNo,
            this.ItemForIsLock,
            this.ItemForRemark,
            this.ItemForCreateName,
            this.ItemForLastModifyName,
            this.ItemForRoleName,
            this.ItemForIsSuper,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.ItemForCreateDate,
            this.ItemForLastModifyDate});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(484, 277);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // ItemForRoleNo
            // 
            this.ItemForRoleNo.Control = this.RoleNoTextEdit;
            this.ItemForRoleNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForRoleNo.Name = "ItemForRoleNo";
            this.ItemForRoleNo.Size = new System.Drawing.Size(237, 24);
            this.ItemForRoleNo.Text = "角色编号";
            this.ItemForRoleNo.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForIsLock
            // 
            this.ItemForIsLock.Control = this.IsLockCheckEdit;
            this.ItemForIsLock.Location = new System.Drawing.Point(0, 24);
            this.ItemForIsLock.Name = "ItemForIsLock";
            this.ItemForIsLock.Size = new System.Drawing.Size(238, 23);
            this.ItemForIsLock.Text = " ";
            this.ItemForIsLock.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForRemark
            // 
            this.ItemForRemark.Control = this.RemarkMemoEdit;
            this.ItemForRemark.Location = new System.Drawing.Point(0, 47);
            this.ItemForRemark.Name = "ItemForRemark";
            this.ItemForRemark.Size = new System.Drawing.Size(476, 144);
            this.ItemForRemark.Text = "备注";
            this.ItemForRemark.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForCreateName
            // 
            this.ItemForCreateName.Control = this.CreateNameTextEdit;
            this.ItemForCreateName.Location = new System.Drawing.Point(0, 191);
            this.ItemForCreateName.Name = "ItemForCreateName";
            this.ItemForCreateName.Size = new System.Drawing.Size(238, 24);
            this.ItemForCreateName.Text = "创建人";
            this.ItemForCreateName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForLastModifyName
            // 
            this.ItemForLastModifyName.Control = this.LastModifyNameTextEdit;
            this.ItemForLastModifyName.Location = new System.Drawing.Point(0, 215);
            this.ItemForLastModifyName.Name = "ItemForLastModifyName";
            this.ItemForLastModifyName.Size = new System.Drawing.Size(238, 24);
            this.ItemForLastModifyName.Text = "最后更改人";
            this.ItemForLastModifyName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForRoleName
            // 
            this.ItemForRoleName.Control = this.RoleNameTextEdit;
            this.ItemForRoleName.Location = new System.Drawing.Point(237, 0);
            this.ItemForRoleName.Name = "ItemForRoleName";
            this.ItemForRoleName.Size = new System.Drawing.Size(239, 24);
            this.ItemForRoleName.Text = "角色名称";
            this.ItemForRoleName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForIsSuper
            // 
            this.ItemForIsSuper.Control = this.IsSuperCheckEdit;
            this.ItemForIsSuper.Location = new System.Drawing.Point(238, 24);
            this.ItemForIsSuper.Name = "ItemForIsSuper";
            this.ItemForIsSuper.Size = new System.Drawing.Size(238, 23);
            this.ItemForIsSuper.Text = " ";
            this.ItemForIsSuper.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.Location = new System.Drawing.Point(268, 239);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnClose;
            this.layoutControlItem2.Location = new System.Drawing.Point(372, 239);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 239);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(268, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForCreateDate
            // 
            this.ItemForCreateDate.Control = this.CreateDateTextEdit;
            this.ItemForCreateDate.Location = new System.Drawing.Point(238, 191);
            this.ItemForCreateDate.Name = "ItemForCreateDate";
            this.ItemForCreateDate.Size = new System.Drawing.Size(238, 24);
            this.ItemForCreateDate.Text = "创建日期";
            this.ItemForCreateDate.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForLastModifyDate
            // 
            this.ItemForLastModifyDate.Control = this.LastModifyDateTextEdit;
            this.ItemForLastModifyDate.Location = new System.Drawing.Point(238, 215);
            this.ItemForLastModifyDate.Name = "ItemForLastModifyDate";
            this.ItemForLastModifyDate.Size = new System.Drawing.Size(238, 24);
            this.ItemForLastModifyDate.Text = "最后更改日期";
            this.ItemForLastModifyDate.TextSize = new System.Drawing.Size(72, 13);
            // 
            // RoleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 277);
            this.Controls.Add(this.baseDataLayoutControl1);
            this.formLoadErrorExit1.SetEnableLoadError(this, true);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoleEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "角色信息";
            this.Load += new System.EventHandler(this.RoleEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseDataLayoutControl1)).EndInit();
            this.baseDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindbaseDataLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsLockCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsSuperCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemarkMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRoleNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRoleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsSuper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormLoadErrorExit formLoadErrorExit1;
        private Infrastructure.WinForm.Base.BaseDataLayoutControl baseDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Infrastructure.WinForm.Base.BaseTextEdit RoleNoTextEdit;
        private System.Windows.Forms.BindingSource bindbaseDataLayoutControl1;
        private Infrastructure.WinForm.Base.BaseTextEdit RoleNameTextEdit;
        private Infrastructure.WinForm.Base.BaseCheckEdit IsLockCheckEdit;
        private Infrastructure.WinForm.Base.BaseCheckEdit IsSuperCheckEdit;
        private Infrastructure.WinForm.Base.BaseMemoEdit RemarkMemoEdit;
        private Infrastructure.WinForm.Base.BaseTextEdit CreateNameTextEdit;
        private Infrastructure.WinForm.Base.BaseTextEdit CreateDateTextEdit;
        private Infrastructure.WinForm.Base.BaseTextEdit LastModifyNameTextEdit;
        private Infrastructure.WinForm.Base.BaseTextEdit LastModifyDateTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRoleNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRoleName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsLock;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsSuper;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRemark;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreateName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreateDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastModifyName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastModifyDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}