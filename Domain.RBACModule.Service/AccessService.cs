using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class AccessService : ServiceBase, IAccessService
    {
        public UserEntity FindUserByTicket(string ticketstring)
        {
            if (ApplicationContext.Current == null)
                return null;
            return ServiceLoader.LoadService<IUserService>().FindUserById(ApplicationContext.Current.Ticket);
        }
        public void ChangePassword(string ticket, string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveUsersFromRole(string[] userids, string RoleId)
        {
            if (userids == null) throw new BusinessException("用户不可为空");
            base.UseTran((tran) =>
           {
               userids.ToList().ForEach((userid) =>
               {
                   DbCommand cmd = base.Database.GetStoredProcCommand("P_RoleUserFlow");
                   base.Database.AddInParameter(cmd, "OP", DbType.String, "removeuserfromrole");
                   base.Database.AddInParameter(cmd, "UserId", DbType.String, userid);
                   base.Database.AddInParameter(cmd, "RoleId", DbType.String, RoleId);
                   base.Database.AddInParameter(cmd, "Lock", DbType.Boolean, false);
                   base.Database.ExecuteNonQuery(cmd, tran);
               });
           });
        }
        public void AddUsersToRole(string[] userids, string RoleId)
        {
            if (userids == null) throw new BusinessException("用户不可为空");
            base.UseTran((tran) =>
            {
                userids.ToList().ForEach((userid) =>
                {
                    DbCommand cmd = base.Database.GetStoredProcCommand("P_RoleUserFlow");
                    base.Database.AddInParameter(cmd, "OP", DbType.String, "addusertorole");
                    base.Database.AddInParameter(cmd, "UserId", DbType.String, userid);
                    base.Database.AddInParameter(cmd, "RoleId", DbType.String, RoleId);
                    base.Database.AddInParameter(cmd, "Lock", DbType.Boolean, false);
                    base.Database.ExecuteNonQuery(cmd, tran);
                });
            });
        }
        public void LockRole(string roleid)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_RoleUserFlow");
                base.Database.AddInParameter(cmd, "OP", DbType.String, "lockrole");
                base.Database.AddInParameter(cmd, "UserId", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
                base.Database.AddInParameter(cmd, "Lock", DbType.Boolean, true);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }
        public void UnLockRole(string roleid)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_RoleUserFlow");
                base.Database.AddInParameter(cmd, "OP", DbType.String, "lockrole");
                base.Database.AddInParameter(cmd, "UserId", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
                base.Database.AddInParameter(cmd, "Lock", DbType.Boolean, false);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }
        public void UnLockUser(string userid)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_RoleUserFlow");
                base.Database.AddInParameter(cmd, "OP", DbType.String, "lockuser");
                base.Database.AddInParameter(cmd, "UserId", DbType.String, userid);
                base.Database.AddInParameter(cmd, "RoleId", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "Lock", DbType.Boolean, false);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }
        public void LockUser(string userid)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_RoleUserFlow");
                base.Database.AddInParameter(cmd, "OP", DbType.String, "lockuser");
                base.Database.AddInParameter(cmd, "UserId", DbType.String, userid);
                base.Database.AddInParameter(cmd, "RoleId", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "Lock", DbType.Boolean, true);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }

        public void SaveRoleMenus(string roleid, string[] menunos)
        {
            base.UseTran((tran) =>
            {
                base.DeleteRelationData("rolemenu", roleid, tran);
                menunos.ToList().ForEach((MenuNo) =>
                {
                    DbCommand cmd = base.Database.GetStoredProcCommand("P_AddRoleMenu");
                    base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
                    base.Database.AddInParameter(cmd, "MenuNo", DbType.String, MenuNo);
                    base.Database.ExecuteNonQuery(cmd, tran);
                });
            });
        }
        public void SaveRoleActions(string roleid, string[] actionnos)
        {
            base.UseTran((tran) =>
            {
                base.DeleteRelationData("roleaction", roleid, tran);
                actionnos.ToList().ForEach((ActionNo) =>
                {
                    DbCommand cmd = base.Database.GetStoredProcCommand("P_AddRoleAction");
                    base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
                    base.Database.AddInParameter(cmd, "ActionNo", DbType.String, ActionNo);
                    base.Database.ExecuteNonQuery(cmd, tran);
                });
            });
        }
        public bool IsSuper(string ticket)
        {
            var entity = this.FindUserByTicket(ticket);
            if (entity == null)
                return false;
            bool result = false;
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_IsSuper");
                base.Database.AddInParameter(cmd, "UserId", DbType.String, entity.UserId);
                base.Database.AddOutParameter(cmd, "IsSuper", DbType.Boolean, 1);
                base.Database.ExecuteNonQuery(cmd, tran);
                result = (bool)base.Database.GetParameterValue(cmd, "IsSuper");
            });
            return result;
        }

        #region StockInfoRight
        public StockInfoRightTempStatusEntity[] GetStockBaseRight(string roleid, string newflag, string oldflag)
        {
            DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
            base.Database.AddInParameter(cmd, "OP", DbType.String, "getright");
            base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolestock");
            base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
            base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, 0);
            base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
            base.Database.AddInParameter(cmd, "Flag", DbType.String, oldflag);
            base.Database.AddInParameter(cmd, "NewFlag", DbType.String, newflag);
            base.Database.AddInParameter(cmd, "Check", DbType.Boolean, false);
            DataTable dt = null;
            base.UseTran((tran) =>
            {
                dt = Database.ExecuteDataTable(cmd, tran);
            });
            if (dt == null)
                return null;
            return StockRightTempService.DataTableToInfoEntitys(dt);
        }
        public void SaveStockRightTempData(string roleid, int[] entityids, string flag, bool check)
        {
            base.UseTran((tran) =>
            {
                entityids.ToList().ForEach((entityid) =>
                {
                    DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                    base.Database.AddInParameter(cmd, "OP", DbType.String, "savetempright");
                    base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolestock");
                    base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
                    base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, entityid);
                    base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                    base.Database.AddInParameter(cmd, "Flag", DbType.String, flag);
                    base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                    base.Database.AddInParameter(cmd, "Check", DbType.Boolean, check);
                    base.Database.ExecuteNonQuery(cmd, tran);
                });
            });
        }
        public void SaveStockRightData(System.Collections.Generic.List<StockInfoRightTempStatusEntity> datas)
        {
            base.UseTran((tran) =>
            {
                datas.ForEach((entity) =>
                {
                    DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                    base.Database.AddInParameter(cmd, "OP", DbType.String, "saveright");
                    base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolestock");
                    base.Database.AddInParameter(cmd, "RoleId", DbType.String, entity.RoleId);
                    base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, entity.StockId);
                    base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                    base.Database.AddInParameter(cmd, "Flag", DbType.String, entity.Flag);
                    base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                    base.Database.AddInParameter(cmd, "Check", DbType.Boolean, entity.Status);
                    base.Database.ExecuteNonQuery(cmd, tran);
                });
            });
        }
        public void DelStockRightTempData(string flag)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                base.Database.AddInParameter(cmd, "OP", DbType.String, "deltempright");
                base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolestock");
                base.Database.AddInParameter(cmd, "RoleId", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, 0);
                base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                base.Database.AddInParameter(cmd, "Flag", DbType.String, flag);
                base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "Check", DbType.Boolean, false);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }
        #endregion
        #region ProductInfoRight
        public ProductInfoRightStatusTempEntity[] GetNewProductBaseRight(string roleid, string newflag, string oldflag)
        {
            return GetProductBaseRight(roleid, newflag, oldflag, 0);
        }
        public ProductInfoRightStatusTempEntity[] GetProductBaseRight(string roleid, string flag, int pid)
        {
            return GetProductBaseRight(roleid, string.Empty, flag, pid);
        }
        private ProductInfoRightStatusTempEntity[] GetProductBaseRight(string roleid, string newflag, string oldflag, int pid)
        {
            DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
            base.Database.AddInParameter(cmd, "OP", DbType.String, "getright");
            base.Database.AddInParameter(cmd, "cMode", DbType.String, "roleproduct");
            base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
            base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, 0);
            base.Database.AddInParameter(cmd, "PId", DbType.Int32, pid);
            base.Database.AddInParameter(cmd, "Flag", DbType.String, oldflag);
            base.Database.AddInParameter(cmd, "NewFlag", DbType.String, newflag);
            base.Database.AddInParameter(cmd, "Check", DbType.Boolean, false);
            DataTable dt = null;
            base.UseTran((tran) =>
            {
                dt = Database.ExecuteDataTable(cmd, tran);
            });
            if (dt == null)
                return null;
            return ProductRightTempService.DataTableToInfoEntitys(dt);
        }
        public void SaveProductRightTempData(string roleid, int[] entityids, string flag, bool check)
        {
            base.UseTran((tran) =>
            {
                entityids.ToList().ForEach((entityid) =>
                {
                    DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                    base.Database.AddInParameter(cmd, "OP", DbType.String, "savetempright");
                    base.Database.AddInParameter(cmd, "cMode", DbType.String, "roleproduct");
                    base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
                    base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, entityid);
                    base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                    base.Database.AddInParameter(cmd, "Flag", DbType.String, flag);
                    base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                    base.Database.AddInParameter(cmd, "Check", DbType.Boolean, check);
                    base.Database.ExecuteNonQuery(cmd, tran);
                });
            });
        }
        public void SaveProductRightData(System.Collections.Generic.List<ProductInfoRightStatusTempEntity> datas)
        {
            base.UseTran((tran) =>
            {
                datas.ForEach((entity) =>
                {
                    DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                    base.Database.AddInParameter(cmd, "OP", DbType.String, "saveright");
                    base.Database.AddInParameter(cmd, "cMode", DbType.String, "roleproduct");
                    base.Database.AddInParameter(cmd, "RoleId", DbType.String, entity.RoleId);
                    base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, entity.ProductId);
                    base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                    base.Database.AddInParameter(cmd, "Flag", DbType.String, entity.Flag);
                    base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                    base.Database.AddInParameter(cmd, "Check", DbType.Boolean, entity.Status);
                    base.Database.ExecuteNonQuery(cmd, tran);
                });
            });
        }
        public void DelProductRightTempData(string flag)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                base.Database.AddInParameter(cmd, "OP", DbType.String, "deltempright");
                base.Database.AddInParameter(cmd, "cMode", DbType.String, "roleproduct");
                base.Database.AddInParameter(cmd, "RoleId", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, 0);
                base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                base.Database.AddInParameter(cmd, "Flag", DbType.String, flag);
                base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "Check", DbType.Boolean, false);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }
        #endregion
        #region CompanyInfoRight
        public CompanyInfoRightStatusTempEntity[] GetNewCompanyBaseRight(string roleid, string newflag, string oldflag)
        {
            return GetCompanyBaseRight(roleid, newflag, oldflag, 0);
        }
        public CompanyInfoRightStatusTempEntity[] GetCompanyBaseRight(string roleid, string flag, int pid)
        {
            return GetCompanyBaseRight(roleid, string.Empty, flag, pid);
        }
        private CompanyInfoRightStatusTempEntity[] GetCompanyBaseRight(string roleid, string newflag, string oldflag, int pid)
        {
            DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
            base.Database.AddInParameter(cmd, "OP", DbType.String, "getright");
            base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolecompany");
            base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
            base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, 0);
            base.Database.AddInParameter(cmd, "PId", DbType.Int32, pid);
            base.Database.AddInParameter(cmd, "Flag", DbType.String, oldflag);
            base.Database.AddInParameter(cmd, "NewFlag", DbType.String, newflag);
            base.Database.AddInParameter(cmd, "Check", DbType.Boolean, false);
            DataTable dt = null;
            base.UseTran((tran) =>
            {
                dt = Database.ExecuteDataTable(cmd, tran);
            });
            if (dt == null)
                return null;
            return CompanyRightTempService.DataTableToInfoEntitys(dt);
        }
        public void SaveCompanyRightTempData(string roleid, int[] entityids, string flag, bool check)
        {
            base.UseTran((tran) =>
            {
                entityids.ToList().ForEach((entityid) =>
                {
                    DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                    base.Database.AddInParameter(cmd, "OP", DbType.String, "savetempright");
                    base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolecompany");
                    base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
                    base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, entityid);
                    base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                    base.Database.AddInParameter(cmd, "Flag", DbType.String, flag);
                    base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                    base.Database.AddInParameter(cmd, "Check", DbType.Boolean, check);
                    base.Database.ExecuteNonQuery(cmd, tran);
                });
            });
        }
        public void SaveCompanyRightData(System.Collections.Generic.List<CompanyInfoRightStatusTempEntity> entityids)
        {
            base.UseTran((tran) =>
            {
                entityids.ForEach((entity) =>
                {
                    DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                    base.Database.AddInParameter(cmd, "OP", DbType.String, "saveright");
                    base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolecompany");
                    base.Database.AddInParameter(cmd, "RoleId", DbType.String, entity.RoleId);
                    base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, entity.CompanyId);
                    base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                    base.Database.AddInParameter(cmd, "Flag", DbType.String, entity.Flag);
                    base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                    base.Database.AddInParameter(cmd, "Check", DbType.Boolean, entity.Status);
                    base.Database.ExecuteNonQuery(cmd, tran);
                });
            });
        }
        public void DelCompanyRightTempData(string flag)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                base.Database.AddInParameter(cmd, "OP", DbType.String, "deltempright");
                base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolecompany");
                base.Database.AddInParameter(cmd, "RoleId", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, 0);
                base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                base.Database.AddInParameter(cmd, "Flag", DbType.String, flag);
                base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "Check", DbType.Boolean, false);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }
        #endregion
        #region RawMateInfoRight
        public RawMateInfoRightStatusTempEntity[] GetNewRawMateBaseRight(string roleid, string newflag, string oldflag)
        {
            return GetRawMateBaseRight(roleid, newflag, oldflag, 0);
        }
        public RawMateInfoRightStatusTempEntity[] GetRawMateBaseRight(string roleid, string flag, int pid)
        {
            return GetRawMateBaseRight(roleid, string.Empty, flag, pid);
        }
        private RawMateInfoRightStatusTempEntity[] GetRawMateBaseRight(string roleid, string newflag, string oldflag, int pid)
        {
            DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
            base.Database.AddInParameter(cmd, "OP", DbType.String, "getright");
            base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolerawmate");
            base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
            base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, 0);
            base.Database.AddInParameter(cmd, "PId", DbType.Int32, pid);
            base.Database.AddInParameter(cmd, "Flag", DbType.String, oldflag);
            base.Database.AddInParameter(cmd, "NewFlag", DbType.String, newflag);
            base.Database.AddInParameter(cmd, "Check", DbType.Boolean, false);
            DataTable dt = null;
            base.UseTran((tran) =>
            {
                dt = Database.ExecuteDataTable(cmd, tran);
            });
            if (dt == null)
                return null;
            return RawMateRightTempService.DataTableToInfoEntitys(dt);
        }
        public void SaveRawMateRightTempData(string roleid, int[] entityids, string flag, bool check)
        {
            base.UseTran((tran) =>
            {
                entityids.ToList().ForEach((entityid) =>
                {
                    DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                    base.Database.AddInParameter(cmd, "OP", DbType.String, "savetempright");
                    base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolerawmate");
                    base.Database.AddInParameter(cmd, "RoleId", DbType.String, roleid);
                    base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, entityid);
                    base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                    base.Database.AddInParameter(cmd, "Flag", DbType.String, flag);
                    base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                    base.Database.AddInParameter(cmd, "Check", DbType.Boolean, check);
                    base.Database.ExecuteNonQuery(cmd, tran);
                });
            });
        }
        public void SaveRawMateRightData(System.Collections.Generic.List<RawMateInfoRightStatusTempEntity> datas)
        {
            base.UseTran((tran) =>
            {
                datas.ForEach((entity) =>
                {
                    DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                    base.Database.AddInParameter(cmd, "OP", DbType.String, "saveright");
                    base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolerawmate");
                    base.Database.AddInParameter(cmd, "RoleId", DbType.String, entity.RoleId);
                    base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, entity.RawMateId);
                    base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                    base.Database.AddInParameter(cmd, "Flag", DbType.String, entity.Flag);
                    base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                    base.Database.AddInParameter(cmd, "Check", DbType.Boolean, entity.Status);
                    base.Database.ExecuteNonQuery(cmd, tran);
                });
            });
        }
        public void DelRawMateRightTempData(string flag)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_BaseRightFlow");
                base.Database.AddInParameter(cmd, "OP", DbType.String, "deltempright");
                base.Database.AddInParameter(cmd, "cMode", DbType.String, "rolerawmate");
                base.Database.AddInParameter(cmd, "RoleId", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "EntityId", DbType.Int32, 0);
                base.Database.AddInParameter(cmd, "PId", DbType.Int32, 0);
                base.Database.AddInParameter(cmd, "Flag", DbType.String, flag);
                base.Database.AddInParameter(cmd, "NewFlag", DbType.String, string.Empty);
                base.Database.AddInParameter(cmd, "Check", DbType.Boolean, false);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }
        #endregion
    }
}
