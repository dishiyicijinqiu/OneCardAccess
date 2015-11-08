using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.HRModule.Service.Interface
{
    [ServiceContract]
    public interface IDeptService
    {
        [OperationContract]
        DeptCMCateEntity[] GetDeptTree(int pid);
        [OperationContract]
        DeptEntity GetDeptById(int DeptId);
        [OperationContract]
        int CreateDept(DeptEntity entity);
        [OperationContract]
        void UpdateDept(DeptEntity entity);
        [OperationContract]
        //[Transaction]
        void DeleteDepts(int[] deptIds);
    }
}
