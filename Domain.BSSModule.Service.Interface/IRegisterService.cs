using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using System.ServiceModel;
namespace FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface
{
    [ServiceContract]
    public interface IRegisterService
    {
        [OperationContract]
        RegisterEntity GetRegisterById(string entityid);
        [OperationContract]
        void DeleteRegisters(string[] entityids);
        [OperationContract]
        RegisterCMEntity[] GetRegisterCMList();
        [OperationContract]
        RegisterAttachmentEntity[] GetRegisterAttachmentEntitys(string entityid);
        [OperationContract]
        string CreateRegisterWithAttachment(RegisterEntity entity, RegisterAttachmentEntityNewLogic[] registerAttachmentEntityNewLogic);
        [OperationContract]
        void UpdateRegisterWithAttachment(RegisterEntity entity, RegisterAttachmentEntityNewLogic[] registerAttachmentEntityNewLogic);
    }
}
