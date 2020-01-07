using Rubik.DataTools.Enums;
using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik.DataTools.Objects
{
    [Serializable]
    public class Table : DatabaseObject
    {
        [field: NonSerialized]
        public override event DatabaseObject.ObjectProcessDelegate OnObjectProcess;

        private bool _includeTableData = false;
        private bool _generateCreateStatment = false;
        private DataTable _tableData;
        private List<string> _referencedTables = new List<string>();
        private System.Collections.ObjectModel.ObservableCollection<Column> _columns = new System.Collections.ObjectModel.ObservableCollection<Column>();
        private System.Collections.ObjectModel.ObservableCollection<Key> _keys = new System.Collections.ObjectModel.ObservableCollection<Key>();
        private System.Collections.ObjectModel.ObservableCollection<Index> _indexes = new System.Collections.ObjectModel.ObservableCollection<Index>();

        public string XmlDataFile = "";
        public DataTable TableData
        {
            get
            {
                return _tableData;
            }
            set
            {
                if (value != null)
                {
                    _tableData = value;
                    _includeTableData = true;
                }
            }
        }
        public bool GenerateCreateStatment
        {
            get
            {
                return _generateCreateStatment;
            }
            set
            {
                _generateCreateStatment = value;
            }
        }
        public bool IncludeTableData
        {
            get
            {
                return _includeTableData;
            }
            set
            {
                _includeTableData = value;
            }
        }
        public string TableSpace
        {
            get;
            set;
        }

        public List<string> ReferencedTables
        {
            get
            {
                return _referencedTables;
            }
        }

        public Table()
        {
            this.ObjectType = ObjectTypeEnum.TABLE;
            this.LoadPriority = 1;
        }

        public System.Collections.ObjectModel.ObservableCollection<Column> Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        public System.Collections.ObjectModel.ObservableCollection<Key> Keys
        {
            get { return _keys; }
            set { _keys = value; }
        }
        public System.Collections.ObjectModel.ObservableCollection<Index> Indexes
        {
            get
            {
                var indexes = Owner.SchemaObjects.Where(p => p.ObjectType == ObjectTypeEnum.INDEX && ((Index)p).Table == Name).Cast<Index>().ToList();
                _indexes = new System.Collections.ObjectModel.ObservableCollection<Index>(indexes);
                return _indexes;
            }
        }
        public string GetAlterColumnsSql(bool dropStatment, bool createStatment)
        {
            try
            {
                string sql = "";

                if (dropStatment)
                {
                    sql += "------Drop Script ---------------\r\n";
                    sql += "DROP TABLE " + this.Name + ";";
                    sql += "\r\n";
                }

                if (createStatment)
                {
                    Key PK = IsPkAvailable();
                    Column col = new Column();
                    if (PK != null && PK.Columns.Count > 0)
                    {
                        col = this.Columns.Where(p => p.Name == PK.Columns.FirstOrDefault().Name).FirstOrDefault();
                    }
                    else
                    {
                        col = Columns.FirstOrDefault();
                    }

                    sql += "\r\n\r\n---Create Table Statment " + this.CreatePriority.ToString() + "-" + this.Name + Common.NewLine;
                    sql += "CREATE TABLE " + this.Name + "\r\n" +
                        " (\r\n" +
                        "       " + col.GetSelfString() +
                        "\r\n);";

                    sql += "\r\n\r\n---Alter Table " + this.Name + Common.NewLine;
                    foreach (Column item in Columns)
                    {
                        if (item.Name != col.Name)
                            sql += "\r\n" + item.GetSqlString();
                    }

                    sql += "\r\n\r\n---Create Keys " + this.Name + Common.NewLine; ;

                    foreach (Key item in this.Keys)
                    {
                        sql += "\r\n" + item.GetSqlString();
                    }
                }
                else
                {
                    sql += "\r\n\r\n---Create Columns " + this.Name + Common.NewLine; ;

                    foreach (Column col in Columns)
                    {
                        sql += "\r\n" + col.GetSqlString();
                    }

                    sql += "\r\n\r\n---Create Keys " + this.Name + Common.NewLine; ;

                    foreach (Key item in this.Keys)
                    {
                        sql += "\r\n" + item.GetSqlString();
                    }
                }
                return sql;
            }
            catch (Exception ex)
            {
                return "Hata Oluştu !!! : " + ex.Message;
            }
        }
        public string GetInsertStatement()
        {
            if (_includeTableData)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine();
                builder.AppendLine("------------------ Insert Statement-----------------");

                if (TableData == null)
                {
                    FillData();
                }

                if (TableData == null || TableData.Rows.Count == 0)
                    return "";


                builder.AppendLine(String.Format("PROMPT DISABLING TRIGGERS FOR {0}...", this.Name));
                builder.AppendLine(String.Format("ALTER TABLE {0} DISABLE ALL TRIGGERS;", this.Name));
                builder.AppendLine();


                string strSql = "INSERT INTO " + this.Owner.Name + "." + this.Name + "({0}) VALUES ({1});";
                string colNames = "";

                foreach (DataColumn col in TableData.Columns)
                {
                    colNames += col.ColumnName + ",";
                }

                colNames = colNames.Substring(0, colNames.Length - 1);

                for (int i = 0; i < TableData.Rows.Count; i++)
                {
                    string rowValues = "";
                    foreach (DataColumn item in TableData.Columns)
                    {
                        var colData = TableData.Rows[i][item];
                        if (item.DataType == typeof(int) || item.DataType == typeof(Decimal))
                        {
                            rowValues += colData.ToString() + ",";
                        }
                        else
                        {
                            rowValues += "'" + colData.ToString() + "',";
                        }

                    }

                    rowValues = rowValues.Substring(0, rowValues.Length - 1);
                    builder.AppendLine(String.Format(strSql, colNames, rowValues));

                }
                builder.AppendLine("commit;");
                builder.AppendLine();
                builder.AppendLine(String.Format("PROMPT {0} ROWS LOADED ", TableData.Rows.Count));
                builder.AppendLine(String.Format("PROMPT ENABLING TRIGGERS FOR  {0}...", this.Name));
                builder.AppendLine(String.Format("ALTER TABLE {0} ENABLE ALL TRIGGERS;", this.Name));

                builder.AppendLine("---------------End Insert Statement ------------------");

                return builder.ToString();
            }

            return "";
        }
        public override void OnBuildObject()
        {
            FillColumns();
            FillKeys();
            FillReferencedTables();
            FillIndex();
        }
        public override string OnGetSqlString()
        {
            try
            {
                string colSql = "";

                #region Prepaire Columns
                foreach (Column col in Columns)
                {
                    colSql += "\r\n" + col.GetSqlString() + ",";
                }
                #endregion

                string strSql = "CREATE TABLE " + this.Name + "\r\n (" + colSql + "\r\n);";
                return strSql;
            }
            catch
            {

                throw;
            }
        }

        #region Private Methods

        private Key IsPkAvailable()
        {
            var result = Keys.Where(p => p.KeyType == KeyTypesEnum.Primary);
            if (result != null && result.Count() > 0)
            {
                return result.FirstOrDefault();
            }
            else
                return null;
        }
        private void FillColumns()
        {
            string strSelectCols = "SELECT T.TABLE_NAME,T.COLUMN_NAME,T.DATA_TYPE,T.DATA_LENGTH,T.NULLABLE,T.COLUMN_ID,T.QUALIFIED_COL_NAME,T.DATA_DEFAULT,X.COMMENTS FROM DBA_TAB_COLS T\n" +
                                    " LEFT JOIN USER_COL_COMMENTS X ON X.table_name = T.TABLE_NAME AND X.column_name = T.COLUMN_NAME \n" +
                                    " WHERE T.TABLE_NAME = :TABLE_NAME AND T.OWNER = :OWNER AND SUBSTR(T.COLUMN_NAME,0,4) != 'SYS_' ORDER BY COLUMN_ID ASC";

            var param = new Devart.Data.Oracle.OracleParameter("TABLE_NAME", this.Name);
            var param2 = new Devart.Data.Oracle.OracleParameter("OWNER", this.Owner.Name);

            DataTable dt = this.Owner.OwnerUser.FillDataTable(strSelectCols, new DbParameter[]{
                param,param2
            });


            foreach (DataRow dr in dt.Rows)
            {
                Column col = new Column(this);
                col.Name = dr[1].ToString();
                col.ValueLength = int.Parse(dr["DATA_LENGTH"].ToString());
                col.DataType = StringToColType(dr["DATA_TYPE"].ToString());
                col.Nullable = (dr["NULLABLE"].ToString() == "Y") ? true : false;
                col.Default = dr["DATA_DEFAULT"].ToString();
                col.ColumnId = int.Parse(dr["COLUMN_ID"].ToString());

                //if (dr["COMMENTS"].ToString().Length > 0)
                //{
                //    ColumnComment comment = new ColumnComment();
                //    comment.Column = col;
                //    comment.Comment = dr["COMMENTS"].ToString();
                //    col.Comment = comment;
                //}

                this.Columns.Add(col);
            }
        }
        private void FillKeys()
        {
            string strSql =
            "SELECT I.OWNER,\n" +
            "       I.CONSTRAINT_NAME,\n" +
            "       I.CONSTRAINT_TYPE,\n" +
            "       I.TABLE_NAME,\n" +
            "       I.DELETE_RULE,\n" +
            "       I.STATUS,\n" +
            "       U.COLUMN_NAME,\n" +
            "       U2.TABLE_NAME AS REFTABLE,U2.COLUMN_NAME AS REFCOL\n" +
            "  FROM USER_CONSTRAINTS I\n" +
            " INNER JOIN USER_CONS_COLUMNS U ON U.CONSTRAINT_NAME = I.CONSTRAINT_NAME\n" +
            "                               AND U.OWNER = I.OWNER\n" +
            " LEFT JOIN USER_CONS_COLUMNS U2 ON U2.constraint_name = I.R_CONSTRAINT_NAME\n" +
            " WHERE I.TABLE_NAME = :TABLE_NAME \n" +
            "   AND I.CONSTRAINT_TYPE IN ('P', 'R', 'U')";

            var param = new Devart.Data.Oracle.OracleParameter("TABLE_NAME", this.Name);

            DataTable dt = this.Owner.OwnerUser.FillDataTable(strSql, new DbParameter[]{
                param
            });


            foreach (DataRow dr in dt.Rows)
            {
                Key key = new Key();
                var item = Keys.Where(p => p.Name == dr["CONSTRAINT_NAME"].ToString()).FirstOrDefault();
                if (item != null)
                {
                    key = item;

                    Column col = new Column();
                    col.Name = dr["COLUMN_NAME"].ToString();

                    key.Columns.Add(col);

                }
                else
                {
                    key.Name = dr["CONSTRAINT_NAME"].ToString();
                    key.OwnerTable = this;
                    key.Owner = this.Owner;
                    key.KeyType = StringToKeyTypes(dr["CONSTRAINT_TYPE"].ToString());
                    key.OnDeleteAction = OnDeleteActionEnums.NoAction;
                    key.Enabled = (dr["STATUS"].ToString() == "DISABLED") ? false : true;
                    if (key.KeyType == KeyTypesEnum.Foreign)
                    {
                        key.ReferencingTable = dr["REFTABLE"].ToString();
                        key.ReferencingColumns = dr["REFCOL"].ToString();
                    }

                    Column col = new Column();
                    col.Name = dr["COLUMN_NAME"].ToString();

                    key.Columns.Add(col);

                    this.Keys.Add(key);
                }
            }
        }
        private void FillData()
        {
            try
            {
                string strCheckCount = "SELECT COUNT(*) FROM " + this.Owner.Name + "." + this.Name;
                var result = this.Owner.OwnerUser.ExecuteScaler(strCheckCount);
                if (!String.IsNullOrEmpty(result) && int.Parse(result) <= 10000)
                {
                    TableData = Owner.OwnerUser.FillDataTable("SELECT * FROM " + this.Owner.Name + "." + this.Name);
                }
                else
                {
                    throw new SystemException("Tablodaki kayıt sayısı çok fazla bu tabloyu dışa aktaramazsınız !");
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void FillReferencedTables()
        {

            string strSql =
                "SELECT OWNER,CONSTRAINT_NAME,CONSTRAINT_TYPE,TABLE_NAME,R_OWNER,R_CONSTRAINT_NAME,DELETE_RULE\n" +
            "  FROM SYS.ALL_CONSTRAINTS\n" +
            " WHERE TABLE_NAME = :TABLE_NAME\n" +
            "   AND OWNER = :OWNER\n" +
            "   AND CONSTRAINT_TYPE IN ('R')\n" +
            " ORDER BY CONSTRAINT_TYPE,CONSTRAINT_NAME";

            var param = new Devart.Data.Oracle.OracleParameter("TABLE_NAME", this.Name);
            var param2 = new Devart.Data.Oracle.OracleParameter("OWNER", this.Owner.Name);

            DataTable dt = this.Owner.OwnerUser.FillDataTable(strSql, new DbParameter[]{
                param,param2
            });

            foreach (DataRow item in dt.Rows)
            {
                string constName = item["R_CONSTRAINT_NAME"].ToString();
                string constTable = FindConstTableName(constName);

                if (!_referencedTables.Contains(constTable))
                    _referencedTables.Add(constTable);
            }

        }

        private void FillIndex()
        {
            var indexes = Owner.SchemaObjects.Where(p => p.ObjectType == ObjectTypeEnum.INDEX && ((Index)p).Table == Name).Cast<Index>().ToList();
        }

        private string FindConstTableName(string constName)
        {
            string sqlString = "SELECT TABLE_NAME\n" +
            "  FROM SYS.ALL_CONSTRAINTS\n" +
            " WHERE CONSTRAINT_NAME = :CONST_NAME \n" +
            "   AND OWNER = :OWNER \n" +
            "   AND CONSTRAINT_TYPE IN ('P', 'U')";

            var param = new Devart.Data.Oracle.OracleParameter("CONST_NAME", constName);
            var param2 = new Devart.Data.Oracle.OracleParameter("OWNER", this.Owner.Name);

            DataTable dt = this.Owner.OwnerUser.FillDataTable(sqlString, new DbParameter[]{
                param,param2
            });

            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();

            return "";
        }
        private DataTypeEnums StringToColType(string colType)
        {
            try
            {
                if (colType.IndexOf('(') > -1)
                {
                    colType = colType.Substring(0, colType.IndexOf('('));
                }
                DataTypeEnums tempType = (DataTypeEnums)Enum.Parse(typeof(DataTypeEnums), colType);
                return tempType;
            }
            catch (Exception)
            {
                return DataTypeEnums.UNKNOWN;
            }
        }
        private KeyTypesEnum StringToKeyTypes(string keyType)
        {
            switch (keyType)
            {
                case "U":
                    {
                        return KeyTypesEnum.Unique;
                        break;
                    }
                case "P":
                    {
                        return KeyTypesEnum.Primary;
                        break;
                    }
                case "R":
                    {
                        return KeyTypesEnum.Foreign;
                        break;
                    }
                default:
                    {
                        return KeyTypesEnum.Unknown;
                        break;
                    }
            }
        }



        #endregion
    }
}
