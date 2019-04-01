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
//using YpClass

namespace ts_yf_tjbb
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmylfltj : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttj;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private myDataGrid.myDataGrid myDataGrid1;
		private Rectangle RcDraw;
		private System.Windows.Forms.Panel panel1;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private DataTable _tab=new DataTable("tab");
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private myDataGrid.myDataGrid myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.ComboBox cmbyjks;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butprintmx;
		private DataSet _dtset=null;

		public Frmylfltj(MenuTag menuTag,string chineseName,Form mdiParent)
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmylfltj));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butprintmx = new System.Windows.Forms.Button();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butprintmx);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.buttj);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // butprintmx
            // 
            this.butprintmx.Location = new System.Drawing.Point(632, 16);
            this.butprintmx.Name = "butprintmx";
            this.butprintmx.Size = new System.Drawing.Size(88, 32);
            this.butprintmx.TabIndex = 18;
            this.butprintmx.Text = "打印明细(&P)";
            this.butprintmx.Click += new System.EventHandler(this.butprintmx_Click);
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(68, 22);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(96, 20);
            this.cmbyjks.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "药剂科室";
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(336, 24);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(112, 21);
            this.dtp2.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(320, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(208, 24);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(110, 21);
            this.dtp1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(168, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "日期从";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(720, 16);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(72, 32);
            this.butquit.TabIndex = 11;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(544, 16);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 32);
            this.butprint.TabIndex = 10;
            this.butprint.Text = "打印汇总(&D)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // buttj
            // 
            this.buttj.Location = new System.Drawing.Point(464, 16);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(78, 32);
            this.buttj.TabIndex = 9;
            this.buttj.Text = "统计(&T)";
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
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
            this.statusBar1.Size = new System.Drawing.Size(944, 23);
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
            this.statusBarPanel3.Width = 1000;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.Silver;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.PreferredRowHeight = 20;
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(725, 413);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "名称";
            this.dataGridTextBoxColumn1.Width = 250;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "金额";
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "百分比";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "总金额";
            this.dataGridTextBoxColumn4.Width = 0;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "id";
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 438);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(211, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(733, 438);
            this.panel3.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(733, 438);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.myDataGrid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(725, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "汇总";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.myDataGrid2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(914, 453);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "明细";
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.Silver;
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.PreferredRowHeight = 20;
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.Size = new System.Drawing.Size(914, 453);
            this.myDataGrid2.TabIndex = 1;
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
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn14});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "cjid";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "品名";
            this.dataGridTextBoxColumn7.Width = 180;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "规格";
            this.dataGridTextBoxColumn8.Width = 120;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "厂家";
            this.dataGridTextBoxColumn9.Width = 120;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "零售价";
            this.dataGridTextBoxColumn10.Width = 70;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "数量";
            this.dataGridTextBoxColumn11.Width = 65;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "单位";
            this.dataGridTextBoxColumn12.Width = 40;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "金额";
            this.dataGridTextBoxColumn13.Width = 80;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "百分比";
            this.dataGridTextBoxColumn15.Width = 55;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "总金额";
            this.dataGridTextBoxColumn14.Width = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(208, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 438);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 438);
            this.panel2.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(208, 438);
            this.treeView1.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // Frmylfltj
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmylfltj";
            this.Text = "药理分类统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmxspm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>


		private void Frmxspm_Load(object sender, System.EventArgs e)
		{
			try
			{

				//初始化
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");
				FunBase.CsDataGrid(this.myDataGrid2,this.myDataGrid2.TableStyles[0],"Tbmx");
				
				AddTree();

	
				AddcmbYjks(cmbyjks,"药房");
	

				
			}
			catch(System.Exception err)
			{ 
				MessageBox.Show("发生错误"+err.Message);
			}


		}

		private static void AddcmbYjks(System.Windows.Forms.ComboBox cmb,string kslx)
		{
			string ssql="";
			if (Yp.SelectYjks(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase).Rows.Count==0)
				ssql=" select '全部' KSMC,0 DEPTID union select KSMC,DEPTID from yp_yjks a where  qybz=1 and a.kslx='"+kslx.Trim()+"' ";
			else
				ssql="select KSMC,DEPTID from yp_yjks a where deptid="+InstanceForm.BCurrentDept.DeptId+" ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);

			cmb.DataSource=tb;
			cmb.ValueMember="DEPTID";
			cmb.DisplayMember="KSMC";
		}


		private void AddTree()
		{
			this.treeView1.Nodes.Clear();
			this.treeView1.ImageList=this.imageList1;
			TreeNode node = treeView1.Nodes.Add("药品分类目录");
			node.Tag="0";
			node.ImageIndex=0;
			AddTreeViewNode(node);
			node.Expand();
			
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();
		}

		private void AddTreeViewNode(TreeNode treeNode)
		{
			treeNode.Nodes.Clear();
			DataTable tb=new DataTable();
			string ssql="";
			ssql="select 0 序号,flbh 编号,flmc  名称,pym 拼音码,wbm 五笔码,flms 描述,dbo.fun_yp_ylfl(fid) 所属上级编目,cast(bdelete as smallint) 禁用,fid,id,yjdbz from yp_ylfl where  fid="+Convert.ToInt64(Convertor.IsNull(treeNode.Tag,"-10"))+" order by fid ";
			tb=InstanceForm.BDatabase.GetDataTable(ssql);
			FunBase.AddRowtNo(tb);
			treeNode.Nodes.Clear();
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				TreeNode Cnode = treeNode.Nodes.Add(tb.Rows[i]["名称"].ToString());
				Cnode.Tag=tb.Rows[i]["id"];
				if (tb.Rows[i]["yjdbz"].ToString()=="1") Cnode.ImageIndex=1; else Cnode.ImageIndex=0;
				AddTreeViewNode(Cnode);
			}
		}


		private void buttj_Click(object sender, System.EventArgs e)
		{
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                buttj.Enabled = false;
                if (this.treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请在左边选择您想要统计的分类", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Value = Convert.ToInt32(cmbyjks.SelectedValue);
                parameters[1].Value = this.dtp1.Value.ToShortDateString();
                parameters[2].Value = this.dtp2.Value.ToShortDateString();
                parameters[3].Value = Convert.ToInt64(this.treeView1.SelectedNode.Tag);
                parameters[4].Value = _menuTag.Function_Name;

                parameters[0].Text = "@deptid";
                parameters[1].Text = "@dtp1";
                parameters[2].Text = "@dtp2";
                parameters[3].Text = "@fid";
                parameters[4].Text = "@functionname";


                //_tab=InstanceForm.BDatabase.GetDataTable("SP_YK_select_ylfltj",parameters,30);
                _dtset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_YF_select_ylfltj", parameters, _dtset, "dtset", 240);

                //汇总列表
                _dtset.Tables[1].TableName = "Tb";
                this.myDataGrid1.DataSource = (DataTable)_dtset.Tables[1];
                this.myDataGrid1.Refresh();

                decimal bfbl = 0;
                if (Convert.ToDecimal(Convertor.IsNull(_dtset.Tables[1].Rows[0]["总金额"], "0")) != 0)
                {
                    bfbl = Math.Round(
                        Convert.ToDecimal(Convertor.IsNull(_dtset.Tables[1].Rows[_dtset.Tables[1].Rows.Count - 1]["金额"], "0"))
                        / Convert.ToDecimal(Convertor.IsNull(_dtset.Tables[1].Rows[0]["总金额"], "0")) * 100
                        , 2);
                }
                this.myDataGrid1.CaptionText = "总金额：" + _dtset.Tables[1].Rows[0]["总金额"].ToString() +
                    "     其中 [" + this.treeView1.SelectedNode.Text + "] 占总额的" + Convert.ToString((bfbl)) + "%";


                //明细列表
                _dtset.Tables[0].TableName = "Tbmx";
                if (_dtset.Tables[0].Rows.Count != 0)
                {
                    DataRow row = _dtset.Tables[0].NewRow();
                    row["品名"] = "合计";
                    row["数量"] = Convertor.IsNull(_dtset.Tables[0].Compute("sum(数量)", ""), "0");
                    row["金额"] = Convertor.IsNull(_dtset.Tables[0].Compute("sum(金额)", ""), "0");
                    _dtset.Tables[0].Rows.Add(row);
                }


                this.myDataGrid2.DataSource = (DataTable)_dtset.Tables[0];
                this.myDataGrid2.Refresh();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                buttj.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
		}


		//查找当前选择节点的一级子节点
		private void SelectTree1Node(string ssql,string nodeName,string nodeTag)
		{
			DataTable tb=new DataTable();
			string ss="";
			ss="select id,flmc from yp_ylfl where fid="+Convert.ToInt64(nodeTag)+" order by fid ";
			tb=InstanceForm.BDatabase.GetDataTable(ss);

			tb.TableName="Tb";
			this.myDataGrid1.DataSource=tb;
			this.myDataGrid1.TableStyles[0].MappingName="Tb";

			this.myDataGrid1.CaptionText="当前节点："+nodeName;
			
		}

		//递归每前TAB下的节点金额之和
		private void AddTreeViewNode(DataTable tb)
		{
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				string ssql="select * from dbo.fun_tlfl_child("+Convert.ToInt64(tb.Rows[0]["id"])+")";
				DataTable tab=InstanceForm.BDatabase.GetDataTable(ssql);
				
				
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
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset1 Dset=new ts_Yk_ReportView.Dataset1();
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.药理分类统计汇总.NewRow();
					myrow["mc"]=Convert.ToString(tb.Rows[i]["名称"]);
					myrow["je"]=Convert.ToString(tb.Rows[i]["金额"]);
					myrow["bfbl"]=Convert.ToString(tb.Rows[i]["百分比"]);
					Dset.药理分类统计汇总.Rows.Add(myrow);

				}

				ParameterEx[] parameters=new ParameterEx[4];
				parameters[0].Text="swhere";
				parameters[0].Value="药剂科室："+cmbyjks.Text.Trim()+"      日期从："+dtp1.Value.ToShortDateString()+" 到 "+dtp2.Value.ToShortDateString();
				parameters[1].Text="swhere1";
				parameters[1].Value=this.myDataGrid1.CaptionText;
				parameters[2].Text="title";
				parameters[2].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+this.Text;
				parameters[3].Text="username";
				parameters[3].Value=InstanceForm.BCurrentUser.Name;

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.药理分类统计汇总 ,Constant.ApplicationDirectory+"\\Report\\YK_药理分类统计(汇总).rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();


			}
			catch(System.Exception err) 
			{
				MessageBox.Show(err.Message);
			}
		}

		private void butprintmx_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=(DataTable)this.myDataGrid2.DataSource;
				ts_Yk_ReportView.Dataset1 Dset=new ts_Yk_ReportView.Dataset1();
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.药理分类统计明细.NewRow();
					myrow["pm"]=Convert.ToString(tb.Rows[i]["品名"]);
					myrow["gg"]=Convert.ToString(tb.Rows[i]["规格"]);
					myrow["cj"]=Convert.ToString(tb.Rows[i]["厂家"]);
					myrow["lsj"]=Convert.ToString(tb.Rows[i]["零售价"]);
					myrow["sl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["数量"],"0"));
					myrow["dw"]=Convert.ToString(tb.Rows[i]["单位"]);
					myrow["je"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["金额"],"0"));
					myrow["bfbl"]=Convert.ToString(tb.Rows[i]["百分比"]);
					Dset.药理分类统计明细.Rows.Add(myrow);

				}

				ParameterEx[] parameters=new ParameterEx[4];
				parameters[0].Text="swhere";
				parameters[0].Value="药剂科室："+cmbyjks.Text.Trim()+"      日期从："+dtp1.Value.ToShortDateString()+" 到 "+dtp2.Value.ToShortDateString();
				parameters[1].Text="swhere1";
				parameters[1].Value=this.myDataGrid1.CaptionText;
				parameters[2].Text="title";
				parameters[2].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+this.Text;
				parameters[3].Text="username";
				parameters[3].Value=InstanceForm.BCurrentUser.Name;

				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.药理分类统计明细 ,Constant.ApplicationDirectory+"\\Report\\YK_药理分类统计(明细).rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();


			}
			catch(System.Exception err) 
			{
				MessageBox.Show(err.Message);
			}
		}



	}
}
