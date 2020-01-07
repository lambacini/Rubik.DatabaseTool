using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.DataTools.Objects
{
    [Serializable]
    public class Trigger : DatabaseObject
    {
        [field: NonSerialized] public override event DatabaseObject.ObjectProcessDelegate OnObjectProcess;
        public Trigger()
        {
            this.ObjectType = Enums.ObjectTypeEnum.TRIGGER;
            this.LoadPriority = 8;
        }
        public Enums.DbEnums.TrigerType TrigerType
        {
            get;
            set;
        }
        public Enums.DbEnums.TrigerEventType TrigetEventType
        {
            get;
            set;
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
            string strSelectSql = "SELECT DBMS_METADATA.get_ddl('TRIGGER','" + this.Name + "','" + this.Owner.Name + "') from dual";

            string strTriger = this.Owner.OwnerUser.ExecuteScaler(strSelectSql);
            int index = strTriger.ToUpper().IndexOf("ALTER TRIGGER");
            strTriger = strTriger.Remove(index);
            this.SqlStatment = strTriger;
        }

        public override string OnGetSqlString()
        {
            try
            {
                string strCreateViewSql = Common.NewLine + Common.NewLine + Common.NewLine + "--Create Triger " + this.Name;
                strCreateViewSql += Common.NewLine + this.SqlStatment + "/";
                return strCreateViewSql.TrimStart().TrimEnd(); ;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
