using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        string CreateUser(UserEntity user);
        [OperationContract]
        void UpdateUser(UserEntity user);
        [OperationContract]
        UserEntity[] GetAllUser();
        [OperationContract]
        void DeleteUsers(string[] UserIds);
        [OperationContract]
        UserEntity FindUserById(string UserId);
        [OperationContract]
        UserWithCreateAndModify[] GetAllUserWithCreateAndModify();
    }
}
