using System;
using System.Collections.Generic;
using System.Linq;
using Devart.Data.Oracle;
using System.Data;
using System.Xml.Serialization;

namespace Rubik.Database.Objects
{
    [Serializable]
    [XmlRootAttribute("Database", Namespace = "", IsNullable = false)]
    public class Database
    {
        #region Events
        public delegate void ObjectCreatedDelegete(string strInfo);
        public event ObjectCreatedDelegete OnObjectCreated;

        #endregion
        #region Variables
        
        public string OwnerUser = "";
        public string Name {
            get
            {
                if (this.Connection == null)
                    return "UNKNOWN";
                else
                    return this.Connection.UserId;
            }
        }
        public string ClientVersion
        {
            get
            {
                if (this.Connection != null)
                    return Connection.ClientVersion;
                else
                    return "Unknown";
            }
        }
        public string DatabaseVersion
        {
            get
            {
                if (Connection != null)
                    return Connection.ServerVersion.Replace(Convert.ToChar(10), ' ');
                else
                    return "Unknown";
            }
        }
        public string ConnectionType {
            get {
                if (Connection == null)
                    return "Schema";
                else
                    return Connection.ConnectMode.ToString();
            }
        }

        [NonSerialized]
        [XmlIgnore()] 
        public string ConnectionString = String.Empty;

        [NonSerialized]
        [XmlIgnore()] 
        public OracleConnection Connection = null;

        public List<Table> Tables = new List<Table>();
        public List<View> Views = new List<View>();
        public List<Function> Functions = new List<Function>();
        public List<Triger> Trigers = new List<Triger>();
        public List<Package> Packages = new List<Package>();
        public List<Procedure> Procedures = new List<Procedure>();
        public List<Sequence> Sequences = new List<Sequence>();

        #endregion
        #region Const
        public Database()
        {

        }
        #endregion
        #region Public Methods
        public void InitializeDatabase()
        {
            try
            {
                Connection = new OracleConnection(ConnectionString);
                Connection.Open();
                LogManager.LogWriter.Debug("> Veritabanı Bağlantısı Açıldı");
            }
            catch (Exception ex)
            {
                LogManager.LogWriter.Error(ex.Message);
            }
        }
        public void DatabaseToSchema()
        {
            LoadTables();
            LoadViews();
            LoadProcedure();
            LoadSequences();
            LoadTrigers();
            LogManager.LogWriter.Trace("Database To Schema Complated");
        }
        public OracleCommand GetCommand()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = this.Connection;
                return cmd;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public OracleDataAdapter GetDataAdapter()
        {
            try
            {
                OracleDataAdapter adp = new OracleDataAdapter();
                adp.SelectCommand = GetCommand();
                return adp;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void FillDataTable(ref DataTable dtTable,string strSelectSql)
        {
            try
            {
                OracleDataAdapter adp = GetDataAdapter();
                adp.SelectCommand.CommandText = strSelectSql;
                    adp.Fill(dtTable);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region Private Methods

        private void FireEvent(string info)
        {
            if (OnObjectCreated != null)
                OnObjectCreated(info);
        }
        private void LoadTables()
        {
            Tables.Clear();
            string strSelectTable = "SELECT TABLE_NAME,TABLESPACE_NAME FROM USER_ALL_TABLES ORDER BY TABLE_NAME ASC";
            DataTable dt = new DataTable();

            OracleCommand cmd = new OracleCommand(strSelectTable);
            cmd.Connection = this.Connection;

            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            adapter.Fill(dt);
            LogManager.LogWriter.Debug(dt.Rows.Count.ToString() + " Tablo Bulundu");

            foreach (DataRow item in dt.Rows)
            {
                string TableName = item[0].ToString();
                Table tbl = new Table();
                tbl.Owner = this;
                tbl.Name = TableName;
                tbl.FillDbSchema();
                this.Tables.Add(tbl);
                LogManager.LogWriter.Info("Tablo Yapısı Okundu : " + tbl.Name);
                FireEvent("Table Generated : "+TableName);
            }
        }
        private void LoadViews()
        {
            Views.Clear();
            string strSelectView = "SELECT VIEW_NAME,TEXT,TEXT_LENGTH FROM USER_VIEWS";
            DataTable dtViews = new DataTable();
            this.FillDataTable(ref dtViews, strSelectView);
            LogManager.LogWriter.Debug(dtViews.Rows.Count.ToString() + " View Bulundu");

            foreach (DataRow row in dtViews.Rows)
            {
                View view = new View()
                {
                    Name = row["VIEW_NAME"].ToString(),
                    SqlStatment = row["TEXT"].ToString(),
                    TextLength = int.Parse(row["TEXT_LENGTH"].ToString())

                };
                LogManager.LogWriter.Info("View Yapısı Okundu : " + view.Name);
                FireEvent("View Generated : " + view.Name);
                this.Views.Add(view);
            }

        }
        private void LoadProcedure()
        {
            string strSelectSql = "SELECT DISTINCT OBJECT_NAME,OBJECT_TYPE FROM USER_PROCEDURES";

            DataTable dtProcedure = new DataTable();
            this.FillDataTable(ref dtProcedure,strSelectSql);
            LogManager.LogWriter.Debug(dtProcedure.Rows.Count.ToString() + " Procedure Bulundu");
            foreach (DataRow dataRow in dtProcedure.Rows)
            {
                    if(dataRow["OBJECT_TYPE"].ToString() == "FUNCTION")
                    {
                        Function func = new Function()
                                            {
                                                Name = dataRow["OBJECT_NAME"].ToString()
                                            };
                        func.Owner = this;
                        func.BuildSql();
                        this.Functions.Add(func);

                        LogManager.LogWriter.Info("Function Yapısı Okundu : " + func.Name);
                        FireEvent("Function Created : "+func.Name);
                    }
                    else if (dataRow["OBJECT_TYPE"].ToString() == "TRIGGER")
                    {
                        try
                        {
                            Triger trg = new Triger()
                            {
                                Name = dataRow["OBJECT_NAME"].ToString()
                            };
                            trg.Owner = this;
                            trg.BuildSql();
                            this.Trigers.Add(trg);
                            LogManager.LogWriter.Info("Triger Yapısı Okundu : " + trg.Name);
                            FireEvent("Triger Created : " + trg.Name);
                        }
                        catch (Exception ex)
                        {
                            LogManager.LogWriter.Error("Triger Oluşturulamadı !: " + ex.Message);
                        }
                    }
                    else if (dataRow["OBJECT_TYPE"].ToString() == "PACKAGE")
                    {
                        Package pck = new Package()
                        {
                            Name = dataRow["OBJECT_NAME"].ToString()
                        };
                        pck.Owner = this;
                        pck.BuildSql();
                        this.Packages.Add(pck);

                        LogManager.LogWriter.Info("PACKAGE Yapısı Okundu : " + pck.Name);

                        FireEvent("Triger Package : " + pck.Name);
                    }
                    else if (dataRow["OBJECT_TYPE"].ToString() == "PROCEDURE")
                    {
                        Procedure proc = new Procedure()
                        {
                            Name = dataRow["OBJECT_NAME"].ToString()
                        };
                        proc.Owner = this;
                        proc.BuildSql();
                        this.Procedures.Add(proc);
                        LogManager.LogWriter.Info("PROCEDURE Yapısı Okundu : " + proc.Name);
                        FireEvent("Triger Procedure : " + proc.Name);
                    }
            }
        }
        private void LoadSequences()
        {
            Sequences.Clear();

            string strSelectView = "SELECT * FROM USER_SEQUENCES T";
            DataTable dtSeqeucences = new DataTable();
            this.FillDataTable(ref dtSeqeucences, strSelectView);
            LogManager.LogWriter.Debug(dtSeqeucences.Rows.Count.ToString() + " Sequence Bulundu...");

            foreach (DataRow row in dtSeqeucences.Rows)
            {
                Sequence seq = new Sequence()
                                   {
                                       Name = row["SEQUENCE_NAME"].ToString(),
                                       MinValue = row["MIN_VALUE"].ToString(),
                                       MaxValue = row["MAX_VALUE"].ToString(),
                                       IncrementBy = row["INCREMENT_BY"].ToString(),
                                       Cycle = (row["CYCLE_FLAG"].ToString() == "Y") ? true:false,
                                       Order = (row["ORDER_FLAG"].ToString() == "Y") ? true : false,
                                       CacheSize = row["CACHE_SIZE"].ToString()
                                   };
                Sequences.Add(seq);
                LogManager.LogWriter.Info("Sequence Yapısı Okundu : " + seq.Name);
                FireEvent("Sequence Generated : " + seq.Name);
            }

        }
        private void LoadTrigers()
        {
            Trigers.Clear();

            string strSelectTrigers = "SELECT * FROM USER_TRIGGERS T";
            DataTable dtTrigers = new DataTable();
            this.FillDataTable(ref dtTrigers, strSelectTrigers);
            LogManager.LogWriter.Debug(dtTrigers.Rows.Count.ToString() + " Trigger Bulundu...");
            foreach (DataRow row in dtTrigers.Rows)
            {
                Triger trg = new Triger()
                {
                    Name = row["TRIGGER_NAME"].ToString(),
                    Owner = this
                };
                Trigers.Add(trg);
                LogManager.LogWriter.Info("Triger Yapısı Okundu : " + trg.Name);
                FireEvent("Triger Generated : " + trg.Name);
            }
        }
        public string GetFileHeader()
        {
            string strHeader =
                                "----------------------------------------------------------------\n" +
                                "--Date Of Creation = "+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString()+"\n" +
                                "--User = "+this.Name+"\n" +
                                "--Client Version = "+this.ClientVersion+"\n" +
                                "--Database Version = " + this.DatabaseVersion + "\n" +
                                "----------------------------------------------------------------\n\n";

            return strHeader;
        }

        #endregion
    }
}
