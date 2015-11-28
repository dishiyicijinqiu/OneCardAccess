﻿namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    partial class DlyNdxJYLCManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlyNdxJYLCManageForm));
            this.baseLayoutControl1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseLayoutControl();
            this.btnClose = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.btnRefresh = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseSimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseGridView();
            this.colDlyNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlyTypeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJSRName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZDRName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSHRName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSHRName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSHRName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSummary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.mainFormMdiProvider1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.MainFormMdiProvider(this.components);
            this.formLoadErrorExit1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormLoadErrorExit(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_MouseMulSelect1 = new FengSharp.WinForm.Dev.Components.GridView_MouseMulSelect(this.components);
            this.gridView_ShowLine1 = new FengSharp.WinForm.Dev.Components.GridView_ShowLine(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.baseLayoutControl1)).BeginInit();
            this.baseLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // baseLayoutControl1
            // 
            this.baseLayoutControl1.Controls.Add(this.btnClose);
            this.baseLayoutControl1.Controls.Add(this.btnRefresh);
            this.baseLayoutControl1.Controls.Add(this.gridControl1);
            this.baseLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.baseLayoutControl1.Name = "baseLayoutControl1";
            this.baseLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(937, 202, 250, 350);
            this.baseLayoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AlignInGroups;
            this.baseLayoutControl1.Root = this.layoutControlGroup1;
            this.baseLayoutControl1.Size = new System.Drawing.Size(937, 546);
            this.baseLayoutControl1.TabIndex = 0;
            this.baseLayoutControl1.Text = "baseLayoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClose.Location = new System.Drawing.Point(831, 514);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.btnClose.StyleController = this.baseLayoutControl1;
            this.btnClose.TabIndex = 63;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRefresh.Location = new System.Drawing.Point(6, 514);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 26);
            this.btnRefresh.StyleController = this.baseLayoutControl1;
            this.btnRefresh.TabIndex = 64;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(6, 6);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(925, 504);
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
            this.colDlyNo,
            this.colDlyDate,
            this.colDlyTypeId,
            this.colStockName1,
            this.colStockName2,
            this.colCompanyNo,
            this.colCompanyName,
            this.colJSRName,
            this.colTotal,
            this.colZDRName,
            this.colSHRName1,
            this.colSHRName2,
            this.colSHRName3,
            this.colSummary,
            this.colComment});
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
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // colDlyNo
            // 
            this.colDlyNo.Caption = "单据编号";
            this.colDlyNo.FieldName = "DlyNo";
            this.colDlyNo.Name = "colDlyNo";
            this.colDlyNo.Visible = true;
            this.colDlyNo.VisibleIndex = 0;
            this.colDlyNo.Width = 100;
            // 
            // colDlyDate
            // 
            this.colDlyDate.Caption = "单据日期";
            this.colDlyDate.FieldName = "DlyDate";
            this.colDlyDate.Name = "colDlyDate";
            this.colDlyDate.Visible = true;
            this.colDlyDate.VisibleIndex = 1;
            this.colDlyDate.Width = 100;
            // 
            // colDlyTypeId
            // 
            this.colDlyTypeId.Caption = "单据类型";
            this.colDlyTypeId.FieldName = "DlyTypeId";
            this.colDlyTypeId.Name = "colDlyTypeId";
            this.colDlyTypeId.Visible = true;
            this.colDlyTypeId.VisibleIndex = 2;
            this.colDlyTypeId.Width = 100;
            // 
            // colStockName1
            // 
            this.colStockName1.Caption = "仓库1名称";
            this.colStockName1.FieldName = "StockName1";
            this.colStockName1.Name = "colStockName1";
            this.colStockName1.Visible = true;
            this.colStockName1.VisibleIndex = 3;
            this.colStockName1.Width = 100;
            // 
            // colStockName2
            // 
            this.colStockName2.Caption = "仓库2名称";
            this.colStockName2.FieldName = "StockName2";
            this.colStockName2.Name = "colStockName2";
            this.colStockName2.Visible = true;
            this.colStockName2.VisibleIndex = 4;
            this.colStockName2.Width = 100;
            // 
            // colCompanyNo
            // 
            this.colCompanyNo.Caption = "往来单位编号";
            this.colCompanyNo.FieldName = "CompanyNo";
            this.colCompanyNo.Name = "colCompanyNo";
            this.colCompanyNo.Visible = true;
            this.colCompanyNo.VisibleIndex = 5;
            this.colCompanyNo.Width = 100;
            // 
            // colCompanyName
            // 
            this.colCompanyName.Caption = "往来单位名称";
            this.colCompanyName.FieldName = "CompanyName";
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 6;
            this.colCompanyName.Width = 100;
            // 
            // colJSRName
            // 
            this.colJSRName.Caption = "经手人";
            this.colJSRName.FieldName = "JSRName";
            this.colJSRName.Name = "colJSRName";
            this.colJSRName.Visible = true;
            this.colJSRName.VisibleIndex = 7;
            this.colJSRName.Width = 100;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "金额";
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 8;
            this.colTotal.Width = 100;
            // 
            // colZDRName
            // 
            this.colZDRName.Caption = "制单人姓名";
            this.colZDRName.FieldName = "ZDRName";
            this.colZDRName.Name = "colZDRName";
            this.colZDRName.Visible = true;
            this.colZDRName.VisibleIndex = 9;
            this.colZDRName.Width = 100;
            // 
            // colSHRName1
            // 
            this.colSHRName1.Caption = "一级审核人";
            this.colSHRName1.FieldName = "SHRName1";
            this.colSHRName1.Name = "colSHRName1";
            this.colSHRName1.Visible = true;
            this.colSHRName1.VisibleIndex = 10;
            this.colSHRName1.Width = 100;
            // 
            // colSHRName2
            // 
            this.colSHRName2.Caption = "二级审核人";
            this.colSHRName2.FieldName = "SHRName2";
            this.colSHRName2.Name = "colSHRName2";
            this.colSHRName2.Visible = true;
            this.colSHRName2.VisibleIndex = 11;
            this.colSHRName2.Width = 100;
            // 
            // colSHRName3
            // 
            this.colSHRName3.Caption = "三级审核人";
            this.colSHRName3.FieldName = "SHRName3";
            this.colSHRName3.Name = "colSHRName3";
            this.colSHRName3.Visible = true;
            this.colSHRName3.VisibleIndex = 12;
            this.colSHRName3.Width = 100;
            // 
            // colSummary
            // 
            this.colSummary.Caption = "摘要";
            this.colSummary.FieldName = "Summary";
            this.colSummary.Name = "colSummary";
            this.colSummary.Visible = true;
            this.colSummary.VisibleIndex = 13;
            this.colSummary.Width = 100;
            // 
            // colComment
            // 
            this.colComment.Caption = "附加说明";
            this.colComment.FieldName = "Comment";
            this.colComment.Name = "colComment";
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 14;
            this.colComment.Width = 100;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(937, 546);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(929, 508);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnRefresh;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 508);
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
            this.layoutControlItem3.Control = this.btnClose;
            this.layoutControlItem3.Location = new System.Drawing.Point(825, 508);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(104, 508);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(721, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // DlyNdxJYLCManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 546);
            this.Controls.Add(this.baseLayoutControl1);
            this.formLoadErrorExit1.SetEnableLoadError(this, true);
            this.mainFormMdiProvider1.SetEnableMainFormMdi(this, true);
            this.Name = "DlyNdxJYLCManageForm";
            this.Text = "经营历程";
            this.Load += new System.EventHandler(this.DlyNdxJYLCManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseLayoutControl1)).EndInit();
            this.baseLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infrastructure.WinForm.Base.BaseLayoutControl baseLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private Infrastructure.WinForm.Base.BaseGridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Infrastructure.WinForm.Components.MainFormMdiProvider mainFormMdiProvider1;
        private Infrastructure.WinForm.Components.FormLoadErrorExit formLoadErrorExit1;
        private DevExpress.XtraGrid.Columns.GridColumn colDlyNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDlyDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDlyTypeId;
        private DevExpress.XtraGrid.Columns.GridColumn colStockName1;
        private DevExpress.XtraGrid.Columns.GridColumn colStockName2;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colJSRName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colZDRName;
        private DevExpress.XtraGrid.Columns.GridColumn colSHRName1;
        private DevExpress.XtraGrid.Columns.GridColumn colSHRName2;
        private DevExpress.XtraGrid.Columns.GridColumn colSHRName3;
        private DevExpress.XtraGrid.Columns.GridColumn colSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnClose;
        private Infrastructure.WinForm.Base.BaseSimpleButton btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private WinForm.Dev.Components.GridView_ShowLine gridView_ShowLine1;
        private WinForm.Dev.Components.GridView_MouseMulSelect gridView_MouseMulSelect1;
    }
}