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

namespace ts_yf_ypck
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmtitle : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.Button butnew;
		private System.Windows.Forms.Button butclose;
		private System.Windows.Forms.Button butsh;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.CheckBox chkdjsj;
		private System.Windows.Forms.TextBox txtdjh;
		private System.Windows.Forms.CheckBox chkdjh;
		private System.Windows.Forms.TextBox txtghdw;
		private System.Windows.Forms.CheckBox chkghdw;
		private System.Windows.Forms.RadioButton rdo2;
		private System.Windows.Forms.RadioButton rdo1;
		private System.Windows.Forms.Button butref;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn 往来科室;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.Button butdel;
		private MenuTag _menuTag;
		private string _chineseName;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
        private Button butexcel;
        private DataGridTextBoxColumn dataGridTextBoxColumn23;
		private Form _mdiParent;

		public Frmtitle(MenuTag menuTag,string chineseName,Form mdiParent)
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.往来科室 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.butexcel = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butsh = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.butnew = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.chkdjsj = new System.Windows.Forms.CheckBox();
            this.txtdjh = new System.Windows.Forms.TextBox();
            this.chkdjh = new System.Windows.Forms.CheckBox();
            this.txtghdw = new System.Windows.Forms.TextBox();
            this.chkghdw = new System.Windows.Forms.CheckBox();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.butref = new System.Windows.Forms.Button();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 485);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.myDataGrid1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 88);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(832, 341);
            this.panel5.TabIndex = 3;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(832, 341);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1,
            this.dataGridTableStyle2});
            this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid1_DoubleClick);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.myDataGrid1_Navigate);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn8,
            this.往来科室,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn23});
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
            this.dataGridTextBoxColumn2.HeaderText = "单据号";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 60;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "单据日期";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "进货金额";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.Width = 65;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "批发金额";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 65;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "零售金额";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 65;
            // 
            // 往来科室
            // 
            this.往来科室.Format = "";
            this.往来科室.FormatInfo = null;
            this.往来科室.HeaderText = "往来科室";
            this.往来科室.NullText = "";
            this.往来科室.ReadOnly = true;
            this.往来科室.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "登记时间";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 110;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "登记员";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "审核时间";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 0;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "审核员";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 0;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "备注";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "id";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 0;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "申领单号";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 0;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn21});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "序号";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.ReadOnly = true;
            this.dataGridTextBoxColumn13.Width = 50;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "申领单号";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.ReadOnly = true;
            this.dataGridTextBoxColumn18.Width = 75;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "申领科室";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 75;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "申领时间";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 130;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "申领人";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.Width = 75;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "备注";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.ReadOnly = true;
            this.dataGridTextBoxColumn17.Width = 150;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "id";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.Width = 0;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "单据号";
            this.dataGridTextBoxColumn20.Width = 0;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "deptid";
            this.dataGridTextBoxColumn21.Width = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.butexcel);
            this.panel4.Controls.Add(this.butdel);
            this.panel4.Controls.Add(this.butclose);
            this.panel4.Controls.Add(this.butsh);
            this.panel4.Controls.Add(this.statusBar1);
            this.panel4.Controls.Add(this.butnew);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 429);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(832, 56);
            this.panel4.TabIndex = 2;
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point(222, 6);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(116, 24);
            this.butexcel.TabIndex = 5;
            this.butexcel.Text = "导出EXCEL";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // butdel
            // 
            this.butdel.Enabled = false;
            this.butdel.Location = new System.Drawing.Point(536, 6);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(88, 24);
            this.butdel.TabIndex = 4;
            this.butdel.Text = "删除(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(636, 6);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 3;
            this.butclose.Text = "关闭(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butsh
            // 
            this.butsh.Location = new System.Drawing.Point(440, 6);
            this.butsh.Name = "butsh";
            this.butsh.Size = new System.Drawing.Size(88, 24);
            this.butsh.TabIndex = 2;
            this.butsh.Text = "查看(&H)";
            this.butsh.Click += new System.EventHandler(this.butsh_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 32);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(832, 24);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 200;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 1000;
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(344, 6);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(88, 24);
            this.butnew.TabIndex = 0;
            this.butnew.Text = "新单据(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(832, 88);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtp2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp1);
            this.panel2.Controls.Add(this.chkdjsj);
            this.panel2.Controls.Add(this.txtdjh);
            this.panel2.Controls.Add(this.chkdjh);
            this.panel2.Controls.Add(this.txtghdw);
            this.panel2.Controls.Add(this.chkghdw);
            this.panel2.Controls.Add(this.rdo2);
            this.panel2.Controls.Add(this.rdo1);
            this.panel2.Controls.Add(this.butref);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 88);
            this.panel2.TabIndex = 3;
            // 
            // dtp2
            // 
            this.dtp2.Enabled = false;
            this.dtp2.Location = new System.Drawing.Point(394, 42);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(110, 21);
            this.dtp2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(371, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.Enabled = false;
            this.dtp1.Location = new System.Drawing.Point(257, 42);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(111, 21);
            this.dtp1.TabIndex = 2;
            // 
            // chkdjsj
            // 
            this.chkdjsj.Location = new System.Drawing.Point(184, 41);
            this.chkdjsj.Name = "chkdjsj";
            this.chkdjsj.Size = new System.Drawing.Size(80, 22);
            this.chkdjsj.TabIndex = 8;
            this.chkdjsj.Text = "登记时间";
            this.chkdjsj.CheckedChanged += new System.EventHandler(this.chkshdh_CheckedChanged);
            // 
            // txtdjh
            // 
            this.txtdjh.Enabled = false;
            this.txtdjh.Location = new System.Drawing.Point(497, 11);
            this.txtdjh.Name = "txtdjh";
            this.txtdjh.Size = new System.Drawing.Size(88, 21);
            this.txtdjh.TabIndex = 1;
            // 
            // chkdjh
            // 
            this.chkdjh.Location = new System.Drawing.Point(427, 11);
            this.chkdjh.Name = "chkdjh";
            this.chkdjh.Size = new System.Drawing.Size(73, 22);
            this.chkdjh.TabIndex = 6;
            this.chkdjh.Text = "单据号";
            this.chkdjh.CheckedChanged += new System.EventHandler(this.chkshdh_CheckedChanged);
            // 
            // txtghdw
            // 
            this.txtghdw.Enabled = false;
            this.txtghdw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtghdw.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtghdw.Location = new System.Drawing.Point(256, 11);
            this.txtghdw.Name = "txtghdw";
            this.txtghdw.Size = new System.Drawing.Size(160, 21);
            this.txtghdw.TabIndex = 0;
            this.txtghdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // chkghdw
            // 
            this.chkghdw.Location = new System.Drawing.Point(184, 11);
            this.chkghdw.Name = "chkghdw";
            this.chkghdw.Size = new System.Drawing.Size(80, 22);
            this.chkghdw.TabIndex = 2;
            this.chkghdw.Text = "往来科室";
            this.chkghdw.CheckedChanged += new System.EventHandler(this.chkshdh_CheckedChanged);
            // 
            // rdo2
            // 
            this.rdo2.Checked = true;
            this.rdo2.Location = new System.Drawing.Point(24, 35);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(72, 22);
            this.rdo2.TabIndex = 1;
            this.rdo2.TabStop = true;
            this.rdo2.Text = "已审核";
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.Location = new System.Drawing.Point(24, 12);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(88, 22);
            this.rdo1.TabIndex = 0;
            this.rdo1.Text = "申请领药单";
            this.rdo1.Visible = false;
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // butref
            // 
            this.butref.Location = new System.Drawing.Point(520, 40);
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size(88, 24);
            this.butref.TabIndex = 4;
            this.butref.Text = "刷新(&R)";
            this.butref.Click += new System.EventHandler(this.butref_Click);
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "接收状态";
            this.dataGridTextBoxColumn23.MappingName = "接收状态";
            this.dataGridTextBoxColumn23.NullText = "";
            this.dataGridTextBoxColumn23.Width = 150;
            // 
            // Frmtitle
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(832, 485);
            this.Controls.Add(this.panel1);
            this.Name = "Frmtitle";
            this.Text = "药品出库";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Frmtitle_Activated);
            this.Load += new System.EventHandler(this.Frmtitle_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void butnew_Click(object sender, System.EventArgs e)
		{

            if (YpConfig.是否药库(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) == true)
            {
                MessageBox.Show("您的登陆科室是药库,但进入了药房系统", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

			Frmypck f=new Frmypck(_menuTag,_chineseName,_mdiParent);
			Point point=new Point(160,75 );
			f.Location=point;
			f.MdiParent=_mdiParent;
			f.Show();
		}

		private void chkshdh_CheckedChanged(object sender, System.EventArgs e)
		{
			this.txtghdw.Enabled=chkghdw.Checked==true?true:false;
			this.txtdjh.Enabled=chkdjh.Checked==true?true:false;
			this.dtp1.Enabled=chkdjsj.Checked==true?true:false;
			this.dtp2.Enabled=chkdjsj.Checked==true?true:false;
		}

		private void Frmtitle_Load(object sender, System.EventArgs e)
		{
			this.dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			this.dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			CsMydataGrid(this.rdo2.Checked);
			FunctionControlEnable(_menuTag.Function_Name.Trim());
            if (rdo2.Checked == true) { chkdjsj.Checked = true; butdel.Enabled = true; }

		}

		private void FunctionControlEnable(string functionName)
		{
			switch(functionName)
			{
				case "Fun_ts_yf_ypck_cfbl":
					chkghdw.Visible=false;
					txtghdw.Visible=false;
					this.往来科室.Width=0;
					break;
				case "Fun_ts_yf_ypck_xygck"://小药柜出库
					this.rdo1.Visible=true;
					this.rdo2.Visible=true;
					this.rdo1.Checked=true;
					break;
				default:
					break;
			} 
		}
		private void CsMydataGrid(bool shbz)
		{
			this.myDataGrid1.DataSource=null;
			if (shbz==true)
			{
				//初始化
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");
				this.chkghdw.Text="往来科室";
			}
			else
			{
				//初始化
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[1],"myTb");
				this.chkghdw.Text="申请科室";
			}
		}
		private void butref_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (chkghdw.Checked==false && chkdjh.Checked==false && chkdjsj.Checked==false && rdo2.Checked==true)
				{MessageBox.Show("查询的记录范围太大，请重新选择查询条件");return;}
				if (txtghdw.Text.Trim()=="" && txtghdw.Enabled==true) {MessageBox.Show("请输入科室");return;}
				if (txtdjh.Text.Trim()=="" && txtdjh.Enabled==true) {MessageBox.Show("请输入单据号");return;}

				ParameterEx[] parameters=new ParameterEx[11];
				parameters[0].Value=_menuTag.FunctionTag.Trim();
				parameters[1].Value=this.chkghdw.Checked==true?Convert.ToInt32(this.txtghdw.Tag):0;
				parameters[2].Value=chkdjsj.Checked==true?dtp1.Value.ToShortDateString():"";
				parameters[3].Value=chkdjsj.Checked==true?dtp2.Value.ToShortDateString():"";
				parameters[4].Value=chkdjh.Checked==true?Convert.ToInt64(Convertor.IsNull(txtdjh.Text,"0")):0;
				parameters[5].Value="";
				parameters[6].Value="";
				parameters[7].Value=this.rdo1.Checked==true?0:1;
				parameters[8].Value=InstanceForm.BCurrentDept.DeptId;
				parameters[9].Value=_menuTag.Function_Name.Trim();
                parameters[10].Value = 0;

				parameters[0].Text="@ywlx";
				parameters[1].Text="@wldw";
				parameters[2].Text="@dtp1";
				parameters[3].Text="@dtp2";
				parameters[4].Text="@djh";
				parameters[5].Text="@fph";
				parameters[6].Text="@shdh";
				parameters[7].Text="@shbz";
				parameters[8].Text="@deptid";
				parameters[9].Text="@functionname";
                parameters[10].Text = "@P_deptid";

				DataTable tb=InstanceForm.BDatabase.GetDataTable("sp_yf_selectDj",parameters,30);
				FunBase.AddRowtNo(tb);
				if (this.rdo2.Checked==true) tb.TableName="Tb";else tb.TableName="myTb"; 
				this.myDataGrid1.DataSource=tb;

				if (rdo1.Checked==true)
					FunBase.myGridSelect(this.myDataGrid1,this.myDataGrid1.TableStyles[1].GridColumnStyles);
				else
					FunBase.myGridSelect(this.myDataGrid1,this.myDataGrid1.TableStyles[0].GridColumnStyles);

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}

		private void butclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butsh_Click(object sender, System.EventArgs e)
		{
			try
			{
				int nrow=this.myDataGrid1.CurrentCell.RowNumber;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				if (tb.Rows.Count==0) return;
				Frmypck f=new  Frmypck(_menuTag,_chineseName,_mdiParent);
				Point point=new Point(160,75 );
				f.Location=point;
				f.MdiParent=_mdiParent;
				f.Show();
				if (this.rdo2.Checked==true)
				{
					f._Sqdh=0;
					f.FillDj(new Guid(tb.Rows[nrow]["id"].ToString()),this.rdo2.Checked);
				}
				else
				{
					f._Sqdh=Convert.ToInt64(tb.Rows[nrow]["申领单号"]);
                    f.FillDj_Rksq(new Guid(tb.Rows[nrow]["id"].ToString()), Convert.ToInt32(tb.Rows[nrow]["deptid"]));
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}
		}

		
		private void rdo2_CheckedChanged(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();
			CsMydataGrid(this.rdo2.Checked);
			this.dataGridTableStyle2.ForeColor=System.Drawing.Color.Black ;
			this.dataGridTableStyle1.ForeColor=System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.chkdjsj.Checked=this.rdo2.Checked==true?true:false;
			this.butdel.Enabled=this.rdo1.Checked==true?true:false;
		}

		private void Frmtitle_Activated(object sender, System.EventArgs e)
		{
            //if (rdo1.Checked==true) this.butref_Click(sender,e);
            this.butref_Click(sender, e);
			
		}

		private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			butsh_Click(sender,e);
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
				
				Point point=new Point(this.Location.X+control.Location.X,this.Location.Y+control.Location.Y+control.Height*3 );
				switch(control.TabIndex)
				{
					case 0:
						if (control.Text.Trim()=="") return;
                        Yp.frmShowCard_funName(sender, ShowCardType.单据往来科室, _menuTag.Function_Name, point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
						if (Convertor.IsNull(control.Tag,"0")!="0") this.SelectNextControl((Control)sender,true,false,true,true);
						break;
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}

		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			this.myDataGrid1.Select(this.myDataGrid1.CurrentCell.RowNumber);
		}

		private void butdel_Click(object sender, System.EventArgs e)
		{
            string msg = "";
            int err_code = 1;
            string err_text = "";
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			int nrow=Convert.ToInt32(this.myDataGrid1.CurrentCell.RowNumber);
			if (nrow>tb.Rows.Count-1) return;
			if(MessageBox.Show("您确定要删除第"+Convert.ToString((nrow+1))+"行这个单据吗 ？","询问窗",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return;

			this.butdel.Enabled=false;

			try
			{
				InstanceForm.BDatabase.BeginTransaction();

                if (rdo1.Checked == true)
                    YF_RKSQ_RKSQMX.DeleteDj(new Guid(tb.Rows[nrow]["id"].ToString()), InstanceForm.BDatabase);
                else
                {
                    DataTable tbdj=YF_DJ_DJMX.SelectDJ(new Guid(tb.Rows[nrow]["id"].ToString()), InstanceForm.BDatabase);

                    //删除单据
                    DataTable tbyjks = Yp.SelectYjks(Convert.ToInt32(tbdj.Rows[0]["wldw"]), InstanceForm.BDatabase);
                    if (tbyjks.Rows.Count > 0 && Convert.ToInt32(tbdj.Rows[0]["wldw"])!=InstanceForm.BCurrentDept.DeptId)
                    {
                        
                        if (Convert.ToInt32(tbyjks.Rows[0]["QYBZ"]) == 1)
                        {
                            if (ts_HospData_Share.yp_yfck.GetShzt(new Guid(tb.Rows[nrow]["id"].ToString()), TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]))) == true)
                            {
                                throw new Exception("该单据对方已审核,不能删除");
                            }

                            if (Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]) == InstanceForm._menuTag.Jgbm)
                            {
                                YF_DJ_DJMX.UpdateKcDrt(new Guid(tb.Rows[nrow]["id"].ToString()), InstanceForm.BDatabase);
                                YF_DJ_DJMX.AddUpdateKcmx(new Guid(tb.Rows[nrow]["id"].ToString()), out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                                if (err_code != 0) throw new Exception(err_text);
                                YF_DJ_DJMX.DeleteDj(new Guid(tb.Rows[nrow]["id"].ToString()), InstanceForm.BDatabase);
                                if (YpConfig.是否药库(Convert.ToInt32(tbdj.Rows[0]["wldw"]), InstanceForm.BDatabase) == true)
                                    Yk_dj_djmx.DeleteDj_YDJ(new Guid(tb.Rows[nrow]["id"].ToString()), InstanceForm.BDatabase);
                                else
                                    YF_DJ_DJMX.DeleteDj_YDJ(new Guid(tb.Rows[nrow]["id"].ToString()), InstanceForm.BDatabase);
                            }
                            else
                            {

                                //三院数据处理_____保存日志
                                Guid log_djid = Guid.Empty;
                                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                                string bz = InstanceForm.BCurrentDept.DeptName + " 删除 " + this.Text + "  ";
                                ts.Save_log(ts_HospData_Share.czlx.yp_删除药房出库单, bz, "yf_dj", "ID", new Guid(tb.Rows[nrow]["id"].ToString()).ToString(), InstanceForm._menuTag.Jgbm, Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]), 0, "", out log_djid, InstanceForm.BDatabase);
                                msg = "删除指令已发送,等稍后再查询";
                                
                            }
                        }
                    }
                    else
                    {
                        YF_DJ_DJMX.UpdateKcDrt(new Guid(tb.Rows[nrow]["id"].ToString()), InstanceForm.BDatabase);
                        YF_DJ_DJMX.AddUpdateKcmx(new Guid(tb.Rows[nrow]["id"].ToString()), out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                        if (err_code != 0) throw new Exception(err_text);
                        YF_DJ_DJMX.DeleteDj(new Guid(tb.Rows[nrow]["id"].ToString()), InstanceForm.BDatabase);
                    }


                }
				//提交事务
				InstanceForm.BDatabase.CommitTransaction();

				this.butdel.Enabled=true;
                if (msg == "")
                    MessageBox.Show("删除成功");
                else
                    MessageBox.Show(msg);
				this.butref_Click(sender,e);

			}
			catch(System.Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				this.butdel.Enabled=true;
				MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
				
			}
		}

		private void myDataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;

                // 创建Excel对象                    --LeeWenjie    2006-11-29
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel无法启动");
                    return;
                }
                // 创建Excel工作薄
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // 列索引，行索引，总列数，总行数
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = tb.Rows.Count;
                for (int i = 0; i <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].Width > 0)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = _chineseName + "一览表";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].Width > 0)
                        objData[0, colIndex++] = myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
                }
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; j++)
                    {
                        if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width > 0)
                        {
                            if (myDataGrid1.TableStyles[0].GridColumnStyles[j].HeaderText == "品名" || myDataGrid1.TableStyles[0].GridColumnStyles[j].HeaderText == "商品名" || myDataGrid1.TableStyles[0].GridColumnStyles[j].HeaderText == "规格")
                                objData[i + 1, colIndex++] = "'" + tb.Rows[i][j].ToString().Trim();
                            else
                                objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString().Trim();
                        }
                    }
                    Application.DoEvents();
                }

                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



	}
}
