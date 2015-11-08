using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface
{
    [ServiceContract]
    public interface IActionService
    {
        [OperationContract]
        ActionEntity[] GetAllEntity();
        [OperationContract]
        void CreateEntity(ActionEntity entity);
        [OperationContract]
        void UpdateEntity(string actionno, ActionEntity entity);
        [OperationContract]
        ActionEntity FindEntityByNo(string actionno);
        [OperationContract]
        RoleActionEntity[] GetRoleActions(string roleid);
        [OperationContract]
        void DeleteEntity(string actionno);
        [OperationContract]
        string GetNewChildNo(string parentactionno);
    }
}
