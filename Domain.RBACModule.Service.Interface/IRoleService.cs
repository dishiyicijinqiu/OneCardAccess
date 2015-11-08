using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface
{
    [ServiceContract]
    public interface IRoleService
    {
        [OperationContract]
        RoleEntity FindRoleById(string RoleId);
        [OperationContract]
        string CreateRole(RoleEntity role);
        [OperationContract]
        void DeleteRole(string roleid);
        [OperationContract]
        void UpdateRole(RoleEntity role);
        [OperationContract]
        RoleEntity[] GetAllRole();
        [OperationContract]
        UserEntity[] GetRoleUsers(string RoleId);
    }
}
