using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IDlyNdxService
    {
        [OperationContract]
        string GetNewDlyNo(int DlyTypeId);
        [OperationContract]
        string GetDlyDate();
        [OperationContract]
        string SaveSPRKBak(SPRKDlyCGNdxEntity entity);
        [OperationContract]
        DlyNdxFullNameEntity[] GetCGList();
    }
}
