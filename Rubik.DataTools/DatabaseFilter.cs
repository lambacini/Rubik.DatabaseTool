using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik.DataTools
{
    [Serializable]
    public class DatabaseFilter
    {
        private List<string> _databaseUsers = new List<string>();
        private List<string> _tables = new List<string>();
        private List<string> _functions = new List<string>();
        private List<string> _views= new List<string>();
        private List<string> _procedures = new List<string>();
        private List<string> _packakges = new List<string>();
        private List<string> _sequences = new List<string>();

        public bool IncludeTables { get; set; }
        public bool IncludeFunctions { get; set; }
        public bool IncludeViews { get; set; }
        public bool IncludeProcedures { get; set; }
        public bool IncludePackages { get; set; }
        public bool IncludeSequences { get; set; }

        public DatabaseFilter()
        {
            IncludeTables = true;
            IncludeFunctions = true;
            IncludeViews = true;
            IncludeProcedures = true;
            IncludePackages = true;
            IncludeSequences = true;
        }

        public List<string> DatabaseUsers
        {
            get
            {
                return _databaseUsers;
            }
        }

        public void FilterTable(string tableName)
        {
            if (!_tables.Contains(tableName))
                _tables.Add(tableName);
        }

        public void FilterViews(string viewName)
        {
            if (!_views.Contains(viewName))
                _views.Add(viewName);
        }
    }
}
