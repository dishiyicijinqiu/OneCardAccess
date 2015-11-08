using FengSharp.OneCardAccess.Domain.RBACModule.Entity;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System.Data;
using System.Data.Common;
using System.Linq;
namespace FengSharp.OneCardAccess.Domain.RBACModule.Service
{
    public class MenuService : ServiceBase, IMenuService
    {
        const string modestring = "menu";
        public MenuEntity[] GetAllEntity()
        {
            var dt = this.GetList(modestring);
            return DataTableToBindEntitys(dt);
        }

        public void CreateEntity(MenuEntity entity)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_CreateMenu");
                base.Database.AddInParameter(cmd, "MenuNo", DbType.String, entity.MenuNo);
                base.Database.AddInParameter(cmd, "PNo", DbType.String, entity.PNo);
                base.Database.AddInParameter(cmd, "MenuName", DbType.String, entity.MenuName);
                base.Database.AddInParameter(cmd, "Order", DbType.Int32, entity.Order);
                base.Database.AddInParameter(cmd, "Glyph", DbType.String, entity.Glyph);
                base.Database.AddInParameter(cmd, "OnClick", DbType.String, entity.OnClick);
                base.Database.AddInParameter(cmd, "KeyTip", DbType.String, entity.KeyTip);
                base.Database.AddInParameter(cmd, "MenuControl", DbType.String, entity.MenuControl);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }

        public void UpdateEntity(string menuno, MenuEntity entity)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_UpdateMenu");
                base.Database.AddInParameter(cmd, "OldMenuNo", DbType.String, menuno);
                base.Database.AddInParameter(cmd, "MenuNo", DbType.String, entity.MenuNo);
                base.Database.AddInParameter(cmd, "PNo", DbType.String, entity.PNo);
                base.Database.AddInParameter(cmd, "MenuName", DbType.String, entity.MenuName);
                base.Database.AddInParameter(cmd, "Order", DbType.Int32, entity.Order);
                base.Database.AddInParameter(cmd, "Glyph", DbType.String, entity.Glyph);
                base.Database.AddInParameter(cmd, "OnClick", DbType.String, entity.OnClick);
                base.Database.AddInParameter(cmd, "KeyTip", DbType.String, entity.KeyTip);
                base.Database.AddInParameter(cmd, "MenuControl", DbType.String, entity.MenuControl);
                base.Database.ExecuteNonQuery(cmd, tran);
            });
        }

        public MenuEntity FindEntityByNo(string menuno)
        {
            var row = this.FindByNo(modestring, menuno);
            return DataRowToBindEntity(row);
        }

        public RoleMenuEntity[] GetRoleMenus(string RoleId)
        {
            DataTable dt = this.GetRelationData("rolemenu", RoleId);
            return RoleMenuService.DataTableToBindEntitys(dt);
        }

        public string[] GetUserMenuNos(string UserId)
        {
            DataTable dt = this.GetRelationData("usermenu", UserId);
            var array = dt.Rows.Cast<DataRow>().Select(t => t["MenuNo"].ToString()).ToArray();
            return array;
        }

        public static MenuEntity DataRowToBindEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new MenuEntity()
            {
                MenuNo = (string)(row["MenuNo"]),
                PNo = (string)(row["PNo"]),
                MenuName = (string)(row["MenuName"]),
                Order = (int)(row["Order"]),
                Glyph = (string)(row["Glyph"]),
                OnClick = (string)(row["OnClick"]),
                KeyTip = (string)(row["KeyTip"]),
                MenuControl = (string)(row["MenuControl"]),

            };
            return result;
        }

        public static MenuEntity[] DataTableToBindEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new MenuEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToBindEntity(dt.Rows[i]);
            }
            return results;
        }

        private MenuEntity[] GetChildMenus(string PNo)
        {
            var dt = this.GetChildList(modestring, PNo);
            return DataTableToBindEntitys(dt);
        }

        public string GetNewChildNo(string PNo)
        {
            var allmenus = GetChildMenus(PNo).OrderBy(t => t.MenuNo).ToList();
            for (int i = 0; i < 100; i++)
            {
                string menuno = PNo + (i + 1).ToString().PadLeft(3, '0');
                if (allmenus.Count <= i)
                    return menuno;
                if (menuno != allmenus[i].MenuNo)
                {
                    return menuno;
                }
            }
            throw new BusinessException("超出最大限制");
        }

        public void DeleteEntity(string MenuNo)
        {
            base.UseTran((tran) =>
            {
                base.DeleteEntity(modestring, MenuNo, tran);
            });
        }
    }
}
