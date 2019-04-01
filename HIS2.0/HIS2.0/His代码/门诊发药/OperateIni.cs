using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;



namespace ts_yf_mzfy
{
    internal class OperateIni
    {

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name=^Section^>节点名称</param>
        /// <param name=^Key^>关键字</param>
        /// <param name=^Value^>值</param>
        /// <param name=^filepath^>INI文件路径</param>
        static public void IniWriteValue(string Section, string Key, string Value, string filepath)
        {
            WritePrivateProfileString(Section, Key, Value, filepath);
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name=^Section^>节点名称</param>
        /// <param name=^Key^>关键字</param>
        /// <param name=^filepath^>INI文件路径</param>
        /// <returns>值</returns>
        static public string IniReadValue(string Section, string Key, string filepath)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, filepath);
            return temp.ToString();
        }

    }
}
