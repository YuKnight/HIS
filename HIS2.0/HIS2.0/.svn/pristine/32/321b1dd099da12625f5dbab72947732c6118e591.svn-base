using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TrasenClasses;
using TrasenFrame.Classes;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;
namespace ts_call
{
    public class ts_call_led_cz : Icall
    {
        #region Icall 成员
        public static readonly string debugFlag = ApiFunction.GetIniString("报价器文件路径", "dll路径", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string com = ApiFunction.GetIniString("报价器文件路径", "通讯端口", Constant.ApplicationDirectory + "//ClientWindow.ini");

        [DllImport("ListenPlayDll.dll", EntryPoint = "SetTransMode")] //设置通讯模式
        private static extern int SetTransMode(int TransMode, int ConType);

        [DllImport("ListenPlayDll.dll", EntryPoint = "SetSerialPortPara")] //设置串口参数
        private static extern int SetSerialPortPara(int pno, int port, int rate);





        [DllImport("ListenPlayDll.dll", EntryPoint = "AddLnTxtString")] //添加单行文本（使用字符串）
        private static extern int AddLnTxtString(int pno, int jno, int qno, int left, int top, int width, int height, string text, string textname, int fontsize, int fontcolor, bool bold, bool italic, bool underline, int PlayStyle, int Playspeed, int times);

        [DllImport("ListenPlayDll.dll", EntryPoint = "SetTest")] //测试
        private static extern int SetTest(int pno, int value);


        [DllImport("ListenPlayDll.dll", EntryPoint = "AddControl")] //添加显示屏
        private static extern int AddControl(int pno, int DBColor);


        [DllImport("ListenPlayDll.dll", EntryPoint = "AddProgram")] //添加节目
        private static extern int AddProgram(int pno, int jno, int playTime);


        [DllImport("ListenPlayDll.dll", EntryPoint = "SetBrightness")] //添加显示屏
        private static extern int SetBrightness(int pno, int value);


        [DllImport("ListenPlayDll.dll", EntryPoint = "StartSend")] //初始化xml文件 
        private static extern int StartSend();

        [DllImport("ListenPlayDll.dll", EntryPoint = "SetProgramTimer")] //设置节目定时
        private static extern int SetProgramTimer(int pno, int jno, int TimingModel, int WeekSelect, int startSecond, int startMinute, int startHour, int startDay, int startMonth, int startWeek, int startYear, int endSecond, int endMinute, int endHour, int endDay, int endMonth, int endWeek, int endYear);

        [DllImport("ListenPlayDll.dll", EntryPoint = "SendControl")] //发送数据 
        private static extern int SendControl(int PNO, int SendType, IntPtr ip);


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("ListenPlayDll.dll", EntryPoint = "SendScreenPara")] //发送屏参
        private static extern int SendScreenPara(int PNO, int DBColor, int Width, int Height);


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
            ts_Caller.ts_call_AxCL2005_16W caller = new ts_Caller.ts_call_AxCL2005_16W();
            int i = SetTransMode(2, 3);//通讯设置
            i = SetSerialPortPara(1, Convert.ToInt32(com), 115200);//设置串口通讯
            StartSend();//构建节目结构
            i = AddControl(1, 1);//添加屏幕
            i = AddProgram(1, 1, 0);//添加节目

            string str = "";
            if (callstring == "您好,欢迎光临")
            {
                SendScreenPara(1, 1, 128, 32);//设置屏幕参数
                str = "祝您早日康复";
            }
            else if (dmtype == DmType.姓名)
            {
                str = "姓名:" + callstring;
                caller.Call(str);// jianqg 2013-4-11 增加 郴州妇幼需求 必须呼叫姓名

            }
            else if (dmtype == DmType.应收)
            {
                str = "应收:" + callstring + "元";
                caller.Call(str);
            }
            else
                str = callstring;
            i = AddLnTxtString(1, 1, 1, 0, 0, 128, 32, str, "宋体", 16, 255, false, false, false, 1, 20, 1);//添加单行文本
            Thread.Sleep(100);//程序需要休眠100毫秒 才能 最好的显示到LED屏幕上
            i = SendControl(1, 1, IntPtr.Zero);//发送端口数据
        }

        public void Call(string ss, string zl)
        {
            
            ts_Caller.ts_call_AxCL2005_16W caller = new ts_Caller.ts_call_AxCL2005_16W();
            string str = "实收:" + ss + "元";
            // jianqg 2013-4-11  修改，实收与找零一并呼叫， 郴州妇幼需求
            string strcall = str;
            if (zl != null && zl.Trim () !="" && Convertor.IsNumeric(zl) && double.Parse(zl) > 0)
            {
                strcall += "找零:" + zl + "元";
            }
            int i = AddLnTxtString(1, 1, 1, 0, 0, 128, 32, str, "宋体", 16, 255, false, false, false, 1, 20, 1);
            Thread.Sleep(100);
            caller.Call(strcall);// caller.Call(str); // jianqg 2013-4-11    修改
            i = SendControl(1, 1, IntPtr.Zero);
            str = "找零:" + zl + "元"; 
            i = AddLnTxtString(1, 1, 1, 0, 0, 128, 32, str, "宋体", 16, 255, false, false, false, 1, 20, 1);
            Thread.Sleep(100);
            //caller.Call(str);// jianqg 2013-4-11  注释
            i = SendControl(1, 1, IntPtr.Zero);
        }

        public void Call(DmType dmtype, string callstring, double je)
        {
            throw new NotImplementedException();
        }

        public void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 具体内容没实现 2013-8-8 by tck
        /// </summary>
        /// <param name="picturename"></param>
        public void SetPicture(string picturename)
        {
           // throw new Exception("The method or operation is not implemented.");
        }   

        #endregion
    }
}
