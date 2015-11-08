using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.Session_Policy
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NoSessionAttribute : Attribute
    {
    }
}
