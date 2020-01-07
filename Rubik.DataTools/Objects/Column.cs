using Rubik.DataTools.Enums;
using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik.DataTools.Objects
{
    [Serializable]
    public class Column : DatabaseObject
    {
        [field: NonSerialized] public override event DatabaseObject.ObjectProcessDelegate OnObjectProcess;

        #region Properties

        public Table Owner { get; set; }
        public int ColumnId { get; set; }
        public int ValueLength { get; set; }
        public DataTypeEnums DataType { get; set; }
        public string Default { get; set; }
        public bool Nullable { get; set; }


        #endregion
        #region Constructors

        public Column()
        {
            this.ObjectType = ObjectTypeEnum.Column;
        }
        public Column(Table owner)
        {
            Owner = owner;
            this.ObjectType = ObjectTypeEnum.Column;
        }

        #endregion
        #region  Public Methods

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
                if (this.DataType == DataTypeEnums.VARCHAR2)
                {
                    return " " + this.DataType.ToString() + "(" + this.ValueLength + ")";
                }
                else if (this.DataType == DataTypeEnums.TIMESTAMP)
                {
                    return " TIMESTAMP(6)";
                }
                else
                    return " " + this.DataType.ToString();
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
                    return " NULL"; ;

                return " ";
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        public override void OnBuildObject()
        {
           
        }

        public override string OnGetSqlString()
        {
            try
            {
                string strSql;
                if (IsModified)
                {
                    strSql = "ALTER TABLE " + this.Owner.Name + " MODIFY " + this.Name + GetTypeString() + GetDefaultString() + GetNullableString() + ";";
                }
                else
                {
                    strSql = "ALTER TABLE " + this.Owner.Name + " ADD " + this.Name + GetTypeString() + GetDefaultString() + GetNullableString() + ";";
                    //if (Comment != null)
                    //{
                    //    strSql += Common.NewLine + "--Comment";
                    //    strSql += Common.NewLine + "COMMENT ON COLUMN " + this.Owner.Name + "." + this.Name + " is '" + this.Comment.Comment + "';";
                    //}
                }
                return strSql;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
