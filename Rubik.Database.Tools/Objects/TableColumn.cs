using System;
using Rubik.Database.Enums;

namespace Rubik.Database.Objects
{
    [Serializable]
    public class TableColumn
    {
        #region Constractor
        public TableColumn() { }
        public TableColumn(Table owner)
        {
            this.Owner = owner;
        }
        #endregion
        #region Properties

        public bool Modified        { get; set; }
        public string Name          { get; set; }
        public string Default       { get; set; }
        public string TableSpace    { get; set; }
        public int ColumnId         { get; set; }
        public int ValueLength      { get; set; }
        public bool Nullable        { get; set; }
        public Table Owner          { get; set; }
        public DataTypes ColumnType { get; set; }
        public ColumnComment Comment;

        #endregion
        #region Public Methods
        public string GetAlterSql()
        {
            try
            {
                string strSql;
                if (Modified)
                {
                    strSql = Common.NewLine + "ALTER TABLE " + this.Owner.Name + " MODIFY " + this.Name + GetTypeString() + GetDefaultString() + GetNullableString() + ";";
                }
                else
                {
                    strSql = Common.NewLine + "ALTER TABLE " + this.Owner.Name + " ADD " + this.Name + GetTypeString() + GetDefaultString() + GetNullableString() + ";";
                    if (Comment != null)
                    {
                        strSql += Common.NewLine + "--Comment";
                        strSql += Common.NewLine + "COMMENT ON COLUMN " + this.Owner.Name + "." + this.Name + " is '" + this.Comment.Comment + "';";
                    }   
                }
                return strSql;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GetSelfString()
        {
            try
            {
                return this.Name + " " + GetTypeString() + GetDefaultString() + GetNullableString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region Private Methods
        private string GetTypeString()
        {
            try
            {
                string str;
                if (this.ColumnType == DataTypes.VARCHAR2)
                {
                    return " "+this.ColumnType.ToString()+"(" + this.ValueLength + ")";
                }
                else if (this.ColumnType == DataTypes.TIMESTAMP)
                {
                    return " TIMESTAMP(6)";
                }
                else
                    return " " + this.ColumnType.ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private string GetDefaultString()
        {
            try
            {
                if (Default != null && Default.Length > 0)
                {
                    return " DEFAULT " + Default;
                }
                else
                    return "";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private string GetNullableString() 
        {
            try
            {
                if (Nullable != null && !Nullable)
                {
                    return " NOT NULL";
                }
                else if (Nullable != null && Nullable)
                    return " NULL";;
                
                    return " ";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion
    }
}
