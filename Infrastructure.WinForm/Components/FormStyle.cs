using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("窗体的样式")]
    [ProvideProperty("EnableStyle", typeof(Form))]
    public partial class FormStyle : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<Form, FormPara> list = null;
        #endregion
        public FormStyle()
        {
            InitializeComponent();
            list = new Dictionary<Form, FormPara>();
        }

        public FormStyle(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<Form, FormPara>();
        }

        public bool CanExtend(object extendee)
        {
            return extendee is Form;
        }
        [Category("扩展")]
        [Description("是否应用按钮样式"), DefaultValue(false)]
        public bool GetEnableStyle(Form form)
        {
            if (this.list.ContainsKey(form))
            {
                return list[form].EnableStyle;
            }
            return true;
        }
        public void SetEnableStyle(Form form, bool enableStyle)
        {
            if (!this.list.ContainsKey(form))
            {
                this.list.Add(form, new FormPara() { EnableStyle = enableStyle });
            }
            else
            {
                this.list[form].EnableStyle = enableStyle;
            }
            if (enableStyle)
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
            }
        }
    }
    internal class FormPara
    {
        private bool enableStyle = false;
        public bool EnableStyle
        {
            get
            {
                return enableStyle;
            }
            set
            {
                enableStyle = value;
            }
        }
    }
}
