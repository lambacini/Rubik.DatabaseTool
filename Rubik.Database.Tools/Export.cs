using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Devart.Data.Oracle;
using System.Data;
using Rubik.Database.Objects;
using System.IO;

namespace Rubik.Database.Tools
{
    public class DatabaseParameter
    {
        public string DatabaseOwner = "";
        public string ConnectionString = "";
        public string FilePath = "";
        public bool DropTable = false;
        public bool CreateTable = true;
        public bool ExportColumns = true;
        public bool ExportKeys = true;
        public bool ExportIndexes = true;
        public bool CraeteTableSpace = false;
        public bool CheckWrongDataType = false;
        public bool ExportData = false;
        public bool AutoSave = false;
        public List<string> TableName = new List<string>();

    }
    public class Export
    {
        private string SqlFile = "";
        private OracleConnection connection = new OracleConnection();
        private DatabaseParameter _exportParameters;
        private Rubik.Database.Objects.Database db;

        public Export(Objects.Database database)
        {
            db = database;
        }
        public Export(DatabaseParameter parameters)
        {
            this._exportParameters = parameters;
        }
        public void Execute() 
        {
            if (_exportParameters == null)
                throw new NullReferenceException("ExportParameters Cannot be null");

            ExportTableSql();
        }
        public void Execute(string path)
        {
            _exportParameters = new DatabaseParameter();
            _exportParameters.FilePath = path;
            _exportParameters.CreateTable = false;
           
            ExportTableSql();
        }
        
        private void ExportTableSql()
        {
            if(db == null)
            {
                db = new Objects.Database() { 
                    ConnectionString = _exportParameters.ConnectionString
                };
                db.InitializeDatabase();
                db.DatabaseToSchema();
            }
            else
            {
                ExportTableObject();   
            }
        }
        private void ExportTableObject()
        {
            string tempString = db.GetFileHeader();

            LogManager.LogWriter.Debug("Tablolar Aktarılıyor...");
            foreach (Table item in db.Tables)
            {
                tempString += item.GetAlterColumnsSql(_exportParameters.DropTable, _exportParameters.CreateTable);
                LogManager.LogWriter.Info(item.Name+" Dışa Aktarıldı...");
            }

            LogManager.LogWriter.Debug("Viewler Aktarılıyor...");
            foreach (View item in db.Views)
            {
                tempString += item.GetCreateSql();
                LogManager.LogWriter.Info(item.Name + " Dışa Aktarıldı...");
            }

            LogManager.LogWriter.Debug("Sequenceler Aktarılıyor...");
            foreach (Sequence item in db.Sequences)
            {
                tempString += item.GetCreateSql();
                LogManager.LogWriter.Info(item.Name + " Dışa Aktarıldı...");
            }

            LogManager.LogWriter.Debug("Fonksiyonlar Aktarılıyor...");
            foreach (Function item in db.Functions)
            {
                tempString += item.GetCreateSql();
                LogManager.LogWriter.Info(item.Name + " Dışa Aktarıldı...");
            }

            LogManager.LogWriter.Debug("Package Aktarılıyor...");
            foreach (Package item in db.Packages)
            {
                tempString += item.GetCreateSql();
                LogManager.LogWriter.Info(item.Name + " Dışa Aktarıldı...");
            }
            LogManager.LogWriter.Debug("Procedureler Aktarılıyor...");
            foreach (Procedure item in db.Procedures)
            {
                tempString += item.GetCreateSql();
                LogManager.LogWriter.Info(item.Name + " Dışa Aktarıldı...");
            }

            LogManager.LogWriter.Debug("Triggerlar Aktarılıyor...");
            foreach (Triger item in db.Trigers)
            {
                tempString += item.GetCreateSql();
                LogManager.LogWriter.Info(item.Name + " Dışa Aktarıldı...");
            }

            LogManager.LogWriter.Trace("Nesnelerin Serializasyon İşlemi tamamlandı Dosya kaydediliyor.");
            SaveFile(tempString);
        }
        private void SaveFile(string strSqlScript)
        {
            try
            {
                strSqlScript = strSqlScript.TrimStart();
                strSqlScript = strSqlScript.TrimEnd();
                string filePath = AppDomain.CurrentDomain.BaseDirectory+@"\Backups\"+ db.Name + "_" + db.OwnerUser + "_" +
                        DateTime.Now.Year.ToString() + "_" +
                        DateTime.Now.Month.ToString().PadLeft(2, '0') + "_" +
                        DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" +
                        DateTime.Now.Hour.ToString().PadLeft(2, '0') + "_" +
                        DateTime.Now.Minute.ToString().PadLeft(2, '0') + "_" +
                        DateTime.Now.Second.ToString().PadLeft(2, '0') + ".sql";

                LogManager.LogWriter.Trace("Aktarılacak DosyaAdı : "+filePath);
                if (_exportParameters.AutoSave)
                {
                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Backups"))
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\Backups");
                    }
                }
                else
                {
                    filePath = _exportParameters.FilePath + @"\" + db.Name + "_" + db.OwnerUser + "_" +
                        DateTime.Now.Year.ToString() + "_" +
                        DateTime.Now.Month.ToString().PadLeft(2, '0') + "_" +
                        DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" +
                        DateTime.Now.Hour.ToString().PadLeft(2, '0') + "_" +
                        DateTime.Now.Minute.ToString().PadLeft(2, '0') + "_" +
                        DateTime.Now.Second.ToString().PadLeft(2, '0') + ".sql";
                }
                FileStream fs = File.Create(filePath);
                var sw = new StreamWriter(fs);
                sw.Write(strSqlScript);
                sw.Close();
                fs.Close();
                LogManager.LogWriter.Debug("Veritabanı Yapısı Dışa Aktarıldı " + _exportParameters.FilePath);
            }
            catch (Exception ex)
            {
                LogManager.LogWriter.Error("Dosya Kaydedilemedi : "+ex.Message);
            }
        }
    }
}
