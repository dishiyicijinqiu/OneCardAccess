using FengSharp.OneCardAccess.Infrastructure.WinForm.Components;
using FengSharp.OneCardAccess.Infrastructure.WinForm.Controls;
namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.HR
{
    partial class DeptEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeptEditForm));
            this.layoutControl1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseDataLayoutControl();
            this.btnSave = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.btnClose = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.CreateNameTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.bindlayoutControl1 = new System.Windows.Forms.BindingSource(this.components);
            this.LastModifyNameTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.DeptNoTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.DeptNameTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.RemarkMemoEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseMemoEdit();
            this.CreateDateTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.LastModifyDateTextEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDeptNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRemark = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCreateDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLastModifyDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForCreateName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLastModifyName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDeptName = new DevExpress.XtraLayout.LayoutControlItem();
            this.formLoadErrorExit1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormLoadErrorExit(this.components);
            this.buttonStyleSelect1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.ButtonStyleSelect(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreateNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindlayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeptNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeptNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemarkMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeptNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeptName)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.CreateNameTextEdit);
            this.layoutControl1.Controls.Add(this.LastModifyNameTextEdit);
            this.layoutControl1.Controls.Add(this.DeptNoTextEdit);
            this.layoutControl1.Controls.Add(this.DeptNameTextEdit);
            this.layoutControl1.Controls.Add(this.RemarkMemoEdit);
            this.layoutControl1.Controls.Add(this.CreateDateTextEdit);
            this.layoutControl1.Controls.Add(this.LastModifyDateTextEdit);
            this.layoutControl1.DataSource = this.bindlayoutControl1;
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(617, 322, 494, 472);
            this.layoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AlignInGroups;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(537, 284);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(327, 252);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 26);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClose.Location = new System.Drawing.Point(431, 252);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CreateNameTextEdit
            // 
            this.CreateNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindlayoutControl1, "CreateName", true));
            this.CreateNameTextEdit.Location = new System.Drawing.Point(81, 204);
            this.CreateNameTextEdit.Name = "CreateNameTextEdit";
            this.CreateNameTextEdit.Properties.NullValuePrompt = null;
            this.CreateNameTextEdit.Properties.ReadOnly = true;
            this.CreateNameTextEdit.Size = new System.Drawing.Size(185, 20);
            this.CreateNameTextEdit.StyleController = this.layoutControl1;
            this.CreateNameTextEdit.TabIndex = 4;
            // 
            // bindlayoutControl1
            // 
            this.bindlayoutControl1.DataSource = typeof(FengSharp.OneCardAccess.Domain.HRModule.Entity.DeptCMEntity);
            // 
            // LastModifyNameTextEdit
            // 
            this.LastModifyNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindlayoutControl1, "LastModifyName", true));
            this.LastModifyNameTextEdit.Location = new System.Drawing.Point(81, 228);
            this.LastModifyNameTextEdit.Name = "LastModifyNameTextEdit";
            this.LastModifyNameTextEdit.Properties.NullValuePrompt = null;
            this.LastModifyNameTextEdit.Properties.ReadOnly = true;
            this.LastModifyNameTextEdit.Size = new System.Drawing.Size(185, 20);
            this.LastModifyNameTextEdit.StyleController = this.layoutControl1;
            this.LastModifyNameTextEdit.TabIndex = 5;
            // 
            // DeptNoTextEdit
            // 
            this.DeptNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindlayoutControl1, "DeptNo", true));
            this.DeptNoTextEdit.Location = new System.Drawing.Point(81, 6);
            this.DeptNoTextEdit.Name = "DeptNoTextEdit";
            this.DeptNoTextEdit.Properties.NullValuePrompt = null;
            this.DeptNoTextEdit.Size = new System.Drawing.Size(185, 20);
            this.DeptNoTextEdit.StyleController = this.layoutControl1;
            this.DeptNoTextEdit.TabIndex = 6;
            // 
            // DeptNameTextEdit
            // 
            this.DeptNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindlayoutControl1, "DeptName", true));
            this.DeptNameTextEdit.Location = new System.Drawing.Point(345, 6);
            this.DeptNameTextEdit.Name = "DeptNameTextEdit";
            this.DeptNameTextEdit.Properties.NullValuePrompt = null;
            this.DeptNameTextEdit.Size = new System.Drawing.Size(186, 20);
            this.DeptNameTextEdit.StyleController = this.layoutControl1;
            this.DeptNameTextEdit.TabIndex = 7;
            // 
            // RemarkMemoEdit
            // 
            this.RemarkMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindlayoutControl1, "Remark", true));
            this.RemarkMemoEdit.Location = new System.Drawing.Point(81, 30);
            this.RemarkMemoEdit.Name = "RemarkMemoEdit";
            this.RemarkMemoEdit.Size = new System.Drawing.Size(450, 170);
            this.RemarkMemoEdit.StyleController = this.layoutControl1;
            this.RemarkMemoEdit.TabIndex = 8;
            // 
            // CreateDateTextEdit
            // 
            this.CreateDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindlayoutControl1, "CreateDate", true));
            this.CreateDateTextEdit.Location = new System.Drawing.Point(345, 204);
            this.CreateDateTextEdit.Name = "CreateDateTextEdit";
            this.CreateDateTextEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.CreateDateTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateDateTextEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.CreateDateTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CreateDateTextEdit.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.CreateDateTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.CreateDateTextEdit.Properties.NullValuePrompt = null;
            this.CreateDateTextEdit.Properties.ReadOnly = true;
            this.CreateDateTextEdit.Size = new System.Drawing.Size(186, 20);
            this.CreateDateTextEdit.StyleController = this.layoutControl1;
            this.CreateDateTextEdit.TabIndex = 9;
            // 
            // LastModifyDateTextEdit
            // 
            this.LastModifyDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindlayoutControl1, "LastModifyDate", true));
            this.LastModifyDateTextEdit.Location = new System.Drawing.Point(345, 228);
            this.LastModifyDateTextEdit.Name = "LastModifyDateTextEdit";
            this.LastModifyDateTextEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.LastModifyDateTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.LastModifyDateTextEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.LastModifyDateTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.LastModifyDateTextEdit.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.LastModifyDateTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.LastModifyDateTextEdit.Properties.NullValuePrompt = null;
            this.LastModifyDateTextEdit.Properties.ReadOnly = true;
            this.LastModifyDateTextEdit.Size = new System.Drawing.Size(186, 20);
            this.LastModifyDateTextEdit.StyleController = this.layoutControl1;
            this.LastModifyDateTextEdit.TabIndex = 10;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDeptNo,
            this.ItemForRemark,
            this.ItemForCreateDate,
            this.ItemForLastModifyDate,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.ItemForCreateName,
            this.ItemForLastModifyName,
            this.ItemForDeptName});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(537, 284);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // ItemForDeptNo
            // 
            this.ItemForDeptNo.Control = this.DeptNoTextEdit;
            this.ItemForDeptNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForDeptNo.Name = "ItemForDeptNo";
            this.ItemForDeptNo.Size = new System.Drawing.Size(264, 24);
            this.ItemForDeptNo.Text = "部门编号";
            this.ItemForDeptNo.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForRemark
            // 
            this.ItemForRemark.Control = this.RemarkMemoEdit;
            this.ItemForRemark.Location = new System.Drawing.Point(0, 24);
            this.ItemForRemark.Name = "ItemForRemark";
            this.ItemForRemark.Size = new System.Drawing.Size(529, 174);
            this.ItemForRemark.Text = "备注";
            this.ItemForRemark.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForCreateDate
            // 
            this.ItemForCreateDate.Control = this.CreateDateTextEdit;
            this.ItemForCreateDate.Location = new System.Drawing.Point(264, 198);
            this.ItemForCreateDate.Name = "ItemForCreateDate";
            this.ItemForCreateDate.Size = new System.Drawing.Size(265, 24);
            this.ItemForCreateDate.Text = "创建日期";
            this.ItemForCreateDate.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForLastModifyDate
            // 
            this.ItemForLastModifyDate.Control = this.LastModifyDateTextEdit;
            this.ItemForLastModifyDate.Location = new System.Drawing.Point(264, 222);
            this.ItemForLastModifyDate.Name = "ItemForLastModifyDate";
            this.ItemForLastModifyDate.Size = new System.Drawing.Size(265, 24);
            this.ItemForLastModifyDate.Text = "最后更改日期";
            this.ItemForLastModifyDate.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.Location = new System.Drawing.Point(321, 246);
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
            this.layoutControlItem2.Location = new System.Drawing.Point(425, 246);
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
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 246);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(321, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForCreateName
            // 
            this.ItemForCreateName.Control = this.CreateNameTextEdit;
            this.ItemForCreateName.Location = new System.Drawing.Point(0, 198);
            this.ItemForCreateName.Name = "ItemForCreateName";
            this.ItemForCreateName.Size = new System.Drawing.Size(264, 24);
            this.ItemForCreateName.Text = "创建人";
            this.ItemForCreateName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForLastModifyName
            // 
            this.ItemForLastModifyName.Control = this.LastModifyNameTextEdit;
            this.ItemForLastModifyName.Location = new System.Drawing.Point(0, 222);
            this.ItemForLastModifyName.Name = "ItemForLastModifyName";
            this.ItemForLastModifyName.Size = new System.Drawing.Size(264, 24);
            this.ItemForLastModifyName.Text = "最后更改人";
            this.ItemForLastModifyName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // ItemForDeptName
            // 
            this.ItemForDeptName.Control = this.DeptNameTextEdit;
            this.ItemForDeptName.Location = new System.Drawing.Point(264, 0);
            this.ItemForDeptName.Name = "ItemForDeptName";
            this.ItemForDeptName.Size = new System.Drawing.Size(265, 24);
            this.ItemForDeptName.Text = "部门名称";
            this.ItemForDeptName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // buttonStyleSelect1
            // 
            this.buttonStyleSelect1.SimpleButton = this.btnClose;
            // 
            // DeptEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 284);
            this.Controls.Add(this.layoutControl1);
            this.formLoadErrorExit1.SetEnableLoadError(this, true);
            this.Name = "DeptEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "部门信息";
            this.Load += new System.EventHandler(this.DeptEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CreateNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindlayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeptNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeptNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemarkMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastModifyDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeptNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreateName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastModifyName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeptName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infrastructure.WinForm.Base.BaseDataLayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnClose;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnSave;
        private FormLoadErrorExit formLoadErrorExit1;
        private ButtonStyleSelect buttonStyleSelect1;
        private Infrastructure.WinForm.Base.BaseTextEdit CreateNameTextEdit;
        private System.Windows.Forms.BindingSource bindlayoutControl1;
        private Infrastructure.WinForm.Base.BaseTextEdit LastModifyNameTextEdit;
        private Infrastructure.WinForm.Base.BaseTextEdit DeptNoTextEdit;
        private Infrastructure.WinForm.Base.BaseTextEdit DeptNameTextEdit;
        private Infrastructure.WinForm.Base.BaseMemoEdit RemarkMemoEdit;
        private Infrastructure.WinForm.Base.BaseTextEdit CreateDateTextEdit;
        private Infrastructure.WinForm.Base.BaseTextEdit LastModifyDateTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreateName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastModifyName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeptNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeptName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRemark;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreateDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastModifyDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}