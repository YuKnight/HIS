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

namespace ts_yf_cx
{
	/// <summary>
	/// Frmdjcx 的摘要说明。
	/// </summary>
    public class Frmdjhz_fkbl : System.Windows.Forms.Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.StatusBarPanel statusBarPanel4;
        private System.Windows.Forms.Label lbldjlx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkdjsj;
        private System.Windows.Forms.CheckBox chkrq;
        private System.Windows.Forms.CheckBox chkshrq;
        private System.Windows.Forms.CheckBox chkdjh;
        private System.Windows.Forms.CheckBox chkwldw;
        private System.Windows.Forms.CheckBox chkshdh;
        private System.Windows.Forms.CheckBox chkfph;
        private System.Windows.Forms.CheckBox chkypmc;
        private System.Windows.Forms.CheckBox chkdjbz;
        private System.Windows.Forms.ComboBox cmbdjlx;
        private System.Windows.Forms.DateTimePicker dtpdjsj2;
        private System.Windows.Forms.DateTimePicker dtpdjsj1;
        private System.Windows.Forms.DateTimePicker dtprq2;
        private System.Windows.Forms.DateTimePicker dtprq1;
        private System.Windows.Forms.DateTimePicker dtpshrq2;
        private System.Windows.Forms.DateTimePicker dtpshrq1;
        private System.Windows.Forms.TextBox txtdjh;
        private System.Windows.Forms.TextBox txtwldw;
        private System.Windows.Forms.TextBox txtshdh;
        private System.Windows.Forms.TextBox txtfph;
        private System.Windows.Forms.TextBox txtypmc;
        private System.Windows.Forms.TextBox txtdjbz;
        private System.Windows.Forms.Button butlook;
        private System.Windows.Forms.Button butclear;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chktjwh;
        private System.Windows.Forms.TextBox txttjwh;
        private System.Windows.Forms.Label lblshrq;
        private System.Windows.Forms.Label lblrq;
        private System.ComponentModel.Container components = null;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private TextBox txtdjhY;
        private CheckBox chkdjhY;
        private ComboBox cmbck;
        private Label lblck;
        private Button butprint1;
        private ComboBox cmbywy;
        private CheckBox chkywy;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn 序号;
        private DataGridViewTextBoxColumn 往来单位;
        private DataGridViewTextBoxColumn 商品名;
        private DataGridViewTextBoxColumn 规格;
        private DataGridViewTextBoxColumn 厂家;
        private DataGridViewTextBoxColumn 付款比例;
        private DataGridViewTextBoxColumn 折扣金额;
        private DataGridViewTextBoxColumn 付款金额;
        private DataGridViewTextBoxColumn 进货金额;
        private string _chineseName;

        public Frmdjhz_fkbl(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = chineseName;
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
            this.cmbdjlx = new System.Windows.Forms.ComboBox();
            this.lbldjlx = new System.Windows.Forms.Label();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.lblck = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butclear = new System.Windows.Forms.Button();
            this.butlook = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbywy = new System.Windows.Forms.ComboBox();
            this.butprint1 = new System.Windows.Forms.Button();
            this.txtdjhY = new System.Windows.Forms.TextBox();
            this.chkdjhY = new System.Windows.Forms.CheckBox();
            this.txttjwh = new System.Windows.Forms.TextBox();
            this.chktjwh = new System.Windows.Forms.CheckBox();
            this.txtdjbz = new System.Windows.Forms.TextBox();
            this.chkdjbz = new System.Windows.Forms.CheckBox();
            this.txtypmc = new System.Windows.Forms.TextBox();
            this.chkypmc = new System.Windows.Forms.CheckBox();
            this.txtfph = new System.Windows.Forms.TextBox();
            this.chkfph = new System.Windows.Forms.CheckBox();
            this.txtshdh = new System.Windows.Forms.TextBox();
            this.chkshdh = new System.Windows.Forms.CheckBox();
            this.txtwldw = new System.Windows.Forms.TextBox();
            this.chkwldw = new System.Windows.Forms.CheckBox();
            this.txtdjh = new System.Windows.Forms.TextBox();
            this.chkdjh = new System.Windows.Forms.CheckBox();
            this.dtpshrq2 = new System.Windows.Forms.DateTimePicker();
            this.lblshrq = new System.Windows.Forms.Label();
            this.dtpshrq1 = new System.Windows.Forms.DateTimePicker();
            this.chkshrq = new System.Windows.Forms.CheckBox();
            this.dtprq2 = new System.Windows.Forms.DateTimePicker();
            this.lblrq = new System.Windows.Forms.Label();
            this.dtprq1 = new System.Windows.Forms.DateTimePicker();
            this.chkrq = new System.Windows.Forms.CheckBox();
            this.dtpdjsj2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpdjsj1 = new System.Windows.Forms.DateTimePicker();
            this.chkdjsj = new System.Windows.Forms.CheckBox();
            this.chkywy = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.往来单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.规格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.厂家 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.付款比例 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.折扣金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.付款金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.进货金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbdjlx
            // 
            this.cmbdjlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdjlx.Enabled = false;
            this.cmbdjlx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbdjlx.Location = new System.Drawing.Point(275, 6);
            this.cmbdjlx.Name = "cmbdjlx";
            this.cmbdjlx.Size = new System.Drawing.Size(216, 22);
            this.cmbdjlx.TabIndex = 0;
            this.cmbdjlx.SelectedIndexChanged += new System.EventHandler(this.cmbdjlx_SelectedIndexChanged);
            // 
            // lbldjlx
            // 
            this.lbldjlx.ForeColor = System.Drawing.Color.Navy;
            this.lbldjlx.Location = new System.Drawing.Point(221, 11);
            this.lbldjlx.Name = "lbldjlx";
            this.lbldjlx.Size = new System.Drawing.Size(72, 16);
            this.lbldjlx.TabIndex = 0;
            this.lbldjlx.Text = "单据类型";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 468);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1000, 25);
            this.statusBar1.TabIndex = 2;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 200;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 200;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 200;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Width = 200;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.cmbck);
            this.panel1.Controls.Add(this.lblck);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butclear);
            this.panel1.Controls.Add(this.butlook);
            this.panel1.Controls.Add(this.cmbdjlx);
            this.panel1.Controls.Add(this.lbldjlx);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 34);
            this.panel1.TabIndex = 3;
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Location = new System.Drawing.Point(65, 7);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(140, 20);
            this.cmbck.TabIndex = 38;
            // 
            // lblck
            // 
            this.lblck.Location = new System.Drawing.Point(12, 11);
            this.lblck.Name = "lblck";
            this.lblck.Size = new System.Drawing.Size(67, 16);
            this.lblck.TabIndex = 37;
            this.lblck.Text = "药剂科室";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(931, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(144, 24);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "所含备份表";
            this.checkBox1.Visible = false;
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.Blue;
            this.butquit.Location = new System.Drawing.Point(851, 5);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(73, 24);
            this.butquit.TabIndex = 5;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprint.ForeColor = System.Drawing.Color.Blue;
            this.butprint.Location = new System.Drawing.Point(782, 5);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(63, 24);
            this.butprint.TabIndex = 4;
            this.butprint.Text = "打印(&P)";
            this.butprint.UseVisualStyleBackColor = false;
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butclear
            // 
            this.butclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butclear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butclear.ForeColor = System.Drawing.Color.Blue;
            this.butclear.Location = new System.Drawing.Point(708, 5);
            this.butclear.Name = "butclear";
            this.butclear.Size = new System.Drawing.Size(70, 24);
            this.butclear.TabIndex = 3;
            this.butclear.Text = "清除(&C)";
            this.butclear.UseVisualStyleBackColor = false;
            this.butclear.Click += new System.EventHandler(this.butclear_Click);
            // 
            // butlook
            // 
            this.butlook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butlook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butlook.ForeColor = System.Drawing.Color.Blue;
            this.butlook.Location = new System.Drawing.Point(628, 5);
            this.butlook.Name = "butlook";
            this.butlook.Size = new System.Drawing.Size(74, 24);
            this.butlook.TabIndex = 2;
            this.butlook.Text = "查询(&T)";
            this.butlook.UseVisualStyleBackColor = false;
            this.butlook.Click += new System.EventHandler(this.butlook_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbywy);
            this.groupBox1.Controls.Add(this.butprint1);
            this.groupBox1.Controls.Add(this.txtdjhY);
            this.groupBox1.Controls.Add(this.chkdjhY);
            this.groupBox1.Controls.Add(this.txttjwh);
            this.groupBox1.Controls.Add(this.chktjwh);
            this.groupBox1.Controls.Add(this.txtdjbz);
            this.groupBox1.Controls.Add(this.chkdjbz);
            this.groupBox1.Controls.Add(this.txtypmc);
            this.groupBox1.Controls.Add(this.chkypmc);
            this.groupBox1.Controls.Add(this.txtfph);
            this.groupBox1.Controls.Add(this.chkfph);
            this.groupBox1.Controls.Add(this.txtshdh);
            this.groupBox1.Controls.Add(this.chkshdh);
            this.groupBox1.Controls.Add(this.txtwldw);
            this.groupBox1.Controls.Add(this.chkwldw);
            this.groupBox1.Controls.Add(this.txtdjh);
            this.groupBox1.Controls.Add(this.chkdjh);
            this.groupBox1.Controls.Add(this.dtpshrq2);
            this.groupBox1.Controls.Add(this.lblshrq);
            this.groupBox1.Controls.Add(this.dtpshrq1);
            this.groupBox1.Controls.Add(this.chkshrq);
            this.groupBox1.Controls.Add(this.dtprq2);
            this.groupBox1.Controls.Add(this.lblrq);
            this.groupBox1.Controls.Add(this.dtprq1);
            this.groupBox1.Controls.Add(this.chkrq);
            this.groupBox1.Controls.Add(this.dtpdjsj2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpdjsj1);
            this.groupBox1.Controls.Add(this.chkdjsj);
            this.groupBox1.Controls.Add(this.chkywy);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 110);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // cmbywy
            // 
            this.cmbywy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbywy.Enabled = false;
            this.cmbywy.ForeColor = System.Drawing.Color.Navy;
            this.cmbywy.Location = new System.Drawing.Point(250, 78);
            this.cmbywy.Name = "cmbywy";
            this.cmbywy.Size = new System.Drawing.Size(123, 20);
            this.cmbywy.TabIndex = 40;
            // 
            // butprint1
            // 
            this.butprint1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butprint1.Enabled = false;
            this.butprint1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprint1.ForeColor = System.Drawing.Color.Blue;
            this.butprint1.Location = new System.Drawing.Point(784, 71);
            this.butprint1.Name = "butprint1";
            this.butprint1.Size = new System.Drawing.Size(112, 24);
            this.butprint1.TabIndex = 39;
            this.butprint1.Text = "打印采购明细";
            this.butprint1.UseVisualStyleBackColor = false;
            this.butprint1.Visible = false;
            this.butprint1.Click += new System.EventHandler(this.butprint1_Click);
            // 
            // txtdjhY
            // 
            this.txtdjhY.Enabled = false;
            this.txtdjhY.Location = new System.Drawing.Point(708, 76);
            this.txtdjhY.Name = "txtdjhY";
            this.txtdjhY.Size = new System.Drawing.Size(70, 21);
            this.txtdjhY.TabIndex = 37;
            // 
            // chkdjhY
            // 
            this.chkdjhY.Location = new System.Drawing.Point(628, 74);
            this.chkdjhY.Name = "chkdjhY";
            this.chkdjhY.Size = new System.Drawing.Size(90, 24);
            this.chkdjhY.TabIndex = 38;
            this.chkdjhY.Text = "单据号(月)";
            this.chkdjhY.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // txttjwh
            // 
            this.txttjwh.Enabled = false;
            this.txttjwh.Location = new System.Drawing.Point(851, 44);
            this.txttjwh.Name = "txttjwh";
            this.txttjwh.Size = new System.Drawing.Size(80, 21);
            this.txttjwh.TabIndex = 11;
            // 
            // chktjwh
            // 
            this.chktjwh.Location = new System.Drawing.Point(782, 42);
            this.chktjwh.Name = "chktjwh";
            this.chktjwh.Size = new System.Drawing.Size(80, 24);
            this.chktjwh.TabIndex = 36;
            this.chktjwh.Text = "调价文号";
            this.chktjwh.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // txtdjbz
            // 
            this.txtdjbz.Enabled = false;
            this.txtdjbz.Location = new System.Drawing.Point(74, 78);
            this.txtdjbz.Name = "txtdjbz";
            this.txtdjbz.Size = new System.Drawing.Size(108, 21);
            this.txtdjbz.TabIndex = 12;
            // 
            // chkdjbz
            // 
            this.chkdjbz.Location = new System.Drawing.Point(6, 76);
            this.chkdjbz.Name = "chkdjbz";
            this.chkdjbz.Size = new System.Drawing.Size(80, 24);
            this.chkdjbz.TabIndex = 34;
            this.chkdjbz.Text = "单据备注";
            this.chkdjbz.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // txtypmc
            // 
            this.txtypmc.Enabled = false;
            this.txtypmc.Location = new System.Drawing.Point(450, 78);
            this.txtypmc.Name = "txtypmc";
            this.txtypmc.Size = new System.Drawing.Size(170, 21);
            this.txtypmc.TabIndex = 13;
            this.txtypmc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // chkypmc
            // 
            this.chkypmc.Location = new System.Drawing.Point(379, 77);
            this.chkypmc.Name = "chkypmc";
            this.chkypmc.Size = new System.Drawing.Size(80, 24);
            this.chkypmc.TabIndex = 32;
            this.chkypmc.Text = "药品名称";
            this.chkypmc.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // txtfph
            // 
            this.txtfph.Enabled = false;
            this.txtfph.Location = new System.Drawing.Point(691, 45);
            this.txtfph.Name = "txtfph";
            this.txtfph.Size = new System.Drawing.Size(79, 21);
            this.txtfph.TabIndex = 10;
            // 
            // chkfph
            // 
            this.chkfph.Location = new System.Drawing.Point(626, 43);
            this.chkfph.Name = "chkfph";
            this.chkfph.Size = new System.Drawing.Size(81, 24);
            this.chkfph.TabIndex = 30;
            this.chkfph.Text = "发票号";
            this.chkfph.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // txtshdh
            // 
            this.txtshdh.Enabled = false;
            this.txtshdh.Location = new System.Drawing.Point(538, 45);
            this.txtshdh.Name = "txtshdh";
            this.txtshdh.Size = new System.Drawing.Size(82, 21);
            this.txtshdh.TabIndex = 9;
            // 
            // chkshdh
            // 
            this.chkshdh.Location = new System.Drawing.Point(468, 43);
            this.chkshdh.Name = "chkshdh";
            this.chkshdh.Size = new System.Drawing.Size(80, 24);
            this.chkshdh.TabIndex = 28;
            this.chkshdh.Text = "送货单号";
            this.chkshdh.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // txtwldw
            // 
            this.txtwldw.Enabled = false;
            this.txtwldw.Location = new System.Drawing.Point(223, 45);
            this.txtwldw.Name = "txtwldw";
            this.txtwldw.Size = new System.Drawing.Size(228, 21);
            this.txtwldw.TabIndex = 8;
            this.txtwldw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // chkwldw
            // 
            this.chkwldw.Location = new System.Drawing.Point(154, 44);
            this.chkwldw.Name = "chkwldw";
            this.chkwldw.Size = new System.Drawing.Size(80, 24);
            this.chkwldw.TabIndex = 26;
            this.chkwldw.Text = "往来单位";
            this.chkwldw.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // txtdjh
            // 
            this.txtdjh.Enabled = false;
            this.txtdjh.Location = new System.Drawing.Point(74, 45);
            this.txtdjh.Name = "txtdjh";
            this.txtdjh.Size = new System.Drawing.Size(70, 21);
            this.txtdjh.TabIndex = 7;
            // 
            // chkdjh
            // 
            this.chkdjh.Location = new System.Drawing.Point(6, 43);
            this.chkdjh.Name = "chkdjh";
            this.chkdjh.Size = new System.Drawing.Size(72, 24);
            this.chkdjh.TabIndex = 24;
            this.chkdjh.Text = "单据号";
            this.chkdjh.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // dtpshrq2
            // 
            this.dtpshrq2.Enabled = false;
            this.dtpshrq2.Location = new System.Drawing.Point(821, 14);
            this.dtpshrq2.Name = "dtpshrq2";
            this.dtpshrq2.Size = new System.Drawing.Size(110, 21);
            this.dtpshrq2.TabIndex = 6;
            // 
            // lblshrq
            // 
            this.lblshrq.ForeColor = System.Drawing.Color.Navy;
            this.lblshrq.Location = new System.Drawing.Point(806, 18);
            this.lblshrq.Name = "lblshrq";
            this.lblshrq.Size = new System.Drawing.Size(24, 16);
            this.lblshrq.TabIndex = 21;
            this.lblshrq.Text = "到";
            // 
            // dtpshrq1
            // 
            this.dtpshrq1.Enabled = false;
            this.dtpshrq1.Location = new System.Drawing.Point(696, 14);
            this.dtpshrq1.Name = "dtpshrq1";
            this.dtpshrq1.Size = new System.Drawing.Size(110, 21);
            this.dtpshrq1.TabIndex = 5;
            // 
            // chkshrq
            // 
            this.chkshrq.Location = new System.Drawing.Point(624, 13);
            this.chkshrq.Name = "chkshrq";
            this.chkshrq.Size = new System.Drawing.Size(80, 21);
            this.chkshrq.TabIndex = 23;
            this.chkshrq.Text = "审核时间";
            this.chkshrq.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // dtprq2
            // 
            this.dtprq2.Enabled = false;
            this.dtprq2.Location = new System.Drawing.Point(506, 14);
            this.dtprq2.Name = "dtprq2";
            this.dtprq2.Size = new System.Drawing.Size(111, 21);
            this.dtprq2.TabIndex = 4;
            // 
            // lblrq
            // 
            this.lblrq.ForeColor = System.Drawing.Color.Navy;
            this.lblrq.Location = new System.Drawing.Point(492, 19);
            this.lblrq.Name = "lblrq";
            this.lblrq.Size = new System.Drawing.Size(24, 15);
            this.lblrq.TabIndex = 17;
            this.lblrq.Text = "到";
            // 
            // dtprq1
            // 
            this.dtprq1.Enabled = false;
            this.dtprq1.Location = new System.Drawing.Point(380, 14);
            this.dtprq1.Name = "dtprq1";
            this.dtprq1.Size = new System.Drawing.Size(111, 21);
            this.dtprq1.TabIndex = 3;
            // 
            // chkrq
            // 
            this.chkrq.Location = new System.Drawing.Point(311, 13);
            this.chkrq.Name = "chkrq";
            this.chkrq.Size = new System.Drawing.Size(80, 21);
            this.chkrq.TabIndex = 19;
            this.chkrq.Text = "单据时间";
            this.chkrq.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // dtpdjsj2
            // 
            this.dtpdjsj2.Enabled = false;
            this.dtpdjsj2.Location = new System.Drawing.Point(196, 14);
            this.dtpdjsj2.Name = "dtpdjsj2";
            this.dtpdjsj2.Size = new System.Drawing.Size(110, 21);
            this.dtpdjsj2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(181, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "到";
            // 
            // dtpdjsj1
            // 
            this.dtpdjsj1.Enabled = false;
            this.dtpdjsj1.Location = new System.Drawing.Point(74, 14);
            this.dtpdjsj1.Name = "dtpdjsj1";
            this.dtpdjsj1.Size = new System.Drawing.Size(108, 21);
            this.dtpdjsj1.TabIndex = 1;
            // 
            // chkdjsj
            // 
            this.chkdjsj.Location = new System.Drawing.Point(6, 13);
            this.chkdjsj.Name = "chkdjsj";
            this.chkdjsj.Size = new System.Drawing.Size(80, 21);
            this.chkdjsj.TabIndex = 15;
            this.chkdjsj.Text = "登记时间";
            this.chkdjsj.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // chkywy
            // 
            this.chkywy.Location = new System.Drawing.Point(190, 76);
            this.chkywy.Name = "chkywy";
            this.chkywy.Size = new System.Drawing.Size(80, 24);
            this.chkywy.TabIndex = 41;
            this.chkywy.Text = "业务员";
            this.chkywy.CheckedChanged += new System.EventHandler(this.chkdjbz_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.往来单位,
            this.商品名,
            this.规格,
            this.厂家,
            this.付款比例,
            this.折扣金额,
            this.付款金额,
            this.进货金额});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1000, 324);
            this.dataGridView1.TabIndex = 5;
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "序号";
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.Width = 60;
            // 
            // 往来单位
            // 
            this.往来单位.DataPropertyName = "往来单位";
            this.往来单位.HeaderText = "往来单位";
            this.往来单位.Name = "往来单位";
            this.往来单位.Width = 180;
            // 
            // 商品名
            // 
            this.商品名.DataPropertyName = "商品名";
            this.商品名.HeaderText = "商品名";
            this.商品名.Name = "商品名";
            this.商品名.Width = 150;
            // 
            // 规格
            // 
            this.规格.DataPropertyName = "规格";
            this.规格.HeaderText = "规格";
            this.规格.Name = "规格";
            // 
            // 厂家
            // 
            this.厂家.DataPropertyName = "厂家";
            this.厂家.HeaderText = "厂家";
            this.厂家.Name = "厂家";
            // 
            // 付款比例
            // 
            this.付款比例.DataPropertyName = "付款比例";
            this.付款比例.HeaderText = "付款比例";
            this.付款比例.Name = "付款比例";
            // 
            // 折扣金额
            // 
            this.折扣金额.DataPropertyName = "折扣金额";
            this.折扣金额.HeaderText = "折扣金额";
            this.折扣金额.Name = "折扣金额";
            // 
            // 付款金额
            // 
            this.付款金额.DataPropertyName = "付款金额";
            this.付款金额.HeaderText = "付款金额";
            this.付款金额.Name = "付款金额";
            // 
            // 进货金额
            // 
            this.进货金额.DataPropertyName = "进货金额";
            this.进货金额.HeaderText = "进货金额";
            this.进货金额.Name = "进货金额";
            // 
            // Frmdjhz_fkbl
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1000, 493);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.Name = "Frmdjhz_fkbl";
            this.Text = "单据查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmdjcx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        //查询条件的选择事件
        private void chkdjbz_CheckedChanged(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if(tb!=null)
            tb.Rows.Clear();
            dtpdjsj1.Enabled = chkdjsj.Checked == true ? true : false;
            dtpdjsj2.Enabled = chkdjsj.Checked == true ? true : false;
            dtprq1.Enabled = chkrq.Checked == true ? true : false;
            dtprq2.Enabled = chkrq.Checked == true ? true : false;
            dtpshrq1.Enabled = chkshrq.Checked == true ? true : false;
            dtpshrq2.Enabled = chkshrq.Checked == true ? true : false;
            txtdjh.Enabled = chkdjh.Checked == true ? true : false;
            txtwldw.Enabled = chkwldw.Checked == true ? true : false;
            txtshdh.Enabled = chkshdh.Checked == true ? true : false;
            txtfph.Enabled = chkfph.Checked == true ? true : false;
            txtdjbz.Enabled = chkdjbz.Checked == true ? true : false;
            txtypmc.Enabled = chkypmc.Checked == true ? true : false;
            txttjwh.Enabled = chktjwh.Checked == true ? true : false;
            txtdjhY.Enabled = chkdjhY.Checked == true ? true : false;
            cmbywy.Enabled = chkywy.Checked == true ? true : false;
        }

        //窗口加载事件
        private void Frmdjcx_Load(object sender, System.EventArgs e)
        {
            //Yp.AddcmbYwlx(InstanceForm.BCurrentDept.DeptId, cmbdjlx, InstanceForm.BDatabase);

            string ssql = "";
            ssql = "select YWMC,YWLX FROM Yf_YWLX WHERE YWZT=1 ORDER BY YWLX";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            cmbdjlx.ValueMember = "YWLX";
            cmbdjlx.DisplayMember = "YWMC";
            cmbdjlx.DataSource = tb;
            
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();
            this.dtpdjsj1.Value = Convert.ToDateTime(sDate);
            this.dtpdjsj2.Value = Convert.ToDateTime(sDate);
            this.dtprq1.Value = Convert.ToDateTime(sDate);
            this.dtprq2.Value = Convert.ToDateTime(sDate);
            this.dtpshrq1.Value = Convert.ToDateTime(sDate);
            this.dtpshrq2.Value = Convert.ToDateTime(sDate);

            Yp.AddcmbYjks(cmbck, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
            chkdjsj.Checked = true;
        }

        //查询按钮事件
        private void butlook_Click(object sender, System.EventArgs e)
        {
            string ywlx = cmbdjlx.SelectedValue.ToString();
            string sdtpdjsj1 = chkdjsj.Checked == true && chkdjsj.Visible==true ? this.dtpdjsj1.Value.ToShortDateString() : "";
            string sdtpdjsj2 = chkdjsj.Checked == true && chkdjsj.Visible==true ? this.dtpdjsj2.Value.ToShortDateString() : "";
            string sdtprq1 = chkrq.Checked == true && chkrq.Visible==true ? this.dtprq1.Value.ToShortDateString() : "";
            string sdtprq2 = chkrq.Checked == true && chkrq.Visible==true ? this.dtprq2.Value.ToShortDateString() : "";
            string sdtpshrq1 = chkshrq.Checked == true && chkshrq.Visible==true ? this.dtpshrq1.Value.ToShortDateString() : "";
            string sdtpshrq2 = chkshrq.Checked == true && chkshrq.Visible==true ? this.dtpshrq2.Value.ToShortDateString() : "";
            long djh = this.chkdjh.Checked == true && chkdjh.Visible==true ? Convert.ToInt64(Convertor.IsNull(txtdjh.Text, "0")) : 0;
            long wldw = this.chkwldw.Checked == true && chkwldw.Visible==true ? Convert.ToInt64(Convertor.IsNull(txtwldw.Tag, "0")) : 0;
            string shdh = chkshdh.Checked == true && chkshdh.Visible==true ? txtshdh.Text.Trim() : "";
            string fph = chkfph.Checked == true && chkfph.Visible==true ? txtfph.Text.Trim() : "";
            string djbz = chkdjbz.Checked == true ? txtdjbz.Text.Trim() : "";
            int cjid = chkypmc.Checked == true && chkypmc.Visible==true ? Convert.ToInt32(Convertor.IsNull(txtypmc.Tag, "0")) : 0;
            string tjwh = chktjwh.Checked == true && chktjwh.Checked==true ? txttjwh.Text.Trim() : "";
            long deptid = Convert.ToInt32(cmbck.SelectedValue);
            string sdjh = txtdjhY.Text.Trim();
            int ywy = chkywy.Checked == true && chkywy.Visible==true ? Convert.ToInt32(Convertor.IsNull(cmbywy.SelectedValue, "0")) : 0;

            try
            {

                ParameterEx[] parameters = new ParameterEx[18];
                parameters[0].Value = ywlx;
                parameters[1].Value = sdtpdjsj1;
                parameters[2].Value = sdtpdjsj2;
                parameters[3].Value = sdtprq1;
                parameters[4].Value = sdtprq2;
                parameters[5].Value = sdtpshrq1;
                parameters[6].Value = sdtpshrq2;
                parameters[7].Value = djh;
                parameters[8].Value = wldw;
                parameters[9].Value = shdh;
                parameters[10].Value = fph;
                parameters[11].Value = djbz;
                parameters[12].Value = cjid;
                parameters[13].Value = tjwh;
                parameters[14].Value = deptid;
                parameters[15].Value = sdjh;
                parameters[16].Value = deptid;
                parameters[17].Value =ywy;

                parameters[0].Text = "@ywlx";
                parameters[1].Text = "@dtpdjsj1";
                parameters[2].Text = "@dtpdjsj2";
                parameters[3].Text = "@dtprq1";
                parameters[4].Text = "@dtprq2";
                parameters[5].Text = "@dtpshrq1";
                parameters[6].Text = "@dtpshrq2";
                parameters[7].Text = "@djh";
                parameters[8].Text = "@wldw";
                parameters[9].Text = "@shdh";
                parameters[10].Text = "@fph";
                parameters[11].Text = "@djbz";
                parameters[12].Text = "@cjid";
                parameters[13].Text = "@tjwh";
                parameters[14].Text = "@deptid";
                parameters[15].Text = "@sdjh";
                parameters[16].Text = "@deptid_ck";
                parameters[17].Text = "@ywy";

                DataTable tb = InstanceForm.BDatabase.GetDataTable("sp_yf_dj_djmxcx", parameters, 30);


                #region 汇总单据明细
                DataTable tb1 = tb.Copy();
                string[] groupbyField ={ "往来单位", "商品名", "规格", "厂家", "付款比例"};
                string [] computeField={"付款金额","进货金额"};
                string [] cField={"sum","sum"};
                DataTable tab = FunBase.GroupbyDataTable(tb1, groupbyField, computeField, cField, null);
                tab.Columns.Add(new DataColumn("折扣金额", Type.GetType("System.Decimal")));
                tab.Columns.Add(new DataColumn("序号",Type.GetType("System.Int32")));
                int ixh = 1;
                foreach(DataRow row in tab.Rows)
                {
                    row["折扣金额"]=Convert.ToDecimal(row["进货金额"])-Convert.ToDecimal(row["付款金额"]);
                    row["序号"] = ixh;
                    ixh += 1;
                }

                decimal sumzkje = 0;
                decimal sumfkje = 0;
                decimal sumjhje = 0;
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    sumzkje += Convert.ToDecimal(tab.Rows[i]["折扣金额"]);
                    sumfkje += Convert.ToDecimal(tab.Rows[i]["付款金额"]);
                    sumjhje += Convert.ToDecimal(tab.Rows[i]["进货金额"]);
                }
                DataRow newrow = tab.NewRow();
                newrow["折扣金额"] = sumzkje;
                newrow["付款金额"] = sumfkje;
                newrow["进货金额"] = sumjhje;
                newrow["往来单位"] = "合计";
                tab.Rows.Add(newrow);
                dataGridView1.DataSource = tab;
                #endregion

                #region 无用代码
                //ColumnVisble(this.cmbdjlx.SelectedValue.ToString());

                ////求和列
                //decimal sumypsl = 0; decimal sumjhje = 0; decimal sumlsje = 0; decimal sumplce = 0; decimal sumtjje = 0; decimal sumzcje = 0; decimal sumpcje = 0; decimal sumykje = 0; decimal sumpfje = 0;
                //decimal sumfkje = 0;
                //for (int i = 0; i <= tb.Rows.Count - 1; i++)
                //{
                //    switch (this.dataGridView1.Tag.ToString().Trim())
                //    {
                //        case "DJMX":
                //            sumypsl = sumypsl + Convert.ToDecimal(tb.Rows[i]["数量"]);
                //            sumjhje = sumjhje + Convert.ToDecimal(tb.Rows[i]["进货金额"]);
                //            sumlsje = sumlsje + Convert.ToDecimal(tb.Rows[i]["零售金额"]);
                //            sumpfje = sumpfje + Convert.ToDecimal(tb.Rows[i]["批发金额"]);

                //            if (ywlx == "001" || ywlx == "002")
                //                sumfkje = sumfkje + Convert.ToDecimal(tb.Rows[i]["付款金额"]);

                //            break;
                //        case "TJMX":
                //            sumtjje = sumtjje + Convert.ToDecimal(tb.Rows[i]["调价金额"]);
                //            break;
                //        case "PDMX":
                //            sumzcje = sumzcje + Convert.ToDecimal(tb.Rows[i]["帐存金额"]);
                //            sumpcje = sumzcje + Convert.ToDecimal(tb.Rows[i]["盘存金额"]);
                //            sumykje = sumykje + Convert.ToDecimal(tb.Rows[i]["盈亏金额"]);
                //            break;
                //    }
                //}


                //DataRow newrow = tb.NewRow();
                //switch (this.dataGridView1.Tag.ToString().Trim())
                //{
                //    case "DJMX":
                //        sumplce = sumlsje - sumjhje;
                //        this.statusBar1.Panels[0].Text = "进货金额:" + sumjhje.ToString("0.00");
                //        this.statusBar1.Panels[1].Text = "零售金额:" + sumlsje.ToString("0.00");
                //        this.statusBar1.Panels[2].Text = "进零差额:" + sumplce.ToString("0.00");
                //        newrow["数量"] = sumypsl.ToString("0.00");
                //        newrow["进货金额"] = sumjhje.ToString("0.00");
                //        newrow["零售金额"] = sumlsje.ToString("0.00");
                //        newrow["进零差额"] = sumlsje.ToString("0.00");
                //        newrow["批发金额"] = sumpfje.ToString("0.00");
                //        if (ywlx == "001" || ywlx == "002")
                //            newrow["付款金额"] = sumfkje.ToString("0.00");
                //        break;
                //    case "TJMX":
                //        this.statusBar1.Panels[0].Text = "调价金额:" + sumtjje.ToString("0.00");
                //        //						newrow["进货金额"]=sumtjje.ToString("0.00");
                        
                //        break;
                //    case "PDMX":
                //        this.statusBar1.Panels[0].Text = "帐存金额:" + sumjhje.ToString("0.00");
                //        this.statusBar1.Panels[1].Text = "盘存金额:" + sumlsje.ToString("0.00");
                //        this.statusBar1.Panels[2].Text = "盈亏金额:" + sumplce.ToString("0.00");
                //        newrow["帐存金额"] = sumjhje.ToString("0.00");
                //        newrow["盘存金额"] = sumlsje.ToString("0.00");
                //        newrow["盈亏金额"] = sumlsje.ToString("0.00");
                        
                //        break;
                //}
                //newrow["品名"] = "合计";
                //tb.Rows.Add(newrow);
                //FunBase.AddRowtNo(tb);
                //tb.TableName = this.dataGridView1.Tag.ToString();
                //this.dataGridView1.DataSource = tb;
                //switch (this.dataGridView1.Tag.ToString().Trim())
                //{
                //    //case "DJMX":
                //    //    FunBase.myGridSelect(this.dataGridView1, this.dataGridView1.TableStyles[0].GridColumnStyles);
                //    //    break;
                //    //case "TJMX":
                //    //    FunBase.myGridSelect(this.dataGridView1, this.dataGridView1.TableStyles[2].GridColumnStyles);
                //    //    break;
                //    //case "PDMX":
                //    //    FunBase.myGridSelect(this.dataGridView1, this.dataGridView1.TableStyles[1].GridColumnStyles);
                //    //    break;
                //}

                #endregion

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //根据不同的业务类型屏蔽某些列
        private void ColumnVisble(string ywlx)
        {
            
        }

        //填充网格列
        private void cmbdjlx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            OptionVisble(cmbdjlx.SelectedValue.ToString());
            butprint1.Visible = false;
            butprint1.Enabled = false;
        }

        //查询选项的可见性
        private void OptionVisble(string ywlx)
        {
            for (int i = 0; i <= this.groupBox1.Controls.Count - 1; i++)
            {
                this.groupBox1.Controls[i].Visible = true;
            }

            butprint1.Visible = false;
            switch (ywlx)
            {

                case "001":
                case "002":
                    chktjwh.Visible = false;
                    txttjwh.Visible = false;
                    butprint1.Visible = true;
                    cmbywy.Visible = true;
                    chkywy.Visible = true;
                    break;
                case "003":
                case "004":
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
                    this.lblshrq.Visible = false;
                    this.chkshrq.Visible = false;
                    this.dtpshrq1.Visible = false;
                    this.dtpshrq2.Visible = false;
                    chktjwh.Visible = false;
                    txttjwh.Visible = false;
                    chkshdh.Visible = false;
                    txtshdh.Visible = false;
                    chkfph.Visible = false;
                    txtfph.Visible = false;
                    cmbywy.Visible = false;
                    chkywy.Visible = false;
                    break;
                case "005":
                    this.lblrq.Visible = false;
                    this.chkrq.Visible = false;
                    this.dtprq1.Visible = false;
                    this.dtprq2.Visible = false;
                    chkshdh.Visible = false;
                    txtshdh.Visible = false;
                    chkfph.Visible = false;
                    txtfph.Visible = false;
                    chkwldw.Visible = false;
                    txtwldw.Visible = false;
                    cmbywy.Enabled = false;
                    cmbywy.Visible = false;
                    chkywy.Visible = false;
                    break;
                case "006":
                case "007":
                    this.lblshrq.Visible = false;
                    this.chkshrq.Visible = false;
                    this.dtpshrq1.Visible = false;
                    this.dtpshrq2.Visible = false;
                    chktjwh.Visible = false;
                    txttjwh.Visible = false;
                    chkshdh.Visible = false;
                    txtshdh.Visible = false;
                    chkfph.Visible = false;
                    txtfph.Visible = false;
                    chkwldw.Visible = false;
                    txtwldw.Visible = false;
                    cmbywy.Enabled = false;
                    cmbywy.Visible = false;
                    chkywy.Visible = false;
                    break;
                case "008":
                case "009":
                    this.lblshrq.Visible = false;
                    this.chkshrq.Visible = false;
                    this.dtpshrq1.Visible = false;
                    this.dtpshrq2.Visible = false;
                    chktjwh.Visible = false;
                    txttjwh.Visible = false;
                    chkshdh.Visible = false;
                    txtshdh.Visible = false;
                    chkfph.Visible = false;
                    txtfph.Visible = false;
                    chkwldw.Visible = false;
                    txtwldw.Visible = false;
                    cmbywy.Enabled = false;
                    cmbywy.Visible = false;
                    chkywy.Visible = false;
                    break;
                case "":
                    break;
            }
        }


        //选项卡
        //弹出输入框
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            tb.Rows.Clear();

            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = ""; control.Tag = "0";
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { }
            else { return; }

            try
            {
                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 8:
                        if (control.Text.Trim() == "") return;
                        if (Convertor.IsNull(cmbdjlx.SelectedValue, "") == "001" || Convertor.IsNull(cmbdjlx.SelectedValue, "") == "002" || Convertor.IsNull(cmbdjlx.SelectedValue, "") == "019")
                        {
                            Yp.frmShowCard(sender, ShowCardType.供货单位, 0, point, Convert.ToInt32(cmbck.SelectedValue), InstanceForm.BDatabase);
                            Yp.AddcmbYwy(Convert.ToInt32(Convertor.IsNull(control.Tag, "0")), cmbywy, InstanceForm.BDatabase);
                        }
                        else
                            Yp.frmShowCard_funName(sender, ShowCardType.单据往来科室,"", point, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);

                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                       
                        break;
                    case 13:
                        if (control.Text.Trim() == "") return;
                        Yp.frmShowCard(sender, ShowCardType.库存药品_不区分禁用, 0, point, Convert.ToInt32(cmbck.SelectedValue), InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        Ypcj cj = new Ypcj(Convert.ToInt32(control.Tag), InstanceForm.BDatabase);
                        this.txtypmc.Text = cj.S_YPPM;
                        break;

                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        private void butquit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void butprint_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    #region 简单打印

            //    this.butprint.Enabled = false;
            //    Excel.Application myExcel = new Excel.Application();

            //    myExcel.Application.Workbooks.Add(true);

            //    //查询条件
            //    string swhere = "";
            //    if (this.chkdjsj.Checked == true) swhere = chkdjsj.Text + ":" + this.dtpdjsj1.Value.ToShortDateString() + " 到" + this.dtpdjsj2.Value.ToShortDateString();
            //    if (this.chkrq.Checked == true) swhere = swhere + " " + chkrq.Text + ":" + this.dtprq1.Value.ToShortDateString() + " 到" + this.dtprq2.Value.ToShortDateString();
            //    if (this.chkshrq.Checked == true) swhere = swhere + " " + chkshrq.Text + ":" + this.dtpshrq1.Value.ToShortDateString() + " 到" + this.dtpshrq2.Value.ToShortDateString();
            //    if (this.chkdjh.Checked == true) swhere = swhere + " " + chkdjh.Text + ":" + txtdjh.Text.Trim();
            //    if (this.chkdjh.Checked == true) swhere = swhere + " " + chkwldw.Text + ":" + txtwldw.Text.Trim();
            //    if (this.chkshdh.Checked == true) swhere = swhere + " " + chkshdh.Text + ":" + txtshdh.Text.Trim();
            //    if (this.chkfph.Checked == true) swhere = swhere + " " + chkfph.Text + ":" + txtfph.Text.Trim();
            //    if (this.chktjwh.Checked == true) swhere = swhere + " " + chktjwh.Text + ":" + txttjwh.Text.Trim();
            //    if (this.chkdjbz.Checked == true) swhere = swhere + " " + chkdjbz.Text + ":" + txtdjbz.Text.Trim();
            //    if (this.chkypmc.Checked == true) swhere = swhere + " " + chkypmc.Text + ":" + txtypmc.Text.Trim();

            //    //写入行头
            //    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            //    int SumRowCount = tb.Rows.Count;
            //    int SumColCount = tb.Columns.Count;

            //    for (int j = 0; j < tb.Columns.Count; j++)
            //    {
            //        myExcel.Cells[5, 1 + j] = tb.Columns[j].ColumnName;

            //    }
            //    myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
            //    myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


            //    //逐行写入数据，
            //    for (int i = 0; i < tb.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < tb.Columns.Count; j++)
            //        {
            //            myExcel.Cells[6 + i, 1 + j] = "'" + tb.Rows[i][j].ToString();
            //        }
            //    }

            //    //设置报表表格为最适应宽度
            //    myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
            //    myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

            //    //加边框
            //    myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

            //    //报表名称
            //    myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + this.cmbdjlx.Text.Trim() + "查询";
            //    myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
            //    myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
            //    //报表名称跨行居中
            //    myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
            //    myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

            //    //报表条件
            //    myExcel.Cells[3, 1] = swhere.Trim();
            //    myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
            //    myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
            //    myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            //    //最后一行为黄色
            //    myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

            //    //让Excel文件可见
            //    myExcel.Visible = true;
            //    this.butprint.Enabled = true;
            //    #endregion
            //}
            //catch (System.Exception err)
            //{
            //    this.butprint.Enabled = true;
            //    MessageBox.Show(err.Message);
            //}




            try
            {

                DataTable tb = (DataTable)this.dataGridView1.DataSource;

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
                int colCount = 0;
                int RowCount = tb.Rows.Count+1;
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                        colCount = colCount + 1;
                }


                //查询条件
                string swhere = "";
                if (this.chkdjsj.Checked == true) swhere = chkdjsj.Text + ":" + this.dtpdjsj1.Value.ToShortDateString() + " 到" + this.dtpdjsj2.Value.ToShortDateString();
                if (this.chkrq.Checked == true) swhere = swhere + " " + chkrq.Text + ":" + this.dtprq1.Value.ToShortDateString() + " 到" + this.dtprq2.Value.ToShortDateString();
                if (this.chkshrq.Checked == true) swhere = swhere + " " + chkshrq.Text + ":" + this.dtpshrq1.Value.ToShortDateString() + " 到" + this.dtpshrq2.Value.ToShortDateString();
                if (this.chkdjh.Checked == true) swhere = swhere + " " + chkdjh.Text + ":" + txtdjh.Text.Trim();
                if (this.chkdjh.Checked == true) swhere = swhere + " " + chkwldw.Text + ":" + txtwldw.Text.Trim();
                if (this.chkshdh.Checked == true) swhere = swhere + " " + chkshdh.Text + ":" + txtshdh.Text.Trim();
                if (this.chkfph.Checked == true) swhere = swhere + " " + chkfph.Text + ":" + txtfph.Text.Trim();
                if (this.chktjwh.Checked == true) swhere = swhere + " " + chktjwh.Text + ":" + txttjwh.Text.Trim();
                if (this.chkdjbz.Checked == true) swhere = swhere + " " + chkdjbz.Text + ":" + txtdjbz.Text.Trim();
                if (this.chkypmc.Checked == true) swhere = swhere + " " + chkypmc.Text + ":" + txtypmc.Text.Trim();

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "单据明细查询";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 设置条件
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;
                //xlApp.ActiveCell.FormulaR1C1 = swhere;
                //xlApp.ActiveCell.Font.Size = 20;
                //xlApp.ActiveCell.Font.Bold = true;
                //xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    objData[1, colIndex++] = tb.Columns[i].Caption;
                }
                // 获取数据
                objData[0, 0] = swhere;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        //if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width>0)
                        //{
                        if (tb.Columns[j].Caption == "门诊号")
                                objData[i + 2, colIndex++] = "'" + tb.Rows[i][j].ToString();
                            else
                                objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
                        //}
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

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




        }

        private void butclear_Click(object sender, System.EventArgs e)
        {
          
        }



        private void butprint1_Click(object sender, EventArgs e)
        {
            try
            {
                string ywlwname = this.Text.Trim();
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                ts_Yk_ReportView.Dataset1 Dset = new ts_Yk_ReportView.Dataset1();
                DataRow myrow;
                for (int i = 0; i <= tb.Rows.Count - 2; i++)
                {
                    myrow = Dset.药品单据明细.NewRow();
                    myrow["xh"] = Convert.ToInt32(tb.Rows[i]["序号"]);
                    myrow["ypmc"] = Convert.ToString(tb.Rows[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(tb.Rows[i]["厂家"]);
                    float ypsl = (float)Convert.ToDecimal(tb.Rows[i]["数量"]);
                    myrow["ypsl"] = ypsl.ToString();
                    myrow["ypdw"] = Convert.ToString(tb.Rows[i]["单位"]);
                    myrow["ypkl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["扣率"], "0"));
                    myrow["jhj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"], "0"));
                    myrow["jhje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"], "0"));
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"], "0"));
                    myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"], "0"));
                    myrow["jlce"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进零差额"], "0"));
                    myrow["ypph"] = Convert.ToString(tb.Rows[i]["批号"]);
                    myrow["ypxq"] = Convert.ToString(tb.Rows[i]["效期"]);
                    //myrow["shh"] = Convert.ToString(tb.Rows[i]["货号"]);
                    myrow["shdh"] = Convert.ToString(tb.Rows[i]["送货单号"]);
                    myrow["djh"] = Convert.ToString(tb.Rows[i]["单据号"]);
                    myrow["djrq"] = Convert.ToString(tb.Rows[i]["登记日期"]);
                    string ywy = chkywy.Checked == true ? "[" + cmbywy.Text.Trim() + "]" : "";
                    myrow["ghdw"] = Convert.ToString(tb.Rows[i]["往来单位"])+ywy;
                    myrow["fph"] = Convert.ToString(tb.Rows[i]["发票号"]);
                    myrow["fprq"] = Convert.ToString(tb.Rows[i]["发票日期"]);
                    if (tb.Columns.Contains("条形码") == true)
                        myrow["txm"] = Convert.ToString(tb.Rows[i]["条形码"]);
                    myrow["pfj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"], "0"));
                    myrow["pfje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"], "0"));
                    Dset.药品单据明细.Rows.Add(myrow);

                }
                string where1 = "";
     
                where1 = where1+"  统计类别:"+cmbdjlx.Text.Trim();
                if (chkdjsj.Checked == true) where1 =where1+ "      登记时间:" + dtpdjsj1.Value.ToShortDateString() + " 到 " + dtpdjsj2.Value.ToShortDateString();
                string where2 = "";
                if (chkfph.Checked == true) where2 = "发票号:" + txtfph.Text;
                if (chkshdh.Checked == true) where2 = where2 + " 送货单号:" + txtshdh.Text;
                if (chkypmc.Checked == true) where2 = where2 + " 药品名称:" + txtypmc.Text;

                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "titletext";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;
                parameters[1].Text = "统计条件";
                parameters[1].Value = where1;
                parameters[2].Text = "统计条件1";
                parameters[2].Value = "";
                parameters[3].Text = "仓库名称";
                parameters[3].Value = cmbck.Text.Trim();

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.药品单据明细, Constant.ApplicationDirectory + "\\Report\\YP_采购明细单.rpt", parameters);
                if (f.LoadReportSuccess)
                {
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void myDataGrid1_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable tb = (DataTable)myDataGrid1.DataSource;
            //    if (tb == null) return;
            //    int nrow = myDataGrid1.CurrentCell.RowNumber;
            //    if (nrow >= tb.Rows.Count - 1) return;
            //    Guid id = new Guid(tb.Rows[nrow]["id"].ToString());
            //    string ywlx = tb.Rows[nrow]["ywlx"].ToString();
            //    int deptid = Convert.ToInt32(tb.Rows[nrow]["deptid"].ToString());
            //    MenuTag mtag = new MenuTag();
            //    Department BCurrentDept = new Department(deptid, InstanceForm.BDatabase); ;

            //    switch (ywlx)
            //    {
            //        case "001":
            //            mtag.DllName = "ts_yk_cgrk";
            //            mtag.Function_Name = "Fun_ts_yk_cgrk_cx";
            //            mtag.FunctionTag = "001";
            //            ts_yk_cgrk.InstanceForm.BDatabase = InstanceForm.BDatabase;
            //            ts_yk_cgrk.InstanceForm.BCurrentDept = BCurrentDept;
            //            ts_yk_cgrk.InstanceForm.BCurrentUser = InstanceForm.BCurrentUser;
            //            ts_yk_cgrk.InstanceForm._menuTag = mtag;
            //            ts_yk_cgrk.Frmyprk frmcg = new ts_yk_cgrk.Frmyprk(mtag, "采购入库单查询", null, tb);
            //            frmcg.Show();
            //            frmcg.FillDj(id, true);
            //            break;
            //        case "002":
            //            mtag.DllName = "ts_yk_cgrk";
            //            mtag.Function_Name = "Fun_ts_yk_cgrk_th_cx";
            //            mtag.FunctionTag = "002";
            //            ts_yk_cgrk.InstanceForm.BDatabase = InstanceForm.BDatabase;
            //            ts_yk_cgrk.InstanceForm.BCurrentDept = BCurrentDept;
            //            ts_yk_cgrk.InstanceForm.BCurrentUser = InstanceForm.BCurrentUser;
            //            ts_yk_cgrk.InstanceForm._menuTag = mtag;
            //            ts_yk_cgrk.Frmyprk frmth = new ts_yk_cgrk.Frmyprk(mtag, "退货单查询", null, tb);
            //            frmth.Show();
            //            frmth.FillDj(id, true);
            //            break;
            //        case "003":
            //        case "014":
            //        case "017":
            //        case "018":
            //        case "020":
            //        case "022":
            //        case "030":
            //            mtag.DllName = "ts_yk_ck";
            //            if (ywlx == "003") mtag.Function_Name = "Fun_ts_yk_ypck_cx";
            //            if (ywlx == "014") mtag.Function_Name = "Fun_ts_yk_ypck_qtly_cx";
            //            if (ywlx == "018") mtag.Function_Name = "Fun_ts_yk_ypck_cfbl_cx";
            //            if (ywlx == "020") mtag.Function_Name = "Fun_ts_yk_ypck_jzcfck_cx";
            //            if (ywlx == "022") mtag.Function_Name = "Fun_ts_yk_ypck_wyylyd_cx";
            //            if (ywlx == "030") mtag.Function_Name = "Fun_ts_yk_ypck_dck_cx";
            //            mtag.FunctionTag =ywlx;
            //            ts_yk_ck.InstanceForm.BDatabase = InstanceForm.BDatabase;
            //            ts_yk_ck.InstanceForm.BCurrentDept = BCurrentDept;
            //            ts_yk_ck.InstanceForm.BCurrentUser = InstanceForm.BCurrentUser;
            //            ts_yk_ck.InstanceForm._menuTag = mtag;
            //            ts_yk_ck.Frmypck frmck = new ts_yk_ck.Frmypck(mtag, "单据查询", null,tb,false);
            //            frmck.Show();
            //            frmck.FillDj(id, true);
            //            break;
            //        case "004":
            //        case "009":
            //        case "016":
            //        case "031":
            //            mtag.DllName = "ts_yk_ptrk";
            //            if (ywlx == "004") mtag.Function_Name = "Fun_ts_yk_ypptrk_tk_cx";
            //            if (ywlx == "009") mtag.Function_Name = "Fun_ts_yk_ypptrk_qc_cx";
            //            if (ywlx == "016") mtag.Function_Name = "Fun_ts_yk_ypptrk_qtrk_cx";
            //            if (ywlx == "031") mtag.Function_Name = "Fun_ts_yk_ypptrk_drk_cx";
            //            mtag.FunctionTag = ywlx;
            //            ts_yk_ptrk.InstanceForm.BDatabase = InstanceForm.BDatabase;
            //            ts_yk_ptrk.InstanceForm.BCurrentDept = BCurrentDept;
            //            ts_yk_ptrk.InstanceForm.BCurrentUser = InstanceForm.BCurrentUser;
            //            ts_yk_ptrk.InstanceForm._menuTag = mtag;
            //            ts_yk_ptrk.Frmypptrk frmptrk = new ts_yk_ptrk.Frmypptrk(mtag, "单据查询", null);
            //            frmptrk.Show();
            //            frmptrk.FillDj(id, true);
            //            break;
            //        case "005":
            //            mtag.DllName = "ts_yp_tj";
            //            mtag.Function_Name = "Fun_ts_yp_tj_cx";
            //            mtag.FunctionTag = ywlx;
            //            ts_yp_tj.InstanceForm.BDatabase = InstanceForm.BDatabase;
            //            ts_yp_tj.InstanceForm.BCurrentDept = BCurrentDept;
            //            ts_yp_tj.InstanceForm.BCurrentUser = InstanceForm.BCurrentUser;
            //            ts_yp_tj.InstanceForm._menuTag = mtag;
            //            ts_yp_tj.Frmyptj frmtj = new ts_yp_tj.Frmyptj(mtag, "单据查询", null);
            //            frmtj.Show();
            //            frmtj.FillDj(id, true);
            //            break;
            //        case "008":
            //            mtag.DllName = "ts_yp_tj";
            //            mtag.Function_Name = "Fun_ts_yp_tj_cx";
            //            mtag.FunctionTag = ywlx;
            //            ts_yp_pd.InstanceForm.BDatabase = InstanceForm.BDatabase;
            //            ts_yp_pd.InstanceForm.BCurrentDept = BCurrentDept;
            //            ts_yp_pd.InstanceForm.BCurrentUser = InstanceForm.BCurrentUser;
            //            ts_yp_pd.InstanceForm._menuTag = mtag;
            //            ts_yp_pd.Frmpdsh frmpd = new ts_yp_pd.Frmpdsh(mtag, "单据查询", null);
            //            frmpd.Show();
            //            frmpd.FillDj(id, true);
            //            break;
            //        case "006":
            //        case "007":
            //            mtag.DllName = "ts_yk_bsby";
            //            if (ywlx == "006") mtag.Function_Name = "Fun_ts_yk_ypbs_cx";
            //            if (ywlx == "007") mtag.Function_Name = "Fun_ts_yk_ypby_cx";
            //            mtag.FunctionTag = ywlx;
            //            ts_yk_bsby.InstanceForm.BDatabase = InstanceForm.BDatabase;
            //            ts_yk_bsby.InstanceForm.BCurrentDept = BCurrentDept;
            //            ts_yk_bsby.InstanceForm.BCurrentUser = InstanceForm.BCurrentUser;
            //            ts_yk_bsby.InstanceForm._menuTag = mtag;
            //            ts_yk_bsby.Frmypbsby frmbs = new ts_yk_bsby.Frmypbsby(mtag, "单据查询", null);
            //            frmbs.Show();
            //            frmbs.FillDj(id, true);
            //            break;
            //        default:
            //            break;
            //    }

            //}
            //catch (System.Exception err)
            //{
            //    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            ////try
            ////{
            ////    DataTable tb = (DataTable)myDataGrid1.DataSource;
            ////    int nrow = myDataGrid1.CurrentCell.RowNumber;
            ////    if (nrow >= tb.Rows.Count - 1) return;

            ////    string djid = Convertor.IsNull(tb.Rows[nrow]["id"].ToString(), Guid.Empty.ToString());
            ////    int cjid = Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["cjid"].ToString(), "0"));

            ////    string ssql = "";
            ////    ssql = "select ywlx,deptid,djh,djh 单据号 from vi_yk_dj where id='" + djid + "'";
            ////    if (cmbdjlx.SelectedValue.ToString()=="005")
            ////        ssql="select ywlx,deptid,djh,djh 单据号 from Yf_TJ where id='" + djid + "'";
            ////    if (cmbdjlx.SelectedValue.ToString() == "008")
            ////        ssql = "select ywlx,deptid,djh,djh 单据号 from YF_PD where id='" + djid + "'";
  
                    
            ////    DataTable tbdj = InstanceForm.BDatabase.GetDataTable(ssql);
            ////    string ywlx = "";
            ////    if (tbdj.Rows.Count > 0) ywlx = tbdj.Rows[0]["ywlx"].ToString();
            ////    if (ywlx == "") return;
            ////    MenuTag _menutag = new MenuTag();
            ////    Department BCurrentDept = new Department(Convert.ToInt32(tbdj.Rows[0]["deptid"]), InstanceForm.BDatabase);


            ////    //ssql = "select * from pub_menu a,yk_ywlx b where a.function_tag=b.ywlx and (function_name='Fun_ts_yp_tj_cx' or function_name='Fun_ts_yp_pd_cx' or (dll_name like '%_yk_%' and function_name like '%_cx%' )) and ywlx='" + ywlx + "'";
            ////    //DataTable tbyw = InstanceForm.BDatabase.GetDataTable(ssql);
            ////    //if (tbyw.Rows.Count == 0) return;
            ////    //string dllname = tbyw.Rows[0]["dll_name"].ToString().Trim();
            ////    //string funname = tbyw.Rows[0]["function_name"].ToString().Trim();
            ////    //string funtag = ywlx.Trim();
            ////    //string menuname = tbyw.Rows[0]["name"].ToString().Trim();
            ////    //int jgbm = Convert.ToInt32(tbyw.Rows[0]["jgbm"]) > 0 ? Convert.ToInt32(tbyw.Rows[0]["jgbm"]) : InstanceForm._menuTag.Jgbm;

            ////    string dllname = "";
            ////    string funname = "";
            ////    string funtag = ywlx.Trim();
            ////    string menuname = "单据明细查询";
            ////    int jgbm = InstanceForm._menuTag.Jgbm;
            ////    switch (ywlx)
            ////    {
            ////        case "001":
            ////            dllname = "ts_yk_cgrk";
            ////            funname = "Fun_ts_yk_cgrk_cx";
            ////            break;
            ////        case "002":
            ////            dllname = "ts_yk_cgrk";
            ////            funname = "Fun_ts_yk_cgrk_th_cx";
            ////            break;
            ////        case "003":
            ////        case "014":
            ////        case "017":
            ////        case "018":
            ////        case "020":
            ////        case "022":
            ////        case "030":
            ////            dllname = "ts_yk_ck";
            ////            if (ywlx == "003") funname = "Fun_ts_yk_ypck_cx";
            ////            if (ywlx == "014") funname = "Fun_ts_yk_ypck_qtly_cx";
            ////            if (ywlx == "018") funname = "Fun_ts_yk_ypck_cfbl_cx";
            ////            if (ywlx == "020") funname = "Fun_ts_yk_ypck_jzcfck_cx";
            ////            if (ywlx == "022") funname = "Fun_ts_yk_ypck_wyylyd_cx";
            ////            if (ywlx == "030") funname = "Fun_ts_yk_ypck_dck_cx";
            ////            break;
            ////        case "004":
            ////        case "009":
            ////        case "016":
            ////        case "031":
            ////            dllname = "ts_yk_ptrk";
            ////            if (ywlx == "004") funname = "Fun_ts_yk_ypptrk_tk_cx";
            ////            if (ywlx == "009") funname = "Fun_ts_yk_ypptrk_qc_cx";
            ////            if (ywlx == "016") funname = "Fun_ts_yk_ypptrk_qtrk_cx";
            ////            if (ywlx == "031") funname = "Fun_ts_yk_ypptrk_drk_cx";
            ////            break;
            ////        case "005":
            ////            dllname = "ts_yp_tj";
            ////            funname = "Fun_ts_yp_tj_cx";
            ////            break;
            ////        case "008":
            ////            dllname = "ts_yp_pd";
            ////            funname = "Fun_ts_yp_pd_cx";
            ////            break;
            ////        case "006":
            ////        case "007":
            ////            dllname = "ts_yk_bsby";
            ////            if (ywlx == "006") funname = "Fun_ts_yk_ypbs_cx";
            ////            if (ywlx == "007") funname = "Fun_ts_yk_ypby_cx";
            ////            break;
            ////        default:
            ////            break;
            ////    }

            ////    switch (ywlx)
            ////    {
            ////        case "005":
            ////            ssql = "select * from yf_tj where deptid=" + tbdj.Rows[0]["deptid"].ToString() + " and djh=" + tbdj.Rows[0]["djh"].ToString() + "";
            ////            DataTable tbtj = InstanceForm.BDatabase.GetDataTable(ssql);
            ////            if (tbtj.Rows.Count == 0) return;
            ////            _menutag.DllName = dllname;
            ////            _menutag.Function_Name = funname;
            ////            _menutag.FunctionTag = funtag;
            ////            _menutag.Jgbm = jgbm;
            ////            object[] comValue1 = new object[5];
            ////            comValue1[0] = _menutag;
            ////            comValue1[1] = menuname;
            ////            comValue1[2] = tbtj.Rows[0]["id"].ToString();
            ////            comValue1[3] = tb;
            ////            comValue1[4] = cjid;
            ////            Form f1 = ShowDllForm(dllname, funname, menuname, ref comValue1, false, BCurrentDept, InstanceForm.BCurrentUser);
            ////            //f1.ShowDialog();
            ////            break;
            ////        case "008":
            ////            ssql = "select * from yf_pd where deptid=" + tbdj.Rows[0]["deptid"].ToString() + " and djh=" + tbdj.Rows[0]["djh"].ToString() + "";
            ////            DataTable tbpd = InstanceForm.BDatabase.GetDataTable(ssql);
            ////            if (tbpd.Rows.Count == 0) return;
            ////            _menutag.DllName = dllname;
            ////            _menutag.Function_Name = funname;
            ////            _menutag.FunctionTag = funtag;
            ////            _menutag.Jgbm = jgbm;
            ////            object[] comValue2 = new object[5];
            ////            comValue2[0] = _menutag;
            ////            comValue2[1] = menuname;
            ////            comValue2[2] = tbpd.Rows[0]["id"].ToString();
            ////            comValue2[3] = tb;
            ////            comValue2[4] = cjid;
            ////            Form f2 = ShowDllForm(dllname, funname, menuname, ref comValue2, false, BCurrentDept, InstanceForm.BCurrentUser);
            ////            //f2.ShowDialog();
            ////            break;
            ////        case "012":
            ////            break;
            ////        default:
            ////            _menutag.DllName = dllname;
            ////            _menutag.Function_Name = funname;
            ////            _menutag.FunctionTag = funtag;
            ////            _menutag.Jgbm = jgbm;
            ////            object[] comValue3 = new object[5];
            ////            comValue3[0] = _menutag;
            ////            comValue3[1] = menuname;
            ////            comValue3[2] = djid;
            ////            comValue3[3] = tb;
            ////            comValue3[4] = cjid;
            ////            Form f3 = ShowDllForm(dllname, funname, menuname, ref comValue3, false, BCurrentDept, InstanceForm.BCurrentUser);
            ////            //f3.ShowDialog();
            ////            break;
            ////    }
            ////}
            ////catch (System.Exception err)
            ////{
            ////    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////}

        }

        private Form ShowDllForm(string dllName, string functionName, string chineseName, ref object[] communicateValue, bool showModule, Department _department, User _user)
        {
            try
            {
                long menuId;
                menuId = _menuTag.ModuleId;
                //获得DLL中窗体
                Form dllForm = null;
                if (showModule)
                    dllForm = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, _user, _department,
                        _menuTag, menuId, this.MdiParent, InstanceForm.BDatabase, ref communicateValue);
                else
                    dllForm = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, _user, _department,
                        _menuTag, menuId, null, InstanceForm.BDatabase, ref communicateValue);
                return dllForm;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private void myDataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            //this.dataGridView1.sel(this.dataGridView1.CurrentCell.);
        }
    }
}
