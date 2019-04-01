using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using YpClass;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
namespace ts_zyhs_jyddy
{
    /// <summary>
    /// 化验单打印 的摘要说明。
    /// </summary>
    public class frmjyd : System.Windows.Forms.Form
    {

        //自定义变量
        private BaseFunc myFunc;
        private int nType = 0;
        private TheReportDateSet rds = new TheReportDateSet();
        //Add By Tany 2011-05-19 7088打印检验申请单时是否允许勾选已确费的申请 0=不是 1=是
        private string _cfg7088 = "";
        //Add By tany 2011-06-07 默认条码长度9
        private int _txmLen = 9;
        private SystemCfg cfg7157 = new SystemCfg(7157);
        private string _txmStr = "000000000";
        //Add By tany 2011-06-07 条形码生成类型 4101检验申请单条码生成方式 0=自动生成 1=读取现有条码
        private int _txmType = 0;
        private SystemCfg cfg7174 = new SystemCfg(7174);
        /// <summary>
        /// 住院护士站打印模板 Add by Eric 2014-04-15
        /// </summary>
        private static string tempFile = "BarcodebyZYHS.Trasen";
        /// <summary>
        /// 加载XML文档，展示文本按钮 Add by Eric 2014-04-15
        /// </summary>
        private static string xmlFile = "TrasenBarCodeOtherInfo.xml";
        /// <summary>
        /// 模板文件 Add by Eric 2014-04-17
        /// </summary>
        private static string xmlFile1 = "TrasenBarCode.XML";
        /// <summary>
        /// add by zouchihua 2012-9-13 打印份数
        /// </summary>
        private string _cfg7135 = "1";
        /// <summary>
        /// 不能分在一组的表 add by zouchihua 2013-6-27
        /// </summary>
        DataTable tbBfz = new DataTable();
        /// <summary>
        /// 打印条码图片的大小
        /// </summary>
        private SystemCfg cfg7181 = new SystemCfg(7181);
        private System.Windows.Forms.Panel panel4;
        private GroupBox groupBox3;
        private RadioButton rdowdy;
        private RadioButton rdoydy;
        private Button btCancel;
        private Button btnPrint;
        public Button btnRefresh;
        private Button button3;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        public TextBox txtcwh;
        private Label label4;
        private Label label3;
        public TextBox txtzyh;
        private Panel panel2;
        private Label label5;
        public TextBox txtname;
        private Label label6;
        private TextBox txttxm;
        public CheckBox chkbq;
        private CheckBox checkBox1;
        private DataGridEx myDataGrid1;
        private DataGridTableStyle dataGridTableStyle1;
        private Button btnSelAll;
        private Button btnUnSel;
        private Button btReDo;
        private Label lblTxmInput;
        private TextBox txtTxmInput;
        private Button btnYdyprint;
        private CheckBox chekje;
        private Button btnOpen;
        private ComboBox comboBox1;
        private Label label7;
        public CheckBox chksqd;
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(

            IntPtr hdcDest, //目的上下文设备的句柄 

            int nXDest, //目的图形的左上角的x坐标 

            int nYDest, //目的图形的左上角的y坐标 

            int nWidth, //目的图形的矩形宽度 

            int nHeight, //目的图形的矩形高度 

            IntPtr hdcSrc, //源上下文设备的句柄 

            int nXSrc, //源图形的左上角的x坐标 

            int nYSrc, //源图形的左上角的x坐标 

            System.Int32 dwRop //光栅操作代码 

            );
        public System.Drawing.Brush brush;
        public System.Drawing.Font font;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmjyd(string _formText, int _type)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;
            nType = _type;

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
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chekje = new System.Windows.Forms.CheckBox();
            this.btnYdyprint = new System.Windows.Forms.Button();
            this.btnSelAll = new System.Windows.Forms.Button();
            this.btnUnSel = new System.Windows.Forms.Button();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblTxmInput = new System.Windows.Forms.Label();
            this.txtTxmInput = new System.Windows.Forms.TextBox();
            this.btReDo = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chksqd = new System.Windows.Forms.CheckBox();
            this.chkbq = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txttxm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtcwh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtzyh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdowdy = new System.Windows.Forms.RadioButton();
            this.rdoydy = new System.Windows.Forms.RadioButton();
            this.btCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(924, 555);
            this.panel4.TabIndex = 74;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chekje);
            this.panel2.Controls.Add(this.btnYdyprint);
            this.panel2.Controls.Add(this.btnSelAll);
            this.panel2.Controls.Add(this.btnUnSel);
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 456);
            this.panel2.TabIndex = 78;
            // 
            // chekje
            // 
            this.chekje.AutoSize = true;
            this.chekje.Location = new System.Drawing.Point(243, 5);
            this.chekje.Name = "chekje";
            this.chekje.Size = new System.Drawing.Size(72, 16);
            this.chekje.TabIndex = 101;
            this.chekje.Text = "打印金额";
            this.chekje.UseVisualStyleBackColor = true;
            // 
            // btnYdyprint
            // 
            this.btnYdyprint.BackColor = System.Drawing.Color.Honeydew;
            this.btnYdyprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYdyprint.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnYdyprint.Location = new System.Drawing.Point(108, 1);
            this.btnYdyprint.Name = "btnYdyprint";
            this.btnYdyprint.Size = new System.Drawing.Size(128, 23);
            this.btnYdyprint.TabIndex = 100;
            this.btnYdyprint.Text = "已打印条码打印";
            this.btnYdyprint.UseVisualStyleBackColor = false;
            this.btnYdyprint.Visible = false;
            this.btnYdyprint.Click += new System.EventHandler(this.btnYdyprint_Click);
            // 
            // btnSelAll
            // 
            this.btnSelAll.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSelAll.Location = new System.Drawing.Point(18, 2);
            this.btnSelAll.Name = "btnSelAll";
            this.btnSelAll.Size = new System.Drawing.Size(40, 20);
            this.btnSelAll.TabIndex = 90;
            this.btnSelAll.Text = "全选";
            this.btnSelAll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelAll.UseVisualStyleBackColor = false;
            this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
            // 
            // btnUnSel
            // 
            this.btnUnSel.BackColor = System.Drawing.Color.PaleGreen;
            this.btnUnSel.Location = new System.Drawing.Point(62, 2);
            this.btnUnSel.Name = "btnUnSel";
            this.btnUnSel.Size = new System.Drawing.Size(40, 20);
            this.btnUnSel.TabIndex = 91;
            this.btnUnSel.Text = "反选";
            this.btnUnSel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUnSel.UseVisualStyleBackColor = false;
            this.btnUnSel.Click += new System.EventHandler(this.btnUnSel_Click);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(924, 456);
            this.myDataGrid1.TabIndex = 88;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.lblTxmInput);
            this.panel1.Controls.Add(this.txtTxmInput);
            this.panel1.Controls.Add(this.btReDo);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.chksqd);
            this.panel1.Controls.Add(this.chkbq);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txttxm);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtname);
            this.panel1.Controls.Add(this.txtcwh);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtzyh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 99);
            this.panel1.TabIndex = 77;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "请选择",
            "标本已采集",
            "标本未采集"});
            this.comboBox1.Location = new System.Drawing.Point(338, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 102;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(255, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 101;
            this.label7.Text = "标本采集状态";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Location = new System.Drawing.Point(831, 69);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(79, 25);
            this.btnOpen.TabIndex = 100;
            this.btnOpen.Text = "条码设计器";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblTxmInput
            // 
            this.lblTxmInput.AutoSize = true;
            this.lblTxmInput.Location = new System.Drawing.Point(364, 77);
            this.lblTxmInput.Name = "lblTxmInput";
            this.lblTxmInput.Size = new System.Drawing.Size(65, 12);
            this.lblTxmInput.TabIndex = 99;
            this.lblTxmInput.Text = "条形码扫描";
            // 
            // txtTxmInput
            // 
            this.txtTxmInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTxmInput.Location = new System.Drawing.Point(433, 70);
            this.txtTxmInput.Name = "txtTxmInput";
            this.txtTxmInput.Size = new System.Drawing.Size(139, 23);
            this.txtTxmInput.TabIndex = 98;
            this.txtTxmInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTxmInput_KeyPress);
            // 
            // btReDo
            // 
            this.btReDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btReDo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btReDo.Enabled = false;
            this.btReDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReDo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btReDo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btReDo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btReDo.ImageIndex = 0;
            this.btReDo.Location = new System.Drawing.Point(774, 25);
            this.btReDo.Name = "btReDo";
            this.btReDo.Size = new System.Drawing.Size(64, 32);
            this.btReDo.TabIndex = 97;
            this.btReDo.Text = "重编(&C)";
            this.btReDo.UseVisualStyleBackColor = false;
            this.btReDo.Click += new System.EventHandler(this.btReDo_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkBox1.Location = new System.Drawing.Point(775, 75);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 96;
            this.checkBox1.Text = "预览";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chksqd
            // 
            this.chksqd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chksqd.AutoSize = true;
            this.chksqd.Location = new System.Drawing.Point(601, 75);
            this.chksqd.Name = "chksqd";
            this.chksqd.Size = new System.Drawing.Size(84, 16);
            this.chksqd.TabIndex = 95;
            this.chksqd.Text = "打印申请单";
            this.chksqd.UseVisualStyleBackColor = true;
            // 
            // chkbq
            // 
            this.chkbq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbq.AutoSize = true;
            this.chkbq.Checked = true;
            this.chkbq.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbq.Location = new System.Drawing.Point(688, 75);
            this.chkbq.Name = "chkbq";
            this.chkbq.Size = new System.Drawing.Size(84, 16);
            this.chkbq.TabIndex = 94;
            this.chkbq.Text = "打印条形码";
            this.chkbq.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 93;
            this.label6.Text = "条形码";
            // 
            // txttxm
            // 
            this.txttxm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttxm.Location = new System.Drawing.Point(207, 70);
            this.txttxm.Name = "txttxm";
            this.txttxm.Size = new System.Drawing.Size(139, 23);
            this.txttxm.TabIndex = 92;
            this.txttxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttxm_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 87;
            this.label5.Text = "姓名";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(63, 72);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(97, 21);
            this.txtname.TabIndex = 86;
            this.txtname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtname_KeyPress);
            // 
            // txtcwh
            // 
            this.txtcwh.Location = new System.Drawing.Point(199, 42);
            this.txtcwh.Name = "txtcwh";
            this.txtcwh.Size = new System.Drawing.Size(50, 21);
            this.txtcwh.TabIndex = 84;
            this.txtcwh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcwh_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 83;
            this.label4.Text = "床号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 82;
            this.label3.Text = "住院号";
            // 
            // txtzyh
            // 
            this.txtzyh.Location = new System.Drawing.Point(63, 43);
            this.txtzyh.Name = "txtzyh";
            this.txtzyh.Size = new System.Drawing.Size(97, 21);
            this.txtzyh.TabIndex = 81;
            this.txtzyh.TextChanged += new System.EventHandler(this.txtzyh_TextChanged);
            this.txtzyh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtzyh_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 80;
            this.label2.Text = "到";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 79;
            this.label1.Text = "申请日期";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(185, 14);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(98, 21);
            this.dateTimePicker2.TabIndex = 78;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(64, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(98, 21);
            this.dateTimePicker1.TabIndex = 77;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rdowdy);
            this.groupBox3.Controls.Add(this.rdoydy);
            this.groupBox3.Location = new System.Drawing.Point(511, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(106, 58);
            this.groupBox3.TabIndex = 76;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择打印类型";
            // 
            // rdowdy
            // 
            this.rdowdy.Checked = true;
            this.rdowdy.Location = new System.Drawing.Point(6, 18);
            this.rdowdy.Name = "rdowdy";
            this.rdowdy.Size = new System.Drawing.Size(88, 16);
            this.rdowdy.TabIndex = 2;
            this.rdowdy.TabStop = true;
            this.rdowdy.Text = "选择未打印";
            this.rdowdy.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdowdy.Click += new System.EventHandler(this.btnRefresh_Click);
            this.rdowdy.CheckedChanged += new System.EventHandler(this.rdowdy_CheckedChanged);
            // 
            // rdoydy
            // 
            this.rdoydy.Location = new System.Drawing.Point(6, 40);
            this.rdoydy.Name = "rdoydy";
            this.rdoydy.Size = new System.Drawing.Size(88, 16);
            this.rdoydy.TabIndex = 1;
            this.rdoydy.Text = "选择已打印";
            this.rdoydy.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdoydy.Click += new System.EventHandler(this.btnRefresh_Click);
            this.rdoydy.CheckedChanged += new System.EventHandler(this.rdoydy_CheckedChanged);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(844, 25);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 32);
            this.btCancel.TabIndex = 72;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.Location = new System.Drawing.Point(634, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 32);
            this.btnRefresh.TabIndex = 74;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.ImageIndex = 0;
            this.btnPrint.Location = new System.Drawing.Point(704, 25);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(64, 32);
            this.btnPrint.TabIndex = 71;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(625, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(293, 47);
            this.button3.TabIndex = 73;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // frmjyd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(924, 555);
            this.Controls.Add(this.panel4);
            this.Name = "frmjyd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "检验单打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmjyd_Load);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmjyd_Load(object sender, EventArgs e)
        {
            //初始化
            //FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
            InitGrid();

            this.comboBox1.SelectedIndex = 0;

            //7088打印检验申请单时是否允许勾选已确费的申请 0=不是 1=是 By Tany 2011-05-19
            _cfg7088 = new SystemCfg(7088).Config;

            _cfg7135 = new SystemCfg(7135).Config;

            try
            {
                btnOpen.Visible = new SystemCfg(7188).Config == "1" ? true : false;
            }
            catch { btnOpen.Visible = false; }

            //4100检验申请单条码长度
            _txmLen = Convert.ToInt32(new SystemCfg(4100).Config);
            if (_txmLen > 0)
            {
                _txmStr = "";
                for (int i = 0; i < _txmLen; i++)
                {
                    _txmStr += "0";
                }
            }

            //4101检验申请单条码生成方式 0=自动生成 1=读取现有条码
            _txmType = Convert.ToInt32(new SystemCfg(4101).Config);
            if (_txmType == 1)
            {
                chkbq.Checked = false;
                chkbq.Enabled = false;
                chksqd.Checked = true;

                lblTxmInput.Visible = true;
                txtTxmInput.Visible = true;

                btnSelAll.Enabled = false;
                btnUnSel.Enabled = false;

                txtTxmInput.Focus();
            }
            else
            {
                btnSelAll.Enabled = true;
                btnUnSel.Enabled = true;

                lblTxmInput.Visible = false;
                txtTxmInput.Visible = false;
            }
            try
            {
                tbBfz = FrmMdiMain.Database.GetDataTable("select * from JC_JYBBFLMX_bfl ");
            }
            catch { }
        }

        //Add By Tany 2011-05-19
        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;

            string TypeStr = sender.GetType().ToString();
            if (sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn"
                || sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn")
            {

                myDataGrid.myDataGrid DataGrid = new myDataGrid.myDataGrid();
                switch (TypeStr)
                {
                    case "TrasenClasses.GeneralControls.DataGridEnableBoolColumn":
                        {
                            DataGrid = (myDataGrid.myDataGrid)((((TrasenClasses.GeneralControls.DataGridEnableBoolColumn)sender).DataGridTableStyle).DataGrid);
                            break;
                        }
                    case "TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn":
                        {
                            DataGrid = (myDataGrid.myDataGrid)((((TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn)sender).DataGridTableStyle).DataGrid);
                            break;
                        }
                }

                DataTable myTb = (DataTable)DataGrid.DataSource;
                if (myTb == null || myTb.Rows.Count == 0)
                    return;

                int nrow = e.Row;

                if (nrow >= myTb.Rows.Count)
                    return;

                if (DataGrid.TableStyles[0].GridColumnStyles.Contains("选"))
                {
                    if (Convert.ToBoolean(myTb.Rows[nrow]["选"]))
                    {
                        e.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        e.BackColor = Color.White;
                    }
                }
            }
        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                ParameterEx[] parameters = new ParameterEx[13];
                parameters[0].Value = 0;
                parameters[1].Value = InstanceForm.BCurrentDept.WardId.Trim();
                parameters[2].Value = this.dateTimePicker1.Value.ToShortDateString() + " 00:00:01";
                parameters[3].Value = this.dateTimePicker2.Value.ToShortDateString() + " 23:59:59";
                parameters[4].Value = this.rdoydy.Checked == true ? 1 : 0;
                parameters[5].Value = txtzyh.Text.Trim();
                parameters[6].Value = txtcwh.Text.Trim();
                parameters[7].Value = txtname.Text.Trim();
                parameters[8].Value = txttxm.Text.Trim();
                parameters[9].Value = "";
                parameters[10].Value = "";
                parameters[11].Value = 0;
                parameters[12].Value = this.comboBox1.Text;

                parameters[0].Text = "@lx";
                parameters[1].Text = "@wardid";
                parameters[2].Text = "@sqrq1";
                parameters[3].Text = "@sqrq2";
                parameters[4].Text = "@dybz";
                parameters[5].Text = "@zyh";
                parameters[6].Text = "@cwh";
                parameters[7].Text = "@name";
                parameters[8].Text = "@txm";
                parameters[9].Text = "@qrrq1";
                parameters[10].Text = "@qrrq2";
                parameters[11].Text = "@zxks";
                parameters[12].Text = "@BBCJZT";
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_zyhs_getjchy", parameters, 60);
                FunBase.AddRowtNo(tb);
                //tb.TableName = "Tb";

                #region 条码
                if (rdowdy.Checked == true)
                {
                    /*
                                    //汇总当前的分类
                                    string[] GroupbyField1 ={ "inpatient_id","项目分类","标本类型" };
                                    string[] ComputeField1 ={ };
                                    string[] CField1 ={ };
                                    TrasenFrame.Classes.TsSet tsset1 = new TrasenFrame.Classes.TsSet();
                                    tsset1.TsDataTable = tb;
                                    DataTable tab = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "条形码=''");
                                    tab.Columns.Add("txm", System.Type.GetType("System.String"));
                                    tab.Columns.Add("order_id", System.Type.GetType("System.String"));
                                    tab.Columns.Add("rowcount", System.Type.GetType("System.Int32"));
                                    tab.Columns.Add("分组", System.Type.GetType("System.String"));


                                        //产生每组分类的条形码
                                        for (int i = 0; i <= tab.Rows.Count - 1; i++)
                                        {
                                            long txm = 0;
                                            string order_id = "(";
                                            int rowcount = 0;

                                            //DataRow[] selrow = tb.Select(" inpatient_id='" + tab.Rows[id]["inpatient_id"].ToString().Trim() + "' and 项目分类='"+tab.Rows[id]["项目分类"].ToString().Trim()+"','"+tab.Rows[id]["标本类型"].ToString().Trim()+"'");
                                            for (int j = 0; j <= tb.Rows.Count - 1; j++)
                                            {
                                                if (tab.Rows[i]["inpatient_id"].ToString().Trim() == tb.Rows[j]["inpatient_id"].ToString().Trim() && tab.Rows[i]["项目分类"].ToString().Trim() == tb.Rows[j]["项目分类"].ToString().Trim() && tab.Rows[i]["标本类型"].ToString().Trim() == tb.Rows[j]["标本类型"].ToString().Trim())
                                                {
                                                    txm = Convert.ToInt64(txm) + Convert.ToInt64(tb.Rows[j]["order_id"]);
                                                    order_id = order_id + tb.Rows[j]["order_id"] + ",";
                                                    rowcount = rowcount + 1;
                                                    tb.Rows[j]["分组"] = i.ToString();
                                                }
                                            }
                                            order_id = order_id + "0)";

                                            tab.Rows[i]["TXM"] = txm.ToString(_txmStr);
                                            tab.Rows[i]["order_id"] = order_id;
                                            tab.Rows[i]["rowcount"] = rowcount;
                                            tab.Rows[i]["分组"] = i.ToString();
                                        }


                                        try
                                        {
                                            //将条形码更新到申请表
                                            InstanceForm.BDatabase.BeginTransaction();
                                            for (int i = 0; i <= tab.Rows.Count - 1; i++)
                                            {
                                                String ssql = "update YJ_APPLYRECORD set txm='" + tab.Rows[i]["txm"].ToString().Trim() + "' where orderid in " + tab.Rows[i]["order_id"].ToString() + " and txm is null  ";
                                                int iii = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(ssql, 30);
                                                if (iii != Convert.ToInt64(tab.Rows[i]["rowcount"]))
                                                    throw new Exception("数据可能在别处已被更新，请重新刷新数据");
                                            }
                                            InstanceForm.BDatabase.CommitTransaction();

                                            //将条形码加到网格中
                                            for (int i = 0; i <= tab.Rows.Count - 1; i++)
                                            {
                                                for (int j = 0; j <= tb.Rows.Count - 1; j++)
                                                {
                                                    if (tab.Rows[i]["分组"].ToString().Trim() == tb.Rows[j]["分组"].ToString().Trim())
                                                        tb.Rows[j]["条形码"] = tab.Rows[i]["txm"];
                                                }
                                            }
                                        }
                                        catch (System.Exception err)
                                        {
                                            InstanceForm.BDatabase.RollbackTransaction();
                                            this.btnRefresh_Click(sender, e);
                                            MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                      */
                }

                #endregion

                DataColumn col = new DataColumn();
                col.DataType = System.Type.GetType("System.Boolean");
                col.AllowDBNull = false;
                col.ColumnName = "选";

                col.DefaultValue = false;
                tb.Columns.Add(col);

                this.myDataGrid1.DataSource = tb;
                //FunBase.myGridSelect(this.myDataGrid1, this.myDataGrid1.TableStyles[0].GridColumnStyles);
                //add by zouchihua 2012-11-21 相同的医嘱项目不打在一张条码上
                if (rdowdy.Checked)
                {
                    #region//add by zouchihua 2013-6-27 不能打在一起
                    try
                    {
                        if (tbBfz.Rows.Count > 0)
                        {
                            for (int i = 0; i < tb.Rows.Count; i++)
                            {
                                //如果项目id在tbBfz里面
                                DataRow[] row = tbBfz.Select("YZXMID=" + tb.Rows[i]["YZXMID"].ToString() + "");
                                if (row.Length > 0)
                                {
                                    for (int j = i; j < tb.Rows.Count; j++)
                                    {
                                        if (i != j &&
                                            tb.Rows[i]["INPATIENT_ID"].ToString().Trim() == tb.Rows[j]["INPATIENT_ID"].ToString().Trim() &&
                                            tb.Rows[i]["分组"].ToString() == tb.Rows[j]["分组"].ToString()
                                            )
                                        {
                                            for (int k = 0; k < row.Length; k++)
                                            {
                                                if (tbBfz.Select("bflid=" + row[k]["bflid"] + "  and  yzxmid=" + tb.Rows[j]["YZXMID"].ToString()).Length > 0)//如果两个都在分类中 说明不能打在一起
                                                    //把相同的组号改为不同
                                                    tb.Rows[j]["分组"] = "-1" + tb.Rows[j]["id"].ToString();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex) { }
                    #endregion
                    string[] GroupbyField ={ "inpatient_id", "baby_id", "分组", "附加说明", "sqrq", "标本类型" };
                    string[] ComputeField ={ };
                    string[] CField ={ };
                    TrasenFrame.Classes.TsSet tsset = new TrasenFrame.Classes.TsSet();
                    tsset.TsDataTable = tb;
                    DataTable patTb = tsset.GroupTable(GroupbyField, ComputeField, CField, "");
                    ArrayList argroup = new ArrayList();
                    for (int k = 0; k < patTb.Rows.Count; k++)
                    {
                        DataRow[] row = tb.Select(" inpatient_id='" + patTb.Rows[k]["inpatient_id"].ToString() + "' and baby_id=" + patTb.Rows[k]["baby_id"].ToString() + " and 分组=" + patTb.Rows[k]["分组"].ToString() +
                                       "and 附加说明='" + patTb.Rows[k]["附加说明"].ToString() + "'  and sqrq='" + patTb.Rows[k]["sqrq"].ToString() + "'  and  标本类型='" + patTb.Rows[k]["标本类型"].ToString() + "'");
                        for (int i = 0; i < row.Length; i++)
                        {
                            row[i]["分组"] = 90000 + k + 1;
                        }
                    }

                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        for (int j = i; j < tb.Rows.Count; j++)
                        {
                            if (i != j &&
                                tb.Rows[i]["INPATIENT_ID"].ToString().Trim() == tb.Rows[j]["INPATIENT_ID"].ToString().Trim() &&
                                tb.Rows[i]["分组"].ToString() == tb.Rows[j]["分组"].ToString()
                                &&
                                tb.Rows[i]["YZXMID"].ToString() == tb.Rows[j]["YZXMID"].ToString()
                                // &&(tb.Rows[j]["附加说明"].ToString().Trim()!=""&&  tb.Rows[i]["附加说明"].ToString().Trim() != tb.Rows[j]["附加说明"].ToString().Trim() )  //附加说明不一样要分开 Mofiby by zouchihua 2013-7-3
                                )
                            {
                                //把相同的组号改为不同
                                tb.Rows[j]["分组"] = "-1" + tb.Rows[j]["id"].ToString();
                            }
                        }
                    }
                }
                InitGrid();

                SetStyle(tb, this.myDataGrid1);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 设置标本采集时间样式 --Add by Eric 2014-04-15
        /// </summary>
        /// <param name="table"></param>
        /// <param name="grid"></param>
        public void SetStyle(DataTable table, DataGridEx grid)
        {
            CurrencyManager cm = (CurrencyManager)this.BindingContext[table];
            DataGridTableStyle style = this.myDataGrid1.TableStyles[0];
            style.MappingName = table.TableName;

            foreach (DataColumn col in table.Columns)
            {
                if (col.ColumnName == "标本采集时间")
                {
                    PropertyDescriptor pd = cm.GetItemProperties()[col.ColumnName];
                    ((DataGridTextBoxColumn)style.GridColumnStyles[pd]).Format = "yyyy-MM-dd HH:mm:ss";
                }
            }
            grid.TableStyles.Add(style);
        }

        //Add By Tany 2011-05-20
        private void InitGrid()
        {
            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();

            string[] GrdMappingName1 ={ "yjsqid", 
                                        "id",
                                        "序号",
                                        "选",
                                        "打印",
                                        "状态",
                                        "签收状态",
                                        "病区", 
                                        "住院号", 
                                        "床号",
                                        "姓名", 
                                        "性别",
                                        "年龄", 
                                        "条形码",
                                        "项目内容",
                                        "简称", 
                                        "金额",
                                        "执行科室",
                                        "项目分类",
                                        "标本类型", 
                                        "附加说明", 
                                        "申请日期",
                                        "标本采集时间",
                                        "申请医生",
                                        "确认日期", 
                                        "确认人",
                                        "诊断及病史", 
                                        "order_id", 
                                        "lx",
                                        "ipatient_id", 
                                        "分组",
                                        "分类名称",
                                        "打印时间",
                                        "打印人",
                                        "取消签收原因" };
            int[] GrdWidth1 ={ 0,
                0, 
                4, 
                3,
                5, 
                7,
                10,
                0, 
                9, 
                6, 
                7,
                0,
                0, 
                12,
                21,
                20, 
                8, 
                9, 
                0,
                9, 
                11, 
                11,
                20, 
                7, 
                11,
                7, 
                18, 
                0,
                0, 
                0,
                6,
                10 ,
                13,
                6,
                23};
            int[] Alignment1 ={ 0,
                0,
                1,
                1,
                1,
                1,
                0, 
                0,
                0, 
                0, 
                0,
                0, 
                0,
                0,
                0,
                0, 
                2,
                0,
                0,
                0,
                0, 
                0,
                0, 
                0,
                0,
                0, 
                0,
                0,
                0,
                0, 
                0,
                0,
                0,
                0,
                0};
            int[] ReadOnly1 ={ 
                0,
                0,
                0, 
                0,
                0,
                0,
                0,
                0, 
                0, 
                0,
                0, 
                0,
                0,
                0,
                0, 
                0,
                0,
                0, 
                0, 
                0, 
                0, 
                0,
                1, 
                0,
                0, 
                0,
                0,
                0, 
                0, 
                0, 
                0,
                0,
                0,
                0,
                0};
            myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);
            //PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);// Modify by Eric 2014-04-14 设置单元格可以输入
        }

        private void myDataGrid1_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (tb == null || tb.Rows.Count == 0) return;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (tb.Rows.Count == 0) return;
            if (tb.Rows[nrow]["状态"].ToString().Trim() == "作废") return;
            //Modify By tany 2011-05-19
            //7088打印检验申请单时是否允许勾选已确费的申请 0=不是 1=是
            if (tb.Rows[nrow]["状态"].ToString().Trim() == "已确费" && _cfg7088 == "0") return;

            if (Convert.ToBoolean(tb.Rows[nrow]["选"]) == false)
            {
                //Modify By tany 2011-06-07 如果是读取已有条码，并且是未打印状态，判断分组ID是不是一样
                if (_txmType == 1 && rdowdy.Checked)
                {
                    //Modify By tany 2011-05-27 不再限制，打印时自动分组
                    DataRow[] drs = tb.Select("选=1");
                    if (drs.Length > 0)
                    {
                        if (tb.Rows[nrow]["inpatient_id"].ToString().Trim() != drs[0]["inpatient_id"].ToString().Trim()
                            || tb.Rows[nrow]["姓名"].ToString().Trim() != drs[0]["姓名"].ToString().Trim())
                        {
                            if (MessageBox.Show("不能同时打印不同病人的化验检查项目！", "化验单提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                tb.Rows[nrow]["选"] = (short)0;
                                return;
                            }
                        }
                        //if (tb.Rows[nrow]["条形码"].ToString().Trim() != drs[0]["条形码"].ToString().Trim())
                        //{
                        //    if (MessageBox.Show("不能同时打印不同条码的化验检查项目！", "化验单提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        //    {
                        //        tb.Rows[nrow]["选"] = (short)0;
                        //        return;
                        //    }
                        //}
                        //if (tb.Rows[nrow]["标本类型"].ToString().Trim() != drs[0]["标本类型"].ToString().Trim())
                        //{
                        //    if (MessageBox.Show("不能同时打印不同标本的化验检查项目！", "化验单提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        //    {
                        //        tb.Rows[nrow]["选"] = (short)0;
                        //        return;
                        //    }
                        //}
                        if (tb.Rows[nrow]["分组"].ToString().Trim() != drs[0]["分组"].ToString().Trim())
                        {
                            if (MessageBox.Show("不能同时打印不同分组的化验检查项目！", "化验单提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                tb.Rows[nrow]["选"] = (short)0;
                                return;
                            }
                        }
                    }
                }
                tb.Rows[nrow]["选"] = (short)1;
            }
            else
            {
                tb.Rows[nrow]["选"] = (short)0;
            }
            //Modify By tany 2011-05-20 相同分组的必须一起选中，但是可以单个反选
            if (rdowdy.Checked)
            {
                if (Convert.ToBoolean(tb.Rows[nrow]["选"]) && Convert.ToInt32(tb.Rows[nrow]["分组"]) != 0)
                {
                    //modify by zouchihua 2011-11-21 如果有加急或者急的单独出来
                    if ((tb.Rows[nrow]["项目内容"].ToString().IndexOf("急") >= 0 && (tb.Rows[nrow]["项目内容"].ToString().IndexOf("急诊") < 0)) || (tb.Rows[nrow]["项目内容"].ToString().IndexOf("加急") >= 0))
                    {
                        DataRow[] drsfz = tb.Select("inpatient_id='" + tb.Rows[nrow]["inpatient_id"].ToString().Trim() + "' and baby_id=" + tb.Rows[nrow]["baby_id"].ToString().Trim() + " and 分组=" + tb.Rows[nrow]["分组"].ToString().Trim() + " and (( 项目内容 like '%急%' and 项目内容 not like '%急诊%') or 项目内容 like '%加急%'  ) ");
                        foreach (DataRow dr in drsfz)
                        {
                            dr["选"] = tb.Rows[nrow]["选"];
                        }
                    }
                    else
                    {
                        DataRow[] drsfz = tb.Select("inpatient_id='" + tb.Rows[nrow]["inpatient_id"].ToString().Trim() + "' and baby_id=" + tb.Rows[nrow]["baby_id"].ToString().Trim() + " and 分组=" + tb.Rows[nrow]["分组"].ToString().Trim() + " and ( 项目内容 not like '%急%' or (项目内容  like '%急诊%' and  项目内容 not like '%加急%' ))");
                        foreach (DataRow dr in drsfz)
                        {
                            dr["选"] = tb.Rows[nrow]["选"];
                        }
                    }
                }
            }
            //Modify By tany 2011-04-28 已打印的同一条码必须在一起选择
            if (rdoydy.Checked)
            {
                DataRow[] drs = tb.Select("条形码='" + tb.Rows[nrow]["条形码"].ToString().Trim() + "'");
                foreach (DataRow dr in drs)
                {
                    dr["选"] = tb.Rows[nrow]["选"];
                }
            }

            //Modify By tany 2011-06-07 
            if (txtTxmInput.Visible)
            {
                txtTxmInput.Focus();
            }
            #region//选择不能超过4个选项   2008年6月19号邵阳修改
            //int j = 0;//控制参数
            ////Modify By tany 2011-04-12
            //j = tb.Select("选=1").Length;
            //if (j > 4)
            //{
            //    if (MessageBox.Show("化验检查项目不能超过4个", "化验单提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            //    {
            //        tb.Rows[nrow]["选"] = (short)0;
            //    }
            //}
            //for (int i = 0; i < tb.Rows.Count-1; i++)
            //{
            //    if (Convert.ToBoolean(tb.Rows[i]["选择"]) == true)
            //    {
            //        j++;
            //        if (j>4)
            //        {
            //            if (MessageBox.Show("化验检查项目不能超过4个", "化验单提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            //            {
            //                tb.Rows[nrow]["选择"] = (short)0;
            //            }
            //        }
            //    }
            //}
            #endregion
            #region
            //////////DataRow[] selrow = tb.Select("条形码='"+tb.Rows[nrow]["条形码"].ToString().Trim()+"'");
            ////////string txm = tb.Rows[nrow]["条形码"].ToString().Trim();
            ////////for (int i = 0; i <= tb.Rows.Count - 1; i++)
            ////////{
            ////////    if (tb.Rows[i]["条形码"].ToString().Trim() == txm )
            ////////    {
            ////////        if (Convert.ToBoolean(tb.Rows[i]["选择"]) == false)
            ////////              tb.Rows[i]["选择"] = (short)1;
            ////////        else
            ////////              tb.Rows[i]["选择"] = (short)0;

            ////////    }
            ////////    //else
            ////////    //{
            ////////    //    tb.Rows[i]["选择"] = (short)0;
            ////////    //}
            ////////}
            #endregion
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //this.printPreviewDialog1.ShowDialog();
            //Add by Eric 2014-04-17 兼容旧的设计模式文档
            TrasenCommon.OperateXML.CompatibilityXMLFile(xmlFile1, xmlFile, tempFile);
            lastRow = this.myDataGrid1.CurrentCell.RowNumber;

            try
            {
                String ssql = "";
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }

                List<DataRow> list = new List<DataRow>();
                //Modify By Tany 2011-04-28 已打印的不再更新条码
                if (rdowdy.Checked)
                {
                    //条形码条形码条形码条形码条形码条形码条形码条形码
                    DataRow[] sel = tb.Select("选=true");
                    DataRow[] jsel = tb.Select("选=true");//add by zouchihua 记录加急的标本
                    if (sel.Length == 0)
                    {
                        MessageBox.Show("请选择需要打印的内容！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (_txmType == 1)
                    {
                        if (txtTxmInput.Text.Trim() == "" || !Convertor.IsNumeric(txtTxmInput.Text.Trim()))
                        {
                            MessageBox.Show("请输入正确的条码号！");
                            txtTxmInput.Focus();
                            return;
                        }
                    }
                    long Nid = 1;
                    //Modify By tany 2011-05-27 改变打印逻辑，可以选择多条打印，自动分组
                    //汇总当前的分类
                    string[] GroupbyField ={ "inpatient_id", "baby_id", "分组" };
                    string[] ComputeField ={ };
                    string[] CField ={ };
                    TrasenFrame.Classes.TsSet tsset = new TrasenFrame.Classes.TsSet();
                    tsset.TsDataTable = tb;
                    DataTable patTb = tsset.GroupTable(GroupbyField, ComputeField, CField, "选=true");
                    for (int k = 0; k < patTb.Rows.Count; k++)
                    {

                        sel = tb.Select("选=true and inpatient_id='" + patTb.Rows[k]["inpatient_id"].ToString() + "' and baby_id=" + patTb.Rows[k]["baby_id"].ToString() + " and 分组=" + patTb.Rows[k]["分组"].ToString() + " and ((项目内容 not like '%急%') or (项目内容 like '%急诊%' and 项目内容 not like '%加急%') )");
                        if (sel.Length > 0)
                        {
                            if (_txmType == 1)
                            {
                                Nid = Convert.ToInt64(txtTxmInput.Text.Trim());

                                //检索当前条码是否已经存在
                                if (Convert.ToInt32(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select count(1) from YJ_ZYSQ where txm='" + Nid.ToString(_txmStr) + "'"), "0")) > 0)
                                {
                                    MessageBox.Show("当前的条形码已经存在，请验证！");
                                    txtTxmInput.Focus();
                                    txtTxmInput.SelectAll();
                                    return;
                                }
                            }
                            else
                            {
                                Nid = Convert.ToInt64(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select no + 1 from JC_IDENTITY where rowtype=11   update JC_IDENTITY set no = no + 1 where rowtype=11"), "1"));//Modify By tany 2010-12-23 条码取jc_identity表11的数据
                                //add by zouchihua 2013-7-19 解决并发问题
                                try
                                {
                                    //type 11 住院条码
                                    string insert = " insert into jc_lock  ( no,type) values(" + Nid.ToString() + ",11)";
                                    FrmMdiMain.Database.DoCommand(insert);
                                    string del = "delete from  [jc_lock] where crsj<=GETDATE()-1  and type=11";
                                    FrmMdiMain.Database.DoCommand(del);
                                }
                                catch
                                {
                                    MessageBox.Show("当前的条形码已经存在，请重试！");
                                    return;
                                }
                            }
                            string Syjsqid = " (";
                            for (int i = 0; i <= sel.Length - 1; i++)
                            {
                                Syjsqid = Syjsqid + "'" + sel[i]["yjsqid"] + "',";//
                            }
                            Syjsqid = Syjsqid.Substring(0, Syjsqid.Length - 1) + ")";

                            //将条形码更新到申请表
                            ssql = "update YJ_ZYSQ set txm='" + Nid.ToString(_txmStr) + "' where yjsqid in " + Syjsqid + "  ";
                            int iii = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(ssql, 30);
                            if (iii != sel.Length)
                                throw new Exception("数据可能在别处已被更新，请重新刷新数据");

                            for (int i = 0; i <= tb.Rows.Count - 1; i++)
                            {
                                if (Convert.ToInt16(tb.Rows[i]["选"]) == 1
                                    && tb.Rows[i]["inpatient_id"].ToString().Trim() == patTb.Rows[k]["inpatient_id"].ToString().Trim()
                                    && tb.Rows[i]["baby_id"].ToString().Trim() == patTb.Rows[k]["baby_id"].ToString().Trim()
                                    && tb.Rows[i]["分组"].ToString().Trim() == patTb.Rows[k]["分组"].ToString().Trim()
                                    &&
                                      ((tb.Rows[i]["项目内容"].ToString().Trim().IndexOf("急") < 0) ||
                                            (tb.Rows[i]["项目内容"].ToString().Trim().IndexOf("急诊") >= 0
                                          && tb.Rows[i]["项目内容"].ToString().Trim().IndexOf("加急") < 0)
                                       )
                                    )
                                {
                                    tb.Rows[i]["条形码"] = Nid.ToString(_txmStr);
                                }
                            }
                        }
                        jsel = tb.Select("选=true and inpatient_id='" + patTb.Rows[k]["inpatient_id"].ToString() + "' and baby_id=" + patTb.Rows[k]["baby_id"].ToString() + " and 分组=" + patTb.Rows[k]["分组"].ToString() + " and (  ( 项目内容  like '%急%' and 项目内容 not like '%急诊%') or 项目内容 like '%加急%'  ) ");
                        if (jsel.Length > 0)
                        {
                            #region // 加急 add by zouchihua 2011-11-28
                            if (_txmType == 1)
                            {
                                Nid = Convert.ToInt64(txtTxmInput.Text.Trim());

                                //检索当前条码是否已经存在
                                if (Convert.ToInt32(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select count(1) from YJ_ZYSQ where txm='" + Nid.ToString(_txmStr) + "'"), "0")) > 0)
                                {
                                    MessageBox.Show("当前的条形码已经存在，请验证！");
                                    txtTxmInput.Focus();
                                    txtTxmInput.SelectAll();
                                    return;
                                }
                            }
                            else
                            {
                                Nid = Convert.ToInt64(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select no + 1 from JC_IDENTITY where rowtype=11  update JC_IDENTITY set no = no + 1 where rowtype=11"), "1"));//Modify By tany 2010-12-23 条码取jc_identity表11的数据
                                //add by zouchihua 2013-7-19 解决并发问题
                                try
                                {
                                    //type 11 住院条码

                                    string insert = " insert into jc_lock  ( no,type) values(" + Nid.ToString() + ",11)";
                                    FrmMdiMain.Database.DoCommand(insert);
                                    string del = "delete from  [jc_lock] where crsj<=GETDATE()-1  and type=11";
                                    FrmMdiMain.Database.DoCommand(del);
                                }
                                catch
                                {
                                    MessageBox.Show("当前的条形码已经存在，请重试！");
                                    return;
                                }
                            }
                            string Syjsqid = " (";
                            for (int i = 0; i <= jsel.Length - 1; i++)
                            {
                                Syjsqid = Syjsqid + "'" + jsel[i]["yjsqid"] + "',";//
                            }
                            Syjsqid = Syjsqid.Substring(0, Syjsqid.Length - 1) + ")";

                            //将条形码更新到申请表
                            ssql = "update YJ_ZYSQ set txm='" + Nid.ToString(_txmStr) + "' where yjsqid in " + Syjsqid + "  ";
                            int iii = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(ssql, 30);
                            if (iii != jsel.Length)
                                throw new Exception("数据可能在别处已被更新，请重新刷新数据");
                            for (int i = 0; i <= tb.Rows.Count - 1; i++)
                            {
                                if (Convert.ToInt16(tb.Rows[i]["选"]) == 1
                                    && tb.Rows[i]["inpatient_id"].ToString().Trim() == patTb.Rows[k]["inpatient_id"].ToString().Trim()
                                    && tb.Rows[i]["baby_id"].ToString().Trim() == patTb.Rows[k]["baby_id"].ToString().Trim()
                                    && tb.Rows[i]["分组"].ToString().Trim() == patTb.Rows[k]["分组"].ToString().Trim()
                                    && ((tb.Rows[i]["项目内容"].ToString().Trim().IndexOf("急") >= 0 && tb.Rows[i]["项目内容"].ToString().Trim().IndexOf("急诊") < 0)
                                          || tb.Rows[i]["项目内容"].ToString().Trim().IndexOf("加急") >= 0)
                                    )
                                {
                                    tb.Rows[i]["条形码"] = Nid.ToString(_txmStr);
                                }
                            }
                            #endregion
                        }
                    }
                }

                //汇总当前的分类
                string[] GroupbyField1 ={ "条形码" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet tsset1 = new TrasenFrame.Classes.TsSet();
                tsset1.TsDataTable = tb;
                DataTable tab = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "选=true");

                if (tab == null || tab.Rows.Count == 0)
                {
                    MessageBox.Show("请选择需要打印的内容！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ts_zyhs_classes.TheReportDateSet Dset = new ts_zyhs_classes.TheReportDateSet();
                string sTxm = " (";

                for (int III = 0; III <= tab.Rows.Count - 1; III++)
                {
                    sTxm += "'" + tab.Rows[III]["条形码"].ToString() + "'";
                    if (III < tab.Rows.Count - 1)
                    {
                        sTxm += ",";
                    }
                    else
                    {
                        sTxm += ") ";
                    }

                    DataRow myrow;

                    string xm = "";
                    string xmcx = "";//重新的长度为7的字符串
                    DataRow[] selrow = tb.Select(" 条形码='" + tab.Rows[III]["条形码"].ToString().Trim() + "'");

                    int jdcd = 7;//截断字符长度
                    try
                    {
                        jdcd = Int32.Parse(cfg7157.Config.Trim());
                    }
                    catch { }
                    //Modify By Tany 2011-05-31 组合项目放在前面
                    for (int i = 0; i <= selrow.Length - 1; i++)
                    {
                        //add by zouchihua  有简称时使用简称
                        if (selrow[i]["简称"].ToString() == "")
                        {
                            //modify by zouchihua 2013-7-3 打印内容为申请内容
                            string nrstr = selrow[i]["项目内容"].ToString();//明晨抽血查凝血酶时间测定
                            try
                            {
                                //add by zouchihua 2013-8-23 验证申请内容和医嘱是否一致
                                if (selrow[i]["项目内容"].ToString().IndexOf(selrow[i]["申请内容"].ToString()) >= 0)
                                    nrstr = selrow[i]["申请内容"].ToString();// +"(" + selrow[i]["附加说明"].ToString() + ")"; 附加说明不要打印出来
                                else
                                    nrstr = selrow[i]["项目内容"].ToString();
                            }
                            catch { }
                            //2008年6月19号邵阳修改   截取字符串
                            if (nrstr.Length > jdcd)
                            {
                                xmcx = nrstr.Substring(0, jdcd);
                            }
                            else
                            {
                                xmcx = nrstr.ToString();
                            }
                        }
                        else
                        {
                            if (selrow[i]["简称"].ToString().Length > jdcd)
                            {
                                xmcx = selrow[i]["简称"].ToString().Substring(0, jdcd);

                            }
                            else
                            {
                                xmcx = selrow[i]["简称"].ToString();
                            }
                            //add by zouchihua 2013-6-6 如果是急，检查也要加
                            if (selrow[i]["项目内容"].ToString().IndexOf("急") >= 0)
                            {
                                xmcx += "(急)";
                            }
                            // xmcx = selrow[i]["简称"].ToString();
                        }
                        if (xm.Length % 14 + xmcx.Length < 14)
                            xm += xmcx.Trim() + "  ";
                        else
                            xm += xmcx.Trim() + "  ";
                        //switch (i)
                        //{
                        //    case 0:
                        //        xm += xmcx.Trim() + "  ";
                        //        break;
                        //    case 1:
                        //        xm += xmcx.Trim()+"  ";// +"\n";
                        //        break;
                        //    case 2:
                        //        xm += xmcx.Trim() + "  ";
                        //        break;
                        //    default:
                        //        xm += xmcx.Trim()+"  ";// +"\n";
                        //        break;
                        //}
                    }
                    for (int i = 0; i <= selrow.Length - 1; i++)
                    {
                        myrow = Dset.tabJYSQD.NewRow();

                        #region 处理myrow

                        // myrow["条形码图片"] = "";
                        // myrow["编号"] = xx.ToString();
                        myrow["条形码"] = tab.Rows[III]["条形码"].ToString().Trim();
                        myrow["住院号"] = selrow[i]["住院号"].ToString();
                        myrow["姓名"] = selrow[i]["姓名"].ToString();
                        myrow["性别"] = selrow[i]["性别"].ToString();
                        myrow["年龄"] = selrow[i]["年龄"].ToString();
                        //add by  zouchihua 2013-8-21 把颜色改为
                        string ys = "";
                        #region 颜色
                        switch (selrow[i]["颜色名称"].ToString().Trim())
                        {
                            case "red":
                                ys = "红色";
                                break;
                            case "brown":
                                ys = "褐色";
                                break;
                            case "blue":
                                ys = "蓝色";
                                break;
                            case "black":
                                ys = "黑色";
                                break;
                            case "purple":
                                ys = "紫色";
                                break;
                            case "green":
                                ys = "绿色";
                                break;
                            default:
                                ys = selrow[i]["颜色名称"].ToString().Trim();
                                break;

                        }
                        #endregion
                        myrow["科室"] = ys;
                        myrow["病区"] = InstanceForm.BCurrentDept.WardName;
                        myrow["床号"] = selrow[i]["床号"].ToString();
                        myrow["标本"] = selrow[i]["标本类型"].ToString();
                        myrow["项目分类"] = selrow[i]["项目分类"].ToString();
                        myrow["项目内容"] = selrow[i]["项目内容"];
                        myrow["申请医生"] = selrow[i]["申请医生"].ToString();
                        myrow["附加说明"] = selrow[i]["附加说明"].ToString();
                        myrow["诊断及病史"] = selrow[i]["诊断及病史"].ToString();
                        myrow["申请日期"] = Convert.ToDateTime(selrow[i]["申请日期"]);
                        myrow["价格"] = selrow[i]["金额"].ToString();
                        myrow["xmmc"] = xm;
                        //生成条形码图片
                        BarcodeLib.Barcode b = new BarcodeLib.Barcode(tab.Rows[III]["条形码"].ToString().Trim(), BarcodeLib.TYPE.CODE128);
                        Image im = b.Encode();
                        int wide = im.Width;
                        int height = im.Height;
                        try
                        {
                            string[] ss = cfg7181.Config.Split(',');
                            wide = int.Parse(ss[0]);
                            height = int.Parse(ss[1]);
                        }
                        catch
                        {
                            wide = im.Width;
                            height = im.Height;
                        }
                        im = Resize(wide, height, im);
                        //  im.Save("d:\\txm.Jpeg");
                        //MemoryStream ms = new MemoryStream(); 
                        //BinaryFormatter bf = new BinaryFormatter();  
                        //bf.Serialize(ms, (object)im);
                        MemoryStream ms = new MemoryStream();
                        im.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                        //byte[] by = ms.ToArray();
                        //MemoryStream ms1 = new MemoryStream(by, 0, by.Length);
                        //FileStream fs = new FileStream("d:\\txm1.jpg", FileMode.OpenOrCreate);
                        //fs.Write(by, 0, by.Length);

                        //return bytes;
                        //
                        //myrow["条形码[图片]"] = ms.ToArray();

                        #endregion

                        Dset.tabJYSQD.Rows.Add(myrow);
                        list.Add(myrow);
                        ms.Close();
                        if (rdowdy.Checked == true)
                        {
                            tb.Rows.Remove(selrow[i]);
                        }
                    }
                }

                #region  检验申请单//条码
                //Modify By tany 2011-05-31 循环输送数据打印改成一次性送全部数据到dataset一起打印
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "检验申请单";
                parameters[1].Text = "打印者";
                parameters[1].Value = InstanceForm.BCurrentUser.Name;
                parameters[2].Text = "xmmc";
                parameters[2].Value = "";

                bool bview = this.checkBox1.Checked == true ? false : true;
                try
                {
                    //改为点击打印才更新
                    //InstanceForm.BDatabase.BeginTransaction();
                    ssql = "update YJ_ZYSQ set BJLDYBZ=1,dysj=getdate(),dyid1=" + FrmMdiMain.CurrentUser.EmployeeId + " where txm in " + sTxm + " and BJLDYBZ=0";//把dyid1记录打印人
                    //Modify by zouchihua 2012-9-29 判断是否打印过
                    //string  ssqltb = "select * from YJ_ZYSQ  where txm in " + sTxm + " and BJLDYBZ=0";//把dyid1记录打印人
                    //DataTable tmtb = FrmMdiMain.Database.GetDataTable(ssqltb);
                    int n = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(ssql, 30);
                    // int n = tmtb.Rows.Count;
                    if (chksqd.Checked == true)
                    {
                        if (n == 0)
                        {
                            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "检验申请单(补打)";
                        }
                        TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.tabJYSQD, Constant.ApplicationDirectory + "\\report\\ZYHS_检验申请单.rpt", parameters, bview);
                        f._sqlStr = new string[] { ssql };
                        if (f.LoadReportSuccess) f.Show(); else f.Dispose();
                    }
                    string bd = "";
                    if (chkbq.Checked == true)
                    {
                        //Modify By tany 2011-04-27
                        if (n == 0)
                        {
                            parameters[0].Value = "补打";
                            bd = "补打";
                        }
                        else
                        {
                            parameters[0].Value = "";
                        }
                        SystemCfg syscfg7188 = new SystemCfg(7188);
                        //Add By tany 2011-05-24 条码打印机的名称
                        string _printerName = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select printername from jc_reportpaper where reportname='ZYHS_检验申请单条码'"), "");// "在 WIND 上自动 Microsoft XPS Document Writer";// 
                        if (bview && int.Parse(_cfg7135.Trim()) > 1)//Modify by zouchihua 如果不是预览并且是打印多份
                        {
                            //add by yaokx 2014-03-14 条码打印
                            if (syscfg7188.Config == "1")
                            {
                                Creating_Barcode.Barcode b = new Creating_Barcode.Barcode();
                                DataTable dt = GetTMTable(int.Parse(_cfg7135.Trim()), Dset.tabJYSQD, bd);
                                if (dt.Rows.Count > 0)
                                {
                                    //b.PrintBarcodeMore(dt, bview, 0);
                                    b.PrintBarcodeMore(dt, bview, tempFile,"");//Modify by Eric 2014-04-15 按照新的打印模板打印
                                }
                            }
                            else
                            {
                                //Modify by zouchihua  2012-9-13 增加参数控制打印份数
                                for (int xx = 0; xx < int.Parse(_cfg7135.Trim()); xx++)
                                {
                                    TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.tabJYSQD, Constant.ApplicationDirectory + "\\report\\ZYHS_检验申请单条码.rpt", parameters, bview, _printerName);
                                    // f._sqlStr=new string[] { ssql };
                                    // if (f.LoadReportSuccess) f.Show(); else f.Dispose();

                                }
                            }
                        }
                        else
                        {
                            //add by yaokx 2014-03-14 条码打印
                            if (syscfg7188.Config == "1")
                            {
                                Creating_Barcode.Barcode b = new Creating_Barcode.Barcode();
                                DataTable dt = GetTMTable(1, Dset.tabJYSQD, bd);
                                if (dt.Rows.Count > 0)
                                {
                                    //b.PrintBarcodeMore(dt, bview, 0);
                                    b.PrintBarcodeMore(dt, bview, tempFile,"");//Modify by Eric 2014-04-15 按照新的打印模板打印
                                }
                            }
                            else
                            {
                                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.tabJYSQD, Constant.ApplicationDirectory + "\\report\\ZYHS_检验申请单条码.rpt", parameters, bview, _printerName);
                                //f._sqlStr = new string[] { ssql };
                                if (f.LoadReportSuccess) f.Show(); else f.Dispose();
                            }
                        }
                    }

                    // InstanceForm.BDatabase.CommitTransaction();
                }
                catch (System.Exception err)
                {
                    //InstanceForm.BDatabase.RollbackTransaction();
                    try
                    {
                        string ssql1 = "update YJ_ZYSQ set BJLDYBZ=0,dysj=null,dyid1=0 where txm in " + sTxm + " and BJLDYBZ=1";//把dyid1记录打印人
                        FrmMdiMain.Database.DoCommand(ssql1);
                    }
                    catch
                    {

                    }
                }
                #endregion
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                if (_txmType == 1)
                {
                    txtTxmInput.Text = "";
                    txtTxmInput.Focus();
                }
            }
        }

        private DataTable GetTMTable(int printnum, DataTable tabJYSQD, string bd)
        {
            if (tabJYSQD.Rows.Count < 1) return new DataTable();

            #region 处理条码相同的情况

            DataTable dtSqd_xmzh = tabJYSQD.Copy();
            if (dtSqd_xmzh.Columns.Contains("条形码[图片]"))
            {
                dtSqd_xmzh.Columns.Remove("条形码[图片]");
            }
            for (int i = dtSqd_xmzh.Rows.Count - 1; i >= 0; i--)
            {
                if (i > dtSqd_xmzh.Rows.Count - 1)
                {
                    i = dtSqd_xmzh.Rows.Count - 1;
                }
                DataRow dr = dtSqd_xmzh.Rows[i];
                string txm = dr["条形码"].ToString();
                DataView dv = new DataView(dtSqd_xmzh, "条形码='" + txm + "'", "", DataViewRowState.CurrentRows);
                if (dv.Count > 1)
                {
                    for (int j = dv.Count - 1; j > 0; j--)
                    {
                        dtSqd_xmzh.Rows.Remove(dv[j].Row);
                    }
                }
            }

            #endregion

            DataTable dt = GetTMTableStruct(dtSqd_xmzh.Rows[0]);
            for (int i = 0; i < dtSqd_xmzh.Rows.Count; i++)
            {
                DataRow drnew = GetTMTableOneRow(dt, printnum, dtSqd_xmzh.Rows[i], bd);
                dt.Rows.Add(drnew);
            }
            return dt;
        }

        private DataRow GetTMTableOneRow(DataTable dt, int printnum, DataRow dr,string bd)
        {
            
            DataRow drr = dt.NewRow();
            drr["barcode"] = dr["条形码"].ToString();
            drr["printnum"] = printnum;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
               string s=dt.Columns[i].ColumnName;
                if (s != "barcode" && s != "printnum")
                {
                    for (int a = 0; a < dr.Table.Columns.Count; a++)
                    {
                        if (dt.Columns[i].ColumnName == dr.Table.Columns[a].ColumnName)
                        {
                            drr[dt.Columns[i].ColumnName] = dr[a].ToString();
                            break;
                        }
                    }
                }
                
            }
            drr["bd"] = bd;
            drr["bq"] = InstanceForm.BCurrentDept.WardName;
            return drr;
        }

        private DataTable GetTMTableStruct(DataRow dr)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("barcode");
            dt.Columns.Add("printnum");
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                 dt.Columns.Add(dr.Table.Columns[i].ColumnName);
            }
            dt.Columns.Add("bd");
            dt.Columns.Add("bq");
            return dt;
        }

        public Bitmap Resize(int newWidth, int newHeight, Image _currentBitmap)
        {
            if (newWidth != 0 && newHeight != 0)
            {
                Bitmap temp = (Bitmap)_currentBitmap;
                Bitmap bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                double nWidthFactor = (double)temp.Width / (double)newWidth;
                double nHeightFactor = (double)temp.Height / (double)newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1 = new Color();
                Color color2 = new Color();
                Color color3 = new Color();
                Color color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (int x = 0; x < bmap.Width; ++x)
                {
                    for (int y = 0; y < bmap.Height; ++y)
                    {

                        fr_x = (int)Math.Floor(x * nWidthFactor);
                        fr_y = (int)Math.Floor(y * nHeightFactor);
                        cx = fr_x + 1;
                        if (cx >= temp.Width) cx = fr_x;
                        cy = fr_y + 1;
                        if (cy >= temp.Height) cy = fr_y;
                        fx = x * nWidthFactor - fr_x;
                        fy = y * nHeightFactor - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        color1 = temp.GetPixel(fr_x, fr_y);
                        color2 = temp.GetPixel(cx, fr_y);
                        color3 = temp.GetPixel(fr_x, cy);
                        color4 = temp.GetPixel(cx, cy);

                        // Blue
                        bp1 = (byte)(nx * color1.B + fx * color2.B);

                        bp2 = (byte)(nx * color3.B + fx * color4.B);

                        nBlue = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Green
                        bp1 = (byte)(nx * color1.G + fx * color2.G);

                        bp2 = (byte)(nx * color3.G + fx * color4.G);

                        nGreen = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Red
                        bp1 = (byte)(nx * color1.R + fx * color2.R);

                        bp2 = (byte)(nx * color3.R + fx * color4.R);

                        nRed = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        bmap.SetPixel(x, y, System.Drawing.Color.FromArgb
                (255, nRed, nGreen, nBlue));
                    }
                }

                return (Bitmap)bmap.Clone();
            }
            return (Bitmap)_currentBitmap;
        }

        private void txtzyh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtzyh.Text = FunBase.returnZyh(txtzyh.Text.Trim());
                this.btnRefresh_Click(sender, e);
            }
        }

        private void txtcwh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                this.btnRefresh_Click(sender, e);
            }
        }

        private void txtzyh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                this.btnRefresh_Click(sender, e);
            }
        }

        private void txttxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                string txm = txttxm.Text.Trim();
                if (Convertor.IsNumeric(txm) == true)
                {
                    decimal tm = Convert.ToDecimal(txm);
                    txttxm.Text = tm.ToString(_txmStr);
                    btnRefresh_Click(sender, e);
                    txttxm.Focus();
                    txttxm.SelectAll();
                }
            }
        }

        private void btnSelAll_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null || myTb.Rows.Count <= 0)
                return;

            DataGridCell myCel = myDataGrid1.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["选"] = true;
            }
            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.CurrentCell = myCel;
        }

        private void btnUnSel_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null || myTb.Rows.Count <= 0)
                return;

            DataGridCell myCel = myDataGrid1.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
            }
            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.CurrentCell = myCel;
        }

        private void rdoydy_CheckedChanged(object sender, EventArgs e)
        {
            btnYdyprint.Visible = true;
            btReDo.Enabled = rdoydy.Checked;

            if (_txmType == 1)
            {
                btnSelAll.Enabled = rdoydy.Checked;
                btnUnSel.Enabled = rdoydy.Checked;
            }
        }

        private void btReDo_Click(object sender, EventArgs e)
        {
            try
            {
                String ssql = "";
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }

                if (rdoydy.Checked)
                {
                    DataRow[] sel = tb.Select("选=true");

                    if (sel.Length == 0)
                    {
                        MessageBox.Show("请选择需要重编的项目！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //汇总当前的分类
                    string[] GroupbyField1 ={ "条形码" };
                    string[] ComputeField1 ={ };
                    string[] CField1 ={ };
                    TrasenFrame.Classes.TsSet tsset1 = new TrasenFrame.Classes.TsSet();
                    tsset1.TsDataTable = tb;
                    DataTable tab = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "选=true");

                    if (tab == null || tab.Rows.Count == 0)
                    {
                        MessageBox.Show("请选择需要重编的项目！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string ts = "";
                    //add by zouchihua  签收的条码不能重编
                    for (int x = 0; x < tb.Rows.Count; x++)
                    {
                        if (tb.Rows[x]["选"].ToString() == "True" && tb.Rows[x]["BQSBZ"].ToString() == "1")
                        {
                            tb.Rows[x]["选"] = "False";
                            ts += tb.Rows[x]["项目内容"].ToString() + "\n";
                        }
                    }
                    if (ts != "")
                    {
                        MessageBox.Show("以下项目已经签收不允许重编：\n" + ts, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }
                    //add by zouchihua  确费的条码不能重编
                    if (cfg7174.Config.Trim() == "0")
                    {
                        for (int x = 0; x < tb.Rows.Count; x++)
                        {
                            if (tb.Rows[x]["选"].ToString() == "True" && tb.Rows[x]["BJSBZ"].ToString() == "1" && decimal.Parse(tb.Rows[x]["je"].ToString().Trim()) != 0)
                            {
                                tb.Rows[x]["选"] = "False";
                                ts += tb.Rows[x]["项目内容"].ToString() + "\n";
                            }
                        }
                        if (ts != "")
                        {
                            MessageBox.Show("以下项目已经费用确认不允许重编：\n" + ts, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                        if (MessageBox.Show("确定要重编条码吗？\r\n\r\n注意：重编条码后不能返回原来的状态，请谨慎操作！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            return;
                        }

                        string sTxm = " (";
                        for (int III = 0; III <= tab.Rows.Count - 1; III++)
                        {
                            sTxm += "'" + tab.Rows[III]["条形码"].ToString() + "'";
                            if (III < tab.Rows.Count - 1)
                            {
                                sTxm += ",";
                            }
                            else
                            {
                                sTxm += ") ";
                            }
                        }


                        ssql = "update YJ_ZYSQ set txm=null,BJLDYBZ=0,dysj=null,dyid1=0 where txm in " + sTxm + " and BJLDYBZ=1";
                    //Modify by zouchihua 2013-7-17 重编条形码时
                    //string sTxm = " (";
                    //for (int III = 0; III <= tb.Rows.Count - 1; III++)
                    //{
                    //    if (tb.Rows[III]["选"].ToString() == "True")
                    //    {
                    //        sTxm += "'" + tb.Rows[III]["YJSQID"].ToString() + "'";
                    //        if (III < tab.Rows.Count - 1)//YJSQID
                    //        {
                    //            sTxm += ",";
                    //        }
                    //        else
                    //        {
                    //            sTxm += ") ";
                    //        }
                    //    }
                    //}
                    //ssql = "update YJ_ZYSQ set txm=null,BJLDYBZ=0,dysj=null,dyid1=0 where YJSQID in " + sTxm + " and BJLDYBZ=1";
                    FrmMdiMain.Database.DoCommand(ssql, 30);

                    for (int i = 0; i <= sel.Length - 1; i++)
                    {
                        tb.Rows.Remove(sel[i]);
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtTxmInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPrint_Click(null, null);
            }
        }

        private void rdowdy_CheckedChanged(object sender, EventArgs e)
        {
            btnYdyprint.Visible = false;
        }

        private void btnYdyprint_Click(object sender, EventArgs e)
        {
            DataTable patTb = (DataTable)myDataGrid1.DataSource;
            //汇总当前的分类
            string[] GroupbyField ={ "inpatient_id", "baby_id", "条形码" };
            string[] ComputeField ={ };
            string[] CField ={ };
            TrasenFrame.Classes.TsSet tsset = new TrasenFrame.Classes.TsSet();
            tsset.TsDataTable = patTb;
            DataTable tab = tsset.GroupTable(GroupbyField, ComputeField, CField, "选=true"); 
            DataSet1 ds=new DataSet1();
            if(tab.Rows.Count==0)
                return;
            int xh = 1;
            int count = chekje.Checked ? patTb.Rows.Count : tab.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataRow[] rownew=null;
                //if (tab.Rows[i]["选"].ToString().Trim() == "True")
                {
                    if (!chekje.Checked)
                     rownew = patTb.Select("id=" + tab.Rows[i]["id"].ToString().Trim());
                     if(chekje.Checked)
                     {
                         rownew = new DataRow[1];
                         rownew[0] = patTb.Rows[i];
                     }
                    
                    DataRow myrow = ds.ydy.NewRow();
                    myrow["条码号"] = rownew[0]["条形码"].ToString().Trim();
                    myrow["住院号"] = rownew[0]["住院号"].ToString();
                    myrow["姓名"] = rownew[0]["姓名"].ToString();
                    myrow["床号"] = rownew[0]["床号"].ToString();
                    myrow["bz1"] = rownew[0]["打印时间"].ToString();
                   myrow["bz2"] = InstanceForm.BCurrentDept.WardName;
                  
                   myrow["送标本人"] = "";
                   myrow["接收标本人签字"] = "";
                   
                   decimal hj = 0;
                   if (!chekje.Checked)
                   {
                       DataRow[] nrrow = patTb.Select("选=true and inpatient_id='" + tab.Rows[i]["inpatient_id"].ToString() + "' and baby_id=" + tab.Rows[i]["baby_id"].ToString() + " and 条形码=" + tab.Rows[i]["条形码"].ToString());
                       for (int x = 0; x < nrrow.Length; x++)
                       {
                           myrow["项目名称"] = myrow["项目名称"].ToString() + nrrow[x]["项目内容"].ToString() + (nrrow[x]["附加说明"].ToString().Trim() == "" ? "" : (" [" + nrrow[x]["附加说明"].ToString() + "]"))
                             + (chekje.Checked ? (" (" + nrrow[x]["金额"].ToString() + " 元)") : "")
                             + "\r\n";
                           hj += decimal.Parse(nrrow[x]["金额"].ToString());
                       }
                   }
                   else
                   {
                       myrow["项目名称"] = rownew[0]["项目内容"].ToString();
                       hj = decimal.Parse(rownew[0]["金额"].ToString());
                   }
                   for (int j = 3; j <= 10; j++)
                   {
                       myrow["bz" +j.ToString()] = ""; 
                   }
                   myrow["bz3"] = xh.ToString();
                   //add by zouchihua 2013-9-26
                  // myrow["bz4"] = rownew[0]["金额"].ToString();
                   myrow["bz4"] = rownew[0]["标本类型"].ToString();
                   myrow["bz5"] = hj.ToString();
                   myrow["bz6"] = rownew[0]["简称"].ToString();
                   xh++;
                   ds.ydy.Rows.Add(myrow);
                }
            }
            bool bview = this.checkBox1.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(ds.ydy, Constant.ApplicationDirectory + "\\report\\zyhs_已打印条码.rpt", null, bview);
            if (f.LoadReportSuccess) f.Show(); else f.Dispose();
        }

        /// <summary>
        /// 打开条码设计器 Add by Eric 2014-04-15
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            TrasenCommon.OperateXML.CompatibilityXMLFile(xmlFile1, xmlFile, tempFile);

            ts_BarCodeDesigner.FrmMain main = new ts_BarCodeDesigner.FrmMain(tempFile, xmlFile);
            main.Show();
        }

        int currentRow = 0;
        int lastRow = -1;

        /// <summary>
        /// 单元格改变事件 Add by Eric 2014-04-15
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.myDataGrid1.DataSource;
            //当前行号
            currentRow = this.myDataGrid1.CurrentCell.RowNumber;
            try
            {
                if (lastRow != -1)
                {
                    if (!string.IsNullOrEmpty(this.myDataGrid1[lastRow, 22].ToString()))
                    {
                        if (FrmMdiMain.Database.GetDataResult(string.Format("select BQSBZ from YJ_ZYSQ where YJSQID ='{0}'"
                       , dt.Rows[lastRow]["YJSQID"].ToString())).ToString() == "0")//判断标本签收状态
                        {
                            DateTime time = DateTime.Parse(this.myDataGrid1[lastRow, 22].ToString());

                            string sql = string.Format("update YJ_ZYSQ set BBCJSJ='{0}' where YJSQID='{1}'",
                            this.myDataGrid1[lastRow, 22].ToString(),
                            dt.Rows[lastRow]["YJSQID"].ToString());

                            FrmMdiMain.Database.DoCommand(sql, 30);
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.myDataGrid1[currentRow, 22].ToString()))
                    {
                        if (FrmMdiMain.Database.GetDataResult(string.Format("select BQSBZ from YJ_ZYSQ where YJSQID ='{0}'"
                      , dt.Rows[currentRow]["YJSQID"].ToString())).ToString() == "0")//判断标本签收状态
                        {
                            DateTime time = DateTime.Parse(this.myDataGrid1[currentRow, 22].ToString());

                            string sql = string.Format("update YJ_ZYSQ set BBCJSJ='{0}' where YJSQID='{1}'",
                            this.myDataGrid1[currentRow, 22].ToString(),
                            dt.Rows[currentRow]["YJSQID"].ToString());

                            FrmMdiMain.Database.DoCommand(sql, 30);
                        }
                    }
                }

                lastRow = this.myDataGrid1.CurrentCell.RowNumber;
            }
            catch { }
        }

        /// <summary>
        /// 监听全局键盘回车事件，按回车会在标本采集时间添加当前时间 Add by Eric 2014-04-15
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter && this.myDataGrid1.CurrentCell.ColumnNumber == 22 && this.myDataGrid1.DataSource != null)
            {
                this.myDataGrid1[this.myDataGrid1.CurrentCell.RowNumber, 22] = DateTime.Now.ToString();

                DataTable dt = (DataTable)this.myDataGrid1.DataSource;
                if (!string.IsNullOrEmpty(this.myDataGrid1[this.myDataGrid1.CurrentCell.RowNumber, 22].ToString()))
                {
                    if (FrmMdiMain.Database.GetDataResult(string.Format("select BQSBZ from YJ_ZYSQ where YJSQID ='{0}'"
                        , dt.Rows[this.myDataGrid1.CurrentCell.RowNumber]["YJSQID"].ToString())).ToString() == "0")//判断标本签收状态
                    {
                        string sql = string.Format("update YJ_ZYSQ set BBCJSJ='{0}' where YJSQID='{1}'",
                            this.myDataGrid1[this.myDataGrid1.CurrentCell.RowNumber, 22].ToString(),
                            dt.Rows[this.myDataGrid1.CurrentCell.RowNumber]["YJSQID"].ToString());

                        FrmMdiMain.Database.DoCommand(sql, 30);
                    }
                }
                lastRow = this.myDataGrid1.CurrentCell.RowNumber;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
