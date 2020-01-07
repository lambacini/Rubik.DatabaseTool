using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.DataTools.Objects
{
    [Serializable]
    public class PackageBody : DatabaseObject
    {
        [field: NonSerialized] public override event DatabaseObject.ObjectProcessDelegate OnObjectProcess;
        public PackageBody()
        {
            this.ObjectType = Enums.ObjectTypeEnum.PACKAGE_BODY;
            this.LoadPriority = 7;
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
            string strSelectSql = "SELECT DBMS_METADATA.get_ddl('PACKAGE_BODY','" + this.Name + "','" + this.Owner.Name + "') from dual";

            string strTriger = this.Owner.OwnerUser.ExecuteScaler(strSelectSql);
            this.SqlStatment = strTriger;
        }

        public override string OnGetSqlString()
        {
            string strCreateViewSql = Common.NewLine + Common.NewLine + Common.NewLine + "--Create Package Body " + this.Name;
            strCreateViewSql += Common.NewLine + this.SqlStatment;
            return strCreateViewSql.TrimStart().TrimEnd(); ;
        }
    }
}
