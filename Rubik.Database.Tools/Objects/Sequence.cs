using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Devart.Data.Oracle;

namespace Rubik.Database.Objects
{
    [Serializable]
    public class Sequence
    {
        #region Properties

        public string Name { get; set; }
        public string SqlStatment { get; set; }

        private string _minValue = "1";
        public string MinValue
        {
            get { return _minValue; }
            set { _minValue = value; }
        }

        private string _maxValue = "9999999999999";
        public string MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; }
        }

        private string _startWith = "1";
        public string StartWith
        {
            get { return _startWith; }
            set { _startWith = value; }
        }

        private string _incrementBy = "1";
        public string IncrementBy
        {
            get { return _incrementBy; }
            set { _incrementBy = value; }
        }

        private string _cacheSize = "0";
        public string CacheSize
        {
            get
            {
                if (_cacheSize.Equals("0") || _cacheSize.Equals("1"))
                    _cacheSize = "20";

                return _cacheSize;
            }
            set { _cacheSize = value; }
        }

        private bool _cycle = false;
        public bool Cycle
        {
            get { return _cycle; }
            set { _cycle = value; }
        }

        private bool _order = false;
        public bool Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public Database Owner { get; set; }
        #endregion
        public string GetCreateSql()
        {
            try
            {
                string strCreateViewSql = Common.NewLine +
                                          "-- Create sequence\n" +
                                          "CREATE SEQUENCE " + this.Name + "\n" +
                                          "MINVALUE " + this.MinValue + "\n" +
                                          "MAXVALUE " + this.MaxValue + "\n" +
                                          "START WITH " + this.StartWith + "\n" +
                                          "INCREMENT BY " + this.IncrementBy + "\n" +
                                          "CACHE " + this.CacheSize + "\n" + 
                                          (Cycle ? "cycle\n" : "")+
                                          (Order ? "order" : "")+";";

                return strCreateViewSql;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

