using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using TrasenClasses.DatabaseAccess;
using ts_mz_class;

namespace ts_yf_mzpy
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmmzpy : System.Windows.Forms.Form
	{
		private long _employeeID;
		private long _deptID;
		public  string _Pyckh;
        private string _functionName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtprint;
		private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butbegin;
		private myDataGrid.myDataGrid myDataGrid1;
		private myDataGrid.myDataGrid myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
		private System.Windows.Forms.ComboBox cmbpyr;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.Button butquit;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtfph;
		private System.Windows.Forms.RadioButton rdozd;
        private System.Windows.Forms.RadioButton rdosd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butok;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn46;
        private string IPAddRess;
        private TextBox txtmzh;
        private Label label9;
        private TextBox txtkh;
        private Label label11;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private Button butref;
        private YpConfig s;
        private DataGridTableStyle dataGridTableStyle1;
        private Button butqhpyck;
        private RadioButton rdoyck;
        private RadioButton rdowck;
        private CheckBox chkprint;
        private CheckBox chkview;
        private ComboBox cmbklx;
        private GroupBox groupBox2;
        private Panel panel7;
        private ComboBox cmbfyr;
        private Label label5;
        private Splitter splitter2;
        private GroupBox groupBox1;
        private Panel panel5;
        private GroupBox groupBox3;
        private Panel panel1;
        private DateTimePicker dtp2;
        private DateTimePicker dtp1;
        private Label label7;
        private Panel panel2;
        private Label lblerr;
        private Button butcx;
        private Panel panel3;
        private CheckBox chkpyrq;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem mnuqxpy;
        private Timer timer1;
        private CheckBox chkqd;
        private CheckBox chkcf;
        private CheckBox chkzsd;
        private DataGridTextBoxColumn dataGridTextBoxColumn3;
        private Panel panel4;
        private DateTimePicker dtpcfrq;
        private TextBox _textBox;

        public Frmmzpy(MenuTag menuTag, string chineseName, Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
          
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
			//网卡地址
            IPAddRess = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
			//配药窗口号 ???
			//_Pyckh=MZYF_PY.SeekPychk(IPAddRess);
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{


			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.butok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfph = new System.Windows.Forms.TextBox();
            this.rdosd = new System.Windows.Forms.RadioButton();
            this.butquit = new System.Windows.Forms.Button();
            this.cmbpyr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butprint = new System.Windows.Forms.Button();
            this.butbegin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtprint = new System.Windows.Forms.TextBox();
            this.rdozd = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn46 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuqxpy = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.butqhpyck = new System.Windows.Forms.Button();
            this.txtkh = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtmzh = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rdowck = new System.Windows.Forms.RadioButton();
            this.rdoyck = new System.Windows.Forms.RadioButton();
            this.butref = new System.Windows.Forms.Button();
            this.chkview = new System.Windows.Forms.CheckBox();
            this.chkprint = new System.Windows.Forms.CheckBox();
            this.cmbklx = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkqd = new System.Windows.Forms.CheckBox();
            this.chkcf = new System.Windows.Forms.CheckBox();
            this.chkzsd = new System.Windows.Forms.CheckBox();
            this.cmbfyr = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpcfrq = new System.Windows.Forms.DateTimePicker();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butcx = new System.Windows.Forms.Button();
            this.lblerr = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.chkpyrq = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butok
            // 
            this.butok.Location = new System.Drawing.Point(525, 53);
            this.butok.Name = "butok";
            this.butok.Size = new System.Drawing.Size(84, 25);
            this.butok.TabIndex = 26;
            this.butok.Text = "配药确认";
            this.butok.Click += new System.EventHandler(this.butok_Click);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(128, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "每";
            // 
            // txtfph
            // 
            this.txtfph.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfph.Location = new System.Drawing.Point(286, 28);
            this.txtfph.Name = "txtfph";
            this.txtfph.Size = new System.Drawing.Size(149, 23);
            this.txtfph.TabIndex = 18;
            this.txtfph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmzh_KeyPress);
            // 
            // rdosd
            // 
            this.rdosd.ForeColor = System.Drawing.Color.Black;
            this.rdosd.Location = new System.Drawing.Point(19, 46);
            this.rdosd.Name = "rdosd";
            this.rdosd.Size = new System.Drawing.Size(104, 24);
            this.rdosd.TabIndex = 17;
            this.rdosd.Text = "手动模式  ";
            this.rdosd.CheckedChanged += new System.EventHandler(this.rdozd_CheckedChanged);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(700, 42);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(79, 30);
            this.butquit.TabIndex = 16;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // cmbpyr
            // 
            this.cmbpyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbpyr.Location = new System.Drawing.Point(318, 16);
            this.cmbpyr.Name = "cmbpyr";
            this.cmbpyr.Size = new System.Drawing.Size(96, 22);
            this.cmbpyr.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(269, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "配药人";
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(700, 11);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(79, 30);
            this.butprint.TabIndex = 13;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butbegin
            // 
            this.butbegin.Location = new System.Drawing.Point(627, 17);
            this.butbegin.Name = "butbegin";
            this.butbegin.Size = new System.Drawing.Size(65, 49);
            this.butbegin.TabIndex = 12;
            this.butbegin.Text = "开始";
            this.butbegin.Click += new System.EventHandler(this.butbegin_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(174, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "秒打印一张处方";
            // 
            // txtprint
            // 
            this.txtprint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtprint.ForeColor = System.Drawing.Color.Red;
            this.txtprint.Location = new System.Drawing.Point(146, 18);
            this.txtprint.Name = "txtprint";
            this.txtprint.Size = new System.Drawing.Size(29, 21);
            this.txtprint.TabIndex = 10;
            this.txtprint.Text = "30";
            // 
            // rdozd
            // 
            this.rdozd.Checked = true;
            this.rdozd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdozd.ForeColor = System.Drawing.Color.Black;
            this.rdozd.Location = new System.Drawing.Point(19, 17);
            this.rdozd.Name = "rdozd";
            this.rdozd.Size = new System.Drawing.Size(112, 24);
            this.rdozd.TabIndex = 4;
            this.rdozd.TabStop = true;
            this.rdozd.Text = "自动配药模式 ";
            this.rdozd.CheckedChanged += new System.EventHandler(this.rdozd_CheckedChanged);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(238, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "发票号";
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 78);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(260, 377);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.AllowSorting = false;
            this.dataGridTableStyle3.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn46,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn36,
            this.dataGridTextBoxColumn3});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.RowHeadersVisible = false;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "发票号";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 60;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "金额";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 60;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "姓名";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // dataGridTextBoxColumn46
            // 
            this.dataGridTextBoxColumn46.Format = "";
            this.dataGridTextBoxColumn46.FormatInfo = null;
            this.dataGridTextBoxColumn46.HeaderText = "门诊号";
            this.dataGridTextBoxColumn46.NullText = "";
            this.dataGridTextBoxColumn46.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "发药窗口";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 80;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "FPID";
            this.dataGridTextBoxColumn36.NullText = "";
            this.dataGridTextBoxColumn36.ReadOnly = true;
            this.dataGridTextBoxColumn36.Width = 0;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "发票流水号";
            this.dataGridTextBoxColumn3.Width = 90;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.ContextMenuStrip = this.contextMenuStrip1;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.Size = new System.Drawing.Size(619, 351);
            this.myDataGrid2.TabIndex = 0;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuqxpy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mnuqxpy
            // 
            this.mnuqxpy.Name = "mnuqxpy";
            this.mnuqxpy.Size = new System.Drawing.Size(118, 22);
            this.mnuqxpy.Text = "取消配药";
            this.mnuqxpy.Click += new System.EventHandler(this.mnuqxpy_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // butqhpyck
            // 
            this.butqhpyck.Location = new System.Drawing.Point(466, 20);
            this.butqhpyck.Name = "butqhpyck";
            this.butqhpyck.Size = new System.Drawing.Size(143, 25);
            this.butqhpyck.TabIndex = 29;
            this.butqhpyck.Text = "切换配药窗口";
            this.butqhpyck.Click += new System.EventHandler(this.butqhpyck_Click);
            // 
            // txtkh
            // 
            this.txtkh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtkh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtkh.Location = new System.Drawing.Point(157, 3);
            this.txtkh.Name = "txtkh";
            this.txtkh.Size = new System.Drawing.Size(124, 23);
            this.txtkh.TabIndex = 24;
            this.txtkh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmzh_KeyPress);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(6, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "卡类型/卡号";
            // 
            // txtmzh
            // 
            this.txtmzh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmzh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtmzh.Location = new System.Drawing.Point(89, 28);
            this.txtmzh.Name = "txtmzh";
            this.txtmzh.Size = new System.Drawing.Size(147, 23);
            this.txtmzh.TabIndex = 22;
            this.txtmzh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmzh_KeyPress);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(41, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "门诊号";
            // 
            // rdowck
            // 
            this.rdowck.BackColor = System.Drawing.SystemColors.Control;
            this.rdowck.Enabled = false;
            this.rdowck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdowck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdowck.ForeColor = System.Drawing.Color.Black;
            this.rdowck.Location = new System.Drawing.Point(133, 35);
            this.rdowck.Name = "rdowck";
            this.rdowck.Size = new System.Drawing.Size(109, 21);
            this.rdowck.TabIndex = 6;
            this.rdowck.Text = "无窗口处方 ";
            this.rdowck.UseVisualStyleBackColor = false;
            // 
            // rdoyck
            // 
            this.rdoyck.BackColor = System.Drawing.SystemColors.Control;
            this.rdoyck.Checked = true;
            this.rdoyck.Enabled = false;
            this.rdoyck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoyck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoyck.ForeColor = System.Drawing.Color.Black;
            this.rdoyck.Location = new System.Drawing.Point(6, 35);
            this.rdoyck.Name = "rdoyck";
            this.rdoyck.Size = new System.Drawing.Size(120, 21);
            this.rdoyck.TabIndex = 5;
            this.rdoyck.TabStop = true;
            this.rdoyck.Text = "对应窗口处方 ";
            this.rdoyck.UseVisualStyleBackColor = false;
            this.rdoyck.CheckedChanged += new System.EventHandler(this.rdoyck_CheckedChanged);
            // 
            // butref
            // 
            this.butref.Dock = System.Windows.Forms.DockStyle.Right;
            this.butref.Enabled = false;
            this.butref.Location = new System.Drawing.Point(143, 0);
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size(117, 31);
            this.butref.TabIndex = 1;
            this.butref.Text = "刷新数据";
            this.butref.UseVisualStyleBackColor = true;
            this.butref.Click += new System.EventHandler(this.butref_Click);
            // 
            // chkview
            // 
            this.chkview.AutoSize = true;
            this.chkview.Location = new System.Drawing.Point(791, 21);
            this.chkview.Name = "chkview";
            this.chkview.Size = new System.Drawing.Size(82, 18);
            this.chkview.TabIndex = 23;
            this.chkview.Text = "打印预览";
            this.chkview.UseVisualStyleBackColor = true;
            // 
            // chkprint
            // 
            this.chkprint.AutoSize = true;
            this.chkprint.Checked = true;
            this.chkprint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkprint.Location = new System.Drawing.Point(791, 49);
            this.chkprint.Name = "chkprint";
            this.chkprint.Size = new System.Drawing.Size(96, 18);
            this.chkprint.TabIndex = 22;
            this.chkprint.Text = "配药时打印";
            this.chkprint.UseVisualStyleBackColor = true;
            // 
            // cmbklx
            // 
            this.cmbklx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbklx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbklx.Location = new System.Drawing.Point(90, 4);
            this.cmbklx.Name = "cmbklx";
            this.cmbklx.Size = new System.Drawing.Size(66, 22);
            this.cmbklx.TabIndex = 41;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(896, 5);
            this.panel7.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.cmbfyr);
            this.groupBox2.Controls.Add(this.chkview);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.chkprint);
            this.groupBox2.Controls.Add(this.rdozd);
            this.groupBox2.Controls.Add(this.butquit);
            this.groupBox2.Controls.Add(this.txtprint);
            this.groupBox2.Controls.Add(this.butbegin);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.butprint);
            this.groupBox2.Controls.Add(this.rdosd);
            this.groupBox2.Controls.Add(this.cmbpyr);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 78);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配药选项";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chkqd);
            this.panel3.Controls.Add(this.chkcf);
            this.panel3.Controls.Add(this.chkzsd);
            this.panel3.Location = new System.Drawing.Point(419, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 56);
            this.panel3.TabIndex = 28;
            // 
            // chkqd
            // 
            this.chkqd.AutoSize = true;
            this.chkqd.Location = new System.Drawing.Point(6, 6);
            this.chkqd.Name = "chkqd";
            this.chkqd.Size = new System.Drawing.Size(82, 18);
            this.chkqd.TabIndex = 31;
            this.chkqd.Text = "门诊清单";
            this.chkqd.UseVisualStyleBackColor = true;
            // 
            // chkcf
            // 
            this.chkcf.AutoSize = true;
            this.chkcf.Location = new System.Drawing.Point(94, 6);
            this.chkcf.Name = "chkcf";
            this.chkcf.Size = new System.Drawing.Size(82, 18);
            this.chkcf.TabIndex = 30;
            this.chkcf.Text = "门诊处方";
            this.chkcf.UseVisualStyleBackColor = true;
            // 
            // chkzsd
            // 
            this.chkzsd.AutoSize = true;
            this.chkzsd.Location = new System.Drawing.Point(6, 29);
            this.chkzsd.Name = "chkzsd";
            this.chkzsd.Size = new System.Drawing.Size(96, 18);
            this.chkzsd.TabIndex = 29;
            this.chkzsd.Text = "门诊注射单";
            this.chkzsd.UseVisualStyleBackColor = true;
            // 
            // cmbfyr
            // 
            this.cmbfyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfyr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbfyr.Location = new System.Drawing.Point(317, 44);
            this.cmbfyr.Name = "cmbfyr";
            this.cmbfyr.Size = new System.Drawing.Size(96, 22);
            this.cmbfyr.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(268, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "发药人";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myDataGrid1);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 458);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "处方信息";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.rdowck);
            this.panel5.Controls.Add(this.rdoyck);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 59);
            this.panel5.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtpcfrq);
            this.panel4.Controls.Add(this.butref);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 31);
            this.panel4.TabIndex = 7;
            // 
            // dtpcfrq
            // 
            this.dtpcfrq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpcfrq.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpcfrq.Location = new System.Drawing.Point(0, 0);
            this.dtpcfrq.Name = "dtpcfrq";
            this.dtpcfrq.Size = new System.Drawing.Size(143, 26);
            this.dtpcfrq.TabIndex = 2;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(266, 83);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 458);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(271, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(625, 458);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "处方明细";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(619, 351);
            this.panel2.TabIndex = 43;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butcx);
            this.panel1.Controls.Add(this.lblerr);
            this.panel1.Controls.Add(this.dtp2);
            this.panel1.Controls.Add(this.dtp1);
            this.panel1.Controls.Add(this.butok);
            this.panel1.Controls.Add(this.txtfph);
            this.panel1.Controls.Add(this.butqhpyck);
            this.panel1.Controls.Add(this.cmbklx);
            this.panel1.Controls.Add(this.txtmzh);
            this.panel1.Controls.Add(this.txtkh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.chkpyrq);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 85);
            this.panel1.TabIndex = 42;
            // 
            // butcx
            // 
            this.butcx.Location = new System.Drawing.Point(464, 53);
            this.butcx.Name = "butcx";
            this.butcx.Size = new System.Drawing.Size(53, 25);
            this.butcx.TabIndex = 118;
            this.butcx.Text = "查找";
            this.butcx.Click += new System.EventHandler(this.butcx_Click);
            // 
            // lblerr
            // 
            this.lblerr.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblerr.ForeColor = System.Drawing.Color.Red;
            this.lblerr.Location = new System.Drawing.Point(298, 0);
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(277, 17);
            this.lblerr.TabIndex = 28;
            this.lblerr.Text = "错误提示";
            this.lblerr.Visible = false;
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(275, 54);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(161, 23);
            this.dtp2.TabIndex = 115;
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(91, 54);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(163, 23);
            this.dtp1.TabIndex = 114;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(256, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 17);
            this.label7.TabIndex = 117;
            this.label7.Text = "到";
            // 
            // chkpyrq
            // 
            this.chkpyrq.AutoSize = true;
            this.chkpyrq.Location = new System.Drawing.Point(12, 57);
            this.chkpyrq.Name = "chkpyrq";
            this.chkpyrq.Size = new System.Drawing.Size(82, 18);
            this.chkpyrq.TabIndex = 119;
            this.chkpyrq.Text = "配药日期";
            this.chkpyrq.UseVisualStyleBackColor = true;
            this.chkpyrq.CheckedChanged += new System.EventHandler(this.chkpyrq_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frmmzpy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(896, 541);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel7);
            this.Name = "Frmmzpy";
            this.Text = "门诊配药";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmmzpy_Load);
            this.Closed += new System.EventHandler(this.Frmmzpy_Closed);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frmmzpy_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>

		private void Frmmzpy_Load(object sender, System.EventArgs e)
		{
			try
			{
                FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "myTb");

                //string[] HeaderText ={ "序号", "发药", "皮试", "发票号", "项目", "总金额", "姓名", "剂型", "商品名", "品名", "用量", "单位", "规格", "厂家", "单价", "库存", "剂数", "金额", "门诊号", "性别", "年龄", "诊断", "科室", "医生", "煎药", "用法", "频次", "剂量", "剂量单位", "天数", "录入日期", "录入员", "收费日期", "记费员", "发药日期", "发药员", "配药员", "处方号", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "配药窗口", "发药窗口", "记帐金额", "优惠金额", "自付金额", "YPID", "YDWBL", "cfmxid", "嘱托", "批发价", "批发金额", "使用频次", "货号" };
                //string[] MappingName ={ "序号", "发药", "皮试", "发票号", "项目", "总金额", "姓名", "剂型", "商品名", "品名", "用量", "单位", "规格", "厂家", "单价", "库存", "剂数", "金额", "门诊号", "性别", "年龄", "诊断", "科室", "医生", "煎药", "用法", "频次", "剂量", "剂量单位", "天数", "录入日期", "录入员", "收费日期", "记费员", "发药日期", "发药员", "配药员", "处方号", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "配药窗口", "发药窗口", "记帐金额", "优惠金额", "自付金额", "YPID", "YDWBL", "cfmxid", "嘱托", "批发价", "批发金额", "使用频次", "货号" };
                //int[] ColWidth ={ 35, 0, 30, 60, 0, 0, 60, 0, 100, 100, 45/*ypsl*/, 35, 80, 70, 55, 0, 40, 65, 0, 0, 0, 0, 0, 50, 0, 0/*userage*/, 0, 0, 0, 0, 0, 0, 90/*发费日期*/, 0, 90, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90 };
                //bool[] BoolCol ={ false , false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

                string[] HeaderText ={ "序号", "发药", "皮试", "发票号", "项目", "总金额", "姓名", "剂型", "商品名", "品名", "用量", "单位", "规格", "厂家", "单价", "库存", "剂数", "金额", "门诊号", "性别", "年龄", "诊断", "科室", "医生", "煎药", "用法", "频次", "剂量", "剂量单位", "天数", "组标志", "排序序号", "录入日期", "录入员", "收费日期", "记费员", "发药日期", "发药员", "配药员", "处方号", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "配药窗口", "发药窗口", "记帐金额", "优惠金额", "自付金额", "YPID", "YDWBL", "cfmxid", "嘱托", "批发价", "批发金额", "使用频次", "货号", "单位规格", "zsyp", "fpid", "发票流水号", "中药备注", "备注2", "备注3","hwmc" };
                string[] MappingName ={ "序号", "发药", "皮试", "发票号", "项目", "总金额", "姓名", "剂型", "商品名", "品名", "用量", "单位", "规格", "厂家", "单价", "库存", "剂数", "金额", "门诊号", "性别", "年龄", "诊断", "科室", "医生", "煎药", "用法", "频次", "剂量", "剂量单位", "天数", "组标志", "排序序号", "录入日期", "录入员", "收费日期", "记费员", "发药日期", "发药员", "配药员", "处方号", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "配药窗口", "发药窗口", "记帐金额", "优惠金额", "自付金额", "YPID", "YDWBL", "cfmxid", "嘱托", "批发价", "批发金额", "使用频次", "货号", "单位规格", "zsyp", "fpid", "发票流水号", "中药备注", "备注2", "备注3","hwmc" };
                int[] ColWidth ={ 40, 30, 30, 60, 0, 0, 60, 0, 110, 110, 50/*ypsl*/, 40, 90, 90, 60, 0, 40, 65, 70, 40, 40, 70, 0, 50, 0, 0/*userage*/, 0, 0, 0, 0, 0, 0, 90, 60, 90/*发费日期*/, 60, 90, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 80, 0, 90, 150, 50, 50,0 };
                bool[] ColReadOnly ={ true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true,true };
                bool[] ColBool ={ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,false };


                FunBase.csMydataGrid(this.myDataGrid2, HeaderText, MappingName, ColBool, ColWidth, false);
                FunBase.CsDataGrid(this.myDataGrid2, this.myDataGrid2.TableStyles[0], "Tb");

				//添加配药人 ???
                Yp.AddcmbPyr(InstanceForm.BCurrentDept.DeptId, this.cmbpyr, InstanceForm.BDatabase);
                Yp.AddcmbPyr(InstanceForm.BCurrentDept.DeptId, this.cmbfyr, InstanceForm.BDatabase);

                FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
                
                cmbpyr.Text = InstanceForm.BCurrentUser.Name.Trim();

                //string cfgs = new SystemCfg(8010).Config;
                //if (cfgs == "1") rdocfgs.Checked = true; 
                //if (cfgs == "0") rdoqdgs.Checked = true;
                //if (cfgs == "2") rdoall.Checked = true;

                s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

                if (s.门诊配药时打印处方 == true) chkcf.Checked = true;
                if (s.门诊配药时打印清单 == true) chkqd.Checked = true;
                if (s.门诊配药时打印注射单 == true) chkzsd.Checked = true;

                if (s.网络内容显示商品名 == false)
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["商品名"].Width = 0;
                butqhpyck.Text = butqhpyck.Text + "(" + _Pyckh.Trim() + "窗)";
				//更新当前窗口的使用状态 ???
				//MZYF_PY.UpateCkSybz(IPAddRess,1);

                chkpyrq.Checked = true;
                chkpyrq.Checked = false;

                this.dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
                this.dtp2.Value =Convert.ToDateTime( DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString()+" 23:59:59");

                FunBase.myGridSelect(myDataGrid2, this.myDataGrid2.TableStyles[0].GridColumnStyles);

                txtprint.Text = new SystemCfg(8016).Config;

                //自动读射频卡
                string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
                if (ReadCard != null)
                    ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}

       
		private void butbegin_Click(object sender, System.EventArgs e)
		{

            
			if (s.配药模式==true && _Pyckh.Trim()==""){MessageBox.Show("配药窗口号没有维护，请先维护这个窗口");return;}

			if (cmbpyr.Text.Trim()=="")
			{
				MessageBox.Show("请选择配药人");
				return;
			}

			if (Convertor.IsNumeric(txtprint.Text)==false && this.rdozd.Checked==true)
			{
				MessageBox.Show("请输入多少秒钟打印一张处方");
				return;
			}

			if (this.rdozd.Checked==true)
			{
                if (Convert.ToInt32(txtprint.Text) > 60)
                {
                    MessageBox.Show("对不起，处方配药间隔最大应在 60 秒或60秒以下");
                    return;
                }
				if (Convert.ToInt32(txtprint.Text)<=4)
				{
					MessageBox.Show("对不起，处方配药间隔最少应在 4 秒以上");
					return;
				}
			}



            lblerr.Visible = false;
			butbegin.Text=this.butbegin.Text.Trim()=="开始"?"停止":"开始";

            try
            {
                if (this.butbegin.Text.Trim() == "停止")
                {
                    //
                    //lblbz.Text = "正在运行...";
                    //先打印一张
                    DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;
                    if (tb1.Rows.Count == 0 && rdozd.Checked == true) this.butref_Click(sender, e);
                   

                    this.rdozd.Enabled = false;
                    this.rdosd.Enabled = false;

                    //this.timer1.Interval=Convert.ToInt32(txtsd.Text)*1000;
                    this.timer2.Interval = Convert.ToInt32(txtprint.Text) * 1000;

                    this.timer1.Enabled = this.rdosd.Checked == true ? true : false; //提取数据时钟开始生效
                    this.timer2.Enabled = this.rdozd.Checked == true ? true : false;

                    timer2_Tick(sender, e);

                    txtfph.Enabled = this.timer2.Enabled == true ? false : true;
                    txtmzh.Enabled = this.timer2.Enabled == true ? false : true;
                    txtkh.Enabled = this.timer2.Enabled == true ? false : true;
                    //txtghxh.Enabled = this.timer2.Enabled == true ? false : true;

                    if (rdosd.Checked == true)
                    {
                        this.butref_Click(sender, e);
                    }
                }
                else
                {
                    //lblbz.Text = "已停止";
                    lblerr.Visible = false;
                    this.rdozd.Enabled = true;
                    this.rdosd.Enabled = true;

                    this.timer1.Enabled = false; //提取数据时钟开始失效
                    this.timer2.Enabled = false;
                    txtfph.Enabled = this.timer2.Enabled == true ? false : true;
                    txtmzh.Enabled = this.timer2.Enabled == true ? false : true;
                    txtkh.Enabled = this.timer2.Enabled == true ? false : true;
                    //txtghxh.Enabled = this.timer2.Enabled == true ? false : true;
                }
            }
            catch (System.Exception err)
            {
                lblerr.Visible = true;
                lblerr.Text = err.Message.Trim();
                this.timer1.Enabled = false; //提取数据时钟开始失效
                this.timer2.Enabled = false;
            }
		}


		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb1=(DataTable) myDataGrid1.DataSource;
				int nrow= myDataGrid1.CurrentCell.RowNumber ;
				if (nrow>tb1.Rows.Count-1) return;
				string  fph=Convertor.IsNull(tb1.Rows[nrow]["发票号"],"0");
    
				Guid fpid=new Guid(Convertor.IsNull(tb1.Rows[nrow]["fpid"],Guid.Empty.ToString()));
                
                DataTable tbmx = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, Guid.Empty, "",
                 "", 0,
                "", "", 0, -1, "", "", "", 0, "", "", 0, 0, "", "", "", 0, 0,fpid,Guid.Empty, 0, InstanceForm.BDatabase);
                tbmx.TableName = "Tb";
                FunBase.AddRowtNo(tbmx); 
                AddPresc(tbmx);
                //this.myDataGrid2.DataSource = tbmx;

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}


	
		//手动、自动配药确认
		private void timer2_Tick(object sender, System.EventArgs e)
        {
              #region 作废
            //try
            //{

            //    if (s.配药模式 == true && _Pyckh.Trim() == "") { lblerr.Visible = true; lblerr.Text = "配药窗口号没有维护，请先维护这个窗口"; return; }

            //    timer2.Enabled = false;    

            //    Guid  _xh = Guid.Empty;
            //    long _fph = 0;
            //    string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            //    DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;

            //    //DataTable tbmx;
            //    //自动配药模式下才需要重新找处方
            //    if (rdozd.Checked == true)
            //    {
            //        if (tb1.Rows.Count == 0) { this.butref_Click(sender, e); tb1 = (DataTable)this.myDataGrid1.DataSource; }
            //        if (tb1.Rows.Count != 0)
            //        {
            //            DataTable tbmx = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, Guid.Empty, "",
            //                     Convert.ToInt64(tb1.Rows[0]["发票号"]), 0,
            //                    "", "", 0, 0, "", "", "", 0, "", "", 0, 0, "", "", "", 0, 0, 0, InstanceForm.BDatabase);
            //            AddPresc(tbmx);
            //        }
            //    }


            //    DataTable tb2 = (DataTable)this.myDataGrid2.DataSource;

            //    if (this.rdosd.Checked == true)
            //    {
            //        if (tb2.Rows.Count == 0)
            //        {
            //            MessageBox.Show("没有选择配药记录,请确认", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //    }

            //    //按发票号等分组明细
            //    DataRow[] selrow = tb2.Select(" cfxh<>''");
            //    DataTable tbsel = tb2.Clone();
            //    for (int w = 0; w <= selrow.Length - 1; w++)
            //        tbsel.ImportRow(selrow[w]);

            //    string[] GroupbyField ={ "cfxh", "发票号" };
            //    string[] ComputeField ={ };
            //    string[] CField ={ };
            //    DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
            //    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            //    {
            //        _xh = new Guid(Convertor.IsNull(tbcf.Rows[i]["cfxh"], Guid.Empty.ToString()));
            //        _fph = Convert.ToInt64(Convertor.IsNull(tbcf.Rows[i]["发票号"], "0"));
            //        if (_xh == Guid.Empty) { lblerr.Visible = true; lblerr.Text = "对不起，处方序号为零不能确认！"; return; } else { lblerr.Visible = false; }

            //        int xx = MZPY.ExecPy(_xh, Convert.ToInt32(Convertor.IsNull(cmbpyr.SelectedValue, "0")), sDate, _Pyckh, InstanceForm.BDatabase);

            //        if (xx == 1)
            //        {

            //            string fph = Convertor.IsNull(tbcf.Rows[i]["发票号"], "0");
            //            DataRow[] delrow = tb1.Select("发票号=" + fph + "");
            //            if (delrow.Length != 0)
            //                tb1.Rows.Remove(delrow[0]);
            //        }
            //        else
            //        {
            //            if (rdosd.Checked == true)
            //            {
            //                MessageBox.Show("发票号为" + _fph.ToString() + " 的处方可能已配药，请刷新后再核实", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }
            //        }
            //    }

            //    //处方
            //    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            //    {
            //        if (chkcf.Checked == true && chkprint.Checked == true)
            //            this.PrintCf(tbcf.Rows[i], 1);
            //    }
            //    //注射单
            //    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            //    {
            //        if (chkzsd.Checked == true && chkprint.Checked == true)
            //            this.PrintCf(tbcf.Rows[i], 2);
            //    }

            //    //清单
            //    if (chkqd.Checked == true && chkprint.Checked == true)
            //    {
            //        DataTable tbselqd = tb2.Clone();
            //        for (int w = 0; w <= selrow.Length - 1; w++)
            //            tbselqd.ImportRow(selrow[w]);

            //        DataTable tbcfqd;
            //        string[] GroupbyFieldqd ={ "发票号"};
            //        string[] ComputeFieldqd ={ };
            //        string[] CFieldqd ={ };
            //        tbcfqd = FunBase.GroupbyDataTable(tbselqd, GroupbyFieldqd, ComputeFieldqd, CFieldqd, null);
            //        for (int i = 0; i <= tbcfqd.Rows.Count - 1; i++)
            //        {
            //            this.PrintCf(tbcfqd.Rows[i]["发票号"].ToString());
            //        }
            //    }

            //    tb2.Rows.Clear();

            //    timer2.Enabled = true;
                
            //    //tb1.Rows.Remove(tb1.Rows[0]);

            //}
            //catch (System.Exception err)
            //{
            //    if (this.butbegin.Text.Trim() == "停止") this.butbegin_Click(sender, e);
            //    throw new Exception(err.Message);
            //}

#endregion

            try
            {

                if (s.配药模式 == true && _Pyckh.Trim() == "") { lblerr.Visible = true; lblerr.Text = "配药窗口号没有维护，请先维护这个窗口"; return; }

                timer2.Enabled = false;

                //Guid _xh = Guid.Empty;
                string  _fph = "abcedfg";
                Guid _fpid = Guid.NewGuid();
                long _dnlsh = 0;
                string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;

                if (tb1.Rows.Count == 0 && rdozd.Checked == true) { this.butref_Click(sender, e); tb1 = (DataTable)this.myDataGrid1.DataSource; }


                //自动配药模式下才需要重新找处方
                if (rdozd.Checked == true && tb1.Rows.Count > 0)
                {
                    _fph = tb1.Rows[0]["发票号"].ToString();
                    _fpid = new Guid(tb1.Rows[0]["fpid"].ToString());
                    _dnlsh = Convert.ToInt64(tb1.Rows[0]["发票流水号"].ToString());
                }
                else
                {
                    DataTable tb2 = (DataTable)this.myDataGrid2.DataSource;
                    if (tb2.Rows.Count > 0)
                    {
                        _fph = tb2.Rows[0]["发票号"].ToString();
                        _fpid = new Guid(tb2.Rows[0]["fpid"].ToString());
                        _dnlsh = Convert.ToInt64(tb2.Rows[0]["发票流水号"].ToString());
                    }
                }

                if (this.rdosd.Checked == true)
                {
                    if (_fpid == Guid.Empty)
                    {
                        MessageBox.Show("没有选择配药记录,请确认", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                DataTable tbmx = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, Guid.Empty, "",
                         "", 0,
                        "", "", 0, -1, "", "", "", 0, "", "", 0, 0, "", "", "", 0, 0,_fpid,Guid.Empty, 0, InstanceForm.BDatabase);
               //         AddPresc(tbmx);

                int sss = tbmx.Rows.Count;

                int xx = MZPY.ExecPy(_fpid,InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(Convertor.IsNull(cmbpyr.SelectedValue, "0")), sDate, _Pyckh, InstanceForm.BDatabase);

                if (xx == 0)
                {
                    if (rdosd.Checked == true)
                    {
                        MessageBox.Show("发票号为" + _fph.ToString() + " 发票流水号为 "+_dnlsh.ToString()+" 的处方可能已配药，请刷新后再核实", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }

                DataRow[] delrow = tb1.Select("FPID='" + _fpid + "'");
                if (delrow.Length != 0)
                    tb1.Rows.Remove(delrow[0]);


                string[] GroupbyField ={ "cfxh", "发票号" };
                string[] ComputeField ={ };
                string[] CField ={ };
                DataTable tbmx_bf = tbmx.Copy();
                DataTable tbcf = FunBase.GroupbyDataTable(tbmx_bf, GroupbyField, ComputeField, CField, null);

                SystemCfg cfg8035 = new SystemCfg(8035);

                if (cfg8035.Config == "1")
                {
                    //处方
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkcf.Checked == true && chkprint.Checked == true && xx != 0)
                            this.PrintCf(tbcf.Rows[i], 1, tbmx);
                    }
                    //注射单
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkzsd.Checked == true && chkprint.Checked == true && xx != 0)
                            this.PrintCf(tbcf.Rows[i], 2, tbmx);
                    }

                    //清单
                    if (chkqd.Checked == true && chkprint.Checked == true && xx != 0)
                    {
                        this.PrintCf(_fpid.ToString(), tbmx);
                    }

                }
                else
                {
                    //清单
                    if (chkqd.Checked == true && chkprint.Checked == true && xx != 0)
                    {
                        this.PrintCf(_fpid.ToString(), tbmx);
                    }

                    //处方
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkcf.Checked == true && chkprint.Checked == true && xx != 0)
                            this.PrintCf(tbcf.Rows[i], 1, tbmx);
                    }
                    //注射单
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkzsd.Checked == true && chkprint.Checked == true && xx != 0)
                            this.PrintCf(tbcf.Rows[i], 2, tbmx);
                    }


                }

                if (rdozd.Checked==true) timer2.Enabled = true;


            }
            catch (System.Exception err)
            {
                if (this.butbegin.Text.Trim() == "停止") this.butbegin_Click(sender, e);
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

		}


		//退出
		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//窗体关闭时更新使用状态
		private void Frmmzpy_Closed(object sender, System.EventArgs e)
		{
			try
			{
                MZPY.Update_pyck(IPAddRess, _Pyckh, 0, InstanceForm.BDatabase);
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
				return;
			}
		}


		//手动自动切换事件
		private void rdozd_CheckedChanged(object sender, System.EventArgs e)
		{
            if (rdozd.Checked == true)
            {
                rdoyck.Checked = true;
                rdowck.Checked = false;
                butbegin.Enabled = true;
                butok.Enabled = false;
                //lblbz.Visible = true;
            }
            else
            {
                butbegin.Enabled = false;
                butok.Enabled = true;
                //lblbz.Visible = false;
            }


            rdoyck.Enabled = rdozd.Checked == true ? false : true;
            rdowck.Enabled = rdozd.Checked == true ? false : true;

            txtprint.Enabled = this.rdosd.Checked == true ? false : true;
			txtfph.Enabled=this.timer2.Enabled ==true?false:true ;
            txtmzh.Enabled = this.timer2.Enabled == true ? false : true;
            txtkh.Enabled = this.timer2.Enabled == true ? false : true;
            //txtghxh.Enabled = this.timer2.Enabled == true ? false : true;
            butref.Enabled = this.rdozd.Checked == true ? false : true;
			this.butok.Enabled=this.rdosd.Checked==true?true:false;
			DataTable tb=(DataTable)this.myDataGrid2.DataSource;
			tb.Rows.Clear();
		}

		//发票号回车事件
		private void txtfph_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			long fph=Convert.ToInt64(Convertor.IsNull(txtfph.Text,"0"));
			if (Convert.ToInt32(e.KeyChar)==13)
			{
                //this.RefreshMydataGrid1(fph,"","",0,this.myDataGrid1,"");
                //SelectCfmx(0,fph);
			}
		}



		//打印配药单
		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{

				DataTable tb2=(DataTable)this.myDataGrid2.DataSource;
				if (tb2.Rows.Count==0) {MessageBox.Show("没有可以打印的处方明细");return;}

                DataRow[] selrow = tb2.Select(" 配药员<>''");
                DataTable tbsel = tb2.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);

                //按发票号等分组明细
                string[] GroupbyField ={ "cfxh", "发票号" };
                string[] ComputeField ={ };
                string[] CField ={ };
                DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                if (tbcf.Rows.Count == 0)
                {
                    MessageBox.Show("明细列表中没有已配药的处方，只有已配了药的处方才能补打", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SystemCfg cfg8035 = new SystemCfg(8035);

                if (cfg8035.Config == "1")
                {
                    //处方
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkcf.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 1, tb2);
                    }
                    //注射单
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkzsd.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 2, tb2);
                    }

                    //清单
                    if (chkqd.Checked == true)
                    {
                        DataTable tbselqd = tb2.Clone();
                        for (int w = 0; w <= selrow.Length - 1; w++)
                            tbselqd.ImportRow(selrow[w]);

                        DataTable tbcfqd;
                        string[] GroupbyFieldqd ={ "FPID" };
                        string[] ComputeFieldqd ={ };
                        string[] CFieldqd ={ };
                        tbcfqd = FunBase.GroupbyDataTable(tbselqd, GroupbyFieldqd, ComputeFieldqd, CFieldqd, null);
                        for (int i = 0; i <= tbcfqd.Rows.Count - 1; i++)
                        {
                            this.PrintCf(tbcfqd.Rows[i]["FPID"].ToString(), tb2);
                        }
                    }
                }
                else
                {
                    //清单
                    if (chkqd.Checked == true)
                    {
                        DataTable tbselqd = tb2.Clone();
                        for (int w = 0; w <= selrow.Length - 1; w++)
                            tbselqd.ImportRow(selrow[w]);

                        DataTable tbcfqd;
                        string[] GroupbyFieldqd ={ "FPID" };
                        string[] ComputeFieldqd ={ };
                        string[] CFieldqd ={ };
                        tbcfqd = FunBase.GroupbyDataTable(tbselqd, GroupbyFieldqd, ComputeFieldqd, CFieldqd, null);
                        for (int i = 0; i <= tbcfqd.Rows.Count - 1; i++)
                        {
                            this.PrintCf(tbcfqd.Rows[i]["FPID"].ToString(), tb2);
                        }
                    }

                    //处方
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkcf.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 1, tb2);
                    }
                    //注射单
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkzsd.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 2, tb2);
                    }

                }



            }
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

        private void PrintCf(string fpid, DataTable tb2)
		{
            //DataTable tb2 = (DataTable)this.myDataGrid2.DataSource;
            DataRow[] rows;
            rows = tb2.Select(" fpid='" + fpid + "'");
            if (rows.Length == 0) return;

            string jtdz = ""; string grlxdh = ""; string sfzh = "";
            string ssql = "select * from yy_brxx a inner join mz_cfb b on a.brxxid=b.brxxid where b.cfid='" + rows[0]["cfxh"].ToString() + "'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                jtdz = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
                grlxdh = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
                sfzh = Convertor.IsNull(tb.Rows[0]["sfzh"], "");
            }

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;

            decimal sumje = 0;
            for (int i = 0; i <= rows.Length - 1; i++)
            {

                #region  非中药处方格式
                myrow = Dset.病人处方清单.NewRow();
                myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                myrow["cfts"] = rows[i]["剂数"].ToString();
                myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                sumje = sumje + Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "");
                myrow["pc"] = Convertor.IsNull(rows[i]["使用频次"], "");
                myrow["syjl"] = "";
                myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                myrow["ksname"] = Convert.ToString(rows[i]["科室"]).Trim();
                myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim();
                myrow["PSZT"] = rows[i]["皮试"].ToString();
                myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                myrow["pyr"] = this.cmbpyr.Text.Trim(); ;
                myrow["fyr"] = "";
                myrow["pyckdm"] = _Pyckh;
                myrow["fyckdm"] = Convert.ToString(rows[i]["发药窗口"]);
                myrow["zdmc"] = Convertor.IsNull(rows[i]["诊断"], "");
                myrow["syff"] = Convert.ToString(rows[i]["用法"]);
                myrow["sypc"] = Convert.ToString(rows[i]["使用频次"]);
                myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                myrow["ts"] = Convert.ToString(rows[i]["天数"]);
                myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");

                if (rows[i]["组标志"].ToString() == "1")
                {
                    yzzh = yzzh + 1;
                }
                myrow["yzzh"] = yzzh;
                myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                myrow["fzbz"] = rows[i]["组标志"].ToString();


                myrow["JTDZ"] = jtdz;
                myrow["LXDH"] = grlxdh;
                myrow["SFZH"] = sfzh;
                myrow["bz1"] = Convertor.IsNull(rows[i]["中药备注"], "");
                myrow["bz2"] = Convertor.IsNull(rows[i]["备注2"], "");
                myrow["bz3"] = Convertor.IsNull(rows[i]["备注3"], "");
                myrow["dyr"] = InstanceForm.BCurrentUser.Name;

                myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                Dset.病人处方清单.Rows.Add(myrow);
                #endregion

            }

            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Text = "cfts";
            parameters[0].Value = rows[0]["剂数"].ToString();
            parameters[1].Text = "zje";
            parameters[1].Value = sumje;

            parameters[2].Text = "TITLETEXT";
            parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "";
            parameters[3].Text = "text1";
            parameters[3].Value = "发药单位:" + InstanceForm.BCurrentDept.DeptName + "    诊断:" + rows[0]["诊断"].ToString();

            parameters[4].Text = "xyf";
            if (Convert.ToString(rows[0]["cflx"]) != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]) == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            bool bview = true;
            if (chkview.Checked == true) bview = false;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单.rpt", parameters, bview);
            if (f.LoadReportSuccess) f.Show(); else f.Dispose();


            
		}

        private void PrintCf(DataRow row, int cfgs, DataTable tb2)
        {
            //DataTable tb2 = (DataTable)this.myDataGrid2.DataSource;
            DataRow[] rows;
            if (cfgs==1)
                rows = tb2.Select(" cfxh='" + row["cfxh"] + "' ");
            else
                rows = tb2.Select(" cfxh='" + row["cfxh"] + "' and zsyp=1 ");
            if (rows.Length == 0) return;

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;

            string jtdz = ""; string grlxdh = ""; string sfzh = "";
            string ssql = "select * from yy_brxx a inner join mz_cfb b on a.brxxid=b.brxxid where b.cfid='" + row["cfxh"].ToString() + "'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                jtdz = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
                grlxdh = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
                sfzh = Convertor.IsNull(tb.Rows[0]["sfzh"], "");
            }

            for (int i = 0; i <= rows.Length - 1; i++)
            {

                    #region  非中药处方格式
                    myrow = Dset.病人处方清单.NewRow();
                    myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                    myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                    myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                    myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                    myrow["cfts"] = rows[i]["剂数"].ToString();
                    myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                    myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "") ;
                    myrow["pc"] = Convertor.IsNull(rows[i]["使用频次"], "");
                    myrow["syjl"] = "";
                    myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                    myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                    myrow["ksname"] = Convert.ToString(rows[i]["科室"]).Trim();
                    myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim();
                    myrow["PSZT"] = rows[i]["皮试"].ToString();
                    myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                    myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                    myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                    myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                    myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                    myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                    myrow["pyr"] = this.cmbpyr.Text.Trim(); ;
                    myrow["fyr"] = "";
                    myrow["pyckdm"] = _Pyckh;
                    myrow["fyckdm"] = Convert.ToString(rows[i]["发药窗口"]);
                    myrow["zdmc"] = Convertor.IsNull(rows[i]["诊断"], "");
                    myrow["syff"] = Convert.ToString(rows[i]["用法"]);
                    myrow["sypc"] = Convert.ToString(rows[i]["使用频次"]);
                    myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                    myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                    myrow["ts"] =Convert.ToDouble(Convertor.IsNull(rows[i]["天数"],"0")).ToString();
                    myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");

                    if (rows[i]["组标志"].ToString() == "1")
                    {
                        yzzh = yzzh + 1;
                    }
                    myrow["yzzh"] = yzzh;
                    myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                    myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                    myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                    myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                    myrow["fzbz"] = rows[i]["组标志"].ToString();

                    myrow["JTDZ"] = jtdz;
                    myrow["LXDH"] = grlxdh;
                    myrow["SFZH"] = sfzh;
                    myrow["bz1"] = Convertor.IsNull(rows[i]["中药备注"], "");
                    myrow["bz2"] = Convertor.IsNull(rows[i]["备注2"], "");
                    myrow["bz3"] = Convertor.IsNull(rows[i]["备注3"], "");
                    myrow["dyr"] = InstanceForm.BCurrentUser.Name;
                    myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                    myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                    Dset.病人处方清单.Rows.Add(myrow);
                    #endregion

            }

            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Text = "cfts";
            parameters[0].Value = rows[0]["剂数"].ToString();
            parameters[1].Text = "zje";
            parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(rows[0]["总金额"], "0"));
            parameters[2].Text = "TITLETEXT";
            parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "";
            parameters[3].Text = "text1";
            parameters[3].Value = "发药单位:" + InstanceForm.BCurrentDept.DeptName + "    诊断:" + rows[0]["诊断"].ToString();

            parameters[4].Text = "xyf";
            if (Convert.ToString(rows[0]["cflx"]) != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]) == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            bool bview = true;
            if (chkview.Checked == true) bview = false;
            TrasenFrame.Forms.FrmReportView f;
            if (cfgs==1)
            {
                if (Convert.ToString(rows[0]["cflx"]) == "03")
                    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单_中药处方.rpt", parameters, bview);

                else
                    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单(处方格式).rpt", parameters, bview);
            }
            else
            {
                f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单(注射单).rpt", parameters, bview);
            }
            if (f.LoadReportSuccess) f.Show(); else f.Dispose();


        }

        //刷新数据
        private void butref_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb;
                if (rdoyck.Checked == true)
                    tb = MZPY.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, "", 0, 0, "", "", _Pyckh, "", "", 0, InstanceForm.BDatabase,dtpcfrq.Value.ToShortDateString(),dtpcfrq.Value.ToShortDateString());
                else
                    tb = MZPY.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, "", 0, 0, "", "", "", "", "", 0, InstanceForm.BDatabase, dtpcfrq.Value.ToShortDateString(), dtpcfrq.Value.ToShortDateString());
                tb.TableName = "myTb";
                FunBase.AddRowtNo(tb);
                this.myDataGrid1.DataSource = tb;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmzh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int nkey = Convert.ToInt32(e.KeyChar);
                if (nkey == 13)
                {
                    DataTable mytb = (DataTable)this.myDataGrid1.DataSource;
                    mytb.Rows.Clear();

                    Control control = (Control)sender;
                    ts_mz_brxx.MzGhxx ghxx = null;
                    ts_mz_brxx.MzBrxx brxx = null;

                    string pyrq1=chkpyrq.Checked==true?dtp1.Value.ToShortDateString():"";
                    string pyrq2=chkpyrq.Checked==true?dtp2.Value.ToShortDateString():"";

                    DataTable tb = null;

                    if (control.Name == "txtmzh")
                    {
                        this.txtmzh.Text = FunBase.returnMzh(this.txtmzh.Text, InstanceForm.BDatabase,InstanceForm._menuTag.Jgbm);
                        DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, txtmzh.Text.Trim(), 0, 0, InstanceForm.BDatabase);
                        if (tbghxx.Rows.Count == 0) { MessageBox.Show("没有找到病人，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                        brxx = new ts_mz_brxx.MzBrxx(ghxx.binid, 0, "", "", 0, InstanceForm.BDatabase);

                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, ghxx.ghxh, "",
                            "", 0,
                            "", "", 0, -1, "", "", "", 0, pyrq1, pyrq2, 0, 0, "", "", "", 0, 0,Guid.Empty,Guid.Empty, 0, InstanceForm.BDatabase);
                        this.txtkh.Text = "";

                        //this.txtghxh.Text = "";
                        this.txtfph.Text = "";
                        _textBox = txtmzh;

                    }
                    if (control.Name == "txtkh")
                    {
                        int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));

                        //txtkh.Text = Fun.returnKh(klx, txtkh.Text.Trim(), InstanceForm.BDatabase);

                        brxx = new ts_mz_brxx.MzBrxx(Guid.Empty, klx, txtkh.Text, "", 0, InstanceForm.BDatabase);
                        if (brxx.binid == Guid.Empty) { MessageBox.Show("没有找到病人，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(brxx.binid, Guid.Empty, "", 0, 0, InstanceForm.BDatabase);

                        Guid ghxxid = Guid.Empty;
                        if (tbghxx.Rows.Count == 1)
                        {
                            ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                            ghxxid = ghxx.ghxh;
                        }

                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, ghxxid, "",
                            "", 0,
                            "", "", 0, -1, "", "", "", 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, brxx.binid,0, InstanceForm.BDatabase);
                        this.txtmzh.Text = "";
                        //this.txtghxh.Text = "";
                        this.txtfph.Text = "";
                        _textBox = txtkh;
                    }
                    if (control.Name == "txtghxh")
                    {
                        //DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, new Guid(Convertor.IsNull(txtghxh.Text, Guid.Empty.ToString())), "", 0, 0);
                        //if (tbghxx.Rows.Count == 0) { MessageBox.Show("没有找到病人，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        //ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                        //brxx = new ts_mz_brxx.MzBrxx(ghxx.binid, "", "", 0);

                        //tb = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, ghxx.ghxh, "",
                        //    0, 0,
                        //    "", "", 0,0, "", "", "", 0, "", "", 0, 0, "", "", "", 0, 0, 0);
                        //this.txtmzh.Text = "";
                        //this.txtkh.Text = "";
                        //this.txtfph.Text = "";
                        //_textBox = txtghxh;
                    }
                    if (control.Name == "txtfph")
                    {
                        if (Convert.ToInt64(Convertor.IsNull(txtfph.Text, "0")) == 0) return;
                        DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, "", Convert.ToInt64(Convertor.IsNull(txtfph.Text, "0")), 0, InstanceForm.BDatabase);
                        if (tbghxx.Rows.Count == 0) { MessageBox.Show("没有找到病人，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                        brxx = new ts_mz_brxx.MzBrxx(ghxx.binid, 0, "", "", 0, InstanceForm.BDatabase);

                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, Guid.Empty, "",
                            Convertor.IsNull(txtfph.Text, "0"), 0,
                            "", "", 0, -1, "", "", "", 0, "", "", 0, 0, "", "", "", 0, 0,Guid.Empty,Guid.Empty, 0, InstanceForm.BDatabase);
                        this.txtmzh.Text = "";
                        this.txtkh.Text = "";
                        //this.txtghxh.Text = "";
                        _textBox = txtfph;
                    }

                    this.AddPresc(tb);


                    TextBox control1 = (TextBox)sender;
                    control1.SelectAll();
                    control1.Focus();
                    
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        //添加处方记录
        private void AddPresc(DataTable tbcf)
        {

            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            tb.Rows.Clear();

            if (tbcf.Rows.Count == 0) return;
            string _prescNo = tbcf.Rows[0]["处方号"].ToString().Trim();
            int _PrescRowNo = 0;
            decimal _PrescJe = 0;

            for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            {
                if (tbcf.Rows[i]["处方号"].ToString().Trim() != _prescNo)
                {
                    DataRow row = tb.NewRow();
                    row["序号"] = "小计";
                    row["金额"] = _PrescJe.ToString("0.00");
                    row["处方号"] = _prescNo;
                    _prescNo = tbcf.Rows[i]["处方号"].ToString().Trim();
                    _PrescRowNo = 0;
                    _PrescJe = 0;
                    tb.Rows.Add(row);

                    DataRow row1 = tb.NewRow();
                    tb.Rows.Add(row1);
                }

                if (tbcf.Rows[i]["处方号"].ToString().Trim() == _prescNo)
                {
                    _PrescRowNo = _PrescRowNo + 1;
                    tbcf.Rows[i]["序号"] =Convert.ToString(_PrescRowNo.ToString());
                    //					if (this.tabControl1.SelectedTab==this.tabPage2) tbcf.Rows[i]["发药"]="√";
                    tb.ImportRow(tbcf.Rows[i]); 
                    _PrescJe = _PrescJe + Convert.ToDecimal(tbcf.Rows[i]["金额"]);
                }

                _prescNo = tbcf.Rows[i]["处方号"].ToString().Trim();

            }

            //添加最后一张处方的合计
            DataRow endrow = tb.NewRow();
            endrow["序号"] = "小计";
            endrow["金额"] = _PrescJe.ToString("0.00");
            endrow["处方号"] = _prescNo;
            tb.Rows.Add(endrow);
        }



        private void butqhpyck_Click(object sender, EventArgs e)
        {
            this.Close();
            Frmpyck f = new Frmpyck(_menuTag, _chineseName, _mdiParent);
            f.ShowDialog();

        }

        private void Frmmzpy_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SERVER_NAME", "NAME", Constant.ApplicationDirectory + "\\ClientConfig.ini");
                string connectionString = WorkStaticFun.GetConnnectionString(ConnectionType.SQLSERVER, serverName);
                RelationalDatabase database=FunBase.Database(ConnectionType.SQLSERVER, connectionString);
                MZPY.Update_pyck(IPAddRess, _Pyckh, 0,database);
                database.Dispose();

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

        }

        private void rdoyck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                string pyrq1 = chkpyrq.Checked == true ? dtp1.Value.ToString() : "";
                string pyrq2 = chkpyrq.Checked == true ? dtp2.Value.ToString() : "";
                DataTable  tb = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId,Guid.Empty, "",
                        "", 0,
                        "", "", 0, -1, "", "", "", 0, pyrq1, pyrq2, 0, 0, "", "", "", 0, 0,Guid.Empty,Guid.Empty , 0, InstanceForm.BDatabase);
                this.AddPresc(tb);
                
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkpyrq_CheckedChanged(object sender, EventArgs e)
        {
            dtp1.Enabled = chkpyrq.Checked == true ? true : false;
            dtp2.Enabled = chkpyrq.Checked == true ? true : false;
            butcx.Enabled = chkpyrq.Checked == true ? true : false;
            butok.Enabled = chkpyrq.Checked == true ? false : true;
        }

        private void myDataGrid2_CurrentCellChanged(object sender, EventArgs e)
        {
            this.myDataGrid2.Select(this.myDataGrid2.CurrentCell.RowNumber);
        }

        private void mnuqxpy_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)myDataGrid2.DataSource;
                if (tb.Rows.Count == 0) return;
                if (myDataGrid2.CurrentCell.RowNumber < 0) return;
                int nrow = myDataGrid2.CurrentCell.RowNumber;

                string cfid = tb.Rows[nrow]["cfxh"].ToString();
                string mzh = tb.Rows[nrow]["门诊号"].ToString();
                string ssql = "select * from mz_cfb where cfid='"+cfid+"' and blh='"+mzh+"'";
                DataTable tbcf = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbcf.Rows.Count == 0) return;
                if (tbcf.Rows[0]["bpybz"].ToString() == "0")
                {
                    MessageBox.Show("该处方还没有配药,不能进行此操作", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tbcf.Rows[0]["bpybz"].ToString() == "-1")
                {
                    MessageBox.Show("该处方已取消配药操作,不能再次取消", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tbcf.Rows[0]["bfybz"].ToString() == "1")
                {
                    MessageBox.Show("该处方已发药,不能取消配药", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ssql = "update mz_cfb set bpybz=-1,pyr=0,pyrxm='',pyrq=null where cfid='" + cfid + "' and blh='" + mzh + "' and bfybz=0 ";
                int iii=InstanceForm.BDatabase.DoCommand(ssql);
                if (iii == 0)
                {
                    MessageBox.Show("没有更新到记录,请重新刷新数据", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string str_old = "取消 门诊号为'"+mzh+"' cfid为 '"+cfid+"' 的处方配药操作";
                SystemLog systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "取消配药", str_old, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, 8);
                systemLog.Save();
                systemLog = null;

                MessageBox.Show("取消成功");

                tb.Rows.Clear();
                return;
                
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)myDataGrid2.DataSource;
                if (tb.Rows.Count == 0) return;
                if (myDataGrid2.CurrentCell.RowNumber < 0) return;
                int nrow = myDataGrid2.CurrentCell.RowNumber;

                string fph = tb.Rows[nrow]["发票号"].ToString();
                string mzh = tb.Rows[nrow]["门诊号"].ToString();

                if (fph == "" || mzh == "")
                    mnuqxpy.Enabled = false;
                else mnuqxpy.Enabled = true;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)myDataGrid1.DataSource;
                if (tb.Rows.Count > 0) return;
                else
                    butref_Click(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butok_Click(object sender, EventArgs e)
        {
            try
            {

                if (s.配药模式 == true && _Pyckh.Trim() == "") { lblerr.Visible = true; lblerr.Text = "配药窗口号没有维护，请先维护这个窗口"; return; }

            

                string _fph = "abcedfg";
                Guid _fpid = Guid.Empty;
                long _dnlsh = 0;
                string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;
                DataTable tb2 = (DataTable)this.myDataGrid2.DataSource;


                //分组处方
                string[] GroupbyFieldx ={ "发票号", "fpid", "发票流水号"};
                string[] ComputeFieldx ={ };
                string[] CFieldx ={  };
                TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                xcset.TsDataTable = tb2;
                DataTable tbcfx = xcset.GroupTable(GroupbyFieldx, ComputeFieldx, CFieldx, "收费日期<>''");
                if (tbcfx.Rows.Count == 0)
                {
                    MessageBox.Show("没有选择配药记录,请确认", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                for (int x = 0; x <= tbcfx.Rows.Count - 1; x++)
                {
                    _fph = tbcfx.Rows[x]["发票号"].ToString();
                    _fpid = new Guid(tbcfx.Rows[x]["fpid"].ToString());
                    _dnlsh = Convert.ToInt64(tbcfx.Rows[x]["发票流水号"].ToString());

                    DataTable tbmx = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, Guid.Empty, "",
                             "", 0,
                            "", "", 0, -1, "", "", "", 0, "", "", 0, 0, "", "", "", 0, 0, _fpid, Guid.Empty, 0, InstanceForm.BDatabase);
                    int sss = tbmx.Rows.Count;

                    int xx = MZPY.ExecPy(_fpid, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(Convertor.IsNull(cmbpyr.SelectedValue, "0")), sDate, _Pyckh, InstanceForm.BDatabase);

                    if (xx == 0)
                    {
                        if (rdosd.Checked == true)
                        {
                            MessageBox.Show("发票号为" + _fph.ToString() + " 发票流水号为 " + _dnlsh.ToString() + " 的处方可能已配药，请刷新后再核实", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }

                    DataRow[] delrow = tb1.Select("FPID='" + _fpid + "'");
                    if (delrow.Length != 0)
                        tb1.Rows.Remove(delrow[0]);


                    string[] GroupbyField ={ "cfxh", "发票号" };
                    string[] ComputeField ={ };
                    string[] CField ={ };
                    DataTable tbmx_bf = tbmx.Copy();
                    DataTable tbcf = FunBase.GroupbyDataTable(tbmx_bf, GroupbyField, ComputeField, CField, null);

                    SystemCfg cfg8035 = new SystemCfg(8035);

                    if (cfg8035.Config == "1")
                    {
                        //处方
                        for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                        {
                            if (chkcf.Checked == true && chkprint.Checked == true && xx != 0)
                                this.PrintCf(tbcf.Rows[i], 1, tbmx);
                        }
                        //注射单
                        for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                        {
                            if (chkzsd.Checked == true && chkprint.Checked == true && xx != 0)
                                this.PrintCf(tbcf.Rows[i], 2, tbmx);
                        }

                        //清单
                        if (chkqd.Checked == true && chkprint.Checked == true && xx != 0)
                        {
                            this.PrintCf(_fpid.ToString(), tbmx);
                        }

                    }
                    else
                    {
                        //清单
                        if (chkqd.Checked == true && chkprint.Checked == true && xx != 0)
                        {
                            this.PrintCf(_fpid.ToString(), tbmx);
                        }

                        //处方
                        for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                        {
                            if (chkcf.Checked == true && chkprint.Checked == true && xx != 0)
                                this.PrintCf(tbcf.Rows[i], 1, tbmx);
                        }
                        //注射单
                        for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                        {
                            if (chkzsd.Checked == true && chkprint.Checked == true && xx != 0)
                                this.PrintCf(tbcf.Rows[i], 2, tbmx);
                        }

                    }
                }

            }
            catch (System.Exception err)
            {
                if (this.butbegin.Text.Trim() == "停止") this.butbegin_Click(sender, e);
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] GetImageByte(string strEmployeeId)
        {
            string ss = "select sign from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID=" + strEmployeeId + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ss);
            if (tb == null || tb.Rows.Count == 0)
                return null;
            else
                return ((byte[])tb.Rows[0]["sign"]);
        }

	}
}
