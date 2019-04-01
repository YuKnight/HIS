using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using Microsoft.Win32;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.DatabaseAccess
{
	/// <summary>
	/// Oracle 的摘要说明。
	/// </summary>
	public class Oracle : OleDB //RelationalDatabase
	{
		/// <summary>
		/// 数据库平台名称
		/// </summary>
		new protected const string VENDOR_NAME = "Oracle";
		/// <summary>
		/// 构造一OleDB
		/// </summary>
		public Oracle()
		{
			this.Vendor = VENDOR_NAME;
		}
		private Oracle (string name ,string connectionString )
		{
			this.Vendor = VENDOR_NAME;
			this.cnnString = connectionString;
			//this.connection = new OracleConnection (connectionString);
			this.connection = new OleDbConnection( connectionString );
			this.Name = name;
		}
		/// <summary>
		/// 获取该对象副本
		/// </summary>
		/// <returns></returns>
		public override RelationalDatabase GetCopy()
		{	
			return new Oracle (this.Name,this.cnnString);
		}

        public override ConnectType ConnectionType
        {
            get
            {
                return ConnectType.ORACLE;
            }
        }

		#region 实现基类的抽象方法
		/*
		#region //创建一个CommandBuilder
		/// <summary>
		/// 返回一个CommandBuilder
		/// </summary>
		/// <param name="_adapter">数据适配器</param>
		public override void CreateCommandBuilder(IDataAdapter _adapter)
		{
			OracleCommandBuilder cb = new OracleCommandBuilder((OracleDataAdapter)_adapter);
		}
		#endregion

		#region //执行一个命令
		/// <summary>
		/// 执行一个语句，返回执行情况
		/// </summary>
		/// <param name="cmd">IDbCommand对象</param>
		/// <returns></returns>
		public override int DoCommand(IDbCommand cmd)
		{
			int result=0;
			if(isInTransaction) cmd.Transaction=transaction;
			cmd.Connection=connection;
			result = cmd.ExecuteNonQuery();
			return result;
		}
		/// <summary>
		///  执行一个语句，返回执行情况
		/// </summary>
		/// <param name="procedureName">存储过程名</param>
		/// <param name="parameters">参数</param>
		/// <param name="timeOut">超时时间</param>
		/// <returns></returns>
		public override int DoCommand(string procedureName, ParameterEx[] parameters, int timeOut)
		{
			int result=0;
			IDbCommand cmd = this.GetCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = procedureName;
			cmd.CommandTimeout = timeOut;
			if ( parameters != null && parameters.Length > 0 )
				SetParameters( cmd, parameters );
			if(isInTransaction) cmd.Transaction=transaction;
			cmd.Connection=connection;
			try
			{
				result = cmd.ExecuteNonQuery();
				if ( parameters != null && parameters.Length > 0 )
					ReturnParameters( cmd, parameters );
				return result;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{
				cmd.Dispose();
				cmd = null;
			}
		}

		/// <summary>
		/// 执行一个语句，返回执行情况
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <returns></returns>
		public override int DoCommand(string commandText)
		{
			int result=0;
			OracleCommand cmd=new OracleCommand(commandText);
			if(isInTransaction) cmd.Transaction= (OracleTransaction)transaction;
			cmd.Connection=(OracleConnection)connection;
			try
			{
				result = cmd.ExecuteNonQuery();
				return result;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
			}
		}
		/// <summary>
		/// 执行一个语句，返回执行情况
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <param name="timeOut">超时限制</param>
		/// <returns></returns>
		public override int DoCommand(string commandText,int timeOut)
		{
			int result=0;
			OracleCommand cmd=new OracleCommand(commandText);
			if(isInTransaction) cmd.Transaction= (OracleTransaction)transaction;
			cmd.Connection=(OracleConnection)connection;

			try
			{
				result = cmd.ExecuteNonQuery();
				return result;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
			}
		}
		/// <summary>
		/// 执行一组命令
		/// </summary>
		/// <param name="storeProcedureNameArray">存储过程数组</param>
		/// <param name="parametersArray">参数数组</param>
		/// <param name="tiemOutArray">超时数组</param>
		/// <param name="commandTexts">命令字符串数组</param>
		/// <returns></returns>
		public override int DoCommand(string[] storeProcedureNameArray, ParameterEx[][] parametersArray, int[] tiemOutArray, string[] commandTexts)
		{
			
			int result=0;
			//开始一个事物
			this.BeginTransaction();
			try
			{
				int i;
				if(storeProcedureNameArray!=null)
				{
					IDbCommand cmd=null;
					for(i=0;i<storeProcedureNameArray.GetLength(0);i++)
					{
						if(storeProcedureNameArray[i]!="")
						{
							cmd =this.GetCommand();
							cmd.CommandText=storeProcedureNameArray[i];
							cmd.CommandType=CommandType.StoredProcedure;
							//参数赋值
							SetParameters(cmd,parametersArray[i]);

							if(tiemOutArray!=null)
							{
								if(tiemOutArray[i]>30)					//默认为30秒
								{
									cmd.CommandTimeout=tiemOutArray[i];	
								}
							}
							this.DoCommand(cmd);
							//回传数据
							ReturnParameters(cmd,parametersArray[i]);
							
						}
					}
					cmd.Dispose();
					cmd=null;
				}
				if(commandTexts!=null)
				{
					for(i=0;i<commandTexts.GetLength(0);i++)
					{
						if(commandTexts[i]!=null)
						{
							if(commandTexts[i]!="")
							{
								DoCommand(commandTexts[i]);
							}
						}
					}
				}
				//提交事务
				CommitTransaction();
				return result;
			}
			catch(Exception err)
			{
				//回滚事务
				this.RollbackTransaction();
				throw new Exception("DoCommand\\DatabaseAccess\\"+err.Message);
			}
		}
		#endregion

		#region //返回一个数据参数
		/// <summary>
		/// 返回一个参数对象
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="values">参数值</param>
		/// <returns></returns>
		public override IDbDataParameter GetParameter(string parameterName,object values) 
		{
			return new OracleParameter(parameterName,values);
		}
		/// <summary>
		/// 返回一个参数对象
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="dataType">参数类型</param>
		/// <param name="size">参数大小</param>
		/// <returns></returns>
		public override IDbDataParameter GetParameter(string parameterName,object dataType,int size)
		{
			return new OracleParameter(parameterName,(OracleType)dataType,size);
		}
		/// <summary>
		/// 返回一个参数对象
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="dataType">参数类型</param>
		/// <param name="size">参数大小</param>
		/// <param name="values">参数值</param>
		/// <returns></returns>
		public override IDbDataParameter GetParameter(string parameterName,object dataType,int size,object values)
		{
			OracleParameter para= new OracleParameter(parameterName,(OracleType)dataType,size);
			para.Value = values;
			return para;
		}
		/// <summary>
		/// 返回一个参数对象
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="values">参数值</param>
		/// <param name="direction">参数传入传出方向</param>
		/// <returns></returns>
		public override IDbDataParameter GetParameter(string parameterName,object values,ParameterDirection direction)
		{
			OracleParameter para= new OracleParameter();
			para.ParameterName = parameterName;
			para.Value = values;
			para.Direction=direction;
			return para;
		}
		/// <summary>
		/// 返回一个参数对象
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="values">参数值</param>
		/// <param name="direction">参数传入传出方向</param>
		/// <param name="size">参数大小</param>
		/// <returns></returns>
		public override IDbDataParameter GetParameter(string parameterName,object values,ParameterDirection direction,int size)
		{
			OracleParameter para= new OracleParameter();
			para.ParameterName = parameterName;
			para.Value = values;
			para.Direction=direction;
			para.Size=size;
			return para;
		}
		/// <summary>
		/// 返回一个参数对象
		/// </summary>
		/// <param name="parameterName">参数名称</param>
		/// <param name="values">参数值</param>
		/// <param name="direction">参数传入传出方向</param>
		/// <param name="dataType">参数类型</param>
		/// <param name="size">参数大小</param>
		/// <returns></returns>
		public override IDbDataParameter Getparameter(string parameterName, object values, ParameterDirection direction,int size, object dataType )
		{
			OracleParameter para= new OracleParameter(parameterName,(OracleType)dataType,size);
			para.Direction=direction;
			return para;
		}
		#endregion

		#region //执行一个命令返回一个数据结果
		/// <summary>
		/// 执行一个命令返回一个数据结果
		/// </summary>
		/// <param name="cmd">IDbCommand对象</param>
		/// <returns></returns>
		public override object GetDataResult(IDbCommand cmd)
		{
			object Result=null;
			if(isInTransaction) cmd.Transaction=transaction;
			cmd.Connection=connection;
			Result = cmd.ExecuteScalar();
			return Result;
		}
		/// <summary>
		/// 执行一个命令返回一个数据结果
		/// </summary>
		/// <param name="procedureName">存储过程名</param>
		/// <param name="parameters">参数</param>
		/// <param name="timeOut">超时时间</param>
		/// <returns></returns>
		public override object GetDataResult(string procedureName, ParameterEx[] parameters, int timeOut)
		{
			object Result=null;
			IDbCommand cmd = this.GetCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText =procedureName;
			cmd.CommandTimeout = timeOut;
			if ( parameters != null && parameters.Length > 0 )
				SetParameters ( cmd,parameters );

			if(isInTransaction) cmd.Transaction=transaction;
			cmd.Connection=connection;
			try
			{
				Result = cmd.ExecuteScalar();
				return Result;
			}
			catch(Exception err)
			{
				throw new EntityException ( err.Message );
			}
			finally
			{
				cmd.Dispose();
				cmd = null;
			}
		}

		/// <summary>
		/// 执行一个命令返回一个数据结果
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <returns></returns>
		public override object GetDataResult(string commandText)
		{
			object Result=null;
			OracleCommand cmd=new OracleCommand(commandText);
			if(isInTransaction) cmd.Transaction= (OracleTransaction)transaction;
			cmd.Connection=(OracleConnection)connection;
			try
			{
				Result = cmd.ExecuteScalar();
				return Result;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
			}
		}
		/// <summary>
		/// 执行一个命令返回一个数据结果
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <param name="timeOut">超时限制</param>
		/// <returns></returns>
		public override object GetDataResult(string commandText,int timeOut)
		{
			object Result=null;
			OracleCommand cmd=new OracleCommand(commandText);
			if(isInTransaction) cmd.Transaction= (OracleTransaction)transaction;
			cmd.Connection=(OracleConnection)connection;
//			if(timeOut>30)
//			{
//				cmd.CommandTimeout =timeOut;
//			}
			try
			{
				Result = cmd.ExecuteScalar();
				return Result;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
			}
		}
		#endregion 

		#region //插入一条记录
		/// <summary>
		/// 执行插入一条记录 适用于有 自动生成标识的列
		/// </summary>
		/// <param name="cmd">IDbCommand对象</param>
		/// <param name="identity">自动增长列在插入记录是产生的序号</param>
		/// <returns></returns>
		public override int InsertRecord (IDbCommand cmd ,out object identity)
		{
			if(GetIdentityString()==null)
			{
				throw new EntityException("无法取得自增长列ID");
			}
			int result = 0;
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			cmd.Connection = connection;
			result = cmd.ExecuteNonQuery();
	
			cmd.CommandText = GetIdentityString();
			identity = Convert.ToInt32(cmd.ExecuteScalar());
			
			return result;
		}
		/// <summary>
		/// 执行插入一条记录 适用于有 自动生成标识的列
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <param name="identity">自动增长列在插入记录是产生的序号</param>
		/// <returns></returns>
		public override int InsertRecord (string commandText ,out object identity)
		{
			if(GetIdentityString()==null)
			{
				throw new EntityException("无法取得自增长列ID");
			}
			int result = 0;
			OracleCommand cmd=new OracleCommand(commandText);
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			cmd.Connection = (OracleConnection)connection;
			try
			{
				result = cmd.ExecuteNonQuery();
				cmd.CommandText = GetIdentityString();
				identity = Convert.ToInt32(cmd.ExecuteScalar());
				return result;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
			}
		}	
		/// <summary>
		/// 执行插入一条记录 适用于有 自动生成标识的列
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <param name="identity">自动增长列在插入记录是产生的序号</param>
		/// <param name="timeOut">超时限制</param>
		/// <returns></returns>
		public override int InsertRecord (string commandText ,out object identity,int timeOut)
		{
			if(GetIdentityString()==null)
			{
				throw new EntityException("无法取得自增长列ID");
			}
			int result = 0;
			OracleCommand cmd=new OracleCommand(commandText);
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			cmd.Connection = (OracleConnection)connection;
//			if(timeOut>30)
//			{
//				cmd.CommandTimeout =timeOut;
//			}
			try
			{
				result = cmd.ExecuteNonQuery();
				cmd.CommandText = GetIdentityString();
				identity = Convert.ToInt32(cmd.ExecuteScalar());
				return result;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
			}
		}
		#endregion

		#region //返回一个DataTable
		/// <summary>
		/// 返回一个DataTable
		/// </summary>
		/// <param name="cmd">IDbCommand对象</param>
		/// <returns></returns>
		public override DataTable GetDataTable(IDbCommand cmd)
		{
			cmd.Connection=this.connection;
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;

			OracleDataAdapter adapter = new OracleDataAdapter ((OracleCommand)cmd);

			try
			{
				DataTable dt=new DataTable();
				adapter.Fill(dt);
				return dt;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				adapter.Dispose();
				adapter=null;
			}
		}
		/// <summary>
		/// 返回一个DataTable
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <returns></returns>
		public override DataTable GetDataTable(string  commandText)
		{
			OracleCommand cmd=new OracleCommand(commandText);
			cmd.Connection=(OracleConnection)this.connection;
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;

			OracleDataAdapter adapter = new OracleDataAdapter((OracleCommand)cmd);
			try
			{
				DataTable dt=new DataTable();
				adapter.Fill(dt);
				return dt;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
				adapter.Dispose();
				adapter=null;
			}
		}
		/// <summary>
		/// 返回一个DataTable
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <param name="timeOut">超时限制</param>
		/// <returns></returns>
		public override DataTable GetDataTable(string  commandText,int timeOut)
		{
			OracleCommand cmd=new OracleCommand(commandText);
			cmd.Connection=(OracleConnection)this.connection;
//			if(timeOut>30)
//			{
//				cmd.CommandTimeout =timeOut;
//			}
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;

			OracleDataAdapter adapter = new OracleDataAdapter((OracleCommand)cmd);
			try
			{
				DataTable dt=new DataTable();
				adapter.Fill(dt);
				return dt;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
				adapter.Dispose();
				adapter=null;
			}
		}
		/// <summary>
		/// 返回一个DataTable
		/// </summary>
		/// <param name="procedureName">存储过程名称</param>
		/// <param name="parameters">参数名称</param>
		/// <returns></returns>
		public override DataTable GetDataTable(string procedureName,ParameterEx[] parameters)
		{
			IDbCommand cmd = this.GetCommand();
			cmd.Connection=this.connection;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = procedureName;
			
			SetParameters(cmd,parameters);

			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			
			OracleDataAdapter adapter = new OracleDataAdapter ((OracleCommand)cmd);

			DataTable dt=new DataTable();
			try
			{
				adapter.Fill(dt);
				return dt;
			}
			catch(Exception err)
			{
				throw new Exception(err.Message);
			}
			finally
			{
				cmd.Dispose();
				adapter.Dispose();
			}
		}
		/// <summary>
		/// 返回一个DataTable
		/// </summary>
		/// <param name="procedureName">存储过程名称</param>
		/// <param name="parameters">参数名称</param>
		/// <param name="timeOut">超时时间</param>
		/// <returns></returns>
		public override DataTable GetDataTable(string procedureName,ParameterEx[] parameters,int timeOut)
		{
			IDbCommand cmd = this.GetCommand();
			cmd.Connection=this.connection;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = procedureName;
			cmd.CommandTimeout = timeOut;
			SetParameters(cmd,parameters);

			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			
			OracleDataAdapter adapter = new OracleDataAdapter ((OracleCommand)cmd);

			DataTable dt=new DataTable();
			try
			{
				adapter.Fill(dt);
				return dt;
			}
			catch(Exception err)
			{
				throw new Exception(err.Message);
			}
			finally
			{
				cmd.Dispose();
				adapter.Dispose();
			}
		}
		#endregion

		#region //返回一个OracleDataAdapter
		/// <summary>
		///  返回一个IDataAdpter 
		/// </summary>
		/// <param name="cmd">IDbCommand对象</param>
		/// <returns></returns>
		public override DbDataAdapter GetAdapter(IDbCommand cmd)
		{
			OracleDataAdapter adapter = new OracleDataAdapter();
			adapter.SelectCommand= (OracleCommand)cmd;
			cmd.Connection=connection;
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			return adapter;
		}
		/// <summary>
		///  返回一个IDataAdpter 
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <returns></returns>	
		public override DbDataAdapter GetAdapter(string commandText)
		{
			OracleDataAdapter adapter = new OracleDataAdapter ();
			OracleCommand cmd=new OracleCommand(commandText);
			adapter.SelectCommand= (OracleCommand)cmd;
			cmd.Connection=(OracleConnection)connection;
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			return adapter;
		}
		/// <summary>
		///  返回一个IDataAdpter 
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <param name="timeOut">超时限制</param>
		/// <returns></returns>
		public override DbDataAdapter GetAdapter(string commandText,int timeOut)
		{
			OracleDataAdapter adapter = new OracleDataAdapter ();
			OracleCommand cmd=new OracleCommand(commandText);
			adapter.SelectCommand= (OracleCommand)cmd;
			cmd.Connection=(OracleConnection)connection;
//			if(timeOut>30)
//			{
//				cmd.CommandTimeout =timeOut;
//			}
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			return adapter;
		}
		#endregion

		#region //取得数据行
		/// <summary>
		/// 返回一个DataRow
		/// </summary>
		/// <param name="cmd">IDbCommand对象</param>
		/// <returns></returns>
		public override DataRow GetDataRow(IDbCommand cmd)
		{
			cmd.Connection=this.connection;				//添加连接
			DataRow r ;

			OracleDataAdapter adapter=new OracleDataAdapter();
			adapter.SelectCommand= (OracleCommand) cmd;
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			try
			{
				DataTable dt=new DataTable();
				adapter.Fill(dt);
			
				if (dt.Rows.Count>0)
				{
					r = dt.Rows[0];
				}
				else
				{
					r = null;
				}
				return r;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				adapter.Dispose();
				adapter=null;
			}
		}
		public override DataRow GetDataRow(string procedurName, ParameterEx[] parameters, int timeOut)
		{
			IDbCommand cmd = this.GetCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = procedurName;
			cmd.CommandTimeout = timeOut;
			cmd.Connection=this.connection;				//添加连接
			
			if ( parameters != null && parameters.Length > 0 )
				this.SetParameters( cmd, parameters );

			DataRow r ;

			OracleDataAdapter adapter=new OracleDataAdapter();
			adapter.SelectCommand= (OracleCommand) cmd;
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			try
			{
				DataTable dt=new DataTable();
				adapter.Fill(dt);
			
				if (dt.Rows.Count>0)
				{
					r = dt.Rows[0];
				}
				else
				{
					r = null;
				}
				if ( parameters != null && parameters.Length > 0 )
					this.ReturnParameters ( cmd,parameters );

				return r;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				adapter.Dispose();
				adapter=null;
			}
		}

		/// <summary>
		/// 返回一个DataRow
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <returns></returns>
		public override DataRow GetDataRow(string commandText)
		{
			OracleCommand cmd=new OracleCommand(commandText);
			cmd.Connection=(OracleConnection)this.connection;				//添加连接
			DataRow r ;

			OracleDataAdapter adapter=new OracleDataAdapter();
			adapter.SelectCommand= (OracleCommand) cmd;
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			try
			{
				DataTable dt=new DataTable();
				adapter.Fill(dt);
			
				if (dt.Rows.Count>0)
				{
					r = dt.Rows[0];
				}
				else
				{
					r = null;
				}
				return r;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
				adapter.Dispose();
				adapter=null;
			}
		}
		/// <summary>
		/// 返回一个DataRow
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <param name="timeOut">超时限制</param>
		/// <returns></returns>
		public override DataRow GetDataRow(string commandText,int timeOut)
		{
			OracleCommand cmd=new OracleCommand(commandText);
			cmd.Connection=(OracleConnection)this.connection;				//添加连接
//			if(timeOut>30)
//			{
//				cmd.CommandTimeout =timeOut;
//			}
			DataRow r ;

			OracleDataAdapter adapter=new OracleDataAdapter();
			adapter.SelectCommand= (OracleCommand) cmd;
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			try
			{
				DataTable dt=new DataTable();
				adapter.Fill(dt);
			
				if (dt.Rows.Count>0)
				{
					r = dt.Rows[0];
				}
				else
				{
					r = null;
				}
				return r;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
				adapter.Dispose();
				adapter=null;
			}
		}
		#endregion

		#region //取得一个DataReader
		/// <summary>
		/// 返回一个DataReader
		/// </summary>
		/// <param name="cmd">IDbCommand对象</param>
		/// <returns></returns>
		public override IDataReader GetDataReader(IDbCommand cmd)
		{
			cmd.Connection=this.connection;
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			System.Data.OracleClient.OracleDataReader reader=(OracleDataReader)cmd.ExecuteReader();
			return reader;
		}
		/// <summary>
		/// 返回一个DataReader
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <returns></returns>
		public override IDataReader GetDataReader(string commandText)
		{
			OracleCommand cmd=new OracleCommand(commandText);
			cmd.Connection=(OracleConnection)this.connection;
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			try
			{
				System.Data.OracleClient.OracleDataReader reader=(OracleDataReader)cmd.ExecuteReader();
				return reader;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
			}
		}
		/// <summary>
		/// 返回一个DataReader
		/// </summary>
		/// <param name="commandText">SQL语句字符串</param>
		/// <param name="timeOut">超时限制</param>
		/// <returns></returns>
		public override IDataReader GetDataReader(string commandText,int timeOut)
		{
			OracleCommand cmd=new OracleCommand(commandText);
			cmd.Connection=(OracleConnection)this.connection;
//			if(timeOut>30)
//			{
//				cmd.CommandTimeout =timeOut;
//			}
			if(isInTransaction) cmd.Transaction = (OracleTransaction)transaction;
			try
			{
				System.Data.OracleClient.OracleDataReader reader=(OracleDataReader)cmd.ExecuteReader();
				return reader;
			}
			catch(Exception err)
			{
				throw new EntityException(err.Message);
			}
			finally
			{ 
				cmd.Dispose();
				cmd=null;
			}
		}
		#endregion

		#region 用数据适配器填充一个数据集中一个表
		/// <summary>
		/// 用数据适配器填充一个数据集中一个表
		/// </summary>
		/// <param name="storeProcedureName">存储过程名</param>
		/// <param name="parameters">参数名</param>
		/// <param name="ds">数据集</param>
		/// <param name="tableName">表名</param>
		/// <param name="timeOut">超时时间</param>
		public override void AdapterFillDataSet(string storeProcedureName, ParameterEx[] parameters, DataSet ds, string tableName, int timeOut)
		{
			try
			{
				IDbCommand cmd =this.GetCommand();
				cmd.CommandText=storeProcedureName;
				cmd.CommandType=CommandType.StoredProcedure;
				//参数赋值
				if ( parameters !=null && parameters.Length > 0)
					SetParameters(cmd,parameters);

				if(timeOut>30)					//默认为30秒
				{
					cmd.CommandTimeout=timeOut;	
				}
				DbDataAdapter adapter=this.GetAdapter(cmd);
				//回传数据
				if ( parameters != null && parameters.Length > 0 )
					ReturnParameters(cmd,parameters);

				adapter.Fill(ds,tableName);
				adapter.Dispose();
				cmd.Dispose();
				cmd=null;
			}
			catch(Exception err)
			{
				throw new Exception("AdapterFillDataSet\\DatabaseAccess"+err.Message);
			}
		}

		/// <summary>
		/// 用数据适配器填充一个数据集中一个表
		/// </summary>
		/// <param name="commandText">SQL命令</param>
		/// <param name="ds">数据集</param>
		/// <param name="tableName">表名</param>
		/// <param name="timeOut">超时时间</param>
		public override void AdapterFillDataSet(string commandText, DataSet ds, string tableName, int timeOut)
		{
			try
			{
				DbDataAdapter adapter=this.GetAdapter(commandText,timeOut);
				adapter.Fill(ds,tableName);
				adapter.Dispose();
			}
			catch(Exception err)
			{
				throw new Exception("AdapterFillDataSet\\DatabaseAccess"+err.Message);
			}
	
		}

		#endregion
		*/
		/// <summary>
		/// 获取服务器时间的SQL语句(默认为IBM DB2数据库语句）
		/// </summary>
		/// <returns></returns>
		public override string GetIdentityString()
		{
			//有待补充
			return null;
		}
		/// <summary>
		/// 获取服务器时间的SQL语句(默认为IBM DB2数据库语句）
		/// </summary>
		/// <returns></returns>
		public override string GetServerTimeString()
		{
			return "SELECT SYSDATE FROM DUAL";
		}
//		/// <summary>
//		/// 初始化数据库（刚被初始化的数据库的连接是打开的）
//		/// </summary>
//		/// <param name="connectionString">连接字符串</param>
//		public override void Initialize(string connectionString)
//		{
//			cnnString=connectionString;
//			try
//			{
//				//获得连接
//				OracleConnection cnn=new OracleConnection(cnnString);
//				this.connection = cnn;
//				this.connection.Open();
//			}
//			catch(OracleException e)
//			{
//				throw new EntityException("连接数据库失败！参考：" + e.Message ,ErrorTypes.DatabaseUnknownError);
//			}
//		}
		/// <summary>
		/// 返回参数的字符串形式
		/// </summary>
		/// <param name="name">名称</param>
		/// <returns></returns>
		public override string GetStringParameter (string name)
		{
			return "@" + name;
		}
		/// <summary>
		/// 返回数据类型
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public override SqlValueTypes SqlValueType (DbType type)
		{
			if (type == DbType.Boolean)
			{
				return SqlValueTypes.BoolToInterger;
			}
			else
			{
				return SqlValueTypes.PrototypeString;
			}
		}
		/// <summary>
		/// 返回加上引号的名称
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public override string GetName (string name)
		{
			return this.QuotationMarksStart + name + this.QuotationMarksEnd;
		}

//		/// <summary>
//		/// 错误处理
//		/// </summary>
//		/// <param name="e">异常</param>
//		/// <param name="message">消息</param>
//		/// <returns></returns>
//		public override ErrorTypes ErrorHandler (Exception e,out string message) 
//		{
//			message = "";
//			if (e is OracleException)
//			{
//				OracleException sqlErr = (OracleException)e;
////				int j = 0;
////				for (j = 0;j < sqlErr.Errors.Count ;j++)
////				{
////					if (sqlErr.Errors[j].Number != 3621) break;
////				}
////				switch (sqlErr.Errors[j].Number)
////				{
////					case 2627:
////						message = "数据重复！";
////						return ErrorTypes.NotUnique;
////					case 8152:
////						return ErrorTypes.DataTooLong;
////					case 515:
////						message = "参考：" + sqlErr.Message;
////						return ErrorTypes.NotAllowDataNull;
////					case 0:
////						return ErrorTypes.DataTypeNotMatch;
////					case 544:
////						message = "参考：" + sqlErr.Message;
////						return ErrorTypes.AutoValueOn;
////					case 547:
////						message = "参考：" + sqlErr.Message;
////						return ErrorTypes.RestrictError;
////
////				}
////				message = "数据库操作异常:";
////				for(int i =0; i <sqlErr.Errors.Count;i++)
////				{
////					message += "Index #" + i + "\n" +
////						"Message: " + sqlErr.Message + "\n" +
////						"Native: " + sqlErr.Errors[i].Number.ToString() + "\n" +
////						"Source: " + sqlErr.Errors[i].Source + "\n" ;
////				}
//				return ErrorTypes.DatabaseUnknownError;
//			}
//			else
//			{
//				message = "";
//				return ErrorTypes.Unknown;
//			}
//		}

		#endregion 
	}
}
