using System;
using System.IO;
using System.Windows.Forms;
using TrasenFrame.Classes;
using System.Net;
using System.IO.Compression;


namespace TraSen
{
    /// <summary>
    /// 系统入口
    /// </summary>
    public class Entrance
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main( string[] args )
        {            
            /*
             * 参数说明:
             * caption		：主窗体标题
             * connectionType ： 数据库连接类型
             * connectionString 连接字符串
             * mainProgramname:主程序名
			 
             * */

            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            

            TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog( new string[] { string.Format("********************************************** Local Time : {0} **********************************************",DateTime.Now.ToString() ) }, false );

            string clientConfigFile = Constant.ApplicationDirectory + "\\ClientConfig.ini";

            string[] ss = System.Windows.Forms.Application.ExecutablePath.Split( "\\".ToCharArray() );
            TrasenClasses.GeneralClasses.ApiFunction.WriteIniString( "HIS_StARTUP_EXE" , "NAME" , ss[ss.Length - 1] , clientConfigFile );
            
            string serverName = "";

            serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SERVER_NAME", "NAME", clientConfigFile);
            if (serverName == "")
            {
                System.Windows.Forms.MessageBox.Show("ClientConfig.ini中[SERVER_NAME]的NAME未设置,请启动配置程序并设置当前服务器", "错误");
                return;
            }
            
            string connectionString = WorkStaticFun.GetConnnectionString_Default(ConnectionType.SQLSERVER);//.GetConnnectionString(ConnectionType.SQLSERVER, serverName);

            //TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog(new string[] { string.Format("args：{0},{1}", args.Length, args[0]) }, true);

            if ( args != null && args.Length > 0 && args[0] == "IsFormUpdate" )
            {

                TrasenMainWindow.FrmMdiMainWindow.StartupMain( "创星科技信息系统" , ConnectionType.SQLSERVER , connectionString , "Trasen" , true , true );
                return;
            }
            //单点登录
            #region 单点登录处理
            try
            {
                if ( args.Length > 0 )
                {
                    //trasen.exe 8|635;portalsid=xxxxxx
                    const string name = "portalsid";
                    string[] array = args[0].Split( ";".ToCharArray() );
                    //Modify By Tany 2014-12-10 原来写的是长度=2，但是门户可能会增加参数，所以改写成>=
                    if ( array.Length >= 2 && ( array[1].Length > name.Length && array[1].Substring( 0 , name.Length ).ToLower() == name.ToLower() ) )
                    {
                        string system_menu_id = array[0]; //得到系统及菜单的ID xx|xxx格式
                        string portalsid = array[1];      //得到portalsid 部分 portalsid=xxxx格式
                        string[] temp = portalsid.Split( "=".ToCharArray() );
                        if (temp.Length == 2)
                        {
                            portalsid = temp[1].Trim();
                        }
                        else
                        {
                            portalsid = "";  //得到真正的portalsid                       
                        }
                        //Add By Tany 2014-10-30 记录门户的ID
                        TrasenFrame.Forms.FrmMdiMain.PortalsId = portalsid;

                        TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { string.Format( "获取到参数{0},{1}" , system_menu_id , portalsid ) }, true );

                        string dll = AppDomain.CurrentDomain.BaseDirectory + "ts.WHZXYY.Portal.dll";
                        System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile( dll );
                        object obj = assembly.CreateInstance( "ts.WHZXYY.Portal.Client" );
                        if ( obj == null )
                            throw new Exception( "创建ts.WHZXYY.Portal.Client对象失败" );

                        System.Reflection.MethodInfo mi = obj.GetType().GetMethod( "GetRequestString" );
                        object objRet = mi.Invoke( obj , new object[] { portalsid } );
                        string ret = objRet != null ? objRet.ToString() : "";
                        if ( !string.IsNullOrEmpty( ret ) )
                        {
                            System.Xml.XmlDocument document = new System.Xml.XmlDocument();
                            document.LoadXml( ret );
                            System.Xml.XmlNode nameNode = document.SelectSingleNode( "//loginUserInfo/userAccount" );
                            if ( nameNode != null )
                            {
                                string loginCode = nameNode.InnerText;
                                if ( !string.IsNullOrEmpty( system_menu_id ) )
                                    TrasenMainWindow.FrmMdiMainWindow.StartupMain( "创星科技信息系统" , ConnectionType.SQLSERVER , connectionString , "Trasen" , true , false , loginCode , system_menu_id );
                                else
                                    TrasenMainWindow.FrmMdiMainWindow.StartupMain( "创星科技信息系统" , ConnectionType.SQLSERVER , connectionString , "Trasen" , true , false , loginCode );
                                return;
                            }
                            else
                                throw new Exception( document.InnerText );
                        }
                    }
                }
            }
            catch ( Exception error )
            {
                MessageBox.Show( "单点登录失败！原因:" + error.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { error.Message , error.StackTrace }, true );
            }
            #endregion

            TrasenMainWindow.FrmMdiMainWindow.StartupMain( "创星科技信息系统" , ConnectionType.SQLSERVER , connectionString , "Trasen" , true );
        }
    
    }
}
