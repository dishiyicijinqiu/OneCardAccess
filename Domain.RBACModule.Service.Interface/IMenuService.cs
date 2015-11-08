using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface
{
    [ServiceContract]
    public interface IMenuService
    {
        [OperationContract]
        MenuEntity[] GetAllEntity();
        [OperationContract]
        void CreateEntity(MenuEntity entity);
        [OperationContract]
        void UpdateEntity(string menuno, MenuEntity entity);
        [OperationContract]
        MenuEntity FindEntityByNo(string menuno);
        [OperationContract]
        RoleMenuEntity[] GetRoleMenus(string roleid);
        [OperationContract]
        string GetNewChildNo(string PNo);
        [OperationContract]
        void DeleteEntity(string MenuNo);
        [OperationContract]
        string[] GetUserMenuNos(string userid);
    }
}
