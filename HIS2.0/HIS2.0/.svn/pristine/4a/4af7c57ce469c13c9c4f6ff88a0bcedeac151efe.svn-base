using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_zdlr
{
	/// <summary>
	/// 医嘱录入 的摘要说明。
	/// </summary>
	public class frmJRYZLR : System.Windows.Forms.Form
	{
		
		//自定义变量		
        private BaseFunc myFunc;	
		private bool Close_check=false;
		private bool isPY=true;
		private string sTab0="长期账单",sTab1="临时账单",sTab2="所有长期账单",sTab3="所有临时账单";
		private long   cYZ=0;
		private double  cJL=0;
        private string cYF="";        //上一次录入的医嘱内容、剂量、用法

		string sPaint="",sPaintPS="",sPaintWZX="",sName="";

		int max_len0=0,max_len1=0,max_len2=0;//最长的医嘱长度,最长的医嘱长度(有数量单位的),最长的数量单位长度	

		public DataView SelectDataView=new DataView();
		private System.Windows.Forms.Panel panel全屏;
		private System.Windows.Forms.Panel panel左;
		private System.Windows.Forms.Panel panel右中;
		private System.Windows.Forms.Panel panel右下;
		private System.Windows.Forms.Panel panel右中上;
		private System.Windows.Forms.DateTimePicker DtpbeginDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pane右中下;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Splitter splitter左右;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Button btExit;
		private System.Windows.Forms.Label lbPY;
		private System.Windows.Forms.Label lbSZ;
		private System.Windows.Forms.Button button2;
		private DataGridEx GrdSel;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle4;
		private System.Windows.Forms.Button BtChangeZH;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btCheck;
		private System.Windows.Forms.Button btCls;
		private System.Windows.Forms.Button btDel;
		private System.Windows.Forms.Button btInsert;
		private System.Windows.Forms.Button btSaveModel;
		private System.Windows.Forms.Button btOpenModel;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button bt立即执行;
		private System.Windows.Forms.ProgressBar progressBar1;
		private 病人信息.PatientInfo patientInfo1;
		private DataGridEx myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private DataGridEx myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.Button bt刷新;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtInpatNo;
		private System.Windows.Forms.Button btnSeek;
		private System.ComponentModel.IContainer components;

		public frmJRYZLR()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

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
			this.panel全屏 = new System.Windows.Forms.Panel();
			this.panel右下 = new System.Windows.Forms.Panel();
			this.patientInfo1 = new 病人信息.PatientInfo();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.lbSZ = new System.Windows.Forms.Label();
			this.lbPY = new System.Windows.Forms.Label();
			this.btSave = new System.Windows.Forms.Button();
			this.btCls = new System.Windows.Forms.Button();
			this.btDel = new System.Windows.Forms.Button();
			this.btInsert = new System.Windows.Forms.Button();
			this.btExit = new System.Windows.Forms.Button();
			this.btSaveModel = new System.Windows.Forms.Button();
			this.btCheck = new System.Windows.Forms.Button();
			this.btOpenModel = new System.Windows.Forms.Button();
			this.BtChangeZH = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.bt立即执行 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panel右中 = new System.Windows.Forms.Panel();
			this.pane右中下 = new System.Windows.Forms.Panel();
            this.GrdSel = new DataGridEx();
			this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.myDataGrid1 = new DataGridEx();
			this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
			this.panel右中上 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.splitter左右 = new System.Windows.Forms.Splitter();
			this.panel左 = new System.Windows.Forms.Panel();
			this.bt刷新 = new System.Windows.Forms.Button();
            this.myDataGrid2 = new DataGridEx();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtInpatNo = new System.Windows.Forms.TextBox();
			this.btnSeek = new System.Windows.Forms.Button();
			this.panel全屏.SuspendLayout();
			this.panel右下.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.panel右中.SuspendLayout();
			this.pane右中下.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GrdSel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.panel右中上.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.panel左.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel全屏
			// 
			this.panel全屏.Controls.Add(this.panel右下);
			this.panel全屏.Controls.Add(this.panel右中);
			this.panel全屏.Controls.Add(this.splitter左右);
			this.panel全屏.Controls.Add(this.panel左);
			this.panel全屏.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel全屏.Location = new System.Drawing.Point(0, 0);
			this.panel全屏.Name = "panel全屏";
			this.panel全屏.Size = new System.Drawing.Size(1028, 721);
			this.panel全屏.TabIndex = 0;
			// 
			// panel右下
			// 
			this.panel右下.Controls.Add(this.patientInfo1);
			this.panel右下.Controls.Add(this.progressBar1);
			this.panel右下.Controls.Add(this.lbSZ);
			this.panel右下.Controls.Add(this.lbPY);
			this.panel右下.Controls.Add(this.btSave);
			this.panel右下.Controls.Add(this.btCls);
			this.panel右下.Controls.Add(this.btDel);
			this.panel右下.Controls.Add(this.btInsert);
			this.panel右下.Controls.Add(this.btExit);
			this.panel右下.Controls.Add(this.btSaveModel);
			this.panel右下.Controls.Add(this.btCheck);
			this.panel右下.Controls.Add(this.btOpenModel);
			this.panel右下.Controls.Add(this.BtChangeZH);
			this.panel右下.Controls.Add(this.dataGrid1);
			this.panel右下.Controls.Add(this.button2);
			this.panel右下.Controls.Add(this.bt立即执行);
			this.panel右下.Controls.Add(this.button1);
			this.panel右下.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel右下.Location = new System.Drawing.Point(164, 550);
			this.panel右下.Name = "panel右下";
			this.panel右下.Size = new System.Drawing.Size(864, 240);
			this.panel右下.TabIndex = 6;
			// 
			// patientInfo1
			// 
			this.patientInfo1.BackColor = System.Drawing.Color.DarkTurquoise;
			this.patientInfo1.Location = new System.Drawing.Point(0, 48);
			this.patientInfo1.Name = "patientInfo1";
			this.patientInfo1.Size = new System.Drawing.Size(460, 124);
			this.patientInfo1.TabIndex = 50;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(2, 37);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(858, 8);
			this.progressBar1.TabIndex = 49;
			// 
			// lbSZ
			// 
			this.lbSZ.ForeColor = System.Drawing.SystemColors.Desktop;
			this.lbSZ.Location = new System.Drawing.Point(780, 8);
			this.lbSZ.Name = "lbSZ";
			this.lbSZ.Size = new System.Drawing.Size(76, 24);
			this.lbSZ.TabIndex = 46;
			this.lbSZ.Text = "数字码(&F&1&2)";
			this.lbSZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbPY
			// 
			this.lbPY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbPY.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lbPY.Location = new System.Drawing.Point(696, 8);
			this.lbPY.Name = "lbPY";
			this.lbPY.Size = new System.Drawing.Size(80, 24);
			this.lbPY.TabIndex = 45;
			this.lbPY.Text = "拼音码(&F&1&1)";
			this.lbPY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btSave
			// 
			this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btSave.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btSave.ImageIndex = 3;
			this.btSave.Location = new System.Drawing.Point(484, 8);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(60, 24);
			this.btSave.TabIndex = 43;
			this.btSave.Text = "保存(&S)";
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// btCls
			// 
			this.btCls.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btCls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btCls.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btCls.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btCls.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btCls.ImageIndex = 8;
			this.btCls.Location = new System.Drawing.Point(348, 8);
			this.btCls.Name = "btCls";
			this.btCls.Size = new System.Drawing.Size(60, 24);
			this.btCls.TabIndex = 42;
			this.btCls.Text = "清空(&C)";
			this.btCls.Click += new System.EventHandler(this.btCls_Click);
			// 
			// btDel
			// 
			this.btDel.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btDel.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDel.ImageIndex = 7;
			this.btDel.Location = new System.Drawing.Point(280, 8);
			this.btDel.Name = "btDel";
			this.btDel.Size = new System.Drawing.Size(60, 24);
			this.btDel.TabIndex = 41;
			this.btDel.Text = "删除(&D)";
			this.btDel.Click += new System.EventHandler(this.btDel_Click);
			// 
			// btInsert
			// 
			this.btInsert.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btInsert.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btInsert.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btInsert.ImageIndex = 6;
			this.btInsert.Location = new System.Drawing.Point(212, 8);
			this.btInsert.Name = "btInsert";
			this.btInsert.Size = new System.Drawing.Size(60, 24);
			this.btInsert.TabIndex = 40;
			this.btInsert.Text = "插入(&I)";
			this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
			// 
			// btExit
			// 
			this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btExit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btExit.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btExit.ImageIndex = 4;
			this.btExit.Location = new System.Drawing.Point(620, 8);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(60, 24);
			this.btExit.TabIndex = 39;
			this.btExit.Text = "退出(&X)";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// btSaveModel
			// 
			this.btSaveModel.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btSaveModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btSaveModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btSaveModel.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btSaveModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btSaveModel.ImageIndex = 9;
			this.btSaveModel.Location = new System.Drawing.Point(112, 8);
			this.btSaveModel.Name = "btSaveModel";
			this.btSaveModel.Size = new System.Drawing.Size(92, 24);
			this.btSaveModel.TabIndex = 38;
			this.btSaveModel.Text = "保存模板(&M)";
			this.btSaveModel.Click += new System.EventHandler(this.btSaveModel_Click);
			// 
			// btCheck
			// 
			this.btCheck.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btCheck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btCheck.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btCheck.ImageIndex = 2;
			this.btCheck.Location = new System.Drawing.Point(416, 8);
			this.btCheck.Name = "btCheck";
			this.btCheck.Size = new System.Drawing.Size(60, 24);
			this.btCheck.TabIndex = 36;
			this.btCheck.Text = "整理(&Z)";
			this.btCheck.Click += new System.EventHandler(this.btCheck_Click);
			// 
			// btOpenModel
			// 
			this.btOpenModel.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btOpenModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btOpenModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btOpenModel.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btOpenModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btOpenModel.ImageIndex = 1;
			this.btOpenModel.Location = new System.Drawing.Point(10, 8);
			this.btOpenModel.Name = "btOpenModel";
			this.btOpenModel.Size = new System.Drawing.Size(94, 24);
			this.btOpenModel.TabIndex = 32;
			this.btOpenModel.Text = "打开模板(&O)";
			this.btOpenModel.Click += new System.EventHandler(this.btOpenModel_Click);
			// 
			// BtChangeZH
			// 
			this.BtChangeZH.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.BtChangeZH.Location = new System.Drawing.Point(628, 8);
			this.BtChangeZH.Name = "BtChangeZH";
			this.BtChangeZH.Size = new System.Drawing.Size(48, 24);
			this.BtChangeZH.TabIndex = 27;
			this.BtChangeZH.Text = "ZH(&A)";
			this.BtChangeZH.Click += new System.EventHandler(this.BtChangeZH_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGrid1.CaptionBackColor = System.Drawing.Color.MediumSeaGreen;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(460, 48);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
			this.dataGrid1.Size = new System.Drawing.Size(404, 124);
			this.dataGrid1.TabIndex = 28;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.button2.Enabled = false;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Location = new System.Drawing.Point(692, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(168, 32);
			this.button2.TabIndex = 44;
			// 
			// bt立即执行
			// 
			this.bt立即执行.Enabled = false;
			this.bt立即执行.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt立即执行.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.bt立即执行.ForeColor = System.Drawing.SystemColors.Desktop;
			this.bt立即执行.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bt立即执行.ImageIndex = 9;
			this.bt立即执行.Location = new System.Drawing.Point(552, 8);
			this.bt立即执行.Name = "bt立即执行";
			this.bt立即执行.Size = new System.Drawing.Size(60, 24);
			this.bt立即执行.TabIndex = 48;
			this.bt立即执行.Text = "发送(&E)";
			this.bt立即执行.Click += new System.EventHandler(this.bt立即执行_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.button1.Enabled = false;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(2, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(686, 32);
			this.button1.TabIndex = 30;
			// 
			// panel右中
			// 
			this.panel右中.Controls.Add(this.pane右中下);
			this.panel右中.Controls.Add(this.panel右中上);
			this.panel右中.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel右中.Location = new System.Drawing.Point(164, 0);
			this.panel右中.Name = "panel右中";
			this.panel右中.Size = new System.Drawing.Size(864, 550);
			this.panel右中.TabIndex = 4;
			// 
			// pane右中下
			// 
			this.pane右中下.Controls.Add(this.GrdSel);
			this.pane右中下.Controls.Add(this.myDataGrid1);
			this.pane右中下.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pane右中下.Location = new System.Drawing.Point(0, 32);
			this.pane右中下.Name = "pane右中下";
			this.pane右中下.Size = new System.Drawing.Size(864, 518);
			this.pane右中下.TabIndex = 0;
			// 
			// GrdSel
			// 
			this.GrdSel.AllowNavigation = false;
			this.GrdSel.AllowSorting = false;
			this.GrdSel.BackgroundColor = System.Drawing.SystemColors.Window;
			this.GrdSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.GrdSel.CaptionVisible = false;
			this.GrdSel.DataMember = "";
			this.GrdSel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.GrdSel.Location = new System.Drawing.Point(192, 136);
			this.GrdSel.Name = "GrdSel";
			this.GrdSel.ReadOnly = true;
			this.GrdSel.RowHeadersVisible = false;
			this.GrdSel.Size = new System.Drawing.Size(280, 184);
			this.GrdSel.TabIndex = 32;
			this.GrdSel.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																							   this.dataGridTableStyle4});
			this.GrdSel.Visible = false;
            this.GrdSel.myKeyDown += new myDelegate(this.GrdSel_myKeyDown);
			this.GrdSel.CurrentCellChanged += new System.EventHandler(this.GrdSel_CurrentCellChanged);
			// 
			// dataGridTableStyle4
			// 
			this.dataGridTableStyle4.AllowSorting = false;
			this.dataGridTableStyle4.DataGrid = this.GrdSel;
			this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle4.MappingName = "";
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.AllowSorting = false;
			this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.MediumSeaGreen;
			this.myDataGrid1.CaptionText = "床位费";
			this.myDataGrid1.CaptionVisible = false;
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.Size = new System.Drawing.Size(864, 518);
			this.myDataGrid1.TabIndex = 1;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle3});
			this.myDataGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myDataGrid1_MouseDown);
			this.myDataGrid1.myKeyDown += new myDelegate(this.myDataGrid1_myKeyDown);
			this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
			this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
			// 
			// dataGridTableStyle3
			// 
			this.dataGridTableStyle3.AllowSorting = false;
			this.dataGridTableStyle3.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle3.MappingName = "";
			this.dataGridTableStyle3.PreferredColumnWidth = 0;
			this.dataGridTableStyle3.RowHeaderWidth = 15;
			// 
			// panel右中上
			// 
			this.panel右中上.Controls.Add(this.label1);
			this.panel右中上.Controls.Add(this.DtpbeginDate);
			this.panel右中上.Controls.Add(this.tabControl1);
			this.panel右中上.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel右中上.Location = new System.Drawing.Point(0, 0);
			this.panel右中上.Name = "panel右中上";
			this.panel右中上.Size = new System.Drawing.Size(864, 32);
			this.panel右中上.TabIndex = 28;
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(492, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 12);
			this.label1.TabIndex = 28;
			this.label1.Text = "开始时间：";
			// 
			// DtpbeginDate
			// 
			this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
			this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.DtpbeginDate.Location = new System.Drawing.Point(558, 0);
			this.DtpbeginDate.Name = "DtpbeginDate";
			this.DtpbeginDate.ShowUpDown = true;
			this.DtpbeginDate.Size = new System.Drawing.Size(176, 23);
			this.DtpbeginDate.TabIndex = 99;
			this.DtpbeginDate.Value = new System.DateTime(2003, 9, 20, 19, 22, 0, 0);
			this.DtpbeginDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtpbeginDate_KeyUp);
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.tabControl1.ItemSize = new System.Drawing.Size(60, 20);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(876, 66);
			this.tabControl1.TabIndex = 24;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.tabPage1.Location = new System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(868, 38);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "长期账单  ";
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 24);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(868, 38);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "临时账单  ";
			this.tabPage4.Visible = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(868, 38);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Text = "所有长期账单";
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 24);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(868, 38);
			this.tabPage3.TabIndex = 5;
			this.tabPage3.Text = "所有临时账单";
			// 
			// splitter左右
			// 
			this.splitter左右.Location = new System.Drawing.Point(160, 0);
			this.splitter左右.Name = "splitter左右";
			this.splitter左右.Size = new System.Drawing.Size(4, 721);
			this.splitter左右.TabIndex = 1;
			this.splitter左右.TabStop = false;
			// 
			// panel左
			// 
			this.panel左.Controls.Add(this.bt刷新);
			this.panel左.Controls.Add(this.myDataGrid2);
			this.panel左.Controls.Add(this.groupBox1);
			this.panel左.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel左.Location = new System.Drawing.Point(0, 0);
			this.panel左.Name = "panel左";
			this.panel左.Size = new System.Drawing.Size(160, 721);
			this.panel左.TabIndex = 0;
			// 
			// bt刷新
			// 
			this.bt刷新.BackColor = System.Drawing.Color.PaleGreen;
			this.bt刷新.Location = new System.Drawing.Point(94, 2);
			this.bt刷新.Name = "bt刷新";
			this.bt刷新.Size = new System.Drawing.Size(56, 20);
			this.bt刷新.TabIndex = 84;
			this.bt刷新.Text = "刷新(&R)";
			this.bt刷新.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bt刷新.Click += new System.EventHandler(this.bt刷新_Click);
			// 
			// myDataGrid2
			// 
			this.myDataGrid2.AllowSorting = false;
			this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid2.CaptionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid2.CaptionForeColor = System.Drawing.Color.Black;
			this.myDataGrid2.CaptionText = "介入病人信息";
			this.myDataGrid2.DataMember = "";
			this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid2.Name = "myDataGrid2";
			this.myDataGrid2.ReadOnly = true;
			this.myDataGrid2.RowHeaderWidth = 20;
			this.myDataGrid2.Size = new System.Drawing.Size(160, 678);
			this.myDataGrid2.TabIndex = 24;
			this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AllowSorting = false;
			this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtInpatNo);
			this.groupBox1.Controls.Add(this.btnSeek);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 678);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(160, 43);
			this.groupBox1.TabIndex = 33;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "住院号查询";
			// 
			// txtInpatNo
			// 
			this.txtInpatNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtInpatNo.Location = new System.Drawing.Point(6, 16);
			this.txtInpatNo.Name = "txtInpatNo";
			this.txtInpatNo.Size = new System.Drawing.Size(96, 21);
			this.txtInpatNo.TabIndex = 57;
			this.txtInpatNo.Text = "";
			this.txtInpatNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInpatNo_KeyPress);
			// 
			// btnSeek
			// 
			this.btnSeek.BackColor = System.Drawing.SystemColors.Control;
			this.btnSeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSeek.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnSeek.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnSeek.Location = new System.Drawing.Point(106, 16);
			this.btnSeek.Name = "btnSeek";
			this.btnSeek.Size = new System.Drawing.Size(48, 21);
			this.btnSeek.TabIndex = 58;
			this.btnSeek.Text = "定位";
			this.btnSeek.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
			// 
			// frmJRYZLR
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(1028, 721);
			this.Controls.Add(this.panel全屏);
			this.Name = "frmJRYZLR";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "介入账单录入";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmJRYZLR_Closing);
			this.Load += new System.EventHandler(this.frmJRYZLR_Load);
			this.panel全屏.ResumeLayout(false);
			this.panel右下.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.panel右中.ResumeLayout(false);
			this.pane右中下.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GrdSel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.panel右中上.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.panel左.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//Modify By Tany 2005-06-08
		//新增模块，用于专项录入介入治疗的病人帐单
		private void frmJRYZLR_Load(object sender, System.EventArgs e)
		{
			bt刷新_Click(null,null);

			DataTable jrbinTb = (DataTable)myDataGrid2.DataSource;

			if(jrbinTb==null || jrbinTb.Rows.Count==0)
			{
				MessageBox.Show("没有找到介入申请的病人信息！","提示",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				this.Close();
				return;
			}
			
			myFunc.SelectBin(true,this.myDataGrid2,5,6,7,9);
			this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID,ClassStatic.Current_BabyID,ClassStatic.Current_isMY);								

			
			//初始化录入网格
			string[] GrdMappingName={"ID","嘱号","类型","医嘱内容","剂量","单价","单位","用法","频率","首次","执行科室","HOItem_ID","exec_dept","times_defalut","iscomplex","oldprice"};
			string[] GrdHeaderText ={"ID","嘱号","类型","账单内容","数量","单价","单位","用法","频率","首次",        "",         "",         "",             "","",""};
			int[]    GrdWidth      ={   0,    40,    80,       350,    40,  80  ,  40,    90,    40,    40,         0,          0,          0,              0,0,0};
			bool[]   GrdReadOnly   ={true,  true,  true,     false, false,false,  true, false, false, false,      true,       true,       true,           true,true,true};
			this.myFunc.InitmyGrd(GrdMappingName,GrdHeaderText,GrdWidth,GrdReadOnly,this.myDataGrid1);

			//初始化医嘱号
			ShowmyDate(false,true,false);

            this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);                      //服务器当前系统日期
            this.DtpbeginDate.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Date.ToString() + " 23:59:59");					//系统日期    -最大
            System.TimeSpan diff = new System.TimeSpan(Convert.ToInt32(new SystemCfg(7007).Config), 0, 0, 0);
            this.DtpbeginDate.MinDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Subtract(diff);	    //系统日期-Begin_MinDays天 -最小	
//			this.DtpbeginDate.Focus();		
			myDataGrid1.CurrentCell = new DataGridCell(0,2);
		}

		private void ShowmyDate(bool isClear,bool isInitYZH,bool isSendKey)
		{
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			if (isClear)
			{
				myTb.Rows.Clear();
				myTb.Rows.Add(myTb.NewRow());
			}
			this.myDataGrid1.DataSource=myTb;

			//初始化医嘱号
			if (isInitYZH)
			{				
//				int yztype=(this.tabControl1.SelectedTab.Text.Trim()==sTab0?2:3);
//				string sSql=@"select max(Group_Id) as YZH "+
//					"  from Zy_OrderRecord " +
//					" where inpatient_id=" + ClassStatic.Current_BinID +
//					"       and baby_id=" + ClassStatic.Current_BabyID +
//					"       and mngtype=" + yztype.ToString();
//				DataTable myTempTb=myQuery.myOpen(sSql);
//				if (myTempTb.Rows[0]["YZH"].ToString().Trim()=="") 
//				{
					myTb.Rows[0]["嘱号"]="1";
//				}
//				else					
//				{
//					myTb.Rows[0]["嘱号"]=(Convert.ToInt32(myTempTb.Rows[0]["YZH"].ToString())+1).ToString();
//				}

			}

			if (isSendKey)
			{				
				this.myDataGrid1.CurrentCell=new DataGridCell(0,2);
				this.myDataGrid1.Focus();
				//if(this.tabControl1.SelectedTab.Text.Trim()==sTab0)
				//{
				//	SendKeys.Send(Keys.NumPad7.ToString());
				//}
				//if(this.tabControl1.SelectedTab.Text.Trim()==sTab1)
				//{
				//	SendKeys.Send(Keys.NumPad8.ToString());
				//}

				if  (myTb.Rows[0]["类型"].ToString().Trim()=="")
				{
					SendKeys.Send(Keys.NumPad8.ToString());
				}
				else
				{
					SendKeys.Send("{tab}");
				}

			}
		}

		private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataTable myTb=(DataTable)this.myDataGrid2.DataSource;
			if (myTb.Rows.Count==0) return ;		

			//得到病人基本信息
			int nrow=this.myDataGrid2.CurrentCell.RowNumber;	
			this.myDataGrid2.Select(nrow);
            ClassStatic.Current_BinID = new Guid(this.myDataGrid2[nrow, 2].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(this.myDataGrid2[nrow, 3]);
            ClassStatic.Current_DeptID = Convert.ToInt64(this.myDataGrid2[nrow, 4]);	//病人当前所属科室
            ClassStatic.Current_isMY = Convert.ToInt16(this.myDataGrid2[nrow, 5]);
            this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);
			this.DtpbeginDate.Focus();

			this.tabControl1_SelectedIndexChanged(sender,e);	
		}


		private void DtpbeginDate_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(Convert.ToInt32(e.KeyData)==13)
			{				
				ShowmyDate(false,true,true);				
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//询问用户是否保存切换前的医嘱
			if(myDataGrid1.ReadOnly==false)
				DataIsSave(sender);

			if(this.tabControl1.SelectedTab.Text.Trim()==sTab0 || this.tabControl1.SelectedTab.Text.Trim()==sTab1)
			{
				this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
				this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

				//初始化录入网格
				string[] GrdMappingName={"ID","嘱号","类型","医嘱内容","剂量","单价","单位","用法","频率","首次","执行科室","HOItem_ID","exec_dept","times_defalut","iscomplex","oldprice"};
				string[] GrdHeaderText ={"ID","嘱号","类型","账单内容","数量","单价","单位","用法","频率","首次",        "",         "",         "",             "","",""};
				int[]    GrdWidth      ={   0,    40,    80,       350,    40,    80,  40  ,  90,    40,    40,         0,          0,          0,              0,0,0};
				bool[]   GrdReadOnly   ={true,  true,  true,     false, false,false , true, false, false, false,      true,       true,       true,           true,true,true};
				this.myFunc.InitmyGrd(GrdMappingName,GrdHeaderText,GrdWidth,GrdReadOnly,this.myDataGrid1);

				//myDataGrid1.DataSource=null;
				myDataGrid1.ReadOnly=false;

				if (this.GrdSel.Visible) this.GrdSel.Visible=false;
			
				//判断类型			
				if(this.tabControl1.SelectedTab.Text.Trim()==sTab0)
				{
					myDataGrid1.TableStyles[0].GridColumnStyles[7].Width=90;
					myDataGrid1.TableStyles[0].GridColumnStyles[8].Width=40;
					myDataGrid1.TableStyles[0].GridColumnStyles[9].Width=40;
				}
				else if(this.tabControl1.SelectedTab.Text.Trim()==sTab1)
				{
					myDataGrid1.TableStyles[0].GridColumnStyles[7].Width=0;
					myDataGrid1.TableStyles[0].GridColumnStyles[8].Width=0;
					myDataGrid1.TableStyles[0].GridColumnStyles[9].Width=0;
				}

				//清空网格,并重绘制
				ShowmyDate(true,true,false);
				myDataGrid1.Refresh();			

				btOpenModel.Enabled=true;
				btSaveModel.Enabled=true;
				btSave.Enabled=true;
				btCheck.Enabled=true;
				btInsert.Enabled=true;
				btCls.Enabled=true;
				bt立即执行.Enabled=false;
			
				this.DtpbeginDate.MaxDate=Convert.ToDateTime(myFunc.Sys_Date().Date.ToString() + " 23:59:59");	
				this.DtpbeginDate.Value=myFunc.Sys_Date();   
//				this.DtpbeginDate.Focus();

				myDataGrid1.CurrentCell = new DataGridCell(0,2);

			}
			else
			{
				btOpenModel.Enabled=false;
				btSaveModel.Enabled=false;
				btSave.Enabled=false;
				btCheck.Enabled=false;
				btInsert.Enabled=false;
				btCls.Enabled=false;
				bt立即执行.Enabled=true;
				
				this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
				this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

				string[] GrdMappingName={ "status_flag","Order_ID","Group_ID","Num","Unit","Order_Usage","frequency","Dropsper","Dosage",
											"ntype","c1","exec_dept","day1","second1","day2","second2", "AUDITING_USER","AUDITING_USER1","order_euser","order_euser1","item_code",     
											"选",
											"开日期","开时间","医嘱内容","开嘱医生","开嘱转抄","开嘱核对",
											"停日期","停时间","停嘱医生","停嘱转抄","停嘱核对","执行时间","发送护士","执行科室"};															
				int[]    GrdWidth ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,6,6,60,8,8,8,6,6,8,8,8,16,8,10};
				int[]    Alignment     ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
				int[]	 ReadOnly      ={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
				this.InitGridYZ(GrdMappingName,GrdWidth,Alignment,ReadOnly,this.myDataGrid1);

				myDataGrid1.DataSource=null;
				myDataGrid1.ReadOnly=true;

				ShowOrderDate();
				myDataGrid1.Refresh();
			}
		}


		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			int nrow,ncol;
			//首先得到基本的网格信息
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			nrow=this.myDataGrid1.CurrentCell.RowNumber;
			ncol=this.myDataGrid1.CurrentCell.ColumnNumber;

			if(this.tabControl1.SelectedTab.Text.Trim()==sTab0 || this.tabControl1.SelectedTab.Text.Trim()==sTab1)
			{
				//判断是不是最后一个
				if(nrow>myTb.Rows.Count-1)
				{
					myTb.Rows.Add(myTb.NewRow());
					this.myDataGrid1.DataSource=myTb;
					//为防止失去焦点
					DataGridCell myCell=new DataGridCell(nrow,ncol);
					this.myDataGrid1.CurrentCell=myCell ;

					DataTable myTbTemp=(DataTable)this.dataGrid1.DataSource;
					if (myTbTemp!=null) myTbTemp.Rows.Clear();				
				}
				else
				{
					long HOitem_ID=myFunc.GetValue(myTb.Rows[nrow]["HOitem_ID"].ToString());															
					double num=myFunc.GetValueF(myTb.Rows[nrow]["剂量"].ToString());
					string User_Name=myTb.Rows[nrow]["用法"].ToString();
					if ( cYZ!=HOitem_ID || cJL!=num  || ( cYF!=User_Name && this.tabControl1.SelectedTab.Text.Trim()==sTab1) )
					{
						//赋当前值
						cYZ=HOitem_ID;
						cJL=num;
						cYF=User_Name;

						//不是一组医嘱的第一行，则不显示用法的附加项目
						if (nrow>0 && (myTb.Rows[nrow-1]["医嘱内容"].ToString().Trim()!="" || myTb.Rows[nrow-1]["HOItem_ID"].ToString().Trim()!=""))
						{
							User_Name="";
						}

						DataTable myTbTemp=myQuery.SetItemInfo("",HOitem_ID,num,User_Name); //*js);
						this.dataGrid1.DataSource=myTbTemp;		
						
					}
					//判断是否为医嘱内容的输入
					this.GrdSel.Visible=false;
				}

				//控制只有单价为0并且不是套餐才能够更改价格
				DataGridTextBoxColumn txtColPrice = (DataGridTextBoxColumn)myDataGrid1.TableStyles[0].GridColumnStyles["单价"];
				if(myTb.Rows[nrow]["oldprice"].ToString().Trim()=="0" && myTb.Rows[nrow]["iscomplex"].ToString().Trim()=="0")
				{
					txtColPrice.ReadOnly=false;
				}
				else
				{
					txtColPrice.ReadOnly=true;
				}
			}

		}

		private void myDataGrid1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(this.tabControl1.SelectedTab.Text.Trim() != sTab0 && this.tabControl1.SelectedTab.Text.Trim() != sTab1) return;

			//避免鼠标离开时产生的错误
			
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			int ncol=this.myDataGrid1.CurrentCell.ColumnNumber;
			string ColumnName=this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();

			if(this.GrdSel.Visible==true)
			{
				myTb.Rows[nrow][ColumnName]="";
				if(ColumnName.Trim()=="医嘱内容") 	myTb.Rows[nrow]["HOItem_ID"]="";
				if(ColumnName.Trim()=="执行科室")	myTb.Rows[nrow]["Exec_Dept"]="";

				DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
				txtCol.TextBox.Text="";

				this.myDataGrid1.DataSource=myTb;
			}
		}

		private bool myDataGrid1_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
			//Modify By Tany 2004-10-23
			//加入对单价输入的支持

			if(this.tabControl1.SelectedTab.Text.Trim() != sTab0 && this.tabControl1.SelectedTab.Text.Trim() != sTab1) return false;

			//变量定义
			//string sSql="";
			long keyInt=Convert.ToInt32(keyData);
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			int ncol=this.myDataGrid1.CurrentCell.ColumnNumber;
			string ColumnName=this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();
			string SelStrType="";

			//确定此列为只读,输入数字或字母或F功能键等，屏蔽输入
			//if(this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].ReadOnly==true && (keyInt>=65 && keyInt<=122))return true;
			if(this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].ReadOnly==true && ((keyInt>=65 && keyInt<=135) && keyInt!=104 && keyInt!=105)) return true;
			
			DataGridTextBoxColumn txtColYz=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles["医嘱内容"];
			#region 类型的输入
			if(ColumnName=="类型" && txtColYz.TextBox.Text.Trim()=="")//如果有医嘱内容则不允许修改类型			 
			{
				//判断是否输入了数字键
				//if(keyInt>=48 && keyInt<=57)  
				if((keyInt>=56 && keyInt<=57) || keyInt==104 || keyInt==105)   //只允许输入 8、9
				{
					string tempType=GetyzType(keyInt>57?keyInt-96:keyInt-48);
					if ( tempType!="" && (nrow==0 || (nrow>0 && myTb.Rows[nrow-1]["医嘱内容"].ToString().Trim()=="") ) )
					{
						myTb.Rows[nrow][ColumnName]=tempType;
						this.myDataGrid1.DataSource=myTb;
						SendKeys.Send("{tab}");
					}
					//屏蔽输入
					return true;
				}
			}
			#endregion

			#region 医嘱内容、频率、用法的列录入
			if ( ColumnName=="医嘱内容" || (ColumnName=="频率"  && this.tabControl1.SelectedTab.Text.Trim()==sTab0 ) || (ColumnName=="用法" && this.tabControl1.SelectedTab.Text.Trim()==sTab0 ))		
			{			

				#region 有效性判断
				//"类型"若为空，则取上一行的"类型"
				if (ColumnName=="医嘱内容") 
				{
					SelStrType=(myTb.Rows[nrow]["类型"].ToString()!=""?myTb.Rows[nrow]["类型"].ToString():"000000");
					if  ( nrow>0 && SelStrType=="000000" )
					{
						SelStrType=(myTb.Rows[nrow-1]["类型"].ToString()!=""?myTb.Rows[nrow-1]["类型"].ToString():"000000");
					}											
				}

				//若上一行的“医嘱内容”不为空，则屏蔽录入频率、用法
				if ( nrow>0 && keyInt>=65 && keyInt<=105 && myTb.Rows[nrow-1]["医嘱内容"].ToString().Trim()!="" && (ColumnName=="用法" || ColumnName=="频率")  )
				{
					return true;
				}		
		
				#endregion

				#region 判断在当前输入状态下是不是输入了英文字或数字
				//if ( (keyInt>=65 && keyInt<=90 && isPY==true) || ( ( (keyInt>=48 && keyInt<=57) || (keyInt>=96 && keyInt<=105) ) && this.isPY==false))
				if ( (keyInt>=65 && keyInt<=90 ) || ( (keyInt>=48 && keyInt<=57) || (keyInt>=96 && keyInt<=105)  )  )
				{
					if (keyInt>90) keyInt-=48;

					//得到输入的数据
					DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
					string SelData=txtCol.TextBox.Text;
					if(SelData.Trim()!="")
					{
						SelData=(txtCol.TextBox.SelectionLength==txtCol.TextBox.TextLength?"":SelData);
					}

					//显示查到的数据
					if (ColumnName=="医嘱内容")
					{
						ShowSelCard(SelData+Convert.ToChar(keyInt),SelStrType);
						//不屏蔽输入
						return false;	
					}
					else if (myTb.Rows[nrow]["医嘱内容"].ToString()!="")
					{
						ShowSelCardOther(SelData+Convert.ToChar(keyInt),ColumnName,nrow,ncol);
						//不屏蔽输入
						return false;	
					}
					else
					{
						//医嘱内容为空时,屏蔽输入用法和频率
						return true;
					}

					
					
				}										
				#endregion 

				#region 判断不在当前输入状态下是不是输入了英文字或数字 (屏蔽此功能，允许在拼音状态下输入数字)
				//if ( (keyInt>=65 && keyInt<=90 && isPY==false) || ( ( (keyInt>=48 && keyInt<=57) || (keyInt>=96 && keyInt<=105) ) && this.isPY==true))
				//{
				//	//屏蔽输入
				//	return true;
				//}
				#endregion 

				#region 退格键
				if(keyInt==8 && this.GrdSel.Visible==true)
				{
					//得到输入的数据
					DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
					string SelData=txtCol.TextBox.Text;
					if(SelData.Trim()!="")
					{
						if (txtCol.TextBox.SelectionLength==txtCol.TextBox.TextLength )
						{
							SelData="";
						}
						else
						{
							SelData=SelData.Substring(0,SelData.Length-1);
						}
					}
					//显示查到的数据					
					if(SelData.Trim()!="")
					{
						if (ColumnName=="医嘱内容")
						{
							ShowSelCard(SelData,SelStrType);
						}
						else
						{
							ShowSelCardOther(SelData,ColumnName,nrow,ncol);
						}						
					}
					else
					{
						this.GrdSel.Visible=false;
					}
					//不屏蔽输入
					return false;
				}
				#endregion 

				#region 上下左右键
				if( (keyInt==40 || keyInt==38 || keyInt==37 || keyInt==39) && this.GrdSel.Visible==true)
				{
					if(this.GrdSel.VisibleRowCount>0)
					{
						//this.GrdSel.CurrentCell=new DataGridCell(0,1);
						if (ColumnName=="医嘱内容") 
							this.GrdSel.Select(0);
						else
							this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);
					}
					this.GrdSel.Focus();
					//屏蔽输入
					return true;
				}
				#endregion 

				#region 回车键
				if (keyInt==13 && this.GrdSel.Visible)
				{
					switch(ColumnName)
					{
						case "医嘱内容":
							GetCardData(48);
							break;
						case "用法":
							GetCardDataUsage(this.GrdSel.CurrentCell.RowNumber);
							break;
						case "频率":
							GetCardDataPL(this.GrdSel.CurrentCell.RowNumber);
							break;
					}						
				}					
				#endregion 

				#region F11,F12键切换输入方法
				if ( (keyInt==122 && isPY==false) || (keyInt==123 && isPY==true)) 
				{					
					this.isPY=(this.isPY?false:true);					
					this.lbPY.ForeColor=(isPY?SystemColors.HotTrack:SystemColors.Desktop);
					this.lbPY.BorderStyle=(isPY?BorderStyle.Fixed3D:BorderStyle.None);
					this.lbSZ.ForeColor=(isPY?SystemColors.Desktop:SystemColors.HotTrack);
					this.lbSZ.BorderStyle=(isPY?BorderStyle.None:BorderStyle.Fixed3D);
					this.GrdSel.Visible=false;	
					//this.GrdSel.Dispose();
					this.myDataGrid1.Focus();	
					DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[this.myDataGrid1.CurrentCell.ColumnNumber];
					if (txtCol.TextBox.Text!="")
					{
						SendKeys.Send("{tab}");
						SendKeys.Send("{left}");  //选中已经输入的数据
					}						
					return true;
				}
				#endregion

			}
			#endregion

			#region 剂量的输入
			if (ColumnName=="剂量")	
			{
				//医嘱内容为空，屏蔽输入数字和小数点
				if (((keyInt>=48 && keyInt<=57) || (keyInt==110) )  && (myTb.Rows[nrow]["医嘱内容"].ToString()=="")) return true;

				//有效性判断
				if(keyInt==13)
				{
					try
					{
						this.myDataGrid1.EndEdit(this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol],nrow,false);
						if (myTb.Rows[nrow]["剂量"].ToString()!="")	//确认输入了剂量
						{														
							if(myFunc.GetValueF(myTb.Rows[nrow]["剂量"].ToString())<=0)
							{
								MessageBox.Show(this, "剂量不能为0或负数！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);								
								myTb.Rows[nrow]["剂量"]=1;								
							}							
						}
						else
						{
							myTb.Rows[nrow]["剂量"]=1;
						}
					}
					catch(System.Data.OleDb.OleDbException err)
					{
						MessageBox.Show(err.ToString());
					}
					catch(System.Exception err)
					{
						MessageBox.Show(err.ToString());
					}

				}
			}
			#endregion

			#region 单价的输入
			if (ColumnName=="单价")	
			{
				//医嘱内容为空，屏蔽输入数字和小数点
				if (((keyInt>=48 && keyInt<=57)|| (keyInt==110)) && (myTb.Rows[nrow]["医嘱内容"].ToString()=="")) return true;

				//有效性判断
				if(keyInt==13)
				{
					try
					{
						this.myDataGrid1.EndEdit(this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol],nrow,false);
						if (myTb.Rows[nrow]["单价"].ToString()!="")	//确认输入了
						{														
							if(myFunc.GetValueF(myTb.Rows[nrow]["单价"].ToString())<=0)
							{
								MessageBox.Show(this, "单价不能为零或负数！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);								
								myTb.Rows[nrow]["单价"]=myTb.Rows[nrow]["oldprice"];
							}							
						}
						else
						{
							myTb.Rows[nrow]["单价"]=myTb.Rows[nrow]["oldprice"];
						}
					}
					catch(System.Data.OleDb.OleDbException err)
					{
						MessageBox.Show(err.ToString());
					}
					catch(System.Exception err)
					{
						MessageBox.Show(err.ToString());
					}

				}

			}
			#endregion

			#region 首次的输入
			if (ColumnName=="首次" && (keyInt==13  || keyInt==9)  && this.tabControl1.SelectedTab.Text==sTab0)  // (enter or tab)长嘱时
			{
				if (Convert.ToSingle(myTb.Rows[nrow]["首次"])<0)
				{
					MessageBox.Show(this, "首次执行次数不能小于零！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);						
					myTb.Rows[nrow]["首次"]=myTb.Rows[nrow]["times_defalut"].ToString().Trim();
				}
				else if ( Convert.ToSingle(myTb.Rows[nrow]["首次"]) > Convert.ToSingle(myTb.Rows[nrow]["times_defalut"]) )
				{
					MessageBox.Show(this, "首次执行次数不能大于"+myTb.Rows[nrow]["times_defalut"].ToString()+"！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);							
					myTb.Rows[nrow]["首次"]=myTb.Rows[nrow]["times_defalut"].ToString().Trim();
				}
			}
			#endregion

			#region 按键整体控制		

			//屏蔽输入上下左右键
			if( (keyInt==40  || keyInt==38 || keyInt==37 || keyInt==39) && this.GrdSel.Visible==true)
			{				
				return true;
			}

			//判断是不是控制键,针对所有列   //====================================================================================================================
			switch(keyInt)
			{
				case 13:
					DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
					if(txtCol.TextBox.Text.Trim()=="" && txtCol.MappingName=="医嘱内容")
					{
						SendKeys.Send("{esc}");
						txtCol.TextBox.Focus();
						this.GrdSel.Visible=false;
						return true;
					}

					//长嘱最后一列
					if (ColumnName=="首次" && this.tabControl1.SelectedIndex==0)	
					{
						this.btCheck_Click(this.myDataGrid1,new EventArgs());		//先整理数据				
						this.SendTabKey(10);											//为最后一个，连续送七格
						return true;												//屏蔽输入
					}										
					
					//长嘱为剂量  用来实现连续跳格
					if(ColumnName=="剂量" && this.tabControl1.SelectedIndex==0) 
					{
						//第0行
						if(nrow==0)
						{
							if(myTb.Rows[nrow]["oldprice"].ToString().Trim()=="0" && myTb.Rows[nrow]["iscomplex"].ToString().Trim()=="0")
							{
								this.SendTabKey(1);			//价格为0并且不为套餐，跳到价格
								return true;
							}
							else
							{
								this.SendTabKey(3);			//单位为只渎	连续跳格
								return true;				//屏蔽输入
							}
						}
						
						//上一行无内容
						if(myTb.Rows[nrow-1]["医嘱内容"].ToString().Trim()=="" || myTb.Rows[nrow-1]["HOItem_ID"].ToString().Trim()=="")
						{
							if(myTb.Rows[nrow]["oldprice"].ToString().Trim()=="0" && myTb.Rows[nrow]["iscomplex"].ToString().Trim()=="0")
							{
								this.SendTabKey(1);			//价格为0并且不为套餐，跳到价格
								return true;
							}
							else
							{
								this.SendTabKey(3);			//单位为只渎	连续跳格
								return true;				//屏蔽输入
							}
						}
						else
						{
							if(myTb.Rows[nrow]["医嘱内容"].ToString().Trim()=="" || myTb.Rows[nrow]["HOItem_ID"].ToString().Trim()=="")
							{
								if(myTb.Rows[nrow]["oldprice"].ToString().Trim()=="0" && myTb.Rows[nrow]["iscomplex"].ToString().Trim()=="0")
								{
									this.SendTabKey(1);			//价格为0并且不为套餐，跳到价格
									return true;
								}
								else
								{
									this.SendTabKey(3);			//单位为只渎	连续跳格
									return true;				//屏蔽输入
								}
							}															
							else
							{
								if(myTb.Rows[nrow]["oldprice"].ToString().Trim()=="0" && myTb.Rows[nrow]["iscomplex"].ToString().Trim()=="0")
								{
									this.SendTabKey(1);			//价格为0并且不为套餐，跳到价格
									return true;
								}
								else
								{
									//上行有内容，直接跳到下行
									this.SendTabKey(15);										//为最后一个，连续送十二格
									return true;												//屏蔽输入
								}
							}
						}
					}

					//长嘱为单价 跳到用法
					if(ColumnName=="单价" && this.tabControl1.SelectedIndex==0) 
					{
						//第0行
						if(nrow==0)
						{
							this.SendTabKey(2);			//单位为只读	连续跳格
							return true;				//屏蔽输入
						}
						
						//上一行无内容
						if(myTb.Rows[nrow-1]["医嘱内容"].ToString().Trim()=="" || myTb.Rows[nrow-1]["HOItem_ID"].ToString().Trim()=="")
						{
							this.SendTabKey(2);			//单位为只渎	连续跳格
							return true;				//屏蔽输入
						}
						else
						{
							if(myTb.Rows[nrow]["医嘱内容"].ToString().Trim()=="" || myTb.Rows[nrow]["HOItem_ID"].ToString().Trim()=="")
							{
								this.SendTabKey(2);			//单位为只渎	连续跳格
								return true;				//屏蔽输入	
							}															
							else
							{
								//上行有内容，直接跳到下行
								this.SendTabKey(14);										//为最后一个，连续送十二格
								return true;												//屏蔽输入
							}
						}
					}

					//临嘱最后一列
					if (ColumnName=="单位" && this.tabControl1.SelectedIndex==1)	
					{
						this.btCheck_Click(this.myDataGrid1,new EventArgs());		//先整理数据				
						this.SendTabKey(13);										//为最后一个，连续送十三格
						return true;												//屏蔽输入
					}

					//临嘱为剂量  用来实现连续跳格
					if(ColumnName=="剂量" && this.tabControl1.SelectedIndex==1) 
					{
						if(myTb.Rows[nrow]["oldprice"].ToString().Trim()=="0" && myTb.Rows[nrow]["iscomplex"].ToString().Trim()=="0")
						{
							this.SendTabKey(1);			//价格为0并且不为套餐，跳到价格
							return true;
						}
						else
						{
							this.btCheck_Click(this.myDataGrid1,new EventArgs());		//先整理数据				
							this.SendTabKey(15);										//连续跳到下行
							return true;												//屏蔽输入
						}
					}
					
					//临嘱为单价 连续跳格
					if(ColumnName=="单价" && this.tabControl1.SelectedIndex==1) 
					{
						this.SendTabKey(14);			//单位为只渎	连续跳格
						return true;				//屏蔽输入
					}
					
					//通用
					SendKeys.Send("{tab}");
					this.GrdSel.Visible=false;
					//屏蔽输入
					return true;
					//break;
				case 27:  //esc
					this.GrdSel.Visible=false;
					break;	
			}
			#endregion
			//====================================================================================================================================================================							

			return false;
		}
		
		private void SendTabKey(int num)
		{
			for(int i=0;i<=num-1;i++)
			{
				SendKeys.Send("{tab}");
			}
		}

		private void BtChangeZH_Click(object sender, System.EventArgs e)
		{
			//变量定义
			int nrow,ncol,i;
			long grid_YZH=0;
			string ColumnName="";

			//变量付初始值
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			nrow=this.myDataGrid1.CurrentCell.RowNumber;
			ncol=this.myDataGrid1.CurrentCell.ColumnNumber;
			ColumnName=myTb.Columns[ncol].ColumnName.Trim();

			//有效性判断，至少要有一组以上的医嘱
			if(nrow==0)return;
			else
			{
				for(i=myTb.Rows.Count-1;i>=0;i--)
				{
					if(myTb.Rows[i]["嘱号"].ToString().Trim()!="")
					{
						grid_YZH=Convert.ToInt32(myTb.Rows[i]["嘱号"])+1;
						break;
					}
				}
			}

			DataGridCell myCell;
			if(myTb.Rows[nrow]["医嘱内容"].ToString().Trim()=="")
			{
				myCell=new DataGridCell(nrow+1,2);
				if(nrow+1>myTb.Rows.Count-1)
				{
					myTb.Rows.Add(myTb.NewRow());
					myTb.Rows[nrow+1]["嘱号"]=grid_YZH.ToString();
					this.myDataGrid1.DataSource=myTb;
				}
			}
			else
			{
				myCell=new DataGridCell(nrow+2,2);
				if(nrow+1>myTb.Rows.Count-1)myTb.Rows.Add(myTb.NewRow());
				if(nrow+2>myTb.Rows.Count-1)
				{
					myTb.Rows.Add(myTb.NewRow());
					myTb.Rows[nrow+2]["嘱号"]=grid_YZH.ToString();
					this.myDataGrid1.DataSource=myTb;
				}

			}
			this.myDataGrid1.CurrentCell=myCell;
		
		}


		//显示医嘱类型
		private string GetyzType(long nType)
		{
			string sSql="select name from Base_OrderType where code=" + nType.ToString();
			//string sSql="select name from Base_OrderType where code=8";  //只允许输入8项目
			DataTable myTb=myQuery.myOpen(sSql);
			if(myTb.Rows.Count>0)
			{
				return myTb.Rows[0]["name"].ToString().Trim();
			}
			else
			{
				return "";
			}
		}

		//显示医嘱内容
		private void GetCardData(long keyInt)
		{
			//选定病人的信息
			//"病区","床号","姓名","介入科室","申请时间","INPATIENT_ID","Baby_ID","DEPT_BR","JR_DEPT","isMY","ward_id","inpatient_no"
			int nSel = myDataGrid2.CurrentRowIndex;
			string sDeptJr = myDataGrid2[nSel,8].ToString(); //用于执行科室

			//首先得到当前网格的信息
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			int ncol=this.myDataGrid1.CurrentCell.ColumnNumber;	
			DataView mySelView=(DataView)this.GrdSel.DataSource;;
			int nSelRow=(int)keyInt-48;

			DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
	
			//选择超出范围
			if(nSelRow>mySelView.Count-1)
			{
				txtCol.TextBox.Text="";
				return;
			}
			else
			{
				#region 内容的添入

				if(mySelView[nSelRow]["备注"].ToString().Trim()=="非医保" && patientInfo1.lbJSLX.Text.Trim().Substring(0,2)=="医保")
				{
					if((MessageBox.Show("[ "+mySelView[nSelRow]["内容"].ToString().Trim()+" ]是自费项目，"+"你确定要给该病人记帐吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2))==DialogResult.No)
					{
						txtCol.TextBox.Text="";
						return;
					}
				}

				txtCol.TextBox.Text = mySelView[nSelRow]["内容"].ToString();
				txtCol.TextBox.BackColor=System.Drawing.Color.SkyBlue ;

				if(nrow==0)
				{
					//医嘱内容
					myTb.Rows[nrow]["医嘱内容"]=mySelView[nSelRow]["内容"];
					//剂量,单位，用法，频率，首次，执行科室
					myTb.Rows[nrow]["剂量"]=mySelView[nSelRow]["剂量"];
					myTb.Rows[nrow]["单价"]=mySelView[nSelRow]["iscomplex"].ToString().Trim()=="0"?mySelView[nSelRow]["单价"]:"";
					myTb.Rows[nrow]["单位"]=mySelView[nSelRow]["单位"];
					myTb.Rows[nrow]["用法"]="";
					myTb.Rows[nrow]["iscomplex"]=mySelView[nSelRow]["iscomplex"];
					myTb.Rows[nrow]["oldprice"]=mySelView[nSelRow]["单价"];

					//判断类型
					if(tabControl1.SelectedTab.Text.Trim()==this.sTab0)
					{
						//限长期帐单
						myTb.Rows[nrow]["频率"]="Qd";
						myTb.Rows[nrow]["首次"]="1";
						myTb.Rows[nrow]["times_defalut"]=1;
					}
					else
					{
						//限临时帐单
						myTb.Rows[nrow]["频率"]="";
						myTb.Rows[nrow]["首次"]="";
						myTb.Rows[nrow]["times_defalut"]=0;
					}
					
					myTb.Rows[nrow]["HOItem_ID"]=mySelView[nSelRow]["医嘱编号"];

					//执行科室为病人当前所属科室
					//如果项目有执行科室则为该执行科室，为0（没有）或1（全院）则为本科室 Modify By Tany 2005-05-22
					myTb.Rows[nrow]["Exec_Dept"]=mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="0" || mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="1"?sDeptJr:mySelView[nSelRow]["Exec_Dept"].ToString().Trim();
					myTb.Rows[nrow]["执行科室"]=mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="0" || mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="1"?BaseFun.SeekDeptName(Convert.ToDecimal(sDeptJr)):mySelView[nSelRow]["执行科室"].ToString().Trim();					
					/*
					if(mySelView[nSelRow]["default_dept"].ToString()!="")
					{
						myTb.Rows[nrow]["Exec_Dept"]=mySelView[nSelRow]["default_dept"];
						myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(myFunc.GetValue(mySelView[nSelRow]["default_dept"].ToString()));
					}
					else
					{
						myTb.Rows[nrow]["Exec_Dept"]=ClassStatic.Static_WardID.ToString();
						myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(Convert.ToDecimal(ClassStatic.Current_DeptID));
					}*/
					
				}
				else
				{
					//上一列无内容
					if(myTb.Rows[nrow-1][ncol].ToString().Trim()=="")
					{
						//医嘱内容
						myTb.Rows[nrow]["医嘱内容"]=mySelView[nSelRow]["内容"];
						//剂量,单位，用法，频率，首次，执行科室
						myTb.Rows[nrow]["剂量"]=mySelView[nSelRow]["剂量"];
						myTb.Rows[nrow]["单价"]=mySelView[nSelRow]["iscomplex"].ToString().Trim()=="0"?mySelView[nSelRow]["单价"]:"";
						myTb.Rows[nrow]["单位"]=mySelView[nSelRow]["单位"];
						myTb.Rows[nrow]["用法"]="";
						myTb.Rows[nrow]["iscomplex"]=mySelView[nSelRow]["iscomplex"];
						myTb.Rows[nrow]["oldprice"]=mySelView[nSelRow]["单价"];

						//判断类型
						if(tabControl1.SelectedTab.Text.Trim()==this.sTab0)
						{
							//限长期帐单
							myTb.Rows[nrow]["频率"]="qd";
							myTb.Rows[nrow]["首次"]="1";
							myTb.Rows[nrow]["times_defalut"]=1;
						}
						else
						{
							//限临时帐单
							myTb.Rows[nrow]["频率"]="";
							myTb.Rows[nrow]["首次"]="";
							myTb.Rows[nrow]["times_defalut"]=0;
						}

						myTb.Rows[nrow]["HOItem_ID"]=mySelView[nSelRow]["医嘱编号"];

						//执行科室为病人当前所属科室
						//如果项目有执行科室则为该执行科室，为0（没有）或1（全院）则为本科室 Modify By Tany 2005-05-22
						myTb.Rows[nrow]["Exec_Dept"]=mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="0" || mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="1"?sDeptJr:mySelView[nSelRow]["Exec_Dept"].ToString().Trim();
						myTb.Rows[nrow]["执行科室"]=mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="0" || mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="1"?BaseFun.SeekDeptName(Convert.ToDecimal(sDeptJr)):mySelView[nSelRow]["执行科室"].ToString().Trim();
						/*if(mySelView[nSelRow]["default_dept"].ToString()!="")
						{
							myTb.Rows[nrow]["Exec_Dept"]=mySelView[nSelRow]["default_dept"];
							myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(myFunc.GetValue(mySelView[nSelRow]["default_dept"].ToString()));
						}
						else
						{
							myTb.Rows[nrow]["Exec_Dept"]=ClassStatic.Static_WardID.ToString();
							myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(Convert.ToDecimal(ClassStatic.Current_DeptID));
						}*/
					}
					else
					{
						//医嘱内容
						myTb.Rows[nrow]["医嘱内容"]=mySelView[nSelRow]["内容"];
						//类型,剂量,单位，用法，频率，首次，执行科室
						myTb.Rows[nrow]["剂量"]=mySelView[nSelRow]["剂量"];

						myTb.Rows[nrow]["嘱号"]=myTb.Rows[nrow-1]["嘱号"];
						myTb.Rows[nrow]["类型"]=myTb.Rows[nrow-1]["类型"];
						myTb.Rows[nrow]["单价"]=mySelView[nSelRow]["iscomplex"].ToString().Trim()=="0"?mySelView[nSelRow]["单价"]:"";
						myTb.Rows[nrow]["单位"]=mySelView[nSelRow]["单位"];
						myTb.Rows[nrow]["用法"]=myTb.Rows[nrow-1]["用法"];
						myTb.Rows[nrow]["频率"]=myTb.Rows[nrow-1]["频率"];
						myTb.Rows[nrow]["首次"]=myTb.Rows[nrow-1]["首次"];						
						myTb.Rows[nrow]["times_defalut"]=myTb.Rows[nrow-1]["times_defalut"];
						myTb.Rows[nrow]["HOItem_ID"]=mySelView[nSelRow]["医嘱编号"];
						myTb.Rows[nrow]["iscomplex"]=mySelView[nSelRow]["iscomplex"];
						myTb.Rows[nrow]["oldprice"]=mySelView[nSelRow]["单价"];

						//如果项目有执行科室则为该执行科室，为0（没有）或1（全院）则为本科室 Modify By Tany 2005-05-22
						myTb.Rows[nrow]["Exec_Dept"]=mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="0" || mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="1"?sDeptJr:mySelView[nSelRow]["Exec_Dept"].ToString().Trim();
						myTb.Rows[nrow]["执行科室"]=mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="0" || mySelView[nSelRow]["Exec_Dept"].ToString().Trim()=="1"?BaseFun.SeekDeptName(Convert.ToDecimal(sDeptJr)):mySelView[nSelRow]["执行科室"].ToString().Trim();
						/*
						if(mySelView[nSelRow]["default_dept"].ToString()!="")
						{
							myTb.Rows[nrow]["Exec_Dept"]=mySelView[nSelRow]["default_dept"];
							myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(myFunc.GetValue(mySelView[nSelRow]["default_dept"].ToString()));
						}
						else
						{
							myTb.Rows[nrow]["Exec_Dept"]=ClassStatic.Static_WardID.ToString();
							myTb.Rows[nrow]["执行科室"]=BaseFun.SeekDeptName(Convert.ToDecimal(ClassStatic.Current_DeptID));
						}*/
					}					
				}
				#endregion
				
				this.myDataGrid1.DataSource=myTb;

				#region 显示药品信息

				string mySHH=myTb.Rows[nrow]["HOItem_ID"].ToString();
				//有效性判断
				if( mySHH!="")
				{
					if(mySHH.Substring(1,1)=="Y")
					{
						//this.priceInfo1.cCon=this.cCon ;
						//this.priceInfo1.SetYpInfo(mySHH);
					}
					else
					{
						//this.priceInfo1.ClearYpInfo();
					}
				}

				#endregion
			}
			this.GrdSel.Visible=false;			
		}

		private void GetCardDataPL(int theSel)
		{
			int nrow,ncol;
			//首先得到当前网格的信息
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			nrow=this.myDataGrid1.CurrentCell.RowNumber;
			ncol=this.myDataGrid1.CurrentCell.ColumnNumber;			


			int nSelRow;
			DataTable mySelTbTemp=(DataTable)this.GrdSel.DataSource;
			myTb=(DataTable)this.myDataGrid1.DataSource;

			nSelRow=(int)theSel;

			//得到网格选择的信息
			//判断选择的有效性
			if(nSelRow<=mySelTbTemp.Rows.Count-1)
			{
				//给网格安全的付值
				myTb.Rows[nrow]["频率"]=mySelTbTemp.Rows[nSelRow]["频率"];
				DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
				txtCol.TextBox.Text=mySelTbTemp.Rows[nSelRow]["频率"].ToString().Trim();

				myTb.Rows[nrow]["首次"]=mySelTbTemp.Rows[nSelRow]["ExecNum"];
				myTb.Rows[nrow]["times_defalut"]=mySelTbTemp.Rows[nSelRow]["ExecNum"];
				txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol+1];
				txtCol.TextBox.Text=mySelTbTemp.Rows[nSelRow]["ExecNum"].ToString().Trim();
				
				this.myDataGrid1.DataSource=myTb;
				this.GrdSel.Visible=false;

			}
			else
			{
				myTb.Rows[nrow]["频率"]="";
				DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
				txtCol.TextBox.Text="";
				this.myDataGrid1.DataSource=myTb;
				this.GrdSel.Visible=false;
			}
		}

		private void GetCardDataDept(int theSel)
		{
			//变量付初始值
			int nrow,ncol;
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			nrow=this.myDataGrid1.CurrentCell.RowNumber;
			ncol=this.myDataGrid1.CurrentCell.ColumnNumber;

			int nSelRow;
			DataTable mySelTbTemp=(DataTable)this.GrdSel.DataSource;
			nSelRow=theSel;

			//判断选择的有效性
			if(nSelRow<=mySelTbTemp.Rows.Count-1)
			{
				//给网格安全的付值
				myTb.Rows[nrow]["执行科室"]=mySelTbTemp.Rows[nSelRow]["科室名称"];
				myTb.Rows[nrow]["exec_dept"]=mySelTbTemp.Rows[nSelRow]["dept_id"];

				DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
				txtCol.TextBox.Text=mySelTbTemp.Rows[nSelRow]["科室名称"].ToString().Trim();
				this.myDataGrid1.DataSource=myTb;
				this.GrdSel.Visible=false;
			}
			else
			{
				myTb.Rows[nrow]["执行科室"]="";
				DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
				txtCol.TextBox.Text="";
				this.myDataGrid1.DataSource=myTb;
				this.GrdSel.Visible=false;
			}
		}

		private void GetCardDataUsage(int theSel)
		{
			//变量付初始值
			int nrow,ncol;
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			nrow=this.myDataGrid1.CurrentCell.RowNumber;
			ncol=this.myDataGrid1.CurrentCell.ColumnNumber;

			int nSelRow;
			DataTable mySelTbTemp=(DataTable)this.GrdSel.DataSource;
			nSelRow=theSel;

			//判断选择的有效性
			if(nSelRow<=mySelTbTemp.Rows.Count-1)
			{
				//给网格安全的付值
				myTb.Rows[nrow]["用法"]=mySelTbTemp.Rows[nSelRow]["用法"];
				DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
				txtCol.TextBox.Text=mySelTbTemp.Rows[nSelRow]["用法"].ToString().Trim();
				this.myDataGrid1.DataSource=myTb;
				this.GrdSel.Visible=false;
			}
			else
			{
				myTb.Rows[nrow]["用法"]="";
				DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
				txtCol.TextBox.Text="";
				this.myDataGrid1.DataSource=myTb;
				this.GrdSel.Visible=false;
			}
		}


		private void ShowSelCard(string SelData,string Type)
		{
			//首先得到当前网格的信息			
			DataTable myTb=new DataTable();
			int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			int ncol=this.myDataGrid1.CurrentCell.ColumnNumber;
			string sType=(Type.Substring(0,1));

			//查询得到数据 用DATAVIEW 来筛选
			DataView dv=new DataView();
			dv=SelectDataView;
			if (this.isPY==true)
			{
				dv.RowFilter="拼音码 like '"  + SelData + "%' and type='" + sType + "'";
				dv.Sort="拼音码";
			}
			else
			{
				dv.RowFilter="标准码 like  '"  + SelData + "%' and type='" + sType + "'";
				dv.Sort="标准码";
			}			

			//数据绑定			
			this.GrdSel.SetDataBinding(dv,null);
			//this.GrdSel.Refresh();			
			DataGridTableStyle myGridTableStyle = new DataGridTableStyle();
			myGridTableStyle.MappingName = dv.Table.TableName;
			//this.GrdSel.TableStyles.Clear();
			this.GrdSel.TableStyles.Remove(this.GrdSel.TableStyles[0]);
			this.GrdSel.TableStyles.Add(myGridTableStyle);

			//设置网格的位置
			this.GrdSel.Left=this.myDataGrid1.GetCellBounds(nrow,ncol).Left ;
			this.GrdSel.Top=this.myDataGrid1.GetCellBounds(nrow,ncol).Top +this.myDataGrid1.Top+this.myDataGrid1.GetCellBounds(nrow,ncol).Height ;		
			
			this.GrdSel.Width=700;			
			this.GrdSel.TableStyles[0].RowHeaderWidth=10;
			string[] GrdMappingName={"拼音码","内容","单位","单价","剂量","医嘱编号","标准码","备注","type","iscomplex","Exec_Dept","执行科室"};
			int[]    GrdWidth      ={      60,   250,    40,    60,     0,         0,      60,   110,   0,0,0,80};			
			this.myFunc.InitGrd_sub(GrdMappingName,GrdMappingName,GrdWidth,this.GrdSel);					
			/*if (isPY)
			{
				string[] GrdMappingName={"拼音码","内容","单位","单价","剂量","医嘱编号","标准码","type","医嘱内容"};
				int[]    GrdWidth      ={      60,   250,    40,    60,     0,         0,      60,     0,         0};
				this.myFunc.InitGrd_sub(GrdMappingName,GrdMappingName,GrdWidth,this.GrdSel);					
			}
			else
			{
				string[] GrdMappingName={"标准码","内容","单位","单价","拼音码","剂量","医嘱编号","type","医嘱内容"};
				int[]    GrdWidth      ={      60,   250,    40,    60,      60,     0,         0,     0,         0};			
				this.myFunc.InitGrd_sub(GrdMappingName,GrdMappingName,GrdWidth,this.GrdSel);					
			}*/		
			this.GrdSel.CurrentRowIndex=0;
			//this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);
			this.GrdSel.Visible=true;
			this.GrdSel.Refresh();
		}

		private void ShowSelCardOther(string CurrentChar,string ColumnName,int nrow,int ncol)
		{
			//string CurrentChar=SelData.ToUpper()+Convert.ToChar(keyInt).ToString() ;			
			string[] GrdMappingName={"","",""};
			int[]    GrdWidth={0,0,0};
			string sSql="";

			if (ColumnName=="用法")
			{
				if (isPY)
				{
					//sSql="select py_code as 拼音码,name as 用法,id as 数字码 from Base_UsageDiction where py_code like '" + CurrentChar+ "%' order by py_code";
					sSql="select py_code as 拼音码,name as 用法,id as 数字码 from Base_UsageDiction order by py_code";
					string[] GrdMappingName_tmp={"拼音码","用法","数字码"};
					int[]    GrdWidth_tmp      ={      60,   100,      60};
					GrdMappingName_tmp.CopyTo( GrdMappingName,0);
					GrdWidth_tmp.CopyTo(GrdWidth,0); 
				}
				else
				{
					sSql="select id as 数字码,name as 用法,py_code as 拼音码 from Base_UsageDiction order by id";
					string[] GrdMappingName_tmp={"数字码","用法","拼音码"};
					int[]    GrdWidth_tmp      ={      60,   100,      60};
					GrdMappingName_tmp.CopyTo( GrdMappingName,0);
					GrdWidth_tmp.CopyTo(GrdWidth,0);
				}				
			}
			else
			{
				if (isPY)
				{
					sSql="select name as 频率 ,id as 数字码,ExecNum from Base_Frequency order by name";
					string[] GrdMappingName_tmp={"频率" ,"数字码","ExecNum"};
					int[]    GrdWidth_tmp      ={     60,      60,        0};
					GrdMappingName_tmp.CopyTo( GrdMappingName,0);
					GrdWidth_tmp.CopyTo(GrdWidth,0); 						
				}
				else
				{
					sSql="select id as 数字码,name as 频率 ,ExecNum from Base_Frequency order by id";
					string[] GrdMappingName_tmp={"数字码","频率" ,"ExecNum"};
					int[]    GrdWidth_tmp      ={      60,     60,        0};
					GrdMappingName_tmp.CopyTo( GrdMappingName,0);
					GrdWidth_tmp.CopyTo(GrdWidth,0);
				}
			}
						
			//创建临时数据表
			DataTable myTempTb=myQuery.myOpen(sSql);		
			myTempTb.TableName="选择表";						
						
			//数据绑定
			this.GrdSel.DataSource=myTempTb;
			this.GrdSel.Refresh();		
			DataGridTableStyle myGridTableStyle = new DataGridTableStyle();
			myGridTableStyle.MappingName = myTempTb.TableName;
			//this.GrdSel.TableStyles.Clear();
			this.GrdSel.TableStyles.Remove(this.GrdSel.TableStyles[0]);
			this.GrdSel.TableStyles.Add(myGridTableStyle);				
						   
			//设置网格的位置
			this.GrdSel.Left=this.myDataGrid1.GetCellBounds(nrow,ncol).Left ;
			this.GrdSel.Top=this.myDataGrid1.GetCellBounds(nrow,ncol).Top +this.myDataGrid1.Top+this.myDataGrid1.GetCellBounds(nrow,ncol).Height ;

			int i=0,j=0;
			this.GrdSel.Width=0;
			for (i=0;i<=GrdMappingName.Length-1;i++) j+=GrdWidth[i];						
			this.GrdSel.Width=j+70;
			this.myFunc.InitGrd_sub(GrdMappingName,GrdMappingName,GrdWidth,this.GrdSel);
			this.GrdSel.Visible=true;
						
			//选择最接近的记录
			j=CurrentChar.Length;
			while (j>0)
			{
				string sCode=CurrentChar.Substring(0,j);
				for(i=0;i<=myTempTb.Rows.Count-1;i++)
				{	
					if (Convert.ToString(this.GrdSel[i,0]).Trim().Length<j) continue;
					if (Convert.ToString(this.GrdSel[i,0]).Trim().Substring(0,j).ToLower()==sCode.ToLower())
					{
						this.GrdSel.CurrentRowIndex=i;
						//this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);
						j=1;
						break;
					}
				}
				j--;
			}
			this.GrdSel.Refresh();							
		}

 		private bool GrdSel_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
			//变量定义
			long keyInt=Convert.ToInt32(keyData);
			int nrow,ncol;
			string ColumnName="";

			//变量付初始值
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			nrow=this.myDataGrid1.CurrentCell.RowNumber;
			ncol=this.myDataGrid1.CurrentCell.ColumnNumber;
			ColumnName=this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();

			if(keyInt==27)   //ESC
			{
				this.GrdSel.Visible=false;  
				//this.GrdSel.Dispose();
				this.myDataGrid1.Focus();				
			}

			if(ColumnName=="医嘱内容")
			{
				if(keyInt==13)
				{
					GetCardData(this.GrdSel.CurrentCell.RowNumber+48);
					this.myDataGrid1.Select();
					SendKeys.Send("{Tab}");
				}
				//为英文字母
				if((keyInt>=65 && keyInt<=90) || (keyInt>=48 && keyInt<=57) || (keyInt>=96 && keyInt<=105))
				{
					//需要重复的代码
					this.myDataGrid1.Select();
					DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
					txtCol.TextBox.SelectionStart=txtCol.TextBox.TextLength ;
					if(keyInt>=65 && keyInt<=90) SendKeys.Send(keyData.ToString().ToLower());
					else if((keyInt>=48 && keyInt<=57))
						SendKeys.Send(Convert.ToString(keyInt-48));
					else
						SendKeys.Send(Convert.ToString(keyInt-96));

				}
			}

			else if(ColumnName=="用法")
			{
				if(keyInt==13)
				{
					GetCardDataUsage(this.GrdSel.CurrentCell.RowNumber);
					this.myDataGrid1.Select();
					SendKeys.Send("{Tab}");				

				}
				//为英文字母
				if((keyInt>=65 && keyInt<=90) || (keyInt>=48 && keyInt<=57) || (keyInt>=96 && keyInt<=105))
				{
					//需要重复的代码
					this.myDataGrid1.Select();
					DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
					txtCol.TextBox.SelectionStart=txtCol.TextBox.TextLength ;
					if(keyInt>=65 && keyInt<=90) SendKeys.Send(keyData.ToString().ToLower());
					else if((keyInt>=48 && keyInt<=57))
						SendKeys.Send(Convert.ToString(keyInt-48));
					else
						SendKeys.Send(Convert.ToString(keyInt-96));

				}
			}

			else if(ColumnName=="频率")
			{
				if(keyInt==13)
				{
					GetCardDataPL(this.GrdSel.CurrentCell.RowNumber);
					this.myDataGrid1.Select();
					SendKeys.Send("{Tab}");
				}
				//为英文字母
				if((keyInt>=65 && keyInt<=90) || (keyInt>=48 && keyInt<=57) || (keyInt>=96 && keyInt<=105))
				{
					//需要重复的代码
					this.myDataGrid1.Select();
					DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
					txtCol.TextBox.SelectionStart=txtCol.TextBox.TextLength ;
					if(keyInt>=65 && keyInt<=90) SendKeys.Send(keyData.ToString().ToLower());
					else if((keyInt>=48 && keyInt<=57))
						SendKeys.Send(Convert.ToString(keyInt-48));
					else
						SendKeys.Send(Convert.ToString(keyInt-96));

				}
			}

			else if(ColumnName=="执行科室")
			{
				if(keyInt==13)
				{
					GetCardDataDept(this.GrdSel.CurrentCell.RowNumber);
					this.myDataGrid1.Select();
				}
				//为英文字母
				if((keyInt>=65 && keyInt<=90) || (keyInt>=48 && keyInt<=57) || (keyInt>=96 && keyInt<=105))
				{
					//需要重复的代码
					this.myDataGrid1.Select();
					DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
					txtCol.TextBox.SelectionStart=txtCol.TextBox.TextLength ;
					if(keyInt>=65 && keyInt<=90) SendKeys.Send(keyData.ToString().ToLower());
					else if((keyInt>=48 && keyInt<=57))
						SendKeys.Send(Convert.ToString(keyInt-48));
					else
						SendKeys.Send(Convert.ToString(keyInt-96));

				}
			}

			if(keyInt==40 || keyInt==38)return  false;
			return true;
		}

		private void GrdSel_CurrentCellChanged(object sender, System.EventArgs e)
		{
			this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);

			//Add By Tany 2005-05-25
			DataView mySelView=(DataView)this.GrdSel.DataSource;
			int nrow=this.GrdSel.CurrentCell.RowNumber;
			int ncol=this.GrdSel.CurrentCell.ColumnNumber;
			DataGridTextBoxColumn dgtb=(DataGridTextBoxColumn)this.GrdSel.TableStyles[0].GridColumnStyles["执行科室"];
			dgtb.TextBox.Controls.Clear();//清除编辑框中的控件
						
			string ColumnName=this.GrdSel.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();
			if(ColumnName=="执行科室") this.addDeptCmb(mySelView[nrow]["医嘱编号"].ToString());
		}


		//数据是否为空
        private bool DataIsOk(DataTable myTb, DataGridEx myDataGrid)
		{			
			//只有一行，而且医嘱内容为空值，返回错误
			if (myTb.Rows.Count==1 && myTb.Rows[0]["医嘱内容"].ToString().Trim()=="") 
			{
				MessageBox.Show(this, "第1行数据错误！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);						
				myDataGrid.Select(0);					
				return false;
			}

			for(int nrow=0;nrow<=myTb.Rows.Count-1;nrow++)
			{																							
				if(myTb.Rows[nrow]["医嘱内容"].ToString().Trim()=="") continue;				

				/*if	(myTb.Rows[nrow]["嘱号"].ToString().Trim()!="" && myTb.Rows[nrow]["类型"].ToString().Trim()!="" 
					&& myTb.Rows[nrow]["HOItem_ID"].ToString().Trim()!=""  && myTb.Rows[nrow]["医嘱内容"].ToString().Trim()!="" 
					&& myTb.Rows[nrow]["剂量"].ToString().Trim()!=""  && myTb.Rows[nrow]["单位"].ToString().Trim()!="" 
					&& myTb.Rows[nrow]["首次"].ToString().Trim()!=""  && myTb.Rows[nrow]["用法"].ToString().Trim()!="" 
					&& myTb.Rows[nrow]["频率"].ToString().Trim()!=""  && myTb.Rows[nrow]["Exec_Dept"].ToString().Trim()!="" 
					&& myTb.Rows[nrow]["执行科室"].ToString().Trim()!="" && Convert.ToSingle(myTb.Rows[nrow]["剂量"])>=0 
					&& Convert.ToSingle(myTb.Rows[nrow]["首次"])<0
					&& Convert.ToSingle(myTb.Rows[nrow]["首次"]) > Convert.ToSingle(myTb.Rows[nrow]["times_defalut"]) )*/

				if	(myTb.Rows[nrow]["嘱号"].ToString().Trim()!=""         && myTb.Rows[nrow]["类型"].ToString().Trim()!="" 
					&& myTb.Rows[nrow]["HOItem_ID"].ToString().Trim()!=""  && myTb.Rows[nrow]["医嘱内容"].ToString().Trim()!="" 
					&& myTb.Rows[nrow]["剂量"].ToString().Trim()!=""       && myFunc.GetValueF(myTb.Rows[nrow]["剂量"].ToString())>=0 
					&& myTb.Rows[nrow]["单价"].ToString().Trim()!=""       && myFunc.GetValueF(myTb.Rows[nrow]["单价"].ToString())>0 
					&& myTb.Rows[nrow]["执行科室"].ToString().Trim()!=""   && myTb.Rows[nrow]["Exec_Dept"].ToString().Trim()!="" 
					&& (  (this.tabControl1.SelectedTab.Text.Trim()==sTab0
					          && myTb.Rows[nrow]["首次"].ToString().Trim()!=""  && Convert.ToSingle(myTb.Rows[nrow]["首次"])>0				
					          && Convert.ToSingle(myTb.Rows[nrow]["首次"]) <= Convert.ToSingle(myTb.Rows[nrow]["times_defalut"])
					          && myTb.Rows[nrow]["频率"].ToString().Trim()!=""  )
					     ||(this.tabControl1.SelectedTab.Text.Trim()==sTab1)            ) 	)					 

				{
					continue;
				}
				else 
				{
					int j=nrow+1;	
					MessageBox.Show(this, "第 " + j.ToString() + " 行" + "数据错误，请检查！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);						
					myDataGrid.Select(nrow);					
					return false;
				}		
			}
			return true;
		}
		
		//是否保存数据
		private void DataIsSave(object sender)
		{
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;

			if(myTb==null || myTb.Rows.Count==0)
				return;

			if  (myTb.Rows[0]["嘱号"].ToString().Trim()!=""         && myTb.Rows[0]["类型"].ToString().Trim()!="" 
				&& myTb.Rows[0]["HOItem_ID"].ToString().Trim()!=""  && myTb.Rows[0]["医嘱内容"].ToString().Trim()!="" 
				&& myTb.Rows[0]["剂量"].ToString().Trim()!=""       
				&& myTb.Rows[0]["执行科室"].ToString().Trim()!=""   && myTb.Rows[0]["Exec_Dept"].ToString().Trim()!="" )
				//&& (  (this.tabControl1.SelectedTab.Text.Trim()==sTab0
				//&& myTb.Rows[0]["首次"].ToString().Trim()!=""    	&& myTb.Rows[0]["频率"].ToString().Trim()!=""  )
				//||(this.tabControl1.SelectedTab.Text.Trim()==sTab1)))					 

				/*if (   myTb.Rows[0]["嘱号"].ToString().Trim()!="" && myTb.Rows[0]["类型"].ToString().Trim()!="" 
					&& myTb.Rows[0]["HOItem_ID"].ToString().Trim()!=""  && myTb.Rows[0]["医嘱内容"].ToString().Trim()!="" 
					&& myTb.Rows[0]["剂量"].ToString().Trim()!=""  && myTb.Rows[0]["单位"].ToString().Trim()!="" 
					&& myTb.Rows[0]["首次"].ToString().Trim()!=""  && myTb.Rows[0]["用法"].ToString().Trim()!="" 
					&& myTb.Rows[0]["频率"].ToString().Trim()!=""  && myTb.Rows[0]["Exec_Dept"].ToString().Trim()!="" 
					&& myTb.Rows[0]["执行科室"].ToString().Trim()!="" )*/
				//if(myDataGrid.VisibleRowCount>=4)
			{
				if(MessageBox.Show(this, "是否保存医嘱", "保存确认", MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)==DialogResult.Yes )
				{
					this.btSave_Click(sender,new System.EventArgs());
				}
			}
		}


		private void btOpenModel_Click(object sender, System.EventArgs e) 
		{
			//询问用户是否保存已经输入的医嘱
			DataIsSave(sender);

			frmYZModel f1=new frmYZModel();
			f1.MngType=(this.tabControl1.SelectedTab.Text.Trim()==sTab0?2:3); //床位费
			f1.ShowDialog();
			long ModelID=f1.ModelID;
			f1.Dispose();	
			
			if(ModelID==0) return; 

			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
						
			//1、查询数据								
			string sSql="select ntype,hoitem_id,order_context,num,dosage,unit,order_usage,frequency,first_times,exec_dept,b.name as dept_name ,c.dept_id as exec_dept1,c.name as dept_name1," +
				" d.ExecNum "+
				"  from zy_ordermodel_dtl a,base_dept_property b ,base_dept_property c ,Base_Frequency d" + 
				" where a.exec_dept=b.dept_id  and a.id=" + f1.ModelID + 
				" and c.dept_id=" + ClassStatic.Current_DeptID +
			    " and d.name=a.frequency ";
			DataTable tempTb=myQuery.myOpen(sSql);

			//2、给网格付值
			for(int i=0;i<=tempTb.Rows.Count-1;i++)
			{
				//唯一的不同是医嘱号的不同
				myTb.Rows[i]["医嘱内容"]=tempTb.Rows[i]["order_context"];
				myTb.Rows[i]["剂量"]=tempTb.Rows[i]["num"];
				myTb.Rows[i]["单位"]=tempTb.Rows[i]["unit"];

				//类型,剂量,单位，用法，频率，首次
				myTb.Rows[i]["类型"]=GetyzType(Convert.ToInt32(tempTb.Rows[i]["nType"]));
				myTb.Rows[i]["用法"]=tempTb.Rows[i]["order_usage"];
				myTb.Rows[i]["频率"]=tempTb.Rows[i]["frequency"];
				myTb.Rows[i]["首次"]=tempTb.Rows[i]["first_times"];						
				myTb.Rows[i]["HOItem_ID"]=tempTb.Rows[i]["hoitem_id"];
				myTb.Rows[i]["times_defalut"]=tempTb.Rows[i]["ExecNum"];


				//执行科室
				if (Convert.ToString(tempTb.Rows[i]["exec_dept"]).Trim()=="")
				{
					myTb.Rows[i]["执行科室"]=tempTb.Rows[i]["dept_name1"];
					myTb.Rows[i]["Exec_Dept"]=tempTb.Rows[i]["exec_dept1"];
				}
				else
				{
					myTb.Rows[i]["执行科室"]=tempTb.Rows[i]["dept_name"];
					myTb.Rows[i]["Exec_Dept"]=tempTb.Rows[i]["exec_dept"];
				}

				myTb.Rows.Add(myTb.NewRow());
			}
						
			DataTable myTbUseTemp=myTb.Copy();		
			ShowmyDate(true,true,false);
			this.myDataGrid1.DataSource=myTbUseTemp;
			
			this.btCheck_Click(this.myDataGrid1,new System.EventArgs());
		}

		private void btSaveModel_Click(object sender, System.EventArgs e)
		{
			if(ClassStatic.Static_isCZ==false)
			{
				MessageBox.Show("对不起，你没有操作的权限！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			DlgModelNameInput f1=new DlgModelNameInput();
			f1.ShowDialog();
			string ModelName=f1.ModelName;
			long ModelID=f1.ModelID;
			int State=f1.State;
			f1.Dispose();

			if(State==0)
			{
				this.myDataGrid1.Focus();
				return;
			}

			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			string sSql="";			
			int retn=0,i=0;	

			#region 数据正确性判断
			if (DataIsOk(myTb,this.myDataGrid1)==false)	return;

			if (myTb.Rows.Count==1) return;

			string sZH="";					
			for(i=0;i<=myTb.Rows.Count-1;i++)
			{					
				if(myTb.Rows[i]["医嘱内容"].ToString().Trim()!="") 
				{
					sZH=(sZH==""?myTb.Rows[i]["嘱号"].ToString():sZH);
					if (sZH!=myTb.Rows[i]["嘱号"].ToString()) 
					{
						MessageBox.Show(this, "不同嘱号的数据不能保存在一个模板中，保存模板失败！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);
						this.myDataGrid1.Select(i);
						return;
					}
				}
			}
			#endregion	

			#region 保存模板主表ZY_ORDERMODEL
			System.Data.OleDb.OleDbTransaction myTrans=BaseFun.AConnect.BeginTransaction();
			try
			{
				if (State==1) 
				{
					//覆盖模板主表
					sSql="UPDATE ZY_ORDERMODEL set "+
						"OPER_UPDATE=" + ClassStatic.Static_EmployeeID.ToString()+ ","+ 
						"UPDATE_DATE=current timestamp"+ "," + 
						"CANCEL_BIT=0 "+
						"WHERE ID="+ModelID;
					System.Data.OleDb.OleDbCommand mySelCmd=new OleDbCommand();
					mySelCmd.CommandText=sSql;
					mySelCmd.Connection=BaseFun.AConnect;
					mySelCmd.Transaction=myTrans;
					retn= mySelCmd.ExecuteNonQuery();

					//删除模板子表
					if (retn>0)
					{
						sSql="DELETE FROM ZY_ORDERMODEL_DTL WHERE ID="+ModelID;					
						mySelCmd.CommandText=sSql;
						mySelCmd.Connection=BaseFun.AConnect;
						mySelCmd.Transaction=myTrans;
						mySelCmd.ExecuteNonQuery();
					}					
					myTrans.Commit();	
				}
				else
				{
					//新增模板
					sSql="INSERT INTO ZY_ORDERMODEL("+
						"MODEL_NAME,LEVEL,WARD_ID,OPERATOR,BOOK_DATE,OPER_UPDATE,UPDATE_DATE,MNGTYPE,CANCEL_BIT) "+
						"VALUES("+
						"'" + ModelName.Trim() +"',2,'"+ClassStatic.Static_WardID+"',"+
						ClassStatic.Static_EmployeeID.ToString()+",current timestamp," +
						ClassStatic.Static_EmployeeID.ToString()+",current timestamp," +
						Convert.ToString(this.tabControl1.SelectedIndex+2) + ",0)";

					System.Data.OleDb.OleDbCommand mySelCmd=new OleDbCommand();
					mySelCmd.CommandText=sSql;
					mySelCmd.Connection=BaseFun.AConnect;
					mySelCmd.Transaction=myTrans;
					retn= mySelCmd.ExecuteNonQuery();
					myTrans.Commit();

					if (retn>0)
					{
						sSql="select ID from ZY_ORDERMODEL where MODEL_NAME='" + ModelName.Trim() + "' and ward_id='"+ClassStatic.Static_WardID +"'";
						DataTable tempTab=myQuery.myOpen(sSql);
						ModelID=Convert.ToInt16(tempTab.Rows[0]["ID"]);
					}
				}													
			}

			catch(System.Data.OleDb.OleDbException  err)
			{
				myTrans.Rollback();
				MessageBox.Show("保存失败" + " " + err.ToString());
				return;
			}
			catch(Exception err)
			{
				myTrans.Rollback();
				MessageBox.Show("保存失败" + " " + err.ToString());
				return;
			}
			#endregion

			#region 循环保存模板子表ZY_ORDERMODEL_DTL
			System.Data.OleDb.OleDbTransaction myTrans1=BaseFun.AConnect.BeginTransaction();
			try
			{
				for(i=0;i<=myTb.Rows.Count-1;i++)
				{										
					if(myTb.Rows[i]["医嘱内容"].ToString().Trim()!="") 
					{
						//非药品医嘱
						if(char.IsNumber(myTb.Rows[i]["HOItem_ID"].ToString(),0)==true)
						{
							//构成SQL语句,并执行
							int j=1;
							if (myTb.Rows[i]["首次"].ToString()!="")
							{
								j=Convert.ToInt16(myTb.Rows[i]["首次"]);
							}

							sSql="INSERT INTO ZY_ORDERMODEL_DTL(" +
								"ID,GROUP_ID,NTYPE,HOITEM_ID,ORDER_CONTEXT,NUM,UNIT,"+
								"FIRST_TIMES,ORDER_USAGE,FREQUENCY,EXEC_DEPT) "+
								"VALUES(" +
								ModelID.ToString() + "," + myTb.Rows[i]["嘱号"] + "," + myTb.Rows[i]["类型"].ToString().Substring(0,1) + "," +
								myTb.Rows[i]["HOItem_ID"] + ",'" + myTb.Rows[i]["医嘱内容"] + "'," + myTb.Rows[i]["剂量"] + ",'" + myTb.Rows[i]["单位"] + "'," +
								j + ",'" + myTb.Rows[i]["用法"] + "','" + myTb.Rows[i]["频率"] + "'," + myTb.Rows[i]["Exec_Dept"] + ")";							
						}
						else
						{
							/*	//药品医嘱

									//先更新，后插入
									sSqlUpdate="UPDATE ZY_ORDERRECORD_MODEL set MODEL_NAME='" + ModelName.Trim() + "',  nType=" + myTb.Rows[i]["类型"].ToString().Substring(0,1) + ",Order_Doc=" + " "  + ",Item_Code='" + myTb.Rows[i]["HOItem_ID"] + "'," +
										" Order_context='" + myTb.Rows[i]["医嘱内容"] + "',Num=" + myTb.Rows[i]["剂量"] + ",Dosage=" + " "  + ",Unit='" + myTb.Rows[i]["单位"] + "'," +
										" Order_bDate='" + this.DtpbeginDate.Value + "',First_times=" + myTb.Rows[i]["首次"] + ",Order_Usage='" + myTb.Rows[i]["用法"] + "'," +
										" frequency='" + myTb.Rows[i]["频率"] + "',Exec_dept=" + myTb.Rows[i]["Exec_Dept"] + ",Operator=" + ClassStatic.Static_EmployeeID  + "" +
										" WHERE Order_ID=" + myFunc.GetValue(myTb.Rows[i]["ID"].ToString()).ToString();

									//构成SQL语句,并执行
									sSql="INSERT INTO ZY_ORDERRECORD_MODEL(" +
										"MODEL_NAME,Group_ID,Inpatient_ID,Dept_ID,nType,Order_Doc," + 
										"Item_Code,Order_context,Num,Dosage,Unit," +
										"Order_bDate,First_times,Order_Usage,frequency,Exec_dept," +
										"Operator,Delete_Bit)" +
										" VALUES('" + ModelName.Trim() + "'," + myTb.Rows[i]["嘱号"] + "," + BinID.ToString() + ","  + this.DeptID + "," + myTb.Rows[i]["类型"].ToString().Substring(0,1) + "," + " "  + "," +
										"'" + myTb.Rows[i]["HOItem_ID"] + "','" + myTb.Rows[i]["医嘱内容"] + "'," + myTb.Rows[i]["剂量"] + "," +  " "   + ",'" + myTb.Rows[i]["单位"] + "'," +
										"'" + this.DtpbeginDate.Value + "'," + myTb.Rows[i]["首次"] + ",'" + myTb.Rows[i]["用法"] + "','" + myTb.Rows[i]["频率"] + "'," + myTb.Rows[i]["Exec_Dept"] + "," +		
										"" + ClassStatic.Static_EmployeeID.ToString()  + ",0)";
								*/	
						}

						System.Data.OleDb.OleDbCommand mySelCmd=new OleDbCommand();
						mySelCmd.CommandText=sSql;
						mySelCmd.Connection=BaseFun.AConnect;
						mySelCmd.Transaction=myTrans1;
						mySelCmd.ExecuteNonQuery();
					}
				}
				myTrans1.Commit();
				MessageBox.Show(this, "保存模板成功", "OK", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);			
			}
			catch(System.Data.OleDb.OleDbException  err)
			{
				myTrans1.Rollback();
				MessageBox.Show(this, "保存模板失败！（"+err.ToString() +"）", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			catch(Exception err)
			{
				myTrans1.Rollback();
				MessageBox.Show(this, "保存模板失败！（"+err.ToString() +"）", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			#endregion	

			this.myDataGrid1.Focus();
		}


		private void btInsert_Click(object sender, System.EventArgs e)
		{
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			int nrow=this.myDataGrid1.CurrentCell.RowNumber;
			int ncol=this.myDataGrid1.CurrentCell.ColumnNumber;
					
			//先增加一空行
			DataRow row=myTb.NewRow();
			myTb.Rows.Add(myTb.NewRow());

			//循环下移DATATABLE中的数据，与具体某一列无关
			for(int i=myTb.Rows.Count-1;i>nrow;i--)
			{
				for(int j=0;j<=myTb.Columns.Count-1;j++)
				{
					myTb.Rows[i][j]=myTb.Rows[i-1][j];
				}
			}

			for(int j=0;j<=myTb.Columns.Count-1;j++)
			{
				myTb.Rows[nrow][j]=row[j];
			}

			this.myDataGrid1.DataSource=myTb;	
		}
		
		private void btDel_Click(object sender, System.EventArgs e)
		{
			if(ClassStatic.Static_isCZ==false)
			{
				MessageBox.Show("对不起，你没有操作的权限！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			string sSql="";
			string sMsg="";
			string sGroup_id="";
			string sOrder_id="";
			int j=1;

			try
			{
				DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
				if(this.tabControl1.SelectedTab.Text.Trim()==sTab0 || this.tabControl1.SelectedTab.Text.Trim()==sTab1)
				{
					int nrow=this.myDataGrid1.CurrentCell.RowNumber;
					int ncol=this.myDataGrid1.CurrentCell.ColumnNumber;
			
					if(nrow==0) return;
					myTb.Rows[nrow].Delete();
					this.myDataGrid1.DataSource=myTb;		
				}
				else
				{
					if(myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["执行时间"].ToString().Trim() != "")
					{
						MessageBox.Show(this,"账单已经执行，不能删除！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
					sGroup_id=myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["group_id"].ToString().Trim();
					sOrder_id=myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["order_id"].ToString().Trim();
					for(int i=0;i<myTb.Rows.Count;i++)
					{
						if(myTb.Rows[i]["group_id"].ToString().Trim()==sGroup_id)
						{
							sMsg += "("+j.ToString()+") "+myTb.Rows[i]["医嘱内容"].ToString().Trim()+"\n";
							j=j+1;
						}
					}
					//如果只有1条记录则j==2
					if(j > 2)
					{
						if(MessageBox.Show(this,"是否删除该组账单内容？\n该组账单包含：\n"+sMsg,"删除",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
						{
							sSql="update zy_orderrecord set delete_bit=1,order_euser="+Convert.ToDecimal(ClassStatic.Static_EmployeeID)+
								",order_eudate='"+myFunc.Sys_Date()+"' where inpatient_id="+Convert.ToDecimal(ClassStatic.Current_BinID)+
								" and baby_id="+Convert.ToDecimal(ClassStatic.Current_BabyID)+" and group_id="+Convert.ToInt32(sGroup_id)+
								" and mngtype="+GetMNGType();
						}
					}
					if(sSql=="")
					{
						if(MessageBox.Show(this,"是否删除账单 "+myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["医嘱内容"].ToString().Trim()+" ？","删除",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
							return;
						else
							sSql="update zy_orderrecord set delete_bit=1,order_euser="+Convert.ToDecimal(ClassStatic.Static_EmployeeID)+
								",order_eudate='"+myFunc.Sys_Date()+"' where inpatient_id="+Convert.ToDecimal(ClassStatic.Current_BinID)+
								" and baby_id="+Convert.ToDecimal(ClassStatic.Current_BabyID)+" and order_id="+Convert.ToInt32(sOrder_id);
					}

					frmInPassword f1=new frmInPassword();
					f1.ShowDialog();
					if (f1.isLogin==false) return;

					myQuery.ExecuteSql(sSql);
					MessageBox.Show(this,"执行成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);

					//写日志 Add By Tany 2005-01-12
					SystemLog _systemLog=new SystemLog(-1,Convert.ToInt32(ClassStatic.Current_DeptID),Convert.ToInt32(ClassStatic.Static_EmployeeID),"删除账单","删除"+ClassStatic.Current_BinID+" "+ClassStatic.Current_BabyID+"的账单Group_id="+sGroup_id+" Order_id="+sOrder_id,myFunc.Sys_Date(),1,"主机名："+System.Environment.MachineName,5);
					_systemLog.Save(null);
					_systemLog=null;

					ShowOrderDate();
				}
			}
			catch(Exception err)
			{
				//写错误日志 Add By Tany 2005-01-12
				SystemLog _systemErrLog=new SystemLog(-1,Convert.ToInt32(ClassStatic.Current_DeptID),Convert.ToInt32(ClassStatic.Static_EmployeeID),"程序错误","删除账单错误："+err.Message+"  Source："+err.Source,myFunc.Sys_Date(),1,"主机名："+System.Environment.MachineName,5);
				_systemErrLog.Save(null);
				_systemErrLog=null;

				MessageBox.Show("错误："+err.Message+"\n"+"Source："+err.Source,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void btCls_Click(object sender, System.EventArgs e)
		{
			ShowmyDate(true,true,true);
			tabControl1_SelectedIndexChanged(sender, e);
		}

		private void btCheck_Click(object sender, System.EventArgs e)
		{
			//变量定义
			int nrow,ncol,i;               
			long tempYZH=0,minYZH=0;

			//变量付初始值
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			nrow=this.myDataGrid1.CurrentCell.RowNumber;
			ncol=this.myDataGrid1.CurrentCell.ColumnNumber;

			//整理空行
			if(myTb.Rows.Count>0)
			{
				for(i=0;i<=myTb.Rows.Count-2;i++)
				{
					if(myTb.Rows[i]["医嘱内容"].ToString().Trim()=="" && myTb.Rows[i+1]["医嘱内容"].ToString().Trim()=="")
					{
						myTb.Rows[i].Delete();
						i--;
					}
				}
			}

			if(myTb.Rows.Count>2)
			{
				minYZH=Convert.ToInt32(myTb.Rows[0]["嘱号"]);
				tempYZH=minYZH;
				//整理嘱号
				for(i=0;i<=myTb.Rows.Count-1;i++)
				{
					if(myTb.Rows[i]["医嘱内容"].ToString().Trim()!="")
					{
						myTb.Rows[i]["嘱号"]=tempYZH.ToString();
					}
					else
					{
						tempYZH++;
						myTb.Rows[i]["嘱号"]="";
					}
					
				}

				//整理用法，频率，执行科室
				for(i=1;i<=myTb.Rows.Count-1;i++)
				{
					//如果上一行的内容不为空,且本行不为空
					if(myTb.Rows[i-1]["医嘱内容"].ToString().Trim()!="" && myTb.Rows[i]["医嘱内容"].ToString().Trim()!="")
					{
						//则本行的 类型 ,用法，频率，首次,执行科室 与上一行相同
						myTb.Rows[i]["类型"]=myTb.Rows[i-1]["类型"];
						myTb.Rows[i]["用法"]=myTb.Rows[i-1]["用法"];
						myTb.Rows[i]["频率"]=myTb.Rows[i-1]["频率"];
						myTb.Rows[i]["首次"]=myTb.Rows[i-1]["首次"];
					}
				}				
			}

			this.myDataGrid1.DataSource=myTb;		
		}

		private void btSave_Click(object sender, System.EventArgs e)
		{
			if(ClassStatic.Static_isCZ==false)
			{
				MessageBox.Show("对不起，你没有操作的权限！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			int i,serial_no=0,iYZH=0;
			int yztype=(this.tabControl1.SelectedTab.Text.Trim()==sTab0?2:3);
			string sSql="";			
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;

			this.btCheck_Click(this.myDataGrid1,new EventArgs());

			//数据正确性判断
			if (DataIsOk(myTb,this.myDataGrid1)==false) return;

            //初始化医嘱
			sSql=@"select max(Group_Id) as YZH "+
				"  from Zy_OrderRecord " +
				" where inpatient_id=" + ClassStatic.Current_BinID +
				"       and baby_id=" + ClassStatic.Current_BabyID ;//+
//				"       and mngtype=" + yztype.ToString();
			DataTable myTempTb=myQuery.myOpen(sSql);
			if (myTempTb.Rows[0]["YZH"].ToString().Trim()=="") 
			{
				iYZH=0;
			}
			else					
			{
				iYZH=Convert.ToInt32(myTempTb.Rows[0]["YZH"]);
			}

			//选定病人的信息
			//"病区","床号","姓名","介入科室","申请时间","INPATIENT_ID","Baby_ID","DEPT_BR","JR_DEPT","isMY","ward_id","inpatient_no"
			int nSel = myDataGrid2.CurrentRowIndex;
			string sWardId = myDataGrid2[nSel,10].ToString();
			string sDeptBr = myDataGrid2[nSel,7].ToString();
			string sDeptJr = myDataGrid2[nSel,8].ToString();

			System.Data.OleDb.OleDbTransaction myTrans=BaseFun.AConnect.BeginTransaction();
			try
			{

				#region 循环保存数据
				for(i=0;i<=myTb.Rows.Count-1;i++)
				{										
					if(myTb.Rows[i]["医嘱内容"].ToString().Trim()!="") 
					{
						//首次
						int j=1;
						if (myTb.Rows[i]["首次"].ToString()!="")
						{
							j=Convert.ToInt16(myTb.Rows[i]["首次"]);
						}	


						//取医嘱号
						if ( (i==0) ||(i>0 && myTb.Rows[i]["嘱号"].ToString()!=myTb.Rows[i-1]["嘱号"].ToString()))
						{
							iYZH+=1;
							serial_no=0;
						}
						else serial_no+=1;

						decimal v_price=myTb.Rows[i]["单价"].ToString().Trim()==myTb.Rows[i]["oldprice"].ToString().Trim()?0:Convert.ToDecimal(myTb.Rows[i]["单价"].ToString().Trim());

						//构成SQL语句,并执行
						//Modify By Tany 2004-10-23 加入price 主要针对单价为0的项目
						sSql=@"INSERT INTO ZY_ORDERRECORD( " +
							"INPATIENT_ID,Baby_ID,WARD_ID,DEPT_BR,DEPT_ID, "+
							"MNGTYPE,ORDER_BDATE,GROUP_ID,NTYPE, "+
							"HOITEM_ID,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_USAGE,FREQUENCY, "+
							"EXEC_DEPT,FIRST_TIMES,STATUS_FLAG, "+
							"AUDITING_USER,AUDITING_DATE,OPERATOR,BOOK_DATE,SERIAL_NO,price) "+
							"VALUES( " +	
							ClassStatic.Current_BinID + ","  + ClassStatic.Current_BabyID + ",'" + sWardId +"',"+ sDeptBr + "," + sDeptJr + "," +
							Convert.ToString(this.tabControl1.SelectedIndex+2) + ",'" + this.DtpbeginDate.Value + "'," +iYZH.ToString() + "," + myTb.Rows[i]["类型"].ToString().Substring(0,1) + "," +
							myTb.Rows[i]["HOItem_ID"] + ",'" + myTb.Rows[i]["医嘱内容"] + "'," + myTb.Rows[i]["剂量"] +  ",1,'" + myTb.Rows[i]["单位"] + "','" + myTb.Rows[i]["用法"] + "','" + myTb.Rows[i]["频率"] + "'," +
							myTb.Rows[i]["Exec_Dept"] + "," + j + ",2," + 
							ClassStatic.Static_EmployeeID.ToString() +",current timestamp ,"+ ClassStatic.Static_EmployeeID.ToString() + ",current timestamp,"+serial_no.ToString()+
							","+v_price+")";
		  				
						System.Data.OleDb.OleDbCommand mySelCmd=new OleDbCommand();
						mySelCmd.CommandText=sSql;
						mySelCmd.Connection=BaseFun.AConnect;
						mySelCmd.Transaction=myTrans;						
						mySelCmd.ExecuteNonQuery();
						
					}
				}
				#endregion

				myTrans.Commit();
				MessageBox.Show(this, "保存数据成功", "OK", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			catch(System.Data.OleDb.OleDbException  err)
			{
				myTrans.Rollback();				
				MessageBox.Show(this, "保存数据失败！（"+err.ToString() +"）", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			catch(Exception err)
			{
				myTrans.Rollback();
				MessageBox.Show(this, "保存数据失败！（"+err.ToString() +"）", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			BaseFun.CloseConnect();
			btCls_Click(sender,e);
		}
		private void btExit_Click(object sender, System.EventArgs e)
		{
			//询问用户是否保存已经输入的医嘱
			if(this.tabControl1.SelectedTab.Text.Trim()==sTab0 || this.tabControl1.SelectedTab.Text.Trim()==sTab1)
				DataIsSave(sender);
			Close_check=true;
			this.Close();
		}


		private void frmJRYZLR_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.Close_check==false) 
			{
				if(this.tabControl1.SelectedTab.Text.Trim()==sTab0 || this.tabControl1.SelectedTab.Text.Trim()==sTab1)
					DataIsSave(sender);
			}
			this.Close();
		}

		private void ShowOrderDate()
		{
			//2-长期账单  3-临时账单  （MNGTYPE）
			int nType=this.GetMNGType();
			int nKind=this.tabControl1.SelectedTab.Text.Trim().IndexOf("有效",0,this.tabControl1.SelectedTab.Text.Trim().Length)>=0?0:1;
						
			DataTable myTb=new DataTable();
			myTb=myQuery.GetBinOrdrs("",Convert.ToInt32(ClassStatic.Current_BinID),Convert.ToInt32(ClassStatic.Current_BabyID),nType,nKind,0,myFunc.Sys_Date(),"");

			DataColumn col=new DataColumn();
			col.DataType=System.Type.GetType("System.Boolean");			 
			col.AllowDBNull=false;
			col.ColumnName="选";
			col.DefaultValue=false;
			myTb.Columns.Add(col);

			this.myDataGrid1.DataSource=myTb;
			this.myDataGrid1.TableStyles[0].RowHeaderWidth=5;	
			
			CheckGrdData(myTb,nType);	
			this.myDataGrid1.DataSource=myTb;	
						
			//this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();			

			string[] GrdMappingName={ "开嘱医生","开嘱转抄","开嘱核对","停日期","停时间","停嘱医生","停嘱转抄","停嘱核对"};								
			int[]        GrdWidth  ={          8,         8,         8,       6,       6,         8,         8,         8,
										8,         8,         8,       0,       0,         0,         0,         0,
										0,         8,         0,       6,       6,         0,         8,         0,
										0,         8,         0,       0,       0,         0,         0,         0};
			int i=0,j=GrdMappingName.Length;
			for(i=0; i<=j-1; i++)
			{
				this.myDataGrid1.TableStyles[0].GridColumnStyles[GrdMappingName[i]].Width=GrdWidth[j*nType+i]==0?0:(GrdWidth[j*nType+i]*7+2);
			}
			
			// bt取消开医嘱转抄,bt取消停医嘱转抄,bt取消开医嘱核对,bt取消停医嘱核对,bt未执行,bt阴性,bt阳性
			int[] btEnabled={1,1,1,1,0,0,0,
								1,0,1,0,1,1,1,
								0,0,0,0,1,0,0,
								0,0,0,0,0,0,0};

			if (nType>1)
			{
				this.myDataGrid1.TableStyles[0].GridColumnStyles["开嘱转抄"].HeaderText="录入护士";
				this.myDataGrid1.TableStyles[0].GridColumnStyles["停嘱转抄"].HeaderText="停止护士";
			}
			else
			{
				this.myDataGrid1.TableStyles[0].GridColumnStyles["开嘱转抄"].HeaderText="开嘱转抄";
				this.myDataGrid1.TableStyles[0].GridColumnStyles["停嘱转抄"].HeaderText="停嘱转抄";
			}

			this.myDataGrid1.CaptionText=tabControl1.SelectedTab.Text.Trim();
			this.myDataGrid1.Refresh();
		
		}

		private int GetMNGType()
		{
			switch (this.tabControl1.SelectedTab.Text.Trim())
			{
				case "所有长期账单":
					return 2;
				case "所有临时账单":
					return 3;
				default:
					return 2;
			}
		}


		private void CheckGrdData(DataTable myTb,int nType)
		{
			if (myTb.Rows.Count==0) return;

			string sNum="";
			int i=0,iDay=0,iTime=0;                //记录上一个显示日期和时间的行号
			int l=0,group_rows=1;    //同组中的医嘱个数
			this.sPaint="";
			this.sPaintPS="";
			this.sPaintWZX="";			

			#region 算出长度
			max_len0=0;
			max_len1=0;
			max_len2=0;
			for(i=0;i<=myTb.Rows.Count-1;i++)
			{
				sNum=this.GetNumUnit(myTb,i);
				l=System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
				max_len0=max_len0>l?max_len0:l;
				if (sNum.Trim()!="")
				{
					max_len1=max_len1>l?max_len1:l;	
					l=System.Text.Encoding.Default.GetByteCount(sNum);
					max_len2=max_len2>l?max_len2:l;	
				}
			}
			#endregion

			for(i=0;i<=myTb.Rows.Count-1;i++)
			{	
				#region 显示日期时间
				myTb.Rows[i]["开日期"]=myFunc.getDate(myTb.Rows[i]["开日期"].ToString().Trim(),myTb.Rows[i]["day1"].ToString().Trim());
				myTb.Rows[i]["开时间"]=myFunc.getTime(myTb.Rows[i]["开时间"].ToString().Trim(),myTb.Rows[i]["second1"].ToString().Trim());
				myTb.Rows[i]["停日期"]=myFunc.getDate(myTb.Rows[i]["停日期"].ToString().Trim(),myTb.Rows[i]["day2"].ToString().Trim());
				myTb.Rows[i]["停时间"]=myFunc.getTime(myTb.Rows[i]["停时间"].ToString().Trim(),myTb.Rows[i]["second2"].ToString().Trim());
				if (i!=0) 
				{
					if (myTb.Rows[i]["开日期"].ToString().Trim() == myTb.Rows[iDay]["开日期"].ToString().Trim() ) 
					{
						myTb.Rows[i]["开日期"]=System.DBNull.Value;
					}
					else
					{
						iDay=i;
					}			
	
					if (myTb.Rows[i]["开时间"].ToString().Trim() == myTb.Rows[iTime]["开时间"].ToString().Trim() ) 
					{
						myTb.Rows[i]["开时间"]=System.DBNull.Value;
					}
					else
					{
						iTime=i;
					}
				}
				#endregion 
				
				#region 显示医嘱内容

				//“医嘱内容”+= “医嘱内容”+“空格”+“数量单位”
				l=System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
				sNum=this.GetNumUnit(myTb,i);
				if (sNum.Trim()!="") myTb.Rows[i]["医嘱内容"]=myTb.Rows[i]["医嘱内容"].ToString().Trim () +myFunc.Repeat_Space(max_len1-l)+sNum;
				else myTb.Rows[i]["医嘱内容"]=myTb.Rows[i]["医嘱内容"].ToString().Trim () +myFunc.Repeat_Space(max_len0-l)+sNum;

				if  ( (i==myTb.Rows.Count-1) || (i!=myTb.Rows.Count-1 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i+1]["Group_id"].ToString().Trim() ))
				{
					//如果是最后一行或本行和上一行的医嘱号不一致

					//同组中第一条医嘱的“医嘱内容”+=“用法”+“滴量”+ “频率”
					l=System.Text.Encoding.Default.GetByteCount(myTb.Rows[i-group_rows+1]["医嘱内容"].ToString().Trim());
					myTb.Rows[i-group_rows+1]["医嘱内容"]+=myFunc.Repeat_Space(max_len1+max_len2-l+4);					
					if (myTb.Rows[i-group_rows+1]["Order_Usage"].ToString().Trim () !="" ) myTb.Rows[i-group_rows+1]["医嘱内容"]+=" "+myTb.Rows[i-group_rows+1]["Order_Usage"].ToString().Trim ();	
					if (myTb.Rows[i-group_rows+1]["Dropsper"].ToString().Trim () !="" ) myTb.Rows[i-group_rows+1]["医嘱内容"]+=" "+myTb.Rows[i-group_rows+1]["Dropsper"].ToString().Trim ()+"滴/min";	
					if (myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim () !="" && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim () !="1" &&
						( Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 || 
						(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD" ) )
						) myTb.Rows[i-group_rows+1]["医嘱内容"]+=" "+myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim ();																						
					
				
					//如果一组中的医嘱个数大于1
					if (group_rows!=1)
					{
						//[3i2]0 代表第三行是一组医嘱的最后一条，该组医嘱有两条医嘱，status_flag=0
						this.sPaint+="["+i.ToString()+"i"+group_rows.ToString().Trim()+"]"+myTb.Rows[i]["status_flag"].ToString().Trim();  						
					}
					group_rows=1;			
				}
				else
				{
					try
					{
						//如果不是第一行，且本行和下一行的医嘱号一致
						myTb.Rows[i]["开嘱医生"]=System.DBNull.Value;
						myTb.Rows[i]["开嘱转抄"]=System.DBNull.Value;
						myTb.Rows[i]["开嘱核对"]=System.DBNull.Value;
						myTb.Rows[i]["停日期"]=System.DBNull.Value;	
						myTb.Rows[i]["停时间"]=System.DBNull.Value;
						myTb.Rows[i]["停嘱医生"]=System.DBNull.Value;
						myTb.Rows[i]["停嘱转抄"]=System.DBNull.Value;
						myTb.Rows[i]["停嘱核对"]=System.DBNull.Value;						
						if (myTb.Rows[i]["ntype"].ToString() == "1" || myTb.Rows[i]["ntype"].ToString() == "2" || myTb.Rows[i]["ntype"].ToString() == "3") group_rows+=1;
					}
					catch(System.Data.OleDb.OleDbException err)
					{
						MessageBox.Show(err.ToString());
					}
					catch(System.Exception err)
					{
						MessageBox.Show(err.ToString());
					}
				}		
				#endregion

				#region 显示未执行
				if (myTb.Rows[i]["c1"].ToString().Trim().IndexOf("X",0,myTb.Rows[i]["c1"].ToString().Trim().Length)>=0)
				{
					this.sPaintWZX+="i"+i.ToString()+"X";
				}
				#endregion

				#region 显示皮试
				if (myTb.Rows[i]["c1"].ToString().Trim().IndexOf("+",0,myTb.Rows[i]["c1"].ToString().Trim().Length)>=0)
				{
					this.sPaintPS+="["+i.ToString()+"+"+System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim())+"]";
				}
				if (myTb.Rows[i]["c1"].ToString().Trim().IndexOf("-",0,myTb.Rows[i]["c1"].ToString().Trim().Length)>=0)
				{
					this.sPaintPS+="["+i.ToString()+"-"+System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim())+"]"+myTb.Rows[i]["status_flag"].ToString().Trim();
				}
				#endregion
			}								
			this.myDataGrid1.DataSource=myTb;
		}

		//返回“数量+单位”，检查是否显示小数
		private string GetNumUnit(DataTable myTb,int i)
		{		
			string sNum="";
			if (Convert.ToDecimal(myTb.Rows[i]["Num"]) == Convert.ToInt32(myTb.Rows[i]["Num"]))
			{
				sNum=String.Format("{0:F0}",myTb.Rows[i]["Num"]).Trim();
			}
			else 
			{
				sNum=String.Format("{0:F3}",myTb.Rows[i]["Num"]).Trim();
			}
			//Modify By Tany 2004-10-27
			if ((sNum=="1" && myTb.Rows[i]["ntype"].ToString().Trim()!="1" 
				&& myTb.Rows[i]["ntype"].ToString().Trim()!="2" 
				&& myTb.Rows[i]["ntype"].ToString().Trim()!="3"
				&& GetMNGType()!=2
				&& GetMNGType()!=3)
				||sNum=="0"||sNum=="") 
				return "";
			else  
				return ""+sNum+myTb.Rows[i]["Unit"].ToString().Trim ();		
		}

        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
		{
			myDataGrid.TableStyles[0].AllowSorting=false; //不允许排序

			DataGridEnableTextBoxColumn aColumnTextColumn ;
			for(int i=0; i<=GrdMappingName.Length-1; i++)
			{
				if (GrdMappingName[i].ToString().Trim()=="选")
				{
					DataGridEnableBoolColumn myBoolCol=new DataGridEnableBoolColumn(i);
					myBoolCol.CheckCellEnabled  += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);						
					myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol); 
					myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName=GrdMappingName[i].ToString();
					myDataGrid.TableStyles[0].GridColumnStyles[i].Width=GrdWidth[i]==0?0:(GrdWidth[i]*7+2);				
				}
				else
				{
					aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
					aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
					myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
					myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName=GrdMappingName[i].ToString();
					myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText=GrdMappingName[i].ToString().Trim();
					myFunc.InitGrid_Sub(i,GrdMappingName,GrdWidth,Alignment,myDataGrid);
					if (ReadOnly[i]!=0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly=true;	
				}
			}			
		}

		private void SetEnableValues(object sender,DataGridEnableEventArgs e)
		{
			//用色彩区分医嘱的状态 
			int ColorCol=0;		 //状态列
			e.BackColor = Color.White;
			if (Convert.ToInt16(this.myDataGrid1[e.Row,ColorCol]) > 1 &&  Convert.ToInt16(this.myDataGrid1[e.Row,ColorCol]) <5  )   //已审核
			{
				e.ForeColor = Color.Blue;
				//选择列
				if (this.myDataGrid1[e.Row,21].ToString() == "True") e.BackColor=Color.GreenYellow;						
			}
			if (this.myDataGrid1[e.Row,ColorCol].ToString() == "5")   //已停止
			{
				e.ForeColor = Color.Gray;	
				if (this.myDataGrid1[e.Row,21].ToString() == "True") e.BackColor=Color.GreenYellow;		
			}
						
		}

		private void myDataGrid1_Click(object sender, System.EventArgs e)
		{
			if(this.tabControl1.SelectedTab.Text.Trim()==sTab2 || this.tabControl1.SelectedTab.Text.Trim()==sTab3)
			{
				//控制BOOL列
				int nrow,ncol;
				nrow=this.myDataGrid1.CurrentCell.RowNumber;
				ncol=this.myDataGrid1.CurrentCell.ColumnNumber;
			
				//提交网格数据
				if(ncol>0 && nrow>0)this.myDataGrid1.CurrentCell=new DataGridCell(nrow,ncol-1);
				this.myDataGrid1.CurrentCell=new DataGridCell(nrow,ncol);

				DataTable myTb=((DataTable)this.myDataGrid1.DataSource);
				if(myTb == null) return;
				if(myTb.Rows.Count<=0)return;

				//非"选"字段
				if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim()!="选") return;
				if (nrow>myTb.Rows.Count-1) return;

				if (myTb.Rows[nrow]["选"].ToString().Trim()=="1")
				{
					myTb.Rows[nrow]["选"]=false;
					return;
				}
			
				bool isResult=myTb.Rows[nrow]["选"].ToString()=="True"?false:true;
				myTb.Rows[nrow]["选"]=isResult;		

				for(int i=0;i<=myTb.Rows.Count-1;i++)
				{
					if (  myTb.Rows[i]["Group_id"].ToString().Trim()==myTb.Rows[nrow]["Group_id"].ToString().Trim()
						&& myTb.Rows[i]["选"].ToString()!=isResult.ToString() )
					{
						this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);
						myTb.Rows[i]["选"]=isResult;
						//this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
					}
				}

				this.myDataGrid1.DataSource=myTb;
				//this.myDataGrid1.CurrentCell=new DataGridCell(nrow,ncol);	
			}
		}

		private void bt立即执行_Click(object sender, System.EventArgs e)
		{
			if(ClassStatic.Static_isCZ==false)
			{
				MessageBox.Show("对不起，你没有操作的权限！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			frmInPassword f1=new frmInPassword();
			f1.ShowDialog();
			bool isHSZ=f1.isHSZ;
			if (f1.isLogin==false) return;

			//发送
			System.DateTime ExecDate=myFunc.Sys_Date();
			Cursor.Current=new Cursor(ClassStatic.Static_cur); 

			//开始事务
			OleDbCommand myCmd = new OleDbCommand();
			myCmd.Connection=BaseFun.AConnect;
			OleDbTransaction myTrans = BaseFun.AConnect.BeginTransaction();
			myCmd.Transaction=myTrans;

			try
			{
				if(myQuery.GetConfig("cname","医嘱发送时是否使用欠费管理",myCmd)=="是")
				{
					//判断病人的余额
					if(Convert.ToDecimal(patientInfo1.lbYE.Text.Trim()==""?"0":patientInfo1.lbYE.Text.Trim())<myQuery.GetMinExecYE(Convert.ToInt32(ClassStatic.Current_DeptID),myCmd))
					{
						if(isHSZ==false)
						{
							myTrans.Commit();
							MessageBox.Show(patientInfo1.lbBed.Text.Trim()+" 床病人 "+patientInfo1.lbName.Text.Trim()+" 的余额为 "+
								patientInfo1.lbYE.Text.Trim() +" 元，将不能发送该病人医嘱！\n\n如果需要发送，请使用护士长权限登陆！","提示",
								MessageBoxButtons.OK,MessageBoxIcon.Warning);
							return;
						}
					}
				}
				if(this.tabControl1.SelectedTab.Text.Trim()==sTab2)
				{
					//发送长期账单
					myQuery.ExecOrdersWithDate(this.myDataGrid1,2,1,this.progressBar1,Convert.ToInt32(ClassStatic.Current_BinID),Convert.ToInt32(ClassStatic.Current_BabyID),ExecDate,ExecDate,myCmd);
				}
				if(this.tabControl1.SelectedTab.Text.Trim()==sTab3)
				{				
					//发送临时账单
					myQuery.ExecOrdersWithDate(this.myDataGrid1,3,1,this.progressBar1,Convert.ToInt32(ClassStatic.Current_BinID),Convert.ToInt32(ClassStatic.Current_BabyID),ExecDate,ExecDate,myCmd);			
				}

				myTrans.Commit();
			}
			catch(Exception err)
			{
				myTrans.Rollback();

				//写错误日志 Add By Tany 2005-01-12
				SystemLog _systemErrLog=new SystemLog(-1,Convert.ToInt32(ClassStatic.Current_DeptID),Convert.ToInt32(ClassStatic.Static_EmployeeID),"程序错误","执行账单错误："+err.Message+"  Source："+err.Source,myFunc.Sys_Date(),1,"主机名："+System.Environment.MachineName,5);
				_systemErrLog.Save();
				_systemErrLog=null;

				MessageBox.Show("错误："+err.Message+"\n"+"Source："+err.Source+"\n数据已经回滚，请检查后重新执行！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				progressBar1.Value=0;
				ShowOrderDate();
				return;
			}

			Cursor.Current=Cursors.Default;	

			MessageBox.Show("发送成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			ShowOrderDate();
		}

		#region 增加执行科室下拉选择框
		private void addDeptCmb(string orderStr)
		{
			if(orderStr=="")return;
			string sSql="SELECT A.DEPT_ID, B.name "+
				"FROM (SELECT case when (exec_dept IS NULL OR exec_dept = 0) then "+ClassStatic.Current_DeptID+" else exec_dept end dept_id FROM BASE_HOI_DEPT WHERE (order_id ="+orderStr+") "+
				"      UNION "+
				"      SELECT case when (default_dept IS NULL OR default_dept=0) then "+ClassStatic.Current_DeptID+" else default_dept end dept_id FROM base_hoitemdiction WHERE order_id = "+orderStr+") A "+
				"     LEFT OUTER JOIN BASE_DEPT_PROPERTY B ON A.DEPT_ID = B.dept_id";
			DataTable myTb=myQuery.myOpen(sSql);

			if(myTb.Rows.Count<2) return;
			  
			ComboBox cmb=new ComboBox();
			
			cmb.Items.Clear();
			
			cmb.DisplayMember="name";
			cmb.ValueMember="DEPT_ID";
			cmb.DataSource=myTb;

			cmb.DropDownStyle=ComboBoxStyle.DropDownList;
			cmb.Dock=DockStyle.Fill;
			cmb.Cursor=Cursors.Hand;
			cmb.DropDownWidth=90;
			cmb.BackColor=Color.LightCyan;
			cmb.SelectionChangeCommitted+=new EventHandler(cmbDept_SelectionChangeCommitted);
			DataGridTextBoxColumn dgtb=(DataGridTextBoxColumn)this.GrdSel.TableStyles[0].GridColumnStyles["执行科室"];
			dgtb.TextBox.Controls.Clear();//必须先清空
			dgtb.TextBox.Controls.Add(cmb);
		}
		
		private void cmbDept_SelectionChangeCommitted(object sender, EventArgs e)
		{
			DataView mySelView=(DataView)this.GrdSel.DataSource;;
			int nrow=this.GrdSel.CurrentCell.RowNumber;
			int ncol=this.GrdSel.CurrentCell.ColumnNumber;
			this.GrdSel[this.GrdSel.CurrentCell]=((ComboBox)sender).Text.ToString().Trim();
			string dept=((ComboBox)sender).SelectedValue.ToString();
			mySelView[nrow]["Exec_Dept"]=Convert.ToInt32(dept);			
		}
		#endregion

		private void bt刷新_Click(object sender, System.EventArgs e)
		{
			//得到介入病人的有效显示天数
			int nDays = Convert.ToInt32(myQuery.GetConfig("cname","介入申请病人显示有效天数"));

			//查出申请介入治疗的病人信息
			string sSql=@" SELECT c.WARD_NAME AS 病区,b.bed_no as 床号,b.NAME AS 姓名,seekdeptname(jr_dept) 介入科室,apply_date 申请时间,b.INPATIENT_ID,b.Baby_ID,a.DEPT_br,a.jr_dept,b.isMY,c.ward_id,b.inpatient_no as 住院号"+                                 
				"  FROM ZY_vinpatient_bed b inner join ZY_JR_APPLY A on a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id"+ 
				"  inner join base_ward c on a.ward_id=c.ward_id"+        
				"  WHERE a.jr_dept in (select dept_id from base_wardrdept where ward_id='"+ClassStatic.Static_WardID +"')"+
				"  and delete_bit=0 and current timestamp between apply_date and apply_date + "+nDays+" days order by b.WARD_ID,b.bed_no";
			string[] GrdMappingName1={"病区","床号","姓名","介入科室","申请时间","INPATIENT_ID","Baby_ID","DEPT_BR","JR_DEPT","isMY","ward_id","住院号"};
			int[]    GrdWidth1      ={   6,     4,    8,     10,        10,        0,0,0,0,0,0,10};
			int[]    Alignment1     ={   1,     1,     0,    0,         0,        0,0,0,0,0,0,1};
			myFunc.InitGridSQL(sSql,GrdMappingName1,GrdWidth1,Alignment1,this.myDataGrid2);

			/*
			DataTable jrbinTb = (DataTable)myDataGrid2.DataSource;

			if(jrbinTb==null || jrbinTb.Rows.Count==0)
			{
				MessageBox.Show("没有找到介入申请的病人信息！","提示",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				this.Close();
				return;
			}
			*/
		}

		private void txtInpatNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				btnSeek.Focus();

			if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar!=8)
			{
				e.Handled=true;
			}
		}

		private void btnSeek_Click(object sender, System.EventArgs e)
		{
			DataTable myTb = (DataTable)myDataGrid2.DataSource;
			int nRow = -1;

			for(int i=0;i<myTb.Rows.Count;i++)
			{
				if(myTb.Rows[i]["住院号"].ToString().Trim() == txtInpatNo.Text.Trim())
				{
					nRow=i;
					break;
				}
			}

			if(nRow == -1)
			{
				MessageBox.Show("未找到该住院号病人的介入申请信息，请核对后重新定位！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtInpatNo.Focus();
				txtInpatNo.SelectAll();
			}
			else
			{
				for(int i=0;i<myTb.Rows.Count;i++)
				{
					myDataGrid2.UnSelect(i);
				}
				
				myDataGrid2.CurrentRowIndex = nRow;
			}
		}

	}
}
























