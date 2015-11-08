using FengSharp.OneCardAccess.Infrastructure.Base;

namespace FengSharp.OneCardAccess.Infrastructure.WinForm.Base
{
    public partial class Base_UserControl<TFacade> : BaseUserControl, IFacadeBase<TFacade>
    {
        public TFacade Facade { get; set; }
    }
}
