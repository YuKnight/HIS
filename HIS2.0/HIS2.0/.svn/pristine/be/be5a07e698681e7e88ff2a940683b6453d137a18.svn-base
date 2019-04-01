using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.GeneralClasses;
using System.Runtime.InteropServices;
using TrasenFrame.Classes;
using System.Threading;
namespace ts_call
{
    public class ts_call : Icall
    {
        public static int A = 0;
        public static readonly string debugFlag = ApiFunction.GetIniString("报价器文件路径", "dll路径", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public static readonly string com = ApiFunction.GetIniString("报价器文件路径", "通讯端口", Constant.ApplicationDirectory + "//ClientWindow.ini");
        [DllImport("pxdc1.dll", EntryPoint = "dsbcall")]
        private static extern void dsbcall(int lcom, string lcStr);

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
        //SHL-1语音收费报价器
        //浦鑫科技有限公司
        /// <summary>
        /// 显示屏显示
        /// </summary>
        /// <param name="dmtype"></param>
        /// <param name="callstring"></param>
        public void Call(DmType dmtype, string callstring)
        {
            if (Convertor.IsNumeric(com) == false)
                throw new Exception("通讯端口必须设为数字");
            int ncom = Convert.ToInt32(Convertor.IsNull(com, "0"));

            aa a = new aa(dmtype, callstring);

            if (dmtype == DmType.应收 || dmtype == DmType.实收)
            {
                Thread t = new Thread(new ThreadStart(a.call));


                t.Start();
            }
            else
            {
                a.call();
            }

        }

        public void Call(string ss, string zl)
        {
            if (Convertor.IsNumeric(com) == false)
                throw new Exception("通讯端口必须设为数字");
            int ncom = Convert.ToInt32(Convertor.IsNull(com, "0"));

            bb b = new bb(ss, zl);
            Thread t = new Thread(new ThreadStart(b.call));
            t.Start();

        }

        /// <summary>
        /// 报价显示（浦鑫这个方法同Call(DmType dmtype, string callstring)）
        /// </summary>
        /// <param name="dmtype">枚举类型</param>
        /// <param name="callstring">显示字符串</param>
        /// <param name="je">金额（浦鑫暂不处理）</param>
        public void Call(DmType dmtype, string callstring, double je)//Add by Tany 2010-07-25
        {
            if (dmtype == DmType.找零)
            {
                Call(dmtype, je.ToString("0.00"));
            }
            else
            {
                Call(dmtype, callstring);
            }
        }

        public void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX)
        {
            if (dmtype == DmType.找零)
            {
                Call(dmtype, je.ToString("0.00"));
            }
            else
            {
                Call(dmtype, callstring);
            }
        }
        public class bb
        {
            //要用到的属性，也就是我们要传递的参数
            private string callstring1;
            private string callstring2;

            //包含参数的构造函数
            public bb(string _callstring1, string _callstring2)
            {
                callstring1 = _callstring1;
                callstring2 = _callstring2;
            }

            public void call()
            {
                if (Convertor.IsNumeric(com) == false)
                    throw new Exception("通讯端口必须设为数字");
                int ncom = Convert.ToInt32(Convertor.IsNull(com, "0"));

                dsbcall(ncom, "Y31" + callstring1.Trim() + "$");

                dsbcall(ncom, "Z41" + callstring2.Trim() + "$");

            }


        }

        public class aa
        {
            //要用到的属性，也就是我们要传递的参数
            private DmType dmtype1;
            private string callstring1;

            //包含参数的构造函数
            public aa(DmType dmtype, string callstring)
            {
                dmtype1 = dmtype;
                callstring1 = callstring;
            }

            public void call()
            {
                if (Convertor.IsNumeric(com) == false)
                    throw new Exception("通讯端口必须设为数字");
                int ncom = Convert.ToInt32(Convertor.IsNull(com, "0"));

                if (dmtype1 == DmType.姓名)
                {
                    dsbcall(ncom, "S11C$");
                    dsbcall(1, "C11姓名:" + callstring1 + "$");
                }
                if (dmtype1 == DmType.应收)
                {

                    dsbcall(ncom, "J21" + callstring1.Trim() + "$");

                }
                if (dmtype1 == DmType.实收)
                {
                    dsbcall(ncom, "Y31" + callstring1.Trim() + "$");

                }
                if (dmtype1 == DmType.找零)
                {
                    dsbcall(ncom, "Z41" + callstring1.Trim() + "$");

                }
                if (dmtype1 == DmType.欢迎)
                {
                    dsbcall(ncom, "S11C$");
                    dsbcall(1, "C21" + callstring1 + "$");
                }
                if (dmtype1 == DmType.清除)
                    dsbcall(ncom, "S11C$");
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
