using Rubik.DataTools.Enums;
using Rubik.DataTools.Interface;
using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.DataTools
{
    public class DatabaseObjectFactory
    {
        private static object _lockObject = new object();
        private static DatabaseObjectFactory _instance;
        public static DatabaseObjectFactory Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_lockObject)
                    {
                        _instance = new DatabaseObjectFactory();
                    }
                }
                return _instance;
            }
        }

        private Dictionary<ObjectTypeEnum, Type> _objectTypes = new Dictionary<ObjectTypeEnum, Type>();

        private  void InitObjects()
        {
            _objectTypes.Add(ObjectTypeEnum.TABLE,typeof(Table));
            _objectTypes.Add(ObjectTypeEnum.INDEX, typeof(Index));
            _objectTypes.Add(ObjectTypeEnum.SEQUENCE, typeof(Sequence));
            _objectTypes.Add(ObjectTypeEnum.VIEW, typeof(View));
            _objectTypes.Add(ObjectTypeEnum.TRIGGER, typeof(Trigger));
            _objectTypes.Add(ObjectTypeEnum.FUNCTION, typeof(Function));
            _objectTypes.Add(ObjectTypeEnum.PROCEDURE, typeof(Procedure));
            _objectTypes.Add(ObjectTypeEnum.PACKAGE, typeof(Package));
            _objectTypes.Add(ObjectTypeEnum.PACKAGE_BODY, typeof(PackageBody));
        }

        public DatabaseObjectFactory()
        {
            InitObjects();
        }

        public IDatabaseObject CreateObject(ObjectTypeEnum typeEnum,string Name,Schema schemaOwner)
        {
            var item =  _objectTypes.FirstOrDefault(p => p.Key == typeEnum);

            if(item.Value != null)
            {
                IDatabaseObject dbObject = GetInstance(item.Value);
                dbObject.Name = Name;
                dbObject.Owner = schemaOwner;
                dbObject.BuildObject();

                return dbObject;
            }
            return null;
        }

        public IDatabaseObject GetInstance(Type type)
        {
            var obj  = (IDatabaseObject)Activator.CreateInstance(type);;
            return obj;
        }
    }
}
