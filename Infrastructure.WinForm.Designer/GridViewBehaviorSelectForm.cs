using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraGrid.Views.Base;

namespace Infrastructure.WinForm.Designer
{
    public partial class GridViewBehaviorSelectForm : Form
    {
        readonly GridView ysGridView = new GridView();

        readonly GridView cusGridView = (GridView)Activator.CreateInstance(Type.GetType(ResourceMessages.GridViewTypeString));

        public GridView defaultGridView
        {
            get
            {
                if (this.checkBox1.Checked)
                    return ysGridView;
                else
                    return cusGridView;
            }
        }
        private GridView gv;
        public GridViewBehaviorSelectForm(GridView pgv)
        {
            InitializeComponent();
            this.gv = pgv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IDesignerHost host = (IDesignerHost)gv.Site.GetService(typeof(IDesignerHost));
                DesignerTransaction transaction = host.CreateTransaction("GridViewBehaviorSelectDesigner");//创建事务 
                try
                {
                    SetStyle(gv);
                    transaction.Commit();//提交事务 
                }
                catch (Exception ex)
                {
                    transaction.Cancel();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetStyle(this.gridView1);
        }
        private void SetStyle(GridView gridview)
        {
            switch (this.comboBox1.SelectedIndex)
            {
                default:
                    break;
                case 0:
                    SetDefaultStyle(gridview);
                    break;
                case 1:
                    SetStyle1(gridview);
                    break;
                case 2:
                    SetStyle2(gridview);
                    break;
            }
        }
        private void SetDefaultStyle(GridView gridview)
        {
            var _defaultGridView = defaultGridView;
            ClassValueCopier.Copy(gridview.OptionsCustomization, _defaultGridView.OptionsCustomization);
            ClassValueCopier.Copy(gridview.OptionsDetail, _defaultGridView.OptionsDetail);
            ClassValueCopier.Copy(gridview.OptionsEditForm, _defaultGridView.OptionsEditForm);
            ClassValueCopier.Copy(gridview.OptionsFilter, _defaultGridView.OptionsFilter);
            ClassValueCopier.Copy(gridview.OptionsFind, _defaultGridView.OptionsFind);
            ClassValueCopier.Copy(gridview.OptionsHint, _defaultGridView.OptionsHint);
            ClassValueCopier.Copy(gridview.OptionsMenu, _defaultGridView.OptionsMenu);
            ClassValueCopier.Copy(gridview.OptionsSelection, _defaultGridView.OptionsSelection);
            ClassValueCopier.Copy(gridview.OptionsView, _defaultGridView.OptionsView);

            gridview.OptionsDetail.EnableMasterViewMode = _defaultGridView.OptionsDetail.EnableMasterViewMode;
            gridview.OptionsNavigation.EnterMoveNextColumn = _defaultGridView.OptionsNavigation.EnterMoveNextColumn;
            gridview.OptionsSelection.EnableAppearanceFocusedCell = _defaultGridView.OptionsSelection.EnableAppearanceFocusedCell;
            gridview.Appearance.EvenRow.BackColor = _defaultGridView.Appearance.EvenRow.BackColor;
            gridview.Appearance.EvenRow.Options.UseBackColor = _defaultGridView.Appearance.EvenRow.Options.UseBackColor;
            gridview.Appearance.OddRow.BackColor = _defaultGridView.Appearance.OddRow.BackColor;
            gridview.Appearance.OddRow.Options.UseBackColor = _defaultGridView.Appearance.OddRow.Options.UseBackColor;
            gridview.IndicatorWidth = _defaultGridView.IndicatorWidth;

        }
        /// <summary>
        /// 禁用菜单，启用单双行背景色，禁用编辑，不显示分组框
        /// </summary>
        private void SetStyle1(GridView gridview)
        {
            SetDefaultStyle(gridview);
            gridview.Appearance.EvenRow.BackColor = System.Drawing.Color.LightYellow;
            gridview.Appearance.EvenRow.Options.UseBackColor = true;
            gridview.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            gridview.Appearance.OddRow.Options.UseBackColor = true;
            gridview.IndicatorWidth = 40;
            gridview.OptionsBehavior.Editable = false;
            gridview.OptionsCustomization.AllowFilter = false;
            gridview.OptionsCustomization.AllowQuickHideColumns = false;
            gridview.OptionsDetail.EnableMasterViewMode = false;
            gridview.OptionsLayout.Columns.StoreLayout = false;
            gridview.OptionsLayout.StoreDataSettings = false;
            gridview.OptionsLayout.StoreVisualOptions = false;
            gridview.OptionsMenu.EnableColumnMenu = false;
            gridview.OptionsNavigation.EnterMoveNextColumn = true;
            gridview.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridview.OptionsSelection.MultiSelect = true;
            gridview.OptionsView.ColumnAutoWidth = false;
            gridview.OptionsView.EnableAppearanceEvenRow = true;
            gridview.OptionsView.EnableAppearanceOddRow = true;
            gridview.OptionsView.ShowGroupPanel = false;
        }
        private void SetStyle2(GridView gridview)
        {
            SetDefaultStyle(gridview);
            gridview.Appearance.EvenRow.BackColor = System.Drawing.Color.LightYellow;
            gridview.Appearance.EvenRow.Options.UseBackColor = true;
            gridview.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            gridview.Appearance.OddRow.Options.UseBackColor = true;
            gridview.IndicatorWidth = 40;
            gridview.OptionsBehavior.Editable = false;
            gridview.OptionsCustomization.AllowFilter = false;
            gridview.OptionsCustomization.AllowQuickHideColumns = false;
            gridview.OptionsDetail.EnableMasterViewMode = false;
            gridview.OptionsLayout.Columns.StoreLayout = false;
            gridview.OptionsLayout.StoreDataSettings = false;
            gridview.OptionsLayout.StoreVisualOptions = false;
            gridview.OptionsMenu.EnableColumnMenu = true;
            gridview.OptionsNavigation.EnterMoveNextColumn = true;
            gridview.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridview.OptionsSelection.MultiSelect = true;
            gridview.OptionsView.ColumnAutoWidth = false;
            gridview.OptionsView.EnableAppearanceEvenRow = true;
            gridview.OptionsView.EnableAppearanceOddRow = true;
            gridview.OptionsView.ShowGroupPanel = false;
        }

        private void GridViewBehaviorSelectForm_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = GetData();
            this.comboBox1.SelectedIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        }

        private List<UserInfo> GetData()
        {
            var list = new List<UserInfo>();
            for (int i = 0; i < 30; i++)
            {
                list.Add(new UserInfo()
                {
                    Address = string.Format("河南驻马店{0}", Guid.NewGuid().ToString()),
                    Age = 10 + i,
                    UserName = string.Format("张三{0}", i)
                });
            }
            return list;
        }

        public class UserInfo
        {
            public string UserName { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }
    }

    /// <summary>
    /// 类属性/字段的值复制工具
    /// </summary>
    internal class ClassValueCopier
    {
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="destination">目标</param>
        /// <param name="source">来源</param>
        /// <returns>成功复制的值个数</returns>
        public static int Copy(object destination, object source)
        {
            if (destination == null || source == null)
            {
                return 0;
            }
            return Copy(destination, source, source.GetType());
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="destination">目标</param>
        /// <param name="source">来源</param>
        /// <param name="type">复制的属性字段模板</param>
        /// <returns>成功复制的值个数</returns>
        public static int Copy(object destination, object source, Type type)
        {
            return Copy(destination, source, type, null);
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="destination">目标</param>
        /// <param name="source">来源</param>
        /// <param name="type">复制的属性字段模板</param>
        /// <param name="excludeName">排除下列名称的属性不要复制</param>
        /// <returns>成功复制的值个数</returns>
        public static int Copy(object destination, object source, Type type, IEnumerable<string> excludeName)
        {
            if (destination == null || source == null)
            {
                return 0;
            }
            if (excludeName == null)
            {
                excludeName = new List<string>();
            }
            int i = 0;
            Type desType = destination.GetType();
            foreach (FieldInfo mi in type.GetFields())
            {
                if (excludeName.Contains(mi.Name))
                {
                    continue;
                }
                try
                {
                    FieldInfo des = desType.GetField(mi.Name);
                    if (des != null && des.FieldType == mi.FieldType)
                    {
                        des.SetValue(destination, mi.GetValue(source));
                        i++;
                    }

                }
                catch
                {
                }
            }

            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (excludeName.Contains(pi.Name))
                {
                    continue;
                }
                try
                {
                    PropertyInfo des = desType.GetProperty(pi.Name);
                    if (des != null && des.PropertyType == pi.PropertyType && des.CanWrite && pi.CanRead)
                    {
                        des.SetValue(destination, pi.GetValue(source, null), null);
                        i++;
                    }

                }
                catch
                {
                    //throw ex;
                }
            }
            return i;
        }
    }

    #region 扩展方法 For .NET 3.0+
    /// <summary>
    /// 类属性/字段的值复制工具 扩展方法
    /// </summary>
    internal static class ClassValueCopier2
    {
        /// <summary>
        /// 获取实体类的属性名称
        /// </summary>
        /// <param name="source">实体类</param>
        /// <returns>属性名称列表</returns>
        public static List<string> GetPropertyNames(this object source)
        {
            if (source == null)
            {
                return new List<string>();
            }
            return GetPropertyNames(source.GetType());
        }
        /// <summary>
        /// 获取类类型的属性名称（按声明顺序）
        /// </summary>
        /// <param name="source">类类型</param>
        /// <returns>属性名称列表</returns>
        public static List<string> GetPropertyNames(this Type source)
        {
            return GetPropertyNames(source, true);
        }
        /// <summary>
        /// 获取类类型的属性名称
        /// </summary>
        /// <param name="source">类类型</param>
        /// <param name="declarationOrder">是否按声明顺序排序</param>
        /// <returns>属性名称列表</returns>
        public static List<string> GetPropertyNames(this Type source, bool declarationOrder)
        {
            if (source == null)
            {
                return new List<string>();
            }
            var list = source.GetProperties().AsQueryable();
            if (declarationOrder)
            {
                list = list.OrderBy(p => p.MetadataToken);
            }
            return list.Select(o => o.Name).ToList(); ;
        }

        /// <summary>
        /// 从源对象赋值到当前对象
        /// </summary>
        /// <param name="destination">当前对象</param>
        /// <param name="source">源对象</param>
        /// <returns>成功复制的值个数</returns>
        public static int CopyValueFrom(this object destination, object source)
        {
            return CopyValueFrom(destination, source, null);
        }

        /// <summary>
        /// 从源对象赋值到当前对象
        /// </summary>
        /// <param name="destination">当前对象</param>
        /// <param name="source">源对象</param>
        /// <param name="excludeName">排除下列名称的属性不要复制</param>
        /// <returns>成功复制的值个数</returns>
        public static int CopyValueFrom(this object destination, object source, IEnumerable<string> excludeName)
        {
            if (destination == null || source == null)
            {
                return 0;
            }
            return ClassValueCopier.Copy(destination, source, source.GetType(), excludeName);
        }

        /// <summary>
        /// 从当前对象赋值到目标对象
        /// </summary>
        /// <param name="source">当前对象</param>
        /// <param name="destination">目标对象</param>
        /// <returns>成功复制的值个数</returns>
        public static int CopyValueTo(this object source, object destination)
        {
            return CopyValueTo(destination, source, null);
        }

        /// <summary>
        /// 从当前对象赋值到目标对象
        /// </summary>
        /// <param name="source">当前对象</param>
        /// <param name="destination">目标对象</param>
        /// <param name="excludeName">排除下列名称的属性不要复制</param>
        /// <returns>成功复制的值个数</returns>
        public static int CopyValueTo(this object source, object destination, IEnumerable<string> excludeName)
        {
            if (destination == null || source == null)
            {
                return 0;
            }
            return ClassValueCopier.Copy(destination, source, source.GetType(), excludeName);
        }

    }
    #endregion
}
