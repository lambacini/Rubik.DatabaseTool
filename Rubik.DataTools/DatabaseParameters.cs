using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.DataTools
{
    public class DatabaseParameters
    {
        public string DatabaseOwner = "";
        public string ConnectionString = "";
        public string FilePath = "";
        public bool DropTable = false;
        public bool DropObjects = false;
        public bool AutoChangeSchema = true;
        public bool CreateTable = true;
        public bool ExportColumns = true;
        public bool ExportKeys = true;
        public bool ExportIndexes = true;
        public bool CraeteTableSpace = false;
        public bool CheckWrongDataType = false;
        public bool ExportData = false;
        public bool AutoSave = false;
        public bool SeparateSchemas = false;
        public bool CreateUser = false;
        public List<string> TableName = new List<string>();
        public List<string> SelectedUsers = new List<string>();
    }
}
