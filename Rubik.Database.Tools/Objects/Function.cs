using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Devart.Data.Oracle;

namespace Rubik.Database.Objects
{
    [Serializable]
    public class Function
    {
        #region Properties

        public string Name { get; set; }
        public string SqlStatment { get; set; }
        public int TextLength { get; set; }
        public Database Owner { get; set; }
        #endregion
        public void BuildSql()
        {
            string strSelectSql = "SELECT DBMS_METADATA.get_ddl('FUNCTION','"+this.Name+"','"+this.Owner.Name+"') from dual";
            OracleCommand cmd = this.Owner.GetCommand();
            cmd.CommandText = strSelectSql;
            this.SqlStatment = cmd.ExecuteScalar().ToString();
            
        }
        public string GetCreateSql()
        {
            try
            {
                string strCreateViewSql = Common.NewLine + Common.NewLine + Common.NewLine + "--Create Function " + this.Name;
                strCreateViewSql += Common.NewLine + this.SqlStatment + "/" ;
                return strCreateViewSql;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
