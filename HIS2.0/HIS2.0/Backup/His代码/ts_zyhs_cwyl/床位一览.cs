using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Runtime.InteropServices;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using TszyHIS;
using Crownwood.Magic.Docking;
using Crownwood.Magic.Common;
using ts_zyhs_fpcw;
using System.Drawing.Drawing2D;
using System.Diagnostics;
namespace ts_zyhs_cwyl
{
    /// <summary>
    /// 主窗体 的摘要说明。
    /// </summary>
    public class frmCWYL : System.Windows.Forms.Form
    {
        //自定义字段
        //public long BinID = 0;
        //public long Baby = 0;
        private BaseFunc myFunc;
        [DllImport("user32.dll")]
        static extern int GetScrollPos(IntPtr hwnd, int bar);
        public delegate void Delegtesroll(int i, int index, ListView lv);
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern bool PostMessage(int hWnd, int Msg, int wParam, int lParam);
        public System.Data.OleDb.OleDbConnection cCon = new OleDbConnection();
        public DataView SelectDataView = null;
        private int bit = 0;  //bit=0 图标 bit=1 床头卡
        private string[] stagArr;
        public static Guid[] openForm = new Guid[10]; //被打开的医嘱管理窗体，限制为10个
        private bool isClose = true;//是否要关闭
        private bool isCloseC = true;
        string bedno = "";
        string name = "";
        string sex = "";
        string age = "";
        string fb = "";
        string zyh = "";
        string bq = "";
        string tend = "";
        string zd = "";
        string ryrq = "";
        string bc = "";
        PictureBox[] Cpgb;//图片临床路径
        //是否使用电子病历 Add By Tany 2011-07-30
        private bool isUseEMR = false;
        SystemCfg cfg7145 = new SystemCfg(7145);
        SystemCfg cfg7205 = new SystemCfg(7205);
        SystemCfg cfg7600 = new SystemCfg(7600);//Modify by jchl  护士站分配床位是否联动产生床位费，0否，1是  
        #region Windows控件
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel中;
        private System.Windows.Forms.Panel panel中下;
        private ts_zyhs_cwyl.myListview listView1;
        private System.Windows.Forms.MenuItem mnb病人信息;
        private System.Windows.Forms.MenuItem mnuDYCY;
        private System.Windows.Forms.MenuItem mnb出院召回;
        private 病人信息.PatientInfo patientInfo1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem mnuBRZK;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem40;
        private System.Windows.Forms.MenuItem menuItem43;
        private System.Windows.Forms.MenuItem menuItem48;
        private System.Windows.Forms.MenuItem menuItem49;
        private System.Windows.Forms.MenuItem menuItem51;
        private System.Windows.Forms.Panel panBed;
        private System.Windows.Forms.Panel panel总;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private RichTextBoxEx rtbMsg;
        private System.Windows.Forms.MenuItem mnuRefrashBed;
        private System.Windows.Forms.MenuItem mnuOrderPrt;
        private System.Windows.Forms.MenuItem mnuBC;
        private System.Windows.Forms.MenuItem mnuQXBC;
        private System.Windows.Forms.MenuItem mnuFM;
        private System.Windows.Forms.MenuItem mnuOrderQuery;
        private System.Windows.Forms.MenuItem mnuOrderZC;
        private System.Windows.Forms.MenuItem mnuZDLR;
        private System.Windows.Forms.MenuItem mnuFYXX;
        private System.Windows.Forms.MenuItem mnuYPXX;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem mnuXGXX;
        private System.Windows.Forms.MenuItem mnuZC;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imgBED;
        private Panel plDock;
        private Button btRefresh;
        private DataGridView dgvNewPatient;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private MenuItem mnuXgbrxx;
        private MenuItem menuItem1;
        private MenuItem mnuEMR;
        private ImageList ImgCp;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private MenuItem menuItem7;
        private Button btSyncOldHISPatInfo;
        private UcShowCard ucShowCard1;
        private MenuItem menuItem8;
        private System.Windows.Forms.Timer timer1;
        #endregion Windows控件

        public frmCWYL(string _formText, long _curDeptId, long _curUserId)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            myFunc = new BaseFunc();

            DockingPanel();
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCWYL));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            ""}, -1);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem48 = new System.Windows.Forms.MenuItem();
            this.menuItem49 = new System.Windows.Forms.MenuItem();
            this.menuItem51 = new System.Windows.Forms.MenuItem();
            this.mnuRefrashBed = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem43 = new System.Windows.Forms.MenuItem();
            this.mnuXGXX = new System.Windows.Forms.MenuItem();
            this.mnuXgbrxx = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuZC = new System.Windows.Forms.MenuItem();
            this.mnuBC = new System.Windows.Forms.MenuItem();
            this.mnuQXBC = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.mnuFM = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.mnuOrderQuery = new System.Windows.Forms.MenuItem();
            this.mnuOrderZC = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.mnuZDLR = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuFYXX = new System.Windows.Forms.MenuItem();
            this.mnuYPXX = new System.Windows.Forms.MenuItem();
            this.mnb病人信息 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuBRZK = new System.Windows.Forms.MenuItem();
            this.mnuDYCY = new System.Windows.Forms.MenuItem();
            this.mnb出院召回 = new System.Windows.Forms.MenuItem();
            this.menuItem40 = new System.Windows.Forms.MenuItem();
            this.mnuOrderPrt = new System.Windows.Forms.MenuItem();
            this.mnuEMR = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panBed = new System.Windows.Forms.Panel();
            this.imgBED = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel中下 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btSyncOldHISPatInfo = new System.Windows.Forms.Button();
            this.rtbMsg = new TrasenClasses.GeneralControls.RichTextBoxEx(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.patientInfo1 = new 病人信息.PatientInfo();
            this.panel总 = new System.Windows.Forms.Panel();
            this.panel中 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.plDock = new System.Windows.Forms.Panel();
            this.dgvNewPatient = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucShowCard1 = new ts_zyhs_classes.UcShowCard();
            this.btRefresh = new System.Windows.Forms.Button();
            this.ImgCp = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new ts_zyhs_cwyl.myListview();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.panel中下.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel总.SuspendLayout();
            this.panel中.SuspendLayout();
            this.plDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem48,
            this.mnuRefrashBed,
            this.menuItem6,
            this.menuItem43,
            this.mnuXGXX,
            this.mnuXgbrxx,
            this.menuItem3,
            this.mnuZC,
            this.mnuBC,
            this.mnuQXBC,
            this.menuItem11,
            this.mnuFM,
            this.menuItem20,
            this.mnuOrderQuery,
            this.mnuOrderZC,
            this.menuItem4,
            this.mnuZDLR,
            this.menuItem2,
            this.mnuFYXX,
            this.mnuYPXX,
            this.mnb病人信息,
            this.menuItem9,
            this.menuItem10,
            this.menuItem1,
            this.mnuBRZK,
            this.mnuDYCY,
            this.mnb出院召回,
            this.menuItem40,
            this.mnuOrderPrt,
            this.mnuEMR,
            this.menuItem5,
            this.menuItem7,
            this.menuItem8});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem48
            // 
            this.menuItem48.Index = 0;
            this.menuItem48.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem49,
            this.menuItem51});
            this.menuItem48.Text = "视图";
            this.menuItem48.Popup += new System.EventHandler(this.menuItem48_Popup);
            // 
            // menuItem49
            // 
            this.menuItem49.Index = 0;
            this.menuItem49.Text = "图标";
            this.menuItem49.Click += new System.EventHandler(this.viewType_Click);
            // 
            // menuItem51
            // 
            this.menuItem51.Index = 1;
            this.menuItem51.Text = "床头卡";
            this.menuItem51.Click += new System.EventHandler(this.viewType_Click);
            // 
            // mnuRefrashBed
            // 
            this.mnuRefrashBed.Index = 1;
            this.mnuRefrashBed.Text = "刷新床位";
            this.mnuRefrashBed.Click += new System.EventHandler(this.mnuRefrashBed_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "按姓名排序";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem43
            // 
            this.menuItem43.Index = 3;
            this.menuItem43.Text = "-";
            // 
            // mnuXGXX
            // 
            this.mnuXGXX.Index = 4;
            this.mnuXGXX.Text = "修改管床信息";
            this.mnuXGXX.Click += new System.EventHandler(this.mnuXGXX_Click);
            // 
            // mnuXgbrxx
            // 
            this.mnuXgbrxx.Index = 5;
            this.mnuXgbrxx.Text = "修改病人信息";
            this.mnuXgbrxx.Click += new System.EventHandler(this.mnuXgbrxx_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 6;
            this.menuItem3.Text = "-";
            // 
            // mnuZC
            // 
            this.mnuZC.Index = 7;
            this.mnuZC.Text = "转床";
            this.mnuZC.Click += new System.EventHandler(this.mnuZC_Click);
            // 
            // mnuBC
            // 
            this.mnuBC.Index = 8;
            this.mnuBC.Text = "包床";
            this.mnuBC.Click += new System.EventHandler(this.mnuBCorQXBC_Click);
            // 
            // mnuQXBC
            // 
            this.mnuQXBC.Index = 9;
            this.mnuQXBC.Text = "取消包床";
            this.mnuQXBC.Click += new System.EventHandler(this.mnuBCorQXBC_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 10;
            this.menuItem11.Text = "-";
            // 
            // mnuFM
            // 
            this.mnuFM.Index = 11;
            this.mnuFM.Text = "";
            this.mnuFM.Click += new System.EventHandler(this.mnuFM_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 12;
            this.menuItem20.Text = "-";
            // 
            // mnuOrderQuery
            // 
            this.mnuOrderQuery.Index = 13;
            this.mnuOrderQuery.Text = "医嘱查询";
            this.mnuOrderQuery.Click += new System.EventHandler(this.mnuOrderQuery_Click);
            // 
            // mnuOrderZC
            // 
            this.mnuOrderZC.Index = 14;
            this.mnuOrderZC.Text = "医嘱转抄";
            this.mnuOrderZC.Click += new System.EventHandler(this.mnuOrderZC_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 15;
            this.menuItem4.Text = "医嘱核对";
            this.menuItem4.Visible = false;
            this.menuItem4.Click += new System.EventHandler(this.mn1分配床位_Click);
            // 
            // mnuZDLR
            // 
            this.mnuZDLR.Index = 16;
            this.mnuZDLR.Text = "账单录入";
            this.mnuZDLR.Click += new System.EventHandler(this.mnuZDLR_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 17;
            this.menuItem2.Text = "-";
            // 
            // mnuFYXX
            // 
            this.mnuFYXX.Index = 18;
            this.mnuFYXX.Text = "费用信息";
            this.mnuFYXX.Click += new System.EventHandler(this.mnuFYXX_Click);
            // 
            // mnuYPXX
            // 
            this.mnuYPXX.Index = 19;
            this.mnuYPXX.Text = "药品信息";
            this.mnuYPXX.Click += new System.EventHandler(this.mnuYPXX_Click);
            // 
            // mnb病人信息
            // 
            this.mnb病人信息.Index = 20;
            this.mnb病人信息.Text = "病人信息";
            this.mnb病人信息.Visible = false;
            this.mnb病人信息.Click += new System.EventHandler(this.mn1分配床位_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 21;
            this.menuItem9.Text = "包房";
            this.menuItem9.Visible = false;
            this.menuItem9.Click += new System.EventHandler(this.mn1分配床位_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 22;
            this.menuItem10.Text = "取消包房";
            this.menuItem10.Visible = false;
            this.menuItem10.Click += new System.EventHandler(this.mn1分配床位_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 23;
            this.menuItem1.Text = "-";
            // 
            // mnuBRZK
            // 
            this.mnuBRZK.Index = 24;
            this.mnuBRZK.Text = "病人转科";
            this.mnuBRZK.Click += new System.EventHandler(this.mnuBRZK_Click);
            // 
            // mnuDYCY
            // 
            this.mnuDYCY.Index = 25;
            this.mnuDYCY.Text = "定义出院";
            this.mnuDYCY.Click += new System.EventHandler(this.mnuDYCY_Click);
            // 
            // mnb出院召回
            // 
            this.mnb出院召回.Index = 26;
            this.mnb出院召回.Text = "出院召回";
            this.mnb出院召回.Visible = false;
            this.mnb出院召回.Click += new System.EventHandler(this.mn1分配床位_Click);
            // 
            // menuItem40
            // 
            this.menuItem40.Index = 27;
            this.menuItem40.Text = "-";
            // 
            // mnuOrderPrt
            // 
            this.mnuOrderPrt.Index = 28;
            this.mnuOrderPrt.Text = "医嘱打印";
            this.mnuOrderPrt.Click += new System.EventHandler(this.mnuOrderPrt_Click);
            // 
            // mnuEMR
            // 
            this.mnuEMR.Index = 29;
            this.mnuEMR.Text = "电子病历";
            this.mnuEMR.Click += new System.EventHandler(this.mnuEMR_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 30;
            this.menuItem5.Text = "-";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 31;
            this.menuItem7.Text = "医保审核";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 300;
            // 
            // panBed
            // 
            this.panBed.AutoScroll = true;
            this.panBed.BackColor = System.Drawing.Color.White;
            this.panBed.ContextMenu = this.contextMenu1;
            this.panBed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBed.Location = new System.Drawing.Point(0, 0);
            this.panBed.Name = "panBed";
            this.panBed.Size = new System.Drawing.Size(1014, 215);
            this.panBed.TabIndex = 3;
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
            this.imgBED.Images.SetKeyName(71, "lg.ico");
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
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            // 
            // panel中下
            // 
            this.panel中下.Controls.Add(this.panel2);
            this.panel中下.Controls.Add(this.panel1);
            this.panel中下.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel中下.Location = new System.Drawing.Point(0, 215);
            this.panel中下.Name = "panel中下";
            this.panel中下.Size = new System.Drawing.Size(1014, 144);
            this.panel中下.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btSyncOldHISPatInfo);
            this.panel2.Controls.Add(this.rtbMsg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(461, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 144);
            this.panel2.TabIndex = 16;
            // 
            // btSyncOldHISPatInfo
            // 
            this.btSyncOldHISPatInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSyncOldHISPatInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSyncOldHISPatInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSyncOldHISPatInfo.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSyncOldHISPatInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btSyncOldHISPatInfo.Location = new System.Drawing.Point(363, 118);
            this.btSyncOldHISPatInfo.Name = "btSyncOldHISPatInfo";
            this.btSyncOldHISPatInfo.Size = new System.Drawing.Size(169, 24);
            this.btSyncOldHISPatInfo.TabIndex = 46;
            this.btSyncOldHISPatInfo.Text = "同步新老系统病人信息";
            this.btSyncOldHISPatInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSyncOldHISPatInfo.Click += new System.EventHandler(this.btSyncOldHISPatInfo_Click);
            // 
            // rtbMsg
            // 
            this.rtbMsg.BackColor = System.Drawing.SystemColors.Window;
            this.rtbMsg.DetectUrls = false;
            this.rtbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMsg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbMsg.LinkStyle = true;
            this.rtbMsg.Location = new System.Drawing.Point(0, 0);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.ReadOnly = true;
            this.rtbMsg.Size = new System.Drawing.Size(553, 144);
            this.rtbMsg.TabIndex = 14;
            this.rtbMsg.Text = "";
            this.rtbMsg.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbMsg_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.patientInfo1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 144);
            this.panel1.TabIndex = 15;
            // 
            // patientInfo1
            // 
            this.patientInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.patientInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientInfo1.IsShow = true;
            this.patientInfo1.Location = new System.Drawing.Point(0, 0);
            this.patientInfo1.Name = "patientInfo1";
            this.patientInfo1.Size = new System.Drawing.Size(461, 144);
            this.patientInfo1.TabIndex = 14;
            // 
            // panel总
            // 
            this.panel总.BackColor = System.Drawing.Color.White;
            this.panel总.Controls.Add(this.panel中);
            this.panel总.Controls.Add(this.panel中下);
            this.panel总.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel总.Location = new System.Drawing.Point(0, 0);
            this.panel总.Name = "panel总";
            this.panel总.Size = new System.Drawing.Size(1014, 359);
            this.panel总.TabIndex = 5;
            // 
            // panel中
            // 
            this.panel中.Controls.Add(this.listView1);
            this.panel中.Controls.Add(this.panBed);
            this.panel中.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel中.Location = new System.Drawing.Point(0, 0);
            this.panel中.Name = "panel中";
            this.panel中.Size = new System.Drawing.Size(1014, 215);
            this.panel中.TabIndex = 4;
            this.panel中.SizeChanged += new System.EventHandler(this.panel中_SizeChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 120000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // plDock
            // 
            this.plDock.Controls.Add(this.dgvNewPatient);
            this.plDock.Controls.Add(this.ucShowCard1);
            this.plDock.Controls.Add(this.btRefresh);
            this.plDock.Location = new System.Drawing.Point(55, 84);
            this.plDock.Name = "plDock";
            this.plDock.Size = new System.Drawing.Size(139, 274);
            this.plDock.TabIndex = 6;
            // 
            // dgvNewPatient
            // 
            this.dgvNewPatient.AllowUserToAddRows = false;
            this.dgvNewPatient.AllowUserToDeleteRows = false;
            this.dgvNewPatient.AllowUserToResizeRows = false;
            this.dgvNewPatient.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNewPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNewPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNewPatient.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNewPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNewPatient.Location = new System.Drawing.Point(0, 50);
            this.dgvNewPatient.MultiSelect = false;
            this.dgvNewPatient.Name = "dgvNewPatient";
            this.dgvNewPatient.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNewPatient.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNewPatient.RowHeadersVisible = false;
            this.dgvNewPatient.RowHeadersWidth = 4;
            this.dgvNewPatient.RowTemplate.Height = 23;
            this.dgvNewPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNewPatient.Size = new System.Drawing.Size(139, 224);
            this.dgvNewPatient.TabIndex = 1;
            this.dgvNewPatient.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNewPatient_CellMouseDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "姓名";
            this.Column1.HeaderText = "姓名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "性别";
            this.Column2.HeaderText = "性别";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 20;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "所属科室";
            this.Column3.HeaderText = "所属科室";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "病人来源";
            this.Column4.HeaderText = "病人来源";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 60;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "住院号";
            this.Column6.HeaderText = "住院号";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "入院日期";
            this.Column5.HeaderText = "入院日期";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 120;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "婴儿号";
            this.Column7.HeaderText = "婴儿号";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "ID";
            this.Column8.HeaderText = "ID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "pat_in_dept";
            this.Column9.HeaderText = "pat_in_dept";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "inpatient_id";
            this.Column10.HeaderText = "inpatient_id";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "baby_id";
            this.Column11.HeaderText = "baby_id";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // ucShowCard1
            // 
            this.ucShowCard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucShowCard1.IType = 0;
            this.ucShowCard1.Key = "";
            this.ucShowCard1.Location = new System.Drawing.Point(0, 29);
            this.ucShowCard1.Name = "ucShowCard1";
            this.ucShowCard1.Row = null;
            this.ucShowCard1.Size = new System.Drawing.Size(139, 21);
            this.ucShowCard1.TabIndex = 2;
            this.ucShowCard1.Value = "";
            this.ucShowCard1.MyDelEvent += new ts_zyhs_classes.UcShowCard.MyDel(this.ucShowCard1_MyDelEvent);
            // 
            // btRefresh
            // 
            this.btRefresh.BackColor = System.Drawing.Color.White;
            this.btRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRefresh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRefresh.Location = new System.Drawing.Point(0, 0);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(139, 29);
            this.btRefresh.TabIndex = 0;
            this.btRefresh.Text = "刷新病人(&R)";
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // ImgCp
            // 
            this.ImgCp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgCp.ImageStream")));
            this.ImgCp.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgCp.Images.SetKeyName(0, "utsing.gif");
            this.ImgCp.Images.SetKeyName(1, "CP.png");
            this.ImgCp.Images.SetKeyName(2, "dbz1.ico");
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.ContextMenu = this.contextMenu1;
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.LargeImageList = this.imgBED;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1014, 215);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.Leave += new System.EventHandler(this.listView1_Leave);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.GD += new ts_zyhs_cwyl.GdtGt(this.listView1_GD);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.MouseLeave += new System.EventHandler(this.listView1_MouseLeave);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 32;
            this.menuItem8.Text = "护理记录";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // frmCWYL
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1014, 359);
            this.Controls.Add(this.plDock);
            this.Controls.Add(this.panel总);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCWYL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "护士工作站";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCWYL_Load_1);
            this.Activated += new System.EventHandler(this.frmCWYL_Activated);
            this.Leave += new System.EventHandler(this.frmCWYL_Leave);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmCWYL_Closing);
            this.panel中下.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel总.ResumeLayout(false);
            this.panel中.ResumeLayout(false);
            this.plDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPatient)).EndInit();
            this.ResumeLayout(false);

        }

        void panel中_SizeChanged(object sender, EventArgs e)
        {
            PostMessage(this.listView1.Handle.ToInt32(), 0x020A, 0, 0);
        }

        void listView1_GD()
        {
            int i = 0;
            for (i = 0; i < this.listView1.Items.Count; i++)
            {
                scroll(0, i, listView1);
            }
        }
        private void scroll(int i, int index, ListView mylistView)
        {
            try
            {
                int x = GetScrollPos(mylistView.Handle, 0);
                int y = GetScrollPos(mylistView.Handle, 1);
                if (Cpgb[index] != null)
                    Cpgb[index].Location = new Point(mylistView.Items[index].Position.X + mylistView.LargeImageList.ImageSize.Width - x, mylistView.Items[index].Position.Y + mylistView.LargeImageList.ImageSize.Height - 15 - y);
            }
            catch
            {

            }
        }
        #endregion

        private void DockingPanel()
        {
            DockingManager _dockingManager = new DockingManager(this, VisualStyle.IDE);

            _dockingManager.OuterControl = panel中;
            _dockingManager.InnerControl = panel总;

            Content content = _dockingManager.Contents.Add(plDock, "新病人");
            WindowContent wc = _dockingManager.AddContentWithState(content, State.DockLeft) as WindowContent;

            content.CloseButton = false;
            //content.
        }



        private void frmCWYL_Load(object sender, System.EventArgs e)
        {
            //Modify by jchl
            mnuZDLR.Visible = false;
            mnuOrderZC.Visible = false;

            //Add By Tany 2005-02-24
            if (CheckBedNo() == false)
            {
                MessageBox.Show("本病区有床位代码设置重合，部分操作将产生严重错误，请及时通知信息科更改！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            for (int i = 0; i < 10; i++) openForm[i] = Guid.Empty;

            InitView(bit, 0);
            this.listView1.Focus();

            ShowNewPatient();
        }

        private void frmCWYL_Closing(object sender, CancelEventArgs e)
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
                if (MessageBox.Show("还有未关闭的医嘱录入窗体，是否要关闭？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
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

        /// <summary>
        /// 检查床位编号是否有重复值
        /// </summary>
        /// <returns></returns>
        private bool CheckBedNo()
        {
            bool isOk = true;
            string sSql = "select bed_no from zy_beddiction where isinuse=0 and ward_id='" + InstanceForm.BCurrentDept.WardId + "' group by bed_no having count(bed_no)>1";
            DataTable bedTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (bedTb.Rows.Count > 0)
            {
                isOk = false;
            }

            return isOk;
        }

        private void InitView(int bit, int pxlx)//bit=0 图标 bit=1 床头卡 pxlx 0=床位号，1=病人姓名
        {
            string S_Data = "";
            string sSql = "";
            try
            {
                if (bit == 0)
                {
                    panBed.Visible = false;
                    listView1.Visible = true;

                    //Modify by Tany 2005-02-24
                    //增加停用标志
                    sSql = "select config from jc_config where id=7044";
                    string px = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql), "0");
                    //if (px.ToString() == "0")
                    //    px = " A.ROOM_NO,dbo.Fun_GetBedToOrder( (case when left(a.bed_no,1)='+' then '999'+a.bed_no else a.bed_no end) )";//Modify by zouchihua 2012-3-12 床位排序增加函数判断
                    //else
                    //    px = "dbo.Fun_GetBedToOrder( (case when left(a.bed_no,1)='+' then '999'+a.bed_no else a.bed_no end) )";//Modify by zouchihua 2012-3-12 床位排序增加函数判断

                    //Modify by pengy 2014-11-21
                    if (px == "0")
                    {
                        //                        px = @"  A.ROOM_NO asc,
                        //                                 CHARINDEX('+',a.bed_no) ASC,
                        //                                 ISNUMERIC(a.bed_no) DESC,
                        //                                 CAST(substring(a.bed_no,PATindex('%[1234567890]%',a.bed_no),
                        //                                 len(a.bed_no) - patindex('%[1234567890]%',a.bed_no) + 1) as INT)";

                        px = @" A.ROOM_NO asc,
                                case when isnumeric(a.bed_no)=1 and SUBSTRING (a.bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',a.bed_no)>0 then 2 when SUBSTRING (a.bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(a.bed_no)=1 then cast(a.bed_no as int) else 999999 end";
                    }
                    else
                        //                        px = @"  CHARINDEX('+',a.bed_no) ASC,
                        //                                 ISNUMERIC(a.bed_no) DESC,
                        //                                 CAST(substring(a.bed_no,PATindex('%[1234567890]%',a.bed_no),
                        //                                 len(a.bed_no) - patindex('%[1234567890]%',a.bed_no) + 1) as INT)";
                        px = @"case when isnumeric(a.bed_no)=1 and SUBSTRING (a.bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',a.bed_no)>0 then 2 when SUBSTRING (a.bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(a.bed_no)=1 then cast(a.bed_no as int) else 999999 end,a.bed_no";

                    if (pxlx == 1)
                        px = " c.name,A.ROOM_NO ";
                    sSql = @"SELECT a.Ismzlg ,A.ROOM_NO,A.BED_NO,A.INPATIENT_ID,A.ISBF,A.ISMYTS,A.BED_ID,B.BED_NO as BF_NO,C.AGE,isnull(C.OUT_MODE,0) OUT_MODE, " +
                        "       C.NAME,C.DISCHARGETYPE,C.FLAG,C.SEX_NAME,C.JSFS_NAME,C.TENDLEVEL,C.ORDER_BW,C.ORDER_BZ,yblx_name, A.Baby_ID," +
                        "       convert(char(41),A.INPATIENT_ID)+convert(char(11),A.Baby_ID)+convert(char(11),A.ISMYTS)  + convert(char(11),C.DEPT_ID) + convert(char(11),C.ISMY) + isnull(C.SEX_NAME,'未知')+'  '+c.hsj     AS STAG " +//+'  费用'+convert(char(15), dbo.FUN_ZY_SEEKPATFEEYE (A.INPATIENT_ID,0)) 
                        "  FROM ZY_BEDDICTION A left join ZY_BEDDICTION B on a.bf_id=b.bed_id" +
                        "  LEFT JOIN (select * from vi_ZY_vInpatient_Bed where WARD_ID='" + InstanceForm.BCurrentDept.WardId + "')  C ON C.INPATIENT_ID=A.INPATIENT_ID AND C.Baby_ID=A.Baby_ID " +
                        "  WHERE A.ISINUSE=0 and A.WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' ORDER BY " + px;// (select * from ZY_vInpatient_Bed where WARD_ID='" + InstanceForm.BCurrentDept.WardId +"') Modify By Tany 2005-01-23
                    DataTable BedTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    this.listView1.Items.Clear();

                    if (BedTb.Rows.Count == 0) return;
                    #region//add by zouchihua 增加临床路径图标
                    Cpgb = null;
                    GC.Collect();
                    Cpgb = new PictureBox[BedTb.Rows.Count];
                    this.listView1.Controls.Clear();
                    #endregion
                    #region//add by yaokx 2014-03-04 隔离标志
                    string cfg7185 = new SystemCfg(7185).Config.Trim();
                    string value = "";
                    if (cfg7185 != "")
                    {
                        string[] ss = cfg7185.Split(',');


                        for (int ii = 0; ii < ss.Length; ii++)
                        {
                            value += "'" + ss[ii] + "',";
                        }
                        value = value.Substring(0, value.Length - 1);
                    }
                    #endregion
                    for (int i = 0; i <= BedTb.Rows.Count - 1; i++)
                    {
                        DataRow BedRow = BedTb.Rows[i];//以前为床位为3位 ，现在改为5 modify by zouchihua 2012-6-1
                        S_Data = BedRow["BED_NO"].ToString().Trim();//直接取床位 //BedRow["BED_NO"].ToString().Trim().Length >= 5 ? BedRow["BED_NO"].ToString().Trim().Substring(0, 5) : BedRow["BED_NO"].ToString().Trim() + myFunc.Repeat_Space(5 - BedRow["BED_NO"].ToString().Trim().Length);
                        if (BedRow["ORDER_BW"].ToString().Trim() != "0" && BedRow["ORDER_BW"].ToString().Trim() != "") S_Data += "*";
                        if (BedRow["ORDER_BZ"].ToString().Trim() != "0" && BedRow["ORDER_BZ"].ToString().Trim() != "") S_Data += "△";
                        string gl = " ";
                        if (Convert.ToString(BedRow["INPATIENT_ID"]).Trim() != "" && value != "")
                        {
                            string strgl = "select * from zy_orderrecord where inpatient_id='" + BedRow["INPATIENT_ID"] + "' and delete_bit=0 and status_flag>=2 and status_flag<4 and HOITEM_ID in (" + value + ")";
                            DataTable dtgl = InstanceForm.BDatabase.GetDataTable(strgl);
                            if (dtgl != null)
                            {
                                if (dtgl.Rows.Count > 0)
                                {
                                    gl = " 隔离," + dtgl.Rows[0]["ORDER_CONTEXT"].ToString();
                                }
                            }
                        }

                        if (BedRow["Ismzlg"].ToString().Trim() == "1")
                        {
                            this.listView1.Items.Add(S_Data.Trim(), 71).Tag = Convert.ToString(BedRow["STAG"]) + gl;
                        }
                        else
                        {
                            if (Convert.ToString(BedRow["INPATIENT_ID"]).Trim() == "")
                            {
                                if (BedRow["ISBF"].ToString() == "1")
                                {
                                    S_Data += "\r\n" + "(" + BedRow["BF_NO"].ToString().Trim() + "床 包)";
                                }
                                try
                                {
                                    this.listView1.Items.Add(S_Data.Trim(), 0).Tag = Convert.ToString(BedRow["STAG"]);
                                }
                                catch { this.listView1.Items.Add(S_Data.Trim(), 71).Tag = Convert.ToString(BedRow["STAG"]) + gl; }
                            }
                            else
                            {
                                if (BedRow["DISCHARGETYPE"].ToString() == "1")
                                {
                                    if (cfg7145.Config.Trim() == "0")
                                        S_Data += "(" + BedRow["yblx_name"].ToString().Trim() + ")";   //医保	
                                    else
                                    {
                                        string str3 = " select * from zy_yb_shxx  where inpatient_id='" + BedRow["INPATIENT_ID"].ToString() + "' and ybjs_bit=0  and isnull(delete_bit,0)=0 ";
                                        DataTable table2 = InstanceForm.BDatabase.GetDataTable(str3);
                                        if (table2.Rows.Count != 0)
                                        {
                                            if (table2.Rows[0]["hs_shbz"].ToString() == "1")
                                            {
                                                if (table2.Rows[0]["RYSH"].ToString() == "1")
                                                {
                                                    S_Data = S_Data + "(√" + Convert.ToString(BedRow["yblx_name"]).Trim() + ")";
                                                }
                                                else
                                                {
                                                    S_Data = S_Data + "(×" + Convert.ToString(BedRow["yblx_name"]).Trim() + ")";
                                                }
                                            }
                                            else
                                            {
                                                S_Data = S_Data + "(" + BedRow["yblx_name"].ToString().Trim() + ")";   //医保	
                                            }
                                        }
                                        else
                                        {
                                            S_Data = S_Data + "(" + BedRow["yblx_name"].ToString().Trim() + ")";   //医保	
                                        }
                                    }
                                    //S_Data += "\r\n" + Convert.ToString(BedRow["NAME"]).Trim();
                                }
                                S_Data += "\r\n" + Convert.ToString(BedRow["NAME"]).Trim();
                                if (BedRow["ISBF"].ToString() == "1")
                                {
                                    S_Data += "(包)";
                                }

                                //							int m=0,n=0;					
                                //							if (BedRow["SEX_NAME"].ToString().Trim()=="男")
                                //								n=0;  //男
                                //							else
                                //								n=(BedRow["ISMYTS"].ToString()=="0"? 1:2);          //女或母婴
                                //					
                                //							if (BedRow["FLAG"].ToString() =="4")        //申请出院 						
                                //								this.listView1.Items.Add(S_Data.Trim(),n+1).Tag=Convert.ToString(BedRow["STAG"]);
                                //							else 
                                //							{
                                //								m=(Convert.ToString(BedRow["TENDLEVEL"]).Trim()==""?0:Convert.ToInt32(BedRow["TENDLEVEL"]));  // 护理级别
                                //								this.listView1.Items.Add(S_Data.Trim() ,n*5+m+4).Tag=Convert.ToString(BedRow["STAG"]);
                                //							}

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
                                        this.listView1.Items.Add(S_Data.Trim(), n).Tag = Convert.ToString(BedRow["STAG"]) + gl;
                                    }
                                    catch
                                    {
                                        this.listView1.Items.Add(S_Data.Trim(), 71).Tag = Convert.ToString(BedRow["STAG"]) + gl;
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
                                        this.listView1.Items.Add(S_Data.Trim(), n).Tag = Convert.ToString(BedRow["STAG"]) + gl;
                                    }
                                    catch
                                    {
                                        this.listView1.Items.Add(S_Data.Trim(), 71).Tag = Convert.ToString(BedRow["STAG"]) + gl;
                                    }
                                }
                            }
                        }
                        #region  //add by zouchihua 2012-11-01
                        string cpstatus = this.myFunc.GetCpzt(Convert.ToString(BedRow["INPATIENT_ID"]).Trim(), "0").ToString();
                        if (cpstatus.IndexOf("1") >= 0 || cpstatus.IndexOf("9") >= 0)
                        {
                            Cpgb[i] = new PictureBox();
                            if (cpstatus == "9")
                                Cpgb[i].Name = Convert.ToString(i) + "单病种";
                            Cpgb[i].Tag = i;
                            Cpgb[i].Size = new Size(20, 20);
                            //gb[i].MouseClick += new MouseEventHandler(Form3_MouseClick);
                            Cpgb[i].MouseEnter += new EventHandler(frmMain_MouseEnter1);
                            // Cpgb[i].MouseDoubleClick += new MouseEventHandler(frmMain_MouseDoubleClick1);
                            Cpgb[i].Location = new Point(this.listView1.Items[i].Position.X + this.listView1.LargeImageList.ImageSize.Width, this.listView1.Items[i].Position.Y + this.listView1.LargeImageList.ImageSize.Height - 15);
                            if (cpstatus == "15")
                                Cpgb[i].Image = this.ImgCp.Images[0];
                            else
                                if (cpstatus.Trim() == "9")
                                    Cpgb[i].Image = this.ImgCp.Images[2];
                                else
                                    Cpgb[i].Image = this.ImgCp.Images[1];
                            this.listView1.Controls.Add(Cpgb[i]);
                        }
                        #endregion

                    }
                }
                else if (bit == 1)
                {
                    int x = 9;
                    int y = 9;

                    panBed.Visible = true;
                    listView1.Visible = false;

                    //Modify by Tany 2005-02-24
                    //增加停用标志
                    sSql = @"SELECT A.ROOM_NO,A.BED_NO,A.INPATIENT_ID,A.ISBF,A.ISMYTS,A.BED_ID,c.inpatient_no," +
                        "       C.NAME,C.DISCHARGETYPE,C.FLAG,C.SEX_NAME,c.age,C.JSFS_NAME,C.TENDLEVEL,C.ORDER_BW,C.ORDER_BZ,dbo.fun_getdate(c.in_date) in_date,c.in_diagnosis,c.ryzd," +
                        "       convert(char(41),A.INPATIENT_ID)+convert(char(11),A.Baby_ID)+convert(char(11),A.ISMYTS)  + convert(char(11),C.DEPT_ID) + convert(char(11),C.ISMY) + isnull(C.SEX_NAME,'未知') AS STAG " +
                        "  FROM ZY_BEDDICTION A LEFT JOIN (select * from vi_ZY_vInpatient_Bed where WARD_ID='" + InstanceForm.BCurrentDept.WardId + "')  C ON C.INPATIENT_ID=A.INPATIENT_ID AND C.Baby_ID=A.Baby_ID " +
                        " WHERE A.ISINUSE=0 and A.WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' ORDER BY A.ROOM_NO,dbo.Fun_GetBedToOrder(A.BED_NO)";// (select * from ZY_vInpatient_Bed where WARD_ID='" + InstanceForm.BCurrentDept.WardId +"') Modify By Tany 2005-01-23
                    DataTable BedTb = InstanceForm.BDatabase.GetDataTable(sSql);

                    panBed.Controls.Clear();

                    stagArr = new string[BedTb.Rows.Count];

                    if (BedTb.Rows.Count == 0) return;

                    for (int i = 0; i <= BedTb.Rows.Count - 1; i++)
                    {
                        Button bt = new Button();

                        bt.AllowDrop = true;
                        bt.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(227)), ((System.Byte)(236)));
                        bt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                        bt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        bt.Size = new System.Drawing.Size(80, 105);
                        bt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                        bt.Location = new System.Drawing.Point(x, y);
                        bt.Name = "bt" + i.ToString();
                        bt.Paint += new System.Windows.Forms.PaintEventHandler(button_Paint);
                        bt.Click += new EventHandler(bt_Click);
                        //						bt.DoubleClick += new EventHandler(bt_DoubleClick);
                        bt.MouseDown += new MouseEventHandler(bt_MouseDown);
                        //						bt.MouseHover += new EventHandler(bt_Click);

                        if (x + 169 >= this.panBed.Width)
                        {
                            y = y + 114;
                            x = this.panBed.Location.X + 9;
                        }
                        else
                        {
                            x = x + 89;
                        }

                        int ll = 0;
                        //床号10位
                        if (BedTb.Rows[i]["bed_no"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["bed_no"].ToString().Trim().Length;
                            bt.Tag = BedTb.Rows[i]["bed_no"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["bed_no"].ToString().Trim().Substring(0, 10);
                        }
                        //姓名6位
                        if (BedTb.Rows[i]["name"].ToString().Trim().Length <= 6)
                        {
                            ll = 6 - BedTb.Rows[i]["name"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["name"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["name"].ToString().Trim().Substring(0, 6);
                        }
                        //性别2位
                        if (BedTb.Rows[i]["sex_name"].ToString().Trim().Length <= 2)
                        {
                            ll = 2 - BedTb.Rows[i]["sex_name"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["sex_name"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["sex_name"].ToString().Trim().Substring(0, 2);
                        }
                        //年龄3位
                        if (BedTb.Rows[i]["age"].ToString().Trim().Length <= 3)
                        {
                            ll = 3 - BedTb.Rows[i]["age"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["age"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["age"].ToString().Trim().Substring(0, 3);
                        }
                        //费用类别6位
                        if (BedTb.Rows[i]["jsfs_name"].ToString().Trim().Length <= 6)
                        {
                            ll = 6 - BedTb.Rows[i]["jsfs_name"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["jsfs_name"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["jsfs_name"].ToString().Trim().Substring(0, 6);
                        }
                        //住院号10位
                        if (BedTb.Rows[i]["inpatient_no"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["inpatient_no"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["inpatient_no"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["inpatient_no"].ToString().Trim().Substring(0, 10);
                        }
                        //病情10位
                        string s_bq = "";
                        if (BedTb.Rows[i]["order_bw"].ToString() != "0" && BedTb.Rows[i]["order_bw"].ToString() != "" && BedTb.Rows[i]["inpatient_no"].ToString() != "")
                            s_bq = s_bq + "*" + "病危";
                        if (BedTb.Rows[i]["order_bz"].ToString() != "0" && BedTb.Rows[i]["order_bz"].ToString() != "" && BedTb.Rows[i]["inpatient_no"].ToString() != "")
                            s_bq = s_bq + "△" + "病重";
                        if (s_bq.Length <= 10)
                        {
                            ll = 10 - s_bq.Length;
                            bt.Tag = bt.Tag + s_bq + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag += BedTb.Rows[i]["inpatient_no"].ToString().Trim().Substring(0, 10);
                        }
                        //护理10位
                        string s_hl = "";
                        switch (BedTb.Rows[i]["TENDLEVEL"].ToString())
                        {
                            case "4":
                                s_hl = "特级护理";
                                break;
                            case "3":
                                s_hl = "一级护理";
                                break;
                            case "2":
                                s_hl = "二级护理";
                                break;
                            case "1":
                                s_hl = "三级护理";
                                break;
                        }
                        if (s_hl.Length <= 10)
                        {
                            ll = 10 - s_hl.Length;
                            bt.Tag = bt.Tag + s_hl + Space(ll);
                        }
                        else
                        {
                            //bt.Tag = bt.Tag + BedTb.Rows[i]["in_diagnosis"].ToString().Trim().Substring(0, 10);
                            //Modify by Tany 2010-03-17 入院诊断名称
                            bt.Tag = bt.Tag + BedTb.Rows[i]["ryzd"].ToString().Trim().Substring(0, 10);
                        }
                        //诊断10位
                        if (BedTb.Rows[i]["ryzd"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["ryzd"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["ryzd"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["ryzd"].ToString().Trim().Substring(0, 10);
                        }
                        //入院时间10位
                        if (BedTb.Rows[i]["in_date"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["in_date"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["in_date"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["in_date"].ToString().Trim().Substring(0, 10);
                        }
                        //母婴同室6位
                        string s_myts = "";
                        if (BedTb.Rows[i]["ismyts"].ToString() == "1" && cfg7205.Config == "0")
                            s_myts = "(母婴同室)";
                        else
                            s_myts = Space(6);
                        bt.Tag = bt.Tag + s_myts;
                        //包房3位
                        string s_bf = "";
                        if (BedTb.Rows[i]["isbf"].ToString() == "1")
                            s_bf = "(包)";
                        else
                            s_bf = Space(3);
                        bt.Tag = bt.Tag + s_bf;
                        //出院状态6位
                        string s_cy = "";
                        if (BedTb.Rows[i]["FLAG"].ToString() == "6")
                            s_cy = "(申请出院)";
                        else
                            s_cy = Space(6);
                        bt.Tag = bt.Tag + s_cy;

                        this.toolTip1.SetToolTip(bt, "床        号：" + bt.Tag.ToString().Substring(0, 10).Trim() +
                            bt.Tag.ToString().Substring(77, 6).Trim() + bt.Tag.ToString().Substring(83, 3).Trim() + bt.Tag.ToString().Substring(86, 6).Trim() + "\n" +
                            "姓        名：" + bt.Tag.ToString().Substring(10, 6) + "\n" +
                            "性        别：" + bt.Tag.ToString().Substring(16, 2) + "\n" +
                            "年        龄：" + bt.Tag.ToString().Substring(18, 3) + "\n" +
                            "费用类别：" + bt.Tag.ToString().Substring(21, 6) + "\n" +
                            "住  院  号：" + bt.Tag.ToString().Substring(27, 10) + "\n" +
                            "病        情：" + bt.Tag.ToString().Substring(37, 10) + "\n" +
                            "护理级别：" + bt.Tag.ToString().Substring(47, 10) + "\n" +
                            "入院诊断：" + bt.Tag.ToString().Substring(57, 10) + "\n" +
                            "入院日期：" + bt.Tag.ToString().Substring(67, 10));

                        stagArr[i] = BedTb.Rows[i]["stag"].ToString();
                        panBed.Controls.Add(bt);

                    }
                }

                rtbMsg.Text = ShowMsgText();

            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PostMessage(this.listView1.Handle.ToInt32(), 0x020A, 0, 0);
        }
        void frmMain_MouseEnter1(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();

            t.Show(((sender as PictureBox).Name.IndexOf("单病种") >= 0 ? "该病人进入单病种管理" : "该病人进入临床路径！！"), this.listView1, (sender as PictureBox).Location.X + (sender as PictureBox).Height, (sender as PictureBox).Location.Y + 20, 1000);
        }

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
            if (cfg7205.Config == "1" && _ismy > 0)
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
            if (cfg7205.Config == "0")
            {
                if (_ismy > 0)
                {
                    _rtn = _type * 10 + 10;
                }
            }

            return _rtn;
        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count >= 1)
                {
                    string STAG = Convert.ToString(this.listView1.SelectedItems[0].Tag);
                    if ((STAG.Trim() != "") && (STAG != null))
                    {
                        ClassStatic.Current_BinID = new Guid(STAG.Substring(0, 41).Trim());
                        ClassStatic.Current_BabyID = Convert.ToInt64(STAG.Substring(41, 11).Trim());
                        ClassStatic.Current_isMYTS = Convert.ToInt16(STAG.Substring(52, 11).Trim());
                        ClassStatic.Current_DeptID = Convert.ToInt64(STAG.Substring(63, 11).Trim());
                        ClassStatic.Current_isMY = Convert.ToInt16(STAG.Substring(74, 11));
                        this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);

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
                            //try
                            //{ 
                            //    if (dr["order_ph"].ToString() != "0" && dr["order_ph"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                            //        s_bq = s_bq + " " + "陪护";
                            //}
                            //catch { }
                            msg += "病        情：" + s_bq + "\n";
                            msg += "护理级别：" + (dr["HLJB_NAME"].ToString().Trim().Length > 4 ? dr["HLJB_NAME"].ToString().Trim().Substring(0, 4) : dr["HLJB_NAME"].ToString().Trim()) + dr["order_ph"].ToString() + "\n";// //add by zouchihua 2013-8-1 增加陪护选择
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
                        ClassStatic.Current_BinID = Guid.Empty;
                        ClassStatic.Current_BabyID = 0;
                        ClassStatic.Current_DeptID = 0;
                        ClassStatic.Current_isMYTS = 0;
                        ClassStatic.Current_isMY = 0;

                        toolTip1.Hide(listView1);
                    }
                }
                else
                {
                    toolTip1.Hide(listView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            toolTip1.Hide(listView1);
            DragDropEffects dropEffect = listView1.DoDragDrop(e.Item, DragDropEffects.All | DragDropEffects.Link);
        }

        private void listView1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem dragItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                if (dragItem.ListView.Equals(listView1))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else if (e.Data.GetDataPresent(typeof(int)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        //
        private bool IsTimeRight(string dtRyrq)
        {
            try
            {
                string dtNow = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd");

                string ryrq = DateTime.Parse(dtRyrq).ToString("yyyy-MM-dd");

                return dtNow.Equals(ryrq);
            }
            catch { return false; }
        }

        private void listView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                #region 换床
                string sSql = "", sMsg = "";
                string old_bed_no, new_bed_no;
                long old_dept_id, new_dept_id;
                Guid old_bed_id, new_bed_id;

                //屏幕坐标的转换
                System.Drawing.Point p = new Point(e.X, e.Y);
                Point p1 = listView1.PointToClient(p);

                //得到当前的VIEWITEM
                System.Windows.Forms.ListViewItem new_item = listView1.GetItemAt(p1.X, p1.Y);
                System.Windows.Forms.ListViewItem old_item = listView1.SelectedItems[0];

                //如果VIEWITEM不为空，则执行转床处理
                if (new_item != null)
                {
                    if (new_item.Text == old_item.Text) return;

                    //i=old_item.Text.Trim().IndexOf("-",0,old_item.Text.Trim().Length);
                    //j=old_item.Text.Trim().IndexOf("\r",0,old_item.Text.Trim().Length);
                    //old_bed_no=old_item.Text.Trim().Substring(i+1,j-i-1);
                    if (old_item.Text.IndexOf("*") < 0)
                    {
                        if (old_item.Text.IndexOf("△") < 0)
                        {
                            if (old_item.Text.IndexOf("(") < 0)
                            {
                                // old_bed_no = old_item.Text.Trim().Substring(0, 4).Trim(); 固定取4位不行，取到换行符为止比较好 Modify BY Tany 2014-12-04
                                old_bed_no = old_item.Text.Trim().Substring(0, old_item.Text.IndexOf("\r")).Trim();//old_item.Text.Trim().Substring(0,1)=="加" + old_item.Text.Trim().Substring(0,1)=="家"?old_item.Text.Trim().Substring(0,3):old_item.Text.Trim().Substring(0,2);
                            }
                            else
                            {
                                old_bed_no = old_item.Text.Trim().Substring(0, old_item.Text.IndexOf("("));
                            }
                        }
                        else
                            old_bed_no = old_item.Text.Trim().Substring(0, old_item.Text.IndexOf("△"));
                    }
                    else
                        old_bed_no = old_item.Text.Trim().Substring(0, old_item.Text.IndexOf("*"));
                    sSql = "select bed_id,INPATIENT_ID,isbf,INPATIENT_dept,bedsex from ZY_BEDDICTION where isinuse=0 and WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' and bed_no='" + old_bed_no + "'";
                    DataTable old_tempTab = InstanceForm.BDatabase.GetDataTable(sSql);

                    #region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
                    string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(new Guid(old_tempTab.Rows[0]["INPATIENT_ID"].ToString()));

                    if (rtnSql[2] != "0")
                    {
                        MessageBox.Show("由于跨院特殊申请未完成，不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    #endregion
                    if (Convert.ToInt16(old_tempTab.Rows[0]["isbf"].ToString()) == 1)
                    {
                        MessageBox.Show(this, "对不起，包床不允许换床！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    old_bed_id = new Guid(old_tempTab.Rows[0]["bed_id"].ToString());
                    old_dept_id = Convert.ToInt32(old_tempTab.Rows[0]["INPATIENT_dept"]);

                    //i=new_item.Text.Trim().IndexOf("-",0,new_item.Text.Trim().Length);
                    //j=new_item.Text.Trim().IndexOf("\r",0,new_item.Text.Trim().Length);
                    //j=(j==-1?j=new_item.Text.Trim().Length:j);
                    //new_bed_no=new_item.Text.Trim().Substring(i+1,j-i-1);
                    new_bed_no = new_item.Text.Trim();//.Substring(0,1)=="加"?new_item.Text.Trim().Substring(0,3):new_item.Text.Trim().Substring(0,2);
                    sSql = "select bed_id,INPATIENT_ID,isbf,dept_id,room_no from ZY_BEDDICTION where isinuse=0 and WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' and bed_no='" + new_bed_no + "'";
                    DataTable new_tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (new_tempTab.Rows[0]["INPATIENT_ID"].ToString().Trim() != "")
                    {
                        MessageBox.Show(this, "对不起，目标床位不是空床！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Convert.ToInt16(new_tempTab.Rows[0]["isbf"].ToString()) == 1)
                    {
                        MessageBox.Show(this, "对不起，目标床位被包！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    new_bed_id = new Guid(new_tempTab.Rows[0]["bed_id"].ToString());
                    new_dept_id = Convert.ToInt32(new_tempTab.Rows[0]["dept_id"]);

                    //性别判断
                    sSql = @"select * from zy_BedDiction " +
                        " where ward_id='" + InstanceForm.BCurrentDept.WardId + "'" +
                        "   and room_no='" + new_tempTab.Rows[0]["room_no"].ToString().Trim() + "'" +
                        "   and inpatient_id is not null " +
                        "   and bedsex!='" + old_tempTab.Rows[0]["bedsex"].ToString() + "'";
                    DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (tempTab.Rows.Count > 0)
                    {
                        sMsg = "目标房间住有异性病人，";
                    }

                    if (new_dept_id != old_dept_id)
                    {
                        //if (MessageBox.Show(this, "两个床位的所属科室不相同，" + sMsg + "是否确认转床？", "转床", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                        //Modify By Tany 2016-11-21 不允许跨科室转床
                        MessageBox.Show(this, "目标床位属于【" + new Department(new_dept_id, InstanceForm.BDatabase).DeptName.Trim() + "】，当前病人属于【" + new Department(old_dept_id, InstanceForm.BDatabase).DeptName.Trim() + "】\r\n两个床位的所属科室不相同，不允许操作！", "转床", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        if (patientInfo1.IsShow)
                        {
                            if (MessageBox.Show(this, sMsg + "是否确认将 [" + old_bed_no + "床] 病人转到 [" + new_bed_no + "床] ？", "转床", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        else
                        {
                            patientInfo1.IsShow = true;
                            return;
                        }
                    }

                    string _outmsg = myFunc.ChangeBed("", 1, old_bed_id, new_bed_id, InstanceForm.BCurrentUser.EmployeeId, FrmMdiMain.Jgbm);

                    if (_outmsg.Trim() != "")
                    {
                        MessageBox.Show(_outmsg);
                    }

                    //刷新LISTVIEW
                    InitView(bit, 0);

                    //写日志 Add By Tany 2005-01-12
                    SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "转床", _outmsg + "把病人 " + ClassStatic.Current_BinID + " 从" + old_bed_id.ToString() + "床位代码转到" + new_bed_id.ToString() + "床位代码", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemLog.Save();
                    _systemLog = null;
                }
                #endregion
            }
            else if (e.Data.GetDataPresent(typeof(int)))
            {
                #region 分配床位
                //病人
                DataTable tb = (DataTable)this.dgvNewPatient.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }

                int nrow = (int)e.Data.GetData(typeof(int));
                Guid _inpatientid = new Guid(tb.Rows[nrow]["inpatient_id"].ToString());
                long _babyid = Convert.ToInt64(tb.Rows[nrow]["baby_id"].ToString());

                //Modify by jchl
                if (!IsTimeRight(tb.Rows[nrow]["入院日期"].ToString()))
                {
                    //如果分配床位日期和入院日期不相同
                    if (MessageBox.Show("分配床位操作日期 和 入院日期：" + tb.Rows[nrow]["入院日期"].ToString() + "不相同,是否继续", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                        return;
                }

                //重新刷新病人信息 Modify By Tany 2010-04-15
                string tSql = "select * from vi_zy_vinpatient where flag not in (2,6,10) and inpatient_id='" + _inpatientid + "' and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')";
                DataTable tTb = InstanceForm.BDatabase.GetDataTable(tSql);

                if (tTb == null || tTb.Rows.Count == 0)
                {
                    MessageBox.Show("对不起，该病人信息已经刷新，不再属于可操作范围，请核实！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btRefresh_Click(null, null);
                    return;
                }

                string name = tTb.Rows[0]["name"].ToString();
                long _deptid = Convert.ToInt64(tTb.Rows[0]["dept_id"].ToString());
                string _sex = tTb.Rows[0]["sex"].ToString();

                string sFlag = "";
                string sSql = "";
                string _outmsg = "";
                string new_bed_no = "";
                long new_dept_id = 0;
                int isPLUS = 0;
                string Room_NO = "";
                Guid new_bed_id = Guid.Empty;

                int isInput_ZD = 0;

                int isUpdate = 1;//Modify By Tany 拖床不自动更新床位费
                //int isUpdate = tb.Rows[nrow]["病人来源"].ToString().Trim() == "新入院" ? 0 : 1;
                int isTmpIn = 1;//0=临时入住 状态4，1=入住 状态3

                //屏幕坐标的转换
                System.Drawing.Point p = new Point(e.X, e.Y);
                Point p1 = listView1.PointToClient(p);

                //得到当前的VIEWITEM
                System.Windows.Forms.ListViewItem new_item = listView1.GetItemAt(p1.X, p1.Y);

                //如果VIEWITEM不为空，则执行分床处理
                if (new_item != null)
                {
                    new_bed_no = new_item.Text.Trim();//.Substring(0,1)=="加"?new_item.Text.Trim().Substring(0,3):new_item.Text.Trim().Substring(0,2);
                    sSql = "select bed_id,INPATIENT_ID,isbf,dept_id,room_no,isPLUS from ZY_BEDDICTION where isinuse=0 and WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' and bed_no='" + new_bed_no + "'";
                    DataTable new_tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (new_tempTab.Rows[0]["INPATIENT_ID"].ToString().Trim() != "")
                    {
                        MessageBox.Show(this, "对不起，目标床位不是空床！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Convert.ToInt16(new_tempTab.Rows[0]["isbf"].ToString()) == 1)
                    {
                        MessageBox.Show(this, "对不起，目标床位被包！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    new_bed_id = new Guid(new_tempTab.Rows[0]["bed_id"].ToString());
                    new_dept_id = Convert.ToInt32(new_tempTab.Rows[0]["dept_id"]);
                    isPLUS = Convert.ToInt32(new_tempTab.Rows[0]["isPLUS"]);
                    Room_NO = new_tempTab.Rows[0]["Room_NO"].ToString();

                    //床位有效性判断
                    //Add By Tany 2005-02-24
                    string isInuse = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select isinuse from zy_beddiction where bed_id='" + new_bed_id + "'"), "");
                    if (isInuse == "1")
                    {
                        MessageBox.Show("该张床位已经被停用，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitView(bit, 0);
                        ShowNewPatient();
                        return;
                    }

                    if (_babyid > 0 && cfg7205.Config == "0")//isCK && Modify By Tany 2011-03-07 所有的婴儿都不能单独分床
                    {
                        //if(MessageBox.Show(this, "确认为该婴儿单独分配床位吗？", "确认", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) 
                        MessageBox.Show(this, "婴儿不能单独分配床位，请进入分配床位功能菜单后选择母婴同室！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (_babyid > 0 && cfg7205.Config == "1")
                    {
                        MessageBox.Show(this, "附加病人不能单独分配床位，请进入分配床位功能菜单后选择病人同室！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (MessageBox.Show(this, "是否确认将 " + name + " 病人分配到 " + new_bed_no + " 号床？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;

                    //修改床位费判断方式 Modify By Tany 2010-04-26

                    //Modify by jchl
                    //if (cbCWF.Checked)
                    //if (cfg7600.Config.Trim().Equals("1"))
                    {
                        //床位费HOITEM_ID
                        //SystemCfg cfg = new SystemCfg(7024);
                        //string _hoitemID = cfg.Config;
                        //if (_hoitemID.Trim() == "") _hoitemID = "0";
                        //看是否还有未停止的床位账单
                        sSql = @"select 1 from zy_orderrecord where inpatient_id='" + _inpatientid + "'" +
                            " and baby_id=" + _babyid + " and mngtype=2 and status_flag=2 " +
                            " and delete_bit=0 and hoitem_id in (select order_id from jc_hsitemdiction a  " +
                            " inner join jc_hoi_hdi b on a.item_id=b.hditem_id " +
                            " inner join jc_hoitemdiction c on b.hoitem_id=c.order_id " +
                            " where a.statitem_code in (" + new SystemCfg(7029).Config + "))";//Modify by Tany 2010-11-26 床位费大项目代码可能有多个
                        DataTable tmpbedTb = InstanceForm.BDatabase.GetDataTable(sSql);

                        if (tmpbedTb.Rows.Count > 0)
                        {
                            if (MessageBox.Show(this, "病人有未停止的床位费长期账单，是否还要自动生成床位费长期账单？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                isInput_ZD = 1;
                            }
                        }
                    }

                    //科室一致性判断,加床例外
                    if ((new_dept_id != _deptid) && (isPLUS == 0))
                    {
                        if (MessageBox.Show(this, "病人科室与床位科室不一致，是否确认分配？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }

                    //同一房间性别判断
                    string s = _sex.Trim();
                    if (s != "") s = (s == "男" ? "女" : "男");
                    sSql = @"select * from zy_BedDiction " +
                        " where ward_id='" + InstanceForm.BCurrentDept.WardId + "'" +
                        "   and room_no='" + Room_NO + "'" +
                        "   and bedsex='" + s + "'";
                    DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (tempTab.Rows.Count > 0)
                    {
                        if (MessageBox.Show(this, "该房间住有" + s + "性病人，是否确认分配？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }

                    //再次判断病人状态是否属于正常 Add By Tany 2005-04-26
                    sSql = "select flag from vi_zy_vinpatient_info where inpatient_id='" + _inpatientid + "' and baby_id=" + _babyid + " and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')";
                    DataTable patTb = InstanceForm.BDatabase.GetDataTable(sSql);

                    if (patTb == null || patTb.Rows.Count == 0)
                    {
                        MessageBox.Show("对不起，没有找到病人信息，不能进行操作！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitView(bit, 0);
                        ShowNewPatient();
                        return;
                    }
                    else
                    {
                        sFlag = patTb.Rows[0][0].ToString().Trim();//Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select flag from vi_zy_vinpatient_all where inpatient_id="+ClassStatic.Current_BinID+" and baby_id="+ClassStatic.Current_BabyID).ToString(),"");
                        if (sFlag == "2" || sFlag == "6" || sFlag == "10")
                        {
                            MessageBox.Show("对不起，病人已经结算或者信息被删除，不能进行操作！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            InitView(bit, 0);
                            ShowNewPatient();
                            return;
                        }
                    }

                    //模式1为不包房分配床位
                    _outmsg = myFunc.AssignBed("", 1, new_bed_id, _deptid, _inpatientid, _babyid, _sex, Room_NO, 0, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), InstanceForm.BCurrentUser.EmployeeId, isInput_ZD, isUpdate, isTmpIn, FrmMdiMain.Jgbm);

                    string OperType = "分配床位";

                    //写日志 Add By Tany 2005-01-12
                    SystemLog _systemLog = new SystemLog(-1, Convert.ToInt64(ClassStatic.Current_DeptID), InstanceForm.BCurrentUser.EmployeeId, OperType, _outmsg + "将 " + name + " 病人分配到 " + new_bed_no + " 号床", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemLog.Save();
                    _systemLog = null;

                    if (_outmsg.Trim() != "")
                    {
                        MessageBox.Show(_outmsg);
                    }
                    else
                    {
                        MessageBox.Show("分配床位成功！");
                    }

                    //刷新LISTVIEW
                    InitView(bit, 0);
                    ShowNewPatient();
                }
                #endregion
            }
        }

        #region 老菜单事件
        private void mn1分配床位_Click(object sender, System.EventArgs e)
        {
            //			int i=0;
            //			string sName="", sSql="";
            //			bool isCheckEmpty=false;	//病区内是否没有一个病人
            //			bool isInput=false;			//是否是输入医嘱
            //			bool isBC=false;            //是否是包床或取消包床
            //			bool isCheckSelect=false;	//是否选中病人
            //			bool isShow=true;			//是否显示窗体
            //			bool isRefresh=true;		//是否刷新listview
            //			
            //			System.Type tp=sender.GetType();
            //			switch (tp.ToString())
            //			{
            //				case "System.Windows.Forms.MenuItem":
            //					MenuItem mn=(MenuItem) sender;
            //					i=mn.Text.Trim().Length<4?mn.Text.Trim().Length:4;
            //					sName=mn.Text.Trim().Substring(0,i);
            //					break;
            //				case "System.Windows.Forms.Button":
            //					Button bt=(Button) sender;
            //					//i=bt.Text.Trim().Length<4?bt.Text.Trim().Length:4;
            //					sName=bt.Text.Trim();//.Substring(0,i);
            //					break;	
            //				case "System.Windows.Forms.ListView":
            //					if(mn3医嘱查询.Visible)
            //						sName="医嘱查询";
            //					else
            //						return;
            //					break;
            //			}
            //			
            //			System.Windows.Forms.Form f1=new Form();
            //			switch (sName.Trim())
            //			{
            //				#region 床位管理
            //				case "分配床位":
            //					f1=new frmFPCW();					
            //					//f1=new Form1();				
            //					break;
            //				case "刷新床位":					
            //					isShow=false;					
            //					break;
            ////				case "包房":
            ////					isCheckSelect=true;
            ////					isShow=false;
            ////					break;
            ////				case "取消包房":
            ////					isCheckSelect=true;
            ////					isShow=false;
            ////					break;
            //				case "包床":
            //					isCheckSelect=true;
            //					isShow=false;
            //					isBC=true;
            //					break;
            //				case "取消包床":
            //					isCheckSelect=true;
            //					isShow=false;
            //					isBC=true;
            //					break;
            //				case "床位属性":
            //					f1=new frmCWSX();					
            //					break;
            //				#endregion
            //				
            //				#region 病人管理
            //				case "病人信息":
            //					isCheckSelect=true;
            //					f1=new frmPatientInfo();
            //					break;
            //				case "病人一览":
            //					isCheckSelect=false;
            //					f1=new frmAllPatientInfo();
            //					break;
            //				case "修改信息":
            //					isCheckSelect=true;
            //					f1=new frmXGXX();
            //					break;
            //				case "查找病人":
            //					f1=new frmCZBR();
            //					break;
            //				case "分娩":
            //					if(this.listView1.SelectedItems.Count<1 + this.listView1.SelectedItems[0].Tag==null + this.listView1.SelectedItems[0].Tag.ToString()=="") 
            //					{
            //						MessageBox.Show(this,"请选择一个病人！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //						return;
            //					}
            //					if (this.listView1.SelectedItems[0].Tag.ToString().Substring(55,1)!="女")
            //					{
            //						MessageBox.Show(this,"对不起，您选择的病人必须是女性！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            //						return;
            //					}
            //					if (Convert.ToInt16(ClassStatic.Current_BabyID)>0)
            //					{
            //						MessageBox.Show(this,"对不起，您选择的病人是婴儿！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            //						return;
            //					}
            //					f1=new frmFM();
            //					break;
            //				case "转科":					
            //					f1=new frmZK();
            //					break;
            //				case "定义出院":					
            //					f1=new frmDYCY();
            //					break;
            //				#endregion
            //
            //				#region 医嘱管理
            //				case "医嘱查询":
            //					isCheckEmpty=true;
            //					f1=new frmYZGL();
            //					break;
            //				case "未发送医":
            //					isCheckEmpty=true;
            //					f1=new frmYZCX();
            //					break;
            //				case "未处理项":
            //					isCheckSelect=true;
            //					frmWzxxm fwzx=new frmWzxxm();
            //					fwzx.v_inpatinet_id=ClassStatic.Current_BinID;
            //					fwzx.v_baby_id=Convert.ToDecimal(ClassStatic.Current_BabyID);
            //					fwzx.ShowDialog();
            //					fwzx.Dispose();
            //					return;
            //                 case "医嘱转抄":
            //					 if (this.isNotEmpty==false)
            //					 {
            //						 MessageBox.Show(this,"本病区暂没有病人", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //						 return;
            //					 }
            //					 frmYZZC fmYZZC=new frmYZZC();
            //					 fmYZZC.Kind=1;
            //					 fmYZZC.ShowDialog();
            //					 fmYZZC.Dispose();	
            //					 isShow=false;
            //					 break;
            //				case "医嘱核对":
            //					if (this.isNotEmpty==false)
            //					{
            //						MessageBox.Show(this,"本病区暂没有病人", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //						return;
            //					}
            //					frmYZZC fmYZZC1=new frmYZZC();
            //					fmYZZC1.Kind=3;
            //					fmYZZC1.ShowDialog();
            //					fmYZZC1.Dispose();	
            //					isShow=false;
            //					break;	
            //				case "医嘱查对":
            //					if (this.isNotEmpty==false)
            //					{
            //						MessageBox.Show(this,"本病区暂没有病人", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //						return;
            //					}
            //					frmYZZC fmYZZC2=new frmYZZC();
            //					fmYZZC2.Kind=5;
            //					fmYZZC2.ShowDialog();
            //					fmYZZC2.Dispose();	
            //					isShow=false;
            //					break;
            //				case "账单输入":
            //					isCheckEmpty=true;
            //					isInput=true;
            //					isShow=false;
            //					break;
            //				case "介入账单":
            //					isCheckEmpty=true;
            //					isInput=true;
            //					isShow=false;
            //					break;
            //				case "模板查询":
            //					frmYZModel fm=new frmYZModel();
            //					fm.MngType=0;		
            //					fm.ShowDialog();
            //					fm.Dispose();	
            //					isShow=false;
            //					break;
            //				#endregion
            //
            //				#region 执行
            //				case "医嘱发送":
            //					isCheckEmpty=true;
            //					f1=new frmExecOrders();
            //					break;
            //				case "药品信息":
            //					f1=new frmYPXX();
            //					break;
            //				case "基数药品":
            //					f1=new frmJSYTJ();
            //					break;
            //				case "交病人药":					
            //					frmHydprt fh = new frmHydprt();	
            //					fh.sType="交病人药品打印";
            //					fh.ShowDialog();
            //					fh.Dispose();
            //					return;	
            //				case "费用信息":
            //					isCheckEmpty=true;
            //					f1=new frmDJDY();			
            //					break;		
            //				case "执行单":
            //					isCheckEmpty=true;
            //					f1=new frmZXD();			
            //					break;
            //				case "化验单打":					
            //					f1=new frmHydprt();			
            //					break;
            //				case "取消医技":					
            //					f1=new frmCancel();			
            //					break;
            //				#endregion
            //
            //				#region 护理文书
            //				case "入院评估":
            //					isCheckSelect=true;
            //					f1=new frmHLPG();
            //					break;
            //				case "一般患者":
            //					isCheckSelect=true;
            //					frmYBHZ fy=new frmYBHZ();
            //					fy.Show_Date(ClassStatic.Current_BinID,Convert.ToDecimal(ClassStatic.Current_BabyID));
            //					fy.ShowDialog();
            //					fy.Dispose();
            //					return;
            //				case "危重患者":
            //					isCheckSelect=true;
            //					frmWZHZ fw=new frmWZHZ();
            //					fw.Show_Date(ClassStatic.Current_BinID,Convert.ToDecimal(ClassStatic.Current_BabyID));
            //					fw.ShowDialog();
            //					fw.Dispose();
            //					return;
            ////				case "旧三测单":
            ////					isCheckSelect=true;
            ////					f1=new frmSCD0();
            ////					break;
            //				case "三测单":
            //				case "三 测 单":
            //					isCheckSelect=true;
            //					f1=new Frmscd();
            //					break;
            //				case "四测记录":
            //					isCheckSelect=true;
            //					f1=new frmSCD1();
            //					break;
            //				case "交班记录":
            ////					isCheckSelect=true;
            //					f1=new  frmJBJL();
            //					break;
            //				#endregion
            //
            //				#region 护理管理
            //				case "护士排班":
            //					f1=new  frmHSPB();
            //					break;
            //				case "统计护士":
            //					f1=new  frmReptPbgzl();
            //					break;
            //				case "医生排班":
            //					f1=new  frmYSPB();
            //					break;				
            //				case "护理工作":
            //					//
            //					break;
            //				#endregion
            //				
            //				#region 综合统计
            //				case "床日统计":
            //					f1=new frmCRTJ();
            //					break;
            //				case "病区工作":
            //					f1=new frmWardGzrz();
            //					break;
            //				case "科室收入":
            //					f1=new frmSRTJ();
            //					break;
            //				case "病区考勤":
            //					f1=new frmReptPbgzl();
            //					break;
            //				case "病区科室":
            //					f1=new frmWarddeptSR();
            //					break;
            //				#endregion
            //                
            //				#region 系统
            //				case"用法与附":
            //					f1=new frmAddFee();
            //					isRefresh=false;
            //					break;
            //				case"科室基数":
            //					f1=new frmJSY();
            //					isRefresh=false;
            //					break;
            //				case"项目查询":
            //					f1=new frmxmcx();
            //					isRefresh=false;
            //					break;
            //				case"重新登录":
            //					frmLogin flg1=new frmLogin();
            //					flg1.ShowDialog();
            //					if (flg1.LoginOK==false) 
            //					{
            //						this.Close();						
            //					}
            //					this.frmCWYL_Load(sender,e);
            //					return;
            //				case "更改密码":
            //					f1=new DlgChgPWD();
            //					isRefresh=false;
            //					break;
            //				case "退出系统":
            //					Application.Exit();
            //					return;
            //				#endregion
            //					
            //				default:
            //					MessageBox.Show(this,"对不起，此功能正在建设中....", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning); 
            //					return;
            //			}			
            //
            //			// 检查病区内是否没有一个病人
            //			if (isCheckEmpty || isCheckSelect ) 
            //			{
            //				if (this.isNotEmpty==false)
            //				{
            //					MessageBox.Show(this,"本病区暂没有病人", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //					return;
            //				}
            //			}
            //
            //
            //			#region 是否是输入医嘱
            //			if (isInput) 
            //			{
            //				frmYZLR fy=new frmYZLR();
            //				frmJRYZLR fj=new frmJRYZLR();
            //
            //				if(SelectDataView==null)
            //				{
            //					//frmLoading fw=new frmLoading();
            //					//fw.Show();
            //					//fw.Update();
            //
            //					//事先取出数据放置到DATAVIEW中去					
            ////					DataTable myTb=myFunc.GetSelCard("","",1);
            //					//只显示8，9的，并且显示执行科室 Modify By Tany 2005-05-22
            //					sSql=@"SELECT AA.拼音码 ,AA.医嘱内容 as 内容, AA.单位,AA.单价,1 as 剂量,"+
            ////						  "       CAST(CAST(ORDER_ID AS INT) AS CHARACTER(10) ) AS 医嘱编号,Hoicode as 标准码,AA.BZ as 备注,Order_Type as type,iscomplex,zxdd_id AS exec_dept,seekdeptname(zxdd_id) 执行科室"+   //Modify By Tany 2005-06-13 从jc_HOItemDiction取执行科室
            //						  "       CAST(CAST(ORDER_ID AS INT) AS CHARACTER(10) ) AS 医嘱编号,Hoicode as 标准码,AA.BZ as 备注,Order_Type as type,iscomplex,default_dept AS exec_dept,seekdeptname(default_dept) 执行科室"+
            //						  "  FROM (SELECT  a.order_name as 医嘱内容,order_unit as 单位,retail_price as 单价,a.py_code as 拼音码,"+
            //						  "                default_dept,a.bz,a.ORDER_ID,a.Order_Type,a.Hoicode,c.iscomplex,zxdd_id"+
            //						  "          FROM  jc_HOItemDiction a,jc_HOI_HDI b,jc_HSItemDiction c "+
            //		                  "         WHERE a.ORDER_ID=b.Hoitem_id and c.item_id=b.Hditem_id and a.delete_bit=0 and a.Order_Type IN (8, 9))  AS AA ";
            //						 // "ORDER BY Order_Type "; 
            //					DataTable myTb=InstanceForm.BDatabase.GetDataTable(sSql);
            //					myTb.TableName="ORDERQUERY";				
            //					SelectDataView=new DataView();
            //					SelectDataView.Table=myTb;
            //					//fw.Close();
            //				}
            //
            //				switch (sName.Trim())
            //				{
            //					case "账单输入":
            //						fy.SelectDataView=this.SelectDataView;				
            //						fy.ShowDialog();
            //						break;
            //					case "介入账单":
            //						fj.SelectDataView=this.SelectDataView;				
            //						fj.ShowDialog();
            //						break;
            //				}
            //
            //				fy.Dispose();
            //				fj.Dispose();
            //			}
            //			#endregion
            //
            //
            //			//检查是否选中病人,
            //			if (isCheckSelect) 
            //			{
            ////				if(listView1.Visible)
            ////				{
            ////					if(this.listView1.SelectedItems.Count<1 || this.listView1.SelectedItems[0].Tag==null || this.listView1.SelectedItems[0].Tag.ToString()=="") 
            ////					{
            ////						MessageBox.Show(this,"请选择一个病人！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            ////						return;
            ////					}
            ////				}
            ////				else
            ////				{
            //					//不判断是否有点击事件，只管有没有病人信息
            //					//Modify By Tany 2004-10-28
            //					if(ClassStatic.Current_BinID=="0" || ClassStatic.Current_BinID==null)
            //					{
            //						MessageBox.Show(this,"请选择一个病人！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //						return;
            //					}
            ////				}
            //			}
            //
            //			//是否显示窗体
            //			if (isShow) 
            //			{
            //				f1.ShowDialog();
            //				f1.Dispose();	
            //			}
            //			else
            //			{
            //				if (isBC)
            //				{
            //					frmBC fmBC=new frmBC();
            //					fmBC.isBC=sName=="包床"?true:false;
            //					fmBC.ShowDialog();
            //					fmBC.Dispose();
            //				}
            //
            //				#region 此功能暂屏蔽  包房与取消包房
            //				switch (sName)
            //				{
            //					case "包房":
            //						#region 包房
            //						sSql=@"select bed_id,ISBF,ROOM_NO from zy_BedDiction "+
            //							" where ward_id='"+ InstanceForm.BCurrentDept.WardId + "'" +
            //							"   and inpatient_id="+ClassStatic.Current_BinID+" and baby_id="+ClassStatic.Current_BabyID;
            //						DataTable tempTab1=InstanceForm.BDatabase.GetDataTable(sSql);					
            //						if (Convert.ToInt16(tempTab1.Rows[0]["ISBF"])==1)
            //						{
            //							MessageBox.Show(this,"对不起，该房间已经被包！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            //							return;
            //						}
            //
            //						sSql=@"select * from zy_BedDiction "+
            //							" where ward_id='"+ InstanceForm.BCurrentDept.WardId + "'" +
            //							"   and room_no='"+tempTab1.Rows[0]["ROOM_NO"].ToString()+"'"+
            //							"   and inpatient_id!="+ ClassStatic.Current_BinID +
            //							"   and inpatient_id is not null ";
            //						DataTable tempTab2=InstanceForm.BDatabase.GetDataTable(sSql);
            //						if (tempTab2.Rows.Count>0)
            //						{
            //							MessageBox.Show(this,"对不起，该房间已住人，不允许包房！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            //							return;
            //						}
            //
            //						if(MessageBox.Show(this, "确认包房吗？", "确认", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return;				
            //						myFunc.ChangeBed("",3,Convert.ToInt32(tempTab1.Rows[0]["bed_id"]),0,InstanceForm.BCurrentUser.EmployeeId );
            //						break;
            //						#endregion
            //					case "取消包房":
            //						#region 取消包房
            //						sSql=@"select bed_id,ISBF,ROOM_NO from zy_BedDiction "+
            //							" where ward_id='"+ InstanceForm.BCurrentDept.WardId + "'" +
            //							"   and inpatient_id="+ClassStatic.Current_BinID+" and baby_id="+ClassStatic.Current_BabyID;
            //						DataTable tempTab3=InstanceForm.BDatabase.GetDataTable(sSql);					
            //						if (Convert.ToInt16(tempTab3.Rows[0]["ISBF"])==0)
            //						{
            //							MessageBox.Show(this,"对不起，该房间没有被包！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            //							return;
            //						}
            //
            //						if(MessageBox.Show(this, "确认取消包房吗？", "确认", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return;				
            //						myFunc.ChangeBed("",4,Convert.ToInt32(tempTab3.Rows[0]["bed_id"]),0,InstanceForm.BCurrentUser.EmployeeId );
            //						break;			
            //						#endregion					
            //				}
            //				#endregion
            //			}
            //
            //			//是否刷新listview
            //			if (isRefresh) InitView(bit);
        }
        #endregion

        private void viewType_Click(object sender, System.EventArgs e)
        {
            MenuItem mi = new MenuItem();
            mi = (MenuItem)sender;

            if (mi.Text == "图标") bit = 0;
            else bit = 1;

            InitView(bit, 0);
        }

        private void button_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Button bt = (Button)sender;

            //横线
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 15, bt.Width, 15);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 30, bt.Width, 30);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 45, bt.Width, 45);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 60, bt.Width, 60);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 75, bt.Width, 75);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 90, bt.Width, 90);

            //竖线
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 40, 0, 40, 30);
            //e.Graphics.DrawLine(System.Drawing.Pens.Black,80,0,80,20);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 20, 15, 20, 30);
            //e.Graphics.DrawLine(System.Drawing.Pens.Black,60,20,60,40);

            //病人信息
            bedno = bt.Tag.ToString().Substring(0, 10);
            name = bt.Tag.ToString().Substring(10, 6);
            sex = bt.Tag.ToString().Substring(16, 2);
            age = bt.Tag.ToString().Substring(18, 3);
            fb = bt.Tag.ToString().Substring(21, 6);
            zyh = bt.Tag.ToString().Substring(27, 10);
            bq = bt.Tag.ToString().Substring(37, 10);
            tend = bt.Tag.ToString().Substring(47, 10);
            zd = bt.Tag.ToString().Substring(57, 10);
            ryrq = bt.Tag.ToString().Substring(67, 10);
            if (bt.Tag.ToString().Substring(83, 3).Trim() != "" && name.Trim() == "")
                bc = bt.Tag.ToString().Substring(83, 3).Trim();
            else
                bc = "";
            e.Graphics.DrawString(bedno.Trim() + bc, bt.Font, Brushes.Red, 2, 2);
            e.Graphics.DrawString(name, bt.Font, Brushes.MidnightBlue, 41, 2);
            e.Graphics.DrawString(sex, bt.Font, Brushes.MidnightBlue, 2, 17);
            e.Graphics.DrawString(age, bt.Font, Brushes.MidnightBlue, 22, 17);
            e.Graphics.DrawString(fb, bt.Font, Brushes.MidnightBlue, 41, 17);
            e.Graphics.DrawString(zyh, bt.Font, Brushes.MidnightBlue, 2, 32);
            e.Graphics.DrawString(bq, bt.Font, Brushes.Red, 2, 47);
            e.Graphics.DrawString(tend, bt.Font, Brushes.MidnightBlue, 2, 62);
            e.Graphics.DrawString(zd, bt.Font, Brushes.MidnightBlue, 2, 77);
            e.Graphics.DrawString(ryrq, bt.Font, Brushes.MidnightBlue, 2, 92);
        }

        private string Space(int len)
        {
            string space = "";
            if (len > 0)
            {
                for (int i = 1; i <= len; i++)
                {
                    space += " ";
                }
            }
            return space;
        }

        private void bt_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int ii = Convert.ToInt32(bt.Name.Substring(2));

            if ((stagArr[ii].Trim() != "") && (stagArr[ii] != null))
            {
                ClassStatic.Current_BinID = new Guid(stagArr[ii].Substring(0, 41).Trim());
                ClassStatic.Current_BabyID = Convert.ToInt64(stagArr[ii].Substring(41, 11).Trim());
                ClassStatic.Current_isMYTS = Convert.ToInt16(stagArr[ii].Substring(52, 11).Trim());
                ClassStatic.Current_DeptID = Convert.ToInt64(stagArr[ii].Substring(63, 11).Trim());
                ClassStatic.Current_isMY = Convert.ToInt16(stagArr[ii].Substring(74, 11));
                this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);
            }
            else
            {
                this.patientInfo1.ClearInpatientInfo();
                ClassStatic.Current_BinID = Guid.Empty;
                ClassStatic.Current_BabyID = 0;
                ClassStatic.Current_DeptID = 0;
                ClassStatic.Current_isMYTS = 0;
                ClassStatic.Current_isMY = 0;
            }


        }

        private void bt_MouseDown(object sender, MouseEventArgs e)
        {
            bt_Click(sender, e);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            //mtype 0=全部系统 1=护士 2=医生
            DataTable msgTb = new DataTable();
            string sSql = "";
            DateTime NowTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            rtbMsg.Text = "";
            sSql = "select distinct a.id,bdate,title from zy_message a inner join zy_message_dept b on a.id=b.p_id"
                + " where '" + NowTime + "' between a.bdate and a.edate and mtype in (0,1) and level=1"//只显示系统级消息 Modify By Tany 2005-03-14
                + " and (b.dept_id=0 or b.dept_id in (SELECT DEPT_ID FROM JC_WARDRDEPT WHERE WARD_ID='" + InstanceForm.BCurrentDept.WardId + "'))";
            msgTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (msgTb == null || msgTb.Rows.Count == 0)
                return;

            for (int i = 0; i < msgTb.Rows.Count; i++)
            {
                rtbMsg.Text += "【" + msgTb.Rows[i]["id"].ToString().Trim() + "】" + msgTb.Rows[i]["bdate"].ToString().Trim() + "  " + msgTb.Rows[i]["title"].ToString().Trim() + "\n";
            }

            rtbMsg.Focus();
            rtbMsg.Select(rtbMsg.TextLength, 0);
            rtbMsg.ScrollToCaret();
        }

        private void rtbMsg_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            //			frmMsg fm = new frmMsg();
            //			fm.MsgId=e.LinkText;
            //			fm.ShowDialog();
            //			fm.Dispose();
        }

        private void mnuRefrashBed_Click(object sender, System.EventArgs e)
        {
            InitView(bit, 0);
        }

        private void mnuOrderPrt_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_yzdy", "Fun_ts_zyhs_yzdy", "医嘱打印", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuBCorQXBC_Click(object sender, System.EventArgs e)
        {
            //不判断是否有点击事件，只管有没有病人信息
            //Modify By Tany 2004-10-28
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MenuItem mn = (MenuItem)sender;
            string mnName = mn.Text.Trim();

            frmBC frmBc = null;
            bool _isBC = true;

            if (mnName == "包床")
                _isBC = true;
            else
                _isBC = false;

            frmBc = new frmBC(_isBC);
            frmBc.ShowDialog();
            frmBc.Dispose();

            InitView(bit, 0);
        }

        private void mnuFM_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (cfg7205.Config == "0")
                {
                    if (this.listView1.SelectedItems[0].Tag.ToString().Substring(85, 1) != "女")
                    {
                        MessageBox.Show(this, "对不起，您选择的病人必须是女性！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(this, "对不起，请点击一个病人！" + "\n" + this.listView1.SelectedItems[0].Tag.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt16(ClassStatic.Current_BabyID) > 0)
            {
                MessageBox.Show(this, "对不起，您选择的病人是婴儿！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmFM frmFm = new frmFM();
            frmFm.ShowDialog();
            frmFm.Dispose();

            InitView(bit, 0);
        }

        private void mnuOrderQuery_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_yzgl", "Fun_ts_zyhs_yzgl", "医嘱管理", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuOrder_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string docSql = "select zy_doc from zy_inpatient a inner join JC_ROLE_DOCTOR b on a.zy_doc=b.employee_id where a.inpatient_id='" + ClassStatic.Current_BinID + "'";
            DataTable docTb = InstanceForm.BDatabase.GetDataTable(docSql);

            if (docTb == null || docTb.Rows.Count == 0)
            {
                MessageBox.Show("该病人没有分配管床医生，请先分配管床医生后再进行医嘱录入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (openform(ClassStatic.Current_BinID) == true)
            {
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
                return;
            }

            object[] communicateValue = new object[7];
            communicateValue[0] = ClassStatic.Current_BinID;
            communicateValue[1] = InstanceForm.BCurrentDept.WardId;
            communicateValue[2] = ClassStatic.Current_DeptID;
            communicateValue[3] = listView1.SelectedItems[0].Tag;
            communicateValue[4] = myFunc.OutFlag(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
            communicateValue[5] = 1;
            communicateValue[6] = InstanceForm.BCurrentDept.WardDeptId;

            GetForm("ts_zyys_yzgl", "Fun_Ts_zyys_hsyz", "医嘱录入", InstanceForm.BCurrentUser.UserID, InstanceForm.BCurrentDept.DeptId, communicateValue, true);
        }

        private void mnuOrderZC_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_yzzc", "Fun_ts_zyhs_yzzc", "医嘱转抄", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuZDLR_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_zdlr", "Fun_ts_zyhs_zdlr", "帐单录入", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuFYXX_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_fyxx", "Fun_ts_zyhs_fyxx", "病人费用查询", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuYPXX_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_ypxx", "Fun_ts_zyhs_ypxx", "药品信息", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuXGXX_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_xgxx", "Fun_ts_zyhs_xgxx", "修改信息", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void frmCWYL_Activated(object sender, System.EventArgs e)
        {
            frmCWYL_Load(null, null);
            PostMessage(this.listView1.Handle.ToInt32(), 0x020A, 0, 0);
        }

        private void mnuZC_Click(object sender, System.EventArgs e)
        {
            //不判断是否有点击事件，只管有没有病人信息
            //Modify By Tany 2004-10-28
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
            string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
            if (rtnSql[2] != "0")
            {
                MessageBox.Show("由于跨院特殊申请未完成，不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cursor = Cursors.Default;
                return;
            }
            #endregion
            frmZC frmZc = new frmZC();
            frmZc.ShowDialog();
            frmZc.Dispose();

            InitView(bit, 0);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            toolTip1.Hide(listView1);
            //根据参数判断是否使用护士站医嘱录入
            //Modify By Tany 2007-09-04
            if ((new SystemCfg(7032)).Config == "是")
            {
                //Modify By tany 2011-06-18
                string _cfg7037 = (new SystemCfg(7037)).Config;
                //如果所有科室可以录入
                if (_cfg7037 == "所有")
                {
                    mnuOrder_Click(null, null);
                }
                else if (_cfg7037 != "")//指定科室可以录入
                {
                    string[] _cfgWard = _cfg7037.Split(',');
                    bool _isInput = false;
                    if (_cfgWard.Length > 0)
                    {
                        for (int i = 0; i < _cfgWard.Length; i++)
                        {
                            if (InstanceForm.BCurrentDept.WardId == _cfgWard[i])
                            {
                                _isInput = true;
                                break;
                            }
                        }
                    }
                    if (_isInput)
                    {
                        mnuOrder_Click(null, null);
                    }
                    else
                    {
                        mnuOrderQuery_Click(null, null);
                    }
                }
                else
                {
                    mnuOrderQuery_Click(null, null);
                }
            }
            else
            {
                mnuOrderQuery_Click(null, null);
            }
        }

        private void GetForm(string dllName, string functionName, string chineseName, long userID, long deptID, object[] communicateValue, bool showType)
        {
            try
            {
                User _user_id = new User(Convert.ToInt32(userID), FrmMdiMain.Database);
                Department _dept_id = new Department(Convert.ToInt32(deptID), FrmMdiMain.Database);

                //获得DLL中窗体
                Form _dllform = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, _user_id, _dept_id, null, FrmMdiMain.Database, ref communicateValue);
                _dllform.StartPosition = FormStartPosition.CenterScreen;
                if (showType) _dllform.ShowDialog();
                else _dllform.Show();
                for (int i = 0; i < 10; i++) openForm[i] = Guid.Empty;   //将已经打开的医嘱管理窗体进行初始化,如果没有这句话,在关闭医嘱窗体后再打开则会提示该医嘱窗体已经打开
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace.ToString());
                Cursor = Cursors.Default;
                return;
            }
        }

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

        private void btRefresh_Click(object sender, EventArgs e)
        {
            ShowNewPatient();
        }

        private void ShowNewPatient()
        {
            string sSql = @"select in_date as 入院日期,inpatient_no as 住院号,x.name as 姓名,x.baby_no as 婴儿号, " +
                    "         case when sexcode=1 then '男' else '女' end as 性别, " +
                    "         dbo.FUN_ZY_SEEKDEPTNAME(x.dept_id) as 所属科室," +
                    "         case when y.zkcs is null  then '新入院' else '转科'end as 病人来源," +
                    "         x.inpatient_id as ID,dept_id as pat_in_dept,x.inpatient_id,x.baby_id " +
                    "    from (select inpatient_no,name,0 baby_id,0 baby_no,sexcode,in_date,inpatient_id,dept_id " +
                    "          from vi_zy_vinpatient a " +
                    "          where flag=1 " +
                    "                and a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' ) " +
                    "          union all " +
                    "          select inpatient_no,babyname,baby_id,baby_no,sex,in_date,inpatient_id,dept_id " +
                    "          from zy_inpatient_baby " +
                    "          where flag=1 " +
                    "                and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' )) x " +
                //只要转成功过,不管是否取消,都算过转科,不改变病人入院日期 Modify By tany 2009-10-28
                //"    left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where cancel_bit=0 and finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                    "    left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                    "   order by in_date ";

            DataTable tb = InstanceForm.BDatabase.GetDataTable(sSql);

            dgvNewPatient.DataSource = tb;

            string[] GrdMappingName1 ={ "姓名", "性别", "所属科室", "病人来源", "住院号", "入院日期", "婴儿号", "ID", "pat_in_dept", "INPATIENT_ID", "Baby_ID" };
            //Modify by jchl
            DataTable dtSrc = dgvNewPatient.DataSource as DataTable;
            DoInitCtr(GrdMappingName1, GrdMappingName1, new string[] { "姓名", "住院号" }, new int[] { 60, 60, 100, 0, 0, 0, 0, 0, 0, 0, 0 }, dtSrc);

        }

        private void dgvNewPatient_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Clicks == 1) && (e.Button == MouseButtons.Left) && (e.ColumnIndex > 0) && (e.RowIndex > -1))
            {
                dgvNewPatient.DoDragDrop(e.RowIndex, DragDropEffects.All | DragDropEffects.Link);
            }
        }

        private void mnuXgbrxx_Click(object sender, EventArgs e)
        {
            Guid brxxid = new Guid(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select patient_id from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"), Guid.Empty.ToString()));
            Guid kdjid = new Guid(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select kdjid from yy_kdjb where brxxid='" + brxxid + "'"), Guid.Empty.ToString()));

            if (brxxid == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息！");
                return;
            }
            MenuTag mt = new MenuTag();
            mt.Function_Name = "hs";

            ts_mz_kgl.Frmbrkdj frm = new ts_mz_kgl.Frmbrkdj(mt, "修改病人信息", MdiParent, brxxid, kdjid);
            frm.ShowDialog();
        }

        //private void dgvNewPatient_CurrentCellChanged(object sender, EventArgs e)
        //{
        //    dgvNewPatient.ClearSelection();
        //    dgvNewPatient.CurrentCell.Selected = true;
        //    dgvNewPatient.Rows[dgvNewPatient.CurrentRow.Index].Selected = true;
        //    dgvNewPatient.CurrentCell = dgvNewPatient.Rows[dgvNewPatient.CurrentRow.Index].Cells[0];
        //}

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
            DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            try
            {
                sSql = "SP_ZYHS_WARDGZRZ";

                parameters[0].Value = InstanceForm.BCurrentDept.WardId;
                parameters[0].Text = "@WARD_ID";
                parameters[1].Value = now.ToString("yyyy-MM-dd 00:00:00");
                parameters[1].Text = "@BDATE";
                parameters[2].Value = now.ToString("yyyy-MM-dd 23:59:59"); ;
                parameters[2].Text = "@EDATE";
                parameters[3].Value = 0;
                parameters[3].Text = "@FLAG";

                rtnTb = FrmMdiMain.Database.GetDataTable(sSql, parameters, 60);

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
                    //add by zouchihua 2013-8-1 增加陪护数
                    int ph = 0;
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
                        ph += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["陪护"], "0"));
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
                    rs += "陪护人数：" + ph + "\r\n";
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

        private void mnuBRZK_Click(object sender, EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_brzk", "Fun_ts_zyhs_brzk", "病人转科", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuDYCY_Click(object sender, EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_dycy", "Fun_ts_zyhs_dycy", "定义出院", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void frmCWYL_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(listView1);
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            toolTip1.Hide(listView1);

            mnuEMR.Visible = isUseEMR;
        }

        private void frmCWYL_Load_1(object sender, EventArgs e)
        {
            if (cfg7205.Config == "1")
                this.mnuFM.Text = "费用附加";
            else
                this.mnuFM.Text = "分娩";

            this.listView1.LostFocus += new EventHandler(listView1_LostFocus);
            this.listView1.OwnerDraw = true;
            //7128 护士站是否允许分娩 0=否，1=是 add by zouchihua 2012-6-1
            SystemCfg cfg7128 = new SystemCfg(7128);
            if (cfg7128.Config.Trim() == "0")
                mnuFM.Enabled = false;
            //add by zouchihua 2013-3-7 是否需要护士站审核医保病人的身份

            if (cfg7145.Config.Trim() == "1")
                menuItem7.Visible = true;
            else
                menuItem7.Visible = false;
            //7095是否使用护士站电子病历 0=不是 1=是
            string cfg = new SystemCfg(7095).Config;
            if (cfg == "1")
            {
                isUseEMR = true;
            }
            else
            {
                isUseEMR = false;
            }
            string cfg7112 = new SystemCfg(7112).Config;
            if (cfg7112.Trim() == "1")
            {
                mnuXgbrxx.Enabled = false;
            }
        }

        void listView1_LostFocus(object sender, EventArgs e)
        {
            //焦点失去就隐藏
            toolTip1.Hide(this.listView1);
        }

        private void mnuEMR_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Inpatient inpatient = new Inpatient(ClassStatic.Current_BinID);
            Patient patient = new Patient(inpatient.PatientID);
            //  //0:用户编号 1：当次病人住院标识 2:病人所在科室 3:病人出生日期 4:病人入院日期 5：病人出院日期 6：婴儿id
            object[] communicateValue = new object[6];
            communicateValue[0] = FrmMdiMain.CurrentUser.LoginCode.Trim();
            communicateValue[1] = ClassStatic.Current_BinID;
            communicateValue[2] = ClassStatic.Current_DeptID;
            communicateValue[3] = patient.Birthday.ToString();
            communicateValue[4] = inpatient.In_date.ToString();
            communicateValue[5] = inpatient.Flag == 4 ? inpatient.Out_date.ToString() : "";
            Form _dllform = (Form)WorkStaticFun.InstanceForm("EmrHisNurseInterface", "Fun_emr_nurse_interface", "病历书写", FrmMdiMain.CurrentUser, FrmMdiMain.CurrentDept, null, FrmMdiMain.Database, ref communicateValue);
            //_dllform.StartPosition = FormStartPosition.CenterScreen;
            if (_dllform != null)
            {
                _dllform.ShowDialog();
            }

        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            InitView(bit, 1);
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "请选择一个病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            frmInPassword password = new frmInPassword();
            password.ShowDialog();
            if (!password.isLogin)
            {
                MessageBox.Show(this, "密码错误！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DateTime serverDateTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                string commandText = "select  DISCHARGETYPE,inpatient_id  from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "' ";
                DataTable dataTable = FrmMdiMain.Database.GetDataTable(commandText);
                this.toolTip1.SetToolTip(this.listView1, "");
                commandText = " select * from VI_ZY_VINPATIENT_ALL  where inpatient_id='" + ClassStatic.Current_BinID + "' ";
                DataTable table2 = FrmMdiMain.Database.GetDataTable(commandText);
                try
                {
                    if (table2.Rows.Count >= 1)
                    {
                        DataTable table3 = new DataTable();
                        DataTable table4 = new DataTable();
                        string str2 = "select * from ZY_YB_SHXX where inpatient_id='" + new Guid(dataTable.Rows[0]["INPATIENT_ID"].ToString().Trim()) + "'    ";
                        table4 = FrmMdiMain.Database.GetDataTable(str2);
                        if (table4.Rows.Count == 0)
                        {
                            frmlrzd frmlrzd = new frmlrzd("cwyl", new Guid(dataTable.Rows[0]["INPATIENT_ID"].ToString()), FrmMdiMain.CurrentUser);
                            frmlrzd.ShowDialog();
                            if (frmlrzd.ReturnValue != 3)
                            {
                                this.frmCWYL_Load(null, null);
                            }
                            if ((frmlrzd.ReturnValue != 3) && (frmlrzd.ReturnValue != -1))
                            {
                            }
                        }
                        else if (table4.Rows[0]["RYSH"].ToString() != "1")
                        {
                            frmlrzd frmlrzd2 = new frmlrzd("cwyl", new Guid(dataTable.Rows[0]["INPATIENT_ID"].ToString()), FrmMdiMain.CurrentUser);
                            frmlrzd2.ShowDialog();
                            if (frmlrzd2.ReturnValue != 3)
                            {
                                this.frmCWYL_Load(null, null);
                            }
                            if ((frmlrzd2.ReturnValue != 3) && (frmlrzd2.ReturnValue != -1))
                            {
                            }
                        }
                        else if (table4.Rows[0]["RYSH"].ToString() == "1")
                        {
                            MessageBox.Show("该病人已经在医保科入院或者医保入院审核通过，护士站已不能进行审核操作！！", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    else
                    {
                        MessageBox.Show("老接口病人不能进行这种操作", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void menuItem48_Popup(object sender, EventArgs e)
        {
            toolTip1.Hide(this.listView1);
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(this.listView1);
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if ((e.State & ListViewItemStates.Selected) != 0)
            {

                //Rectangle rc = new Rectangle(new Point(e.Bounds.Location.X + this.columnHeader1.Width, e.Bounds.Y), new Size(e.Bounds.Width - this.columnHeader1.Width, e.Bounds.Height - 1));
                //LinearGradientBrush brush =
                //            new LinearGradientBrush(rc, FColor,
                //            TColor, LinearGradientMode.Horizontal);
                // Draw the background and focus rectangle for a selected item.
                //e.Graphics.FillRectangle(brush, rc);
                //e.Graphics.DrawRectangle(Pens.Blue, e.Bounds);
                //e.DrawFocusRectangle();
            }
            // e.DrawText(TextFormatFlags.Default);

            if (e.Item.Text.IndexOf("*") >= 0)
            {
                e.Graphics.DrawString("病危", e.Item.Font, Brushes.Red, e.Bounds.Location.X - 10, e.Bounds.Location.Y);
            }
            if (e.Item.Text.IndexOf("△") >= 0)
            {
                if (e.Item.Text.IndexOf("△") >= 0 && e.Item.Text.IndexOf("*") >= 0)
                    e.Graphics.DrawString("病重", e.Item.Font, Brushes.Red, e.Bounds.Location.X - 10, e.Bounds.Location.Y + 15);
                else
                    e.Graphics.DrawString("病重", e.Item.Font, Brushes.Red, e.Bounds.Location.X - 10, e.Bounds.Location.Y);
            }
            // Font f=new Font("宋体",FontStyle.Bold);
            try
            {
                Font f = new Font("宋体", 18, FontStyle.Bold);
                if (e.Item.Tag.ToString().IndexOf("R") >= 0)
                    e.Graphics.DrawString("R", f, Brushes.Red, e.Bounds.Location.X + 2, e.Bounds.Location.Y + 22);
                //隔离处理 add by yaokx 2014-03-04
                if (e.Item.Tag.ToString().IndexOf("隔离") >= 0)
                {
                    //1、接触隔离 蓝色；2、血液体液隔离 红色；3、呼吸道隔离 蓝色；4、严密隔离 黄色；5、消化道隔离 棕色。
                    string[] list = e.Item.Tag.ToString().Split(',');
                    Font f2 = new Font("宋体", 11);
                    if (list[1].IndexOf("接触隔离") >= 0)
                        e.Graphics.DrawString("隔离", f2, Brushes.Blue, e.Bounds.Location.X - 15, e.Bounds.Location.Y + 30);
                    else if (list[1].IndexOf("血液体液隔离") >= 0 || list[1].IndexOf("血液隔离") >= 0 || list[1].IndexOf("体液隔离") >= 0 || list[1].IndexOf("血体液隔离") >= 0)
                        e.Graphics.DrawString("隔离", f2, Brushes.Red, e.Bounds.Location.X - 15, e.Bounds.Location.Y + 30);
                    else if (list[1].IndexOf("呼吸道隔离") >= 0)
                        e.Graphics.DrawString("隔离", f2, Brushes.Blue, e.Bounds.Location.X - 15, e.Bounds.Location.Y + 30);
                    else if (list[1].IndexOf("严密隔离") >= 0)
                        e.Graphics.DrawString("隔离", f2, Brushes.Gold, e.Bounds.Location.X - 15, e.Bounds.Location.Y + 30);
                    else if (list[1].IndexOf("消化道隔离") >= 0)
                        e.Graphics.DrawString("隔离", f2, Brushes.Brown, e.Bounds.Location.X - 15, e.Bounds.Location.Y + 30);

                }
                string str = e.Item.Tag.ToString();
                //欠费的处理
                Font f1 = new Font("宋体", 16, FontStyle.Bold);
                if (str.Substring(str.IndexOf("费用")).IndexOf('-') > 0)
                    e.Graphics.DrawString("欠", f1, Brushes.Red, e.Bounds.Location.X + this.listView1.LargeImageList.ImageSize.Width + 15, e.Bounds.Location.Y);


            }
            catch { }
            e.DrawDefault = true;
            try
            {
                Font f1 = new Font("宋体", 10, FontStyle.Bold);
                if (e.Item.ImageIndex == 71)
                    e.Graphics.DrawString("门\r\n诊\r\n留\r\n观", f1, Brushes.Blue, e.Bounds.Location.X + this.listView1.LargeImageList.ImageSize.Width + 20, e.Bounds.Location.Y);
            }
            catch { }
            //e.Graphics.DrawImage(e.Item.ImageList.Images[e.Item.ImageIndex], e.Item.Position);
        }

        private void listView1_MouseLeave(object sender, EventArgs e)
        {
            //toolTip1.Hide(this.listView1); 
        }

        private void btSyncOldHISPatInfo_Click(object sender, EventArgs e)
        {
            TrasenHIS.BLL.SyncPatientInfo.SyncPat(FrmMdiMain.Database);
        }

        private void DoInitCtr(string[] headtext, string[] mappingname, string[] serchFileds, int[] cols, DataTable dtSrc)
        {
            ucShowCard1.Init(headtext, mappingname, serchFileds, cols, dtSrc);
        }

        private void ucShowCard1_MyDelEvent()
        {
            ucShowCard1.Value = ucShowCard1.Row["姓名"].ToString();
            ucShowCard1.Key = ucShowCard1.Row["INPATIENT_ID"].ToString();

            DataTable dt = dgvNewPatient.DataSource as DataTable;
            if (dt == null || dt.Rows.Count <= 0)
                return;

            dt.DefaultView.RowFilter = "INPATIENT_ID='" + ucShowCard1.Key + "'";
        }
        /// <summary>
        /// 调用医惠系统（批处理文件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem8_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                string targetDir = string.Format(@"D:\bsoft\portal");//this is where mybatch.bat lies
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName ="HisIntoNis.bat";
                proc.StartInfo.Arguments = string.Format(InstanceForm.BCurrentUser.LoginCode.ToString()+" "+patientInfo1.lbID.Text.Remove(0,2));//this is argument
                //proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.CreateNoWindow = false;
                //proc.StartInfo.UseShellExecute = false;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }

    }
}
