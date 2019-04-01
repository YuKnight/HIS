using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Management;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using System.Xml;
using System.Drawing.Drawing2D;
using System.Data.OleDb;
using System.Drawing.Printing;
using ts_zyhs_classes;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralControls;
using PinkieControls;
using UtilityLibrary.WinControls;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using Ts_zyys_yspb;
using Ts_zyys_zhcx;
using ts_zyhs_cwyl;
using Ts_zyys_public;
using ts_lis_mzzyQuery;
using 病人信息;
using System.Net;
using ts_his_aqyjwb;
using System.Collections.Generic;
using Ts_Hlyy_Interface;
using System.Text;


namespace Ts_zyys_main
{
    /// <summary>
    /// frmMain 的摘要说明。
    /// </summary>
    public class frmMain : System.Windows.Forms.Form
    {
        delegate void Callback(ListView list);
        [DllImport("user32.dll")]
        static extern int GetScrollPos(IntPtr hwnd, int bar);
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern bool PostMessage(int hWnd, int Msg, int wParam, int lParam);
        //API函数申明
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        public delegate void txgb(int i, int index);
        public delegate void Delegtesroll(int i, int index, ListView lv);


        /// <summary>
        /// 是否使用合理用药
        /// </summary>
        string cfg6032 = new SystemCfg(6032).Config.Trim();
        /// <summary>
        /// 合理用药接口 add by jchl 2011-12-24
        /// </summary>
        HlyyInterface hl = null;

        #region 自定义变量
        public OleDbConnection cCon = new OleDbConnection();
        public long YS_ID = 0;
        public long BinID = 0;
        public DataTable TSTb = new DataTable();
        public long DeptID = 0;
        public int WardID = 0;
        private long Ward_dept = 0;
        private string STAG = "";
        private long DeptBR = 0;
        /// <summary>
        /// 是否开单科室领药 0=不领1=领药
        /// </summary>
        public int _iskdksly = 0;//是否开单科室领药 Modify By Tany 2009-07-15 
        private bool _istszlks = false;//是否特殊治疗科室
        private long _currentUser;
        private long _currentDept;
        private DbQuery myQuery = new DbQuery();
        public DataView SelectDataView = null;
        public static User Current_User;
        public static Department Current_Dept;			///系统当前登录的部门
        private MenuTag tag = new MenuTag();
        private string editingFileName = null;
        private bool dirty = false;
        private static readonly string noFilename = "交班公告";
        //		private static readonly string notDirtyCaptionFormat = "住院医生站系统  {0} - 记事公告";
        //		private static readonly string dirtyCaptionFormat = "住院医生站系统  {0}* - 记事公告";
        private int m_nFirstCharOnPage = 0;
        private bool fileOnDiskModified = false;
        private Guid sBinID = Guid.Empty;
        private string sWardID = "";
        private long sWard_dept = 0;
        private long lg = 0;
        ResourceManager rmListImages = null;
        ImageList outlookLargeIcons = null;
        private string richText = "";
        private bool isClose = true;//是否要关闭
        private bool isCloseC = true;
        public static bool outflag = false;//是否是出院或死亡状态
        public static Guid[] openForm = new Guid[10]; //被打开的医嘱管理窗体，限制为10个
        private bool isWard = true;//是否为医生所属科室的病人
        public string ExePath = Application.StartupPath;
        private DataTable MessageTb = new DataTable();
        private bool SelEnd = false;//是否选项页面显示改变结束
        //add by zouchihua 2012-6-26
        private SystemCfg cfg6050 = new SystemCfg(6050);
        private SystemCfg cfg6051;
        private SystemCfg cfg18003;
        private SystemCfg cfg6083 = new SystemCfg(6083);
        private SystemCfg cfg6098 = new SystemCfg(6098);
        /// <summary>
        /// 住院医生站是否提示为完成的手术和会诊 0=否，1=是
        /// </summary>
        private SystemCfg cfg6076 = new SystemCfg(6076);
        private SystemCfg cfg6077 = new SystemCfg(6077);

        SystemCfg cfg7205 = new SystemCfg(7205);//yaokx2014-06-27

        public delegate void del();
        PictureBox[] gb;
        PictureBox[] Cpgb;
        Thread[] thr;
        Thread LisThr;
        private int Firstflag = 0;
        int Jsq = 0;
        /// <summary>
        /// lis危机值表
        /// </summary>
        DataTable wjzTb;
        /// <summary>
        /// 医技发送过来的消息
        /// </summary>
        DataTable Yjtb;
        #endregion

        #region  初始化录入病历首页
        PatientCaseCase.FrmNavigation frmNavigation = null;
        #endregion

        #region 系统自动生成变量
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private UtilityLibrary.WinControls.OutlookBar outlookBar1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ToolBarButton toolBarButton4;
        private System.Windows.Forms.ToolBarButton toolBarButton5;
        private System.Windows.Forms.ToolBarButton toolBarButton6;
        private System.Windows.Forms.ToolBarButton toolBarButton7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuItem menuItem18;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel4;
        private 病人信息.PatientInfo patientInfo1;
        private System.Windows.Forms.GroupBox ddd;
        private PinkieControls.ButtonXP btnEdit;
        private PinkieControls.ButtonXP btnSave;
        private PinkieControls.ButtonXP btnSaveAs;
        private PinkieControls.ButtonXP btnPrint;
        private TrasenClasses.GeneralControls.RichTextBoxEx richTextBoxEx1;
        private System.Windows.Forms.PrintDialog printDialog;
        protected internal System.Windows.Forms.OpenFileDialog openFileDialog1;
        protected internal System.Windows.Forms.SaveFileDialog saveFileDialog1;
        protected internal System.IO.FileSystemWatcher dirWatcher;
        private PinkieControls.ButtonXP btnOpen;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.ComponentModel.IContainer components;
        private Ts_zyys_main.myListview listView2;//Modify by zouchihua 2012-6-26
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem35;
        private System.Windows.Forms.MenuItem menuItem36;
        private System.Windows.Forms.MenuItem menuItem48;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuItem menuItem54;
        private System.Windows.Forms.MenuItem menuItem55;
        private System.Windows.Forms.MenuItem menuItem57;
        private System.Windows.Forms.ToolBarButton toolBarButton8;
        private System.Windows.Forms.MenuItem menuItem21;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.MenuItem menuItem61;
        private System.Windows.Forms.MenuItem menuItem62;
        private System.Windows.Forms.ContextMenu contextMenu2;
        private System.Windows.Forms.MenuItem menuItem64;
        private System.Windows.Forms.MenuItem menuItem65;
        private System.Windows.Forms.MenuItem menuItem66;
        private System.Windows.Forms.MenuItem menuItem67;
        private System.Windows.Forms.MenuItem menuItem68;
        private System.Windows.Forms.MenuItem menuItem69;
        private System.Windows.Forms.MenuItem menuItem70;
        private System.Windows.Forms.MenuItem menuItem71;
        private System.Windows.Forms.MenuItem menuItem72;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem menuItem77;
        private System.Windows.Forms.MenuItem menuItem78;
        private System.Windows.Forms.MenuItem menuItem80;
        private System.Windows.Forms.MenuItem menuItem84;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView listView3;
        private 病人信息.PatientInfo patientInfo2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTBoxCon;
        private System.Windows.Forms.ColumnHeader col_BinID;
        private System.Windows.Forms.ColumnHeader col_ZYH;
        private System.Windows.Forms.ColumnHeader col_Name;
        private System.Windows.Forms.ColumnHeader col_Ward;
        private System.Windows.Forms.ColumnHeader col_DeptID;
        private System.Windows.Forms.ColumnHeader col_SQRQ;
        private System.Windows.Forms.ColumnHeader col_SQYS;
        private System.Windows.Forms.ColumnHeader col_ConText;
        private System.Windows.Forms.MenuItem menuItem88;
        private System.Windows.Forms.MenuItem menuItem89;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private 病人信息.PatientInfo patientInfo3;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.RichTextBox richTBoxJR;
        private System.Windows.Forms.ImageList imageList4;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList0;
        private System.Windows.Forms.MenuItem menuItem_YZGL;
        private System.Windows.Forms.MenuItem menuItem_JCSQ;
        private System.Windows.Forms.MenuItem menuItem_JYSQ;
        private System.Windows.Forms.MenuItem menuItem_ZLSQ;
        private System.Windows.Forms.MenuItem menuItem_SSSQ;
        private System.Windows.Forms.MenuItem menuItem_TS;
        private System.Windows.Forms.MenuItem menuItem_HZ;
        private System.Windows.Forms.MenuItem menuItem_YY;
        private System.Windows.Forms.MenuItem menuItem_BRXX;
        private System.Windows.Forms.MenuItem menuItem_BRFY;
        private System.Windows.Forms.MenuItem menuItem_SCD;
        private System.Windows.Forms.MenuItem menuItem_SCJL;
        private System.Windows.Forms.MenuItem menuItem_WZJL;
        private System.Windows.Forms.MenuItem menuItem_JSYP;
        private System.Windows.Forms.MenuItem menuItem_XMCX;
        private System.Windows.Forms.MenuItem menuItem_YFCX;
        private System.Windows.Forms.MenuItem menuItem_BQ;
        private System.Windows.Forms.MenuItem menuItem_FYTJ;
        private System.Windows.Forms.MenuItem menuItem_YSPB;
        private Ts_zyys_main.myListview listView1;//Modify by zouchihua 2012-6-22
        private System.Windows.Forms.ImageList imageList_png;
        private System.Windows.Forms.MenuItem menuItem_WHJL;
        private DougScrollingTextCtr dougScrollingTextCtr1;
        private System.Windows.Forms.Button bt_CW;
        private System.Windows.Forms.Button bt_RF;
        private System.Windows.Forms.ImageList imageList5;
        private System.Windows.Forms.MenuItem menuItem1;
        private TrasenClasses.GeneralControls.LabelEx xcjwLabel1;
        private System.Windows.Forms.ImageList imgBED;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ComboBox cmbWard;
        private TabPage tabPage5;
        private DataGridView dgvPat;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 特殊治疗完成ToolStripMenuItem;
        private ColumnHeader columnHeader9;
        private TabPage tabPage6;
        private DataGridView dgvTodayIn;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem 刷新全部未完成ToolStripMenuItem;
        private ToolStripMenuItem 查询全部已完成ToolStripMenuItem;
        private ToolTip toolTip1;
        private MenuItem menuItem2;
        private MenuItem miPatPacs;
        private ColumnHeader col_hzid;
        private ImageList ImageTsd;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem 分娩ToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private CheckBox checkCpIN;
        private ImageList ImgCp;
        private MenuItem menuItem3;
        private MenuItem menuItem7;
        private MenuItem menuItem9;
        private ColumnHeader col_babyid;
        private CheckBox checkDbz;
        private MenuItem menuItem10;
        private ToolStripMenuItem 查询ToolStripMenuItem;
        private ColumnHeader col_level;
        private MenuItem menuItem11;
        private MenuItem menuItem13;
        private MenuItem menuItem14;
        private TabPage tabPage7;
        private myListview myListview1;
        private BackgroundWorker backgroundWorker1;
        private Button butt_ks;
        private MenuItem menuItem15;
        private Button btSyncOldHISPatInfo;
        private Button btReComputeRate;
        private TextBox textBox1;
        private Label label15;
        private Button button1;
        private Button button2;
        private MenuItem menuItem19;
        private MenuItem menuItem20;
        private MenuItem menuItem17;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        #endregion

        #region 构造函数
        public frmMain(long currentUser, long currentDept, string formText, int right)
        {
            this.Cursor = PubStaticFun.WaitCursor();

            Assembly thisAssembly = Assembly.GetAssembly(Type.GetType("Ts_zyys_main.frmMain"));
            rmListImages = new ResourceManager("Ts_zyys_main.Resources.IconImages", thisAssembly);
            outlookLargeIcons = new ImageList();
            outlookLargeIcons.ImageSize = new Size(32, 32);
            Bitmap icons = (Bitmap)rmListImages.GetObject("OutlookLargeIcons");
            icons.MakeTransparent(Color.FromArgb(255, 0, 255));
            outlookLargeIcons.Images.AddStrip(icons);

            //
            // Windows 窗体设计器支持所必需的
            //

            InitializeComponent();
            _currentUser = currentUser;
            _currentDept = currentDept;

            Current_User = new User(Convert.ToInt32(currentUser), FrmMdiMain.Database);
            Current_Dept = new Department(Convert.ToInt32(currentDept), FrmMdiMain.Database);

            //得到登陆的医生ID
            this.YS_ID = Current_User.EmployeeId;
            this.DeptID = Convert.ToInt32(currentDept);
            this.WardID = Current_Dept.DeptId; ;
            this.Ward_dept = Current_Dept.DeptId;
            this.lg = right;
            this.Text = formText;
            if (cfg6098.Config == "1")//yaokx 2014-06-21 初始化窗体
            {
                frmNavigation = new PatientCaseCase.FrmNavigation(InstanceForm._currentUser.Name);
            }
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }


        #endregion

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (isClose == false) return;
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem62 = new System.Windows.Forms.MenuItem();
            this.menuItem35 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem36 = new System.Windows.Forms.MenuItem();
            this.menuItem61 = new System.Windows.Forms.MenuItem();
            this.menuItem48 = new System.Windows.Forms.MenuItem();
            this.menuItem54 = new System.Windows.Forms.MenuItem();
            this.menuItem77 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem78 = new System.Windows.Forms.MenuItem();
            this.menuItem_WHJL = new System.Windows.Forms.MenuItem();
            this.menuItem84 = new System.Windows.Forms.MenuItem();
            this.miPatPacs = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.outlookBar1 = new UtilityLibrary.WinControls.OutlookBar();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton8 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.imageList_png = new System.Windows.Forms.ImageList(this.components);
            this.imageList4 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem_YZGL = new System.Windows.Forms.MenuItem();
            this.menuItem88 = new System.Windows.Forms.MenuItem();
            this.menuItem_JCSQ = new System.Windows.Forms.MenuItem();
            this.menuItem_JYSQ = new System.Windows.Forms.MenuItem();
            this.menuItem_ZLSQ = new System.Windows.Forms.MenuItem();
            this.menuItem89 = new System.Windows.Forms.MenuItem();
            this.menuItem_HZ = new System.Windows.Forms.MenuItem();
            this.menuItem_SSSQ = new System.Windows.Forms.MenuItem();
            this.menuItem_TS = new System.Windows.Forms.MenuItem();
            this.menuItem_YY = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem55 = new System.Windows.Forms.MenuItem();
            this.menuItem_BRXX = new System.Windows.Forms.MenuItem();
            this.menuItem_BRFY = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem_SCD = new System.Windows.Forms.MenuItem();
            this.menuItem_SCJL = new System.Windows.Forms.MenuItem();
            this.menuItem_WZJL = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem57 = new System.Windows.Forms.MenuItem();
            this.menuItem_XMCX = new System.Windows.Forms.MenuItem();
            this.menuItem_YFCX = new System.Windows.Forms.MenuItem();
            this.menuItem_JSYP = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem_FYTJ = new System.Windows.Forms.MenuItem();
            this.menuItem80 = new System.Windows.Forms.MenuItem();
            this.menuItem_YSPB = new System.Windows.Forms.MenuItem();
            this.menuItem_BQ = new System.Windows.Forms.MenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new Ts_zyys_main.myListview();
            this.imgBED = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBoxEx1 = new TrasenClasses.GeneralControls.RichTextBoxEx(this.components);
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem64 = new System.Windows.Forms.MenuItem();
            this.menuItem67 = new System.Windows.Forms.MenuItem();
            this.menuItem65 = new System.Windows.Forms.MenuItem();
            this.menuItem66 = new System.Windows.Forms.MenuItem();
            this.menuItem68 = new System.Windows.Forms.MenuItem();
            this.menuItem69 = new System.Windows.Forms.MenuItem();
            this.menuItem70 = new System.Windows.Forms.MenuItem();
            this.menuItem71 = new System.Windows.Forms.MenuItem();
            this.menuItem72 = new System.Windows.Forms.MenuItem();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ddd = new System.Windows.Forms.GroupBox();
            this.btnOpen = new PinkieControls.ButtonXP();
            this.btnEdit = new PinkieControls.ButtonXP();
            this.btnSave = new PinkieControls.ButtonXP();
            this.btnSaveAs = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.patientInfo1 = new 病人信息.PatientInfo();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new Ts_zyys_main.myListview();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.myListview1 = new Ts_zyys_main.myListview();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.col_BinID = new System.Windows.Forms.ColumnHeader();
            this.col_ZYH = new System.Windows.Forms.ColumnHeader();
            this.col_Name = new System.Windows.Forms.ColumnHeader();
            this.col_Ward = new System.Windows.Forms.ColumnHeader();
            this.col_DeptID = new System.Windows.Forms.ColumnHeader();
            this.col_SQRQ = new System.Windows.Forms.ColumnHeader();
            this.col_SQYS = new System.Windows.Forms.ColumnHeader();
            this.col_ConText = new System.Windows.Forms.ColumnHeader();
            this.col_hzid = new System.Windows.Forms.ColumnHeader();
            this.col_babyid = new System.Windows.Forms.ColumnHeader();
            this.col_level = new System.Windows.Forms.ColumnHeader();
            this.panel5 = new System.Windows.Forms.Panel();
            this.richTBoxCon = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.patientInfo2 = new 病人信息.PatientInfo();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.特殊治疗完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新全部未完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询全部已完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.分娩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel6 = new System.Windows.Forms.Panel();
            this.richTBoxJR = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.patientInfo3 = new 病人信息.PatientInfo();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvPat = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dgvTodayIn = new System.Windows.Forms.DataGridView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dirWatcher = new System.IO.FileSystemWatcher();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.bt_RF = new System.Windows.Forms.Button();
            this.bt_CW = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.imageList0 = new System.Windows.Forms.ImageList(this.components);
            this.imageList5 = new System.Windows.Forms.ImageList(this.components);
            this.cmbWard = new System.Windows.Forms.ComboBox();
            this.xcjwLabel1 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ImageTsd = new System.Windows.Forms.ImageList(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.ImgCp = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.butt_ks = new System.Windows.Forms.Button();
            this.checkCpIN = new System.Windows.Forms.CheckBox();
            this.checkDbz = new System.Windows.Forms.CheckBox();
            this.btSyncOldHISPatInfo = new System.Windows.Forms.Button();
            this.btReComputeRate = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dougScrollingTextCtr1 = new Ts_zyys_main.DougScrollingTextCtr();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ddd.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPat)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dirWatcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem2,
            this.menuItem14,
            this.menuItem62,
            this.menuItem35,
            this.menuItem6,
            this.menuItem36,
            this.menuItem61,
            this.menuItem48,
            this.menuItem54,
            this.menuItem77,
            this.menuItem84,
            this.miPatPacs,
            this.menuItem15,
            this.menuItem3,
            this.menuItem7,
            this.menuItem9,
            this.menuItem10,
            this.menuItem11,
            this.menuItem13,
            this.menuItem19,
            this.menuItem20,
            this.menuItem17});
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "医嘱录入";
            this.menuItem4.Popup += new System.EventHandler(this.menuItem4_Popup);
            this.menuItem4.Click += new System.EventHandler(this.menuItem_YZGL_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 2;
            this.menuItem14.Text = "病历书写";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem62
            // 
            this.menuItem62.Index = 3;
            this.menuItem62.Text = "-";
            // 
            // menuItem35
            // 
            this.menuItem35.Index = 4;
            this.menuItem35.Text = "检验申请";
            this.menuItem35.Click += new System.EventHandler(this.menuItem_JYSQ_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Text = "检查申请";
            this.menuItem6.Click += new System.EventHandler(this.menuItem_JCSQ_Click);
            // 
            // menuItem36
            // 
            this.menuItem36.Index = 6;
            this.menuItem36.Text = "治疗申请";
            this.menuItem36.Click += new System.EventHandler(this.menuItem_ZLSQ_Click);
            // 
            // menuItem61
            // 
            this.menuItem61.Index = 7;
            this.menuItem61.Text = "-";
            // 
            // menuItem48
            // 
            this.menuItem48.Index = 8;
            this.menuItem48.Text = "会诊申请";
            this.menuItem48.Click += new System.EventHandler(this.menuItem_HZ_Click);
            // 
            // menuItem54
            // 
            this.menuItem54.Index = 9;
            this.menuItem54.Text = "医嘱查询";
            this.menuItem54.Visible = false;
            this.menuItem54.Click += new System.EventHandler(this.menuItem54_Click);
            // 
            // menuItem77
            // 
            this.menuItem77.Index = 10;
            this.menuItem77.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem78,
            this.menuItem_WHJL});
            this.menuItem77.Text = "护理信息";
            this.menuItem77.Visible = false;
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "三测单查询";
            this.menuItem5.Click += new System.EventHandler(this.menuItem_SCD_Click);
            // 
            // menuItem78
            // 
            this.menuItem78.Index = 1;
            this.menuItem78.Text = "四测记录";
            this.menuItem78.Click += new System.EventHandler(this.menuItem_SCJL_Click);
            // 
            // menuItem_WHJL
            // 
            this.menuItem_WHJL.Index = 2;
            this.menuItem_WHJL.Text = "危重患者护理记录";
            this.menuItem_WHJL.Click += new System.EventHandler(this.menuItem_WHJL_Click);
            // 
            // menuItem84
            // 
            this.menuItem84.Index = 11;
            this.menuItem84.Text = "会诊医嘱";
            this.menuItem84.Visible = false;
            this.menuItem84.Click += new System.EventHandler(this.menuItem84_Click);
            // 
            // miPatPacs
            // 
            this.miPatPacs.Index = 12;
            this.miPatPacs.Text = "病人PACS结果查询";
            this.miPatPacs.Visible = false;
            this.miPatPacs.Click += new System.EventHandler(this.miPatPacs_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 13;
            this.menuItem15.Text = "病人病理结果查询";
            this.menuItem15.Visible = false;
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 14;
            this.menuItem3.Text = "-";
            this.menuItem3.Visible = false;
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 15;
            this.menuItem7.Text = "进入路径";
            this.menuItem7.Visible = false;
            this.menuItem7.Popup += new System.EventHandler(this.menuItem7_Popup);
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 16;
            this.menuItem9.Text = "退出路径";
            this.menuItem9.Visible = false;
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 17;
            this.menuItem10.Text = "进入单病种";
            this.menuItem10.Visible = false;
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 18;
            this.menuItem11.Text = "安全预警登记";
            this.menuItem11.Visible = false;
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 19;
            this.menuItem13.Text = "-";
            this.menuItem13.Visible = false;
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 20;
            this.menuItem19.Text = "历史病历";
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 21;
            this.menuItem20.Text = "检查报告";
            this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
            // 
            // outlookBar1
            // 
            this.outlookBar1.AnimationSpeed = 20;
            this.outlookBar1.BackColor = System.Drawing.SystemColors.Control;
            this.outlookBar1.BackgroundBitmap = null;
            this.outlookBar1.BorderType = UtilityLibrary.WinControls.BorderType.Fixed3D;
            this.outlookBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outlookBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.outlookBar1.FlatArrowButtons = false;
            this.outlookBar1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.outlookBar1.LeftTopColor = System.Drawing.Color.Empty;
            this.outlookBar1.Location = new System.Drawing.Point(0, 71);
            this.outlookBar1.Name = "outlookBar1";
            this.outlookBar1.RightBottomColor = System.Drawing.Color.Empty;
            this.outlookBar1.Size = new System.Drawing.Size(104, 293);
            this.outlookBar1.TabIndex = 27;
            this.outlookBar1.Text = "outlookBar1";
            this.outlookBar1.Click += new System.EventHandler(this.outlookBar1_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton2,
            this.toolBarButton3,
            this.toolBarButton4,
            this.toolBarButton5,
            this.toolBarButton7,
            this.toolBarButton8,
            this.toolBarButton6});
            this.toolBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList_png;
            this.toolBar1.Location = new System.Drawing.Point(0, 23);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(1028, 44);
            this.toolBar1.TabIndex = 29;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 0;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.toolBarButton1.Tag = "医嘱录入";
            this.toolBarButton1.ToolTipText = "医嘱录入";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 8;
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.toolBarButton2.Tag = "病案首页";
            this.toolBarButton2.ToolTipText = "病案首页";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.ImageIndex = 17;
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Tag = "会诊申请";
            this.toolBarButton3.ToolTipText = "会诊申请";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.toolBarButton4.Tag = "";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.ImageIndex = 3;
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Tag = "检验申请";
            this.toolBarButton5.ToolTipText = "检验申请";
            // 
            // toolBarButton7
            // 
            this.toolBarButton7.ImageIndex = 2;
            this.toolBarButton7.Name = "toolBarButton7";
            this.toolBarButton7.Tag = "检查申请";
            this.toolBarButton7.ToolTipText = "检查申请";
            // 
            // toolBarButton8
            // 
            this.toolBarButton8.Name = "toolBarButton8";
            this.toolBarButton8.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.ImageIndex = 18;
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Tag = "EXIT";
            this.toolBarButton6.ToolTipText = "退出系统";
            // 
            // imageList_png
            // 
            this.imageList_png.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_png.ImageStream")));
            this.imageList_png.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_png.Images.SetKeyName(0, "");
            this.imageList_png.Images.SetKeyName(1, "");
            this.imageList_png.Images.SetKeyName(2, "");
            this.imageList_png.Images.SetKeyName(3, "");
            this.imageList_png.Images.SetKeyName(4, "");
            this.imageList_png.Images.SetKeyName(5, "");
            this.imageList_png.Images.SetKeyName(6, "");
            this.imageList_png.Images.SetKeyName(7, "");
            this.imageList_png.Images.SetKeyName(8, "");
            this.imageList_png.Images.SetKeyName(9, "");
            this.imageList_png.Images.SetKeyName(10, "");
            this.imageList_png.Images.SetKeyName(11, "");
            this.imageList_png.Images.SetKeyName(12, "");
            this.imageList_png.Images.SetKeyName(13, "");
            this.imageList_png.Images.SetKeyName(14, "");
            this.imageList_png.Images.SetKeyName(15, "");
            this.imageList_png.Images.SetKeyName(16, "");
            this.imageList_png.Images.SetKeyName(17, "");
            this.imageList_png.Images.SetKeyName(18, "");
            this.imageList_png.Images.SetKeyName(19, "");
            this.imageList_png.Images.SetKeyName(20, "");
            this.imageList_png.Images.SetKeyName(21, "");
            // 
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "");
            this.imageList4.Images.SetKeyName(1, "");
            this.imageList4.Images.SetKeyName(2, "");
            this.imageList4.Images.SetKeyName(3, "");
            this.imageList4.Images.SetKeyName(4, "");
            this.imageList4.Images.SetKeyName(5, "");
            this.imageList4.Images.SetKeyName(6, "");
            this.imageList4.Images.SetKeyName(7, "");
            this.imageList4.Images.SetKeyName(8, "");
            this.imageList4.Images.SetKeyName(9, "");
            this.imageList4.Images.SetKeyName(10, "");
            this.imageList4.Images.SetKeyName(11, "");
            this.imageList4.Images.SetKeyName(12, "");
            this.imageList4.Images.SetKeyName(13, "");
            this.imageList4.Images.SetKeyName(14, "");
            this.imageList4.Images.SetKeyName(15, "");
            this.imageList4.Images.SetKeyName(16, "");
            this.imageList4.Images.SetKeyName(17, "");
            this.imageList4.Images.SetKeyName(18, "");
            this.imageList4.Images.SetKeyName(19, "");
            this.imageList4.Images.SetKeyName(20, "");
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 4);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem12,
            this.menuItem18});
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_YZGL,
            this.menuItem88,
            this.menuItem_JCSQ,
            this.menuItem_JYSQ,
            this.menuItem_ZLSQ,
            this.menuItem89,
            this.menuItem_HZ,
            this.menuItem_SSSQ,
            this.menuItem_TS,
            this.menuItem_YY});
            this.menuItem8.MergeOrder = 1;
            this.menuItem8.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.menuItem8.Text = "   日常业务 (&W)";
            // 
            // menuItem_YZGL
            // 
            this.menuItem_YZGL.Index = 0;
            this.menuItem_YZGL.Text = "医嘱管理 (&D)";
            this.menuItem_YZGL.Click += new System.EventHandler(this.menuItem_YZGL_Click);
            // 
            // menuItem88
            // 
            this.menuItem88.Index = 1;
            this.menuItem88.Text = "-";
            // 
            // menuItem_JCSQ
            // 
            this.menuItem_JCSQ.Index = 2;
            this.menuItem_JCSQ.Text = "检查申请 (&I)";
            this.menuItem_JCSQ.Click += new System.EventHandler(this.menuItem_JCSQ_Click);
            // 
            // menuItem_JYSQ
            // 
            this.menuItem_JYSQ.Index = 3;
            this.menuItem_JYSQ.Text = "检验申请 (&L)";
            this.menuItem_JYSQ.Click += new System.EventHandler(this.menuItem_JYSQ_Click);
            // 
            // menuItem_ZLSQ
            // 
            this.menuItem_ZLSQ.Index = 4;
            this.menuItem_ZLSQ.Text = "治疗申请 (&C)";
            this.menuItem_ZLSQ.Click += new System.EventHandler(this.menuItem_ZLSQ_Click);
            // 
            // menuItem89
            // 
            this.menuItem89.Index = 5;
            this.menuItem89.Text = "-";
            // 
            // menuItem_HZ
            // 
            this.menuItem_HZ.Index = 6;
            this.menuItem_HZ.Text = "会诊管理";
            this.menuItem_HZ.Click += new System.EventHandler(this.menuItem_HZ_Click);
            // 
            // menuItem_SSSQ
            // 
            this.menuItem_SSSQ.Index = 7;
            this.menuItem_SSSQ.Text = "手术申请 (&T)";
            this.menuItem_SSSQ.Click += new System.EventHandler(this.menuItem_SSSQ_Click);
            // 
            // menuItem_TS
            // 
            this.menuItem_TS.Index = 8;
            this.menuItem_TS.Text = "特殊治疗(&J)";
            this.menuItem_TS.Visible = false;
            this.menuItem_TS.Click += new System.EventHandler(this.menuItem_TS_Click);
            // 
            // menuItem_YY
            // 
            this.menuItem_YY.Index = 9;
            this.menuItem_YY.Text = "预约查询(打印)";
            this.menuItem_YY.Visible = false;
            this.menuItem_YY.Click += new System.EventHandler(this.menuItem_YY_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 1;
            this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem55,
            this.menuItem_BRXX,
            this.menuItem_BRFY,
            this.menuItem16,
            this.menuItem1,
            this.menuItem57,
            this.menuItem_XMCX,
            this.menuItem_YFCX,
            this.menuItem_JSYP});
            this.menuItem12.MergeOrder = 2;
            this.menuItem12.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.menuItem12.Text = "   查询功能 (&Q)";
            // 
            // menuItem55
            // 
            this.menuItem55.Index = 0;
            this.menuItem55.Text = "病人历史医嘱查询 (&V)";
            this.menuItem55.Click += new System.EventHandler(this.menuItem54_Click);
            // 
            // menuItem_BRXX
            // 
            this.menuItem_BRXX.Index = 1;
            this.menuItem_BRXX.Text = "病人信息查询";
            this.menuItem_BRXX.Visible = false;
            this.menuItem_BRXX.Click += new System.EventHandler(this.menuItem_BRXX_Click);
            // 
            // menuItem_BRFY
            // 
            this.menuItem_BRFY.Index = 2;
            this.menuItem_BRFY.Text = "病人费用明细";
            this.menuItem_BRFY.Click += new System.EventHandler(this.menuItem_BRFY_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 3;
            this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_SCD,
            this.menuItem_SCJL,
            this.menuItem_WZJL});
            this.menuItem16.Text = "护理信息";
            // 
            // menuItem_SCD
            // 
            this.menuItem_SCD.Index = 0;
            this.menuItem_SCD.Text = "三测单";
            this.menuItem_SCD.Click += new System.EventHandler(this.menuItem_SCD_Click);
            // 
            // menuItem_SCJL
            // 
            this.menuItem_SCJL.Index = 1;
            this.menuItem_SCJL.Text = "四测记录";
            this.menuItem_SCJL.Click += new System.EventHandler(this.menuItem_SCJL_Click);
            // 
            // menuItem_WZJL
            // 
            this.menuItem_WZJL.Index = 2;
            this.menuItem_WZJL.Text = "危重患者护理记录";
            this.menuItem_WZJL.Click += new System.EventHandler(this.menuItem_WHJL_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "-";
            // 
            // menuItem57
            // 
            this.menuItem57.Index = 5;
            this.menuItem57.Text = "手术查询";
            this.menuItem57.Click += new System.EventHandler(this.menuItem_SSCX_Click);
            // 
            // menuItem_XMCX
            // 
            this.menuItem_XMCX.Index = 6;
            this.menuItem_XMCX.Text = "医嘱项目查询 (&Z)";
            this.menuItem_XMCX.Click += new System.EventHandler(this.menuItem_XMCX_Click);
            // 
            // menuItem_YFCX
            // 
            this.menuItem_YFCX.Index = 7;
            this.menuItem_YFCX.Text = "医嘱用法查询(&U)";
            this.menuItem_YFCX.Click += new System.EventHandler(this.menuItem_YFCX_Click);
            // 
            // menuItem_JSYP
            // 
            this.menuItem_JSYP.Index = 8;
            this.menuItem_JSYP.Text = "科室基数药";
            this.menuItem_JSYP.Visible = false;
            this.menuItem_JSYP.Click += new System.EventHandler(this.menuItem_JSYP_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 2;
            this.menuItem18.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem21,
            this.menuItem_FYTJ,
            this.menuItem80,
            this.menuItem_YSPB,
            this.menuItem_BQ});
            this.menuItem18.MergeOrder = 3;
            this.menuItem18.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.menuItem18.Text = "   病区信息";
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 0;
            this.menuItem21.Text = "-";
            // 
            // menuItem_FYTJ
            // 
            this.menuItem_FYTJ.Index = 1;
            this.menuItem_FYTJ.Text = "本病区病人费用统计";
            this.menuItem_FYTJ.Click += new System.EventHandler(this.menuItem_FYTJ_Click);
            // 
            // menuItem80
            // 
            this.menuItem80.Index = 2;
            this.menuItem80.Text = "-";
            // 
            // menuItem_YSPB
            // 
            this.menuItem_YSPB.Index = 3;
            this.menuItem_YSPB.Text = "医生排班";
            this.menuItem_YSPB.Click += new System.EventHandler(this.menuItem_YSPB_Click);
            // 
            // menuItem_BQ
            // 
            this.menuItem_BQ.Index = 4;
            this.menuItem_BQ.Text = "病区一览";
            this.menuItem_BQ.Visible = false;
            this.menuItem_BQ.Click += new System.EventHandler(this.menuItem_BQ_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(104, 71);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(924, 293);
            this.tabControl1.TabIndex = 31;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(916, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "管辖内病人";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView1.ContextMenu = this.contextMenu1;
            this.listView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imgBED;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(916, 53);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.menuItem_YZGL_Click);
            this.listView1.Enter += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView1.MouseEnter += new System.EventHandler(this.listView1_MouseEnter);
            this.listView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView1_KeyPress);
            this.listView1.GD += new Ts_zyys_main.GdtGt(this.listView1_GD);
            this.listView1.MouseLeave += new System.EventHandler(this.listView1_MouseLeave);
            // 
            // imgBED
            // 
            this.imgBED.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgBED.ImageStream")));
            this.imgBED.TransparentColor = System.Drawing.Color.Transparent;
            this.imgBED.Images.SetKeyName(0, "");
            this.imgBED.Images.SetKeyName(1, "");
            this.imgBED.Images.SetKeyName(2, "");
            this.imgBED.Images.SetKeyName(3, "");
            this.imgBED.Images.SetKeyName(4, "");
            this.imgBED.Images.SetKeyName(5, "");
            this.imgBED.Images.SetKeyName(6, "");
            this.imgBED.Images.SetKeyName(7, "");
            this.imgBED.Images.SetKeyName(8, "");
            this.imgBED.Images.SetKeyName(9, "");
            this.imgBED.Images.SetKeyName(10, "");
            this.imgBED.Images.SetKeyName(11, "");
            this.imgBED.Images.SetKeyName(12, "");
            this.imgBED.Images.SetKeyName(13, "");
            this.imgBED.Images.SetKeyName(14, "");
            this.imgBED.Images.SetKeyName(15, "");
            this.imgBED.Images.SetKeyName(16, "");
            this.imgBED.Images.SetKeyName(17, "");
            this.imgBED.Images.SetKeyName(18, "");
            this.imgBED.Images.SetKeyName(19, "");
            this.imgBED.Images.SetKeyName(20, "");
            this.imgBED.Images.SetKeyName(21, "");
            this.imgBED.Images.SetKeyName(22, "");
            this.imgBED.Images.SetKeyName(23, "");
            this.imgBED.Images.SetKeyName(24, "");
            this.imgBED.Images.SetKeyName(25, "");
            this.imgBED.Images.SetKeyName(26, "");
            this.imgBED.Images.SetKeyName(27, "");
            this.imgBED.Images.SetKeyName(28, "");
            this.imgBED.Images.SetKeyName(29, "");
            this.imgBED.Images.SetKeyName(30, "");
            this.imgBED.Images.SetKeyName(31, "");
            this.imgBED.Images.SetKeyName(32, "");
            this.imgBED.Images.SetKeyName(33, "");
            this.imgBED.Images.SetKeyName(34, "");
            this.imgBED.Images.SetKeyName(35, "");
            this.imgBED.Images.SetKeyName(36, "");
            this.imgBED.Images.SetKeyName(37, "");
            this.imgBED.Images.SetKeyName(38, "");
            this.imgBED.Images.SetKeyName(39, "");
            this.imgBED.Images.SetKeyName(40, "");
            this.imgBED.Images.SetKeyName(41, "");
            this.imgBED.Images.SetKeyName(42, "");
            this.imgBED.Images.SetKeyName(43, "");
            this.imgBED.Images.SetKeyName(44, "");
            this.imgBED.Images.SetKeyName(45, "");
            this.imgBED.Images.SetKeyName(46, "");
            this.imgBED.Images.SetKeyName(47, "");
            this.imgBED.Images.SetKeyName(48, "");
            this.imgBED.Images.SetKeyName(49, "");
            this.imgBED.Images.SetKeyName(50, "");
            this.imgBED.Images.SetKeyName(51, "");
            this.imgBED.Images.SetKeyName(52, "");
            this.imgBED.Images.SetKeyName(53, "");
            this.imgBED.Images.SetKeyName(54, "");
            this.imgBED.Images.SetKeyName(55, "");
            this.imgBED.Images.SetKeyName(56, "");
            this.imgBED.Images.SetKeyName(57, "");
            this.imgBED.Images.SetKeyName(58, "");
            this.imgBED.Images.SetKeyName(59, "");
            this.imgBED.Images.SetKeyName(60, "");
            this.imgBED.Images.SetKeyName(61, "");
            this.imgBED.Images.SetKeyName(62, "");
            this.imgBED.Images.SetKeyName(63, "");
            this.imgBED.Images.SetKeyName(64, "");
            this.imgBED.Images.SetKeyName(65, "");
            this.imgBED.Images.SetKeyName(66, "");
            this.imgBED.Images.SetKeyName(67, "");
            this.imgBED.Images.SetKeyName(68, "");
            this.imgBED.Images.SetKeyName(69, "");
            this.imgBED.Images.SetKeyName(70, "");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(916, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 208);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.richTextBoxEx1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(463, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(453, 208);
            this.panel4.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panel8.BackColor = System.Drawing.Color.LightYellow;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Controls.Add(this.label13);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(56, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(352, 208);
            this.panel8.TabIndex = 17;
            this.panel8.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(352, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "病人图片上一个DEATH字母:医生定义该病人死亡，护士还没确认";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(360, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "病人图片上一个OUT字母:医生定义该病人出院，护士还没确认";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(360, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "病床号后一个(医保)图标:该病人是医保病人";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(368, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "病人姓名后一个(包)图标:该病人将该病房给包了";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "病床号后一个△图标:该病人病重";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.LightYellow;
            this.label14.Location = new System.Drawing.Point(0, 112);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(384, 16);
            this.label14.TabIndex = 6;
            this.label14.Text = "病床号后一个*图标:该病人病危";
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label13.Location = new System.Drawing.Point(0, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(416, 16);
            this.label13.TabIndex = 5;
            this.label13.Text = "图片无框:一般护理病人";
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Lime;
            this.label12.Location = new System.Drawing.Point(0, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(384, 16);
            this.label12.TabIndex = 4;
            this.label12.Text = "图片外框为细体绿色:三级护理病人";
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(0, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(384, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "图片外框为细体蓝色:二级护理病人";
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Magenta;
            this.label10.Location = new System.Drawing.Point(0, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(384, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "图片外框为细体红色:一级护理病人";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.LightYellow;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(0, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(384, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "图片外框为粗体大红色:特级护理病人";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(0, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(384, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "图片状态说明：";
            // 
            // richTextBoxEx1
            // 
            this.richTextBoxEx1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxEx1.ContextMenu = this.contextMenu2;
            this.richTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEx1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxEx1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBoxEx1.LinkStyle = false;
            this.richTextBoxEx1.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.ReadOnly = true;
            this.richTextBoxEx1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxEx1.Size = new System.Drawing.Size(453, 208);
            this.richTextBoxEx1.TabIndex = 0;
            this.richTextBoxEx1.Text = "";
            this.richTextBoxEx1.MouseEnter += new System.EventHandler(this.richTextBoxEx1_MouseEnter);
            this.richTextBoxEx1.Leave += new System.EventHandler(this.richTextBoxEx1_Leave);
            this.richTextBoxEx1.TextChanged += new System.EventHandler(this.richTextBoxEx1_TextChanged);
            this.richTextBoxEx1.MouseLeave += new System.EventHandler(this.richTextBoxEx1_MouseLeave);
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem64,
            this.menuItem67,
            this.menuItem65,
            this.menuItem66,
            this.menuItem68,
            this.menuItem69,
            this.menuItem70,
            this.menuItem71,
            this.menuItem72});
            // 
            // menuItem64
            // 
            this.menuItem64.Index = 0;
            this.menuItem64.Text = "编辑";
            this.menuItem64.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // menuItem67
            // 
            this.menuItem67.Index = 1;
            this.menuItem67.Text = "打开";
            this.menuItem67.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // menuItem65
            // 
            this.menuItem65.Index = 2;
            this.menuItem65.Text = "保存";
            this.menuItem65.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // menuItem66
            // 
            this.menuItem66.Index = 3;
            this.menuItem66.Text = "另存";
            this.menuItem66.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // menuItem68
            // 
            this.menuItem68.Index = 4;
            this.menuItem68.Text = "-";
            // 
            // menuItem69
            // 
            this.menuItem69.Index = 5;
            this.menuItem69.Text = "滚动";
            this.menuItem69.Click += new System.EventHandler(this.menuItem69_Click);
            // 
            // menuItem70
            // 
            this.menuItem70.Index = 6;
            this.menuItem70.Text = "停止";
            this.menuItem70.Click += new System.EventHandler(this.menuItem70_Click);
            // 
            // menuItem71
            // 
            this.menuItem71.Index = 7;
            this.menuItem71.Text = "-";
            // 
            // menuItem72
            // 
            this.menuItem72.Index = 8;
            this.menuItem72.Text = "题头日期";
            this.menuItem72.Click += new System.EventHandler(this.menuItem72_Click);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(460, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 208);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ddd);
            this.panel3.Controls.Add(this.patientInfo1);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(460, 208);
            this.panel3.TabIndex = 1;
            // 
            // ddd
            // 
            this.ddd.Controls.Add(this.btnOpen);
            this.ddd.Controls.Add(this.btnEdit);
            this.ddd.Controls.Add(this.btnSave);
            this.ddd.Controls.Add(this.btnSaveAs);
            this.ddd.Controls.Add(this.btnPrint);
            this.ddd.Location = new System.Drawing.Point(5, 5);
            this.ddd.Name = "ddd";
            this.ddd.Size = new System.Drawing.Size(449, 56);
            this.ddd.TabIndex = 16;
            this.ddd.TabStop = false;
            this.ddd.Text = "医生记事记录";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.DefaultScheme = false;
            this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOpen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpen.Hint = "";
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new System.Drawing.Point(92, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOpen.Size = new System.Drawing.Size(88, 30);
            this.btnOpen.TabIndex = 50;
            this.btnOpen.Text = "打开(&O)";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.DefaultScheme = false;
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEdit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Hint = "";
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(4, 18);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEdit.Size = new System.Drawing.Size(88, 30);
            this.btnEdit.TabIndex = 48;
            this.btnEdit.Text = "编辑(&E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DefaultScheme = false;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Hint = "";
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(180, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSave.Size = new System.Drawing.Size(88, 30);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnSaveAs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAs.DefaultScheme = false;
            this.btnSaveAs.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveAs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveAs.Hint = "";
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.Location = new System.Drawing.Point(268, 18);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSaveAs.Size = new System.Drawing.Size(88, 30);
            this.btnSaveAs.TabIndex = 46;
            this.btnSaveAs.Text = "另存(&A)";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.DefaultScheme = false;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Hint = "";
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(356, 18);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(88, 30);
            this.btnPrint.TabIndex = 49;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // patientInfo1
            // 
            this.patientInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.patientInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.patientInfo1.IsShow = true;
            this.patientInfo1.Location = new System.Drawing.Point(0, 64);
            this.patientInfo1.Name = "patientInfo1";
            this.patientInfo1.Size = new System.Drawing.Size(460, 144);
            this.patientInfo1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(916, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "本科所有病人";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.FloralWhite;
            this.listView2.ContextMenu = this.contextMenu1;
            this.listView2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.HideSelection = false;
            this.listView2.LargeImageList = this.imgBED;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(916, 264);
            this.listView2.SmallImageList = this.imageList1;
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView2.SizeChanged += new System.EventHandler(this.listView2_SizeChanged);
            this.listView2.DoubleClick += new System.EventHandler(this.menuItem_YZGL_Click);
            this.listView2.Enter += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView1_KeyPress);
            this.listView2.GD += new Ts_zyys_main.GdtGt(this.listView2_GD);
            this.listView2.MouseLeave += new System.EventHandler(this.listView2_MouseLeave);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.myListview1);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(916, 264);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "本组病人";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // myListview1
            // 
            this.myListview1.BackColor = System.Drawing.Color.FloralWhite;
            this.myListview1.ContextMenu = this.contextMenu1;
            this.myListview1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.myListview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myListview1.HideSelection = false;
            this.myListview1.LargeImageList = this.imgBED;
            this.myListview1.Location = new System.Drawing.Point(3, 3);
            this.myListview1.MultiSelect = false;
            this.myListview1.Name = "myListview1";
            this.myListview1.Size = new System.Drawing.Size(910, 258);
            this.myListview1.SmallImageList = this.imageList1;
            this.myListview1.TabIndex = 3;
            this.myListview1.UseCompatibleStateImageBehavior = false;
            this.myListview1.SelectedIndexChanged += new System.EventHandler(this.myListview1_SelectedIndexChanged);
            this.myListview1.DoubleClick += new System.EventHandler(this.menuItem_YZGL_Click);
            this.myListview1.Enter += new System.EventHandler(this.myListview1_Enter);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView3);
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(916, 264);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "会诊病人";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.BackColor = System.Drawing.Color.AliceBlue;
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_BinID,
            this.col_ZYH,
            this.col_Name,
            this.col_Ward,
            this.col_DeptID,
            this.col_SQRQ,
            this.col_SQYS,
            this.col_ConText,
            this.col_hzid,
            this.col_babyid,
            this.col_level});
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.listView3.FullRowSelect = true;
            this.listView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView3.Location = new System.Drawing.Point(0, 0);
            this.listView3.MultiSelect = false;
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(916, 118);
            this.listView3.SmallImageList = this.imageList1;
            this.listView3.TabIndex = 2;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged);
            this.listView3.DoubleClick += new System.EventHandler(this.listView3_DoubleClick);
            this.listView3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView3_KeyPress);
            // 
            // col_BinID
            // 
            this.col_BinID.Text = "";
            this.col_BinID.Width = 20;
            // 
            // col_ZYH
            // 
            this.col_ZYH.Text = "住院号";
            this.col_ZYH.Width = 90;
            // 
            // col_Name
            // 
            this.col_Name.Text = "姓名";
            this.col_Name.Width = 96;
            // 
            // col_Ward
            // 
            this.col_Ward.Text = "病区";
            this.col_Ward.Width = 0;
            // 
            // col_DeptID
            // 
            this.col_DeptID.Text = "科室";
            this.col_DeptID.Width = 152;
            // 
            // col_SQRQ
            // 
            this.col_SQRQ.Text = "申请日期";
            this.col_SQRQ.Width = 151;
            // 
            // col_SQYS
            // 
            this.col_SQYS.Text = "申请医生";
            this.col_SQYS.Width = 102;
            // 
            // col_ConText
            // 
            this.col_ConText.Text = "会诊内容";
            this.col_ConText.Width = 280;
            // 
            // col_hzid
            // 
            this.col_hzid.Text = "hzid";
            this.col_hzid.Width = 0;
            // 
            // col_babyid
            // 
            this.col_babyid.Text = "col_babyid";
            this.col_babyid.Width = 0;
            // 
            // col_level
            // 
            this.col_level.Text = "会诊级别";
            this.col_level.Width = 150;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.richTBoxCon);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.patientInfo2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 118);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(916, 146);
            this.panel5.TabIndex = 1;
            // 
            // richTBoxCon
            // 
            this.richTBoxCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTBoxCon.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTBoxCon.Location = new System.Drawing.Point(480, 0);
            this.richTBoxCon.Name = "richTBoxCon";
            this.richTBoxCon.ReadOnly = true;
            this.richTBoxCon.Size = new System.Drawing.Size(434, 144);
            this.richTBoxCon.TabIndex = 4;
            this.richTBoxCon.Text = "";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(460, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 144);
            this.label2.TabIndex = 3;
            this.label2.Text = "会诊内容";
            // 
            // patientInfo2
            // 
            this.patientInfo2.BackColor = System.Drawing.SystemColors.Control;
            this.patientInfo2.Dock = System.Windows.Forms.DockStyle.Left;
            this.patientInfo2.IsShow = true;
            this.patientInfo2.Location = new System.Drawing.Point(0, 0);
            this.patientInfo2.Name = "patientInfo2";
            this.patientInfo2.Size = new System.Drawing.Size(460, 144);
            this.patientInfo2.TabIndex = 5;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listView4);
            this.tabPage4.Controls.Add(this.panel6);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(916, 264);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "特殊治疗病人";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listView4
            // 
            this.listView4.BackColor = System.Drawing.Color.GhostWhite;
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView4.ContextMenuStrip = this.contextMenuStrip1;
            this.listView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.listView4.FullRowSelect = true;
            this.listView4.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView4.Location = new System.Drawing.Point(0, 0);
            this.listView4.MultiSelect = false;
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(916, 118);
            this.listView4.TabIndex = 5;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            this.listView4.SelectedIndexChanged += new System.EventHandler(this.listView4_SelectedIndexChanged);
            this.listView4.DoubleClick += new System.EventHandler(this.listView4_DoubleClick);
            this.listView4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView4_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "inpatient_id";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "住院号";
            this.columnHeader2.Width = 106;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "姓名";
            this.columnHeader3.Width = 96;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "病区";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "科室";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 152;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "申请日期";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 151;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "申请医生";
            this.columnHeader7.Width = 102;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "申请内容";
            this.columnHeader8.Width = 280;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "id";
            this.columnHeader9.Width = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.特殊治疗完成ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.刷新全部未完成ToolStripMenuItem,
            this.查询全部已完成ToolStripMenuItem,
            this.toolStripSeparator1,
            this.分娩ToolStripMenuItem,
            this.查询ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 148);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem1.Text = "医嘱查询";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 特殊治疗完成ToolStripMenuItem
            // 
            this.特殊治疗完成ToolStripMenuItem.Name = "特殊治疗完成ToolStripMenuItem";
            this.特殊治疗完成ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.特殊治疗完成ToolStripMenuItem.Text = "特殊治疗完成";
            this.特殊治疗完成ToolStripMenuItem.Click += new System.EventHandler(this.特殊治疗完成ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 6);
            // 
            // 刷新全部未完成ToolStripMenuItem
            // 
            this.刷新全部未完成ToolStripMenuItem.Name = "刷新全部未完成ToolStripMenuItem";
            this.刷新全部未完成ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.刷新全部未完成ToolStripMenuItem.Text = "查询全部未完成";
            this.刷新全部未完成ToolStripMenuItem.Click += new System.EventHandler(this.刷新全部未完成ToolStripMenuItem_Click);
            // 
            // 查询全部已完成ToolStripMenuItem
            // 
            this.查询全部已完成ToolStripMenuItem.Name = "查询全部已完成ToolStripMenuItem";
            this.查询全部已完成ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.查询全部已完成ToolStripMenuItem.Text = "查询全部已完成";
            this.查询全部已完成ToolStripMenuItem.Click += new System.EventHandler(this.查询全部已完成ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // 分娩ToolStripMenuItem
            // 
            this.分娩ToolStripMenuItem.Name = "分娩ToolStripMenuItem";
            this.分娩ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.分娩ToolStripMenuItem.Text = "分娩";
            this.分娩ToolStripMenuItem.Visible = false;
            this.分娩ToolStripMenuItem.Click += new System.EventHandler(this.分娩ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.查询ToolStripMenuItem.Text = "查询病人";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.richTBoxJR);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.patientInfo3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 118);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(916, 146);
            this.panel6.TabIndex = 4;
            // 
            // richTBoxJR
            // 
            this.richTBoxJR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTBoxJR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTBoxJR.Location = new System.Drawing.Point(480, 0);
            this.richTBoxJR.Name = "richTBoxJR";
            this.richTBoxJR.ReadOnly = true;
            this.richTBoxJR.Size = new System.Drawing.Size(434, 144);
            this.richTBoxJR.TabIndex = 4;
            this.richTBoxJR.Text = "";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(460, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 144);
            this.label3.TabIndex = 3;
            this.label3.Text = "申请内容";
            // 
            // patientInfo3
            // 
            this.patientInfo3.BackColor = System.Drawing.SystemColors.Control;
            this.patientInfo3.Dock = System.Windows.Forms.DockStyle.Left;
            this.patientInfo3.IsShow = true;
            this.patientInfo3.Location = new System.Drawing.Point(0, 0);
            this.patientInfo3.Name = "patientInfo3";
            this.patientInfo3.Size = new System.Drawing.Size(460, 144);
            this.patientInfo3.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvPat);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(916, 264);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "未入区病人";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvPat
            // 
            this.dgvPat.AllowUserToAddRows = false;
            this.dgvPat.AllowUserToDeleteRows = false;
            this.dgvPat.AllowUserToResizeRows = false;
            this.dgvPat.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPat.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPat.Location = new System.Drawing.Point(3, 3);
            this.dgvPat.MultiSelect = false;
            this.dgvPat.Name = "dgvPat";
            this.dgvPat.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPat.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPat.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvPat.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPat.RowTemplate.Height = 23;
            this.dgvPat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPat.Size = new System.Drawing.Size(910, 258);
            this.dgvPat.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dgvTodayIn);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(916, 264);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "今日入院";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dgvTodayIn
            // 
            this.dgvTodayIn.AllowUserToAddRows = false;
            this.dgvTodayIn.AllowUserToDeleteRows = false;
            this.dgvTodayIn.AllowUserToResizeRows = false;
            this.dgvTodayIn.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTodayIn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTodayIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTodayIn.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTodayIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTodayIn.Location = new System.Drawing.Point(0, 0);
            this.dgvTodayIn.MultiSelect = false;
            this.dgvTodayIn.Name = "dgvTodayIn";
            this.dgvTodayIn.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTodayIn.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTodayIn.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvTodayIn.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTodayIn.RowTemplate.Height = 23;
            this.dgvTodayIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTodayIn.Size = new System.Drawing.Size(916, 264);
            this.dgvTodayIn.TabIndex = 1;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.White;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "");
            this.imageList2.Images.SetKeyName(10, "");
            this.imageList2.Images.SetKeyName(11, "");
            this.imageList2.Images.SetKeyName(12, "");
            this.imageList2.Images.SetKeyName(13, "");
            this.imageList2.Images.SetKeyName(14, "");
            this.imageList2.Images.SetKeyName(15, "");
            this.imageList2.Images.SetKeyName(16, "");
            this.imageList2.Images.SetKeyName(17, "");
            this.imageList2.Images.SetKeyName(18, "");
            this.imageList2.Images.SetKeyName(19, "");
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // printDocument
            // 
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "rtf";
            this.openFileDialog1.Filter = "文本文件 (*.txt)|*.txt|RTF 文件 (*.rtf)|*.rtf|XML 文件 (*.xml)|*.xml|所有文件 (*.*)|*.*";
            this.openFileDialog1.Title = "打开";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "文本文件 (*.txt)|*.txt|RTF 文件 (*.rtf)|*.rtf|XML 文件 (*.xml)|*.xml|所有文件 (*.*)|*.*";
            this.saveFileDialog1.Title = "另存为";
            // 
            // dirWatcher
            // 
            this.dirWatcher.EnableRaisingEvents = true;
            this.dirWatcher.SynchronizingObject = this;
            this.dirWatcher.Changed += new System.IO.FileSystemEventHandler(this.dirWatcher_Changed);
            // 
            // pageSetupDialog
            // 
            this.pageSetupDialog.Document = this.printDocument;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // bt_RF
            // 
            this.bt_RF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_RF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_RF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_RF.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_RF.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_RF.Location = new System.Drawing.Point(938, 72);
            this.bt_RF.Name = "bt_RF";
            this.bt_RF.Size = new System.Drawing.Size(59, 24);
            this.bt_RF.TabIndex = 36;
            this.bt_RF.Text = "刷新";
            this.bt_RF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt_RF.Click += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // bt_CW
            // 
            this.bt_CW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_CW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_CW.Enabled = false;
            this.bt_CW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_CW.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_CW.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_CW.Location = new System.Drawing.Point(861, 72);
            this.bt_CW.Name = "bt_CW";
            this.bt_CW.Size = new System.Drawing.Size(65, 24);
            this.bt_CW.TabIndex = 38;
            this.bt_CW.Text = "按病房";
            this.bt_CW.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt_CW.Click += new System.EventHandler(this.bt_CW_Click);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "");
            this.imageList3.Images.SetKeyName(1, "");
            this.imageList3.Images.SetKeyName(2, "");
            this.imageList3.Images.SetKeyName(3, "");
            this.imageList3.Images.SetKeyName(4, "");
            this.imageList3.Images.SetKeyName(5, "");
            this.imageList3.Images.SetKeyName(6, "");
            this.imageList3.Images.SetKeyName(7, "");
            this.imageList3.Images.SetKeyName(8, "");
            this.imageList3.Images.SetKeyName(9, "");
            this.imageList3.Images.SetKeyName(10, "");
            this.imageList3.Images.SetKeyName(11, "");
            this.imageList3.Images.SetKeyName(12, "");
            // 
            // imageList0
            // 
            this.imageList0.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList0.ImageStream")));
            this.imageList0.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList0.Images.SetKeyName(0, "");
            this.imageList0.Images.SetKeyName(1, "");
            this.imageList0.Images.SetKeyName(2, "");
            this.imageList0.Images.SetKeyName(3, "");
            this.imageList0.Images.SetKeyName(4, "");
            this.imageList0.Images.SetKeyName(5, "");
            this.imageList0.Images.SetKeyName(6, "");
            this.imageList0.Images.SetKeyName(7, "");
            this.imageList0.Images.SetKeyName(8, "");
            this.imageList0.Images.SetKeyName(9, "");
            this.imageList0.Images.SetKeyName(10, "");
            this.imageList0.Images.SetKeyName(11, "");
            this.imageList0.Images.SetKeyName(12, "");
            this.imageList0.Images.SetKeyName(13, "");
            this.imageList0.Images.SetKeyName(14, "");
            this.imageList0.Images.SetKeyName(15, "");
            this.imageList0.Images.SetKeyName(16, "");
            this.imageList0.Images.SetKeyName(17, "");
            this.imageList0.Images.SetKeyName(18, "");
            this.imageList0.Images.SetKeyName(19, "");
            this.imageList0.Images.SetKeyName(20, "");
            this.imageList0.Images.SetKeyName(21, "");
            this.imageList0.Images.SetKeyName(22, "");
            this.imageList0.Images.SetKeyName(23, "");
            this.imageList0.Images.SetKeyName(24, "");
            // 
            // imageList5
            // 
            this.imageList5.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList5.ImageStream")));
            this.imageList5.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList5.Images.SetKeyName(0, "");
            this.imageList5.Images.SetKeyName(1, "");
            this.imageList5.Images.SetKeyName(2, "");
            this.imageList5.Images.SetKeyName(3, "");
            this.imageList5.Images.SetKeyName(4, "");
            this.imageList5.Images.SetKeyName(5, "");
            this.imageList5.Images.SetKeyName(6, "");
            this.imageList5.Images.SetKeyName(7, "");
            this.imageList5.Images.SetKeyName(8, "");
            this.imageList5.Images.SetKeyName(9, "");
            this.imageList5.Images.SetKeyName(10, "");
            this.imageList5.Images.SetKeyName(11, "");
            this.imageList5.Images.SetKeyName(12, "");
            this.imageList5.Images.SetKeyName(13, "");
            this.imageList5.Images.SetKeyName(14, "");
            this.imageList5.Images.SetKeyName(15, "");
            this.imageList5.Images.SetKeyName(16, "");
            this.imageList5.Images.SetKeyName(17, "");
            this.imageList5.Images.SetKeyName(18, "");
            // 
            // cmbWard
            // 
            this.cmbWard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbWard.FormattingEnabled = true;
            this.cmbWard.Location = new System.Drawing.Point(726, 72);
            this.cmbWard.Name = "cmbWard";
            this.cmbWard.Size = new System.Drawing.Size(106, 22);
            this.cmbWard.TabIndex = 42;
            this.cmbWard.Visible = false;
            this.cmbWard.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // xcjwLabel1
            // 
            this.xcjwLabel1.BackColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.xcjwLabel1.BackColor2 = System.Drawing.Color.AliceBlue;
            this.xcjwLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xcjwLabel1.Location = new System.Drawing.Point(0, 0);
            this.xcjwLabel1.Name = "xcjwLabel1";
            this.xcjwLabel1.Size = new System.Drawing.Size(1028, 23);
            this.xcjwLabel1.TabIndex = 41;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 300;
            // 
            // ImageTsd
            // 
            this.ImageTsd.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageTsd.ImageStream")));
            this.ImageTsd.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageTsd.Images.SetKeyName(0, "0.bmp");
            this.ImageTsd.Images.SetKeyName(1, "1.bmp");
            this.ImageTsd.Images.SetKeyName(2, "2.bmp");
            this.ImageTsd.Images.SetKeyName(3, "3.bmp");
            this.ImageTsd.Images.SetKeyName(4, "4.bmp");
            this.ImageTsd.Images.SetKeyName(5, "无灯.jpg");
            this.ImageTsd.Images.SetKeyName(6, "CP.png");
            this.ImageTsd.Images.SetKeyName(7, "utsing.gif");
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ImgCp
            // 
            this.ImgCp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgCp.ImageStream")));
            this.ImgCp.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgCp.Images.SetKeyName(0, "utsing.gif");
            this.ImgCp.Images.SetKeyName(1, "CP.png");
            this.ImgCp.Images.SetKeyName(2, "dbz1.ico");
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // butt_ks
            // 
            this.butt_ks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butt_ks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butt_ks.Enabled = false;
            this.butt_ks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butt_ks.Font = new System.Drawing.Font("宋体", 10F);
            this.butt_ks.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butt_ks.Location = new System.Drawing.Point(838, 71);
            this.butt_ks.Name = "butt_ks";
            this.butt_ks.Size = new System.Drawing.Size(64, 25);
            this.butt_ks.TabIndex = 40;
            this.butt_ks.Text = "按科室";
            this.butt_ks.UseVisualStyleBackColor = true;
            this.butt_ks.Click += new System.EventHandler(this.butt_ks_Click);
            // 
            // checkCpIN
            // 
            this.checkCpIN.AutoSize = true;
            this.checkCpIN.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkCpIN.Image = global::Ts_zyys_main.Properties.Resources.CP;
            this.checkCpIN.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkCpIN.Location = new System.Drawing.Point(673, 72);
            this.checkCpIN.Name = "checkCpIN";
            this.checkCpIN.Size = new System.Drawing.Size(116, 20);
            this.checkCpIN.TabIndex = 43;
            this.checkCpIN.Text = "进入路径病人";
            this.checkCpIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkCpIN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.checkCpIN.UseVisualStyleBackColor = true;
            this.checkCpIN.Click += new System.EventHandler(this.checkCpIN_Click);
            this.checkCpIN.CheckedChanged += new System.EventHandler(this.checkCpIN_CheckedChanged);
            // 
            // checkDbz
            // 
            this.checkDbz.AutoSize = true;
            this.checkDbz.ForeColor = System.Drawing.Color.Purple;
            this.checkDbz.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkDbz.ImageKey = "dbz1.ico";
            this.checkDbz.ImageList = this.ImgCp;
            this.checkDbz.Location = new System.Drawing.Point(607, 45);
            this.checkDbz.Name = "checkDbz";
            this.checkDbz.Size = new System.Drawing.Size(104, 20);
            this.checkDbz.TabIndex = 44;
            this.checkDbz.Text = "单病种病人";
            this.checkDbz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkDbz.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.checkDbz.UseVisualStyleBackColor = true;
            this.checkDbz.Click += new System.EventHandler(this.checkCpIN_Click);
            this.checkDbz.CheckedChanged += new System.EventHandler(this.checkCpIN_CheckedChanged);
            // 
            // btSyncOldHISPatInfo
            // 
            this.btSyncOldHISPatInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSyncOldHISPatInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSyncOldHISPatInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSyncOldHISPatInfo.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSyncOldHISPatInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btSyncOldHISPatInfo.Location = new System.Drawing.Point(849, 41);
            this.btSyncOldHISPatInfo.Name = "btSyncOldHISPatInfo";
            this.btSyncOldHISPatInfo.Size = new System.Drawing.Size(167, 24);
            this.btSyncOldHISPatInfo.TabIndex = 45;
            this.btSyncOldHISPatInfo.Text = "同步新老系统病人信息";
            this.btSyncOldHISPatInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSyncOldHISPatInfo.Click += new System.EventHandler(this.btSyncOldHISPatInfo_Click);
            // 
            // btReComputeRate
            // 
            this.btReComputeRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btReComputeRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btReComputeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReComputeRate.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btReComputeRate.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btReComputeRate.Location = new System.Drawing.Point(726, 41);
            this.btReComputeRate.Name = "btReComputeRate";
            this.btReComputeRate.Size = new System.Drawing.Size(117, 24);
            this.btReComputeRate.TabIndex = 46;
            this.btReComputeRate.Text = "重刷医嘱比例";
            this.btReComputeRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btReComputeRate.Click += new System.EventHandler(this.btReComputeRate_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(293, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 12);
            this.label15.TabIndex = 47;
            this.label15.Text = "住院号:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(339, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 21);
            this.textBox1.TabIndex = 48;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(501, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 24);
            this.button1.TabIndex = 49;
            this.button1.Text = "查询";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(242, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 32);
            this.button2.TabIndex = 50;
            this.button2.Text = "患者基本信息导出(Excel)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dougScrollingTextCtr1
            // 
            this.dougScrollingTextCtr1.BorderColor = System.Drawing.Color.Black;
            this.dougScrollingTextCtr1.BorderType = System.Windows.Forms.BorderStyle.None;
            this.dougScrollingTextCtr1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dougScrollingTextCtr1.DougScrollingTextColor1 = System.Drawing.Color.Black;
            this.dougScrollingTextCtr1.DougScrollingTextColor2 = System.Drawing.Color.Gold;
            this.dougScrollingTextCtr1.IsStop = false;
            this.dougScrollingTextCtr1.Location = new System.Drawing.Point(588, 43);
            this.dougScrollingTextCtr1.Name = "dougScrollingTextCtr1";
            this.dougScrollingTextCtr1.ScrollingType = Ts_zyys_main.DougScrollingTextCtr.ScrollingTypes.NoContinuum;
            this.dougScrollingTextCtr1.ShowText = "";
            this.dougScrollingTextCtr1.Size = new System.Drawing.Size(412, 20);
            this.dougScrollingTextCtr1.TabIndex = 40;
            this.dougScrollingTextCtr1.Visible = false;
            this.dougScrollingTextCtr1.Waytype = Ts_zyys_main.DougScrollingTextCtr.WayTypes.Left;
            this.dougScrollingTextCtr1.Click += new System.EventHandler(this.dougScrollingTextCtr1_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 22;
            this.menuItem17.Text = "单病种录入";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1028, 364);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btReComputeRate);
            this.Controls.Add(this.btSyncOldHISPatInfo);
            this.Controls.Add(this.butt_ks);
            this.Controls.Add(this.bt_RF);
            this.Controls.Add(this.checkCpIN);
            this.Controls.Add(this.checkDbz);
            this.Controls.Add(this.cmbWard);
            this.Controls.Add(this.dougScrollingTextCtr1);
            this.Controls.Add(this.bt_CW);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.outlookBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.xcjwLabel1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ddd.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPat)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dirWatcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private void GetListb()
        {
            while (true)
            {
                if (Jsq != 0 && Jsq % Convert.ToInt32(cfg6051.Config.Trim()) == 0)
                {
                    //是危机值，并且没有
                    string sql = "select a.*,b.INPATIENT_ID from  dbo.LS_AS_READREPORT a left join ZY_INPATIENT b on a.REG_NO=b.INPATIENT_NO  where   ISNULL(a.assaypat_type,1) =9 and DELETE_BIT=0 and dept_code=" + frmMain.Current_Dept.DeptId + " and ( a.flag=0 or look_dr!=dbo.fun_getEmpName(isnull(b.ZY_DOC,0)))";
                    sql = "select b.INPATIENT_ID,a.REG_NO,a.DEPT_CODE ,(case ISNULL(a.assaypat_type,1) when 9 then '危机报告' else '' end) as assaypat_type,(case ISNULL(a.High_Risk,0) when 1 then '高危菌株' else '' end) as High_Risk,ISNULL(a.WSW_LYX,'') as WSW_LYX from LS_AS_REPORT a  (nolock) " +
                        "   join ZY_INPATIENT b (nolock) on (a.REG_NO =b.INPATIENT_NO and b.flag in(1,3,4) ) " +
                        "  where (ISNULL(a.High_Risk,0) =1 or ISNULL(a.WSW_LYX,'')!='' or ISNULL(a.assaypat_type,1) =9)  " +
                        "   and a.DELETE_BIT=0 and a.TYPE =2  and a.CONF='S' and   not exists(select c.Rep_no  from LIS_SEE_WJ_REPORT_LOG c (nolock) where c.REP_NO=a.REP_NO and c.see_man_id !=b.ZY_DOC) and a.dept_code=" + frmMain.Current_Dept.DeptId;
                    RelationalDatabase Database = new MsSqlServer();
                    Database.Initialize(InstanceForm._database.ConnectionString);
                    wjzTb = Database.GetDataTable(sql);
                    //add by zouchihua 2013-8-13获得其它医技的危机值或者提示
                    sql = "select *,dbo.fun_getEmpName(MASSEGEDOCTOR) fsr,dbo.fun_getDeptname(ZXKS) 发送科室  from JY_MASSEGE a join YJ_ZYSQ b on a.yjsqid=b.YJSQID where a.MASSEGESTATE=1  and b.SQKS=" + InstanceForm._currentDept.DeptId;//标题没有查看的
                    Yjtb = Database.GetDataTable(sql);
                    if (tabControl1.SelectedTab.Text == "本科所有病人")
                    {
                        setcallback(this.listView2);
                    }
                    if (tabControl1.SelectedTab.Text == "管辖内病人")
                    {
                        setcallback(this.listView1);
                    }
                    Jsq = 0;
                    Database.Dispose();
                }
                Thread.Sleep(1000);
            }
        }
        delegate void Callbackfrm(object list);
        FrmWwcxm frmwwcxm = null;
        Thread thrWwcxm = null;
        long timer = 0;
        private void GetWwcxm()
        {
            frmwwcxm = new FrmWwcxm();
            frmwwcxm.FormClosed -= new FormClosedEventHandler(frmwwcxm_FormClosed);
            frmwwcxm.FormClosed += new FormClosedEventHandler(frmwwcxm_FormClosed);
            ParameterEx[] pe1 = new ParameterEx[2];
            pe1[0].Text = "@DEPT_ID ";
            pe1[0].Value = InstanceForm._currentDept.DeptId;
            pe1[1].Text = "@DOC_ID";
            pe1[1].Value = InstanceForm._currentUser.EmployeeId;
            DataSet ds1 = new DataSet();
            RelationalDatabase Database1 = new MsSqlServer();
            Database1.Initialize(InstanceForm._database.ConnectionString);
            Database1.AdapterFillDataSet("SP_ZYYS_GET_WWCXM", pe1, ds1, "tb", 60);
            frmwwcxm.ds = ds1;
            int rows = 0;
            rows = ds1.Tables[0].Rows.Count + ds1.Tables[2].Rows.Count + ds1.Tables[1].Rows.Count + ds1.Tables[3].Rows.Count;
            try
            {
                rows = ds1.Tables[0].Rows.Count + ds1.Tables[2].Rows.Count + ds1.Tables[1].Rows.Count + ds1.Tables[3].Rows.Count + ds1.Tables[4].Rows.Count + ds1.Tables[5].Rows.Count;
            }
            catch { }
            if (rows > 0)
                SHowform(frmwwcxm);
            while (true)
            {
                Thread.Sleep(1000);
                if (timer != 0 && timer % Convert.ToInt32(cfg6077.Config.Trim()) == 0)
                {
                    ParameterEx[] pe = new ParameterEx[2];
                    pe[0].Text = "@DEPT_ID ";
                    pe[0].Value = InstanceForm._currentDept.DeptId;
                    pe[1].Text = "@DOC_ID";
                    pe[1].Value = InstanceForm._currentUser.EmployeeId;
                    DataSet ds = new DataSet();
                    RelationalDatabase Database = new MsSqlServer();
                    Database.Initialize(InstanceForm._database.ConnectionString);
                    Database.AdapterFillDataSet("SP_ZYYS_GET_WWCXM", pe, ds, "tb", 60);

                    rows = 0;
                    rows = ds.Tables[0].Rows.Count + ds.Tables[2].Rows.Count + ds.Tables[1].Rows.Count + ds.Tables[3].Rows.Count;
                    try
                    {
                        rows = ds.Tables[0].Rows.Count + ds.Tables[2].Rows.Count + ds.Tables[1].Rows.Count + ds.Tables[3].Rows.Count + ds.Tables[4].Rows.Count + ds.Tables[5].Rows.Count;
                    }
                    catch { }
                    if (rows == 0)
                        continue;
                    lock (this)
                    {

                        if (frmwwcxm == null)
                        {
                            frmwwcxm = new FrmWwcxm();
                            frmwwcxm.FormClosed -= new FormClosedEventHandler(frmwwcxm_FormClosed);
                            frmwwcxm.FormClosed += new FormClosedEventHandler(frmwwcxm_FormClosed);
                            // frmwwcxm.TopMost = true;
                        }
                        frmwwcxm.ds = ds;
                        SHowform(frmwwcxm);
                        timer = 0;

                    }
                }

            }
        }
        private void SHowform(object form)
        {
            Form f = form as Form;
            if (f.InvokeRequired)
            {
                Callbackfrm cb = new Callbackfrm(SHowform);
                this.Invoke(cb, f);
            }
            else
            {
                //f.BringToFront();
                f.ShowDialog();
            }
        }

        private void ht(IAsyncResult result)
        {

        }

        MenuTag _menuTag;
        /// <summary>
        /// add pengyang 2015-8-12
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="currentDept"></param>
        /// <param name="formText"></param>
        /// <param name="right"></param>
        /// <param name="menuTag"></param>
        public frmMain(long currentUser, long currentDept, string formText, int right, MenuTag menuTag)
            : this(currentUser, currentDept, formText, right)
        {
            this._menuTag = menuTag;
        }

        #region 主窗体Load事件
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            try
            {
                SystemCfg cfg = new SystemCfg(6209);

                if (cfg.Config.Equals("1"))
                {
                    if (this.contextMenu1.MenuItems.Contains(menuItem48))
                    {
                        this.contextMenu1.MenuItems.Remove(menuItem48);
                        //menuItem_HZ.Visible = false;
                    }

                    if (this.toolBar1.Buttons.Contains(toolBarButton3))
                    {
                        this.toolBar1.Buttons.Remove(toolBarButton3);
                        //menuItem_HZ.Visible = false;
                    }
                }
            }
            catch { }

            //Modify by jchl
            InitHlyy();

            //Add by Tany 2015-02-11
            //Modify By Tany 2015-04-08 放开
            btReComputeRate.Visible = true; //FrmMdiMain.CurrentUser.IsAdministrator;

            backgroundWorker1.RunWorkerAsync();
            if (cfg6076.Config.Trim() == "1")
            {

                //frmwwcxm.TopMost = true;
                //del d = new del(GetWwcxm);
                //AsyncCallback d1 = new AsyncCallback(ht);
                //IAsyncResult hh = d.BeginInvoke(d1, d);
                thrWwcxm = new Thread(new ThreadStart(GetWwcxm));
                thrWwcxm.Start();
            }
            this.patientInfo1.Sfdcts = false;
            string ifqy = ApiFunction.GetIniString("SfQy", "SfQy", Constant.ApplicationDirectory + "\\Cpset.ini");
            /*是否启用临床路径 0=不启用，1=启用临床路径 2=启用单病种 3=单病种临床路径都启用*/
            if (ifqy == "0")
            {
                checkCpIN.Visible = false;
                checkDbz.Visible = false;
                menuItem7.Visible = false;
                menuItem8.Visible = false;
            }
            else
                if (ifqy == "1")
                {
                    checkCpIN.Visible = true;
                    checkDbz.Visible = false;
                    menuItem7.Visible = true;
                    menuItem10.Visible = false;
                }
                else if (ifqy == "2")
                {
                    checkCpIN.Visible = false;
                    checkDbz.Visible = true;
                    menuItem7.Visible = false;
                    menuItem10.Visible = true;
                }
                else
                {
                    checkCpIN.Visible = true;
                    checkDbz.Visible = true;
                    menuItem7.Visible = true;
                    menuItem10.Visible = true;
                }
            cfg6050 = new SystemCfg(6050);
            cfg6051 = new SystemCfg(6051);
            cfg18003 = new SystemCfg(18003);
            if (cfg6050.Config.Trim() == "1")
            {
                string sql = "select a.*,b.INPATIENT_ID from  dbo.LS_AS_READREPORT a left join ZY_INPATIENT b on a.REG_NO=b.INPATIENT_NO  where     ISNULL(a.assaypat_type,1) =9 and DELETE_BIT=0 and dept_code=" + frmMain.Current_Dept.DeptId + "   and ( a.flag=0 or look_dr!=dbo.fun_getEmpName(isnull(b.ZY_DOC,0)))";
                sql = "select b.INPATIENT_ID,a.REG_NO,a.DEPT_CODE ,(case ISNULL(a.assaypat_type,1) when 9 then '危机报告' else '' end) as assaypat_type,(case ISNULL(a.High_Risk,0) when 1 then '高危菌株' else '' end) as High_Risk,ISNULL(a.WSW_LYX,'') as WSW_LYX from LS_AS_REPORT a  (nolock) " +
                        "   join ZY_INPATIENT b (nolock) on (a.REG_NO =b.INPATIENT_NO and b.flag in(1,3,4) ) " +
                        "  where (ISNULL(a.High_Risk,0) =1 or ISNULL(a.WSW_LYX,'')!='' or ISNULL(a.assaypat_type,1) =9)  " +
                        "   and a.DELETE_BIT=0 and a.TYPE =2  and a.CONF='S' and   not exists(select c.Rep_no  from LIS_SEE_WJ_REPORT_LOG c (nolock) where c.REP_NO=a.REP_NO and c.see_man_id !=b.ZY_DOC) and a.dept_code=" + frmMain.Current_Dept.DeptId;
                RelationalDatabase Database = new MsSqlServer();
                Database.Initialize(InstanceForm._database.ConnectionString);
                wjzTb = Database.GetDataTable(sql);
                //add by zouchihua 2013-8-13获得其它医技的危机值或者提示
                sql = "select *,dbo.fun_getEmpName(MASSEGEDOCTOR) fsr,dbo.fun_getDeptname(ZXKS) 发送科室  from JY_MASSEGE a join YJ_ZYSQ b on a.yjsqid=b.YJSQID where a.MASSEGESTATE=1  and b.SQKS=" + InstanceForm._currentDept.DeptId;//标题没有查看的
                Yjtb = Database.GetDataTable(sql);
                LisThr = new Thread(new ThreadStart(GetListb));
                LisThr.Start();
                Database.Dispose();
            }
            LoadWard();

            //显示页面确定
            ShowPage(DeptID);

            //初始化医生的病人
            InitDoctorsman(this.YS_ID);

            //创建功能菜单
            InitializeOutlookBar();

            for (int i = 0; i < 10; i++) openForm[i] = Guid.Empty;



            this.Activate();
            // 医生站主界面是否提示危机值结果
            this.listView1.Resize += new EventHandler(listView1_Resize);
            this.listView2.Resize += new EventHandler(listView2_Resize);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;

            this.timer3.Enabled = false;
            this.listView1.MouseLeave += new EventHandler(listView1_MouseLeave);

            // add pengyang 2015-8-12
            //if (_menuTag.Function_Name.ToUpper() == "Fun_Ts_zyys_main_1".ToUpper())
            //{
            //    label15.Visible = false;
            //    textBox1.Visible = false;
            //    button1.Visible = false;
            //}
            return;
            // AddEmr();
            //_dllform.Dock = DockStyle.Fill;

            tbPgemr.Text = "电子病历";
            tbPgemr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.TabPages.Add(tbPgemr);
            tbPgemr.Dock = System.Windows.Forms.DockStyle.Fill;
            //Panel plEmr = new Panel();

            tbPgemr.Controls.Add(plEmr);
            plEmr.Size = tbPgemr.Size;

            plEmr.Dock = DockStyle.Fill;

            plEmr.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AddEmr();
            //BackgroundWorker bw = new BackgroundWorker();
            //bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            //bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            //bw.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            AddEmr();
        }
        TabPage tbPgemr = new TabPage();
        Panel plEmr = new Panel();
        Form _dllform;
        public delegate void INvokefun();
        private void AddEmr()
        {
            //添加页面电子病历卡片
            //TabPage tbPgemr = new TabPage();

            object[] communicateValue = new object[6];
            communicateValue[0] = FrmMdiMain.CurrentUser.LoginCode.Trim();
            communicateValue[1] = ClassStatic.Current_BinID;
            communicateValue[2] = frmMain.Current_Dept.DeptId;
            communicateValue[3] = System.DateTime.Now.ToString();
            communicateValue[4] = System.DateTime.Now.ToString();
            communicateValue[5] = "";
            if (plEmr.InvokeRequired)
            {
                INvokefun Invoke = new INvokefun(AddEmr);
                this.BeginInvoke(Invoke);
            }
            else
            {
                _dllform = (Form)WorkStaticFun.InstanceForm("EmrHisDoctorInterface", "Fun_emr_docdor_interface", "病历书写", FrmMdiMain.CurrentUser, FrmMdiMain.CurrentDept, null, FrmMdiMain.Database, ref communicateValue);
                // add by yaokx 2014-03-10
                // InsertWindow iw = new InsertWindow(plEmr, _dllform.Handle);
                _dllform.Show();
                _dllform.WindowState = FormWindowState.Maximized;
            }


        }
        void frmwwcxm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmwwcxm.Dispose();
            frmwwcxm = null;
        }

        void listView2_Resize(object sender, EventArgs e)
        {

        }

        void listView1_Resize(object sender, EventArgs e)
        {

        }
        #endregion

        private void AddJsd(ListView MyLv)
        {
            int i = 0;
            MyLv.Controls.Clear();
            PictureBox[] gb = new PictureBox[MyLv.Items.Count];
            for (i = 0; i < MyLv.Items.Count; i++)
            {
                gb[i] = new PictureBox();
                gb[i].Size = new Size(12, 12);
                gb[i].Location = new Point(MyLv.Items[i].Position.X + 40, MyLv.Items[i].Position.Y);
                gb[i].Image = ImageTsd.Images[5];//5
                MyLv.Controls.Add(gb[i]);
            }
            int flag = 0;
            while (true)
            {
                if (flag == 0)
                {
                    gb[0].Image = ImageTsd.Images[1];
                    flag = 1;
                }
                else
                {
                    gb[0].Image = ImageTsd.Images[5];
                    flag = 0;
                }
            }
        }

        #region OUTLOOK CONTROL的代码
        void InitializeOutlookBar()
        {
            //创建功能菜单

            OutlookBarBand outlookShortcutsBand;
            outlookShortcutsBand = new OutlookBarBand("日常业务");
            outlookShortcutsBand.LargeImageList = this.imageList_png;
            //outlookShortcutsBand.Items.Add(new OutlookBarItem("病案首页", 8)); Modify By tany 2011-04-20
            outlookShortcutsBand.Items.Add(new OutlookBarItem("医嘱管理", 0));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("检查申请", 2));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("检验申请", 3));
            //outlookShortcutsBand.Items.Add(new OutlookBarItem("检查申请", 2));

            //Modify By Tany 2015-02-03 增加病理申请
            try
            {
                string sfqy = ApiFunction.GetIniString("bl", "是否启用", Constant.ApplicationDirectory + "\\bl.ini");
                if (sfqy == "1")
                {
                    outlookShortcutsBand.Items.Add(new OutlookBarItem("病理申请", 3));
                }
            }
            catch
            {
            }

            /* 屏蔽Modify By Tany 2015-02-03
            if (lg == 3)
            {
                outlookShortcutsBand.Items.Add(new OutlookBarItem("手术审核", 4));
            }
            else
            {
                outlookShortcutsBand.Items.Add(new OutlookBarItem("手术申请", 4));
            }
            */

            try
            {
                SystemCfg cfg = new SystemCfg(6209);

                if (cfg.Config.Equals("0"))
                {
                    outlookShortcutsBand.Items.Add(new OutlookBarItem("会诊管理", 20));
                }
            }
            catch { }

            outlookShortcutsBand.Items.Add(new OutlookBarItem("特殊治疗", 6));
            if (lg == 3 || lg == 4 || lg == 0)//如果有主任权限、查询组、administrator就显示该组功能
            {
                //				if(lg==3) outlookShortcutsBand.Items .Add (new OutlookBarItem ("材料申领",8));
                //				outlookShortcutsBand.Items .Add (new OutlookBarItem ("材料统计",8));
                outlookShortcutsBand.Items.Add(new OutlookBarItem("排班管理", 9));
            }
            outlookShortcutsBand.Background = Color.DarkSlateBlue;
            //			outlookShortcutsBand.Background2=Color.BurlyWood;
            outlookShortcutsBand.TextColor = Color.White;
            outlookBar1.Bands.Add(outlookShortcutsBand);

            OutlookBarBand outlookShortcutsBand1;
            outlookShortcutsBand1 = new OutlookBarBand("查询功能");
            outlookShortcutsBand1.LargeImageList = this.imageList_png;
            outlookShortcutsBand1.Items.Add(new OutlookBarItem("出院病人查询", 17));//add by zouchihua 2013-6-4

            outlookShortcutsBand1.Items.Add(new OutlookBarItem("护理信息", 17));
            ///-----------------------------------------/屏蔽掉了手术管理-------------------------------------------//
            outlookShortcutsBand1.Items.Add(new OutlookBarItem("手术查询", 4));
            outlookShortcutsBand1.Items.Add(new OutlookBarItem("病人信息查询", 1));
            outlookShortcutsBand1.Items.Add(new OutlookBarItem("病人费用明细", 7));
            outlookShortcutsBand1.Items.Add(new OutlookBarItem("病人历史医嘱查询", 13));
            //			outlookShortcutsBand1.Items.Add(new OutlookBarItem("科室基数药", 5));
            outlookShortcutsBand1.Items.Add(new OutlookBarItem("药品综合查询", 16));
            outlookShortcutsBand1.Items.Add(new OutlookBarItem("医嘱项目查询", 16));
            outlookShortcutsBand1.Items.Add(new OutlookBarItem("医嘱用法查询", 16));
            outlookShortcutsBand1.Items.Add(new OutlookBarItem("排班查询", 16));
            outlookShortcutsBand1.Background = Color.DarkSlateGray;
            //			outlookShortcutsBand1.Background2=Color.BurlyWood;
            outlookShortcutsBand1.TextColor = Color.White;
            outlookBar1.Bands.Add(outlookShortcutsBand1);

            /*Modify By tany 2011-08-18 暂时屏蔽查询功能
            if (lg == 3 || lg == 4 || lg == 0)//如果有主任权限、查询组、administrator就显示该组功能
            {
                OutlookBarBand outlookShortcutsBand2;
                outlookShortcutsBand2 = new OutlookBarBand("报表统计");
                outlookShortcutsBand2.LargeImageList = this.imageList_png;
                outlookShortcutsBand2.Items.Add(new OutlookBarItem("本病区病人费用统计", 10));
                outlookShortcutsBand2.Items.Add(new OutlookBarItem("按医生统计", 10));
                outlookShortcutsBand2.Items.Add(new OutlookBarItem("出院病人统计", 10));
                outlookShortcutsBand2.Items.Add(new OutlookBarItem("科室收入统计", 10));
                //outlookShortcutsBand2.Items.Add(new OutlookBarItem("项目收入统计", 10));
                outlookShortcutsBand2.Background = Color.DarkOliveGreen;
                //				outlookShortcutsBand2.Background2=Color.BurlyWood;
                outlookShortcutsBand2.TextColor = Color.White;
                outlookBar1.Bands.Add(outlookShortcutsBand2);
            }
            */

            OutlookBarBand outlookShortcutsBand3 = new OutlookBarBand("常用工具");
            outlookShortcutsBand3.LargeImageList = outlookLargeIcons;
            outlookShortcutsBand3.Items.Add(new OutlookBarItem("计算器", 0));
            outlookShortcutsBand3.Items.Add(new OutlookBarItem("画笔", 1));
            //			outlookShortcutsBand3.Items.Add(new OutlookBarItem("图象处理",2));
            outlookShortcutsBand3.Items.Add(new OutlookBarItem("记事本", 3));
            outlookShortcutsBand3.Items.Add(new OutlookBarItem("写字板", 4));
            outlookShortcutsBand3.Items.Add(new OutlookBarItem("通讯簿", 5));
            outlookShortcutsBand3.Background = SystemColors.ControlDarkDark;
            //			outlookShortcutsBand3.Background2=Color.BurlyWood;
            outlookShortcutsBand3.TextColor = Color.White;
            outlookBar1.Bands.Add(outlookShortcutsBand3);


            //添加控件的单击事件和设置字体
            outlookBar1.ItemClicked += new OutlookBarItemClickedHandler(OnOutlookBarItemClicked);
            outlookBar1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

            //控制控件的停靠
            outlookBar1.Dock = System.Windows.Forms.DockStyle.Left;
        }
        #endregion

        #region 功能菜单的实现(左边菜单项)
        void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            if (!(item.Text == "会诊管理") && (_istszlks && Current_Dept.WardId == ""))
            {
                return;
            }
            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null & (item.Text == "医嘱管理" || item.Text == "病案首页" || item.Text == "护理信息" || item.Text == "检验申请" || item.Text == "检查申请" || item.Text == "手术申请" || item.Text == "手术审核" || item.Text == "病人信息查询" || item.Text == "特殊治疗" || item.Text == "检查申请(部位)"))//|| item.Text == "会诊管理" 
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (item.Text == "医嘱管理" || item.Text == "病案首页" || item.Text == "护理信息" || item.Text == "检验申请" || item.Text == "检查申请" || item.Text == "电子病历" || item.Text == "手术申请" || item.Text == "手术审核" || item.Text == "特殊治疗")//|| item.Text == "会诊管理"
            {
                if (sBinID == Guid.Empty)
                {
                    MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (isWard == false)
                {
                    MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            this.Cursor = PubStaticFun.WaitCursor();

            switch (item.Text)
            {
                case "出院病人查询":
                    Ts_zyys_brxx.FrmOutInpatInfo frmOutInpat = new Ts_zyys_brxx.FrmOutInpatInfo(DeptID);
                    frmOutInpat.ShowDialog();
                    break;
                case "医嘱管理":
                    //add by zouchihua 2012-12-18  是否进入路径
                    if (cfg18003.Config.Trim() == "1" && myQuery.IsIntoPathWay(sBinID.ToString(), "0", frmMain.Current_Dept.DeptId))
                    {
                        menuItem7_Click(null, null);
                        return;
                    }
                    if (openform(sBinID) == true)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Arrow;
                        return;
                    }
                    ShowFrmYZGL(this._currentUser, this._currentDept, this.DeptBR, 0, 0);
                    break;
                case "病案首页":
                    if (listView2.FocusedItem == null || (listView2.FocusedItem != null && this.lg == 3))
                    {
                        ShowFrmCaseHistory();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("请在管辖页选择病人！");
                        break;
                    }
                case "护理信息":
                    ShowFrmHLXX();
                    break;
                case "手术申请":
                    if (outflag == true) return;
                    ShowFrmSSSQ();
                    break;
                case "特殊治疗":
                    if (outflag == true) return;
                    ShowFrmTSZL();
                    break;
                case "手术审核":
                    if (outflag == true) return;
                    ShowFrmSSSQ();
                    break;
                case "手术查询":
                    if (outflag == true) return;
                    ShowFrmSSCX();
                    break;
                case "会诊管理":
                    if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
                    {
                        ShowFrmHZGL(false);
                    }
                    else
                    {
                        ShowFrmHZGL(true);
                    }
                    break;
                case "检验申请":
                    ShowFrmJYSQ();
                    break;
                case "检查申请":
                    ShowFrmJCSQBW();
                    break;
                    //case "检查申请(部位)":
                    //    ShowFrmJCSQBW();
                    break;
                case "病理申请": //Add By Tany 2015-02-03
                    {
                        try
                        {
                            string sfqy = ApiFunction.GetIniString("bl", "是否启用", Constant.ApplicationDirectory + "\\bl.ini");
                            if (sfqy == "1")
                            {
                                Ts_Bl_interface.BlFactory bf = new Ts_Bl_interface.BlFactory();
                                //bf.Create("").ShowPatBlInfo(BinID, Ts_Bl_interface.PatientSource.住院);
                                bf.Create("").ShowBlSq(sBinID, Ts_Bl_interface.PatientSource.住院, InstanceForm._currentDept.DeptId);
                            }
                            else
                            {
                                MessageBox.Show("没有开启病理接口，请联系管理员");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
                case "排班查询":
                    ShowFrmYSPB();
                    break;
                case "排班管理":
                    FrmShift fs = new FrmShift();
                    if (this.lg == 2 || this.lg == 3) fs.purview = true;
                    else fs.purview = false;
                    fs.deptID = this.DeptID;
                    fs.ShowDialog();
                    break;
                /*
                case "材料申领":
                    HIS_LHX.FrmMaterial FM;
                    if(this.lg==3) FM=new HIS_LHX.FrmMaterial(true,this.YS_ID,this.DeptID);
                    else FM=new HIS_LHX.FrmMaterial(false,this.YS_ID,this.DeptID);
                    FM.WindowState=System.Windows.Forms.FormWindowState.Normal;
                    FM.StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
                    FM.ShowDialog();
                    break;
                case "材料统计":
                    frmMaterialsStat frmmaterialsStat=new frmMaterialsStat();
                    frmmaterialsStat.WindowState=System.Windows.Forms.FormWindowState.Normal;
                    frmmaterialsStat.StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
                    frmmaterialsStat.ShowDialog();
                    break;
                    */
                case "病人信息查询":
                    ShowFrmBRXX();
                    break;
                case "病人费用明细":
                    ShowFrmBRFY();
                    break;
                case "科室基数药":
                    ShowFrmKSYP();
                    break;
                case "药品综合查询":
                    ShowFrmYPCX();
                    break;
                case "病人历史医嘱查询":
                    ShowFrmOldYZ();
                    break;
                case "医嘱项目查询":
                    ShowFrmXMCX();
                    break;
                case "医嘱用法查询":
                    ShowFrmYFCX();
                    break;

                case "科室收入统计":
                    ShowFrmKSSRTJ();
                    break;
                case "按医生统计":
                    ShowFrmBRFYYSTJ();
                    break;
                case "本病区病人费用统计":
                    ShowFrmBRFYTJ();
                    break;
                case "出院病人统计":
                    ShowFrmCYBRTJ();
                    break;
                case "项目收入统计":
                    ShowFrmXMSRTJ();
                    break;

                case "计算器":
                    System.Diagnostics.Process.Start("calc.exe");
                    break;
                case "画笔":
                    System.Diagnostics.Process.Start("mspaint.exe");
                    break;
                case "通讯簿":
                    System.Diagnostics.Process.Start("wab.exe");
                    break;
                case "记事本":
                    System.Diagnostics.Process.Start("notepad.exe");
                    break;
                case "写字板":
                    System.Diagnostics.Process.Start("wordpad.exe");
                    break;
                case "图象处理":
                    try
                    {
                        System.Diagnostics.Process.Start("kodakimg.exe");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        #endregion

        #region 初始化医生的病人
        /// <summary>
        /// 初始化医生的病人
        /// </summary>
        /// <param name="YSID">医生的ID号</param>
        private void InitDoctorsman(long YSID)
        {
            //this.timer3.Enabled = true;
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabPage1":
                    {
                        InitView(YS_ID);
                        this.bt_CW.Visible = false;
                        this.butt_ks.Visible = false;
                        listView2.Items.Clear();
                        listView2.Controls.Clear();
                        listView3.Items.Clear();
                        listView4.Items.Clear();
                        break;
                    }
                case "tabPage2":
                    {
                        if (this.bt_CW.Text == "按床位") InitView(WardID, 1);
                        else InitView(WardID, 0);
                        //add by zouchihua 2012-2-27
                        //AddJsd(this.listView2);
                        this.bt_CW.Enabled = true;
                        this.bt_CW.Visible = true;
                        this.butt_ks.Visible = false;
                        listView1.Items.Clear();
                        listView1.Controls.Clear();
                        listView3.Items.Clear();
                        listView4.Items.Clear();
                        break;
                    }
                case "tabPage7"://本组 add by zouchihua 2013-11-21
                    InitViewGroup(YS_ID);
                    break;
                case "tabPage3":
                    {
                        InitView();
                        this.bt_CW.Visible = false;
                        this.butt_ks.Visible = false;
                        listView1.Items.Clear();
                        listView2.Items.Clear();
                        listView4.Items.Clear();
                        break;
                    }
                case "tabPage4"://特殊治疗初始化
                    {
                        InitView_TS(0);
                        this.bt_CW.Visible = false;
                        this.butt_ks.Enabled = true;
                        this.butt_ks.Visible = true;
                        listView1.Items.Clear();
                        listView2.Items.Clear();
                        listView3.Items.Clear();
                        break;
                    }
                case "tabPage5":
                    {
                        InitView_WRQ();
                        this.bt_CW.Visible = false;
                        this.butt_ks.Visible = false;
                        listView1.Items.Clear();
                        listView2.Items.Clear();
                        listView3.Items.Clear();
                        listView4.Items.Clear();
                        break;
                    }
                case "tabPage6":
                    {
                        InitView_JRRY();
                        this.bt_CW.Visible = false;
                        this.butt_ks.Visible = false;
                        listView1.Items.Clear();
                        listView2.Items.Clear();
                        listView3.Items.Clear();
                        listView4.Items.Clear();
                        break;
                    }
            }
            this.tabControl1.Refresh();

            richTextBoxEx1.Text = ShowMsgText();
        }


        #region 医生管辖病人
        /// <summary>
        /// 医生管辖内病人
        /// </summary>
        /// <param name="DocID">医生ID号</param>
        private void InitView(long DocID)
        {

            string S_Data = "";
            DataTable BedTb;
            if (checkCpIN.Checked)
                BedTb = myQuery.GetInpatientCp(1, this.DeptID, this.YS_ID, 0);
            else if (checkDbz.Checked)
                BedTb = myQuery.GetInpatientCp(1, this.DeptID, this.YS_ID, 1);
            else
                BedTb = myQuery.GetInpatient(1, this.DeptID, this.YS_ID);
            //DataTable BedTb = myQuery.GetInpatient(1, this.DeptID, this.YS_ID);
            if (cfg6050.Config.Trim() == "1")
            {
                Sfzy();
                gb = null;
                thr = null;
                Cpgb = null;
                GC.Collect();
                Cpgb = new PictureBox[BedTb.Rows.Count];
                gb = new PictureBox[BedTb.Rows.Count];
                thr = new Thread[BedTb.Rows.Count];

                this.listView1.Controls.Clear();
            }
            else
            {
                Sfzy();
                Cpgb = null;
                GC.Collect();
                Cpgb = new PictureBox[BedTb.Rows.Count];
                this.listView1.Controls.Clear();
            }

            this.listView1.Items.Clear();
            for (int i = 0; i <= BedTb.Rows.Count - 1; i++)
            {


                DataRow BedRow = BedTb.Rows[i];
                S_Data = BedRow["BED_NO"].ToString().Trim();
                if (BedRow["ORDER_BW"].ToString().Trim() != "0" && BedRow["ORDER_BW"].ToString().Trim() != "") S_Data += "*";
                if (BedRow["ORDER_BZ"].ToString().Trim() != "0" && BedRow["ORDER_BZ"].ToString().Trim() != "") S_Data += "△";
                if (Convert.ToString(BedRow["INPATIENT_ID"]).Trim() == "")
                {
                    if (BedRow["ISBF"].ToString() == "1") S_Data += "(包)";
                    this.listView1.Items.Add(S_Data.Trim(), 0).Tag = Convert.ToString(BedRow["STAG"]);
                }
                else
                {
                    if (BedRow["DISCHARGETYPE"].ToString() == "1") S_Data += "(" + BedRow["yblx_name"].ToString().Trim() + ")";   //医保	
                    S_Data += "\r\n" + Convert.ToString(BedRow["NAME"]).Trim();
                    if (BedRow["ISBF"].ToString() == "1") S_Data += "(包)";

                    //床位图标显示
                    //1=3岁以下无性别2=4~12女3=13~22女4=23~59女5=60+女6=4~12男7=13~22男8=23~59男9=60+男10=母婴
                    //1-10  普通
                    //11-20 死亡
                    //21-30 出院
                    //31-40 一级护理
                    //41-50 二级护理
                    //51-60 三级护理
                    //61-70 特级护理

                    int m = 0;//护理级别
                    int n = 0;//图片位置
                    int _type = 0;//类型
                    if (BedRow["FLAG"].ToString() == "4")        //申请出院 	
                    {
                        //死亡
                        if (Convert.ToInt32(BedRow["OUT_MODE"]) == 4)
                        {
                            _type = 1;
                        }
                        else
                        {
                            _type = 2;
                        }
                        try
                        {
                            n = GetBedImgNO(BedRow["SEX_NAME"].ToString().Trim(), Convert.ToInt32(BedRow["AGE"]), _type, Convert.ToInt32(BedRow["ISMYTS"]));
                            this.listView1.Items.Add(S_Data.Trim(), n).Tag = Convert.ToString(BedRow["STAG"]);
                        }
                        catch
                        {
                            this.listView1.Items.Add(S_Data.Trim(), 0).Tag = Convert.ToString(BedRow["STAG"]);
                        }
                    }
                    else
                    {
                        m = (Convert.ToString(BedRow["TENDLEVEL"]).Trim() == "" ? 0 : Convert.ToInt32(BedRow["TENDLEVEL"]));  // 护理级别
                        switch (m)
                        {
                            case 0://普通
                                _type = 0;
                                break;
                            case 1://三级
                                _type = 5;
                                break;
                            case 2://二级
                                _type = 4;
                                break;
                            case 3://一级
                                _type = 3;
                                break;
                            case 4://特级
                                _type = 6;
                                break;
                            default:
                                _type = 0;
                                break;
                        }
                        try
                        {
                            n = GetBedImgNO(BedRow["SEX_NAME"].ToString().Trim(), Convert.ToInt32(BedRow["AGE"]), _type, Convert.ToInt32(BedRow["ISMYTS"]));
                            this.listView1.Items.Add(S_Data.Trim(), n).Tag = Convert.ToString(BedRow["STAG"]);
                        }
                        catch
                        {
                            this.listView1.Items.Add(S_Data.Trim(), 0).Tag = Convert.ToString(BedRow["STAG"]);
                        }
                    }
                }
                //临床路径图片
                string cpststus = "0";
                cpststus = this.myQuery.GetCpzt(Convert.ToString(BedRow["INPATIENT_ID"]).Trim(), "0").ToString();
                if (Convert.ToString(BedRow["INPATIENT_ID"]).Trim() != "" && (cpststus.IndexOf("1") >= 0 || cpststus.IndexOf("9") >= 0))
                {
                    #region  //add by zouchihua 2012-4-21
                    Cpgb[i] = new PictureBox();
                    if (cpststus == "9")
                        Cpgb[i].Name = Convert.ToString(i) + "单病种";
                    Cpgb[i].Tag = i;
                    Cpgb[i].Size = new Size(20, 20);
                    //gb[i].MouseClick += new MouseEventHandler(Form3_MouseClick);
                    Cpgb[i].MouseEnter += new EventHandler(frmMain_MouseEnter1);
                    Cpgb[i].MouseDoubleClick += new MouseEventHandler(frmMain_MouseDoubleClick1);
                    Cpgb[i].Location = new Point(this.listView1.Items[i].Position.X + this.listView1.LargeImageList.ImageSize.Width, this.listView1.Items[i].Position.Y + this.listView1.LargeImageList.ImageSize.Height - 15);
                    if (this.myQuery.GetCpzt(Convert.ToString(BedRow["INPATIENT_ID"]).Trim(), "0").ToString().Trim() == "15")
                        Cpgb[i].Image = this.ImgCp.Images[0];
                    else
                        if (cpststus.Trim() == "9")
                            Cpgb[i].Image = this.ImgCp.Images[2];
                        else
                            Cpgb[i].Image = this.ImgCp.Images[1];
                    this.listView1.Controls.Add(Cpgb[i]);

                    #endregion
                }
                //add by zouchihua 2012-6-22
                if (cfg6050.Config.Trim() == "1")
                {
                    gb[i] = new PictureBox();
                    gb[i].Tag = Convert.ToString(BedRow["INPATIENT_ID"]).Trim();
                    //gb[i].MouseClick += new MouseEventHandler(Form3_MouseClick);
                    // gb[i].MouseEnter += new EventHandler(Form3_MouseEnter);
                    gb[i].Size = new Size(12, 12);
                    gb[i].Location = new Point(this.listView1.Items[i].Position.X + this.listView1.LargeImageList.ImageSize.Width, this.listView1.Items[i].Position.Y);
                    gb[i].Image = ImageTsd.Images[0];
                    this.listView1.Controls.Add(gb[i]);
                    //thr[i] = new Thread(new ParameterizedThreadStart(tt));
                    //int[] cs = new int[] { 0, i };
                    //thr[i].Start((object)cs);
                }
            }

            BindListview(listView1);
            //if (Firstflag == 1)
            //{
            //    Firstflag = 0;
            //    return;
            //}
        }
        #endregion

        private void InitViewGroup(long DocID)
        {

            string S_Data = "";
            DataTable BedTb;
            if (checkCpIN.Checked)
                BedTb = myQuery.GetInpatientCp(4, this.DeptID, this.YS_ID, 0);
            else if (checkDbz.Checked)
                BedTb = myQuery.GetInpatientCp(4, this.DeptID, this.YS_ID, 1);
            else
                BedTb = myQuery.GetInpatient(4, this.DeptID, this.YS_ID);
            //DataTable BedTb = myQuery.GetInpatient(1, this.DeptID, this.YS_ID);
            if (cfg6050.Config.Trim() == "1")
            {
                Sfzy();
                gb = null;
                thr = null;
                Cpgb = null;
                GC.Collect();
                Cpgb = new PictureBox[BedTb.Rows.Count];
                gb = new PictureBox[BedTb.Rows.Count];
                thr = new Thread[BedTb.Rows.Count];

                this.myListview1.Controls.Clear();
            }
            else
            {
                Sfzy();
                Cpgb = null;
                GC.Collect();
                Cpgb = new PictureBox[BedTb.Rows.Count];
                this.myListview1.Controls.Clear();
            }

            this.myListview1.Items.Clear();
            for (int i = 0; i <= BedTb.Rows.Count - 1; i++)
            {


                DataRow BedRow = BedTb.Rows[i];
                S_Data = BedRow["BED_NO"].ToString().Trim();
                if (BedRow["ORDER_BW"].ToString().Trim() != "0" && BedRow["ORDER_BW"].ToString().Trim() != "") S_Data += "*";
                if (BedRow["ORDER_BZ"].ToString().Trim() != "0" && BedRow["ORDER_BZ"].ToString().Trim() != "") S_Data += "△";
                if (Convert.ToString(BedRow["INPATIENT_ID"]).Trim() == "")
                {
                    if (BedRow["ISBF"].ToString() == "1") S_Data += "(包)";
                    this.myListview1.Items.Add(S_Data.Trim(), 0).Tag = Convert.ToString(BedRow["STAG"]);
                }
                else
                {
                    if (BedRow["DISCHARGETYPE"].ToString() == "1") S_Data += "(" + BedRow["yblx_name"].ToString().Trim() + ")";   //医保	
                    S_Data += "\r\n" + Convert.ToString(BedRow["NAME"]).Trim();
                    if (BedRow["ISBF"].ToString() == "1") S_Data += "(包)";

                    //床位图标显示
                    //1=3岁以下无性别2=4~12女3=13~22女4=23~59女5=60+女6=4~12男7=13~22男8=23~59男9=60+男10=母婴
                    //1-10  普通
                    //11-20 死亡
                    //21-30 出院
                    //31-40 一级护理
                    //41-50 二级护理
                    //51-60 三级护理
                    //61-70 特级护理

                    int m = 0;//护理级别
                    int n = 0;//图片位置
                    int _type = 0;//类型
                    if (BedRow["FLAG"].ToString() == "4")        //申请出院 	
                    {
                        //死亡
                        if (Convert.ToInt32(BedRow["OUT_MODE"]) == 4)
                        {
                            _type = 1;
                        }
                        else
                        {
                            _type = 2;
                        }
                        try
                        {
                            n = GetBedImgNO(BedRow["SEX_NAME"].ToString().Trim(), Convert.ToInt32(BedRow["AGE"]), _type, Convert.ToInt32(BedRow["ISMYTS"]));
                            this.myListview1.Items.Add(S_Data.Trim(), n).Tag = Convert.ToString(BedRow["STAG"]);
                        }
                        catch
                        {
                            this.listView1.Items.Add(S_Data.Trim(), 0).Tag = Convert.ToString(BedRow["STAG"]);
                        }
                    }
                    else
                    {
                        m = (Convert.ToString(BedRow["TENDLEVEL"]).Trim() == "" ? 0 : Convert.ToInt32(BedRow["TENDLEVEL"]));  // 护理级别
                        switch (m)
                        {
                            case 0://普通
                                _type = 0;
                                break;
                            case 1://三级
                                _type = 5;
                                break;
                            case 2://二级
                                _type = 4;
                                break;
                            case 3://一级
                                _type = 3;
                                break;
                            case 4://特级
                                _type = 6;
                                break;
                            default:
                                _type = 0;
                                break;
                        }
                        try
                        {
                            n = GetBedImgNO(BedRow["SEX_NAME"].ToString().Trim(), Convert.ToInt32(BedRow["AGE"]), _type, Convert.ToInt32(BedRow["ISMYTS"]));
                            this.myListview1.Items.Add(S_Data.Trim(), n).Tag = Convert.ToString(BedRow["STAG"]);
                        }
                        catch
                        {
                            this.myListview1.Items.Add(S_Data.Trim(), 0).Tag = Convert.ToString(BedRow["STAG"]);
                        }
                    }
                }
                //临床路径图片
                string cpststus = "0";
                cpststus = this.myQuery.GetCpzt(Convert.ToString(BedRow["INPATIENT_ID"]).Trim(), "0").ToString();
                if (Convert.ToString(BedRow["INPATIENT_ID"]).Trim() != "" && (cpststus.IndexOf("1") >= 0 || cpststus.IndexOf("9") >= 0))
                {
                    #region  //add by zouchihua 2012-4-21
                    Cpgb[i] = new PictureBox();
                    if (cpststus == "9")
                        Cpgb[i].Name = Convert.ToString(i) + "单病种";
                    Cpgb[i].Tag = i;
                    Cpgb[i].Size = new Size(20, 20);
                    //gb[i].MouseClick += new MouseEventHandler(Form3_MouseClick);
                    Cpgb[i].MouseEnter += new EventHandler(frmMain_MouseEnter1);
                    Cpgb[i].MouseDoubleClick += new MouseEventHandler(frmMain_MouseDoubleClick1);
                    Cpgb[i].Location = new Point(this.myListview1.Items[i].Position.X + this.myListview1.LargeImageList.ImageSize.Width, this.myListview1.Items[i].Position.Y + this.myListview1.LargeImageList.ImageSize.Height - 15);
                    if (this.myQuery.GetCpzt(Convert.ToString(BedRow["INPATIENT_ID"]).Trim(), "0").ToString().Trim() == "15")
                        Cpgb[i].Image = this.ImgCp.Images[0];
                    else
                        if (cpststus.Trim() == "9")
                            Cpgb[i].Image = this.ImgCp.Images[2];
                        else
                            Cpgb[i].Image = this.ImgCp.Images[1];
                    this.myListview1.Controls.Add(Cpgb[i]);

                    #endregion
                }
                //add by zouchihua 2012-6-22
                if (cfg6050.Config.Trim() == "1")
                {
                    gb[i] = new PictureBox();
                    gb[i].Tag = Convert.ToString(BedRow["INPATIENT_ID"]).Trim();
                    //gb[i].MouseClick += new MouseEventHandler(Form3_MouseClick);
                    // gb[i].MouseEnter += new EventHandler(Form3_MouseEnter);
                    gb[i].Size = new Size(12, 12);
                    gb[i].Location = new Point(this.myListview1.Items[i].Position.X + this.myListview1.LargeImageList.ImageSize.Width, this.myListview1.Items[i].Position.Y);
                    gb[i].Image = ImageTsd.Images[0];
                    this.myListview1.Controls.Add(gb[i]);
                    //thr[i] = new Thread(new ParameterizedThreadStart(tt));
                    //int[] cs = new int[] { 0, i };
                    //thr[i].Start((object)cs);
                }
            }

            BindListview(myListview1);
            //if (Firstflag == 1)
            //{
            //    Firstflag = 0;
            //    return;
            //}
        }
        private void dl(int i, int index)
        {
            if (gb[index].InvokeRequired)
            {
                txgb dg = new txgb(dl);
                this.Invoke(dg, i, index);

            }
            else
            {
                gb[index].Image = ImageTsd.Images[i];
            }
        }
        private void tt(object cs)
        {
            int falg = 0;
            int[] css = cs as int[];
            int index = css[1];
            while (true)
            {
                if (falg == 0)
                {
                    dl(2, index);
                    falg = 1;
                }
                else
                {
                    dl(5, index);
                    falg = 0;
                }
                Thread.Sleep(300);
            }
        }
        void listView1_GD()
        {
            //MessageBox.Show("dfdf");
            int i = 0;
            for (i = 0; i < this.listView1.Items.Count; i++)
            {
                scroll(0, i, listView1);
            }
        }
        void listView2_GD()
        {
            //MessageBox.Show("dfdf");
            int i = 0;
            for (i = 0; i < this.listView2.Items.Count; i++)
            {
                scroll(0, i, listView2);
            }
        }
        private void Sfzy()
        {
            if (thr == null)
                return;
            int i = 0;
            for (i = 0; i < thr.Length; i++)
            {
                if (thr[i] == null)
                    continue;
                else
                {
                    thr[i].Abort();
                }
            }
            Ts_zyys_public.PulicStatiFuntion.GCCollect();
            Ts_zyys_public.PulicStatiFuntion.ClearMemory();
        }
        private void scroll(int i, int index, ListView mylistView)
        {
            try
            {
                int x = GetScrollPos(mylistView.Handle, 0);
                int y = GetScrollPos(mylistView.Handle, 1);
                if (Cpgb[index] != null)
                    Cpgb[index].Location = new Point(mylistView.Items[index].Position.X + mylistView.LargeImageList.ImageSize.Width - x, mylistView.Items[index].Position.Y + mylistView.LargeImageList.ImageSize.Height - 15 - y);
                if (gb[index].InvokeRequired)
                {
                    Delegtesroll dg = new Delegtesroll(scroll);
                    this.Invoke(dg, i, mylistView);
                }
                else
                {

                    gb[index].Location = new Point(mylistView.Items[index].Position.X + mylistView.LargeImageList.ImageSize.Width - x, mylistView.Items[index].Position.Y - y);
                }

            }
            catch
            {

            }
        }
        #region 科室病人
        /// <summary>
        /// 科室病人
        /// </summary>
        /// <param name="wardId">病区ID</param>
        /// <param name="tab">按照什么模式显示病人列表(1为按床位显示，其余的按病房显示)</param>
        private void InitView(int wardId, int tab)
        {

            string S_Data = "";
            DataTable BedTb;
            if (checkCpIN.Checked)
                BedTb = myQuery.GetInpatientCp(2, this.DeptID, this.YS_ID, 0);
            else if (checkDbz.Checked)
                BedTb = myQuery.GetInpatientCp(2, this.DeptID, this.YS_ID, 1);
            else
                BedTb = myQuery.GetInpatient(2, this.DeptID, this.YS_ID);
            //string[] GroupbyField ={ "room_no" };
            //string[] ComputeField ={ };
            //string[] CField ={ };
            //TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
            //xcset.TsDataTable = BedTb;
            //DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "");
            int zl = 0;
            int kcw = 0;
            if (tab == 1)
            {
                for (int x = 0; x < BedTb.Rows.Count; x++)
                {
                    if (x != 0 && BedTb.Rows[x]["room_no"].ToString() != BedTb.Rows[x - 1]["room_no"].ToString())
                        zl++;
                }
            }
            if (cfg6050.Config.Trim() == "1")
            {
                Sfzy();
                gb = null;
                thr = null;
                Cpgb = null;
                GC.Collect();
                gb = new PictureBox[BedTb.Rows.Count + zl];
                Cpgb = new PictureBox[BedTb.Rows.Count + zl];
                thr = new Thread[BedTb.Rows.Count + zl];
                this.listView2.Controls.Clear();
            }
            else
            {
                Sfzy();
                Cpgb = null;
                GC.Collect();
                Cpgb = new PictureBox[BedTb.Rows.Count + zl];
                this.listView2.Controls.Clear();
            }
            this.listView2.Items.Clear();
            int j = 0;
            for (int i = 0; i <= BedTb.Rows.Count - 1; i++)
            {

                DataRow BedRow = BedTb.Rows[i];
                S_Data = BedRow["BED_NO"].ToString().Trim();
                if (BedRow["ORDER_BW"].ToString().Trim() != "0" && BedRow["ORDER_BW"].ToString().Trim() != "") S_Data += "*";
                if (BedRow["ORDER_BZ"].ToString().Trim() != "0" && BedRow["ORDER_BZ"].ToString().Trim() != "") S_Data += "△";

                //不同的房间隔开
                if (tab == 1)    //按床位分
                {
                    if (i != 0 && BedTb.Rows[i]["room_no"].ToString() != BedTb.Rows[i - 1]["room_no"].ToString())
                    {
                        this.listView2.Items.Add("");
                        //add by zouchihua 2012-6-22
                        if (cfg6050.Config.Trim() == "1")
                        {
                            gb[j] = new PictureBox();
                            gb[j].Tag = Convert.ToString("").Trim();
                            //gb[i].MouseClick += new MouseEventHandler(Form3_MouseClick);
                            // gb[i].MouseEnter += new EventHandler(Form3_MouseEnter);
                            gb[j].Size = new Size(12, 12);
                            gb[j].Location = new Point(this.listView2.Items[j].Position.X + this.listView2.LargeImageList.ImageSize.Width, this.listView2.Items[j].Position.Y);
                            gb[j].Image = ImageTsd.Images[5];
                            this.listView2.Controls.Add(gb[j]);
                            j++;

                            //thr[i] = new Thread(new ParameterizedThreadStart(tt));
                            //int[] cs = new int[] { 0, i };
                            //thr[i].Start((object)cs);
                        }
                        kcw++;
                    }
                }

                if (Convert.ToString(BedRow["INPATIENT_ID"]).Trim() == "")
                {
                    if (BedRow["ISBF"].ToString() == "1") S_Data += "(包)";
                    this.listView2.Items.Add(S_Data.Trim(), 0).Tag = Convert.ToString(BedRow["STAG"]);
                }
                else         //按病房分
                {
                    if (BedRow["DISCHARGETYPE"].ToString() == "1") S_Data += "(" + BedRow["yblx_name"].ToString().Trim() + ")";   //医保	
                    S_Data += "\r\n" + Convert.ToString(BedRow["NAME"]).Trim();
                    if (BedRow["ISBF"].ToString() == "1") S_Data += "(包)";
                    //床位图标显示
                    //1=3岁以下无性别2=4~12女3=13~22女4=23~59女5=60+女6=4~12男7=13~22男8=23~59男9=60+男10=母婴
                    //1-10  普通
                    //11-20 死亡
                    //21-30 出院
                    //31-40 一级护理
                    //41-50 二级护理
                    //51-60 三级护理
                    //61-70 特级护理

                    int m = 0;//护理级别
                    int n = 0;//图片位置
                    int _type = 0;//类型
                    if (BedRow["FLAG"].ToString() == "4")        //申请出院 	
                    {
                        //死亡
                        if (Convert.ToInt32(BedRow["OUT_MODE"]) == 4)
                        {
                            _type = 1;
                        }
                        else
                        {
                            _type = 2;
                        }
                        try
                        {
                            n = GetBedImgNO(BedRow["SEX_NAME"].ToString().Trim(), Convert.ToInt32(BedRow["AGE"]), _type, Convert.ToInt32(BedRow["ISMYTS"]));
                            this.listView2.Items.Add(S_Data.Trim(), n).Tag = Convert.ToString(BedRow["STAG"]);
                        }
                        catch
                        {
                            this.listView2.Items.Add(S_Data.Trim(), 0).Tag = Convert.ToString(BedRow["STAG"]);
                        }
                    }
                    else
                    {
                        m = (Convert.ToString(BedRow["TENDLEVEL"]).Trim() == "" ? 0 : Convert.ToInt32(BedRow["TENDLEVEL"]));  // 护理级别
                        switch (m)
                        {
                            case 0://普通
                                _type = 0;
                                break;
                            case 1://三级
                                _type = 5;
                                break;
                            case 2://二级
                                _type = 4;
                                break;
                            case 3://一级
                                _type = 3;
                                break;
                            case 4://特级
                                _type = 6;
                                break;
                            default:
                                _type = 0;
                                break;
                        }
                        try
                        {
                            n = GetBedImgNO(BedRow["SEX_NAME"].ToString().Trim(), Convert.ToInt32(BedRow["AGE"]), _type, Convert.ToInt32(BedRow["ISMYTS"]));
                            this.listView2.Items.Add(S_Data.Trim(), n).Tag = Convert.ToString(BedRow["STAG"]);
                        }
                        catch { this.listView2.Items.Add(S_Data.Trim(), 0).Tag = Convert.ToString(BedRow["STAG"]); }
                    }
                }
                //临床路径图片
                string cpststus = "0";
                cpststus = this.myQuery.GetCpzt(Convert.ToString(BedRow["INPATIENT_ID"]).Trim(), "0").ToString();
                if (Convert.ToString(BedRow["INPATIENT_ID"]).Trim() != "" && (cpststus.IndexOf("1") >= 0 || cpststus.IndexOf("9") >= 0))
                {
                    #region  //add by zouchihua 2012-4-21 以前用变量i

                    Cpgb[i + kcw] = new PictureBox();
                    if (cpststus.Trim() == "9")
                        Cpgb[i + kcw].Name = Convert.ToString((i + kcw)) + "单病种";
                    Cpgb[i + kcw].Tag = i + kcw;
                    Cpgb[i + kcw].Size = new Size(20, 20);
                    //gb[i].MouseClick += new MouseEventHandler(Form3_MouseClick);
                    Cpgb[i + kcw].MouseEnter += new EventHandler(frmMain_MouseEnter1);
                    Cpgb[i + kcw].MouseDoubleClick += new MouseEventHandler(frmMain_MouseDoubleClick1);
                    Cpgb[i + kcw].Location = new Point(this.listView2.Items[i + kcw].Position.X + this.listView2.LargeImageList.ImageSize.Width, this.listView2.Items[i + kcw].Position.Y + this.listView2.LargeImageList.ImageSize.Height - 15);
                    if (this.myQuery.GetCpzt(Convert.ToString(BedRow["INPATIENT_ID"]).Trim(), "0").ToString().Trim() == "15")
                        Cpgb[i + kcw].Image = this.ImgCp.Images[0];
                    else
                        if (cpststus.Trim() == "9")
                            Cpgb[i + kcw].Image = this.ImgCp.Images[2];
                        else
                            Cpgb[i + kcw].Image = this.ImgCp.Images[1];
                    this.listView2.Controls.Add(Cpgb[i + kcw]);

                    #endregion
                }
                //add by zouchihua 2012-6-22
                if (cfg6050.Config.Trim() == "1")
                {
                    gb[j] = new PictureBox();
                    gb[j].Tag = Convert.ToString(BedRow["INPATIENT_ID"]).Trim();
                    //gb[i].MouseClick += new MouseEventHandler(Form3_MouseClick);
                    // gb[i].MouseEnter += new EventHandler(Form3_MouseEnter);
                    gb[j].Size = new Size(12, 12);
                    gb[j].Location = new Point(this.listView2.Items[j].Position.X + this.listView2.LargeImageList.ImageSize.Width, this.listView2.Items[j].Position.Y);
                    gb[j].Image = ImageTsd.Images[5];
                    this.listView2.Controls.Add(gb[j]);
                    j++;
                    //thr[i] = new Thread(new ParameterizedThreadStart(tt));
                    //int[] cs = new int[] { 0, i };
                    //thr[i].Start((object)cs);
                }


            }

            BindListview(listView2);
            //if (Firstflag == 1)
            //{
            //    Firstflag = 0;
            //    return;
            //}
        }
        #endregion

        #region 获得床位图片的序号(年龄、护理级别、性别、状态判断)
        /// <summary>
        /// 获得床位图片的序号
        /// </summary>
        /// <param name="_sex">性别</param>
        /// <param name="_age">年龄</param>
        /// <param name="_type">类型(0=普通1=死亡2=出院3=一级护理4=二级护理5=三级护理6=特级护理)</param>
        /// <param name="_ismy">是否母婴</param>
        /// <returns></returns>
        private int GetBedImgNO(string _sex, int _age, int _type, int _ismy)
        {
            //1=3岁以下无性别2=4~12女3=13~22女4=23~59女5=60+女6=4~12男7=13~22男8=23~59男9=60+男10=母婴
            //1-10  普通
            //11-20 死亡
            //21-30 出院
            //31-40 一级护理
            //41-50 二级护理
            //51-60 三级护理
            //61-70 特级护理
            int m = 0;//年龄段
            int n = 0;//男女差别带来的位置差
            int _rtn = 0;

            if (cfg7205.Config == "1" && _ismy > 0)//yaokx 2014-06-27
            {
                if (_sex == "男")
                    n = 4;  //男从4位开始
                else
                    n = 0;//女从0位开始
            }
            else
            {
                if (_sex == "男")
                    n = 4;  //男从4位开始
                else
                    n = 0;//女从0位开始
            }


            //3岁以下不论男女
            if (_age <= 3)
            {
                m = 1;
                _rtn = _type * 10 + m;
            }
            if (_age > 3 && _age <= 12)
            {
                m = 2;
                _rtn = _type * 10 + m + n;
            }
            if (_age > 12 && _age <= 22)
            {
                m = 3;
                _rtn = _type * 10 + m + n;
            }
            if (_age > 22 && _age <= 59)
            {
                m = 4;
                _rtn = _type * 10 + m + n;
            }
            if (_age > 59)
            {
                m = 5;
                _rtn = _type * 10 + m + n;
            }
            //如果母婴直接取最后一位
            if (cfg7205.Config == "0" && _ismy > 0)
            {
                _rtn = _type * 10 + 10;
            }

            return _rtn;
        }
        #endregion

        //会诊病人
        private void InitView()
        {
            this.listView3.Items.Clear();

            DataTable ConTb = myQuery.GetInpatient(3, this.DeptID, this.YS_ID);
            if (ConTb.Rows.Count == 0) return;
            ListViewItem LItem = null;
            for (int i = 0; i < ConTb.Rows.Count; i++)
            {
                LItem = new ListViewItem(new string[]{ConTb.Rows[i]["INPATIENT_ID"].ToString(),
													   ConTb.Rows[i]["住院号"].ToString(),
													   ConTb.Rows[i]["姓名"].ToString(),
													   ConTb.Rows[i]["病区"].ToString(),
													   ConTb.Rows[i]["科室"].ToString(),
													   (Convert.ToDateTime(ConTb.Rows[i]["申请日期"])).ToString("yyyy-M-d hh:ss"),
													   ConTb.Rows[i]["申请医师"].ToString(),
													   ConTb.Rows[i]["content"].ToString()+"\r\n"+ConTb.Rows[i]["intent"].ToString(),
                                                        ConTb.Rows[i]["id"].ToString(),
                ConTb.Rows[i]["BABY_ID"].ToString(),ConTb.Rows[i]["collevel"].ToString()});

                this.listView3.Items.Add(LItem).Tag = ConTb.Rows[i]["STAG"].ToString();
                if (ConTb.Rows[i]["finish_flag"].ToString() == "2")//已完成会诊
                {
                    LItem.ForeColor = Color.Blue;
                    LItem.ImageIndex = 14;
                }
                if (ConTb.Rows[i]["level"].ToString() == "1")//急诊会诊
                {
                    LItem.ForeColor = Color.HotPink;
                }
            }
        }

        //特殊治疗病人
        private void InitView_TS(int type)
        {
            this.listView4.Items.Clear();
            TSTb = myQuery.GetTSapply(type, DeptID, 1, cmbWard.SelectedValue.ToString());
            if (TSTb.Rows.Count == 0) return;
            ListViewItem LItem = null;
            for (int i = 0; i < TSTb.Rows.Count; i++)
            {
                LItem = new ListViewItem(new string[]{TSTb.Rows[i]["INPATIENT_ID"].ToString(),
													   TSTb.Rows[i]["INPATIENT_NO"].ToString(),
													   TSTb.Rows[i]["BinName"].ToString(),
													   TSTb.Rows[i]["WARD_ID"].ToString(),
													   TSTb.Rows[i]["DeptName"].ToString(),
													   (Convert.ToDateTime(TSTb.Rows[i]["APPLY_DATE"])).ToString("yyyy-MM-dd HH:mm:ss"),
													   TSTb.Rows[i]["doc_name"].ToString(),
													   TSTb.Rows[i]["content"].ToString(),
                                                       TSTb.Rows[i]["id"].ToString()});

                this.listView4.Items.Add(LItem).Tag = TSTb.Rows[i]["STAG"].ToString();
            }
        }

        //未入区病人 Modify By Tany 2010-02-25
        private void InitView_WRQ()
        {
            try
            {
                string sSql = @"select in_date as 入院日期,inpatient_no as 住院号,x.name as 姓名, " +
                        "         sex_name 性别,JSFS_NAME 结算类型,yblx_name 医保类型,BRLX_NAME 病人类型,xzlx_name 险种类型,dylx_name 待遇类型, " +
                        "         dbo.fun_getempname(clinic_doc) 门诊医生,ryzd 入院诊断, " +
                        "         cur_dept_name as 所属科室," +
                        "         case when y.zkcs is null  then '新入院' else '转科'end as 病人来源" +
                        "    from vi_zy_vinpatient_all x " +
                    //只要转成功过,不管是否取消,都算过转科,不改变病人入院日期 Modify By tany 2009-10-28
                    //"    left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where cancel_bit=0 and finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                        "    left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                        "    where x.flag=1 and x.dept_id =" + InstanceForm._currentDept.DeptId + " " +
                        "   order by in_date ";

                DataTable tb = InstanceForm._database.GetDataTable(sSql);

                dgvPat.DataSource = tb;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //今日入院 Modify By Tany 2010-04-12
        private void InitView_JRRY()
        {
            try
            {
                string sSql = @"select in_date as 入院日期,inpatient_no as 住院号,x.name as 姓名, " +
                        "         sex_name 性别,JSFS_NAME 结算类型,yblx_name 医保类型,BRLX_NAME 病人类型,xzlx_name 险种类型,dylx_name 待遇类型, " +
                        "         dbo.fun_getempname(clinic_doc) 门诊医生,ryzd 入院诊断, " +
                        "         cur_dept_name as 所属科室," +
                        "         '新入院'as 病人来源" +
                        "    from vi_zy_vinpatient_all x " +
                    //只要转成功过,不管是否取消,都算过转科,不改变病人入院日期 Modify By tany 2009-10-28
                    //"    left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where cancel_bit=0 and finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                    //"    left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                        "    where x.flag<>10 and x.dept_id =" + InstanceForm._currentDept.DeptId + " and dbo.fun_getdate(in_date)=dbo.fun_getdate(getdate()) " +
                        "   order by in_date ";

                DataTable tb = InstanceForm._database.GetDataTable(sSql);

                dgvTodayIn.DataSource = tb;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        #region 是否是特殊科室
        /// <summary>
        /// 是否特殊科室
        /// </summary>
        /// <param name="deptID"> 登陆系统的科室名称 </param>
        /// <returns></returns>
        private bool IsTSdept(long deptID)
        {
            //获取特殊治疗科室
            DataTable tb = FrmMdiMain.Database.GetDataTable("select * from jc_dept_tszl where deptid=" + deptID);
            if (tb.Rows.Count > 0)
            {
                _iskdksly = Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["iskdksly"], "0"));
                _istszlks = true;
                return true;  //根据获得的DEPT_ID中第一位数字是否大于0且登陆系统的DEPT_ID是否就是特殊科室来判断是否进入特殊科室界面
            }
            else
            {
                _iskdksly = 0;
                return false;
            }
        }
        #endregion

        #region 选项页面显示控制
        private void ShowPage(long deptID)
        {
            SelEnd = false; //是否选项页面显示改变结束
            tabControl1.Visible = false;	//右边的病人窗体

            tabControl1.TabPages.Clear();

            IsTSdept(deptID);

            if (!(_istszlks && Current_Dept.WardId == ""))
            {
                tabControl1.TabPages.Add(tabPage1);
                //增加本组病人 add by zouchihua2013-11-21
                //tabControl1.TabPages.Add(tabPage7);
                tabControl1.TabPages.Add(tabPage2);
                tabControl1.TabPages.Add(tabPage3);
                tabControl1.TabPages.Add(tabPage5);
                tabControl1.TabPages.Add(tabPage6);

            }

            if (_istszlks)    //如果登陆的是特殊科室，则进入特殊科室界面
            {
                tabControl1.TabPages.Add(tabPage4);
                //add by zouchihua  2012-5-18 特殊治疗科室增加分娩功能
                SystemCfg cfg7124 = new SystemCfg(7124);
                string ss = "," + cfg7124.Config.Trim() + ",";
                if (ss.Contains(Current_Dept.DeptId.ToString().Trim() + ","))
                    分娩ToolStripMenuItem.Visible = true;
                else
                    分娩ToolStripMenuItem.Visible = false;
                cmbWard.Visible = true;
            }
            try
            {
                string hz = "select * from JC_DEPT_PROPERTY where HZ_FLAG=1 and dept_id=" + DeptID;
                DataTable hz_table = InstanceForm._database.GetDataTable(hz);
                if (hz_table.Rows.Count > 0 && !tabControl1.TabPages.Contains(tabPage3))
                    tabControl1.TabPages.Add(tabPage3);
            }
            catch { }

            SelEnd = true;
            tabControl1.Visible = true;
            tabControl1.Refresh();
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 || tabControl1.SelectedIndex == 1 || tabControl1.SelectedIndex == -1)
            {
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
            }

            toolTip1.Hide(listView2);

            if (tabControl1.SelectedTab == tabPage4)
            {
                cmbWard.Visible = true;
            }
            else
            {
                cmbWard.Visible = false;
            }
            if (SelEnd) InitDoctorsman(this.YS_ID);
            PostMessage(this.listView1.Handle.ToInt32(), 0x020A, 0, 0);
            PostMessage(this.listView2.Handle.ToInt32(), 0x020A, 0, 0);
        }
        #endregion

        #region 工具栏按钮点击事件
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "EXIT")
            {
                Sfzy();
                thr = null;
                GC.Collect();
                if (LisThr != null && LisThr.ThreadState == System.Threading.ThreadState.Running)
                    LisThr.Abort();
                this.Close();
                return;
            }
            if (isWard == false)
            {
                MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (outflag == true && (e.Button.Tag.ToString() == "检查申请" || e.Button.Tag.ToString() == "检验申请")) return;

            this.Cursor = PubStaticFun.WaitCursor();

            switch (e.Button.Tag.ToString())
            {
                case "会诊申请":
                    ShowFrmHZGL(true);
                    break;
                case "检查申请":
                    ShowFrmJCSQBW();
                    break;
                    //case "检查申请(部位)":
                    //    ShowFrmJCSQBW();
                    break;
                case "检验申请":
                    ShowFrmJYSQ();
                    break;
                case "医嘱录入":
                    if (openform(sBinID) == true)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Arrow;
                        return;
                    }
                    ShowFrmYZGL(this._currentUser, this._currentDept, this.DeptBR, 0, 0);
                    break;
                case "病案首页":
                    if (listView2.FocusedItem == null || this.lg == 3) //或 有主任权限 不限
                    {
                        ShowFrmCaseHistory();
                    }
                    else
                    {
                        MessageBox.Show("请在管辖页选择病人！");
                    }
                    break;
            }
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        #endregion

        #region listView选项改变事件(管辖内病人、本科所有病人、会诊病人、特殊治疗病人)
        /// <summary>
        /// listView选项改变事件(管辖内病人、本科所有病人、会诊病人、特殊治疗病人)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            if (this.listView1.SelectedItems.Count == 0)
            {
                toolTip1.Hide(listView1);
                return;
            }
            if (this.listView1.FocusedItem.Text == "")
            {
                toolTip1.Hide(listView1);
                return;
            }
            if (this.listView1.SelectedItems.Count >= 1)
            {
                STAG = Convert.ToString(this.listView1.FocusedItem.Tag);
                if ((STAG.Trim() != "") && (STAG != null))
                {
                    this.patientInfo1.SetInpatientInfo(new Guid(STAG.Substring(0, 40)), Convert.ToInt64(STAG.Substring(40, 10)), Convert.ToInt16(STAG.Substring(50, 10).Trim()));
                }
                else
                {
                    this.patientInfo1.ClearInpatientInfo();
                }
            }
            else return;
            if (this.listView1.FocusedItem.Tag.ToString().Trim() != "")
            {
                sBinID = new Guid(this.listView1.FocusedItem.Tag.ToString().Substring(0, 40));
                DeptBR = Convert.ToInt32(this.listView1.FocusedItem.Tag.ToString().Substring(60, 10));
                sWardID = this.listView1.FocusedItem.Tag.ToString().Substring(70, 4);
                sWard_dept = this.Ward_dept;
                if (myQuery.OutFlag(sBinID) || myQuery.TurnFlag(this.DeptID, sBinID)) outflag = true;
                else outflag = false;
                isWard = true;
            }
            #region 显示医保信息 add by zouchihua 2012-9-19

            if (this.listView1.FocusedItem.Tag.ToString().Trim() != "")
            {
                STAG = Convert.ToString(this.listView1.FocusedItem.Tag);
                if ((STAG.Trim() != "") && (STAG != null))
                {
                    this.patientInfo1.SetInpatientInfo(new Guid(STAG.Substring(0, 40).Trim()), Convert.ToInt64(STAG.Substring(40, 10).Trim()), Convert.ToInt16(STAG.Substring(50, 10).Trim()));

                    //Add By Tany 2010-08-29
                    DataRow dr = patientInfo1.myRow;
                    if (dr != null)
                    {
                        string msg = "";
                        msg += "床        号：" + patientInfo1.lbBed.Text + "\n";
                        msg += "姓        名：" + patientInfo1.lbName.Text + "\n";
                        msg += "性        别：" + patientInfo1.lbSex.Text + "\n";
                        msg += "年        龄：" + patientInfo1.lbAge.Text + "\n";
                        msg += "费用类别：" + patientInfo1.lbJSLX.Text + "\n";
                        msg += "住  院  号：" + patientInfo1.lbID.Text + "\n";
                        msg += "病  人  ID：" + Convertor.IsNull(dr["inpatient_bano"], "") + "\n"; //Add By tany 2015-04-23 增加病人ID显示
                        //病情
                        string s_bq = "";
                        if (dr["order_bw"].ToString() != "0" && dr["order_bw"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                            s_bq = s_bq + "*" + "病危";
                        if (dr["order_bz"].ToString() != "0" && dr["order_bz"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                            s_bq = s_bq + "△" + "病重";
                        msg += "病        情：" + s_bq + "\n";
                        msg += "护理级别：" + (dr["HLJB_NAME"].ToString().Trim().Length > 4 ? dr["HLJB_NAME"].ToString().Trim().Substring(0, 4) : dr["HLJB_NAME"].ToString().Trim()) + "\n";
                        msg += "入院诊断：" + patientInfo1.lbRYZD.Text + "\n";
                        msg += "入院日期：" + patientInfo1.lbIn_Date.Text + "\n";
                        msg += "费用总额：" + patientInfo1.lbFYZE.Text + "\n";
                        msg += "未结算额：" + patientInfo1.lbWJSFY.Text + "\n";
                        msg += "预  收  款：" + patientInfo1.lbYJK.Text + "\n";
                        msg += "欠费限额：" + Convert.ToDecimal(dr["yjj_limit"]).ToString("0.00") + "\n";//Add By tany 2010-11-27
                        msg += "余        额：" + patientInfo1.lbYE.Text + "\n";
                        msg += "提        示：" + patientInfo1.lbTs.Text + "\n";
                        if (Convert.ToDecimal(Convertor.IsNull(dr["fyxz"], "0")) > 0)
                        {
                            msg += "费用限制：" + Convert.ToDecimal(dr["fyxz"]).ToString("0.00") + "\n";
                        }
                        if (Convertor.IsNull(dr["ybjs_date"], "") != "")
                        {
                            msg += "计算时间：" + Convert.ToDateTime(dr["ybjs_date"]).ToString("yyyy-MM-dd HH:mm:ss") + "\n";
                            msg += "医保总额：" + Convert.ToDecimal(dr["ybzfy"]).ToString("0.00") + "\n";
                            msg += "统筹支付：" + Convert.ToDecimal(dr["tczf"]).ToString("0.00") + "\n";
                            msg += "账户支付：" + Convert.ToDecimal(dr["zhzf"]).ToString("0.00") + "\n";
                            msg += "其他支付：" + Convert.ToDecimal(dr["qtzf"]).ToString("0.00") + "\n";
                            msg += "现金支付：" + Convert.ToDecimal(dr["xjzf"]).ToString("0.00") + "\n";
                            msg += "医保余额：" + Convert.ToDecimal(Convert.ToDecimal(dr["yjk"]) - Convert.ToDecimal(dr["xjzf"])).ToString("0.00") + "\n";
                        }
                        string ryshbz = Convertor.IsNull(dr["rysh_bz"], "");
                        if (ryshbz != "")
                        {
                            msg += "入院备注：" + ryshbz + "\n";
                        }
                        //Add By Tany 2011-01-05
                        msg += "描        述：" + dr["SICKDESCRIPTION"].ToString().Trim() + "\n";
                        toolTip1.Show(msg, listView1, this.listView1.SelectedItems[0].Position.X + 50, this.listView1.SelectedItems[0].Position.Y + 40, 60000);
                    }
                    else
                    {
                        toolTip1.Hide(listView1);
                    }
                }
                else
                {
                    this.patientInfo1.ClearInpatientInfo();

                    toolTip1.Hide(listView1);
                }
            }
            #endregion
        }
        private void listView2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (this.listView2.SelectedItems.Count == 0)
                {
                    toolTip1.Hide(listView2);
                    return;
                }
                if (this.listView2.FocusedItem.Text == "")
                {
                    toolTip1.Hide(listView2);
                    return;
                }
                if (this.listView2.FocusedItem.Tag.ToString().Trim() != "")
                {
                    STAG = Convert.ToString(this.listView2.FocusedItem.Tag);
                    if ((STAG.Trim() != "") && (STAG != null))
                    {
                        this.patientInfo1.SetInpatientInfo(new Guid(STAG.Substring(0, 40).Trim()), Convert.ToInt64(STAG.Substring(40, 10).Trim()), Convert.ToInt16(STAG.Substring(50, 10).Trim()));

                        //Add By Tany 2010-08-29
                        DataRow dr = patientInfo1.myRow;
                        if (dr != null)
                        {
                            string msg = "";
                            msg += "床        号：" + patientInfo1.lbBed.Text + "\n";
                            msg += "姓        名：" + patientInfo1.lbName.Text + "\n";
                            msg += "性        别：" + patientInfo1.lbSex.Text + "\n";
                            msg += "年        龄：" + patientInfo1.lbAge.Text + "\n";
                            msg += "费用类别：" + patientInfo1.lbJSLX.Text + "\n";
                            msg += "住  院  号：" + patientInfo1.lbID.Text + "\n";
                            msg += "病  人  ID：" + Convertor.IsNull(dr["inpatient_bano"], "") + "\n"; //Add By tany 2015-04-23 增加病人ID显示
                            //病情
                            string s_bq = "";
                            if (dr["order_bw"].ToString() != "0" && dr["order_bw"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                                s_bq = s_bq + "*" + "病危";
                            if (dr["order_bz"].ToString() != "0" && dr["order_bz"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                                s_bq = s_bq + "△" + "病重";
                            msg += "病        情：" + s_bq + "\n";
                            msg += "护理级别：" + (dr["HLJB_NAME"].ToString().Trim().Length > 4 ? dr["HLJB_NAME"].ToString().Trim().Substring(0, 4) : dr["HLJB_NAME"].ToString().Trim()) + "\n";
                            msg += "入院诊断：" + patientInfo1.lbRYZD.Text + "\n";
                            msg += "入院日期：" + patientInfo1.lbIn_Date.Text + "\n";
                            msg += "费用总额：" + patientInfo1.lbFYZE.Text + "\n";
                            msg += "未结算额：" + patientInfo1.lbWJSFY.Text + "\n";
                            msg += "预  收  款：" + patientInfo1.lbYJK.Text + "\n";
                            msg += "欠费限额：" + Convert.ToDecimal(dr["yjj_limit"]).ToString("0.00") + "\n";//Add By tany 2010-11-27
                            msg += "余        额：" + patientInfo1.lbYE.Text + "\n";
                            msg += "提        示：" + patientInfo1.lbTs.Text + "\n";
                            if (Convert.ToDecimal(Convertor.IsNull(dr["fyxz"], "0")) > 0)
                            {
                                msg += "费用限制：" + Convert.ToDecimal(dr["fyxz"]).ToString("0.00") + "\n";
                            }
                            if (Convertor.IsNull(dr["ybjs_date"], "") != "")
                            {
                                msg += "计算时间：" + Convert.ToDateTime(dr["ybjs_date"]).ToString("yyyy-MM-dd HH:mm:ss") + "\n";
                                msg += "医保总额：" + Convert.ToDecimal(dr["ybzfy"]).ToString("0.00") + "\n";
                                msg += "统筹支付：" + Convert.ToDecimal(dr["tczf"]).ToString("0.00") + "\n";
                                msg += "账户支付：" + Convert.ToDecimal(dr["zhzf"]).ToString("0.00") + "\n";
                                msg += "其他支付：" + Convert.ToDecimal(dr["qtzf"]).ToString("0.00") + "\n";
                                msg += "现金支付：" + Convert.ToDecimal(dr["xjzf"]).ToString("0.00") + "\n";
                                msg += "医保余额：" + Convert.ToDecimal(Convert.ToDecimal(dr["yjk"]) - Convert.ToDecimal(dr["xjzf"])).ToString("0.00") + "\n";
                            }
                            string ryshbz = Convertor.IsNull(dr["rysh_bz"], "");
                            if (ryshbz != "")
                            {
                                msg += "入院备注：" + ryshbz + "\n";
                            }
                            //Add By Tany 2011-01-05
                            msg += "描        述：" + dr["SICKDESCRIPTION"].ToString().Trim() + "\n";
                            toolTip1.Show(msg, listView2, this.listView2.SelectedItems[0].Position.X + 50, this.listView2.SelectedItems[0].Position.Y + 40, 60000);
                        }
                        else
                        {
                            toolTip1.Hide(listView2);
                        }
                    }
                    else
                    {
                        this.patientInfo1.ClearInpatientInfo();

                        toolTip1.Hide(listView2);
                    }
                    sBinID = new Guid(this.listView2.FocusedItem.Tag.ToString().Substring(0, 40));
                    DeptBR = Convert.ToInt32(this.listView2.FocusedItem.Tag.ToString().Substring(60, 10));
                    sWardID = this.listView2.FocusedItem.Tag.ToString().Substring(70, 4);
                    sWard_dept = this.Ward_dept;
                    if (myQuery.OutFlag(sBinID) || myQuery.TurnFlag(this.DeptID, sBinID)) outflag = true;
                    else outflag = false;
                    if (DeptBR != Convert.ToInt64(DeptID)) isWard = false;
                    else isWard = true;
                }
                else
                {
                    sBinID = Guid.Empty;
                    sWardID = "";

                    toolTip1.Hide(listView2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listView3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.listView3.SelectedItems.Count >= 1)
            {
                try
                {
                    STAG = Convert.ToString(this.listView3.FocusedItem.Tag);
                    if ((STAG.Trim() != "") && (STAG != null))
                    {
                        this.patientInfo2.SetInpatientInfo(new Guid(STAG.Substring(0, 40)), Convert.ToInt64(STAG.Substring(40, 10)), Convert.ToInt32(STAG.Substring(50, 10).Trim()));

                        this.richTBoxCon.Text = this.listView3.FocusedItem.SubItems[7].Text.Trim();
                        if (this.richTBoxCon.Text == "") this.richTBoxCon.Text = "详见会诊申请单";
                    }
                    else
                    {
                        this.patientInfo2.ClearInpatientInfo();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else return;
            if (this.listView3.FocusedItem.Tag.ToString().Trim() != "")
            {
                sBinID = new Guid(this.listView3.FocusedItem.Tag.ToString().Substring(0, 40));
                DeptBR = Convert.ToInt32(this.listView3.FocusedItem.Tag.ToString().Substring(60, 10));
                sWardID = this.listView3.FocusedItem.Tag.ToString().Substring(70, 4);
                sWard_dept = (new Department()).DeptId;
                long ss = Convert.ToInt64(this.listView3.FocusedItem.Tag.ToString().Substring(60, 10));
                if (myQuery.OutFlag(sBinID) || myQuery.TurnFlag(ss, sBinID)) outflag = true;
                else outflag = false;
            }

        }
        private void listView4_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.listView4.SelectedItems.Count >= 1)
            {
                STAG = Convert.ToString(this.listView4.FocusedItem.Tag);
                if ((STAG.Trim() != "") && (STAG != null))
                {
                    this.patientInfo3.SetInpatientInfo(new Guid(STAG.Substring(0, 40)), Convert.ToInt64(STAG.Substring(40, 10)), Convert.ToInt32(STAG.Substring(50, 10).Trim()));

                    this.richTBoxJR.Text = this.listView4.FocusedItem.SubItems[7].Text.Trim();
                    if (this.richTBoxJR.Text == "") this.richTBoxJR.Text = "详见申请单";
                }
                else
                {
                    this.patientInfo3.ClearInpatientInfo();
                }
            }
            else return;
            if (this.listView4.FocusedItem.Tag.ToString().Trim() != "")
            {
                sBinID = new Guid(this.listView4.FocusedItem.Tag.ToString().Substring(0, 40));
                DeptBR = Convert.ToInt32(this.listView4.FocusedItem.Tag.ToString().Substring(60, 10));
                sWardID = this.listView4.FocusedItem.Tag.ToString().Substring(70, 10);
                sWard_dept = (new Department()).DeptId;
                long depate = Convert.ToInt64(this.listView4.FocusedItem.Tag.ToString().Substring(60, 10));
                if (myQuery.OutFlag(sBinID) || myQuery.TurnFlag(depate, sBinID)) outflag = true;
                else outflag = false;
            }
        }
        #endregion

        #region 判断该病人的医嘱管理窗体是否打开
        private bool openform(Guid Bin_ID)
        {
            for (int i = 0; i < 10; i++)
            {
                if (openForm[i] == Bin_ID)
                {
                    MessageBox.Show("该病人的医嘱管理窗口已经打开。", "提示");
                    return true;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (openForm[i] == Guid.Empty)
                {
                    openForm[i] = Bin_ID;
                    return false;
                }

                if (i == 9)
                {
                    MessageBox.Show("医嘱管理窗口太多！", "提示");
                    return true;
                }
            }
            return true;
        }
        #endregion

        #region 菜单单击事件
        private void menuItem_BQ_Click(object sender, System.EventArgs e)
        {
            //			frmCWSX frmC=new frmCWSX();
            //			frmC.WardID=this.WardID;
            //			frmC.Show();			
        }

        private void menuItem_BASY_Click(object sender, System.EventArgs e)
        {
            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (isWard == false)
            {
                MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (listView2.FocusedItem == null || (listView2.FocusedItem != null && this.lg == 3))
            {
                //				this.Cursor=PublicStaticFun.WaitCursor();
                //				frmBinInfoEnter fb=new frmBinInfoEnter();
                //				fb.BinID=sBinID;
                //				fb.YS_ID=this.YS_ID;
                //				fb.cCon=this.cCon;	
                //				fb.lg=this.lg;
                //				fb.Show();
            }
            else MessageBox.Show("请在管辖页选择病人！");

            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        private void menuItem_SSSQ_Click(object sender, System.EventArgs e)
        {
            //手术申请
            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (isWard == false)
            {
                MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (outflag == true) return;
            ShowFrmSSSQ();
        }

        //三测单
        private void menuItem_SCD_Click(object sender, System.EventArgs e)
        {
            toolTip1.Hide(listView2);

            if (isWard == false && !(this.listView1.FocusedItem == null & listView2.FocusedItem == null))
            {
                MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ShowFrmSCD();
        }

        //医嘱管理
        private void menuItem_YZGL_Click(object sender, System.EventArgs e)
        {
            toolTip1.Hide(listView2);
            toolTip1.Hide(myListview1);
            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (listView2.FocusedItem != null)
            {
                if (listView2.FocusedItem.Text == "") return;
            }
            if (isWard == false)
            {
                MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //add by zouchihua 2012-12-18  是否进入路径
            if (cfg18003.Config.Trim() == "1" && myQuery.IsIntoPathWay(sBinID.ToString(), "0", frmMain.Current_Dept.DeptId))
            {
                menuItem7_Click(null, null);
                return;
            }

            if (openform(sBinID) == true) return;
            this.Cursor = PubStaticFun.WaitCursor();



            ShowFrmYZGL(this._currentUser, this._currentDept, this.DeptBR, 0, 0);
            //this.Cursor=System.Windows.Forms.Cursors.Arrow;
        }

        //药品查询
        private void menuItem_YPCX_Click(object sender, System.EventArgs e)
        {
            FrmQuery fq = new FrmQuery();
            fq.tabControl1.SelectedIndex = 0;
            fq.Show();
        }

        //医嘱项目查询
        private void menuItem_XMCX_Click(object sender, System.EventArgs e)
        {
            FrmQuery fq = new FrmQuery();
            fq.tabControl1.SelectedIndex = 1;
            fq.Show();
        }

        //检查申请
        private void menuItem_JCSQ_Click(object sender, System.EventArgs e)
        {
            toolTip1.Hide(listView2);

            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (isWard == false)
            {
                MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = PubStaticFun.WaitCursor();
            ShowFrmJCSQBW();
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        //检验申请
        private void menuItem_JYSQ_Click(object sender, System.EventArgs e)
        {
            toolTip1.Hide(listView2);

            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (isWard == false)
            {
                MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = PubStaticFun.WaitCursor();
            ShowFrmJYSQ();
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        //治疗申请
        private void menuItem_ZLSQ_Click(object sender, System.EventArgs e)
        {
            toolTip1.Hide(listView2);

            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (isWard == false)
            {
                MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = PubStaticFun.WaitCursor();
            ShowFrmZLSQ();
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        //会诊管理
        private void menuItem_HZ_Click(object sender, System.EventArgs e)
        {
            toolTip1.Hide(listView2);

            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                ShowFrmHZGL(false);
            }
            else
            {
                if (isWard == false)
                {
                    MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ShowFrmHZGL(true);
            }
        }

        //预约查询
        private void menuItem_YY_Click(object sender, System.EventArgs e)
        {
            //			FrmBooking fb=new FrmBooking();
            //			fb.DeptID=this.DeptID;
            //			fb.YS_ID=this.YS_ID;
            //			fb.BinID=sBinID;
            //			fb.WardID=sWardID;
            //			fb.Show();
        }

        //医生排班
        private void menuItem_YSPB_Click(object sender, System.EventArgs e)
        {
            FrmShift fs = new FrmShift();
            if (this.lg == 2 || this.lg == 3) fs.purview = true;
            else fs.purview = false;
            fs.deptID = this.DeptID;
            fs.Show();
        }

        //病人历史医嘱查询
        private void menuItem54_Click(object sender, System.EventArgs e)
        {
            toolTip1.Hide(listView2);

            Ts_zyys_brxx.FrmFindOldYZ frmold = new Ts_zyys_brxx.FrmFindOldYZ(this.DeptID);
            frmold.Show();
        }

        //科室基数药
        private void menuItem_JSYP_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("Ts_zyys_zhcx", "Fun_Ts_zyys_jsyp", "基数药品查询", new User(this._currentUser, FrmMdiMain.Database), new Department(this._currentDept, FrmMdiMain.Database), null, FrmMdiMain.Database);
        }

        //病人费用明细
        private void menuItem_BRFY_Click(object sender, System.EventArgs e)
        {
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            WorkStaticFun.InstanceForm("Ts_zyys_brxx", "Fun_Ts_zyys_fymx", "病人费用明细", new User(this._currentUser, FrmMdiMain.Database), new Department(this._currentDept, FrmMdiMain.Database), null, FrmMdiMain.Database);
        }

        //病人信息查询
        private void menuItem_BRXX_Click(object sender, System.EventArgs e)
        {
            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择病人", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            object[] communicateValue = new object[1];
            communicateValue[0] = sBinID;
            GetForm("Ts_zyys_brxx", "Fun_Ts_zyys_xxcx", "病人信息查询", this.YS_ID, this.DeptID, communicateValue, false);
        }

        //手术查询
        private void menuItem_SSCX_Click(object sender, System.EventArgs e)
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = 0;
            communicateValue[1] = "";
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_ssgl", "Fun_Ts_zyys_sscx", "手术查询", this._currentUser, this._currentDept, communicateValue, true);
        }

        //病人费用统计
        private void menuItem_FYTJ_Click(object sender, System.EventArgs e)
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = 0;
            communicateValue[1] = "";
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_bbtj", "Fun_Ts_zyys_brfytj", "病人费用统计", this._currentUser, this._currentDept, communicateValue, false);
        }

        //四测记录
        private void menuItem_SCJL_Click(object sender, System.EventArgs e)
        {
            toolTip1.Hide(listView2);

            if (isWard == false && !(this.listView1.FocusedItem == null & listView2.FocusedItem == null))
            {
                MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ShowFrmSCJL();
        }

        //会诊医嘱
        private void menuItem84_Click(object sender, System.EventArgs e)
        {
            toolTip1.Hide(listView2);

            //获取所属会诊科室的医生
            DataTable tempTb = myQuery.GetConDeptDoc(this.sBinID);
            if (tempTb.Rows.Count == 0)
            {
                MessageBox.Show("该病人没有会诊完成记录！不能开会诊医嘱。", "提示");
                return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tempPW tp = new tempPW();
            tp.myTb = tempTb;
            tp.ShowDialog();
            if (tp.flag == false) return;

            if (openform(sBinID) == true) return;
            this.Cursor = PubStaticFun.WaitCursor();
            ShowFrmYZGL(tp.userID, tp.ConDept, this.DeptBR, 0, 0);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        //用法查询
        private void menuItem_YFCX_Click(object sender, System.EventArgs e)
        {
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            WorkStaticFun.InstanceForm("Ts_zyys_zhcx", "Fun_Ts_zyys_yfcx", "用法查询", new User(this._currentUser, FrmMdiMain.Database), new Department(this._currentDept, FrmMdiMain.Database), null, FrmMdiMain.Database);
        }
        //特殊治疗
        private void menuItem_TS_Click(object sender, System.EventArgs e)
        {
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择本科室病人！", "提示"); return;
            }
            else
            {
                this.Cursor = PubStaticFun.WaitCursor();
                ShowFrmTSZL();
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
            }
        }
        //危重患者护理记录
        private void menuItem_WHJL_Click(object sender, System.EventArgs e)
        {
            toolTip1.Hide(listView2);

            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ShowFrmWHJL();
        }
        #endregion

        #region 记事记录
        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            //new file
            //			if (dirty) 
            //			{
            //				System.Windows.Forms.DialogResult dr = MessageBox.Show(this,
            //					"要保存当前更改吗？",
            //					"保存更改吗？",
            //					MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //
            //				switch (dr) 
            //				{
            //					case System.Windows.Forms.DialogResult.Yes:
            //						Save();
            //						break;
            //					case System.Windows.Forms.DialogResult.No:
            //						break;
            //				}
            //			}
            //			E=true;
            this.timer1.Stop(); this.richTextBoxEx1.ScrollBars = (RichTextBoxScrollBars)ScrollBars.Vertical;
            //			this.richTextBoxEx1.Text=this.richText;
            this.richTextBoxEx1.Focus();
            if (MessageBox.Show("新建文档吗？\n新建文档请按“是”；\n修改当前文档请按“否”。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                richTextBoxEx1.Clear();
                this.btnSave.Enabled = false;
                this.contextMenu2.MenuItems[2].Enabled = false;
            }
            else
            {
                this.richTextBoxEx1.Focus();
                this.richTextBoxEx1.Text = this.richText;
            }
            this.richTextBoxEx1.ReadOnly = false;

        }

        private void richTextBoxEx1_TextChanged(object sender, System.EventArgs e)
        {
            if (!dirty)
            {
                dirty = true;
                UpdateFormText();
            }

            this.richTextBoxEx1.Text.Remove(this.richTextBoxEx1.SelectionStart, this.richTextBoxEx1.SelectionLength);
        }
        private void UpdateFormText()
        {
            string file = noFilename;
            if (editingFileName != null && editingFileName.Length > 1)
            {
                file = editingFileName;
            }

            if (dirty)
            {
                this.Text = "住院医生工作站";// string.Format(dirtyCaptionFormat, file);
            }
            else
            {
                this.Text = "住院医生工作站";// string.Format(notDirtyCaptionFormat, file);
            }
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            this.timer1.Stop();
            this.richTextBoxEx1.Text = this.richText;
            //print preview
            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
                printDocument.Print();
        }

        private void btnOpen_Click(object sender, System.EventArgs e)
        {
            //open file
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.timer1.Stop();
                editingFileName = openFileDialog1.FileName;
                ReadEditingFile();
                //				this.timer1 .Start ();
                //				E=false;
                this.btnSave.Enabled = true;
                this.contextMenu2.MenuItems[2].Enabled = true;
            }
        }
        private void ReadEditingFile()
        {
            richTextBoxEx1.TextChanged -= new System.EventHandler(this.richTextBoxEx1_TextChanged);
            dirWatcher.EnableRaisingEvents = false;
            try
            {
                Stream s = new FileStream(editingFileName, FileMode.OpenOrCreate);
                FileInfo efInfo = new FileInfo(editingFileName);

                string fext = efInfo.Extension.ToUpper();

                if (fext.Equals(".RTF"))
                    richTextBoxEx1.LoadFile(s, RichTextBoxStreamType.RichText);
                else
                    richTextBoxEx1.LoadFile(s, RichTextBoxStreamType.PlainText);

                //				s.Close();

                dirWatcher.Path = efInfo.DirectoryName;
                dirWatcher.Filter = efInfo.Name;

                dirty = false;
                UpdateFormText();
            }
            finally
            {
                richTextBoxEx1.TextChanged += new System.EventHandler(this.richTextBoxEx1_TextChanged);
                dirWatcher.EnableRaisingEvents = true;
                Environment.CurrentDirectory = this.ExePath;
            }
            this.richText = this.richTextBoxEx1.Text;
            this.richTextBoxEx1.ReadOnly = true;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            this.timer1.Stop();
            if (dirty)
            {
                System.Windows.Forms.DialogResult dr = MessageBox.Show(this,
                    "要保存当前更改吗？",
                    "保存更改吗？",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                switch (dr)
                {
                    case DialogResult.Yes:
                        if (!Save()) return;
                        this.richText = this.richTextBoxEx1.Text;
                        this.richTextBoxEx1.ReadOnly = true;
                        break;
                    case DialogResult.No:
                        break;
                }
            }

            //			this.richText=this.richTextBoxEx1.Text;
            //			this.timer1.Start();
            //			E=false;

        }

        private void btnSaveAs_Click(object sender, System.EventArgs e)
        {
            this.timer1.Stop();
            //			this.richTextBoxEx1.Text=this.richText;
            System.Windows.Forms.DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                this.richText = this.richTextBoxEx1.Text;
                editingFileName = saveFileDialog1.FileName;
                FileInfo efInfo = new FileInfo(editingFileName);
                dirWatcher.EnableRaisingEvents = false;
                dirWatcher.Path = efInfo.DirectoryName;
                dirWatcher.Filter = efInfo.Name;
                if (!Save()) return;
                UpdateFormText();
            }
            //			this.timer1.Start();
            //			E=false;
            this.richTextBoxEx1.ReadOnly = true;
        }

        private bool Save()
        {
            if (System.Text.Encoding.Default.GetByteCount(richTextBoxEx1.Text.Trim()) > 999999)
            {
                MessageBox.Show("文本内容太大，不能保存！");
                return false;
            }
            //			if (editingFileName == null || editingFileName.Length < 1) 
            //			{
            //				SaveAs();
            //				return;
            //			}
            //
            dirWatcher.EnableRaisingEvents = false;
            FileStream fs = null;
            try
            {
                File.Delete(editingFileName);
                fs = new FileStream(editingFileName, FileMode.Create);
                //				if (File.Exists(editingFileName)) 
                //				{
                //					fs = new FileStream(editingFileName, FileMode.Open);
                //				}
                //				else 
                //				{
                //					fs = new FileStream(editingFileName, FileMode.Create);
                //				}

                string fext = (new FileInfo(editingFileName)).Extension.ToUpper();

                Console.WriteLine(editingFileName);

                if (fext.Equals(".RTF"))
                    richTextBoxEx1.SaveFile(fs, RichTextBoxStreamType.RichText);
                else
                    richTextBoxEx1.SaveFile(fs, RichTextBoxStreamType.PlainText);

                return true;

            }
            finally
            {
                if (fs != null)
                {
                    fs.Flush();
                    fs.Close();
                    dirty = false;
                }
                dirWatcher.EnableRaisingEvents = true;
                Environment.CurrentDirectory = this.ExePath;
            }
        }

        private void richTextBoxEx1_MouseEnter(object sender, System.EventArgs e)
        {
            //			this.timer1.Stop();
        }

        private void richTextBoxEx1_MouseLeave(object sender, System.EventArgs e)
        {
            //			if(E==false) this.timer1.Start();
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // Start at the beginning of the text
            m_nFirstCharOnPage = 0;

        }

        #region //FormatRangeDone方法和FormatRange方法
        //		private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //		{
        //			// Clean up cached information
        //			richTextBoxEx1.FormatRangeDone();		
        //		}
        //
        //		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //		{
        //			// To print the boundaries of the current page margins
        //			// uncomment the next line:
        //			//e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, e.MarginBounds);
        //    
        //			// make the RichTextBoxEx calculate and render as much text as will
        //			// fit on the page and remember the last character printed for the
        //			// beginning of the next page
        //			m_nFirstCharOnPage = richTextBoxEx1.FormatRange(false,
        //				e,
        //				m_nFirstCharOnPage,
        //				richTextBoxEx1.TextLength);
        //
        //			// check if there are more pages to print
        //			if (m_nFirstCharOnPage < richTextBoxEx1.TextLength)
        //				e.HasMorePages = true;
        //			else
        //				e.HasMorePages = false;
        //		}
        #endregion
        private void PromptForReload()
        {
            fileOnDiskModified = false;

            System.Windows.Forms.DialogResult dr = MessageBox.Show(this,
                "当前文件已更改，要重新加载它吗？",
                "文件更改通知",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                ReadEditingFile();
            }
        }

        private void dirWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            if (this.ContainsFocus)
            {
                PromptForReload();
            }
            else
            {
                fileOnDiskModified = true;
            }
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (this.richTextBoxEx1.Text.Length > 20)
                this.richTextBoxEx1.Text = this.richTextBoxEx1.Text.Remove(0, this.richTextBoxEx1.Lines[0].ToString().Length).Trim();
            else this.richTextBoxEx1.Text = this.richText;
        }
        private void menuItem72_Click(object sender, System.EventArgs e)
        {
            DateTime dTime = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            string strTime = "【" + dTime.ToLongDateString() + " " + dTime.ToShortTimeString() + "】\n";
            this.richTextBoxEx1.Text = richTextBoxEx1.Text.Trim() != "" ? richTextBoxEx1.Text.Trim() + "\n" + strTime : strTime;
            this.richTextBoxEx1.SelectionStart = this.richTextBoxEx1.Text.Length;
        }

        //停止滚动
        private void menuItem70_Click(object sender, System.EventArgs e)
        {
            this.richTextBoxEx1.Text = this.richText;
            this.timer1.Stop();
            this.richTextBoxEx1.ScrollBars = (RichTextBoxScrollBars)ScrollBars.Vertical;
        }

        //开始滚动，有修改先保存
        private void menuItem69_Click(object sender, System.EventArgs e)
        {
            if (this.richTextBoxEx1.Text != this.richText)
            {
                btnSave_Click(null, null);
            }
            this.timer1.Start();
            this.richTextBoxEx1.ScrollBars = (RichTextBoxScrollBars)ScrollBars.None;
        }

        private void richTextBoxEx1_Leave(object sender, System.EventArgs e)
        {
            this.Text = "住院医生工作站";
        }
        #endregion

        #region 将英文星期转化为中文
        private string ChineseWeek(string str)
        {
            switch (str)
            {
                case "Monday":
                    return "星期一";

                case "Tuesday":
                    return "星期二";

                case "Wednesday":
                    return "星期三";

                case "Thursday":
                    return "星期四";

                case "Friday":
                    return "星期五";

                case "Saturday":
                    return "星期六";

                case "Sunday":
                    return "星期日";
                default:
                    return "";
            }
        }
        #endregion

        private void listView1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) menuItem_YZGL_Click(null, null);
        }

        #region 床位排列按钮事件
        private void bt_CW_Click(object sender, System.EventArgs e)
        {
            if (this.bt_CW.Text == "按病房")
            {
                InitView(WardID, 1);
                this.bt_CW.Text = "按床位";
            }
            else
            {
                InitView(WardID, 0);
                this.bt_CW.Text = "按病房";
            }
        }
        #endregion

        #region 滚动条控制
        private void dougScrollingTextCtr1_Click(object sender, System.EventArgs e)
        {
            //SendMessage.FrmMessage fm = new SendMessage.FrmMessage();
            //fm.myTb = this.MessageTb;
            ////			fm.YS=this._currentUser;
            //fm.ShowDialog();
        }
        private void timer3_Tick(object sender, System.EventArgs e)
        {
            //MessageTb = upForm.selMessage(0, 1);
            //dougScrollingTextCtr1.Text = "";
            //if (MessageTb.Rows.Count == 0)
            //{
            //    dougScrollingTextCtr1.Visible = false;
            //    return;
            //}
            //dougScrollingTextCtr1.Visible = true;
            //for (int i = 0; i < MessageTb.Rows.Count; i++)
            //{
            //    dougScrollingTextCtr1.Text += MessageTb.Rows[i]["主题"].ToString().Trim() + "  ";
            //}
            //dougScrollingTextCtr1.Text += "(点击查看)  ";
            //检索lis结果的危机值
            //this.timer3.Enabled = false;
            //if (Jsq % Convert.ToInt32(cfg6051.Config.Trim()) == 0)
            //{
            //    string sql = "select a.*,b.INPATIENT_ID from  dbo.LS_AS_READREPORT a left join ZY_INPATIENT b on a.REG_NO=b.INPATIENT_NO  where   a.FLAG=9 and dept_code='" + frmMain.Current_Dept.DeptId + "'";
            //     wjzTb = FrmMdiMain.Database.GetDataTable(sql);
            //    if (tabControl1.SelectedTab.Text == "本科所有病人")
            //    {
            //        BindListview(this.listView2);
            //    }
            //    if (tabControl1.SelectedTab.Text == "管辖内病人")
            //    {
            //        BindListview(this.listView1);
            //    }
            //    Jsq = 0;
            //}
            //this.timer3.Enabled = true;
        }

        #endregion



        #region 选择病人事件(listView3,4)
        private void listView3_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.listView3.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            ShowFrmYZGL(this._currentUser, this._currentDept, this.DeptBR, 0, 0, new Guid(this.listView3.FocusedItem.SubItems[8].Text), 4);//会诊病人

        }
        private void listView4_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.listView4.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            ShowFrmYZGL(this._currentUser, this._currentDept, this.DeptBR, _iskdksly, 1, new Guid(this.listView4.FocusedItem.SubItems[8].Text), 1);//特殊治疗病人
        }

        private void listView3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) listView3_DoubleClick(null, null);
        }

        private void listView4_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) listView4_DoubleClick(null, null);
        }
        #endregion

        #region 窗体关闭事件
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (openForm[i] != Guid.Empty)
                {
                    isCloseC = false;
                    break;
                }
            }
            if (isCloseC == false)
            {
                if (MessageBox.Show("还有未关闭的医嘱录入窗体，是否要退出系统？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    isClose = true;
                }
                else
                {
                    isClose = false;
                    e.Cancel = true;
                }
                isCloseC = true;
                return;
            }
        }
        #endregion

        #region 获取窗体
        private void GetForm(string dllName, string functionName, string chineseName, long userID, long deptID, object[] communicateValue, bool showType)
        {
            try
            {


                User _user = new User(Convert.ToInt32(userID), FrmMdiMain.Database);
                Department _dept = new Department(Convert.ToInt32(deptID), FrmMdiMain.Database);

                //获得DLL中窗体
                Form _dllform = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, _user, _dept, null, FrmMdiMain.Database, ref communicateValue);
                _dllform.StartPosition = FormStartPosition.CenterScreen;
                if (showType) _dllform.ShowDialog();
                else _dllform.Show();
                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace.ToString());
                Cursor = Cursors.Default;
                return;
            }
            finally
            {
                for (int i = 0; i < 10; i++) openForm[i] = Guid.Empty;   //将已经打开的医嘱管理窗体进行初始化,如果没有这句话,在关闭医嘱窗体后再打开则会提示该医嘱窗体已经打开
                tabControl1_SelectedIndexChanged(null, null);
            }
        }

        /// <summary>
        /// 医嘱管理
        /// </summary>
        /// <param name="userid">开嘱医生userId</param>
        /// <param name="deptid">开嘱医生的科室ID</param>
        /// <param name="dept_br">病人所在科室ID</param>
        /// <param name="_iskdksly">是否开单科室领药</param>
        /// <param name="_tszl">是否特殊治疗</param>
        private void ShowFrmYZGL(long userid, long deptid, long dept_br, int _iskdksly, int _tszl)
        {

            string ifqy = ApiFunction.GetIniString("SfQy", "SfQy", Constant.ApplicationDirectory + "\\Cpset.ini");
            /*是否启用临床路径 0=不启用，1=启用临床路径 2=启用单病种 3=单病种临床路径都启用*/
            if (ifqy == "1" && cfg6083.Config.Trim() == "1")
            {
                string sql = "select * from PATH_WAY where STATUS=21 and (isnull(DEPTID,'')='' or DEPTID=" + deptid + " or PATHWAY_ID in (select pathway_id from path_way_dept k where k.dept_id=" + deptid + "))";
                //string sql = "select * from PATH_WAY where STATUS=21 and (isnull(DEPTID,'')='' or DEPTID=" + deptid + ") ";

                DataTable tb = InstanceForm._database.GetDataTable(sql);
                if (tb.Rows.Count > 0)
                {
                    string ljmc = "本科室有以下路径可以进入：\r\n";
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ljmc += "[" + tb.Rows[i]["PATHWAY_NAME"].ToString() + "]\r\n";
                    }
                    DataTable tbpath = InstanceForm._database.GetDataTable("select * from PATH_WAY_EXE where INPATIENT_ID='" + sBinID + "'");
                    if (tbpath.Rows.Count == 0)
                    {
                        tbpath = InstanceForm._database.GetDataTable("select * from path_Notin_record where inpatient_id='" + sBinID + "'");
                        if (tbpath.Rows.Count == 0)
                        {
                            if (MessageBox.Show(ljmc + "是否进入临床路径？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                string sqlinsert = "insert into  path_Notin_record (id,doc_id,ip,hostname,inpatient_id) values (newid()," + InstanceForm._currentUser.EmployeeId + ",'" + Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString() + "','" + Dns.GetHostName() + "','" + sBinID + "')";
                                InstanceForm._database.DoCommand(sqlinsert);
                            }
                            else
                            {
                                menuItem7_Click(null, null);
                                for (int i = 0; i < 10; i++) openForm[i] = Guid.Empty;   //将已经打开的医嘱管理窗体进行初始化,如果没有这句话,在关闭医嘱窗体后再打开则会提示该医嘱窗体已经打开
                                tabControl1_SelectedIndexChanged(null, null);
                                return;
                            }
                        }
                    }

                }
            }

            object[] communicateValue = new object[12];
            communicateValue[0] = sBinID;
            communicateValue[1] = sWardID;
            communicateValue[2] = dept_br;
            communicateValue[3] = this.STAG;
            communicateValue[4] = outflag;
            communicateValue[5] = this.lg;
            communicateValue[6] = this.sWard_dept;
            communicateValue[7] = _iskdksly;
            communicateValue[8] = _tszl;//0 代表会诊病人
            communicateValue[9] = Guid.Empty;
            communicateValue[10] = 0;//正常
            //yaokx 2014-06-21 医生定义出院，是否调用病历首页录入数据,先初始化窗体
            if (cfg6098.Config == "1")
            {
                communicateValue[11] = frmNavigation;
            }

            GetForm("Ts_zyys_yzgl", "Fun_Ts_zyys_yzgl", "医嘱管理", userid, deptid, communicateValue, true);
            //如果是临床路径的要刷新
            string cpzt = myQuery.GetCpzt(sBinID.ToString(), "0").Trim();
            //状态退出，或者完成时才刷新
            if ((cpzt.Trim() == "2" || cpzt.Trim() == "3"))
            {
                tabControl1_SelectedIndexChanged(null, null);
            }

        }
        /// <summary>
        /// 医嘱管理 用于特殊治疗和会诊申请 Modify by zouchihua 2011-11-01
        /// </summary>
        /// <param name="userid">开嘱医生userId</param>
        /// <param name="deptid">开嘱医生的科室ID</param>
        /// <param name="dept_br">病人所在科室ID</param>
        /// <param name="_iskdksly">是否开单科室领药</param>
        /// <param name="_tszl">是否特殊治疗</param>
        private void ShowFrmYZGL(long userid, long deptid, long dept_br, int _iskdksly, int _tszl, Guid tsapply_id, int Apply_type)
        {
            object[] communicateValue = new object[12];
            communicateValue[0] = sBinID;
            communicateValue[1] = sWardID;
            communicateValue[2] = dept_br;
            communicateValue[3] = this.STAG;
            communicateValue[4] = outflag;
            communicateValue[5] = this.lg;
            communicateValue[6] = this.sWard_dept;
            communicateValue[7] = _iskdksly;
            communicateValue[8] = _tszl;//0 代表会诊病人
            communicateValue[9] = tsapply_id;
            communicateValue[10] = Apply_type;
            try
            {
                //会诊病人增加一个baby_id
                communicateValue[11] = this.listView3.FocusedItem.SubItems[9].Text.Trim();
            }
            catch { communicateValue[11] = "0"; }

            GetForm("Ts_zyys_yzgl", "Fun_Ts_zyys_yzgl", "医嘱管理", userid, deptid, communicateValue, true);
        }
        /// <summary>
        /// 病案首页
        /// </summary>
        private void ShowFrmCaseHistory()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = sBinID;
            communicateValue[1] = "";
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_basy", "Fun_Ts_zyys_basy", "病案首页", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 护理信息
        /// </summary>
        private void ShowFrmHLXX()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = sBinID;
            communicateValue[1] = sWardID;
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = 0;
            GetForm("Ts_zyys_hlxx", "Fun_Ts_zyys_hlxx", "护理信息", this._currentUser, this._currentDept, communicateValue, false);
        }
        /// <summary>
        /// 手术申请
        /// </summary>
        private void ShowFrmSSSQ()
        {

            object[] communicateValue = new object[7];
            communicateValue[0] = sBinID;
            communicateValue[1] = sWardID;
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            communicateValue[6] = this.patientInfo1.lbID.Text;
            GetForm("Ts_zyys_ssgl", "Fun_Ts_zyys_sssq", "手术申请", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 手术查询
        /// </summary>
        private void ShowFrmSSCX()
        {

            object[] communicateValue = new object[6];
            communicateValue[0] = 0;
            communicateValue[1] = "";
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_ssgl", "Fun_Ts_zyys_sscx", "手术查询", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 会诊管理
        /// </summary>
        /// <param name="selbin">是否选择了病人</param>
        private void ShowFrmHZGL(bool selbin)
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = selbin ? sBinID : Guid.Empty;
            communicateValue[1] = sWardID;
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_hzgl", "Fun_Ts_zyys_hzgl", "会诊管理", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 检验申请
        /// </summary>
        private void ShowFrmJYSQ()
        {
            //#region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
            //string[] rtnSql =Ts_zyys_public.DbQuery.GetBrzt(sBinID);
            //if (rtnSql[0] != "0")
            //{
            //    MessageBox.Show("由于跨院转科或者特殊治疗，该病人记录已经冻结不能允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (rtnSql[1] != FrmMdiMain.Jgbm.ToString())
            //{
            //    MessageBox.Show("该病人不属于本院区，不允许操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //#endregion
            object[] communicateValue = new object[6];
            communicateValue[0] = sBinID;
            communicateValue[1] = sWardID;
            communicateValue[2] = 0;
            communicateValue[3] = this.STAG;
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_jysq", "Fun_Ts_zyys_jysq", "检验申请", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 检查申请
        /// </summary>
        //private void ShowFrmJCSQ()
        //{
        //    //#region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
        //    //string[] rtnSql = Ts_zyys_public.DbQuery.GetBrzt(sBinID);
        //    //if (rtnSql[0] != "0")
        //    //{
        //    //    MessageBox.Show("由于跨院转科或者特殊治疗，该病人记录已经冻结不能允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    return;
        //    //}
        //    //if (rtnSql[1] != FrmMdiMain.Jgbm.ToString())
        //    //{
        //    //    MessageBox.Show("该病人不属于本院区，不允许操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    return;
        //    //}
        //    //#endregion
        //    object[] communicateValue = new object[6];
        //    communicateValue[0] = sBinID;
        //    communicateValue[1] = sWardID;
        //    communicateValue[2] = 0;
        //    communicateValue[3] = this.STAG;
        //    communicateValue[4] = 0;
        //    communicateValue[5] = this.lg;
        //    GetForm("Ts_zyys_jcsq", "Fun_Ts_zyys_jcsq", "检查申请", this._currentUser, this._currentDept, communicateValue, true);
        //}
        /// <summary>
        /// 检查申请（部位）
        /// </summary>
        private void ShowFrmJCSQBW()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = sBinID;
            communicateValue[1] = sWardID;
            communicateValue[2] = 0;
            communicateValue[3] = this.STAG;
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_jcsq", "Fun_Ts_zyys_jcsqbw", "检查申请", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 治疗申请
        /// </summary>
        private void ShowFrmZLSQ()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = sBinID;
            communicateValue[1] = sWardID;
            communicateValue[2] = 0;
            communicateValue[3] = this.STAG;
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_zlsq", "Fun_Ts_zyys_zlsq", "治疗申请", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 特殊治疗
        /// </summary>
        private void ShowFrmTSZL()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = sBinID;
            communicateValue[1] = sWardID;
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_tszl", "Fun_ts_zyys_tszl", "特殊治疗", this._currentUser, this._currentDept, communicateValue, false);
        }
        /// <summary>
        /// 排班管理
        /// </summary>
        private void ShowFrmYSPB()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = 0;
            communicateValue[1] = "";
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_yspb", "Fun_Ts_zyys_yspb", "排班管理", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 科室收入统计
        /// </summary>
        private void ShowFrmKSSRTJ()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = 0;
            communicateValue[1] = myQuery.GetDeptName(this.DeptID);
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_bbtj", "Fun_Ts_zyys_kssrtj", "科室收入统计", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 病人费用(按医生)统计
        /// </summary>
        private void ShowFrmBRFYYSTJ()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = 0;
            communicateValue[1] = myQuery.GetDeptName(this.DeptID);
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_bbtj", "Fun_Ts_zyys_brfyystj", "病人费用统计", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 本病区病人费用统计
        /// </summary>
        private void ShowFrmBRFYTJ()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = 0;
            communicateValue[1] = "";
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_bbtj", "Fun_Ts_zyys_brfytj", "本病区病人费用统计", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 出院病人统计
        /// </summary>
        private void ShowFrmCYBRTJ()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = 0;
            communicateValue[1] = myQuery.GetWardName(this.WardID);
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = this.lg;
            GetForm("Ts_zyys_bbtj", "Fun_Ts_zyys_cybrtj", "出院病人统计", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 项目收入统计
        /// </summary>
        private void ShowFrmXMSRTJ()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = 0;
            communicateValue[1] = "";
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = 0;
            GetForm("Ts_zyys_bbtj", "Fun_Ts_zyys_xmsrtj", "项目收入统计", this._currentUser, this._currentDept, communicateValue, true);
        }
        /// <summary>
        /// 三测单
        /// </summary>
        private void ShowFrmSCD()
        {
            try
            {

                EmrBussinessLogic.Forms.FrmMain.Database = TrasenFrame.Forms.FrmMdiMain.Database;
                //改为调用电子病历的三测单
                EmrNurseWs.FrmScdPrint fsp = new EmrNurseWs.FrmScdPrint(this._currentDept.ToString(), sBinID.ToString(), "0");

                fsp.ShowDialog();
                return;
                object[] communicateValue = new object[6];
                communicateValue[0] = sBinID;
                communicateValue[1] = "";
                communicateValue[2] = 0;
                communicateValue[3] = "";
                communicateValue[4] = 0;
                communicateValue[5] = 0;
                GetForm("Ts_zyys_hlxx", "Fun_Ts_zyys_scd", "三测单", this._currentUser, this._currentDept, communicateValue, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        ///  四测记录
        /// </summary>
        private void ShowFrmSCJL()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = sBinID;
            communicateValue[1] = "";
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = 0;
            GetForm("Ts_zyys_hlxx", "Fun_Ts_zyys_scjl", "四测记录", this._currentUser, this._currentDept, communicateValue, false);
        }
        /// <summary>
        /// 危护记录
        /// </summary>
        private void ShowFrmWHJL()
        {
            object[] communicateValue = new object[6];
            communicateValue[0] = 0;
            communicateValue[1] = sWardID;
            communicateValue[2] = 0;
            communicateValue[3] = "";
            communicateValue[4] = 0;
            communicateValue[5] = 0;
            GetForm("Ts_zyys_hlxx", "Fun_Ts_zyys_whjl", "危重患者护理记录", this._currentUser, this._currentDept, communicateValue, false);
        }
        /// <summary>
        /// 病人信息查询
        /// </summary>
        private void ShowFrmBRXX()
        {
            object[] communicateValue = new object[1];
            communicateValue[0] = sBinID;
            GetForm("Ts_zyys_brxx", "Fun_Ts_zyys_xxcx", "病人信息查询", this._currentUser, this._currentDept, communicateValue, false);
        }
        /// <summary>
        /// 病人费用明细
        /// </summary>
        private void ShowFrmBRFY()
        {
            WorkStaticFun.InstanceForm("Ts_zyys_brxx", "Fun_Ts_zyys_fymx", "病人费用明细", new User(this._currentUser, FrmMdiMain.Database), new Department(this._currentDept, FrmMdiMain.Database), null, FrmMdiMain.Database);
        }
        /// <summary>
        /// 科室药品查询
        /// </summary>
        private void ShowFrmKSYP()
        {
            WorkStaticFun.InstanceForm("Ts_zyys_zhcx", "Fun_Ts_zyys_jsyp", "基数药品查询", new User(this._currentUser, FrmMdiMain.Database), new Department(this._currentDept, FrmMdiMain.Database), null, FrmMdiMain.Database);
        }
        /// <summary>
        /// 历史医嘱查询
        /// </summary>
        private void ShowFrmOldYZ()
        {
            WorkStaticFun.InstanceForm("Ts_zyys_brxx", "Fun_Ts_zyys_yzcx", "历史医嘱查询", new User(this._currentUser, FrmMdiMain.Database), new Department(this._currentDept, FrmMdiMain.Database), null, FrmMdiMain.Database);
        }
        /// <summary>
        /// 药品查询
        /// </summary>
        private void ShowFrmYPCX()
        {
            WorkStaticFun.InstanceForm("Ts_zyys_zhcx", "Fun_Ts_zyys_ypcx", "药品查询", new User(this._currentUser, FrmMdiMain.Database), new Department(this._currentDept, FrmMdiMain.Database), null, FrmMdiMain.Database);
        }
        /// <summary>
        /// 医嘱项目查询
        /// </summary>
        private void ShowFrmXMCX()
        {
            WorkStaticFun.InstanceForm("Ts_zyys_zhcx", "Fun_Ts_zyys_xmcx", "项目查询", new User(this._currentUser, FrmMdiMain.Database), new Department(this._currentDept, FrmMdiMain.Database), null, FrmMdiMain.Database);
        }
        /// <summary>
        /// 医嘱用法查询
        /// </summary>
        private void ShowFrmYFCX()
        {
            WorkStaticFun.InstanceForm("Ts_zyys_zhcx", "Fun_Ts_zyys_yfcx", "用法查询", new User(this._currentUser, FrmMdiMain.Database), new Department(this._currentDept, FrmMdiMain.Database), null, FrmMdiMain.Database);
        }
        #endregion

        #region 设置鼠标
        private void SetCursor(string res)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(GetType());
            System.IO.Stream stream = assembly.GetManifestResourceStream(res);
            this.Cursor = new Cursor(stream);
        }
        private void GetCursor(Cursor cur)
        {
            this.Cursor = cur;
        }
        #endregion

        #region 获取资源中的位图
        private Bitmap GetImage(string res)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(GetType());
            System.IO.Stream stream = assembly.GetManifestResourceStream(res);
            return new Bitmap(stream);
        }
        #endregion

        #region 写标题
        private void Label1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            using (Brush MyBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle((this.Width - 210) / 2, 1, 200, 25), Color.Red, Color.Blue, 10))
            {
                e.Graphics.DrawString("医 生 工 作 站", new System.Drawing.Font("隶书", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))),
                    System.Drawing.Brushes.LavenderBlush, (this.Width - 207) / 2, 0);
                e.Graphics.DrawString("医 生 工 作 站", new System.Drawing.Font("隶书", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))),
                                      MyBrush, (this.Width - 210) / 2, 1);
            }
        }
        #endregion

        #region 窗体大小改变事件
        private void frmMain_Resize(object sender, System.EventArgs e)
        {
            //刷新按钮
            this.bt_RF.Left = this.Width - 135;
            //改变床位顺序按钮
            this.bt_CW.Left = this.Width - 240;
            PostMessage(this.listView1.Handle.ToInt32(), 0x020A, 0, 0);
            PostMessage(this.listView2.Handle.ToInt32(), 0x020A, 0, 0);
        }
        #endregion

        #region 该两个方法是用来显示和隐藏主界面中的说明内容
        /// <summary>
        /// 该两个方法是用来显示和隐藏主界面中的说明内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseEnter(object sender, System.EventArgs e)
        {
            this.panel8.Visible = true;
        }

        private void listView1_MouseLeave(object sender, System.EventArgs e)
        {
            this.panel8.Visible = false;
            this.toolTip1.Hide(this.listView1);
        }
        #endregion

        /// <summary>
        /// 加载病区
        /// </summary>
        private void LoadWard()
        {
            DataTable myTb = new DataTable();
            string sSql = "";

            cmbWard.Items.Clear();
            cmbWard.DataSource = null;

            sSql = "select WARD_ID,WARD_NAME from jc_ward where jgbm=" + FrmMdiMain.Jgbm + " union all select '-1' ward_id,'全部' ward_name order by ward_id";
            myTb = InstanceForm._database.GetDataTable(sSql);

            cmbWard.DisplayMember = "WARD_NAME";
            cmbWard.ValueMember = "WARD_ID";
            cmbWard.DataSource = myTb;

            cmbWard.SelectedValue = "-1";
        }

        /// <summary>
        /// 显示病区动态栏信息
        /// </summary>
        /// <returns></returns>
        private string ShowMsgText()
        {
            //Modify by Tany 2010-02-05 取病区工作日志的信息，保持一致
            DataTable rtnTb = new DataTable();
            string sSql = "";
            ParameterEx[] parameters = new ParameterEx[4];
            DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm._database);

            try
            {
                sSql = "SP_ZYHS_WARDGZRZ";

                parameters[0].Value = InstanceForm._currentDept.WardId;
                parameters[0].Text = "@WARD_ID";
                parameters[1].Value = now.ToString("yyyy-MM-dd 00:00:00");
                parameters[1].Text = "@BDATE";
                parameters[2].Value = now.ToString("yyyy-MM-dd 23:59:59"); ;
                parameters[2].Text = "@EDATE";
                parameters[3].Value = 0;
                parameters[3].Text = "@FLAG";

                rtnTb = InstanceForm._database.GetDataTable(sSql, parameters, 60);

                string rs = "";
                if (rtnTb.Rows.Count > 0)
                {
                    int zy = 0;
                    int cy = 0;
                    int sw = 0;
                    int ss = 0;
                    int bw = 0;
                    int bz = 0;
                    int th = 0;
                    int yjhl = 0;
                    //add by yaokx 2014-05-13 总在床人数，总在院人数
                    int lgrs = 0;
                    int zyrs = 0;
                    int cqrs = 0;
                    for (int i = 0; i < rtnTb.Rows.Count; i++)
                    {
                        zy += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["现有"], "0"));
                        cy += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["出院合计"], "0"));
                        sw += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["死亡"], "0"));
                        ss += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["手术"], "0"));
                        bw += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["病危"], "0"));
                        bz += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["病重"], "0"));
                        th += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["特护"], "0"));
                        yjhl += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["一级护理"], "0"));
                        lgrs += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["留观人数"], "0"));
                        zyrs += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["在院床位人数"], "0"));
                        cqrs += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["出区人数"], "0"));
                    }
                    rs = "当前在院人数：" + zy + "（注：入区人数+在床人数）\r\n";
                    rs += "今日出院人数：" + cy + "（其中死亡：" + sw + "）\r\n";
                    rs += "今日手术人数：" + ss + "\r\n";
                    rs += "病危人数：" + bw + "\r\n";
                    rs += "病重人数：" + bz + "\r\n";
                    rs += "特级护理人数：" + th + "\r\n";
                    rs += "一级护理人数：" + yjhl + "\r\n";
                    rs += "总在床人数：" + (lgrs + zyrs) + "（注：住院在床人数:" + zyrs + ";留观占床人数:" + lgrs + "）\r\n";
                    rs += "总在院人数：" + (lgrs + zyrs + cqrs) + "（注：在床人数:" + (lgrs + zyrs) + "+出区人数:" + cqrs + "）\r\n";
                }

                return rs;
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "程序错误", "SP_ZYHS_WARDGZRZ错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "主机名：" + System.Environment.MachineName, 7);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return "";
            }
        }

        private void 特殊治疗完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView4.FocusedItem == null || listView4.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }

            if (MessageBox.Show("是否确认该申请已完成？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            try
            {

                //生成操作日志 Modify by Zouchihua 2011-10-10 三院方案
                #region
                DataTable tb = InstanceForm._database.GetDataTable("select * from ZY_TS_APPLY where id='" + listView4.SelectedItems[0].SubItems[8].Text + "'");
                string br_dept = "-1";
                string inpatient_id = Guid.Empty.ToString();
                Guid guid = Guid.Empty;
                if (tb != null && tb.Rows.Count > 0)
                    br_dept = tb.Rows[0]["DEPT_br"].ToString();
                inpatient_id = tb.Rows[0]["inpatient_id"].ToString();
                string[] rtnSql = Ts_zyys_public.DbQuery.GetBrzt(new Guid(inpatient_id));
                if (rtnSql[1] != FrmMdiMain.Jgbm.ToString())//跨院判断
                {
                    #region //判断费用是否记账，医嘱是否执行
                    string sql = "select * from ZY_FEE_SPECI where CHARGE_BIT=0 and  INPATIENT_ID='" + inpatient_id + "' and DELETE_BIT=0";
                    DataTable temp = FrmMdiMain.Database.GetDataTable(sql);
                    if (temp.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "对不起，该病人有未记账的医嘱 ，不允许完成！", "跨院特殊治疗错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sql = "select * from ZY_ORDERRECORD where INPATIENT_ID='" + inpatient_id + "' and STATUS_FLAG!=5 and delete_bit=0";
                    temp = FrmMdiMain.Database.GetDataTable(sql);
                    if (temp.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "对不起，该病人有未执行的医嘱 ，不允许完成！", "跨院特殊治疗错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    #endregion
                    //药房是否发药判断
                    string sSql = "select id from ZY_FEE_SPECI where FY_BIT=0 and XMLY=1 " + " and inpatient_id='" + inpatient_id + "' and DELETE_BIT=0";
                    temp = FrmMdiMain.Database.GetDataTable(sSql);
                    if (temp.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "对不起，该病人有未领取的药品，不允许完成！", "跨院特殊治疗错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //医技是否完成 select * from YJ_ZYSQ where BJSBZ=0
                    sSql = "select yjsqid from YJ_ZYSQ where BJSBZ=0  " + " and inpatient_id='" + inpatient_id + "' and BSCBZ=0";
                    temp = FrmMdiMain.Database.GetDataTable(sSql);
                    if (temp.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "对不起，该病人有未确认的医技项目 ，不允许完成！", "跨院特殊治疗错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try
                    {
                        ts_HospData_Share.ts_update_log ts_share = new ts_HospData_Share.ts_update_log();
                        // ts_share.Save_log(ts_HospData_Share.czlx.zy_特殊治疗完成, "特殊治疗完成【复制病人相关数据】", "ZY_TS_APPLY", "id", listView4.SelectedItems[0].SubItems[8].Text, FrmMdiMain.Jgbm, int.Parse(br_dept == "" ? "-1" : br_dept), "", out guid, FrmMdiMain.Database);
                        //冻结本地数据 永久
                        string ss = "update zy_inpatient set FREEZE_FLAG=2 where inpatient_id='" + tb.Rows[0]["inpatient_id"].ToString() + "'";
                        InstanceForm._database.DoCommand(ss);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    //如果不是跨院区。要判断本科室的医嘱是否
                    #region //判断费用是否记账，医嘱是否执行
                    string sql = "select * from ZY_FEE_SPECI where CHARGE_BIT=0 and  INPATIENT_ID='" + inpatient_id + "' and DELETE_BIT=0 and dept_id=" + InstanceForm._currentDept.DeptId;
                    DataTable temp = FrmMdiMain.Database.GetDataTable(sql);
                    if (temp.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "对不起，该病人有未记账的医嘱 ，不允许完成！", "跨院特殊治疗错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sql = "select * from ZY_ORDERRECORD where INPATIENT_ID='" + inpatient_id + "' and STATUS_FLAG!=5 and delete_bit=0 and dept_id=" + InstanceForm._currentDept.DeptId;
                    temp = FrmMdiMain.Database.GetDataTable(sql);
                    if (temp.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "对不起，该病人有未执行的医嘱 ，不允许完成！", "跨院特殊治疗错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    #endregion
                }
                InstanceForm._database.DoCommand("update ZY_TS_APPLY set status_flag=2 where id='" + listView4.SelectedItems[0].SubItems[8].Text + "'");

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tabControl1_SelectedIndexChanged(null, null);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView4.FocusedItem == null || listView4.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Guid inpatientId = new Guid(listView4.SelectedItems[0].SubItems[0].Text);

                object[] communicateValue = new object[3];

                //这个是废参数，无所谓
                communicateValue[0] = "";
                communicateValue[1] = 0;
                //病人ID
                communicateValue[2] = inpatientId;

                WorkStaticFun.InstanceFormEx("ts_zyhs_yzgl", "Fun_ts_zyhs_yzgl_inpatient", "医嘱查询", InstanceForm._currentUser, InstanceForm._currentDept, new MenuTag(), -1, this.MdiParent, FrmMdiMain.Database, ref communicateValue);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 刷新全部未完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView4.Items.Clear();
            string sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,'('+isnull((select top 1 BED_NO from ZY_BEDDICTION where BED_ID=b.BED_ID),'') +')'+(case when A.BABY_ID=0 then B.NAME else C.BABYNAME end) BinName," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG, " +
                        "       (select top 1 BED_NO from ZY_BEDDICTION where BED_ID=c.BED_ID) bed_no  , " +
                        "       CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.DEPT_ID AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                        "from (select * from ZY_TS_APPLY where TS_DEPT=" + DeptID.ToString() + " and (ward_id='" + cmbWard.SelectedValue.ToString() + "' or '" + cmbWard.SelectedValue.ToString() + "'='-1') and status_flag=1 and delete_bit=0) A " +
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID and b.flag <>10 " +
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "order by apply_date";
            TSTb = FrmMdiMain.Database.GetDataTable(sSql);
            if (TSTb.Rows.Count == 0) return;
            ListViewItem LItem = null;
            for (int i = 0; i < TSTb.Rows.Count; i++)
            {
                LItem = new ListViewItem(new string[]{TSTb.Rows[i]["INPATIENT_ID"].ToString(),
													   TSTb.Rows[i]["INPATIENT_NO"].ToString(),
													   TSTb.Rows[i]["BinName"].ToString(),
													   TSTb.Rows[i]["WARD_ID"].ToString(),
													   TSTb.Rows[i]["DeptName"].ToString(),
													   (Convert.ToDateTime(TSTb.Rows[i]["APPLY_DATE"])).ToString("yyyy-MM-dd HH:mm:ss"),
													   TSTb.Rows[i]["doc_name"].ToString(),
													   TSTb.Rows[i]["content"].ToString(),
                                                       TSTb.Rows[i]["id"].ToString()});

                this.listView4.Items.Add(LItem).Tag = TSTb.Rows[i]["STAG"].ToString();
            }
        }

        private void 查询全部已完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView4.Items.Clear();
            string sSql = "Select A.ID,A.INPATIENT_ID,B.INPATIENT_NO,'('+isnull((select top 1 BED_NO from ZY_BEDDICTION where BED_ID=b.BED_ID),'') +')'+(case when A.BABY_ID=0 then B.NAME else C.BABYNAME end) BinName," +
                        "       A.WARD_ID,D.NAME DeptName,A.DEPT_ID,A.APPLY_DOC,dbo.FUN_ZY_SEEKEMPLOYEENAME(A.APPLY_DOC) doc_name," +
                        "       A.APPLY_DATE,A.CONTENT,A.TS_DEPT,A.SH_USER,A.SH_DATE,A.BOOK_DATE,A.STATUS_FLAG, " +
                        "       (select top 1 BED_NO from ZY_BEDDICTION where BED_ID=c.BED_ID) bed_no  , " +
                        "       CAST(A.INPATIENT_ID AS CHAR(40)) + CAST(A.BABY_id AS CHAR(10)) + CAST(0 AS CHAR(10)) + CAST(A.DEPT_ID AS CHAR(10)) + CAST(A.WARD_ID AS CHAR(10)) AS STAG " +
                        "from (select * from ZY_TS_APPLY where TS_DEPT=" + DeptID.ToString() + " and (ward_id='" + cmbWard.SelectedValue.ToString() + "' or '" + cmbWard.SelectedValue.ToString() + "'='-1') and status_flag=2 and delete_bit=0) A " +
                        "     inner join  " +
                        "     VI_ZY_VINPATIENT B on A.INPATIENT_ID=B.INPATIENT_ID and b.flag<>10 " +//Modify By Tany 2010-03-26 加入在院的判断
                        "     left join " +
                        "     ZY_INPATIENT_BABY C on A.BABY_ID=C.BABY_ID " +
                        "     left join " +
                        "     JC_DEPT_PROPERTY D on A.DEPT_BR=D.DEPT_ID " +
                        "order by apply_date";
            TSTb = FrmMdiMain.Database.GetDataTable(sSql);
            if (TSTb.Rows.Count == 0) return;
            ListViewItem LItem = null;
            for (int i = 0; i < TSTb.Rows.Count; i++)
            {
                LItem = new ListViewItem(new string[]{TSTb.Rows[i]["INPATIENT_ID"].ToString(),
													   TSTb.Rows[i]["INPATIENT_NO"].ToString(),
													   TSTb.Rows[i]["BinName"].ToString(),
													   TSTb.Rows[i]["WARD_ID"].ToString(),
													   TSTb.Rows[i]["DeptName"].ToString(),
													   (Convert.ToDateTime(TSTb.Rows[i]["APPLY_DATE"])).ToString("yyyy-MM-dd HH:mm:ss"),
													   TSTb.Rows[i]["doc_name"].ToString(),
													   TSTb.Rows[i]["content"].ToString(),
                                                       TSTb.Rows[i]["id"].ToString()});

                this.listView4.Items.Add(LItem).Tag = TSTb.Rows[i]["STAG"].ToString();
            }
        }

        private void miPatPacs_Click(object sender, EventArgs e)
        {
            toolTip1.Hide(listView2);

            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (isWard == false)
            {
                MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = PubStaticFun.WaitCursor();

            try
            {
                if (ApiFunction.GetIniString("PACS", "是否启用", Constant.ApplicationDirectory + "\\pacs.ini").Trim() != "1")
                {
                    MessageBox.Show("对不起，暂未启用PACS接口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string pacsName = ApiFunction.GetIniString("PACS", "PACS类型", Constant.ApplicationDirectory + "\\pacs.ini");
                ts_pacs_interface.Ipacs pacs = ts_pacs_interface.PacsFactory.Pacs(pacsName);

                TszyHIS.Inpatient ipt = new TszyHIS.Inpatient(sBinID);

                pacs.ShowPatPacsInfo(ipt.PatientID, ts_pacs_interface.PatientSource.住院);

                //GetPacsInfo(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到有效的记录，请重新查证！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void listView2_MouseLeave(object sender, EventArgs e)
        {
            this.toolTip1.Hide(this.listView2);
        }

        private void outlookBar1_Click(object sender, EventArgs e)
        {

        }

        private void 分娩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView4.FocusedItem == null || listView4.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Guid inpatientId = new Guid(listView4.SelectedItems[0].SubItems[0].Text);
            DataTable tb = FrmMdiMain.Database.GetDataTable("select  SEX_NAME from VI_ZY_VINPATIENT_BED  where inpatient_id='" + inpatientId + "'");
            if (tb == null || tb.Rows.Count == 0)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb.Rows[0]["SEX_NAME"].ToString().Trim() != "女")
            {
                MessageBox.Show(this, "对不起，您选择的病人必须是女性！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClassStatic.Current_BinID = inpatientId;
            frmFM frmFm = new frmFM(1);
            frmFm.ShowDialog();
            frmFm.Dispose();

        }

        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            if (cfg6050.Config.Trim() == "1" && tabControl1.SelectedTab.Text == "管辖内病人" && this.listView1.Height != 0)
            {
                if (this.MdiParent.ActiveMdiChild == this)
                {
                    //InitView(YS_ID);
                    //this.bt_CW.Visible = false;
                    //listView2.Items.Clear();
                    //listView3.Items.Clear();
                    //listView4.Items.Clear();
                }
            }
        }

        private void listView2_SizeChanged(object sender, EventArgs e)
        {
            if (cfg6050.Config.Trim() == "1" && tabControl1.SelectedTab.Text == "本科所有病人" && this.listView2.Height != 0)
            {
                if (this.MdiParent.ActiveMdiChild == this)
                {
                    //if (this.bt_CW.Text == "按床位") InitView(WardID, 1);
                    //else InitView(WardID, 0);
                    ////add by zouchihua 2012-2-27
                    ////AddJsd(this.listView2);
                    //this.bt_CW.Enabled = true;
                    //this.bt_CW.Visible = true;
                    //listView1.Items.Clear();
                    //listView3.Items.Clear();

                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Jsq += 1;
            timer += 1;
        }
        /// <summary>
        /// 判断listview图片
        /// </summary>
        /// <param name="listview"></param>
        private void BindListview(ListView listview)
        {
            if (cfg6050.Config.Trim() == "0")
                return;
            int i = 0;
            Sfzy();
            thr = null;
            GC.Collect();
            Ts_zyys_public.PulicStatiFuntion.GCCollect();
            Ts_zyys_public.PulicStatiFuntion.ClearMemory();
            thr = new Thread[listview.Items.Count];
            int flag = 0;
            for (i = 0; i < listview.Items.Count; i++)
            {
                flag = 0;
                STAG = Convert.ToString(listview.Items[i].Tag);
                if ((STAG.Trim() != "") && (STAG != null))
                {
                    for (int j = 0; j < wjzTb.Rows.Count; j++)
                    {
                        if (STAG.Substring(0, 40).Trim().ToUpper() == wjzTb.Rows[j]["inpatient_id"].ToString().Trim().ToUpper()
                            )
                        {
                            thr[i] = new Thread(new ParameterizedThreadStart(tt));
                            int[] cs = new int[] { 0, i };
                            thr[i].Start((object)cs);
                            gb[i].MouseEnter -= new EventHandler(frmMain_MouseEnter);
                            gb[i].MouseEnter += new EventHandler(frmMain_MouseEnter);
                            gb[i].MouseDoubleClick -= new MouseEventHandler(frmMain_MouseDoubleClick);
                            gb[i].MouseDoubleClick += new MouseEventHandler(frmMain_MouseDoubleClick);
                            flag = 1;
                            break;
                        }
                    }
                    //是否存在其它消息 add by zouchihua 2013-8-13
                    if (flag == 0)
                    {
                        if (Yjtb.Rows.Count > 0)
                        {
                            DataRow[] row = Yjtb.Select("INPATIENT_ID='" + STAG.Substring(0, 40).Trim().ToUpper() + "'");
                            if (row.Length > 0)
                            {
                                thr[i] = new Thread(new ParameterizedThreadStart(tt));
                                int[] cs = new int[] { 0, i };
                                thr[i].Start((object)cs);
                                gb[i].MouseEnter -= new EventHandler(frmMain_MouseEnter);
                                gb[i].MouseEnter += new EventHandler(frmMain_MouseEnter);
                                gb[i].MouseLeave -= new EventHandler(frmMain_MouseLeave);
                                gb[i].MouseLeave += new EventHandler(frmMain_MouseLeave);
                                gb[i].MouseDoubleClick -= new MouseEventHandler(frmMain_MouseDoubleClick);
                                gb[i].MouseDoubleClick += new MouseEventHandler(frmMain_MouseDoubleClick);
                                gb[i].Tag = "jytb|" + gb[i].Tag.ToString();//如果有jytb|开头就表示是医技那边发来的消息
                                flag = 1;
                            }
                        }
                    }
                }
                if (flag == 0)
                {
                    gb[i].MouseEnter -= new EventHandler(frmMain_MouseEnter);
                    gb[i].Image = ImageTsd.Images[5];
                }
            }
        }

        void frmMain_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            t.Hide(pb);
        }
        Ts_zyys_public.FrmMessageShow fmshow;
        void frmMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                PictureBox pbox = (sender as PictureBox);
                if (pbox != null && pbox.Tag.ToString().IndexOf("jytb|") >= 0)
                {
                    string inpatid = (sender as PictureBox).Tag.ToString().Replace("jytb|", "");
                    DataRow[] row = Yjtb.Select("inpatient_id='" + inpatid + "'");
                    string xx = "";

                    if (fmshow == null)
                    {
                        fmshow = new FrmMessageShow();
                        for (int i = 0; i < row.Length; i++)
                        {
                            int start = 0;
                            try
                            {
                                start = fmshow.richTextBox1.Text.Length;

                                xx = "发送时间：" + row[i]["maseegetime"].ToString().Trim() + "  发送人：" + row[i]["fsr"].ToString().Trim() + " 发送科室：" + row[i]["发送科室"].ToString().Trim() + " 检查项目：" + row[i]["SQNR"].ToString().Trim();
                                fmshow.richTextBox1.Text = fmshow.richTextBox1.Text + xx;
                                fmshow.richTextBox1.Select(start, xx.Length);
                                fmshow.richTextBox1.SelectionColor = Color.Blue;
                                // fmshow.richTextBox1.Font.Bold = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + "ss");
                            }


                            try
                            {
                                start = fmshow.richTextBox1.Text.Length;
                                xx = "\r\n【内容】：\r\n   " + row[i]["massegeinfo"].ToString().Trim() + "\r\n";
                                fmshow.richTextBox1.Text = fmshow.richTextBox1.Text + xx;
                                fmshow.richTextBox1.Select(start, xx.Length);
                                fmshow.richTextBox1.SelectionColor = Color.DarkRed;
                                fmshow.richTextBox1.SelectionStart = fmshow.richTextBox1.Text.Length;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + "dd");
                            }
                            break;

                        }
                        fmshow.ShowDialog();
                        if (fmshow.DialogResult == DialogResult.OK)
                        {
                            for (int i = 0; i < row.Length; i++)
                            {
                                string sql = " update JY_MASSEGE set MASSEGESTATE=2,CKMASSEGEDOCTOR='" + InstanceForm._currentUser.EmployeeId.ToString() + "', CKMASEEGETIME='" + DateManager.ServerDateTimeByDBType(FrmMdiMain.Database) + "' where MASSEGEID='" + row[i]["MASSEGEID"] + "'";
                                InstanceForm._database.DoCommand(sql);
                                break;
                            }
                            //add by zouchihua 2013-8-13获得其它医技的危机值或者提示
                            string sql1 = "select *,dbo.fun_getEmpName(MASSEGEDOCTOR) fsr,dbo.fun_getDeptname(ZXKS) 发送科室  from JY_MASSEGE a join YJ_ZYSQ b on a.yjsqid=b.YJSQID where a.MASSEGESTATE=1  and b.SQKS=" + InstanceForm._currentDept.DeptId;//标题没有查看的
                            Yjtb = InstanceForm._database.GetDataTable(sql1);
                            tabControl1_SelectedIndexChanged(null, null);//刷新
                        }
                        fmshow.Dispose();
                        fmshow = null;

                    }
                }
                else
                {
                    DataTable tb = FrmMdiMain.Database.GetDataTable("select inpatient_no from zy_inpatient where inpatient_id='" + (sender as PictureBox).Tag.ToString() + "'");
                    if (tb.Rows.Count > 0)
                    {
                        ts_lis_mzzyQuery.InstanceForm.BCurrentUser = frmMain.Current_User;
                        ts_lis_mzzyQuery.InstanceForm.BCurrentDept = frmMain.Current_Dept;
                        ts_lis_mzzyQuery.InstanceForm.BDatabase = FrmMdiMain.Database;
                        ts_lis_mzzyQuery.Frm_Query t = new ts_lis_mzzyQuery.Frm_Query(frmMain.Current_User.UserID, frmMain.Current_Dept.DeptId, "检验报告查询");
                        t.GetWeiJiInfo(tb.Rows[0]["inpatient_no"].ToString());
                        //t.Show();
                    }
                    else
                    {
                        MessageBox.Show("没有找到对应的病人信息！！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void frmMain_MouseDoubleClick1(object sender, MouseEventArgs e)
        {

        }
        private void setcallback(ListView listview)
        {
            if (listview.InvokeRequired)
            {
                Callback cb = new Callback(setcallback);
                this.Invoke(cb, listview);
            }
            else
            {
                BindListview(listview);
            }
        }
        ToolTip t;
        void frmMain_MouseEnter(object sender, EventArgs e)
        {
            t = new ToolTip();
            if (tabControl1.SelectedTab.Text == "本科所有病人")
            {
                PictureBox pbox = (sender as PictureBox);
                if (pbox != null && pbox.Tag.ToString().IndexOf("jytb|") >= 0)
                {
                    string inpatid = (sender as PictureBox).Tag.ToString().Replace("jytb|", "");
                    DataRow[] row = Yjtb.Select("inpatient_id='" + inpatid + "'");
                    string xx = "";
                    for (int i = 0; i < row.Length; i++)
                    {
                        xx += "发送时间：" + row[i]["maseegetime"].ToString().Trim() + " 内容 ：\r\n" + row[i]["massegeinfo"].ToString().Trim() + "\r\n";
                    }
                    t.Show(xx, this.listView2, (sender as PictureBox).Location.X + (sender as PictureBox).Height, (sender as PictureBox).Location.Y + 20, 5000);
                }
                else
                    t.Show("双击查看危急值或者异常结果！！", this.listView2, (sender as PictureBox).Location.X + (sender as PictureBox).Height, (sender as PictureBox).Location.Y + 20, 1000);
            }
            if (tabControl1.SelectedTab.Text == "管辖内病人")
            {
                PictureBox pbox = (sender as PictureBox);
                if (pbox != null && pbox.Tag.ToString().IndexOf("jytb|") >= 0)
                {
                    string inpatid = (sender as PictureBox).Tag.ToString().Replace("jytb|", "");
                    DataRow[] row = Yjtb.Select("inpatient_id='" + inpatid + "'");
                    string xx = "";
                    for (int i = 0; i < row.Length; i++)
                    {
                        xx += "发送时间：" + row[i]["maseegetime"].ToString().Trim() + " 内容 ：\r\n" + row[i]["massegeinfo"].ToString().Trim() + "\r\n";
                    }
                    t.Show(xx, this.listView1, (sender as PictureBox).Location.X + (sender as PictureBox).Height, (sender as PictureBox).Location.Y + 20, 1000);
                }
                else
                    t.Show("双击查看危急值或者异常结果！！", this.listView1, (sender as PictureBox).Location.X + (sender as PictureBox).Height, (sender as PictureBox).Location.Y + 20, 5000);
            }
        }
        void frmMain_MouseEnter1(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            if (tabControl1.SelectedTab.Text == "本科所有病人")
                t.Show(((sender as PictureBox).Name.IndexOf("单病种") >= 0 ? "该病人进入单病种管理" : "该病人进入临床路径！！"), this.listView2, (sender as PictureBox).Location.X + (sender as PictureBox).Height, (sender as PictureBox).Location.Y + 20, 1000);
            if (tabControl1.SelectedTab.Text == "管辖内病人")
                t.Show(((sender as PictureBox).Name.IndexOf("单病种") >= 0 ? "该病人进入单病种管理" : "该病人进入临床路径！！"), this.listView1, (sender as PictureBox).Location.X + (sender as PictureBox).Height, (sender as PictureBox).Location.Y + 20, 1000);
            if (tabControl1.SelectedTab.Text == "本组病人")
                t.Show(((sender as PictureBox).Name.IndexOf("单病种") >= 0 ? "该病人进入单病种管理" : "该病人进入临床路径！！"), this.myListview1, (sender as PictureBox).Location.X + (sender as PictureBox).Height, (sender as PictureBox).Location.Y + 20, 1000);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sfzy();
            thr = null;

            //modify by jchl 2016-07-13
            CloseHlyy();

            //if (LisThr != null && LisThr.ThreadState== System.Threading.ThreadState.Running)
            try
            {
                LisThr.Abort();

            }
            catch
            {

            }
            try
            {
                thrWwcxm.Abort();
            }
            catch { }
            GC.Collect();
            Ts_zyys_public.PulicStatiFuntion.GCCollect();
            Ts_zyys_public.PulicStatiFuntion.ClearMemory();
        }

        private void checkCpIN_CheckedChanged(object sender, EventArgs e)
        {
            ////if ((sender as CheckBox).Name == "checkCpIN" && (sender as CheckBox).Checked)
            ////    this.checkDbz.Checked = false;
            ////else
            ////    this.checkCpIN.Checked = false;

            tabControl1_SelectedIndexChanged(null, null);
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
            //引入临床路径
            myQuery.GetIntoPathway(sBinID.ToString(), "0", 0);//单病种 为 1 ，默认 为0
            tabControl1_SelectedIndexChanged(null, null);//刷新
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    decimal fyxz = Convert.ToDecimal(Convertor.IsNull(this.patientInfo1.myRow["fyxz"], "0"));
                    if (fyxz > 0 && Convert.ToDecimal(this.patientInfo1.myRow["WJSZFY"]) > fyxz)
                        MessageBox.Show(this, this.patientInfo1.lbBed.Text + "床病人“" + this.patientInfo1.lbName.Text + "”费用限制为：" + fyxz.ToString("0.00") + "元，发生费用为：" + Convert.ToDecimal(this.patientInfo1.myRow["WJSZFY"]).ToString("0.00") + "元，已经超标，请注意！\n 请联系管理员", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void menuItem7_Popup(object sender, EventArgs e)
        {

        }

        private void menuItem4_Popup(object sender, EventArgs e)
        {
            this.toolTip1.Hide(this);
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
            //引入临床路径
            myQuery.GetIntoPathway(sBinID.ToString(), "0", 1);//单病种 为 1 ，默认 为0
            tabControl1_SelectedIndexChanged(null, null);//刷新
        }

        private void checkCpIN_Click(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Name == "checkCpIN")
                this.checkDbz.Checked = false;
            if ((sender as CheckBox).Name == "checkDbz")
                this.checkCpIN.Checked = false;
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string inpatient_id = TszyHIS.Inpatient.GetInpatientID().ToString();
            for (int i = 0; i < this.listView4.Items.Count; i++)
            {
                if (this.listView4.Items[i].SubItems[0].Text == inpatient_id)
                {
                    this.listView4.Items[i].Selected = true;
                    return;
                }
            }
            MessageBox.Show("没有找到相应的病人！请重新查询");
        }

        private void menuItem11_Click(object sender, EventArgs e)
        {

            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (sBinID == Guid.Empty)
            {
                MessageBox.Show("空床！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (isWard == false)
            {
                MessageBox.Show("不是你所属科室的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //this.Cursor = PubStaticFun.WaitCursor();
            try
            {
                //ts_his_aqyjwb.AQYJMain aqyjfrm = new AQYJMain(sBinID.ToString(), "0");
                //aqyjfrm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            if (this.listView1.FocusedItem == null & listView2.FocusedItem == null && this.myListview1.FocusedItem == null)
            {
                MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            try
            {
                //msg += "床        号：" + patientInfo1.lbBed.Text + "\n";
                //msg += "姓        名：" + patientInfo1.lbName.Text + "\n";
                //msg += "性        别：" + patientInfo1.lbSex.Text + "\n";
                //msg += "年        龄：" + patientInfo1.lbAge.Text + "\n";
                //msg += "费用类别：" + patientInfo1.lbJSLX.Text + "\n";
                //msg += "住  院  号：" + patientInfo1.lbID.Text + "\n";
                string birthday = Convert.ToString(InstanceForm._database.GetDataResult("select CONVERT(varchar,birthday,23) from VI_ZY_VINPATIENT where inpatient_id='" + sBinID.ToString() + "'"));
                string fwddz = ApiFunction.GetIniString("Emrset", "服务端地址", Constant.ApplicationDirectory + "//Emrset.ini");
                string emrzxwj = ApiFunction.GetIniString("Emrset", "电子病例执行文件地址", Constant.ApplicationDirectory + "//Emrset.ini");
                string emrzxwj_new = "";
                //增加多个判断 
                if (!System.IO.File.Exists(emrzxwj))
                {
                    for (int i = 1; i < 5; i++)
                    {
                        try
                        {
                            emrzxwj_new = ApiFunction.GetIniString("Emrset", "电子病例执行文件地址" + i.ToString(), Constant.ApplicationDirectory + "//Emrset.ini");
                            if (emrzxwj_new.Trim() != "" && System.IO.File.Exists(emrzxwj_new))
                            {
                                emrzxwj = emrzxwj_new;
                                break;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                string startpath = emrzxwj;
                string csstr = "";
                csstr += fwddz + " " + frmMain.Current_User.LoginCode.ToString() + " " + HisEnCode.HisEnCode.EnCode(frmMain.Current_User.LoginCode.ToString()) + " HOSPITAL " + sBinID.ToString() + " ";
                string blcs = "Name:" + patientInfo1.lbName.Text + "|Sex:" + patientInfo1.lbSex.Text + "|Birthday:" + birthday + "|Age:" + patientInfo1.lbAge.Text + "|HIS内部标识:" + sBinID.ToString() + "";
                csstr = csstr + " " + blcs;

                //Modify  by jchl 武汉中心医院  2017-06-02
                //csstr = fwddz + " " + frmMain.Current_User.LoginCode.ToString() + " null " + Convert.ToInt64(patientInfo1.lbID.Text).ToString() + " null true";

                if (string.IsNullOrEmpty(patientInfo1.lbID.Text))
                {
                    MessageBox.Show("请选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }

                csstr = frmMain.Current_User.LoginCode.ToString() + " null " + Convert.ToInt64(patientInfo1.lbID.Text).ToString() + " null true";

                Process.Start(startpath, csstr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void myListview1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.myListview1.SelectedItems.Count == 0)
                {
                    toolTip1.Hide(myListview1);
                    return;
                }
                if (this.myListview1.FocusedItem.Text == "")
                {
                    toolTip1.Hide(myListview1);
                    return;
                }

                if (this.myListview1.FocusedItem.Tag.ToString().Trim() != "")
                {
                    STAG = Convert.ToString(this.myListview1.FocusedItem.Tag);
                    if ((STAG.Trim() != "") && (STAG != null))
                    {
                        this.patientInfo1.SetInpatientInfo(new Guid(STAG.Substring(0, 40).Trim()), Convert.ToInt64(STAG.Substring(40, 10).Trim()), Convert.ToInt16(STAG.Substring(50, 10).Trim()));

                        //Add By Tany 2010-08-29
                        DataRow dr = patientInfo1.myRow;
                        if (dr != null)
                        {
                            string msg = "";
                            msg += "床        号：" + patientInfo1.lbBed.Text + "\n";
                            msg += "姓        名：" + patientInfo1.lbName.Text + "\n";
                            msg += "性        别：" + patientInfo1.lbSex.Text + "\n";
                            msg += "年        龄：" + patientInfo1.lbAge.Text + "\n";
                            msg += "费用类别：" + patientInfo1.lbJSLX.Text + "\n";
                            msg += "住  院  号：" + patientInfo1.lbID.Text + "\n";
                            msg += "病  人  ID：" + Convertor.IsNull(dr["inpatient_bano"], "") + "\n"; //Add By tany 2015-04-23 增加病人ID显示
                            //病情
                            string s_bq = "";
                            if (dr["order_bw"].ToString() != "0" && dr["order_bw"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                                s_bq = s_bq + "*" + "病危";
                            if (dr["order_bz"].ToString() != "0" && dr["order_bz"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                                s_bq = s_bq + "△" + "病重";
                            msg += "病        情：" + s_bq + "\n";
                            msg += "护理级别：" + (dr["HLJB_NAME"].ToString().Trim().Length > 4 ? dr["HLJB_NAME"].ToString().Trim().Substring(0, 4) : dr["HLJB_NAME"].ToString().Trim()) + "\n";
                            msg += "入院诊断：" + patientInfo1.lbRYZD.Text + "\n";
                            msg += "入院日期：" + patientInfo1.lbIn_Date.Text + "\n";
                            msg += "费用总额：" + patientInfo1.lbFYZE.Text + "\n";
                            msg += "未结算额：" + patientInfo1.lbWJSFY.Text + "\n";
                            msg += "预  收  款：" + patientInfo1.lbYJK.Text + "\n";
                            msg += "欠费限额：" + Convert.ToDecimal(dr["yjj_limit"]).ToString("0.00") + "\n";//Add By tany 2010-11-27
                            msg += "余        额：" + patientInfo1.lbYE.Text + "\n";
                            msg += "提        示：" + patientInfo1.lbTs.Text + "\n";
                            if (Convert.ToDecimal(Convertor.IsNull(dr["fyxz"], "0")) > 0)
                            {
                                msg += "费用限制：" + Convert.ToDecimal(dr["fyxz"]).ToString("0.00") + "\n";
                            }
                            if (Convertor.IsNull(dr["ybjs_date"], "") != "")
                            {
                                msg += "计算时间：" + Convert.ToDateTime(dr["ybjs_date"]).ToString("yyyy-MM-dd HH:mm:ss") + "\n";
                                msg += "医保总额：" + Convert.ToDecimal(dr["ybzfy"]).ToString("0.00") + "\n";
                                msg += "统筹支付：" + Convert.ToDecimal(dr["tczf"]).ToString("0.00") + "\n";
                                msg += "账户支付：" + Convert.ToDecimal(dr["zhzf"]).ToString("0.00") + "\n";
                                msg += "其他支付：" + Convert.ToDecimal(dr["qtzf"]).ToString("0.00") + "\n";
                                msg += "现金支付：" + Convert.ToDecimal(dr["xjzf"]).ToString("0.00") + "\n";
                                msg += "医保余额：" + Convert.ToDecimal(Convert.ToDecimal(dr["yjk"]) - Convert.ToDecimal(dr["xjzf"])).ToString("0.00") + "\n";
                            }
                            string ryshbz = Convertor.IsNull(dr["rysh_bz"], "");
                            if (ryshbz != "")
                            {
                                msg += "入院备注：" + ryshbz + "\n";
                            }
                            //Add By Tany 2011-01-05
                            msg += "描        述：" + dr["SICKDESCRIPTION"].ToString().Trim() + "\n";
                            toolTip1.Show(msg, myListview1, this.myListview1.SelectedItems[0].Position.X + 50, this.myListview1.SelectedItems[0].Position.Y + 40, 60000);
                        }
                        else
                        {
                            toolTip1.Hide(myListview1);
                        }
                    }
                    else
                    {
                        this.patientInfo1.ClearInpatientInfo();

                        toolTip1.Hide(myListview1);
                    }
                    sBinID = new Guid(this.myListview1.FocusedItem.Tag.ToString().Substring(0, 40));
                    DeptBR = Convert.ToInt32(this.myListview1.FocusedItem.Tag.ToString().Substring(60, 10));
                    sWardID = this.myListview1.FocusedItem.Tag.ToString().Substring(70, 4);
                    sWard_dept = this.Ward_dept;
                    if (myQuery.OutFlag(sBinID) || myQuery.TurnFlag(this.DeptID, sBinID)) outflag = true;
                    else outflag = false;
                    if (DeptBR != Convert.ToInt64(DeptID)) isWard = false;
                    else isWard = true;
                }
                else
                {
                    sBinID = Guid.Empty;
                    sWardID = "";

                    toolTip1.Hide(myListview1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void myListview1_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.myListview1.SelectedItems.Count == 0)
                {
                    toolTip1.Hide(myListview1);
                    return;
                }
                if (this.myListview1.FocusedItem.Text == "")
                {
                    toolTip1.Hide(myListview1);
                    return;
                }
                if (this.myListview1.FocusedItem.Tag.ToString().Trim() != "")
                {
                    STAG = Convert.ToString(this.myListview1.FocusedItem.Tag);
                    if ((STAG.Trim() != "") && (STAG != null))
                    {
                        this.patientInfo1.SetInpatientInfo(new Guid(STAG.Substring(0, 40).Trim()), Convert.ToInt64(STAG.Substring(40, 10).Trim()), Convert.ToInt16(STAG.Substring(50, 10).Trim()));

                        //Add By Tany 2010-08-29
                        DataRow dr = patientInfo1.myRow;
                        if (dr != null)
                        {
                            string msg = "";
                            msg += "床        号：" + patientInfo1.lbBed.Text + "\n";
                            msg += "姓        名：" + patientInfo1.lbName.Text + "\n";
                            msg += "性        别：" + patientInfo1.lbSex.Text + "\n";
                            msg += "年        龄：" + patientInfo1.lbAge.Text + "\n";
                            msg += "费用类别：" + patientInfo1.lbJSLX.Text + "\n";
                            msg += "住  院  号：" + patientInfo1.lbID.Text + "\n";
                            msg += "病  人  ID：" + Convertor.IsNull(dr["inpatient_bano"], "") + "\n"; //Add By tany 2015-04-23 增加病人ID显示
                            //病情
                            string s_bq = "";
                            if (dr["order_bw"].ToString() != "0" && dr["order_bw"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                                s_bq = s_bq + "*" + "病危";
                            if (dr["order_bz"].ToString() != "0" && dr["order_bz"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                                s_bq = s_bq + "△" + "病重";
                            msg += "病        情：" + s_bq + "\n";
                            msg += "护理级别：" + (dr["HLJB_NAME"].ToString().Trim().Length > 4 ? dr["HLJB_NAME"].ToString().Trim().Substring(0, 4) : dr["HLJB_NAME"].ToString().Trim()) + "\n";
                            msg += "入院诊断：" + patientInfo1.lbRYZD.Text + "\n";
                            msg += "入院日期：" + patientInfo1.lbIn_Date.Text + "\n";
                            msg += "费用总额：" + patientInfo1.lbFYZE.Text + "\n";
                            msg += "未结算额：" + patientInfo1.lbWJSFY.Text + "\n";
                            msg += "预  收  款：" + patientInfo1.lbYJK.Text + "\n";
                            msg += "欠费限额：" + Convert.ToDecimal(dr["yjj_limit"]).ToString("0.00") + "\n";//Add By tany 2010-11-27
                            msg += "余        额：" + patientInfo1.lbYE.Text + "\n";
                            msg += "提        示：" + patientInfo1.lbTs.Text + "\n";
                            if (Convert.ToDecimal(Convertor.IsNull(dr["fyxz"], "0")) > 0)
                            {
                                msg += "费用限制：" + Convert.ToDecimal(dr["fyxz"]).ToString("0.00") + "\n";
                            }
                            if (Convertor.IsNull(dr["ybjs_date"], "") != "")
                            {
                                msg += "计算时间：" + Convert.ToDateTime(dr["ybjs_date"]).ToString("yyyy-MM-dd HH:mm:ss") + "\n";
                                msg += "医保总额：" + Convert.ToDecimal(dr["ybzfy"]).ToString("0.00") + "\n";
                                msg += "统筹支付：" + Convert.ToDecimal(dr["tczf"]).ToString("0.00") + "\n";
                                msg += "账户支付：" + Convert.ToDecimal(dr["zhzf"]).ToString("0.00") + "\n";
                                msg += "其他支付：" + Convert.ToDecimal(dr["qtzf"]).ToString("0.00") + "\n";
                                msg += "现金支付：" + Convert.ToDecimal(dr["xjzf"]).ToString("0.00") + "\n";
                                msg += "医保余额：" + Convert.ToDecimal(Convert.ToDecimal(dr["yjk"]) - Convert.ToDecimal(dr["xjzf"])).ToString("0.00") + "\n";
                            }
                            string ryshbz = Convertor.IsNull(dr["rysh_bz"], "");
                            if (ryshbz != "")
                            {
                                msg += "入院备注：" + ryshbz + "\n";
                            }
                            //Add By Tany 2011-01-05
                            msg += "描        述：" + dr["SICKDESCRIPTION"].ToString().Trim() + "\n";
                            toolTip1.Show(msg, myListview1, this.myListview1.SelectedItems[0].Position.X + 50, this.listView2.SelectedItems[0].Position.Y + 40, 60000);
                        }
                        else
                        {
                            toolTip1.Hide(listView2);
                        }
                    }
                    else
                    {
                        this.patientInfo1.ClearInpatientInfo();

                        toolTip1.Hide(listView2);
                    }
                    sBinID = new Guid(this.listView2.FocusedItem.Tag.ToString().Substring(0, 40));
                    DeptBR = Convert.ToInt32(this.listView2.FocusedItem.Tag.ToString().Substring(60, 10));
                    sWardID = this.listView2.FocusedItem.Tag.ToString().Substring(70, 4);
                    sWard_dept = this.Ward_dept;
                    if (myQuery.OutFlag(sBinID) || myQuery.TurnFlag(this.DeptID, sBinID)) outflag = true;
                    else outflag = false;
                    if (DeptBR != Convert.ToInt64(DeptID)) isWard = false;
                    else isWard = true;
                }
                else
                {
                    sBinID = Guid.Empty;
                    sWardID = "";

                    toolTip1.Hide(listView2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string ifqy = ApiFunction.GetIniString("SfQy", "SfQy", Constant.ApplicationDirectory + "\\Cpset.ini");
            if (ifqy == "1")
            {
                string typename = ApiFunction.GetIniString("Tpype", "typename", Constant.ApplicationDirectory + "\\Cpset.ini");
                if (typename == "曼德罗")
                {
                    try
                    {
                        //判断是否进入路径
                        Ts_Clinicalpathway_Factory.Ts_Manadal_path.GetCpstatus(this.BinID.ToString(), "", "", "", "", System.DateTime.Now.ToString());
                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message); 
                    }
                }
            }
        }
        //add by yaokx 2013-03-12 特殊治疗按科室排序
        private void butt_ks_Click(object sender, EventArgs e)
        {
            InitView_TS(1);
        }
        private void menuItem15_Click(object sender, EventArgs e)
        {
            try
            {
                string sfqy = ApiFunction.GetIniString("bl", "是否启用", Constant.ApplicationDirectory + "\\bl.ini");
                if (sfqy == "1")
                {
                    Ts_Bl_interface.BlFactory bf = new Ts_Bl_interface.BlFactory();
                    bf.Create("").ShowPatBlInfo(sBinID, Ts_Bl_interface.PatientSource.住院);
                    //bf.Create("").ShowBlSq(sBinID, Ts_Bl_interface.PatientSource.住院);
                }
                else
                {
                    MessageBox.Show("没有开启病理接口，请联系管理员");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSyncOldHISPatInfo_Click(object sender, EventArgs e)
        {
            TrasenHIS.BLL.SyncPatientInfo.SyncPat(FrmMdiMain.Database);
        }

        //Add By Tany 2015-02-11 重刷医嘱比例
        private void btReComputeRate_Click(object sender, EventArgs e)
        {
            string zyh = "";
            if (patientInfo1.lbID.Text == "")
            {
                //如果是管理员，可以弹出输入框 Modify By Tany 2015-03-17
                if (FrmMdiMain.CurrentUser.IsAdministrator)
                {
                    TrasenFrame.Forms.DlgInputBox dlgInput = new TrasenFrame.Forms.DlgInputBox("", "请输入住院号：", "重刷医嘱比例");
                    //dlgInput.NumCtrl = true;
                    dlgInput.ShowDialog();
                    if (DlgInputBox.DlgResult)
                    {
                        zyh = DlgInputBox.DlgValue;
                    }
                }
            }
            else
            {
                zyh = patientInfo1.lbID.Text;
            }
            if (zyh == "")
            {
                MessageBox.Show("请选择病人！");
                return;
            }

            string ts = "重要提示！！！\r\n\r\n住院号：【" + zyh + "】\r\n床号：【" + patientInfo1.lbBed.Text + "】\r\n姓名：【" + patientInfo1.lbName.Text + "】\r\n该操作会重新计算病人所有有效医嘱的自付比例，请根据提示操作！\r\n\r\n是否继续操作？";
            if (MessageBox.Show(ts, "重要提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            try
            {
                TrasenHIS.BLL.Judgeorder jo = new TrasenHIS.BLL.Judgeorder(FrmMdiMain.Database);
                jo.ReComputeRate(zyh);

                MessageBox.Show("重新计算完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listView4.Items.Count > 0 && textBox1.Text.Trim() != string.Empty)
            {
                this.listView4.Items.Clear();
                TSTb = myQuery.GetTSapply(0, DeptID, 1, cmbWard.SelectedValue.ToString());
                if (TSTb.Rows.Count == 0)
                    return;
                DataRow[] rows = TSTb.Select(string.Format(" INPATIENT_NO like '%{0}%'", textBox1.Text.Trim()));
                if (rows != null && rows.Length > 0)
                {
                    ListViewItem LItem = null;
                    for (int i = 0; i < rows.Length; i++)
                    {
                        LItem = new ListViewItem(new string[]{rows[i]["INPATIENT_ID"].ToString(),
													   rows[i]["INPATIENT_NO"].ToString(),
													   rows[i]["BinName"].ToString(),
													   rows[i]["WARD_ID"].ToString(),
													   rows[i]["DeptName"].ToString(),
													   (Convert.ToDateTime(rows[i]["APPLY_DATE"])).ToString("yyyy-MM-dd HH:mm:ss"),
													   rows[i]["doc_name"].ToString(),
													   rows[i]["content"].ToString(),
                                                       rows[i]["id"].ToString()});

                        this.listView4.Items.Add(LItem).Tag = rows[i]["STAG"].ToString();
                    }
                }
            }
            else if (textBox1.Text.Trim() == string.Empty)
                InitView_TS(0);

            listView4_SelectedIndexChanged(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable BedTb;
            if (tabControl1.SelectedTab.Text == "管辖内病人")
            {
                if (checkCpIN.Checked)
                    BedTb = myQuery.GetInpatientCp(1, this.DeptID, this.YS_ID, 0);
                else if (checkDbz.Checked)
                    BedTb = myQuery.GetInpatientCp(1, this.DeptID, this.YS_ID, 1);
                else
                    BedTb = myQuery.GetInpatient(1, this.DeptID, this.YS_ID);
                if (BedTb.Rows.Count > 0)
                {
                    Dictionary<string, string> xlsInfo = new Dictionary<string, string>();
                    xlsInfo.Add("A", "BED_NO");
                    xlsInfo.Add("B", "INPATIENT_NO");
                    xlsInfo.Add("C", "NAME");
                    xlsInfo.Add("D", "SEX_NAME");
                    xlsInfo.Add("E", "AGE");
                    xlsInfo.Add("F", "RYZD");
                    xlsInfo.Add("G", "IN_DATE");
                    xlsInfo.Add("H", "YBLX_NAME");


                    ExportInExcel(BedTb, xlsInfo);
                }
                else
                {
                    MessageBox.Show("无数据，导出失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tabControl1.SelectedTab.Text == "本科所有病人")
            {
                if (checkCpIN.Checked)
                    BedTb = myQuery.GetInpatientCp(2, this.DeptID, this.YS_ID, 0);
                else if (checkDbz.Checked)
                    BedTb = myQuery.GetInpatientCp(2, this.DeptID, this.YS_ID, 1);
                else
                    BedTb = myQuery.GetInpatient(2, this.DeptID, this.YS_ID);

                if (BedTb.Rows.Count > 0)
                {
                    Dictionary<string, string> xlsInfo = new Dictionary<string, string>();
                    xlsInfo.Add("A", "BED_NO");
                    xlsInfo.Add("B", "INPATIENT_NO");
                    xlsInfo.Add("C", "NAME");
                    xlsInfo.Add("D", "SEX_NAME");
                    xlsInfo.Add("E", "AGE");
                    xlsInfo.Add("F", "RYZD");
                    xlsInfo.Add("G", "IN_DATE");
                    xlsInfo.Add("H", "YBLX_NAME");

                    ExportInExcel(BedTb, xlsInfo);
                }
                else
                {
                    MessageBox.Show("无数据，导出失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void ExportInExcel(DataTable dt, Dictionary<string, string> dict)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 文件(*.xlsx)|*.xlsx";
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.FileName = string.Format("{0}.xlsx", DateTime.Now.ToString("yyyyMMddhhmmss"));
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(Waiting);
                thread.IsBackground = true;
                thread.Start();

                Stream s = this.GetType().Assembly.GetManifestResourceStream("Ts_zyys_main.Resources.data.xlsx");
                StreamToFile(s, sfd.FileName);

                Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
                wb.Open(sfd.FileName);
                int rowIndex = 2;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i]["INPATIENT_ID"].ToString()) && dt.Rows[i]["FLAG"].ToString() == "3")
                    {
                        foreach (KeyValuePair<string, string> pair in dict) //循环rowIndex行  的dict所有列
                        {

                            DataTable getValueDT = new DataTable();
                            getValueDT = FrmMdiMain.Database.GetDataTable(" select INPATIENT_NO,RYZD,IN_DATE from VI_ZY_VINPATIENT_BED where INPATIENT_ID='" + dt.Rows[i]["INPATIENT_ID"].ToString() + "'");
                            if (pair.Value == "INPATIENT_NO")
                                wb.Worksheets[0].Cells[pair.Key + rowIndex.ToString()].PutValue(getValueDT.Rows[0][pair.Value].ToString());
                            else if (pair.Value == "RYZD")
                                wb.Worksheets[0].Cells[pair.Key + rowIndex.ToString()].PutValue(getValueDT.Rows[0][pair.Value].ToString());
                            else if (pair.Value == "IN_DATE")
                                wb.Worksheets[0].Cells[pair.Key + rowIndex.ToString()].PutValue(getValueDT.Rows[0][pair.Value].ToString());
                            else
                                wb.Worksheets[0].Cells[pair.Key + rowIndex.ToString()].PutValue(dt.Rows[i][pair.Value].ToString());
                        }
                        rowIndex++;
                    }
                }

                wb.SaveToStream();
                wb.Save(sfd.FileName);

                if (thread != null && thread.IsAlive)
                {
                    thread.Abort(); //销毁线程，自动回收托管资源
                }

                MessageBox.Show("数据导出成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Waiting()
        {
            FrmWait fw = new FrmWait();
            fw.ShowDialog();
        }

        private void StreamToFile(Stream stream, string fileName)
        {
            // 把 Stream 转换成 byte[] 
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始 
            stream.Seek(0, SeekOrigin.Begin);
            // 把 byte[] 写入文件 
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public static string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }

        /// <summary>
        /// Modify by jchl 2016-07-13
        /// </summary>
        private void InitHlyy()
        {
            try
            {
                if (cfg6032 == "1")
                {
                    string hlyytype = "";
                    hlyytype = GetIniString("hlyy", "name", System.Windows.Forms.Application.StartupPath + "\\Hlyy.ini");

                    hl = Ts_Hlyy_Interface.HlyyFactory.Hlyy(hlyytype);
                    hl.RegisterServer_fun(new object[] { });
                    //hl.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("合理用药初始化错误！\r\r" + ex.Message, "错误信息！");
            }
        }

        /// <summary>
        /// Modify by jchl 2016-07-13
        /// </summary>
        private void CloseHlyy()
        {
            try
            {
                if (cfg6032 == "1" && hl != null)
                {
                    this.hl.UNRegisterServer();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("合理用药关闭错误！\r\r" + ex.Message, "错误信息！");
            }
        }

        /// <summary>
        /// 患者电子健康档案浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem19_Click(object sender, EventArgs e)
        {

            try
            {
                {

                    //string path = @"D:\bsoft\portal\360\360chrome.exe";
                    string url = string.Format(@"http://192.168.0.26:8080/emrinterfaces/inPatientServlet?reqCode=9009New&ipId={0}", Convert.ToInt64(patientInfo1.lbID.Text).ToString());

                    //System.Diagnostics.Process[] myProcesses;
                    //myProcesses = System.Diagnostics.Process.GetProcessesByName("360chrome");
                    //foreach (System.Diagnostics.Process instance in myProcesses)
                    //{
                    //    //instance.CloseMainWindow();
                    //    instance.Kill();
                    //}

                    System.Diagnostics.Process.Start(url);
                    //System.Diagnostics.Process.Start("explorer.exe", url);  
                    //System.Diagnostics.Process.Start(path, url);
                }
            }
            catch { }
        }

        private void menuItem20_Click(object sender, EventArgs e)
        {

            try
            {
                {
                    //string path = @"D:\bsoft\portal\360\360chrome.exe";

                    string url = string.Format(@"http://192.168.201.29:7000/IMCISClient/Interface/ClinicExamList?UserID=his&UserPwd=123456&MedRecNO={0}", Convert.ToInt64(patientInfo1.lbID.Text).ToString());

                    //System.Diagnostics.Process[] myProcesses;
                    //myProcesses = System.Diagnostics.Process.GetProcessesByName("360chrome");
                    //foreach (System.Diagnostics.Process instance in myProcesses)
                    //{
                    //    //instance.CloseMainWindow();
                    //    instance.Kill();
                    //}

                    //System.Diagnostics.Process.Start(path, url);

                    System.Diagnostics.Process.Start(url);
                    //System.Diagnostics.Process.Start("explorer.exe", url);  
                }
            }
            catch { }
        }

        private void menuItem17_Click(object sender, EventArgs e)
        {
            Ts_zyys_yzgl.FrmDBZ FrmDBZ = new Ts_zyys_yzgl.FrmDBZ(InstanceForm._database, sBinID);
             //STAG = Convert.ToString(this.myListview1.FocusedItem.Tag);
             if ((STAG.Trim() != "") && (STAG != null))
             {
                 this.patientInfo1.SetInpatientInfo(new Guid(STAG.Substring(0, 40).Trim()), Convert.ToInt64(STAG.Substring(40, 10).Trim()), Convert.ToInt16(STAG.Substring(50, 10).Trim()));
             }
            FrmDBZ.dqje = patientInfo1.lbFYZE.Text;
            FrmDBZ.binid = sBinID;
            FrmDBZ.ShowDialog();
        }



    }
}
