using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.DataTools.Enums
{
    public class DbEnums
    {
        [Serializable]
        public enum TrigerType
        {
            BeforeEachRow,
            AfterEachRow,
            Insteadof
        }

        [Serializable]
        public enum TrigerEventType
        {
            Insert,
            Update,
            Delete
        }



    }

    [Serializable]
    public enum DataTypeEnums
    {
        VARCHAR,
        VARCHAR2,
        NVARCHAR2,
        NUMBER,
        BLOB,
        CLOB,
        DATE,
        CHAR,
        TIMESTAMP,
        RAW,
        UNKNOWN
    }
}
