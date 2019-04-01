using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.GeneralClasses;
using System.Runtime.InteropServices;
using TrasenFrame.Classes;
using System.Threading;

namespace ts_call
{
    public class ts_call_led_VFD8C : Icall
    {
        public static int A = 0;
        public static readonly string debugFlag = ApiFunction.GetIniString("报价器文件路径", "dll路径", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string com = ApiFunction.GetIniString("报价器文件路径", "通讯端口", Constant.ApplicationDirectory + "//ClientWindow.ini");
        [DllImport("DisFun.dll", EntryPoint = "DisFun")]
        private static extern int DisFun(string hPort, string lpName, double dbMoney);

        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_OpenCom")]
        public static extern bool VFD8C_LED8C_OpenCom(int intPort);
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_CloseCom")]
        public static extern bool VFD8C_LED8C_CloseCom();
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_Clear")]
        public static extern bool VFD8C_LED8C_Clear();
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_CAN")]
        public static extern bool VFD8C_LED8C_CAN();
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_Reset")]
        public static extern bool VFD8C_LED8C_Reset();
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_DisplayNum")]
        public static extern bool VFD8C_LED8C_DisplayNum(string tbuf);
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_DisplayChar")]
        public static extern bool VFD8C_LED8C_DisplayChar(int iTransType);
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_DisplayThanksLine")]
        public static extern bool VFD8C_LED8C_DisplayThanksLine(int iThanksType, int iLine);
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_DisplayCurrency")]
        public static extern bool VFD8C_LED8C_DisplayCurrency(int iCurrency);
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_DisplayPOS")]
        public static extern bool VFD8C_LED8C_DisplayPOS(int iPOS);
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_SpeakOther")]
        public static extern bool VFD8C_LED8C_SpeakOther(int iOther);
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_SpeakSetup")]
        public static extern bool VFD8C_LED8C_SpeakSetup(int n, int m, int k1, int k2, int k3, int k4);
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_OpenBox")]
        public static extern bool VFD8C_LED8C_OpenBox();
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_DisplayNumChar")]
        public static extern bool VFD8C_LED8C_DisplayNumChar(string tbuf, int iTransType);
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_DisplayCharNum")]
        public static extern bool VFD8C_LED8C_DisplayCharNum(int iTransType, string tbuf);
        [DllImport("VFD8C_LED8C.dll", EntryPoint = "VFD8C_LED8C_Sendc")]
        public static extern bool VFD8C_LED8C_Sendc(string tbuf);


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
        //led报价器
        /// <summary>
        /// 显示屏显示
        /// </summary>
        /// <param name="dmtype"></param>
        /// <param name="callstring"></param>
        public void Call(DmType dmtype, string callstring)
        {
            try
            {
                string ncom = com;

                bool bok = false;
                bok= VFD8C_LED8C_OpenCom(Convert.ToInt32(ncom));
                

                if (dmtype == DmType.姓名)
                {
                   // DisFun(ncom, "" + callstring, 0);
                   VFD8C_LED8C_Reset();
                }
                if (dmtype == DmType.应收)
                {
                    VFD8C_LED8C_DisplayChar(2);
                    VFD8C_LED8C_DisplayNum(callstring);

                }
                if (dmtype == DmType.实收)
                {
                    VFD8C_LED8C_DisplayChar(3);
                    VFD8C_LED8C_DisplayNum(callstring);

                }
                if (dmtype == DmType.找零)
                {
                    VFD8C_LED8C_DisplayChar(4);
                    VFD8C_LED8C_DisplayNum(callstring);

                }
                if (dmtype == DmType.欢迎)
                {

                }
                if (dmtype == DmType.清除)
                {
                    VFD8C_LED8C_Reset();

                }
                VFD8C_LED8C_CloseCom();
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }

        }

        public void Call(string ss, string zl)
        {
            try
            {
                string ncom = com;

                VFD8C_LED8C_OpenCom(Convert.ToInt32(ncom));

                VFD8C_LED8C_DisplayChar(3);
                VFD8C_LED8C_DisplayNum(ss);

                System.Threading.Thread.Sleep(1 * 2000);

                VFD8C_LED8C_DisplayChar(4);
                VFD8C_LED8C_DisplayNum(zl);

                VFD8C_LED8C_CloseCom();
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }

        }

        /// <summary>
        /// 报价显示
        /// </summary>
        /// <param name="dmtype">枚举类型</param>
        /// <param name="callstring">显示字符串</param>
        /// <param name="je">金额</param>
        public void Call(DmType dmtype, string callstring, double je)
        {
            try
            {
                string ncom = com;
                VFD8C_LED8C_OpenCom(Convert.ToInt32(ncom));

                if (dmtype == DmType.姓名)
                {
                    VFD8C_LED8C_Reset();
                }
                else if (dmtype == DmType.找零)
                {
                    VFD8C_LED8C_DisplayChar(4);
                    VFD8C_LED8C_DisplayNum(je.ToString());
                }
                else if (dmtype == DmType.实收)
                {
                    string ss = "";
                    if (je >= 0)
                    {
                        ss = "实收";
                        VFD8C_LED8C_DisplayChar(3);
                        VFD8C_LED8C_DisplayNum(je.ToString());
                    }
                    else
                    {
                        ss = "退款";
                        VFD8C_LED8C_DisplayChar(3);
                        VFD8C_LED8C_DisplayNum(je.ToString());
                    }
                    //DisFun(ncom, ss, Math.Abs(je));
                }
                else
                {
                    Call(dmtype, callstring);
                }
                VFD8C_LED8C_CloseCom();
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX)
        {
            try
            {
                string ncom = com;
                VFD8C_LED8C_OpenCom(Convert.ToInt32(ncom));

                if (dmtype == DmType.姓名)
                {
                    VFD8C_LED8C_Reset();
                }
                else if (dmtype == DmType.找零)
                {
                    VFD8C_LED8C_DisplayChar(4);
                    VFD8C_LED8C_DisplayNum(je.ToString());
                }
                else if (dmtype == DmType.实收)
                {
                    string ss = "";
                    if (je >= 0)
                    {
                        ss = "实收";
                        VFD8C_LED8C_DisplayChar(3);
                        VFD8C_LED8C_DisplayNum(je.ToString());
                    }
                    else
                    {
                        ss = "退款";
                        VFD8C_LED8C_DisplayChar(3);
                        VFD8C_LED8C_DisplayNum(je.ToString());
                    }
                    //DisFun(ncom, ss, Math.Abs(je));
                }
                else
                {
                    Call(dmtype, callstring);
                }
                VFD8C_LED8C_CloseCom();
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        #region Icall 成员


        public void SetPicture(string picturename)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
