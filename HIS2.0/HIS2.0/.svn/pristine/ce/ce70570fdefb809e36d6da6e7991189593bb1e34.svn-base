using System;
using System.Data;
using System.Data.Odbc;
using System.Data.Common;
using Microsoft.Win32;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.DatabaseAccess
{
    /// <summary>
    /// Odbc 的摘要说明。 
    /// jianqg 2013-4-1 增加 本类 处理Dbf（Microsoft Visual FoxPro）
    /// </summary>
    public class OdbcVfpDbf:Odbc
    {
        /// <summary>
		/// 数据库平台名称
		/// </summary>
		protected const string VENDOR_NAME = "OdbcDbf";
		/// <summary>
		/// 构造一Odbc
		/// </summary>
		public OdbcVfpDbf()
		{
			this.Vendor = VENDOR_NAME;
		}
        public OdbcVfpDbf(string path):this()
        {
            string connectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + path + " ;Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
            //connectionString = string.Format(connectionString, path);
            this.cnnString = connectionString;
            

        }
        private OdbcVfpDbf(string name, string connectionString)
		{
            this.Vendor = VENDOR_NAME;
            this.cnnString = connectionString;
            this.connection = new OdbcConnection(connectionString);
            this.Name = name;
		}
		/// <summary>
		/// 获取该对象副本
		/// </summary>
		/// <returns></returns>
		public override RelationalDatabase GetCopy()
		{
            return new OdbcVfpDbf(this.Name, this.cnnString);
		}
    }
}
