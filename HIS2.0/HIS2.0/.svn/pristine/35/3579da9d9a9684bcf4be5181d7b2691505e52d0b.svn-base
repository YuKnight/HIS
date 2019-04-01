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
namespace ts_yk_cx
{
	/// <summary>
	/// Frmkccx 的摘要说明。
	/// </summary>
	public class Frmkccx : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbypzlx;
		private System.Windows.Forms.CheckBox chkyplx;
		private System.Windows.Forms.CheckBox chkypzlx;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkjx;
		private System.Windows.Forms.CheckBox chkqkcwl;
		private System.Windows.Forms.CheckBox chkqjy;
		private System.Windows.Forms.ComboBox cmbjx;
		private System.Windows.Forms.Button butcx;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.ComboBox cmbyplx;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtdm;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
		private System.Windows.Forms.Panel panel2;
		private myDataGrid.myDataGrid myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.CheckBox chksccj;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.TextBox cmbsccj;
		private System.Windows.Forms.Button butjy;
		private Form _mdiParent;
		private MenuTag _menuTag;
		private string _chineseName;
		private System.Windows.Forms.DataGridTextBoxColumn 商品名;
		private YpConfig ss;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
        private ComboBox cmbyjks;
        private Label label6;
        private CheckBox chkqkcxyl;
        private ComboBox cmbck;
        private Label lblck;
        private CheckBox chkbwl;
        private ComboBox cmbsort;
        private Label label2;
        private DataGridTextBoxColumn dataGridTextBoxColumn20;
        private Button butexcel;
        private DataGridTextBoxColumn col_批次号;
        private DataGridTextBoxColumn col_kcid;
        private bool bpcgl = false;
        private GroupBox grbpcxz;
        private Label lblpch;
        private Label label3;
        private Label label8;
        private DateTimePicker dtpxq;
        private Button btnbcpc;
        private GroupBox grbpctz;
        private Label label4;
        private Label lblypch;
        private Label label5;
        private Label label10;
        private Button btnSavePctz;
        private TextBox txttzsl;
        private ComboBox cmbtpch;//是否进行批次管理

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmkccx(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text =chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
			ss=new YpConfig(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase);
			if (ss.网络内容显示商品名==true)
				this.商品名.Width=110;
			else
				this.商品名.Width=0;

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbpctz = new System.Windows.Forms.GroupBox();
            this.cmbtpch = new System.Windows.Forms.ComboBox();
            this.btnSavePctz = new System.Windows.Forms.Button();
            this.txttzsl = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblypch = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grbpcxz = new System.Windows.Forms.GroupBox();
            this.btnbcpc = new System.Windows.Forms.Button();
            this.dtpxq = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.lblpch = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butexcel = new System.Windows.Forms.Button();
            this.cmbsort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.lblck = new System.Windows.Forms.Label();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butjy = new System.Windows.Forms.Button();
            this.cmbsccj = new System.Windows.Forms.TextBox();
            this.chksccj = new System.Windows.Forms.CheckBox();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.butprint = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butcx = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkbwl = new System.Windows.Forms.CheckBox();
            this.chkqkcxyl = new System.Windows.Forms.CheckBox();
            this.chkqjy = new System.Windows.Forms.CheckBox();
            this.chkqkcwl = new System.Windows.Forms.CheckBox();
            this.cmbjx = new System.Windows.Forms.ComboBox();
            this.chkjx = new System.Windows.Forms.CheckBox();
            this.cmbypzlx = new System.Windows.Forms.ComboBox();
            this.chkyplx = new System.Windows.Forms.CheckBox();
            this.chkypzlx = new System.Windows.Forms.CheckBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_批次号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn2 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_kcid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.grbpctz.SuspendLayout();
            this.grbpcxz.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grbpctz);
            this.groupBox1.Controls.Add(this.grbpcxz);
            this.groupBox1.Controls.Add(this.butexcel);
            this.groupBox1.Controls.Add(this.cmbsort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.lblck);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.butjy);
            this.groupBox1.Controls.Add(this.cmbsccj);
            this.groupBox1.Controls.Add(this.chksccj);
            this.groupBox1.Controls.Add(this.txtdm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbyplx);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butcx);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.cmbjx);
            this.groupBox1.Controls.Add(this.chkjx);
            this.groupBox1.Controls.Add(this.cmbypzlx);
            this.groupBox1.Controls.Add(this.chkyplx);
            this.groupBox1.Controls.Add(this.chkypzlx);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1261, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // grbpctz
            // 
            this.grbpctz.Controls.Add(this.cmbtpch);
            this.grbpctz.Controls.Add(this.btnSavePctz);
            this.grbpctz.Controls.Add(this.txttzsl);
            this.grbpctz.Controls.Add(this.label10);
            this.grbpctz.Controls.Add(this.lblypch);
            this.grbpctz.Controls.Add(this.label5);
            this.grbpctz.Controls.Add(this.label4);
            this.grbpctz.Location = new System.Drawing.Point(1032, 13);
            this.grbpctz.Name = "grbpctz";
            this.grbpctz.Size = new System.Drawing.Size(219, 112);
            this.grbpctz.TabIndex = 52;
            this.grbpctz.TabStop = false;
            this.grbpctz.Text = "批次调整";
            this.grbpctz.Visible = false;
            // 
            // cmbtpch
            // 
            this.cmbtpch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbtpch.ForeColor = System.Drawing.Color.Red;
            this.cmbtpch.FormattingEnabled = true;
            this.cmbtpch.Location = new System.Drawing.Point(61, 44);
            this.cmbtpch.Name = "cmbtpch";
            this.cmbtpch.Size = new System.Drawing.Size(121, 22);
            this.cmbtpch.TabIndex = 31;
            // 
            // btnSavePctz
            // 
            this.btnSavePctz.Location = new System.Drawing.Point(144, 72);
            this.btnSavePctz.Name = "btnSavePctz";
            this.btnSavePctz.Size = new System.Drawing.Size(72, 28);
            this.btnSavePctz.TabIndex = 30;
            this.btnSavePctz.Text = "保存";
            this.btnSavePctz.Click += new System.EventHandler(this.btnSavePctz_Click);
            // 
            // txttzsl
            // 
            this.txttzsl.Location = new System.Drawing.Point(60, 76);
            this.txttzsl.Name = "txttzsl";
            this.txttzsl.Size = new System.Drawing.Size(80, 21);
            this.txttzsl.TabIndex = 10;
            this.txttzsl.Leave += new System.EventHandler(this.txttzsl_Leave);
            this.txttzsl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txttzsl_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "调整数量";
            // 
            // lblypch
            // 
            this.lblypch.AutoSize = true;
            this.lblypch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblypch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblypch.Location = new System.Drawing.Point(60, 21);
            this.lblypch.Name = "lblypch";
            this.lblypch.Size = new System.Drawing.Size(49, 14);
            this.lblypch.TabIndex = 7;
            this.lblypch.Text = "批次号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "调批次号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "原批次号";
            // 
            // grbpcxz
            // 
            this.grbpcxz.Controls.Add(this.btnbcpc);
            this.grbpcxz.Controls.Add(this.dtpxq);
            this.grbpcxz.Controls.Add(this.label8);
            this.grbpcxz.Controls.Add(this.lblpch);
            this.grbpcxz.Controls.Add(this.label3);
            this.grbpcxz.Location = new System.Drawing.Point(826, 13);
            this.grbpcxz.Name = "grbpcxz";
            this.grbpcxz.Size = new System.Drawing.Size(200, 111);
            this.grbpcxz.TabIndex = 51;
            this.grbpcxz.TabStop = false;
            this.grbpcxz.Text = "效期修正";
            // 
            // btnbcpc
            // 
            this.btnbcpc.Location = new System.Drawing.Point(124, 69);
            this.btnbcpc.Name = "btnbcpc";
            this.btnbcpc.Size = new System.Drawing.Size(72, 28);
            this.btnbcpc.TabIndex = 29;
            this.btnbcpc.Text = "保存";
            this.btnbcpc.Click += new System.EventHandler(this.btnbcpc_Click);
            // 
            // dtpxq
            // 
            this.dtpxq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpxq.Location = new System.Drawing.Point(47, 17);
            this.dtpxq.Name = "dtpxq";
            this.dtpxq.Size = new System.Drawing.Size(149, 21);
            this.dtpxq.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "效期";
            // 
            // lblpch
            // 
            this.lblpch.AutoSize = true;
            this.lblpch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblpch.Location = new System.Drawing.Point(52, 50);
            this.lblpch.Name = "lblpch";
            this.lblpch.Size = new System.Drawing.Size(49, 14);
            this.lblpch.TabIndex = 1;
            this.lblpch.Text = "批次号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "批次号";
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point(674, 15);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(72, 28);
            this.butexcel.TabIndex = 50;
            this.butexcel.Text = "导出(&E)";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // cmbsort
            // 
            this.cmbsort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsort.Items.AddRange(new object[] {
            "货位号",
            "品名",
            "货号",
            "剂型"});
            this.cmbsort.Location = new System.Drawing.Point(530, 62);
            this.cmbsort.Name = "cmbsort";
            this.cmbsort.Size = new System.Drawing.Size(102, 20);
            this.cmbsort.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(500, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "排序";
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Location = new System.Drawing.Point(332, 13);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(140, 20);
            this.cmbck.TabIndex = 42;
            this.cmbck.SelectedIndexChanged += new System.EventHandler(this.cmbck_SelectedIndexChanged);
            // 
            // lblck
            // 
            this.lblck.Location = new System.Drawing.Point(271, 17);
            this.lblck.Name = "lblck";
            this.lblck.Size = new System.Drawing.Size(67, 16);
            this.lblck.TabIndex = 41;
            this.lblck.Text = "仓库名称";
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(104, 13);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(144, 20);
            this.cmbyjks.TabIndex = 40;
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(35, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 39;
            this.label6.Text = "药剂科室";
            // 
            // butjy
            // 
            this.butjy.Location = new System.Drawing.Point(638, 57);
            this.butjy.Name = "butjy";
            this.butjy.Size = new System.Drawing.Size(157, 25);
            this.butjy.TabIndex = 38;
            this.butjy.Text = "禁用库存为零的批号";
            this.butjy.Click += new System.EventHandler(this.butjy_Click);
            // 
            // cmbsccj
            // 
            this.cmbsccj.Enabled = false;
            this.cmbsccj.Location = new System.Drawing.Point(333, 38);
            this.cmbsccj.Name = "cmbsccj";
            this.cmbsccj.Size = new System.Drawing.Size(158, 21);
            this.cmbsccj.TabIndex = 35;
            this.cmbsccj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // chksccj
            // 
            this.chksccj.Location = new System.Drawing.Point(256, 39);
            this.chksccj.Name = "chksccj";
            this.chksccj.Size = new System.Drawing.Size(91, 23);
            this.chksccj.TabIndex = 34;
            this.chksccj.Text = "生产厂家";
            this.chksccj.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // txtdm
            // 
            this.txtdm.Location = new System.Drawing.Point(333, 63);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(158, 21);
            this.txtdm.TabIndex = 33;
            this.txtdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdm_KeyUp);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(277, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "代码查询";
            // 
            // cmbyplx
            // 
            this.cmbyplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyplx.Enabled = false;
            this.cmbyplx.Location = new System.Drawing.Point(104, 39);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(144, 20);
            this.cmbyplx.TabIndex = 31;
            this.cmbyplx.SelectedIndexChanged += new System.EventHandler(this.cmbyplx_SelectedIndexChanged);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(600, 15);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(72, 28);
            this.butprint.TabIndex = 30;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(748, 15);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(72, 28);
            this.butquit.TabIndex = 29;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butcx
            // 
            this.butcx.Location = new System.Drawing.Point(526, 15);
            this.butcx.Name = "butcx";
            this.butcx.Size = new System.Drawing.Size(72, 28);
            this.butcx.TabIndex = 28;
            this.butcx.Text = "查询(&V)";
            this.butcx.Click += new System.EventHandler(this.butcx_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkbwl);
            this.groupBox3.Controls.Add(this.chkqkcxyl);
            this.groupBox3.Controls.Add(this.chkqjy);
            this.groupBox3.Controls.Add(this.chkqkcwl);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox3.Location = new System.Drawing.Point(257, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(535, 36);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选项";
            // 
            // chkbwl
            // 
            this.chkbwl.Location = new System.Drawing.Point(366, 10);
            this.chkbwl.Name = "chkbwl";
            this.chkbwl.Size = new System.Drawing.Size(123, 24);
            this.chkbwl.TabIndex = 33;
            this.chkbwl.Text = "库存不为零的药品";
            // 
            // chkqkcxyl
            // 
            this.chkqkcxyl.Location = new System.Drawing.Point(130, 15);
            this.chkqkcxyl.Name = "chkqkcxyl";
            this.chkqkcxyl.Size = new System.Drawing.Size(104, 19);
            this.chkqkcxyl.TabIndex = 30;
            this.chkqkcxyl.Text = "仅库存小于零";
            this.chkqkcxyl.CheckedChanged += new System.EventHandler(this.chkqkcxyl_CheckedChanged);
            // 
            // chkqjy
            // 
            this.chkqjy.Location = new System.Drawing.Point(242, 15);
            this.chkqjy.Name = "chkqjy";
            this.chkqjy.Size = new System.Drawing.Size(104, 19);
            this.chkqjy.TabIndex = 29;
            this.chkqjy.Text = "仅禁用的药品";
            this.chkqjy.CheckedChanged += new System.EventHandler(this.chkqjy_CheckedChanged);
            // 
            // chkqkcwl
            // 
            this.chkqkcwl.Location = new System.Drawing.Point(8, 10);
            this.chkqkcwl.Name = "chkqkcwl";
            this.chkqkcwl.Size = new System.Drawing.Size(128, 24);
            this.chkqkcwl.TabIndex = 28;
            this.chkqkcwl.Text = "仅库存为零的药品";
            this.chkqkcwl.CheckedChanged += new System.EventHandler(this.chkqkcwl_CheckedChanged);
            // 
            // cmbjx
            // 
            this.cmbjx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbjx.Enabled = false;
            this.cmbjx.Location = new System.Drawing.Point(104, 90);
            this.cmbjx.Name = "cmbjx";
            this.cmbjx.Size = new System.Drawing.Size(144, 20);
            this.cmbjx.TabIndex = 22;
            // 
            // chkjx
            // 
            this.chkjx.Enabled = false;
            this.chkjx.Location = new System.Drawing.Point(16, 85);
            this.chkjx.Name = "chkjx";
            this.chkjx.Size = new System.Drawing.Size(88, 25);
            this.chkjx.TabIndex = 23;
            this.chkjx.Text = "药品剂型";
            this.chkjx.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // cmbypzlx
            // 
            this.cmbypzlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbypzlx.Enabled = false;
            this.cmbypzlx.Location = new System.Drawing.Point(104, 64);
            this.cmbypzlx.Name = "cmbypzlx";
            this.cmbypzlx.Size = new System.Drawing.Size(144, 20);
            this.cmbypzlx.TabIndex = 19;
            this.cmbypzlx.DropDown += new System.EventHandler(this.cmbypzlx_DropDown);
            // 
            // chkyplx
            // 
            this.chkyplx.Location = new System.Drawing.Point(16, 38);
            this.chkyplx.Name = "chkyplx";
            this.chkyplx.Size = new System.Drawing.Size(88, 23);
            this.chkyplx.TabIndex = 20;
            this.chkyplx.Text = "药品类型";
            this.chkyplx.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // chkypzlx
            // 
            this.chkypzlx.Enabled = false;
            this.chkypzlx.Location = new System.Drawing.Point(16, 60);
            this.chkypzlx.Name = "chkypzlx";
            this.chkypzlx.Size = new System.Drawing.Size(88, 24);
            this.chkypzlx.TabIndex = 21;
            this.chkypzlx.Text = "药品子类型";
            this.chkypzlx.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(782, 358);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.商品名,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn5,
            this.dataGridBoolColumn1,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn10});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.Width = 30;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "品名";
            this.dataGridTextBoxColumn2.Width = 110;
            // 
            // 商品名
            // 
            this.商品名.Format = "";
            this.商品名.FormatInfo = null;
            this.商品名.HeaderText = "商品名";
            this.商品名.Width = 110;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "厂家";
            this.dataGridTextBoxColumn4.Width = 80;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "零售价";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "库存量";
            this.dataGridTextBoxColumn8.Width = 65;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "单位";
            this.dataGridTextBoxColumn9.Width = 30;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "零售金额";
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "货号";
            this.dataGridTextBoxColumn5.Width = 55;
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.AllowNull = false;
            this.dataGridBoolColumn1.FalseValue = ((short)(0));
            this.dataGridBoolColumn1.HeaderText = "禁用";
            this.dataGridBoolColumn1.NullValue = ((short)(0));
            this.dataGridBoolColumn1.TrueValue = ((short)(1));
            this.dataGridBoolColumn1.Width = 35;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "cjid";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "货位号";
            this.dataGridTextBoxColumn20.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "批发价";
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "批发金额";
            this.dataGridTextBoxColumn10.Width = 70;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 509);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1261, 24);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 150;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 150;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Text = "双击库存记录可禁用库存量小于等于零的药品";
            this.statusBarPanel4.Width = 300;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.splitter1);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1261, 378);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存情况";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myDataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 358);
            this.panel1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(785, 17);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 358);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(789, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 358);
            this.panel2.TabIndex = 2;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.Size = new System.Drawing.Size(469, 358);
            this.myDataGrid2.TabIndex = 0;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid2.DoubleClick += new System.EventHandler(this.myDataGrid2_DoubleClick);
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn19,
            this.col_批次号,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridBoolColumn2,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn17,
            this.col_kcid});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "进价";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.ReadOnly = true;
            this.dataGridTextBoxColumn19.Width = 60;
            // 
            // col_批次号
            // 
            this.col_批次号.Format = "";
            this.col_批次号.FormatInfo = null;
            this.col_批次号.HeaderText = "批次号";
            this.col_批次号.Width = 95;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "批号";
            this.dataGridTextBoxColumn12.Width = 60;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "效期";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.Width = 70;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "库存量";
            this.dataGridTextBoxColumn13.Width = 60;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "单位";
            this.dataGridTextBoxColumn14.Width = 30;
            // 
            // dataGridBoolColumn2
            // 
            this.dataGridBoolColumn2.AllowNull = false;
            this.dataGridBoolColumn2.FalseValue = ((short)(0));
            this.dataGridBoolColumn2.HeaderText = "禁用";
            this.dataGridBoolColumn2.NullValue = ((short)(0));
            this.dataGridBoolColumn2.ReadOnly = true;
            this.dataGridBoolColumn2.TrueValue = ((short)(1));
            this.dataGridBoolColumn2.Width = 30;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "cjid";
            this.dataGridTextBoxColumn16.Width = 0;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "id";
            this.dataGridTextBoxColumn17.Width = 0;
            // 
            // col_kcid
            // 
            this.col_kcid.Format = "";
            this.col_kcid.FormatInfo = null;
            this.col_kcid.HeaderText = "kcid";
            this.col_kcid.Width = 0;
            // 
            // Frmkccx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1261, 533);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmkccx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "库存情况查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmkccx_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbpctz.ResumeLayout(false);
            this.grbpctz.PerformLayout();
            this.grbpcxz.ResumeLayout(false);
            this.grbpcxz.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void chkyplx_CheckedChanged(object sender, System.EventArgs e)
		{
			cmbyplx.Enabled=chkyplx.Checked==true?true:false;
			
			chkypzlx.Enabled=chkyplx.Checked==true?true:false;
			cmbypzlx.Enabled=chkypzlx.Checked==true?true:false;
			
			chkjx.Enabled=chkyplx.Checked==true?true:false;
			cmbjx.Enabled=chkjx.Checked==true?true:false;
			cmbsccj.Enabled=chksccj.Checked==true?true:false;

			if (chkyplx.Checked==false)
			{
				chkypzlx.Checked=false;
				chkjx.Checked=false;

			}

		}

		private void butcx_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tbmx=(DataTable)this.myDataGrid2.DataSource;
				tbmx.Rows.Clear();

                int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue,"0"));
                int deptid_ck = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
                if (deptid_ck > 0)
                    deptid = deptid_ck;

                //DataTable tb = new DataTable("Tb");
                string ssql = "select 0 序号,yppm 品名,ypspm 商品名,ypgg 规格,s_sccj 厂家,cast(round(lsj/dwbl,4) as float) 零售价," +
                    " kcl 库存量,dbo.fun_yp_ypdw(zxdw) 单位," +
                    " cast(lsj*kcl/dwbl as decimal(14,2)) 零售金额,shh 货号,CAST(BDELETE_KC AS SMALLINT) 禁用,cjid,b.hwmc 货位号,cast(round(pfj/dwbl,4) as float) 批发价,cast(pfj*kcl/dwbl as decimal(18,2)) 批发金额  " +
                    " from vi_yk_kcmx a left join yp_hwsz b on a.ggid=b.ggid and a.deptid=b.deptid where a.deptid=" + Convert.ToInt32(cmbck.SelectedValue) + " ";

                if (chkyplx.Checked == true && Convertor.IsNull(cmbyplx.SelectedValue, "") != "0") ssql = ssql + " and yplx=" + Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0")) + " ";
                if (chkypzlx.Checked == true) ssql = ssql + " and ypzlx=" + Convert.ToInt32(Convertor.IsNull(cmbypzlx.SelectedValue, "0")) + " ";
                if (chkjx.Checked == true) ssql = ssql + " and ypjx=" + Convert.ToInt32(Convertor.IsNull(cmbjx.SelectedValue, "0")) + " ";
                if (chksccj.Checked == true) ssql = ssql + " and sccj=" + Convert.ToInt32(Convertor.IsNull(cmbsccj.Tag, "0")) + " ";
			
				if (chkqkcwl.Checked==true) 
				{
					ssql=ssql+" and kcl=0 and bdelete_kc=0";
				}

                if (chkqkcxyl.Checked == true)
                {
                    ssql = ssql + " and kcl<0 ";
                }

				if (chkqjy.Checked==true) 
				{
					ssql=ssql+" and  bdelete_kc=1";
				}

				if (chkqkcwl.Checked==false && chkqjy.Checked==false)
				{
					ssql=ssql+" and  (bdelete_kc=0 or kcl<>0)";
				}
                if (chkbwl.Checked == true)
                {
                    ssql = ssql + " and  kcl<>0";
                }

				if (txtdm.Text.Trim()!="")
				{
					ssql=ssql+" and ( a.ggid in(select ggid from yp_ypbm where Upper(pym) like '"+txtdm.Text.Trim().ToUpper()+"%' or Upper(wbm) like '"+txtdm.Text.Trim().ToUpper()+"%'"+
                        " or Upper(szm) like '" + txtdm.Text.Trim().ToUpper() + "%' or ypbm like '%" + txtdm.Text.Trim() + "%') or shh like '%" + txtdm.Text.Trim() + "%')";
				}

                switch (cmbsort.SelectedIndex)
                {
                    case 0:
                        ssql = ssql + " order by hwmc,yplx,ypjx,a.ggid,a.cjid";
                        break;
                    case 1:
                        ssql = ssql + " order by yppm";
                        break;
                    case 2:
                        ssql = ssql + " order by shh";
                        break;
                    case 3:
                        ssql = ssql + " order by n_yplx,s_ypjx";
                        break;
                    default:
                        break;
                }


                DataView dv = InstanceForm.BDatabase.GetDataTable(ssql, 60).DefaultView;
                FunBase.AddRowtNo(dv.Table);
                dv.Table.TableName = "Tb";
                //myDataGrid1.DataMember = "Tb";
                myDataGrid1.DataSource = dv;


                DataTable tb = dv.Table;
				decimal sumpfje=0;
				decimal sumlsje=0;
				decimal sumplce=0;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					sumpfje=sumpfje+Convert.ToDecimal(tb.Rows[i]["批发金额"]);
					sumlsje=sumlsje+Convert.ToDecimal(tb.Rows[i]["零售金额"]);
				}
				sumplce=sumlsje-sumpfje;
				this.statusBar1.Panels[0].Text="批发金额 "+sumpfje.ToString("0.00");
				this.statusBar1.Panels[1].Text="零售金额 "+sumlsje.ToString("0.00");
				this.statusBar1.Panels[2].Text="批零差额 "+sumplce.ToString("0.00");
			}
			catch(System.Exception err)
			{
                
				MessageBox.Show("对不起,发生错误"+err.Message );
			}
		}

		private void Frmkccx_Load(object sender, System.EventArgs e)
		{
			DataTable Tb=new DataTable();
			Tb.TableName="Tb";
			for(int i=0;i<=this.myDataGrid1.TableStyles[0].GridColumnStyles.Count-1;i++) 
			{	
				if(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
					Tb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.Int16"));	
				else
					Tb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
				this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
				this.myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText="";
			}
			this.myDataGrid1.DataSource=Tb;
			this.myDataGrid1.TableStyles[0].MappingName ="Tb";

			DataTable Tb1=new DataTable();
			Tb1.TableName="Tb1";
			for(int i=0;i<=this.myDataGrid2.TableStyles[0].GridColumnStyles.Count-1;i++) 
			{	
				if(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
					Tb1.Columns.Add(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.Int16"));	
				else
					Tb1.Columns.Add(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
				this.myDataGrid2.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText;
				this.myDataGrid2.TableStyles[0].GridColumnStyles[i].NullText="";
			}
			this.myDataGrid2.DataSource=Tb1;
			this.myDataGrid2.TableStyles[0].MappingName ="Tb1";


            Yp.AddCmbYjks(false, InstanceForm.BCurrentDept.DeptId, cmbyjks, InstanceForm.BDatabase);

            cmbsort.SelectedIndex = 0;

            if (bpcgl)
            {
                if (InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药房操作员
                   && InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药库操作员)
                {
                    grbpcxz.Visible = false;
                    grbpctz.Visible = false;
                }
                else
                {
                    grbpcxz.Visible = true;
                    grbpctz.Visible = true;
                }
            }

			
		}

		private void cmbypzlx_DropDown(object sender, System.EventArgs e)
		{
            int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));
            int deptid_ck = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
            if (deptid_ck > 0)
                deptid = deptid_ck;

            Yp.AddCmbYpzlx(deptid, Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0")), this.cmbypzlx, InstanceForm.BDatabase);
			Yp.AddcmbYpjx(Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue,"0")),this.cmbjx, InstanceForm.BDatabase);
		}

		private void cmbyplx_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cmbypzlx.DataSource=null;
			cmbjx.DataSource=null;
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
                int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));
                int deptid_ck = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
                if (deptid_ck > 0)
                    deptid = deptid_ck;

				string yplx=chkyplx.Checked==true?Convertor.IsNull(cmbyplx.Text,"全部"):"全部";
				string ypzlx=chkypzlx.Checked==true?Convertor.IsNull(cmbypzlx.Text,"全部"):"全部";
				string ypjx=chkjx.Checked==true?Convertor.IsNull(cmbjx.Text,"全部"):"全部";

                DataView dv = (DataView)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset1 Dset=new ts_Yk_ReportView.Dataset1();

				DataRow myrow;
				for(int i=0;i<=dv.Table.Rows.Count-1;i++)
				{
					myrow=Dset.库存情况表.NewRow();
					myrow["xh"]=Convert.ToInt32(dv[i]["序号"]);
					myrow["ypspm"]=Convert.ToString(dv[i]["品名"]);
					myrow["ypgg"]=Convert.ToString(dv[i]["规格"]);
					myrow["sccj"]=Convert.ToString(dv[i]["厂家"]);
					myrow["pfj"]=Convert.ToString(dv[i]["批发价"]);
					myrow["lsj"]=Convert.ToString(dv[i]["零售价"]);
					myrow["kcl"]=Convert.ToString(dv[i]["库存量"]);
					myrow["ypdw"]=Convert.ToString(dv[i]["单位"]);
					myrow["pfje"]=Convert.ToString(dv[i]["批发金额"]);
					myrow["lsje"]=Convert.ToString(dv[i]["零售金额"]);
					myrow["shh"]=Convert.ToString(dv[i]["货号"]);
                    myrow["hwh"] = Convert.ToString(dv[i]["货位号"]);
					Dset.库存情况表.Rows.Add(myrow);

				}

				ParameterEx[] parameters=new ParameterEx[4];
				parameters[0].Text="yplx";
				parameters[0].Value=yplx.Trim();
				parameters[1].Text="ypzlx";
				parameters[1].Value=ypzlx.Trim();
				parameters[2].Text="ypjx";
				parameters[2].Value=ypjx.Trim();
				parameters[3].Text="TITLETEXT";
                parameters[3].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + Yp.SeekDeptName(deptid, InstanceForm.BDatabase) + ")" + this.Text;
				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.库存情况表,Constant.ApplicationDirectory+"\\Report\\YK_库存情况表.rpt",parameters);

				if (f.LoadReportSuccess) f.Show();else  f.Dispose();

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void txtdm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (Convert.ToInt32(e.KeyCode)==13) this.butcx_Click(sender,e);
		}

		private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
                int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));
                int deptid_ck = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
                if (deptid_ck > 0)
                    deptid = deptid_ck;

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				if (nrow>tb.Rows.Count-1) return;
				int cjid=Convert.ToInt32(tb.Rows[nrow]["cjid"]);

				if (Convert.ToBoolean(tb.Rows[nrow]["禁用"])==true)
				{
					if(MessageBox.Show(this, "您要 [取消禁用] 当前这个库存药品吗?", "确认", MessageBoxButtons.YesNo)==DialogResult.No ) return;
                    string ssql = "update yk_kcmx set bdelete=0 where deptid=" + deptid + " and cjid=" + cjid + "";
					InstanceForm.BDatabase.DoCommand(ssql);
					tb.Rows[nrow]["禁用"]=(short)0;
				}
				else
				{
					if (Convert.ToDecimal(tb.Rows[nrow]["库存量"])!=0) {MessageBox.Show("库存不为零时不能禁用");return;}
					if(MessageBox.Show(this, "您要 [禁用] 当前这个库存药品吗?", "确认", MessageBoxButtons.YesNo)==DialogResult.No ) return;

                    string ssql = "select *  from yk_kcph where cjid=" + cjid + " and deptid=" + deptid + " and bdelete=0";
					DataTable tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
					if (tbmx.Rows.Count!=0) {MessageBox.Show("对不起,这个药品的相关批号还有库存,不能禁用");return;}

                    ssql = "update yk_kcmx set bdelete=1 where deptid=" + deptid + " and cjid=" + cjid + "";
					InstanceForm.BDatabase.DoCommand(ssql);
					tb.Rows[nrow]["禁用"]=(short)1;
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
				
		}

		private void myDataGrid1_CurrentCellChanged(object se98nder, System.EventArgs e)
		{
			try
			{
                int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));
                int deptid_ck = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
                if (deptid_ck > 0)
                    deptid = deptid_ck;

                DataView dv = (DataView)this.myDataGrid1.DataSource;
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				if (nrow>dv.Table.Rows.Count-1)return;
                string ssql = "select jhj 进价,yppch 批次号,ypph 批号,ypxq 效期,cast(kcl as float) 库存量,dbo.fun_yp_ypdw(zxdw) 单位,cast(BDELETE as smallint)  禁用,cjid,id , id kcid  from yk_kcph where cjid=" + Convert.ToInt32(dv[nrow]["cjid"]) + " and deptid=" + deptid + "";
                ssql += " order by djsj desc,yppch desc ";
                
                DataTable tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
				tbmx.TableName="Tb1";
				this.myDataGrid2.DataSource=tbmx;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}

		private void myDataGrid2_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
                if (InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药房操作员
                     && InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药库操作员)
                {
                    MessageBox.Show("非药房药库操作员不能执行该操作");
                    return;
                }

                int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));
                int deptid_ck = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
                if (deptid_ck > 0)
                    deptid = deptid_ck;

				DataTable tb=(DataTable)this.myDataGrid2.DataSource;
				int nrow=this.myDataGrid2.CurrentCell.RowNumber;
				if (nrow>tb.Rows.Count-1) return;
				int cjid=Convert.ToInt32(tb.Rows[nrow]["cjid"]);
				Guid id=new Guid(tb.Rows[nrow]["id"].ToString());
				string bz="";
				string sdate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

				if (Convert.ToBoolean(tb.Rows[nrow]["禁用"])==true)
				{
					if(MessageBox.Show(this, "您要 [取消禁用] 当前这个库存批号吗?", "确认", MessageBoxButtons.YesNo)==DialogResult.No ) return;
                    string ssql = "update Yk_kcph set bdelete=0 where deptid=" + deptid + " and cjid=" + cjid + " and id='" + id + "'";
					InstanceForm.BDatabase.DoCommand(ssql);
                    ssql = "update Yk_kcmx set bdelete=0 where deptid=" + deptid + " and cjid=" + cjid + "";
					InstanceForm.BDatabase.DoCommand(ssql);
					tb.Rows[nrow]["禁用"]=(short)0;
					bz=InstanceForm.BCurrentDept.DeptName+"取消禁用的批号为 ["+tb.Rows[nrow]["批号"].ToString()+"] 当时该批号库存为 "+tb.Rows[nrow]["库存量"]+tb.Rows[nrow]["单位"].ToString();
				}
				else
				{
					//					if (Convert.ToDecimal(tb.Rows[nrow]["库存量"])!=0) {MessageBox.Show("库存不为零时不能禁用");return;}
					if(MessageBox.Show(this, "您要 [禁用] 当前这个库存批号吗?", "确认", MessageBoxButtons.YesNo)==DialogResult.No ) return;
                    string ssql = "update Yk_kcph set bdelete=1 where deptid=" + deptid + " and cjid=" + cjid + " and id='" + id + "'";
					InstanceForm.BDatabase.DoCommand(ssql);
                    ssql = "select * from yk_kcph where deptid=" + deptid + " and cjid=" + cjid + " and bdelete=0";
					DataTable tbph=InstanceForm.BDatabase.GetDataTable(ssql);
					bz=InstanceForm.BCurrentDept.DeptName+"禁用的批号为 ["+tb.Rows[nrow]["批号"].ToString()+"] 当时该批号库存为 "+tb.Rows[nrow]["库存量"]+tb.Rows[nrow]["单位"].ToString();
					if (tbph.Rows.Count==0)
					{
						bz="◆"+bz;
                        ssql = "update Yk_kcmx set bdelete=1 where deptid=" + deptid + " and cjid=" + cjid + "";
						InstanceForm.BDatabase.DoCommand(ssql);
					}
					tb.Rows[nrow]["禁用"]=(short)1;
				}
                Yp.InsertLog("禁用药品", InstanceForm.BCurrentDept.DeptId, cjid, InstanceForm.BCurrentUser.EmployeeId, sdate, bz, InstanceForm.BDatabase);
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void chkqkcwl_CheckedChanged(object sender, System.EventArgs e)
		{
            if (this.chkqkcwl.Checked == true)
            {
                this.chkqkcxyl.Checked = false;
                this.chkqjy.Checked = false;
            }
			
		}

		private void chkqjy_CheckedChanged(object sender, System.EventArgs e)
		{
            if (this.chkqjy.Checked == true)
            {
                this.chkqkcxyl.Checked = false;
                this.chkqkcwl.Checked = false;
            }
		}

        private void chkqkcxyl_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkqkcxyl.Checked == true)
            {
                this.chkqjy.Checked = false;
                this.chkqkcwl.Checked = false;
            }
        }

		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			try
			{
				Control control=(Control)sender;

				if (control.Text.Trim()=="" )
				{
					control.Text="";
					control.Tag="0";
				}

				if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (control.Tag.ToString()=="0" || control.Tag.ToString()=="")))
				{
				}
				else
				{
					return;
				}

				
				Point point=new Point(this.Location.X+control.Location.X,this.Location.Y+control.Location.Y+control.Height*3 );
				switch(control.TabIndex)
				{
					case 35://生产厂家
						if (nkey==13 && (control.Tag.ToString()!="" && control.Tag.ToString()!="0")) return;
                        Yp.frmShowCard(sender, ShowCardType.厂家, 0, point, Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
						if (Convertor.IsNull(control.Tag,"0")!="0") this.SelectNextControl((Control)sender,true,false,true,true);
						break;
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void butjy_Click(object sender, System.EventArgs e)
		{
            if (InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药房操作员
                 && InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药库操作员)
            {
                MessageBox.Show("非药房药库操作员不能执行该操作");
                return;
            }

			if(MessageBox.Show(this, "此操作将禁用有多个批号，且相应批号库存为零的批号记录,您确定要执行吗?", "确认", MessageBoxButtons.YesNo)==DialogResult.No ) return;

			try
			{
                int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));
                int deptid_ck = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
                if (deptid_ck > 0)
                    deptid = deptid_ck;

				InstanceForm.BDatabase.BeginTransaction();
				
				string ssql="update yk_kcph set bdelete=1 where id not in( "+
                " select isnull((select top 1 id from yk_kcph where cjid=a.cjid and deptid=a.deptid and bdelete=0 order by kcl desc),dbo.FUN_GETEMPTYGUID()) " +
					" from yk_kcph a where deptid="+deptid+
				")  and deptid="+deptid+" and kcl=0";
				InstanceForm.BDatabase.DoCommand(ssql);

				InstanceForm.BDatabase.CommitTransaction();

				MessageBox.Show("更新成功");
			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show(err.Message);
			}
		}

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), this.cmbyplx,InstanceForm.BDatabase);

            Yp.AddCmbYjks_ck(false, Convert.ToInt32(cmbyjks.SelectedValue), cmbck, InstanceForm.BDatabase);
            if (cmbck.Items.Count == 0)
            {
                cmbck.Visible = false;
                lblck.Visible = false;
            }
            else
            {
                cmbck.Visible = true;
                lblck.Visible = true;
            }
        
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataView dv = (DataView)this.myDataGrid1.DataSource;

                // 创建Excel对象                  
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
                int RowCount =dv.Table.Rows.Count;
                for (int i = 0; i <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].Width > 0)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = this.Text;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                //查询条件
                string bz = "";
                bz = bz + "药剂科室:" + cmbyjks.Text.Trim() + "   仓库名称:"+cmbck.Text.Trim()+"    库存金额:" + dv.Table.Compute("sum(零售金额)", "").ToString(); ;
                string swhere = "  " + bz;
                // 设置条件
                Excel.Range rangeT = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                rangeT.MergeCells = true;
                object[,] objDataT = new object[1, 1];
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                objDataT[0, 0] = swhere;
                range.Value2 = objDataT;



                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].Width > 0)
                        objData[0, colIndex++] = myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= dv.Table.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; j++)
                    {
                        if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width > 0)
                        {
                            objData[i + 1, colIndex++] = "" + dv[i][j].ToString();
                        }
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 3, colCount]).Font.Size = 9;

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

        private void cmbck_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue,"0"));
            bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);
            if (bpcgl)
            {
                col_批次号.Width = 100;
            }
            else
            {
                col_批次号.Width = 0;
            }
        }

        //保存效期修改
        private void btnbcpc_Click(object sender, EventArgs e)
        {
            try
            {
                if (InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药房操作员
                   && InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药库操作员)
                {
                    MessageBox.Show("非药房药库操作员不能执行该操作");
                    return;
                }

                int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0"));
                int deptid_ck = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
                if (deptid_ck > 0)
                    deptid = deptid_ck;
                if (deptid <= 0) return;

                string yppch = lblpch.Text;//批次号
                int cjid = Convert.ToInt32(lblpch.Tag);//cjid
                string xq = dtpxq.Value.ToShortDateString();//效期
                Guid kcid = new Guid(dtpxq.Tag.ToString());

                string yxq = Convert.ToDateTime(grbpcxz.Tag).ToShortDateString();//原效期

                if (yppch == string.Empty)
                {
                    return;
                }

                DialogResult result = MessageBox.Show("确定要修正效期？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    //更新药库
                    string ssql = string.Format(" update yk_kcph set ypxq='{0}' where cjid={1} and id='{2}' and yppch='{3}'  and deptid={4}",xq,cjid,kcid,yppch,deptid);
                    int i = InstanceForm.BDatabase.DoCommand(ssql);
                    if (i <= 0)
                    {
                        MessageBox.Show("修正药库库存效期失败，影响到数据库0行！");
                        return;
                    }
                    else
                    {

                        SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId,
                                                                 InstanceForm.BCurrentUser.EmployeeId,
                                                                 "修改药品效期",
                          string.Format("cjid={0},kcid={1}的药品效期由{2}修改成{3}",cjid,kcid,yxq,xq),
                                                                 DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase),
                                                                 1,
                                                                 "主机名：" + System.Environment.MachineName, 39);
                        _systemLog.Save();
                        _systemLog = null;

                      ;
                        DataTable tb_kcph = (DataTable)myDataGrid2.DataSource;
                        tb_kcph.Rows.Clear();
                        myDataGrid2.DataSource = tb_kcph;

                        MessageBox.Show("修正成功！");
                    }


                    //更新药房
                    ssql = string.Format(" update yf_kcph set ypxq='{0}' where cjid={1} and yppch='{2}'", xq, cjid, yppch);
                    InstanceForm.BDatabase.DoCommand(ssql);

                }
                
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void myDataGrid2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药房操作员
                 && InstanceForm.BCurrentUser.Rylx != TrasenClasses.GeneralClasses.EmployeeType.药库操作员)
                {
                    MessageBox.Show("非药房药库操作员不能执行该操作");
                    return;
                }

                DataTable tb_kcph = (DataTable)this.myDataGrid2.DataSource;
                int nrow = this.myDataGrid2.CurrentCell.RowNumber;
                if (nrow > tb_kcph.Rows.Count - 1) return;
                DataRow row = tb_kcph.Rows[nrow];
                lblpch.Text = row["批次号"].ToString();
                lblpch.Tag = Convert.ToInt32(row["cjid"]);
                dtpxq.Value = Convert.ToDateTime(row["效期"]);
                dtpxq.Tag = row["kcid"];
                grbpcxz.Tag = Convert.ToDateTime(row["效期"]);


                int cjid = Convert.ToInt32(row["cjid"]);
                Guid kcid = new Guid(row["kcid"].ToString());
                string yppch = row["批次号"].ToString();
                int deptid = Convert.ToInt32(cmbyjks.SelectedValue);

                grbpctz.Tag = deptid;
                lblypch.Text = yppch;
                lblypch.Tag = kcid;
                txttzsl.Tag = cjid;

                string ssql = string.Format(" select yppch, id kcid from yk_kcph where deptid={0} and cjid={1} order by djsj desc,yppch desc  ",deptid,cjid);
                DataTable tb_pc = InstanceForm.BDatabase.GetDataTable(ssql);
                cmbtpch.DataSource = tb_pc;
                cmbtpch.ValueMember = "kcid";
                cmbtpch.DisplayMember = "yppch";


               
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void txttzsl_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void btnSavePctz_Click(object sender, EventArgs e)
        {
            decimal tzsl = Convert.ToDecimal(Convertor.IsNull(txttzsl.Text, "0"));//调整数量
            string ypch = lblypch.Text;
            Guid ykcid = new Guid(Convertor.IsNull(lblypch.Tag, Guid.Empty.ToString()));
            string tpch = cmbtpch.Text;
            Guid tkcid = new Guid(Convertor.IsNull(cmbtpch.SelectedValue, Guid.Empty.ToString()));
            int deptid=Convert.ToInt32(grbpctz.Tag);//科室id
            int cjid=Convert.ToInt32(txttzsl.Tag); //cjid

            Guid _djid=Guid.Empty;
            int _err_code = 0;
            string _err_text = "";

            if (ypch == ""||ykcid==Guid.Empty)
            {
                return;
            }

            if(tpch==""||tkcid==Guid.Empty)
            {
                return;
            }

            if (tzsl <= 0)
            {
                MessageBox.Show("调整数量必须大于0");
                return;
            }

            Ypcj cj=new Ypcj(cjid,InstanceForm.BDatabase);

            string ssql="";
            DataRow yrow;
            DataRow trow;

            ssql=string.Format(" select * from yk_kcph  where id='{0}' and yppch='{1}'",ykcid,ypch);
            DataTable tb_ypc=InstanceForm.BDatabase.GetDataTable(ssql);
            if(tb_ypc.Rows.Count<=0)
            {
                MessageBox.Show(string.Format("找不到原批次【{0}】",ypch));
                return;
            }
            else
            {
                yrow=tb_ypc.Rows[0];
            }
            decimal ykcl=Convert.ToDecimal(yrow["kcl"]);
            if(ykcl<tzsl)
            {
                MessageBox.Show(string.Format("原批次库存量:{0}小于调整数量:{1}",ykcl,tzsl));
                return;
            }
            

            ssql=string.Format(" select * from yk_kcph  where id='{0}' and yppch='{1}'",tkcid,tpch);
            DataTable tb_tpc=InstanceForm.BDatabase.GetDataTable(ssql);
            if(tb_tpc.Rows.Count<=0)
            {
                MessageBox.Show(string.Format("找不到调批次【{0}】",tpch));
                return;
            }
            else
            {
                trow=tb_tpc.Rows[0];
            }

            if (tpch == ypch)
            {
                MessageBox.Show("调批次不能跟原批次相同！");
                return;
            }

            int ydwbl=Convert.ToInt32(yrow["dwbl"]);
            decimal yjhj=Convert.ToDecimal(yrow["jhj"]);//原进价
            decimal tjhj=Convert.ToDecimal(trow["jhj"]);//调进价
            decimal sumjhje=Convert.ToDecimal((tjhj-yjhj)*tzsl);//调进货金额
            decimal sumpfje=0;
            decimal sumlsje=0;

            decimal lsj=Convert.ToDecimal(cj.LSJ/ydwbl);
            decimal pfj=Convert.ToDecimal(cj.PFJ/ydwbl);
            
            decimal yjhje=Convert.ToDecimal(yjhj*tzsl);
            decimal ypfje=Convert.ToDecimal(pfj*tzsl);
            decimal ylsje=Convert.ToDecimal(lsj*tzsl);

            decimal tjhje=Convert.ToDecimal(tjhj*tzsl*(-1));
            decimal tpfje=Convert.ToDecimal(ypfje*(-1));
            decimal tlsje=Convert.ToDecimal(ylsje*(-1));

            string yph=yrow["ypph"].ToString();//原批号
            string yxq=yrow["ypxq"].ToString();//原效期

            string tph=trow["ypph"].ToString();//调批号
            string txq=trow["ypxq"].ToString();//调效期

            DialogResult result = MessageBox.Show(
                string.Format("确定调整【{0}【{1}】\n   批次:{2},数量：{3}[{4}] \n到批次:{5}？", cj.S_YPPM, cj.S_YPGG, ypch, tzsl, cj.S_YPDW,
                tpch), "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                DateTime serverTime=Convert.ToDateTime(InstanceForm.BDatabase.GetDataResult(InstanceForm.BDatabase.GetServerTimeString()));
                InstanceForm.BDatabase.BeginTransaction();

                string ywlx="034";
                long djh=Yp.SeekNewDjh(ywlx,Convert.ToInt64(deptid),InstanceForm.BDatabase);
                string sdjh=Yp.SeekNewDjh_Str(ywlx,Convert.ToInt64(deptid),InstanceForm.BDatabase);

                #region 批次调整
                Yk_dj_djmx.SaveDJ(Guid.Empty,
                                    djh,
                                    deptid,
                                    ywlx,
                                    deptid,
                                    0,
                                    serverTime.ToShortDateString(),
                                    InstanceForm.BCurrentUser.EmployeeId,
                                    serverTime.ToShortDateString(),
                                    serverTime.ToShortTimeString(),
                                    "",
                                    "",
                                    "",
                                    "",
                                    0,
                                    0,
                                    sumjhje,
                                    sumpfje,
                                    sumlsje,
                                    sdjh,
                                    out _djid,
                                    out _err_code,
                                    out _err_text,
                                    InstanceForm._menuTag.Jgbm,
                                    InstanceForm.BDatabase);
                if(_err_code!=0)
                {
                    throw new Exception(_err_text);  
                }

                #region  原批次单据明细
                Yk_dj_djmx.SaveDJMX(Guid.Empty,_djid,cjid,0,cj.SHH,
                    cj.S_YPPM,cj.S_YPSPM,cj.S_YPGG,cj.S_SCCJ,

                    yph,yxq,
                    
                    0,0,tzsl,cj.S_YPDW,Yp.SeekYpdw(cj.S_YPDW,InstanceForm.BDatabase),
                    ydwbl,
                    yjhj,
                    pfj,
                    lsj,
                    yjhje,
                    ypfje,
                    ylsje,
                    djh,
                    Convert.ToInt64(deptid),
                    ywlx,
                    "",
                    "",0,
                    out _err_code,
                    out _err_text,
                    InstanceForm.BDatabase,
                    1,
                    ypch,
                    ykcid);
                if(_err_code!=0)
                {
                    throw new Exception(_err_text);
                }
                #endregion

                #region 调批次单据明细
                Yk_dj_djmx.SaveDJMX(Guid.Empty,_djid,cjid,0,cj.SHH,
                    cj.S_YPPM,cj.S_YPSPM,cj.S_YPGG,cj.S_SCCJ,

                    tph
                    ,txq,

                    0,0,
                    Convert.ToDecimal(tzsl*(-1)),
                    cj.S_YPDW,Yp.SeekYpdw(cj.S_YPDW,InstanceForm.BDatabase),
                    ydwbl,
                    yjhj,
                    pfj,
                    lsj,
                    tjhje,
                    tpfje,
                    tlsje,
                    djh,
                    Convert.ToInt64(deptid),
                    ywlx,
                    "",
                    "",0,
                    out _err_code,
                    out _err_text,
                    InstanceForm.BDatabase,
                    1,
                    tpch,
                    tkcid);
                if(_err_code!=0)
                {
                    throw new Exception(_err_text);
                }
                #endregion

                Yk_dj_djmx.Shdj(_djid, serverTime.ToString(), InstanceForm.BDatabase);


                Yk_dj_djmx.AddUpdateKcmx(_djid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                if (_err_code != 0)
                {
                    throw new Exception(_err_text);
                }

                MessageBox.Show("调整成功！");
                DataTable tb_kcph = (DataTable)myDataGrid2.DataSource;
                tb_kcph.Rows.Clear();
                myDataGrid2.DataSource = tb_kcph;
                txttzsl.Text = "";


                #endregion

                InstanceForm.BDatabase.CommitTransaction();
            }
            catch(Exception err)
            {
               InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.ToString());
            }

        }

        private void txttzsl_Leave(object sender, EventArgs e)
        {
            if (Convertor.IsNumeric(txttzsl.Text))
            {
                txttzsl.Text = Convert.ToDecimal(txttzsl.Text).ToString("0.000");
            }
            else
            {
                txttzsl.Text = "";
            }
        }

	}
}
