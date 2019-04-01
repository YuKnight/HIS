using System;
using System.Data.OleDb;

namespace TrasenClasses.DatabaseAccess
{
	/// <summary>
	/// IbmDb2 的摘要说明。
	/// </summary>
	public class IbmDb2 : OleDB
	{
		/// <summary>
		/// 数据库平台名称
		/// </summary>
		new protected const string VENDOR_NAME = "IbmDb2";
		/// <summary>
		/// 构造一IbmDb2
		/// </summary>
		public IbmDb2()
		{
			this.Vendor = VENDOR_NAME;
		}
		private IbmDb2 (string name ,string connectionString )
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
			return new IbmDb2(this.Name,this.cnnString);
		}

        public override ConnectType ConnectionType
        {
            get
            {
                return ConnectType.IBMDB2;
            }
        }
	
		/// <summary>
		/// 获取服务器时间的SQL语句
		/// </summary>
		/// <returns></returns>
		public override string GetIdentityString()
		{
			return "VALUES IDENTITY_VAL_LOCAL() ";
		}
		/// <summary>
		/// 获取服务器时间的SQL语句
		/// </summary>
		/// <returns></returns>
		public override string GetServerTimeString()
		{
			return "VALUES CURRENT TIMESTAMP";
		}
        public override void AdapterFillDataSet_Encryption(string commandText, System.Data.DataSet ds, int timeout, bool AutoTransaction)
        {
            //base.AdapterFillDataSet_Encryption(commandText, ds, timeout, AutoTransaction);
            throw new Exception("暂未实现此功能");
        }
	}
}
