using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.Caching_Handling
{
    public class CachingAttributeMatchingRule : IMatchingRule
    {
        public bool Matches(MethodBase member)
        {
            var interfacetypes = member.DeclaringType.GetInterfaces();
            foreach (var interfacetype in interfacetypes)
            {
                var method = interfacetype.GetMethod(member.Name);
                if (method.ToString() == member.ToString())
                {
                    foreach (CachingAttribute attribute in ReflectionHelper.GetAllAttributes<CachingAttribute>(method, true))
                    {
                        if (attribute.CachingEnable)
                            return true;
                    }
                }
            }
            foreach (CachingAttribute attribute in ReflectionHelper.GetAllAttributes<CachingAttribute>(member, true))
            {
                if (attribute.CachingEnable)
                    return true;
            }
            return false;
        }
    }
}
