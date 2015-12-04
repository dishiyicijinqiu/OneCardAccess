﻿using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Instrumentation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace FengSharp.OneCardAccess.Infrastructure.Services
{
    public abstract class ServiceBase
    {
        private Database database;
        public Database Database
        {
            get
            {
                if (database == null)
                    database = DBHelper.CreateDataBase();
                return database;
            }
        }

        protected void UseTran(Action<DbTransaction> action)
        {
            using (DbConnection connection = this.Database.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    action(transaction);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        #region FindById
        public virtual DataRow FindById(string cMode, string EntityId, string UserId = null)
        {
            DbCommand cmd = Database.GetStoredProcCommand("P_Glo_FindById;1");
            Database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            Database.AddInParameter(cmd, "EntityId", DbType.String, EntityId);
            Database.AddInParameter(cmd, "UserId", DbType.String, UserId);
            DataTable dt = Database.ExecuteDataTable(cmd);
            if (dt == null || dt.Rows.Count <= 0)
                return null;
            return dt.Rows[0];
        }

        public virtual DataRow FindById(string cMode, int EntityId, string UserId = null)
        {
            DbCommand cmd = Database.GetStoredProcCommand("P_Glo_FindById;2");
            Database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            Database.AddInParameter(cmd, "EntityId", DbType.Int32, EntityId);
            Database.AddInParameter(cmd, "UserId", DbType.String, UserId);
            DataTable dt = Database.ExecuteDataTable(cmd);
            if (dt == null || dt.Rows.Count <= 0)
                return null;
            return dt.Rows[0];
        }
        #endregion

        #region FindByNo
        public virtual DataRow FindByNo(string cMode, string entityNo)
        {
            DbCommand cmd = Database.GetStoredProcCommand("P_Glo_FindByNo");
            Database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            Database.AddInParameter(cmd, "EntityNo", DbType.String, entityNo);
            DataTable dt = Database.ExecuteDataTable(cmd);
            if (dt == null || dt.Rows.Count <= 0)
                return null;
            return dt.Rows[0];
        }
        #endregion

        public virtual DataTable GetList(string cMode, string UserId = null)
        {
            DbCommand cmd = Database.GetStoredProcCommand("P_Glo_GetList;1");
            Database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            Database.AddInParameter(cmd, "UserId", DbType.String, UserId);
            return Database.ExecuteDataTable(cmd);
        }

        #region GetTree
        public virtual DataTable GetTree(string cMode, int PId, string UserId = null)
        {
            DbCommand cmd = Database.GetStoredProcCommand("P_Glo_GetTree;1");
            Database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            Database.AddInParameter(cmd, "PId", DbType.Int32, PId);
            Database.AddInParameter(cmd, "UserId", DbType.String, UserId);
            return Database.ExecuteDataTable(cmd);
        }

        public virtual DataTable GetTree(string cMode, string PId, string UserId = null)
        {
            DbCommand cmd = Database.GetStoredProcCommand("P_Glo_GetTree;2");
            Database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            Database.AddInParameter(cmd, "PId", DbType.String, PId);
            Database.AddInParameter(cmd, "UserId", DbType.String, UserId);
            return Database.ExecuteDataTable(cmd);
        }
        #endregion

        #region GetRelationData
        public virtual DataTable GetRelationData(string cMode, string EntityId, string UserId = null)
        {
            DbCommand cmd = Database.GetStoredProcCommand("P_Glo_GetRelationData;1");
            Database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            Database.AddInParameter(cmd, "EntityId", DbType.String, EntityId);
            Database.AddInParameter(cmd, "UserId", DbType.String, UserId);
            return Database.ExecuteDataTable(cmd);
        }

        public virtual DataTable GetRelationData(string cMode, int EntityId, string UserId = null)
        {
            DbCommand cmd = Database.GetStoredProcCommand("P_Glo_GetRelationData;2");
            Database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            Database.AddInParameter(cmd, "EntityId", DbType.Int32, EntityId);
            Database.AddInParameter(cmd, "UserId", DbType.String, UserId);
            return Database.ExecuteDataTable(cmd);
        }
        #endregion
        #region DeleteEntity
        public virtual void DeleteEntity(string cMode, string EntityId, DbTransaction transaction = null)
        {
            DbCommand cmd = Database.GetStoredProcCommand("P_Glo_Delete");
            Database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            Database.AddInParameter(cmd, "EntityId", DbType.String, EntityId);
            if (transaction == null)
                Database.ExecuteNonQuery(cmd);
            else
                Database.ExecuteNonQuery(cmd, transaction);
        }
        public virtual void DeleteEntity(string cMode, int EntityId, DbTransaction transaction = null)
        {
            DbCommand cmd = Database.GetStoredProcCommand("P_Glo_Delete;2");
            Database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            Database.AddInParameter(cmd, "EntityId", DbType.Int32, EntityId);
            if (transaction == null)
                Database.ExecuteNonQuery(cmd);
            else
                Database.ExecuteNonQuery(cmd, transaction);
        }
        #endregion
        public virtual void DeleteRelationData(string cMode, string EntityId, DbTransaction transaction = null)
        {
            DbCommand cmd = Database.GetStoredProcCommand("P_Glo_DeleteRelationData;1");
            Database.AddInParameter(cmd, "cMode", DbType.String, cMode);
            Database.AddInParameter(cmd, "EntityId", DbType.String, EntityId);
            if (transaction == null)
                Database.ExecuteNonQuery(cmd);
            else
                Database.ExecuteNonQuery(cmd, transaction);
        }
    }
    public static class DataBaseExtend
    {
        public static DataTable ExecuteDataTable(this Database database, DbCommand cmd, DbTransaction transaction = null)
        {
            DataSet ds;
            if (transaction != null)
                ds = database.ExecuteDataSet(cmd, transaction);
            else
                ds = database.ExecuteDataSet(cmd);
            if (ds == null || ds.Tables.Count <= 0)
                return null;
            return ds.Tables[0];
        }
        public static void AddReturnParameter(this Database database, DbCommand cmd, string name, DbType dbType)
        {
            database.AddParameter(cmd, name, dbType, ParameterDirection.ReturnValue, null, DataRowVersion.Default, null);
        }
    }

    [ConfigurationElementType(typeof(FengSharpDatabaseData))]
    public class FengSharpDataBase : Database
    {
        public FengSharpDataBase(string connectionString, DbProviderFactory dbProviderFactory
        )
            : base(connectionString, dbProviderFactory)
        {
        }
        public FengSharpDataBase(string connectionString, DbProviderFactory dbProviderFactory, IDataInstrumentationProvider instrumentationProvider)
            : base(connectionString, dbProviderFactory, instrumentationProvider)
        {
            //AddInParameter
        }
        public override void AddParameter(DbCommand command, string name, DbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            command.CommandTimeout = 0;
            base.AddParameter(command, name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
        }
        protected override void DeriveParameters(DbCommand discoveryCommand)
        {
            throw new NotSupportedException("不支持");
        }
    }
    public class FengSharpDatabaseData : DatabaseData
    {
        public FengSharpDatabaseData(ConnectionStringSettings connectionStringSettings, IConfigurationSource configurationSource)
            : base(connectionStringSettings, configurationSource)
        {
        }

        /// <summary>
        /// Gets the name of the ADO.NET provider for the represented database.
        /// </summary>
        public string ProviderName
        {
            get { return ConnectionStringSettings.ProviderName; }
        }
        public override IEnumerable<TypeRegistration> GetRegistrations()
        {
            yield return new TypeRegistration<Database>(
                () => new FengSharpDataBase(ConnectionString,
                    System.Data.SqlClient.SqlClientFactory.Instance,
                    Container.Resolved<IDataInstrumentationProvider>(Name)))
            {
                Name = Name,
                Lifetime = TypeRegistrationLifetime.Transient
            };
        }
    }
}
