using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Rubik.DataTools.Objects
{
    [Serializable]
    public class View : DatabaseObject
    {
        [field: NonSerialized] public override event DatabaseObject.ObjectProcessDelegate OnObjectProcess;
        public View()
        {
            this.ObjectType = Enums.ObjectTypeEnum.VIEW;
            this.LoadPriority = 3;
        }

        public int TextLength
        {
            get;
            set;
        }
        public string SqlStatment { get; set; }

        public override void OnBuildObject()
        {
            string strSelectView = "SELECT VIEW_NAME,TEXT,TEXT_LENGTH FROM USER_VIEWS where VIEW_NAME =:VIEW_NAME";
            var param = new Devart.Data.Oracle.OracleParameter("VIEW_NAME", this.Name);

            DataTable dt = this.Owner.OwnerUser.FillDataTable(strSelectView, new DbParameter[]{
                param
            });

            this.SqlStatment = dt.Rows[0]["TEXT"].ToString();
            this.TextLength = int.Parse(dt.Rows[0]["TEXT_LENGTH"].ToString());
        }

        public override string OnGetSqlString()
        {
            try
            {
                string strCreateViewSql = Common.NewLine + Common.NewLine + Common.NewLine + "--Create View " + this.Name;
                strCreateViewSql += Common.NewLine + "CREATE OR REPLACE VIEW " + this.Name + " AS" + Common.NewLine + this.SqlStatment.TrimEnd() + ";";
                return strCreateViewSql.TrimStart().TrimEnd(); ;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
