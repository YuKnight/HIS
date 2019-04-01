using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using System.Data;
using System.IO;
using Crownwood.Magic.Menus;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.Resources;
using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using TrasenFrame.Classes;
using System.Diagnostics;

namespace TrasenMainWindow
{
    /// <summary>
    /// 系统主窗体
    /// </summary>
    public partial class FrmMdiMainWindow : System.Windows.Forms.Form
    {
        #region 变量的定义区
        // jianqg 2013-5-16 增加不自动更新 UpdateFile,UPDATETYPE,NotUpdate

        //jianqg emr-his 整合暂时注释--  按此 文本查询
        /// <summary>
        /// 改变常量框架类型，并手动修改AssemblyInfo中版本， 自动使用公司或东软的框架 jianqg 2012-8-8 
        /// 2012-12-27 该为属性，使用常量 emr可能取到的值还是原来的公司值
        /// </summary>
        //private TrasenFrame.Classes.FrameKind _FRAMEKIND = FrameKind.公司;
        /// <summary>
        /// jianqg 2012-10月 emr-his框架整合 增加 电子病历菜单，便于进入到电子病历系统，自动打开员电子病历系统
        /// </summary>
        private MenuCommand menu_EmrBussinessHis = null;

        /// <summary>
        /// 流大小
        /// </summary>
        private const int BUFFER_LENGTH = 4096;
        /// <summary>
        /// 升级文件
        /// </summary>
        private const string INIFILENAME = "SYSUPDATE.INI";
        /// <summary>
        /// 标题
        /// </summary>
        private string _caption;
        /// <summary>
        /// 主程序名
        /// </summary>
        private string _maintProgramName;
        /// <summary>
        /// 是否检查注册
        /// </summary>
        private bool _ifCheckRegister;
        /// <summary>
        /// 窗口菜单
        /// </summary>
        private MenuCommand menuWindow;
        /// <summary>
        /// 主菜单
        /// </summary>
        private Crownwood.Magic.Menus.MenuControl mainMenu;
        /// <summary>
        /// 工具按钮拦
        /// </summary>
        private System.Windows.Forms.ToolBar mainToolbar;
        /// <summary>
        /// 系统时间
        /// </summary>
        private DateTime CurrentTime;
        /// <summary>
        /// 消息控制,负责发送消息和监听端口接收消息
        /// </summary>
        //private TrasenMessage.MessageController messageControler;
        /// <summary>
        /// 用于显示接收到的消息的窗体
        /// </summary>
        //private TrasenMessage.DlgImmediatelyMessage dlgMsg; //add by wangzhi 2013-08-01

        private Icon AppIcon = null;
        private Icon AppGrayIcon = null;
        /// <summary>
        /// 是否有新消息
        /// </summary>
        private bool newMsg = false;
        /// <summary>
        /// 消息发送者
        /// </summary>
        private string msgSender = "";
        /// <summary>
        /// 消息内容
        /// </summary>
        private string msgContents = "";
        /// <summary>
        /// 消息显示时间（秒）
        /// </summary>
        private int showTime = 5;
        /// <summary>
        /// 是否已经显示过消息
        /// </summary>
        private bool showMsg = false;

        private ImageList userToolbarList = new ImageList();
        /// <summary>
        /// 用于线程访问锁定用的对象
        /// </summary>
        private static object _objLock = new object(); //add by wangzhi 2013-08-01
        /// <summary>
        /// 是否实时读取系统公告或通知、或实时接收其他工作站的实时消息，对应参数ID = 7
        /// </summary>
        /// <remarks>add by wangzhi 2013-08-01</remarks>
        private int realLoadMessage = Convert.ToInt32(new TrasenFrame.Classes.SystemCfg(0007).Config == "0");
        /// <summary>
        /// 获取系统公告或通知的频率，单位分钟，0则不获取，对应参数ID = 8
        /// </summary>
        private int loadAnnouncementFrequency = Convert.ToInt32(Convertor.IsNull(new TrasenFrame.Classes.SystemCfg(0008).Config, "1"));

        /// <summary>
        /// 是否需要检查验证码
        /// </summary>
        private bool _checkMenuAuth = true;

        private bool _IsDebugVersion = false;

        private System.Diagnostics.Process msgProcess;

        private string _system_menu_id = null;
        #endregion

        /// <summary>
        /// 主界面构造函数
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="maintProgramName">主程序名称</param>
        /// <param name="checkRegister">是否检查软件注册情况</param>
        public FrmMdiMainWindow(string caption, string maintProgramName, bool checkRegister)
        {
            InitializeComponent();
            InitializeFrmMdiMainWindow(caption, maintProgramName, checkRegister, null);
        }

        /// <summary>
        /// 主界面构造函数
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="maintProgramName">主程序名称</param>
        /// <param name="checkRegister">是否检查软件注册情况</param>
        public FrmMdiMainWindow(string caption, string maintProgramName, bool checkRegister, string system_menu_id)
        {
            InitializeComponent();
            InitializeFrmMdiMainWindow(caption, maintProgramName, checkRegister, system_menu_id);
        }

        private void InitializeFrmMdiMainWindow(string caption, string maintProgramName, bool checkRegister, string system_menu_id)
        {
            _system_menu_id = system_menu_id;
            try
            {
                #region 正式版和调试版的设置,将原来编译时修改改为配置ini
                string strDebug = ApiFunction.GetIniString("Enviroment", "IsDebugVersion", Application.StartupPath + "\\ClientConfig.ini");
                if (string.IsNullOrEmpty(strDebug))
                    ApiFunction.WriteIniString("Enviroment", "IsDebugVersion", "false", Application.StartupPath + "\\ClientConfig.ini");
                strDebug = ApiFunction.GetIniString("Enviroment", "IsDebugVersion", Application.StartupPath + "\\ClientConfig.ini");
                try
                {
                    _IsDebugVersion = Convert.ToBoolean(strDebug);
                }
                catch
                {
                    _IsDebugVersion = false;
                }
                #endregion

                #region jianqg 2012-8-8 处理框架图标
                ResourceManager rm = new ResourceManager("TrasenMainWindow.Properties.Resources", typeof(TrasenMainWindow.Properties.Resources).Assembly);
                string appIconName = "App";
                string appGrayIconName = "AppGray";
                switch (TrasenFrame.Forms.FrmMdiMain.FRAMEKIND)
                {
                    case TrasenFrame.Classes.FrameKind.东软:
                        appIconName = "App_dr";
                        appGrayIconName = "AppGray_dr";
                        if (caption.Contains("创星"))
                            caption = "东软医院管理系统";
                        break;
                    case TrasenFrame.Classes.FrameKind.弘麒:
                        appIconName = "App_OnKiy";
                        appGrayIconName = "AppGray_OnKiy";
                        if (caption.Contains("创星"))
                            caption = "弘麒医院管理系统";
                        break;
                }
                AppIcon = (System.Drawing.Icon)rm.GetObject(appIconName);
                AppGrayIcon = (System.Drawing.Icon)rm.GetObject(appGrayIconName);
                this.Icon = AppIcon;
                this.notifyIcon1.Icon = AppIcon;
                #endregion
                for (int i = 0; i < imgToolbar.Images.Count; i++)
                {
                    Image img = imgToolbar.Images[i];
                    userToolbarList.Images.Add(img);
                }
                userToolbarList.ImageSize = new Size(20, 20);
                #region 加入按钮栏
                mainToolbar = new ToolBar();
                mainToolbar.Dock = DockStyle.Top;
                mainToolbar.Appearance = ToolBarAppearance.Flat;
                mainToolbar.TextAlign = ToolBarTextAlign.Right;
                mainToolbar.ImageList = userToolbarList;//this.imgToolbar;

                mainToolbar.ButtonClick += new ToolBarButtonClickEventHandler(mainToolbar_ButtonClick);
                Panel panBtn = new Panel();
                panBtn.Dock = DockStyle.Top;
                this.Controls.Add(panBtn);
                panBtn.Controls.Add(mainToolbar);
                panBtn.Height = mainToolbar.Height;
                #endregion
                #region 加入菜单
                mainMenu = new MenuControl();
                mainMenu.Dock = DockStyle.Top;
                mainMenu.MdiContainer = this;
                this.Controls.Add(mainMenu);
                #endregion
                this.Text = caption;
                _caption = caption;
                _maintProgramName = maintProgramName;
                _ifCheckRegister = checkRegister;

                //Modify By Tany 2012-05-15 0022系统登录时是否无条件弹出科室选择框 0=是1=不是
                if (new TrasenFrame.Classes.SystemCfg(22).Config == "1")
                {
                    TrasenFrame.Forms.FrmMdiMain.CurrentDept = this.InstanceCurrentDept();
                }
                if (TrasenFrame.Forms.FrmMdiMain.CurrentDept == null || TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId <= 0)
                {
                    //如果没有实例化成功，则让用户选择科室后在实例化，同时更新 人员-科室-系统 的关系
                    TrasenFrame.Forms.FrmSelectDept fSelect = new TrasenFrame.Forms.FrmSelectDept(TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId);
                    if (fSelect.ShowDialog(this) == DialogResult.OK)
                    {
                        int selectDept = Convert.ToInt32(fSelect.SelectedDeptId);
                        TrasenFrame.Forms.FrmMdiMain.CurrentDept = new TrasenFrame.Classes.Department(fSelect.SelectedDeptId, TrasenFrame.Forms.FrmMdiMain.Database);

                        string sql = "update jc_emp_dept_role set xtbh=" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId + " where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " and dept_id= " + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
                        TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);

                        LoadUserSystemMenu(TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId);
                        LoadFixedMenu();
                        LoadFixedToolbarButton();

                        this.Text = _caption + "--" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemName;
                    }
                    else
                    {
                        MessageBox.Show("没有选择登录科室，程序将结束运行", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        CloseMessageDectectProcess();
                        Application.Exit();
                    }
                }
                else
                {
                    //选择科室的时候改变操作员的登录科室
                    //Modify By Tany 2009-12-23
                    TrasenFrame.Forms.FrmMdiMain.Database.DoCommand("update pub_user set login_dept = " + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + " where id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID);

                    LoadUserSystemMenu(TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId);
                    LoadFixedMenu();
                    LoadFixedToolbarButton();
                    this.Text = _caption + "--" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemName;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            this.SizeChanged += delegate(object sender, EventArgs e)
            {
                LoadBackgroupPicture();
            };
            this.Activated += delegate(object sender, EventArgs e)
            {
                if (TrasenFrame.Forms.FrmMdiMain.CurrentDept != null)
                    this.sttbpDept.Text = "部门科室：" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
            };
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (!this._IsDebugVersion)
                    base.Text = value;
                else
                    base.Text = value + "--【公司内部开发测试模式】";
            }
        }

        #region 屏幕空闲超时锁定代码  add by wangzhi 2010-11-27
        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            public int size;
            public int lastTick;
        }
        [DllImport("User32")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO lii);
        private int lastActivity = Environment.TickCount;
        private delegate void AfterIdleTimeoutEventHandler();   //定义超出设定的空闲等待时间的事件处理委托
        private event AfterIdleTimeoutEventHandler AfterIdleTimeoutEvent; //定义超出设定的空闲等待时间的事件
        private delegate void PasswordValidateEventHandler();//定义处理弹出密码验证窗口的委托
        private int idleTimeout = 0;
        private Thread thIdle;
        private bool screenLocked = false;
        /// <summary>
        /// 处理在超出空闲等待时间后事件
        /// </summary>
        private void ProcessAfterIdleTimeoutEvent()
        {
            PasswordValidateEventHandler handler = new PasswordValidateEventHandler(ShowPasswordValidate);
            this.Invoke(handler);
        }
        /// <summary>
        /// 检测空闲时间
        /// </summary>
        private void DetectIdleTime()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (screenLocked)
                    return;
                LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
                lastInputInfo.size = 8;

                if (GetLastInputInfo(ref lastInputInfo))
                {
                    lastActivity = Math.Max(lastActivity, lastInputInfo.lastTick);

                    int diff = Environment.TickCount - lastActivity; //计算最后一次鼠标键盘活动到现在的时间间隔
                    if (diff > idleTimeout)
                    {
                        //当前距离最后一次鼠标键盘活动时间间隔大于空闲时间值，
                        //触发超出空闲时间事件
                        AfterIdleTimeoutEvent();
                    }
                }
            }
        }
        /// <summary>
        /// 显示密码窗口，相当于用密码验证窗口锁屏
        /// </summary>
        private void ShowPasswordValidate()
        {
            if (thIdle != null)
            {
                thIdle.Suspend();
                //this.WindowState = FormWindowState.Minimized;
                //if ( this.dlgMsg != null )
                //{
                //    dlgMsg.Clear();
                //    dlgMsg.Hide();
                //}

                TrasenFrame.Forms.FrmLockScreen fLockScreen = new TrasenFrame.Forms.FrmLockScreen(TrasenFrame.Forms.FrmMdiMain.CurrentUser);
                CloseMessageDectectProcess();
                fLockScreen.ShowDialog(this);
                if (fLockScreen.ExitProgrammer)
                {
                    ExitProgrammer();
                    return;
                }
                //DisplayUnDealMessage();
                StartMesssageDectectProcess();

                screenLocked = false;
                thIdle.Resume();
            }
        }
        /// <summary>
        /// 获取开启组的锁屏功能的时间
        /// </summary>
        /// <returns></returns>
        private int GetGroupIdleTimeOut()
        {
            //return 3 * 1000;
            return TrasenFrame.Forms.FrmMdiMain.CurrentSystem.AutoLockTime * 60 * 1000;
        }
        #endregion

        #region 加载背景图
        private void LoadBackgroupPicture()
        {
            Image image = null;
            image = (new TrasenFrame.Classes.AppEnvironment()).GetBackgroundImage(TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode);

            if (image != null)
            {
                Image imageBk = image.GetThumbnailImage(this.Width, this.Height, (new Image.GetThumbnailImageAbort(delegate()
                {
                    return false;
                })), IntPtr.Zero);
                this.BackgroundImage = imageBk;
            }
            else
                this.BackgroundImage = null;
        }
        #endregion

        #region 静态方法:入口函数StartupMain，子窗体处理函数等
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="connectionType"></param>
        /// <param name="connectionString"></param>
        /// <param name="maintProgramName"></param>
        /// <param name="checkRegister"></param>
        public static void StartupMain(string caption, TrasenFrame.Classes.ConnectionType connectionType, string connectionString,
            string maintProgramName, bool checkRegister)
        {
            WriteFrameLocalLog(new string[] { "Begin Invoke “StartupMain(string,TrasenFrame.Classs.ConnectionType,string,bool,bool)”" }, true);
            StartupMain(caption, connectionType, connectionString, maintProgramName, checkRegister, false);
        }

        public static void StartupMain(string caption, TrasenFrame.Classes.ConnectionType connectionType, string connectionString,
            string maintProgramName, bool checkRegister, bool IsFormUpdate)
        {
            StartupMain(caption, connectionType, connectionString, maintProgramName, checkRegister, IsFormUpdate, null);
        }
        /// <summary>
        /// 系统启动
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="connectionType">连接类别</param>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="maintProgramName">主程序名称</param>
        /// <param name="checkRegister">是否检查软件注册情况</param>
        /// <param name="checkRegister">是否是由updateexe启动</param>
        public static void StartupMain(string caption, TrasenFrame.Classes.ConnectionType connectionType, string connectionString,
            string maintProgramName, bool checkRegister, bool IsFormUpdate, string LogingCode)
        {
            StartupMain(caption, connectionType, connectionString, maintProgramName, checkRegister, IsFormUpdate, LogingCode, null);
        }
        /// <summary>
        /// 系统启动
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="connectionType">连接类别</param>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="maintProgramName">主程序名称</param>
        /// <param name="checkRegister">是否检查软件注册情况</param>
        /// <param name="checkRegister">是否是由updateexe启动</param>
        public static void StartupMain(string caption, TrasenFrame.Classes.ConnectionType connectionType, string connectionString,
            string maintProgramName, bool checkRegister, bool IsFormUpdate, string LogingCode, string system_menu_id)
        {
            try
            {
                switch (TrasenFrame.Forms.FrmMdiMain.FRAMEKIND)
                {
                    case TrasenFrame.Classes.FrameKind.东软:
                        caption = "东软医院管理系统";
                        break;
                    case TrasenFrame.Classes.FrameKind.弘麒:
                        caption = "弘麒医院管理系统";
                        break;
                }


                //连接数据库
                if (TrasenFrame.Classes.Constant.IsSelectConnect)
                {
                    TrasenFrame.Forms.FrmSelectConnect frmSelectConnect = new TrasenFrame.Forms.FrmSelectConnect(connectionType);
                    frmSelectConnect.ShowDialog();

                    if (frmSelectConnect.ServerName.Trim() != "")
                    {
                        connectionString = TrasenFrame.Classes.WorkStaticFun.GetConnnectionString(connectionType, frmSelectConnect.ServerName);
                    }
                }
                switch (connectionType)
                {
                    case TrasenFrame.Classes.ConnectionType.SQLSERVER:
                        TrasenFrame.Forms.FrmMdiMain.Database = new MsSqlServer();
                        TrasenFrame.Forms.FrmMdiMain.Database_Lis = new MsSqlServer();
                        TrasenFrame.Forms.FrmMdiMain.Database_Pacs = new MsSqlServer();
                        break;
                    case TrasenFrame.Classes.ConnectionType.IBMDB2:
                        TrasenFrame.Forms.FrmMdiMain.Database = new IbmDb2();
                        TrasenFrame.Forms.FrmMdiMain.Database_Lis = new IbmDb2();
                        TrasenFrame.Forms.FrmMdiMain.Database_Pacs = new IbmDb2();
                        break;
                    case TrasenFrame.Classes.ConnectionType.MSACCESS:
                        TrasenFrame.Forms.FrmMdiMain.Database = new MsAccess();
                        TrasenFrame.Forms.FrmMdiMain.Database_Lis = new MsAccess();
                        TrasenFrame.Forms.FrmMdiMain.Database_Pacs = new MsAccess();
                        break;
                    case TrasenFrame.Classes.ConnectionType.ORACLE:
                        TrasenFrame.Forms.FrmMdiMain.Database = new Oracle();
                        TrasenFrame.Forms.FrmMdiMain.Database_Lis = new Oracle();
                        TrasenFrame.Forms.FrmMdiMain.Database_Pacs = new Oracle();
                        break;
                    default:
                        break;
                }
                if (TrasenFrame.Forms.FrmMdiMain.Database != null)
                {

                    //初始化数据库连接
                    TrasenFrame.Forms.FrmMdiMain.Database.Initialize(connectionString);
                    WriteFrameLocalLog(new string[] { "Initialize Database Connection Object (TrasenFrame.Forms.FrmMdiMain.Database.Initialize( connectionString ))" }, true);
                    //Add By Tany 2009-3-31 增加LIS和PACS的连接
                    bool _lis = false;
                    bool _pacs = false;
                    string sqlType = "";
                    switch (connectionType)
                    {
                        case TrasenFrame.Classes.ConnectionType.SQLSERVER:
                            sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("SQLSERVERTYPE", "TYPE", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                            break;
                        case TrasenFrame.Classes.ConnectionType.IBMDB2:
                            sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("IBMDB2TYPE", "TYPE", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                            break;
                        case TrasenFrame.Classes.ConnectionType.MSACCESS:
                            sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("MSACCESSTYPE", "TYPE", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                            break;
                        case TrasenFrame.Classes.ConnectionType.ORACLE:
                            sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("ORACLETYPE", "TYPE", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                            break;
                        default:
                            break;
                    }
                    string[] type = sqlType.Split('|');
                    if (type.Length > 0)
                    {
                        for (int i = 0; i < type.Length && type[i].Trim() != ""; i++)
                        {
                            if (type[i].Trim().ToUpper() == "LIS")
                            {
                                _lis = true;
                                continue;
                            }
                            if (type[i].Trim().ToUpper() == "PACS")
                            {
                                _pacs = true;
                                continue;
                            }
                        }
                    }
                    if (_lis)
                    {
                        //实例化LIS服务器链接
                        try
                        {
                            string connectionString_lis = TrasenFrame.Classes.WorkStaticFun.GetConnnectionString(connectionType, "LIS");
                            if (connectionString_lis.Trim() != "")
                                TrasenFrame.Forms.FrmMdiMain.Database_Lis.Initialize(connectionString_lis);
                        }
                        catch (System.Exception err)
                        {
                            MessageBox.Show("您在数据库配置中设置了LIS服务器，但连接数据库时不成功。请检查！", "连接数据库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (_pacs)
                    {
                        //实例化PACS服务器链接
                        try
                        {
                            string connectionString_pacs = TrasenFrame.Classes.WorkStaticFun.GetConnnectionString(connectionType, "PACS");
                            if (connectionString_pacs.Trim() != "")
                                TrasenFrame.Forms.FrmMdiMain.Database_Pacs.Initialize(connectionString_pacs);
                        }
                        catch (System.Exception err)
                        {
                            MessageBox.Show("您在数据库配置中设置了PACS服务器，但连接数据库时不成功。请检查！", "连接数据库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (ProcessSysUpdate(IsFormUpdate) == true)
                    {
                        //如果升级标志true则有文件需要升级，启动升级文件
                        string path = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\SysUpdateEx.exe";

                        if (System.IO.File.Exists(path))
                        {
                            if (string.IsNullOrEmpty(LogingCode))
                            {
                                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog(new string[] { "正在启动升级程序" + path }, true);
                                System.Diagnostics.Process.Start(path);
                            }
                            else
                            {
                                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog(new string[] { "正在启动升级程序" + path + " " + "SSO" }, true);
                                Process proc = new Process();
                                proc.StartInfo = new ProcessStartInfo(path);
                                proc.StartInfo.Arguments = "SSO";
                                proc.Start();
                                //System.Diagnostics.Process.Start( path + " " + "SSO" );
                            }
                            return;
                        }
                        else
                        {
                            MessageBox.Show("升级文件" + path + "丢失,建议联系管理员以获取最新的程序", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }



                    //读取机构编码
                    TrasenFrame.Forms.FrmMdiMain.Jgbm = Convert.ToInt32((TrasenFrame.Forms.FrmMdiMain.GetJgbmmc())[0]);
                    TrasenFrame.Forms.FrmMdiMain.Jgmc = (TrasenFrame.Forms.FrmMdiMain.GetJgbmmc())[1].ToString().Trim();
                    TrasenFrame.Forms.FrmMdiMain.JgYybm = Convert.ToInt32((TrasenFrame.Forms.FrmMdiMain.GetJgbmmc())[2]);
                    TrasenFrame.Forms.FrmMdiMain.JgServerIpaddr = (TrasenFrame.Forms.FrmMdiMain.GetJgbmmc())[3].ToString().Trim();

                    //读取中心机构编码
                    TrasenFrame.Forms.FrmMdiMain.ZxJgbm = Convert.ToInt32((TrasenFrame.Forms.FrmMdiMain.GetZxJgbmmc())[0]);
                    TrasenFrame.Forms.FrmMdiMain.ZxJgmc = (TrasenFrame.Forms.FrmMdiMain.GetZxJgbmmc())[1].ToString().Trim();
                    //给当前程序分配一个可用的端口号
                    TrasenFrame.Forms.FrmMdiMain.PortNum = TrasenFrame.Classes.WorkStaticFun.GetAvailablePortNumber();



                    if (string.IsNullOrEmpty(LogingCode))
                    {
                        #region 正常登陆,系统登录
                        DlgLogin dlglogin = new DlgLogin();
                        dlglogin.BringToFront();
                        dlglogin.ShowDialog();

                        if (dlglogin.LoginSuccess)
                        {
                            TrasenFrame.Forms.FrmMdiMain.CurrentUser = dlglogin.CurrentUser;
                            TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new TrasenFrame.Classes.SystemInfo(dlglogin.CurrentSystem, TrasenFrame.Forms.FrmMdiMain.Database);
                            //启动主界面
                            Application.Run(new FrmMdiMainWindow(caption, maintProgramName, checkRegister));
                        }
                        else
                        {
                            if (TrasenFrame.Forms.FrmMdiMain.Database_Lis != null)
                            {
                                TrasenFrame.Forms.FrmMdiMain.Database_Lis.Close();
                                //Database_Lis.Dispose();
                            }
                            if (TrasenFrame.Forms.FrmMdiMain.Database_Pacs != null)
                            {
                                TrasenFrame.Forms.FrmMdiMain.Database_Pacs.Close();
                                //Database_Pacs.Dispose();
                            }
                            TrasenFrame.Forms.FrmMdiMain.Database.Close();
                            TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                            Application.Exit();
                        }
                        #endregion
                    }
                    else
                    {
                        #region 由门户登陆
                        TrasenFrame.Forms.FrmMdiMain.CurrentUser = new User(LogingCode, TrasenFrame.Forms.FrmMdiMain.Database);
                        DataTable dtSystem = TrasenFrame.Forms.FrmMdiMain.CurrentUser.GetSystemInfo();
                        if (dtSystem.Rows.Count >= 1)
                            TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new SystemInfo(Convert.ToInt32(dtSystem.Rows[0]["System_ID"]), TrasenFrame.Forms.FrmMdiMain.Database);
                        else
                            TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new SystemInfo();
                        TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog(new string[] { "正在由门户启动主界面.." }, true);
                        //启动主界面
                        Application.Run(new FrmMdiMainWindow(caption, maintProgramName, checkRegister, system_menu_id));
                        #endregion
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接失败，停止运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                if (TrasenFrame.Forms.FrmMdiMain.Database_Lis != null)
                {
                    TrasenFrame.Forms.FrmMdiMain.Database_Lis.Close();
                    TrasenFrame.Forms.FrmMdiMain.Database_Lis = null;
                }
                if (TrasenFrame.Forms.FrmMdiMain.Database_Pacs != null)
                {
                    TrasenFrame.Forms.FrmMdiMain.Database_Pacs.Close();
                    TrasenFrame.Forms.FrmMdiMain.Database_Pacs = null;
                }
                if (TrasenFrame.Forms.FrmMdiMain.Database != null)
                {
                    if (TrasenFrame.Forms.FrmMdiMain.Database.ConnectionStates == ConnectionState.Open && TrasenFrame.Forms.FrmMdiMain.CurrentUser != null)
                    {
                        //Modify By Tany 2009-12-02 增加登陆状态的记录
                        //TrasenFrame.Forms.FrmMdiMain.Database.DoCommand( "update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null where id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID );
                        TrasenFrame.Forms.FrmMdiMain.CurrentUser.Loginout();
                    }
                    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                    TrasenFrame.Forms.FrmMdiMain.Database = null;
                    Application.Exit();
                }
            }
        }


        /// <summary>
        /// 判断Mdi子窗体是否已经打开
        /// </summary>
        /// <param name="mdiForm">MDI父窗体</param>
        /// <param name="formText">MDI子窗体名称</param>
        /// <returns></returns>
        public static bool MdiChildFormIsExist(Form mdiForm, string formText)
        {
            bool blResult = false;
            int m = mdiForm.MdiChildren.Length;
            for (int i = 0; i < m; i++)
            {
                if (mdiForm.MdiChildren[i].Text == formText)
                {
                    mdiForm.MdiChildren[i].Activate();
                    blResult = true;
                    break;
                }
            }
            return blResult;
        }
        /// <summary>
        /// 判断Mdi子窗体是否已经打开
        /// </summary>
        /// <param name="mdiForm">MDI父窗体</param>
        /// <param name="formText">MDI子窗体名称</param>
        /// <param name="childForm">子窗体对象</param>
        /// <returns></returns>
        public static bool MdiChildFormIsExist(Form mdiForm, string formText, ref Form childForm)
        {
            bool blResult = false;
            int m = mdiForm.MdiChildren.Length;
            for (int i = 0; i < m; i++)
            {
                if (mdiForm.MdiChildren[i].Text == formText)
                {
                    mdiForm.MdiChildren[i].Activate();
                    blResult = true;
                    childForm = mdiForm.MdiChildren[i];
                    break;
                }
            }
            return blResult;
        }
        /// <summary>
        /// 关闭指定MDI子窗体
        /// </summary>
        /// <param name="mdiForm">MDI父窗体</param>
        /// <param name="formText">MDI子窗体名称</param>
        /// <returns></returns>
        public static void CloseMdiChildForm(Form mdiForm, string formText)
        {
            int m = mdiForm.MdiChildren.Length;
            if (m == 0)
                return;
            for (int i = 0; i < m; i++)
            {
                if (mdiForm.MdiChildren[i].Text == formText)
                {
                    mdiForm.MdiChildren[i].Close();
                    i -= 1;
                    m -= 1;
                }
            }
        }
        #endregion

        #region 处理更新程序的更新 add by wangzhi 2011-02-15
        /// <summary>
        /// 创建XML文件
        /// </summary>
        public static void CreateUpdateInfoFile(string sFile)
        {
            FileStream fs = new FileStream(sFile, FileMode.Create);
            fs.Close();
            DirectoryInfo dir = new DirectoryInfo(TrasenFrame.Classes.Constant.ApplicationDirectory);
            FileInfo[] files = dir.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                string fileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(files[i].FullName).FileVersion;
                fileVersion = files[i].LastWriteTime.ToString("yyyyMMddHHmmss");
                ApiFunction.WriteIniString("FILEINFO", files[i].Name, fileVersion, TrasenFrame.Classes.Constant.ApplicationDirectory + "\\UpdateFile.ini");
            }

        }
        /// <summary>
        /// 处理升级文件的更新
        /// </summary>
        /// <returns></returns>
        private static bool ProcessSysUpdate(bool IsFormUpdate)
        {
            //2013-7-3 jianqg 发现 不能部分机器不能下载文件 特注释 f.Show();f.Refresh();f.Close();
            WriteFrameLocalLog((new string[] { "Start Check Update File" }), true);
            //Frmflash f = new Frmflash();
            try
            {
                bool update = false;
                string updateFile = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\UpdateFile.ini";
                if (!File.Exists(updateFile))
                {
                    CreateUpdateInfoFile(updateFile);
                    WriteFrameLocalLog((new string[] { "Created UpdateFile.ini File" }), true);
                }

                //如果升级用的exe程序有新版本，由框架下载该exe
                if (HasNewVersionOfUpdateEXE())
                {
                    WriteFrameLocalLog((new string[] { "Detected New Version Of File : SystemUpdateEx.exe,Ready To Download" }), true);
                    DownLoadUpdateProgrammer();
                    WriteFrameLocalLog((new string[] { "SystemUpdateEx.exe Download Finished" }), true);
                }
                // jianqg 2013-5-16 增加不自动更新 UpdateFile,UPDATETYPE,NotUpdate
                string notUpdate = ApiFunction.GetIniString("UPDATETYPE", "NotUpdate", updateFile);
                if (notUpdate.Trim().ToLower() == "true")
                {
                    WriteFrameLocalLog((new string[] { "UpdateFile.ini->[UPDATETYPE]->NotUpdate=true,Stop Update and Return to Main Program" }), true);
                    return false;
                }

                if (IsFormUpdate)
                {
                    //如果是由Update启动的,则不需要再进行更新检查 wangzhi 2013-06-19
                    WriteFrameLocalLog((new string[] { "IsFromUpdate = true,return false" }), true);
                    return false;
                }

                //获取升级文件(不包括升级程序的执行文件)
                DataTable tableNewFile = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(@"select name,Version,download_folder from pub_systemupdate 
                                                                                                where name not in ('SystemUpdate.exe','SysUpdate.exe','SysUpdateEx.exe') and delete_bit=0");
                string fileName = "";
                string[] fileVersion = new string[2];

                for (int i = 0; i < tableNewFile.Rows.Count; i++)
                {
                    fileName = tableNewFile.Rows[i]["name"].ToString();

                    //add by wangzhi 2012-03-01
                    string path = Convertor.IsNull(tableNewFile.Rows[i]["download_folder"].ToString(), "").Trim();
                    if (string.IsNullOrEmpty(path))
                        path = "";// "..";
                    if (path == "..")
                        path = "";

                    string fullFilename = path + "\\" + fileName;
                    if (path == "")
                        fullFilename = fileName;
                    //end add

                    //服务器版本号
                    fileVersion[0] = tableNewFile.Rows[i]["Version"].ToString().Trim();
                    //本地版本号
                    fileVersion[1] = ApiFunction.GetIniString("FILEINFO", /*fileName*/ fullFilename, TrasenFrame.Classes.Constant.ApplicationDirectory + "\\UpdateFile.ini");
                    if (fileName.ToLower() == "trasenframe.dll")
                    {
                        WriteFrameLocalLog((new string[] { "TrasenFrame Version:Server[" + fileVersion[0] + "  Local:[" + fileVersion[1] + "]" }), true);
                    }
                    if (fileVersion[0].Trim() != fileVersion[1].Trim())
                    {
                        update = true;//有新版本的文件要更新
                        break;
                    }
                }
                WriteFrameLocalLog((new string[] { "update=" + update.ToString() }), true);
                return update;

            }
            catch (FileNotFoundException fnfe)
            {
                MessageBox.Show(fnfe.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception err)
            {
                MessageBox.Show("主程序更新升级程序文件发生错误：" + err.Message + "\r\n" + err.StackTrace + "\r\n" + err.GetType().ToString() + "请将此信息反馈给系统管理员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            finally
            {
                //f.Close();
            }
        }
        /// <summary>
        /// 下载升级程序的执行文件
        /// </summary>
        /// <remarks>先将升级文件下载到特定目录，然后从特定目录Copy到运行目录</remarks>
        private static void DownLoadUpdateProgrammer()
        {
            //如果要升级的文件是更新程序，kill掉所有升级程序的进程

            #region wangzhi 注释 2013-06-19.改下面的代码杀进程
            //System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("SysUpdateEx");
            //while (ps.Length > 0)
            //{
            //    for (int idx = 0; idx < ps.Length; idx++)
            //    {
            //        if (!ps[idx].HasExited)
            //            ps[idx].Kill();
            //        ps[idx].Close();
            //        ps[idx].Dispose();
            //    }
            //    ps = System.Diagnostics.Process.GetProcessesByName("SysUpdateEx");
            //}
            #endregion

            #region 获取当前所有进程中在运行的UPDATE进程ID
            System.Diagnostics.Process[] proces = System.Diagnostics.Process.GetProcesses();//获取所有进程
            System.Collections.Generic.List<int> lstPID = new System.Collections.Generic.List<int>(); //定义UpdateEx.exe的进程列表
            foreach (System.Diagnostics.Process p in proces)
            {
                //遍历当前所有进程，为防止改名，判断原始文件名，只要是SysUpdateEx，就添加到列表
                string originalFilename = "";
                try
                {
                    originalFilename = p.MainModule.FileVersionInfo.OriginalFilename.ToUpper();//转为大写
                }
                catch (Exception error)
                {
                    //访问系统进程模块等的错误忽略
                    continue;
                }
                if (!string.IsNullOrEmpty(originalFilename) && originalFilename == "SYSUPDATEEX.EXE")
                    lstPID.Add(p.Id);
            }
            #endregion

            #region 循环结束Update的进程
            foreach (int pid in lstPID)
            {
                #region 使用Process类结束进程
                System.Diagnostics.Process p = null;
                try
                {
                    #region 尝试获取指定ID的进程,如果获取不到，继续下一个进程ID
                    try
                    {
                        //第一次开始查找进程ID
                        p = System.Diagnostics.Process.GetProcessById(pid);
                    }
                    catch (ArgumentException e0)
                    {
                        continue;
                    }
                    #endregion
                    int count = 1;    //定义尝试次数
                    int maxCount = 3; //定义最大尝试次数
                    //如果找到进程，进入循环尝试结束进程，次数为maxCount指定
                    #region 循环尝试结束Update.exe进程
                    while (count <= maxCount)
                    {
                        WriteFrameLocalLog(new string[] { string.Format("Try To Terminate Process[ID:{1}] for {0} Times", count, pid) }, true);
                        p.Kill();
                        p.WaitForExit();

                        #region 尝试重新获取进程，看是否被结束,如果结束，跳出while循环
                        try
                        {
                            //重新根据ID获取进程
                            p = System.Diagnostics.Process.GetProcessById(pid);
                        }
                        catch
                        {
                            //如果发生ArgementException,说明进程已经结束,跳出while循环
                            WriteFrameLocalLog(new string[] { string.Format("Process[ID:{1}] Has Terminated", pid) } , true);
                            break;
                        }
                        #endregion

                        #region 如果没有被结束，继续循环Kill，直到达到指定的尝试次数
                        if (count == maxCount)
                        {
                            //如果尝试次数到达限定次数，跳出循环
                            WriteFrameLocalLog(new string[] { string.Format("Try To Terminate Process[ID:{1}] least than {1} Times", maxCount, pid) }, true);
                            MessageBox.Show(string.Format("尝试结束SysUpdateEx.exe进程({0})已达三次，请手工处理", pid));
                            break;
                        }
                        else
                        {
                            //重新根据ID获取进程的操作如果成功，则进行下一次循环来结束进程
                            count++;
                        }
                        #endregion
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    WriteFrameLocalLog(new string[] { string.Format("Catched a Exception at terminate process[ID:{0}],Error Message:{1}", pid, error.Message) }, true);
                }
                #endregion
            }
            #endregion

            #region 检测Update.exe的进程是否还有残留,如果还有，不进行下载
            foreach (int pid in lstPID)
            {
                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(pid);
                    MessageBox.Show("程序无法结束SystemUpdateEx.exe,不能下载新的SystemUpdateEx.exe", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; //退出下载处理
                }
                catch
                {
                    continue;
                }
            }
            #endregion

            WriteFrameLocalLog((new string[] { "Ready from Update File:SystemUpdateEx.exe" }), true);
            string iniFile = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\UpdateFile.ini";
            DataRow drNewUpdateFile = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow("select name,Version,file_value from pub_systemupdate where name in ('SystemUpdate.exe','SysUpdate.exe','SysUpdateEx.exe') and delete_bit=0");
            Object obj = drNewUpdateFile["file_value"];//升级程序的文件内容
            string fileName = drNewUpdateFile["name"].ToString().Trim();//升级程序文件名
            string serverVersion = drNewUpdateFile["Version"].ToString().Trim();//升级程序版本名

            string fullFileName = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\" + fileName;

            if (obj != null && !Convert.IsDBNull(obj))
            {
                if (File.Exists(fullFileName))
                {
                    //删除原文件
                    File.Delete(fullFileName);
                    WriteFrameLocalLog((new string[] { string.Format("Delete Old File:{0}", fullFileName) }), true);
                }
                #region 把二进制数据转为文件
                using (FileStream fw = new FileStream(fullFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    WriteFrameLocalLog((new string[] { string.Format("Write content to File : {0}", fullFileName) }), true);
                    byte[] buffer = (byte[])obj;
                    int fileLength = (int)buffer.Length / BUFFER_LENGTH;
                    if (fileLength * BUFFER_LENGTH < buffer.Length)
                    {
                        fileLength++;
                    }

                    for (int j = 0; j < fileLength; j++)	//以长度为BUFFER_LENGTH字节的块进行传送
                    {
                        if (buffer.Length - j * BUFFER_LENGTH >= BUFFER_LENGTH)
                        {
                            fw.Write(buffer, j * BUFFER_LENGTH, BUFFER_LENGTH);
                        }
                        else
                        {
                            fw.Write(buffer, j * BUFFER_LENGTH, buffer.Length - j * BUFFER_LENGTH);
                        }
                        fw.Seek(0, SeekOrigin.End);
                    }
                    fw.Close();
                    fw.Dispose();
                }
                #endregion

                //将文件名及服务器版本号写入到本地的ini中
                ApiFunction.WriteIniString("FILEINFO", fileName, serverVersion, iniFile);
                WriteFrameLocalLog((new string[] { string.Format("SystemUpdateEx.exe Update Successfully，Version:{0}", serverVersion) }), true);
            }
        }
        /// <summary>
        /// 判断是否有新版本的更新程序
        /// </summary>
        /// <returns></returns>
        private static bool HasNewVersionOfUpdateEXE()
        {
            string iniFile = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\UpdateFile.ini";
            DataRow drUpdateFile = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow("select name,Version,file_value from pub_systemupdate where name in ('SystemUpdate.exe','SysUpdate.exe','SysUpdateEx.exe') and delete_bit=0");
            if (drUpdateFile == null)
                return false;
            Object obj = drUpdateFile["file_value"];//升级程序的文件内容
            string fileName = drUpdateFile["name"].ToString().Trim();//升级程序文件名
            string serverVersion = drUpdateFile["Version"].ToString().Trim();//升级程序的服务器版本
            //升级程序的本地版本号
            string localVersion = ApiFunction.GetIniString("FILEINFO", fileName, iniFile);
            if (serverVersion.Trim().ToUpper() != localVersion.Trim().ToUpper())
                return true;
            else
                return false;
        }
        /// <summary>
        /// 写本地的框架日志方法 add by wangzhi 2013-06-21
        /// </summary>
        /// <param name="content"></param>
        /// <param name="showTime"></param>
        /// <param name="type">0:升级日志 1:运行日志</param>
        public static void WriteFrameLocalLog(string[] content, bool showTime)
        {
            try
            {
                string path = string.Format("{0}\\AppLog", System.Windows.Forms.Application.StartupPath);
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);

                string fileName = DateTime.Now.ToString("yyyyMMdd") + ".log";
                string logFile = string.Format("{0}\\{1}", path, fileName);

                string strTime = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]";
                if (!showTime)
                    strTime = "";

                if (!System.IO.File.Exists(logFile))
                {
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(logFile))
                    {
                        sw.WriteLine(string.Format("{0}Trasen.exe Created Log File", strTime));
                        sw.Flush();
                        sw.Close();
                    }
                }

                for (int i = 0; i < content.Length; i++)
                {
                    using (System.IO.StreamWriter sw = System.IO.File.AppendText(logFile))
                    {
                        if (i == 0)
                        {
                            sw.WriteLine(strTime + content[i]);
                        }
                        else
                        {
                            if (strTime != "")
                            {
                                sw.WriteLine("                     " + content[i]);
                            }
                            else
                            {
                                sw.WriteLine(content[i]);
                            }
                        }
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch
            {

            }
        }
        #endregion

        #region  根据当前用户和系统实例化科室
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private TrasenFrame.Classes.Department InstanceCurrentDept()
        {
            string sql = "select dept_id as ksbh from jc_emp_dept_role where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " and  xtbh = " + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId + " and dept_id in (select dept_id from jc_dept_property where jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + ")";//Modify By tany 2010-04-01 读取默认科室的时候判断一下该科室不是当前机构编码下的科室
            //string sql = "select dept_id as ksbh from jc_emp_dept_role where employee_id=" + CurrentUser.EmployeeId + " and  [default] = 1";
            DataRow dr = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow(sql);
            if (dr == null)
            {
                return null;
            }
            else
            {
                try
                {
                    return new TrasenFrame.Classes.Department(Convert.ToInt32(dr["ksbh"]), TrasenFrame.Forms.FrmMdiMain.Database);
                }
                catch
                {
                    return null;
                }
            }
        }
        #endregion

        #region 主界面的菜单加载、菜单事件的处理以及 工具栏的加载及点击事件的处理

        #region 菜单[系统]
        private void mnuSRelogin_Click(object sender, System.EventArgs e)
        {
            //重新登录记录老的用户ID,用于注销登录 Modify by Tany 2009-12-02
            long _oldUserId = TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID;

            //系统登录
            DlgLogin dlglogin = new DlgLogin();
            dlglogin.ShowDialog();
            if (dlglogin.LoginSuccess)
            {
                if (_oldUserId != dlglogin.CurrentUser.UserID)
                {
                    //TrasenFrame.Forms.FrmMdiMain.Database.DoCommand( "update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null where id=" + _oldUserId );
                    TrasenFrame.Classes.User.ClearOnlineStatus(_oldUserId, 0, "", TrasenFrame.Forms.FrmMdiMain.Database);
                }
                try
                {
                    foreach (Form frm in this.MdiChildren)
                    {
                        frm.Close();
                    }

                }
                catch
                {
                }

                TrasenFrame.Forms.FrmMdiMain.CurrentUser = dlglogin.CurrentUser;
                TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new TrasenFrame.Classes.SystemInfo(dlglogin.CurrentSystem, TrasenFrame.Forms.FrmMdiMain.Database);
                //工具栏
                sttbpUnit.Text = "用户单位：" + TrasenFrame.Classes.WorkStaticFun.GetConfigValueByCode(0002, TrasenFrame.Forms.FrmMdiMain.Database) + "【" + TrasenFrame.Forms.FrmMdiMain.Jgbm + "：" + TrasenFrame.Forms.FrmMdiMain.Jgmc + "】";
                sttbpUser.Text = "操作员：" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;
                //根据当前用户和选择的系统查找科室
                string sql = "select dept_id as ksbh from jc_emp_dept_role where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " and xtbh =" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId;
                DataRow dr = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow(sql);
                if (!TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator)
                {
                    if (dr != null)
                    {
                        TrasenFrame.Forms.FrmMdiMain.CurrentDept = new TrasenFrame.Classes.Department(Convert.ToInt32(dr["ksbh"]), TrasenFrame.Forms.FrmMdiMain.Database);
                        sttbpDept.Text = "部门科室：" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
                    }
                    else
                    {
                        TrasenFrame.Forms.FrmSelectDept fSelectDept = new TrasenFrame.Forms.FrmSelectDept(TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId);
                        DialogResult dlg = fSelectDept.ShowDialog();
                        if (dlg != DialogResult.OK)
                        {
                            MessageBox.Show("没有选择科室,程序关闭!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            CloseMessageDectectProcess();
                            Application.Exit();
                        }
                        else
                        {
                            TrasenFrame.Forms.FrmMdiMain.CurrentDept = new TrasenFrame.Classes.Department(fSelectDept.SelectedDeptId, TrasenFrame.Forms.FrmMdiMain.Database);
                            sttbpDept.Text = "部门科室：" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
                        }
                    }
                }

                LoadBackgroupPicture();

                this.mainMenu.MenuCommands.Clear();
                this.mainToolbar.Buttons.Clear();
                //加载系统菜单
                LoadUserSystemMenu(TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId);
                //加载固定部分菜单
                LoadFixedMenu();
                LoadFixedToolbarButton();

                this.Text = _caption + "--" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemName;

                ShowMessage(0);
                //if ( this.dlgMsg != null )
                //{
                //    dlgMsg.Clear();
                //    dlgMsg.Hide();
                //}
                //DisplayUnDealMessage();
                CloseMessageDectectProcess();
                StartMesssageDectectProcess();
            }
        }

        private void mnuUpLoad_Click(object sender, System.EventArgs e)
        {
            TrasenFrame.Forms.FrmFileUpLoad frmFileUpLoad = new TrasenFrame.Forms.FrmFileUpLoad(true);
            if (!MdiChildFormIsExist(this, frmFileUpLoad.Text))
            {
                frmFileUpLoad.MdiParent = this;
                frmFileUpLoad.Show();
            }

        }

        private void mnuUpLoadBD_Click(object sender, System.EventArgs e)
        {
            TrasenFrame.Forms.FrmFileUpLoad frmFileUpLoad = new TrasenFrame.Forms.FrmFileUpLoad(false);
            if (!MdiChildFormIsExist(this, frmFileUpLoad.Text))
            {
                frmFileUpLoad.MdiParent = this;
                frmFileUpLoad.Show();
            }

        }

        private void menuSwitch_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                if (MessageBox.Show("更改科室会关闭当前所有子窗口，确定更改？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Form frm in this.MdiChildren)
                    {
                        frm.Close();
                        frm.Dispose();
                    }
                }
                else
                {
                    return;
                }
            }
            TrasenFrame.Forms.FrmSelectDept fSelect = new TrasenFrame.Forms.FrmSelectDept(TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId);

            if (fSelect.ShowDialog() == DialogResult.OK && fSelect.SelectedDeptId != TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId)
            {
                TrasenFrame.Forms.FrmMdiMain.CurrentDept = new TrasenFrame.Classes.Department(fSelect.SelectedDeptId, TrasenFrame.Forms.FrmMdiMain.Database);

                sttbpDept.Text = "部门科室：" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;

                this.mainMenu.MenuCommands.Clear();
                this.mainToolbar.Buttons.Clear();
                //根据选择的科室与当前用户，查找对应的系统，重新加载菜单
                string sql = "select xtbh from jc_emp_dept_role where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " and dept_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
                DataRow dr = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow(sql);
                if (dr != null)
                {
                    TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new TrasenFrame.Classes.SystemInfo(Convert.ToInt32(dr["xtbh"]), TrasenFrame.Forms.FrmMdiMain.Database);
                    if (TrasenFrame.Forms.FrmMdiMain.CurrentSystem != null)
                    {
                        //重新加载菜单
                        LoadUserSystemMenu(TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId);
                    }
                    else
                    {
                        //无对应的系统
                        DataTable tableSys = TrasenFrame.Forms.FrmMdiMain.CurrentUser.GetSystemInfo();
                    }
                }

                LoadFixedMenu();
                LoadFixedToolbarButton();

                //if ( this.dlgMsg != null )
                //{
                //    dlgMsg.Clear();
                //    dlgMsg.Hide();
                //}
                //DisplayUnDealMessage();
                CloseMessageDectectProcess();
                StartMesssageDectectProcess();
            }
        }

        private void mnuSysSetting_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Text == ((MenuCommand)sender).Text)
                {
                    f.Activate();
                    return;
                }
            }
            FrmSystemSet fSystemset = new FrmSystemSet();
            fSystemset.MdiParent = this;
            fSystemset.Show();
        }
        /// <summary>
        /// jianqg 2012-7-3 增加 菜单查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSysSearch_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Text == ((MenuCommand)sender).Text)
                {
                    f.Activate();
                    return;
                }
            }


            try
            {
                //调用ts_jc_cdcx.dll
                string dllName = "ts_jc_cdcx.dll";
                string strNameSpace = "ts_jc_cdcx";
                string className = "frmMain";
                MenuCommand menuCmd = sender as MenuCommand;
                if (menuCmd == null)
                    return;
                if (menuCmd.Text.Contains("自动升级SQL脚本"))
                {
                    dllName = "ts_autosql.dll";
                    strNameSpace = "ts_autosql";
                    className = "FrmPath";
                }

                string fullPath = Application.StartupPath + "\\" + dllName;
                if (System.IO.File.Exists(fullPath))
                {
                    Assembly assembly = Assembly.LoadFile(fullPath);
                    object objInstance = assembly.CreateInstance(strNameSpace + "." + "InstanceForm");
                    objInstance.GetType().GetProperty("Database").SetValue(objInstance, TrasenFrame.Forms.FrmMdiMain.Database, null);
                    if (menuCmd.Text.Contains("自动升级SQL脚本"))
                    {
                        objInstance.GetType().GetProperty("CurrentUser").SetValue(objInstance, TrasenFrame.Forms.FrmMdiMain.CurrentUser, null);
                    }
                    //objInstance.GetType().GetProperty("MdiParent").SetValue(objInstance, this, null);

                    object[] args = new object[] { null, "系统菜单查询", null };
                    object objForm = assembly.CreateInstance(strNameSpace + "." + className, true, BindingFlags.CreateInstance, null, args, null, null);
                    if (objForm != null)
                    {

                        Form f1 = (Form)objForm;
                        f1.Text = "系统菜单查询";
                        f1.MdiParent = this;
                        f1.Show();
                    }
                }
            }
            catch (Exception err)
            {
                //Console.WriteLine( err.Message );
                throw err;
            }



        }

        private void mnuGroupUser_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Text == ((MenuCommand)sender).Text)
                {
                    f.Activate();
                    return;
                }
            }
            TrasenFrame.Forms.FrmGroupAccess fGroupAccess = new TrasenFrame.Forms.FrmGroupAccess();
            fGroupAccess.MdiParent = this;
            fGroupAccess.Show();
        }

        private void menuChangeDept_Click(object sender, EventArgs e)
        {
            //jianqg 2012-10月 emr-his框架整合 修改 原来 菜单中科室切换 没有关闭窗口，工具栏有，现在统一
            if (this.MdiChildren.Length > 0)
            {
                if (MessageBox.Show("切换科室会关闭当前所有子窗口，确定切换？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Form frm in this.MdiChildren)
                    {
                        frm.Close();
                        frm.Dispose();
                    }

                }
                else
                {
                    return;
                }
            }
            TrasenFrame.Forms.FrmSelectDept fSelectDept = new TrasenFrame.Forms.FrmSelectDept(TrasenFrame.Forms.FrmMdiMain.CurrentUser);
            if (fSelectDept.ShowDialog() == DialogResult.OK)
            {
                int ksbh = fSelectDept.SelectedDeptId;
                //如果是普通用户，更新关系
                if (!TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator)
                {
                    string sql = "update jc_emp_dept_role set xtbh =" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + " where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " and dept_id=" + ksbh;
                    TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);
                }
                TrasenFrame.Classes.Department dept = new TrasenFrame.Classes.Department(fSelectDept.SelectedDeptId, TrasenFrame.Forms.FrmMdiMain.Database);
                TrasenFrame.Forms.FrmMdiMain.CurrentDept = dept;
                MessageBox.Show("科室已更改为【" + dept.DeptName + "】", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //if ( this.dlgMsg != null )
                //{
                //    this.dlgMsg.Clear();
                //    this.dlgMsg.Hide();
                //}
                //DisplayUnDealMessage();
                CloseMessageDectectProcess();
                StartMesssageDectectProcess();
            }
            fSelectDept.Close();

            //jianqg 2012-10月 emr-his框架整合 增加 包含电子病历菜单，自动打开电子病历
            if (menu_EmrBussinessHis != null)
            {
                menu_Click(menu_EmrBussinessHis, null);
            }

            //Add By Tany 2017-08-17
            LoadLisWjz();

            //Add By HYD 2017-09-19
            LoadPACSWjz();
        }

        private void menuReleaseMsg_Click(object sender, EventArgs e)
        {
            // Begin Modifty by Wangzhi

            //begin comment by wangzhi 2010-10-19
            //判断用户所在组是否可以使用发布功能，否则只能浏览
            //SystemCfg cfg = new SystemCfg(0006);
            //string sql = "select 1 from pub_group_user where group_id in (" + cfg.Config + ") and user_id=" + FrmMdiMain.CurrentUser.UserID;
            //DataRow dr = FrmMdiMain.Database.GetDataRow(sql);
            //end comment

            //从消息发布许可人列表中判断当前用户能否发布消息
            string sql = "select * from pub_message_releasor where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
            DataRow dr = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow(sql);

            //End Modifty

            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(TrasenFrame.Classes.Constant.ApplicationDirectory + "\\TrasenMessage.dll");
            Type type = null;
            Object obj = null;
            if (dr == null)
            {
                //只能浏览
                type = assembly.GetType("TrasenMessage.FrmMsgBrower", false, true);
                obj = System.Activator.CreateInstance(type);
            }
            else
            {
                //能使用发布功能
                type = assembly.GetType("TrasenMessage.FrmMsgRelease", false, true);
                obj = System.Activator.CreateInstance(type);
            }
            FrameEnvironment frameEvt = new FrameEnvironment();
            frameEvt.Database = TrasenFrame.Forms.FrmMdiMain.Database;
            frameEvt.User = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
            frameEvt.Department = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
            frameEvt.CSystem = TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId;

            ((Form)obj).MdiParent = this;
            ((Form)obj).WindowState = FormWindowState.Maximized;
            ((Form)obj).Tag = frameEvt;
            ((Form)obj).Show();
        }

        #endregion

        #region 固定菜单部分
        /// <summary>
        /// 加载固定菜单部分
        /// </summary>
        private void LoadFixedMenu()
        {
            #region [系统]
            MenuCommand menuSystem = new MenuCommand("系统");
            MenuCommand menuReleasorSet = new MenuCommand("公告通知人员设置", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenFrame.Forms.FrmMessageReleasor frmReleasor = new TrasenFrame.Forms.FrmMessageReleasor();
                frmReleasor.ShowDialog();
            }));//add by wangzhi 2010-10-19

            MenuCommand menuNoteAndMessage = new MenuCommand("公告通知及消息");
            MenuCommand menuReleaseMessage = new MenuCommand("公告通知管理", new EventHandler(menuReleaseMsg_Click));
            MenuCommand menuImmMessage = new MenuCommand("即时消息管理", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenMessage.FrmMsgManager frmMsgMgr = new TrasenMessage.FrmMsgManager(TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator);
                frmMsgMgr.ShowDialog();
            }));
            menuNoteAndMessage.MenuCommands.AddRange(new MenuCommand[] { menuReleaseMessage, menuImmMessage });

            MenuCommand menuLockTimeSet = new MenuCommand("系统锁屏时间设置", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenFrame.Forms.FrmLockTimeSet f = new TrasenFrame.Forms.FrmLockTimeSet();
                f.ShowDialog();
            }));
            MenuCommand menuMessageSender = new MenuCommand("短消息发送", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenFrame.Forms.FrmMessageSender fSender = new TrasenFrame.Forms.FrmMessageSender();
                fSender.Show();
            }));

            MenuCommand mnuSysSetting = new MenuCommand("系统菜单设置", new EventHandler(mnuSysSetting_Click));
            MenuCommand mnuSysSearch = new MenuCommand("系统菜单查询", new EventHandler(mnuSysSearch_Click));//jianqg 2012-7-3 增加 菜单查询
            MenuCommand mnuSysAutoSql = new MenuCommand("自动升级SQL脚本", new EventHandler(mnuSysSearch_Click));//jianqg 2013-2-22 增加 自动升级SQL脚本
            MenuCommand mnuGroupUser = new MenuCommand("系统用户组设置", new EventHandler(mnuGroupUser_Click));
            MenuCommand mnuUpLoadFile = new MenuCommand("系统升级文件上传(所有服务器)", new EventHandler(mnuUpLoad_Click));
            MenuCommand mnuUpLoadFileBD = new MenuCommand("系统升级文件上传(本地服务器)", new EventHandler(mnuUpLoadBD_Click));
            MenuCommand menuSpliter1 = new MenuCommand("-");
            MenuCommand menuSwitch = new MenuCommand("更改系统");
            MenuCommand menuChangeDept = new MenuCommand("更改当前科室", new EventHandler(menuChangeDept_Click));
            #region 获取用户拥有的系统
            DataTable tableSys = TrasenFrame.Forms.FrmMdiMain.CurrentUser.GetSystemInfo();
            for (int i = 0; i < tableSys.Rows.Count; i++)
            {
                TrasenFrame.Classes.MenuTag tag = new TrasenFrame.Classes.MenuTag();
                tag.System = new TrasenFrame.Classes.SystemInfo(Convert.ToInt32(tableSys.Rows[i]["System_Id"]), TrasenFrame.Forms.FrmMdiMain.Database);
                MenuCommand menuSys = new MenuCommand();
                menuSys.Text = tableSys.Rows[i]["Name"].ToString().Trim();
                menuSys.Tag = tag;
                menuSys.Click += new EventHandler(menuSys_Click);
                if (tag.System.SystemId == TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId)
                    menuSys.Checked = true;

                menuSwitch.MenuCommands.Add(menuSys);

            }
            #endregion
            MenuCommand menuSpliter2 = new MenuCommand("-");
            MenuCommand menuResetPwd = new MenuCommand("修改密码", new EventHandler(delegate(object sender, EventArgs e)
            {
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd)
                {
                    MessageBox.Show("使用公用密码登陆不能修改密码", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TrasenFrame.Forms.DlgPasswd dlgPasswd = new TrasenFrame.Forms.DlgPasswd();
                dlgPasswd.AllowCancel = true;
                dlgPasswd.ShowDialog();
            }));
            MenuCommand menuRelogin = new MenuCommand("重新登录", new EventHandler(mnuSRelogin_Click));
            MenuCommand menuParaSet = new MenuCommand("参数设置", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenFrame.Forms.FrmParaSetting frmParaSetting = new TrasenFrame.Forms.FrmParaSetting();
                frmParaSetting.ShowDialog();
            }));
            MenuCommand menuSpliter3 = new MenuCommand("-");
            MenuCommand menuExit = new MenuCommand("退出系统", System.Windows.Forms.Shortcut.AltF4, new EventHandler(delegate(object sender, EventArgs e)
            {
                this.Close();
            }));
            if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator)
                menuSystem.MenuCommands.AddRange(new MenuCommand[] { menuReleasorSet,menuNoteAndMessage, menuLockTimeSet,
                    menuMessageSender, 
                    mnuSysSetting, 
                    mnuSysSearch,
                    mnuSysAutoSql,
                    mnuGroupUser, 
                    mnuUpLoadFile, 
                    mnuUpLoadFileBD,
                    menuSpliter1, 
                    menuSwitch,
                    menuChangeDept, 
                    menuSpliter2, 
                    menuResetPwd, 
                    menuRelogin, 
                    menuParaSet, 
                    menuSpliter3, 
                    menuExit });
            else
                menuSystem.MenuCommands.AddRange(new MenuCommand[] { menuNoteAndMessage, 
                    menuMessageSender, 
                    menuSwitch, 
                    menuChangeDept, 
                    menuSpliter2, 
                    menuResetPwd, 
                    menuRelogin, 
                    menuParaSet, 
                    menuSpliter3, 
                    menuExit });
            #endregion

            #region [窗口]
            menuWindow = new MenuCommand("窗口(&W)");
            MenuCommand mnuWTileHorizontal = new MenuCommand("水平平铺(&H)", new EventHandler(delegate(object sender, EventArgs e)
            {
                this.LayoutMdi(MdiLayout.TileHorizontal);
            }));
            MenuCommand mnuWTileVertical = new MenuCommand("垂直平铺(&W)", new EventHandler(delegate(object sender, EventArgs e)
            {
                this.LayoutMdi(MdiLayout.TileVertical);
            }));
            MenuCommand mnuWCascade = new MenuCommand("层叠窗口(&C)", new EventHandler(delegate(object sender, EventArgs e)
            {
                this.LayoutMdi(MdiLayout.Cascade);
            }));
            MenuCommand mnuWArrangeIcons = new MenuCommand("排列图标(&A)", new EventHandler(delegate(object sender, EventArgs e)
            {
                this.LayoutMdi(MdiLayout.ArrangeIcons);
            }));
            menuWindow.MenuCommands.AddRange(new MenuCommand[] { mnuWTileHorizontal, mnuWTileVertical, mnuWCascade, mnuWArrangeIcons });

            //Add By Tany 2010-07-22 在窗口栏显示已经打开的窗体
            menuWindow.PopupStart += new CommandHandler(menuWindow_PopupStart);
            menuWindow.PopupEnd += new CommandHandler(menuWindow_PopupEnd);
            #endregion

            #region [帮助]
            MenuCommand menuHelp = new MenuCommand("帮助(&H)");
            MenuCommand mnuHelp = new MenuCommand("使用帮助(&H)");
            MenuCommand menuAbout = new MenuCommand("关于(&A)", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenMainWindow.Forms.FrmAbout frmAbout = new TrasenMainWindow.Forms.FrmAbout(_caption, _maintProgramName);
                frmAbout.ShowDialog();
            }));
            MenuCommand menuSupport = new MenuCommand("技术支持(&S)");
            MenuCommand menuRegAndAuth = new MenuCommand("注册及授权");
            MenuCommand mnuSRegister = new MenuCommand("系统注册(&R)", delegate(object sender, EventArgs e)
            {
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator)
                {
                    DlgRegister dlgRegister = new DlgRegister();
                    dlgRegister.ShowDialog();
                }
                else
                {
                    MessageBox.Show("对不起，你不是系统管理员，不能使用注册功能", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            MenuCommand menuAuth = new MenuCommand("菜单授权(&A)", delegate(object sender, EventArgs e)
            {
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator)
                {
                    (new TrasenMainWindow.Forms.FrmMenuAuth()).ShowDialog();
                }
                else
                {
                    MessageBox.Show("对不起，你不是系统管理员，不能使用注册功能", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            menuRegAndAuth.MenuCommands.AddRange(new MenuCommand[] { mnuSRegister, menuAuth });

            menuHelp.MenuCommands.AddRange(new MenuCommand[] { mnuHelp, menuAbout, menuSupport, menuRegAndAuth });
            #endregion

            this.mainMenu.MenuCommands.AddRange(new MenuCommand[] { menuSystem, menuWindow, menuHelp });

            //设置字体大小
            mainMenu.Font = new Font("宋体", (float)Convert.ToDouble(TrasenFrame.Classes.Constant.MenuFontSize == "" ? "9" : TrasenFrame.Classes.Constant.MenuFontSize));

        }

        //菜单消失时，清除固定菜单栏以外的菜单
        private void menuWindow_PopupEnd(MenuCommand mc)
        {
            int count = mc.MenuCommands.Count;

            if (count >= 4)
            {
                for (int index = 4; index < count; index++)
                    mc.MenuCommands.RemoveAt(4);
            }
        }

        //菜单弹出时，加载打开的子窗体为菜单
        private void menuWindow_PopupStart(MenuCommand mc)
        {
            Form current = this.ActiveMdiChild;

            Form[] children = this.MdiChildren;

            if (children.Length > 0)
            {
                mc.MenuCommands.Add(new MenuCommand("-"));

                foreach (Form f in children)
                {
                    MenuCommand newMC = new MenuCommand(f.Text);

                    newMC.Checked = (current == f);
                    newMC.Click += new EventHandler(newMC_Click);

                    mc.MenuCommands.Add(newMC);
                }
            }
        }
        //激活选中的子窗体
        private void newMC_Click(object sender, EventArgs e)
        {
            MenuCommand childCommand = sender as MenuCommand;

            string name = childCommand.Text;

            Form[] children = this.MdiChildren;

            foreach (Form f in children)
            {
                if (f.Text == name)
                {
                    f.Activate();
                    break;
                }
            }
        }
        //固定菜单的点击事件
        private void menuSys_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                if (MessageBox.Show("更该系统会关闭当前所有子窗口，确定更改？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Form frm in this.MdiChildren)
                    {
                        frm.Close();
                        frm.Dispose();
                    }
                }
                else
                {
                    return;
                }
            }
            mainMenu.MenuCommands.Clear();
            mainToolbar.Buttons.Clear();
            TrasenFrame.Classes.MenuTag tag = (TrasenFrame.Classes.MenuTag)((MenuCommand)sender).Tag;
            TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new TrasenFrame.Classes.SystemInfo(tag.System.SystemId, TrasenFrame.Forms.FrmMdiMain.Database);
            LoadUserSystemMenu(tag.System.SystemId, true);
            LoadFixedMenu();
            LoadFixedToolbarButton();
            this.Text = this._caption + "--" + tag.System.SystemName;

            LoadBackgroupPicture();

            //强制性重新选择科室
            TrasenFrame.Forms.FrmSelectDept fSelectDept = new TrasenFrame.Forms.FrmSelectDept(TrasenFrame.Forms.FrmMdiMain.CurrentUser);
            if (fSelectDept.ShowDialog() == DialogResult.OK)
            {
                int ksbh = fSelectDept.SelectedDeptId;
                TrasenFrame.Classes.Department dept = new TrasenFrame.Classes.Department(fSelectDept.SelectedDeptId, TrasenFrame.Forms.FrmMdiMain.Database);
                TrasenFrame.Forms.FrmMdiMain.CurrentDept = dept;
                this.sttbpDept.Text = "部门科室：" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
            }
            else
            {
                MessageBox.Show("你更换了系统但未更改登录科室", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            fSelectDept.Close();
            //if ( this.dlgMsg != null )
            //{
            //    dlgMsg.Clear();
            //    dlgMsg.Hide();
            //}
            //this.DisplayUnDealMessage();
            CloseMessageDectectProcess();
            StartMesssageDectectProcess();

            //jianqg 2012-10月 emr-his框架整合 增加 包含电子病历菜单，自动打开电子病历(点系统更换除外，系统更换时，在系统更换时处理)
            if (menu_EmrBussinessHis != null)
            {
                menu_Click(menu_EmrBussinessHis, null);
            }

        }
        #endregion

        #region 加载系统及其所属的模块菜单
        /// <summary>
        /// 加载系统菜单  jianqg 2012-10月 emr-his框架整合 增加
        /// </summary>
        /// <param name="SystemId"></param>
        private void LoadUserSystemMenu(int SystemId)
        {
            LoadUserSystemMenu(SystemId, false);

        }
        /// <summary>
        /// //jianqg 2012-10月 emr-his框架整合 修改 增加参数is_menuSys_Click
        /// </summary>
        /// <param name="SystemId"></param>
        /// <param name="is_menuSys_Click"> 是否是点击 更换系统</param>
        private void LoadUserSystemMenu(int SystemId, bool is_menuSys_Click)
        {

            //jianqg 2012-10月 emr-his框架整合 增加
            menu_EmrBussinessHis = null;

            //读取菜单的时候改变操作员的登录系统和科室
            //Modify By Tany 2009-12-23
            TrasenFrame.Forms.FrmMdiMain.Database.DoCommand("update pub_user set login_dept=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + ",login_system = " + SystemId + " where id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID);

            DataTable table = TrasenFrame.Forms.FrmMdiMain.LoadSystemMenuList(SystemId);

            DataRow[] rows = table.Select("Parent_Id=-1", "Sort_Id");

            for (int i = 0; i < rows.Length; i++)
            {
                MenuCommand menu = new MenuCommand(rows[i]["name"].ToString().Trim());
                menu.Text = rows[i]["name"].ToString().Trim();
                TrasenFrame.Classes.MenuTag tag = new TrasenFrame.Classes.MenuTag();

                tag.Function_Name = rows[i]["Function_Name"].ToString().Trim();
                tag.FunctionTag = rows[i]["function_tag"].ToString().Trim();
                tag.DllName = rows[i]["Dll_name"].ToString().Trim();
                tag.MenuName = menu.Text;
                tag.System = new TrasenFrame.Classes.SystemInfo(Convert.ToInt32(rows[i]["menu_id"]), TrasenFrame.Forms.FrmMdiMain.Database);
                tag.Jgbm = Convert.ToInt32(rows[i]["jgbm"]) == -1 ? TrasenFrame.Forms.FrmMdiMain.Jgbm : Convert.ToInt32(rows[i]["jgbm"]);//Add By Tany 2010-01-14 Modify By Tany 如果没有设置机构编码，则默认机构编码设置为登录机构编码
                //jianqg emr-his 整合暂时注释
                tag.CanUsePublicPwd = Convert.ToInt32(rows[i]["CanUsePublicPwd"]) == 1 ? true : false;//是否可以用公用密码 jianqg 2012-10-6 emr-his框架整合  增加

                menu.Tag = tag;
                if (ContainMenu_ts_autosql(tag))
                    continue;//不加 2012-2-22 jianqg 做固定菜单

                menu.Click += new EventHandler(menu_Click);
                //jianqg 2012-10月 emr-his框架整合 增加  是否包含电子病历菜单
                ContainMenu_EmrBussinessHis(menu);
                object objIcon = Convert.IsDBNull(rows[i]["icon"]) ? null : rows[i]["icon"];

                AddSubMenu(table, menu, Convert.ToInt32(rows[i]["menu_id"]));
                mainMenu.MenuCommands.Add(menu);
                if (Convert.ToInt32(rows[i]["showtoolbar"]) == 1)
                {
                    if (objIcon == null)
                    {
                        AddButton(menu.Text, tag);
                    }
                    else
                    {
                        AddButton(menu.Text, tag, objIcon);
                    }
                }
                //mainMenu.MenuItems.Add( menu );
            }
            //jianqg 2012-10月 emr-his框架整合 增加 包含电子病历菜单，自动打开电子病历(点系统更换除外，系统更换时，在系统更换时处理)
            if (menu_EmrBussinessHis != null && is_menuSys_Click == false)
            {
                menu_Click(menu_EmrBussinessHis, null);
            }
        }
        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="tableMenu"></param>
        /// <param name="parentMenu"></param>
        /// <param name="parentMenuId"></param>
        private void AddSubMenu(DataTable tableMenu, MenuCommand parentMenu, int parentMenuId)
        {
            DataRow[] rows = tableMenu.Select("Parent_Id=" + parentMenuId.ToString(), "Sort_Id");
            for (int i = 0; i < rows.Length; i++)
            {
                MenuCommand menu = new MenuCommand();
                menu.Text = rows[i]["name"].ToString().Trim();

                TrasenFrame.Classes.MenuTag tag = new TrasenFrame.Classes.MenuTag();
                tag.Function_Name = rows[i]["Function_Name"].ToString().Trim();
                tag.FunctionTag = rows[i]["function_tag"].ToString().Trim();
                tag.DllName = rows[i]["Dll_name"].ToString().Trim();
                tag.MenuName = menu.Text;
                tag.System = new TrasenFrame.Classes.SystemInfo(Convert.ToInt32(rows[i]["menu_id"]), TrasenFrame.Forms.FrmMdiMain.Database);
                tag.Jgbm = Convert.ToInt32(rows[i]["jgbm"]) == -1 ? TrasenFrame.Forms.FrmMdiMain.Jgbm : Convert.ToInt32(rows[i]["jgbm"]);//Add By Tany 2010-01-14 Modify By Tany 如果没有设置机构编码，则默认机构编码设置为登录机构编码
                //jianqg emr-his 整合暂时注释
                tag.CanUsePublicPwd = Convert.ToInt32(rows[i]["CanUsePublicPwd"]) == 1 ? true : false;//是否可以用公用密码 jianqg 2012-10-6 emr-his框架整合  增加
                //wangzhi 13-08-12 加入授权码                
                menu.Tag = tag;
                if (ContainMenu_ts_autosql(tag))
                    continue;//不加 2012-2-22 jianqg 做固定菜单
                //jianqg 2012-10月 emr-his框架整合 增加  是否包含电子病历菜单
                ContainMenu_EmrBussinessHis(menu);
                object objIcon = Convert.IsDBNull(rows[i]["icon"]) ? null : rows[i]["icon"];

                if (menu.Text != "-")
                    menu.Click += new EventHandler(menu_Click);

                if (Convert.ToInt32(rows[i]["showtoolbar"]) == 1)
                {
                    if (objIcon == null)
                    {
                        AddButton(menu.Text, tag);
                    }
                    else
                    {
                        AddButton(menu.Text, tag, objIcon);
                    }
                }
                AddSubMenu(tableMenu, menu, Convert.ToInt32(rows[i]["menu_id"]));
                parentMenu.MenuCommands.Add(menu);
                //parentMenu.MenuItems.Add(menu);
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {


            if (MdiChildFormIsExist(this, ((TrasenFrame.Classes.MenuTag)((MenuCommand)sender).Tag).MenuName))
                return;

            MenuClickTraceLog(sender);

            RelationalDatabase jgbmDb = null;
            try
            {
                TrasenFrame.Classes.MenuTag tag = (TrasenFrame.Classes.MenuTag)((MenuCommand)sender).Tag;

                #region wangzhi加入授权码验证
                if (tag.DllName.ToUpper() != "TS_PUB_REPORT") //自定义报表不用检测授权2013-08-16
                {
                    if (!_IsDebugVersion)
                    {
                        if (this._checkMenuAuth)
                        {
                            TrasenFrame.Classes.MenuTag _tag = TrasenFrame.Classes.MenuTag.GetTag(tag.DllName, tag.Function_Name, tag.FunctionTag, tag.MenuName,
                                TrasenFrame.Forms.FrmMdiMain.Database);
                            try
                            {
                                string tmp = TrasenRegister.Security.DeCryp(_tag.AuthCode);
                                string[] val = tmp.Split("|$|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                if (val[0] != (new TrasenFrame.Classes.SystemCfg(0002)).Config)
                                {
                                    MessageBox.Show("该菜单没有授权给当前用户，或者授权码不正确,不能使用", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (val[1] != tag.MenuName || val[2] != tag.DllName || val[3] != tag.Function_Name)
                                {
                                    MessageBox.Show("菜单信息和授权信息不一致，不能使用", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show("授权码不正确或者已损坏", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
                #endregion

                //jianqg 2012-10月 emr-his框架整合 增加
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd && tag.CanUsePublicPwd == false)
                {
                    MessageBox.Show("该菜单不允许使用公用密码！", "提示信息");
                    return;
                }
                //Modify By Tany 2010-01-14
                //如果该菜单的连接指向不是本地，则使用指向的数据库连接
                if (tag.Jgbm != -1 && tag.Jgbm != TrasenFrame.Forms.FrmMdiMain.Jgbm)
                {
                    jgbmDb = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(tag.Jgbm);

                    TrasenFrame.Classes.WorkStaticFun.InstanceForm(tag.DllName, tag.Function_Name, tag.MenuName, TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept, tag,
                        tag.System.SystemId, this, jgbmDb);
                }
                else
                {
                    TrasenFrame.Classes.WorkStaticFun.InstanceForm(tag.DllName, tag.Function_Name, tag.MenuName, TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept, tag,
                        tag.System.SystemId, this, TrasenFrame.Forms.FrmMdiMain.Database);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 加载工具栏按钮
        private void LoadFixedToolbarButton()
        {
            ToolBarButton btn = new ToolBarButton();
            btn.Text = "切换科室";
            btn.Tag = "SWITCH";
            btn.ImageIndex = 1;
            this.mainToolbar.Buttons.Add(btn);
            btn = new ToolBarButton();
            btn.Text = "重新登录";
            btn.Tag = "RELOGIN";
            btn.ImageIndex = 2;
            this.mainToolbar.Buttons.Add(btn);
            btn = new ToolBarButton();
            btn.Text = "锁屏";
            btn.Tag = "LOCKSRCEEN";
            btn.ImageIndex = 4;
            this.mainToolbar.Buttons.Add(btn);

            btn = new ToolBarButton();
            btn.Style = ToolBarButtonStyle.Separator;
            this.mainToolbar.Buttons.Add(btn);
            btn = new ToolBarButton();
            btn.Text = "关闭";
            btn.Tag = "EXIT";
            btn.ImageIndex = 3;
            this.mainToolbar.Buttons.Add(btn);
            //设置字体大小
            mainToolbar.Font = new Font("宋体", (float)Convert.ToDouble(TrasenFrame.Classes.Constant.MenuFontSize == "" ? "9" : TrasenFrame.Classes.Constant.MenuFontSize));
            this.sttbMain.Font = new Font("宋体", (float)Convert.ToDouble(TrasenFrame.Classes.Constant.MenuFontSize == "" ? "9" : TrasenFrame.Classes.Constant.MenuFontSize));
        }
        private void AddButton(string Text, TrasenFrame.Classes.MenuTag tag)
        {
            if (tag.DllName != "" && tag.Function_Name != "")
            {
                ToolBarButton tlbbtn = new ToolBarButton();
                tlbbtn.Text = Text;
                tlbbtn.Tag = tag;
                tlbbtn.ImageIndex = 0;
                this.mainToolbar.Buttons.Add(tlbbtn);
            }
        }
        private void AddButton(string Text, TrasenFrame.Classes.MenuTag tag, int icoIndex)
        {
            if (tag.DllName != "" && tag.Function_Name != "")
            {
                ToolBarButton tlbbtn = new ToolBarButton();
                tlbbtn.Text = Text;
                tlbbtn.Tag = tag;
                if (icoIndex < this.imgToolbar.Images.Count && icoIndex >= 0)
                    tlbbtn.ImageIndex = icoIndex;
                else
                    tlbbtn.ImageIndex = 0;
                this.mainToolbar.Buttons.Add(tlbbtn);
            }
        }
        private void AddButton(string Text, TrasenFrame.Classes.MenuTag tag, object Icon)
        {
            if (tag.DllName != "" && tag.Function_Name != "")
            {
                ToolBarButton tlbbtn = new ToolBarButton();
                tlbbtn.Text = Text;
                tlbbtn.Tag = tag;
                if (Icon != null)
                {
                    byte[] byteIco = (byte[])Icon;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(byteIco);
                    try
                    {
                        Image img = Image.FromStream(ms, true);

                        userToolbarList.Images.Add(img);

                        //imgToolbar.Images.Add( img );
                        tlbbtn.ImageIndex = userToolbarList.Images.Count - 1;
                    }
                    catch (Exception err)
                    {
                        tlbbtn.ImageIndex = 0;
                    }
                }
                else
                {
                    tlbbtn.ImageIndex = 0;
                }
                this.mainToolbar.Buttons.Add(tlbbtn);
            }
        }
        #endregion

        #region 工具栏按钮事件
        private void mainToolbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            TrasenFrame.Classes.MenuTag tag;
            if (e.Button.Tag is TrasenFrame.Classes.MenuTag)
            {
                tag = (TrasenFrame.Classes.MenuTag)e.Button.Tag;
                MenuCommand menu = new MenuCommand();
                menu.Tag = tag;
                menu_Click(menu, null);
            }
            else
            {
                string sTmp = e.Button.Tag.ToString();
                if (sTmp.Trim().ToUpper() == "EXIT")
                {
                    //
                    try
                    {
                        if (this.MdiChildren.Length > 0)
                        {
                            Form form = this.ActiveMdiChild;
                            form.Close();
                        }
                        else
                            this.Close();
                    }
                    catch
                    {
                    }
                }
                if (sTmp.Trim().ToUpper() == "RELOGIN")
                {
                    mnuSRelogin_Click(null, null);
                }
                if (sTmp.Trim().ToUpper() == "SWITCH")
                {
                    //if (this.MdiChildren.Length > 0)
                    //{
                    //    if (MessageBox.Show("切换科室会关闭当前所有子窗口，确定切换？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //    {
                    //        foreach (Form frm in this.MdiChildren)
                    //        {
                    //            frm.Close();
                    //            frm.Dispose();
                    //        }
                    //    }
                    //    else
                    //    {
                    //        return;
                    //    }
                    //}
                    //jianqg 2012-10月 emr-his框架整合 修改 原来 菜单中科室切换 没有关闭窗口，工具栏有，现在统一
                    menuChangeDept_Click(null, null);
                }
                if (sTmp.Trim().ToUpper() == "LOCKSRCEEN")
                {
                    //if ( dlgMsg != null )
                    //{
                    //    dlgMsg.Clear();
                    //    dlgMsg.Hide();
                    //}
                    CloseMessageDectectProcess();
                    TrasenFrame.Forms.FrmLockScreen fLockScreen = new TrasenFrame.Forms.FrmLockScreen(TrasenFrame.Forms.FrmMdiMain.CurrentUser, true);
                    fLockScreen.ShowDialog();
                    if (fLockScreen.ExitProgrammer)
                    {
                        ExitProgrammer();
                        return;
                    }
                    screenLocked = false;
                    //DisplayUnDealMessage();
                    StartMesssageDectectProcess();
                }
            }
        }
        #endregion

        #endregion

        #region 主窗体事件   FrmMdiMainWindow_Load 、 FrmMdiMain_Closing 、FrmMdiMain_Activated 、 FrmMdiMain_SizeChanged
        private void FrmMdiMain_Load(object sender, System.EventArgs e)
        {

            try
            {
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser == null || TrasenFrame.Forms.FrmMdiMain.CurrentDept == null)
                {
                    Application.Exit();
                    return;
                }
                //安装4.0Framework
                InstallDotNetFramework();

                string hospitalName = (new TrasenFrame.Classes.SystemCfg(0002)).Config;//获取医院名称
                DateTime serverTime = DateManager.ServerDateTimeByDBType(TrasenFrame.Forms.FrmMdiMain.Database);//获取当前服务器时间

                #region 设置状态栏信息：医院名称，当前登录的人员，科室,系统时间的显示
                sttbpUnit.Text = "用户单位：" + hospitalName + "【" + TrasenFrame.Forms.FrmMdiMain.Jgbm + "：" + TrasenFrame.Forms.FrmMdiMain.Jgmc + "】";
                if (this._IsDebugVersion)
                    sttbpUnit.Text += "【测试开发模式】";
                sttbpUser.Text = "操作员：" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;
                sttbpDept.Text = "部门科室：" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
                this.CurrentTime = serverTime;
                this.timeSystem.Enabled = true;
                this.timeSystem.Tick += new EventHandler(timeSystem_Tick);
                #endregion

                #region 将本机时间与服务器时间同步
                TrasenClasses.GeneralClasses.SystemTime systNew = new SystemTime();
                systNew.wDay = Convert.ToInt16(serverTime.Day);
                systNew.wMonth = Convert.ToInt16(serverTime.Month);
                systNew.wYear = Convert.ToInt16(serverTime.Year);
                systNew.wHour = Convert.ToInt16(serverTime.Hour);
                systNew.wMinute = Convert.ToInt16(serverTime.Minute);
                systNew.wSecond = Convert.ToInt16(serverTime.Second);
                ApiFunction.SetLocalTime(ref systNew);// 调用API，更新系统时间 
                #endregion

                #region 注册验证 add by wangzhi 2010-09-29
                TrasenRegister.Licence.CheckRegisterCode += new TrasenRegister.CheckRegisterCodeHandle(Licence_CheckRegisterCode);
                try
                {

                    bool ret = TrasenRegister.Licence.DoCheck(hospitalName, serverTime, TrasenFrame.Forms.FrmMdiMain.Database);
                    if (ret)
                    {
                        return;
                    }
                    else
                    {
                        //Modify By Tany 2012-02-23 如果注册验证通过，则判断是否更改了注册的公司信息
                        try
                        {
                            string keyCode = Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select RegCode from YY_Register"), "");
                            if (!String.IsNullOrEmpty(keyCode))
                            {
                                string[] contents = TrasenRegister.Licence.GetRegisterInfo(keyCode);
                                if (contents.Length >= 7)
                                {
                                    _caption = contents[5];
                                    _maintProgramName = contents[6];

                                    this.Text = _caption + "--" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemName;
                                    this.notifyIcon1.Text = _caption; //Modify By tany 2012-03-06
                                }
                            }
                        }
                        catch//错误则跳过
                        {
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "注册验证异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                #endregion

                #region 密码检查 add by wangzhi 2010-12-16 \ 2013-09-17 加入公用密码不允许修改密码
                TrasenFrame.Classes.SystemCfg cfgAllowEmptyPwd = new TrasenFrame.Classes.SystemCfg(16);
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.Password.Trim() == "" && cfgAllowEmptyPwd.Config == "1"
                    && !TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd)
                {
                    TrasenFrame.Forms.DlgPasswd fPwd = new TrasenFrame.Forms.DlgPasswd();
                    fPwd.Message = "您当前的密码为空，系统设置了不允许空密码，请更改您的密码";
                    fPwd.AllowCancel = false;
                    fPwd.ShowDialog();
                }

                #endregion

                //显示公告、通知
                ShowMessage(0);

                #region 启动即时消息控制器(线程)，(2013-12-26 comment by wangzhi 框架不再负责启动消息监听，改为启动监听消息的进程，由进程去监听消息)
                //LoadtimerMessageConfig(); //commit by wangzhi 不用原来的定时器，集成到系统时钟控制定时器去触发

                //实例化消息管理器，并开始侦听登录时获得的端口
                //messageControler = new TrasenMessage.MessageController();
                //messageControler.RecivedMessage += new TrasenMessage.ReceviedMessageHandler( messageControler_RecivedMessage );
                //messageControler.StartListen();

                //add by wangzhi 开启一个进程用于监听消息
                StartMesssageDectectProcess();
                #endregion

                #region 空闲等待锁屏处理 add by wangzhi 2010-11-27(线程)
                idleTimeout = GetGroupIdleTimeOut();
                if (idleTimeout > 0)
                {
                    this.AfterIdleTimeoutEvent += new AfterIdleTimeoutEventHandler(ProcessAfterIdleTimeoutEvent);
                    thIdle = new Thread(new ThreadStart(DetectIdleTime));
                    thIdle.IsBackground = true;
                    thIdle.Start();
                }
                #endregion

                #region 设置并启动子系统消息检测定时器 (考虑是不是由LIS那边改造为发消息，通过统一的消息机制来管理？)
                int timespan = 0;
                try
                {
                    TrasenFrame.Classes.SystemCfg cfg19 = new TrasenFrame.Classes.SystemCfg(19);
                    int second = Convert.ToInt32(cfg19.Config); //设置的秒数
                    timespan = 1000 * second;
                }
                catch
                {
                    MessageBox.Show("系统参数19不存在或设置错误,请联系管理员,在未设置该参数前将不检测子系统消息", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (timespan != 0)
                {
                    //timespan = 1000 * 2; //测试用，2秒检测一次
                    timerSubSystemMessage.Interval = timespan;
                    timerSubSystemMessage.Start();
                }
                else
                {
                    timerSubSystemMessage.Enabled = false;
                }
                #endregion

                #region 显示未读消息 ,(2013-12-26 comment by wangzhi 注释。框架不再监听消息，消息由另一个进程去监听。框架只负责响应)
                //this.DisplayUnDealMessage();
                #endregion

                LoadBackgroupPicture();

                WriteFrameLocalLog(new string[] { "Mian Window Load Successfully" }, true);

                #region 如果指定了某个系统的某个菜单
                if (!string.IsNullOrEmpty(_system_menu_id))
                {
                    WriteFrameLocalLog(new string[] { "正在启动指定的界面" + _system_menu_id }, true);
                    string[] strArray = _system_menu_id.Split("|".ToCharArray());
                    string str0 = string.Format(@"select m.*,psm.system_id
                                                     from pub_menu m
                                                        inner join pub_system_menu as psm on psm.menu_id=m.menu_id
                                                        inner join pub_group_menu as gm on psm.sys_menu_id = gm.system_menu_id
                                                        inner join pub_group_user as gu on gm.[group_id]=gu.[group_id]
                                                        inner join pub_user u on gu.[user_id]=u.id 
                                                    where u.code='{0}' and psm.system_id={1} and m.menu_id={2}",
                                                    TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode, strArray[0], strArray[1]);
                    DataRow row = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow(str0);
                    if (row != null)
                    {
                        TrasenFrame.Classes.MenuTag tag = new TrasenFrame.Classes.MenuTag();
                        tag.Function_Name = row["Function_Name"].ToString().Trim();
                        tag.FunctionTag = row["function_tag"].ToString().Trim();
                        tag.DllName = row["Dll_name"].ToString().Trim();
                        tag.MenuName = row["Name"].ToString().Trim();
                        tag.System = new TrasenFrame.Classes.SystemInfo(Convert.ToInt32(row["system_id"]), TrasenFrame.Forms.FrmMdiMain.Database);
                        tag.Jgbm = Convert.ToInt32(row["jgbm"]) == -1 ? TrasenFrame.Forms.FrmMdiMain.Jgbm : Convert.ToInt32(row["jgbm"]);
                        tag.CanUsePublicPwd = Convert.ToInt32(row["CanUsePublicPwd"]) == 1 ? true : false;

                        TrasenFrame.Classes.WorkStaticFun.InstanceForm(tag.DllName, tag.Function_Name, tag.MenuName,
                            TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept, tag,
                            Convert.ToInt64(strArray[1]), this, TrasenFrame.Forms.FrmMdiMain.Database);
                        //MenuCommand menu = new MenuCommand();
                        //menu.Text = tag.MenuName;
                        //menu.Tag = tag;
                        //menu_Click( menu , new EventArgs() );
                    }
                }
                #endregion

                LoadLisWjz();
                LoadPACSWjz();// Add by HYD 2017-09-19
                Loadntp();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        void Licence_CheckRegisterCode(TrasenRegister.CheckRegisterCodeEventArgs e)
        {
            TrasenRegister.FrmWaring frmNote = new TrasenRegister.FrmWaring(e.InterruptProgrammer, e.Message, e.ShowTime,
                TrasenFrame.Forms.FrmMdiMain.Database, (new TrasenFrame.Classes.SystemCfg(0002)).Config);

            frmNote.ShowDialog(this);
            if (frmNote.ExitProgramm)
            {
                Application.Exit();
            }
        }

        private void FrmMdiMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {

                if (MessageBox.Show("您确定要退出系统吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //先关闭所有子窗体 Modify by Tany 2009-05-22
                    foreach (Form frm in this.MdiChildren)
                    {
                        frm.Close();
                        frm.Dispose();
                    }
                    e.Cancel = false;

                    //Modify By Tany 2009-12-02 增加登陆状态的记录
                    //TrasenFrame.Forms.FrmMdiMain.Database.DoCommand( "update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null where id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID );                    
                    TrasenFrame.Forms.FrmMdiMain.CurrentUser.Loginout();
                    //关闭连接
                    if (TrasenFrame.Forms.FrmMdiMain.Database != null)
                    {
                        if (TrasenFrame.Forms.FrmMdiMain.Database.ConnectionStates == ConnectionState.Open)
                            TrasenFrame.Forms.FrmMdiMain.Database.Close();
                        TrasenFrame.Forms.FrmMdiMain.Database.Close();
                        TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                    }
                    //if ( messageControler != null )
                    //{
                    //    messageControler.StopListen();
                    //}

                    #region 退出程序时停止空闲检测线程
                    if (thIdle != null && thIdle.IsAlive)
                    {
                        thIdle.Abort();
                    }
                    #endregion

                    notifyIcon1.Visible = false;
                    CloseMessageDectectProcess();
                    Application.Exit();

                    System.Diagnostics.Process.GetCurrentProcess().Kill();


                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
                CloseMessageDectectProcess();
                Application.Exit();
            }

        }
        #endregion

        int count1 = 0;
        /// <summary>
        /// 用于存储读取公告时间的计数器,以系统时钟计数器为准，单位为秒
        /// </summary>        
        void timeSystem_Tick(object sender, EventArgs e)
        {
            this.CurrentTime = this.CurrentTime.AddSeconds(1);
            sttbpDateTime.Text = "当前时间：" + this.CurrentTime.ToLongDateString() + " " + this.CurrentTime.ToLongTimeString();

            if (this.realLoadMessage == 1)
            {
                count1++;
                if (count1 == (loadAnnouncementFrequency * 60))
                {
                    OnShowAnnouncementHandler handler = new OnShowAnnouncementHandler(ShowAnnouncementForm);
                    IAsyncResult result = handler.BeginInvoke((int)1, new AsyncCallback(ShowAnnouncementCallback), "OK");
                }
            }
        }

        #region 显示系统公告的方法及委托定义
        /// <summary>
        /// 定义显示公告窗口的委托
        /// </summary>
        /// <param name="flag"></param>
        private delegate void OnShowAnnouncementHandler(int flag);
        /// <summary>
        /// 用于显示公告的异步委托回调函数
        /// </summary>
        /// <param name="result"></param>
        private void ShowAnnouncementCallback(IAsyncResult result)
        {
            OnShowAnnouncementHandler handler = (OnShowAnnouncementHandler)((AsyncResult)result).AsyncDelegate;
            handler.EndInvoke(result);
            if (result.IsCompleted)
            {
                count1 = 0;
            }
        }
        /// <summary>
        /// 用于异步调用的方法
        /// </summary>
        /// <param name="flag"></param>
        private void ShowAnnouncementForm(int flag)
        {
            this.Invoke(new OnShowAnnouncementHandler(ShowMessage), flag);
        }
        /// <summary>
        /// 显示通知公告
        /// </summary>
        /// <param name="_flag">显示类型0=不管是否本地已读1=过滤本地已读</param>
        private void ShowMessage(int _flag)
        {
            RelationalDatabase database = TrasenFrame.Forms.FrmMdiMain.Database.GetCopy();
            try
            {
                database.Initialize(TrasenFrame.Forms.FrmMdiMain.Database.ConnectionString);
                database.Open();
                string sql = "select 1 from pub_message where deletebit=0 and datediff(d,releasedate,getdate()) < invalidday";
                DataRow dr = database.GetDataRow(sql);
                if (dr == null)
                    return;

                //如果有有效天数的消息
                sql = "select msgId from pub_message where deletebit=0 and datediff(d,releasedate,getdate()) < invalidday";
                sql += " and msgId in (";
                sql += "select msgid from pub_message_recivelist where (reciver_type = 0 and reciver_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId + ") or (reciver_type=1 and reciver_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + ") or (reciver_type=2 and reciver_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + ")";
                sql += " ) order by sort desc,releasedate desc";//Modify By Tany 2012-04-17 增加置顶排序

                DataTable tbMsg = database.GetDataTable(sql);
                if (tbMsg.Rows.Count == 0)
                    return;

                DataTable tb = tbMsg.Clone();
                if (_flag != 0)
                {
                    for (int i = 0; i < tbMsg.Rows.Count; i++)
                    {
                        if (TrasenClasses.GeneralClasses.ApiFunction.GetIniString("MessageInfo", tbMsg.Rows[i]["msgId"].ToString().Trim(), Application.StartupPath + "\\MessageInfo.ini").Trim() == "1")
                        {
                            continue;
                        }
                        tb.Rows.Add(tbMsg.Rows[i].ItemArray);
                    }
                }
                else
                {
                    tb = tbMsg.Copy();
                }

                if (tb.Rows.Count == 0)
                    return;

                //根据发布给当前系统、科室、用户的消息

                object[] objMsgs = new object[tb.Rows.Count];
                object[] objMsgId = new object[tb.Rows.Count];

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    //objMsgs[i] = tb.Rows[i]["content"];
                    objMsgId[i] = tb.Rows[i]["msgId"];
                }

                //以公告牌的形式显示最新消息
                TrasenMessage.FrmMsgBorad fMsgBorad = new TrasenMessage.FrmMsgBorad(database, objMsgs, objMsgId);
                fMsgBorad.ShowDialog();
            }
            catch (Exception error)
            {
            }
            finally
            {
                database.Close();
                database.Dispose();
            }
        }
        #endregion

        #region 气泡类的即时消息的监听和显示处理
        private void timerTwinkle_Tick(object sender, EventArgs e)
        {
            if (this.newMsg)
            {
                if (notifyIcon1.Icon == AppIcon)
                {
                    notifyIcon1.Icon = AppGrayIcon;
                }
                else
                {
                    notifyIcon1.Icon = AppIcon;
                }

                if (!this.showMsg && this.msgSender.Trim() != "" && this.msgContents != "")
                {
                    this.showMsg = true;
                    notifyIcon1.ShowBalloonTip(this.showTime * 1000, this.msgSender, this.msgContents, ToolTipIcon.Info);
                }
            }
        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            this.newMsg = false;
            this.showMsg = false;
            this.msgSender = "";
            this.msgContents = "";
        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            this.newMsg = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowAllMessage(DateTime.Now);
        }
        /// <summary>
        /// 显示某天的气泡消息
        /// </summary>
        /// <param name="date"></param>
        private void ShowAllMessage(DateTime date)
        {
            this.newMsg = false;
            this.showMsg = false;
            this.msgSender = "";
            this.msgContents = "";

            //string path = TrasenFrame.Classes.Constant.CustomDirectory + "\\消息记录\\MSG" ;
            string path = Application.StartupPath + "\\消息记录";
            string file = path + "\\MSG" + date.ToString("yyyyMMdd") + ".txt";
            if (File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);
                string ss = sr.ReadToEnd();
                sr.Close();
                TrasenFrame.Forms.FrmTxtMsg frmTxtMsg = new TrasenFrame.Forms.FrmTxtMsg();
                frmTxtMsg.Text = "消息";
                frmTxtMsg.txtMsg.Text = ss;
                frmTxtMsg.txtMsg.ReadOnly = true;
                frmTxtMsg.TopMost = true;
                frmTxtMsg.MaximizeBox = false;
                frmTxtMsg.MinimizeBox = false;
                frmTxtMsg.ShowDialog();
            }
        }
        #endregion

        /// <summary>
        /// 显示未处理的消息
        /// </summary>
        //private void DisplayUnDealMessage()
        //{

        //    List<TrasenFrame.Classes.MessageInfo> undealMessages = TrasenFrame.Classes.MessageInfo.GetUnDealMessageList( TrasenFrame.Forms.FrmMdiMain.Database );
        //    if ( undealMessages.Count > 0 )
        //    {
        //        foreach ( TrasenFrame.Classes.MessageInfo msg in undealMessages )
        //        {
        //            TrasenMessage.MessageCommunication message = new TrasenMessage.MessageCommunication( msg.MessageId , msg.Summary , msg.SenderName , msg.IsMustRead ? 1 : 0 , msg.ShowTime );
        //            message.SendTime = msg.SendTime;
        //            message.Color = msg.FontColor;
        //            ShowRecivedMessageHandler handler = new ShowRecivedMessageHandler( ShowReciveMessage );
        //            handler.BeginInvoke( message , new AsyncCallback( ReciveMessageCallback ) , "" );
        //        }
        //    }
        //}

        private void ExitProgrammer()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
                frm.Dispose();
            }
            //Modify By Tany 2009-12-02 增加登陆状态的记录
            //TrasenFrame.Forms.FrmMdiMain.Database.DoCommand( "update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null where id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID );
            TrasenFrame.Forms.FrmMdiMain.CurrentUser.Loginout();
            //关闭连接
            if (TrasenFrame.Forms.FrmMdiMain.Database != null)
            {
                TrasenFrame.Forms.FrmMdiMain.Database.Close();
                TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
            }

            #region jianqg 2012-8-20 增加 处理Database_Lis，Database_Pacs
            if (TrasenFrame.Forms.FrmMdiMain.Database_Lis != null)
            {
                TrasenFrame.Forms.FrmMdiMain.Database_Lis.Close();
                //Database_Lis.Dispose();
            }
            if (TrasenFrame.Forms.FrmMdiMain.Database_Pacs != null)
            {
                TrasenFrame.Forms.FrmMdiMain.Database_Pacs.Close();
                //Database_Pacs.Dispose();
            }
            #endregion

            //if ( messageControler != null )
            //{
            //    messageControler.StopListen();
            //}
            notifyIcon1.Visible = false;
            CloseMessageDectectProcess();
            Application.Exit();
            TrasenRegister.Licence.Realse();

            #region 退出程序时停止空闲检测线程
            if (thIdle != null && thIdle.IsAlive)
            {
                thIdle.Abort();
            }
            #endregion
            //jianqg 2012-10月 emr-his框架整合 增加
            menu_EmrBussinessHis = null;


        }
        /// <summary>
        /// 子系统消息处理器
        /// </summary>
        private TrasenFrame.Classes.SubSystemMessageProcessor ssmp;

        private void timerSubSystemMessage_Tick(object sender, EventArgs e)
        {
            try
            {
                ssmp = new TrasenFrame.Classes.SubSystemMessageProcessor(this, TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept,
                    TrasenFrame.Classes.Constant.ApplicationDirectory, TrasenFrame.Forms.FrmMdiMain.Database);
                ssmp.AfterShowMessageDialog += new TrasenFrame.Classes.OnAfterShowMessageDialogHandle(ssmp_AfterShowMessageDialog);
                ssmp.CloseShowMessageDialog += new TrasenFrame.Classes.OnCloseShowMessageDialoghandle(ssmp_CloseShowMessageDialog);
                ssmp.Detecting();
            }
            catch (Exception err)
            {
                MessageBox.Show("检测子系统消息时发生错误" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ssmp_CloseShowMessageDialog()
        {
            timerSubSystemMessage.Start();
        }

        void ssmp_AfterShowMessageDialog()
        {
            timerSubSystemMessage.Stop();
        }

        /// <summary>
        /// jianqg 2013-2-22 是否是自动升级菜单 
        /// </summary>
        /// <param name="tag"></param>
        bool ContainMenu_ts_autosql(TrasenFrame.Classes.MenuTag tag)
        {
            //jianqg 2013-2-22 是否是自动升级菜单
            if (tag.DllName == "ts_autosql" && tag.Function_Name == "Fun_ts_autosql")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// //jianqg 2012-10月 emr-his框架整合 增加 是否包含 电子病历菜单
        /// </summary>
        /// <param name="tag"></param>
        void ContainMenu_EmrBussinessHis(MenuCommand menu)
        {
            //jianqg 2012-10月 emr-his框架整合 增加 
            TrasenFrame.Classes.MenuTag tag = (TrasenFrame.Classes.MenuTag)menu.Tag;
            if (menu_EmrBussinessHis == null && tag.DllName == "EmrBussinessHis" && tag.Function_Name == "Fun_EmrBussinessHis")
            {

                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd && tag.CanUsePublicPwd)
                    menu_EmrBussinessHis = menu;//使用公用密码登陆，并菜单设置可以使用公用密码
                else if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd == false)
                    menu_EmrBussinessHis = menu;//使用私有密码登陆
            }
        }

        /// <summary>
        /// //jianqg 2012-10月 emr-his框架整合 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sttbMain_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {
            if (e.StatusBarPanel.Name == "sttbpDept")
            {
                menuChangeDept_Click(null, null);
            }
        }
        /// <summary>
        /// 记录菜单点击的日志 add  by wangzhi 2013-06-21
        /// </summary>
        /// <param name="sender">点击的菜单对象</param>
        private void MenuClickTraceLog(object sender)
        {
            try
            {
                TrasenFrame.Classes.MenuTag tag = (TrasenFrame.Classes.MenuTag)((MenuCommand)sender).Tag;
                string time = this.CurrentTime.ToString("yyyy-MM-dd HH:mm:ss");
                string strLog = string.Format("用户[{0}]于[{1}]点击了子系统[{2}]中的菜单项中的[{3}],登录科室[{4}],引出函数[{5}]",
                    TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name, time, TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemName, tag.MenuName, TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName, tag.Function_Name);
                TrasenFrame.Classes.WorkStaticFun.SaveSysLog(strLog, TrasenFrame.Forms.FrmMdiMain.CurrentSystem, tag, TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.Database);
            }
            catch (Exception error)
            {
                System.Collections.Generic.List<string> lstStr = new System.Collections.Generic.List<string>();
                lstStr.Add("记录菜单点击日志发生错误！");
                lstStr.Add("错误消息：" + error.Message);
                WriteFrameLocalLog(lstStr.ToArray(), true);
            }
        }

        #region 新的消息处理机制 add by wangzhi 2013-08-01
        //void messageControler_RecivedMessage( TrasenMessage.IMessageProcessor message  )
        //{
        //    //接收到消息后，异步委托调用消息显示
        //    ShowRecivedMessageHandler handler = new ShowRecivedMessageHandler( ShowReciveMessage );
        //    handler.BeginInvoke( message  , new AsyncCallback( ReciveMessageCallback ) , "" );
        //}
        ///// <summary>
        ///// 显示即时消息
        ///// </summary>
        ///// <param name="message"></param>
        ///// <param name="MsgParamter"></param>
        //private void ShowReciveMessage( TrasenMessage.IMessageProcessor IMessage  )
        //{
        //    TrasenMessage.MessageCommunication msg = (TrasenMessage.MessageCommunication)IMessage;
        //    lock ( _objLock )
        //    {
        //        msg.WriteMessage();

        //        if ( msg.ShowType == 0 )
        //        {
        //            //如果是气泡方式显示。对变量赋值后，由定时器去处理消息（待改进)
        //            this.newMsg = true;
        //            this.msgSender = msg.Sender;
        //            this.msgContents = msg.MessageString;
        //            this.showTime = msg.ShowTime;
        //            this.showMsg = false;
        //        }
        //        else
        //        {
        //            lock ( _objLock )
        //            {
        //                this.Invoke( new ShowMessageFormHandler( showMessagePopForm ) , msg );
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 异步委托的回调函数
        ///// </summary>
        ///// <param name="result"></param>
        //private void ReciveMessageCallback( IAsyncResult result )
        //{
        //    ShowRecivedMessageHandler hander = (ShowRecivedMessageHandler)( (System.Runtime.Remoting.Messaging.AsyncResult)result ).AsyncDelegate;
        //    hander.EndInvoke( result );
        //}
        ///// <summary>
        ///// 显示接收到的消息的委托
        ///// </summary>
        ///// <param name="message"></param>
        ///// <param name="MsgParamter"></param>
        //private delegate void ShowRecivedMessageHandler( TrasenMessage.IMessageProcessor message );
        ///// <summary>
        ///// 显示消息弹出窗口
        ///// </summary>
        ///// <param name="message"></param>
        //private void showMessagePopForm( TrasenMessage.MessageCommunication message )
        //{
        //    if ( dlgMsg == null )
        //    {
        //        dlgMsg = new TrasenMessage.DlgImmediatelyMessage();
        //        dlgMsg.MessageContentClicked += new TrasenMessage.OnMessageContentClickedHander( dlgMsg_MessageContentClicked );
        //        dlgMsg.SetCheckedMessageStatus +=new TrasenMessage.OnSetCheckedMessageStautsHandler(dlgMsg_SetCheckedMessageStatus);
        //        dlgMsg.TopMost = true;
        //    }
        //    dlgMsg.Show();
        //    dlgMsg.BringToFront();
        //    while ( !dlgMsg.IsHandleCreated )
        //    {
        //        //空循环，防止窗口句柄还未创建就执行Invoke方法
        //    }
        //    dlgMsg.AddMessage( message );
        //}
        /// <summary>
        /// 根据消息ID创建所需要的消息处理窗口，如子模块中的FORM等
        /// </summary>
        /// <param name="MessageId"></param>
        public void createMoudleForm(Guid MessageId)
        {
            try
            {
                TrasenFrame.Classes.MessageInfo message = new TrasenFrame.Classes.MessageInfo(MessageId, TrasenFrame.Forms.FrmMdiMain.Database);
                if (string.IsNullOrEmpty(message.AssemblyDLL))
                    return;
                //创建MenuTag
                TrasenFrame.Classes.MenuTag tag = TrasenFrame.Classes.MenuTag.GetTag(message.AssemblyDLL, message.AssemblyFuncationName, message.AssemblyTag,
                    message.AssemblyFormText, TrasenFrame.Forms.FrmMdiMain.Database);

                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd && tag.CanUsePublicPwd == false)
                {
                    MessageBox.Show("该菜单不允许使用公用密码！", "提示信息");
                    return;
                }

                object objForm = null;
                object[] commucationVal = new object[] { message.AssemblyParameter };
                if (MdiChildFormIsExist(this, tag.MenuName))
                {
                    objForm = this.ActiveMdiChild;
                }
                else
                {
                    RelationalDatabase jgbmDb = null;
                    try
                    {
                        //Modify By Tany 2010-01-14
                        //如果该菜单的连接指向不是本地，则使用指向的数据库连接
                        if (tag.Jgbm != -1 && tag.Jgbm != TrasenFrame.Forms.FrmMdiMain.Jgbm)
                        {
                            jgbmDb = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(tag.Jgbm);

                            objForm = TrasenFrame.Classes.WorkStaticFun.InstanceForm(tag.DllName, tag.Function_Name, tag.MenuName,
                             TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept, tag, tag.System.SystemId, this, jgbmDb, ref commucationVal);
                        }
                        else
                        {
                            objForm = TrasenFrame.Classes.WorkStaticFun.InstanceForm(tag.DllName, tag.Function_Name, tag.MenuName,
                             TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept, tag, tag.System.SystemId, this, TrasenFrame.Forms.FrmMdiMain.Database, ref commucationVal);
                        }
                        if (((Form)objForm).MdiParent != null)
                        {
                            ((Form)objForm).WindowState = FormWindowState.Maximized;
                            ((Form)objForm).Show();
                        }
                        else
                        {
                            ((Form)objForm).Show();
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "调用失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region 静默安装.net framework4.0
        private static void InstallDotNetFramework()
        {
            //dotNetFx40 静默安装
            //dotNetFx40_Full_x86_x64.exe /q /norestart /ChainingPackage FullX64Bootstrapper  
            DirectoryInfo[] directories = new DirectoryInfo(Environment.SystemDirectory + @"\..\Microsoft.NET\Framework").GetDirectories("v?.?.*");
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            foreach (DirectoryInfo info2 in directories)
            {
                string ver = info2.Name.Substring(1, 3);
                if (ver == "4.0")
                {
                    return;
                }
            }
            string installFile = System.Windows.Forms.Application.StartupPath + "\\DotNetFramework\\dotNetFx40_Full_x86_x64.exe";
            if (System.IO.File.Exists(installFile))
            {

                string args = "/q /norestart /ChainingPackage FullX64Bootstrapper";
                System.Diagnostics.Process.Start(installFile, args);
            }
            else
            {
                string message = string.Format("当前机器没有安装.Net Framework4.0, 并且未找到安装文件{0}", installFile);
                TrasenFrame.Classes.MessageInfo mi = new TrasenFrame.Classes.MessageInfo();
                mi.IsMustRead = false;
                mi.ShowTime = 5;
                mi.Summary = message;
                mi.ReciveStaffer = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                TrasenFrame.Classes.WorkStaticFun.SendMessage(mi);
            }
        }
        #endregion

        private void StartMesssageDectectProcess()
        {
            string exeName = System.Windows.Forms.Application.StartupPath + "\\tsmsgDtc.exe";
            if (!System.IO.File.Exists(exeName))
            {
                using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("TrasenMainWindow.Resources.tsmsgDtc.exe"))
                {
                    byte[] fileByte = new byte[(int)stream.Length];
                    stream.Read(fileByte, 0, (int)stream.Length);
                    using (System.IO.FileStream fs = new System.IO.FileStream(exeName, System.IO.FileMode.Create))
                    {
                        fs.Write(fileByte, 0, fileByte.Length);
                        fs.Flush();
                    }
                    stream.Close();
                }
            }
            if (!System.IO.File.Exists(exeName))
            {
                MessageBox.Show("未能启动消息侦听程序tsmsgDtc.exe", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int currentProcessId = System.Diagnostics.Process.GetCurrentProcess().Id;

            msgProcess = new System.Diagnostics.Process();
            msgProcess.StartInfo.FileName = exeName;
            msgProcess.StartInfo.Arguments = string.Format("/{0} /{1} /{2} /{3} /{4} /{5}",
                TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId,
                TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId,
                TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId,
                this.Handle,
                TrasenFrame.Forms.FrmMdiMain.PortNum,
                currentProcessId
                );
            msgProcess.Start();
            TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog(new string[] { "TrasenHIS进程:" + currentProcessId.ToString() + "启动的进程:" + msgProcess.Id }, true);
        }

        private void CloseMessageDectectProcess()
        {
            if (this.msgProcess != null)
            {
                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(msgProcess.Id);
                    if (p != null)
                    {
                        p.Kill();
                        p.Dispose();
                        p = null;
                    }
                }
                catch
                {
                    TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog(new string[] { "侦听消息进程未运行" }, true);
                }
            }
        }

        const int WM_COPYDATA = 0x004A;
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            string revMessage = "";
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                    Type mytype = mystr.GetType();
                    mystr = (COPYDATASTRUCT)m.GetLParam(mytype);
                    revMessage = mystr.lpData;
                    string flag = revMessage.Substring(0, 1);
                    string sValue = revMessage.Remove(0, 2);
                    if (flag == "0")
                    {
                        //接收到的是消息ID，表示需要进行处理的
                        createMoudleForm(new Guid(sValue));
                    }
                    else
                    {
                        string[] strDetail = sValue.Split(",".ToCharArray());
                        this.newMsg = true;
                        this.msgSender = strDetail[0];
                        this.msgContents = strDetail[1];
                        this.showTime = Convert.ToInt32(strDetail[2]);
                        this.showMsg = false;
                    }
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        //Add By Tany 2015-07-23
        /// <summary>
        /// 结束进程
        /// </summary>
        /// <param name="procName"></param>
        private static void KillProcess(string procName)
        {
            try
            {
                /**********使用cmd命令结束进程 add by wangzhi 2013-06-18*************/
                //Classes.Logger.Write("开始检测进程并结束相关进程");
                //定义要kill的进程列表
                List<string> lstExe = new List<string>();
                #region 要kill掉的HIS相关进程
                //lstExe.Add("TRASEN");
                //lstExe.Add("TRASEN.EXE");
                //lstExe.Add("NEUSOFT");
                //lstExe.Add("NEUSOFT.EXE");
                //lstExe.Add("ONKIY");
                //lstExe.Add("ONKIY.EXE");
                //lstExe.Add("NEUSOFTEMR");
                //lstExe.Add("NEUSOFTEMR.EXE");
                //lstExe.Add("TRASENEMR");
                //lstExe.Add("TRASENEMR.EXE");
                //lstExe.Add("EMRDOCORNURSEVIEW");
                //lstExe.Add("EMRDOCORNURSEVIEW.EXE");
                //lstExe.Add("EMRCONFIG");
                //lstExe.Add("EMRCONFIG.EXE");
                //lstExe.Add("CLIENTCONFIG");
                //lstExe.Add("CLIENTCONFIG.EXE");
                lstExe.Add(procName.ToUpper());
                lstExe.Add(procName.ToUpper() + ".EXE");
                #endregion

                #region 获取当前所有进程中在运行的HIS进程ID
                List<int> lstPID = new List<int>();
                try
                {
                    System.Diagnostics.Process[] proces = Process.GetProcesses();
                    foreach (Process p in proces)
                    {
                        //遍历当前所有进程，为防止改名，判断原始文件名，只要是HIS相关的程序就添加到KILL列表中
                        string originalFilename = "";
                        try
                        {
                            originalFilename = p.MainModule.FileVersionInfo.OriginalFilename.ToUpper();//转为大写
                        }
                        catch
                        {
                            //访问系统进程模块等的错误忽略
                            continue;
                        }
                        //执行文件名称不为空并且在删除列表中存在，则添加到KILL列表中
                        if (!string.IsNullOrEmpty(originalFilename) && lstExe.Contains(originalFilename))
                            lstPID.Add(p.Id);
                    }
                    //Classes.Logger.Write("遍历到相关进程共" + lstPID.Count.ToString());
                }
                catch (Exception error)
                {
                    //Classes.Logger.Write("遍历进程发生错误！", error);
                }
                #endregion

                //杀进程,调用taskkill命令强制结束进程   
                int killType = 1;
                foreach (int pid in lstPID)
                {
                    if (killType == 0)
                    {
                        #region 调用cmd.exe结束进程
                        //Classes.Logger.Write("开始尝试结束进程" + pid.ToString());

                        System.Diagnostics.Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";

                        cmd.StartInfo.UseShellExecute = false;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardError = true;
                        cmd.StartInfo.CreateNoWindow = true;

                        string command = "taskkill /PID " + pid + " /F /T";
                        cmd.Start();
                        cmd.StandardInput.WriteLine(command);
                        //Classes.Logger.Write(command);

                        cmd.StandardInput.WriteLine("exit");
                        //Classes.Logger.Write("exit");
                        cmd.WaitForExit();
                        cmd.Close();

                        //Classes.Logger.Write("执行结束！");
                        #endregion
                    }
                    else
                    {
                        #region 使用Process类结束进程
                        try
                        {
                            //第一次开始查找进程ID
                            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(pid);
                            int count = 1;
                            int maxCount = 3;
                            //如果找到进程，进入循环尝试结束进程，次数为maxCount指定
                            while (count <= maxCount)
                            {
                                //Classes.Logger.Write(string.Format("正在第{0}尝试结束进程{1}", count, pid));
                                p.Kill();
                                p.WaitForExit();
                                try
                                {
                                    //重新根据ID获取进程
                                    p = System.Diagnostics.Process.GetProcessById(pid);
                                }
                                catch
                                {
                                    //如果发生ArgementException,说明进程已经结束,跳出while循环
                                    //Classes.Logger.Write(string.Format("进程{0}已经结束", pid));
                                    break;
                                }

                                if (count == maxCount)
                                {
                                    //如果尝试次数到达限定次数，跳出循环
                                    //Classes.Logger.Write(string.Format("尝试连续{0}次结束进程{1}失败！", maxCount, pid));
                                    break;
                                }
                                else
                                {
                                    //重新根据ID获取进程的操作如果成功，则进行下一次循环来结束进程
                                    count++;
                                }
                            }
                        }
                        catch (ArgumentException argex)
                        {
                            //第一次开始查找进程发生错误
                            //Classes.Logger.Write(string.Format("进程{0}未启动或已结束！", pid));
                        }
                        catch (Exception error)
                        {
                            //Classes.Logger.Write(string.Format("在结束进程{0}时发生错误", error));
                        }
                        #endregion
                    }
                }
                //Classes.Logger.Write("检测进程并结束相关进程的处理结束");
                return;
            }
            catch
            {
                //throw new Exception("升级程序无法关闭" + procName + "应用程序，请手工关闭程序后再试" + err.Message);
                //MessageBox.Show("升级程序无法关闭相关应用程序，请手工关闭程序后再试" + err.Message);
                //return;
            }
        }

        #region 启动LIS的危急值程序 Add By Tany 2015-07-23
        /// <summary>
        /// 启动LIS危急值
        /// </summary>
        private static void LoadLisWjz()
        {
            try
            {
                KillProcess("CISMsg");

                string path = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\CISMsg.exe";

                if (System.IO.File.Exists(path))
                {
                    string rylx = "";
                    switch (TrasenFrame.Forms.FrmMdiMain.CurrentUser.Rylx)
                    {
                        case EmployeeType.医生:
                            rylx = "医生";
                            break;
                        case EmployeeType.护士:
                            rylx = "护士";
                            break;
                        default:
                            rylx = "其他";
                            break;
                    }
                    string ksdm = Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select oldid from datamap where newtable='jc_dept_property' and newid='" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "'"), "");
                    ////血液内科病区 (科室名称)   ，  医生 （如果是医生就传 ” 医生“   如果是护士就传  ”护士“）  ，  D1234(登陆人ID)  ， 123 科室ID  ，测试人（登陆人姓名）
                    string cs = "" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName + "," + rylx + "," + TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode + "," + ksdm + "," + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name + "";
                    System.Diagnostics.Process.Start(path, cs);
                    return;
                }
            }
            catch
            {
            }
        }
        #endregion

        #region 启动LIS的危急值程序 Add By HYD 2017-09-20

        private static void LoadPACSWjz()
        {
            try
            {
                KillProcess("IMCISClientTool");

                string path = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\IMCISClientTool.exe";
               // string path = @"C:\Program Files\IMCISPlugin\" + "\\IMCISClientTool.exe";

                if (System.IO.File.Exists(path))
                {
                    /* string rylx = "";
                     switch (TrasenFrame.Forms.FrmMdiMain.CurrentUser.Rylx)
                     {
                         case EmployeeType.医生:
                             rylx = "医生";
                             break;
                         case EmployeeType.护士:
                             rylx = "护士";
                             break;
                         default:
                             rylx = "其他";
                             break;
                     }
                   

                     string ksdm = Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select oldid from datamap where newtable='jc_dept_property' and newid='" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "'"), "");
                     //血液内科病区 (科室名称)   ，  医生 （如果是医生就传 ” 医生“   如果是护士就传  ”护士“）  ，  D1234(登陆人ID)  ， 123 科室ID  ，测试人（登陆人姓名）
                    string cs = "" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName + "," + rylx + "," + TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode + "," + ksdm + "," + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name + "";
                     */

                    // 调用方式为：C:\Program Files\IMCISPlugin\IMCISClientTool.exe 用户工号,用户姓名,科室ID,科室名称,病区

                    string BQMC = Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select top 1 WARD_NAME from JC_WARD where DEPT_ID='" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "'"), "");

                    string UserGH = Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select code  from Pub_User where Employee_Id='" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + "'"), "");
                    string cs = "" + UserGH + "," + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name + "," + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "," + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName + "," + BQMC + "";
                   // MessageBox.Show("PACS");
                    System.Diagnostics.Process.Start(path, cs);
                   // MessageBox.Show("PACS");
                    return;
                }
            }
            catch
            {
            }
        }
        #endregion


        #region 启动ntp时间服务器同步 Add By Tany 2015-10-30
        /// <summary>
        /// 启动ntp时间服务器同步
        /// </summary>
        private static void Loadntp()
        {
            try
            {
                KillProcess("ntp");

                string path = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\ntp.exe";

                if (System.IO.File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                    return;
                }
            }
            catch
            {
            }
        }

        #endregion
    }
}
