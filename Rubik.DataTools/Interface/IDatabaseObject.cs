using Rubik.DataTools.Enums;
using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik.DataTools.Interface
{
    public interface IDatabaseObject 
    {
        bool IsSelected { get; set; }
        bool IsModified { get; set; }
        bool IsLoaded { get; set; }
        int CreatePriority { get; set; }
        ObjectTypeEnum ObjectType { get; }
        string Name { get; set; }
        Schema Owner { get; set; }
        void BuildObject();
        string GetSqlString();
    }
}
