using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System.Data;
using System.Data.Common;
using System.Linq;
namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class ActionService : ServiceBase, IActionService
    {
        const string modestring = "action";
        public ActionEntity[] GetAllEntity()
        {
            return ActionService.DataTableToBindEntitys(this.GetList(modestring));
        }

        public void CreateEntity(ActionEntity entity)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_CreateAction");
                base.Database.AddInParameter(cmd, "ActionName", DbType.String, entity.ActionName);
                base.Database.AddInParameter(cmd, "ActionNo", DbType.String, entity.ActionNo);
                base.Database.AddInParameter(cmd, "ActionType", DbType.String, entity.ActionType);
                base.Database.AddInParameter(cmd, "ParentActionNo", DbType.String, entity.ParentActionNo);
                base.Database.AddInParameter(cmd, "Order", DbType.Int32, entity.Order);
                base.Database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }

        public void UpdateEntity(string actionno, ActionEntity entity)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_UpdateAction");
                base.Database.AddInParameter(cmd, "OldActionNo", DbType.String, actionno);
                base.Database.AddInParameter(cmd, "ActionName", DbType.String, entity.ActionName);
                base.Database.AddInParameter(cmd, "ActionNo", DbType.String, entity.ActionNo);
                base.Database.AddInParameter(cmd, "ActionType", DbType.String, entity.ActionType);
                base.Database.AddInParameter(cmd, "ParentActionNo", DbType.String, entity.ParentActionNo);
                base.Database.AddInParameter(cmd, "Order", DbType.Int32, entity.Order);
                base.Database.AddInParameter(cmd, "Remark", DbType.String, entity.Remark);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }

        public ActionEntity FindEntityByNo(string actionno)
        {
            return ActionService.DataRowToBindEntity(this.FindByNo(modestring, actionno));
        }

        public RoleActionEntity[] GetRoleActions(string RoleId)
        {
            return RoleActionService.DataTableToBindEntitys(this.GetRelationData("roleaction", RoleId));
        }

        public static ActionEntity DataRowToBindEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new ActionEntity()
            {
                ActionNo = (string)(row["ActionNo"]),
                ActionName = (string)(row["ActionName"]),
                ParentActionNo = (string)(row["ParentActionNo"]),
                Remark = (string)(row["Remark"]),
                Order = (int)(row["Order"]),
                ActionType = (string)(row["ActionType"]),
            };
            return result;
        }

        public static ActionEntity[] DataTableToBindEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new ActionEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToBindEntity(dt.Rows[i]);
            }
            return results;
        }

        private ActionEntity[] GetChildMenus(string PNo)
        {
            return ActionService.DataTableToBindEntitys(this.GetTree(modestring, PNo));
        }

        public void DeleteEntity(string actionno)
        {
            base.UseTran((tran) =>
            {
                base.DeleteEntity(modestring, actionno, tran);
            });
        }

        public string GetNewChildNo(string parentactionno)
        {
            var allmenus = GetChildMenus(parentactionno).OrderBy(t => t.ActionNo).ToList();
            for (int i = 0; i < 100; i++)
            {
                string actionno = parentactionno + (i + 1).ToString().PadLeft(3, '0');
                if (allmenus.Count <= i)
                    return actionno;
                if (actionno != allmenus[i].ActionNo)
                {
                    return actionno;
                }
            }
            throw new BusinessException("超出最大限制");
        }
    }
}
