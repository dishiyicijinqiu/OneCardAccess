namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    partial class RoleStockControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleStockControl));
            this.baseLayoutControl1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseLayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseGridView();
            this.colStockNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnUnAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAll = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_ShowLine1 = new FengSharp.WinForm.Dev.Components.GridView_ShowLine(this.components);
            this.columnViewGeneColumn1 = new FengSharp.WinForm.Dev.Components.ColumnViewGeneColumn(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.baseLayoutControl1)).BeginInit();
            this.baseLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // baseLayoutControl1
            // 
            this.baseLayoutControl1.Controls.Add(this.gridControl1);
            this.baseLayoutControl1.Controls.Add(this.btnUnAll);
            this.baseLayoutControl1.Controls.Add(this.btnSave);
            this.baseLayoutControl1.Controls.Add(this.btnAll);
            this.baseLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.baseLayoutControl1.Name = "baseLayoutControl1";
            this.baseLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(466, 270, 533, 516);
            this.baseLayoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AlignInGroups;
            this.baseLayoutControl1.Root = this.layoutControlGroup1;
            this.baseLayoutControl1.Size = new System.Drawing.Size(668, 494);
            this.baseLayoutControl1.TabIndex = 44;
            this.baseLayoutControl1.Text = "baseLayoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(6, 36);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(656, 452);
            this.gridControl1.TabIndex = 47;
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
            this.colStockNo,
            this.colStockName,
            this.colStatus});
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
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // colStockNo
            // 
            this.colStockNo.Caption = "仓库编号";
            this.colStockNo.FieldName = "StockNo";
            this.colStockNo.Name = "colStockNo";
            this.colStockNo.Visible = true;
            this.colStockNo.VisibleIndex = 0;
            this.colStockNo.Width = 100;
            // 
            // colStockName
            // 
            this.colStockName.Caption = "仓库名称";
            this.colStockName.FieldName = "StockName";
            this.colStockName.Name = "colStockName";
            this.colStockName.Visible = true;
            this.colStockName.VisibleIndex = 1;
            this.colStockName.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "选中状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 100;
            // 
            // btnUnAll
            // 
            this.btnUnAll.Location = new System.Drawing.Point(110, 6);
            this.btnUnAll.Name = "btnUnAll";
            this.btnUnAll.Size = new System.Drawing.Size(100, 26);
            this.btnUnAll.StyleController = this.baseLayoutControl1;
            this.btnUnAll.TabIndex = 46;
            this.btnUnAll.Text = "反选";
            this.btnUnAll.Click += new System.EventHandler(this.btnUnAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(214, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 26);
            this.btnSave.StyleController = this.baseLayoutControl1;
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(6, 6);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(100, 26);
            this.btnAll.StyleController = this.baseLayoutControl1;
            this.btnAll.TabIndex = 44;
            this.btnAll.Text = "全选";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(668, 494);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnAll;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(104, 30);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(104, 30);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnUnAll;
            this.layoutControlItem2.Location = new System.Drawing.Point(104, 0);
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
            this.layoutControlItem3.Control = this.btnSave;
            this.layoutControlItem3.Location = new System.Drawing.Point(208, 0);
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
            this.emptySpaceItem1.Location = new System.Drawing.Point(312, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(348, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(660, 456);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // columnViewGeneColumn1
            // 
            this.columnViewGeneColumn1.ColumnView = this.gridView1;
            // 
            // RoleStockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseLayoutControl1);
            this.Name = "RoleStockControl";
            this.Size = new System.Drawing.Size(668, 494);
            this.Load += new System.EventHandler(this.RoleStockControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseLayoutControl1)).EndInit();
            this.baseLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infrastructure.WinForm.Base.BaseLayoutControl baseLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnUnAll;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private WinForm.Dev.Components.GridView_ShowLine gridView_ShowLine1;
        private WinForm.Dev.Components.ColumnViewGeneColumn columnViewGeneColumn1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Base.BaseGridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colStockNo;
        private DevExpress.XtraGrid.Columns.GridColumn colStockName;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
