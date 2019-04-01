using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Ts_zyys_public
{
    public class PulicStatiFuntion
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process,
            int minSize,
            int maxSize
        );
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
            //GCCollect();
        }
        /// <summary>
        /// GC回收资源
        /// </summary>
        public static void GCCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
