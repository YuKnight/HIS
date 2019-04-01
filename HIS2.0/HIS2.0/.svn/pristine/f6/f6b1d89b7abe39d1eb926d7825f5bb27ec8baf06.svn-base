using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using System.IO;

namespace LED_RemotingServer
{
    public class LED_Operate
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LED_Operate()
        {
 
        }

        public static int A = 0;
        public static readonly string debugFlag = ApiFunction.GetIniString("LED服务器", "dll路径", Constant.ApplicationDirectory + "//LedCalling.ini");
        public static readonly string coms = ApiFunction.GetIniString("LED服务器", "串口号", Constant.ApplicationDirectory + "//LedCalling.ini");
        public static readonly string comType = ApiFunction.GetIniString("LED服务器", "通讯连接类型", Constant.ApplicationDirectory + "//LedCalling.ini");
        public static readonly string sIPs = ApiFunction.GetIniString("LED服务器", "控制卡IP地址", Constant.ApplicationDirectory + "//LedCalling.ini"); //本地或远程控制卡预先设定的IP地址
        public static readonly string port_baud = ApiFunction.GetIniString("LED服务器", "连接端口号", Constant.ApplicationDirectory + "//LedCalling.ini"); //控制命令回应时间
        public static readonly string delays = ApiFunction.GetIniString("LED服务器", "控制命令回应时间", Constant.ApplicationDirectory + "//LedCalling.ini"); //控制命令回应时间
        public static readonly string addrs = ApiFunction.GetIniString("LED服务器", "显示屏地址", Constant.ApplicationDirectory + "//LedCalling.ini"); //显示屏地址

        public static readonly string effect = ApiFunction.GetIniString("LED服务器", "播放方式", Constant.ApplicationDirectory + "//LedCalling.ini"); //显示屏地址
        public static readonly string level = ApiFunction.GetIniString("LED服务器", "速度级别", Constant.ApplicationDirectory + "//LedCalling.ini"); //显示屏地址
        public static readonly string speed = ApiFunction.GetIniString("LED服务器", "播放速度", Constant.ApplicationDirectory + "//LedCalling.ini"); //显示屏地址
        public static readonly string delay = ApiFunction.GetIniString("LED服务器", "停留时间", Constant.ApplicationDirectory + "//LedCalling.ini"); //显示屏地址
        public static readonly string font = ApiFunction.GetIniString("LED服务器", "字体大小", Constant.ApplicationDirectory + "//LedCalling.ini"); //显示屏地址
        public static readonly string showTitle = ApiFunction.GetIniString("LED服务器", "是否显示标题", Constant.ApplicationDirectory + "//LedCalling.ini"); //显示屏地址
        public static readonly string titleColor = ApiFunction.GetIniString("LED服务器", "标题颜色", Constant.ApplicationDirectory + "//LedCalling.ini"); //显示屏地址
        public static readonly string wordColor = ApiFunction.GetIniString("LED服务器", "内容颜色", Constant.ApplicationDirectory + "//LedCalling.ini"); //显示屏地址
        public static readonly string sfzy = ApiFunction.GetIniString("LED服务器", "释放资源", Constant.ApplicationDirectory + "//LedCalling.ini"); //显示屏地址

        public static readonly string qingpingshijian = ApiFunction.GetIniString("LED服务器", "清屏时间", Constant.ApplicationDirectory + "//LedCalling.ini"); //清屏时间 分钟
        public static readonly string yuying_xuhao = ApiFunction.GetIniString("LED服务器", "语音序号", Constant.ApplicationDirectory + "//LedCalling.ini"); //语音序号
        public static readonly string yuying_sudu = ApiFunction.GetIniString("LED服务器", "语音速度", Constant.ApplicationDirectory + "//LedCalling.ini"); //语音速度
        public static readonly string yuying_yingliang = ApiFunction.GetIniString("LED服务器", "语音音量", Constant.ApplicationDirectory + "//LedCalling.ini"); //语音音量

        [StructLayout(LayoutKind.Sequential)]
        public struct TFileParam
        {
            public byte Effect;		//播放方式 1~17（见附注3）
            public byte Level;		//速度级别 0~7 （0最慢/7最快，速度粗调）
            public byte Speed;		//播放速度 0~31（0最快/31最慢，速度微调）
            public byte Delay;		//停留时间 0~99
            //以下参数仅对文本文件有效，图形文件可为任意值
            public byte Font;	    //字体大小 16或24
            public byte ShowTitle;	//是否显示标题 0不显/1显示
            public byte TitleColor; //标题颜色 0红/1绿/2黄
            public byte WordColor;	//内容颜色 0红/1绿/2黄
        }

        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Com")]
        private static extern int SS_Open_Com(int addr, int com, int baud, int delay);//打开串口函数
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Tcp")]
        private static extern int SS_Open_Tcp(string sIP, int port, int delay);//打开TCP连接函数
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Udp")]
        private static extern int SS_Open_Udp(string sIP, int port, int delay);//打开UDP连接函数
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Close")]
        private static extern void SS_Close();//关闭通讯连接

        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Time")]
        private static extern int SS_Send_Time();//控制卡时钟校正
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Reset")]
        private static extern int SS_Send_Reset();//控制卡复位
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Replay")]
        private static extern int SS_Send_Replay();
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List")]
        private static extern string SS_Get_Window_List();//读取播放窗口列表
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_File")]
        private static extern int SS_Send_File(int W_index, ref TFileParam param, string ListFile, bool IsSave);//往指定的窗口中传送指定文件列表数据
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Buffer")]
        private static extern int SS_Send_Buffer(int W_index, ref TFileParam param, string Buffer, bool IsSave);//往指定的窗口中传送指定字符串数据
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Delete_File")]
        private static extern int SS_Delete_File(int W_index);//删除指定的窗口中的保存的播放数据
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Buffer_Ex")]
        private static extern int SS_Send_Buffer_Ex(int W_index, int Effect, int Speed, int Delay, int FontSize, int Color, string Buffer, bool IsSave);//发送字符串
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List_Ex")]
        //private static extern int SS_Get_Window_List_Ex(string win_list);//获取窗体
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Power_Off")]
        private static extern int SS_Send_Power_Off();//关闭显示屏
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Power_On")]
        private static extern int SS_Send_Power_On();//打开显示屏
        [DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List_Ex")]
        private static extern int SS_Get_Window_List_Ex(ref string win_list);//读取播放窗口列表

        //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        //public struct TFileParam
        //{
        //    public byte Effect;		//播放方式 1~17（见附注3）
        //    public byte Level;		//速度级别 0~7 （0最慢/7最快，速度粗调）
        //    public byte Speed;		//播放速度 0~31（0最快/31最慢，速度微调）
        //    public byte Delay;		//停留时间 0~99
        //    //以下参数仅对文本文件有效，图形文件可为任意值
        //    public byte Font;	    //字体大小 16或24
        //    public byte ShowTitle;	//是否显示标题 0不显/1显示
        //    public byte TitleColor; //标题颜色 0红/1绿/2黄
        //    public byte WordColor;	//内容颜色 0红/1绿/2黄
        //}

      
        /// <summary>
        /// 显示发送信息
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="w_index"></param>
        /// <returns></returns>
        public bool Display(string strName, int w_index)
        {
            try
            {
                toText("操作日志", "LED显示：" + strName);
                if (!Open_Led())
                    return false;
                //System.Threading.Thread.Sleep(50);
                if (!Send_Buffer(strName, w_index))
                    return false;
                SS_Close();
                return true;
            }
            catch (Exception ex)
            {
                SS_Close();
                toText("错误日志", "LED显示数据发送失败：" + ex.Message);
                return false;
            }
        }

        #region 测试函数
        /// <summary>
        /// 获取窗体
        /// </summary>
        /// <returns></returns>
        private bool Get_Window_List()
        {
            string win_list = "";
            try
            {
                if (!Open_Led())
                    return false;
                int i = SS_Get_Window_List_Ex(ref win_list);
                if (i != 0)
                {
                    toText("错误日志", "获取窗口错误LED报错" + i.ToString());
                    return false;
                }
                else
                    toText("错误日志", win_list);
                SS_Close();
                return true;
            }
            catch (Exception ex)
            {
                SS_Close();
                toText("错误日志", "获取窗口错误" + ex.Message);
                return false;
            }
        }

        /// <summary>
        ///  删除文件
        /// </summary>
        /// <returns></returns>
        private bool Delete_File()
        {
            try
            {
                if (!Open_Led())
                    return false;
                int i = SS_Delete_File(0);
                if (i != 0)
                {
                    throw new Exception(i.ToString());
                    //return false;
                }
                SS_Close();
                return true;
            }
            catch (Exception ex)
            {
                SS_Close();
                throw new Exception(ex.Message);
                //return false;
            }
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <returns></returns>
        public bool Send_Reset()
        {
            try
            {
                if (!Open_Led())
                    return false;
                int i = SS_Send_Reset();
                if (i != 0)
                {
                    
                    return false;
                }
                SS_Close();
                return true;
            }
            catch (Exception ex)
            {
                SS_Close();
                //throw new Exception(ex.Message);
                return false;
            }
        }



        /// <summary>
        /// 校准时间
        /// </summary>
        /// <returns></returns>
        private bool Send_Time()
        {
            try
            {
                if (!Open_Led())
                    return false;
                int i = SS_Send_Time();
                if (i != 0)
                {
                    throw new Exception(i.ToString());
                    //return false;
                }
                SS_Close();
                return true;
            }
            catch (Exception ex)
            {
                SS_Close();
                throw new Exception(ex.Message);
                //return false;
            }
        }
        #endregion

        #region 基础操作
        /// <summary>
        /// 打开显示连接
        /// </summary>
        /// <param name="comType">1为串口连接，2为TCP连接，3为UDP连接</param>
        /// <returns></returns>
        private bool Open_Led()
        {
            try
            {
                int i = -1;
                int port;
                int delay;
                switch (comType)
                {
                    case "1":
                        int com = Convert.ToInt32(coms);
                        int addr = Convert.ToInt32(addrs);
                        int baud = Convert.ToInt32(port_baud);
                        delay = Convert.ToInt32(delays);
                        i = SS_Open_Com(addr, com, baud, delay);
                        break;
                    case "2":
                        port = Convert.ToInt32(port_baud);
                        delay = Convert.ToInt32(delays);
                        i = SS_Open_Tcp(sIPs, port, delay);
                        break;
                    case "3":
                        port = Convert.ToInt32(port_baud);
                        delay = Convert.ToInt32(delays);
                        i = SS_Open_Tcp(sIPs, port, delay);
                        break;
                    default:
                        break;
                }
                if (i == 0)
                    return true;
                else
                {
                    toText("错误日志", "LED显示连接失败LED报错：" + i.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                toText("错误日志", "LED显示连接失败：" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 发送字符串
        /// </summary>
        /// <param name="sendstr"></param>
        /// <param name="w_index"></param>
        /// <returns></returns>
        private bool Send_Buffer(string sendstr, int w_index)
        {
            try
            {
                int i = -1;
                //TFileParam param = new TFileParam();
                //param.Effect = Convert.ToByte(effect);
                //param.Level = Convert.ToByte(level);
                //param.Speed = Convert.ToByte(speed);
                //param.Delay = Convert.ToByte(delay);
                //param.Font = Convert.ToByte(font);
                //param.ShowTitle = Convert.ToByte(showTitle);
                //param.TitleColor = Convert.ToByte(titleColor);
                //param.WordColor = Convert.ToByte(wordColor);
                //i = SS_Send_Buffer(w_index, ref param, sendstr, false);
                i = SS_Send_Buffer_Ex(w_index, Convert.ToInt32(effect), Convert.ToInt32(speed), Convert.ToInt32(delay), Convert.ToInt32(font), Convert.ToInt32(wordColor), sendstr, false);
                if (i == 0)
                    return true;
                else
                {
                    toText("错误日志", "LED传输数据内部报错：错误代码" + i.ToString() + ",窗口号" + w_index.ToString() + ",播放方式" + effect + ",播放速度" + speed + ",停留时间" + delay + ",字体大小" + font + ",内容颜色" + wordColor + sendstr);
                    return false;
      
                }
            }
            catch (Exception ex)
            {
                toText("错误日志", "LED显示传输数据失败：" + ex.Message);
                return false;
            }

        }
        /// <summary>
        /// 删除 5天前的日志
        /// </summary>
        /// <param name="FILE_NAME"></param>
        public static void DeleteFile_Log(string FILE_NAME)
        {
            DateTime dtime=DateTime.Now.Date.AddDays(-5);
            for(int i=30;i>=0;i--)
            {

                try
                {
                    string file_name = Constant.ApplicationDirectory + " \\" + FILE_NAME + dtime.AddDays(i * -1).ToString("yyyyMMdd") + ".txt";
                    if (System.IO.File.Exists(file_name))
                    {
                        System.IO.File.Delete(file_name);
                    }
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 写日志记录
        /// </summary>
        /// <param name="FILE_NAME"></param>
        /// <param name="text"></param>
        public static void toText(string FILE_NAME, string text)
        {
            try
            {

                string file_name = Constant.ApplicationDirectory + " \\" + FILE_NAME + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (File.Exists(file_name))
                {
                    using (StreamWriter sw = File.AppendText(file_name))
                    {
                        text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + ":" + text;
                        sw.WriteLine(text + "\n");
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    StreamWriter sr = File.CreateText(file_name);
                    sr.Close();
                }
            }
            catch
            { 
               

            }
            finally           
            { 
               ShiFangZiYuan();
            }            
        }
        #endregion



        [DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放资源 2014-4-28
        /// </summary>
        public static void ShiFangZiYuan()
        {
            try
            {
                if (sfzy == "1")
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    //if (System.Environment.OSVersion.Platform == PlatformID.Win32NT)
                    //{
                    //    SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                    //}
                }
            }
            catch { }
        }

    }

}
