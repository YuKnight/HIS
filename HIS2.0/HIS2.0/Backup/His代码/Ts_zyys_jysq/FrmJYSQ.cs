using EmrVSHISInterface;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using Ts_zyys_jysq.Properties;
using Ts_zyys_public;
using ts_zyhs_jyddy;

namespace Ts_zyys_jysq
{

    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class FrmJYSQ : System.Windows.Forms.Form
    {
        #region 自定义变量
        private DataTable dt = new DataTable();
        private DataTable itemTb = new DataTable();
        private DataTable mydt = new DataTable();
        private DbQuery myQuery = new DbQuery();
        private DataGridTableStyle GrdTableS = new DataGridTableStyle();

        public string _Zyid = "";//add by jchl
        public string fylb = "";//add by jchl

        public long YS_ID = 1;
        public long DeptID = 1;
        public string WardID = "";
        public long Dept_Br = 1;
        public Guid BinID = Guid.Empty;
        public long BabyID = 1;
        public User YS = null;
        public long lg = 0;//权限
        public System.Drawing.Brush brush;
        public System.Drawing.Font font;
        private string stritem = "";
        private Timer tm = new Timer();
        private Label lb = new Label();
        decimal pr = 0;
        private DataTable sampleTb = new DataTable();

        private bool _isHideJySq = false;
        #endregion



        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox chkListBox;
        private System.Windows.Forms.Label lbCaption;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.DataGrid GrdJY;
        private System.Windows.Forms.Button btTJ;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbprint;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private TrasenClasses.GeneralControls.LabelEx label12;
        private System.Windows.Forms.RichTextBox richJY;
        private System.Windows.Forms.Button btPanel;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.TextBox txtDM;
        private System.Windows.Forms.Label lbDateTime;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbFJ;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbSample;
        private System.Windows.Forms.TextBox txtDiag;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbClass;
        private Ts_zyys_public.PatientBar patientBar1;
        private System.Windows.Forms.ImageList imageList_tab;
        private Button btSaveTC;
        private Label label1;
        private ComboBox cmbTc;
        private Button btDelTC;
        private GroupBox groupBox1;
        private Panel panel8;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader8;
        private Button button3;
        private Button button1;
        private Button button4;
        private ColumnHeader columnHeader7;
        private ColumnHeader header;
        private Button button6;
        private TabPage tabPage3;
        private Control_jysq control_jysq1;
        private DateTimePicker DtpbeginDate;
        private Button btnQuery;
        private Button btnSinglePrint;
        private Button btnAllPrint;
        private Button button7;
        private Button btEmr;
        private System.ComponentModel.IContainer components;


        public FrmJYSQ(long currentUser, long currentDept, string formText, object[] _value)
        {
            InitializeComponent();

            BinID = new Guid(Convertor.IsNull(_value[0], Guid.Empty.ToString()));

            YS = new User(Convert.ToInt64(currentUser), FrmMdiMain.Database);

            YS_ID = YS.EmployeeId;
            DeptID = currentDept;
            WardID = _value[1].ToString();
            BabyID = Convert.ToInt64(Convertor.IsNull(_value[4], "0"));
            lg = Convert.ToInt64(Convertor.IsNull(_value[5], "0"));
            control_jysq1.Close += new DelClose(control_jysq1_Close);
            this.ActiveControl = this.control_jysq1;
            base.FormClosing += new FormClosingEventHandler(this.FrmJYSQ_FormClosing);

            this.patientBar1.PatientID = this.BinID;
            this.control_jysq1.BabyID = (int)this.BabyID;
            this.control_jysq1.BinID = this.BinID;
            this.control_jysq1.typely = Typely.住院;
            this.control_jysq1._brxx = new brxx();
            this.control_jysq1._brxx.inpatient_id = BinID;
            this.control_jysq1._brxx.baby_id = BabyID;
            this.control_jysq1._brxx.brxm = this.patientBar1.lblName.Text;
            this.control_jysq1._brxx.inpatient_no = this.patientBar1.lblInpatientNo.Text;
            this.control_jysq1._brxx.bedno = this.patientBar1.lblBedNo.Text;
            this.control_jysq1._brxx.nl = this.patientBar1.lblage.Text;
            this.control_jysq1._brxx.xb = this.patientBar1.lblSex.Text;
            this.control_jysq1._brxx.bq = this.patientBar1.lblWard.Text;
            this.control_jysq1._brxx.lczd = this.patientBar1.lblDiag.Text;
        }
        public FrmJYSQ(long currentUser, long currentDept, string formText)
        {
            InitializeComponent();

        }
        public FrmJYSQ(Guid inpatientid, long babyid)
        {
            InitializeComponent();
            this.BinID = inpatientid;
            this.BabyID = babyid;
            this.patientBar1.PatientID = this.BinID;
            control_jysq1.Close += new DelClose(control_jysq1_Close);
            this.ActiveControl = this.control_jysq1;
            base.FormClosing += new FormClosingEventHandler(this.FrmJYSQ_FormClosing);

            this.control_jysq1.BabyID = (int)this.BabyID;
            this.control_jysq1.BinID = this.BinID;
            this.control_jysq1.typely = Typely.住院;
            this.control_jysq1._brxx = new brxx();
            this.control_jysq1._brxx.inpatient_id = BinID;
            this.control_jysq1._brxx.baby_id = BabyID;
            this.control_jysq1._brxx.brxm = this.patientBar1.lblName.Text;
            this.control_jysq1._brxx.inpatient_no = this.patientBar1.lblInpatientNo.Text;
            this.control_jysq1._brxx.bedno = this.patientBar1.lblBedNo.Text;
            this.control_jysq1._brxx.nl = this.patientBar1.lblage.Text;
            this.control_jysq1._brxx.xb = this.patientBar1.lblSex.Text;
            this.control_jysq1._brxx.bq = this.patientBar1.lblWard.Text;
            this.control_jysq1._brxx.lczd = this.patientBar1.lblDiag.Text;
        }
        public FrmJYSQ(Guid inpatientid, long babyid, bool isHideJySq)
        {
            InitializeComponent();
            this.BinID = inpatientid;
            this.BabyID = babyid;
            this.patientBar1.PatientID = this.BinID;
            if (isHideJySq)
            {
                control_jysq1.Load -= new EventHandler(control_jysq1.Control_jysq_Load);
            }
            control_jysq1.Close += new DelClose(control_jysq1_Close);
            base.FormClosing += new FormClosingEventHandler(this.FrmJYSQ_FormClosing);

            //this.ActiveControl = this.control_jysq1;
            this.control_jysq1.BabyID = (int)this.BabyID;
            this.control_jysq1.BinID = this.BinID;
            this.control_jysq1.typely = Typely.住院;
            this.control_jysq1._brxx = new brxx();
            this.control_jysq1._brxx.inpatient_id = BinID;
            this.control_jysq1._brxx.baby_id = BabyID;
            this.control_jysq1._brxx.brxm = this.patientBar1.lblName.Text;
            this.control_jysq1._brxx.inpatient_no = this.patientBar1.lblInpatientNo.Text;
            this.control_jysq1._brxx.bedno = this.patientBar1.lblBedNo.Text;
            this.control_jysq1._brxx.nl = this.patientBar1.lblage.Text;
            this.control_jysq1._brxx.xb = this.patientBar1.lblSex.Text;
            this.control_jysq1._brxx.bq = this.patientBar1.lblWard.Text;
            this.control_jysq1._brxx.lczd = this.patientBar1.lblDiag.Text;

            _isHideJySq = isHideJySq;
        }
        public FrmJYSQ()
        {
            InitializeComponent();
        }
        #region 自定义项
        /// <summary>
        /// 自定义项
        /// </summary>
        private class Item
        {
            private long _id;
            private string _name;
            private string _unit;
            private string _usage;
            private long _dept;
            private string _pym;
            private int _code;
            private string _sample;
            private string _bz;
            private int _tempcode;
            private int _FJSMBT;
            private string _zxksmc = "";
            public string zxksmc
            {
                get
                {
                    return this._zxksmc;
                }
                set
                {
                    this._zxksmc = value;
                }
            }
            public Item()
            {
                _id = 0;
                _name = "";
                _unit = "";
                _usage = "";
                _dept = 0;
                _pym = "";
                _code = 1;
                _sample = "";
                _bz = "";
                _tempcode = 1;
            }
            /// <summary>
            /// 附加说明必填
            /// </summary>
            public int FJSMBT
            {
                get { return _FJSMBT; }
                set { _FJSMBT = value; }
            }
            /// <summary>
            /// 检验项目ID
            /// </summary>
            public long orderID
            {
                get { return _id; }
                set { _id = value; }
            }
            /// <summary>
            /// 检验项目名称
            /// </summary>
            public string orderName
            {
                get { return _name; }
                set { _name = value; }
            }
            /// <summary>
            /// 检验项目单位
            /// </summary>
            public string orderUnit
            {
                get { return _unit; }
                set { _unit = value; }
            }
            /// <summary>
            /// 检验项目用法
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
            /// 拼音码
            /// </summary>
            public string pym
            {
                get { return _pym; }
                set { _pym = value; }
            }
            /// <summary>
            /// 标本ID
            /// </summary>
            public int code
            {
                get { return _code; }
                set { _code = value; }
            }
            /// <summary>
            /// 标本名称
            /// </summary>
            public string sample
            {
                get { return _sample; }
                set { _sample = value; }
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
            /// 选择的标本ID
            /// </summary>
            public int sampleCode
            {
                get { return _tempcode; }
                set { _tempcode = value; }
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
            System.Windows.Forms.ColumnHeader columnHeader6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJYSQ));
            this.panel1 = new System.Windows.Forms.Panel();
            this.patientBar1 = new Ts_zyys_public.PatientBar();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.header = new System.Windows.Forms.ColumnHeader();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btEmr = new System.Windows.Forms.Button();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.control_jysq1 = new Ts_zyys_jysq.Control_jysq();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbFJ = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbTc = new System.Windows.Forms.ComboBox();
            this.txtDiag = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbSample = new System.Windows.Forms.ComboBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lbDateTime = new System.Windows.Forms.Label();
            this.txtDM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkListBox = new System.Windows.Forms.CheckedListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lbCaption = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btDelTC = new System.Windows.Forms.Button();
            this.btSaveTC = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btTJ = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btPanel = new System.Windows.Forms.Button();
            this.richJY = new System.Windows.Forms.RichTextBox();
            this.label12 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.btnSinglePrint = new System.Windows.Forms.Button();
            this.btnAllPrint = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.lbprint = new System.Windows.Forms.Label();
            this.GrdJY = new System.Windows.Forms.DataGrid();
            this.imageList_tab = new System.Windows.Forms.ImageList(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdJY)).BeginInit();
            this.SuspendLayout();
            // 
            // columnHeader6
            // 
            columnHeader6.Width = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.patientBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 72);
            this.panel1.TabIndex = 0;
            // 
            // patientBar1
            // 
            this.patientBar1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.patientBar1.BorderType = Ts_zyys_public.PatientBar.BorderStyle.Raised;
            this.patientBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientBar1.Location = new System.Drawing.Point(0, 0);
            this.patientBar1.Name = "patientBar1";
            this.patientBar1.Size = new System.Drawing.Size(971, 72);
            this.patientBar1.TabIndex = 37;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "数量";
            // 
            // header
            // 
            this.header.Text = "执行科室id";
            this.header.Width = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ImageList = this.imageList_tab;
            this.tabControl1.Location = new System.Drawing.Point(0, 72);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 4);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(971, 489);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btEmr);
            this.tabPage3.Controls.Add(this.DtpbeginDate);
            this.tabPage3.Controls.Add(this.control_jysq1);
            this.tabPage3.ImageIndex = 1;
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(963, 455);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "检验申请";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btEmr
            // 
            this.btEmr.Location = new System.Drawing.Point(0, 121);
            this.btEmr.Name = "btEmr";
            this.btEmr.Size = new System.Drawing.Size(75, 23);
            this.btEmr.TabIndex = 113;
            this.btEmr.Text = "EMR病史";
            this.btEmr.UseVisualStyleBackColor = true;
            this.btEmr.Click += new System.EventHandler(this.btEmr_Click);
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(103, 373);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(164, 21);
            this.DtpbeginDate.TabIndex = 112;
            this.DtpbeginDate.Value = new System.DateTime(2004, 6, 25, 0, 0, 0, 0);
            // 
            // control_jysq1
            // 
            this.control_jysq1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.control_jysq1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.control_jysq1.Location = new System.Drawing.Point(3, 4);
            this.control_jysq1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.control_jysq1.Name = "control_jysq1";
            this.control_jysq1.Size = new System.Drawing.Size(958, 447);
            this.control_jysq1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(963, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "检验申请录入";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Honeydew;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.cmbTc);
            this.panel3.Controls.Add(this.txtDiag);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.cmbSample);
            this.panel3.Controls.Add(this.cmbClass);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.lbDateTime);
            this.panel3.Controls.Add(this.txtDM);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.chkListBox);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.cmbDept);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.lbCaption);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(963, 417);
            this.panel3.TabIndex = 0;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button6.Location = new System.Drawing.Point(555, 184);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(24, 24);
            this.button6.TabIndex = 98;
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel8.Controls.Add(this.label19);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.lbPrice);
            this.panel8.Controls.Add(this.label17);
            this.panel8.Controls.Add(this.cmbFJ);
            this.panel8.Controls.Add(this.label18);
            this.panel8.Location = new System.Drawing.Point(7, 385);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(944, 30);
            this.panel8.TabIndex = 97;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label19.Location = new System.Drawing.Point(244, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 14);
            this.label19.TabIndex = 90;
            this.label19.Text = "备注信息";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(561, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 14);
            this.label11.TabIndex = 9;
            this.label11.Text = "检验费：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPrice
            // 
            this.lbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbPrice.AutoSize = true;
            this.lbPrice.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lbPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPrice.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbPrice.Location = new System.Drawing.Point(643, 6);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(64, 17);
            this.lbPrice.TabIndex = 10;
            this.lbPrice.Text = "0.00 元";
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label17.Location = new System.Drawing.Point(2, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 14);
            this.label17.TabIndex = 87;
            this.label17.Text = "附加说明";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbFJ
            // 
            this.cmbFJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbFJ.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbFJ.Location = new System.Drawing.Point(69, 5);
            this.cmbFJ.Name = "cmbFJ";
            this.cmbFJ.Size = new System.Drawing.Size(169, 23);
            this.cmbFJ.TabIndex = 88;
            this.cmbFJ.TextChanged += new System.EventHandler(this.cmbFJ_TextChanged);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FloralWhite;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.Location = new System.Drawing.Point(313, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(2, 17);
            this.label18.TabIndex = 89;
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(581, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 382);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已选择项目";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader4,
            this.header,
            this.columnHeader7});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(375, 359);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目名称";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "附加说明";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "执行科室";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "标本名称";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "价格";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "单位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(171, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 95;
            this.label1.Text = "套餐选择";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(555, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 6;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbTc
            // 
            this.cmbTc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTc.FormattingEnabled = true;
            this.cmbTc.Location = new System.Drawing.Point(241, 87);
            this.cmbTc.Name = "cmbTc";
            this.cmbTc.Size = new System.Drawing.Size(139, 23);
            this.cmbTc.TabIndex = 94;
            this.cmbTc.SelectedIndexChanged += new System.EventHandler(this.cmbTc_SelectedIndexChanged);
            // 
            // txtDiag
            // 
            this.txtDiag.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDiag.Location = new System.Drawing.Point(74, 59);
            this.txtDiag.Name = "txtDiag";
            this.txtDiag.Size = new System.Drawing.Size(183, 24);
            this.txtDiag.TabIndex = 92;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label20.Location = new System.Drawing.Point(3, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 14);
            this.label20.TabIndex = 93;
            this.label20.Text = "临床诊断";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbSample
            // 
            this.cmbSample.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSample.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSample.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSample.Items.AddRange(new object[] {
            "生化室",
            "急诊生化室"});
            this.cmbSample.Location = new System.Drawing.Point(451, 91);
            this.cmbSample.Name = "cmbSample";
            this.cmbSample.Size = new System.Drawing.Size(104, 23);
            this.cmbSample.TabIndex = 91;
            this.cmbSample.Visible = false;
            // 
            // cmbClass
            // 
            this.cmbClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbClass.Location = new System.Drawing.Point(261, 31);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(156, 23);
            this.cmbClass.TabIndex = 2;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label13.Location = new System.Drawing.Point(417, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 14);
            this.label13.TabIndex = 85;
            this.label13.Text = "室";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDateTime
            // 
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDateTime.Location = new System.Drawing.Point(331, 62);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(58, 16);
            this.lbDateTime.TabIndex = 84;
            this.lbDateTime.Text = "label20";
            this.lbDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDM
            // 
            this.txtDM.BackColor = System.Drawing.Color.FloralWhite;
            this.txtDM.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDM.Location = new System.Drawing.Point(74, 88);
            this.txtDM.Name = "txtDM";
            this.txtDM.Size = new System.Drawing.Size(87, 23);
            this.txtDM.TabIndex = 0;
            this.txtDM.Text = "<拼音码>";
            this.txtDM.TextChanged += new System.EventHandler(this.txtDM_TextChanged);
            this.txtDM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDM_KeyDown);
            this.txtDM.Leave += new System.EventHandler(this.txtDM_Leave);
            this.txtDM.Enter += new System.EventHandler(this.txtDM_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(3, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "检验项目";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkListBox
            // 
            this.chkListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.chkListBox.BackColor = System.Drawing.Color.FloralWhite;
            this.chkListBox.CheckOnClick = true;
            this.chkListBox.ColumnWidth = 280;
            this.chkListBox.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkListBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkListBox.Location = new System.Drawing.Point(7, 115);
            this.chkListBox.MultiColumn = true;
            this.chkListBox.Name = "chkListBox";
            this.chkListBox.Size = new System.Drawing.Size(548, 220);
            this.chkListBox.TabIndex = 7;
            this.chkListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkListBox_MouseClick);
            this.chkListBox.SelectedIndexChanged += new System.EventHandler(this.chkListBox_SelectedIndexChanged);
            this.chkListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListBox_ItemCheck);
            this.chkListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkListBox_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label14.Location = new System.Drawing.Point(263, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 14);
            this.label14.TabIndex = 5;
            this.label14.Text = "申请时间 ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label15.Location = new System.Drawing.Point(385, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 14);
            this.label15.TabIndex = 3;
            this.label15.Text = "送检标本 ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.Visible = false;
            // 
            // cmbDept
            // 
            this.cmbDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDept.Location = new System.Drawing.Point(74, 31);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(157, 23);
            this.cmbDept.TabIndex = 1;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label16.Location = new System.Drawing.Point(3, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(283, 14);
            this.label16.TabIndex = 1;
            this.label16.Text = "请选择                           科";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCaption
            // 
            this.lbCaption.AutoSize = true;
            this.lbCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCaption.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbCaption.Location = new System.Drawing.Point(254, 1);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(154, 31);
            this.lbCaption.TabIndex = 0;
            this.lbCaption.Text = "检验申请单";
            this.lbCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btDelTC);
            this.panel2.Controls.Add(this.btSaveTC);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btTJ);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 417);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(963, 38);
            this.panel2.TabIndex = 3;
            // 
            // btDelTC
            // 
            this.btDelTC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDelTC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelTC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDelTC.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btDelTC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelTC.Location = new System.Drawing.Point(325, 5);
            this.btDelTC.Name = "btDelTC";
            this.btDelTC.Size = new System.Drawing.Size(121, 28);
            this.btDelTC.TabIndex = 5;
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
            this.btSaveTC.Location = new System.Drawing.Point(197, 5);
            this.btSaveTC.Name = "btSaveTC";
            this.btSaveTC.Size = new System.Drawing.Size(122, 28);
            this.btSaveTC.TabIndex = 4;
            this.btSaveTC.Text = "保存套餐(&T)";
            this.btSaveTC.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btSaveTC.Click += new System.EventHandler(this.btSaveTC_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btClose);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(590, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(373, 38);
            this.panel4.TabIndex = 3;
            // 
            // btClose
            // 
            this.btClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btClose.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.ImageIndex = 1;
            this.btClose.Location = new System.Drawing.Point(224, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(87, 28);
            this.btClose.TabIndex = 3;
            this.btClose.Text = "退出(&C)";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.ImageIndex = 5;
            this.button4.Location = new System.Drawing.Point(170, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 28);
            this.button4.TabIndex = 8;
            this.button4.Text = "反选";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.ImageIndex = 5;
            this.button3.Location = new System.Drawing.Point(116, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 28);
            this.button3.TabIndex = 7;
            this.button3.Text = "全选";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(104, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "打印(&P)";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btTJ
            // 
            this.btTJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTJ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTJ.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btTJ.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btTJ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTJ.Location = new System.Drawing.Point(9, 5);
            this.btTJ.Name = "btTJ";
            this.btTJ.Size = new System.Drawing.Size(89, 28);
            this.btTJ.TabIndex = 0;
            this.btTJ.Text = "提交(&O)";
            this.btTJ.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btTJ.Click += new System.EventHandler(this.btTJ_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.GrdJY);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(963, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "检验申请查询";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Visible = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.btPanel);
            this.panel7.Controls.Add(this.richJY);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.pictureBox2);
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Location = new System.Drawing.Point(112, 24);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(561, 296);
            this.panel7.TabIndex = 6;
            this.panel7.Visible = false;
            // 
            // btPanel
            // 
            this.btPanel.BackColor = System.Drawing.Color.Wheat;
            this.btPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btPanel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPanel.ImageIndex = 1;
            this.btPanel.Location = new System.Drawing.Point(457, 11);
            this.btPanel.Name = "btPanel";
            this.btPanel.Size = new System.Drawing.Size(72, 24);
            this.btPanel.TabIndex = 4;
            this.btPanel.Text = "关闭";
            this.btPanel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btPanel.UseVisualStyleBackColor = false;
            this.btPanel.Click += new System.EventHandler(this.btPanel_Click);
            // 
            // richJY
            // 
            this.richJY.BackColor = System.Drawing.SystemColors.Window;
            this.richJY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richJY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richJY.Location = new System.Drawing.Point(0, 43);
            this.richJY.Name = "richJY";
            this.richJY.Size = new System.Drawing.Size(559, 248);
            this.richJY.TabIndex = 3;
            this.richJY.Text = "";
            // 
            // label12
            // 
            this.label12.BackColor1 = System.Drawing.Color.DarkGoldenrod;
            this.label12.BackColor2 = System.Drawing.Color.OldLace;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label12.Location = new System.Drawing.Point(0, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(559, 40);
            this.label12.TabIndex = 2;
            this.label12.Text = "检验报告单";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 291);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(559, 3);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(559, 3);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button7);
            this.panel5.Controls.Add(this.btnSinglePrint);
            this.panel5.Controls.Add(this.btnAllPrint);
            this.panel5.Controls.Add(this.btnQuery);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.btPrint);
            this.panel5.Controls.Add(this.lbprint);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 387);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(963, 68);
            this.panel5.TabIndex = 5;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.button7.ForeColor = System.Drawing.Color.Navy;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(578, 18);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(136, 30);
            this.button7.TabIndex = 117;
            this.button7.Text = "检验结果打印(&P)";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnSinglePrint
            // 
            this.btnSinglePrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinglePrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnSinglePrint.ForeColor = System.Drawing.Color.Navy;
            this.btnSinglePrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSinglePrint.Location = new System.Drawing.Point(343, 18);
            this.btnSinglePrint.Name = "btnSinglePrint";
            this.btnSinglePrint.Size = new System.Drawing.Size(81, 30);
            this.btnSinglePrint.TabIndex = 116;
            this.btnSinglePrint.Text = "单打(&S)";
            this.btnSinglePrint.UseVisualStyleBackColor = true;
            this.btnSinglePrint.Click += new System.EventHandler(this.btnSinglePrint_Click);
            // 
            // btnAllPrint
            // 
            this.btnAllPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnAllPrint.ForeColor = System.Drawing.Color.Navy;
            this.btnAllPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllPrint.Location = new System.Drawing.Point(256, 18);
            this.btnAllPrint.Name = "btnAllPrint";
            this.btnAllPrint.Size = new System.Drawing.Size(81, 30);
            this.btnAllPrint.TabIndex = 115;
            this.btnAllPrint.Text = "群打(&A)";
            this.btnAllPrint.UseVisualStyleBackColor = true;
            this.btnAllPrint.Click += new System.EventHandler(this.btnAllPrint_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.ForeColor = System.Drawing.Color.Navy;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(436, 18);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(136, 30);
            this.btnQuery.TabIndex = 114;
            this.btnQuery.Text = "检验结果查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(779, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(184, 68);
            this.panel6.TabIndex = 7;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.ForeColor = System.Drawing.Color.Navy;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.ImageIndex = 1;
            this.button5.Location = new System.Drawing.Point(9, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 28);
            this.button5.TabIndex = 4;
            this.button5.Text = "退出(&C)";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button5.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btPrint
            // 
            this.btPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrint.ForeColor = System.Drawing.Color.Navy;
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageIndex = 14;
            this.btPrint.Location = new System.Drawing.Point(88, 20);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(89, 28);
            this.btPrint.TabIndex = 6;
            this.btPrint.Text = "打印(&R)";
            this.btPrint.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btPrint.Visible = false;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // lbprint
            // 
            this.lbprint.Location = new System.Drawing.Point(184, 24);
            this.lbprint.Name = "lbprint";
            this.lbprint.Size = new System.Drawing.Size(305, 23);
            this.lbprint.TabIndex = 5;
            // 
            // GrdJY
            // 
            this.GrdJY.AllowSorting = false;
            this.GrdJY.AlternatingBackColor = System.Drawing.SystemColors.ScrollBar;
            this.GrdJY.BackgroundColor = System.Drawing.Color.Gray;
            this.GrdJY.DataMember = "";
            this.GrdJY.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrdJY.GridLineColor = System.Drawing.SystemColors.Desktop;
            this.GrdJY.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdJY.Location = new System.Drawing.Point(0, 0);
            this.GrdJY.Name = "GrdJY";
            this.GrdJY.Size = new System.Drawing.Size(963, 380);
            this.GrdJY.TabIndex = 0;
            this.GrdJY.DoubleClick += new System.EventHandler(this.GrdJY_DoubleClick);
            this.GrdJY.CurrentCellChanged += new System.EventHandler(this.GrdJY_CurrentCellChanged);
            // 
            // imageList_tab
            // 
            this.imageList_tab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_tab.ImageStream")));
            this.imageList_tab.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_tab.Images.SetKeyName(0, "");
            this.imageList_tab.Images.SetKeyName(1, "");
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
            // FrmJYSQ
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(971, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmJYSQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验申请";
            this.Load += new System.EventHandler(this.FrmJYSQ_Load);
            this.Resize += new System.EventHandler(this.FrmJYSQ_Resize);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdJY)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void btClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btDelTC_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(this.cmbTc.SelectedValue) != -1) && (MessageBox.Show("是否删除该套餐？\n\n套餐名称：" + this.cmbTc.Text.Trim(), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No))
            {
                string commandtext = "select * from jc_jchytc_t where id=" + Convert.ToInt32(this.cmbTc.SelectedValue);
                DataTable dataTable = FrmMdiMain.Database.GetDataTable(commandtext);
                if ((dataTable.Rows.Count > 0) && !(FrmMdiMain.CurrentUser.IsAdministrator || (Convert.ToInt32(dataTable.Rows[0]["tclx"]) != 0)))
                {
                    MessageBox.Show("你没有权限删除院级模板！");
                }
                else
                {
                    string[] commandTexts = new string[] { "delete from jc_jchytc_mx where tcid=" + Convert.ToInt32(this.cmbTc.SelectedValue), "delete from jc_jchytc_t where id=" + Convert.ToInt32(this.cmbTc.SelectedValue) };
                    FrmMdiMain.Database.DoCommand(null, null, null, commandTexts);
                    MessageBox.Show("删除成功！");
                    SystemLog log = new SystemLog(-1L, (long)FrmMdiMain.CurrentDept.DeptId, (long)FrmMdiMain.CurrentUser.EmployeeId, "删除化验套餐", "删除名为 " + this.cmbTc.Text.Trim() + " 的套餐信息", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "主机名：" + Environment.MachineName, 6);
                    log.Save();
                    log = null;
                    this.cmbClass_SelectedIndexChanged(null, null);
                }
            }
        }

        private void btPanel_Click(object sender, EventArgs e)
        {
            this.panel7.Visible = false;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
        }

        private void btSaveTC_Click(object sender, EventArgs e)
        {
            if ((this.chkListBox.CheckedItems.Count != 0) && (MessageBox.Show("是否将选中的项目保存为套餐？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No))
            {
                FrmModelSave save = new FrmModelSave("套餐保存");
                save.ShowDialog();
                if (save.DialogResult != DialogResult.Cancel)
                {
                    string modelName = save.ModelName;
                    int num = save.model_type;
                    string commandtext = "";
                    int num2 = 0;
                    int deptId = 0;
                    switch (num)
                    {
                        case 1:
                            deptId = FrmMdiMain.CurrentDept.DeptId;
                            break;

                        case 2:
                            deptId = FrmMdiMain.CurrentUser.EmployeeId;
                            break;
                    }
                    FrmMdiMain.Database.BeginTransaction();
                    try
                    {
                        commandtext = string.Concat(new object[] { "insert into jc_jchytc_t(NAME, CLASS_ID, JGBM, TCLX, SYID) values ('", modelName, "',", Convert.ToInt32(this.cmbClass.SelectedValue), ",", FrmMdiMain.Jgbm, ",", num, ",", deptId, ")" });
                        FrmMdiMain.Database.DoCommand(commandtext);
                        commandtext = "Select IDENT_CURRENT('jc_jchytc_t')";
                        num2 = Convert.ToInt32(Convertor.IsNull(FrmMdiMain.Database.GetDataResult(commandtext), "0"));
                        if (num2 <= 0)
                        {
                            throw new Exception("插入套餐头表出错！");
                        }
                        for (int i = 0; i < this.chkListBox.CheckedItems.Count; i++)
                        {
                            commandtext = string.Concat(new object[] { "insert into jc_jchytc_mx(TCID, XMID) values (", num2, ",", Convert.ToInt32(((Item)this.chkListBox.CheckedItems[i]).orderID), ")" });
                            FrmMdiMain.Database.DoCommand(commandtext);
                        }
                        FrmMdiMain.Database.CommitTransaction();
                        MessageBox.Show("保存成功！");
                        this.cmbClass_SelectedIndexChanged(null, null);
                    }
                    catch (Exception exception)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void btTJ_Click(object sender, EventArgs e)
        {

            if ((this.lg != 0L) && (this.lg < 4L))
            {
                if (this.listView1.Items.Count == 0)
                {
                    MessageBox.Show("您还没有选择检验项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (MessageBox.Show("你确定要生成医嘱吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    this.cmbDept_SelectedIndexChanged(sender, e);
                    this.lbPrice.Text = "0.00 元";
                }
                else
                {
                    int num;
                    for (num = 0; num <= (this.chkListBox.CheckedItems.Count - 1); num++)
                    {
                        Item item = (Item)this.chkListBox.CheckedItems[num];
                        if (item.code < 0)
                        {
                            FrmSample sample = new FrmSample();
                            sample.item = item.ToString();
                            sample.sampleTb = this.sampleTb;
                            if (sample.ShowDialog() == DialogResult.OK)
                            {
                                item.sampleCode = sample.sampleCode;
                                int index = 0;
                                this.Issame(item.orderID.ToString(), out index);
                                if (index > 0)
                                {
                                    this.listView1.Items[index].SubItems[8].Text = sample.sampleCode.ToString();
                                }
                                continue;
                            }
                            MessageBox.Show("该检验项目没有设置标本，不能保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        item.sampleCode = item.code;
                    }
                    this.btTJ.Enabled = false;
                    long yzNum = 0L;
                    string str = "";
                    bool flag = true;
                    FrmMdiMain.Database.BeginTransaction();
                    yzNum = this.myQuery.GetYzNum(FrmMdiMain.Database, this.BinID);
                    DataTable dataTable = FrmMdiMain.Database.GetDataTable("select * from vi_zy_vinpatient_all where baby_id=0 and inpatient_id='" + this.BinID + "'");
                    int num4 = Convert.ToInt32(Convertor.IsNull(dataTable.Rows[0]["ybjklx"], "0"));
                    int yblx = Convert.ToInt32(Convertor.IsNull(dataTable.Rows[0]["yblx"], "0"));
                    int num6 = Convert.ToInt32(DbQuery.GetBrzt(this.BinID)[1]);
                    try
                    {
                        for (num = 0; num < this.listView1.Items.Count; num++)
                        {
                            ListViewItem item2 = this.listView1.Items[num];
                            string xmid = "";
                            if (!((!(new SystemCfg(0x1785).Config == "1") || (num4 <= 0)) || this.myQuery.isPP(long.Parse(item2.Tag.ToString()), yblx, ref xmid)))
                            {
                                MessageBox.Show(item2.SubItems[1].Text + "[" + xmid + "]没有进行医保匹配，不允许申请，将不会保存！");
                            }
                            else
                            {
                                yzNum += 1L;
                                string commandtext = string.Concat(new object[] { 
                                    "INSERT INTO ZY_ORDERRECORD(order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,nType,Order_Doc,HOItem_ID,xmly,Order_context,Num,Dosage,Unit,book_date,Order_bDate,First_times,Order_Usage,frequency,Operator,Delete_Bit,status_flag,baby_id,dept_br,exec_dept,dwlx,MEMO,MEMO1,jgbm,zsl)  VALUES('", PubStaticFun.NewGuid(), "',", yzNum.ToString(), ",'", this.BinID.ToString(), "',", this.DeptID.ToString(), ",'", this.WardID, "',1,5,", this.YS_ID.ToString(), ",", item2.Tag.ToString(), ",2,'", item2.SubItems[2].Text, 
                                    item2.SubItems[1].Text, "',", item2.SubItems[0].Text.ToString(), ",1,'", item2.SubItems[7].Text, "',GetDate(),GetDate(),0,'", item2.SubItems[9].Text, "','',", this.YS_ID.ToString(), ",0,0,", this.BabyID.ToString(), ",", (this.Dept_Br == 1L) ? this.DeptID : this.Dept_Br, ",", item2.SubItems[6].Text, ",", 
                                    item2.SubItems[8].Text, ",'", item2.SubItems[2].Text, "★", this.txtDiag.Text.Trim(), "','", this.txtDiag.Text.Trim(), "',", num6, ","+item2.SubItems[0].Text.ToString()+")"
                                 });
                                FrmMdiMain.Database.DoCommand(commandtext);
                                str = str + item2.SubItems[1].Text + "\n";
                            }
                        }
                        FrmMdiMain.Database.CommitTransaction();
                    }
                    catch (Exception exception)
                    {
                        FrmMdiMain.Database.RollbackTransaction();
                        flag = false;
                        MessageBox.Show("错误！\n" + exception.ToString() + "\n\n检验申请失败！");
                    }
                    finally
                    {
                        if (flag)
                        {
                            MessageBox.Show(str + "检验申请完成！\n成功生成医嘱！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        this.btTJ.Enabled = true;
                    }
                    this.SelectOne();
                    this.lbPrice.Text = "0.00 元";
                    base.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            int num = 0;
            for (int i = 0; (i - num) < this.listView1.Items.Count; i++)
            {
                if (!this.listView1.Items[i - num].Checked)
                {
                    continue;
                }
                string str = this.listView1.Items[i - num].Tag.ToString().Trim();
                this.listView1.Items[i - num].Remove();
                for (int j = 0; j < this.chkListBox.Items.Count; j++)
                {
                    Item item = (Item)this.chkListBox.Items[j];
                    if (str == item.orderID.ToString().Trim())
                    {
                        this.chkListBox.SetItemChecked(j, false);
                        break;
                    }
                }
                num++;
            }
            this.chkListBox_SelectedIndexChanged(sender, e);
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.listView1.Columns[6].Width = 0;
            this.GetlistHj();
        }
        private int pagecount = 0;
        private int currentpageno = 0;
        private int currentitem = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            this.pagecount = (this.listView1.Items.Count / 4) + 1;
            if ((this.listView1.Items.Count % 4) == 0)
            {
                this.pagecount = this.listView1.Items.Count / 4;
            }
            if (this.listView1.Items.Count != 0)
            {
                this.currentpageno = 0;
                this.currentitem = 0;
                this.printDocument1.DocumentName = this.pagecount.ToString();
                this.printDocument1.PrintPage -= new PrintPageEventHandler(this.printDocument1_PrintPage);
                this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
                PrintPreviewDialogEx ex = new PrintPreviewDialogEx();
                ex.Document = this.printDocument1;
                ex.OnPrintDy += new Exdy(this.prdlg_OnPrintDy);
                ex.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                this.listView1.Items[i].Checked = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                if (this.listView1.Items[i].Checked)
                {
                    this.listView1.Items[i].Checked = false;
                }
                else
                {
                    this.listView1.Items[i].Checked = true;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = 0; i < this.chkListBox.Items.Count; i++)
            {
                if (!this.chkListBox.GetItemChecked(i))
                {
                    continue;
                }
                Item item = (Item)this.chkListBox.Items[i];
                if (item.code < 0)
                {
                    FrmSample sample = new FrmSample();
                    sample.item = item.ToString();
                    sample.sampleTb = this.sampleTb;
                    if (sample.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("该检验项目没有设置标本，不能保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    item.sampleCode = sample.sampleCode;
                    DataRow[] rowArray = sample.sampleTb.Select("code='" + item.sampleCode + "'");
                    if ((rowArray != null) && (rowArray.Length > 0))
                    {
                        item.sample = rowArray[0]["name"].ToString().Trim();
                    }
                }
                else
                {
                    item.sampleCode = item.code;
                }
                decimal price = this.myQuery.GetPrice(item.orderID, FrmMdiMain.Jgbm);
                ListViewItem item2 = new ListViewItem(new string[] { "1", item.orderName, this.cmbFJ.Text, item.zxksmc, item.sample, price.ToString(), item.execDept.ToString(), item.orderUnit, item.sampleCode.ToString(), item.defaultUsage }, 0x11);
                item2.Tag = item.orderID;
                if ((item.FJSMBT == 1) && (this.cmbFJ.Text.Trim() == ""))
                {
                    str = str + "【" + item.orderName + "】\n";
                }
                else
                {
                    int index = 0;
                    if (!this.Issame(item.orderID.ToString(), out index))
                    {
                        this.listView1.Items.Add(item2);
                    }
                    this.chkListBox.SetItemChecked(i, false);
                }
            }
            if (str.Trim() != "")
            {
                MessageBox.Show(str + "必须填写附加说明，请选择附加说明！");
                this.cmbFJ.Focus();
            }
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.listView1.Columns[6].Width = 0;
            this.GetlistHj();
            this.cmbFJ.Text = "";
        }

        private void chkListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void chkListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!this.chkListBox.GetItemChecked(this.chkListBox.SelectedIndex))
                {
                    this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, true);
                }
                else
                {
                    this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, false);
                }
                this.chkListBox_SelectedIndexChanged(sender, e);
            }
        }

        private void chkListBox_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void chkListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label18.Text = this.showBZ();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.itemTb = this.GetItemID(Convert.ToInt64(this.cmbDept.SelectedValue), Convert.ToInt16(this.cmbClass.SelectedValue));
            this.chkListBox.Items.Clear();
            Item item = null;
            for (int i = 0; i <= (this.itemTb.Rows.Count - 1); i++)
            {
                item = new Item();
                item.orderID = Convert.ToInt32(this.itemTb.Rows[i]["order_id"]);
                item.orderName = this.itemTb.Rows[i]["order_name"].ToString().Trim();
                item.orderUnit = this.itemTb.Rows[i]["order_unit"].ToString();
                item.defaultUsage = this.itemTb.Rows[i]["default_usage"].ToString();
                item.execDept = Convert.ToInt32(this.itemTb.Rows[i]["default_dept"]);
                item.pym = this.itemTb.Rows[i]["py_code"].ToString();
                item.zxksmc = this.itemTb.Rows[i]["zxksmc"].ToString();
                item.code = Convert.ToInt32(Convertor.IsNull(this.itemTb.Rows[i]["code"], "-1"));
                item.sample = this.itemTb.Rows[i]["sample"].ToString();
                item.BZ = this.itemTb.Rows[i]["BZ"].ToString();
                item.FJSMBT = Convert.ToInt32(this.itemTb.Rows[i]["FJSMBT"].ToString());
                this.chkListBox.Items.Add(item);
            }
            this.txtDM.Focus();
            this.chkListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPrice.Text = "0.00 元";
            this.label18.Text = "";
            string commandtext = string.Concat(new object[] { "select -1 as id,'' as name union all select id,name from JC_JCHYTC_T where jgbm=", FrmMdiMain.Jgbm, " and class_id=", Convert.ToInt32(this.cmbClass.SelectedValue), " and (tclx=0 or (tclx=1 and syid=", FrmMdiMain.CurrentDept.DeptId, ") or (tclx=2 and syid=", FrmMdiMain.CurrentUser.EmployeeId, "))" });
            DataTable dataTable = FrmMdiMain.Database.GetDataTable(commandtext);
            this.cmbTc.DisplayMember = "NAME";
            this.cmbTc.ValueMember = "ID";
            this.cmbTc.DataSource = dataTable;
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string commandtext = "select distinct a.hylxid as ID,b.name as NAME from (select * from jc_assay where yzid in (select order_id from jc_hoi_dept where exec_DEPT=" + this.cmbDept.SelectedValue.ToString() + ")) a       left join (select * from jc_jcclassdiction where class_type=1) b on a.hylxid=b.ID order by hylxid ";
            DataTable dataTable = FrmMdiMain.Database.GetDataTable(commandtext);
            if (dataTable.Rows.Count == 0)
            {
                DataRow row = dataTable.NewRow();
                row["id"] = 0x270f;
                row["name"] = "全部";
                dataTable.Rows.InsertAt(row, 0);
            }
            this.cmbClass.DisplayMember = "NAME";
            this.cmbClass.ValueMember = "ID";
            this.cmbClass.DataSource = dataTable;
        }

        private void cmbFJ_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                if (this.listView1.Items[i].Checked)
                {
                    this.listView1.Items[i].SubItems[2].Text = this.cmbFJ.Text;
                }
            }
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void cmbFJcon()
        {
            DataTable dataTable = FrmMdiMain.Database.GetDataTable("select mc NAME,pym py from jc_param where lx=2");
            if (dataTable.Rows.Count != 0)
            {
                this.cmbFJ.Items.Clear();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    this.cmbFJ.Items.Add(dataTable.Rows[i]["NAME"].ToString());
                }
            }
        }

        private void cmbTc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cmbTc.SelectedValue) == -1)
            {
                this.cmbClass_SelectedIndexChanged(null, null);
            }
            else
            {
                int num;
                object obj2;
                string commandtext = "SELECT ORDER_ID, ORDER_NAME, ORDER_UNIT, DEFAULT_DEPT,LOWER(PY_CODE) PY_CODE,BZ,DEFAULT_USAGE,SAMPLE,CODE ,FJSMBT,   (select top 1 NAME from JC_DEPT_PROPERTY where JC_DEPT_PROPERTY.DEPT_ID=AA.DEFAULT_DEPT)  as DeptName ,AA.HYLXID,    (select top 1 name from jc_jcclassdiction where jc_jcclassdiction.ID=AA.HYLXID) as JCLXNaMe   FROM  (      SELECT A.ORDER_ID, A.ORDER_NAME, A.ORDER_UNIT, A.PY_CODE, A.BZ, A.DEFAULT_USAGE,      D.EXEC_DEPT AS DEFAULT_DEPT,SAMP_NAME SAMPLE,0 SORT_INDEX,C.SAMP_CODE CODE,FJSMBT,b.HYLXID       FROM (SELECT *      FROM JC_HOITEMDICTION      WHERE DELETE_BIT = 0 AND ORDER_TYPE = 5) A      INNER JOIN      JC_ASSAY B ON A.ORDER_ID = B.YZID ";
                if (this.cmbClass.SelectedValue.ToString() != "9999")
                {
                    obj2 = commandtext;
                    commandtext = string.Concat(new object[] { obj2, "  AND B.HYLXID= ", Convert.ToInt32(this.cmbClass.SelectedValue), " " });
                }
                obj2 = commandtext;
                commandtext = string.Concat(new object[] { obj2, "     INNER JOIN      JC_JCHYTC_MX F ON A.ORDER_ID = F.XMID      INNER JOIN      JC_JCHYTC_T E ON F.TCID = E.ID AND E.ID=", Convert.ToInt32(this.cmbTc.SelectedValue), "     INNER JOIN      JC_HOI_DEPT D ON A.ORDER_ID = D.ORDER_ID " });
                if (this.cmbDept.SelectedValue.ToString() != "9999")
                {
                    commandtext = commandtext + "  AND D.EXEC_DEPT= " + Convert.ToInt32(this.cmbDept.SelectedValue);
                }
                commandtext = commandtext + "     LEFT JOIN      LS_AS_SAMPLE C ON B.BBID=C.SAMP_CODE   ) AA  ORDER BY PY_CODE";
                this.itemTb = FrmMdiMain.Database.GetDataTable(commandtext);
                this.chkListBox.Items.Clear();
                Item item = null;
                for (num = 0; num <= (this.itemTb.Rows.Count - 1); num++)
                {
                    item = new Item();
                    item.orderID = Convert.ToInt32(this.itemTb.Rows[num]["order_id"]);
                    item.orderName = this.itemTb.Rows[num]["order_name"].ToString().Trim();
                    item.orderUnit = this.itemTb.Rows[num]["order_unit"].ToString();
                    item.defaultUsage = this.itemTb.Rows[num]["default_usage"].ToString();
                    item.execDept = Convert.ToInt32(this.itemTb.Rows[num]["default_dept"]);
                    item.pym = this.itemTb.Rows[num]["py_code"].ToString();
                    item.code = Convert.ToInt32(Convertor.IsNull(this.itemTb.Rows[num]["code"], "-1"));
                    item.sample = this.itemTb.Rows[num]["sample"].ToString();
                    item.BZ = this.itemTb.Rows[num]["BZ"].ToString();
                    item.FJSMBT = Convert.ToInt32(this.itemTb.Rows[num]["FJSMBT"].ToString());
                    item.zxksmc = this.itemTb.Rows[num]["DeptName"].ToString();
                    this.chkListBox.Items.Add(item);
                }
                this.txtDM.Focus();
                this.chkListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.lbPrice.Text = "0.00 元";
                this.label18.Text = "";
                for (num = 0; num <= (this.chkListBox.Items.Count - 1); num++)
                {
                    this.chkListBox.SetItemChecked(num, true);
                }
                this.chkListBox_SelectedIndexChanged(null, null);
            }
        }

        private void DelDataGridTextBox(DataGrid dg)
        {
            DataGridTextBoxColumn column = null;
            for (int i = 0; i < dg.TableStyles[0].GridColumnStyles.Count; i++)
            {
                column = (DataGridTextBoxColumn)dg.TableStyles[0].GridColumnStyles[i];
                column.TextBox.Parent.Controls.Remove(column.TextBox);
            }
        }



        private void FrmJYSQ_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.listView1.Focus();
            if (this.listView1.Controls.Count > 0)
            {
                e.Cancel = true;
            }
        }

        private void FrmJYSQ_Load(object sender, EventArgs e)
        {
            this.DtpbeginDate.Enabled = false;
            this.tabControl1.TabPages.Remove(this.tabPage1);
            this.listView1.MouseClick += new MouseEventHandler(this.listView1_MouseClick);
            this.patientBar1.PatientID = this.BinID;
            this.control_jysq1.textBoxEx1.Focus();
            if (this.patientBar1.IsLeave && (!_isHideJySq))
            {
                base.Close();
            }
            else
            {
                this.lbDateTime.Text = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToString();
                this.txtDiag.Text = this.patientBar1.lblDiag.Text.Trim();
                try
                {
                    if (this.txtDiag.Text.Trim() == "")
                    {
                        object[] mrDiagnoseOrContent = HisInterface.GetMrDiagnoseOrContent(this.BinID.ToString());
                        this.txtDiag.Text = Convertor.IsNull(mrDiagnoseOrContent[0], "");
                    }
                }
                catch (Exception)
                {
                }
                this.getDept();
                this.GrdJY.TableStyles.Add(this.GrdTableS);
                this.tm.Tick += new EventHandler(this.tm_Tick);
                this.tm.Interval = 1;
                if (this.chkListBox.Items.Count > 0)
                {
                    this.chkListBox.SelectedIndex = 0;
                }
                this.cmbFJcon();
                this.GetSample();
                this.ActiveControl = this.control_jysq1.textBoxEx1;
                this.control_jysq1.textBoxEx1.Focus();
            }

            //Modify By Tany 2015-04-08 赋值放前面，避免为空
            _Zyid = patientBar1.lblInpatientNo.Text;
            this.fylb = myQuery.GetTsxx(_Zyid);//武汉中心医院(Modify by jchl)
            
            control_jysq1._Zyid = _Zyid;
            control_jysq1.fylb = fylb;

            if (_isHideJySq)
            {
                DoHideTabOrder();
                tabControl1_SelectedIndexChanged(null, null);
            }
        }

        void control_jysq1_Close()
        {
            this.Close();
        }

        private void FrmJYSQ_Resize(object sender, EventArgs e)
        {
        }

        private void getDept()
        {
            DataTable dept = this.myQuery.GetDept(0, FrmMdiMain.Jgbm);
            if (dept.Rows.Count == 0)
            {
                MessageBox.Show("错误，未能取得化验科室信息！");
            }
            else
            {
                DataRow row = dept.NewRow();
                row["id"] = 0x270f;
                row["name"] = "全部";
                dept.Rows.InsertAt(row, 0);
                this.cmbDept.DisplayMember = "NAME";
                this.cmbDept.ValueMember = "ID";
                this.cmbDept.DataSource = dept;
                dept = null;
            }
        }

        private DataTable GetItemID(long deptID, short classType)
        {
            return this.myQuery.GetItem(deptID, classType, 0, InstanceForm._currentDept.DeptId);
        }

        private void GetlistHj()
        {
            decimal price = 0M;
            this.pr = 0M;
            for (int i = 0; i <= (this.listView1.Items.Count - 1); i++)
            {
                price = this.myQuery.GetPrice(long.Parse(this.listView1.Items[i].Tag.ToString()), FrmMdiMain.Jgbm) * long.Parse(this.listView1.Items[i].Text.ToString());
                this.pr += price;
            }
            if (this.chkListBox.CheckedItems.Count > 1)
            {
                this.lbPrice.Text = "合计 " + this.pr.ToString() + " 元";
            }
            else
            {
                this.lbPrice.Text = this.pr.ToString() + " 元";
            }
        }

        private DataTable GetQueryTb()
        {
            return this.myQuery.GetItemOrders(this.BinID, 0, FrmMdiMain.Jgbm);
        }

        private void GetSample()
        {
            this.sampleTb = this.myQuery.GetItem(1L, 1, 5);
        }

        private void GrdJY_CurrentCellChanged(object sender, EventArgs e)
        {
            this.GrdJY.Select(this.GrdJY.CurrentRowIndex);
        }

        private void GrdJY_DoubleClick(object sender, EventArgs e)
        {
            //武汉中心医院屏蔽 modify by jchl
            return;
            string str = "";
            if (this.mydt.Rows.Count != 0)
            {
                try
                {
                    DataTable report = this.myQuery.GetReport(new Guid(this.mydt.Rows[this.GrdJY.CurrentRowIndex]["ID"].ToString()), this.BinID);
                    string str2 = "";
                    string str3 = "";
                    string str4 = "";
                    if (report.Rows.Count > 0)
                    {
                        str = (this.mydt.Rows[this.GrdJY.CurrentRowIndex]["检验项目"].ToString().Trim().PadLeft(20, ' ') + "\n\n") + "项目名称".PadRight(20, ' ') + "结果值".PadRight(20, ' ') + "参考值范围\n";
                    }
                    for (int i = 0; i < report.Rows.Count; i++)
                    {
                        str2 = report.Rows[i]["item_name"].ToString().Trim();
                        str3 = report.Rows[i]["item_result"].ToString().Trim() + report.Rows[i]["unit"].ToString().Trim();
                        str4 = report.Rows[i]["upbound"].ToString().Trim() + "～" + report.Rows[i]["downbound"].ToString().Trim() + report.Rows[i]["unit"].ToString().Trim();
                        string str5 = str;
                        str = str5 + str2.PadRight(20, ' ') + str3.PadRight(20, ' ') + str4 + "\n";
                    }
                    this.richJY.Text = str;
                    this.panel7.Width = 50;
                    this.panel7.Height = 50;
                    this.panel7.Visible = true;
                    this.tm.Start();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        //private void InitializeComponent()
        // {
        //     this.components = new Container();
        //     ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmJYSQ));
        //     this.panel1 = new Panel();
        //     this.patientBar1 = new PatientBar();
        //     this.tabControl1 = new TabControl();
        //     this.tabPage1 = new TabPage();
        //     this.panel3 = new Panel();
        //     this.button6 = new Button();
        //     this.panel8 = new Panel();
        //     this.label19 = new Label();
        //     this.label11 = new Label();
        //     this.lbPrice = new Label();
        //     this.label17 = new Label();
        //     this.cmbFJ = new ComboBox();
        //     this.label18 = new Label();
        //     this.groupBox1 = new GroupBox();
        //     this.listView1 = new ListView();
        //     this.columnHeader1 = new ColumnHeader();
        //     this.columnHeader3 = new ColumnHeader();
        //     this.columnHeader2 = new ColumnHeader();
        //     this.columnHeader5 = new ColumnHeader();
        //     this.columnHeader4 = new ColumnHeader();
        //     this.columnHeader7 = new ColumnHeader();
        //     this.imageList1 = new ImageList(this.components);
        //     this.label1 = new Label();
        //     this.button1 = new Button();
        //     this.cmbTc = new ComboBox();
        //     this.txtDiag = new TextBox();
        //     this.label20 = new Label();
        //     this.cmbSample = new ComboBox();
        //     this.cmbClass = new ComboBox();
        //     this.label13 = new Label();
        //     this.lbDateTime = new Label();
        //     this.txtDM = new TextBox();
        //     this.label9 = new Label();
        //     this.chkListBox = new CheckedListBox();
        //     this.label14 = new Label();
        //     this.label15 = new Label();
        //     this.cmbDept = new ComboBox();
        //     this.label16 = new Label();
        //     this.lbCaption = new Label();
        //     this.panel2 = new Panel();
        //     this.btDelTC = new Button();
        //     this.btSaveTC = new Button();
        //     this.panel4 = new Panel();
        //     this.btClose = new Button();
        //     this.button4 = new Button();
        //     this.button3 = new Button();
        //     this.button2 = new Button();
        //     this.btTJ = new Button();
        //     this.tabPage2 = new TabPage();
        //     this.panel7 = new Panel();
        //     this.btPanel = new Button();
        //     this.richJY = new RichTextBox();
        //     this.label12 = new LabelEx(this.components);
        //     this.pictureBox2 = new PictureBox();
        //     this.pictureBox1 = new PictureBox();
        //     this.panel5 = new Panel();
        //     this.panel6 = new Panel();
        //     this.button5 = new Button();
        //     this.btPrint = new Button();
        //     this.lbprint = new Label();
        //     this.GrdJY = new DataGrid();
        //     this.imageList_tab = new ImageList(this.components);
        //     this.printDocument1 = new PrintDocument();
        //     this.printPreviewDialog1 = new PrintPreviewDialog();
        //     this.columnHeader8 = new ColumnHeader();
        //     ColumnHeader header = new ColumnHeader();
        //     this.panel1.SuspendLayout();
        //     this.tabControl1.SuspendLayout();
        //     this.tabPage1.SuspendLayout();
        //     this.panel3.SuspendLayout();
        //     this.panel8.SuspendLayout();
        //     this.groupBox1.SuspendLayout();
        //     this.panel2.SuspendLayout();
        //     this.panel4.SuspendLayout();
        //     this.tabPage2.SuspendLayout();
        //     this.panel7.SuspendLayout();
        //     ((ISupportInitialize)this.pictureBox2).BeginInit();
        //     ((ISupportInitialize)this.pictureBox1).BeginInit();
        //     this.panel5.SuspendLayout();
        //     this.panel6.SuspendLayout();
        //     this.GrdJY.BeginInit();
        //     base.SuspendLayout();
        //     header.Text = "执行科室id";
        //     header.Width = 0;
        //     this.panel1.Controls.Add(this.patientBar1);
        //     this.panel1.Dock = DockStyle.Top;
        //     this.panel1.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.panel1.Location = new Point(0, 0);
        //     this.panel1.Name = "panel1";
        //     this.panel1.Size = new Size(0x3cb, 0x48);
        //     this.panel1.TabIndex = 0;
        //     this.patientBar1.BorderType = PatientBar.BorderStyle.Raised;
        //     this.patientBar1.Dock = DockStyle.Fill;
        //     this.patientBar1.Location = new Point(0, 0);
        //     this.patientBar1.Name = "patientBar1";
        //     this.patientBar1.Size = new Size(0x3cb, 0x48);
        //     this.patientBar1.TabIndex = 0x25;
        //     this.tabControl1.Controls.Add(this.tabPage1);
        //     this.tabControl1.Controls.Add(this.tabPage2);
        //     this.tabControl1.Dock = DockStyle.Fill;
        //     this.tabControl1.Font = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.tabControl1.ImageList = this.imageList_tab;
        //     this.tabControl1.Location = new Point(0, 0x48);
        //     this.tabControl1.Multiline = true;
        //     this.tabControl1.Name = "tabControl1";
        //     this.tabControl1.Padding = new Point(6, 4);
        //     this.tabControl1.SelectedIndex = 0;
        //     this.tabControl1.Size = new Size(0x3cb, 0x1e9);
        //     this.tabControl1.TabIndex = 0;
        //     this.tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_SelectedIndexChanged);
        //     this.tabPage1.Controls.Add(this.panel3);
        //     this.tabPage1.Controls.Add(this.panel2);
        //     this.tabPage1.ForeColor = SystemColors.ControlText;
        //     this.tabPage1.ImageIndex = 0;
        //     this.tabPage1.Location = new Point(4, 0x1a);
        //     this.tabPage1.Name = "tabPage1";
        //     this.tabPage1.Size = new Size(0x3c3, 0x1cb);
        //     this.tabPage1.TabIndex = 0;
        //     this.tabPage1.Text = "检验申请录入";
        //     this.panel3.BackColor = Color.Honeydew;
        //     this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        //     this.panel3.Controls.Add(this.button6);
        //     this.panel3.Controls.Add(this.panel8);
        //     this.panel3.Controls.Add(this.groupBox1);
        //     this.panel3.Controls.Add(this.label1);
        //     this.panel3.Controls.Add(this.button1);
        //     this.panel3.Controls.Add(this.cmbTc);
        //     this.panel3.Controls.Add(this.txtDiag);
        //     this.panel3.Controls.Add(this.label20);
        //     this.panel3.Controls.Add(this.cmbSample);
        //     this.panel3.Controls.Add(this.cmbClass);
        //     this.panel3.Controls.Add(this.label13);
        //     this.panel3.Controls.Add(this.lbDateTime);
        //     this.panel3.Controls.Add(this.txtDM);
        //     this.panel3.Controls.Add(this.label9);
        //     this.panel3.Controls.Add(this.chkListBox);
        //     this.panel3.Controls.Add(this.label14);
        //     this.panel3.Controls.Add(this.label15);
        //     this.panel3.Controls.Add(this.cmbDept);
        //     this.panel3.Controls.Add(this.label16);
        //     this.panel3.Controls.Add(this.lbCaption);
        //     this.panel3.Dock = DockStyle.Fill;
        //     this.panel3.Location = new Point(0, 0);
        //     this.panel3.Name = "panel3";
        //     this.panel3.Size = new Size(0x3c3, 0x1a5);
        //     this.panel3.TabIndex = 0;
        //     this.panel3.Paint += new PaintEventHandler(this.panel3_Paint);
        //     this.button6.BackgroundImage = Resources.y;
        //     this.button6.Cursor = Cursors.Hand;
        //     this.button6.FlatStyle = FlatStyle.Flat;
        //     this.button6.Font = new Font("宋体", 10f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.button6.ForeColor = SystemColors.ControlText;
        //     this.button6.Image = Resources.y;
        //     this.button6.Location = new Point(0x22a, 0xb8);
        //     this.button6.Name = "button6";
        //     this.button6.Size = new Size(0x19, 0x18);
        //     this.button6.TabIndex = 0x62;
        //     this.button6.Text = " ";
        //     this.button6.TextAlign = ContentAlignment.BottomRight;
        //     this.button6.Click += new EventHandler(this.button6_Click);
        //     this.panel8.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
        //     this.panel8.Controls.Add(this.label19);
        //     this.panel8.Controls.Add(this.label11);
        //     this.panel8.Controls.Add(this.lbPrice);
        //     this.panel8.Controls.Add(this.label17);
        //     this.panel8.Controls.Add(this.cmbFJ);
        //     this.panel8.Controls.Add(this.label18);
        //     this.panel8.Location = new Point(6, 0x185);
        //     this.panel8.Name = "panel8";
        //     this.panel8.Size = new Size(0x3b0, 30);
        //     this.panel8.TabIndex = 0x61;
        //     this.label19.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
        //     this.label19.AutoSize = true;
        //     this.label19.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.label19.ForeColor = SystemColors.Desktop;
        //     this.label19.Location = new Point(0xf4, 7);
        //     this.label19.Name = "label19";
        //     this.label19.Size = new Size(0x43, 14);
        //     this.label19.TabIndex = 90;
        //     this.label19.Text = "备注信息";
        //     this.label19.TextAlign = ContentAlignment.MiddleCenter;
        //     this.label11.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
        //     this.label11.AutoSize = true;
        //     this.label11.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.label11.ForeColor = SystemColors.Desktop;
        //     this.label11.Location = new Point(0x231, 8);
        //     this.label11.Name = "label11";
        //     this.label11.Size = new Size(0x43, 14);
        //     this.label11.TabIndex = 9;
        //     this.label11.Text = "检验费：";
        //     this.label11.TextAlign = ContentAlignment.MiddleCenter;
        //     this.lbPrice.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
        //     this.lbPrice.AutoSize = true;
        //     this.lbPrice.BackColor = SystemColors.HighlightText;
        //     this.lbPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //     this.lbPrice.ForeColor = SystemColors.Desktop;
        //     this.lbPrice.Location = new Point(0x282, 6);
        //     this.lbPrice.Name = "lbPrice";
        //     this.lbPrice.Size = new Size(0x40, 0x11);
        //     this.lbPrice.TabIndex = 10;
        //     this.lbPrice.Text = "0.00 元";
        //     this.lbPrice.TextAlign = ContentAlignment.BottomCenter;
        //     this.label17.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
        //     this.label17.AutoSize = true;
        //     this.label17.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.label17.ForeColor = SystemColors.Desktop;
        //     this.label17.Location = new Point(1, 7);
        //     this.label17.Name = "label17";
        //     this.label17.Size = new Size(0x43, 14);
        //     this.label17.TabIndex = 0x57;
        //     this.label17.Text = "附加说明";
        //     this.label17.TextAlign = ContentAlignment.MiddleCenter;
        //     this.cmbFJ.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
        //     this.cmbFJ.Cursor = Cursors.Hand;
        //     this.cmbFJ.Font = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.cmbFJ.Location = new Point(0x45, 5);
        //     this.cmbFJ.Name = "cmbFJ";
        //     this.cmbFJ.Size = new Size(0xa9, 0x17);
        //     this.cmbFJ.TabIndex = 0x58;
        //     this.cmbFJ.TextChanged += new EventHandler(this.cmbFJ_TextChanged);
        //     this.label18.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
        //     this.label18.AutoSize = true;
        //     this.label18.BackColor = Color.FloralWhite;
        //     this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //     this.label18.ForeColor = SystemColors.ActiveCaption;
        //     this.label18.Location = new Point(0x138, 6);
        //     this.label18.Name = "label18";
        //     this.label18.Size = new Size(2, 0x11);
        //     this.label18.TabIndex = 0x59;
        //     this.label18.TextAlign = ContentAlignment.MiddleCenter;
        //     this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
        //     this.groupBox1.Controls.Add(this.listView1);
        //     this.groupBox1.Location = new Point(0x245, 3);
        //     this.groupBox1.Name = "groupBox1";
        //     this.groupBox1.Size = new Size(380, 0x182);
        //     this.groupBox1.TabIndex = 0x60;
        //     this.groupBox1.TabStop = false;
        //     this.groupBox1.Text = "已选择项目";
        //     this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        //     this.listView1.CheckBoxes = true;
        //     this.listView1.Columns.AddRange(new ColumnHeader[] { this.columnHeader8, this.columnHeader1, this.columnHeader3, this.columnHeader2, this.columnHeader5, this.columnHeader4, header, this.columnHeader7 });
        //     this.listView1.Dock = DockStyle.Fill;
        //     this.listView1.FullRowSelect = true;
        //     this.listView1.GridLines = true;
        //     this.listView1.LargeImageList = this.imageList1;
        //     this.listView1.Location = new Point(3, 20);
        //     this.listView1.Name = "listView1";
        //     this.listView1.Size = new Size(0x176, 0x16b);
        //     this.listView1.TabIndex = 0;
        //     this.listView1.UseCompatibleStateImageBehavior = false;
        //     this.listView1.View = View.Details;
        //     this.listView1.MouseClick += new MouseEventHandler(this.listView1_MouseClick);
        //     this.columnHeader1.Text = "项目名称";
        //     this.columnHeader1.Width = 200;
        //     this.columnHeader3.Text = "附加说明";
        //     this.columnHeader3.Width = 80;
        //     this.columnHeader2.Text = "执行科室";
        //     this.columnHeader2.Width = 80;
        //     this.columnHeader5.Text = "标本名称";
        //     this.columnHeader5.Width = 80;
        //     this.columnHeader4.Text = "价格";
        //     this.columnHeader7.Text = "单位";
        //     this.imageList1.ImageStream = (ImageListStreamer)manager.GetObject("imageList1.ImageStream");
        //     this.imageList1.TransparentColor = Color.Transparent;
        //     this.imageList1.Images.SetKeyName(0, "");
        //     this.imageList1.Images.SetKeyName(1, "");
        //     this.imageList1.Images.SetKeyName(2, "");
        //     this.imageList1.Images.SetKeyName(3, "");
        //     this.imageList1.Images.SetKeyName(4, "");
        //     this.imageList1.Images.SetKeyName(5, "");
        //     this.imageList1.Images.SetKeyName(6, "");
        //     this.imageList1.Images.SetKeyName(7, "");
        //     this.imageList1.Images.SetKeyName(8, "");
        //     this.imageList1.Images.SetKeyName(9, "");
        //     this.imageList1.Images.SetKeyName(10, "");
        //     this.imageList1.Images.SetKeyName(11, "");
        //     this.imageList1.Images.SetKeyName(12, "");
        //     this.imageList1.Images.SetKeyName(13, "");
        //     this.imageList1.Images.SetKeyName(14, "");
        //     this.imageList1.Images.SetKeyName(15, "");
        //     this.imageList1.Images.SetKeyName(0x10, "");
        //     this.imageList1.Images.SetKeyName(0x11, "indd.ico");
        //     this.label1.AutoSize = true;
        //     this.label1.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.label1.ForeColor = SystemColors.Desktop;
        //     this.label1.Location = new Point(0xab, 0x5b);
        //     this.label1.Name = "label1";
        //     this.label1.Size = new Size(0x43, 14);
        //     this.label1.TabIndex = 0x5f;
        //     this.label1.Text = "套餐选择";
        //     this.label1.TextAlign = ContentAlignment.MiddleCenter;
        //     this.button1.BackgroundImage = Resources.z;
        //     this.button1.Cursor = Cursors.Hand;
        //     this.button1.FlatStyle = FlatStyle.Flat;
        //     this.button1.Font = new Font("宋体", 10f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.button1.ForeColor = SystemColors.ControlText;
        //     this.button1.ImageAlign = ContentAlignment.MiddleLeft;
        //     this.button1.Location = new Point(0x22a, 0xd6);
        //     this.button1.Name = "button1";
        //     this.button1.Size = new Size(0x19, 0x18);
        //     this.button1.TabIndex = 6;
        //     this.button1.TextAlign = ContentAlignment.MiddleLeft;
        //     this.button1.Click += new EventHandler(this.button1_Click);
        //     this.cmbTc.DropDownStyle = ComboBoxStyle.DropDownList;
        //     this.cmbTc.FormattingEnabled = true;
        //     this.cmbTc.Location = new Point(240, 0x57);
        //     this.cmbTc.Name = "cmbTc";
        //     this.cmbTc.Size = new Size(0x8b, 0x17);
        //     this.cmbTc.TabIndex = 0x5e;
        //     this.cmbTc.SelectedIndexChanged += new EventHandler(this.cmbTc_SelectedIndexChanged);
        //     this.txtDiag.Font = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.txtDiag.Location = new Point(0x49, 0x3b);
        //     this.txtDiag.Name = "txtDiag";
        //     this.txtDiag.Size = new Size(0xb8, 0x18);
        //     this.txtDiag.TabIndex = 0x5c;
        //     this.label20.AutoSize = true;
        //     this.label20.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.label20.ForeColor = SystemColors.Desktop;
        //     this.label20.Location = new Point(3, 0x40);
        //     this.label20.Name = "label20";
        //     this.label20.Size = new Size(0x43, 14);
        //     this.label20.TabIndex = 0x5d;
        //     this.label20.Text = "临床诊断";
        //     this.label20.TextAlign = ContentAlignment.MiddleCenter;
        //     this.cmbSample.Cursor = Cursors.Hand;
        //     this.cmbSample.DropDownStyle = ComboBoxStyle.DropDownList;
        //     this.cmbSample.Font = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.cmbSample.Items.AddRange(new object[] { "生化室", "急诊生化室" });
        //     this.cmbSample.Location = new Point(450, 0x5b);
        //     this.cmbSample.Name = "cmbSample";
        //     this.cmbSample.Size = new Size(0x68, 0x17);
        //     this.cmbSample.TabIndex = 0x5b;
        //     this.cmbSample.Visible = false;
        //     this.cmbClass.Cursor = Cursors.Hand;
        //     this.cmbClass.DropDownStyle = ComboBoxStyle.DropDownList;
        //     this.cmbClass.Font = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.cmbClass.Location = new Point(260, 0x1f);
        //     this.cmbClass.Name = "cmbClass";
        //     this.cmbClass.Size = new Size(0x9d, 0x17);
        //     this.cmbClass.TabIndex = 2;
        //     this.cmbClass.SelectedIndexChanged += new EventHandler(this.cmbClass_SelectedIndexChanged);
        //     this.label13.AutoSize = true;
        //     this.label13.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.label13.ForeColor = SystemColors.Desktop;
        //     this.label13.Location = new Point(0x1a1, 0x21);
        //     this.label13.Name = "label13";
        //     this.label13.Size = new Size(0x16, 14);
        //     this.label13.TabIndex = 0x55;
        //     this.label13.Text = "室";
        //     this.label13.TextAlign = ContentAlignment.MiddleCenter;
        //     this.lbDateTime.AutoSize = true;
        //     this.lbDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //     this.lbDateTime.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.lbDateTime.Location = new Point(330, 0x3e);
        //     this.lbDateTime.Name = "lbDateTime";
        //     this.lbDateTime.Size = new Size(0x3a, 0x10);
        //     this.lbDateTime.TabIndex = 0x54;
        //     this.lbDateTime.Text = "label20";
        //     this.lbDateTime.TextAlign = ContentAlignment.MiddleLeft;
        //     this.txtDM.BackColor = Color.FloralWhite;
        //     this.txtDM.Font = new Font("宋体", 10f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.txtDM.Location = new Point(0x49, 0x58);
        //     this.txtDM.Name = "txtDM";
        //     this.txtDM.Size = new Size(0x58, 0x17);
        //     this.txtDM.TabIndex = 0;
        //     this.txtDM.Text = "<拼音码>";
        //     this.txtDM.TextChanged += new EventHandler(this.txtDM_TextChanged);
        //     this.txtDM.KeyDown += new KeyEventHandler(this.txtDM_KeyDown);
        //     this.txtDM.Leave += new EventHandler(this.txtDM_Leave);
        //     this.txtDM.Enter += new EventHandler(this.txtDM_Enter);
        //     this.label9.AutoSize = true;
        //     this.label9.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.label9.ForeColor = SystemColors.Desktop;
        //     this.label9.Location = new Point(3, 0x5b);
        //     this.label9.Name = "label9";
        //     this.label9.Size = new Size(0x43, 14);
        //     this.label9.TabIndex = 8;
        //     this.label9.Text = "检验项目";
        //     this.label9.TextAlign = ContentAlignment.MiddleCenter;
        //     this.chkListBox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
        //     this.chkListBox.BackColor = Color.FloralWhite;
        //     this.chkListBox.CheckOnClick = true;
        //     this.chkListBox.ColumnWidth = 280;
        //     this.chkListBox.Font = new Font("宋体", 10f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.chkListBox.ForeColor = SystemColors.WindowText;
        //     this.chkListBox.Location = new Point(6, 0x73);
        //     this.chkListBox.MultiColumn = true;
        //     this.chkListBox.Name = "chkListBox";
        //     this.chkListBox.Size = new Size(0x224, 0x112);
        //     this.chkListBox.TabIndex = 7;
        //     this.chkListBox.MouseClick += new MouseEventHandler(this.chkListBox_MouseClick);
        //     this.chkListBox.SelectedIndexChanged += new EventHandler(this.chkListBox_SelectedIndexChanged);
        //     this.chkListBox.ItemCheck += new ItemCheckEventHandler(this.chkListBox_ItemCheck);
        //     this.chkListBox.KeyDown += new KeyEventHandler(this.chkListBox_KeyDown);
        //     this.label14.AutoSize = true;
        //     this.label14.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.label14.ForeColor = SystemColors.Desktop;
        //     this.label14.Location = new Point(0x107, 0x40);
        //     this.label14.Name = "label14";
        //     this.label14.Size = new Size(0x4b, 14);
        //     this.label14.TabIndex = 5;
        //     this.label14.Text = "申请时间 ";
        //     this.label14.TextAlign = ContentAlignment.MiddleCenter;
        //     this.label15.AutoSize = true;
        //     this.label15.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.label15.ForeColor = SystemColors.Desktop;
        //     this.label15.Location = new Point(0x180, 0x5e);
        //     this.label15.Name = "label15";
        //     this.label15.Size = new Size(0x4b, 14);
        //     this.label15.TabIndex = 3;
        //     this.label15.Text = "送检标本 ";
        //     this.label15.TextAlign = ContentAlignment.MiddleCenter;
        //     this.label15.Visible = false;
        //     this.cmbDept.Cursor = Cursors.Hand;
        //     this.cmbDept.DropDownStyle = ComboBoxStyle.DropDownList;
        //     this.cmbDept.Font = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.cmbDept.Location = new Point(0x49, 0x1f);
        //     this.cmbDept.Name = "cmbDept";
        //     this.cmbDept.Size = new Size(0x9d, 0x17);
        //     this.cmbDept.TabIndex = 1;
        //     this.cmbDept.SelectedIndexChanged += new EventHandler(this.cmbDept_SelectedIndexChanged);
        //     this.label16.AutoSize = true;
        //     this.label16.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.label16.ForeColor = SystemColors.Desktop;
        //     this.label16.Location = new Point(3, 0x21);
        //     this.label16.Name = "label16";
        //     this.label16.Size = new Size(0x11b, 14);
        //     this.label16.TabIndex = 1;
        //     this.label16.Text = "请选择                           科";
        //     this.label16.TextAlign = ContentAlignment.MiddleCenter;
        //     this.lbCaption.AutoSize = true;
        //     this.lbCaption.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.lbCaption.ForeColor = SystemColors.Desktop;
        //     this.lbCaption.Location = new Point(0xfd, 1);
        //     this.lbCaption.Name = "lbCaption";
        //     this.lbCaption.Size = new Size(0x9a, 0x1f);
        //     this.lbCaption.TabIndex = 0;
        //     this.lbCaption.Text = "检验申请单";
        //     this.lbCaption.TextAlign = ContentAlignment.MiddleCenter;
        //     this.panel2.Controls.Add(this.btDelTC);
        //     this.panel2.Controls.Add(this.btSaveTC);
        //     this.panel2.Controls.Add(this.panel4);
        //     this.panel2.Controls.Add(this.button2);
        //     this.panel2.Controls.Add(this.btTJ);
        //     this.panel2.Dock = DockStyle.Bottom;
        //     this.panel2.Location = new Point(0, 0x1a5);
        //     this.panel2.Name = "panel2";
        //     this.panel2.Size = new Size(0x3c3, 0x26);
        //     this.panel2.TabIndex = 3;
        //     this.btDelTC.Cursor = Cursors.Hand;
        //     this.btDelTC.FlatStyle = FlatStyle.Flat;
        //     this.btDelTC.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.btDelTC.ForeColor = Color.MidnightBlue;
        //     this.btDelTC.ImageAlign = ContentAlignment.MiddleLeft;
        //     this.btDelTC.ImageIndex = 5;
        //     this.btDelTC.ImageList = this.imageList1;
        //     this.btDelTC.Location = new Point(0x144, 5);
        //     this.btDelTC.Name = "btDelTC";
        //     this.btDelTC.Size = new Size(0x79, 0x1c);
        //     this.btDelTC.TabIndex = 5;
        //     this.btDelTC.Text = "删除套餐(&D)";
        //     this.btDelTC.TextAlign = ContentAlignment.BottomRight;
        //     this.btDelTC.Click += new EventHandler(this.btDelTC_Click);
        //     this.btSaveTC.Cursor = Cursors.Hand;
        //     this.btSaveTC.FlatStyle = FlatStyle.Flat;
        //     this.btSaveTC.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.btSaveTC.ForeColor = Color.MidnightBlue;
        //     this.btSaveTC.ImageAlign = ContentAlignment.MiddleLeft;
        //     this.btSaveTC.ImageIndex = 0;
        //     this.btSaveTC.ImageList = this.imageList1;
        //     this.btSaveTC.Location = new Point(0xc5, 5);
        //     this.btSaveTC.Name = "btSaveTC";
        //     this.btSaveTC.Size = new Size(0x79, 0x1c);
        //     this.btSaveTC.TabIndex = 4;
        //     this.btSaveTC.Text = "保存套餐(&T)";
        //     this.btSaveTC.TextAlign = ContentAlignment.BottomRight;
        //     this.btSaveTC.Click += new EventHandler(this.btSaveTC_Click);
        //     this.panel4.Controls.Add(this.btClose);
        //     this.panel4.Controls.Add(this.button4);
        //     this.panel4.Controls.Add(this.button3);
        //     this.panel4.Dock = DockStyle.Right;
        //     this.panel4.Location = new Point(0x24d, 0);
        //     this.panel4.Name = "panel4";
        //     this.panel4.Size = new Size(0x176, 0x26);
        //     this.panel4.TabIndex = 3;
        //     this.btClose.Cursor = Cursors.Hand;
        //     this.btClose.FlatStyle = FlatStyle.Flat;
        //     this.btClose.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.btClose.ForeColor = Color.MidnightBlue;
        //     this.btClose.ImageAlign = ContentAlignment.MiddleLeft;
        //     this.btClose.ImageIndex = 1;
        //     this.btClose.ImageList = this.imageList1;
        //     this.btClose.Location = new Point(0xdf, 3);
        //     this.btClose.Name = "btClose";
        //     this.btClose.Size = new Size(0x58, 0x1c);
        //     this.btClose.TabIndex = 3;
        //     this.btClose.Text = "退出(&C)";
        //     this.btClose.TextAlign = ContentAlignment.BottomRight;
        //     this.btClose.Click += new EventHandler(this.btClose_Click);
        //     this.button4.Cursor = Cursors.Hand;
        //     this.button4.FlatStyle = FlatStyle.Flat;
        //     this.button4.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.button4.ForeColor = SystemColors.ActiveCaption;
        //     this.button4.ImageIndex = 5;
        //     this.button4.Location = new Point(0xa9, 3);
        //     this.button4.Name = "button4";
        //     this.button4.Size = new Size(0x30, 0x1c);
        //     this.button4.TabIndex = 8;
        //     this.button4.Text = "反选";
        //     this.button4.Click += new EventHandler(this.button4_Click);
        //     this.button3.Cursor = Cursors.Hand;
        //     this.button3.FlatStyle = FlatStyle.Flat;
        //     this.button3.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.button3.ForeColor = SystemColors.ActiveCaption;
        //     this.button3.ImageIndex = 5;
        //     this.button3.Location = new Point(0x73, 3);
        //     this.button3.Name = "button3";
        //     this.button3.Size = new Size(0x30, 0x1c);
        //     this.button3.TabIndex = 7;
        //     this.button3.Text = "全选";
        //     this.button3.Click += new EventHandler(this.button3_Click);
        //     this.button2.Cursor = Cursors.Hand;
        //     this.button2.FlatStyle = FlatStyle.Flat;
        //     this.button2.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.button2.ForeColor = Color.MidnightBlue;
        //     this.button2.ImageAlign = ContentAlignment.MiddleLeft;
        //     this.button2.ImageIndex = 14;
        //     this.button2.ImageList = this.imageList1;
        //     this.button2.Location = new Point(0x67, 5);
        //     this.button2.Name = "button2";
        //     this.button2.Size = new Size(0x58, 0x1c);
        //     this.button2.TabIndex = 1;
        //     this.button2.Text = "打印(&P)";
        //     this.button2.TextAlign = ContentAlignment.BottomRight;
        //     this.button2.Click += new EventHandler(this.button2_Click);
        //     this.btTJ.Cursor = Cursors.Hand;
        //     this.btTJ.FlatStyle = FlatStyle.Flat;
        //     this.btTJ.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.btTJ.ForeColor = Color.MidnightBlue;
        //     this.btTJ.ImageAlign = ContentAlignment.MiddleLeft;
        //     this.btTJ.ImageIndex = 0x10;
        //     this.btTJ.ImageList = this.imageList1;
        //     this.btTJ.Location = new Point(9, 5);
        //     this.btTJ.Name = "btTJ";
        //     this.btTJ.Size = new Size(0x58, 0x1c);
        //     this.btTJ.TabIndex = 0;
        //     this.btTJ.Text = "提交(&O)";
        //     this.btTJ.TextAlign = ContentAlignment.BottomRight;
        //     this.btTJ.Click += new EventHandler(this.btTJ_Click);
        //     this.tabPage2.Controls.Add(this.panel7);
        //     this.tabPage2.Controls.Add(this.panel5);
        //     this.tabPage2.Controls.Add(this.GrdJY);
        //     this.tabPage2.ImageIndex = 1;
        //     this.tabPage2.Location = new Point(4, 0x1a);
        //     this.tabPage2.Name = "tabPage2";
        //     this.tabPage2.Size = new Size(0x3c3, 0x1cb);
        //     this.tabPage2.TabIndex = 1;
        //     this.tabPage2.Text = "检验申请查询";
        //     this.tabPage2.Visible = false;
        //     this.panel7.BackColor = SystemColors.ActiveBorder;
        //     this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //     this.panel7.Controls.Add(this.btPanel);
        //     this.panel7.Controls.Add(this.richJY);
        //     this.panel7.Controls.Add(this.label12);
        //     this.panel7.Controls.Add(this.pictureBox2);
        //     this.panel7.Controls.Add(this.pictureBox1);
        //     this.panel7.Location = new Point(0x70, 0x18);
        //     this.panel7.Name = "panel7";
        //     this.panel7.Size = new Size(560, 0x128);
        //     this.panel7.TabIndex = 6;
        //     this.panel7.Visible = false;
        //     this.btPanel.BackColor = Color.Wheat;
        //     this.btPanel.Cursor = Cursors.Hand;
        //     this.btPanel.FlatStyle = FlatStyle.Popup;
        //     this.btPanel.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.btPanel.ImageAlign = ContentAlignment.MiddleLeft;
        //     this.btPanel.ImageIndex = 1;
        //     this.btPanel.ImageList = this.imageList1;
        //     this.btPanel.Location = new Point(0x1c8, 11);
        //     this.btPanel.Name = "btPanel";
        //     this.btPanel.Size = new Size(0x48, 0x18);
        //     this.btPanel.TabIndex = 4;
        //     this.btPanel.Text = "关闭";
        //     this.btPanel.TextAlign = ContentAlignment.TopRight;
        //     this.btPanel.UseVisualStyleBackColor = false;
        //     this.btPanel.Click += new EventHandler(this.btPanel_Click);
        //     this.richJY.BackColor = SystemColors.Window;
        //     this.richJY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //     this.richJY.Dock = DockStyle.Fill;
        //     this.richJY.Location = new Point(0, 0x2b);
        //     this.richJY.Name = "richJY";
        //     this.richJY.Size = new Size(0x22e, 0xf8);
        //     this.richJY.TabIndex = 3;
        //     this.richJY.Text = "";
        //     this.label12.BackColor1 = Color.DarkGoldenrod;
        //     this.label12.BackColor2 = Color.OldLace;
        //     this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //     this.label12.Dock = DockStyle.Top;
        //     this.label12.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
        //     this.label12.ForeColor = Color.DarkSlateGray;
        //     this.label12.Location = new Point(0, 3);
        //     this.label12.Name = "label12";
        //     this.label12.Size = new Size(0x22e, 40);
        //     this.label12.TabIndex = 2;
        //     this.label12.Text = "检验报告单";
        //     this.label12.TextAlign = ContentAlignment.BottomCenter;
        //     this.pictureBox2.Dock = DockStyle.Bottom;
        //     this.pictureBox2.Image = (Image)manager.GetObject("pictureBox2.Image");
        //     this.pictureBox2.Location = new Point(0, 0x123);
        //     this.pictureBox2.Name = "pictureBox2";
        //     this.pictureBox2.Size = new Size(0x22e, 3);
        //     this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        //     this.pictureBox2.TabIndex = 1;
        //     this.pictureBox2.TabStop = false;
        //     this.pictureBox1.Dock = DockStyle.Top;
        //     this.pictureBox1.Image = (Image)manager.GetObject("pictureBox1.Image");
        //     this.pictureBox1.Location = new Point(0, 0);
        //     this.pictureBox1.Name = "pictureBox1";
        //     this.pictureBox1.Size = new Size(0x22e, 3);
        //     this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //     this.pictureBox1.TabIndex = 0;
        //     this.pictureBox1.TabStop = false;
        //     this.panel5.Controls.Add(this.panel6);
        //     this.panel5.Controls.Add(this.btPrint);
        //     this.panel5.Controls.Add(this.lbprint);
        //     this.panel5.Dock = DockStyle.Bottom;
        //     this.panel5.Location = new Point(0, 0x187);
        //     this.panel5.Name = "panel5";
        //     this.panel5.Size = new Size(0x3c3, 0x44);
        //     this.panel5.TabIndex = 5;
        //     this.panel6.Controls.Add(this.button5);
        //     this.panel6.Dock = DockStyle.Right;
        //     this.panel6.Location = new Point(0x30b, 0);
        //     this.panel6.Name = "panel6";
        //     this.panel6.Size = new Size(0xb8, 0x44);
        //     this.panel6.TabIndex = 7;
        //     this.button5.FlatStyle = FlatStyle.Flat;
        //     this.button5.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.button5.ForeColor = Color.Navy;
        //     this.button5.ImageAlign = ContentAlignment.MiddleLeft;
        //     this.button5.ImageIndex = 1;
        //     this.button5.ImageList = this.imageList1;
        //     this.button5.Location = new Point(8, 20);
        //     this.button5.Name = "button5";
        //     this.button5.Size = new Size(0x58, 0x1c);
        //     this.button5.TabIndex = 4;
        //     this.button5.Text = "退出(&C)";
        //     this.button5.TextAlign = ContentAlignment.BottomRight;
        //     this.button5.Click += new EventHandler(this.btClose_Click);
        //     this.btPrint.FlatStyle = FlatStyle.Flat;
        //     this.btPrint.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        //     this.btPrint.ForeColor = Color.Navy;
        //     this.btPrint.ImageAlign = ContentAlignment.MiddleLeft;
        //     this.btPrint.ImageIndex = 14;
        //     this.btPrint.ImageList = this.imageList1;
        //     this.btPrint.Location = new Point(0x58, 20);
        //     this.btPrint.Name = "btPrint";
        //     this.btPrint.Size = new Size(0x58, 0x1c);
        //     this.btPrint.TabIndex = 6;
        //     this.btPrint.Text = "打印(&P)";
        //     this.btPrint.TextAlign = ContentAlignment.BottomRight;
        //     this.btPrint.Visible = false;
        //     this.btPrint.Click += new EventHandler(this.btPrint_Click);
        //     this.lbprint.Location = new Point(0xb8, 0x18);
        //     this.lbprint.Name = "lbprint";
        //     this.lbprint.Size = new Size(0x130, 0x17);
        //     this.lbprint.TabIndex = 5;
        //     this.GrdJY.AllowSorting = false;
        //     this.GrdJY.AlternatingBackColor = SystemColors.ScrollBar;
        //     this.GrdJY.BackgroundColor = Color.Gray;
        //     this.GrdJY.DataMember = "";
        //     this.GrdJY.Dock = DockStyle.Top;
        //     this.GrdJY.GridLineColor = SystemColors.Desktop;
        //     this.GrdJY.HeaderForeColor = SystemColors.ControlText;
        //     this.GrdJY.Location = new Point(0, 0);
        //     this.GrdJY.Name = "GrdJY";
        //     this.GrdJY.Size = new Size(0x3c3, 380);
        //     this.GrdJY.TabIndex = 0;
        //     this.GrdJY.DoubleClick += new EventHandler(this.GrdJY_DoubleClick);
        //     this.GrdJY.CurrentCellChanged += new EventHandler(this.GrdJY_CurrentCellChanged);
        //     this.imageList_tab.ImageStream = (ImageListStreamer)manager.GetObject("imageList_tab.ImageStream");
        //     this.imageList_tab.TransparentColor = Color.Transparent;
        //     this.imageList_tab.Images.SetKeyName(0, "");
        //     this.imageList_tab.Images.SetKeyName(1, "");
        //     this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
        //     this.printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
        //     this.printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
        //     this.printPreviewDialog1.ClientSize = new Size(400, 300);
        //     this.printPreviewDialog1.Document = this.printDocument1;
        //     this.printPreviewDialog1.Enabled = true;
        //     this.printPreviewDialog1.Icon = (Icon)manager.GetObject("printPreviewDialog1.Icon");
        //     this.printPreviewDialog1.Name = "printPreviewDialog1";
        //     this.printPreviewDialog1.Visible = false;
        //     this.columnHeader8.Text = "数量";
        //     this.AutoScaleBaseSize = new Size(6, 14);
        //     base.ClientSize = new Size(0x3cb, 0x231);
        //     base.Controls.Add(this.tabControl1);
        //     base.Controls.Add(this.panel1);
        //     base.Name = "FrmJYSQ";
        //     base.StartPosition = FormStartPosition.CenterScreen;
        //     this.Text = "检验申请";
        //     base.Load += new EventHandler(this.FrmJYSQ_Load);
        //     base.Resize += new EventHandler(this.FrmJYSQ_Resize);
        //     this.panel1.ResumeLayout(false);
        //     this.tabControl1.ResumeLayout(false);
        //     this.tabPage1.ResumeLayout(false);
        //     this.panel3.ResumeLayout(false);
        //     this.panel3.PerformLayout();
        //     this.panel8.ResumeLayout(false);
        //     this.panel8.PerformLayout();
        //     this.groupBox1.ResumeLayout(false);
        //     this.panel2.ResumeLayout(false);
        //     this.panel4.ResumeLayout(false);
        //     this.tabPage2.ResumeLayout(false);
        //     this.panel7.ResumeLayout(false);
        //     ((ISupportInitialize)this.pictureBox2).EndInit();
        //     ((ISupportInitialize)this.pictureBox1).EndInit();
        //     this.panel5.ResumeLayout(false);
        //     this.panel6.ResumeLayout(false);
        //     this.GrdJY.EndInit();
        //     base.ResumeLayout(false);
        // }

        private bool Issame(string orderid, out int index)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                if (this.listView1.Items[i].Tag.ToString() == orderid)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = this.listView1.HitTest(e.Location);
            if (((info.Item != null) && (info.SubItem != null)) && ((info.Item.SubItems.IndexOf(info.SubItem) == 0) && (info.Item == this.listView1.FocusedItem)))
            {
                TextBox box = new TextBox();
                box.KeyPress += new KeyPressEventHandler(this.tb_KeyPress);
                box.LostFocus += new EventHandler(this.tb_LostFocus);
                box.Width = this.listView1.Columns[0].Width;
                box.Height = this.listView1.FocusedItem.Bounds.Height - 5;
                box.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.listView1.Controls.Add(box);
                box.Text = this.listView1.FocusedItem.Text;
                box.Location = this.listView1.FocusedItem.Bounds.Location;
                box.Focus();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void prdlg_OnPrintDy()
        {
            this.currentitem = 0;
            this.currentpageno = 0;
        }

        private string priceHJ(DataTable myTb)
        {
            decimal num = 0M;
            for (int i = 0; i <= (myTb.Rows.Count - 1); i++)
            {
                if (myTb.Rows[i]["检验费"] != DBNull.Value)
                {
                    num += Convert.ToDecimal(myTb.Rows[i]["检验费"].ToString().Trim());
                }
            }
            return num.ToString().Trim();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int num = 0;
            this.brush = new SolidBrush(Color.FromArgb(0xec, 0xec, 0xec));
            this.font = new Font("宋体", 20f, FontStyle.Italic);
            for (int i = 0; i <= 5; i++)
            {
                for (int k = 0; k <= 40; k++)
                {
                    if ((k % 2) == 0)
                    {
                        num = (i * 160) + 30;
                    }
                    else
                    {
                        num = (i * 160) - 30;
                    }
                    e.Graphics.DrawString("检验申请单", this.font, this.brush, (float)num, (float)(k * 0x23));
                }
            }
            string s = this.cmbDept.Text.Trim() + "检验申请单";
            int num4 = 0;
            int num5 = 1;
            int left = e.MarginBounds.Left;
            int top = e.MarginBounds.Top;
            int num8 = Convert.ToInt16((int)((e.MarginBounds.Width - (s.Length * 0x1b)) / 2));
            string commandtext = "select name from jc_employee_property where employee_id=" + this.YS_ID.ToString();
            string str3 = FrmMdiMain.Database.GetDataTable(commandtext).Rows[0]["name"].ToString().Trim();
            for (int j = this.currentitem; j <= (this.listView1.Items.Count - 1); j++)
            {
                s = this.listView1.Items[j].SubItems[3].Text + "检验申请单";
                this.brush = new SolidBrush(Color.SteelBlue);
                this.font = new Font("楷体_GB2312", 20f, FontStyle.Bold);
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                e.Graphics.DrawString(s, this.font, this.brush, (float)(left + num8), (float)(top + num4), StringFormat.GenericTypographic);
                this.brush = new SolidBrush(Color.Black);
                this.font = new Font("宋体", 11f, FontStyle.Bold);
                e.Graphics.DrawString("姓名：" + this.patientBar1.lblName.Text, this.font, this.brush, (float)left, (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("性别：" + this.patientBar1.lblSex.Text, this.font, this.brush, (float)(130 + left), (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("年龄：" + this.patientBar1.lblage.Text, this.font, this.brush, (float)(220 + left), (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("病区：" + this.patientBar1.lblWard.Text, this.font, this.brush, (float)(300 + left), (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("床号：" + this.patientBar1.lblBedNo.Text, this.font, this.brush, (float)((390 + left) + 80), (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("住院号：" + this.patientBar1.lblInpatientNo.Text, this.font, this.brush, (float)((470 + left) + 80), (float)((60 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("临床诊断：" + this.patientBar1.lblDiag.Text, this.font, this.brush, (float)left, (float)((100 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("送检标本：" + this.listView1.Items[j].SubItems[4].Text, this.font, this.brush, (float)(300 + left), (float)((100 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("申请日期：" + this.lbDateTime.Text, this.font, this.brush, (float)(470 + left), (float)((100 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("检验项目：" + this.listView1.Items[j].SubItems[1].Text, this.font, this.brush, (float)left, (float)((140 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawString("申请医师：" + str3, this.font, this.brush, (float)(470 + left), (float)((190 + top) + num4), StringFormat.GenericTypographic);
                e.Graphics.DrawLine(new Pen(Color.Black, 1f), (int)(20 + left), (int)((230 + top) + num4), (int)((left + e.MarginBounds.Width) - 20), (int)((230 + top) + num4));
                if (((j + 1) % 4) == 0)
                {
                    this.currentpageno++;
                    num5++;
                    this.currentitem++;
                    num4 -= num5 * (e.MarginBounds.Bottom - e.MarginBounds.Top);
                    break;
                }
                num4 += 280;
                this.currentitem++;
                if (j == (this.listView1.Items.Count - 1))
                {
                    this.currentpageno++;
                }
            }
            if (this.pagecount > this.currentpageno)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                return;
            }
            this.brush.Dispose();
            this.font.Dispose();
        }

        public void ReadXMLReport(string strXML, Control ctl)
        {
            try
            {
                StringReader reader = new StringReader(strXML);
                XmlDataDocument document = new XmlDataDocument();
                document.DataSet.ReadXml(reader);
                DataTable table = document.DataSet.Tables[0];
                if (table != null)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        Font font;
                        if (Convert.ToInt32(table.Rows[i]["iBold"]) == 1)
                        {
                            font = new Font("宋体", (float)Convert.ToInt32(table.Rows[i]["iSIZE"]), FontStyle.Bold);
                        }
                        else
                        {
                            font = new Font("宋体", (float)Convert.ToInt32(table.Rows[i]["iSIZE"]));
                        }
                        if (Convert.ToString(table.Rows[i]["sTYPE"]).Trim() == "XT_LABEL")
                        {
                            Label label = new Label();
                            label.Location = new Point(Convert.ToInt32(table.Rows[i]["iPTX"]), Convert.ToInt32(table.Rows[i]["iPTY"]));
                            label.Width = Convert.ToInt32(table.Rows[i]["iWIDTH"]);
                            label.Height = Convert.ToInt32(table.Rows[i]["iHEIGHT"]);
                            label.Text = Convert.ToString(table.Rows[i]["sTEXT"]);
                            label.Font = font;
                            ctl.Controls.Add(label);
                        }
                        else if (Convert.ToString(table.Rows[i]["sTYPE"]).Trim() == "XT_TEXT")
                        {
                            TextBox box = new TextBox();
                            box.Location = new Point(Convert.ToInt32(table.Rows[i]["iPTX"]), Convert.ToInt32(table.Rows[i]["iPTY"]));
                            box.Multiline = true;
                            box.Width = Convert.ToInt32(table.Rows[i]["iWIDTH"]);
                            box.Height = Convert.ToInt32(table.Rows[i]["iHEIGHT"]);
                            box.Text = Convert.ToString(table.Rows[i]["sTEXT"]);
                            box.Font = font;
                            ctl.Controls.Add(box);
                        }
                        else if (Convert.ToString(table.Rows[i]["sTYPE"]).Trim() == "XT_DATETIME")
                        {
                            DateTimePicker picker = new DateTimePicker();
                            picker.Location = new Point(Convert.ToInt32(table.Rows[i]["iPTX"]), Convert.ToInt32(table.Rows[i]["iPTY"]));
                            picker.Width = Convert.ToInt32(table.Rows[i]["iWIDTH"]);
                            picker.Height = Convert.ToInt32(table.Rows[i]["iHEIGHT"]);
                            picker.Value = Convert.ToDateTime(table.Rows[i]["sTEXT"]);
                            picker.Font = font;
                            ctl.Controls.Add(picker);
                        }
                        else if (Convert.ToString(table.Rows[i]["sTYPE"]).Trim() == "XT_CHECK")
                        {
                            CheckBox box2 = new CheckBox();
                            box2.Location = new Point(Convert.ToInt32(table.Rows[i]["iPTX"]), Convert.ToInt32(table.Rows[i]["iPTY"]));
                            box2.Width = Convert.ToInt32(table.Rows[i]["iWIDTH"]);
                            box2.Height = Convert.ToInt32(table.Rows[i]["iHEIGHT"]);
                            box2.Text = Convert.ToString(table.Rows[i]["sTEXT"]);
                            box2.Checked = Convert.ToInt32(table.Rows[i]["iVALUE"]) == 1;
                            box2.Font = font;
                            ctl.Controls.Add(box2);
                        }
                        else if (Convert.ToString(table.Rows[i]["sTYPE"]).Trim() == "XT_RADIO")
                        {
                            RadioButton button = new RadioButton();
                            button.Location = new Point(Convert.ToInt32(table.Rows[i]["iPTX"]), Convert.ToInt32(table.Rows[i]["iPTY"]));
                            button.Width = Convert.ToInt32(table.Rows[i]["iWIDTH"]);
                            button.Height = Convert.ToInt32(table.Rows[i]["iHEIGHT"]);
                            button.Text = Convert.ToString(table.Rows[i]["sTEXT"]);
                            button.Checked = Convert.ToInt32(table.Rows[i]["iVALUE"]) == 1;
                            button.Font = font;
                            ctl.Controls.Add(button);
                        }
                    }
                    table = null;
                    document = null;
                    reader = null;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("读取XML报告出错\n" + exception.Message);
            }
        }

        private void SelectOne()
        {
            for (int i = 0; i < this.chkListBox.Items.Count; i++)
            {
                this.chkListBox.SetItemChecked(i, false);
            }
        }

        private string showBZ()
        {
            if (this.chkListBox.SelectedItem == null)
            {
                return "";
            }
            return ((Item)this.chkListBox.SelectedItem).BZ.ToString().Trim();
        }

        public void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            this.Text = this.tabControl1.SelectedTab.Text;
            if (tabControl1.SelectedTab == tabPage2)
            {
                this.mydt = this.GetQueryTb();
                if (this.mydt.Rows.Count != 0)
                {
                    this.GrdJY.DataSource = this.mydt;
                    this.GrdJY.ReadOnly = true;
                    this.GrdJY.CaptionText = "患者：" + this.patientBar1.lblName.Text.Trim() + "                                                          费用合计：" + this.priceHJ(this.mydt) + " 元";
                    this.GrdJY.TableStyles[0].AllowSorting = false;
                    this.GrdJY.TableStyles[0].GridColumnStyles[0].Width = 0;
                    this.GrdJY.TableStyles[0].GridColumnStyles[1].Width = 100;
                    this.GrdJY.TableStyles[0].GridColumnStyles[2].Width = 60;
                    this.GrdJY.TableStyles[0].GridColumnStyles[3].Width = 200;
                    this.GrdJY.TableStyles[0].GridColumnStyles[4].Width = 100;
                    this.GrdJY.TableStyles[0].GridColumnStyles[5].Alignment = HorizontalAlignment.Right;
                    this.GrdJY.TableStyles[0].GridColumnStyles[5].Width = 60;
                    this.GrdJY.TableStyles[0].GridColumnStyles[6].Alignment = HorizontalAlignment.Center;
                    this.GrdJY.TableStyles[0].GridColumnStyles[6].Width = 70;
                    this.GrdJY.TableStyles[0].GridColumnStyles[7].Alignment = HorizontalAlignment.Center;
                    this.GrdJY.TableStyles[0].GridColumnStyles[7].Width = 100;
                    this.DelDataGridTextBox(this.GrdJY);
                }
            }
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    if (int.Parse((sender as TextBox).Text.Trim()) <= 0)
                    {
                        (sender as TextBox).LostFocus -= new EventHandler(this.tb_LostFocus);
                        MessageBox.Show("请输入大于0的整数");
                        (sender as TextBox).LostFocus += new EventHandler(this.tb_LostFocus);
                        (sender as TextBox).Focus();
                        return;
                    }
                }
                catch
                {
                    (sender as TextBox).LostFocus -= new EventHandler(this.tb_LostFocus);
                    MessageBox.Show("请输入数字");
                    (sender as TextBox).LostFocus += new EventHandler(this.tb_LostFocus);
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
                catch
                {
                }
            }
            if (e.KeyChar == '\x001b')
            {
                (sender as TextBox).LostFocus -= new EventHandler(this.tb_LostFocus);
                (sender as TextBox).Dispose();
            }
            this.GetlistHj();
        }

        private void tb_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse((sender as TextBox).Text.Trim()) <= 0)
                {
                    (sender as TextBox).LostFocus -= new EventHandler(this.tb_LostFocus);
                    (sender as TextBox).LostFocus -= new EventHandler(this.tb_LostFocus);
                    MessageBox.Show("请输入大于0的整数");
                    (sender as TextBox).LostFocus += new EventHandler(this.tb_LostFocus);
                    (sender as TextBox).Focus();
                    return;
                }
                this.listView1.Items[this.listView1.FocusedItem.Index].SubItems[0].Text = (sender as TextBox).Text;
            }
            catch
            {
                (sender as TextBox).LostFocus -= new EventHandler(this.tb_LostFocus);
                (sender as TextBox).LostFocus -= new EventHandler(this.tb_LostFocus);
                MessageBox.Show("请输入数字");
                (sender as TextBox).LostFocus += new EventHandler(this.tb_LostFocus);
                (sender as TextBox).Focus();
                return;
            }
            (sender as TextBox).Dispose();
            this.GetlistHj();
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            if (this.panel7.Width <= 0x220)
            {
                this.panel7.Width += 6;
            }
            else
            {
                this.tm.Stop();
            }
            if (this.panel7.Height <= 0x150)
            {
                this.panel7.Height += 4;
            }
        }

        private void txtDM_Enter(object sender, EventArgs e)
        {
            this.txtDM.Text = "";
            this.txtDM.BackColor = Color.White;
        }

        private void txtDM_KeyDown(object sender, KeyEventArgs e)
        {
            int selectedIndex = this.chkListBox.SelectedIndex;
            if ((e.KeyValue == 13) && (this.chkListBox.SelectedItems.Count != 0))
            {
                if (!this.chkListBox.GetItemChecked(selectedIndex))
                {
                    this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, true);
                }
                else
                {
                    this.chkListBox.SetItemChecked(this.chkListBox.SelectedIndex, false);
                }
                this.chkListBox_SelectedIndexChanged(sender, e);
                this.txtDM.Text = "";
                this.chkListBox.SelectedIndex = selectedIndex;
            }
            if ((e.KeyValue == 40) && (selectedIndex < (this.chkListBox.Items.Count - 1)))
            {
                this.chkListBox.SelectedIndex++;
            }
            if ((e.KeyValue == 0x27) && ((selectedIndex + 8) < this.chkListBox.Items.Count))
            {
                this.chkListBox.SelectedIndex += 8;
            }
            if ((e.KeyValue == 0x26) && (selectedIndex > 0))
            {
                this.chkListBox.SelectedIndex--;
            }
            if ((e.KeyValue == 0x25) && ((selectedIndex - 8) >= 0))
            {
                this.chkListBox.SelectedIndex -= 8;
            }
            this.label18.Text = this.showBZ();
        }

        private void txtDM_Leave(object sender, EventArgs e)
        {
            this.txtDM.Text = "<拼音码>";
            this.txtDM.BackColor = Color.FloralWhite;
        }

        private void txtDM_TextChanged(object sender, EventArgs e)
        {
            Item item = null;
            for (int i = 0; i < this.chkListBox.Items.Count; i++)
            {
                item = (Item)this.chkListBox.Items[i];
                if (item.pym.IndexOf(this.txtDM.Text.Trim().ToLower(), 0) == 0)
                {
                    this.chkListBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

            try
            {
                string strUrl = GetIniString("武汉市中心医院", "QueryUrl", System.Windows.Forms.Application.StartupPath + "\\LisInterface.ini");
                strUrl += ConvertNo(_Zyid);

                DoQueryJcJyInfo(strUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询结果出错 \n" + ex.Message + "\n" + ex.StackTrace, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, System.Text.StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="lpApplicationName">节名</param>
        /// <param name="lpKeyName">关键字</param>
        /// <param name="lpFileName">INI文件路径</param>
        /// <returns></returns>
        public string GetIniString(string lpApplicationName, string lpKeyName, string lpFileName)
        {
            System.Text.StringBuilder strReturn = new System.Text.StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }

        private void btnAllPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ts_zyhs_jyddy.InstanceForm.BDatabase = InstanceForm._database;
                ts_zyhs_jyddy.InstanceForm.BCurrentDept = InstanceForm._currentDept;
                ts_zyhs_jyddy.InstanceForm.BCurrentUser = InstanceForm._currentUser;
                frmjyd jyd_jchl = new frmjyd("检验单打印", 0);

                //jyd_jchl.MdiParent = this.MdiParent;
                //jyd_jchl.txtApplyDoc.Text =  InstanceForm._currentUser.Name;
                //jyd_jchl.txtApplyDoc.Tag = InstanceForm._currentUser.EmployeeId;
                //jyd_jchl.chkApplyDoc.Enabled = false;
                //jyd_jchl.chkApplyDoc.Enabled = false;
                //jyd_jchl.txtApplyDoc.Enabled = false;

                jyd_jchl.chkbq.Checked = false;
                jyd_jchl.chksqd.Checked = true;

                jyd_jchl.txtzyh.Enabled = false;
                jyd_jchl.txtzyh.Text = patientBar1.lblInpatientNo.Text;
                jyd_jchl.txtcwh.Enabled = false;
                jyd_jchl.txtcwh.Text = patientBar1.lblBedNo.Text;
                jyd_jchl.txtname.Enabled = false;
                jyd_jchl.txtname.Text = patientBar1.lblName.Text;

                jyd_jchl.WindowState = FormWindowState.Normal;
                jyd_jchl.StartPosition = FormStartPosition.CenterScreen;
                jyd_jchl.Show();
                jyd_jchl.btnRefresh_Click(null, null);
            }
            catch { }
        }

        private void btnSinglePrint_Click(object sender, EventArgs e)
        {
            try
            {
                ts_zyhs_jyddy.InstanceForm.BDatabase = InstanceForm._database;
                ts_zyhs_jyddy.InstanceForm.BCurrentDept = InstanceForm._currentDept;
                ts_zyhs_jyddy.InstanceForm.BCurrentUser = InstanceForm._currentUser;
                frmjyd jyd_jchl = new frmjyd("检验单打印", 0);

                //jyd_jchl.MdiParent = this.MdiParent;
                //jyd_jchl.txtApplyDoc.Text = InstanceForm._currentUser.Name;
                //jyd_jchl.txtApplyDoc.Tag = InstanceForm._currentUser.EmployeeId;
                //jyd_jchl.chkApplyDoc.Enabled = false;
                //jyd_jchl.chkApplyDoc.Enabled = false;
                //jyd_jchl.txtApplyDoc.Enabled = false;

                jyd_jchl.chkbq.Checked = true;
                jyd_jchl.chksqd.Checked = false;

                jyd_jchl.txtzyh.Enabled = false;
                jyd_jchl.txtzyh.Text = patientBar1.lblInpatientNo.Text;
                jyd_jchl.txtcwh.Enabled = false;
                jyd_jchl.txtcwh.Text = patientBar1.lblBedNo.Text;
                jyd_jchl.txtname.Enabled = false;
                jyd_jchl.txtname.Text = patientBar1.lblName.Text;

                jyd_jchl.WindowState = FormWindowState.Normal;
                jyd_jchl.StartPosition = FormStartPosition.CenterScreen;
                jyd_jchl.Show();
                jyd_jchl.btnRefresh_Click(null, null);
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string strUrl = GetIniString("武汉市中心医院", "PrintUrl", System.Windows.Forms.Application.StartupPath + "\\LisInterface.ini");
                strUrl += ConvertNo(_Zyid);

                DoQueryJcJyInfo(strUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印界面出错 \n" + ex.Message + "\n" + ex.StackTrace, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void DoHideTabOrder()
        {
            tabControl1.TabPages.Remove(tabPage3);
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
                        if (control_jysq1.richTextBoxEx1.Text.Trim() != "")
                        {
                            if (MessageBox.Show("简要病史输入栏不为空，是否需要替换为EMR的简要病史？\r\nEMR的简要病史为：\r\n" + jybs, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        control_jysq1.richTextBoxEx1.Text = jybs;
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
    }
}
