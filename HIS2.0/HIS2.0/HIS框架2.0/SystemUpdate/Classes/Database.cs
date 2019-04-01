using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace SystemUpdate
{
    public class Database
    {
        private IDbConnection database = null;

        public Database()
        {
            if ( database == null )
            {
                string serverName = ApiFunction.GetIniString( "SERVER_NAME" , "NAME" , Application.StartupPath + "\\ClientConfig.ini" );
                if ( serverName == "" )
                {
                    throw new Exception( "ClientConfig.ini中[SERVER_NAME]的NAME未设置,请启动配置程序并设置当前服务器" );
                }
                //获取连接字符串
                ConnectionType dbType = ConnectionType.SQLSERVER;//在此设置数据库类型,以后根据数据库平台需要更改此处
                string connectionString = GetConnnectionString( dbType , serverName );
                database = CreateConnection( dbType , connectionString );
                database.Open();
            }
        }
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="type">类型0、SQL SERVER 1、IBM DB2</param>
        /// <param name="applicationName">INI文件中段(SECTION)名称</param>
        private string GetConnnectionString( ConnectionType type , string applicationName )
        {
            string cnnString , hostName , database , userID , password , protocol , port , strCnnType;
            switch ( type )
            {
                case ConnectionType.SQLSERVER:
                    hostName = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "HOSTNAME" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    database = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "DATASOURCE" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    userID = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "USER_ID" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    password = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "PASSWORD" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    cnnString = @"packet size=4096;user id=" + userID + ";password=" + password + ";data source=" + hostName + ";persist security info=True;initial catalog=" + database;
                    break;
                case ConnectionType.IBMDB2:
                    hostName = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "HOSTNAME" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    protocol = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "PROTOCOL" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    port = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "PORT" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    database = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "DATASOURCE" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    userID = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "USER_ID" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    password = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "PASSWORD" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    strCnnType = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "CONNECTIONTYPE" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    if ( strCnnType == "1" )
                        cnnString = @"Provider=IBMDADB2;Database=" + database + ";HostName=" + hostName + ";Protocol=" + protocol + ";Port=" + port + ";User ID=" + userID + ";Password=" + password;
                    else
                        cnnString = @"Provider=IBMDADB2.1;User ID=" + userID + ";Password=" + password + ";Data Source=" + database + ";Mode=ReadWrite;Extended Properties=";
                    break;
                case ConnectionType.MSACCESS:
                    database = Crypto.Instance().Decrypto( ApiFunction.GetIniString( applicationName , "DATASOURCE" , Application.StartupPath + "\\ClientConfig.ini" ) );
                    cnnString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=" + database + ";Mode=Share Deny None;Jet OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
                    break;
                default:
                    cnnString = "";
                    break;
            }
            return cnnString;
        }
        /// <summary>
        /// 返回数据库连接对象
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="ConnString"></param>
        /// <returns></returns>
        private IDbConnection CreateConnection(ConnectionType dbType,string ConnString)
        {
            switch ( dbType )
            {
                case ConnectionType.SQLSERVER:
                    return new SqlConnection( ConnString );
                default:
                    return new OleDbConnection( ConnString );
            }
        }
        /// <summary>
        /// 获取需要升级的文件列表
        /// </summary>
        /// <returns></returns>
        public List<UpdateInfo> GetUpdateFileList()
        {
            string commandText = "select id,type,name,update_time,version,dellocalreport,download_folder from pub_systemupdate where delete_bit=0";
            IDbCommand command = null;
            IDataReader dataReader = null;
            try
            {
                //创建Command对象
                try
                {
                    command = database.CreateCommand();
                    command.CommandText = commandText;
                }
                catch(Exception err1)
                {
                    throw new Exception( "创建Command对象发生错误！" + err1.Message );
                }
                //获取DataReader对象
                try
                {
                    dataReader = command.ExecuteReader();
                }
                catch(Exception err2)
                {
                    throw new Exception( "Command对象获取DataReader发生错误！" + err2.Message);
                }
                //返回升级文件信息
                List<UpdateInfo> updateList = new List<UpdateInfo>();
                try
                {
                    while ( dataReader.Read() )
                    {
                        UpdateInfo info = new UpdateInfo(this);
                        info.Id = Convert.ToInt32( dataReader["ID"] );
                        info.Name = dataReader["NAME"].ToString().Trim();
                        info.Type = Convert.ToInt32( dataReader["TYPE"] );
                        info.UpdateTime = Convert.ToDateTime( dataReader["UPDATE_TIME"] );
                        info.Version = dataReader["VERSION"].ToString().Trim();
                        info.DelLocalReport = Convert.ToInt32( dataReader["DELLOCALREPORT"] );
                        info.DownloadFolder = Convert.IsDBNull( dataReader["Download_Folder"] ) ? "" : dataReader["Download_Folder"].ToString();
                        updateList.Add( info );
                    }
                }
                catch ( Exception err3 )
                {
                    throw new Exception( "获取升级文件信息发生错误！" + err3.Message );
                }
                finally
                {
                    dataReader.Close();
                }
                return updateList;
            }
            catch(Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 获取升级文件内容
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public object GetUpdateFileContent( int Id )
        {
            IDbCommand cmd;

            string commandText = "select file_value from pub_systemupdate where id=" + Id;
            try
            {
                cmd = database.CreateCommand();
                cmd.CommandText = commandText;
                object objContent = cmd.ExecuteScalar();
                return objContent;
            }
            catch(Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 获取数据中参数表关于自定义路径的配置值
        /// </summary>
        /// <returns></returns>
        public string GetDbCustomDirectoryConfig()
        {
            IDbCommand cmd = database.CreateCommand();
            cmd.CommandText = "select config from jc_config where id=0001";
            object obj = cmd.ExecuteScalar();
            if ( obj == null || Convert.IsDBNull( obj ) )
                return "";
            else
                return obj.ToString().Trim();
        }
    }
}
