using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Drawing.Drawing2D;
using Ts_zyys_public;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using ts_mzys_yjsqd;
using Ts_Clinicalpathway_Factory;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text;
namespace Ts_zyys_jcsq
{
    //public enum Typely
    //{
    //    住院 = 1,
    //    门诊 = 2,
    //}

    //public struct Cf
    //{
    //    public Guid brxxid;
    //    public Guid ghxxid;
    //    public Guid jzid;
    //    public string brxm;
    //    public string xb;
    //    public string nl;
    //    public string gzdw;
    //    public string lxfs;
    //    public string tz;
    //    public string mzh;
    //    public Guid yjsqid;
    //    public Guid yzid;
    //    public int sqys;
    //    public int sqks;
    //}

    /// <summary>
    /// FrmJCSQBW 的摘要说明。
    /// </summary>
    public class FrmJCSQBW : System.Windows.Forms.Form
    {
        /// <summary>
        /// 获得院区tb
        /// </summary>
        public DataTable Yqtb = new DataTable();

        private DbQuery myQuery = new DbQuery();
        private DataGridTableStyle GrdTableS = new DataGridTableStyle();

        public string _Zyid = "";//add by jchl
        public string fylb = "";//add by jchl

        public long YS_ID = 0;
        public long DeptID = 0;
        public string WardID = "";
        public string YS_pw = "";
        public Guid BinID = Guid.Empty;
        public long BabyID = 0;
        public long Dept_Br = 0;
        public User YS = null;
        public long lg = 0;//权限
        private System.Data.DataSet ds = new DataSet();
        private System.Data.DataTable dt = new DataTable();
        public System.Drawing.Brush brush;
        public System.Drawing.Font font;
        private string stritem = "";
        private DataTable jcTypeTb = new DataTable();
        private DataTable itemTb = new DataTable();
        private string printType = "";//打印类型
        private string printFile = "";//打印报表文件
        private DataRow[] dr;
        private DataTable mydt = new DataTable();
        private decimal pr = 0;
        private int IDeptID = -1;
        private int IClassID = -1;
        private bool _isHideJySq = false;
        private DateTime MaxdTime;//补录时间的最大值
        private DateTime MindTime;//补录时间的最小值
        private DataTable dt_item = new DataTable();


        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public RichTextBox richRecord;
        public Label lbPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public TextBox txtDiag;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox chkListBox;
        private System.Windows.Forms.Label lbCaption;
        private System.Windows.Forms.DataGrid GrdJY;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numUpDown;
        private System.Windows.Forms.TextBox txtDM;
        private System.Windows.Forms.Label lbDateTime;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.CheckBox chkMore;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ComboBox cmbPlace;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private TrasenClasses.GeneralControls.LabelEx label17;
        private System.Windows.Forms.RichTextBox richJC;
        private System.Windows.Forms.CheckBox chkBox1;
        private System.Windows.Forms.CheckBox chkBox2;
        private System.Windows.Forms.CheckBox chkBox3;
        private Ts_zyys_public.PatientBar patientBar1;
        private System.Windows.Forms.ImageList imageList_tab;
        private System.Windows.Forms.ImageList imageList1;
        private Label label1;
        private ComboBox cmbTc;
        private Button btDelTC;
        private Button btSaveTC;
        private Ts_Ba_tj.DataGridviewEx dataGridviewEx1;
        private Ts_Clinicalpathway_Factory.DataGridViewGroupColumn dataGridViewGroupColumn1;
        private GroupBox groupBox1;
        private ToolStrip toolStrip1;
        private Label label2;
        public RichTextBox richTextBox1;
        private ListView listView1;
        private Button button6;
        private Button button4;
        private GroupBox groupBox2;
        private Button button7;
        private Button button5;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader6;
        private Button button8;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnGetTemplete;
        private Button btnSave;
        private Label label3;
        private TextBox txtAClass;
        private Label label4;
        private TextBox txtADept;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader5;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton4;
        private System.ComponentModel.IContainer components;
        public Cf Dqcf = new Cf();
        private TabControl tabControl2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Label lblxm;
        private Label label5;
        private Label lblmzh;
        private Label label10;
        private Label label15;
        private Label label13;
        private Label lbllxdh;
        private Label lblnl;
        private Label label14;
        private Label lblxb;
        private Label lblgzdw;
        private Label label21;
        private Label label22;
        private Label lbltz;
        private ColumnHeader columnHeader7;
        public Typely BrLy = Typely.住院;//默认为住院
        private SystemCfg cfg6080 = new SystemCfg(6080);

        public bool issfy = false;
        public bool Xg = false;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem 展开ToolStripMenuItem;
        private ToolStripMenuItem 折叠ToolStripMenuItem;
        private ComboBox cmbYQ;
        private Label label23;
        private CheckBox chcekbl;
        private DateTimePicker DtpbeginDate;
        private Button btnQuery;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private Button btEmr;
        public DataTable tbxg = new DataTable();

        //add by 岳成成 2014-11-28
        public Guid _tsapply_id = Guid.Empty;//申请id
        public int _Apply_type = 0;//0=正常  包括 1=特殊治疗，2=手术申请，3=转科 4=会诊 ;

        /// <summary>
        /// 申请科室id add by zouchihua 2014-9-30 为了划价时用
        /// </summary>
        public int sqks = 0;
        public RichTextBox txtJcResult;
        private Label label24;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewGroupColumn Column2;
        private DataGridViewTextBoxColumn order_unit;
        private DataGridViewTextBoxColumn clDeptName;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn clDeptID;
        private DataGridViewTextBoxColumn clClassId;
        private DataGridViewTextBoxColumn clClassName;
        private DataGridViewTextBoxColumn clOrderId;
        private DataGridViewTextBoxColumn BW_CODE;
        //private DataGridView GrdSel;
        /// <summary>
        /// 申请室生id add by zouchihua 2014-9-30 为了划价时用
        /// </summary>
        public int sqys = 0;
        // <summary>
        /// 控制ListView项之间的距离
        /// </summary>
        /// <param name="Handle"></param>
        /// <param name="wMsg"></param>
        /// <param name="wParam">水平间距</param>
        /// <param name="lParam">垂直间距</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        /// <summary>
        /// 提供Win32的消息发送,发送后等到处理完成然后返回
        /// </summary>
        /// <param name="hWnd">要发送消息窗体的句柄</param>
        /// <param name="Msg">需要发送的指定消息</param>
        /// <param name="wParam">需要发送的指定附加消息</param>
        /// <param name="lParam">需要发送的指定附加消息</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        /// <summary>
        /// 提供Win32的消息发送,发送后立即返回
        /// </summary>
        /// <param name="hWnd">要发送消息窗体的句柄</param>
        /// <param name="Msg">需要发送的指定消息</param>
        /// <param name="wParam">需要发送的指定附加消息</param>
        /// <param name="lParam">需要发送的指定附加消息</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern bool PostMessage(int hWnd, int Msg, int wParam, int lParam);
        const int LVM_FIRST = 0x1000;
        const int LVM_SETICONSPACING = LVM_FIRST + 53;
        public static void SetListViewSpacing(ListView lst, int x, int y)
        {
            SendMessage(lst.Handle.ToInt32(), LVM_SETICONSPACING, 0, x * 65536 + y);
        }
        public FrmJCSQBW()
        {
            InitializeComponent();
        }
        public FrmJCSQBW(bool isHideJySq)
        {
            InitializeComponent();

            _isHideJySq = isHideJySq;
        }
        public FrmJCSQBW(long currentUser, long currentDept, string formText, object[] _value)
        {
            InitializeComponent();

            BinID = new Guid(Convertor.IsNull(_value[0], Guid.Empty.ToString()));

            YS = new User(Convert.ToInt64(currentUser), FrmMdiMain.Database);

            YS_ID = YS.EmployeeId;
            DeptID = currentDept;
            WardID = _value[1].ToString();
            BabyID = Convert.ToInt64(Convertor.IsNull(_value[4], "0"));
            lg = Convert.ToInt64(Convertor.IsNull(_value[5], "0"));

            try
            {
                sqks = Convert.ToInt32(Convertor.IsNull(_value[13], "0"));
                sqys = Convert.ToInt32(Convertor.IsNull(_value[14], "0"));
            }
            catch { }
        }
        public FrmJCSQBW(long currentUser, long currentDept, string formText)
        {
            InitializeComponent();
        }

        #region 自定义项
        /// <summary>
        /// 自定义项
        /// </summary>
        public class Item
        {
            private long _id;
            private string _name;
            private string _unit;
            private string _usage;
            private long _dept;
            private string _pym;
            private string _bz;
            private short _booking;

            /// <summary>
            /// 分组组号
            /// </summary>
            private long _groupid;//add by zouchihua 2011-12-16

            //Modify by jchl(whzxyy)
            //private Guid _jc_no;
            private int _jc_no;

            public int jc_no
            {
                get { return _jc_no; }
                set { _jc_no = value; }
            }

            //private string _sqsj;

            //public string sqsj
            //{
            //    get { return _sqsj; }
            //    set { _sqsj = value; }
            //}

            private long _DefaultDept;//add by caicheng 2013-05-21
            private long _JcxtId;//add by zouchihua 2013-05-21
            private decimal _zfbl;//add by jchl 2014-08-07

            private string _zysx;//add by jchl 2014-08-25 注意事项
            public string Zysx
            {
                get { return _zysx; }
                set { _zysx = value; }
            }

            private string _lczd;//add by jchl 2014-08-25 临床诊断
            public string Lczd
            {
                get { return _lczd; }
                set { _lczd = value; }
            }

            public Item()
            {
                _id = 0;
                _name = "";
                _unit = "";
                _usage = "";
                _dept = 0;
                _pym = "";
                _bz = "";
                _booking = 0;
                _groupid = -1;
                _jc_no = -1;
                _DefaultDept = -1;
                _JcxtId = -1;

                _lczd = "";
                _zysx = "";
                _zfbl = 1;
            }

            /// <summary>
            /// 自费比例
            /// </summary>
            public decimal Zfbl
            {
                get { return _zfbl; }
                set { _zfbl = value; }
            }
            /// <summary>
            /// 检查项目ID
            /// </summary>
            public long orderID
            {
                get { return _id; }
                set { _id = value; }
            }
            /// <summary>
            /// 检查项目名称
            /// </summary>
            public string orderName
            {
                get { return _name; }
                set { _name = value; }
            }

            /// <summary>
            /// 检查项目单位
            /// </summary>
            public string orderUnit
            {
                get { return _unit; }
                set { _unit = value; }
            }
            /// <summary>
            /// 检查项目用法
            /// </summary>
            public string defaultUsage
            {
                get { return _usage; }
                set { _usage = value; }
            }
            /// <summary>
            /// 项目的执行科室
            /// </summary>
            public long execDept
            {
                get { return _dept; }
                set { _dept = value; }
            }
            /// <summary>
            /// 项目分组组号
            /// </summary>
            public long groupid
            {
                get { return _groupid; }
                set { _groupid = value; }
            }
            /// <summary>
            /// 拼音码
            /// </summary>
            public string pym
            {
                get { return _pym; }
                set { _pym = value; }
            }
            /// <summary>
            /// 备注
            /// </summary>
            public string BZ
            {
                get { return _bz; }
                set { _bz = value; }
            }
            /// <summary>
            /// 是否是预约项目(1 预约，0非预约）
            /// </summary>
            public short booking
            {
                get { return _booking; }
                set { _booking = value; }
            }

            public long DefaultDept
            {
                get { return _DefaultDept; }
                set { _DefaultDept = value; }
            }
            public long JcxmId
            {
                get { return _JcxtId; }
                set { _JcxtId = value; }
            }
            public override string ToString()
            {
                return _name.Trim();
            }
        }
        #endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJCSQBW));
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.btEmr = new System.Windows.Forms.Button();
            this.richRecord = new System.Windows.Forms.RichTextBox();
            this.btnGetTemplete = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.txtAClass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtADept = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtJcResult = new System.Windows.Forms.RichTextBox();
            this.chcekbl = new System.Windows.Forms.CheckBox();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.cmbYQ = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dataGridviewEx1 = new Ts_Ba_tj.DataGridviewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new Ts_Clinicalpathway_Factory.DataGridViewGroupColumn();
            this.order_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clClassId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BW_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.展开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.折叠ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTc = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.lbDateTime = new System.Windows.Forms.Label();
            this.txtDiag = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMore = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.chkBox3 = new System.Windows.Forms.CheckBox();
            this.chkBox2 = new System.Windows.Forms.CheckBox();
            this.chkBox1 = new System.Windows.Forms.CheckBox();
            this.cmbPlace = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lbCaption = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkListBox = new System.Windows.Forms.CheckedListBox();
            this.numUpDown = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.richJC = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label17 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GrdJY = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.imageList_tab = new System.Windows.Forms.ImageList(this.components);
            this.button8 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btDelTC = new System.Windows.Forms.Button();
            this.btSaveTC = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.patientBar1 = new Ts_zyys_public.PatientBar();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblxm = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblmzh = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbllxdh = new System.Windows.Forms.Label();
            this.lblnl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblxb = new System.Windows.Forms.Label();
            this.lblgzdw = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lbltz = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataGridViewGroupColumn1 = new Ts_Clinicalpathway_Factory.DataGridViewGroupColumn();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridviewEx1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdJY)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1013, 566);
            this.panel3.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ImageList = this.imageList_tab;
            this.tabControl1.ItemSize = new System.Drawing.Size(84, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1013, 566);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btEmr);
            this.tabPage1.Controls.Add(this.richRecord);
            this.tabPage1.Controls.Add(this.btnGetTemplete);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.txtAClass);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtADept);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.chkMore);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.chkBox3);
            this.tabPage1.Controls.Add(this.chkBox2);
            this.tabPage1.Controls.Add(this.chkBox1);
            this.tabPage1.Controls.Add(this.cmbPlace);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.lbCaption);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.chkListBox);
            this.tabPage1.Controls.Add(this.numUpDown);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1005, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "检查申请录入";
            this.tabPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage1_Paint);
            this.tabPage1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPage1_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(465, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 336);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已选择项目";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton4});
            this.toolStrip2.Location = new System.Drawing.Point(3, 19);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(529, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton1.Text = "删除";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton4.Text = "打印";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader10,
            this.columnHeader13,
            this.columnHeader12,
            this.columnHeader4,
            this.columnHeader11,
            this.columnHeader6,
            this.columnHeader9,
            this.columnHeader8,
            this.columnHeader7,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 50);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(530, 280);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "部位";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "数量";
            this.columnHeader5.Width = 51;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "单位";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "价格";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "金额";
            this.columnHeader13.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "检查科室";
            this.columnHeader12.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "默认用法";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "项目分类";
            this.columnHeader11.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "医嘱ID";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "项目分类ID";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "检查科室ID";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "套餐id";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "临床诊断";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "注意事项";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "检查结果";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "检查部位CODE";
            // 
            // btEmr
            // 
            this.btEmr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btEmr.Location = new System.Drawing.Point(532, -2);
            this.btEmr.Name = "btEmr";
            this.btEmr.Size = new System.Drawing.Size(132, 23);
            this.btEmr.TabIndex = 190;
            this.btEmr.Text = "调用EMR简要病史";
            this.btEmr.UseVisualStyleBackColor = true;
            this.btEmr.Click += new System.EventHandler(this.btEmr_Click);
            // 
            // richRecord
            // 
            this.richRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richRecord.BackColor = System.Drawing.Color.White;
            this.richRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richRecord.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richRecord.Location = new System.Drawing.Point(467, 22);
            this.richRecord.Name = "richRecord";
            this.richRecord.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richRecord.Size = new System.Drawing.Size(531, 76);
            this.richRecord.TabIndex = 1;
            this.richRecord.Text = "";
            // 
            // btnGetTemplete
            // 
            this.btnGetTemplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetTemplete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetTemplete.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetTemplete.Location = new System.Drawing.Point(421, 63);
            this.btnGetTemplete.Name = "btnGetTemplete";
            this.btnGetTemplete.Size = new System.Drawing.Size(45, 35);
            this.btnGetTemplete.TabIndex = 185;
            this.btnGetTemplete.Text = "调用模板";
            this.btnGetTemplete.UseVisualStyleBackColor = true;
            this.btnGetTemplete.Click += new System.EventHandler(this.btnGetTemplete_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.Location = new System.Drawing.Point(429, 276);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(32, 27);
            this.button7.TabIndex = 100;
            this.button7.Text = "上一个(&F4)";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Location = new System.Drawing.Point(421, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(45, 37);
            this.btnSave.TabIndex = 184;
            this.btnSave.Text = "保存模板";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(429, 309);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(32, 27);
            this.button5.TabIndex = 99;
            this.button5.Text = "下一个(&F3)";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtAClass
            // 
            this.txtAClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAClass.Location = new System.Drawing.Point(387, 11);
            this.txtAClass.Name = "txtAClass";
            this.txtAClass.ReadOnly = true;
            this.txtAClass.Size = new System.Drawing.Size(10, 26);
            this.txtAClass.TabIndex = 189;
            this.txtAClass.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(334, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 188;
            this.label4.Text = "项目分类";
            this.label4.Visible = false;
            // 
            // txtADept
            // 
            this.txtADept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtADept.Location = new System.Drawing.Point(317, 11);
            this.txtADept.Name = "txtADept";
            this.txtADept.ReadOnly = true;
            this.txtADept.Size = new System.Drawing.Size(11, 26);
            this.txtADept.TabIndex = 187;
            this.txtADept.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.txtJcResult);
            this.groupBox2.Controls.Add(this.chcekbl);
            this.groupBox2.Controls.Add(this.DtpbeginDate);
            this.groupBox2.Controls.Add(this.cmbYQ);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.dataGridviewEx1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDM);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbTc);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbClass);
            this.groupBox2.Controls.Add(this.cmbDept);
            this.groupBox2.Controls.Add(this.lbDateTime);
            this.groupBox2.Controls.Add(this.txtDiag);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(3, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 500);
            this.groupBox2.TabIndex = 105;
            this.groupBox2.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(33, 163);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(189, 14);
            this.label24.TabIndex = 108;
            this.label24.Text = "特殊检查及实验室检查结果：";
            // 
            // txtJcResult
            // 
            this.txtJcResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJcResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtJcResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtJcResult.Location = new System.Drawing.Point(32, 182);
            this.txtJcResult.Name = "txtJcResult";
            this.txtJcResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtJcResult.Size = new System.Drawing.Size(382, 50);
            this.txtJcResult.TabIndex = 107;
            this.txtJcResult.Text = "";
            // 
            // chcekbl
            // 
            this.chcekbl.AutoSize = true;
            this.chcekbl.Location = new System.Drawing.Point(10, 238);
            this.chcekbl.Name = "chcekbl";
            this.chcekbl.Size = new System.Drawing.Size(84, 24);
            this.chcekbl.TabIndex = 106;
            this.chcekbl.Text = "补录医嘱";
            this.chcekbl.UseVisualStyleBackColor = true;
            this.chcekbl.Visible = false;
            this.chcekbl.CheckedChanged += new System.EventHandler(this.chcekbl_CheckedChanged);
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DtpbeginDate.Enabled = false;
            this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(105, 240);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(163, 21);
            this.DtpbeginDate.TabIndex = 105;
            this.DtpbeginDate.Value = new System.DateTime(2004, 6, 25, 0, 0, 0, 0);
            this.DtpbeginDate.Visible = false;
            // 
            // cmbYQ
            // 
            this.cmbYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbYQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbYQ.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbYQ.Location = new System.Drawing.Point(73, 22);
            this.cmbYQ.Name = "cmbYQ";
            this.cmbYQ.Size = new System.Drawing.Size(116, 23);
            this.cmbYQ.TabIndex = 104;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(29, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 14);
            this.label23.TabIndex = 103;
            this.label23.Text = "院区";
            // 
            // dataGridviewEx1
            // 
            this.dataGridviewEx1.AllowUserToAddRows = false;
            this.dataGridviewEx1.AllowUserToDeleteRows = false;
            this.dataGridviewEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridviewEx1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridviewEx1.checkindex = 0;
            this.dataGridviewEx1.ColumnHeadersHeight = 30;
            this.dataGridviewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridviewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.order_unit,
            this.clDeptName,
            this.Column4,
            this.clDeptID,
            this.clClassId,
            this.clClassName,
            this.clOrderId,
            this.BW_CODE});
            this.dataGridviewEx1.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridviewEx1.groupColumIndex = 1;
            this.dataGridviewEx1.IsCheck = true;
            this.dataGridviewEx1.Iszlfb = false;
            this.dataGridviewEx1.Location = new System.Drawing.Point(7, 268);
            this.dataGridviewEx1.Name = "dataGridviewEx1";
            this.dataGridviewEx1.ReadOnly = true;
            this.dataGridviewEx1.RowHeadersWidth = 45;
            this.dataGridviewEx1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridviewEx1.RowTemplate.Height = 23;
            this.dataGridviewEx1.Size = new System.Drawing.Size(415, 219);
            this.dataGridviewEx1.TabIndex = 98;
            this.dataGridviewEx1.Zlh = 0;
            this.dataGridviewEx1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridviewEx1_CellPainting);
            this.dataGridviewEx1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridviewEx1_CellClick);
            this.dataGridviewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridviewEx1_DataError);
            this.dataGridviewEx1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridviewEx1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "check";
            this.Column1.FalseValue = "0";
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "选择";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.TrueValue = "1";
            this.Column1.Width = 20;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "order_name";
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "内容";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 330;
            // 
            // order_unit
            // 
            this.order_unit.DataPropertyName = "order_unit";
            this.order_unit.Frozen = true;
            this.order_unit.HeaderText = "单位";
            this.order_unit.Name = "order_unit";
            this.order_unit.ReadOnly = true;
            this.order_unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.order_unit.Visible = false;
            this.order_unit.Width = 50;
            // 
            // clDeptName
            // 
            this.clDeptName.DataPropertyName = "DeptName";
            this.clDeptName.Frozen = true;
            this.clDeptName.HeaderText = "执行科室";
            this.clDeptName.Name = "clDeptName";
            this.clDeptName.ReadOnly = true;
            this.clDeptName.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "py_code";
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "拼音码";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Visible = false;
            this.Column4.Width = 50;
            // 
            // clDeptID
            // 
            this.clDeptID.DataPropertyName = "DEFAULT_DEPT";
            this.clDeptID.Frozen = true;
            this.clDeptID.HeaderText = "执行科室ID";
            this.clDeptID.Name = "clDeptID";
            this.clDeptID.ReadOnly = true;
            this.clDeptID.Visible = false;
            // 
            // clClassId
            // 
            this.clClassId.DataPropertyName = "JCLXID";
            this.clClassId.Frozen = true;
            this.clClassId.HeaderText = "项目分类ID";
            this.clClassId.Name = "clClassId";
            this.clClassId.ReadOnly = true;
            this.clClassId.Visible = false;
            // 
            // clClassName
            // 
            this.clClassName.DataPropertyName = "JCLXNaMe";
            this.clClassName.Frozen = true;
            this.clClassName.HeaderText = "项目分类名称";
            this.clClassName.Name = "clClassName";
            this.clClassName.ReadOnly = true;
            this.clClassName.Visible = false;
            // 
            // clOrderId
            // 
            this.clOrderId.DataPropertyName = "order_id";
            this.clOrderId.Frozen = true;
            this.clOrderId.HeaderText = "医嘱ID";
            this.clOrderId.Name = "clOrderId";
            this.clOrderId.ReadOnly = true;
            this.clOrderId.Visible = false;
            // 
            // BW_CODE
            // 
            this.BW_CODE.DataPropertyName = "BW_CODE";
            this.BW_CODE.Frozen = true;
            this.BW_CODE.HeaderText = "部位";
            this.BW_CODE.Name = "BW_CODE";
            this.BW_CODE.ReadOnly = true;
            this.BW_CODE.Visible = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.展开ToolStripMenuItem,
            this.折叠ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 48);
            // 
            // 展开ToolStripMenuItem
            // 
            this.展开ToolStripMenuItem.Name = "展开ToolStripMenuItem";
            this.展开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.展开ToolStripMenuItem.Text = "展开";
            this.展开ToolStripMenuItem.Click += new System.EventHandler(this.展开ToolStripMenuItem_Click);
            // 
            // 折叠ToolStripMenuItem
            // 
            this.折叠ToolStripMenuItem.Name = "折叠ToolStripMenuItem";
            this.折叠ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.折叠ToolStripMenuItem.Text = "折叠";
            this.折叠ToolStripMenuItem.Click += new System.EventHandler(this.折叠ToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(5, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 74;
            this.label6.Text = "检查项目";
            // 
            // txtDM
            // 
            this.txtDM.BackColor = System.Drawing.Color.Honeydew;
            this.txtDM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDM.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDM.Location = new System.Drawing.Point(73, 101);
            this.txtDM.Name = "txtDM";
            this.txtDM.Size = new System.Drawing.Size(90, 23);
            this.txtDM.TabIndex = 3;
            this.txtDM.TextChanged += new System.EventHandler(this.txtDM_TextChanged);
            this.txtDM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDM_KeyDown);
            this.txtDM.Leave += new System.EventHandler(this.txtDM_Leave);
            this.txtDM.Enter += new System.EventHandler(this.txtDM_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(169, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 97;
            this.label1.Text = "套餐选择";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTc
            // 
            this.cmbTc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTc.FormattingEnabled = true;
            this.cmbTc.Location = new System.Drawing.Point(245, 99);
            this.cmbTc.Name = "cmbTc";
            this.cmbTc.Size = new System.Drawing.Size(171, 28);
            this.cmbTc.TabIndex = 96;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(229, 62);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 14);
            this.label20.TabIndex = 84;
            this.label20.Text = "项目分类";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(194, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 65;
            this.label9.Text = "检查科室";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbClass
            // 
            this.cmbClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClass.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbClass.Location = new System.Drawing.Point(295, 60);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(121, 23);
            this.cmbClass.TabIndex = 85;
            // 
            // cmbDept
            // 
            this.cmbDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDept.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDept.Location = new System.Drawing.Point(263, 21);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(153, 23);
            this.cmbDept.TabIndex = 86;
            // 
            // lbDateTime
            // 
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDateTime.Location = new System.Drawing.Point(77, 63);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(58, 16);
            this.lbDateTime.TabIndex = 83;
            this.lbDateTime.Text = "label20";
            this.lbDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDateTime.Visible = false;
            // 
            // txtDiag
            // 
            this.txtDiag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiag.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDiag.Location = new System.Drawing.Point(73, 59);
            this.txtDiag.Name = "txtDiag";
            this.txtDiag.Size = new System.Drawing.Size(152, 24);
            this.txtDiag.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(355, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 19);
            this.label12.TabIndex = 69;
            this.label12.Text = "申请日期";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(7, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 71;
            this.label8.Text = "临床诊断";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(468, 116);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(531, 78);
            this.richTextBox1.TabIndex = 102;
            this.richTextBox1.Text = "";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button6.Location = new System.Drawing.Point(427, 289);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(36, 42);
            this.button6.TabIndex = 104;
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(465, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 14);
            this.label2.TabIndex = 101;
            this.label2.Text = "注意事项（目的）";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(284, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 186;
            this.label3.Text = "检查科室";
            this.label3.Visible = false;
            // 
            // chkMore
            // 
            this.chkMore.Checked = true;
            this.chkMore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMore.Location = new System.Drawing.Point(429, 196);
            this.chkMore.Name = "chkMore";
            this.chkMore.Size = new System.Drawing.Size(22, 24);
            this.chkMore.TabIndex = 87;
            this.chkMore.Text = "多选";
            this.chkMore.Visible = false;
            this.chkMore.CheckedChanged += new System.EventHandler(this.chkMore_CheckedChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(427, 338);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 42);
            this.button4.TabIndex = 103;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(465, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 68;
            this.label11.Text = "简要病史";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkBox3
            // 
            this.chkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBox3.Location = new System.Drawing.Point(701, 265);
            this.chkBox3.Name = "chkBox3";
            this.chkBox3.Size = new System.Drawing.Size(96, 24);
            this.chkBox3.TabIndex = 92;
            this.chkBox3.Tag = "【平扫＋增强】";
            this.chkBox3.Text = "平扫+增强";
            this.chkBox3.Visible = false;
            this.chkBox3.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
            // 
            // chkBox2
            // 
            this.chkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBox2.Location = new System.Drawing.Point(652, 265);
            this.chkBox2.Name = "chkBox2";
            this.chkBox2.Size = new System.Drawing.Size(64, 24);
            this.chkBox2.TabIndex = 91;
            this.chkBox2.Tag = "【直接增强】";
            this.chkBox2.Text = "增强";
            this.chkBox2.Visible = false;
            this.chkBox2.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
            // 
            // chkBox1
            // 
            this.chkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBox1.Location = new System.Drawing.Point(599, 266);
            this.chkBox1.Name = "chkBox1";
            this.chkBox1.Size = new System.Drawing.Size(65, 24);
            this.chkBox1.TabIndex = 90;
            this.chkBox1.Tag = "【平扫】";
            this.chkBox1.Text = "平扫";
            this.chkBox1.Visible = false;
            this.chkBox1.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
            // 
            // cmbPlace
            // 
            this.cmbPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPlace.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPlace.Location = new System.Drawing.Point(545, 512);
            this.cmbPlace.Name = "cmbPlace";
            this.cmbPlace.Size = new System.Drawing.Size(11, 23);
            this.cmbPlace.TabIndex = 88;
            this.cmbPlace.Visible = false;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label18.Location = new System.Drawing.Point(469, 514);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 14);
            this.label18.TabIndex = 80;
            this.label18.Text = "检查部位";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label18.Visible = false;
            // 
            // lbCaption
            // 
            this.lbCaption.AutoSize = true;
            this.lbCaption.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCaption.Location = new System.Drawing.Point(134, 6);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(135, 24);
            this.lbCaption.TabIndex = 78;
            this.lbCaption.Text = "检查申请单";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "<请选择>";
            this.label7.Visible = false;
            // 
            // chkListBox
            // 
            this.chkListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListBox.BackColor = System.Drawing.Color.Honeydew;
            this.chkListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkListBox.CheckOnClick = true;
            this.chkListBox.ColumnWidth = 280;
            this.chkListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkListBox.Font = new System.Drawing.Font("宋体", 11F);
            this.chkListBox.HorizontalExtent = 20;
            this.chkListBox.HorizontalScrollbar = true;
            this.chkListBox.Location = new System.Drawing.Point(297, 405);
            this.chkListBox.MultiColumn = true;
            this.chkListBox.Name = "chkListBox";
            this.chkListBox.Size = new System.Drawing.Size(145, 97);
            this.chkListBox.TabIndex = 73;
            this.chkListBox.Visible = false;
            this.chkListBox.SelectedIndexChanged += new System.EventHandler(this.chkListBox_SelectedIndexChanged);
            this.chkListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListBox_ItemCheck);
            this.chkListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkListBox_MouseDown);
            this.chkListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkListBox_KeyDown);
            // 
            // numUpDown
            // 
            this.numUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numUpDown.Enabled = false;
            this.numUpDown.Location = new System.Drawing.Point(873, 344);
            this.numUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown.Name = "numUpDown";
            this.numUpDown.Size = new System.Drawing.Size(40, 26);
            this.numUpDown.TabIndex = 5;
            this.numUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown.Visible = false;
            this.numUpDown.ValueChanged += new System.EventHandler(this.numUpDown_ValueChanged);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label19.Location = new System.Drawing.Point(801, 352);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 14);
            this.label19.TabIndex = 82;
            this.label19.Text = "部位数量";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label19.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.GrdJY);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1005, 536);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "检查申请查询";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.richJC);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Location = new System.Drawing.Point(40, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(696, 408);
            this.panel4.TabIndex = 7;
            this.panel4.Visible = false;
            // 
            // richJC
            // 
            this.richJC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richJC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richJC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richJC.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richJC.Location = new System.Drawing.Point(0, 43);
            this.richJC.Name = "richJC";
            this.richJC.Size = new System.Drawing.Size(692, 358);
            this.richJC.TabIndex = 8;
            this.richJC.Text = "";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.ImageIndex = 1;
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point(609, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "关闭";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // 
            // label17
            // 
            this.label17.BackColor1 = System.Drawing.Color.DimGray;
            this.label17.BackColor2 = System.Drawing.Color.LightGray;
            this.label17.Dock = System.Windows.Forms.DockStyle.Top;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(0, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(692, 40);
            this.label17.TabIndex = 7;
            this.label17.Text = "检查报告单";
            this.label17.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(692, 3);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 401);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(692, 3);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // GrdJY
            // 
            this.GrdJY.AllowSorting = false;
            this.GrdJY.AlternatingBackColor = System.Drawing.SystemColors.ScrollBar;
            this.GrdJY.BackgroundColor = System.Drawing.Color.Gray;
            this.GrdJY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdJY.DataMember = "";
            this.GrdJY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdJY.GridLineColor = System.Drawing.SystemColors.Desktop;
            this.GrdJY.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdJY.Location = new System.Drawing.Point(0, 0);
            this.GrdJY.Name = "GrdJY";
            this.GrdJY.Size = new System.Drawing.Size(1005, 536);
            this.GrdJY.TabIndex = 6;
            this.GrdJY.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.GrdJY.DoubleClick += new System.EventHandler(this.GrdJY_DoubleClick);
            this.GrdJY.CurrentCellChanged += new System.EventHandler(this.GrdJY_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.GrdJY;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // imageList_tab
            // 
            this.imageList_tab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_tab.ImageStream")));
            this.imageList_tab.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_tab.Images.SetKeyName(0, "");
            this.imageList_tab.Images.SetKeyName(1, "");
            this.imageList_tab.Images.SetKeyName(2, "");
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Location = new System.Drawing.Point(706, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(10, 26);
            this.button8.TabIndex = 106;
            this.button8.Text = "更改";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(436, 46);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(36, 367);
            this.toolStrip1.TabIndex = 100;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // lbPrice
            // 
            this.lbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPrice.ForeColor = System.Drawing.Color.Maroon;
            this.lbPrice.Location = new System.Drawing.Point(933, 8);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(76, 23);
            this.lbPrice.TabIndex = 77;
            this.lbPrice.Text = "0.00 元";
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label16.Location = new System.Drawing.Point(871, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 14);
            this.label16.TabIndex = 76;
            this.label16.Text = "检查费：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnQuery);
            this.panel2.Controls.Add(this.btPrint);
            this.panel2.Controls.Add(this.btDelTC);
            this.panel2.Controls.Add(this.btSaveTC);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.lbPrice);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 664);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1013, 39);
            this.panel2.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnQuery.Location = new System.Drawing.Point(435, 8);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(138, 30);
            this.btnQuery.TabIndex = 101;
            this.btnQuery.Text = "查看心电图结果(&Q)";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btPrint
            // 
            this.btPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrint.ForeColor = System.Drawing.Color.Black;
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageIndex = 14;
            this.btPrint.ImageList = this.imageList1;
            this.btPrint.Location = new System.Drawing.Point(439, 8);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(87, 30);
            this.btPrint.TabIndex = 3;
            this.btPrint.Text = "打印(&P)";
            this.btPrint.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btPrint.UseVisualStyleBackColor = false;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btDelTC
            // 
            this.btDelTC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDelTC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelTC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDelTC.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btDelTC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelTC.ImageIndex = 5;
            this.btDelTC.ImageList = this.imageList1;
            this.btDelTC.Location = new System.Drawing.Point(310, 8);
            this.btDelTC.Name = "btDelTC";
            this.btDelTC.Size = new System.Drawing.Size(121, 30);
            this.btDelTC.TabIndex = 7;
            this.btDelTC.Text = "删除套餐(&D)";
            this.btDelTC.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btDelTC.Click += new System.EventHandler(this.btDelTC_Click);
            // 
            // btSaveTC
            // 
            this.btSaveTC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSaveTC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveTC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSaveTC.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btSaveTC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSaveTC.ImageIndex = 0;
            this.btSaveTC.ImageList = this.imageList1;
            this.btSaveTC.Location = new System.Drawing.Point(183, 8);
            this.btSaveTC.Name = "btSaveTC";
            this.btSaveTC.Size = new System.Drawing.Size(121, 30);
            this.btSaveTC.TabIndex = 6;
            this.btSaveTC.Text = "保存套餐(&T)";
            this.btSaveTC.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btSaveTC.Click += new System.EventHandler(this.btSaveTC_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageIndex = 1;
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point(579, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "退出(&C)";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 16;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(89, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "提交(&O)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Controls.Add(this.tabControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 98);
            this.panel1.TabIndex = 5;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1013, 98);
            this.tabControl2.TabIndex = 56;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.patientBar1);
            this.tabPage4.Controls.Add(this.toolStrip1);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1005, 68);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "住院病人信息";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // patientBar1
            // 
            this.patientBar1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.patientBar1.BorderType = Ts_zyys_public.PatientBar.BorderStyle.Raised;
            this.patientBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientBar1.Location = new System.Drawing.Point(3, 3);
            this.patientBar1.Name = "patientBar1";
            this.patientBar1.Size = new System.Drawing.Size(999, 62);
            this.patientBar1.TabIndex = 55;
            this.patientBar1.Load += new System.EventHandler(this.patientBar1_Load);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tabPage3.Controls.Add(this.lblxm);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.lblmzh);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.lbllxdh);
            this.tabPage3.Controls.Add(this.lblnl);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.lblxb);
            this.tabPage3.Controls.Add(this.lblgzdw);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.lbltz);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1005, 72);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "门诊病人信息";
            // 
            // lblxm
            // 
            this.lblxm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblxm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblxm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxm.ForeColor = System.Drawing.Color.Navy;
            this.lblxm.Location = new System.Drawing.Point(46, 3);
            this.lblxm.Name = "lblxm";
            this.lblxm.Size = new System.Drawing.Size(82, 21);
            this.lblxm.TabIndex = 148;
            this.lblxm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(11, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 141;
            this.label5.Text = "姓名";
            // 
            // lblmzh
            // 
            this.lblmzh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblmzh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblmzh.ForeColor = System.Drawing.Color.Navy;
            this.lblmzh.Location = new System.Drawing.Point(391, 3);
            this.lblmzh.Name = "lblmzh";
            this.lblmzh.Size = new System.Drawing.Size(172, 22);
            this.lblmzh.TabIndex = 154;
            this.lblmzh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(145, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 142;
            this.label10.Text = "性别";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(335, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 14);
            this.label15.TabIndex = 153;
            this.label15.Text = "门诊号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(235, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 143;
            this.label13.Text = "年龄";
            // 
            // lbllxdh
            // 
            this.lbllxdh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbllxdh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllxdh.ForeColor = System.Drawing.Color.Navy;
            this.lbllxdh.Location = new System.Drawing.Point(640, 32);
            this.lbllxdh.Name = "lbllxdh";
            this.lbllxdh.Size = new System.Drawing.Size(228, 22);
            this.lbllxdh.TabIndex = 152;
            this.lbllxdh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblnl
            // 
            this.lblnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblnl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnl.ForeColor = System.Drawing.Color.Navy;
            this.lblnl.Location = new System.Drawing.Point(273, 4);
            this.lblnl.Name = "lblnl";
            this.lblnl.Size = new System.Drawing.Size(46, 21);
            this.lblnl.TabIndex = 144;
            this.lblnl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(589, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 151;
            this.label14.Text = "联系方式";
            // 
            // lblxb
            // 
            this.lblxb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblxb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxb.ForeColor = System.Drawing.Color.Navy;
            this.lblxb.Location = new System.Drawing.Point(179, 3);
            this.lblxb.Name = "lblxb";
            this.lblxb.Size = new System.Drawing.Size(36, 21);
            this.lblxb.TabIndex = 145;
            this.lblxb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblgzdw
            // 
            this.lblgzdw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblgzdw.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgzdw.ForeColor = System.Drawing.Color.Navy;
            this.lblgzdw.Location = new System.Drawing.Point(640, 3);
            this.lblgzdw.Name = "lblgzdw";
            this.lblgzdw.Size = new System.Drawing.Size(228, 22);
            this.lblgzdw.TabIndex = 150;
            this.lblgzdw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(9, 39);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 146;
            this.label21.Text = "体征";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(581, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 149;
            this.label22.Text = "工作单位";
            // 
            // lbltz
            // 
            this.lbltz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbltz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltz.ForeColor = System.Drawing.Color.Navy;
            this.lbltz.Location = new System.Drawing.Point(46, 34);
            this.lbltz.Name = "lbltz";
            this.lbltz.Size = new System.Drawing.Size(517, 21);
            this.lbltz.TabIndex = 147;
            this.lbltz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dataGridViewGroupColumn1
            // 
            this.dataGridViewGroupColumn1.DataPropertyName = "order_name";
            this.dataGridViewGroupColumn1.HeaderText = "内容";
            this.dataGridViewGroupColumn1.Name = "dataGridViewGroupColumn1";
            this.dataGridViewGroupColumn1.ReadOnly = true;
            // 
            // FrmJCSQBW
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1013, 703);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmJCSQBW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检查申请";
            this.Load += new System.EventHandler(this.FrmJCSQ_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJCSQBW_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmJCSQ_KeyDown);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridviewEx1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdJY)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region load事件
        private void FrmJCSQ_Load(object sender, System.EventArgs e)
        {
            //this.dataGridviewEx1.Columns.Clear();
            //string[] Columname = new string[] { "选择", "内容", "单位", "执行科室", "拼音码", "执行科室ID", "项目分类ID", "项目分类名称", "医嘱ID" };
            //string[] Values = new string[] { "check", "order_name", "order_unit", "DeptName", "py_code", "DEFAULT_DEPT", "JCLXID", "JCLXNaMe", "order_id" };
            //int[] colwidth = new int[] { 20, 245, 50, 100, 50, 100, 100, 100, 100 };
            //string[] Coltype = new string[]{PublicFunction.DgvColStype.CheckBoxColumn,PublicFunction.DgvColStype.GroupColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
            //,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn,PublicFunction.DgvColStype.TextBoxColumn
            //,PublicFunction.DgvColStype.TextBoxColumn};
            //PublicFunction.InitDgv(Columname, colwidth, Coltype, Values, dataGridviewEx1, 1);
            //this.dataGridviewEx1.ReadOnly = false;
            //this.dataGridviewEx1.Columns[0].ReadOnly = false;


            this.cmbDept.SelectedIndexChanged -= new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            cmbClass.SelectedIndexChanged -= new EventHandler(cmbClass_SelectedIndexChanged);
            //this.FormClosing += new FormClosingEventHandler(FrmJCSQ_FormClosing);
            this.cmbPlace.DisplayMember = "ORDER_POSITION";
            this.cmbPlace.ValueMember = "ORDER_ID";
            for (int j = 0; j < this.dataGridviewEx1.Columns.Count; j++)
            {
                this.dataGridviewEx1.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            if (BrLy == Typely.住院)
            {
                DataTable dataTable = FrmMdiMain.Database.GetDataTable("select * from vi_zy_vinpatient_all where baby_id=0 and inpatient_id='" + this.BinID + "'");
                this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm._database);//取数据库时间
                this.DtpbeginDate.MinDate = Convert.ToDateTime(Convertor.IsNull(dataTable.Rows[0]["in_date"], "1900-01-01 00:00:00"));

                this.DtpbeginDate.Visible = true;
                this.chcekbl.Visible = true;
                #region 病人信息
                //			Inpatient Inpt=new Inpatient(this.BinID);
                //			Patient pt=new Patient (Inpt.PatientID );
                //			lblName.Text=pt.Name.Trim();
                //			lblInpatientNo.Text =pt.Inpatient_No .Trim ();  
                //			sexNum=pt.Sex;
                //			lblSex.Text =(pt.Sex.ToString ()=="1")?"男":"女";
                //			lblage.Text = Convert.ToString(System.DateTime.Now.Year  -  pt.Birthday.Year);
                //			lblYJJ.Text ="￥"+Inpt.GetDeposits(true).ToString("0.00");
                //			lblTotal.Text="￥"+Inpt.GetFee().ToString("0.00");
                //			lblDiag.Text =Inpt.In_Diagnosis;
                //			lblWard.Tag  =WardID;
                //			lblWard.Text =myQuery.GetWardName(WardID);
                //			Birthday=pt.Birthday;
                //			
                //			lblBedNo.Text=Inpt.Bed_ID<=0 ? "" : myQuery.GetBedNO(Inpt.Bed_ID);
                //			try
                //			{
                //				Refresh();
                //			}
                //			catch(System.Exception err){MessageBox.Show(err.Message);}
                //			if(Inpt.Flag==2 || Inpt.Flag>=4)
                //			{
                //				MessageBox.Show("注意，该病人已经是出院病人，不允许再申请检查！");
                //				this.Close();
                //				return;
                //			}
                //			if(Inpt.DischargeType==DischargeMode.Insure_DischargeMode)
                //				lblName.ForeColor=Color.Red;
                //			else
                //				lblName.ForeColor=Color.Navy;
                #endregion
                patientBar1.PatientID = BinID;

                if (patientBar1.IsLeave && (!_isHideJySq))
                {
                    this.Close();
                    return;
                }

                this.txtDiag.Text = patientBar1.lblDiag.Text.Trim();

                //Modify By Tany 2011-04-26
                //增加对EMR信息的调用
                try
                {
                    string jybs = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select top 1 symptom from zy_jc_record where inpatient_id='" + BinID + "' order by id desc"), "");
                    if (jybs == "" || this.txtDiag.Text.Trim() == "" || this.txtDiag.Text.Trim() == "未知诊断")
                    {
                        //EmrVSHISInterface.HisInterface emr = new EmrVSHISInterface.HisInterface();
                        //object[] objs = emr.GetMrDiagnoseOrContent(BinID.ToString());
                        //if (this.txtDiag.Text.Trim() == "" || this.txtDiag.Text.Trim()=="未知诊断")
                        //{
                        //    this.txtDiag.Text = Convertor.IsNull(objs[0], "");
                        //}
                        //jybs = Convertor.IsNull(objs[1], "");
                        string sSql = "select * from VI_ZY_VINPATIENT_ALL where inpatient_id='" + this.BinID + "' and baby_id=" + this.BabyID;
                        DataTable myTb = FrmMdiMain.Database.GetDataTable(sSql);
                        if (myTb.Rows.Count == 0) return;
                        string[] rtn = TrasenHIS.BLL.HisFunctions.GetEmrDiagnosois_jc(myTb.Rows[0]["inpatient_no"].ToString(), myTb.Rows[0]["inpatient_bano"].ToString());
                        if (this.txtDiag.Text.Trim() == "" || this.txtDiag.Text.Trim() == "未知诊断")
                        {
                            string zd="";
                            string[] zd_arr = rtn[1].ToString().Split(',');
                            for (int i = 0; i < 4 && i < zd_arr.Length; i++)
                            {
                                zd += zd_arr[i].ToString().Trim() + ",";
                            }
                            this.txtDiag.Text = zd.TrimEnd(',');
                        }
                    }
                    if (jybs == "")
                    {
                        try
                        {
                            DataTable tb = TrasenHIS.BLL.HisFunctions.GetEmrInpatientSummary(patientBar1.lblInpatientNo.Text, "");
                            if (tb != null && tb.Rows.Count > 0)
                            {
                                jybs = tb.Rows[0]["content"].ToString().Trim();
                                if (jybs != "")
                                {
                                    richRecord.Text = jybs;
                                }
                                else
                                {
                                    throw new Exception("获取EMR的简要病史为空！");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    {
                        richRecord.Text = jybs;
                    }
                }
                catch
                {
                    //MessageBox.Show(ex.Message);
                }
                this.tabControl2.TabPages.Remove(this.tabPage3);
            }
            else
            {

                this.tabControl2.TabPages.Remove(this.tabPage4);
                //门诊信息
                lblxm.Text = Dqcf.brxm;
                lblxb.Text = Dqcf.xb;
                lblnl.Text = Dqcf.nl;
                lblgzdw.Text = Dqcf.tz;
                lbllxdh.Text = Dqcf.gzdw;
                lbltz.Text = Dqcf.lxfs;
                lblmzh.Text = Dqcf.mzh;
                if (Xg)
                {
                    this.dataGridviewEx1.ReadOnly = true;
                    toolStripButton1.Visible = false;
                    this.cmbTc.Visible = false;
                }
                for (int i = 0; i < tbxg.Rows.Count; i++)
                {
                    DataRow r = tbxg.Rows[i];


                    //Modify by jchl
                    decimal sprc = GetorderPrice(long.Parse(r["医嘱项目id"].ToString())); ;//单价
                    decimal aprc = GetorderPrice(long.Parse(r["医嘱项目id"].ToString())) * long.Parse("1"); //金额
                    //ListViewItem li = new ListViewItem(new string[] { r["数量"].ToString(),r["名称"].ToString(), r["单位"].ToString(),r["标本"].ToString(),
                    //"","","",  r["医嘱项目id"].ToString(),r["JcxmId"].ToString(),r["execDept"].ToString(),
                    //r["套餐id"].ToString()});
                    ListViewItem li = new ListViewItem(new string[] {  
                        r["名称"].ToString(),
                        r["标本"].ToString(),
                        r["数量"].ToString(),
                        r["单位"].ToString(),
                        sprc.ToString(),
                        aprc.ToString(),
                        r["执行科室"].ToString(),
                        "",
                        r["项目分类"].ToString(),
                        r["医嘱项目id"].ToString(),
                        r["JcxmId"].ToString(),
                        r["execDept"].ToString(),
                        r["套餐id"].ToString()
                    });

                    li.Tag = tbxg.Rows[i]["医嘱项目id"].ToString();
                    listView1.Items.AddRange(new ListViewItem[] { li });

                }
                #region
                ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
                this.listView1.ListViewItemSorter = lvwColumnSorter;
                // 检查点击的列是不是现在的排序列.
                if (5 == lvwColumnSorter.SortColumn)
                {
                    // 重新设置此列的排序方法.
                    if (lvwColumnSorter.Order == SortOrder.Ascending)
                    {
                        lvwColumnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        lvwColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // 设置排序列，默认为正向排序
                    lvwColumnSorter.SortColumn = 5;
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
                // 用新的排序方法对ListView排序
                this.listView1.Sort();
                #endregion
                this.lbPrice.Text = Getprice() + " 元";
                ChangeAltercolr();

                if (issfy)
                {
                    this.dataGridviewEx1.ReadOnly = false;
                    toolStripButton1.Visible = true;
                }
            }
            this.lbDateTime.Text = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString();

            jcTypeTb = GetJCtype();
            getDept();



            this.btPrint.Visible = true;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            cmbClass.SelectedIndexChanged += new EventHandler(cmbClass_SelectedIndexChanged);
            cmbDept_SelectedIndexChanged(null, null);
            //cmbClass_SelectedIndexChanged(null, null);

            //获得院区
            this.cmbYQ.ValueMember = "jgbm";
            this.cmbYQ.DisplayMember = "jgmc";
            DataTable tbyqjg = FrmMdiMain.Database.GetDataTable("select  JGMC,JGBM  from  JC_JGBM");
            this.cmbYQ.DataSource = tbyqjg;
            this.cmbYQ.SelectedIndexChanged += new EventHandler(cmbYQ_SelectedIndexChanged);
            this.cmbYQ_SelectedIndexChanged(null, null);
            //

            this.cmbTc.SelectedIndexChanged += new System.EventHandler(this.cmbTc_SelectedIndexChanged);
            this.lbPrice.Text = Getprice() + " 元";
            this.txtDM.Focus();

            _Zyid = patientBar1.lblInpatientNo.Text;
            this.fylb = myQuery.GetTsxx(_Zyid);//武汉中心医院(Modify by jchl)

            if (_isHideJySq)
            {
                tabControl1_SelectedIndexChanged(null, null);
            }
        }

        void cmbYQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDept();
            //cmbDept_SelectedIndexChanged(null, null);
        }

        //void FrmJCSQ_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    this.listView1.Focus();
        //    if (this.listView1.Controls.Count > 0)
        //    {
        //        e.Cancel = true;
        //    }
        //}
        #endregion

        #region 申请页

        #region 获取检查类型
        private DataTable GetJCtype()
        {
            string sSql = "select distinct a.id typeid,a.name,a.comment,a.printtype,b.reportfile,a.multselect " +
                        "from jc_jcclassdiction a left join " +
                        "     JC_YJ_PRINTTYPE b on a.printtype=b.code " +
                        "where a.class_type=0 ";
            return FrmMdiMain.Database.GetDataTable(sSql);
        }
        #endregion

        #region 获取检查科室
        private void getDept()
        {

            try
            {
                if (this.cmbYQ.SelectedValue == null)
                {
                    this.cmbYQ.SelectedIndex = -1;//这里要改
                    this.cmbDept.Items.Clear();

                    //this.cmbTc.Items.Clear();
                    ///cmbClass_SelectedIndexChanged(null, null);
                    return;
                }
            }
            catch { return; }

            int jgbm = int.Parse(this.cmbYQ.SelectedValue.ToString());
            DataTable tb = myQuery.GetDept(1, jgbm);

            //NULL 直接返回
            if (tb == null) return;
            if (tb.Rows.Count == 0)
            {
                this.cmbDept.Items.Clear();
                this.dataGridviewEx1.DataSource = null;
                this.cmbTc.DataSource = null;
                this.cmbTc.Items.Clear();
                MessageBox.Show("错误，未能取得检查科室信息！");
                return;
            }

            //添加一项全部 caicheng  
            cmbDept.Items.Clear();
            cmbDept.Items.Add(new ListItem("-1", "全部"));

            foreach (DataRow row in tb.Rows)
            {
                cmbDept.Items.Add(new ListItem(row["ID"].ToString(), row["NAME"].ToString()));
            }
            cmbDept.Text = "全部";
        }
        #endregion

        #region 检查项目动态绑定
        private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            cmbDept.Text = cmbDept.Text.Trim();
            if (cmbDept.SelectedIndex >= 0)
            {
                if (((ListItem)cmbDept.SelectedItem).ID.ToString() == "-1")
                {
                    cmbClass.Items.Clear();
                    ListItem item = new ListItem("-1", "全部");
                    cmbClass.Items.Add(item);
                    cmbClass.Text = "全部";
                }
                else
                {
                    string sSql = string.Format(@"   select	distinct A.jclxid ID,
                                                B.name NAME,
                                                A.jclxid TYPE   
                                           from jc_jc_item A  left outer join      
                                                jc_jcclassdiction B 
                                                on A.jclxid=B.ID and B.class_type=0  
                                          where yzid in (select order_id from jc_hoi_dept where exec_dept = {0})  
				                                order by ID", ((ListItem)cmbDept.SelectedItem).ID.ToString());
                    DataTable tb = FrmMdiMain.Database.GetDataTable(sSql);
                    if (tb == null) return;
                    if (tb.Rows.Count == 0) return;
                    ////添加全部 caicheng  
                    cmbClass.Items.Clear();
                    ListItem item = null;
                    foreach (DataRow row in tb.Rows)
                    {
                        item = new ListItem(row["ID"].ToString(), row["NAME"].ToString());
                        cmbClass.Items.Add(item);
                    }
                    cmbClass.SelectedIndex = 0;
                }
                this.txtADept.Text = cmbDept.Text;
                IDeptID = Convert.ToInt32(((ListItem)cmbDept.SelectedItem).ID);
            }
        }
        #endregion
        Thread thr;
        public delegate void del(object ob);
        #region 根据项目类别的不同显示检查项目
        private void cmbClass_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            string selClass = cmbClass.Text.Trim();//类型名
            string itemid = ((ListItem)cmbClass.SelectedItem).ID.ToString();//类型ID
            string placeStr = "";//体位

            txtAClass.Text = selClass;
            IClassID = Convert.ToInt32(((ListItem)cmbClass.SelectedItem).ID);
            //标题控制
            lbCaption.Text = selClass + "检查申请单";
            int x = Convert.ToInt16((this.panel3.Width - lbCaption.Width) / 2);
            int y = lbCaption.Top;
            // lbCaption.Location = new Point(x, y);


            this.chkMore.Enabled = false;
            this.printType = "";
            this.printFile = "";
            for (int i = 0; i < jcTypeTb.Rows.Count; i++)
            {
                if (jcTypeTb.Rows[i]["typeid"].ToString() == itemid)
                {
                    if (jcTypeTb.Rows[i]["multselect"].ToString() != "0")
                    {
                        //可多选
                        this.chkMore.Enabled = true;
                    }
                    placeStr = jcTypeTb.Rows[i]["comment"].ToString().Trim();
                    printType = Convertor.IsNull(jcTypeTb.Rows[i]["printtype"], "");
                    printFile = Convertor.IsNull(jcTypeTb.Rows[i]["reportfile"], "");
                    break;
                }
            }

            //是否显示打印按钮（打印类型不为空则显示） 把这个屏蔽掉 2013-5-7 Modify by zouchihua 
            //if (printType != "") this.btPrint.Visible = true;
            //else this.btPrint.Visible = false;

            //设置体位
            string[] place;
            place = placeStr.Split('/');
            try
            {
                cmbPlace.Items.Clear();
                cmbPlace.Text = "";
                cmbPlace.Items.AddRange(place);
            }
            catch { }

            //CT分类显示控制
            if (selClass == (new SystemCfg(6006)).Config)
            {
                chkBox1.Visible = true; chkBox2.Visible = true; chkBox3.Visible = true;
            }
            else
            {
                chkBox1.Visible = false; chkBox2.Visible = false; chkBox3.Visible = false;
                chkBox1.Checked = false; chkBox2.Checked = false; chkBox3.Checked = false;
            }
            //查询所有的检查项目  modify by caicheng 2013-05-21
            if (selClass == "全部")
            {
                itemTb = myQuery.GetItem(Convert.ToInt64(Convertor.IsNull(((ListItem)cmbDept.SelectedItem).ID, "0")), Convert.ToInt16(itemid), 7, FrmMdiMain.CurrentDept.DeptId);//2 改为6 Modify by zouchihua  2012-3-1
            }
            else
            {
                //根据检查科室提取检验项目	
                itemTb = myQuery.GetItem(Convert.ToInt64(Convertor.IsNull(((ListItem)cmbDept.SelectedItem).ID, "0")), Convert.ToInt16(itemid), 6, FrmMdiMain.CurrentDept.DeptId);//2 改为6 Modify by zouchihua  2012-3-1
            }
            DataTable temp = itemTb.Copy();
            try
            {
                if (thr != null)
                {
                    thr.Abort();
                    thr = null;
                    GC.Collect();
                }
                //this.listView1.Items.Clear();
                this.dataGridviewEx1.AutoGenerateColumns = false;

                // this.dataGridviewEx1.DataSource = temp;
                this.dataGridviewEx1.EnableHeadersVisualStyles = false;
                //del d = new del(tt);
                //AsyncCallback d1 = new AsyncCallback(ht);
                //IAsyncResult hh = d.BeginInvoke(temp, d1, null);

                thr = new Thread(new ParameterizedThreadStart(tt));
                thr.Start(temp);
                //Ts_Clinicalpathway_Factory.PublicFunction.GruopShow(temp, "fid=0", "order_id", this.dataGridviewEx1, "fid", this.dataGridviewEx1.groupColumIndex,1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //添加检验项目
            chkListBox.Items.Clear();
            // Item jcItem = null;
            //for (int i = 0; i <= itemTb.Rows.Count - 1; i++)
            //{
            //    //jcItem = new Item();
            //    //jcItem.orderID = Convert.ToInt32(itemTb.Rows[i]["order_id"]);
            //    //jcItem.orderName = itemTb.Rows[i]["order_name"].ToString().Trim();
            //    //jcItem.orderUnit = itemTb.Rows[i]["order_unit"].ToString().Trim();
            //    //jcItem.execDept = Convert.ToInt64(Convertor.IsNull(itemTb.Rows[i]["default_dept"], "0"));
            //    //jcItem.defaultUsage = itemTb.Rows[i]["default_usage"].ToString().Trim();
            //    //jcItem.pym = itemTb.Rows[i]["py_code"].ToString();
            //    //jcItem.booking = Convert.ToInt16(itemTb.Rows[i]["booking_bit"]); 
            //    //chkListBox.Items.Add(jcItem);
            //}

            chkListBox.BorderStyle = BorderStyle.None;
            // lbPrice.Text = "0.00 元";
            int jgbm = int.Parse(this.cmbYQ.SelectedValue.ToString());
            //添加套餐项目
            string sSql = "select -1 as id,'' as name union all select id,name from JC_JCHYTC_T where jgbm=" + jgbm + " and class_id=" + Convert.ToInt32(((ListItem)cmbClass.SelectedItem).ID.ToString()) + " and (tclx=0 or (tclx=1 and syid=" + FrmMdiMain.CurrentDept.DeptId + ") or (tclx=2 and syid=" + FrmMdiMain.CurrentUser.EmployeeId + "))";

            DataTable tb = FrmMdiMain.Database.GetDataTable(sSql);

            cmbTc.DisplayMember = "NAME";
            cmbTc.ValueMember = "ID";
            cmbTc.DataSource = tb;
            //txtDM.Text = "";
            //this.ActiveControl = txtDM;
            //txtDM.Focus();
            //添加检查部位选择  add  by   chenl    2017-05-12
            //string sSqlbw = "select -1 as id,'' as name union all select id,name from JC_JCHYTC_T where jgbm=" + jgbm + " and class_id=" + Convert.ToInt32(((ListItem)cmbClass.SelectedItem).ID.ToString()) + " and (tclx=0 or (tclx=1 and syid=" + FrmMdiMain.CurrentDept.DeptId + ") or (tclx=2 and syid=" + FrmMdiMain.CurrentUser.EmployeeId + "))";
            //string str = ((ListItem)cmbClass.SelectedItem).Name.ToString();
            //string sSqlbw = " select distinct TC_NAME,TC_CODE FROM  JCBW  WHERE XM_NAME='"+str+"'";

            //DataTable tbbw = FrmMdiMain.Database.GetDataTable(sSqlbw);

            //cmbbw.DisplayMember = "TC_NAME";
            //cmbbw.ValueMember = "TC_CODE";
            //cmbbw.DataSource = tbbw;
            txtDM.Text = "";
            this.ActiveControl = txtDM;
            txtDM.Focus();
            this.dt_item = itemTb.Copy();
            
        }
        #endregion

        #region CT选择
        private void chkBox_CheckedChanged(object sender, System.EventArgs e)
        {
            DataTable tempTb = itemTb.Copy();
            string str = "", str1 = "", str2 = "", str3 = "";
            //			if(chkBox1.Checked==true)str1="order_name like '%【平扫】%' ";
            //			if(chkBox2.Checked==true)str2="order_name like '%【直接增强】%' ";
            //			if(chkBox3.Checked==true)str3="order_name like '%【平扫＋增强】%'";
            if (chkBox1.Checked == true) str1 = "order_name like '%平扫%' ";
            if (chkBox2.Checked == true) str2 = "order_name like '%增强%' ";
            if (chkBox3.Checked == true) str3 = "order_name like '%平扫%' and order_name like '%增强%'";
            str = str1;
            if (str == "") str = str2;
            else if (str2 != "") str += "or " + str2;
            if (str == "") str = str3;
            else if (str3 != "") str += "or " + str3;
            dr = tempTb.Select(str, "py_code");
            chkListBox.Items.Clear();
            Item jcItem = null;
            for (int i = 0; i < dr.GetLength(0); i++)
            {
                jcItem = new Item();
                jcItem.orderID = Convert.ToInt32(dr[i]["order_id"]);
                jcItem.orderName = dr[i]["order_name"].ToString().Trim();
                jcItem.orderUnit = dr[i]["order_unit"].ToString().Trim();
                jcItem.execDept = Convert.ToInt64(Convertor.IsNull(dr[i]["default_dept"], "0"));
                jcItem.defaultUsage = dr[i]["default_usage"].ToString().Trim();
                jcItem.pym = dr[i]["py_code"].ToString();
                jcItem.booking = Convert.ToInt16(dr[i]["booking_bit"]);
                chkListBox.Items.Add(jcItem);
            }
        }
        #endregion
        private void tt(object ob)
        {
            dlfun(ob);
            try
            {
                //if (thr != null)
                //    thr.Abort();

            }
            catch { }
            // /  this.ActiveControl = txtDM;
            //txtDM.Focus();
            //Ts_Clinicalpathway_Factory.PublicFunction.GruopShow((DataTable)ob, "fid=0", "order_id", this.dataGridviewEx1, "fid", this.dataGridviewEx1.groupColumIndex, 1);
        }
        private void dlfun(object ob)
        {
            if (this.dataGridviewEx1.InvokeRequired)
            {
                del d = new del(dlfun);
                this.Invoke(d, ob);
            }
            else
            {
                Ts_Clinicalpathway_Factory.PublicFunction.GruopShow((DataTable)ob, "fid=0", "order_id", this.dataGridviewEx1, "fid", this.dataGridviewEx1.groupColumIndex, 1);
                Collapse(true);

            }
        }
        private void Collapse(bool _bool)
        {
            for (int i = 0; i < this.dataGridviewEx1.Rows.Count; i++)
            {
                Ts_Clinicalpathway_Factory.DataGridViewGroupCell cel = (this.dataGridviewEx1.Rows[i].Cells[this.dataGridviewEx1.groupColumIndex] as Ts_Clinicalpathway_Factory.DataGridViewGroupCell);
                if (_bool)
                    cel.Collapse();
                else
                    cel.Expand();
            }
        }
        private void ht(IAsyncResult result)
        {
            // MessageBox.Show(result.IsCompleted.ToString());
            //if (result.IsCompleted)
            //{

            MessageBox.Show("完成");
            //}

        }
        #region 检查费动态统计(录入页)
        private void chkListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            decimal p = 0;
            if (chkListBox.CheckedItems.Count == 1)
            {
                cmbPlace.Enabled = true;
                this.btPrint.Visible = true;
            }
            else
            {
                cmbPlace.Enabled = false;
                cmbPlace.Text = "";
                this.numUpDown.Value = 1;
                this.numUpDown.Enabled = false;
                //this.btPrint.Visible = false;
            }

            if (this.printType != "" && chkListBox.CheckedItems.Count < 2) this.btPrint.Visible = true;
            else this.btPrint.Visible = true;

            pr = 0;
            for (int i = 0; i <= chkListBox.CheckedItems.Count - 1; i++)
            {
                p = myQuery.GetPrice(((Item)chkListBox.CheckedItems[i]).orderID, FrmMdiMain.Jgbm);
                if (((Item)chkListBox.CheckedItems[i]).booking == 1) this.btPrint.Visible = true;
                if (p.ToString() == "") continue;
                pr += p;
            }
            if (chkListBox.CheckedItems.Count > 1) lbPrice.Text = "合计 " + pr.ToString() + " 元";
            else lbPrice.Text = pr.ToString() + " 元";

        }
        #endregion
        ArrayList arr = new ArrayList();
        /// <summary>
        /// 检查是否需要录入部位
        /// </summary>
        /// <returns></returns>
        private bool CheckBw()
        {
            arr.Clear();
            int i = 0;
            string text = "以下检查申请没有检查部位：\r\n";
            for (i = 0; i < this.listView1.Items.Count; i++)
            {
                if (this.listView1.Items[i].SubItems[1].Text.Trim() == "")
                {
                    text += "  【" + this.listView1.Items[i].SubItems[0].Text.Trim() + "】\r\n";
                    this.listView1.Items[i].Selected = true;
                    arr.Add(i);
                    // this.listView1.Items[i].Focused = true;
                    //this.listView1.Items[i].BackColor=Color.Blue;
                    // this.listView1.FocusedItem.Selected = true;
                }
            }
            if (text != "以下检查申请没有检查部位：\r\n")
            {
                if (cfg6080.Config.Trim() == "1")
                {
                    if (MessageBox.Show(text + "\r\n你确定要继续吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        Listselect();
                        return false;
                    }
                }
                if (cfg6080.Config.Trim() == "2")
                {

                    MessageBox.Show(text + "\r\n请先填写检查部位！！");
                    Listselect();
                    return false;
                }
                //cfg6080

            }

            return true;
        }

        private void Listselect()
        {
            this.listView1.Focus();
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                if (arr.IndexOf(i) >= 0)
                {
                    this.listView1.Items[i].Selected = true;
                    this.listView1.Items[i].Focused = true;
                }
                else
                    this.listView1.Items[i].Selected = false;
            }
        }
        #region 生成医嘱
        private void button1_Click(object sender, System.EventArgs e)
        {
            

            if (this.lg == 0 || this.lg >= 4) return;
            if (this.listView1.Items.Count == 0)
            {
                MessageBox.Show("没有选择检查项目！不能申请！", "提示");
                return;
            }
            if (!CheckBw())
                return;

            //Add By Tany 2015-07-06 保存的时候验证一下病人的费别是否发生了变化，如果变化则刷新掉没保存的
            #region 验证费别变化情况
            //Modify By Tany 2015-03-18 这里加上try catch，出错的话返回
            try
            {
                TrasenHIS.BLL.Judgeorder jo = new TrasenHIS.BLL.Judgeorder(FrmMdiMain.Database);
                string strFb = jo.GetLb(patientBar1.lblInpatientNo.Text);
                string oldFb = "";
                bool isChangeFb = false;
                if (strFb == "自费")
                {
                    if (strFb != fylb)
                    {
                        isChangeFb = true;
                        oldFb = fylb;
                    }
                }
                else if (strFb == "公费")
                {
                    if (strFb != fylb)
                    {
                        isChangeFb = true;
                        oldFb = fylb;
                    }
                }
                else
                {
                    if (strFb != fylb)
                    {
                        isChangeFb = true;
                        oldFb = fylb;
                    }
                }

                //Modify by jchl (毛毛按自费)
                //if (isChangeFb )
                if (isChangeFb && BabyID == 0)
                {
                    string ts = "该病人的费别发生变化！！！\r\n\r\n";
                    ts += "原费别：" + oldFb + "\r\n";
                    ts += "现费别：" + strFb + "\r\n\r\n";
                    ts += "出于数据准确性考虑，在点击确定后，系统将退出界面并不保存您选中的医嘱！";
                    MessageBox.Show(ts, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            #endregion
            //Modify By chenli 2017-10-30 强制不许保存
            bool is_unknown = txtDiag.Text.Trim() == "未知诊断" || IsNumber(txtDiag.Text.Trim());
            if (is_unknown)
            {
                MessageBox.Show("请先在申请页面左上方“临床诊断”处填写诊断");
                txtDiag.Text = "";
                txtDiag.Focus();
                return;
            }

            //Modify By Tany 2015-06-03 强制不许保存
            if (this.btPrint.Visible == true
                && (
                        richRecord.Text.ToString().Trim() == "" || string.IsNullOrEmpty(richRecord.Text.TrimStart().TrimEnd().Trim())
                        || cmbDept.SelectedIndex < 0
                        || txtDiag.Text.Trim() == ""
                        || richTextBox1.Text.Trim() == ""
                       )
                )
            {
                //if (MessageBox.Show("申请单没有填写完整！可以在打印后手工填写。\n你确定要生成医嘱吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                MessageBox.Show("申请单没有填写完整，不允许保存，请将页面全部内容填写完整后再重新提交！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                if (richTextBox1.Text.Trim() == "")
                {
                    richTextBox1.Focus();
                }
                if (string.IsNullOrEmpty(richRecord.Text.TrimStart().TrimEnd().Trim()))
                {
                    richRecord.Focus();
                }
                if (cmbDept.SelectedIndex < 0)
                {
                    cmbDept.Focus();
                }
                if (txtDiag.Text.Trim() == "")
                {
                    txtDiag.Focus();
                }
                return;
            }
            else
            {
                if (MessageBox.Show("你确定要生成医嘱吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            }

            if (BrLy == Typely.住院)
            {
                string config = new SystemCfg(6029).Config.ToString();
                if (config == "1")
                {
                    #region //弹出分类的窗口
                    //if (chkListBox.CheckedItems.Count >= 2)
                    //{
                    //    Item[] itemgruop = new Item[chkListBox.CheckedItems.Count];
                    //    for (int x = 0; x < chkListBox.CheckedItems.Count; x++)
                    //    {
                    //        itemgruop[x] = (Item)chkListBox.CheckedItems[x];
                    //    }
                    //    FrmGroup fg = new FrmGroup(itemgruop);
                    //    fg.ShowDialog();
                    //    if (fg.DialogResult == DialogResult.OK)
                    //    {
                    //        for (int x = 0; x < chkListBox.CheckedItems.Count; x++)
                    //        {
                    //            ((Item)chkListBox.CheckedItems[x]).groupid = fg._item[x].groupid;
                    //            ((Item)chkListBox.CheckedItems[x]).jc_no = fg._item[x].jc_no;
                    //        }
                    //    }
                    //    else//不分成一组
                    //    {
                    //        for (int x = 0; x < chkListBox.CheckedItems.Count; x++)
                    //        {
                    //            ((Item)chkListBox.CheckedItems[x]).groupid = -1;
                    //            ((Item)chkListBox.CheckedItems[x]).jc_no = Guid.NewGuid();
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    ((Item)chkListBox.CheckedItems[0]).jc_no = Guid.NewGuid();
                    //}
                    #endregion
                }
                Item[] itemgruop = new Item[this.listView1.Items.Count];
                try
                {
                    try
                    {
                        for (int x = 0; x < this.listView1.Items.Count; x++)
                        {
                            //itemgruop[x] = new Item();
                            //itemgruop[x].orderID = long.Parse(this.listView1.Items[x].SubItems[5].Text);
                            //itemgruop[x].orderName = this.listView1.Items[x].SubItems[0].Text;
                            //itemgruop[x].defaultUsage = this.listView1.Items[x].SubItems[3].Text;
                            //itemgruop[x].execDept = long.Parse(this.listView1.Items[x].SubItems[6].Text);//执行科室id
                            //itemgruop[x].orderUnit = this.listView1.Items[x].SubItems[1].Text;
                            itemgruop[x] = new Item();
                            itemgruop[x].orderID = long.Parse(this.listView1.Items[x].SubItems[9].Text);
                            itemgruop[x].orderName = this.listView1.Items[x].SubItems[0].Text;
                            itemgruop[x].defaultUsage = this.listView1.Items[x].SubItems[7].Text;
                            itemgruop[x].execDept = long.Parse(this.listView1.Items[x].SubItems[11].Text);//执行科室id
                            itemgruop[x].orderUnit = this.listView1.Items[x].SubItems[3].Text;
                            itemgruop[x].JcxmId = Convert.ToInt32(this.listView1.Items[x].SubItems[10].Text); //项目类型 
                            itemgruop[x].Lczd = this.listView1.Items[x].SubItems[13].Text;
                            itemgruop[x].Zysx = this.listView1.Items[x].SubItems[14].Text;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "dddd");
                    }
                    if (config == "1")
                    {

                        if (this.listView1.Items.Count >= 2)
                        {

                            FrmGroup fg = new FrmGroup(itemgruop);
                            fg.ShowDialog();
                            if (fg.DialogResult != DialogResult.OK)
                            {
                                //不分成一组

                                for (int x = 0; x < itemgruop.Length; x++)
                                {
                                    (itemgruop[x]).groupid = -1;
                                    (itemgruop[x]).jc_no = DbQuery.UpdateNowNoAndGetNewNo(13, InstanceForm._database);
                                }

                            }
                            else
                                for (int x = 0; x < itemgruop.Length; x++)
                                {
                                    (itemgruop[x]).groupid = fg._item[x].groupid;
                                    (itemgruop[x]).jc_no = fg._item[x].jc_no;
                                }
                        }
                        else
                        {
                            (itemgruop[0]).jc_no = DbQuery.UpdateNowNoAndGetNewNo(13, InstanceForm._database);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //根据岳阳的需求暂时屏蔽掉身份确认
                //			string dlgvalue=DlgPW.Show();
                //			string pwStr=YS.Password;
                //			if(dlgvalue=="" || dlgvalue!=pwStr) 
                //			{
                //				FrmMessageBox.Show("你没有通过权限确认，不能生成医嘱！",new Font("宋体",12f),Color.Red,"信息",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //				return;
                //			}

                #region 按选择项目生成医嘱
                button1.Enabled = false;

                long Order_Num = 0;
                string selitem = "";
                string selitemH = "";
                string strPlace = cmbPlace.Text.Trim();
                Order_Num = myQuery.GetYzNum(this.BinID, this.DeptID);//获取该病人最大医嘱组号
                //add by zouchihua 2011-11-16获得病人所在科室机构编码
                string[] BrInfo = Ts_zyys_public.DbQuery.GetBrzt(this.BinID);
                int BrJgm = Convert.ToInt32(BrInfo[1]);
                bool tj = true;

                Item item = null;
                for (int i = 0; i <= this.listView1.Items.Count - 1; i++)
                {
                    //for (int m = 0; m < itemgruop.Length; m++)
                    //{
                    //    if (itemgruop[m].orderID.ToString().Trim().Equals(listView1.Items[i].SubItems[6 + 1].Text.Trim()))
                    //    {
                    //        item = itemgruop[m];
                    //    }
                    //}
                    item = itemgruop[i];

                    if (config == "0")
                        item.jc_no = DbQuery.UpdateNowNoAndGetNewNo(13, InstanceForm._database);

                    #region//武汉中心医院(Modify by jchl)
                    decimal zfbl = 1;
                    if (this.fylb != "" && this.fylb != "自费")
                    {
                        int type = 0;
                        if (this.fylb.Contains("公费"))
                            type = 1;
                        else
                            type = 2;

                        try
                        {
                            if (!myQuery.GetGfxx(type, _Zyid, item.orderID.ToString(), "2", item.orderName, this.fylb, ref zfbl))
                            {
                                itemgruop[i].Zfbl = 1;
                                listView1.Items.Remove(listView1.Items[i]);
                                continue;
                            }
                            else
                            {
                                itemgruop[i].Zfbl = zfbl;
                            }
                        }
                        catch (Exception ex)//Modify By Tany 2015-03-18 加上捕获错误并返回，不继续操作
                        {
                            MessageBox.Show(ex.Message);
                            itemgruop[i].Zfbl = 1;
                            listView1.Items.Remove(listView1.Items[i]);
                            continue;
                        }
                    }
                    #endregion
                }

                FrmMdiMain.Database.BeginTransaction();
                try
                {
                    DataTable tbPat = FrmMdiMain.Database.GetDataTable("select * from vi_zy_vinpatient_all where baby_id=0 and inpatient_id='" + this.BinID + "'");
                    int ybjklx = Convert.ToInt32(Convertor.IsNull(tbPat.Rows[0]["ybjklx"], "0"));
                    int yblx = Convert.ToInt32(Convertor.IsNull(tbPat.Rows[0]["yblx"], "0"));
                    Guid guidjc_no = Guid.Empty;
                    if (config == "0")
                        guidjc_no = Guid.NewGuid();
                    item = new Item();
                    string jc_no = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString("yyyyMMddHHmmssfff");
                    for (int i = 0; i <= this.listView1.Items.Count - 1; i++)
                    {
                        for (int m = 0; m < itemgruop.Length; m++)
                        {
                            if (this.listView1.Items[i].SubItems[9].Text.Equals(itemgruop[m].orderID.ToString().Trim()))
                            {
                                item = itemgruop[m];
                            }
                        }

                        //Modify By Tany 2015-05-05 这里屏蔽，不需要再次获取jcno，而且在事务中获取，jc_identity表不会提交，造成重号的可能
                        //if (config == "0")
                        //    item.jc_no = DbQuery.UpdateNowNoAndGetNewNo(13, InstanceForm._database);

                        //#region//武汉中心医院(Modify by jchl)
                        //decimal zfbl = 1;
                        //if (this.fylb != "" && this.fylb != "自费")
                        //{
                        //    int type = 0;
                        //    if (this.fylb.Contains("公费"))
                        //        type = 1;
                        //    else
                        //        type = 2;

                        //    if (!myQuery.GetGfxx(type, _Zyid, item.orderID.ToString(),"2", selitem, this.fylb, ref zfbl))
                        //    {
                        //        FrmMdiMain.Database.RollbackTransaction();
                        //        return;
                        //    }
                        //}
                        //#endregion

                        //验证医保匹配关系
                        string xmid = "";//Modify By Tany 2010-08-10 增加返回值
                        if ((new SystemCfg(6021)).Config == "1" && ybjklx > 0 && !myQuery.isPP(item.orderID, yblx, ref xmid))
                        {
                            MessageBox.Show(item.orderName + "[" + xmid + "]没有进行医保匹配，不允许申请，将不会保存！");
                            continue;
                        }

                        selitem = item.orderName;

                        //int YY = selitem.IndexOf("【", 0);
                        //if (YY > 0) selitem = selitem.Substring(0, YY);
                        Order_Num++;
                        //if (strPlace != "") selitem = strPlace + selitem.Trim();
                        //Modify by zouchihua 2011-09-17  医嘱中增加检查部位
                        //for (int j = 0; j < bwitem.Count; j++)
                        //{
                        //    //Modify by zouchihua 2011-09-17 判断医嘱长度
                        //    if(System.Text.Encoding.Default.GetByteCount(selitem+bwitem[j].positionName)<100)
                        //      selitem += "(" + bwitem[j].positionName + ")";
                        //    else
                        //    {
                        //        selitem+="等";
                        //        break;
                        //    }
                        //}
                        //if (this.listView1.Items[i].SubItems[1].Text.ToString().Trim() != "")
                        //selitem += "【" + this.listView1.Items[i].SubItems[1].Text.ToString() + "】";
                        string sSql = "INSERT INTO ZY_ORDERRECORD(" +
                            "order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,nType,Order_Doc," +
                            "HOItem_ID,xmly,Order_context,Num,Dosage,Unit,book_date," +
                            "Order_bDate,First_times,Order_Usage,frequency," +
                            "Operator,Delete_Bit,status_flag,baby_id,dept_br,exec_dept,jgbm,zsl,zfbl)" +
                            " VALUES('" + PubStaticFun.NewGuid() + "'," + Order_Num.ToString() + ",'" + this.BinID.ToString() + "'," + this.DeptID.ToString() + ",'" + this.WardID + "'," + "1" + ",5," + this.YS_ID.ToString() + "," +
                            "" + item.orderID + ",2,'" + selitem + "'," + this.listView1.Items[i].SubItems[2].Text.ToString() + ",1,'" + item.orderUnit + "',GetDate()," +
                             (this.chcekbl.Checked ? ("'" + DtpbeginDate.Value.ToString() + "'") : "GetDate()") + "," + "0" + ",'" + "" + "','" + "" + "'," +
                            "" + this.YS_ID.ToString() + ",0," + (this.chcekbl.Checked ? 9 : 0) + "," + this.BabyID.ToString() + "," + this.DeptID.ToString() + "," + item.execDept + "," + BrJgm + "," + this.listView1.Items[i].SubItems[2].Text.ToString() + "," + item.Zfbl + ")";

                        FrmMdiMain.Database.DoCommand(sSql);

                        //sSql = "insert into zy_jc_record (" +
                        //    "id,group_id,inpatient_id,hoitem_id,place,place_num,SYMPTOM ,IN_DIAGNOSIS,jc_no,lczd,zysx,jcresult,jgbm) " +
                        //    "values('" + PubStaticFun.NewGuid() + "'," + Order_Num.ToString() + ",'" + this.BinID.ToString() + "'," + item.orderID + ",'"
                        //    + this.listView1.Items[i].SubItems[1].Text.ToString()//cmbPlace.Text.Trim() 
                        //    + "'," +
                        //    "" + this.listView1.Items[i].SubItems[2].Text.ToString() + ",'" + richRecord.Text.Trim() + "','" + txtDiag.Text.Trim() + "','" + item.jc_no.ToString() + "','" + item.Lczd.ToString() + "','" + item.Zysx.ToString() + "','" + this.listView1.Items[i].SubItems[15].Text.ToString() + "'," + BrJgm + ")";//dbo.FUN_ZY_SEEKJCNO('" + this.BinID + "','" + printType + "')
                        //add  by    chenl   2017-05-12
                        sSql = "insert into zy_jc_record (" +
                                 "id,group_id,inpatient_id,hoitem_id,place,place_num,SYMPTOM ,IN_DIAGNOSIS,jc_no,lczd,zysx,jcresult,jgbm,TCMX_CODE) " +
                                 "values('" + PubStaticFun.NewGuid() + "'," + Order_Num.ToString() + ",'" + this.BinID.ToString() + "'," + item.orderID + ",'"
                                 + this.listView1.Items[i].SubItems[1].Text.ToString()//cmbPlace.Text.Trim() 
                                 + "'," +
                                 "" + this.listView1.Items[i].SubItems[2].Text.ToString() + ",'" + richRecord.Text.Trim() + "','" + txtDiag.Text.Trim() + "','" + item.jc_no.ToString() + "','" + txtDiag.Text.Trim() + "','" + item.Zysx.ToString() + "','" + this.listView1.Items[i].SubItems[15].Text.ToString() + "'," + BrJgm + ",'" + this.listView1.Items[i].SubItems[16].Text.ToString() + "')";//dbo.FUN_ZY_SEEKJCNO('" + this.BinID + "','" + printType + "')
                        FrmMdiMain.Database.DoCommand(sSql);

                        selitemH += "\n" + selitem;

                    }
                    FrmMdiMain.Database.CommitTransaction();
                }
                catch (System.Exception er)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    tj = false;
                    if (er.Message.Contains("截断字符串或二进制数据"))
                    {
                        MessageBox.Show("请核对项目【" + selitem + "】检查部位数量，数量过多可分为多条申请!");
                        //MessageBox.Show(selitem.ToString().Length.ToString());
                        return;
                    }
                    else
                    {
                        MessageBox.Show("错误！\n" + er.ToString() + "\n\n检查申请失败！", "失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    if (tj == true) MessageBox.Show(selitemH + "\n检查申请完成！\n成功生成医嘱！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //				FrmMdiMain.Database.Close();
                    button1.Enabled = true;
                    selitemH = "";
                    chcekbl.Checked = false;
                }
                // this.Close();
                #endregion

            }
            else
            {
                bool bl = MzScYz();
                if (bl == false)
                    return;
                //门诊部分
                //    string ssql = "select '' 名称,0 医嘱项目id,0 单价,0 数量,'' 单位,0 金额 ,0 套餐id,'' 频次,'' 标本,'' execDept,'' JcxmId ,'' 附加说明 where 1=2";
                //    DataTable tb = FrmMdiMain.Database.GetDataTable(ssql);
                //    for (int i = 0; i<this.listView1.Items.Count; i++)
                //    {
                //        DataRow r = tb.NewRow();
                //        r["名称"] = this.listView1.Items[i].SubItems[0 + 1].Text;
                //        r["数量"] = this.listView1.Items[i].SubItems[0].Text;
                //        r["医嘱项目id"] = this.listView1.Items[i].SubItems[7].Text;
                //        r["金额"] = myQuery.GetPrice(long.Parse(this.listView1.Items[i].Tag.ToString()), FrmMdiMain.Jgbm) * int.Parse(this.listView1.Items[i].SubItems[0].Text.ToString());
                //        r["单位"] = this.listView1.Items[i].SubItems[1 + 1].Text;
                //        r["单价"] = myQuery.GetPrice(long.Parse(this.listView1.Items[i].Tag.ToString()), FrmMdiMain.Jgbm);
                //        r["频次"] = "";
                //        r["套餐id"] = this.listView1.Items[i].SubItems[10].Text;
                //        r["execDept"] = this.listView1.Items[i].SubItems[8 + 1].Text;
                //        r["JcxmId"] = this.listView1.Items[i].SubItems[7 + 1].Text;
                //        r["标本"] = this.listView1.Items[i].SubItems[3].Text;
                //        r["附加说明"] = "";
                //        tb.Rows.Add(r);
                //    }
                //    //分组处方
                //    string[] GroupbyField1 = { "execDept", "JcxmId" };
                //    string[] ComputeField1 = {};
                //    string[] CField1 = {};
                //    TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                //    xcset1.TsDataTable = tb;
                //    DataTable tbcf1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
                //    DataTable tbmx = tb.Clone();
                //    for (int i = 0; i < tbcf1.Rows.Count; i++)
                //    {
                //        decimal je = 0;
                //        DataRow[] _row = tb.Select("execDept='" + tbcf1.Rows[i]["execDept"] + "' and JcxmId='" + tbcf1.Rows[i]["JcxmId"] + "'");
                //        tbmx.Clear();
                //        for (int j = 0; j < _row.Length; j++)
                //        {
                //            tbmx.Rows.Add(_row[j].ItemArray);
                //            je += myQuery.GetPrice(long.Parse(_row[j]["医嘱项目id"].ToString()), FrmMdiMain.Jgbm) * int.Parse(_row[j]["数量"].ToString());

                //        }
                //        ts_mzys_class.mzys.Yjsq(TrasenFrame.Forms.FrmMdiMain.Jgbm, tbmx, Dqcf.yjsqid, Dqcf.yzid, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 2, lbDateTime.Text.ToString(),
                //FrmMdiMain.CurrentUser.EmployeeId, FrmMdiMain.CurrentDept.DeptId, richRecord.Text, txtDiag.Text, Convert.ToInt32(tbcf1.Rows[i]["execDept"].ToString()),
                // richTextBox1.Text, 0, je, 0, FrmMdiMain.Database);
                //        //ts_mzys_class.mzys.Yjsq(TrasenFrame.Forms.FrmMdiMain.Jgbm, tb, Dqcf.yjsqid, Dqcf.yzid, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 2, label20.Text.ToString(),
                //        //  FrmMdiMain.CurrentUser.EmployeeId, FrmMdiMain.CurrentDept.DeptId, richRecord.Text, txtDiag.Text, Convert.ToInt32(tbcf1.Rows[i]["execDept"].ToString()),
                //        //     "", richTextBox1.Text, 0, je, 0, FrmMdiMain.Database);

                //        //ts_mzys_class.mzys.Yjsq(
                //    }


                //ts_mzys_class.mzys.Yjsq(TrasenFrame.Forms.FrmMdiMain.Jgbm, tb, Dqcf.yjsqid, Dqcf.yzid, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 2, label20.Text.ToString(),
                //  InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, richRecord.Text, txtDiag.Text, Convert.ToInt32(cmbjcks.SelectedValue),
                //  cmbbw.Text, richTextBox1.Text, 0, Convert.ToDecimal(lblPrice.Text), 0, InstanceForm.BDatabase);
            }
            //申请单发送到医技科室
            //			myQuery.apply(this.BinID,Order_Num,chkListBox.CheckedItems.Count,lblName.Text,lblInpatientNo.Text,this.sexNum,this.Birthday,lblBedNo.Text,1);


            ///----------------申请单打印注释----------------////
            if (this.btPrint.Visible == true || this.btPrint.Visible == false)
            {
                //if(myQuery.DoGetApplyInfo(""))
                /*提交医嘱时不打印医嘱【modify by jchl 2015-08-07】
                if (MessageBox.Show("要打印申请单吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    this.btPrint_Click(sender, e);
                 */
            }
            else
            {
                //恢复未选状态
                //				cmbDept_SelectedIndexChanged(sender,e);
                SelectOne();
                lbPrice.Text = "0.00 元";
                cmbPlace.Text = "";
                this.numUpDown.Value = 1;
                this.numUpDown.Enabled = false;
            }
            this.Close();
        }

        private bool MzScYz()
        {
            //门诊部分
            string ssql = "select '' 名称,0 医嘱项目id,0.00 单价,0 数量,'' 单位,0.00 金额 ,0 套餐id,'' 频次,'' 标本,'' execDept,'' JcxmId ,'' 附加说明 where 1=2";
            DataTable tb = FrmMdiMain.Database.GetDataTable(ssql);
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                DataRow r = tb.NewRow();
                r["名称"] = this.listView1.Items[i].SubItems[0].Text;
                r["数量"] = this.listView1.Items[i].SubItems[2].Text;
                r["医嘱项目id"] = this.listView1.Items[i].SubItems[9].Text;
                r["金额"] = myQuery.GetPrice(long.Parse(this.listView1.Items[i].Tag.ToString()), FrmMdiMain.Jgbm) * int.Parse(this.listView1.Items[i].SubItems[2].Text.ToString());
                r["单位"] = this.listView1.Items[i].SubItems[3].Text;
                r["单价"] = myQuery.GetPrice(long.Parse(this.listView1.Items[i].Tag.ToString()), FrmMdiMain.Jgbm);
                r["频次"] = "";
                r["套餐id"] = this.listView1.Items[i].SubItems[12].Text;
                r["execDept"] = this.listView1.Items[i].SubItems[11].Text;
                r["JcxmId"] = this.listView1.Items[i].SubItems[10].Text;
                r["标本"] = this.listView1.Items[i].SubItems[1].Text;
                r["附加说明"] = "";
                tb.Rows.Add(r);
            }
            //分组处方
            string[] GroupbyField1 = { "execDept", "JcxmId" };
            string[] ComputeField1 = { };
            string[] CField1 = { };
            TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
            xcset1.TsDataTable = tb;
            DataTable tbcf1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
            DataTable tbmx = tb.Clone();
            DataTable tb_hjinfo = new DataTable();
            if (Dqcf.yzid != Guid.Empty) //如果是更新 需要判断当前明细的执行科室和原有的执行科室 不同则提示 并返回
                tb_hjinfo = ts_mz_class.mz_hj.GetHjInfo(Dqcf.yzid, FrmMdiMain.Database);
            for (int i = 0; i < tbcf1.Rows.Count; i++)
            {
                decimal je = 0;
                DataRow[] _row = tb.Select("execDept='" + tbcf1.Rows[i]["execDept"] + "' and JcxmId='" + tbcf1.Rows[i]["JcxmId"] + "'");
                tbmx.Clear();
                for (int j = 0; j < _row.Length; j++)
                {
                    tbmx.Rows.Add(_row[j].ItemArray);
                    je += myQuery.GetPrice(long.Parse(_row[j]["医嘱项目id"].ToString()), FrmMdiMain.Jgbm) * int.Parse(_row[j]["数量"].ToString());

                }

                for (int j = 0; j < tbmx.Rows.Count; j++)
                {
                    if (Dqcf.yzid != Guid.Empty && tb_hjinfo.Rows.Count > 0) //如果是更新 需要判断当前明细的执行科室和原有的执行科室 不同则提示 并返回
                    {
                        if (tbmx.Rows[j]["execDept"].ToString().Trim() != tb_hjinfo.Rows[0]["zxks"].ToString().Trim())
                        {
                            MessageBox.Show("当前执行科室与原处方执行科室不同!不允许修改!", "提示");
                            return false;
                        }
                    }
                }
                ts_mzys_class.mzys.Yjsq(TrasenFrame.Forms.FrmMdiMain.Jgbm, tbmx, Dqcf.yjsqid, Dqcf.yzid, Dqcf.brxxid, Dqcf.ghxxid, Dqcf.jzid, Dqcf.mzh, 2, lbDateTime.Text.ToString(),
                    sqys == 0 ? FrmMdiMain.CurrentUser.EmployeeId : sqys, sqks == 0 ? FrmMdiMain.CurrentDept.DeptId : sqks, richRecord.Text, txtDiag.Text, Convert.ToInt32(tbcf1.Rows[i]["execDept"].ToString()),
                 richTextBox1.Text, 0, je, 0, issfy, FrmMdiMain.Database);
            }
            return true;
        }

        #endregion

        #region 打印检查申请
        private void btPrint_Click(object sender, System.EventArgs e)
        {
            if (!CheckBw())
                return;
            if (this.listView1.Items.Count == 0)
                return;
            //获得卡号信息
            //Modify By Tany 2015-01-28 把病人信息也放出来，住院的会用到
            string sql = "  select a.kh,b.* from YY_KDJB a right join ZY_INPATIENT b on a.BRXXID=b.PATIENT_ID where b.INPATIENT_ID='" + BinID + "'";
            if (BrLy == Typely.门诊)
                sql = "  select a.kh from YY_KDJB a  where brxxid='" + Dqcf.brxxid + "'";
            DataTable tbPat = FrmMdiMain.Database.GetDataTable(sql);
            string brkh = "";
            if (tbPat.Rows.Count > 0)
                brkh = Convertor.IsNull(tbPat.Rows[0]["KH"], "");
            Cursor = Cursors.WaitCursor;
            DsJyJc.rptAPPDataTable ds = new DsJyJc.rptAPPDataTable();
            DsJyJc.rptAPPDataTable tb = new DsJyJc.rptAPPDataTable();
            //add by caicheng 2013-05-22
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.AddRange(new DataColumn[]{
                             new DataColumn("orderID",typeof(long)),
                             new DataColumn("orderName",typeof(string)),
                             new DataColumn("defaultUsage",typeof(string)),
                             new DataColumn("execDept",typeof(long)),
                             new DataColumn("orderUnit",typeof(string)),
                             new DataColumn("place",typeof(string)),
                             new DataColumn("JcxmId",typeof(long)),
                             new DataColumn("IsUpdate",typeof(long)),
                             new DataColumn("DeptName",typeof(string)),
                             new DataColumn("JCLXNaMe",typeof(string)),
                             new DataColumn("IN_DIAGNOSIS",typeof(string)),
                             new DataColumn("zysx",typeof(string)),
                 new DataColumn("num",typeof(long))
            });
            //add by zouchihua 2013-3-22
            Item[] itemgruop = new Item[this.listView1.Items.Count];
            for (int x = 0; x < this.listView1.Items.Count; x++)
            {
                itemgruop[x] = new Item();
                itemgruop[x].orderID = long.Parse(this.listView1.Items[x].SubItems[9].Text);//医嘱id
                itemgruop[x].orderName = this.listView1.Items[x].SubItems[0].Text;//医嘱内容
                itemgruop[x].defaultUsage = this.listView1.Items[x].SubItems[7].Text;//默认用法
                itemgruop[x].execDept = long.Parse(this.listView1.Items[x].SubItems[11].Text);//执行科室id
                itemgruop[x].orderUnit = this.listView1.Items[x].SubItems[3].Text; //单位
                itemgruop[x].JcxmId = long.Parse(this.listView1.Items[x].SubItems[10].Text); //项目类型 id

                dt.Rows.Add(new object[] {  long.Parse(this.listView1.Items[x].SubItems[9].Text) ,//医嘱id
                                        this.listView1.Items[x].SubItems[0].Text,//医嘱内容
                                        this.listView1.Items[x].SubItems[7].Text,//默认用法
                                        long.Parse(this.listView1.Items[x].SubItems[11].Text),//执行科室id
                                        this.listView1.Items[x].SubItems[3].Text,//单位
                                        this.listView1.Items[x].SubItems[1].Text,//部位
                                        long.Parse(this.listView1.Items[x].SubItems[10].Text),0,//项目类型 id
                                        this.listView1.Items[x].SubItems[6].Text,//检查科室
                                        this.listView1.Items[x].SubItems[8].Text,//检查化验类型名称
                                        this.listView1.Items[x].SubItems[13].Text,//临床诊断
                                        this.listView1.Items[x].SubItems[14].Text,//注意事项
                   long.Parse( this.listView1.Items[x].SubItems[2].Text),//数量
                });

            }

            //按照执行科室和项目类型分组分别打印 
            DataTable dttemp = dt.Clone();
            for (int j = 0; j <= dt.Rows.Count - 1; j++)
            {
                dttemp.Clear();
                if (dt.Rows[j]["IsUpdate"].ToString() == "1") continue;
                dttemp.Rows.Add(dt.Rows[j].ItemArray);
                dt.Rows[j]["IsUpdate"] = 1;
                for (int z = j + 1; z <= dt.Rows.Count - 1; z++)
                {
                    if (dt.Rows[j]["execDept"].ToString() == dt.Rows[z]["execDept"].ToString() && dt.Rows[j]["JcxmId"].ToString() == dt.Rows[z]["JcxmId"].ToString() && dt.Rows[z]["IsUpdate"].ToString() == "0")
                    {
                        dttemp.Rows.Add(dt.Rows[z].ItemArray);
                        dt.Rows[z]["IsUpdate"] = 1;
                    }
                }
                if (dttemp.Rows.Count == 0) continue;
                #region  打印
                tb.Clear();

                //Modify by jchl 2015-08-05 打印单独医嘱价格
                //List<string> LtPrice = new List<string>();
                //foreach (DataRow row in dttemp.Rows)
                //{
                //    LtPrice.Add(row["orderID"].ToString());
                //}
                //string strPrice = GetPrice(LtPrice);

                string bbmc = "";
                for (int i = 0; i <= dttemp.Rows.Count - 1; i++)
                {
                    DataRow dr = tb.NewRow();
                    for (int h = 1; h < 7; h++)
                    {
                        dr["col" + h.ToString()] = "";
                    }
                    List<string> ltOrid = new List<string>();
                    ltOrid.Add(dttemp.Rows[i]["orderID"].ToString());
                    if (Typely.住院 == BrLy)
                    {
                        dr["binname"] = patientBar1.lblName.Text;
                        dr["sex"] = patientBar1.lblSex.Text;
                        dr["age"] = patientBar1.lblage.Text;
                        dr["yqDoc"] = FrmMdiMain.CurrentUser.Name;
                        dr["yqDate"] = this.lbDateTime.Text;
                        dr["deptName"] = FrmMdiMain.CurrentDept.DeptName;
                        dr["wardName"] = FrmMdiMain.CurrentDept.WardName;
                        dr["bedID"] = Convertor.IsNull(patientBar1.lblBedNo.Text, "");

                        dr["symptom"] = richRecord.Text;
                        dr["diagnosis"] = dttemp.Rows[i]["IN_DIAGNOSIS"];
                        dr["place"] = dttemp.Rows[i]["place"];//this.cmbPlace.Text.Trim();
                        dr["itemName"] = dttemp.Rows[i]["orderName"];// chkListBox.CheckedItems;
                        dr["inpatientid"] = "*" + patientBar1.lblInpatientNo.Text + "*";

                        //Modify by jchl 2015-08-05 打印单独医嘱价格
                        dr["price"] = myQuery.GetPrice(long.Parse(dttemp.Rows[i]["orderID"].ToString()), FrmMdiMain.Jgbm);
                        //dr["price"] = strPrice;

                        dr["bz"] = dttemp.Rows[i]["zysx"];
                        dr["yymc"] = (new SystemCfg(2)).Config;

                        dr["lxmc"] = "住院病人" + dttemp.Rows[i]["JCLXNaMe"] + "申请单";
                        dr["col1"] = brkh;
                        //增加价格和数量
                        dr["col2"] = GetPrice(ltOrid);
                        dr["col3"] = dttemp.Rows[i]["num"].ToString();//数量
                        dr["col4"] = dttemp.Rows[i]["deptname"].ToString();//检查科室

                        //Modify By Tany 2015-01-28 增加电话
                        dr["col5"] = tbPat.Columns.Contains("lxrdh") ? Convertor.IsNull(tbPat.Rows[0]["lxrdh"], "") : "";
                    }
                    else
                    {
                        dr["binname"] = lblxm.Text;
                        dr["sex"] = lblxb.Text;
                        dr["age"] = lblnl.Text;
                        dr["yqDoc"] = FrmMdiMain.CurrentUser.Name;
                        dr["yqDate"] = this.lbDateTime.Text;
                        dr["deptName"] = FrmMdiMain.CurrentDept.DeptName;
                        dr["wardName"] = FrmMdiMain.CurrentDept.DeptName;
                        dr["bedID"] = "";
                        //			dr["address"]=dt.Rows[0]["unit_name"];
                        //			dr["tele"]=dt.Rows[0]["unit_tel"];
                        dr["symptom"] = richRecord.Text;
                        dr["diagnosis"] = this.txtDiag.Text.Trim();
                        dr["place"] = dttemp.Rows[i]["place"];//this.cmbPlace.Text.Trim();
                        dr["itemName"] = dttemp.Rows[i]["orderName"];// chkListBox.CheckedItems;
                        dr["inpatientid"] = lblmzh.Text;// 门诊号

                        //Modify by jchl 2015-08-05 打印单独医嘱价格
                        dr["price"] = myQuery.GetPrice(long.Parse(dttemp.Rows[i]["orderID"].ToString()), FrmMdiMain.Jgbm);
                        //dr["price"] = strPrice;

                        dr["bz"] = "";
                        dr["yymc"] = (new SystemCfg(2)).Config;
                        //增加价格和数量
                        dr["col2"] = GetPrice(ltOrid);
                        dr["col3"] = dttemp.Rows[i]["num"].ToString();//数量
                        dr["col1"] = brkh;
                        dr["col4"] = dttemp.Rows[i]["deptname"].ToString();//检查科室
                        //  tb.Rows.Add(dr);

                        dr["lxmc"] = "门诊病人" + dttemp.Rows[i]["JCLXNaMe"] + "申请单";
                    }

                    bbmc = dttemp.Rows[i]["JCLXNaMe"].ToString();


                    tb.Rows.Add(dr);
                }
                if (Typely.住院 == BrLy)
                {
                    printFile = "Zy_检查申请.rpt";
                    printFile = "Zy_" + bbmc + ".rpt";
                }
                else
                {
                    printFile = "Mz_检查申请.rpt";
                    printFile = "Mz_" + bbmc + ".rpt";
                }
                if (printFile == "")
                {
                    {
                        this.printPreviewDialog1.Document = this.printDocument1;
                        this.printPreviewDialog1.ShowDialog();
                    }
                    Cursor = Cursors.Arrow;
                    return;
                }
                else
                {
                    try
                    {
                        if (System.IO.File.Exists(Constant.ApplicationDirectory + "\\report\\" + printFile)
                            || System.IO.File.Exists(Constant.CustomDirectory + "\\report\\" + printFile))
                        {
                            FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
                            rv.ShowDialog();
                        }
                        else
                        {
                            if (Typely.住院 == BrLy)
                                //如果没有就 默认统一的检查单
                                printFile = "Zy_检查申请.rpt";
                            else
                                //如果没有就 默认统一的检查单
                                printFile = "Mz_检查申请.rpt";
                            FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
                            rv.ShowDialog();
                        }
                    }
                    catch
                    {
                        if (Typely.住院 == BrLy)
                            //如果没有就 默认统一的检查单
                            printFile = "Zy_检查申请.rpt";
                        else
                            //如果没有就 默认统一的检查单
                            printFile = "Mz_检查申请.rpt";
                        FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
                        rv.ShowDialog();
                    }
                }
                Cursor = Cursors.Arrow;
                #endregion
            }
            this.lbPrice.Text = Getprice() + " 元";
            #region
            //for (int i = 0; i <= itemgruop.Length - 1; i++)
            //{
            //    DataRow dr = tb.NewRow();

            //    dr["binname"] = patientBar1.lblName.Text;
            //    dr["sex"] = patientBar1.lblSex.Text;
            //    dr["age"] = patientBar1.lblage.Text;
            //    dr["yqDoc"] = FrmMdiMain.CurrentUser.Name;
            //    dr["yqDate"] = this.lbDateTime.Text;
            //    dr["deptName"] = patientBar1.lblWard.Text;
            //    dr["wardName"] = patientBar1.lblWard.Text;
            //    dr["bedID"] = Convertor.IsNull(patientBar1.lblBedNo.Text, "");
            //    //			dr["address"]=dt.Rows[0]["unit_name"];
            //    //			dr["tele"]=dt.Rows[0]["unit_tel"];
            //    dr["symptom"] = richRecord.Text;
            //    dr["diagnosis"] = this.txtDiag.Text.Trim();
            //    dr["place"] = this.listView1.Items[i].SubItems[2].Text;//this.cmbPlace.Text.Trim();
            //    dr["itemName"] = itemgruop[i].orderName.ToString();// chkListBox.CheckedItems;
            //    dr["inpatientid"] = patientBar1.lblInpatientNo.Text;
            //    dr["price"] = this.lbPrice.Text;
            //    dr["bz"] = "";
            //    dr["yymc"] = (new SystemCfg(2)).Config;
            //    dr["lxmc"] = "住院病人" + this.cmbClass.Text.Trim() + "申请单";
            //    for (int j = 1; j < 7; j++)
            //    {
            //        dr["col" + j.ToString()] = "";
            //    }
            //    dr["col1"] = brkh;
            //    tb.Rows.Add(dr);
            //}


            //printFile = "Zy_检查申请.rpt";
            //printFile = "Zy_"+ this.cmbClass.Text.Trim() +".rpt";
            //if (printFile == "")
            //{ 
            //    {
            //        this.printPreviewDialog1.Document = this.printDocument1;
            //        this.printPreviewDialog1.ShowDialog();
            //    }
            //    Cursor = Cursors.Arrow;
            //    return;
            //}
            //else
            //{
            //    try
            //    {
            //        if (System.IO.File.Exists(Constant.ApplicationDirectory + "\\report\\" + printFile)
            //            || System.IO.File.Exists(Constant.CustomDirectory + "\\report\\" + printFile))
            //        {
            //            FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
            //            rv.ShowDialog();
            //        }
            //        else
            //        {
            //            //如果没有就 默认统一的检查单
            //            printFile = "Zy_检查申请.rpt";
            //            FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
            //            rv.ShowDialog();
            //        }
            //    }
            //    catch
            //    {
            //        //如果没有就 默认统一的检查单
            //        printFile = "Zy_检查申请.rpt";
            //        FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
            //        rv.ShowDialog();
            //    }
            //} 
            //Cursor = Cursors.Arrow;
            #endregion
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string str = "住院病人" + this.cmbClass.Text.Trim() + "申请单";
            string str0 = (new SystemCfg(2)).Config;
            int left = e.MarginBounds.Left,
                top = e.MarginBounds.Top;
            int num = Convert.ToInt16((e.MarginBounds.Width - str.Length * 27) / 2),
                num0 = Convert.ToInt16((e.MarginBounds.Width - str0.Length * 20) / 2);
            string sSql = "select name from jc_employee_property where employee_id=" + YS_ID.ToString();
            DataTable myTb = FrmMdiMain.Database.GetDataTable(sSql);
            string YS_name = myTb.Rows[0]["name"].ToString().Trim();


            brush = new SolidBrush(Color.Black);
            font = new Font("楷体_GB2312", 20, FontStyle.Bold);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(str, font, brush, left + num, 30 + top, System.Drawing.StringFormat.GenericTypographic);
            font = new Font("楷体_GB2312", 15, FontStyle.Regular);
            e.Graphics.DrawString(str0, font, brush, left + num0, top, System.Drawing.StringFormat.GenericTypographic);

            font = new Font("宋体", 11, FontStyle.Bold);
            e.Graphics.DrawString("姓名：" + patientBar1.lblName.Text, font, brush, left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("性别：" + patientBar1.lblSex.Text, font, brush, 120 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("年龄：" + patientBar1.lblage.Text, font, brush, 210 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("病区：" + patientBar1.lblWard.Text, font, brush, 290 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("床号：" + patientBar1.lblBedNo.Text, font, brush, 400 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("住院号：" + patientBar1.lblInpatientNo.Text, font, brush, 470 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("简要病史及检查：", font, brush, left, 130 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString(richRecord.Text, new Font("宋体", 11, FontStyle.Regular), brush, new Rectangle(left, 170 + top, e.MarginBounds.Width, 200));
            e.Graphics.DrawString("临床诊断：", font, brush, left, 380 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString(this.txtDiag.Text.Trim(), font, brush, 100 + left, 380 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("申请日期：" + this.lbDateTime.Text, font, brush, 400 + left, 800 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("检查项目：", font, brush, left, 430 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("检查费：" + this.lbPrice.Text, font, brush, 400 + left, 750 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("申请医师：" + YS_name, font, brush, 130 + left, 800 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), left, 160 + top, e.MarginBounds.Width, 200);

            for (int i = 0; i <= chkListBox.CheckedItems.Count - 1; i++)
            {
                stritem = chkListBox.CheckedItems[i].ToString();
                font = new Font("宋体", 11, FontStyle.Bold);
                e.Graphics.DrawString(stritem, font, brush, new Rectangle(60 + left, 470 + i * 30 + top, 400, 60));
            }
            e.HasMorePages = false;
            //	e.Graphics.DrawString("",font,brush,new Rectangle(20,140,400,60));

            brush.Dispose();
            font.Dispose();

        }
        #endregion

        #region 控制richTextBox
        private void richRecord_Enter(object sender, System.EventArgs e)
        {
            this.richRecord.Height = 200;
        }

        private void richRecord_Leave(object sender, System.EventArgs e)
        {
            this.richRecord.Height = 28;

        }
        private void tabPage1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //this.richRecord.Height = 28;
            this.txtDiag.Focus();

        }
        #endregion

        #region 申请单背景字
        private void tabPage1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            brush = new SolidBrush(Color.FromArgb(40, Color.LightCyan));
            font = new Font("宋体", 20, FontStyle.Italic);
            for (int x = 0; x <= 6; x++)
                for (int y = 0; y <= 15; y++)
                {
                    e.Graphics.DrawString("检查申请单", font, brush, x * 160, y * 35);
                }
            brush.Dispose();
            font.Dispose();
        }
        #endregion

        private void txtPlace_Enter(object sender, System.EventArgs e)
        {
            this.numUpDown.Enabled = true;
        }

        private void numUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            this.lbPrice.Text = Convert.ToString(pr * numUpDown.Value) + " 元";
        }
        int Dqh = 0;
        private void txtDM_TextChanged(object sender, System.EventArgs e)
        {
            //for (int i = 0; i < chkListBox.Items.Count; i++)
            //{
            //    if (((Item)chkListBox.Items[i]).pym.IndexOf(txtDM.Text.Trim().ToLower(), 0) == 0)
            //    {
            //        this.chkListBox.SelectedIndex = i;
            //        break;
            //    }
            //}
            //检索
            Dqh = 0;
            DataTable tb = this.dt_item.Copy();
            //DataRow[] r = tb.Select("Py_code='" + txtDM.Text.Trim() + "'");
            DataTable newdt = new DataTable(); 
            newdt = tb.Clone(); // 克隆dt 的结构，包括所有 dt 架构和约束,并无数据； 
            DataRow[] rows = tb.Select("D_code like'%" + txtDM.Text.Trim() + "%'" + "or Py_code like'%" + txtDM.Text.Trim() + "%'"); // 从dt 中查询符合条件的记录； 
            foreach (DataRow row in rows)  // 将查询的结果添加到newdt中； 
            {
                newdt.Rows.Add(row.ItemArray);
            }
            if (newdt.Rows.Count <= 0)
            {
                MessageBox.Show("无此项目编码或无此编码开立权限,请联系物价科！");
            }
            this.dataGridviewEx1.DataSource = newdt;
            for (int i = Dqh; i < newdt.Rows.Count; i++)
            {
                if (newdt.Rows[i]["Py_code"].ToString().IndexOf(txtDM.Text.Trim().ToLower(), 0) == 0)
                {
                    this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[i].Cells[1];
                    Dqh = i;
                    break;
                }
                if (newdt.Rows[i]["D_code"].ToString().IndexOf(txtDM.Text.Trim().ToLower(), 0) == 0)
                {
                    this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[i].Cells[1];
                    Dqh = i;
                    break;
                }
                if (newdt.Rows[i]["WB_code"].ToString().IndexOf(txtDM.Text.Trim().ToLower(), 0) == 0)
                {
                    this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[i].Cells[1];
                    Dqh = i;
                    break;
                }
            }
            //for (int i = Dqh; i < tb.Rows.Count; i++)
            //{
            //    if (tb.Rows[i]["Py_code"].ToString().IndexOf(txtDM.Text.Trim().ToLower(), 0) == 0)
            //    {
            //        this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[i].Cells[1];
            //        Dqh = i;
            //        break;
            //    }
            //    if (tb.Rows[i]["D_code"].ToString().IndexOf(txtDM.Text.Trim().ToLower(), 0) == 0)
            //    {
            //        this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[i].Cells[1];
            //        Dqh = i;
            //        break;
            //    }
            //    if (tb.Rows[i]["WB_code"].ToString().IndexOf(txtDM.Text.Trim().ToLower(), 0) == 0)
            //    {
            //        this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[i].Cells[1];
            //        Dqh = i;
            //        break;
            //    }
            //}
            Qbx();
        }

        private void chkListBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == 32 && chkMore.Checked == false) SelectOne();
            if (e.KeyValue != 13) return;
            if (this.chkMore.Checked == false) SelectOne();
            if (this.chkListBox.GetItemChecked(this.chkListBox.SelectedIndex) == false)
                this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, true);
            else this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, false);
            chkListBox_SelectedIndexChanged(sender, e);
        }

        private void txtDM_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int sel = this.chkListBox.SelectedIndex;
            if (e.KeyValue == 13 && this.chkListBox.SelectedItems.Count != 0)
            {
                if (this.chkMore.Checked == false) SelectOne();
                if (this.chkListBox.GetItemChecked(sel) == false)
                {
                    this.chkListBox.SetItemChecked(sel, true);
                }
                else this.chkListBox.SetItemChecked(sel, false);
                chkListBox_SelectedIndexChanged(sender, e);
                txtDM.Text = "";
                this.chkListBox.SelectedIndex = sel;
            }
            if (e.KeyValue == 13)
            {
                this.txtDM.TextChanged -= new System.EventHandler(this.txtDM_TextChanged);
                txtDM.Text = "";
                this.txtDM.TextChanged += new System.EventHandler(this.txtDM_TextChanged);
            }
            //if(e.KeyValue!=13)
            //    this.Qbx();
            if (e.KeyValue == 40)
            {
                if (sel < this.chkListBox.Items.Count - 1) this.chkListBox.SelectedIndex++;
            }
            if (e.KeyValue == 39)
            {
                if (sel + 7 < this.chkListBox.Items.Count) this.chkListBox.SelectedIndex += 7;
            }
            if (e.KeyValue == 38)
            {
                if (sel > 0) this.chkListBox.SelectedIndex--;
            }
            if (e.KeyValue == 37)
            {
                if (sel - 7 >= 0) this.chkListBox.SelectedIndex -= 7;
            }

        }

        private void txtDM_Enter(object sender, System.EventArgs e)
        {
            //txtDM.Text = "";
            txtDM.BackColor = Color.Honeydew;
        }

        private void txtDM_Leave(object sender, System.EventArgs e)
        {
            //txtDM.Text = "<拼音码>";
            txtDM.BackColor = Color.WhiteSmoke;//this.tabPage1.BackColor;

        }

        //取消所有被Checked的项目
        private void SelectOne()
        {
            for (int i = 0; i < this.chkListBox.Items.Count; i++)
            {
                this.chkListBox.SetItemChecked(i, false);
            }
            // lbPrice.Text = "0.0 元";
        }

        private void chkListBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            if (this.chkMore.Checked == false)
            {
                for (int i = 0; i < this.chkListBox.Items.Count; i++)
                {
                    if (i != chkListBox.SelectedIndex)
                        this.chkListBox.SetItemChecked(i, false);
                }
            }
            // lbPrice.Text = "0.0 元";
        }

        private void chkMore_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chkListBox.CheckedItems.Count != 1 && this.chkMore.Checked == false) SelectOne();
        }
        #endregion

        #region 查询页

        #region 检查医嘱费用合计(查询页)
        private string priceHJ(DataTable myTb)
        {
            decimal price = 0;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["检查费"] == System.DBNull.Value) continue;
                price += Convert.ToDecimal(myTb.Rows[i]["检查费"].ToString().Trim());
            }
            return price.ToString().Trim();
        }
        #endregion

        #region  检查医嘱查询显示
        public void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                this.button1.Visible = false;
                this.btPrint.Visible = false;
                this.btSaveTC.Visible = false;
                this.btDelTC.Visible = false;
                this.label16.Visible = false;
                this.lbPrice.Visible = false;
            }
            else
            {
                this.button1.Visible = true;
                this.btPrint.Visible = true;
                this.btSaveTC.Visible = true;
                this.btDelTC.Visible = true;
                this.label16.Visible = true;
                this.lbPrice.Visible = true;
            }

            DataTable myTb = new DataTable();
            this.Text = tabControl1.SelectedTab.Text;

            //显示检查医嘱
            if (tabControl1.SelectedTab == tabPage2)
            {
                //DataTable dtplace = new DataTable();
                //string sqlplace = "select HOITEM_ID,GROUP_ID,PLACE FROM ZY_JC_RECORD where INPATIENT_ID='" + this.BinID + "'";
                //dtplace = FrmMdiMain.Database.GetDataTable(sqlplace);
                mydt = GetQueryTb();
                //for (int i = 0; i < mydt.Rows.Count; i++)
                //{
                //    if (mydt.Rows[i]["检查项目"].ToString().Contains("【"))
                //    {

                //    }
                //    else
                //    {
                //        DataRow[] drplace = dtplace.Select("HOITEM_ID='" + mydt.Rows[i]["HID"] + "'and GROUP_ID='" + mydt.Rows[i]["医嘱号"] + "'");
                //        if (drplace.Length > 0 && drplace[0]["PLACE"].ToString() != "")
                //        {
                //            string palce = drplace[0]["PLACE"].ToString();
                //            mydt.Rows[i]["检查项目"] += "【" + palce + "】";
                //        }
                //    }
                //}
                if (mydt.Rows.Count == 0) return;
                GrdJY.DataSource = mydt;
                GrdJY.ReadOnly = true;
                GrdJY.CaptionText = "患者：" + patientBar1.lblName.Text.Trim() + "                                                          费用合计：" + priceHJ(mydt) + " 元";

                GrdJY.TableStyles[0].AllowSorting = false;
                GrdJY.TableStyles[0].GridColumnStyles[0].Width = 0;
                GrdJY.TableStyles[0].GridColumnStyles[1].Width = 100;
                if (BrLy == Typely.门诊)
                    GrdJY.TableStyles[0].GridColumnStyles[2].Width = 0;
                else
                    GrdJY.TableStyles[0].GridColumnStyles[2].Width = 50;
                GrdJY.TableStyles[0].GridColumnStyles[3].Width = 200;
                GrdJY.TableStyles[0].GridColumnStyles[4].Width = 100;
                GrdJY.TableStyles[0].GridColumnStyles[5].Width = 60;
                GrdJY.TableStyles[0].GridColumnStyles[5].Alignment = System.Windows.Forms.HorizontalAlignment.Right;
                GrdJY.TableStyles[0].GridColumnStyles[6].Width = 70;
                GrdJY.TableStyles[0].GridColumnStyles[6].Alignment = System.Windows.Forms.HorizontalAlignment.Center;
                GrdJY.TableStyles[0].GridColumnStyles[7].Alignment = System.Windows.Forms.HorizontalAlignment.Center;
                GrdJY.TableStyles[0].GridColumnStyles[7].Width = 100;
                GrdJY.TableStyles[0].GridColumnStyles[8].Width = 0;
                GrdJY.TableStyles[0].GridColumnStyles[9].Width = 0;
                GrdJY.TableStyles[0].GridColumnStyles[10].Width = 0;
                GrdJY.TableStyles[0].GridColumnStyles[11].Width = 0;
                GrdJY.TableStyles[0].GridColumnStyles[12].Width = 0;
                GrdJY.TableStyles[0].GridColumnStyles[13].Width = 0;
                GrdJY.TableStyles[0].GridColumnStyles[14].Width = 0;
                if (BrLy == Typely.门诊)
                    GrdJY.TableStyles[0].GridColumnStyles[15].Width = 0;
                else
                    GrdJY.TableStyles[0].GridColumnStyles[15].Width = 50;
                // 定位在最后一条记录上
                //				myBind=this.BindingContext[mydt];
                //				myBind.Position=myBind.Count-1;
                GrdJY.TableStyles[0].GridColumnStyles[19].Width = 0;
                DelDataGridTextBox(GrdJY);
            }
        }

        // 当前患者所有检查医嘱
        private DataTable GetQueryTb()
        {
            if (BrLy == Typely.门诊)
                return myQuery.GetItemOrders(Dqcf.ghxxid, 2, FrmMdiMain.Jgbm);
            else
                return myQuery.GetItemOrders(this.BinID, 1, FrmMdiMain.Jgbm);
        }

        private void GrdJY_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.GrdJY.Select(this.GrdJY.CurrentRowIndex);//选取整行
        }
        #endregion

        #region 显示检查报告
        private void GrdJY_DoubleClick(object sender, System.EventArgs e)
        {
            //            string strJY = "";
            //            if (mydt.Rows.Count == 0) return;
            //            strJY = mydt.Rows[GrdJY.CurrentRowIndex]["检查项目"].ToString();

            //            string sSql = @"SELECT xmlreport FROM YJ_REPORT A INNER JOIN YJ_ARRANGEQUEUE C ON A.ARRANGEID = C.ID INNER JOIN YJ_APPLYRECORD B ON C.APPLYID = B.ID
            //                          WHERE (B.ORDERID =" + mydt.Rows[GrdJY.CurrentRowIndex]["ID"].ToString() + ")";

            //            DataTable dTable = FrmMdiMain.Database.GetDataTable(sSql);
            //            this.richJC.Controls.Clear();
            //            if (dTable.Rows.Count != 0)
            //            {
            //                this.richJC.Text = "";
            //                //				this.richJC.Controls.Clear();
            //                if (dTable.Rows[0][0].ToString().Trim() == "")
            //                {
            //                    this.panel4.Visible = true;
            //                    this.richJC.Text = strJY + "\n\n没有该检查报告";
            //                    return;
            //                }
            //                ReadXMLReport(dTable.Rows[0][0].ToString(), richJC);
            //            }
            //            else this.richJC.Text = strJY + "\n\n没有该检查报告";
            //            this.panel4.Visible = true;

            string sql = "";
            if (BrLy == Typely.门诊)
                sql = "  select a.kh from YY_KDJB a  where brxxid='" + Dqcf.brxxid + "'";
            else
                sql = "  select a.kh from YY_KDJB a  join ZY_INPATIENT b on a.BRXXID=b.PATIENT_ID where b.INPATIENT_ID='" + BinID + "'";
            DataTable tbPat = FrmMdiMain.Database.GetDataTable(sql);
            string brkh = "";
            if (tbPat.Rows.Count > 0)
                brkh = tbPat.Rows[0]["KH"].ToString();
            Cursor = Cursors.WaitCursor;
            DsJyJc.rptAPPDataTable ds = new DsJyJc.rptAPPDataTable();
            DsJyJc.rptAPPDataTable tb = new DsJyJc.rptAPPDataTable();

            CurrencyManager cm_row = (CurrencyManager)BindingContext[GrdJY.DataSource];
            DataRowView row = cm_row.Current as DataRowView;//双击后数据源的当前行
            #region  打印

            //已经生成了医技申请单的医嘱才能够继续打印
            if (myQuery.DoGetApplyInfo(row["ID"].ToString()))
            {
                btPrint_cx(row);
            }
            else
            {
                MessageBox.Show("该医技项目未转抄发送,请联系护士发送医嘱后再操作打印", "提示");
                Cursor = Cursors.Arrow;
                return;
            }
            //DataRow dr = tb.NewRow();
            //for (int h = 1; h < 7; h++)
            //{
            //    dr["col" + h.ToString()] = "";
            //}
            //if (Typely.住院 == BrLy)
            //{
            //    dr["binname"] = patientBar1.lblName.Text;
            //    dr["sex"] = patientBar1.lblSex.Text;
            //    dr["age"] = patientBar1.lblage.Text;
            //    dr["yqDoc"] = FrmMdiMain.CurrentUser.Name;
            //    dr["yqDate"] = this.lbDateTime.Text;
            //    dr["deptName"] = patientBar1.lblWard.Text;
            //    dr["wardName"] = patientBar1.lblWard.Text;
            //    dr["bedID"] = Convertor.IsNull(patientBar1.lblBedNo.Text, "");

            //    dr["symptom"] = richRecord.Text;
            //    dr["diagnosis"] = this.txtDiag.Text.Trim();
            //    //  dr["place"] = row["place"];//this.cmbPlace.Text.Trim();
            //    dr["itemName"] = row["检查项目"];
            //    dr["inpatientid"] = patientBar1.lblInpatientNo.Text;
            //    dr["price"] = Convert.ToDecimal(row["检查费"].ToString());
            //    dr["bz"] = "";
            //    dr["yymc"] = (new SystemCfg(2)).Config;

            //    dr["lxmc"] = "住院病人" + patientBar1.lblName.Text + "申请单";
            //    dr["col1"] = brkh;
            //    dr["col4"] = row.Row.ItemArray[4];//检查科室
            //}
            //else
            //{
            //    dr["binname"] = lblxm.Text;
            //    dr["sex"] = lblxb.Text;
            //    dr["age"] = lblnl.Text;
            //    dr["yqDoc"] = FrmMdiMain.CurrentUser.Name;
            //    dr["yqDate"] = this.lbDateTime.Text;
            //    dr["deptName"] = FrmMdiMain.CurrentDept.DeptName;
            //    dr["wardName"] = FrmMdiMain.CurrentDept.DeptName;
            //    dr["bedID"] = "";
            //    dr["symptom"] = richRecord.Text;
            //    dr["diagnosis"] = this.txtDiag.Text.Trim();
            //    // dr["place"] = row["place"];
            //    dr["itemName"] = row["检查项目"];
            //    dr["inpatientid"] = lblmzh.Text;// 门诊号
            //    dr["price"] = Convert.ToDecimal(row["检查费"].ToString());
            //    dr["bz"] = "";
            //    dr["yymc"] = (new SystemCfg(2)).Config;
            //    dr["col1"] = brkh;
            //    dr["col4"] = row.Row.ItemArray[4];//检查科室

            //    dr["lxmc"] = "门诊病人" + patientBar1.lblName.Text + "申请单";
            //}

            //tb.Rows.Add(dr);

            //if (Typely.住院 == BrLy)
            //    printFile = "Zy_检查申请.rpt";
            //else
            //    printFile = "Mz_检查申请.rpt";

            //if (printFile == "")
            //{
            //    {
            //        this.printPreviewDialog1.Document = this.printDocument1;
            //        this.printPreviewDialog1.ShowDialog();
            //    }
            //    Cursor = Cursors.Arrow;
            //    return;
            //}
            //else
            //{
            //    try
            //    {
            //        if (System.IO.File.Exists(Constant.ApplicationDirectory + "\\report\\" + printFile)
            //            || System.IO.File.Exists(Constant.CustomDirectory + "\\report\\" + printFile))
            //        {
            //            FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
            //            rv.ShowDialog();
            //        }
            //        else
            //        {
            //            if (Typely.住院 == BrLy)
            //                //如果没有就 默认统一的检查单
            //                printFile = "Zy_检查申请.rpt";
            //            else
            //                //如果没有就 默认统一的检查单
            //                printFile = "Mz_检查申请.rpt";
            //            FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
            //            rv.ShowDialog();
            //        }
            //    }
            //    catch
            //    {
            //        if (Typely.住院 == BrLy)
            //            //如果没有就 默认统一的检查单
            //            printFile = "Zy_检查申请.rpt";
            //        else
            //            //如果没有就 默认统一的检查单
            //            printFile = "Mz_检查申请.rpt";
            //        FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
            //        rv.ShowDialog();
            //    }
            //}
            Cursor = Cursors.Arrow;
            #endregion

        }

        private void btPrint_cx(DataRowView drv)
        {

            //获得卡号信息
            //Modify By Tany 2015-01-28 把病人信息也放出来，住院的会用到
            string sql = "  select a.kh,b.* from YY_KDJB a right join ZY_INPATIENT b on a.BRXXID=b.PATIENT_ID where b.INPATIENT_ID='" + BinID + "'";
            if (BrLy == Typely.门诊)
                sql = "  select a.kh from YY_KDJB a  where brxxid='" + Dqcf.brxxid + "'";
            DataTable tbPat = FrmMdiMain.Database.GetDataTable(sql);
            string brkh = "";
            if (tbPat.Rows.Count > 0)
                brkh = Convertor.IsNull(tbPat.Rows[0]["KH"], "");
            Cursor = Cursors.WaitCursor;
            DsJyJc.rptAPPDataTable ds = new DsJyJc.rptAPPDataTable();
            DsJyJc.rptAPPDataTable tb = new DsJyJc.rptAPPDataTable();
            //DataColumn dc = new DataColumn();
            //dc.Caption = "JC_NO";
            //dc.ColumnName = "JC_NO";
            //tb.Columns.Add(dc);

            //add by caicheng 2013-05-22
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.AddRange(new DataColumn[]{
                             new DataColumn("orderID",typeof(long)),
                             new DataColumn("orderName",typeof(string)),
                             new DataColumn("yqDoc",typeof(string)),
                             new DataColumn("defaultUsage",typeof(string)),
                             new DataColumn("execDept",typeof(long)),
                             new DataColumn("orderUnit",typeof(string)),
                             new DataColumn("place",typeof(string)),
                             new DataColumn("JcxmId",typeof(long)),
                             new DataColumn("IsUpdate",typeof(long)),
                             new DataColumn("DeptName",typeof(string)),
                             new DataColumn("JCLXNaMe",typeof(string)),
                             new DataColumn("IN_DIAGNOSIS",typeof(string)),
                             new DataColumn("zysx",typeof(string)),
                 new DataColumn("num",typeof(string)),
                 new DataColumn("sqsj",typeof(string)),
                 new DataColumn("jybs",typeof(string))
            });

            Item[] itemgruop = new Item[1];
            for (int x = 0; x < 1; x++)
            {
                itemgruop[x] = new Item();
                itemgruop[x].orderID = long.Parse(drv["HID"].ToString());//医嘱id
                itemgruop[x].orderName = drv["检查项目"].ToString();//医嘱内容
                itemgruop[x].defaultUsage = "";//默认用法
                itemgruop[x].execDept = long.Parse(drv["EXEC_DEPT"].ToString());//执行科室id
                itemgruop[x].orderUnit = drv["dw"].ToString(); //单位
                itemgruop[x].JcxmId = long.Parse(drv["jcxmid"].ToString()); //项目类型 id

                dt.Rows.Add(new object[] {  long.Parse(drv["HID"].ToString()) ,//医嘱id
                                        drv["检查项目"].ToString(),//医嘱内容
                                        drv["下嘱医生"].ToString(),//开单医生
                                        "",//默认用法
                                         drv["EXEC_DEPT"],//执行科室id
                                       drv["dw"].ToString(),//单位
                                        drv["bbmc"].ToString(),//部位
                                        long.Parse(drv["jcxmid"].ToString()),0,//项目类型 id
                                         drv["执行科室"],//检查科室
                                         drv["jclxname"],//检查化验类型名称
                                         drv["IN_DIAGNOSIS"],//检查化验类型名称
                                         drv["zysx"],//检查化验类型名称
                  drv["JSNUM"].ToString(),//数量
                  drv["申请时间"].ToString(),//数量
                   drv["SYMPTOM"].ToString()//简要病史
                });

            }

            //按照执行科室和项目类型分组分别打印 
            DataTable dttemp = dt.Clone();
            for (int j = 0; j <= dt.Rows.Count - 1; j++)
            {
                dttemp.Clear();
                if (dt.Rows[j]["IsUpdate"].ToString() == "1") continue;
                dttemp.Rows.Add(dt.Rows[j].ItemArray);
                dt.Rows[j]["IsUpdate"] = 1;
                for (int z = j + 1; z <= dt.Rows.Count - 1; z++)
                {
                    if (dt.Rows[j]["execDept"].ToString() == dt.Rows[z]["execDept"].ToString() && dt.Rows[j]["JcxmId"].ToString() == dt.Rows[z]["JcxmId"].ToString() && dt.Rows[z]["IsUpdate"].ToString() == "0")
                    {
                        dttemp.Rows.Add(dt.Rows[z].ItemArray);
                        dt.Rows[z]["IsUpdate"] = 1;
                    }
                }
                if (dttemp.Rows.Count == 0) continue;
                #region  打印
                tb.Clear();

                //Modify by jchl 2015-08-05 打印单独医嘱价格
                //List<string> LtPrice = new List<string>();
                //foreach (DataRow row in dttemp.Rows)
                //{
                //    LtPrice.Add(row["orderID"].ToString());
                //}
                //string strPrice = GetPrice(LtPrice);

                string bbmc = "";
                for (int i = 0; i <= dttemp.Rows.Count - 1; i++)
                {
                    DataRow dr = tb.NewRow();
                    for (int h = 1; h < 7; h++)
                    {
                        dr["col" + h.ToString()] = "";
                    }
                    List<string> ltOrid = new List<string>();
                    ltOrid.Add(dttemp.Rows[i]["orderID"].ToString());
                    if (Typely.住院 == BrLy)
                    {
                        dr["binname"] = patientBar1.lblName.Text;
                        dr["sex"] = patientBar1.lblSex.Text;
                        dr["age"] = patientBar1.lblage.Text;
                        dr["yqDoc"] = dttemp.Rows[i]["yqDoc"]; ;//FrmMdiMain.CurrentUser.Name;//Modify by jchl 2016-07-19
                        dr["yqDate"] = dttemp.Rows[i]["sqsj"];//this.lbDateTime.Text;//Modify by jchl
                        dr["deptName"] = FrmMdiMain.CurrentDept.DeptName;
                        dr["wardName"] = FrmMdiMain.CurrentDept.WardName;
                        dr["bedID"] = Convertor.IsNull(patientBar1.lblBedNo.Text, "");

                        dr["symptom"] = dttemp.Rows[i]["jybs"];//richRecord.Text;
                        dr["diagnosis"] = dttemp.Rows[i]["IN_DIAGNOSIS"];
                        dr["place"] = dttemp.Rows[i]["place"];//this.cmbPlace.Text.Trim();
                        dr["itemName"] = dttemp.Rows[i]["orderName"];// chkListBox.CheckedItems;
                        dr["inpatientid"] = "*" + patientBar1.lblInpatientNo.Text + "*";

                        //Modify by jchl 2015-08-05 打印单独医嘱价格
                        dr["price"] = myQuery.GetPrice(long.Parse(dttemp.Rows[i]["orderID"].ToString()), FrmMdiMain.Jgbm);
                        //dr["price"] = strPrice;

                        dr["bz"] = dttemp.Rows[i]["zysx"];
                        dr["yymc"] = (new SystemCfg(2)).Config;

                        dr["lxmc"] = "住院病人" + dttemp.Rows[i]["JCLXNaMe"] + "申请单";
                        dr["col1"] = brkh;
                        //增加价格和数量
                        dr["col2"] = GetPrice(ltOrid);
                        dr["col3"] = dttemp.Rows[i]["num"].ToString();//数量
                        dr["col4"] = dttemp.Rows[i]["deptname"].ToString();//检查科室

                        //Modify By Tany 2015-01-28 增加电话
                        dr["col5"] = tbPat.Columns.Contains("lxrdh") ? Convertor.IsNull(tbPat.Rows[0]["lxrdh"], "") : "";

                        dr["JC_NO"] = patientBar1.lblInpatientNo.Text; //drv["JC_NO"];
                    }
                    else
                    {
                        dr["binname"] = lblxm.Text;
                        dr["sex"] = lblxb.Text;
                        dr["age"] = lblnl.Text;
                        dr["yqDoc"] = dttemp.Rows[i]["yqDoc"]; ;//FrmMdiMain.CurrentUser.Name;//Modify by jchl 2016-07-19
                        dr["yqDate"] = dttemp.Rows[i]["sqsj"];//this.lbDateTime.Text; //Modify by jchl
                        dr["deptName"] = FrmMdiMain.CurrentDept.DeptName;
                        dr["wardName"] = FrmMdiMain.CurrentDept.DeptName;
                        dr["bedID"] = "";
                        //			dr["address"]=dt.Rows[0]["unit_name"];
                        //			dr["tele"]=dt.Rows[0]["unit_tel"];
                        dr["symptom"] = richRecord.Text;
                        dr["diagnosis"] = this.txtDiag.Text.Trim();
                        dr["place"] = dttemp.Rows[i]["place"];//this.cmbPlace.Text.Trim();
                        dr["itemName"] = dttemp.Rows[i]["orderName"];// chkListBox.CheckedItems;
                        dr["inpatientid"] = lblmzh.Text;// 门诊号

                        //Modify by jchl 2015-08-05 打印单独医嘱价格
                        dr["price"] = myQuery.GetPrice(long.Parse(dttemp.Rows[i]["orderID"].ToString()), FrmMdiMain.Jgbm);
                        //dr["price"] = strPrice;

                        dr["bz"] = "";
                        dr["yymc"] = (new SystemCfg(2)).Config;
                        //增加价格和数量
                        dr["col2"] = GetPrice(ltOrid);
                        dr["col3"] = dttemp.Rows[i]["num"].ToString();//数量
                        dr["col1"] = brkh;
                        dr["col4"] = dttemp.Rows[i]["deptname"].ToString();//检查科室
                        //  tb.Rows.Add(dr);

                        dr["lxmc"] = "门诊病人" + dttemp.Rows[i]["JCLXNaMe"] + "申请单";
                    }

                    bbmc = dttemp.Rows[i]["JCLXNaMe"].ToString();


                    tb.Rows.Add(dr);
                }
                if (Typely.住院 == BrLy)
                {
                    printFile = "Zy_检查申请.rpt";
                    printFile = "Zy_" + bbmc + ".rpt";
                }
                else
                {
                    printFile = "Mz_检查申请.rpt";
                    printFile = "Mz_" + bbmc + ".rpt";
                }
                if (printFile == "")
                {
                    {
                        this.printPreviewDialog1.Document = this.printDocument1;
                        this.printPreviewDialog1.ShowDialog();
                    }
                    Cursor = Cursors.Arrow;
                    return;
                }
                else
                {
                    try
                    {
                        if (System.IO.File.Exists(Constant.ApplicationDirectory + "\\report\\" + printFile)
                            || System.IO.File.Exists(Constant.CustomDirectory + "\\report\\" + printFile))
                        {
                            FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
                            rv.ShowDialog();
                        }
                        else
                        {
                            if (Typely.住院 == BrLy)
                                //如果没有就 默认统一的检查单
                                printFile = "Zy_检查申请.rpt";
                            else
                                //如果没有就 默认统一的检查单
                                printFile = "Mz_检查申请.rpt";
                            FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
                            rv.ShowDialog();
                        }
                    }
                    catch
                    {
                        if (Typely.住院 == BrLy)
                            //如果没有就 默认统一的检查单
                            printFile = "Zy_检查申请.rpt";
                        else
                            //如果没有就 默认统一的检查单
                            printFile = "Mz_检查申请.rpt";
                        FrmReportView rv = new FrmReportView(tb, Constant.ApplicationDirectory + "\\report\\" + printFile, null, false);
                        rv.ShowDialog();
                    }
                }
                Cursor = Cursors.Arrow;
                #endregion
            }
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            panel4.Visible = false;
        }


        #region 读XML报告至某控件
        /// <summary>
        ///  读XML报告至某控件
        /// </summary>
        /// <param name="strXML">XML语句</param>
        /// <param name="ctl">承载控件</param>
        public void ReadXMLReport(string strXML, Control ctl)
        {
            int iRows;
            try
            {
                StringReader sr = new StringReader(strXML);
                XmlDataDocument datadoc = new XmlDataDocument();
                //创建该对象为了读取XML
                datadoc.DataSet.ReadXml(sr);
                DataTable tb = (DataTable)datadoc.DataSet.Tables[0];
                if (tb == null) return;
                for (iRows = 0; iRows < tb.Rows.Count; iRows++)
                {
                    Font ft;
                    if (Convert.ToInt32(tb.Rows[iRows]["iBold"]) == 1)		//是否粗体
                    {
                        ft = new Font("宋体", float.Parse(tb.Rows[iRows]["iSIZE"].ToString()), FontStyle.Bold);
                    }
                    else
                    {
                        ft = new Font("宋体", float.Parse(tb.Rows[iRows]["iSIZE"].ToString()));
                    }
                    //Label
                    if (Convert.ToString(tb.Rows[iRows]["sTYPE"]).Trim() == "XT_LABEL")
                    {
                        Label lbl = new Label();
                        lbl.Location = new Point(Convert.ToInt32(tb.Rows[iRows]["iPTX"]), Convert.ToInt32(tb.Rows[iRows]["iPTY"]));
                        lbl.Width = Convert.ToInt32(tb.Rows[iRows]["iWIDTH"]);
                        lbl.Height = Convert.ToInt32(tb.Rows[iRows]["iHEIGHT"]);
                        lbl.Text = Convert.ToString(tb.Rows[iRows]["sTEXT"]);
                        lbl.Font = ft;
                        ctl.Controls.Add(lbl);
                    }
                    //TextBox
                    else if (Convert.ToString(tb.Rows[iRows]["sTYPE"]).Trim() == "XT_TEXT")
                    {
                        TextBox txt = new TextBox();
                        txt.Location = new Point(Convert.ToInt32(tb.Rows[iRows]["iPTX"]), Convert.ToInt32(tb.Rows[iRows]["iPTY"]));
                        txt.Multiline = true;
                        txt.Width = Convert.ToInt32(tb.Rows[iRows]["iWIDTH"]);
                        txt.Height = Convert.ToInt32(tb.Rows[iRows]["iHEIGHT"]);
                        txt.Text = Convert.ToString(tb.Rows[iRows]["sTEXT"]);
                        txt.Font = ft;
                        ctl.Controls.Add(txt);
                    }
                    //DateTimePicker
                    else if (Convert.ToString(tb.Rows[iRows]["sTYPE"]).Trim() == "XT_DATETIME")
                    {

                        DateTimePicker dtp = new DateTimePicker();
                        dtp.Location = new Point(Convert.ToInt32(tb.Rows[iRows]["iPTX"]), Convert.ToInt32(tb.Rows[iRows]["iPTY"]));
                        dtp.Width = Convert.ToInt32(tb.Rows[iRows]["iWIDTH"]);
                        dtp.Height = Convert.ToInt32(tb.Rows[iRows]["iHEIGHT"]);
                        dtp.Value = Convert.ToDateTime(tb.Rows[iRows]["sTEXT"]);
                        dtp.Font = ft;
                        ctl.Controls.Add(dtp);

                    }
                    //CheckBox
                    else if (Convert.ToString(tb.Rows[iRows]["sTYPE"]).Trim() == "XT_CHECK")
                    {

                        CheckBox chk = new CheckBox();
                        chk.Location = new Point(Convert.ToInt32(tb.Rows[iRows]["iPTX"]), Convert.ToInt32(tb.Rows[iRows]["iPTY"]));
                        chk.Width = Convert.ToInt32(tb.Rows[iRows]["iWIDTH"]);
                        chk.Height = Convert.ToInt32(tb.Rows[iRows]["iHEIGHT"]);
                        chk.Text = Convert.ToString(tb.Rows[iRows]["sTEXT"]);
                        chk.Checked = Convert.ToInt32(tb.Rows[iRows]["iVALUE"]) == 1 ? true : false;
                        chk.Font = ft;
                        ctl.Controls.Add(chk);
                    }
                    //RadioButton
                    else if (Convert.ToString(tb.Rows[iRows]["sTYPE"]).Trim() == "XT_RADIO")
                    {

                        RadioButton rb = new RadioButton();
                        rb.Location = new Point(Convert.ToInt32(tb.Rows[iRows]["iPTX"]), Convert.ToInt32(tb.Rows[iRows]["iPTY"]));
                        rb.Width = Convert.ToInt32(tb.Rows[iRows]["iWIDTH"]);
                        rb.Height = Convert.ToInt32(tb.Rows[iRows]["iHEIGHT"]);
                        rb.Text = Convert.ToString(tb.Rows[iRows]["sTEXT"]);
                        rb.Checked = Convert.ToInt32(tb.Rows[iRows]["iVALUE"]) == 1 ? true : false;
                        rb.Font = ft;
                        ctl.Controls.Add(rb);
                    }

                }
                //释放对象
                tb = null;
                datadoc = null;
                sr = null;
            }
            catch (System.Exception err)
            {
                throw new Exception("读取XML报告出错\n" + err.Message);
            }

        }
        #endregion
        #endregion

        #region 清除DataGrid中的TextBox
        private void DelDataGridTextBox(DataGrid dg)
        {
            System.Windows.Forms.DataGridTextBoxColumn dgtb = null;
            for (int i = 0; i < dg.TableStyles[0].GridColumnStyles.Count; i++)
            {
                dgtb = (DataGridTextBoxColumn)dg.TableStyles[0].GridColumnStyles[i];
                dgtb.TextBox.Parent.Controls.Remove(dgtb.TextBox);
            }
        }
        #endregion

        #endregion

        #region 退出窗体
        private void button3_Click(object sender, System.EventArgs e)
        {
            //this.Dispose();
            this.Close();
        }
        #endregion

        private void btDelTC_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbTc.SelectedValue) == -1)
                return;

            if (MessageBox.Show("是否删除该套餐？\n\n套餐名称：" + cmbTc.Text.Trim(), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            string ssql = "select * from jc_jchytc_t where id=" + Convert.ToInt32(cmbTc.SelectedValue);
            DataTable tb = FrmMdiMain.Database.GetDataTable(ssql);

            if (tb.Rows.Count > 0)
            {
                if (!FrmMdiMain.CurrentUser.IsAdministrator && Convert.ToInt32(tb.Rows[0]["tclx"]) == 0)
                {
                    MessageBox.Show("你没有权限删除院级模板！");
                    return;
                }
            }

            string[] sql = new string[2];

            sql[0] = "delete from jc_jchytc_mx where tcid=" + Convert.ToInt32(cmbTc.SelectedValue);
            sql[1] = "delete from jc_jchytc_t where id=" + Convert.ToInt32(cmbTc.SelectedValue);

            FrmMdiMain.Database.DoCommand(null, null, null, sql);

            MessageBox.Show("删除成功！");

            SystemLog _systemLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "删除检查套餐", "删除名为 " + cmbTc.Text.Trim() + " 的套餐信息", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "主机名：" + System.Environment.MachineName, 6);
            _systemLog.Save();
            _systemLog = null;

            cmbClass_SelectedIndexChanged(null, null);
        }

        private void btSaveTC_Click(object sender, EventArgs e)
        {
            // if (chkListBox.CheckedItems.Count == 0)
            //    return;
            // DataRow[] r = ((DataTable)this.dataGridviewEx1.DataSource).Select("check=1 and fid=0");
            if (this.listView1.Items.Count == 0)
                return;
            if (MessageBox.Show("是否将选中的项目保存为套餐？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            FrmModelSave frmModelsave = new FrmModelSave("套餐保存");
            frmModelsave.ShowDialog();

            if (frmModelsave.DialogResult == DialogResult.Cancel)
                return;

            string _tcname = frmModelsave.ModelName;
            int _tclx = frmModelsave.model_type;
            string sql = "";
            int id = 0;
            int syid = 0;

            if (_tclx == 1)
                syid = FrmMdiMain.CurrentDept.DeptId;
            else if (_tclx == 2)
                syid = FrmMdiMain.CurrentUser.EmployeeId;

            FrmMdiMain.Database.BeginTransaction();
            try
            {
                sql = "insert into jc_jchytc_t(NAME, CLASS_ID, JGBM, TCLX, SYID) values ('" + _tcname + "'," + Convert.ToInt32(((ListItem)cmbClass.SelectedItem).ID.ToString()) + "," + FrmMdiMain.Jgbm + "," + _tclx + "," + syid + ")";
                FrmMdiMain.Database.DoCommand(sql);

                sql = "Select IDENT_CURRENT('jc_jchytc_t')";
                id = Convert.ToInt32(Convertor.IsNull(FrmMdiMain.Database.GetDataResult(sql), "0"));
                if (id <= 0)
                    throw new Exception("插入套餐头表出错！");

                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    sql = "insert into jc_jchytc_mx(TCID, XMID) values (" + id + "," + Convert.ToInt32(this.listView1.Items[i].SubItems[9].Text) + ")";
                    FrmMdiMain.Database.DoCommand(sql);
                }

                FrmMdiMain.Database.CommitTransaction();
                MessageBox.Show("保存成功！");

                cmbClass_SelectedIndexChanged(null, null);
            }
            catch (Exception err)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show(err.Message);
            }
        }

        private void cmbTc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbTc.SelectedValue) == -1)
            {
                cmbClass_SelectedIndexChanged(null, null);
                this.button4.Visible = false;
                this.button6.Visible = false;
            }
            else
            {
                this.button4.Visible = true;
                this.button6.Visible = true;
                string sql = "SELECT DISTINCT 0 [check],  0 fid,AA.ORDER_ID, AA.ORDER_NAME, AA.DEFAULT_DEPT, AA.ORDER_UNIT,AA.DEFAULT_USAGE,LOWER(AA.PY_CODE) PY_CODE, AA.BOOKING_BIT, " +
                        "  (select top 1 NAME from JC_DEPT_PROPERTY where JC_DEPT_PROPERTY.DEPT_ID=AA.DEFAULT_DEPT)  as DeptName ,AA.JCLXID, " +
                        "   (select top 1 name from jc_jcclassdiction where jc_jcclassdiction.ID=AA.JCLXID) as JCLXNaMe  " +
                        " ,(select top 1 TCID from JC_HOI_HDI where HOITEM_ID=AA.ORDER_ID) tcid" +
                        " FROM " +
                        " ( " +
                        "     SELECT A.ORDER_ID, 0 BOOKING_BIT, CASE WHEN (BZ IS NULL OR BZ='') THEN ORDER_NAME ELSE (ORDER_NAME + '【'+ BZ + '】') END ORDER_NAME, " +
                        "     D.EXEC_DEPT AS DEFAULT_DEPT,b.JCLXID , ORDER_UNIT,A.PY_CODE,DEFAULT_USAGE " +
                        "     FROM (SELECT * " +
                        "     FROM JC_HOITEMDICTION " +
                        "     WHERE DELETE_BIT = 0 AND ORDER_TYPE = 5) A " +
                        "     INNER JOIN " +
                        "     JC_JC_ITEM B ON A.ORDER_ID = B.YZID ";
                if (cmbClass.Text.Trim() != "全部")
                    sql += " AND B.JCLXID= " + Convert.ToInt32(((ListItem)cmbClass.SelectedItem).ID.ToString());//cmbClass.SelectedValue
                sql += "     INNER JOIN " +
                "     JC_JCHYTC_MX F ON A.ORDER_ID = F.XMID " +
                "     INNER JOIN " +
                "     JC_JCHYTC_T E ON F.TCID = E.ID AND E.ID=" + Convert.ToInt32(cmbTc.SelectedValue) +
                "     INNER JOIN " +
                "     JC_HOI_DEPT D ON A.ORDER_ID = D.ORDER_ID  ";
                if (cmbDept.Text.Trim() != "全部")
                    sql += " AND D.EXEC_DEPT= " + Convert.ToInt32(((ListItem)cmbDept.SelectedItem).ID.ToString());
                sql += " ) AA " +
                  "  union all " +

                  " select '0' [check],ORDER_ID fid,-id ,ORDER_POSITION,null,null,null,null,null,null,null,null,null  from JC_HOITEMDICTIONCHILD      ";
                itemTb = FrmMdiMain.Database.GetDataTable(sql);
                //Modify by zouchihua 增加了新的绑定方式
                DataTable temp = itemTb.Copy();
                try
                {
                    this.dataGridviewEx1.AutoGenerateColumns = false;
                    //this.dataGridviewEx1.DataSource = temp;
                    this.dataGridviewEx1.EnableHeadersVisualStyles = false;
                    Ts_Clinicalpathway_Factory.PublicFunction.GruopShow(temp, "fid=0", "order_id", this.dataGridviewEx1, "fid", this.dataGridviewEx1.groupColumIndex);
                    Collapse(true);
                    for (int x = 0; x < temp.Rows.Count; x++)
                    {
                        if (temp.Rows[x]["fid"].ToString().Trim() == "0")
                        {
                            //模拟鼠标点上   武汉中心医院，选择套餐check为false
                            //this.dataGridviewEx1_CellContentClick(null, new DataGridViewCellEventArgs(0, x));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                chkListBox.Items.Clear();
                //   Item jcItem = null;
                for (int i = 0; i <= itemTb.Rows.Count - 1; i++)
                {
                    //jcItem = new Item();
                    //jcItem.orderID = Convert.ToInt32(itemTb.Rows[i]["order_id"]);
                    //jcItem.orderName = itemTb.Rows[i]["order_name"].ToString().Trim();
                    //jcItem.orderUnit = itemTb.Rows[i]["order_unit"].ToString().Trim();
                    //jcItem.execDept = Convert.ToInt64(Convertor.IsNull(itemTb.Rows[i]["default_dept"], "0"));
                    //jcItem.defaultUsage = itemTb.Rows[i]["default_usage"].ToString().Trim();
                    //jcItem.pym = itemTb.Rows[i]["py_code"].ToString();
                    //jcItem.booking = Convert.ToInt16(itemTb.Rows[i]["booking_bit"]);
                    //chkListBox.Items.Add(jcItem);
                }
                chkListBox.BorderStyle = BorderStyle.None;
                //lbPrice.Text = "0.00 元";

                //for (int i = 0; i <= chkListBox.Items.Count - 1; i++)
                //{
                //    chkListBox.SetItemChecked(i, true);
                //}
                //chkListBox_SelectedIndexChanged(null, null);

            }

        }

        List<Ts_zyys_jcsq.FrmJCBWXX.Item> bwitem = new List<FrmJCBWXX.Item>();

        /// <summary>
        /// Modify By lwl 2011-09-15
        /// 增加检查项目选中后供部位选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                //选中之前
                if (e.CurrentValue == CheckState.Unchecked)
                {
                    DataTable dt = myQuery.GetCheckSite(((Item)chkListBox.SelectedItem).orderID.ToString());
                    if (dt.Rows.Count > 1)
                    {
                        FrmJCBWXX frmjcbwxx = null;
                        if (chkMore.Checked == true)
                        {
                            frmjcbwxx = new FrmJCBWXX(dt, bwitem, ((Item)chkListBox.SelectedItem).orderID.ToString());
                        }
                        else
                        {
                            bwitem = new List<FrmJCBWXX.Item>();
                            frmjcbwxx = new FrmJCBWXX(dt, bwitem, ((Item)chkListBox.SelectedItem).orderID.ToString());
                        }
                        frmjcbwxx.ShowDialog();
                        if (frmjcbwxx.DialogResult == DialogResult.OK)
                        {
                            bwitem = frmjcbwxx.GetPositionItem();
                            if (bwitem.Count > 0)
                            {

                            }
                        }
                        else
                        {
                            e.NewValue = CheckState.Unchecked;
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < bwitem.Count; i++)
                    {
                        Ts_zyys_jcsq.FrmJCBWXX.Item modal = bwitem.Find(delegate(Ts_zyys_jcsq.FrmJCBWXX.Item callmodal)
                       {
                           return ((Item)chkListBox.SelectedItem).orderID == callmodal.orderID;
                       });
                        if (modal != null)
                        {
                            bwitem.Remove(modal);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void dataGridviewEx1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridviewEx1.DataSource;
            if (tb == null) return;
            if (tb.Rows.Count == 0)
                return;
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                e.CellStyle.BackColor = this.tabPage1.BackColor;
            }
            //改变颜色
            if ((e.RowIndex >= 0 && e.ColumnIndex >= 0) && tb.Rows[e.RowIndex]["fid"].ToString().Trim() != "0")
            {
                e.CellStyle.BackColor = Color.LightYellow;
            }
        }

        private void dataGridviewEx1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridviewEx1.DataSource;
            if (tb.Rows.Count == 0)
                return;
            if (e.ColumnIndex == 0)
            {
                //如果是没有选择
                if (tb.Rows[e.RowIndex][e.ColumnIndex].ToString() == "0")
                {
                    //如果是项目，不是部位
                    if (tb.Rows[e.RowIndex]["fid"].ToString().Trim() == "0")
                    {
                        //那么把该项选上，同时也要把部位选上。如果有多个默认选择第一个
                        tb.Rows[e.RowIndex][e.ColumnIndex] = 1;
                        for (int j = e.RowIndex; j < tb.Rows.Count; j++)
                        {
                            if (tb.Rows[j]["fid"].ToString().Trim() != "0")//那么肯定就是上一个的部位
                            {
                                tb.Rows[j][0] = 1;
                                break;
                            }
                            if (j == e.RowIndex + 1)
                                break;
                        }
                    }
                    else
                    {
                        //如果选择的是部位不做认为操作
                        tb.Rows[e.RowIndex][0] = 1;
                        for (int x = 0; x < tb.Rows.Count; x++)
                        {
                            if (tb.Rows[x]["order_id"].ToString() == tb.Rows[e.RowIndex]["fid"].ToString())
                            {
                                tb.Rows[x][0] = 1;//把相应的父级选上

                            }
                            if (x != e.RowIndex && tb.Rows[x]["fid"].ToString() == tb.Rows[e.RowIndex]["fid"].ToString())
                            {
                                tb.Rows[x][0] = 0;//同级的全部不选上
                            }
                        }

                    }
                }
                else
                {
                    //选择了 如果是项目，不是部位
                    if (tb.Rows[e.RowIndex]["fid"].ToString().Trim() == "0")
                    {
                        //那么把该项取消选择，同时也要把部位全部取消 
                        tb.Rows[e.RowIndex][e.ColumnIndex] = 0;
                        for (int j = e.RowIndex; j < tb.Rows.Count; j++)
                        {
                            if (tb.Rows[j]["fid"].ToString().Trim() != "0")//那么肯定就是上一个的部位
                            {
                                tb.Rows[j][e.ColumnIndex] = 0;
                            }

                        }
                    }
                    else
                    {
                        //是部位，如果有只有一个就把，医嘱一起取消
                        DataRow[] r = tb.Select("fid=" + tb.Rows[e.RowIndex]["fid"].ToString());
                        if (r.Length > 0)
                        {
                            tb.Rows[e.RowIndex][e.ColumnIndex] = 0;
                            for (int ii = 0; ii < tb.Rows.Count; ii++)
                            {
                                if (tb.Rows[e.RowIndex]["fid"].ToString().Trim() == tb.Rows[ii]["fid"].ToString()
                                    || tb.Rows[e.RowIndex]["fid"].ToString().Trim() == tb.Rows[ii]["order_id"].ToString()
                                    )
                                {
                                    tb.Rows[ii][e.ColumnIndex] = 0;

                                }
                            }
                        }
                        else
                        {
                            //int tempcount = 0;
                            tb.Rows[e.RowIndex][e.ColumnIndex] = 0;
                            for (int ii = 0; ii < tb.Rows.Count; ii++)
                            {
                                if (ii != e.RowIndex && tb.Rows[e.RowIndex]["fid"].ToString().Trim() == tb.Rows[ii]["fid"].ToString()
                                    && tb.Rows[e.RowIndex]["order_id"].ToString().Trim() != tb.Rows[ii]["order_id"].ToString()
                                    )
                                {
                                    tb.Rows[ii][e.ColumnIndex] = 1;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (sender != null)
            {
                //button4_Click(null, null);
                buttonJC_Click(null, null);
            }
        }

        private void dataGridviewEx1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Dqh = Dqh + 1;
                DataTable tb = (DataTable)this.dataGridviewEx1.DataSource;
                DataRow[] r = tb.Select("Py_code='" + txtDM.Text.Trim() + "'");
                for (int i = Dqh; i < tb.Rows.Count; i++)
                {
                    if (tb.Rows[i]["Py_code"].ToString().IndexOf(txtDM.Text.Trim().ToLower(), 0) == 0)
                    {
                        this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[i].Cells[1];
                        Dqh = i;
                        break;
                    }
                }
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Dqh = Dqh - 1;
                DataTable tb = (DataTable)this.dataGridviewEx1.DataSource;
                DataRow[] r = tb.Select("Py_code='" + txtDM.Text.Trim() + "'");
                for (int i = Dqh; i >= 0; i--)
                {
                    if (tb.Rows[i]["Py_code"].ToString().IndexOf(txtDM.Text.Trim().ToLower(), 0) == 0)
                    {
                        this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[i].Cells[1];
                        Dqh = i;
                        break;
                    }
                }
            }
            catch { }
        }

        private void FrmJCSQ_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtDM.Focused)
            {
                if ((Keys)e.KeyCode == Keys.F3)
                {
                    button5_Click(null, null);
                }
                if ((Keys)e.KeyCode == Keys.F4)
                {
                    button7_Click(null, null);
                }
                if ((Keys)e.KeyCode == Keys.Up)
                {
                    try
                    {
                        this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[this.dataGridviewEx1.CurrentRow.Index - 1].Cells[1];
                    }
                    catch
                    {
                        if (this.dataGridviewEx1.CurrentRow.Index != 0)
                            Updown(true, this.dataGridviewEx1.CurrentRow.Index);
                    }
                }
                if ((Keys)e.KeyCode == Keys.Down)
                {
                    try
                    {
                        this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[this.dataGridviewEx1.CurrentRow.Index + 1].Cells[1];
                    }
                    catch (Exception ex)
                    {

                        Updown(false, this.dataGridviewEx1.CurrentRow.Index);
                    }
                }
                if ((Keys)e.KeyCode == Keys.Enter)
                {
                    //模拟鼠标点上
                    this.dataGridviewEx1_CellContentClick(sender, new DataGridViewCellEventArgs(0, this.dataGridviewEx1.CurrentCell.RowIndex));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Up"></param>
        private void Updown(bool Up, int i)
        {
            int j = 0;
            try
            {
                if (Up)
                {
                    i--;
                    j = i;
                    this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[j].Cells[1];

                }
                else
                {
                    i++;
                    j = i;
                    this.dataGridviewEx1.CurrentCell = this.dataGridviewEx1.Rows[j].Cells[1];

                }
                return;
            }
            catch (Exception ex)
            {
                if (Up || this.dataGridviewEx1.CurrentRow.Index != this.dataGridviewEx1.Rows.Count - 1)
                    Updown(Up, j);
            }
        }
        private void Qbx()
        {
            DataTable tb = (DataTable)this.dataGridviewEx1.DataSource;

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                tb.Rows[i]["check"] = 0;
            }
        }
        private void ChangeAltercolr()
        {
            try
            {
                string ssql = "select '' 名称,0 医嘱项目id,0 单价,0 数量,'' 单位,0 金额 ,0 套餐id,'' 频次,'' execDept,'' JcxmId, '' 项目分类 where 1=2";
                DataTable tb = FrmMdiMain.Database.GetDataTable(ssql);
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    DataRow r = tb.NewRow();
                    r["名称"] = this.listView1.Items[i].SubItems[0].Text;
                    r["数量"] = this.listView1.Items[i].SubItems[2].Text;
                    r["医嘱项目id"] = this.listView1.Items[i].SubItems[9].Text;
                    r["金额"] = myQuery.GetPrice(long.Parse(this.listView1.Items[i].Tag.ToString()), FrmMdiMain.Jgbm) * int.Parse(this.listView1.Items[i].SubItems[2].Text.ToString());
                    r["单位"] = this.listView1.Items[i].SubItems[3].Text;
                    r["单价"] = myQuery.GetPrice(long.Parse(this.listView1.Items[i].Tag.ToString()), FrmMdiMain.Jgbm);
                    r["频次"] = "";
                    r["套餐id"] = this.listView1.Items[i].SubItems[12].Text;
                    r["execDept"] = this.listView1.Items[i].SubItems[11].Text;
                    r["JcxmId"] = this.listView1.Items[i].SubItems[10].Text;
                    r["项目分类"] = this.listView1.Items[i].SubItems[8].Text;
                    tb.Rows.Add(r);
                }
                string[] GroupbyField1 = { "execDept", "JcxmId", "项目分类" };
                string[] ComputeField1 = { };
                string[] CField1 = { };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                DataTable tbcf1 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
                ListViewGroup[] group = new ListViewGroup[tbcf1.Rows.Count];
                int cout = 0;
                for (int i = 0; i < tbcf1.Rows.Count; i++)
                {
                    group[i] = new ListViewGroup(tbcf1.Rows[i]["项目分类"].ToString());

                    this.listView1.Groups.Add(group[i]);
                    DataRow[] _row = tb.Select("execDept='" + tbcf1.Rows[i]["execDept"] + "' and JcxmId='" + tbcf1.Rows[i]["JcxmId"] + "'");
                    for (int j = 0; j < _row.Length; j++)
                    {
                        this.listView1.Items[cout].Group = group[i];
                        cout++;
                    }

                }
            }
            catch (Exception EX) { MessageBox.Show(EX.Message); }

            // AliceBlue
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    this.listView1.Items[i].BackColor = Color.AliceBlue;
                    //this.listView1.Items[i].ForeColor = Color.Blue;
                }
                else
                {
                    this.listView1.Items[i].BackColor = Color.LightGreen;

                    //this.listView1.Items[i].ForeColor = Color.Black;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridviewEx1.DataSource;

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["fid"].ToString().Trim() == "0" && tb.Rows[i]["check"].ToString() == "1")
                {
                    string bw = "";
                    for (int j = i + 1; j < tb.Rows.Count; j++)
                    {
                        if (tb.Rows[j]["fid"].ToString().Trim() == tb.Rows[i]["order_id"].ToString().Trim() && tb.Rows[j]["check"].ToString() == "1")
                        {
                            bw += tb.Rows[j]["ORDER_NAME"].ToString();
                        }
                    }
                    if (!Iscx(tb.Rows[i]["order_id"].ToString().Trim()))
                    {
                        listView1.Groups.Clear();

                        //Modify by jchl
                        decimal sprc = GetorderPrice(long.Parse(tb.Rows[i]["ORDER_ID"].ToString())); ;//单价
                        decimal aprc = GetorderPrice(long.Parse(tb.Rows[i]["ORDER_ID"].ToString())) * long.Parse("1"); //金额

                        ListViewItem li = new ListViewItem(new string[] 
                        { 
                            tb.Rows[i]["ORDER_NAME"].ToString(), 
                            bw,
                            "1",
                            tb.Rows[i]["ORDER_UNIT"].ToString(),
                            sprc.ToString(),//单价
                            aprc.ToString(),//金额
                            tb.Rows[i]["DeptName"].ToString(),
                            tb.Rows[i]["DEFAULT_USAGE"].ToString(),
                            tb.Rows[i]["JCLXNaMe"].ToString(), 
                            tb.Rows[i]["order_id"].ToString(),
                            tb.Rows[i]["JCLXID"].ToString(),
                            tb.Rows[i]["DEFAULT_DEPT"].ToString(),
                            tb.Rows[i]["tcid"].ToString()
                            ,txtDiag.Text   //临床诊断
                            ,richTextBox1.Text  //注意事项
                            ,txtJcResult.Text.Trim()
                        });
                        li.Tag = tb.Rows[i]["order_id"].ToString();
                        listView1.Items.AddRange(new ListViewItem[] { li });
                        SetListViewSpacing(this.listView1, 0, 4000);
                        //this.listView1.Items[listView1.Items.Count - 1].Bounds.Height = 30;
                    }
                }
                // tb.Rows[i]["check"] = 0; 暂时屏蔽
            }
            // this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //按照执行科室排序
            #region
            ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            // 检查点击的列是不是现在的排序列.
            if (6 == lvwColumnSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // 设置排序列，默认为正向排序
                lvwColumnSorter.SortColumn = 6;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            // 用新的排序方法对ListView排序
            this.listView1.Sort();
            #endregion
            this.lbPrice.Text = Getprice() + " 元";
            ChangeAltercolr();
        }

        /// <summary>
        /// Add by 2017-05-16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonJC_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridviewEx1.DataSource;

            
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["fid"].ToString().Trim() == "0" && tb.Rows[i]["check"].ToString() == "1")
                {
                    //MessageBox.Show(tb.Rows[i]["ORDER_NAME"].ToString());
                    string bw = "";
                    string bw_code = "";
                    //DataTable dtcsk = new DataTable();
                    //string sql = ("select place,place_code  from  jc_csk   where order_id='" + tb.Rows[i]["order_id"].ToString().Trim() + "'");
                    //dtcsk = FrmMdiMain.Database.GetDataTable(sql);
                    //if (dtcsk.Rows.Count > 0)
                    //{
                    //    bw = dtcsk.Rows[0]["place"].ToString().Trim();
                    //}
                    for (int j = i + 1; j < tb.Rows.Count; j++)
                    {
                        if (tb.Rows[j]["fid"].ToString().Trim() == tb.Rows[i]["order_id"].ToString().Trim() && tb.Rows[j]["check"].ToString() == "1")
                        {
                            bw += tb.Rows[j]["ORDER_NAME"].ToString();
                            //bw_code += tb.Rows[j]["DEFAULT_USAGE"].ToString();
                        }
                    }
                    if (!Iscx(tb.Rows[i]["order_id"].ToString().Trim()))
                    {
                        listView1.Groups.Clear();

                        //Modify by jchl
                        decimal sprc = GetorderPrice(long.Parse(tb.Rows[i]["ORDER_ID"].ToString())); ;//单价
                        decimal aprc = GetorderPrice(long.Parse(tb.Rows[i]["ORDER_ID"].ToString())) * long.Parse("1"); //金额

                        ListViewItem li = new ListViewItem(new string[] 
                        { 
                            tb.Rows[i]["ORDER_NAME"].ToString(), 
                            bw,
                            "1",
                            tb.Rows[i]["ORDER_UNIT"].ToString(),
                            sprc.ToString(),//单价
                            aprc.ToString(),//金额
                            tb.Rows[i]["DeptName"].ToString(),
                            tb.Rows[i]["DEFAULT_USAGE"].ToString(),
                            tb.Rows[i]["JCLXNaMe"].ToString(), 
                            tb.Rows[i]["order_id"].ToString(),
                            tb.Rows[i]["JCLXID"].ToString(),
                            tb.Rows[i]["DEFAULT_DEPT"].ToString(),
                            tb.Rows[i]["tcid"].ToString()
                            ,txtDiag.Text   //临床诊断
                            ,richTextBox1.Text  //注意事项
                            ,txtJcResult.Text.Trim()
                            ,bw_code
                        });
                        li.Tag = tb.Rows[i]["order_id"].ToString();
                        listView1.Items.AddRange(new ListViewItem[] { li });
                        SetListViewSpacing(this.listView1, 0, 4000);
                        //this.listView1.Items[listView1.Items.Count - 1].Bounds.Height = 30;
                    }
                }
                // tb.Rows[i]["check"] = 0; 暂时屏蔽
            }
            // this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //按照执行科室排序
            #region
            ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            // 检查点击的列是不是现在的排序列.
            if (6 == lvwColumnSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // 设置排序列，默认为正向排序
                lvwColumnSorter.SortColumn = 6;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            // 用新的排序方法对ListView排序
            this.listView1.Sort();
            #endregion
            this.lbPrice.Text = Getprice() + " 元";
            ChangeAltercolr();
        }

        private string Getprice()
        {
            decimal zj = 0;
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                zj += myQuery.GetPrice(long.Parse(this.listView1.Items[i].Tag.ToString()), FrmMdiMain.Jgbm) * int.Parse(this.listView1.Items[i].SubItems[2].Text.ToString());
            }
            return zj.ToString();
        }

        private string GetPrice(List<string> orderId)
        {
            decimal zj = 0;
            for (int i = 0; i <= orderId.Count - 1; i++)
            {
                zj += myQuery.GetPrice(long.Parse(orderId[i]), FrmMdiMain.Jgbm);
            }
            return zj.ToString();
        }

        private bool Iscx(string order_id)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                if (this.listView1.Items[i].Tag.ToString().Trim() == order_id)
                {
                    return true;
                }
            }
            return false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int count = this.listView1.SelectedItems.Count;
            int j = 0;
            for (int i = 0; i < count; i++)
            {
                this.listView1.Items.Remove(this.listView1.SelectedItems[i - j]);
                j++;
            }
            this.lbPrice.Text = Getprice() + " 元";
            Qbx();
            ChangeAltercolr();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView1.SelectedItems.Count; i++)
            {
                this.listView1.SelectedItems[i].SubItems[1].Text = this.cmbPlace.Text;
            }
            //this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(richRecord.Text))
                {
                    MessageBox.Show("请填写简要病史及检查的内容");
                }
                else
                {
                    FrmBmsave fb = new FrmBmsave();
                    fb.Hylx = int.Parse(((ListItem)cmbClass.Items[this.cmbClass.SelectedIndex]).ID);
                    fb.nr = richRecord.Text;
                    fb.ShowDialog();
                    //ts_mzys_yjsqd.InstanceForm.BDatabase = FrmMdiMain.Database;
                    //Name name = new Name();
                    //if (!string.IsNullOrEmpty(richRecord.Text))
                    //{
                    //    name.ContextValue = richRecord.Text;
                    //}
                    //name.UserID = Convert.ToString(FrmMdiMain.CurrentUser.UserID);
                    //name.ksdm = Convert.ToInt32(cmbDept.SelectedValue);
                    //name.Show();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("对不起，只能保存300个汉字，请您修改后重新保存！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetTemplete_Click(object sender, EventArgs e)
        {
            FrmJybsSz frm = new FrmJybsSz();

            frm.Hylx = int.Parse(((ListItem)cmbClass.Items[this.cmbClass.SelectedIndex]).ID);
            frm.ShowDialog();
            if (frm.context.Trim() != "")
            {
                if (this.richRecord.Text.Trim() != "")
                    this.richRecord.Text += "\r\n" + frm.context;
                else
                    this.richRecord.Text += frm.context;
            }
            //ts_mzys_yjsqd.InstanceForm.BDatabase = FrmMdiMain.Database;
            //Muban muban = new Muban(this);
            //muban.ksdm = Convert.ToInt32(cmbDept.SelectedValue);
            //muban.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                this.cmbPlace.DataSource = null;
                this.cmbPlace.Items.Clear();
                this.cmbPlace.DisplayMember = "ORDER_POSITION";

                //Modify by jchl
                //this.cmbPlace.ValueMember = "ORDER_ID";
                this.cmbPlace.ValueMember = "ORDER_POSITION";

                string sql = "  select ORDER_ID,ORDER_POSITION from JC_HOITEMDICTIONCHILD  where  order_id=" + this.listView1.FocusedItem.SubItems[9].Text;
                DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
                if (tb.Rows.Count > 0)
                    this.cmbPlace.DataSource = tb;
                else
                    this.cmbPlace.DataSource = null;
            }
            catch
            {

            }

            //try//add  by  chenl 2017-05-12
            //{
            //    this.cmbPlace.DataSource = null;
            //    this.cmbPlace.Items.Clear();
            //    this.cmbPlace.DisplayMember = "TCMX_NAME";

            //    //Modify by jchl
            //    //this.cmbPlace.ValueMember = "ORDER_ID";
            //    this.cmbPlace.ValueMember = "TCMX_CODE";

            //    string sql = "  select TCMX_CODE,TCMX_NAME from JCBW  where  TC_CODE=" + this.cmbbw.SelectedValue.ToString();
            //    DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
            //    if (tb.Rows.Count > 0)
            //        this.cmbPlace.DataSource = tb;
            //    else
            //        this.cmbPlace.DataSource = null;
            //}
            //catch
            //{

            //}
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            //this.listView1.LabelEdit = true;

        }
        string value = "";
        ComboBox comb = new ComboBox();
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //this.listView1.Refresh();
            value = "";
            ListViewHitTestInfo info = this.listView1.HitTest(e.Location);
            comb.Visible = false;
            if (info.Item != null && info.SubItem != null)
            {
                int subItemIndex = info.Item.SubItems.IndexOf(info.SubItem);
                //if (subItemIndex == 0)
                if (subItemIndex == 2)//modify by jchl （数量）
                {
                    if (!Xg && BrLy == Typely.住院)
                    {
                        TextBox tb = new TextBox();
                        tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
                        tb.LostFocus += new EventHandler(tb_LostFocus);
                        tb.Width = this.listView1.Columns[2].Width;
                        tb.Height = this.listView1.FocusedItem.Bounds.Height - 5;
                        tb.BorderStyle = BorderStyle.None;
                        this.listView1.Controls.Add(tb);
                        //Modify by jchl
                        //tb.Text = this.listView1.FocusedItem.Text;
                        tb.Text = info.Item.SubItems[subItemIndex].Text;
                        tb.Location = e.Location;
                        //tb.Location = new Point((listView1.Columns[0].Width + listView1.Columns[1].Width), this.listView1.FocusedItem.Bounds.Location.Y);
                        tb.Focus();
                    }
                }
                else
                    //if (subItemIndex == 3)
                    if (subItemIndex == 1)//modify by jchl （部位）
                    {
                        try
                        {
                            comb.Text = "";
                            comb.Tag = "";
                            comb.Name = "Listcomb";
                            comb.Font = new Font("宋体", 10);
                            comb.ForeColor = Color.Blue;
                            // comb.FlatStyle = FlatStyle.Popup;
                            comb.Width = this.listView1.Columns[1].Width;
                            comb.Height = this.listView1.FocusedItem.Bounds.Height - 10;

                            comb.Visible = true;
                            this.comb.DataSource = null;
                            if (this.listView1.Controls.Find("Listcomb", true).Length <= 0)
                                this.listView1.Controls.Add(comb);
                            this.comb.Location = info.SubItem.Bounds.Location;
                            //this.comb.Items.Clear();
                            //this.comb.DisplayMember = "ORDER_POSITION";
                            //this.comb.ValueMember = "ORDER_ID";
                            //string sql = "  select ORDER_ID,ORDER_POSITION from JC_HOITEMDICTIONCHILD  where  order_id=" + info.Item.SubItems[9].Text;
                            //this.comb.DisplayMember = "TCMX_NAME";
                            //this.comb.ValueMember = "TCMX_CODE";
                            //string sql = "  select TCMX_CODE,TCMX_NAME from JCBW  where  TC_CODE=" + this.cmbbw.SelectedValue.ToString();
                            //DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
                            //DataRow r1 = tb.NewRow();
                            //r1["TCMX_CODE"] = -1;
                            //r1["TCMX_NAME"] = info.Item.SubItems[1].Text;
                            DataTable dept = new DataTable();
                            string deptsql = "  select * from dept_bwxz  where  dept_id=" + info.Item.SubItems[11].Text;
                            dept = FrmMdiMain.Database.GetDataTable(deptsql);
                            if (dept.Rows.Count > 0)
                            {
                                //if (dept.Rows[0]["dept_id"].ToString() == "9")
                                //{
                                //    comb.Text = info.Item.SubItems[1].Text;
                                //    comb.Tag = info.Item.SubItems[16].Text;
                                //    //return;
                                //}
                                //else
                                //{
                                    comb.Enabled = false;
                                    FrmBW frmbw = new FrmBW();
                                    frmbw.xmmc = info.Item.SubItems[0].Text.Trim();
                                    frmbw.orderid = info.Item.SubItems[9].Text.Trim();
                                    frmbw.xmclass = info.Item.SubItems[8].Text.Trim();
                                    frmbw.ShowDialog();
                                    comb.Visible = false;
                                    //DataTable tb = frmbw.jcfltb();
                                    if (info.Item.SubItems[1].Text.Trim() != "")
                                    {
                                        //DataRow[] delrow = tb.Select("TCMX_NAME='" + info.Item.SubItems[1].Text + "'");
                                        //for (int y = 0; y < delrow.Length; y++)
                                        //{
                                        //    info.Item.SubItems[1].Tag = delrow[0].ItemArray[0].ToString();
                                        //    tb.Rows.Remove(delrow[y]);
                                        //}
                                        //tb.Rows.InsertAt(r1, 0);
                                    }
                                    //if (tb.Rows.Count > 0)
                                    //{
                                        //this.comb.DataSource = tb;
                                        info.Item.SubItems[1].Text = frmbw.ordertext;
                                        info.Item.SubItems[16].Text = frmbw.ordertag;
                                        comb.Text = info.Item.SubItems[1].Text;
                                        comb.Tag = info.Item.SubItems[16].Text;
                                    //}
                                    frmbw.Dispose();
                                    //else
                                    //    this.comb.DataSource = null;
                                    //comb.Text = info.Item.SubItems[1].Text;
                                    //comb.Tag = info.Item.SubItems[1].Tag;
                                //}
                                
                            }
                            else
                            {
                                comb.Enabled = true;
                                this.comb.DataSource = null;
                                comb.Text = info.Item.SubItems[1].Text;
                                comb.Tag = " ";

                            }
                            comb.Focus();
                            comb.KeyPress -= new KeyPressEventHandler(comb_KeyPress);
                            comb.KeyPress += new KeyPressEventHandler(comb_KeyPress);

                            comb.LostFocus -= new EventHandler(comb_LostFocus);
                            comb.LostFocus += new EventHandler(comb_LostFocus);
                            // comb.Tag = info.Item.SubItems[3].Text;
                            // MessageBox.Show(info.Item.SubItems[3].Text);

                            return;
                        }
                        catch
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
            }
            else
                return;


        }



        void comb_LostFocus(object sender, EventArgs e)
        {
            this.listView1.Items[this.listView1.FocusedItem.Index].SubItems[1].Text = comb.Text;
            this.listView1.Items[this.listView1.FocusedItem.Index].SubItems[1].Tag = comb.Tag;
            this.listView1.Controls.Clear();
            comb.Visible = false;
        }

        void comb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    this.comb.Visible = false;
                    this.listView1.FocusedItem.Selected = false;
                    this.listView1.Items[this.listView1.FocusedItem.Index + 1].Selected = true;
                    this.listView1.Items[this.listView1.FocusedItem.Index + 1].Focused = true;
                    this.listView1.Focus();
                }
                catch
                {
                    this.listView1.Focus();
                }
            }
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                //(sender as TextBox).LostFocus -= new EventHandler(tb_LostFocus);
                //(sender as TextBox).Dispose();
                this.listView1.Controls.Clear();
                comb.Visible = false;
                //(sender as TextBox).Visible = false;

            }
        }



        void tb_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (listView1.Items.Count == 0)
                {
                    (sender as TextBox).Dispose();
                    return;
                }

                //Modify by jchl
                //int data = int.Parse((sender as TextBox).Text.Trim());
                int data = -1;
                try
                {
                    data = int.Parse((sender as TextBox).Text.Trim());
                }
                catch
                {
                    data = int.Parse((sender as TextBoxBase).Text.Trim());
                }

                if (data <= 0)
                {
                    (sender as TextBox).LostFocus -= new EventHandler(tb_LostFocus);
                    MessageBox.Show("请输入大于0的整数");
                    (sender as TextBox).LostFocus += new EventHandler(tb_LostFocus);
                    (sender as TextBox).Focus();
                    return;
                }
                string strPrc = (sender as TextBox).Text;
                this.listView1.Items[this.listView1.FocusedItem.Index].SubItems[2].Text = strPrc;

                string strDj = this.listView1.Items[this.listView1.FocusedItem.Index].SubItems[4].Text;
                //add by jchl
                this.listView1.Items[this.listView1.FocusedItem.Index].SubItems[5].Text = (decimal.Parse(strDj) * decimal.Parse(strPrc)).ToString();
            }
            catch
            {

                (sender as TextBox).LostFocus -= new EventHandler(tb_LostFocus);
                MessageBox.Show("请输入数字");
                (sender as TextBox).LostFocus += new EventHandler(tb_LostFocus);
                (sender as TextBox).Focus();
                return;
            }
            this.lbPrice.Text = Getprice() + " 元";
            (sender as TextBox).Dispose();
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    if (listView1.Items.Count == 0)
                    {
                        (sender as TextBox).Dispose();
                        return;
                    }

                    //Modify by jchl
                    //int data = int.Parse((sender as TextBox).Text.Trim());
                    int data = -1;
                    try
                    {
                        data = int.Parse((sender as TextBox).Text.Trim());
                    }
                    catch
                    {
                        data = int.Parse((sender as TextBoxBase).Text.Trim());
                    }

                    if (data <= 0)
                    {
                        (sender as TextBox).LostFocus -= new EventHandler(tb_LostFocus);
                        MessageBox.Show("请输入大于0的整数");
                        (sender as TextBox).LostFocus += new EventHandler(tb_LostFocus);
                        (sender as TextBox).Focus();
                        return;
                    }
                    //this.listView1.Items[this.listView1.FocusedItem.Index].SubItems[0].Text = (sender as TextBox).Text;

                }
                catch
                {

                    (sender as TextBox).LostFocus -= new EventHandler(tb_LostFocus);
                    MessageBox.Show("请输入数字");
                    (sender as TextBox).LostFocus += new EventHandler(tb_LostFocus);
                    (sender as TextBox).Focus();
                    return;
                }
                (sender as TextBox).Dispose();
                try
                {
                    this.listView1.FocusedItem.Selected = false;
                    this.listView1.Items[this.listView1.FocusedItem.Index + 1].Selected = true;
                    this.listView1.Items[this.listView1.FocusedItem.Index + 1].Focused = true;
                }
                catch { }

            }
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                (sender as TextBox).LostFocus -= new EventHandler(tb_LostFocus);
                (sender as TextBox).Dispose();
                //(sender as TextBox).Visible = false;

            }
        }

        private void dataGridviewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            button6_Click(null, null);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //btPrint_Click(null, null);
            button1_Click(sender, e);
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //e.DrawDefault = true;
            Rectangle rc = new Rectangle(new Point(e.Bounds.Location.X, e.Bounds.Y), new Size(e.Bounds.Width, e.Bounds.Height - 1));
            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                Color FColor = Color.FromKnownColor(KnownColor.Highlight);
                Color TColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);


                LinearGradientBrush brush =
                            new LinearGradientBrush(rc, FColor,
                            TColor, LinearGradientMode.Horizontal);
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(brush, rc);
                e.Graphics.DrawRectangle(Pens.Blue, rc);
                //e.DrawFocusRectangle();

                // rc = new Rectangle(new Point(e.Bounds.Location.X + this.columnHeader1.Width, e.Bounds.Y), new Size(e.Bounds.Width - this.columnHeader1.Width, e.Bounds.Height));
                // WorkStats.PulicFun.DrawButtonBackground(e.Graphics, rc, true, true, true, true, TColor, FColor, Color.White, TColor, Color.WhiteSmoke, 5);
            }
            else
            {
                if ((e.State & ListViewItemStates.ShowKeyboardCues) != 0)
                {
                    SolidBrush sbrush = null;
                    if ((e.ItemIndex + 1) % 2 == 0)
                    {

                        sbrush = new SolidBrush(Color.AliceBlue);

                        //this.listView1.Items[i].ForeColor = Color.Blue;

                    }
                    else
                    {
                        sbrush = new SolidBrush(Color.LightGreen);

                        //this.listView1.Items[i].ForeColor = Color.Black;
                    }
                    e.Graphics.FillRectangle(sbrush, e.Bounds);
                }
            }

            //TextFormatFlags flags = TextFormatFlags.Default;
            //e.DrawText(flags);
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {

            if (e.ColumnIndex == 3)
            {
                e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Height - 2)); //画底色

            }
            else
            {

            }
            TextFormatFlags flags = TextFormatFlags.Default;
            e.DrawText();
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            //TextFormatFlags flags = TextFormatFlags.VerticalCenter;
            //e.DrawText(flags);
            e.DrawDefault = true;
        }

        private void 折叠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collapse(true);
        }

        private void 展开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Collapse(false);
        }

        private void chcekbl_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcekbl.Checked)
            {
                this.DtpbeginDate.Enabled = true;
            }
            else
                this.DtpbeginDate.Enabled = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GrdJY.DataSource as DataTable;
                if (dt.Rows.Count <= 0)
                    return;

                int iRow = GrdJY.CurrentRowIndex;

                string sql = string.Format(@"select jc_no from zy_jc_record where group_id='{0}' and inpatient_id='{1}'", dt.Rows[iRow]["医嘱号"].ToString().Trim(), BinID);
                DataTable dtJc = InstanceForm._database.GetDataTable(sql);

                if (dtJc.Rows.Count > 0)
                {
                    string strJcNo = dtJc.Rows[0]["jc_no"].ToString().Trim();

                    string strUrl = GetIniString("武汉市中心医院", "QueryUrl", System.Windows.Forms.Application.StartupPath + "\\ECG.ini");
                    strUrl += strJcNo;

                    DoQueryJcJyInfo(strUrl);
                }
                else
                {
                    MessageBox.Show("找不到【JC_NO】申请！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("查询结果出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// 调用IE查询检查结果
        /// </summary>
        /// <param name="url"></param>
        public void DoQueryJcJyInfo(string url)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", url);
        }

        //API函数申明
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }

        public decimal GetorderPrice(long orderid)
        {
            if (myQuery == null)
                myQuery = new DbQuery();
            return myQuery.GetPrice(orderid, FrmMdiMain.Jgbm);
        }

        /// <summary>
        /// 住院号去掉前面的0
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        private string ConvertNo(string zyh)
        {
            int leng = zyh.Length;
            for (int i = 0; i < leng; i++)
            {
                if (zyh.Substring(0, 1) == "0")
                {
                    zyh = zyh.Substring(1, zyh.Length - 1);
                }
                else
                    break;
            }
            return zyh;
        }

        public void DoHideTabOrder()
        {
            tabControl1.TabPages.Remove(tabPage1);
        }

        //Add By Tany 2015-06-04 读取EMR简要病史
        private void btEmr_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = TrasenHIS.BLL.HisFunctions.GetEmrInpatientSummary(patientBar1.lblInpatientNo.Text, "");
                if (tb != null && tb.Rows.Count > 0)
                {
                    string jybs = tb.Rows[0]["content"].ToString().Trim();
                    if (jybs != "")
                    {
                        if (richRecord.Text.Trim() != "")
                        {
                            if (MessageBox.Show("简要病史输入栏不为空，是否需要替换为EMR的简要病史？\r\nEMR的简要病史为：\r\n" + jybs, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        richRecord.Text = jybs;
                    }
                    else
                    {
                        throw new Exception("获取EMR的简要病史为空！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void patientBar1_Load(object sender, EventArgs e)
        {

        }

        private void FrmJCSQBW_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Dispose();
            //this.Close();
        }
        public static bool IsNumber(string str)
        {
            if (str == null || str.Length == 0)    //验证这个参数是否为空  
                return false;                           //是，就返回False  
            ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的实例  
            byte[] bytestr = ascii.GetBytes(str);         //把string类型的参数保存到数组里  

            foreach (byte c in bytestr)                   //遍历这个数组里的内容  
            {
                if (c < 48 || c > 57)                          //判断是否为数字  
                {
                    return false;                              //不是，就返回False  
                }
            }
            return true;                                        //是，就返回True  
        }  
    }
}
