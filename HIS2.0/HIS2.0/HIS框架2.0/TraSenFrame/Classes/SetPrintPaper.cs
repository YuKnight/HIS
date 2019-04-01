using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using TrasenFrame.Classes;

namespace TrasenFrame.Classes 
{
   public  class SetPrintPaper //: System.Windows.Forms.Form
    {
        #region 引用API函数
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct structPrinterDefaults
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public String pDatatype;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.I4)]
            public int DesiredAccess;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinter", SetLastError = true,
          CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall),
        SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPTStr)] 
         string printerName,
         out IntPtr phPrinter,
         ref structPrinterDefaults pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true,
          CharSet = CharSet.Unicode, ExactSpelling = false,
          CallingConvention = CallingConvention.StdCall), SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool ClosePrinter(IntPtr phPrinter);

        [DllImport("winspool.Drv", EntryPoint = "SetPrinterA", SetLastError = true,
          CharSet = CharSet.Auto, ExactSpelling = true,
          CallingConvention = CallingConvention.StdCall), SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool SetPrinter(
         IntPtr hPrinter,
         [MarshalAs(UnmanagedType.I4)] int level,
         IntPtr pPrinter,
         [MarshalAs(UnmanagedType.I4)] int command);

        [DllImport("winspool.Drv", EntryPoint = "DocumentPropertiesA", SetLastError = true,
          ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern int DocumentProperties(
         IntPtr hwnd,
         IntPtr hPrinter,
         [MarshalAs(UnmanagedType.LPStr)] string pDeviceName,
         IntPtr pDevModeOutput,
         IntPtr pDevModeInput,
         int fMode
         );

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct structSize
        {
            public Int32 width;
            public Int32 height;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct structRect
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct structDevMode
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public String
             dmDeviceName;
            [MarshalAs(UnmanagedType.U2)]
            public short dmSpecVersion;
            [MarshalAs(UnmanagedType.U2)]
            public short dmDriverVersion;
            [MarshalAs(UnmanagedType.U2)]
            public short dmSize;
            [MarshalAs(UnmanagedType.U2)]
            public short dmDriverExtra;
            [MarshalAs(UnmanagedType.U4)]
            public int dmFields;
            [MarshalAs(UnmanagedType.I2)]
            public short dmOrientation;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPaperSize;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPaperLength;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPaperWidth;
            [MarshalAs(UnmanagedType.I2)]
            public short dmScale;
            [MarshalAs(UnmanagedType.I2)]
            public short dmCopies;
            [MarshalAs(UnmanagedType.I2)]
            public short dmDefaultSource;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPrintQuality;
            [MarshalAs(UnmanagedType.I2)]
            public short dmColor;
            [MarshalAs(UnmanagedType.I2)]
            public short dmDuplex;
            [MarshalAs(UnmanagedType.I2)]
            public short dmYResolution;
            [MarshalAs(UnmanagedType.I2)]
            public short dmTTOption;
            [MarshalAs(UnmanagedType.I2)]
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public String dmFormName;
            [MarshalAs(UnmanagedType.U2)]
            public short dmLogPixels;
            [MarshalAs(UnmanagedType.U4)]
            public int dmBitsPerPel;
            [MarshalAs(UnmanagedType.U4)]
            public int dmPelsWidth;
            [MarshalAs(UnmanagedType.U4)]
            public int dmPelsHeight;
            [MarshalAs(UnmanagedType.U4)]
            public int dmNup;
            [MarshalAs(UnmanagedType.U4)]
            public int dmDisplayFrequency;
            [MarshalAs(UnmanagedType.U4)]
            public int dmICMMethod;
            [MarshalAs(UnmanagedType.U4)]
            public int dmICMIntent;
            [MarshalAs(UnmanagedType.U4)]
            public int dmMediaType;
            [MarshalAs(UnmanagedType.U4)]
            public int dmDitherType;
            [MarshalAs(UnmanagedType.U4)]
            public int dmReserved1;
            [MarshalAs(UnmanagedType.U4)]
            public int dmReserved2;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct PRINTER_INFO_9
        {
            public IntPtr pDevMode;
        }


        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        internal struct FormInfo1
        {
            [FieldOffset(0), MarshalAs(UnmanagedType.I4)]
            public uint Flags;
            [FieldOffset(4), MarshalAs(UnmanagedType.LPWStr)]
            public String pName;
            [FieldOffset(8)]
            public structSize Size;
            [FieldOffset(16)]
            public structRect ImageableArea;
        }

        [DllImport("winspool.Drv", EntryPoint = "AddFormW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall), SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool AddForm(IntPtr phPrinter, [MarshalAs(UnmanagedType.I4)] int level, ref FormInfo1 form);

        [DllImport("kernel32.dll", EntryPoint = "GetLastError", SetLastError = false,
          ExactSpelling = true, CallingConvention = CallingConvention.StdCall),
        SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern Int32 GetLastError();

        [DllImport("winspool.Drv", EntryPoint = "GetPrinterA", SetLastError = true,
          ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool GetPrinter(
         IntPtr hPrinter,
         int dwLevel,
         IntPtr pPrinter,
         int dwBuf,
         out int dwNeeded
         );

        [Flags]
        internal enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }
        const int WM_SETTINGCHANGE = 0x001A;
        const int HWND_BROADCAST = 0xffff;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessageTimeout(
         IntPtr windowHandle,
         uint Msg,
         IntPtr wParam,
         IntPtr lParam,
         SendMessageTimeoutFlags flags,
         uint timeout,
         out IntPtr result
         );

        #endregion


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
        
        public SetPrintPaper(string ReportName)
        {

            #region 设置自定义纸张格式,如果没有则添加,如果有则设为首选纸张
            //Add By Tany 2007-10-24
            //****************************************************************************************
            string _reportName = ReportName;
            int _idx = 0;
            //从_reportFilePath取出报表文件名
            //while (_reportName.IndexOf(@"\") >= 0)
            //{
            //    _idx = _reportName.IndexOf(@"\");
            //    _reportName = _reportName.Substring(_idx + 1);
            //}
            //_reportName = _reportName.Substring(0, _reportName.Length - 4);

            //查找数据库中设置的纸张格式
            string sql = "select * from jc_reportpaper where reportname='" + _reportName + "'";
            DataTable paperTb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sql);
            //如果设置了纸张才进行下面的操作
            if (paperTb.Rows.Count > 0)
            {
                PrintDocument prtdoc = new PrintDocument();
                string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;//获取默认打印机

                Microsoft.Win32.RegistryKey rk;
                if (!strDefaultPrinter.StartsWith(@"\\"))//本地打印机
                {
                    rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Printers\\" + strDefaultPrinter + "\\DsDriver");
                }
                else                                //网络打印机
                {

                    string[] p = strDefaultPrinter.Remove(0, 2).Split(new char[] { '\\' });
                    string path = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Providers\\LanMan Print Services\\Servers\\" + p[0] + "\\Printers\\" + p[1] + "\\DsDriver";
                    rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(path);
                }
                //获取默认打印机支持的纸张
                string[] papers = (string[])(rk.GetValue("printMediaSupported"));
                int iPaper = 0;
                bool Exist = false;
                string PaperName = paperTb.Rows[0]["PAPERNAME"].ToString();

                //查找这个纸张是否存在
                for (int i = 0; i < papers.Length; i++)
                {
                    if (papers[i].ToString().ToUpper() == PaperName.ToUpper())
                    {
                        iPaper = i;
                        Exist = true;
                        break;
                    }
                }

                const int PRINTER_ACCESS_USE = 0x00000008;
                const int PRINTER_ACCESS_ADMINISTER = 0x00000004;
                const int FORM_PRINTER = 0x00000002;

                structPrinterDefaults defaults = new structPrinterDefaults();
                defaults.pDatatype = null;
                defaults.pDevMode = IntPtr.Zero;
                defaults.DesiredAccess = PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE;

                IntPtr hPrinter = IntPtr.Zero;

                //如果没有这个纸张则添加
                if (!Exist)
                {
                    //打开打印机 
                    if (OpenPrinter(strDefaultPrinter, out hPrinter, ref defaults))
                    {
                        try
                        {
                            float WidthInMm = Convert.ToSingle(paperTb.Rows[0]["PAPERWIDTH"]);
                            float HeightInMm = Convert.ToSingle(paperTb.Rows[0]["PAPERHEIGHT"]);

                            //创建并初始化FORM_INFO_1 
                            FormInfo1 formInfo = new FormInfo1();
                            formInfo.Flags = 0;
                            formInfo.pName = PaperName;
                            formInfo.Size.width = (int)(WidthInMm * 1000.0);
                            formInfo.Size.height = (int)(HeightInMm * 1000.0);
                            formInfo.ImageableArea.left = 0;
                            formInfo.ImageableArea.right = formInfo.Size.width;
                            formInfo.ImageableArea.top = 0;
                            formInfo.ImageableArea.bottom = formInfo.Size.height;
                            //AddForm(hPrinter, 1, ref formInfo);
                            if (!AddForm(hPrinter, 1, ref formInfo))
                            {
                                StringBuilder strBuilder = new StringBuilder();
                                strBuilder.AppendFormat("向打印机 {1} 添加自定义纸张 {0} 失败！错误代号：{2}",
                                 PaperName, strDefaultPrinter, GetLastError());
                                throw new ApplicationException(strBuilder.ToString());
                            }
                            else
                            {
                                MessageBox.Show("自定义纸张已经设置成功，请重新打印！\n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //return false;
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        finally
                        {
                            ClosePrinter(hPrinter);
                        }
                    }
                }
                else//有纸张则设置为首选纸张
                {
                    //打开打印机 
                    if (OpenPrinter(strDefaultPrinter, out hPrinter, ref defaults))
                    {
                        try
                        {
                            //初始化 
                            const int DM_OUT_BUFFER = 2;
                            const int DM_IN_BUFFER = 8;
                            structDevMode devMode = new structDevMode();
                            IntPtr hPrinterInfo, hDummy;
                            PRINTER_INFO_9 printerInfo;
                            printerInfo.pDevMode = IntPtr.Zero;
                            int iPrinterInfoSize, iDummyInt;


                            int iDevModeSize = DocumentProperties(IntPtr.Zero, hPrinter, strDefaultPrinter, IntPtr.Zero, IntPtr.Zero, 0);

                            if (iDevModeSize < 0)
                                throw new ApplicationException("无法取得DEVMODE结构的大小！");

                            //分配缓冲 
                            IntPtr hDevMode = Marshal.AllocCoTaskMem(iDevModeSize + 100);

                            //获取DEV_MODE指针 
                            int iRet = DocumentProperties(IntPtr.Zero, hPrinter, strDefaultPrinter, hDevMode, IntPtr.Zero, DM_OUT_BUFFER);

                            if (iRet < 0)
                                throw new ApplicationException("无法获得DEVMODE结构！");

                            //填充DEV_MODE 
                            devMode = (structDevMode)Marshal.PtrToStructure(hDevMode, devMode.GetType());


                            devMode.dmFields = 0x10000;

                            //FORM名称 
                            devMode.dmFormName = PaperName;

                            Marshal.StructureToPtr(devMode, hDevMode, true);

                            iRet = DocumentProperties(IntPtr.Zero, hPrinter, strDefaultPrinter,
                             printerInfo.pDevMode, printerInfo.pDevMode, DM_IN_BUFFER | DM_OUT_BUFFER);

                            if (iRet < 0)
                                throw new ApplicationException("无法为打印机设定打印方向！");

                            GetPrinter(hPrinter, 9, IntPtr.Zero, 0, out iPrinterInfoSize);
                            if (iPrinterInfoSize == 0)
                                throw new ApplicationException("调用GetPrinter方法失败！");

                            hPrinterInfo = Marshal.AllocCoTaskMem(iPrinterInfoSize + 100);

                            bool bSuccess = GetPrinter(hPrinter, 9, hPrinterInfo, iPrinterInfoSize, out iDummyInt);

                            if (!bSuccess)
                                throw new ApplicationException("调用GetPrinter方法失败！");

                            printerInfo = (PRINTER_INFO_9)Marshal.PtrToStructure(hPrinterInfo, printerInfo.GetType());
                            printerInfo.pDevMode = hDevMode;

                            Marshal.StructureToPtr(printerInfo, hPrinterInfo, true);

                            bSuccess = SetPrinter(hPrinter, 9, hPrinterInfo, 0);

                            if (!bSuccess)
                                throw new Win32Exception(Marshal.GetLastWin32Error(), "调用SetPrinter方法失败，无法进行打印机设置！");

                            //SendMessageTimeout(
                            // new IntPtr(HWND_BROADCAST),
                            // WM_SETTINGCHANGE,
                            // IntPtr.Zero,
                            // IntPtr.Zero,
                            //SendMessageTimeoutFlags.SMTO_NORMAL,
                            // 1000,
                            // out hDummy);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        finally
                        {
                            ClosePrinter(hPrinter);
                        }
                    }
                }

                //PrintDocument doc = new PrintDocument();
                //int[] sizes = PaperSizeGetter.Get_PaperSizes(strDefaultPrinter);
                //int paperSizeid = sizes[iPaper];
                //string ss = doc.DefaultPageSettings.PaperSize.PaperName; doc.DefaultPageSettings.PaperSize.
                //rptDoc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)(paperSizeid);
                //int[] sizes = PaperSizeGetter.Get_PaperSizes(strDefaultPrinter);
                //int paperSizeid = sizes[iPaper];

                //ReportDocument rptDoc = new ReportDocument();
                //rptDoc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)(paperSizeid);
                
                //doc.DefaultPageSettings.PaperSize =rptDoc.PrintOptions.PaperSize; 

                //PrintDocument doc = new PrintDocument();
                
                    
            }
            //****************************************************************************************
            #endregion
        }

      
    }
}
