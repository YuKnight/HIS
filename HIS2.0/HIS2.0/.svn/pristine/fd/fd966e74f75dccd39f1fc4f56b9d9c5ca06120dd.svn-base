using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Data;
namespace ts_jc_yykssz
{
	/// <summary>
	/// FrmMain 的摘要说明。
	/// </summary>
	public class FrmMain : System.Windows.Forms.Form
	{
		private struct DeptInfo
		{
			public int DeptId;
			public int Level;
		}
		private DataTable tableDepartment;
		private DataTable tableEmpDept;
		private System.Windows.Forms.Panel plTop;
		private System.Windows.Forms.Panel plLeft;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel plRight;
		private System.Windows.Forms.Panel plDeptInfo;
		private System.Windows.Forms.Panel plDeptEmp;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TreeView tvwDept;
		private ListViewEx lstEmployee;
		private System.Windows.Forms.Button btnRefreshDept;
		private System.Windows.Forms.Button btnEditDept;
		private System.Windows.Forms.Button btnAddDept;
		private System.Windows.Forms.Button btnEditEmp;
		private System.Windows.Forms.Button btnAddEmp;
		private System.Windows.Forms.Label lblDeptname;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.ListView lvwRole;
		private System.Windows.Forms.Button btnAll;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.TextBox txtFind;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListView lvwWarddept;
		private System.Windows.Forms.Button btnInvalidData;
		private System.Windows.Forms.Label label6;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
		private System.ComponentModel.IContainer components;
        private Button btnExport;
        private Label label7;
        private ComboBox cboRylx;
        private Label lblSum;
        private MenuTag _menuTag;

        public FrmMain(MenuTag menuTag, string text)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.Text = text;
     
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            _menuTag = menuTag;
            
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.plTop = new System.Windows.Forms.Panel();
            this.plLeft = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tvwDept = new System.Windows.Forms.TreeView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInvalidData = new System.Windows.Forms.Button();
            this.btnRefreshDept = new System.Windows.Forms.Button();
            this.btnEditDept = new System.Windows.Forms.Button();
            this.btnAddDept = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.plRight = new System.Windows.Forms.Panel();
            this.plDeptEmp = new System.Windows.Forms.Panel();
            this.lstEmployee = new TrasenClasses.GeneralControls.ListViewEx(this.components);
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cboRylx = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditEmp = new System.Windows.Forms.Button();
            this.btnAddEmp = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plDeptInfo = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lvwWarddept = new System.Windows.Forms.ListView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lvwRole = new System.Windows.Forms.ListView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblDeptname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.plLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plDeptEmp.SuspendLayout();
            this.panel3.SuspendLayout();
            this.plDeptInfo.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // plTop
            // 
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(1008, 34);
            this.plTop.TabIndex = 0;
            // 
            // plLeft
            // 
            this.plLeft.Controls.Add(this.panel2);
            this.plLeft.Controls.Add(this.panel1);
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLeft.Location = new System.Drawing.Point(0, 34);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(184, 696);
            this.plLeft.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 531);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tvwDept);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(184, 520);
            this.panel6.TabIndex = 2;
            // 
            // tvwDept
            // 
            this.tvwDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwDept.ImageIndex = 0;
            this.tvwDept.ImageList = this.imageList2;
            this.tvwDept.Location = new System.Drawing.Point(0, 0);
            this.tvwDept.Name = "tvwDept";
            this.tvwDept.SelectedImageIndex = 0;
            this.tvwDept.Size = new System.Drawing.Size(184, 520);
            this.tvwDept.TabIndex = 0;
            this.tvwDept.DoubleClick += new System.EventHandler(this.tvwDept_DoubleClick);
            this.tvwDept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDept_AfterSelect);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 520);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(184, 11);
            this.panel5.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInvalidData);
            this.panel1.Controls.Add(this.btnRefreshDept);
            this.panel1.Controls.Add(this.btnEditDept);
            this.panel1.Controls.Add(this.btnAddDept);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 165);
            this.panel1.TabIndex = 0;
            // 
            // btnInvalidData
            // 
            this.btnInvalidData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvalidData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInvalidData.Location = new System.Drawing.Point(13, 107);
            this.btnInvalidData.Name = "btnInvalidData";
            this.btnInvalidData.Size = new System.Drawing.Size(147, 26);
            this.btnInvalidData.TabIndex = 4;
            this.btnInvalidData.Text = "查看无效数据";
            this.btnInvalidData.Click += new System.EventHandler(this.btnInvalidData_Click);
            // 
            // btnRefreshDept
            // 
            this.btnRefreshDept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefreshDept.Location = new System.Drawing.Point(13, 74);
            this.btnRefreshDept.Name = "btnRefreshDept";
            this.btnRefreshDept.Size = new System.Drawing.Size(147, 26);
            this.btnRefreshDept.TabIndex = 3;
            this.btnRefreshDept.Text = "刷新";
            this.btnRefreshDept.Click += new System.EventHandler(this.btnRefreshDept_Click);
            // 
            // btnEditDept
            // 
            this.btnEditDept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditDept.Location = new System.Drawing.Point(13, 39);
            this.btnEditDept.Name = "btnEditDept";
            this.btnEditDept.Size = new System.Drawing.Size(147, 26);
            this.btnEditDept.TabIndex = 1;
            this.btnEditDept.Text = "编辑部门";
            this.btnEditDept.Click += new System.EventHandler(this.btnEditDept_Click);
            // 
            // btnAddDept
            // 
            this.btnAddDept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddDept.Location = new System.Drawing.Point(13, 7);
            this.btnAddDept.Name = "btnAddDept";
            this.btnAddDept.Size = new System.Drawing.Size(147, 26);
            this.btnAddDept.TabIndex = 0;
            this.btnAddDept.Text = "添加部门";
            this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(184, 34);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 696);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // plRight
            // 
            this.plRight.Controls.Add(this.plDeptEmp);
            this.plRight.Controls.Add(this.plDeptInfo);
            this.plRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRight.Location = new System.Drawing.Point(187, 34);
            this.plRight.Name = "plRight";
            this.plRight.Size = new System.Drawing.Size(821, 696);
            this.plRight.TabIndex = 3;
            // 
            // plDeptEmp
            // 
            this.plDeptEmp.Controls.Add(this.lstEmployee);
            this.plDeptEmp.Controls.Add(this.panel3);
            this.plDeptEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDeptEmp.Location = new System.Drawing.Point(0, 215);
            this.plDeptEmp.Name = "plDeptEmp";
            this.plDeptEmp.Size = new System.Drawing.Size(821, 481);
            this.plDeptEmp.TabIndex = 1;
            // 
            // lstEmployee
            // 
            this.lstEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader4});
            this.lstEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEmployee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstEmployee.FullRowSelect = true;
            this.lstEmployee.GridLines = true;
            this.lstEmployee.Location = new System.Drawing.Point(0, 51);
            this.lstEmployee.MultiSelect = false;
            this.lstEmployee.Name = "lstEmployee";
            this.lstEmployee.Size = new System.Drawing.Size(821, 430);
            this.lstEmployee.TabIndex = 1;
            this.lstEmployee.UseCompatibleStateImageBehavior = false;
            this.lstEmployee.View = System.Windows.Forms.View.Details;
            this.lstEmployee.DoubleClick += new System.EventHandler(this.lstEmployee_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "性别";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "登录账号";
            this.columnHeader1.Width = 87;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "类型";
            this.columnHeader3.Width = 101;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "工号";
            this.columnHeader5.Width = 81;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "医生级别";
            this.columnHeader6.Width = 87;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "护士级别";
            this.columnHeader7.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "所在科室";
            this.columnHeader4.Width = 174;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblSum);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.cboRylx);
            this.panel3.Controls.Add(this.btnExport);
            this.panel3.Controls.Add(this.btnAll);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnEditEmp);
            this.panel3.Controls.Add(this.btnAddEmp);
            this.panel3.Controls.Add(this.txtFind);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(821, 51);
            this.panel3.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "类型";
            // 
            // cboRylx
            // 
            this.cboRylx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRylx.Location = new System.Drawing.Point(296, 6);
            this.cboRylx.Name = "cboRylx";
            this.cboRylx.Size = new System.Drawing.Size(142, 20);
            this.cboRylx.TabIndex = 2;
            this.cboRylx.SelectedIndexChanged += new System.EventHandler(this.cboRylx_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Location = new System.Drawing.Point(736, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(78, 27);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "导出数据";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAll
            // 
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAll.Location = new System.Drawing.Point(648, 6);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(78, 27);
            this.btnAll.TabIndex = 5;
            this.btnAll.Text = "全部人员";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(420, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "查询请输入内容并按回车键(查询条件为姓名、拼音码、工号，支持模糊查询)";
            // 
            // btnEditEmp
            // 
            this.btnEditEmp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditEmp.Location = new System.Drawing.Point(560, 6);
            this.btnEditEmp.Name = "btnEditEmp";
            this.btnEditEmp.Size = new System.Drawing.Size(78, 27);
            this.btnEditEmp.TabIndex = 4;
            this.btnEditEmp.Text = "编辑人员";
            this.btnEditEmp.Click += new System.EventHandler(this.btnEditEmp_Click);
            // 
            // btnAddEmp
            // 
            this.btnAddEmp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddEmp.Location = new System.Drawing.Point(472, 6);
            this.btnAddEmp.Name = "btnAddEmp";
            this.btnAddEmp.Size = new System.Drawing.Size(78, 27);
            this.btnAddEmp.TabIndex = 3;
            this.btnAddEmp.Text = "添加人员";
            this.btnAddEmp.Click += new System.EventHandler(this.btnAddEmp_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(61, 6);
            this.txtFind.MaxLength = 30;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(195, 21);
            this.txtFind.TabIndex = 1;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询条件";
            // 
            // plDeptInfo
            // 
            this.plDeptInfo.Controls.Add(this.panel8);
            this.plDeptInfo.Controls.Add(this.panel7);
            this.plDeptInfo.Controls.Add(this.panel4);
            this.plDeptInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plDeptInfo.Location = new System.Drawing.Point(0, 0);
            this.plDeptInfo.Name = "plDeptInfo";
            this.plDeptInfo.Size = new System.Drawing.Size(821, 215);
            this.plDeptInfo.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lvwWarddept);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 131);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(821, 84);
            this.panel8.TabIndex = 10;
            // 
            // lvwWarddept
            // 
            this.lvwWarddept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwWarddept.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwWarddept.LargeImageList = this.imageList2;
            this.lvwWarddept.Location = new System.Drawing.Point(0, 22);
            this.lvwWarddept.MultiSelect = false;
            this.lvwWarddept.Name = "lvwWarddept";
            this.lvwWarddept.Size = new System.Drawing.Size(821, 62);
            this.lvwWarddept.SmallImageList = this.imageList2;
            this.lvwWarddept.TabIndex = 1;
            this.lvwWarddept.UseCompatibleStateImageBehavior = false;
            this.lvwWarddept.View = System.Windows.Forms.View.List;
            this.lvwWarddept.DoubleClick += new System.EventHandler(this.lvwWarddept_DoubleClick);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label5);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(821, 22);
            this.panel9.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "病区下的科室";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel11);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 46);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(821, 85);
            this.panel7.TabIndex = 9;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.lvwRole);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 21);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(821, 64);
            this.panel11.TabIndex = 10;
            // 
            // lvwRole
            // 
            this.lvwRole.CheckBoxes = true;
            this.lvwRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwRole.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwRole.Location = new System.Drawing.Point(0, 0);
            this.lvwRole.Name = "lvwRole";
            this.lvwRole.Size = new System.Drawing.Size(821, 64);
            this.lvwRole.TabIndex = 8;
            this.lvwRole.UseCompatibleStateImageBehavior = false;
            this.lvwRole.View = System.Windows.Forms.View.List;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label6);
            this.panel10.Controls.Add(this.label4);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(821, 21);
            this.panel10.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(96, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "(仅做显示，要修改请使用编辑功能)";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "科室角色";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblDeptname);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(821, 46);
            this.panel4.TabIndex = 7;
            // 
            // lblDeptname
            // 
            this.lblDeptname.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDeptname.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDeptname.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeptname.Location = new System.Drawing.Point(82, 8);
            this.lblDeptname.Name = "lblDeptname";
            this.lblDeptname.Size = new System.Drawing.Size(356, 31);
            this.lblDeptname.TabIndex = 5;
            this.lblDeptname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "名称";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(443, 35);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(41, 12);
            this.lblSum.TabIndex = 18;
            this.lblSum.Text = "label8";
            // 
            // FrmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.plRight);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.plLeft);
            this.Controls.Add(this.plTop);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.plLeft.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plDeptEmp.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.plDeptInfo.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        /// <summary>
        /// jianqg 2014-6-30 增加，将人事，医务权限分离
        /// </summary>
        private void Init_function_Name()
        {
            string function_Name = InstanceForm._menuTag.Function_Name;
            switch (function_Name)
            {
                case "Fun_ts_jc_yykssz_yw_ry"://医务
                    panel1.Height = 67;
                    btnAddDept.Visible = false;
                    btnEditDept.Visible = false;
                    btnRefreshDept.Visible = false;
                    btnAddEmp.Enabled = false;
                    break;
                case "Fun_ts_jc_yykssz_rs_ksry"://人事
                    break;
            }
            
        }

		/// <summary>
		/// 获取可是角色
		/// </summary>
		private void LoadDepartment()
		{
            this.tableDepartment = InstanceForm.BDatabase.GetDataTable("select dept_id,p_dept_id,name,layer from jc_dept_property where deleted=0 order by LAYER, SORT_ID,DEPT_ID");
			this.tableEmpDept = InstanceForm.BDatabase.GetDataTable("select a.employee_id,b.name from jc_emp_dept_role a left join jc_dept_property b on a.dept_id=b.dept_id ");
		}
		/// <summary>
		/// 获取角色列表
		/// </summary>
		private void LoadDeptRoleList()
		{
			this.lvwRole.Items.Clear();
			string sql = "select * from jc_dept_type order by code";
			DataTable tableRole = InstanceForm.BDatabase.GetDataTable( sql );
			for( int i=0;i<tableRole.Rows.Count;i++)
			{
				ListViewItem item = new ListViewItem();
				item.Text = tableRole.Rows[i]["name"].ToString().Trim();
				item.Tag = tableRole.Rows[i]["code"].ToString().Trim();
 
				this.lvwRole.Items.Add( item );
			}
            this.lvwRole.Enabled = false;
		}
		/// <summary>
		/// 创建树
		/// </summary>
		private void CreateTree()
		{
			this.tvwDept.BeginUpdate();
			this.tvwDept.Nodes.Clear();
			
			DataRow[] drs = tableDepartment.Select("p_dept_id<=0");
			for(int i=0;i<drs.Length;i++)
			{
				TreeNode nd = new TreeNode();				
				nd.Text = drs[i]["name"].ToString();
				nd.ImageIndex = 0;
				DeptInfo deptInfo = new DeptInfo();
				deptInfo.DeptId = Convert.ToInt32(drs[i]["dept_id"]);
				deptInfo.Level = Convert.ToInt32(drs[i]["layer"]);
				nd.Tag = deptInfo;
				AddNode(tableDepartment,Convert.ToInt32(drs[i]["dept_id"]),nd);
				this.tvwDept.Nodes.Add(nd);
			}
            if (tvwDept.Nodes.Count > 0) tvwDept.Nodes[0].Expand();
			this.tvwDept.EndUpdate();
            
           
		}
		/// <summary>
		/// 添加子节点
		/// </summary>
		/// <param name="tableAll"></param>
		/// <param name="pId"></param>
		/// <param name="pNd"></param>
		private void AddNode(DataTable tableAll ,int pId,TreeNode pNd)
		{
			DataRow[] drs = tableAll.Select("p_dept_id=" + pId);
			for(int i=0;i<drs.Length;i++)
			{
				TreeNode nd = new TreeNode();
				nd.Text = drs[i]["name"].ToString();

				DeptInfo deptInfo = new DeptInfo();
				deptInfo.DeptId = Convert.ToInt32(drs[i]["dept_id"]);
				deptInfo.Level = Convert.ToInt32(drs[i]["layer"]);

				nd.Tag = deptInfo;
				nd.ImageIndex = 0;
				AddNode(tableAll,Convert.ToInt32(drs[i]["dept_id"]),nd);
				pNd.Nodes.Add(nd);
			}
		}
		/// <summary>
		/// 显示科室信息
		/// </summary>
		/// <param name="deptId"></param>
		private void ShowDeptInfo(int deptId)
		{
			foreach(ListViewItem item in this.lvwRole.Items)
			{
				item.Checked = false;
			}
			this.lblDeptname.Text = this.tvwDept.SelectedNode.Text;
			string sql = "select * from jc_dept_type_relation where dept_id="+deptId;
			DataTable tableRole = InstanceForm.BDatabase.GetDataTable( sql );
			for( int i=0;i<tableRole.Rows.Count;i++)
			{
				string code = tableRole.Rows[i]["type_code"].ToString().Trim();
				foreach(ListViewItem item in this.lvwRole.Items)
				{
					if ( item.Tag.ToString().Trim() == code )
					{
						item.Checked = true;
					}
				}
			}
		}
		/// <summary>
		/// 显示病区科室
		/// </summary>
		/// <param name="deptId"></param>
		private void ShowWardDept(int deptId)
		{
			this.lvwWarddept.Items.Clear();
			string sql = "select * from jc_ward where dept_id=" + deptId;
			DataRow drWard = InstanceForm.BDatabase.GetDataRow( sql );
			if ( drWard != null )
			{
				sql = "select b.layer,b.dept_id,b.name from jc_wardrdept a ,jc_dept_property b where a.dept_id=b.dept_id and ward_id='" + drWard["ward_id"].ToString() + "' and a.dept_id <>" + deptId;
				DataTable tableDept = InstanceForm.BDatabase.GetDataTable( sql );
				for( int i=0;i<tableDept.Rows.Count;i++)
				{
					DeptInfo deptInfo = new DeptInfo();
					deptInfo.DeptId = Convert.ToInt32( tableDept.Rows[i]["dept_id"] );
					deptInfo.Level = Convert.ToInt32( tableDept.Rows[i]["layer"] );
					ListViewItem item = new ListViewItem(tableDept.Rows[i]["name"].ToString().Trim());
					item.Tag = deptInfo;
					item.ImageIndex =2;
					this.lvwWarddept.Items.Add( item );
				}
			}
		}
        /// <summary>
        /// 显示所有人员
        /// </summary>
        private void ShowEmployee()
        {
            ShowEmployee(null);
        }
        /// <summary>
        /// 显示所有人员, 并定位于findEmployeeId
        /// jianqg 20120222 增加参数，findEmployeeId，可以定位于该人员
        /// </summary>
        /// <param name="findEmployeeId">需要查找的人员id</param>
        private void ShowEmployee(object findEmployeeId)
		{
			try
			{
				this.lstEmployee.Items.Clear();
                string sql = @"select a.employee_id,a.name,b.code,(case a.sex when 0 then '未指定' when 1 then '男' when 2 then '女' end) as sex,
							case a.rylx 
								when 1 then '医生'
								when 2 then '护士'
								when 3 then '收费员'
								when 4 then '药库操作员'
								when 5 then '药房操作员'
								when 6 then '医技人员'
								when 7 then '其他'
                                when 8 then '自助终端'
							end as rylx,
                            a.d_code as ys_code,
							dbo.fun_getyszcjb(ys_typeid) type_name,
							case d.type
								when 0 then '普通护士'
								when 1 then '组长护士'
								when 2 then '护士长'
							end as hsjb
							from jc_employee_property a 
							left join pub_user b on a.employee_id=b.employee_id
							left join  jc_role_doctor  c on a.employee_id=c.employee_id
							left join jc_role_nurse d on a.employee_id=d.employee_id
							where a.delete_bit=0
							order by a.employee_id";
                //left join (select a.*,b.type_name from jc_role_doctor a left join jc_doctor_type b on a.ys_typeid = b.type_id) c on a.employee_id=c.employee_id

				DataTable tableEmployee = InstanceForm.BDatabase.GetDataTable( sql );
                lblSum.Text = tableEmployee.Rows.Count.ToString() + "人";
				for ( int i=0;i<tableEmployee.Rows.Count;i++)
				{
                    ListViewItem item = new ListViewItem();
					item.Text = tableEmployee.Rows[i]["name"].ToString().Trim();
                    item.SubItems.Add( tableEmployee.Rows[i]["sex"].ToString( ) );
					item.SubItems.Add( tableEmployee.Rows[i]["code"].ToString().Trim());
					item.SubItems.Add(tableEmployee.Rows[i]["rylx"].ToString().Trim());
                    item.SubItems.Add( tableEmployee.Rows[i]["ys_code"].ToString( ).Trim( ) );
                    item.SubItems.Add( tableEmployee.Rows[i]["type_name"].ToString( ).Trim( ) );
                    item.SubItems.Add( tableEmployee.Rows[i]["hsjb"].ToString( ).Trim( ) );
					item.Tag = Convert.ToInt32(tableEmployee.Rows[i]["employee_id"]);
                    item.Name = item.Tag.ToString(); //jiang 20120222 增加 设置 key，方便查找


					sql = "employee_id=" + Convert.ToInt32(tableEmployee.Rows[i]["employee_id"]);
					DataRow[] drs = this.tableEmpDept.Select( sql );
					string dept = "";
					for( int j = 0;j<drs.Length;j++)
					{
						string name = drs[j]["name"].ToString().Trim();
						if ( name != "")
						{
							dept = dept + name +",";
						}
					}
					if ( dept!="")
					{
						dept = dept.Substring(0,dept.Length-1);
					}
					item.SubItems.Add(dept);
					this.lstEmployee.Items.Add(item);

                    if (findEmployeeId != null && findEmployeeId.ToString() == item.Tag.ToString())
                    {
                        lstEmployee.Items[item.Name].Selected = true;
                        lstEmployee.EnsureVisible(item.Index);
                        lstEmployee.Select();
                         
                    }
				}
			}
			catch
			{
                lstEmployee.Tag = null;
			}
		}
		/// <summary>
		/// 显示当前选中科室人员
		/// </summary>
		/// <param name="deptId"></param>
		private void ShowEmployee(int deptId)
		{
			try
			{
                this.lstEmployee.Items.Clear();
                string sql = @"select a.employee_id,a.name,b.code,(case a.sex when 0 then '未指定' when 1 then '男' when 2 then '女' end) as sex,
							case a.rylx 
								when 1 then '医生'
								when 2 then '护士'
								when 3 then '收费员'
								when 4 then '药库操作员'
								when 5 then '药房操作员'
								when 6 then '医技人员'
								when 7 then '其他'
                                when 8 then '自助终端'
							end as rylx,
                            a.d_code as ys_code,
							dbo.fun_getyszcjb(ys_typeid) type_name,
							case d.type
								when 0 then '普通护士'
								when 1 then '组长护士'
								when 2 then '护士长'
							end as hsjb
							from jc_employee_property a 
							left join pub_user b on a.employee_id=b.employee_id
							left join jc_role_doctor c on a.employee_id=c.employee_id
							left join jc_role_nurse d on a.employee_id=d.employee_id
							where a.delete_bit=0 and a.employee_id in (select employee_id from jc_emp_dept_role where dept_id=" + deptId + ")" + @"
                            {0}
							order by a.employee_id";
                ShowEmployee_public(sql);
//                DataTable tableEmployee = InstanceForm.BDatabase.GetDataTable( sql );
//                for ( int i=0;i<tableEmployee.Rows.Count;i++)
//                {
//                    ListViewItem item = new ListViewItem();
//                    item.Text = tableEmployee.Rows[i]["name"].ToString().Trim();
//                    item.Tag = Convert.ToInt32(tableEmployee.Rows[i]["employee_id"]);
//                    item.SubItems.Add( tableEmployee.Rows[i]["sex"].ToString( ) );
//                    item.SubItems.Add( tableEmployee.Rows[i]["code"].ToString().Trim());
//                    item.SubItems.Add(tableEmployee.Rows[i]["rylx"].ToString().Trim());
//                    item.SubItems.Add( tableEmployee.Rows[i]["ys_code"].ToString().Trim());
//                    item.SubItems.Add( tableEmployee.Rows[i]["type_name"].ToString().Trim());
//                    item.SubItems.Add( tableEmployee.Rows[i]["hsjb"].ToString().Trim());
//                    sql = "employee_id=" + Convert.ToInt32(tableEmployee.Rows[i]["employee_id"]);
//                    DataRow[] drs = this.tableEmpDept.Select( sql );
//                    string dept = "";
//                    for( int j = 0;j<drs.Length;j++)
//                    {
//                        string name = drs[j]["name"].ToString().Trim();
//                        if ( name != "")
//                        {
//                            dept = dept + name +",";
//                        }
//                    }
//                    if ( dept!="")
//                    {
//                        dept = dept.Substring(0,dept.Length-1);
//                    }
//                    item.SubItems.Add(dept);
					
//                    this.lstEmployee.Items.Add(item);
//                }
			}
			catch(System.Exception err)
			{
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		/// <summary>
		/// 显示符合条件的人员
		/// </summary>
		/// <param name="deptId"></param>
		private void ShowEmployee(string strVal)
		{
			try
			{
				this.lstEmployee.Items.Clear();
                //jianqg 2014-6-30 增加条件
                string sql = @"select a.employee_id,a.name,b.code,(case a.sex when 0 then '未指定' when 1 then '男' when 2 then '女' end) as sex,
							case a.rylx 
								when 1 then '医生'
								when 2 then '护士'
								when 3 then '收费员'
								when 4 then '药库操作员'
								when 5 then '药房操作员'
								when 6 then '医技人员'
								when 7 then '其他'
                                 when 8 then '自助终端'
							end as rylx,
                            a.d_code as ys_code,
							dbo.fun_getyszcjb(ys_typeid) type_name,
							case d.type
								when 0 then '普通护士'
								when 1 then '组长护士'
								when 2 then '护士长'
							end as hsjb
							from jc_employee_property a 
							left join pub_user b on a.employee_id=b.employee_id
							left join  jc_role_doctor  c on a.employee_id=c.employee_id
							left join jc_role_nurse d on a.employee_id=d.employee_id
							where a.delete_bit=0 
                            and (a.name like '%" + strVal + "%' or a.py_code like '" + strVal + "%' or b.code like '" + strVal + @"%')
                            {0}
							order by a.employee_id";
                ShowEmployee_public(sql);
                //DataTable tableEmployee = InstanceForm.BDatabase.GetDataTable( sql );
                //for ( int i=0;i<tableEmployee.Rows.Count;i++)
                //{
                //    ListViewItem item = new ListViewItem();
                //    item.Text = tableEmployee.Rows[i]["name"].ToString().Trim();
                //    item.Tag = Convert.ToInt32(tableEmployee.Rows[i]["employee_id"]);
                //    item.SubItems.Add( tableEmployee.Rows[i]["sex"].ToString( ) );
                //    item.SubItems.Add( tableEmployee.Rows[i]["code"].ToString().Trim());
                //    item.SubItems.Add(tableEmployee.Rows[i]["rylx"].ToString().Trim());
                //    item.SubItems.Add( tableEmployee.Rows[i]["ys_code"].ToString( ).Trim( ) );
                //    item.SubItems.Add( tableEmployee.Rows[i]["type_name"].ToString( ).Trim( ) );
                //    item.SubItems.Add( tableEmployee.Rows[i]["hsjb"].ToString( ).Trim( ) );
                //    sql = "employee_id=" + Convert.ToInt32(tableEmployee.Rows[i]["employee_id"]);
                //    DataRow[] drs = this.tableEmpDept.Select( sql );
                //    string dept = "";
                //    for( int j = 0;j<drs.Length;j++)
                //    {
                //        string name = drs[j]["name"].ToString().Trim();
                //        if ( name != "")
                //        {
                //            dept = dept + name +",";
                //        }
                //    }
                //    if ( dept!="")
                //    {
                //        dept = dept.Substring(0,dept.Length-1);
                //    }
                //    item.SubItems.Add(dept);
					
                //    this.lstEmployee.Items.Add(item);
                //}
			}
			catch
			{
			}
		}
        private void ShowEmployee_public(string sql)
        {
            this.lstEmployee.Items.Clear();
                           //jianqg 2014-6-30 增加条件
            string strrylx = "";
            if (cboRylx.Text !="" )
            {
                EmployeeType rylx = EmployeeType.其他;
                foreach (object obj in Enum.GetValues(typeof(EmployeeType)))
                {
                    if (((EmployeeType)obj).ToString() == cboRylx.Text)
                    {
                        rylx = (EmployeeType)obj;
                        break;
                    }
                }

                strrylx = "  and  a.rylx = " +  (int)rylx;

                
            }
            sql = string.Format(sql, strrylx);
            DataTable tableEmployee = InstanceForm.BDatabase.GetDataTable(sql);
            lblSum.Text = tableEmployee.Rows.Count.ToString() + "人";
            for ( int i=0;i<tableEmployee.Rows.Count;i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = tableEmployee.Rows[i]["name"].ToString().Trim();
                item.Tag = Convert.ToInt32(tableEmployee.Rows[i]["employee_id"]);
                item.SubItems.Add( tableEmployee.Rows[i]["sex"].ToString( ) );
                item.SubItems.Add( tableEmployee.Rows[i]["code"].ToString().Trim());
                item.SubItems.Add(tableEmployee.Rows[i]["rylx"].ToString().Trim());
                item.SubItems.Add( tableEmployee.Rows[i]["ys_code"].ToString( ).Trim( ) );
                item.SubItems.Add( tableEmployee.Rows[i]["type_name"].ToString( ).Trim( ) );
                item.SubItems.Add( tableEmployee.Rows[i]["hsjb"].ToString( ).Trim( ) );
                sql = "employee_id=" + Convert.ToInt32(tableEmployee.Rows[i]["employee_id"]);
                DataRow[] drs = this.tableEmpDept.Select( sql );
                string dept = "";
                for( int j = 0;j<drs.Length;j++)
                {
                    string name = drs[j]["name"].ToString().Trim();
                    if ( name != "")
                    {
                        dept = dept + name +",";
                    }
                }
                if ( dept!="")
                {
                    dept = dept.Substring(0,dept.Length-1);
                }
                item.SubItems.Add(dept);
				
                this.lstEmployee.Items.Add(item);
            }
        }

		private void FrmMain_Load(object sender, System.EventArgs e)
		{
            Init_function_Name();
			this.LoadDepartment();
			this.LoadDeptRoleList();
			this.CreateTree();
			this.ShowEmployee();
            cboRylx.Items.Add("");
            foreach (object obj in Enum.GetValues(typeof(EmployeeType)))
                cboRylx.Items.Add(obj.ToString());


		}

		private void tvwDept_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if ( this.tvwDept.SelectedNode != null )
			{
				DeptInfo deptInfo = (DeptInfo)e.Node.Tag;

				int deptId = deptInfo.DeptId;

				this.ShowDeptInfo(deptId);

				ShowWardDept(deptId);

				this.ShowEmployee(deptId);
			}
		}

		private void btnAll_Click(object sender, System.EventArgs e)
		{
			this.ShowEmployee();
		}
        private void cboRylx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string findStr = this.txtFind.Text;
            findStr = findStr.Replace("'", "''");
            findStr = findStr.Replace("%", "[%]");
            findStr = findStr.Replace("[", "[[]");
            this.ShowEmployee(findStr);
            
        }
		private void txtFind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ( e.KeyCode == Keys.Enter )
			{
                cboRylx_SelectedIndexChanged(null, null);
                //string findStr = this.txtFind.Text;
                //findStr = findStr.Replace("'","''");
                //findStr = findStr.Replace("%","[%]");
                //findStr = findStr.Replace("[","[[]");
                //this.ShowEmployee(findStr);
			}
		}

		private void btnAddDept_Click(object sender, System.EventArgs e)
		{
			FrmDeptProperty fDept = new FrmDeptProperty();
            fDept.Text = "添加部门";
			fDept.ShowDialog();
			if ( fDept.ReturnDepartment != null )
			{
				DataRow dr = InstanceForm.BDatabase.GetDataRow("select * from jc_dept_property where dept_id=" + fDept.ReturnDepartment.DeptId);
				TreeNode node = new TreeNode();
				node.Text = fDept.ReturnDepartment.DeptName;
				DeptInfo deptInfo = new DeptInfo();
				deptInfo.DeptId = fDept.ReturnDepartment.DeptId;
				deptInfo.Level = Convert.ToInt32(dr["layer"]);
				node.Tag = deptInfo;
				bool addSub = false;

				foreach(TreeNode node1 in this.tvwDept.Nodes)
				{
					DeptInfo deptInfo1 = (DeptInfo)node1.Tag;
					if ( deptInfo1.DeptId == Convert.ToInt32(dr["p_dept_id"]))
					{
						node1.Nodes.Add(node);
						addSub = true;
						break;
					}
					else
					{
						foreach(TreeNode node2 in node1.Nodes)
						{
							DeptInfo deptInfo2 = (DeptInfo)node2.Tag;
							if ( deptInfo2.DeptId == Convert.ToInt32(dr["p_dept_id"]))
							{
								node2.Nodes.Add(node);
								addSub = true;
								return;
							}
						}
					}
				}
				if ( addSub != true )
				{
					this.tvwDept.Nodes.Add( node );
				}

			}
		}

		private void btnEditDept_Click(object sender, System.EventArgs e)
		{
			if ( this.tvwDept.SelectedNode == null ) return;
			DeptInfo deptInfo = (DeptInfo)tvwDept.SelectedNode.Tag;
			FrmDeptProperty fDept = new FrmDeptProperty(deptInfo.Level,deptInfo.DeptId);
            fDept.Text = "编辑部门";
			fDept.ShowDialog();
			if ( fDept.ReturnDepartment != null )
				tvwDept.SelectedNode.Text = fDept.ReturnDepartment.DeptName;
		}

		private void btnAddEmp_Click(object sender, System.EventArgs e)
		{
			FrmEmployee fEmployee = new FrmEmployee(_menuTag);
            if (fEmployee.ShowDialog() == DialogResult.OK)
            {
                this.ShowEmployee();
            }
		}

		private void btnEditEmp_Click(object sender, System.EventArgs e)
		{
            try
            {
                if (this.lstEmployee.SelectedItems.Count != 0)
                {
                    object objEmployeeId = lstEmployee.SelectedItems[0].Tag;
                    //lstEmployee.Tag = lstEmployee.SelectedItems[0].Tag;
                    //FrmEmployee fEmployee = new FrmEmployee(_menuTag, Convert.ToInt32(lstEmployee.SelectedItems[0].Tag));
                    FrmEmployee fEmployee = new FrmEmployee(_menuTag, Convert.ToInt32(lstEmployee.SelectedItems[0].Tag));
                    fEmployee.Text = "编辑人员";
                    if (fEmployee.ShowDialog() == DialogResult.OK)
                    {
                        this.ShowEmployee(objEmployeeId);


                    }
                }
            }
            catch { }
		}

		private void btnRefreshDept_Click(object sender, System.EventArgs e)
		{
			this.LoadDepartment();
			this.LoadDeptRoleList();
			this.CreateTree();
			this.ShowEmployee();
		}

		private void btnInvalidData_Click(object sender, System.EventArgs e)
		{
			FrmInvalidData f = new FrmInvalidData();
			f.ShowDialog();
		}

		private void lstEmployee_DoubleClick(object sender, System.EventArgs e)
		{
			if ( this.lstEmployee.SelectedItems.Count == 0 ) return;
			btnEditEmp_Click(null,null);
		}

		private void tvwDept_DoubleClick(object sender, System.EventArgs e)
		{
			if ( this.tvwDept.SelectedNode != null )
			{
				btnEditDept_Click(null,null);
			}
		}

		private void lvwWarddept_DoubleClick(object sender, System.EventArgs e)
		{
			if ( lvwWarddept.SelectedItems.Count == 0 ) return;
			DeptInfo deptInfo = (DeptInfo)lvwWarddept.SelectedItems[0].Tag;
			FrmDeptProperty fDept = new FrmDeptProperty(deptInfo.Level,deptInfo.DeptId);
			fDept.ShowDialog();
			if ( fDept.ReturnDepartment != null )
				lvwWarddept.SelectedItems[0].Text = fDept.ReturnDepartment.DeptName;
		}

        private void btnExport_Click(object sender, EventArgs e)
        {
            ListView lstTmp = lstEmployee as ListView;
            ts_jc_log.ExcelOper.ExportData_ForListView(lstTmp, "科室人员");
        }


	}
}
