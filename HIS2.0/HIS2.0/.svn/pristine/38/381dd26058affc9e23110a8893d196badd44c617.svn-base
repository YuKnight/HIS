using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
namespace TrasenMainWindow
{
    /// <summary>
    /// 系统定义，系统菜单设置对话框
    /// </summary>
    public class FrmSystemSet : System.Windows.Forms.Form
    {
        //自定义变
        //private DataTable _menuTable;
        /// <summary>
        /// 本窗体的数据库连接
        /// </summary>
        private RelationalDatabase db;//Add By Tany 2010-01-27
        /// <summary>
        /// 本窗体连接的机构编码
        /// </summary>
        private int jgbm;//Add By Tany 2010-01-27

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList img;
        private System.Windows.Forms.ToolBarButton tlbtnLoadDll;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ToolBarButton toolBarButton4;
        private System.Windows.Forms.ToolBarButton tlbbtnAddSystem;
        private System.Windows.Forms.ToolBarButton tlbbtnExit;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private TrasenClasses.GeneralControls.DataGridEx dtgrdMenu;
        private TrasenClasses.GeneralControls.ListViewEx lvwDllFile;
        private System.Windows.Forms.ProgressBar pgbLoad;
        private System.Windows.Forms.ListView lvwSystem;
        private System.Windows.Forms.TreeView tvwMenu;
        private System.Windows.Forms.ToolBar tblMain;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAddToSystem;
        private System.Windows.Forms.ContextMenu menuMenu;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuOption;
        private System.Windows.Forms.MenuItem mnuAddTopMenu;
        private System.Windows.Forms.MenuItem mnuAddSubmenu;
        private System.Windows.Forms.MenuItem mnuRemovemenu;
        private System.Windows.Forms.MenuItem menuSortmenu;
        private System.Windows.Forms.MenuItem mnuAddSubTopmenu;
        private System.Windows.Forms.ToolBarButton tlbbtnAddToTable;
        private System.Windows.Forms.ToolBarButton tlbbtnRemoveFromTable;
        private System.Windows.Forms.ToolBarButton tlbbtnEditmenu;
        private TrasenClasses.GeneralControls.ComboGridSearch comboGridSearch1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ToolBarButton toolBarButton5;
        private Panel panel11;
        private TextBox txtFind;
        private Label label5;
        private System.ComponentModel.IContainer components;
        private TextBox txt_loaddllErr;

        private System.Collections.Generic.List<ListViewItem> lstDllItems = new System.Collections.Generic.List<ListViewItem>();
        /// <summary>
        /// 系统设置
        /// </summary>
        public FrmSystemSet()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            //Modify By Tany 2010-01-27 使用本窗体自己的数据连接
            //如果设置了中心机构编码并且中心机构编码不等于当前连接的机构编码，则重新实例化本地连接为中心数据库连接
            if ( TrasenFrame.Forms.FrmMdiMain.ZxJgbm != -1 && TrasenFrame.Forms.FrmMdiMain.ZxJgbm != TrasenFrame.Forms.FrmMdiMain.Jgbm )
            {
                db = WorkStaticFun.GetJgbmDb(FrmMdiMain.ZxJgbm);
                jgbm = FrmMdiMain.ZxJgbm;
            }
            else
            {
                db = FrmMdiMain.Database;
                jgbm = FrmMdiMain.Jgbm;
            }
            this.Text += "【" + jgbm + "】";
            CreateGridColumnStyle();
            LoadMenu();
            LoadSystem();

            pgbLoad.Visible = false;
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
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

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystemSet));
            this.tblMain = new System.Windows.Forms.ToolBar();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.tlbtnLoadDll = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tlbbtnAddSystem = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.tlbbtnAddToTable = new System.Windows.Forms.ToolBarButton();
            this.tlbbtnRemoveFromTable = new System.Windows.Forms.ToolBarButton();
            this.tlbbtnEditmenu = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tlbbtnExit = new System.Windows.Forms.ToolBarButton();
            this.img = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dtgrdMenu = new TrasenClasses.GeneralControls.DataGridEx();
            this.listView2 = new System.Windows.Forms.ListView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.comboGridSearch1 = new TrasenClasses.GeneralControls.ComboGridSearch();
            this.btnAddToSystem = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lvwDllFile = new TrasenClasses.GeneralControls.ListViewEx(this.components);
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pgbLoad = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvwSystem = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tvwMenu = new System.Windows.Forms.TreeView();
            this.menuMenu = new System.Windows.Forms.ContextMenu();
            this.menuOption = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.mnuAddTopMenu = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuAddSubmenu = new System.Windows.Forms.MenuItem();
            this.mnuAddSubTopmenu = new System.Windows.Forms.MenuItem();
            this.mnuRemovemenu = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuSortmenu = new System.Windows.Forms.MenuItem();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_loaddllErr = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdMenu)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tblMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton3,
            this.tlbtnLoadDll,
            this.toolBarButton2,
            this.tlbbtnAddSystem,
            this.toolBarButton5,
            this.toolBarButton4,
            this.tlbbtnAddToTable,
            this.tlbbtnRemoveFromTable,
            this.tlbbtnEditmenu,
            this.toolBarButton1,
            this.tlbbtnExit});
            this.tblMain.DropDownArrows = true;
            this.tblMain.ImageList = this.img;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.ShowToolTips = true;
            this.tblMain.Size = new System.Drawing.Size(1000, 43);
            this.tblMain.TabIndex = 0;
            this.tblMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tblMain_ButtonClick);
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbtnLoadDll
            // 
            this.tlbtnLoadDll.ImageIndex = 2;
            this.tlbtnLoadDll.Name = "tlbtnLoadDll";
            this.tlbtnLoadDll.Tag = "LOAD_DLL";
            this.tlbtnLoadDll.Text = "加载";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbbtnAddSystem
            // 
            this.tlbbtnAddSystem.ImageIndex = 0;
            this.tlbbtnAddSystem.Name = "tlbbtnAddSystem";
            this.tlbbtnAddSystem.Tag = "ADD_SYSTEM";
            this.tlbbtnAddSystem.Text = "添加系统";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.ImageIndex = 9;
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Tag = "DEL_SYSTEM";
            this.toolBarButton5.Text = "删除系统";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbbtnAddToTable
            // 
            this.tlbbtnAddToTable.ImageIndex = 24;
            this.tlbbtnAddToTable.Name = "tlbbtnAddToTable";
            this.tlbbtnAddToTable.Tag = "ADD_TO_TABLE";
            this.tlbbtnAddToTable.Text = "添加到现有";
            // 
            // tlbbtnRemoveFromTable
            // 
            this.tlbbtnRemoveFromTable.ImageIndex = 25;
            this.tlbbtnRemoveFromTable.Name = "tlbbtnRemoveFromTable";
            this.tlbbtnRemoveFromTable.Tag = "REMOVE_FROM_TABLE";
            this.tlbbtnRemoveFromTable.Text = "从现有移除";
            // 
            // tlbbtnEditmenu
            // 
            this.tlbbtnEditmenu.ImageIndex = 23;
            this.tlbbtnEditmenu.Name = "tlbbtnEditmenu";
            this.tlbbtnEditmenu.Tag = "EDIT_MENU";
            this.tlbbtnEditmenu.Text = "编辑菜单";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbbtnExit
            // 
            this.tlbbtnExit.ImageIndex = 5;
            this.tlbbtnExit.Name = "tlbbtnExit";
            this.tlbbtnExit.Tag = "CLOSE";
            this.tlbbtnExit.Text = "关闭";
            // 
            // img
            // 
            this.img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img.ImageStream")));
            this.img.TransparentColor = System.Drawing.Color.Transparent;
            this.img.Images.SetKeyName(0, "");
            this.img.Images.SetKeyName(1, "");
            this.img.Images.SetKeyName(2, "");
            this.img.Images.SetKeyName(3, "");
            this.img.Images.SetKeyName(4, "");
            this.img.Images.SetKeyName(5, "");
            this.img.Images.SetKeyName(6, "");
            this.img.Images.SetKeyName(7, "");
            this.img.Images.SetKeyName(8, "");
            this.img.Images.SetKeyName(9, "");
            this.img.Images.SetKeyName(10, "");
            this.img.Images.SetKeyName(11, "");
            this.img.Images.SetKeyName(12, "");
            this.img.Images.SetKeyName(13, "");
            this.img.Images.SetKeyName(14, "");
            this.img.Images.SetKeyName(15, "");
            this.img.Images.SetKeyName(16, "");
            this.img.Images.SetKeyName(17, "");
            this.img.Images.SetKeyName(18, "");
            this.img.Images.SetKeyName(19, "");
            this.img.Images.SetKeyName(20, "");
            this.img.Images.SetKeyName(21, "");
            this.img.Images.SetKeyName(22, "");
            this.img.Images.SetKeyName(23, "");
            this.img.Images.SetKeyName(24, "");
            this.img.Images.SetKeyName(25, "");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 629);
            this.panel1.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dtgrdMenu);
            this.panel5.Controls.Add(this.listView2);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 234);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(594, 395);
            this.panel5.TabIndex = 2;
            // 
            // dtgrdMenu
            // 
            this.dtgrdMenu.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtgrdMenu.CaptionBackColor = System.Drawing.SystemColors.Desktop;
            this.dtgrdMenu.CaptionVisible = false;
            this.dtgrdMenu.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dtgrdMenu.DataMember = "";
            this.dtgrdMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdMenu.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgrdMenu.Location = new System.Drawing.Point(0, 32);
            this.dtgrdMenu.Name = "dtgrdMenu";
            this.dtgrdMenu.ReadOnly = true;
            this.dtgrdMenu.RowHeaderWidth = 20;
            this.dtgrdMenu.Size = new System.Drawing.Size(594, 363);
            this.dtgrdMenu.TabIndex = 2;
            this.dtgrdMenu.CurrentCellChanged += new System.EventHandler(this.dtgrdMenu_CurrentCellChanged);
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Location = new System.Drawing.Point(0, 32);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(594, 363);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.comboGridSearch1);
            this.panel7.Controls.Add(this.btnAddToSystem);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(594, 32);
            this.panel7.TabIndex = 0;
            // 
            // comboGridSearch1
            // 
            this.comboGridSearch1.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboGridSearch1.Location = new System.Drawing.Point(98, 0);
            this.comboGridSearch1.MappingDataGrid = this.dtgrdMenu;
            this.comboGridSearch1.Name = "comboGridSearch1";
            this.comboGridSearch1.Size = new System.Drawing.Size(442, 28);
            this.comboGridSearch1.TabIndex = 6;
            this.comboGridSearch1.TableStyleIndex = 0;
            // 
            // btnAddToSystem
            // 
            this.btnAddToSystem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddToSystem.ImageIndex = 0;
            this.btnAddToSystem.ImageList = this.imageList1;
            this.btnAddToSystem.Location = new System.Drawing.Point(562, 0);
            this.btnAddToSystem.Name = "btnAddToSystem";
            this.btnAddToSystem.Size = new System.Drawing.Size(28, 28);
            this.btnAddToSystem.TabIndex = 5;
            this.btnAddToSystem.Visible = false;
            this.btnAddToSystem.Click += new System.EventHandler(this.btnAddToSystem_Click);
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
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "现有菜单";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 230);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(594, 4);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel11);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(594, 230);
            this.panel4.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.lvwDllFile);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 44);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(594, 186);
            this.panel11.TabIndex = 3;
            // 
            // lvwDllFile
            // 
            this.lvwDllFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader4});
            this.lvwDllFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDllFile.FullRowSelect = true;
            this.lvwDllFile.HideSelection = false;
            this.lvwDllFile.Location = new System.Drawing.Point(0, 0);
            this.lvwDllFile.Name = "lvwDllFile";
            this.lvwDllFile.Size = new System.Drawing.Size(594, 186);
            this.lvwDllFile.TabIndex = 1;
            this.lvwDllFile.UseCompatibleStateImageBehavior = false;
            this.lvwDllFile.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "功能名称";
            this.columnHeader6.Width = 92;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "调用函数名";
            this.columnHeader2.Width = 118;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 116;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "路径";
            this.columnHeader4.Width = 240;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtFind);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.pgbLoad);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(594, 44);
            this.panel6.TabIndex = 0;
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(441, 21);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(151, 21);
            this.txtFind.TabIndex = 26;
            this.txtFind.DoubleClick += new System.EventHandler(this.txtFind_DoubleClick);
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(411, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "查找";
            // 
            // pgbLoad
            // 
            this.pgbLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgbLoad.Location = new System.Drawing.Point(116, 0);
            this.pgbLoad.Name = "pgbLoad";
            this.pgbLoad.Size = new System.Drawing.Size(478, 44);
            this.pgbLoad.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "动态链接库";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Location = new System.Drawing.Point(594, 43);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 629);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvwSystem);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(597, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 629);
            this.panel2.TabIndex = 5;
            // 
            // lvwSystem
            // 
            this.lvwSystem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader5});
            this.lvwSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSystem.FullRowSelect = true;
            this.lvwSystem.HideSelection = false;
            this.lvwSystem.Location = new System.Drawing.Point(0, 44);
            this.lvwSystem.Name = "lvwSystem";
            this.lvwSystem.Size = new System.Drawing.Size(203, 585);
            this.lvwSystem.TabIndex = 1;
            this.lvwSystem.UseCompatibleStateImageBehavior = false;
            this.lvwSystem.View = System.Windows.Forms.View.Details;
            this.lvwSystem.SelectedIndexChanged += new System.EventHandler(this.lvwSystem_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "序号";
            this.columnHeader7.Width = 42;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "系统名称";
            this.columnHeader5.Width = 144;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(203, 44);
            this.panel8.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 44);
            this.label3.TabIndex = 1;
            this.label3.Text = "系统列表";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(800, 43);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 629);
            this.splitter3.TabIndex = 6;
            this.splitter3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_loaddllErr);
            this.panel3.Controls.Add(this.tvwMenu);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(803, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(197, 629);
            this.panel3.TabIndex = 7;
            // 
            // tvwMenu
            // 
            this.tvwMenu.ContextMenu = this.menuMenu;
            this.tvwMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwMenu.HideSelection = false;
            this.tvwMenu.ImageIndex = 0;
            this.tvwMenu.ImageList = this.img;
            this.tvwMenu.Location = new System.Drawing.Point(0, 44);
            this.tvwMenu.Name = "tvwMenu";
            this.tvwMenu.SelectedImageIndex = 0;
            this.tvwMenu.Size = new System.Drawing.Size(197, 585);
            this.tvwMenu.TabIndex = 1;
            // 
            // menuMenu
            // 
            this.menuMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuOption,
            this.menuItem4,
            this.mnuAddTopMenu,
            this.menuItem3,
            this.mnuAddSubmenu,
            this.mnuAddSubTopmenu,
            this.mnuRemovemenu,
            this.menuItem7,
            this.menuSortmenu});
            // 
            // menuOption
            // 
            this.menuOption.Index = 0;
            this.menuOption.Text = "菜单选项";
            this.menuOption.Click += new System.EventHandler(this.menuOption_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "-";
            // 
            // mnuAddTopMenu
            // 
            this.mnuAddTopMenu.Index = 2;
            this.mnuAddTopMenu.Text = "增加顶级菜单";
            this.mnuAddTopMenu.Click += new System.EventHandler(this.mnuAddTopMenu_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // mnuAddSubmenu
            // 
            this.mnuAddSubmenu.Index = 4;
            this.mnuAddSubmenu.Text = "增加选中的菜单";
            this.mnuAddSubmenu.Click += new System.EventHandler(this.mnuAddSubmenu_Click);
            // 
            // mnuAddSubTopmenu
            // 
            this.mnuAddSubTopmenu.Index = 5;
            this.mnuAddSubTopmenu.Text = "增加选中的菜单为顶级菜单";
            this.mnuAddSubTopmenu.Click += new System.EventHandler(this.mnuAddSubTopmenu_Click);
            // 
            // mnuRemovemenu
            // 
            this.mnuRemovemenu.Index = 6;
            this.mnuRemovemenu.Text = "移除菜单";
            this.mnuRemovemenu.Click += new System.EventHandler(this.mnuRemovemenu_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            this.menuItem7.Text = "-";
            // 
            // menuSortmenu
            // 
            this.menuSortmenu.Index = 8;
            this.menuSortmenu.Text = "排序该级菜单";
            this.menuSortmenu.Click += new System.EventHandler(this.menuSortmenu_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label4);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(197, 44);
            this.panel9.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 44);
            this.label4.TabIndex = 1;
            this.label4.Text = "菜单结构";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_loaddllErr
            // 
            this.txt_loaddllErr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_loaddllErr.Location = new System.Drawing.Point(122, 45);
            this.txt_loaddllErr.Multiline = true;
            this.txt_loaddllErr.Name = "txt_loaddllErr";
            this.txt_loaddllErr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_loaddllErr.Size = new System.Drawing.Size(73, 584);
            this.txt_loaddllErr.TabIndex = 2;
            this.txt_loaddllErr.Visible = false;
            // 
            // FrmSystemSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1000, 672);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tblMain);
            this.Name = "FrmSystemSet";
            this.Text = "系统菜单设置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdMenu)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// 创建表头式样
        /// </summary>
        private void CreateGridColumnStyle()
        {
            //Modify By Tany 2010-01-14 增加 机构编码
            string[] head = new string[] { "编号", "菜单名称", "Dll文件", "调用函数名", "附属值", "机构编码" };
            string[] mapping = new string[] { "menu_id", "Name", "Dll_Name", "Function_Name", "function_tag", "jgbm" };
            int[] colWidth = new int[] { 30, 100, 100, 160, 80, 60 };
            this.dtgrdMenu.CreateTableStyle(head, mapping, colWidth);
        }

        /// <summary>
        /// 加载本地dll信息
        /// </summary>
        private void LoadDll()
        {
            Cursor.Current = Cursors.WaitCursor;
            //获取路径下可用菜单
            DirectoryInfo folder = new DirectoryInfo(Constant.ApplicationDirectory);
            pgbLoad.BringToFront();
            //jianqg 2012-10-26 用 txx_loaddllErr 保持错误信息，便于查找问题
            txt_loaddllErr.Text = ""; txt_loaddllErr.Visible = false;
            //Modify By Tany 2012-05-16 查找指定名称的DLL
            
            string strDll = txtFind.Text.Trim();
            if (strDll == "")
            {
                strDll = "*.dll";
            }
            else
            {
                strDll = "*" + strDll + "*.dll";
            }

            FileInfo[] files = folder.GetFiles(strDll);

            pgbLoad.Value = 0;
            pgbLoad.Maximum = files.Length;
            pgbLoad.Visible = true;
            lstDllItems.Clear();
            lvwDllFile.Items.Clear();//Modify By Tany 2012-05-16 清空列表
            foreach (FileInfo f in files)
            {
                
                try
                {
                    pgbLoad.Value++;
                    string sDllName  = f.Name.Remove(f.Name.LastIndexOf(f.Extension), f.Extension.Length).Trim();
                    
                    ObjectInfo[] funInfo;
                    ObjectInfo dllInfo;
                    Assembly assembly = Assembly.LoadFrom(f.FullName);
                    Type type = assembly.GetType(sDllName + ".InstanceForm", false, true);
                    if( type == null )
                        continue;
  
                    
                    Object obj = System.Activator.CreateInstance(type);
                    if( obj == null )
                        continue;

                    ((IDllInformation)obj).Database = db;
                    funInfo = ((IDllInformation)obj).GetFunctionsInfo();
                    dllInfo = ((IDllInformation)obj).GetDllInfo();

                    if( funInfo != null )
                    {
                        //循环添加该Dll所有引出函数
                        for( int i = 0 ; i < funInfo.Length ; i++ )
                        {
                            if( funInfo[i].Text.Trim() != "" )
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = funInfo[i].Text;
                                item.SubItems.Add( funInfo[i].Name );
                                item.SubItems.Add( sDllName );
                                item.SubItems.Add( f.DirectoryName );
                                lvwDllFile.Items.Add( item );
                                lstDllItems.Add( item );
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    //jianqg 2012-10-26 用 txx_loaddllErr 保持错误信息，便于查找问题
                    string strErr = txt_loaddllErr.Text;
                    if (txt_loaddllErr.Text != "") strErr += "\r\n";
                    strErr += f.Name + " 发生错误：" + err.Message;
                    txt_loaddllErr.Text = strErr;
                    Console.Write(err.Message);
                    //忽略错误
                }
            }
            pgbLoad.Visible = false;

            Cursor.Current = Cursors.Default;
        }

        //jianqg 2012-10-26 用 txx_loaddllErr 保持错误信息，便于查找问题
        private void txtFind_DoubleClick(object sender, EventArgs e)
        {
            if (txt_loaddllErr.Text.Trim() != "") txt_loaddllErr.Visible =true;
        }
        /// <summary>
        /// 加载已经保存的菜单列表
        /// </summary>
        private void LoadMenu()
        {
            try
            {
                string sql = "select * from pub_menu order by menu_id";
                DataTable tbMenu = db.GetDataTable(sql);
                this.dtgrdMenu.DataSource = tbMenu.DefaultView;
                PubStaticFun.ModifyDataGridStyle(this.dtgrdMenu, 0);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 加载已经定义的系统列表
        /// </summary>
        private void LoadSystem()
        {
            this.lvwSystem.Items.Clear();
            try
            {
                DataTable tbSystem = FrmMdiMain.LoadSystemList(db);
                if (tbSystem != null)
                {
                    for (int i = 0; i < tbSystem.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = tbSystem.Rows[i]["system_id"].ToString().Trim();
                        item.Text = Convert.ToString(i + 1);
                        item.SubItems.Add(tbSystem.Rows[i]["Name"].ToString().Trim());
                        lvwSystem.Items.Add(item);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 显示选中的系统的菜单结构
        /// </summary>
        private void DisplaySystemMenuStruct(int SystemID)
        {
            try
            {
                tvwMenu.Nodes.Clear();
                tvwMenu.BeginUpdate();
                DataTable tableMenu = FrmMdiMain.LoadSystemMenuList(SystemID, db);
                DataRow[] parentMenu = tableMenu.Select("Parent_Id=-1", "Sort_Id");
                for (int i = 0; i < parentMenu.Length; i++)
                {
                    TreeNode parentNode = new TreeNode();
                    parentNode.Text = parentMenu[i]["Name"].ToString().Trim();
                    parentNode.Tag = parentMenu[i]["menu_id"].ToString();

                    AddSubMenu(tableMenu, parentNode, Convert.ToInt32(parentMenu[i]["menu_id"]));

                    parentNode.ExpandAll();
                    tvwMenu.Nodes.Add(parentNode);
                }
                tvwMenu.EndUpdate();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="tableMenu"></param>
        /// <param name="parentMenu"></param>
        /// <param name="parentMenuId"></param>
        private void AddSubMenu(DataTable tableMenu, TreeNode parentMenu, int parentMenuId)
        {
            try
            {
                DataRow[] rows = tableMenu.Select("Parent_Id=" + parentMenuId.ToString(), "Sort_Id");
                for (int i = 0; i < rows.Length; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = rows[i]["Name"].ToString().Trim();
                    node.Tag = rows[i]["menu_id"].ToString();

                    AddSubMenu(tableMenu, node, Convert.ToInt32(rows[i]["menu_id"]));
                    parentMenu.Nodes.Add(node);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 编辑系统信息
        /// </summary>
        /// <param name="IsEdit"></param>
        /// <param name="sysId"></param>
        /// <param name="sysName"></param>
        /// <param name="sortId"></param>
        /// <param name="deleteBit"></param>
        private int EditSystem(bool IsEdit, int sysId, string sysName, int sortId, int deleteBit)
        {
            try
            {
                IDbCommand cmd = db.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                ParameterEx[] paras = new ParameterEx[8];
                #region ...
                paras[0].Text = "@SystemId";
                paras[0].Value = sysId;

                paras[1].Text = "@SystemName";
                paras[1].Value = sysName;

                paras[2].Text = "@SortId";
                paras[2].Value = sortId;

                paras[3].Text = "@PyCode";
                paras[3].Value = PubStaticFun.GetPYWBM(sysName, 0); //jianqg 2012-6-26 增加

                paras[4].Text = "@WbCode";
                paras[4].Value = PubStaticFun.GetPYWBM(sysName, 1);//jianqg 2012-6-26 增加

                paras[5].Text = "@DCode";
                paras[5].Value = "";

                paras[6].Text = "@DeleteBit";
                paras[6].Value = deleteBit;

                paras[7].Text = "@Errmsg ";
                paras[7].ParaSize = 200;
                paras[7].ParaDirection = ParameterDirection.Output;
                #endregion
                db.SetParameters(cmd, paras);

                try
                {
                    //定义多院操作日志 Modify By Tany 2010-01-29
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    Guid log_djid = Guid.Empty;

                    db.BeginTransaction();
                    if (IsEdit)
                    {
                        cmd.CommandText = "up_EditSystemInfo";
                        db.DoCommand(cmd);

                        //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                        string cznr = "修改系统:【" + sysName + "】";
                        ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, cznr, "pub_system", "system_Id", sysId.ToString(), jgbm, -999, "", out log_djid, db);

                        db.CommitTransaction();

                        try
                        {
                            //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                            string errtext = "";
                            ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, db);
                            if (ty.Bzx == 1 && log_djid != Guid.Empty)
                            {
                                //立即执行该操作 Modify By Tany 2010-01-29
                                ts.Pexec_log(log_djid, db, out errtext);
                            }
                            if (errtext != "")
                            {
                                throw new Exception(errtext);
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        return sysId;
                    }
                    else
                    {
                        object newId;
                        cmd.CommandText = "up_AddSystemInfo";
                        db.InsertRecord(cmd, out newId);

                        object obj = ((IDataParameter)cmd.Parameters[7]).Value;

                        if (obj.ToString() != "")
                        {
                            db.RollbackTransaction();
                            MessageBox.Show(obj.ToString());
                            return -1;
                        }
                        else
                        {
                            //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                            string cznr = "新增系统:【" + sysName + "】";
                            ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, cznr, "pub_system", "system_Id", newId.ToString(), jgbm, -999, "", out log_djid, db);

                            db.CommitTransaction();

                            try
                            {
                                //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                                string errtext = "";
                                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, db);
                                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                                {
                                    //立即执行该操作 Modify By Tany 2010-01-29
                                    ts.Pexec_log(log_djid, db, out errtext);
                                }
                                if (errtext != "")
                                {
                                    throw new Exception(errtext);
                                }
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            return Convert.ToInt32(newId);
                        }
                    }
                }
                catch(Exception err)
                {
                    db.RollbackTransaction();
                    throw err;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return -1;
            }

        }

        /// <summary>
        /// 添加系统菜单,,返回0则表示没有添加成功
        /// </summary>
        /// <param name="systemId">系统编号</param>
        /// <param name="menuId">菜单编号</param>
        /// <param name="parentMenuId">父级菜单编号</param>
        /// <returns>新增加的菜单编号,返回0则表示没有添加成功</returns>
        private int AddSystemMenu(int systemId, int menuId, string menuName, int parentMenuId)
        {
            try
            {
                ParameterEx[] paras = new ParameterEx[5];
                #region ...
                paras[0].Text = "@SysMenuId";
                paras[0].ParaSize = 100;
                paras[0].ParaDirection = ParameterDirection.Output;
                paras[1].Text = "@SystemId";
                paras[1].Value = systemId;
                paras[2].Text = "@MenuId";
                paras[2].Value = menuId;
                paras[3].Text = "@ParentMenuId";
                paras[3].Value = parentMenuId;
                paras[4].Text = "@Errmsg";
                paras[4].ParaSize = 200;
                paras[4].ParaDirection = ParameterDirection.Output;
                #endregion
                IDbCommand cmd = db.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "up_AddMenuToSystem";
                db.SetParameters(cmd, paras);
                object obj;

                try
                {
                    //定义多院操作日志 Modify By Tany 2010-01-30
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    Guid log_djid = Guid.Empty;

                    db.BeginTransaction();

                    db.InsertRecord(cmd, out obj);
                    if (((IDataParameter)cmd.Parameters[4]).Value.ToString().Trim() != "")
                    {
                        db.RollbackTransaction();
                        MessageBox.Show(((IDataParameter)cmd.Parameters[4]).Value.ToString().Trim(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }

                    //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-30
                    string cznr = "新增系统菜单:【往系统 " + lvwSystem.SelectedItems[0].SubItems[1].Text.Trim() + " 中新增菜单 " + menuName + "】";
                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, cznr, "pub_system_menu", "Sys_Menu_Id", obj.ToString(), jgbm, -999, "", out log_djid, db);

                    db.CommitTransaction();

                    try
                    {
                        //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-30
                        string errtext = "";
                        ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, db);
                        if (ty.Bzx == 1 && log_djid != Guid.Empty)
                        {
                            //立即执行该操作 Modify By Tany 2010-01-29
                            ts.Pexec_log(log_djid, db, out errtext);
                        }
                        if (errtext != "")
                        {
                            throw new Exception(errtext);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return Convert.ToInt32(obj);
                }
                catch (Exception err)
                {
                    db.RollbackTransaction();
                    throw err;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        /// <summary>
        /// 添加系统顶级菜单,,返回0则表示没有添加成功
        /// </summary>
        /// <param name="systemId">系统编号</param>
        /// <param name="menuName">顶级菜单名称</param>
        /// <param name="Invalid"></param>
        /// <param name="menuId"></param>
        /// <returns>新增加的菜单编号,返回0则表示没有添加成功</returns>
        private int AddSystemTopMenu(int systemId, int parentMenuId, int menuId, string menuName, bool Invalid)
        {
            try
            {
                ParameterEx[] paras = new ParameterEx[7];
                #region ...
                paras[0].Text = "@SysMenuId";
                paras[0].ParaSize = 100;
                paras[0].ParaDirection = ParameterDirection.Output;

                paras[1].Text = "@SystemId";
                paras[1].Value = systemId;

                paras[2].Text = "@ParentMenuId";
                paras[2].Value = parentMenuId;

                paras[3].Text = "@MenuId";
                paras[3].Value = menuId;

                paras[4].Text = "@MenuName";
                paras[4].Value = menuName.Trim();

                paras[5].Text = "@Invalid";
                if (Invalid)
                    paras[5].Value = 1;
                else
                    paras[5].Value = 0;

                paras[6].Text = "@Errmsg";
                paras[6].ParaSize = 200;
                paras[6].ParaDirection = ParameterDirection.Output;
                #endregion
                IDbCommand cmd = db.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "up_AddTopMenuToSystem";
                db.SetParameters(cmd, paras);
                object obj;

                try
                {
                    //定义多院操作日志 Modify By Tany 2010-01-29
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    Guid log_djid = Guid.Empty;

                    db.BeginTransaction();
                    db.InsertRecord(cmd, out obj);
                    if (((IDataParameter)cmd.Parameters[6]).Value.ToString().Trim() != "")
                    {
                        db.RollbackTransaction();
                        MessageBox.Show(((IDataParameter)cmd.Parameters[6]).Value.ToString().Trim(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                    
                    //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                    string cznr = "修改系统菜单:【system_id=" + systemId.ToString().Trim() + "】";
                    ts.Save_log(ts_HospData_Share.czlx.jc_系统菜单修改, cznr, "pub_system_menu", "system_id", systemId.ToString(), jgbm, -999, "", out log_djid, db);
                    db.CommitTransaction();

                    try
                    {
                        //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                        string errtext = "";
                        ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_系统菜单修改, db);
                        if (ty.Bzx == 1 && log_djid != Guid.Empty)
                        {
                            //立即执行该操作 Modify By Tany 2010-01-29
                            ts.Pexec_log(log_djid, db, out errtext);
                        }
                        if (errtext != "")
                        {
                            throw new Exception(errtext);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return Convert.ToInt32(obj);
                }
                catch (Exception err)
                {
                    db.RollbackTransaction();
                    throw err;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        /// <summary>
        /// 移除系统菜单中的某个菜单
        /// </summary>
        /// <param name="SystemMenuId"></param>
        /// <returns></returns>
        private bool RemmoveSystemMenu(int SystemMenuId)
        {
            try
            {
                ParameterEx[] paras = new ParameterEx[2];
                #region ...
                paras[0].Text = "@SystemMenuId";
                paras[0].Value = SystemMenuId;
                paras[1].Text = "@Errmsg";
                paras[1].ParaSize = 200;
                paras[1].ParaDirection = ParameterDirection.Output;
                #endregion

                IDbCommand cmd = db.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "up_RemoveSystemMenu";
                db.SetParameters(cmd, paras);

                try
                {
                    //定义多院操作日志 Modify By Tany 2010-01-30
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    Guid log_djid = Guid.Empty;

                    db.BeginTransaction();
                    db.DoCommand(cmd);
                    if (((IDataParameter)cmd.Parameters[1]).Value.ToString().Trim() != "")
                    {
                        throw new Exception(((IDataParameter)cmd.Parameters[1]).Value.ToString().Trim());
                    }

                    //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-30
                    string cznr = "移除系统菜单:【从系统 "+ lvwSystem.SelectedItems[0].SubItems[1].Text.Trim() +" 中移除菜单 " + tvwMenu.SelectedNode.Text.Trim() + "】";
                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, cznr, "pub_system_menu", "Sys_Menu_Id", SystemMenuId.ToString(), jgbm, -999, "", out log_djid, db);
                    
                    db.CommitTransaction();

                    try
                    {
                        //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-30
                        string errtext = "";
                        ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, db);
                        if (ty.Bzx == 1 && log_djid != Guid.Empty)
                        {
                            //立即执行该操作 Modify By Tany 2010-01-29
                            ts.Pexec_log(log_djid, db, out errtext);
                        }
                        if (errtext != "")
                        {
                            throw new Exception(errtext);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return true;
                }
                catch (Exception err)
                {
                    db.RollbackTransaction();
                    throw err;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void tblMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Tag.ToString().ToUpper())
            {
                case "LOAD_DLL":
                    LoadDll();
                    break;
                case "ADD_SYSTEM":
                    DlgInputBox dlg = new DlgInputBox("", "请输入新的系统名称", "添加系统");
                    dlg.ShowDialog();
                    if (DlgInputBox.DlgResult)
                    {
                        string sysName = DlgInputBox.DlgValue;
                        if (sysName.Trim() != "")
                        {
                            int newSysId = EditSystem(false, 0, sysName, 0, 0);
                            if (newSysId > 0)
                            {
                                ListViewItem item = new ListViewItem();
                                item.Tag = newSysId.ToString();
                                item.Text = Convert.ToString(lvwSystem.Items.Count + 1);
                                item.SubItems.Add(sysName);
                                lvwSystem.Items.Add(item);
                            }
                        }
                    }
                    break;
                case "DEL_SYSTEM":
                    if (MessageBox.Show("确定要删除该系统吗？", "TS-HIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (this.lvwSystem.SelectedItems.Count != 0)
                        {
                            for (int i = 0; i < this.lvwSystem.SelectedItems.Count; i++)
                            {
                                int systemId = Convert.ToInt32(lvwSystem.SelectedItems[i].Tag);
                                try
                                {
                                    //定义多院操作日志 Modify By Tany 2010-01-29
                                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                                    Guid log_djid = Guid.Empty;

                                    db.BeginTransaction();
                                    db.DoCommand("update pub_system set delete_bit=1 where system_id=" + systemId);

                                    //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                                    string cznr = "删除系统:【" + lvwSystem.SelectedItems[i].Text.Trim() + "】";
                                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, cznr, "pub_system", "system_id", systemId.ToString(), jgbm, -999, "", out log_djid, db);
                                    db.CommitTransaction();

                                    try
                                    {
                                        //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                                        string errtext = "";
                                        ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, db);
                                        if (ty.Bzx == 1 && log_djid != Guid.Empty)
                                        {
                                            //立即执行该操作 Modify By Tany 2010-01-29
                                            ts.Pexec_log(log_djid, db, out errtext);
                                        }
                                        if (errtext != "")
                                        {
                                            throw new Exception(errtext);
                                        }
                                    }
                                    catch (Exception err)
                                    {
                                        MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch
                                {
                                    db.RollbackTransaction();
                                }
                            }
                            this.LoadSystem();
                            this.tvwMenu.Nodes.Clear();
                        }
                    }
                    break;
                case "CLOSE":
                    this.Close();
                    break;
                case "ADD_TO_TABLE":
                    AddMenu();
                    break;
                case "REMOVE_FROM_TABLE":
                    DeleteMenu();
                    break;
                case "EDIT_MENU":
                    EditMenu();
                    break;
            }

        }

        private void lvwSystem_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lvwSystem.SelectedItems.Count == 0) return;

            DisplaySystemMenuStruct(Convert.ToInt32(lvwSystem.SelectedItems[0].Tag));
        }

        private void AddMenu()
        {
            #region 添加菜单
            if (lvwDllFile.SelectedItems.Count == 0)
            {
                MessageBox.Show("请在动态库中至少选择一项", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                //判断是否已经添加到当前菜单库中
                #region ...
                for (int i = 0; i < lvwDllFile.SelectedItems.Count; i++)
                {
                    string menuName = lvwDllFile.SelectedItems[i].Text;
                    string funName = lvwDllFile.SelectedItems[i].SubItems[1].Text.ToString().Trim();
                    string dllName = lvwDllFile.SelectedItems[i].SubItems[2].Text.ToString().Trim();

                    string sfilter = "Name = '" + menuName + "' and Dll_Name='" + dllName + "' and Function_Name = '" + funName + "'";
                    DataView dv = (DataView)this.dtgrdMenu.DataSource;
                    DataRow[] drs = dv.Table.Select(sfilter);
                    if (drs.Length > 0)
                    {
                        MessageBox.Show("【" + menuName + "】已经有相同的菜单名称并具有相同的调用函数的菜单存在！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                #endregion

                #region 保存
                try
                {
                    for (int i = 0; i < lvwDllFile.SelectedItems.Count; i++)
                    {
                        string menuName = lvwDllFile.SelectedItems[i].Text;
                        string funName = lvwDllFile.SelectedItems[i].SubItems[1].Text.ToString().Trim();
                        string dllName = lvwDllFile.SelectedItems[i].SubItems[2].Text.ToString().Trim();
                        ParameterEx[] paras = new ParameterEx[5];
                        #region ...
                        paras[0].Text = "@MenuId";
                        paras[0].ParaSize = 100;
                        paras[0].ParaDirection = ParameterDirection.Output;
                        paras[1].Text = "@Name";
                        paras[1].Value = menuName;
                        paras[2].Text = "@DllName";
                        paras[2].Value = dllName;
                        paras[3].Text = "@FunctionName";
                        paras[3].Value = funName;
                        paras[4].Text = "@Errmsg";
                        paras[4].ParaSize = 200;
                        paras[4].ParaDirection = ParameterDirection.Output;
                        #endregion
                        IDbCommand cmd = db.GetCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "up_AddMenuInfo";
                        db.SetParameters(cmd, paras);
                        object objNewId;

                        try
                        {
                            //定义多院操作日志 Modify By Tany 2010-01-29
                            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                            Guid log_djid = Guid.Empty;

                            db.BeginTransaction();

                            db.InsertRecord(cmd, out objNewId);

                            object obj = ((IDataParameter)cmd.Parameters[4]).Value;
                            if (obj.ToString() != "")
                            {
                                db.RollbackTransaction();
                                if (MessageBox.Show(obj.ToString() + "\r\n是否继续？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                    return;
                            }

                            //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                            string cznr = "新增菜单:【" + menuName.Trim() + "】";
                            ts.Save_log(ts_HospData_Share.czlx.jc_菜单修改, cznr, "pub_menu", "menu_Id", objNewId.ToString(), jgbm, -999, "", out log_djid, db);

                            db.CommitTransaction();

                            try
                            {
                                //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                                string errtext = "";
                                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_菜单修改, db);
                                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                                {
                                    //立即执行该操作 Modify By Tany 2010-01-29
                                    ts.Pexec_log(log_djid, db, out errtext);
                                }
                                if (errtext != "")
                                {
                                    throw new Exception(errtext);
                                }
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch
                        {
                            db.RollbackTransaction();
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                finally
                {
                    LoadMenu();
                }
                #endregion
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        private void DeleteMenu()
        {
            #region 删除菜单
            try
            {
                DataView dv = (DataView)this.dtgrdMenu.DataSource;
                if (dv.Count > 0)
                {
                    string menuName = dv[dtgrdMenu.CurrentRowIndex]["name"].ToString();
                    int menuId = Convert.ToInt32(dv[dtgrdMenu.CurrentRowIndex]["menu_id"]);
                    DialogResult dlg = MessageBox.Show("删除菜单【" + menuName.Trim() + "】会导致现有系统内的该菜单都会被移除\r\n确定删除吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        //删除操作
                        ParameterEx[] paras = new ParameterEx[2];
                        #region ...
                        paras[0].Text = "@MenuId";
                        paras[0].Value = menuId;
                        paras[1].Text = "@Errmsg";
                        paras[1].ParaSize = 200;
                        paras[1].ParaDirection = ParameterDirection.Output;
                        #endregion
                        IDbCommand cmd = db.GetCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "up_DeleteMenuInfo";
                        db.SetParameters(cmd, paras);

                        try
                        {
                            //定义多院操作日志 Modify By Tany 2010-01-29
                            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                            Guid log_djid = Guid.Empty;

                            db.BeginTransaction();
                            db.DoCommand(cmd);
                            if (((IDataParameter)cmd.Parameters[1]).Value.ToString() != "")
                            {
                                db.RollbackTransaction();
                                MessageBox.Show(((IDataParameter)cmd.Parameters[1]).Value.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                            string cznr = "删除菜单:【" + menuName.Trim() + "】";
                            ts.Save_log(ts_HospData_Share.czlx.jc_菜单删除, cznr, "pub_menu", "menu_id", menuId.ToString(), jgbm, -999, "", out log_djid, db);

                            db.CommitTransaction();

                            try
                            {
                                //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                                string errtext = "";
                                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_菜单删除, db);
                                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                                {
                                    //立即执行该操作 Modify By Tany 2010-01-29
                                    ts.Pexec_log(log_djid, db, out errtext);
                                }
                                if (errtext != "")
                                {
                                    throw new Exception(errtext);
                                }
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show("发生错误：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            tvwMenu.Nodes.Clear();
                            lvwSystem.SelectedItems.Clear();
                        }
                        catch(Exception err)
                        {
                            db.RollbackTransaction();
                            throw err;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                LoadMenu();
            }
            #endregion
        }

        private void EditMenu()
        {
            //编辑菜单属性
            DataView dv = (DataView)this.dtgrdMenu.DataSource;
            if (dv.Count > 0)
            {
                TrasenMainWindow.Forms.FrmMenuProperty fMenuProperty = new TrasenMainWindow.Forms.FrmMenuProperty(Convert.ToInt32(dv[this.dtgrdMenu.CurrentRowIndex]["menu_id"]), db, jgbm);
                DialogResult dlg = fMenuProperty.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    LoadMenu();
                }
            }
        }

        private void btnAddToSystem_Click(object sender, System.EventArgs e)
        {
            if (((DataView)this.dtgrdMenu.DataSource).Count <= 0)
            {
                MessageBox.Show("请选择一个菜单项", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lvwSystem.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择一个系统！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int systemId = Convert.ToInt32(lvwSystem.SelectedItems[0].Tag);
            int parentMenuId = -1;
            if (tvwMenu.SelectedNode != null)
            {
                parentMenuId = Convert.ToInt32(tvwMenu.SelectedNode.Tag);
            }

            DataView dv = (DataView)this.dtgrdMenu.DataSource;
            if (dv.Count == 0) return;
            for (int i = 0; i < dv.Count; i++)
            {
                if (dtgrdMenu.IsSelected(i))
                {
                    int menuId = Convert.ToInt32(dv[i]["Menu_Id"]);
                    string menuName = Convert.ToString(dv[i]["Name"].ToString().Trim());
                    int newMenuId = 0;

                    if (parentMenuId != -1)
                        newMenuId = AddSystemMenu(systemId, menuId, menuName, parentMenuId);
                    else
                        newMenuId = AddSystemTopMenu(systemId, -1, menuId, menuName, false);

                    if (newMenuId != 0)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = menuName.Trim();
                        node.Tag = newMenuId;
                        tvwMenu.BeginUpdate();
                        if (parentMenuId != -1)
                            tvwMenu.SelectedNode.Nodes.Add(node);
                        else
                            tvwMenu.Nodes.Add(node);
                        tvwMenu.EndUpdate();
                    }
                }
            }

        }

        private void mnuAddTopMenu_Click(object sender, System.EventArgs e)
        {
            if (lvwSystem.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择一个系统！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int systemId = Convert.ToInt32(lvwSystem.SelectedItems[0].Tag);

            DlgInputBox dlgMenuName = new DlgInputBox("", "请输入菜单名称", "增加顶级菜单");
            dlgMenuName.ShowDialog();
            if (DlgInputBox.DlgResult)
            {
                string menuName = DlgInputBox.DlgValue;
                int parentMenuId = 0;
                //Modify By tany 2010-01-30 既然是增加顶级菜单，那么必然不会在某菜单之下
                //if (tvwMenu.SelectedNode != null)
                //{
                //    parentMenuId = Convert.ToInt32(tvwMenu.SelectedNode.Tag);
                //}

                int newMenuId = AddSystemTopMenu(systemId, parentMenuId, 0, menuName, true);
                if (newMenuId != 0)
                {
                    TreeNode node = new TreeNode();
                    node.Text = menuName.Trim();
                    node.Tag = newMenuId;
                    tvwMenu.Nodes.Add(node);
                    tvwMenu.Refresh();
                    LoadMenu();
                }
            }
        }

        private void mnuAddSubmenu_Click(object sender, System.EventArgs e)
        {
            btnAddToSystem_Click(null, null);
        }

        private void mnuRemovemenu_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (tvwMenu.SelectedNode == null) return;
                if (MessageBox.Show("是否移除选中的菜单？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (RemmoveSystemMenu(Convert.ToInt32(tvwMenu.SelectedNode.Tag)))
                    {
                        tvwMenu.Nodes.Remove(tvwMenu.SelectedNode);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dtgrdMenu_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if (dtgrdMenu.CurrentRowIndex == -1) return;
            dtgrdMenu.Select(dtgrdMenu.CurrentRowIndex);
        }

        private void mnuAddSubTopmenu_Click(object sender, System.EventArgs e)
        {
            if (((DataView)this.dtgrdMenu.DataSource).Count <= 0)
            {
                MessageBox.Show("请选择一个菜单项", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lvwSystem.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择一个系统！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int systemId = Convert.ToInt32(lvwSystem.SelectedItems[0].Tag);
            int parentMenuId = -1;

            DataView dv = (DataView)this.dtgrdMenu.DataSource;
            if (dv.Count == 0) return;
            for (int i = 0; i < dv.Count; i++)
            {
                if (dtgrdMenu.IsSelected(i))
                {
                    int menuId = Convert.ToInt32(dv[i]["Menu_Id"]);
                    string menuName = Convert.ToString(dv[i]["Name"].ToString().Trim());
                    int newMenuId = 0;

                    newMenuId = AddSystemTopMenu(systemId, 0, menuId, menuName, false);

                    if (newMenuId != 0)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = menuName.Trim();
                        node.Tag = newMenuId;
                        tvwMenu.BeginUpdate();
                        if (parentMenuId != -1)
                            tvwMenu.SelectedNode.Nodes.Add(node);
                        else
                            tvwMenu.Nodes.Add(node);
                        tvwMenu.EndUpdate();
                    }
                }
            }
        }

        private void menuSortmenu_Click(object sender, System.EventArgs e)
        {
            if (tvwMenu.SelectedNode != null && lvwSystem.SelectedItems.Count > 0)
            {
                int parentMenuid = tvwMenu.SelectedNode.Parent == null ? -1 : Convert.ToInt32(tvwMenu.SelectedNode.Parent.Tag);
                int systemId = Convert.ToInt32(lvwSystem.SelectedItems[0].Tag);
                FrmSortMenus fSortmenu = new FrmSortMenus(systemId, parentMenuid, db, jgbm);
                fSortmenu.ShowInTaskbar = false;
                fSortmenu.ShowDialog();
            }
        }

        private void menuOption_Click(object sender, EventArgs e)
        {

        }

        private void txtFind_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( e.KeyChar != '\r' )
                return;

            string keyWord = txtFind.Text.Trim();
            lvwDllFile.Items.Clear();
            if ( string.IsNullOrEmpty( keyWord ) )
            {
                foreach ( ListViewItem item in lstDllItems )
                    lvwDllFile.Items.Add( item );

            }
            else
            {
                System.Collections.Generic.List<ListViewItem> lstFindItem = new System.Collections.Generic.List<ListViewItem>();
                lstFindItem = lstDllItems.FindAll( delegate( ListViewItem item )
                {
                    int idx1 = item.Text.ToUpper().IndexOf( keyWord.ToUpper() );
                    int idx2 = item.SubItems[1].Text.ToUpper().IndexOf( keyWord.ToUpper() );
                    int idx3 = item.SubItems[2].Text.ToUpper().IndexOf( keyWord.ToUpper() );

                    return ( idx1 != -1 || idx2 != -1 || idx3 != -1 );
                } );

                //循环添加找到的项目
                foreach ( ListViewItem item in lstFindItem )
                    lvwDllFile.Items.Add( item );
            }
        }


    }
}
