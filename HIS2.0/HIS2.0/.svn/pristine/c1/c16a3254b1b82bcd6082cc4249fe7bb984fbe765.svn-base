using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ts_PrintProcess
{
    public class PaperSizeGetter
    {
        public static string OutputPort = String.Empty;

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DeviceCapabilities(string pDevice, string pPort, short fwCapabilities, IntPtr pOutput, IntPtr pDevMode);

        public static int[] Get_PaperSizes(string printer)
        {
            string text1 = printer;
            int num1 = FastDeviceCapabilities(0x10, IntPtr.Zero, -1, text1);
            if (num1 == -1)
            {
                return new int[0];
            }
            int num2 = Marshal.SystemDefaultCharSize * 0x40;
            IntPtr ptr1 = Marshal.AllocCoTaskMem(num2 * num1);
            FastDeviceCapabilities(0x10, ptr1, -1, text1);
            IntPtr ptr2 = Marshal.AllocCoTaskMem(2 * num1);
            FastDeviceCapabilities(2, ptr2, -1, text1);
            IntPtr ptr3 = Marshal.AllocCoTaskMem(8 * num1);
            FastDeviceCapabilities(3, ptr3, -1, text1);
            int[] sizeArray1 = new int[num1];
            for (int num3 = 0; num3 < num1; num3++)
            {
                string text2 = Marshal.PtrToStringAuto((IntPtr)(((long)ptr1) + (num2 * num3)), 0x40);
                int num4 = text2.IndexOf('\0');
                if (num4 > -1)
                {
                    text2 = text2.Substring(0, num4);
                }
                short num5 = Marshal.ReadInt16((IntPtr)(((long)ptr2) + (num3 * 2)));
                int num6 = Marshal.ReadInt32((IntPtr)(((long)ptr3) + (num3 * 8)));
                int num7 = Marshal.ReadInt32((IntPtr)((((long)ptr3) + (num3 * 8)) + 4));
                sizeArray1[num3] = System.Convert.ToInt32(num5);
            }
            Marshal.FreeCoTaskMem(ptr1);
            Marshal.FreeCoTaskMem(ptr2);
            Marshal.FreeCoTaskMem(ptr3);
            return sizeArray1;
        }

        private static int FastDeviceCapabilities(short capability, IntPtr pointerToBuffer, int defaultValue, string printerName)
        {
            int num1 = DeviceCapabilities(printerName, OutputPort, capability, pointerToBuffer, IntPtr.Zero);
            if (num1 == -1)
            {
                return defaultValue;
            }
            return num1;
        }
    }
}
