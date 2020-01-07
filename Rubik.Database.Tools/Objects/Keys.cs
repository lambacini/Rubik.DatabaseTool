using System;
using System.Collections.Generic;
using Rubik.Database.Enums;

namespace Rubik.Database.Objects
{
    [Serializable]
    public enum OnDelete
    { 
        NoAction,
        Cascade,
        SetNull
    }

    [Serializable]
    public class Keys
    {
        #region Variables
        public List<TableColumn> Columns = new List<TableColumn>();
        #endregion
        #region Properties
        
        public bool Enabled { get; set; }

        public string Name { get; set; }
        public string ReferencingTable { get; set; }
        public string ReferencingColumns { get; set; }

        public OnDelete OnDelete { get; set; }
        public Table Owner { get; set; }
        public KeyTypes KeyType { get; set; }

        #endregion
        #region Constractoins
        public Keys() { }
        public Keys(Table OwnerTable)
        {
            Owner = OwnerTable;
        }
        #endregion
        #region Public Methods
        public string GetAlterSql()
        {
            try
            {
                string columnsName = "";

                #region Prepaire Columns Name
                foreach (TableColumn col in Columns)
                {
                    columnsName += col.Name + ",";
                }
                if (columnsName.Substring(columnsName.Length - 1, 1) == ",")
                {
                    columnsName = columnsName.Substring(0, columnsName.Length - 1);
                }
                #endregion

                string strSql = "";
                if (KeyType == KeyTypes.Unique)
                {
                    strSql = "ALTER TABLE " + Owner.Name + " ADD CONSTRAINT " + this.Name + " " + KeyType.ToString() + " (" + columnsName + ")";
                }
                else if (KeyType == KeyTypes.Foreign)
                {
                    strSql = "ALTER TABLE " + Owner.Name + " ADD CONSTRAINT " + this.Name + " " + KeyType.ToString() + " key (" + columnsName + ") REFERENCES "+this.ReferencingTable+" ("+this.ReferencingColumns+")";
                }
                else
                {
                    strSql = "ALTER TABLE " + Owner.Name + " ADD CONSTRAINT " + this.Name + " " + KeyType.ToString() + " key (" + columnsName + ")";
                }

                if (!Enabled)
                {
                    strSql += " DISABLE;";
                }
                return strSql+";";
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
