using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;

namespace LED_RemotingServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SERVER_NAME", "NAME", Constant.ApplicationDirectory + "\\ClientConfig.ini");
            if (serverName == "")
            {
                System.Windows.Forms.MessageBox.Show("ClientConfig.ini中[SERVER_NAME]的NAME未设置,请启动配置程序并设置当前服务器", "错误");
                return;
            }
            //string filename = Constant.ApplicationDirectory + " \\" + string.Format("{0:yyyyMMdd}", DateTime.Now) + ".txt";
            RelationalDatabase database = null;
            database = new MsSqlServer();
            string connectionString = WorkStaticFun.GetConnnectionString(ConnectionType.SQLSERVER, serverName);
            database.Initialize(connectionString);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmServer(database));
        }
    }
}