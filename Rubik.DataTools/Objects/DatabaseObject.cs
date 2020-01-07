using Rubik.DataTools.Interface;
using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.DataTools.Objects
{
    [Serializable]
    public abstract class DatabaseObject : IDatabaseObject
    {
        public delegate void ObjectProcessDelegate(IDatabaseObject sender, IDatabaseObject obj);
        [field: NonSerialized]
        public abstract event ObjectProcessDelegate OnObjectProcess;

        private bool _isSelected = true;
        private bool _isModified = false;
        public bool IsLoaded
        {
            get;
            set;
        }
        public int LoadPriority = 999;
        private int _createPriority = 99999;

        public Enums.ObjectTypeEnum ObjectType
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public Schema Owner
        {
            get;
            set;
        }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
            }
        }
        public bool IsModified
        {
            get
            {
                return _isModified;
            }
            set
            {
                _isModified = value;
            }
        }
        

        public void BuildObject()
        {
            OnBuildObject();
            IsLoaded = true;
        }

        public string DropStatement()
        {
            return "DROP " + this.ObjectType.ToString() +" "+ this.Name+";";
        }

        public abstract void OnBuildObject();

        public string GetSqlString()
        {
            return OnGetSqlString();
        }
        public abstract string OnGetSqlString();



        public int CreatePriority
        {
            get
            {
                return _createPriority;
            }
            set
            {
                _createPriority = value;
            }
        }
    }
}
