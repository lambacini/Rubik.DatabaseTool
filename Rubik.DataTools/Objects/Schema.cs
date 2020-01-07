using Devart.Data.Oracle;
using Rubik.DataTools.Enums;
using Rubik.DataTools.Interface;
using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik.DataTools.Objects
{
    [Serializable]
    public class Schema : DatabaseObject
    {
        public Schema()
        {
            base.ObjectType = ObjectTypeEnum.Schema;
        }
        [field: NonSerialized] public override event DatabaseObject.ObjectProcessDelegate OnObjectProcess;
        private List<IDatabaseObject> _schemaObjects;
        public List<IDatabaseObject> SchemaObjects
        {
            get{
                if (_schemaObjects == null)
                    _schemaObjects = new List<IDatabaseObject>();
                return _schemaObjects;
            }
            set{
                _schemaObjects = value;
            }
        }

        public IDatabase OwnerUser
        {
            get;
            set;
        }

        public override void OnBuildObject()
        {
            string strSql = @"SELECT O.OWNER,O.OBJECT_NAME,REPLACE(O.OBJECT_TYPE,' ','_') AS OBJECT_TYPE FROM DBA_OBJECTS O
                                WHERE O.OWNER = '{0}'
                                ORDER BY OBJECT_NAME, o.OBJECT_TYPE ASC";

            DataTable userObjects = OwnerUser.FillDataTable(String.Format(strSql, this.Name));
            if (userObjects != null && userObjects.Rows.Count > 0)
            {
                foreach (DataRow item in userObjects.Rows)
                {
                    try
                    {
                        ObjectTypeEnum objectType = (ObjectTypeEnum)Enum.Parse(typeof(ObjectTypeEnum), item["OBJECT_TYPE"].ToString(), true);
                        var dbObject = DatabaseObjectFactory.Instance.CreateObject(objectType, item["OBJECT_NAME"].ToString().Replace(" ", ""), this);
                        if (dbObject != null)
                        {
                            this.SchemaObjects.Add(dbObject);
                            if (OnObjectProcess != null)
                                OnObjectProcess(this, dbObject);
                        }
                    }
                    catch (Exception ex)
                    {
                        //throw;
                    }
                }
            }

            this.SchemaObjects =  SortObjects();
        }

        public override string OnGetSqlString()
        {
            return "";// throw new NotImplementedException();
        }

        public List<IDatabaseObject> SortObjects()
        {
            var tables = this.SchemaObjects.Where(p => p.ObjectType == ObjectTypeEnum.TABLE).ToList();

            foreach (var dbObject in tables)
            {
                foreach (string item in (dbObject as Table).ReferencedTables)
                {
                    var reference = this.SchemaObjects.FirstOrDefault(p => p.ObjectType == ObjectTypeEnum.TABLE && p.Name == item);
                    var refTable = reference as Table;
                    if (refTable != null)
                    {
                        refTable.CreatePriority--;
                    }
                }
            }

            return this.SchemaObjects.OrderBy(p => p.CreatePriority).ToList();
        }
    }
}
