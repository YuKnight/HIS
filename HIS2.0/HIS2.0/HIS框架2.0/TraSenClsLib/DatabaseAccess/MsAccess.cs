using System;
using System.Data.OleDb;

namespace TrasenClasses.DatabaseAccess
{
	/// <summary>
	/// MsAccess 的摘要说明。
	/// </summary>
	public class MsAccess : OleDB
	{
		/// <summary>
		/// 数据库平台名称
		/// </summary>
		new protected const string VENDOR_NAME = "MsAccess";
		/// <summary>
		/// 构造一IbmDb2
		/// </summary>
		public MsAccess()
		{
			this.Vendor = VENDOR_NAME;
		}
		private MsAccess (string name ,string connectionString )
		{
			this.Vendor = VENDOR_NAME;
			this.cnnString = connectionString;
			this.connection = new OleDbConnection (connectionString);
			this.Name = name;
		}
		/// <summary>
		/// 获取该对象副本
		/// </summary>
		/// <returns></returns>
		public override RelationalDatabase GetCopy()
		{	
			return new MsAccess(this.Name,this.cnnString);
		}

        public override ConnectType ConnectionType
        {
            get
            {
                return ConnectType.MSACCESS;
            }
        }
		/// <summary>
		/// 获取服务器时间的SQL语句
		/// </summary>
		/// <returns></returns>
		public override string GetIdentityString()
		{
			return null;
		}
		/// <summary>
		/// 获取服务器时间的SQL语句
		/// </summary>
		/// <returns></returns>
		public override string GetServerTimeString()
		{
			return "SELECT NOW()";
		}
	}
}
