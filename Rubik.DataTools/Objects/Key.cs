using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik.DataTools.Objects
{
    [Serializable]
    public class Key : DatabaseObject
    {
        [field: NonSerialized] public override event DatabaseObject.ObjectProcessDelegate OnObjectProcess;

        public Key()
        {
            this.ObjectType = Enums.ObjectTypeEnum.Key;
        }
        private List<Column> _columns = new List<Column>();
        public List<Column> Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                _columns = value;
            }
        }

        public bool Enabled { get; set;  }
        public string ReferencingTable
        {
            get;
            set;
        }
        public string ReferencingColumns
        {
            get;
            set;
        }
        public Table OwnerTable
        {
            get;
            set;
        }
        public Enums.OnDeleteActionEnums OnDeleteAction
        {
            get;
            set;
        }
        public Enums.KeyTypesEnum KeyType
        {
            get;
            set;
        }

        public override void OnBuildObject()
        {
        }

        public override string OnGetSqlString()
        {
            try
            {
                string columnsName = "";

                #region Prepaire Columns Name
                foreach (Column col in Columns)
                {
                    columnsName += col.Name + ",";
                }
                if (columnsName.Substring(columnsName.Length - 1, 1) == ",")
                {
                    columnsName = columnsName.Substring(0, columnsName.Length - 1);
                }
                #endregion

                string strSql = "";
                if (KeyType == Enums.KeyTypesEnum.Unique)
                {
                    strSql = "ALTER TABLE " + OwnerTable.Name + " ADD CONSTRAINT " + this.Name + " " + KeyType.ToString() + " (" + columnsName + ")";
                }
                else if (KeyType == Enums.KeyTypesEnum.Foreign)
                {
                    strSql = "ALTER TABLE " + OwnerTable.Name + " ADD CONSTRAINT " + this.Name + " " + KeyType.ToString() + " key (" + columnsName + ") REFERENCES " + this.ReferencingTable + " (" + this.ReferencingColumns + ")";
                }
                else
                {
                    strSql = "ALTER TABLE " + OwnerTable.Name + " ADD CONSTRAINT " + this.Name + " " + KeyType.ToString() + " key (" + columnsName + ")";
                }

                if (!Enabled)
                {
                    strSql += " DISABLE;";
                }
                return strSql + ";";
            }
            catch
            {
                throw;
            }
        }
    }
}
