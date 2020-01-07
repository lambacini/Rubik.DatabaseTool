using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Rubik.Database.Controls;

namespace Rubik.Database.Tools.BackupUtils
{
    class Program
    {
        private static string _iniFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Settings.ini";
        private static INIFile ini = new INIFile(_iniFilePath);

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("\r > Şema Oluşturuluyor.");

                if (args[0].ToUpper() == "EXPORT")
                {
                    Execute();


                }
            }
            else
            {
                Console.WriteLine("\r > Şema Karşılaştırılıyor.");

                Compare();
            }
            //DatabaseViewer viewer = new DatabaseViewer();
            //viewer.Show();
            Console.WriteLine("\r > Çıkmak İçin Herhangi Bir Tuşa Basınız");
            Console.ReadLine();
            Console.ReadLine();
        }

        private static void Compare()
        {
            string file = Path.Combine(Application.StartupPath, "Schema.bdb");

                var parameters = new ComparerParameters();
                parameters.SchemaPath = file;
                parameters.TargetParameters = new DatabaseParameter()
                    {
                        ConnectionString = GetConnectionString("")
                    };

                var comparer = new DatabaseComparer();
                if (comparer.IsDifferent(parameters))
                {
                    comparer.SaveScript();
                }
        }
        private static void Execute()
        {
            DatabaseParameter param = GetParameters();
            if (param == null)
                return;


            string[] multipleUser = ini.ReadValue("Database", "User").Split(',');
            if (multipleUser.Count() > 1)
            {
                foreach (var item in multipleUser)
                {
                    param.ConnectionString = GetConnectionString(item);
                    var export = new Export(param);
                    export.Execute();
                }
            }
            else
            {
                try
                {
                    var db = new Objects.Database();
                    db.ConnectionString = param.ConnectionString;
                    db.InitializeDatabase();
                    db.DatabaseToSchema();


                    BinaryFormatter formatter = new BinaryFormatter();

                    FileStream fs = new FileStream(Path.Combine(Application.StartupPath, "Schema.bdb"), FileMode.OpenOrCreate, FileAccess.ReadWrite);

                    formatter.Serialize(fs, db);

                    fs.Flush();
                    fs.Close();
                }
                catch (Exception)
                {

                }
            }

            //Rubik.Database.Tools.Export export = new Export(param);
                //export.Execute();
            //}
        }
        private static Rubik.Database.Tools.DatabaseParameter GetParameters()
        {
            if (!File.Exists(_iniFilePath))
            {
                string answer = AskQuestion(" > Ayar Dosyası Bulunamadı ! Otomatik Oluşturulsunmu ?<E,H>");
                bool correct = false;
                //Gereksiz düzelt
                if (answer.ToUpper() == "EVET" || answer.ToUpper() == "HAYIR" || answer.ToUpper() == "E" || answer.ToUpper() == "H")
                    correct = true;
                else
                    correct = false;

                while (!correct)
                {
                    answer = AskQuestion("\r > Seçenek Tanımlanamadı Geçerli Seçenekler <E,H>");
                    if (answer.ToUpper() == "EVET" || answer.ToUpper() == "HAYIR" || answer.ToUpper() == "E" || answer.ToUpper() == "H")
                        correct = true;
                    else
                        correct = false;
                }

                if (correct)
                {
                    WriteDefaultSettings();
                    Console.WriteLine("\r > Varsayılan ayarlar kaydedildi.Lütfen settings.ini dosyasından veritabanı ayarlarını düzenleyin");
                }
                
                return null;
            }
            else
            {
                DatabaseParameter param = new DatabaseParameter()
                {
                    CreateTable = Convert.ToBoolean(ini.ReadValue("ExportParameters", "CreateTable", "True")),
                    DropTable = Convert.ToBoolean(ini.ReadValue("ExportParameters", "DropTable", "False")),
                    ExportColumns = Convert.ToBoolean(ini.ReadValue("ExportParameters", "ExportColumns", "True")),
                    ExportData = Convert.ToBoolean(ini.ReadValue("ExportParameters", "ExportData", "False")),
                    ExportIndexes = Convert.ToBoolean(ini.ReadValue("ExportParameters", "ExportIndexes", "True")),
                    ExportKeys = Convert.ToBoolean(ini.ReadValue("ExportParameters", "ExportKeys", "True")),
                    AutoSave = Convert.ToBoolean(ini.ReadValue("ExportParameters", "AutoSave", "True")),
                    FilePath = ini.ReadValue("ExportParameters", "FilePath", ""),
                    ConnectionString = GetConnectionString("")
                };
                return param;
            }
        }
        private static string GetConnectionString(string userName)
        {
            string source =  ini.ReadValue("Database","DataSource");
            string Sid = ini.ReadValue("Database","SID");
            string User = string.IsNullOrEmpty(userName) ? ini.ReadValue("Database", "User") : userName;
            string Server = ini.ReadValue("Database","Server");
            string pass = ini.ReadValue("Database","Password");
            bool direct = Convert.ToBoolean(ini.ReadValue("Database", "Direct Connection", "True"));
            bool IsHash = Convert.ToBoolean(ini.ReadValue("Database", "IsPasswordHash", "False"));

            if (direct)
                return "User Id=" + User + ";Password=" + pass + ";Server=" + Server + ";Direct=True;Sid=" + Sid + ";Persist Security Info=True";
            else
                return "User Id=" + User + ";Password=" + pass + ";Data Source=" + source;
        }
        private static void WriteDefaultSettings()
        {
            File.Create(_iniFilePath).Close();

            ini.WriteValue("ExportParameters", "CreateTable", "True");
            ini.WriteValue("ExportParameters", "DropTable", "False");
            ini.WriteValue("ExportParameters", "ExportColumns", "True");
            ini.WriteValue("ExportParameters", "ExportData", "False");
            ini.WriteValue("ExportParameters", "ExportIndexes", "True");
            ini.WriteValue("ExportParameters", "ExportKeys", "True");
            ini.WriteValue("ExportParameters", "AutoSave", "True");
            ini.WriteValue("ExportParameters", "FilePath", "");

            ini.WriteValue("Database", "DataSource", "FONET");
            ini.WriteValue("Database", "SID", "FONET");
            ini.WriteValue("Database", "User", "FONETPACS");
            ini.WriteValue("Database", "Server", "127.0.0.1");
            ini.WriteValue("Database", "Password", "");
            ini.WriteValue("Database", "Direct Connection", "True");
            ini.WriteValue("Database", "IsPasswordHash", "False");
        }
        private static string AskQuestion(string Question)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Question);
            Console.ForegroundColor = ConsoleColor.White;
            string answer = Console.ReadLine();
            return answer;
        }
        private static bool SendSvn()
        {
            return true;
        }
    }
}
