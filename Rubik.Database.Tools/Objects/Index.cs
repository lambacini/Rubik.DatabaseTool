using System;
using System.Collections.Generic;

namespace Rubik.Database.Objects
{
    [Serializable]
    public enum IndexType
    { 
        Normal,
        Unique,
        Bitmap
    }
    [Serializable]
    public abstract class Index
    {
        public string Owner { get; set; }
        public string Name { get; set; }
        public IndexType indexType { get; set; }
        public List<TableColumn> Columns = new List<TableColumn>();
        public bool Compress { get; set; }
        public bool Reverse { get; set; }
    }
}
