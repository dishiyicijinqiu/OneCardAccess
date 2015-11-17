using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Infrastructure;
using System.ServiceModel;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface
{
    [ServiceContract]
    public interface IAccessService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void ChangePassword(string oldPassword, string newPassword);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void RemoveUsersFromRole(string[] userids, string RoleId);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void AddUsersToRole(string[] userids, string RoleId);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void LockRole(string roleid);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void UnLockRole(string roleid);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void UnLockUser(string userid);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void LockUser(string userid);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void SaveRoleMenus(string roleid, string[] menunos);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void SaveRoleActions(string roleid, string[] actionno);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool IsSuper();
        #region Stock
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        StockInfoRightTempStatusEntity[] GetStockBaseRight(string roleid, string newflag, string oldflag);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void DelStockRightTempData(string flag);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void SaveStockRightData(System.Collections.Generic.List<StockInfoRightTempStatusEntity> datas);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void SaveStockRightTempData(string roleid, int[] entityids, string flag, bool check);
        #endregion
        #region Product
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        ProductInfoRightStatusTempEntity[] GetNewProductBaseRight(string roleid, string newflag, string oldflag);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        ProductInfoRightStatusTempEntity[] GetProductBaseRight(string roleid, string flag, int pid);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void SaveProductRightData(System.Collections.Generic.List<ProductInfoRightStatusTempEntity> datas);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void DelProductRightTempData(string flag);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void SaveProductRightTempData(string roleid, int[] entityids, string flag, bool check);
        #endregion
        #region Company
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        CompanyInfoRightStatusTempEntity[] GetNewCompanyBaseRight(string roleid, string newflag, string oldflag);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        CompanyInfoRightStatusTempEntity[] GetCompanyBaseRight(string roleid, string flag, int pid);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void SaveCompanyRightData(System.Collections.Generic.List<CompanyInfoRightStatusTempEntity> datas);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void DelCompanyRightTempData(string flag);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void SaveCompanyRightTempData(string roleid, int[] entityids, string flag, bool check);
        #endregion
        #region RawMate
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        RawMateInfoRightStatusTempEntity[] GetNewRawMateBaseRight(string roleid, string newflag, string oldflag);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        RawMateInfoRightStatusTempEntity[] GetRawMateBaseRight(string roleid, string flag, int pid);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void SaveRawMateRightData(System.Collections.Generic.List<RawMateInfoRightStatusTempEntity> datas);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void DelRawMateRightTempData(string flag);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void SaveRawMateRightTempData(string roleid, int[] entityids, string flag, bool check);
        #endregion
    }
}
