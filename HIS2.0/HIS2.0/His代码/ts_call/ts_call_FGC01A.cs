using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;
using System.Threading;
using TrasenFrame.Classes;

namespace ts_call
{
    public class ts_call_FGC01A : Icall
    {
        [DllImport("Fgc01.dll")]
        private static extern int SetComNo(int No);

        [DllImport("Fgc01.dll", EntryPoint = "SetHandleType")]
        private static extern IntPtr SetHandleType(int HandleType);

        [DllImport("Fgc01.dll", EntryPoint = "LocStringDisplay")]
        private static extern IntPtr LocStringDisplay(int X, int Y, string str);

        [DllImport("Fgc01.dll", EntryPoint = "AllClear")]
        private static extern IntPtr AllClear();

        [DllImport("Fgc01.dll", EntryPoint = "MagicClear")]
        private static extern IntPtr MagicClear(int mode);

        [DllImport("Fgc01.dll", EntryPoint = "SetFontSize")]
        private static extern IntPtr SetFontSize(int size);

        [DllImport("Fgc01.dll", EntryPoint = "PlayWaves")]
        private static extern int PlayWaves(string filename);

        [DllImport("Fgc01.dll", EntryPoint = "RMB2Wav")]
        private static extern bool RMB2Wav(double values);

        public static readonly string com = ApiFunction.GetIniString("报价器文件路径", "通讯端口", Constant.ApplicationDirectory + "//ClientWindow.ini");
        #region Icall 成员
        private Thread currentThread;
        public System.Threading.Thread CurrentThread
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
            int ncom = Convert.ToInt32(com);
            IntPtr intp;
            int result = -1;
            result = SetComNo(ncom);
            if (dmtype == DmType.清除)
                MagicClear(2);
            if (dmtype == DmType.姓名)
            {
                intp = SetFontSize(16);
                intp = LocStringDisplay(10, 10, "姓名:" + callstring);
            }
            if (dmtype == DmType.应收)
            {
                MagicClear(2);
                AllClear();
                intp = SetFontSize(10);
                intp = LocStringDisplay(10, 10, "应收:" + callstring);
                int r = PlayWaves("请您付款");
                bool bol = RMB2Wav(Convert.ToDouble(callstring));
            }
        }

        public void Call(string ss, string zl)
        {
          
            IntPtr intp;
            intp = SetFontSize(10);
            intp = LocStringDisplay(10, 30, "实收:" + ss);
            int r = PlayWaves("实收");
            bool bol = RMB2Wav(Convert.ToDouble(ss));

            intp = SetFontSize(10);
            intp = LocStringDisplay(10, 50, "找零:" + zl);
            r = PlayWaves("找零");
            bol = RMB2Wav(Convert.ToDouble(zl));
        }

        public void Call(DmType dmtype, string callstring, double je)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Call(DmType dmtype, string callstring, double je, CFMX[] CFMX)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 具体内容没实现 2013-8-8 by tck
        /// </summary>
        /// <param name="picturename"></param>
        public void SetPicture(string picturename)
        {
            //throw new Exception("The method or operation is not implemented.");
        }   
        #endregion
    }
}
