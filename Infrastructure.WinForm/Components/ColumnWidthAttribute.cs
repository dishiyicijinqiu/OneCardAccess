using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Components
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ColumnWidthAttribute : Attribute
    {
        public ColumnWidthAttribute()
        {

        }
        public int Width { get; set; }
        public bool ForceColumnWidth { get; set; }
    }
}
