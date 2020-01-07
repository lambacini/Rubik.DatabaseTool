using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Devart.Data.Oracle;

namespace Rubik.Database.Objects
{

    [Serializable]
    public enum TrigerType
    { 
        BeforeEachRow,
        AfterEachRow,
        Insteadof
    }

    [Serializable]
    public enum TrigerEventType
    {
        Insert,
        Update,
        Delete
    }

    [Serializable]
    public class Triger
    {
        #region Properties

        public string Name { get; set; }
        public string SqlStatment { get; set; }
        public int TextLength { get; set; }
        public TrigerType TrigerType { get; set; }
        public TrigerEventType TrigetEventType { get; set; }
        public Database Owner { get; set; }
        #endregion

        public void BuildSql()
        {
            string strSelectSql = "SELECT DBMS_METADATA.get_ddl('TRIGGER','" + this.Name + "','" + this.Owner.Name + "') from dual";
            OracleCommand cmd = this.Owner.GetCommand();
            cmd.CommandText = strSelectSql;
            string strTriger = cmd.ExecuteScalar().ToString();
            int index = strTriger.ToUpper().IndexOf("ALTER TRIGGER");
            strTriger = strTriger.Remove(index);
            this.SqlStatment = strTriger;
        }
        public string GetCreateSql()
        {
            try
            {
                string strCreateViewSql = Common.NewLine + Common.NewLine + Common.NewLine + "--Create Triger " + this.Name;
                strCreateViewSql += Common.NewLine + this.SqlStatment + "/";
                return strCreateViewSql;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
