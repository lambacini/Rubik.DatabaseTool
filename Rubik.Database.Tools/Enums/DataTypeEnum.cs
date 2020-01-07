using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.Database.Enums
{
    [Serializable]
    public enum  DataTypes
    {
        VARCHAR,
        VARCHAR2,
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
