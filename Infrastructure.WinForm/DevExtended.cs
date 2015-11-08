using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm
{
    public static class DevExtended
    {
        public static void SetReadOnly(this DevExpress.XtraLayout.LayoutControl layoutcontrol, bool isreadonly, Control[] inadditionCtls = null)
        {
            layoutcontrol.Items.ToList().ForEach((item) =>
            {
                if (item is DevExpress.XtraLayout.LayoutControlItem)
                {
                    var ctl = (item as DevExpress.XtraLayout.LayoutControlItem).Control;
                    if (ctl != null)
                    {
                        if (inadditionCtls == null)
                        {
                            var property = ctl.GetType().GetProperty("ReadOnly");
                            if (property != null)
                            {
                                property.SetValue(ctl, isreadonly, null);
                            }
                        }
                        else
                        {
                            if (!inadditionCtls.Contains(ctl))
                            {
                                var property = ctl.GetType().GetProperty("ReadOnly");
                                if (property != null)
                                {
                                    property.SetValue(ctl, isreadonly, null);
                                }
                            }
                        }
                    }
                }
            });
        }
        public static void RemoveEntityIfDataSourceIsList<T>(this BindingSource bindingSource, List<T> entityToRemove, bool metadataChanged = false)
        {
            var datalist = bindingSource.DataSource as List<T>;
            entityToRemove.ForEach(new Action<T>((t) =>
            {
                if (datalist.Contains(t))
                    datalist.Remove(t);
            }));
            bindingSource.ResetBindings(metadataChanged);
        }
    }
}
