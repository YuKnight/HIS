using System;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Security;
using System.IO;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;

namespace TrasenFrame.Classes
{
    /// <summary>
    /// WorkStaticFun 的摘要说明
    /// 常用与业务有关的静态方法
    /// </summary>
    public class WorkStaticFun
    {
        //Modify By Tany 2009-12-29
        //Modify By jianqg 2012-7-25 win7 网络打印机 注册表
        //为了给发送消息使用线程，不适用
        //private static bool issm;
        //private static SystemModule sm;
        //private static string wardid;
        //private static long deptid;
        //private static long empid;
        //private static string sender;
        //private static string msg;

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

        private WorkStaticFun()
        {

        }
        #region 通过动态链接库名称与引出函数名称访问窗体
        /// <summary>
        /// 通过动态链接库名称与引出函数名称访问窗体
        /// </summary>
        /// <param name="dllName">动态链接库名称</param>
        /// <param name="functionName">函数名称</param>
        /// <param name="chineseName">窗体中文名称</param>
        /// <param name="currentUser">当前操作员ID</param>
        /// <param name="currentDept">当前操作员所在科室ID</param>
        /// <param name="menuId">菜单ID</param>
        /// <param name="mdiParent">MDI父窗体</param>
        /// <param name="database">数据库访问类</param>
        /// <param name="tag">附属值</param>
        /// <returns></returns>
        public static void InstanceForm(string dllName, string functionName, string chineseName, User currentUser,
            Department currentDept, MenuTag tag, long menuId, Form mdiParent, RelationalDatabase database)
        {
            try
            {
                //加载类库
                Assembly assembly = Assembly.LoadFrom(Constant.ApplicationDirectory + "\\" + dllName + ".dll");
                //获得类（型）
                Type type = assembly.GetType(dllName + ".InstanceForm", false, true);
                //实例化引导函数类
                Object obj = System.Activator.CreateInstance(type);
                //设置属性
                ((IDllInformation)obj).FunctionName = functionName;
                ((IDllInformation)obj).ChineseName = chineseName;
                ((IDllInformation)obj).CurrentUser = currentUser;
                ((IDllInformation)obj).CurrentDept = currentDept;
                ((IDllInformation)obj).MenuId = menuId;
                ((IDllInformation)obj).MdiParent = mdiParent;
                ((IDllInformation)obj).Database = database;
                ((IDllInformation)obj).FunctionTag = tag;
                //实例化窗体
                ((IDllInformation)obj).InstanceWorkForm();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// 通过动态链接库名称与引出函数名称访问窗体
        /// </summary>
        /// <param name="dllName">动态链接库名称</param>
        /// <param name="functionName">函数名称</param>
        /// <param name="chineseName">窗体中文名称</param>
        /// <param name="currentUser">当前操作员ID</param>
        /// <param name="currentDept">当前操作员所在科室ID</param>
        /// <param name="menuId">菜单ID</param>
        /// <param name="mdiParent">MDI父窗体</param>
        /// <param name="database">数据库访问类</param>
        /// <param name="tag">附属值</param>
        /// <returns></returns>
        public static void InstanceForm(string dllName, string functionName, string chineseName, User currentUser,
            Department currentDept, MenuTag tag, Form mdiParent, RelationalDatabase database)
        {
            try
            {
                //加载类库
                Assembly assembly = Assembly.LoadFrom(Constant.ApplicationDirectory + "\\" + dllName + ".dll");
                //获得类（型）
                Type type = assembly.GetType(dllName + ".InstanceForm", false, true);
                //实例化引导函数类
                Object obj = System.Activator.CreateInstance(type);
                //设置属性
                ((IDllInformation)obj).FunctionName = functionName;
                ((IDllInformation)obj).ChineseName = chineseName;
                ((IDllInformation)obj).CurrentUser = currentUser;
                ((IDllInformation)obj).CurrentDept = currentDept;
                ((IDllInformation)obj).MenuId = 0;
                ((IDllInformation)obj).MdiParent = mdiParent;
                ((IDllInformation)obj).Database = database;
                ((IDllInformation)obj).FunctionTag = tag;
                //实例化窗体
                ((IDllInformation)obj).InstanceWorkForm();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// 通过动态链接库名称与引出函数名称访问窗体
        /// </summary>
        /// <param name="dllName">动态链接库名称</param>
        /// <param name="functionName">函数名称</param>
        /// <param name="chineseName">窗体中文名称</param>
        /// <param name="currentUser">当前操作员ID</param>
        /// <param name="currentDept">当前操作员所在科室ID</param>
        /// <param name="menuId">菜单ID</param>
        /// <param name="mdiParent">MDI父窗体</param>
        /// <param name="database">数据库访问类</param>
        /// <param name="tag">附属值</param>
        /// <returns></returns>
        public static void InstanceForm(string dllName, string functionName, string chineseName, User currentUser,
            Department currentDept, Form mdiParent, RelationalDatabase database)
        {
            try
            {
                //加载类库
                Assembly assembly = Assembly.LoadFrom(Constant.ApplicationDirectory + "\\" + dllName + ".dll");
                //获得类（型）
                Type type = assembly.GetType(dllName + ".InstanceForm", false, true);
                //实例化引导函数类
                Object obj = System.Activator.CreateInstance(type);
                //设置属性
                ((IDllInformation)obj).FunctionName = functionName;
                ((IDllInformation)obj).ChineseName = chineseName;
                ((IDllInformation)obj).CurrentUser = currentUser;
                ((IDllInformation)obj).CurrentDept = currentDept;
                ((IDllInformation)obj).MenuId = 0;
                ((IDllInformation)obj).MdiParent = mdiParent;
                ((IDllInformation)obj).Database = database;
                ((IDllInformation)obj).FunctionTag = new MenuTag();
                //实例化窗体
                ((IDllInformation)obj).InstanceWorkForm();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// 通过动态链接库名称与引出函数名称访问窗体(允许不同DLL中FORM通信)
        /// </summary>
        /// <param name="dllName">动态链接库名称</param>
        /// <param name="functionName">函数名称</param>
        /// <param name="chineseName">窗体中文名称</param>
        /// <param name="currentUser">当前操作员ID</param>
        /// <param name="currentDept">当前操作员所在科室ID</param>
        /// <param name="menuId">菜单ID</param>
        /// <param name="mdiParent">MDI父窗体</param>
        /// <param name="database">数据库访问类</param>
        /// <param name="communicateValue">内部通信值</param>
        /// <param name="tag">附属值</param>
        /// <returns></returns>
        public static void InstanceFormEx(string dllName, string functionName, string chineseName, User currentUser,
            Department currentDept, MenuTag tag, long menuId, Form mdiParent, RelationalDatabase database, ref object[] communicateValue)
        {
            try
            {
                //加载类库
                Assembly assembly = Assembly.LoadFrom(Constant.ApplicationDirectory + "\\" + dllName + ".dll");
                //获得类（型）
                Type type = assembly.GetType(dllName + ".InstanceForm", false, true);
                //实例化引导函数类
                Object obj = System.Activator.CreateInstance(type);
                //设置属性
                ((IInnerCommunicate)obj).FunctionName = functionName;
                ((IInnerCommunicate)obj).ChineseName = chineseName;
                ((IInnerCommunicate)obj).CurrentUser = currentUser;
                ((IInnerCommunicate)obj).CurrentDept = currentDept;
                ((IInnerCommunicate)obj).MenuId = menuId;
                ((IInnerCommunicate)obj).MdiParent = mdiParent;
                ((IInnerCommunicate)obj).Database = database;
                ((IInnerCommunicate)obj).CommunicateValue = communicateValue;
                ((IInnerCommunicate)obj).FunctionTag = tag;
                //实例化窗体
                ((IInnerCommunicate)obj).InstanceWorkForm();
                //回传参数
                communicateValue = ((IInnerCommunicate)obj).CommunicateValue;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// 通过动态链接库名称与引出函数名称获得一个窗体（建议只在Dll内部调用）
        /// </summary>
        /// <param name="dllName">动态链接库名称</param>
        /// <param name="functionName">函数名称</param>
        /// <param name="chineseName">窗体中文名称</param>
        /// <param name="currentUser">当前操作员ID</param>
        /// <param name="currentDept">当前操作员所在科室ID</param>
        /// <param name="menuId">菜单ID</param>
        /// <param name="mdiParent">MDI父窗体</param>
        /// <param name="database">数据库访问类</param>
        /// <param name="communicateValue">内部通信值</param>
        /// <param name="tag">附属值</param>
        /// <returns></returns>
        public static object InstanceForm(string dllName, string functionName, string chineseName, User currentUser,
            Department currentDept, MenuTag tag, long menuId, Form mdiParent, RelationalDatabase database, ref object[] communicateValue)
        {
            try
            {
                //加载类库
                Assembly assembly = Assembly.LoadFrom(Constant.ApplicationDirectory + "\\" + dllName + ".dll");
                //获得类（型）
                Type type = assembly.GetType(dllName + ".InstanceForm", false, true);
                //实例化引导函数类
                Object obj = System.Activator.CreateInstance(type);
                //设置属性
                ((IInnerCommunicate)obj).FunctionName = functionName;
                ((IInnerCommunicate)obj).ChineseName = chineseName;
                ((IInnerCommunicate)obj).CurrentUser = currentUser;
                ((IInnerCommunicate)obj).CurrentDept = currentDept;
                ((IInnerCommunicate)obj).MenuId = menuId;
                ((IInnerCommunicate)obj).MdiParent = mdiParent;
                ((IInnerCommunicate)obj).Database = database;
                ((IInnerCommunicate)obj).CommunicateValue = communicateValue;
                ((IInnerCommunicate)obj).FunctionTag = tag;
                //返回对象
                object returnObject = ((IInnerCommunicate)obj).GetObject();
                //回传参数
                communicateValue = ((IInnerCommunicate)obj).CommunicateValue;
                return returnObject;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        /// <summary>
        /// 通过动态链接库名称与引出函数名称获得一个窗体（建议只在Dll内部调用）
        /// </summary>
        /// <param name="dllName">动态链接库名称</param>
        /// <param name="functionName">函数名称</param>
        /// <param name="chineseName">窗体中文名称</param>
        /// <param name="currentUser">当前操作员ID</param>
        /// <param name="currentDept">当前操作员所在科室ID</param>
        /// <param name="mdiParent">MDI父窗体</param>
        /// <param name="database">数据库访问类</param>
        /// <param name="communicateValue">内部通信值</param>
        /// <param name="tag">附属值</param>
        /// <returns></returns>
        public static object InstanceForm(string dllName, string functionName, string chineseName, User currentUser,
            Department currentDept, MenuTag tag, Form mdiParent, RelationalDatabase database, ref object[] communicateValue)
        {
            try
            {
                //加载类库
                Assembly assembly = Assembly.LoadFrom(Constant.ApplicationDirectory + "\\" + dllName + ".dll");
                //获得类（型）
                Type type = assembly.GetType(dllName + ".InstanceForm", false, true);
                //实例化引导函数类
                Object obj = System.Activator.CreateInstance(type);
                //设置属性
                ((IInnerCommunicate)obj).FunctionName = functionName;
                ((IInnerCommunicate)obj).ChineseName = chineseName;
                ((IInnerCommunicate)obj).CurrentUser = currentUser;
                ((IInnerCommunicate)obj).CurrentDept = currentDept;
                ((IInnerCommunicate)obj).MenuId = 0;
                ((IInnerCommunicate)obj).MdiParent = mdiParent;
                ((IInnerCommunicate)obj).Database = database;
                ((IInnerCommunicate)obj).CommunicateValue = communicateValue;
                ((IInnerCommunicate)obj).FunctionTag = tag;
                //返回对象
                object returnObject = ((IInnerCommunicate)obj).GetObject();
                //回传参数
                communicateValue = ((IInnerCommunicate)obj).CommunicateValue;
                return returnObject;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        /// <summary>
        /// 通过动态链接库名称与引出函数名称获得一个窗体（建议只在Dll内部调用）
        /// </summary>
        /// <param name="dllName">动态链接库名称</param>
        /// <param name="functionName">函数名称</param>
        /// <param name="chineseName">窗体中文名称</param>
        /// <param name="currentUser">当前操作员ID</param>
        /// <param name="currentDept">当前操作员所在科室ID</param>
        /// <param name="mdiParent">MDI父窗体</param>
        /// <param name="database">数据库访问类</param>
        /// <param name="communicateValue">内部通信值</param>
        /// <returns></returns>
        public static object InstanceForm(string dllName, string functionName, string chineseName, User currentUser,
            Department currentDept, Form mdiParent, RelationalDatabase database, ref object[] communicateValue)
        {
            try
            {
                //加载类库
                Assembly assembly = Assembly.LoadFrom(Constant.ApplicationDirectory + "\\" + dllName + ".dll");
                //获得类（型）
                Type type = assembly.GetType(dllName + ".InstanceForm", false, true);
                //实例化引导函数类
                Object obj = System.Activator.CreateInstance(type);
                //设置属性
                ((IInnerCommunicate)obj).FunctionName = functionName;
                ((IInnerCommunicate)obj).ChineseName = chineseName;
                ((IInnerCommunicate)obj).CurrentUser = currentUser;
                ((IInnerCommunicate)obj).CurrentDept = currentDept;
                ((IInnerCommunicate)obj).MenuId = 0;
                ((IInnerCommunicate)obj).MdiParent = mdiParent;
                ((IInnerCommunicate)obj).Database = database;
                ((IInnerCommunicate)obj).CommunicateValue = communicateValue;
                ((IInnerCommunicate)obj).FunctionTag = new MenuTag();
                //返回对象
                object returnObject = ((IInnerCommunicate)obj).GetObject();
                //回传参数
                communicateValue = ((IInnerCommunicate)obj).CommunicateValue;
                return returnObject;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        /// <summary>
        /// 根据动态链接库名称、引出函数名称取得菜单ID
        /// </summary>
        /// <param name="dllName">动态链接库名称</param>
        /// <param name="functionName">引出函数名称</param>
        /// <param name="database">数据库访问类</param>
        /// <returns>菜单ID</returns>
        [Obsolete("该方法已经不再支持", true)]
        public static long GetMenuId(string dllName, string functionName, RelationalDatabase database)
        {
            string sql = "SELECT MENU_ID FROM BASE_MENU WHERE DLL_NAME='" + dllName + "' AND FUNCTION_NAME='" + functionName + "'";
            return Convert.ToInt64(Convertor.IsNull(database.GetDataResult(sql), "-1"));
        }
        #endregion

        #region 通过键盘值获得数据行
        /// <summary>
        /// 通过键盘值获得数据行（要求查询表中有如下字段名：ROWNO、PY_CODE、WB_CODE）
        /// </summary>
        /// <param name="occurObject">触发网格弹出的对象</param>
        /// <param name="keyInt">键盘值</param>
        /// <param name="currColumn">当前列索引(只对网格实用)</param>
        /// <param name="cardGrid">选项网格</param>
        /// <param name="tableStyleIndex">网格格式索引</param>
        /// <param name="dataSet">数据集</param>
        /// <param name="tableName">查询表名称</param>
        /// <param name="filterType">过滤类型（拼音、五笔。。。）</param>
        /// <param name="searchType">查询类型（前导相似。。。）</param>
        /// <param name="respondKey">是否响应键值</param>
        /// <param name="otherFilter">其他过滤条件</param>
        /// <param name="useDataView">使用DataView过滤，不显示行号</param>
        /// <returns></returns>
        public static DataRow GetCardData(Object occurObject, int keyInt, int currColumn, DataGrid cardGrid, int tableStyleIndex, DataSet dataSet, string tableName,
            FilterType filterType, SearchType searchType, ref bool respondKey, string otherFilter, bool useDataView)
        {
            DataTable selectView = null;
            DataTable CurTable = null;
            //定义可能触发的对象
            DataGrid occurGrid = null;
            Control occurTextBox = null;
            //区别触发对象
            if (occurObject.GetType().IsSubclassOf(typeof(System.Windows.Forms.DataGrid)) || occurObject.GetType() == typeof(System.Windows.Forms.DataGrid))	//网格	
            {
                occurGrid = (DataGrid)occurObject;
            }
            else if (occurObject.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)) || occurObject.GetType() == typeof(System.Windows.Forms.TextBox))//文本框
            {
                occurTextBox = (TextBox)occurObject;
            }
            else if (occurObject.GetType().IsSubclassOf(typeof(System.Windows.Forms.ComboBox)) || occurObject.GetType() == typeof(System.Windows.Forms.ComboBox))//组合框与文本框相同
            {
                occurTextBox = (ComboBox)occurObject;
            }

            if (occurGrid != null)
            {
                CurTable = (DataTable)occurGrid.DataSource;
            }
            //ESC键
            if ((Keys)keyInt == Keys.Escape && cardGrid.Visible)
            {
                cardGrid.Visible = false;
                return null;
            }

            #region 方向键
            if ((Keys)keyInt == Keys.Down && cardGrid.Visible)
            {
                selectView = (DataTable)cardGrid.DataSource;
                if (cardGrid.CurrentRowIndex < selectView.DefaultView.Count - 1)
                {
                    cardGrid.CurrentRowIndex += 1;
                }
                else
                {
                    cardGrid.CurrentRowIndex = 0;
                }
                return null;
            }
            if ((Keys)keyInt == Keys.Up && cardGrid.Visible)
            {
                selectView = (DataTable)cardGrid.DataSource;
                if (cardGrid.CurrentRowIndex > 0)
                {
                    cardGrid.CurrentRowIndex -= 1;
                }
                else
                {
                    cardGrid.CurrentRowIndex = selectView.DefaultView.Count - 1;
                }
                return null;
            }
            if (((Keys)keyInt == Keys.Left || (Keys)keyInt == Keys.Right) && !cardGrid.Visible)
            {
                //在触发对象中响应该键值
                respondKey = true;
                return null;
            }
            #endregion

            string filterString = "";
            if (occurGrid != null)
            {
                DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)occurGrid.TableStyles[0].GridColumnStyles[currColumn];
                if (keyInt == 8 || keyInt == 32 || (keyInt >= 48 && keyInt <= 122))
                {
                    filterString = txtCol.TextBox.Text.Trim() + Convert.ToChar(keyInt);
                }
            }
            else
            {
                filterString = occurTextBox.Text.Trim();
            }
            //如果当前输入法为汉字输入法则不返回任何值
            if (InputLanguage.CurrentInputLanguage.LayoutName.ToString() != PubStaticFun.GetInputLanguage("美式键盘").LayoutName.ToString())
            {
                cardGrid.Visible = false;
                return null;
            }
            //如果输入全部为数字则认为是输入的数字码,否则为快捷选码
            if (keyInt == 13 || ((keyInt >= 48 && keyInt <= 57) || (keyInt >= 96 && keyInt <= 105)) && !Convertor.IsNumeric(filterString))
            {
                #region 返回数据行
                if (!cardGrid.Visible)
                {
                    return null;
                }
                cardGrid.Visible = false;
                selectView = (DataTable)cardGrid.DataSource;
                if (selectView == null)
                {
                    if (occurGrid != null)
                    {
                        occurGrid.CurrentCell = new DataGridCell(occurGrid.CurrentRowIndex, currColumn);
                    }
                    return null;
                }
                //如果正确选中列，则说明是正确输入行，并给后列初始值
                if (selectView.Rows.Count > 0)
                {
                    int CurrentRowIndex = cardGrid.CurrentRowIndex;
                    if (keyInt >= 48 && keyInt <= 57 && keyInt - 48 <= selectView.Rows.Count)	//如果按数字键选择
                    {
                        CurrentRowIndex = Convert.ToInt32(keyInt - 48);
                    }
                    if (keyInt >= 96 && keyInt <= 105 && keyInt - 96 <= selectView.Rows.Count)
                    {
                        CurrentRowIndex = Convert.ToInt32(keyInt - 96);
                    }
                    if (occurGrid != null)
                    {
                        //if(occurGrid.CurrentRowIndex<=CurTable.Rows.Count-1)

                        if (CurrentRowIndex != -1)
                        {
                            return selectView.DefaultView[CurrentRowIndex].Row;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (occurTextBox != null)
                    {
                        return selectView.DefaultView[CurrentRowIndex].Row;
                    }
                }
                else
                {
                    return null;
                }
                #endregion
            }
            else
            {
                #region 只允许空格\退格符与有效字符
                if (keyInt == 8 || keyInt == 32 || (keyInt >= 48 && keyInt <= 122))
                {
                    //在触发对象中响应该键值
                    respondKey = true;

                    int top, left;
                    if (keyInt >= 96 && keyInt <= 105) keyInt -= 48;
                    if (occurGrid != null)
                    {
                        #region 触发对象为网格
                        if (occurGrid.TableStyles[0].GridColumnStyles[currColumn].ReadOnly)	//如果该列只读
                        {
                            respondKey = false;
                            return null;
                        }
                        DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)occurGrid.TableStyles[0].GridColumnStyles[currColumn];
                        //定位卡片
                        cardGrid.Parent = occurGrid.Parent;
                        cardGrid.BringToFront();
                        top = occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Top + occurGrid.Top + occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Height;
                        left = occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Left + occurGrid.Left;
                        if (top + cardGrid.Height > cardGrid.Parent.Height)					//如果其下边界超出父容器底边界则底部与父容器底边界对齐
                        {
                            cardGrid.Top = top - cardGrid.Height - occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Height;
                        }
                        else
                        {
                            cardGrid.Top = top;
                        }
                        if (left + cardGrid.Width > cardGrid.Parent.Width)					//如果其右边界超出父容器右边界则底部与父容器右边界对齐
                        {
                            cardGrid.Left = cardGrid.Parent.Width - cardGrid.Width;
                            if (cardGrid.Top < 0)
                            {
                                cardGrid.Top = 0;
                                cardGrid.Left = occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Left - cardGrid.Width;
                            }
                        }
                        else
                        {
                            cardGrid.Left = left;
                            if (cardGrid.Top < 0)
                            {
                                cardGrid.Top = 0;
                                cardGrid.Left = occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Left + occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Width;
                            }
                        }
                        if (keyInt == 8)	//退格符
                        {
                            string filter = txtCol.TextBox.Text;
                            if (txtCol.TextBox.SelectionStart > 0)
                            {
                                filter = filter.Substring(0, txtCol.TextBox.SelectionStart - 1) + filter.Substring(txtCol.TextBox.SelectionStart);
                            }
                            ShowCard(cardGrid, tableStyleIndex, dataSet, tableName, filter.Trim(), filterType, searchType, otherFilter, useDataView);
                        }
                        else
                        {
                            if (keyInt == 32)
                                ShowCard(cardGrid, tableStyleIndex, dataSet, tableName, txtCol.TextBox.Text.Trim() + Convert.ToChar(keyInt), filterType, SearchType.精确定位, otherFilter, useDataView);
                            else
                                ShowCard(cardGrid, tableStyleIndex, dataSet, tableName, txtCol.TextBox.Text.Trim() + Convert.ToChar(keyInt), filterType, searchType, otherFilter, useDataView);
                        }
                        #endregion
                    }
                    else if (occurTextBox != null)
                    {
                        #region 触发对象为文本框或组合框
                        //定位卡片
                        if (!cardGrid.Visible)
                        {
                            PubStaticFun.SetCardGridTopAndLeft(occurTextBox, cardGrid, occurTextBox.Parent, occurTextBox.Top, occurTextBox.Left);
                        }
                        if (keyInt == 32)
                            ShowCard(cardGrid, tableStyleIndex, dataSet, tableName, occurTextBox.Text.Trim(), filterType, SearchType.精确定位, otherFilter, useDataView);
                        else
                            ShowCard(cardGrid, tableStyleIndex, dataSet, tableName, occurTextBox.Text.Trim(), filterType, searchType, otherFilter, useDataView);
                        #endregion
                    }
                    cardGrid.Visible = true;
                }
                #endregion
            }
            return null;
        }
        /// <summary>
        /// 通过键盘值获得数据行（要求查询表中有如下字段名：ROWNO、PY_CODE、WB_CODE）
        /// </summary>
        /// <param name="occurObject">触发网格弹出的对象</param>
        /// <param name="keyInt">键盘值</param>
        /// <param name="currColumn">当前列索引(只对网格实用)</param>
        /// <param name="cardGrid">选项网格</param>
        /// <param name="tableStyleIndex">网格格式索引</param>
        /// <param name="dataSet">数据集</param>
        /// <param name="tableName">查询表名称</param>
        /// <param name="filterType">过滤类型（拼音、五笔。。。）</param>
        /// <param name="searchType">查询类型（前导相似。。。）</param>
        /// <param name="respondKey">是否响应键值</param>
        /// <param name="otherFilter">其他过滤条件</param>
        /// <param name="sortString">排序条件</param>
        /// <returns></returns>
        public static DataRow GetCardData(Object occurObject, int keyInt, int currColumn, DataGrid cardGrid, int tableStyleIndex, DataSet dataSet, string tableName,
            FilterType filterType, SearchType searchType, ref bool respondKey, string otherFilter, string sortString)
        {
            DataTable selectView = null;
            DataTable CurTable = null;
            //定义可能触发的对象
            DataGrid occurGrid = null;
            Control occurTextBox = null;
            //区别触发对象
            if (occurObject.GetType().IsSubclassOf(typeof(System.Windows.Forms.DataGrid)) || occurObject.GetType() == typeof(System.Windows.Forms.DataGrid))	//网格	
            {
                occurGrid = (DataGrid)occurObject;
            }
            else if (occurObject.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)) || occurObject.GetType() == typeof(System.Windows.Forms.TextBox))//文本框
            {
                occurTextBox = (TextBox)occurObject;
            }
            else if (occurObject.GetType().IsSubclassOf(typeof(System.Windows.Forms.ComboBox)) || occurObject.GetType() == typeof(System.Windows.Forms.ComboBox))//组合框与文本框相同
            {
                occurTextBox = (ComboBox)occurObject;
            }

            if (occurGrid != null)
            {
                CurTable = (DataTable)occurGrid.DataSource;
            }
            //ESC键
            if ((Keys)keyInt == Keys.Escape && cardGrid.Visible)
            {
                cardGrid.Visible = false;
                return null;
            }

            #region 方向键
            if ((Keys)keyInt == Keys.Down && cardGrid.Visible)
            {
                selectView = (DataTable)cardGrid.DataSource;
                if (cardGrid.CurrentRowIndex < selectView.Rows.Count - 1)
                {
                    cardGrid.CurrentRowIndex += 1;
                }
                else
                {
                    cardGrid.CurrentRowIndex = 0;
                }

                return null;
            }
            if ((Keys)keyInt == Keys.Up && cardGrid.Visible)
            {
                selectView = (DataTable)cardGrid.DataSource;
                if (cardGrid.CurrentRowIndex > 0)
                {
                    cardGrid.CurrentRowIndex -= 1;
                }
                else
                {
                    cardGrid.CurrentRowIndex = selectView.Rows.Count - 1;
                }
                return null;
            }
            if (((Keys)keyInt == Keys.Left || (Keys)keyInt == Keys.Right) && !cardGrid.Visible)
            {
                //在触发对象中响应该键值
                respondKey = true;
                return null;
            }
            #endregion

            string filterString = "";
            if (occurGrid != null)
            {
                DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)occurGrid.TableStyles[0].GridColumnStyles[currColumn];
                if (keyInt == 8 || keyInt == 32 || (keyInt >= 48 && keyInt <= 122))
                {
                    filterString = txtCol.TextBox.Text.Trim() + Convert.ToChar(keyInt);
                }
            }
            else
            {
                filterString = occurTextBox.Text.Trim();
            }
            //如果当前输入法为汉字输入法则不返回任何值
            if (InputLanguage.CurrentInputLanguage.LayoutName.ToString() != PubStaticFun.GetInputLanguage("美式键盘").LayoutName.ToString())
            {
                cardGrid.Visible = false;
                return null;
            }
            //如果输入全部为数字则认为是输入的数字码,否则为快捷选码
            if (keyInt == 13 || ((keyInt >= 48 && keyInt <= 57) || (keyInt >= 96 && keyInt <= 105)) && !Convertor.IsNumeric(filterString))
            {
                #region 返回数据行
                if (!cardGrid.Visible)
                {
                    return null;
                }
                cardGrid.Visible = false;
                selectView = (DataTable)cardGrid.DataSource;
                if (selectView == null)
                {
                    if (occurGrid != null)
                    {
                        occurGrid.CurrentCell = new DataGridCell(occurGrid.CurrentRowIndex, currColumn);
                    }
                    return null;
                }
                //如果正确选中列，则说明是正确输入行，并给后列初始值
                if (selectView.Rows.Count > 0)
                {
                    int CurrentRowIndex = cardGrid.CurrentRowIndex;
                    if (keyInt >= 48 && keyInt <= 57 && keyInt - 48 <= selectView.Rows.Count)	//如果按数字键选择
                    {
                        CurrentRowIndex = Convert.ToInt32(keyInt - 48);
                    }
                    if (keyInt >= 96 && keyInt <= 105 && keyInt - 96 <= selectView.Rows.Count)
                    {
                        CurrentRowIndex = Convert.ToInt32(keyInt - 96);
                    }
                    if (occurGrid != null)
                    {
                        if (occurGrid.CurrentRowIndex <= CurTable.Rows.Count - 1)
                        {
                            return selectView.Rows[CurrentRowIndex];
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (occurTextBox != null)
                    {
                        return selectView.Rows[CurrentRowIndex];
                    }
                }
                else
                {
                    return null;
                }
                #endregion
            }
            else
            {
                #region 只允许空格\退格符与有效字符
                if (keyInt == 8 || keyInt == 32 || (keyInt >= 48 && keyInt <= 122))
                {
                    //在触发对象中响应该键值
                    respondKey = true;

                    int top, left;
                    if (keyInt >= 96 && keyInt <= 105) keyInt -= 48;
                    if (occurGrid != null)
                    {
                        #region 触发对象为网格
                        if (occurGrid.TableStyles[0].GridColumnStyles[currColumn].ReadOnly)	//如果该列只读
                        {
                            respondKey = false;
                            return null;
                        }
                        DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)occurGrid.TableStyles[0].GridColumnStyles[currColumn];
                        //定位卡片
                        cardGrid.Parent = occurGrid.Parent;
                        cardGrid.BringToFront();
                        top = occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Top + occurGrid.Top + occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Height;
                        left = occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Left + occurGrid.Left;
                        if (top + cardGrid.Height > cardGrid.Parent.Height)					//如果其下边界超出父容器底边界则底部与父容器底边界对齐
                        {
                            cardGrid.Top = top - cardGrid.Height - occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Height;
                        }
                        else
                        {
                            cardGrid.Top = top;
                        }
                        if (left + cardGrid.Width > cardGrid.Parent.Width)					//如果其右边界超出父容器右边界则底部与父容器右边界对齐
                        {
                            cardGrid.Left = cardGrid.Parent.Width - cardGrid.Width;
                            if (cardGrid.Top < 0)
                            {
                                cardGrid.Top = 0;
                                cardGrid.Left = occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Left - cardGrid.Width;
                            }
                        }
                        else
                        {
                            cardGrid.Left = left;
                            if (cardGrid.Top < 0)
                            {
                                cardGrid.Top = 0;
                                cardGrid.Left = occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Left + occurGrid.GetCellBounds(occurGrid.CurrentRowIndex, currColumn).Width;
                            }
                        }
                        if (keyInt == 8)	//退格符
                        {
                            string filter = txtCol.TextBox.Text;
                            if (txtCol.TextBox.SelectionStart > 0)
                            {
                                filter = filter.Substring(0, txtCol.TextBox.SelectionStart - 1) + filter.Substring(txtCol.TextBox.SelectionStart);
                            }
                            ShowCard(cardGrid, tableStyleIndex, dataSet, tableName, filter.Trim(), filterType, searchType, otherFilter, sortString);
                        }
                        else
                        {
                            if (keyInt == 32)
                                ShowCard(cardGrid, tableStyleIndex, dataSet, tableName, txtCol.TextBox.Text.Trim() + Convert.ToChar(keyInt), filterType, SearchType.精确定位, otherFilter, sortString);
                            else
                                ShowCard(cardGrid, tableStyleIndex, dataSet, tableName, txtCol.TextBox.Text.Trim() + Convert.ToChar(keyInt), filterType, searchType, otherFilter, sortString);
                        }
                        #endregion
                    }
                    else if (occurTextBox != null)
                    {
                        #region 触发对象为文本框或组合框
                        //定位卡片
                        if (!cardGrid.Visible)
                        {
                            PubStaticFun.SetCardGridTopAndLeft(occurTextBox, cardGrid, occurTextBox.Parent, occurTextBox.Top, occurTextBox.Left);
                        }
                        if (keyInt == 32)
                            ShowCard(cardGrid, tableStyleIndex, dataSet, tableName, occurTextBox.Text.Trim(), filterType, SearchType.精确定位, otherFilter, sortString);
                        else
                            ShowCard(cardGrid, tableStyleIndex, dataSet, tableName, occurTextBox.Text.Trim(), filterType, searchType, otherFilter, sortString);
                        #endregion
                    }
                    cardGrid.Visible = true;
                }
                #endregion
            }
            return null;
        }
        #endregion

        #region 显示辅助输入卡片(ShowCard)
        /// <summary>
        /// 显示辅助输入卡片
        /// </summary>
        /// <param name="dtGrid">表格对象</param>
        /// <param name="tableStyleIndex">网格格式索引</param>
        /// <param name="dataSet">数据集合</param>
        /// <param name="tableName">数据集中表名称</param>
        /// <param name="filter">筛选条件</param>
        /// <param name="filterType">过滤字段</param>
        /// <param name="finishFlag">过滤方式</param>
        /// <param name="otherFilter">其他过滤条件</param>
        /// <param name="useDataView">使用DataView过滤，不显示行号</param>
        /// <returns></returns>
        public static void ShowCard(DataGrid dtGrid, int tableStyleIndex, DataSet dataSet, string tableName, string filter, FilterType filterType, SearchType finishFlag, string otherFilter, bool useDataView)
        {
            DataTable _dataView = null;
            DataRow[] rows;
            string filterTmp = "";
            if (filter.Trim() == "" && finishFlag == SearchType.精确定位)
            {
                filterTmp = "1=1";		//如果是精确定位且按空字符串查找则显示全部内容
            }
            else
            {
                if (finishFlag == SearchType.模糊查询)
                    filter = "%" + filter;
                if (finishFlag != SearchType.精确定位)
                    filter += "%";
                switch (filterType)
                {
                    case FilterType.智能:
                        filterTmp = "WB_CODE like'" + filter.Trim() + "' or PY_CODE like '" + filter.Trim() + "' or D_CODE like '" + filter.Trim() + "'";
                        break;
                    case FilterType.拼音:
                        filterTmp = "PY_CODE like '" + filter.Trim() + "'";
                        break;
                    case FilterType.五笔:
                        filterTmp = "WB_CODE like'" + filter.Trim() + "'";
                        break;
                    case FilterType.数字:
                        filterTmp = "D_CODE like'" + filter.Trim() + "'";
                        break;
                    default:
                        break;

                }
            }
            if (useDataView)
            {
                if (otherFilter != "")
                    dataSet.Tables[tableName].DefaultView.RowFilter = "(" + filterTmp + ") AND (" + otherFilter + ")";
                else
                    dataSet.Tables[tableName].DefaultView.RowFilter = filterTmp;
                dtGrid.BeginInit();
                //删除原来视图
                dtGrid.DataSource = null;
                //绑定新的视图
                dtGrid.DataSource = dataSet.Tables[tableName];
                dtGrid.TableStyles[tableStyleIndex].MappingName = tableName;
                dtGrid.EndInit();
                PubStaticFun.ModifyDataGridStyle(dtGrid, tableStyleIndex);
                if (dataSet.Tables[tableName].DefaultView.Count > 0)
                {
                    dtGrid.CurrentRowIndex = 0;
                    dtGrid.Select(0);
                }
            }
            else
            {
                try
                {

                    _dataView = dataSet.Tables[tableName].Clone();
                    if (otherFilter != "")
                        rows = dataSet.Tables[tableName].Select("(" + filterTmp + ") AND (" + otherFilter + ")");
                    else
                        rows = dataSet.Tables[tableName].Select(filterTmp);

                    for (int k = 0; k < rows.GetLength(0) && k < 50; k++)
                    {
                        rows[k]["ROWNO"] = k;
                        _dataView.Rows.Add(rows[k].ItemArray);
                    }

                }
                catch (System.Exception err)
                {
                    MessageBox.Show("加载数据时错误\n" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //数据绑定到选择卡片上
                if (_dataView == null)
                {
                    dtGrid.Visible = false;
                    return;
                }
                dtGrid.BeginInit();
                //删除原来视图
                dtGrid.DataSource = null;
                //绑定新的视图
                dtGrid.DataSource = _dataView;
                dtGrid.TableStyles[tableStyleIndex].MappingName = tableName;
                dtGrid.EndInit();
                PubStaticFun.ModifyDataGridStyle(dtGrid, tableStyleIndex);
                if (_dataView.Rows.Count > 0)
                {
                    dtGrid.Select(0);
                }
            }
            //定位卡片
            dtGrid.Visible = true;
        }
        /// <summary>
        /// 显示辅助输入卡片
        /// </summary>
        /// <param name="dtGrid">表格对象</param>
        /// <param name="tableStyleIndex">网格格式索引</param>
        /// <param name="dataSet">数据集合</param>
        /// <param name="tableName">数据集中表名称</param>
        /// <param name="filter">筛选条件</param>
        /// <param name="filterType">过滤字段</param>
        /// <param name="finishFlag">过滤方式</param>
        /// <param name="otherFilter">其他过滤条件</param>
        /// <param name="sortString">排序条件</param>
        /// <returns></returns>
        public static void ShowCard(DataGrid dtGrid, int tableStyleIndex, DataSet dataSet, string tableName, string filter, FilterType filterType, SearchType finishFlag, string otherFilter, string sortString)
        {
            DataTable _dataView = null;
            DataRow[] rows;
            string filterTmp = "";
            if (filter.Trim() == "" && finishFlag == SearchType.精确定位)
            {
                filterTmp = "1=1";		//如果是精确定位且按空字符串查找则显示全部内容
            }
            else
            {
                if (finishFlag == SearchType.模糊查询)
                    filter = "%" + filter;
                if (finishFlag != SearchType.精确定位)
                    filter += "%";
                switch (filterType)
                {
                    case FilterType.智能:
                        filterTmp = "WB_CODE like'" + filter.Trim() + "' or PY_CODE like '" + filter.Trim() + "' or D_CODE like '" + filter.Trim() + "'";
                        break;
                    case FilterType.拼音:
                        filterTmp = "PY_CODE like '" + filter.Trim() + "'";
                        break;
                    case FilterType.五笔:
                        filterTmp = "WB_CODE like'" + filter.Trim() + "'";
                        break;
                    case FilterType.数字:
                        filterTmp = "D_CODE like'" + filter.Trim() + "'";
                        break;
                    default:
                        break;

                }
            }
            try
            {

                _dataView = dataSet.Tables[tableName].Clone();
                if (otherFilter != "")
                    rows = dataSet.Tables[tableName].Select("(" + filterTmp + ") AND (" + otherFilter + ")", sortString);
                else
                    rows = dataSet.Tables[tableName].Select(filterTmp, sortString);
                for (int k = 0; k < rows.GetLength(0) && k < 50; k++)
                {
                    rows[k]["ROWNO"] = k;
                    _dataView.Rows.Add(rows[k].ItemArray);
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show("加载数据时错误\n" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //数据绑定到选择卡片上
            if (_dataView == null)
            {
                dtGrid.Visible = false;
                return;
            }
            dtGrid.BeginInit();
            //删除原来视图
            dtGrid.DataSource = null;
            //绑定新的视图
            dtGrid.DataSource = _dataView;
            dtGrid.TableStyles[tableStyleIndex].MappingName = tableName;
            dtGrid.EndInit();
            PubStaticFun.ModifyDataGridStyle(dtGrid, tableStyleIndex);
            if (_dataView.Rows.Count > 0)
            {
                dtGrid.Select(0);
            }
            //定位卡片
            dtGrid.Visible = true;
        }
        #endregion


        #region 获取连接字符串
        /// <summary>
        /// 获取连接字符串 默认的连接串
        /// jianqg 2012-10-6 emr-his框架整合  增加 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetConnnectionString_Default(ConnectionType type)
        {
            string clientConfigFile = Constant.ApplicationDirectory + "\\ClientConfig.ini";
            string[] ss = System.Windows.Forms.Application.ExecutablePath.Split("\\".ToCharArray());
            string serverName = "";

            serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SERVER_NAME", "NAME", clientConfigFile);
            if (serverName == "")
            {
                System.Windows.Forms.MessageBox.Show("ClientConfig.ini中[SERVER_NAME]的NAME未设置,请启动配置程序并设置当前服务器", "错误");
                throw new Exception("ClientConfig.ini中[SERVER_NAME]的NAME未设置,请启动配置程序并设置当前服务器");
            }

            string connectionString = WorkStaticFun.GetConnnectionString(ConnectionType.SQLSERVER, serverName);
            return connectionString;
        }
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="type">类型0、SQL SERVER 1、IBM DB2</param>
        /// <param name="DatabaseName">INI文件中段(SECTION)名称(当前服务器名)</param>
        public static string GetConnnectionString(ConnectionType type, string DatabaseName)
        {
            string cnnString, hostName, database, userID, password, protocol, port, strCnnType;
            switch (type)
            {
                case ConnectionType.SQLSERVER:
                    hostName = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "HOSTNAME", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    database = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    userID = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "USER_ID", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    password = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "PASSWORD", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    if (hostName.Trim() == "" && database.Trim() == "" && userID.Trim() == "" && password.Trim() == "")
                    {
                        cnnString = "";
                    }
                    else
                    {
                        cnnString = @"packet size=4096;user id=" + userID + ";password=" + password + ";data source=" + hostName + ";persist security info=True;initial catalog=" + database;
                    }
                    break;
                case ConnectionType.IBMDB2:
                    hostName = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "HOSTNAME", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    protocol = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "PROTOCOL", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    port = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "PORT", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    database = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    userID = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "USER_ID", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    password = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "PASSWORD", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    strCnnType = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "CONNECTIONTYPE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    if (strCnnType == "1")
                        cnnString = @"Provider=IBMDADB2;Database=" + database + ";HostName=" + hostName + ";Protocol=" + protocol + ";Port=" + port + ";User ID=" + userID + ";Password=" + password;
                    else
                        cnnString = @"Provider=IBMDADB2.1;User ID=" + userID + ";Password=" + password + ";Data Source=" + database + ";Mode=ReadWrite;Extended Properties=";
                    break;
                case ConnectionType.MSACCESS:
                    database = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    cnnString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=" + database + ";Mode=Share Deny None;Jet OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
                    break;
                case ConnectionType.ORACLE:
                    database = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    userID = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "USER_ID", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    password = Crypto.Instance().Decrypto(ApiFunction.GetIniString(DatabaseName, "PASSWORD", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    cnnString = "Provider=msdaora;Data Source=" + database + ";User Id=" + userID + ";Password=" + password;
                    break;
                default:
                    cnnString = "";
                    break;
            }
            return cnnString;
        }
        #endregion

        #region 根据参数编码获取参数值
        /// <summary>
        /// 根据参数编码获取参数值
        /// </summary>
        /// <param name="code">参数编码</param>
        /// <param name="database">数据库访问对象</param>
        /// <returns></returns>
        public static string GetConfigValueByCode(int code, RelationalDatabase database)
        {
            string sql = "select config from jc_config where id=" + code;
            return Convertor.IsNull(database.GetDataResult(sql), "");
        }
        #endregion

        #region 设置打印机纸张
        /// <summary>
        /// 设置打印机纸张
        /// </summary>
        /// <param name="papername">纸张名称</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public static void SetPrinterPaper(string papername, float width, float height)
        {
            //Add By Tany 2007-10-24
            //****************************************************************************************
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;//获取默认打印机

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
                rk = GetRegistryKey_NetWorkPrint(strDefaultPrinter);
            }
            //获取默认打印机支持的纸张
            string[] papers = (string[])(rk.GetValue("printMediaSupported"));
            int iPaper = 0;
            bool Exist = false;
            string PaperName = papername;

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
                        float WidthInMm = width;
                        float HeightInMm = height;

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
                            MessageBox.Show("自定义纸张已经设置成功！\n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
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
        }
        //Add By Tany 2012-04-04 重载一个方法，可以设置打印机
        /// <summary>
        /// 设置打印机纸张
        /// </summary>
        /// <param name="papername">纸张名称</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="printername">打印机名称</param>
        public static void SetPrinterPaper(string papername, float width, float height, string printername)
        {
            //Add By Tany 2007-10-24
            //****************************************************************************************
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = printername;

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
                rk = GetRegistryKey_NetWorkPrint(strDefaultPrinter);

            }
            //获取默认打印机支持的纸张
            string[] papers = (string[])(rk.GetValue("printMediaSupported"));
            int iPaper = 0;
            bool Exist = false;
            string PaperName = papername;

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
                        float WidthInMm = width;
                        float HeightInMm = height;

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
                            MessageBox.Show("自定义纸张已经设置成功！\n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
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
        }

        /// <summary>
        /// 设置打印机默认纸张
        /// </summary>
        /// <param name="papername">纸张名称（如果没有该名称，请先调用SetPrinterPaper）</param>
        public static void SetPrinterDefaultPaper(string papername)
        {
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;//获取默认打印机

            Microsoft.Win32.RegistryKey rk;
            if (!strDefaultPrinter.StartsWith(@"\\"))//本地打印机
            {
                //rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Printers\\" + strDefaultPrinter + "\\DsDriver");
                rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Print\Printers\" + strDefaultPrinter + @"\DsDriver");
            }
            else                                //网络打印机
            {
                //jianqg  增加 处理网络打印机  win7 下 2012-7-25
                rk = GetRegistryKey_NetWorkPrint(strDefaultPrinter);


            }

            //获取默认打印机支持的纸张
            string[] papers = (string[])(rk.GetValue("printMediaSupported"));


            int iPaper = 0;
            bool Exist = false;
            string PaperName = papername;


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
            if (Exist)
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
                        // SendMessageTimeoutFlags.SMTO_NORMAL,
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
        }

        /// <summary>
        /// 设置打印机默认纸张
        /// </summary>
        /// <param name="papername">纸张名称（如果没有该名称，请先调用SetPrinterPaper）</param>
        /// <param name="printername">打印机名称</param>
        public static void SetPrinterDefaultPaper(string papername, string printername)
        {
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = printername;

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
                rk = GetRegistryKey_NetWorkPrint(strDefaultPrinter);
            }
            //获取默认打印机支持的纸张
            string[] papers = (string[])(rk.GetValue("printMediaSupported"));
            int iPaper = 0;
            bool Exist = false;
            string PaperName = papername;

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
            if (Exist)
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
                        // SendMessageTimeoutFlags.SMTO_NORMAL,
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
        }

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
        #endregion

        #region 回收系统内存
        /// <summary>
        /// 回收系统内存
        /// </summary>
        public class RevokeMemory
        {
            [DllImport("kernel32.dll")]
            private static extern bool GetProcessWorkingSetSize(IntPtr proc, out int min, out int max);

            [DllImport("kernel32.dll")]
            private static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

            public static void ReduceMemoryFootPrint()
            {
                int currentMinWorkingSetValue = 0;
                int currentMaxWorkingSetValue = 0;
                Process currentProcess = Process.GetCurrentProcess();

                try
                {
                    if (GetProcessWorkingSetSize(currentProcess.Handle, out currentMinWorkingSetValue, out currentMaxWorkingSetValue))
                    {
                        currentProcess.MinWorkingSet = (IntPtr)currentMinWorkingSetValue;
                    }
                }
                catch (Exception err)
                {
                    string additionalInfo = "MinWorkingSet value is set to: " + currentMinWorkingSetValue.ToString();
                    additionalInfo += " Process In Error: " + currentProcess.ProcessName;

                    throw new Exception(err.Message + "\n" + additionalInfo);
                }
            }
        }
        #endregion

        #region 获取表的备份数据插入SQL
        /// <summary>
        /// 获取表的备份数据插入SQL
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <returns>返回一个插入数据库脚本字符串</returns>
        public static string GetInsertDataSql(string tablename)
        {
            string sql = "";
            string rtn = "";

            DataTable tb = new DataTable();
            try
            {
                sql = "select * from sysobjects where xtype='U' and name='" + tablename + "'";
                tb = FrmMdiMain.Database.GetDataTable(sql);
                if (tb.Rows.Count <= 0)
                {
                    throw new Exception("没有找到名为" + tablename + "的表！");
                }

                sql = "select * from " + tablename;
                tb = FrmMdiMain.Database.GetDataTable(sql);

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    string tmp = "";
                    string[] tmp1 = new string[tb.Columns.Count];
                    string[] tmp2 = new string[tb.Columns.Count];
                    tmp = "insert into " + tablename + "(";
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        tmp1[j] = tb.Columns[j].ColumnName;
                        if (tb.Columns[j].DataType.Name.ToLower() == "byte" ||
                            tb.Columns[j].DataType.Name.ToLower() == "sbyte" ||
                            tb.Columns[j].DataType.Name.ToLower() == "short" ||
                            tb.Columns[j].DataType.Name.ToLower() == "ushort" ||
                            tb.Columns[j].DataType.Name.ToLower() == "int" ||
                            tb.Columns[j].DataType.Name.ToLower() == "uint" ||
                            tb.Columns[j].DataType.Name.ToLower() == "long" ||
                            tb.Columns[j].DataType.Name.ToLower() == "ulong" ||
                            tb.Columns[j].DataType.Name.ToLower() == "double" ||
                            tb.Columns[j].DataType.Name.ToLower() == "float" ||
                            tb.Columns[j].DataType.Name.ToLower() == "decimal")
                        {
                            tmp2[j] = tb.Rows[i][j].ToString().Trim();
                        }
                        else
                        {
                            tmp2[j] = "'" + tb.Rows[i][j].ToString().Trim() + "'";
                        }
                    }
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        tmp += tmp1[j];
                        if (j != tb.Columns.Count - 1)
                        {
                            tmp += ",";
                        }
                    }
                    tmp += ") values (";
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        tmp += tmp2[j];
                        if (j != tb.Columns.Count - 1)
                        {
                            tmp += ",";
                        }
                    }
                    tmp += ")\n";

                    rtn += tmp;
                }

                return rtn;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        #endregion

        #region 发送消息
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="issm">是否指定系统模块</param>
        /// <param name="sm">系统模块</param>
        /// <param name="wardid">病区代码""表示全部</param>
        /// <param name="deptid">科室代码0表示全部</param>
        /// <param name="empid">用户代码0表示全部</param>
        /// <param name="sender">发送者</param>
        /// <param name="msg">消息内容</param>
        public static void SendMessage(bool issm, SystemModule sm, string wardid, long deptid, long empid, string sender, string msg)
        {
            TrasenFrame.Classes.MessageInfo message = new TrasenFrame.Classes.MessageInfo();
            if ( issm )
                message.ReciveSystem = sm; 
            else
                message.ReciveSystem = null;
            message.ReciveWardId = wardid;
            message.ReciveDeptId = Convert.ToInt32( deptid );
            message.ReciveStaffer = Convert.ToInt32( empid );
            message.Summary = msg;
            SendMessage( message );
            return;

            //try
            //{
            //    //是否启用系统消息
            //    if (Convert.ToInt32(new Classes.SystemCfg(0009).Config) != 0)
            //    {
            //        return;
            //    }
            //    //Add By Tany 2009-12-24
            //    //首先查找符合要求的IP地址
            //    string sql = "select distinct login_ip from pub_user where login_bit=1 ";
            //    if (issm)
            //    {
            //        sql += " and login_system in (select system_id from pub_system where module_id=" + (int)sm + ") ";
            //    }
            //    if (wardid.Trim() != "")
            //    {
            //        sql += " and login_dept in (select dept_id from jc_wardrdept where ward_id='" + wardid + "') ";
            //    }
            //    if (deptid > 0)
            //    {
            //        sql += " and login_dept=" + deptid + " ";
            //    }
            //    if (empid > 0)
            //    {
            //        sql += " and employee_id=" + empid + " ";
            //    }
            //    DataTable ipTb = FrmMdiMain.Database.GetDataTable(sql);

            //    if (ipTb == null || ipTb.Rows.Count == 0)
            //    {
            //        return;
            //    }

            //    int showType = Convert.ToInt32(new Classes.SystemCfg(0010).Config);
            //    int showTime = 5;
            //    if (showType == 0)
            //    {
            //        showTime = Convert.ToInt32(new Classes.SystemCfg(0011).Config);
            //    }
            //    else
            //    {
            //        showTime = Convert.ToInt32(new Classes.SystemCfg(0012).Config);
            //    }

            //    Assembly assembly = Assembly.LoadFile( System.Windows.Forms.Application.StartupPath + "\\TrasenMessage.dll" );
            //    object objMsgCtrl = assembly.CreateInstance( "TrasenMessage.MessageController" , true , BindingFlags.CreateInstance , null , null , null , null );
            //    //循环每个IP，进行消息发送
            //    for ( int i = 0 ; i < ipTb.Rows.Count ; i++ )
            //    {
            //        string hostIp = Convertor.IsNull( ipTb.Rows[i]["login_ip"] , "" );
            //        if ( string.IsNullOrEmpty( hostIp ) )
            //            continue;

            //        MethodInfo mi = objMsgCtrl.GetType().GetMethod( "SendTo" );

            //        mi.Invoke( objMsgCtrl , BindingFlags.InvokeMethod | BindingFlags.Public , null ,
            //            new object[] { hostIp , msg , sender , showType , showTime }, null );
            //    }
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show("发送消息失败：" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        public static void SendMessage( MessageInfo message )
        {
            //如果是必读的，保存到数据库，气泡方式的消息不保存
            RelationalDatabase database = TrasenFrame.Forms.FrmMdiMain.Database.GetCopy();
            try
            {
                database.Open();

                if ( message.IsMustRead )
                    message.Save( database );

                //是否启用系统消息,否的话，不发送
                if ( Convert.ToInt32( new Classes.SystemCfg( 0009 ).Config ) != 0 )
                {
                    return;
                }
                //Add By Tany 2009-12-24
                //首先查找符合要求的IP地址
                string sql = "select login_ip,login_port from pub_user where login_bit=1 ";
                if ( message.ReciveSystem != null )
                    sql += " and login_system in (select system_id from pub_system where module_id=" + (int)message.ReciveSystem.Value + ") ";

                if ( !string.IsNullOrEmpty( message.ReciveWardId ) )
                    sql += " and login_dept in (select dept_id from jc_wardrdept where ward_id='" + message.ReciveWardId + "') ";

                if ( message.ReciveDeptId > 0 )
                    sql += " and login_dept=" + message.ReciveDeptId + " ";

                if ( message.ReciveStaffer > 0 )
                    sql += " and employee_id=" + message.ReciveStaffer + " ";

                sql += " group by login_ip,login_port";
                DataTable ipTb = database.GetDataTable( sql );

                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { sql }, true );

                Assembly assembly = Assembly.LoadFile( System.Windows.Forms.Application.StartupPath + "\\TrasenMessage.dll" );
                object objMsgCtrl = assembly.CreateInstance( "TrasenMessage.MessageController" , true , BindingFlags.CreateInstance , null , null , null , null );
                //循环每个IP，进行消息发送
                for ( int i = 0 ; i < ipTb.Rows.Count ; i++ )
                {
                    string hostIp = Convertor.IsNull( ipTb.Rows[i]["login_ip"] , "" );
                    int port = Convert.ToInt32( Convertor.IsNull( ipTb.Rows[i]["login_port"] , "0" ) );
                    if ( string.IsNullOrEmpty( hostIp ) )
                        continue;

                    MethodInfo mi = objMsgCtrl.GetType().GetMethod( "SendTo" , new Type[] { typeof( string ) , typeof( int ) , typeof( MessageInfo ) } );

                    mi.Invoke( objMsgCtrl , BindingFlags.InvokeMethod | BindingFlags.Public , null ,
                        new object[] { hostIp , port , message }, null );
                    
                }
            }
            catch ( Exception error )
            {
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { error.Message }, true );
            }
            finally
            {
                database.Close();
                database.Dispose();
            }

        }
        #endregion

        #region 获取机构编码对应的数据库连接
        //Add By Tany 2010-01-14
        /// <summary>
        /// 获取机构编码对应的数据库连接
        /// </summary>
        /// <param name="Jgbm">机构编码</param>
        /// <returns>数据库</returns>
        public static RelationalDatabase GetJgbmDb(int Jgbm)
        {
            try
            {
                RelationalDatabase db = new MsSqlServer();
                DataRow row = FrmMdiMain.Database.GetDataRow("select * from jc_jgbm where jgbm=" + Jgbm);
                if (row == null)
                {
                    throw new Exception("没有找到该机构编码（" + Jgbm + "）！");
                }

                string cnnString, hostName, database, userID, password;
                hostName = row["ipaddr"].ToString().Trim();
                database = Crypto.Instance().Decrypto(row["database"].ToString().Trim());
                userID = Crypto.Instance().Decrypto(row["user"].ToString().Trim());
                password = Crypto.Instance().Decrypto(row["password"].ToString().Trim());
                if (hostName.Trim() == "" && database.Trim() == "" && userID.Trim() == "" && password.Trim() == "")
                {
                    cnnString = "";
                }
                else
                {
                    cnnString = @"packet size=4096;user id=" + userID + ";password=" + password + ";data source=" + hostName + ";persist security info=True;initial catalog=" + database;
                }

                if (cnnString == "")
                {
                    throw new Exception("获取该机构编码（" + Jgbm + "）的连接信息错误，请检查机构编码表设置！");
                }

                db.Initialize(cnnString);

                return db;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        #endregion

        public static bool CheckCurrentUserPassword()
        {
            FrmCheckCurrentUserPassword fCheck = new FrmCheckCurrentUserPassword();
            if (fCheck.ShowDialog() == DialogResult.OK)
                return true;
            else
                return false;
        }

        #region 处理win7 等网络打印机注册表问题
        /// <summary>
        /// 处理win7 等网络打印机注册表问题
        /// </summary>
        /// <param name="DefaultPrinter"></param>
        /// <returns></returns>
        public static Microsoft.Win32.RegistryKey GetRegistryKey_NetWorkPrint(string strDefaultPrinter)
        {
            Microsoft.Win32.RegistryKey rk;
            string[] p = strDefaultPrinter.Remove(0, 2).Split(new char[] { '\\' });
            string path ="";
            //jianqg  增加 处理win7 下打印机的问题 2012-7-25
            string os = System.Environment.OSVersion.VersionString;

            if (os.StartsWith("Microsoft Windows NT 6.1.76"))  //Microsoft Windows NT 6.1.7600.0  是 win7
            {
                #region jianqg  增加 处理win7 下打印机的问题 2012-7-25
                path = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Print\Providers\Client Side Rendering Print Provider\Servers\" + p[0] + @"\Printers";
                Microsoft.Win32.RegistryKey rkPrints = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(path);
                rk = rkPrints;
                string[] subKeyNames = rkPrints.GetSubKeyNames();
                foreach (string subKeyname in subKeyNames)
                {
                    rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(path + @"\" + subKeyname + @"\DsDriver");
                    
                    if (rk != null) break;

                }
                if (rk == rkPrints || rk == null)
                {
                    MessageBox.Show("windows 没有找到默认打印机");
                    return rk;
                }
                #endregion
            }
            else
            {
                //path = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Providers\\LanMan Print Services\\Servers\\" + p[0] + "\\Printers\\" + p[1] + "\\DsDriver";
                path =  @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Print\Providers\LanMan Print Services\Servers\" + p[0] + @"\Printers\" + p[1] + @"\DsDriver";

                
                rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(path);
            }
            return rk;
        }
        #endregion

        /// <summary>
        /// 2013-1-18 清理用户文件夹\Local Settings\\Temp的文件
        /// 2013-7-3 jianqg 原来在load事件 移到登录按钮，并且改为不等待
        /// </summary>
        public static void ClearTempDir()
        {
            string Cmdstring = "del /f /s /q \"%userprofile%\\Local Settings\\Temp\\*.*\""; //CMD命令
            ExecCmdString(Cmdstring,-1);//不等待--2013-7-3 修改为不等待
        }
        #region 调用cmd.exe程序处理strCmdString
        /// <summary>
        ///  2013-1-18 调用cmd.exe程序处理strCmdString
        /// </summary>
        /// <param name="strCmdString">需要有cmd.exe执行的字符串，</param>
        public static void ExecCmdString(string strCmdString)
        {
            ExecCmdString(strCmdString, 0);
        }
        
        /// <summary>
        /// <param name="strCmdString">需要有cmd.exe执行的字符串</param>
        /// </summary>
        /// <param name="strCmdString"></param>
        /// <param name="Wait_milliSeconds">等待时间0一直等待，>为等待毫秒时间，其他不等待</param>
        public static void ExecCmdString(string strCmdString,int Wait_milliSeconds)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;

                p.StartInfo.CreateNoWindow = true;

                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;


                //string Cmdstring = "del /f /s /q \"%userprofile%\\Local Settings\\Temp\\*.*\""; //CMD命令

                p.Start();
                p.StandardInput.WriteLine(strCmdString);
                p.StandardInput.WriteLine("exit");
                if (Wait_milliSeconds == 0) p.WaitForExit();
                else if (Wait_milliSeconds > 0) p.WaitForExit(Wait_milliSeconds);
                p.Close();
            }
            catch
            {
            }
        }
        #endregion


        /// <summary>
        /// 写菜单点击日志 add by wangzhi 2013-06-21
        /// </summary>
        /// <param name="contents"></param>
        /// <param name="systemInfo"></param>
        /// <param name="tag"></param>
        /// <param name="user"></param>
        /// <param name="database"></param>
        public static void SaveSysLog( string contents , SystemInfo systemInfo , MenuTag tag , User user , RelationalDatabase database )
        {
            string ip = PubStaticFun.GetIPAddress();
            string mac = PubStaticFun.GetMacAddress();

            string strInsert = string.Format( "insert into Pub_Menu_ClickLog(SYSTEM_ID,FUNCTION_NAME,EMPLOYE_ID,CONTENT,IP,MAC) values ({0},'{1}',{2},'{3}','{4}','{5}')" ,
                systemInfo.SystemId , tag.Function_Name , user.EmployeeId , contents , ip , mac );
            try
            {
                database.DoCommand( strInsert );
            }
            catch ( Exception error )
            {
                throw error;
            }
        }

        #region public static int GetFirstAvailablePort() 获取一个可用的端口号
        /// <summary>
        /// 获取第一个可用的端口号
        /// </summary>
        /// <returns></returns>
        public static int GetAvailablePortNumber()
        {
            Random rd = new Random();
            while ( true )
            {
                int portNum = rd.Next( 4000 , 5000 );
                if ( PortIsAvailable( portNum ) )
                {
                    return portNum;
                }
            }
            return -1;
        }
        /// <summary>
        /// 获取操作系统已用的端口号
        /// </summary>
        /// <returns></returns>
        private static IList PortIsUsed()
        {
            //获取本地计算机的网络连接和通信统计数据的信息
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            //返回本地计算机上的所有Tcp监听程序
            IPEndPoint[] ipsTCP = ipGlobalProperties.GetActiveTcpListeners();
            //返回本地计算机上的所有UDP监听程序
            IPEndPoint[] ipsUDP = ipGlobalProperties.GetActiveUdpListeners();
            //返回本地计算机上的Internet协议版本4(IPV4 传输控制协议(TCP)连接的信息。
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            IList allPorts = new ArrayList();
            foreach ( IPEndPoint ep in ipsTCP )
                allPorts.Add( ep.Port );
            foreach ( IPEndPoint ep in ipsUDP )
                allPorts.Add( ep.Port );
            foreach ( TcpConnectionInformation conn in tcpConnInfoArray )
                allPorts.Add( conn.LocalEndPoint.Port );
            return allPorts;
        }
        /// <summary>
        /// 检查指定端口是否已用
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        private static bool PortIsAvailable( int port )
        {
            bool isAvailable = true;
            IList portUsed = PortIsUsed();
            foreach ( int p in portUsed )
            {
                if ( p == port )
                {
                    isAvailable = false;
                    break;
                }
            }
            return isAvailable;
        }
        #endregion
    }
}
