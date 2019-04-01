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

namespace ts_zyhs_jsytl
{
	/// <summary>
	/// Form2 的摘要说明。
	/// </summary>
	public class frmJSYTL : System.Windows.Forms.Form
	{
		//自定义变量
		private BaseFunc myFunc;
		private double total=0;
		private DataTable JSYTb  = new DataTable();

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private DataGridEx myDataGrid2;
		private DataGridEx myDataGrid3;
		private System.Windows.Forms.Button bt刷新统计表;
		private System.Windows.Forms.Button bt刷新明细表;
		private System.Windows.Forms.Button bt退出;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.Button bt反选;
		private System.Windows.Forms.Button bt全选;
		private System.Windows.Forms.Button bt发送统计表;
		private System.Windows.Forms.ProgressBar progressBar1;
		private TheReportDateSet rds = new TheReportDateSet();
		private DataRow dr;
		private System.Windows.Forms.RadioButton rb选定病人;
		private System.Windows.Forms.RadioButton rb所有病人;
		private System.Windows.Forms.RadioButton rb选定药品;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdoAll;
		private System.Windows.Forms.RadioButton rdoNormal;
		private System.Windows.Forms.RadioButton rdoQY;
		private System.Windows.Forms.RadioButton rdoQuick;
		private System.Windows.Forms.TextBox txtPy;
		private System.Windows.Forms.ComboBox cmbYP;
		private System.Windows.Forms.RadioButton rdoZJ;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel7;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmJSYTL(string _formText)
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.rb选定药品 = new System.Windows.Forms.RadioButton();
			this.rb选定病人 = new System.Windows.Forms.RadioButton();
			this.rb所有病人 = new System.Windows.Forms.RadioButton();
			this.bt反选 = new System.Windows.Forms.Button();
			this.bt全选 = new System.Windows.Forms.Button();
			this.myDataGrid3 = new DataGridEx();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.panel5 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdoZJ = new System.Windows.Forms.RadioButton();
			this.txtPy = new System.Windows.Forms.TextBox();
			this.rdoQY = new System.Windows.Forms.RadioButton();
			this.rdoNormal = new System.Windows.Forms.RadioButton();
			this.rdoAll = new System.Windows.Forms.RadioButton();
			this.cmbYP = new System.Windows.Forms.ComboBox();
			this.rdoQuick = new System.Windows.Forms.RadioButton();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.bt发送统计表 = new System.Windows.Forms.Button();
			this.bt刷新统计表 = new System.Windows.Forms.Button();
			this.bt刷新明细表 = new System.Windows.Forms.Button();
			this.bt退出 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.myDataGrid2 = new DataGridEx();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).BeginInit();
			this.panel5.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel7);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1024, 645);
			this.panel1.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel6);
			this.panel3.Controls.Add(this.panel5);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(556, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(468, 645);
			this.panel3.TabIndex = 2;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.panel4);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(468, 508);
			this.panel6.TabIndex = 2;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.rb选定药品);
			this.panel4.Controls.Add(this.rb选定病人);
			this.panel4.Controls.Add(this.rb所有病人);
			this.panel4.Controls.Add(this.bt反选);
			this.panel4.Controls.Add(this.bt全选);
			this.panel4.Controls.Add(this.myDataGrid3);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(468, 508);
			this.panel4.TabIndex = 0;
			// 
			// rb选定药品
			// 
			this.rb选定药品.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rb选定药品.BackColor = System.Drawing.Color.PaleTurquoise;
			this.rb选定药品.Location = new System.Drawing.Point(98, 3);
			this.rb选定药品.Name = "rb选定药品";
			this.rb选定药品.Size = new System.Drawing.Size(72, 18);
			this.rb选定药品.TabIndex = 87;
			this.rb选定药品.Text = "选定药品";
			// 
			// rb选定病人
			// 
			this.rb选定病人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rb选定病人.BackColor = System.Drawing.Color.PaleTurquoise;
			this.rb选定病人.Location = new System.Drawing.Point(174, 3);
			this.rb选定病人.Name = "rb选定病人";
			this.rb选定病人.Size = new System.Drawing.Size(72, 18);
			this.rb选定病人.TabIndex = 85;
			this.rb选定病人.Text = "选定病人";
			// 
			// rb所有病人
			// 
			this.rb所有病人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rb所有病人.BackColor = System.Drawing.Color.PaleTurquoise;
			this.rb所有病人.Checked = true;
			this.rb所有病人.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rb所有病人.Location = new System.Drawing.Point(250, 3);
			this.rb所有病人.Name = "rb所有病人";
			this.rb所有病人.Size = new System.Drawing.Size(72, 18);
			this.rb所有病人.TabIndex = 86;
			this.rb所有病人.TabStop = true;
			this.rb所有病人.Text = "所有病人";
			this.rb所有病人.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// bt反选
			// 
			this.bt反选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt反选.BackColor = System.Drawing.Color.PaleGreen;
			this.bt反选.Location = new System.Drawing.Point(396, 1);
			this.bt反选.Name = "bt反选";
			this.bt反选.Size = new System.Drawing.Size(56, 20);
			this.bt反选.TabIndex = 81;
			this.bt反选.Text = "反选(&F)";
			this.bt反选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bt反选.Click += new System.EventHandler(this.bt反选_Click);
			// 
			// bt全选
			// 
			this.bt全选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt全选.BackColor = System.Drawing.Color.PaleGreen;
			this.bt全选.Location = new System.Drawing.Point(330, 1);
			this.bt全选.Name = "bt全选";
			this.bt全选.Size = new System.Drawing.Size(56, 20);
			this.bt全选.TabIndex = 80;
			this.bt全选.Text = "全选(&A)";
			this.bt全选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bt全选.Click += new System.EventHandler(this.bt全选_Click);
			// 
			// myDataGrid3
			// 
			this.myDataGrid3.AllowSorting = false;
			this.myDataGrid3.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid3.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid3.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid3.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid3.CaptionText = "明细表";
			this.myDataGrid3.DataMember = "";
			this.myDataGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid3.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid3.Name = "myDataGrid3";
			this.myDataGrid3.ReadOnly = true;
			this.myDataGrid3.Size = new System.Drawing.Size(468, 508);
			this.myDataGrid3.TabIndex = 4;
			this.myDataGrid3.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle2});
			this.myDataGrid3.Click += new System.EventHandler(this.myDataGrid3_Click);
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.AllowSorting = false;
			this.dataGridTableStyle2.DataGrid = this.myDataGrid3;
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.groupBox1);
			this.panel5.Controls.Add(this.progressBar1);
			this.panel5.Controls.Add(this.bt发送统计表);
			this.panel5.Controls.Add(this.bt刷新统计表);
			this.panel5.Controls.Add(this.bt刷新明细表);
			this.panel5.Controls.Add(this.bt退出);
			this.panel5.Controls.Add(this.button4);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel5.Location = new System.Drawing.Point(0, 508);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(468, 137);
			this.panel5.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.rdoZJ);
			this.groupBox1.Controls.Add(this.txtPy);
			this.groupBox1.Controls.Add(this.rdoQY);
			this.groupBox1.Controls.Add(this.rdoNormal);
			this.groupBox1.Controls.Add(this.rdoAll);
			this.groupBox1.Controls.Add(this.cmbYP);
			this.groupBox1.Controls.Add(this.rdoQuick);
			this.groupBox1.Location = new System.Drawing.Point(2, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 64);
			this.groupBox1.TabIndex = 55;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "类型";
			// 
			// rdoZJ
			// 
			this.rdoZJ.Location = new System.Drawing.Point(8, 40);
			this.rdoZJ.Name = "rdoZJ";
			this.rdoZJ.Size = new System.Drawing.Size(64, 16);
			this.rdoZJ.TabIndex = 6;
			this.rdoZJ.Text = "小针剂";
			this.rdoZJ.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rdoZJ.Click += new System.EventHandler(this.bt刷新明细表_Click);
			// 
			// txtPy
			// 
			this.txtPy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPy.Location = new System.Drawing.Point(184, 16);
			this.txtPy.Name = "txtPy";
			this.txtPy.Size = new System.Drawing.Size(272, 21);
			this.txtPy.TabIndex = 4;
			this.txtPy.Text = "";
			this.txtPy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPy_KeyPress);
			this.txtPy.TextChanged += new System.EventHandler(this.txtPy_TextChanged);
			// 
			// rdoQY
			// 
			this.rdoQY.Location = new System.Drawing.Point(72, 40);
			this.rdoQY.Name = "rdoQY";
			this.rdoQY.Size = new System.Drawing.Size(48, 16);
			this.rdoQY.TabIndex = 2;
			this.rdoQY.Text = "缺药";
			this.rdoQY.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rdoQY.Click += new System.EventHandler(this.bt刷新明细表_Click);
			// 
			// rdoNormal
			// 
			this.rdoNormal.Location = new System.Drawing.Point(8, 19);
			this.rdoNormal.Name = "rdoNormal";
			this.rdoNormal.Size = new System.Drawing.Size(64, 16);
			this.rdoNormal.TabIndex = 1;
			this.rdoNormal.Text = "口服药";
			this.rdoNormal.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rdoNormal.Click += new System.EventHandler(this.bt刷新明细表_Click);
			// 
			// rdoAll
			// 
			this.rdoAll.Location = new System.Drawing.Point(120, 40);
			this.rdoAll.Name = "rdoAll";
			this.rdoAll.Size = new System.Drawing.Size(48, 16);
			this.rdoAll.TabIndex = 0;
			this.rdoAll.Text = "全部";
			this.rdoAll.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rdoAll.Visible = false;
			this.rdoAll.Click += new System.EventHandler(this.bt刷新明细表_Click);
			// 
			// cmbYP
			// 
			this.cmbYP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbYP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbYP.Location = new System.Drawing.Point(184, 40);
			this.cmbYP.Name = "cmbYP";
			this.cmbYP.Size = new System.Drawing.Size(272, 20);
			this.cmbYP.TabIndex = 5;
			// 
			// rdoQuick
			// 
			this.rdoQuick.Checked = true;
			this.rdoQuick.Location = new System.Drawing.Point(72, 19);
			this.rdoQuick.Name = "rdoQuick";
			this.rdoQuick.Size = new System.Drawing.Size(128, 16);
			this.rdoQuick.TabIndex = 3;
			this.rdoQuick.TabStop = true;
			this.rdoQuick.Text = "选择药品拼音码：";
			this.rdoQuick.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rdoQuick.Click += new System.EventHandler(this.rdoQuick_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(2, 0);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(464, 10);
			this.progressBar1.TabIndex = 54;
			// 
			// bt发送统计表
			// 
			this.bt发送统计表.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bt发送统计表.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt发送统计表.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.bt发送统计表.ForeColor = System.Drawing.SystemColors.Desktop;
			this.bt发送统计表.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bt发送统计表.ImageIndex = 4;
			this.bt发送统计表.Location = new System.Drawing.Point(266, 90);
			this.bt发送统计表.Name = "bt发送统计表";
			this.bt发送统计表.Size = new System.Drawing.Size(96, 40);
			this.bt发送统计表.TabIndex = 53;
			this.bt发送统计表.Text = "发送(&S)";
			this.bt发送统计表.Click += new System.EventHandler(this.bt发送统计表_Click);
			// 
			// bt刷新统计表
			// 
			this.bt刷新统计表.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bt刷新统计表.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt刷新统计表.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.bt刷新统计表.ForeColor = System.Drawing.SystemColors.Desktop;
			this.bt刷新统计表.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bt刷新统计表.ImageIndex = 4;
			this.bt刷新统计表.Location = new System.Drawing.Point(138, 90);
			this.bt刷新统计表.Name = "bt刷新统计表";
			this.bt刷新统计表.Size = new System.Drawing.Size(120, 40);
			this.bt刷新统计表.TabIndex = 52;
			this.bt刷新统计表.Text = "刷新统计表(&T)";
			this.bt刷新统计表.Click += new System.EventHandler(this.bt刷新统计表_Click);
			// 
			// bt刷新明细表
			// 
			this.bt刷新明细表.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bt刷新明细表.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt刷新明细表.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.bt刷新明细表.ForeColor = System.Drawing.SystemColors.Desktop;
			this.bt刷新明细表.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bt刷新明细表.ImageIndex = 4;
			this.bt刷新明细表.Location = new System.Drawing.Point(10, 90);
			this.bt刷新明细表.Name = "bt刷新明细表";
			this.bt刷新明细表.Size = new System.Drawing.Size(120, 40);
			this.bt刷新明细表.TabIndex = 51;
			this.bt刷新明细表.Text = "刷新明细表(&M)";
			this.bt刷新明细表.Click += new System.EventHandler(this.bt刷新明细表_Click);
			// 
			// bt退出
			// 
			this.bt退出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bt退出.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bt退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt退出.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.bt退出.ForeColor = System.Drawing.SystemColors.Desktop;
			this.bt退出.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bt退出.ImageIndex = 4;
			this.bt退出.Location = new System.Drawing.Point(370, 90);
			this.bt退出.Name = "bt退出";
			this.bt退出.Size = new System.Drawing.Size(88, 40);
			this.bt退出.TabIndex = 50;
			this.bt退出.Text = "退出(&E)";
			this.bt退出.Click += new System.EventHandler(this.bt退出_Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Enabled = false;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
			this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button4.ImageIndex = 4;
			this.button4.Location = new System.Drawing.Point(2, 81);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(464, 56);
			this.button4.TabIndex = 49;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.myDataGrid2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(553, 645);
			this.panel2.TabIndex = 0;
			// 
			// myDataGrid2
			// 
			this.myDataGrid2.AllowSorting = false;
			this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid2.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid2.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid2.CaptionText = "统计表";
			this.myDataGrid2.DataMember = "";
			this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid2.Name = "myDataGrid2";
			this.myDataGrid2.ReadOnly = true;
			this.myDataGrid2.Size = new System.Drawing.Size(553, 645);
			this.myDataGrid2.TabIndex = 4;
			this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AllowSorting = false;
			this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(553, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 645);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.panel2);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(553, 645);
			this.panel7.TabIndex = 4;
			// 
			// frmJSYTL
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(1024, 645);
			this.Controls.Add(this.panel1);
			this.Name = "frmJSYTL";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "病区基数药品统计";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmJSYTJ_Load);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).EndInit();
			this.panel5.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
			this.panel7.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmJSYTJ_Load(object sender, System.EventArgs e)
		{
			string[] GrdMappingName2={"编号","名称","规格","数量","单位","单价","金额"};
			int[]    GrdWidth2      ={8,24,11,6,6,8,10};
			int[]    Alignment2     ={0,0,0,2,1,2,2,1};
			int[]	 ReadOnly2      ={0,0,0,0,0,0,0,0};			
			myFunc.InitGrid(GrdMappingName2,GrdWidth2,Alignment2,ReadOnly2,this.myDataGrid2);

			string[] GrdMappingName3={"选","编号","名称","数量","单位","住院号","姓名","规格","单价","金额","床号","ID"};
			int[]    GrdWidth3      ={2,8,20,6,4, 9,8,0,0,0,4,0};
			int[]    Alignment3     ={0,0,0, 2,1, 0, 0,0,0,0,1,0};
			int[]	 ReadOnly3      ={0,0,0, 0,0, 0, 0,0,0,0,0,0};
			myFunc.InitGrid(GrdMappingName3,GrdWidth3,Alignment3,ReadOnly3,this.myDataGrid3);

			Cursor.Current=PubStaticFun.WaitCursor();

			LoadJSY();

			txtPy.Focus();

			Cursor.Current=Cursors.Default;

//			this.bt刷新明细表_Click(sender,e);
		}

		private void myDataGrid3_Click(object sender, System.EventArgs e)
		{
			//控制BOOL列
			int nrow,ncol;
			nrow=this.myDataGrid3.CurrentCell.RowNumber;
			ncol=this.myDataGrid3.CurrentCell.ColumnNumber;
			
			//提交网格数据
			if(ncol>0 && nrow>0)this.myDataGrid3.CurrentCell=new DataGridCell(nrow,ncol-1);
			this.myDataGrid3.CurrentCell=new DataGridCell(nrow,ncol);

			DataTable myTb=((DataTable)this.myDataGrid3.DataSource);
			if(myTb == null) return;
			if(myTb.Rows.Count<=0)return;

			//非"选"字段
			if (this.myDataGrid3.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim()!="选") return;
			if (nrow>myTb.Rows.Count-1) return;

		
			bool isResult=myTb.Rows[nrow]["选"].ToString()=="True"?false:true;
			myTb.Rows[nrow]["选"]=isResult;		

			this.myDataGrid3.DataSource=myTb;	

		}

		#region 废代码
		/*
		private void bt全选_Click(object sender, System.EventArgs e)
		{
			DataTable myTb=((DataTable)this.myDataGrid3.DataSource);
			if(myTb == null) return;
			if(myTb.Rows.Count<=0)return;

			for(int i=0;i<=myTb.Rows.Count-1;i++)
			{
				if (myTb.Rows[i]["选"].ToString().Trim()=="1") continue;
				this.myDataGrid3.CurrentCell=new DataGridCell(i,0);
				myTb.Rows[i]["选"]=true;			
			}			
			this.myDataGrid3.DataSource=myTb;	
		}

		private void bt反选_Click(object sender, System.EventArgs e)
		{
			DataTable myTb=((DataTable)this.myDataGrid3.DataSource);
			if(myTb == null) return;
			if(myTb.Rows.Count<=0)return;

			for(int i=0;i<=myTb.Rows.Count-1;i++)
			{
				if (myTb.Rows[i]["选"].ToString().Trim()=="1") continue;
				this.myDataGrid3.CurrentCell=new DataGridCell(i,0);
				myTb.Rows[i]["选"]=myTb.Rows[i]["选"].ToString()=="True"?false:true;			
			}			
			this.myDataGrid3.DataSource=myTb;	
		}
		*/
		#endregion
		private void bt全选_Click(object sender, System.EventArgs e)
		{
			DataTable myTb=((DataTable)this.myDataGrid3.DataSource);
			if(myTb == null) return;
			if(myTb.Rows.Count<=0)return;
			int nrow=0,j=0;	
			bool isTrue=false;
			DataGridCell myCel = myDataGrid3.CurrentCell;

			for(int i=0;i<=myTb.Rows.Count-1;i++)
			{
				if (this.rb所有病人.Checked)
				{
					this.myDataGrid3.CurrentCell=new DataGridCell(i,0);
					myTb.Rows[i]["选"]=true;			
				}
				else if(this.rb选定病人.Checked)
				{
					if ( i==0 
						|| ( i!=0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim()==myTb.Rows[i-1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim()!=myTb.Rows[i-1]["Baby_ID"].ToString().Trim() )
						|| ( i!=0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim()!=myTb.Rows[i-1]["Inpatient_ID"].ToString().Trim() ) )
					{
						nrow=i;	 //新病人的行号	
						isTrue=false;
						for (j=i;j<=myTb.Rows.Count-1;j++)
						{
							if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim()==myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim()==myTb.Rows[nrow]["Baby_ID"].ToString().Trim() )
							{
								if (myTb.Rows[j]["选"].ToString()=="True" )
								{
									isTrue=true;
									break;
								}
							}
							else break;							
						}
					}
					
					if (myTb.Rows[i]["Inpatient_ID"].ToString().Trim()==myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim()==myTb.Rows[nrow]["Baby_ID"].ToString().Trim() )
					{
						this.myDataGrid3.CurrentCell=new DataGridCell(i,0);
						myTb.Rows[i]["选"]=isTrue;			
					}
					else  isTrue=false;  
				}
				else //选定药品
				{
					if ( i==0 
						|| ( i!=0 && myTb.Rows[i]["编号"].ToString().Trim()!=myTb.Rows[i-1]["编号"].ToString().Trim()))
					{
						nrow=i;	 //新病人的行号	
						isTrue=false;
						for (j=i;j<=myTb.Rows.Count-1;j++)
						{
							if (myTb.Rows[j]["编号"].ToString().Trim()==myTb.Rows[nrow]["编号"].ToString().Trim())
							{
								if (myTb.Rows[j]["选"].ToString()=="True" )
								{
									isTrue=true;
									break;
								}
							}
							else break;							
						}
					}
					
					if (myTb.Rows[i]["编号"].ToString().Trim()==myTb.Rows[nrow]["编号"].ToString().Trim())
					{
						this.myDataGrid3.CurrentCell=new DataGridCell(i,0);
						myTb.Rows[i]["选"]=isTrue;			
					}
					else  isTrue=false;
				}
			}			
			this.myDataGrid3.DataSource=myTb;	
			this.myDataGrid3.CurrentCell=myCel;	
		}

		private void bt反选_Click(object sender, System.EventArgs e)
		{
			DataTable myTb=((DataTable)this.myDataGrid3.DataSource);
			if(myTb == null) return;
			if(myTb.Rows.Count<=0)return;
			int nrow=0,j=0;	
			bool isTrue=false;
			DataGridCell myCel = myDataGrid3.CurrentCell;

			for(int i=0;i<=myTb.Rows.Count-1;i++)
			{
				if (this.rb所有病人.Checked)
				{
					this.myDataGrid3.CurrentCell=new DataGridCell(i,0);
					myTb.Rows[i]["选"]=myTb.Rows[i]["选"].ToString()=="True"?false:true;			
				}
				else if(this.rb选定病人.Checked)
				{
					if ( i==0 
						|| ( i!=0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim()==myTb.Rows[i-1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim()!=myTb.Rows[i-1]["Baby_ID"].ToString().Trim() )
						|| ( i!=0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim()!=myTb.Rows[i-1]["Inpatient_ID"].ToString().Trim() ) )
					{
						nrow=i;	 //新病人的行号	
						isTrue=false;
						for (j=i;j<=myTb.Rows.Count-1;j++)
						{
							if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim()==myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim()==myTb.Rows[nrow]["Baby_ID"].ToString().Trim() )
							{
								if (myTb.Rows[j]["选"].ToString()=="True" )
								{
									isTrue=true;
									break;
								}
							}
							else break;							
						}
					}

					if (isTrue && myTb.Rows[i]["Inpatient_ID"].ToString().Trim()==myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim()==myTb.Rows[nrow]["Baby_ID"].ToString().Trim() )
					{
						this.myDataGrid3.CurrentCell=new DataGridCell(i,0);
						myTb.Rows[i]["选"]=myTb.Rows[i]["选"].ToString()=="True"?false:true;		
					}
				}
				else
				{
					if ( i==0 
						|| ( i!=0 && myTb.Rows[i]["编号"].ToString().Trim()!=myTb.Rows[i-1]["编号"].ToString().Trim() ) )
					{
						nrow=i;	 //新病人的行号	
						isTrue=false;
						for (j=i;j<=myTb.Rows.Count-1;j++)
						{
							if (myTb.Rows[j]["编号"].ToString().Trim()==myTb.Rows[nrow]["编号"].ToString().Trim()  )
							{
								if (myTb.Rows[j]["选"].ToString()=="True" )
								{
									isTrue=true;
									break;
								}
							}
							else break;							
						}
					}

					if (isTrue && myTb.Rows[i]["编号"].ToString().Trim()==myTb.Rows[nrow]["编号"].ToString().Trim())
					{
						this.myDataGrid3.CurrentCell=new DataGridCell(i,0);
						myTb.Rows[i]["选"]=myTb.Rows[i]["选"].ToString()=="True"?false:true;		
					}
				}
			}			
			this.myDataGrid3.DataSource=myTb;	
			this.myDataGrid3.CurrentCell=myCel;
		}


		private void bt刷新明细表_Click(object sender, System.EventArgs e)
		{
			Cursor.Current=PubStaticFun.WaitCursor();  

			DataTable myTb1=(DataTable)this.myDataGrid3.DataSource;
			if (myTb1!=null) myTb1.Rows.Clear();

			DataTable myTb=new DataTable();

			//0=已经统领查询 1=基数药 2=缺药 3=普通药品统领信息 5=正常基数药 6=缺药基数药 7=针剂
			int YPLX=1;

			if(rdoNormal.Checked)
			{
				YPLX=5;
				txtPy.Enabled=false;
				cmbYP.Enabled=false;
			}
			else if(rdoQY.Checked)
			{
				YPLX=6;
				txtPy.Enabled=false;
				cmbYP.Enabled=false;
			}
			else if(rdoZJ.Checked)
			{
				YPLX=7;
				txtPy.Enabled=false;
				cmbYP.Enabled=false;
			}
			else if(rdoQuick.Checked)
			{
				if(cmbYP.SelectedIndex==-1)
				{
					MessageBox.Show("请选择一种药品！","提示",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					return;
				}
			}
			else
			{
				YPLX=1;
				txtPy.Enabled=false;
				cmbYP.Enabled=false;
			}

			if(rdoQuick.Checked)
			{
				myTb=myFunc.GetJSYTLD(InstanceForm.BCurrentDept.WardId,cmbYP.SelectedValue.ToString().Trim());
				#region 废代码
				/*
				string sSql="WITH TT5(fee_id, NAME, INPATIENT_NO, BED_NO, SUBCODE, NUM, UNIT, RETAIL_PRICE, "+
						" ACVALUE, ID, group_id, exec_dept, dept_id, S_SPM, S_GG, inpatient_id, baby_id) "+
						" AS (SELECT c.id, Q.NAME, Q.INPATIENT_NO, Q.BED_NO, SUBCODE, c.NUM, c.UNIT, "+
						" RETAIL_PRICE, ACVALUE, C.ID, 0, o.exec_dept, o.dept_id, S_SPM, S_GG,"+ 
						" o.inpatient_id, o.baby_id"+
						" FROM (SELECT * "+
						" FROM ZY_FEE_SPECI fee"+
						" WHERE charge_bit = 1 AND FINISH_BIT = 0 AND subcode ='"+cmbYP.SelectedValue.ToString().Trim()+"') "+
						" C INNER JOIN"+
						" (SELECT *"+
						" FROM zy_orderrecord"+
						" WHERE HOITEM_ID IN (53, 54) AND item_code='"+cmbYP.SelectedValue.ToString().Trim()+"' AND "+
						" (dept_id IN"+
						" (SELECT DEPT_ID"+
						" FROM jc_WARDRDEPT"+
						" WHERE WARD_ID = '"+InstanceForm.BCurrentDept.WardId+"')) AND mngtype <> 5) o ON "+
						" c.order_id = o.order_id INNER JOIN"+
						" (SELECT M.INPATIENT_ID, 0, M.NAME, M.INPATIENT_NO, N.BED_NO, "+
						" 0 AS BABY_ID"+
						" FROM ZY_VINPATIENT M LEFT JOIN"+
						" ZY_BEDDICTION N ON M.BED_ID = N.BED_ID"+
						" UNION ALL"+
						" SELECT M.INPATIENT_ID, M.BABY_ID, M.BABYNAME AS NAME, "+
						" M.INPATIENT_NO, N.BED_NO, M.BABY_ID"+
						" FROM ZY_INPATIENT_BABY M LEFT JOIN"+
						" ZY_BEDDICTION N ON M.BED_ID = N.BED_ID) AS Q ON "+
						" o.INPATIENT_ID = Q.INPATIENT_ID AND o.BABY_ID = Q.BABY_ID INNER JOIN"+
						" (SELECT X.S_SPM, X.S_GG, X.S_HH"+
						" FROM (SELECT *"+
						" FROM yk_xyd"+
						" UNION ALL"+
						" SELECT *"+
						" FROM yk_cyd) X"+
						" WHERE S_HH='"+cmbYP.SelectedValue.ToString().Trim()+"') AS P ON o.item_code = P.S_HH)"+
						" SELECT BED_NO 床号, INPATIENT_NO 住院号, NAME 姓名, SUBCODE 编号, "+
						" S_SPM 名称, NUM 数量, UNIT 单位, S_GG 规格, RETAIL_PRICE 单价, "+
						" ACVALUE 金额, ID, tt5.group_id, exec_dept, dept_id, tt5.inpatient_id, "+
						" tt5.baby_id"+
						" FROM TT5"+
						" WHERE seekfeeid(cast(fee_id AS bigint)) IS NULL"+
						" ORDER BY 编号"; 
				myTb=InstanceForm.BDatabase.GetDataTable(sSql);
				*/
				#endregion
			}
			else if(rdoNormal.Checked)
			{
				DataTable medTb = new DataTable();
				DataTable jsyTb = new DataTable();
				string medSql="SELECT DISTINCT ITEM_CODE FROM jc_DEPTMED WHERE DEPT_ID IN (SELECT DEPT_ID FROM jc_WARDRDEPT WHERE WARD_ID='"+InstanceForm.BCurrentDept.WardId+"') and delete_bit=0 and ITEM_CODE in (select s_hh from yk_vyd where isxzj<>1)";
				medTb=InstanceForm.BDatabase.GetDataTable(medSql);

				if(medTb==null || medTb.Rows.Count==0)
					return;

				if(myTb.Columns.Count==0)
				{
					myTb.Columns.Add("床号");
					myTb.Columns.Add("住院号");
					myTb.Columns.Add("姓名");
					myTb.Columns.Add("编号");
					myTb.Columns.Add("名称");
					myTb.Columns.Add("数量");
					myTb.Columns.Add("单位");
					myTb.Columns.Add("规格");
					myTb.Columns.Add("单价");
					myTb.Columns.Add("金额");
					myTb.Columns.Add("ID");
					myTb.Columns.Add("GROUP_ID");
					myTb.Columns.Add("EXEC_DEPT");
					myTb.Columns.Add("DEPT_ID");
					myTb.Columns.Add("INPATIENT_ID");
					myTb.Columns.Add("BABY_ID");
				}

				this.progressBar1.Value=0;
				this.progressBar1.Maximum=medTb.Rows.Count;

				for(int i=0;i<medTb.Rows.Count;i++)
				{
					this.progressBar1.Value+=1;
					jsyTb.Clear();
					jsyTb=myFunc.GetJSYTLD(InstanceForm.BCurrentDept.WardId,medTb.Rows[i][0].ToString());
					
					if(jsyTb==null || jsyTb.Rows.Count==0)
						continue;

					for(int j=0;j<jsyTb.Rows.Count;j++)
					{
						DataRow dr = myTb.NewRow();
//						dr=(DataRow)jsyTb.Rows[j];
						dr["床号"]=jsyTb.Rows[j]["床号"];
						dr["住院号"]=jsyTb.Rows[j]["住院号"];
						dr["姓名"]=jsyTb.Rows[j]["姓名"];
						dr["编号"]=jsyTb.Rows[j]["编号"];
						dr["名称"]=jsyTb.Rows[j]["名称"];
						dr["数量"]=jsyTb.Rows[j]["数量"];
						dr["单位"]=jsyTb.Rows[j]["单位"];
						dr["规格"]=jsyTb.Rows[j]["规格"];
						dr["单价"]=jsyTb.Rows[j]["单价"];
						dr["金额"]=jsyTb.Rows[j]["金额"];
						dr["ID"]=jsyTb.Rows[j]["ID"];
						dr["GROUP_ID"]=jsyTb.Rows[j]["GROUP_ID"];
						dr["EXEC_DEPT"]=jsyTb.Rows[j]["EXEC_DEPT"];
						dr["DEPT_ID"]=jsyTb.Rows[j]["DEPT_ID"];
						dr["INPATIENT_ID"]=jsyTb.Rows[j]["INPATIENT_ID"];
						dr["BABY_ID"]=jsyTb.Rows[j]["BABY_ID"];
						myTb.Rows.Add(dr);
					}
				}

				this.progressBar1.Value=0;
			}
			else if(rdoZJ.Checked)
			{
				DataTable medTb = new DataTable();
				DataTable jsyTb = new DataTable();
				string medSql="SELECT DISTINCT ITEM_CODE FROM jc_DEPTMED "+
					" WHERE DEPT_ID IN (SELECT DEPT_ID FROM jc_WARDRDEPT WHERE WARD_ID='"+InstanceForm.BCurrentDept.WardId+"') "+
					" and delete_bit=0 and ITEM_CODE in (select s_hh from yk_vyd where isxzj=1)";
				medTb=InstanceForm.BDatabase.GetDataTable(medSql);

				if(medTb==null || medTb.Rows.Count==0)
					return;

				if(myTb.Columns.Count==0)
				{
					myTb.Columns.Add("床号");
					myTb.Columns.Add("住院号");
					myTb.Columns.Add("姓名");
					myTb.Columns.Add("编号");
					myTb.Columns.Add("名称");
					myTb.Columns.Add("数量");
					myTb.Columns.Add("单位");
					myTb.Columns.Add("规格");
					myTb.Columns.Add("单价");
					myTb.Columns.Add("金额");
					myTb.Columns.Add("ID");
					myTb.Columns.Add("GROUP_ID");
					myTb.Columns.Add("EXEC_DEPT");
					myTb.Columns.Add("DEPT_ID");
					myTb.Columns.Add("INPATIENT_ID");
					myTb.Columns.Add("BABY_ID");
				}

				this.progressBar1.Value=0;
				this.progressBar1.Maximum=medTb.Rows.Count;

				for(int i=0;i<medTb.Rows.Count;i++)
				{
					this.progressBar1.Value+=1;
					jsyTb.Clear();
					jsyTb=myFunc.GetJSYTLD(InstanceForm.BCurrentDept.WardId,medTb.Rows[i][0].ToString());
					
					if(jsyTb==null || jsyTb.Rows.Count==0)
						continue;

					for(int j=0;j<jsyTb.Rows.Count;j++)
					{
						DataRow dr = myTb.NewRow();
						//						dr=(DataRow)jsyTb.Rows[j];
						dr["床号"]=jsyTb.Rows[j]["床号"];
						dr["住院号"]=jsyTb.Rows[j]["住院号"];
						dr["姓名"]=jsyTb.Rows[j]["姓名"];
						dr["编号"]=jsyTb.Rows[j]["编号"];
						dr["名称"]=jsyTb.Rows[j]["名称"];
						dr["数量"]=jsyTb.Rows[j]["数量"];
						dr["单位"]=jsyTb.Rows[j]["单位"];
						dr["规格"]=jsyTb.Rows[j]["规格"];
						dr["单价"]=jsyTb.Rows[j]["单价"];
						dr["金额"]=jsyTb.Rows[j]["金额"];
						dr["ID"]=jsyTb.Rows[j]["ID"];
						dr["GROUP_ID"]=jsyTb.Rows[j]["GROUP_ID"];
						dr["EXEC_DEPT"]=jsyTb.Rows[j]["EXEC_DEPT"];
						dr["DEPT_ID"]=jsyTb.Rows[j]["DEPT_ID"];
						dr["INPATIENT_ID"]=jsyTb.Rows[j]["INPATIENT_ID"];
						dr["BABY_ID"]=jsyTb.Rows[j]["BABY_ID"];
						myTb.Rows.Add(dr);
					}
				}

				this.progressBar1.Value=0;
			}
			else
			{
//				myTb=myFunc.GetPatientYPTLD(0,YPLX,0,InstanceForm.BCurrentDept.WardId);因为类里面没有 Modify By Tany 2006-12-04
			}

			DataColumn col=new DataColumn();
			col.DataType=System.Type.GetType("System.Boolean");			 
			col.AllowDBNull=false;
			col.ColumnName="选";
			col.DefaultValue=false;
			myTb.Columns.Add(col);

			this.myDataGrid3.DataSource=myTb;
			this.myDataGrid3.TableStyles[0].RowHeaderWidth=5;	
//			this.myDataGrid3.TableStyles[0].MappingName="MedYPMXD";	
			System.DateTime TempDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
//			this.myDataGrid3.CaptionText="明细表 -- "+ TempDate.ToString() ;					

			this.bt全选_Click(sender,e);
			this.bt刷新统计表_Click(sender,e);
			this.myDataGrid2.CaptionText="统计表（金额总计："+total.ToString()+"元）-- "+ TempDate.ToString();
			
		}

		private void bt刷新统计表_Click(object sender, System.EventArgs e)
		{
			
			total=0;
			string sSql="";
			bool isSelect=false;

			DataTable myTb2=(DataTable)this.myDataGrid2.DataSource;
			if (myTb2!=null) myTb2.Rows.Clear();

			DataTable myTb1=(DataTable)this.myDataGrid3.DataSource;
			if (myTb1==null) return;
			if (myTb1.Rows.Count==0) return;

			Cursor.Current=PubStaticFun.WaitCursor();  
			
			try
			{		
//				OleDbConnection tempCon=new OleDbConnection();
//				tempCon.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=0;Jet OLEDB:Database Password=;Data Source=c:\winnt\db1.mdb;Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
//				tempCon.Open();
//
//				OleDbCommand myCmd=new OleDbCommand();
//				myCmd.Connection=tempCon;
//				sSql="delete from MedMXD"; 
//				myCmd.CommandText=sSql;
//				myCmd.ExecuteNonQuery();
//				sSql="delete from MedTLD"; 
//				myCmd.CommandText=sSql;
//				myCmd.ExecuteNonQuery();

				this.progressBar1.Maximum=myTb1.Rows.Count+5;
				this.progressBar1.Value=0;
				rds.Tables["MedYPMXD"].Clear();
				rds.Tables["MedYPTLD"].Clear();
				int j;

				for(j=0;j<=myTb1.Rows.Count-1;j++)
				{
					if (myTb1.Rows[j]["选"].ToString()=="True")
					{
//						sSql="INSERT INTO MedMXD(床号,住院号,姓名,编号,名称,规格,数量,单位,单价,金额) "+
//							"VALUES("+
//							"'"+myTb1.Rows[j]["床号"].ToString()+"',"+
//							"'"+myTb1.Rows[j]["住院号"].ToString()+"',"+
//							"'"+myTb1.Rows[j]["姓名"].ToString()+"',"+
//							"'"+myTb1.Rows[j]["编号"].ToString()+"',"+
//							"'"+myTb1.Rows[j]["名称"].ToString()  +"',"+
//							"'"+myTb1.Rows[j]["规格"].ToString()   +"',"+
//							+Convert.ToDouble(myTb1.Rows[j]["数量"]) +" ,"+
//							"'"+myTb1.Rows[j]["单位"].ToString()   +"',"+
//							+Convert.ToDouble(myTb1.Rows[j]["单价"]) +" ,"+
//							+Convert.ToDouble(myTb1.Rows[j]["金额"]) +")";								
//						myCmd.CommandText=sSql;
//						myCmd.ExecuteNonQuery();
						dr=rds.Tables["MedYPMXD"].NewRow();
						dr["床号"]=myTb1.Rows[j]["床号"].ToString();
						dr["住院号"]=myTb1.Rows[j]["住院号"].ToString();
						dr["姓名"]=myTb1.Rows[j]["姓名"].ToString();
						//dr["日期"]=Convert.ToDateTime(myTb1.Rows[j]["presc_date"]).Month.ToString()+"-"+Convert.ToDateTime(myTb1.Rows[j]["presc_date"]).Day.ToString();
						dr["编号"]=myTb1.Rows[j]["编号"].ToString();
						dr["名称"]=myTb1.Rows[j]["名称"].ToString();
						dr["规格"]=myTb1.Rows[j]["规格"].ToString();
						dr["数量"]=Convert.ToDouble(myTb1.Rows[j]["数量"]);
						dr["单位"]=myTb1.Rows[j]["单位"].ToString();
						dr["单价"]=Convert.ToDouble(myTb1.Rows[j]["单价"]);
						dr["金额"]=Convert.ToDouble(myTb1.Rows[j]["金额"]);
						dr["选"]=false;
						rds.Tables["MedYPMXD"].Rows.Add(dr);
						total+=Convert.ToDouble(myTb1.Rows[j]["金额"]);
						isSelect=true;
					}
					this.progressBar1.Value+=1;
				}
				
				if (isSelect)
				{
					for(j=0;j<=rds.Tables["MedYPMXD"].Rows.Count-1;j++)
					{
						dr=rds.Tables["MedYPTLD"].NewRow();
						dr["编号"]=rds.Tables["MedYPMXD"].Rows[j]["编号"].ToString().Trim();
						dr["名称"]=rds.Tables["MedYPMXD"].Rows[j]["名称"].ToString();
						dr["规格"]=rds.Tables["MedYPMXD"].Rows[j]["规格"].ToString();
						dr["单位"]=rds.Tables["MedYPMXD"].Rows[j]["单位"].ToString();
						dr["单价"]=Convert.ToDouble(rds.Tables["MedYPMXD"].Rows[j]["单价"]);
						dr["数量"]=Convert.ToDouble(rds.Tables["MedYPMXD"].Compute("Sum(数量)","编号='"+dr["编号"]+"' and 单位='"+dr["单位"]+"'"));//Modify By Tany 2004-12-10 加入单位的判断
						dr["金额"]=Convert.ToDouble(rds.Tables["MedYPMXD"].Compute("SUM(金额)","编号='"+dr["编号"]+"' and 单位='"+dr["单位"]+"'"));//Modify By Tany 2004-12-10 加入单位的判断
						bool boo_existsamerow=false;
						for(int m=0;m<=rds.Tables["MedYPTLD"].Rows.Count-1;m++)		//模拟分组汇总（寻找相同药品，如果有则不加入数据集）
						{
							if(rds.Tables["MedYPTLD"].Rows[m]["编号"].ToString()==dr["编号"].ToString()
								&& rds.Tables["MedYPTLD"].Rows[m]["单位"].ToString()==dr["单位"].ToString())//Modify By Tany 2004-12-10 加入单位的判断
							{
								boo_existsamerow=true;
								break;
							}
						}
						if(!boo_existsamerow)
							rds.Tables["MedYPTLD"].Rows.Add(dr);
					}		
//					sSql="INSERT INTO MedTLD(编号,名称,规格,数量,单位,单价,金额) "+
//						"SELECT 编号,名称,规格,SUM(数量) AS 数量,单位,单价,SUM(金额) AS 金额"+
//						"  FROM MedMXD "+
//						"GROUP BY 编号,名称,规格,单位,单价";
//					myCmd.CommandText=sSql;
//					myCmd.ExecuteNonQuery();


					this.progressBar1.Value+=2;

//					sSql="SELECT * FROM MedTLD";
//					DataTable myTempTb1=new DataTable();
//					myTempTb1=myOpenAss(tempCon,sSql);
					DataTable myTempTb1=rds.Tables["MedYPTLD"];
					this.myDataGrid2.DataSource=myTempTb1;
					this.myDataGrid2.TableStyles[0].RowHeaderWidth=5;
					this.myDataGrid2.TableStyles[0].MappingName="MedYPTLD";	
					this.myDataGrid2.CaptionText="统计表（金额总计："+total.ToString()+"元）-- "+ DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
					for (int i=myTempTb1.Rows.Count-1;i>=0;i--)
					{
						myTempTb1.Rows[i]["金额"]=string.Format("{0:F2}",myTempTb1.Rows[i]["金额"]);
					}
					this.progressBar1.Value+=3;
//					tempCon.Close();
				}
			}
			catch(System.Data.OleDb.OleDbException err)
			{
				MessageBox.Show(err.ToString());
			}
			
			Cursor.Current=Cursors.Default;
			this.progressBar1.Value=0;
	
		}

		private DataTable myOpenAss(OleDbConnection cCon,string sSql)
		{
			DataTable myTb=new DataTable();
			try
			{
				System.Data.OleDb.OleDbCommand mySelCmd=new OleDbCommand();
				mySelCmd.CommandText=sSql;			
				mySelCmd.Connection=cCon;
				mySelCmd.CommandType=System.Data.CommandType.Text ;
				System.Data.OleDb.OleDbDataAdapter myAdp=new OleDbDataAdapter();
				myAdp.SelectCommand=mySelCmd;
				myAdp.Fill(myTb);
			}
			catch(System.Data.OleDb.OleDbException err)
			{
				MessageBox.Show(err.ToString());
			}			
			return myTb;
		}

		private void bt发送统计表_Click(object sender, System.EventArgs e)
		{
			//this.bt刷新明细表_Click(sender,e);
		  
			DataTable myTb=(DataTable)this.myDataGrid2.DataSource;
			if (myTb==null || (myTb!=null && myTb.Rows.Count==0))
			{
				MessageBox.Show(this,"对不起，统计表没有数据或数据已经被发送！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Error); 
				return;
			}

			if (MessageBox.Show(this, "确认发送所选择的药品吗（金额总计："+total.ToString()+"元）？", "确认", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) 	return;			

			Cursor.Current=PubStaticFun.WaitCursor();  

			string sSql="";
			System.DateTime TempDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			this.myDataGrid2.CaptionText="统计表（金额总计："+total.ToString()+"元）-- "+ TempDate.ToString();

			DataTable myTb1=(DataTable)this.myDataGrid3.DataSource;
			this.progressBar1.Maximum=myTb1.Rows.Count+5;
			this.progressBar1.Value=0;
	
			//生成数据访问对象
			RelationalDatabase database=RelationalDatabase.GetDatabase();
			database.Initialize("");
			database.Open();
			//开始一个事物
			database.BeginTransaction();

			try
			{
				for(int j=0;j<=myTb1.Rows.Count-1;j++)
				{
					if (myTb1.Rows[j]["选"].ToString()=="True")
					{
						if (myTb1.Rows[j]["group_id"].ToString().Trim()=="-1")
						{
							sSql="update ZY_PUTOUTDRUG set group_id=0,apply_id=-2,apply_date='"+TempDate.ToString()+"' where nfee_id="+Convert.ToInt32(myTb1.Rows[j]["ID"].ToString());
						}
						else
						{
							//发送药品明细
							sSql="INSERT INTO ZY_PUTOUTDRUG (apply_date,apply_id,nFee_id,med_kind,execdept,dept_id) "+
								" VALUES ('"+TempDate.ToString()+"',-2,"+myTb1.Rows[j]["ID"].ToString()+",2,"+Convert.ToInt32(myTb1.Rows[j]["exec_dept"])+","+Convert.ToInt32(myTb1.Rows[j]["dept_id"])+")";
						}
						database.DoCommand(sSql);					
					}
					this.progressBar1.Value+=1;
				}
				//发送药品消息 只执行统领 Modify By Tany 2004-11-09
//				myFunc.SendYPFY("",InstanceForm.BCurrentDept.WardId,0,0,InstanceForm.BCurrentUser.EmployeeId,TempDate,1,-2,database);

				database.CommitTransaction();
			}
			catch(Exception err)
			{
				database.RollbackTransaction();

				//写错误日志 Add By Tany 2005-01-12
				SystemLog _systemErrLog=new SystemLog(-1,InstanceForm.BCurrentDept.DeptId,InstanceForm.BCurrentUser.EmployeeId,"程序错误","发送基数药错误："+err.Message+"  Source："+err.Source,DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase),1,"主机名："+System.Environment.MachineName,5);
				_systemErrLog.Save();
				_systemErrLog=null;

				MessageBox.Show("错误："+err.Message+"\n"+"Source："+err.Source,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				progressBar1.Value=0;
			}

			this.progressBar1.Value+=5;
			
			this.bt刷新明细表_Click(sender,e);
			this.progressBar1.Value=0;
		}

		private void rdoQuick_Click(object sender, System.EventArgs e)
		{
			txtPy.Enabled=true;
			cmbYP.Enabled=true;
			txtPy.Focus();
		}

		private void LoadJSY()
		{
			string sSql="SELECT X.S_SPM||' ['||X.S_GG||']' name,X.S_HH,Y.s_dmbm"+
					" FROM (select * from yk_xyd union all select * from yk_cyd) X"+
					" INNER JOIN (select * from yk_xydbm where ntype=1) Y on X.s_hh=Y.yphh"+
					" where S_HH IN (SELECT DISTINCT ITEM_CODE FROM jc_DEPTMED WHERE DEPT_ID IN (SELECT DEPT_ID FROM jc_WARDRDEPT WHERE WARD_ID='"+InstanceForm.BCurrentDept.WardId+"') and delete_bit=0)"+
					" order by s_dmbm";
			JSYTb=InstanceForm.BDatabase.GetDataTable(sSql);

			cmbYP.DataSource=JSYTb;
			cmbYP.DisplayMember="NAME";
			cmbYP.ValueMember="S_HH";
		}

		private void txtPy_TextChanged(object sender, System.EventArgs e)
		{
			string CurrentChar=txtPy.Text.Trim();
			int j=CurrentChar.Length;
			while (j>0)
			{
				string sCode=CurrentChar.Substring(0,j);
				for(int i=0;i<=JSYTb.Rows.Count-1;i++)
				{	
					if (JSYTb.Rows[i]["s_dmbm"].ToString().Trim().Length<j) continue;
					if (JSYTb.Rows[i]["s_dmbm"].ToString().Trim().Substring(0,j).ToLower()==sCode.ToLower())
					{
						cmbYP.SelectedIndex=i;
						j=1;
						break;
					}
				}
				j--;
			}
		}

		private void txtPy_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13)
				bt刷新明细表.Focus();
		}

		private void bt退出_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
