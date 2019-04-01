using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_gzrzbb
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class FrmGZRZ : System.Windows.Forms.Form
	{
		private DataTable dtPat;
		private bool IsSaveTable = false;//日志是否已保存

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private LabelEx LabelEx1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private DataGridEx DGrid_GZRZ;
		private System.Windows.Forms.Button bt_query;
		private System.Windows.Forms.Button bt_print;
		private System.Windows.Forms.Button bt_save;
		private System.Windows.Forms.DateTimePicker dTimeP_Date;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private DataGridEx DGrid_Out;
		private DataGridEx DGrid_In;
		private DataGridEx DGrid_SW;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn37;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label23;
        private DataGridTextBoxColumn dataGridTextBoxColumn39;
        private DataGridTextBoxColumn dataGridTextBoxColumn40;
        private DataGridTextBoxColumn dataGridTextBoxColumn41;
        private DataGridTextBoxColumn dataGridTextBoxColumn42;
		private System.ComponentModel.IContainer components;

		public FrmGZRZ(string _formText)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			this.Text=_formText;
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "风格风格",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "88",
            "9",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("封建割据");
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_query = new System.Windows.Forms.Button();
            this.dTimeP_Date = new System.Windows.Forms.DateTimePicker();
            this.bt_print = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.DGrid_Out = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.DGrid_In = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGrid_SW = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DGrid_GZRZ = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.LabelEx1 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid_Out)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid_In)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid_SW)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid_GZRZ)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bt_query);
            this.panel1.Controls.Add(this.dTimeP_Date);
            this.panel1.Controls.Add(this.bt_print);
            this.panel1.Controls.Add(this.bt_save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 41);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "选择日期";
            // 
            // bt_query
            // 
            this.bt_query.BackColor = System.Drawing.Color.Turquoise;
            this.bt_query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_query.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_query.Location = new System.Drawing.Point(216, 10);
            this.bt_query.Name = "bt_query";
            this.bt_query.Size = new System.Drawing.Size(75, 23);
            this.bt_query.TabIndex = 3;
            this.bt_query.Text = "查询(&Q)";
            this.bt_query.UseVisualStyleBackColor = false;
            this.bt_query.Click += new System.EventHandler(this.bt_query_Click);
            // 
            // dTimeP_Date
            // 
            this.dTimeP_Date.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dTimeP_Date.Location = new System.Drawing.Point(88, 9);
            this.dTimeP_Date.Name = "dTimeP_Date";
            this.dTimeP_Date.Size = new System.Drawing.Size(120, 24);
            this.dTimeP_Date.TabIndex = 2;
            // 
            // bt_print
            // 
            this.bt_print.BackColor = System.Drawing.Color.Turquoise;
            this.bt_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_print.Location = new System.Drawing.Point(584, 11);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(75, 23);
            this.bt_print.TabIndex = 1;
            this.bt_print.Text = "打印(&P)";
            this.bt_print.UseVisualStyleBackColor = false;
            this.bt_print.Visible = false;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // bt_save
            // 
            this.bt_save.BackColor = System.Drawing.Color.Turquoise;
            this.bt_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_save.Location = new System.Drawing.Point(488, 11);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 0;
            this.bt_save.Text = "保存(&S)";
            this.bt_save.UseVisualStyleBackColor = false;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 471);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(863, 22);
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "      注：表内人数从每天零时零分起至晚上十二时止";
            this.statusBarPanel1.Width = 300;
            // 
            // DGrid_Out
            // 
            this.DGrid_Out.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGrid_Out.CaptionBackColor = System.Drawing.Color.Turquoise;
            this.DGrid_Out.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.DGrid_Out.CaptionText = "  出院病人";
            this.DGrid_Out.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.DGrid_Out.DataMember = "";
            this.DGrid_Out.Dock = System.Windows.Forms.DockStyle.Left;
            this.DGrid_Out.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGrid_Out.Location = new System.Drawing.Point(259, 0);
            this.DGrid_Out.Name = "DGrid_Out";
            this.DGrid_Out.ReadOnly = true;
            this.DGrid_Out.RowHeaderWidth = 0;
            this.DGrid_Out.Size = new System.Drawing.Size(260, 184);
            this.DGrid_Out.TabIndex = 2;
            this.DGrid_Out.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.DGrid_Out;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn30});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "姓 名";
            this.dataGridTextBoxColumn3.MappingName = "姓名";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 60;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "住院号";
            this.dataGridTextBoxColumn4.MappingName = "住院号";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 50;
            // 
            // dataGridTextBoxColumn37
            // 
            this.dataGridTextBoxColumn37.Format = "";
            this.dataGridTextBoxColumn37.FormatInfo = null;
            this.dataGridTextBoxColumn37.HeaderText = "科别";
            this.dataGridTextBoxColumn37.MappingName = "科别";
            this.dataGridTextBoxColumn37.NullText = "";
            this.dataGridTextBoxColumn37.Width = 75;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "床号";
            this.dataGridTextBoxColumn28.MappingName = "床号";
            this.dataGridTextBoxColumn28.NullText = "";
            this.dataGridTextBoxColumn28.Width = 40;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "诊断";
            this.dataGridTextBoxColumn29.MappingName = "诊断";
            this.dataGridTextBoxColumn29.NullText = "";
            this.dataGridTextBoxColumn29.Width = 120;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "时间";
            this.dataGridTextBoxColumn30.MappingName = "时间";
            this.dataGridTextBoxColumn30.NullText = "";
            this.dataGridTextBoxColumn30.Width = 75;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(256, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 184);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // DGrid_In
            // 
            this.DGrid_In.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGrid_In.CaptionBackColor = System.Drawing.Color.Turquoise;
            this.DGrid_In.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.DGrid_In.CaptionText = "  入院病人";
            this.DGrid_In.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.DGrid_In.DataMember = "";
            this.DGrid_In.Dock = System.Windows.Forms.DockStyle.Left;
            this.DGrid_In.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGrid_In.Location = new System.Drawing.Point(0, 0);
            this.DGrid_In.Name = "DGrid_In";
            this.DGrid_In.ReadOnly = true;
            this.DGrid_In.RowHeaderWidth = 0;
            this.DGrid_In.Size = new System.Drawing.Size(256, 184);
            this.DGrid_In.TabIndex = 0;
            this.DGrid_In.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.DGrid_In;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn36,
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn27});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "姓 名";
            this.dataGridTextBoxColumn1.MappingName = "姓名";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 60;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "住院号";
            this.dataGridTextBoxColumn2.MappingName = "住院号";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 50;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "科别";
            this.dataGridTextBoxColumn36.MappingName = "科别";
            this.dataGridTextBoxColumn36.NullText = "";
            this.dataGridTextBoxColumn36.Width = 75;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "床号";
            this.dataGridTextBoxColumn25.MappingName = "床号";
            this.dataGridTextBoxColumn25.NullText = "";
            this.dataGridTextBoxColumn25.Width = 40;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "诊断";
            this.dataGridTextBoxColumn26.MappingName = "诊断";
            this.dataGridTextBoxColumn26.NullText = "";
            this.dataGridTextBoxColumn26.Width = 120;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "时间";
            this.dataGridTextBoxColumn27.MappingName = "时间";
            this.dataGridTextBoxColumn27.NullText = "";
            this.dataGridTextBoxColumn27.Width = 75;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGrid_SW);
            this.panel2.Controls.Add(this.splitter3);
            this.panel2.Controls.Add(this.DGrid_Out);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.DGrid_In);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 287);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 184);
            this.panel2.TabIndex = 4;
            // 
            // DGrid_SW
            // 
            this.DGrid_SW.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGrid_SW.CaptionBackColor = System.Drawing.Color.Turquoise;
            this.DGrid_SW.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.DGrid_SW.CaptionText = "  病亡人";
            this.DGrid_SW.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.DGrid_SW.DataMember = "";
            this.DGrid_SW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGrid_SW.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGrid_SW.Location = new System.Drawing.Point(522, 0);
            this.DGrid_SW.Name = "DGrid_SW";
            this.DGrid_SW.ReadOnly = true;
            this.DGrid_SW.Size = new System.Drawing.Size(341, 184);
            this.DGrid_SW.TabIndex = 5;
            this.DGrid_SW.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle4});
            // 
            // dataGridTableStyle4
            // 
            this.dataGridTableStyle4.DataGrid = this.DGrid_SW;
            this.dataGridTableStyle4.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn31,
            this.dataGridTextBoxColumn32,
            this.dataGridTextBoxColumn38,
            this.dataGridTextBoxColumn33,
            this.dataGridTextBoxColumn34,
            this.dataGridTextBoxColumn35});
            this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "姓名";
            this.dataGridTextBoxColumn31.MappingName = "姓名";
            this.dataGridTextBoxColumn31.NullText = "";
            this.dataGridTextBoxColumn31.Width = 60;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "住院号";
            this.dataGridTextBoxColumn32.MappingName = "住院号";
            this.dataGridTextBoxColumn32.NullText = "";
            this.dataGridTextBoxColumn32.Width = 50;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "科别";
            this.dataGridTextBoxColumn38.MappingName = "科别";
            this.dataGridTextBoxColumn38.NullText = "";
            this.dataGridTextBoxColumn38.Width = 75;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "床号";
            this.dataGridTextBoxColumn33.MappingName = "床号";
            this.dataGridTextBoxColumn33.NullText = "";
            this.dataGridTextBoxColumn33.Width = 40;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Format = "";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "诊断";
            this.dataGridTextBoxColumn34.MappingName = "诊断";
            this.dataGridTextBoxColumn34.NullText = "";
            this.dataGridTextBoxColumn34.Width = 120;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "时间";
            this.dataGridTextBoxColumn35.MappingName = "时间";
            this.dataGridTextBoxColumn35.NullText = "";
            this.dataGridTextBoxColumn35.Width = 75;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(519, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 184);
            this.splitter3.TabIndex = 4;
            this.splitter3.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 284);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(863, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(863, 220);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.DGrid_GZRZ);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.listView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(860, 220);
            this.panel4.TabIndex = 7;
            // 
            // DGrid_GZRZ
            // 
            this.DGrid_GZRZ.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGrid_GZRZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGrid_GZRZ.CaptionFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.DGrid_GZRZ.CaptionVisible = false;
            this.DGrid_GZRZ.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.DGrid_GZRZ.ColumnHeadersVisible = false;
            this.DGrid_GZRZ.DataMember = "";
            this.DGrid_GZRZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGrid_GZRZ.GridLineColor = System.Drawing.SystemColors.ControlDark;
            this.DGrid_GZRZ.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGrid_GZRZ.Location = new System.Drawing.Point(0, 88);
            this.DGrid_GZRZ.Name = "DGrid_GZRZ";
            this.DGrid_GZRZ.ParentRowsVisible = false;
            this.DGrid_GZRZ.PreferredRowHeight = 20;
            this.DGrid_GZRZ.RowHeadersVisible = false;
            this.DGrid_GZRZ.Size = new System.Drawing.Size(860, 132);
            this.DGrid_GZRZ.TabIndex = 3;
            this.DGrid_GZRZ.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.DGrid_GZRZ.myKeyDown += new TrasenClasses.GeneralControls.myDelegate(this.DGrid_GZRZ_myKeyDown);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.ColumnHeadersVisible = false;
            this.dataGridTableStyle3.DataGrid = this.DGrid_GZRZ;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn39,
            this.dataGridTextBoxColumn40,
            this.dataGridTextBoxColumn41,
            this.dataGridTextBoxColumn42});
            this.dataGridTableStyle3.GridLineColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridTableStyle3.HeaderFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.PreferredRowHeight = 20;
            this.dataGridTableStyle3.RowHeadersVisible = false;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "deptname";
            this.dataGridTextBoxColumn5.MappingName = "deptname";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 104;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "YY";
            this.dataGridTextBoxColumn6.MappingName = "YY";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 32;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "IN";
            this.dataGridTextBoxColumn7.MappingName = "IN";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 32;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "TRANSIN";
            this.dataGridTextBoxColumn8.MappingName = "TRANSIN";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 32;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "TRANSOUT";
            this.dataGridTextBoxColumn9.MappingName = "TRANSOUT";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 32;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.Width = 32;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "OUTALL";
            this.dataGridTextBoxColumn11.MappingName = "OUTALL";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 32;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "OUTZY";
            this.dataGridTextBoxColumn12.MappingName = "OUTZY";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.Width = 32;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "OUTHZ";
            this.dataGridTextBoxColumn13.MappingName = "OUTHZ";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 32;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "OUTWY";
            this.dataGridTextBoxColumn14.MappingName = "OUTWY";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 32;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "OUTSW";
            this.dataGridTextBoxColumn15.MappingName = "OUTSW";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 32;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "OPER_L";
            this.dataGridTextBoxColumn16.MappingName = "OPER_L";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.Width = 32;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "OPER_M";
            this.dataGridTextBoxColumn17.MappingName = "OPER_M";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.Width = 32;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "OPER_S";
            this.dataGridTextBoxColumn18.MappingName = "OPER_S";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.Width = 32;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "YBRS";
            this.dataGridTextBoxColumn19.MappingName = "YBRS";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.Width = 32;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "YJHL";
            this.dataGridTextBoxColumn20.MappingName = "YJHL";
            this.dataGridTextBoxColumn20.NullText = "";
            this.dataGridTextBoxColumn20.Width = 32;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "BW";
            this.dataGridTextBoxColumn21.MappingName = "BW";
            this.dataGridTextBoxColumn21.NullText = "";
            this.dataGridTextBoxColumn21.Width = 32;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "BWQJ";
            this.dataGridTextBoxColumn22.MappingName = "BWQJ";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.Width = 32;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "PH";
            this.dataGridTextBoxColumn23.MappingName = "PH";
            this.dataGridTextBoxColumn23.NullText = "";
            this.dataGridTextBoxColumn23.Width = 32;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "NOW";
            this.dataGridTextBoxColumn24.MappingName = "NOW";
            this.dataGridTextBoxColumn24.NullText = "";
            this.dataGridTextBoxColumn24.Width = 80;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.HeaderText = "djrs";
            this.dataGridTextBoxColumn39.MappingName = "djrs";
            this.dataGridTextBoxColumn39.NullText = "(";
            this.dataGridTextBoxColumn39.Width = 32;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.HeaderText = "bzrs";
            this.dataGridTextBoxColumn40.MappingName = "bzrs";
            this.dataGridTextBoxColumn40.NullText = "";
            this.dataGridTextBoxColumn40.Width = 32;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.HeaderText = "syrs";
            this.dataGridTextBoxColumn41.MappingName = "syrs";
            this.dataGridTextBoxColumn41.NullText = "";
            this.dataGridTextBoxColumn41.Width = 32;
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn42.Format = "";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.HeaderText = "lgrs";
            this.dataGridTextBoxColumn42.MappingName = "lgrs";
            this.dataGridTextBoxColumn42.NullText = "";
            this.dataGridTextBoxColumn42.Width = 32;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Controls.Add(this.label26);
            this.panel5.Controls.Add(this.label25);
            this.panel5.Controls.Add(this.label24);
            this.panel5.Controls.Add(this.label23);
            this.panel5.Controls.Add(this.label22);
            this.panel5.Controls.Add(this.label21);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(860, 88);
            this.panel5.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.SystemColors.Window;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(824, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 88);
            this.label26.TabIndex = 15;
            this.label26.Text = "留观人数";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.Window;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(792, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(32, 88);
            this.label25.TabIndex = 14;
            this.label25.Text = "输液人数";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.Window;
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(760, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(32, 88);
            this.label24.TabIndex = 13;
            this.label24.Text = "病重人数";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.Window;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(728, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 88);
            this.label23.TabIndex = 12;
            this.label23.Text = "单间人数";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.Window;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(648, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 88);
            this.label22.TabIndex = 12;
            this.label22.Text = "本日住院人数";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.Window;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Dock = System.Windows.Forms.DockStyle.Left;
            this.label21.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(616, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 88);
            this.label21.TabIndex = 11;
            this.label21.Text = "陪人人数";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.Window;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.label20.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(584, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 88);
            this.label20.TabIndex = 10;
            this.label20.Text = "病危抢救";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.Window;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Dock = System.Windows.Forms.DockStyle.Left;
            this.label19.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(552, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 88);
            this.label19.TabIndex = 9;
            this.label19.Text = "病危人数";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.Window;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(520, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 88);
            this.label14.TabIndex = 8;
            this.label14.Text = "一级护理数";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Window;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(488, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 88);
            this.label13.TabIndex = 7;
            this.label13.Text = "医保人数";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Controls.Add(this.label17);
            this.panel7.Controls.Add(this.label18);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(392, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(96, 88);
            this.panel7.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.Window;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(64, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 56);
            this.label15.TabIndex = 7;
            this.label15.Text = "小";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.Window;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(32, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 56);
            this.label16.TabIndex = 6;
            this.label16.Text = "中";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Window;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(0, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 56);
            this.label17.TabIndex = 5;
            this.label17.Text = "大";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 32);
            this.label18.TabIndex = 0;
            this.label18.Text = "手 术";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(232, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(160, 88);
            this.panel6.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Window;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(128, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 56);
            this.label12.TabIndex = 9;
            this.label12.Text = "死亡";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Window;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(96, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 56);
            this.label11.TabIndex = 8;
            this.label11.Text = "未愈";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Window;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(64, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 56);
            this.label10.TabIndex = 7;
            this.label10.Text = "好转";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Window;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(32, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 56);
            this.label9.TabIndex = 6;
            this.label9.Text = "痊愈";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(0, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 56);
            this.label8.TabIndex = 5;
            this.label8.Text = "计";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "出 院 时 情 况";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(200, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 88);
            this.label6.TabIndex = 4;
            this.label6.Text = "转往他科";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(168, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 88);
            this.label5.TabIndex = 3;
            this.label5.Text = "他科转入";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(136, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 88);
            this.label4.TabIndex = 2;
            this.label4.Text = "新收人数";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(104, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 88);
            this.label3.TabIndex = 1;
            this.label3.Text = "原有人数";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 88);
            this.label2.TabIndex = 0;
            this.label2.Text = "科  别";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
            this.listView1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem1.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(480, 120);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.Size = new System.Drawing.Size(248, 56);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 102;
            // 
            // columnHeader2
            // 
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 32;
            // 
            // columnHeader3
            // 
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 32;
            // 
            // columnHeader4
            // 
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 32;
            // 
            // columnHeader5
            // 
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 32;
            // 
            // columnHeader6
            // 
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 32;
            // 
            // columnHeader7
            // 
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 32;
            // 
            // columnHeader8
            // 
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 32;
            // 
            // columnHeader9
            // 
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 32;
            // 
            // columnHeader10
            // 
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 32;
            // 
            // columnHeader11
            // 
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 32;
            // 
            // columnHeader12
            // 
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader12.Width = 32;
            // 
            // columnHeader13
            // 
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 32;
            // 
            // columnHeader14
            // 
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 32;
            // 
            // columnHeader15
            // 
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader15.Width = 32;
            // 
            // columnHeader16
            // 
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader16.Width = 32;
            // 
            // columnHeader17
            // 
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader17.Width = 32;
            // 
            // columnHeader18
            // 
            this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader18.Width = 32;
            // 
            // LabelEx1
            // 
            this.LabelEx1.BackColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.LabelEx1.BackColor2 = System.Drawing.Color.AliceBlue;
            this.LabelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelEx1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelEx1.ForeColor = System.Drawing.SystemColors.Window;
            this.LabelEx1.Location = new System.Drawing.Point(0, 0);
            this.LabelEx1.Name = "LabelEx1";
            this.LabelEx1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelEx1.Size = new System.Drawing.Size(863, 23);
            this.LabelEx1.TabIndex = 5;
            this.LabelEx1.Text = "住院病人日报表";
            this.LabelEx1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmGZRZ
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(863, 493);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LabelEx1);
            this.Name = "FrmGZRZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病区住院病人日报表";
            this.Load += new System.EventHandler(this.FrmGZRZ_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid_Out)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid_In)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid_SW)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid_GZRZ)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region 方法
		/// <summary>
		/// 工作日志
		/// </summary>
		/// <param name="wardID"></param>
		/// <param name="dtime"></param>
		/// <returns></returns>
		private DataTable GetGZRZ(string wardID,DateTime dtime)
		{
			//ZY_WARDRBB中有记录的先取，没记录取ZY_WARDGZRZ
			DataTable dt = new DataTable();
			string sql = "select ' '+c.name deptname,a.* "+
				"from ZY_WARDRBB a "+ 
				"     inner join jc_WARDRDEPT b on a.dept_id = b.dept_id and ward_id='"+wardID+"' "+ 
				"     left join  jc_dept_property c on b.dept_id = c.dept_id "+
				"where a.book_date = '"+dtime.Date+"' and isnull(del,0)=0 order by c.dept_id ";
			dt = InstanceForm.BDatabase.GetDataTable(sql);
			IsSaveTable = true;
			if(dt.Rows.Count==0)
			{
                //Modify by zouchihua 增加了单间人数，病重人数，输液人数，留观人数
                sql = "select ' '+c.name deptname,a.*,'' oper_l,'' oper_m,'' oper_s,'' BWQJ, '' djrs,'' bzrs,'' syrs,'' lgrs   " +
					"from ZY_WARDGZRZ a "+ 
					"     inner join jc_WARDRDEPT b on a.dept_id = b.dept_id and ward_id='"+wardID+"' "+ 
					"     left join  jc_dept_property c on b.dept_id = c.dept_id "+
					"where a.book_date = '"+dtime.Date+"' order by c.dept_id ";
			    dt = InstanceForm.BDatabase.GetDataTable(sql);
				IsSaveTable = false;
			}
			return dt;
		}
		/// <summary>
		/// 入院病人
		/// </summary>
		/// <param name="wardID"></param>
		/// <param name="dtime"></param>
		/// <returns></returns>
		private DataTable GetInPat(string wardID,DateTime dtime)
		{
			string sql = "select in_dept,inpatient_no 住院号,dbo.fun_zy_GETBEDNO(bed_id) 床号,name 姓名,in_diagnosis 诊断,convert(varchar,in_date,108) 时间 "+
				         "from vi_zy_vinpatient "+
	                     "where in_date between '"+dtime.Date+"' and '"+dtime.Date.AddDays(1)+"' and flag not in (1,10) "+
      	                 "      and in_dept in (select dept_id from jc_wardrdept where (ward_id='"+wardID+"')) ";
			return InstanceForm.BDatabase.GetDataTable(sql);
		}
		/// <summary>
		/// 出院病人
		/// </summary>
		/// <param name="wardID"></param>
		/// <param name="dtime"></param>
		/// <returns></returns>
		private DataTable GetOutPat(string wardID,DateTime dtime)
		{
            string sql = "select dept_id,inpatient_no 住院号,dbo.fun_zy_GETBEDNO(bed_id) 床号,name 姓名,out_diagnosis 诊断,convert(varchar,out_date,108) 时间 " +
                         "from vi_zy_vinpatient "+
	                     "where out_mode<>4 and flag in (2,4,5,6) and out_date between '"+dtime.Date+"' and '"+dtime.Date.AddDays(1)+"' "+
      	                 "      and dept_id in (select dept_id from jc_wardrdept where (ward_id='"+wardID+"')) ";
			return InstanceForm.BDatabase.GetDataTable(sql);
		}
		/// <summary>
		/// 死亡病人
		/// </summary>
		/// <param name="wardID"></param>
		/// <param name="dtime"></param>
		/// <returns></returns>
		private DataTable GetSW(string wardID,DateTime dtime)
		{
            string sql = "select dept_id,inpatient_no 住院号,dbo.fun_zy_GETBEDNO(bed_id) 床号,name 姓名,out_diagnosis 诊断,convert(varchar,out_date,108) 时间 " +
				         "from vi_zy_vinpatient "+
	                     "where out_mode=4 and flag in (2,4,5,6) and out_date between '"+dtime.Date+"' and '"+dtime.Date.AddDays(1)+"' "+
      	                 "      and dept_id in (select dept_id from jc_wardrdept where (ward_id='"+wardID+"')) ";
			return InstanceForm.BDatabase.GetDataTable(sql);
		}
		/// <summary>
		///  入院、出院、死亡病人
		/// </summary>
		/// <param name="wardID"></param>
		/// <param name="dtime"></param>
		/// <returns></returns>
		private DataTable GetPat(string wardID,DateTime dtime)
		{
			string sql = "select b.name 科别,a.* "+
                        " from (select in_dept dept_id,inpatient_no 住院号,dbo.fun_zy_GETBEDNO(bed_id) 床号,name 姓名,in_diagnosis 诊断,convert(varchar,in_date,108) 时间,4 type  " +
						"from vi_zy_vinpatient "+
						"where in_date between '"+dtime.Date+"' and '"+dtime.Date.AddDays(1).AddSeconds(-1)+"' and flag not in (1,10) "+
						"      and in_dept in (select dept_id from jc_wardrdept where (ward_id='"+wardID+"')) "+
						"union all "+
                        "select dept_id,inpatient_no 住院号,dbo.fun_zy_GETBEDNO(bed_id) 床号,name 姓名,out_diagnosis 诊断,convert(varchar,out_date,108) 时间,1 type " +
						"from vi_zy_vinpatient "+
						"where out_mode<>4 and flag in (2,4,5,6) and out_date between '"+dtime.Date+"' and '"+dtime.Date.AddDays(1).AddSeconds(-1)+"' "+
						"      and dept_id in (select dept_id from jc_wardrdept where (ward_id='"+wardID+"')) "+
						"union all "+
                        "select dept_id,inpatient_no 住院号,dbo.fun_zy_GETBEDNO(bed_id) 床号,name 姓名,out_diagnosis 诊断,convert(varchar,out_date,108) 时间,3 type " +
						"from vi_zy_vinpatient "+
						"where out_mode=4 and flag in (2,4,5,6) and out_date between '"+dtime.Date+"' and '"+dtime.Date.AddDays(1).AddSeconds(-1)+"' "+
						"      and dept_id in (select dept_id from jc_wardrdept where (ward_id='"+wardID+"'))) a "+
				         "    left join jc_dept_property b on a.dept_id = b.dept_id ";
			return InstanceForm.BDatabase.GetDataTable(sql);
		}
		/// <summary>
		/// 获取相关病人
		/// </summary>
		/// <param name="dt"></param>
		/// <param name="type">1=出院病人，4=入院病人，3=死亡病人</param>
		/// <returns></returns>
		private DataTable DataRowToDataTable(DataTable dt,int type)
		{
			DataTable tmpdt = dt.Clone();
			DataRow[] drlist = dt.Select("type="+type.ToString(),"科别");
			foreach(DataRow dr in drlist)
			{
				tmpdt.Rows.Add(dr.ItemArray);
			}
			return tmpdt;
		}
		//数据验证
		private int Validate(DataRow dr)
		{
			int YY = Convert.ToInt32(Convertor.IsNull(dr["YY"],"0"));
			int IN = Convert.ToInt32(Convertor.IsNull(dr["IN"],"0"));
			int OUT = Convert.ToInt32(Convertor.IsNull(dr["OUTALL"],"0"));
			int OUTZY = Convert.ToInt32(Convertor.IsNull(dr["OUTZY"],"0"));
			int OUTHZ = Convert.ToInt32(Convertor.IsNull(dr["OUTHZ"],"0"));
			int OUTWY = Convert.ToInt32(Convertor.IsNull(dr["OUTWY"],"0"));
			int OUTSW = Convert.ToInt32(Convertor.IsNull(dr["OUTSW"],"0"));
			int TRANSIN = Convert.ToInt32(Convertor.IsNull(dr["TRANSIN"],"0"));
			int TRANSOUT = Convert.ToInt32(Convertor.IsNull(dr["TRANSOUT"],"0"));
			int NOW = Convert.ToInt32(Convertor.IsNull(dr["NOW"],"0"));

			if( OUT != OUTZY + OUTHZ + OUTWY + OUTSW ) 
			{
				MessageBox.Show("出院合计错误！请检查。","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return 6 ;//OUTALL
			}
			if( NOW != YY + IN + TRANSIN - OUT - TRANSOUT)
			{
				MessageBox.Show("本日住院人数计算错误！请检查数据。","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return 19;//NOW
			}
			return -1;
		}
		// 定位网格焦点
		private void FocusCell(DataGridEx myDataGrid1,int nrow,int ncol)
		{
			myDataGrid1.Focus();
			DataGridCell myCell=new DataGridCell(nrow,ncol);
			myDataGrid1.CurrentCell=myCell ;	
			DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
			txtCol.TextBox.BackColor=System.Drawing.Color.SkyBlue ;		
		}

		private void CountRC(DataTable myTb,int nrow)
		{
			if(myTb.Rows.Count>nrow)
			{
				int YY = Convert.ToInt32(Convertor.IsNull(myTb.Rows[nrow]["YY"],"0"));
				int IN = Convert.ToInt32(Convertor.IsNull(myTb.Rows[nrow]["IN"],"0"));
				int OUT = Convert.ToInt32(Convertor.IsNull(myTb.Rows[nrow]["OUTALL"],"0"));
				int TRANSIN = Convert.ToInt32(Convertor.IsNull(myTb.Rows[nrow]["TRANSIN"],"0"));
				int TRANSOUT = Convert.ToInt32(Convertor.IsNull(myTb.Rows[nrow]["TRANSOUT"],"0"));
				myTb.Rows[nrow]["NOW"] = YY + IN + TRANSIN - OUT - TRANSOUT;
			}
		}
		
		#endregion

		#region 事件
		//控制DataGrid键盘事件
		private bool DGrid_GZRZ_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
			long keyInt=Convert.ToInt32(keyData);

			DataTable myTb=(DataTable)DGrid_GZRZ.DataSource;
			int nrow= DGrid_GZRZ.CurrentCell.RowNumber;
			int ncol= DGrid_GZRZ.CurrentCell.ColumnNumber;
			string ColumnName= DGrid_GZRZ.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();

			if(keyInt==9 || keyInt==37 || keyInt==39 ||(keyInt==38)||(keyInt==40))return false;
			if(keyInt==13 )
			{
				//得到输入的数据
				DataGridTextBoxColumn txtCol=(DataGridTextBoxColumn)this.DGrid_GZRZ.TableStyles[0].GridColumnStyles[ncol];
				string SelData=txtCol.TextBox.Text;
				
				switch(ColumnName)
				{
					case "YY":
						if(SelData=="")
						{
							myTb.Rows[nrow]["YY"] = System.DBNull.Value;
						}
						else
						{
							myTb.Rows[nrow]["YY"] = SelData;
						}
						CountRC(myTb,nrow);
						break;
					case "IN":
						if(SelData=="")
						{
							myTb.Rows[nrow]["IN"] = System.DBNull.Value;
						}
						else
						{
							myTb.Rows[nrow]["IN"] = SelData;
						}
						CountRC(myTb,nrow);
						break;
					case "OUTALL":
						if(SelData=="")
						{
							myTb.Rows[nrow]["OUTALL"] = System.DBNull.Value;
						}
						else
						{
							myTb.Rows[nrow]["OUTALL"] = SelData;
						}
						CountRC(myTb,nrow);
						break;
					case "TRANSIN":
						if(SelData=="")
						{
							myTb.Rows[nrow]["TRANSIN"] = System.DBNull.Value;
						}
						else
						{
							myTb.Rows[nrow]["TRANSIN"] = SelData;
						}
						CountRC(myTb,nrow);
						break;
					case "TRANSOUT":
						if(SelData=="")
						{
							myTb.Rows[nrow]["TRANSOUT"] = System.DBNull.Value;
						}
						else
						{
							myTb.Rows[nrow]["TRANSOUT"] = SelData;
						}
						CountRC(myTb,nrow);
						break;
					case "NOW":
						SendKeys.Send("{tab}"); //跳格	
						break;
					default:
						break;
				}
				SendKeys.Send("{tab}"); //跳格			
				return true;
			}
			if(nrow>=myTb.Rows.Count) return true;

			if((keyInt>=48 && keyInt<=57)  || (keyInt>=96 && keyInt<=105) || keyInt==8)
			{
				return false;
			}
			return true;			
		}

		//查询
		private void bt_query_Click(object sender, System.EventArgs e)
		{
			this.Cursor = PubStaticFun.WaitCursor();
			try
			{
				this.DGrid_GZRZ.DataSource = GetGZRZ(InstanceForm.BCurrentDept.WardId,dTimeP_Date.Value);
				dtPat = GetPat(InstanceForm.BCurrentDept.WardId,dTimeP_Date.Value);
			
				this.DGrid_In.DataSource = DataRowToDataTable(dtPat,4);
				this.DGrid_Out.DataSource = DataRowToDataTable(dtPat,1);
				this.DGrid_SW.DataSource = DataRowToDataTable(dtPat,3);
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString());
			}
			finally
			{
				this.Cursor = Cursors.Arrow;
			}

		}

		//load事件
		private void FrmGZRZ_Load(object sender, System.EventArgs e)
		{
			this.LabelEx1.Text=InstanceForm.BCurrentDept.WardName+this.LabelEx1.Text;	
			this.dTimeP_Date.MaxDate= DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Date;
		}

		//保存
		private void bt_save_Click(object sender, System.EventArgs e)
		{
			this.Cursor = PubStaticFun.WaitCursor();
			try
			{
				DataTable dt = (DataTable)this.DGrid_GZRZ.DataSource;
				if(dt.Rows.Count>0)
				{
					int ncol = 0;
					for(int n=0;n<dt.Rows.Count;n++)
					{
						ncol = Validate(dt.Rows[n]);
						if( ncol >= 0)
						{
							FocusCell(this.DGrid_GZRZ,n,ncol);
							return;
						}					
					}
					if(IsSaveTable )
					{
						if(MessageBox.Show("该报表已经保存，是否重新保存？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
						{
							return;
						}
					}
			
					string[] sSql = new string[dt.Rows.Count+1];
					sSql[0]="update ZY_WARDRBB set Del=1 where book_date='"+dt.Rows[0]["BOOK_DATE"]+"' and dept_id in (select dept_id from jc_wardrdept where ward_id='"+InstanceForm.BCurrentDept.WardId+"');";
					for(int i=1;i<sSql.Length;i++)
					{
						DataRow dr = dt.Rows[i-1];
                        sSql[i] = "insert into zy_wardrbb(BOOK_DATE, DEPT_ID, YY, OUTALL, OUTZY, OUTHZ, OUTWY, OUTSW,TRANSOUT, [IN], TRANSIN, NOW, OPER_L, OPER_M, OPER_S, BIRTH, BW, BWQJ, BZ,TJHL, YJHL, PH, YBRS,DEL,BOOK_USER ,djrs,bzrs,syrs,lgrs) " +//Modify by zouchihua 2013-1-15
							" values('"+dr["BOOK_DATE"]+"',"+dr["DEPT_ID"]+","+Convertor.IsNull(dr["YY"],"null")+","+Convertor.IsNull(dr["OUTALL"],"null")+","+Convertor.IsNull(dr["OUTZY"],"null")+","+Convertor.IsNull(dr["OUTHZ"],"null")+","+Convertor.IsNull(dr["OUTWY"],"null")+","+Convertor.IsNull(dr["OUTSW"],"null")+","+Convertor.IsNull(dr["TRANSOUT"],"null")+","+Convertor.IsNull(dr["IN"],"null")+","+Convertor.IsNull(dr["TRANSIN"],"null")+","+Convertor.IsNull(dr["NOW"],"null")+","+Convertor.IsNull(dr["OPER_L"],"null")+","+Convertor.IsNull(dr["OPER_M"],"null")+","+Convertor.IsNull(dr["OPER_S"],"null")+","+Convertor.IsNull(dr["BIRTH"],"null")+","+Convertor.IsNull(dr["BW"],"null")+","+Convertor.IsNull(dr["BWQJ"],"null")+","+Convertor.IsNull(dr["BZ"],"null")+","+Convertor.IsNull(dr["TJHL"],"null")+","+Convertor.IsNull(dr["YJHL"],"null")+","+Convertor.IsNull(dr["PH"],"null")+","+Convertor.IsNull(dr["YBRS"],"null")+",0,"+InstanceForm.BCurrentUser.EmployeeId
                            + "," + Convertor.IsNull(dr["djrs"], "0") + " ," + Convertor.IsNull(dr["bzrs"], "0") + "," + Convertor.IsNull(dr["syrs"], "0") + "," + Convertor.IsNull(dr["lgrs"],"0") + " )";
					}
					InstanceForm.BDatabase.DoCommand(null,null,null,sSql);
					IsSaveTable = true;

					MessageBox.Show("保存成功！","提示");
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.ToString());
			}
			finally
			{
				this.Cursor = Cursors.Arrow;
			}		
		}

		//打印
		private void bt_print_Click(object sender, System.EventArgs e)
		{
		
		}
		#endregion
	}
}
