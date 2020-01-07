using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.DataTools.Objects
{
    [Serializable]
    public class Package : DatabaseObject
    {
        [field: NonSerialized] public override event DatabaseObject.ObjectProcessDelegate OnObjectProcess;

        public Package()
        {
            this.ObjectType = Enums.ObjectTypeEnum.PACKAGE;
            this.LoadPriority = 4;
        }

        public string SqlStatment
        {
            get;
            set;
        }

        public int TextLength
        {
            get;
            set;
        }

        public override void OnBuildObject()
        {
            string strSelectSql = "SELECT DBMS_METADATA.get_ddl('PACKAGE','" + this.Name + "','" + this.Owner.Name + "') from dual";

            string strTriger = this.Owner.OwnerUser.ExecuteScaler(strSelectSql);
            this.SqlStatment = strTriger;
        }

        public override string OnGetSqlString()
        {
            string strCreateViewSql = Common.NewLine + Common.NewLine + Common.NewLine + "--Create Package " + this.Name;
            strCreateViewSql += Common.NewLine + this.SqlStatment;
            return strCreateViewSql.TrimStart().TrimEnd(); ;

        }
    }
}
