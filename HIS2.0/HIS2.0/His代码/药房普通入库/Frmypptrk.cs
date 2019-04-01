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



namespace ts_yf_ptrk
{
	/// <summary>
	/// Frmyprk 的摘要说明。
	/// </summary>
	public class Frmypptrk : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
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
		private System.Windows.Forms.Label lblrkfs;
		private System.Windows.Forms.Label lblrkrq;
		private long _Sqdh;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtbz;
		private System.Windows.Forms.Label lbldjh;
		private System.Windows.Forms.Label lbldjhddd;
		private System.Windows.Forms.DateTimePicker dtprkrq;
		private System.Windows.Forms.TextBox txtghdw;
		private System.Windows.Forms.ComboBox cmbrckfs;
		private System.Windows.Forms.Label lbllsje;
		private System.Windows.Forms.Label lblpfje;
		private System.Windows.Forms.TextBox txtph;
		private System.Windows.Forms.TextBox txtkw;
		private System.Windows.Forms.DateTimePicker dtpxq;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.Label lblkc;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.Button butsh;
		private System.Windows.Forms.Button butph;
		private System.Windows.Forms.DataGridTextBoxColumn 批号;
		private System.Windows.Forms.DataGridTextBoxColumn 效期;
		private System.Windows.Forms.DataGridTextBoxColumn 库位;
		private System.Windows.Forms.DataGridTextBoxColumn 申请量;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblghdw;
		private System.Windows.Forms.Button button1;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.Label lblpm;
		private YpConfig s;
		private System.Windows.Forms.DataGridTextBoxColumn 商品名;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.TextBox lbljhje;
		private System.Windows.Forms.TextBox lbljhj;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox chkjj;
        private TextBox txtpch;
        private Label label9;
        private DataGridTextBoxColumn col_批次号;
        private DataGridTextBoxColumn col_kcid;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;


        bool bpcgl = false; //是否进行批次管理
        private bool btjhj = false;//是否调进货价
           
		public Frmypptrk(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			_Sqdh=0;
			this.Text =chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
			s=new YpConfig(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase);

            int deptid = Convert.ToInt32(Convertor.IsNull(InstanceForm.BCurrentDept.DeptId, "0")); //库房id
            bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);                        //是否进行批次管理
            if (bpcgl)//是否显示批次列
                col_批次号.Width = 75;
            else
                col_批次号.Width = 0;

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
            this.dtprkrq = new System.Windows.Forms.DateTimePicker();
            this.lblrkrq = new System.Windows.Forms.Label();
            this.txtghdw = new System.Windows.Forms.TextBox();
            this.lblghdw = new System.Windows.Forms.Label();
            this.cmbrckfs = new System.Windows.Forms.ComboBox();
            this.lblrkfs = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtpch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbljhje = new System.Windows.Forms.TextBox();
            this.lbljhj = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblypmc = new System.Windows.Forms.Label();
            this.lblpm = new System.Windows.Forms.Label();
            this.lbllsje = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblpfje = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butph = new System.Windows.Forms.Button();
            this.txtph = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtkw = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.dtpxq = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
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
            this.col_批次号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_kcid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.批号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.效期 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.库位 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.申请量 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkjj = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.butsh = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.dtprkrq);
            this.groupBox1.Controls.Add(this.lblrkrq);
            this.groupBox1.Controls.Add(this.txtghdw);
            this.groupBox1.Controls.Add(this.lblghdw);
            this.groupBox1.Controls.Add(this.cmbrckfs);
            this.groupBox1.Controls.Add(this.lblrkfs);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(922, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtbz
            // 
            this.txtbz.ForeColor = System.Drawing.Color.Navy;
            this.txtbz.Location = new System.Drawing.Point(64, 37);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(712, 21);
            this.txtbz.TabIndex = 3;
            this.txtbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "备注";
            // 
            // lbldjh
            // 
            this.lbldjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldjh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldjh.ForeColor = System.Drawing.Color.Navy;
            this.lbldjh.Location = new System.Drawing.Point(679, 12);
            this.lbldjh.Name = "lbldjh";
            this.lbldjh.Size = new System.Drawing.Size(97, 20);
            this.lbldjh.TabIndex = 15;
            // 
            // lbldjhddd
            // 
            this.lbldjhddd.Location = new System.Drawing.Point(624, 16);
            this.lbldjhddd.Name = "lbldjhddd";
            this.lbldjhddd.Size = new System.Drawing.Size(64, 16);
            this.lbldjhddd.TabIndex = 14;
            this.lbldjhddd.Text = "单据号";
            // 
            // dtprkrq
            // 
            this.dtprkrq.Location = new System.Drawing.Point(496, 11);
            this.dtprkrq.Name = "dtprkrq";
            this.dtprkrq.Size = new System.Drawing.Size(120, 21);
            this.dtprkrq.TabIndex = 2;
            this.dtprkrq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblrkrq
            // 
            this.lblrkrq.Location = new System.Drawing.Point(440, 16);
            this.lblrkrq.Name = "lblrkrq";
            this.lblrkrq.Size = new System.Drawing.Size(64, 16);
            this.lblrkrq.TabIndex = 4;
            this.lblrkrq.Text = "单据日期";
            // 
            // txtghdw
            // 
            this.txtghdw.ForeColor = System.Drawing.Color.Navy;
            this.txtghdw.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtghdw.Location = new System.Drawing.Point(64, 11);
            this.txtghdw.Name = "txtghdw";
            this.txtghdw.Size = new System.Drawing.Size(368, 21);
            this.txtghdw.TabIndex = 1;
            this.txtghdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtghdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblghdw
            // 
            this.lblghdw.Location = new System.Drawing.Point(8, 16);
            this.lblghdw.Name = "lblghdw";
            this.lblghdw.Size = new System.Drawing.Size(64, 16);
            this.lblghdw.TabIndex = 2;
            this.lblghdw.Text = "供货单位";
            // 
            // cmbrckfs
            // 
            this.cmbrckfs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbrckfs.ForeColor = System.Drawing.Color.Navy;
            this.cmbrckfs.Location = new System.Drawing.Point(65, 12);
            this.cmbrckfs.Name = "cmbrckfs";
            this.cmbrckfs.Size = new System.Drawing.Size(111, 20);
            this.cmbrckfs.TabIndex = 0;
            this.cmbrckfs.Visible = false;
            this.cmbrckfs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblrkfs
            // 
            this.lblrkfs.Location = new System.Drawing.Point(8, 16);
            this.lblrkfs.Name = "lblrkfs";
            this.lblrkfs.Size = new System.Drawing.Size(64, 16);
            this.lblrkfs.TabIndex = 0;
            this.lblrkfs.Text = "单据方式";
            this.lblrkfs.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtpch);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lbljhje);
            this.groupBox2.Controls.Add(this.lbljhj);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblypmc);
            this.groupBox2.Controls.Add(this.lblpm);
            this.groupBox2.Controls.Add(this.lbllsje);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblpfje);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.butph);
            this.groupBox2.Controls.Add(this.txtph);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtkw);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.dtpxq);
            this.groupBox2.Controls.Add(this.label30);
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
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lblcj);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblgg);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtypdm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(922, 120);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtpch
            // 
            this.txtpch.ForeColor = System.Drawing.Color.Navy;
            this.txtpch.Location = new System.Drawing.Point(64, 87);
            this.txtpch.Name = "txtpch";
            this.txtpch.ReadOnly = true;
            this.txtpch.Size = new System.Drawing.Size(111, 21);
            this.txtpch.TabIndex = 88;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(32, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 89;
            this.label9.Text = "批次";
            // 
            // lbljhje
            // 
            this.lbljhje.Enabled = false;
            this.lbljhje.ForeColor = System.Drawing.Color.Navy;
            this.lbljhje.Location = new System.Drawing.Point(680, 64);
            this.lbljhje.Name = "lbljhje";
            this.lbljhje.Size = new System.Drawing.Size(96, 21);
            this.lbljhje.TabIndex = 8;
            this.lbljhje.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbljhje_KeyUp);
            this.lbljhje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lbljhj
            // 
            this.lbljhj.Enabled = false;
            this.lbljhj.ForeColor = System.Drawing.Color.Navy;
            this.lbljhj.Location = new System.Drawing.Point(544, 64);
            this.lbljhj.Name = "lbljhj";
            this.lbljhj.Size = new System.Drawing.Size(72, 21);
            this.lbljhj.TabIndex = 7;
            this.lbljhj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbljhj_KeyUp);
            this.lbljhj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(624, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 87;
            this.label11.Text = "进货金额";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(516, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 86;
            this.label8.Text = "进价";
            // 
            // lblypmc
            // 
            this.lblypmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblypmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblypmc.ForeColor = System.Drawing.Color.Navy;
            this.lblypmc.Location = new System.Drawing.Point(392, 15);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(136, 19);
            this.lblypmc.TabIndex = 21;
            // 
            // lblpm
            // 
            this.lblpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpm.ForeColor = System.Drawing.Color.Navy;
            this.lblpm.Location = new System.Drawing.Point(232, 15);
            this.lblpm.Name = "lblpm";
            this.lblpm.Size = new System.Drawing.Size(160, 19);
            this.lblpm.TabIndex = 72;
            // 
            // lbllsje
            // 
            this.lbllsje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsje.ForeColor = System.Drawing.Color.Navy;
            this.lbllsje.Location = new System.Drawing.Point(392, 65);
            this.lbllsje.Name = "lbllsje";
            this.lbllsje.Size = new System.Drawing.Size(104, 20);
            this.lbllsje.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(336, 67);
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
            this.lblpfje.Size = new System.Drawing.Size(104, 20);
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
            // butph
            // 
            this.butph.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butph.Location = new System.Drawing.Point(313, 88);
            this.butph.Name = "butph";
            this.butph.Size = new System.Drawing.Size(25, 20);
            this.butph.TabIndex = 67;
            this.butph.Text = "F1";
            this.butph.Click += new System.EventHandler(this.butph_Click);
            // 
            // txtph
            // 
            this.txtph.ForeColor = System.Drawing.Color.Navy;
            this.txtph.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtph.Location = new System.Drawing.Point(232, 88);
            this.txtph.Name = "txtph";
            this.txtph.Size = new System.Drawing.Size(80, 21);
            this.txtph.TabIndex = 9;
            this.txtph.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(200, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 65;
            this.label5.Text = "批号";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(664, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 20);
            this.button2.TabIndex = 64;
            this.button2.Text = "...";
            this.button2.Visible = false;
            // 
            // txtkw
            // 
            this.txtkw.ForeColor = System.Drawing.Color.Navy;
            this.txtkw.Location = new System.Drawing.Point(576, 90);
            this.txtkw.Name = "txtkw";
            this.txtkw.Size = new System.Drawing.Size(90, 21);
            this.txtkw.TabIndex = 11;
            this.txtkw.Visible = false;
            this.txtkw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtkw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtkw.LostFocus += new System.EventHandler(this.txtkw_LostFocus);
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(544, 94);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 16);
            this.label31.TabIndex = 62;
            this.label31.Text = "库位";
            this.label31.Visible = false;
            // 
            // dtpxq
            // 
            this.dtpxq.Location = new System.Drawing.Point(400, 90);
            this.dtpxq.Name = "dtpxq";
            this.dtpxq.Size = new System.Drawing.Size(128, 21);
            this.dtpxq.TabIndex = 10;
            this.dtpxq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(347, 94);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 16);
            this.label30.TabIndex = 60;
            this.label30.Text = "有效日期";
            // 
            // butmodif
            // 
            this.butmodif.Location = new System.Drawing.Point(843, 90);
            this.butmodif.Name = "butmodif";
            this.butmodif.Size = new System.Drawing.Size(64, 24);
            this.butmodif.TabIndex = 14;
            this.butmodif.Text = "修改(&M)";
            this.butmodif.Click += new System.EventHandler(this.butmodif_Click);
            // 
            // butdel
            // 
            this.butdel.Location = new System.Drawing.Point(772, 90);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(65, 24);
            this.butdel.TabIndex = 13;
            this.butdel.Text = "删除(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butadd
            // 
            this.butadd.Location = new System.Drawing.Point(700, 90);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(65, 24);
            this.butadd.TabIndex = 12;
            this.butadd.Text = "添加(&A)";
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            this.butadd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblkc
            // 
            this.lblkc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkc.ForeColor = System.Drawing.Color.Navy;
            this.lblkc.Location = new System.Drawing.Point(544, 40);
            this.lblkc.Name = "lblkc";
            this.lblkc.Size = new System.Drawing.Size(72, 20);
            this.lblkc.TabIndex = 51;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(504, 42);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 16);
            this.label36.TabIndex = 50;
            this.label36.Text = "库存量";
            // 
            // txtypsl
            // 
            this.txtypsl.ForeColor = System.Drawing.Color.Navy;
            this.txtypsl.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtypsl.Location = new System.Drawing.Point(64, 40);
            this.txtypsl.Name = "txtypsl";
            this.txtypsl.Size = new System.Drawing.Size(96, 21);
            this.txtypsl.TabIndex = 5;
            this.txtypsl.Leave += new System.EventHandler(this.txtypsl_Leave);
            this.txtypsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(32, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(33, 16);
            this.label26.TabIndex = 32;
            this.label26.Text = "数量";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(392, 40);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(104, 20);
            this.lbllsj.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(344, 40);
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
            this.lblpfj.Size = new System.Drawing.Size(104, 20);
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
            this.cmbdw.TabIndex = 6;
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
            this.label18.Location = new System.Drawing.Point(648, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 16);
            this.label18.TabIndex = 22;
            this.label18.Text = "货号";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(162, 16);
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
            this.lblcj.Size = new System.Drawing.Size(87, 19);
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
            this.lblgg.Size = new System.Drawing.Size(84, 19);
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
            this.txtypdm.ImeMode = System.Windows.Forms.ImeMode.Off;
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
            this.groupBox3.Location = new System.Drawing.Point(0, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(922, 365);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 281);
            this.panel2.TabIndex = 63;
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
            this.myDataGrid1.Size = new System.Drawing.Size(916, 281);
            this.myDataGrid1.TabIndex = 60;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.商品名,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.col_批次号,
            this.col_kcid,
            this.批号,
            this.效期,
            this.库位,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.申请量,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn19});
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
            this.dataGridTextBoxColumn2.Width = 110;
            // 
            // 商品名
            // 
            this.商品名.Format = "";
            this.商品名.FormatInfo = null;
            this.商品名.HeaderText = "商品名";
            this.商品名.NullText = "";
            this.商品名.ReadOnly = true;
            this.商品名.Width = 110;
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
            // col_批次号
            // 
            this.col_批次号.Format = "";
            this.col_批次号.FormatInfo = null;
            this.col_批次号.HeaderText = "批次号";
            this.col_批次号.Width = 115;
            // 
            // col_kcid
            // 
            this.col_kcid.Format = "";
            this.col_kcid.FormatInfo = null;
            this.col_kcid.HeaderText = "kcid";
            this.col_kcid.Width = 0;
            // 
            // 批号
            // 
            this.批号.Format = "";
            this.批号.FormatInfo = null;
            this.批号.HeaderText = "批号";
            this.批号.NullText = "";
            this.批号.ReadOnly = true;
            this.批号.Width = 60;
            // 
            // 效期
            // 
            this.效期.Format = "";
            this.效期.FormatInfo = null;
            this.效期.HeaderText = "效期";
            this.效期.NullText = "";
            this.效期.ReadOnly = true;
            this.效期.Width = 85;
            // 
            // 库位
            // 
            this.库位.Format = "";
            this.库位.FormatInfo = null;
            this.库位.HeaderText = "库位";
            this.库位.NullText = "";
            this.库位.ReadOnly = true;
            this.库位.Width = 60;
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
            // 申请量
            // 
            this.申请量.Format = "";
            this.申请量.FormatInfo = null;
            this.申请量.HeaderText = "申请量";
            this.申请量.NullText = "";
            this.申请量.ReadOnly = true;
            this.申请量.Width = 50;
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
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "批零差额";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 60;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "进价";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "进货金额";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 70;
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
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "kwid";
            this.dataGridTextBoxColumn18.NullText = "0";
            this.dataGridTextBoxColumn18.ReadOnly = true;
            this.dataGridTextBoxColumn18.Width = 0;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "id";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.ReadOnly = true;
            this.dataGridTextBoxColumn19.Width = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkjj);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butnew);
            this.panel1.Controls.Add(this.butsh);
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 64);
            this.panel1.TabIndex = 62;
            // 
            // chkjj
            // 
            this.chkjj.Location = new System.Drawing.Point(16, 8);
            this.chkjj.Name = "chkjj";
            this.chkjj.Size = new System.Drawing.Size(112, 24);
            this.chkjj.TabIndex = 74;
            this.chkjj.Text = "进价可以输入";
            this.chkjj.Visible = false;
            this.chkjj.CheckedChanged += new System.EventHandler(this.chkjj_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 24);
            this.button1.TabIndex = 73;
            this.button1.Text = "初始化库存";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(472, 8);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(88, 24);
            this.butsave.TabIndex = 57;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(296, 8);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(88, 24);
            this.butnew.TabIndex = 56;
            this.butnew.Text = "新单号(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // butsh
            // 
            this.butsh.Enabled = false;
            this.butsh.Location = new System.Drawing.Point(384, 8);
            this.butsh.Name = "butsh";
            this.butsh.Size = new System.Drawing.Size(88, 24);
            this.butsh.TabIndex = 61;
            this.butsh.Text = "审核(&H)";
            this.butsh.Click += new System.EventHandler(this.butsh_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(648, 8);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 59;
            this.butclose.Text = "关闭(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butprint
            // 
            this.butprint.Enabled = false;
            this.butprint.Location = new System.Drawing.Point(560, 8);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 24);
            this.butprint.TabIndex = 58;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 524);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(922, 25);
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
            // Frmypptrk
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(922, 549);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "Frmypptrk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "药品普通入库";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmypptrk_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frmypptrk_KeyUp);
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

        //Fun_ts_yf_ypptrk_qc 期初入库单
        //Fun_ts_yf_ypptrk_sh 药库入库单
        //Fun_ts_yf_ypptrk_drd 药品调入单
        //Fun_ts_yf_ypptrk_qtrk 其他入库单
        //Fun_ts_yf_ypptrk_xygrk 科室申请领药审核入库

		private void Frmypptrk_Load(object sender, System.EventArgs e)
		{
			try
			{
				//YFFun.AddRckfs (_menuTag.FunctionTag.Trim(),this.cmbrckfs);

				this.dtprkrq.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				//初始化未发药处方列表
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");

				if (s.网络内容显示商品名==true)
					this.商品名.Width=110;
				else
					this.商品名.Width=0;

				this.butnew_Click(sender,e);

				this.FunctionControlEnable(_menuTag.Function_Name.Trim());

                SystemCfg s8015 = new SystemCfg(8015);
                if (s8015.Config != "1")
                    button1.Visible = false;
                else
                    button1.Visible = true;
                SystemCfg cfg8056 = new SystemCfg(8056);//调进货价
                if (cfg8056.Config == "1")
                {
                    btjhj = true;
                }

                
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}

		private void FunctionControlEnable(string functionName)
		{
			//系统控制
			
			YpConfig s=new YpConfig(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase);

            //if (s.管理批号 == false)
            //{
            //    txtph.Enabled = false;
            //    dtpxq.Enabled = false;
            //    butph.Enabled = false;
            //    this.批号.Width = 0;
            //    this.效期.Width = 0;
            //}
			if (s.库位管理==false)
			{
				txtkw.Enabled=false;
				this.库位.Width=0;
			}

			switch(functionName)
			{
				case "Fun_ts_yf_ypptrk_qc":
					 this.申请量.Width=0;
					lblghdw.Visible=false;
					txtghdw.Visible=false;
					txtghdw.Enabled=false;
					txtghdw.Text=InstanceForm.BCurrentDept.DeptName;
					txtghdw.Tag=InstanceForm.BCurrentDept.DeptId.ToString();
                    txtypdm.Focus();
					break;
				case "Fun_ts_yf_ypptrk_sh":
					this.butprint.Visible=false;
					this.butnew.Visible=s.业务单据接受方是否可以手工办理单据;
					this.butsave.Visible=s.业务单据接受方是否可以手工办理单据;
					break;
				case "Fun_ts_yf_ypptrk_drd":
                    this.butprint.Visible = s.业务单据接受方是否可以手工办理单据;
					this.butnew.Visible=s.业务单据接受方是否可以手工办理单据;
					this.butsave.Visible=s.业务单据接受方是否可以手工办理单据;
					this.申请量.Width=0;
					break;
				case "Fun_ts_yf_ypptrk_qtrk":
					 this.申请量.Width=0;
					break;
				case "Fun_ts_yf_ypptrk_xygrk":
					this.butnew.Visible=s.业务单据接受方是否可以手工办理单据;
					this.butsave.Visible=s.业务单据接受方是否可以手工办理单据;
					break;
				default:
					break;
			}
		}


		#region 界面控制事件
		// 回车跳至下一个文本
		private void GotoNext(object sender, KeyPressEventArgs e)
		{ 
			Control control=(Control)sender;
			if (e.KeyChar==13 )
			{
                if (txtypsl.Text == "" && control.Name == "txtypsl")
                    return;
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
            this.groupBox1.Tag = null;
			this.dtprkrq.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
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

			//系统控制
            if (s.管理批号 == false)
            {
                txtph.Enabled = false;
                dtpxq.Enabled = false;
                butph.Enabled = false;
                this.批号.Width = 0;
                this.效期.Width = 0;
            }

            if (bpcgl)//进行批次管理
            {
                txtph.Enabled = true;
                dtpxq.Enabled = true;
                butph.Enabled = true;
                this.批号.Width = 60;
                this.效期.Width = 60;
            }

			if (s.库位管理==false)
			{
				txtkw.Enabled=false;
				this.库位.Width=0;
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
			this.dtpxq.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

			this.lbljhj.Text="";
			this.lbljhj.Tag="";
			this.lbljhje.Text="";

			this.lbljhj.Enabled=this.chkjj.Checked==true?true:false;
			this.lbljhje.Enabled=this.chkjj.Checked==true?true:false;

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
				
				
				switch(control.TabIndex)
				{
					case 1:
						Point point=new Point(this.Location.X+this.groupBox1.Location.X+control.Location.X,this.Location.Y+this.groupBox1.Location.Y +control.Location.Y+control.Height*3 );
						if (control.Text.Trim()=="")  return;

						if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_ypptrk_qtrk")
						{
                            Yp.frmShowCard(sender, ShowCardType.供货单位, 0, point,InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
							if (Convertor.IsNull(control.Tag,"0")!="0") this.SelectNextControl((Control)sender,true,false,true,true);
						}
						else
						{
                            Yp.frmShowCard_funName(sender, ShowCardType.单据往来科室, _menuTag.Function_Name, point,InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
							if (Convertor.IsNull(control.Tag,"0")!="0") this.SelectNextControl((Control)sender,true,false,true,true);
						}

						break;

					case 4:
                        Point point1 = new Point(this.Location.X + this.groupBox2.Location.X + control.Location.X, this.groupBox1.Location.Y + this.groupBox2.Location.Y + control.Location.Y + control.Height * 5);
						if (control.Text.Trim()=="")  return;
                        Yp.frmShowCard(sender, ShowCardType.包含在科室管理类型中的药品字典, 0, point1,InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
						if (Convertor.IsNull(control.Tag,"0")!="0") 
						{
                            Ypcj cj = new Ypcj(Convert.ToInt32(Convertor.IsNull(control.Tag, "0")), InstanceForm.BDatabase);
                            FindRecord(cj.CJID, 0);
                            csgroupbox2();
                            if (butsave.Enabled == true) butadd.Enabled = true;
                            this.csyp(cj.GGID, cj.CJID);
                            this.SelectNextControl((Control)sender, true, false, true, true);                            
						}
						else
						{
							return;
						}
						break;
					case 9:
//						Point point2=new Point(this.Location.X+this.groupBox2.Location.X+control.Location.X,this.Location.Y+this.groupBox2.Location.Y +control.Location.Y+control.Height*3 );
//						if (control.Text.Trim()=="") return;
//						Yp.frmShowCard(sender,ShowCardType.,0,point);
//						if (Convertor.IsNull(control.Tag,"0")!="0") this.SelectNextControl((Control)sender,true,false,true,true);
						break;

				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

        private void FindRecord(int cjid, int nrow)
        {
            int beginrow = nrow;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = beginrow; i <= tb.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(tb.Rows[i]["cjid"]) == cjid)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    for (int j = 0; j <= tb.Rows.Count - 1; j++)
                    {
                        this.myDataGrid1.UnSelect(j);
                    }

                    this.myDataGrid1.Select(i);
                    beginrow = i + 1;
                    DataRow row = tb.NewRow();
                    Getrow(row);
                    return;

                }

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
				else
				{DataRow row=tb.Rows[nrow];Getrow(row);this.butadd.Enabled=false;}
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
                if (Convert.ToUInt32(Convertor.IsNull(lblypmc.Tag, "0")) == 0) return;
				if (cmbdw.SelectedIndex<=-1) return;
				//if (cmbdw.SelectedValue.GetType().ToString()!="System.Int32") return;
				int dwbl=Convert.ToInt32(cmbdw.SelectedValue);
				this.lblkc.Text=Yp.SeekKcZh(dwbl,Convert.ToInt32(this.lblypmc.Tag),InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase).ToString("0.000");
		
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

                decimal jhj = Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Tag, "0")) / dwbl;
                jhj = Convert.ToDecimal(jhj.ToString("0.0000"));
                decimal jhje = jhj * ypsl;
                this.lbljhj.Text = jhj.ToString("0.0000");
                this.lbljhje.Text = jhje.ToString("0.00");
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		
		//窗体键盘事件
		private void Frmypptrk_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (Convert.ToInt32(e.KeyCode)==112)
			{
				this.butph_Click(sender,e);
			}
		}

		
		private void txtypsl_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if (Convertor.IsNumeric(txtypsl.Text)==false) txtypsl.Text="";
				if(txtypsl.Text.Trim()!="-" && txtypsl.Text.Trim()!=".")
				{
					decimal sumpfje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text,"0"));
					this.lblpfje.Text=sumpfje.ToString("0.00");
					decimal sumlsje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text,"0"));
					this.lbllsje.Text=sumlsje.ToString("0.00");

					decimal sumjhje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text,"0"));
					this.lbljhje.Text=sumjhje.ToString("0.00");
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}

		#endregion

		#region 填充数据的过程
		//初始药品
		private void csyp(int ggid,int cjid)
		{
			try
			{
				this.csgroupbox2();
				//Ydgg ydgg=new  Ydgg(ggid);
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
				this.lbljhj.Text="";
				this.lbljhje.Text="";
                if (bpcgl)
                {
                    lbljhj.Text = ydcj.MRJJ.ToString();
                    lbljhj.Tag = ydcj.MRJJ;
                }

                if (btjhj)//如果调进货价
                {
                    lbljhj.Text = ydcj.MRJJ.ToString();
                    lbljhj.Tag = ydcj.MRJJ;
                }

                Yp.AddCmbDW(InstanceForm.BCurrentDept.DeptId, ydcj.GGID, ydcj.CJID, this.cmbdw, InstanceForm.BDatabase);
				this.cmbdw.SelectedIndex=0;
				this.lblkc.Text=Yp.SeekKcZh(Convert.ToInt32(this.cmbdw.SelectedValue),ydcj.CJID,InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase).ToString("0.000");
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message );
			}
		}


        //Fun_ts_yf_ypptrk_qc 期初入库单
        //Fun_ts_yf_ypptrk_sh 药库入库单
        //Fun_ts_yf_ypptrk_drd 药品调入单
        //Fun_ts_yf_ypptrk_qtrk 其他入库单
        //Fun_ts_yf_ypptrk_xygrk 科室申请领药审核入库

		//填充行
		private void Fillrow(System.Data.DataRow row)
        {

            #region 验证输入
            if (Convert.ToInt32(this.lblypmc.Tag) == 0)
            {
                MessageBox.Show("没有可添加的药品");
                return;
            }

            if (Convertor.IsNull(this.txtypsl.Text, "") == "")
            {
                MessageBox.Show("请输入药品数量");
                txtypsl.Focus();
                return;
            }

            if (Convertor.IsNumeric(txtypsl.Text) == true)
            {
                if (new SystemCfg(8022).Config.Contains(_menuTag.FunctionTag.ToString()) == true && Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0")) < 0)
                {
                    MessageBox.Show("系统设定不能输入负数");
                    return;
                }
            }
            #endregion

            Guid t_kcid = Guid.Empty;


            #region 验证库存
            if (_menuTag.Function_Name == "")
            {
                if (Convertor.IsNull(txtph.Tag.ToString(), "0") != "0")
                {
                    t_kcid = new Guid(txtph.Tag.ToString());
                }

                YpConfig s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                if (Yp.BYfOutKc(_menuTag.FunctionTag.Trim(),
                    Convert.ToInt32(this.lblypmc.Tag),
                    Convertor.IsNull(this.txtph.Text.Trim(), "无批号"),
                    Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text.Trim(), "0")),
                    Convert.ToInt32(cmbdw.SelectedValue),
                    InstanceForm.BCurrentDept.DeptId, Convert.ToDecimal(Convertor.IsNull(lbljhj.Text, "0")), InstanceForm.BDatabase
                    , t_kcid) == true)
                {
                    if (s.强制控制库存 == true)
                    {
                        MessageBox.Show("库存不够,请重新确认数量");
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show(this, "库存不够，您确认继续吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    }
                }
            }
            #endregion

            DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				row["序号"]=tb.Rows.Count+1;
				row["商品名"]=this.lblypmc.Text.Trim();
				row["品名"]=this.lblpm.Text.Trim();
				row["规格"]=this.lblgg.Text.Trim();
				row["厂家"]=this.lblcj.Text.Trim();

				row["批号"]=Convertor.IsNull(this.txtph.Text.Trim(),"无批号");
				row["效期"]=this.dtpxq.Value.ToShortDateString();
				row["库位"]=this.txtkw.Text.ToString();
				row["批发价"]=this.lblpfj.Text.Trim();
				row["零售价"]=this.lbllsj.Text.Trim();
				row["数量"]=this.txtypsl.Text.Trim();
				row["单位"]=this.cmbdw.Text.Trim();
				decimal sumpfje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(),"0"));
				row["批发金额"]=sumpfje.ToString("0.00");
				decimal sumlsje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text.Trim(),"0"));
				row["零售金额"]=sumlsje.ToString("0.00");
				decimal sumplce=sumlsje-sumpfje;
				row["批零差额"]=sumplce.ToString("0.00");

				//进价、进货金额
				decimal sumjhje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text.Trim(),"0"));
				row["进价"]=Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text,"0"));
				row["进货金额"]=sumjhje.ToString("0.00");

				row["货号"]=this.lblhh.Text.Trim();
				row["CJID"]=this.lblypmc.Tag.ToString();
				row["DWBL"]=Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
				row["kwid"]=Convertor.IsNull(this.txtkw.Tag,"0");

                row["kcid"] = t_kcid;        //kcid
                row["批次号"] = this.txtpch.Text.Trim();//批次号
				SortRowNO();
		}

		
		//求和金额
		private void Sumje()
		{
			try
			{
				decimal sumjhje=0;
				decimal sumpfje=0;
				decimal sumlsje=0;
				decimal sumplce=0;
				decimal sumjlce=0;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				for( int i=0;i<=tb.Rows.Count-1;i++)
				{
					sumjhje=sumjhje+Convert.ToDecimal(tb.Rows[i]["进货金额"]);
					sumpfje=sumpfje+Convert.ToDecimal(tb.Rows[i]["批发金额"]);
					sumlsje=sumlsje+Convert.ToDecimal(tb.Rows[i]["零售金额"]);
				}
				sumplce=sumlsje-sumpfje;
				sumjlce=sumlsje-sumjhje;
				//				this.statusBar1.Panels[0].Text ="批发金额: "+sumpfje.ToString("0.00");
				//				this.statusBar1.Panels[1].Text ="零售金额: "+sumlsje.ToString("0.00");
				//				this.statusBar1.Panels[2].Text ="批零差额: "+sumplce.ToString("0.00");
				
				this.statusBar1.Panels[0].Text ="进货金额: "+sumjhje.ToString("0.00");
				this.statusBar1.Panels[1].Text ="零售金额: "+sumlsje.ToString("0.00");
				this.statusBar1.Panels[2].Text ="进零差额: "+sumjlce.ToString("0.00");
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}


		//获取一行
		private void Getrow(DataRow row)
		{
			int cjid=Convert.ToInt32(Convertor.IsNull(row["cjid"],"0"));
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
			this.lblypmc.Text=row["商品名"].ToString();
			this.lblypmc.Tag=row["CJID"].ToString();
			this.lblpm.Text=row["品名"].ToString();
			this.lblgg.Text=row["规格"].ToString();
			this.lblcj.Text=row["厂家"].ToString();
            this.txtpch.Text = row["批次号"].ToString();
            this.txtph.Tag = row["kcid"];
			this.txtph.Text=row["批号"].ToString();
			if (row["效期"].ToString().Trim()!="")  this.dtpxq.Value=Convert.ToDateTime(row["效期"]);
			this.txtkw.Text=row["库位"].ToString();
			this.txtkw.Tag=Convertor.IsNull(row["kwid"].ToString(),"0");
			this.lblpfj.Text=row["批发价"].ToString();
			this.lblpfj.Tag=ydcj.PFJ.ToString();
			this.lbllsj.Text=row["零售价"].ToString();
			this.lbllsj.Tag=ydcj.LSJ.ToString();
			this.txtypsl.Text=row["数量"].ToString();
            Yp.AddCmbDW(InstanceForm.BCurrentDept.DeptId, ydcj.GGID, ydcj.CJID, this.cmbdw, InstanceForm.BDatabase);
			this.cmbdw.Text=row["单位"].ToString();
			this.lblkc.Text=Yp.SeekKcZh(Convert.ToInt32(this.cmbdw.SelectedValue),ydcj.CJID,InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase).ToString("0.000");
			this.lblpfje.Text=row["批发金额"].ToString();
			this.lbllsje.Text=row["零售金额"].ToString();
			this.lblhh.Text=row["货号"].ToString();

			this.lbljhj.Text=row["进价"].ToString();
			this.lbljhj.Tag=Convert.ToDecimal(Convertor.IsNull(row["进价"],"0"))*Convert.ToDecimal(Convertor.IsNull(row["dwbl"],"0"));
			this.lbljhje.Text=row["进货金额"].ToString();
			
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
		public void FillDj(Guid  id,bool shbz)
		{
			string ssql="select * from vi_yf_dj where id='"+id+"'";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			
			this.groupBox1.Tag=tb.Rows[0]["id"].ToString();
			this.txtghdw.Tag =tb.Rows[0]["WLDW"].ToString();
            if (_menuTag.Function_Name.Trim()!="Fun_ts_yf_ypptrk_qtrk") //其他入库
                this.txtghdw.Text = Yp.SeekDeptName(Convert.ToInt32(tb.Rows[0]["wldw"]), InstanceForm.BDatabase);
            else
                this.txtghdw.Text = Yp.SeekGhdw(Convert.ToInt32(tb.Rows[0]["wldw"]), InstanceForm.BDatabase);

			this.txtbz.Text=tb.Rows[0]["bz"].ToString();
			this._Sqdh=Convert.ToInt64(tb.Rows[0]["sqdh"]);
			this.dtprkrq.Value=Convert.ToDateTime(tb.Rows[0]["rq"]);
			long djh=Convert.ToInt64(tb.Rows[0]["djh"]);
			this.lbldjh.Text=djh.ToString("00000000");
				
			ssql=@"select 0   序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,dbo.fun_yp_sccj(b.sccj) 厂家,
                    a.yppch 批次号,a.kcid,a.ypph 批号,a.ypxq 效期,dbo.fun_yp_KWMC(b.ggid,A.DEPTID) 库位,"+
					" a.pfj 批发价,a.lsj 零售价,sqsl 申请量,ypsl 数量,a.ypdw 单位,"+
					" pfje 批发金额,lsje 零售金额,(lsje-pfje) 批零差额,jhj 进价,jhje 进货金额,b.shh 货号,"+
					" a.cjid,ydwbl dwbl,kwid,a.id from yf_djmx a,vi_yp_ypcd b  where a.cjid=b.cjid and djid='"+id+"' order by a.pxxh";
			DataTable tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
			if (tbmx.Rows.Count==0)
			{
                ssql = @"select 0   序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,dbo.fun_yp_sccj(b.sccj) 厂家,
                       a.yppch 批次号,a.kcid,a.ypph 批号,a.ypxq 效期,dbo.fun_yp_KWMC(b.ggid,A.DEPTID) 库位," +
					" a.pfj 批发价,a.lsj 零售价,sqsl 申请量,ypsl 数量,a.ypdw 单位,"+
					" pfje 批发金额,lsje 零售金额,(lsje-pfje) 批零差额,jhj 进价,jhje 进货金额,b.shh 货号,"+
					" a.cjid,ydwbl dwbl,kwid,a.id from yf_djmx_h a,vi_yp_ypcd b  where a.cjid=b.cjid and djid='"+id+"' order by a.pxxh";
				tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
			}
			tbmx.TableName="tbmx";
			FunBase.AddRowtNo(tbmx);
			this.myDataGrid1.DataSource=tbmx;
			this.myDataGrid1.TableStyles[0].MappingName ="tbmx";
			
			//this.butnew.Visible=false;
			this.cmbrckfs.Enabled=false;
			this.txtghdw.Enabled=false;
			this.dtprkrq.Enabled=false;
			this.txtbz.Enabled=false;
			this.txtypdm.Enabled=true;
			this.txtypsl.Enabled=false;
			this.cmbdw.Enabled=false;
			this.txtph.Enabled=false;
			this.dtpxq.Enabled=false;
			this.txtkw.Enabled=false;
			this.butsave.Enabled=false;
			this.butadd.Enabled=false;
			this.butdel.Enabled=false;
			this.butmodif.Enabled=false;	
			this.butsh.Enabled=false;
			this.butprint.Enabled=true;
			if (Convert.ToInt32(tb.Rows[0]["shbz"])==0) {this.butsh.Enabled=true;this.butprint.Enabled=false;}
			this.Sumje();

		}

		
		#endregion
	
		#region 按钮事件
		//添加一行
		private void butadd_Click(object sender, System.EventArgs e)
		{
			try
			{
                #region Modify by dyw 2014/6/28  期初入库判断进价不能为0.00
                if (Convert.ToDecimal(Convertor.IsNull(lbljhj.Text, "0")) == 0)
                {
                    MessageBox.Show(lblpm.Text.Trim() + "的进价不能为0，请联系药库维护价格");
                    return;
                }
                if (Convert.ToDecimal(Convertor.IsNull(lbljhje.Text, "0")) == 0)
                {
                    MessageBox.Show("请输入药品数量");
                    txtypsl.Focus();
                    return;
                }
                //if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_ypptrk_qc")
                //{

                //}

                #endregion

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				DataRow row=tb.NewRow();
                this.Fillrow(row);
                if (YpClass.FunBase.IsExistsInGrid(new object[] { row["cjid"], row["批次号"] }, tb, new string[] { "cjid", "批次号" }))
                {
                    MessageBox.Show( "添加的药品已经存在，不能重复添加" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }
				if (row["货号"].ToString().Trim()!="") 
				{
					tb.Rows.Add(row);
					this.Sumje();
					this.myDataGrid1.Select(tb.Rows.Count-1);
					this.myDataGrid1.CurrentCell=new DataGridCell(tb.Rows.Count-1,3);
					this.csgroupbox2();
					this.butadd.Enabled=true;
				}

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString());
			}
		}
	
		
		//新单据
		private void butnew_Click(object sender, System.EventArgs e)
		{
			this.csgroupbox1();
			this.csgroupbox2();
			this.FunctionControlEnable(_menuTag.Function_Name.Trim());

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
			this.butsh.Enabled=false;
			this.cmbrckfs.Focus();
		}

	
		//保存事件
		private void butsave_Click(object sender, System.EventArgs e)
		{
			if (Yp.是否药库(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase)==true)
			{
				MessageBox.Show("请核实您当前登陆的科室是否正确","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			long djh=0;
			Guid djid=Guid.Empty;
			int err_code=0;
			string err_text="";
			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
			this.butsave.Enabled=false;

			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			if (tb.Rows.Count==0) {MessageBox.Show("没有可保存的记录");return;};

			//如果是审核入库调用审核事件
//			if (_Sqdh>0)
//			{
//				butsh_Click(sender,e);
//				return;
//			}


			try
			{
				InstanceForm.BDatabase.BeginTransaction();
				string ghdw=this.txtghdw.Tag.ToString();

				//产生单据号
				djh=this.lbldjh.Text.Trim()==""? Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(),InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase):Convert.ToInt64(this.lbldjh.Text);

                //if (this.groupBox1.Tag == null)
                //{ 
                //   djh=Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(),InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                //}
               
				#region 合计金额
				decimal sumjhje=0;
				decimal sumpfje=0;
				decimal sumlsje=0;
				//				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				for( int i=0;i<=tb.Rows.Count-1;i++)
				{
					sumjhje=sumjhje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"],"0"));
					sumpfje=sumpfje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"],"0"));
					sumlsje=sumlsje+Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"],"0"));
				}
				#endregion

				//保存单据表头
                YF_DJ_DJMX.SaveDJ(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())), 
					djh,
					InstanceForm.BCurrentDept.DeptId,
					_menuTag.FunctionTag.Trim(),
					Convert.ToInt32(this.txtghdw.Tag),+
					0,
					this.dtprkrq.Value.ToShortDateString(),
					InstanceForm.BCurrentUser.EmployeeId,
					Convert.ToDateTime(sDate).ToShortDateString(),
					Convert.ToDateTime(sDate).ToLongTimeString(),
					"",
					"",
					this.txtbz.Text.Trim(),
                    "", 0, 0, sumjhje, sumpfje, sumlsje, out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
			
				//如果没有成功，抛出异常
				if (err_code!=0){throw new System.Exception(err_text);}

				//保存单据明细
				
				for(int i=0;i<=tb.Rows.Count-1;i++)
                {
                    string strYppch = "";

                    //进行批次管理 并且是期初入库或者其他入库才生成新的批次号
                    if (_menuTag.Function_Name == "Fun_ts_yf_ypptrk_qtrk" || _menuTag.Function_Name == "Fun_ts_yf_ypptrk_qc")
                    {
                        if (bpcgl)
                        {
                            strYppch = Yp.SeekNewYppch(_menuTag.FunctionTag.Trim(), djh, Convert.ToInt32(tb.Rows[i]["cjid"]), InstanceForm.BDatabase);
                        }
                    }
                    YF_DJ_DJMX.SaveDJMX(new Guid(Convertor.IsNull(tb.Rows[i]["id"], Guid.Empty.ToString())),
						djid,
						Convert.ToInt32(tb.Rows[i]["cjid"]),
						Convert.ToInt32(tb.Rows[i]["kwid"]),
						Convert.ToString(tb.Rows[i]["货号"]),
						Convert.ToString(tb.Rows[i]["品名"]),
						Convert.ToString(tb.Rows[i]["商品名"]),
						Convert.ToString(tb.Rows[i]["规格"]),
						Convert.ToString(tb.Rows[i]["厂家"]),
						Convert.ToString(tb.Rows[i]["批号"]),
						Convert.ToString(tb.Rows[i]["效期"]),
						0,//kl
						0,  
						Convert.ToDecimal(tb.Rows[i]["数量"]),
						Convert.ToString(tb.Rows[i]["单位"]),
                        Yp.SeekYpdw(Convert.ToString(tb.Rows[i]["单位"]), InstanceForm.BDatabase),
						Convert.ToInt32(tb.Rows[i]["dwbl"]),
						Convert.ToDecimal(tb.Rows[i]["进价"]),
						Convert.ToDecimal(tb.Rows[i]["批发价"]),
						Convert.ToDecimal(tb.Rows[i]["零售价"]),
						Convert.ToDecimal(tb.Rows[i]["进货金额"]),
						Convert.ToDecimal(tb.Rows[i]["批发金额"]),
						Convert.ToDecimal(tb.Rows[i]["零售金额"]),
						djh,
						InstanceForm.BCurrentDept.DeptId,
						_menuTag.FunctionTag.Trim(),
						"",
						"",
                        out err_code, out err_text, InstanceForm.BDatabase, i,
                        //tb.Rows[i]["批次号"].ToString(),
                        strYppch,
                        new Guid(tb.Rows[i]["kcid"].ToString()));
					//如果没有成功，抛出异常
					if (err_code!=0){throw new System.Exception(err_text);}
				}


				
				//更新表头的审核标志
				YF_DJ_DJMX.Shdj(djid,
                    sDate, InstanceForm.BDatabase
					);


				//更新库存
				YF_DJ_DJMX.AddUpdateKcmx(
					djid,
                    out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);

				//如果没有成功，抛出异常
				if (err_code!=0){throw new System.Exception(err_text);}
				
				InstanceForm.BDatabase.CommitTransaction();


                this.groupBox1.Tag = djid;
                FillDj(djid, false);
				this.lbldjh.Text=djh.ToString("00000000");
				this.butadd.Enabled=false;
				this.butdel.Enabled=false;
				this.butmodif.Enabled=false;
				this.butprint.Enabled=true;
				MessageBox.Show(err_text);

                

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
			try
			{
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				if (nrow>=tb.Rows.Count) return;
				if(MessageBox.Show("您确定要删除第"+Convert.ToString((nrow+1))+"行吗 ？","询问窗",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					DataRow datarow=tb.Rows[nrow];
                    string ssql = "delete from yf_djmx where id='" + new Guid(Convertor.IsNull(datarow["id"], Guid.Empty.ToString())) + "'";
					InstanceForm.BDatabase.DoCommand(ssql);
					tb.Rows.Remove(datarow);
					this.Sumje();
					this.csgroupbox2();
				}
			
				this.butadd.Enabled=true;
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

	
		//退出
		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	
		//批号按钮事件
		private void butph_Click(object sender, System.EventArgs e)
		{
			int cjid=Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag,"0"));
			string[] GrdMappingName={"行号","库存量","单位","进价","批号","批次号","效期","库位","kwid"};
			int[] GrdWidth={50,80,40,60,75,100,100,100,0};
			string[] sfield={"","","","",""};
			string ssql="select 0   rowno, kcl,dbo.fun_yp_ypdw(zxdw),jhj,ypph,yppch,ypxq,dbo.fun_yp_kwmc(ggid,deptid) kwmc,0 kwid  from yF_kcph  where deptid="+InstanceForm.BCurrentDept.DeptId+" and cjid="+cjid+" and bdelete=0";

            //modify by jchl
            SystemCfg cfg = new SystemCfg(8051);//批号排序及自动分配批号库存规则，0-先进先出 1-按效期先出 
            ssql += cfg.Config.Trim().Equals("0") ? " order by DJSJ asc" : " order by ypxq asc";

            TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, "".Trim(), ssql);
			Point point=new Point(this.Location.X+this.txtph.Location.X,this.Location.Y+this.txtph.Location.Y+this.txtph.Height*3 );
			f2.Location=point;
			f2.ShowDialog(this);
			DataRow row=f2.dataRow;
			if (row!=null) 
			{
				this.txtph.Text=Convert.ToString(row["ypph"]);
				if (row["ypxq"].ToString().Trim()!="") dtpxq.Value=Convert.ToDateTime(row["ypxq"].ToString());
				this.txtkw.Text=row["kwmc"].ToString();
                this.txtkw.Tag = 0;//Convert.ToInt32(Convertor.IsNull(row["kwid"],"0"));
				//进价、进货金额

                if (!btjhj)//如果不调进价
                {
                    int dwbl = Convert.ToInt32(cmbdw.SelectedValue);
                    decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                    decimal jhj = Convert.ToDecimal(Convertor.IsNull(row["jhj"], "0")) / dwbl;
                    jhj = Convert.ToDecimal(jhj.ToString("0.0000"));
                    this.lbljhj.Text = jhj.ToString("0.0000");
                    this.lbljhj.Tag = jhj.ToString("0.0000");
                }
				this.txtkw.Focus();
			}
		}


		//修改按钮事件
		private void butmodif_Click(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				if (nrow>tb.Rows.Count-1) return;
				DataRow row=tb.Rows[nrow];
				this.Fillrow(row);
				if (row["货号"].ToString().Trim()!="") 
				{
					this.Sumje();
					DataRow nullrow=tb.NewRow();
					this.Getrow(nullrow);
					this.butadd.Enabled=true;
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message );
			}
		}

	
		//审核事件
        private void butsh_Click(object sender, System.EventArgs e)
        {
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(); ;
            int err_code = 0;
            string err_text = "";
            Guid djid = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));
            this.butsh.Enabled = false;
            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                YF_DJ_DJMX.Shdj(djid, sDate, InstanceForm.BDatabase);

                YF_DJ_DJMX.AddUpdateKcmx(djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);

                if (err_code != 0)
                { throw new System.Exception(err_text); }
                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("审核成功");
                this.butprint.Enabled = true;
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butsh.Enabled = true;
                MessageBox.Show(err.Message + err.Source);
            }
        }

		//丢失焦点事件
		private void txtkw_LostFocus(object sender, EventArgs e)
		{
			//txtkw.Text=BaseFun.SeekKwmc(Convert.ToInt64(Convertor.IsNull(txtkw.Tag,"0")),InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
		}


		#endregion

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string ghdw="";
				string rq="";
                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_ypptrk_qc")
                {
                    ghdw = "";
                    rq = "单据日期:" + dtprkrq.Value.ToShortDateString();
                }
                else
                {
                    ghdw ="往来单位:"+ txtghdw.Text.Trim();
                    rq = "单据日期:" + dtprkrq.Value.ToShortDateString();
                }

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.普通入库单.NewRow();
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
					myrow["plce"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批零差额"],"0"));

					myrow["jhj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"));
					myrow["jhje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"],"0"));
					decimal jlce=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"],"0"))-Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"],"0"));
					myrow["jlce"]=jlce.ToString("0.00");

					myrow["ypph"]=Convert.ToString(tb.Rows[i]["批号"]);
					myrow["ypxq"]=Convert.ToString(tb.Rows[i]["效期"]);
					myrow["shh"]=Convert.ToString(tb.Rows[i]["货号"]);
					myrow["kwmc"]=Convert.ToString(tb.Rows[i]["库位"]);
					Dset.普通入库单.Rows.Add(myrow);

				}

                string djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from vi_yf_dj where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();

				ParameterEx[] parameters=new ParameterEx[7];
				parameters[0].Text="DJH";
				parameters[0].Value=this.lbldjh.Text;
				parameters[1].Text="DJY";
                parameters[1].Value = djy + "                                 打印员:" + InstanceForm.BCurrentUser.Name;
				parameters[2].Text="GHDW";
				parameters[2].Value=ghdw.Trim();
				parameters[3].Text="RQ";
				parameters[3].Value=rq.Trim();
				parameters[4].Text="TITLETEXT";
				parameters[4].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+_menuTag.MenuName;
				parameters[5].Text="BZ";
				parameters[5].Value=txtbz.Text.Trim();
				parameters[6].Text="ybps";
				parameters[6].Value=cmbrckfs.Text.Trim()=="是"?"医保配送":"";

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.普通入库单,Constant.ApplicationDirectory+"\\Report\\YF_普通入库单.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
            if (MessageBox.Show("[初始化库存] 相当于从药品词典中导入药品进行大批量的入库,主要用于测试.系统正式启用后请慎用!您要这样做吗?", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            string ssql = "";
            if (btjhj)
            {
                 ssql = "select 0   序号,yppm 品名,ypspm 商品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家,'无批号' 批号,'2099-1-1' 效期,''库位," +
                                  " pfj 批发价,lsj 零售价,0 申请量,1000 数量,dbo.fun_yp_ypdw(ypdw) 单位," +
                                  " pfj*1000 批发金额,lsj*1000 零售金额,(lsj*1000-pfj*1000) 批零差额,mrjj 进价,mrjj*1000 进货金额,shh 货号," +
                                  @" cjid,1 dwbl,0 kwid,dbo.FUN_GETEMPTYGUID() id,dbo.FUN_GETEMPTYGUID() kcid,'' 批次号 from vi_yp_ypcd where cjbdelete=0 and 
                ypdw>0 and ypzlx in(select ypzlx from yp_gllx where deptid=" + InstanceForm.BCurrentDept.DeptId + ")  ";
            }
            else
            {
                 ssql = "select 0   序号,yppm 品名,ypspm 商品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家,'无批号' 批号,'2099-1-1' 效期,''库位," +
                    " pfj 批发价,lsj 零售价,0 申请量,1000 数量,dbo.fun_yp_ypdw(ypdw) 单位," +
                    " pfj*1000 批发金额,lsj*1000 零售金额,(lsj*1000-pfj*1000) 批零差额,0 进价,0 进货金额,shh 货号," +
                    @" cjid,1 dwbl,0 kwid,dbo.FUN_GETEMPTYGUID() id,dbo.FUN_GETEMPTYGUID() kcid,'' 批次号 from vi_yp_ypcd where cjbdelete=0 and 
                ypdw>0 and ypzlx in(select ypzlx from yp_gllx where deptid=" + InstanceForm.BCurrentDept.DeptId + ")  ";
            }
            //门诊西药房
            //string ssql = "select 0   序号,yppm 品名,ypspm 商品名,ypgg 规格,trasen.dbo.fun_yp_sccj(sccj) 厂家,'无批号' 批号,'1900-01-01' 效期,''库位," +
            //    "round(pfj/n_dwbl,4) 批发价,round(lsj/n_dwbl,4) 零售价,0 申请量,n_kcl 数量,s_zxdw 单位," +
            //    "round(pfj*n_kcl/n_dwbl,3) 批发金额,round(lsj*n_kcl/n_dwbl,3) 零售金额,(lsj*n_kcl/n_dwbl-pfj*n_kcl/n_dwbl) 批零差额,0 进价,0 进货金额,shh 货号," +
            //    "a.cjid,n_dwbl dwbl,0 kwid,0 id from trasen.dbo.vi_yp_ypcd a,mthis.dbo.mzyf_kcmx b where  a.shh=b.s_hh";
            //门诊中药房
            //string ssql = "select 0   序号,yppm 品名,ypspm 商品名,ypgg 规格,trasen.dbo.fun_yp_sccj(sccj) 厂家,'无批号' 批号,'1900-01-01' 效期,''库位," +
            //    "round(pfj/n_dwbl,4) 批发价,round(lsj/n_dwbl,4) 零售价,0 申请量,n_kcl 数量,s_zxdw 单位," +
            //    "round(pfj*n_kcl/n_dwbl,3) 批发金额,round(lsj*n_kcl/n_dwbl,3) 零售金额,(lsj*n_kcl/n_dwbl-pfj*n_kcl/n_dwbl) 批零差额,0 进价,0 进货金额,shh 货号," +
            //    "a.cjid,n_dwbl dwbl,0 kwid,0 id from trasen.dbo.vi_yp_ypcd a,mthis.dbo.mzzyf_kcmx b where  a.shh=b.s_hh";
            ////中心西药房
            //string ssql = "select 0   序号,yppm 品名,ypspm 商品名,ypgg 规格,trasen.dbo.fun_yp_sccj(sccj) 厂家,'无批号' 批号,'1900-01-01' 效期,''库位," +
            //    "round(pfj/n_dwbl,4) 批发价,round(lsj/n_dwbl,4) 零售价,0 申请量,n_kcl 数量,s_zxdw 单位," +
            //    "round(pfj*n_kcl/n_dwbl,3) 批发金额,round(lsj*n_kcl/n_dwbl,3) 零售金额,(lsj*n_kcl/n_dwbl-pfj*n_kcl/n_dwbl) 批零差额,0 进价,0 进货金额,shh 货号," +
            //    "a.cjid,n_dwbl dwbl,0 kwid,0 id from trasen.dbo.vi_yp_ypcd a,hisdata.dbo.zxyf_kcmx b where  a.shh=b.s_hh";
            ////中心中药房
            //string ssql = "select 0   序号,yppm 品名,ypspm 商品名,ypgg 规格,trasen.dbo.fun_yp_sccj(sccj) 厂家,'无批号' 批号,'1900-01-01' 效期,''库位," +
            //    "round(pfj/n_dwbl,4) 批发价,round(lsj/n_dwbl,4) 零售价,0 申请量,n_kcl 数量,s_zxdw 单位," +
            //    "round(pfj*n_kcl/n_dwbl,3) 批发金额,round(lsj*n_kcl/n_dwbl,3) 零售金额,(lsj*n_kcl/n_dwbl-pfj*n_kcl/n_dwbl) 批零差额,0 进价,0 进货金额,shh 货号," +
            //    "a.cjid,n_dwbl dwbl,0 kwid,0 id from trasen.dbo.vi_yp_ypcd a,hisdata.dbo.zyzyf_kcmx b where  a.shh=b.s_hh";
            
            DataTable tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
			tbmx.TableName="tbmx";
			this.myDataGrid1.DataSource=tbmx;
			this.myDataGrid1.TableStyles[0].MappingName ="tbmx";
			this.Sumje();

			#region 重新计算库存数
			//			OleDbTransaction myTrans;
			//			myTrans =DB.sConnect.BeginTransaction();
			//
			//			try
			//			{
			//				System.Data.OleDb.OleDbCommand  cmd=new System.Data.OleDb.OleDbCommand();
			//				cmd.Connection=DB.sConnect;
			//				cmd.Transaction=myTrans;
			//				string ssql="SELECT c.cjid,"+
			//					" sum(case when a.ywlx='005' then 0 else FUN_Yf_DATADRTION(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ypsl "+
			//					" FROM YF_DJ A,YF_DJMX B,YF_KCPH c WHERE a.id=b.djid AND b.cjid=c.cjid and a.deptid=c.deptid and "+
			//					" A.DEPTID=1154 "+
			//					" and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002'))) group by c.cjid";
			//				DataTable tb=BaseFun.ExecsqlTable(ssql,cmd);
			//				for(int i=0;i<=tb.Rows.Count-1;i++)
			//				{
			//					ssql="update yf_kcmx set kcl="+Convert.ToDecimal(tb.Rows[i]["ypsl"])+" where cjid="+Convert.ToInt32(tb.Rows[i]["cjid"])+" and deptid=1154";
			//					cmd.CommandText=ssql;
			//					cmd.ExecuteNonQuery();
			//					ssql="update yf_kcph set kcl="+Convert.ToDecimal(tb.Rows[i]["ypsl"])+" where cjid="+Convert.ToInt32(tb.Rows[i]["cjid"])+" and deptid=1154";
			//					cmd.CommandText=ssql;
			//					cmd.ExecuteNonQuery();
			//					this.Text=i.ToString();
			//				}
			//				myTrans.Commit();
			//			}
			//			catch(System.Exception err)
			//			{
			//				myTrans.Rollback();
			//				MessageBox.Show(err.Message);
			//			}

			//		}
			#endregion
		}

		private void lbljhj_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			try
			{
				if (nkey!=13)
				{
					if (Convertor.IsNumeric(this.lbljhj.Text)==false) lbljhj.Text="";
					if (nkey!=13  && lbljhj.Text.Trim()!="-" && lbljhj.Text.Trim()!=".")
					{
						decimal jhje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text,"0"));
						this.lbljhje.Text=jhje.ToString("0.00");
                        this.lbljhj.Tag = Convertor.IsNull(this.lbljhj.Text, "0");
					}
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void lbljhje_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			try
			{
				if (Convertor.IsNumeric(this.lbljhje.Text)==false) lbljhje.Text="";
				if (Convertor.IsNull(lbljhje.Text.Trim(),"0")=="0"){lbljhj.Text="0";}
				if (nkey!=13 && Convertor.IsNull(txtypsl.Text.Trim(),"0")!="0" && lbljhje.Text.Trim()!="-" && lbljhje.Text.Trim()!=".")
				{
					decimal jj=Convert.ToDecimal(Convertor.IsNull(this.lbljhje.Text,"0"))/Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"));
					this.lbljhj.Text=jj.ToString("0.000");
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void chkjj_CheckedChanged(object sender, System.EventArgs e)
		{
			this.lbljhj.Enabled=this.chkjj.Checked==true?true:false;
			this.lbljhje.Enabled=this.chkjj.Checked==true?true:false;
		}


	}
}
