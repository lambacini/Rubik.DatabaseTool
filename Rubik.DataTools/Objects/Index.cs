using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik.DataTools.Objects
{
    [Serializable]
    public class Index : DatabaseObject
    {
        public Index()
        {
            this.ObjectType = Enums.ObjectTypeEnum.INDEX;
            Columns = new System.Collections.ObjectModel.ObservableCollection<string>();
            this.LoadPriority = 9998;
        }
        public Enums.IndexTypeEnums IndexType
        {
            get;
            set;
        }

        public string Table
        {
            get;
            set;
        }

        public System.Collections.ObjectModel.ObservableCollection<string> Columns
        {
            get;
            set;
        }

        public bool Compress
        {
            get;
            set;
        }

        public bool Reverse
        {
            get;
            set;
        }

        public string ColumnsString
        {
            get
            {
                if(Columns == null || Columns.Count == 0)
                {
                    return "";
                }

                var str = "";
                foreach (var col in Columns)
                {
                    str += col + ",";
                }

                str = str.Substring(0, str.Length - 1);

                return str;
            }
        }

        public override void OnBuildObject()
        {
            string sqlString = "SELECT I.TABLE_NAME,I.INDEX_NAME,I.INDEX_TYPE,IC.COLUMN_NAME,IC.COLUMN_POSITION FROM DBA_INDEXES I\n" +
            "INNER JOIN DBA_IND_COLUMNS IC ON I.index_name = IC.INDEX_NAME AND I.owner = IC.INDEX_OWNER\n" +
            "AND I.OWNER = '" + this.Owner.Name + "'\n" +
            "AND I.INDEX_NAME = '" + this.Name + "' ORDER BY IC.COLUMN_POSITION ASC";

            DataTable dt = this.Owner.OwnerUser.FillDataTable(sqlString);

            foreach (DataRow row in dt.Rows)
            {
                Table = row["TABLE_NAME"].ToString();
                Columns.Add(row["COLUMN_NAME"].ToString());
            }
        }

        public override string OnGetSqlString()
        {
            return "";
        }

        [field: NonSerialized] public override event DatabaseObject.ObjectProcessDelegate OnObjectProcess;
    }
}
