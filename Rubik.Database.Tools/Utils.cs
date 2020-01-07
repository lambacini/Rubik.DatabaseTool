using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Rubik.Database.Objects;

namespace Rubik.Database
{
    public class Utils
    {
        public static string RemoveLastComma(string value)
        {
            if (value.Substring(value.Length - 1, 1) == ",")
            {
                return value.Substring(0, value.Length - 1);
            }
            else
                return value;
        }
        public static void SerializeDatabase(Rubik.Database.Objects.Database db, string strFilePath)
        {
            Stream sr = File.Open(strFilePath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(sr, db);
            sr.Close();
        }
        public static Rubik.Database.Objects.Database DeserializeDatabase(string path)
        {
            Stream sr = File.Open(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            object obj = formatter.Deserialize(sr);

            if (obj != null)
            {
                Objects.Database db = (Objects.Database)obj;
                return db;
            }
            else
                return null;
        }

        /// <summary>
        /// Compare To Database Schema
        /// Return missing database element to new Database Schema.
        /// </summary>
        /// <param name="sourceDb">Source Database Schema (rdb)</param>
        /// <param name="destination">Destination Database Schema (Real Database Instance) </param>
        /// <returns></returns>
        public static Database.Objects.Database CompareDataBase(Objects.Database sourceDb, Objects.Database destination)
        {
            Objects.Database resultDb = new Objects.Database();

            var tables = from p in sourceDb.Tables
                         where !destination.Tables.Contains(p)
                         select p;

            resultDb.Tables.AddRange(tables);

            return resultDb;
        }
    }
}
