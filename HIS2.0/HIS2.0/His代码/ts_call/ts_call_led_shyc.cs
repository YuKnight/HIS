using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.GeneralClasses;
using System.Runtime.InteropServices;
using TrasenFrame.Classes;
using System.Threading;

namespace ts_call
{
    public class ts_call_led_shyc : Icall
    {
        public static int A = 0;
        public static readonly string debugFlag = ApiFunction.GetIniString("报价器文件路径", "dll路径", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string com = ApiFunction.GetIniString("报价器文件路径", "通讯端口", Constant.ApplicationDirectory + "//ClientWindow.ini");
        [DllImport("ckynth.dll", EntryPoint = "dsbdll")]
        private static extern int dsbdll(int  hPort, string ss);

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
                int ncom = Convert.ToInt32(com);

                if (dmtype == DmType.姓名)
                {
                    dsbdll(ncom, "$1");
                    dsbdll(ncom, "#姓名:" + callstring+"#");
                }
                if (dmtype == DmType.应收)
                {
                    dsbdll(ncom, "$2");
                    dsbdll(ncom, "" + callstring + "J");


                }
                if (dmtype == DmType.实收)
                {
                    dsbdll(ncom, "$2");
                    dsbdll(ncom, "" + callstring + "Y");


                }
                if (dmtype == DmType.找零)
                {
                    dsbdll(ncom, "$2");
                    dsbdll(ncom, "" + callstring + "Z");

                }
                if (dmtype == DmType.欢迎)
                {
                    if (callstring == "抱歉,暂停工作")
                        dsbdll(ncom, "W");
                    else
                        dsbdll(ncom, "F");

                }
                if (dmtype == DmType.清除)
                    dsbdll(ncom, "F");
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
                int ncom = Convert.ToInt32(com);

                dsbdll(ncom, "$1");
                dsbdll(ncom, "" + ss.ToString() + "Y");

                //System.Threading.Thread.Sleep(1 * 2000);

                dsbdll(ncom, "$2");
                dsbdll(ncom, "" + zl.ToString() + "Z");
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
                int ncom = Convert.ToInt32(com);

                if (dmtype == DmType.姓名)
                {
                    dsbdll(ncom, "$1");
                    dsbdll(ncom, "#姓名:" + callstring + "#");
                }
                else if (dmtype == DmType.找零)
                {

                    if (callstring=="退款")
                    {
                        dsbdll(ncom, "$2");
                        //dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "G");
                        dsbdll(ncom, "#退您: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }
                    if (callstring == "补收")
                    {
                        dsbdll(ncom, "$2");
                       // dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "J");
                        dsbdll(ncom, "#请您补交: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }
                    if (callstring == "暂存")
                    {
                        dsbdll(ncom, "$2");
                        //dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "H");
                        dsbdll(ncom, "#暂存: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }
                    if (callstring == "欠费")
                    {
                        dsbdll(ncom, "$2");
                       // dsbdll(ncom, "-" + Convert.ToString(Math.Abs(je)) + "H");
                        dsbdll(ncom, "#您欠费: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }

                }
                else if (dmtype == DmType.实收)
                {
                    string ss = "";
                    if (je >= 0)
                    {
                        dsbdll(ncom, "$2");
                        dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "J");
                    }
                    else
                    {
                        dsbdll(ncom, "$2");
                        dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "G");
                    }

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
            try
            {
                int ncom = Convert.ToInt32(com);

                if (dmtype == DmType.姓名)
                {
                    dsbdll(ncom, "$1");
                    dsbdll(ncom, "#姓名:" + callstring + "#");
                }
                else if (dmtype == DmType.找零)
                {

                    if (callstring == "退款")
                    {
                        dsbdll(ncom, "$2");
                        //dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "G");
                        dsbdll(ncom, "#退您: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }
                    if (callstring == "补收")
                    {
                        dsbdll(ncom, "$2");
                        // dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "J");
                        dsbdll(ncom, "#请您补交: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }
                    if (callstring == "暂存")
                    {
                        dsbdll(ncom, "$2");
                        //dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "H");
                        dsbdll(ncom, "#暂存: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }
                    if (callstring == "欠费")
                    {
                        dsbdll(ncom, "$2");
                        // dsbdll(ncom, "-" + Convert.ToString(Math.Abs(je)) + "H");
                        dsbdll(ncom, "#您欠费: " + Convert.ToDecimal(Math.Abs(je)).ToString("0.00") + " 元#");
                    }

                }
                else if (dmtype == DmType.实收)
                {
                    string ss = "";
                    if (je >= 0)
                    {
                        dsbdll(ncom, "$2");
                        dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "J");
                    }
                    else
                    {
                        dsbdll(ncom, "$2");
                        dsbdll(ncom, "" + Convert.ToString(Math.Abs(je)) + "G");
                    }

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

        #region Icall 成员


        public void SetPicture(string picturename)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
