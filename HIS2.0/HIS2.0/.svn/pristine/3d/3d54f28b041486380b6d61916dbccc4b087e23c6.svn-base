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
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmzjtc : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private myDataGrid.myDataGrid myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.Label lbldw;
		private System.Windows.Forms.TextBox txtlll;
		private System.Windows.Forms.TextBox txtylmc;
		private System.Windows.Forms.TextBox txtzzypmc;
		private System.Windows.Forms.Button butadd;
		private System.Windows.Forms.Button butdel;
		private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblgg;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.TextBox txtzf;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button butclear;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmzjtc(MenuTag menuTag,string chineseName,Form mdiParent)
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
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.myDataGrid1 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lblgg = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.butquit = new System.Windows.Forms.Button();
			this.butsave = new System.Windows.Forms.Button();
			this.butdel = new System.Windows.Forms.Button();
			this.butadd = new System.Windows.Forms.Button();
			this.lbldw = new System.Windows.Forms.Label();
			this.txtlll = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtylmc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtzzypmc = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.myDataGrid2 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.txtzf = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.butclear = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
			this.SuspendLayout();
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 461);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.statusBarPanel2});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size( 800, 24);
			this.statusBar1.TabIndex = 0;
			this.statusBar1.Text = "statusBar1";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Width = 300;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Width = 1001;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.myDataGrid1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(256, 461);
			this.panel1.TabIndex = 1;
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.myDataGrid1.CaptionForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.myDataGrid1.CaptionText = "自制药品列表";
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.HeaderFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.PreferredRowHeight = 22;
			this.myDataGrid1.ReadOnly = true;
			this.myDataGrid1.Size = new System.Drawing.Size(256, 461);
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
																												  this.dataGridTextBoxColumn5});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			this.dataGridTableStyle1.PreferredRowHeight = 22;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "序号";
			this.dataGridTextBoxColumn1.MappingName = "";
			this.dataGridTextBoxColumn1.Width = 50;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "名称";
			this.dataGridTextBoxColumn2.MappingName = "";
			this.dataGridTextBoxColumn2.Width = 140;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "cjid";
			this.dataGridTextBoxColumn5.MappingName = "";
			this.dataGridTextBoxColumn5.Width = 0;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(256, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 461);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.butclear);
			this.panel3.Controls.Add(this.txtzf);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.lblgg);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.butquit);
			this.panel3.Controls.Add(this.butsave);
			this.panel3.Controls.Add(this.butdel);
			this.panel3.Controls.Add(this.butadd);
			this.panel3.Controls.Add(this.lbldw);
			this.panel3.Controls.Add(this.txtlll);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.txtylmc);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.txtzzypmc);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(264, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(536, 136);
			this.panel3.TabIndex = 4;
			// 
			// lblgg
			// 
			this.lblgg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblgg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblgg.ForeColor = System.Drawing.Color.Blue;
			this.lblgg.Location = new System.Drawing.Point(344, 64);
			this.lblgg.Name = "lblgg";
			this.lblgg.Size = new System.Drawing.Size(128, 24);
			this.lblgg.TabIndex = 19;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(304, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 18;
			this.label4.Text = "规格";
			// 
			// butquit
			// 
			this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butquit.Location = new System.Drawing.Point(464, 96);
			this.butquit.Name = "butquit";
			this.butquit.Size = new System.Drawing.Size(64, 24);
			this.butquit.TabIndex = 8;
			this.butquit.Text = "退出(&Q)";
			this.butquit.Click += new System.EventHandler(this.butquit_Click);
			// 
			// butsave
			// 
			this.butsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butsave.Location = new System.Drawing.Point(336, 96);
			this.butsave.Name = "butsave";
			this.butsave.Size = new System.Drawing.Size(64, 24);
			this.butsave.TabIndex = 6;
			this.butsave.Text = "保存(&S)";
			this.butsave.Click += new System.EventHandler(this.butsave_Click);
			// 
			// butdel
			// 
			this.butdel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butdel.Location = new System.Drawing.Point(264, 96);
			this.butdel.Name = "butdel";
			this.butdel.Size = new System.Drawing.Size(72, 24);
			this.butdel.TabIndex = 5;
			this.butdel.Text = "删除行(&D)";
			this.butdel.Click += new System.EventHandler(this.butdel_Click);
			// 
			// butadd
			// 
			this.butadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butadd.Location = new System.Drawing.Point(200, 96);
			this.butadd.Name = "butadd";
			this.butadd.Size = new System.Drawing.Size(64, 24);
			this.butadd.TabIndex = 4;
			this.butadd.Text = "新增(&A)";
			this.butadd.Click += new System.EventHandler(this.butadd_Click);
			// 
			// lbldw
			// 
			this.lbldw.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbldw.ForeColor = System.Drawing.Color.Blue;
			this.lbldw.Location = new System.Drawing.Point(168, 104);
			this.lbldw.Name = "lbldw";
			this.lbldw.Size = new System.Drawing.Size(32, 16);
			this.lbldw.TabIndex = 13;
			// 
			// txtlll
			// 
			this.txtlll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtlll.ForeColor = System.Drawing.Color.Blue;
			this.txtlll.Location = new System.Drawing.Point(104, 96);
			this.txtlll.Name = "txtlll";
			this.txtlll.Size = new System.Drawing.Size(63, 23);
			this.txtlll.TabIndex = 3;
			this.txtlll.Text = "";
			this.txtlll.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(56, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "理论量";
			// 
			// txtylmc
			// 
			this.txtylmc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtylmc.ForeColor = System.Drawing.Color.Blue;
			this.txtylmc.Location = new System.Drawing.Point(104, 64);
			this.txtylmc.Name = "txtylmc";
			this.txtylmc.Size = new System.Drawing.Size(192, 23);
			this.txtylmc.TabIndex = 2;
			this.txtylmc.Text = "";
			this.txtylmc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
			this.txtylmc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(45, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "原料名称";
			// 
			// txtzzypmc
			// 
			this.txtzzypmc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtzzypmc.ForeColor = System.Drawing.Color.Blue;
			this.txtzzypmc.Location = new System.Drawing.Point(104, 8);
			this.txtzzypmc.Name = "txtzzypmc";
			this.txtzzypmc.Size = new System.Drawing.Size(256, 23);
			this.txtzzypmc.TabIndex = 0;
			this.txtzzypmc.Text = "";
			this.txtzzypmc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
			this.txtzzypmc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "自制药品名称";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.myDataGrid2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(264, 136);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(536, 325);
			this.panel2.TabIndex = 5;
			// 
			// myDataGrid2
			// 
			this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
			this.myDataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.myDataGrid2.CaptionForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.myDataGrid2.CaptionText = "原料明细";
			this.myDataGrid2.DataMember = "";
			this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid2.Name = "myDataGrid2";
			this.myDataGrid2.PreferredRowHeight = 22;
			this.myDataGrid2.Size = new System.Drawing.Size(536, 325);
			this.myDataGrid2.TabIndex = 0;
			this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle2});
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.AllowSorting = false;
			this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridTextBoxColumn9,
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn11,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "";
			this.dataGridTableStyle2.PreferredRowHeight = 22;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "序号";
			this.dataGridTextBoxColumn6.MappingName = "";
			this.dataGridTextBoxColumn6.ReadOnly = true;
			this.dataGridTextBoxColumn6.Width = 40;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "原料名称";
			this.dataGridTextBoxColumn7.MappingName = "";
			this.dataGridTextBoxColumn7.ReadOnly = true;
			this.dataGridTextBoxColumn7.Width = 140;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "规格";
			this.dataGridTextBoxColumn8.MappingName = "";
			this.dataGridTextBoxColumn8.ReadOnly = true;
			this.dataGridTextBoxColumn8.Width = 75;
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.HeaderText = "理论量";
			this.dataGridTextBoxColumn9.MappingName = "";
			this.dataGridTextBoxColumn9.Width = 80;
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.HeaderText = "单位";
			this.dataGridTextBoxColumn10.MappingName = "";
			this.dataGridTextBoxColumn10.ReadOnly = true;
			this.dataGridTextBoxColumn10.Width = 40;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "YDWBL";
			this.dataGridTextBoxColumn4.MappingName = "";
			this.dataGridTextBoxColumn4.ReadOnly = true;
			this.dataGridTextBoxColumn4.Width = 0;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "CJID";
			this.dataGridTextBoxColumn11.MappingName = "";
			this.dataGridTextBoxColumn11.ReadOnly = true;
			this.dataGridTextBoxColumn11.Width = 0;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "id";
			this.dataGridTextBoxColumn3.MappingName = "";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 0;
			// 
			// txtzf
			// 
			this.txtzf.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtzf.ForeColor = System.Drawing.Color.Blue;
			this.txtzf.Location = new System.Drawing.Point(104, 35);
			this.txtzf.Name = "txtzf";
			this.txtzf.Size = new System.Drawing.Size(416, 23);
			this.txtzf.TabIndex = 1;
			this.txtzf.Text = "";
			this.txtzf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(72, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 21;
			this.label5.Text = "制法";
			// 
			// butclear
			// 
			this.butclear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butclear.Location = new System.Drawing.Point(400, 96);
			this.butclear.Name = "butclear";
			this.butclear.Size = new System.Drawing.Size(64, 24);
			this.butclear.TabIndex = 22;
			this.butclear.Text = "清除(&C)";
			this.butclear.Click += new System.EventHandler(this.butclear_Click);
			// 
			// Frmzjtc
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size( 800, 485);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusBar1);
			this.Name = "Frmzjtc";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Frmzjtc_Load);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]


		private void Frmzjtc_Load(object sender, System.EventArgs e)
		{
			try
			{
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");
				FunBase.CsDataGrid(this.myDataGrid2,this.myDataGrid2.TableStyles[0],"Tbmx");
	
				FunBase.myGridSelect(this.myDataGrid1,this.myDataGrid1.TableStyles[0].GridColumnStyles);
				this.AddDataMydataGrid1(0);
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		private void AddDataMydataGrid1(int tccjid)
		{
			DataTable myTb;
			string ssql="";
			if (tccjid==0)
			{
				ssql="select 0 序号,s_ypspm 名称,tccjid cjid from yp_ypcjd a,yp_zjtc b where a.cjid=b.tccjid group by tccjid,s_ypspm ";
				myTb=InstanceForm.BDatabase.GetDataTable(ssql);
				myTb.TableName="Tb";
				this.myDataGrid1.DataSource=myTb;
				this.myDataGrid1.TableStyles[0].MappingName ="Tb";
			}
			else
			{
				ssql="select 0 序号,s_ypspm 原料名称,s_ypgg 规格,cast(ypsl as float) 理论量,dbo.fun_yp_ypdw(b.ypdw) 单位,ydwbl,cjid,b.id,b.bz from yp_ypcjd a,yp_zjtc b where a.cjid=b.ylcjid order by b.id";
				myTb=InstanceForm.BDatabase.GetDataTable(ssql);
				myTb.TableName="Tbmx";
				this.myDataGrid2.DataSource=myTb;
				this.myDataGrid2.TableStyles[0].MappingName ="Tbmx";
                Ypcj ydcj = new Ypcj(tccjid, InstanceForm.BDatabase);
				this.txtzzypmc.Text=ydcj.S_YPSPM;
				this.txtzzypmc.Tag=ydcj.CJID.ToString();
				if (myTb.Rows.Count!=0) this.txtzf.Text=myTb.Rows[0]["bz"].ToString();
			}

		}


		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" )
			{
				control.Text="";control.Tag="0";}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)==""))) {} 
			else {return;}

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
						GrdMappingName=new string[] {"ggid","cjid","行号","品名","规格","单位","货号"};
						GrdWidth=new int[] {0,0,30,150,100,40,60};
						sfield=new string[] {"wbm","pym","szm","ywm","ypbm"};
						ssql="select a.ggid,cjid,0 rowno,s_ypspm,s_ypgg,s_ypdw,shh from yp_ypcjd a,yp_ypbm b "+
							" where a.ggid=b.ggid and a.bdelete=0 and n_ypzlx in(2,4,6) ";//and a.n_ypzlx in(select ypzlx from yp_gllx where deptid="+InstanceForm.BCurrentDept.DeptId+")  ";
						TrasenFrame.Forms.Fshowcard f2=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,Constant.CustomFilterType,control.Text.Trim(),ssql);
						f2.Location=point;
						f2.Width=700;
						f2.Height=300;
						f2.Text="选择自制药品";
						f2.ShowDialog(this);
						row=f2.dataRow;
						if (row!=null) 
						{
							this.txtzzypmc.Text=row["s_ypspm"].ToString();
							this.txtzzypmc.Tag=row["cjid"].ToString().Trim();
							this.SelectNextControl((Control)sender,true,false,true,true);
							
						}
						break;
					case 2:
						if (control.Text.Trim()=="") return;
						GrdMappingName=new string[] {"ggid","cjid","行号","品名","规格","单位","货号"};
						GrdWidth=new int[] {0,0,30,150,100,40,60};
						sfield=new string[] {"wbm","pym","szm","ywm","ypbm"};
						ssql="select a.ggid,cjid,0 rowno,s_ypspm,s_ypgg,s_ypdw,shh from yp_ypcjd a,yp_ypbm b "+
							" where a.ggid=b.ggid and a.bdelete=0 and a.n_ypzlx in(select ypzlx from yp_gllx where deptid="+InstanceForm.BCurrentDept.DeptId+")  ";
						TrasenFrame.Forms.Fshowcard f3=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,Constant.CustomFilterType,control.Text.Trim(),ssql);
						f3.Location=point;
						f3.Width=700;
						f3.Height=300;
						f3.Text="选择原料";
						f3.ShowDialog(this);
						row=f3.dataRow;
						if (row!=null) 
						{
							this.txtylmc.Text=row["s_ypspm"].ToString();
							this.txtylmc.Tag=row["cjid"].ToString().Trim();
                            DataTable tb = Yp.SelectYpcl(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(row["cjid"]), InstanceForm.BDatabase);
							if (tb.Rows.Count==0)
							{
								lbldw.Text=row["S_YPDW"].ToString().Trim();
								lbldw.Tag="1";
							}
							else
							{
                                lbldw.Text = Yp.SeekYpdw(Convert.ToInt32(tb.Rows[0]["zxdw"]), InstanceForm.BDatabase);
								lbldw.Tag=tb.Rows[0]["dwbl"].ToString();
							}

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


		private void butdel_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=(DataTable)this.myDataGrid2.DataSource ;
				int nrow=this.myDataGrid2.CurrentCell.RowNumber;
				if (nrow>tb.Rows.Count-1) return;
				int ID=Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["id"],"0"));

				string ssql="delete from yp_zjtc where id="+ID +"";
				InstanceForm.BDatabase.DoCommand(ssql);
				MessageBox.Show("删除成功");
				DataRow row=tb.Rows[nrow];
				tb.Rows.Remove(row);
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

		private void butsave_Click(object sender, System.EventArgs e)
		{
			if (Convert.ToInt32(Convertor.IsNull(this.txtzzypmc.Tag,"0"))==0)
			{
				MessageBox.Show("请输入自制药品名称");
				return;
			}

			try
			{
				this.butsave.Enabled=false;
				InstanceForm.BDatabase.BeginTransaction();

				string ssql="";
				string ylmc="";
				int tccjid=0;decimal lll=0;string ypdw="";int ydwbl=0;int ylcjid=0;string zf="";
				DataTable tb=(DataTable)this.myDataGrid2.DataSource;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{

					int id=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["id"],"0"));
					ylmc=tb.Rows[i]["原料名称"].ToString();
					tccjid=Convert.ToInt32(this.txtzzypmc.Tag);
					lll=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["理论量"],"0"));
					ypdw=tb.Rows[i]["单位"].ToString();
					ydwbl=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["ydwbl"],"0"));
					ylcjid=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["cjid"],"0"));
					zf=this.txtzf.Text.Trim();
					if (ylcjid!=0)
					{
						if (id==0)
						{
                            ssql = "insert into yp_zjtc(ylcjid,ypsl,ypdw,ydwbl,tccjid,bz) values(" + ylcjid + "," + lll + "," + Yp.SeekYpdw(ypdw.Trim(), InstanceForm.BDatabase) + "," + ydwbl + "," + tccjid + ",'" + zf.Trim() + "') ";
						}
						else
						{
                            ssql = "update yp_zjtc set (ylcjid,ypsl,ypdw,ydwbl,tccjid,bz) =(" + ylcjid + "," + lll + "," + Yp.SeekYpdw(ypdw.Trim(), InstanceForm.BDatabase) + "," + ydwbl + "," + tccjid + ",'" + zf.Trim() + "') where id=" + id + " ";
						}
						InstanceForm.BDatabase.DoCommand(ssql);
					}
				}

				InstanceForm.BDatabase.CommitTransaction();
				MessageBox.Show("保存成功");
				this.butsave.Enabled=true;
				this.AddDataMydataGrid1(0);
				this.AddDataMydataGrid1(Convert.ToInt32(this.txtzzypmc.Tag));
			}
			catch(System.Exception err)
			{
				this.butsave.Enabled=true;
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show("发生错误"+err.Message);
			}
		}


		private void butadd_Click(object sender, System.EventArgs e)
		{
			if (Convert.ToInt32(Convertor.IsNull(this.txtylmc.Tag,"0"))==0)
			{
				MessageBox.Show("请输入原料名称");
				return;
			}

			DataTable tb=(DataTable)this.myDataGrid2.DataSource;
			DataRow row=tb.NewRow();
			row["序号"]=tb.Rows.Count+1;
			row["原料名称"]=this.txtylmc.Text.Trim();
			row["规格"]=this.lblgg.Text.Trim();
			row["理论量"]=Convertor.IsNull(this.txtlll.Text.Trim(),"0");
			row["单位"]=this.lbldw.Text.Trim();
			row["YDWBL"]=Convertor.IsNull(this.lbldw.Tag.ToString(),"0");
			row["cjid"]=this.txtylmc.Tag.ToString();
			tb.Rows.Add(row);

			this.txtylmc.Text="";
			this.txtylmc.Tag="0";
			this.txtlll.Text="0";
			this.txtlll.Tag="0";
			this.lbldw.Text="";
			this.lbldw.Tag="";
			this.txtylmc.Focus();
		}

		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			this.AddDataMydataGrid1(Convert.ToInt32(tb.Rows[nrow]["cjid"]));
		}

		private void GotoNext(object sender, KeyPressEventArgs e)
		{ 
			Control control=(Control)sender;
			if (e.KeyChar==13 )
				this.SelectNextControl(control,true,false,true,true);

		}

		private void butclear_Click(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid2.DataSource;
			tb.Rows.Clear();

			this.txtzzypmc.Text="";
			this.txtzzypmc.Tag="0";
			this.txtzf.Text="";
			this.txtylmc.Text="";
			this.txtylmc.Tag="0";
			this.txtlll.Text="";
			this.lblgg.Text="";
			this.lbldw.Text="";
		}



	}
}
