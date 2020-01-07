using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.Database.Objects
{
    [Serializable]
    public class View
    {
        #region Properties

        public string Name { get; set; }
        public string SqlStatment { get; set; }
        public int TextLength { get; set; }
        public Database Owner { get; set; }
        #endregion

        public string GetCreateSql()
        {
            try
            {
                string strCreateViewSql = Common.NewLine + Common.NewLine + Common.NewLine + "--Create View " + this.Name;
                strCreateViewSql += Common.NewLine+"CREATE OR REPLACE VIEW " + this.Name + " AS" + Common.NewLine + this.SqlStatment.TrimEnd() + ";";
                return strCreateViewSql;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
