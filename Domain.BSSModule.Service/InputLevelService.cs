using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Domain.BSSModule.Service.Interface;
using FengSharp.OneCardAccess.Domain.RBACModule.Service.Interface;
using FengSharp.OneCardAccess.Infrastructure;
using FengSharp.OneCardAccess.Infrastructure.Services;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace FengSharp.OneCardAccess.Domain.BSSModule.Service
{
    public class InputLevelService : ServiceBase, IInputLevelService
    {
        #region 实体转化
        public static DlyInputLevelInputerEntity DataRowToBindEntity(DataRow row)
        {
            if (row == null)
                return null;
            var result = new DlyInputLevelInputerEntity();
            result.DlyTypeId = (int)row["DlyTypeId"];
            result.Id = (int)row["Id"];
            result.InputerId = (string)row["InputerId"];
            result.InputerName = (string)row["InputerName"];
            result.InputLevel = (short)row["InputLevel"];
            return result;
        }
        public static DlyInputLevelInputerEntity[] DataTableToBindEntitys(DataTable dt)
        {
            if (dt == null)
                return null;
            var results = new DlyInputLevelInputerEntity[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results[i] = InputLevelService.DataRowToBindEntity(dt.Rows[i]);
            }
            return results;
        }
        #endregion
        public DlyInputLevelInputerEntity[] GetInputLevelsByDlyTypeId(int DlyTypeId)
        {
            var dt = this.GetRelationData("dlytypeinputlevel", DlyTypeId);
            return InputLevelService.DataTableToBindEntitys(dt);
        }
        public void SaveInputLevel(int DlyTypeId, short inputlevel, List<DlyInputLevelInputerEntity> inputlevels)
        {
            base.UseTran((tran) =>
            {
                DbCommand cmd1 = base.Database.GetStoredProcCommand("P_InputLevelFlow");
                Database.AddInParameter(cmd1, "cMode", DbType.String, "delinputer");
                Database.AddInParameter(cmd1, "DlyTypeId", DbType.Int32, DlyTypeId);
                Database.AddInParameter(cmd1, "InputLevel", DbType.Int16, (short)0);
                Database.AddInParameter(cmd1, "InputerId", DbType.String, string.Empty);
                Database.AddInParameter(cmd1, "DlyNdxId", DbType.String, string.Empty);
                Database.AddOutParameter(cmd1, "HasRight", DbType.Boolean, 1);
                Database.ExecuteNonQuery(cmd1, tran);
                DbCommand cmd2 = base.Database.GetStoredProcCommand("P_InputLevelFlow");
                Database.AddInParameter(cmd2, "cMode", DbType.String, "updateinputlevel");
                Database.AddInParameter(cmd2, "DlyTypeId", DbType.Int32, DlyTypeId);
                Database.AddInParameter(cmd2, "InputLevel", DbType.Int16, inputlevel);
                Database.AddInParameter(cmd2, "InputerId", DbType.String, string.Empty);
                Database.AddInParameter(cmd2, "DlyNdxId", DbType.String, string.Empty);
                Database.AddOutParameter(cmd2, "HasRight", DbType.Boolean, 1);
                Database.ExecuteNonQuery(cmd2, tran);
                inputlevels.ForEach((entity) =>
                {
                    DbCommand cmd3 = base.Database.GetStoredProcCommand("P_InputLevelFlow");
                    Database.AddInParameter(cmd3, "cMode", DbType.String, "addinputer");
                    Database.AddInParameter(cmd3, "DlyTypeId", DbType.Int32, DlyTypeId);
                    Database.AddInParameter(cmd3, "InputLevel", DbType.Int16, entity.InputLevel);
                    Database.AddInParameter(cmd3, "InputerId", DbType.String, entity.InputerId);
                    Database.AddInParameter(cmd3, "DlyNdxId", DbType.String, string.Empty);
                    Database.AddOutParameter(cmd3, "HasRight", DbType.Boolean, 1);
                    Database.ExecuteNonQuery(cmd3, tran);
                });
            });
        }
        public bool CheckInputLevel(int DlyTypeId, short inputlevel)
        {
            string userid = ServiceLoader.LoadService<IAuthService>().GetUserIdByTicket();
            bool result = false;
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_InputLevelFlow");
                Database.AddInParameter(cmd, "cMode", DbType.String, "checkright");
                Database.AddInParameter(cmd, "DlyTypeId", DbType.Int32, DlyTypeId);
                Database.AddInParameter(cmd, "InputLevel", DbType.Int16, inputlevel);
                Database.AddInParameter(cmd, "InputerId", DbType.String, userid);
                Database.AddInParameter(cmd, "DlyNdxId", DbType.String, string.Empty);
                Database.AddOutParameter(cmd, "HasRight", DbType.Boolean, 1);
                Database.ExecuteNonQuery(cmd, tran);
                result = (bool)Database.GetParameterValue(cmd, "HasRight");
            });
            return result;
        }
        public void SHDJ(int DlyTypeId, short inputlevel, string dlyNdxId)
        {
            string userid = ServiceLoader.LoadService<IAuthService>().GetUserIdByTicket();
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_InputLevelFlow");
                Database.AddInParameter(cmd, "cMode", DbType.String, "shdj");
                Database.AddInParameter(cmd, "DlyTypeId", DbType.Int32, DlyTypeId);
                Database.AddInParameter(cmd, "InputLevel", DbType.Int16, inputlevel);
                Database.AddInParameter(cmd, "InputerId", DbType.String, userid);
                Database.AddInParameter(cmd, "DlyNdxId", DbType.String, dlyNdxId);
                Database.AddOutParameter(cmd, "HasRight", DbType.Boolean, 1);
                Database.ExecuteNonQuery(cmd, tran);
            });
        }
        public void FSDJ(int DlyTypeId, short inputlevel, string dlyNdxId)
        {
            string userid = ServiceLoader.LoadService<IAuthService>().GetUserIdByTicket();
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_InputLevelFlow");
                Database.AddInParameter(cmd, "cMode", DbType.String, "fsdj");
                Database.AddInParameter(cmd, "DlyTypeId", DbType.Int32, DlyTypeId);
                Database.AddInParameter(cmd, "InputLevel", DbType.Int16, inputlevel);
                Database.AddInParameter(cmd, "InputerId", DbType.String, userid);
                Database.AddInParameter(cmd, "DlyNdxId", DbType.String, dlyNdxId);
                Database.AddOutParameter(cmd, "HasRight", DbType.Boolean, 1);
                Database.ExecuteNonQuery(cmd, tran);
            });
        }


        public short GetTotalInputLevel(int DlyTypeId)
        {
            short totalinputlevel = 0;
            base.UseTran((tran) =>
            {
                DbCommand cmd = base.Database.GetStoredProcCommand("P_InputLevelFlow");
                Database.AddInParameter(cmd, "cMode", DbType.String, "getinputlevel");
                Database.AddInParameter(cmd, "DlyTypeId", DbType.Int32, DlyTypeId);
                Database.AddOutParameter(cmd, "InputLevel", DbType.Int16, 2);
                Database.AddInParameter(cmd, "InputerId", DbType.String, string.Empty);
                Database.AddInParameter(cmd, "DlyNdxId", DbType.String, string.Empty);
                Database.AddOutParameter(cmd, "HasRight", DbType.Boolean, 1);
                Database.ExecuteNonQuery(cmd, tran);
                totalinputlevel = (short)Database.GetParameterValue(cmd, "InputLevel");
            });
            return totalinputlevel;
        }
    }
}
