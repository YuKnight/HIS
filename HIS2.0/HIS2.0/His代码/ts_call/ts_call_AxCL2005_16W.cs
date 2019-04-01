using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.GeneralClasses;
using System.Runtime.InteropServices;
using TrasenFrame.Classes;
using System.Threading;
using AxCL2005OCXLib;
using SpeechLib;

namespace ts_call
{
    public class ts_call_AxCL2005_16W : Icall
    {
        public static int A = 0;
        public static readonly string debugFlag = ApiFunction.GetIniString("报价器文件路径", "dll路径", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string com = ApiFunction.GetIniString("报价器文件路径", "通讯端口", Constant.ApplicationDirectory + "//ClientWindow.ini");
        //[DllImport("DisFun.dll", EntryPoint = "DisFun")]
        //private static extern int DisFun(string hPort, string lpName, double dbMoney);

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
                if (Convertor.IsNumeric(ncom) == false)  ncom = "1";

                if (dmtype == DmType.姓名)
                {
                    Display("姓名:"+callstring, 0);
                }
                if (dmtype == DmType.应收)
                {

                    Display("应收:" + callstring, Convert.ToDouble(callstring));

                }
                if (dmtype == DmType.实收)
                {
                    Display("实收:" + callstring, Convert.ToDouble(callstring));

                }
                if (dmtype == DmType.找零)
                {
                    Display("找零:" + callstring, Convert.ToDouble(callstring));

                }
                if (dmtype == DmType.欢迎)
                {
                    if (callstring == "抱歉,暂停工作")
                        Display("本窗口暂停工作", 0);
                    else
                        Display("祝您早日康复", 0);

                }
                if (dmtype == DmType.清除)
                    Display("祝您早日康复", 0);
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

                Display("实收:" + ss, Convert.ToDouble(ss));

                System.Threading.Thread.Sleep(1 * 2000);

                Display("找零:" + ss, Convert.ToDouble(ss));
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

                if (dmtype == DmType.姓名)
                {
                    Display(callstring, je);
                }
                else if (dmtype == DmType.找零)
                {
                    Display(callstring, Math.Abs(je));
                }
                else if (dmtype == DmType.实收)
                {
                    string ss = "";
                    if (je >= 0)
                    {
                        ss = "实收";
                    }
                    else
                    {
                        ss = "退款";
                    }
                    Display( ss, Math.Abs(je));
                }
                else
                {
                    Call(dmtype, callstring);
                }
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX)
        {
            string patientName = "发 药 窗 口 ";
            patientName = patientName + callstring + " " + je.ToString();

            string ssql = "select '' ";

            if (dmtype == DmType.发药呼叫)
            {
                try
                {
                    string ss = "请" + CFMX[0].brxm + "到" + CFMX[0].fyck + "来取药";
                    SpVoiceClass class2 = new SpVoiceClass();
                    ISpeechObjectTokens voices = class2.GetVoices("Language = 804", "Gender = Female");
                    if (voices.Count > 0)
                    {
                        class2.Voice = voices.Item(0);
                        class2.Speak(ss, SpeechVoiceSpeakFlags.SVSFDefault);
                    }
                }
                catch (Exception exception)
                {
                }
            }

            if (dmtype == DmType.发药)
            {
                try
                {
                    Display(patientName, Math.Abs(je));
                }
                catch (Exception exception)
                {
                }
            }
        }

        private unsafe bool Display(string strName, double Je)
        {
            try
            {
                string ncom = com;
                if (Convertor.IsNumeric(ncom) == false) ncom = "1";
                short port = Convert.ToInt16(ncom);

                if (strName == "") return true;
                AxCL2005OCXLib.AxCL2005Ocx AxCL2005 = new AxCL2005OCXLib.AxCL2005Ocx();
                bool flag2 = AxCL2005.ComInitial(port, 38400, 1000);
                if (flag2)
                {
                    byte[] buffer3 = new UnicodeEncoding().GetBytes(strName);
                    byte[] buffer4 = Encoding.Convert(Encoding.Unicode, Encoding.Default, buffer3);
                    int num2 = 0;
                    fixed (byte* numRef2 = buffer4)
                    {
                        num2 = (int)numRef2;
                    }
                    flag2 = AxCL2005.SetLEDProperty(1, 0, 0x80, 0x20, 0, 1);
                    if (flag2)
                    {
                        flag2 = AxCL2005.ClearBank(0);
                    }
                    if (flag2)
                    {
                        flag2 = AxCL2005.ClearBank(1);
                    }
                    if (flag2)
                    {
                        flag2 = AxCL2005.SwitchToBank(0);
                    }
                    if (flag2)
                    {
                        short x = 0;
                        short y = 0;
                        flag2 = AxCL2005.ShowString(1, x, y, 1, num2);
                    }
                    if (flag2)
                    {
                        flag2 = AxCL2005.SwitchToBank(1);
                    }
                    AxCL2005.CloseCL2005();
                }
                return flag2;
            }
            catch
            {
                return false;
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
