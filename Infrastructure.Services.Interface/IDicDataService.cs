
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Infrastructure.Services.Interface
{
    [ServiceContract]
    public interface IDicDataService
    {
        [OperationContract]
        DicDataEntity[] GetDataByDicTypes(string[] dictypes);
    }
}
