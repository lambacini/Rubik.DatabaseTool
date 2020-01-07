using System;
using System.Collections.Generic;
using System.Linq;
using Devart.Data.Oracle;
using System.Data;
using Rubik.Database.Enums;

namespace Rubik.Database.Objects
{
    [Serializable]
    public class Table
    {
        #region Variables

        public bool IsColumnsOnly = false;
        public Database Owner;
        
        #endregion
        #region Properties

        public string Name          { get; set; }
        public string Tablespace    { get; set; }
        public bool GenerateCreateStatement = false;

        public List<TableColumn> Columns = new List<TableColumn>();
        public List<Keys> KeyColumns = new List<Keys>();
        public List<Index> Indexes = new List<Index>();

        #endregion
        #region Private Methods

        private Keys IsPkAvailable()
        {
            var result = KeyColumns.Where(p => p.KeyType == KeyTypes.Primary);
            if (result != null && result.Count() > 0)
            {
                return result.FirstOrDefault();
            }
            else
                return null;
        }
        private void FillColumns()
        {
            string strSelectCols = "SELECT T.TABLE_NAME,T.COLUMN_NAME,T.DATA_TYPE,T.DATA_LENGTH,T.NULLABLE,T.COLUMN_ID,T.QUALIFIED_COL_NAME,T.DATA_DEFAULT,X.COMMENTS FROM USER_TAB_COLS T\n" +
                                    " LEFT JOIN USER_COL_COMMENTS X ON X.table_name = T.TABLE_NAME AND X.column_name = T.COLUMN_NAME \n" +
                                    " WHERE T.TABLE_NAME = :TABLE_NAME AND SUBSTR(T.COLUMN_NAME,0,4) != 'SYS_' ORDER BY COLUMN_ID ASC";


            OracleCommand cmd = new OracleCommand(strSelectCols)
                                    {
                                        Connection = this.Owner.Connection
                                    };
            cmd.Parameters.Add("TABLE_NAME", this.Name);

            OracleDataAdapter adapter = new OracleDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                TableColumn col = new TableColumn(this);
                col.Name = dr[1].ToString();
                col.ValueLength = int.Parse(dr["DATA_LENGTH"].ToString());
                col.ColumnType = StringToColType(dr["DATA_TYPE"].ToString());
                col.Nullable = (dr["NULLABLE"].ToString() == "Y") ? true : false;
                col.Default = dr["DATA_DEFAULT"].ToString();
                col.ColumnId = int.Parse(dr["COLUMN_ID"].ToString());

                if (dr["COMMENTS"].ToString().Length > 0)
                {
                    ColumnComment comment = new ColumnComment();
                    comment.Column = col;
                    comment.Comment = dr["COMMENTS"].ToString();
                    col.Comment = comment;
                }

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

            OracleCommand cmd = new OracleCommand(strSql);
            cmd.Connection = this.Owner.Connection;
            cmd.Parameters.Add("TABLE_NAME", this.Name);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Keys key = new Keys();
                var item = KeyColumns.Where(p => p.Name == dr["CONSTRAINT_NAME"].ToString()).FirstOrDefault();
                if (item != null)
                {
                    key = item;

                    TableColumn col = new TableColumn();
                    col.Name = dr["COLUMN_NAME"].ToString();

                    key.Columns.Add(col);

                }
                else
                {
                    key.Name = dr["CONSTRAINT_NAME"].ToString();
                    key.Owner = this;
                    key.KeyType = StringToKeyTypes(dr["CONSTRAINT_TYPE"].ToString());
                    key.OnDelete = OnDelete.NoAction;
                    key.Enabled = (dr["STATUS"].ToString() == "DISABLED") ? false : true;
                    if (key.KeyType == KeyTypes.Foreign)
                    {
                        key.ReferencingTable = dr["REFTABLE"].ToString();
                        key.ReferencingColumns = dr["REFCOL"].ToString();
                    }

                    TableColumn col = new TableColumn();
                    col.Name = dr["COLUMN_NAME"].ToString();

                    key.Columns.Add(col);

                    this.KeyColumns.Add(key);
                }
            }
        }
        private void FillIndexes()
        {

        }
        private KeyTypes StringToKeyTypes(string keyType)
        {
            switch (keyType)
            {
                case "U":
                    {
                        return KeyTypes.Unique;
                        break;
                    }
                case "P":
                    {
                        return KeyTypes.Primary;
                        break;
                    }
                case "R":
                    {
                        return KeyTypes.Foreign;
                        break;
                    }
                default:
                    {
                        return KeyTypes.Unknown;
                        break;
                    }
            }
        }
        private DataTypes StringToColType(string colType)
        {
            try
            {
                if (colType.IndexOf('(') > -1)
                {
                    colType = colType.Substring(0, colType.IndexOf('('));
                }
                DataTypes tempType = (DataTypes)Enum.Parse(typeof(DataTypes), colType);
                return tempType;
            }
            catch (Exception)
            {
                return DataTypes.UNKNOWN;
            }
        }

        #endregion
        #region Public Methods
        public string GetAlterColumnsSql(bool DropStatment, bool CreateStatement)
        {
            try
            {
                string sql = "";
                if (DropStatment)
                {
                    sql += "---Drop Statment\r\n";
                    sql += "DROP TABLE " + this.Name + ";";
                }

                if (CreateStatement || GenerateCreateStatement)
                {
                    Keys PK = IsPkAvailable();
                    TableColumn col = new TableColumn();
                    if (PK != null && PK.Columns.Count > 0)
                    {
                        col = this.Columns.Where(p => p.Name == PK.Columns.FirstOrDefault().Name).FirstOrDefault();
                    }
                    else
                    {
                        col = Columns.First();
                    }

                    sql += "\r\n\r\n---Create Table Statment\r\n";
                    sql += "CREATE TABLE " + this.Name + "\r\n (\r\n" + col.GetSelfString() + "\r\n);";

                    foreach (TableColumn item in Columns)
                    {
                        if (item.Name != col.Name)
                            sql += "\r\n" + item.GetAlterSql();
                    }

                    sql += "\r\n\r\n---Create Keys";

                    foreach (Keys item in this.KeyColumns)
                    {
                        sql += "\r\n" + item.GetAlterSql();
                    }
                }
                else
                {
                    sql += "\r\n\r\n---Create Columns";

                    foreach (TableColumn col in Columns)
                    {
                        sql += "\r\n" + col.GetAlterSql();
                    }

                    sql += "\r\n\r\n---Create Keys";

                    foreach (Keys item in this.KeyColumns)
                    {
                        sql += "\r\n" + item.GetAlterSql();
                    }
                }
                return sql;
            }
            catch
            {

                throw;
            }
        }
        public string GetTableSql()
        {
            try
            {
                string colSql = "";

                #region Prepaire Columns
                foreach (TableColumn col in Columns)
                {
                    colSql += "\r\n" + col.GetSelfString() + ",";
                }
                #endregion

                colSql = Utils.RemoveLastComma(colSql);
                string strSql = "CREATE TABLE " + this.Name + "\r\n (" + colSql + "\r\n);";
                return strSql;
            }
            catch
            {

                throw;
            }
        }
        public bool FillDbSchema()
        {
            FillColumns();
            FillKeys();
            return true;
        }
        #endregion
    }
}
