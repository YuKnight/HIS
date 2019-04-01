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


namespace ts_yp_ypqlrk
{
	/// <summary>
	/// Frmyprk 的摘要说明。
	/// </summary>
	public class Frmypqlrk : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtbz;
		private System.Windows.Forms.Label lbldjh;
		private System.Windows.Forms.Label lbldjhddd;
		private System.Windows.Forms.TextBox txtghdw;
		private System.Windows.Forms.Label lbllsje;
		private System.Windows.Forms.Label lblpfje;
		private System.Windows.Forms.TextBox txtypsl;
		private System.Windows.Forms.Label lbllsj;
		private System.Windows.Forms.Label lblpfj;
		private System.Windows.Forms.ComboBox cmbdw;
		private System.Windows.Forms.Label lblhh;
		private System.Windows.Forms.Label lblypmc;
		private System.Windows.Forms.Label lblcj;
		private System.Windows.Forms.Label lblgg;
		private System.Windows.Forms.TextBox txtypdm;
		private System.Windows.Forms.Button butmodif;
		private System.Windows.Forms.Button butdel;
		private System.Windows.Forms.Button butadd;
		private System.Windows.Forms.Button butclose;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.Button butnew;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.Label lblkc;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private YpConfig s;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.Label lblpm;
		private System.Windows.Forms.DataGridTextBoxColumn 商品名;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmypqlrk(MenuTag menuTag,string chineseName,Form mdiParent)
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
            s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
			if (s.网络内容显示商品名==true)
				this.商品名.Width=120;
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
            this.txtbz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldjh = new System.Windows.Forms.Label();
            this.lbldjhddd = new System.Windows.Forms.Label();
            this.txtghdw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblpm = new System.Windows.Forms.Label();
            this.lbllsje = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblpfje = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butmodif = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butadd = new System.Windows.Forms.Button();
            this.lblkc = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtypsl = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lbllsj = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblpfj = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbdw = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblhh = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblypmc = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblcj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblgg = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtypdm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butclose = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbz);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbldjh);
            this.groupBox1.Controls.Add(this.lbldjhddd);
            this.groupBox1.Controls.Add(this.txtghdw);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 40);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtbz
            // 
            this.txtbz.ForeColor = System.Drawing.Color.Navy;
            this.txtbz.Location = new System.Drawing.Point(296, 11);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(320, 21);
            this.txtbz.TabIndex = 3;
            this.txtbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(264, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "备注";
            // 
            // lbldjh
            // 
            this.lbldjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldjh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldjh.ForeColor = System.Drawing.Color.Navy;
            this.lbldjh.Location = new System.Drawing.Point(678, 12);
            this.lbldjh.Name = "lbldjh";
            this.lbldjh.Size = new System.Drawing.Size(97, 20);
            this.lbldjh.TabIndex = 15;
            // 
            // lbldjhddd
            // 
            this.lbldjhddd.Location = new System.Drawing.Point(622, 16);
            this.lbldjhddd.Name = "lbldjhddd";
            this.lbldjhddd.Size = new System.Drawing.Size(64, 16);
            this.lbldjhddd.TabIndex = 14;
            this.lbldjhddd.Text = "入库单号";
            // 
            // txtghdw
            // 
            this.txtghdw.ForeColor = System.Drawing.Color.Navy;
            this.txtghdw.Location = new System.Drawing.Point(66, 11);
            this.txtghdw.Name = "txtghdw";
            this.txtghdw.Size = new System.Drawing.Size(192, 21);
            this.txtghdw.TabIndex = 1;
            this.txtghdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtghdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = " 目的科室";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblpm);
            this.groupBox2.Controls.Add(this.lbllsje);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblpfje);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.butmodif);
            this.groupBox2.Controls.Add(this.butdel);
            this.groupBox2.Controls.Add(this.butadd);
            this.groupBox2.Controls.Add(this.lblkc);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.txtypsl);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.lbllsj);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.lblpfj);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cmbdw);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.lblhh);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblypmc);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lblcj);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblgg);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtypdm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 96);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lblpm
            // 
            this.lblpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpm.ForeColor = System.Drawing.Color.Navy;
            this.lblpm.Location = new System.Drawing.Point(232, 16);
            this.lblpm.Name = "lblpm";
            this.lblpm.Size = new System.Drawing.Size(168, 20);
            this.lblpm.TabIndex = 72;
            // 
            // lbllsje
            // 
            this.lbllsje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsje.ForeColor = System.Drawing.Color.Navy;
            this.lbllsje.Location = new System.Drawing.Point(381, 65);
            this.lbllsje.Name = "lbllsje";
            this.lbllsje.Size = new System.Drawing.Size(85, 20);
            this.lbllsje.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(325, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "零售金额";
            // 
            // lblpfje
            // 
            this.lblpfje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpfje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfje.ForeColor = System.Drawing.Color.Navy;
            this.lblpfje.Location = new System.Drawing.Point(232, 65);
            this.lblpfje.Name = "lblpfje";
            this.lblpfje.Size = new System.Drawing.Size(90, 20);
            this.lblpfje.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(176, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 68;
            this.label7.Text = "批发金额";
            // 
            // butmodif
            // 
            this.butmodif.Location = new System.Drawing.Point(709, 64);
            this.butmodif.Name = "butmodif";
            this.butmodif.Size = new System.Drawing.Size(64, 24);
            this.butmodif.TabIndex = 12;
            this.butmodif.Text = "修改(&M)";
            this.butmodif.Click += new System.EventHandler(this.butmodif_Click);
            // 
            // butdel
            // 
            this.butdel.Location = new System.Drawing.Point(639, 64);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(64, 24);
            this.butdel.TabIndex = 11;
            this.butdel.Text = "删除(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butadd
            // 
            this.butadd.Location = new System.Drawing.Point(567, 64);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(64, 24);
            this.butadd.TabIndex = 10;
            this.butadd.Text = "添加(&A)";
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            this.butadd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblkc
            // 
            this.lblkc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkc.ForeColor = System.Drawing.Color.Navy;
            this.lblkc.Location = new System.Drawing.Point(552, 40);
            this.lblkc.Name = "lblkc";
            this.lblkc.Size = new System.Drawing.Size(92, 20);
            this.lblkc.TabIndex = 51;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(470, 41);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(90, 16);
            this.label36.TabIndex = 50;
            this.label36.Text = "库存量(库/房)";
            // 
            // txtypsl
            // 
            this.txtypsl.ForeColor = System.Drawing.Color.Navy;
            this.txtypsl.Location = new System.Drawing.Point(64, 40);
            this.txtypsl.Name = "txtypsl";
            this.txtypsl.Size = new System.Drawing.Size(96, 21);
            this.txtypsl.TabIndex = 5;
            this.txtypsl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtypsl_KeyUp);
            this.txtypsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(33, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 16);
            this.label26.TabIndex = 32;
            this.label26.Text = "数量";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(381, 40);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(85, 20);
            this.lbllsj.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(337, 40);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 16);
            this.label23.TabIndex = 28;
            this.label23.Text = "零售价";
            // 
            // lblpfj
            // 
            this.lblpfj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpfj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfj.ForeColor = System.Drawing.Color.Navy;
            this.lblpfj.Location = new System.Drawing.Point(232, 40);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.Size = new System.Drawing.Size(90, 20);
            this.lblpfj.TabIndex = 27;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(184, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 26;
            this.label20.Text = "批发价";
            // 
            // cmbdw
            // 
            this.cmbdw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdw.ForeColor = System.Drawing.Color.Navy;
            this.cmbdw.Location = new System.Drawing.Point(64, 64);
            this.cmbdw.Name = "cmbdw";
            this.cmbdw.Size = new System.Drawing.Size(96, 20);
            this.cmbdw.TabIndex = 66;
            this.cmbdw.SelectedIndexChanged += new System.EventHandler(this.cmbdw_SelectedIndexChanged);
            this.cmbdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(32, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 16);
            this.label19.TabIndex = 24;
            this.label19.Text = "单位";
            // 
            // lblhh
            // 
            this.lblhh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblhh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblhh.ForeColor = System.Drawing.Color.Navy;
            this.lblhh.Location = new System.Drawing.Point(680, 40);
            this.lblhh.Name = "lblhh";
            this.lblhh.Size = new System.Drawing.Size(96, 20);
            this.lblhh.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(648, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 16);
            this.label18.TabIndex = 22;
            this.label18.Text = "货号";
            // 
            // lblypmc
            // 
            this.lblypmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblypmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblypmc.ForeColor = System.Drawing.Color.Navy;
            this.lblypmc.Location = new System.Drawing.Point(400, 16);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(128, 20);
            this.lblypmc.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(161, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 16);
            this.label16.TabIndex = 20;
            this.label16.Text = "品名/商品名";
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(688, 15);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(87, 20);
            this.lblcj.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(656, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 16);
            this.label14.TabIndex = 18;
            this.label14.Text = "厂家";
            // 
            // lblgg
            // 
            this.lblgg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblgg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgg.ForeColor = System.Drawing.Color.Navy;
            this.lblgg.Location = new System.Drawing.Point(560, 15);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(84, 20);
            this.lblgg.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(528, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 16);
            this.label12.TabIndex = 16;
            this.label12.Text = "规格";
            // 
            // txtypdm
            // 
            this.txtypdm.ForeColor = System.Drawing.Color.Navy;
            this.txtypdm.Location = new System.Drawing.Point(64, 15);
            this.txtypdm.Name = "txtypdm";
            this.txtypdm.Size = new System.Drawing.Size(96, 21);
            this.txtypdm.TabIndex = 4;
            this.txtypdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtypdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "药品代码";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(784, 413);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 329);
            this.panel2.TabIndex = 62;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.ForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.HeaderForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(778, 329);
            this.myDataGrid1.TabIndex = 60;
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
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn5});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
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
            this.dataGridTextBoxColumn2.HeaderText = "品名";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // 商品名
            // 
            this.商品名.Format = "";
            this.商品名.FormatInfo = null;
            this.商品名.HeaderText = "商品名";
            this.商品名.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "厂家";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "批发价";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "零售价";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 60;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "数量";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 50;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "单位";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 40;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "批发金额";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 60;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "零售金额";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 60;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "货号";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 60;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "CJID";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "DWBL";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 0;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "id";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butnew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 346);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 64);
            this.panel1.TabIndex = 61;
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(632, 8);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 59;
            this.butclose.Text = "关闭(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butprint
            // 
            this.butprint.Enabled = false;
            this.butprint.Location = new System.Drawing.Point(544, 8);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 24);
            this.butprint.TabIndex = 58;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(456, 8);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(88, 24);
            this.butsave.TabIndex = 57;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(368, 8);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(88, 24);
            this.butnew.TabIndex = 56;
            this.butnew.Text = "新单号(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 525);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(784, 24);
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
            this.statusBarPanel4.Width = 400;
            // 
            // Frmypqlrk
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(784, 549);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "Frmypqlrk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "药品请领单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmypptrk_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Frmypptrk_Load(object sender, System.EventArgs e)
		{

			//初始化未发药处方列表
			FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");

		}



		#region 界面控制事件
		// 回车跳至下一个文本
		private void GotoNext(object sender, KeyPressEventArgs e)
		{ 
			Control control=(Control)sender;
			if (e.KeyChar==13 )
			{
				this.SelectNextControl(control,true,false,true,true);
			}
		}

	
		private void csgroupbox1()
		{
			for(int i=0;i<=this.groupBox1.Controls.Count-1;i++)
			{
				if (this.groupBox1.Controls[i].GetType().ToString()=="System.Windows.Forms.TextBox")
				{
					this.groupBox1.Controls[i].Text="";
					this.groupBox1.Controls[i].Tag="0";
					this.groupBox1.Controls[i].Enabled=true;
				}
			}
			this.lbldjh.Text="";
			this.groupBox1.Tag=null ;
		}


		private void csgroupbox2()
		{
			for(int i=0;i<=this.groupBox2.Controls.Count-1;i++)
			{
				if (this.groupBox2.Controls[i].GetType().ToString()=="System.Windows.Forms.TextBox")
				{
					this.groupBox2.Controls[i].Text="";
					this.groupBox2.Controls[i].Tag="0";
					this.groupBox2.Controls[i].Enabled=true;
				}
			}
			this.lblypmc.Text="";
			this.lblypmc.Tag="0";
			this.lblpm.Text="";
			this.lblgg.Text="";
			this.lblcj.Text="";
			this.lblhh.Text="";
			this.lblpfj.Text="";
			this.lbllsj.Text="";
			this.lblpfj.Tag="";
			this.lbllsj.Tag ="";
			this.lblpfje.Text="";
			this.lbllsje.Text="";
			this.lblkc.Text="";
			this.cmbdw.DataSource=null;
			this.cmbdw.Enabled=true;
			this.txtypdm.Focus();
		}

	
		//输入框控制事件
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" ){control.Text="";control.Tag="0";}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)==""))){}else{return;}

			try
			{
				string[] GrdMappingName;
				int[] GrdWidth;
				string[]sfield;
				string ssql="";
				DataRow row;
				
				Point point=new Point(this.Location.X+control.Location.X,this.Location.Y+control.Location.Y+control.Height*3 );
				switch(control.TabIndex)
				{
					case 1:
						if (control.Text.Trim()=="") return;
                        Yp.frmShowCard_funName(sender, ShowCardType.单据往来科室, _menuTag.Function_Name, point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
						if (Convertor.IsNull(control.Tag,"0")!="0") this.SelectNextControl((Control)sender,true,false,true,true);
						break;
					case 4:
						int wldw=Convert.ToInt32(Convertor.IsNull(txtghdw.Tag,"0"));
						if (wldw==0) 
						{
							MessageBox.Show("请先选择目的科室");
							return;
						}

//                        if (control.Text.Trim()=="") return;
//                        GrdMappingName=new string[] {"ggid","cjid","行号","品名","规格","厂家","库存量","单位","DWBL","批发价","零售价","货号"};
//                        GrdWidth=new int[] {0,0,50,200,100,100,60,40,0,60,60,70};
//                        sfield=new string[] {"wbm","pym","szm","ywm","ypbm"};
////						if (_menuTag.Function_Name.Trim()=="Fxc_yf_ypqlrk_xyg")
////							ssql="select a.ggid,cjid,0   rowno,ypspm,ypgg,dbo.fun_yp_sccj(sccj) sccj,kcl,dbo.fun_yp_ypdw(zxdw) ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b "+
////							 "where a.ggid=b.ggid and deptid="+wldw+" and bdelete_kc=0 and a.ypzlx in(select ypzlx from yp_gllx where deptid="+InstanceForm.BCurrentDept.DeptId+")  ";
////						else
						
//                        string tablename="";
//                        if (Yp.是否药库(wldw, InstanceForm.BDatabase) == true)
//                            tablename="vi_yk_kcmx";
//                        else
//                            tablename="vi_yf_kcmx";

//                        ssql="select a.ggid,cjid,0   rowno,ypspm,ypgg, s_sccj sccj,kcl,dbo.fun_yp_ypdw(zxdw) ypdw,1 dwbl,pfj,lsj,shh from "+tablename+" a,yp_ypbm b "+
//                                "where a.ggid=b.ggid and deptid="+wldw+" and bdelete_kc=0 and bdelete_cj=0";
						
//                        if (s.系统启用==true)
//                            ssql=ssql+" and a.ypzlx in(select ypzlx from yp_gllx where deptid="+InstanceForm.BCurrentDept.DeptId+")  ";

						
//                        TrasenFrame.Forms.Fshowcard f2=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,Constant.CustomFilterType,control.Text.Trim(),ssql);
//                        f2.Location=point;
//                        f2.Width=700;
//                        f2.Height=300;
//                        f2.ShowDialog(this);
//                        row=f2.dataRow;
//                        if (row!=null) 
//                        {
//                            this.csyp(Convert.ToInt32(row["ggid"]),Convert.ToInt32(row["cjid"]));
//                            this.SelectNextControl((Control)sender,true,false,true,true);
							
//                        }


                        if (control.Text.Trim() == "") return;

                        int szjgbm = 0;
                        DataTable tbyjks = Yp.SelectYjks(wldw, InstanceForm.BDatabase);
                        if (tbyjks.Rows.Count > 0)
                        {
                            szjgbm = Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]);
                        }
                        TrasenClasses.DatabaseAccess.RelationalDatabase db;
                        db = InstanceForm.BDatabase;
                        if (TrasenFrame.Forms.FrmMdiMain.Jgbm != szjgbm)
                            db = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(szjgbm);

                        Yp.frmShowCard(sender, ShowCardType.库存药品, _menuTag.Function_Name, 0, point, wldw, db);

                        if (Convertor.IsNull(control.Tag, "0") != "0")
                        {
                            Ypcj cj = new Ypcj(Convert.ToInt32(Convertor.IsNull(control.Tag, "0")), InstanceForm.BDatabase);
                            this.csyp(cj.GGID, cj.CJID);
                            this.SelectNextControl((Control)sender, true, false, true, true);
                        }
                        break;					

				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}


		//数量输入事件
		private void txtypsl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if (Convertor.IsNumeric(txtypsl.Text)==false) txtypsl.Text="";
				if (txtypsl.Text.Trim()!="-" && txtypsl.Text.Trim()!=".")
				{
					decimal sumpfje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text,"0"));
					this.lblpfje.Text=sumpfje.ToString("0.00");
					decimal sumlsje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text,"0"));
					this.lbllsje.Text=sumlsje.ToString("0.00");
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}

		
		//网格单元改变事件
		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				if (nrow>=tb.Rows.Count)
				{
					DataRow nullrow=tb.NewRow();
					this.Getrow(nullrow);
				}
				else{DataRow row=tb.Rows[nrow];Getrow(row);this.butadd.Enabled=false;}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
			
		}


		//单位改变事件
		private void cmbdw_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbdw.SelectedIndex<=-1) return;
				if (cmbdw.SelectedValue.GetType().ToString()!="System.Int32") return;
				int dwbl=Convert.ToInt32(cmbdw.SelectedValue);
                this.lblkc.Text = Yp.SeekKcZh(dwbl, Convert.ToInt32(this.lblypmc.Tag), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase).ToString("0.000");
		
				decimal ypsl=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"));
				decimal pfj=Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Tag,"0"))/dwbl;
				pfj=Convert.ToDecimal(pfj.ToString("0.0000"));
				this.lblpfj.Text=pfj.ToString("0.0000");
				decimal lsj=Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag,"0"))/dwbl;
				lsj=Convert.ToDecimal(lsj.ToString("0.0000"));
				this.lbllsj.Text=lsj.ToString("0.0000");
				decimal pfje=pfj*ypsl;
				this.lblpfje.Text=pfje.ToString("0.00");
				decimal lsje=lsj*ypsl;
				this.lbllsje.Text=lsje.ToString("0.00");
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		
		//窗体键盘事件

		
		#endregion

		#region 填充数据的过程
		//初始药品
		private void csyp(int ggid,int cjid)
		{
			try
			{
				this.csgroupbox2();
                Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
				this.lblypmc.Tag=ydcj.CJID.ToString();
				this.lblypmc.Text=ydcj.S_YPSPM;
				this.lblpm.Text=ydcj.S_YPPM;
				this.lblgg.Text=ydcj.S_YPGG;
				this.lblcj.Text=ydcj.S_SCCJ;
				this.lblhh.Text=ydcj.SHH;
				this.lblpfj.Text=ydcj.PFJ.ToString();
				this.lbllsj.Text=ydcj.LSJ.ToString() ;
				this.lblpfj.Tag=ydcj.PFJ.ToString();
				this.lbllsj.Tag=ydcj.LSJ.ToString() ;
                Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(txtghdw.Tag, "0")), ydcj.GGID, ydcj.CJID, this.cmbdw, InstanceForm.BDatabase);
				this.cmbdw.SelectedIndex=0;
				long wldw=Convert.ToInt32(Convertor.IsNull(txtghdw.Tag,"0"));

                decimal ykkc = Yp.SeekKcZh(Convert.ToInt32(this.cmbdw.SelectedValue), ydcj.CJID, wldw, InstanceForm.BDatabase);
                decimal yfkc = Yp.SeekKcZh(Convert.ToInt32(this.cmbdw.SelectedValue), ydcj.CJID, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

                this.lblkc.Text = Convert.ToDouble(ykkc).ToString() + "/" + Convert.ToDouble(yfkc).ToString();


			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}


		//填充行
		private void Fillrow(System.Data.DataRow row)
		{
			if (Convert.ToInt32(this.lblypmc.Tag)==0) 
			{
				MessageBox.Show("没有可添加的药品");
				return;
			}

			if (Convertor.IsNull(this.txtypsl.Text,"0")=="0")
			{
				MessageBox.Show("请输入药品数量");
				return;
			}

			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			row["序号"]=tb.Rows.Count+1;
			row["商品名"]=this.lblypmc.Text.Trim();
			row["品名"]=this.lblpm.Text.Trim();
			row["规格"]=this.lblgg.Text.Trim();
			row["厂家"]=this.lblcj.Text.Trim();
			row["批发价"]=this.lblpfj.Text.Trim();
			row["零售价"]=this.lbllsj.Text.Trim();
			row["数量"]=this.txtypsl.Text.Trim();
			row["单位"]=this.cmbdw.Text.Trim();
			decimal sumpfje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(),"0"));
			row["批发金额"]=sumpfje.ToString("0.00");
			decimal sumlsje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text.Trim(),"0"));
			row["零售金额"]=sumlsje.ToString("0.00");
			row["货号"]=this.lblhh.Text.Trim();
			row["CJID"]=this.lblypmc.Tag.ToString();
			row["DWBL"]=Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
		}

		
		//求和金额
		private void Sumje()
		{
			decimal sumpfje=0;
			decimal sumlsje=0;
			decimal sumplce=0;
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			for( int i=0;i<=tb.Rows.Count-1;i++)
			{
				sumpfje=sumpfje+Convert.ToDecimal(tb.Rows[i]["批发金额"]);
				sumlsje=sumlsje+Convert.ToDecimal(tb.Rows[i]["零售金额"]);
			}
			sumplce=sumlsje-sumpfje;
			this.statusBar1.Panels[0].Text ="批发金额: "+sumpfje.ToString("0.00");
			this.statusBar1.Panels[1].Text ="零售金额: "+sumlsje.ToString("0.00");
			this.statusBar1.Panels[2].Text ="批零差额: "+sumplce.ToString("0.00");
		}


		//获取一行
		private void Getrow(DataRow row)
		{
			int cjid=Convert.ToInt32(Convertor.IsNull(row["cjid"],"0"));
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
			this.lblypmc.Text=row["品名"].ToString();
			this.lblpm.Text=row["商品名"].ToString();
			this.lblypmc.Tag=row["CJID"].ToString();
			this.lblgg.Text=row["规格"].ToString();
			this.lblcj.Text=row["厂家"].ToString();
			this.lblpfj.Text=row["批发价"].ToString();
			this.lblpfj.Tag=ydcj.PFJ.ToString();
			this.lbllsj.Text=row["零售价"].ToString();
			this.lbllsj.Tag=ydcj.LSJ.ToString();
			this.txtypsl.Text=row["数量"].ToString();
            Yp.AddCmbDW(InstanceForm.BCurrentDept.DeptId, ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
			this.cmbdw.Text=row["单位"].ToString();
           // this.lblkc.Text = Yp.SeekKcZh(Convert.ToInt32(cmbdw.SelectedValue), ydcj.CJID, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase).ToString("0.000");
			this.lblpfje.Text=row["批发金额"].ToString();
			this.lbllsje.Text=row["零售金额"].ToString();
			this.lblhh.Text=row["货号"].ToString();

            decimal ykkc = Yp.SeekKcZh(Convert.ToInt32(this.cmbdw.SelectedValue), ydcj.CJID,Convert.ToInt32(Convertor.IsNull(txtghdw.Tag,"0")), InstanceForm.BDatabase);
            decimal yfkc = Yp.SeekKcZh(Convert.ToInt32(this.cmbdw.SelectedValue), ydcj.CJID, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

            this.lblkc.Text = Convert.ToDouble(ykkc).ToString() + "/" + Convert.ToDouble(yfkc).ToString();

			
		}


		//重新排序行号
		private void SortRowNO()
		{
			DataTable tb1=(DataTable)this.myDataGrid1.DataSource;
			for(int i=0;i<=tb1.Rows.Count-1;i++)
			{
				tb1.Rows[i]["序号"]=i+1;
			}
		}


		//填充单据
		public void FillDj(Guid id,bool shbz)
		{
			string ssql="select * from yf_RKSQ where id='"+id+"'";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			this.groupBox1.Tag=tb.Rows[0]["id"].ToString();
			this.txtghdw.Tag =tb.Rows[0]["WLDW"].ToString();
            this.txtghdw.Text = Yp.SeekDeptName(Convert.ToInt32(tb.Rows[0]["wldw"]), InstanceForm.BDatabase);
			this.txtbz.Text=tb.Rows[0]["bz"].ToString();
			
			long djh=Convert.ToInt64(tb.Rows[0]["djh"]);
			this.lbldjh.Text=djh.ToString("00000000");

			ssql="select 0   序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,dbo.fun_yp_sccj(b.sccj) 厂家,"+
				" a.pfj 批发价,a.lsj 零售价,ypsl 数量,a.ypdw 单位,"+
				" pfje 批发金额,lsje 零售金额,b.shh 货号,"+
				" a.cjid,ydwbl dwbl,a.id from yf_rksqmx a,vi_yp_ypcd b  where a.cjid=b.cjid and  djid='"+new Guid(tb.Rows[0]["id"].ToString())+"' and deptid="+InstanceForm.BCurrentDept.DeptId+" order by a.id";
			DataTable tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
			FunBase.AddRowtNo(tbmx);
			tbmx.TableName="tbmx";
			this.myDataGrid1.DataSource=tbmx;
			this.myDataGrid1.TableStyles[0].MappingName ="tbmx";
            txtghdw.Enabled = false;
			if (Convert.ToInt32(tb.Rows[0]["shbz"])==1)
			{
				this.txtghdw.Enabled=false;
				this.txtbz.Enabled=false;
				this.txtypdm.Enabled=false;
				this.txtypsl.Enabled=false;
				this.cmbdw.Enabled=false;
				this.butsave.Enabled=false;
				this.butadd.Enabled=false;
				this.butdel.Enabled=false;
				this.butmodif.Enabled=false;	
			}
			this.butprint.Enabled=true;
			this.Sumje();

		}

		
		#endregion
	
		#region 按钮事件
		//添加一行
		private void butadd_Click(object sender, System.EventArgs e)
		{
			try
			{

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;

                string cjid = Convertor.IsNull(lblypmc.Tag, "0");
               // DataRow[] selrow = tb.Select("cjid=56");
                DataRow[] selrow = tb.Select("CJID='"+cjid+"'");
                if (selrow.Length > 0)
                    throw new Exception("第 "+selrow[0]["序号"].ToString()+" 行 已经添加了这个药品,不能重复添加");

				DataRow row=tb.NewRow();
				this.Fillrow(row);
				if (row["品名"].ToString().Trim()!="") tb.Rows.Add(row);

				this.Sumje();
                this.myDataGrid1.Select(tb.Rows.Count - 1);
                this.myDataGrid1.CurrentCell = new DataGridCell(tb.Rows.Count - 1, 3);
				this.csgroupbox2();
                this.butadd.Enabled = true;

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
	
		
		//新单据
		private void butnew_Click(object sender, System.EventArgs e)
		{
			this.csgroupbox1();
			this.csgroupbox2();
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();
			this.statusBar1.Panels[0].Text="";
			this.statusBar1.Panels[1].Text="";
			this.statusBar1.Panels[2].Text="";
			this.butadd.Enabled=true;
			this.butdel.Enabled=true;
			this.butmodif.Enabled=true;
			this.butsave.Enabled=true;
			this.butprint.Enabled=false;
			this.txtghdw.Focus();
		}

	
		//保存事件
		private void butsave_Click(object sender, System.EventArgs e)
		{
            string str = "";
			Guid  djid=Guid.Empty;
			long djh=0;
			int err_code=0;
			string err_text="";
			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			if (tb.Rows.Count==0) {MessageBox.Show("没有可保存的记录");return;};

			this.butsave.Enabled=false;

			

			try
			{
				InstanceForm.BDatabase.BeginTransaction();


				//产生单据号
                
                if (_menuTag.FunctionTag=="027")
                    djh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(this.txtghdw.Tag, "0")), InstanceForm.BDatabase) : Convert.ToInt64(this.lbldjh.Text);
				else
                    djh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) : Convert.ToInt64(this.lbldjh.Text);
				//保存单据表头
                YF_RKSQ_RKSQMX.SaveDJ(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), 
					_menuTag.FunctionTag.Trim(),
					Convert.ToInt32(Convertor.IsNull(this.txtghdw.Tag,"0")),
					0,
					InstanceForm.BCurrentUser.EmployeeId,
					sDate,+
					djh,
					InstanceForm.BCurrentDept.DeptId,
					txtbz.Text.Trim(),
					0,
                    out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
			
				//如果没有成功，抛出异常
				if (err_code!=0 || djid==Guid.Empty){throw new System.Exception(err_text);}

				//保存单据明细

				
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
                    YF_RKSQ_RKSQMX.SaveDJMX(new Guid(Convertor.IsNull(tb.Rows[i]["id"], Guid.Empty.ToString())),
						djid,
						djh,
						InstanceForm.BCurrentDept.DeptId,
						Convert.ToInt32(tb.Rows[i]["cjid"]),
						Convert.ToString(tb.Rows[i]["单位"]),
						Convert.ToInt32(tb.Rows[i]["dwbl"]),//kl
						Convert.ToDecimal(tb.Rows[i]["数量"]),
						Convert.ToDecimal(tb.Rows[i]["批发价"]),
						Convert.ToDecimal(tb.Rows[i]["零售价"]),
						Convert.ToDecimal(tb.Rows[i]["批发金额"]),
						Convert.ToDecimal(tb.Rows[i]["零售金额"]),
                        out err_code, out err_text, InstanceForm.BDatabase);
				}

				//如果没有成功，抛出异常
				if (err_code!=0){throw new System.Exception(err_text);}


                //产生目标服务器的申领单
                DataTable tbyjks = Yp.SelectYjks(Convert.ToInt32(this.txtghdw.Tag), InstanceForm.BDatabase);
                if (tbyjks.Rows.Count > 0)
                {
                    if (Convert.ToInt32(tbyjks.Rows[0]["QYBZ"]) == 1 && Convert.ToInt32(tbyjks.Rows[0]["deptid"]) != Convert.ToInt32(InstanceForm.BCurrentDept.DeptId))
                    {
                        if (Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]) != InstanceForm._menuTag.Jgbm)
                        {
                            string _err_text = "";
                                Guid log_djid = Guid.Empty;
                                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                                bool shbz=ts_HospData_Share.yp_lysq.GetShzt(djid, Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]), out _err_text);
                                if (shbz == true) throw new Exception(_err_text);
                                string bz = InstanceForm.BCurrentDept.DeptName.Trim() + " 办理 " + this.Text + "  往来科室:" + txtghdw.Text;
                                ts.Save_log(ts_HospData_Share.czlx.yp_药房申请领药单, bz, "YF_RKSQ", "ID", djid.ToString(), InstanceForm._menuTag.Jgbm, Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]), 0, "", out log_djid, InstanceForm.BDatabase);
                        }
                    }
                }

                if (new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())) == Guid.Empty)
                    str = InstanceForm.BCurrentDept.DeptName+ " "+InstanceForm.BCurrentUser.Name+ " 向 "+ txtghdw.Text.Trim()+" 发送了领药申请单";
				//提交事务
				InstanceForm.BDatabase.CommitTransaction();

				this.lbldjh.Text=djh.ToString("00000000");
                txtghdw.Enabled = false;
				this.butadd.Enabled=false;
				this.butdel.Enabled=false;
				this.butmodif.Enabled=false;
				this.butprint.Enabled=true;
				this.butsave.Enabled=false;
				MessageBox.Show(err_text);

                if (str.Trim() != "")
                    TrasenFrame.Classes.WorkStaticFun.SendMessage(false, TrasenFrame.Classes.SystemModule.药品系统, "", Convert.ToInt32(Convertor.IsNull(this.txtghdw.Tag, "0")), InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, str);


			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				this.butsave.Enabled=true;
				MessageBox.Show(err.Message);
				
			}
		}

	
		// 删除行
		private void butdel_Click(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			if (nrow>=tb.Rows.Count) return;
			if(MessageBox.Show("您确定要删除第"+Convert.ToString((nrow+1))+"行吗 ？","询问窗",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
			{

				DataRow datarow=tb.Rows[nrow];
                try
                {
                    string err_text = "";
                    string ssql = "delete from yf_rksqmx where id='" + new Guid(Convertor.IsNull(datarow["id"], Guid.Empty.ToString())) + "'";
                    InstanceForm.BDatabase.DoCommand(ssql);

                    //产生目标服务器的申领单
                    DataTable tbyjks = Yp.SelectYjks(Convert.ToInt32(this.txtghdw.Tag), InstanceForm.BDatabase);
                    if (tbyjks.Rows.Count > 0 && new Guid(Convertor.IsNull(datarow["id"], Guid.Empty.ToString()))!=Guid.Empty)
                    {
                        if (Convert.ToInt32(tbyjks.Rows[0]["QYBZ"]) == 1 && Convert.ToInt32(tbyjks.Rows[0]["deptid"]) != Convert.ToInt32(InstanceForm.BCurrentDept.DeptId))
                        {
                            if (Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]) != InstanceForm._menuTag.Jgbm)
                            {

                                Guid log_djid = Guid.Empty;
                                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                                bool shbz = ts_HospData_Share.yp_lysq.GetShzt(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]), out err_text);
                                if (shbz == true) throw new Exception(err_text);
                                string bz = InstanceForm.BCurrentDept.DeptName.Trim() + " 办理 " + this.Text + "  往来科室:" + txtghdw.Text;
                                ts.Save_log(ts_HospData_Share.czlx.yp_药房申请领药单, bz, "YF_RKSQ", "ID", new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())).ToString(), InstanceForm._menuTag.Jgbm, Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]), 0, "", out log_djid, InstanceForm.BDatabase);
                            }
                        }
                    }
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
				tb.Rows.Remove(datarow);
				this.Sumje();
				this.csgroupbox2();
			}
			
			this.butadd.Enabled=true;
		}

	
		//退出
		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		//修改按钮事件
		private void butmodif_Click(object sender, System.EventArgs e)
		{
            try
            {
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                if (nrow > tb.Rows.Count - 1) return;
                DataRow row = tb.Rows[nrow];

                DataRow[] selrow = tb.Select("cjid='" + lblypmc.Tag + "'");
                if (selrow.Length > 0)
                {
                    if (tb.Rows[nrow]["序号"].ToString() != selrow[0]["序号"].ToString())
                    throw new Exception("第 " + selrow[0]["序号"].ToString() + " 行 已经添加了这个药品,不能重复添加");

                }


                this.Fillrow(row);

                this.Sumje();
                DataRow nullrow = tb.NewRow();
                this.Getrow(nullrow);
                this.butadd.Enabled = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

	
		//审核事件
		private void butsh_Click(object sender, System.EventArgs e)
		{

		}


		//打印
		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.药品申请单.NewRow();
					myrow["xh"]=Convert.ToInt32(tb.Rows[i]["序号"]);
					if (s.打印单据时单据显示商品名==true)
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["商品名"]);
					else
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["品名"]);
					myrow["ypgg"]=Convert.ToString(tb.Rows[i]["规格"]);
					myrow["sccj"]=Convert.ToString(tb.Rows[i]["厂家"]);
					myrow["ypsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["数量"],"0"));
					myrow["ypdw"]=Convert.ToString(tb.Rows[i]["单位"]);
					myrow["pfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"],"0"));
					myrow["pfje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"],"0"));
					myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"],"0"));
					myrow["lsje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"],"0"));
					decimal plce=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"],"0"))-Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"],"0"));
					myrow["plce"]=plce.ToString("0.00");
					myrow["ypph"]="";
					myrow["ypxq"]="";
					myrow["shh"]=Convert.ToString(tb.Rows[i]["货号"]);
					myrow["kwmc"]="";
					Dset.药品申请单.Rows.Add(myrow);

				}

				ParameterEx[] parameters=new ParameterEx[6];
				parameters[0].Text="DJH";
				parameters[0].Value=this.lbldjh.Text;
				parameters[1].Text="DJY";
				parameters[1].Value=InstanceForm.BCurrentUser.Name;
				parameters[2].Text="GHDW";
				parameters[2].Value=txtghdw.Text.Trim();
				parameters[3].Text="RQ";
				parameters[3].Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();
				parameters[4].Text="TITLETEXT";
				parameters[4].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+this.Text ;
				parameters[5].Text="BZ";
				parameters[5].Value=txtbz.Text.Trim();

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.药品申请单,Constant.ApplicationDirectory+"\\Report\\YF_药品申请单据.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			

		}
	
		#endregion

		
	}
}
