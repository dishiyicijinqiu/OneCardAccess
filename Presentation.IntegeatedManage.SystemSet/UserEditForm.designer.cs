namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    partial class UserEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserEditForm));
            this.bindingSource1 = new System.Windows.Forms.BindingSource();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.UserNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.UserNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.IsLockCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.CreateNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LastModifyNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RemarkTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.CreateDateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LastModifyDateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForUserNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIsLock = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRemark = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCreateName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLastModifyName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCreateDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLastModifyDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.formLoadErrorExit1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormLoadErrorExit();
            this.formStyleSelect1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormStyleSelect();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsLockCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemarkTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyDate)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(FengSharp.OneCardAccess.Domain.RBACModule.Entity.UserWithCreateAndModify);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnClose);
            this.dataLayoutControl1.Controls.Add(this.btnSave);
            this.dataLayoutControl1.Controls.Add(this.UserNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.UserNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.IsLockCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.CreateNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.LastModifyNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.RemarkTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CreateDateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.LastModifyDateTextEdit);
            this.dataLayoutControl1.DataSource = this.bindingSource1;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(637, 278, 470, 497);
            this.dataLayoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AlignInGroups;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(522, 280);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClose.Location = new System.Drawing.Point(410, 242);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.StyleController = this.dataLayoutControl1;
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(306, 242);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 26);
            this.btnSave.StyleController = this.dataLayoutControl1;
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // UserNoTextEdit
            // 
            this.UserNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "UserNo", true));
            this.UserNoTextEdit.Location = new System.Drawing.Point(87, 12);
            this.UserNoTextEdit.Name = "UserNoTextEdit";
            this.UserNoTextEdit.Properties.NullValuePrompt = null;
            this.UserNoTextEdit.Size = new System.Drawing.Size(172, 20);
            this.UserNoTextEdit.StyleController = this.dataLayoutControl1;
            this.UserNoTextEdit.TabIndex = 4;
            // 
            // UserNameTextEdit
            // 
            this.UserNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "UserName", true));
            this.UserNameTextEdit.Location = new System.Drawing.Point(338, 12);
            this.UserNameTextEdit.Name = "UserNameTextEdit";
            this.UserNameTextEdit.Properties.NullValuePrompt = null;
            this.UserNameTextEdit.Size = new System.Drawing.Size(172, 20);
            this.UserNameTextEdit.StyleController = this.dataLayoutControl1;
            this.UserNameTextEdit.TabIndex = 5;
            // 
            // IsLockCheckEdit
            // 
            this.IsLockCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "IsLock", true));
            this.IsLockCheckEdit.Location = new System.Drawing.Point(87, 36);
            this.IsLockCheckEdit.Name = "IsLockCheckEdit";
            this.IsLockCheckEdit.Properties.Caption = "是否锁定";
            this.IsLockCheckEdit.Size = new System.Drawing.Size(172, 19);
            this.IsLockCheckEdit.StyleController = this.dataLayoutControl1;
            this.IsLockCheckEdit.TabIndex = 6;
            // 
            // CreateNameTextEdit
            // 
            this.CreateNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "CreateName", true));
            this.CreateNameTextEdit.Location = new System.Drawing.Point(87, 194);
            this.CreateNameTextEdit.Name = "CreateNameTextEdit";
            this.CreateNameTextEdit.Properties.NullValuePrompt = null;
            this.CreateNameTextEdit.Properties.ReadOnly = true;
            this.CreateNameTextEdit.Size = new System.Drawing.Size(172, 20);
            this.CreateNameTextEdit.StyleController = this.dataLayoutControl1;
            this.CreateNameTextEdit.TabIndex = 10;
            // 
            // LastModifyNameTextEdit
            // 
            this.LastModifyNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "LastModifyName", true));
            this.LastModifyNameTextEdit.Location = new System.Drawing.Point(87, 218);
            this.LastModifyNameTextEdit.Name = "LastModifyNameTextEdit";
            this.LastModifyNameTextEdit.Properties.NullValuePrompt = null;
            this.LastModifyNameTextEdit.Properties.ReadOnly = true;
            this.LastModifyNameTextEdit.Size = new System.Drawing.Size(172, 20);
            this.LastModifyNameTextEdit.StyleController = this.dataLayoutControl1;
            this.LastModifyNameTextEdit.TabIndex = 11;
            // 
            // RemarkTextEdit
            // 
            this.RemarkTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "Remark", true));
            this.RemarkTextEdit.Location = new System.Drawing.Point(87, 59);
            this.RemarkTextEdit.Name = "RemarkTextEdit";
            this.RemarkTextEdit.Properties.NullValuePrompt = null;
            this.RemarkTextEdit.Size = new System.Drawing.Size(423, 131);
            this.RemarkTextEdit.StyleController = this.dataLayoutControl1;
            this.RemarkTextEdit.TabIndex = 7;
            // 
            // CreateDateTextEdit
            // 
            this.CreateDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "CreateDate", true));
            this.CreateDateTextEdit.Location = new System.Drawing.Point(338, 194);
            this.CreateDateTextEdit.Name = "CreateDateTextEdit";
            this.CreateDateTextEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.CreateDateTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateDateTextEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.CreateDateTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateDateTextEdit.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.CreateDateTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.CreateDateTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.CreateDateTextEdit.Properties.NullValuePrompt = null;
            this.CreateDateTextEdit.Properties.ReadOnly = true;
            this.CreateDateTextEdit.Size = new System.Drawing.Size(172, 20);
            this.CreateDateTextEdit.StyleController = this.dataLayoutControl1;
            this.CreateDateTextEdit.TabIndex = 8;
            // 
            // LastModifyDateTextEdit
            // 
            this.LastModifyDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "LastModifyDate", true));
            this.LastModifyDateTextEdit.Location = new System.Drawing.Point(338, 218);
            this.LastModifyDateTextEdit.Name = "LastModifyDateTextEdit";
            this.LastModifyDateTextEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.LastModifyDateTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.LastModifyDateTextEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.LastModifyDateTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.LastModifyDateTextEdit.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.LastModifyDateTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.LastModifyDateTextEdit.Properties.NullValuePrompt = null;
            this.LastModifyDateTextEdit.Properties.ReadOnly = true;
            this.LastModifyDateTextEdit.Size = new System.Drawing.Size(172, 20);
            this.LastModifyDateTextEdit.StyleController = this.dataLayoutControl1;
            this.LastModifyDateTextEdit.TabIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(522, 280);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForUserNo,
            this.ItemForIsLock,
            this.ItemForRemark,
            this.ItemForCreateName,
            this.ItemForLastModifyName,
            this.ItemForUserName,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.ItemForCreateDate,
            this.ItemForLastModifyDate});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup2.Size = new System.Drawing.Size(514, 272);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // ItemForUserNo
            // 
            this.ItemForUserNo.Control = this.UserNoTextEdit;
            this.ItemForUserNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForUserNo.Name = "ItemForUserNo";
            this.ItemForUserNo.Size = new System.Drawing.Size(251, 24);
            this.ItemForUserNo.Text = "用户编号";
            this.ItemForUserNo.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForIsLock
            // 
            this.ItemForIsLock.Control = this.IsLockCheckEdit;
            this.ItemForIsLock.Location = new System.Drawing.Point(0, 24);
            this.ItemForIsLock.Name = "ItemForIsLock";
            this.ItemForIsLock.Size = new System.Drawing.Size(251, 23);
            this.ItemForIsLock.Text = " ";
            this.ItemForIsLock.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForRemark
            // 
            this.ItemForRemark.Control = this.RemarkTextEdit;
            this.ItemForRemark.Location = new System.Drawing.Point(0, 47);
            this.ItemForRemark.Name = "ItemForRemark";
            this.ItemForRemark.Size = new System.Drawing.Size(502, 135);
            this.ItemForRemark.Text = "备注";
            this.ItemForRemark.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForCreateName
            // 
            this.ItemForCreateName.Control = this.CreateNameTextEdit;
            this.ItemForCreateName.Location = new System.Drawing.Point(0, 182);
            this.ItemForCreateName.Name = "ItemForCreateName";
            this.ItemForCreateName.Size = new System.Drawing.Size(251, 24);
            this.ItemForCreateName.Text = "创建人";
            this.ItemForCreateName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForLastModifyName
            // 
            this.ItemForLastModifyName.Control = this.LastModifyNameTextEdit;
            this.ItemForLastModifyName.Location = new System.Drawing.Point(0, 206);
            this.ItemForLastModifyName.Name = "ItemForLastModifyName";
            this.ItemForLastModifyName.Size = new System.Drawing.Size(251, 24);
            this.ItemForLastModifyName.Text = "最后修改人";
            this.ItemForLastModifyName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForUserName
            // 
            this.ItemForUserName.Control = this.UserNameTextEdit;
            this.ItemForUserName.Location = new System.Drawing.Point(251, 0);
            this.ItemForUserName.Name = "ItemForUserName";
            this.ItemForUserName.Size = new System.Drawing.Size(251, 24);
            this.ItemForUserName.Text = "用户名";
            this.ItemForUserName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 230);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(294, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(251, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(251, 23);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnClose;
            this.layoutControlItem2.Location = new System.Drawing.Point(398, 230);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.Location = new System.Drawing.Point(294, 230);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemForCreateDate
            // 
            this.ItemForCreateDate.Control = this.CreateDateTextEdit;
            this.ItemForCreateDate.Location = new System.Drawing.Point(251, 182);
            this.ItemForCreateDate.Name = "ItemForCreateDate";
            this.ItemForCreateDate.Size = new System.Drawing.Size(251, 24);
            this.ItemForCreateDate.Text = "创建日期";
            this.ItemForCreateDate.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForLastModifyDate
            // 
            this.ItemForLastModifyDate.Control = this.LastModifyDateTextEdit;
            this.ItemForLastModifyDate.Location = new System.Drawing.Point(251, 206);
            this.ItemForLastModifyDate.Name = "ItemForLastModifyDate";
            this.ItemForLastModifyDate.Size = new System.Drawing.Size(251, 24);
            this.ItemForLastModifyDate.Text = "最后修改日期";
            this.ItemForLastModifyDate.TextSize = new System.Drawing.Size(72, 13);
            // 
            // formStyleSelect1
            // 
            this.formStyleSelect1.Form = this;
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 280);
            this.Controls.Add(this.dataLayoutControl1);
            this.formLoadErrorExit1.SetEnableLoadError(this, true);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户信息";
            this.Load += new System.EventHandler(this.UserEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsLockCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemarkTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.TextEdit UserNoTextEdit;
        private DevExpress.XtraEditors.TextEdit UserNameTextEdit;
        private DevExpress.XtraEditors.CheckEdit IsLockCheckEdit;
        private DevExpress.XtraEditors.TextEdit CreateNameTextEdit;
        private DevExpress.XtraEditors.TextEdit LastModifyNameTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUserNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUserName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsLock;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRemark;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreateDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastModifyDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreateName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastModifyName;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit RemarkTextEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormLoadErrorExit formLoadErrorExit1;
        private DevExpress.XtraEditors.TextEdit CreateDateTextEdit;
        private DevExpress.XtraEditors.TextEdit LastModifyDateTextEdit;
        private Infrastructure.WinForm.Components.FormStyleSelect formStyleSelect1;
    }
}