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

namespace ts_zyhs_jbjl
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frmJBJL : System.Windows.Forms.Form
	{
		//自定义变量
		private BaseFunc myFunc;
		private string sqlStr;
		DataTable jbjlTb = new DataTable();
		DataTable brdtTb = new DataTable();

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button bt打印;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DateTimePicker DtpbeginDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button button3;
		private DataGridEx myDataGrid1;
		private DataGridEx myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private RichTextBoxEx rtbShow;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblWard;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.ComponentModel.IContainer components;

		public frmJBJL(string _formText)
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbShow = new TrasenClasses.GeneralControls.RichTextBoxEx(this.components);
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWard = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.bt打印 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 621);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.splitter3);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 200);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(864, 421);
            this.panel4.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(400, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(464, 421);
            this.panel6.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbShow);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 421);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "特殊交班";
            // 
            // rtbShow
            // 
            this.rtbShow.BackColor = System.Drawing.SystemColors.Window;
            this.rtbShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbShow.DetectUrls = false;
            this.rtbShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbShow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbShow.LinkStyle = true;
            this.rtbShow.Location = new System.Drawing.Point(3, 17);
            this.rtbShow.Name = "rtbShow";
            this.rtbShow.ReadOnly = true;
            this.rtbShow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbShow.Size = new System.Drawing.Size(458, 401);
            this.rtbShow.TabIndex = 0;
            this.rtbShow.Text = "";
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(392, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(8, 421);
            this.splitter3.TabIndex = 1;
            this.splitter3.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.myDataGrid2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(392, 421);
            this.panel5.TabIndex = 0;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid2.CaptionText = "病人动态";
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid2.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.Size = new System.Drawing.Size(392, 421);
            this.myDataGrid2.TabIndex = 60;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid2.Tag = "";
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 192);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(864, 8);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(864, 132);
            this.panel3.TabIndex = 2;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "交班记录";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.ContextMenu = this.contextMenu2;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(864, 132);
            this.myDataGrid1.TabIndex = 59;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Tag = "";
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4});
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "删除";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 56);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(864, 4);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblWard);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.bt打印);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(864, 56);
            this.panel2.TabIndex = 0;
            // 
            // lblWard
            // 
            this.lblWard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWard.Location = new System.Drawing.Point(72, 22);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(218, 23);
            this.lblWard.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 81;
            this.label2.Text = "病室：";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.Location = new System.Drawing.Point(544, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 24);
            this.btnRefresh.TabIndex = 80;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // bt打印
            // 
            this.bt打印.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt打印.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt打印.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt打印.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt打印.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt打印.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt打印.ImageIndex = 0;
            this.bt打印.Location = new System.Drawing.Point(704, 16);
            this.bt打印.Name = "bt打印";
            this.bt打印.Size = new System.Drawing.Size(72, 24);
            this.bt打印.TabIndex = 79;
            this.bt打印.Text = "打印(&P)";
            this.bt打印.UseVisualStyleBackColor = false;
            this.bt打印.Click += new System.EventHandler(this.bt打印_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DtpbeginDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(296, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 48);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd";
            this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Location = new System.Drawing.Point(64, 16);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.Size = new System.Drawing.Size(148, 23);
            this.DtpbeginDate.TabIndex = 71;
            this.DtpbeginDate.Value = new System.DateTime(2004, 8, 24, 0, 0, 0, 0);
            this.DtpbeginDate.ValueChanged += new System.EventHandler(this.DtpbeginDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 70;
            this.label1.Text = "日期：";
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(784, 16);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 76;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNew.ContextMenu = this.contextMenu1;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.ImageIndex = 0;
            this.btnNew.Location = new System.Drawing.Point(624, 16);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(72, 24);
            this.btnNew.TabIndex = 75;
            this.btnNew.Text = "新建(&N)";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "白班";
            this.menuItem1.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "晚班";
            this.menuItem2.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "夜班";
            this.menuItem3.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(536, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(320, 40);
            this.button3.TabIndex = 77;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // frmJBJL
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(864, 621);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "frmJBJL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "交班记录";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmJBJL_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmJBJL_Load(object sender, System.EventArgs e)
		{
			this.Show_Date();	

			string[] GrdMappingName1={"班次","原有","出院","转出","死亡","入院","转入","现有","手术","分娩","病危","病重","外出","特护","一级护理","jb_text","book_user","id"};
			int[]    GrdWidth1      ={ 4,8,8,8,8,8,8,8,8,8,8,8,8,8,8,0,0,0};
			int[]    Alignment1     ={ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0};
			int[]	 ReadOnly1      ={ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
			myFunc.InitGrid(GrdMappingName1,GrdWidth1,Alignment1,ReadOnly1,this.myDataGrid1);

			string[] GrdMappingName2={"项目","床号","姓名","诊断","时间","jobtime","id"};
			int[]    GrdWidth2      ={ 8,4,8,20,5,0,0};
			int[]    Alignment2     ={ 1,1,0,0,0,0,0};
			int[]	 ReadOnly2      ={ 0,0,0,0,0,0,0};
			myFunc.InitGrid(GrdMappingName2,GrdWidth2,Alignment2,ReadOnly2,this.myDataGrid2);

			this.DtpbeginDate.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);   
			this.DtpbeginDate.MaxDate=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
			this.DtpbeginDate.Focus();
			lblWard.Text=InstanceForm.BCurrentDept.WardName;
		}

		public void Show_Date()
		{
			try
			{
				sqlStr="select case JOBTIME when 1 then '白班' when 2 then '晚班' when 3 then '夜班' end 班次,FORMERLY 原有,GOOUT 出院,TRANSOUT 转出,"+
					"DEATH 死亡,COMEIN 入院,TRANSIN 转入,NOW 现有,OPERATION 手术,CHILDBIRTH 分娩,TERMINALLYILL 病危,HEAVYILL 病重,GOAWAY 外出,"+
					"SPECIALTEND 特护,FIRSTTEND 一级护理,JB_TEXT,dbo.FUN_ZY_SEEKEMPLOYEENAME(book_user) book_user,id from zy_wardjbjl"+
					" where jb_date='"+DtpbeginDate.Value.Date+"' and ward_id='"+InstanceForm.BCurrentDept.WardId+"'"+
					" order by JOBTIME";
				jbjlTb=InstanceForm.BDatabase.GetDataTable(sqlStr);
				myDataGrid1.DataSource=jbjlTb;
                //Modify by zouchihua 改为诊断名称 2012-3-19
                sqlStr = "select item 项目,bed_no 床号,name 姓名,diagnoses 诊断,time 时间,b.jobtime,a.id from zy_wardjbjl_brdt a,zy_wardjbjl b " +
					"where a.jb_id=b.id and b.jb_date='"+DtpbeginDate.Value.Date+"' and ward_id='"+InstanceForm.BCurrentDept.WardId+"'"+
					"union all select '' 项目,'' 床号,'' 姓名,'' 诊断,'' 时间,jobtime,-1 id from zy_wardjbjl where jb_date='"+DtpbeginDate.Value+"' and ward_id='"+InstanceForm.BCurrentDept.WardId+"' and jobtime=2 "+
					"union all select '' 项目,'' 床号,'' 姓名,'' 诊断,'' 时间,jobtime,-1 id from zy_wardjbjl where jb_date='"+DtpbeginDate.Value+"' and ward_id='"+InstanceForm.BCurrentDept.WardId+"' and jobtime=3 "+
					"order by jobtime,a.id";
				brdtTb=InstanceForm.BDatabase.GetDataTable(sqlStr);
				myDataGrid2.DataSource=brdtTb;
				
				rtbShow.Clear();
				for (int i=0;i<jbjlTb.Rows.Count;i++)
				{
					rtbShow.Text += "【 "+jbjlTb.Rows[i]["班次"]+" 】\n";
					rtbShow.Text += jbjlTb.Rows[i]["jb_text"]+"\n";
					rtbShow.Text += "                                             签名："+jbjlTb.Rows[i]["book_user"]+"\n\n";
				}
			}
			catch(Exception err)
			{
				MessageBox.Show("错误："+err.Message+"\n"+"Source："+err.Source,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			Point pp = new Point(btnNew.Location.X,btnNew.Location.Y+btnNew.Height);

			contextMenu1.Show(this,pp);
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			DataTable popTb = new DataTable();

			sqlStr="select jobtime from zy_wardjbjl where jb_date='"+DtpbeginDate.Value.Date+"' and ward_id='"+InstanceForm.BCurrentDept.WardId+"'";
			popTb=InstanceForm.BDatabase.GetDataTable(sqlStr);
			
			if (popTb==null || popTb.Rows.Count==0)
			{
				contextMenu1.MenuItems[0].Enabled=true;
				contextMenu1.MenuItems[1].Enabled=true;
				contextMenu1.MenuItems[2].Enabled=true;
			}
			else
			{
				for(int i=0;i<popTb.Rows.Count;i++)
				{
					if(popTb.Rows[i]["jobtime"].ToString()=="1") contextMenu1.MenuItems[0].Enabled=false;
					if(popTb.Rows[i]["jobtime"].ToString()=="2") contextMenu1.MenuItems[1].Enabled=false;
					if(popTb.Rows[i]["jobtime"].ToString()=="3") contextMenu1.MenuItems[2].Enabled=false;
				}
			}
		}

		private void menuItem_Click(object sender, System.EventArgs e)
		{
			MenuItem mnu = (MenuItem)sender;
			frmNEWJBJL fn = new frmNEWJBJL(mnu.Text);
			fn.DtpbeginDate.Value=DtpbeginDate.Value;
			fn.DtpbeginDate.Enabled=false;
			fn.ShowDialog();
			fn.Dispose();
			Show_Date();
		}

		private void DtpbeginDate_ValueChanged(object sender, System.EventArgs e)
		{
			Show_Date();
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			Show_Date();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			string msg="";

			msg=MessageBox.Show(this,"删除数据将无法恢复，是否继续？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question).ToString();
			if (msg.ToUpper()=="NO") return;

			if (InstanceForm.BCurrentUser.Name.Trim() != jbjlTb.Rows[myDataGrid1.CurrentRowIndex]["book_user"].ToString().Trim())
			{
				MessageBox.Show(this,"不是你录入的记录，不能删除！","提示",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}

			sqlStr="delete from zy_wardjbjl_brdt where jb_id="+Convert.ToInt32(jbjlTb.Rows[myDataGrid1.CurrentRowIndex]["id"].ToString());
			InstanceForm.BDatabase.DoCommand(sqlStr);
			sqlStr="delete from zy_wardjbjl where id="+Convert.ToInt32(jbjlTb.Rows[myDataGrid1.CurrentRowIndex]["id"].ToString());
			InstanceForm.BDatabase.DoCommand(sqlStr);

			//写日志 Add By Tany 2005-01-12
			SystemLog _systemLog=new SystemLog(-1,InstanceForm.BCurrentDept.DeptId,InstanceForm.BCurrentUser.EmployeeId,"删除交班记录","记录号"+jbjlTb.Rows[myDataGrid1.CurrentRowIndex]["id"].ToString(),DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase),1,"主机名："+System.Environment.MachineName,39);
			_systemLog.Save();
			_systemLog=null;

			Show_Date();
		}

		private void bt打印_Click(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			DataTable dt = new DataTable();
			DataTable dt2 = new DataTable();
			string sSql;

            sSql = "select '" + InstanceForm.BCurrentDept.WardName + "'as wname,jb_date,dbo.FUN_ZY_SEEKEMPLOYEENAME(book_user) book_user," +
				"case JOBTIME when 1 then '白班' when 2 then '晚班' when 3 then '夜班' end JOBTIME,FORMERLY,GOOUT,TRANSOUT,"+
				"DEATH,COMEIN,TRANSIN,NOW,OPERATION,CHILDBIRTH,TERMINALLYILL,HEAVYILL,GOAWAY,SPECIALTEND,FIRSTTEND,jb_text from zy_wardjbjl"+
				" where jb_date='"+DtpbeginDate.Value.Date+"' and ward_id='"+InstanceForm.BCurrentDept.WardId+"'"+
				" order by JOBTIME";
			dt=InstanceForm.BDatabase.GetDataTable(sSql);
			dt.TableName="tabWardjbjl";

			if (dt==null || dt.Rows.Count==0) return;

			ds.Tables.Add(dt);
            //Modify by zouchihua 改为诊断名称 2012-3-19
            sSql = "select item,bed_no,name,diagnoses ,time,b.jobtime,b.jb_text as jobtimename,dbo.FUN_ZY_SEEKEMPLOYEENAME(book_user) book_user from zy_wardjbjl_brdt a,zy_wardjbjl b " +
				"where a.jb_id=b.id and b.jb_date='"+DtpbeginDate.Value.Date+"' and ward_id='"+InstanceForm.BCurrentDept.WardId+"' order by jobtime,a.id";
			dt2=InstanceForm.BDatabase.GetDataTable(sSql);
			dt2.TableName="tabWardjbjl_brdt";

			if (dt2==null || dt2.Rows.Count==0) return;

			ds.Tables.Add(dt2);

			FrmReportView frmRptView=null;
			ParameterEx[] _parameters=new ParameterEx[3];

			_parameters[0].Text="医院名称";
			_parameters[0].Value=(new SystemCfg(0002)).Config;
			_parameters[1].Text="病区名称";
			_parameters[1].Value=lblWard.Text;
			_parameters[2].Text="交班日期";
			_parameters[2].Value=DtpbeginDate.Value;

			frmRptView=new FrmReportView(ds,Constant.ApplicationDirectory+"\\report\\ZYHS_交班记录.rpt",_parameters);
			frmRptView.Show();
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
