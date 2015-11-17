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
    [Description("窗体载入错误后退出。")]
    [ProvideProperty("EnableLoadError", typeof(Form))]
    public partial class FormLoadErrorExit : Component, IExtenderProvider
    {
        private Dictionary<Form, FormLoadErrorExitPara> FormList = null;
        public FormLoadErrorExit()
        {
            InitializeComponent();
            FormList = new Dictionary<Form, FormLoadErrorExitPara>();
        }

        public FormLoadErrorExit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            FormList = new Dictionary<Form, FormLoadErrorExitPara>();
        }
        [Category("扩展")]
        [Description("是否设置窗体载入错误后退出。")]
        public bool GetEnableLoadError(Form form)
        {
            if (FormList.ContainsKey(form))
            {
                return FormList[form].EnableLoadError;
            }
            return true;
        }
        public void SetEnableLoadError(Form form, bool isEnable)
        {
            if (!FormList.ContainsKey(form))
            {
                FormList.Add(form, new FormLoadErrorExitPara() { EnableLoadError = isEnable });
            }
            else
            {
                FormList[form].EnableLoadError = isEnable;
            }
            if (isEnable)
            {
                form.Shown -= form_Shown;
                form.Shown += form_Shown;
            }
        }
        public void SetLoadError(Form form, bool isloaderror)
        {
            if (!FormList.ContainsKey(form))
            {
                FormList.Add(form, new FormLoadErrorExitPara() { EnableLoadError = true, IsLoadError = isloaderror });
            }
            else
            {
                FormList[form].IsLoadError = isloaderror;
            }
        }
        public void LoadError()
        {
            foreach (KeyValuePair<Form, FormLoadErrorExitPara> kv in FormList)
            {
                if (kv.Value.EnableLoadError)
                {
                    kv.Value.IsLoadError = true;
                }
            }
        }
        public bool HasLoadError
        {
            set
            {
                foreach (KeyValuePair<Form, FormLoadErrorExitPara> kv in FormList)
                {
                    if (kv.Value.EnableLoadError)
                    {
                        kv.Value.IsLoadError = value;
                    }
                }
            }
        }
        public bool GetLoadError(Form form)
        {
            if (FormList.ContainsKey(form))
            {
                return FormList[form].IsLoadError;
            }
            return false;
        }
        void form_Shown(object sender, EventArgs e)
        {
            var form = sender as Form;
            if (FormList.ContainsKey(form))
            {
                var para = FormList[form];
                if (para.IsLoadError)
                {
                    form.Close();
                }
            }
        }

        public bool CanExtend(object extendee)
        {
            return (extendee is Form);
        }
    }
    public class FormLoadErrorExitPara
    {
        public bool EnableLoadError { get; set; }
        public bool IsLoadError { get; set; }
    }
}
