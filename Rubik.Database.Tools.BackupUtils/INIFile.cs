using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Rubik.Database.Tools.BackupUtils
{
    public class INIFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        public INIFile(string INIPath)
        {
            path = INIPath;
        }

        public void WriteValue(string Section, string Key, string value)
        {
            WritePrivateProfileString(Section, Key, value, this.path);
        }

        public string ReadValue(string Section, string Key)
        {
            StringBuilder sBuilder = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "-1", sBuilder, 255, this.path);
            return sBuilder.ToString();
        }

        public string ReadValue(string Section, string Key,string DefValue) {
            StringBuilder sBuilder = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key,DefValue, sBuilder, 255, this.path);
            return sBuilder.ToString().Length == 0 ? DefValue : sBuilder.ToString();
        }
    }
}
