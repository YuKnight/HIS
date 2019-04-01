using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using Ts_zyys_public;

namespace Ts_zyys_hzgl
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class FrmCon : System.Windows.Forms.Form
    {
        public System.Data.OleDb.OleDbConnection cCon = new System.Data.OleDb.OleDbConnection();
        private DbQuery myQuery = new DbQuery();
        private DataTable myTb = new DataTable();
        private DataTable conTb = new DataTable();
        private DataTable deptTb = new DataTable();
        private DataTable levelTb = new DataTable();
        private DataSet ds = new DataSet();
        private Doctor doctor;
        public long YS_ID = 0;
        public long DeptID = 0;
        public string WardID = "";
        public string YS_pw = "";
        public Guid BinID = Guid.Empty;
        public User YS = null;
        public long lg = 0;
        private string strID = "";
        private int buttonID = 0;//0=本科室申请 1=其他科室申请
        public string babysex = "";
        public string babyName = "";
        public string babyage = "";

        private System.Windows.Forms.BindingManagerBase myBind;

        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private LabelEx label15 = new LabelEx();
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btHer;
        private System.Windows.Forms.Button btMy;
        private System.Windows.Forms.RichTextBox rchIntent;
        private System.Windows.Forms.RichTextBox rchBin;
        private System.Windows.Forms.DateTimePicker dTimePicker;
        private DataGridEx dataGridHZ = new DataGridEx();
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Panel pCon;
        private System.Windows.Forms.RichTextBox rchCon;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.RichTextBox rchContent;
        private System.Windows.Forms.Button btFinish;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dTimePEnd;
        private System.Windows.Forms.DateTimePicker dTimePBegin;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel panel7;
        private LabelEx label16 = new LabelEx();
        private System.Windows.Forms.RichTextBox rchOutcome;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button bt_CloseReport;
        private Ts_zyys_public.PatientBar patientBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList_tab;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.TextBox txtSelDept;
        private System.Windows.Forms.DataGrid dGrid_dept;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.ListView LView_dept;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.Panel pnl_button;
        private System.Windows.Forms.Button bt_accept;
        private System.Windows.Forms.Label label4;
        private Button btnPrint;
        private CheckBox chcekbl;
        private DateTimePicker DtpbeginDate;
        private System.ComponentModel.IContainer components;
        private ComboBox cmbchild;
        private SystemCfg cfg6060;
        /// <summary>
        /// 会诊申请医嘱是否为说明医嘱（不产生费用）0=否 1=是
        /// </summary>
        private SystemCfg cfg6081 = new SystemCfg(6081);
        private SystemCfg cfg6220 = new SystemCfg(6220);//参数控制是否护士站完全上线 0=否 1=是
        public FrmCon(long currentUser, long currentDept, string formText, object[] _value)
        {
            InitializeComponent();

            BinID = new Guid(Convertor.IsNull(_value[0], Guid.Empty.ToString()));

            YS = new User(Convert.ToInt64(currentUser), FrmMdiMain.Database);

            YS_ID = YS.EmployeeId;
            DeptID = currentDept;
            WardID = _value[1].ToString();
            lg = Convert.ToInt64(Convertor.IsNull(_value[5], "0"));
            doctor = new Doctor(YS_ID, FrmMdiMain.Database);
        }
        public FrmCon(long currentUser, long currentDept, string formText)
        {
            InitializeComponent();

            YS = new User(Convert.ToInt64(currentUser), FrmMdiMain.Database);
            doctor = new Doctor(YS.EmployeeId, FrmMdiMain.Database);
        }
        public FrmCon(long ysID)
        {
            InitializeComponent();
            doctor = new Doctor(ysID, FrmMdiMain.Database);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCon));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("未完成的会诊");
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSelDept = new System.Windows.Forms.TextBox();
            this.LView_dept = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rchBin = new System.Windows.Forms.RichTextBox();
            this.rchIntent = new System.Windows.Forms.RichTextBox();
            this.dTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dGrid_dept = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbchild = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chcekbl = new System.Windows.Forms.CheckBox();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.btCancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btPrint = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pCon = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.bt_CloseReport = new System.Windows.Forms.Button();
            this.bt_accept = new System.Windows.Forms.Button();
            this.rchCon = new System.Windows.Forms.RichTextBox();
            this.label15 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.dataGridHZ = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_button = new System.Windows.Forms.Panel();
            this.btHer = new System.Windows.Forms.Button();
            this.btMy = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dTimePEnd = new System.Windows.Forms.DateTimePicker();
            this.dTimePBegin = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rchOutcome = new System.Windows.Forms.RichTextBox();
            this.label16 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.rchContent = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList_tab = new System.Windows.Forms.ImageList(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.btFinish = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.patientBar1 = new Ts_zyys_public.PatientBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_dept)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pCon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHZ)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnl_button.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ImageList = this.imageList2;
            this.tabControl1.ItemSize = new System.Drawing.Size(90, 20);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(15, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 541);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(744, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "会诊申请录入";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Ivory;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.cmbLevel);
            this.panel3.Controls.Add(this.cmbClass);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtSelDept);
            this.panel3.Controls.Add(this.LView_dept);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.rchBin);
            this.panel3.Controls.Add(this.rchIntent);
            this.panel3.Controls.Add(this.dTimePicker);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.dGrid_dept);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(744, 369);
            this.panel3.TabIndex = 0;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            // 
            // cmbLevel
            // 
            this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbLevel.Location = new System.Drawing.Point(296, 40);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(168, 23);
            this.cmbLevel.TabIndex = 2;
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbClass.Items.AddRange(new object[] {
            "科间会诊",
            "急诊会诊",
            "院内大会诊",
            "院外会诊"});
            this.cmbClass.Location = new System.Drawing.Point(104, 40);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(104, 23);
            this.cmbClass.TabIndex = 39;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(488, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "被邀请科室列表：";
            // 
            // txtSelDept
            // 
            this.txtSelDept.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSelDept.Location = new System.Drawing.Point(552, 85);
            this.txtSelDept.Name = "txtSelDept";
            this.txtSelDept.Size = new System.Drawing.Size(182, 23);
            this.txtSelDept.TabIndex = 43;
            this.txtSelDept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSelDept_KeyUp);
            this.txtSelDept.Enter += new System.EventHandler(this.txtSelDept_Enter);
            // 
            // LView_dept
            // 
            this.LView_dept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LView_dept.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LView_dept.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LView_dept.FullRowSelect = true;
            this.LView_dept.GridLines = true;
            this.LView_dept.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LView_dept.Location = new System.Drawing.Point(488, 133);
            this.LView_dept.MultiSelect = false;
            this.LView_dept.Name = "LView_dept";
            this.LView_dept.Size = new System.Drawing.Size(216, 222);
            this.LView_dept.TabIndex = 42;
            this.LView_dept.UseCompatibleStateImageBehavior = false;
            this.LView_dept.View = System.Windows.Forms.View.Details;
            this.LView_dept.DoubleClick += new System.EventHandler(this.LView_dept_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "科室ID";
            this.columnHeader1.Width = 58;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "会诊科室名称";
            this.columnHeader2.Width = 130;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(232, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 41;
            this.label2.Text = "选择级别";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 40;
            this.label1.Text = "会诊类别";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(648, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // rchBin
            // 
            this.rchBin.Location = new System.Drawing.Point(104, 87);
            this.rchBin.Name = "rchBin";
            this.rchBin.Size = new System.Drawing.Size(360, 177);
            this.rchBin.TabIndex = 3;
            this.rchBin.Text = "";
            this.rchBin.Enter += new System.EventHandler(this.rchBin_Enter);
            this.rchBin.Leave += new System.EventHandler(this.rchBin_Leave);
            // 
            // rchIntent
            // 
            this.rchIntent.Location = new System.Drawing.Point(104, 273);
            this.rchIntent.Name = "rchIntent";
            this.rchIntent.Size = new System.Drawing.Size(360, 94);
            this.rchIntent.TabIndex = 4;
            this.rchIntent.Text = "";
            // 
            // dTimePicker
            // 
            this.dTimePicker.CalendarForeColor = System.Drawing.Color.DarkRed;
            this.dTimePicker.CalendarMonthBackground = System.Drawing.Color.LightYellow;
            this.dTimePicker.CalendarTitleBackColor = System.Drawing.Color.DarkOliveGreen;
            this.dTimePicker.CalendarTrailingForeColor = System.Drawing.Color.Tan;
            this.dTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTimePicker.Location = new System.Drawing.Point(552, 40);
            this.dTimePicker.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dTimePicker.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dTimePicker.Name = "dTimePicker";
            this.dTimePicker.Size = new System.Drawing.Size(182, 23);
            this.dTimePicker.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(488, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 14);
            this.label14.TabIndex = 4;
            this.label14.Text = "会诊时间";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(290, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(165, 33);
            this.label13.TabIndex = 3;
            this.label13.Text = "会诊申请单";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(40, 267);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 14);
            this.label12.TabIndex = 2;
            this.label12.Text = "会诊目的";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(488, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 14);
            this.label11.TabIndex = 1;
            this.label11.Text = "邀请科室";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(40, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "病史及检查";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dGrid_dept
            // 
            this.dGrid_dept.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dGrid_dept.CaptionVisible = false;
            this.dGrid_dept.DataMember = "";
            this.dGrid_dept.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGrid_dept.Location = new System.Drawing.Point(552, 133);
            this.dGrid_dept.Name = "dGrid_dept";
            this.dGrid_dept.RowHeaderWidth = 25;
            this.dGrid_dept.Size = new System.Drawing.Size(184, 144);
            this.dGrid_dept.TabIndex = 44;
            this.dGrid_dept.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dGrid_dept.Visible = false;
            this.dGrid_dept.DoubleClick += new System.EventHandler(this.dGrid_dept_DoubleClick);
            this.dGrid_dept.CurrentCellChanged += new System.EventHandler(this.dGrid_dept_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dGrid_dept;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "DEPTNAME";
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.MappingName = "ROWNO";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "科室名称";
            this.dataGridTextBoxColumn2.MappingName = "DEPT_NAME";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 160;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "拼音码";
            this.dataGridTextBoxColumn3.MappingName = "PY_CODE";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 60;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "五笔码";
            this.dataGridTextBoxColumn4.MappingName = "WB_CODE";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 60;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "数字码";
            this.dataGridTextBoxColumn5.MappingName = "D_CODE";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.cmbchild);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 72);
            this.panel1.TabIndex = 5;
            // 
            // cmbchild
            // 
            this.cmbchild.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbchild.FormattingEnabled = true;
            this.cmbchild.Location = new System.Drawing.Point(13, 45);
            this.cmbchild.Name = "cmbchild";
            this.cmbchild.Size = new System.Drawing.Size(121, 21);
            this.cmbchild.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chcekbl);
            this.panel2.Controls.Add(this.DtpbeginDate);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.btPrint);
            this.panel2.Controls.Add(this.btOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 441);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 72);
            this.panel2.TabIndex = 6;
            // 
            // chcekbl
            // 
            this.chcekbl.AutoSize = true;
            this.chcekbl.Location = new System.Drawing.Point(14, 26);
            this.chcekbl.Name = "chcekbl";
            this.chcekbl.Size = new System.Drawing.Size(82, 18);
            this.chcekbl.TabIndex = 31;
            this.chcekbl.Text = "补录医嘱";
            this.chcekbl.UseVisualStyleBackColor = true;
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
            this.DtpbeginDate.Location = new System.Drawing.Point(103, 24);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(164, 21);
            this.DtpbeginDate.TabIndex = 30;
            this.DtpbeginDate.Value = new System.DateTime(2004, 6, 25, 0, 0, 0, 0);
            // 
            // btCancel
            // 
            this.btCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.ImageIndex = 1;
            this.btCancel.ImageList = this.imageList1;
            this.btCancel.Location = new System.Drawing.Point(560, 24);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(88, 30);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消(&C)";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
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
            this.imageList1.Images.SetKeyName(19, "");
            // 
            // btPrint
            // 
            this.btPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrint.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPrint.ImageIndex = 14;
            this.btPrint.ImageList = this.imageList1;
            this.btPrint.Location = new System.Drawing.Point(463, 24);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(88, 30);
            this.btPrint.TabIndex = 1;
            this.btPrint.Text = "打印(&P)";
            this.btPrint.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btOK
            // 
            this.btOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.ImageIndex = 2;
            this.btOK.ImageList = this.imageList1;
            this.btOK.Location = new System.Drawing.Point(369, 24);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(88, 30);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "提交(&O)";
            this.btOK.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pCon);
            this.tabPage2.Controls.Add(this.dataGridHZ);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(744, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "会诊情况查询";
            // 
            // pCon
            // 
            this.pCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCon.Controls.Add(this.btnPrint);
            this.pCon.Controls.Add(this.bt_CloseReport);
            this.pCon.Controls.Add(this.bt_accept);
            this.pCon.Controls.Add(this.rchCon);
            this.pCon.Controls.Add(this.label15);
            this.pCon.Location = new System.Drawing.Point(96, 64);
            this.pCon.Name = "pCon";
            this.pCon.Size = new System.Drawing.Size(536, 448);
            this.pCon.TabIndex = 5;
            this.pCon.Visible = false;
            this.pCon.VisibleChanged += new System.EventHandler(this.pCon_VisibleChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.ImageIndex = 14;
            this.btnPrint.ImageList = this.imageList1;
            this.btnPrint.Location = new System.Drawing.Point(337, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 28);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // bt_CloseReport
            // 
            this.bt_CloseReport.BackColor = System.Drawing.Color.Gainsboro;
            this.bt_CloseReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_CloseReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_CloseReport.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_CloseReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_CloseReport.ImageIndex = 1;
            this.bt_CloseReport.ImageList = this.imageList1;
            this.bt_CloseReport.Location = new System.Drawing.Point(467, 4);
            this.bt_CloseReport.Name = "bt_CloseReport";
            this.bt_CloseReport.Size = new System.Drawing.Size(64, 28);
            this.bt_CloseReport.TabIndex = 2;
            this.bt_CloseReport.Text = "关闭";
            this.bt_CloseReport.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.bt_CloseReport.UseVisualStyleBackColor = false;
            this.bt_CloseReport.Click += new System.EventHandler(this.bt_CloseReport_Click);
            // 
            // bt_accept
            // 
            this.bt_accept.BackColor = System.Drawing.Color.Gainsboro;
            this.bt_accept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_accept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_accept.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_accept.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_accept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_accept.ImageIndex = 8;
            this.bt_accept.ImageList = this.imageList1;
            this.bt_accept.Location = new System.Drawing.Point(402, 4);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(65, 28);
            this.bt_accept.TabIndex = 3;
            this.bt_accept.Text = "接收";
            this.bt_accept.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.bt_accept.UseVisualStyleBackColor = false;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // rchCon
            // 
            this.rchCon.BackColor = System.Drawing.SystemColors.Info;
            this.rchCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchCon.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rchCon.Location = new System.Drawing.Point(0, 36);
            this.rchCon.Name = "rchCon";
            this.rchCon.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rchCon.Size = new System.Drawing.Size(534, 410);
            this.rchCon.TabIndex = 1;
            this.rchCon.Text = "";
            // 
            // label15
            // 
            this.label15.BackColor1 = System.Drawing.Color.Gray;
            this.label15.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(534, 36);
            this.label15.TabIndex = 0;
            this.label15.Text = "会  诊  单";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridHZ
            // 
            this.dataGridHZ.AllowSorting = false;
            this.dataGridHZ.CaptionBackColor = System.Drawing.Color.LightBlue;
            this.dataGridHZ.CaptionForeColor = System.Drawing.Color.Navy;
            this.dataGridHZ.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridHZ.DataMember = "";
            this.dataGridHZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHZ.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridHZ.Location = new System.Drawing.Point(0, 72);
            this.dataGridHZ.Name = "dataGridHZ";
            this.dataGridHZ.RowHeaderWidth = 25;
            this.dataGridHZ.Size = new System.Drawing.Size(744, 441);
            this.dataGridHZ.TabIndex = 6;
            this.dataGridHZ.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dataGridHZ.DoubleClick += new System.EventHandler(this.dataGridHZ_DoubleClick);
            this.dataGridHZ.CurrentCellChanged += new System.EventHandler(this.dataGridHZ_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dataGridHZ;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 25;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(744, 72);
            this.panel4.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pnl_button);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dTimePEnd);
            this.groupBox1.Controls.Add(this.dTimePBegin);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 72);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "查询时间段：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pnl_button
            // 
            this.pnl_button.Controls.Add(this.btHer);
            this.pnl_button.Controls.Add(this.btMy);
            this.pnl_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_button.Location = new System.Drawing.Point(453, 19);
            this.pnl_button.Name = "pnl_button";
            this.pnl_button.Size = new System.Drawing.Size(288, 50);
            this.pnl_button.TabIndex = 11;
            // 
            // btHer
            // 
            this.btHer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btHer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHer.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btHer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHer.ImageIndex = 18;
            this.btHer.ImageList = this.imageList1;
            this.btHer.Location = new System.Drawing.Point(128, 6);
            this.btHer.Name = "btHer";
            this.btHer.Size = new System.Drawing.Size(90, 30);
            this.btHer.TabIndex = 3;
            this.btHer.Text = "其它科室";
            this.btHer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btHer.Click += new System.EventHandler(this.btHer_Click);
            // 
            // btMy
            // 
            this.btMy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btMy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMy.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btMy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMy.ImageIndex = 19;
            this.btMy.ImageList = this.imageList1;
            this.btMy.Location = new System.Drawing.Point(8, 6);
            this.btMy.Name = "btMy";
            this.btMy.Size = new System.Drawing.Size(88, 30);
            this.btMy.TabIndex = 2;
            this.btMy.Text = "本科室";
            this.btMy.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btMy.Click += new System.EventHandler(this.btMy_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(238, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "至";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dTimePEnd
            // 
            this.dTimePEnd.Location = new System.Drawing.Point(265, 28);
            this.dTimePEnd.Name = "dTimePEnd";
            this.dTimePEnd.Size = new System.Drawing.Size(120, 23);
            this.dTimePEnd.TabIndex = 9;
            // 
            // dTimePBegin
            // 
            this.dTimePBegin.Location = new System.Drawing.Point(112, 28);
            this.dTimePBegin.Name = "dTimePBegin";
            this.dTimePBegin.Size = new System.Drawing.Size(120, 23);
            this.dTimePBegin.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel7);
            this.tabPage3.Controls.Add(this.splitter2);
            this.tabPage3.Controls.Add(this.rchContent);
            this.tabPage3.Controls.Add(this.splitter1);
            this.tabPage3.Controls.Add(this.treeView1);
            this.tabPage3.Controls.Add(this.panel6);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(744, 513);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "会诊意见输入";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.rchOutcome);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(131, 283);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(485, 230);
            this.panel7.TabIndex = 7;
            // 
            // rchOutcome
            // 
            this.rchOutcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchOutcome.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rchOutcome.ForeColor = System.Drawing.Color.Navy;
            this.rchOutcome.Location = new System.Drawing.Point(0, 24);
            this.rchOutcome.Name = "rchOutcome";
            this.rchOutcome.Size = new System.Drawing.Size(485, 206);
            this.rchOutcome.TabIndex = 8;
            this.rchOutcome.Text = "";
            // 
            // label16
            // 
            this.label16.BackColor1 = System.Drawing.Color.DarkGray;
            this.label16.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(485, 24);
            this.label16.TabIndex = 0;
            this.label16.Text = "会诊意见：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(131, 280);
            this.splitter2.Name = "splitter2";
            this.splitter2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitter2.Size = new System.Drawing.Size(485, 3);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // rchContent
            // 
            this.rchContent.BackColor = System.Drawing.Color.Ivory;
            this.rchContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rchContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.rchContent.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rchContent.ForeColor = System.Drawing.Color.Navy;
            this.rchContent.Location = new System.Drawing.Point(131, 0);
            this.rchContent.Name = "rchContent";
            this.rchContent.ReadOnly = true;
            this.rchContent.Size = new System.Drawing.Size(485, 280);
            this.rchContent.TabIndex = 5;
            this.rchContent.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(128, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 513);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.Gainsboro;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.ImageIndex = 2;
            this.treeView1.ImageList = this.imageList_tab;
            this.treeView1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "";
            treeNode1.Text = "未完成的会诊";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.SelectedImageIndex = 2;
            this.treeView1.Size = new System.Drawing.Size(128, 513);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList_tab
            // 
            this.imageList_tab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_tab.ImageStream")));
            this.imageList_tab.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_tab.Images.SetKeyName(0, "");
            this.imageList_tab.Images.SetKeyName(1, "");
            this.imageList_tab.Images.SetKeyName(2, "");
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.button7);
            this.panel6.Controls.Add(this.btFinish);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(616, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(128, 513);
            this.panel6.TabIndex = 2;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.ImageIndex = 1;
            this.button7.ImageList = this.imageList1;
            this.button7.Location = new System.Drawing.Point(24, 112);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(80, 26);
            this.button7.TabIndex = 1;
            this.button7.Text = "退出(&C)";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btFinish
            // 
            this.btFinish.BackColor = System.Drawing.SystemColors.Control;
            this.btFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFinish.ImageIndex = 2;
            this.btFinish.ImageList = this.imageList1;
            this.btFinish.Location = new System.Drawing.Point(24, 48);
            this.btFinish.Name = "btFinish";
            this.btFinish.Size = new System.Drawing.Size(80, 26);
            this.btFinish.TabIndex = 0;
            this.btFinish.Text = "完成(&O)";
            this.btFinish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFinish.UseVisualStyleBackColor = false;
            this.btFinish.Click += new System.EventHandler(this.btFinish_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
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
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // patientBar1
            // 
            this.patientBar1.BorderType = Ts_zyys_public.PatientBar.BorderStyle.Raised;
            this.patientBar1.Location = new System.Drawing.Point(0, 0);
            this.patientBar1.Name = "patientBar1";
            this.patientBar1.Size = new System.Drawing.Size(752, 72);
            this.patientBar1.TabIndex = 0;
            // 
            // FrmCon
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(752, 541);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmCon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会诊单";
            this.Load += new System.EventHandler(this.FrmCon_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_dept)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.pCon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHZ)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnl_button.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Load事件
        private void FrmCon_Load(object sender, System.EventArgs e)
        {
            if (this.BinID != Guid.Empty)
            {
                //add by zouchihua 2012-10-16
                cfg6060 = new SystemCfg(6060);
                #region 病人信息
                //				Inpatient Inpt=new Inpatient(this.BinID);
                //				Patient pt=new Patient (Inpt.PatientID );
                //				lblName.Text=pt.Name.Trim();
                //				lblInpatientNo.Text =pt.Inpatient_No .Trim ();            
                //				lblSex.Text =(pt.Sex.ToString ()=="1")?"男":"女";
                //				lblage.Text = Convert.ToString(System.DateTime.Now.Year  -  pt.Birthday.Year);
                //				//			lblYJJ.Text ="￥"+Inpt.GetDeposits(true).ToString("0.00");
                //				//			lblTotal.Text="￥"+Inpt.GetFee().ToString("0.00");
                //				lblDiag.Text =Inpt.In_Diagnosis;
                //				lblWard.Tag  =WardID;
                //				lblWard.Text =myQuery.GetWardName(WardID);
                //			
                //				lblBedNo.Text=Inpt.Bed_ID<=0 ? "" : myQuery.GetBedNO(Inpt.Bed_ID);
                //
                //				//			try
                //				//			{
                //				//				Refresh();
                //				//			}
                //				//			catch(System.Exception err){MessageBox.Show(err.Message);}
                //				if(Inpt.Flag==2 || Inpt.Flag>=4)
                //				{
                //					MessageBox.Show("注意，该病人已经是出院病人，不允许再申请会诊！");
                //					this.Close();
                //					return;
                //				}
                //				if(Inpt.DischargeType==DischargeMode.Insure_DischargeMode)
                //					lblName.ForeColor=Color.Red;
                //				else
                //					lblName.ForeColor=Color.Navy;
                #endregion

                patientBar1.PatientID = BinID;


                //Modify By Tany 2011-04-26
                //增加对EMR信息的调用
                try
                {
                    string jybs = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select top 1 symptom from zy_jc_record where inpatient_id='" + BinID + "' order by id desc"), "");
                    if (jybs == "")
                    {
                        object[] objs = EmrVSHISInterface.HisInterface.GetMrDiagnoseOrContent(BinID.ToString());
                        jybs = Convertor.IsNull(objs[1], "");
                    }
                    rchBin.Text = jybs;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }

                if (patientBar1.IsLeave)
                {
                    this.Close();
                    return;
                }

                //获取可会诊科室
                deptTb = myQuery.GetDept(3, FrmMdiMain.Jgbm);
                deptTb.TableName = "DEPTNAME";
                ds.Tables.Add(deptTb);
                if (deptTb.Rows.Count == 0)
                {
                    MessageBox.Show("未能取得会诊科室信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                //获取会诊级别（医嘱项目）
                levelTb = myQuery.GetConLevel();
                if (levelTb.Rows.Count == 0)
                {
                    MessageBox.Show("未能取得会诊级别信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                this.cmbClass.SelectedIndex = 0;
            }
            else this.tabControl1.TabPages.Remove(this.tabPage1);

            dTimePicker.Value = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            InitGrd_consultation();


            //Add BY ZOUCHIHUA  设置补录的范围
            DtpbeginDate.MaxDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);

            //补录时间控制(默认24小时之内)
            string cfgStr = (new SystemCfg(6004, FrmMdiMain.Database)).Config;
            int cfg = 24;
            if (cfgStr != "")
            {
                try
                {
                    cfg = Convert.ToInt16(cfgStr);
                }
                catch (System.InvalidCastException err)
                {
                    err.ToString();
                    cfg = 24;
                }
            }
            DtpbeginDate.MinDate = DtpbeginDate.MaxDate.AddHours(-cfg);
            //Add by zouchihua 2012-02-09 判断补录日期不能小于上次转科日期
            string mysql = "select * from ZY_INPATIENT where  INPATIENT_ID='" + this.BinID + "' ";
            DataTable TransTb = FrmMdiMain.Database.GetDataTable(mysql);
            if (TransTb != null && TransTb.Rows.Count > 0)
            {
                DtpbeginDate.MinDate = Convert.ToDateTime(TransTb.Rows[0]["in_date"].ToString());
            }
            DtpbeginDate.Value = DtpbeginDate.MaxDate;
            //Add by zouchihua 2012-02-09 判断补录日期不能小于上次转科日期
            mysql = "select * from ZY_TRANSFER_DEPT where  FINISH_BIT=1 and INPATIENT_ID='" + this.BinID + "' and  cancel_bit=0   order by TRANSFER_DATE desc";
            TransTb.Clear();
            TransTb = FrmMdiMain.Database.GetDataTable(mysql);
            if (TransTb != null && TransTb.Rows.Count > 0)
            {
                DtpbeginDate.MinDate = Convert.ToDateTime(TransTb.Rows[0]["TRANSFER_DATE"].ToString());
            }
            DtpbeginDate.Value = DtpbeginDate.MaxDate;
            //add by zouchihua 2012-10-22  婴儿也可以开会诊
            this.cmbchild.DisplayMember = "name";
            this.cmbchild.ValueMember = "id";
            DataTable dt = FrmMdiMain.Database.GetDataTable("select baby_id ID,babyname NAME,dbo.FUN_ZY_SEEKSEXNAME(SEX) sexname,dbo.FUN_ZY_AGE(BIRTHDAY,3,GETDATE()) age from zy_inpatient_baby where inpatient_id='" + this.BinID.ToString() + "' and flag in(1,3,4)");
            if (dt.Rows.Count > 0)
            {
                this.babyage = dt.Rows[0]["age"].ToString();
                this.babyName = dt.Rows[0]["name"].ToString();
                this.babysex = dt.Rows[0]["sexname"].ToString();
                DataRow dr = dt.NewRow();
                dr[0] = 0;//this.BinID;
                dr[1] = patientBar1.lblName.Text;
                dt.Rows.Add(dr);
                cmbchild.DataSource = dt;
                dt = null;
                cmbchild.SelectedIndex = cmbchild.Items.Count - 1;
                this.cmbchild.SelectedValueChanged += new EventHandler(cmbchild_SelectedValueChanged);
            }
            else this.cmbchild.Visible = false;
        }

        void cmbchild_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cmbchild.SelectedValue.ToString() != "0")
            {
                DataTable dt = (DataTable)cmbchild.DataSource;
                this.babyage = dt.Rows[this.cmbchild.SelectedIndex]["age"].ToString();
                this.babyName = dt.Rows[this.cmbchild.SelectedIndex]["name"].ToString();
                this.babysex = dt.Rows[this.cmbchild.SelectedIndex]["sexname"].ToString();
            }
        }
        #endregion

        #region 选项卡页改变事件
        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.Text = tabControl1.SelectedTab.Text;

            //初始化会诊意见录入页
            if (tabControl1.SelectedIndex == tabControl1.TabCount - 1)
            {
                InitTreeView();
                this.treeView1.Nodes[0].Tag = -1;
            }
        }
        #endregion

        #region ①会诊申请页

        #region rchBin的大小控制
        private void rchBin_Enter(object sender, System.EventArgs e)
        {
            //rchBin.Height = 200;
        }

        private void rchBin_Leave(object sender, System.EventArgs e)
        {
            // rchBin.Height = 40;
        }

        private void panel3_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            rchIntent.Focus();
        }
        #endregion

        #region 保存会诊申请
        private void btOK_Click(object sender, System.EventArgs e)
        {
            if (this.lg == 0 || this.lg == 4) return;
            string execdept_id = "";
            string dept_id = "";

            if (cmbLevel.Text.Trim() == "")
            {
                MessageBox.Show("请选择有效的级别！");
                cmbLevel.Focus();
                return;
            }
            //add by zouchihua 2011-11-16获得病人所在科室机构编码
            string[] BrInfo = Ts_zyys_public.DbQuery.GetBrzt(this.BinID);
            int BrJgm = Convert.ToInt32(BrInfo[1]);
            if (MessageBox.Show("你确定要提交会诊申请吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(6023).Config == "0")
            {
                string dlgvalue = DlgPW.Show();

                if (!YS.CheckPassword(dlgvalue))
                {
                    FrmMessageBox.Show("你没有通过权限确认，不能提交会诊申请！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            long Order_Num = 0;//医嘱组号
            string selitem = "";//会诊医嘱内容
            string deptStr = "";//会诊执行科室
            string outStr = "";
            try
            {
                switch (cmbClass.SelectedIndex)
                {
                    case 0:
                        selitem = "邀请" + LView_dept.Items[0].SubItems[1].Text.Trim() + cmbLevel.Text.Trim() + "(科间)";
                        deptStr = LView_dept.Items[0].Text;
                        break;
                    case 1:
                        selitem = "邀请" + LView_dept.Items[0].SubItems[1].Text.Trim() + cmbLevel.Text.Trim() + "(急)";
                        deptStr = LView_dept.Items[0].Text;
                        break;
                    case 2:
                        selitem = "邀请" + cmbLevel.Text.Trim() + "(院内)";
                        deptStr = this.DeptID.ToString();
                        break;
                    case 3:
                        selitem = "邀请" + cmbLevel.Text.Trim();
                        deptStr = this.DeptID.ToString();
                        break;
                }
                //add by zouchihua 2012-10-16
                //Modify by jchl(院外会诊   执行开单科室都是本科，不受6060参数管理)
                if (cmbClass.SelectedIndex == 3)
                {
                    execdept_id = this.DeptID.ToString();
                    dept_id = this.DeptID.ToString();
                }
                else
                {
                    if (cfg6060.Config.Trim() == "1")
                    {
                        try
                        {
                            execdept_id = LView_dept.Items[0].Text;
                            dept_id = LView_dept.Items[0].Text;
                        }
                        catch
                        {
                            execdept_id = this.DeptID.ToString();
                            dept_id = this.DeptID.ToString();
                        }
                    }
                    else
                    {
                        if (cfg6060.Config.Trim() == "0")
                        {
                            execdept_id = this.DeptID.ToString();
                            dept_id = this.DeptID.ToString();
                        }
                        else
                        {
                            //为2时，开单科室为登录科室，执行科室为 会诊科室
                            dept_id = this.DeptID.ToString();
                            execdept_id = LView_dept.Items[0].Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("会诊信息不完整,请认真填写!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            Order_Num = myQuery.GetYzNum(this.BinID, this.DeptID);//获取该病人最大医嘱组号

            //			InstanceForm._database.Open();
            FrmMdiMain.Database.BeginTransaction();
            try
            {


                Order_Num += 1;

                Guid recordID = PubStaticFun.NewGuid();
                //add by zouchihua 汇诊补录 2012-02-08
                string order_date = dTimePicker.Value.ToString().Trim();
                string status_flag = "0";
                if (chcekbl.Checked)
                {
                    order_date = DtpbeginDate.Value.ToString();
                    status_flag = "9";//补录
                }

                //Modify by jchl
                //判断该科室是否上线
                bool isMemoOrder = (cfg6220.Config.Trim() == "1" || myQuery.IsDeptOk(dept_id.Trim()));

                string sSql = "INSERT INTO ZY_ORDERRECORD(" +
                    "Order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,nType,Order_Doc," +
                    "HOItem_ID,Order_context,Num,Dosage,Unit,book_date," +
                    "Order_bDate,First_times,Order_Usage,frequency," +
                    "Operator,Delete_Bit,status_flag,dept_br,exec_dept,SERIAL_NO,xmly,DWLX,PS_FLAG,ps_orderid,wzx_flag,jz_flag,jgbm,zsl,BABY_ID)" +        //jz_flag:是否直接记帐，1直接记帐，0不直接记帐
                    " VALUES('" + recordID + "'," + Order_Num.ToString() + ",'" + this.BinID.ToString() + "'," + dept_id.Trim() + ",'" + this.WardID + "',1," + ((isMemoOrder && cfg6081.Config.Trim() == "0") ? 4 : 7) + "," + this.YS_ID.ToString() + "," +
                    "" + ((isMemoOrder && cfg6081.Config.Trim() == "0") ? cmbLevel.SelectedValue.ToString() : "-1") + ",'" + selitem.Trim() + "',1,1,' ',GetDate()," +   //参数6060开启时，开单科室也为会诊科室
                    "'" + order_date + "',0,'',''," +
                    "" + this.YS_ID.ToString() + ",0," + status_flag + "," + this.DeptID.ToString() + "," + execdept_id.Trim() + ",0,2,0,-1,DBO.FUN_GETEMPTYGUID(),0,1," + BrJgm + ",1," + (this.cmbchild.SelectedValue == null ? "0" : this.cmbchild.SelectedValue.ToString()) + ")";

                FrmMdiMain.Database.DoCommand(sSql);

                //第一步：建临时表
                outStr = myQuery.CommitConApply(FrmMdiMain.Database, Guid.Empty, long.Parse((this.cmbchild.SelectedValue == null ? "0" : this.cmbchild.SelectedValue.ToString())), "", 0, 0, 0, System.DateTime.Now, "", "", Guid.Empty, 0, 0, 0, 1, BrJgm);

                //				string sSql0="insert into zy_consultation("+
                //							"order_id,inpatient_id,baby_id,ward_id,dept_br,dept_id,"+
                //							"apply_doc,apply_date,content,intent,finish_flag,level)"+
                //							"values("+recordID.ToString()+","+ this.BinID.ToString() + ",0,'"+this.WardID+"',"+this.DeptID.ToString()+","+this.DeptID.ToString()+","+
                //							""+this.YS_ID.ToString()+",'"+this.dTimePicker.Value.ToString().Trim()+"','"+this.rchBin.Text.Trim()+"','"+this.rchIntent.Text.Trim()+"',"+
                //							"0,"+cmbClass.SelectedIndex.ToString()+")";
                //				_Database.DoCommand(sSql0);

                //				recordID=Convert.ToInt64(_Database.GetDataResult("values IDENTITY_VAL_LOCAL()"));

                long[] deptList = new long[LView_dept.Items.Count];
                for (int i = 0; i < LView_dept.Items.Count; i++)
                {
                    //第二步：插入记录到临时表
                    outStr = myQuery.CommitConApply(FrmMdiMain.Database, Guid.Empty, long.Parse((this.cmbchild.SelectedValue == null ? "0" : this.cmbchild.SelectedValue.ToString())), "", 0, 0, 0, System.DateTime.Now, "", "", Guid.Empty, 0, 0, Convert.ToInt64(LView_dept.Items[i].Text), 2, BrJgm);
                    //					_Database.DoCommand("insert into zy_con_mx (p_id,con_dept)values("+recordID.ToString()+","+LView_dept.Items[i].Text+")");
                    deptList[i] = Convert.ToInt64(LView_dept.Items[i].Text);
                }
                //第三步：提交临时表数据到正式表
                outStr = myQuery.CommitConApply(FrmMdiMain.Database, this.BinID, long.Parse((this.cmbchild.SelectedValue == null ? "0" : this.cmbchild.SelectedValue.ToString())), this.WardID, this.DeptID, this.DeptID, this.YS_ID, this.dTimePicker.Value,
                    this.rchBin.Text.Trim(), this.rchIntent.Text.Trim(), recordID, Convert.ToInt16(doctor.TypeID == 4 ? 0 : 1),// 经治医生申请的必须审核=0，其他=1
                    Convert.ToInt16(cmbClass.SelectedIndex), 0, 3, BrJgm);
                FrmMdiMain.Database.CommitTransaction();
                MessageBox.Show(selitem.ToString().Trim() + " 申请完成！\n会诊内容保存成功。\n成功写入医嘱。", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (deptList.Length != 0)
                {
                    //myQuery.sendMessage(BinID, YS_ID, DeptID, deptList, "会诊申请", patientBar1.lblWard.Text + selitem, 41, 2);

                    for (int i = 0; i < deptList.Length; i++)
                    {
                        string msg_wardid = "";
                        long msg_deptid = deptList[i];
                        long msg_empid = 0;
                        string msg_sender = FrmMdiMain.CurrentDept.DeptName + "：" + FrmMdiMain.CurrentUser.Name;
                        string msg_msg = patientBar1.lblWard.Text + " " + patientBar1.lblName.Text + " 申请会诊，请处理！";
                        TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.住院医生站, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
                    }
                }
                this.Close();
            }
            catch (System.Exception er)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show("错误！" + outStr + "\n" + er.ToString() + "\n\n会诊申请失败！", "失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //			finally
            //			{
            //				InstanceForm._database.Close();
            //			}			
        }
        #endregion

        #region 显示申请单背景字
        private void panel3_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            System.Drawing.Brush brush = new SolidBrush(Color.FromArgb(220, 220, 220));
            System.Drawing.Font font = new Font("宋体", 20, FontStyle.Italic);
            for (int x = 0; x <= 6; x++)
                for (int y = 0; y <= 15; y++)
                {
                    e.Graphics.DrawString("会诊申请单", font, brush, x * 160, y * 35);
                }
            brush.Dispose();
            font.Dispose();
        }
        #endregion

        #region 打印
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Brush brush;
            System.Drawing.Font font;
            int x0 = 0;
            //			brush=new SolidBrush(Color.FromArgb(236,236,236));
            //			font=new Font("宋体",20,FontStyle.Italic);
            //			for(int x=0;x<=5;x++)
            //				for(int y=0;y<=40;y++)
            //				{
            //					if(y%2==0) x0=x*160+30;else x0=x*160-30;
            //					e.Graphics.DrawString("会诊申请单",font,brush,x0,y*35);
            //				} 


            string str = "会诊申请单";
            string str0 = (new SystemCfg(2, DatabaseType.IbmDb2ZY)).Config;
            int left = e.MarginBounds.Left,
                top = e.MarginBounds.Top;
            int num = Convert.ToInt16((e.MarginBounds.Width - str.Length * 27) / 2),
                num0 = Convert.ToInt16((e.MarginBounds.Width - str0.Length * 20) / 2);
            string sSql = "select name from jc_employee_property where employee_id=" + YS_ID.ToString();
            string YS_name = Convertor.IsNull(FrmMdiMain.Database.GetDataResult(sSql), "无名");

            brush = new SolidBrush(Color.Black);
            font = new Font("楷体_GB2312", 20, FontStyle.Bold);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(str, font, brush, left + num, 30 + top, System.Drawing.StringFormat.GenericTypographic);
            font = new Font("楷体_GB2312", 15, FontStyle.Regular);
            e.Graphics.DrawString(str0, font, brush, left + num0, top, System.Drawing.StringFormat.GenericTypographic);

            font = new Font("宋体", 11, FontStyle.Bold);
            e.Graphics.DrawString("姓名：" + ((this.cmbchild.SelectedValue == null || this.cmbchild.SelectedValue.ToString() == "0") ? patientBar1.lblName.Text : this.babyName), font, brush, left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("性别：" + ((this.cmbchild.SelectedValue == null || this.cmbchild.SelectedValue.ToString() == "0") ? patientBar1.lblSex.Text : this.babysex.ToString()), font, brush, 120 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("年龄：" + ((this.cmbchild.SelectedValue == null || this.cmbchild.SelectedValue.ToString() == "0") ? patientBar1.lblage.Text : this.babyage.ToString()), font, brush, 200 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("病区：" + patientBar1.lblWard.Text, font, brush, 270 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("床号：" + patientBar1.lblBedNo.Text, font, brush, 390 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("住院号：" + patientBar1.lblInpatientNo.Text, font, brush, 470 + left, 90 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("简要病史及检查：", font, brush, left, 130 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString(rchBin.Text, new Font("宋体", 11, FontStyle.Regular), brush, new Rectangle(left, 170 + top, e.MarginBounds.Width, 200));

            e.Graphics.DrawString("申请日期：" + dTimePicker.Value.ToString(), font, brush, 400 + left, 590 + top - 50, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("会诊目的：", font, brush, left, 380 + top, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString(rchIntent.Text, new Font("宋体", 11, FontStyle.Regular), brush, new Rectangle(left, 450 + top, e.MarginBounds.Width, 200));

            //add by zouchihua 2012-11-13
            string byks = "";
            for (int i = 0; i < LView_dept.Items.Count; i++)
            {
                byks += LView_dept.Items[i].SubItems[1].Text + "  ";
            }
            e.Graphics.DrawString("被邀请科室：" + byks, font, brush, 130 + left, 880 + top + 100, System.Drawing.StringFormat.GenericTypographic);


            e.Graphics.DrawString("申请医师：" + YS_name, font, brush, 130 + left, 590 + top - 50, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("会诊日期：", font, brush, 400 + left, 900 + top + 100, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawString("会诊医师：", font, brush, 130 + left, 900 + top + 100, System.Drawing.StringFormat.GenericTypographic);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), left, 160 + top, e.MarginBounds.Width, 200);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), left, 410 + top, e.MarginBounds.Width, 120);
            font = new Font("楷体_GB2312", 15, FontStyle.Regular);
            e.Graphics.DrawString("会诊意见：", font, brush, 220 + left, 640 + top - 70, System.Drawing.StringFormat.GenericTypographic);


            e.HasMorePages = false;
            //	e.Graphics.DrawString("",font,brush,new Rectangle(20,140,400,60));

            brush.Dispose();
            font.Dispose();
        }

        private void btPrint_Click(object sender, System.EventArgs e)
        {
            //			FrmPre fp=new FrmPre();
            //			fp.printDocument1=this.printDocument1;
            //			fp.printPreviewControl1.Document=fp.printDocument1;
            //			fp.Show();
            // this.printPreviewDialog1.Document = this.printDocument1;
            //this.printPreviewDialog1.ShowDialog();


            string sSql = "select name from jc_employee_property where employee_id=" + YS_ID.ToString();
            string YS_name = Convertor.IsNull(FrmMdiMain.Database.GetDataResult(sSql), "无名");

            ParameterEx[] pa = new ParameterEx[1];
            pa[0].Text = "报表名称";
            pa[0].Value = "会诊申请单";
            DataSet1.HzdDataTable hzdtb = new DataSet1.HzdDataTable();
            DataTable tbdy = hzdtb;
            string byks = "";
            for (int i = 0; i < LView_dept.Items.Count; i++)
            {
                byks += LView_dept.Items[i].SubItems[1].Text + "  ";
            }
            DataRow dr = tbdy.NewRow();
            dr["姓名"] = ((this.cmbchild.SelectedValue == null || this.cmbchild.SelectedValue.ToString() == "0") ? patientBar1.lblName.Text : this.babyName);
            dr["床号"] = patientBar1.lblBedNo.Text;
            dr["住院号"] = patientBar1.lblInpatientNo.Text;
            dr["病区"] = FrmMdiMain.CurrentDept.WardDeptName;
            dr["科室"] = FrmMdiMain.CurrentDept.DeptName;
            dr["年龄"] = ((this.cmbchild.SelectedValue == null || this.cmbchild.SelectedValue.ToString() == "0") ? patientBar1.lblage.Text : this.babyage.ToString());
            dr["性别"] = ((this.cmbchild.SelectedValue == null || this.cmbchild.SelectedValue.ToString() == "0") ? patientBar1.lblSex.Text : this.babysex.ToString());
            dr["简要病史及检查"] = rchBin.Text;
            dr["会诊目的"] = rchIntent.Text;
            dr["申请医师"] = YS_name;
            dr["申请日期"] = dTimePicker.Value.ToString();
            dr["会诊意见"] = "";
            dr["会诊医师"] = "";
            dr["会诊日期"] = "";
            dr["被邀科室"] = byks;
            tbdy.Rows.Add(dr);

            //打印
            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(tbdy, Constant.ApplicationDirectory + "\\report\\zyys_会诊单打印.rpt", pa, false);//sqls[0]);
            f.ShowDialog();
        }
        #endregion

        #region 改变会诊类别事件
        private void cmbClass_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            txtSelDept.Enabled = false;
            if (cmbClass.SelectedIndex == 3)//院外会诊
            {
                cmbLevel.DataSource = GetLevel(1);
                LView_dept.Items.Clear();
            }
            else
            {
                cmbLevel.DataSource = GetLevel(0);
                //科内会诊、急诊会诊只能选一个会诊科室
                if (!(LView_dept.Items.Count > 0 && (cmbClass.SelectedIndex == 0 || cmbClass.SelectedIndex == 1)))
                {
                    txtSelDept.Enabled = true;
                }
                else if (LView_dept.Items.Count > 1)
                {
                    txtSelDept.Enabled = true;
                    LView_dept.Items.Clear();
                }
            }
            cmbLevel.DisplayMember = "NAME";
            cmbLevel.ValueMember = "ID";

            //提交申请按钮是否可用 （院内大会诊、院外会诊只能由科主任申请提出）
            if (!(doctor.TypeID == 1 || doctor.TypeID == 2) && (cmbClass.SelectedIndex == 2 || cmbClass.SelectedIndex == 3)) btOK.Enabled = false;
            else btOK.Enabled = true;
        }
        private DataTable GetLevel(int levelType)
        {
            DataTable tempTb = levelTb.Clone();
            foreach (DataRow dr in levelTb.Select("level_type=" + levelType))
            {
                tempTb.Rows.Add(dr.ItemArray);
            }
            return tempTb;
        }
        #endregion

        #region 科室选择控制
        private void txtSelDept_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            bool respondKey = true;
            DataRow dr = WorkStaticFun.GetCardData(txtSelDept, e.KeyValue, 1, dGrid_dept, 0, ds, "DEPTNAME", FilterType.智能, SearchType.前导相似, ref respondKey, "", "");
            bool addItem = true;
            if (dr != null && respondKey)
            {
                for (int i = 0; i < LView_dept.Items.Count; i++)
                {
                    if (LView_dept.Items[i].Text == dr["dept_id"].ToString())
                    {
                        addItem = false;
                        break;
                    }
                }
                if (addItem) LView_dept.Items.Add(new ListViewItem(new string[] { dr["DEPT_ID"].ToString(), dr["dept_name"].ToString() }));
                txtSelDept.Text = "";
                if (cmbClass.SelectedIndex != 2) txtSelDept.Enabled = false;
            }
        }
        private void dGrid_dept_CurrentCellChanged(object sender, System.EventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            for (int i = 0; i < ((DataTable)grid.DataSource).Rows.Count; i++)
            {
                grid.UnSelect(i);
            }
            grid.Select(grid.CurrentCell.RowNumber);
        }

        private void dGrid_dept_DoubleClick(object sender, System.EventArgs e)
        {
            txtSelDept.Focus();
            txtSelDept_KeyUp(txtSelDept, new KeyEventArgs(Keys.Enter));
        }

        private void LView_dept_DoubleClick(object sender, System.EventArgs e)
        {
            LView_dept.SelectedItems[0].Remove();
            if (LView_dept.Items.Count == 0) txtSelDept.Enabled = true;
        }
        #endregion

        #endregion

        #region ②会诊查询页

        #region 初始化DataGrid
        private void InitGrd_consultation()
        {
            //增加新列
            int i = 0;

            DataGridEnableTextBoxColumn aColumnTextColumn;
            dataGridHZ.TableStyles[0].GridColumnStyles.Clear();//先清空列
            for (i = 0; i <= 14; i++)
            {
                aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                dataGridHZ.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);

            }

            dataGridHZ.RowHeaderWidth = 30;
            dataGridHZ.ReadOnly = true;
            //建立网格格式
            for (i = 0; i <= dataGridHZ.TableStyles[0].GridColumnStyles.Count - 1; i++) dataGridHZ.TableStyles[0].GridColumnStyles[i].NullText = "";

            dataGridHZ.TableStyles[0].GridColumnStyles[0].MappingName = "nid";
            dataGridHZ.TableStyles[0].GridColumnStyles[0].HeaderText = "序号";
            dataGridHZ.TableStyles[0].GridColumnStyles[0].Width = 50;

            dataGridHZ.TableStyles[0].GridColumnStyles[1].MappingName = "ID";
            dataGridHZ.TableStyles[0].GridColumnStyles[1].HeaderText = "ID*";
            dataGridHZ.TableStyles[0].GridColumnStyles[1].Width = 0;

            dataGridHZ.TableStyles[0].GridColumnStyles[2].MappingName = "住院号";
            dataGridHZ.TableStyles[0].GridColumnStyles[2].HeaderText = "住院号";
            dataGridHZ.TableStyles[0].GridColumnStyles[2].Width = 65;

            dataGridHZ.TableStyles[0].GridColumnStyles[3].MappingName = "姓名";
            dataGridHZ.TableStyles[0].GridColumnStyles[3].HeaderText = "姓名";
            dataGridHZ.TableStyles[0].GridColumnStyles[3].Width = 60;

            dataGridHZ.TableStyles[0].GridColumnStyles[4].MappingName = "病区";
            dataGridHZ.TableStyles[0].GridColumnStyles[4].HeaderText = "病区";
            dataGridHZ.TableStyles[0].GridColumnStyles[4].Width = 0;

            dataGridHZ.TableStyles[0].GridColumnStyles[5].MappingName = "床号";
            dataGridHZ.TableStyles[0].GridColumnStyles[5].HeaderText = "床号";
            dataGridHZ.TableStyles[0].GridColumnStyles[5].Width = 35;

            dataGridHZ.TableStyles[0].GridColumnStyles[6].MappingName = "科室";
            dataGridHZ.TableStyles[0].GridColumnStyles[6].HeaderText = "科室";
            dataGridHZ.TableStyles[0].GridColumnStyles[6].Width = 95;

            dataGridHZ.TableStyles[0].GridColumnStyles[7].MappingName = "申请医师";
            dataGridHZ.TableStyles[0].GridColumnStyles[7].HeaderText = "申请医师";
            dataGridHZ.TableStyles[0].GridColumnStyles[7].Width = 60;

            dataGridHZ.TableStyles[0].GridColumnStyles[8].MappingName = "申请日期";
            dataGridHZ.TableStyles[0].GridColumnStyles[8].HeaderText = "申请日期";
            dataGridHZ.TableStyles[0].GridColumnStyles[8].Width = 120;

            dataGridHZ.TableStyles[0].GridColumnStyles[9].MappingName = "content";
            dataGridHZ.TableStyles[0].GridColumnStyles[9].HeaderText = "简要病历及检查";
            dataGridHZ.TableStyles[0].GridColumnStyles[9].Width = 0;

            dataGridHZ.TableStyles[0].GridColumnStyles[10].MappingName = "intent";
            dataGridHZ.TableStyles[0].GridColumnStyles[10].HeaderText = "会诊目的";
            dataGridHZ.TableStyles[0].GridColumnStyles[10].Width = 200;

            dataGridHZ.TableStyles[0].GridColumnStyles[11].MappingName = "会诊类型";
            dataGridHZ.TableStyles[0].GridColumnStyles[11].HeaderText = "会诊类别";
            dataGridHZ.TableStyles[0].GridColumnStyles[11].Width = 65;

            dataGridHZ.TableStyles[0].GridColumnStyles[12].MappingName = "会诊级别";
            dataGridHZ.TableStyles[0].GridColumnStyles[12].HeaderText = "会诊级别";
            dataGridHZ.TableStyles[0].GridColumnStyles[12].Width = 100;


            dataGridHZ.TableStyles[0].GridColumnStyles[13].MappingName = "CON_DOC";
            dataGridHZ.TableStyles[0].GridColumnStyles[13].HeaderText = "会诊医生";
            dataGridHZ.TableStyles[0].GridColumnStyles[13].Width = 100;


            dataGridHZ.TableStyles[0].GridColumnStyles[14].MappingName = "CON_DATE";
            dataGridHZ.TableStyles[0].GridColumnStyles[14].HeaderText = "会诊完成时间";
            dataGridHZ.TableStyles[0].GridColumnStyles[14].Width = 120;

            //			dataGridHZ.TableStyles[0].GridColumnStyles[8].MappingName="会诊科室";
            //			dataGridHZ.TableStyles[0].GridColumnStyles[8].HeaderText="会诊科室";	
            //			dataGridHZ.TableStyles[0].GridColumnStyles[8].Width=95;
            //
            //			dataGridHZ.TableStyles[0].GridColumnStyles[9].MappingName="会诊医师";
            //			dataGridHZ.TableStyles[0].GridColumnStyles[9].HeaderText="会诊医师";	
            //			dataGridHZ.TableStyles[0].GridColumnStyles[9].Width=60;

            //			dataGridHZ.TableStyles[0].GridColumnStyles[0].MappingName="结果";
            //			dataGridHZ.TableStyles[0].GridColumnStyles[0].HeaderText="会诊意见";	
            //			dataGridHZ.TableStyles[0].GridColumnStyles[0].Width=120;

            //			dataGridHZ.TableStyles[0].GridColumnStyles[10].MappingName="会诊日期";
            //			dataGridHZ.TableStyles[0].GridColumnStyles[10].HeaderText="会诊日期";	
            //			dataGridHZ.TableStyles[0].GridColumnStyles[10].Width=120;

        }

        #endregion

        #region 网格颜色控制
        public void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.WhiteSmoke;
            DataTable tempTb = (DataTable)this.dataGridHZ.DataSource;

            if (tempTb.Rows[e.Row]["level"].ToString() == "1")//0=科间会诊，1=急诊会诊，2=院内会诊，3=院外会诊
            {
                e.ForeColor = Color.Red; ;
            }
            if (tempTb.Rows[e.Row]["finish_flag"].ToString() == "2")//完成状态(0=申请 1=已审核 2=已完成  3=取消)
            {
                e.ForeColor = Color.Blue;
            }
            if (tempTb.Rows[e.Row]["sel"].ToString() == "1")
            {
                e.BackColor = Color.Wheat;
            }

        }
        #endregion

        #region 显示会诊申请
        //显示本科室的会诊申请
        private void btMy_Click(object sender, System.EventArgs e)
        {
            myTb = myQuery.GetConApp(1, DeptID, dTimePBegin.Value.Date, dTimePEnd.Value.Date);
            SetDataGrid(myTb, "本科室申请的会诊：" + "                                  <红色:急诊会诊；兰色:会诊完成；黑色:会诊未完成>");
            buttonID = 0;
        }
        //显示其它科室向我科室申请的会诊
        private void btHer_Click(object sender, System.EventArgs e)
        {
            myTb = myQuery.GetConApp(2, DeptID, dTimePBegin.Value.Date, dTimePEnd.Value.Date);
            SetDataGrid(myTb, "其它科室向我科室申请的会诊：");
            buttonID = 1;
        }
        private void SetDataGrid(DataTable tb, string captionText)
        {
            this.dataGridHZ.DataSource = tb;
            this.dataGridHZ.CaptionText = captionText;
            PubStaticFun.ModifyDataGridStyle((DataGrid)dataGridHZ, 0);

            // 定位在最后一条记录上
            myBind = this.BindingContext[tb];
            myBind.Position = myBind.Count - 1;
        }
        #endregion

        #region 查询会诊意见结果
        private void dataGridHZ_DoubleClick(object sender, System.EventArgs e)
        {
            if (myBind.Position < 0) return;
            pCon.Visible = true;
            DataTable dt = myQuery.GetConOutcome(new Guid(myTb.Rows[myBind.Position]["id"].ToString()));
            Doctor doc = new Doctor(Convert.ToInt64(myTb.Rows[myBind.Position]["apply_doc"]), FrmMdiMain.Database);

            if (buttonID == 0)
            {
                bt_accept.Text = "审核";
                //申请医生是经治医生，且未审核同意的会诊申请要审核
                if (doctor.TypeID != 4 && doc.TypeID == 4 && myTb.Rows[myBind.Position]["finish_flag"].ToString() == "0") bt_accept.Visible = true;
                else bt_accept.Visible = false;
            }
            else
            {
                bt_accept.Text = "接收";
                if (IsAccept(this.DeptID, dt)) bt_accept.Visible = false;
                else bt_accept.Visible = true;
            }
            string conStr = myTb.Rows[myBind.Position]["住院号"].ToString() + "  " + myTb.Rows[myBind.Position]["床号"].ToString() + "床   " + myTb.Rows[myBind.Position]["姓名"].ToString() + "  " + myTb.Rows[myBind.Position]["科室"].ToString() + "\r\n\n" +
                "【简要病史及检查】\n    " + myTb.Rows[myBind.Position]["content"].ToString() + "\n【会诊目的】\n    " + myTb.Rows[myBind.Position]["intent"].ToString() + "\n                                        " +
                "申请医师：" + myTb.Rows[myBind.Position]["申请医师"].ToString() + new string('_', 64) + "\n【会诊意见】";
            if (dt.Rows.Count == 0) conStr += "\n    (无)";
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    conStr += "\n▲会诊科室: " + dt.Rows[i]["con_deptname"].ToString() + "      会诊时间: " + dt.Rows[i]["con_date"].ToString() +
                            "\n     " + (dt.Rows[i]["content"].ToString().Trim() == "" ? " " : dt.Rows[i]["content"].ToString().Trim()) + "\n                                        " +
                            (dt.Rows[i]["con_docname"].ToString() == "" ? "" : ("会诊医生：" + dt.Rows[i]["con_docname"].ToString()));
                }
            }
            rchCon.Text = conStr;
        }
        /// <summary>
        /// 是否已接收其他科室申请的会诊
        /// </summary>
        /// <param name="deptid">接收科室</param>
        /// <param name="tb">该会诊申请的应邀科室会诊明细</param>
        /// <returns></returns>
        private bool IsAccept(long deptid, DataTable tb)
        {
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["con_dept"].ToString() == deptid.ToString())
                {
                    if (tb.Rows[i]["accept_doc"] != System.DBNull.Value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        private void dataGridHZ_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if (myBind.Position < 0) return;
            for (int i = 0; i < myBind.Count; i++)
            {
                myTb.Rows[i]["sel"] = 0;
            }
            myTb.Rows[myBind.Position]["sel"] = 1;
        }


        private void pCon_VisibleChanged(object sender, System.EventArgs e)
        {
            pnl_button.Enabled = pCon.Visible ? false : true;
        }

        private void bt_accept_Click(object sender, System.EventArgs e)
        {
            if (myQuery.SetConFlag(new Guid(myTb.Rows[myBind.Position]["id"].ToString()), this.DeptID, this.YS_ID, bt_accept.Text) > 0)
            {
                MessageBox.Show(bt_accept.Text + "成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bt_accept.Visible = false;
                if (buttonID == 0) myTb.Rows[myBind.Position]["finish_flag"] = 1;
            }
            else
            {
                MessageBox.Show(bt_accept.Text + "失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region ③会诊意见录入页

        #region 初始化treeView,显示未完成的会诊
        private void InitTreeView()
        {
            this.treeView1.Nodes[0].Nodes.Clear();//先清空结点，只保留根结点

            conTb = myQuery.GetConApp(3, DeptID, dTimePBegin.Value.Date, dTimePEnd.Value.Date);
            if (conTb.Rows.Count == 0) return;

            int k = 0;
            TreeNode tNode = this.treeView1.Nodes[0].Nodes.Add(conTb.Rows[0]["科室"].ToString().Trim());
            tNode.Tag = -1;
            for (int i = 0; i < conTb.Rows.Count; i++)
            {
                if (i - 1 >= 0)
                {
                    if (conTb.Rows[i]["科室"].ToString().Trim() != conTb.Rows[i - 1]["科室"].ToString().Trim())
                    {
                        tNode = this.treeView1.Nodes[0].Nodes.Add(conTb.Rows[i]["科室"].ToString().Trim());
                        tNode.ForeColor = Color.Navy;
                        tNode.Tag = -1;
                        k++;
                    }
                }
                tNode = this.treeView1.Nodes[0].Nodes[k].Nodes.Add(conTb.Rows[i]["姓名"].ToString());
                tNode.ImageIndex = 0;
                tNode.SelectedImageIndex = 0;
                if (conTb.Rows[i]["finish_flag"].ToString() == "1")//level=1 急诊会诊
                {
                    tNode.BackColor = Color.Yellow;//用黄色来表示是急诊会诊
                    tNode.ImageIndex = 1;
                    tNode.SelectedImageIndex = 1;
                }
                tNode.Tag = i;
            }
        }
        #endregion

        #region 响应节点事件
        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) return;
            int i = Convert.ToInt32(e.Node.Tag.ToString().Trim());
            if (i >= 0) strID = conTb.Rows[i]["ID"].ToString();

            if (e.Node.Tag.ToString() != "-1")
            {
                this.rchContent.Text = conTb.Rows[i]["住院号"].ToString().Trim() + "  " + conTb.Rows[i]["姓名"].ToString().Trim() +
                                     "  " + conTb.Rows[i]["科室"].ToString().Trim() + "  " + conTb.Rows[i]["床号"].ToString().Trim() + "床" +
                                     "\n申请时间：" + conTb.Rows[i]["申请日期"].ToString().Trim() +
                                     "\n简要病历及检查：\n   " + conTb.Rows[i]["content"].ToString().Trim() +
                                     "\n会诊目的：\n   " + conTb.Rows[i]["intent"].ToString().Trim();
            }
            else this.rchContent.Text = e.Node.Text.Trim();
        }
        #endregion

        #region 提交会诊意见
        private void btFinish_Click(object sender, System.EventArgs e)
        {
            if (this.lg == 0 || this.lg == 4) return;
            if (strID == "")
            {
                MessageBox.Show("请选择病人！");
                return;
            }

            if (this.rchOutcome.Text.Trim() == "")
            {
                if (MessageBox.Show("没有会诊意见！是否继续？\n继续请按‘是’，否则请按‘否’。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(6023).Config == "0")
            {
                string dlgvalue = DlgPW.Show();
                string pwStr = dlgvalue; //YS.Password;
                bool bOk = InstanceForm._currentUser.CheckPassword(pwStr);
                if (!bOk)
                {
                    FrmMessageBox.Show("你没有通过权限确认，不能提交会诊意见！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (myQuery.CommitConNotion(new Guid(strID), this.YS_ID, this.DeptID, this.rchOutcome.Text.Trim()) >= 0)
            {
                //				//记帐
                //				if(myQuery.ExecuteSql(cCon,"update zy_fee_speci set Charge_user="+this.YS_ID.ToString()+",charge_date=CURRENT TIMESTAMP,charge_bit=1,finish_bit=1 where order_id=(select order_id from zy_consultation where id="+strID+")")==0)
                //				{
                //					MessageBox.Show("记帐失败！\n请重试“完成”按钮。");
                //					sSql="update zy_consultation set con_doc="+System.DBNull.Value+",con_date='"+System.DBNull.Value+"',finish_flag=0,outcome='' where id="+strID+"";
                //					myQuery.ExecuteSql(cCon,sSql);
                //					return;                                        
                //				}
                //				MessageBox.Show("会诊意见成功提交！\n记帐完成。");
                MessageBox.Show("会诊意见成功提交！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.rchContent.Text = "";
                this.rchOutcome.Text = "";
                InitTreeView();
                this.treeView1.Refresh();
            }
            else MessageBox.Show("完成失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #endregion

        #region 退出
        //退出窗体
        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        //关闭报告单
        private void bt_CloseReport_Click(object sender, System.EventArgs e)
        {
            pCon.Visible = false;
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void txtSelDept_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = PubStaticFun.GetInputLanguage("美式键盘");
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

    }
}
