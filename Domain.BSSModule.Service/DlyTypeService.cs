using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure.Services;
using System.Data;

namespace FengSharp.OneCardAccess.Domain.BSSModule.Service
{
    public class DlyTypeService : ServiceBase, IDlyTypeService
    {
        const string modestring = "dlytype";

        public DlyTypeCateEntity[] GetDlyTypeTree(int pid)
        {
            var dt = base.GetTree(modestring, pid);
            return DlyTypeService.DataTableToCateEntitys(dt);
        }

        public DlyTypeEntity GetDlyTypeById(int dlytypeid)
        {
            var row = this.FindById(modestring, dlytypeid);
            return DlyTypeService.DataRowToEntity(row);
        }
        #region 实体转换

        public static DlyTypeCateEntity[] DataTableToCateEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new DlyTypeCateEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DlyTypeService.DataRowToCateEntity(dt.Rows[i]);
            }
            return results;
        }
        public static DlyTypeCateEntity DataRowToCateEntity(DataRow dataRow)
        {
            if (dataRow == null)
                return null;
            var result = new DlyTypeCateEntity();
            var entity = DlyTypeService.DataRowToEntity(dataRow);
            FengSharp.Tool.Reflect.ClassValueCopier.Copy(result, entity);
            result.HasCate = result.Level_Num > 0;
            return result;
        }
        public static DlyTypeEntity[] DataTableToEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new DlyTypeEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = DataRowToEntity(dt.Rows[i]);
            }
            return results;
        }

        public static DlyTypeEntity DataRowToEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new DlyTypeEntity()
            {
                DlyFormat = (string)(row["DlyFormat"]),
                DlyHeader = (string)(row["DlyHeader"]),
                DlyName = (string)(row["DlyName"]),
                DlyTypeId = (int)(row["DlyTypeId"]),
                InputLevel = (short)(row["InputLevel"]),
                Remark = (string)(row["Remark"]),
                PId = (int)(row["PId"]),
                Level_Path = (string)(row["Level_Path"]),
                Level_Num = (int)(row["Level_Num"]),
                Level_Total = (int)(row["Level_Total"]),
                Level_Deep = (int)(row["Level_Deep"]),
            };
            return result;
        }
        #endregion
    }
}
