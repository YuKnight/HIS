using System;
using TrasenFrame.Forms;
using TrasenFrame.Classes;

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
		static void Main() 
		{
			/*
			 * 参数说明:
			 * caption		：主窗体标题
			 * connectionType ： 数据库连接类型
			 * connectionString 连接字符串
			 * mainProgramname:主程序名
			 * checkRegister :是否检查注册信息
			 * */
			string serverName = "mydb_svr";

			serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SERVER_NAME","NAME",Constant.ApplicationDirectory + "\\ClientConfig.ini");
			if ( serverName == "" )
			{
				System.Windows.Forms.MessageBox.Show("ClientConfig.ini中[SERVER_NAME]的NAME未设置,请启动配置程序并设置当前服务器","错误");
				return;
			}
			string connectionString = WorkStaticFun.GetConnnectionString(ConnectionType.SQLSERVER,serverName);

		    TrasenMainWindow.FrmMdiMainWindow.StartupMain("创星科技信息系统",ConnectionType.SQLSERVER,	connectionString,"Trasen",true);
		}
	}
}
