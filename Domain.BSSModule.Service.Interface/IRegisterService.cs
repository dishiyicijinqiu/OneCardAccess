using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IRegisterService
    {
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        RegisterEntity GetRegisterById(string entityid);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void DeleteRegisters(string[] entityids);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        RegisterCMEntity[] GetRegisterCMList();
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        RegisterAttachmentEntity[] GetRegisterAttachmentEntitys(string entityid);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        string CreateRegisterWithAttachment(RegisterEntity entity, RegisterAttachmentEntityNewLogic[] registerAttachmentEntityNewLogic);
        [OperationContract]
        [FaultContract(typeof(FengSharp.OneCardAccess.Infrastructure.ServiceExceptionDetail))]
        void UpdateRegisterWithAttachment(RegisterEntity entity, RegisterAttachmentEntityNewLogic[] registerAttachmentEntityNewLogic);
    }
}
