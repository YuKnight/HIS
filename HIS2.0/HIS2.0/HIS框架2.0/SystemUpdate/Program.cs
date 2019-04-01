using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SystemUpdate
{
    static class Program
    {
        //API函数申明
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        //static void Main(params string[] invokAppId)
        //Modify By Tany 2012-04-10 带参数启动
        static void Main(string[] args)
        {
            Classes.Logger.Write( new string[] { "Start Run Update Main Function" } , true );
            string hisStartupExe = "Trasen.exe";
            string procName = "Trasen";
            //Modify By Tany 2012-03-09 获取主程序的exe名称
            hisStartupExe = GetIniString("MAINPROGRAMINFO", "hisStartupExe", Application.StartupPath + "\\ClientConfig.ini");
            procName = GetIniString("MAINPROGRAMINFO", "Trasen", Application.StartupPath + "\\ClientConfig.ini");
            if (hisStartupExe.Trim() == "")
            {
                hisStartupExe = "Trasen.exe";
            }
            if (procName.Trim() == "")
            {
                procName = "Trasen";
            }

            //判断启动程序的参数，没有参数则是由Trasen.exe调用
            if (args.Length > 0)
            {

                hisStartupExe = args[0];
                //MessageBox.Show(args[0]);
            }
            if (args.Length > 1)
            {
                procName = args[1];

                //MessageBox.Show(args[1]);
            }

            Classes.Logger.Write( new string[] { "Beform CreateMutex" } , true );

            IntPtr hMutex = ApiFunction.CreateMutex(null, false, "SysUpdateEx");
            if (ApiFunction.GetLastError() == ApiFunction.ERROR_ALREADY_EXISTS)
            {
                ApiFunction.ReleaseMutex(hMutex);
                return;
            }

            #region add by wangzhi 记录升级程序的信息
            List<string> lstLogHeader = new List<string>();
            lstLogHeader.Add( "*******************************************************************************************" );
            lstLogHeader.Add( string.Format( "hisStartupExe:{0}" , hisStartupExe ) );
            lstLogHeader.Add( string.Format( "procName:{0}" , procName ) );
            if ( args != null && args.Length > 0 )
            {
                lstLogHeader.Add( "Main.args[]:" );
                for ( int i = 0 ; i < args.Length ; i++ )
                {
                    if ( !string.IsNullOrEmpty( args[i] ) )
                        lstLogHeader.Add( args[i] );
                }
            }
            lstLogHeader.Add( "*******************************************************************************************" );
            Classes.Logger.Write( lstLogHeader.ToArray() , false );
            #endregion

            Frmflash f = new Frmflash("正在关闭相关应用程序...");//jianqg  2013-4-22
            #region 关闭相关的程序
            try
            {
                f.Show();
                f.Refresh();                
                KillProcess( "" );                
            }
            catch (Exception err)
            {
                MessageBox.Show("升级程序无法关闭相关应用程序，请手工关闭程序后再试" + err.Message);
                return;
            }
            finally
            {
                f.Close();
            }
            #endregion

            //启动升级程序主界面
            Classes.Logger.Write( "启动升级程序主界面." );
            Application.Run(new SystemUpdate.Forms.FrmFileUpdate());

            //升级结束后，启动HIS应用程序
            try
            {
                bool invokeBySSO = false;
                string strags = "";
                if ( args.Length == 1 && args[0]=="SSO" )
                {
                    //参数为SSO表示由单点登录的程序调用Trasen后再调用升级程序
                    invokeBySSO = true;
                }
                //jianqg  2013-4-22
                if ( args.Length > 2 ) //jianqg  2013-4-22 增加 通过接口如pacs 传入的参数
                {
                    strags += args[2];
                    //MessageBox.Show(args[2]);
                }
                if ( args.Length > 3 ) //jianqg  2013-4-22 增加 通过接口如pacs 传入的参数
                {
                    strags += " " + args[3] + " " + "IsFromUpdate";
                }
                //MessageBox.Show(hisStartupExe);
                //MessageBox.Show(strags);

                if ( invokeBySSO )
                {
                    MessageBox.Show( "升级完成，请重新由门户程序进入" ,"",MessageBoxButtons.OK,MessageBoxIcon.Information );
                    return;
                }

                if ( strags == "" )
                {
                    Classes.Logger.Write( string.Format( "升级结束，正准备启动{0}，参数{1}" , hisStartupExe , "IsFormUpdate" ) );
                    Process.Start( Application.StartupPath + "\\" + hisStartupExe , "IsFormUpdate" );
                }
                else
                {
                    Classes.Logger.Write( string.Format( "升级结束，正准备启动{0}，参数{1}" , hisStartupExe , strags ) );
                    Process.Start( Application.StartupPath + "\\" + hisStartupExe , strags );
                }
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }



        private static void KillProcess( string procName )
        {
            try
            {
                /**********使用cmd命令结束进程 add by wangzhi 2013-06-18*************/
                Classes.Logger.Write( "开始检测进程并结束相关进程" );
                //定义要kill的进程列表
                List<string> lstExe = new List<string>();
                #region 要kill掉的HIS相关进程
                lstExe.Add( "TRASEN" );
                lstExe.Add( "TRASEN.EXE" );
                lstExe.Add( "NEUSOFT" );
                lstExe.Add( "NEUSOFT.EXE" );
                lstExe.Add( "ONKIY" );
                lstExe.Add( "ONKIY.EXE" );
                lstExe.Add( "NEUSOFTEMR" );
                lstExe.Add( "NEUSOFTEMR.EXE" );
                lstExe.Add( "TRASENEMR" );
                lstExe.Add( "TRASENEMR.EXE" );
                lstExe.Add( "EMRDOCORNURSEVIEW" );
                lstExe.Add( "EMRDOCORNURSEVIEW.EXE" );
                lstExe.Add( "EMRCONFIG" );
                lstExe.Add( "EMRCONFIG.EXE" );
                lstExe.Add( "CLIENTCONFIG" );
                lstExe.Add( "CLIENTCONFIG.EXE" );
                #endregion

                #region 获取当前所有进程中在运行的HIS进程ID
                List<int> lstPID = new List<int>();
                try
                {
                    System.Diagnostics.Process[] proces = Process.GetProcesses();
                    foreach ( Process p in proces )
                    {
                        //遍历当前所有进程，为防止改名，判断原始文件名，只要是HIS相关的程序就添加到KILL列表中
                        string originalFilename = "";
                        try
                        {
                            originalFilename = p.MainModule.FileVersionInfo.OriginalFilename.ToUpper();//转为大写
                        }
                        catch 
                        {
                            //访问系统进程模块等的错误忽略
                            continue;
                        }
                        //执行文件名称不为空并且在删除列表中存在，则添加到KILL列表中
                        if ( !string.IsNullOrEmpty( originalFilename ) && lstExe.Contains( originalFilename ) )
                            lstPID.Add( p.Id );
                    }
                    Classes.Logger.Write( "遍历到相关进程共" + lstPID.Count.ToString() );
                }
                catch ( Exception error )
                {
                    Classes.Logger.Write( "遍历进程发生错误！",error );
                }
                #endregion

                //杀进程,调用taskkill命令强制结束进程   
                int killType = 1;
                foreach (int pid in lstPID )
                {
                    if ( killType == 0 )
                    {
                        #region 调用cmd.exe结束进程
                        Classes.Logger.Write( "开始尝试结束进程" + pid.ToString() );

                        System.Diagnostics.Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";

                        cmd.StartInfo.UseShellExecute = false;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardError = true;
                        cmd.StartInfo.CreateNoWindow = true;

                        string command = "taskkill /PID " + pid + " /F /T";
                        cmd.Start();
                        cmd.StandardInput.WriteLine( command );
                        Classes.Logger.Write( command );

                        cmd.StandardInput.WriteLine( "exit" );
                        Classes.Logger.Write( "exit" );
                        cmd.WaitForExit();
                        cmd.Close();

                        Classes.Logger.Write( "执行结束！" );
                        #endregion
                    }
                    else
                    {
                        #region 使用Process类结束进程
                        try
                        {
                            //第一次开始查找进程ID
                            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById( pid );
                            int count = 1;
                            int maxCount = 3;
                            //如果找到进程，进入循环尝试结束进程，次数为maxCount指定
                            while ( count <= maxCount )
                            {
                                Classes.Logger.Write( string.Format( "正在第{0}尝试结束进程{1}" , count , pid ) );
                                p.Kill();
                                p.WaitForExit();
                                try
                                {
                                    //重新根据ID获取进程
                                    p = System.Diagnostics.Process.GetProcessById( pid );
                                }
                                catch
                                {
                                    //如果发生ArgementException,说明进程已经结束,跳出while循环
                                    Classes.Logger.Write( string.Format( "进程{0}已经结束" , pid ) );
                                    break;
                                }

                                if ( count == maxCount )
                                {
                                    //如果尝试次数到达限定次数，跳出循环
                                    Classes.Logger.Write( string.Format( "尝试连续{0}次结束进程{1}失败！" , maxCount , pid ) );
                                    break;
                                }
                                else
                                {
                                    //重新根据ID获取进程的操作如果成功，则进行下一次循环来结束进程
                                    count++;
                                }
                            }
                        }
                        catch ( ArgumentException argex )
                        {
                            //第一次开始查找进程发生错误
                            Classes.Logger.Write( string.Format( "进程{0}未启动或已结束！" , pid ) );
                        }
                        catch ( Exception error )
                        {
                            Classes.Logger.Write( string.Format( "在结束进程{0}时发生错误" , error ) );
                        }
                        #endregion
                    }
                }
                Classes.Logger.Write( "检测进程并结束相关进程的处理结束" );                
                return;
                /**********************************************************************/

                #region wangzhi 2013-06-18 注释，暂不用
                /*
                System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName( procName );
                //MessageBox.Show(procName + " KillProcess前:" + procs.Length.ToString());
                while ( procs.Length > 0 )
                {
                    for ( int i = 0 ; i < procs.Length ; i++ )
                    {
                        try
                        {
                            if ( !procs[i].HasExited )
                            {
                                //MessageBox.Show(procName + " kill 前" + procs[i].ToString());
                                procs[i].Kill();
                                //MessageBox.Show(procName + " kill 后" + procs[i].ToString());
                            }
                            procs[i].Close();
                            procs[i].Dispose();

                            procs = System.Diagnostics.Process.GetProcessesByName( procName );
                        }
                        catch ( Exception ex )
                        {
                            //MessageBox.Show(procName + " kill 进程  出错：" + ex.Message);
                        }
                    }

                }
                //MessageBox.Show(procName + " KillProcess后:" + procs.Length.ToString());
                 * */
                #endregion
            }
            catch
            {
                //throw new Exception("升级程序无法关闭" + procName + "应用程序，请手工关闭程序后再试" + err.Message);
                //MessageBox.Show("升级程序无法关闭相关应用程序，请手工关闭程序后再试" + err.Message);
                //return;
            }
        }

        

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public static string GetIniString( string lpApplicationName , string lpKeyName, string lpFileName )
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }
    }
}
