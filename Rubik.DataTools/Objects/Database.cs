using Devart.Data.Oracle;
using Rubik.DataTools.Enums;
using Rubik.DataTools.Interface;
using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Rubik.DataTools.Objects
{

    [Serializable]
    public class Database : IDatabase,ICloneable
    {
        //#region Events

        //public delegate void ObjectProcessingDelegate(IDatabaseObject obj);
        //public delegate void ProcessingComplatedDelegate();
        //public delegate void SchemaGenerated(Database owner);

        //public event SchemaGenerated OnSchemaGenerated;
        //public event ObjectProcessingDelegate OnObjectProcessing;
        //public event ProcessingComplatedDelegate OnProcessingComplated;

        //#endregion
        #region Variables

        private DatabaseFilter _filter;
        private ObservableCollection<Schema> _schemas = new ObservableCollection<Schema>();
        [NonSerialized]
        private DbConnection _connection;

        public bool IsModified { get; set; }

        #endregion
        #region Properties

        public Schema Owner
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public ObservableCollection<Schema> Users
        {
            get
            {
                return _schemas;
            }
            set
            {
                _schemas = value;
            }
        }
        public DatabaseTypeEnums DatabaseType { get; set; }
        public string DatabaseVersion
        {
            get;
            set;
        }

        [NonSerialized]
        private DbConnection Connection;

        [NonSerialized]
        private string _connectionString;

        public DatabaseFilter Filter {
            get {
                return _filter;
            }
            set {
                _filter = value;
            }
        }
        public Enums.ObjectTypeEnum ObjectType
        {
            get { return Enums.ObjectTypeEnum.Database; }
        }
        public bool IsSelected { get; set; }
        public bool IsLoaded
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
        #region Constructors

        public Database()
        {

        }
        public Database(string connectionString)
        {
            _connectionString = connectionString;
            Connection = new OracleConnection(_connectionString);
            if (this.Connection != null && !String.IsNullOrEmpty(this.Connection.ConnectionString))
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                this.DatabaseVersion = this.Connection.ServerVersion;
                this.Name = this.Connection.Database;
            }
            else
            {
                throw new NullReferenceException("Database Connection is null !");
            }
        }

        #endregion
        #region Private Methods

        private void Process()
        {
 
        }

        #endregion
        #region Public Methods

        public Schema AddNewSchema(string schemaName)
        {
            Schema userSchema = new Schema();
            userSchema.Name = schemaName;
            userSchema.OwnerUser = this;
            return userSchema;
        }
        public void DatabaseToSchema(DatabaseFilter filter,bool autoFillSchema)
        {
            _filter = filter;
            Task.Factory.StartNew(() => {
                DatabaseToSchema(autoFillSchema);
            });
        }
        public void DatabaseToSchema(bool autoFillSchema)
        {
            try
            {
                string strSql = "SELECT D.USERNAME,D.USER_ID,D.DEFAULT_TABLESPACE,D.TEMPORARY_TABLESPACE FROM DBA_USERS D \n" +
                                 " WHERE D.INITIAL_RSRC_CONSUMER_GROUP = 'DEFAULT_CONSUMER_GROUP'";
                string strUserFilter = " AND D.USERNAME IN ('FONETPACS')";

                if (_filter != null)
                {

                }
                else
                {
                    DataTable dt = this.Connection.GetSchema();
                    OracleCommand cmd = new OracleCommand(strSql+strUserFilter, (OracleConnection)this.Connection);
                    DbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Schema schema = AddNewSchema(reader["USERNAME"].ToString());
                        if (autoFillSchema)
                            schema.BuildObject();
                        this.Users.Add(schema);
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable FillDataTable(string strSql)
        {
            try
            {
                DataTable dt = new DataTable();
                OracleDataAdapter adaptor = new OracleDataAdapter(strSql, (OracleConnection)this.Connection);
                adaptor.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable FillDataTable(string strSql, DbParameter[] parameters)
        {
            try
            {
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = strSql;
                cmd.Parameters.AddRange(parameters);
                cmd.Connection = (OracleConnection)this.Connection;
                OracleDataAdapter adaptor = new OracleDataAdapter();
                adaptor.SelectCommand = cmd;
                adaptor.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string ExecuteScaler(string strSql)
        {
            try
            {
                OracleCommand cmd = new OracleCommand(strSql, (OracleConnection)this.Connection);
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void BuildObject()
        {
            throw new NotImplementedException();
        }
        public string SqlString
        {
            get { throw new NotImplementedException(); }
        }
        public string GetSqlString()
        {
            throw new NotImplementedException();
        }

        public void SerializeDatabase(string destinationLocation)
        {
            Stream sr = File.Open(destinationLocation, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(sr, this);
            sr.Close();
        }
        public static Database DeSerialize(string schemaPath)
        {
            Stream sr = File.Open(schemaPath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            object obj = formatter.Deserialize(sr);

            if (obj != null)
            {
                sr.Flush();
                sr.Close();
                Objects.Database db = (Objects.Database)obj;
                return db;
            }
            else
                return null;
        }
        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            

            foreach (var schema in this.Users)
            {
                var temp = schema.SchemaObjects.Where(p => p.IsSelected);

                if (schema.IsSelected)
                {
                    builder.AppendLine("------------------------------------------");
                    builder.AppendLine(String.Format("--User Objects {0}", schema.Name));
                    builder.AppendLine("------------------------------------------");
                    foreach (var item in schema.SchemaObjects.OrderBy(p => p.ObjectType).ToList())
                    {
                        if (item.GetType() == typeof(Table))
                        {
                            var table = item as Table;
                            if (!table.IsSelected && table.Columns.Where(p => p.IsSelected).Count() > 0)
                            {
                                builder.AppendLine(String.Format("--Table {0}", item.Name));
                                foreach (var col in table.Columns.Where(p=>p.IsSelected).ToList())
                                {
                                builder.AppendLine(col.GetSqlString());    
                                }
                            }
                            else if(table.IsSelected)
                            {
                                builder.AppendLine(String.Format("--Table {0}", item.Name));
                                builder.Append(((Table)item).GetAlterColumnsSql(false, true) + "\r\n");
                            }
                        }
                        else
                        {
                            if (item.IsSelected)
                            {
                                builder.AppendLine(String.Format("--{0} {1}", item.ObjectType.ToString(), item.Name));
                                builder.Append(item.GetSqlString() + "\r\n");
                            }
                        }

                    }
                }

                builder.AppendLine("------------------------------------------");
                builder.AppendLine("--End Of File");
            }

            return builder.ToString();

        }

        public Database CompareDatabase(string schemaFile)
        {
            Database fileSchema =  Database.DeSerialize(schemaFile);
            return DatabaseUtils.CompareDatabase(fileSchema, this);
        }

        public int CreatePriority
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
