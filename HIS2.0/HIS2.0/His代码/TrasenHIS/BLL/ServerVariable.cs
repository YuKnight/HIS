using System;
using System.Data;
using TrasenHIS.DAL;
using System.Data.OleDb;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;


namespace TrasenHIS
{
    /// <summary>
    /// 系统变量对象
    /// </summary>
    public class ServerVariable 
    {
        private static string configfilepath = "";
        private static DataTable dtfpxm;
        private static DataTable dttjdxm;

        public static DateTime ServerDateTime(RelationalDatabase _DataBase)
        {
            //get
            //{
                string sql = "values current timestamp";
                DataRow dr = _DataBase.GetDataRow(sql);
                return Convert.ToDateTime(dr[0]);
            //}
        }

        public static string DateTimeLongFormat
        {
            get
            {
                return "yyyy-MM-dd HH:mm:ss";
            }
        }
        
        public static string ConfigFilePath
        {
            get
            {
                return configfilepath;
            }
            set
            {
                configfilepath = value;
            }
        }

       
       
    }
}
