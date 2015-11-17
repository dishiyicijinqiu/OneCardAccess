using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.HRModule.Service.Interface
{
    [ServiceContract]
    public interface IDeptService
    {
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        DeptCMCateEntity[] GetDeptTree(int pid);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        DeptEntity GetDeptById(int DeptId);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        int CreateDept(DeptEntity entity);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void UpdateDept(DeptEntity entity);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void DeleteDepts(int[] deptIds);
    }
}
