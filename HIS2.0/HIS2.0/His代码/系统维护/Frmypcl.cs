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

namespace ts_yp_xtwh
{
	/// <summary>
	/// Frmkccx 的摘要说明。
	/// </summary>
	public class Frmypcl : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.GroupBox groupBox1;
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
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.Label lblgmp;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label lblkc;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label lbllsj;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label lblpfj;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox cmbdw;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label lblhh;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lblypmc;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label lblcj;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lblgg;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtypdm;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtdwbl;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.TextBox txtdm;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.TextBox txtzxdw;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.DataGridTextBoxColumn 库存量;
        private RadioButton rdowcl;
        private RadioButton rdoycl;
        private RadioButton rdoall;
        private Panel panel1;
        private Panel panel2;
        private ComboBox cmbyjks;
        private Label label4;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmypcl(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;
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
            this.rdowcl = new System.Windows.Forms.RadioButton();
            this.rdoycl = new System.Windows.Forms.RadioButton();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.txtzxdw = new System.Windows.Forms.TextBox();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdwbl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblgmp = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.lblkc = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
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
            this.butsave = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.库存量 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdowcl);
            this.groupBox1.Controls.Add(this.rdoycl);
            this.groupBox1.Controls.Add(this.rdoall);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtzxdw);
            this.groupBox1.Controls.Add(this.txtdm);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtdwbl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblgmp);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.lblkc);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.lbllsj);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.lblpfj);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.cmbdw);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.lblhh);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.lblypmc);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblcj);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblgg);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtypdm);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.butsave);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // rdowcl
            // 
            this.rdowcl.AutoSize = true;
            this.rdowcl.Location = new System.Drawing.Point(719, 99);
            this.rdowcl.Name = "rdowcl";
            this.rdowcl.Size = new System.Drawing.Size(73, 19);
            this.rdowcl.TabIndex = 96;
            this.rdowcl.Text = "未拆零";
            this.rdowcl.UseVisualStyleBackColor = true;
            // 
            // rdoycl
            // 
            this.rdoycl.AutoSize = true;
            this.rdoycl.Location = new System.Drawing.Point(629, 99);
            this.rdoycl.Name = "rdoycl";
            this.rdoycl.Size = new System.Drawing.Size(73, 19);
            this.rdoycl.TabIndex = 95;
            this.rdoycl.Text = "已拆零";
            this.rdoycl.UseVisualStyleBackColor = true;
            // 
            // rdoall
            // 
            this.rdoall.AutoSize = true;
            this.rdoall.Checked = true;
            this.rdoall.Location = new System.Drawing.Point(557, 99);
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size(58, 19);
            this.rdoall.TabIndex = 94;
            this.rdoall.TabStop = true;
            this.rdoall.Text = "全部";
            this.rdoall.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(981, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 92;
            this.button1.Text = "查询(&C)";
            this.button1.Click += new System.EventHandler(this.butcx_Click);
            // 
            // txtzxdw
            // 
            this.txtzxdw.Location = new System.Drawing.Point(107, 93);
            this.txtzxdw.Name = "txtzxdw";
            this.txtzxdw.Size = new System.Drawing.Size(96, 25);
            this.txtzxdw.TabIndex = 2;
            this.txtzxdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtzxdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtdm
            // 
            this.txtdm.Location = new System.Drawing.Point(867, 95);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(106, 25);
            this.txtdm.TabIndex = 90;
            this.txtdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdm_KeyUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(829, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 21);
            this.label3.TabIndex = 91;
            this.label3.Text = "查询";
            // 
            // txtdwbl
            // 
            this.txtdwbl.Location = new System.Drawing.Point(281, 93);
            this.txtdwbl.Name = "txtdwbl";
            this.txtdwbl.Size = new System.Drawing.Size(82, 25);
            this.txtdwbl.TabIndex = 3;
            this.txtdwbl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(208, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 89;
            this.label2.Text = "拆零系数";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 87;
            this.label1.Text = "拆零单位";
            // 
            // lblgmp
            // 
            this.lblgmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblgmp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgmp.ForeColor = System.Drawing.Color.Navy;
            this.lblgmp.Location = new System.Drawing.Point(768, 62);
            this.lblgmp.Name = "lblgmp";
            this.lblgmp.Size = new System.Drawing.Size(116, 25);
            this.lblgmp.TabIndex = 85;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(736, 62);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(40, 20);
            this.label46.TabIndex = 84;
            this.label46.Text = "GMP";
            // 
            // lblkc
            // 
            this.lblkc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkc.ForeColor = System.Drawing.Color.Navy;
            this.lblkc.Location = new System.Drawing.Point(960, 62);
            this.lblkc.Name = "lblkc";
            this.lblkc.Size = new System.Drawing.Size(96, 25);
            this.lblkc.TabIndex = 83;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(896, 62);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(64, 20);
            this.label36.TabIndex = 82;
            this.label36.Text = "库存量";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(565, 62);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(150, 25);
            this.lbllsj.TabIndex = 81;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(501, 62);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 20);
            this.label23.TabIndex = 80;
            this.label23.Text = "零售价";
            // 
            // lblpfj
            // 
            this.lblpfj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpfj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfj.ForeColor = System.Drawing.Color.Navy;
            this.lblpfj.Location = new System.Drawing.Point(331, 62);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.Size = new System.Drawing.Size(160, 25);
            this.lblpfj.TabIndex = 79;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(277, 62);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 20);
            this.label20.TabIndex = 78;
            this.label20.Text = "批发价";
            // 
            // cmbdw
            // 
            this.cmbdw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdw.ForeColor = System.Drawing.Color.Navy;
            this.cmbdw.Location = new System.Drawing.Point(107, 62);
            this.cmbdw.Name = "cmbdw";
            this.cmbdw.Size = new System.Drawing.Size(138, 23);
            this.cmbdw.TabIndex = 1;
            this.cmbdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(32, 62);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 20);
            this.label19.TabIndex = 77;
            this.label19.Text = "药库单位";
            // 
            // lblhh
            // 
            this.lblhh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblhh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblhh.ForeColor = System.Drawing.Color.Navy;
            this.lblhh.Location = new System.Drawing.Point(960, 31);
            this.lblhh.Name = "lblhh";
            this.lblhh.Size = new System.Drawing.Size(96, 26);
            this.lblhh.TabIndex = 76;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(907, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 20);
            this.label18.TabIndex = 75;
            this.label18.Text = "货号";
            // 
            // lblypmc
            // 
            this.lblypmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblypmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblypmc.ForeColor = System.Drawing.Color.Navy;
            this.lblypmc.Location = new System.Drawing.Point(331, 31);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(224, 26);
            this.lblypmc.TabIndex = 74;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(256, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 20);
            this.label16.TabIndex = 73;
            this.label16.Text = "药品名称";
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(768, 31);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(116, 26);
            this.lblcj.TabIndex = 72;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(725, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 20);
            this.label14.TabIndex = 71;
            this.label14.Text = "厂家";
            // 
            // lblgg
            // 
            this.lblgg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblgg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgg.ForeColor = System.Drawing.Color.Navy;
            this.lblgg.Location = new System.Drawing.Point(597, 31);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(112, 26);
            this.lblgg.TabIndex = 70;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(555, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 20);
            this.label12.TabIndex = 69;
            this.label12.Text = "规格";
            // 
            // txtypdm
            // 
            this.txtypdm.ForeColor = System.Drawing.Color.Navy;
            this.txtypdm.Location = new System.Drawing.Point(107, 31);
            this.txtypdm.Name = "txtypdm";
            this.txtypdm.Size = new System.Drawing.Size(138, 25);
            this.txtypdm.TabIndex = 0;
            this.txtypdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtypdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(32, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 20);
            this.label10.TabIndex = 67;
            this.label10.Text = "药品代码";
            // 
            // butsave
            // 
            this.butsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butsave.ForeColor = System.Drawing.Color.Navy;
            this.butsave.Location = new System.Drawing.Point(365, 93);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(75, 30);
            this.butsave.TabIndex = 4;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butquit
            // 
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(451, 93);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(74, 30);
            this.butquit.TabIndex = 5;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(151, 189);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 31);
            this.checkBox1.TabIndex = 93;
            this.checkBox1.Text = "仅拆零药品";
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 21);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(819, 281);
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
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.库存量,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn11});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 35;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "品名";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.Width = 90;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "厂家";
            this.dataGridTextBoxColumn4.Width = 90;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "批发价";
            this.dataGridTextBoxColumn6.Width = 70;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "零售价";
            this.dataGridTextBoxColumn7.Width = 70;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "药库单位";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 60;
            // 
            // 库存量
            // 
            this.库存量.Format = "";
            this.库存量.FormatInfo = null;
            this.库存量.HeaderText = "库存量";
            this.库存量.ReadOnly = true;
            this.库存量.Width = 60;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "折零单位";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 60;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "折零系数";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 60;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "货号";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "CJID";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 0;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "ggid";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 0;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 502);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(825, 31);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 305);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存药品";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbyjks);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 441);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 61);
            this.panel1.TabIndex = 3;
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(129, 17);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(150, 23);
            this.cmbyjks.TabIndex = 9;
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(52, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "药剂科室";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 136);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 305);
            this.panel2.TabIndex = 4;
            // 
            // Frmypcl
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(825, 533);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmypcl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "药品拆零";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmkccx_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		private void butcx_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=new DataTable("Tb");
				string ssql="";
                //if (this.checkBox1.Checked==false)
                //{
                     //ssql="select 0 序号,yppm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家,pfj 批发价,lsj 零售价,"+
                     //   " dbo.fun_yp_ypdw(a.ypdw) 药库单位,kcl 库存量,dbo.fun_yp_ypdw(b.zxdw) 折零单位,b.dwbl 折零系数 "+
                     //   " ,shh 货号,a.cjid,a.ggid from vi_yf_kcmx a "+
                     //   " left join yp_ypcl b on a.cjid=b.cjid and a.deptid=b.deptid  where a.ggid in(select ggid from yp_ypbm where upper(pym) like '"+txtdm.Text.Trim().ToUpper()+"%'"+
                     //   " or upper(wbm) like '"+txtdm.Text.Trim().ToUpper()+"%' or upper(ypbm) like '%"+txtdm.Text.Trim().ToUpper()+"%') and a.deptid="+InstanceForm.BCurrentDept.DeptId+" ";
                //}
                //else
                //{
                //    ssql="select 0 序号,yppm 品名,ypgg 规格,dbo.fun_yp_sccj(sccj) 厂家,cast(round(pfj/b.dwbl,4) as decimal(10,4)) 批发价,cast(round(lsj/b.dwbl,4) as decimal(10,4)) 零售价,"+
                //        " dbo.fun_yp_ypdw(a.ypdw) 药库单位,c.kcl 库存量,dbo.fun_yp_ypdw(b.zxdw) 折零单位,b.dwbl 折零系数 "+
                //        " ,shh 货号,a.cjid,a.ggid from vi_yp_ypcd a inner join yp_ypcl b on a.cjid=b.cjid and b.deptid="+InstanceForm.BCurrentDept.DeptId+" " +
                //        " left join yf_kcmx c on b.cjid=c.cjid and c.deptid="+InstanceForm.BCurrentDept.DeptId+" where a.ggid in(select ggid from yp_ypbm where upper(pym) like '"+txtdm.Text.Trim().ToUpper()+"%'"+
                //        " or upper(wbm) like '"+txtdm.Text.Trim().ToUpper()+"%' or upper(ypbm) like '%"+txtdm.Text.Trim().ToUpper()+"%')";

                //}

                 ssql = "select 0 序号,yppm 品名,ypgg 规格,s_sccj 厂家,pfj 批发价,lsj 零售价," +
                         " s_ypdw 药库单位,kcl 库存量,dbo.fun_yp_ypdw(b.zxdw) 折零单位,b.dwbl 折零系数 " +
                         " ,shh 货号,a.cjid,a.ggid from vi_yp_ypcd a " +
                         " left join yp_ypcl b on a.cjid=b.cjid and b.deptid=" + Convertor.IsNull(cmbyjks.SelectedValue, "0") +
                         " left join yf_kcmx c on b.cjid=c.cjid and c.deptid=" + Convertor.IsNull(cmbyjks.SelectedValue, "0") + 
                          "  where a.cjid>0  and ypzlx in(select ypzlx from yp_gllx where deptid="+ Convertor.IsNull(cmbyjks.SelectedValue, "0")+")  ";

				if (this.rdoycl.Checked==true){ssql=ssql+" and b.dwbl>1";}
                if (this.rdowcl.Checked == true) { ssql = ssql + " and (b.dwbl<=1 or b.dwbl is null )"; }
                if (txtdm.Text.Trim() != "")
                {
                    ssql = ssql + " and a.ggid in(select ggid from yp_ypbm where upper(pym) like '" + txtdm.Text.Trim().ToUpper() + "%'" +
                         " or upper(wbm) like '" + txtdm.Text.Trim().ToUpper() + "%' or upper(ypbm) like '%" + txtdm.Text.Trim().ToUpper() + "%') ";
                }

				tb=InstanceForm.BDatabase.GetDataTable(ssql);
				FunBase.AddRowtNo(tb);
				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;
				this.myDataGrid1.TableStyles[0].MappingName="Tb";
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void Frmkccx_Load(object sender, System.EventArgs e)
		{
			try
			{
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");

                Yp.AddcmbYjks(cmbyjks,DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                if (InstanceForm.BCurrentUser.IsAdministrator == false) { cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId; cmbyjks.Enabled = false; }

			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
		}

		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//输入框控制事件
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" ){control.Text="";control.Tag="0";}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)==""))){	}
			else{return;}

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
					case 0:
						if (control.Text.Trim()=="") return;
						GrdMappingName=new string[] {"ggid","cjid","行号","品名","规格","厂家","单位","DWBL","批发价","零售价","货号"};
						GrdWidth=new int[] {0,0,50,200,100,100,40,0,60,60,70};
						sfield=new string[] {"wbm","pym","szm","ywm","ypbm"};
//						ssql="select a.ggid,cjid,ROW_NUMBER() OVER() rowno,ypspm,ypgg,dbo.fun_yp_sccj(sccj) sccj,dbo.fun_yp_ypdw(ypdw) ypdw,"+
//							" 1 dwbl,pfj,lsj,shh from vi_yp_ypcd a,yp_ypbm b where a.ggid=b.ggid and a.bdelete=0 and a.ypzlx in(select ypzlx from yp_gllx where deptid="+InstanceForm.BCurrentDept.DeptId+")  ";
                        ssql = "select distinct a.ggid,cjid,0 rowno,s_ypspm,s_ypgg,s_sccj,s_ypdw," +
							" 1 dwbl,pfj,lsj,shh from yp_ypcjd a,yp_ypbm b where a.ggid=b.ggid and a.bdelete=0 and a.n_ypzlx in(select ypzlx from yp_gllx where deptid="+Convertor.IsNull(cmbyjks.SelectedValue,"0")+")  ";
						TrasenFrame.Forms.Fshowcard  f2=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,Constant.CustomFilterType,control.Text.Trim(),ssql);
						f2.Location=point;
						f2.ShowDialog(this);
						row=f2.dataRow;
						if (row!=null) 
						{
							this.csyp(Convert.ToInt32(row["ggid"]),Convert.ToInt32(row["cjid"]));
							this.SelectNextControl((Control)sender,true,false,true,true);
							
						}
						break;
					case 2:
						if (nkey==13 && (control.Tag.ToString()!="" && control.Tag.ToString()!="0")) return;
						GrdMappingName=new string[] {"标识","名称"};
						GrdWidth=new int[] {100,200};
						sfield=new string[] {"wbm","pym","","",""};
						ssql="select id,dwmc from yp_ypdw where id<>0 ";
						TrasenFrame.Forms.Fshowcard f3=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,FilterType.拼音,control.Text.Trim(),ssql);
						f3.Location=point;
						f3.ShowDialog(this);
						row=f3.dataRow;
						if (row!=null) 
						{
							control.Text=row["dwmc"].ToString();
							control.Tag =row["ID"].ToString();
							this.SelectNextControl((Control)sender,true,false,true,true);

						}
						break;

				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}

		// 回车跳至下一个文本
		private void GotoNext(object sender, KeyPressEventArgs e)
		{ 
			Control control=(Control)sender;
			if (e.KeyChar==13 )
			{
				this.SelectNextControl(control,true,false,true,true);
			}
		}

		//初始药品
		private void csyp(int ggid,int cjid)
		{
			try
			{
                Ypgg ydgg = new Ypgg(ggid, InstanceForm.BDatabase);
                Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
				this.lblypmc.Tag=ydcj.CJID.ToString();
				this.lblypmc.Text=ydcj.S_YPSPM;
				this.lblgg.Text=ydcj.S_YPGG;
				this.lblcj.Text=ydcj.S_SCCJ;
				this.lblhh.Text=ydcj.SHH;
				this.lblpfj.Text=ydcj.PFJ.ToString();
				this.lbllsj.Text=ydcj.LSJ.ToString() ;
				this.lblpfj.Tag=ydcj.PFJ.ToString();
				this.lbllsj.Tag=ydcj.LSJ.ToString() ;
				cmbdw.Items.Clear();
				cmbdw.Items.Add(ydcj.S_YPDW);
				cmbdw.SelectedIndex=0;
				cmbdw.Tag=ydgg.YPDW.ToString();
                DataTable tb = Yp.SelectYpcl(Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")), ydcj.CJID, InstanceForm.BDatabase);
                if (tb.Rows.Count > 0)
                {
                    txtzxdw.Text = Yp.SeekYpdw(Convert.ToInt32(tb.Rows[0]["zxdw"]), InstanceForm.BDatabase);
                    txtzxdw.Tag = tb.Rows[0]["zxdw"].ToString();
                    txtdwbl.Text = tb.Rows[0]["dwbl"].ToString();
                }
                else
                {
                    txtzxdw.Text = "";
                    txtzxdw.Tag = "";
                    txtdwbl.Text = "";
                }

                this.lblkc.Text = Yp.SeekKcZh(Convert.ToInt32(Convertor.IsNull(txtdwbl.Text, "0")), ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void txtdm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (Convert.ToInt32(e.KeyCode)==13)
			{
				this.butcx_Click(sender,e);
			}
		}

		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				if (nrow>tb.Rows.Count-1) return;
				this.csyp(Convert.ToInt32(tb.Rows[nrow]["ggid"]),Convert.ToInt32(tb.Rows[nrow]["cjid"]));
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}

		private void csgroupbox2()
		{
			for(int i=0;i<=this.groupBox2.Controls.Count-1;i++)
			{
				if (this.groupBox2.Controls[i].GetType().ToString()=="System.Windows.Forms.TextBox")
				{
					this.groupBox2.Controls[i].Text="";
					this.groupBox2.Controls[i].Tag="0";
				}
			}
			this.lblypmc.Text="";
			this.lblypmc.Tag="0";
			this.lblgg.Text="";
			this.lblcj.Text="";
			this.lblhh.Text="";
			this.lblpfj.Text="";
			this.lbllsj.Text="";
			this.lblpfj.Tag="";
			this.lbllsj.Tag ="";
			this.lblkc.Text="";
			this.lblgmp.Text="";
			this.cmbdw.DataSource=null;
			txtzxdw.Text="";
			txtzxdw.Tag="0";
			this.txtdwbl.Text="";
			this.txtypdm.Focus();
		}

		private void butsave_Click(object sender, System.EventArgs e)
		{
		
			if (txtdwbl.Text.Trim()=="" || Convertor.IsNumeric(txtdwbl.Text.Trim())==false || Convert.ToInt32(Convertor.IsNull(txtdwbl.Text,"0"))==0)
			{
				MessageBox.Show("折零系数输入不正确");
				return;
			}

			if (txtzxdw.Tag.ToString()=="0" || txtzxdw.Tag.ToString()=="" || txtzxdw.Text.Trim()=="")
			{
				MessageBox.Show("请输入折零单位");
				return;
			}

			int ypdw=Convert.ToInt32(Convertor.IsNull(cmbdw.Tag,"0"));
			int zxdw=Convert.ToInt32(txtzxdw.Tag);
			int dwbl=Convert.ToInt32(txtdwbl.Text);
			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
			int cjid=Convert.ToInt32(Convertor.IsNull(lblypmc.Tag,"0"));

			if (dwbl<0)
			{
				MessageBox.Show("折零系数必须大于零");
				return;
			}

			if (zxdw==ypdw && dwbl!=1)
			{
				MessageBox.Show("折零不正确");
				return;
			}

			if (zxdw!=ypdw && dwbl==1)
			{
				MessageBox.Show("折零不正确");
				return;
			}

			if (cmbdw.Text.Trim()==txtzxdw.Text.Trim() && dwbl!=1)
			{
				MessageBox.Show("折零不正确,单位名称相同但折零系数不为1");
				return;
			}

			if (cmbdw.Text.Trim()!=txtzxdw.Text.Trim() && dwbl==1)
			{
				MessageBox.Show("折零不正确,单位名称不同但折零系数为1");
				return;
			}


			if (dwbl>10000)
			{
				MessageBox.Show("折零系数过大，请检查正确性");
				return;
			}


            string str_message = "";
			string ssql="";
            ssql = "select * from yp_ypcl where cjid=" + cjid + " and deptid=" + Convertor.IsNull(cmbyjks.SelectedValue, "0") + "";
			DataTable tab=InstanceForm.BDatabase.GetDataTable(ssql);
			int ncount=tab.Rows.Count ;

			try
			{
				InstanceForm.BDatabase.BeginTransaction();
                Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
				
				//折零表
				if (ncount>0)
                    ssql = "update yp_ypcl set zxdw=" + zxdw + ",dwbl=" + dwbl + " where cjid=" + cjid + " and deptid=" + Convertor.IsNull(cmbyjks.SelectedValue, "0") + "";
				else
                    ssql = "insert into yp_ypcl(ggid,cjid,ypdw,zxdw,dwbl,deptid,djsj)values(" + ydcj.GGID + "," + cjid + "," + ypdw + "," + zxdw + "," + dwbl + "," + Convertor.IsNull(cmbyjks.SelectedValue, "0") + ",'" + sDate + "')";
				InstanceForm.BDatabase.DoCommand(ssql);

                string str_old = "";
                if (ncount > 0)
                {
                    if (txtdwbl.Text.Trim()!=tab.Rows[0]["dwbl"].ToString())
                        str_message = "["+lblypmc.Text + "] 修改了拆零:原拆零包装为:" + tab.Rows[0]["dwbl"].ToString() + Yp.SeekYpdw(Convert.ToInt32(tab.Rows[0]["zxdw"]), InstanceForm.BDatabase)
                            + " 现拆零包装为 " + txtdwbl.Text + txtzxdw.Text.Trim();

                    str_old = "货号:" + lblhh.Text + " CJID:" + cjid + " 品名:" + lblypmc.Text + "  原拆零信息为:" + tab.Rows[0]["dwbl"].ToString() + Yp.SeekYpdw(Convert.ToInt32(tab.Rows[0]["zxdw"]), InstanceForm.BDatabase) + "  现拆零信息为:" +
                            txtdwbl.Text + txtzxdw.Text.Trim();
                    SystemLog systemLog = new SystemLog(-1, Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")), InstanceForm.BCurrentUser.EmployeeId, "修改拆零信息", str_old, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, 8);
                    systemLog.Save();
                    systemLog = null;
                }
                else
                {
                    str_message = "["+lblypmc.Text + "] 设置了拆零:原单位:" + cmbdw.Text.Trim() + " 拆零包装为 " + txtdwbl.Text + txtzxdw.Text.Trim();
                    str_old = "新增药品拆零 货号:" + lblhh.Text + " CJID:" + cjid + " 品名:" + lblypmc.Text +  "  拆零信息为:" +
                    txtdwbl.Text + txtzxdw.Text.Trim();
                    SystemLog systemLog = new SystemLog(-1, Convert.ToInt32(Convertor.IsNull(cmbyjks.SelectedValue, "0")), InstanceForm.BCurrentUser.EmployeeId, "修改拆零信息", str_old, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, 8);
                    systemLog.Save();
                    systemLog = null;
                }

				// 库存表
                ssql = "update yF_kcmx set zxdw=" + zxdw + ",dwbl=" + dwbl + ",kcl=kcl*" + dwbl + "/dwbl where cjid=" + cjid + " and deptid=" + Convertor.IsNull(cmbyjks.SelectedValue, "0") + " ";
				InstanceForm.BDatabase.DoCommand(ssql);

                //Modify By Tany 2015-01-19 库存批号表的事件触发机制变化，需要更新修改时间
                ssql = "update YF_kcph set xgsj=getdate(),maxsl= maxsl*" + dwbl + "/dwbl,zxdw=" + zxdw + ",dwbl=" + dwbl + ",kcl=kcl*" + dwbl + "/dwbl where cjid=" + cjid + " and deptid=" + Convertor.IsNull(cmbyjks.SelectedValue, "0") + " ";
				InstanceForm.BDatabase.DoCommand(ssql);

                ssql = "update yk_kcmx set zxdw=" + zxdw + ",dwbl=" + dwbl + ",kcl=kcl*" + dwbl + "/dwbl where cjid=" + cjid + " and deptid=" + Convertor.IsNull(cmbyjks.SelectedValue, "0") + " ";
				InstanceForm.BDatabase.DoCommand(ssql);

                ssql = "update Yk_kcph set maxsl= maxsl*" + dwbl + "/dwbl,zxdw=" + zxdw + ",dwbl=" + dwbl + ",kcl=kcl*" + dwbl + "/dwbl where cjid=" + cjid + " and deptid=" + Convertor.IsNull(cmbyjks.SelectedValue, "0") + " ";
				InstanceForm.BDatabase.DoCommand(ssql);

				InstanceForm.BDatabase.CommitTransaction();

                Yp.InsertLog("药品拆零", TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId, cjid, TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId, sDate, str_old, InstanceForm.BDatabase);

				this.csgroupbox2();
                MessageBox.Show(" 拆零成功");

                if (str_message.Trim() != "")
                    TrasenFrame.Classes.WorkStaticFun.SendMessage(false, TrasenFrame.Classes.SystemModule.药品系统, "",0, InstanceForm.BCurrentUser.EmployeeId,"拆零提示 "+ InstanceForm.BCurrentUser.Name+"("+sDate+")", str_message);
                
			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show("发生错误"+err.Message);
			}
			
		}

        private void cmbyjks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                tb.Rows.Clear();
                csyp(0, 0);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





	}
}
