using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using System.Data;
using System.IO;
using Crownwood.Magic.Menus;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;

using System.Resources;
using System.Net.NetworkInformation;
using System.Net;
namespace TrasenFrame.Forms
{

    /// <summary>
    /// 系统主窗体
    /// </summary>
    public class FrmMdiMain // System.Windows.Forms.Form
    {
        //初始化水晶报表用，仅在系统启动时调用一次
        private static bool initCrypt = StartInitCryReport();//InitCryReport(); jianqg 说明 2014-4-15 调用StartInitCryReport()可能会临时文件不能删除
        private static bool initCryptEnd = true;
        public static bool InitCryptEnd
        {
            get
            {
                return initCryptEnd;
            }
        }
        // jianqg 2013-5-16 增加不自动更新 UpdateFile,UPDATETYPE,NotUpdate

        //jianqg emr-his 整合暂时注释--  按此 文本查询
        /// <summary>
        /// 改变常量框架类型，并手动修改AssemblyInfo中版本， 自动使用公司或东软的框架 jianqg 2012-8-8 
        /// 2012-12-27 该为属性，使用常量 emr可能取到的值还是原来的公司值
        /// </summary>
        //private TrasenFrame.Classes.FrameKind _FRAMEKIND = FrameKind.公司;
        /// <summary>
        /// jianqg 2012-10月 emr-his框架整合 增加 电子病历菜单，便于进入到电子病历系统，自动打开员电子病历系统
        /// </summary>
        //private MenuCommand menu_EmrBussinessHis = null;

        /// <summary>
        /// 当前操作的系统
        /// </summary>
        public static SystemInfo CurrentSystem = null;
        /// <summary>
        /// 数据库访问器
        /// </summary>
        public static RelationalDatabase Database = null;
        /// <summary>
        /// LIS数据库访问器
        /// </summary>
        public static RelationalDatabase Database_Lis = null;
        /// <summary>
        /// PACS数据库访问器
        /// </summary>
        public static RelationalDatabase Database_Pacs = null;
        /// <summary>
        /// 当前用户
        /// </summary>
        public static User CurrentUser = null;
        /// <summary>
        /// 当前科室
        /// </summary>
        public static Department CurrentDept = null;
        /// <summary>
        /// 机构编码
        /// </summary>
        public static int Jgbm = -1;
        /// <summary>
        /// 机构名称
        /// </summary>
        public static string Jgmc = "";
        /// <summary>
        /// 医院编码
        /// </summary>
        public static int JgYybm = -1;
        /// <summary>
        /// 机构编码对应服务器IP
        /// </summary>
        public static string JgServerIpaddr = "";
        /// <summary>
        /// 中心机构编码
        /// </summary>
        public static int ZxJgbm = -1;
        /// <summary>
        /// 中心机构名称
        /// </summary>
        public static string ZxJgmc = "";               
        /// <summary>
        /// 用于消息监听的端口号，在登录的时候由系统随机分配
        /// </summary>
        public static int PortNum;
        /// <summary>
        /// 门户ID，单点登录用
        /// </summary>
        public static string PortalsId = "";//Add By Tany 2014-10-30
       
        public static TrasenFrame.Classes.FrameKind FRAMEKIND
        {
            get
            {                
                return FrameKind.公司;
                //return FrameKind.东软;
                //return FrameKind.弘麒;
            }
        }      
        /// <summary>
        /// 写本地的框架日志方法 add by wangzhi 2013-06-21
        /// </summary>
        /// <param name="content"></param>
        /// <param name="showTime"></param>
        public static void WriteFrameLocalLog( string[] content , bool showTime )
        {
            try
            {
                string path = string.Format( "{0}\\AppLog\\Update" , System.Windows.Forms.Application.StartupPath );
                if ( !System.IO.Directory.Exists( path ) )
                    System.IO.Directory.CreateDirectory( path );

                string logFile = string.Format( "{0}\\{1}" , path , "UpdateLog.log" );

                string strTime = "[" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) + "]";
                if ( !showTime )
                    strTime = "";

                if ( !System.IO.File.Exists( logFile ) )
                {
                    using ( System.IO.StreamWriter sw = System.IO.File.CreateText( logFile ) )
                    {
                        sw.WriteLine( string.Format( "{0}Trasen.exe创建升级日志文件" , strTime ) );
                        sw.Flush();
                        sw.Close();
                    }
                }

                for ( int i = 0 ; i < content.Length ; i++ )
                {
                    using ( System.IO.StreamWriter sw = System.IO.File.AppendText( logFile ) )
                    {
                        if ( i == 0 )
                        {
                            sw.WriteLine( strTime + content[i] );
                        }
                        else
                        {
                            if ( strTime != "" )
                            {
                                sw.WriteLine( "                     " + content[i] );
                            }
                            else
                            {
                                sw.WriteLine( content[i] );
                            }
                        }
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 获取系统列表
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadSystemList()
        {
            ParameterEx[] paras = new ParameterEx[3];
            paras[0].Text = "@UserCode";
            paras[0].Value = "";
            paras[1].Text = "@UserId";
            paras[1].Value = CurrentUser.UserID;
            paras[2].Text = "@AdminFlag";
            paras[2].Value = CurrentUser.IsAdministrator ? 1 : 0;

            IDbCommand cmd = FrmMdiMain.Database.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "up_GetSystemOfUser";
            FrmMdiMain.Database.SetParameters( cmd , paras );
            DataTable tableSystem = FrmMdiMain.Database.GetDataTable( cmd );
            return tableSystem;

        }
        /// <summary>
        /// 获取系统列表
        /// </summary>
        /// <param name="db">数据库连接</param>
        /// <returns></returns>
        public static DataTable LoadSystemList( RelationalDatabase db )
        {
            ParameterEx[] paras = new ParameterEx[3];
            paras[0].Text = "@UserCode";
            paras[0].Value = "";
            paras[1].Text = "@UserId";
            paras[1].Value = CurrentUser.UserID;
            paras[2].Text = "@AdminFlag";
            paras[2].Value = CurrentUser.IsAdministrator ? 1 : 0;

            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "up_GetSystemOfUser";
            db.SetParameters( cmd , paras );
            DataTable tableSystem = db.GetDataTable( cmd );
            return tableSystem;
        }
        /// <summary>
        /// 获取每个系统的菜单
        /// </summary>
        /// <param name="SystemId"></param>
        /// <returns></returns>
        public static DataTable LoadSystemMenuList( int SystemId )
        {
            ParameterEx[] paras = new ParameterEx[3];
            paras[0].Text = "@SystemId";
            paras[0].Value = SystemId;
            paras[1].Text = "@UserId";
            paras[1].Value = CurrentUser.UserID;
            paras[2].Text = "@AdminFlag";
            paras[2].Value = CurrentUser.IsAdministrator ? 1 : 0;

            IDbCommand cmd = FrmMdiMain.Database.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "up_GetSystemUserMenu";
            FrmMdiMain.Database.SetParameters( cmd , paras );
            DataTable table = FrmMdiMain.Database.GetDataTable( cmd );
            return table;
        }
        /// <summary>
        /// 获取每个系统的菜单
        /// </summary>
        /// <param name="SystemId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataTable LoadSystemMenuList( int SystemId , RelationalDatabase db )
        {
            ParameterEx[] paras = new ParameterEx[3];
            paras[0].Text = "@SystemId";
            paras[0].Value = SystemId;
            paras[1].Text = "@UserId";
            paras[1].Value = CurrentUser.UserID;
            paras[2].Text = "@AdminFlag";
            paras[2].Value = CurrentUser.IsAdministrator ? 1 : 0;

            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "up_GetSystemUserMenu";
            db.SetParameters( cmd , paras );
            DataTable table = db.GetDataTable( cmd );
            return table;
        }
        /// <summary>
        /// 根据当前用户和系统实例化科室
        /// </summary>
        /// <returns></returns>
        //private Department InstanceCurrentDept()
        //{
        //    string sql = "select dept_id as ksbh from jc_emp_dept_role where employee_id=" + CurrentUser.EmployeeId + " and  xtbh = " + CurrentSystem.SystemId + " and dept_id in (select dept_id from jc_dept_property where jgbm=" + FrmMdiMain.Jgbm + ")";//Modify By tany 2010-04-01 读取默认科室的时候判断一下该科室不是当前机构编码下的科室
        //    //string sql = "select dept_id as ksbh from jc_emp_dept_role where employee_id=" + CurrentUser.EmployeeId + " and  [default] = 1";
        //    DataRow dr = FrmMdiMain.Database.GetDataRow( sql );
        //    if ( dr == null )
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            return new Department( Convert.ToInt32( dr["ksbh"] ) , FrmMdiMain.Database );
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //}
        /// <summary>
        /// 获得机构编码和名称
        /// </summary>
        /// <returns></returns>
        public static object[] GetJgbmmc()
        {
            object[] obj = new object[4];
            string serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString( "SERVER_NAME" , "NAME" , Constant.ApplicationDirectory + "\\ClientConfig.ini" );
            string _ip = Crypto.Instance().Decrypto( ApiFunction.GetIniString( serverName , "HOSTNAME" , Constant.ApplicationDirectory + "\\ClientConfig.ini" ) );
            ;
            //jianqg 2012-9-26 增加第2ip地址连接 处理
            //string _sql = "select * from jc_jgbm where ipaddr='" + _ip.ToString().Trim() + "'";
            string _sql = "select * from jc_jgbm where ipaddr='" + _ip.ToString().Trim() + "' or IPADDR2='" + _ip.ToString().Trim() + "' ";
            DataTable tb = Database.GetDataTable( _sql );
            if ( tb == null || tb.Rows.Count == 0 )
            {
                throw new Exception( "没有找到该主机地址对应的机构编码，请联系系统管理员！" );
            }
            else
            {
                obj[0] = Convert.ToInt32( tb.Rows[0]["jgbm"] );
                obj[1] = tb.Rows[0]["jgmc"].ToString().Trim();
                obj[2] = Convert.ToInt32( tb.Rows[0]["yybm"] );
                obj[3] = tb.Rows[0]["ipaddr"].ToString().Trim();
                //是否是用IPADDR2连接
                if ( tb.Rows[0]["IPADDR2"].ToString().ToLower() == _ip.ToString().Trim().ToLower() )
                    obj[3] = tb.Rows[0]["IPADDR2"].ToString();

                return obj;
            }
        }
        /// <summary>
        /// 获得中心机构编码和名称
        /// </summary>
        /// <returns></returns>
        public static object[] GetZxJgbmmc()
        {
            object[] obj = new object[2];

            string _sql = "select * from jc_jgbm where yybm=0";
            DataTable tb = Database.GetDataTable( _sql );
            if ( tb == null || tb.Rows.Count == 0 )
            {
                obj[0] = -1;
                obj[1] = "无法找到中心机构编码";
                return obj;
            }
            else
            {
                obj[0] = Convert.ToInt32( tb.Rows[0]["jgbm"] );
                obj[1] = tb.Rows[0]["jgmc"].ToString().Trim();
                return obj;
            }
        }

        private delegate bool OnInitCryReportHandler();
        private static bool StartInitCryReport()
        {
            try
            {
                OnInitCryReportHandler handler = new OnInitCryReportHandler( InitCryReport );
                bool end = false;
                handler.BeginInvoke( new AsyncCallback( StartInitCryReporCallBack ) , end );
                return end;
            }
            catch
            {
                return true;
            }
        }
        private static void StartInitCryReporCallBack( IAsyncResult result )
        {
            try
            {
                OnInitCryReportHandler hander = (OnInitCryReportHandler)( (System.Runtime.Remoting.Messaging.AsyncResult)result ).AsyncDelegate;
                hander.EndInvoke( result );
                if ( result.IsCompleted )
                    initCryptEnd = true;
            }
            catch
            {
                initCryptEnd = true;
            }
        }
        public static bool InitCryReport()
        {
            //// Application.StartupPath + "\\" + Guid.NewGuid() + ".rpt";  
            //jianqg 2014-4-15  发现经常不能删除 临时文件
            //WorkStaticFun.ClearTempDir 删除临时文件 
            string templateFile =System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\" + Guid.NewGuid() + ".rpt";
            try
            {
                DataTable dt = new DataTable( "temp" );
                dt.Columns.Add( "Fields0" );
                Assembly assembly = Assembly.LoadFile( Application.StartupPath + "\\TrasenFrame.dll" );
                using ( System.IO.Stream stream = assembly.GetManifestResourceStream( "TrasenFrame.Forms.Temp.rpt" ) )
                {
                    byte[] fileByte = new byte[(int)stream.Length];
                    stream.Read( fileByte , 0 , (int)stream.Length );
                    using ( System.IO.FileStream fs = new System.IO.FileStream( templateFile , System.IO.FileMode.Create ) )
                    {
                        fs.Write( fileByte , 0 , fileByte.Length );
                        fs.Flush();
                    }
                    stream.Close();
                   
                }
                //WriteFrameLocalLog(new string[] { "InitCryReport1" }, true);
                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //WriteFrameLocalLog(new string[] { "InitCryReport2" }, true);
                rptDoc.FileName = templateFile;
                //WriteFrameLocalLog(new string[] { "InitCryReport3" }, true);
                rptDoc.SetDataSource( dt );


                
                WriteFrameLocalLog( new string[] { "初始化水晶报表组件完成" }, true );
                return true;
            }
            catch ( Exception error )
            {
                WriteFrameLocalLog( new string[] { "初始化水晶报表组件发生错误！" , error.Message }, true );
                return false;
            }
            finally
            {
  
                if ( System.IO.File.Exists( templateFile ) )
                    System.IO.File.Delete( templateFile );

                initCryptEnd = true;
            }
        }
    }
}
