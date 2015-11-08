using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Resources
{
    public class ResourceHelper
    {
        public static object GetResource(string resourcename)
        {
            var type = typeof(FengSharp.OneCardAccess.Infrastructure.WinForm.ResourceMessages);
            var property = type.GetProperty(resourcename, BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase);
            if (property == null)
                return null;
            return property.GetValue(null, null);
        }
        public static T GetResource<T>(string resourcename)
        {
            var result = GetResource(resourcename);
            //if (result == null)
            //    return default(T);
            return (T)result;
        }
    }
}
