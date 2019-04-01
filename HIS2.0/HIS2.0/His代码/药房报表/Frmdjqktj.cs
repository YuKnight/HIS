using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;

namespace ts_yf_tjbb
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class Frmdjqktj : System.Windows.Forms.Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Button buttj;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private myDataGrid.myDataGrid myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
        private System.Windows.Forms.CheckBox chkyplx;
        private System.Windows.Forms.CheckBox chkypzlx;
        private System.Windows.Forms.ComboBox cmbypzlx;
        private System.Windows.Forms.TextBox txtypmc;
        private System.Windows.Forms.GroupBox groupBox3;
        private myDataGrid.myDataGrid myDataGrid2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.ComboBox cmbywlx;
        private System.Windows.Forms.TextBox txtghdw;
        private System.Windows.Forms.CheckBox chkghdw;
        private System.Windows.Forms.ComboBox cmbyplx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.Button butmx;
        private System.Windows.Forms.CheckBox chkyphz;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
        private System.Windows.Forms.StatusBarPanel statusBarPanel4;
        private System.Windows.Forms.StatusBarPanel statusBarPanel5;
        private System.Windows.Forms.StatusBarPanel statusBarPanel7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
        private DataGridTextBoxColumn dataGridTextBoxColumn22;
        private DataGridTableStyle dataGridTableStyle2;
        private DataGridTextBoxColumn dataGridTextBoxColumn23;
        private DataGridTextBoxColumn dataGridTextBoxColumn24;
        private DataGridTextBoxColumn dataGridTextBoxColumn25;
        private DataGridTextBoxColumn dataGridTextBoxColumn26;
        private DataGridTextBoxColumn dataGridTextBoxColumn27;
        private DataGridTextBoxColumn dataGridTextBoxColumn28;
        private DataGridTextBoxColumn dataGridTextBoxColumn29;
        private DataGridTextBoxColumn dataGridTextBoxColumn30;
        private DataGridTextBoxColumn dataGridTextBoxColumn31;
        private DataGridTextBoxColumn dataGridTextBoxColumn32;
        private DataGridTextBoxColumn dataGridTextBoxColumn33;
        private DataGridTextBoxColumn dataGridTextBoxColumn34;
        private DataGridTextBoxColumn dataGridTextBoxColumn35;
        private DataGridTextBoxColumn dataGridTextBoxColumn36;
        private Button btnExport;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frmdjqktj(MenuTag menuTag, string chineseName, Form mdiParent)
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
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkyphz = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butmx = new System.Windows.Forms.Button();
            this.txtghdw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtypmc = new System.Windows.Forms.TextBox();
            this.cmbywlx = new System.Windows.Forms.ComboBox();
            this.cmbypzlx = new System.Windows.Forms.ComboBox();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkyplx = new System.Windows.Forms.CheckBox();
            this.chkypzlx = new System.Windows.Forms.CheckBox();
            this.chkghdw = new System.Windows.Forms.CheckBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel5 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel7 = new System.Windows.Forms.StatusBarPanel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.chkyphz);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbyplx);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.butmx);
            this.groupBox1.Controls.Add(this.txtghdw);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtypmc);
            this.groupBox1.Controls.Add(this.cmbywlx);
            this.groupBox1.Controls.Add(this.cmbypzlx);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.buttj);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkyplx);
            this.groupBox1.Controls.Add(this.chkypzlx);
            this.groupBox1.Controls.Add(this.chkghdw);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 525);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(40, 462);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(88, 24);
            this.btnExport.TabIndex = 33;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkyphz
            // 
            this.chkyphz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkyphz.Location = new System.Drawing.Point(10, 16);
            this.chkyphz.Name = "chkyphz";
            this.chkyphz.Size = new System.Drawing.Size(104, 24);
            this.chkyphz.TabIndex = 32;
            this.chkyphz.Text = "按药品汇总";
            this.chkyphz.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "业务类型";
            // 
            // cmbyplx
            // 
            this.cmbyplx.Enabled = false;
            this.cmbyplx.Location = new System.Drawing.Point(24, 102);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(160, 20);
            this.cmbyplx.TabIndex = 1;
            this.cmbyplx.SelectedIndexChanged += new System.EventHandler(this.cmbyplx_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "单个药品查询";
            // 
            // butmx
            // 
            this.butmx.Location = new System.Drawing.Point(40, 400);
            this.butmx.Name = "butmx";
            this.butmx.Size = new System.Drawing.Size(88, 24);
            this.butmx.TabIndex = 9;
            this.butmx.Text = "查看明细(&M)";
            this.butmx.Click += new System.EventHandler(this.butmx_Click);
            // 
            // txtghdw
            // 
            this.txtghdw.Enabled = false;
            this.txtghdw.Location = new System.Drawing.Point(24, 176);
            this.txtghdw.Name = "txtghdw";
            this.txtghdw.Size = new System.Drawing.Size(160, 21);
            this.txtghdw.TabIndex = 3;
            this.txtghdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "到";
            // 
            // txtypmc
            // 
            this.txtypmc.Enabled = false;
            this.txtypmc.Location = new System.Drawing.Point(24, 216);
            this.txtypmc.Name = "txtypmc";
            this.txtypmc.Size = new System.Drawing.Size(160, 21);
            this.txtypmc.TabIndex = 4;
            this.txtypmc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // cmbywlx
            // 
            this.cmbywlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbywlx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbywlx.Items.AddRange(new object[] {
            "001 采购入库",
            "002 药品退货",
            "003 药品调拨出库",
            "004 药房退库",
            "005 药品调价",
            "006 药品报损",
            "007 药品报溢",
            "008 药品盘点",
            "009 期初入库",
            "012 账务调整",
            "014 其它领药单",
            "015 药品调入库单",
            "016 药库出库单",
            "017 处方出库",
            "018 门诊记帐处方补录出库",
            "019 其它入库",
            "020 处方补录出库"});
            this.cmbywlx.Location = new System.Drawing.Point(24, 58);
            this.cmbywlx.Name = "cmbywlx";
            this.cmbywlx.Size = new System.Drawing.Size(160, 24);
            this.cmbywlx.TabIndex = 0;
            this.cmbywlx.SelectedIndexChanged += new System.EventHandler(this.cmbywlx_SelectedIndexChanged);
            // 
            // cmbypzlx
            // 
            this.cmbypzlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbypzlx.Enabled = false;
            this.cmbypzlx.Location = new System.Drawing.Point(24, 139);
            this.cmbypzlx.Name = "cmbypzlx";
            this.cmbypzlx.Size = new System.Drawing.Size(160, 20);
            this.cmbypzlx.TabIndex = 2;
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(40, 432);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(88, 24);
            this.butquit.TabIndex = 10;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(40, 368);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 24);
            this.butprint.TabIndex = 8;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // buttj
            // 
            this.buttj.Location = new System.Drawing.Point(40, 336);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(88, 24);
            this.buttj.TabIndex = 7;
            this.buttj.Text = "统计(&T)";
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(24, 304);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(140, 21);
            this.dtp2.TabIndex = 6;
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(24, 264);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(140, 21);
            this.dtp1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "日期从";
            // 
            // chkyplx
            // 
            this.chkyplx.Location = new System.Drawing.Point(8, 81);
            this.chkyplx.Name = "chkyplx";
            this.chkyplx.Size = new System.Drawing.Size(80, 23);
            this.chkyplx.TabIndex = 16;
            this.chkyplx.Text = "药品类型";
            this.chkyplx.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // chkypzlx
            // 
            this.chkypzlx.Enabled = false;
            this.chkypzlx.Location = new System.Drawing.Point(8, 120);
            this.chkypzlx.Name = "chkypzlx";
            this.chkypzlx.Size = new System.Drawing.Size(88, 24);
            this.chkypzlx.TabIndex = 17;
            this.chkypzlx.Text = "药品子类型";
            this.chkypzlx.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // chkghdw
            // 
            this.chkghdw.Location = new System.Drawing.Point(8, 157);
            this.chkghdw.Name = "chkghdw";
            this.chkghdw.Size = new System.Drawing.Size(88, 24);
            this.chkghdw.TabIndex = 23;
            this.chkghdw.Text = "供货单位";
            this.chkghdw.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(184, 502);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4,
            this.statusBarPanel5,
            this.statusBarPanel7});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(760, 23);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 120;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 120;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 120;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Width = 120;
            // 
            // statusBarPanel5
            // 
            this.statusBarPanel5.Name = "statusBarPanel5";
            this.statusBarPanel5.Width = 120;
            // 
            // statusBarPanel7
            // 
            this.statusBarPanel7.Name = "statusBarPanel7";
            this.statusBarPanel7.Width = 1000;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(754, 317);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "品名";
            this.dataGridTextBoxColumn4.Width = 120;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "规格";
            this.dataGridTextBoxColumn11.Width = 90;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "厂家";
            this.dataGridTextBoxColumn9.Width = 90;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "现有库存";
            this.dataGridTextBoxColumn22.Width = 75;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "数量";
            this.dataGridTextBoxColumn10.Width = 60;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "盈亏数量";
            this.dataGridTextBoxColumn15.Width = 60;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "调价数量";
            this.dataGridTextBoxColumn16.Width = 60;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "单位";
            this.dataGridTextBoxColumn14.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "供货单位";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "科目";
            this.dataGridTextBoxColumn17.Width = 120;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "领药单位";
            this.dataGridTextBoxColumn18.Width = 120;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "报溢原因";
            this.dataGridTextBoxColumn19.Width = 120;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "报损原因";
            this.dataGridTextBoxColumn20.Width = 120;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "往来单位";
            this.dataGridTextBoxColumn21.NullText = "";
            this.dataGridTextBoxColumn21.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "进货金额";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "批发金额";
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "零售金额";
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "进零差额";
            this.dataGridTextBoxColumn7.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "批零差额";
            this.dataGridTextBoxColumn8.Width = 75;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "CJID";
            this.dataGridTextBoxColumn12.Width = 0;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "往来单位ID";
            this.dataGridTextBoxColumn13.Width = 80;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.myDataGrid2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(184, 342);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 160);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "明细情况";
            this.groupBox3.Visible = false;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.Size = new System.Drawing.Size(754, 140);
            this.myDataGrid2.TabIndex = 0;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid2.Navigate += new System.Windows.Forms.NavigateEventHandler(this.myDataGrid2_Navigate);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn35,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn30,
            this.dataGridTextBoxColumn31,
            this.dataGridTextBoxColumn32,
            this.dataGridTextBoxColumn33,
            this.dataGridTextBoxColumn34,
            this.dataGridTextBoxColumn36});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "序号";
            this.dataGridTextBoxColumn23.Width = 45;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "货号";
            this.dataGridTextBoxColumn35.NullText = "";
            this.dataGridTextBoxColumn35.Width = 60;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "品名";
            this.dataGridTextBoxColumn24.NullText = "";
            this.dataGridTextBoxColumn24.Width = 120;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "商品名";
            this.dataGridTextBoxColumn25.NullText = "";
            this.dataGridTextBoxColumn25.Width = 80;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "规格";
            this.dataGridTextBoxColumn26.NullText = "";
            this.dataGridTextBoxColumn26.Width = 80;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "厂家";
            this.dataGridTextBoxColumn27.Width = 75;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "数量";
            this.dataGridTextBoxColumn28.NullText = "";
            this.dataGridTextBoxColumn28.Width = 60;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "单位";
            this.dataGridTextBoxColumn29.Width = 40;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "批发金额";
            this.dataGridTextBoxColumn30.NullText = "";
            this.dataGridTextBoxColumn30.Width = 65;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "零售金额";
            this.dataGridTextBoxColumn31.NullText = "";
            this.dataGridTextBoxColumn31.Width = 65;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "单据号";
            this.dataGridTextBoxColumn32.NullText = "";
            this.dataGridTextBoxColumn32.Width = 60;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "日期";
            this.dataGridTextBoxColumn33.Width = 75;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Format = "";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "往来单位";
            this.dataGridTextBoxColumn34.NullText = "";
            this.dataGridTextBoxColumn34.Width = 75;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "备注";
            this.dataGridTextBoxColumn36.NullText = "";
            this.dataGridTextBoxColumn36.Width = 200;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(184, 337);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(760, 5);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(184, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 337);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "汇总情况";
            // 
            // Frmdjqktj
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmdjqktj";
            this.Text = "单据情况统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmxspm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>


        private void txtnum_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //if (Convertor.IsNumeric(txtnum.Text)==false) txtnum.Text="";
        }

        private void Frmxspm_Load(object sender, System.EventArgs e)
        {
            try
            {
                dtp1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
                dtp2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
                Yp.AddCmbYplx(true, InstanceForm.BCurrentDept.DeptId, this.cmbyplx, InstanceForm.BDatabase);
                Yp.AddCmbYpzlx(InstanceForm.BCurrentDept.DeptId, 1, this.cmbypzlx, InstanceForm.BDatabase);
                Yp.AddcmbYwlx(InstanceForm.BCurrentDept.DeptId, cmbywlx, InstanceForm.BDatabase);
                this.cmbywlx.SelectedIndex = 0;


            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }


        }

        private void buttj_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                this.buttj.Enabled = false;
                FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
                FunBase.CsDataGrid(this.myDataGrid2, this.myDataGrid2.TableStyles[0], "Tbmx");

                ParameterEx[] parameters = new ParameterEx[9];
                parameters[0].Value = Convert.ToInt32(this.chkyphz.Checked);
                parameters[1].Value = cmbywlx.SelectedValue.ToString().Trim();
                parameters[2].Value = chkyplx.Checked == true ? Convert.ToInt32(cmbyplx.SelectedValue) : 0;
                parameters[3].Value = chkypzlx.Checked == true ? Convert.ToInt32(cmbypzlx.SelectedValue) : 0;
                parameters[4].Value = chkghdw.Checked == true ? Convert.ToInt32(Convertor.IsNull(txtghdw.Tag, "0")) : 0;
                parameters[5].Value = txtypmc.Enabled == true ? Convert.ToInt32(Convertor.IsNull(txtypmc.Tag, "0")) : 0;
                parameters[6].Value = dtp1.Value.ToString();
                parameters[7].Value = dtp2.Value.ToString();
                parameters[8].Value = InstanceForm.BCurrentDept.DeptId;

                parameters[0].Text = "@type";
                parameters[1].Text = "@ywlx";
                parameters[2].Text = "@yplx";
                parameters[3].Text = "@ypzlx";
                parameters[4].Text = "@ghdw";
                parameters[5].Text = "@cjid";
                parameters[6].Text = "@dtp1";
                parameters[7].Text = "@dtp2";
                parameters[8].Text = "@deptid";


                //DataTable tb=InstanceForm.BDatabase.GetDataTable("SP_YF_tj_djqktj",parameters,30);

                DataSet _dtset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_YF_tj_djqktj", parameters, _dtset, "dtset", 30);

                FunBase.AddRowtNo(_dtset.Tables[0]);
                FunBase.AddRowtNo(_dtset.Tables[1]);
                _dtset.Tables[0].TableName = "Tb";
                _dtset.Tables[1].TableName = "Tbmx";
                this.myDataGrid1.DataSource = (DataTable)_dtset.Tables[0];
                this.myDataGrid2.DataSource = (DataTable)_dtset.Tables[1];

                DataTable tb = _dtset.Tables[0];
                decimal sumjhje = 0;
                decimal sumpfje = 0;
                decimal sumlsje = 0;
                decimal sumplce = 0;
                decimal sumjlce = 0;

                this.statusBar1.Panels[0].Text = "";
                this.statusBar1.Panels[1].Text = "";
                this.statusBar1.Panels[2].Text = "";
                this.statusBar1.Panels[3].Text = "";
                this.statusBar1.Panels[4].Text = "";

                DataRow newrow = tb.NewRow();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    switch (cmbywlx.SelectedValue.ToString().Trim())
                    {
                        case "001":
                        case "002":
                            sumjhje = sumjhje + Convert.ToDecimal(tb.Rows[i]["进货金额"]);
                            sumpfje = sumpfje + Convert.ToDecimal(tb.Rows[i]["批发金额"]);
                            sumlsje = sumlsje + Convert.ToDecimal(tb.Rows[i]["零售金额"]);
                            sumjlce = sumjlce + Convert.ToDecimal(tb.Rows[i]["进零差额"]);
                            sumplce = sumplce + Convert.ToDecimal(tb.Rows[i]["批零差额"]);
                            this.statusBar1.Panels[0].Text = "进货金额 " + sumjhje.ToString("0.00");
                            this.statusBar1.Panels[1].Text = "批发金额 " + sumpfje.ToString("0.00");
                            this.statusBar1.Panels[2].Text = "零售金额 " + sumlsje.ToString("0.00");
                            this.statusBar1.Panels[3].Text = "进零差额 " + sumjlce.ToString("0.00");
                            this.statusBar1.Panels[4].Text = "批零差额 " + sumplce.ToString("0.00");
                            newrow["进货金额"] = sumjhje.ToString("0.00");
                            newrow["批发金额"] = sumpfje.ToString("0.00");
                            newrow["零售金额"] = sumlsje.ToString("0.00");
                            newrow["进零差额"] = sumjlce.ToString("0.00");
                            newrow["批零差额"] = sumplce.ToString("0.00");
                            break;
                        case "003":
                        case "004":
                        case "006":
                        case "007":
                        case "009":
                        case "014":
                        case "015":
                        case "016":
                        case "017":
                        case "018":
                        case "019":
                        case "020":
                        case "021":
                        case "022":
                        case "023":
                        case "024":
                        case "025":
                        case "026":
                            sumjhje = 0;
                            sumpfje = sumpfje + Convert.ToDecimal(tb.Rows[i]["批发金额"]);
                            sumlsje = sumlsje + Convert.ToDecimal(tb.Rows[i]["零售金额"]);
                            sumjlce = 0;
                            sumplce = sumplce + Convert.ToDecimal(tb.Rows[i]["批零差额"]);
                            this.statusBar1.Panels[0].Text = "批发金额 " + sumpfje.ToString("0.00");
                            this.statusBar1.Panels[1].Text = "零售金额 " + sumlsje.ToString("0.00");
                            this.statusBar1.Panels[2].Text = "批零差额 " + sumplce.ToString("0.00");
                            newrow["批发金额"] = sumpfje.ToString("0.00");
                            newrow["零售金额"] = sumlsje.ToString("0.00");
                            newrow["批零差额"] = sumplce.ToString("0.00");
                            break;
                        case "005":
                        case "008":
                            sumjhje = 0;
                            sumpfje = sumpfje + Convert.ToDecimal(tb.Rows[i]["批发金额"]);
                            sumlsje = sumlsje + Convert.ToDecimal(tb.Rows[i]["零售金额"]);
                            sumjlce = 0;
                            sumplce = 0;
                            this.statusBar1.Panels[0].Text = "批发金额 " + sumpfje.ToString("0.00");
                            this.statusBar1.Panels[1].Text = "零售金额 " + sumlsje.ToString("0.00");
                            newrow["批发金额"] = sumpfje.ToString("0.00");
                            newrow["零售金额"] = sumlsje.ToString("0.00");
                            break;
                        case "012":
                            sumjhje = 0;
                            sumpfje = sumpfje + Convert.ToDecimal(tb.Rows[i]["批发金额"]);
                            sumlsje = sumlsje + Convert.ToDecimal(tb.Rows[i]["零售金额"]);
                            sumjlce = 0;
                            sumplce = 0;
                            this.statusBar1.Panels[0].Text = "调批发金额 " + sumpfje.ToString("0.00");
                            this.statusBar1.Panels[1].Text = "调零售金额 " + sumlsje.ToString("0.00");
                            newrow["批发金额"] = sumpfje.ToString("0.00");
                            newrow["零售金额"] = sumlsje.ToString("0.00");
                            break;

                    }

                }
                newrow["序号"] = "合计";
                tb.Rows.Add(newrow);
                this.buttj.Enabled = true;
            }
            catch (System.Exception err)
            {
                this.buttj.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butquit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void rdo2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkyphz.Checked == true) txtypmc.Enabled = true; else txtypmc.Enabled = false;
        }

        private void chkyplx_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbyplx.Enabled = chkyplx.Checked == true ? true : false;
            cmbypzlx.Enabled = chkypzlx.Checked == true ? true : false;
            txtghdw.Enabled = chkghdw.Checked == true ? true : false;
            chkypzlx.Enabled = chkyplx.Checked == true ? true : false;
        }

        private void butmx_Click(object sender, System.EventArgs e)
        {
            if (this.butmx.Text == "查看明细(&M)")
            {
                this.butmx.Text = "隐藏明细(&M)";
                this.groupBox3.Visible = true;
                return;
            }
            if (this.butmx.Text == "隐藏明细(&M)")
            {
                this.butmx.Text = "查看明细(&M)";
                this.groupBox3.Visible = false;
                return;
            }

        }

        private void cmbywlx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //			001 采购入库
            //			002 普通入库
            //			004 药品出库
            //			005 药品调价
            //			006 药品报损
            //			007 药品报溢
            //			008 药品盘点
            //			011 账务调整
            switch (cmbywlx.Text.Trim().Substring(0, 3))
            {
                case "001":
                    chkghdw.Enabled = true;
                    chkghdw.Text = "供货单位";
                    break;
                case "002":
                    chkghdw.Enabled = true;
                    chkghdw.Text = "供货科室";
                    break;
                case "004":
                    chkghdw.Enabled = true;
                    chkghdw.Text = "领药科室";
                    break;
                case "005":
                    chkghdw.Enabled = false;
                    break;
                case "006":
                    chkghdw.Enabled = false;
                    break;
                case "007":
                    chkghdw.Enabled = false;
                    break;
                case "008":
                    chkghdw.Enabled = false;
                    break;
                case "011":
                    chkghdw.Enabled = false;
                    break;

            }

        }


        //输入框控制事件
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
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

                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 3:
                        if (control.Text.Trim() == "") return;
                        if (cmbywlx.Text.Substring(0, 3) == "001")
                        {
                            GrdMappingName = new string[] { "id", "行号", "供货商", "拼音码", "五笔码" };
                            sfield = new string[] { "wbm", "pym", "", "", "" };
                            ssql = "select ID DEPT_ID,0  rowno,ghdwmc name,pym py_code ,wbm wb_code from yp_ghdw WHERE ID<>0 ";
                        }
                        else
                        {
                            GrdMappingName = new string[] { "id", "行号", "领药科室", "拼音码", "五笔码" };
                            sfield = new string[] { "wb_code", "py_code", "", "", "" };
                            ssql = "select DEPT_ID,0  rowno,name,py_code,wb_code from jc_dept_property  WHERE dept_ID in(select dyksid from yp_lyks where deptid=" + InstanceForm.BCurrentDept.DeptId + ")";
                        }


                        GrdWidth = new int[] { 0, 50, 200, 100, 100 };


                        TrasenFrame.Forms.Fshowcard f1 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                        f1.Location = point;
                        f1.ShowDialog(this);
                        row = f1.dataRow;
                        if (row != null)
                        {
                            control.Text = row["name"].ToString();
                            control.Tag = row["dept_id"].ToString();
                            this.SelectNextControl((Control)sender, true, false, true, true);
                        }
                        break;
                    case 4:
                        if (control.Text.Trim() == "") return;
                        GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                        GrdWidth = new int[] { 0, 0, 50, 200, 100, 100, 40, 0, 60, 60, 70 };
                        sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                        ssql = "select distinct a.ggid,cjid,0  rowno,ypspm,ypgg,dbo.fun_yp_sccj(sccj) sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_YF_kcmx a,yp_ypbm b where a.ggid=b.ggid and deptid=" + InstanceForm.BCurrentDept.DeptId + "  ";
                        TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, Constant.CustomFilterType, control.Text.Trim(), ssql);
                        f2.Location = point;
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

        private void cmbyplx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbypzlx.Enabled == true)
            {
                cmbypzlx.DataSource = null;
                Yp.AddCmbYpzlx(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(cmbyplx.SelectedValue), this.cmbypzlx, InstanceForm.BDatabase);
            }
        }

        private void butprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                this.butprint.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string swhere = "";
                if (this.chkyplx.Checked == true) swhere = chkyplx.Text + ":" + cmbyplx.Text.Trim();
                if (this.chkypzlx.Checked == true) swhere = swhere + " " + chkypzlx.Text + ":" + cmbypzlx.Text.Trim();
                swhere = swhere + " 日期从:" + this.dtp1.Value.ToShortDateString() + " 到" + this.dtp2.Value.ToShortDateString();
                if (this.chkghdw.Checked == true) swhere = swhere + " " + chkghdw.Text + ":" + this.txtghdw.Text.Trim();
                if (this.txtypmc.Text.Trim() != "") swhere = swhere + "  药品名称:" + txtypmc.Text.Trim();


                //写入行头
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    if (this.myDataGrid1.TableStyles[0].GridColumnStyles[tb.Columns[j].ColumnName].Width > 0)
                    {
                        SumColCount = SumColCount + 1;
                        myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                    }

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        if (this.myDataGrid1.TableStyles[0].GridColumnStyles[tb.Columns[j].ColumnName].Width > 0)
                        {
                            ncol = ncol + 1;
                            myExcel.Cells[6 + i, ncol] = "'" + tb.Rows[i][j].ToString().Trim();

                        }
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + this.cmbywlx.Text.Trim() + "汇总表";
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                myExcel.Cells[3, 1] = swhere.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //最后一行为黄色
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;


                //让Excel文件可见
                myExcel.Visible = true;
                this.butprint.Enabled = true;

                #endregion
            }
            catch (System.Exception err)
            {
                this.butprint.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        private void myDataGrid2_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkyphz.Checked)
                {
                    MessageBox.Show("请勾选按药品汇总");
                    return;
                }

                this.Cursor = PubStaticFun.WaitCursor();
                ParameterEx[] parameters = new ParameterEx[9];
                parameters[0].Value = Convert.ToInt32(this.chkyphz.Checked);
                parameters[1].Value = cmbywlx.SelectedValue.ToString().Trim();
                parameters[2].Value = chkyplx.Checked == true ? Convert.ToInt32(cmbyplx.SelectedValue) : 0;
                parameters[3].Value = chkypzlx.Checked == true ? Convert.ToInt32(cmbypzlx.SelectedValue) : 0;
                parameters[4].Value = chkghdw.Checked == true ? Convert.ToInt32(Convertor.IsNull(txtghdw.Tag, "0")) : 0;
                parameters[5].Value = txtypmc.Enabled == true ? Convert.ToInt32(Convertor.IsNull(txtypmc.Tag, "0")) : 0;
                parameters[6].Value = dtp1.Value.ToString();
                parameters[7].Value = dtp2.Value.ToString();
                parameters[8].Value = InstanceForm.BCurrentDept.DeptId;

                parameters[0].Text = "@type";
                parameters[1].Text = "@ywlx";
                parameters[2].Text = "@yplx";
                parameters[3].Text = "@ypzlx";
                parameters[4].Text = "@ghdw";
                parameters[5].Text = "@cjid";
                parameters[6].Text = "@dtp1";
                parameters[7].Text = "@dtp2";
                parameters[8].Text = "@deptid";


                //DataTable tb=InstanceForm.BDatabase.GetDataTable("SP_YF_tj_djqktj",parameters,30);

                DataSet _dtset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_YF_tj_djqktj", parameters, _dtset, "dtset", 30);

                FunBase.AddRowtNo(_dtset.Tables[0]);
                FunBase.AddRowtNo(_dtset.Tables[1]);


                DataTable tb = _dtset.Tables[0];

                //DataTable tb = (DataTable)myDataGrid1.DataSource;

                // 创建Excel对象                    --LeeWenjie    2006-11-29
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel无法启动");
                    return;
                }
                // 创建Excel工作薄
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // 列索引，行索引，总列数，总行数
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = tb.Columns.Count;
                int RowCount = tb.Rows.Count;

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "门诊处方出库汇总情况";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount];
                // 获取列标题
                for (int i = 0; i <= colCount - 1; i++)
                {
                    if (tb.Columns[i].Caption.ToString() != "现有库存")
                    {
                        objData[0, colIndex++] = tb.Columns[i].Caption;
                    }
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= colCount - 1; j++)
                    {
                        if (tb.Columns[j].Caption.ToString() != "现有库存")
                        {
                            objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString().Trim();
                        }
                    }
                    Application.DoEvents();
                }

                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }





    }
}
