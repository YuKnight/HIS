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
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmypmxz : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdomonth;
		private System.Windows.Forms.ComboBox cmbyear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbllsj;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label lblpfj;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label lblhh;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lblypmc;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label lblcj;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lblgg;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label3;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.GroupBox groupBox3;
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
		private System.Windows.Forms.Button butref;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.TextBox txtdm;
		private System.Windows.Forms.Label lbldw;
		private System.Windows.Forms.ComboBox cmbmonth;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.StatusBarPanel statusBarPanel5;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.DataGridTextBoxColumn col_批号;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn col_效期;
		private Form _mdiParent;
		private MenuTag _menuTag;
		private string _chineseName;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.RadioButton rdorq;
        private ComboBox cmbyjks;
        private Label label6;
        private ComboBox cmbck;
        private Label lblck;
        private GroupBox groupBox4;
        private RadioButton rdodf;
        private RadioButton rdojf;
        private RadioButton rdoall;
        private DataSet dset;
        private DataGridTextBoxColumn col_批次号;

        private bool bpcgl = false;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmypmxz(MenuTag menuTag,string chineseName,Form mdiParent)
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.lblck = new System.Windows.Forms.Label();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.rdorq = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbyear = new System.Windows.Forms.ComboBox();
            this.rdomonth = new System.Windows.Forms.RadioButton();
            this.butprint = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butref = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdodf = new System.Windows.Forms.RadioButton();
            this.rdojf = new System.Windows.Forms.RadioButton();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.lbldw = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbllsj = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblpfj = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblhh = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblypmc = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblcj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblgg = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_批次号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_批号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_效期 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel5 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.lblck);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.rdorq);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbmonth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbyear);
            this.groupBox1.Controls.Add(this.rdomonth);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1131, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Location = new System.Drawing.Point(335, 13);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(140, 20);
            this.cmbck.TabIndex = 40;
            this.cmbck.SelectedIndexChanged += new System.EventHandler(this.cmbck_SelectedIndexChanged);
            // 
            // lblck
            // 
            this.lblck.ForeColor = System.Drawing.Color.Black;
            this.lblck.Location = new System.Drawing.Point(281, 18);
            this.lblck.Name = "lblck";
            this.lblck.Size = new System.Drawing.Size(67, 16);
            this.lblck.TabIndex = 39;
            this.lblck.Text = "仓库名称";
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(103, 13);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(177, 20);
            this.cmbyjks.TabIndex = 32;
            this.cmbyjks.SelectionChangeCommitted += new System.EventHandler(this.cmbyjks_SelectionChangeCommitted);
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(40, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "药剂科室";
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(520, 42);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(111, 21);
            this.dtp2.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(502, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(383, 42);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(113, 21);
            this.dtp1.TabIndex = 20;
            // 
            // rdorq
            // 
            this.rdorq.Checked = true;
            this.rdorq.ForeColor = System.Drawing.Color.Black;
            this.rdorq.Location = new System.Drawing.Point(295, 42);
            this.rdorq.Name = "rdorq";
            this.rdorq.Size = new System.Drawing.Size(96, 24);
            this.rdorq.TabIndex = 19;
            this.rdorq.TabStop = true;
            this.rdorq.Text = "按日期查询";
            this.rdorq.Click += new System.EventHandler(this.rdorq_Click);
            this.rdorq.CheckedChanged += new System.EventHandler(this.rdorq_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(649, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 21);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "显示病人处方明细";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(263, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "月";
            // 
            // cmbmonth
            // 
            this.cmbmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbmonth.Location = new System.Drawing.Point(199, 43);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(64, 20);
            this.cmbmonth.TabIndex = 4;
            this.cmbmonth.SelectedIndexChanged += new System.EventHandler(this.cmbmonth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(184, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "年";
            // 
            // cmbyear
            // 
            this.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyear.Items.AddRange(new object[] {
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010"});
            this.cmbyear.Location = new System.Drawing.Point(119, 43);
            this.cmbyear.Name = "cmbyear";
            this.cmbyear.Size = new System.Drawing.Size(65, 20);
            this.cmbyear.TabIndex = 2;
            this.cmbyear.SelectedIndexChanged += new System.EventHandler(this.cmbyear_SelectedIndexChanged);
            // 
            // rdomonth
            // 
            this.rdomonth.ForeColor = System.Drawing.Color.Black;
            this.rdomonth.Location = new System.Drawing.Point(40, 42);
            this.rdomonth.Name = "rdomonth";
            this.rdomonth.Size = new System.Drawing.Size(96, 24);
            this.rdomonth.TabIndex = 0;
            this.rdomonth.Text = "按月份查看";
            this.rdomonth.Click += new System.EventHandler(this.rdorq_Click);
            this.rdomonth.CheckedChanged += new System.EventHandler(this.rdorq_CheckedChanged);
            // 
            // butprint
            // 
            this.butprint.ForeColor = System.Drawing.Color.Black;
            this.butprint.Location = new System.Drawing.Point(640, 40);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(80, 24);
            this.butprint.TabIndex = 13;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butquit
            // 
            this.butquit.ForeColor = System.Drawing.Color.Black;
            this.butquit.Location = new System.Drawing.Point(720, 40);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(80, 24);
            this.butquit.TabIndex = 12;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butref
            // 
            this.butref.ForeColor = System.Drawing.Color.Black;
            this.butref.Location = new System.Drawing.Point(560, 40);
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size(80, 24);
            this.butref.TabIndex = 11;
            this.butref.Text = "刷新(&R)";
            this.butref.Click += new System.EventHandler(this.butref_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.lbldw);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbllsj);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.lblpfj);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.lblhh);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblypmc);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lblcj);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblgg);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtdm);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.butprint);
            this.groupBox2.Controls.Add(this.butquit);
            this.groupBox2.Controls.Add(this.butref);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(0, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1131, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "药品信息";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdodf);
            this.groupBox4.Controls.Add(this.rdojf);
            this.groupBox4.Controls.Add(this.rdoall);
            this.groupBox4.Location = new System.Drawing.Point(814, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(279, 43);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            // 
            // rdodf
            // 
            this.rdodf.AutoSize = true;
            this.rdodf.Location = new System.Drawing.Point(148, 17);
            this.rdodf.Name = "rdodf";
            this.rdodf.Size = new System.Drawing.Size(83, 16);
            this.rdodf.TabIndex = 46;
            this.rdodf.Text = "仅查看贷方";
            this.rdodf.UseVisualStyleBackColor = true;
            this.rdodf.CheckedChanged += new System.EventHandler(this.rdoall_CheckedChanged);
            // 
            // rdojf
            // 
            this.rdojf.AutoSize = true;
            this.rdojf.Location = new System.Drawing.Point(62, 17);
            this.rdojf.Name = "rdojf";
            this.rdojf.Size = new System.Drawing.Size(83, 16);
            this.rdojf.TabIndex = 45;
            this.rdojf.Text = "仅查看借方";
            this.rdojf.UseVisualStyleBackColor = true;
            this.rdojf.CheckedChanged += new System.EventHandler(this.rdoall_CheckedChanged);
            // 
            // rdoall
            // 
            this.rdoall.AutoSize = true;
            this.rdoall.Checked = true;
            this.rdoall.Location = new System.Drawing.Point(12, 16);
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size(47, 16);
            this.rdoall.TabIndex = 44;
            this.rdoall.TabStop = true;
            this.rdoall.Text = "全部";
            this.rdoall.UseVisualStyleBackColor = true;
            this.rdoall.CheckedChanged += new System.EventHandler(this.rdoall_CheckedChanged);
            // 
            // lbldw
            // 
            this.lbldw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldw.ForeColor = System.Drawing.Color.Navy;
            this.lbldw.Location = new System.Drawing.Point(192, 40);
            this.lbldw.Name = "lbldw";
            this.lbldw.Size = new System.Drawing.Size(64, 20);
            this.lbldw.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(158, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "单位";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(456, 40);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(96, 20);
            this.lbllsj.TabIndex = 41;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(416, 43);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 16);
            this.label23.TabIndex = 40;
            this.label23.Text = "零售价";
            // 
            // lblpfj
            // 
            this.lblpfj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpfj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfj.ForeColor = System.Drawing.Color.Navy;
            this.lblpfj.Location = new System.Drawing.Point(312, 40);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.Size = new System.Drawing.Size(96, 20);
            this.lblpfj.TabIndex = 39;
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(264, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 38;
            this.label20.Text = "批发价";
            // 
            // lblhh
            // 
            this.lblhh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblhh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblhh.ForeColor = System.Drawing.Color.Navy;
            this.lblhh.Location = new System.Drawing.Point(736, 16);
            this.lblhh.Name = "lblhh";
            this.lblhh.Size = new System.Drawing.Size(72, 20);
            this.lblhh.TabIndex = 37;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(704, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 16);
            this.label18.TabIndex = 36;
            this.label18.Text = "货号";
            // 
            // lblypmc
            // 
            this.lblypmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblypmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblypmc.ForeColor = System.Drawing.Color.Navy;
            this.lblypmc.Location = new System.Drawing.Point(192, 16);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(216, 20);
            this.lblypmc.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(136, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 16);
            this.label16.TabIndex = 34;
            this.label16.Text = "药品名称";
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(600, 16);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(104, 20);
            this.lblcj.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(568, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 16);
            this.label14.TabIndex = 32;
            this.label14.Text = "厂家";
            // 
            // lblgg
            // 
            this.lblgg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblgg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgg.ForeColor = System.Drawing.Color.Navy;
            this.lblgg.Location = new System.Drawing.Point(456, 16);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(96, 20);
            this.lblgg.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(416, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 16);
            this.label12.TabIndex = 30;
            this.label12.Text = "规格";
            // 
            // txtdm
            // 
            this.txtdm.Location = new System.Drawing.Point(56, 15);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(72, 21);
            this.txtdm.TabIndex = 0;
            this.txtdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(20, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "代码";
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.ForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.RowHeaderWidth = 18;
            this.myDataGrid1.Size = new System.Drawing.Size(1125, 335);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid1_DoubleClick);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.col_批次号,
            this.col_批号,
            this.col_效期,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn16});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeaderWidth = 18;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 25;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "日期";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 80;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "摘要";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 200;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "单位";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 35;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "零售价";
            this.dataGridTextBoxColumn10.NullText = "0";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 65;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "借方数量";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 70;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "借方金额";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "贷方数量";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 70;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "贷方金额";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "结存数量";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 70;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "结存金额";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 75;
            // 
            // col_批次号
            // 
            this.col_批次号.Format = "";
            this.col_批次号.FormatInfo = null;
            this.col_批次号.HeaderText = "批次号";
            // 
            // col_批号
            // 
            this.col_批号.Format = "";
            this.col_批号.FormatInfo = null;
            this.col_批号.HeaderText = "批号";
            this.col_批号.Width = 60;
            // 
            // col_效期
            // 
            this.col_效期.Format = "";
            this.col_效期.FormatInfo = null;
            this.col_效期.HeaderText = "效期";
            this.col_效期.NullText = "";
            this.col_效期.Width = 80;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "进价";
            this.dataGridTextBoxColumn13.Width = 60;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "扣率";
            this.dataGridTextBoxColumn14.Width = 50;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "送货单号";
            this.dataGridTextBoxColumn15.Width = 70;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "单据日期";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.ReadOnly = true;
            this.dataGridTextBoxColumn17.Width = 85;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "DJID";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.Width = 0;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 493);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4,
            this.statusBarPanel5});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1131, 24);
            this.statusBar1.TabIndex = 3;
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
            this.statusBarPanel4.Width = 150;
            // 
            // statusBarPanel5
            // 
            this.statusBarPanel5.Name = "statusBarPanel5";
            this.statusBarPanel5.Width = 1000;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.myDataGrid1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox3.Location = new System.Drawing.Point(0, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1131, 355);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "明细账";
            // 
            // Frmypmxz
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1131, 517);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmypmxz";
            this.Text = "明细明细分类帐";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmypmxz_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		//初始药品
		private void csyp(int ggid,int cjid)
		{
            Ypgg ydgg = new Ypgg(ggid, InstanceForm.BDatabase);
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
			this.lblypmc.Tag=ydcj.CJID.ToString();
			this.lblypmc.Text=ydgg.YPSPM;
			this.lblgg.Text=ydgg.YPGG;
            this.lblcj.Text = Yp.SeekSccj(ydcj.SCCJ, InstanceForm.BDatabase);
			this.lblhh.Text=ydcj.SHH;
            this.lbldw.Text = Yp.SeekYpdw(ydgg.YPDW, InstanceForm.BDatabase);
			this.lblpfj.Text=ydcj.PFJ.ToString();
			this.lbllsj.Text=ydcj.LSJ.ToString() ;
			this.lblpfj.Tag=ydcj.PFJ.ToString();
			this.lbllsj.Tag=ydcj.LSJ.ToString() ;

		}

		//输入框控制事件
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" )
			{
				control.Text="";
				control.Tag="0";
			}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)=="")))
			{
				
			}
			else
			{
				return;
			}

			string[] GrdMappingName;
			int[] GrdWidth;
			string[]sfield;
			string ssql="";
			DataRow row;

            int deptid = Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue,"0"));
            int deptid_ck = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));


			Point point=new Point(this.Location.X+control.Location.X,this.Location.Y+control.Location.Y+control.Height*3 );
            switch (control.TabIndex)
            {

                case 0:
                    if (control.Text.Trim() == "")
                        return;  



                    GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "商品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                    GrdWidth = new int[] { 0, 0, 50, 160, 160, 100, 100, 40, 0, 60, 60, 70 };
                    sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };
                    ssql = "select distinct a.ggid,cjid,0 rowno,yppm,ypspm,ypgg,s_sccj sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_yp_ypcd a,yp_ypbm b where a.ggid=b.ggid and cjid in(select cjid from vi_yk_kcmx where bdelete_kc=0 and (deptid=" + deptid_ck + " or deptid in(select deptid from yp_yjks_gx where p_deptid=" + deptid + "))  )  ";
                    
                    TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, Constant.CustomFilterType, control.Text.Trim(), ssql, InstanceForm.BDatabase);
                    f2.Location = point;
                    f2.Width = 700;
                    f2.Height = 300;
                    f2.ShowDialog(this);
                    row = f2.dataRow;
                    if (row != null)
                    {
                        this.csyp(Convert.ToInt32(row["ggid"]), Convert.ToInt32(row["cjid"]));
                        this.butref_Click(sender, e);
                        this.txtdm.Text = "";
                        this.txtdm.Focus();

                    }
                    break;

            }
		}

		private void Frmypmxz_Load(object sender, System.EventArgs e)
		{
			//初始化
			FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");

			

			this.dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			this.dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

			this.rdomonth.Checked=true;

            Yp.AddCmbYjks(false, InstanceForm.BCurrentDept.DeptId, cmbyjks, InstanceForm.BDatabase);

           

		}

		


		private void butref_Click(object sender, System.EventArgs e)
		{
			try
			{
				int cjid=Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag,"0"));
				if (cjid==0) return;

				ParameterEx[] parameters;
				DataTable tb;
				if (this.rdomonth.Checked==true)
				{
					parameters=new ParameterEx[6];
					parameters[0].Value=Convert.ToInt32(cmbyear.Text);
					parameters[1].Value=Convert.ToInt32(cmbmonth.Text);
					parameters[2].Value=Convert.ToInt32(Convertor.IsNull(lblypmc.Tag,"0"));
					parameters[3].Value=Convert.ToInt32(cmbyjks.SelectedValue);
					parameters[4].Value=Convert.ToInt32(this.checkBox1.Checked);
                    parameters[5].Value = Convert.ToInt32(cmbck.SelectedValue);

					parameters[0].Text ="@year";
					parameters[1].Text="@month";
					parameters[2].Text="@cjid";
					parameters[3].Text="@deptid";
					parameters[4].Text="@cfmx";
                    parameters[5].Text = "@deptid_ck";
					//tb=InstanceForm.BDatabase.GetDataTable("SP_YK_YPMXZ",parameters,30);
                    dset = new DataSet();
                    InstanceForm.BDatabase.AdapterFillDataSet("SP_YK_YPMXZ", parameters, dset, "dtset", 30);
				}
				else
				{
					parameters=new ParameterEx[6];
					parameters[0].Value=dtp1.Value.ToShortDateString();
					parameters[1].Value=dtp2.Value.ToShortDateString();
					parameters[2].Value=Convert.ToInt32(Convertor.IsNull(lblypmc.Tag,"0"));
					parameters[3].Value=Convert.ToInt32(cmbyjks.SelectedValue);
					parameters[4].Value=Convert.ToInt32(this.checkBox1.Checked);
                    parameters[5].Value = Convert.ToInt32(cmbck.SelectedValue);
					parameters[0].Text ="@rq1";
					parameters[1].Text="@rq2";
					parameters[2].Text="@cjid";
					parameters[3].Text="@deptid";
					parameters[4].Text="@cfmx";
                    parameters[5].Text = "@deptid_ck";
					//tb=InstanceForm.BDatabase.GetDataTable("SP_YK_YPMXZ_RQ",parameters,30);
                    dset = new DataSet();
                    InstanceForm.BDatabase.AdapterFillDataSet("SP_YK_YPMXZ_RQ", parameters, dset, "dtset", 30);
				}

                tb = dset.Tables[0];
                
				tb.Rows[0]["日期"]=System.DBNull.Value;
				tb.Rows[tb.Rows.Count-1]["日期"]=System.DBNull.Value;


			    //  tb.TableName="Tb";

                DataTable tbmx = new DataTable();
                if (rdoall.Checked == true)
                    tbmx = dset.Tables[0].Copy();
                if (rdojf.Checked == true)
                    tbmx = dset.Tables[1].Copy();
                if (rdodf.Checked == true)
                    tbmx = dset.Tables[2].Copy();
                tbmx.TableName = "Tb";
                this.myDataGrid1.DataSource =tbmx;
                FunBase.myGridSelect(this.myDataGrid1, this.myDataGrid1.TableStyles[0].GridColumnStyles);

				decimal sqjc=0;decimal bqjc=0;decimal jfje=0;decimal dfje=0;
				if (tb.Rows.Count!=0)
				{
					sqjc=Convert.ToDecimal(Convertor.IsNull(tb.Rows[0]["结存金额"],"0"));
					bqjc=Convert.ToDecimal(Convertor.IsNull(tb.Rows[tb.Rows.Count-1]["结存金额"],"0"));
				}
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					jfje=jfje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["借方金额"],"0"));
					dfje=dfje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["贷方金额"],"0"));
				}

				this.statusBar1.Panels[0].Text="上期结存: "+sqjc.ToString("0.00");
				this.statusBar1.Panels[1].Text="借方金额: "+jfje.ToString("0.00");
				this.statusBar1.Panels[2].Text="贷方金额: "+dfje.ToString("0.00");
				this.statusBar1.Panels[3].Text="本期结存: "+bqjc.ToString("0.00");

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString());
			}
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string sumje=this.statusBar1.Panels[0].Text.Trim()+"      "+this.statusBar1.Panels[1].Text.Trim()+"      "+this.statusBar1.Panels[2].Text.Trim()+"      "+this.statusBar1.Panels[3].Text.Trim();

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset1 Dset=new ts_Yk_ReportView.Dataset1();
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.保管明细帐.NewRow();
					myrow["xh"]=Convert.ToInt32(tb.Rows[i]["序号"]);
					myrow["rq"]=Convert.ToString(tb.Rows[i]["日期"]);
					myrow["zy"]=Convert.ToString(tb.Rows[i]["摘要"]);
					myrow["ypdw"]=Convert.ToString(tb.Rows[i]["单位"]);
					myrow["lsj"]=Convert.ToString(tb.Rows[i]["零售价"]);
					myrow["jfsl"]=Convert.ToString(tb.Rows[i]["借方数量"]);
					myrow["jfje"]=Convert.ToString(tb.Rows[i]["借方金额"]);
					myrow["dfsl"]=Convert.ToString(tb.Rows[i]["贷方数量"]);
					myrow["dfje"]=Convert.ToString(tb.Rows[i]["贷方金额"]);
					myrow["jysl"]=Convert.ToString(tb.Rows[i]["结存数量"]);
					myrow["jyje"]=Convert.ToString(tb.Rows[i]["结存金额"]);
                    myrow["ypph"] = Convert.ToString(tb.Rows[i]["批号"]);
                    myrow["ypxq"] = Convert.ToString(tb.Rows[i]["效期"]);
                    myrow["shdh"] = Convert.ToString(tb.Rows[i]["送货单号"]);
                    myrow["jhj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"));
					Dset.保管明细帐.Rows.Add(myrow);
				}

				ParameterEx[] parameters=new ParameterEx[11];
				parameters[0].Text="nf";
				parameters[0].Value=cmbyear.Text.Trim()+"年";
				parameters[1].Text="yf";
				parameters[1].Value=cmbmonth.Text.Trim()+"月";
				parameters[2].Text="kjqj";
				parameters[2].Value=this.statusBarPanel5.Text;
				parameters[3].Text="ypspm";
				parameters[3].Value=lblypmc.Text.Trim();
				parameters[4].Text="ypgg";
				parameters[4].Value=lblgg.Text.Trim();
				parameters[5].Text="sccj";
				parameters[5].Value=lblcj.Text.Trim();
				parameters[6].Text="pfj";
				parameters[6].Value=lblpfj.Text.Trim();
				parameters[7].Text="lsj";
				parameters[7].Value=lbllsj.Text.Trim();
				parameters[8].Text="shh";
				parameters[8].Value=lblhh.Text.Trim();
				parameters[9].Text="sumje";
				parameters[9].Value=sumje.Trim();
				parameters[10].Text="TITLETEXT";
				parameters[10].Value=TrasenFrame.Classes.Constant.HospitalName+"("+cmbyjks.Text.Trim()+")"+this.Text;

				
				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.保管明细帐,Constant.ApplicationDirectory+"\\Report\\YK_保管明细帐.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void cmbyear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            Yp.AddcmbMonth(Convert.ToInt32(cmbyjks.SelectedValue), Convert.ToInt32(this.cmbyear.Text), cmbyear, cmbmonth, InstanceForm.BDatabase);
		}

		private void cmbmonth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int nyear=Convert.ToInt32(Convertor.IsNull(cmbyear.Text,"0"));
			int nmonth=Convert.ToInt32(Convertor.IsNull(cmbmonth.Text,"0"));
            this.statusBarPanel5.Text = Yp.Seekkjqj(nyear, nmonth, Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
		}

		private void rdorq_Click(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();
		}

		private void rdorq_CheckedChanged(object sender, System.EventArgs e)
		{
			this.cmbyear.Enabled=this.rdomonth.Checked==true?true:false;
			this.cmbmonth.Enabled=this.rdomonth.Checked==true?true:false;
			this.dtp1.Enabled=this.rdorq.Checked==true?true:false;
			this.dtp2.Enabled=this.rdorq.Checked==true?true:false;
		}

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);
        }

        private void cmbyjks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);
            Yp.AddCmbYjks_ck(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbck, InstanceForm.BDatabase);
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

        private void myDataGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)myDataGrid1.DataSource;
                int nrow=myDataGrid1.CurrentCell.RowNumber;
                if (nrow>=tb.Rows.Count-1) return;

                string djid = Convertor.IsNull(tb.Rows[nrow]["djid"].ToString(), Guid.Empty.ToString());
                int cjid =Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["cjid"].ToString(), "0"));

                string ssql = "select ywlx,deptid,djh,djh 单据号 from vi_yk_dj where id='"+djid+"'";
                DataTable tbdj = InstanceForm.BDatabase.GetDataTable(ssql);
                string ywlx = "";
                if (tbdj.Rows.Count > 0) ywlx = tbdj.Rows[0]["ywlx"].ToString();
                if (ywlx == "") return;
                MenuTag _menutag = new MenuTag();
                Department BCurrentDept = new Department(Convert.ToInt32(tbdj.Rows[0]["deptid"]), InstanceForm.BDatabase);
                

                //ssql = "select * from pub_menu a,yk_ywlx b where a.function_tag=b.ywlx and (function_name='Fun_ts_yp_tj_cx' or function_name='Fun_ts_yp_pd_cx' or (dll_name like '%_yk_%' and function_name like '%_cx%' )) and ywlx='" + ywlx + "'";
                //DataTable tbyw = InstanceForm.BDatabase.GetDataTable(ssql);
                //if (tbyw.Rows.Count == 0) return;
                //string dllname = tbyw.Rows[0]["dll_name"].ToString().Trim();
                //string funname = tbyw.Rows[0]["function_name"].ToString().Trim();
                //string funtag = ywlx.Trim();
                //string menuname = tbyw.Rows[0]["name"].ToString().Trim();
                //int jgbm = Convert.ToInt32(tbyw.Rows[0]["jgbm"]) > 0 ? Convert.ToInt32(tbyw.Rows[0]["jgbm"]) : InstanceForm._menuTag.Jgbm;

                string dllname = "";
                string funname = "";
                string funtag = ywlx.Trim();
                string menuname ="单据明细查询";
                int jgbm =  InstanceForm._menuTag.Jgbm;
                switch (ywlx)
                {
                    case "001":
                        dllname = "ts_yk_cgrk";
                        funname = "Fun_ts_yk_cgrk_cx";
                        break;
                    case "002":
                        dllname = "ts_yk_cgrk";
                        funname = "Fun_ts_yk_cgrk_th_cx";
                        break;
                    case "003":
                    case "014":
                    case "017":
                    case "018":
                    case "020":
                    case "022":
                    case "030":
                        dllname = "ts_yk_ck";
                        if (ywlx == "003") funname = "Fun_ts_yk_ypck_cx";
                        if (ywlx == "014") funname = "Fun_ts_yk_ypck_qtly_cx";
                        if (ywlx == "018") funname = "Fun_ts_yk_ypck_cfbl_cx";
                        if (ywlx == "020") funname = "Fun_ts_yk_ypck_jzcfck_cx";
                        if (ywlx == "022") funname = "Fun_ts_yk_ypck_wyylyd_cx";
                        if (ywlx == "030") funname = "Fun_ts_yk_ypck_dck_cx";
                        break;
                    case "004":
                    case "009":
                    case "016":
                    case "031":
                        dllname = "ts_yk_ptrk";
                        if (ywlx == "004") funname = "Fun_ts_yk_ypptrk_tk_cx";
                        if (ywlx == "009") funname = "Fun_ts_yk_ypptrk_qc_cx";
                        if (ywlx == "016") funname = "Fun_ts_yk_ypptrk_qtrk_cx";
                        if (ywlx == "031") funname = "Fun_ts_yk_ypptrk_drk_cx";
                        break;
                    case "005":
                        dllname = "ts_yp_tj";
                        funname = "Fun_ts_yp_tj_cx";
                        break;
                    case "008":
                        dllname = "ts_yp_pd";
                        funname = "Fun_ts_yp_pd_cx";
                        break;
                    case "006":
                    case "007":
                        dllname = "ts_yk_bsby";
                        if (ywlx == "006") funname = "Fun_ts_yk_ypbs_cx";
                        if (ywlx == "007") funname = "Fun_ts_yk_ypby_cx";
                        break;
                    default:
                        break;
                }

                switch (ywlx)
                {
                    case "005":
                        ssql = "select * from yf_tj where deptid="+tbdj.Rows[0]["deptid"].ToString()+" and djh="+tbdj.Rows[0]["djh"].ToString()+"";
                        DataTable tbtj = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tbtj.Rows.Count == 0) return;
                        _menutag.DllName = dllname;
                        _menutag.Function_Name = funname;
                        _menutag.FunctionTag = funtag;
                        _menutag.Jgbm = jgbm;
                        object[] comValue1 = new object[5];
                        comValue1[0] = _menutag;
                        comValue1[1] = menuname ;
                        comValue1[2] = tbtj.Rows[0]["id"].ToString();
                        comValue1[3] = tbdj;
                        comValue1[4] = cjid;
                        Form f1 = ShowDllForm(dllname, funname, menuname, ref comValue1, false, BCurrentDept,InstanceForm.BCurrentUser);
                        //f1.ShowDialog();
                        break;
                    case "008":
                        ssql = "select * from yf_pd where deptid=" + tbdj.Rows[0]["deptid"].ToString() + " and djh=" + tbdj.Rows[0]["djh"].ToString() + "";
                        DataTable tbpd = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tbpd.Rows.Count == 0) return;
                        _menutag.DllName = dllname;
                        _menutag.Function_Name = funname;
                        _menutag.FunctionTag = funtag;
                        _menutag.Jgbm = jgbm;
                        object[] comValue2 = new object[5];
                        comValue2[0] = _menutag;
                        comValue2[1] = menuname;
                        comValue2[2] = tbpd.Rows[0]["id"].ToString();
                        comValue2[3] = tbdj;
                        comValue2[4] = cjid;
                        Form f2 = ShowDllForm(dllname, funname, menuname, ref comValue2, false, BCurrentDept, InstanceForm.BCurrentUser);
                        //f2.ShowDialog();
                        break;
                    default:
                        _menutag.DllName = dllname;
                        _menutag.Function_Name = funname;
                        _menutag.FunctionTag = funtag;
                        _menutag.Jgbm = jgbm;
                        object[] comValue3 = new object[5];
                        comValue3[0] = _menutag;
                        comValue3[1] = menuname;
                        comValue3[2] = djid;
                        comValue3[3] = tbdj;
                        comValue3[4] = cjid;
                        Form f3 = ShowDllForm(dllname, funname, menuname, ref comValue3, false, BCurrentDept, InstanceForm.BCurrentUser);
                        //f3.ShowDialog();
                        break;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        private Form ShowDllForm(string dllName, string functionName, string chineseName, ref object[] communicateValue, bool showModule,Department _department,User _user)
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

        private void rdoall_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (dset != null)
                {
                    DataTable tbmx = new DataTable();
                    if (rdoall.Checked == true)
                        tbmx = dset.Tables[0].Copy();
                    if (rdojf.Checked == true)
                        tbmx = dset.Tables[1].Copy();
                    if (rdodf.Checked == true)
                        tbmx = dset.Tables[2].Copy();
                    tbmx.TableName = "Tb";
                    this.myDataGrid1.DataSource = tbmx;
                    FunBase.myGridSelect(this.myDataGrid1, this.myDataGrid1.TableStyles[0].GridColumnStyles);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void myDataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            this.myDataGrid1.Select(this.myDataGrid1.CurrentCell.RowNumber);
        }

        private void cmbck_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
            bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);
            if (bpcgl)
            {
                col_批次号.Width = 100;
                col_批号.Width = 65;
                col_效期.Width = 80;
            }
            else
            {
                col_批次号.Width = 0;
                col_批号.Width = 0;
                col_效期.Width = 0;
            }
        }



	}
}
