using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface
{
    [ServiceContract]
    public interface IAccessService
    {
        [OperationContract]
        UserEntity FindUserByTicket(string ticket);
        [OperationContract]
        void ChangePassword(string ticket, string oldPassword, string newPassword);
        [OperationContract]
        void RemoveUsersFromRole(string[] userids, string RoleId);
        [OperationContract]
        void AddUsersToRole(string[] userids, string RoleId);
        [OperationContract]
        void LockRole(string roleid);
        [OperationContract]
        void UnLockRole(string roleid);
        [OperationContract]
        void UnLockUser(string userid);
        [OperationContract]
        void LockUser(string userid);
        [OperationContract]
        void SaveRoleMenus(string roleid, string[] menunos);
        [OperationContract]
        void SaveRoleActions(string roleid, string[] actionno);
        [OperationContract]
        bool IsSuper(string ticket);
        #region Stock
        [OperationContract]
        StockInfoRightTempStatusEntity[] GetStockBaseRight(string roleid, string newflag, string oldflag);
        [OperationContract]
        void DelStockRightTempData(string flag);
        [OperationContract]
        void SaveStockRightData(System.Collections.Generic.List<StockInfoRightTempStatusEntity> datas);
        [OperationContract]
        void SaveStockRightTempData(string roleid, int[] entityids, string flag, bool check);
        #endregion
        #region Product
        [OperationContract]
        ProductInfoRightStatusTempEntity[] GetNewProductBaseRight(string roleid, string newflag, string oldflag);
        [OperationContract]
        ProductInfoRightStatusTempEntity[] GetProductBaseRight(string roleid, string flag, int pid);
        [OperationContract]
        void SaveProductRightData(System.Collections.Generic.List<ProductInfoRightStatusTempEntity> datas);
        [OperationContract]
        void DelProductRightTempData(string flag);
        [OperationContract]
        void SaveProductRightTempData(string roleid, int[] entityids, string flag, bool check);
        #endregion
        #region Company
        [OperationContract]
        CompanyInfoRightStatusTempEntity[] GetNewCompanyBaseRight(string roleid, string newflag, string oldflag);
        [OperationContract]
        CompanyInfoRightStatusTempEntity[] GetCompanyBaseRight(string roleid, string flag, int pid);
        [OperationContract]
        void SaveCompanyRightData(System.Collections.Generic.List<CompanyInfoRightStatusTempEntity> datas);
        [OperationContract]
        void DelCompanyRightTempData(string flag);
        [OperationContract]
        void SaveCompanyRightTempData(string roleid, int[] entityids, string flag, bool check);
        #endregion
        #region RawMate
        [OperationContract]
        RawMateInfoRightStatusTempEntity[] GetNewRawMateBaseRight(string roleid, string newflag, string oldflag);
        [OperationContract]
        RawMateInfoRightStatusTempEntity[] GetRawMateBaseRight(string roleid, string flag, int pid);
        [OperationContract]
        void SaveRawMateRightData(System.Collections.Generic.List<RawMateInfoRightStatusTempEntity> datas);
        [OperationContract]
        void DelRawMateRightTempData(string flag);
        [OperationContract]
        void SaveRawMateRightTempData(string roleid, int[] entityids, string flag, bool check);
        #endregion
    }
}
