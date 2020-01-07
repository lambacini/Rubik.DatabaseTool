using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace Rubik.Database
{
    public class LogManager
    {
        public static Logger LogWriter = NLog.LogManager.GetCurrentClassLogger();
    }
}
