using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IDlyTypeService
    {
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        DlyTypeCateEntity[] GetDlyTypeTree(int pid);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        DlyTypeEntity GetDlyTypeById(int dlytypeid);
    }
}
