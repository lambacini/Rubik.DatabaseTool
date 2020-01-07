using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik.DataTools.Enums
{
    [Serializable]
    public enum  ObjectTypeEnum
    {
        FUNCTION,
        INDEX,
        LOB,
        PACKAGE,
        PACKAGE_BODY,
        PROCEDURE,
        SEQUENCE,
        TABLE,
        TRIGGER,
        TYPE,
        VIEW,
        Column,
        Database,
        Schema,
        Key
    }
}
