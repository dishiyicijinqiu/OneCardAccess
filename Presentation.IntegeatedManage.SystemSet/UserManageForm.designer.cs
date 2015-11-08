namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.SystemSet
{
    partial class UserManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManageForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditView = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopyAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastModifyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastModifyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.mainFormMdiProvider1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.MainFormMdiProvider();
            this.gridView_MouseMulSelect1 = new FengSharp.WinForm.Dev.Components.GridView_MouseMulSelect();
            this.gridView_ShowLine1 = new FengSharp.WinForm.Dev.Components.GridView_ShowLine();
            this.buttonStyle1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.ButtonStyle();
            this.formLoadErrorExit1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormLoadErrorExit();
            this.gridViewColumnWidthComponent1 = new FengSharp.OneCardAccess.Infrastructure.WinForm.Components.GridViewColumnWidthComponent();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnEditView);
            this.layoutControl1.Controls.Add(this.btnCopyAdd);
            this.layoutControl1.Controls.Add(this.btnDel);
            this.layoutControl1.Controls.Add(this.btnAdd);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(421, 78, 704, 511);
            this.layoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AlignInGroups;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1042, 533);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnClose
            // 
            this.buttonStyle1.SetEnableStyle(this.btnClose, true);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClose.Location = new System.Drawing.Point(936, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 26);
            this.buttonStyle1.SetStyle(this.btnClose, FengSharp.OneCardAccess.Infrastructure.WinForm.Components.ButtonStyleKind.CloseWithSmallImage);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭(&C)";
            this.buttonStyle1.SetUseDefaultText(this.btnClose, true);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEditView
            // 
            this.buttonStyle1.SetEnableStyle(this.btnEditView, true);
            this.btnEditView.Image = ((System.Drawing.Image)(resources.GetObject("btnEditView.Image")));
            this.btnEditView.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnEditView.Location = new System.Drawing.Point(214, 501);
            this.btnEditView.Name = "btnEditView";
            this.btnEditView.Size = new System.Drawing.Size(100, 26);
            this.buttonStyle1.SetStyle(this.btnEditView, FengSharp.OneCardAccess.Infrastructure.WinForm.Components.ButtonStyleKind.EditWithSmallImage);
            this.btnEditView.StyleController = this.layoutControl1;
            this.btnEditView.TabIndex = 7;
            this.btnEditView.Text = "编辑(&E)";
            this.buttonStyle1.SetUseDefaultText(this.btnEditView, true);
            this.btnEditView.Click += new System.EventHandler(this.btnEditView_Click);
            // 
            // btnCopyAdd
            // 
            this.buttonStyle1.SetEnableStyle(this.btnCopyAdd, true);
            this.btnCopyAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyAdd.Image")));
            this.btnCopyAdd.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCopyAdd.Location = new System.Drawing.Point(110, 501);
            this.btnCopyAdd.Name = "btnCopyAdd";
            this.btnCopyAdd.Size = new System.Drawing.Size(100, 26);
            this.buttonStyle1.SetStyle(this.btnCopyAdd, FengSharp.OneCardAccess.Infrastructure.WinForm.Components.ButtonStyleKind.CopyAddWithSmallImage);
            this.btnCopyAdd.StyleController = this.layoutControl1;
            this.btnCopyAdd.TabIndex = 6;
            this.btnCopyAdd.Text = "复制新增";
            this.buttonStyle1.SetUseDefaultText(this.btnCopyAdd, true);
            this.btnCopyAdd.Click += new System.EventHandler(this.btnCopyAdd_Click);
            // 
            // btnDel
            // 
            this.buttonStyle1.SetEnableStyle(this.btnDel, true);
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDel.Location = new System.Drawing.Point(318, 501);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 26);
            this.buttonStyle1.SetStyle(this.btnDel, FengSharp.OneCardAccess.Infrastructure.WinForm.Components.ButtonStyleKind.DeleteWithSmallImage);
            this.btnDel.StyleController = this.layoutControl1;
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "删除(&D)";
            this.buttonStyle1.SetUseDefaultText(this.btnDel, true);
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.buttonStyle1.SetEnableStyle(this.btnAdd, true);
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAdd.Location = new System.Drawing.Point(6, 501);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 26);
            this.buttonStyle1.SetStyle(this.btnAdd, FengSharp.OneCardAccess.Infrastructure.WinForm.Components.ButtonStyleKind.AddWithSmallImage);
            this.btnAdd.StyleController = this.layoutControl1;
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "新增(&A)";
            this.buttonStyle1.SetUseDefaultText(this.btnAdd, true);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(6, 6);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1030, 491);
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
            this.colUserNo,
            this.colUserName,
            this.colIsLock,
            this.colRemark,
            this.colCreateName,
            this.colCreateDate,
            this.colLastModifyName,
            this.colLastModifyDate});
            this.gridViewColumnWidthComponent1.SetEnableColumnWidth(this.gridView1, true);
            this.gridView_MouseMulSelect1.SetEnableMouseMulSelect(this.gridView1, true);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView_ShowLine1.SetLineNoFormatString(this.gridView1, "{0}");
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsLayout.Columns.StoreLayout = false;
            this.gridView1.OptionsLayout.StoreDataSettings = false;
            this.gridView1.OptionsLayout.StoreVisualOptions = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView_ShowLine1.SetShowLineNo(this.gridView1, true);
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // colUserNo
            // 
            this.colUserNo.Caption = "用户账号";
            this.colUserNo.FieldName = "UserNo";
            this.colUserNo.Name = "colUserNo";
            this.colUserNo.Visible = true;
            this.colUserNo.VisibleIndex = 0;
            this.colUserNo.Width = 100;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "用户名称";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 1;
            this.colUserName.Width = 100;
            // 
            // colIsLock
            // 
            this.colIsLock.Caption = "是否锁定";
            this.colIsLock.FieldName = "IsLock";
            this.colIsLock.Name = "colIsLock";
            this.colIsLock.Visible = true;
            this.colIsLock.VisibleIndex = 2;
            this.colIsLock.Width = 100;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 3;
            this.colRemark.Width = 100;
            // 
            // colCreateName
            // 
            this.colCreateName.Caption = "创建人姓名";
            this.colCreateName.FieldName = "CreateName";
            this.colCreateName.Name = "colCreateName";
            this.colCreateName.Visible = true;
            this.colCreateName.VisibleIndex = 4;
            this.colCreateName.Width = 100;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "创建日期";
            this.colCreateDate.FieldName = "CreateDate";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 5;
            this.colCreateDate.Width = 100;
            // 
            // colLastModifyName
            // 
            this.colLastModifyName.Caption = "最后更改人姓名";
            this.colLastModifyName.FieldName = "LastModifyName";
            this.colLastModifyName.Name = "colLastModifyName";
            this.colLastModifyName.Visible = true;
            this.colLastModifyName.VisibleIndex = 6;
            this.colLastModifyName.Width = 100;
            // 
            // colLastModifyDate
            // 
            this.colLastModifyDate.Caption = "最后更改日期";
            this.colLastModifyDate.FieldName = "LastModifyDate";
            this.colLastModifyDate.Name = "colLastModifyDate";
            this.colLastModifyDate.Visible = true;
            this.colLastModifyDate.VisibleIndex = 7;
            this.colLastModifyDate.Width = 100;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.Root.Size = new System.Drawing.Size(1042, 533);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1034, 495);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnAdd;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 495);
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
            this.layoutControlItem3.Control = this.btnDel;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(312, 495);
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
            this.layoutControlItem4.Control = this.btnCopyAdd;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(104, 495);
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
            this.layoutControlItem5.Control = this.btnEditView;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(208, 495);
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
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(930, 495);
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
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(416, 495);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(514, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // UserManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 533);
            this.Controls.Add(this.layoutControl1);
            this.formLoadErrorExit1.SetEnableLoadError(this, true);
            this.mainFormMdiProvider1.SetEnableMainFormMdi(this, true);
            this.Name = "UserManageForm";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserManageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnEditView;
        private DevExpress.XtraEditors.SimpleButton btnCopyAdd;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Components.MainFormMdiProvider mainFormMdiProvider1;
        private WinForm.Dev.Components.GridView_MouseMulSelect gridView_MouseMulSelect1;
        private WinForm.Dev.Components.GridView_ShowLine gridView_ShowLine1;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Components.ButtonStyle buttonStyle1;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Components.FormLoadErrorExit formLoadErrorExit1;
        private FengSharp.OneCardAccess.Infrastructure.WinForm.Components.GridViewColumnWidthComponent gridViewColumnWidthComponent1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserNo;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLock;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastModifyName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastModifyDate;
    }
}