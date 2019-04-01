using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using System.Runtime.InteropServices;
namespace ts_call
{
    public class ts_call_led_cnfy : Icall
    {
        #region Icall 成员
        public static readonly string debugFlag = ApiFunction.GetIniString("报价器文件路径", "dll路径", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string com = ApiFunction.GetIniString("报价器文件路径", "通讯端口", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string ip = ApiFunction.GetIniString("报价器文件路径", "ip", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public  string zt = ApiFunction.GetIniString("报价器文件路径", "字体", Constant.ApplicationDirectory + "//ClientWindow.ini");

        public static readonly string left = ApiFunction.GetIniString("报价器文件路径", "left", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string top = ApiFunction.GetIniString("报价器文件路径", "top", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string width = ApiFunction.GetIniString("报价器文件路径", "width", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string height = ApiFunction.GetIniString("报价器文件路径", "height", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string ycsj = ApiFunction.GetIniString("报价器文件路径", "语音延迟时间", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public string ztlx = ApiFunction.GetIniString("报价器文件路径", "字体类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
        private const int WM_LED_NOTIFY = 1025;

        CLEDSender LEDSender = new CLEDSender();

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
        private void GetDeviceParam(ref TDeviceParam param)
        {
            switch (1)
            {
                case 0:
                    param.devType = LEDSender.DEVICE_TYPE_COM;
                    break;
                case 1:
                    param.devType = LEDSender.DEVICE_TYPE_UDP;
                    break;
            }
            param.comPort = (ushort)Convert.ToInt16(com);
            param.comSpeed = 0;
            param.locPort = (ushort)Convert.ToInt16(com);
            param.rmtHost = ip;
            param.rmtPort = 6666;
            param.dstAddr = 0;
            param.txTimeo = 100;
            param.txRepeat = 3;
        }
        private void clearScreen()
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)0;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, LEDSender.COLOR_MODE_DOUBLE, LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 3000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K,  int.Parse(left), int.Parse(top), int.Parse(width), int.Parse(height),0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 3000, LEDSender.WAIT_CHILD);
        }
        private void sendText(string context, int row)
        {
            LEDSender.Do_LED_Startup();
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)0;
            param.wmMessage = WM_LED_NOTIFY;
            System.Drawing.Font font = new System.Drawing.Font("宋体", float.Parse(zt)); 
            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, LEDSender.COLOR_MODE_DOUBLE, LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 3000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, int.Parse(left), int.Parse(top) + font.Height * row + 3, int.Parse(width), int.Parse(height), 0);//-18

            //第1页面
            LEDSender.Do_AddLeaf(K, 3000, LEDSender.WAIT_CHILD);
            //自动换行的文字
            // LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world! 宁采成，HELLO WORLD!", "宋体", 9, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 1, 1, 1, 0, 1, 3);
            //非自动换行的文字
     
            if (row >= 0)
                LEDSender.Do_AddText(K, 0, 16, 64, 64, LEDSender.V_TRUE, 0, context, "宋体", int.Parse(zt), 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 2, 3, 1, 1, 0,0, 1);//0 静态显示
            //if (row >=1)
            //    LEDSender.Do_AddText(K, 0, 16+font.Height*row+3, 64, 32, LEDSender.V_TRUE, 0, context, "宋体", int.Parse(zt), 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 2, 3, 1, 1, 1, 0, 1);

            //System.Threading.Thread.Sleep(100000);
            //  LEDSender.Do_AddText(K, 0, 16, 64, 32, LEDSender.V_TRUE, 0, "谢谢，收您1000.找您50", "宋体", 12, 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE,0, 2, 3, 1, 1, 1, 1, 1);

            //第2页面
            //   LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //非自动换行的文字
            //  LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world!", "宋体", 12, 0xffff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 1, 1, 1, 1, 1, 5);


             Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
        }
        private void sendText(string[] context, int row)
        {
            LEDSender.Do_LED_Startup();
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)0;
            param.wmMessage = WM_LED_NOTIFY;
            if (ztlx == "")
                ztlx = "宋体";
            System.Drawing.Font font = new System.Drawing.Font(ztlx, float.Parse(zt));
            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, LEDSender.COLOR_MODE_DOUBLE, LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 3000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, int.Parse(left), int.Parse(top) , int.Parse(width), int.Parse(height), 0);//-18

            //第1页面
            LEDSender.Do_AddLeaf(K, 3000, LEDSender.WAIT_CHILD);
            //自动换行的文字
            // LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world! 宁采成，HELLO WORLD!", "宋体", 9, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 1, 1, 1, 0, 1, 3);
            //非自动换行的文字
            //+ font.Height * row + 3
            for (int i = 0; i < context.Length; i++)
            {
                LEDSender.Do_AddText(K, 0, 16 + font.Height * i + 3, 64, font.Height + 3, LEDSender.V_TRUE, 0, context[i], ztlx, int.Parse(zt), 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0,1, 3, 1, 1, 0, 0, 1);//0 静态显示
            }
            //    if (row >= 0)
            //        LEDSender.Do_AddText(K, 0, 16 + font.Height * row + 3, 64, 64, LEDSender.V_TRUE, 0, context, "宋体", int.Parse(zt), 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 2, 3, 1, 1, 0, 0, 1);//0 静态显示
            ////if (row >=1)
            //    LEDSender.Do_AddText(K, 0, 16+font.Height*row+3, 64, 32, LEDSender.V_TRUE, 0, context, "宋体", int.Parse(zt), 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 2, 3, 1, 1, 1, 0, 1);

            //System.Threading.Thread.Sleep(100000);
            //  LEDSender.Do_AddText(K, 0, 16, 64, 32, LEDSender.V_TRUE, 0, "谢谢，收您1000.找您50", "宋体", 12, 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE,0, 2, 3, 1, 1, 1, 1, 1);

            //第2页面
            //   LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //非自动换行的文字
            //  LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world!", "宋体", 12, 0xffff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 1, 1, 1, 1, 1, 5);


            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
        }
        private void Parse2(Int32 K)
        {
            string Text = "";
            TNotifyParam notifyparam = new TNotifyParam();
            if (K >= 0)
            {
                LEDSender.Do_LED_GetNotifyParam(ref notifyparam, K);

                if (notifyparam.notify == LEDSender.LM_TIMEOUT)
                {
                    Text = "命令执行超时";
                }
                else if (notifyparam.notify == LEDSender.LM_TX_COMPLETE)
                {
                    if (notifyparam.result == LEDSender.RESULT_FLASH)
                    {
                        Text = "数据传送完成，正在写入Flash";
                    }
                    else
                    {
                        Text = "数据传送完成";
                    }
                }
                else if (notifyparam.notify == LEDSender.LM_RESPOND)
                {
                    if (notifyparam.command == LEDSender.PKC_GET_POWER)
                    {
                        if (notifyparam.status == LEDSender.LED_POWER_ON) Text = "读取电源状态完成，当前为电源开启状态";
                        else if (notifyparam.status == LEDSender.LED_POWER_OFF) Text = "读取电源状态完成，当前为电源关闭状态";
                    }
                    else if (notifyparam.command == LEDSender.PKC_SET_POWER)
                    {
                        if (notifyparam.result == 99) Text = "当前为定时开关屏模式";
                        else if (notifyparam.status == LEDSender.LED_POWER_ON) Text = "设置电源状态完成，当前为电源开启状态";
                        else Text = "设置电源状态完成，当前为电源关闭状态";
                    }
                    else if (notifyparam.command == LEDSender.PKC_GET_BRIGHT)
                    {
                        Text = string.Format("读取亮度完成，当前亮度={0:D}", notifyparam.status);
                    }
                    else if (notifyparam.command == LEDSender.PKC_SET_BRIGHT)
                    {
                        if (notifyparam.result == 99) Text = "当前为定时亮度调节模式";
                        else Text = string.Format("设置亮度完成，当前亮度={0:D}", notifyparam.status);
                    }
                    else if (notifyparam.command == LEDSender.PKC_ADJUST_TIME)
                    {
                        Text = "校正显示屏时间完成";
                    }
                }
            }
            else if (K == LEDSender.R_DEVICE_INVALID) Text = "打开通讯设备失败(串口不存在、或者串口已被占用、或者网络端口被占用)";
            else if (K == LEDSender.R_DEVICE_BUSY) Text = "设备忙，正在通讯中...";
            Writlog(Text);
        }
        private void Writlog(string ss)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.DateTime.Now.ToLongDateString() + ".txt", true);
            sw.Write(System.DateTime.Now.ToString()+"==>>"+ss);
            sw.Close();
            sw.Dispose();
        }
        /// <summary>
        /// 姓名
        /// </summary>
        private static string xm="";
        /// <summary>
        /// 应收
        /// </summary>
        private static string ys = "";
        /// <summary>
        /// 实收
        /// </summary>
        private static string ss = "";
        /// <summary>
        /// 找零
        /// </summary>
        private static string zl = "";
        /// <summary>
        /// 第二行显示
        /// </summary>
        private static string dehxs = "";
        public void Call(DmType dmtype, string callstring)
        {
            ts_Caller.ts_call_AxCL2005_16W caller = new ts_Caller.ts_call_AxCL2005_16W();
            //int i = SetTransMode(2, 3);//通讯设置
            //i = SetSerialPortPara(1, Convert.ToInt32(com), 115200);//设置串口通讯
            //StartSend();//构建节目结构
            //i = AddControl(1, 1);//添加屏幕
            //i = AddProgram(1, 1, 0);//添加节目

            string str = "";
            int row = 0;
            if (callstring == "您好,欢迎光临")
            {
                //SendScreenPara(1, 1, 128, 32);//设置屏幕参数
                str = "祝您早日康复";

            }
            else if (dmtype == DmType.姓名)
            {
                str = "姓名:" + callstring;
                caller.Call(str);// jianqg 2013-4-11 增加 郴州妇幼需求 必须呼叫姓名
                row = 0;
                xm = str;
                dehxs = "";
                ys = "";
                ss = "";
                zl = "";
            }
            else if (dmtype == DmType.应收)
            {
                str = "应收:" + callstring + "元";
                caller.Call(str);
                row = 1;
                ys = str;
                ss = "";
                zl = "";
                dehxs = str;

            }
            else
                if (dmtype == DmType.实收)
                {

                    str = "实收:" + callstring + "元";
                    caller.Call(str);
                    row = 2;
                    ss = str;
                    zl = "";
                    dehxs = str;
                }
                else
                    if (dmtype == DmType.找零)
                    {

                        str = "找零:" + callstring + "元";
                        caller.Call(str);
                        row = 3;
                        ss = str;//把找零放到找零那里
                        dehxs = str;
                    }
                    else if (dmtype == DmType.清除)
                    {
                        clearScreen();
                    }
                    else
                        str = callstring;

            //  i = AddLnTxtString(1, 1, 1, 0, 0, 128, 32, str, "宋体", 16, 255, false, false, false, 1, 20, 1);//添加单行文本
            Thread.Sleep(int.Parse(ycsj));//程序需要休眠100毫秒 才能 最好的显示到LED屏幕上
            // i = SendControl(1, 1, IntPtr.Zero);//发送端口数据
            string[] context = new string[] { xm, dehxs };
            sendText(context, row);
        }

        public void Call(string ss, string zl)
        {

            ts_Caller.ts_call_AxCL2005_16W caller = new ts_Caller.ts_call_AxCL2005_16W();
            string str = "实收:" + ss + "元";
            // jianqg 2013-4-11  修改，实收与找零一并呼叫， 郴州妇幼需求
            string strcall = str;
            if (zl != null && zl.Trim() != "" && Convertor.IsNumeric(zl) && double.Parse(zl) > 0)
            {
                strcall += "找零:" + zl + "元";
            }
            //int i = AddLnTxtString(1, 1, 1, 0, 0, 128, 32, str, "宋体", 16, 255, false, false, false, 1, 20, 1);
            Thread.Sleep(100);
            caller.Call(strcall);// caller.Call(str); // jianqg 2013-4-11    修改
            //   i = SendControl(1, 1, IntPtr.Zero);
            str = "找零:" + zl + "元";
            // i = AddLnTxtString(1, 1, 1, 0, 0, 128, 32, str, "宋体", 16, 255, false, false, false, 1, 20, 1);

            Thread.Sleep(int.Parse(ycsj));
            //caller.Call(str);// jianqg 2013-4-11  注释
            //  i = SendControl(1, 1, IntPtr.Zero);
            sendText(str, 0);
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
        //    throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
