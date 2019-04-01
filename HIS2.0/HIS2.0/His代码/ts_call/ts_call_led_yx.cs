using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using System.IO;
using System.Runtime.Remoting.Channels.Tcp;
using ICommon;
using System.Runtime.Remoting.Channels;

namespace ts_call
{
    public class ts_call_led_yx:Icall
    {
        public static int isRegChannel = 0;
        public ts_call_led_yx()
        {

        }

        //public static readonly string tcpIp = "tcp://localhost:8080/";
        public static readonly string tcpIp = ApiFunction.GetIniString("报价器文件路径", "语音IP地址", Constant.ApplicationDirectory + "//ClientWindow.ini");

        public static readonly string showWind = ApiFunction.GetIniString("报价器文件路径", "显示窗口", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string WindCode = ApiFunction.GetIniString("报价器文件路径", "窗口编号", Constant.ApplicationDirectory + "//ClientWindow.ini");

        #region 注释，作废
        //public static int A = 0;
        //public static readonly string debugFlag = ApiFunction.GetIniString("报价器文件路径", "dll路径", Constant.ApplicationDirectory + "//ClientWindow.ini");
        //public static readonly string coms = ApiFunction.GetIniString("报价器文件路径", "串口号", Constant.ApplicationDirectory + "//ClientWindow.ini");
        //public static readonly string comType = ApiFunction.GetIniString("报价器文件路径", "通讯连接类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
        //public static readonly string sIPs = ApiFunction.GetIniString("报价器文件路径", "控制卡IP地址", Constant.ApplicationDirectory + "//ClientWindow.ini"); //本地或远程控制卡预先设定的IP地址
        //public static readonly string port_baud = ApiFunction.GetIniString("报价器文件路径", "连接端口号", Constant.ApplicationDirectory + "//ClientWindow.ini"); //控制命令回应时间
        //public static readonly string delays = ApiFunction.GetIniString("报价器文件路径", "控制命令回应时间", Constant.ApplicationDirectory + "//ClientWindow.ini"); //控制命令回应时间
        //public static readonly string addrs = ApiFunction.GetIniString("报价器文件路径", "显示屏地址", Constant.ApplicationDirectory + "//ClientWindow.ini"); //显示屏地址

        //public static readonly string effect = ApiFunction.GetIniString("报价器文件路径", "播放方式", Constant.ApplicationDirectory + "//ClientWindow.ini"); //显示屏地址
        //public static readonly string level = ApiFunction.GetIniString("报价器文件路径", "速度级别", Constant.ApplicationDirectory + "//ClientWindow.ini"); //显示屏地址
        //public static readonly string speed = ApiFunction.GetIniString("报价器文件路径", "播放速度", Constant.ApplicationDirectory + "//ClientWindow.ini"); //显示屏地址
        //public static readonly string delay = ApiFunction.GetIniString("报价器文件路径", "停留时间", Constant.ApplicationDirectory + "//ClientWindow.ini"); //显示屏地址
        //public static readonly string font = ApiFunction.GetIniString("报价器文件路径", "字体大小", Constant.ApplicationDirectory + "//ClientWindow.ini"); //显示屏地址
        //public static readonly string showTitle = ApiFunction.GetIniString("报价器文件路径", "是否显示标题", Constant.ApplicationDirectory + "//ClientWindow.ini"); //显示屏地址
        //public static readonly string titleColor = ApiFunction.GetIniString("报价器文件路径", "标题颜色", Constant.ApplicationDirectory + "//ClientWindow.ini"); //显示屏地址
        //public static readonly string wordColor = ApiFunction.GetIniString("报价器文件路径", "内容颜色", Constant.ApplicationDirectory + "//ClientWindow.ini"); //显示屏地址

        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Com")]
        //private static extern int SS_Open_Com(int addr, int com, int baud, int delay);//打开串口函数
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Tcp")]
        //private static extern int SS_Open_Tcp(string sIP, int port, int delay);//打开TCP连接函数
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Open_Udp")]
        //private static extern int SS_Open_Udp(string sIP, int port, int delay);//打开UDP连接函数
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Close")]
        //private static extern void SS_Close();//关闭通讯连接

        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Time")]
        //private static extern int SS_Send_Time();//控制卡时钟校正
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Reset")]
        //private static extern int SS_Send_Reset();//控制卡复位
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Replay")]
        //private static extern int SS_Send_Replay();
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List")]
        //private static extern string SS_Get_Window_List();//读取播放窗口列表
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_File")]
        //private static extern int SS_Send_File(int W_index, ref TFileParam param, string ListFile, bool IsSave);//往指定的窗口中传送指定文件列表数据
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Buffer")]
        //private static extern int SS_Send_Buffer(int W_index, ref TFileParam param, string Buffer, bool IsSave);//往指定的窗口中传送指定字符串数据
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Delete_File")]
        //private static extern int SS_Delete_File(int W_index);//删除指定的窗口中的保存的播放数据
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Buffer_Ex")]
        //private static extern int SS_Send_Buffer_Ex(int W_index, int Effect, int Speed, int Delay, int FontSize, int Color, string Buffer, bool IsSave);//发送字符串
        ////[DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List_Ex")]
        ////private static extern int SS_Get_Window_List_Ex(string win_list);//获取窗体
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Power_Off")]
        //private static extern int SS_Send_Power_Off();//关闭显示屏
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Send_Power_On")]
        //private static extern int SS_Send_Power_On();//打开显示屏
        //[DllImport("pArmSendQt.dll", EntryPoint = "SS_Get_Window_List_Ex")]
        //private static extern int SS_Get_Window_List_Ex(ref string win_list);//读取播放窗口列表

        //[StructLayout(LayoutKind.Sequential,CharSet = CharSet.Auto) ]  
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
        #endregion

        #region Icall 成员
        public ILedShow obj = null;
        private Thread currentThread;
        public Thread CurrentThread
        {
            get
            {
                return currentThread;
            }
            set
            {
                currentThread = value;
            }
        }

        public void Call(DmType dmtype, string callstring)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public void Call(string ss, string zl)
        {
            //throw new Exception("The method or operation is not implemented.");
        }
    
        public void Call(DmType dmtype, string callstring, double je)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 药房发药
        /// </summary>
        /// <param name="dmtype"></param>
        /// <param name="callstring"></param>
        /// <param name="je"></param>
        /// <param name="CFMX"></param>
        public void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX)
        {
            if (dmtype == DmType.发药呼叫)
            {
                try
                {
                    if (isRegChannel == 0)
                    {
                        ChannelServices.RegisterChannel(new TcpClientChannel(), false);
                        isRegChannel = 1;
                    }
                }
                catch (Exception ex)
                {
                    isRegChannel = 0;
                }
                try
                {
                    obj = (ILedShow)Activator.GetObject(typeof(ILedShow), tcpIp + "LED");
                    if (obj != null)
                    {
                        obj.SendMessage(CFMX[0].brxm, showWind, WindCode, CFMX[0].deptid.ToString());
                    }
                        //string patientName = "";
                        //string ssql = "select '' ";
                        //if (dmtype == DmType.发药)
                        //{
                        //    patientName = "发药窗口" + CFMX[0].fyck + "正在为" + callstring + "发药 ";//+ "总金额为：" + je.ToString()+"元";
                        //    //Display(patientName, 1);
                        //}
                        //string ss = "请" + CFMX[0].brxm + "到" + CFMX[0].fyck + "来取药";
                }
                catch (Exception er)
                {

                }
            }

         
            //if (dmtype == DmType.欢迎)
            //{
            //    Get_Window_List();
            //}
            //if (dmtype == DmType.卡充值)
            //{
            //    Send_Reset();
            //}
            //if (dmtype == DmType.清除)
            //{
            //    Delete_File();
            //}
        }

        public void SetPicture(string picturename)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

    }
}
