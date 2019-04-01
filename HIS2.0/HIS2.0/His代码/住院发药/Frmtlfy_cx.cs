using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using Ts_zyys_public;
using TrasenFrame.Forms;
using YpClass;

namespace ts_yf_zyfy
{
	/// <summary>
	/// Frmyprk 的摘要说明。
	/// </summary>
	public class Frmtlfy_cx : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
        public long _Sqdh;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Splitter splitter1;
		private Crownwood.Magic.Controls.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TreeListView treeListView1;
		private System.Windows.Forms.ColumnHeader 消息时间;
		private System.Windows.Forms.ColumnHeader 发送人;
		private System.Windows.Forms.ColumnHeader 消息备注;
		private System.Windows.Forms.ColumnHeader apply_id;
		private System.Windows.Forms.ColumnHeader nurseid;
		private System.Windows.Forms.ColumnHeader dept_ly;
        private System.Windows.Forms.ColumnHeader groupid;
		private System.Windows.Forms.TreeListView treeListView2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label6;
        private Crownwood.Magic.Controls.TabControl tabControl2;
		private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtypmc;
		private System.Windows.Forms.Button butmxcx;
		private System.Windows.Forms.Button butqc;
		private System.Windows.Forms.Button butref;
		private System.Windows.Forms.DateTimePicker dtptlrq2;
        private System.Windows.Forms.DateTimePicker dtptlrq1;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private System.Windows.Forms.TreeListView treeListView3;
		private System.Windows.Forms.ColumnHeader 发药日期;
		private System.Windows.Forms.ColumnHeader 发药人;
		private System.Windows.Forms.ColumnHeader 配药人;
		private System.Windows.Forms.ColumnHeader 单据号;
		private System.Windows.Forms.ColumnHeader 金额;
		private System.Windows.Forms.ColumnHeader 领药护士;
		private System.Windows.Forms.ColumnHeader 备注;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cmbtype;
		private System.Windows.Forms.ComboBox cmbbs3;
		private System.Windows.Forms.CheckBox chkmx;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Button butprintmx;
		private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butfy;
		private System.Windows.Forms.TextBox txtbz;
		private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGridMx;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.CheckBox chkprintview;
		private System.Windows.Forms.Button butselect;
		private System.Windows.Forms.Button butunselect;
		private Crownwood.Magic.Controls.TabPage  tabPage4;
        private Panel panel9;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader8;
        private Panel panel_dd;
        private StatusBarPanel statusBarPanel3;
        private StatusBarPanel statusBarPanel2;
        private StatusBarPanel statusBarPanel1;
        private StatusBar statusBar1;
        private Panel panel_left;
        private Splitter splitter2;
        private Panel panel_top;
        private Panel panel_chk;
        private Panel panel12;
		private YpConfig ss;

        public Frmtlfy_cx(MenuTag menuTag, string chineseName, Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			_Sqdh=0;
			this.Text =chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
			ss=new YpConfig(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase);

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmtlfy_cx));
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer2 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer3 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeListView3 = new System.Windows.Forms.TreeListView();
            this.发药日期 = new System.Windows.Forms.ColumnHeader();
            this.单据号 = new System.Windows.Forms.ColumnHeader();
            this.备注 = new System.Windows.Forms.ColumnHeader();
            this.发药人 = new System.Windows.Forms.ColumnHeader();
            this.配药人 = new System.Windows.Forms.ColumnHeader();
            this.领药护士 = new System.Windows.Forms.ColumnHeader();
            this.金额 = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkmx = new System.Windows.Forms.CheckBox();
            this.cmbbs3 = new System.Windows.Forms.ComboBox();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.butref = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtptlrq2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtptlrq1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.treeListView2 = new System.Windows.Forms.TreeListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.treeListView1 = new System.Windows.Forms.TreeListView();
            this.消息时间 = new System.Windows.Forms.ColumnHeader();
            this.发送人 = new System.Windows.Forms.ColumnHeader();
            this.消息备注 = new System.Windows.Forms.ColumnHeader();
            this.apply_id = new System.Windows.Forms.ColumnHeader();
            this.nurseid = new System.Windows.Forms.ColumnHeader();
            this.dept_ly = new System.Windows.Forms.ColumnHeader();
            this.groupid = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butfy = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.chkprintview = new System.Windows.Forms.CheckBox();
            this.butprintmx = new System.Windows.Forms.Button();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.myDataGridMx = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel8 = new System.Windows.Forms.Panel();
            this.butunselect = new System.Windows.Forms.Button();
            this.butselect = new System.Windows.Forms.Button();
            this.butqc = new System.Windows.Forms.Button();
            this.butmxcx = new System.Windows.Forms.Button();
            this.txtypmc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel_dd = new System.Windows.Forms.Panel();
            this.panel_chk = new System.Windows.Forms.Panel();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridMx)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel_dd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.panel_left.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 549);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabControl1.BoldSelectedPage = true;
            this.tabControl1.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl1.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl1.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabPage3;
            this.tabControl1.Size = new System.Drawing.Size(305, 522);
            this.tabControl1.Style = Crownwood.Magic.Common.VisualStyle.Plain;
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3});
            this.tabControl1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl1.TextInactiveColor = System.Drawing.Color.Black;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(294, 487);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Tag = "2";
            this.tabPage3.Title = "历史统领单据";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeListView3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 423);
            this.panel3.TabIndex = 1;
            // 
            // treeListView3
            // 
            this.treeListView3.CheckBoxes = true;
            this.treeListView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.发药日期,
            this.单据号,
            this.备注,
            this.发药人,
            this.配药人,
            this.领药护士,
            this.金额});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView3.Comparer = treeListViewItemCollectionComparer1;
            this.treeListView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView3.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListView3.GridLines = true;
            this.treeListView3.Location = new System.Drawing.Point(0, 0);
            this.treeListView3.Name = "treeListView3";
            this.treeListView3.Size = new System.Drawing.Size(294, 423);
            this.treeListView3.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView3.TabIndex = 1;
            this.treeListView3.UseCompatibleStateImageBehavior = false;
            this.treeListView3.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.treeListView3_ItemChecked);
            this.treeListView3.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.treeListView3_ItemCheck);
            // 
            // 发药日期
            // 
            this.发药日期.Text = "发药日期";
            this.发药日期.Width = 188;
            // 
            // 单据号
            // 
            this.单据号.Text = "单据号";
            this.单据号.Width = 55;
            // 
            // 备注
            // 
            this.备注.Text = "备注";
            this.备注.Width = 100;
            // 
            // 发药人
            // 
            this.发药人.Text = "发药人";
            // 
            // 配药人
            // 
            this.配药人.Text = "配药人";
            // 
            // 领药护士
            // 
            this.领药护士.Text = "领药护士";
            // 
            // 金额
            // 
            this.金额.Text = "金额";
            this.金额.Width = 65;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.chkmx);
            this.panel2.Controls.Add(this.cmbbs3);
            this.panel2.Controls.Add(this.cmbtype);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.butref);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtptlrq2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtptlrq1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 64);
            this.panel2.TabIndex = 0;
            // 
            // chkmx
            // 
            this.chkmx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkmx.ForeColor = System.Drawing.Color.Black;
            this.chkmx.Location = new System.Drawing.Point(241, 9);
            this.chkmx.Name = "chkmx";
            this.chkmx.Size = new System.Drawing.Size(53, 21);
            this.chkmx.TabIndex = 12;
            this.chkmx.Text = "明细";
            this.chkmx.Visible = false;
            // 
            // cmbbs3
            // 
            this.cmbbs3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbs3.Location = new System.Drawing.Point(30, 35);
            this.cmbbs3.Name = "cmbbs3";
            this.cmbbs3.Size = new System.Drawing.Size(95, 21);
            this.cmbbs3.TabIndex = 11;
            this.cmbbs3.SelectedIndexChanged += new System.EventHandler(this.cmbbs3_SelectedIndexChanged);
            // 
            // cmbtype
            // 
            this.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtype.Items.AddRange(new object[] {
            "全部",
            "统领",
            "退药"});
            this.cmbtype.Location = new System.Drawing.Point(161, 34);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(76, 21);
            this.cmbtype.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(127, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 16);
            this.label12.TabIndex = 10;
            this.label12.Text = "类型";
            // 
            // butref
            // 
            this.butref.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butref.ForeColor = System.Drawing.Color.Navy;
            this.butref.Location = new System.Drawing.Point(232, 32);
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size(56, 24);
            this.butref.TabIndex = 8;
            this.butref.Text = "刷新(&F)";
            this.butref.Click += new System.EventHandler(this.butref_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(-2, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "病区";
            // 
            // dtptlrq2
            // 
            this.dtptlrq2.Location = new System.Drawing.Point(141, 8);
            this.dtptlrq2.Name = "dtptlrq2";
            this.dtptlrq2.Size = new System.Drawing.Size(96, 21);
            this.dtptlrq2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(124, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "到";
            // 
            // dtptlrq1
            // 
            this.dtptlrq1.Location = new System.Drawing.Point(29, 8);
            this.dtptlrq1.Name = "dtptlrq1";
            this.dtptlrq1.Size = new System.Drawing.Size(96, 21);
            this.dtptlrq1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(-3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "日期";
            // 
            // treeListView2
            // 
            this.treeListView2.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.treeListView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9});
            treeListViewItemCollectionComparer2.Column = 0;
            treeListViewItemCollectionComparer2.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView2.Comparer = treeListViewItemCollectionComparer2;
            this.treeListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView2.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeListView2.GridLines = true;
            this.treeListView2.Location = new System.Drawing.Point(0, 0);
            this.treeListView2.Name = "treeListView2";
            this.treeListView2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeListView2.Size = new System.Drawing.Size(328, 436);
            this.treeListView2.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView2.TabIndex = 4;
            this.treeListView2.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "消息时间";
            this.columnHeader1.Width = 168;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "发送人";
            this.columnHeader2.Width = 67;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "消息备注";
            this.columnHeader3.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "apply_id";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "nurseid";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "dept_ly";
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "groupid";
            this.columnHeader7.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "lyflcode";
            this.columnHeader9.Width = 0;
            // 
            // treeListView1
            // 
            this.treeListView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.treeListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.消息时间,
            this.发送人,
            this.消息备注,
            this.apply_id,
            this.nurseid,
            this.dept_ly,
            this.groupid,
            this.columnHeader8});
            treeListViewItemCollectionComparer3.Column = 0;
            treeListViewItemCollectionComparer3.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView1.Comparer = treeListViewItemCollectionComparer3;
            this.treeListView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeListView1.GridLines = true;
            this.treeListView1.Location = new System.Drawing.Point(0, 0);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeListView1.Size = new System.Drawing.Size(326, 458);
            this.treeListView1.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView1.TabIndex = 3;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            // 
            // 消息时间
            // 
            this.消息时间.Text = "消息时间";
            this.消息时间.Width = 194;
            // 
            // 发送人
            // 
            this.发送人.Text = "发送人";
            this.发送人.Width = 67;
            // 
            // 消息备注
            // 
            this.消息备注.Text = "消息备注";
            this.消息备注.Width = 95;
            // 
            // apply_id
            // 
            this.apply_id.Text = "apply_id";
            this.apply_id.Width = 0;
            // 
            // nurseid
            // 
            this.nurseid.Text = "nurseid";
            this.nurseid.Width = 0;
            // 
            // dept_ly
            // 
            this.dept_ly.Text = "dept_ly";
            this.dept_ly.Width = 0;
            // 
            // groupid
            // 
            this.groupid.Text = "groupid";
            this.groupid.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "lyflcode";
            this.columnHeader8.Width = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(305, 522);
            this.panel1.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.txtbz);
            this.panel6.Controls.Add(this.butquit);
            this.panel6.Controls.Add(this.butprint);
            this.panel6.Controls.Add(this.butfy);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.chkprintview);
            this.panel6.Controls.Add(this.butprintmx);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(960, 46);
            this.panel6.TabIndex = 6;
            // 
            // txtbz
            // 
            this.txtbz.Location = new System.Drawing.Point(166, 14);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(78, 21);
            this.txtbz.TabIndex = 8;
            // 
            // butquit
            // 
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(589, 12);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(64, 28);
            this.butquit.TabIndex = 7;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butprint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butprint.ForeColor = System.Drawing.Color.Navy;
            this.butprint.Location = new System.Drawing.Point(416, 12);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(72, 28);
            this.butprint.TabIndex = 5;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butfy
            // 
            this.butfy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butfy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butfy.ForeColor = System.Drawing.Color.Navy;
            this.butfy.Location = new System.Drawing.Point(332, 12);
            this.butfy.Name = "butfy";
            this.butfy.Size = new System.Drawing.Size(80, 28);
            this.butfy.TabIndex = 4;
            this.butfy.Text = "发药(&O)";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(132, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 24);
            this.label6.TabIndex = 2;
            this.label6.Text = "备注";
            // 
            // chkprintview
            // 
            this.chkprintview.Checked = true;
            this.chkprintview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkprintview.Location = new System.Drawing.Point(248, 14);
            this.chkprintview.Name = "chkprintview";
            this.chkprintview.Size = new System.Drawing.Size(88, 24);
            this.chkprintview.TabIndex = 18;
            this.chkprintview.Text = "打印时预览";
            // 
            // butprintmx
            // 
            this.butprintmx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butprintmx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butprintmx.ForeColor = System.Drawing.Color.Navy;
            this.butprintmx.Location = new System.Drawing.Point(492, 12);
            this.butprintmx.Name = "butprintmx";
            this.butprintmx.Size = new System.Drawing.Size(94, 28);
            this.butprintmx.TabIndex = 6;
            this.butprintmx.Text = "打印明细(&M)";
            this.butprintmx.Visible = false;
            this.butprintmx.Click += new System.EventHandler(this.butprintmx_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabControl2.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.SelectedTab = this.tabPage4;
            this.tabControl2.Size = new System.Drawing.Size(960, 476);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage4});
            this.tabControl2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.TextInactiveColor = System.Drawing.Color.Black;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage4.Controls.Add(this.panel9);
            this.tabPage4.Controls.Add(this.panel8);
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(960, 451);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Title = "消息明细";
            this.tabPage4.Visible = false;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.myDataGridMx);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 40);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(960, 411);
            this.panel9.TabIndex = 2;
            // 
            // myDataGridMx
            // 
            this.myDataGridMx.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.myDataGridMx.CaptionVisible = false;
            this.myDataGridMx.DataMember = "";
            this.myDataGridMx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridMx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGridMx.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGridMx.Location = new System.Drawing.Point(0, 0);
            this.myDataGridMx.Name = "myDataGridMx";
            this.myDataGridMx.ReadOnly = true;
            this.myDataGridMx.SelectionForeColor = System.Drawing.Color.Aquamarine;
            this.myDataGridMx.Size = new System.Drawing.Size(960, 411);
            this.myDataGridMx.TabIndex = 0;
            this.myDataGridMx.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGridMx;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 10;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.butunselect);
            this.panel8.Controls.Add(this.butselect);
            this.panel8.Controls.Add(this.butqc);
            this.panel8.Controls.Add(this.butmxcx);
            this.panel8.Controls.Add(this.txtypmc);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(960, 40);
            this.panel8.TabIndex = 1;
            // 
            // butunselect
            // 
            this.butunselect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.butunselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butunselect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butunselect.ForeColor = System.Drawing.Color.Yellow;
            this.butunselect.Location = new System.Drawing.Point(40, 7);
            this.butunselect.Name = "butunselect";
            this.butunselect.Size = new System.Drawing.Size(40, 27);
            this.butunselect.TabIndex = 11;
            this.butunselect.Text = "反选";
            this.butunselect.UseVisualStyleBackColor = false;
            // 
            // butselect
            // 
            this.butselect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.butselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butselect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butselect.ForeColor = System.Drawing.Color.Yellow;
            this.butselect.Location = new System.Drawing.Point(0, 7);
            this.butselect.Name = "butselect";
            this.butselect.Size = new System.Drawing.Size(40, 27);
            this.butselect.TabIndex = 10;
            this.butselect.Text = "全选";
            this.butselect.UseVisualStyleBackColor = false;
            // 
            // butqc
            // 
            this.butqc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butqc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butqc.ForeColor = System.Drawing.Color.Navy;
            this.butqc.Location = new System.Drawing.Point(624, 5);
            this.butqc.Name = "butqc";
            this.butqc.Size = new System.Drawing.Size(48, 27);
            this.butqc.TabIndex = 9;
            this.butqc.Text = "清除";
            this.butqc.Click += new System.EventHandler(this.butqc_Click);
            // 
            // butmxcx
            // 
            this.butmxcx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butmxcx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butmxcx.ForeColor = System.Drawing.Color.Navy;
            this.butmxcx.Location = new System.Drawing.Point(568, 5);
            this.butmxcx.Name = "butmxcx";
            this.butmxcx.Size = new System.Drawing.Size(48, 27);
            this.butmxcx.TabIndex = 4;
            this.butmxcx.Text = "查询";
            // 
            // txtypmc
            // 
            this.txtypmc.Location = new System.Drawing.Point(152, 8);
            this.txtypmc.Name = "txtypmc";
            this.txtypmc.Size = new System.Drawing.Size(364, 23);
            this.txtypmc.TabIndex = 0;
            this.txtypmc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(88, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "药品名称";
            // 
            // panel_dd
            // 
            this.panel_dd.Controls.Add(this.panel_chk);
            this.panel_dd.Controls.Add(this.statusBar1);
            this.panel_dd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_dd.Location = new System.Drawing.Point(3, 522);
            this.panel_dd.Name = "panel_dd";
            this.panel_dd.Size = new System.Drawing.Size(1273, 27);
            this.panel_dd.TabIndex = 0;
            // 
            // panel_chk
            // 
            this.panel_chk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_chk.Location = new System.Drawing.Point(623, 0);
            this.panel_chk.Name = "panel_chk";
            this.panel_chk.Size = new System.Drawing.Size(650, 27);
            this.panel_chk.TabIndex = 1;
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusBar1.Location = new System.Drawing.Point(0, 0);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(623, 27);
            this.statusBar1.TabIndex = 0;
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
            this.statusBarPanel2.Width = 200;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 200;
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.panel1);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(3, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(305, 522);
            this.panel_left.TabIndex = 8;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(308, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(8, 522);
            this.splitter2.TabIndex = 9;
            this.splitter2.TabStop = false;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.panel6);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(316, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(960, 46);
            this.panel_top.TabIndex = 10;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.tabControl2);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(316, 46);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(960, 476);
            this.panel12.TabIndex = 11;
            // 
            // Frmtlfy_cx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1276, 549);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_dd);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Frmtlfy_cx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "药品统领单查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmtlfy_Load);
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridMx)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel_dd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.panel_left.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void Frmtlfy_Load(object sender, System.EventArgs e)
		{
			try
			{
				//初始化领药明细
				CshMxGrid(this.myDataGridMx);
				if (ss.网络内容显示商品名==true)
					this.myDataGridMx.TableStyles[0].GridColumnStyles["商品名"].Width=120;
				else
					this.myDataGridMx.TableStyles[0].GridColumnStyles["商品名"].Width=0;
				//添加病区列表

                Yp.AddcmbWardDept(cmbbs3, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);


				this.cmbbs3.SelectedIndex=0;
				this.cmbtype.SelectedIndex=0;



				this.dtptlrq1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				this.dtptlrq2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            
                this.tabControl2.TabPages.Remove(this.tabPage4);

                string cc = ApiFunction.GetIniString("药品", "统领明细打印按钮可用", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (cc == "否")
                    butprintmx.Enabled = false;


			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

			
		}


		//初始化领药明细
		private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx  xcjwDataGrid)
		{
			#region 添加统领明细的列

			xcjwDataGrid.TableStyles[0].GridColumnStyles.Clear();

            string[] HeaderText ={ "序号", "选择", "品名", "商品名", "规格", "厂家", "单价", "库存数", "数量", "单位", "金额", "货号", "类型", "剂型", "cjid", "dept_ly", "批发价", "批发金额", "货位号"};
            string[] MappingName = HeaderText;

            int[] ColWidth ={ 45,35,120, 120, 90, 50, 55, 66, 50, 40, 54, 55, 55, 55, 0, 65, 0, 0, 60 };

            bool[] ColReadOnly ={ true, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true};//
            int[] ColBoolButton ={ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0};

			DataTable dtTmp=new DataTable();
			dtTmp.TableName="tbmx";
            this.butprintmx.Visible = true;
			for(int j=0;j<=HeaderText.Length-1;j++)
			{
				//文本列
				if (ColBoolButton[j]==0)
				{
					DataGridEnableTextBoxColumn colText=new DataGridEnableTextBoxColumn(j);
					colText.HeaderText=HeaderText[j];
                   
					colText.MappingName=MappingName[j];
					colText.Width=ColWidth[j];
					colText.NullText="";
					colText.ReadOnly=ColReadOnly[j];
					colText.TextBox.Visible=false;
					
					//colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGridMx_colText_CheckCellEnabled);
					colText.CheckCellEnabled+=new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGridMx_colText_CheckCellEnabled);
					xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
					DataColumn datacol;
					if (MappingName[j].Trim()=="ypsl" || MappingName[j]=="金额" || MappingName[j]=="批发金额")
						datacol=new DataColumn(MappingName[j],Type.GetType("System.Decimal"));
					else
						datacol=new DataColumn(MappingName[j]);
					
					dtTmp.Columns.Add(datacol);
				}
				//布尔列
				if (ColBoolButton[j]==1)
				{
					DataGridEnableBoolColumn colText=new DataGridEnableBoolColumn(j);
					colText.HeaderText=HeaderText[j];
					colText.MappingName=MappingName[j];
					colText.Width=ColWidth[j];
					colText.NullText="0";
					colText.AllowNull=false;
					colText.NullValue= ((short)(0));
					colText.FalseValue= ((short)(0));
					colText.TrueValue= ((short)(1));
					colText.ReadOnly=ColReadOnly[j];
					//colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableBoolColumn.EnableCellEventHandler(myDataGridMx_colText_CheckCellEnabled);
					colText.CheckCellEnabled+=new TrasenClasses.GeneralControls.DataGridEnableBoolColumn.EnableCellEventHandler(myDataGridMx_colText_CheckCellEnabled);
					xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
					dtTmp.Columns.Add(MappingName[j],Type.GetType("System.Int16"));
				}
				//按钮列
				if (ColBoolButton[j]==2)
				{
					DataGridButtonColumn btnCol=new DataGridButtonColumn(j);
					btnCol.Dispose();
					btnCol.HeaderText=HeaderText[j];
					btnCol.MappingName=MappingName[j];
					btnCol.Width=ColWidth[j];
		
					
					xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);


					
					DataColumn datacol;
					datacol=new DataColumn(MappingName[j]);
					dtTmp.Columns.Add(datacol);
				}
				
			}

			xcjwDataGrid.DataSource=dtTmp;
			xcjwDataGrid.TableStyles[0].MappingName ="tbmx";

			#endregion

		}

		
		
		//添加统领单树
		private void AddTldTree(int dept_ly,System.Windows.Forms.TreeListView treeListView,Crownwood.Magic.Controls.TabPage  Tabpage,string sType)
		{
			treeListView.Items.Clear();
			DataTable mytb=(DataTable)this.myDataGridMx.DataSource;
			mytb.Rows.Clear();

			long tldCount=0;
			decimal tldJe=0;

            string ssql = @" select name,a.dept_id from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id
                            where a.dept_id in(
                            select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
            ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm + " ";
            if (dept_ly>0) ssql = ssql + " and  a.dept_id=" + dept_ly + "";
            ssql = ssql + " order by isnull(ward_id,'999999999')";

			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);

            treeListView.SmallImageList = imageList1;
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				//添加病区
                TreeListViewItem itemA = new TreeListViewItem(tb.Rows[i]["name"].ToString(), 0);
				itemA.SubItems.Add("");
				itemA.SubItems.Add("");
				itemA.SubItems.Add("");
				itemA.SubItems.Add("");
				itemA.SubItems.Add("");
				itemA.SubItems.Add("");
                itemA.Tag = tb.Rows[i]["dept_id"].ToString();

				itemA.ForeColor = Color.Black;
				itemA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));	
				treeListView.Items.Add(itemA);
				
			}

            int lylx = 0;
            if (_menuTag.Function_Name == "Fun_ts_yf_zyfy_tld_by_cx")
                lylx = 1;
            SystemCfg cfg=new SystemCfg(8004);
            DataTable tab = ZY_FY.SelectTld(dept_ly, InstanceForm.BCurrentDept.DeptId, this.dtptlrq1.Value.ToShortDateString(), this.dtptlrq2.Value.ToShortDateString(), "", sType, lylx, InstanceForm.BDatabase);
            int ncount = 0;
            for(int i=0;i<=treeListView.Items.Count-1;i++)
			{
				for(int j=0;j<=tab.Rows.Count-1;j++)
				{
                    if (tab.Rows[j]["dept_ly"].ToString().Trim() == treeListView.Items[i].Tag.ToString().Trim())
					{
						TreeListViewItem itemB = new TreeListViewItem(tab.Rows[j]["fyrq"].ToString(), 1);
                        itemB.SubItems.Add(tab.Rows[j]["djh"].ToString());
                        string bz = "";
                        if (_menuTag.Function_Name == "Fun_ts_yf_zyfy_tld_by_cx")
                            bz = "已打印 " + tab.Rows[j]["mxdycs"].ToString() + " 次";
                        else
                            bz = "已打印 " + tab.Rows[j]["hzdycs"].ToString() + " 次";
                        itemB.SubItems.Add(bz);
						itemB.SubItems.Add(tab.Rows[j]["发药人"].ToString().Trim());
						itemB.SubItems.Add(tab.Rows[j]["配药人"].ToString().Trim());
						itemB.SubItems.Add(tab.Rows[j]["护士"].ToString().Trim());
						
						itemB.SubItems.Add(tab.Rows[j]["sumlsje"].ToString());

						
						itemB.Tag=tab.Rows[j]["groupid"].ToString();
						tldCount=tldCount+1;
						tldJe=tldJe+Convert.ToDecimal(tab.Rows[j]["sumlsje"]);
						itemB.BackColor = Color.White;
						itemB.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));	
						treeListView.Items[i].Items.Add(itemB);
                        ncount = ncount + 1;
					}
				}
                if (cfg.Config == "1")
                    treeListView.Items[i].Expand();
                //treeListView.Items[i].Text  = treeListView.Items[i].Text + "  ( " + ncount + " 张)";
                ncount = 0;
			}

			this.statusBar1.Panels[0].Text="统领单张数: "+tldCount.ToString()+" 张";
			this.statusBar1.Panels[1].Text="统领单金额: "+tldJe.ToString("0.00")+" ";
			this.statusBar1.Panels[2].Text="";


		}


		//递归移除tabpage
		private void RemoveTabpage(Crownwood.Magic.Controls.TabControl  tabcontrol)
		{
			for(int i=0;i<=tabcontrol.TabPages.Count-1;i++)
			{
				if (tabcontrol.TabPages[i]!=this.tabPage4)
				{
					tabcontrol.TabPages.Remove(tabcontrol.TabPages[i]);
					RemoveTabpage(tabcontrol);
				}
			}
		}

		//添加统领方式页面
		private void AddtlflPage(DataTable tb)
		{
           
			RemoveTabpage(this.tabControl2);
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				Crownwood.Magic.Controls.TabPage tabPage1=new Crownwood.Magic.Controls.TabPage();
				tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				tabPage1.Location = new System.Drawing.Point(0, 25);
                tabPage1.Name = tb.Rows[i]["类型"].ToString().Trim() == "" ? "其他" : tb.Rows[i]["类型"].ToString().Trim();
                tabPage1.Title = tb.Rows[i]["类型"].ToString();
				tabPage1.Size = new System.Drawing.Size(639, 452);
				tabPage1.Font= new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
																								   tabPage1});

				TrasenClasses.GeneralControls.DataGridEx  myDataGrid1 =new TrasenClasses.GeneralControls.DataGridEx();
				System.Windows.Forms.DataGridTableStyle dataGridTableStyle1=new DataGridTableStyle();
				myDataGrid1.TableStyles.Add(dataGridTableStyle1);

                string[] HeaderText ;
                string[] MappingName;
                int	  [] ColWidth;
                bool[] ColReadOnly;
                HeaderText = new string[] { "序号", "品名", "商品名", "规格", "厂家", "单价", "库存数", "领药数", "缺药数", "单位", "金额", "货号", "cjid", "dwbl", "货位号" };
                MappingName = new string[] { "序号", "品名", "商品名", "规格", "厂家", "单价", "库存数", "领药数", "缺药数", "单位", "金额", "货号", "cjid", "dwbl", "货位号" };
                ColWidth = new int[] { 30, 100, 100, 90, 90, 50, 55, 55, 0, 35, 60, 55, 0, 0, 80 };
                ColReadOnly = new bool[] { true, true, true, true, true, true, true, true, true, false, true, true, true, true, true };
				DataTable dtTmp=new DataTable();
				dtTmp.TableName="tb";
				for(int j=0;j<=HeaderText.Length-1;j++)
				{
					DataGridEnableTextBoxColumn colText=new DataGridEnableTextBoxColumn(j);
					colText.HeaderText=HeaderText[j];
					colText.MappingName=MappingName[j];
					colText.Width=ColWidth[j];
					colText.NullText="";
					colText.ReadOnly=ColReadOnly[j];
					//colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(colText_CheckCellEnabled);
					colText.CheckCellEnabled+=new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(colText_CheckCellEnabled);
					myDataGrid1.TableStyles[0].GridColumnStyles.Add(colText);
					DataColumn datacol=new DataColumn(MappingName[j]);
					dtTmp.Columns.Add(datacol);
				}

				myDataGrid1.DataSource=dtTmp;
				myDataGrid1.TableStyles[0].MappingName ="tb";
				myDataGrid1.CaptionVisible=false;
				myDataGrid1.BackgroundColor = System.Drawing.Color.White;
				myDataGrid1.SelectionBackColor=System.Drawing.Color.White;
				myDataGrid1.ReadOnly=true;
				myDataGrid1.Font= new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				tabPage1.Controls.Add(myDataGrid1);
				myDataGrid1.Dock=System.Windows.Forms.DockStyle.Fill;
				if (ss.网络内容显示商品名==true)
					myDataGrid1.TableStyles[0].GridColumnStyles["商品名"].Width=120;
				else
					myDataGrid1.TableStyles[0].GridColumnStyles["商品名"].Width=0;
				
			}
		}

		

		//添加明细或移除明细的方法
		private void SelectOrRemoveItem(System.Windows.Forms.TreeListView TreeListView,TreeListViewItem item)
		{
			#region 改变选择对象的颜色
			if (item.ImageIndex==0) return;
			if (item.BackColor!=Color.GreenYellow)
			{
				#region 判断选择了哪个科室
				bool Byes=false;
				for(int i=0;i<=TreeListView.Items.Count-1;i++)
				{
					//如果当前节点是科室并且已选中
					if (TreeListView.Items[i].ImageIndex==0 && TreeListView.Items[i].BackColor==Color.GreenYellow)
					{
						//如果正要选择的节点的父节点与已选择的科室不同
						if (item.Parent.Tag.ToString().Trim()!=TreeListView.Items[i].Tag.ToString().Trim())
						{
							if(MessageBox.Show(this, "因为不能跨科室选择消息,当前操作将取消原有的选择,您确认继续吗?", "确认",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No ) return;
							Byes=true;
						}
					}
				}

				//如果确认跨科室
				if (Byes==true)
				{
					DataTable tbb=(DataTable)this.myDataGridMx.DataSource;
					tbb.Rows.Clear();
					for(int i=0;i<=TreeListView.Items.Count-1;i++)
						this.ChangeTreeItemColorToWhite(TreeListView.Items[i]);
				}
				#endregion

				item.BackColor=Color.GreenYellow;
				item.SubItems[0].BackColor=Color.GreenYellow;
				item.SubItems[1].BackColor=Color.GreenYellow;
				item.SubItems[2].BackColor=Color.GreenYellow;
				item.SubItems[3].BackColor=Color.GreenYellow;
				item.Selected=false;
			}
			else
			{
				item.BackColor=Color.White ;
				item.SubItems[0].BackColor=Color.White;
				item.SubItems[1].BackColor=Color.White;
				item.SubItems[2].BackColor=Color.White;
				item.SubItems[3].BackColor=Color.White;
				item.Selected=false;
			}
			#endregion

			#region 改变父对象的颜色
			bool bflag=false;
			for(int i=0;i<=item.Parent.Items.Count-1;i++)
			{
				if (item.Parent.Items[i].BackColor==Color.GreenYellow)
				{
					bflag=true;
				}
			}

			if (bflag==true)
			{
				item.Parent.SubItems[0].BackColor=Color.GreenYellow   ;
				item.Parent.SubItems[1].BackColor=Color.GreenYellow;
				item.Parent.SubItems[2].BackColor=Color.GreenYellow;
				item.Parent.SubItems[3].BackColor=Color.GreenYellow;
				item.Parent.Selected=false;
			}
			else
			{
				item.Parent.SubItems[0].BackColor=Color.White;
				item.Parent.SubItems[1].BackColor=Color.White;
				item.Parent.SubItems[2].BackColor=Color.White;
				item.Parent.SubItems[3].BackColor=Color.White;
				item.Parent.Selected=false;
			}
			#endregion

			#region 查询或去除明细 
			DataTable tb=(DataTable)this.myDataGridMx.DataSource;            
            if (new Guid(Convertor.IsNull(this.myDataGridMx.Tag,Guid.Empty.ToString()))!=Guid.Empty) tb.Rows.Clear();            
			DataTable tbmx=new DataTable();
			//查询或去除明细
			if (item.BackColor!=Color.White )
			{
				DataTable tab=tb.Copy();/////////////////////////////
				tbmx=ZY_FY.SelectMassageMx(item.SubItems[7].Text, item.Tag.ToString(),item.SubItems[0].Text,item.Parent.Tag.ToString(),0,InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                if (tbmx.Rows.Count == 0)
                {
                    ZY_FY.UpdateMsg_Delete(new Guid(item.Tag.ToString()), InstanceForm.BDatabase);
                }
                //if (tb.Rows.Count != 0)
                //{
                //    for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                //    {
                //        tbmx.Rows[i]["序号"] = tab.Rows.Count + 1;
                //        tbmx.Rows[i]["类型"] = tbmx.Rows[i]["类型"].ToString().Trim() == "" ? "其它" : tbmx.Rows[i]["类型"];
                //        tab.ImportRow(tbmx.Rows[i]);
                //    }
                //}
                //else
                //{
                //    tab = tbmx;
                //    //ZY_FY.UpdateMsg_Delete(new Guid(item.Tag.ToString()));
                //}
                tab.TableName = "tbmx";
                FunBase.AddRowtNo(tab);
                
				
				
				//this.myDataGridMx.DataSource=tab;
                FunBase.AddRowtNo(tbmx);
                this.myDataGridMx.DataSource = GetDatatableForGrid(tbmx, false);
                //tab
			}
			else
			{
				DataTable tbmxCopy=tb.Clone();                
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (new Guid(tb.Rows[i]["apply_id"].ToString().Trim()) != new Guid(item.Tag.ToString().Trim()))
                        tbmxCopy.ImportRow(tb.Rows[i]);                  
                }
				tb.Rows.Clear();
                FunBase.AddRowtNo(tbmxCopy);
				this.myDataGridMx.DataSource=tbmxCopy;
			}

            //汇总当前的分类
            DataTable tbMx = (DataTable)myDataGridMx.DataSource;
            string[] GroupbyField1 ={ "类型" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };
            TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
            xcset1.TsDataTable = tbMx;
            DataTable tbfl = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "选择=true");///////////////////

            DataTable tbfl2 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
            panel_chk.Controls.Clear();
            for (int i = 0; i <= tbfl2.Rows.Count - 1; i++)
            {

                CheckBox checkBox1;
                checkBox1 = new System.Windows.Forms.CheckBox();
                panel_chk.Controls.Add(checkBox1);
                checkBox1.AutoSize = true;
                checkBox1.Dock = System.Windows.Forms.DockStyle.Left;
                checkBox1.Location = new System.Drawing.Point(0, 0);
                checkBox1.Name = "checkBox" + i.ToString();
                checkBox1.Size = new System.Drawing.Size(77, 40);
                checkBox1.TabIndex = 4;
                checkBox1.Text = tbfl2.Rows[i]["类型"].ToString();
                checkBox1.UseVisualStyleBackColor = true;
                checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
            }


//			DataTable tt=(DataTable)this.myDataGridMx.DataSource;
//			decimal sumje=0;
//			for(int i=0;i<=tt.Rows.Count-1;i++)
//				sumje=sumje+Convert.ToDecimal(tt.Rows[i]["金额"]);
//			this.Text=sumje.ToString();
			#endregion 
		}
	
		



		//点击统领单时
		private void treeListView3_Click(object sender, System.EventArgs e)
		{
			
		}

        /// <summary>
        /// jianqg 20133-5-7增加
        /// </summary>
        /// <param name="tbSource"></param>
        /// <param name="ClearOldData"></param>
        private DataTable GetDatatableForGrid(DataTable tbSource, bool ClearOldData)
        {
            DataTable tb=(DataTable)this.myDataGridMx.DataSource;
            DataTable tab = tb.Clone();
            if (ClearOldData==false) tab = tb.Copy();
            for (int i = 0; i <= tbSource.Rows.Count - 1; i++)
            {

                tab.ImportRow(tbSource.Rows[i]);
            }

            return tab;
        }
        

		
		//生成统领单
		private void  computeTld()
		{
			this.myDataGridMx.Tag=null;
			this.statusBar1.Panels[2].Text="";
			decimal sumlsje=0;

			DataTable tb=(DataTable)this.myDataGridMx.DataSource;

			//汇总当前的分类
			string[] GroupbyField1	={"类型"};
			string[] ComputeField1	={};
			string[] CField1	={};
			TrasenFrame.Classes.TsSet  xcset1=new TrasenFrame.Classes.TsSet();
			xcset1.TsDataTable=tb;
			DataTable tbfl=xcset1.GroupTable(GroupbyField1,ComputeField1,CField1,"选择=true");///////////////////


			//添加分类页面
            AddtlflPage(tbfl);//
            string[] GroupbyField ={ "货号", "品名", "商品名", "规格", "厂家", "库存数", "cjid","批发价", "lsj", "dwbl", "zxdw", "货位号"};/////,"ifby"
			string[] ComputeField	={"ypsl","金额"};
			string[] CField	={"sum","sum"};

			TrasenFrame.Classes.TsSet xcset=new TrasenFrame.Classes.TsSet();
			xcset.TsDataTable=tb;                                   
			for(int i=1;i<=this.tabControl2.TabPages.Count -1;i++)
			{
				for(int j=0;j<=	this.tabControl2.TabPages[i].Controls.Count-1;j++)
				{
					//如果是网格
					if (this.tabControl2.TabPages[i].Controls[j].GetType().ToString()=="TrasenClasses.GeneralControls.DataGridEx")
					{
						//汇总每个统领分类
						//DataTable tab=xcset.GroupTable(GroupbyField,ComputeField,CField," 类型='"+this.tabControl2.TabPages[i].Title.Trim()+"' and 选择=true");

						DataTable tab;
						DataRow[] selrow=tb.Select(" 类型='"+this.tabControl2.TabPages[i].Title.Trim()+"' and 选择=true");
						DataTable tbsel=tb.Clone();
						for(int w=0;w<=selrow.Length-1;w++)
							tbsel.ImportRow(selrow[w]);
						tab=FunBase.GroupbyDataTable(tbsel,GroupbyField,ComputeField,CField,null);
						
						TrasenClasses.GeneralControls.DataGridEx mydatagrid=(TrasenClasses.GeneralControls.DataGridEx)this.tabControl2.TabPages[i].Controls[j];
						DataTable mytb=(DataTable)mydatagrid.DataSource;
						mytb.Rows.Clear();
                        DataRow[] rows = tab.Select("", "货位号,品名 asc");

                        //添加数据
                        #region 添加数据
                        for (int x=0;x<=rows.Length-1;x++)
						{
							DataRow row=mytb.NewRow();
							row["序号"]=x+1;
							row["品名"]=rows[x]["品名"];
							row["商品名"]=rows[x]["商品名"];
							row["规格"]=rows[x]["规格"];
							row["厂家"]=rows[x]["厂家"];
                            row["单价"] = rows[x]["lsj"];
							
                            decimal ypsl = Convert.ToDecimal(Convertor.IsNull(rows[x]["ypsl"], "0"));
                            decimal kcl = Convert.ToDecimal(Convertor.IsNull(rows[x]["库存数"], "0"));
                            float _ypsl = (float)ypsl;
                            float _kcl = (float)kcl;
                            row["库存数"] = kcl.ToString();// rows[x]["库存数"];
                            row["领药数"] = ypsl.ToString();// rows[x]["ypsl"];
							row["缺药数"]=(kcl-ypsl)<0?System.Math.Abs(kcl-ypsl):0;
                            row["单位"] = Yp.SeekYpdw(Convert.ToInt32(rows[x]["zxdw"]), InstanceForm.BDatabase);
							row["金额"]=rows[x]["金额"];
							row["货号"]=rows[x]["货号"];
							row["cjid"]=rows[x]["cjid"];
							row["dwbl"]=rows[x]["dwbl"];
                            row["货位号"] = rows[x]["货位号"];
							//sumlsje=sumlsje+Convert.ToDecimal(Convertor.IsNull(rows[x]["金额"],"0"));
							sumlsje=sumlsje+(Convert.IsDBNull(rows[x]["金额"]) ? 0:Convert.ToDecimal(rows[x]["金额"])); 
							mytb.Rows.Add(row);
                        }

                        #endregion
                    }
				}
			}
            
			this.statusBar1.Panels[2].Text="当前单据金额:"+sumlsje.ToString("0.00");

			PubStaticFun.ModifyDataGridStyle(this.myDataGridMx,0);
			
		}

        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox chk=(CheckBox)sender;
            DataTable tb = (DataTable)this.myDataGridMx.DataSource;

            DataRow[] rows = tb.Select("类型='"+chk.Text+"'");
            for (int i = 0; i <= rows.Length - 1; i++)
                rows[i]["选择"] = chk.Checked == true ? (short)1 :(short)0;
            computeTld();
        }



		
		//关闭窗口
		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}



		
		#region 不般控制
		//清除页面
		private void ClearData()
		{

			DataTable tbmx=(DataTable)this.myDataGridMx.DataSource;
			tbmx.Rows.Clear();

			for(int i=1;i<=this.tabControl2.TabPages.Count -1;i++)
			{
				for(int j=0;j<=	this.tabControl2.TabPages[i].Controls.Count-1;j++)
				{
					//如果是网格
					if (this.tabControl2.TabPages[i].Controls[j].GetType().ToString()=="TrasenClasses.GeneralControls.DataGridEx")
					{					
						TrasenClasses.GeneralControls.DataGridEx  mydatagrid=(TrasenClasses.GeneralControls.DataGridEx)this.tabControl2.TabPages[i].Controls[j];
						DataTable mytb=(DataTable)mydatagrid.DataSource;
						mytb.Rows.Clear();
					}
				}  
			}
		}

		//输入项目
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" ){control.Text="";control.Tag="0";}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)==""))){}
			else{return;}

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
						GrdMappingName=new string[] {"ggid","cjid","行号","品名","规格","厂家","库存量","单位","禁用","DWBL","批发价","零售价","货号","拼音码","五笔码"};
						GrdWidth=new int[] {0,0,50,200,100,100,65,40,40,0,60,60,70,60,60};
						sfield=new string[] {"wbm","pym","szm","ywm","ypbm"};
                        ssql = "select distinct a.ggid,cjid,0  rowno,yppm,ypgg,s_sccj sccj,cast(kcl as float) kcl,dbo.fun_yp_ypdw(ypdw) ypdw,(case when bdelete_kc=1 then '√' else '' end) jy,1 dwbl,pfj,lsj,shh,pym,wbm from vi_yf_kcmx a,yp_ypbm b " +
								"where a.ggid=b.ggid and deptid="+InstanceForm.BCurrentDept.DeptId+"  and a.ypzlx in(select ypzlx from yp_gllx where deptid="+InstanceForm.BCurrentDept.DeptId+")  ";

                        TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
						f2.Location=point;
						f2.Width=700;
						f2.Height=300;
						f2.ShowDialog(this);
						row=f2.dataRow;
						if (row!=null) 
						{
							control.Text=row["yppm"].ToString();
							control.Tag=row["cjid"].ToString();
							this.SelectNextControl((Control)sender,true,false,true,true);

                            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                            DataRow[] rowX = tb.Select("cjid=" + row["cjid"].ToString() + "");
                            if (rowX.Length > 0)
                            {
                                int nrow = Convert.ToInt32(rowX[0]["序号"]);
                                this.myDataGridMx.CurrentCell = new DataGridCell(nrow-1, 1);

                            }
						}
						break;

				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("发生错误"+err.Message);
			}

		}




		//刷新统领消息
		private void butref_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
                AddTldTree(Convert.ToInt32(Convertor.IsNull(cmbbs3.SelectedValue, "0")), this.treeListView3, this.tabPage3, this.cmbtype.Text.Trim());
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}
		
		//选择是是统领？退药？统领单?
		private void tabControl1_Click(object sender, System.EventArgs e)
		{
			try
			{


				if (this.tabControl1.SelectedTab==this.tabPage3)
				{
					//CshMxGrid(this.myDataGridMx);
					this.myDataGridMx.TableStyles[0].GridColumnStyles[1].Width=0;
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[2].Width = 35;//0
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[3].Width = 55;//0
					DataTable tbb=(DataTable)this.myDataGridMx.DataSource;
					tbb.Rows.Clear();
					//重新统计汇总单
					computeTld();

					butfy.Enabled=false;
				}

				this.statusBar1.Panels[0].Text="";
				this.statusBar1.Panels[1].Text="";
				this.statusBar1.Panels[2].Text="";
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}


		}

		
		//清除
		private void butqc_Click(object sender, System.EventArgs e)
		{
			this.txtypmc.Text="";
		}

		
		private void cmbbs3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            AddTldTree(Convert.ToInt32(Convertor.IsNull(this.cmbbs3.SelectedValue, "0")), this.treeListView3, this.tabPage3, this.cmbtype.Text.Trim());
		}

		//将消息的变景变成白色
		private void ChangeTreeItemColorToWhite(System.Windows.Forms.TreeListViewItem item)
		{
			item.BackColor=Color.White;
			item.SubItems[0].BackColor=Color.White;
			item.SubItems[1].BackColor=Color.White;
			item.SubItems[2].BackColor=Color.White;
			item.SubItems[3].BackColor=Color.White;
			item.Selected=false;

			for(int i=0;i<=item.Items.Count-1;i++)
			{
				item.Items[i].BackColor=Color.White;
				item.Items[i].SubItems[0].BackColor=Color.White;
				item.Items[i].SubItems[1].BackColor=Color.White;
				item.Items[i].SubItems[2].BackColor=Color.White;
				item.Items[i].SubItems[3].BackColor=Color.White;
				item.Items[i].Selected=false;
				ChangeTreeItemColorToWhite(item.Items[i]);
			}
		}

		//列颜色改变事件
		private void colText_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
		{
			e.BackColor=Color.White;
			DataGridEnableTextBoxColumn column=(DataGridEnableTextBoxColumn)sender;
			DataTable tb=(DataTable)column.DataGridTableStyle.DataGrid.DataSource  ;
			if (e.Row>tb.Rows.Count-1) return;
			if (Convert.ToDecimal(Convertor.IsNull(tb.Rows[e.Row]["领药数"],"0"))>Convert.ToDecimal(Convertor.IsNull(tb.Rows[e.Row]["库存数"],"0")))
				e.ForeColor=Color.Red;
			else
				e.ForeColor=Color.Black;
			
			
		}

		//列颜色改变事件
		private void myDataGridMx_colText_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
		{
			try
			{
				e.BackColor=Color.White;
				DataTable tb;
				if (sender.GetType().ToString()=="TrasenClasses.GeneralControls.DataGridEnableBoolColumn")
				{
					DataGridEnableBoolColumn column=(DataGridEnableBoolColumn)sender;
					tb=(DataTable)column.DataGridTableStyle.DataGrid.DataSource; 
				}
				else
				{
					DataGridEnableTextBoxColumn column=(DataGridEnableTextBoxColumn)sender;
					tb=(DataTable)column.DataGridTableStyle.DataGrid.DataSource; 
				}



				if (e.Row>tb.Rows.Count-1) return;
                if (Convert.ToBoolean(tb.Rows[e.Row]["选择"]) == false)
                    e.ForeColor = Color.Gray;
                else
                {
                    decimal sl_kc = 0;
                    if(Convert.ToString(tb.Rows[e.Row]["库存数"])!="") 
                        sl_kc=Convert.ToDecimal(tb.Rows[e.Row]["库存数"]);
                    if (Convert.ToDecimal(tb.Rows[e.Row]["数量"]) > sl_kc)
                        e.ForeColor = Color.Red;
                    else
                        e.ForeColor = Color.Blue;
                }

                if (e.Row == this.myDataGridMx.CurrentCell.RowNumber)
                    e.BackColor = Color.Yellow;
                else
                {
                        e.BackColor = Color.White;
                }
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
//			
		}



		#endregion

        #region 打印按钮
        private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
                //Guid _groupid=new Guid(Convertor.IsNull(this.myDataGridMx.Tag,Guid.Empty.ToString()));
                ////_groupid = new Guid(Convertor.IsNull("691aa94e-90ff-403a-aaa4-a0d60006ebc0", Guid.Empty.ToString()));
                //if (_groupid == Guid.Empty)
                //{
                //    MessageBox.Show("必须发药后才能打印单据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                //更新打印次数
                //string ssql = "update yf_tld set hzdycs=hzdycs+1 where groupid='" + _groupid + "'";
                //int n = InstanceForm.BDatabase.DoCommand(ssql);
                //if (n == 0)
                //{

                //    ssql = "update yf_tld_h set hzdycs=hzdycs+1 where groupid='" + _groupid + "'";
                //    n = InstanceForm.BDatabase.DoCommand(ssql);
                //}

                //查询统领汇总单
                DataTable tb = null;
                for (int i = 0; i <= treeListView3.Items.Count - 1; i++)
                {
                    for (int j = 0; j <= treeListView3.Items[i].Items.Count - 1; j++)
                    {
                        if (treeListView3.Items[i].Items[j].Checked == true)
                        {
                            DataTable tb_g = ZY_FY.SelectTldHz(treeListView3.Items[i].Items[j].Tag.ToString(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                            if (tb == null) tb = tb_g.Clone();
                            for (int x = 0; x <= tb_g.Rows.Count - 1; x++)
                                tb.ImportRow(tb_g.Rows[x]);
                        }
                    }
                }

                //DataTable tb = ZY_FY.SelectTldHz(_groupid.ToString(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase); 
                if (this.tabControl1.SelectedTab == this.tabPage3 || tb.Rows.Count == 0)
                {
                    #region 权限确认
                    try
                    {
                        if ((new SystemCfg(8008)).Config == "1")
                        {
                            string dlgvalue = DlgPW.Show();
                            string pwStr = dlgvalue; //YS.Password;
                            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                            if (!bOk)
                            {
                                FrmMessageBox.Show("你没有通过权限确认，不能发药！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion
                }
                this.Cursor = PubStaticFun.WaitCursor();
               
                PrintInfo(tb, System.Guid.Empty);
                
                
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
        }
        #endregion

        #region 打印方法
        private void PrintInfo(DataTable tb, Guid _groupid)
        {

            string djh = "";
            string lydw = "";
            for (int i = 0; i <= treeListView3.Items.Count - 1; i++)
            {
                bool bok = false;
                for (int j = 0; j <= treeListView3.Items[i].Items.Count - 1; j++)
                {
                    if (treeListView3.Items[i].Items[j].Checked == true)
                    {
                        if (djh == "")
                            djh = treeListView3.Items[i].Items[j].SubItems[1].Text;
                        else
                            djh = djh + "," + treeListView3.Items[i].Items[j].SubItems[1].Text;

                        bok = true;
                    }
                }

                if (bok == true)
                {
                    if (lydw == "")
                        lydw = treeListView3.Items[i].Text;
                    else
                        lydw = lydw + "," + treeListView3.Items[i].Text;
                }
            }

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();

            if (tb.Rows.Count == 0) return;
            //string lydw = Yp.SeekDeptName(Convert.ToInt32(tb.Rows[0]["dept_ly"]), InstanceForm.BDatabase);
            string fyr = Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["fyr"]), InstanceForm.BDatabase);
            string pyr = Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["pyr"]), InstanceForm.BDatabase);
            DataRow myrow;

            DataTable tbmx = tb.Copy();
            string[] GroupbyField ={ "类型", "yppm", "ypspm", "ypgg", "sccj", "lsj", "ypdw", "shh", "cjid", "ydwbl", "hwh","ypjx" };/////,"ifby"
            string[] ComputeField ={ "ypsl", "lsje" };
            string[] CField ={ "sum", "sum" };
            DataTable tab = FunBase.GroupbyDataTable(tbmx, GroupbyField, ComputeField, CField, null);
            DataRow[] rows = tab.Select("", "hwh,yppm");
            for (int i = 0; i <= rows.Length - 1; i++)
            {

                    myrow = Dset.发药明细单.NewRow();
                    myrow["yppm"] = Convert.ToString(rows[i]["yppm"]);
                    myrow["ypspm"] = Convert.ToString(rows[i]["ypspm"]);
                    myrow["ypgg"] = Convert.ToString(rows[i]["ypgg"]);
                    myrow["sccj"] = Convert.ToString(rows[i]["sccj"]);
                    myrow["lsj"] = Convert.ToDecimal(rows[i]["lsj"]);
                    myrow["ypsl"] = Convert.ToDecimal(rows[i]["ypsl"]);
                    myrow["ypdw"] = Convert.ToString(rows[i]["ypdw"]);
                    myrow["lsje"] = Convert.ToDecimal(rows[i]["lsje"]);
                    myrow["shh"] = Convert.ToString(rows[i]["shh"]);
                    myrow["hwh"] = Convert.ToString(rows[i]["hwh"]);
                    myrow["tlfl"] = Convert.ToString(rows[i]["类型"]) + " ( No." + djh.ToString() + " )";
                    myrow["fyrq"] = Convert.ToString(tb.Rows[0]["fyrq"]);
                    myrow["fyr"] = fyr;
                    myrow["pyr"] = pyr;
                    myrow["lydw"] = lydw;
                    myrow["bz"] = Convert.ToDecimal(rows[i]["ypsl"]) >= 0 ? "" : "退药";
                    myrow["groupid"] = "( No." + djh.ToString() + " )";
                    myrow["ypjx"] = Convert.ToString(rows[i]["ypjx"]);
                    Dset.发药明细单.Rows.Add(myrow);

            }


            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Text = "title";
            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "" + InstanceForm.BCurrentDept.DeptName + tb.Rows[0]["stype"].ToString().Trim() + "" + "单";            
            parameters[1].Text = "lydwHeadText";
            parameters[1].Value = tb.Rows[0]["stype"].ToString().Trim() == "统领" ? "领药病室:" : "退药病室:";            
            parameters[2].Text = "dycs";
            int dycs = 0;
            if (tb.Rows[0]["hzdycs"].ToString() == "0")
                dycs = 1;
            else
                dycs = Convert.ToInt32(tb.Rows[0]["hzdycs"].ToString()) + 1;

            parameters[2].Value = dycs.ToString();

            string[] str ={ "" };
           // str[0] = "update yf_tld set hzdycs=hzdycs+1 where groupid='" + _groupid + "'";
            bool bview = this.chkprintview.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_药品统领单.rpt", parameters, bview);
            f._sqlStr = str;
            if (f.LoadReportSuccess) f.Show(); else f.Dispose();
        }
        #endregion






        #region 打印明细按钮
        private void butprintmx_Click(object sender, EventArgs e)
        {
            try
            {
                Guid _groupid = new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString()));
                ////_groupid = new Guid(Convertor.IsNull("47BD001F-AB4A-4AB5-AF27-A0D700D59CE7", Guid.Empty.ToString()));
                //if (_groupid == Guid.Empty)
                //{
                //    MessageBox.Show("必须发药后才能打印单据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (_groupid == Guid.Empty) return;

                string ssql = "select * from vi_yf_tld where groupid='" + _groupid.ToString() + "'";
                DataTable tbtld = InstanceForm.BDatabase.GetDataTable(ssql);


                //查询统领汇总单
                DataTable tb = null;
                for (int i = 0; i <= treeListView3.Items.Count - 1; i++)
                {
                    for (int j = 0; j <= treeListView3.Items[i].Items.Count - 1; j++)
                    {
                        if (treeListView3.Items[i].Items[j].Checked == true)
                        {
                            DataTable tb_g = ZY_FY.SelectTldMx(treeListView3.Items[i].Items[j].Tag.ToString(), InstanceForm.BDatabase);
                            if (tb == null) tb = tb_g.Clone();
                            for (int x = 0; x <= tb_g.Rows.Count - 1; x++)
                                tb.ImportRow(tb_g.Rows[x]);
                        }
                    }
                }

                //DataTable tb = ZY_FY.SelectTldMx(_groupid.ToString(), InstanceForm.BDatabase);
                this.Cursor = PubStaticFun.WaitCursor();

                if (this.tabControl1.SelectedTab == this.tabPage3 || tb.Rows.Count == 0)
                {
                    #region 权限确认
                    try
                    {
                        if ((new SystemCfg(8008)).Config == "1")
                        {
                            string dlgvalue = DlgPW.Show();
                            string pwStr = dlgvalue; //YS.Password;
                            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                            if (!bOk)
                            {
                                FrmMessageBox.Show("你没有通过权限确认，不能发药！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion
                }                              
                Print_FYMXInfo(tb,_groupid,tbtld);                

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion

        #region 打印明细方法
        private void Print_FYMXInfo(DataTable tb, Guid _groupid, DataTable tbtld)
        {
            string djh = "";
            string lydw = "";
            for (int i = 0; i <= treeListView3.Items.Count - 1; i++)
            {
                bool bok = false;
                for (int j = 0; j <= treeListView3.Items[i].Items.Count - 1; j++)
                {
                    if (treeListView3.Items[i].Items[j].Checked == true)
                    {
                        if (djh == "")
                            djh = treeListView3.Items[i].Items[j].SubItems[1].Text;
                        else
                            djh = djh + "," + treeListView3.Items[i].Items[j].SubItems[1].Text;

                        bok = true;
                    }
                }

                if (bok == true)
                {
                    if (lydw == "")
                        lydw = treeListView3.Items[i].Text;
                    else
                        lydw = lydw + "," + treeListView3.Items[i].Text;
                }
            }

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();

            if (tb.Rows.Count == 0) return;
           // string lydw = Yp.SeekDeptName(Convert.ToInt32(tbtld.Rows[0]["dept_ly"]), InstanceForm.BDatabase);
            string fyr = Yp.SeekEmpName(Convert.ToInt32(tbtld.Rows[0]["fyr"]), InstanceForm.BDatabase);
            string pyr = Yp.SeekEmpName(Convert.ToInt32(tbtld.Rows[0]["pyr"]), InstanceForm.BDatabase);
            string fyrq = tbtld.Rows[0]["fyrq"].ToString();
            


            DataRow myrow;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                myrow = Dset.住院药品摆药明细.NewRow();
                myrow["yppm"] = Convert.ToString(tb.Rows[i]["品名"]);
                myrow["ypspm"] = Convert.ToString(tb.Rows[i]["商品名"]);
                myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);
                myrow["sccj"] = Convert.ToString(tb.Rows[i]["厂家"]);
                myrow["lsj"] = Convert.ToDecimal(tb.Rows[i]["单价"]);////////////////lsj 单价
                myrow["ypsl"] = Convert.ToDecimal(tb.Rows[i]["数量"]);
                myrow["ypdw"] = Convert.ToString(tb.Rows[i]["单位"]);
                myrow["lsje"] = Convert.ToDecimal(tb.Rows[i]["金额"]);
                myrow["shh"] = Convert.ToString(tb.Rows[i]["货号"]);
                //myrow["tlfl"] = Convert.ToString(tb.Rows[i]["类型"]) + " ( No." + tb.Rows[0]["djh"].ToString() + " )";
                myrow["fyrq"] = fyrq;
                myrow["fyr"] = fyr;
                myrow["pyr"] = pyr;
                myrow["lydw"] = lydw;
                myrow["mcyl"] = Convert.ToString(tb.Rows[i]["mcyl"]);
                myrow["mcdw"] = Convert.ToString(tb.Rows[i]["mcdw"]);
                myrow["yf"] = Convert.ToString(tb.Rows[i]["用法"]);
                myrow["pc"] = Convert.ToString(tb.Rows[i]["频次"]);
                //myrow["ryrq"] = Convert.ToString(tb.Rows[i]["ryrq"]);
                myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["dept_id"], "0")), InstanceForm.BDatabase);
                myrow["rowno"] = i;
                myrow["lydw"] = lydw;
                myrow["bed_no"] = Convert.ToString(tb.Rows[i]["床号"]);
                myrow["inpatient_no"] = Convert.ToString(tb.Rows[i]["住院号"]);
                myrow["name"] = Convert.ToString(tb.Rows[i]["姓名"]);
                myrow["cfrq"] = Convert.ToString(tb.Rows[i]["presc_date"]);
                myrow["MNGTYPE"] = Convert.ToString(tb.Rows[i]["MNGTYPE"]);////////////改printBZ
                myrow["gysj"] = Convert.ToString(tb.Rows[i]["gysj"]);
                myrow["ypjx"] = Convert.ToString(tb.Rows[i]["剂型"]);
                Dset.住院药品摆药明细.Rows.Add(myrow);


            }



            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Text = "titletext";
            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "" + InstanceForm.BCurrentDept.DeptName + "摆药单";           
            parameters[1].Text = "yfmc";
            parameters[1].Value = InstanceForm.BCurrentDept.DeptName;
            parameters[2].Text = "djh";
            parameters[2].Value = djh;
            parameters[3].Text = "dycs";

            int dycs = 0;
            if (tbtld.Rows[0]["mxdycs"].ToString() == "0")
                dycs = 1;
            else
                dycs = Convert.ToInt32(tbtld.Rows[0]["mxdycs"].ToString()) + 1;

            parameters[3].Value = dycs.ToString();

            string[] str ={ "" };
            str[0] = "update yf_tld set mxdycs=mxdycs+1 where groupid='" + _groupid + "'";
            bool bview = this.chkprintview.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.住院药品摆药明细, Constant.ApplicationDirectory + "\\Report\\YF_住院摆药单.rpt", parameters, bview, str);
            f._sqlStr = str;
            if (f.LoadReportSuccess) f.Show(); else f.Dispose();
        }

        #endregion

        private void treeListView3_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void treeListView3_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {

                decimal sumlsje = 0;
                this.statusBar1.Panels[2].Text = "";
                this.Cursor = PubStaticFun.WaitCursor();
                RemoveTabpage(this.tabControl2);
                //TreeListViewItem item = treeListView3.SelectedItems[0];
                //if (item.ImageIndex == 0) return;

                //查询统领汇总单
                DataTable tb = null;
                for (int i = 0; i <= treeListView3.Items.Count - 1; i++)
                {
                    for (int j = 0; j <= treeListView3.Items[i].Items.Count - 1; j++)
                    {
                        if (treeListView3.Items[i].Items[j].Checked == true)
                        {
                            DataTable tb_g = ZY_FY.SelectTldHz(treeListView3.Items[i].Items[j].Tag.ToString(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                            if (tb == null) tb = tb_g.Clone();
                            for (int x = 0; x <= tb_g.Rows.Count - 1; x++)
                                tb.ImportRow(tb_g.Rows[x]);
                        }
                    }
                }
                if (e.Item.ImageIndex!=0)
                    this.myDataGridMx.Tag = e.Item.Tag.ToString();
                if (tb == null) return;

                //汇总当前的统领分类
                string[] GroupbyField1 ={ "类型" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                DataTable tbfl = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");

                //添加分类页面
                this.AddtlflPage(tbfl);


                string[] GroupbyField ={ "类型", "yppm", "ypspm", "ypgg", "sccj", "lsj", "ypdw", "shh", "cjid", "ydwbl", "hwh" };/////,"ifby"
                string[] ComputeField ={ "ypsl", "lsje" };
                string[] CField ={ "sum", "sum" };
                DataTable  tab = FunBase.GroupbyDataTable(tb, GroupbyField, ComputeField, CField, null);

                //添加每个统类分类的药品
                for (int i = 0; i <= this.tabControl2.TabPages.Count - 1; i++)
                {
                    for (int j = 0; j <= this.tabControl2.TabPages[i].Controls.Count - 1; j++)
                    {
                        //如果是网格
                        if (this.tabControl2.TabPages[i].Controls[j].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                        {
                            TrasenClasses.GeneralControls.DataGridEx mydatagrid = (TrasenClasses.GeneralControls.DataGridEx)this.tabControl2.TabPages[i].Controls[j];
                            DataTable mytb = (DataTable)mydatagrid.DataSource;

                            DataRow[] rows = tab.Select("类型='" + this.tabControl2.TabPages[i].Title.Trim() + "'", "hwh,yppm");
                            for (int x = 0; x <= rows.Length - 1; x++)
                            {
                                DataRow row = mytb.NewRow();
                                row["序号"] = mytb.Rows.Count + 1;
                                row["品名"] = rows[x]["yppm"];
                                row["商品名"] = rows[x]["ypspm"];
                                row["规格"] = rows[x]["ypgg"];
                                row["厂家"] = rows[x]["sccj"];
                                row["单价"] = rows[x]["lsj"];
                                row["库存数"] = "";// rows[x]["kcl"];
                                row["领药数"] = rows[x]["ypsl"];
                                row["缺药数"] = "";// rows[x]["qysl"];
                                row["单位"] = rows[x]["ypdw"];
                                row["金额"] = rows[x]["lsje"];
                                row["货号"] = rows[x]["shh"];
                                row["cjid"] = rows[x]["cjid"];
                                row["dwbl"] = rows[x]["ydwbl"];
                                row["货位号"] = rows[x]["hwh"];
                                sumlsje = sumlsje + Convert.ToDecimal(rows[x]["lsje"]);
                                mytb.Rows.Add(row);
                            }
                        }
                    }
                }

                this.statusBar1.Panels[2].Text = "当前单据金额:" + sumlsje.ToString("0.00");

                //查询明细单
                //if (this.chkmx.Checked == true)
                //{
                //    myDataGridMx.TableStyles[0].GridColumnStyles["缺药"].Width = 0;
                //    DataTable tbmx = ZY_FY.SelectTldMx(item.Tag.ToString(), InstanceForm.BDatabase);
                //    tbmx.TableName = "tbmx";

                //    //this.myDataGridMx.DataSource=tbmx;
                //    FunBase.AddRowtNo(tbmx);
                //    this.myDataGridMx.DataSource = GetDatatableForGrid(tbmx, true);
                //    PubStaticFun.ModifyDataGridStyle(this.myDataGridMx, 0);
                //}

                #region 改变选择对象的颜色
                //if (item.ImageIndex == 0) return;

                for (int i = 0; i <= this.treeListView3.Items.Count - 1; i++)
                    this.ChangeTreeItemColorToWhite(this.treeListView3.Items[i]);

                //if (item.BackColor != Color.GreenYellow)
                //{
                //    item.BackColor = Color.GreenYellow;
                //    item.SubItems[0].BackColor = Color.GreenYellow;
                //    item.SubItems[1].BackColor = Color.GreenYellow;
                //    item.SubItems[2].BackColor = Color.GreenYellow;
                //    item.SubItems[3].BackColor = Color.GreenYellow;
                //    item.Selected = false;
                //}

                #endregion

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

















    }
}
