using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.Database.Enums
{
    [Serializable]
    public enum KeyTypes
    {
        Primary,
        Unique,
        Foreign,
        Unknown
    }
}
