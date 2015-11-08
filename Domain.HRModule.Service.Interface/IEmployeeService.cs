using FengSharp.OneCardAccess.Domain.HRModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.HRModule.Service.Interface
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        EmployeeCMDeptEntity[] GetAllCMDeptEmployee();
        [OperationContract]
        EmployeeEntity FindEmployeeById(string empid);
        [OperationContract]
        void DeleteDeployees(string[] empids);
        [OperationContract]
        EmployeeAttachmentEntity[] GetEmployeeAttachmentEntitys(string empid);
        [OperationContract]
        string CreateEmployeeWithAttachment(EmployeeEntity entity, EmployeeAttachmentEntityNewLogic[] employeeAttachmentEntityNewLogic);
        [OperationContract]
        void UpdateEmployeeWithAttachment(EmployeeEntity entity, EmployeeAttachmentEntityNewLogic[] employeeAttachmentEntityNewLogic);
    }
}
