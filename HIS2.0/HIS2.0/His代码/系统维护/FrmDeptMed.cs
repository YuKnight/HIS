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
	/// Frmcfcx 的摘要说明。
	/// </summary>
	public class FrmDeptMed : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label lblgg;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtypdm;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button butdel;
		private System.Windows.Forms.Button butadd;
		private System.Windows.Forms.TextBox txtks;
		private System.Windows.Forms.TextBox txtjs;
		private System.Windows.Forms.Label lbldw;
		private myDataGrid.myDataGrid myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpqyrq;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblypspm;
		private System.Windows.Forms.Label lblypmc;
		private System.Windows.Forms.Button butclear;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmDeptMed(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;

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
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.myDataGrid2 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lblypmc = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpqyrq = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.butdel = new System.Windows.Forms.Button();
			this.butadd = new System.Windows.Forms.Button();
			this.txtks = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lbldw = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblypspm = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.lblgg = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.butsave = new System.Windows.Forms.Button();
			this.butquit = new System.Windows.Forms.Button();
			this.txtypdm = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtjs = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.panel3 = new System.Windows.Forms.Panel();
			this.myDataGrid1 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.butclear = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
			this.panel2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(144, 533);
			this.panel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.myDataGrid2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(144, 533);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "备有基数药的科室";
			// 
			// myDataGrid2
			// 
			this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.myDataGrid2.CaptionBackColor = System.Drawing.Color.Silver;
			this.myDataGrid2.CaptionForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.myDataGrid2.CaptionText = "双击查看明细";
			this.myDataGrid2.DataMember = "";
			this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid2.Location = new System.Drawing.Point(3, 17);
			this.myDataGrid2.Name = "myDataGrid2";
			this.myDataGrid2.Size = new System.Drawing.Size(138, 513);
			this.myDataGrid2.TabIndex = 0;
			this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle2});
			this.myDataGrid2.Click += new System.EventHandler(this.myDataGrid2_DoubleClick);
			this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_DoubleClick);
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn12,
																												  this.dataGridTextBoxColumn13});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "";
			this.dataGridTableStyle2.ReadOnly = true;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.HeaderText = "科室名称";
			this.dataGridTextBoxColumn12.MappingName = "";
			this.dataGridTextBoxColumn12.NullText = "";
			this.dataGridTextBoxColumn12.Width = 75;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "deptid";
			this.dataGridTextBoxColumn13.MappingName = "";
			this.dataGridTextBoxColumn13.NullText = "";
			this.dataGridTextBoxColumn13.Width = 0;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(144, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 533);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(152, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(712, 88);
			this.panel2.TabIndex = 2;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.butclear);
			this.groupBox3.Controls.Add(this.lblypmc);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.dtpqyrq);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.butdel);
			this.groupBox3.Controls.Add(this.butadd);
			this.groupBox3.Controls.Add(this.txtks);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.lbldw);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.lblypspm);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.lblgg);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.butsave);
			this.groupBox3.Controls.Add(this.butquit);
			this.groupBox3.Controls.Add(this.txtypdm);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.txtjs);
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(712, 88);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "查询";
			// 
			// lblypmc
			// 
			this.lblypmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblypmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblypmc.ForeColor = System.Drawing.Color.Navy;
			this.lblypmc.Location = new System.Drawing.Point(240, 20);
			this.lblypmc.Name = "lblypmc";
			this.lblypmc.Size = new System.Drawing.Size(144, 20);
			this.lblypmc.TabIndex = 103;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(201, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 102;
			this.label5.Text = "品名";
			// 
			// dtpqyrq
			// 
			this.dtpqyrq.Location = new System.Drawing.Point(384, 53);
			this.dtpqyrq.Name = "dtpqyrq";
			this.dtpqyrq.Size = new System.Drawing.Size(112, 21);
			this.dtpqyrq.TabIndex = 101;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(328, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 100;
			this.label1.Text = "启用日期";
			// 
			// butdel
			// 
			this.butdel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butdel.ForeColor = System.Drawing.Color.Navy;
			this.butdel.Location = new System.Drawing.Point(544, 51);
			this.butdel.Name = "butdel";
			this.butdel.Size = new System.Drawing.Size(40, 24);
			this.butdel.TabIndex = 99;
			this.butdel.Text = "删除";
			this.butdel.Click += new System.EventHandler(this.butdel_Click);
			// 
			// butadd
			// 
			this.butadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butadd.ForeColor = System.Drawing.Color.Navy;
			this.butadd.Location = new System.Drawing.Point(504, 51);
			this.butadd.Name = "butadd";
			this.butadd.Size = new System.Drawing.Size(40, 24);
			this.butadd.TabIndex = 3;
			this.butadd.Text = "添加";
			this.butadd.Click += new System.EventHandler(this.butadd_Click);
			// 
			// txtks
			// 
			this.txtks.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.txtks.Location = new System.Drawing.Point(48, 53);
			this.txtks.Name = "txtks";
			this.txtks.Size = new System.Drawing.Size(80, 21);
			this.txtks.TabIndex = 0;
			this.txtks.Text = "";
			this.txtks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
			this.txtks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 97;
			this.label4.Text = "科室";
			// 
			// lbldw
			// 
			this.lbldw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbldw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbldw.ForeColor = System.Drawing.Color.Navy;
			this.lbldw.Location = new System.Drawing.Point(584, 19);
			this.lbldw.Name = "lbldw";
			this.lbldw.Size = new System.Drawing.Size(40, 20);
			this.lbldw.TabIndex = 95;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(552, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 16);
			this.label2.TabIndex = 94;
			this.label2.Text = "单位";
			// 
			// lblypspm
			// 
			this.lblypspm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblypspm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblypspm.ForeColor = System.Drawing.Color.Navy;
			this.lblypspm.Location = new System.Drawing.Point(48, 20);
			this.lblypspm.Name = "lblypspm";
			this.lblypspm.Size = new System.Drawing.Size(144, 20);
			this.lblypspm.TabIndex = 74;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 24);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(64, 16);
			this.label16.TabIndex = 73;
			this.label16.Text = "商品名";
			// 
			// lblgg
			// 
			this.lblgg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblgg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblgg.ForeColor = System.Drawing.Color.Navy;
			this.lblgg.Location = new System.Drawing.Point(424, 20);
			this.lblgg.Name = "lblgg";
			this.lblgg.Size = new System.Drawing.Size(120, 20);
			this.lblgg.TabIndex = 70;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(392, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(34, 16);
			this.label12.TabIndex = 69;
			this.label12.Text = "规格";
			// 
			// butsave
			// 
			this.butsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butsave.ForeColor = System.Drawing.Color.Navy;
			this.butsave.Location = new System.Drawing.Point(584, 51);
			this.butsave.Name = "butsave";
			this.butsave.Size = new System.Drawing.Size(40, 24);
			this.butsave.TabIndex = 4;
			this.butsave.Text = "保存";
			this.butsave.Click += new System.EventHandler(this.butsave_Click);
			// 
			// butquit
			// 
			this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butquit.ForeColor = System.Drawing.Color.Navy;
			this.butquit.Location = new System.Drawing.Point(664, 51);
			this.butquit.Name = "butquit";
			this.butquit.Size = new System.Drawing.Size(40, 24);
			this.butquit.TabIndex = 5;
			this.butquit.Text = "退出";
			this.butquit.Click += new System.EventHandler(this.butquit_Click);
			// 
			// txtypdm
			// 
			this.txtypdm.ForeColor = System.Drawing.Color.Navy;
			this.txtypdm.Location = new System.Drawing.Point(160, 53);
			this.txtypdm.Name = "txtypdm";
			this.txtypdm.Size = new System.Drawing.Size(64, 21);
			this.txtypdm.TabIndex = 1;
			this.txtypdm.Text = "";
			this.txtypdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
			this.txtypdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(128, 58);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 16);
			this.label10.TabIndex = 67;
			this.label10.Text = "代码";
			// 
			// txtjs
			// 
			this.txtjs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtjs.Location = new System.Drawing.Point(256, 53);
			this.txtjs.Name = "txtjs";
			this.txtjs.Size = new System.Drawing.Size(72, 21);
			this.txtjs.TabIndex = 2;
			this.txtjs.Text = "";
			this.txtjs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(224, 58);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(48, 16);
			this.label19.TabIndex = 77;
			this.label19.Text = "基数";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(152, 509);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(712, 24);
			this.statusBar1.TabIndex = 3;
			this.statusBar1.Text = "statusBar1";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.myDataGrid1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(152, 88);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(712, 421);
			this.panel3.TabIndex = 4;
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.Silver;
			this.myDataGrid1.CaptionForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.myDataGrid1.CaptionText = "基数药列表";
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.Size = new System.Drawing.Size(712, 421);
			this.myDataGrid1.TabIndex = 0;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid2_DoubleClick);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn11});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "序号";
			this.dataGridTextBoxColumn1.MappingName = "";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 35;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "品名";
			this.dataGridTextBoxColumn2.MappingName = "";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 150;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "商品名";
			this.dataGridTextBoxColumn3.MappingName = "";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 150;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "规格";
			this.dataGridTextBoxColumn4.MappingName = "";
			this.dataGridTextBoxColumn4.ReadOnly = true;
			this.dataGridTextBoxColumn4.Width = 75;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "基数";
			this.dataGridTextBoxColumn7.MappingName = "";
			this.dataGridTextBoxColumn7.Width = 65;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "单位";
			this.dataGridTextBoxColumn8.MappingName = "";
			this.dataGridTextBoxColumn8.ReadOnly = true;
			this.dataGridTextBoxColumn8.Width = 35;
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.HeaderText = "ggid";
			this.dataGridTextBoxColumn10.MappingName = "";
			this.dataGridTextBoxColumn10.ReadOnly = true;
			this.dataGridTextBoxColumn10.Width = 0;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "启用日期";
			this.dataGridTextBoxColumn11.MappingName = "";
			this.dataGridTextBoxColumn11.NullText = "";
			this.dataGridTextBoxColumn11.Width = 75;
			// 
			// butclear
			// 
			this.butclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butclear.ForeColor = System.Drawing.Color.Navy;
			this.butclear.Location = new System.Drawing.Point(624, 51);
			this.butclear.Name = "butclear";
			this.butclear.Size = new System.Drawing.Size(40, 24);
			this.butclear.TabIndex = 104;
			this.butclear.Text = "清除";
			this.butclear.Click += new System.EventHandler(this.butclear_Click);
			// 
			// FrmDeptMed
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(864, 533);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Name = "FrmDeptMed";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "v";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Frmdsytl_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
			this.panel2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void butadd_Click(object sender, System.EventArgs e)
		{
			try
			{

				if (Convert.ToInt32(Convertor.IsNull(lblypmc.Tag,"0"))==0)
				{
					MessageBox.Show("没有选择药品");
					return;
				}

				if (Convertor.IsNumeric(Convertor.IsNull(lblypmc.Tag,"0"))==false)
				{
					MessageBox.Show("基数请输入数字");
					return;
				}

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				DataRow row=tb.NewRow();
				int _ggid=Convert.ToInt32(Convertor.IsNull(lblypmc.Tag,"0"));
				DataRow[] selectrow=tb.Select("ggid='"+_ggid.ToString()+"'");
				if (selectrow.Length>0) 
				{
					MessageBox.Show("当前药品已在列表添加了");
					return;
				}

                Ypgg ydgg = new Ypgg(_ggid, InstanceForm.BDatabase);
				row["序号"]=tb.Rows.Count+1;
				row["品名"]=ydgg.YPPM;
				row["商品名"]=ydgg.YPSPM;
				row["规格"]=ydgg.YPGG;
				//row["零售价"]=ydcj.LSJ;
				row["基数"]=Convertor.IsNull(txtjs.Text,"0");
                row["单位"] = Yp.SeekYpdw(ydgg.YPDW, InstanceForm.BDatabase);
				//row["货号"]=ydcj.SHH;
				row["ggid"]=ydgg.GGID;
				row["启用日期"]=this.dtpqyrq.Value.ToShortDateString();
				tb.Rows.Add(row);
				lblypmc.Text="";
				lblypmc.Tag="0";
				lblgg.Text="";
				//lblcj.Text="";
				lbldw.Text="";
				//lbllsj.Text="";
				//lblhh.Text="";
				txtypdm.Text="";
				txtjs.Text="";
				txtypdm.Focus();
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void butdel_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				if (nrow>=tb.Rows.Count) return;
				int deptid=Convert.ToInt32(Convertor.IsNull(txtks.Tag,"0"));
				if(MessageBox.Show("您确定要删除第"+Convert.ToString((nrow+1))+"行吗 ？","询问窗",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					DataRow datarow=tb.Rows[nrow];
					string ssql="delete from YP_DEPTMED where ggid="+Convert.ToInt32(Convertor.IsNull(datarow["ggid"],"0"))+" and deptid="+deptid+"";
					InstanceForm.BDatabase.DoCommand(ssql);
					tb.Rows.Remove(datarow);

					//移除单据号表
					ssql="select * from YP_DEPTMED where deptid="+deptid+"";
					DataTable tbmed=InstanceForm.BDatabase.GetDataTable(ssql);
					if (tbmed.Rows.Count==0)
					{
						ssql="delete from yp_djh where deptid="+deptid+" and ywlx='013'";
						InstanceForm.BDatabase.DoCommand(ssql);
					}
				}
			
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void Frmdsytl_Load(object sender, System.EventArgs e)
		{
			try
			{
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"tb1");
				FunBase.CsDataGrid(this.myDataGrid2,this.myDataGrid2.TableStyles[0],"tb2");
				DataTable tb=MedDept();
				tb.TableName="tb2";
				this.myDataGrid2.DataSource=tb;
				this.dtpqyrq.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private  DataTable MedDept()
		{
			string ssql="select dbo.fun_getdeptname(deptid) 科室名称,deptid from yp_deptmed group by deptid";
			return InstanceForm.BDatabase.GetDataTable(ssql);
		}

		private  DataTable MedDeptYp(int deptid)
		{
			string ssql="select 0 序号,yppm 品名,ypspm 商品名,ypgg 规格,"+
				"YPSL 基数,dbo.fun_yp_ypdw(ypdw) 单位,a.ggid,qyrq 启用日期  from yp_deptmed a,yp_ypggd b where a.ggid=b.ggid and deptid="+deptid+"";
			return InstanceForm.BDatabase.GetDataTable(ssql);
		}

		private void myDataGrid2_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid2.CurrentCell.RowNumber;
				DataTable tbdept=(DataTable)this.myDataGrid2.DataSource;
				if (nrow>tbdept.Rows.Count-1) return;
				DataTable tb=MedDeptYp(Convert.ToInt32(tbdept.Rows[nrow]["deptid"]));
				tb.TableName="tb1";
				this.myDataGrid1.DataSource=tb;
                txtks.Text = Yp.SeekDeptName(Convert.ToInt32(tbdept.Rows[nrow]["deptid"]), InstanceForm.BDatabase);
				txtks.Tag=Convert.ToString(tbdept.Rows[nrow]["deptid"]);
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		
		}


		//输入框控制事件
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" ){control.Text="";control.Tag="0";}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)==""))){}
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
						GrdMappingName=new string[] {"id","行号","科室","拼音码","五笔码"};
						GrdWidth=new int[] {0,50,200,100,100};
						sfield=new string[] {"wb_code","py_code","","",""};
						ssql="select ksbh dept_id,0 rowno,ksmc name,pym py_code,wbm wb_code from jc_yyksb where ksbh<>0 ";
						TrasenFrame.Forms.Fshowcard f1=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,FilterType.拼音,control.Text.Trim(),ssql);
						f1.Location=point;
						f1.ShowDialog(this);
						row=f1.dataRow;
						if (row!=null) 
						{
							control.Text=row["name"].ToString();
							control.Tag=row["dept_id"].ToString();
							this.SelectNextControl((Control)sender,true,false,true,true);
						}
						break;
					case 1:

						if (control.Text.Trim()=="") return;
						GrdMappingName=new string[] {"ggid","行号","商品名","品名","规格","单位"};
						GrdWidth=new int[] {0,50,180,180,100,40};
						sfield=new string[] {"wbm","pym","szm","ywm","ypbm"};
						ssql="select a.ggid,0 rowno,ypspm,yppm,ypgg,dbo.fun_yp_ypdw(ypdw) ypdw from yp_ypggd a,yp_ypbm b "+
								"where a.ggid=b.ggid  and bdelete=0  and yplx in(1,2)";
						
						TrasenFrame.Forms.Fshowcard  f2=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,Constant.CustomFilterType,control.Text.Trim(),ssql);
						f2.Location=point;
						f2.Width=700;
						f2.Height=300;
						f2.ShowDialog(this);
						row=f2.dataRow;
						if (row!=null) 
						{
							this.csyp(Convert.ToInt32(row["ggid"]),0);
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
				this.lblypmc.Tag=ydgg.GGID.ToString();
				this.lblypmc.Text=ydgg.YPPM;
				this.lblypspm.Text=ydgg.YPSPM;
				this.lblgg.Text=ydgg.YPGG;
				//this.lblcj.Text=ydcj.S_SCCJ;
				//this.lblhh.Text=ydcj.SHH;
				//this.lbllsj.Text=ydcj.LSJ.ToString() ;
                this.lbldw.Text = Yp.SeekYpdw(ydgg.YPDW, InstanceForm.BDatabase);
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void butsave_Click(object sender, System.EventArgs e)
		{

			string ssql="";
			int deptid=Convert.ToInt32(Convertor.IsNull(txtks.Tag,"0"));
			if (InstanceForm.BCurrentDept.DeptId==0)
			{
				MessageBox.Show("没有选择科室");
				return;
			}

			this.butsave.Enabled=false;



			try
			{
				InstanceForm.BDatabase.BeginTransaction();
				
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					int _ggid=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["ggid"],"0"));
					decimal _ypsl=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["基数"],"0"));
					string _qyrq=Convert.ToDateTime(tb.Rows[i]["启用日期"]).ToShortDateString()+" 00:00:00";
					ssql="select * from yp_deptmed where deptid="+deptid+" and ggid="+_ggid+"";
					DataTable mytb=InstanceForm.BDatabase.GetDataTable(ssql);
					if (mytb.Rows.Count!=0) 
					{
						if (Convert.ToDateTime(mytb.Rows[0]["qyrq"]).ToString()!=Convert.ToDateTime(_qyrq).ToString())
						{
							if (Convert.ToDateTime(mytb.Rows[0]["tjrq"]).ToString()!=Convert.ToDateTime(mytb.Rows[0]["qyrq"]).ToString())
							{
								tb.Rows[i]["启用日期"]=mytb.Rows[0]["qyrq"];
								throw new Exception(" ["+tb.Rows[i]["商品名"].ToString().Trim()+"] 这个药品已进行过基数药补充，不能再对启用日期进行更改。");
								
							}
						}

						if (Convert.ToDateTime(mytb.Rows[0]["qyrq"]).ToString()==Convert.ToDateTime(_qyrq).ToString())
						  ssql="update yp_deptmed set (ypsl,qyrq)=("+_ypsl+",'"+_qyrq+"') where ggid="+_ggid+" and deptid="+deptid+"";
						else
						  ssql="update yp_deptmed set (ypsl,qyrq,tjrq)=("+_ypsl+",'"+_qyrq+"','"+_qyrq+"') where ggid="+_ggid+" and deptid="+deptid+"";
					}
					else
					{
						ssql="insert into yp_deptmed(deptid,ggid,ypsl,book_user,book_date,qyrq,tjrq)values("+deptid+","+_ggid+","+_ypsl+","+InstanceForm.BCurrentUser.EmployeeId+",'"+DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString()+"','"+_qyrq+"','"+_qyrq+"')";
					}
						InstanceForm.BDatabase.DoCommand(ssql);
				}
				
				//产生单据号表
				ssql="select * from yp_djh where deptid="+deptid+" and ywlx='013'";
				DataTable tbdjh=InstanceForm.BDatabase.GetDataTable(ssql);
				if (tbdjh.Rows.Count==0)
				{
					ssql="insert into yp_djh(ywlx,djh,deptid)values('013',0,"+deptid+")";
					InstanceForm.BDatabase.DoCommand(ssql);
				}
				
				//提交事务
				InstanceForm.BDatabase.CommitTransaction();
				MessageBox.Show("保存成功");
				this.butsave.Enabled=true;

				DataTable tbdept=MedDept();
				tbdept.TableName="tb2";
				this.myDataGrid2.DataSource=tbdept;


			}
			catch(System.Exception err)
			{
				this.butsave.Enabled=true;
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show(err.Message);
			}
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butclear_Click(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();
			this.txtks.Text="";
			this.txtks.Tag="0";

			DataTable tbdept=MedDept();
			tbdept.TableName="tb2";
			this.myDataGrid2.DataSource=tbdept;
		}


	
	}
}