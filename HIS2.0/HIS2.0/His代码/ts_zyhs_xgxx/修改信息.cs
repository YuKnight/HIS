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
using System.Net;
namespace ts_zyhs_xgxx
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class frmXGXX : System.Windows.Forms.Form
    {
        //自定义变量		
        private BaseFunc myFunc;
        private DataTable zdTb;
        private TextBox TBox = new TextBox();
        private string ryzd = "";
        private string cyzd = "";
        private string ryzddm = "";
        private string cyzddm = "";
        private bool isKeypress = false;

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbI3;
        private System.Windows.Forms.Button bt退出;
        private System.Windows.Forms.Button btUse;
        private System.Windows.Forms.Button button3;
        private DataGridEx GrdSel;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbI2;
        private System.Windows.Forms.RadioButton rbI1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel左;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle0;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private TrasenClasses.GeneralControls.DataGridEx myDataGrid2;
        private System.Windows.Forms.Panel panel1;
        private GroupBox gbCyzd;
        private GroupBox gbRyzd;
        private TextBox txtRyzd;
        private TextBox txtCyzd;
        private Button btXgryzd;
        private Button btXgcyzd;
        private DataGrid dgZd;
        private DataGridTableStyle dataGridTableStyle2;
        private DataGridTextBoxColumn dataGridTextBoxColumn1;
        private DataGridTextBoxColumn dataGridTextBoxColumn2;
        private DataGridTextBoxColumn dataGridTextBoxColumn3;
        private GroupBox groupBox4;
        private Button btnxg;
        private TextBox txtzyzd;
        private TextBox txtzx;
        private Label label3;
        private Label label2;
        private IContainer components;
        private SystemCfg cfg7166 = new SystemCfg(7166);

        public frmXGXX(string _formText)
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbI3 = new System.Windows.Forms.RadioButton();
            this.rbI2 = new System.Windows.Forms.RadioButton();
            this.rbI1 = new System.Windows.Forms.RadioButton();
            this.bt退出 = new System.Windows.Forms.Button();
            this.btUse = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dgZd = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb3 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtzx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnxg = new System.Windows.Forms.Button();
            this.txtzyzd = new System.Windows.Forms.TextBox();
            this.gbRyzd = new System.Windows.Forms.GroupBox();
            this.btXgryzd = new System.Windows.Forms.Button();
            this.txtRyzd = new System.Windows.Forms.TextBox();
            this.gbCyzd = new System.Windows.Forms.GroupBox();
            this.btXgcyzd = new System.Windows.Forms.Button();
            this.txtCyzd = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.GrdSel = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel左 = new System.Windows.Forms.Panel();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle0 = new System.Windows.Forms.DataGridTableStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgZd)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbRyzd.SuspendLayout();
            this.gbCyzd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).BeginInit();
            this.panel左.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbI3);
            this.groupBox3.Controls.Add(this.rbI2);
            this.groupBox3.Controls.Add(this.rbI1);
            this.groupBox3.Location = new System.Drawing.Point(8, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 59);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输入法";
            // 
            // rbI3
            // 
            this.rbI3.Location = new System.Drawing.Point(136, 16);
            this.rbI3.Name = "rbI3";
            this.rbI3.Size = new System.Drawing.Size(64, 32);
            this.rbI3.TabIndex = 59;
            this.rbI3.Text = "数字(&F&1&2)";
            this.rbI3.Click += new System.EventHandler(this.rbI1_Click);
            // 
            // rbI2
            // 
            this.rbI2.Location = new System.Drawing.Point(72, 16);
            this.rbI2.Name = "rbI2";
            this.rbI2.Size = new System.Drawing.Size(56, 32);
            this.rbI2.TabIndex = 58;
            this.rbI2.Text = "五笔(&F&1&1)";
            this.rbI2.Click += new System.EventHandler(this.rbI1_Click);
            // 
            // rbI1
            // 
            this.rbI1.Checked = true;
            this.rbI1.Location = new System.Drawing.Point(8, 16);
            this.rbI1.Name = "rbI1";
            this.rbI1.Size = new System.Drawing.Size(56, 32);
            this.rbI1.TabIndex = 57;
            this.rbI1.TabStop = true;
            this.rbI1.Text = "拼音(&F&1&0)";
            this.rbI1.Click += new System.EventHandler(this.rbI1_Click);
            // 
            // bt退出
            // 
            this.bt退出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt退出.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt退出.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt退出.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt退出.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt退出.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt退出.ImageIndex = 0;
            this.bt退出.Location = new System.Drawing.Point(128, 582);
            this.bt退出.Name = "bt退出";
            this.bt退出.Size = new System.Drawing.Size(72, 24);
            this.bt退出.TabIndex = 54;
            this.bt退出.Text = "退出(&E)";
            this.bt退出.UseVisualStyleBackColor = false;
            this.bt退出.Click += new System.EventHandler(this.bt退出_Click);
            // 
            // btUse
            // 
            this.btUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btUse.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUse.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btUse.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btUse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btUse.ImageIndex = 0;
            this.btUse.Location = new System.Drawing.Point(24, 582);
            this.btUse.Name = "btUse";
            this.btUse.Size = new System.Drawing.Size(72, 24);
            this.btUse.TabIndex = 53;
            this.btUse.Text = "修改(&X)";
            this.btUse.UseVisualStyleBackColor = false;
            this.btUse.Click += new System.EventHandler(this.btUse_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(8, 574);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(208, 40);
            this.button3.TabIndex = 55;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // dgZd
            // 
            this.dgZd.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgZd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgZd.CaptionBackColor = System.Drawing.SystemColors.Window;
            this.dgZd.CaptionVisible = false;
            this.dgZd.DataMember = "";
            this.dgZd.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgZd.Location = new System.Drawing.Point(6, 420);
            this.dgZd.Name = "dgZd";
            this.dgZd.RowHeaderWidth = 20;
            this.dgZd.Size = new System.Drawing.Size(327, 189);
            this.dgZd.TabIndex = 60;
            this.dgZd.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dgZd.Visible = false;
            this.dgZd.DoubleClick += new System.EventHandler(this.dgZd_DoubleClick);
            this.dgZd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgZd_KeyUp);
            this.dgZd.Click += new System.EventHandler(this.dgZd_Click);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dgZd;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "名称";
            this.dataGridTextBoxColumn1.MappingName = "name";
            this.dataGridTextBoxColumn1.Width = 220;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "icd";
            this.dataGridTextBoxColumn2.MappingName = "icd";
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "拼音码";
            this.dataGridTextBoxColumn3.MappingName = "拼音码";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // txtDoc
            // 
            this.txtDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDoc.BackColor = System.Drawing.Color.White;
            this.txtDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDoc.Location = new System.Drawing.Point(224, 16);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(386, 23);
            this.txtDoc.TabIndex = 1;
            this.txtDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDoc_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb3);
            this.groupBox2.Controls.Add(this.lb2);
            this.groupBox2.Controls.Add(this.lb1);
            this.groupBox2.Controls.Add(this.rb3);
            this.groupBox2.Controls.Add(this.rb2);
            this.groupBox2.Controls.Add(this.rb1);
            this.groupBox2.Location = new System.Drawing.Point(8, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 96);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择";
            // 
            // lb3
            // 
            this.lb3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb3.Location = new System.Drawing.Point(96, 68);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(96, 16);
            this.lb3.TabIndex = 6;
            // 
            // lb2
            // 
            this.lb2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb2.Location = new System.Drawing.Point(96, 44);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(96, 16);
            this.lb2.TabIndex = 5;
            // 
            // lb1
            // 
            this.lb1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb1.Location = new System.Drawing.Point(96, 20);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(96, 16);
            this.lb1.TabIndex = 4;
            // 
            // rb3
            // 
            this.rb3.Location = new System.Drawing.Point(8, 64);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(88, 24);
            this.rb3.TabIndex = 3;
            this.rb3.Text = "主治医生：";
            this.rb3.Click += new System.EventHandler(this.rb1_Click);
            // 
            // rb2
            // 
            this.rb2.Checked = true;
            this.rb2.Location = new System.Drawing.Point(8, 40);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(88, 24);
            this.rb2.TabIndex = 2;
            this.rb2.TabStop = true;
            this.rb2.Text = "经治医生：";
            this.rb2.Click += new System.EventHandler(this.rb1_Click);
            // 
            // rb1
            // 
            this.rb1.Location = new System.Drawing.Point(8, 16);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(88, 24);
            this.rb1.TabIndex = 1;
            this.rb1.Text = "主管护士：";
            this.rb1.Click += new System.EventHandler(this.rb1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.dgZd);
            this.groupBox1.Controls.Add(this.gbRyzd);
            this.groupBox1.Controls.Add(this.gbCyzd);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.bt退出);
            this.groupBox1.Controls.Add(this.btUse);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.GrdSel);
            this.groupBox1.Controls.Add(this.txtDoc);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(148, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 619);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtzx);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnxg);
            this.groupBox4.Controls.Add(this.txtzyzd);
            this.groupBox4.Location = new System.Drawing.Point(8, 298);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 116);
            this.groupBox4.TabIndex = 60;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "诊断";
            this.groupBox4.Visible = false;
            // 
            // txtzx
            // 
            this.txtzx.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzx.Location = new System.Drawing.Point(72, 50);
            this.txtzx.Name = "txtzx";
            this.txtzx.Size = new System.Drawing.Size(130, 23);
            this.txtzx.TabIndex = 57;
            this.txtzx.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.txtzx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 56;
            this.label3.Text = "证型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "中医诊断：";
            // 
            // btnxg
            // 
            this.btnxg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnxg.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnxg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnxg.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnxg.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnxg.ImageIndex = 0;
            this.btnxg.Location = new System.Drawing.Point(8, 83);
            this.btnxg.Name = "btnxg";
            this.btnxg.Size = new System.Drawing.Size(196, 24);
            this.btnxg.TabIndex = 54;
            this.btnxg.Text = "修改";
            this.btnxg.UseVisualStyleBackColor = false;
            this.btnxg.Click += new System.EventHandler(this.btnxg_Click);
            // 
            // txtzyzd
            // 
            this.txtzyzd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzyzd.Location = new System.Drawing.Point(72, 20);
            this.txtzyzd.Name = "txtzyzd";
            this.txtzyzd.Size = new System.Drawing.Size(130, 23);
            this.txtzyzd.TabIndex = 2;
            this.txtzyzd.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.txtzyzd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // gbRyzd
            // 
            this.gbRyzd.Controls.Add(this.btXgryzd);
            this.gbRyzd.Controls.Add(this.txtRyzd);
            this.gbRyzd.Location = new System.Drawing.Point(8, 215);
            this.gbRyzd.Name = "gbRyzd";
            this.gbRyzd.Size = new System.Drawing.Size(208, 77);
            this.gbRyzd.TabIndex = 58;
            this.gbRyzd.TabStop = false;
            this.gbRyzd.Text = "入院诊断";
            // 
            // btXgryzd
            // 
            this.btXgryzd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btXgryzd.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btXgryzd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXgryzd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btXgryzd.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btXgryzd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btXgryzd.ImageIndex = 0;
            this.btXgryzd.Location = new System.Drawing.Point(6, 47);
            this.btXgryzd.Name = "btXgryzd";
            this.btXgryzd.Size = new System.Drawing.Size(196, 24);
            this.btXgryzd.TabIndex = 54;
            this.btXgryzd.Text = "修改入院诊断";
            this.btXgryzd.UseVisualStyleBackColor = false;
            this.btXgryzd.Click += new System.EventHandler(this.btXgryzd_Click);
            // 
            // txtRyzd
            // 
            this.txtRyzd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRyzd.Location = new System.Drawing.Point(6, 20);
            this.txtRyzd.Name = "txtRyzd";
            this.txtRyzd.Size = new System.Drawing.Size(196, 23);
            this.txtRyzd.TabIndex = 1;
            this.txtRyzd.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.txtRyzd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // gbCyzd
            // 
            this.gbCyzd.Controls.Add(this.btXgcyzd);
            this.gbCyzd.Controls.Add(this.txtCyzd);
            this.gbCyzd.Location = new System.Drawing.Point(6, 484);
            this.gbCyzd.Name = "gbCyzd";
            this.gbCyzd.Size = new System.Drawing.Size(208, 77);
            this.gbCyzd.TabIndex = 59;
            this.gbCyzd.TabStop = false;
            this.gbCyzd.Text = "出院诊断";
            // 
            // btXgcyzd
            // 
            this.btXgcyzd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btXgcyzd.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btXgcyzd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXgcyzd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btXgcyzd.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btXgcyzd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btXgcyzd.ImageIndex = 0;
            this.btXgcyzd.Location = new System.Drawing.Point(6, 47);
            this.btXgcyzd.Name = "btXgcyzd";
            this.btXgcyzd.Size = new System.Drawing.Size(196, 24);
            this.btXgcyzd.TabIndex = 54;
            this.btXgcyzd.Text = "修改出院诊断";
            this.btXgcyzd.UseVisualStyleBackColor = false;
            this.btXgcyzd.Click += new System.EventHandler(this.btXgcyzd_Click);
            // 
            // txtCyzd
            // 
            this.txtCyzd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCyzd.Location = new System.Drawing.Point(6, 20);
            this.txtCyzd.Name = "txtCyzd";
            this.txtCyzd.Size = new System.Drawing.Size(196, 23);
            this.txtCyzd.TabIndex = 2;
            this.txtCyzd.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.txtCyzd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox1.Enabled = false;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBox1.Location = new System.Drawing.Point(80, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 20);
            this.comboBox1.TabIndex = 57;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // GrdSel
            // 
            this.GrdSel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdSel.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GrdSel.CaptionVisible = false;
            this.GrdSel.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.GrdSel.DataMember = "";
            this.GrdSel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdSel.Location = new System.Drawing.Point(224, 40);
            this.GrdSel.Name = "GrdSel";
            this.GrdSel.ReadOnly = true;
            this.GrdSel.RowHeadersVisible = false;
            this.GrdSel.Size = new System.Drawing.Size(386, 574);
            this.GrdSel.TabIndex = 17;
            this.GrdSel.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.GrdSel.Visible = false;
            this.GrdSel.CurrentCellChanged += new System.EventHandler(this.GrdSel_CurrentCellChanged);
            this.GrdSel.myKeyDown += new TrasenClasses.GeneralControls.myDelegate(this.GrdSel_myKeyDown);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.GrdSel;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "病人姓名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel左
            // 
            this.panel左.Controls.Add(this.myDataGrid2);
            this.panel左.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel左.Location = new System.Drawing.Point(0, 0);
            this.panel左.Name = "panel左";
            this.panel左.Size = new System.Drawing.Size(148, 619);
            this.panel左.TabIndex = 1;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.AllowSorting = false;
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionForeColor = System.Drawing.Color.Black;
            this.myDataGrid2.CaptionText = "病人信息";
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.RowHeaderWidth = 20;
            this.myDataGrid2.Size = new System.Drawing.Size(148, 619);
            this.myDataGrid2.TabIndex = 24;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle0});
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // dataGridTableStyle0
            // 
            this.dataGridTableStyle0.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle0.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle0.RowHeaderWidth = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel左);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 619);
            this.panel1.TabIndex = 2;
            // 
            // frmXGXX
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(766, 619);
            this.Controls.Add(this.panel1);
            this.Name = "frmXGXX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改信息";
            this.Load += new System.EventHandler(this.frmXGXX_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgZd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbRyzd.ResumeLayout(false);
            this.gbRyzd.PerformLayout();
            this.gbCyzd.ResumeLayout(false);
            this.gbCyzd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).EndInit();
            this.panel左.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmXGXX_Load(object sender, System.EventArgs e)
        {
            string BinSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_zy_vInpatient_Bed " +
                "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY BED_NO,Baby_ID";

            string[] GrdMappingName11 ={ "床号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
            int[] GrdWidth11 ={ 5, 10, 0, 0, 0, 0 };
            int[] Alignment11 ={ 1, 0, 0, 0, 0, 0 };
            myFunc.InitGridSQL(BinSql, GrdMappingName11, GrdWidth11, Alignment11, this.myDataGrid2);
            myFunc.SelectBin(true, this.myDataGrid2, 2, 3, 4, 5);
            PubStaticFun.ModifyDataGridStyle(myDataGrid2, 0);

            if (new SystemCfg(7062).Config == "1")
            {
                gbRyzd.Visible = true;
            }
            else
            {
                gbRyzd.Visible = false;
            }

            if (new SystemCfg(7063).Config == "1")
            {
                gbCyzd.Visible = true;
            }
            else
            {
                gbCyzd.Visible = false;
            }

            myFunc.InidNamecomboBox(this.comboBox1);
            ShowData();
        }
        string zx = "";
        string zyzd = "";
        private void ShowData()
        {
            string sSql = "SELECT a.NURS_NAME,a.ZYDOC_NAME,a.ZZDOC_NAME,a.flag,a.ybjklx,a.in_diagnosis,ryzd,a.out_diagnosis,a.cyzd,b.zx,b.zyzd,dbo.fun_getdiseasename(zx,b.yblx) zxmc,dbo.fun_getdiseasename(zyzd,b.yblx) zyzdmc " +
                "  from vi_ZY_vInpatient_all  a  left join zy_inpatient b on a.inpatient_id=b.inpatient_id " +
                " where a.INPATIENT_ID='" + ClassStatic.Current_BinID + "' and a.Baby_ID=" + ClassStatic.Current_BabyID;
            DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);

            if (tempTab == null || tempTab.Rows.Count == 0)
            {
                MessageBox.Show("未找到病人信息，请重新选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.lb1.Text = tempTab.Rows[0]["NURS_NAME"].ToString().Trim();
            this.lb2.Text = tempTab.Rows[0]["ZYDOC_NAME"].ToString().Trim();
            this.lb3.Text = tempTab.Rows[0]["ZZDOC_NAME"].ToString().Trim();

            //Add By Tany 2010-01-13
            comboBox1.Tag = tempTab.Rows[0]["ybjklx"].ToString().Trim();

            isKeypress = false;
            //add by zouchihua 2013-5-23
            zx = tempTab.Rows[0]["zx"].ToString().Trim();//证型
            zyzd = tempTab.Rows[0]["zyzd"].ToString().Trim();//中医诊断
            this.txtzx.Tag = zx;
            this.txtzyzd.Tag = zyzd;
            this.txtzx.Text = tempTab.Rows[0]["zxmc"].ToString().Trim() == "未知诊断" ? "" : tempTab.Rows[0]["zxmc"].ToString().Trim();
            this.txtzyzd.Text = tempTab.Rows[0]["zyzdmc"].ToString().Trim() == "未知诊断" ? "" : tempTab.Rows[0]["zyzdmc"].ToString().Trim();

            ryzd = tempTab.Rows[0]["ryzd"].ToString().Trim();
            cyzd = tempTab.Rows[0]["cyzd"].ToString().Trim();
            ryzddm = tempTab.Rows[0]["in_diagnosis"].ToString().Trim();
            cyzddm = tempTab.Rows[0]["out_diagnosis"].ToString().Trim();
            txtRyzd.Text = ryzd;
            txtRyzd.Tag = ryzddm;
            int flag = Convert.ToInt16(tempTab.Rows[0]["flag"].ToString().Trim());
            if (flag != 4 && flag != 5)
            {
                gbCyzd.Enabled = false;
                txtCyzd.Text = "";
                txtCyzd.Tag = "";
            }
            else
            {
                gbCyzd.Enabled = true;
                txtCyzd.Text = cyzd;
                txtCyzd.Tag = cyzddm;
            }

            this.dgZd.Visible = false;
            this.GrdSel.Visible = false;
            if (this.rb1.Checked) this.txtDoc.Text = this.lb1.Text;
            if (this.rb2.Checked) this.txtDoc.Text = this.lb2.Text;
            if (this.rb3.Checked) this.txtDoc.Text = this.lb3.Text;
        }


        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            myFunc.NamecomboBox_SelectedIndexChanged(this.comboBox1);
            //this.ShowData();
        }


        private void rb1_Click(object sender, System.EventArgs e)
        {
            if (this.rb1.Checked)
            {
                this.txtDoc.Text = this.lb1.Text;
            }
            if (this.rb2.Checked)
            {
                this.txtDoc.Text = this.lb2.Text;
            }
            if (this.rb3.Checked)
            {
                this.txtDoc.Text = this.lb3.Text;
            }
            this.txtDoc.Focus();
            this.txtDoc.SelectAll();
            if (this.GrdSel.Visible == true) this.GrdSel.Visible = false;

        }

        private void rbI1_Click(object sender, System.EventArgs e)
        {
            this.GrdSel.Visible = false;
            this.txtDoc.Focus();
            this.txtDoc.SelectAll();
        }


        private void txtDoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            long keyInt = Convert.ToInt32(e.KeyData);

            #region 数字或字母键
            if ((keyInt >= 65 && keyInt <= 90) || ((keyInt >= 48 && keyInt <= 57) || (keyInt >= 96 && keyInt <= 105)))
            {
                if (keyInt > 90) keyInt -= 48;

                //得到输入的数据
                string SelData = this.txtDoc.Text.Trim();
                if (SelData != "")
                {
                    SelData = (this.txtDoc.SelectionLength == SelData.Length ? "" : SelData);
                }
                ShowSelCard(SelData + Convert.ToChar(keyInt));
            }
            #endregion

            #region 退格键
            if (keyInt == 8 && this.GrdSel.Visible == true)
            {
                //得到输入的数据
                string SelData = this.txtDoc.Text;
                if (SelData.Trim() != "")
                {
                    if (this.txtDoc.SelectionLength == this.txtDoc.TextLength)
                    {
                        SelData = "";
                    }
                    else
                    {
                        SelData = SelData.Substring(0, SelData.Length - 1);
                    }
                }
                //显示查到的数据					
                //				if(SelData.Trim()!="")
                //				{
                ShowSelCard(SelData);
                //     			}
                //				else
                //				{
                //					this.GrdSel.Visible=false;
                //				}	
            }
            #endregion

            #region 上下键
            if ((keyInt == 40 || keyInt == 38) && this.GrdSel.Visible)
            {
                if (this.GrdSel.VisibleRowCount > 0)
                {
                    this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);
                }
                this.GrdSel.Focus();
            }
            #endregion

            #region 回车键
            if (keyInt == 13 && this.GrdSel.Visible)
            {
                GetCardData(this.GrdSel.CurrentCell.RowNumber);
                this.btUse.Focus();
            }
            #endregion

            #region F10,F11,F12键切换输入方法
            if ((keyInt == 121 && this.rbI1.Checked == false) || (keyInt == 122 && this.rbI2.Checked == false) || (keyInt == 123 && this.rbI3.Checked == false))
            {
                if (keyInt == 121) this.rbI1.Checked = true;
                if (keyInt == 122) this.rbI2.Checked = true;
                if (keyInt == 123) this.rbI3.Checked = true;
                this.rbI1_Click(sender, e);
            }
            #endregion
        }


        private void ShowSelCard(string CurrentChar)
        {
            string[] GrdMappingName ={ "", "", "", "", "" };
            int[] GrdWidth ={ 6, 8, 6, 6, 0 };
            int[] Alignment ={ 0, 0, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0 };
            string sSql = "";

            if (this.rb1.Checked)//主管护士
            {
                if (this.rbI1.Checked)
                {
                    sSql = "select distinct b.py_code 拼音码, b.name as 姓名, b.wb_code 五笔码,a.nurse_id 数字码,b.employee_id " +
                        "  from jc_role_nurse a ,jc_employee_property b,jc_EMP_DEPT_ROLE c " +
                        " where a.employee_id=b.employee_id and c.employee_id=b.employee_id " +// and c.default=1"+
                        "       and c.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                        "       and upper(b.py_code) like '" + CurrentChar.Trim().ToUpper() + "%'" +
                        "       and b.delete_bit=0" +//Modify By tany 2011-02-24
                        " order by b.py_code";
                }
                else if (this.rbI2.Checked)
                {
                    sSql = "select distinct b.wb_code 五笔码, b.name as 姓名, b.py_code 拼音码,a.nurse_id 数字码,b.employee_id " +
                        "  from jc_role_nurse a ,jc_employee_property b,jc_EMP_DEPT_ROLE c " +
                        " where a.employee_id=b.employee_id and c.employee_id=b.employee_id " +//and c.default=1"+
                        "       and c.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                        "       and upper(b.wb_code) like '" + CurrentChar.Trim().ToUpper() + "%'" +
                        "       and b.delete_bit=0" +//Modify By tany 2011-02-24
                        " order by b.wb_code";
                }
                else
                {
                    sSql = "select distinct a.nurse_id 数字码, b.name as 姓名, b.py_code 拼音码,b.wb_code 五笔码,b.employee_id " +
                        "  from jc_role_nurse a ,jc_employee_property b,jc_EMP_DEPT_ROLE c " +
                        " where a.employee_id=b.employee_id and c.employee_id=b.employee_id " +//and c.default=1"+
                        "       and c.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                        "       and convert(varchar,convert(bigint,a.nurse_id)) like '" + CurrentChar.Trim() + "%'" +
                        "       and b.delete_bit=0" +//Modify By tany 2011-02-24
                        " order by a.nurse_id";
                }
            }
            else//医生
            {
                if (this.rbI1.Checked)
                {
                    sSql = "select distinct b.py_code 拼音码, b.name as 姓名, b.wb_code 五笔码,a.doc_id 数字码,b.employee_id " +
                        "  from jc_role_doctor a ,jc_employee_property b,jc_EMP_DEPT_ROLE c " +
                        " where a.employee_id=b.employee_id and c.employee_id=b.employee_id " +//and c.default=0"+
                        "       and c.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                        "       and upper(b.py_code) like '" + CurrentChar.Trim().ToUpper() + "%'" +
                        "       and b.delete_bit=0" +//Modify By tany 2011-02-24
                        " order by b.py_code";
                }
                else if (this.rbI2.Checked)
                {
                    sSql = "select distinct b.wb_code 五笔码, b.name as 姓名,b.py_code 拼音码,a.doc_id 数字码,b.employee_id " +
                        "  from jc_role_doctor a ,jc_employee_property b,jc_EMP_DEPT_ROLE c " +
                        " where a.employee_id=b.employee_id and c.employee_id=b.employee_id " +//and c.default=0"+
                        "       and c.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                        "       and upper(b.wb_code) like '" + CurrentChar.Trim().ToUpper() + "%'" +
                        "       and b.delete_bit=0" +//Modify By tany 2011-02-24
                        " order by b.wb_code";
                }
                else
                {
                    sSql = "select distinct a.doc_id 数字码, b.name as 姓名,b.py_code 拼音码, b.wb_code 五笔码,b.employee_id" +
                        "  from jc_role_doctor a ,jc_employee_property b,jc_EMP_DEPT_ROLE c " +
                        " where a.employee_id=b.employee_id and c.employee_id=b.employee_id " +//and c.default=0"+
                        "       and c.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                        "       and convert(varchar,convert(bigint,a.doc_id)) like '" + CurrentChar.Trim() + "%'" +
                        "       and b.delete_bit=0" +//Modify By tany 2011-02-24
                        " order by a.doc_id";
                }

            }

            if (this.rbI1.Checked)
            {
                string[] GrdMappingName_tmp ={ "拼音码", "姓名", "五笔码", "数字码", "employee_id" };
                GrdMappingName_tmp.CopyTo(GrdMappingName, 0);
            }
            else if (this.rbI2.Checked)
            {
                string[] GrdMappingName_tmp ={ "五笔码", "姓名", "拼音码", "数字码", "employee_id" };
                GrdMappingName_tmp.CopyTo(GrdMappingName, 0);
            }
            else
            {
                string[] GrdMappingName_tmp ={ "数字码", "姓名", "拼音码", "五笔码", "employee_id" };
                GrdMappingName_tmp.CopyTo(GrdMappingName, 0);
            }

            this.GrdSel.TableStyles[0].GridColumnStyles.Clear();
            myFunc.ShowGrid(0, sSql, this.GrdSel);
            this.myFunc.InitGrid(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.GrdSel);
            this.GrdSel.Visible = true;

            //选择最接近的记录			
            DataTable myTempTb = (DataTable)this.GrdSel.DataSource;
            int j = CurrentChar.Length;
            while (j > 0)
            {
                string sCode = CurrentChar.Substring(0, j);
                for (int i = 0; i <= myTempTb.Rows.Count - 1; i++)
                {
                    if (Convert.ToString(this.GrdSel[i, 0]).Trim().Length < j) continue;
                    if (Convert.ToString(this.GrdSel[i, 0]).Trim().Substring(0, j).ToLower() == sCode.ToLower())
                    {
                        this.GrdSel.CurrentRowIndex = i;
                        j = 1;
                        break;
                    }
                }
                j--;
            }
        }

        private bool GrdSel_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            long keyInt = Convert.ToInt32(keyData);

            if (keyInt == 27)   //ESC
            {
                this.GrdSel.Visible = false;
                this.txtDoc.Focus();
                this.txtDoc.SelectAll();
            }

            if (keyInt == 13)
            {
                GetCardData(this.GrdSel.CurrentCell.RowNumber);//+48);
            }

            //为英文字母
            if ((keyInt >= 65 && keyInt <= 90) || (keyInt >= 48 && keyInt <= 57) || (keyInt >= 96 && keyInt <= 105))
            {
                //需要重复的代码
                this.txtDoc.Select();
                this.txtDoc.SelectionStart = this.txtDoc.TextLength;
                if (keyInt >= 65 && keyInt <= 90)
                    SendKeys.Send(keyData.ToString().ToLower());
                else if ((keyInt >= 48 && keyInt <= 57))
                    SendKeys.Send(Convert.ToString(keyInt - 48));
                else
                    SendKeys.Send(Convert.ToString(keyInt - 96));
            }

            if ((keyInt == 121 && this.rbI1.Checked == false) || (keyInt == 122 && this.rbI2.Checked == false) || (keyInt == 123 && this.rbI3.Checked == false))
            {
                if (keyInt == 121) this.rbI1.Checked = true;
                if (keyInt == 122) this.rbI2.Checked = true;
                if (keyInt == 123) this.rbI3.Checked = true;
                this.GrdSel.Visible = false;
                this.txtDoc.Focus();
                this.txtDoc.SelectAll();
            }

            return false;
        }

        private void GrdSel_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);
        }

        private void GetCardData(int theSel)
        {
            //变量付初始值
            int nSelRow;
            DataTable mySelTbTemp = (DataTable)this.GrdSel.DataSource;
            nSelRow = theSel;

            //判断选择的有效性
            if (nSelRow <= mySelTbTemp.Rows.Count - 1)
            {
                this.txtDoc.Text = mySelTbTemp.Rows[nSelRow]["姓名"].ToString();
                this.txtDoc.Tag = mySelTbTemp.Rows[nSelRow]["employee_id"].ToString();
            }
            else
            {
                this.txtDoc.Text = "";
                this.txtDoc.Tag = "";
            }
            this.GrdSel.Visible = false;
        }


        private void btUse_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("未找到病人信息，请重新选择病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            #region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
            string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
            if (rtnSql[0] != "0")
            {
                MessageBox.Show("由于跨院转科或者特殊治疗，该病人记录已经冻结不能允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rtnSql[1] != FrmMdiMain.Jgbm.ToString())
            {
                MessageBox.Show("该病人不属于本院区，不允许操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            if (this.txtDoc.Text.Trim() == "") return;

            string OperType = "";
            string OperContens = "";

            try
            {
                if (this.rb1.Checked)
                {
                    if (this.lb1.Text == this.txtDoc.Text.Trim()) return;
                    if (MessageBox.Show(this, "是否将主管护士由“" + this.lb1.Text + "”修改为“" + this.txtDoc.Text.Trim() + "”？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No) return;
                    myFunc.ChangeDOC("", 7, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), Convert.ToInt32(this.txtDoc.Tag), InstanceForm.BCurrentUser.EmployeeId, FrmMdiMain.Jgbm);
                    OperType = "修改主管护士";
                    OperContens = "将" + ClassStatic.Current_BinID + "主管护士由“" + this.lb1.Text + "”修改为“" + this.txtDoc.Text.Trim() + "”";
                }
                else if (this.rb2.Checked)
                {
                    if (this.lb2.Text == this.txtDoc.Text.Trim()) return;
                    if (MessageBox.Show(this, "是否将经治医生由“" + this.lb2.Text + "”修改为“" + this.txtDoc.Text.Trim() + "”？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No) return;
                    myFunc.ChangeDOC("", 6, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), Convert.ToInt32(this.txtDoc.Tag), InstanceForm.BCurrentUser.EmployeeId, FrmMdiMain.Jgbm);
                    OperType = "修改经治医生";
                    OperContens = "将" + ClassStatic.Current_BinID + "经治医生由“" + this.lb2.Text + "”修改为“" + this.txtDoc.Text.Trim() + "”";

                    DataTable tb = (DataTable)myDataGrid2.DataSource;
                    int nrow = this.myDataGrid2.CurrentCell.RowNumber;
                    string msg_wardid = "";
                    long msg_deptid = 0;
                    long msg_empid = Convert.ToInt64(this.txtDoc.Tag);
                    string msg_sender = FrmMdiMain.CurrentDept.WardName + "：" + FrmMdiMain.CurrentUser.Name;
                    string msg_msg = this.txtDoc.Text.Trim() + "医生：\r\n    为您分配了新的病人！\r\n    床号：" + tb.Rows[nrow]["床号"].ToString().Trim() + "\r\n    姓名：" + tb.Rows[nrow]["姓名"].ToString().Trim();
                    TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.住院医生站, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
                }
                else
                {
                    if (this.lb3.Text == this.txtDoc.Text.Trim()) return;
                    if (MessageBox.Show(this, "是否将主管医生由“" + this.lb3.Text + "”修改为“" + this.txtDoc.Text.Trim() + "”？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No) return;
                    myFunc.ChangeDOC("", 5, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), Convert.ToInt32(this.txtDoc.Tag), InstanceForm.BCurrentUser.EmployeeId, FrmMdiMain.Jgbm);
                    OperType = "修改主管医生";
                    OperContens = "将" + ClassStatic.Current_BinID + "主管医生由“" + this.lb3.Text + "”修改为“" + this.txtDoc.Text.Trim() + "”";
                }
                ShowData();

                //写日志 Add By Tany 2005-01-12
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, OperType, OperContens, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;

                return;
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "修改病人信息错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show(this, err.ToString() + "   修改失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void bt退出_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
            if (myTb.Rows.Count == 0) return;

            //得到病人基本信息
            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            this.myDataGrid2.Select(nrow);
            ClassStatic.Current_BinID = new Guid(this.myDataGrid2[nrow, 2].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(this.myDataGrid2[nrow, 3]);
            ClassStatic.Current_DeptID = Convert.ToInt64(this.myDataGrid2[nrow, 4]);	//病人当前所属科室
            ClassStatic.Current_isMY = Convert.ToInt16(this.myDataGrid2[nrow, 5]);

            myFunc.InidNamecomboBox(this.comboBox1);
            ShowData();
        }
        //Add by Kevin 2012-12-31
        /// <summary>
        /// 保存疾病，年龄，性别
        /// </summary>
        /// <param name="inpatientid"></param>
        /// <param name="oldjslx"></param>
        /// <param name="oldyblx"></param>
        /// <param name="newjslx"></param>
        /// <param name="newyblx"></param>
        /// <param name="type">0 疾病 1 年龄 2 性别</param>
        private void SaveAllInpatientLog(Guid inpatientid, string oldstr, string newstr, int type)
        {
            try
            {
                string sql = "insert into ZY_ALLINPATIENT_LOG(INPATIENT_ID, OLD_STR, NEW_STR, TYPE, BOOK_DATE, BOOK_USER, IP, PCNAME)";
                sql += "values ('" + inpatientid + "','" + oldstr + "','" + newstr + "'," + type + ",getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",'" + Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString() + "','" + System.Environment.MachineName + "')";
                FrmMdiMain.Database.DoCommand(sql);
            }
            catch (Exception err)
            {
                MessageBox.Show("保存病人登记变更信息时出错：" + err.Message);
            }
        }

        private void btXgryzd_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BabyID != 0)
            {
                return;
            }
            #region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
            string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
            if (rtnSql[0] != "0")
            {
                MessageBox.Show("由于跨院转科或者特殊治疗，该病人记录已经冻结不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            if (ClassStatic.Current_BabyID == 0 && (txtRyzd.Text.Trim() == "" || Convertor.IsNull(txtRyzd.Tag, "") == ""))
            {
                MessageBox.Show("入院诊断不正确！");
                return;
            }
            try
            {
                if (MessageBox.Show("是否确认修改该病人入院诊断？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                InstanceForm.BDatabase.DoCommand("update zy_inpatient set in_diagnosis='" + txtRyzd.Tag.ToString() + "' where inpatient_id='" + ClassStatic.Current_BinID + "'");

                string OperType = "";
                string OperContens = "";
                OperType = "修改入院诊断";
                OperContens = "将" + ClassStatic.Current_BinID + "入院诊断由“" + ryzd + "(" + ryzddm + ")”修改为“" + txtRyzd.Text.Trim() + "(" + txtRyzd.Tag + ")”";
                SaveAllInpatientLog(ClassStatic.Current_BinID, ryzddm, txtRyzd.Tag.ToString(), 0);
                //写日志 Add By Tany 2010-01-13
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, OperType, OperContens, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 7);
                _systemLog.Save();
                _systemLog = null;

                MessageBox.Show("修改成功！");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btXgcyzd_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BabyID != 0)
            {
                return;
            }
            if (ClassStatic.Current_BabyID == 0 && (txtCyzd.Text.Trim() == "" || Convertor.IsNull(txtCyzd.Tag, "") == ""))
            {
                MessageBox.Show("出院诊断不正确！");
                return;
            }
            try
            {
                if (MessageBox.Show("是否确认修改该病人出院诊断？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                InstanceForm.BDatabase.DoCommand("update zy_inpatient set out_diagnosis='" + txtCyzd.Tag.ToString() + "' where inpatient_id='" + ClassStatic.Current_BinID + "'");

                string OperType = "";
                string OperContens = "";
                OperType = "修改出院诊断";
                OperContens = "将" + ClassStatic.Current_BinID + "出院诊断由“" + cyzd + "(" + cyzddm + ")”修改为“" + txtCyzd.Text.Trim() + "(" + txtCyzd.Tag + ")”";

                //写日志 Add By Tany 2010-01-13
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, OperType, OperContens, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 7);
                _systemLog.Save();
                _systemLog = null;

                MessageBox.Show("修改成功！");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void textBox_TextChanged(object sender, System.EventArgs e)
        {
            if (!isKeypress)
            {
                return;
            }
            TBox = (TextBox)sender;
            this.dgZd.BringToFront();
            if (TBox.Text.Trim() == "" || TBox.Enabled == false)
            {
                this.dgZd.Visible = false;
                return;
            }
            this.dgZd.Visible = true;
            this.dgZd.Top = TBox.Parent.Top + TBox.Top + TBox.Height;
            this.dgZd.Left = TBox.Parent.Left + TBox.Left;

            string str = TBox.Text.Trim().Replace("'", ".").ToUpper();
            str = str == "" ? "" : " and (拼音码 like '" + str + "%' )";
            int ybjklx = Convert.ToInt16(comboBox1.Tag);
            if (ybjklx <= 0)
                ybjklx = 0;
            string sSql = "";
            if(cfg7166.Config.Trim()=="0")
              sSql = "select top 200 name NAME,coding ICD,py_code 拼音码,sort from jc_disease where 1=1 and isnull(BSCBZ,0)=0 and bscbz=0 " + (ybjklx <= 0 ? "" : " and ybjklx =" + ybjklx) + " and (py_code like '" + TBox.Text.Trim() + "%' or wb_code like '" + TBox.Text.Trim() + "%' or name like '" + TBox.Text.Trim() + "%' or coding like '" + TBox.Text.Trim() + "%')  ";
            else
              sSql = "select top 200 name NAME,coding ICD,py_code 拼音码,sort from jc_disease where 1=1 and isnull(BSCBZ,0)=0 and bscbz=0  and ybjklx =" + ybjklx + " and (py_code like '" + TBox.Text.Trim() + "%' or wb_code like '" + TBox.Text.Trim() + "%' or name like '" + TBox.Text.Trim() + "%' or coding like '" + TBox.Text.Trim() + "%')  ";
            if (TBox == txtzyzd)
                sSql += "and sort='B'";
            if (TBox == txtzx)
                sSql += "and sort='Z'";
            sSql+=  "  order by len(name)";
            zdTb = FrmMdiMain.Database.GetDataTable(sSql);

            dgZd.DataSource = zdTb;
            PubStaticFun.ModifyDataGridStyle(dgZd, 0);
        }

        private void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            isKeypress = true;

            TBox = (TextBox)sender;
            int keyInt = Convert.ToInt32(e.KeyCode);

            if (zdTb == null)
            {
                this.dgZd.Visible = false;
                return;
            }
            if (zdTb.Rows.Count == 0)
            {
                dgZd.Visible = false;
                return;
            }
            else if (keyInt == 27 && dgZd.Visible == true)
            {
                TBox.Text = "";
                dgZd.Visible = false;
            }
            else if (keyInt == 40 && this.dgZd.CurrentRowIndex < zdTb.Rows.Count - 1)
            {
                dgZd.UnSelect(dgZd.CurrentCell.RowNumber);
                dgZd.CurrentRowIndex += 1;
                dgZd.Select(dgZd.CurrentCell.RowNumber);
            }
            else if (keyInt == 38 && this.dgZd.CurrentRowIndex > 0)
            {
                dgZd.UnSelect(dgZd.CurrentCell.RowNumber);
                dgZd.CurrentRowIndex -= 1;
                dgZd.Select(dgZd.CurrentCell.RowNumber);
            }
            else if (keyInt == 13)
            {
                if (dgZd.Visible == true)
                {
                    TBox.Tag = zdTb.Rows[dgZd.CurrentCell.RowNumber]["ICD"].ToString();
                    TBox.Text = zdTb.Rows[dgZd.CurrentCell.RowNumber]["NAME"].ToString();
                }

                dgZd.Visible = false;
                if (TBox.Name == "txtRyzd")
                {
                    btXgryzd.Focus();
                }
                else if (TBox.Name == "txtCyzd")
                {
                    btXgcyzd.Focus();
                }
                else
                    if (TBox.Name == "txtzyzd")
                    {
                        this.txtzx.Focus();
                    }
                else
                        if (TBox.Name == "txtzx")
                        {
                            this.btnxg.Focus();
                        }
                
            }
        }

        private void dgZd_Click(object sender, System.EventArgs e)
        {
            DataTable dt = (DataTable)dgZd.DataSource;
            if (dt.Rows.Count>0)
              dgZd.Select(dgZd.CurrentCell.RowNumber);
        }

        private void dgZd_DoubleClick(object sender, System.EventArgs e)
        {
            dgZd_KeyUp(dgZd, new KeyEventArgs(Keys.Enter));
        }

        private void dgZd_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int keyInt = Convert.ToInt32(e.KeyCode);
            if (zdTb.Rows.Count == 0) return;
            if (keyInt == 13)
            {
                TBox.Tag = zdTb.Rows[dgZd.CurrentCell.RowNumber]["ICD"].ToString();
                TBox.Text = zdTb.Rows[dgZd.CurrentCell.RowNumber]["NAME"].ToString();

                if (TBox.Name == "txtRyzd")
                {
                    btXgryzd.Focus();
                }
                else if (TBox.Name == "txtCyzd")
                {
                    btXgcyzd.Focus();
                }

                dgZd.Visible = false;
            }
        }

        private void btnxg_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtzyzd.Text.Trim() == "")
                    txtzyzd.Tag = null;
                if (txtzx.Text.Trim() == "")
                    txtzx.Tag = null;
                string sql = "update zy_inpatient set  zyzd='" + Convertor.IsNull(txtzyzd.Tag, "") + "'," +
                            "  zx='" + Convertor.IsNull(txtzx.Tag, "") + "' where inpatient_id='" + ClassStatic.Current_BinID + "'";
                FrmMdiMain.Database.DoCommand(sql);
                string OperType = "";
                string OperContens = "";
                OperType = "修改诊断";
                OperContens = "将" + ClassStatic.Current_BinID + "中医诊断由“" + zyzd + "”修改为“" + Convertor.IsNull(txtzyzd.Tag, "") +"” "
                                 + "\r\n 证型由" + zx + "修改为 ”" + Convertor.IsNull(txtzx.Tag, "") + "“";

                //写日志 Add By Tany 2010-01-13
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, OperType, OperContens, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 7);
                _systemLog.Save();
                _systemLog = null;
                MessageBox.Show("修改成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
		
