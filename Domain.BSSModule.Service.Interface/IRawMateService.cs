using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IRawMateService
    {
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        RawMateCMCateEntity[] GetRawMateTree(int pid);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        RawMateEntity GetRawMateById(int entityid);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        int CreateRawMate(RawMateEntity entity);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void UpdateRawMate(RawMateEntity entity);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void DeleteRawMates(int[] entityids);
    }
}
