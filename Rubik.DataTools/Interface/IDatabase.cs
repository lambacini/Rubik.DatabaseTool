using Rubik.DataTools.Enums;
using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik.DataTools.Interface
{

    public interface IDatabase : IDatabaseObject
    {
        ObservableCollection<Schema> Users { get; set; }
        DatabaseTypeEnums DatabaseType { get; set; }
        string DatabaseVersion { get; set; }

        DataTable FillDataTable(string strSql);
        DataTable FillDataTable(string strSql, DbParameter[] parameters);
        string ExecuteScaler(string strSql);
    }
}
