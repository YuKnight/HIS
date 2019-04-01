using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.DatabaseAccess
{
    /// <summary>
    /// 关系型数据库的摘要说明。
    /// </summary>
    abstract public class RelationalDatabase
    {
        private string _name;								//数据库名字
        private string _quotationMarksStart = "\"";
        private string _quotationMarksEnd = "\"";
        /// <summary>
        /// 数据库平台
        /// </summary>
        protected string _vendor = "Unknown";				//数据库平台
        /// <summary>
        /// 数据库连接
        /// </summary>
        protected IDbConnection connection = null;			//数据库连接

        public abstract ConnectType ConnectionType
        {
            get;
        }
        /// <summary>
        /// 数据库事务
        /// </summary>
        protected IDbTransaction transaction = null;			//数据库事务
        /// <summary>
        /// 是否在事务中	
        /// </summary>
        protected bool isInTransaction = false;				//是否在事务中	
        /// <summary>
        /// 连接字符串
        /// </summary>
        protected string cnnString = "";
        /// <summary>
        /// jianqg 2013-7-24 增加 处理 默认的timeout
        /// jianqg 2013-7-24 只处理了sqlserver
        /// jianqg 2013-9-2  5分钟改为30分
        /// </summary>
        protected const int CON_TIMEOUT = 30 * 60;//5分钟 

        /// <summary>
        /// 关系型数据库访问对象
        /// </summary>
        public RelationalDatabase()
        {

        }
        /// <summary>
        /// 根据数据库名称构造关系型数据库访问对象
        /// </summary>
        /// <param name="name"></param>
        public RelationalDatabase(string name)
        {
            _name = name;
        }

        /// <summary>
        /// 根据设置返回一个派生类的数据库访问实例
        /// </summary>
        /// <returns></returns>
        public static RelationalDatabase GetDatabase()
        {
            return new OleDB();
        }
        /// <summary>
        /// 获取IDbCommand对象
        /// </summary>
        /// <returns></returns>
        public IDbCommand GetCommand()
        {
            return this.connection.CreateCommand();
        }
        /// <summary>
        /// 获取数据库事务IDbTransaction对象
        /// </summary>
        /// <returns></returns>
        public IDbTransaction GetTransaction()
        {
            return this.transaction;
        }
        /// <summary>
        /// 打开数据库
        /// </summary>
        public void Open()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        /// <summary>
        /// 关闭数据库
        /// </summary>
        public void Close()
        {
            if (this.connection != null && this.connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            this.isInTransaction = false;
        }

        /// <summary>
        /// 释放连接资源
        /// </summary>
        public void Dispose()
        {
            connection.Dispose();
        }

        /// <summary>
        /// 启动一个事务
        /// </summary>
        public virtual void BeginTransaction()
        {
            if ((connection == null) || (connection.State == ConnectionState.Closed))
            {
                throw new EntityException("数据库未打开或未初始化！");
            }
            else
            {
                transaction = connection.BeginTransaction();
                isInTransaction = true;
            }
        }

        /// <summary>
        /// 提交一个事务
        /// </summary>
        public void CommitTransaction()
        {
            if (transaction != null)
            {
                transaction.Commit();
                isInTransaction = false;
                transaction = null;
            }
            else
            {
                throw new EntityException("无可用事务！");
            }
        }
        /// <summary>
        /// 回滚一个事务
        /// </summary>
        public void RollbackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                isInTransaction = false;
                transaction = null;
            }
            else
            {
                throw new EntityException("无可用事务！");
            }
        }


        /// <summary>
        /// 根据属性值得到正确的Sql值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string GetSqlValue(object obj)
        {
            string type = obj.GetType().ToString();
            type = type.Substring(type.LastIndexOf('.') + 1, type.Length);

            switch (type)
            {
                case "Int16":
                    return obj.ToString();
                case "Int32":
                    return obj.ToString();
                case "Int64":
                    return obj.ToString();
                case "Single":
                    return obj.ToString();
                case "String":
                    return "'" + obj.ToString() + "'";
                case "Date":
                    return "'" + obj.ToString() + "'";
                case "Guid":
                    return "'" + obj.ToString() + "'";
                default:
                    throw new EntityException("目前不支持的数据库类型！");
            }
        }
        /// <summary>
        /// 获得AND字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringAnd()
        {
            return "AND";
        }
        /// <summary>
        /// 获得ASC字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringAscend()
        {
            return "ASC";
        }
        /// <summary>
        /// 获得BETWEEN字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringBetween()
        {
            return "BETWEEN";
        }
        /// <summary>
        /// 获得DELETE字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringDelete()
        {
            return "DELETE";
        }
        /// <summary>
        /// 获得DESC字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringDescend()
        {
            return "DESC";
        }
        /// <summary>
        /// 获得=字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringEuqalTo()
        {
            return "=";
        }
        /// <summary>
        /// 获得FOR UPDATE字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringForUpdate()
        {
            return "FOR UPDATE";
        }
        /// <summary>
        /// 获得FROM字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringFrom()
        {
            return "FROM";
        }
        /// <summary>
        /// 获得HAVING字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringHaving()
        {
            return "HAVING";
        }
        /// <summary>
        /// 获得IN字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringIn()
        {
            return "IN";
        }
        /// <summary>
        /// 获得INSERT INTO字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringInsertInto()
        {
            return "INSERT INTO";
        }
        /// <summary>
        /// 获得IS字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringIs()
        {
            return "IS";
        }
        /// <summary>
        /// 获得LIKE字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringLike()
        {
            return "LIKE";
        }
        /// <summary>
        /// 获得NOT字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringNot()
        {
            return "NOT";
        }
        /// <summary>
        /// 获得OR字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringOr()
        {
            return "OR";
        }
        /// <summary>
        /// 获得ORDER BY字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringOrderBy()
        {
            return "ORDER BY";
        }
        /// <summary>
        /// 获得SELECT字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringSelect()
        {
            return "SELECT";
        }
        /// <summary>
        /// 获得SET字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringSet()
        {
            return "SET";
        }
        /// <summary>
        /// 获得UPDATE字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringUpdate()
        {
            return "UPDATE";
        }
        /// <summary>
        /// 获得VALUES字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringValues()
        {
            return "VALUES";
        }
        /// <summary>
        /// 获得WHERE字符串
        /// </summary>
        /// <returns></returns>
        public string GetStringWhere()
        {
            return "WHERE";
        }
        /// <summary>
        /// 获得LEFT JOIN字符串
        /// </summary>
        /// <returns></returns>
        public string GetLeftJoin()
        {
            return "Left Join";
        }
        /*抽象方法*/
        /// <summary>
        /// 获取自增长ID的SQL语句
        /// </summary>
        /// <returns></returns>
        public abstract string GetIdentityString();
        /// <summary>
        /// 获取服务器时间的SQL语句
        /// </summary>
        /// <returns></returns>
        public abstract string GetServerTimeString();
        /// <summary>
        /// 返回一个RelationalDatabase 
        /// </summary>
        /// <returns></returns>
        public abstract RelationalDatabase GetCopy();
        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="e">异常对象</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public abstract ErrorTypes ErrorHandler(Exception e, out string message);
        /// <summary>
        /// 数据库初始化
        /// </summary>
        /// <param name="connectionString"></param>
        public abstract void Initialize(string connectionString);
        /// <summary>
        /// 返回一个CommandBuilder
        /// </summary>
        /// <param name="_adapter">数据适配器</param>
        public abstract void CreateCommandBuilder(IDataAdapter _adapter);
        /// <summary>
        /// 获取参数的字符串形式
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract string GetStringParameter(string name);
        /// <summary>
        /// 返回数据类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract SqlValueTypes SqlValueType(DbType type);
        /// <summary>
        /// 返回加上引号的名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract string GetName(string name);

        #region 执行插入一条记录 适用于有 自动生成标识的列
        /// <summary>
        /// 执行插入一条记录 适用于有 自动生成标识的列
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <param name="identity">自动增长列在插入记录是产生的序号</param>
        /// <returns></returns>
        public abstract int InsertRecord(IDbCommand cmd, out object identity);
        /// <summary>
        /// 执行插入一条记录 适用于有 自动生成标识的列
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <param name="identity">自动增长列在插入记录是产生的序号</param>
        /// <returns></returns>
        public abstract int InsertRecord(string commandtext, out object identity);
        /// <summary>
        /// 执行插入一条记录 适用于有 自动生成标识的列
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <param name="identity">自动增长列在插入记录是产生的序号</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public abstract int InsertRecord(string commandtext, out object identity, int timeOut);
        #endregion

        #region 返回一个参数对象
        /// <summary>
        /// 返回一个参数对象
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="values">参数值</param>
        /// <returns></returns>
        public abstract IDbDataParameter GetParameter(string parameterName, object values);
        /// <summary>
        /// 返回一个参数对象
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="dataType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <returns></returns>
        public abstract IDbDataParameter GetParameter(string parameterName, object dataType, int size);
        /// <summary>
        /// 返回一个参数对象
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="dataType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <param name="values">参数值</param>
        /// <returns></returns>
        public abstract IDbDataParameter GetParameter(string parameterName, object dataType, int size, object values);
        /// <summary>
        /// 返回一个参数对象
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="values">参数值</param>
        /// <param name="direction">参数传入传出方向</param>
        /// <returns></returns>
        public abstract IDbDataParameter GetParameter(string parameterName, object values, ParameterDirection direction);
        /// <summary>
        /// 返回一个参数对象
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="values">参数值</param>
        /// <param name="direction">参数传入传出方向</param>
        /// <param name="size">参数大小</param>
        /// <returns></returns>
        public abstract IDbDataParameter GetParameter(string parameterName, object values, ParameterDirection direction, int size);
        /// <summary>
        /// 返回一个参数对象
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="values">参数值</param>
        /// <param name="direction">参数传入传出方向</param>
        /// <param name="dataType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <returns></returns>
        public abstract IDbDataParameter Getparameter(string parameterName, object values, ParameterDirection direction, int size, object dataType);
        #endregion

        #region 返回一个IDataAdpter
        /// <summary>
        ///  返回一个IDataAdpter 
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <returns></returns>
        public abstract DbDataAdapter GetAdapter(IDbCommand cmd);
        /// <summary>
        ///  返回一个IDataAdpter 
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <returns></returns>
        public abstract DbDataAdapter GetAdapter(string commandtext);
        /// <summary>
        ///  返回一个IDataAdpter 
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public abstract DbDataAdapter GetAdapter(string commandtext, int timeOut);
        #endregion

        #region 返回一个DataTable
        /// <summary>
        /// 返回一个DataTable
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <returns></returns>
        public abstract DataTable GetDataTable(IDbCommand cmd);
        /// <summary>
        /// 返回一个DataTable
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <returns></returns>
        public abstract DataTable GetDataTable(string commandtext);
        /// <summary>
        /// 返回一个DataTable
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public abstract DataTable GetDataTable(string commandtext, int timeOut);
        /// <summary>
        /// 返回一个DataTable
        /// </summary>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public abstract DataTable GetDataTable(string procedureName, ParameterEx[] parameters);
        /// <summary>
        /// 返回一个DataTable
        /// </summary>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeOut">超时时间</param>
        /// <returns></returns>
        public abstract DataTable GetDataTable(string procedureName, ParameterEx[] parameters, int timeOut);
        #endregion

        #region 返回一个DataRow
        /// <summary>
        /// 返回一个DataRow
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <returns></returns>
        public abstract DataRow GetDataRow(IDbCommand cmd);
        /// <summary>
        /// 返回一个DataRow
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <returns></returns>
        public abstract DataRow GetDataRow(string commandtext);
        /// <summary>
        /// 返回一个DataRow
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public abstract DataRow GetDataRow(string commandtext, int timeOut);
        /// <summary>
        /// 返回一个DataRow
        /// </summary>
        /// <param name="procedurName">储存过程名</param>
        /// <param name="parameters">参数名</param>
        /// <param name="timeOut">超时时间</param>
        /// <returns></returns>
        public abstract DataRow GetDataRow(string procedurName, ParameterEx[] parameters, int timeOut);
        #endregion

        #region 返回一个DataReader
        /// <summary>
        /// 返回一个DataReader
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <returns></returns>
        public abstract IDataReader GetDataReader(IDbCommand cmd);
        /// <summary>
        /// 返回一个DataReader
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <returns></returns>
        public abstract IDataReader GetDataReader(string commandtext);
        /// <summary>
        /// 返回一个DataReader
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public abstract IDataReader GetDataReader(string commandtext, int timeOut);
        #endregion

        #region 执行一个语句，返回执行情况
        /// <summary>
        /// 执行一个语句，返回执行情况
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <returns></returns>
        public abstract int DoCommand(IDbCommand cmd);
        /// <summary>
        /// 执行一个语句，返回执行情况
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeOut">超时时间</param>
        /// <returns></returns>
        public abstract int DoCommand(string procedureName, ParameterEx[] parameters, int timeOut);
        /// <summary>
        /// 执行一个语句，返回执行情况
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <returns></returns>
        public abstract int DoCommand(string commandtext);
        /// <summary>
        /// 执行一个语句，返回执行情况
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public abstract int DoCommand(string commandtext, int timeOut);
        /// <summary>
        /// 执行一批命令，并进行事务处理
        /// </summary>
        /// <param name="storeProcedureNameArray">存储过程名称组</param>
        /// <param name="parametersArray">参数集合组</param>
        /// <param name="tiemOutArray">超时限制数组</param>
        /// <param name="commandTexts">SQL语句字符串组</param>
        /// <returns></returns>
        public abstract int DoCommand(string[] storeProcedureNameArray, ParameterEx[][] parametersArray, int[] tiemOutArray, string[] commandTexts);
        #endregion

        #region 执行一个命令返回一个数据结果
        /// <summary>
        /// 执行一个命令返回一个数据结果
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <returns></returns>
        public abstract object GetDataResult(IDbCommand cmd);
        /// <summary>
        /// 执行一个命令返回一个数据结果
        /// </summary>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeOut">超时时间</param>
        /// <returns></returns>
        public abstract object GetDataResult(string procedureName, ParameterEx[] parameters, int timeOut);
        /// <summary>
        /// 执行一个命令返回一个数据结果
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <returns></returns>
        public abstract object GetDataResult(string commandtext);
        /// <summary>
        /// 执行一个命令返回一个数据结果
        /// </summary>
        /// <param name="commandtext">SQL语句字符串</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public abstract object GetDataResult(string commandtext, int timeOut);
        #endregion

        #region 用数据适配器填充一个数据集中一个表
        /// <summary>
        /// 用数据适配器填充一个数据集中一个表
        /// </summary>
        /// <param name="storeProcedureName">存储过程名</param>
        /// <param name="parameters">参数名</param>
        /// <param name="ds">要填充的dataset</param>
        /// <param name="tableName">表明</param>
        /// <param name="timeOut"></param>
        public abstract void AdapterFillDataSet(string storeProcedureName, ParameterEx[] parameters, DataSet ds, string tableName, int timeOut);
        /// <summary>
        /// 用数据适配器填充一个数据集中一个表
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="ds">要填充的dataset</param>
        /// <param name="tableName">表名</param>
        /// <param name="timeOut"></param>
        public abstract void AdapterFillDataSet(string commandText, DataSet ds, string tableName, int timeOut);
        #endregion

        /// <summary>
        /// 用数据适配器填充一个数据集--加密的方法，屏蔽数据库跟踪器
        /// 2013-1-31 增加
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="ds"></param>
        /// <param name="timeout"></param>
        /// <param name="BeginTransaction">自动开启事务</param>
        public virtual void AdapterFillDataSet_Encryption(string commandText, DataSet ds, int timeout, bool AutoTransaction)
        {
            try
            {

                if (AutoTransaction) this.BeginTransaction();
                string strProcedure_drop = @"
                        IF EXISTS (SELECT name FROM   sysobjects WHERE  name = N'{0}' 
	                    AND 	  type = 'P')
                        DROP PROCEDURE {0}
                        
                        ";
                string strProcedure_create = @" 

                        CREATE PROCEDURE [dbo].{0}   
                        with encryption
                        as 
                        begin
                        {1}
                        DROP PROCEDURE [dbo].{0}
                        end
                        ";


                string strProcedure_name = "SP_tmp_" + Guid.NewGuid().ToString().Replace("-", "_");
                strProcedure_create = string.Format(strProcedure_create, new object[] { strProcedure_name, commandText });
                strProcedure_drop = string.Format(strProcedure_drop, new object[] { strProcedure_name });

                try
                {
                    this.DoCommand(strProcedure_drop);
                    this.DoCommand(strProcedure_create);
                    DbDataAdapter adapter = this.GetAdapter(" exec " + strProcedure_name, timeout);

                    adapter.Fill(ds);
                    adapter.Dispose();

                    this.CommitTransaction();


                }
                catch
                {
                    if (AutoTransaction) this.RollbackTransaction();
                    throw new Exception("AdapterFillDataSet_Encryption:加密运行脚本出错");

                }
                finally
                {

                    this.DoCommand(strProcedure_drop);
                }



            }
            catch (Exception err)
            {
                throw new Exception("AdapterFillDataSet_Encryption:" + err.Message);
            }
        }

        #region /*属性*/
        //Add By Tany 2009-12-02
        /// <summary>
        /// 返回数据库当前状态
        /// </summary>
        public ConnectionState ConnectionStates
        {
            get { return connection.State; }
        }
        /// <summary>
        /// 返回数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return this.cnnString; }
        }
        /// <summary>
        /// 返回或设置数据库名
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 返回是否处于事务中
        /// </summary>
        public bool IsInTransaction
        {
            get { return this.isInTransaction; }
        }

        /// <summary>
        /// 返回或设置数据库平台名
        /// </summary>
        public string Vendor
        {
            get { return this._vendor; }
            set { this._vendor = value; }
        }
        /// <summary>
        /// 返回或设置左边引号
        /// </summary>
        public string QuotationMarksStart
        {
            get { return this._quotationMarksStart; }
            set { this._quotationMarksStart = value; }
        }
        /// <summary>
        /// 返回或设置右边引号
        /// </summary>
        public string QuotationMarksEnd
        {
            get { return this._quotationMarksEnd; }
            set { this._quotationMarksEnd = value; }
        }

        #endregion

        #region 存储过程参数赋值与回传参数
        /// <summary>
        /// 存储过程设置参数
        /// </summary>
        /// <param name="cmd">IDbCommand</param>
        /// <param name="parameters">ParameterEx[]</param>
        public void SetParameters(IDbCommand cmd, ParameterEx[] parameters)
        {
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].DataType == null)
                    {
                        if (parameters[i].ParaDirection == null && parameters[i].ParaSize == null)
                            cmd.Parameters.Add(this.GetParameter(parameters[i].Text, parameters[i].Value));
                        else if (parameters[i].ParaSize == null)
                            cmd.Parameters.Add(this.GetParameter(parameters[i].Text, parameters[i].Value, (ParameterDirection)parameters[i].ParaDirection));
                        else
                            cmd.Parameters.Add(this.GetParameter(parameters[i].Text, parameters[i].Value, (ParameterDirection)parameters[i].ParaDirection, (int)parameters[i].ParaSize));
                    }
                    else
                    {
                        if (parameters[i].ParaSize == null && parameters[i].DataType.ToString() == DbType.String.ToString())
                            throw new EntityException("参数设置错误");
                        else if (parameters[i].ParaDirection == null)
                        {
                            if (parameters[i].ParaSize != null)
                                cmd.Parameters.Add(this.GetParameter(parameters[i].Text, parameters[i].DataType, (int)parameters[i].ParaSize, parameters[i].Value));
                            else
                                cmd.Parameters.Add(this.GetParameter(parameters[i].Text, parameters[i].Value));
                        }
                        else
                        {
                            IDbDataParameter par = GetParameter(parameters[i].Text, parameters[i].Value);
                            par.DbType = (DbType)parameters[i].DataType;
                            par.Direction = (ParameterDirection)parameters[i].ParaDirection;
                            if (parameters[i].ParaSize != null)
                                par.Size = (int)parameters[i].ParaSize;
                            cmd.Parameters.Add(par);
                            //							cmd.Parameters.Add(this.GetParameter(parameters[i].Text, parameters[i].Value, (ParameterDirection)parameters[i].ParaDirection,
                            //								(int)parameters[i].ParaSize, parameters[i].DataType));
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 存储过程回传参数
        /// </summary>
        /// <param name="cmd">IDbCommand</param>
        /// <param name="parameters">ParameterEx[]</param>
        public void ReturnParameters(IDbCommand cmd, ParameterEx[] parameters)
        {
            if (parameters != null)
            {
                Type oleDbType = typeof(TrasenClasses.DatabaseAccess.OleDB);
                Type msSqlType = typeof(TrasenClasses.DatabaseAccess.MsSqlServer);
                for (int i = 0; i < parameters.GetLength(0); i++)		//回传参数值
                {
                    if (this.GetType() == oleDbType || this.GetType().IsSubclassOf(oleDbType))
                    {
                        parameters[i].Value = ((OleDbParameter)cmd.Parameters[i]).Value;
                    }
                    else if (this.GetType() == msSqlType || this.GetType().IsSubclassOf(msSqlType))
                    {
                        parameters[i].Value = ((SqlParameter)cmd.Parameters[i]).Value;
                    }
                    else
                    {
                        throw new EntityException("未知数据库类型");
                    }
                }
            }
        }
        #endregion



    }
}