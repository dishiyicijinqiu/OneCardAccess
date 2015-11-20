using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.MainStruct.Interface
{
    public interface IMainForm
    {
        void ReLoad();
        T[] FindForms<T>() where T : class;
    }
}
