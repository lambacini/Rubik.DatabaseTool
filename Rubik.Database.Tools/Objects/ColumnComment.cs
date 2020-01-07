using System;

namespace Rubik.Database.Objects
{
    [Serializable]
    public class ColumnComment
    {
        public TableColumn Column { get;set;}
        public string Comment { get; set; }
    }
}
