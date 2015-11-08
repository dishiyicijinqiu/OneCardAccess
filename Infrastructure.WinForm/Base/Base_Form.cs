using FengSharp.OneCardAccess.Infrastructure.Base;
using System;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Base
{
    public class Base_Form<TFacade> : BaseForm, IFacadeBase<TFacade>
    {
        public TFacade Facade { get; set; }
    }
}
