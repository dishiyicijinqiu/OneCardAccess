using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [ToolboxItem(true)]
    [Description("是否将mdi设置为MainForm。")]
    [ProvideProperty("EnableMainFormMdi", typeof(Form))]
    public class MainFormMdiProvider : Component, IExtenderProvider
    {
        private Dictionary<Form, MainFormMdiProviderPara> FormList = null;
        public MainFormMdiProvider()
        {
            FormList = new Dictionary<Form, MainFormMdiProviderPara>();
        }

        public MainFormMdiProvider(IContainer container)
        {
            container.Add(this);
            FormList = new Dictionary<Form, MainFormMdiProviderPara>();
        }

        [Category("扩展")]
        [Description("是否将mdi设置为MainForm。")]
        public bool GetEnableMainFormMdi(Form form)
        {
            if (FormList.ContainsKey(form))
            {
                return FormList[form].EnableMainFormMdi;
            }
            return true;
        }
        public void SetEnableMainFormMdi(Form form, bool isEnable)
        {
            if (!FormList.ContainsKey(form))
            {
                FormList.Add(form, new MainFormMdiProviderPara() { EnableMainFormMdi = isEnable });
            }
            else
            {
                FormList[form].EnableMainFormMdi = isEnable;
            }
            if (isEnable)
            {
                if (this.DesignMode)
                    return;
                var mdiform = FengSharp.OneCardAccess.Infrastructure.ServiceLoader.LoadService<FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct.Interface.IMainForm>() as Form;
                if (mdiform.InvokeRequired)
                {
                    mdiform.Invoke(new MethodInvoker(() =>
                    {
                        form.MdiParent = mdiform;
                    }));
                }
                else
                    form.MdiParent = mdiform;
            }
        }

        public bool CanExtend(object extendee)
        {
            return (extendee is Form);
        }

    }

    public class MainFormMdiProviderPara
    {
        public bool EnableMainFormMdi { get; set; }
    }
}
