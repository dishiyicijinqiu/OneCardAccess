namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    partial class RegisterManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterManageForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnClose = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.btnDelete = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.btnEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseGridView();
            this.colRegisterNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegisterProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegisterNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegisterProductName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegisterFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastModifyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastModifyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCopyAdd = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.btnAdd = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.formLoadErrorExit1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormLoadErrorExit(this.components);
            this.gridView_ShowLine1 = new FengSharp.WinForm.Dev.Components.GridView_ShowLine(this.components);
            this.gridView_MouseMulSelect1 = new FengSharp.WinForm.Dev.Components.GridView_MouseMulSelect(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mainFormMdiProvider1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.MainFormMdiProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Controls.Add(this.btnEdit);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.btnCopyAdd);
            this.layoutControl1.Controls.Add(this.btnAdd);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AlignInGroups;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1101, 610);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClose.Location = new System.Drawing.Point(995, 578);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDelete.Location = new System.Drawing.Point(318, 578);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 26);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnEdit.Location = new System.Drawing.Point(214, 578);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 26);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "编辑(&E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(6, 6);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1089, 568);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.LightYellow;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRegisterNo,
            this.colRegisterProductName,
            this.colStandardCode,
            this.colRegisterNo1,
            this.colRegisterProductName1,
            this.colStandardCode1,
            this.colRegisterFile,
            this.colStartDate,
            this.colEndDate,
            this.colCreateName,
            this.colCreateDate,
            this.colLastModifyName,
            this.colLastModifyDate,
            this.colRemark});
            this.gridView_MouseMulSelect1.SetEnableMouseMulSelect(this.gridView1, true);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsLayout.Columns.StoreLayout = false;
            this.gridView1.OptionsLayout.StoreDataSettings = false;
            this.gridView1.OptionsLayout.StoreVisualOptions = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView_ShowLine1.SetShowLineNo(this.gridView1, true);
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // colRegisterNo
            // 
            this.colRegisterNo.Caption = "注册证编号";
            this.colRegisterNo.FieldName = "RegisterNo";
            this.colRegisterNo.Name = "colRegisterNo";
            this.colRegisterNo.Visible = true;
            this.colRegisterNo.VisibleIndex = 0;
            this.colRegisterNo.Width = 100;
            // 
            // colRegisterProductName
            // 
            this.colRegisterProductName.Caption = "注册证名称";
            this.colRegisterProductName.FieldName = "RegisterProductName";
            this.colRegisterProductName.Name = "colRegisterProductName";
            this.colRegisterProductName.Visible = true;
            this.colRegisterProductName.VisibleIndex = 1;
            this.colRegisterProductName.Width = 100;
            // 
            // colStandardCode
            // 
            this.colStandardCode.Caption = "标准号";
            this.colStandardCode.FieldName = "StandardCode";
            this.colStandardCode.Name = "colStandardCode";
            this.colStandardCode.Visible = true;
            this.colStandardCode.VisibleIndex = 2;
            this.colStandardCode.Width = 100;
            // 
            // colRegisterNo1
            // 
            this.colRegisterNo1.Caption = "注册证编号(英文)";
            this.colRegisterNo1.FieldName = "RegisterNo1";
            this.colRegisterNo1.Name = "colRegisterNo1";
            this.colRegisterNo1.Visible = true;
            this.colRegisterNo1.VisibleIndex = 3;
            this.colRegisterNo1.Width = 100;
            // 
            // colRegisterProductName1
            // 
            this.colRegisterProductName1.Caption = "注册证名称(英文)";
            this.colRegisterProductName1.FieldName = "RegisterProductName1";
            this.colRegisterProductName1.Name = "colRegisterProductName1";
            this.colRegisterProductName1.Visible = true;
            this.colRegisterProductName1.VisibleIndex = 4;
            this.colRegisterProductName1.Width = 100;
            // 
            // colStandardCode1
            // 
            this.colStandardCode1.Caption = "标准号(英文)";
            this.colStandardCode1.FieldName = "StandardCode1";
            this.colStandardCode1.Name = "colStandardCode1";
            this.colStandardCode1.Visible = true;
            this.colStandardCode1.VisibleIndex = 5;
            this.colStandardCode1.Width = 100;
            // 
            // colRegisterFile
            // 
            this.colRegisterFile.Caption = "注册证文件";
            this.colRegisterFile.FieldName = "RegisterFile";
            this.colRegisterFile.Name = "colRegisterFile";
            this.colRegisterFile.Visible = true;
            this.colRegisterFile.VisibleIndex = 6;
            this.colRegisterFile.Width = 100;
            // 
            // colStartDate
            // 
            this.colStartDate.Caption = "启用日期";
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 7;
            this.colStartDate.Width = 100;
            // 
            // colEndDate
            // 
            this.colEndDate.Caption = "停用日期";
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.Visible = true;
            this.colEndDate.VisibleIndex = 8;
            this.colEndDate.Width = 100;
            // 
            // colCreateName
            // 
            this.colCreateName.Caption = "创建人姓名";
            this.colCreateName.FieldName = "CreateName";
            this.colCreateName.Name = "colCreateName";
            this.colCreateName.Visible = true;
            this.colCreateName.VisibleIndex = 9;
            this.colCreateName.Width = 100;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "创建日期";
            this.colCreateDate.FieldName = "CreateDate";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 10;
            this.colCreateDate.Width = 100;
            // 
            // colLastModifyName
            // 
            this.colLastModifyName.Caption = "最后更改人姓名";
            this.colLastModifyName.FieldName = "LastModifyName";
            this.colLastModifyName.Name = "colLastModifyName";
            this.colLastModifyName.Visible = true;
            this.colLastModifyName.VisibleIndex = 11;
            this.colLastModifyName.Width = 100;
            // 
            // colLastModifyDate
            // 
            this.colLastModifyDate.Caption = "最后更改日期";
            this.colLastModifyDate.FieldName = "LastModifyDate";
            this.colLastModifyDate.Name = "colLastModifyDate";
            this.colLastModifyDate.Visible = true;
            this.colLastModifyDate.VisibleIndex = 12;
            this.colLastModifyDate.Width = 100;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 13;
            this.colRemark.Width = 100;
            // 
            // btnCopyAdd
            // 
            this.btnCopyAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyAdd.Image")));
            this.btnCopyAdd.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCopyAdd.Location = new System.Drawing.Point(110, 578);
            this.btnCopyAdd.Name = "btnCopyAdd";
            this.btnCopyAdd.Size = new System.Drawing.Size(100, 26);
            this.btnCopyAdd.TabIndex = 12;
            this.btnCopyAdd.Text = "复制新增";
            this.btnCopyAdd.Click += new System.EventHandler(this.btnCopyAdd_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAdd.Location = new System.Drawing.Point(6, 578);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 26);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "新增(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1101, 610);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1093, 572);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnAdd;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 572);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(208, 572);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnCopyAdd;
            this.layoutControlItem3.Location = new System.Drawing.Point(104, 572);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnDelete;
            this.layoutControlItem5.Location = new System.Drawing.Point(312, 572);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnClose;
            this.layoutControlItem6.Location = new System.Drawing.Point(989, 572);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(416, 572);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(573, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // RegisterManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 610);
            this.Controls.Add(this.layoutControl1);
            this.formLoadErrorExit1.SetEnableLoadError(this, true);
            this.mainFormMdiProvider1.SetEnableMainFormMdi(this, true);
            this.Name = "RegisterManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "产品注册证";
            this.Load += new System.EventHandler(this.RegisterManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseGridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Infrastructure.WinForm.Components.FormLoadErrorExit formLoadErrorExit1;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnClose;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnDelete;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnEdit;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnCopyAdd;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnAdd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private WinForm.Dev.Components.GridView_ShowLine gridView_ShowLine1;
        private WinForm.Dev.Components.GridView_MouseMulSelect gridView_MouseMulSelect1;
        private DevExpress.XtraGrid.Columns.GridColumn colRegisterNo;
        private DevExpress.XtraGrid.Columns.GridColumn colRegisterProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRegisterNo1;
        private DevExpress.XtraGrid.Columns.GridColumn colRegisterProductName1;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colRegisterFile;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastModifyName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastModifyDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Infrastructure.WinForm.Components.MainFormMdiProvider mainFormMdiProvider1;
    }
}