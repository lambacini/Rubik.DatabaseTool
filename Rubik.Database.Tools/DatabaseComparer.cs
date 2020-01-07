using System.IO;
using Rubik.Database.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using Rubik.Database.Objects;

namespace Rubik.Database
{
    public class ComparerParameters
    {
        private string _scriptSavePath = "";
        /// <summary>
        /// Karşılaştırılacak veritabanı
        /// </summary>
        public Objects.Database TargetDatabase { get; set; }
        /// <summary>
        /// Şablon veritabanı
        /// </summary>
        public Objects.Database SchemaDatabase { get; set; }
        /// <summary>
        /// Targetdatabase set edilmemişse bu parametreye göre yeniden oluşturulur.
        /// </summary>
        public DatabaseParameter TargetParameters { get; set; }
        /// <summary>
        /// SchmaDatabase Set edilmemiş ise bu parametre set edilerek yüklenir.
        /// </summary>
        public string SchemaPath { get; set; }
        /// <summary>
        /// Schema ile ile hedef veritabanı aynı değil ise farklar ScriptSavePath e otomatik olarak kaydedilir.
        /// </summary>
        public bool AutoSaveDifference { get; set; }
        /// <summary>
        /// değişken tanımlanmamış ise var sayılan olarak uygulamanın çalıştığı dizine kaydedilir.
        /// </summary>
        public string ScriptSavePath
        {
            get
            {
                if (String.IsNullOrEmpty(_scriptSavePath))
                {
                    string scriptDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory , "SqlScripts");
                    if (!Directory.Exists(scriptDir))
                        Directory.CreateDirectory(scriptDir);

                    return scriptDir;
                }
                else
                {
                    return _scriptSavePath;
                }
            }
            set { _scriptSavePath = value; }
        }
    }
    public class DatabaseComparer
    {
        private ComparerParameters _parameters;
        private Objects.Database _differents;
        private Objects.Database _schemaDatabase;
        private Objects.Database _targetDatabase;

        public Objects.Database Difference
        {
            get { return _differents; }
        }

        public bool IsDifferent(ComparerParameters parameters)
        {
            CompareToSchema(parameters);
            if (_differents != null)
            {
                if (_differents.Tables.Count > 0 || _differents.Sequences.Count > 0 || _differents.Trigers.Count > 0 ||
                    _differents.Views.Count > 0 || _differents.Functions.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;   
            }
        }
        public Objects.Database CompareToSchema(ComparerParameters parameters)
        {

            try
            {
                _parameters = parameters;

                if (parameters.SchemaDatabase == null)
                    _schemaDatabase = SerializeFileToDatabase(parameters.SchemaPath);

                if (parameters.TargetDatabase == null)
                    _targetDatabase = GenerateDatabase(parameters.TargetParameters);


                _differents = CompareDatabase();

                if (parameters.AutoSaveDifference)
                    SaveScript(parameters.ScriptSavePath);
                return _differents;
            }
            catch (Exception ex)
            {
                LogManager.LogWriter.Error("Database Compare failed."+ex.Message);
                return null;
            }
        }

        public void SaveScript()
        {
            try
            {
                SaveScript(_parameters.ScriptSavePath);
            }
            catch (Exception ex)
            {
                LogManager.LogWriter.Error(ex.Message);
            }
        }

        public void SaveScript(string path)
        {
            try
            {
                Export export = new Export(_differents);
                export.Execute(path);
            }
            catch (Exception ex)
            {
                LogManager.LogWriter.Error(ex.Message);
            }
        }

        private Objects.Database SerializeFileToDatabase(string filePath)
        {
            try
            {
                var fs = new FileStream(filePath,FileMode.Open,FileAccess.Read);
                var formatter = new BinaryFormatter();
                var obj = formatter.Deserialize(fs);
                if (obj.GetType() == typeof (Objects.Database))
                {
                    LogManager.LogWriter.Trace("Serialization Complate : "+filePath);
                    return (Objects.Database)obj;   
                }
                else
                    throw new OperationCanceledException("Serialization Failed.");
            }
            catch (Exception ex)
            {
                LogManager.LogWriter.Error("Serialization Error.. ! " + ex.Message);
                return null;
            }
        }
        private Objects.Database CompareDatabase()
        {
            var result = CompareTables(_schemaDatabase,_targetDatabase);
            CompareSqe(_schemaDatabase, _targetDatabase, result);
            CompareTrigger(_schemaDatabase, _targetDatabase, result);
            CompareView(_schemaDatabase, _targetDatabase, result);
            CompareFunctions(_schemaDatabase, _targetDatabase, result);

            return result;
        }

        private void CompareSqe(Objects.Database schema, Objects.Database target,Objects.Database tempDatabase)
        {
            foreach (var sqe in schema.Sequences)
            {
                var result = target.Sequences.FirstOrDefault(p => p.Name == sqe.Name);
                if (result == null)
                    tempDatabase.Sequences.Add(sqe);
            }
        }
        private void CompareTrigger(Objects.Database schema, Objects.Database target, Objects.Database tempDatabase)
        {
            foreach (var sqe in schema.Trigers)
            {
                var result = target.Trigers.FirstOrDefault(p => p.Name == sqe.Name);
                if (result == null)
                {
                    tempDatabase.Trigers.Add(sqe);
                }
            }
        }
        private void CompareView(Objects.Database schema, Objects.Database target, Objects.Database tempDatabase)
        {
            foreach (var view in schema.Views)
            {
                var result = target.Views.FirstOrDefault(p => p.Name == view.Name);
                if (result == null)
                    tempDatabase.Views.Add(view);
                else
                {
                    if (view.SqlStatment != result.SqlStatment)
                    {
                        LogManager.LogWriter.Warn(view.Name+ " Viewin içeriği farklı yada farklı olabilir lütfen manual kontrol ediniz.");
                        //tempDatabase.Views.Add(view);
                    }
                }
            }
        }
        private void CompareFunctions(Objects.Database schema, Objects.Database target, Objects.Database tempDatabase)
        {
            foreach (var func in schema.Functions)
            {
                var result = target.Functions.FirstOrDefault(p => p.Name == func.Name);
                if (result == null)
                    tempDatabase.Functions.Add(func);
                else
                {
                    if (func.SqlStatment != result.SqlStatment)
                    {
                        LogManager.LogWriter.Warn(func.Name + " Fonksiyonun içeriği farklı yada farklı olabilir lütfen manual kontrol ediniz.");
                        //tempDatabase.Functions.Add(view);
                    }
                }
            }
        }
        private void CompareIndexKeys(Table schema, Table target)
        {
            var resultTable = new Table();
            resultTable.Name = schema.Name;
            resultTable.Tablespace = schema.Tablespace;

            bool different = false;

            foreach (var item in schema.Indexes)
            {
                var result = target.Indexes.FirstOrDefault(p => p.Name == item.Name);
                if (result == null)
                {
                    resultTable.Indexes.Add(item);
                    different = true;
                }
                else
                {
                    if (item.indexType != result.indexType)
                    {
                        resultTable.Indexes.Add(item);
                        different = true;
                    }
                    else
                    {
                        different = false;
                    }
                }
            }

            //if (!different)
            //    return null;
            //return resultTable;
        }
        private Database.Objects.Database CompareTables(Objects.Database schema, Objects.Database target)
        {
            var resultDb = new Objects.Database();
            foreach (var table in schema.Tables)
            {
                var result = target.Tables.FirstOrDefault(p => p.Name == table.Name);
                if (result == null)
                {
                    table.GenerateCreateStatement = true;
                    resultDb.Tables.Add(table);   
                }
                else
                {
                    Table differentTable = CompareColumns(table, result);
                    if (differentTable != null)
                        resultDb.Tables.Add(differentTable);

                    //indexleri kontrol et.
                }
            }

            LogManager.LogWriter.Trace("CompareTables Complate Total Difference : "+resultDb.Tables.Count.ToString());

            return resultDb;
        }
        private Table CompareColumns(Table schema, Table target)
        {
            var resultTable = new Table();
            resultTable.Name = schema.Name;
            resultTable.Tablespace = schema.Tablespace;
            resultTable.GenerateCreateStatement = false;
            bool different = false;

            foreach (var item in schema.Columns)
            {
                var result = target.Columns.FirstOrDefault(p => p.Name == item.Name);
                if (result == null)
                {
                    resultTable.Columns.Add(item);
                    different = true;
                }
                else
                {
                    if (item.Nullable != result.Nullable ||
                        item.ColumnType != result.ColumnType ||
                        item.ValueLength != result.ValueLength)
                    {
                        item.Modified = true;
                        resultTable.Columns.Add(item);
                        different = true;
                    }
                    else
                    {
                        different = false;
                    }
                }
            }

            if (!different)
                return null;
            return resultTable;
        }
        private Objects.Database GenerateDatabase(DatabaseParameter param)
        {
            var db = new Objects.Database();
            db.ConnectionString = param.ConnectionString;
            db.InitializeDatabase();
            db.DatabaseToSchema();

            return db;
        }
    }
}
