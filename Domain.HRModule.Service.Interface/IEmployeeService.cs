using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.HRModule.Service.Interface
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        EmployeeCMDeptEntity[] GetAllCMDeptEmployee();
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        EmployeeEntity FindEmployeeById(string empid);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void DeleteDeployees(string[] empids);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        EmployeeAttachmentEntity[] GetEmployeeAttachmentEntitys(string empid);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        string CreateEmployeeWithAttachment(EmployeeEntity entity, EmployeeAttachmentEntityNewLogic[] employeeAttachmentEntityNewLogic);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void UpdateEmployeeWithAttachment(EmployeeEntity entity, EmployeeAttachmentEntityNewLogic[] employeeAttachmentEntityNewLogic);
    }
}
