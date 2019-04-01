using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using YpClass;
using System.Runtime.InteropServices;
namespace ts_zyhs_ypxx
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class frmYPXX : System.Windows.Forms.Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern short GetKeyState(int vKey);
        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);


        /// <summary>
        /// 不能发送为暂存药的统领分类,多个用逗号隔开
        /// </summary>
        private SystemCfg cfg7175 = new SystemCfg(7175);
        /// <summary>
        /// 护士站是否启用暂存药品库存管理 0=不启用 1=启用
        /// </summary>
        private SystemCfg cfg7182 = new SystemCfg(7182);
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem 全选ToolStripMenuItem;
        private ToolStripMenuItem 反选ToolStripMenuItem;
        private ContextMenuStrip contextMenuStripQXtld;
        private ToolStripMenuItem 取消统领单ToolStripMenuItem;
        private TabPage tabPage3;
        private Panel panelZcyGL;
        private TabPage tabPage2;
        private Panel panel总;
        private Panel panel下;
        private Panel panel右;
        private Panel panel右下;
        private Panel panelMX;
        private Button btnReSend;
        private RadioButton rb所有病人;
        private RadioButton rb选定病人;
        private Button bt反选;
        private Button bt全选;
        private DataGridEx myDataGridMX;
        private DataGridTableStyle dataGridTableStyle7;
        private Panel panelQY;
        private ComboBox cmbSort;
        private Button btnReSend缺;
        private RadioButton rb所有病人缺;
        private RadioButton rb选定病人缺;
        private Button bt反选缺;
        private Button bt全选缺;
        private DataGridEx myDataGridQY;
        private DataGridTableStyle dataGridTableStyle5;
        private Splitter splitter3;
        private Panel panel右上;
        private DataGridEx myDataGridTL;
        private DataGridTableStyle dataGridTableStyle2;
        private Splitter splitter2;
        private Panel panel左;
        private Panel panel2;
        private Button btnSelAll;
        private Button btnUnSel;
        private ComboBox cmbLX;
        private ComboBox cmbSFEXECDEPT;
        private DataGridEx myDataGridXX;
        private DataGridTableStyle dataGridTableStyle4;
        private Splitter splitter4;
        private Panel panel1;
        private ComboBox cmbTLEXECDEPT;
        private DataGridEx myDataGridFY;
        private DataGridTableStyle dataGridTableStyle6;
        private Splitter splitter1;
        private Panel panel上;
        private Button bt发送药品;
        private Button bt显示缺药消息;
        private Button bt发送;
        private Button bt删除;
        private Button bt显示统领单;
        private Button bt刷新消息;
        private Button bt打印明细单;
        private Button bt打印统领单;
        private Button bt退出;
        private GroupBox groupBox2;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button4;
        private GroupBox groupBox1;
        private Label label2;
        private DateTimePicker dtpBeginDate;
        private Label label1;
        private DateTimePicker DtpEndDate;
        private CheckBox checkBox1;
        private TabPage tabPage1;
        private SplitContainer splitContainer1;
        private Panel panel5;
        private Button bt反选1;
        private Button bt全选1;
        private DataGridEx dataGridEx1;
        private DataGridTableStyle dataGridTableStyle3;
        private Crownwood.Magic.Controls.TabControl tabControl2;
        private Label label3;
        private Button button1;
        private SerchText serchText1;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private Panel panel4;
        private DataGridEx dgYPMX;
        private DataGridTableStyle dataGridTableStyle1;
        private Panel panel6;
        private ComboBox cmbTlfl;
        private Button btUnSelect;
        private Button btSelect;
        private Button btClean;
        private Button btSeek;
        private TextBox txtjx;
        private Label label4;
        private Label label5;
        private TextBox txtypmc;
        private Label label6;
        private Panel panel3;
        private GroupBox groupBox6;
        private CheckBox checkDQ;
        private CheckBox checkLsk;
        private Button btnFszdyf;
        private CheckBox CbZCy;
        private Button btExit;
        private GroupBox groupBox5;
        private ComboBox cmbZxyf;
        private GroupBox groupBox4;
        private RadioButton rbTy;
        private RadioButton rbLy;
        private GroupBox groupBox3;
        private RadioButton rbAll;
        private RadioButton rbOut;
        private RadioButton rbTempOut;
        private RadioButton rbIn;
        private RadioButton rbTszl;
        private RadioButton rbTrans;
        private Button bt生成统领单;
        private Button bt刷新药品信息;
        private Button button11;
        private TabControl tabControl1;
        private TabPage tabPage5;
        private Panel panel7;
        private TabPage tabPage6;
        private Panel panel8;
        private TextBox txtYp;
        private Label label7;
        private CheckBox chkBed;
        private TextBox txtMxBed;
        private TextBox txtMxZyh;
        private CheckBox chkZyh;
        private TextBox txtMxName;
        private CheckBox chkName;
        const byte CtrlMask = 8;
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        protected const byte VK_LSHIFT = 0xA0;
        protected const byte VK_RSHIFT = 0xA1;
        private readonly int MOUSEEVENTF_LEFTDOWN = 0x2;
        private readonly int MOUSEEVENTF_LEFTUP = 0x4;
        int ShiftBeginIndex = -1;
        int ShiftEndIndex = -1;
        //自定义变量
        private BaseFunc myFunc;
        private string sendDept = "", execDept = "", sendDate = "", sendkind = "";
        private double total = 0;
        private bool isYPXX = true;  //true是药品消息   false是药房反馈消息
        private bool isFY = false;  // true 已发药      false未发药
        private TheReportDateSet rds = new TheReportDateSet();
        private DataTable xxTb = new DataTable();
        private DataTable fyTb = new DataTable();
        private DataTable yfTb = new DataTable();
        private DataRow dr;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 同厂家ToolStripMenuItem;
        private ToolStripMenuItem 同一人ToolStripMenuItem;
        private ToolStripMenuItem 发送到暂存管理ToolStripMenuItem;
        private IContainer components;
        private string SelectTabtile = "";
        private SystemCfg cfg7210 = new SystemCfg(7210);//护士站是否允许取消统领单 0=否 1=是
        /// <summary>
        /// 重新输入数量控件
        /// </summary>
        private TextBox txtb;
        public frmYPXX(string _formText)
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
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
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
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.contextMenuStripQXtld = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.取消统领单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.同厂家ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同一人ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发送到暂存管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panelZcyGL = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel总 = new System.Windows.Forms.Panel();
            this.panel下 = new System.Windows.Forms.Panel();
            this.panel右 = new System.Windows.Forms.Panel();
            this.panel右下 = new System.Windows.Forms.Panel();
            this.panelMX = new System.Windows.Forms.Panel();
            this.txtMxName = new System.Windows.Forms.TextBox();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.txtMxZyh = new System.Windows.Forms.TextBox();
            this.chkZyh = new System.Windows.Forms.CheckBox();
            this.txtMxBed = new System.Windows.Forms.TextBox();
            this.chkBed = new System.Windows.Forms.CheckBox();
            this.btnReSend = new System.Windows.Forms.Button();
            this.rb所有病人 = new System.Windows.Forms.RadioButton();
            this.rb选定病人 = new System.Windows.Forms.RadioButton();
            this.bt反选 = new System.Windows.Forms.Button();
            this.bt全选 = new System.Windows.Forms.Button();
            this.myDataGridMX = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle7 = new System.Windows.Forms.DataGridTableStyle();
            this.panelQY = new System.Windows.Forms.Panel();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.btnReSend缺 = new System.Windows.Forms.Button();
            this.rb所有病人缺 = new System.Windows.Forms.RadioButton();
            this.rb选定病人缺 = new System.Windows.Forms.RadioButton();
            this.bt反选缺 = new System.Windows.Forms.Button();
            this.bt全选缺 = new System.Windows.Forms.Button();
            this.myDataGridQY = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle5 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel右上 = new System.Windows.Forms.Panel();
            this.txtYp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.myDataGridTL = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel左 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelAll = new System.Windows.Forms.Button();
            this.btnUnSel = new System.Windows.Forms.Button();
            this.cmbLX = new System.Windows.Forms.ComboBox();
            this.cmbSFEXECDEPT = new System.Windows.Forms.ComboBox();
            this.myDataGridXX = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTLEXECDEPT = new System.Windows.Forms.ComboBox();
            this.myDataGridFY = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle6 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel上 = new System.Windows.Forms.Panel();
            this.bt发送药品 = new System.Windows.Forms.Button();
            this.bt显示缺药消息 = new System.Windows.Forms.Button();
            this.bt发送 = new System.Windows.Forms.Button();
            this.bt删除 = new System.Windows.Forms.Button();
            this.bt显示统领单 = new System.Windows.Forms.Button();
            this.bt刷新消息 = new System.Windows.Forms.Button();
            this.bt打印明细单 = new System.Windows.Forms.Button();
            this.bt打印统领单 = new System.Windows.Forms.Button();
            this.bt退出 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.bt反选1 = new System.Windows.Forms.Button();
            this.bt全选1 = new System.Windows.Forms.Button();
            this.dataGridEx1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.serchText1 = new ts_zyhs_ypxx.SerchText();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgYPMX = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmbTlfl = new System.Windows.Forms.ComboBox();
            this.btUnSelect = new System.Windows.Forms.Button();
            this.btSelect = new System.Windows.Forms.Button();
            this.btClean = new System.Windows.Forms.Button();
            this.btSeek = new System.Windows.Forms.Button();
            this.txtjx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtypmc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkDQ = new System.Windows.Forms.CheckBox();
            this.checkLsk = new System.Windows.Forms.CheckBox();
            this.btnFszdyf = new System.Windows.Forms.Button();
            this.CbZCy = new System.Windows.Forms.CheckBox();
            this.btExit = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbZxyf = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbTy = new System.Windows.Forms.RadioButton();
            this.rbLy = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbOut = new System.Windows.Forms.RadioButton();
            this.rbTempOut = new System.Windows.Forms.RadioButton();
            this.rbIn = new System.Windows.Forms.RadioButton();
            this.rbTszl = new System.Windows.Forms.RadioButton();
            this.rbTrans = new System.Windows.Forms.RadioButton();
            this.bt生成统领单 = new System.Windows.Forms.Button();
            this.bt刷新药品信息 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.contextMenuStripQXtld.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel总.SuspendLayout();
            this.panel下.SuspendLayout();
            this.panel右.SuspendLayout();
            this.panel右下.SuspendLayout();
            this.panelMX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridMX)).BeginInit();
            this.panelQY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridQY)).BeginInit();
            this.panel右上.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridTL)).BeginInit();
            this.panel左.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridXX)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridFY)).BeginInit();
            this.panel上.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEx1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgYPMX)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripQXtld
            // 
            this.contextMenuStripQXtld.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.取消统领单ToolStripMenuItem});
            this.contextMenuStripQXtld.Name = "contextMenuStripQXtld";
            this.contextMenuStripQXtld.Size = new System.Drawing.Size(131, 26);
            // 
            // 取消统领单ToolStripMenuItem
            // 
            this.取消统领单ToolStripMenuItem.Name = "取消统领单ToolStripMenuItem";
            this.取消统领单ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.取消统领单ToolStripMenuItem.Text = "取消统领单";
            this.取消统领单ToolStripMenuItem.Visible = false;
            this.取消统领单ToolStripMenuItem.Click += new System.EventHandler(this.取消统领单ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同厂家ToolStripMenuItem,
            this.同一人ToolStripMenuItem,
            this.发送到暂存管理ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 70);
            // 
            // 同厂家ToolStripMenuItem
            // 
            this.同厂家ToolStripMenuItem.Name = "同厂家ToolStripMenuItem";
            this.同厂家ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.同厂家ToolStripMenuItem.Text = "同厂家";
            this.同厂家ToolStripMenuItem.Click += new System.EventHandler(this.同厂家ToolStripMenuItem_Click);
            // 
            // 同一人ToolStripMenuItem
            // 
            this.同一人ToolStripMenuItem.Name = "同一人ToolStripMenuItem";
            this.同一人ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.同一人ToolStripMenuItem.Text = "同一人";
            this.同一人ToolStripMenuItem.Click += new System.EventHandler(this.同一人ToolStripMenuItem_Click);
            // 
            // 发送到暂存管理ToolStripMenuItem
            // 
            this.发送到暂存管理ToolStripMenuItem.Name = "发送到暂存管理ToolStripMenuItem";
            this.发送到暂存管理ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.发送到暂存管理ToolStripMenuItem.Text = "发送到暂存管理";
            this.发送到暂存管理ToolStripMenuItem.Click += new System.EventHandler(this.发送到暂存管理ToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全选ToolStripMenuItem,
            this.反选ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(95, 48);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // 反选ToolStripMenuItem
            // 
            this.反选ToolStripMenuItem.Name = "反选ToolStripMenuItem";
            this.反选ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.反选ToolStripMenuItem.Text = "反选";
            this.反选ToolStripMenuItem.Click += new System.EventHandler(this.反选ToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panelZcyGL);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(918, 505);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "成本节约";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panelZcyGL
            // 
            this.panelZcyGL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelZcyGL.Location = new System.Drawing.Point(3, 3);
            this.panelZcyGL.Name = "panelZcyGL";
            this.panelZcyGL.Size = new System.Drawing.Size(912, 499);
            this.panelZcyGL.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel总);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(918, 505);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "统领信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel总
            // 
            this.panel总.Controls.Add(this.panel下);
            this.panel总.Controls.Add(this.splitter1);
            this.panel总.Controls.Add(this.panel上);
            this.panel总.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel总.Location = new System.Drawing.Point(3, 3);
            this.panel总.Name = "panel总";
            this.panel总.Size = new System.Drawing.Size(912, 499);
            this.panel总.TabIndex = 0;
            // 
            // panel下
            // 
            this.panel下.Controls.Add(this.panel右);
            this.panel下.Controls.Add(this.splitter2);
            this.panel下.Controls.Add(this.panel左);
            this.panel下.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel下.Location = new System.Drawing.Point(0, 81);
            this.panel下.Name = "panel下";
            this.panel下.Size = new System.Drawing.Size(912, 418);
            this.panel下.TabIndex = 2;
            // 
            // panel右
            // 
            this.panel右.Controls.Add(this.panel右下);
            this.panel右.Controls.Add(this.splitter3);
            this.panel右.Controls.Add(this.panel右上);
            this.panel右.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel右.Location = new System.Drawing.Point(356, 0);
            this.panel右.Name = "panel右";
            this.panel右.Size = new System.Drawing.Size(556, 418);
            this.panel右.TabIndex = 2;
            // 
            // panel右下
            // 
            this.panel右下.Controls.Add(this.panelMX);
            this.panel右下.Controls.Add(this.panelQY);
            this.panel右下.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel右下.Location = new System.Drawing.Point(0, 276);
            this.panel右下.Name = "panel右下";
            this.panel右下.Size = new System.Drawing.Size(556, 142);
            this.panel右下.TabIndex = 2;
            // 
            // panelMX
            // 
            this.panelMX.Controls.Add(this.txtMxName);
            this.panelMX.Controls.Add(this.chkName);
            this.panelMX.Controls.Add(this.txtMxZyh);
            this.panelMX.Controls.Add(this.chkZyh);
            this.panelMX.Controls.Add(this.txtMxBed);
            this.panelMX.Controls.Add(this.chkBed);
            this.panelMX.Controls.Add(this.btnReSend);
            this.panelMX.Controls.Add(this.rb所有病人);
            this.panelMX.Controls.Add(this.rb选定病人);
            this.panelMX.Controls.Add(this.bt反选);
            this.panelMX.Controls.Add(this.bt全选);
            this.panelMX.Controls.Add(this.myDataGridMX);
            this.panelMX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMX.Location = new System.Drawing.Point(0, 0);
            this.panelMX.Name = "panelMX";
            this.panelMX.Size = new System.Drawing.Size(556, 142);
            this.panelMX.TabIndex = 0;
            // 
            // txtMxName
            // 
            this.txtMxName.Enabled = false;
            this.txtMxName.Location = new System.Drawing.Point(394, 2);
            this.txtMxName.Name = "txtMxName";
            this.txtMxName.Size = new System.Drawing.Size(46, 21);
            this.txtMxName.TabIndex = 93;
            this.txtMxName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DoFilMx);
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Location = new System.Drawing.Point(344, 4);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(48, 16);
            this.chkName.TabIndex = 92;
            this.chkName.Text = "姓名";
            this.chkName.UseVisualStyleBackColor = true;
            this.chkName.CheckedChanged += new System.EventHandler(this.chkName_CheckedChanged);
            // 
            // txtMxZyh
            // 
            this.txtMxZyh.Enabled = false;
            this.txtMxZyh.Location = new System.Drawing.Point(215, 2);
            this.txtMxZyh.Name = "txtMxZyh";
            this.txtMxZyh.Size = new System.Drawing.Size(120, 21);
            this.txtMxZyh.TabIndex = 91;
            this.txtMxZyh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DoFilMx);
            // 
            // chkZyh
            // 
            this.chkZyh.AutoSize = true;
            this.chkZyh.Location = new System.Drawing.Point(152, 4);
            this.chkZyh.Name = "chkZyh";
            this.chkZyh.Size = new System.Drawing.Size(60, 16);
            this.chkZyh.TabIndex = 90;
            this.chkZyh.Text = "住院号";
            this.chkZyh.UseVisualStyleBackColor = true;
            this.chkZyh.CheckedChanged += new System.EventHandler(this.chkZyh_CheckedChanged);
            // 
            // txtMxBed
            // 
            this.txtMxBed.Enabled = false;
            this.txtMxBed.Location = new System.Drawing.Point(100, 2);
            this.txtMxBed.Name = "txtMxBed";
            this.txtMxBed.Size = new System.Drawing.Size(46, 21);
            this.txtMxBed.TabIndex = 89;
            this.txtMxBed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DoFilMx);
            // 
            // chkBed
            // 
            this.chkBed.AutoSize = true;
            this.chkBed.Location = new System.Drawing.Point(50, 4);
            this.chkBed.Name = "chkBed";
            this.chkBed.Size = new System.Drawing.Size(48, 16);
            this.chkBed.TabIndex = 88;
            this.chkBed.Text = "床号";
            this.chkBed.UseVisualStyleBackColor = true;
            this.chkBed.CheckedChanged += new System.EventHandler(this.chkBed_CheckedChanged);
            // 
            // btnReSend
            // 
            this.btnReSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReSend.BackColor = System.Drawing.Color.PaleGreen;
            this.btnReSend.ContextMenu = this.contextMenu1;
            this.btnReSend.Location = new System.Drawing.Point(469, 2);
            this.btnReSend.Name = "btnReSend";
            this.btnReSend.Size = new System.Drawing.Size(83, 20);
            this.btnReSend.TabIndex = 87;
            this.btnReSend.Text = "重新发送(&R)";
            this.btnReSend.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReSend.UseVisualStyleBackColor = false;
            this.btnReSend.Click += new System.EventHandler(this.btnReSend_Click);
            // 
            // rb所有病人
            // 
            this.rb所有病人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb所有病人.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb所有病人.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb所有病人.Location = new System.Drawing.Point(263, 3);
            this.rb所有病人.Name = "rb所有病人";
            this.rb所有病人.Size = new System.Drawing.Size(72, 18);
            this.rb所有病人.TabIndex = 86;
            this.rb所有病人.Text = "所有病人";
            this.rb所有病人.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rb所有病人.UseVisualStyleBackColor = false;
            // 
            // rb选定病人
            // 
            this.rb选定病人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb选定病人.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb选定病人.Checked = true;
            this.rb选定病人.Location = new System.Drawing.Point(191, 3);
            this.rb选定病人.Name = "rb选定病人";
            this.rb选定病人.Size = new System.Drawing.Size(72, 18);
            this.rb选定病人.TabIndex = 85;
            this.rb选定病人.TabStop = true;
            this.rb选定病人.Text = "选定病人";
            this.rb选定病人.UseVisualStyleBackColor = false;
            // 
            // bt反选
            // 
            this.bt反选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt反选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt反选.Location = new System.Drawing.Point(405, 2);
            this.bt反选.Name = "bt反选";
            this.bt反选.Size = new System.Drawing.Size(56, 20);
            this.bt反选.TabIndex = 84;
            this.bt反选.Text = "反选(&F)";
            this.bt反选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt反选.UseVisualStyleBackColor = false;
            this.bt反选.Click += new System.EventHandler(this.bt反选_Click);
            // 
            // bt全选
            // 
            this.bt全选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt全选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt全选.Location = new System.Drawing.Point(341, 2);
            this.bt全选.Name = "bt全选";
            this.bt全选.Size = new System.Drawing.Size(56, 20);
            this.bt全选.TabIndex = 83;
            this.bt全选.Text = "全选(&A)";
            this.bt全选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt全选.UseVisualStyleBackColor = false;
            this.bt全选.Click += new System.EventHandler(this.bt全选_Click);
            // 
            // myDataGridMX
            // 
            this.myDataGridMX.AllowSorting = false;
            this.myDataGridMX.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGridMX.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGridMX.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGridMX.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGridMX.CaptionText = "明细单";
            this.myDataGridMX.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGridMX.DataMember = "";
            this.myDataGridMX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridMX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGridMX.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGridMX.Location = new System.Drawing.Point(0, 0);
            this.myDataGridMX.Name = "myDataGridMX";
            this.myDataGridMX.ReadOnly = true;
            this.myDataGridMX.RowHeaderWidth = 50;
            this.myDataGridMX.Size = new System.Drawing.Size(556, 142);
            this.myDataGridMX.TabIndex = 5;
            this.myDataGridMX.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle7});
            this.myDataGridMX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myDataGridMX_MouseClick);
            this.myDataGridMX.Click += new System.EventHandler(this.myDataGridMX_Click);
            // 
            // dataGridTableStyle7
            // 
            this.dataGridTableStyle7.AllowSorting = false;
            this.dataGridTableStyle7.DataGrid = this.myDataGridMX;
            this.dataGridTableStyle7.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panelQY
            // 
            this.panelQY.Controls.Add(this.cmbSort);
            this.panelQY.Controls.Add(this.btnReSend缺);
            this.panelQY.Controls.Add(this.rb所有病人缺);
            this.panelQY.Controls.Add(this.rb选定病人缺);
            this.panelQY.Controls.Add(this.bt反选缺);
            this.panelQY.Controls.Add(this.bt全选缺);
            this.panelQY.Controls.Add(this.myDataGridQY);
            this.panelQY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQY.Location = new System.Drawing.Point(0, 0);
            this.panelQY.Name = "panelQY";
            this.panelQY.Size = new System.Drawing.Size(556, 142);
            this.panelQY.TabIndex = 1;
            this.panelQY.VisibleChanged += new System.EventHandler(this.panelQY_VisibleChanged);
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSort.Items.AddRange(new object[] {
            "全部",
            "领药",
            "退药"});
            this.cmbSort.Location = new System.Drawing.Point(87, 1);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(80, 20);
            this.cmbSort.TabIndex = 92;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // btnReSend缺
            // 
            this.btnReSend缺.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReSend缺.BackColor = System.Drawing.Color.PaleGreen;
            this.btnReSend缺.ContextMenu = this.contextMenu1;
            this.btnReSend缺.Location = new System.Drawing.Point(462, 2);
            this.btnReSend缺.Name = "btnReSend缺";
            this.btnReSend缺.Size = new System.Drawing.Size(83, 20);
            this.btnReSend缺.TabIndex = 91;
            this.btnReSend缺.Text = "重新发送(&R)";
            this.btnReSend缺.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReSend缺.UseVisualStyleBackColor = false;
            this.btnReSend缺.Click += new System.EventHandler(this.btnReSend_Click);
            // 
            // rb所有病人缺
            // 
            this.rb所有病人缺.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb所有病人缺.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb所有病人缺.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb所有病人缺.Location = new System.Drawing.Point(242, 3);
            this.rb所有病人缺.Name = "rb所有病人缺";
            this.rb所有病人缺.Size = new System.Drawing.Size(72, 18);
            this.rb所有病人缺.TabIndex = 90;
            this.rb所有病人缺.Text = "所有病人";
            this.rb所有病人缺.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rb所有病人缺.UseVisualStyleBackColor = false;
            // 
            // rb选定病人缺
            // 
            this.rb选定病人缺.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb选定病人缺.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb选定病人缺.Checked = true;
            this.rb选定病人缺.Location = new System.Drawing.Point(170, 3);
            this.rb选定病人缺.Name = "rb选定病人缺";
            this.rb选定病人缺.Size = new System.Drawing.Size(72, 18);
            this.rb选定病人缺.TabIndex = 89;
            this.rb选定病人缺.TabStop = true;
            this.rb选定病人缺.Text = "选定病人";
            this.rb选定病人缺.UseVisualStyleBackColor = false;
            // 
            // bt反选缺
            // 
            this.bt反选缺.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt反选缺.BackColor = System.Drawing.Color.PaleGreen;
            this.bt反选缺.Location = new System.Drawing.Point(396, 2);
            this.bt反选缺.Name = "bt反选缺";
            this.bt反选缺.Size = new System.Drawing.Size(56, 20);
            this.bt反选缺.TabIndex = 88;
            this.bt反选缺.Text = "反选(&F)";
            this.bt反选缺.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt反选缺.UseVisualStyleBackColor = false;
            this.bt反选缺.Click += new System.EventHandler(this.bt反选缺_Click);
            // 
            // bt全选缺
            // 
            this.bt全选缺.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt全选缺.BackColor = System.Drawing.Color.PaleGreen;
            this.bt全选缺.Location = new System.Drawing.Point(330, 2);
            this.bt全选缺.Name = "bt全选缺";
            this.bt全选缺.Size = new System.Drawing.Size(56, 20);
            this.bt全选缺.TabIndex = 87;
            this.bt全选缺.Text = "全选(&A)";
            this.bt全选缺.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt全选缺.UseVisualStyleBackColor = false;
            this.bt全选缺.Click += new System.EventHandler(this.bt全选缺_Click);
            // 
            // myDataGridQY
            // 
            this.myDataGridQY.AllowSorting = false;
            this.myDataGridQY.BackColor = System.Drawing.Color.Yellow;
            this.myDataGridQY.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGridQY.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGridQY.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGridQY.CaptionForeColor = System.Drawing.Color.Red;
            this.myDataGridQY.CaptionText = "缺药信息列表";
            this.myDataGridQY.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGridQY.DataMember = "";
            this.myDataGridQY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridQY.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGridQY.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGridQY.Location = new System.Drawing.Point(0, 0);
            this.myDataGridQY.Name = "myDataGridQY";
            this.myDataGridQY.ReadOnly = true;
            this.myDataGridQY.RowHeaderWidth = 50;
            this.myDataGridQY.Size = new System.Drawing.Size(556, 142);
            this.myDataGridQY.TabIndex = 6;
            this.myDataGridQY.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle5});
            this.myDataGridQY.Click += new System.EventHandler(this.myDataGridQY_Click);
            // 
            // dataGridTableStyle5
            // 
            this.dataGridTableStyle5.AllowSorting = false;
            this.dataGridTableStyle5.DataGrid = this.myDataGridQY;
            this.dataGridTableStyle5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 272);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(556, 4);
            this.splitter3.TabIndex = 1;
            this.splitter3.TabStop = false;
            // 
            // panel右上
            // 
            this.panel右上.Controls.Add(this.txtYp);
            this.panel右上.Controls.Add(this.label7);
            this.panel右上.Controls.Add(this.myDataGridTL);
            this.panel右上.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel右上.Location = new System.Drawing.Point(0, 0);
            this.panel右上.Name = "panel右上";
            this.panel右上.Size = new System.Drawing.Size(556, 272);
            this.panel右上.TabIndex = 0;
            // 
            // txtYp
            // 
            this.txtYp.Location = new System.Drawing.Point(386, 1);
            this.txtYp.Name = "txtYp";
            this.txtYp.Size = new System.Drawing.Size(128, 21);
            this.txtYp.TabIndex = 5;
            this.txtYp.Tag = "0";
            this.txtYp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtYpTl_KeyUp);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(323, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "药品名称";
            // 
            // myDataGridTL
            // 
            this.myDataGridTL.AllowSorting = false;
            this.myDataGridTL.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGridTL.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGridTL.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGridTL.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGridTL.CaptionText = "统领单";
            this.myDataGridTL.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGridTL.DataMember = "";
            this.myDataGridTL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridTL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGridTL.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGridTL.Location = new System.Drawing.Point(0, 0);
            this.myDataGridTL.Name = "myDataGridTL";
            this.myDataGridTL.ReadOnly = true;
            this.myDataGridTL.RowHeaderWidth = 50;
            this.myDataGridTL.Size = new System.Drawing.Size(556, 272);
            this.myDataGridTL.TabIndex = 3;
            this.myDataGridTL.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGridTL.DoubleClick += new System.EventHandler(this.myDataGridTL_DoubleClick);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGridTL;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(352, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(4, 418);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // panel左
            // 
            this.panel左.Controls.Add(this.panel2);
            this.panel左.Controls.Add(this.splitter4);
            this.panel左.Controls.Add(this.panel1);
            this.panel左.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel左.Location = new System.Drawing.Point(0, 0);
            this.panel左.Name = "panel左";
            this.panel左.Size = new System.Drawing.Size(352, 418);
            this.panel左.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSelAll);
            this.panel2.Controls.Add(this.btnUnSel);
            this.panel2.Controls.Add(this.cmbLX);
            this.panel2.Controls.Add(this.cmbSFEXECDEPT);
            this.panel2.Controls.Add(this.myDataGridXX);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 276);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 142);
            this.panel2.TabIndex = 2;
            // 
            // btnSelAll
            // 
            this.btnSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelAll.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSelAll.Location = new System.Drawing.Point(109, 2);
            this.btnSelAll.Name = "btnSelAll";
            this.btnSelAll.Size = new System.Drawing.Size(40, 20);
            this.btnSelAll.TabIndex = 88;
            this.btnSelAll.Text = "全选";
            this.btnSelAll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelAll.UseVisualStyleBackColor = false;
            this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
            // 
            // btnUnSel
            // 
            this.btnUnSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnSel.BackColor = System.Drawing.Color.PaleGreen;
            this.btnUnSel.Location = new System.Drawing.Point(153, 2);
            this.btnUnSel.Name = "btnUnSel";
            this.btnUnSel.Size = new System.Drawing.Size(40, 20);
            this.btnUnSel.TabIndex = 89;
            this.btnUnSel.Text = "反选";
            this.btnUnSel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUnSel.UseVisualStyleBackColor = false;
            this.btnUnSel.Click += new System.EventHandler(this.btnUnSel_Click);
            // 
            // cmbLX
            // 
            this.cmbLX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbLX.Items.AddRange(new object[] {
            "全部",
            "领药",
            "退药"});
            this.cmbLX.Location = new System.Drawing.Point(296, 1);
            this.cmbLX.Name = "cmbLX";
            this.cmbLX.Size = new System.Drawing.Size(53, 20);
            this.cmbLX.TabIndex = 6;
            this.cmbLX.SelectedIndexChanged += new System.EventHandler(this.cmbSFEXECDEPT_SelectedIndexChanged);
            // 
            // cmbSFEXECDEPT
            // 
            this.cmbSFEXECDEPT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSFEXECDEPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSFEXECDEPT.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSFEXECDEPT.Location = new System.Drawing.Point(197, 1);
            this.cmbSFEXECDEPT.Name = "cmbSFEXECDEPT";
            this.cmbSFEXECDEPT.Size = new System.Drawing.Size(96, 20);
            this.cmbSFEXECDEPT.TabIndex = 5;
            this.cmbSFEXECDEPT.SelectedIndexChanged += new System.EventHandler(this.cmbSFEXECDEPT_SelectedIndexChanged);
            // 
            // myDataGridXX
            // 
            this.myDataGridXX.AllowSorting = false;
            this.myDataGridXX.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGridXX.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGridXX.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGridXX.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGridXX.CaptionText = "药品发送消息列表";
            this.myDataGridXX.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGridXX.ContextMenuStrip = this.contextMenuStripQXtld;
            this.myDataGridXX.DataMember = "";
            this.myDataGridXX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridXX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGridXX.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGridXX.Location = new System.Drawing.Point(0, 0);
            this.myDataGridXX.Name = "myDataGridXX";
            this.myDataGridXX.ReadOnly = true;
            this.myDataGridXX.RowHeaderWidth = 50;
            this.myDataGridXX.Size = new System.Drawing.Size(352, 142);
            this.myDataGridXX.TabIndex = 4;
            this.myDataGridXX.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle4});
            this.myDataGridXX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myDataGridXX_MouseClick);
            this.myDataGridXX.Click += new System.EventHandler(this.myDataGridXX_Click);
            // 
            // dataGridTableStyle4
            // 
            this.dataGridTableStyle4.AllowSorting = false;
            this.dataGridTableStyle4.DataGrid = this.myDataGridXX;
            this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle4.RowHeaderWidth = 25;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter4.Location = new System.Drawing.Point(0, 272);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(352, 4);
            this.splitter4.TabIndex = 1;
            this.splitter4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbTLEXECDEPT);
            this.panel1.Controls.Add(this.myDataGridFY);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 272);
            this.panel1.TabIndex = 0;
            // 
            // cmbTLEXECDEPT
            // 
            this.cmbTLEXECDEPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTLEXECDEPT.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTLEXECDEPT.Location = new System.Drawing.Point(121, 1);
            this.cmbTLEXECDEPT.Name = "cmbTLEXECDEPT";
            this.cmbTLEXECDEPT.Size = new System.Drawing.Size(96, 20);
            this.cmbTLEXECDEPT.TabIndex = 4;
            this.cmbTLEXECDEPT.SelectedIndexChanged += new System.EventHandler(this.cmbTLEXECDEPT_SelectedIndexChanged);
            // 
            // myDataGridFY
            // 
            this.myDataGridFY.AllowSorting = false;
            this.myDataGridFY.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGridFY.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGridFY.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGridFY.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGridFY.CaptionText = "药品统领信息列表";
            this.myDataGridFY.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGridFY.DataMember = "";
            this.myDataGridFY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridFY.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGridFY.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGridFY.Location = new System.Drawing.Point(0, 0);
            this.myDataGridFY.Name = "myDataGridFY";
            this.myDataGridFY.ReadOnly = true;
            this.myDataGridFY.RowHeaderWidth = 50;
            this.myDataGridFY.Size = new System.Drawing.Size(352, 272);
            this.myDataGridFY.TabIndex = 3;
            this.myDataGridFY.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle6});
            this.myDataGridFY.CurrentCellChanged += new System.EventHandler(this.myDataGridFY_CurrentCellChanged);
            // 
            // dataGridTableStyle6
            // 
            this.dataGridTableStyle6.AllowSorting = false;
            this.dataGridTableStyle6.DataGrid = this.myDataGridFY;
            this.dataGridTableStyle6.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle6.RowHeaderWidth = 25;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 80);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(912, 1);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel上
            // 
            this.panel上.Controls.Add(this.bt发送药品);
            this.panel上.Controls.Add(this.bt显示缺药消息);
            this.panel上.Controls.Add(this.bt发送);
            this.panel上.Controls.Add(this.bt删除);
            this.panel上.Controls.Add(this.bt显示统领单);
            this.panel上.Controls.Add(this.bt刷新消息);
            this.panel上.Controls.Add(this.bt打印明细单);
            this.panel上.Controls.Add(this.bt打印统领单);
            this.panel上.Controls.Add(this.bt退出);
            this.panel上.Controls.Add(this.groupBox2);
            this.panel上.Controls.Add(this.button4);
            this.panel上.Controls.Add(this.groupBox1);
            this.panel上.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel上.Location = new System.Drawing.Point(0, 0);
            this.panel上.Name = "panel上";
            this.panel上.Size = new System.Drawing.Size(912, 80);
            this.panel上.TabIndex = 0;
            // 
            // bt发送药品
            // 
            this.bt发送药品.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt发送药品.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt发送药品.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt发送药品.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt发送药品.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt发送药品.ImageIndex = 4;
            this.bt发送药品.Location = new System.Drawing.Point(208, 16);
            this.bt发送药品.Name = "bt发送药品";
            this.bt发送药品.Size = new System.Drawing.Size(64, 48);
            this.bt发送药品.TabIndex = 100;
            this.bt发送药品.Text = "发送药品(&Y)";
            this.bt发送药品.Click += new System.EventHandler(this.bt发送药品_Click);
            // 
            // bt显示缺药消息
            // 
            this.bt显示缺药消息.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt显示缺药消息.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt显示缺药消息.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt显示缺药消息.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt显示缺药消息.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt显示缺药消息.ImageIndex = 4;
            this.bt显示缺药消息.Location = new System.Drawing.Point(632, 16);
            this.bt显示缺药消息.Name = "bt显示缺药消息";
            this.bt显示缺药消息.Size = new System.Drawing.Size(64, 48);
            this.bt显示缺药消息.TabIndex = 52;
            this.bt显示缺药消息.Text = "显示缺药消息(&Q)";
            this.bt显示缺药消息.Click += new System.EventHandler(this.bt显示缺药消息_Click);
            // 
            // bt发送
            // 
            this.bt发送.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt发送.Enabled = false;
            this.bt发送.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt发送.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt发送.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt发送.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt发送.ImageIndex = 4;
            this.bt发送.Location = new System.Drawing.Point(776, 16);
            this.bt发送.Name = "bt发送";
            this.bt发送.Size = new System.Drawing.Size(64, 48);
            this.bt发送.TabIndex = 51;
            this.bt发送.Text = "缺药消息发送(&S)";
            this.bt发送.Click += new System.EventHandler(this.bt发送_Click);
            // 
            // bt删除
            // 
            this.bt删除.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt删除.Enabled = false;
            this.bt删除.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt删除.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt删除.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt删除.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt删除.ImageIndex = 4;
            this.bt删除.Location = new System.Drawing.Point(704, 16);
            this.bt删除.Name = "bt删除";
            this.bt删除.Size = new System.Drawing.Size(64, 48);
            this.bt删除.TabIndex = 50;
            this.bt删除.Text = "缺药消息删除(&D)";
            this.bt删除.Click += new System.EventHandler(this.bt删除_Click);
            // 
            // bt显示统领单
            // 
            this.bt显示统领单.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt显示统领单.Enabled = false;
            this.bt显示统领单.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt显示统领单.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt显示统领单.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt显示统领单.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt显示统领单.ImageIndex = 4;
            this.bt显示统领单.Location = new System.Drawing.Point(352, 16);
            this.bt显示统领单.Name = "bt显示统领单";
            this.bt显示统领单.Size = new System.Drawing.Size(96, 48);
            this.bt显示统领单.TabIndex = 49;
            this.bt显示统领单.Text = "显示统领单和明细单(&L)";
            this.bt显示统领单.Click += new System.EventHandler(this.bt显示统领单_Click);
            // 
            // bt刷新消息
            // 
            this.bt刷新消息.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt刷新消息.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt刷新消息.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt刷新消息.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt刷新消息.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt刷新消息.ImageIndex = 4;
            this.bt刷新消息.Location = new System.Drawing.Point(280, 16);
            this.bt刷新消息.Name = "bt刷新消息";
            this.bt刷新消息.Size = new System.Drawing.Size(64, 48);
            this.bt刷新消息.TabIndex = 0;
            this.bt刷新消息.Text = "刷新消息(&X)";
            this.bt刷新消息.Click += new System.EventHandler(this.bt刷新消息_Click);
            // 
            // bt打印明细单
            // 
            this.bt打印明细单.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt打印明细单.Enabled = false;
            this.bt打印明细单.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt打印明细单.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt打印明细单.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt打印明细单.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt打印明细单.ImageIndex = 4;
            this.bt打印明细单.Location = new System.Drawing.Point(544, 16);
            this.bt打印明细单.Name = "bt打印明细单";
            this.bt打印明细单.Size = new System.Drawing.Size(80, 48);
            this.bt打印明细单.TabIndex = 45;
            this.bt打印明细单.Text = "打印明细单(&M)";
            this.bt打印明细单.Click += new System.EventHandler(this.bt打印明细单_Click);
            // 
            // bt打印统领单
            // 
            this.bt打印统领单.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt打印统领单.Enabled = false;
            this.bt打印统领单.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt打印统领单.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt打印统领单.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt打印统领单.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt打印统领单.ImageIndex = 4;
            this.bt打印统领单.Location = new System.Drawing.Point(456, 16);
            this.bt打印统领单.Name = "bt打印统领单";
            this.bt打印统领单.Size = new System.Drawing.Size(80, 48);
            this.bt打印统领单.TabIndex = 44;
            this.bt打印统领单.Text = "打印统领单(&T)";
            this.bt打印统领单.Click += new System.EventHandler(this.bt打印统领单_Click);
            // 
            // bt退出
            // 
            this.bt退出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt退出.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt退出.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt退出.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt退出.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt退出.ImageIndex = 4;
            this.bt退出.Location = new System.Drawing.Point(848, 16);
            this.bt退出.Name = "bt退出";
            this.bt退出.Size = new System.Drawing.Size(48, 48);
            this.bt退出.TabIndex = 43;
            this.bt退出.Text = "退出(&E)";
            this.bt退出.Click += new System.EventHandler(this.bt退出_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(8, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(80, 72);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择状态";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(8, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "已发药";
            this.radioButton2.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(64, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "未发药";
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.ImageIndex = 4;
            this.button4.Location = new System.Drawing.Point(200, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(704, 64);
            this.button4.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpBeginDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtpEndDate);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(96, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 72);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择日期";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "从：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.CustomFormat = "";
            this.dtpBeginDate.Location = new System.Drawing.Point(40, 16);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(112, 21);
            this.dtpBeginDate.TabIndex = 10;
            this.dtpBeginDate.Value = new System.DateTime(2003, 9, 27, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "到：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DtpEndDate
            // 
            this.DtpEndDate.Location = new System.Drawing.Point(40, 45);
            this.DtpEndDate.Name = "DtpEndDate";
            this.DtpEndDate.Size = new System.Drawing.Size(112, 21);
            this.DtpEndDate.TabIndex = 7;
            this.DtpEndDate.Value = new System.DateTime(2003, 9, 27, 23, 59, 0, 0);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(152, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(16, 16);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "查历史表";
            this.checkBox1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(918, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "预领信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 73);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(912, 429);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bt反选1);
            this.panel5.Controls.Add(this.bt全选1);
            this.panel5.Controls.Add(this.dataGridEx1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(187, 429);
            this.panel5.TabIndex = 91;
            // 
            // bt反选1
            // 
            this.bt反选1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt反选1.BackColor = System.Drawing.Color.PaleGreen;
            this.bt反选1.Location = new System.Drawing.Point(141, 2);
            this.bt反选1.Name = "bt反选1";
            this.bt反选1.Size = new System.Drawing.Size(37, 20);
            this.bt反选1.TabIndex = 85;
            this.bt反选1.Text = "反选";
            this.bt反选1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt反选1.UseVisualStyleBackColor = false;
            this.bt反选1.Click += new System.EventHandler(this.bt反选1_Click);
            // 
            // bt全选1
            // 
            this.bt全选1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt全选1.BackColor = System.Drawing.Color.PaleGreen;
            this.bt全选1.Location = new System.Drawing.Point(98, 2);
            this.bt全选1.Name = "bt全选1";
            this.bt全选1.Size = new System.Drawing.Size(37, 20);
            this.bt全选1.TabIndex = 84;
            this.bt全选1.Text = "全选";
            this.bt全选1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt全选1.UseVisualStyleBackColor = false;
            this.bt全选1.Click += new System.EventHandler(this.bt全选1_Click);
            // 
            // dataGridEx1
            // 
            this.dataGridEx1.AllowSorting = false;
            this.dataGridEx1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridEx1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridEx1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridEx1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridEx1.CaptionText = "病人列表";
            this.dataGridEx1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridEx1.DataMember = "";
            this.dataGridEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEx1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridEx1.Name = "dataGridEx1";
            this.dataGridEx1.ReadOnly = true;
            this.dataGridEx1.Size = new System.Drawing.Size(187, 429);
            this.dataGridEx1.TabIndex = 86;
            this.dataGridEx1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.dataGridEx1.Click += new System.EventHandler(this.dataGridEx1_Click);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.AllowSorting = false;
            this.dataGridTableStyle3.DataGrid = this.dataGridEx1;
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.ReadOnly = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
            this.tabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabControl2.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.Controls.Add(this.label3);
            this.tabControl2.Controls.Add(this.button1);
            this.tabControl2.Controls.Add(this.serchText1);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl2.IDEPixelBorder = false;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.SelectedTab = this.tabPage4;
            this.tabControl2.ShowArrows = false;
            this.tabControl2.ShowClose = false;
            this.tabControl2.Size = new System.Drawing.Size(721, 429);
            this.tabControl2.TabIndex = 4;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage4});
            this.tabControl2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.TextInactiveColor = System.Drawing.Color.Black;
            this.tabControl2.SelectionChanged += new System.EventHandler(this.tabControl2_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(578, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 14);
            this.label3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 9F);
            this.button1.Location = new System.Drawing.Point(476, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "显示汇总金额";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serchText1
            // 
            this.serchText1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serchText1.Location = new System.Drawing.Point(649, 4);
            this.serchText1.Name = "serchText1";
            this.serchText1.Size = new System.Drawing.Size(72, 22);
            this.serchText1.TabIndex = 6;
            this.serchText1.textimage = null;
            this.serchText1.Visible = false;
            this.serchText1.Js += new ts_zyhs_ypxx.Mydelegte(this.serchText1_Js);
            this.serchText1.fz += new ts_zyhs_ypxx.Mydelegte(this.serchText1_fz);
            this.serchText1.TextChage += new ts_zyhs_ypxx.Mydelegte(this.serchText1_TextChage);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Controls.Add(this.panel6);
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(721, 404);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Title = "消息明细";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgYPMX);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(721, 364);
            this.panel4.TabIndex = 2;
            // 
            // dgYPMX
            // 
            this.dgYPMX.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgYPMX.CaptionVisible = false;
            this.dgYPMX.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dgYPMX.ContextMenuStrip = this.contextMenuStrip1;
            this.dgYPMX.DataMember = "";
            this.dgYPMX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgYPMX.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgYPMX.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgYPMX.Location = new System.Drawing.Point(0, 0);
            this.dgYPMX.Name = "dgYPMX";
            this.dgYPMX.ReadOnly = true;
            this.dgYPMX.Size = new System.Drawing.Size(721, 364);
            this.dgYPMX.TabIndex = 0;
            this.dgYPMX.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgYPMX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgYPMX_MouseClick);
            this.dgYPMX.DoubleClick += new System.EventHandler(this.dgYPMX_DoubleClick);
            this.dgYPMX.Click += new System.EventHandler(this.dgYPMX_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.dgYPMX;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.cmbTlfl);
            this.panel6.Controls.Add(this.btUnSelect);
            this.panel6.Controls.Add(this.btSelect);
            this.panel6.Controls.Add(this.btClean);
            this.panel6.Controls.Add(this.btSeek);
            this.panel6.Controls.Add(this.txtjx);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.txtypmc);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(721, 40);
            this.panel6.TabIndex = 1;
            // 
            // cmbTlfl
            // 
            this.cmbTlfl.FormattingEnabled = true;
            this.cmbTlfl.Location = new System.Drawing.Point(358, 8);
            this.cmbTlfl.Name = "cmbTlfl";
            this.cmbTlfl.Size = new System.Drawing.Size(99, 22);
            this.cmbTlfl.TabIndex = 12;
            // 
            // btUnSelect
            // 
            this.btUnSelect.BackColor = System.Drawing.SystemColors.Control;
            this.btUnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUnSelect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btUnSelect.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btUnSelect.Location = new System.Drawing.Point(56, 7);
            this.btUnSelect.Name = "btUnSelect";
            this.btUnSelect.Size = new System.Drawing.Size(40, 27);
            this.btUnSelect.TabIndex = 11;
            this.btUnSelect.Text = "反选";
            this.btUnSelect.UseVisualStyleBackColor = false;
            this.btUnSelect.Click += new System.EventHandler(this.btUnSelect_Click);
            // 
            // btSelect
            // 
            this.btSelect.BackColor = System.Drawing.SystemColors.Control;
            this.btSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSelect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSelect.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btSelect.Location = new System.Drawing.Point(10, 7);
            this.btSelect.Name = "btSelect";
            this.btSelect.Size = new System.Drawing.Size(40, 27);
            this.btSelect.TabIndex = 10;
            this.btSelect.Text = "全选";
            this.btSelect.UseVisualStyleBackColor = false;
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);
            // 
            // btClean
            // 
            this.btClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClean.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClean.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btClean.Location = new System.Drawing.Point(638, 7);
            this.btClean.Name = "btClean";
            this.btClean.Size = new System.Drawing.Size(48, 27);
            this.btClean.TabIndex = 9;
            this.btClean.Text = "清除";
            this.btClean.Click += new System.EventHandler(this.btClean_Click);
            // 
            // btSeek
            // 
            this.btSeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSeek.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSeek.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btSeek.Location = new System.Drawing.Point(584, 7);
            this.btSeek.Name = "btSeek";
            this.btSeek.Size = new System.Drawing.Size(48, 27);
            this.btSeek.TabIndex = 4;
            this.btSeek.Text = "查询";
            this.btSeek.Click += new System.EventHandler(this.btSeek_Click);
            // 
            // txtjx
            // 
            this.txtjx.Location = new System.Drawing.Point(490, 8);
            this.txtjx.Name = "txtjx";
            this.txtjx.Size = new System.Drawing.Size(88, 23);
            this.txtjx.TabIndex = 2;
            this.txtjx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtjx_KeyUp);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(457, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "剂型";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(296, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "统领类型";
            // 
            // txtypmc
            // 
            this.txtypmc.Location = new System.Drawing.Point(167, 8);
            this.txtypmc.Name = "txtypmc";
            this.txtypmc.Size = new System.Drawing.Size(128, 23);
            this.txtypmc.TabIndex = 0;
            this.txtypmc.Tag = "0";
            this.txtypmc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtypmc_KeyUp);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(104, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "药品名称";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox6);
            this.panel3.Controls.Add(this.btnFszdyf);
            this.panel3.Controls.Add(this.CbZCy);
            this.panel3.Controls.Add(this.btExit);
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.bt生成统领单);
            this.panel3.Controls.Add(this.bt刷新药品信息);
            this.panel3.Controls.Add(this.button11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(912, 70);
            this.panel3.TabIndex = 3;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkDQ);
            this.groupBox6.Controls.Add(this.checkLsk);
            this.groupBox6.Location = new System.Drawing.Point(300, 26);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(137, 41);
            this.groupBox6.TabIndex = 118;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "选择";
            // 
            // checkDQ
            // 
            this.checkDQ.AutoSize = true;
            this.checkDQ.Checked = true;
            this.checkDQ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkDQ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkDQ.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkDQ.Location = new System.Drawing.Point(4, 20);
            this.checkDQ.Name = "checkDQ";
            this.checkDQ.Size = new System.Drawing.Size(57, 16);
            this.checkDQ.TabIndex = 118;
            this.checkDQ.Text = "当前库";
            this.checkDQ.UseVisualStyleBackColor = true;
            this.checkDQ.CheckedChanged += new System.EventHandler(this.checkDQ_CheckedChanged);
            // 
            // checkLsk
            // 
            this.checkLsk.AutoSize = true;
            this.checkLsk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkLsk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkLsk.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkLsk.Location = new System.Drawing.Point(67, 20);
            this.checkLsk.Name = "checkLsk";
            this.checkLsk.Size = new System.Drawing.Size(57, 16);
            this.checkLsk.TabIndex = 117;
            this.checkLsk.Text = "历史库";
            this.checkLsk.UseVisualStyleBackColor = true;
            this.checkLsk.Visible = false;
            this.checkLsk.CheckedChanged += new System.EventHandler(this.checkLsk_CheckedChanged);
            // 
            // btnFszdyf
            // 
            this.btnFszdyf.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFszdyf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFszdyf.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFszdyf.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnFszdyf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFszdyf.ImageIndex = 4;
            this.btnFszdyf.Location = new System.Drawing.Point(821, 12);
            this.btnFszdyf.Name = "btnFszdyf";
            this.btnFszdyf.Size = new System.Drawing.Size(90, 46);
            this.btnFszdyf.TabIndex = 116;
            this.btnFszdyf.Text = "发送暂存药到指定药房(&f)";
            this.btnFszdyf.Visible = false;
            this.btnFszdyf.Click += new System.EventHandler(this.btnFszdyf_Click);
            // 
            // CbZCy
            // 
            this.CbZCy.AutoSize = true;
            this.CbZCy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbZCy.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CbZCy.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.CbZCy.Location = new System.Drawing.Point(301, 7);
            this.CbZCy.Name = "CbZCy";
            this.CbZCy.Size = new System.Drawing.Size(65, 18);
            this.CbZCy.TabIndex = 115;
            this.CbZCy.Text = "暂存药";
            this.CbZCy.UseVisualStyleBackColor = true;
            this.CbZCy.CheckedChanged += new System.EventHandler(this.CbZCy_CheckedChanged);
            // 
            // btExit
            // 
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btExit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.ImageIndex = 4;
            this.btExit.Location = new System.Drawing.Point(761, 12);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(50, 46);
            this.btExit.TabIndex = 114;
            this.btExit.Text = "退出(&E)";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbZxyf);
            this.groupBox5.Location = new System.Drawing.Point(443, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(120, 60);
            this.groupBox5.TabIndex = 113;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "执行药房";
            // 
            // cmbZxyf
            // 
            this.cmbZxyf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbZxyf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZxyf.FormattingEnabled = true;
            this.cmbZxyf.Location = new System.Drawing.Point(6, 23);
            this.cmbZxyf.Name = "cmbZxyf";
            this.cmbZxyf.Size = new System.Drawing.Size(108, 20);
            this.cmbZxyf.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbTy);
            this.groupBox4.Controls.Add(this.rbLy);
            this.groupBox4.Location = new System.Drawing.Point(221, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(77, 60);
            this.groupBox4.TabIndex = 112;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "领药类型";
            // 
            // rbTy
            // 
            this.rbTy.AutoSize = true;
            this.rbTy.Location = new System.Drawing.Point(6, 40);
            this.rbTy.Name = "rbTy";
            this.rbTy.Size = new System.Drawing.Size(47, 16);
            this.rbTy.TabIndex = 1;
            this.rbTy.Tag = "1";
            this.rbTy.Text = "退药";
            this.rbTy.UseVisualStyleBackColor = true;
            this.rbTy.CheckedChanged += new System.EventHandler(this.bt刷新药品信息_Click);
            // 
            // rbLy
            // 
            this.rbLy.AutoSize = true;
            this.rbLy.Checked = true;
            this.rbLy.Location = new System.Drawing.Point(6, 18);
            this.rbLy.Name = "rbLy";
            this.rbLy.Size = new System.Drawing.Size(47, 16);
            this.rbLy.TabIndex = 0;
            this.rbLy.TabStop = true;
            this.rbLy.Tag = "0";
            this.rbLy.Text = "领药";
            this.rbLy.UseVisualStyleBackColor = true;
            this.rbLy.CheckedChanged += new System.EventHandler(this.bt刷新药品信息_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbAll);
            this.groupBox3.Controls.Add(this.rbOut);
            this.groupBox3.Controls.Add(this.rbTempOut);
            this.groupBox3.Controls.Add(this.rbIn);
            this.groupBox3.Controls.Add(this.rbTszl);
            this.groupBox3.Controls.Add(this.rbTrans);
            this.groupBox3.Location = new System.Drawing.Point(0, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 60);
            this.groupBox3.TabIndex = 111;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "病人状态";
            // 
            // rbAll
            // 
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(155, 34);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(57, 24);
            this.rbAll.TabIndex = 6;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "全部";
            // 
            // rbOut
            // 
            this.rbOut.Location = new System.Drawing.Point(155, 15);
            this.rbOut.Name = "rbOut";
            this.rbOut.Size = new System.Drawing.Size(57, 24);
            this.rbOut.TabIndex = 3;
            this.rbOut.Text = "出院";
            this.rbOut.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbTempOut
            // 
            this.rbTempOut.Location = new System.Drawing.Point(75, 15);
            this.rbTempOut.Name = "rbTempOut";
            this.rbTempOut.Size = new System.Drawing.Size(57, 24);
            this.rbTempOut.TabIndex = 2;
            this.rbTempOut.Text = "出区";
            this.rbTempOut.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbIn
            // 
            this.rbIn.Location = new System.Drawing.Point(12, 15);
            this.rbIn.Name = "rbIn";
            this.rbIn.Size = new System.Drawing.Size(57, 24);
            this.rbIn.TabIndex = 1;
            this.rbIn.Text = "在院";
            this.rbIn.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbTszl
            // 
            this.rbTszl.Location = new System.Drawing.Point(75, 34);
            this.rbTszl.Name = "rbTszl";
            this.rbTszl.Size = new System.Drawing.Size(74, 24);
            this.rbTszl.TabIndex = 5;
            this.rbTszl.Text = "特殊治疗";
            this.rbTszl.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbTrans
            // 
            this.rbTrans.Location = new System.Drawing.Point(12, 34);
            this.rbTrans.Name = "rbTrans";
            this.rbTrans.Size = new System.Drawing.Size(74, 24);
            this.rbTrans.TabIndex = 4;
            this.rbTrans.Text = "转科";
            this.rbTrans.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // bt生成统领单
            // 
            this.bt生成统领单.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt生成统领单.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt生成统领单.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt生成统领单.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt生成统领单.ImageIndex = 4;
            this.bt生成统领单.Location = new System.Drawing.Point(672, 12);
            this.bt生成统领单.Name = "bt生成统领单";
            this.bt生成统领单.Size = new System.Drawing.Size(87, 46);
            this.bt生成统领单.TabIndex = 110;
            this.bt生成统领单.Text = "生成统领单(&S)";
            this.bt生成统领单.Click += new System.EventHandler(this.bt生成统领单_Click);
            // 
            // bt刷新药品信息
            // 
            this.bt刷新药品信息.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt刷新药品信息.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt刷新药品信息.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt刷新药品信息.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt刷新药品信息.ImageIndex = 4;
            this.bt刷新药品信息.Location = new System.Drawing.Point(583, 12);
            this.bt刷新药品信息.Name = "bt刷新药品信息";
            this.bt刷新药品信息.Size = new System.Drawing.Size(87, 46);
            this.bt刷新药品信息.TabIndex = 101;
            this.bt刷新药品信息.Text = "刷新药品信息(&R)";
            this.bt刷新药品信息.Click += new System.EventHandler(this.bt刷新药品信息_Click);
            // 
            // button11
            // 
            this.button11.Enabled = false;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.ImageIndex = 4;
            this.button11.Location = new System.Drawing.Point(567, 5);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(248, 61);
            this.button11.TabIndex = 102;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(926, 531);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel7);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(918, 505);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "成本节约处理";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(912, 499);
            this.panel7.TabIndex = 1;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel8);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(918, 505);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "药品上缴记录查询";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(912, 499);
            this.panel8.TabIndex = 2;
            // 
            // frmYPXX
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(926, 531);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmYPXX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYPXX_Load);
            this.Activated += new System.EventHandler(this.frmYPXX_Activated);
            this.contextMenuStripQXtld.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel总.ResumeLayout(false);
            this.panel下.ResumeLayout(false);
            this.panel右.ResumeLayout(false);
            this.panel右下.ResumeLayout(false);
            this.panelMX.ResumeLayout(false);
            this.panelMX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridMX)).EndInit();
            this.panelQY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridQY)).EndInit();
            this.panel右上.ResumeLayout(false);
            this.panel右上.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridTL)).EndInit();
            this.panel左.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridXX)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridFY)).EndInit();
            this.panel上.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEx1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControl2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgYPMX)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        DataTable yptb = new DataTable();
        private void frmYPXX_Load(object sender, System.EventArgs e)
        {


            //tabPage1.Font = new Font("宋体", (float)Convert.ToDouble(Constant.MenuFontSize == "" ? "9" : Constant.MenuFontSize));
            //tabPage2.Font = new Font("宋体", (float)Convert.ToDouble(Constant.MenuFontSize == "" ? "9" : Constant.MenuFontSize));
            //未结算总费用是否统计当前日期算
            SystemCfg cfg7108 = new SystemCfg(7108);
            if (cfg7108.Config == "0")
            {
                CbZCy.Enabled = false;
                bt发送药品.Enabled = true;
            }
            else
            {
                CbZCy.Enabled = true;
                bt发送药品.Enabled = false;
            }
            //Modify By Tany 2011-01-18 移到上面
            if ((new SystemCfg(7022).Config) == "是")
            {
                tabControl1.SelectedTab = tabControl1.TabPages[1];
            }

            LoadPatient();

            DateTime dt = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.dtpBeginDate.Value = Convert.ToDateTime(dt.ToShortDateString() + " 00:00:00");
            this.DtpEndDate.Value = Convert.ToDateTime(dt.ToShortDateString() + " 23:59:59");

            dtpBeginDate.MinDate = dt.AddDays(-1 * Convert.ToInt32(new SystemCfg(7028).Config));

            //myDataGridFY 统领信息 
            string[] GrdMappingName1 ={ "发药批次", "单据号", "发药时间", "发药科室", "领药科室", "发药员", "配药员", };
            int[] GrdWidth1 ={ 0, 6, 16, 10, 10, 8, 8 };
            int[] Alignment1 ={ 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGridFY);

            //myDataGridXX 发送信息
            string[] GrdMappingName4 ={ "选", "发送时间", "发药科室", "类型", "APPLY_ID", "领药分类", "领药科室", "发送人" };//add by zouchihua 2012-10-8 增加发要人
            int[] GrdWidth4 ={ 2, 18, 12, 8, 0, 12, 12, 10 };
            int[] Alignment4 ={ 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly4 ={ 1, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName4, GrdWidth4, Alignment4, ReadOnly4, this.myDataGridXX);

            //myDataGridTL 统领单
            string[] GrdMappingName2 ={ "编号", "名称", "规格", "数量", "单位", "单价", "金额", "麻毒否", "贵重否", "发药科室", "领药科室", "统领分类" };
            int[] GrdWidth2 ={ 8, 30, 14, 8, 6, 8, 8, 6, 6, 6, 6, 8 };
            int[] Alignment2 ={ 0, 0, 0, 2, 1, 2, 2, 1, 1, 1, 1, 0 };
            int[] ReadOnly2 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName2, GrdWidth2, Alignment2, ReadOnly2, this.myDataGridTL);

            //myDataGridMX 明细单
            string[] GrdMappingName3 ={ "选", "床号", "住院号", "姓名", "日期", "编号", "名称", "规格", "数量", "单位", "单价", "金额", "麻毒否", "贵重否", "id", "INPATIENT_ID", "baby_id", "fee_id", "xmid", "TLFL" };
            int[] GrdWidth3 ={ 2, 4, 9, 8, 6, 8, 28, 12, 6, 6, 8, 8, 0, 0, 0, 0, 0, 0, 0, 8 };
            int[] Alignment3 ={ 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 2, 1, 1, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly3 ={ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName3, GrdWidth3, Alignment3, ReadOnly3, this.myDataGridMX);

            //myDataGrid5 缺药信息  id是zy_fee_speci表的id
            string[] GrdMappingName5 ={"选","床号","住院号","姓名","领药日期","编号","名称","规格","数量","单位","单价","金额","备注","领药科室","发药科室",
										 "麻毒否","贵重否","id","mngtype","group_id","inpatient_id","baby_id","fee_id"};
            int[] GrdWidth5 ={ 2, 4, 9, 8, 10, 8, 28, 12, 6, 6, 8, 8, 30, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] Alignment5 ={ 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly5 ={ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName5, GrdWidth5, Alignment5, ReadOnly5, this.myDataGridQY);

            //Add By Tany 2011-03-07
            myDataGridFY.isShowRowHeadId = true;
            myDataGridXX.isShowRowHeadId = true;
            myDataGridTL.isShowRowHeadId = true;
            myDataGridMX.isShowRowHeadId = true;
            myDataGridQY.isShowRowHeadId = true;
            myDataGridFY.TableStyles[0].RowHeaderWidth = 25;
            myDataGridXX.TableStyles[0].RowHeaderWidth = 25;
            myDataGridTL.TableStyles[0].RowHeaderWidth = 25;
            myDataGridMX.TableStyles[0].RowHeaderWidth = 25;
            myDataGridQY.TableStyles[0].RowHeaderWidth = 25;

            //Add By Tany 2011-01-24 加入缺药排序
            //从第2列开始取
            cmbSort.Items.Clear();
            for (int i = 1; i < GrdMappingName5.Length; i++)
            {
                if (GrdWidth5[i] > 0)
                {
                    cmbSort.Items.Add(GrdMappingName5[i]);
                }
            }

            //初始化领药明细
            CshMxGrid(this.dgYPMX);

            this.panelMX.Visible = true;
            this.panelQY.Visible = false;

            AddYF();

            AddZXYF();

            Yp.Addcmbtlfl(cmbTlfl, InstanceForm.BDatabase);

            try
            {
                //add by zouchihua 
                string ypsql = "select ypspm 药品名,ypgg 规格,s_sccj 厂家,dbo.fun_yp_ypdw(ypdw) 单位,1 dwbl,pfj 批发价,lsj 零售价,shh,a.ggid,cjid, PYM,WBM from vi_yf_kcmx a,yp_ypbm b " +
                                    "where a.ggid=b.ggid and deptid=" + cmbZxyf.SelectedValue.ToString() + " and bdelete_kc=0 and a.ypzlx in(select ypzlx from yp_gllx where deptid=" + cmbZxyf.SelectedValue.ToString() + ")  ";
                yptb = FrmMdiMain.Database.GetDataTable(ypsql);
                this.serchText1.tb = yptb;

                //Modify by zouchihua 2012-4-12
                this.cmbZxyf.SelectedIndexChanged += new System.EventHandler(this.bt刷新药品信息_Click);
                this.bt刷新药品信息_Click(null, null);
                //add by zouchihua 2012-5-24
                SystemCfg cfg7116 = new SystemCfg(7116);
                string cfg = "," + cfg7116.Config + ",";
                if (cfg.Contains(FrmMdiMain.CurrentUser.EmployeeId + ","))
                {
                    this.取消统领单ToolStripMenuItem.Visible = true;
                }
                else
                    this.取消统领单ToolStripMenuItem.Visible = false;
            }
            catch { }
            if (cfg7182.Config.Trim() == "1")
            {
                zcygl = new FrmZcyGl();
                zcygl.Disposed += delegate
                {
                    this.Close();
                };
                InsertWindow iw = new InsertWindow(this.panelZcyGL, zcygl.Handle);
                zcygl.Show();

                zcysj = new FrmZcySj();
                zcysj.Disposed += delegate
               {
                   this.Close();
               };
                iw = new InsertWindow(this.panel7, zcysj.Handle);
                zcysj.Show();


                frmsj = new FrmSjjlcx();
                frmsj.Disposed += delegate
               {
                   this.Close();
               };
                iw = new InsertWindow(this.panel8, frmsj.Handle);
                frmsj.Show();//panel8

            }
            else
            {
                this.tabControl1.TabPages.Remove(this.tabPage3);
                this.tabControl1.TabPages.Remove(this.tabPage5);
                this.tabControl1.TabPages.Remove(this.tabPage6);
            }

            #region 程序控制流程
            //未发药 ================
            //    [刷新消息] 隐藏发药列表，显示消息列表 ，显示药品缺药信息 
            //       [显示统领单]       选择几个消息  -> 显示统领单和明细单，药品消息窗口隐藏
            //已发药 ================
            //    [刷新消息] 显示发药列表，显示消息列表（清空），显示药品缺药信息 
            //    [发药列表单击] 显示对应的所有消息列表（全选），显示统领单，明细单隐藏
            //    [显示统领单]           选择几个消息  -> 显示统领单和明细单，药品消息窗口隐藏
            #endregion
        }
        FrmSjjlcx frmsj = null;
        private void radioButton1_Click(object sender, System.EventArgs e)
        {
            SystemCfg cfg7116 = new SystemCfg(7116);
            string cfg = "," + cfg7116.Config + ",";
            if (this.radioButton1.Checked)
            {
                this.groupBox1.Enabled = false;
                this.btnReSend.Enabled = true;
                this.myDataGridMX.TableStyles[0].AllowSorting = false;
                if (cfg.Contains(FrmMdiMain.CurrentUser.EmployeeId + ","))
                {
                    this.取消统领单ToolStripMenuItem.Visible = true;
                }
                else
                    this.取消统领单ToolStripMenuItem.Visible = false;

            }
            else
            {
                this.groupBox1.Enabled = true;
                this.btnReSend.Enabled = false;
                this.myDataGridMX.TableStyles[0].AllowSorting = true;
                this.取消统领单ToolStripMenuItem.Visible = false;
            }
            this.isFY = this.radioButton2.Checked;

            if (cfg7210.Config.Trim() == "1")
                this.取消统领单ToolStripMenuItem.Visible = true;

            bt刷新消息_Click(sender, e);
        }


        private DataTable myOpenAss(OleDbConnection cCon, string sSql)
        {
            DataTable myTb = new DataTable();
            try
            {
                System.Data.OleDb.OleDbCommand mySelCmd = new OleDbCommand();
                mySelCmd.CommandText = sSql;
                mySelCmd.Connection = cCon;
                mySelCmd.CommandType = System.Data.CommandType.Text;
                System.Data.OleDb.OleDbDataAdapter myAdp = new OleDbDataAdapter();
                myAdp.SelectCommand = mySelCmd;
                myAdp.Fill(myTb);
            }
            catch (System.Data.OleDb.OleDbException err)
            {
                MessageBox.Show(err.ToString());
            }
            return myTb;
        }

        private void ClearRows()
        {
            DataTable myTb1 = (DataTable)this.myDataGridXX.DataSource;
            if (myTb1 != null) myTb1.Rows.Clear();

            DataTable myTb2 = (DataTable)this.myDataGridTL.DataSource;
            if (myTb2 != null) myTb2.Rows.Clear();

            DataTable myTb3 = (DataTable)this.myDataGridMX.DataSource;
            if (myTb3 != null) myTb3.Rows.Clear();
        }


        private void myDataGridFY_CurrentCellChanged(object sender, System.EventArgs e)
        {
            DataTable myTb1 = (DataTable)this.myDataGridFY.DataSource;
            if (myTb1 == null) return;
            if (myTb1.Rows.Count < 1) return;
            int nrow = this.myDataGridFY.CurrentCell.RowNumber;

            this.myDataGridTL.CaptionText = "统领单";

            cmbSFEXECDEPT.Items.Clear();
            cmbLX.Items.Clear();

            string sSql = "SELECT APPLY_DATE 发送时间,dbo.FUN_ZY_SEEKDEPTNAME(EXECDEPT_ID) 发药科室," +
                "        case msg_type when 0 then '领药' else '退药' end 类型, APPLY_ID, isnull(c.name,'其他') 领药分类,dbo.fun_getEmpName(APPLY_NURSE) 发送人" +
                " FROM ZY_APPLY_DRUG a  left join jc_yplyflk c on a.lyflcode=c.code " +
                " WHERE GROUP_ID='" + myTb1.Rows[nrow]["发药批次"].ToString() + "'";
            myFunc.ShowGrid(1, sSql, this.myDataGridXX);

            DataTable myTb2 = (DataTable)this.myDataGridXX.DataSource;
            if (myTb2.Rows.Count < 1) return;
            myFunc.SelectAll(0, this.myDataGridXX);
            xxTb.Clear();
            xxTb = myTb2.Copy();
            GetCmbItem(myTb2, cmbSFEXECDEPT, "发药科室");
            AddCmbLXItem();

            this.panelQY.Visible = true;
            this.panelMX.Visible = false;
            this.bt打印明细单.Enabled = false;
            this.bt打印统领单.Enabled = false;

            sSql = "select shh 编号, ypspm 名称,ypgg 规格,ypsl 数量,ypdw 单位,lsj 单价,lsje 金额,'' as 麻毒否,'' as 贵重否" +
                "  from VI_YF_TLDMX   " +//add by zouchihua 增加历史库检索
                " where GROUPID='" + myTb1.Rows[nrow]["发药批次"].ToString() + "'";
            myFunc.ShowGrid(0, sSql, this.myDataGridTL);
            DataTable myTb3 = (DataTable)this.myDataGridTL.DataSource;
            if (myTb3.Rows.Count < 1) return;
            this.bt打印统领单.Enabled = true;

            //Add by tany 2011-03-07
            myDataGridFY.TableStyles[0].RowHeaderWidth = 25;
            myDataGridXX.TableStyles[0].RowHeaderWidth = 25;
            myDataGridTL.TableStyles[0].RowHeaderWidth = 25;
            myDataGridMX.TableStyles[0].RowHeaderWidth = 25;
            myDataGridQY.TableStyles[0].RowHeaderWidth = 25;
        }


        private void myDataGridQY_Click(object sender, System.EventArgs e)
        {
            //控制BOOL列
            int nrow, ncol;
            nrow = this.myDataGridQY.CurrentCell.RowNumber;
            ncol = this.myDataGridQY.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0 && nrow > 0) this.myDataGridQY.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGridQY.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGridQY.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            //非"选"字段
            if (this.myDataGridQY.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "选") return;
            if (nrow > myTb.Rows.Count - 1) return;

            bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["选"] = isResult;

            //若不是中草药，则处理该组医嘱
            //			if (myTb.Rows[nrow]["编号"].ToString().Substring(0,2)!="ZY") 
            //			{
            //				for(int i=0;i<=myTb.Rows.Count-1;i++)
            //				{
            //					if (     myTb.Rows[i]["inpatient_id"].ToString().Trim()==myTb.Rows[nrow]["inpatient_id"].ToString().Trim() 
            //						&& myTb.Rows[i]["baby_id"].ToString().Trim()==myTb.Rows[nrow]["baby_id"].ToString().Trim() 
            //						&& myTb.Rows[i]["mngtype"].ToString().Trim()==myTb.Rows[nrow]["mngtype"].ToString().Trim() 
            //						&& myTb.Rows[i]["group_id"].ToString().Trim()==myTb.Rows[nrow]["group_id"].ToString().Trim() 
            //						)
            //					{
            //						this.myDataGridQY.CurrentCell=new DataGridCell(i,ncol);
            //						myTb.Rows[i]["选"]=isResult;
            //					}
            //				}
            //			}
            this.myDataGridQY.DataSource = myTb;
        }


        private void bt刷新消息_Click(object sender, System.EventArgs e)
        {
            if (this.DtpEndDate.Value < this.dtpBeginDate.Value)
            {
                MessageBox.Show(this, "对不起，结束日期不能小于开始日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.ClearRows();
            Cursor.Current = PubStaticFun.WaitCursor();

            string sSql = "";
            this.bt显示统领单.Enabled = false;
            this.bt打印统领单.Enabled = false;
            this.bt打印明细单.Enabled = false;

            cmbTLEXECDEPT.Items.Clear();
            cmbSFEXECDEPT.Items.Clear();
            cmbLX.Items.Clear();

            myDataGridTL.CaptionText = "统领单";

            if (isFY)
            {
                //已发药的统领信息								
                sSql = "SELECT groupid 发药批次,djh 单据号,fyrq 发药时间,dbo.FUN_ZY_SEEKDEPTNAME(deptid) 发药科室,b.name 领药科室,dbo.FUN_ZY_SEEKEmployeeName(fyr) 发药员, dbo.FUN_ZY_SEEKEmployeeName(pyr) 配药员 " +
                    " from VI_YF_TLD  a left join jc_dept_property b on a.dept_ly=b.dept_id" +
                    " where (DEPT_LY = " + InstanceForm.BCurrentDept.DeptId + " or dept_ly in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "'))" +
                    "       and fyrq between '" + this.dtpBeginDate.Value.ToString() + "' and '" + this.DtpEndDate.Value.ToString() + "'";
                myFunc.ShowGrid(1, sSql, this.myDataGridFY);

                this.panel1.Visible = true;
                DataTable myTb1 = (DataTable)this.myDataGridFY.DataSource;
                if (myTb1.Rows.Count > 0)
                {
                    this.bt显示统领单.Enabled = true;
                    fyTb.Clear();
                    fyTb = myTb1.Copy();
                    GetCmbItem(myTb1, cmbTLEXECDEPT, "发药科室");
                }
            }
            else
            {
                //未发药的消息明细
                sSql = "SELECT APPLY_DATE 发送时间,b.name 发药科室," +
                    "        case msg_type when 0 then '领药' else '退药' end 类型, APPLY_ID, isnull(c.name,'其他') 领药分类,d.name 领药科室,dbo.fun_getEmpName(APPLY_NURSE) 发送人 " +
                    "  FROM ZY_APPLY_DRUG a left join jc_DEPT_PROPERTY b on a.EXECDEPT_ID=b.dept_id  left join jc_yplyflk c on a.lyflcode=c.code " +
                    "  left join jc_dept_property d on a.dept_ly=d.dept_id " +
                    " WHERE (DEPT_LY = " + InstanceForm.BCurrentDept.DeptId + " or dept_ly in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "'))" +
                    "   and isnull(GROUP_ID,DBO.FUN_GETEMPTYGUID())=DBO.FUN_GETEMPTYGUID() and a.delete_bit=0 order by APPLY_DATE";
                myFunc.ShowGrid(1, sSql, this.myDataGridXX);

                DataTable myTb2 = (DataTable)this.myDataGridXX.DataSource;
                this.panel1.Visible = false;
                if (myTb2.Rows.Count > 0)
                {
                    this.bt显示统领单.Enabled = true;
                    xxTb.Clear();
                    xxTb = myTb2.Copy();
                    GetCmbItem(myTb2, cmbSFEXECDEPT, "发药科室");
                    AddCmbLXItem();
                }
            }

            bt显示缺药消息_Click(sender, e);

            //Add by tany 2011-03-07
            myDataGridFY.TableStyles[0].RowHeaderWidth = 25;
            myDataGridXX.TableStyles[0].RowHeaderWidth = 25;
            myDataGridTL.TableStyles[0].RowHeaderWidth = 25;
            myDataGridMX.TableStyles[0].RowHeaderWidth = 25;
            myDataGridQY.TableStyles[0].RowHeaderWidth = 25;

            Cursor.Current = Cursors.Default;
        }

        private void bt显示统领单_Click(object sender, System.EventArgs e)
        {
            string sSql = "";
            int i = 0;
            int isHistroy = this.checkBox1.Checked ? 1 : 0;
            this.bt打印统领单.Enabled = false;
            this.bt打印明细单.Enabled = false;

            sendDept = "";
            execDept = "";
            sendDate = "";
            sendkind = "";
            total = 0;

            DataTable myTb = (DataTable)this.myDataGridXX.DataSource;

            bool isSelect = false;
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (new Guid(myTb.Rows[i]["APPLY_ID"].ToString().Trim()) != Guid.Empty && myTb.Rows[i]["选"].ToString() == "True")
                {
                    if (sendDept == "")
                    {
                        isSelect = true;
                        sendDept = InstanceForm.BCurrentDept.WardId;
                        execDept = myTb.Rows[i]["发药科室"].ToString().Trim();
                        sendDate = myTb.Rows[i]["发送时间"].ToString().Trim();
                        sendkind = myTb.Rows[i]["类型"].ToString().Trim();
                    }
                    else
                    {
                        if (execDept != myTb.Rows[i]["发药科室"].ToString().Trim() && this.isFY == false)
                        {
                            MessageBox.Show(this, "发药科室不一致，不能统计！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //						if (sendkind!=myTb.Rows[i]["类型"].ToString().Trim() && this.isFY==false)
                        //						{
                        //							MessageBox.Show(this,"类型不一致，不能统计！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error); 
                        //							return;
                        //						}
                        //sendDate+="、"+myTb.Rows[i]["发送时间"].ToString().Trim(); modify by Tany 2004-11-18
                        sendDate = myTb.Rows[i]["发送时间"].ToString().Trim();
                    }
                }
            }

            if (isSelect == false)
            {
                MessageBox.Show(this, "没有选择发送消息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor.Current = PubStaticFun.WaitCursor();

                rds.Tables["MedYPMXD"].Clear();
                rds.Tables["MedYPTLD"].Clear();
                int j;
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (new Guid(myTb.Rows[i]["APPLY_ID"].ToString().Trim()) != Guid.Empty && myTb.Rows[i]["选"].ToString() == "True")
                    {
                        DataTable myTb1 = myFunc.GetYPTLD(new Guid(myTb.Rows[i]["APPLY_ID"].ToString()), InstanceForm.BCurrentDept.WardId, 0);//InstanceForm.BDatabase.GetDataTable("call hs_yptld("+Convert.ToDecimal(myTb.Rows[i]["APPLY_ID"])+",0,0,'"+InstanceForm.BCurrentDept.WardId+"')");//
                        if (myTb1.Rows.Count >= 1)
                        {
                            for (j = 0; j <= myTb1.Rows.Count - 1; j++)
                            {
                                dr = rds.Tables["MedYPMXD"].NewRow();
                                dr["选"] = false;
                                dr["床号"] = myTb1.Rows[j]["BED_NO"].ToString();
                                dr["住院号"] = myTb1.Rows[j]["INPATIENT_NO"].ToString();
                                dr["姓名"] = myTb1.Rows[j]["NAME"].ToString();
                                dr["日期"] = Convert.ToDateTime(myTb1.Rows[j]["presc_date"]).Month.ToString() + "-" + Convert.ToDateTime(myTb1.Rows[j]["presc_date"]).Day.ToString();
                                dr["编号"] = myTb1.Rows[j]["SUBCODE"].ToString();
                                dr["名称"] = myTb1.Rows[j]["S_YPSPM"].ToString();
                                dr["规格"] = myTb1.Rows[j]["S_YPGG"].ToString();
                                dr["数量"] = Convert.ToDouble(myTb1.Rows[j]["NUM"]);
                                dr["单位"] = myTb1.Rows[j]["UNIT"].ToString();
                                dr["单价"] = Convert.ToDouble(myTb1.Rows[j]["RETAIL_PRICE"]);
                                dr["金额"] = Convert.ToDouble(myTb1.Rows[j]["ACVALUE"]);
                                dr["麻毒否"] = myTb1.Rows[j]["MZYP"].ToString();
                                dr["贵重否"] = myTb1.Rows[j]["GZYP"].ToString();
                                dr["id"] = j.ToString();
                                dr["baby_id"] = myTb1.Rows[j]["baby_id"].ToString();
                                dr["INPATIENT_ID"] = myTb1.Rows[j]["INPATIENT_ID"].ToString();
                                dr["fee_id"] = myTb1.Rows[j]["fee_id"].ToString();
                                dr["xmid"] = myTb1.Rows[j]["xmid"].ToString();
                                dr["TLFL"] = myTb1.Rows[j]["TLFL"].ToString();
                                rds.Tables["MedYPMXD"].Rows.Add(dr);
                                total += Convert.ToDouble(myTb1.Rows[j]["ACVALUE"]);
                            }
                        }
                        else//清除空记录
                        {
                            if (radioButton1.Checked)
                            {
                                //Add By Tany 2004-12-28 如果真的没有记录了，则删除
                                sSql = "select count(*) from zy_fee_speci where delete_bit=0 and apply_id='" + myTb.Rows[i]["APPLY_ID"].ToString().Trim() + "'";
                                DataTable tmpTb = InstanceForm.BDatabase.GetDataTable(sSql);
                                if (tmpTb.Rows.Count == 0 || tmpTb == null || tmpTb.Rows[0][0].ToString().Trim() == "0")
                                {
                                    sSql = "update zy_apply_drug set delete_bit=1,memo='无药'+convert(varchar,getdate(),120)+' By '+'" + InstanceForm.BCurrentUser.EmployeeId + "' where apply_id='" + myTb.Rows[i]["APPLY_ID"].ToString().Trim() + "'";
                                    InstanceForm.BDatabase.DoCommand(sSql);
                                }
                            }
                        }
                    }
                }


                for (j = 0; j <= rds.Tables["MedYPMXD"].Rows.Count - 1; j++)
                {
                    dr = rds.Tables["MedYPTLD"].NewRow();
                    dr["编号"] = rds.Tables["MedYPMXD"].Rows[j]["编号"].ToString().Trim();
                    dr["名称"] = rds.Tables["MedYPMXD"].Rows[j]["名称"].ToString();
                    dr["规格"] = rds.Tables["MedYPMXD"].Rows[j]["规格"].ToString();
                    dr["单位"] = rds.Tables["MedYPMXD"].Rows[j]["单位"].ToString();
                    dr["单价"] = Convert.ToDouble(rds.Tables["MedYPMXD"].Rows[j]["单价"]);
                    dr["数量"] = Convert.ToDouble(rds.Tables["MedYPMXD"].Compute("Sum(数量)", "编号='" + dr["编号"] + "' and 单位='" + dr["单位"] + "'"));//Modify By Tany 2004-12-10 加入单位的判断
                    dr["金额"] = Convert.ToDouble(rds.Tables["MedYPMXD"].Compute("SUM(金额)", "编号='" + dr["编号"] + "' and 单位='" + dr["单位"] + "'"));//Modify By Tany 2004-12-10 加入单位的判断
                    dr["麻毒否"] = rds.Tables["MedYPMXD"].Rows[j]["麻毒否"].ToString();
                    dr["贵重否"] = rds.Tables["MedYPMXD"].Rows[j]["贵重否"].ToString();
                    dr["统领分类"] = rds.Tables["MedYPMXD"].Rows[j]["TLFL"].ToString();
                    bool boo_existsamerow = false;
                    for (int m = 0; m <= rds.Tables["MedYPTLD"].Rows.Count - 1; m++)		//模拟分组汇总（寻找相同药品，如果有则不加入数据集）
                    {
                        if (rds.Tables["MedYPTLD"].Rows[m]["编号"].ToString() == dr["编号"].ToString()
                            && rds.Tables["MedYPTLD"].Rows[m]["单位"].ToString() == dr["单位"].ToString())//Modify By Tany 2004-12-10 加入单位的判断
                        {
                            boo_existsamerow = true;
                            break;
                        }
                    }
                    if (!boo_existsamerow)
                        rds.Tables["MedYPTLD"].Rows.Add(dr);
                }

                DataTable myTempTb1 = rds.Tables["MedYPTLD"];
                this.myDataGridTL.DataSource = myTempTb1;
                this.myDataGridTL.TableStyles[0].MappingName = "MedYPTLD";
                this.myDataGridTL.TableStyles[0].RowHeaderWidth = 25;
                this.myDataGridTL.CaptionText = "统领单【金额总计：" + decimal.Round(Convert.ToDecimal(total), 2) + "元】";
                if (myTempTb1.Rows.Count >= 1)
                {
                    this.bt打印统领单.Enabled = true;
                    this.bt打印明细单.Enabled = true;
                }

                DataTable myTempTb2 = rds.Tables["MedYPMXD"];
                this.myDataGridMX.DataSource = myTempTb2;
                this.myDataGridMX.TableStyles[0].MappingName = "MedYPMXD";
                this.myDataGridMX.TableStyles[0].RowHeaderWidth = 25;
                this.myDataGridMX.CaptionText = "明细单";

                this.panelMX.Visible = true;
                this.panelQY.Visible = false;
            }
            catch (System.Data.OleDb.OleDbException err)
            {
                MessageBox.Show(err.ToString());
            }

            Cursor.Current = Cursors.Default;

        }

        private void bt打印统领单_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGridTL.DataSource;
            //首先查找不需要打印的 add by zouchihua 2014-
            //DataTable tbTlfl = InstanceForm.BDatabase.GetDataTable("select * from YP_TLFL where Bprint=0");
            //DataTable myTb1 = myTbsourse.Copy();
            //DataTable myTb = myTbsourse.Clone();
            //myTb.Clear();
            //foreach (DataRow Inserrow in myTb1.Rows)
            //{
            //   DataRow []row1= tbTlfl.Select("name='" + Inserrow["统领分类"] + "'");
            //   if (row1 == null || row1.Length == 0)
            //   {
            //       myTb.Rows.Add(Inserrow.ItemArray);
            //   }
            //}
            //rds.Tables.Remove("MedYPTLD");
            //rds.Tables.Add(myTb);
            if (myTb == null || myTb != null && myTb.Rows.Count < 1)
            {
                MessageBox.Show(this, "没有数据，不能打印", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmReportView frmReport = null;
            ParameterEx[] _parameters = new ParameterEx[4];

            _parameters[0].Text = "tTitle";
            _parameters[0].Value = "住院病人药品统领单(领药)";//+"("+this.sendkind+")";
            _parameters[1].Text = "tDate";
            _parameters[1].Value = "消息发送时间： " + this.sendDate;
            _parameters[2].Text = "tDept";
            _parameters[2].Value = "领药科室： " + InstanceForm.BCurrentDept.WardName + "  发药科室： " + this.execDept;
            _parameters[3].Text = "tUser";
            _parameters[3].Value = "打印者：" + InstanceForm.BCurrentUser.Name;

            frmReport = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\ZYHS_药品统领单.rpt", _parameters);
            frmReport.Show();
        }

        private void bt打印明细单_Click(object sender, System.EventArgs e)
        {
            DataTable myTb3 = (DataTable)this.myDataGridMX.DataSource;

            //首先查找不需要打印的 add by zouchihua 2014-
            //首先查找不需要打印的 add by zouchihua 2014-
            //DataTable tbTlfl = InstanceForm.BDatabase.GetDataTable("select * from YP_TLFL where Bprint=0");
            //DataTable myTb1 = myTb.Copy();
            //DataTable myTb3 = myTb.Clone();
            //myTb3.Clear();
            //foreach (DataRow Inserrow in myTb1.Rows)
            //{
            //    DataRow[] row1 = tbTlfl.Select("name='" + Inserrow["tlfl"] + "'");
            //    if (row1 == null || row1.Length == 0)
            //    {
            //        myTb3.Rows.Add(Inserrow.ItemArray);
            //    }
            //}
            //rds.Tables.Remove("MedYPMXD");
            //rds.Tables.Add(myTb3);
            if (myTb3 == null || myTb3 != null && myTb3.Rows.Count < 1)
            {
                MessageBox.Show(this, "没有数据，不能打印", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmReportView frmReport = null;
            ParameterEx[] _parameters = new ParameterEx[4];

            _parameters[0].Text = "tTitle";
            _parameters[0].Value = "住院病人药品明细单";
            _parameters[1].Text = "tDate";
            _parameters[1].Value = "消息发送时间： " + this.sendDate;
            _parameters[2].Text = "tDept";
            _parameters[2].Value = "领药科室： " + InstanceForm.BCurrentDept.WardName + "  发药科室： " + this.execDept;
            _parameters[3].Text = "tUser";
            _parameters[3].Value = "打印者：" + InstanceForm.BCurrentUser.Name;

            frmReport = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\ZYHS_药品明细单.rpt", _parameters);
            frmReport.Show();
        }

        private void bt删除_Click(object sender, System.EventArgs e)
        {

            DataTable myTb = (DataTable)this.myDataGridQY.DataSource;

            bool isSelect = false;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["id"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                {
                    isSelect = true;
                    break;
                }
            }

            if (isSelect == false)
            {
                MessageBox.Show(this, "没有选择缺药消息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(this, "确认删除选择的缺药消息吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            string sSql = "";
            string zy_putoutdrug_id = "";
            string nfee_id = "";

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                bool isHSZ = f1.isHSZ;
                if (f1.isLogin == false) return;
            }

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["id"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                {
                    InstanceForm.BDatabase.BeginTransaction();

                    try
                    {
                        //已经结算的或者已经记账的不能删除
                        sSql = "update zy_fee_speci set delete_bit=1 where discharge_bit=0 and charge_bit=0 and id='" + myTb.Rows[i]["id"].ToString() + "'";//
                        InstanceForm.BDatabase.DoCommand(sSql);
                        nfee_id += myTb.Rows[i]["id"].ToString().Trim() + ",";

                        InstanceForm.BDatabase.CommitTransaction();
                    }
                    catch (Exception err)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();

                        //写错误日志 Add By Tany 2005-01-12
                        SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "删除缺药消息错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                        _systemErrLog.Save();
                        _systemErrLog = null;

                        MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source + "\n数据已经回滚，请检查后重新执行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            //			database.Close();

            //写日志 Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "删除缺药消息", "update zy_putoutdrug set delete_bit=1 where id in (" + zy_putoutdrug_id + ")+ update zy_fee_speci set delete_bit=1 where id in (" + nfee_id + ")", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            this.bt刷新消息_Click(sender, e);
            this.bt显示缺药消息_Click(sender, e);
        }

        private void bt发送_Click(object sender, System.EventArgs e)
        {
            int msgType = 0;
            System.DateTime ExecDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            DataTable myTb = (DataTable)this.myDataGridQY.DataSource;

            bool isSelect = false;
            sendDept = "";
            execDept = "";
            string sSql = "";
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["id"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                {
                    if (sendDept == "")
                    {
                        isSelect = true;
                        sendDept = InstanceForm.BCurrentDept.WardName;
                        execDept = myTb.Rows[i]["发药科室"].ToString().Trim();
                    }
                    else
                    {
                        if (execDept != myTb.Rows[i]["发药科室"].ToString().Trim())
                        {
                            MessageBox.Show(this, "发药科室不一致！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            if (isSelect == false)
            {
                MessageBox.Show(this, "没有选择缺药消息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(this, "确认发送选择的缺药消息吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                bool isHSZ = f1.isHSZ;
                if (f1.isLogin == false) return;
            }

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["id"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                {
                    if (Convert.ToDecimal(myTb.Rows[i]["数量"]) < 0)
                    {
                        msgType = 1;
                    }
                    else
                    {
                        msgType = 0;
                    }
                    sSql = "update zy_fee_speci set apply_id='" + Guid.Empty + "',tlfs=2 where id='" + myTb.Rows[i]["id"].ToString().Trim() + "'";
                    InstanceForm.BDatabase.DoCommand(sSql);
                }
            }

            //新统领药品消息 Modify By Tany 2005-09-13
            //缺药也是先变成重新发送状态
            string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
            DataTable yfTb = InstanceForm.BDatabase.GetDataTable(yfSql);

            for (int i = 0; i < yfTb.Rows.Count; i++)
            {
                //新统领药品（领药）消息 Modify By Tany 2005-09-13
                myFunc.SendYPFY(2, 0, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);

                //新统领药品（退药）消息 Modify By Tany 2005-09-13
                myFunc.SendYPFY(2, 1, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
            }

            this.bt刷新消息_Click(sender, e);
            this.bt显示缺药消息_Click(sender, e);
        }


        private void myDataGridXX_Click(object sender, System.EventArgs e)
        {
            // myFunc.SelCol_Click(this.myDataGridXX);
        }

        private void panelQY_VisibleChanged(object sender, System.EventArgs e)
        {
            this.bt删除.Enabled = false;
            this.bt发送.Enabled = false;

            if (this.panelQY.Visible == false) return;

            DataTable myTb = (DataTable)this.myDataGridQY.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count < 1) return;

            this.bt删除.Enabled = true;
            this.bt发送.Enabled = true;
        }

        private void bt显示缺药消息_Click(object sender, System.EventArgs e)
        {
            //查询药品缺药信息			
            try
            {
                Cursor.Current = PubStaticFun.WaitCursor();

                DataTable GridMXTb = (DataTable)this.myDataGridMX.DataSource;
                if (GridMXTb != null) GridMXTb.Rows.Clear();

                DataTable myTb3 = myFunc.GetYPTLD(Guid.Empty, InstanceForm.BCurrentDept.WardId, 1);
                DataColumn col = new DataColumn();
                col.DataType = System.Type.GetType("System.Boolean");
                col.AllowDBNull = false;
                col.ColumnName = "选";
                col.DefaultValue = false;
                myTb3.Columns.Add(col);
                this.myDataGridQY.DataSource = myTb3;
                this.myDataGridQY.TableStyles[0].RowHeaderWidth = 25;
                this.panelMX.Visible = false;
                this.panelQY.Visible = true;
                this.panelQY_VisibleChanged(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void bt全选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGridMX.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            int nrow = 0, j = 0;
            bool isTrue = false;
            DataGridCell myCel = myDataGridMX.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (this.rb所有病人.Checked)
                {
                    this.myDataGridMX.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["选"] = true;
                }
                else
                {
                    if (i == 0
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() != myTb.Rows[i - 1]["Baby_ID"].ToString().Trim())
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        nrow = i;	 //新病人的行号	
                        isTrue = false;
                        for (j = i; j <= myTb.Rows.Count - 1; j++)
                        {
                            if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                            {
                                if (myTb.Rows[j]["选"].ToString() == "True")
                                {
                                    isTrue = true;
                                    break;
                                }
                            }
                            else break;
                        }
                    }

                    if (myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                    {
                        this.myDataGridMX.CurrentCell = new DataGridCell(i, 0);
                        myTb.Rows[i]["选"] = isTrue;
                    }
                    else isTrue = false;
                }
            }
            this.myDataGridMX.DataSource = myTb;
            this.myDataGridMX.CurrentCell = myCel;
        }

        private void bt反选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGridMX.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            int nrow = 0, j = 0;
            bool isTrue = false;
            DataGridCell myCel = myDataGridMX.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (this.rb所有病人.Checked)
                {
                    this.myDataGridMX.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
                }
                else
                {
                    if (i == 0
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() != myTb.Rows[i - 1]["Baby_ID"].ToString().Trim())
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        nrow = i;	 //新病人的行号	
                        isTrue = false;
                        for (j = i; j <= myTb.Rows.Count - 1; j++)
                        {
                            if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                            {
                                if (myTb.Rows[j]["选"].ToString() == "True")
                                {
                                    isTrue = true;
                                    break;
                                }
                            }
                            else break;
                        }
                    }

                    if (isTrue && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                    {
                        this.myDataGridMX.CurrentCell = new DataGridCell(i, 0);
                        myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
                    }
                }
            }
            this.myDataGridMX.DataSource = myTb;
            this.myDataGridMX.CurrentCell = myCel;
        }

        private void myDataGridMX_Click(object sender, System.EventArgs e)
        {
            myFunc.SelCol_Click(this.myDataGridMX);
        }

        private void btnReSend_Click(object sender, System.EventArgs e)
        {

            Button btnNew = (Button)sender;
            Point pp = new Point(btnNew.Location.X, btnNew.Location.Y + btnNew.Height);
            contextMenu1.Show(btnNew.Parent, pp);
        }

        private void bt退出_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSelAll_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGridXX.DataSource);
            if (myTb == null || myTb.Rows.Count <= 0)
                return;

            DataGridCell myCel = myDataGridXX.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                this.myDataGridXX.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["选"] = true;
            }
            this.myDataGridXX.DataSource = myTb;
            this.myDataGridXX.CurrentCell = myCel;
        }

        private void btnUnSel_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGridXX.DataSource);
            if (myTb == null || myTb.Rows.Count <= 0)
                return;

            DataGridCell myCel = myDataGridXX.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                this.myDataGridXX.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
            }
            this.myDataGridXX.DataSource = myTb;
            this.myDataGridXX.CurrentCell = myCel;
        }

        //获取项目
        private void GetCmbItem(DataTable myTb, ComboBox cmb, string ItemName)
        {
            cmb.Items.Clear();
            cmb.Items.Add("全部");
            DataRow[] drM = myTb.Select("", ItemName);
            DataTable tmpTb = myTb.Clone();

            foreach (DataRow dr in drM)
            {
                tmpTb.Rows.Add(dr.ItemArray);
            }

            for (int i = 0; i < tmpTb.Rows.Count; i++)
            {
                if (i == 0)
                {
                    cmb.Items.Add(tmpTb.Rows[i][ItemName].ToString().Trim());
                }
                else if (tmpTb.Rows[i][ItemName].ToString().Trim() != tmpTb.Rows[i - 1][ItemName].ToString().Trim())
                {
                    cmb.Items.Add(tmpTb.Rows[i][ItemName].ToString().Trim());
                }
            }
            cmb.SelectedIndex = 0;
        }

        private void AddCmbLXItem()
        {
            cmbLX.Items.Clear();
            cmbLX.Items.Add("全部");
            cmbLX.Items.Add("领药");
            cmbLX.Items.Add("退药");
            cmbLX.SelectedIndex = 0;
        }

        private void cmbTLEXECDEPT_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DataTable myTb = fyTb.Copy();

            if (cmbTLEXECDEPT.Text.Trim() == "全部")
            {
                myDataGridFY.DataSource = myTb;
                myDataGridFY.TableStyles[0].RowHeaderWidth = 25;
            }
            else
            {
                DataRow[] drM = myTb.Select("发药科室='" + cmbTLEXECDEPT.Text.Trim() + "'");
                DataTable tmpTb = myTb.Clone();
                foreach (DataRow dr in drM)
                {
                    tmpTb.Rows.Add(dr.ItemArray);
                }
                myDataGridFY.DataSource = tmpTb;
                myDataGridFY.TableStyles[0].RowHeaderWidth = 25;
            }
        }

        private void cmbSFEXECDEPT_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DataTable myTb = xxTb.Copy();

            if (cmbSFEXECDEPT.Text.Trim() == "全部" && cmbLX.Text.Trim() == "全部")
            {
                myDataGridXX.DataSource = myTb;
                myDataGridXX.TableStyles[0].RowHeaderWidth = 25;
            }
            else if (cmbSFEXECDEPT.Text.Trim() == "全部" && cmbLX.Text.Trim() != "全部")
            {
                DataRow[] drM = myTb.Select("类型='" + cmbLX.Text.Trim() + "'");
                DataTable tmpTb = myTb.Clone();
                foreach (DataRow dr in drM)
                {
                    tmpTb.Rows.Add(dr.ItemArray);
                }
                myDataGridXX.DataSource = tmpTb;
                myDataGridXX.TableStyles[0].RowHeaderWidth = 25;
            }
            else if (cmbSFEXECDEPT.Text.Trim() != "全部" && cmbLX.Text.Trim() == "全部")
            {
                DataRow[] drM = myTb.Select("发药科室='" + cmbSFEXECDEPT.Text.Trim() + "'");
                DataTable tmpTb = myTb.Clone();
                foreach (DataRow dr in drM)
                {
                    tmpTb.Rows.Add(dr.ItemArray);
                }
                myDataGridXX.DataSource = tmpTb;
                myDataGridXX.TableStyles[0].RowHeaderWidth = 25;
            }
            else
            {
                DataRow[] drM = myTb.Select("发药科室='" + cmbSFEXECDEPT.Text.Trim() + "' and 类型='" + cmbLX.Text.Trim() + "'");
                DataTable tmpTb = myTb.Clone();
                foreach (DataRow dr in drM)
                {
                    tmpTb.Rows.Add(dr.ItemArray);
                }
                myDataGridXX.DataSource = tmpTb;
                myDataGridXX.TableStyles[0].RowHeaderWidth = 25;
            }
        }

        private void AddYF()
        {
            string sSql = "";
            sSql = "Select distinct b.KSMC,b.DEPTID from jc_DEPT_DRUGSTORE a inner join YP_YJKS b on a.drugstore_id=b.deptid " +
                " where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
            yfTb = InstanceForm.BDatabase.GetDataTable(sSql);

            MenuItem mnu原执行药房 = new MenuItem();
            mnu原执行药房.Index = 0;
            mnu原执行药房.Text = "原执行药房";
            mnu原执行药房.Click += new System.EventHandler(menuItem_Click);

            contextMenu1.MenuItems.Clear();
            contextMenu1.MenuItems.Add(mnu原执行药房);

            if (yfTb == null || yfTb.Rows.Count == 0)
                return;

            for (int i = 0; i < yfTb.Rows.Count; i++)
            {
                MenuItem mi = new MenuItem();
                mi.Index = i + 1;
                mi.Text = yfTb.Rows[i]["KSMC"].ToString().Trim();
                mi.Click += new System.EventHandler(menuItem_Click);

                contextMenu1.MenuItems.Add(mi);
            }
        }

        private void menuItem_Click(object sender, System.EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            string miName = mi.Text.Trim();
            long execYf = GetYFID(miName);
            int iSelectRows = 0;
            int msgType = 0;
            DataTable myTb = new DataTable();
            string msg = "";
            string sMsg = "";
            string sSql = "";

            if (panelMX.Visible)
            {
                myTb = (DataTable)myDataGridMX.DataSource;
            }
            else if (panelQY.Visible)
            {
                myTb = (DataTable)myDataGridQY.DataSource;
            }

            if (myTb == null || myTb.Rows.Count == 0)
                return;

            #region 是否选择消息
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    iSelectRows += 1;
                }
            }

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择消息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            if (execYf == 0)
                msg = "是否需要将选定的药品从现在的统领消息中分离并重新发送？";
            else
                msg = "是否需要将选定的药品从 ［" + execDept + "］ 转发到 ［" + miName + "］ ？";

            if (MessageBox.Show(msg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                bool isHSZ = f1.isHSZ;
                if (f1.isLogin == false) return;
            }

            Cursor.Current = PubStaticFun.WaitCursor();
            System.DateTime BookDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            if (execYf == 0)
            {
                #region 不更改执行科室
                try
                {
                    //选中的医嘱
                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                        {
                            if (Convert.ToDecimal(myTb.Rows[i]["数量"]) < 0)
                            {
                                msgType = 1;
                            }
                            else
                            {
                                msgType = 0;
                            }
                            sSql = "update zy_fee_speci set apply_id=DBO.FUN_GETEMPTYGUID(),tlfs=2 where delete_bit=0 and fy_bit=0 and id='" + myTb.Rows[i]["fee_id"].ToString().Trim() + "'";
                            InstanceForm.BDatabase.DoCommand(sSql);
                        }
                    }
                }
                catch (Exception err)
                {
                    //写错误日志 Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "重新发送药品不更改执行科室错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source + "\n\n数据已经回滚，请检查后重新执行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bt刷新消息_Click(sender, e);
                    return;
                }
                #endregion
            }
            else
            {
                #region 更改执行科室
                #region 判断药品的有效性
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                    {
                        sSql = "Select a.kcl yfkcl,b.num*a.dwbl/b.unitrate num,a.dwbl,b.unitrate from YF_KCMX a inner join zy_fee_speci b on a.cjid=b.xmid where a.bdelete=0 and b.id='" + myTb.Rows[i]["fee_id"].ToString().Trim() + "' and a.deptid=" + execYf;
                        DataTable medTb = InstanceForm.BDatabase.GetDataTable(sSql);

                        if (medTb == null || medTb.Rows.Count == 0)
                        {
                            sMsg += " ⊙ " + myTb.Rows[i]["名称"].ToString().Trim() + "\n";
                        }
                        else if (Convert.ToInt32(medTb.Rows[0]["unitrate"]) > 1 && Convert.ToInt32(medTb.Rows[0]["unitrate"]) != Convert.ToInt32(medTb.Rows[0]["dwbl"]))//如果单位系数大于1（说明开的是小单位），并且不等于对方药房的单位比例，不允许发
                        {
                            sMsg += " ⊙ " + myTb.Rows[i]["名称"].ToString().Trim() + " [ 原药房与对应药房的拆零单位不相同 ]\n";
                        }
                        else if (Convert.ToDecimal(medTb.Rows[0]["num"]) > Convert.ToDecimal(medTb.Rows[0]["yfkcl"]))
                        {
                            sMsg += " ⊙ " + myTb.Rows[i]["名称"].ToString().Trim() + " [ 数量：" + medTb.Rows[0]["num"].ToString().Trim() + " ] 大于 [ 库存量：" + medTb.Rows[0]["yfkcl"].ToString().Trim() + "] \n";
                        }
                    }
                }

                if (sMsg.Trim() != "")
                {
                    MessageBox.Show("下列药品因为所更改的执行科室中没有该种药品或库存不够，将不能被发送，请重新选择后再发送！\n不能更改执行科室的药品包括：\n\n" + sMsg,
                        "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion

                //				//生成数据访问对象
                //				RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
                //				database.Initialize("");
                //				database.Open();
                //				//开始一个事物
                //				database.BeginTransaction();

                InstanceForm.BDatabase.BeginTransaction();

                try
                {
                    //选中的医嘱
                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                        {
                            if (Convert.ToDecimal(myTb.Rows[i]["数量"]) < 0)
                            {
                                msgType = 1;
                            }
                            else
                            {
                                msgType = 0;
                            }
                            sSql = "update zy_fee_speci set execdept_id=" + execYf + ",apply_id=DBO.FUN_GETEMPTYGUID(),tlfs=2 " +
                                " where delete_bit=0 and fy_bit=0 and id ='" + myTb.Rows[i]["fee_id"].ToString().Trim() + "'";
                            InstanceForm.BDatabase.DoCommand(sSql);

                            sSql = "update zy_prescription set execdept_id=" + execYf +
                                " where id in (select prescription_id from zy_fee_speci " +
                                " where id ='" + myTb.Rows[i]["fee_id"].ToString().Trim() + "')";
                            InstanceForm.BDatabase.DoCommand(sSql);
                        }
                    }

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    //					database.Close();

                    //写错误日志 Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "重新发送药品更改执行科室错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source + "\n\n数据已经回滚，请检查后重新执行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bt刷新消息_Click(sender, e);
                    return;
                }

                //				database.Close();
                #endregion
            }

            string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
            DataTable yfTb = InstanceForm.BDatabase.GetDataTable(yfSql);

            for (int i = 0; i < yfTb.Rows.Count; i++)
            {
                //新统领药品（领药）消息 Modify By Tany 2005-09-13
                myFunc.SendYPFY(2, 0, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, BookDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);

                //新统领药品（退药）消息 Modify By Tany 2005-09-13
                myFunc.SendYPFY(2, 1, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, BookDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
            }

            //写日志 Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "重新发送药品", "BookDate=" + BookDate.ToString(), DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            Cursor.Current = Cursors.Default;
            MessageBox.Show("重新发送成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bt刷新消息_Click(sender, e);

            if (panelQY.Visible)
            {
                this.bt显示缺药消息_Click(sender, e);
            }
        }

        private long GetYFID(string YFName)
        {
            long YFID = 0;

            if (yfTb == null || yfTb.Rows.Count == 0)
            {
                YFID = 0;
            }
            else
            {
                for (int i = 0; i < yfTb.Rows.Count; i++)
                {
                    if (yfTb.Rows[i]["KSMC"].ToString().Trim() == YFName)
                    {
                        YFID = Convert.ToInt64(yfTb.Rows[i]["DEPTID"]);
                        break;
                    }
                }
            }

            return YFID;
        }

        private void frmYPXX_Activated(object sender, System.EventArgs e)
        {
            this.bt刷新消息_Click(sender, e);
        }

        private void bt发送药品_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("是否需要生成药品统领信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor.Current = PubStaticFun.WaitCursor();

                string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                DataTable yfTb = InstanceForm.BDatabase.GetDataTable(yfSql);

                DateTime _sendDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                for (int i = 0; i < yfTb.Rows.Count; i++)
                {
                    //新统领药品（领药）消息 Modify By Tany 2005-09-13
                    myFunc.SendYPFY(0, 0, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, _sendDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);

                    //新统领药品（退药）消息 Modify By Tany 2005-09-13
                    myFunc.SendYPFY(0, 1, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, _sendDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);

                    //重新统领药品（领药）消息 Modify By Tany 2005-09-13
                    myFunc.SendYPFY(2, 0, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, _sendDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);

                    //重新统领药品（退药）消息 Modify By Tany 2005-09-13
                    myFunc.SendYPFY(2, 1, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, _sendDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                }

                bt刷新药品信息_Click(null, null);
                bt刷新消息_Click(null, null);

                Cursor.Current = Cursors.Default;
            }
        }

        private void bt全选缺_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGridQY.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            int nrow = 0, j = 0;
            bool isTrue = false;
            DataGridCell myCel = myDataGridQY.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (this.rb所有病人缺.Checked)
                {
                    this.myDataGridQY.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["选"] = true;
                }
                else
                {
                    if (i == 0
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() != myTb.Rows[i - 1]["Baby_ID"].ToString().Trim())
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        nrow = i;	 //新病人的行号	
                        isTrue = false;
                        for (j = i; j <= myTb.Rows.Count - 1; j++)
                        {
                            if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                            {
                                if (myTb.Rows[j]["选"].ToString() == "True")
                                {
                                    isTrue = true;
                                    break;
                                }
                            }
                            else break;
                        }
                    }

                    if (myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                    {
                        this.myDataGridQY.CurrentCell = new DataGridCell(i, 0);
                        myTb.Rows[i]["选"] = isTrue;
                    }
                    else isTrue = false;
                }
            }
            this.myDataGridQY.DataSource = myTb;
            this.myDataGridQY.CurrentCell = myCel;
        }

        private void bt反选缺_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGridQY.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            int nrow = 0, j = 0;
            bool isTrue = false;
            DataGridCell myCel = myDataGridQY.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (this.rb所有病人缺.Checked)
                {
                    this.myDataGridQY.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
                }
                else
                {
                    if (i == 0
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() != myTb.Rows[i - 1]["Baby_ID"].ToString().Trim())
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        nrow = i;	 //新病人的行号	
                        isTrue = false;
                        for (j = i; j <= myTb.Rows.Count - 1; j++)
                        {
                            if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                            {
                                if (myTb.Rows[j]["选"].ToString() == "True")
                                {
                                    isTrue = true;
                                    break;
                                }
                            }
                            else break;
                        }
                    }

                    if (isTrue && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                    {
                        this.myDataGridQY.CurrentCell = new DataGridCell(i, 0);
                        myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
                    }
                }
            }
            this.myDataGridQY.DataSource = myTb;
            this.myDataGridQY.CurrentCell = myCel;
        }

        private void bt全选1_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(0, this.dataGridEx1);
        }

        private void bt反选1_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(1, this.dataGridEx1);
        }

        private void dataGridEx1_Click(object sender, EventArgs e)
        {
            myFunc.SelCol_Click(this.dataGridEx1);
        }

        private void AddZXYF()
        {
            string sSql = "";
            sSql = "Select distinct b.KSMC,b.DEPTID from jc_DEPT_DRUGSTORE a inner join YP_YJKS b on a.drugstore_id=b.deptid " +
                " where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + InstanceForm.BCurrentDept.DeptId + ")";
            yfTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (yfTb == null || yfTb.Rows.Count == 0)
            {
                return;
            }

            cmbZxyf.DisplayMember = "KSMC";
            cmbZxyf.ValueMember = "DEPTID";
            cmbZxyf.DataSource = yfTb;
            //add by zouchihua 2012-4-22 默认选择中心药房
            for (int i = 0; i < yfTb.Rows.Count; i++)
            {
                if (yfTb.Rows[i]["ksmc"].ToString().IndexOf("中心") >= 0)
                {
                    cmbZxyf.SelectedIndex = i;
                    return;
                }
            }
            cmbZxyf.SelectedIndex = 0;
        }

        private void LoadPatient()
        {
            string binSql = "";

            if (rbAll.Checked)
            {
                return;
            }

            if (rbIn.Checked)
            {
                binSql = @"  SELECT BED_NO 床号,INPATIENT_NO 住院号,NAME 姓名,INPATIENT_ID,Baby_ID,DEPT_ID" +
                        "    FROM vi_zy_vInpatient_Bed " +
                        "   WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "'order by BED_NO,baby_id";
            }
            else if (rbTempOut.Checked)
            {
                binSql = @" SELECT BED_NO 床号,INPATIENT_NO 住院号,NAME 姓名,INPATIENT_ID,Baby_ID,DEPT_ID " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and flag = 5 ORDER BY BED_NO,Baby_ID";
            }
            else if (rbOut.Checked)
            {
                int _outMonth = Convert.ToInt32((new SystemCfg(7023)).Config) * -1;
                DateTime _outDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddMonths(_outMonth);

                binSql = @" SELECT BED_NO 床号,INPATIENT_NO 住院号,NAME 姓名,INPATIENT_ID,Baby_ID,DEPT_ID " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and flag in (2,6) " +
                        "  and out_Date>= '" + _outDate.Date + "' ORDER BY BED_NO,Baby_ID";
            }
            else if (rbTrans.Checked)
            {
                binSql = @" SELECT BED_NO 床号,INPATIENT_NO 住院号,NAME 姓名,INPATIENT_ID,Baby_ID,DEPT_ID " +
                    "   FROM vi_zy_vInpatient_Bed " +
                    "  WHERE inpatient_id in (select inpatient_id from zy_transfer_dept where cancel_bit=0 and finish_bit=1 and s_dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')) " +
                    "  ORDER BY BED_NO,Baby_ID";
            }
            else if (rbTszl.Checked)
            {
                binSql = @" SELECT BED_NO 床号,INPATIENT_NO 住院号,NAME 姓名,INPATIENT_ID,Baby_ID,DEPT_ID " +
                    "   FROM vi_zy_vInpatient_Bed " +
                    "  WHERE inpatient_id in (select inpatient_id from ZY_TS_APPLY where status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002) and ts_dept in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')) " +
                    "  ORDER BY BED_NO,Baby_ID";
            }

            myFunc.ShowGrid(1, binSql, this.dataGridEx1);

            this.dataGridEx1.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName0 ={ "选", "床号", "住院号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID" };
            int[] GrdWidth0 ={ 2, 4, 9, 10, 0, 0, 0 };
            int[] Alignment0 ={ 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly0 ={ 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName0, GrdWidth0, Alignment0, ReadOnly0, this.dataGridEx1);
            //开始全部不选中
            bt全选1_Click(null, null);
            bt反选1_Click(null, null);
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            LoadPatient();

            bt刷新药品信息_Click(null, null);
        }

        private void bt刷新药品信息_Click(object sender, EventArgs e)
        {
            //Modify By Tany 2010-01-18
            if (tabControl1.SelectedTab != tabControl1.TabPages[0])
            {
                return;
            }
            this.label3.Text = "";
            DataTable tbBin = (DataTable)dataGridEx1.DataSource;

            DataTable tb = (DataTable)this.dgYPMX.DataSource;

            if (!rbAll.Checked && (tbBin == null || tbBin.Rows.Count == 0))
            {
                tb.Clear();
                dgYPMX.DataSource = tb;
                computeTld();
                return;
            }

            DataTable tbmx = new DataTable();

            DataTable tab = tb.Clone();
            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {
                int _msg_type = rbLy.Checked ? 0 : 1;
                //add by zouchihua 2012-3-10 暂存药的处理，9表示 暂存药
                int _tfls = 0;
                if (CbZCy.Checked == true)
                    _tfls = 9;
                if (rbAll.Checked)
                {
                    //DateTime dt1 = System.DateTime.Now;
                    if (!this.checkLsk.Checked)
                        tab = myFunc.ZYHS_YPFY_SELECT(_tfls, _msg_type, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(cmbZxyf.SelectedValue));
                    else
                        tab = myFunc.ZYHS_YPFY_SELECT(_tfls, _msg_type, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(cmbZxyf.SelectedValue), true);
                    //DateTime dt2 = System.DateTime.Now;
                    //TimeSpan ts1 = dt2 - dt1;
                    //MessageBox.Show(ts1.Seconds.ToString());
                    //add by zouchihua 2012-3-25 增加重发发送药品查询
                    if (_tfls == 0)
                    {
                        //DateTime dt11 = System.DateTime.Now;
                        DataTable temp;
                        if (!this.checkLsk.Checked)
                            temp = myFunc.ZYHS_YPFY_SELECT(2, _msg_type, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(cmbZxyf.SelectedValue));
                        else
                            temp = myFunc.ZYHS_YPFY_SELECT(2, _msg_type, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(cmbZxyf.SelectedValue), true);
                        //DateTime dt12 = System.DateTime.Now;
                        //TimeSpan ts = dt12 - dt11;
                        //MessageBox.Show(ts.Seconds.ToString());
                        for (int x = 0; x < temp.Rows.Count; x++)
                        {
                            tab.ImportRow(temp.Rows[x]);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < tbBin.Rows.Count; j++)
                    {
                        if (tbBin.Rows[j]["选"].ToString().Trim() == "True")
                        {
                            if (!this.checkLsk.Checked)
                                tbmx = myFunc.ZYHS_YPFY_SELECT(_tfls, _msg_type, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, new Guid(tbBin.Rows[j]["inpatient_id"].ToString()), Convert.ToInt32(tbBin.Rows[j]["baby_id"]), Convert.ToInt32(cmbZxyf.SelectedValue));
                            else
                                tbmx = myFunc.ZYHS_YPFY_SELECT(_tfls, _msg_type, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, new Guid(tbBin.Rows[j]["inpatient_id"].ToString()), Convert.ToInt32(tbBin.Rows[j]["baby_id"]), Convert.ToInt32(cmbZxyf.SelectedValue), true);
                            for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                            {
                                tab.ImportRow(tbmx.Rows[i]);
                            }
                            //add by zouchihua 2012-3-25 增加重发发送药品查询
                            if (_tfls == 0)
                            {
                                DataTable temp;
                                if (!this.checkLsk.Checked)
                                    temp = myFunc.ZYHS_YPFY_SELECT(2, _msg_type, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(cmbZxyf.SelectedValue));
                                else
                                    temp = myFunc.ZYHS_YPFY_SELECT(2, _msg_type, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(cmbZxyf.SelectedValue), true);
                                for (int x = 0; x < temp.Rows.Count; x++)
                                {
                                    tab.ImportRow(temp.Rows[x]);
                                }
                            }
                        }
                    }
                }

                FunBase.AddRowtNo(tab);
                tab.TableName = "tbmx";

                this.dgYPMX.DataSource = tab;

                //计算统领单
                computeTld();

                PubStaticFun.ModifyDataGridStyle(this.dgYPMX, 0);
                if (rbLy.Checked && (CbZCy.Checked == false && (CbZCy.Enabled == true)))
                    发送到暂存管理ToolStripMenuItem.Enabled = true;
                else
                {

                    发送到暂存管理ToolStripMenuItem.Enabled = false;

                }
                if (cfg7182.Config.Trim() == "1" && CbZCy.Checked == false)
                {
                    发送到暂存管理ToolStripMenuItem.Enabled = true;
                }
                Cursor.Current = Cursors.Default;
                if (this.CbZCy.Checked)
                    btUnSelect_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dgYPMX.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
                tb.Rows[i]["选"] = (short)1;
            computeTld();
        }

        private void btUnSelect_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dgYPMX.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
                tb.Rows[i]["选"] = (short)0;
            computeTld();
        }

        private void btClean_Click(object sender, EventArgs e)
        {
            this.txtypmc.Text = "";
            this.txtjx.Text = "";
            this.cmbTlfl.Text = "";
        }

        private void btSeek_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.dgYPMX.DataSource;
                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }
                DataTable tab = tb.Clone();
                DataRow[] rows;
                string swhere = "";
                //品名
                if (Convert.ToInt32(txtypmc.Tag) > 0 && txtypmc.Text.Trim() != "")
                    swhere = " cjid='" + txtypmc.Tag.ToString().Trim() + "'";
                //统领类型
                if (cmbTlfl.Text.Trim() != "")
                    swhere = swhere == "" ? swhere = "类型='" + cmbTlfl.Text.Trim() + "'" : swhere = swhere + " and 类型='" + cmbTlfl.Text.Trim() + "'";
                //剂型
                if (txtjx.Text.Trim() != "")
                    swhere = swhere == "" ? swhere = "剂型='" + txtjx.Text.Trim() + "'" : swhere = swhere + " and 剂型='" + txtjx.Text.Trim() + "'";

                rows = tb.Select(swhere);
                for (int i = 0; i <= rows.Length - 1; i++)
                    tab.ImportRow(rows[i]);

                TrasenClasses.GeneralControls.DataGridEx myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
                System.Windows.Forms.DataGridTableStyle dataGridTableStyle = new DataGridTableStyle();
                dataGridTableStyle.AllowSorting = false;
                myDataGrid1.TableStyles.Add(dataGridTableStyle);
                myDataGrid1.CaptionVisible = false;
                myDataGrid1.ReadOnly = true;
                myDataGrid1.BackgroundColor = System.Drawing.Color.White;
                myDataGrid1.SelectionBackColor = System.Drawing.Color.White;
                myDataGrid1.Click += new EventHandler(dgYPMX_Click);
                // myDataGrid1.MouseClick += new MouseEventHandler(dgYPMX_MouseClick);
                //初始化网格
                CshMxGrid(myDataGrid1);

                //显示查询结果
                myDataGrid1.DataSource = tab;

                Frmmxcx f = new Frmmxcx();
                f.panel2.Controls.Add(myDataGrid1);
                myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);

                decimal zsl = Convert.ToDecimal(Convertor.IsNull(tab.Compute("sum(ypsl)", "选=true"), "0"));
                f.statusBar1.Text = "药品总用量:" + zsl.ToString();

                f.ShowDialog();

                //更新明细的选择结果
                if (f.Bselect == true)
                {
                    DataTable tbmx = (DataTable)myDataGrid1.DataSource;
                    TrasenFrame.Classes.TsSet tsset = new TrasenFrame.Classes.TsSet();
                    tsset.TsDataTable = tb;

                    for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                    {
                        ItemEx[] item = new ItemEx[1];
                        item[0].Text = "选";
                        item[0].Value = (short)(Convert.ToInt16(tbmx.Rows[i]["选"]));
                        tsset.UpdateField(item, "zy_id='" + tbmx.Rows[i]["zy_id"].ToString().Trim() + "'");
                    }
                    this.dgYPMX.DataSource = tsset.TsDataTable;
                    this.computeTld();

                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }



        private void txtypmc_KeyUp(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "") { control.Text = ""; control.Tag = "0"; }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { }
            else { return; }

            try
            {
                string[] GrdMappingName;
                int[] GrdWidth;
                string[] sfield;
                string ssql = "";
                DataRow row;
                //Modify by zouchihua 2012-3-12 定位
                Point newpoint = this.panel6.PointToScreen(control.Location);
                Point point = newpoint;
                point.Offset(0, 20);// new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 0:
                        if (control.Text.Trim() == "") return;
                        GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                        GrdWidth = new int[] { 0, 0, 50, 200, 100, 100, 40, 0, 60, 60, 70 };
                        sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                        ssql = "select a.ggid,cjid,0  rowno,ypspm,ypgg,s_sccj sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b " +
                                "where a.ggid=b.ggid and deptid=" + cmbZxyf.SelectedValue.ToString() + " and bdelete_kc=0 and a.ypzlx in(select ypzlx from yp_gllx where deptid=" + cmbZxyf.SelectedValue.ToString() + ")  ";

                        TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, Constant.CustomFilterType, control.Text.Trim(), ssql);
                        f2.Location = point;
                        f2.Width = 700;
                        f2.Height = 300;
                        f2.ShowDialog(this);
                        row = f2.dataRow;
                        if (row != null)
                        {
                            control.Text = row["ypspm"].ToString();
                            control.Tag = row["cjid"].ToString();
                            this.SelectNextControl((Control)sender, true, false, true, true);
                        }
                        break;

                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void dgYPMX_Click(object sender, EventArgs e)
        {
            //放到鼠标时间里去
            //TrasenClasses.GeneralControls.DataGridEx myGridDate = (TrasenClasses.GeneralControls.DataGridEx)sender;
            //DataTable tb = (DataTable)myGridDate.DataSource;
            //int nrow = myGridDate.CurrentCell.RowNumber;
            ////add by zouchihua 2012-3-10
            //#region
            //bool shift = ((GetKeyState(VK_LSHIFT) & 0x80) != 0) ||
            //                 ((GetKeyState(VK_RSHIFT) & 0x80) != 0);

            //if (shift)
            //{
            //    if (ShiftBeginIndex == -1)
            //    {
            //        ShiftBeginIndex = nrow;
            //    }
            //    else
            //    {
            //        ShiftEndIndex = nrow;
            //        for (int i = 0; i < tb.Rows.Count; i++)
            //        {
            //            if (ShiftBeginIndex > ShiftEndIndex)
            //            {
            //                if (i >= ShiftEndIndex && i <= ShiftBeginIndex)
            //                    tb.Rows[i]["选"] = (short)1;
            //            }
            //            else
            //            {
            //                if (i >= ShiftBeginIndex && i <= ShiftEndIndex)
            //                    tb.Rows[i]["选"] = (short)1;
            //            }
            //        }
            //        ShiftBeginIndex = -1;
            //        ShiftEndIndex = -1;
            //    }

            //    return;
            //}
            //else
            //{
            //    ShiftBeginIndex = -1;
            //    ShiftEndIndex = -1;
            //}
            //#endregion
            //try
            //{
            //    if (myGridDate.TableStyles[0].GridColumnStyles[myGridDate.CurrentCell.ColumnNumber].HeaderText != "选")
            //    {
            //        if (tb.Rows[nrow]["选"].ToString() == "1")
            //            tb.Rows[nrow]["选"] = (short)0;
            //        else
            //            tb.Rows[nrow]["选"] = (short)1;
            //        return;
            //    }
            //    if (nrow > tb.Rows.Count - 1) return;
            //    tb.Rows[nrow]["选"] = Convert.ToBoolean(tb.Rows[nrow]["选"]) == true ? false : true;
            //    if (myGridDate.Name == "dgYPMX") this.computeTld();
            //    else myGridDate.Tag = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(ypsl)", "选=true"), "0"));
            //    PubStaticFun.ModifyDataGridStyle(myGridDate, 0);
            //}
            //catch (System.Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
        }

        //生成统领单
        private void computeTld()
        {
            this.dgYPMX.Tag = "0";
            decimal sumlsje = 0;
            decimal Fzhjje = 0;//每个页面分组合计
            DataTable tb = (DataTable)this.dgYPMX.DataSource;

            //汇总当前的分类
            string[] GroupbyField1 ={ "类型" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };
            TrasenFrame.Classes.TsSet tsset1 = new TrasenFrame.Classes.TsSet();
            tsset1.TsDataTable = tb;
            DataTable tbfl = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "选=true");
            //添加分类页面
            AddtlflPage(tbfl);

            string[] GroupbyField ={ "货号", "品名", "商品名", "规格", "厂家", "库存数", "cjid", "单价", "dwbl", "zxdw" };
            string[] ComputeField ={ "ypsl", "金额" };
            string[] CField ={ "sum", "sum" };

            TrasenFrame.Classes.TsSet tsset = new TrasenFrame.Classes.TsSet();
            tsset.TsDataTable = tb;
            for (int i = 1; i <= this.tabControl2.TabPages.Count - 1; i++)
            {
                for (int j = 0; j <= this.tabControl2.TabPages[i].Controls.Count - 1; j++)
                {
                    //如果是网格
                    if (this.tabControl2.TabPages[i].Controls[j].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                    {
                        Fzhjje = 0;
                        //汇总每个统领分类
                        //DataTable tab=tsset.GroupTable(GroupbyField,ComputeField,CField," 类型='"+this.tabControl2.TabPages[i].Title.Trim()+"' and 选择=true");

                        DataTable tab;
                        DataRow[] selrow = tb.Select(" 类型='" + this.tabControl2.TabPages[i].Title.Trim() + "' and 选=true");
                        DataTable tbsel = tb.Clone();
                        for (int w = 0; w <= selrow.Length - 1; w++)
                            tbsel.ImportRow(selrow[w]);
                        tab = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);

                        TrasenClasses.GeneralControls.DataGridEx mydatagrid = (TrasenClasses.GeneralControls.DataGridEx)this.tabControl2.TabPages[i].Controls[j];
                        DataTable mytb = (DataTable)mydatagrid.DataSource;
                        mytb.Rows.Clear();
                        DataRow[] rows = tab.Select("", "货号 asc");

                        //添加数据
                        for (int x = 0; x <= rows.Length - 1; x++)
                        {
                            DataRow row = mytb.NewRow();
                            row["序号"] = x + 1;
                            row["选"] = "1";//add by zouchihua 增加选择列
                            row["品名"] = rows[x]["品名"];
                            row["商品名"] = rows[x]["商品名"];
                            row["规格"] = rows[x]["规格"];
                            row["厂家"] = rows[x]["厂家"];
                            row["单价"] = rows[x]["单价"];

                            decimal ypsl = Convert.ToDecimal(Convertor.IsNull(rows[x]["ypsl"], "0"));
                            decimal kcl = Convert.ToDecimal(Convertor.IsNull(rows[x]["库存数"], "0"));
                            float _ypsl = (float)ypsl;
                            float _kcl = (float)kcl;
                            row["库存数"] = kcl.ToString();// rows[x]["库存数"];
                            row["领药数"] = ypsl.ToString();// rows[x]["ypsl"];
                            row["缺药数"] = (kcl - ypsl) < 0 ? System.Math.Abs(kcl - ypsl) : 0;
                            row["单位"] = Yp.SeekYpdw(Convert.ToInt32(rows[x]["zxdw"]), InstanceForm.BDatabase);
                            row["金额"] = rows[x]["金额"];
                            row["货号"] = rows[x]["货号"];
                            row["cjid"] = rows[x]["cjid"];
                            row["dwbl"] = rows[x]["dwbl"];
                            //sumlsje=sumlsje+Convert.ToDecimal(Convertor.IsNull(rows[x]["金额"],"0"));
                            sumlsje = sumlsje + (Convert.IsDBNull(rows[x]["金额"]) ? 0 : Convert.ToDecimal(rows[x]["金额"]));
                            Fzhjje += (Convert.IsDBNull(rows[x]["金额"]) ? 0 : Convert.ToDecimal(rows[x]["金额"]));
                            mytb.Rows.Add(row);
                        }
                        //添加合计列
                        DataRow row1 = mytb.NewRow();
                        row1["序号"] = rows.Length + 1;
                        row1["品名"] = "合计";
                        row1["金额"] = Fzhjje;
                        mytb.Rows.Add(row1);
                    }
                }
            }

            PubStaticFun.ModifyDataGridStyle(this.dgYPMX, 0);

        }

        //添加统领方式页面
        private void AddtlflPage(DataTable tb)
        {
            RemoveTabpage(this.tabControl2);

            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage();
                tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                tabPage1.Location = new System.Drawing.Point(0, 25);
                tabPage1.Name = tb.Rows[i]["类型"].ToString().Trim() == "" ? "其他" : tb.Rows[i]["类型"].ToString().Trim();
                tabPage1.Title = tb.Rows[i]["类型"].ToString();
                tabPage1.Size = new System.Drawing.Size(639, 452);
                tabPage1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
																								   tabPage1});

                TrasenClasses.GeneralControls.DataGridEx myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
                myDataGrid1.ContextMenuStrip = this.contextMenuStrip2;
                myDataGrid1.ReadOnly = true;
                myDataGrid1.MouseClick += new MouseEventHandler(myDataGrid1_MouseClick);
                System.Windows.Forms.DataGridTableStyle dataGridTableStyle = new DataGridTableStyle();
                myDataGrid1.FlatMode = false;
                dataGridTableStyle.AllowSorting = false;
                dataGridTableStyle.ReadOnly = true;
                //dataGridTableStyle.DataGrid = myDataGrid1;
                myDataGrid1.TableStyles.Add(dataGridTableStyle);

                string[] HeaderText ={ "序号", "选", "品名", "商品名", "规格", "厂家", "单价", "库存数", "领药数", "缺药数", "单位", "金额", "货号", "cjid", "dwbl" };
                string[] MappingName ={ "序号", "选", "品名", "商品名", "规格", "厂家", "单价", "库存数", "领药数", "缺药数", "单位", "金额", "货号", "cjid", "dwbl" };
                int[] ColWidth ={ 30, 30, 100, 100, 90, 90, 50, 55, 55, 0, 35, 60, 55, 0, 0 };
                bool[] ColReadOnly ={ true, false, true, true, true, true, true, true, true, true, false, true, true, true, true, true };
                DataTable dtTmp = new DataTable();
                dtTmp.TableName = "tb";
                for (int j = 0; j <= HeaderText.Length - 1; j++)
                {
                    if (HeaderText[j] != "选")
                    {
                        DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(j);
                        colText.HeaderText = HeaderText[j];
                        colText.MappingName = MappingName[j];
                        colText.Width = ColWidth[j];
                        colText.NullText = "";
                        colText.ReadOnly = ColReadOnly[j];
                        // add by zouchihua 2012-03-10 
                        if (HeaderText[j] == "领药数")
                        {
                            // colText.ReadOnly = false;
                            colText.TextBox.MouseClick += new MouseEventHandler(TextBox_MouseClick);
                        }
                        else
                        {
                            colText.TextBox.Visible = false;
                        }
                        colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(colText_CheckCellEnabled);
                        myDataGrid1.TableStyles[0].GridColumnStyles.Add(colText);
                    }
                    else
                    {
                        DataGridBoolColumn colbll = new DataGridBoolColumn();
                        colbll.HeaderText = HeaderText[j];
                        colbll.FalseValue = "0";
                        colbll.MappingName = MappingName[j];
                        colbll.Width = ColWidth[j];
                        colbll.NullText = "";
                        colbll.NullValue = "0";
                        colbll.ReadOnly = ColReadOnly[j];
                        colbll.TrueValue = "1";
                        colbll.AllowNull = false;
                        //colbll.NullValue = "";

                        myDataGrid1.TableStyles[0].GridColumnStyles.Add(colbll);
                    }
                    DataColumn datacol = new DataColumn(MappingName[j]);
                    dtTmp.Columns.Add(datacol);
                }
                myDataGrid1.CurrentCellChanged += new EventHandler(myDataGrid1_CurrentCellChanged);
                myDataGrid1.DataSource = dtTmp;
                myDataGrid1.TableStyles[0].MappingName = "tb";
                myDataGrid1.CaptionVisible = false;
                myDataGrid1.BackgroundColor = System.Drawing.Color.White;
                myDataGrid1.SelectionBackColor = System.Drawing.Color.White;
                myDataGrid1.ReadOnly = false;
                myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                tabPage1.Controls.Add(myDataGrid1);
                myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                myDataGrid1.TableStyles[0].GridColumnStyles["商品名"].Width = 120;
            }
        }

        void myDataGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;
            int curindex = (sender as DataGridEx).CurrentCell.RowNumber;
            int colindex = (sender as DataGridEx).CurrentCell.ColumnNumber;
            DataTable tb = (DataTable)(sender as DataGridEx).DataSource;
            if (curindex > tb.Rows.Count - 1)
                return;
            if ((sender as DataGridEx).TableStyles[0].GridColumnStyles[colindex].MappingName == "领药数")
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
            if (
                (sender as DataGridEx).TableStyles[0].GridColumnStyles[(sender as DataGridEx).CurrentCell.ColumnNumber].HeaderText != "领药数")
            {
                if (tb.Rows[curindex]["选"].ToString() == "1")
                    tb.Rows[curindex]["选"] = (short)0;
                else
                    tb.Rows[curindex]["选"] = (short)1;

                //DataTable mytb = (DataTable)mydatagrid.DataSource;
                // int curindx = mydatagrid.CurrentRowIndex;
                string cjid = tb.Rows[curindex]["cjid"].ToString();
                int ReturnValue = 0;
                decimal je = 0;
                DataTable ypmxtb = (DataTable)dgYPMX.DataSource;
                //改为0
                if (tb.Rows.Count <= 0 || tb.Rows[curindex]["品名"].ToString() == "合计")
                    return;
                if (tb.Rows[curindex]["选"].ToString() == "0")
                {
                    DataTable tbmx = myFunc.Gxypsl(ypmxtb, 0, cjid, ref ReturnValue, ref je);
                    dgYPMX.DataSource = tbmx;
                    //tb.Rows[curindex]["领药数"] = 0;  
                }
                else
                {
                    DataTable tbmx = myFunc.Gxypsl(ypmxtb, Convert.ToInt32(tb.Rows[curindex]["领药数"].ToString()), cjid, ref ReturnValue, ref je);
                    dgYPMX.DataSource = tbmx;
                    tb.Rows[curindex]["领药数"] = ReturnValue;
                    tb.Rows[curindex]["金额"] = je;
                    Gethj((sender as DataGridEx));
                }
                return;
            }
        }
        /// <summary>
        /// 重新计算合计
        /// </summary>
        /// <param name="dge"></param>
        private void Gethj(DataGridEx dge)
        {
            DataTable tb = (DataTable)dge.DataSource;
            decimal hjje = 0;
            for (int i = 0; i < tb.Rows.Count - 1; i++)
            {
                hjje += decimal.Parse(tb.Rows[i]["金额"].ToString());
            }
            tb.Rows[tb.Rows.Count - 1]["金额"] = hjje;
        }

        void TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            //int yls= (sender as TextBox).Text.ToString();//保存原来数量
            txtb = new TextBox();
            txtb.BackColor = Color.LightYellow;
            txtb.Size = new Size((sender as TextBox).Width, (sender as TextBox).Height);
            txtb.Location = new Point(0, 0);
            txtb.Text = (sender as TextBox).Text;
            txtb.ForeColor = Color.Blue;
            txtb.SelectAll();
            txtb.Focus();
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            (sender as TextBox).Controls.Add(txtb);
            txtb.KeyPress += new KeyPressEventHandler(txtb_KeyPress);
        }
        int curflag = 0;
        void myDataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (txtb != null)
            {
                txtb.Visible = false;
                txtb.Dispose();
            }
            if (curflag == 1)
            {
                curflag = 0;
                return;
            }
            int curindex = (sender as DataGridEx).CurrentCell.ColumnNumber;
            if ((sender as DataGridEx).TableStyles[0].GridColumnStyles[curindex].MappingName == "领药数")
            {
                //(sender as DataGridEx).CurrentCell = new DataGridCell(curindex + 1, 8);
                Rectangle rc = (sender as DataGridEx).GetCellBounds((sender as DataGridEx).CurrentCell);
                Rectangle screrc = (sender as DataGridEx).RectangleToScreen(rc);
                SetCursorPos(screrc.Location.X - 5 + rc.Width, screrc.Location.Y + 10);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
            curflag = 0;
        }
        void txtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SelectTabtile = this.tabControl2.SelectedTab.Title;
                TextBox t = sender as TextBox;
                int xsl = 0;
                int ReturnValue = 0;
                decimal je = 0;
                try
                {
                    xsl = Convert.ToInt32(t.Text.Trim());

                }
                catch (Exception ex)
                {
                    xsl = -1;
                }
                t.Visible = false;
                t.Dispose();
                //重新选择药品
                for (int i = 0; i < this.tabControl2.SelectedTab.Controls.Count; i++)
                {
                    if (this.tabControl2.SelectedTab.Controls[i].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                    {

                        TrasenClasses.GeneralControls.DataGridEx mydatagrid = (TrasenClasses.GeneralControls.DataGridEx)this.tabControl2.SelectedTab.Controls[i];
                        DataTable mytb = (DataTable)mydatagrid.DataSource;
                        int curindx = mydatagrid.CurrentRowIndex;
                        string cjid = mytb.Rows[curindx]["cjid"].ToString();
                        if (xsl != -1)
                        {
                            DataTable yptb = (DataTable)this.dgYPMX.DataSource;
                            if (yptb.Rows.Count <= 0)
                                return;
                            if (mytb.Rows[curindx]["选"].ToString() == "1")
                            {
                                DataTable tb = myFunc.Gxypsl(yptb, xsl, cjid, ref ReturnValue, ref je);
                                dgYPMX.DataSource = tb;
                                mytb.Rows[curindx]["领药数"] = ReturnValue;
                                mytb.Rows[curindx]["金额"] = je;
                            }
                            else
                            {
                                mytb.Rows[curindx]["领药数"] = 0;
                                mytb.Rows[curindx]["金额"] = 0;

                            }
                            Gethj(mydatagrid);
                        }
                        curflag = 1;
                        mydatagrid.CurrentCell = new DataGridCell(curindx + 1, 8);
                        Rectangle rc = mydatagrid.GetCellBounds(mydatagrid.CurrentCell);
                        Rectangle screrc = mydatagrid.RectangleToScreen(rc);
                        SetCursorPos(screrc.Location.X - 5 + rc.Width, screrc.Location.Y + 10);
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                    }
                }
            }
        }

        //递归移除tabpage
        private void RemoveTabpage(Crownwood.Magic.Controls.TabControl tabcontrol)
        {
            for (int i = 0; i <= tabcontrol.TabPages.Count - 1; i++)
            {
                if (tabcontrol.TabPages[i] != this.tabPage4)
                {
                    tabcontrol.TabPages.Remove(tabcontrol.TabPages[i]);
                    RemoveTabpage(tabcontrol);
                }
            }
        }

        //初始化领药明细
        private void CshMxGrid(TrasenClasses.GeneralControls.DataGridEx DataGrid)
        {
            #region 添加统领明细的列

            DataGrid.TableStyles[0].GridColumnStyles.Clear();
            //35
            string[] HeaderText ={ "序号", "选", "床号", "姓名", "时间", "住院号", "品名", "商品名", "规格", "厂家", "单价", "库存数", "数量", "单位", "金额", "货号", "类型", "剂型", "cjid", "dept_id", "apply_id", "apply_date", "charge_bit", "ward_id", "zy_id", "unitrate", "ypsl", "zxdw", "dwbl", "批发价", "批发金额", "统领分类", "ypjx", "ypyf", "药品用法", "INPATIENT_ID" };
            string[] MappingName ={ "序号", "选", "床号", "姓名", "PRESC_DATE", "住院号", "品名", "商品名", "规格", "厂家", "单价", "库存数", "数量", "单位", "金额", "货号", "类型", "剂型", "cjid", "dept_id", "apply_id", "apply_date", "charge_bit", "ward_id", "zy_id", "unitrate", "ypsl", "zxdw", "dwbl", "批发价", "批发金额", "统领分类", "ypjx", "ypyf", "药品用法", "INPATIENT_ID" };
            int[] ColWidth ={ 45, 35, 35, 55, 120, 72, 120, 120, 90, 0, 55, 66, 50, 40, 55, 0, 65, 65, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 65, 0 };
            bool[] ColReadOnly ={ true, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
            int[] ColBoolButton ={ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";

            for (int j = 0; j <= HeaderText.Length - 1; j++)
            {
                //文本列
                if (ColBoolButton[j] == 0)
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(j);
                    colText.HeaderText = HeaderText[j];
                    colText.MappingName = MappingName[j];
                    colText.Width = ColWidth[j];
                    colText.NullText = "";
                    colText.ReadOnly = ColReadOnly[j];
                    colText.TextBox.Visible = false;
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(dgYPMX_colText_CheckCellEnabled);
                    DataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    DataColumn datacol;
                    if (MappingName[j].Trim() == "ypsl" || MappingName[j] == "金额" || MappingName[j] == "批发金额")
                        datacol = new DataColumn(MappingName[j], Type.GetType("System.Decimal"));
                    else
                        datacol = new DataColumn(MappingName[j]);

                    dtTmp.Columns.Add(datacol);
                }
                //布尔列
                if (ColBoolButton[j] == 1)
                {
                    DataGridEnableBoolColumn colText = new DataGridEnableBoolColumn(j);
                    colText.HeaderText = HeaderText[j];
                    colText.MappingName = MappingName[j];
                    colText.Width = ColWidth[j];
                    colText.NullText = "0";
                    colText.AllowNull = false;
                    colText.NullValue = ((short)(0));
                    colText.FalseValue = ((short)(0));
                    colText.TrueValue = ((short)(1));
                    colText.ReadOnly = ColReadOnly[j];
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableBoolColumn.EnableCellEventHandler(dgYPMX_colText_CheckCellEnabled);
                    DataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    dtTmp.Columns.Add(MappingName[j], Type.GetType("System.Int16"));
                }
            }

            DataGrid.DataSource = dtTmp;
            DataGrid.TableStyles[0].MappingName = "tbmx";

            #endregion

        }

        //列颜色改变事件
        private void colText_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;
            DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
            DataTable tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
            if (e.Row > tb.Rows.Count - 1) return;
            if (tb.Rows[e.Row]["选"].ToString() == "1")
            {
                e.ForeColor = Color.Blue;
                e.BackColor = Color.WhiteSmoke;
                if (Convert.ToDecimal(Convertor.IsNull(tb.Rows[e.Row]["领药数"], "0")) > Convert.ToDecimal(Convertor.IsNull(tb.Rows[e.Row]["库存数"], "0")))
                    e.ForeColor = Color.Red;
            }
            else
            {
                e.ForeColor = Color.Gray;
                if (Convert.ToDecimal(Convertor.IsNull(tb.Rows[e.Row]["领药数"], "0")) > Convert.ToDecimal(Convertor.IsNull(tb.Rows[e.Row]["库存数"], "0")))
                    e.ForeColor = Color.Red;

            }


            if (tb.Rows[e.Row]["品名"].ToString() == "合计")
            {
                e.ForeColor = Color.Blue;
                e.BackColor = Color.LightGreen;
            }
        }

        //列颜色改变事件
        private void dgYPMX_colText_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            try
            {
                e.BackColor = Color.White;
                DataTable tb;
                if (sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn")
                {
                    DataGridEnableBoolColumn column = (DataGridEnableBoolColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                else
                {
                    DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }

                if (e.Row > tb.Rows.Count - 1) return;
                if (Convert.ToBoolean(tb.Rows[e.Row]["选"]) == false)
                    e.ForeColor = Color.Gray;
                else
                    e.ForeColor = Color.Blue; ;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            //			
        }

        private void dgYPMX_DoubleClick(object sender, EventArgs e)
        {
            if ((new SystemCfg(8012)).Config != "1") return;

            DataTable tb = (DataTable)this.dgYPMX.DataSource;
            if (tb.Rows.Count == 0) return;
            int nrow = this.dgYPMX.CurrentCell.RowNumber;
            int cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);
            Ypcj cj = new Ypcj(cjid, InstanceForm.BDatabase);

            DataTable tab = tb.Clone();
            DataRow[] rows;
            string swhere = " cjid='" + cjid + "'";
            rows = tb.Select(swhere);
            for (int i = 0; i <= rows.Length - 1; i++)
                tab.ImportRow(rows[i]);

            TrasenClasses.GeneralControls.DataGridEx myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            System.Windows.Forms.DataGridTableStyle dataGridTableStyle = new DataGridTableStyle();
            dataGridTableStyle.AllowSorting = false;
            myDataGrid1.TableStyles.Add(dataGridTableStyle);
            myDataGrid1.CaptionVisible = false;
            myDataGrid1.ReadOnly = true;
            myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            myDataGrid1.SelectionBackColor = System.Drawing.Color.White;
            myDataGrid1.Click += new EventHandler(dgYPMX_Click);
            myDataGrid1.Name = "myhy";
            //初始化网格
            CshMxGrid(myDataGrid1);

            //显示查询结果
            myDataGrid1.DataSource = tab;

            Frmhy f = new Frmhy(cj.GGID, cj.CJID, Convert.ToInt32(cmbZxyf.SelectedValue));
            f.panel2.Controls.Add(myDataGrid1);
            myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);

            myDataGrid1.TableStyles[0].GridColumnStyles["厂家"].Width = 80;
            myDataGrid1.TableStyles[0].GridColumnStyles["货号"].Width = 80;

            decimal zsl = Convert.ToDecimal(Convertor.IsNull(tab.Compute("sum(ypsl)", "选=true and cjid=" + cj.CJID + ""), "0"));
            f.statusStrip1.Items[0].Text = "药品总用量:" + zsl.ToString() + Yp.SeekYpdw(Convert.ToInt32(tb.Rows[0]["zxdw"]), InstanceForm.BDatabase);

            f.ShowDialog();

            if (f.Bok == false) return;

            DataTable tbmx = (DataTable)this.dgYPMX.DataSource;
            DataTable tbcj = (DataTable)f.dataGridView1.DataSource;
            if (tbcj.Rows.Count == 0) { MessageBox.Show("没有可供选择的厂家", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            Ypcj newcj = new Ypcj(Convert.ToInt32(tbcj.Rows[f.dataGridView1.CurrentCell.RowIndex]["cjid"]), InstanceForm.BDatabase);
            decimal kcl = Convert.ToDecimal(tbcj.Rows[f.dataGridView1.CurrentCell.RowIndex]["库存量"]);

            try
            {

                //修改后台的数据
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(tab.Rows[i]["选"]) == true)
                    {
                        DataRow[] rows1 = tbmx.Select("zy_id='" + tab.Rows[i]["zy_id"] + "'");
                        DataRow row = rows1[0];

                        decimal dj = Math.Round(newcj.LSJ / Convert.ToInt32(row["unitrate"]), 4);
                        decimal sl = Convert.ToDecimal(row["数量"]);
                        decimal je = Math.Round(dj * sl, 2);
                        Guid zy_id = new Guid(row["zy_id"].ToString());

                        try
                        {
                            InstanceForm.BDatabase.BeginTransaction();

                            ParameterEx[] parameters = new ParameterEx[9];
                            parameters[0].Text = "@zy_id";
                            parameters[0].Value = zy_id;
                            parameters[1].Text = "@new_cjid";
                            parameters[1].Value = newcj.CJID;
                            parameters[2].Text = "@new_price";
                            parameters[2].Value = dj;
                            parameters[3].Text = "@new_je";
                            parameters[3].Value = je;
                            parameters[4].Text = "@err_code";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].DataType = System.Data.DbType.Int32;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@err_text";
                            parameters[5].ParaDirection = ParameterDirection.Output;
                            parameters[5].ParaSize = 100;

                            parameters[6].Text = "@sccj";
                            parameters[6].Value = newcj.SCCJ;
                            parameters[7].Text = "@djy";
                            parameters[7].Value = FrmMdiMain.CurrentUser.Name;
                            parameters[8].Text = "@kcl";
                            parameters[8].Value = row["库存数"].ToString() + " " + row[14].ToString() + "" + " 新药库存: " + kcl.ToString() + " " + newcj.S_YPDW;
                            TrasenFrame.Forms.FrmMdiMain.Database.DoCommand("sp_yf_hy", parameters, 120);
                            int err_code = Convert.ToInt32(parameters[4].Value);
                            string err_text = Convert.ToString(parameters[5].Value);
                            if (err_code == 0)
                            {//修改网格中的数据显示
                                row["cjid"] = newcj.CJID;
                                row["单价"] = dj.ToString();
                                row["金额"] = je.ToString();
                                row["库存数"] = kcl.ToString();
                                row["货号"] = newcj.SHH;
                            }
                            else
                                throw new Exception(@err_text);
                            InstanceForm.BDatabase.CommitTransaction();
                        }
                        catch (System.Exception err)
                        {
                            InstanceForm.BDatabase.RollbackTransaction();
                            MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                //重新计算
                computeTld();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //DataTable tbb = (DataTable)dgYPMX.DataSource;
                tb.Rows.Clear();
            }
        }

        private void bt生成统领单_Click(object sender, EventArgs e)
        {
            if (this.checkLsk.Checked)
            {
                MessageBox.Show("对不起，由于这些数据已经转移到历史库，不允许生成统领单！");
                return;
            }
            DataTable tb = (DataTable)this.dgYPMX.DataSource;
            if (tb.Rows.Count == 0) return;
            Cursor.Current = PubStaticFun.WaitCursor();
            if (this.CbZCy.Checked)
            {
                //add by zouchihua  2012-3-13是否只有护士长才可以发送暂存药
                bool isHSZ = myFunc.IsHSZ(FrmMdiMain.CurrentUser.EmployeeId);
                SystemCfg cfg7109 = new SystemCfg(7109);
                if (cfg7109.Config == "1")
                {
                    if (isHSZ == false)
                    {
                        MessageBox.Show("对不起，只有护士长才可以发送暂存药！", "提示信息！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            DataTable tab = tb.Clone();
            DataRow[] rows;
            string swhere = " 选=true";
            rows = tb.Select(swhere);
            for (int i = 0; i <= rows.Length - 1; i++)
                tab.ImportRow(rows[i]);

            if (tab.Rows.Count == 0) return;

            int _msg_type = rbLy.Checked ? 0 : 1;
            if (this.CbZCy.Checked && cfg7182.Config.Trim() == "1")
                myFunc.SendYPzcgl(tab, FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), Convert.ToInt64(cmbZxyf.SelectedValue), _msg_type, FrmMdiMain.Jgbm);
            else
                myFunc.SendYP(tab, FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), Convert.ToInt64(cmbZxyf.SelectedValue), _msg_type, FrmMdiMain.Jgbm);
            Cursor.Current = Cursors.Default;
            #region
            //string[] sql = new string[2];

            //string lyflSql = "select * from jc_yplyflk where delete_bit=0 order by code";
            //DataTable lyflTb = FrmMdiMain.Database.GetDataTable(lyflSql);

            //try
            //{
            //    //如果没有设置领药分类，那么默认99
            //    if (lyflTb == null || lyflTb.Rows.Count == 0)
            //    {
            //        swhere = "";
            //        for (int i = 0; i < tab.Rows.Count; i++)
            //        {
            //            if (swhere == "")
            //            {
            //                swhere = "'" + tab.Rows[i]["zy_id"].ToString().Trim() + "'";
            //            }
            //            else
            //            {
            //                swhere += ",'" + tab.Rows[i]["zy_id"].ToString().Trim() + "'";
            //            }
            //        }

            //        int _msg_type = rbLy.Checked ? 0 : 1;
            //        Guid _applyid = PubStaticFun.NewGuid();
            //        sql[0] = "INSERT INTO ZY_APPLY_DRUG(APPLY_ID,APPLY_DATE,APPLY_NURSE,APPLY_WARD,EXECDEPT_ID,MSG_TYPE,LYFLCODE,GROUP_ID,JGBM) " +
            //                " VALUES('" + _applyid + "','" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + InstanceForm.BCurrentDept.WardId + "','" + cmbZxyf.SelectedValue.ToString() + "'," + _msg_type + ",'99',DBO.FUN_GETEMPTYGUID()," + FrmMdiMain.Jgbm + ") ";
            //        sql[1] = "UPDATE ZY_FEE_SPECI SET APPLY_ID='" + _applyid + "' " +
            //                " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";

            //        InstanceForm.BDatabase.DoCommand(null, null, null, sql);
            //    }
            //    else
            //    {
            //        string[] ypjx = new string[lyflTb.Rows.Count];
            //        string[] ypyf = new string[lyflTb.Rows.Count];
            //        string[] _where = new string[lyflTb.Rows.Count];
            //        string[] _notwhere = new string[lyflTb.Rows.Count];

            //        DataTable tmpTb = tab.Copy();
            //        for (int j = 0; j < lyflTb.Rows.Count; j++)
            //        {
            //            _where[j] = "";
            //            _notwhere[j] = "";
            //            ypjx[j] = lyflTb.Rows[j]["ypjx"].ToString().Trim();
            //            ypyf[j] = lyflTb.Rows[j]["ypyf"].ToString().Trim();

            //            if (ypjx[j] != "" && ypyf[j] != "")
            //            {
            //                _where[j] = " ypjx in (" + ypjx[j] + ") and ypyf in (" + ypyf[j] + ") ";
            //                _notwhere[j] = " ypjx not in (" + ypjx[j] + ") and ypyf not in (" + ypyf[j] + ") ";
            //            }

            //            if (_where[j] != "")
            //            {
            //                DataRow[] tmprows = tmpTb.Select(_where[j]);
            //                DataTable tmptb = tmpTb.Clone();
            //                for (int i = 0; i < tmprows.Length; i++)
            //                {
            //                    tmptb.ImportRow(tmprows[i]);
            //                    tmpTb.Rows.Remove(tmprows[i]);
            //                }

            //                swhere = "";
            //                for (int i = 0; i < tmptb.Rows.Count; i++)
            //                {
            //                    if (swhere == "")
            //                    {
            //                        swhere = "'" + tmptb.Rows[i]["zy_id"].ToString().Trim() + "'";
            //                    }
            //                    else
            //                    {
            //                        swhere += ",'" + tmptb.Rows[i]["zy_id"].ToString().Trim() + "'";
            //                    }
            //                }

            //                if (swhere != "")
            //                {
            //                    int _msg_type = rbLy.Checked ? 0 : 1;
            //                    Guid _applyid = PubStaticFun.NewGuid();
            //                    sql[0] = "INSERT INTO ZY_APPLY_DRUG(APPLY_ID,APPLY_DATE,APPLY_NURSE,APPLY_WARD,EXECDEPT_ID,MSG_TYPE,LYFLCODE,GROUP_ID,JGBM) " +
            //                            " VALUES('" + _applyid + "','" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + InstanceForm.BCurrentDept.WardId + "','" + cmbZxyf.SelectedValue.ToString() + "'," + _msg_type + ",'" + lyflTb.Rows[j]["code"].ToString() + "',DBO.FUN_GETEMPTYGUID()," + FrmMdiMain.Jgbm + ") ";
            //                    sql[1] = "UPDATE ZY_FEE_SPECI SET APPLY_ID='" + _applyid + "' " +
            //                            " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";

            //                    InstanceForm.BDatabase.DoCommand(null, null, null, sql);
            //                }
            //            }
            //        }

            //        //其他的
            //        swhere = "";
            //        for (int i = 0; i < tmpTb.Rows.Count; i++)
            //        {
            //            if (swhere == "")
            //            {
            //                swhere = "'" + tmpTb.Rows[i]["zy_id"].ToString().Trim() + "'";
            //            }
            //            else
            //            {
            //                swhere += ",'" + tmpTb.Rows[i]["zy_id"].ToString().Trim() + "'";
            //            }
            //        }

            //        if (swhere != "")
            //        {
            //            int _msg_type = rbLy.Checked ? 0 : 1;
            //            Guid _applyid = PubStaticFun.NewGuid();
            //            sql[0] = "INSERT INTO ZY_APPLY_DRUG(APPLY_ID,APPLY_DATE,APPLY_NURSE,APPLY_WARD,EXECDEPT_ID,MSG_TYPE,LYFLCODE,GROUP_ID,JGBM) " +
            //                    " VALUES('" + _applyid + "','" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + InstanceForm.BCurrentDept.WardId + "','" + cmbZxyf.SelectedValue.ToString() + "'," + _msg_type + ",'99',DBO.FUN_GETEMPTYGUID()," + FrmMdiMain.Jgbm + ") ";
            //            sql[1] = "UPDATE ZY_FEE_SPECI SET APPLY_ID='" + _applyid + "' " +
            //                    " WHERE (APPLY_ID IS NULL OR APPLY_ID=DBO.FUN_GETEMPTYGUID()) AND DELETE_BIT=0 AND ID IN (" + swhere + ")";

            //            InstanceForm.BDatabase.DoCommand(null, null, null, sql);
            //        }
            //    }
            //}
            //catch(Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
            #endregion

            bt刷新药品信息_Click(null, null);
            bt刷新消息_Click(null, null);
        }

        private void txtjx_KeyUp(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "") { control.Text = ""; control.Tag = "0"; }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { }
            else { return; }

            try
            {
                string[] GrdMappingName;
                int[] GrdWidth;
                string[] sfield;
                string ssql = "";
                DataRow row;
                //Modify by zouchihua 2012-3-12 定位
                Point newpoint = this.panel6.PointToScreen(control.Location);
                Point point = newpoint;
                point.Offset(0, 20);
                //Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 2:
                        if (control.Text.Trim() == "") return;
                        GrdMappingName = new string[] { "名称", "拼音码", "五笔码" };
                        GrdWidth = new int[] { 200, 100, 100 };
                        sfield = new string[] { "pym", "wbm", "", "", "" };
                        ssql = "select mc 名称,pym 拼音码,wbm 五笔码 from YP_YPJX where 1=1 ";

                        TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, Constant.CustomFilterType, control.Text.Trim(), ssql);
                        f2.Location = point;
                        f2.Width = 500;
                        f2.Height = 300;
                        f2.ShowDialog(this);
                        row = f2.dataRow;
                        if (row != null)
                        {
                            control.Text = row["名称"].ToString();
                            this.SelectNextControl((Control)sender, true, false, true, true);
                        }
                        break;

                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGridQY.DataSource;
            if (myTb == null || myTb.Rows.Count == 0)
            {
                return;
            }

            try
            {
                DataRow[] drs = myTb.Select("", cmbSort.Text);
                DataTable newTb = myTb.Clone();

                foreach (DataRow dr in drs)
                {
                    newTb.Rows.Add(dr.ItemArray);
                }

                myDataGridQY.DataSource = newTb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Add By tany 2011-05-23 双击统领药，可以查看明细情况
        private void myDataGridTL_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable tbTl = (DataTable)this.myDataGridTL.DataSource;
                DataTable tbMx = (DataTable)this.myDataGridMX.DataSource;
                if (tbTl == null || tbTl.Rows.Count == 0)
                {
                    return;
                }
                if (tbMx == null || tbMx.Rows.Count == 0)
                {
                    MessageBox.Show("没有找到明细记录，请点击【显示统领单和明细单】按钮重新刷新数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int nrow = this.myDataGridTL.CurrentCell.RowNumber;
                DataTable tabMx = tbMx.Clone();
                DataRow[] rows;
                string swhere = " 编号='" + tbTl.Rows[nrow]["编号"].ToString().Trim() + "'";//Modify by jchl：xmid!=shh

                rows = tbMx.Select(swhere, "床号,日期");
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    tabMx.ImportRow(rows[i]);
                }

                TrasenClasses.GeneralControls.DataGridEx myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
                System.Windows.Forms.DataGridTableStyle dataGridTableStyle = new DataGridTableStyle();
                myDataGrid1.CaptionVisible = false;
                myDataGrid1.ReadOnly = true;
                myDataGrid1.BackgroundColor = System.Drawing.Color.White;
                myDataGrid1.SelectionBackColor = System.Drawing.Color.White;
                myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                myDataGrid1.isShowRowHeadId = true;
                //myDataGrid1.TableStyles.Add(dataGridTableStyle);
                myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] { dataGridTableStyle });
                dataGridTableStyle.AllowSorting = false;
                dataGridTableStyle.ReadOnly = true;
                //myDataGrid1.Click += new EventHandler(dgYPMX_Click);

                //初始化网格
                //myDataGridMX 明细单
                string[] GrdMappingName3 ={ "选", "床号", "住院号", "姓名", "日期", "编号", "名称", "规格", "数量", "单位", "单价", "金额", "麻毒否", "贵重否", "id", "INPATIENT_ID", "baby_id", "fee_id", "xmid", "TLFL" };
                int[] GrdWidth3 ={ 2, 4, 9, 8, 6, 8, 28, 12, 6, 6, 8, 8, 0, 0, 0, 0, 0, 0, 0, 8 };
                int[] Alignment3 ={ 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 2, 1, 1, 0, 0, 0, 0, 0, 0 };
                int[] ReadOnly3 ={ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                myFunc.InitGrid(GrdMappingName3, GrdWidth3, Alignment3, ReadOnly3, myDataGrid1);

                //显示查询结果
                myDataGrid1.DataSource = tabMx;

                Frmmxcx f = new Frmmxcx();
                f.panel2.Controls.Add(myDataGrid1);
                f.butall.Visible = false;
                f.butuall.Visible = false;
                f.butok.Visible = false;

                //PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);

                decimal zsl = Convert.ToDecimal(Convertor.IsNull(tabMx.Compute("sum(数量)", ""), "0"));
                f.statusBar1.Text = "药品总数量:" + zsl.ToString();

                f.ShowDialog();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dgYPMX_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TrasenClasses.GeneralControls.DataGridEx myGridDate = (TrasenClasses.GeneralControls.DataGridEx)sender;
                DataTable tb = (DataTable)myGridDate.DataSource;
                int nrow = myGridDate.CurrentCell.RowNumber;
                //add by zouchihua 2012-3-10
                #region
                bool shift = ((GetKeyState(VK_LSHIFT) & 0x80) != 0) ||
                                 ((GetKeyState(VK_RSHIFT) & 0x80) != 0);

                if (shift)
                {
                    if (ShiftBeginIndex == -1)
                    {
                        ShiftBeginIndex = nrow;
                    }
                    else
                    {
                        ShiftEndIndex = nrow;
                        for (int i = 0; i < tb.Rows.Count; i++)
                        {
                            if (ShiftBeginIndex > ShiftEndIndex)
                            {
                                if (i >= ShiftEndIndex && i <= ShiftBeginIndex)
                                    tb.Rows[i]["选"] = (short)1;
                            }
                            else
                            {
                                if (i >= ShiftBeginIndex && i <= ShiftEndIndex)
                                    tb.Rows[i]["选"] = (short)1;
                            }
                        }
                        ShiftBeginIndex = -1;
                        ShiftEndIndex = -1;
                    }

                    return;
                }
                else
                {
                    ShiftBeginIndex = -1;
                    ShiftEndIndex = -1;
                }
                #endregion
                try
                {
                    if (myGridDate.TableStyles[0].GridColumnStyles[myGridDate.CurrentCell.ColumnNumber].HeaderText != "选")
                    {
                        if (tb.Rows[nrow]["选"].ToString() == "1")
                            tb.Rows[nrow]["选"] = (short)0;
                        else
                            tb.Rows[nrow]["选"] = (short)1;
                        if (myGridDate.Name == "dgYPMX") this.computeTld();
                        else myGridDate.Tag = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(ypsl)", "选=true"), "0"));
                        PubStaticFun.ModifyDataGridStyle(myGridDate, 0);
                        return;
                    }
                    if (nrow > tb.Rows.Count - 1) return;
                    tb.Rows[nrow]["选"] = Convert.ToBoolean(tb.Rows[nrow]["选"]) == true ? false : true;
                    if (myGridDate.Name == "dgYPMX") this.computeTld();
                    else myGridDate.Tag = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(ypsl)", "选=true"), "0"));
                    PubStaticFun.ModifyDataGridStyle(myGridDate, 0);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {

            }
        }

        private void CbZCy_CheckedChanged(object sender, EventArgs e)
        {
            SystemCfg cfg7116 = new SystemCfg(7116);
            string cfg = "," + cfg7116.Config + ",";
            if (CbZCy.Checked == true || CbZCy.Visible == false || CbZCy.Enabled == false)
            {
                发送到暂存管理ToolStripMenuItem.Enabled = false;
                if (cfg.Contains(FrmMdiMain.CurrentUser.EmployeeId + ","))
                    this.btnFszdyf.Visible = true;
            }
            else
            {
                发送到暂存管理ToolStripMenuItem.Enabled = true;
                if (cfg.Contains(FrmMdiMain.CurrentUser.EmployeeId + ","))
                    this.btnFszdyf.Visible = false;
            }
            if (cfg7182.Config.Trim() == "1" && CbZCy.Checked == false)
            {
                发送到暂存管理ToolStripMenuItem.Enabled = true;
            }

            发送到暂存管理ToolStripMenuItem.Enabled = true;
            this.label3.Text = "";
            this.checkLsk.Visible = true;
            bt刷新药品信息_Click(null, null);
        }

        private void 同厂家ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataTable tb = (DataTable)dgYPMX.DataSource;
            if (tb == null || tb.Rows.Count == 0)
                return;
            int index = dgYPMX.CurrentCell.RowNumber;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["cjid"].ToString().Trim() == tb.Rows[index]["cjid"].ToString().Trim())
                    tb.Rows[i]["选"] = (short)1;
            }
            this.computeTld();
        }

        private void 同一人ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dgYPMX.DataSource;
            if (tb == null || tb.Rows.Count == 0)
                return;
            int index = dgYPMX.CurrentCell.RowNumber;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["inpatient_id"].ToString().Trim() == tb.Rows[index]["inpatient_id"].ToString().Trim())
                    tb.Rows[i]["选"] = (short)1;
            }
            this.computeTld();
        }

        private void 发送到暂存管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dgYPMX.DataSource;
            if (tb == null || tb.Rows.Count == 0)
                return;
            try
            {
                string strcfg = "," + cfg7175.Config.Trim() + ",";
                int flag = 0;
                for (int i = 0; i < tb.Rows.Count; i++)
                {

                    if (tb.Rows[i]["选"].ToString().Trim() == "1")
                    {
                        if (strcfg.Contains(tb.Rows[i]["tlfl"].ToString().Trim()))
                        {
                            tb.Rows[i]["选"] = "0";
                            flag = 1;
                        }
                    }
                }
                if (flag == 1)
                {
                    MessageBox.Show("所选的药品中有系统控制不能设为暂存药的药品，系统已经自动将其不选中，请重新操作！！", "提示信息");
                    this.computeTld();
                    return;
                }
                if (cfg7182.Config.Trim() == "1")
                {
                    #region //add by zouchihua  如果启用了暂存库存管理
                    tb.DefaultView.RowFilter = "选=1";
                    DataTable temp = tb.DefaultView.ToTable();//全部已经选上了的
                    DataSet ds = myFunc.GetZcAndYFfs_Tb(temp, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId
                        , Int32.Parse(cmbZxyf.SelectedValue.ToString()));
                    //发送到暂存
                    myFunc.SendZc(ds.Tables[0], FrmMdiMain.CurrentUser.UserID.ToString(), FrmMdiMain.CurrentUser.Name, true, Convert.ToInt64(cmbZxyf.SelectedValue));
                    //发送到药房 ,只有正记录在去判断
                    if (rbTy.Checked == false)
                    {
                        int _msg_type = rbLy.Checked ? 0 : 1;
                        myFunc.SendYP(ds.Tables[1], FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), Convert.ToInt64(cmbZxyf.SelectedValue), _msg_type, FrmMdiMain.Jgbm);
                    }
                    #endregion
                    //如果是退药，那么就直接冲减掉 （如果正的记录在暂存里面，平且数量相同时）
                    if (rbTy.Checked)
                    {
                        CjZcy(ds.Tables[0]);
                    }
                    MessageBox.Show("发送成功！！", "提示信息");
                }
                else
                {
                    myFunc.SendZc(tb, FrmMdiMain.CurrentUser.UserID.ToString(), FrmMdiMain.CurrentUser.Name, false, Convert.ToInt64(cmbZxyf.SelectedValue));
                    MessageBox.Show("发送到暂存管理成功！！", "提示信息");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bt刷新药品信息_Click(null, null);
        }
        /// <summary>
        /// 冲减暂存药品
        /// </summary>
        /// <param name="tb"></param>
        private void CjZcy(DataTable tb)
        {
            if (tb.Rows.Count == 0)
                return;
            try
            {
                string feeid = " select a.* from ZY_FEE_SPECI a join   ";
                string tj = " ( select * from ZY_FEE_SPECI  where id   in (";
                string tj1 = "";
                foreach (DataRow row in tb.Rows)
                {
                    tj1 += " '" + row["zy_id"].ToString() + "',";
                    tj += " '" + row["zy_id"].ToString() + "',";
                }
                tj = tj.Substring(0, tj.Length - 1);
                tj1 = tj1.Substring(0, tj1.Length - 1);
                tj += " )  )  b on b.CZ_ID=a.ID";
                DataTable tbzfy = FrmMdiMain.Database.GetDataTable(feeid + tj + "  where   a.DELETE_BIT=0 and a.TLFS=9 union all  select * from zy_fee_speci  where  id  in ( " + tj1 + ")");//获得费用
                foreach (DataRow row in tb.Rows)
                {
                    DataRow[] temprow = tbzfy.Select("id='" + row["zy_id"] + "'");
                    if (temprow.Length > 0)
                    {
                        decimal hj = decimal.Parse(tbzfy.Compute("sum(num)", " id='" + temprow[0]["id"].ToString() + "' or id ='" + temprow[0]["cz_id"].ToString() + "'").ToString());
                        if (hj == 0)
                        {
                            //那么就冲正记录 如果没有冲正的，就直接放到暂存里面
                            string update = " update ZY_FEE_SPECI set  tlfs=10  where id='" + temprow[0]["id"].ToString() + "' or id ='" + temprow[0]["cz_id"].ToString() + "'";
                            FrmMdiMain.Database.DoCommand(update);
                        }
                    }
                }
            }
            catch { }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dgYPMX.DataSource;
            decimal Je = 0;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                Je += decimal.Parse(tb.Rows[i]["金额"].ToString());
            }
            this.label3.Text = Je.ToString();
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.tabControl2.SelectedTab.Controls.Count; i++)
            {
                if (this.tabControl2.SelectedTab.Controls[i].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                {
                    TrasenClasses.GeneralControls.DataGridEx dgex = this.tabControl2.SelectedTab.Controls[i] as TrasenClasses.GeneralControls.DataGridEx;
                    int j = 0;
                    DataTable tb = (DataTable)dgex.DataSource;
                    for (j = 0; j < tb.Rows.Count - 1; j++)
                    {
                        tb.Rows[j]["选"] = "1";
                        string cjid = tb.Rows[j]["cjid"].ToString();
                        int ReturnValue = 0;
                        decimal je = 0;
                        DataTable ypmxtb = (DataTable)dgYPMX.DataSource;
                        if (tb.Rows[j]["选"].ToString() == "0")
                        {
                            DataTable tbmx = myFunc.Gxypsl(ypmxtb, 0, cjid, ref ReturnValue, ref je);
                            dgYPMX.DataSource = tbmx;
                            //tb.Rows[curindex]["领药数"] = 0;  
                        }
                        else
                        {
                            DataTable tbmx = myFunc.Gxypsl(ypmxtb, Convert.ToInt32(tb.Rows[j]["领药数"].ToString()), cjid, ref ReturnValue, ref je);
                            dgYPMX.DataSource = tbmx;
                            tb.Rows[j]["领药数"] = ReturnValue;
                            tb.Rows[j]["金额"] = je;
                            Gethj(dgex);
                        }
                    }
                }
            }
        }

        private void 反选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.tabControl2.SelectedTab.Controls.Count; i++)
            {
                if (this.tabControl2.SelectedTab.Controls[i].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                {
                    TrasenClasses.GeneralControls.DataGridEx dgex = this.tabControl2.SelectedTab.Controls[i] as TrasenClasses.GeneralControls.DataGridEx;
                    int j = 0;
                    DataTable tb = (DataTable)dgex.DataSource;
                    for (j = 0; j < tb.Rows.Count - 1; j++)
                    {
                        if (tb.Rows[j]["选"].ToString() == "0")
                            tb.Rows[j]["选"] = "1";
                        else
                            tb.Rows[j]["选"] = "0";
                        string cjid = tb.Rows[j]["cjid"].ToString();
                        int ReturnValue = 0;
                        decimal je = 0;
                        DataTable ypmxtb = (DataTable)dgYPMX.DataSource;
                        if (tb.Rows[j]["选"].ToString() == "0")
                        {
                            DataTable tbmx = myFunc.Gxypsl(ypmxtb, 0, cjid, ref ReturnValue, ref je);
                            dgYPMX.DataSource = tbmx;
                            //tb.Rows[curindex]["领药数"] = 0;  
                        }
                        else
                        {
                            DataTable tbmx = myFunc.Gxypsl(ypmxtb, Convert.ToInt32(tb.Rows[j]["领药数"].ToString()), cjid, ref ReturnValue, ref je);
                            dgYPMX.DataSource = tbmx;
                            tb.Rows[j]["领药数"] = ReturnValue;
                            tb.Rows[j]["金额"] = je;
                            Gethj(dgex);
                        }

                    }

                }
            }
        }
        /// <summary>
        /// 通过条件检索
        /// </summary>
        private void serchText1_TextChage()
        {
            serchText1.BringToFront();
            yptb.DefaultView.RowFilter = "pym like '%" + this.serchText1.textBox1.Text.Trim() + "%' or wbm like '%" + this.serchText1.textBox1.Text.Trim() + "%' or 药品名 like '%" + this.serchText1.textBox1.Text.Replace("%", "") + "%'";
            this.serchText1.tb = yptb.DefaultView.ToTable();
        }
        /// <summary>
        /// 赋值给控件
        /// </summary>
        private void serchText1_fz()
        {
            if (serchText1.row == null)
                return;
            DataRow row = serchText1.row;
            this.serchText1.textBox1.Text = row["药品名"].ToString().Trim();
            this.serchText1.textBox1.Tag = row["cjid"].ToString().Trim();
        }
        /// <summary>
        /// 检索
        /// </summary>
        private void serchText1_Js()
        {
            if (tabControl2.SelectedTab.Title.Trim() != "消息明细")
            {
                for (int i = 0; i < this.tabControl2.SelectedTab.Controls.Count; i++)
                {
                    if (this.tabControl2.SelectedTab.Controls[i].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                    {
                        TrasenClasses.GeneralControls.DataGridEx dgex = this.tabControl2.SelectedTab.Controls[i] as TrasenClasses.GeneralControls.DataGridEx;
                        int j = 0;
                        DataTable tb = (DataTable)dgex.DataSource;
                        for (j = 0; j < tb.Rows.Count - 1; j++)
                        {
                            if (this.serchText1.textBox1.Tag == null)
                                return;
                            if (tb.Rows[j]["cjid"].ToString() == this.serchText1.textBox1.Tag.ToString().Trim())
                            {
                                dgex.UnSelect(dgex.CurrentCell.RowNumber);
                                dgex.CurrentCell = new DataGridCell(j, 2);
                                dgex.Select(j);
                                break;
                            }

                        }
                    }
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0201)//鼠标单击
            {
                //  MessageBox.Show("dfd");
                // this.serchText1.TextLosfocus();
            }
            base.WndProc(ref m);
        }

        private void tabControl2_SelectionChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab.Title == "消息明细")
                serchText1.Visible = false;
            else
                serchText1.Visible = true;
        }

        private void btnFszdyf_Click(object sender, EventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            if (MessageBox.Show("您确认要把暂存药发送到指定药房吗,确认继续？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            string sqlerr = "";
            try
            {
                SystemCfg cfg7117 = new SystemCfg(7117);
                string execdeptid = cfg7117.Config.Trim();
                DataTable tbyf = (DataTable)cmbZxyf.DataSource;
                DataTable Yptable = null;
                //将暂存药导入到临时表
                for (int i = 0; i < tbyf.Rows.Count; i++)
                {
                    DataTable tmpable;
                    if (checkDQ.Checked)
                        tmpable = myFunc.ZYHS_YPFY_SELECT(9, 0, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(tbyf.Rows[i]["DEPTID"].ToString()));
                    else
                        tmpable = myFunc.ZYHS_YPFY_SELECT(9, 0, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentDept.WardId, Guid.Empty, 0, Convert.ToInt32(tbyf.Rows[i]["DEPTID"].ToString()), true);
                    if (Yptable == null)
                        Yptable = tmpable.Clone();
                    for (int j = 0; j < tmpable.Rows.Count; j++)
                    {
                        Yptable.ImportRow(tmpable.Rows[j]);
                    }
                    //增加暂存药品的负数到暂存药房
                    string ss = "";
                    //add by zouchihua 2013-5-27
                    if (checkDQ.Checked)
                        ss = "SELECT 0 序号,CAST(1 AS SMALLINT) 选,a.INPATIENT_ID,'' 类型, "
                           + " S_YPJX 剂型,YPPM 品名,YPSPM 商品名,YPGG 规格,S_SCCJ 厂家,   "
                          + "  CAST(COST_PRICE AS FLOAT) 单价,  "
        + "   null 库存数,0 数量,A.UNIT 单位,  "
        + "  CAST(SDVALUE AS FLOAT) 金额,SHH 货号,B.CJID,'' 床号,   "
        + "  '' 姓名, '' 住院号,A.DEPT_ID,  "
        + "   '' APPLY_ID,'' APPLY_DATE,CHARGE_BIT,'' WARD_ID,A.ID ZY_ID,UNITRATE,   "
        + "   CAST((A.NUM*A.DOSAGE*B.DWBL/UNITRATE) AS FLOAT) YPSL,  "
        + "   ZXDW,DWBL,B.PFJ/UNITRATE 批发价,  "
        + "     CAST((B.PFJ*A.NUM*A.DOSAGE/UNITRATE) AS FLOAT) 批发金额,   "
        + "    B.TLFL 统领分类,B.YPJX,ISNULL(F.ID,0) YPYF,F.NAME 药品用法,A.DEPT_LY,A.PRESC_DATE,B.TLFL,E.MNGTYPE  "
      + "   FROM ZY_FEE_SPECI A(NOLOCK)   "
    + "    INNER JOIN VI_YF_KCMX B(NOLOCK)   "
    + "   ON A.XMID=B.CJID AND A.XMLY=1 AND A.EXECDEPT_ID=B.DEPTID  "
                            //+"   INNER JOIN VI_ZY_VINPATIENT_ALL C   "
                            //+"    ON A.INPATIENT_ID=C.INPATIENT_ID AND A.BABY_ID=C.BABY_ID  "
    + " left JOIN ZY_ORDERRECORD E ON A.ORDER_ID=E.ORDER_ID  "
    + "    LEFT JOIN JC_USAGEDICTION F ON E.ORDER_USAGE=F.NAME where a.EXECDEPT_ID=" + execdeptid + " and a.TLFS=9 and a.CZ_FLAG=2 and a.DELETE_BIT=0 and a.charge_bit=1 and bz='暂存药自动记账' ";
                    else
                        ss = "SELECT 0 序号,CAST(1 AS SMALLINT) 选,a.INPATIENT_ID,'' 类型, "
                          + " S_YPJX 剂型,YPPM 品名,YPSPM 商品名,YPGG 规格,S_SCCJ 厂家,   "
                         + "  CAST(COST_PRICE AS FLOAT) 单价,  "
       + "   null 库存数,0 数量,A.UNIT 单位,  "
       + "  CAST(SDVALUE AS FLOAT) 金额,SHH 货号,B.CJID,'' 床号,   "
       + "  '' 姓名, '' 住院号,A.DEPT_ID,  "
       + "   '' APPLY_ID,'' APPLY_DATE,CHARGE_BIT,'' WARD_ID,A.ID ZY_ID,UNITRATE,   "
       + "   CAST((A.NUM*A.DOSAGE*B.DWBL/UNITRATE) AS FLOAT) YPSL,  "
       + "   ZXDW,DWBL,B.PFJ/UNITRATE 批发价,  "
       + "     CAST((B.PFJ*A.NUM*A.DOSAGE/UNITRATE) AS FLOAT) 批发金额,   "
       + "    B.TLFL 统领分类,B.YPJX,ISNULL(F.ID,0) YPYF,F.NAME 药品用法,A.DEPT_LY,A.PRESC_DATE,B.TLFL,E.MNGTYPE  "
     + "   FROM ZY_FEE_SPECI_h A(NOLOCK)   "
   + "    INNER JOIN VI_YF_KCMX B(NOLOCK)   "
   + "   ON A.XMID=B.CJID AND A.XMLY=1 AND A.EXECDEPT_ID=B.DEPTID  "
                            //+"   INNER JOIN VI_ZY_VINPATIENT_ALL C   "
                            //+"    ON A.INPATIENT_ID=C.INPATIENT_ID AND A.BABY_ID=C.BABY_ID  "
   + " left JOIN ZY_ORDERRECORD E ON A.ORDER_ID=E.ORDER_ID  "
   + "    LEFT JOIN JC_USAGEDICTION F ON E.ORDER_USAGE=F.NAME where a.EXECDEPT_ID=" + execdeptid + " and a.TLFS=9 and a.CZ_FLAG=2 and a.DELETE_BIT=0 and a.charge_bit=1 and bz='暂存药自动记账' ";
                    DataTable tem = FrmMdiMain.Database.GetDataTable(ss, 120);
                    for (int j = 0; j < tem.Rows.Count; j++)
                    {

                        Yptable.ImportRow(tem.Rows[i]);
                    }
                }
                #region 屏蔽以前的代码，放到事务里面进行处理
                //myFunc.SendYP(Yptable, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), Convert.ToInt64(execdeptid), 0, FrmMdiMain.Jgbm);
                ////FrmMdiMain.Database.BeginTransaction();

                //for (int i = 0; i < Yptable.Rows.Count; i++)
                //{
                //    string update = "update ZY_FEE_SPECI set  bz=cast(EXECDEPT_ID as varchar(20)),fy_bit=1,FY_DATE=getdate(),FY_USER =" + FrmMdiMain.CurrentUser.EmployeeId + " , EXECDEPT_ID=" + execdeptid + " where id= '" + Yptable.Rows[i]["zy_id"].ToString() + "'";
                //    sqlerr=update;
                //    FrmMdiMain.Database.DoCommand(update);
                //    if (checkLsk.Checked)
                //    {
                //        //add by zouchihua 2013-5-24 增加历史库
                //        update = "update ZY_FEE_SPECI_h set  bz=cast(EXECDEPT_ID as varchar(20)),fy_bit=1,FY_DATE=getdate(),FY_USER =" + FrmMdiMain.CurrentUser.EmployeeId + " , EXECDEPT_ID=" + execdeptid + " where id= '" + Yptable.Rows[i]["zy_id"].ToString() + "'";
                //        sqlerr=update;
                //        FrmMdiMain.Database.DoCommand(update);
                //    }
                //}
                ////生成发药信息
                //Guid group_id = Guid.Empty;
                //myFunc.Cszcyp(Yptable, InstanceForm.BCurrentDept.WardDeptId.ToString(), InstanceForm.BCurrentUser.EmployeeId, long.Parse(execdeptid), DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), FrmMdiMain.Jgbm,out  group_id);
                ////删除领药消息 add by zouchihua 2012-12-15
                //string udpatess = " update ZY_APPLY_DRUG set DELETE_BIT=1,GROUP_ID='"+group_id+"' where APPLY_NURSE=" + FrmMdiMain.CurrentUser.EmployeeId + " and DELETE_BIT=0 and EXECDEPT_ID=" + execdeptid + " ";
                //FrmMdiMain.Database.DoCommand(udpatess);
                #endregion
                //新代码
                SendTozCyf(Yptable, InstanceForm.BCurrentDept.WardDeptId.ToString(), long.Parse(execdeptid), DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), long.Parse(execdeptid));

                Cursor.Current = Cursors.Default;
                MessageBox.Show("发送成功！");
                bt刷新药品信息_Click(null, null);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message + " 出错sql :" + sqlerr);
                bt刷新药品信息_Click(null, null);
            }
        }
        /// <summary>
        /// 发送到制定暂存药房
        /// </summary>
        /// <param name="tb"></param>
        private void SendTozCyf(DataTable tb, string Wardeptid, long execdeptid, DateTime dt, long zcyf)
        {
            FrmJdt jdt = new FrmJdt();
            jdt.Show();
            DataTable groupbytb = groupby(tb);
            DataTable temptb = tb.Clone();
            jdt.progressBar1.Maximum = groupbytb.Rows.Count;
            jdt.progressBar1.Value = 0;
            try
            {
                for (int i = 0; i < groupbytb.Rows.Count; i++)
                {

                    temptb.Clear();
                    string cjid = groupbytb.Rows[i]["cjid"].ToString();
                    string dept_ly = groupbytb.Rows[i]["dept_ly"].ToString();
                    string ZXDW = groupbytb.Rows[i]["ZXDW"].ToString();
                    string tlfl = groupbytb.Rows[i]["tlfl"].ToString();
                    string 单价 = groupbytb.Rows[i]["单价"].ToString();
                    string dwbl = groupbytb.Rows[i]["dwbl"].ToString();
                    string UNITRATE = groupbytb.Rows[i]["UNITRATE"].ToString();
                    DataRow[] row = tb.Select("cjid=" + cjid + " and dept_ly=" + dept_ly + " and  ZXDW=" + ZXDW + " and  tlfl='" + tlfl + "' and 单价=" + 单价 + " and dwbl=" + dwbl + " and UNITRATE=" + UNITRATE + "");
                    for (int j = 0; j < row.Length; j++)
                    {
                        temptb.Rows.Add(row[j].ItemArray);
                    }
                    if (temptb.Rows.Count == 0)
                        continue;
                    Guid group_id = Guid.Empty;
                    Cszcyp(temptb, Wardeptid, FrmMdiMain.CurrentUser.EmployeeId, execdeptid, dt, FrmMdiMain.Jgbm, out  group_id);
                    jdt.progressBar1.Value = i + 1;
                    jdt.labjd.Text = "目前已经完成 " + System.Math.Round((decimal)(i + 1) / jdt.progressBar1.Maximum) * 100 + "%";
                    jdt.Refresh();
                }
            }
            catch (Exception ex)
            {
                jdt.Close();
                throw ex;
            }
            finally { jdt.Close(); }
        }
        /// <summary>
        /// 生成统领单据
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="Wardeptid"></param>
        /// <param name="EmpID"></param>
        /// <param name="ExecDept_Id"></param>
        /// <param name="dt"></param>
        /// <param name="Jgbm"></param>
        /// <param name="group_id"></param>
        public void Cszcyp(DataTable tb, string Wardeptid, long EmpID, long ExecDept_Id, DateTime dt, int Jgbm, out Guid group_id)
        {

            FrmMdiMain.Database.BeginTransaction();
            group_id = Guid.Empty;
            try
            {
                if (tb == null || tb.Rows.Count == 0)
                    return;
                decimal SUMPFJE = 0;
                decimal SUMLSJE = 0;
                ParameterEx[] parameters = new ParameterEx[24];
                Guid Group_id = Guid.NewGuid();
                group_id = Group_id;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    SUMPFJE += decimal.Parse(tb.Rows[i]["批发金额"].ToString());
                    SUMLSJE += decimal.Parse(tb.Rows[i]["金额"].ToString());
                    parameters[0].Text = "GROUPID";
                    parameters[0].Value = Group_id;
                    parameters[1].Text = "CJID";
                    parameters[1].Value = Int32.Parse(tb.Rows[i]["cjid"].ToString());
                    parameters[2].Text = "SHH";
                    parameters[2].Value = tb.Rows[i]["货号"].ToString();
                    parameters[3].Text = "YPPM";
                    parameters[3].Value = tb.Rows[i]["品名"].ToString();
                    parameters[4].Text = "YPSPM";
                    parameters[4].Value = tb.Rows[i]["商品名"].ToString();
                    parameters[5].Text = "YPGG";
                    parameters[5].Value = tb.Rows[i]["规格"].ToString();
                    parameters[6].Text = "YPDW";
                    parameters[6].Value = tb.Rows[i]["单位"].ToString();
                    parameters[7].Text = "SCCJ";
                    parameters[7].Value = tb.Rows[i]["厂家"].ToString();
                    parameters[8].Text = "KCL";//不设计到库存量
                    parameters[8].Value = 9999;
                    parameters[9].Text = "YPSL";
                    parameters[9].Value = Convert.ToDecimal(tb.Rows[i]["数量"].ToString());
                    parameters[10].Text = "QysL";
                    parameters[10].Value = 0;
                    parameters[11].Text = "PFJ";
                    parameters[11].Value = decimal.Parse(tb.Rows[i]["批发价"].ToString());
                    parameters[12].Text = "LSJ";
                    parameters[12].Value = decimal.Parse(tb.Rows[i]["单价"].ToString());
                    parameters[13].Text = "PFJE";
                    parameters[13].Value = decimal.Parse(tb.Rows[i]["批发金额"].ToString());
                    parameters[14].Text = "LSJE";
                    parameters[14].Value = decimal.Parse(tb.Rows[i]["金额"].ToString());
                    parameters[15].Text = "TLFL";
                    parameters[15].Value = tb.Rows[i]["TLFL"].ToString();
                    parameters[16].Text = "DWBL";
                    parameters[16].Value = tb.Rows[i]["UNITRATE"].ToString();
                    parameters[17].Text = "bkc";
                    parameters[17].Value = 0;
                    parameters[18].Text = "deptid";
                    parameters[18].Value = ExecDept_Id;
                    parameters[19].Text = "ypph";
                    parameters[19].Value = "";
                    parameters[20].Text = "fyid";
                    parameters[20].Value = Guid.Empty;
                    parameters[20].ParaDirection = ParameterDirection.Output;
                    parameters[21].Text = "ERR_CODE";
                    parameters[21].Value = 0;
                    parameters[21].ParaDirection = ParameterDirection.Output;
                    parameters[22].Text = "ERR_TEXT";
                    parameters[22].Value = "";
                    parameters[22].ParaDirection = ParameterDirection.Output;
                    parameters[23].Text = "hwh";
                    parameters[23].Value = "";
                    FrmMdiMain.Database.DoCommand("sp_YF_TLDMX_zcy", parameters, 60);
                    //group_id ,和APPLY_ID 都复制为Group_id
                    string update = "update ZY_FEE_SPECI set  bz=cast(EXECDEPT_ID as varchar(20)),fy_bit=1,FY_DATE=getdate(),APPLY_ID='" + Group_id + "',GROUP_ID='" + Group_id + "',FY_USER =" + FrmMdiMain.CurrentUser.EmployeeId + " , EXECDEPT_ID=" + ExecDept_Id + " where id= '" + tb.Rows[i]["zy_id"].ToString() + "'";

                    FrmMdiMain.Database.DoCommand(update);
                    if (checkLsk.Checked)
                    {
                        //add by zouchihua 2013-5-24 增加历史库
                        update = "update ZY_FEE_SPECI_h set  bz=cast(EXECDEPT_ID as varchar(20)),fy_bit=1,FY_DATE=getdate(),APPLY_ID='" + Group_id + "',GROUP_ID='" + Group_id + "',FY_USER =" + FrmMdiMain.CurrentUser.EmployeeId + " , EXECDEPT_ID=" + ExecDept_Id + " where id= '" + tb.Rows[i]["zy_id"].ToString() + "'";

                        FrmMdiMain.Database.DoCommand(update);
                    }
                }
                ParameterEx[] parameters1 = new ParameterEx[18];
                parameters1[0].Text = "DJH";
                parameters1[0].Value = 0;
                parameters1[1].Text = "DEPTID";
                parameters1[1].Value = ExecDept_Id;
                parameters1[2].Text = "FYRQ";
                parameters1[2].Value = dt.ToString();
                parameters1[3].Text = "FYR";
                parameters1[3].Value = EmpID;
                parameters1[4].Text = "dept_ly";
                parameters1[4].Value = Int32.Parse(Wardeptid);
                parameters1[5].Text = "NURSEID";
                parameters1[5].Value = 0;
                parameters1[6].Text = "PYR";
                parameters1[6].Value = EmpID;
                parameters1[7].Text = "bz";
                parameters1[7].Value = "";
                parameters1[8].Text = "SUMPFJE";
                parameters1[8].Value = SUMPFJE;
                parameters1[9].Text = "SUMLSJE";
                parameters1[9].Value = SUMLSJE;
                parameters1[10].Text = "STYPE";
                parameters1[10].Value = "统领";
                parameters1[11].Text = "ywlx";
                parameters1[11].Value = "020";
                parameters1[12].Text = "GROUPID";
                parameters1[12].Value = Group_id;
                parameters1[13].Text = "ERR_CODE";
                parameters1[13].Value = 0;
                parameters1[13].ParaDirection = ParameterDirection.Output;
                parameters1[14].Text = "ERR_TEXT";
                parameters1[14].Value = "";
                parameters1[14].ParaDirection = ParameterDirection.Output;
                parameters1[15].Text = "jgbm";
                parameters1[15].Value = Jgbm;
                parameters1[16].Text = "wkdz";
                parameters1[16].Value = "";
                parameters1[17].Text = "LYLX";
                parameters1[17].Value = 0;

                FrmMdiMain.Database.DoCommand("sp_YF_TLD_zcy", parameters1, 120);
                FrmMdiMain.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                FrmMdiMain.Database.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }
        private DataTable groupby(DataTable tbtb)
        {
            string[] GroupbyField1 ={ "cjid", "ZXDW", "tlfl", "单价", "UNITRATE" };
            string[] ComputeField1 ={ "数量", "金额", "ypsl" };
            string[] CField1 ={ "sum", "sum", "sum" };
            int j = 0;
            DataTable tbcompute = new DataTable();
            tbcompute.Columns.Add("cjid", typeof(int));
            tbcompute.Columns.Add("dept_ly", typeof(int));
            tbcompute.Columns.Add("ZXDW", typeof(int));
            tbcompute.Columns.Add("tlfl", typeof(string));
            tbcompute.Columns.Add("单价", typeof(decimal));
            tbcompute.Columns.Add("dwbl", typeof(int));
            tbcompute.Columns.Add("数量", typeof(decimal));
            tbcompute.Columns.Add("金额", typeof(decimal));
            tbcompute.Columns.Add("ypsl", typeof(decimal));
            tbcompute.Columns.Add("UNITRATE", typeof(int));
            DataTable tb = tbtb.Copy();
            for (int i = 0; 0 < tb.Rows.Count; i++)
            {
                string cjid = tb.Rows[0]["cjid"].ToString();
                string dept_ly = tb.Rows[0]["dept_ly"].ToString();
                string ZXDW = tb.Rows[0]["ZXDW"].ToString();
                string tlfl = tb.Rows[0]["tlfl"].ToString();
                string 单价 = tb.Rows[0]["单价"].ToString();
                string dwbl = tb.Rows[0]["dwbl"].ToString();
                string UNITRATE = tb.Rows[0]["UNITRATE"].ToString();
                DataRow insertrow = tbcompute.NewRow();
                insertrow["cjid"] = tb.Rows[0]["cjid"];
                insertrow["dept_ly"] = tb.Rows[0]["dept_ly"];
                insertrow["ZXDW"] = tb.Rows[0]["ZXDW"];
                insertrow["tlfl"] = tb.Rows[0]["tlfl"];
                insertrow["单价"] = tb.Rows[0]["单价"];
                insertrow["dwbl"] = tb.Rows[0]["dwbl"];
                insertrow["UNITRATE"] = tb.Rows[0]["UNITRATE"];
                tb.DefaultView.RowFilter = "cjid=" + cjid + " and dept_ly=" + dept_ly + " and  ZXDW=" + ZXDW + " and  tlfl='" + tlfl + "' and 单价=" + 单价 + " and dwbl=" + dwbl + "   and UNITRATE=" + UNITRATE + "";
                DataTable temp = tb.DefaultView.ToTable();

                insertrow["数量"] = decimal.Parse(temp.Compute("sum(数量)", "").ToString());
                // writelog("获得数量");
                insertrow["金额"] = decimal.Parse(temp.Compute("sum(金额)", "").ToString());
                // writelog("获得金额");
                insertrow["ypsl"] = decimal.Parse(temp.Compute("sum(ypsl)", "").ToString());
                tbcompute.Rows.Add(insertrow);

                DataRow[] row = tb.Select("cjid=" + cjid + " and dept_ly=" + dept_ly + " and  ZXDW=" + ZXDW + " and  tlfl='" + tlfl + "' and 单价=" + 单价 + " and dwbl=" + dwbl + " and UNITRATE=" + UNITRATE + "");

                for (int w = 0; w < row.Length; w++)
                {
                    tb.Rows.Remove(row[w]);
                    j++;
                }



            }
            tbcompute.TableName = "tbcompute";
            tbcompute.WriteXml("tbcompute.xml");
            return tbcompute;
        }
        private void 取消统领单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确认要取消统领信息吗,确认继续？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            DataTable tb = (DataTable)this.myDataGridXX.DataSource;
            int index = this.myDataGridMX.CurrentCell.RowNumber;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["选"].ToString() == "True")
                {
                    FrmMdiMain.Database.BeginTransaction();
                    try
                    {
                        string applyid = tb.Rows[i]["APPLY_ID"].ToString();
                        string update = "update zy_fee_speci set apply_id=null where apply_id='" + applyid + "' and fy_bit=0";
                        FrmMdiMain.Database.DoCommand(update);
                        update = "update ZY_APPLY_DRUG set DELETE_BIT=1 where apply_id='" + applyid + "'";
                        FrmMdiMain.Database.DoCommand(update);
                        FrmMdiMain.Database.CommitTransaction();
                        MessageBox.Show("取消成功成功！");
                    }
                    catch (Exception ex)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            bt刷新消息_Click(null, null);
        }

        private void myDataGridMX_MouseClick(object sender, MouseEventArgs e)
        {
            // if (e.Button == MouseButtons.Left)
            //   myFunc.SelCol_Click(this.myDataGridMX);
        }

        private void myDataGridXX_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                myFunc.SelCol_Click(this.myDataGridXX);
        }

        private void checkLsk_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLsk.Checked)
            {
                checkDQ.Checked = false;
            }
            else
                checkDQ.Checked = true;
            //bt刷新药品信息_Click(null, null);
        }

        private void checkDQ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDQ.Checked)
            {
                checkLsk.Checked = false;
            }
            else
                checkLsk.Checked = true;
            bt刷新药品信息_Click(null, null);
        }
        FrmZcyGl zcygl = null;
        FrmZcySj zcysj = null;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zcygl != null && this.tabControl1.SelectedTab.Name == "tabPage3")
            {
                zcygl.FrmZcyGl_Load(null, null);
            }
        }

        //add by jchl
        private void txtYpTl_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tbTl = (DataTable)this.myDataGridTL.DataSource;

            if (tbTl == null || tbTl.Rows.Count <= 0)
                return;

            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";

                tbTl.DefaultView.RowFilter = "";
                //tbTl = tbTl.DefaultView.Table;
                myDataGridTL.DataSource = tbTl.DefaultView.Table;
                return;
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { }
            else { return; }

            try
            {
                string[] GrdMappingName;
                int[] GrdWidth;
                string[] sfield;
                string ssql = "";
                DataRow row;
                //Modify by zouchihua 2012-3-12 定位
                Point newpoint = this.panel6.PointToScreen(control.Location);
                Point point = newpoint;
                point.Offset(0, 20);// new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.Name)
                {
                    case "txtYp":
                        if (control.Text.Trim() == "") return;
                        GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                        GrdWidth = new int[] { 0, 0, 50, 200, 100, 100, 40, 0, 60, 60, 70 };
                        sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                        ssql = @"select a.ggid,cjid,0  rowno,ypspm,ypgg,s_sccj sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh 
                                    from vi_yf_kcmx a,yp_ypbm b 
                                    where a.ggid=b.ggid and rtrim(ltrim(dbo.fun_getDeptname(deptid)))='" + execDept.Trim() + @"' and bdelete_kc=0 and 
                                    a.ypzlx in(select ypzlx from yp_gllx where rtrim(ltrim(dbo.fun_getDeptname(deptid)))='" + execDept.Trim() + "' )";

                        TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, Constant.CustomFilterType, control.Text.Trim(), ssql);
                        f2.Location = point;
                        f2.Width = 700;
                        f2.Height = 300;
                        f2.ShowDialog(this);
                        row = f2.dataRow;
                        if (row != null)
                        {
                            control.Text = row["ypspm"].ToString();
                            control.Tag = row["cjid"].ToString();
                            //control.Select();
                            //this.SelectNextControl((Control)sender, true, false, true, true);
                            string swhere = " 编号='" + row["shh"].ToString() + "'";
                            tbTl.DefaultView.RowFilter = swhere;
                            (control as TextBox).SelectAll();
                        }
                        break;

                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        private void chkBed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBed.Checked)
            {
                txtMxBed.Enabled = true;
                txtMxBed.Focus();
            }
            else
            {
                txtMxBed.Enabled = false;
                txtMxBed.Text = "";

                DataTable dt = myDataGridMX.DataSource as DataTable;
                if (dt == null || dt.Rows.Count <= 0)
                    return;

                DoFilMx(dt);
            }
        }

        private void chkZyh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkZyh.Checked)
            {
                txtMxZyh.Enabled = true;
                txtMxZyh.Focus();
            }
            else
            {
                txtMxZyh.Enabled = false;
                txtMxZyh.Text = "";

                DataTable dt = myDataGridMX.DataSource as DataTable;
                if (dt == null || dt.Rows.Count <= 0)
                    return;

                DoFilMx(dt);
            }
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked)
            {
                txtMxName.Enabled = true;
                txtMxName.Focus();
            }
            else
            {
                txtMxName.Enabled = false;
                txtMxName.Text = "";

                DataTable dt = myDataGridMX.DataSource as DataTable;
                if (dt == null || dt.Rows.Count <= 0)
                    return;

                DoFilMx(dt);
            }
        }

        private void DoFilMx(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            DataTable dt = myDataGridMX.DataSource as DataTable;
            if (dt == null || dt.Rows.Count <= 0)
                return;

            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;
            try
            {
                if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { }
                else { return; }

                if (nkey == 13)
                {
                    string swhere = "1=1 ";
                    swhere += chkBed.Checked ? "and 床号='" + txtMxBed.Text.Trim() + "'" : "";
                    swhere += chkZyh.Checked ? "and 住院号='" + txtMxZyh.Text.Trim() + "'" : "";
                    swhere += chkName.Checked ? "and 姓名='" + txtMxName.Text.Trim() + "'" : "";

                    dt.DefaultView.RowFilter = swhere;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void DoFilMx(DataTable dt)
        {
            dt = dt.DefaultView.Table;

            string swhere = "1=1 ";
            swhere += chkBed.Checked ? "and 床号 ='" + txtMxBed.Text.Trim() + "'" : "";
            swhere += chkZyh.Checked ? "and 住院号 like '%" + txtMxZyh.Text.Trim() + "%'" : "";
            swhere += chkName.Checked ? "and 姓名 like '%" + txtMxName.Text.Trim() + "%'" : "";

            dt.DefaultView.RowFilter = swhere;
        }

    }
}