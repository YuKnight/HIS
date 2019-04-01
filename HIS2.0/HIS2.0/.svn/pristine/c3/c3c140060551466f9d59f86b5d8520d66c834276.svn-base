using System;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
namespace TrasenFrame.Classes
{
	/// <summary>
	/// SystemLog 的摘要说明。
	/// 系统运行日志
	/// </summary>
	public class SystemLog :IStdObject
	{
		private RelationalDatabase _database = FrmMdiMain.Database;
		private long _logID;
		private long _deptID;
		private long _operatorID;
		private string _operatorType;
		private string _contents;
		private DateTime _startTime;
		private int _errLevel;
		private string _workStation;
		private int _moduleID;
		

		#region 属性
		/// <summary>
		/// 数据访问对象
		/// </summary>
		public RelationalDatabase Database
		{
			get
			{
				return _database;
			}
			set
			{
				_database=value;
			}
		}
		/// <summary>
		/// 标识ID
		/// </summary>
		public long LogID
		{
			get{return _logID;}
		}
		/// <summary>
		/// 科室
		/// </summary>
		public long DeptID
		{
			get{return _deptID;}
			set{_deptID=value;}
		}
		/// <summary>
		///  操作员ID
		/// </summary>
		public long OperatorID
		{
			get{return _operatorID;}
			set{_operatorID=value;}
		}
		/// <summary>
		/// 操作员类型
		/// </summary>
		public string OperatorType
		{
			get{return _operatorType;}
			set{_operatorType=value;}
		}
		/// <summary>
		/// 日志内容
		/// </summary>
		public string Contents
		{
			get{return _contents;}
			set{_contents=value;}
		}
		/// <summary>
		/// 日志登记时间
		/// </summary>
		public DateTime StartTime
		{
			get{return _startTime;}
		}
		/// <summary>
		///  错误级别
		/// </summary>
		public int ErrLevel
		{
			get{return _errLevel;}
			set{_errLevel=value;}
		}
		/// <summary>
		/// 操作员机器名
		/// </summary>
		public string WorkStation
		{
			get{return _workStation;}
			set{_workStation=value;}
		}
		/// <summary>
		/// 操作模块
		/// </summary>
		public int ModuleID
		{
			get{return _moduleID;}
			set{_moduleID=value;}
		}

		#endregion

		/// <summary>
		/// 根据日志ID构造对象
		/// </summary>
		/// <param name="logID">日志ID</param>
		public SystemLog(long logID)
		{
			try
			{
				
				DataRow dr=FrmMdiMain.Database.GetDataRow( "SELECT * FROM HIS_LOG WHERE ID="+logID);
				if(dr==null)
				{
					_logID=-1;
					throw new Exception("指定的记录不存在！");
				}
				_logID=Convert.ToInt64(dr["ID"]);
				_deptID=Convert.ToInt64(Convertor.IsNull(dr["DEPT_ID"],"-1"));
				_operatorID=Convert.ToInt64(Convertor.IsNull(dr["OPERATOR_ID"],"-1"));
				_operatorType=Convertor.IsNull(dr["OPERATOR_TYPE"],"");
				_contents=Convertor.IsNull(dr["CONTENTS"],"");
				_startTime=Convert.ToDateTime(dr["STARTTIME"]);
				_errLevel=Convert.ToInt32(Convertor.IsNull(dr["ERRLEVEL"],"-1"));
				_workStation=Convertor.IsNull(dr["WORKSTATION"],"");
				_moduleID=Convert.ToInt32(Convertor.IsNull(dr["MODULE_ID"],"-1"));
			}
			catch(Exception err)
			{
				throw new Exception("SystemLog\\读取系统日志表出错\n"+err.Message);
			}
		}
		/// <summary>
		/// 根据日志ID构造对象
		/// </summary>
		/// <param name="logID">日志ID</param>
		/// <param name="database">数据库访问对象</param>
		public SystemLog(long logID,RelationalDatabase database)
		{
			try
			{
				
				this.Database =database;
				DataRow dr=this.Database.GetDataRow( "SELECT * FROM HIS_LOG WHERE ID="+logID);
				if(dr==null)
				{
					_logID=-1;
					throw new Exception("指定的记录不存在！");
				}
				_logID=Convert.ToInt64(dr["ID"]);
				_deptID=Convert.ToInt64(Convertor.IsNull(dr["DEPT_ID"],"-1"));
				_operatorID=Convert.ToInt64(Convertor.IsNull(dr["OPERATOR_ID"],"-1"));
				_operatorType=Convertor.IsNull(dr["OPERATOR_TYPE"],"");
				_contents=Convertor.IsNull(dr["CONTENTS"],"");
				_startTime=Convert.ToDateTime(dr["STARTTIME"]);
				_errLevel=Convert.ToInt32(Convertor.IsNull(dr["ERRLEVEL"],"-1"));
				_workStation=Convertor.IsNull(dr["WORKSTATION"],"");
				_moduleID=Convert.ToInt32(Convertor.IsNull(dr["MODULE_ID"],"-1"));
			}
			catch(Exception err)
			{
				throw new Exception("SystemLog\\读取系统日志表出错\n"+err.Message);
			}
		}
		/// <summary>
		/// 直接根据具体值构造日志对象
		/// </summary>
		/// <param name="logID">日志ID</param>
		/// <param name="deptID">科室ID</param>
		/// <param name="operatorID">操作员EmployeeID</param>
		/// <param name="operatorType">操作类型</param>
		/// <param name="contens">日志内容</param>
		/// <param name="startTime">发生时间</param>
		/// <param name="errLevel">错误级别</param>
		/// <param name="workStation">工作站名称</param>
		/// <param name="moduleID">模块ID</param>
		public SystemLog(long logID,long deptID,long operatorID,string operatorType,string contens,DateTime startTime,int errLevel,string workStation,int moduleID)
		{
			_logID=logID;
			_deptID=deptID;
			_operatorID=operatorID;
			_operatorType=operatorType;
			_contents=contens;
			_startTime=startTime;
			_errLevel=errLevel;
			_workStation=workStation;
			_moduleID=moduleID;
			
		}
		/// <summary>
		/// 直接根据具体值构造日志对象
		/// </summary>
		/// <param name="logID">日志ID</param>
		/// <param name="deptID">科室ID</param>
		/// <param name="operatorID">操作员EmployeeID</param>
		/// <param name="operatorType">操作类型</param>
		/// <param name="contens">日志内容</param>
		/// <param name="startTime">发生时间</param>
		/// <param name="errLevel">错误级别</param>
		/// <param name="workStation">工作站名称</param>
		/// <param name="moduleID">模块ID</param>
		/// <param name="dbType">数据库类别</param>
		public SystemLog(long logID,long deptID,long operatorID,string operatorType,string contens,DateTime startTime,int errLevel,
						string workStation,int moduleID,DatabaseType dbType)
		{
			_logID=logID;
			_deptID=deptID;
			_operatorID=operatorID;
			_operatorType=operatorType;
			_contents=contens;
			_startTime=startTime;
			_errLevel=errLevel;
			_workStation=workStation;
			_moduleID=moduleID;
			
		}


		#region 接口成员
		/// <summary>
		/// 保存对象
		/// </summary>
		/// <returns></returns>
		public bool Save()
		{
			
			string sql = "insert into his_log( dept_id,operator_id,operator_Type,contents,starttime,errlevel,workstation,module_id )";
			sql += "values ( "+ _deptID + "," + _operatorID + ",'" + _operatorType + "','" + _contents + "','" + _startTime + "'," + _errLevel + ",'" + _workStation + "'," + _moduleID + " )";
			
			try
			{
				this.Database.DoCommand( sql );
				return true;
			}
			catch(System.Exception err)
			{
				return false;
			}
		}
		/// <summary>
		/// 刷新对象
		/// </summary>
		/// <returns></returns>
		public bool Retrieve()
		{
			return true;
		}
		/// <summary>
		/// 删除对象
		/// </summary>
		/// <returns></returns>
		public bool Delete()
		{
			return true;
		}
		#endregion
	}
}
