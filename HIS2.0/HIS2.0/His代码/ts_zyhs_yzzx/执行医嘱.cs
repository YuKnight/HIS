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
//using Excel;
namespace ts_zyhs_yzzx
{
    /// <summary>
    /// 执行医嘱 的摘要说明。
    /// </summary>
    public class frmYZZX : System.Windows.Forms.Form
    {

        //自定义变量
        private BaseFunc myFunc;

        //add by jchl(pivas 是否审方才能发送判断)
        string cfg7605 = new SystemCfg(7605).Config;
        string cfg7602 = new SystemCfg(7602).Config;

        /// <summary>
        /// 医保病人的欠费控制是否按照医保实时试算结果进行欠费控制  0=否 1=是
        /// </summary>
        SystemCfg cfg7186 = new SystemCfg(7186);
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DateExecDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb临时账单;
        private System.Windows.Forms.CheckBox cb长期账单;
        private System.Windows.Forms.CheckBox cb临时医嘱;
        private System.Windows.Forms.CheckBox cb长期医嘱;
        private System.Windows.Forms.CheckBox cb选择医嘱和账单;
        private System.Windows.Forms.Button bt执行;
        private System.Windows.Forms.Button bt退出;
        private System.Windows.Forms.Button btOpenModel;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button bt反选;
        private System.Windows.Forms.Button bt全选;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox cb长期医嘱仅药品;
        private System.Windows.Forms.Panel panel4;
        private Button bt预算;
        private Button butdc;
        private GroupBox groupBox3;
        private RadioButton rbfkfy;
        private RadioButton rbsyyp;
        private RadioButton rbkfy;
        private System.ComponentModel.IContainer components = null;
        private Button button1;
        private SystemCfg cfg7052;
        public frmYZZX(string _formText)
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
            cfg7052 = new SystemCfg(7052);
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt反选 = new System.Windows.Forms.Button();
            this.bt全选 = new System.Windows.Forms.Button();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bt预算 = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bt执行 = new System.Windows.Forms.Button();
            this.bt退出 = new System.Windows.Forms.Button();
            this.btOpenModel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DateExecDate = new System.Windows.Forms.DateTimePicker();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbfkfy = new System.Windows.Forms.RadioButton();
            this.rbsyyp = new System.Windows.Forms.RadioButton();
            this.rbkfy = new System.Windows.Forms.RadioButton();
            this.butdc = new System.Windows.Forms.Button();
            this.cb临时账单 = new System.Windows.Forms.CheckBox();
            this.cb长期医嘱仅药品 = new System.Windows.Forms.CheckBox();
            this.cb长期账单 = new System.Windows.Forms.CheckBox();
            this.cb临时医嘱 = new System.Windows.Forms.CheckBox();
            this.cb长期医嘱 = new System.Windows.Forms.CheckBox();
            this.cb选择医嘱和账单 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 621);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(960, 533);
            this.panel4.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.bt反选);
            this.panel2.Controls.Add(this.bt全选);
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 533);
            this.panel2.TabIndex = 0;
            // 
            // bt反选
            // 
            this.bt反选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt反选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt反选.Location = new System.Drawing.Point(768, 1);
            this.bt反选.Name = "bt反选";
            this.bt反选.Size = new System.Drawing.Size(56, 20);
            this.bt反选.TabIndex = 89;
            this.bt反选.Text = "反选(&F)";
            this.bt反选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt反选.UseVisualStyleBackColor = false;
            this.bt反选.Click += new System.EventHandler(this.bt反选_Click);
            // 
            // bt全选
            // 
            this.bt全选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt全选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt全选.Location = new System.Drawing.Point(696, 1);
            this.bt全选.Name = "bt全选";
            this.bt全选.Size = new System.Drawing.Size(56, 20);
            this.bt全选.TabIndex = 88;
            this.bt全选.Text = "全选(&A)";
            this.bt全选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt全选.UseVisualStyleBackColor = false;
            this.bt全选.Click += new System.EventHandler(this.bt全选_Click);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "病人列表";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(960, 533);
            this.myDataGrid1.TabIndex = 87;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bt预算);
            this.panel3.Controls.Add(this.progressBar2);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.bt执行);
            this.panel3.Controls.Add(this.bt退出);
            this.panel3.Controls.Add(this.btOpenModel);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 533);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(960, 88);
            this.panel3.TabIndex = 2;
            // 
            // bt预算
            // 
            this.bt预算.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt预算.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt预算.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt预算.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt预算.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt预算.ImageIndex = 4;
            this.bt预算.Location = new System.Drawing.Point(810, 24);
            this.bt预算.Name = "bt预算";
            this.bt预算.Size = new System.Drawing.Size(64, 24);
            this.bt预算.TabIndex = 97;
            this.bt预算.Text = "预算(&Y)";
            this.bt预算.Click += new System.EventHandler(this.bt预算_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar2.Location = new System.Drawing.Point(8, 76);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(944, 8);
            this.progressBar2.TabIndex = 96;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(8, 61);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(944, 8);
            this.progressBar1.TabIndex = 95;
            // 
            // bt执行
            // 
            this.bt执行.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt执行.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt执行.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt执行.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt执行.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt执行.ImageIndex = 4;
            this.bt执行.Location = new System.Drawing.Point(740, 24);
            this.bt执行.Name = "bt执行";
            this.bt执行.Size = new System.Drawing.Size(64, 24);
            this.bt执行.TabIndex = 94;
            this.bt执行.Text = "发送(&S)";
            this.bt执行.Click += new System.EventHandler(this.bt执行_Click);
            // 
            // bt退出
            // 
            this.bt退出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt退出.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt退出.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt退出.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt退出.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt退出.ImageIndex = 4;
            this.bt退出.Location = new System.Drawing.Point(880, 24);
            this.bt退出.Name = "bt退出";
            this.bt退出.Size = new System.Drawing.Size(64, 24);
            this.bt退出.TabIndex = 93;
            this.bt退出.Text = "退出(&E)";
            this.bt退出.Click += new System.EventHandler(this.bt退出_Click);
            // 
            // btOpenModel
            // 
            this.btOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenModel.Enabled = false;
            this.btOpenModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btOpenModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpenModel.ImageIndex = 1;
            this.btOpenModel.Location = new System.Drawing.Point(732, 14);
            this.btOpenModel.Name = "btOpenModel";
            this.btOpenModel.Size = new System.Drawing.Size(220, 42);
            this.btOpenModel.TabIndex = 92;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.DateExecDate);
            this.groupBox1.Controls.Add(this.chkDate);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 48);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // DateExecDate
            // 
            this.DateExecDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateExecDate.CustomFormat = "yyyy-MM-dd";
            this.DateExecDate.Enabled = false;
            this.DateExecDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateExecDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateExecDate.Location = new System.Drawing.Point(8, 16);
            this.DateExecDate.Name = "DateExecDate";
            this.DateExecDate.Size = new System.Drawing.Size(104, 23);
            this.DateExecDate.TabIndex = 11;
            this.DateExecDate.Value = new System.DateTime(2003, 9, 20, 0, 0, 0, 0);
            // 
            // chkDate
            // 
            this.chkDate.Location = new System.Drawing.Point(8, 0);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(80, 16);
            this.chkDate.TabIndex = 10;
            this.chkDate.Text = "选择日期";
            this.chkDate.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.butdc);
            this.groupBox2.Controls.Add(this.cb临时账单);
            this.groupBox2.Controls.Add(this.cb长期医嘱仅药品);
            this.groupBox2.Controls.Add(this.cb长期账单);
            this.groupBox2.Controls.Add(this.cb临时医嘱);
            this.groupBox2.Controls.Add(this.cb长期医嘱);
            this.groupBox2.Controls.Add(this.cb选择医嘱和账单);
            this.groupBox2.Location = new System.Drawing.Point(136, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 48);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbfkfy);
            this.groupBox3.Controls.Add(this.rbsyyp);
            this.groupBox3.Controls.Add(this.rbkfy);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(134, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 38);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "药品";
            // 
            // rbfkfy
            // 
            this.rbfkfy.AutoSize = true;
            this.rbfkfy.Location = new System.Drawing.Point(118, 18);
            this.rbfkfy.Name = "rbfkfy";
            this.rbfkfy.Size = new System.Drawing.Size(71, 16);
            this.rbfkfy.TabIndex = 2;
            this.rbfkfy.TabStop = true;
            this.rbfkfy.Text = "非口服药";
            this.rbfkfy.UseVisualStyleBackColor = true;
            this.rbfkfy.CheckedChanged += new System.EventHandler(this.rbsyyp_CheckedChanged);
            // 
            // rbsyyp
            // 
            this.rbsyyp.AutoSize = true;
            this.rbsyyp.Location = new System.Drawing.Point(0, 16);
            this.rbsyyp.Name = "rbsyyp";
            this.rbsyyp.Size = new System.Drawing.Size(47, 16);
            this.rbsyyp.TabIndex = 1;
            this.rbsyyp.TabStop = true;
            this.rbsyyp.Text = "所有";
            this.rbsyyp.UseVisualStyleBackColor = true;
            this.rbsyyp.CheckedChanged += new System.EventHandler(this.rbsyyp_CheckedChanged);
            // 
            // rbkfy
            // 
            this.rbkfy.AutoSize = true;
            this.rbkfy.Location = new System.Drawing.Point(48, 17);
            this.rbkfy.Name = "rbkfy";
            this.rbkfy.Size = new System.Drawing.Size(71, 16);
            this.rbkfy.TabIndex = 0;
            this.rbkfy.TabStop = true;
            this.rbkfy.Text = "仅口服药";
            this.rbkfy.UseVisualStyleBackColor = true;
            this.rbkfy.CheckedChanged += new System.EventHandler(this.rbsyyp_CheckedChanged);
            // 
            // butdc
            // 
            this.butdc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdc.Location = new System.Drawing.Point(510, 15);
            this.butdc.Name = "butdc";
            this.butdc.Size = new System.Drawing.Size(74, 26);
            this.butdc.TabIndex = 19;
            this.butdc.Text = "导出EXCEL";
            this.butdc.UseVisualStyleBackColor = true;
            this.butdc.Click += new System.EventHandler(this.butdc_Click);
            // 
            // cb临时账单
            // 
            this.cb临时账单.Enabled = false;
            this.cb临时账单.Location = new System.Drawing.Point(449, 15);
            this.cb临时账单.Name = "cb临时账单";
            this.cb临时账单.Size = new System.Drawing.Size(53, 32);
            this.cb临时账单.TabIndex = 9;
            this.cb临时账单.Text = "临时账单";
            // 
            // cb长期医嘱仅药品
            // 
            this.cb长期医嘱仅药品.Enabled = false;
            this.cb长期医嘱仅药品.Location = new System.Drawing.Point(62, 16);
            this.cb长期医嘱仅药品.Name = "cb长期医嘱仅药品";
            this.cb长期医嘱仅药品.Size = new System.Drawing.Size(73, 31);
            this.cb长期医嘱仅药品.TabIndex = 10;
            this.cb长期医嘱仅药品.Text = "长期医嘱仅药品";
            this.cb长期医嘱仅药品.CheckedChanged += new System.EventHandler(this.cb长期医嘱仅药品_CheckedChanged);
            // 
            // cb长期账单
            // 
            this.cb长期账单.Enabled = false;
            this.cb长期账单.Location = new System.Drawing.Point(390, 15);
            this.cb长期账单.Name = "cb长期账单";
            this.cb长期账单.Size = new System.Drawing.Size(53, 33);
            this.cb长期账单.TabIndex = 8;
            this.cb长期账单.Text = "长期账单";
            // 
            // cb临时医嘱
            // 
            this.cb临时医嘱.Enabled = false;
            this.cb临时医嘱.Location = new System.Drawing.Point(332, 14);
            this.cb临时医嘱.Name = "cb临时医嘱";
            this.cb临时医嘱.Size = new System.Drawing.Size(51, 33);
            this.cb临时医嘱.TabIndex = 7;
            this.cb临时医嘱.Text = "临时医嘱";
            // 
            // cb长期医嘱
            // 
            this.cb长期医嘱.Enabled = false;
            this.cb长期医嘱.Location = new System.Drawing.Point(8, 16);
            this.cb长期医嘱.Name = "cb长期医嘱";
            this.cb长期医嘱.Size = new System.Drawing.Size(59, 31);
            this.cb长期医嘱.TabIndex = 6;
            this.cb长期医嘱.Text = "长期医嘱";
            this.cb长期医嘱.CheckedChanged += new System.EventHandler(this.cb长期医嘱_CheckedChanged);
            // 
            // cb选择医嘱和账单
            // 
            this.cb选择医嘱和账单.Location = new System.Drawing.Point(8, 0);
            this.cb选择医嘱和账单.Name = "cb选择医嘱和账单";
            this.cb选择医嘱和账单.Size = new System.Drawing.Size(120, 16);
            this.cb选择医嘱和账单.TabIndex = 5;
            this.cb选择医嘱和账单.Text = "选择医嘱和账单";
            this.cb选择医嘱和账单.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cb选择医嘱和账单.CheckedChanged += new System.EventHandler(this.cb选择医嘱和账单_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.Location = new System.Drawing.Point(595, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 20);
            this.button1.TabIndex = 90;
            this.button1.Text = "当天未执行";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmYZZX
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(960, 621);
            this.Controls.Add(this.panel1);
            this.Name = "frmYZZX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "医嘱发送";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmExecOrders_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmExecOrders_Load(object sender, System.EventArgs e)
        {
            this.DateExecDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);																		//服务器当前系统日期
            this.DateExecDate.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Date.AddDays(Convert.ToInt32((new SystemCfg(7006)).Config)).ToShortDateString() + " 23:59:59");					//系统日期    -最小
            System.TimeSpan diff = new System.TimeSpan(Convert.ToInt32((new SystemCfg(7007)).Config), 0, 0, 0);
            this.DateExecDate.MinDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Subtract(diff).ToShortDateString() + " 23:59:59");	    //系统日期-Static_Exec_MaxDays -最大

            //查出本科室的病人信息
            //暂时屏蔽有无床位费判断 Modify By Tany 2004-10-20
            string[] GrdMappingName1 ={ "选", "床号", "住院号", "姓名", "费用类型", "性别", "年龄", "所属科室", "无床位费", "有新开医嘱", "有新停医嘱", "最近执行日期", "担保金额", "余额", "inpatient_id", "baby_id", "dept_id", "flag", "本次费用预算", "余额预算" };
            int[] GrdWidth1 ={ 2, 5, 9, 10, 8, 4, 4, 14, 0, 0, 0, 26, 12, 12, 0, 0, 0, 0, 12, 12, 0 };
            int[] Alignment1 ={ 0, 0, 0, 0, 1, 1, 2, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);

            this.Show_Data();
        }

        private void Show_Data()
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            //update pengyang 2015-7-31  dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id,-1)  余额
            MethodInvoker mi = new MethodInvoker(delegate()
            {
                string sSql = @"select 床号,姓名,住院号,JSFS_NAME as 费用类型,性别,年龄,所属科室,DBJE 担保金额," +
                    "       '' 余额,'' as 无床位费,'' as 有新开医嘱,'' as 有新停医嘱," +
                    "		dbo.FUN_ZY_SEEKLASTEXECDATE(a.inpatient_id,a.baby_id) 最近执行日期, " +
                    "       a.INPATIENT_ID,a.Baby_ID,dept_id,flag,'' 本次费用预算,'' 余额预算,'' 颜色  " +
                    "       FROM ( " +
                    "			SELECT BED_NO 床号,NAME 姓名,INPATIENT_NO 住院号,SEX_NAME 性别,age 年龄,CUR_DEPT_NAME 所属科室,INPATIENT_ID,Baby_ID,dept_id,JSFS_NAME,YBYE,DBJE,FLAG " +
                    "            from vi_zy_vInpatient_Bed (nolock) " +
                    "          WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "') a " +
                    " order by case when isnumeric(床号)=1 and SUBSTRING (床号 ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',床号)>0 then 2 when SUBSTRING (床号 ,0,2)='+' then 3  else  4   end ,case when isnumeric(床号)=1 then cast(床号 as int) else 999999 end,床号,a.Baby_ID ";//Modify By Tany 2015-02-09 排完再按床号

                if (myDataGrid1.InvokeRequired)
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        myFunc.ShowGrid(1, sSql, this.myDataGrid1);
                    }));
                else
                    myFunc.ShowGrid(1, sSql, this.myDataGrid1);
                //add by zouchihua 2013-1-14 增加颜色
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                DateTime dt = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                if (cfg7052.Config.Trim() == "1")
                    dt = dt.AddDays(1);

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (tb.Rows[i]["最近执行日期"].ToString().Trim() != "")
                    {
                        if (Convert.ToDateTime(dt.ToShortDateString()) <= Convert.ToDateTime(Convert.ToDateTime(tb.Rows[i]["最近执行日期"].ToString()).ToShortDateString()))
                        {
                            tb.Rows[i]["颜色"] = "LightGreen";
                        }
                    }
                }
            });
            mi.BeginInvoke(null, null);
            Cursor.Current = Cursors.Default;
        }


        private void myDataGrid1_Click(object sender, System.EventArgs e)
        {
            //控制BOOL列
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0 && nrow > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            //非"选"字段
            if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "选") return;
            if (nrow > myTb.Rows.Count - 1) return;


            bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["选"] = isResult;

            this.myDataGrid1.DataSource = myTb;

        }

        private void bt全选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "1") continue;
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["选"] = true;
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void bt反选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "1") continue;
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
            }
            this.myDataGrid1.DataSource = myTb;
        }


        private void cb选择医嘱和账单_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.cb选择医嘱和账单.Checked == false)
            {
                //发送所有医嘱
                this.cb长期医嘱.Checked = true;
                this.cb临时医嘱.Checked = true;
                this.cb长期账单.Checked = true;
                this.cb临时账单.Checked = true;
                this.cb长期医嘱仅药品.Checked = false;

                this.cb长期医嘱.Enabled = false;
                this.cb临时医嘱.Enabled = false;
                this.cb长期账单.Enabled = false;
                this.cb临时账单.Enabled = false;
                this.cb长期医嘱仅药品.Enabled = false;
                this.groupBox3.Enabled = false;
                //this.groupBox1.Enabled=true;
            }
            else
            {
                this.cb长期医嘱.Checked = true;
                this.cb临时医嘱.Checked = true;
                this.cb长期账单.Checked = true;
                this.cb临时账单.Checked = true;
                this.cb长期医嘱仅药品.Checked = false;

                this.cb长期医嘱.Enabled = true;
                this.cb临时医嘱.Enabled = true;
                this.cb长期账单.Enabled = true;
                this.cb临时账单.Enabled = true;
                this.cb长期医嘱仅药品.Enabled = true;
                //this.groupBox3.Enabled = true;
                //this.DateExecDate.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);		
                //this.groupBox1.Enabled=false;
            }

        }

        //新版本医嘱执行，将事务最小化
        //Modify By Tany 2005-07-14
        private void bt执行_Click(object sender, System.EventArgs e)
        {
            int i = 0, iSelectRows = 0;
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            bool isHSZ = false;
            string IsQfMsg = "";
            string IsErrMsg = "";

            if (this.cb选择医嘱和账单.Checked && this.cb长期医嘱.Checked == false && this.cb临时医嘱.Checked == false && this.cb长期账单.Checked == false && this.cb临时账单.Checked == false && this.cb长期医嘱仅药品.Checked == false)
            {
                MessageBox.Show(this, "对不起，没有选择医嘱或账单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkDate.Checked)
            {
                if (DateExecDate.Value.Date > DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Date)
                {
                    if (cb选择医嘱和账单.Checked == false)
                    {
                        MessageBox.Show(this, "预执行医嘱只能选择长期医嘱或账单，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cb选择医嘱和账单.Checked = true;
                        cb长期医嘱.Checked = false;
                        cb临时医嘱.Checked = false;
                        cb长期账单.Checked = false;
                        cb临时账单.Checked = false;
                        cb长期医嘱仅药品.Checked = true;
                        return;
                    }
                    else
                    {
                        if (cb临时医嘱.Checked == true || cb临时账单.Checked == true)//cb长期医嘱.Checked==true || cb长期账单.Checked==true || 
                        {
                            MessageBox.Show(this, "预执行医嘱只能选择长期医嘱或账单，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cb长期医嘱.Checked = false;
                            cb临时医嘱.Checked = false;
                            cb长期账单.Checked = false;
                            cb临时账单.Checked = false;
                            cb长期医嘱仅药品.Checked = true;
                            return;
                        }
                    }
                }
            }
            //add by zouchihua 2013-3-15
            ArrayList row = new ArrayList();
            string ss = "";
            string ss7146 = new SystemCfg(7146).Config.Trim();
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    iSelectRows += 1;
                    if (ss7146.Trim() == "1" && Convert.ToDecimal(Convertor.IsNull(myTb.Rows[i]["余额"], "0")) <= 0)
                    {
                        row.Add(i);
                        ss += myTb.Rows[i]["姓名"].ToString() + " , ";
                    }
                }
            }
            if (row.Count > 0)
            {
                if (MessageBox.Show(ss + "\n 费用余额已经小于0，是否继续执行这些病人医嘱？\n",
                       "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    for (int x = 0; x < row.Count; x++)
                    {
                        myTb.Rows[int.Parse(row[x].ToString())]["选"] = false;
                    }
                }
            }

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.cb选择医嘱和账单.Checked && (this.cb长期医嘱.Checked == false || this.cb临时账单.Checked == false || this.cb长期账单.Checked == false || this.cb临时账单.Checked == false))
            {
                if (MessageBox.Show(this, "确认不是执行所有医嘱和账单吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
                isHSZ = f1.isHSZ;
                f1.Close();
            }

            int iSelect0 = this.cb长期医嘱.Checked ? 0 : 2;
            int iSelect1 = this.cb临时医嘱.Checked ? 0 : 2;
            int iSelect2 = this.cb长期账单.Checked ? 0 : 2;
            int iSelect3 = this.cb临时账单.Checked ? 0 : 2;
            int iSelect4 = this.cb长期医嘱仅药品.Checked ? 3 : 2;

            //发送
            Cursor.Current = PubStaticFun.WaitCursor();
            System.DateTime BookDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            //如果选择日期发送，选择日期+服务器时间作为时间挫 Modify By Tany at 2004-10-08
            System.DateTime ExecDate = chkDate.Checked ? Convert.ToDateTime(DateExecDate.Value.ToShortDateString() + " " + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToLongTimeString()) : DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.progressBar2.Maximum = iSelectRows + 1;
            this.progressBar2.Value = 0;
            this.progressBar1.Value = 0;

            //Modify by jchl 2016-12-28-----------------------------------------
            DateTime serDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//PubStaticFun.GetDateFromGuid(PubStaticFun.NewGuid());
            int ExecYear = ExecDate.Year;
            int ServerYear = serDate.Year;
            if (ServerYear == 2016 && ExecYear == 2017)
            {
                if (MessageBox.Show("因为年底大调价，根据医院的统一部署安排，只能将医嘱发送至2016.12.31日，是否继续？\n",
                    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }

            DateTime dtMinFee = DateTime.Parse("2016-12-31 23:55:00");
            DateTime dtMaxFee = DateTime.Parse("2017-01-01 00:20:00");
            if (serDate >= dtMinFee && serDate <= dtMaxFee)
            {
                MessageBox.Show("因为年底大调价，根据医院的统一部署安排，12月31日 23:55以后 至 次日1月1日 00:20 为调价期间，所有病人不允许发送医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dtMin = DateTime.Parse("2016-12-31 18:00:00");
            DateTime dtMax = DateTime.Parse("2017-01-01 00:10:00");
            if (serDate >= dtMin && serDate <= dtMax)
            {
                MessageBox.Show("因为年底大调价，根据医院的统一部署安排，2016.12.31 18点 至 次日0:10分 医保病人不允许发送医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //------------------------------------------------------------------


            bool _qfExeCurDeptOrder = false;//欠费是否能够发送本科室医嘱

            //			//生成数据访问对象
            //			RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
            //			database.Initialize("");
            //			database.Open();

            bool _isYS = false;//是否预算

            //医嘱发送控制欠费是否强制包括预算费用
            if ((new SystemCfg(7040)).Config == "是")
            {
                _isYS = true;
                bt预算_Click(sender, e);
            }

            int dept_lock = InstanceForm.BCurrentDept.DeptId;
            int emp_lock = InstanceForm.BCurrentUser.EmployeeId;
            string mac_lock = PubStaticFun.GetIPAddress();
            try
            {
                //Modify By jchl  增加锁定记录表，避免医嘱执行时重复执行同一医嘱
                DataTable tb = new DataTable();
                string sql = "select * from ZY_ORDEREXEC_LOCK_dept(nolock) where dept_id=" + dept_lock;
                tb = InstanceForm.BDatabase.GetDataTable(sql);

                //如果没有找到记录，则插入一条新记录，并直接锁定
                if (tb == null || tb.Rows.Count == 0)
                {
                    sql = "insert into ZY_ORDEREXEC_LOCK_dept(dept_id,emp_id,mac,lock_bit) values(" + dept_lock + "," + emp_lock + ",'" + mac_lock + "',1)";
                    InstanceForm.BDatabase.DoCommand(sql);
                }
                else
                {
                    //如果已经被锁定，则退出
                    if (Convert.ToInt32(tb.Rows[0]["lock_bit"]) == 1)
                    {
                        MessageBox.Show("工号：" + tb.Rows[0]["emp_id"].ToString() + "正在执行 " + InstanceForm.BCurrentDept.DeptName + " 医嘱！  \r一台电脑【执行医嘱】速度更快,请稍后！", "提示");
                        return;
                    }
                    else
                    {
                        //sql = "select * from zy_orderexec_lock(nolock) where inpatient_id='" + BinID + "' and baby_id=" + BabyID + " and group_id=" + GroupID;
                        //DataTable  tbtemp = database.GetDataTable(sql);

                        //如果没有被锁，则上锁
                        int iLock = InstanceForm.BDatabase.DoCommand("update ZY_ORDEREXEC_LOCK_dept set lock_bit=1 where dept_id=" + dept_lock);
                        // 如果没有更新到lock_bit=0的行，说明已经上锁了 ，必须返回
                        if (iLock == 0)
                        {
                            MessageBox.Show("请重试执行医嘱", "提示");
                            return;
                        }
                    }
                }
                if (tb == null || tb.Rows.Count == 0)
                {
                    // 再次判断   如果大于两条则自动删除一条，并且返回
                    string sqlLock = "select * from ZY_ORDEREXEC_LOCK_dept(nolock) where dept_id=" + dept_lock;
                    DataTable tb1 = InstanceForm.BDatabase.GetDataTable(sqlLock);
                    if (tb1.Rows.Count > 1)
                    {
                        sqlLock = "delete from ZY_ORDEREXEC_LOCK_dept where id=" + tb1.Rows[0]["id"].ToString() + " ";
                        InstanceForm.BDatabase.DoCommand(sqlLock);
                        MessageBox.Show("请重试执行医嘱", "提示");
                        return;
                    }
                }

                //执行医嘱
                //Add BY tany 2010-11-27
                //7072病人入院？小时后控制欠费（0=立即控制）
                int _hour = Convert.ToInt32(new SystemCfg(7072).Config);
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["inpatient_id"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                    {
                        //Modify by jchl 2016-12-28
                        if (myTb.Rows[i]["费用类型"].ToString().Trim() == "医保")
                        {
                            if (serDate >= dtMin && serDate <= dtMax)
                            {
                                continue;
                            }
                        }

                        //add by zouchihua 2013-4-22 防止只发送口服药时的错误
                        iSelect4 = this.cb长期医嘱仅药品.Checked ? 3 : 2;
                        _qfExeCurDeptOrder = false;

                        int _flag = 0;
                        //如果允许出院病人欠费执行医嘱，才判断病人当前的状态，要不都默认为0
                        if ((new SystemCfg(7042)).Config == "是")
                        {
                            _flag = Convert.ToInt32(myTb.Rows[i]["flag"]);
                        }
                        //出院及死亡病人判断 Modify By Tany 2007-12-05
                        if ((new SystemCfg(7001)).Config == "是" && _flag != 4)
                        {
                            if (Convert.ToInt32(myTb.Rows[i]["Baby_ID"]) == 0
                                || (Convert.ToInt32(myTb.Rows[i]["Baby_ID"]) != 0 && (new SystemCfg(7002)).Config == "是"))
                            {
                                decimal _ye = 0;
                                decimal _ysfy = Convert.ToDecimal(myTb.Rows[i]["本次费用预算"].ToString().Trim() == "" ? "0" : myTb.Rows[i]["本次费用预算"].ToString().Trim());

                                //医嘱发送控制欠费是否强制包括预算费用
                                if (_isYS)
                                {
                                    _ye = Convert.ToDecimal(myTb.Rows[i]["余额"].ToString().Trim() == "" ? "0" : myTb.Rows[i]["余额"].ToString().Trim()) - _ysfy;
                                }
                                else
                                {
                                    _ye = Convert.ToDecimal(myTb.Rows[i]["余额"].ToString().Trim() == "" ? "0" : myTb.Rows[i]["余额"].ToString().Trim());
                                }
                                //Modify By Tany 2010-06-18 如果是医保病人，余额=预交金-总费用*费用比例
                                if (myTb.Rows[i]["费用类型"].ToString().Trim() == "医保")
                                {
                                    decimal fee = 0;
                                    decimal yjj = 0;
                                    if (cfg7186.Config.Trim() == "0")
                                    {
                                        //首先判断费用比例是不是小于1，如果等于1，则不需要计算
                                        decimal bl = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select b.yjj_bl from zy_inpatient a left join jc_yblx b on a.yblx=b.id where a.dischargetype=1 and a.inpatient_id='" + myTb.Rows[i]["inpatient_id"].ToString().Trim() + "'"), "1"));
                                        //Modify By Tany 2010-08-07 比例=0的时候相当于不控制欠费
                                        if (bl >= 0 && bl < 1)
                                        {

                                            TszyHIS.Inpatient inpatient = new TszyHIS.Inpatient(new Guid(myTb.Rows[i]["inpatient_id"].ToString()));
                                            fee = inpatient.GetFee();
                                            yjj = inpatient.GetDeposits();

                                            if (_isYS)
                                            {
                                                _ye = yjj - (fee * bl) - (_ysfy * bl);
                                            }
                                            else
                                            {
                                                _ye = yjj - (fee * bl);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        #region  add by zouchihua 2014-3-10按照医保试算进行控制
                                        string ybfy = @"select isnull(SUM(XJZF),0) fee from 
                                (
                                select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id='" + myTb.Rows[i]["INPATIENT_ID"].ToString() + @"'  order by YBJS_DATE desc
                                 union all
                                select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and DISCHARGE_BIT=0 and inpatient_id='" + myTb.Rows[i]["INPATIENT_ID"].ToString() + @"'
                                ) aa
                                ";
                                        DataTable tbybfy = InstanceForm.BDatabase.GetDataTable(ybfy);
                                        if (tbybfy.Rows.Count > 0)
                                        {
                                            fee = decimal.Parse(tbybfy.Rows[0]["fee"].ToString());
                                        }
                                        if (_isYS)
                                        {
                                            _ye = yjj - (fee) - (_ysfy);
                                        }
                                        else
                                        {
                                            _ye = yjj - (fee);
                                        }
                                        #endregion
                                    }
                                }
                                //判断病人的余额
                                decimal zdje = myFunc.GetPatMinExecYE(new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()));
                                bool zgflag = true;
                                #region 对职工单位单独处理
                                if (new SystemCfg(7204).Config == "1")
                                {
                                    decimal zgje = 0;
                                    string iszgsql = @"select * from ZY_INPATIENT_SUPPLY where PATIENTTYPE=1 and CHARGETYPE=1 and INPATIENT_ID='" + myTb.Rows[i]["INPATIENT_ID"].ToString() + "'";
                                    DataTable mydtzg = FrmMdiMain.Database.GetDataTable(iszgsql);
                                    if (mydtzg != null && mydtzg.Rows.Count > 0)
                                    {
                                        int _hour1 = Convert.ToInt32(new SystemCfg(7072).Config);
                                        DateTime _rysj = Convert.ToDateTime(FrmMdiMain.Database.GetDataResult("select in_date from zy_inpatient where inpatient_id='" + myTb.Rows[i]["INPATIENT_ID"].ToString() + "'"));
                                        if (_rysj.AddHours(_hour1) <= ExecDate && _ye < zdje)
                                        {
                                            SystemCfg cfg7204 = new SystemCfg(7204);
                                            if (isHSZ == false || (new SystemCfg(7034)).Config == "否")//护士长是否能够欠费发送 Modify By Tany 2007-07-19
                                            {
                                                if ((new SystemCfg(7021)).Config == "是")
                                                {
                                                    _qfExeCurDeptOrder = true;
                                                    //MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " 床职工担保病人 " + patientInfo1.lbName.Text.Trim() + " 的余额为 " +
                                                    //    _ye.ToString().Trim() + " 元，" + ("最大担保金额为 " + zgje.ToString() + " 元，") + "请通知相关人员进行审核,目前只能发送该病人本科执行的医嘱！", "提示",
                                                    //    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                                if (_qfExeCurDeptOrder)
                                                {
                                                    IsQfMsg += " ⊙ " + myTb.Rows[i]["床号"].ToString().Trim() + " 床病人 " + myTb.Rows[i]["姓名"].ToString().Trim() + " ，余额为 " +
                                                        myTb.Rows[i]["余额"].ToString().Trim() + " 元" + (_ysfy == 0 ? "" : ("，本次预算费用为 " + _ysfy + " 元")) + "\n";
                                                }
                                                else
                                                {
                                                    IsQfMsg += " ⊙ " + myTb.Rows[i]["床号"].ToString().Trim() + " 床病人 " + myTb.Rows[i]["姓名"].ToString().Trim() + " ，余额为 " +
                                                        myTb.Rows[i]["余额"].ToString().Trim() + " 元" + (_ysfy == 0 ? "" : ("，本次预算费用为 " + _ysfy + " 元")) + "\n";
                                                    continue;
                                                }
                                            }
                                        }
                                        zgflag = false;
                                    }

                                }
                                #endregion
                                decimal kyqfe = zdje;// myFunc.GetPatMinExecYE(new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()));
                                //   MessageBox.Show(kyqfe.ToString() +"   ***  "+ myTb.Rows[i]["INPATIENT_ID"].ToString().ToString());
                                #region //判断病人的余额
                                if (_ye < kyqfe && zgflag)
                                {
                                    //Add By Tany 2010-11-27 增加对病人入院时间的判断
                                    DateTime _rysj = Convert.ToDateTime(FrmMdiMain.Database.GetDataResult("select in_date from zy_inpatient where inpatient_id='" + new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()) + "'"));
                                    if (_rysj.AddHours(_hour) <= ExecDate)
                                    {
                                        if (isHSZ == false || (new SystemCfg(7034)).Config == "否")//护士长是否能够欠费发送 Modify By Tany 2007-07-19
                                        {
                                            if ((new SystemCfg(7021)).Config == "是")
                                            {
                                                _qfExeCurDeptOrder = true;
                                            }

                                            if (_qfExeCurDeptOrder)
                                            {
                                                IsQfMsg += " ⊙ " + myTb.Rows[i]["床号"].ToString().Trim() + " 床病人 " + myTb.Rows[i]["姓名"].ToString().Trim() + " ，余额为 " +
                                                    myTb.Rows[i]["余额"].ToString().Trim() + " 元" + (_ysfy == 0 ? "" : ("，本次预算费用为 " + _ysfy + " 元")) + ",最大欠费额度为" + kyqfe.ToString() + "\n";
                                            }
                                            else
                                            {
                                                IsQfMsg += " ⊙ " + myTb.Rows[i]["床号"].ToString().Trim() + " 床病人 " + myTb.Rows[i]["姓名"].ToString().Trim() + " ，余额为 " +
                                                    myTb.Rows[i]["余额"].ToString().Trim() + " 元" + (_ysfy == 0 ? "" : ("，本次预算费用为 " + _ysfy + " 元")) + ",最大欠费额度为" + kyqfe.ToString() + "\n";
                                                continue;
                                            }
                                        }
                                    }
                                }
                                #endregion


                            }
                        }

                        ClassStatic.Current_DeptID = Convert.ToInt64(myTb.Rows[i]["dept_id"]);
                        if (this.cb选择医嘱和账单.Checked == false)
                        {
                            //全部发送
                            myFunc.ExecOrdersWithData(this.myDataGrid1, 9, 0, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate, _qfExeCurDeptOrder, FrmMdiMain.Jgbm);
                            //add by yaokx 2014-03-12  开出院医嘱、转科医嘱时自动冲最后一天的床位费用

                            #region 开出院医嘱时自动冲最后一天的床位费用
                            string cfg7187 = new SystemCfg(7187).Config;
                            if (cfg7187 != "")
                            {
                                DateTime dTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//取数据库时间

                                myFunc.GetCZcy(new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), cfg7187, dTime);

                            }
                            #endregion
                        }
                        else
                        {
                            //发送长期医嘱
                            myFunc.ExecOrdersWithData(this.myDataGrid1, 0, iSelect0, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate, _qfExeCurDeptOrder, FrmMdiMain.Jgbm);
                            //Modify by zouchihua 2012-01-13 所有药品3，5仅口服药，6非口服药品
                            if (iSelect4 == 3)//选中
                            {
                                if (rbkfy.Checked)
                                    iSelect4 = 5;
                                if (rbfkfy.Checked)
                                    iSelect4 = 6;
                                //发送长期医嘱仅药品
                                myFunc.ExecOrdersWithData(this.myDataGrid1, 0, iSelect4, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate, _qfExeCurDeptOrder, FrmMdiMain.Jgbm);
                            }
                            //发送临时医嘱
                            myFunc.ExecOrdersWithData(this.myDataGrid1, 1, iSelect1, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate, _qfExeCurDeptOrder, FrmMdiMain.Jgbm);

                            //发送长期账单
                            myFunc.ExecOrdersWithData(this.myDataGrid1, 2, iSelect2, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate, _qfExeCurDeptOrder, FrmMdiMain.Jgbm);

                            //发送临时账单
                            myFunc.ExecOrdersWithData(this.myDataGrid1, 3, iSelect3, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate, _qfExeCurDeptOrder, FrmMdiMain.Jgbm);
                        }

                        this.progressBar2.Value += 1;
                    }
                }

                //			database.Close();

                //医嘱发送（冲账）是否自动生成药品统领信息
                //Modify By Tany 2005-11-05
                if ((new SystemCfg(7022)).Config == "是")
                {
                    string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                        " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                    DataTable yfTb = InstanceForm.BDatabase.GetDataTable(yfSql);

                    for (int n = 0; n < yfTb.Rows.Count; n++)
                    {
                        //新统领药品（领药）消息 Modify By Tany 2005-09-13
                        myFunc.SendYPFY(0, 0, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, BookDate, Convert.ToInt64(yfTb.Rows[n]["execdept_id"]), FrmMdiMain.Jgbm);
                        //新统领药品（领药） Add by zouchihua 2012-4-22
                        myFunc.SendYPFY(2, 0, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, BookDate, Convert.ToInt64(yfTb.Rows[n]["execdept_id"]), FrmMdiMain.Jgbm);
                    }
                }

                //Modify By Tany 2009-08-03
                //冲账和发送分开
                if ((new SystemCfg(7047)).Config == "是")
                {
                    string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                        " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                    DataTable yfTb = InstanceForm.BDatabase.GetDataTable(yfSql);

                    for (int n = 0; n < yfTb.Rows.Count; n++)
                    {
                        //新统领药品（退药）消息 Modify By Tany 2005-09-13
                        myFunc.SendYPFY(0, 1, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[n]["execdept_id"]), FrmMdiMain.Jgbm);
                        //新统领药品（退药） Add by zouchihua 2012-4-22
                        myFunc.SendYPFY(2, 1, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[n]["execdept_id"]), FrmMdiMain.Jgbm);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                //执行完毕解锁
                InstanceForm.BDatabase.DoCommand("update ZY_ORDEREXEC_LOCK_dept set lock_bit=0 where dept_id=" + dept_lock);
            }

            Cursor.Current = Cursors.Default;
            this.progressBar2.Value = 0;

            if ((new SystemCfg(7021)).Config == "是")
            {
                _qfExeCurDeptOrder = true;
            }

            if (IsQfMsg.Trim() != "")
            {
                if (_qfExeCurDeptOrder)
                {
                    MessageBox.Show("以下病人的余额不足，将只能发送以下病人执行科室为本科的医嘱！\n欠费病人包括：\n" + IsQfMsg, "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("以下病人的余额不足，将不能发送以下病人的医嘱！\n欠费病人包括：\n" + IsQfMsg, "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            #region"pivas未审方是否允许执行药品医嘱  add by jchl"

            if (cfg7605.Trim().Equals("0"))
            {
                row = new ArrayList();
                ss = "";

                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["选"].ToString() == "True")
                    {
                        if (!isPvsChkExe(myTb.Rows[i]["inpatient_id"].ToString().Trim(), myTb.Rows[i]["baby_id"].ToString().Trim(), cfg7602.Trim()))
                        {
                            row.Add(i);
                            ss += myTb.Rows[i]["姓名"].ToString() + " , ";
                        }
                    }
                }
                if (row.Count > 0)
                {
                    MessageBox.Show(ss + "\n 有未审核的pivas医嘱未执行 \n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            #endregion

            this.Show_Data();

            //处理出错病人信息，将病人打上钩
            if (IsErrMsg.Trim() != "")
            {
                bool IsErr = false;
                DataTable binTb = (DataTable)this.myDataGrid1.DataSource;

                if (binTb.Rows.Count == 0 || binTb == null)
                    return;

                for (int j = 0; j < binTb.Rows.Count; j++)
                {
                    if (IsErrMsg.Trim().IndexOf(binTb.Rows[j]["INPATIENT_ID"].ToString().Trim()) > -1)
                    {
                        binTb.Rows[j]["选"] = true;
                        IsErr = true;
                    }
                }

                if (IsErr)
                {
                    MessageBox.Show("以上选中病人的医嘱在执行时出现错误，请重新执行选中病人的医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("全部执行完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //刷新 
            this.Show_Data();
        }

        #region 老版本执行
        /*
		private void bt执行_Click(object sender, System.EventArgs e)
		{
			if(ClassStatic.Static_isCZ==false)
			{
				MessageBox.Show("对不起，你没有操作的权限！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			int i=0,iSelectRows=0;
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			bool isHSZ=false;
			string IsQfMsg="";

			if (this.cb选择医嘱和账单.Checked && this.cb长期医嘱.Checked==false && this.cb临时医嘱.Checked==false && this.cb长期账单.Checked==false && this.cb临时账单.Checked==false && this.cb长期医嘱仅药品.Checked==false)
			{
				MessageBox.Show(this,"对不起，没有选择医嘱或账单！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
				return;
			}

			for(i=0;i<=myTb.Rows.Count-1;i++)
			{
				if (myTb.Rows[i]["选"].ToString()=="True")
				{				
					iSelectRows+=1;				
				}
			}
            
			if (iSelectRows==0)
			{
				MessageBox.Show(this,"对不起，没有选择病人！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
				return;
			}

			if (this.cb选择医嘱和账单.Checked && (this.cb长期医嘱.Checked==false || this.cb临时账单.Checked==false || this.cb长期账单.Checked==false || this.cb临时账单.Checked==false ))
			{
				if (MessageBox.Show(this, "确认不是执行所有医嘱和账单吗？", "确认", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) 	return;			
			}
			

			frmInPassword f1=new frmInPassword();
			f1.ShowDialog();
			if (f1.isLogin==false) return;
			isHSZ=f1.isHSZ;
			f1.Close();

			int iSelect0=this.cb长期医嘱.Checked?0:2;
			int iSelect1=this.cb临时医嘱.Checked?0:2;
			int iSelect2=this.cb长期账单.Checked?0:2;
			int iSelect3=this.cb临时账单.Checked?0:2;
			int iSelect4=this.cb长期医嘱仅药品.Checked?3:2;

			//发送
			Cursor.Current=new Cursor(ClassStatic.Static_cur); 
			System.DateTime BookDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			//如果选择日期发送，选择日期+服务器时间作为时间挫 Modify By Tany at 2004-10-08
			System.DateTime ExecDate=chkDate.Checked?Convert.ToDateTime(DateExecDate.Value.ToShortDateString()+" "+DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToLongTimeString()):DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);			
			this.progressBar2.Maximum=iSelectRows+1;
			this.progressBar2.Value=0;

			//定义事务
			OleDbCommand myCmd = new OleDbCommand();
			myCmd.Connection=new OleDbConnection(DatabaseAccess.GetConnectionString(DatabaseType.IbmDb2ZY));
			OleDbTransaction myTrans;
			
				//执行医嘱
			for(i=0;i<=myTb.Rows.Count-1;i++)
			{				
				if(myTb.Rows[i]["inpatient_id"].ToString().Trim()!="" && myTb.Rows[i]["选"].ToString()=="True")
				{
					if(myFunc.GetConfig("cname","医嘱发送时是否使用欠费管理",myCmd)=="是")
					{
						if(Convert.ToInt32(myTb.Rows[i]["Baby_ID"])==0 
							|| (Convert.ToInt32(myTb.Rows[i]["Baby_ID"])!=0 && myFunc.GetConfig("cname","婴儿医嘱发送时是否使用欠费管理",myCmd)=="是"))
						{
							//判断病人的余额
							if(Convert.ToDecimal(myTb.Rows[i]["余额"].ToString().Trim()==""?"0":myTb.Rows[i]["余额"].ToString().Trim())<myFunc.GetMinExecYE(Convert.ToInt32(myTb.Rows[i]["dept_id"])))
							{
								if(isHSZ==false)
								{
									IsQfMsg+=" ⊙ "+myTb.Rows[i]["床号"].ToString().Trim()+" 床病人 "+myTb.Rows[i]["姓名"].ToString().Trim()+" ，余额为 "+
										myTb.Rows[i]["余额"].ToString().Trim() +" 元\n";
									continue;
								}
							}
						}
					}

					//开始事务
					myTrans = new OleDbConnection(DatabaseAccess.GetConnectionString(DatabaseType.IbmDb2ZY)).BeginTransaction();
					myCmd.Transaction=myTrans;
					try
					{
						ClassStatic.Current_DeptID=myTb.Rows[i]["dept_id"].ToString().Trim();
						if (this.cb选择医嘱和账单.Checked==false) 
						{
							//全部发送
							myFunc.ExecOrdersWithDate(this.myDataGrid1,9,0,this.progressBar1,Convert.ToInt32(myTb.Rows[i]["INPATIENT_ID"]),Convert.ToInt32(myTb.Rows[i]["Baby_ID"]),BookDate,ExecDate,myCmd);
						}
						else
						{
							//发送长期医嘱
							myFunc.ExecOrdersWithDate(this.myDataGrid1,0,iSelect0,this.progressBar1,Convert.ToInt32(myTb.Rows[i]["INPATIENT_ID"]),Convert.ToInt32(myTb.Rows[i]["Baby_ID"]),BookDate,ExecDate,myCmd);
				
							//发送长期医嘱仅药品
							myFunc.ExecOrdersWithDate(this.myDataGrid1,0,iSelect4,this.progressBar1,Convert.ToInt32(myTb.Rows[i]["INPATIENT_ID"]),Convert.ToInt32(myTb.Rows[i]["Baby_ID"]),BookDate,ExecDate,myCmd);

							//发送临时医嘱
							myFunc.ExecOrdersWithDate(this.myDataGrid1,1,iSelect1,this.progressBar1,Convert.ToInt32(myTb.Rows[i]["INPATIENT_ID"]),Convert.ToInt32(myTb.Rows[i]["Baby_ID"]),BookDate,ExecDate,myCmd);
				
							//发送长期账单
							myFunc.ExecOrdersWithDate(this.myDataGrid1,2,iSelect2,this.progressBar1,Convert.ToInt32(myTb.Rows[i]["INPATIENT_ID"]),Convert.ToInt32(myTb.Rows[i]["Baby_ID"]),BookDate,ExecDate,myCmd);
								
							//发送临时账单
							myFunc.ExecOrdersWithDate(this.myDataGrid1,3,iSelect3,this.progressBar1,Convert.ToInt32(myTb.Rows[i]["INPATIENT_ID"]),Convert.ToInt32(myTb.Rows[i]["Baby_ID"]),BookDate,ExecDate,myCmd);							
						}

						//药品消息 Modify By Tany 2004-11-09
						myFunc.SendYPFY("",InstanceForm.BCurrentDept.WardId,Convert.ToDecimal(myTb.Rows[i]["INPATIENT_ID"]),Convert.ToDecimal(myTb.Rows[i]["Baby_ID"]),InstanceForm.BCurrentUser.EmployeeId,BookDate,0,-1,myCmd);

						//提交
						myTrans.Commit();

						this.progressBar2.Value+=1;
					}
					catch(Exception err)
					{
						myTrans.Rollback();

						//写错误日志 Add By Tany 2005-01-12
						SystemLog _systemErrLog=new SystemLog(-1,_Dept.DeptID,InstanceForm.BCurrentUser.EmployeeId,"程序错误","执行医嘱错误："+err.Message+"  Source："+err.Source,DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase),1,"主机名："+System.Environment.MachineName,39);
						_systemErrLog.Save();
						_systemErrLog=null;

						MessageBox.Show("错误："+err.Message+"\n"+"Source："+err.Source+"\n执行数据已经回滚，请检查后重新执行！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
						progressBar1.Value=0;
						progressBar2.Value=0;
						this.Show_Date();
						return;
					}
				}
			}

			//开始事务
			myTrans = new OleDbConnection(DatabaseAccess.GetConnectionString(DatabaseType.IbmDb2ZY)).BeginTransaction();
			myCmd.Transaction=myTrans;
			try
			{
				//统领药品消息 Modify By Tany 2004-11-09
				myFunc.SendYPFY("",InstanceForm.BCurrentDept.WardId,0,0,InstanceForm.BCurrentUser.EmployeeId,BookDate,1,-1,myCmd);

				myTrans.Commit();
			}
			catch(Exception err)
			{
				myTrans.Rollback();

				//写错误日志 Add By Tany 2005-01-12
				SystemLog _systemErrLog=new SystemLog(-1,_Dept.DeptID,InstanceForm.BCurrentUser.EmployeeId,"程序错误","发送药品统领单错误："+err.Message+"  Source："+err.Source,DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase),1,"主机名："+System.Environment.MachineName,39);
				_systemErrLog.Save();
				_systemErrLog=null;

				MessageBox.Show("错误："+err.Message+"\n"+"Source："+err.Source+"\n统领数据已经回滚，请检查后重新执行！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				progressBar1.Value=0;
				progressBar2.Value=0;
				this.Show_Date();
				return;
			}
			
			Cursor.Current=Cursors.Default;	
			this.progressBar2.Value=0;
			if(IsQfMsg.Trim()!="")
			{
				MessageBox.Show("以下病人的余额不足，将不能发送以下病人的医嘱！如果需要发送，请使用护士长权限登陆！\n欠费病人包括：\n"+IsQfMsg,"提示",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
			MessageBox.Show("全部执行完成","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);

			

			this.Show_Date();			
		}
		*/
        #endregion

        private void chkDate_CheckedChanged(object sender, System.EventArgs e)
        {
            DateExecDate.Enabled = chkDate.Checked;
        }

        private void cb长期医嘱_CheckedChanged(object sender, System.EventArgs e)
        {
            if (cb长期医嘱.Checked) cb长期医嘱仅药品.Checked = false;
        }

        private void cb长期医嘱仅药品_CheckedChanged(object sender, System.EventArgs e)
        {
            if (cb长期医嘱仅药品.Checked)
            {
                cb长期医嘱.Checked = false;
                //add by zouchihua 2012-01-13 默认为所有药品
                this.groupBox3.Enabled = true;
                rbsyyp.Checked = true;
            }
            else
            {
                this.groupBox3.Enabled = false;
                this.rbfkfy.Checked = false;
                this.rbkfy.Checked = false;
                this.rbsyyp.Checked = false;
            }
        }

        private void bt退出_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void bt预算_Click(object sender, EventArgs e)
        {
            int i = 0, iSelectRows = 0;
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;

            if (this.cb选择医嘱和账单.Checked && this.cb长期医嘱.Checked == false && this.cb临时医嘱.Checked == false && this.cb长期账单.Checked == false && this.cb临时账单.Checked == false && this.cb长期医嘱仅药品.Checked == false)
            {
                MessageBox.Show(this, "对不起，没有选择医嘱或账单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    iSelectRows += 1;
                }
            }

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int iSelect0 = this.cb长期医嘱.Checked ? 0 : 2;
            int iSelect1 = this.cb临时医嘱.Checked ? 0 : 2;
            int iSelect2 = this.cb长期账单.Checked ? 0 : 2;
            int iSelect3 = this.cb临时账单.Checked ? 0 : 2;
            int iSelect4 = this.cb长期医嘱仅药品.Checked ? 3 : 2;

            //发送
            Cursor.Current = PubStaticFun.WaitCursor();
            System.DateTime BookDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            //如果选择日期发送，选择日期+服务器时间作为时间挫 Modify By Tany at 2004-10-08
            System.DateTime ExecDate = chkDate.Checked ? Convert.ToDateTime(DateExecDate.Value.ToShortDateString() + " " + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToLongTimeString()) : DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.progressBar2.Maximum = iSelectRows + 1;
            this.progressBar2.Value = 0;
            this.progressBar1.Value = 0;

            //执行医嘱
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["inpatient_id"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                {
                    decimal _orderfee = 0;
                    ClassStatic.Current_DeptID = Convert.ToInt64(myTb.Rows[i]["dept_id"]);
                    if (this.cb选择医嘱和账单.Checked == false)
                    {
                        //全部发送
                        _orderfee += myFunc.GetOrderFeeTotal(this.myDataGrid1, 9, 0, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate);
                    }
                    else
                    {
                        //发送长期医嘱
                        _orderfee += myFunc.GetOrderFeeTotal(this.myDataGrid1, 0, iSelect0, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate);

                        //发送长期医嘱仅药品
                        _orderfee += myFunc.GetOrderFeeTotal(this.myDataGrid1, 0, iSelect4, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate);

                        //发送临时医嘱
                        _orderfee += myFunc.GetOrderFeeTotal(this.myDataGrid1, 1, iSelect1, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate);

                        //发送长期账单
                        _orderfee += myFunc.GetOrderFeeTotal(this.myDataGrid1, 2, iSelect2, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate);

                        //发送临时账单
                        _orderfee += myFunc.GetOrderFeeTotal(this.myDataGrid1, 3, iSelect3, this.progressBar1, new Guid(myTb.Rows[i]["INPATIENT_ID"].ToString()), Convert.ToInt64(myTb.Rows[i]["Baby_ID"]), BookDate, ExecDate);
                    }
                    myTb.Rows[i]["本次费用预算"] = _orderfee.ToString();
                    myTb.Rows[i]["余额预算"] = Convert.ToString((myTb.Rows[i]["余额"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(myTb.Rows[i]["余额"])) - _orderfee);

                    this.progressBar2.Value += 1;
                }
                else
                {
                    myTb.Rows[i]["本次费用预算"] = "";
                    myTb.Rows[i]["余额预算"] = "";
                }
            }

            Cursor.Current = Cursors.Default;
            this.progressBar2.Value = 0;

            //MessageBox.Show("预算费用完毕！","通知",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void butdc_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                #region 简单打印

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                this.butdc.Enabled = false;

                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //查询条件
                string swhere = "日期: " + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + "    人数:" + tb.Rows.Count + " 人";


                //写入行头

                int SumRowCount = tb.Rows.Count;
                int SumColCount = 0;

                for (int j = 0; j < 7; j++)
                {
                    // if (this.myDataGrid1.TableStyles[0].GridColumnStyles[tb.Columns[j].ColumnName].Width > 0)
                    //{
                    SumColCount = SumColCount + 1;
                    myExcel.Cells[5, SumColCount] = tb.Columns[j].ColumnName;
                    //}

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //逐行写入数据，

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int ncol = 0;
                    for (int j = 0; j < 7; j++)
                    {
                        //   if (this.myDataGrid1.TableStyles[0].GridColumnStyles[tb.Columns[j].ColumnName].Width > 0)
                        // {
                        ncol = ncol + 1;
                        myExcel.Cells[6 + i, ncol] = "     " + tb.Rows[i][j].ToString().Trim();

                        //}
                    }
                }

                //设置报表表格为最适应宽度
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //加边框
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //报表名称
                string ss = "";
                myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + "当前在院病人";
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
                this.butdc.Enabled = true;

                #endregion
            }
            catch (System.Exception err)
            {
                this.butdc.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void rbsyyp_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
                this.cb长期医嘱仅药品.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["颜色"].ToString().Trim() == "")
                    myTb.Rows[i]["选"] = true;
                else
                    myTb.Rows[i]["选"] = false;
            }
        }

        /// <summary>
        /// pivas 是否审方
        /// </summary>
        private bool isPvsChkExe(string inpatid, string babyid, string mngType)
        {
            try
            {
                string sSql = string.Format(@"select count(1) as Num from ZY_ORDERRECORD t 
                                        where t.INPATIENT_ID='{0}' and BABY_ID='{1}' and t.DELETE_BIT=0 and t.STATUS_FLAG=2 and t.is_PvsChk=0
	                                        and (MNGTYPE={2} or ('{2}'='2' and MNGTYPE in (0,1))) and exists(select 1 from VI_pivas_Orderusage f where t.ORDER_USAGE=f.name) ",
                                            inpatid, babyid, mngType);

                string str = InstanceForm.BDatabase.GetDataResult(sSql).ToString().Trim();
                int iNum = int.Parse(str);

                //没有 需要却未审方 的医嘱
                if (iNum == 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
