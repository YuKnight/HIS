using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.GeneralClasses;
using System.Runtime.InteropServices;
using TrasenFrame.Classes;
using System.Threading;

namespace ts_call
{
    public class ts_call_led : Icall
    {
        public static int A = 0;
        public static readonly string debugFlag = ApiFunction.GetIniString("报价器文件路径", "dll路径", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string com = ApiFunction.GetIniString("报价器文件路径", "通讯端口", Constant.ApplicationDirectory + "//ClientWindow.ini");
        [DllImport("DisFun.dll", EntryPoint = "DisFun")]
        private static extern int DisFun(string hPort, string lpName, double dbMoney);

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

                if (dmtype == DmType.姓名)
                {
                    DisFun(ncom, "" + callstring, 0);
                }
                if (dmtype == DmType.应收)
                {

                    DisFun(ncom, "应收", Convert.ToDouble(callstring));

                }
                if (dmtype == DmType.实收)
                {
                    DisFun(ncom, "实收", Convert.ToDouble(callstring));

                }
                if (dmtype == DmType.找零)
                {
                    DisFun(ncom, "找零", Convert.ToDouble(callstring));

                }
                if (dmtype == DmType.欢迎)
                {
                    if (callstring == "抱歉,暂停工作")
                        DisFun(ncom, "暂停工作", 0);
                    else
                        DisFun(ncom, "您好", 0);

                }
                if (dmtype == DmType.清除)
                    DisFun(ncom, "您好", 0);
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

                DisFun(ncom, "实收", Convert.ToDouble(ss));

                System.Threading.Thread.Sleep(1 * 2000);

                DisFun(ncom, "找零", Convert.ToDouble(zl));
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
                    DisFun(ncom, "" + callstring, je);
                }
                else if (dmtype == DmType.找零)
                {
                    DisFun(ncom, "" + callstring, Math.Abs(je));
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
                    DisFun(ncom, ss, Math.Abs(je));
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
                string ncom = com;

                if (dmtype == DmType.姓名)
                {
                    DisFun(ncom, "" + callstring, je);
                }
                else if (dmtype == DmType.找零)
                {
                    DisFun(ncom, "" + callstring, Math.Abs(je));
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
                    DisFun(ncom, ss, Math.Abs(je));
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
