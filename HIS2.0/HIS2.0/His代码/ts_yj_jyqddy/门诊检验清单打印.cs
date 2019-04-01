using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_yj_tjbb;
using ts_mz_class;


namespace ts_yj_jyqddy
{
    public class Frmmzqddy : System.Windows.Forms.Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private long PrintID = 0;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private Label label5;
        private ComboBox cmbklx;
        private TextBox txtkh;
        private ImageList imageList2;
        private Button button1;
        private Button button2;
        private Button buthelp;
        private TextBox txttxm;
        private Label label6;
        private Panel panel1;
        private RadioButton rdow;
        private RadioButton rdoy;
        private RadioButton rdoall;
        private DataGridViewTextBoxColumn 打印内容;
        private DataGridViewTextBoxColumn 打印时间;
        private DataGridViewTextBoxColumn 打印人;
        private DataGridViewTextBoxColumn dyid;
        private DataGridViewTextBoxColumn yjsqid;
        private DataGridViewTextBoxColumn 序号;
        private DataGridViewTextBoxColumn 门诊号;
        private DataGridViewTextBoxColumn 姓名;
        private DataGridViewTextBoxColumn 科室;
        private DataGridViewTextBoxColumn 项目名称;
        private DataGridViewTextBoxColumn 次数;
        private DataGridViewTextBoxColumn 单位;
        private DataGridViewTextBoxColumn 金额;
        private DataGridViewTextBoxColumn 收费时间;
        private DataGridViewTextBoxColumn 检验类型;
        private DataGridViewTextBoxColumn 条形码;
        private DataGridViewTextBoxColumn 操作窗口;
        private string _chineseName;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmmzqddy));
			this.lblCaption = new System.Windows.Forms.Label();
			this.btLookup = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.yjsqid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.门诊号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.科室 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.项目名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.次数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.收费时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.检验类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.条形码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.操作窗口 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbhylx = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dtp1 = new System.Windows.Forms.DateTimePicker();
			this.dtp2 = new System.Windows.Forms.DateTimePicker();
			this.txtmzh = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.rdo1_ydy = new System.Windows.Forms.RadioButton();
			this.rdo1_wdy = new System.Windows.Forms.RadioButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rdow = new System.Windows.Forms.RadioButton();
			this.rdoy = new System.Windows.Forms.RadioButton();
			this.rdoall = new System.Windows.Forms.RadioButton();
			this.txttxm = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.buthelp = new System.Windows.Forms.Button();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.cmbklx = new System.Windows.Forms.ComboBox();
			this.txtkh = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.打印内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.打印时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.打印人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel6 = new System.Windows.Forms.Panel();
			this.butdycx = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.dtpdyrq1 = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblCaption
			// 
			this.lblCaption.BackColor = System.Drawing.Color.CornflowerBlue;
			this.lblCaption.Font = new System.Drawing.Font("楷体_GB2312", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblCaption.ForeColor = System.Drawing.SystemColors.Window;
			this.lblCaption.Location = new System.Drawing.Point(0, -2);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(913, 34);
			this.lblCaption.TabIndex = 16;
			this.lblCaption.Text = "   检验清单打印";
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btLookup
			// 
			this.btLookup.BackColor = System.Drawing.SystemColors.Control;
			this.btLookup.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btLookup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btLookup.ForeColor = System.Drawing.Color.Black;
			this.btLookup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btLookup.Location = new System.Drawing.Point(706, 52);
			this.btLookup.Name = "btLookup";
			this.btLookup.Size = new System.Drawing.Size(92, 34);
			this.btLookup.TabIndex = 18;
			this.btLookup.Text = "查询";
			this.btLookup.UseVisualStyleBackColor = false;
			this.btLookup.Click += new System.EventHandler(this.btLookup_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yjsqid,
            this.序号,
            this.门诊号,
            this.姓名,
            this.科室,
            this.项目名称,
            this.次数,
            this.单位,
            this.金额,
            this.收费时间,
            this.检验类型,
            this.条形码,
            this.操作窗口});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(671, 484);
			this.dataGridView1.TabIndex = 18;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			// 
			// yjsqid
			// 
			this.yjsqid.DataPropertyName = "yjsqid";
			this.yjsqid.HeaderText = "yjsqid";
			this.yjsqid.Name = "yjsqid";
			this.yjsqid.ReadOnly = true;
			this.yjsqid.Visible = false;
			// 
			// 序号
			// 
			this.序号.DataPropertyName = "序号";
			this.序号.HeaderText = "序号";
			this.序号.Name = "序号";
			this.序号.ReadOnly = true;
			this.序号.Width = 40;
			// 
			// 门诊号
			// 
			this.门诊号.DataPropertyName = "门诊号";
			this.门诊号.HeaderText = "门诊号";
			this.门诊号.Name = "门诊号";
			this.门诊号.ReadOnly = true;
			// 
			// 姓名
			// 
			this.姓名.DataPropertyName = "姓名";
			this.姓名.HeaderText = "姓名";
			this.姓名.Name = "姓名";
			this.姓名.ReadOnly = true;
			this.姓名.Width = 70;
			// 
			// 科室
			// 
			this.科室.DataPropertyName = "科室";
			this.科室.HeaderText = "科室";
			this.科室.Name = "科室";
			this.科室.ReadOnly = true;
			// 
			// 项目名称
			// 
			this.项目名称.DataPropertyName = "项目名称";
			this.项目名称.HeaderText = "项目名称";
			this.项目名称.Name = "项目名称";
			this.项目名称.ReadOnly = true;
			this.项目名称.Width = 200;
			// 
			// 次数
			// 
			this.次数.DataPropertyName = "次数";
			this.次数.HeaderText = "次数";
			this.次数.Name = "次数";
			this.次数.ReadOnly = true;
			this.次数.Visible = false;
			// 
			// 单位
			// 
			this.单位.DataPropertyName = "单位";
			this.单位.HeaderText = "单位";
			this.单位.Name = "单位";
			this.单位.ReadOnly = true;
			this.单位.Visible = false;
			// 
			// 金额
			// 
			this.金额.DataPropertyName = "金额";
			this.金额.HeaderText = "金额";
			this.金额.Name = "金额";
			this.金额.ReadOnly = true;
			this.金额.Width = 60;
			// 
			// 收费时间
			// 
			this.收费时间.DataPropertyName = "收费时间";
			this.收费时间.HeaderText = "收费时间";
			this.收费时间.Name = "收费时间";
			this.收费时间.ReadOnly = true;
			// 
			// 检验类型
			// 
			this.检验类型.DataPropertyName = "检验类型";
			this.检验类型.HeaderText = "检验类型";
			this.检验类型.Name = "检验类型";
			this.检验类型.ReadOnly = true;
			// 
			// 条形码
			// 
			this.条形码.DataPropertyName = "条形码";
			this.条形码.HeaderText = "条形码";
			this.条形码.Name = "条形码";
			this.条形码.ReadOnly = true;
			// 
			// 操作窗口
			// 
			this.操作窗口.DataPropertyName = "操作窗口";
			this.操作窗口.HeaderText = "操作窗口";
			this.操作窗口.Name = "操作窗口";
			this.操作窗口.ReadOnly = true;
			this.操作窗口.Width = 80;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(486, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 14);
			this.label3.TabIndex = 31;
			this.label3.Text = "检验类型";
			// 
			// cmbhylx
			// 
			this.cmbhylx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cmbhylx.FormattingEnabled = true;
			this.cmbhylx.Items.AddRange(new object[] {
            "",
            "生化室",
            "细菌室",
            "免疫室",
            "细胞室",
            "PCR实验室",
            "体液室",
            "免疫发光室",
            "血液室",
            "血库室",
            "乙肝室"});
			this.cmbhylx.Location = new System.Drawing.Point(552, 13);
			this.cmbhylx.Name = "cmbhylx";
			this.cmbhylx.Size = new System.Drawing.Size(103, 22);
			this.cmbhylx.TabIndex = 30;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(93, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 14);
			this.label1.TabIndex = 24;
			this.label1.Text = "开始时间";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(297, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 14);
			this.label2.TabIndex = 25;
			this.label2.Text = "结束时间";
			// 
			// dtp1
			// 
			this.dtp1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtp1.Location = new System.Drawing.Point(162, 12);
			this.dtp1.Name = "dtp1";
			this.dtp1.Size = new System.Drawing.Size(119, 23);
			this.dtp1.TabIndex = 26;
			// 
			// dtp2
			// 
			this.dtp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtp2.Location = new System.Drawing.Point(360, 12);
			this.dtp2.Name = "dtp2";
			this.dtp2.Size = new System.Drawing.Size(120, 23);
			this.dtp2.TabIndex = 27;
			// 
			// txtmzh
			// 
			this.txtmzh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtmzh.Location = new System.Drawing.Point(163, 45);
			this.txtmzh.Name = "txtmzh";
			this.txtmzh.Size = new System.Drawing.Size(119, 23);
			this.txtmzh.TabIndex = 1;
			this.txtmzh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtzyh_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(107, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 14);
			this.label4.TabIndex = 0;
			this.label4.Text = "门诊号";
			// 
			// rdo1_ydy
			// 
			this.rdo1_ydy.AutoSize = true;
			this.rdo1_ydy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.rdo1_ydy.Location = new System.Drawing.Point(12, 45);
			this.rdo1_ydy.Name = "rdo1_ydy";
			this.rdo1_ydy.Size = new System.Drawing.Size(67, 18);
			this.rdo1_ydy.TabIndex = 37;
			this.rdo1_ydy.Text = "已打印";
			this.rdo1_ydy.UseVisualStyleBackColor = true;
			this.rdo1_ydy.CheckedChanged += new System.EventHandler(this.rdo1_wdy_CheckedChanged);
			// 
			// rdo1_wdy
			// 
			this.rdo1_wdy.AutoSize = true;
			this.rdo1_wdy.Checked = true;
			this.rdo1_wdy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.rdo1_wdy.Location = new System.Drawing.Point(12, 14);
			this.rdo1_wdy.Name = "rdo1_wdy";
			this.rdo1_wdy.Size = new System.Drawing.Size(67, 18);
			this.rdo1_wdy.TabIndex = 36;
			this.rdo1_wdy.TabStop = true;
			this.rdo1_wdy.Text = "未打印";
			this.rdo1_wdy.UseVisualStyleBackColor = true;
			this.rdo1_wdy.CheckedChanged += new System.EventHandler(this.rdo1_wdy_CheckedChanged);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel1);
			this.panel3.Controls.Add(this.txttxm);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.button1);
			this.panel3.Controls.Add(this.button2);
			this.panel3.Controls.Add(this.buthelp);
			this.panel3.Controls.Add(this.cmbklx);
			this.panel3.Controls.Add(this.txtkh);
			this.panel3.Controls.Add(this.btLookup);
			this.panel3.Controls.Add(this.rdo1_wdy);
			this.panel3.Controls.Add(this.txtmzh);
			this.panel3.Controls.Add(this.rdo1_ydy);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.dtp2);
			this.panel3.Controls.Add(this.dtp1);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.cmbhylx);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(904, 108);
			this.panel3.TabIndex = 38;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.rdow);
			this.panel1.Controls.Add(this.rdoy);
			this.panel1.Controls.Add(this.rdoall);
			this.panel1.Location = new System.Drawing.Point(444, 73);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(219, 32);
			this.panel1.TabIndex = 242;
			// 
			// rdow
			// 
			this.rdow.AutoSize = true;
			this.rdow.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.rdow.Location = new System.Drawing.Point(146, 8);
			this.rdow.Name = "rdow";
			this.rdow.Size = new System.Drawing.Size(71, 16);
			this.rdow.TabIndex = 40;
			this.rdow.Text = "无条形码";
			this.rdow.UseVisualStyleBackColor = true;
			// 
			// rdoy
			// 
			this.rdoy.AutoSize = true;
			this.rdoy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.rdoy.Location = new System.Drawing.Point(65, 9);
			this.rdoy.Name = "rdoy";
			this.rdoy.Size = new System.Drawing.Size(71, 16);
			this.rdoy.TabIndex = 39;
			this.rdoy.Text = "有条形码";
			this.rdoy.UseVisualStyleBackColor = true;
			// 
			// rdoall
			// 
			this.rdoall.AutoSize = true;
			this.rdoall.Checked = true;
			this.rdoall.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.rdoall.Location = new System.Drawing.Point(12, 9);
			this.rdoall.Name = "rdoall";
			this.rdoall.Size = new System.Drawing.Size(47, 16);
			this.rdoall.TabIndex = 38;
			this.rdoall.TabStop = true;
			this.rdoall.Text = "全部";
			this.rdoall.UseVisualStyleBackColor = true;
			// 
			// txttxm
			// 
			this.txttxm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txttxm.Location = new System.Drawing.Point(163, 76);
			this.txttxm.Name = "txttxm";
			this.txttxm.Size = new System.Drawing.Size(119, 23);
			this.txttxm.TabIndex = 241;
			this.txttxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttxm_KeyPress);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(107, 79);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(49, 14);
			this.label6.TabIndex = 240;
			this.label6.Text = "条形码";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button1.ForeColor = System.Drawing.Color.Black;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Location = new System.Drawing.Point(804, 14);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 34);
			this.button1.TabIndex = 238;
			this.button1.Text = "打印";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.Control;
			this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button2.ForeColor = System.Drawing.Color.Black;
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.Location = new System.Drawing.Point(804, 51);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 34);
			this.button2.TabIndex = 237;
			this.button2.Text = "关闭";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// buthelp
			// 
			this.buthelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buthelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buthelp.ImageIndex = 0;
			this.buthelp.ImageList = this.imageList2;
			this.buthelp.Location = new System.Drawing.Point(611, 46);
			this.buthelp.Name = "buthelp";
			this.buthelp.Size = new System.Drawing.Size(44, 22);
			this.buthelp.TabIndex = 236;
			this.buthelp.Text = "F1";
			this.buthelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buthelp.UseVisualStyleBackColor = true;
			this.buthelp.Click += new System.EventHandler(this.buthelp_Click);
			// 
			// imageList2
			// 
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList2.Images.SetKeyName(0, "VIEWER1.ICO");
			// 
			// cmbklx
			// 
			this.cmbklx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbklx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cmbklx.ForeColor = System.Drawing.Color.Navy;
			this.cmbklx.FormattingEnabled = true;
			this.cmbklx.Location = new System.Drawing.Point(362, 46);
			this.cmbklx.Name = "cmbklx";
			this.cmbklx.Size = new System.Drawing.Size(68, 22);
			this.cmbklx.TabIndex = 234;
			// 
			// txtkh
			// 
			this.txtkh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtkh.ForeColor = System.Drawing.Color.Navy;
			this.txtkh.Location = new System.Drawing.Point(436, 45);
			this.txtkh.Name = "txtkh";
			this.txtkh.Size = new System.Drawing.Size(172, 23);
			this.txtkh.TabIndex = 233;
			this.txtkh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtkh_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(311, 51);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 14);
			this.label5.TabIndex = 235;
			this.label5.Text = "卡类型";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Controls.Add(this.splitter1);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 108);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(904, 484);
			this.panel2.TabIndex = 40;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.dataGridView1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(233, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(671, 484);
			this.panel5.TabIndex = 21;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(230, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 484);
			this.splitter1.TabIndex = 20;
			this.splitter1.TabStop = false;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.panel7);
			this.panel4.Controls.Add(this.panel6);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(230, 484);
			this.panel4.TabIndex = 19;
			this.panel4.Visible = false;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.dataGridView2);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(0, 55);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(230, 429);
			this.panel7.TabIndex = 2;
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dataGridView2.ColumnHeadersHeight = 30;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.打印内容,
            this.打印时间,
            this.打印人,
            this.dyid});
			this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView2.Location = new System.Drawing.Point(0, 0);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.RowTemplate.Height = 23;
			this.dataGridView2.Size = new System.Drawing.Size(230, 429);
			this.dataGridView2.TabIndex = 0;
			this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
			// 
			// 打印内容
			// 
			this.打印内容.DataPropertyName = "打印内容";
			this.打印内容.HeaderText = "打印内容";
			this.打印内容.Name = "打印内容";
			this.打印内容.ReadOnly = true;
			// 
			// 打印时间
			// 
			this.打印时间.DataPropertyName = "打印时间";
			this.打印时间.HeaderText = "打印时间";
			this.打印时间.Name = "打印时间";
			this.打印时间.ReadOnly = true;
			// 
			// 打印人
			// 
			this.打印人.DataPropertyName = "打印人";
			this.打印人.HeaderText = "打印人";
			this.打印人.Name = "打印人";
			this.打印人.ReadOnly = true;
			// 
			// dyid
			// 
			this.dyid.DataPropertyName = "dyid";
			this.dyid.HeaderText = "dyid";
			this.dyid.Name = "dyid";
			this.dyid.ReadOnly = true;
			this.dyid.Visible = false;
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.butdycx);
			this.panel6.Controls.Add(this.label9);
			this.panel6.Controls.Add(this.dtpdyrq1);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(230, 55);
			this.panel6.TabIndex = 1;
			// 
			// butdycx
			// 
			this.butdycx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.butdycx.Location = new System.Drawing.Point(151, 25);
			this.butdycx.Name = "butdycx";
			this.butdycx.Size = new System.Drawing.Size(68, 24);
			this.butdycx.TabIndex = 29;
			this.butdycx.Text = "查询";
			this.butdycx.UseVisualStyleBackColor = true;
			this.butdycx.Click += new System.EventHandler(this.butdycx_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label9.Location = new System.Drawing.Point(5, 4);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(63, 14);
			this.label9.TabIndex = 28;
			this.label9.Text = "打印时间";
			// 
			// dtpdyrq1
			// 
			this.dtpdyrq1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtpdyrq1.Location = new System.Drawing.Point(29, 25);
			this.dtpdyrq1.Name = "dtpdyrq1";
			this.dtpdyrq1.Size = new System.Drawing.Size(119, 23);
			this.dtpdyrq1.TabIndex = 27;
			// 
			// Frmmzqddy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(904, 592);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.lblCaption);
			this.Name = "Frmmzqddy";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "门诊检验清单打印";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Jyqddy_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btLookup;
        private Label label1;
        private Label label2;
        private DateTimePicker dtp1;
        private DateTimePicker dtp2;
        private TextBox txtmzh;
        private Label label4;
        private Label label3;
        private ComboBox cmbhylx;
        private Panel panel3;
        private RadioButton rdo1_ydy;
        private RadioButton rdo1_wdy;
        private Panel panel2;
        private Panel panel5;
        private Splitter splitter1;
        private Panel panel4;
        private DataGridView dataGridView2;
        private Panel panel7;
        private Panel panel6;
        private Button butdycx;
        private Label label9;
        private DateTimePicker dtpdyrq1;
        private DataGridView dataGridView1;


        public Frmmzqddy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
           
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void ShowData(long printID)//显示数据
        {
            string BDate = "";
            string EDate = "";
             BDate = this.dtp1.Value.ToShortDateString()+" 00:00:00";
             EDate = this.dtp2.Value.ToShortDateString() + " 23:59:59";


             ReadCard _card = new ReadCard(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text.Trim(), InstanceForm.BDatabase);

             int btxm = 2;
             if (rdoy.Checked == true) btxm = 1;
             if (rdow.Checked == true) btxm = 0;
            ParameterEx[] _parameters = new ParameterEx[10];
            _parameters[0].Text = "@MZH";
            _parameters[0].Value = txtmzh.Text.Trim();
            _parameters[1].Text = "@BRXXID";
            _parameters[1].Value = _card.brxxid;
            _parameters[2].Text = "@jylx";
            _parameters[2].Value = cmbhylx.Text.Trim();
            _parameters[3].Text = "bdate";
            _parameters[3].Value = BDate;
            _parameters[4].Text = "edate";
            _parameters[4].Value = EDate;
            _parameters[5].Text = "execdept_id";
            _parameters[5].Value = InstanceForm.BCurrentDept.DeptId;
            _parameters[6].Text = "printid";
            _parameters[6].Value = printID;
            _parameters[7].Text = "dybz";
            _parameters[7].Value = rdo1_wdy.Checked==true?0:1 ;
            _parameters[8].Text = "txm";
            _parameters[8].Value = txttxm.Text.Trim();
            _parameters[9].Text = "btxm";
            _parameters[9].Value = btxm;
            DataTable dV = new DataTable();
            try
            {
                dV = FrmMdiMain.Database.GetDataTable("SP_YJ_mzSQ_JYDDY", _parameters);
                dataGridView1.DataSource = dV;
                Fun.AddRowtNo(dV);
            }
            catch (Exception err)
            {
                MessageBox.Show("执行 查询 时出错！\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }        

        private void btLookup_Click(object sender, EventArgs e)
        {            
           ShowData(0);  
        }

        private void btnPrint_Click(object sender, EventArgs e)//打印
        { 
            try
            {

                DataTable tbmx = (DataTable)dataGridView1.DataSource;

                if (tbmx.Rows.Count == 0) return;
                #region  打印状态
                string id = "";
                string sql = "";
                for (int i = 0; i <= this.dataGridView1.Rows.Count - 1; i++)
                {
                    string name = "'"+this.dataGridView1.Rows[i].Cells[0].Value.ToString()+"'";
                    id += name + ",";
                }
                if (true)
                {
                    id = Convert.ToString(id.Remove(id.Length - 1));
                }

                int dybz = 0;
                dybz = rdo1_wdy.Checked == true ? 0 : 1;
                if (dybz == 0)
                {
                    try
                    {
                        InstanceForm.BDatabase.BeginTransaction();
                        string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                        int lx = 2;
                        string dylr = cmbhylx.Text.Trim();
                        sql = "insert into yj_dyjl(dylx,dylr,djsj,djy)values(" + lx + ",'" + dylr + "','" + _sDate + "'," + InstanceForm.BCurrentUser.EmployeeId + ")";
                        InstanceForm.BDatabase.DoCommand(sql);
                        sql = "select @@IDENTITY";
                        long _printid = Convert.ToInt64(InstanceForm.BDatabase.GetDataResult(sql));

                        sql = "update yj_mzsq set BJLDYBZ=1,JLDYPC='" + _printid + "' where yjsqid in (" + id + ")";
                        int iii = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql, 30);
                        InstanceForm.BDatabase.CommitTransaction();


                    }
                    catch (System.Exception err)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        MessageBox.Show(err.Message, "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                #endregion


                DataSet1 Dset = new DataSet1();
                int x = 0;
                DataRow myrow = Dset.项目.NewRow();
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    if (dataGridView1.Columns[i].Visible == true)
                    {
                        x = x + 1;
                        string nm = "T" + x.ToString();
                        myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
                    }
                }
                Dset.项目.Rows.Add(myrow);

                
                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    DataRow myrow1 = Dset.项目内容.NewRow();
                    x = 0;
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                       
                        if (dataGridView1.Columns[i].Visible == true)
                        {
                             x = x + 1;
                            string nm = "JE" + x.ToString();
                            myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
                        }
                    }
                    Dset.项目内容.Rows.Add(myrow1);
                }


                ParameterEx[] _parameters = new ParameterEx[4];

                _parameters[0].Text = "医院名称";
                _parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;
                _parameters[1].Text = "rq1";
                _parameters[1].Value = this.dtp1.Value.Date.ToString();
                _parameters[2].Text = "rq2";
                _parameters[2].Value = this.dtp2.Value.Date.ToString();
                _parameters[3].Text = "cd";
                _parameters[3].Value = "";
                if (rdo1_ydy.Checked == true )
                {
                    _parameters[3].Value = "重打";
                }

                TrasenFrame.Forms.FrmReportView f;

                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\YJ_门诊检验清单.rpt", _parameters);

                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();


                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (tb == null) return;
                tb.Rows.Clear();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ReadOnly = true;            
        }


        private void Jyqddy_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.rdo1_wdy.Checked = true;
            ts_mz_class.FunAddComboBox.AddKlx(false, 0, cmbklx);

            LoadJCCLASSDICTION();

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);

        }


        private void LoadJCCLASSDICTION()
        {
            string sSql = "";
            DataTable myTb = new DataTable();

            sSql = "select '0' id,' ' name union all select id,name from JC_JCCLASSDICTION where class_type=1";
            myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            cmbhylx.DataSource = myTb;
            cmbhylx.DisplayMember = "name";
            cmbhylx.ValueMember = "id";
            cmbhylx.SelectedIndex = 0;
        }


        private void txtzyh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    txtmzh.Text = Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                    ShowData(0);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }




        private void rdo1_wdy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo1_wdy.Checked==true)
                panel4.Visible = false;
            else
                panel4.Visible = true;
  
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb == null) return;
            tb.Rows.Clear();
        }

  

        private void butdycx_Click(object sender, EventArgs e)
        {
            int lx = 2;
            string bdate = dtpdyrq1.Value.ToShortDateString() + " 00:00:00";
            string edate = dtpdyrq1.Value.ToShortDateString() + " 23:59:59";
            string ssql = "select dylr 打印内容,djsj 打印时间,dbo.fun_getempname(djy) 打印人,id dyid from yj_dyjl where dylx="+lx+" and djsj>='"+bdate+"' and djsj<='"+edate+"'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            this.dataGridView2.DataSource = tb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData(0);
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell == null) return;
            DataTable tb = (DataTable)this.dataGridView2.DataSource;
            if (tb == null) return;
            int nrow = dataGridView2.CurrentCell.RowIndex;
            long _printid = Convert.ToInt64(tb.Rows[nrow]["dyid"]);
            ShowData(_printid);
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if ((int)e.KeyChar == 13)
                {
                    string kh = txtkh.Text.Trim();
                    int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                    txtkh.Text = Fun.returnKh(klx, txtkh.Text,InstanceForm.BDatabase);
                    ShowData(0);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txttxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if ((int)e.KeyChar == 13)
                {
                    ShowData(0);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buthelp_Click(object sender, EventArgs e)
        {
            try
            {


                MenuTag tag = new MenuTag();
                tag = _menuTag;
                //tag.Function_Name = "Fun_ts_mz_kgl_kdj";
                //tag.DllName = "ts_mz_gh";
                ts_mz_kgl.Frmbrxxcx f = new ts_mz_kgl.Frmbrxxcx(tag, "病人查询", null);
                //f.txtbrxm.Text = txtxm.Text;
                //if (txtxm.Text.Trim() == "")
                f.chkdjsj.Checked = true;
                f.txtbrxm.Focus();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();

                ReadCard card = new ReadCard(f.return_kdjid, InstanceForm.BDatabase);
                if (card.kdjid != Guid.Empty)
                {
                    cmbklx.SelectedValue = card.klx;
                    txtkh.Text = card.kh;
                    txtkh.Focus();
                    txtkh_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
                }
                else
                {
                    if (f.bok == true)
                    {
                        MessageBox.Show("只能检索有卡的病人", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
    }
   
}

