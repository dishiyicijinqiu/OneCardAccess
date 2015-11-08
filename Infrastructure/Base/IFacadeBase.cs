
namespace FengSharp.OneCardAccess.Infrastructure.Base
{
    public interface IFacadeBase<TFacade>
    {
        TFacade Facade { get; }
    }
}
