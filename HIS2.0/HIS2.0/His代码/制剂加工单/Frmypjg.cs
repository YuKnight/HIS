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
//using ts_Yk_ReportView;
using TrasenClasses.DatabaseAccess;
using System.Collections.Generic;
namespace ts_yk_zjjgd
{
	/// <summary>
    /// Frmypjg 加工
	/// </summary>
	public class Frmypjg : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label 登记日期;
		private System.Windows.Forms.DateTimePicker dtpdjrq;
		private System.Windows.Forms.TextBox txtbz;
		private System.Windows.Forms.Button butmodif;
		private System.Windows.Forms.Button butdel;
		private System.Windows.Forms.Button butadd;
        private System.Windows.Forms.Label lblkc;
        private System.Windows.Forms.Button butph;
        private System.Windows.Forms.TextBox txtph;
		private System.Windows.Forms.TextBox txtjhsl;
		private System.Windows.Forms.Label lblscjj;
		private System.Windows.Forms.Label lbllsj;
        private System.Windows.Forms.ComboBox cmbdw;
		private System.Windows.Forms.Label lblypmc;
		private System.Windows.Forms.Label lblcj;
		private System.Windows.Forms.Label lblgg;
		private System.Windows.Forms.TextBox txtypdm;
		private System.Windows.Forms.Button butclose;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.Button butnew;
        private System.Windows.Forms.Button butsh;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
        private System.Windows.Forms.Label lblpm;
		private Guid _id=Guid.Empty;
		private YpConfig ss;
        private System.Windows.Forms.TextBox lblpfj;
        private ComboBox cmbck;
        private Label label3;
        private TextBox txtcpsl;
        private Label label1;
        private DateTimePicker dtpshrq;
        private Label 审核日期;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlYpxx;
        private Trasen.Controls.DataGridView dgYlmx;
        private Panel panel3;
        private Trasen.Controls.DataGridView dgjhmx;
        private Label label5;
        private Label lblsumcplsje;
        private Label lblcpls;
        private Label lblsumcppfje;
        private Label lblcppf;
        private Label lblsumcpjhje;
        private Label lblcpjh;
        private Label lblsumcpcbje;
        private Label lblcpcb;
        private Label label4;
        private Label lblyl;
        private Label lblcp;
        private Label lblsumyllsje;
        private Label lblylls;
        private Label lblsumylpfje;
        private Label lblylpf;
        private Label lblsumyljhje;
        private Label lblyljh;
        private DateTimePicker dtpxq;
        private Label label2;
        private DataGridViewTextBoxColumn cyppm;
        private DataGridViewTextBoxColumn cypgg;
        private DataGridViewTextBoxColumn csccj;
        private DataGridViewTextBoxColumn cjhj;
        private DataGridViewTextBoxColumn cpfj;
        private DataGridViewTextBoxColumn clsj;
        private DataGridViewTextBoxColumn cypdw;
        private DataGridViewTextBoxColumn cnypdw;
        private DataGridViewTextBoxColumn cydwbl;
        private DataGridViewTextBoxColumn csl;
        private DataGridViewButtonColumn cjsph;
        private DataGridViewTextBoxColumn cph;
        private DataGridViewTextBoxColumn cxq;
        private DataGridViewTextBoxColumn ckcl;
        private DataGridViewTextBoxColumn cid;
        private DataGridViewTextBoxColumn cdjid;
        private DataGridViewTextBoxColumn cdjh;
        private DataGridViewTextBoxColumn ccjid;
        private DataGridViewTextBoxColumn cpxxh;
        private DataGridViewLinkColumn c删除;
        private DataGridViewTextBoxColumn cjhje;
        private DataGridViewTextBoxColumn cpfje;
        private DataGridViewTextBoxColumn clsje;
        private DataGridViewTextBoxColumn cjhmxid;
        private DataGridViewTextBoxColumn cckmxid;
        private DataGridViewTextBoxColumn col_yppm;
        private DataGridViewTextBoxColumn col_ypgg;
        private DataGridViewTextBoxColumn col_sccj;
        private DataGridViewTextBoxColumn col_ypdw;
        private DataGridViewTextBoxColumn col_nypdw;
        private DataGridViewTextBoxColumn col_ydwbl;
        private DataGridViewTextBoxColumn col_jhsl;
        private DataGridViewTextBoxColumn col_cpsl;
        private DataGridViewTextBoxColumn col_cpl;
        private DataGridViewTextBoxColumn col_cpl1;
        private DataGridViewTextBoxColumn col_cbj;
        private DataGridViewTextBoxColumn col_jhj;
        private DataGridViewTextBoxColumn col_pfj;
        private DataGridViewTextBoxColumn col_lsj;
        private DataGridViewButtonColumn col_jsph;
        private DataGridViewTextBoxColumn col_ph;
        private DataGridViewTextBoxColumn col_xq;
        private DataGridViewTextBoxColumn col_pxxh;
        private DataGridViewLinkColumn col_删除;
        private DataGridViewLinkColumn col_添加原料;
        private DataGridViewTextBoxColumn colcbje;
        private DataGridViewTextBoxColumn coljhje;
        private DataGridViewTextBoxColumn colpfje;
        private DataGridViewTextBoxColumn collsje;
        private DataGridViewTextBoxColumn col_id;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn col_rkdjmxid;
       
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmypjg));
            Trasen.Controls.ShowCardProperty showCardProperty1 = new Trasen.Controls.ShowCardProperty();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            Trasen.Controls.ShowCardProperty showCardProperty2 = new Trasen.Controls.ShowCardProperty();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpshrq = new System.Windows.Forms.DateTimePicker();
            this.审核日期 = new System.Windows.Forms.Label();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpdjrq = new System.Windows.Forms.DateTimePicker();
            this.登记日期 = new System.Windows.Forms.Label();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.txtcpsl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblpfj = new System.Windows.Forms.TextBox();
            this.lblypmc = new System.Windows.Forms.Label();
            this.lblpm = new System.Windows.Forms.Label();
            this.butmodif = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butadd = new System.Windows.Forms.Button();
            this.lblkc = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.butph = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.txtph = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtjhsl = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lblscjj = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbllsj = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbdw = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblcj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblgg = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtypdm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgYlmx = new Trasen.Controls.DataGridView();
            this.cyppm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cypgg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csccj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cjhj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpfj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cypdw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnypdw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cydwbl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cjsph = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cxq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckcl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdjid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdjh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccjid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpxxh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c删除 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cjhje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpfje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cjhmxid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cckmxid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlYpxx = new System.Windows.Forms.Panel();
            this.dtpxq = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgjhmx = new Trasen.Controls.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblcpcb = new System.Windows.Forms.Label();
            this.lblyl = new System.Windows.Forms.Label();
            this.lblcp = new System.Windows.Forms.Label();
            this.lblsumcpcbje = new System.Windows.Forms.Label();
            this.lblsumyllsje = new System.Windows.Forms.Label();
            this.lblylls = new System.Windows.Forms.Label();
            this.lblsumylpfje = new System.Windows.Forms.Label();
            this.lblylpf = new System.Windows.Forms.Label();
            this.lblsumyljhje = new System.Windows.Forms.Label();
            this.lblyljh = new System.Windows.Forms.Label();
            this.lblsumcplsje = new System.Windows.Forms.Label();
            this.lblcpls = new System.Windows.Forms.Label();
            this.lblsumcppfje = new System.Windows.Forms.Label();
            this.lblcppf = new System.Windows.Forms.Label();
            this.lblsumcpjhje = new System.Windows.Forms.Label();
            this.lblcpjh = new System.Windows.Forms.Label();
            this.butsh = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.col_yppm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ypgg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sccj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ypdw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nypdw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ydwbl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jhsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cpsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cpl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cpl1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cbj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jhj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pfj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jsph = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_ph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pxxh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_删除 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_添加原料 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colcbje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coljhje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpfje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collsje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rkdjmxid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgYlmx)).BeginInit();
            this.pnlYpxx.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgjhmx)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpshrq);
            this.groupBox1.Controls.Add(this.审核日期);
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpdjrq);
            this.groupBox1.Controls.Add(this.登记日期);
            this.groupBox1.Controls.Add(this.txtbz);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1370, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(576, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "计划备注";
            // 
            // dtpshrq
            // 
            this.dtpshrq.Enabled = false;
            this.dtpshrq.Location = new System.Drawing.Point(439, 19);
            this.dtpshrq.Name = "dtpshrq";
            this.dtpshrq.Size = new System.Drawing.Size(128, 21);
            this.dtpshrq.TabIndex = 22;
            // 
            // 审核日期
            // 
            this.审核日期.AutoSize = true;
            this.审核日期.Location = new System.Drawing.Point(383, 23);
            this.审核日期.Name = "审核日期";
            this.审核日期.Size = new System.Drawing.Size(53, 12);
            this.审核日期.TabIndex = 23;
            this.审核日期.Text = "审核日期";
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbck.Location = new System.Drawing.Point(64, 19);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(112, 20);
            this.cmbck.TabIndex = 0;
            this.cmbck.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "仓库名称";
            // 
            // dtpdjrq
            // 
            this.dtpdjrq.Enabled = false;
            this.dtpdjrq.Location = new System.Drawing.Point(243, 19);
            this.dtpdjrq.Name = "dtpdjrq";
            this.dtpdjrq.Size = new System.Drawing.Size(128, 21);
            this.dtpdjrq.TabIndex = 3;
            this.dtpdjrq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // 登记日期
            // 
            this.登记日期.AutoSize = true;
            this.登记日期.Location = new System.Drawing.Point(187, 23);
            this.登记日期.Name = "登记日期";
            this.登记日期.Size = new System.Drawing.Size(53, 12);
            this.登记日期.TabIndex = 4;
            this.登记日期.Text = "登记日期";
            // 
            // txtbz
            // 
            this.txtbz.ForeColor = System.Drawing.Color.Navy;
            this.txtbz.Location = new System.Drawing.Point(633, 19);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(633, 21);
            this.txtbz.TabIndex = 1;
            this.txtbz.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtcpsl
            // 
            this.txtcpsl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcpsl.ForeColor = System.Drawing.Color.Navy;
            this.txtcpsl.Location = new System.Drawing.Point(207, 26);
            this.txtcpsl.Name = "txtcpsl";
            this.txtcpsl.Size = new System.Drawing.Size(88, 21);
            this.txtcpsl.TabIndex = 11;
            this.txtcpsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 94;
            this.label1.Text = "成品数量";
            // 
            // lblpfj
            // 
            this.lblpfj.Enabled = false;
            this.lblpfj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfj.Location = new System.Drawing.Point(959, 4);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.ReadOnly = true;
            this.lblpfj.Size = new System.Drawing.Size(80, 21);
            this.lblpfj.TabIndex = 92;
            this.lblpfj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblypmc
            // 
            this.lblypmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblypmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblypmc.ForeColor = System.Drawing.Color.Navy;
            this.lblypmc.Location = new System.Drawing.Point(341, 4);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(121, 20);
            this.lblypmc.TabIndex = 21;
            // 
            // lblpm
            // 
            this.lblpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpm.ForeColor = System.Drawing.Color.Navy;
            this.lblpm.Location = new System.Drawing.Point(181, 4);
            this.lblpm.Name = "lblpm";
            this.lblpm.Size = new System.Drawing.Size(159, 20);
            this.lblpm.TabIndex = 91;
            // 
            // butmodif
            // 
            this.butmodif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butmodif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butmodif.Location = new System.Drawing.Point(713, 26);
            this.butmodif.Name = "butmodif";
            this.butmodif.Size = new System.Drawing.Size(64, 20);
            this.butmodif.TabIndex = 18;
            this.butmodif.Text = "修改(&M)";
            this.butmodif.Click += new System.EventHandler(this.butmodif_Click);
            // 
            // butdel
            // 
            this.butdel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butdel.Location = new System.Drawing.Point(782, 26);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(64, 20);
            this.butdel.TabIndex = 17;
            this.butdel.Text = "删除(&D)";
            this.butdel.Visible = false;
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butadd
            // 
            this.butadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butadd.Location = new System.Drawing.Point(644, 26);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(64, 20);
            this.butadd.TabIndex = 16;
            this.butadd.Text = "添加(&A)";
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            // 
            // lblkc
            // 
            this.lblkc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkc.ForeColor = System.Drawing.Color.Navy;
            this.lblkc.Location = new System.Drawing.Point(709, 4);
            this.lblkc.Name = "lblkc";
            this.lblkc.Size = new System.Drawing.Size(69, 20);
            this.lblkc.TabIndex = 51;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(677, 8);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(29, 12);
            this.label36.TabIndex = 50;
            this.label36.Text = "库存";
            // 
            // butph
            // 
            this.butph.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butph.Location = new System.Drawing.Point(417, 26);
            this.butph.Name = "butph";
            this.butph.Size = new System.Drawing.Size(25, 21);
            this.butph.TabIndex = 44;
            this.butph.Text = "F1";
            this.butph.Click += new System.EventHandler(this.butph_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(446, 30);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 40;
            this.label30.Text = "有效日期";
            // 
            // txtph
            // 
            this.txtph.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtph.ForeColor = System.Drawing.Color.Navy;
            this.txtph.Location = new System.Drawing.Point(334, 26);
            this.txtph.Name = "txtph";
            this.txtph.Size = new System.Drawing.Size(80, 21);
            this.txtph.TabIndex = 13;
            this.txtph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(302, 30);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 12);
            this.label29.TabIndex = 38;
            this.label29.Text = "批号";
            // 
            // txtjhsl
            // 
            this.txtjhsl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjhsl.ForeColor = System.Drawing.Color.Navy;
            this.txtjhsl.Location = new System.Drawing.Point(58, 26);
            this.txtjhsl.Name = "txtjhsl";
            this.txtjhsl.Size = new System.Drawing.Size(87, 21);
            this.txtjhsl.TabIndex = 9;
            this.txtjhsl.Leave += new System.EventHandler(this.txtjhsl_Leave);
            this.txtjhsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(3, 30);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 32;
            this.label26.Text = "计划数量";
            // 
            // lblscjj
            // 
            this.lblscjj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblscjj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblscjj.ForeColor = System.Drawing.Color.Navy;
            this.lblscjj.Location = new System.Drawing.Point(1235, 4);
            this.lblscjj.Name = "lblscjj";
            this.lblscjj.Size = new System.Drawing.Size(80, 20);
            this.lblscjj.TabIndex = 31;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(1179, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 30;
            this.label25.Text = "上次进价";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(1094, 4);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(80, 20);
            this.lbllsj.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(1046, 8);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 28;
            this.label23.Text = "零售价";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(917, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 26;
            this.label20.Text = "批发价";
            // 
            // cmbdw
            // 
            this.cmbdw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdw.Enabled = false;
            this.cmbdw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbdw.ForeColor = System.Drawing.Color.Navy;
            this.cmbdw.Location = new System.Drawing.Point(822, 4);
            this.cmbdw.Name = "cmbdw";
            this.cmbdw.Size = new System.Drawing.Size(86, 20);
            this.cmbdw.TabIndex = 88;
            this.cmbdw.SelectedIndexChanged += new System.EventHandler(this.cmbdw_SelectedIndexChanged);
            this.cmbdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(790, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 24;
            this.label19.Text = "单位";
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(619, 5);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(49, 19);
            this.lblcj.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(587, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 18;
            this.label14.Text = "厂家";
            // 
            // lblgg
            // 
            this.lblgg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblgg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgg.ForeColor = System.Drawing.Color.Navy;
            this.lblgg.Location = new System.Drawing.Point(501, 5);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(80, 19);
            this.lblgg.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(469, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "规格";
            // 
            // txtypdm
            // 
            this.txtypdm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtypdm.ForeColor = System.Drawing.Color.Navy;
            this.txtypdm.Location = new System.Drawing.Point(58, 4);
            this.txtypdm.Name = "txtypdm";
            this.txtypdm.Size = new System.Drawing.Size(86, 21);
            this.txtypdm.TabIndex = 7;
            this.txtypdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtypdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "药品代码";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(149, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 20;
            this.label16.Text = "品名";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1370, 696);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1364, 633);
            this.panel2.TabIndex = 62;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgYlmx, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pnlYpxx, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1364, 633);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgYlmx
            // 
            this.dgYlmx.AllowColumnSort = false;
            this.dgYlmx.AllowUserToAddRows = false;
            this.dgYlmx.AllowUserToDeleteRows = false;
            this.dgYlmx.BackgroundColor = System.Drawing.Color.White;
            this.dgYlmx.ColumnDeep = 1;
            this.dgYlmx.ColumnHeadersHeight = 17;
            this.dgYlmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgYlmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cyppm,
            this.cypgg,
            this.csccj,
            this.cjhj,
            this.cpfj,
            this.clsj,
            this.cypdw,
            this.cnypdw,
            this.cydwbl,
            this.csl,
            this.cjsph,
            this.cph,
            this.cxq,
            this.ckcl,
            this.cid,
            this.cdjid,
            this.cdjh,
            this.ccjid,
            this.cpxxh,
            this.c删除,
            this.cjhje,
            this.cpfje,
            this.clsje,
            this.cjhmxid,
            this.cckmxid});
            this.dgYlmx.DisplayShowCardWhenCellInEdit = false;
            this.dgYlmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgYlmx.Location = new System.Drawing.Point(3, 348);
            this.dgYlmx.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgYlmx.MergeColumnNames")));
            this.dgYlmx.Name = "dgYlmx";
            this.dgYlmx.RowHeadersWidth = 31;
            this.dgYlmx.RowTemplate.Height = 23;
            this.dgYlmx.ShowCardComponent = null;
            showCardProperty1.AllowCustomInputWhenNoneSelectedRow = false;
            showCardProperty1.BindColumnName = "cyppm";
            showCardProperty1.ColumnHeaderVisible = true;
            showCardProperty1.DbConnection = null;
            showCardProperty1.RealTimeQuery = false;
            showCardProperty1.RowHeaderVisible = true;
            showCardProperty1.ShowCardColumns = new Trasen.Controls.ShowCardColumn[0];
            showCardProperty1.ShowCardDataSource = null;
            showCardProperty1.ShowCardDataSourceSqlString = null;
            showCardProperty1.ShowCardSize = new System.Drawing.Size(650, 0);
            this.dgYlmx.ShowCardProperty = new Trasen.Controls.ShowCardProperty[] {
        showCardProperty1};
            this.dgYlmx.Size = new System.Drawing.Size(1358, 282);
            this.dgYlmx.TabIndex = 6;
            this.dgYlmx.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgYlmx_CellEndEdit);
            this.dgYlmx.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgYlmx_CellClick);
            this.dgYlmx.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgYlmx_CellContentClick);
            // 
            // cyppm
            // 
            this.cyppm.DataPropertyName = "yppm";
            this.cyppm.HeaderText = "品名";
            this.cyppm.Name = "cyppm";
            this.cyppm.ReadOnly = true;
            this.cyppm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cyppm.Width = 180;
            // 
            // cypgg
            // 
            this.cypgg.DataPropertyName = "ypgg";
            this.cypgg.HeaderText = "规格";
            this.cypgg.Name = "cypgg";
            this.cypgg.ReadOnly = true;
            this.cypgg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cypgg.Width = 120;
            // 
            // csccj
            // 
            this.csccj.DataPropertyName = "sccj";
            this.csccj.HeaderText = "厂家";
            this.csccj.Name = "csccj";
            this.csccj.ReadOnly = true;
            this.csccj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cjhj
            // 
            this.cjhj.DataPropertyName = "jhj";
            this.cjhj.HeaderText = "进货价";
            this.cjhj.Name = "cjhj";
            this.cjhj.ReadOnly = true;
            this.cjhj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cjhj.Visible = false;
            this.cjhj.Width = 60;
            // 
            // cpfj
            // 
            this.cpfj.DataPropertyName = "pfj";
            this.cpfj.HeaderText = "批发价";
            this.cpfj.Name = "cpfj";
            this.cpfj.ReadOnly = true;
            this.cpfj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cpfj.Width = 60;
            // 
            // clsj
            // 
            this.clsj.DataPropertyName = "lsj";
            this.clsj.HeaderText = "零售价";
            this.clsj.Name = "clsj";
            this.clsj.ReadOnly = true;
            this.clsj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clsj.Width = 60;
            // 
            // cypdw
            // 
            this.cypdw.DataPropertyName = "ypdw";
            this.cypdw.HeaderText = "单位";
            this.cypdw.Name = "cypdw";
            this.cypdw.ReadOnly = true;
            this.cypdw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cypdw.Width = 45;
            // 
            // cnypdw
            // 
            this.cnypdw.DataPropertyName = "nypdw";
            this.cnypdw.HeaderText = "nypdw";
            this.cnypdw.Name = "cnypdw";
            this.cnypdw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cnypdw.Visible = false;
            // 
            // cydwbl
            // 
            this.cydwbl.DataPropertyName = "ydwbl";
            this.cydwbl.HeaderText = "ydwbl";
            this.cydwbl.Name = "cydwbl";
            this.cydwbl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cydwbl.Visible = false;
            // 
            // csl
            // 
            this.csl.DataPropertyName = "sl";
            this.csl.HeaderText = "数量";
            this.csl.Name = "csl";
            this.csl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.csl.Width = 60;
            // 
            // cjsph
            // 
            this.cjsph.DataPropertyName = "jsph";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cjsph.DefaultCellStyle = dataGridViewCellStyle1;
            this.cjsph.HeaderText = "F";
            this.cjsph.Name = "cjsph";
            this.cjsph.Text = "F";
            this.cjsph.Width = 25;
            // 
            // cph
            // 
            this.cph.DataPropertyName = "ph";
            this.cph.HeaderText = "批号";
            this.cph.Name = "cph";
            this.cph.ReadOnly = true;
            this.cph.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cph.Width = 80;
            // 
            // cxq
            // 
            this.cxq.DataPropertyName = "xq";
            this.cxq.HeaderText = "效期";
            this.cxq.Name = "cxq";
            this.cxq.ReadOnly = true;
            this.cxq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cxq.Width = 80;
            // 
            // ckcl
            // 
            this.ckcl.DataPropertyName = "kcl";
            this.ckcl.HeaderText = "库存量";
            this.ckcl.Name = "ckcl";
            this.ckcl.ReadOnly = true;
            this.ckcl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ckcl.Width = 60;
            // 
            // cid
            // 
            this.cid.DataPropertyName = "id";
            this.cid.HeaderText = "id";
            this.cid.Name = "cid";
            this.cid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cid.Visible = false;
            // 
            // cdjid
            // 
            this.cdjid.DataPropertyName = "djid";
            this.cdjid.HeaderText = "djid";
            this.cdjid.Name = "cdjid";
            this.cdjid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cdjid.Visible = false;
            // 
            // cdjh
            // 
            this.cdjh.DataPropertyName = "djh";
            this.cdjh.HeaderText = "djh";
            this.cdjh.Name = "cdjh";
            this.cdjh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cdjh.Visible = false;
            // 
            // ccjid
            // 
            this.ccjid.DataPropertyName = "cjid";
            this.ccjid.HeaderText = "cjid";
            this.ccjid.Name = "ccjid";
            this.ccjid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ccjid.Visible = false;
            // 
            // cpxxh
            // 
            this.cpxxh.DataPropertyName = "pxxh";
            this.cpxxh.HeaderText = "序号";
            this.cpxxh.Name = "cpxxh";
            this.cpxxh.ReadOnly = true;
            this.cpxxh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cpxxh.Width = 40;
            // 
            // c删除
            // 
            this.c删除.DataPropertyName = "删除";
            this.c删除.HeaderText = "删除";
            this.c删除.Name = "c删除";
            this.c删除.Text = "删除";
            this.c删除.Width = 45;
            // 
            // cjhje
            // 
            this.cjhje.DataPropertyName = "jhje";
            this.cjhje.HeaderText = "进货金额";
            this.cjhje.Name = "cjhje";
            this.cjhje.ReadOnly = true;
            this.cjhje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cjhje.Width = 80;
            // 
            // cpfje
            // 
            this.cpfje.DataPropertyName = "pfje";
            this.cpfje.HeaderText = "批发金额";
            this.cpfje.Name = "cpfje";
            this.cpfje.ReadOnly = true;
            this.cpfje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cpfje.Width = 80;
            // 
            // clsje
            // 
            this.clsje.DataPropertyName = "lsje";
            this.clsje.HeaderText = "零售金额";
            this.clsje.Name = "clsje";
            this.clsje.ReadOnly = true;
            this.clsje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clsje.Width = 80;
            // 
            // cjhmxid
            // 
            this.cjhmxid.DataPropertyName = "jhmxid";
            this.cjhmxid.HeaderText = "jhmxid";
            this.cjhmxid.Name = "cjhmxid";
            this.cjhmxid.ReadOnly = true;
            this.cjhmxid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cjhmxid.Visible = false;
            // 
            // cckmxid
            // 
            this.cckmxid.DataPropertyName = "ckmxid";
            this.cckmxid.HeaderText = "ckmxid";
            this.cckmxid.Name = "cckmxid";
            this.cckmxid.ReadOnly = true;
            this.cckmxid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cckmxid.Visible = false;
            // 
            // pnlYpxx
            // 
            this.pnlYpxx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlYpxx.Controls.Add(this.dtpxq);
            this.pnlYpxx.Controls.Add(this.label5);
            this.pnlYpxx.Controls.Add(this.lblkc);
            this.pnlYpxx.Controls.Add(this.txtcpsl);
            this.pnlYpxx.Controls.Add(this.label16);
            this.pnlYpxx.Controls.Add(this.label1);
            this.pnlYpxx.Controls.Add(this.label10);
            this.pnlYpxx.Controls.Add(this.lblpfj);
            this.pnlYpxx.Controls.Add(this.label12);
            this.pnlYpxx.Controls.Add(this.txtypdm);
            this.pnlYpxx.Controls.Add(this.lblypmc);
            this.pnlYpxx.Controls.Add(this.lblgg);
            this.pnlYpxx.Controls.Add(this.lblpm);
            this.pnlYpxx.Controls.Add(this.label14);
            this.pnlYpxx.Controls.Add(this.butmodif);
            this.pnlYpxx.Controls.Add(this.lblcj);
            this.pnlYpxx.Controls.Add(this.butdel);
            this.pnlYpxx.Controls.Add(this.label19);
            this.pnlYpxx.Controls.Add(this.butadd);
            this.pnlYpxx.Controls.Add(this.cmbdw);
            this.pnlYpxx.Controls.Add(this.label20);
            this.pnlYpxx.Controls.Add(this.label36);
            this.pnlYpxx.Controls.Add(this.label23);
            this.pnlYpxx.Controls.Add(this.butph);
            this.pnlYpxx.Controls.Add(this.lbllsj);
            this.pnlYpxx.Controls.Add(this.label30);
            this.pnlYpxx.Controls.Add(this.label25);
            this.pnlYpxx.Controls.Add(this.txtph);
            this.pnlYpxx.Controls.Add(this.lblscjj);
            this.pnlYpxx.Controls.Add(this.label29);
            this.pnlYpxx.Controls.Add(this.label26);
            this.pnlYpxx.Controls.Add(this.txtjhsl);
            this.pnlYpxx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlYpxx.Location = new System.Drawing.Point(3, 3);
            this.pnlYpxx.Name = "pnlYpxx";
            this.pnlYpxx.Size = new System.Drawing.Size(1358, 51);
            this.pnlYpxx.TabIndex = 5;
            // 
            // dtpxq
            // 
            this.dtpxq.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpxq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpxq.Location = new System.Drawing.Point(501, 26);
            this.dtpxq.Name = "dtpxq";
            this.dtpxq.Size = new System.Drawing.Size(137, 21);
            this.dtpxq.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(784, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 12);
            this.label5.TabIndex = 96;
            this.label5.Text = "上层网格：成品明细 下层网格：原料明细 ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgjhmx);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1358, 282);
            this.panel3.TabIndex = 7;
            // 
            // dgjhmx
            // 
            this.dgjhmx.AllowColumnSort = false;
            this.dgjhmx.AllowUserToAddRows = false;
            this.dgjhmx.AllowUserToDeleteRows = false;
            this.dgjhmx.BackgroundColor = System.Drawing.Color.White;
            this.dgjhmx.ColumnDeep = 1;
            this.dgjhmx.ColumnHeadersHeight = 17;
            this.dgjhmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgjhmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_yppm,
            this.col_ypgg,
            this.col_sccj,
            this.col_ypdw,
            this.col_nypdw,
            this.col_ydwbl,
            this.col_jhsl,
            this.col_cpsl,
            this.col_cpl,
            this.col_cpl1,
            this.col_cbj,
            this.col_jhj,
            this.col_pfj,
            this.col_lsj,
            this.col_jsph,
            this.col_ph,
            this.col_xq,
            this.col_pxxh,
            this.col_删除,
            this.col_添加原料,
            this.colcbje,
            this.coljhje,
            this.colpfje,
            this.collsje,
            this.col_id,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.col_rkdjmxid});
            this.dgjhmx.DisplayShowCardWhenCellInEdit = false;
            this.dgjhmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgjhmx.Location = new System.Drawing.Point(0, 0);
            this.dgjhmx.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgjhmx.MergeColumnNames")));
            this.dgjhmx.MultiSelect = false;
            this.dgjhmx.Name = "dgjhmx";
            this.dgjhmx.ReadOnly = true;
            this.dgjhmx.RowHeadersWidth = 31;
            this.dgjhmx.RowTemplate.Height = 23;
            this.dgjhmx.ShowCardComponent = null;
            showCardProperty2.AllowCustomInputWhenNoneSelectedRow = false;
            showCardProperty2.BindColumnName = "cyppm";
            showCardProperty2.ColumnHeaderVisible = true;
            showCardProperty2.DbConnection = null;
            showCardProperty2.RealTimeQuery = false;
            showCardProperty2.RowHeaderVisible = true;
            showCardProperty2.ShowCardColumns = new Trasen.Controls.ShowCardColumn[0];
            showCardProperty2.ShowCardDataSource = null;
            showCardProperty2.ShowCardDataSourceSqlString = null;
            showCardProperty2.ShowCardSize = new System.Drawing.Size(650, 0);
            this.dgjhmx.ShowCardProperty = new Trasen.Controls.ShowCardProperty[] {
        showCardProperty2};
            this.dgjhmx.Size = new System.Drawing.Size(1358, 282);
            this.dgjhmx.TabIndex = 7;
            this.dgjhmx.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgjhmx_CellClick);
            this.dgjhmx.CurrentCellChanged += new System.EventHandler(this.dgjhmx_CurrentCellChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblcpcb);
            this.panel1.Controls.Add(this.lblyl);
            this.panel1.Controls.Add(this.lblcp);
            this.panel1.Controls.Add(this.lblsumcpcbje);
            this.panel1.Controls.Add(this.lblsumyllsje);
            this.panel1.Controls.Add(this.lblylls);
            this.panel1.Controls.Add(this.lblsumylpfje);
            this.panel1.Controls.Add(this.lblylpf);
            this.panel1.Controls.Add(this.lblsumyljhje);
            this.panel1.Controls.Add(this.lblyljh);
            this.panel1.Controls.Add(this.lblsumcplsje);
            this.panel1.Controls.Add(this.lblcpls);
            this.panel1.Controls.Add(this.lblsumcppfje);
            this.panel1.Controls.Add(this.lblcppf);
            this.panel1.Controls.Add(this.lblsumcpjhje);
            this.panel1.Controls.Add(this.lblcpjh);
            this.panel1.Controls.Add(this.butsh);
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butnew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 650);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 43);
            this.panel1.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(752, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 12);
            this.label4.TabIndex = 98;
            this.label4.Text = "1.保存(原料消耗出库) 2.审核(成品入库)";
            // 
            // lblcpcb
            // 
            this.lblcpcb.AutoSize = true;
            this.lblcpcb.Location = new System.Drawing.Point(143, 13);
            this.lblcpcb.Name = "lblcpcb";
            this.lblcpcb.Size = new System.Drawing.Size(59, 12);
            this.lblcpcb.TabIndex = 82;
            this.lblcpcb.Text = "成本金额:";
            this.lblcpcb.Visible = false;
            // 
            // lblyl
            // 
            this.lblyl.AutoSize = true;
            this.lblyl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblyl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblyl.Location = new System.Drawing.Point(1, 25);
            this.lblyl.Name = "lblyl";
            this.lblyl.Size = new System.Drawing.Size(77, 12);
            this.lblyl.TabIndex = 81;
            this.lblyl.Text = "原料金额合计";
            // 
            // lblcp
            // 
            this.lblcp.AutoSize = true;
            this.lblcp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcp.ForeColor = System.Drawing.Color.Red;
            this.lblcp.Location = new System.Drawing.Point(0, 5);
            this.lblcp.Name = "lblcp";
            this.lblcp.Size = new System.Drawing.Size(77, 12);
            this.lblcp.TabIndex = 80;
            this.lblcp.Text = "成品金额合计";
            // 
            // lblsumcpcbje
            // 
            this.lblsumcpcbje.AutoSize = true;
            this.lblsumcpcbje.ForeColor = System.Drawing.Color.Red;
            this.lblsumcpcbje.Location = new System.Drawing.Point(202, 13);
            this.lblsumcpcbje.Name = "lblsumcpcbje";
            this.lblsumcpcbje.Size = new System.Drawing.Size(11, 12);
            this.lblsumcpcbje.TabIndex = 79;
            this.lblsumcpcbje.Text = "0";
            this.lblsumcpcbje.Visible = false;
            // 
            // lblsumyllsje
            // 
            this.lblsumyllsje.AutoSize = true;
            this.lblsumyllsje.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblsumyllsje.Location = new System.Drawing.Point(269, 25);
            this.lblsumyllsje.Name = "lblsumyllsje";
            this.lblsumyllsje.Size = new System.Drawing.Size(11, 12);
            this.lblsumyllsje.TabIndex = 77;
            this.lblsumyllsje.Text = "0";
            // 
            // lblylls
            // 
            this.lblylls.AutoSize = true;
            this.lblylls.Location = new System.Drawing.Point(211, 25);
            this.lblylls.Name = "lblylls";
            this.lblylls.Size = new System.Drawing.Size(59, 12);
            this.lblylls.TabIndex = 76;
            this.lblylls.Text = "零售金额:";
            // 
            // lblsumylpfje
            // 
            this.lblsumylpfje.AutoSize = true;
            this.lblsumylpfje.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblsumylpfje.Location = new System.Drawing.Point(137, 25);
            this.lblsumylpfje.Name = "lblsumylpfje";
            this.lblsumylpfje.Size = new System.Drawing.Size(11, 12);
            this.lblsumylpfje.TabIndex = 75;
            this.lblsumylpfje.Text = "0";
            // 
            // lblylpf
            // 
            this.lblylpf.AutoSize = true;
            this.lblylpf.Location = new System.Drawing.Point(79, 25);
            this.lblylpf.Name = "lblylpf";
            this.lblylpf.Size = new System.Drawing.Size(59, 12);
            this.lblylpf.TabIndex = 74;
            this.lblylpf.Text = "批发金额:";
            // 
            // lblsumyljhje
            // 
            this.lblsumyljhje.AutoSize = true;
            this.lblsumyljhje.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblsumyljhje.Location = new System.Drawing.Point(136, 25);
            this.lblsumyljhje.Name = "lblsumyljhje";
            this.lblsumyljhje.Size = new System.Drawing.Size(11, 12);
            this.lblsumyljhje.TabIndex = 73;
            this.lblsumyljhje.Text = "0";
            this.lblsumyljhje.Visible = false;
            // 
            // lblyljh
            // 
            this.lblyljh.AutoSize = true;
            this.lblyljh.Location = new System.Drawing.Point(78, 25);
            this.lblyljh.Name = "lblyljh";
            this.lblyljh.Size = new System.Drawing.Size(59, 12);
            this.lblyljh.TabIndex = 72;
            this.lblyljh.Text = "进货金额:";
            this.lblyljh.Visible = false;
            // 
            // lblsumcplsje
            // 
            this.lblsumcplsje.AutoSize = true;
            this.lblsumcplsje.ForeColor = System.Drawing.Color.Red;
            this.lblsumcplsje.Location = new System.Drawing.Point(269, 5);
            this.lblsumcplsje.Name = "lblsumcplsje";
            this.lblsumcplsje.Size = new System.Drawing.Size(11, 12);
            this.lblsumcplsje.TabIndex = 71;
            this.lblsumcplsje.Text = "0";
            // 
            // lblcpls
            // 
            this.lblcpls.AutoSize = true;
            this.lblcpls.Location = new System.Drawing.Point(211, 5);
            this.lblcpls.Name = "lblcpls";
            this.lblcpls.Size = new System.Drawing.Size(59, 12);
            this.lblcpls.TabIndex = 70;
            this.lblcpls.Text = "零售金额:";
            // 
            // lblsumcppfje
            // 
            this.lblsumcppfje.AutoSize = true;
            this.lblsumcppfje.ForeColor = System.Drawing.Color.Red;
            this.lblsumcppfje.Location = new System.Drawing.Point(137, 5);
            this.lblsumcppfje.Name = "lblsumcppfje";
            this.lblsumcppfje.Size = new System.Drawing.Size(11, 12);
            this.lblsumcppfje.TabIndex = 69;
            this.lblsumcppfje.Text = "0";
            // 
            // lblcppf
            // 
            this.lblcppf.AutoSize = true;
            this.lblcppf.Location = new System.Drawing.Point(79, 5);
            this.lblcppf.Name = "lblcppf";
            this.lblcppf.Size = new System.Drawing.Size(59, 12);
            this.lblcppf.TabIndex = 68;
            this.lblcppf.Text = "批发金额:";
            // 
            // lblsumcpjhje
            // 
            this.lblsumcpjhje.AutoSize = true;
            this.lblsumcpjhje.ForeColor = System.Drawing.Color.Red;
            this.lblsumcpjhje.Location = new System.Drawing.Point(136, 5);
            this.lblsumcpjhje.Name = "lblsumcpjhje";
            this.lblsumcpjhje.Size = new System.Drawing.Size(11, 12);
            this.lblsumcpjhje.TabIndex = 67;
            this.lblsumcpjhje.Text = "0";
            this.lblsumcpjhje.Visible = false;
            // 
            // lblcpjh
            // 
            this.lblcpjh.AutoSize = true;
            this.lblcpjh.Location = new System.Drawing.Point(78, 5);
            this.lblcpjh.Name = "lblcpjh";
            this.lblcpjh.Size = new System.Drawing.Size(59, 12);
            this.lblcpjh.TabIndex = 66;
            this.lblcpjh.Text = "进货金额:";
            this.lblcpjh.Visible = false;
            // 
            // butsh
            // 
            this.butsh.Location = new System.Drawing.Point(345, 11);
            this.butsh.Name = "butsh";
            this.butsh.Size = new System.Drawing.Size(76, 24);
            this.butsh.TabIndex = 60;
            this.butsh.Text = "审核(&H)";
            this.butsh.Click += new System.EventHandler(this.butsh_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(653, 11);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(76, 24);
            this.butclose.TabIndex = 59;
            this.butclose.Text = "关闭(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butprint
            // 
            this.butprint.Enabled = false;
            this.butprint.Location = new System.Drawing.Point(575, 11);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(76, 24);
            this.butprint.TabIndex = 58;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(498, 11);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(76, 24);
            this.butsave.TabIndex = 57;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(421, 11);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(76, 24);
            this.butnew.TabIndex = 56;
            this.butnew.Text = "新计划(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // col_yppm
            // 
            this.col_yppm.DataPropertyName = "yppm";
            this.col_yppm.HeaderText = "品名";
            this.col_yppm.Name = "col_yppm";
            this.col_yppm.ReadOnly = true;
            this.col_yppm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_yppm.Width = 180;
            // 
            // col_ypgg
            // 
            this.col_ypgg.DataPropertyName = "ypgg";
            this.col_ypgg.HeaderText = "规格";
            this.col_ypgg.Name = "col_ypgg";
            this.col_ypgg.ReadOnly = true;
            this.col_ypgg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ypgg.Width = 120;
            // 
            // col_sccj
            // 
            this.col_sccj.DataPropertyName = "sccj";
            this.col_sccj.HeaderText = "厂家";
            this.col_sccj.Name = "col_sccj";
            this.col_sccj.ReadOnly = true;
            this.col_sccj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_ypdw
            // 
            this.col_ypdw.DataPropertyName = "ypdw";
            this.col_ypdw.HeaderText = "单位";
            this.col_ypdw.Name = "col_ypdw";
            this.col_ypdw.ReadOnly = true;
            this.col_ypdw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ypdw.Width = 45;
            // 
            // col_nypdw
            // 
            this.col_nypdw.DataPropertyName = "nypdw";
            this.col_nypdw.HeaderText = "nypdw";
            this.col_nypdw.Name = "col_nypdw";
            this.col_nypdw.ReadOnly = true;
            this.col_nypdw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_nypdw.Visible = false;
            // 
            // col_ydwbl
            // 
            this.col_ydwbl.DataPropertyName = "ydwbl";
            this.col_ydwbl.HeaderText = "ydwbl";
            this.col_ydwbl.Name = "col_ydwbl";
            this.col_ydwbl.ReadOnly = true;
            this.col_ydwbl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ydwbl.Visible = false;
            // 
            // col_jhsl
            // 
            this.col_jhsl.DataPropertyName = "jhsl";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon;
            this.col_jhsl.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_jhsl.HeaderText = "计划数量";
            this.col_jhsl.Name = "col_jhsl";
            this.col_jhsl.ReadOnly = true;
            this.col_jhsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_jhsl.Width = 60;
            // 
            // col_cpsl
            // 
            this.col_cpsl.DataPropertyName = "cpsl";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LemonChiffon;
            this.col_cpsl.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_cpsl.HeaderText = "成品数量";
            this.col_cpsl.Name = "col_cpsl";
            this.col_cpsl.ReadOnly = true;
            this.col_cpsl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_cpsl.Width = 60;
            // 
            // col_cpl
            // 
            this.col_cpl.DataPropertyName = "cpl";
            this.col_cpl.HeaderText = "成品率";
            this.col_cpl.Name = "col_cpl";
            this.col_cpl.ReadOnly = true;
            this.col_cpl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_cpl.Visible = false;
            this.col_cpl.Width = 60;
            // 
            // col_cpl1
            // 
            this.col_cpl1.DataPropertyName = "cpl1";
            this.col_cpl1.HeaderText = "成品率";
            this.col_cpl1.Name = "col_cpl1";
            this.col_cpl1.ReadOnly = true;
            this.col_cpl1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_cpl1.Visible = false;
            this.col_cpl1.Width = 60;
            // 
            // col_cbj
            // 
            this.col_cbj.DataPropertyName = "cbj";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Cyan;
            this.col_cbj.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_cbj.HeaderText = "成本价";
            this.col_cbj.Name = "col_cbj";
            this.col_cbj.ReadOnly = true;
            this.col_cbj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_cbj.Visible = false;
            this.col_cbj.Width = 60;
            // 
            // col_jhj
            // 
            this.col_jhj.DataPropertyName = "jhj";
            this.col_jhj.HeaderText = "进货价";
            this.col_jhj.Name = "col_jhj";
            this.col_jhj.ReadOnly = true;
            this.col_jhj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_jhj.Width = 60;
            // 
            // col_pfj
            // 
            this.col_pfj.DataPropertyName = "pfj";
            this.col_pfj.HeaderText = "批发价";
            this.col_pfj.Name = "col_pfj";
            this.col_pfj.ReadOnly = true;
            this.col_pfj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_pfj.Width = 60;
            // 
            // col_lsj
            // 
            this.col_lsj.DataPropertyName = "lsj";
            this.col_lsj.HeaderText = "零售价";
            this.col_lsj.Name = "col_lsj";
            this.col_lsj.ReadOnly = true;
            this.col_lsj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_lsj.Width = 60;
            // 
            // col_jsph
            // 
            this.col_jsph.DataPropertyName = "jsph";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.col_jsph.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_jsph.HeaderText = "F";
            this.col_jsph.Name = "col_jsph";
            this.col_jsph.ReadOnly = true;
            this.col_jsph.Text = "F";
            this.col_jsph.Visible = false;
            this.col_jsph.Width = 25;
            // 
            // col_ph
            // 
            this.col_ph.DataPropertyName = "ph";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LemonChiffon;
            this.col_ph.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_ph.HeaderText = "批号";
            this.col_ph.Name = "col_ph";
            this.col_ph.ReadOnly = true;
            this.col_ph.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_ph.Width = 80;
            // 
            // col_xq
            // 
            this.col_xq.DataPropertyName = "xq";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LemonChiffon;
            this.col_xq.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_xq.HeaderText = "效期";
            this.col_xq.Name = "col_xq";
            this.col_xq.ReadOnly = true;
            this.col_xq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_xq.Width = 80;
            // 
            // col_pxxh
            // 
            this.col_pxxh.DataPropertyName = "pxxh";
            this.col_pxxh.HeaderText = "序号";
            this.col_pxxh.Name = "col_pxxh";
            this.col_pxxh.ReadOnly = true;
            this.col_pxxh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_pxxh.Width = 40;
            // 
            // col_删除
            // 
            this.col_删除.DataPropertyName = "删除";
            this.col_删除.HeaderText = "删除";
            this.col_删除.Name = "col_删除";
            this.col_删除.ReadOnly = true;
            this.col_删除.Text = "删除";
            this.col_删除.Width = 45;
            // 
            // col_添加原料
            // 
            this.col_添加原料.DataPropertyName = "添加原料";
            this.col_添加原料.HeaderText = "添加原料";
            this.col_添加原料.Name = "col_添加原料";
            this.col_添加原料.ReadOnly = true;
            this.col_添加原料.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_添加原料.Width = 65;
            // 
            // colcbje
            // 
            this.colcbje.DataPropertyName = "cbje";
            this.colcbje.HeaderText = "成本金额";
            this.colcbje.Name = "colcbje";
            this.colcbje.ReadOnly = true;
            this.colcbje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colcbje.Width = 80;
            // 
            // coljhje
            // 
            this.coljhje.DataPropertyName = "jhje";
            this.coljhje.HeaderText = "进货金额";
            this.coljhje.Name = "coljhje";
            this.coljhje.ReadOnly = true;
            this.coljhje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.coljhje.Width = 80;
            // 
            // colpfje
            // 
            this.colpfje.DataPropertyName = "pfje";
            this.colpfje.HeaderText = "批发金额";
            this.colpfje.Name = "colpfje";
            this.colpfje.ReadOnly = true;
            this.colpfje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colpfje.Width = 80;
            // 
            // collsje
            // 
            this.collsje.DataPropertyName = "lsje";
            this.collsje.HeaderText = "零售金额";
            this.collsje.Name = "collsje";
            this.collsje.ReadOnly = true;
            this.collsje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.collsje.Width = 80;
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_id.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "djid";
            this.dataGridViewTextBoxColumn12.HeaderText = "djid";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "djh";
            this.dataGridViewTextBoxColumn13.HeaderText = "djh";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "cjid";
            this.dataGridViewTextBoxColumn14.HeaderText = "cjid";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // col_rkdjmxid
            // 
            this.col_rkdjmxid.DataPropertyName = "rkdjmxid";
            this.col_rkdjmxid.HeaderText = "rkdjmxid";
            this.col_rkdjmxid.Name = "col_rkdjmxid";
            this.col_rkdjmxid.ReadOnly = true;
            this.col_rkdjmxid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_rkdjmxid.Visible = false;
            // 
            // Frmypjg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1370, 742);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "Frmypjg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品加工单";
            this.Load += new System.EventHandler(this.Frmyprk_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgYlmx)).EndInit();
            this.pnlYpxx.ResumeLayout(false);
            this.pnlYpxx.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgjhmx)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        //构造函数
        public Frmypjg(MenuTag menuTag, string chineseName, Form mdiParent, Guid id)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            this.db=InstanceForm.BDatabase;
            this.jhid = id;//计划id
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            this.MdiParent = _mdiParent;
            Yp.AddcmbCk(false, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);
            this.csYpxx();
            dgjhmx.DataError += new DataGridViewDataErrorEventHandler(dgjhmx_DataError);
            dgYlmx.DataError += new DataGridViewDataErrorEventHandler(dgYlmx_DataError);
        }

        void dgjhmx_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            tbjhmx = (DataTable)dgjhmx.DataSource;
            if (dgjhmx.Columns[e.ColumnIndex].HeaderText == "计划数量")
            {
                MessageBox.Show(string.Format("成品明细第{0}行【计划数量】输入有误！", rowIndex + 1));

                //dgjhmx.Rows[rowIndex].Cells[colIndex].Value = tbjhmx.Rows[rowIndex][colIndex];
            }
            if (dgjhmx.Columns[e.ColumnIndex].HeaderText == "成品数量")
            {
                MessageBox.Show(string.Format("成品明细第{0}行【成品数量】输入有误！", rowIndex + 1));
                //dgjhmx.Rows[rowIndex].Cells[colIndex].Value = tbjhmx.Rows[rowIndex][colIndex];
            }
            if (dgjhmx.Columns[e.ColumnIndex].HeaderText == "批号")
            {
                MessageBox.Show(string.Format("成品明细第{0}行【批号】输入有误！", rowIndex + 1));
                //dgjhmx.Rows[rowIndex].Cells[colIndex].Value = tbjhmx.Rows[rowIndex][colIndex].ToString();
            }
            if (dgjhmx.Columns[e.ColumnIndex].HeaderText == "效期")
            {
                MessageBox.Show(string.Format("成品明细第{0}行【效期】输入有误！", rowIndex + 1));
                //dgjhmx.Rows[rowIndex].Cells[colIndex].Value = Convert.ToDateTime(tbjhmx.Rows[rowIndex][colIndex]).ToShortDateString();
            }
        }

        void dgYlmx_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (dgYlmx.Columns[e.ColumnIndex].HeaderText == "数量")
            {
                dgYlmx.Rows[rowIndex].Cells[colIndex].Value = 0;
                MessageBox.Show(string.Format("原料明细第{0}行【数量】输入有误！",rowIndex+1));
                return;
            }
        }

		//窗体加载事件
		private void Frmyprk_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.dtpdjrq.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase); //取得系统日期
                SetLoad();
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

        private void SetLoad()
        {
            if (jhid == Guid.Empty || jhid == null)
            {
                tbjhmx = YK_ZJJG_JHMX.GetJhmxDataTable(" and  1=2 ", " order by a.pxxh ", db);
                tbylmx = YK_ZJJG_YLMX.GetYlmxDataTable(" and 1=2 ", " order by b.pxxh,a.pxxh ", db);
                dgjhmx.DataSource = tbjhmx;
                dgYlmx.DataSource = tbylmx;
            }
            List<YK_ZJJG_JH> lstJh = YK_ZJJG_JH.GetJhList(string.Format(" and a.id='{0}'", jhid), "", db);
            if (lstJh.Count > 0)
                jh = lstJh[0];
            else
                jh = null;

            if (jh == null)
            {
                //计划未保存
                jh = new YK_ZJJG_JH();
                jh.id = Guid.NewGuid();
                jh.bshbz = -1;
                SetControlEnable(-1);
            }
            else
            {
                if (jh.bshbz == 0)
                {
                    //已保存未审核
                    tbjhmx = YK_ZJJG_JHMX.GetJhmxDataTable(string.Format(" and a.djid ='{0}'", jh.id), " order by a.pxxh ", db);
                    dgjhmx.DataSource = tbjhmx;
                    tbylmx = YK_ZJJG_YLMX.GetYlmxDataTable(string.Format(" and a.djid= '{0}' ", jh.id), " order by b.pxxh,a.pxxh ", db);
                    dgYlmx.DataSource = tbylmx;
                    dtpdjrq.Value = jh.djrq;
                    txtbz.Text = Convertor.IsNull(jh.bz, "");
                    SetControlEnable(0);
                }
                if (jh.bshbz == 1)
                {
                    //已审核
                    tbjhmx = YK_ZJJG_JHMX.GetJhmxDataTable(string.Format(" and a.djid ='{0}'", jh.id), " order by a.pxxh ", db);
                    dgjhmx.DataSource = tbjhmx;
                    tbylmx = YK_ZJJG_YLMX.GetYlmxDataTable(string.Format(" and a.djid= '{0}' ", jh.id), " order by b.pxxh,a.pxxh ", db);
                    dgYlmx.DataSource = tbylmx;
                    dtpdjrq.Value = jh.djrq;
                    dtpshrq.Value = jh.shrq;
                    txtbz.Text = Convertor.IsNull(jh.bz, "");
                    SetControlEnable(1);
                }
            }
        }

        //void dtpxq_Leave(object sender, EventArgs e)
        //{
        //    //throw new Exception("The method or operation is not implemented.");
        //}

        private void SetControlEnable(int i)
        {
            if (i ==-1)//计划不存在时
            {
                this.审核日期.Visible = false;
                dtpshrq.Visible = false;
                this.登记日期.Visible = false;
                dtpdjrq.Visible = false;
                this.txtbz.Enabled = true;//计划备注
                this.txtypdm.Enabled = true;//计划明细检索
                //this.lblpfj.Enabled = true;//批发价
                this.txtjhsl.Enabled = true;//计划数量
                this.txtcpsl.Enabled = true;//成品数量
                this.txtph.Enabled = true;//批号
                this.butph.Enabled = true;//检索计划明细批号
                this.butadd.Enabled = true;//添加计划明细
                this.butdel.Enabled = true;//删除计划明细
                this.butmodif.Enabled = true;//修改计划明细

                this.dgjhmx.ReadOnly = false;//计划明细dg
                this.col_添加原料.Visible = true; dgjhmx.Columns["col_添加原料"].Visible = true;
                this.col_删除.Visible = true; dgjhmx.Columns["col_删除"].Visible = true;
                this.col_cbj.Visible = false; dgjhmx.Columns["col_cbj"].Visible = false;//成本价
                this.col_cpl.Visible = false; dgjhmx.Columns["col_cpl"].Visible = false;//成品率
                this.col_jhj.Visible = false; dgjhmx.Columns["col_jhj"].Visible = false;

                this.colcbje.Visible = false; dgjhmx.Columns["colcbje"].Visible = false;
                this.coljhje.Visible = false; dgjhmx.Columns["coljhje"].Visible = false;
                this.colpfje.Visible = false; dgjhmx.Columns["colpfje"].Visible = false;
                this.collsje.Visible = false; dgjhmx.Columns["collsje"].Visible = false;

                this.dgYlmx.ReadOnly = false;//原料明细dg
                foreach (DataGridViewColumn col in dgjhmx.Columns)
                {
                    string strColName = col.Name;
                    if (strColName == "col_jhsl" || strColName == "col_cpsl" || strColName == "col_" || strColName == "col_ph" || strColName == "col_xq")
                    {
                        col.ReadOnly = false;
                    }
                    else
                    {
                        col.ReadOnly = true;
                    }
                }
                this.c删除.Visible = true; dgYlmx.Columns["c删除"].Visible = true;
                this.cjsph.Visible = true; dgYlmx.Columns["cjsph"].Visible = true;
                this.ckcl.Visible = true; dgYlmx.Columns["ckcl"].Visible = true;

                this.cjhje.Visible = false; dgYlmx.Columns["cjhje"].Visible = false;
                this.cpfje.Visible = false; dgYlmx.Columns["cpfje"].Visible = false;
                this.clsje.Visible = false; dgYlmx.Columns["clsje"].Visible = false;

                butadd.Enabled = true;
                butdel.Enabled = true;
                butmodif.Enabled = true;
                 
                this.butsave.Enabled = true; //保存计划btn
                this.butsh.Enabled = false;  //审核计划btn
                this.butnew.Enabled = true; //新计划btn
                this.butprint.Enabled = false; //打印btn
                
            }
            if (i == 0)//计划已存在未审核时
            {
                this.审核日期.Visible = false;
                dtpshrq.Visible = false;
                this.登记日期.Visible = true;
                dtpdjrq.Visible = true;
                this.txtbz.Enabled = true;//计划备注
                this.txtypdm.Enabled = true;//计划明细检索
                //this.lblpfj.Enabled = true;//批发价
                this.txtjhsl.Enabled = true;//计划数量
                this.txtcpsl.Enabled = true;//成品数量
                this.txtph.Enabled = true;//批号
                this.butph.Enabled = true;//检索计划明细批号

                this.butadd.Enabled = false;//添加计划明细
                this.butdel.Enabled = false;//删除计划明细
                this.butmodif.Enabled = true;//修改计划明细

                this.dgjhmx.ReadOnly = false;//计划明细dg

                foreach (DataGridViewColumn col in dgjhmx.Columns)
                {
                    string strColName = col.Name;
                    if (strColName == "col_jhsl" || strColName == "col_cpsl" || strColName == "col_" || strColName == "col_ph" || strColName == "col_xq" )
                    {
                        col.ReadOnly = false;
                    }
                    else
                    {
                        col.ReadOnly = true;
                    }
                }

                this.col_添加原料.Visible = false; dgjhmx.Columns["col_添加原料"].Visible = false;
                this.col_删除.Visible = false; dgjhmx.Columns["col_删除"].Visible = false;
                //this.col_jsph.Visible = true; dgjhmx.Columns["col_jsph"].Visible = true;
                this.col_cbj.Visible = false; dgjhmx.Columns["col_cbj"].Visible = false;//成本价
                this.col_cpl.Visible = false; dgjhmx.Columns["col_cpl"].Visible = false;//成品率
                this.col_jhj.Visible = false; dgjhmx.Columns["col_jhj"].Visible = false;

                this.colcbje.Visible = false; dgjhmx.Columns["colcbje"].Visible = false;
                this.coljhje.Visible = false; dgjhmx.Columns["coljhje"].Visible = false;
                this.colpfje.Visible = false; dgjhmx.Columns["colpfje"].Visible = false;
                this.collsje.Visible = false; dgjhmx.Columns["collsje"].Visible = false;

                this.dgYlmx.ReadOnly = true;//原料明细dg 
                this.c删除.Visible = false; dgYlmx.Columns["c删除"].Visible = false;
                this.cjsph.Visible = false; dgYlmx.Columns["cjsph"].Visible = false;
                this.ckcl.Visible = false; dgYlmx.Columns["ckcl"].Visible = false;

                this.cjhje.Visible = false; dgYlmx.Columns["cjhje"].Visible = false;
                this.cpfje.Visible = true; dgYlmx.Columns["cpfje"].Visible = true;
                this.clsje.Visible = true; dgYlmx.Columns["clsje"].Visible = true;


                butadd.Enabled = false;
                butdel.Enabled = false;
                butmodif.Enabled = true;

                this.butsave.Enabled = false; //保存计划btn
                this.butsh.Enabled = true;  //审核计划btn
                this.butnew.Enabled = true; //新计划btn
                this.butprint.Enabled = false; //打印btn
            }
            if (i == 1)//计划已审核时
            {
                this.审核日期.Visible = true;
                dtpshrq.Visible = true;
                this.登记日期.Visible = true;
                dtpdjrq.Visible = true;
                this.txtbz.Enabled = false;//计划备注
                this.txtypdm.Enabled = false;//计划明细检索
                //this.lblpfj.Enabled = false;//批发价
                this.txtjhsl.Enabled = false;//计划数量
                this.txtcpsl.Enabled = false;//成品数量
                this.txtph.Enabled = false;//批号
                this.butph.Enabled = false;//检索计划明细批号
                this.butadd.Enabled = false;//添加计划明细
                this.butdel.Enabled = false;//删除计划明细
                this.butmodif.Enabled = false;//修改计划明细


                this.dgjhmx.Enabled = true;//计划明细dg 
                this.dgjhmx.ReadOnly = true;
                this.col_添加原料.Visible = false; dgjhmx.Columns["col_添加原料"].Visible = false;
                this.col_删除.Visible = false; dgjhmx.Columns["col_删除"].Visible = false;
                //this.col_jsph.Visible = false; dgjhmx.Columns["col_jsph"].Visible = false;
                this.col_cbj.Visible = false; dgjhmx.Columns["col_cbj"].Visible = false;//成本价
                this.col_cpl.Visible = true; dgjhmx.Columns["col_cpl"].Visible = true;//成品率
                this.col_jhj.Visible = false; dgjhmx.Columns["col_jhj"].Visible = false;

                this.colcbje.Visible = false; dgjhmx.Columns["colcbje"].Visible = false;
                this.coljhje.Visible = false; dgjhmx.Columns["coljhje"].Visible = false;
                this.colpfje.Visible = true; dgjhmx.Columns["colpfje"].Visible = true;
                this.collsje.Visible = true; dgjhmx.Columns["collsje"].Visible = true;

                this.dgYlmx.ReadOnly = true;//原料明细dg
                this.c删除.Visible = false; dgYlmx.Columns["c删除"].Visible = false;
                this.cjsph.Visible = false; dgYlmx.Columns["cjsph"].Visible = false;
                this.ckcl.Visible = false; dgYlmx.Columns["ckcl"].Visible = false;

                this.cjhje.Visible = false; dgYlmx.Columns["cjhje"].Visible = false;
                this.cpfje.Visible = true; dgYlmx.Columns["cpfje"].Visible = true;
                this.clsje.Visible = true; dgYlmx.Columns["clsje"].Visible = true;

                butadd.Enabled = false;
                butdel.Enabled = false;
                butmodif.Enabled = false;

                this.butsave.Enabled = false; //保存计划btn
                this.butsh.Enabled = false;  //审核计划btn
                this.butnew.Enabled = true; //新计划btn
                this.butprint.Enabled = false; //打印btn
            }

            SumJe(i);
        }

		#region 填充数据

	     //初始药品明细卡片
		private void csyp(int ggid,int cjid)
		{
            this.csYpxx();
			Ypgg ypgg=new  Ypgg(ggid,InstanceForm.BDatabase);
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
			this.lblypmc.Tag=ydcj.CJID.ToString();
			this.lblypmc.Text=ypgg.YPSPM;
			this.lblpm.Text=ypgg.YPPM;
			this.lblgg.Text=ypgg.YPGG;
            this.lblcj.Text = Yp.SeekSccj(ydcj.SCCJ, InstanceForm.BDatabase);
            Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ggid, cjid, this.cmbdw, InstanceForm.BDatabase);
            this.cmbdw.SelectedValue = "1";
			this.lblpfj.Text=ydcj.PFJ.ToString("0.000");
			this.lbllsj.Text=ydcj.LSJ.ToString("0.000") ;
			this.lblpfj.Tag=ydcj.PFJ.ToString();
			this.lbllsj.Tag=ydcj.LSJ.ToString() ;
            this.lblscjj.Text = Yp.SeekScjhj(ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString();
            this.lblkc.Text = Yp.SeekKcZh(1, ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");
            //this.txtjj.Text=ydcj.MRJJ.ToString("0.00");
            

            //对于退货 没有检索批号的时候要显示上次供货单位
            //指定批号之后 要查找它的供货单位 
            if (_menuTag.ToString() == "002")
            { 
                
            }
		}

        private void SumJe(int jhzt)
        {
            SumCpje(jhzt);
            SumYlje(jhzt);
        }

       //求和计划明细金额
		private void SumCpje(int jhzt)
		{
            if (jhzt == -1||jhzt==0)
            {
                lblcp.Visible = false;
                lblcpcb.Visible = false;
                lblsumcpcbje.Visible = false;
                lblcpjh.Visible = false;
                lblsumcpjhje.Visible = false;
                lblcppf.Visible = false;
                lblsumcppfje.Visible = false;
                lblcpls.Visible = false;
                lblsumcplsje.Visible = false;
                return;
            }
            if (jhzt == 1)
            {
                lblcp.Visible = true;
                //lblcpcb.Visible = true;
                //lblsumcpcbje.Visible = true;
                //lblcpjh.Visible = true;
                //lblsumcpjhje.Visible = true;
                lblcppf.Visible = true;
                lblsumcppfje.Visible = true;
                lblcpls.Visible = true;
                lblsumcplsje.Visible = true;

                decimal sumcpcbje = 0;
                decimal sumcpjhje = 0;
                decimal sumcppfje = 0;
                decimal sumcplsje = 0;

                tbjhmx = (DataTable)this.dgjhmx.DataSource;
                for (int i = 0; i <= tbjhmx.Rows.Count - 1; i++)
                {
                    sumcpcbje = sumcpcbje + Convert.ToDecimal(Convertor.IsNull(tbjhmx.Rows[i]["cbje"],"0"));
                    sumcpjhje = sumcpjhje + Convert.ToDecimal(Convertor.IsNull(tbjhmx.Rows[i]["jhje"], "0"));
                    sumcppfje = sumcppfje + Convert.ToDecimal(Convertor.IsNull(tbjhmx.Rows[i]["pfje"], "0"));
                    sumcplsje = sumcplsje + Convert.ToDecimal(Convertor.IsNull(tbjhmx.Rows[i]["lsje"], "0"));

                    lblsumcpcbje.Text = sumcpcbje.ToString("0.00");
                    lblsumcpjhje.Text = sumcpjhje.ToString("0.00");
                    lblsumcppfje.Text = sumcppfje.ToString("0.00");
                    lblsumcplsje.Text = sumcplsje.ToString("0.00");
                }
            }
		}

        //求和原料明细金额
        private void SumYlje(int jhzt)
        {
            if (jhzt == -1)
            {
                lblyl.Visible = false;
                lblyljh.Visible = false;
                lblsumyljhje.Visible = false;
                lblylpf.Visible = false;
                lblsumylpfje.Visible = false;
                lblylls.Visible = false;
                lblsumyllsje.Visible = false;
                return;
            }
            if (jhzt == 0 || jhzt == 1)
            {
                lblyl.Visible = true;
                //lblyljh.Visible = true;
                //lblsumyljhje.Visible = true;
                lblylpf.Visible = true;
                lblsumylpfje.Visible = true;
                lblylls.Visible = true;
                lblsumyllsje.Visible = true;

                decimal sumyljhje = 0;
                decimal sumylpfje = 0;
                decimal sumyllsje = 0;

                tbylmx = (DataTable)this.dgYlmx.DataSource;
                for (int i = 0; i <= tbylmx.Rows.Count - 1; i++)
                {
                    sumyljhje = sumyljhje + Convert.ToDecimal(Convertor.IsNull(tbylmx.Rows[i]["jhje"], "0"));
                    sumylpfje = sumylpfje + Convert.ToDecimal(Convertor.IsNull(tbylmx.Rows[i]["pfje"], "0"));
                    sumyllsje = sumyllsje + Convert.ToDecimal(Convertor.IsNull(tbylmx.Rows[i]["lsje"], "0"));
                }
                lblsumyljhje.Text = sumyljhje.ToString("0.00");
                lblsumylpfje.Text = sumylpfje.ToString("0.00") ;
                lblsumyllsje.Text = sumyllsje.ToString("0.00");
            }
        }


        //将网格行的明细显示在药品明细卡片上
		private void Getrow(DataRow row)
		{
            try
            {
                int cjid = Convert.ToInt32(Convertor.IsNull(row["cjid"], "0"));

                //Guid id = new Guid(row["id"].ToString());//计划明细id


                Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
                //this.dgjhmx.Tag=row["序号"].ToString();
                this.lblypmc.Text = row["yppm"].ToString();
                this.lblpm.Text = row["yppm"].ToString();
                this.lblypmc.Tag = row["cjid"].ToString();
                this.lblgg.Text = row["ypgg"].ToString();
                this.lblcj.Text = row["sccj"].ToString();
                this.txtph.Text = row["ph"].ToString();
                DateTime ttemp = Convertor.IsNull(row["xq"], "") != "" ? Convert.ToDateTime(row["xq"].ToString()) : System.DateTime.Now;
                this.dtpxq.Value = ttemp;
                this.lblpfj.Text = row["pfj"].ToString();
                this.lblpfj.Tag = row["pfj"].ToString();
                this.lbllsj.Text = row["lsj"].ToString();
                this.lbllsj.Tag = row["lsj"].ToString();
                this.lblscjj.Text = Yp.SeekScjhj(cjid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString();
                this.lblkc.Text = Yp.SeekKcZh(1, ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");
                this.txtjhsl.Text = row["jhsl"].ToString();
                this.txtcpsl.Text = row["cpsl"].ToString();
                Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
                this.cmbdw.SelectedValue = "1";
                //this.cmbdw.Text=row["单位"].ToString();
                //this.cmbdw.SelectedValue = row["dwbl"].ToString();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
		}

        //重新排序行号
		private void SortRowNO()
		{
			DataTable tb1=(DataTable)this.dgjhmx.DataSource;
			for(int i=0;i<=tb1.Rows.Count-1;i++)
			{
				tb1.Rows[i]["序号"]=i+1;
			}
		}

		//填充计划
        public void FillDj(Guid id, bool shbz)
		{
            cmbck.Enabled = false;
			bool isYk=false;//是否药库
            isYk = YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);

			DataTable tb;
			if (isYk==true)
                tb = Yk_dj_djmx.SelectDJ(id, InstanceForm.BDatabase);
			else
                tb = YF_DJ_DJMX.SelectDJ(id, InstanceForm.BDatabase);

            cmbck.SelectedValue = tb.Rows[0]["deptid"].ToString();
            ControlEnabled(Convert.ToInt32(tb.Rows[0]["shbz"]));

			this.groupBox1.Tag=tb.Rows[0]["id"].ToString();
			this.txtbz.Tag =tb.Rows[0]["wldw"].ToString();
            this.txtbz.Text = Yp.SeekGhdw(Convert.ToInt32(tb.Rows[0]["wldw"]), InstanceForm.BDatabase);
			DataTable tbmx;
			if (isYk==true)
                tbmx = Yk_dj_djmx.SelectDJmx(_menuTag.DllName, _menuTag.Function_Name, "yk_djmx", new Guid(tb.Rows[0]["id"].ToString()), InstanceForm.BDatabase);
			else
                tbmx = YF_DJ_DJMX.SelectDJmx(_menuTag.DllName, _menuTag.Function_Name, "yf_djmx", new Guid(tb.Rows[0]["id"].ToString()), InstanceForm.BDatabase);

			if (tbmx.Rows.Count==0)
			{
				if (isYk==true)
                    tbmx = Yk_dj_djmx.SelectDJmx(_menuTag.DllName, _menuTag.Function_Name, "yk_djmx_h", new Guid(tb.Rows[0]["id"].ToString()), InstanceForm.BDatabase);
				else
                    tbmx = YF_DJ_DJMX.SelectDJmx(_menuTag.DllName, _menuTag.Function_Name, "yf_djmx_h", new Guid(tb.Rows[0]["id"].ToString()), InstanceForm.BDatabase);
			}
			tbmx.TableName="tbmx";
			FunBase.AddRowtNo(tbmx);
			this.dgjhmx.DataSource=tbmx;
            //this.Sumje();
		}
		#endregion

		#region 界面控制事件
		/// <summary>
		/// 各控件的可用状态控制
		/// </summary>
		/// <param name="shbz">单据审核标记</param>
		private void ControlEnabled(int shbz)
		{
            this.butdel.Enabled = false;
            this.butadd.Enabled = false;
            this.butmodif.Enabled = false;
            this.txtjhsl.Enabled = false;
            this.cmbdw.Enabled = false;
            this.butph.Enabled = false;
            this.txtph.Enabled = false;
            //this.dtpxq.Enabled = false;
            this.txtypdm.Enabled = true;
            this.butsave.Enabled = false;
            this.butprint.Enabled = true;
            this.txtbz.Enabled = false;
            this.dtpdjrq.Enabled = false;
            
          
            this.butsh.Enabled = false;
            this.lblpfj.Enabled = false;
			if (shbz==0)
			{
				this.txtbz.Enabled=true;
				this.butsh.Enabled=true;
                this.butsave.Enabled = true;
                this.txtjhsl.Enabled = true;
                this.txtypdm.Enabled = true;
                this.butadd.Enabled = true;
				this.butmodif.Enabled=true;
                this.txtph.Enabled = true;
                this.dtpxq.Enabled = true;
				
				this.dtpdjrq.Enabled=true;
				
				this.butprint.Enabled=false;
                //if (ss.直接录入批发价==true) lblpfj.Enabled=true;
			}


            if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_yf_cx" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf_cx"
                || _menuTag.Function_Name == "Fun_ts_yk_cgrk_cx" || InstanceForm._menuTag.Function_Name == "Fun_ts_yk_cgrk_th_cx")
            {
                butnew.Visible = false;
                butsave.Enabled = false;
                butsh.Enabled = false;
            }
			
		}

		/// <summary>
		/// 清空当前单据的头信息
		/// </summary>
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
		
			this.groupBox1.Tag=null;
			this.dtpdjrq.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			
			this.dtpdjrq.Enabled=true;
		
			this.butph.Enabled=true;
            cmbck.Enabled = true;
           

		}


		/// <summary>
		/// 清空药品明细录入卡片
		/// </summary>
		private void csYpxx()
		{
            for (int i = 0; i <= this.pnlYpxx.Controls.Count - 1; i++)
            {
                if (this.pnlYpxx.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    if (this.pnlYpxx.Controls[i].Name != "txtshdh") this.pnlYpxx.Controls[i].Text = "";
                    this.pnlYpxx.Controls[i].Tag = "0";
                    this.pnlYpxx.Controls[i].Enabled = true;
                }
            }
			this.lblypmc.Text="";
			this.lblypmc.Tag="0";
			this.lblpm.Text="";
			this.lblgg.Text="";
			this.lblcj.Text="";
			
			this.lblpfj.Text="";
			this.lblpfj.Tag="0";
			this.lbllsj.Text="";
			this.lbllsj.Tag="0";
			this.lblscjj.Text="";
			this.lblkc.Text="";
		
			this.cmbdw.DataSource=null;
            //dtpxq = new System.Windows.Forms.DateTimePicker();
            //dtpxq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            //dtpxq.Location = new System.Drawing.Point(248, 96);
            //dtpxq.Name = "dtpxq";
            //dtpxq.Size = new System.Drawing.Size(120, 21);
            //dtpxq.TabIndex = 14;
            dtpxq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
			this.dtpxq.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			this.txtypdm.Focus();
			this.dgjhmx.Tag="0";
			this.cmbdw.Enabled=false;
			this.dtpxq.Enabled=true;
            //if (ss.直接录入批发价 == false)
            //{
            //    //lblpfj.Enabled = false;
            //}

		}


		/// <summary>
		/// 回车跳至下一个文本事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GotoNext(object sender, KeyPressEventArgs e)
		{ 
			Control control=(Control)sender;
			if (e.KeyChar==13 )
			{
				switch(control.Name)
				{
                    case "txtypdm":
                        if (lblypmc.Text.Trim() == "") return;
                        break;
					case "txtypsl":
                        if (txtjhsl.Text.Trim() == "") return;
                        //if (ss.直接录入批发价==true)
                        //    lblpfj.Focus();
						break;
					case "txtshdh":
						if (butadd.Enabled==false) butmodif.Focus();else butadd.Focus();
						break;
                        
					default:
						this.SelectNextControl(control,true,false,true,true);
						break;
				}
				
			}
		}
	
		/// <summary>
		/// 弹出输入框事件，调用相应的SHOWCard
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = ""; control.Tag = "0";
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { } else { return; }

            try
            {

                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    //case 1:
                    //    if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                    //    Yp.frmShowCard(sender, ShowCardType.供货单位, 0, point, 0, InstanceForm.BDatabase);

                    //    if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                    //    break;
                    case 7:
                        if (control.Text.Trim() == "") return;
                        Yp.frmShowCard(sender, ShowCardType.加工成品的药品字典, 0, point, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0")
                        {
                            Ypcj cj = new Ypcj(Convert.ToInt32(Convertor.IsNull(control.Tag, "0")), InstanceForm.BDatabase);
                            FindRecord(cj.CJID, 0);
                            csYpxx();
                            if (butsave.Enabled == true) butadd.Enabled = true;
                            this.csyp(cj.GGID, cj.CJID);
                            this.SelectNextControl((Control)sender, true, false, true, true);
                            //FindRecord(cj.CJID, 0);

                            ////获得上次供货单位
                            //if (_menuTag.FunctionTag == "002")
                            //{
                            //    int lastGhdw = Yp.SeekLastGhdwID(cj, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                            //}
                        }
                        break;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        public void FindRecord(int cjid, int nrow)
        {
            //int beginrow = nrow;
            //DataTable tb = (DataTable)this.dgjhmx.DataSource;
            //for (int i = beginrow; i <= tb.Rows.Count - 1; i++)
            //{
            //    if (Convert.ToInt32(tb.Rows[i]["cjid"]) == cjid)
            //    {
            //        this.dgjhmx.CurrentCell = new DataGridCell(i, 0);
            //        for (int j = 0; j <= tb.Rows.Count - 1; j++)
            //        {
            //            this.dgjhmx.UnSelect(j);
            //        }

            //        //this.dgjhmx.Select(i);
            //        beginrow = i + 1;
            //        DataRow row = tb.NewRow();
            //        Getrow(row);

            //        txtypdm.Focus();
            //        return;

            //    }
            //}
        }
	
		/// <summary>
		/// 进货金额输入事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtjhje_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
			int nkey=Convert.ToInt32(e.KeyCode);
			try
			{
				if (nkey!=13 && Convertor.IsNull(txtjhsl.Text.Trim(),"0")!="0" )
				{
					
	
					decimal pfj=0;
					pfj=Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text,"0"));

				
				
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

	
		/// <summary>
		/// 进价输入事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtjj_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			try
			{
				if (nkey!=13)
				{
                    //if (Convertor.IsNumeric(this.txtjj.Text)==false) txtjj.Text="";
                    ////if (nkey!=13 && Convertor.IsNull(txtjj.Text.Trim(),"0")!="0" && txtjj.Text.Trim()!="-" && txtjj.Text.Trim()!=".")
                    //if (nkey!=13  && txtjj.Text.Trim()!="-" && txtjj.Text.Trim()!=".")
                    //{
                    //    //decimal jhje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text,"0"));
                    //    decimal pfj=0;
                    //    pfj=Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text,"0"));
                    //    decimal kl=pfj==0?0:Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text,"0"))/pfj;
						
                    //}
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}


		/// <summary>
		/// 进价改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtjj_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
                //if (Convertor.IsNull(txtjj.Text.Trim(),"0")=="0"){txtjhje.Text="0";}
                //if (Convertor.IsNumeric(txtjj.Text)==true && Convertor.IsNull(txtjj.Text.Trim(),"0")!="0" && txtjj.Text.Trim()!="-" && txtjj.Text.Trim()!=".")
                //{
                //    decimal jhje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text,"0"));
                //    this.txtjhje.Text=jhje.ToString("0.000");
                //    decimal pfj=Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text,"0"));
                //    decimal kl=pfj==0?0:Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text,"0"))/pfj;
					
                //}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

	
		/// <summary>
		/// 扣率输入事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtkl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			try
			{
				if (nkey!=13)
				{  
				
					if (nkey!=13)
					{
						
						
                        //decimal jhje=Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text,"0"))*Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text,"0"));
                        //this.txtjhje.Text=jhje.ToString("0.00");
                      
					}
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

	
		/// <summary>
		/// 窗体键盘事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Frmyprk_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (Convert.ToInt32(e.KeyCode)==112)
			{
				this.butph_Click(sender,e);
			}

            if (e.KeyCode == Keys.F3)
            {
                if (Convert.ToInt32(Convertor.IsNull(lblypmc.Tag, "0")) == 0)
                {
                    MessageBox.Show("请选择药品后再进行该操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                FrmAddYpJg frm = new FrmAddYpJg(InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(Convertor.IsNull(lblypmc.Tag, "0")), InstanceForm.BDatabase);
                frm.ShowDialog();
                if (frm.ReturnCjid > 0)
                {
                    Ypcj cj = new Ypcj(frm.ReturnCjid, InstanceForm.BDatabase);
                    if (cj.CJID <= 0)
                    {
                        MessageBox.Show("对不起,该价格或厂家信息还没有写入本地服务器", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    csyp(cj.GGID, cj.CJID);
                    txtjhsl.Focus();
                    txtjhsl.SelectAll();
                }
            }

        }


		/// <summary>
		/// 单位改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmbdw_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
                if (Convert.ToUInt32(Convertor.IsNull(lblypmc.Tag, "0")) == 0) return;
                if (cmbdw.SelectedIndex <= -1) return;
				int dwbl=Convert.ToInt32(cmbdw.SelectedValue);
                this.lblkc.Text = Yp.SeekKcZh(dwbl, Convert.ToInt32(this.lblypmc.Tag), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");

				decimal pfj=Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Tag,"0"))/dwbl;
				this.lblpfj.Text=pfj.ToString("0.000");
				decimal lsj=Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag,"0"))/dwbl;
				this.lbllsj.Text=lsj.ToString("0.000");
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}


		/// <summary>
		/// 数量输入事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtypsl_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if (Convertor.IsNumeric(this.txtjhsl.Text)==false) txtjhsl.Text="";
				if(txtjhsl.Text.Trim()!="-" && txtjhsl.Text.Trim()!=".")
				{
                    //decimal jj=Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text,"0"));
					decimal ypsl=Convert.ToDecimal(Convertor.IsNull(this.txtjhsl.Text,"0"));
                    //decimal jhje=jj*ypsl;
                    //this.txtjhje.Text=jhje.ToString("0.000");
					decimal pfj=Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text,"0"));
                    //decimal kl=pfj==0?0:Convert.ToDecimal(Convertor.IsNull(this.txtjj.Text,"0"))/pfj;

                    
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		#endregion 

		#region 按钮事件 
	
        //添加计划明细
		private void butadd_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=(DataTable)this.dgjhmx.DataSource;
				DataRow row=tb.NewRow();

                int pxxh = 0;
                foreach (DataRow rowJhmx in tb.Rows)
                {
                    int temp = Convert.ToInt32(rowJhmx["pxxh"].ToString());
                    if (pxxh < temp)
                        pxxh = temp;
                }
                pxxh += 1;
                row["pxxh"] = pxxh;

				this.FillJhmxRow(row,true);
             
				if (row["yppm"].ToString().Trim()!="")
				{
					tb.Rows.Add(row);
                    this.csYpxx();
					this.butadd.Enabled=true;
                    //this.Sumje();
				}
                dgjhmx.CurrentCell = dgjhmx.Rows[dgjhmx.Rows.Count - 1].Cells["col_yppm"];//添加计划明细行之后定位到该行
                if (butsh.Enabled == true) butsh.Enabled = false;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}
	
		//新计划
		private void butnew_Click(object sender, System.EventArgs e)
		{
            try
            {
                this.csgroupbox1();
                tbjhmx = (DataTable)dgjhmx.DataSource;
                tbjhmx.Rows.Clear();

                tbylmx = (DataTable)dgYlmx.DataSource;
                tbylmx.Rows.Clear();

                jh = new YK_ZJJG_JH();
                jh.id = Guid.NewGuid();
                jh.bshbz = -1;

                SetControlEnable(-1);
                this.csYpxx();
                //if (ss.直接录入批发价==false) lblpfj.Enabled=false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + err.Source);
            }
		}

		//保存计划
		private void butsave_Click(object sender, System.EventArgs e)
		{
			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//登记时间
			tbjhmx=(DataTable)dgjhmx.DataSource;
            tbylmx=(DataTable)dgYlmx.DataSource;
			if (tbjhmx.Rows.Count==0) {MessageBox.Show("没有可保存的成品明细记录");return;}
            if(tbylmx.Rows.Count<=0) {MessageBox.Show("没有可保存的原料明细记录");return;}
			bool isYk=false;
            isYk = YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
            
            decimal sumjhje = 0;
            decimal sumpfje = 0;
            decimal sumlsje = 0;
            for (int i = 0; i <tbylmx.Rows.Count; i++)
            {
                sumjhje += Convert.ToDecimal(Convertor.IsNull(tbylmx.Rows[i]["jhj"], "0")) * Convert.ToDecimal(Convertor.IsNull(tbylmx.Rows[i]["sl"], "0"));
                sumpfje += Convert.ToDecimal(Convertor.IsNull(tbylmx.Rows[i]["pfj"], "0")) * Convert.ToDecimal(Convertor.IsNull(tbylmx.Rows[i]["sl"], "0"));
                sumlsje += Convert.ToDecimal(Convertor.IsNull(tbylmx.Rows[i]["lsj"], "0")) * Convert.ToDecimal(Convertor.IsNull(tbylmx.Rows[i]["sl"], "0"));
            }

            string mStr = string.Format("原料批发金额合计：{0}\n原料零售金额合计：{1}",sumlsje.ToString("0.000"), sumpfje.ToString("0.000"));
            if (DialogResult.Cancel == MessageBox.Show("确定要保存计划?\n" + mStr, "保存计划",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                return;

            this.butsave.Enabled = false;

            //if(DialogResult.Cancel==MessageBox.Show("确定要保存计划","保存计划",MessageBoxButtons.OKCancel,MessageBoxIcon.Question))
            //    return;
            try
			{
				InstanceForm.BDatabase.BeginTransaction();
                if (isYk == true)
                {
                    List<Jhmx_lstYlmx> lstjhmx_lstYlmx=new List<Jhmx_lstYlmx>();
                    List<DataRow> lstYlmxRow = new List<DataRow>(); //原料明细row集合
                    
                    foreach (DataRow row in tbylmx.Rows)
                    {
                        lstYlmxRow.Add(row);
                    }

                    int j = 1;
                    foreach (DataRow rowjhmx in tbjhmx.Rows)
                    {
                        Guid jhmxid = new Guid(rowjhmx["id"].ToString());
                        List<DataRow> lstYlmxRow2 = new List<DataRow>();
                        Jhmx_lstYlmx jhmx_lstYlmx;
                        for(int m=0;m<lstYlmxRow.Count;m++)
                        {
                            if (lstYlmxRow[m]["jhmxid"].ToString() == jhmxid.ToString())
                            {
                                lstYlmxRow2.Add(lstYlmxRow[m]);
                                //lstYlmxRow.Remove(lstYlmxRow[m]);
                            }
                        }
                        if (lstYlmxRow2.Count <= 0)
                        {
                            throw new Exception(string.Format("序号为{0}的成品明细没有添加对应的原料消耗明细",j));
                        }
                        j += 1;

                        //计划明细
                        YK_ZJJG_JHMX jhmx = new YK_ZJJG_JHMX();
                        jhmx.id = jhmxid;
                        jhmx.cjid = Convert.ToInt32(rowjhmx["cjid"].ToString()); //厂家id
                        jhmx.jhj = 0;// Convert.ToDecimal(Convertor.IsNull(rowjhmx["jhj"], "0"));//进货价
                        jhmx.jhsl = Convert.ToDecimal(Convertor.IsNull(rowjhmx["jhsl"],"0"));//计划数量
                        jhmx.cpsl = Convert.ToDecimal(Convertor.IsNull(rowjhmx["cpsl"],"0"));         //成品数量
                        jhmx.lsj = Convert.ToDecimal(Convertor.IsNull(rowjhmx["lsj"], "0"));//零售价
                        jhmx.pfj = Convert.ToDecimal(Convertor.IsNull(rowjhmx["pfj"], "0"));//批发价
                        jhmx.ph = rowjhmx["ph"].ToString();
                        jhmx.xq =Convert.ToDateTime( rowjhmx["xq"].ToString());
                        jhmx.rkdjmxid = Guid.Empty;
                        jhmx.sccj = rowjhmx["sccj"].ToString();
                        jhmx.ypdw = rowjhmx["ypdw"].ToString();
                        jhmx.nypdw = Convert.ToInt32(rowjhmx["nypdw"]);
                        jhmx.ydwbl = Convert.ToInt32(rowjhmx["ydwbl"]);
                        jhmx.ypgg = rowjhmx["ypgg"].ToString();
                        jhmx.yppm = rowjhmx["yppm"].ToString();
                        jhmx.pxxh = Convert.ToInt32(rowjhmx["pxxh"]);

                        //原料消耗明细List
                        List<YK_ZJJG_YLMX> lstYlmx = new List<YK_ZJJG_YLMX>();
                        int rowno = 1;
                        foreach (DataRow rowylmx in lstYlmxRow2)
                        {
                            YK_ZJJG_YLMX ylmx = new YK_ZJJG_YLMX();
                            if (rowylmx["cjid"] is DBNull) throw new Exception(string.Format("原料消耗明细没有选择药品！原料明细第{0}行",rowno));
                            if (rowylmx["xq"] is DBNull) throw new Exception(string.Format("原料消耗明细没有选择批号库存！原料明细第{0}行", rowno));
                            ylmx.id = new Guid(rowylmx["id"].ToString());
                            //ylmx.djid;
                            //ylmx.djh;
                            ylmx.cjid = Convert.ToInt32(rowylmx["cjid"].ToString());
                            ylmx.yppm=rowylmx["yppm"].ToString();
                            ylmx.ypgg=rowylmx["ypgg"].ToString();
                            ylmx.sccj=rowylmx["sccj"].ToString();
                            ylmx.ypdw=rowylmx["ypdw"].ToString();
                            ylmx.sl=Convert.ToDecimal(Convertor.IsNull(rowylmx["sl"],"0"));
                            if (ylmx.sl <= 0)
                            {
                                dgYlmx.CurrentCell = dgYlmx.Rows[rowno - 1].Cells["csl"];
                                throw new Exception(string.Format("第 {0} 行原料明细【{1}】数量不能小于等于0 ",rowno,ylmx.yppm));
                            }
                            ylmx.jhj=0;//Convert.ToDecimal(rowylmx["jhj"]);
                            ylmx.pfj=Convert.ToDecimal(rowylmx["pfj"]);
                            ylmx.lsj=Convert.ToDecimal(rowylmx["lsj"]);
                            ylmx.ph=rowylmx["ph"].ToString();
                            ylmx.xq=Convert.ToDateTime(rowylmx["xq"]);
                            
                            ylmx.jhmxid=jhmxid;
                            ylmx.ckmxid=Guid.Empty;
                            ylmx.pxxh = Convert.ToInt32(rowylmx["pxxh"]);
                            rowno += 1;
                            lstYlmx.Add(ylmx);
                        }

                        jhmx_lstYlmx=new Jhmx_lstYlmx(jhmx,lstYlmx);
                        lstjhmx_lstYlmx.Add(jhmx_lstYlmx);
                    }
                    string ywlx="032";
                    jh.id = Guid.NewGuid();
                    jh.djrq =Convert.ToDateTime(db.GetDataResult(db.GetServerTimeString()));//登记日期
                    jh.shrq = DateTime.MinValue;
                    jh.bscbz = 0;
                    jh.bshbz = 0;
                    jh.ywlx = "002"; //001--制剂  002--加工
                    jh.djy = InstanceForm.BCurrentUser.EmployeeId;
                    jh.bz = txtbz.Text;
                    jh.deptid = InstanceForm.BCurrentDept.DeptId;


                    #region 验证是否所有的原料消耗明细都有对应的计划明细
                    int tempCount = 0;
                    foreach (Jhmx_lstYlmx tt1 in lstjhmx_lstYlmx)
                    {
                        foreach (YK_ZJJG_YLMX tt2 in tt1.lstYlmx)
                        {
                            tempCount += 1;
                        }
                    }
                    if (tempCount != tbylmx.Rows.Count)
                    {
                        throw new Exception("存在原料明细找不到对应的成品明细！");
                    }
                    #endregion

                    YK_ZJJG_Class.CreatScJh(jh, lstjhmx_lstYlmx, db, ywlx, _menuTag.Jgbm);
                    db.CommitTransaction();
                    MessageBox.Show("保存计划成功！");
                    //tbjhmx = jh.GetJhmxDataTable("", "", db);
                    //dgjhmx.DataSource = tbjhmx;
                    //tbylmx = jh.GetYlmxDataTable("", "", db);
                    //dgYlmx.DataSource = tbylmx;
                    //SetControlEnable(0);
                    jhid = jh.id;
                    SetLoad();
                  
                }
                else
                {
                    jh.bshbz = -1;
                    throw new Exception("必须是药库！");
                }
			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				this.butsave.Enabled=true;
                jh.bshbz = -1;
                jhid=Guid.Empty;
                MessageBox.Show("保存失败！"+err.Message + err.Source);
			}
		}

		//删除计划明细行
		private void butdel_Click(object sender, System.EventArgs e)
		{
            //DataTable tb=(DataTable)this.dgjhmx.DataSource;
            //int nrow=this.dgjhmx.CurrentCell.RowNumber;
            //if (nrow>=tb.Rows.Count) return;
            //if(MessageBox.Show("您确定要删除第"+Convert.ToString((nrow+1))+"行吗 ？","询问窗",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
            //{
            //    DataRow datarow=tb.Rows[nrow];
            //    #region 删除原料明细
            //    DataTable tbmx2 = (DataTable)myDataGrid2.DataSource;
            //    foreach (DataRow row2 in tbmx2.Rows)
            //    {
            //        if (row2["jhmxid"].ToString() == datarow["id"])
            //        {
            //            tbmx2.Rows.Remove(row2);
            //        }
            //    }
            //    #endregion
            //    tb.Rows.Remove(datarow);
            //    this.Sumje();
            //    this.csgroupbox2();
            //}
			
            //this.butadd.Enabled=true;
		}

		//退出
		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//批号按钮事件
		private void butph_Click(object sender, System.EventArgs e)
		{
			try
			{
				int cjid=Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag,"0"));
				string[] GrdMappingName={"行号","库存量","单位","批号","效期", "子类型", "库位","kwid"};
				int[] GrdWidth={50,80,40,75,100,60,0,0};
				string[] sfield={"","","","",""};
                string ssql = "select 0 rowno,kcl,dbo.fun_yp_ypdw(zxdw),ypph,ypxq,c.mc zlxmc,'' kwmc,kwid  from " 
                    + Yp.Seek_kcph_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                    InstanceForm.BDatabase) 
                    + " a inner join  yp_ypcjd b on a.cjid=b.cjid inner join yp_ypzlx c on b.n_ypzlx= c.id where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) 
                    + " and b.cjid=" + cjid + " and (a.bdelete=0 or (a.bdelete=1 and kcl<>0))";
				TrasenFrame.Forms.Fshowcard f2=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,FilterType.拼音,"".Trim(),ssql,InstanceForm.BDatabase);
				Point point=new Point(this.Location.X+this.txtph.Location.X,this.Location.Y+this.txtph.Location.Y+this.txtph.Height*3 );
				f2.Location=point;
				f2.ShowDialog(this);
				DataRow row=f2.dataRow;
				if (row!=null) 
				{
					if (row["ypxq"].ToString().Trim()!="") dtpxq.Value=Convert.ToDateTime(row["ypxq"].ToString());
					this.txtph.Text=Convert.ToString(row["ypph"]);
				
                    //获得采购入库单中的供货单位
                    //if (_menuTag.FunctionTag == "002")
                    //{
                    //    int lastghdw = Yp.SeekLastGhdwID(new Ypcj(cjid,InstanceForm.BDatabase), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), txtph.Text == "" ? "无批号" : txtph.Text, InstanceForm.BDatabase);
                       
                    //}
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		//修改计划明细
		private void butmodif_Click(object sender, System.EventArgs e)
		{
			try
			{
				tbjhmx=(DataTable)this.dgjhmx.DataSource;
				int nrow=this.dgjhmx.CurrentCell.RowIndex;
                if (nrow > tbjhmx.Rows.Count - 1) return;
                DataRow row = tbjhmx.Rows[nrow];
				this.FillJhmxRow(row,false);
                DataRow nullrow = tbjhmx.NewRow();
				this.Getrow(nullrow);
                //this.butadd.Enabled=true;
                //if (butsh.Enabled == true) butsh.Enabled = false;
				txtypdm.Focus();
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		//审核计划
		private void butsh_Click(object sender, System.EventArgs e)
		{
			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

            tbjhmx = (DataTable)dgjhmx.DataSource;
            decimal sumjhje = 0;
            decimal sumpfje = 0;
            decimal sumlsje = 0;
            for (int i = 0; i < tbjhmx.Rows.Count;i++ )
            {
                sumjhje += Convert.ToDecimal(Convertor.IsNull(tbjhmx.Rows[i]["jhj"],"0")) * Convert.ToDecimal(Convertor.IsNull(tbjhmx.Rows[i]["cpsl"],"0"));
                sumpfje += Convert.ToDecimal(Convertor.IsNull(tbjhmx.Rows[i]["pfj"], "0")) * Convert.ToDecimal(Convertor.IsNull(tbjhmx.Rows[i]["cpsl"], "0"));
                sumlsje += Convert.ToDecimal(Convertor.IsNull(tbjhmx.Rows[i]["lsj"], "0")) * Convert.ToDecimal(Convertor.IsNull(tbjhmx.Rows[i]["cpsl"], "0"));
            }
            string mStr = string.Format("成品批发金额合计：{0}\n成品零售金额合计：{1}",  sumpfje.ToString("0.000"), sumlsje.ToString("0.000"));
            if (DialogResult.Cancel == MessageBox.Show("确定要审核计划？\n" + mStr, "保存计划",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                return;
			try
			{
				InstanceForm.BDatabase.BeginTransaction();
                if (YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) == true)
                {
                    List<YK_ZJJG_JHMX> lstjhmx = new List<YK_ZJJG_JHMX>();
                    
                    foreach (DataRow row in tbjhmx.Rows)
                    {
                        YK_ZJJG_JHMX jhmx = new YK_ZJJG_JHMX();
                        jhmx.id = new Guid(row["id"].ToString());
                        //jhmx.djid = new Guid(row["djid"].ToString());
                        //jhmx.djh = Convert.ToInt32(row["djh"]);
                        jhmx.cjid = Convert.ToInt32(row["cjid"]);
                        jhmx.yppm = row["yppm"].ToString();
                        jhmx.ypgg = row["ypgg"].ToString();
                        jhmx.ypdw = row["ypdw"].ToString();
                        jhmx.nypdw = Convert.ToInt32(row["nypdw"]);
                        jhmx.ydwbl = Convert.ToInt32(row["ydwbl"]);
                        jhmx.sccj = row["sccj"].ToString();
                        jhmx.jhsl = Convert.ToDecimal(Convertor.IsNull(row["jhsl"],"0"));
                        jhmx.cpsl = Convert.ToDecimal(Convertor.IsNull(row["cpsl"],"0"));
                        jhmx.cpl = Convert.ToDecimal( Convertor.IsNull(row["cpl"],"0"));
                        jhmx.jhj = 0;// Convert.ToDecimal(Convertor.IsNull(row["jhj"], "0"));
                        jhmx.pfj = Convert.ToDecimal(Convertor.IsNull(row["pfj"],"0"));
                        jhmx.lsj = Convert.ToDecimal(Convertor.IsNull(row["lsj"],"0"));
                        jhmx.cbj = Convert.ToDecimal(Convertor.IsNull(row["cbj"],"0"));
                        jhmx.ph = row["ph"].ToString();
                        jhmx.xq = Convert.ToDateTime(row["xq"].ToString());
                        jhmx.pxxh = Convert.ToInt32(row["pxxh"]);
                        jhmx.rkdjmxid = new Guid(row["rkdjmxid"].ToString());
                        lstjhmx.Add(jhmx);
                    }
                    jh.bshbz = 1;
                    jh.bz = txtbz.Text.Trim();
                    jh.shy = InstanceForm.BCurrentUser.EmployeeId;
                    YK_ZJJG_Class.ShScJh(jh, lstjhmx, db, "033", _menuTag.Jgbm);
                }
                else
                {
                    jh.bshbz = 0;
                    throw new Exception("必须是药库");
                }

				InstanceForm.BDatabase.CommitTransaction();
				this.butprint.Enabled=true;
                jhid = jh.id;
				MessageBox.Show("审核成功");
                SetLoad();

			}
			catch(System.Exception err)
			{
               
				InstanceForm.BDatabase.RollbackTransaction();
                jh.bshbz = 0;
                jhid = Guid.Empty;
				this.butsave.Enabled=true;
				MessageBox.Show("审核失败！"+err.Message+err.Source);
				
			}
		}

		//打印计划
		private void butprint_Click(object sender, System.EventArgs e)
        {
            #region 原单据打印代码
            //try
            //{
            //    string ywlwname=this.Text.Trim();
            //    DataTable tb=(DataTable)this.dgjhmx.DataSource;
            //    ts_Yk_ReportView.Dataset1 Dset=new ts_Yk_ReportView.Dataset1();
				
            //    DataRow myrow;
            //    for(int i=0;i<=tb.Rows.Count-1;i++)
            //    {
            //        myrow=Dset.采购入库单.NewRow();
            //        myrow["xh"]=Convert.ToInt32(tb.Rows[i]["序号"]);
            //        if (ss.打印单据时单据显示商品名==true)
            //            myrow["ypmc"]=Convert.ToString(tb.Rows[i]["商品名"]);
            //        else
            //            myrow["ypmc"]=Convert.ToString(tb.Rows[i]["品名"]);
            //        myrow["ypgg"]=Convert.ToString(tb.Rows[i]["规格"]);
            //        myrow["sccj"]=Convert.ToString(tb.Rows[i]["厂家"]);
            //        float ypsl=(float)Convert.ToDecimal(tb.Rows[i]["数量"]);
            //        myrow["ypsl"] = ypsl.ToString();//Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["数量"],"0"));
            //        myrow["ypdw"]=Convert.ToString(tb.Rows[i]["单位"]);
            //        myrow["ypkl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["扣率"],"0"));
            //        myrow["jhj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"],"0"));
            //        myrow["jhje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"],"0"));
            //        myrow["pfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"],"0"));
            //        myrow["pfje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"],"0"));
            //        myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"],"0"));
            //        myrow["lsje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"],"0"));
            //        myrow["jlce"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进零差额"],"0"));
            //        myrow["ypph"]=Convert.ToString(tb.Rows[i]["批号"]);
            //        myrow["ypxq"]=Convert.ToString(tb.Rows[i]["效期"]);
            //        myrow["shh"]=Convert.ToString(tb.Rows[i]["货号"]);
            //        myrow["kwmc"]=Convert.ToString(tb.Rows[i]["库位"]);
            //        myrow["shdh"]="";
            //        myrow["pzwh"] = Convert.ToString(tb.Rows[i]["批准文号"]);
            //        myrow["gjjbyw"] = Convert.ToString(tb.Rows[i]["基药"]);
            //        myrow["fkbl"] = Convert.ToString(tb.Rows[i]["付款比例"]);
            //        myrow["fkje"] = Convert.ToString(tb.Rows[i]["付款金额"]);
            //        Dset.采购入库单.Rows.Add(myrow);

            //    }

            //    string djy="";
            //    if (_menuTag.Function_Name == "Fun_ts_yk_cgrk" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_cx" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_th" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_th_cx")//药库
            //        djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from vi_yk_dj where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();
            //    if (_menuTag.Function_Name == "Fun_ts_yk_cgrk_yf" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_yf_cx" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf" || _menuTag.Function_Name == "Fun_ts_yk_cgrk_th_yf_cx")//药房
            //        djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from vi_yf_dj where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();
                

            //    ParameterEx[] parameters=new ParameterEx[11];
            //    parameters[0].Text="DJH";

            //    parameters[1].Text="DJY";
            //    parameters[1].Value = djy + "                                 打印员:" + InstanceForm.BCurrentUser.Name;
            //    parameters[2].Text="FPH";

            //    parameters[3].Text="FPRQ";
            //    //parameters[3].Value=fprq.Trim();
            //    parameters[4].Text="GHDW";
            //    parameters[4].Value=txtbz.Text.Trim();
            //    parameters[5].Text="RQ";
            //    parameters[5].Value=dtpdjrq.Value.ToShortDateString();
            //    parameters[6].Text="SHDH";
            //    //parameters[6].Value=txtshdh.Text.Trim();
            //    parameters[7].Text="TITLETEXT";
            //    parameters[7].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+ywlwname;
            //    parameters[8].Text="YWY";

            //    parameters[9].Text="ybps";

            //    parameters[10].Text = "ckmc";
            //    parameters[10].Value = cmbck.Text.Trim();

            //    string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            //    string[] str ={ "" };
            //    if (YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) == true)
            //        str[0] = " update yk_dj set bprint=1,DYCZY=" + InstanceForm.BCurrentUser.EmployeeId + " ,DYSJ='" + sDate + "' where id='" + new Guid(Convertor.IsNull(this.groupBox1.Tag, "")) + "'";
            //    else
            //        str[0] = " update yf_dj set bprint=1,DYCZY=" + InstanceForm.BCurrentUser.EmployeeId + " ,DYSJ='" + sDate + "' where id='" + new Guid(Convertor.IsNull(this.groupBox1.Tag, "")) + "'";

            //    TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.采购入库单, Constant.ApplicationDirectory + "\\Report\\YK_采购入库单.rpt", parameters, false, str, InstanceForm.BDatabase);
            //    if (f.LoadReportSuccess)
            //    {
            //        f._sqlStr = str;
            //        f.Show();
            //    }
            //    else
            //    {
            //        f.Dispose();
            //    }

				
            //}
            //catch(System.Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
            #endregion

            if (jh.bshbz == -1)
            { 
                //不能打印
            }
            if (jh.bshbz == 0)
            { 
                //打印原料消耗明细
            }
            if (jh.bshbz == 1)
            { 
                //打印原料消耗明细及成品入库明细
            }


        }

		//上一个计划
		private void butup_Click(object sender, System.EventArgs e)
		{
            //_id = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));
            //if (_id==Guid.Empty)
            //{
            //    _id = new Guid(_tb.Rows[_tb.Rows.Count - 1]["id"].ToString());
            //    FillDj(_id,false);
            //}
            //else
            //{
            //    //DataRow[] row=_tb.Select(" 单据号<"+Convert.ToInt64(lbldjh.Text)+"","单据号 desc");
            //    //if (row.Length==0) {butup.Enabled=false;butnext.Enabled=true;return;}
            //    //_id=new Guid(row[0]["id"].ToString());
            //    //FillDj(_id,false);

            //    //row=_tb.Select(" 单据号<"+Convert.ToInt64(lbldjh.Text)+"","单据号 desc");
            //    //if (row.Length==0) {butup.Enabled=false;butnext.Enabled=true;return;}
            //}
		}

		//下一个计划
		private void butnext_Click(object sender, System.EventArgs e)
		{
            _id = new Guid(Convertor.IsNull(this.groupBox1.Tag,Guid.Empty.ToString()));
			if (_id==Guid.Empty)
			{
                //butnext.Enabled=false;
                //butup.Enabled=true;
				return;
			}
			else
            {
            //    DataRow[] row=_tb.Select(" 单据号>"+Convert.ToInt64(lbldjh.Text)+"","单据号");
            //    if (row.Length==0) {butup.Enabled=true;butnext.Enabled=false;return;}
            //    _id=new Guid(row[0]["id"].ToString());
            //    FillDj(_id,false);

            //    row=_tb.Select(" 单据号>"+Convert.ToInt64(lbldjh.Text)+"","单据号");
            //    if (row.Length==0) {butup.Enabled=true;butnext.Enabled=false;return;}
			}
		}
		#endregion

        //定义变量
        DataTable tbjhmx;  //计划明细datatable
        DataTable tbylmx;  //原料明细datatable
        Guid jhid;         //计划id
        YK_ZJJG_JH jh;
        private RelationalDatabase db;

        private void cmbck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbck.SelectedValue == null) return;
                if (cmbck.SelectedValue.ToString() == "System.Data.DataRowView" ) return;
                ss = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                //if (ss.直接录入批发价 == true)
                //    lblpfj.Enabled = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //填充计划明细
        private void FillJhmxRow(System.Data.DataRow row,bool bAdd)
        {
            YpConfig s = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);

            #region 验证输入 批发价、计划数量、成品数量
            if (Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag, "0")) == 0)
            {
                if (bAdd)
                {
                   throw  new  Exception("没有可添加的药品"); 
                }
                else
                {
                    throw new Exception("没有可修改的药品");
                }
            }

            if (Convertor.IsNumeric(txtjhsl.Text) == true)
            {
                if (new SystemCfg(8023).Config.Contains(_menuTag.FunctionTag.ToString()) == true && Convert.ToDecimal(Convertor.IsNull(txtjhsl.Text, "0")) < 0)
                {
                    throw new Exception("系统设定不能输入负数");
                }
            }

            //批发价 不能为负数
            if (Convertor.IsNumeric(lblpfj.Text) == false)
            {
                throw new Exception("批发价必须为数字");
            }
            else
            {
                if (Convert.ToDecimal(Convertor.IsNull(lblpfj.Text, "0")) < 0)
                {
                    throw new Exception("批发价必须大于0");
                }
            }

            //计划数量  不能为负数
            if (Convertor.IsNumeric(txtjhsl.Text) == false)
            {
                throw new Exception("计划数量必须为数字");
            }
            else
            {
                if (Convert.ToDecimal(Convertor.IsNull(txtjhsl.Text, "0")) < 0)
                {
                    throw new Exception("计划数量必须大于0");
                }
            }

            //成品数量  不能为负数
            if (Convertor.IsNumeric(txtcpsl.Text) == false)
            {
                throw new Exception("成品数量必须为数字");
            }
            else
            {
                if (Convert.ToDecimal(Convertor.IsNull(txtcpsl.Text, "0")) < 0)
                {
                    throw new Exception("成品数量必须大于0");
                }
            }

            
            //if (Convert.ToDecimal(Convertor.IsNull(txtjhsl.Text, "0")) == 0)
            //{
            //    if (MessageBox.Show("计划数量为零,您确定吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            //    {
            //        txtjhsl.Focus(); return;
            //    }
            //}
            #endregion

            if (jh.bshbz==-1)
            {
                #region 填充计划明细
                tbjhmx = (DataTable)this.dgjhmx.DataSource;
                int cjid = Convert.ToInt32(this.lblypmc.Tag.ToString());
                for (int i = 0; i <= tbjhmx.Rows.Count - 1; i++)
                {
                    if (cjid.ToString() == Convertor.IsNull(tbjhmx.Rows[i]["cjid"], "0"))
                    {
                        if (row["cjid"].ToString() == "") if (MessageBox.Show(this, "[" + this.lblypmc.Text + "] 已在第" + (i + 1) + "行添加过,您确认继续添加吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    }
                }
                row["yppm"] = this.lblpm.Text.Trim();
                //row["商品名"]=this.lblypmc.Text.Trim();
                row["ypgg"] = this.lblgg.Text.Trim();
                row["sccj"] = this.lblcj.Text.Trim();
                row["ph"] = Convertor.IsNull(this.txtph.Text.Trim(), "无批号");
                row["xq"] = this.dtpxq.Value.ToShortDateString();
                //MessageBox.Show("dtpxq.value"+dtpxq.Value.ToString());
                decimal jhj = 0;//Convert.ToDecimal(Convertor.IsNull(this.lblscjj.Text.Trim(), "0"));
                row["jhj"] = jhj.ToString("0.000");
                decimal pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(), "0"));
                row["pfj"] = pfj.ToString("0.000");
                decimal lsj = Convert.ToDecimal(this.lbllsj.Text.Trim());
                row["lsj"] = lsj.ToString("0.000");
                decimal jhsl = Convert.ToDecimal(Convertor.IsNull(this.txtjhsl.Text.Trim(), "0"));
                row["jhsl"] = jhsl.ToString("0.000");
                decimal cpsl = Convert.ToDecimal(Convertor.IsNull(this.txtcpsl.Text.Trim(), "0"));
                row["cpsl"] = cpsl.ToString("0.000");
                row["ypdw"] = this.cmbdw.Text.Trim();
                row["nypdw"] = Yp.SeekYpdw(row["ypdw"].ToString(), InstanceForm.BDatabase);
                row["ydwbl"] = this.cmbdw.SelectedValue;
                row["cjid"] = this.lblypmc.Tag.ToString();
                //row["dwbl"]=Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
                row["删除"] = "删除";
                row["添加原料"] = "添加原料";
                if (row["id"] is DBNull)
                {
                    row["id"] = Guid.NewGuid();
                }
                row["jsph"] = "F";
               
                Ypcj cj = new Ypcj(Convert.ToInt32(this.lblypmc.Tag), InstanceForm.BDatabase);
                Ypgg gg = new Ypgg(cj.GGID, InstanceForm.BDatabase);
                #endregion

                if (bAdd)
                {
                    #region 自动匹配原料
                    Ypcj ylcj = MatchYlYpcj(cj,
                        Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                    if (ylcj!=null)
                    {
                        Ypgg ylgg = new Ypgg(ylcj.GGID, InstanceForm.BDatabase);
                        tbylmx = (DataTable)dgYlmx.DataSource;

                        #region  分配批号库存
                        decimal sl_temp = jhsl; //取计划数量的库存进行分配
                        string ssql = string.Format("  select * from yk_kcph where cjid = '{0}' and kcl>0 and deptid ={1} and ykbdelete<>1 order by djsj asc ", ylcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")));
                        DataTable tbkcph = db.GetDataTable(ssql);
                        List<Kcph> lstkcph = new List<Kcph>();
                        foreach (DataRow rowkcph in tbkcph.Rows)
                        {
                            decimal kclph = Convert.ToDecimal(rowkcph["kcl"]);
                            if (kclph >= sl_temp)
                            {
                                Kcph kcph = new Kcph(ylcj.CJID, sl_temp, rowkcph["ypph"].ToString(), Convert.ToDateTime(rowkcph["ypxq"]), kclph);
                                sl_temp -= kclph;
                                lstkcph.Add(kcph);
                                break;
                            }
                            else
                            {
                                Kcph kcph = new Kcph(ylcj.CJID, kclph, rowkcph["ypph"].ToString(), Convert.ToDateTime(rowkcph["ypxq"]), kclph);
                                lstkcph.Add(kcph);
                                sl_temp -= kclph;
                            }
                        }
                        #endregion

                        #region 填充原料明细
                        foreach (Kcph kcph in lstkcph)
                        {
                            DataRow rowylmx = tbylmx.NewRow();
                            rowylmx["yppm"] = ylcj.S_YPPM;
                            rowylmx["ypgg"] = ylcj.S_YPGG;
                            rowylmx["sccj"] = ylcj.S_SCCJ;
                            rowylmx["ypdw"] = ylcj.S_YPDW;
                            rowylmx["nypdw"] = Yp.SeekYpdw(rowylmx["ypdw"].ToString(), InstanceForm.BDatabase);
                            rowylmx["ydwbl"] = 1;
                            rowylmx["sl"] = kcph.sl.ToString("0.000"); //计划明细中成品数量
                            rowylmx["ph"] = kcph.ph;
                            rowylmx["xq"] = kcph.xq;
                            rowylmx["jhj"] = 0;
                            rowylmx["pfj"] = ylcj.PFJ.ToString("0.000");
                            rowylmx["lsj"] = ylcj.LSJ.ToString("0.000");
                            rowylmx["id"] = Guid.NewGuid();
                            rowylmx["jhmxid"] = row["id"];    //计划明细id
                            rowylmx["ckmxid"] = Guid.Empty; //出库明细id
                            rowylmx["cjid"] = ylcj.CJID;
                            //rowylmx["移除原料"] = "移除原料";
                            rowylmx["kcl"] = kcph.kcl;
                            rowylmx["删除"] = "删除";
                            rowylmx["jsph"] = "F";
                            int pxxh = 0;
                            foreach (DataRow row_Ylmx in tbylmx.Rows)
                            {
                                if (rowylmx["jhmxid"].ToString() == row_Ylmx["jhmxid"].ToString())
                                {
                                    int temp = Convert.ToInt32(row_Ylmx["pxxh"].ToString());
                                    if (pxxh < temp)
                                    {
                                        pxxh = temp;
                                    }
                                }
                            }
                            pxxh += 1;
                            rowylmx["pxxh"] = pxxh;
                            //row2["djid"];
                            //row2["djh"];
                            tbylmx.Rows.Add(rowylmx);
                        }
                        #endregion
                    }
                    #endregion
                }
            }
            if (jh.bshbz == 0)
            {
                #region 填充计划明细
                tbjhmx = (DataTable)this.dgjhmx.DataSource;
                int cjid = Convert.ToInt32(this.lblypmc.Tag.ToString());
                for (int i = 0; i <= tbjhmx.Rows.Count - 1; i++)
                {
                    if (cjid.ToString() == Convertor.IsNull(tbjhmx.Rows[i]["cjid"], "0"))
                    {
                        if (row["cjid"].ToString() == "") if (MessageBox.Show(this, "[" + this.lblypmc.Text + "] 已在第" + (i + 1) + "行添加过,您确认继续添加吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    }
                }
                row["yppm"] = this.lblpm.Text.Trim();
                //row["商品名"]=this.lblypmc.Text.Trim();
                row["ypgg"] = this.lblgg.Text.Trim();
                row["sccj"] = this.lblcj.Text.Trim();
                row["ph"] = Convertor.IsNull(this.txtph.Text.Trim(), "无批号");
                row["xq"] = this.dtpxq.Value.ToShortDateString();
                decimal jhj = 0;//Convert.ToDecimal(Convertor.IsNull(this.lblscjj.Text.Trim(), "0"));
                row["jhj"] = jhj.ToString();
                decimal pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(), "0"));
                row["pfj"] = pfj.ToString();
                decimal lsj = Convert.ToDecimal(this.lbllsj.Text.Trim());
                row["lsj"] = lsj.ToString();
                decimal jhsl = Convert.ToDecimal(Convertor.IsNull(this.txtjhsl.Text.Trim(), "0"));
                row["jhsl"] = jhsl.ToString();
                decimal cpsl = Convert.ToDecimal(Convertor.IsNull(this.txtcpsl.Text.Trim(), "0"));
                row["cpsl"] = cpsl.ToString();
                row["ypdw"] = this.cmbdw.Text.Trim();
                row["cjid"] = this.lblypmc.Tag.ToString();
                //row["dwbl"]=Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
                row["删除"] = "删除";
                row["添加原料"] = "添加原料";
                //if (row["id"] is DBNull)
                //{
                //    row["id"] = Guid.NewGuid();
                //}
                row["jsph"] = "F";
                //Ypcj cj = new Ypcj(Convert.ToInt32(this.lblypmc.Tag), InstanceForm.BDatabase);
                //Ypgg gg = new Ypgg(cj.GGID, InstanceForm.BDatabase);
                #endregion
            }
        }
       
        //根据输入的成品匹配原料
        //如果匹配到两个原料 只取前面一个
        private YpClass.Ypcj MatchYlYpcj(Ypcj cpYpcj,int deptid,RelationalDatabase db)
        {
            //参数：8042  值：1,2|3,4  中药加工成品原料对应药品子类型: 前面的是成品子类型，后面的是原料子类型
            //原料 跟成品名称必须一致
            Ypgg cpgg=new Ypgg(cpYpcj.GGID,db); //成品规格
            int cpzlx = cpgg.YPZLX;
            string strYlzlx = "";//原料所属药品子类型
            Ypcj ylYpcj = null;

            //获取对应原料所属药品类型
            DataTable dtConfig = db.GetDataTable(string.Format(" select config from jc_config where id = 8042 ",8042));
            if (dtConfig.Rows.Count > 0)
            {
                string strCfg = dtConfig.Rows[0][0].ToString();

                string[] strs = strCfg.Split('|');
                string strCp = strs[0];
                string strYl = strs[1];

                string[] scps = strCp.Split(',');
                string[] syls = strYl.Split(',');

                List<string> lstTemp = new List<string>();
                for (int i = 0; i < scps.Length; i++)
                {
                    if (cpzlx == Convert.ToInt32(scps[i]))
                    {
                        lstTemp.Add(syls[i].ToString());
                    }
                }
                if (lstTemp.Count > 0)
                {
                    for (int m = 0; m < lstTemp.Count; m++)
                    {
                        if (m == 0)
                        {
                            strYlzlx = "(" + lstTemp[m];
                        }
                        else
                        {
                            strYlzlx += lstTemp[m];
                        }
                        if(m == lstTemp.Count - 1)
                        {
                            strYlzlx += ")";
                        }
                    }

                    string ssql = string.Format(" select * from yp_ypcjd where s_yppm = '{0}' and n_ypzlx in {1} and cjid<>{2}", cpYpcj.S_YPPM, strYlzlx, cpYpcj.CJID);
                    DataTable dt = db.GetDataTable(ssql);
                    if (dt.Rows.Count > 0)
                    {
                        int cjid = Convert.ToInt32(dt.Rows[0]["cjid"]);
                        ylYpcj = new Ypcj(cjid, db);
                    }
                }
            }
            return ylYpcj;
        }

        //计划明细单元格单击事件
        private void dgjhmx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0) return;
                if (dgjhmx.Rows.Count <= 0) return;
                int rowIndex = e.RowIndex;
                int colIndex = e.ColumnIndex;
                if (rowIndex < 0) return;
                tbjhmx = (DataTable)dgjhmx.DataSource;
                tbylmx = (DataTable)dgYlmx.DataSource;
                DataRow rowjhmx = tbjhmx.Rows[e.RowIndex];

                Guid jhmxid = new Guid(rowjhmx["id"].ToString());//计划明细id

                #region 删除计划明细 同时应该计划明细对应的原料明细
                List<DataRow> lstrow = new List<DataRow>();
                if (dgjhmx.Columns[e.ColumnIndex].Name == "col_删除")
                {
                    DialogResult result = MessageBox.Show("确定删除成品明细？", "删除成品", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        for (int i = 0; i < tbylmx.Rows.Count; i++)
                        {
                            if (tbylmx.Rows[i]["jhmxid"].ToString() == jhmxid.ToString())
                            {
                                lstrow.Add(tbylmx.Rows[i]);
                            }
                        }
                        tbjhmx.Rows.Remove(rowjhmx);

                        foreach (DataRow row in lstrow)
                        {
                            tbylmx.Rows.Remove(row);
                        }
                        return;
                    }
                }

                #endregion

                #region 添加原料消耗明细 如果该计划明细已有原料消耗明细，需要插入到特定位置
                if (dgjhmx.Columns[e.ColumnIndex].Name == "col_添加原料")
                {
                    tbylmx = (DataTable)dgYlmx.DataSource;
                    Ypcj cpcj = new Ypcj(Convert.ToInt32(tbjhmx.Rows[rowIndex]["cjid"]), db);

                    DataRow rowylmx = tbylmx.NewRow();

                    #region 匹配原料
                    Ypcj ylcj = MatchYlYpcj(cpcj, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                        InstanceForm.BDatabase);
                    if (ylcj != null)//如果匹配到原料
                    {
                        #region
                        Ypgg ylgg = new Ypgg(ylcj.GGID, InstanceForm.BDatabase);
                        tbylmx = (DataTable)dgYlmx.DataSource;

                        rowylmx["yppm"] = ylcj.S_YPPM;
                        rowylmx["ypgg"] = ylcj.S_YPGG;
                        rowylmx["sccj"] = ylcj.S_SCCJ;
                        rowylmx["ypdw"] = ylcj.S_YPDW;
                        rowylmx["nypdw"] = Yp.SeekYpdw(rowylmx["ypdw"].ToString(), InstanceForm.BDatabase);
                        rowylmx["ydwbl"] = 1;
                        rowylmx["sl"] = 0; //计划明细中成品数量
                        //rowylmx["ph"] = kcph.ph;
                        //rowylmx["xq"] = kcph.xq;
                        rowylmx["jhj"] = 0;
                        rowylmx["pfj"] = ylcj.PFJ;
                        rowylmx["lsj"] = ylcj.LSJ;
                        rowylmx["id"] = Guid.NewGuid();
                        rowylmx["jhmxid"] = rowjhmx["id"];//计划明细id
                        rowylmx["ckmxid"] = Guid.Empty;   //出库明细id
                        rowylmx["cjid"] = ylcj.CJID;
                        rowylmx["kcl"] = 0;
                        rowylmx["删除"] = "删除";
                        rowylmx["jsph"] = "F";
                        //row2["djid"];
                        //row2["djh"];
                        //tbylmx.Rows.Add(rowylmx);
                        #endregion
                    }
                    else//未匹配到原料
                    {
                        //Ypgg ylgg = new Ypgg(ylcj.GGID, InstanceForm.BDatabase);
                        tbylmx = (DataTable)dgYlmx.DataSource;

                        //rowylmx["yppm"] = ylcj.S_YPPM;
                        //rowylmx["ypgg"] = ylcj.S_YPGG;
                        //rowylmx["sccj"] = ylcj.S_SCCJ;
                        //rowylmx["ypdw"] = ylcj.S_YPDW;
                        rowylmx["sl"] = 0; //计划明细中成品数量
                        ////rowylmx["ph"] = kcph.ph;
                        ////rowylmx["xq"] = kcph.xq;
                        //rowylmx["jhj"] = 0;
                        //rowylmx["pfj"] = ylcj.PFJ;
                        //rowylmx["lsj"] = ylcj.LSJ;
                        rowylmx["id"] = Guid.NewGuid();
                        rowylmx["jhmxid"] = rowjhmx["id"];//计划明细id
                        rowylmx["ckmxid"] = Guid.Empty;   //出库明细id
                        //rowylmx["cjid"] = ylcj.CJID;
                        //rowylmx["kcl"] = 0;
                        rowylmx["删除"] = "删除";
                        rowylmx["jsph"] = "F";
                        //row2["djid"];
                        //row2["djh"];
                        //tbylmx.Rows.Add(rowylmx);
                    }
                    #endregion

                    //插入原料消耗行 如果该计划已有原料消耗明细
                    //如果一行都没有，则插入到第一行
                    //如果当前行jhmxid等于dgjhmx中id，判断下一行jhmxid是否等于dgjhmx中id
                    //如果等于，则继续循环；如果不等于，则在当前行的下一行插入原料消耗明细 
                    //如果循环到最后一行，则在最后位置插入一行；
                    int index = 0;
                    int pxxh = 0;

                    for (int i = 0; i < tbylmx.Rows.Count; i++)
                    {
                        if (i == tbylmx.Rows.Count - 1)
                        {
                            index = tbylmx.Rows.Count;
                        }
                        else
                        {
                            if (tbylmx.Rows[i]["jhmxid"].ToString() == rowylmx["jhmxid"].ToString())
                            {
                                if (tbylmx.Rows[i + 1]["jhmxid"].ToString() != rowylmx["jhmxid"].ToString())
                                {
                                    index = i + 1;
                                    break;
                                }
                            }
                        }
                    }


                    //生成排序序号
                    for (int i = 0; i < tbylmx.Rows.Count; i++)
                    {
                        if (tbylmx.Rows[i]["jhmxid"].ToString() == jhmxid.ToString())
                        {
                            int temp = Convert.ToInt32(tbylmx.Rows[i]["pxxh"].ToString());
                            if (pxxh < temp)
                            {
                                pxxh = temp;
                            }
                        }
                    }
                    pxxh += 1;

                    rowylmx["pxxh"] = pxxh;
                    tbylmx.Rows.InsertAt(rowylmx, index);
                    dgYlmx.CurrentCell = dgYlmx.Rows[index].Cells["csl"];  //dgylmx定位到添加行的【数量】单元格

                }
                #endregion

                #region 定位原料消耗明细
                tbjhmx = (DataTable)dgjhmx.DataSource;
                tbylmx = (DataTable)dgYlmx.DataSource;
                for (int i = 0; i < tbylmx.Rows.Count; i++)
                {
                    if (tbylmx.Rows[i]["jhmxid"].ToString() == jhmxid.ToString())
                    {
                        dgYlmx.Rows[i].Cells["cypdw"].Style.ForeColor = Color.Red;
                        dgYlmx.Rows[i].Cells["csl"].Style.ForeColor = Color.Red;
                        if (jh.bshbz == 0 || jh.bshbz == 1)
                            dgYlmx.Rows[i].Selected = true;
                    }
                    else
                    {
                        dgYlmx.Rows[i].Cells["cypdw"].Style.ForeColor = Color.Black;
                        dgYlmx.Rows[i].Cells["csl"].Style.ForeColor = Color.Black;
                        dgYlmx.Rows[i].Selected = false;
                    }
                }

                if (dgjhmx.Columns[e.ColumnIndex].Name != "col_添加原料")
                {
                    for (int i = 0; i < tbylmx.Rows.Count; i++)
                    {
                        if (tbylmx.Rows[i]["jhmxid"].ToString() == jhmxid.ToString())
                        {
                            dgYlmx.CurrentCell = dgYlmx.Rows[i].Cells["csl"];
                            break;
                        }
                    }
                }
                #endregion
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        //修改原料明细数量完毕时，判断库存是否足够
        private void dgYlmx_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tbylmx = (DataTable)dgYlmx.DataSource;
                int rowIndex = e.RowIndex;
                int colIndex = e.ColumnIndex;
                if (tbylmx.Columns[colIndex].ColumnName=="sl")
                {
                    if (!Convertor.IsNumeric(dgYlmx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        //dgYlmx.Rows[rowIndex].Cells[colIndex].Value = 0;
                        tbylmx.Rows[rowIndex][colIndex] = 0;
                    }
                    try
                    {
                        Convert.ToDecimal(dgYlmx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    }
                    catch 
                    {
                        //MessageBox.Show("原料明细数量必须为数字");
                        //dgYlmx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        tbylmx.Rows[rowIndex][colIndex] = 0;
                        return;
                    }

                    decimal sl = Convert.ToDecimal(dgYlmx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (sl <= 0)
                    {
                        //MessageBox.Show("原料明细数量必须大于0");
                        sl = 0;
                        return;
                    }
                    object obj = tbylmx.Rows[rowIndex][colIndex];
                    if (!(obj is DBNull))
                    {
                        decimal kcl = Convert.ToDecimal(tbylmx.Rows[rowIndex]["KCL"]);
                        if (sl > kcl)
                        {
                            MessageBox.Show("库存不足！");
                            //dgYlmx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = kcl;
                            tbylmx.Rows[rowIndex][colIndex] = kcl.ToString("0.000");
                            dgYlmx.CurrentCell = dgYlmx.Rows[e.RowIndex].Cells["csl"];
                        }
                    }
                }
            }
        }

        private void dgjhmx_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgjhmx.CurrentCell == null) return;
                if (dgjhmx.Columns[dgjhmx.CurrentCell.ColumnIndex].Name == col_删除.Name) return;
                int nrow = this.dgjhmx.CurrentCell.RowIndex;
                tbjhmx = (DataTable)this.dgjhmx.DataSource;
                if (nrow >= tbjhmx.Rows.Count)
                {
                    DataRow nullrow = tbjhmx.NewRow();
                    this.Getrow(nullrow);
                    return;
                }
                else
                {
                    DataRow row = tbjhmx.Rows[nrow];
                    Getrow(row);
                    this.butadd.Enabled = false;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //原料明细单元格单击事件 
        private void dgYlmx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            if (e.RowIndex >= 0)
            {
                if (dgYlmx.Columns[e.ColumnIndex].Name == "c删除") //删除行
                {
                    if (dgYlmx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                        return;
                    tbylmx.Rows.RemoveAt(e.RowIndex);
                }

                if (dgYlmx.Columns[e.ColumnIndex].Name == "cjsph")//检索批号
                {
                    try
                    {
                        int deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")); //库房id
                        if (dgYlmx.Rows[e.RowIndex].Cells["c删除"].Value.ToString() == "") return;
                        if (dgYlmx.Rows[e.RowIndex].Cells["ccjid"].Value.ToString() == "") return;
                        DataGridViewCell dgCellPh = dgYlmx.Rows[e.RowIndex].Cells["cph"];
                        int cellX = dgYlmx.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;
                        int cellY = dgYlmx.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Y;
                        int dgvX = dgYlmx.Location.X;
                        int dgvY = dgYlmx.Location.Y;
                        int cjid = Convert.ToInt32(Convertor.IsNull(dgYlmx.Rows[e.RowIndex].Cells["ccjid"].Value, "0"));
                        string[] GrdMappingName ={ "行号", "库存量", "单位", "批号", "效期", "进货价", "库位", "kwid" };
                        int[] GrdWidth ={ 0, 80, 40, 75, 100, 75, 0, 0 };
                        string[] sfield ={ "", "", "", "", "" };
                        string ssql = "select 0 rowno,kcl,dbo.fun_yp_ypdw(zxdw),ypph,ypxq,jhj,'' kwmc,kwid  from " + Yp.Seek_kcph_table(Convert.ToInt32(Convertor.IsNull(deptid, "0")), InstanceForm.BDatabase)
                            + "  where kcl>0 and deptid=" + Convert.ToInt32(Convertor.IsNull(deptid, "0")) + " and cjid=" + cjid + " and (bdelete=0 or (bdelete=1 and kcl<>0))";
                        TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, "".Trim(), ssql, InstanceForm.BDatabase);
                        Point point = new Point(this.Location.X + cellX, this.Location.Y + cellY + dgCellPh.Size.Height * 8 - 10);
                        f2.Location = point;
                        //f2.Width = 700;
                        f2.ShowDialog(this);
                        DataRow row11 = f2.dataRow;
                        if (row11 != null)
                        {
                            if (row11["ypxq"].ToString().Trim() != "")
                                dgYlmx.Rows[e.RowIndex].Cells["cxq"].Value = Convert.ToDateTime(row11["ypxq"].ToString());//效期
                            dgYlmx.Rows[e.RowIndex].Cells["cph"].Value = Convert.ToString(row11["ypph"]);//批号
                            dgYlmx.Rows[e.RowIndex].Cells["cjhj"].Value = Convert.ToDecimal(row11["jhj"].ToString()).ToString("0.000");//进货价
                            dgYlmx.Rows[e.RowIndex].Cells["cpfj"].Value = new Ypcj(cjid, InstanceForm.BDatabase).PFJ.ToString("0.000");//批发价
                            dgYlmx.Rows[e.RowIndex].Cells["ckcl"].Value = Convert.ToDecimal(row11["kcl"].ToString()).ToString("0.000");//库存量
                            tbylmx.Rows[e.RowIndex]["xq"] = Convert.ToDateTime(row11["ypxq"].ToString());//效期
                            tbylmx.Rows[e.RowIndex]["ph"] = Convert.ToString(row11["ypph"]);//批号
                            tbylmx.Rows[e.RowIndex]["jhj"] = 0;//Convert.ToDecimal(row11["jhj"].ToString()).ToString("0.000");//进货价
                            tbylmx.Rows[e.RowIndex]["pfj"] = new Ypcj(cjid, InstanceForm.BDatabase).PFJ.ToString("0.000");//批发价
                            tbylmx.Rows[e.RowIndex]["kcl"] = row11["kcl"];//库存量

                            //判断库存量是否充足 不足的话只给最大库存量
                            decimal sl = Convert.ToDecimal(dgYlmx.Rows[e.RowIndex].Cells["csl"].Value);
                            if (sl <= 0)
                            {
                                sl = 0;
                                return;
                            }
                            object obj = tbylmx.Rows[e.RowIndex]["sl"];
                            if (!(obj is DBNull))
                            {
                                decimal kcl = Convert.ToDecimal(tbylmx.Rows[e.RowIndex]["KCL"]);
                                if (sl > kcl)
                                {
                                    MessageBox.Show("库存不足！");
                                    //dgYlmx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = kcl;
                                    tbylmx.Rows[e.RowIndex]["sl"] = kcl.ToString("0.000");
                                    dgYlmx.CurrentCell = dgYlmx.Rows[e.RowIndex].Cells["csl"];
                                }
                            }


                            dgYlmx.CurrentCell = dgYlmx.Rows[e.RowIndex].Cells["csl"];  //定位到数量
                            //dgYlmx.CurrentCell.Tag = row11["kcl"]; //数量
                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show("发生错误" + err.ToString());
                    }
                }
            }
        }

        //单击dgylmx
        private void dgYlmx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            if (e.RowIndex >= 0)
            {
                #region 定位计划明细
                Guid jhmxid = new Guid(dgYlmx.Rows[e.RowIndex].Cells["cjhmxid"].Value.ToString());
                for (int i = 0; i < dgjhmx.Rows.Count; i++)
                {
                    if (dgjhmx.Rows[i].Cells["col_id"].Value.ToString() == jhmxid.ToString())
                    {
                        dgjhmx.CurrentCell = dgjhmx.Rows[i].Cells["col_yppm"];
                        break;
                    }
                }

                for(int i=0;i<dgYlmx.Rows.Count;i++)
                {
                    if(dgYlmx.Rows[i].Cells["cjhmxid"].Value.ToString()==jhmxid.ToString())
                    {
                        dgYlmx.Rows[i].Cells["cypdw"].Style.ForeColor = Color.Red;
                        dgYlmx.Rows[i].Cells["csl"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dgYlmx.Rows[i].Cells["cypdw"].Style.ForeColor = Color.Black;
                        dgYlmx.Rows[i].Cells["csl"].Style.ForeColor = Color.Black;
                    }
                }

                #endregion

                //string ss= Convertor.IsNull( dgYlmx.Rows[e.RowIndex].Cells["cxq"].Value,DateTime.Now.ToShortDateString());
                //dtpxq.Value=Convert.ToDateTime(ss);
                //点击原料品名
                if (dgYlmx.Columns[e.ColumnIndex].Name == cyppm.Name)
                {
                    try
                    {
                        if (jh.bshbz != -1) return;
                        int deptid = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")); //库房id
                        //if (dgYlmx.Rows[e.RowIndex].Cells["c删除"].Value.ToString() == "") return;
                        //if (dgYlmx.Rows[e.RowIndex].Cells["ccjid"].Value.ToString() == "") return;
                        DataGridViewCell dgCellPh = dgYlmx.Rows[e.RowIndex].Cells["cph"];
                        int cellX = dgYlmx.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;
                        int cellY = dgYlmx.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Y;
                        int dgvX = dgYlmx.Location.X;
                        int dgvY = dgYlmx.Location.Y;
                        //int cjid = Convert.ToInt32(Convertor.IsNull(dgYlmx.Rows[e.RowIndex].Cells["ccjid"].Value, "0"));

                        #region 获取原料所在物资子类型
                        //参数：8042  值：1,2|3,4  中药加工成品原料对应药品子类型: 前面的是成品子类型，后面的是原料子类型
                        //原料 跟成品名称必须一致
                        //Guid jhmxid =new Guid(dgYlmx.Rows[e.RowIndex].Cells["cjhmxid"].Value.ToString()); //计划明细id

                        //获取计划明细中的成品厂家id
                        tbjhmx=(DataTable)dgjhmx.DataSource;
                        int cpcjid=0;
                        foreach(DataRow row in tbjhmx.Rows)
                        {
                            if(row["id"].ToString()==jhmxid.ToString())
                            {
                                cpcjid=Convert.ToInt32(row["cjid"]);
                            }
                        }
                        Ypcj cpYpcj=new Ypcj(cpcjid,db);
                        Ypgg cpgg=new Ypgg(cpYpcj.GGID,db); //成品规格
                        int cpzlx = cpgg.YPZLX;//成品所属药品子类型
                        string strYlzlx = "";//原料所属药品子类型
                        Ypcj ylYpcj = null;

                        #region 获取对应原料所属药品类型
                        DataTable dtConfig = db.GetDataTable(string.Format(" select config from jc_config where id = 8042 ",8042));
                        if (dtConfig.Rows.Count > 0)
                        {
                            string strCfg = dtConfig.Rows[0][0].ToString();

                            string[] strs = strCfg.Split('|');
                            string strCp = strs[0];
                            string strYl = strs[1];

                            string[] scps = strCp.Split(',');
                            string[] syls = strYl.Split(',');

                            List<string> lstTemp = new List<string>();
                            for (int i = 0; i < scps.Length; i++)
                            {
                                if (cpzlx == Convert.ToInt32(scps[i]))
                                {
                                    lstTemp.Add(syls[i].ToString());
                                }
                            }

                            if (lstTemp.Count > 0)
                            {
                                for (int m = 0; m < lstTemp.Count; m++)
                                {
                                    if (m == 0)
                                    {
                                        strYlzlx = "(" + lstTemp[m];
                                    }
                                    else
                                    {
                                        strYlzlx += lstTemp[m];
                                    }
                                    if (m == lstTemp.Count - 1)
                                    {
                                        strYlzlx += ")";
                                    }
                                }
                            }
                        }
                        #endregion

                        #endregion

                        string[] GrdMappingName ={ "行号", "品名", "规格", "厂家", "单位", "库存量", "子类型", "批号", "效期", "进货价", "库位", "kwid", "cjid" };
                        int[] GrdWidth ={ 0, 120, 80, 80, 40, 80, 60, 75, 100, 75, 0, 0, 0 };

                        string[] sfield = new string[] { "b.wbm", "b.pym", "b.szm", "b.ywm", "b.ypbm" };
                        string ssql = @"select 0 rowno,b.s_yppm,b.s_ypgg,b.s_sccj,dbo.fun_yp_ypdw(a.zxdw),a.kcl,c.mc ypzlx, a.ypph,a.ypxq,a.jhj,'' kwmc,a.kwid,a.cjid  from " 
                            + Yp.Seek_kcph_table(Convert.ToInt32(Convertor.IsNull(deptid, "0")), InstanceForm.BDatabase)
                            + " a inner join vi_yp_ypcd b on a.cjid=b.cjid  inner join yp_ypzlx c on c.id=b.n_ypzlx  where kcl>0 and deptid=" 
                            + Convert.ToInt32(Convertor.IsNull(deptid, "0")) 
                            //+ " and cjid=" + cjid 
                            + " and (a.bdelete=0 or (a.bdelete=1 and a.kcl<>0))";

                        if(strYlzlx!=string.Empty)
                        {
                            ssql+=string.Format(" and c.id in{0} ",strYlzlx);
                        }

                        TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, "".Trim(), ssql, InstanceForm.BDatabase);
                        Point point = new Point(this.Location.X + cellX, this.Location.Y + cellY + dgCellPh.Size.Height * 8 - 10);
                        f2.Location = point;
                        f2.Width = 700;
                        f2.ShowDialog(this);
                        DataRow row11 = f2.dataRow;
                        if (row11 != null)
                        {
                            if (row11["ypxq"].ToString().Trim() != "")
                            {
                                dgYlmx.Rows[e.RowIndex].Cells["cxq"].Value = Convert.ToDateTime(row11["ypxq"].ToString());//效期
                            }
                            int cjid = Convert.ToInt32(row11["cjid"]);
                            Ypcj cj = new Ypcj(cjid, db);
                           
                            //dgYlmx.Rows[e.RowIndex].Cells["cph"].Value = Convert.ToString(row11["ypph"]);//批号
                            //dgYlmx.Rows[e.RowIndex].Cells["cjhj"].Value = Convert.ToDecimal(row11["jhj"].ToString()).ToString("0.000");//进货价
                            //dgYlmx.Rows[e.RowIndex].Cells["cpfj"].Value = new Ypcj(cjid, InstanceForm.BDatabase).PFJ.ToString("0.000");//批发价

                            tbylmx.Rows[e.RowIndex]["cjid"] = cjid;
                            tbylmx.Rows[e.RowIndex]["yppm"] = cj.S_YPPM;//品名
                            tbylmx.Rows[e.RowIndex]["ypgg"] = cj.S_YPGG;//规格
                            tbylmx.Rows[e.RowIndex]["sccj"] = cj.S_SCCJ;//厂家
                            tbylmx.Rows[e.RowIndex]["ypdw"] = cj.S_YPDW;//单位
                            tbylmx.Rows[e.RowIndex]["nypdw"] = Yp.SeekYpdw(tbylmx.Rows[e.RowIndex]["ypdw"].ToString(), InstanceForm.BDatabase);
                            tbylmx.Rows[e.RowIndex]["ydwbl"] = 1;
                            tbylmx.Rows[e.RowIndex]["kcl"] = Convert.ToDecimal(row11["kcl"]).ToString();
                            tbylmx.Rows[e.RowIndex]["xq"] = Convert.ToDateTime(row11["ypxq"].ToString());//效期
                            tbylmx.Rows[e.RowIndex]["ph"] = Convert.ToString(row11["ypph"]);//批号
                            tbylmx.Rows[e.RowIndex]["jhj"] = 0;// Convert.ToDecimal(row11["jhj"].ToString()).ToString("0.000");//进货价
                            tbylmx.Rows[e.RowIndex]["pfj"] = cj.PFJ.ToString("0.000");//批发价
                            tbylmx.Rows[e.RowIndex]["lsj"] = cj.LSJ.ToString("0.000");//零售价
                            dgYlmx.CurrentCell.Tag = row11["kcl"]; //数量
                            dgYlmx.Refresh();
                            dgYlmx.CurrentCell = dgYlmx.Rows[e.RowIndex].Cells["csl"];  //定位到数量
                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show("发生错误" + err.ToString());
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dtpxq.value:" + dtpxq.Value.ToString()+"\n"+"dtpxq2.value:"+dtpxq.Value.ToString());
            
        }

        private void txtjhsl_Leave(object sender, EventArgs e)
        {
            if (Convertor.IsNumeric(this.txtjhsl.Text) == false || txtcpsl.Text != string.Empty)
                return;
            else
            {
                txtcpsl.Text = txtjhsl.Text;
            }
            
        }

	}

    class Kcph
    {
       public int cjid;
       public decimal sl;
       public string ph;
       public DateTime xq;
       public decimal kcl;
       public Kcph(int cjid,decimal sl,string ph,DateTime xq,decimal kcl)
       {
           this.cjid = cjid;
           this.sl = sl;
           this.ph = ph;
           this.xq = xq;
           this.kcl = kcl;
       }
    }
}
