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

namespace Rubik.DataTools.Fluent
{
    [Serializable]
    public class DatabaseFactory : IDatabase, ICloneable
    {
        [field: NonSerialized]
        public delegate void ObjectProcessDelegate(IDatabase database,Schema schema, IDatabaseObject obj);
        [field: NonSerialized]
        public event ObjectProcessDelegate OnSchemaProcess;

        [NonSerialized]
        private string _cnnStr;
        [NonSerialized]
        private DbConnection _connection;

        private ObservableCollection<Schema> _schemas = new ObservableCollection<Schema>();
        private DatabaseFilter _databaseFilter = new DatabaseFilter();
        private List<string> _schemaList = new List<string>();
        private bool _includeDefaultSchema = true;
        private bool _dropObject = false;
        private bool _autoChangeSchema = false;
        private bool _createUser = false;
        private bool _separateSchema = false;

        #region Properties

        public bool IsSchemaFile
        {
            get;
            set;
        }
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
        public string DefaultUserSchema
        {
            get;
            set;
        }
        public bool IsSelected
        {
            get;
            set;
        }

        public bool IsModified
        {
            get;
            set;
        }

        public bool IsLoaded
        {
            get;
            set;
        }

        public ObjectTypeEnum ObjectType
        {
            get { return ObjectTypeEnum.Database; }
        }

        #endregion

        #region Constructor

        public DatabaseFactory()
        {

        }

        public DatabaseFactory(string cnnStr)
            : this()
        {
            _cnnStr = cnnStr;
            _connection = new OracleConnection(_cnnStr);
            _connection.Open();
            DatabaseVersion = this._connection.ServerVersion;
            Name = this._connection.Database;
            //DefaultUserSchema = this._connection.GetSchema().Rows[0][0].ToString();
            var test = this._connection.GetSchema();
        }

        #endregion

        #region Fluent Methods

        public static DatabaseFactory Init(string cnnStr = "")
        {
            return new DatabaseFactory(cnnStr);
        }

        public DatabaseFactory AddSchema(string schemaName)
        {
            if(_schemas.FirstOrDefault(p=>p.Name == schemaName) == null)
            {
                Schema schema = new Schema();
                schema.Name = schemaName;
                schema.OwnerUser = this;

                _schemas.Add(schema);
            }

            return this;
        }

        public DatabaseFactory UseSchemaChangeScript()
        {
            _autoChangeSchema = true;
            return this;
        }

        public DatabaseFactory CreateUserScript()
        {
            _createUser = true;
            return this;
        }


        public DatabaseFactory SeparateScriptFilePerSchema()
        {
            _separateSchema = true;
            return this;
        }

        public DatabaseFactory ExcludeDefaultSchema()
        {
            _includeDefaultSchema = false;
            return this;
        }

        public DatabaseFactory IncludeDropStatement()
        {
            _dropObject = true;
            return this;
        }

        public DatabaseFactory UseDatabaseFilter(DatabaseFilter filter)
        {
            if (filter != null)
                _databaseFilter = filter;

            return this;
        }

        #endregion

        #region Public Methods

        public DataTable FillDataTable(string strSql)
        {
            try
            {
                DataTable dt = new DataTable();
                OracleDataAdapter adaptor = new OracleDataAdapter(strSql, (OracleConnection)this._connection);
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
                cmd.Connection = (OracleConnection)this._connection;
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
                OracleCommand cmd = new OracleCommand(strSql, (OracleConnection)this._connection);
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void BuildObject()
        {
            Prepare();
            LoadSchemas();
        }

        public async Task<bool> BuildAsync()
        {
            Prepare();

            await Task.Factory.StartNew(() =>
            {
                LoadSchemas();
            });

            return true;
        }

        public string GetSqlString()
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            return null;
        }

        public string ToSql()
        {
            
            StringBuilder builder = new StringBuilder();

            foreach (var schema in this.Users)
            {
                schema.SortObjects();

                if (schema.IsSelected)
                {
                    builder.AppendLine("------------------------------------------");
                    builder.AppendLine(String.Format("--User Objects {0}", schema.Name));
                    builder.AppendLine("------------------------------------------");
                    if(_autoChangeSchema)
                    {
                        builder.AppendLine("------Change Schema-------");
                        builder.AppendLine(String.Format("ALTER SESSION SET CURRENT_SCHEMA ={0};", schema.Name));
                    }

                    foreach (var item in schema.SchemaObjects.OrderBy(p => p.CreatePriority).ToList())
                    {
                        

                        if (item.GetType() == typeof(Table))
                        {
                            var table = item as Table;
                            if (!table.IsSelected && table.Columns.Where(p => p.IsSelected).Count() > 0)
                            {
                                if (_dropObject && (item as DatabaseObject) != null)
                                {
                                    var dbItem = item as DatabaseObject;
                                    string dropStatement = dbItem.DropStatement();

                                    builder.AppendLine("------Drop Script ---------------");
                                    builder.AppendLine(dropStatement);
                                }

                                builder.AppendLine(String.Format("--Table {0}", item.Name));


                                foreach (var col in table.Columns.Where(p => p.IsSelected).ToList())
                                {
                                    builder.AppendLine(col.GetSqlString());
                                }
                            }
                            else if (table.IsSelected)
                            {
                                if (_dropObject && (item as DatabaseObject) != null)
                                {
                                    var dbItem = item as DatabaseObject;
                                    string dropStatement = dbItem.DropStatement();

                                    builder.AppendLine("------Drop Script ---------------");
                                    builder.AppendLine(dropStatement);
                                }

                                builder.AppendLine(String.Format("--Table {0}", item.Name));
                                builder.Append(((Table)item).GetAlterColumnsSql(false, true) + "\r\n");
                            }
                        }
                        else if(item.GetType() != typeof(Index))
                        {
                            if (item.IsSelected)
                            {
                                if (_dropObject && (item as DatabaseObject) != null)
                                {
                                    var dbItem = item as DatabaseObject;
                                    string dropStatement = dbItem.DropStatement();

                                    builder.AppendLine("------Drop Script ---------------");
                                    builder.AppendLine(dropStatement);
                                }

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

        public void SerializeDatabase(string destination)
        {
            Stream sr = File.Open(destination, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(sr, this);
            sr.Close();

        }

        public static DatabaseFactory DeSerialize(string schemaPath)
        {
            Stream sr = File.Open(schemaPath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            object obj = formatter.Deserialize(sr);

            if (obj != null)
            {
                sr.Flush();
                sr.Close();
                DatabaseFactory db = (DatabaseFactory)obj;
                db.IsSchemaFile = true;
                return db;
            }
            else
                return null;
        }

        public int CreatePriority
        {
            get;
            set;
        }

        #endregion

        #region Private Methods


        private void IncludeDefaultUserSchema()
        {
            string strSql = "SELECT USER FROM DUAL";
            OracleCommand cmd = new OracleCommand(strSql, (OracleConnection)_connection);
            DefaultUserSchema = cmd.ExecuteScalar().ToString();

            Schema defaultSchema = new Schema();
            defaultSchema.Name = DefaultUserSchema;
            defaultSchema.OwnerUser = this;

            _schemas.Add(defaultSchema);
        }

        private bool Prepare()
        {
            if (_includeDefaultSchema)
                IncludeDefaultUserSchema();

            foreach (var user in _databaseFilter.DatabaseUsers)
            {
                Schema schema = new Schema();
                schema.Name = user;
                schema.OwnerUser = this;

                _schemas.Add(schema);
            }

            return true;
        }

        private void LoadSchemas()
        {
            foreach (var schema in _schemas)
            {
                schema.OnObjectProcess += (s, e) =>
                {
                    if (OnSchemaProcess != null)
                        OnSchemaProcess(this, schema, e);
                };

                schema.BuildObject();

            }
        }

        #endregion

    }
}
