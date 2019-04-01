using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using UtilityLibrary.General ;
using UtilityLibrary.WinControls;
using 病人信息;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using Ts_ss_class;
using ts_zyhs_classes;

namespace Ts_ss_main
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class FrmMain : System.Windows.Forms.Form
    {
        private long _currentUserId;
        private long _currentDeptId;
        public OleDbConnection cCon = new OleDbConnection();
        private int _mzbz = 0; //麻醉标志[0=手术；1=麻醉]
        private int _level;//手术麻醉医嘱权限[3=主任；1=普通]
        /// <summary>
        /// 时间查询条件
        /// </summary>
        private string Serchstring = "";
        private Guid _inpatientId;
        private string _stag;
        private string _wardId;
        private long _deptId;
        private long _ward_deptId;
        private int toolButton;
        //		private SplashScreen _splashScreen;  //闪屏
        private byte[] ba = null;
        private int bj = 0;//报警灯：1=红色、0=白色
        private Guid tsapply_id = Guid.Empty; //Add by zouchihua 2011-11-1
        private DataTable MessageTb = new DataTable();

		#region Windows 窗体设计器生成的代码

		private UtilityLibrary.WinControls.OutlookBar outlookBar1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel2;
        private Crownwood.Magic.Menus.MenuControl menuControl1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;

        public DataView SelectDataView = null;
        private System.Windows.Forms.ImageList imageList3;
        private System.Timers.Timer timer1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.ContextMenu contextMenu2;
        private System.Windows.Forms.MenuItem menuItem18;
        private System.Windows.Forms.ContextMenu contextMenu3;
        private System.Windows.Forms.MenuItem menuItem21;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ToolBarButton toolBarButton4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel5;
        private DougScrollingText.DougScrollingTextCtrl dougScrollingTextCtrl1;
        private System.Windows.Forms.Splitter splitter4;
        private SelectCode.Select_ss select_ss1;
        private System.Windows.Forms.CheckBox checkBox_BJ;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.ToolBarButton toolBarButton5;
        private System.Windows.Forms.ToolBarButton toolBarButton6;
        private 病人信息.PatientInfo patientInfo1;
        private System.Windows.Forms.ListViewItem litem = new ListViewItem();
        //新加变量
        string Sno, Inpatient_no;
        int deptbrzk = 0;
        private ToolBarButton toolBarButton7;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private Button btnserch;
        private GroupBox groupBox1;
        private RadioButton rdbzq;
        private RadioButton rdbjj;
        private RadioButton rdbsy;
        private MenuItem menuItem3;
        private RadioButton rdbWjz;
        private MenuItem menuItemprint; 
        /// 清理所有正在使用的资源。

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        } 
       
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.outlookBar1 = new UtilityLibrary.WinControls.OutlookBar();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItemprint = new System.Windows.Forms.MenuItem();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.select_ss1 = new SelectCode.Select_ss();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbWjz = new System.Windows.Forms.RadioButton();
            this.rdbzq = new System.Windows.Forms.RadioButton();
            this.rdbjj = new System.Windows.Forms.RadioButton();
            this.rdbsy = new System.Windows.Forms.RadioButton();
            this.btnserch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox_BJ = new System.Windows.Forms.CheckBox();
            this.patientInfo1 = new 病人信息.PatientInfo();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.dougScrollingTextCtrl1 = new DougScrollingText.DougScrollingTextCtrl();
            this.menuControl1 = new Crownwood.Magic.Menus.MenuControl();
            this.timer1 = new System.Timers.Timer();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.contextMenu3 = new System.Windows.Forms.ContextMenu();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // outlookBar1
            // 
            this.outlookBar1.AnimationSpeed = 20;
            this.outlookBar1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.outlookBar1.BackgroundBitmap = null;
            this.outlookBar1.BorderType = UtilityLibrary.WinControls.BorderType.Fixed3D;
            this.outlookBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.outlookBar1.FlatArrowButtons = false;
            this.outlookBar1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.outlookBar1.LeftTopColor = System.Drawing.Color.Empty;
            this.outlookBar1.Location = new System.Drawing.Point(0, 0);
            this.outlookBar1.Name = "outlookBar1";
            this.outlookBar1.RightBottomColor = System.Drawing.Color.Empty;
            this.outlookBar1.Size = new System.Drawing.Size(112, 639);
            this.outlookBar1.TabIndex = 12;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Control;
            this.splitter1.Location = new System.Drawing.Point(112, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 639);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(115, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 452);
            this.panel1.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel4.Size = new System.Drawing.Size(1072, 452);
            this.panel4.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.ContextMenu = this.contextMenu1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1072, 452);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem14,
            this.menuItem12,
            this.menuItem13,
            this.menuItem17,
            this.menuItem7,
            this.menuItem8,
            this.menuItemprint});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem10,
            this.menuItem11});
            this.menuItem9.Text = "显示";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 0;
            this.menuItem10.Text = "图标";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 1;
            this.menuItem11.Text = "列表";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 1;
            this.menuItem14.Text = "-";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 2;
            this.menuItem12.Text = "修改安排";
            this.menuItem12.Visible = false;
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 3;
            this.menuItem13.Text = "取消安排";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 4;
            this.menuItem17.Text = "-";
            // 
            // menuItem7
            // 
            this.menuItem7.Enabled = false;
            this.menuItem7.Index = 5;
            this.menuItem7.Text = "护理记录单";
            this.menuItem7.Visible = false;
            // 
            // menuItem8
            // 
            this.menuItem8.Enabled = false;
            this.menuItem8.Index = 6;
            this.menuItem8.Text = "术后补录";
            this.menuItem8.Visible = false;
            // 
            // menuItemprint
            // 
            this.menuItemprint.Index = 7;
            this.menuItemprint.Text = "打印手术一览表";
            this.menuItemprint.Click += new System.EventHandler(this.menuItemprint_Click);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.Control;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(115, 452);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1072, 3);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.select_ss1);
            this.panel2.Controls.Add(this.splitter4);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(115, 455);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1072, 184);
            this.panel2.TabIndex = 8;
            // 
            // select_ss1
            // 
            this.select_ss1.BackColor = System.Drawing.SystemColors.Control;
            this.select_ss1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.select_ss1.Location = new System.Drawing.Point(0, 0);
            this.select_ss1.Name = "select_ss1";
            this.select_ss1.Size = new System.Drawing.Size(547, 184);
            this.select_ss1.TabIndex = 0;
            // 
            // splitter4
            // 
            this.splitter4.BackColor = System.Drawing.SystemColors.Control;
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter4.Location = new System.Drawing.Point(547, 0);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(5, 184);
            this.splitter4.TabIndex = 24;
            this.splitter4.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.btnserch);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.checkBox_BJ);
            this.panel5.Controls.Add(this.patientInfo1);
            this.panel5.Controls.Add(this.toolBar1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(552, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(520, 184);
            this.panel5.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbWjz);
            this.groupBox1.Controls.Add(this.rdbzq);
            this.groupBox1.Controls.Add(this.rdbjj);
            this.groupBox1.Controls.Add(this.rdbsy);
            this.groupBox1.Location = new System.Drawing.Point(164, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 33);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择";
            // 
            // rdbWjz
            // 
            this.rdbWjz.AutoSize = true;
            this.rdbWjz.Location = new System.Drawing.Point(144, 16);
            this.rdbWjz.Name = "rdbWjz";
            this.rdbWjz.Size = new System.Drawing.Size(59, 16);
            this.rdbWjz.TabIndex = 3;
            this.rdbWjz.Text = "未登账";
            this.rdbWjz.UseVisualStyleBackColor = true;
            this.rdbWjz.CheckedChanged += new System.EventHandler(this.rdbWjz_CheckedChanged);
            // 
            // rdbzq
            // 
            this.rdbzq.AutoSize = true;
            this.rdbzq.Location = new System.Drawing.Point(99, 16);
            this.rdbzq.Name = "rdbzq";
            this.rdbzq.Size = new System.Drawing.Size(47, 16);
            this.rdbzq.TabIndex = 2;
            this.rdbzq.Text = "择期";
            this.rdbzq.UseVisualStyleBackColor = true;
            this.rdbzq.CheckedChanged += new System.EventHandler(this.rdbsy_CheckedChanged);
            // 
            // rdbjj
            // 
            this.rdbjj.AutoSize = true;
            this.rdbjj.Location = new System.Drawing.Point(52, 16);
            this.rdbjj.Name = "rdbjj";
            this.rdbjj.Size = new System.Drawing.Size(47, 16);
            this.rdbjj.TabIndex = 1;
            this.rdbjj.Text = "急诊";
            this.rdbjj.UseVisualStyleBackColor = true;
            this.rdbjj.CheckedChanged += new System.EventHandler(this.rdbsy_CheckedChanged);
            // 
            // rdbsy
            // 
            this.rdbsy.AutoSize = true;
            this.rdbsy.Checked = true;
            this.rdbsy.Location = new System.Drawing.Point(5, 16);
            this.rdbsy.Name = "rdbsy";
            this.rdbsy.Size = new System.Drawing.Size(47, 16);
            this.rdbsy.TabIndex = 0;
            this.rdbsy.TabStop = true;
            this.rdbsy.Text = "所有";
            this.rdbsy.UseVisualStyleBackColor = true;
            this.rdbsy.CheckedChanged += new System.EventHandler(this.rdbsy_CheckedChanged);
            // 
            // btnserch
            // 
            this.btnserch.Location = new System.Drawing.Point(375, 10);
            this.btnserch.Name = "btnserch";
            this.btnserch.Size = new System.Drawing.Size(39, 28);
            this.btnserch.TabIndex = 32;
            this.btnserch.Text = "查询";
            this.btnserch.UseVisualStyleBackColor = true;
            this.btnserch.Click += new System.EventHandler(this.btnserch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(415, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // checkBox_BJ
            // 
            this.checkBox_BJ.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox_BJ.Checked = true;
            this.checkBox_BJ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_BJ.Location = new System.Drawing.Point(440, 8);
            this.checkBox_BJ.Name = "checkBox_BJ";
            this.checkBox_BJ.Size = new System.Drawing.Size(72, 32);
            this.checkBox_BJ.TabIndex = 30;
            this.checkBox_BJ.Text = "急诊手术报警提示";
            this.checkBox_BJ.UseVisualStyleBackColor = false;
            this.checkBox_BJ.CheckedChanged += new System.EventHandler(this.checkBox_BJ_CheckedChanged);
            // 
            // patientInfo1
            // 
            this.patientInfo1.BackColor = System.Drawing.Color.LightGray;
            this.patientInfo1.IsShow = true;
            this.patientInfo1.Location = new System.Drawing.Point(1, 42);
            this.patientInfo1.Name = "patientInfo1";
            this.patientInfo1.Size = new System.Drawing.Size(519, 169);
            this.patientInfo1.TabIndex = 28;
            // 
            // toolBar1
            // 
            this.toolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton2,
            this.toolBarButton3,
            this.toolBarButton4,
            this.toolBarButton5,
            this.toolBarButton6,
            this.toolBarButton7});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList3;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(520, 42);
            this.toolBar1.TabIndex = 27;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 2;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Pushed = true;
            this.toolBarButton1.Tag = "1";
            this.toolBarButton1.Text = " 已安排申请";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 3;
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Tag = "2";
            this.toolBarButton2.Text = " 未安排申请";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.ImageIndex = 2;
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Tag = "3";
            this.toolBarButton3.Text = "所有手术";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.ImageIndex = 3;
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Tag = "4";
            this.toolBarButton4.Text = "未安排麻醉";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.ImageIndex = 3;
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Tag = "5";
            this.toolBarButton5.Text = "未安排手术";
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.ImageIndex = 2;
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Tag = "6";
            this.toolBarButton6.Text = "已安排手术";
            // 
            // toolBarButton7
            // 
            this.toolBarButton7.ImageIndex = 2;
            this.toolBarButton7.Name = "toolBarButton7";
            this.toolBarButton7.Tag = "7";
            this.toolBarButton7.Text = "已安排麻醉";
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "");
            this.imageList3.Images.SetKeyName(1, "");
            this.imageList3.Images.SetKeyName(2, "");
            this.imageList3.Images.SetKeyName(3, "");
            // 
            // dougScrollingTextCtrl1
            // 
            this.dougScrollingTextCtrl1.DougScrollingTextColor1 = System.Drawing.Color.Black;
            this.dougScrollingTextCtrl1.DougScrollingTextColor2 = System.Drawing.Color.Gold;
            this.dougScrollingTextCtrl1.IsStop = false;
            this.dougScrollingTextCtrl1.Location = new System.Drawing.Point(0, 184);
            this.dougScrollingTextCtrl1.Name = "dougScrollingTextCtrl1";
            this.dougScrollingTextCtrl1.Size = new System.Drawing.Size(457, 32);
            this.dougScrollingTextCtrl1.TabIndex = 30;
            this.dougScrollingTextCtrl1.Text = "dougScrollingTextCtrl1";
            // 
            // menuControl1
            // 
            this.menuControl1.AnimateStyle = Crownwood.Magic.Menus.Animation.System;
            this.menuControl1.AnimateTime = 100;
            this.menuControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.menuControl1.Direction = Crownwood.Magic.Common.Direction.Horizontal;
            this.menuControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(134)));
            this.menuControl1.HighlightTextColor = System.Drawing.SystemColors.MenuText;
            this.menuControl1.Location = new System.Drawing.Point(0, 0);
            this.menuControl1.Name = "menuControl1";
            this.menuControl1.Size = new System.Drawing.Size(0, 25);
            this.menuControl1.Style = Crownwood.Magic.Common.VisualStyle.IDE;
            this.menuControl1.TabIndex = 0;
            this.menuControl1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 180000;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem18,
            this.menuItem3});
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 0;
            this.menuItem18.Text = "麻醉安排";
            this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "打印麻醉一览表";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // contextMenu3
            // 
            this.contextMenu3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem21,
            this.menuItem20,
            this.menuItem19,
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 0;
            this.menuItem21.Text = "手术安排";
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 1;
            this.menuItem20.Text = "-";
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 2;
            this.menuItem19.Text = "手术取消";
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 4;
            this.menuItem2.Text = "打印手术一览表";
            this.menuItem2.Click += new System.EventHandler(this.menuItemprint_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            this.imageList1.Images.SetKeyName(24, "");
            this.imageList1.Images.SetKeyName(25, "");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1187, 639);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.outlookBar1);
            this.Name = "FrmMain";
            this.Text = "手术麻醉管理系统2.0版";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

		public FrmMain(long currentUser, long currentDept, string formText)
		{ 
			InitializeComponent();
			_currentUserId = currentUser;
			_currentDeptId = currentDept;
			_ward_deptId = new Department(currentDept, FrmMdiMain.Database).WardDeptId;
			PubFunction.AuserEmployeeID = Convert.ToInt32((new User(Convert.ToInt32(currentUser), FrmMdiMain.Database)).EmployeeId);
			PubFunction.AuserDeptID = Convert.ToInt32(currentDept);
			_mzbz = 0;
			_level = 1;
			CsOutBar();
		}

		public FrmMain(long currentUser, long currentDept, string formText, int mzbz)
		{ 
			InitializeComponent();
			_currentUserId = currentUser;
			_currentDeptId = currentDept;
			_ward_deptId = new Department(currentDept, FrmMdiMain.Database).WardDeptId;
			_mzbz = 1;
			_level = mzbz;
			CsOutBar();
			this.checkBox_BJ.Visible = false; 
		} 

        #region 方法 
      
        /// <summary>
        /// 取病人信息
        /// </summary>
        /// <param name="sNo">手术号</param>
        private void GetPatientInfo(string sNo)
        {
            string ssql = "select distinct a.inpatient_id," +
                " cast(b.inpatient_id as char(40))+cast(cast(b.baby_id as int) as char(10))+ cast(cast(b.ismyts as int) as char(10))+cast(cast(b.INPATIENT_DEPT as int) as char(10))+cast(b.ward_id as char(10)) as stag," +
                " b.ward_id,b.dept_id " +                                                                                                                                         //这里应该要取INPATIENT_DEPT
                " from ss_apprecord as a inner join zy_beddiction as b " +
                " on a.inpatient_id=b.inpatient_id and sno='" + sNo + "'and inpatient_no='" + this.Inpatient_no.Trim() + "' ";
            DataTable tb = FrmMdiMain.Database.GetDataTable(ssql);
            try
            {
                _inpatientId = new Guid(tb.Rows[0]["inpatient_id"].ToString());
                _stag = tb.Rows[0]["stag"].ToString();
                _deptId = Convert.ToInt64(tb.Rows[0]["dept_id"]);
                _wardId = Convert.ToString(tb.Rows[0]["ward_id"]);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        } 

        /// <summary>
        /// 是否已经安排
        /// </summary>
        /// <param name="Sno"></param>
        /// <returns></returns>
        private bool IsArrage(string Sno)
        {
            string strSql = string.Format(@"SELECT	  count(*)
										 FROM SS_ARRRECORD
										 where SNO = {0} and BDELETE=0 ", Sno);
            DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);
            if (dt == null) return false;
            else if (dt.Rows[0][0].ToString() == "0") return false;
            else return true;
        }

        #region 获取窗体 modify by caicheng
        private void GetForm(string dllName, string functionName, string chineseName, long userID, long deptID, object[] communicateValue, bool showType)
        { 
            User _userid = new User(userID, FrmMdiMain.Database);
            Department _deptid = new Department(deptID, FrmMdiMain.Database); 
            {
                //获得DLL中窗体			
                Form _dllform = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, _userid, _deptid, null, FrmMdiMain.Database, ref communicateValue);
                _dllform.StartPosition = FormStartPosition.CenterScreen;
                if (showType) _dllform.ShowDialog();
                else _dllform.Show();
            }
        }
        #endregion 

        /// <summary>
        /// 显示手术安排
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmSsap(long userid, long deptid, string ssNo, string _inpatient_no, string age)
        {
            object[] communicateValue = new object[3];
            communicateValue[0] = ssNo;  
            communicateValue[1] = _inpatient_no;
            communicateValue[2] = age;
            GetForm("Ts_ss_ssap", "Fun_Ts_ss_ssap", "手术安排", userid, deptid, communicateValue, true);
        }

        /// <summary>
        /// 显示手术护理记录单
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmSshljld(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[1];
            communicateValue[0] = ssNo;
            GetForm("Ts_ss_hljld", "Fun_Ts_ss_hljld", "手术护理记录单", userid, deptid, communicateValue, true);
        }

        /// <summary>
        /// 显示术后补录
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmShbl(long userid, long deptid, string ssNo, string _inpatient_no, string age)
        {
            object[] communicateValue = new object[3];
            communicateValue[0] = ssNo;
            communicateValue[1] = _inpatient_no;
            communicateValue[2] = age;
            GetForm("Ts_ss_shbl", "Fun_Ts_ss_shbl", "术后补录", userid, deptid, communicateValue, true);
        }

        /// <summary>
        /// 显示手术安排查询
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmSsapcx(long userid, long deptid, string ssNo, string _inpatient_no)
        {
            object[] communicateValue = new object[2];
            communicateValue[0] = ssNo;
            communicateValue[1] = _inpatient_no;
            WorkStaticFun.InstanceForm("Ts_ss_apcx", "Fun_Ts_ss_apcx", "手术安排查询", new User(userid, FrmMdiMain.Database), new Department(deptid, FrmMdiMain.Database), this.MdiParent, FrmMdiMain.Database, ref communicateValue);
        }

        /// <summary>
        /// 显示门诊手术补录
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmMzssbl(long userid, long deptid, string ssNo, string _inpatient_no)
        {
            object[] communicateValue = new object[2];
            communicateValue[0] = ssNo;
            communicateValue[1] = _inpatient_no;
            GetForm("Ts_ss_mzssbl", "Fun_Ts_ss_mzssbl", "门诊手术补录", userid, deptid, communicateValue, true);
        }

        /// <summary>
        /// 显示麻醉安排
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmMzap(long userid, long deptid, string ssNo, string _inpatient_no)
        {
            object[] communicateValue = new object[2];
            communicateValue[0] = ssNo;
            communicateValue[1] = _inpatient_no;
            GetForm("Ts_ss_mzap", "Fun_Ts_ss_mzap", "麻醉安排", userid, deptid, communicateValue, true);
        }

        /// <summary>
        /// 显示麻醉安排查询
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmMzapcx(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[1];
            communicateValue[0] = ssNo;
            User _userid = new User(userid, FrmMdiMain.Database);
            Department _deptid = new Department(deptid, FrmMdiMain.Database);
            //GetForm("Xc_ss_mzapcx","Fun_Ts_ss_mzapcx","麻醉安排查询",userid,deptid,communicateValue,false);	
            WorkStaticFun.InstanceForm("Ts_ss_mzapcx", "Fun_Ts_ss_mzapcx", "麻醉安排查询", _userid, _deptid, this.MdiParent, FrmMdiMain.Database, ref communicateValue);
        }

        /// <summary>
        /// 显示手术器械材料维护
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmQxclwh(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[1];
            communicateValue[0] = ssNo;
            GetForm("Ts_ss_qxclwh", "Fun_Ts_ss_qxclwh", "手术器械材料维护", userid, deptid, communicateValue, true);
        }

        /// <summary>
        /// 显示手术体位维护
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmSstwwh(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[1];
            communicateValue[0] = ssNo;
            GetForm("Ts_ss_sstwwh", "Fun_Ts_ss_sstwwh", "手术体位维护", userid, deptid, communicateValue, true);
        }

        /// <summary>
        /// 显示手术等级维护
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmSsdjwh(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[1];
            communicateValue[0] = ssNo;
            GetForm("Ts_ss_ssdjwh", "Fun_Ts_ss_ssdjwh", "手术等级维护", userid, deptid, communicateValue, true);
        }

        /// <summary>
        /// 显示手术包维护
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmSsbwh(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[1];
            communicateValue[0] = ssNo;
            GetForm("Ts_ss_ssbwh", "Fun_Ts_ss_ssbwh", "手术包维护", userid, deptid, communicateValue, true);
        }

        /// <summary>
        /// 显示手术房间维护
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmSsfjwh(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[1];
            communicateValue[0] = ssNo;
            GetForm("Ts_ss_ssfjwh", "Fun_Ts_ss_ssfjwh", "手术房间维护", userid, deptid, communicateValue, true);
        }

        /// <summary>
        /// 显示麻醉方法维护
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmMzffwh(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[1];
            communicateValue[0] = ssNo;
            GetForm("Ts_ss_mzffwh", "Fun_Ts_ss_mzffwh", "麻醉方法维护", userid, deptid, communicateValue, true);
        }

        /// <summary>
        /// 显示医嘱管理
        /// </summary>
        /// <param name="userid">开嘱医生userId</param>
        /// <param name="deptid">开嘱医生的科室ID</param>
        /// <param name="dept_br">病人所在科室ID</param>
        private void ShowFrmYZGL(long userid, long deptid, string ssNo)
        {
            if (ssNo == "0")
            {
                MessageBox.Show("请选择一位病人!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ///by add yaokx 2014-05-23 如果A科室病人申请一台手术，若做完手术，手术室医生没有记账之前，该病人由A科室转入B科室，此时手术室医生再进行记账，则此次病人在手术室发生的费用记账在B科室
            if (new SystemCfg(9010).Config == "1")
            {
                DataTable tbward = FrmMdiMain.Database.GetDataTable("select * from JC_WARDRDEPT where DEPT_ID=" + deptbrzk + "");
                if (tbward != null && tbward.Rows.Count > 0)
                {
                    _wardId = tbward.Rows[0]["WARD_ID"].ToString();
                }
                _deptId = deptbrzk;
                string[] strs = _stag.Split(' ');
                string s = strs[0] + "    " + strs[4] + "         " + strs[13] + "         " + _deptId + "       " + _wardId + "       ";
                _stag = s;
            }
            object[] communicateValue = new object[10];
            communicateValue[0] = _inpatientId;
            communicateValue[1] = _wardId;//
            communicateValue[2] = _deptId;//病人科室
            communicateValue[3] = _stag;
            communicateValue[4] = false;
            communicateValue[5] = _level;
            communicateValue[6] = _ward_deptId;

            User _userid = new User(userid, FrmMdiMain.Database);
            Department _deptid = new Department(deptid, FrmMdiMain.Database);
            string _ssql = "select  c.INPATIENT_ID AS BINID,C.INPATIENT_NO AS 住院号,c.NAME AS 姓名 " +
                "from ss_apprecord a,ss_arrrecord b,vi_zy_vinpatient_bed c " +
                "where a.inpatient_id=c.inpatient_id and c.baby_id=0 and " +
                "a.sno=b.sno and a.inpatient_id=b.inpatient_id and a.apbj=1 and  b.bdelete=0 and b.wcbj=0 ORDER BY 住院号";
            communicateValue[7] = _ssql;
            communicateValue[8] = tsapply_id;//add by zouchihua 2011-11-1
            communicateValue[9] = 2;//
            GetForm("Ts_zyys_yzgl", "Fun_Ts_zyys_mzyz", "医嘱管理", userid, deptid, communicateValue, false);

        }

        /// <summary>
        /// 显示药品信息
        /// </summary>
        /// <param name="userid">开嘱医生userId</param>
        /// <param name="deptid">开嘱医生的科室ID</param>
        /// <param name="dept_br">病人所在科室ID</param>
        private void ShowFrmYPXX(long userid, long deptid, string ssNo)
        {
            User _userid = new User(userid, FrmMdiMain.Database);
            Department _deptid = new Department(deptid, FrmMdiMain.Database);
            WorkStaticFun.InstanceForm("ts_zyhs_ypxx", "Fun_ts_zyhs_ypxx", "药品信息", _userid, _deptid, this.MdiParent, FrmMdiMain.Database);
        }

        /// <summary>
        ///	显示病人查询
        /// </summary>
        /// <param name="userid">开嘱医生userId</param>
        /// <param name="deptid">开嘱医生的科室ID</param>
        /// <param name="dept_br">病人所在科室ID</param>
        private void ShowFrmBRCX(long userid, long deptid, string ssNo)
        {
            User _userid = new User(userid, FrmMdiMain.Database);
            Department _deptid = new Department(deptid, FrmMdiMain.Database);
            WorkStaticFun.InstanceForm("Ts_ss_brcx", "Fun_Ts_ss_brcx", "病人查询", _userid, _deptid, this.MdiParent, FrmMdiMain.Database);
        }

        /// <summary>
        /// 显示费用信息
        /// </summary>
        /// <param name="userid">开嘱医生userId</param>
        /// <param name="deptid">开嘱医生的科室ID</param>
        /// <param name="dept_br">病人所在科室ID</param>
        private void ShowFrmFYXX(long userid, long deptid, string ssNo)
        {
            User _userid = new User(userid, FrmMdiMain.Database);
            Department _deptid = new Department(deptid, FrmMdiMain.Database);
            WorkStaticFun.InstanceForm("ts_zyhs_fyxx", "Fun_ts_zyhs_fyxx_ssmz", "费用信息", _userid, _deptid, this.MdiParent, FrmMdiMain.Database);
        }

        /// <summary>
        /// 显示取消医技检查
        /// </summary>
        /// <param name="userid">开嘱医生userId</param>
        /// <param name="deptid">开嘱医生的科室ID</param>
        /// <param name="dept_br">病人所在科室ID</param>
        private void ShowFrmQXYJJC(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[1];
            User _userid = new User(userid, FrmMdiMain.Database);
            Department _deptid = new Department(deptid, FrmMdiMain.Database);
            string ssql = "select distinct A.INPATIENT_ID,0 as Baby_ID " +
                " from ss_apprecord a,ss_arrrecord b" +
                " where  " +
                " a.sno=b.sno and a.inpatient_id=b.inpatient_id and a.apbj=1 and  b.bdelete=0 and b.wcbj=0";
            communicateValue[0] = ssql;
            WorkStaticFun.InstanceFormEx("ts_zyhs_qxyjjc", "Fun_ts_zyhs_qxyjjc_ssmz", "取消医技检查", _userid, _deptid, InstanceForm._functions, InstanceForm._menuId, this.MdiParent, FrmMdiMain.Database, ref communicateValue);
        }

        /// <summary>
        /// 显示医嘱查询_手术
        /// </summary>
        /// <param name="userid">开嘱医生userId</param>
        /// <param name="deptid">开嘱医生的科室ID</param>
        /// <param name="dept_br">病人所在科室ID</param>
        private void ShowFrmYZCX_SS(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[2];
            User _userid = new User(userid, FrmMdiMain.Database);
            Department _deptid = new Department(deptid, FrmMdiMain.Database);
            //add by zouchihua 2012-5-22 医生工作站 手术麻醉进入是否对婴儿记账 0=否，1=是
            SystemCfg cfg6034 = new SystemCfg(6034);
            string ssql ="";
            if(cfg6034.Config.Trim()=="0")
            //Modify by zouchihua 科室显示毛毛
             ssql = "select distinct C.INPATIENT_NO AS 住院号,c.NAME AS 姓名,c.INPATIENT_ID,0 as Baby_ID,c.DEPT_ID,0 as isMY" +
                " from ss_apprecord a,ss_arrrecord b,vi_zy_vinpatient c" +
                " where a.inpatient_id=c.inpatient_id and " +
                " a.sno=b.sno and a.inpatient_id=b.inpatient_id and a.apbj=1 and  b.bdelete=0 and b.wcbj=0";
            else
             ssql = "select distinct C.INPATIENT_NO AS 住院号,c.NAME AS 姓名,c.INPATIENT_ID,BABY_ID,c.DEPT_ID,0 as isMY" +
              " from ss_apprecord a,ss_arrrecord b,VI_ZY_VINPATIENT_BED c" +
              " where a.inpatient_id=c.inpatient_id and " +
              " a.sno=b.sno and a.inpatient_id=b.inpatient_id and a.apbj=1 and  b.bdelete=0 and b.wcbj=0";
            communicateValue[0] = ssql;
            communicateValue[1] = 0;
            WorkStaticFun.InstanceFormEx("ts_zyhs_yzgl", "Fun_ts_zyhs_yzgl_ssmz", "医嘱管理", _userid, _deptid, InstanceForm._functions, InstanceForm._menuId, this.MdiParent, FrmMdiMain.Database, ref communicateValue);
        }

        /// <summary>
        /// 显示医嘱查询_麻醉
        /// </summary>
        /// <param name="userid">开嘱医生userId</param>
        /// <param name="deptid">开嘱医生的科室ID</param>
        /// <param name="dept_br">病人所在科室ID</param>
        private void ShowFrmYZCX_MZ(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[2];
            User _userid = new User(userid, FrmMdiMain.Database);
            Department _deptid = new Department(deptid, FrmMdiMain.Database);
            //add by zouchihua 2012-5-22 医生工作站 手术麻醉进入是否对婴儿记账 0=否，1=是
            SystemCfg cfg6034 = new SystemCfg(6034);
            string ssql ="";
            if(cfg6034.Config.Trim()=="0")
              ssql = "select distinct C.INPATIENT_NO AS 住院号,c.NAME AS 姓名,c.INPATIENT_ID,0 Baby_ID,c.DEPT_ID,0 as isMY" +
                " from ss_apprecord a,ss_arrrecord b,vi_zy_vinpatient c" +
                " where a.inpatient_id=c.inpatient_id and " +
                " a.sno=b.sno and a.inpatient_id=b.inpatient_id and a.apbj=1 and  b.bdelete=0 and b.wcbj=0";
            else
              ssql = "select distinct C.INPATIENT_NO AS 住院号,c.NAME AS 姓名,c.INPATIENT_ID,BABY_ID,c.DEPT_ID,0 as isMY" +
             " from ss_apprecord a,ss_arrrecord b,VI_ZY_VINPATIENT_BED c" +
             " where a.inpatient_id=c.inpatient_id and " +
             " a.sno=b.sno and a.inpatient_id=b.inpatient_id and a.apbj=1 and  b.bdelete=0 and b.wcbj=0";
            communicateValue[0] = ssql;
            communicateValue[1] = 1;
            WorkStaticFun.InstanceFormEx("ts_zyhs_yzgl", "Fun_ts_zyhs_yzgl_ssmz", "医嘱管理", _userid, _deptid, InstanceForm._functions, InstanceForm._menuId, this.MdiParent, FrmMdiMain.Database, ref communicateValue);
        }

        /// <summary>
        /// 显示手术麻醉登记薄
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmssmzdjb(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[1];
            communicateValue[0] = ssNo;
            GetForm("Ts_ss_bb", "Fun_Ts_ss_ssmzdjb", "手术麻醉登记薄", userid, deptid, null, false);
        }

        /// <summary>
        /// 显示手术室工作量统计表
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmsssgzltjb(long userid, long deptid, string ssNo)
        {
            GetForm("Ts_ss_bb", "Fun_Ts_ss_sssgzltjb", "手术室工作量统计表", userid, deptid, null, false);
        }

        /// <summary>
        /// 显示手术室收入报表
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmssssrbb(long userid, long deptid, string ssNo)
        {
            GetForm("Ts_ss_bb", "Fun_Ts_ss_ssssrbb", "手术室收入报表", userid, deptid, null, false);
        }

        /// <summary>
        /// 显示麻醉登记薄
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmmzdjb(long userid, long deptid, string ssNo)
        {
            object[] communicateValue = new object[1];
            communicateValue[0] = ssNo;
            GetForm("Ts_ss_bb", "Fun_Ts_ss_mzdjb", "麻醉登记薄", userid, deptid, null, false);
        }

        /// <summary>
        /// 显示麻醉科工作量报表
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmmzkgzlbb(long userid, long deptid, string ssNo)
        {
            GetForm("Ts_ss_bb", "Fun_Ts_ss_mzkgzlbb", "麻醉科工作量报表", userid, deptid, null, false);
        }

        /// <summary>
        /// 显示麻醉汇总统计表
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmmzhztjb(long userid, long deptid, string ssNo)
        {
            GetForm("Ts_ss_bb", "Fun_Ts_ss_mzhztjb", "麻醉汇总统计表", userid, deptid, null, false);
        }

        /// <summary>
        /// 显示手术台次报表
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmsstcbb(long userid, long deptid, string ssNo)
        {
            GetForm("Ts_ss_bb", "Fun_Ts_ss_sstcbb", "手术台次报表", userid, deptid, null, false);
        }

        /// <summary>
        /// 显示麻醉科收入报表
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="dept_br">手术NO</param>
        private void ShowFrmmzksrtjb(long userid, long deptid, string ssNo)
        {
            GetForm("Ts_ss_bb", "Fun_Ts_ss_mzksrtjb", "麻醉科收入报表", userid, deptid, null, false);
        }

        /// <summary>
        /// 显示安排管理
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="deptid"></param>
        /// <param name="ssNo"></param>
        private void ShowFrmAp(long userid, long deptid, string ssNo)
        {
            GetForm("Ts_ss_ap", "Fun_Ts_ss_ap", "安排管理", userid, deptid, null, false);
        }

        #region 添加功能图标
        private void CsOutBar()
        {
            //创建功能菜单
            if (_mzbz == 0)
            {
                OutlookBarBand outlookBand1 = new OutlookBarBand("手术室日常业务");
                outlookBand1.LargeImageList = this.imageList1;
                outlookBand1.Items.Add(new OutlookBarItem("手术安排", 1)); 
                outlookBand1.Items.Add(new OutlookBarItem("医嘱账单录入", 9)); 
                outlookBand1.Items.Add(new OutlookBarItem("术后补录", 4));

				#region  modify by caicheng  
				if (new SystemCfg(9008).Config.Equals("1")) {
					outlookBand1.Items.Add(new OutlookBarItem("麻醉补录", 5));
				}
                #endregion

                outlookBand1.Items.Add(new OutlookBarItem("汇总领药", 3)); 
                outlookBand1.Items.Add(new OutlookBarItem("手术安排查询", 5));
                outlookBand1.Items.Add(new OutlookBarItem("账单查询", 0));
                outlookBar1.Bands.Add(outlookBand1);

                OutlookBarBand outlookBand5 = new OutlookBarBand("手术室其它业务");
                outlookBand5.LargeImageList = this.imageList1; 
                outlookBand5.Items.Add(new OutlookBarItem("门诊手术补录", 7));
                outlookBand5.BackColor = Color.LightSlateGray;
                outlookBar1.Bands.Add(outlookBand5);

                OutlookBarBand outlookBand3 = new OutlookBarBand("查询统计");
                outlookBand3.LargeImageList = this.imageList1;
                outlookBand3.Items.Add(new OutlookBarItem("病人查询", 0));
                outlookBand3.Items.Add(new OutlookBarItem("费用清单", 0));
                outlookBand3.Items.Add(new OutlookBarItem("手术麻醉登记薄", 0));
                outlookBand3.Items.Add(new OutlookBarItem("手术室工作量统计", 0));
                outlookBand3.Items.Add(new OutlookBarItem("手术室收入报表", 0));
                outlookBand3.Items.Add(new OutlookBarItem("手术台次报表", 0));
                outlookBand3.BackColor = Color.LightSlateGray;
                outlookBar1.Bands.Add(outlookBand3); 
            }
            else
            {
                OutlookBarBand outlookBand2 = new OutlookBarBand("麻醉科业务");
                outlookBand2.LargeImageList = this.imageList1;
                outlookBand2.Items.Add(new OutlookBarItem("麻醉安排", 8));
				#region modify by caicheng 
				outlookBand2.Items.Add(new OutlookBarItem("术后补录", 4));
				#endregion
				outlookBand2.Items.Add(new OutlookBarItem("医嘱账单录入", 9)); 
                outlookBand2.Items.Add(new OutlookBarItem("汇总领药", 3)); 
                outlookBand2.Items.Add(new OutlookBarItem("麻醉安排查询", 10));
                outlookBand2.Items.Add(new OutlookBarItem("医嘱查询", 11));
                outlookBar1.Bands.Add(outlookBand2);

                OutlookBarBand outlookBand6 = new OutlookBarBand("麻醉科其它业务");
                outlookBand6.LargeImageList = this.imageList1; 
                outlookBand6.BackColor = Color.LightSlateGray;
                outlookBar1.Bands.Add(outlookBand6);

                OutlookBarBand outlookBand3 = new OutlookBarBand("查询统计");
                outlookBand3.LargeImageList = this.imageList1;
                outlookBand3.Items.Add(new OutlookBarItem("病人查询", 0));
                outlookBand3.Items.Add(new OutlookBarItem("费用清单", 0));
                outlookBand3.Items.Add(new OutlookBarItem("麻醉登记薄", 0));
                outlookBand3.Items.Add(new OutlookBarItem("麻醉科工作量报表", 0));
                outlookBand3.Items.Add(new OutlookBarItem("麻醉汇总统计表", 0));
                outlookBand3.Items.Add(new OutlookBarItem("麻醉科收入报表", 0));
                outlookBand3.BackColor = Color.LightSlateGray;
                outlookBar1.Bands.Add(outlookBand3);  
            }

            //添加控件的单击事件和设置字体
            outlookBar1.ItemClicked += new OutlookBarItemClickedHandler(outlookBarClicked);
            outlookBar1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

            //控制控件的停靠
            outlookBar1.Dock = System.Windows.Forms.DockStyle.Left;
        }
        #endregion

        #endregion

        #region 事件

        #region 导航图标点击事件
        private void outlookBarClicked(OutlookBarBand band, OutlookBarItem item)
        {
            StopSound();//停止报警 
            menuClick(item.Text);
        }
        #endregion

        #region 退出程序
        private int returnQuit()
        {
            if (MessageBox.Show("确认退出整个程序吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        #endregion

        #region 菜单点击事件
        private void menuClick(string sText)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            try
            {
                if (this.Inpatient_no == null
                    && (sText == "麻醉安排" || sText == "手术安排" || sText == "术后补录"))
                {
                    MessageBox.Show("请选择一个病人！");
                    return;
                }
                if ((sText == "医嘱账单录入") && (toolBar1.Buttons[3].Pushed || toolBar1.Buttons[1].Pushed)) //|| sText == "术后补录" Modify By Tany 2015-04-14 术后补录不限制
                {
                    MessageBox.Show("请选择已安排的病人！");
                    return;
                }
                switch (sText)
                {
                    #region Modify by caicheng
                    case "麻醉补录":
                        ShowFrmACollection(this._currentUserId, this._currentDeptId, Convertor.IsNull(this.Tag, "0"), Convertor.IsNull(this.Inpatient_no, ""));
                        break;
                    #endregion
                    case "门诊手术补录":
                        ShowFrmMzssbl(this._currentUserId, this._currentDeptId, Convertor.IsNull(this.Tag, "0").Trim(), Convertor.IsNull(this.Inpatient_no, "").Trim());
                        break;
                    case "手术安排":
                        ShowFrmSsap(this._currentUserId, this._currentDeptId, this.Tag.ToString(), this.Inpatient_no.Trim(), patientInfo1.lbAge.Text);
                        outlookBand1_Click(toolButton);
                        break;
                    case "手术安排查询":
                        ShowFrmSsapcx(this._currentUserId, this._currentDeptId, Convertor.IsNull(this.Tag, "0"), Convertor.IsNull(this.Inpatient_no, ""));
                        break;
                    case "账单查询":
                        ShowFrmYZCX_SS(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "麻醉安排":
                        ShowFrmMzap(this._currentUserId, this._currentDeptId, Convertor.IsNull(this.Tag, "0"), Convertor.IsNull(this.Inpatient_no, ""));
                        outlookBand1_Click(toolButton);//add by zouchihua 2013-3-11 安排后，重新刷新界面
                        break;
                    case "麻醉安排查询":
                        ShowFrmMzapcx(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "医嘱账单录入":
                        ShowFrmYZGL(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "医嘱查询":
                        ShowFrmYZCX_MZ(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "取消医技检查":
                        ShowFrmQXYJJC(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "汇总领药":
                        ShowFrmYPXX(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "术后补录":
                        ShowFrmShbl(this._currentUserId, this._currentDeptId, Convertor.IsNull(this.Tag, "0"), Convertor.IsNull(this.Inpatient_no, ""), patientInfo1.lbAge.Text);
                        outlookBand1_Click(1);
                        break;
                    case "病人查询":
                        ShowFrmBRCX(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "费用清单":
                        ShowFrmFYXX(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "手术器械材料维护":
                        ShowFrmQxclwh(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "麻醉方法维护":
                        ShowFrmMzffwh(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "手术体位代码":
                        ShowFrmSstwwh(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "手术等级代码":
                        ShowFrmSsdjwh(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "手术包维护":
                        ShowFrmSsbwh(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "手术房间维护":
                        ShowFrmSsfjwh(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "护理记录单":
                        ShowFrmSshljld(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "手术麻醉登记薄":
                        ShowFrmssmzdjb(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "手术室工作量统计":
                        ShowFrmsssgzltjb(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "手术室收入报表":
                        ShowFrmssssrbb(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "手术台次报表":
                        ShowFrmsstcbb(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "麻醉科工作量报表":
                        ShowFrmmzkgzlbb(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "麻醉汇总统计表":
                        ShowFrmmzhztjb(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "麻醉科收入报表":
                        ShowFrmmzksrtjb(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "麻醉登记薄":
                        ShowFrmmzdjb(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                    case "安排管理":
                        ShowFrmAp(this._currentUserId, this._currentDeptId, this.Tag.ToString());
                        break;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message + err.StackTrace.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
            //this.ShowPanel(true);
        }
        #endregion

        #region outlookBand1_Click 加载申请记录
        public void outlookBand1_Click(int ntype)
        {
            string _name = "";
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                this.Tag = "0";
                this.listView1.Items.Clear();
                this.panel4.Controls.Clear();

                DataTable Tb = new DataTable();
                string ssql = ""; 
                switch (ntype)
                {

                    #region 手术
                    case 1://已安排手术
                        ssql = "select distinct a.id, a.inpatient_no,a.sno,b.ysss,a.zdys,b.ysmz,a.mzys,b.yxssrq,b.sstc,a.ssbz,sstys,mztys,sqdjczy,a.inpatient_id,apbj,jzss,b.bdelete,DATEDIFF(DD,c.BIRTHDAY,GETDATE())/365 age,ssyz_name,a.YSSSRQFW  from ss_apprecord a,ss_arrrecord b,vi_zy_vinpatient c where a.ssdept=" + this._currentDeptId + " and a.sno=b.sno and a.inpatient_id=c.inpatient_id and a.inpatient_id=b.inpatient_id and a.apbj=1 and c.flag=3 and  b.bdelete=0 and b.wcbj=0 ";
                        //Tb=PubFunction.ExecsqlTable(ssql);
                        Tb = PubFunction.ExecsqlTable("exec SP_SS_SSMZCX null,null," + this._currentDeptId + ",11");
                        break;
                    case 2://未安排手术 //只显示在院病人的
                        ssql = "select distinct a.id, a.inpatient_no,a.sno,a.ysss,a.zdys,a.ysmz,a.mzys,a.ysssrq yxssrq,0 sstc,a.ssbz,sstys,mztys,sqdjczy,a.inpatient_id,0 apbj,jzss,a.bdelete,DATEDIFF(DD,c.BIRTHDAY,GETDATE())/365 age,ssyz_name,a.YSSSRQFW   from ss_apprecord a,vi_zy_vinpatient c where a.ssdept=" + this._currentDeptId + " and a.inpatient_id=c.inpatient_id and c.flag=3 and (shbj=1 or jzss=1) and apbj=0 and  a.bdelete=0";
                        //Tb=PubFunction.ExecsqlTable(ssql);
                        Tb = PubFunction.ExecsqlTable("exec SP_SS_SSMZCX null,null," + this._currentDeptId + ",10");
                        break;
                    #endregion

                    #region 麻醉
                    case 3: //所有手术
                        ssql = "select a.id,a.inpatient_no,a.sno,b.ysss,a.zdys,b.ysmz,a.mzys,b.yxssrq,b.sstc,a.ssbz,sstys,mztys,sqdjczy,a.inpatient_id,apbj,jzss,b.bdelete,a.YSSSRQFW from ss_apprecord a,ss_arrrecord b,vi_zy_vinpatient c where a.sno=b.sno and a.inpatient_id=c.inpatient_id and a.inpatient_id=b.inpatient_id and a.apbj=1 and c.flag=3 and  b.bdelete=0 and b.wcbj=0 ";
                        //Tb=PubFunction.ExecsqlTable(ssql);
                        break;
                    case 4: //未安排麻醉 
                        //ssql="select a.inpatient_no,a.sno,b.ysss,a.zdys,b.ysmz,a.mzys,b.yxssrq,b.sstc,a.ssbz,sstys,mztys,sqdjczy,a.inpatient_id,apbj,jzss,b.bdelete from ss_apprecord a,ss_arrrecord b,zy_vinpatient c where a.inpatient_id=c.inpatient_id and a.sno=b.sno and a.inpatient_id=b.inpatient_id and a.apbj=1 and c.flag=3 and  b.bdelete=0  and (b.ysmz is null or b.ysmz='0') and a.ysssrq>current timestamp-3 day ";
                        ssql = "select a.id,a.inpatient_no,a.sno,b.ysss,a.zdys,b.ysmz,a.mzys,b.yxssrq,b.sstc,a.ssbz,sstys,mztys,sqdjczy,a.inpatient_id,apbj,jzss,b.bdelete,a.YSSSRQFW from ss_apprecord a,ss_arrrecord b,vi_zy_vinpatient c where a.inpatient_id=c.inpatient_id and a.sno=b.sno and a.inpatient_id=b.inpatient_id and c.flag=3 and  b.bdelete=0  and (b.ysmz is null or b.ysmz='0') and a.ysssrq > DATEADD(DAY,-3,GetDate()) ";
                        //Tb=PubFunction.ExecsqlTable(ssql); 
                        Tb = PubFunction.ExecsqlTable("exec SP_SS_SSMZCX null,null,0,14");
                        break;
                    case 5: //未安排手术 
                        ssql = "select a.id,a.inpatient_no,a.sno,a.ysss,a.zdys,a.ysmz,a.mzys,a.ysssrq yxssrq,0 sstc,a.ssbz,sstys,mztys,sqdjczy,a.inpatient_id,0 apbj,jzss,a.bdelete,a.YSSSRQFW from ss_apprecord a,vi_zy_vinpatient c where a.inpatient_id=c.inpatient_id and c.flag=3 and (shbj=1 or jzss=1) and apbj=0 and  a.bdelete=0";
                        //Tb=PubFunction.ExecsqlTable(ssql); 
                        Tb = PubFunction.ExecsqlTable("exec SP_SS_SSMZCX null,null,0,15");
                        break;
                    case 6: //已安排手术 
                        ssql = "select a.id,a.inpatient_no,a.sno,b.ysss,a.zdys,b.ysmz,a.mzys,b.yxssrq,b.sstc,a.ssbz,sstys,mztys,sqdjczy,a.inpatient_id,apbj,jzss,b.bdelete,a.YSSSRQFW from ss_apprecord a,ss_arrrecord b,vi_zy_vinpatient c where a.inpatient_id=c.inpatient_id and a.sno=b.sno and a.inpatient_id=b.inpatient_id and a.apbj=1 and c.flag=3 and  b.bdelete=0  and (b.ysmz is null or b.ysmz='0') and a.ysssrq > DATEADD(DAY,-3,GetDate()) ";
                        //Tb=PubFunction.ExecsqlTable(ssql); 
                        Tb = PubFunction.ExecsqlTable("exec SP_SS_SSMZCX null,null,0,13");
                        break;
                    case 7: //已安排麻醉 
                        ssql = "select a.id,a.inpatient_no,a.sno,b.ysss,a.zdys,b.ysmz,a.mzys,b.yxssrq,b.sstc,a.ssbz,sstys,mztys,sqdjczy,a.inpatient_id,apbj,jzss,b.bdelete,a.YSSSRQFW from ss_apprecord a,ss_arrrecord b,vi_zy_vinpatient c where a.inpatient_id=c.inpatient_id and a.sno=b.sno and a.inpatient_id=b.inpatient_id and a.apbj=1 and c.flag=3 and  b.bdelete=0  and (b.ysmz is null or b.ysmz='0') and a.ysssrq > DATEADD(DAY,-3,GetDate()) ";
                        //Tb=PubFunction.ExecsqlTable(ssql); 
                        Tb = PubFunction.ExecsqlTable("exec SP_SS_SSMZCX null,null,0,16");
                        break;
                    #endregion
                }
                if (Serchstring.Trim() == "")
                    Serchstring = " 1=1   ";
                //add by zouchihua 2012-5-29 
                if (this.rdbjj.Checked)
                {
                    Serchstring = Serchstring + " and JZSS=1 ";
                }
                else
                    if(this.rdbzq.Checked)
                        Serchstring = Serchstring + " and JZSS=0 ";

                //add by cc 2014-04-15 增加未记账选项
                if (rdbWjz.Checked)
                {
                    Serchstring = Serchstring + " and isjz=1";
                }
                //end add
                //add by zouchihua 2012-5-12 增加查询
                Tb.DefaultView.RowFilter = Serchstring;
                Tb = Tb.DefaultView.ToTable();
                if (Tb.Rows.Count > 0)
                {
                    int x;
                    int y;
                    x = this.listView1.Location.X;
                    y = this.listView1.Location.Y;
                    for (int i = 0; i <= Tb.Rows.Count - 1; i++)
                    {
                        string rqfw = "";
                        System.Windows.Forms.ListViewItem litem = new ListViewItem();

                        #region//选择图标
                        if (Convert.ToInt32(Tb.Rows[i]["apbj"].ToString()) == 0)
                        {
                            if (Convert.ToInt32(Tb.Rows[i]["jzss"].ToString()) == 1)
                            {
                                litem.ImageIndex = 1;
                            }
                            else
                            {
                                litem.ImageIndex = 0;
                            }
                        }

                        if (Convert.ToInt32(Tb.Rows[i]["apbj"].ToString()) == 1)
                        {
                            if (Convert.ToInt32(Tb.Rows[i]["jzss"].ToString()) == 1)
                            {
                                litem.ImageIndex = 3;
                            }
                            else
                            {
                                litem.ImageIndex = 2;
                            }
                        }

                        if (Convert.ToInt32(Tb.Rows[i]["BDELETE"].ToString()) == 1)
                        {
                            if (Convert.ToInt32(Tb.Rows[i]["jzss"].ToString()) == 1)
                            {
                                litem.ImageIndex = 7;
                            }
                            else
                            {
                                litem.ImageIndex = 6;
                            }
                        }
                        #endregion
                        if (Tb.Rows[i]["YSSSRQFW"] != null && Tb.Rows[i]["YSSSRQFW"].ToString() != "")
                        {
                            rqfw = Tb.Rows[i]["YSSSRQFW"].ToString();
                        }
                        this.listView1.LargeImageList = imageList1;
                        this.listView1.SmallImageList = imageList1;
                        this.listView1.StateImageList = imageList1;
                        string s1 = Convert.ToString(Tb.Rows[i]["pat_name"].ToString().Trim()) + "(" + Tb.Rows[i]["inpatient_no"].ToString().Trim() + ")";

                        litem.Text = PubFunction.AddSpace(s1.ToString().Trim(), 15);//+"\r\n"+PubFunction.AddSpace(s2.ToString().Trim(),15)+"\r\n"+PubFunction.AddSpace(s3.ToString().Trim(),15)+"\r\n"+PubFunction.AddSpace(s4.ToString().Trim(),15)+"\r\n"+PubFunction.AddSpace(s5.ToString().Trim(),15)+"\r\n";
                        litem.Tag = Tb.Rows[i]["sno"].ToString();
                        litem.SubItems.Add(Tb.Rows[i]["inpatient_no"].ToString().Trim());
                        litem.SubItems.Add(Tb.Rows[i]["pat_name"].ToString().Trim());
                        litem.SubItems.Add(Tb.Rows[i]["sex_name"].ToString());
                        litem.SubItems.Add(Tb.Rows[i]["dept_name"].ToString());

                        litem.SubItems.Add(Tb.Rows[i]["ssfz"].ToString().Trim());
                        litem.SubItems.Add(Tb.Rows[i]["ysss"].ToString().Trim());
                        litem.SubItems.Add(Tb.Rows[i]["zdys_name"].ToString().Trim());
                        litem.SubItems.Add(Tb.Rows[i]["ysmz_name"].ToString().Trim());
                        litem.SubItems.Add(Tb.Rows[i]["mzys_name"].ToString());
                        litem.SubItems.Add(Tb.Rows[i]["yxssrq"].ToString().Trim());
                        litem.SubItems.Add(PubFunction.Seekssfj(new Guid(Tb.Rows[i]["sstc"].ToString().Trim())));
                        litem.SubItems.Add(Tb.Rows[i]["ssbz"].ToString().Trim());
                        litem.SubItems.Add(PubFunction.SeekYesNo(Convert.ToBoolean(Tb.Rows[i]["sstys"])));
                        litem.SubItems.Add(PubFunction.SeekYesNo(Convert.ToBoolean(Tb.Rows[i]["mztys"])));
                        litem.SubItems.Add(Tb.Rows[i]["sqdjczy_name"].ToString().Trim());
                        litem.SubItems.Add(Tb.Rows[i]["inpatient_id"].ToString());
                        //Modify By tany 2011-05-10 增加洗手巡回护士和床号
                        if (Tb.Columns.Contains("xshs_name"))
                        {
                            litem.SubItems.Add(Tb.Rows[i]["xshs_name"].ToString());
                        }
                        else
                        {
                            litem.SubItems.Add("");
                        }
                        if (Tb.Columns.Contains("xhhs_name"))
                        {
                            litem.SubItems.Add(Tb.Rows[i]["xhhs_name"].ToString());
                        }
                        else
                        {
                            litem.SubItems.Add("");
                        }
                        if (Tb.Columns.Contains("bed_no"))
                        {
                            litem.SubItems.Add(Tb.Rows[i]["bed_no"].ToString());
                        }
                        else
                        {
                            litem.SubItems.Add("");
                        }
                        litem.SubItems.Add(Tb.Rows[i]["id"].ToString());  //Modify By zouchihua 2011-11-01 增加手术申请id
                        //add by zouchihua 增加年龄和第一助手 2012-01-11
                        if (Tb.Columns.Contains("age"))
                        {
                            litem.SubItems.Add(Tb.Rows[i]["age"].ToString());
                        }
                        else
                        {
                            litem.SubItems.Add("");
                        }
                        if (Tb.Columns.Contains("ssyz_name"))
                        {
                            litem.SubItems.Add(Tb.Rows[i]["ssyz_name"].ToString());
                        }
                        else
                        {
                            litem.SubItems.Add("");
                        }
                        if (_mzbz == 0)
                        {
                            //add by zouchihua 2012-5-12 增加辅助医生
                            if (Tb.Columns.Contains("mzys1"))
                            {
                                litem.SubItems.Add(Getname(Tb.Rows[i]["mzys1"].ToString()));
                                
                            }
                            else
                            {
                                litem.SubItems.Add("");
                            }
                        }
                        if (Tb.Columns.Contains("FMYS_NAME"))
                        {
                            litem.SubItems.Add(Getname(Tb.Rows[i]["FMYS_NAME"].ToString())); 
                        }
                        listView1.Items.Add(litem);

                        if (Tb.Rows[i]["pat_name"].ToString().Trim().Length == 2)
                        {
                            _name = Tb.Rows[i]["pat_name"].ToString().Trim() + "  ";
                        }
                        if (Tb.Rows[i]["pat_name"].ToString().Trim().Length == 1)
                        {
                            _name = Tb.Rows[i]["pat_name"].ToString().Trim() + "   ";
                        }
                        if (Tb.Rows[i]["pat_name"].ToString().Trim().Length > 2)
                        {
                            _name = Tb.Rows[i]["pat_name"].ToString().Trim();
                        }
                        string jzss = "";
                        Button bt = new Button();
                        bt.ImageList = this.imageList3;
                        if (Tb.Rows[i]["sex_name"].ToString().Trim() == "男")
                        {
                            bt.ImageIndex = 0;
                        }
                        else
                        {
                            bt.ImageIndex = 1;
                        }
                        //bt.Paint += new PaintEventHandler(bt_Paint);
                        bt.FlatStyle = FlatStyle.Flat;
                        bt.Tag = Tb.Rows[i]["sno"].ToString() + "," + Tb.Rows[i]["id"].ToString();//Modiby By Zouchihua 增加手术申请id
                       
                         
                        bt.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
                        bt.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
                        bt.TextAlign = System.Drawing.ContentAlignment.TopRight;
                        bt.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        //表示特殊手术需要上级审核 add by zouchihua 2013-8-30
                        if (ntype<=2&&Convert.ToInt16(Tb.Rows[i]["shbj"]) == 2)
                        {
                            bt.BackColor = Color.Yellow;
                            bt.Tag += ",特殊手术";
                        }
                        bt.Size = new System.Drawing.Size(210, 170);
                        //add by zouchihua 2013-3-5
                        if(ntype == 7)
                            bt.Size = new System.Drawing.Size(210, 180);
                        bt.Location = new System.Drawing.Point(x, y);
                        this.panel4.Controls.Add(bt);
                        //this.panel4.Refresh();

                        if (Convert.ToInt16(Tb.Rows[i]["jzss"]) == 1)
                        {
                            jzss = "加急";
                            bt.ForeColor = Color.Red;
                        }
                        else
                        {
                            bt.ForeColor = Color.Black;
                        }
                        if (ntype <= 2 && Convert.ToInt16(Tb.Rows[i]["shbj"]) == 2)
                            jzss = "特殊手术";
							bt.Text = "病人姓名 " + _name + " " + Tb.Rows[i]["inpatient_no"].ToString().Trim() + "" + "\r\n" +
                            "手术名称 " + Tb.Rows[i]["ysss"].ToString().Trim() + "\r\n" +
                            "主刀医生 " + Tb.Rows[i]["zdys_name"].ToString().Trim() + "\r\n" +
                            "麻醉名称 " + Tb.Rows[i]["ysmz_name"].ToString().Trim() + "\r\n" +
                            "主麻医生 " + Tb.Rows[i]["mzys_name"].ToString().Trim() + "\r\n";
                        if (toolBarButton1.Pushed)
                        {
                                bt.Text += "安排日期 " + Tb.Rows[i]["yxssrq"].ToString().Trim() + "\r\n";
                        }
                        if (rqfw != "" && Tb.Rows[i]["ysssrq"].ToString().Trim() != "")
                        {
                            bt.Text += "拟施日期 " + Convert.ToDateTime(Tb.Rows[0]["ysssrq"]).ToString("yyyy-MM-dd") + "  " + rqfw + "\r\n";
                        }
                        else
                        {
                            bt.Text += "拟施日期 " + Tb.Rows[i]["ysssrq"].ToString().Trim() + "\r\n" ;
                        }
                           bt.Text +=  "申请日期 " + Tb.Rows[i]["sqdjrq"].ToString().Trim() + "\r\n" +
                             "申请科室 " + Tb.Rows[i]["sqks_name"].ToString().Trim() + "\r\n" +//Add By Tany 2011-03-10
                             "手术类型 " + jzss.Trim();
                        //bt.Click+=new EventHandler(bt_Click);
                        if (ntype == 7)//已安排麻醉 add by zouchihua 2013-3-05
                        {
                            bt.Text += "\r\n" + "安排日期 " + Tb.Rows[i]["yxssrq"].ToString().Trim() + "\r\n";
                            bt.Text += "手术房间 " + Tb.Rows[i]["shfjmc"].ToString().Trim() + "\r\n";
                        }
                        bt.Enter += new EventHandler(bt_Enter);
                        bt.MouseDown += new MouseEventHandler(bt_MouseDown);
                        if (x + 320 >= this.listView1.Width)
                        {
                            y = y + 180;
                            x = this.listView1.Location.X;
                        }
                        else
                        {
                            x = x + 220;
                        }
                    }
                    // this.panel4.Show();
                }
            }
            catch (System.Data.OleDb.OleDbException err)
            {
                MessageBox.Show(err.Message + err.Source);
                return;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + err.Source);
                return;
            }
            finally
            {
                //最后清空
                Serchstring = "";
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion
        private string Getname(string Emploee_id)
        {
            try
            {
                DataTable tb = FrmMdiMain.Database.GetDataTable("SELECT NAME FROM jc_employee_property WHERE employee_id=" + Emploee_id);
                if (tb != null && tb.Rows.Count > 0)
                {
                    return tb.Rows[0]["NAME"].ToString();
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        #region 显示图标菜单事件 listview
        private void menuItem10_Click(object sender, System.EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
            this.listView1.Visible = false;
            this.panel4.Visible = true;
        }

        #endregion

        #region 显示列表菜单事件 listview
        private void menuItem11_Click(object sender, System.EventArgs e)
        {
            this.listView1.Visible = true;
            this.panel4.Visible = false;
            this.listView1.View = View.Details;
            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("图标", 10, HorizontalAlignment.Left);
            this.listView1.Columns.Add("病历号", 70, HorizontalAlignment.Left);
            this.listView1.Columns.Add("姓名", 60, HorizontalAlignment.Left);
            this.listView1.Columns.Add("性别", 40, HorizontalAlignment.Left);
            this.listView1.Columns.Add("科室", 80, HorizontalAlignment.Left);
            this.listView1.Columns.Add("术前诊断", 150, HorizontalAlignment.Left);
            this.listView1.Columns.Add("拟实手术", 150, HorizontalAlignment.Left);
            this.listView1.Columns.Add("主刀", 60, HorizontalAlignment.Left);
            this.listView1.Columns.Add("麻醉方法", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("麻醉师", 60, HorizontalAlignment.Left);
            this.listView1.Columns.Add("拟实时间", 150, HorizontalAlignment.Left);
            this.listView1.Columns.Add("手术间", 60, HorizontalAlignment.Left);
            this.listView1.Columns.Add("备注", 60, HorizontalAlignment.Left);
            this.listView1.Columns.Add("手术同意书", 70, HorizontalAlignment.Left);
            this.listView1.Columns.Add("麻醉同意书", 70, HorizontalAlignment.Left);
            this.listView1.Columns.Add("申请医生", 80, HorizontalAlignment.Left);
            this.listView1.Columns.Add("inpatient_id", 0, HorizontalAlignment.Left);
            this.listView1.Columns.Add("id", 0, HorizontalAlignment.Left);//add by zouchihua 2011-11-01
            this.listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;

        }

        #endregion

        #region listview 项的点击事件
        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DataTable Tb = new DataTable();
            System.Windows.Forms.ListViewItem litem = new ListViewItem();
            try
            {
                litem = this.listView1.SelectedItems[0];
            }
            catch
            {
                return;
            }

            this.Sno = Convert.ToString(litem.Tag).Trim();
            this.tsapply_id = new Guid(litem.SubItems[20].Text);//modify by zouchihua 2011-11-01 获得申请id

            //对住院号单独处理 Modify By Weny 2007-6-26     
            string sql = "select inpatient_no,DEPTID from ss_apprecord where sno = " + Sno;
            DataRow dr1= FrmMdiMain.Database.GetDataRow(sql);
            if (dr1 != null)
            {
                this.Inpatient_no = Convert.ToString(dr1["inpatient_No"]);

                this.deptbrzk = Convert.ToInt32(dr1["DEPTID"].ToString());
            }
            //select_ss1.FillTabPage(1);
            DataTable Tinpatient = new DataTable();
            patientInfo1.ClearInpatientInfo();
            GetPatientInfo(Convert.ToString(litem.Tag).Trim());
            patientInfo1.SetInpatientInfo(_inpatientId, 0, 0);

        }

        #endregion

        #region 控制右键菜单的可见性
        private void contextMenu1_Popup(object sender, System.EventArgs e)
        {
            System.Windows.Forms.ListViewItem litem = new ListViewItem();
            try
            {
                litem = this.listView1.SelectedItems[0];
            }
            catch
            {
                return;
            }

            Operate ss = new Operate();
            DataTable ssTab = new DataTable();
            ssTab = ss.SeekAppRecord(litem.Tag.ToString().Trim(), this.Inpatient_no);
            if (ssTab.Rows.Count > 0)
            {
                for (int i = 1; i <= this.contextMenu1.MenuItems.Count; i++)
                {
                    try
                    {
                        this.contextMenu1.MenuItems[i].Enabled = true;
                    }
                    catch
                    {
                        i = i + 1;
                    }
                }
            }
        }
        #endregion

        #region 窗体LOAD
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            this.Tag = "0";
            try
            {
                if (_mzbz == 0)
                {
                    outlookBand1_Click(1);
                    this.toolBar1.Buttons[0].Pushed = true;
                    this.toolBar1.Buttons[0].Visible = true;
                    this.toolBar1.Buttons[1].Visible = true;
                    this.toolBar1.Buttons[2].Visible = false;
                    this.toolBar1.Buttons[3].Visible = false;
                    this.toolBar1.Buttons[4].Visible = false;
                    this.toolBar1.Buttons[5].Visible = false;
                    this.toolBar1.Buttons[6].Visible = false;

                }
                else
                {
                    outlookBand1_Click(4);
                    this.toolBar1.Buttons[3].Pushed = true;
                    this.toolBar1.Buttons[0].Pushed = false;//Modify By tany 2011-04-14 不会自动改变button1的pushed
                    this.toolBar1.Buttons[0].Visible = false;
                    this.toolBar1.Buttons[1].Visible = false;
                    this.toolBar1.Buttons[2].Visible = false;
                    this.toolBar1.Buttons[3].Visible = true;
                    this.toolBar1.Buttons[4].Visible = false;
                    this.toolBar1.Buttons[5].Visible = false;
                    this.toolBar1.Buttons[6].Visible = true;
                    //this.btnserch.Visible = false; Modify By Tany 2015-02-02 麻醉也过滤
                    this.groupBox1.Visible = false;
                }
                //this.timer2.Interval=300000;
            }
            catch (System.Exception err)
            {
                //				_splashScreen.Close();
                MessageBox.Show("加载失败！" + err.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //			finally
            //			{
            //				_splashScreen.Close();
            //			}
            //			
            if (_mzbz == 0)
            {
                //设置报警时间间隔
                string cfgStr = (new SystemCfg(9001)).Config;
                if (cfgStr != "")
                {
                    this.timer1.Interval = Convert.ToDouble(cfgStr) * 1000;
                }
                else
                {
                    this.timer1.Interval = 120000;
                }
                //Add By Tany 2010-07-21 9002急诊手术报警是否默认打开 0=是 1=不是
                if (new SystemCfg(9002).Config == "0")
                {
                    checkBox_BJ.Checked = true;
                }
                else
                {
                    checkBox_BJ.Checked = false;
                }
            }
            else
            {
                checkBox_BJ.Checked = false;
                checkBox_BJ.Enabled = false;
            }
        }
        #endregion

        #region 卡片的点击事件
        //private void bt_Click(object sender, EventArgs e)
        private void bt_Enter(object sender, EventArgs e)
        {
            //			string tag = "";
            //StopSound();         
            try
            {
                Control btt = (Control)sender;
                for (int i = 0; i < +this.panel4.Controls.Count; i++)
                {
                    Control control = (Control)this.panel4.Controls[i];
                    if (control.GetType().ToString().Trim() == "System.Windows.Forms.Button")
                    {
                        
                        control.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
                        if (control.Tag.ToString().IndexOf("特殊手术") >= 0)
                        {
                            control.BackColor = Color.Yellow;

                        }
                    }
                }
                if (btt.Tag.ToString().IndexOf("特殊手术") >= 0 || btt.BackColor == Color.Yellow)
                {
                    this.Inpatient_no = null;
                    btt.BackColor = Color.Yellow;
                    MessageBox.Show("该手术为特殊手术，科主任已经审核，需要上级领导审核才可以安排手术");
                    return;
                }
                       
                btt.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
                this.Tag = (btt.Tag.ToString().Trim().Split(','))[0];//Modiby by zouchihua 
                tsapply_id = new Guid((btt.Tag.ToString().Trim().Split(','))[1]);//Modiby by zouchihua  2011-11-01 获得申请id
                this.Sno = Convert.ToString(this.Tag).Trim();

                //对住院号单独处理 Modify By Weny 2007-6-26     
          
                string sql = "select inpatient_no,DEPTID from ss_apprecord where sno = " + Sno;
                DataRow dr1 = FrmMdiMain.Database.GetDataRow(sql);
                if (dr1 != null)
                {
                    this.Inpatient_no = Convert.ToString(dr1["inpatient_No"]);

                    this.deptbrzk = Convert.ToInt32(dr1["DEPTID"].ToString());
                }
                //string selectText = btt.Text.ToString();
                //select_ss1._pat_name = Convert.ToString(selectText.Substring(3,4)).Trim();
                //select_ss1.FillTabPage(1);

                DataTable Tinpatient = new DataTable();
                patientInfo1.ClearInpatientInfo();

                //这样的写法影响性能  Modify By Weny 2007-6-26
                //string ssql="select distinct a.inpatient_id from ss_apprecord a inner join VI_ZY_VINPATIENT_BED c on a.inpatient_id=c.inpatient_id and c.baby_id=0 where a.sno='"+this.Tag.ToString().Trim()+"' and c.name='"+select_ss1._pat_name.ToString().Trim()+"'";
                // string ssql = "select distinct a.inpatient_id from ss_apprecord a right join zy_inpatient c on a.inpatient_id=c.inpatient_id and c.baby_id=0 where a.sno='" + this.Tag.ToString().Trim() + "' and c.name='" + select_ss1._pat_name.ToString().Trim() + "'";
                // _inpatientId = Convert.ToInt64(FrmMdiMain.Database.GetDataRow(ssql)["inpatient_id"]);
                //this.select_ss1.Tag = FrmMdiMain.Database.GetDataTable(ssql);

                GetPatientInfo(Convert.ToString(this.Tag).Trim());
                patientInfo1.SetInpatientInfo(_inpatientId, 0, 0);

                ClassStatic.Current_BinID = _inpatientId;
                ClassStatic.Current_DeptID = _deptId;
                ClassStatic.Current_BabyID = 0;

                if (this.toolBar1.Buttons[0].Pushed == true)
                {
                    btt.ContextMenu = this.contextMenu1;
                }
                else if (this.toolBar1.Buttons[1].Pushed == true)
                {
                    btt.ContextMenu = this.contextMenu3;
                }
                else if (this.toolBar1.Buttons[2].Pushed == true)
                {
                    btt.ContextMenu = this.contextMenu2;
                }
                else if (this.toolBar1.Buttons[3].Pushed == true)
                {
                    btt.ContextMenu = this.contextMenu2;
                    menuItem3.Visible = false;
                    menuItem18.Visible = true;
                }
                else if (this.toolBar1.Buttons[4].Pushed == true)
                {
                    btt.ContextMenu = this.contextMenu2;
                    
                }
                else if (this.toolBar1.Buttons[5].Pushed == true)
                {
                    btt.ContextMenu = this.contextMenu2; 
                }
                else if (this.toolBar1.Buttons[6].Pushed == true)
                {
                    btt.ContextMenu = this.contextMenu2;
                    menuItem18.Visible = false;
                    menuItem3.Visible = true;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message + err.Source);
            }
        }
        #endregion

        #region 工具栏点击
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            StopSound();//停止报警 
            for (int i = 0; i <= toolBar1.Buttons.Count - 1; i++)
            {
                toolBar1.Buttons[i].Pushed = false;
            }
            e.Button.Pushed = true;
            toolButton = Convert.ToInt32(e.Button.Tag);
            outlookBand1_Click(toolButton);
        }
        #endregion

        #region 病人卡鼠标事件
        private void bt_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            control.Focus();
        }
        #endregion

        #region contextMenu1  菜单
        /// <summary>
        /// 修改手术安排
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem12_Click(object sender, System.EventArgs e)
        {
            //右键 手术安排修改
            if (MessageBox.Show(this, "您确认要修改当前选定的手术安排吗?", "修改手术安排", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Operate ss = new Operate();
                if (ss.UpdataOperate(this.Tag.ToString(), 4) == true)
                {
                    MessageBox.Show("修改成功", "修改手术安排", MessageBoxButtons.OK);
                    this.outlookBand1_Click(1);
                }
            }
        }
        #region 显示麻醉补录信息 modify by caicheng
        /// <summary>
        /// 显示麻醉补录信息
        /// </summary>
        /// <param name="userid">userId</param>
        /// <param name="deptid">科室ID</param>
        /// <param name="ssNo">手术NO</param>
        /// <param name="_inpatient_no">患者NO</param>
        private void ShowFrmACollection(long userid, long deptid, string ssNo, string _inpatient_no)
        {
            if (!IsArrage(ssNo))
            {
                MessageBox.Show("请选择已安排的病人");
            }
            else
            {
                object[] communicateValue = new object[2];
                communicateValue[0] = ssNo;
                communicateValue[1] = _inpatient_no;
                GetForm("Ts_ss_MZBL", "Fun_ts_ss_FrmACollection", "麻醉补录信息", userid, deptid, communicateValue, true);
            }
        }
        #endregion
        /// <summary>
        /// 取消手术安排
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem13_Click(object sender, System.EventArgs e)
        {
            //右键  取消手术安排
            if (MessageBox.Show(this, "您确认要取消当前选定的手术安排吗?", "取消手术安排", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Operate ss = new Operate();
                if (ss.CancelArr(this.Tag.ToString()) == true)
                {
                    MessageBox.Show("取消成功", "取消手术安排", MessageBoxButtons.OK);
                    this.outlookBand1_Click(1);
                }
            }
        }
        #endregion

        #region contextMenu2  菜单
        /// <summary>
        /// 未安排、已经安排选择菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem18_Click(object sender, System.EventArgs e)
        {
            ShowFrmMzap(this._currentUserId, this._currentDeptId, this.Tag.ToString(), this.Inpatient_no.Trim());
            outlookBand1_Click(4);
        }
        #endregion

        #region contextMenu3  菜单
        /// <summary>
        /// 手术安排
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem21_Click(object sender, System.EventArgs e)
        {
            //右键 手术安排
            ShowFrmSsap(this._currentUserId, this._currentDeptId, this.Tag.ToString(), this.Inpatient_no.Trim(), patientInfo1.lbAge.Text);
            outlookBand1_Click(2);
        }
        /// <summary>
        /// 取消手术申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem19_Click(object sender, System.EventArgs e)
        {
            //右键 手术取消
            if (MessageBox.Show("取消手术是不可恢复的，你确定取消吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Operate ss = new Operate();
                if (ss.CancelApp(this.Tag.ToString(), this.Inpatient_no.Trim()) == true)
                {
                    MessageBox.Show("取消成功", "取消手术申请", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.outlookBand1_Click(2);
                }
            }
        }
        #endregion 

        #region 菜单点击
        private void menu_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.MenuItem menu = (System.Windows.Forms.MenuItem)sender;
            menuClick(menu.Text.Trim());
        }
        #endregion

        #region 导航栏点击
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.MenuItem menu = (MenuItem)sender;
            switch (menu.Text)
            {
                case "日常业务":
                    this.outlookBar1.SetCurrentBand(0);
                    break;
                case "其它业务":
                    this.outlookBar1.SetCurrentBand(1);
                    break;
                case "查询统计":
                    this.outlookBar1.SetCurrentBand(2);
                    break;
                case "系统维护":
                    this.outlookBar1.SetCurrentBand(3);
                    break;
            }
            this.outlookBar1.Focus();
        }
        #endregion

        #endregion

        #region 急诊手术报警
        [DllImport("winmm.dll")]
        public static extern bool PlaySound(byte[] lpszSoundName, int hmod, int fdwSound);
        [DllImport("winmm.dll")]
        public static extern int sndPlaySoundA(byte[] lpszSoundName, int fdwSound);
        private const int SND_ASYNC = 1;
        private const int SND_LOOP = 8;
        private const int SND_FILENAME = 131072;
        private const int SND_MEMORY = 0x4;
        private void checkBox_BJ_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (checkBox_BJ.Checked)
                {
                    Type t = this.GetType();
                    Assembly a = t.Assembly;
                    System.IO.Stream stream = a.GetManifestResourceStream(t.Namespace+".BUZZ5.WAV");
                    ba = new byte[stream.Length];
                    stream.Read(ba, 0, ba.Length);
                    stream.Close();
                    this.timer1.Enabled = true;
                }
                else
                {
                    this.timer1.Enabled = false;
                    this.pictureBox1.Visible = false;
                    StopSound();
                    ba = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (IsJzApp())
            {
                PlaySound(ba, 0, SND_MEMORY | SND_ASYNC | SND_LOOP);
                this.timer2.Enabled = true;
                this.pictureBox1.Visible = true;
            }
            else
            {
                StopSound();
                this.timer2.Enabled = false;
                ba = null;
            }
        }
        private void StopSound()
        {
            PlaySound(null, IntPtr.Zero.ToInt32(), SND_ASYNC);//停
            this.pictureBox1.Visible = false;
        }

        #region 是否有急诊手术申请未安排
        private bool IsJzApp()
        {
            string sSql = "select count(*) from ss_apprecord a,vi_zy_vinpatient c where a.ssdept=" + this._currentDeptId + " and a.inpatient_id=c.inpatient_id and c.flag=3 and jzss=1 and apbj=0 and  a.bdelete=0 ";
            try
            {
                DataTable Tb = PubFunction.ExecsqlTable(sSql);
                if (Tb.Rows.Count == 0) return false;
                if (Convert.ToInt32(Tb.Rows[0][0]) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        private void timer2_Tick(object sender, System.EventArgs e)
        {
            if (bj == 0)
            {
                this.pictureBox1.Image = (Image)this.imageList2.Images[0].Clone();
                bj = 1;
            }
            else
            {
                this.pictureBox1.Image = (Image)this.imageList2.Images[1].Clone();
                bj = 0;
            }
        }

        #endregion

        private void menuItemprint_Click(object sender, EventArgs e)
        {  
            try
            {
                Ts_ss_report.RepDataset Dset = new Ts_ss_report.RepDataset();
                DataRow myrow;
                for (int i = 0; i <= this.listView1.Items.Count - 1; i++)
                {
                    myrow = Dset.SS_print.NewRow();
                    myrow["序号"] = i + 1;
                    myrow["病历号"] = this.listView1.Items[i].SubItems[1].Text;
                    myrow["姓名"] = this.listView1.Items[i].SubItems[2].Text;
                    myrow["性别"] = this.listView1.Items[i].SubItems[3].Text;
                    myrow["科室"] = this.listView1.Items[i].SubItems[4].Text;
                    myrow["术前诊断"] = this.listView1.Items[i].SubItems[5].Text;
                    myrow["拟实手术"] = this.listView1.Items[i].SubItems[6].Text;
                    myrow["主刀"] = this.listView1.Items[i].SubItems[7].Text;
                    myrow["麻醉方法"] = this.listView1.Items[i].SubItems[8].Text;
                    myrow["麻醉师"] = this.listView1.Items[i].SubItems[9].Text;
                    myrow["拟实时间"] = this.listView1.Items[i].SubItems[10].Text;
                    myrow["手术间"] = this.listView1.Items[i].SubItems[11].Text;
                    myrow["备注"] = this.listView1.Items[i].SubItems[12].Text;
                    myrow["手术同意书"] = this.listView1.Items[i].SubItems[13].Text;
                    myrow["麻醉同意书"] = this.listView1.Items[i].SubItems[14].Text;
                    myrow["申请医生"] = this.listView1.Items[i].SubItems[15].Text;
                    //Modify By tany 2011-05-10
                    myrow["洗手护士"] = this.listView1.Items[i].SubItems[17].Text;
                    myrow["巡回护士"] = this.listView1.Items[i].SubItems[18].Text;
                    myrow["床号"] = this.listView1.Items[i].SubItems[19].Text;
                    //21 ssyz_name
                     //Modify by zouchihua 2012-01-11
                    myrow["年龄"] = this.listView1.Items[i].SubItems[21].Text;
                    myrow["一助姓名"] = this.listView1.Items[i].SubItems[22].Text;
                    //Modify by zouchihua 2012-05-12
                    myrow["辅麻医生"] = this.listView1.Items[i].SubItems[23].Text;
                    Dset.SS_print.Rows.Add(myrow);
                    

                }
                DataTable temp = Dset.SS_print.Copy();
                DataView dv = new DataView(temp);
				//dv.Sort = "手术间"; //按照手术间 改成后台控制 Modify by zouchihua 2013-9-4

				//Modify By caicheng 2013-10-12
				if (toolBarButton1.Pushed) {
					dv.Sort = "手术间"; //按照科室排序
				}
				else {
					dv.Sort = "科室";
				}
				// end Modify
                temp = dv.ToTable(); 
                ///add by zouchihua 2011-12-29 按手术间排序
                Dset.SS_print.Rows.Clear();
                for (int i = 0; i < temp.Rows.Count;i++ )
                {
                    temp.Rows[i]["序号"] = i + 1;
                    Dset.SS_print.Rows.Add(temp.Rows[i].ItemArray);
                }
                //Add by Tany 2011-03-04
                string tt = "";
                try
                {
                    if (toolBarButton1.Pushed)
                    {
                        tt = "（已安排）";
                    }
                    else if (toolBarButton2.Pushed)
                    {
                        tt = "（未安排）";
                    }
                }
                catch
                {
                }

                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "TITLETEXT";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "手术一览表" + tt;
                parameters[1].Text = "bz";
                parameters[1].Value = "";

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.SS_print, Constant.ApplicationDirectory + "\\Report\\SS_手术一览表.rpt", parameters);
                if (f.LoadReportSuccess) f.Show(); else f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Enabled = false;
            this.pictureBox1.Visible = false;
            StopSound();
            ba = null;
        }

        private void btnserch_Click(object sender, EventArgs e)
        {
            Frmserch frm = new Frmserch();
            frm.ShowDialog();
            Serchstring = frm.Tj;
            if (Serchstring.Trim() == "")
                return;
            Serchstring = "1=1 and " + Serchstring;
            StopSound();//停止报警 
            int j = 0;
            for (int i = 0; i <= toolBar1.Buttons.Count - 1; i++)
            {
                if (toolBar1.Buttons[i].Pushed == true)
                {
                    j = i;
                    break;
                }
            }
            toolButton = Convert.ToInt32(toolBar1.Buttons[j].Tag);
            outlookBand1_Click(toolButton);
        }

        private void rdbsy_CheckedChanged(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i <= toolBar1.Buttons.Count - 1; i++)
            {
                if (toolBar1.Buttons[i].Pushed == true)
                {
                    j = i;
                    break;
                }
            }
            toolButton = Convert.ToInt32(toolBar1.Buttons[j].Tag);
            outlookBand1_Click(toolButton);
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                Ts_ss_report.RepDataset Dset = new Ts_ss_report.RepDataset();
                DataRow myrow;
                for (int i = 0; i <= this.listView1.Items.Count - 1; i++)
                {
                    myrow = Dset.SS_print.NewRow();
                    myrow["序号"] = i + 1;
                    myrow["病历号"] = this.listView1.Items[i].SubItems[1].Text;
                    myrow["姓名"] = this.listView1.Items[i].SubItems[2].Text;
                    myrow["性别"] = this.listView1.Items[i].SubItems[3].Text;
                    myrow["科室"] = this.listView1.Items[i].SubItems[4].Text;
                    myrow["术前诊断"] = this.listView1.Items[i].SubItems[5].Text;
                    myrow["拟实手术"] = this.listView1.Items[i].SubItems[6].Text;
                    myrow["主刀"] = this.listView1.Items[i].SubItems[7].Text;
                    myrow["麻醉方法"] = this.listView1.Items[i].SubItems[8].Text;
                    myrow["麻醉师"] = this.listView1.Items[i].SubItems[9].Text;
                    myrow["拟实时间"] = this.listView1.Items[i].SubItems[10].Text;
                    myrow["手术间"] = this.listView1.Items[i].SubItems[11].Text;
                    myrow["备注"] = this.listView1.Items[i].SubItems[12].Text;
                    myrow["手术同意书"] = this.listView1.Items[i].SubItems[13].Text;
                    myrow["麻醉同意书"] = this.listView1.Items[i].SubItems[14].Text;
                    myrow["申请医生"] = this.listView1.Items[i].SubItems[15].Text;
                    //Modify By tany 2011-05-10
                    myrow["洗手护士"] = this.listView1.Items[i].SubItems[17].Text;
                    myrow["巡回护士"] = this.listView1.Items[i].SubItems[18].Text;
                    myrow["床号"] = this.listView1.Items[i].SubItems[19].Text;
                    //21 ssyz_name
                    //Modify by zouchihua 2012-01-11
                    myrow["年龄"] = this.listView1.Items[i].SubItems[21].Text;
                    myrow["一助姓名"] = this.listView1.Items[i].SubItems[22].Text;
                    //Modify by zouchihua 2012-05-12
                    myrow["辅麻医生"] = this.listView1.Items[i].SubItems[23].Text;
                    Dset.SS_print.Rows.Add(myrow); 
                }
                DataTable temp = Dset.SS_print.Copy();
                DataView dv = new DataView(temp);
                //dv.Sort = "手术间"; //按照手术间 改成后台控制 Modify by zouchihua 2013-9-4

                //Modify By caicheng 2013-10-12
                if (toolBarButton1.Pushed)
                {
                    dv.Sort = "手术间"; //按照科室排序
                }
                else
                {
                    dv.Sort = "科室";
                }
                // end Modify
                temp = dv.ToTable();
                ///add by zouchihua 2011-12-29 按手术间排序
                Dset.SS_print.Rows.Clear();
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    temp.Rows[i]["序号"] = i + 1;
                    Dset.SS_print.Rows.Add(temp.Rows[i].ItemArray);
                }
                //Add by Tany 2011-03-04
                string tt = "";
                try
                {
                    if (toolBarButton1.Pushed)
                    {
                        tt = "（已安排）";
                    }
                    else if (toolBarButton2.Pushed)
                    {
                        tt = "（未安排）";
                    }
                }
                catch
                {

                }

                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "TITLETEXT";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "麻醉一览表" + tt;
                parameters[1].Text = "bz";
                parameters[1].Value = "";

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.SS_print, Constant.ApplicationDirectory + "\\Report\\SS_麻醉一览表.rpt", parameters);
                if (f.LoadReportSuccess) f.Show(); else f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void rdbWjz_CheckedChanged(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i <= toolBar1.Buttons.Count - 1; i++)
            {
                if (toolBar1.Buttons[i].Pushed == true)
                {
                    j = i;
                    break;
                }
            }
            toolButton = Convert.ToInt32(toolBar1.Buttons[j].Tag);

            outlookBand1_Click(toolButton);
        } 
       
    }
}
