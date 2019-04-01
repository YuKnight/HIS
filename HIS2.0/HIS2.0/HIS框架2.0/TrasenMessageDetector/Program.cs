using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrasenMessageDetector
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            

            int systemId = Convert.ToInt32( args[0].Remove( 0 , 1 ) ); //开启此进程的HIS程序中的系统ID
            int deptId = Convert.ToInt32( args[1].Remove( 0 , 1 ) );   //开启此程 的HIS程序中的系统ID
            int employeeId = Convert.ToInt32( args[2].Remove( 0 , 1 ) );
            IntPtr mw_handle = new IntPtr( Convert.ToInt32( args[3].Remove( 0 , 1 ) ) );
            int port = Convert.ToInt32( args[4].Remove( 0 , 1 ) );
            int mainProcessId = Convert.ToInt32( args[5].Remove( 0 , 1 ) );
            TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { "启动消息侦听进程." } , true );
            Application.Run( new HideOnStartupApplicationContext( new FrmConsole() , systemId , deptId , employeeId , mw_handle , port , mainProcessId  ) );
            
        }


    }

    
}