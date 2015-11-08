namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.CRM
{
    partial class CompanyManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyManageForm));
            this.baseLayoutControl1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseLayoutControl();
            this.btnClose = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.btnCopyAdd = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.btnKind = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.btnEdit = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.btnDelete = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseGridView();
            this.colCompanyNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPostCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankAndAcount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colARTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAPTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastModifyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastModifyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainFormMdiProvider1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.MainFormMdiProvider(this.components);
            this.gridView_ShowCate1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.GridView_ShowCate(this.components);
            this.gridView_MouseMulSelect1 = new FengSharp.WinForm.Dev.Components.GridView_MouseMulSelect(this.components);
            this.formLoadErrorExit1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormLoadErrorExit(this.components);
            this.columnViewGeneColumn1 = new FengSharp.WinForm.Dev.Components.ColumnViewGeneColumn(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.baseLayoutControl1)).BeginInit();
            this.baseLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // baseLayoutControl1
            // 
            this.baseLayoutControl1.Controls.Add(this.btnClose);
            this.baseLayoutControl1.Controls.Add(this.btnCopyAdd);
            this.baseLayoutControl1.Controls.Add(this.btnKind);
            this.baseLayoutControl1.Controls.Add(this.btnEdit);
            this.baseLayoutControl1.Controls.Add(this.btnDelete);
            this.baseLayoutControl1.Controls.Add(this.gridControl1);
            this.baseLayoutControl1.Controls.Add(this.btnAdd);
            this.baseLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.baseLayoutControl1.Name = "baseLayoutControl1";
            this.baseLayoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AlignInGroups;
            this.baseLayoutControl1.Root = this.layoutControlGroup1;
            this.baseLayoutControl1.Size = new System.Drawing.Size(988, 536);
            this.baseLayoutControl1.TabIndex = 0;
            this.baseLayoutControl1.Text = "baseLayoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClose.Location = new System.Drawing.Point(882, 504);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.StyleController = this.baseLayoutControl1;
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCopyAdd
            // 
            this.btnCopyAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyAdd.Image")));
            this.btnCopyAdd.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCopyAdd.Location = new System.Drawing.Point(110, 504);
            this.btnCopyAdd.Name = "btnCopyAdd";
            this.btnCopyAdd.Size = new System.Drawing.Size(100, 26);
            this.btnCopyAdd.StyleController = this.baseLayoutControl1;
            this.btnCopyAdd.TabIndex = 18;
            this.btnCopyAdd.Text = "复制新增";
            this.btnCopyAdd.Click += new System.EventHandler(this.btnCopyAdd_Click);
            // 
            // btnKind
            // 
            this.btnKind.Image = ((System.Drawing.Image)(resources.GetObject("btnKind.Image")));
            this.btnKind.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnKind.Location = new System.Drawing.Point(422, 504);
            this.btnKind.Name = "btnKind";
            this.btnKind.Size = new System.Drawing.Size(100, 26);
            this.btnKind.StyleController = this.baseLayoutControl1;
            this.btnKind.TabIndex = 20;
            this.btnKind.Text = "分类(&K)";
            this.btnKind.Click += new System.EventHandler(this.btnKind_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnEdit.Location = new System.Drawing.Point(214, 504);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 26);
            this.btnEdit.StyleController = this.baseLayoutControl1;
            this.btnEdit.TabIndex = 19;
            this.btnEdit.Text = "编辑(&E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDelete.Location = new System.Drawing.Point(318, 504);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 26);
            this.btnDelete.StyleController = this.baseLayoutControl1;
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(6, 6);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(976, 494);
            this.gridControl1.TabIndex = 1;
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
            this.colCompanyNo,
            this.colCompanyName,
            this.colAddress,
            this.colTel,
            this.colFax,
            this.colPostCode,
            this.colEMail,
            this.colPerson,
            this.colBankAndAcount,
            this.colTaxNumber,
            this.colARTotal,
            this.colAPTotal,
            this.colCreateName,
            this.colCreateDate,
            this.colLastModifyName,
            this.colLastModifyDate,
            this.colEnable,
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
            this.gridView_ShowCate1.SetShowCate(this.gridView1, true);
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colCompanyNo
            // 
            this.colCompanyNo.Caption = "单位编号";
            this.colCompanyNo.FieldName = "CompanyNo";
            this.colCompanyNo.Name = "colCompanyNo";
            this.colCompanyNo.Visible = true;
            this.colCompanyNo.VisibleIndex = 0;
            this.colCompanyNo.Width = 100;
            // 
            // colCompanyName
            // 
            this.colCompanyName.Caption = "单位名称";
            this.colCompanyName.FieldName = "CompanyName";
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 1;
            this.colCompanyName.Width = 100;
            // 
            // colAddress
            // 
            this.colAddress.Caption = "单位地址";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 2;
            this.colAddress.Width = 100;
            // 
            // colTel
            // 
            this.colTel.Caption = "电话";
            this.colTel.FieldName = "Tel";
            this.colTel.Name = "colTel";
            this.colTel.Visible = true;
            this.colTel.VisibleIndex = 3;
            this.colTel.Width = 100;
            // 
            // colFax
            // 
            this.colFax.Caption = "传真";
            this.colFax.FieldName = "Fax";
            this.colFax.Name = "colFax";
            this.colFax.Visible = true;
            this.colFax.VisibleIndex = 4;
            this.colFax.Width = 100;
            // 
            // colPostCode
            // 
            this.colPostCode.Caption = "邮政编码";
            this.colPostCode.FieldName = "PostCode";
            this.colPostCode.Name = "colPostCode";
            this.colPostCode.Visible = true;
            this.colPostCode.VisibleIndex = 5;
            this.colPostCode.Width = 100;
            // 
            // colEMail
            // 
            this.colEMail.Caption = "电子邮件";
            this.colEMail.FieldName = "EMail";
            this.colEMail.Name = "colEMail";
            this.colEMail.Visible = true;
            this.colEMail.VisibleIndex = 6;
            this.colEMail.Width = 100;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "联系人";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 7;
            this.colPerson.Width = 100;
            // 
            // colBankAndAcount
            // 
            this.colBankAndAcount.Caption = "开户银行";
            this.colBankAndAcount.FieldName = "BankAndAcount";
            this.colBankAndAcount.Name = "colBankAndAcount";
            this.colBankAndAcount.Visible = true;
            this.colBankAndAcount.VisibleIndex = 8;
            this.colBankAndAcount.Width = 100;
            // 
            // colTaxNumber
            // 
            this.colTaxNumber.Caption = "税号";
            this.colTaxNumber.FieldName = "TaxNumber";
            this.colTaxNumber.Name = "colTaxNumber";
            this.colTaxNumber.Visible = true;
            this.colTaxNumber.VisibleIndex = 9;
            this.colTaxNumber.Width = 100;
            // 
            // colARTotal
            // 
            this.colARTotal.Caption = "应收";
            this.colARTotal.FieldName = "ARTotal";
            this.colARTotal.Name = "colARTotal";
            this.colARTotal.Visible = true;
            this.colARTotal.VisibleIndex = 10;
            this.colARTotal.Width = 100;
            // 
            // colAPTotal
            // 
            this.colAPTotal.Caption = "应付";
            this.colAPTotal.FieldName = "APTotal";
            this.colAPTotal.Name = "colAPTotal";
            this.colAPTotal.Visible = true;
            this.colAPTotal.VisibleIndex = 11;
            this.colAPTotal.Width = 100;
            // 
            // colCreateName
            // 
            this.colCreateName.Caption = "创建人";
            this.colCreateName.FieldName = "CreateName";
            this.colCreateName.Name = "colCreateName";
            this.colCreateName.Visible = true;
            this.colCreateName.VisibleIndex = 12;
            this.colCreateName.Width = 100;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "创建日期";
            this.colCreateDate.FieldName = "CreateDate";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 13;
            this.colCreateDate.Width = 100;
            // 
            // colLastModifyName
            // 
            this.colLastModifyName.Caption = "最后更改人";
            this.colLastModifyName.FieldName = "LastModifyName";
            this.colLastModifyName.Name = "colLastModifyName";
            this.colLastModifyName.Visible = true;
            this.colLastModifyName.VisibleIndex = 14;
            this.colLastModifyName.Width = 100;
            // 
            // colLastModifyDate
            // 
            this.colLastModifyDate.Caption = "最后更改日期";
            this.colLastModifyDate.FieldName = "LastModifyDate";
            this.colLastModifyDate.Name = "colLastModifyDate";
            this.colLastModifyDate.Visible = true;
            this.colLastModifyDate.VisibleIndex = 15;
            this.colLastModifyDate.Width = 100;
            // 
            // colEnable
            // 
            this.colEnable.Caption = "是否启用";
            this.colEnable.FieldName = "Enable";
            this.colEnable.Name = "colEnable";
            this.colEnable.Visible = true;
            this.colEnable.VisibleIndex = 16;
            this.colEnable.Width = 100;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 17;
            this.colRemark.Width = 100;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAdd.Location = new System.Drawing.Point(6, 504);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 26);
            this.btnAdd.StyleController = this.baseLayoutControl1;
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "新增(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(988, 536);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(980, 498);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnAdd;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 498);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnCopyAdd;
            this.layoutControlItem3.Location = new System.Drawing.Point(104, 498);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(208, 498);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnDelete;
            this.layoutControlItem5.Location = new System.Drawing.Point(312, 498);
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
            this.layoutControlItem6.Control = this.btnKind;
            this.layoutControlItem6.Location = new System.Drawing.Point(416, 498);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnClose;
            this.layoutControlItem7.Location = new System.Drawing.Point(876, 498);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(520, 498);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(356, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // columnViewGeneColumn1
            // 
            this.columnViewGeneColumn1.ColumnView = this.gridView1;
            // 
            // CompanyManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 536);
            this.Controls.Add(this.baseLayoutControl1);
            this.formLoadErrorExit1.SetEnableLoadError(this, true);
            this.mainFormMdiProvider1.SetEnableMainFormMdi(this, true);
            this.Name = "CompanyManageForm";
            this.Text = "往来单位信息";
            this.Load += new System.EventHandler(this.CompanyManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseLayoutControl1)).EndInit();
            this.baseLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infrastructure.WinForm.Base.BaseLayoutControl baseLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.BindingSource bindingSource;
        private Infrastructure.WinForm.Components.MainFormMdiProvider mainFormMdiProvider1;
        private Infrastructure.WinForm.Components.GridView_ShowCate gridView_ShowCate1;
        private WinForm.Dev.Components.GridView_MouseMulSelect gridView_MouseMulSelect1;
        private Infrastructure.WinForm.Components.FormLoadErrorExit formLoadErrorExit1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseGridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnClose;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnKind;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnEdit;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnCopyAdd;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnDelete;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnAdd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private WinForm.Dev.Components.ColumnViewGeneColumn columnViewGeneColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colTel;
        private DevExpress.XtraGrid.Columns.GridColumn colFax;
        private DevExpress.XtraGrid.Columns.GridColumn colPostCode;
        private DevExpress.XtraGrid.Columns.GridColumn colEMail;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colBankAndAcount;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colARTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colAPTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastModifyName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastModifyDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEnable;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
    }
}