using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security;
using TrasenClasses.GeneralClasses;
using CrystalDecisions.CrystalReports.Engine;
 
using System.IO;
using System.Drawing.Printing;

namespace ts_PrintProcess
{
    public partial class UcReportView : UserControl
    {    

        //2013-8-16 增加导出pdf等文件的方法
        //2013-3-6 增加事件  this.AddEvent_AfterSetReportSource(); 增加panelLeft,panelRight
        //2012-3-4  对外公公布水晶报表的一些方法与事件
        //2013-1-18 增加 将对象销毁，不要在temp文件中产生垃圾 jianqg
        //2012-2-22 显示或隐藏ToolbarStatusBar 2012-2-22 增加  jianqg

        //CrystalDecisions.Shared.ReportPageRequestContext rprc  = new CrystalDecisions.Shared.ReportPageRequestContext();
        //ReportDocument rptDoc;
        //rptDoc.FormatEngine.GetLastPageNumber(rprc);  总页数 


        ///// <summary>
        ///// CrystalReportViewer
        ///// </summary>
        //public CrystalDecisions.Windows.Forms.CrystalReportViewer CryRepViw;
        /// <summary>
        /// 报表是否加载成功
        /// </summary>
        private bool LoadReportSuccess;
        /// <summary>
        /// 该字符串用于点击打印后执行
        /// </summary>
        /// <remarks>Add By Tany 2010-09-25 增加一个SQLSTR用于点击打印后执行该语句</remarks>
        private string[] _sqlStr;
        /// <summary>
        /// 是否在点击打印后成功执行该字符串
        /// </summary>
        private bool _isExecSuccess = false;

        public TrasenClasses.DatabaseAccess.RelationalDatabase db = PrescriptionPrint.DB;

        public event EventHandler IsExecSuccessChanged;
        #region 2013-3-4 公共委托事件
        public event MouseEventHandler CryRepViw__MouseClick;
        public event MouseEventHandler CryRepViw__MouseMove;
        public event MouseEventHandler CryRepViw__MouseUp;
        public event MouseEventHandler CryRepViw__MouseDown;
        public event MouseEventHandler CryRepViw__MouseWheel;
        public event MouseEventHandler CryRepViw__MouseDoubleClick;


        public event EventHandler CryRepViw__MouseLeave;
        public event KeyEventHandler CryRepViw__KeyDown;
        public event KeyPressEventHandler CryRepViw__KeyPress;
        public event KeyEventHandler CryRepViw__KeyUp;
        public event EventHandler CryRepViw__Click;
        public event EventHandler CryRepViw__DoubleClick;
        #endregion


       

        private object _reportDataSource;
        private string _reportFilePath;
        private ParameterEx[] _parameters;
        private bool _toPrinter;
        private bool _localLogin;		//是否本机登录
        private string _printName;		//打印机设置
        private bool _isPrinted;		//是否点击过打印按钮
        private string PaperName;

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

        public UcReportView()
        {
            InitializeComponent();
            //CrystalDecisions.Windows.Forms.PageView pageView = CryRepViw.Controls[0] as CrystalDecisions.Windows.Forms.PageView;
            //AddEvent(pageView);

        }


        #region 属性 IsPrinted，ShowPrintButton
        /// <summary>
        /// 判断用户是否点击了打印按钮
        /// </summary>
        public bool IsPrinted
        {
            get
            {
                return _isPrinted;
            }
        }


        public bool ShowPrintButton
        {
            get
            {
                return this.tbbtnPrint.Visible;
            }
            set
            {
                tbbtnPrint.Visible = value;
                tbMain.Visible = value;//2013-2-22 增加
            }
        }
        #endregion
        #region 原来窗口中的 public 变量 暂时改为属性，以防窗口需要使用 jianqg 2013-2-20
        public CrystalDecisions.Windows.Forms.CrystalReportViewer CryRepViw_Uc
        {
            get { return this.CryRepViw; }
        }
        public ToolBar tbMain_Uc
        {
            get { return this.tbMain; }

        }
        public bool LoadReportSuccess_Uc
        {
            get { return this.LoadReportSuccess; }
            set { this.LoadReportSuccess = value; }
        }
        public bool isExecSuccess_Uc
        {
            get { return this._isExecSuccess; }
            //set { this._isExecSuccess = value; }
        }
        public string[] sqlStr_Uc
        {
            get { return this._sqlStr; }
            set { this._sqlStr = value; }
        }


        #endregion


        #region 增加3个属性对应_reportDataSource，_reportFilePath，_parameters jianqg 2013-2-20
        public object reportDataSource_Uc
        {
            get { return this._reportDataSource; }
            set { this._reportDataSource = value; }
        }

        public string reportFilePath_Uc
        {
            get { return this._reportFilePath; }
            set { this._reportFilePath = value; }
        }
        public ParameterEx[] parameters_Uc
        {
            get { return this._parameters; }
            set { this._parameters = value; }
        }



        #endregion

        #region 原来的静态方法
        /// <summary>
        /// 取得用户自定义报表文件路径，如果不存在则从path拷贝只自定义路径下
        /// </summary>
        /// <param name="path">当前报表路径</param>
        /// <param name="localLogin">是否为本机登录</param>
        /// <returns></returns>
        public static string GetCustomReportPath(string path, bool localLogin)
        {
            //取得报表文件名
            string fileName = path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);
            string customReportDirectory = "";
            if (localLogin)	//如果是本机登录则报表文件路径默认为本机数据库Access所在路径
            {
                //从INI文件读取本机数据库路径
                string dataSource = Crypto.Instance().UnCryp(ApiFunction.GetIniString("LOCALSERVER", "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                customReportDirectory = dataSource.Substring(0, dataSource.LastIndexOf("\\")) + "\\Report";
            }
            else
                customReportDirectory = Constant.CustomDirectory + "\\Report";
            if (!Directory.Exists(customReportDirectory))			//如果该路径不存在则建立该目录
            {
                Directory.CreateDirectory(customReportDirectory);
            }
            if (!File.Exists(customReportDirectory + "\\" + fileName))	//如果配置文件不存在则从安装目录拷贝
            {
                File.Copy(path, customReportDirectory + "\\" + fileName, true);
            }
            return customReportDirectory + "\\" + fileName;
        }
        /// <summary>
        /// 直接打印
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="localLogin">是否本机登录</param>
        /// <param name="printName">打印机名称</param>
        /// <param name="actualReportFilePath">报表文件路径是否为实际路径</param>
        /// <returns>打印是否成功</returns>
        public static bool DirectPrint(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool localLogin, string printName, bool actualReportFilePath)
        {
            try
            {

                ReportDocument rptDoc = new ReportDocument();
                if (actualReportFilePath)
                {
                    rptDoc.Load(reportFilePath);
                }
                else
                {
                    rptDoc.Load(GetCustomReportPath(reportFilePath, localLogin));
                }
                if (reportDataSource != null)
                {
                    rptDoc.SetDataSource(reportDataSource);
                }
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        rptDoc.SetParameterValue(parameters[i].Text, parameters[i].Value);
                    }
                }
                if (printName != "")
                {
                    rptDoc.PrintOptions.PrinterName = printName;
                }
                rptDoc.PrintToPrinter(1, false, 0, 0);

                rptDoc.Dispose();
                return true;
            }
            catch (LoadSaveReportException err)
            {
                MessageBox.Show("报表文件路径设置错误！\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            catch (Exception err)
            {
                MessageBox.Show("1、检查数据源设置是否正确！\n2、检查报表与数据源绑定是否正确！\n3、检查参数设置是否正确！\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        #endregion

        #region 方法
        private bool LoadReport_000001()
        {
            //获取报表名称
            string _reportName = GetReportFileName();
            //从本地配置读取报表使用的纸张信息及在本地打印时指向的打印机
            ReportPaper reportPaper = ReportPaper.GetReportPapterConfigFromLocalXml(_reportName, false, this.db);

            PrinterManager printerManager = new PrinterManager();
            if (string.IsNullOrEmpty(this._printName))
            {
                //如果调用时没有传打印机名称
                if (string.IsNullOrEmpty(reportPaper.DefaultPrinterName))
                {
                    //既没有传打印机，也没有在本地配置该报表的打印机，则使用的默认打印机
                    this._printName = PrinterManager.CurrentDefaultPrinter;
                }
                else
                {
                    //使用该报表在本地配置中的打印机
                    this._printName = reportPaper.DefaultPrinterName;
                }
            }
            //根据得到的打印机名从xml中获取打印机对象
            Printer printer = printerManager.GetConfiguredPrinter(this._printName);
            if (printer == null)
            {
                //如果传入的打印机没有配置，使用默认值
                printer = new Printer();
                printer.Name = this._printName;
                printer.IsNetPrinter = false;
                printer.Type = PrinterType.针式打印机;
            }
            FrmMdiMain.WriteFrameLocalLog(new string[] { string.Format("报表：[{0}]输往打印机：{1}", _reportName, _printName) }, true);
            //网络打印设置问题：
            //1 共享的打印机不能使用 usb打印线，需要使用传统的打印机端口
            //2 共享的打印机 必须可以访问，使用\\ip\共享的打印机,连接，的安装方式，可能需要密码，以后也许也需要
            //3 需要设置纸张的打印机，不能 是网络打印的方式（本软件系统菜单\参数设置 中处理），因为该框架对网络打印机，不设置纸张
            if (printer.IsNetPrinter)
            {
                //jianqg 2012-10-16 增加参数控制，判断是否网络打印机需要设置 纸张，原来是 不设置return LoadReportWithoutSetting();//网络打印机
                SystemCfg cfg24 = new SystemCfg(24, db);//网络打印机是否设置纸张
                if (cfg24.Config == "1")
                    return LoadReportWithSetting();
                else
                    return LoadReportWithoutSetting();//网络打印机
            }
            else
            {
                if (printer.Type == PrinterType.激光打印机)
                {

                    return LoadReportWithoutSetting();
                }
                else
                {
                    return LoadReportWithSetting();
                }
            }

        }
        /// <summary>
        /// 加载报表文件
        /// </summary>
        /// <returns></returns>
        protected bool LoadReport()
        {
            PrinterManager printerManager = new PrinterManager();
            string objPrinter = "";//目标打印机
            //获取打印机
            if (string.IsNullOrEmpty(this._printName))
                objPrinter = PrinterManager.CurrentDefaultPrinter;//没有传打印机，则使用的默认打印机
            else
                objPrinter = this._printName;
            //判断类型
            Printer printer = printerManager.GetConfiguredPrinter(objPrinter);
            if (printer == null)
            {
                //如果传入的打印机没有配置，使用默认值
                printer = new Printer();
                printer.Name = objPrinter;
                printer.IsNetPrinter = false;
                printer.Type = PrinterType.针式打印机;
            }

            //如果没有传入打印机名
            if (string.IsNullOrEmpty(_printName))
            {
                string _reportName = GetReportFileName();
                //MessageBox.Show("test 2:" + _reportName + objPrinter.ToString());
                //查找数据库中设置的纸张格式
                string sql = "select printername,lx from jc_reportpaper where reportname='" + _reportName + "'";
                //MessageBox.Show("test 2:看数据库打印机设置" + sql);
                DataRow drPaper = PrescriptionPrint.DB.GetDataRow(sql);
                if (drPaper != null)
                {

                    object obj = drPaper["printername"];
                    //MessageBox.Show("test 2:看数据库打印机设置obj：" + obj.ToString());
                    if (obj != null && !Convert.IsDBNull(obj))
                    {
                        _printName = obj.ToString().Trim();//将打印机设置为报表设置的打印机
                        //MessageBox.Show("test 3:jc_reportpaper中打印机:" + _printName);
                    }
                    else
                    {
                        int lx = Convert.IsDBNull(drPaper["lx"]) ? 0 : Convert.ToInt32(drPaper["lx"]);
                        if (lx != 0)
                        {
                            if (lx == 1)
                            {
                                _printName = Constant.CInvoicePrinterName;
                            }
                            else if (lx == 2)
                            {
                                _printName = Constant.CReportPrinterName;
                            }
                        }
                        //MessageBox.Show("test 4:" + _printName + " jc_reportpaper 中lx:" + lx.ToString());
                    }
                }
            }
            //网络打印设置问题：
            //1 共享的打印机不能使用 usb打印线，需要使用传统的打印机端口
            //2 共享的打印机 必须可以访问，使用\\ip\共享的打印机,连接，的安装方式，可能需要密码，以后也许也需要
            //3 需要设置纸张的打印机，不能 是网络打印的方式（本软件系统菜单\参数设置 中处理），因为该框架对网络打印机，不设置纸张
            if (printer.IsNetPrinter)
            {
                //jianqg 2012-10-16 增加参数控制，判断是否网络打印机需要设置 纸张，原来是 不设置return LoadReportWithoutSetting();//网络打印机
                SystemCfg cfg24 = new SystemCfg(24, PrescriptionPrint.DB);//网络打印机是否设置纸张
                if (cfg24.Config == "1")
                    return LoadReportWithSetting();
                else
                    return LoadReportWithoutSetting();//网络打印机
            }
            else
            {
                if (printer.Type == PrinterType.激光打印机)
                {

                    return LoadReportWithoutSetting();
                }
                else
                {

                    return LoadReportWithSetting();
                }
            }

        }
        private bool LoadReportWithoutSetting()
        {
            return LoadReportWithoutSetting(false);
        }
        /// <summary>
        /// 不更改打印机设置的方式加载报表
        /// </summary>
        /// <returns></returns>
        private bool LoadReportWithoutSetting(bool isExportFile)
        {
            try
            {
                if (_reportFilePath != "")
                {
                    string strMsg = "";
                    ReportDocument rptDoc = new ReportDocument();
                    rptDoc.Load(GetCustomReportPath(_reportFilePath));
                    if (_reportDataSource != null)
                    {
                        rptDoc.SetDataSource(_reportDataSource);
                    }
                    if (_parameters != null)
                    {
                        for (int i = 0; i < _parameters.Length; i++)
                        {
                            try
                            {
                                rptDoc.SetParameterValue(_parameters[i].Text, _parameters[i].Value);
                            }
                            catch (Exception errParameter)
                            {
                                strMsg = "报表参数设置错误！ 参数：" + _parameters[i].Text + "\n" + errParameter.Message;

                                if (isExportFile) throw new Exception(strMsg);
                                else MessageBox.Show(strMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                    }
                    if (_printName != "")
                    {
                        rptDoc.PrintOptions.PrinterName = _printName;
                    }
                    if (_toPrinter)
                    {
                        //Add By Tany 2010-09-25
                        ExecSqlString();
                        rptDoc.PrintToPrinter(1, false, 0, 0);

                        rptDoc.Dispose();

                        return false;		//不预览
                    }
                    else
                    {
                        try
                        {
                            //MessageBox.Show("LoadReportWithoutSetting 5");
                            CryRepViw.ReportSource = rptDoc;
                            //MessageBox.Show("LoadReportWithoutSetting 6");
                            this.AddEvent_AfterSetReportSource(); //2013-3-6 增加事件
                        }
                        catch (Exception err)
                        {
                            if (isExportFile) throw new Exception(err.Message);
                            else MessageBox.Show("设置报表数据源出错！\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (LoadSaveReportException err)
            {
                if (isExportFile) throw new Exception(err.Message);
                else MessageBox.Show("报表文件路径设置错误！\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            catch (TypeInitializationException te)
            {
                if (isExportFile) throw new Exception(te.Message);
                else MessageBox.Show("水晶报表组件初始发生错误\r\n" + te.InnerException.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception err)
            {
                if (isExportFile) throw new Exception(err.Message);
                else MessageBox.Show("1、检查数据源设置是否正确！\n2、检查报表与数据源绑定是否正确！\n3、检查参数设置是否正确！\n4、激光打印机请自行配置纸张格式！\n5打印机没有连接或不可用或默认打印没有设置\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        /// <summary>
        /// 以添加并更改默认纸张设置的方式加载报表
        /// </summary>
        /// <returns></returns>
        private bool LoadReportWithSetting()
        {
            try
            {
                if (_reportFilePath != "")
                {
                    ReportDocument rptDoc = new ReportDocument();
                    rptDoc.Load(GetCustomReportPath(_reportFilePath));
                    if (_reportDataSource != null)
                    {
                        rptDoc.SetDataSource(_reportDataSource);

                    }
                    if (_parameters != null)
                    {
                        for (int i = 0; i < _parameters.Length; i++)
                        {
                            try
                            {
                                rptDoc.SetParameterValue(_parameters[i].Text, _parameters[i].Value);
                            }
                            catch (Exception errParameter)
                            {
                                MessageBox.Show("报表参数设置错误！ 参数：" + _parameters[i].Text + "\n" + errParameter.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }

                        }
                    }

                    if (_printName != "")
                    {
                        rptDoc.PrintOptions.PrinterName = _printName;
                    }
                    //设置自定义纸张格式,如果没有则添加,如果有则设为首选纸张
                    AddCustomPaperAndSetDefaultPaper(rptDoc);
                    if (_toPrinter)
                    {
                        //Add By Tany 2010-09-25
                        ExecSqlString();
                        rptDoc.PrintToPrinter(1, false, 0, 0);


                        rptDoc.Dispose();
                        ResetDefaultPaper();//add by wangzhi 20101214

                        return false;		//不预览
                    }
                    else
                    {
                        try
                        {
                            CryRepViw.ReportSource = rptDoc;
                            this.AddEvent_AfterSetReportSource(); //2013-3-6 增加事件

                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("设置报表数据源出错！\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (LoadSaveReportException err)
            {
                MessageBox.Show("报表文件路径设置错误！\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            catch (TypeInitializationException te)
            {
                MessageBox.Show("水晶报表组件初始发生错误\r\n" + te.InnerException.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception err)
            {
                MessageBox.Show("1、检查数据源设置是否正确！\n2、检查报表与数据源绑定是否正确！\n3、检查参数设置是否正确！\n4、激光打印机请自行配置纸张格式！\n5打印机没有连接或不可用或默认打印没有设置\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        /// <summary>
        /// 根据ClientWindow.ini中DEFUAL_PAPTER的值设置打印机的默认纸张
        /// </summary>
        private void ResetDefaultPaper()
        {
            string sRset = ApiFunction.GetIniString("RESET_PRINTER_PAPTER", "ALLOW_RESET", Constant.ApplicationDirectory + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(sRset))
            {
                ApiFunction.WriteIniString("RESET_PRINTER_PAPTER", "ALLOW_RESET", "TRUE", Constant.ApplicationDirectory + "\\ClientWindow.ini");
                sRset = ApiFunction.GetIniString("RESET_PRINTER_PAPTER", "ALLOW_RESET", Constant.ApplicationDirectory + "\\ClientWindow.ini");
            }
            if (sRset.ToUpper() == "TRUE")
            {
                string sVal = ApiFunction.GetIniString("RESET_PRINTER_PAPTER", "DEFUAL_PAPTER", Constant.ApplicationDirectory + "\\ClientWindow.ini");
                if (string.IsNullOrEmpty(sVal))
                {
                    ApiFunction.WriteIniString("RESET_PRINTER_PAPTER", "DEFUAL_PAPTER", "A4", Constant.ApplicationDirectory + "\\ClientWindow.ini");
                    sVal = ApiFunction.GetIniString("RESET_PRINTER_PAPTER", "DEFUAL_PAPTER", Constant.ApplicationDirectory + "\\ClientWindow.ini");
                }
                //不预览的话直接还原纸张设置
                WorkStaticFun.SetPrinterDefaultPaper(sVal /*"A4"*/);
            }
        }
        /// <summary>
        /// 添加自定义纸张并且设置为当前打印机的默认纸张
        /// </summary>
        /// <param name="rptDoc"></param>
        private void AddCustomPaperAndSetDefaultPaper(ReportDocument rptDoc)
        {
            try
            {
                string _reportName = GetReportFileName();
                //查找数据库中设置的纸张格式
                string sql = "select * from jc_reportpaper where reportname='" + _reportName + "'";
                DataTable paperTb = db.GetDataTable(sql);
                //如果设置了纸张才进行下面的操作
                if (paperTb.Rows.Count > 0)
                {
                    PrintDocument prtdoc = new PrintDocument();
                    string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;//获取默认打印机

                    #region 处理打印机纸张设置及添加
                    #region 获取打印机注册表信息
                    Microsoft.Win32.RegistryKey rk;
                    if (!strDefaultPrinter.StartsWith(@"\\"))//本地打印机
                    {
                        //rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Printers\\" + strDefaultPrinter + "\\DsDriver");
                        rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Print\Printers\" + strDefaultPrinter + @"\DsDriver");
                    }
                    else                                //网络打印机
                    {
                        //string[] p = strDefaultPrinter.Remove(0, 2).Split(new char[] { '\\' });
                        //string path = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Providers\\LanMan Print Services\\Servers\\" + p[0] + "\\Printers\\" + p[1] + "\\DsDriver";
                        //rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(path);

                        //jianqg  增加 处理网络打印机  win7 下 2012-7-25
                        rk = WorkStaticFun.GetRegistryKey_NetWorkPrint(strDefaultPrinter);
                    }
                    #endregion
                    //获取默认打印机支持的纸张
                    string[] papers = (string[])(rk.GetValue("printMediaSupported"));
                    int iPaper = 0;
                    bool Exist = false;
                    PaperName = paperTb.Rows[0]["PAPERNAME"].ToString();

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
                        #region 添加纸张到打印机
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
                                    MessageBox.Show("自定义纸张已经设置成功，第一次打印大约需要几秒到几十秒设置打印机，请耐心等待！\n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //return false;
                                }

                                //初始化 
                                const int DM_OUT_BUFFER = 2;
                                const int DM_IN_BUFFER = 8;
                                structDevMode devMode = new structDevMode();
                                IntPtr hPrinterInfo, hDummy;
                                PRINTER_INFO_9 printerInfo;
                                printerInfo.pDevMode = IntPtr.Zero;
                                int iPrinterInfoSize, iDummyInt;

                                int papersLength = 0;

                                papersLength = papers.Length;

                                papers = (string[])(rk.GetValue("printMediaSupported"));

                                if (papersLength == papers.Length)
                                {
                                    for (int i = 1; i <= 30; i++)
                                    {
                                        papers = (string[])(rk.GetValue("printMediaSupported"));
                                        if (papersLength != papers.Length)
                                        {
                                            MessageBox.Show("用时" + i.ToString() + "秒！");
                                            break;
                                        }
                                        else
                                        {
                                            SendMessageTimeout(
                                             new IntPtr(HWND_BROADCAST),
                                             WM_SETTINGCHANGE,
                                             IntPtr.Zero,
                                             IntPtr.Zero,
                                             SendMessageTimeoutFlags.SMTO_NORMAL,
                                             1000,
                                             out hDummy);
                                        }
                                    }
                                }

                                //查找这个纸张是否存在
                                for (int i = 0; i < papers.Length; i++)
                                {
                                    if (papers[i].ToString().ToUpper() == PaperName.ToUpper())
                                    {
                                        iPaper = i;
                                        break;
                                    }
                                }

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
                            }
                            catch (ApplicationException apperr)
                            {
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
                        #endregion
                    }
                    else//有纸张则设置为首选纸张
                    {
                        #region 设置打印机的默认纸张
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
                                // new IntPtr( HWND_BROADCAST ) ,
                                // WM_SETTINGCHANGE ,
                                // IntPtr.Zero ,
                                // IntPtr.Zero ,
                                // FrmReportView.SendMessageTimeoutFlags.SMTO_NORMAL ,
                                // 1000 ,
                                // out hDummy );
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
                        #endregion
                    }
                    //Modify By Tany 2010-10-08 如果纸张不存在，则用另外的方式查找一下
                    try
                    {
                        int[] sizes = PaperSizeGetter.Get_PaperSizes(strDefaultPrinter);
                        int paperSizeid = sizes[iPaper];

                        rptDoc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)(paperSizeid);
                    }
                    catch
                    {
                        PaperSize myPaperSize = null;
                        //查找打印机所支持纸张中的同名纸张
                        foreach (PaperSize paperSize in prtdoc.PrinterSettings.PaperSizes)
                        {
                            if (paperSize.PaperName.ToLower() == PaperName.ToLower())
                            {
                                myPaperSize = paperSize;
                                break;
                            }
                        }
                        //设置打印机名
                        rptDoc.PrintOptions.PrinterName = strDefaultPrinter;
                        //设置打印纸张
                        if (myPaperSize != null)
                            rptDoc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)myPaperSize.RawKind;
                    }
                    #endregion

                }
            }
            catch (Exception err)
            {
                //MessageBox.Show("自定义纸张设置错误！\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 根据报表路径获取报表名称
        /// jianqg 2013-1-28 由private 改为protected 方便 窗口继承
        /// </summary>
        /// <returns></returns>
        protected string GetReportFileName()
        {
            string _reportName = _reportFilePath;
            int _idx = 0;
            //从_reportFilePath取出报表文件名
            while (_reportName.IndexOf(@"\") >= 0)
            {
                _idx = _reportName.IndexOf(@"\");
                _reportName = _reportName.Substring(_idx + 1);
            }
            _reportName = _reportName.Substring(0, _reportName.Length - 4);
            return _reportName;
        }

        /// <summary>
        /// 将运行环境下报表路径转换成自定义路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetCustomReportPath(string path)
        {
            //取得报表文件名
            string fileName = path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);
            string customReportDirectory = "";
            if (_localLogin)	//如果是本机登录则报表文件路径默认为本机数据库Access所在路径
            {
                //从INI文件读取本机数据库路径
                //string dataSource=Crypto.Instance().UnCryp(ApiFunction.GetIniString("LOCALSERVER","DATASOURCE",Constant.ApplicationDirectory+"\\ClientConfig.ini"));
                string dataSource = ApiFunction.GetIniString("LOCALSERVER", "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini");
                customReportDirectory = dataSource.Substring(0, dataSource.LastIndexOf("\\")) + "\\Report";
            }
            else
                customReportDirectory = Constant.CustomDirectory + "\\Report";
            if (!Directory.Exists(customReportDirectory))			//如果该路径不存在则建立该目录
            {
                Directory.CreateDirectory(customReportDirectory);
            }
            if (!File.Exists(customReportDirectory + "\\" + fileName))	//如果配置文件不存在则从安装目录拷贝
            {
                File.Copy(path, customReportDirectory + "\\" + fileName, true);
            }
            return customReportDirectory + "\\" + fileName;
        }

        //Add By Tany 2010-09-25
        /// <summary>
        /// 打印后执行SQL语句
        /// </summary>
        private void ExecSqlString()
        {
            bool old_isExecSuccess = _isExecSuccess;
            if (_sqlStr != null && _sqlStr.Length > 0 && !_isExecSuccess)
            {
                try
                {
                    db.DoCommand(null, null, null, _sqlStr);

                    _isExecSuccess = true;
                    if (IsExecSuccessChanged != null) IsExecSuccessChanged(null, new EventArgs());
                }
                catch (Exception ex)
                {
                    _isExecSuccess = false;
                    if (IsExecSuccessChanged != null) IsExecSuccessChanged(null, new EventArgs());
                    string sql = "";
                    for (int i = 0; i < _sqlStr.Length; i++)
                    {
                        if (_sqlStr[i].Trim() != "")
                        {
                            sql += "[" + i.ToString() + "]" + _sqlStr[i].Trim() + ";";
                        }
                    }

                    throw new Exception(ex.Message + "\n\n" + sql);
                }
            }
        }
        #endregion

        #region 事件

        private void rbtnPageRange_CheckedChanged(object sender, System.EventArgs e)
        {
            nupFromPage.Enabled = rbtnPageRange.Checked;
            lblTo.Enabled = rbtnPageRange.Checked;
            nupToPage.Enabled = rbtnPageRange.Checked;
        }
        //Add By Tany 2007-10-24
        //--------------------------------------------------------------
        #endregion

        #region 原来窗口中的事件Load 及Closed 改为两个过程，可以供窗口调用 jianqg 2013-2-20
        public void Control_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                PrinterManager printerManager = new PrinterManager();
                string objPrinter = "";//目标打印机
                //获取打印机

                if (string.IsNullOrEmpty(this._printName))
                    objPrinter = PrinterManager.CurrentDefaultPrinter;
                else
                    objPrinter = this._printName;
                //判断类型

                Printer printer = printerManager.GetConfiguredPrinter(objPrinter);
                if (printer != null)
                {
                    //激光打印机和网络打印机不还原纸张
                    if (printer.Type != PrinterType.激光打印机 && !printer.IsNetPrinter)
                    {
                        ResetDefaultPaper();
                    }
                }
            }
            catch
            {
                //
            }
            finally
            {
                //2013-1-18 增加 将对象销毁，不要在temp文件中产生垃圾 jianqg
                if (CryRepViw.ReportSource != null)
                {
                    ReportDocument rpt = CryRepViw.ReportSource as ReportDocument;
                    if (rpt != null) rpt.Dispose();

                }
                CryRepViw.Dispose();



            }
        }

        public void Control_Load(object sender, EventArgs e)
        {

            //Modify By Tany 2012-04-06
            //Modify By Tany 2012-05-15 21水晶报表打印预览窗体是否允许导出文件 0=是1=不是
            //Modify By jianq 2012-07-31 处理 emr 中调用 报错，因为没有FrmMdiMain.CurrentUser
            User CurrentUser = null;
            if (FrmMdiMain.CurrentUser == null)
            {
                CurrentUser = new User();
            }
            else
            {
                CurrentUser = FrmMdiMain.CurrentUser;
            }

            if (CurrentUser.IsAdministrator || new SystemCfg(21).Config == "0")
            {
                CryRepViw.ShowCloseButton = true;
                CryRepViw.ShowExportButton = true;
                CryRepViw.ShowRefreshButton = true;
                CryRepViw.ShowGroupTreeButton = true;
            }


        }
        //--------------------------------------------------------------
        #endregion

        #region 原来窗口中构造函数  改为对应的过程，可以供窗口调用 jianqg 2013-2-20

        /// <summary>
        /// 报表打印类构造函数
        /// </summary>
        public bool Init()
        {
            //InitializeComponent();
            _toPrinter = false;
            _localLogin = false;
            _reportDataSource = null;
            _reportFilePath = "";
            _parameters = null;
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            //InitializeComponent();
            _toPrinter = false;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        /// <param name="printName">打印机名称</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, string printName)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = printName;
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        /// <param name="localLogin">是否本机数据库报表打印</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, bool localLogin)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = localLogin;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        /// <param name="localLogin">是否本机数据库报表打印</param>
        /// <param name="printName">打印机名称</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, bool localLogin, string printName)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = localLogin;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = printName;
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        //Add By Tany 2010-09-25 新增一个构造函数，用于直接打印时，可以执行sql语句
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        /// <param name="sqlStr">打印后执行字符串</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, string[] sqlStr)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            _sqlStr = sqlStr;//Add by tany 2010-09-25
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        //Add By Tany 2010-10-25 新增一个构造函数，用于直接打印时，可以执行sql语句，可以更改数据连接
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        /// <param name="sqlStr">打印后执行字符串</param>
        /// <param name="database">数据库</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, string[] sqlStr, TrasenClasses.DatabaseAccess.RelationalDatabase database)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            _sqlStr = sqlStr;//Add by tany 2010-09-25
            db = database;//Add By tany 2010-10-25
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        //Add By Tany 2012-03-06 新增一个构造函数，用于是否显示导出、刷新、关闭、树状目录等按钮
        /// <summary>
        /// 根据报表文件的路径及数据源显示报表
        /// </summary>
        /// <param name="reportDataSource">报表数据源</param>
        /// <param name="reportFilePath">报表文件路径</param>
        /// <param name="parameters">报表参数</param>
        /// <param name="toPrinter">是否直接打印</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, bool isShowExport, bool isShowRefresh, bool isShowCloseButton, bool isShowTree)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            CryRepViw.ShowCloseButton = isShowCloseButton;
            CryRepViw.ShowExportButton = isShowExport;
            CryRepViw.ShowRefreshButton = isShowRefresh;
            CryRepViw.ShowGroupTreeButton = isShowTree;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        #endregion


        #region ShowOrHide_ToolbarStatusBar
        /// <summary>
        /// 显示或隐藏ToolbarStatusBar 2012-2-22 增加  jianqg
        /// </summary>
        /// <param name="Visible"></param>
        public void ShowOrHide_ToolbarStatusBar(bool Visible)
        {
            CryRepViw.DisplayToolbar = false;
            CryRepViw.DisplayStatusBar = false;

            tbMain.Visible = false;
            label1.Visible = nupCopies.Visible = false;
            rbtnAll.Visible = rbtnPageRange.Visible = nupFromPage.Visible = lblTo.Visible = nupToPage.Visible = false;
        }
        #endregion


        #region ShowHideGroupTree,GetLastPageNumber,ReportPrint 2013-3-4
        public void ShowHideGroupTree(bool visible)
        {
            CryRepViw.DisplayGroupTree = visible;



        }
        public int GetLastPageNumber()
        {
            CrystalDecisions.Shared.ReportPageRequestContext rprc = new CrystalDecisions.Shared.ReportPageRequestContext();
            ReportDocument rptDoc = (ReportDocument)CryRepViw.ReportSource;

            return rptDoc.FormatEngine.GetLastPageNumber(rprc);  //总页数 
        }

        public void ReportPrint(int copies)
        {
            ReportDocument rptDoc = (ReportDocument)CryRepViw.ReportSource;

            rptDoc.PrintToPrinter(copies, false, 0, 0);
        }
        #endregion
        #region CryRepViw 事件 2013-3-4
        private void CryRepViw_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseClick != null) CryRepViw__MouseClick(sender, e);
        }
        private void CryRepViw_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseMove != null) CryRepViw__MouseMove(sender, e);
        }
        private void CryRepViw_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseUp != null) CryRepViw__MouseUp(sender, e);
        }

        private void CryRepViw_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseWheel != null) CryRepViw__MouseWheel(sender, e);
        }
        private void CryRepViw_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseDoubleClick != null) CryRepViw__MouseDoubleClick(sender, e);
        }

        private void CryRepViw_MouseLeave(object sender, EventArgs e)
        {
            if (this.CryRepViw__MouseLeave != null) CryRepViw__MouseLeave(sender, e);
        }

        private void CryRepViw_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.CryRepViw__KeyDown != null) CryRepViw__KeyDown(sender, e);
        }
        private void CryRepViw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.CryRepViw__KeyPress != null) CryRepViw__KeyPress(sender, e);
        }



        private void CryRepViw_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.CryRepViw__KeyUp != null) CryRepViw__KeyUp(sender, e);

        }

        private void CryRepViw_Click(object sender, EventArgs e)
        {
            if (this.CryRepViw__Click != null) CryRepViw__Click(sender, e);
        }
        private void CryRepViw_DoubleClick(object sender, EventArgs e)
        {
            if (this.CryRepViw__DoubleClick != null) CryRepViw__DoubleClick(sender, e);
        }
        #endregion

        #region 增加事件 SetReportSource,AddEvent 2013-3-6
        /// <summary>
        /// SetReportSource 后增加事件
        /// </summary>
        private void AddEvent_AfterSetReportSource()
        {
            CrystalDecisions.Windows.Forms.PageView pageView = CryRepViw.Controls[0] as CrystalDecisions.Windows.Forms.PageView;
            if (pageView != null && pageView.Controls.Count > 0)
            {
                TabControl temp_tabControl = new TabControl();
                //CrystalDecisions.Windows.Forms.DocumentControl docControl = null; 
                foreach (Control control in pageView.Controls)
                {
                    if (control.GetType() == temp_tabControl.GetType())
                    {
                        TabControl tc = (TabControl)control;
                        foreach (Control tab in tc.Controls)
                        {
                            //tab.BackColor = Color.White;
                            AddEvent(tab);

                        }

                        break;
                    }
                }

            }
        }
        private void AddEvent(Control objControl)
        {
            //CrystalDecisions.Windows.Forms.PageView pageView = CryRepViw.Controls[0] as CrystalDecisions.Windows.Forms.PageView;
            objControl.MouseClick += new MouseEventHandler(CryRepViw_MouseClick);

            objControl.MouseMove += new MouseEventHandler(CryRepViw_MouseMove);
            objControl.MouseUp += new MouseEventHandler(CryRepViw_MouseUp);
            objControl.MouseDown += new MouseEventHandler(CryRepViw_MouseDown);

            objControl.MouseWheel += new MouseEventHandler(CryRepViw_MouseWheel);
            objControl.MouseDoubleClick += new MouseEventHandler(CryRepViw_MouseDoubleClick);

            objControl.MouseLeave += new EventHandler(CryRepViw_MouseLeave);


            objControl.KeyDown += new KeyEventHandler(CryRepViw_KeyDown);
            objControl.KeyPress += new KeyPressEventHandler(CryRepViw_KeyPress);
            objControl.KeyUp += new KeyEventHandler(CryRepViw_KeyUp);

            objControl.Click += new EventHandler(CryRepViw_Click);
            objControl.DoubleClick += new EventHandler(CryRepViw_DoubleClick);
        }
        #endregion

        #region 增加属性 用于翻页的控件 2013-3-6
        public Panel PanelLeft
        {
            get
            {
                return this.panelLeft;
            }
        }
        public Panel PanelRight
        {
            get
            {
                return this.panelRight;
            }
        }
        #endregion
        #region panelLeft,panelRight 的Visible 自动设置pageView底色 2013-3-6

        #endregion


        #region ExportToFile  内部过程
        /// <summary>
        /// 导出文件 内部过程
        /// </summary>
        /// <param name="ReportDoc"></param>
        /// <param name="FileName_export"></param>
        /// <param name="File_Type"></param>
        /// <returns></returns>
        private bool ExportToFile(ReportDocument ReportDoc, string FileName_export, FileType File_Type)
        {
            bool isSucess = false;
            CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();

            ReportDoc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            if (File_Type == FileType.Word)
            {

                ReportDoc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.WordForWindows;
            }
            else if (File_Type == FileType.PDF || File_Type != FileType.Word)
            {
                ReportDoc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            }
            DiskOpts.DiskFileName = FileName_export;

            ReportDoc.ExportOptions.DestinationOptions = DiskOpts;
            ReportDoc.Export();
            isSucess = true;
            return isSucess;
        }
        #endregion

        #region ExportToFile  外部方法
        /// <summary>
        /// 控件导出 文件 ExportToFile
        /// </summary>
        /// <param name="FileName_export">报表文件名称,调用时请使用Server.MapPath("报表文件.rpt")这样来给这个参数</param>
        /// <param name="File_Type">你要导成的目标文件名称,注意不要放在wwwroot等目录中,iis会不让你导出的</param>
        /// <returns></returns>
        public bool ExportToFile(string FileName_export, FileType File_Type)
        {
            if (CryRepViw.ReportSource == null)
            {
                throw new Exception("没有报表文件！");
            }
            ReportDocument ReportDoc = (ReportDocument)CryRepViw.ReportSource;
            return ExportToFile(ReportDoc, FileName_export, File_Type);
        }


        /// <summary>   
        /// 导出报表文件为PDF格式   
        /// </summary>   
        /// <param name="ReportFile">报表文件名称,调用时请使用Server.MapPath("报表文件.rpt")这样来给这个参数</param>   
        /// <param name="ReportDataSource">报表文件所使用的数据源,是一个Dataset</param>   
        /// <param name="FileName_export">你要导成的目标文件名称,注意不要放在wwwroot等目录中,iis会不让你导出的</param>  
        /// <param name="parameters">参数列表</param>   
        /// <returns>bool成功返回true,失败返回false</returns> 
        public bool ExportToFile(string ReportFile, object ReportDataSource, string FileName_export, ParameterEx[] parameters, FileType File_Type)
        {
            try
            {
                _reportFilePath = ReportFile;
                _reportDataSource = ReportDataSource;
                _parameters = parameters;

                LoadReportWithoutSetting(true);

                bool flag = ExportToFile(FileName_export, File_Type);
                //2013-1-18 增加 将对象销毁，不要在temp文件中产生垃圾 jianqg
                if (CryRepViw.ReportSource == null)
                {
                    ReportDocument ReportDoc = (ReportDocument)CryRepViw.ReportSource;
                    ReportDoc.Dispose();
                }

                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CryRepViw_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseDown != null) CryRepViw__MouseDown(sender, e);
        }

        //public void Init_ExportFile(string ReportFile, object ReportDataSource, ParameterEx[] parameters)
        //{
        //    _reportFilePath = ReportFile;
        //    _reportDataSource = ReportDataSource;
        //    _parameters = parameters;
        //    LoadReportWithoutSetting();
        //}

        public void tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (!Convertor.IsInteger(nupFromPage.Value.ToString()))
                {
                    MessageBox.Show("起始页码只能输入整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Convertor.IsInteger(nupToPage.Value.ToString()))
                {
                    MessageBox.Show("结束页码只能输入整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (nupFromPage.Value > nupToPage.Value)
                {
                    MessageBox.Show("起始页码不能大于结束页码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                switch (Convert.ToInt32(e.Button.Tag))
                {
                    case 0:
                        ReportDocument rptDoc = (ReportDocument)CryRepViw.ReportSource;
                        //Add By Tany 2010-09-25
                        ExecSqlString();
                        if (rbtnAll.Checked)
                            rptDoc.PrintToPrinter(Convert.ToInt32(nupCopies.Value), false, 0, 0);
                        else
                            rptDoc.PrintToPrinter(Convert.ToInt32(nupCopies.Value), false, Convert.ToInt32(nupFromPage.Value), Convert.ToInt32(nupToPage.Value));

                        break;
                    default:
                        break;
                }
                _isPrinted = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion 
    }
}
