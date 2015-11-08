using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IDlyTypeService
    {
        [OperationContract]
        DlyTypeCateEntity[] GetDlyTypeTree(int pid);
        [OperationContract]
        DlyTypeEntity GetDlyTypeById(int dlytypeid);
    }
}
