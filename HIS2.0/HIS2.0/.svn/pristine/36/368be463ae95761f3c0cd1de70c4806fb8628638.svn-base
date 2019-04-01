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
	/// Form1 的摘要说明。
	/// </summary>
	public class frmYZModel : System.Windows.Forms.Form
	{

		//自定义变量
		private BaseFunc myFunc;
		private bool Close_check=false;
		public int MngType=0;      //窗口输入参数，模板级别 
		public long ModelID=0;     //窗口输出参数，模板ID
		
		private System.Windows.Forms.Panel panel总;
		private System.Windows.Forms.Panel panel左;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.Panel panel右下;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbOper;
		private System.Windows.Forms.Label lbBook_Date;
		private System.Windows.Forms.Label lbUpdate;
		private System.Windows.Forms.Label lbUpdate_Date;
		private System.Windows.Forms.Button btExit;
		private System.Windows.Forms.Button btDel;
		private System.Windows.Forms.Button btOpen;
		private System.Windows.Forms.Button button2;
		private DataGridEx myDataGrid1;
		private DataGridEx myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmYZModel(string _formText)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.Text=_formText;

			myFunc=new BaseFunc();
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
			this.panel总 = new System.Windows.Forms.Panel();
			this.panel右下 = new System.Windows.Forms.Panel();
			this.lbUpdate_Date = new System.Windows.Forms.Label();
			this.lbUpdate = new System.Windows.Forms.Label();
			this.lbBook_Date = new System.Windows.Forms.Label();
			this.lbOper = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btExit = new System.Windows.Forms.Button();
			this.btDel = new System.Windows.Forms.Button();
			this.btOpen = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.myDataGrid2 = new DataGridEx();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel左 = new System.Windows.Forms.Panel();
			this.myDataGrid1 = new DataGridEx();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel总.SuspendLayout();
			this.panel右下.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
			this.panel左.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel总
			// 
			this.panel总.Controls.Add(this.panel1);
			this.panel总.Controls.Add(this.splitter2);
			this.panel总.Controls.Add(this.panel右下);
			this.panel总.Controls.Add(this.splitter1);
			this.panel总.Controls.Add(this.panel左);
			this.panel总.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel总.Location = new System.Drawing.Point(0, 0);
			this.panel总.Name = "panel总";
			this.panel总.Size = new System.Drawing.Size(896, 597);
			this.panel总.TabIndex = 0;
			// 
			// panel右下
			// 
			this.panel右下.Controls.Add(this.lbUpdate_Date);
			this.panel右下.Controls.Add(this.lbUpdate);
			this.panel右下.Controls.Add(this.lbBook_Date);
			this.panel右下.Controls.Add(this.lbOper);
			this.panel右下.Controls.Add(this.label3);
			this.panel右下.Controls.Add(this.label4);
			this.panel右下.Controls.Add(this.label2);
			this.panel右下.Controls.Add(this.label1);
			this.panel右下.Controls.Add(this.btExit);
			this.panel右下.Controls.Add(this.btDel);
			this.panel右下.Controls.Add(this.btOpen);
			this.panel右下.Controls.Add(this.button1);
			this.panel右下.Controls.Add(this.button2);
			this.panel右下.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel右下.Location = new System.Drawing.Point(260, 525);
			this.panel右下.Name = "panel右下";
			this.panel右下.Size = new System.Drawing.Size(636, 72);
			this.panel右下.TabIndex = 4;
			// 
			// lbUpdate_Date
			// 
			this.lbUpdate_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lbUpdate_Date.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lbUpdate_Date.Location = new System.Drawing.Point(272, 43);
			this.lbUpdate_Date.Name = "lbUpdate_Date";
			this.lbUpdate_Date.Size = new System.Drawing.Size(120, 16);
			this.lbUpdate_Date.TabIndex = 52;
			// 
			// lbUpdate
			// 
			this.lbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lbUpdate.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lbUpdate.Location = new System.Drawing.Point(136, 43);
			this.lbUpdate.Name = "lbUpdate";
			this.lbUpdate.Size = new System.Drawing.Size(56, 16);
			this.lbUpdate.TabIndex = 51;
			// 
			// lbBook_Date
			// 
			this.lbBook_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lbBook_Date.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lbBook_Date.Location = new System.Drawing.Point(272, 19);
			this.lbBook_Date.Name = "lbBook_Date";
			this.lbBook_Date.Size = new System.Drawing.Size(120, 16);
			this.lbBook_Date.TabIndex = 50;
			// 
			// lbOper
			// 
			this.lbOper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lbOper.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lbOper.Location = new System.Drawing.Point(136, 19);
			this.lbOper.Name = "lbOper";
			this.lbOper.Size = new System.Drawing.Size(56, 16);
			this.lbOper.TabIndex = 49;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(200, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 48;
			this.label3.Text = "修改时间：";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Location = new System.Drawing.Point(80, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 47;
			this.label4.Text = "修改者：";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(200, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 46;
			this.label2.Text = "创建时间：";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(80, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 45;
			this.label1.Text = "创建者：";
			// 
			// btExit
			// 
			this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btExit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btExit.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btExit.ImageIndex = 7;
			this.btExit.Location = new System.Drawing.Point(560, 27);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(64, 24);
			this.btExit.TabIndex = 44;
			this.btExit.Text = "退出(&E)";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// btDel
			// 
			this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btDel.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btDel.ImageIndex = 7;
			this.btDel.Location = new System.Drawing.Point(488, 27);
			this.btDel.Name = "btDel";
			this.btDel.Size = new System.Drawing.Size(64, 24);
			this.btDel.TabIndex = 43;
			this.btDel.Text = "删除(&D)";
			this.btDel.Click += new System.EventHandler(this.btDelete_Click);
			// 
			// btOpen
			// 
			this.btOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btOpen.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btOpen.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btOpen.ImageIndex = 7;
			this.btOpen.Location = new System.Drawing.Point(416, 27);
			this.btOpen.Name = "btOpen";
			this.btOpen.Size = new System.Drawing.Size(64, 24);
			this.btOpen.TabIndex = 42;
			this.btOpen.Text = "打开(&O)";
			this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Enabled = false;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(64, 11);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(336, 56);
			this.button1.TabIndex = 3;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Enabled = false;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button2.ForeColor = System.Drawing.SystemColors.Desktop;
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.ImageIndex = 7;
			this.button2.Location = new System.Drawing.Point(408, 11);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(224, 56);
			this.button2.TabIndex = 53;
			// 
			// myDataGrid2
			// 
			this.myDataGrid2.AllowSorting = false;
			this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid2.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid2.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid2.CaptionText = "模板内容";
			this.myDataGrid2.DataMember = "";
			this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid2.Name = "myDataGrid2";
			this.myDataGrid2.ReadOnly = true;
			this.myDataGrid2.Size = new System.Drawing.Size(636, 522);
			this.myDataGrid2.TabIndex = 26;
			this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle2});
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "";
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(256, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(4, 597);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel左
			// 
			this.panel左.Controls.Add(this.myDataGrid1);
			this.panel左.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel左.Location = new System.Drawing.Point(0, 0);
			this.panel左.Name = "panel左";
			this.panel左.Size = new System.Drawing.Size(256, 597);
			this.panel左.TabIndex = 0;
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.AllowSorting = false;
			this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid1.CaptionText = "模板列表";
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.ReadOnly = true;
			this.myDataGrid1.Size = new System.Drawing.Size(256, 597);
			this.myDataGrid1.TabIndex = 26;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.MappingName = "";
			this.dataGridTextBoxColumn1.Width = 75;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.MappingName = "";
			this.dataGridTextBoxColumn2.Width = 75;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.MappingName = "";
			this.dataGridTextBoxColumn3.Width = 75;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.MappingName = "";
			this.dataGridTextBoxColumn4.Width = 75;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.MappingName = "";
			this.dataGridTextBoxColumn5.Width = 75;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.MappingName = "";
			this.dataGridTextBoxColumn6.Width = 75;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.MappingName = "";
			this.dataGridTextBoxColumn7.Width = 75;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.MappingName = "";
			this.dataGridTextBoxColumn8.Width = 75;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(260, 522);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(636, 3);
			this.splitter2.TabIndex = 5;
			this.splitter2.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.myDataGrid2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(260, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(636, 522);
			this.panel1.TabIndex = 6;
			// 
			// frmYZModel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(896, 597);
			this.Controls.Add(this.panel总);
			this.Name = "frmYZModel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "医嘱模板管理";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmYZModel_Closing);
			this.Load += new System.EventHandler(this.frmYZModel_Load);
			this.panel总.ResumeLayout(false);
			this.panel右下.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
			this.panel左.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmYZModel_Load(object sender, System.EventArgs e)
		{
			//主表表格初始化

			this.Show_Data1();

			string[] GrdMappingName1={"ID","LEVEL","类型","级别","模板名称","OPER_NAME","BOOK_DATE","UPDATE_NAME","UPDATE_DATE"};
			int[]    GrdWidth1      ={   0,      0,    8,    4,          20,          0,          0,            0,            0};
			int[]    Alignment1     ={   0,      0,    0,    0,           0,          0,          0,            0,            0};
			int[]    ReadOnly1      ={   0,      0,    0,    0,           0,          0,          0,            0,            0};
			myFunc.InitGrid(GrdMappingName1,GrdWidth1,Alignment1,ReadOnly1,this.myDataGrid1);
						
			this.myDataGrid1.CurrentRowIndex=0;			
			this.myDataGrid1_CurrentCellChanged(sender,e);

			//明细表格初始化
			string[] GrdMappingName2={"嘱号","医嘱内容","剂量","单位","用法","频率","首次","执行科室"};
			int[]    GrdWidth2      ={    0,        24,      8,     8,     8,     8,     4,        10};
			int[]    Alignment2     ={    0,         0,      2,     1,     1,     1,     1,         0};
			int[]    ReadOnly2      ={    0,         0,      0,     0,     0,     0,     0,         0};
			this.myFunc.InitGrid(GrdMappingName2,GrdWidth2,Alignment2,ReadOnly2,this.myDataGrid2);
			
			if (this.MngType==0) this.btOpen.Enabled=false; 
		}
		

		private void Show_Data1()
		{
			string sSql="SELECT ID,LEVEL," +
				" CASE MNGTYPE WHEN 0 THEN '长期医嘱' WHEN 1 THEN '临时医嘱' WHEN 5 THEN '临时医嘱' WHEN 2 THEN '长期账单' WHEN 3 THEN '临时账单' END AS 类型," +
				" CASE LEVEL WHEN 0 THEN '医院' WHEN 2 THEN '病区' END AS 级别, "+
				" MODEL_NAME 模板名称 ,B.NAME AS OPER_NAME,BOOK_DATE,C.NAME AS UPDATE_NAME,UPDATE_DATE"+
				"  FROM ZY_OrderModel A LEFT JOIN jc_EMPLOYEE_PROPERTY B ON A.OPERATOR=B.EMPLOYEE_ID " +
				"                       LEFT JOIN jc_EMPLOYEE_PROPERTY C ON A.OPER_UPDATE=C.EMPLOYEE_ID " +
				" WHERE (LEVEL=0 OR (LEVEL=2 AND WARD_ID='"+InstanceForm.BCurrentDept.WardId + " ') ) AND CANCEL_BIT=0";
            //if (this.MngType!=0)
            //{
            //    sSql+=" and MNGTYPE=" + this.MngType;  //从医嘱录入窗体打开模板时，需要限制只能打开与当前医嘱级别相同的模板
            //}
			sSql+=" ORDER BY MNGTYPE,LEVEL,ID";   //只能打开医院或病区级别的模板
			this.myFunc.ShowGrid(0,sSql,this.myDataGrid1);		
		}

		private void Show_Data2()
		{
			string sSql="select group_id as 嘱号,order_context as 医嘱内容,num as 剂量,unit as 单位,order_usage as 用法,frequency as 频率, first_times as 首次, b.name as 执行科室 "+
				"  from zy_ordermodel_dtl a left join jc_dept_property b on a.exec_dept=b.dept_id   "+
				" where id=" + this.ModelID.ToString() ;			
			this.myFunc.ShowGrid(0,sSql,this.myDataGrid2);						
		}

		
		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			int nrow=this.myFunc.SelRow(this.myDataGrid1);
			if (nrow==-1) 
			{
				this.lbOper.Text="";
				this.lbBook_Date.Text="";
				this.lbUpdate.Text="";
				this.lbUpdate_Date.Text="";
				return;			
			}

			this.ModelID=Convert.ToInt32(this.myDataGrid1[nrow,0]);
			this.lbOper.Text=this.myDataGrid1[nrow,5].ToString();
			this.lbBook_Date.Text=this.myDataGrid1[nrow,6].ToString();
			this.lbUpdate.Text=this.myDataGrid1[nrow,7].ToString();
			this.lbUpdate_Date.Text=this.myDataGrid1[nrow,8].ToString();
			this.Show_Data2();
	
		}


		private void btOpen_Click(object sender, System.EventArgs e)
		{
			this.Close_check=true;
			this.Close();
		}

		private void btDelete_Click(object sender, System.EventArgs e)
		{
			//权限控制	
			
			if (this.ModelID==0) return;

			if (MessageBox.Show(this, "是否确认删除该组模板", "确认删除", MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)==DialogResult.Yes)
			{
				//删除
				string sSql=@"update zy_ordermodel"+
					"   set cancel_bit=1,"+					
					"       oper_update="+InstanceForm.BCurrentUser.EmployeeId+","+
					"       update_date=getdate()" +
					" where id=" + this.ModelID.ToString();
				InstanceForm.BDatabase.DoCommand(sSql);

				this.Show_Data1();
				this.myDataGrid1.CurrentRowIndex=0;			
				this.myDataGrid1_CurrentCellChanged(sender,e);			
			}
			this.myDataGrid1.Focus();									
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.ModelID=0;
			this.Close_check=true;
			this.Close();		
		}

		private void frmYZModel_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{		
//			if (this.Close_check==false) this.ModelID=0;
//			this.Close();		
		}




	}
}
