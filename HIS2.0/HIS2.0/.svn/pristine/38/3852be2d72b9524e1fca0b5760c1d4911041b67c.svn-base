using System;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace TrasenFrame.Classes
{
    /// <summary>
    /// SystemLog 的摘要说明。
    /// 系统运行日志
    /// </summary>
    public class SystemCfg : IStdObject
    {
        private RelationalDatabase _database = null;//FrmMdiMain.Database;
        private int _cfgID;
        private string _config;
        private string _note;
        private int _moduleID;
        private short _paraLevel;
        private bool _writable;
        private short _varType;
        private DatabaseType _dbType;
        /// <summary>
        /// 参数表 2013-7-18 增加
        /// </summary>
        private static  DataTable _dataTableConfig;

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
                _database = value;
            }
        }
        /// <summary>
        /// 参数ID(最高位说明：1 挂号系统 2收费系统 3医生站系统 4 药房系统 5 药库系统 6 基础数据)
        /// </summary>
        public int CfgID
        {
            get { return _cfgID; }
        }
        /// <summary>
        /// 参数值
        /// </summary>
        public string Config
        {
            get { return _config; }
        }
        /// <summary>
        ///  操作员ID
        /// </summary>
        public string Note
        {
            get { return _note; }
        }
        /// <summary>
        /// 模块号
        /// </summary>
        public int ModuleID
        {
            get { return _moduleID; }
        }
        /// <summary>
        /// 参数级别
        /// </summary>
        public short ParaLevel
        {
            get { return _paraLevel; }
        }
        /// <summary>
        /// 可写标志
        /// </summary>
        public bool Writable
        {
            get { return _writable; }
        }
        /// <summary>
        /// 变量类别
        /// </summary>
        public short VarType
        {
            get { return _varType; }
        }
        #endregion

        /// <summary>
        /// 参数表 2013-7-18 增加 部分参数取内存表
        /// </summaryDataTable
        private DataRow DataRowConfig( int cfgID )
        {
            if ( _dataTableConfig == null )
                _dataTableConfig = _database.GetDataTable( "SELECT * FROM JC_CONFIG(nolock) WHERE rwbz=1" );
            _dataTableConfig.PrimaryKey = new DataColumn[] { _dataTableConfig.Columns["ID"] };
            DataRow dr = _dataTableConfig.Rows.Find( cfgID );
            return dr;

        }

        /// <summary>
        /// 根据参数ID构造对象
        /// </summary>
        /// <param name="cfgID"></param>
        public SystemCfg( int cfgID )
        {
            InitDatabase();
            try
            {
                _dbType = DatabaseType.SqlServer;
                //FrmMdiMain.WriteFrameLocalLog(new string[] { string.Format("测试参数问题{0}", "SystemCfg(int cfgID):1-cfgID:" + cfgID.ToString()) }, true);
                DataRow dr = DataRowConfig( cfgID ); //2013-7-18 修改 取内存表
                if ( dr == null )
                    dr = _database.GetDataRow( "SELECT * FROM JC_CONFIG(nolock) WHERE ID=" + cfgID );

                //FrmMdiMain.WriteFrameLocalLog(new string[] { string.Format("测试参数问题{0}", "SystemCfg(int cfgID):2-cfgID:" + cfgID.ToString()) }, true);
                if ( dr == null )
                {

                    _cfgID = -1;
                    throw new Exception( "指定的参数记录不存在：" + cfgID );
                }

                //FrmMdiMain.WriteFrameLocalLog(new string[] { string.Format("测试参数问题{0}", "SystemCfg(int cfgID):3-cfgID:" + cfgID.ToString()) + "：列：" + GetTableColumnsName(dr.Table) }, true);
                _cfgID = cfgID;
                _config = Convertor.IsNull( dr["CONFIG"] , "" );
                _note = Convertor.IsNull( dr["NOTE"] , "" );
                _moduleID = Convert.ToInt32( Convertor.IsNull( dr["MODULE_ID"] , "-1" ) );
                _paraLevel = Convert.ToInt16( Convertor.IsNull( dr["CSJB"] , "-1" ) );
                _writable = Convert.ToInt16( Convertor.IsNull( dr["RWBZ"] , "0" ) ) > 0 ? true : false;
                _varType = Convert.ToInt16( Convertor.IsNull( dr["BLBZ"] , "-1" ) );
                //FrmMdiMain.WriteFrameLocalLog(new string[] { string.Format("测试参数问题{0}", "SystemCfg(int cfgID):4-cfgID:" + cfgID.ToString()) }, true);
                ReleaseDatabase();
            }
            catch ( Exception err )
            {
                FrmMdiMain.WriteFrameLocalLog( new string[] { string.Format( "测试参数问题{0}" , "SystemCfg(int cfgID):err-cfgID:" + cfgID.ToString() ) + err.Message }, true );
                MessageBox.Show( "SystemCfg(int cfgID)\\读取系统参数表出错\n" + err.Message );
                //throw new Exception("SystemCfg\\读取系统参数表出错\n"+err.Message);
            }
        }
        /// <summary>
        /// 根据参数ID构造对象
        /// </summary>
        /// <param name="cfgID">参数ID</param>
        /// <param name="dbType">数据库类别</param>
        public SystemCfg(int cfgID, DatabaseType dbType)
        {
            InitDatabase();
            try
            {
                _dbType = dbType;
                DataRow dr = _database.GetDataRow( "SELECT * FROM JC_CONFIG(nolock) WHERE ID=" + cfgID );

                if ( dr == null )
                {
                    _cfgID = -1;
                    throw new Exception( "指定的参数记录不存在：" + cfgID );
                }
                _cfgID = cfgID;
                _config = Convertor.IsNull( dr["CONFIG"] , "" );
                _note = Convertor.IsNull( dr["NOTE"] , "" );
                _moduleID = Convert.ToInt32( Convertor.IsNull( dr["MODULE_ID"] , "-1" ) );
                _paraLevel = Convert.ToInt16( Convertor.IsNull( dr["CSJB"] , "-1" ) );
                _writable = Convert.ToInt16( Convertor.IsNull( dr["RWBZ"] , "0" ) ) > 0 ? true : false;
                _varType = Convert.ToInt16( Convertor.IsNull( dr["BLBZ"] , "-1" ) );
            }
            catch ( Exception err )
            {

                throw new Exception( " SystemCfg(int cfgID, DatabaseType dbType)\\读取系统参数表出错\n" + err.Message );
            }
            finally
            {
                ReleaseDatabase();
            }
        }
        /// <summary>
        /// 根据参数ID构造对象
        /// </summary>
        /// <param name="cfgID">参数ID</param>
        /// <param name="database">数据库访问对象</param>
        public SystemCfg(int cfgID, RelationalDatabase database)
        {
            try
            {
                _dbType = DatabaseType.SqlServer;
                this.Database = database.GetCopy();
                this.Database.Open();
                DataRow dr = this.Database.GetDataRow( "SELECT * FROM JC_CONFIG(nolock) WHERE ID=" + cfgID );
                if ( dr == null )
                {
                    _cfgID = -1;
                    throw new Exception( "指定的参数记录不存在：" + cfgID );
                }
                _cfgID = cfgID;
                _config = Convertor.IsNull( dr["CONFIG"] , "" );
                _note = Convertor.IsNull( dr["NOTE"] , "" );
                _moduleID = Convert.ToInt32( Convertor.IsNull( dr["MODULE_ID"] , "-1" ) );
                _paraLevel = Convert.ToInt16( Convertor.IsNull( dr["CSJB"] , "-1" ) );
                _writable = Convert.ToInt16( Convertor.IsNull( dr["RWBZ"] , "0" ) ) > 0 ? true : false;
                _varType = Convert.ToInt16( Convertor.IsNull( dr["BLBZ"] , "-1" ) );
            }
            catch ( Exception err )
            {
                throw new Exception( "(int cfgID, RelationalDatabase database)\\读取系统参数表出错\n" + err.Message );
            }
            finally
            {
                ReleaseDatabase();
            }
        }
        /// <summary>
        /// 直接根据具体值构造参数对象
        /// </summary>
        /// <param name="cfgID">参数ID</param>
        /// <param name="config">参数值</param>
        /// <param name="note">参数说明</param>
        /// <param name="moduleID">所属模块</param>
        /// <param name="paraLevel">参数级别</param>
        /// <param name="writable">是否可写</param>
        /// <param name="varType">参数类别</param>
        public SystemCfg(int cfgID, string config, string note, int moduleID, short paraLevel, bool writable, short varType)
        {
            InitDatabase();
            _cfgID = cfgID;
            _config = config;
            _note = note;
            _moduleID = moduleID;
            _paraLevel = paraLevel;
            _writable = writable;
            _varType = varType;
            _dbType = DatabaseType.IbmDb2;
            ReleaseDatabase();
        }

        /// <summary>
        /// 直接根据具体值构造参数对象
        /// </summary>
        /// <param name="cfgID">参数ID</param>
        /// <param name="config">参数值</param>
        /// <param name="note">参数说明</param>
        /// <param name="moduleID">所属模块</param>
        /// <param name="paraLevel">参数级别</param>
        /// <param name="writable">是否可写</param>
        /// <param name="varType">参数类别</param>
        /// <param name="dbType">数据库类别</param>
        public SystemCfg(int cfgID, string config, string note, int moduleID, short paraLevel, bool writable, short varType, DatabaseType dbType)
        {
            InitDatabase();
            _cfgID = cfgID;
            _config = config;
            _note = note;
            _moduleID = moduleID;
            _paraLevel = paraLevel;
            _writable = writable;
            _varType = varType;
            _dbType = dbType;
            ReleaseDatabase();
        }
        /// <summary>
        /// 取表的列名称
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetTableColumnsName(DataTable dt)
        {
            string str_coluns = "";
            foreach (DataColumn col in dt.Columns)
            {
    
                if (str_coluns != "") str_coluns += ",";
                str_coluns += col.ColumnName;
            }
            return str_coluns;
        }
        #region 接口成员
        /// <summary>
        /// 保存对象
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return true;
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

        private void InitDatabase()
        {
            if ( _database == null )
            {
                _database = FrmMdiMain.Database.GetCopy();
                _database.Open();
                //Console.WriteLine( "Open a new Connection Of SystemCfg Object" );
            }
        }

        private void ReleaseDatabase()
        {
            if ( _database != null )
            {
                if ( _database.ConnectionStates == ConnectionState.Open )
                {
                    try
                    {
                        _database.Close();
                        _database.Dispose();
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}