using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using XcjwHIS.DatabaseAccessLayer;
using XcjwHIS.PubicBaseClasses;
using XcjwHIS.BussinessLogicLayer.Classes;
using XcMediHis.BaseFun;
using XcMediHis.Mediclass;
using XcjwHIS.BussinessLogicLayer.Forms;

namespace Xc_yk_xtdz
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Frmxtdzmx : System.Windows.Forms.Form
	{
		private string _ywlx;
		private long _employeeID;
		private long _deptID;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		public myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.TabPage tabPage2;
		public myDataGrid.myDataGrid myDataGrid2;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmxtdzmx(long employeeID,long deptID)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_employeeID=employeeID;
			_deptID=deptID;
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.myDataGrid1 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.myDataGrid2 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ItemSize = new System.Drawing.Size(60, 17);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(714, 391);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.myDataGrid1);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(706, 366);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "数量有误";
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
			this.myDataGrid1.CaptionVisible = false;
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.Size = new System.Drawing.Size(706, 366);
			this.myDataGrid1.TabIndex = 0;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn21,
																												  this.dataGridTextBoxColumn22,
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn23,
																												  this.dataGridTextBoxColumn24,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn25,
																												  this.dataGridTextBoxColumn26,
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridTextBoxColumn27,
																												  this.dataGridTextBoxColumn28,
																												  this.dataGridTextBoxColumn33});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			this.dataGridTableStyle1.ReadOnly = true;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "CJID";
			this.dataGridTextBoxColumn1.MappingName = "";
			this.dataGridTextBoxColumn1.Width = 0;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "品名";
			this.dataGridTextBoxColumn2.MappingName = "";
			this.dataGridTextBoxColumn2.Width = 75;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "规格";
			this.dataGridTextBoxColumn3.MappingName = "";
			this.dataGridTextBoxColumn3.Width = 80;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "单位";
			this.dataGridTextBoxColumn4.MappingName = "";
			this.dataGridTextBoxColumn4.Width = 40;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "上期数量";
			this.dataGridTextBoxColumn5.MappingName = "";
			this.dataGridTextBoxColumn5.Width = 60;
			// 
			// dataGridTextBoxColumn21
			// 
			this.dataGridTextBoxColumn21.Format = "";
			this.dataGridTextBoxColumn21.FormatInfo = null;
			this.dataGridTextBoxColumn21.HeaderText = "上期批发金额";
			this.dataGridTextBoxColumn21.MappingName = "";
			this.dataGridTextBoxColumn21.Width = 0;
			// 
			// dataGridTextBoxColumn22
			// 
			this.dataGridTextBoxColumn22.Format = "";
			this.dataGridTextBoxColumn22.FormatInfo = null;
			this.dataGridTextBoxColumn22.HeaderText = "上期零售金额";
			this.dataGridTextBoxColumn22.MappingName = "";
			this.dataGridTextBoxColumn22.Width = 0;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "发生数量";
			this.dataGridTextBoxColumn6.MappingName = "";
			this.dataGridTextBoxColumn6.Width = 60;
			// 
			// dataGridTextBoxColumn23
			// 
			this.dataGridTextBoxColumn23.Format = "";
			this.dataGridTextBoxColumn23.FormatInfo = null;
			this.dataGridTextBoxColumn23.HeaderText = "发生批发金额";
			this.dataGridTextBoxColumn23.MappingName = "";
			this.dataGridTextBoxColumn23.Width = 0;
			// 
			// dataGridTextBoxColumn24
			// 
			this.dataGridTextBoxColumn24.Format = "";
			this.dataGridTextBoxColumn24.FormatInfo = null;
			this.dataGridTextBoxColumn24.HeaderText = "发生零售金额";
			this.dataGridTextBoxColumn24.MappingName = "";
			this.dataGridTextBoxColumn24.Width = 0;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "库存数量";
			this.dataGridTextBoxColumn7.MappingName = "";
			this.dataGridTextBoxColumn7.Width = 60;
			// 
			// dataGridTextBoxColumn25
			// 
			this.dataGridTextBoxColumn25.Format = "";
			this.dataGridTextBoxColumn25.FormatInfo = null;
			this.dataGridTextBoxColumn25.HeaderText = "库存批发金额";
			this.dataGridTextBoxColumn25.MappingName = "";
			this.dataGridTextBoxColumn25.Width = 0;
			// 
			// dataGridTextBoxColumn26
			// 
			this.dataGridTextBoxColumn26.Format = "";
			this.dataGridTextBoxColumn26.FormatInfo = null;
			this.dataGridTextBoxColumn26.HeaderText = "库存零售金额";
			this.dataGridTextBoxColumn26.MappingName = "";
			this.dataGridTextBoxColumn26.Width = 0;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "数量误差";
			this.dataGridTextBoxColumn8.MappingName = "";
			this.dataGridTextBoxColumn8.Width = 60;
			// 
			// dataGridTextBoxColumn27
			// 
			this.dataGridTextBoxColumn27.Format = "";
			this.dataGridTextBoxColumn27.FormatInfo = null;
			this.dataGridTextBoxColumn27.HeaderText = "批发金额差值";
			this.dataGridTextBoxColumn27.MappingName = "";
			this.dataGridTextBoxColumn27.Width = 0;
			// 
			// dataGridTextBoxColumn28
			// 
			this.dataGridTextBoxColumn28.Format = "";
			this.dataGridTextBoxColumn28.FormatInfo = null;
			this.dataGridTextBoxColumn28.HeaderText = "零售金额差值";
			this.dataGridTextBoxColumn28.MappingName = "";
			this.dataGridTextBoxColumn28.Width = 0;
			// 
			// dataGridTextBoxColumn33
			// 
			this.dataGridTextBoxColumn33.Format = "";
			this.dataGridTextBoxColumn33.FormatInfo = null;
			this.dataGridTextBoxColumn33.HeaderText = "dwbl";
			this.dataGridTextBoxColumn33.MappingName = "";
			this.dataGridTextBoxColumn33.Width = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.myDataGrid2);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(706, 366);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "金额有误";
			// 
			// myDataGrid2
			// 
			this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
			this.myDataGrid2.CaptionVisible = false;
			this.myDataGrid2.DataMember = "";
			this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid2.Name = "myDataGrid2";
			this.myDataGrid2.Size = new System.Drawing.Size(706, 366);
			this.myDataGrid2.TabIndex = 0;
			this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle2});
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn34,
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn11,
																												  this.dataGridTextBoxColumn12,
																												  this.dataGridTextBoxColumn29,
																												  this.dataGridTextBoxColumn13,
																												  this.dataGridTextBoxColumn14,
																												  this.dataGridTextBoxColumn30,
																												  this.dataGridTextBoxColumn15,
																												  this.dataGridTextBoxColumn16,
																												  this.dataGridTextBoxColumn31,
																												  this.dataGridTextBoxColumn17,
																												  this.dataGridTextBoxColumn18,
																												  this.dataGridTextBoxColumn32,
																												  this.dataGridTextBoxColumn19,
																												  this.dataGridTextBoxColumn20,
																												  this.dataGridTextBoxColumn9});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "";
			this.dataGridTableStyle2.ReadOnly = true;
			// 
			// dataGridTextBoxColumn34
			// 
			this.dataGridTextBoxColumn34.Format = "";
			this.dataGridTextBoxColumn34.FormatInfo = null;
			this.dataGridTextBoxColumn34.HeaderText = "cjid";
			this.dataGridTextBoxColumn34.MappingName = "";
			this.dataGridTextBoxColumn34.Width = 0;
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.HeaderText = "品名";
			this.dataGridTextBoxColumn10.MappingName = "品名";
			this.dataGridTextBoxColumn10.Width = 90;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "规格";
			this.dataGridTextBoxColumn11.MappingName = "规格";
			this.dataGridTextBoxColumn11.Width = 75;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.HeaderText = "单位";
			this.dataGridTextBoxColumn12.MappingName = "单位";
			this.dataGridTextBoxColumn12.Width = 30;
			// 
			// dataGridTextBoxColumn29
			// 
			this.dataGridTextBoxColumn29.Format = "";
			this.dataGridTextBoxColumn29.FormatInfo = null;
			this.dataGridTextBoxColumn29.HeaderText = "上期数量";
			this.dataGridTextBoxColumn29.MappingName = "";
			this.dataGridTextBoxColumn29.Width = 0;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "上期批发金额";
			this.dataGridTextBoxColumn13.MappingName = "";
			this.dataGridTextBoxColumn13.Width = 75;
			// 
			// dataGridTextBoxColumn14
			// 
			this.dataGridTextBoxColumn14.Format = "";
			this.dataGridTextBoxColumn14.FormatInfo = null;
			this.dataGridTextBoxColumn14.HeaderText = "上期零售金额";
			this.dataGridTextBoxColumn14.MappingName = "";
			this.dataGridTextBoxColumn14.Width = 75;
			// 
			// dataGridTextBoxColumn30
			// 
			this.dataGridTextBoxColumn30.Format = "";
			this.dataGridTextBoxColumn30.FormatInfo = null;
			this.dataGridTextBoxColumn30.HeaderText = "发生数量";
			this.dataGridTextBoxColumn30.MappingName = "";
			this.dataGridTextBoxColumn30.Width = 0;
			// 
			// dataGridTextBoxColumn15
			// 
			this.dataGridTextBoxColumn15.Format = "";
			this.dataGridTextBoxColumn15.FormatInfo = null;
			this.dataGridTextBoxColumn15.HeaderText = "发生批发金额";
			this.dataGridTextBoxColumn15.MappingName = "";
			this.dataGridTextBoxColumn15.Width = 75;
			// 
			// dataGridTextBoxColumn16
			// 
			this.dataGridTextBoxColumn16.Format = "";
			this.dataGridTextBoxColumn16.FormatInfo = null;
			this.dataGridTextBoxColumn16.HeaderText = "发生零售金额";
			this.dataGridTextBoxColumn16.MappingName = "";
			this.dataGridTextBoxColumn16.Width = 75;
			// 
			// dataGridTextBoxColumn31
			// 
			this.dataGridTextBoxColumn31.Format = "";
			this.dataGridTextBoxColumn31.FormatInfo = null;
			this.dataGridTextBoxColumn31.HeaderText = "库存数量";
			this.dataGridTextBoxColumn31.MappingName = "";
			this.dataGridTextBoxColumn31.Width = 0;
			// 
			// dataGridTextBoxColumn17
			// 
			this.dataGridTextBoxColumn17.Format = "";
			this.dataGridTextBoxColumn17.FormatInfo = null;
			this.dataGridTextBoxColumn17.HeaderText = "库存批发金额";
			this.dataGridTextBoxColumn17.MappingName = "";
			this.dataGridTextBoxColumn17.Width = 75;
			// 
			// dataGridTextBoxColumn18
			// 
			this.dataGridTextBoxColumn18.Format = "";
			this.dataGridTextBoxColumn18.FormatInfo = null;
			this.dataGridTextBoxColumn18.HeaderText = "库存零售金额";
			this.dataGridTextBoxColumn18.MappingName = "";
			this.dataGridTextBoxColumn18.Width = 75;
			// 
			// dataGridTextBoxColumn32
			// 
			this.dataGridTextBoxColumn32.Format = "";
			this.dataGridTextBoxColumn32.FormatInfo = null;
			this.dataGridTextBoxColumn32.HeaderText = "数量差值";
			this.dataGridTextBoxColumn32.MappingName = "";
			this.dataGridTextBoxColumn32.Width = 0;
			// 
			// dataGridTextBoxColumn19
			// 
			this.dataGridTextBoxColumn19.Format = "";
			this.dataGridTextBoxColumn19.FormatInfo = null;
			this.dataGridTextBoxColumn19.HeaderText = "批发金额差值";
			this.dataGridTextBoxColumn19.MappingName = "";
			this.dataGridTextBoxColumn19.Width = 75;
			// 
			// dataGridTextBoxColumn20
			// 
			this.dataGridTextBoxColumn20.Format = "";
			this.dataGridTextBoxColumn20.FormatInfo = null;
			this.dataGridTextBoxColumn20.HeaderText = "零售金额差值";
			this.dataGridTextBoxColumn20.MappingName = "";
			this.dataGridTextBoxColumn20.Width = 75;
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.HeaderText = "dwbl";
			this.dataGridTextBoxColumn9.MappingName = "";
			this.dataGridTextBoxColumn9.Width = 0;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 447);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.statusBarPanel2});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(714, 24);
			this.statusBar1.TabIndex = 1;
			this.statusBar1.Text = "statusBar1";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Width = 200;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Width = 200;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 391);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(714, 56);
			this.panel1.TabIndex = 2;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(480, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(112, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "退出(&Q)";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(360, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "数据入帐(&O)";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(714, 391);
			this.panel2.TabIndex = 3;
			// 
			// Frmxtdzmx
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(714, 471);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "Frmxtdzmx";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "系统对帐结果";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Frmxtdz_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void Frmxtdz_Load(object sender, System.EventArgs e)
		{
			//初始化
			DataTable Tb=new DataTable();
			Tb.TableName="Tb";
			for(int i=0;i<=this.myDataGrid1.TableStyles[0].GridColumnStyles.Count-1;i++) 
			{	
				if(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
					Tb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.Int16"));	
				else
					Tb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
				this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
				this.myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText="";
			}
			this.myDataGrid1.DataSource=Tb;
			this.myDataGrid1.TableStyles[0].MappingName ="Tb";

			//初始化
			DataTable Tb1=new DataTable();
			Tb1.TableName="Tb1";
			for(int i=0;i<=this.myDataGrid2.TableStyles[0].GridColumnStyles.Count-1;i++) 
			{	
				if(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
					Tb1.Columns.Add(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.Int16"));	
				else
					Tb1.Columns.Add(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
				this.myDataGrid2.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText;
				this.myDataGrid2.TableStyles[0].GridColumnStyles[i].NullText="";
			}
			this.myDataGrid2.DataSource=Tb1;
			this.myDataGrid2.TableStyles[0].MappingName ="Tb1";

			_ywlx="012";

		}

		public void FillData(DataTable tb)
		{
				

			DataTable Tb=(DataTable)this.myDataGrid1.DataSource;
			Tb.TableName="Tb";
			DataRow[] row=tb.Select("数量差值<> 0");
			for(int i=0;i<=row.Length-1;i++)
			{
				Tb.Rows.Add(row[i].ItemArray);
			}
			myDataGrid1.DataSource=Tb;

			DataTable Tb1=(DataTable)this.myDataGrid2.DataSource;
			Tb1.TableName="Tb1";
			DataRow[] row1=tb.Select("批发金额差值<> 0 or 零售金额差值<>0 ");
			for(int i=0;i<=row1.Length-1;i++)
			{
				Tb1.Rows.Add(row1[i].ItemArray);
			}
			myDataGrid2.DataSource=Tb1;

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			DataTable tbsl=(DataTable)this.myDataGrid1.DataSource;
			if (tbsl.Rows.Count>0){MessageBox.Show("当有数量误差时不能作账务调整，必须先解决数量误差，请和管理员联系!");return;}
			DataTable tbje=(DataTable)this.myDataGrid2.DataSource;
			if (tbje.Rows.Count==0) {MessageBox.Show("没有需要作调整的数据");return;}

			if(MessageBox.Show("您确定要将金额误差数据作账务处理行吗 ？","询问窗",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
			{
				return;
			}

			decimal sumlsje=0;
			decimal sumpfje=0;
			for (int i=0;i<=tbje.Rows.Count-1;i++)
			{
				sumlsje=sumlsje+Convert.ToDecimal(tbje.Rows[i]["零售金额差值"]);
				sumpfje=sumpfje+Convert.ToDecimal(tbje.Rows[i]["批发金额差值"]);
			}

			if (sumlsje>=100 || sumpfje>=100)
			{
				MessageBox.Show("调整金额太大了，系统数据可能存在问题！请和管理员联系");
				return;
			}


			long djh=0;       //单据号
			long djid=0;	  //主表ID
			int err_code=0;   //错误号
			string err_text="";//借误文本
			string sDate=XcDate.ServerDateTime.ToString();//登记时间
			this.button1.Enabled=false;

			OleDbTransaction myTrans;
			myTrans =DB.sConnect.BeginTransaction();

			try
			{
				System.Data.OleDb.OleDbCommand  cmd=new System.Data.OleDb.OleDbCommand();
				cmd.Connection=DB.sConnect;
				cmd.Transaction=myTrans;


				//产生单据号
				djh=BaseFun.SeekNewDjh(_ywlx.Trim(),_deptID,cmd);
				
				//保存单据表头
				YK_DJ_DJMX.SaveDJ(0, 
					djh,
					_deptID,
					_ywlx.Trim(),
					0,
					Convert.ToInt32(_deptID),
					0,
					Convert.ToDateTime(sDate).ToShortDateString(),
					_employeeID,
					Convert.ToDateTime(sDate).ToShortDateString(),
					Convert.ToDateTime(sDate).ToLongTimeString(),
					"",
					"",
					"",
					"",
					0,
					0,
					0,
					sumpfje,
					sumlsje,
					out djid,out err_code,out err_text,cmd);
				if (err_code!=0){throw new System.Exception(err_text);}

				//保存单据明细
				DataTable tb=(DataTable)this.myDataGrid2.DataSource;
				
				if (tb.Rows.Count==0) {MessageBox.Show("没有可保存的记录");return;};
				cmd.Parameters.Clear();
				
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					YK_DJ_DJMX.SaveDJMX(0,
						djid,
						Convert.ToInt32(tb.Rows[i]["cjid"]),
						0,
						"",
						"",
						0,
						0,
						0,
						Convert.ToString(tb.Rows[i]["单位"]),
						BaseFun.SeekYpdw(Convert.ToString(tb.Rows[i]["单位"])),
						Convert.ToInt32(tb.Rows[i]["dwbl"]),
						0,
						0,
						0,
						0,
						Convert.ToDecimal(tb.Rows[i]["批发金额差值"])*(-1),
						Convert.ToDecimal(tb.Rows[i]["零售金额差值"])*(-1),
						djh,
						_deptID,
						_ywlx.Trim(),
						"",
						"",
						out err_code,out err_text,cmd);
					cmd.Parameters.Clear();
					if (err_code!=0){throw new System.Exception(err_text);}
				}


				//审核单据
				YK_DJ_DJMX.Shdj(djh,
						_deptID,
						_employeeID,
						sDate,
						_ywlx.Trim(),
						cmd);


				//提交事务
				myTrans.Commit();
				DB.Colse();

				MessageBox.Show(err_text);

			}
			catch(System.Exception err)
			{
				myTrans.Rollback();
				DB.Colse();
				this.button1.Enabled=true;
				MessageBox.Show(err.Message+err.Source);
				
			}


		}
	}
}
