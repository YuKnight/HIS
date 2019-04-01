using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.DatabaseAccess
{

    /*
     * jianqg 2013-5-16 增加 为的是 处理数据库断了可以自连,必须在每个方法起始位置调用
     * 
     */ 

    /// <summary>
    /// MsSqlServer 的摘要说明。
    /// </summary>
    public class MsSqlServer : RelationalDatabase
    {
        /// <summary>
        /// 数据库平台名称
        /// </summary>
        protected const string VENDOR_NAME = "MsSqlServer";

        /// <summary>
        /// 构造一MsSqlServer
        /// </summary>
        public MsSqlServer()
        {
            this.Vendor = VENDOR_NAME;
        }

        private MsSqlServer(string name, string connectionString)
        {
            this.Vendor = VENDOR_NAME;
            this.cnnString = connectionString;
            this.connection = new SqlConnection(connectionString);
            this.Name = name;
        }

        #region 实现基类的抽象方法

        public override ConnectType ConnectionType
        {
            get
            {
                return ConnectType.SQLSERVER;
            }
        }

        #region //创建一个CommandBuilder
        /// <summary>
        /// 返回一个CommandBuilder
        /// </summary>
        /// <param name="_adapter">数据适配器</param>
        public override void CreateCommandBuilder(IDataAdapter _adapter)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder((SqlDataAdapter)_adapter);
        }
        #endregion

        #region //获取参数
        /// <summary>
        /// 返回一个参数对象
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="values">参数值</param>
        /// <returns></returns>
        public override IDbDataParameter GetParameter(string parameterName, object values)
        {
            return new SqlParameter(parameterName, values);
        }
        /// <summary>
        /// 返回一个参数对象
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="dataType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <returns></returns>
        public override IDbDataParameter GetParameter(string parameterName, object dataType, int size)
        {
            return new SqlParameter(parameterName, (SqlDbType)dataType, size);
        }
        /// <summary>
        /// 返回一个参数对象
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="dataType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <param name="values">参数值</param>
        /// <returns></returns>
        public override IDbDataParameter GetParameter(string parameterName, object dataType, int size, object values)
        {
            IDbDataParameter para = new SqlParameter(parameterName, (SqlDbType)dataType, size);
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
        public override IDbDataParameter GetParameter(string parameterName, object values, ParameterDirection direction)
        {
            IDbDataParameter para = new SqlParameter();
            para.ParameterName = parameterName;
            para.Value = values;
            para.Direction = direction;
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
        public override IDbDataParameter GetParameter(string parameterName, object values, ParameterDirection direction, int size)
        {
            IDbDataParameter para = new SqlParameter();
            para.ParameterName = parameterName;
            para.Value = values;
            para.Direction = direction;
            para.Size = size;
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
        public override IDbDataParameter Getparameter(string parameterName, object values, ParameterDirection direction, int size, object dataType)
        {
            IDbDataParameter para = new SqlParameter(parameterName, (SqlDbType)dataType, size);
            para.Direction = direction;

            return para;
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
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (cmd.CommandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(cmd.CommandText);

            int result = 0;
            if (isInTransaction) cmd.Transaction = transaction;
            //2013-7-24 jianqg 增加
            if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;


            cmd.Connection = connection;
            result = cmd.ExecuteNonQuery();
            return result;
        }
        /// <summary>
        /// 执行一个语句，返回执行情况
        /// </summary>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeOut">超时时间</param>
        /// <returns></returns>
        public override int DoCommand(string procedureName, ParameterEx[] parameters, int timeOut)
        {
            int result = 0;
            SqlException("");//jianqg 2013-5-16 增加  改行，为的是 处理数据库断了可以自连
            IDbCommand cmd = this.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            //if (timeOut > 30) cmd.CommandTimeout = timeOut;
            //2013-7-24 jianqg 修改
            if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
            else cmd.CommandTimeout = CON_TIMEOUT;
            if (isInTransaction) cmd.Transaction = transaction;
            cmd.Connection = connection;
            if (parameters != null && parameters.Length > 0)
            {
                this.SetParameters(cmd, parameters);
            }
            try
            {
                result = cmd.ExecuteNonQuery();
                //回传参数
                if (parameters != null && parameters.Length > 0)
                {
                    ReturnParameters(cmd, parameters);
                }

                return result;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + "过程：" + procedureName);
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
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程
            SqlException(commandText);

            int result = 0;
            SqlCommand cmd = new SqlCommand(commandText);
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            cmd.Connection = (SqlConnection)connection;
            try
            {
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + "命令：" + commandText);
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
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public override int DoCommand(string commandText, int timeOut)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(commandText);

            int result = 0;
            SqlCommand cmd = new SqlCommand(commandText);
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            cmd.Connection = (SqlConnection)connection;
            //if (timeOut > 30) cmd.CommandTimeout = timeOut;
            //2013-7-24 jianqg 修改
            if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
            else cmd.CommandTimeout = CON_TIMEOUT;
            try
            {
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + "命令：" + commandText);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
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

            int result = 0;
            SqlException("");//jianqg 2013-5-16 增加  改行，为的是 处理数据库断了可以自连
            //开始一个事物
            this.BeginTransaction();
            try
            {
                int i;
                if (storeProcedureNameArray != null)
                {
                    IDbCommand cmd = null;
                    for (i = 0; i < storeProcedureNameArray.GetLength(0); i++)
                    {
                        if (storeProcedureNameArray[i] != "")
                        {
                            cmd = this.GetCommand();
                            cmd.CommandText = storeProcedureNameArray[i];
                            cmd.CommandType = CommandType.StoredProcedure;
                            //参数赋值
                            SetParameters(cmd, parametersArray[i]);

                            if (tiemOutArray != null)
                            {
                                //if (tiemOutArray[i] > 30)					//默认为30秒
                                //{
                                //    cmd.CommandTimeout = tiemOutArray[i];
                                //}
                                //if (timeOut > 30) cmd.CommandTimeout = timeOut;
                                //2013-7-24 jianqg 修改
                                if (tiemOutArray[i] > CON_TIMEOUT) cmd.CommandTimeout = tiemOutArray[i];
                                else cmd.CommandTimeout = CON_TIMEOUT;
                            }
                            this.DoCommand(cmd);
                            //回传数据
                            ReturnParameters(cmd, parametersArray[i]);

                        }
                    }
                    cmd.Dispose();
                    cmd = null;
                }
                if (commandTexts != null)
                {
                    for (i = 0; i < commandTexts.GetLength(0); i++)
                    {
                        if (commandTexts[i] != null)
                        {
                            if (commandTexts[i] != "")
                            {
                                ////Modify By Tany 2012-02-13 避免SQL注入
                                //string[] array = { ";" };//{ ";", "--" };
                                //for (int j = 0; j < array.Length; j++)
                                //{
                                //    if (commandTexts[i].IndexOf(array[j]) >= 0)
                                //    {
                                //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[j] + "】");
                                //    }
                                //}
                                ////End
                                //避免SQL注入 改调用公共过程 2012-10-7
                                SqlException(commandTexts[i]);

                                DoCommand(commandTexts[i]);
                            }
                        }
                    }
                }
                //提交事务
                CommitTransaction();
                return result;
            }
            catch (Exception err)
            {
                //回滚事务
                this.RollbackTransaction();
                throw new Exception("DoCommand\\DatabaseAccess\\" + err.Message);
            }
        }

        //private int _ExecuteNonQuery( SqlCommand cmd )
        //{
        //    int result = cmd.ExecuteNonQuery();
        //}

        #endregion

        #region //执行一个命令返回一个数据结果
        /// <summary>
        /// 执行一个命令返回一个数据结果
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <returns></returns>
        public override object GetDataResult(IDbCommand cmd)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (cmd.CommandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(cmd.CommandText);

            object Result = null;
            if (isInTransaction) cmd.Transaction = transaction;
            cmd.Connection = connection;
            //2013-7-24 jianqg 增加
            if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;

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
            object Result = null;
            SqlException("");//jianqg 2013-5-16 增加  改行，为的是 处理数据库断了可以自连
            IDbCommand cmd = this.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            //if (timeOut > 30) cmd.CommandTimeout = timeOut;
            //2013-7-24 jianqg 修改
            if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
            else cmd.CommandTimeout = CON_TIMEOUT;
            if (parameters != null && parameters.Length > 0)
            {
                this.SetParameters(cmd, parameters);
            }
            if (isInTransaction) cmd.Transaction = transaction;
            cmd.Connection = connection;
            try
            {
                Result = cmd.ExecuteScalar();
                if (parameters != null && parameters.Length > 0)
                {
                    ReturnParameters(cmd, parameters);
                }
                return Result;
            }
            catch (Exception err)
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
        /// 执行一个命令返回一个数据结果
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <returns></returns>
        public override object GetDataResult(string commandText)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(commandText);

            object Result = null;
            SqlCommand cmd = new SqlCommand(commandText);
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            cmd.Connection = (SqlConnection)connection;
            //2013-7-24 jianqg 增加
            if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;

            try
            {
                Result = cmd.ExecuteScalar();
                return Result;
            }
            catch (Exception err)
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
        /// 执行一个命令返回一个数据结果
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public override object GetDataResult(string commandText, int timeOut)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End

            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(commandText);

            object Result = null;
            SqlCommand cmd = new SqlCommand(commandText);
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            cmd.Connection = (SqlConnection)connection;
            //if (timeOut > 30) cmd.CommandTimeout = timeOut;
            //2013-7-24 jianqg 修改
            if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
            else cmd.CommandTimeout = CON_TIMEOUT;
            try
            {
                Result = cmd.ExecuteScalar();
                return Result;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
            }
        }
        #endregion

        #region //写入一条记录
        /// <summary>
        /// 执行插入一条记录 适用于有 自动生成标识的列
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <param name="identity">自动增长列在插入记录是产生的序号</param>
        /// <returns></returns>
        public override int InsertRecord(IDbCommand cmd, out object identity)
        {
            int result = 0;
            SqlException(cmd.CommandText);//jianqg 2013-5-16 增加  改行，为的是 处理数据库断了可以自连
            try
            {
                if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
                cmd.Connection = connection;
                //2013-7-24 jianqg 增加
                if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;
                result = cmd.ExecuteNonQuery();

                IDbCommand _cmd = this.GetCommand();
                _cmd.CommandText = GetIdentityString();
                _cmd.CommandType = CommandType.Text;
                if (isInTransaction) _cmd.Transaction = (SqlTransaction)transaction;
                //2013-7-24 jianqg 增加
                if (_cmd.CommandTimeout < CON_TIMEOUT) _cmd.CommandTimeout = CON_TIMEOUT;
                object objIdent = _cmd.ExecuteScalar();
                if (!Convert.IsDBNull(objIdent))
                {
                    identity = Convert.ToInt32(objIdent);
                }
                else
                    identity = null;
                _cmd.Dispose();
                _cmd = null;
            }
            catch (Exception err)
            {
                throw new Exception("InsertRecord\\" + err.Message + cmd.CommandText);
            }
            return result;
        }
        /// <summary>
        /// 执行插入一条记录 适用于有 自动生成标识的列
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <param name="identity">自动增长列在插入记录是产生的序号</param>
        /// <returns></returns>
        public override int InsertRecord(string commandText, out object identity)
        {
            int result = 0;
            SqlException(commandText);//jianqg 2013-5-16 增加  改行，为的是 处理数据库断了可以自连
            SqlCommand cmd = new SqlCommand(commandText);
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            cmd.Connection = (SqlConnection)connection;
            try
            {
                //2013-7-24 jianqg 增加
                if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;
                result = cmd.ExecuteNonQuery();

                IDbCommand _cmd = this.GetCommand();
                _cmd.CommandText = GetIdentityString();
                _cmd.CommandType = CommandType.Text;
                if (isInTransaction) _cmd.Transaction = (SqlTransaction)transaction;
                //2013-7-24 jianqg 增加
                if (_cmd.CommandTimeout < CON_TIMEOUT) _cmd.CommandTimeout = CON_TIMEOUT;
                object objIdent = _cmd.ExecuteScalar();
                if (!Convert.IsDBNull(objIdent))
                {
                    identity = Convert.ToInt32(objIdent);
                }
                else
                    identity = null;
                _cmd.Dispose();
                _cmd = null;
                return result;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + commandText);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
            }
        }
        /// <summary>
        /// 执行插入一条记录 适用于有 自动生成标识的列
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <param name="identity">自动增长列在插入记录是产生的序号</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public override int InsertRecord(string commandText, out object identity, int timeOut)
        {
            int result = 0;
            SqlException(commandText);//jianqg 2013-5-16 增加  改行，为的是 处理数据库断了可以自连
            SqlCommand cmd = new SqlCommand(commandText);
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            cmd.Connection = (SqlConnection)connection;
            //if (timeOut > 30) cmd.CommandTimeout = timeOut;
            //2013-7-24 jianqg 修改
            if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
            else cmd.CommandTimeout = CON_TIMEOUT;
            try
            {
                result = cmd.ExecuteNonQuery();

                IDbCommand _cmd = this.GetCommand();
                _cmd.CommandText = GetIdentityString();
                _cmd.CommandType = CommandType.Text;
                if (isInTransaction) _cmd.Transaction = (SqlTransaction)transaction;
                object objIdent = _cmd.ExecuteScalar();
                if (!Convert.IsDBNull(objIdent))
                {
                    identity = Convert.ToInt32(objIdent);
                }
                else
                    identity = null;
                _cmd.Dispose();
                _cmd = null;
                return result;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + commandText);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
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
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (cmd.CommandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(cmd.CommandText);

            cmd.Connection = this.connection;
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            //2013-7-24 jianqg 增加
            if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;
            SqlDataAdapter adapter = new SqlDataAdapter((SqlCommand)cmd);

            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message + cmd.CommandText);
            }
            finally
            {
                adapter.Dispose();
            }
        }
        /// <summary>
        /// 返回一个DataTable
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <returns></returns>
        public override DataTable GetDataTable(string commandText)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(commandText);

            SqlCommand cmd = new SqlCommand(commandText);
            cmd.Connection = (SqlConnection)this.connection;
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            //2013-7-24 jianqg 增加
            if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;
            SqlDataAdapter adapter = new SqlDataAdapter((SqlCommand)cmd);

            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message + commandText);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                adapter.Dispose();
                adapter = null;
            }
        }
        /// <summary>
        /// 返回一个DataTable
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public override DataTable GetDataTable(string commandText, int timeOut)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(commandText);

            SqlCommand cmd = new SqlCommand(commandText);
            cmd.Connection = (SqlConnection)this.connection;
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            //if (timeOut > 30) cmd.CommandTimeout = timeOut;
            //2013-7-24 jianqg 修改
            if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
            else cmd.CommandTimeout = CON_TIMEOUT;
            SqlDataAdapter adapter = new SqlDataAdapter((SqlCommand)cmd);

            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message + commandText);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                adapter.Dispose();
                adapter = null;
            }
        }
        /// <summary>
        /// 返回一个DataTable
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="parameters">参数名称</param>
        /// <returns></returns>
        public override DataTable GetDataTable(string procedureName, ParameterEx[] parameters)
        {
            SqlException("");//jianqg 2013-5-16 增加  改行，为的是 处理数据库断了可以自连
            IDbCommand cmd = this.GetCommand();
            cmd.Connection = this.connection;
            //2013-7-24 jianqg 增加
            if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            if (parameters != null && parameters.Length > 0)
            {
                SetParameters(cmd, parameters);
            }
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;

            SqlDataAdapter adapter = new SqlDataAdapter((SqlCommand)cmd);

            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                ReturnParameters(cmd, parameters);
                return dt;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message +"过程：" + procedureName);
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
        public override DataTable GetDataTable(string procedureName, ParameterEx[] parameters, int timeOut)
        {
            SqlException("");//jianqg 2013-5-16 增加  改行，为的是 处理数据库断了可以自连
            IDbCommand cmd = this.GetCommand();
            cmd.Connection = this.connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            //if (timeOut > 30) cmd.CommandTimeout = timeOut;
            //2013-7-24 jianqg 修改
            if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
            else cmd.CommandTimeout = CON_TIMEOUT;

            if (parameters != null && parameters.Length > 0)
                SetParameters(cmd, parameters);

            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;

            SqlDataAdapter adapter = new SqlDataAdapter((SqlCommand)cmd);

            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                ReturnParameters(cmd, parameters);
                return dt;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message + "过程：" + procedureName);
            }
            finally
            {
                cmd.Dispose();
                adapter.Dispose();
            }
        }
        #endregion

        #region //返回一个SqlDataAdpter
        /// <summary>
        ///  返回一个IDataAdpter 
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <returns></returns>
        public override DbDataAdapter GetAdapter(IDbCommand cmd)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (cmd.CommandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(cmd.CommandText);
            //2013-7-24 jianqg 增加
            if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = (SqlCommand)cmd;
            cmd.Connection = connection;

            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            return adapter;
        }
        /// <summary>
        ///  返回一个IDataAdpter 
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <returns></returns>	
        public override DbDataAdapter GetAdapter(string commandText)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(commandText);

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(commandText);
            //2013-7-24 jianqg 增加
            if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;

            adapter.SelectCommand = (SqlCommand)cmd;
            cmd.Connection = (SqlConnection)connection;
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            return adapter;
        }
        /// <summary>
        ///  返回一个IDataAdpter 
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public override DbDataAdapter GetAdapter(string commandText, int timeOut)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(commandText);

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(commandText);
            //if (timeOut > 30) cmd.CommandTimeout = timeOut;
            //2013-7-24 jianqg 修改
            if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
            else cmd.CommandTimeout = CON_TIMEOUT;

            adapter.SelectCommand = (SqlCommand)cmd;
            cmd.Connection = (SqlConnection)connection;

            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            return adapter;
        }
        #endregion

        #region //返回一行数据
        /// <summary>
        /// 返回一个DataRow
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <returns></returns>
        public override DataRow GetDataRow(IDbCommand cmd)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (cmd.CommandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(cmd.CommandText);

            cmd.Connection = this.connection;				//添加连接
            DataRow r;
            //2013-7-24 jianqg 增加
            if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = (SqlCommand)cmd;
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            try
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    r = dt.Rows[0];
                }
                else
                {
                    r = null;
                }
                return r;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + cmd.CommandText);
            }
            finally
            {
                adapter.Dispose();
                adapter = null;
            }
        }
        /// <summary>
        /// 返回一个DataRow
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <returns></returns>
        public override DataRow GetDataRow(string commandText)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(commandText);

            SqlCommand cmd = new SqlCommand(commandText);
            cmd.Connection = (SqlConnection)this.connection;				//添加连接
            DataRow r;
            //2013-7-24 jianqg 增加
            if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = (SqlCommand)cmd;
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            try
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    r = dt.Rows[0];
                }
                else
                {
                    r = null;
                }
                return r;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + commandText);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                adapter.Dispose();
                adapter = null;
            }
        }
        /// <summary>
        /// 返回一个DataRow
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public override DataRow GetDataRow(string commandText, int timeOut)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(commandText);

            SqlCommand cmd = new SqlCommand(commandText);
            cmd.Connection = (SqlConnection)this.connection;				//添加连接
            //if (timeOut > 30) cmd.CommandTimeout = timeOut;
            //2013-7-24 jianqg 修改
            if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
            else cmd.CommandTimeout = CON_TIMEOUT;
            DataRow r;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = (SqlCommand)cmd;
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            try
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    r = dt.Rows[0];
                }
                else
                {
                    r = null;
                }
                return r;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + commandText);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                adapter.Dispose();
                adapter = null;
            }
        }
        /// <summary>
        /// 获取数据行
        /// </summary>
        /// <param name="procedurName"></param>
        /// <param name="parameters"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public override DataRow GetDataRow(string procedurName, ParameterEx[] parameters, int timeOut)
        {
            SqlException("");//jianqg 2013-5-16 增加  改行，为的是 处理数据库断了可以自连
            IDbCommand cmd = this.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedurName;
            //if (timeOut > 30) cmd.CommandTimeout = timeOut;
            //2013-7-24 jianqg 修改
            if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
            else cmd.CommandTimeout = CON_TIMEOUT;
            cmd.Connection = this.connection;				//添加连接
            DataRow r;

            if (parameters != null && parameters.Length > 0)
            {
                this.SetParameters(cmd, parameters);
            }

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = (SqlCommand)cmd;
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            try
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    r = dt.Rows[0];
                }
                else
                {
                    r = null;
                }
                if (parameters != null && parameters.Length > 0)
                {
                    this.ReturnParameters(cmd, parameters);
                }
                return r;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + "过程：" + procedurName);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                adapter.Dispose();
                adapter = null;
            }
        }

        #endregion

        #region //取得一个DataReader 返回一个数据读取器
        /// <summary>
        /// 返回一个DataReader
        /// </summary>
        /// <param name="cmd">IDbCommand对象</param>
        /// <returns></returns>
        public override IDataReader GetDataReader(IDbCommand cmd)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (cmd.CommandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            System.Data.SqlClient.SqlDataReader reader;
            try
            {
                SqlException(cmd.CommandText);
                //2013-7-24 jianqg 增加
                if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;
                cmd.Connection = this.connection;
                if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;

                reader = (SqlDataReader)cmd.ExecuteReader();
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + cmd.CommandText);
            }
            return reader;
        }
        /// <summary>
        /// 返回一个DataReader
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <returns></returns>
        public override IDataReader GetDataReader(string commandText)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(commandText);

            SqlCommand cmd = new SqlCommand(commandText);
            //2013-7-24 jianqg 增加
            if (cmd.CommandTimeout < CON_TIMEOUT) cmd.CommandTimeout = CON_TIMEOUT;
            cmd.Connection = (SqlConnection)this.connection;
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            try
            {
                SqlDataReader reader = (SqlDataReader)cmd.ExecuteReader();
                return reader;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + commandText);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
            }
        }
        /// <summary>
        /// 返回一个DataReader
        /// </summary>
        /// <param name="commandText">SQL语句字符串</param>
        /// <param name="timeOut">超时限制</param>
        /// <returns></returns>
        public override IDataReader GetDataReader(string commandText, int timeOut)
        {
            ////Modify By Tany 2012-02-13 避免SQL注入
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (commandText.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            ////End
            //避免SQL注入 改调用公共过程 2012-10-7
            SqlException(commandText);

            SqlCommand cmd = new SqlCommand(commandText);
            cmd.Connection = (SqlConnection)this.connection;
            //if (timeOut > 30) cmd.CommandTimeout = timeOut;
            //2013-7-24 jianqg 修改
            if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
            else cmd.CommandTimeout = CON_TIMEOUT;
            if (isInTransaction) cmd.Transaction = (SqlTransaction)transaction;
            try
            {
                SqlDataReader reader = (SqlDataReader)cmd.ExecuteReader();
                return reader;
            }
            catch (Exception err)
            {
                throw new EntityException(err.Message + commandText);
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
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
                SqlException("");//jianqg 2013-5-16 增加  改行，为的是 处理数据库断了可以自连
                IDbCommand cmd = this.GetCommand();
                cmd.CommandText = storeProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                //参数赋值
                if (parameters != null && parameters.Length > 0)
                    SetParameters(cmd, parameters);

                //if (timeOut > 30) cmd.CommandTimeout = timeOut;
                //2013-7-24 jianqg 修改
                if (timeOut > CON_TIMEOUT) cmd.CommandTimeout = timeOut;
                else cmd.CommandTimeout = CON_TIMEOUT;
                DbDataAdapter adapter = this.GetAdapter(cmd);
                //回传数据 Modify By Tany 2010-01-30
                //if (parameters != null && parameters.Length > 0)
                //    ReturnParameters(cmd, parameters);

                adapter.Fill(ds, tableName);

                //回传数据 Modify By Tany 2010-01-30
                if (parameters != null && parameters.Length > 0)
                    ReturnParameters(cmd, parameters);

                adapter.Dispose();
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception err)
            {
                throw new Exception("AdapterFillDataSet\\DatabaseAccess" + err.Message + "过程：" + storeProcedureName);
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
                SqlException(commandText);//jianqg 2013-5-16 增加  改行，为的是 处理数据库断了可以自连
                DbDataAdapter adapter = this.GetAdapter(commandText, timeOut);
                adapter.Fill(ds, tableName);
                adapter.Dispose();
            }
            catch (Exception err)
            {
                throw new Exception("AdapterFillDataSet\\DatabaseAccess" + err.Message + commandText );
            }
        }

        #endregion
        /// <summary>
        /// 获取服务器时间的SQL语句
        /// </summary>
        /// <returns></returns>
        public override string GetIdentityString()
        {
         
            return "SELECT @@IDENTITY ";
        }
        /// <summary>
        /// 获取服务器时间的SQL语句
        /// </summary>
        /// <returns></returns>
        public override string GetServerTimeString()
        {

            return "SELECT GETDATE()";
        }

        /// <summary>
        /// 初始化数据库（刚被初始化的数据库的连接是打开的）
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public override void Initialize(string connectionString)
        {

            cnnString = connectionString;
            try
            {
                //获得连接
                SqlConnection cnn = new SqlConnection(cnnString);
                this.connection = cnn;
                this.connection.Open();
            }
            catch (Exception e)
            {
                throw new EntityException("连接数据库失败！参考：" + e.Message, ErrorTypes.DatabaseUnknownError);
            }
        }
        /// <summary>
        /// 返回参数的字符串形式
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public override string GetStringParameter(string name)
        {
            return "@" + name;
        }
        /// <summary>
        /// 返回数据类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override SqlValueTypes SqlValueType(DbType type)
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
        public override string GetName(string name)
        {
            return this.QuotationMarksStart + name + this.QuotationMarksEnd;
        }
        /// <summary>
        /// 获取该对象副本
        /// </summary>
        /// <returns></returns>
        public override RelationalDatabase GetCopy()
        {
            return new MsSqlServer(this.Name, this.cnnString);
        }

        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="e">异常</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public override ErrorTypes ErrorHandler(Exception e, out string message)
        {
            message = "";
            if (e is SqlException)
            {
                SqlException sqlErr = (SqlException)e;
                int j = 0;
                for (j = 0; j < sqlErr.Errors.Count; j++)
                {
                    if (sqlErr.Errors[j].Number != 3621) break;
                }
                switch (sqlErr.Errors[j].Number)
                {
                    case 2627:
                        message = "数据重复！";
                        return ErrorTypes.NotUnique;
                    case 8152:
                        return ErrorTypes.DataTooLong;
                    //					case -541396598 :
                    //						message = "参考：" + oleErr.Message;
                    //						return ErrorTypes.NotAllowStringEmpty;
                    case 515:
                        message = "参考：" + sqlErr.Message;
                        return ErrorTypes.NotAllowDataNull;
                    case 0:
                        return ErrorTypes.DataTypeNotMatch;
                    case 544:
                        message = "参考：" + sqlErr.Message;
                        return ErrorTypes.AutoValueOn;
                    case 547:
                        message = "参考：" + sqlErr.Message;
                        return ErrorTypes.RestrictError;

                }
                message = "数据库操作异常:";
                for (int i = 0; i < sqlErr.Errors.Count; i++)
                {
                    message += "Index #" + i + "\n" +
                        "Message: " + sqlErr.Message + "\n" +
                        "Native: " + sqlErr.Errors[i].Number.ToString() + "\n" +
                        "Source: " + sqlErr.Errors[i].Source + "\n";
                }
                return ErrorTypes.DatabaseUnknownError;
            }
            else
            {
                message = "";
                return ErrorTypes.Unknown;
            }
        }
        #endregion


        #region 避免SQL注入 jianqg 2012-10-7 做成公用过程
        /// <summary>
        /// 避免SQL注入 jianqg 2012-10-7 做成公用过程
        /// </summary>
        public void SqlException(string strSql)
        {
            SqlAutoConnect();
            //Modify By Tany 2012-02-13 避免SQL注入
            //jianqg 2012-10-7因为框架合并，需要升级本类，暂时注释
            //string[] array = { ";" };//{ ";", "--" };
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (strSql.IndexOf(array[i]) >= 0)
            //    {
            //        throw new Exception("需执行的SQL语句中含有非法字符，请检查！【" + array[i] + "】");
            //    }
            //}
            //End

           


        }
        #endregion
        /// <summary>
        /// 覆盖基类的BeginTransaction 增加处理关于事务中的数据库连接断了 2013-6-9
        /// </summary>
        public override void BeginTransaction()
        {
            if ((connection == null) || (connection.State == ConnectionState.Closed))
            {
                throw new EntityException("数据库未打开或未初始化！");
            }
            else
            {
                SqlAutoConnect(); //增加处理关于事务中的数据库连接断了 2013-6-9
                transaction = connection.BeginTransaction();
                isInTransaction = true;
            }

        }

        #region SqlAutoConnect
        /// <summary>
        /// /jianqg 2013-5-16 增加 为的是 处理数据库断了可以自连
        /// </summary>
        private void SqlAutoConnect()
        {
           
            //return; //2013-7-16 不自动连接 ，看是否有问题
            //jianqg 2013-5-16 增加 为的是 处理数据库断了可以自连
            if (this.connection != null && this.ConnectionString != null)
            {

                try
                {
                    //if (isInTransaction == false)  //增加处理关于事务中的数据库连接断了 2013-6-9
                    //{
                    //    IDbTransaction transactionTmp=connection.BeginTransaction();
                    //     if (transactionTmp != null)
                    //     {
                    //        transactionTmp.Rollback();
                    //        transactionTmp = null;
                    //     }

                    //}
                    //jianqg 2013-6-19 修改 为 原来使用事务判断，现改为 取时间判断





                    //SqlCommand cmd = new SqlCommand(GetServerTimeString());
                    //if (cmd != null)
                    //{
                    //    cmd.Connection = (SqlConnection)this.connection;
                    //    cmd.ExecuteNonQuery();
                    //    cmd.Dispose();
                    //    cmd = null;
                    //}
                    // 2013-6-27 jianqg x修改 因为发送消息时 已有打开的与此命令相关联的 DataReader，必须首先将它关闭。

                    using ( SqlCommand cmd = new SqlCommand( GetServerTimeString() , (SqlConnection)this.connection ) )
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter( cmd );
                        DataTable dt = new DataTable();
                        adapter.Fill( dt );
                        dt.Dispose();
                        dt = null;
                        adapter.Dispose();
                        adapter = null;
                        cmd.Dispose();

                    }

                    //在向服务器发送请求时发生传输级错误。 (provider: TCP 提供程序, error: 0 - 远程主机强迫关闭了一个现有的连接。)
                    //在向服务器发送请求时发生传输级错误。 (provider: 共享内存提供程序, error: 0 - 管道的另一端上无任何进程。)

                }        
                catch ( Exception ex )
                {
                    string strMsg = ex.Message;
                    if ( this.connection.State == ConnectionState.Closed || ( this.connection.State == ConnectionState.Open && strMsg.Contains( "closed by the remote host an existing connection" ) 
                        || strMsg.Contains( "远程主机强迫关闭了一个现有的连接" ) ) 
                        || strMsg.Contains( "管道的另一端上无任何进程")
                        )
                    {
                        try
                        {
                            if ( this.connection != null && this.ConnectionString != null && this.connection.State == ConnectionState.Closed )
                                this.connection.Open();
                        }
                        catch ( Exception exOpen )
                        {
                            throw exOpen;
                        }

                    }
                }

            }

        }
        #endregion

    
    }
}
