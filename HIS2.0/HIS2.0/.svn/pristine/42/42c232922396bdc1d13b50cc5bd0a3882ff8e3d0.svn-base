using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
namespace TrasenFrame.Forms
{
    /// <summary>
    /// 组成员访问系统权限对话框
    /// </summary>
    public class FrmGroupAccess : System.Windows.Forms.Form
    {
        //自定义变量
        private const int ALLACCESSIMAGEINDEX = 17;		//全部权限的图标索引
        private const int PARTACCESSIMAGEINDEX = 17;		//部分权限的图标索引
        private const int NONACCESSIMAGEINDEX = 19;		//无权限的图标索引

        /// <summary>
        /// 本窗体的数据库连接
        /// </summary>
        private RelationalDatabase db;//Add By Tany 2010-01-27
        /// <summary>
        /// 本窗体连接的机构编码
        /// </summary>
        private int jgbm;//Add By Tany 2010-01-27

        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ImageList img;
        private System.Windows.Forms.ToolBarButton btnRefresh;
        private System.Windows.Forms.ToolBarButton btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView lvwGroup;
        private System.Windows.Forms.TreeView tvwAccess;
        private System.Windows.Forms.ListView lvwUser;
        private TrasenClasses.GeneralControls.DataGridEx dtgrdMain;
        private TrasenClasses.GeneralControls.ComboGridSearch cGridSearch;
        private System.Windows.Forms.Button btAddUser;
        private System.Windows.Forms.Button btRemoveUser;
        private System.Windows.Forms.ToolBarButton tlbbtnAddGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btForbidden;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAllow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveAccess;
        private System.Windows.Forms.ContextMenu mnuAddGroup;
        private System.Windows.Forms.MenuItem mnuAddAdminGroup;
        private System.Windows.Forms.MenuItem mnuAddCommonGroup;
        private System.Windows.Forms.ToolBarButton tlbbtnEditGroup;
        private System.Windows.Forms.ToolBarButton tblDelGroup;
        private ColumnHeader columnHeader7;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// 用户组设置
        /// </summary>
        public FrmGroupAccess()
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
            if (FrmMdiMain.ZxJgbm != -1 && FrmMdiMain.ZxJgbm != FrmMdiMain.Jgbm)
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
            CreateGridStyle();
            LoadAllGroup();
            LoadAllUser();
            LoadAllSystemMenuStruct();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmGroupAccess ) );
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tlbbtnAddGroup = new System.Windows.Forms.ToolBarButton();
            this.mnuAddGroup = new System.Windows.Forms.ContextMenu();
            this.mnuAddAdminGroup = new System.Windows.Forms.MenuItem();
            this.mnuAddCommonGroup = new System.Windows.Forms.MenuItem();
            this.tlbbtnEditGroup = new System.Windows.Forms.ToolBarButton();
            this.tblDelGroup = new System.Windows.Forms.ToolBarButton();
            this.btnRefresh = new System.Windows.Forms.ToolBarButton();
            this.btnClose = new System.Windows.Forms.ToolBarButton();
            this.img = new System.Windows.Forms.ImageList( this.components );
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tvwAccess = new System.Windows.Forms.TreeView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveAccess = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btForbidden = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btAllow = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dtgrdMain = new TrasenClasses.GeneralControls.DataGridEx();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cGridSearch = new TrasenClasses.GeneralControls.ComboGridSearch();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btAddUser = new System.Windows.Forms.Button();
            this.btRemoveUser = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lvwUser = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvwGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dtgrdMain ) ).BeginInit();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange( new System.Windows.Forms.ToolBarButton[] {
            this.tlbbtnAddGroup,
            this.tlbbtnEditGroup,
            this.tblDelGroup,
            this.btnRefresh,
            this.btnClose} );
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.img;
            this.toolBar1.Location = new System.Drawing.Point( 0 , 0 );
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size( 1028 , 41 );
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler( this.toolBar1_ButtonClick );
            // 
            // tlbbtnAddGroup
            // 
            this.tlbbtnAddGroup.DropDownMenu = this.mnuAddGroup;
            this.tlbbtnAddGroup.ImageIndex = 0;
            this.tlbbtnAddGroup.Name = "tlbbtnAddGroup";
            this.tlbbtnAddGroup.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tlbbtnAddGroup.Tag = "ADD_GROUP";
            this.tlbbtnAddGroup.Text = "添加组";
            // 
            // mnuAddGroup
            // 
            this.mnuAddGroup.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.mnuAddAdminGroup,
            this.mnuAddCommonGroup} );
            // 
            // mnuAddAdminGroup
            // 
            this.mnuAddAdminGroup.Index = 0;
            this.mnuAddAdminGroup.Text = "管理员组";
            this.mnuAddAdminGroup.Click += new System.EventHandler( this.mnuAddAdminGroup_Click );
            // 
            // mnuAddCommonGroup
            // 
            this.mnuAddCommonGroup.Index = 1;
            this.mnuAddCommonGroup.Text = "普通用户组";
            this.mnuAddCommonGroup.Click += new System.EventHandler( this.mnuAddCommonGroup_Click );
            // 
            // tlbbtnEditGroup
            // 
            this.tlbbtnEditGroup.ImageIndex = 8;
            this.tlbbtnEditGroup.Name = "tlbbtnEditGroup";
            this.tlbbtnEditGroup.Tag = "EDIT_GROUP";
            this.tlbbtnEditGroup.Text = "修改组名";
            // 
            // tblDelGroup
            // 
            this.tblDelGroup.ImageIndex = 9;
            this.tblDelGroup.Name = "tblDelGroup";
            this.tblDelGroup.Tag = "DELETEGROUP";
            this.tblDelGroup.Text = "删除组";
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageIndex = 2;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Tag = "REFRESH";
            this.btnRefresh.Text = "刷新";
            // 
            // btnClose
            // 
            this.btnClose.ImageIndex = 5;
            this.btnClose.Name = "btnClose";
            this.btnClose.Tag = "CLOSE";
            this.btnClose.Text = "关闭";
            // 
            // img
            // 
            this.img.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "img.ImageStream" ) ) );
            this.img.TransparentColor = System.Drawing.Color.Transparent;
            this.img.Images.SetKeyName( 0 , "" );
            this.img.Images.SetKeyName( 1 , "" );
            this.img.Images.SetKeyName( 2 , "" );
            this.img.Images.SetKeyName( 3 , "" );
            this.img.Images.SetKeyName( 4 , "" );
            this.img.Images.SetKeyName( 5 , "" );
            this.img.Images.SetKeyName( 6 , "" );
            this.img.Images.SetKeyName( 7 , "" );
            this.img.Images.SetKeyName( 8 , "" );
            this.img.Images.SetKeyName( 9 , "" );
            this.img.Images.SetKeyName( 10 , "" );
            this.img.Images.SetKeyName( 11 , "" );
            this.img.Images.SetKeyName( 12 , "" );
            this.img.Images.SetKeyName( 13 , "" );
            this.img.Images.SetKeyName( 14 , "" );
            this.img.Images.SetKeyName( 15 , "" );
            this.img.Images.SetKeyName( 16 , "" );
            this.img.Images.SetKeyName( 17 , "" );
            this.img.Images.SetKeyName( 18 , "" );
            this.img.Images.SetKeyName( 19 , "" );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.panel10 );
            this.panel1.Controls.Add( this.panel9 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point( 756 , 41 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 272 , 630 );
            this.panel1.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add( this.tvwAccess );
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point( 0 , 34 );
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size( 272 , 596 );
            this.panel10.TabIndex = 1;
            // 
            // tvwAccess
            // 
            this.tvwAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwAccess.Font = new System.Drawing.Font( "宋体" , 12F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.tvwAccess.HideSelection = false;
            this.tvwAccess.ImageIndex = 0;
            this.tvwAccess.ImageList = this.img;
            this.tvwAccess.Location = new System.Drawing.Point( 0 , 0 );
            this.tvwAccess.Name = "tvwAccess";
            this.tvwAccess.SelectedImageIndex = 0;
            this.tvwAccess.Size = new System.Drawing.Size( 272 , 596 );
            this.tvwAccess.TabIndex = 0;
            this.tvwAccess.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.tvwAccess_AfterSelect );
            // 
            // panel9
            // 
            this.panel9.Controls.Add( this.label4 );
            this.panel9.Controls.Add( this.btnSaveAccess );
            this.panel9.Controls.Add( this.label3 );
            this.panel9.Controls.Add( this.btForbidden );
            this.panel9.Controls.Add( this.label2 );
            this.panel9.Controls.Add( this.btAllow );
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point( 0 , 0 );
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size( 272 , 34 );
            this.panel9.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 224 , 10 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 29 , 12 );
            this.label4.TabIndex = 29;
            this.label4.Text = "保存";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveAccess
            // 
            this.btnSaveAccess.ImageIndex = 1;
            this.btnSaveAccess.ImageList = this.img;
            this.btnSaveAccess.Location = new System.Drawing.Point( 184 , 3 );
            this.btnSaveAccess.Name = "btnSaveAccess";
            this.btnSaveAccess.Size = new System.Drawing.Size( 34 , 28 );
            this.btnSaveAccess.TabIndex = 28;
            this.btnSaveAccess.Click += new System.EventHandler( this.btnSaveAccess_Click );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 132 , 9 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 29 , 12 );
            this.label3.TabIndex = 27;
            this.label3.Text = "禁止";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btForbidden
            // 
            this.btForbidden.ImageIndex = 19;
            this.btForbidden.ImageList = this.img;
            this.btForbidden.Location = new System.Drawing.Point( 92 , 3 );
            this.btForbidden.Name = "btForbidden";
            this.btForbidden.Size = new System.Drawing.Size( 34 , 28 );
            this.btForbidden.TabIndex = 26;
            this.btForbidden.Click += new System.EventHandler( this.btForbidden_Click );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 46 , 9 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 29 , 12 );
            this.label2.TabIndex = 25;
            this.label2.Text = "允许";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btAllow
            // 
            this.btAllow.ImageIndex = 17;
            this.btAllow.ImageList = this.img;
            this.btAllow.Location = new System.Drawing.Point( 6 , 3 );
            this.btAllow.Name = "btAllow";
            this.btAllow.Size = new System.Drawing.Size( 34 , 28 );
            this.btAllow.TabIndex = 24;
            this.btAllow.Click += new System.EventHandler( this.btAllow_Click );
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point( 752 , 41 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 4 , 630 );
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.panel7 );
            this.panel2.Controls.Add( this.panel6 );
            this.panel2.Controls.Add( this.splitter2 );
            this.panel2.Controls.Add( this.panel5 );
            this.panel2.Controls.Add( this.panel4 );
            this.panel2.Controls.Add( this.panel3 );
            this.panel2.Controls.Add( this.label1 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0 , 41 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 752 , 630 );
            this.panel2.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add( this.dtgrdMain );
            this.panel7.Controls.Add( this.panel8 );
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point( 352 , 272 );
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size( 400 , 358 );
            this.panel7.TabIndex = 6;
            // 
            // dtgrdMain
            // 
            this.dtgrdMain.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgrdMain.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dtgrdMain.CaptionVisible = false;
            this.dtgrdMain.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dtgrdMain.DataMember = "";
            this.dtgrdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdMain.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgrdMain.Location = new System.Drawing.Point( 0 , 34 );
            this.dtgrdMain.Name = "dtgrdMain";
            this.dtgrdMain.ReadOnly = true;
            this.dtgrdMain.Size = new System.Drawing.Size( 400 , 324 );
            this.dtgrdMain.TabIndex = 27;
            // 
            // panel8
            // 
            this.panel8.Controls.Add( this.cGridSearch );
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point( 0 , 0 );
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size( 400 , 34 );
            this.panel8.TabIndex = 0;
            // 
            // cGridSearch
            // 
            this.cGridSearch.BackColor = System.Drawing.SystemColors.Control;
            this.cGridSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.cGridSearch.Location = new System.Drawing.Point( 0 , 0 );
            this.cGridSearch.MappingDataGrid = this.dtgrdMain;
            this.cGridSearch.Name = "cGridSearch";
            this.cGridSearch.Size = new System.Drawing.Size( 400 , 30 );
            this.cGridSearch.TabIndex = 26;
            this.cGridSearch.TableStyleIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add( this.btAddUser );
            this.panel6.Controls.Add( this.btRemoveUser );
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point( 291 , 272 );
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size( 61 , 358 );
            this.panel6.TabIndex = 5;
            // 
            // btAddUser
            // 
            this.btAddUser.Image = ( (System.Drawing.Image)( resources.GetObject( "btAddUser.Image" ) ) );
            this.btAddUser.Location = new System.Drawing.Point( 14 , 66 );
            this.btAddUser.Name = "btAddUser";
            this.btAddUser.Size = new System.Drawing.Size( 28 , 24 );
            this.btAddUser.TabIndex = 9;
            this.btAddUser.Click += new System.EventHandler( this.btAddUser_Click );
            // 
            // btRemoveUser
            // 
            this.btRemoveUser.Image = ( (System.Drawing.Image)( resources.GetObject( "btRemoveUser.Image" ) ) );
            this.btRemoveUser.Location = new System.Drawing.Point( 14 , 130 );
            this.btRemoveUser.Name = "btRemoveUser";
            this.btRemoveUser.Size = new System.Drawing.Size( 29 , 24 );
            this.btRemoveUser.TabIndex = 8;
            this.btRemoveUser.Click += new System.EventHandler( this.btRemoveUser_Click );
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point( 288 , 272 );
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size( 3 , 358 );
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add( this.lvwUser );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point( 0 , 272 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 288 , 358 );
            this.panel5.TabIndex = 3;
            // 
            // lvwUser
            // 
            this.lvwUser.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6} );
            this.lvwUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwUser.FullRowSelect = true;
            this.lvwUser.Location = new System.Drawing.Point( 0 , 0 );
            this.lvwUser.Name = "lvwUser";
            this.lvwUser.Size = new System.Drawing.Size( 288 , 358 );
            this.lvwUser.TabIndex = 0;
            this.lvwUser.UseCompatibleStateImageBehavior = false;
            this.lvwUser.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "登录名";
            this.columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "姓名";
            this.columnHeader5.Width = 105;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "状态";
            this.columnHeader6.Width = 45;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point( 0 , 250 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 752 , 22 );
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.lvwGroup );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point( 0 , 34 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 752 , 216 );
            this.panel3.TabIndex = 1;
            // 
            // lvwGroup
            // 
            this.lvwGroup.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader7} );
            this.lvwGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwGroup.FullRowSelect = true;
            this.lvwGroup.HideSelection = false;
            this.lvwGroup.Location = new System.Drawing.Point( 0 , 0 );
            this.lvwGroup.Name = "lvwGroup";
            this.lvwGroup.Size = new System.Drawing.Size( 752 , 216 );
            this.lvwGroup.TabIndex = 0;
            this.lvwGroup.UseCompatibleStateImageBehavior = false;
            this.lvwGroup.View = System.Windows.Forms.View.Details;
            this.lvwGroup.SelectedIndexChanged += new System.EventHandler( this.lvwGroup_SelectedIndexChanged );
            this.lvwGroup.DoubleClick += new System.EventHandler( this.lvwGroup_DoubleClick );
            this.lvwGroup.Click += new System.EventHandler( this.lvwGroup_Click );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "用户组名称";
            this.columnHeader1.Width = 191;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "备注";
            this.columnHeader3.Width = 203;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "";
            this.columnHeader7.Width = 103;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font( "楷体_GB2312" , 14.25F , ( (System.Drawing.FontStyle)( ( System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic ) ) ) , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point( 0 , 0 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 752 , 34 );
            this.label1.TabIndex = 0;
            this.label1.Text = "用户组列表";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmGroupAccess
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 6 , 14 );
            this.ClientSize = new System.Drawing.Size( 1028 , 671 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.splitter1 );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.toolBar1 );
            this.Name = "FrmGroupAccess";
            this.Text = "系统用户组设置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout( false );
            this.panel10.ResumeLayout( false );
            this.panel9.ResumeLayout( false );
            this.panel9.PerformLayout();
            this.panel2.ResumeLayout( false );
            this.panel7.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.dtgrdMain ) ).EndInit();
            this.panel8.ResumeLayout( false );
            this.panel6.ResumeLayout( false );
            this.panel5.ResumeLayout( false );
            this.panel3.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout();

        }
        #endregion


        /// <summary>
        /// 创建网格格式
        /// </summary>
        private void CreateGridStyle()
        {
            string[] head ={ "登录名称", "姓名", "拼音码", "五笔码", "数字码", "", "" };
            string[] colname ={ "Code", "Name", "Py_Code", "Wb_Code", "D_Code", "User_Id", "Employee_Id" };
            int[] colwidth ={ 80, 80, 70, 70, 70, 0, 0 };
            dtgrdMain.CreateTableStyle(head, colname, colwidth, 20);
        }
        /// <summary>
        /// 加载所有用户组
        /// </summary>
        private void LoadAllGroup()
        {
            //comment by wangzhi 2010-10-20
            //string[] msgGroup = null;
            //try
            //{
            //    TrasenFrame.Classes.SystemCfg cfg = new TrasenFrame.Classes.SystemCfg(0006, db);
            //    if (cfg.Config != "")
            //    {
            //        msgGroup = cfg.Config.Split(",".ToCharArray());
            //    }
            //}
            //catch
            //{
            //}
            //end comment
            try
            {
                IDbCommand cmd = db.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "up_GetUserGroupList";
                DataTable tb = db.GetDataTable(cmd);
                lvwGroup.Items.Clear();
                lvwUser.Tag = null;
                if (tb != null && tb.Rows.Count > 0)
                {
                    ListViewItem lvwItem = null;
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        lvwItem = new ListViewItem(Convertor.IsNull(tb.Rows[i]["name"], ""));
                        lvwItem.SubItems.Add(Convertor.IsNull(tb.Rows[i]["remarks"], ""));
                        lvwItem.Tag = Convertor.IsNull(tb.Rows[i]["id"], "-1");
                        if (Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["administrator_bit"], "0")) > 0)
                        {
                            lvwItem.ForeColor = Color.Blue;
                        }
                        lvwItem.SubItems.Add("");
                        //comment by wangzhi 2010-10-20
                        //if (msgGroup != null)
                        //{
                        //    for (int m = 0; m < msgGroup.Length; m++)
                        //    {
                        //        if (tb.Rows[i]["id"].ToString() == msgGroup[m])
                        //        {
                        //            lvwItem.SubItems[2].Text = "*";
                        //        }
                        //    }
                        //}
                        //end comment

                        lvwItem.ImageIndex = 15;
                        lvwGroup.Items.Add(lvwItem);
                    }
                    lvwGroup.Items[0].Selected = true;
                }
                if (tb != null)
                {
                    tb.Dispose();
                }
                tb = null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
        }
        /// <summary>
        /// 加载所有用户
        /// </summary>
        private void LoadAllUser()
        {
            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "up_GetAllUserWithEmployeeInfo";
            DataTable tb = db.GetDataTable(cmd);
            DataView dv = tb.DefaultView;
            dtgrdMain.DataSource = tb.DefaultView;
            tb.Dispose();
            tb = null;
            PubStaticFun.ModifyDataGridStyle(dtgrdMain, 0);
        }

        /// <summary>
        /// 根据组ID显示其成员
        /// </summary>
        /// <param name="groupID"></param>
        private void ViewGroupMember(int groupID)
        {
            try
            {
                ParameterEx[] paras = new ParameterEx[1];
                paras[0].Text = "@GroupID";
                paras[0].Value = groupID;

                IDbCommand cmd = db.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "up_GetGroupUserList";
                db.SetParameters(cmd, paras);
                DataTable tb = db.GetDataTable(cmd);

                lvwUser.Tag = groupID;
                lvwUser.Items.Clear();
                if (tb != null && tb.Rows.Count > 0)
                {
                    ListViewItem lvwItem = null;
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        lvwItem = new ListViewItem(Convertor.IsNull(tb.Rows[i]["code"], ""));
                        lvwItem.SubItems.Add(Convertor.IsNull(tb.Rows[i]["name"], ""));
                        lvwItem.Tag = Convertor.IsNull(tb.Rows[i]["user_id"], "-1");
                        if (Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["locked_bit"], "0")) > 0)
                        {
                            lvwItem.ForeColor = Color.Red;
                            lvwItem.SubItems.Add("锁定");
                        }
                        else
                        {
                            lvwItem.SubItems.Add("正常");
                        }
                        lvwItem.ImageIndex = 16;
                        lvwUser.Items.Add(lvwItem);
                    }
                }
                if (tb != null)
                {
                    tb.Dispose();
                }
                tb = null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
        }
        /// <summary>
        /// 加载所有系统的菜单结构
        /// </summary>
        private void LoadAllSystemMenuStruct()
        {
            DataTable tbSystem = FrmMdiMain.LoadSystemList(db);
            this.tvwAccess.Nodes.Clear();
            if (tbSystem != null && tbSystem.Rows.Count > 0)
            {
                for (int iCountSys = 0; iCountSys < tbSystem.Rows.Count; iCountSys++)
                {
                    int systemId = Convert.ToInt32(tbSystem.Rows[iCountSys]["system_id"]);
                    string sysName = tbSystem.Rows[iCountSys]["Name"].ToString();

                    TreeNode ndSys = new TreeNode();
                    ndSys.Text = sysName.Trim();
                    ndSys.Tag = systemId;
                    ndSys.ImageIndex = NONACCESSIMAGEINDEX;
                    ndSys.SelectedImageIndex = NONACCESSIMAGEINDEX;
                    //获取当前系统的菜单
                    DataTable tbSystemMenu = FrmMdiMain.LoadSystemMenuList(systemId, db);
                    //找出顶级菜单
                    DataRow[] drsTopMenu = tbSystemMenu.Select("Parent_Id = -1", "sort_id");
                    for (int topIndex = 0; topIndex < drsTopMenu.Length; topIndex++)
                    {
                        TreeNode ndTopMenu = new TreeNode();
                        ndTopMenu.Text = drsTopMenu[topIndex]["name"].ToString().Trim();
                        ndTopMenu.Tag = Convert.ToInt32(drsTopMenu[topIndex]["menu_id"]);
                        ndTopMenu.ImageIndex = NONACCESSIMAGEINDEX;
                        ndTopMenu.SelectedImageIndex = NONACCESSIMAGEINDEX;

                        AddSubMenu(tbSystemMenu, ndTopMenu, Convert.ToInt32(drsTopMenu[topIndex]["menu_id"]));
                        ndSys.Nodes.Add(ndTopMenu);
                    }

                    tvwAccess.Nodes.Add(ndSys);
                }

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
                    node.ImageIndex = NONACCESSIMAGEINDEX;
                    node.SelectedImageIndex = NONACCESSIMAGEINDEX;
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
        /// 显示组可访问的菜单
        /// </summary>
        /// <param name="groupId"></param>
        private void DisplayGroupAccessMenu(int groupId)
        {
            //获取组所有菜单
            ParameterEx[] paras = new ParameterEx[1];
            paras[0].Text = "@GroupId";
            paras[0].Value = groupId;

            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "up_GetGroupMenuList";
            db.SetParameters(cmd, paras);
            DataTable tableGroupMenu = db.GetDataTable(cmd);

            foreach (TreeNode topNode in tvwAccess.Nodes)
            {
                topNode.ImageIndex = NONACCESSIMAGEINDEX;
                topNode.SelectedImageIndex = NONACCESSIMAGEINDEX;

                int systemId = Convert.ToInt32(topNode.Tag);
                DataRow[] drs = tableGroupMenu.Select("system_id = " + systemId.ToString());

                if (drs.Length == 0)
                {
                    //如果没有该系统，则不用检查子节点
                    topNode.ImageIndex = NONACCESSIMAGEINDEX;
                    topNode.SelectedImageIndex = NONACCESSIMAGEINDEX;
                    SetNodeCheckStatus(topNode, false);
                }
                else
                {
                    this.tvwAccess.BeginUpdate();
                    this.tvwAccess.CollapseAll();
                    topNode.ImageIndex = ALLACCESSIMAGEINDEX;
                    topNode.SelectedImageIndex = ALLACCESSIMAGEINDEX;
                    topNode.ExpandAll();
                    CheckSubNode(topNode, tableGroupMenu);
                    this.tvwAccess.EndUpdate();
                }
            }
        }
        /// <summary>
        /// 检查子节点菜单是否有权限
        /// </summary>
        /// <param name="topNode"></param>
        /// <param name="tableGroupMenu"></param>
        private void CheckSubNode(TreeNode topNode, DataTable tableGroupMenu)
        {
            foreach (TreeNode node in topNode.Nodes)
            {
                node.ImageIndex = NONACCESSIMAGEINDEX;
                node.SelectedImageIndex = NONACCESSIMAGEINDEX;

                int sysmenuId = Convert.ToInt32(node.Tag);
                DataRow[] drs = tableGroupMenu.Select("sys_menu_id = " + sysmenuId.ToString());
                if (drs.Length > 0)
                {
                    node.ImageIndex = ALLACCESSIMAGEINDEX;
                    node.SelectedImageIndex = ALLACCESSIMAGEINDEX;
                    node.ExpandAll();
                    CheckSubNode(node, tableGroupMenu);
                }
            }
        }
        /// <summary>
        /// 设置节点及其子节点的选中状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="Checked"></param>
        private void SetNodeCheckStatus(TreeNode node, bool Checked)
        {
            node.ImageIndex = NONACCESSIMAGEINDEX;
            node.SelectedImageIndex = NONACCESSIMAGEINDEX;

            if (Checked)
            {
                node.ImageIndex = ALLACCESSIMAGEINDEX;
                node.SelectedImageIndex = ALLACCESSIMAGEINDEX;
            }
            else
            {
                node.ImageIndex = NONACCESSIMAGEINDEX;
                node.SelectedImageIndex = NONACCESSIMAGEINDEX;
            }
            foreach (TreeNode subNode in node.Nodes)
            {
                subNode.ImageIndex = node.ImageIndex;
                subNode.SelectedImageIndex = node.SelectedImageIndex;
                SetNodeCheckStatus(subNode, Checked);
            }
        }
        /// <summary>
        /// 设置节点的父级节点的选中状态
        /// </summary>
        /// <param name="node">选定节点</param>
        private void SetParentNodeStatus(TreeNode node)
        {

            if (node.Parent != null)
            {
                int flag = 0;
                for (int i = 0; i < node.Parent.Nodes.Count; i++)
                {
                    if (node.Parent.Nodes[i].ImageIndex == ALLACCESSIMAGEINDEX)		//有权限
                    {
                        flag = flag | 1;
                    }
                    else if (node.Parent.Nodes[i].ImageIndex == NONACCESSIMAGEINDEX)	//无权限
                    {
                        flag = flag | 2;
                    }
                    else															//部分权限
                    {
                        flag = flag | 4;
                    }
                }
                switch (flag)
                {
                    case 1:
                        node.Parent.ImageIndex = ALLACCESSIMAGEINDEX;
                        node.Parent.SelectedImageIndex = ALLACCESSIMAGEINDEX;
                        break;
                    case 2:
                        node.Parent.ImageIndex = NONACCESSIMAGEINDEX;
                        node.Parent.SelectedImageIndex = NONACCESSIMAGEINDEX;
                        break;
                    default:
                        node.Parent.ImageIndex = PARTACCESSIMAGEINDEX;
                        node.Parent.SelectedImageIndex = PARTACCESSIMAGEINDEX;
                        break;
                }
                SetParentNodeStatus(node.Parent);
            }
        }

        /// <summary>
        /// 保存组权限
        /// </summary>
        private void SaveGroupAccess()
        {
            try
            {
                //定义多院操作日志 Modify By Tany 2010-01-29
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                Guid log_djid = Guid.Empty;

                db.BeginTransaction();
                int groupID = Convert.ToInt32(lvwGroup.SelectedItems[0].Tag);
                string sql = "delete from pub_group_menu where group_id=" + groupID;
                db.DoCommand(sql);
                foreach (TreeNode ndSystem in tvwAccess.Nodes)
                {
                    RecursionSave(ndSystem.Nodes, groupID);
                }

                //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                string cznr = "修改用户组信息:【" + lvwGroup.SelectedItems[0].Text.Trim() + "】";
                ts.Save_log(ts_HospData_Share.czlx.jc_组菜单修改, cznr, "pub_group_menu", "group_id", groupID.ToString(), jgbm, -999, "", out log_djid, db);

                db.CommitTransaction();

                try
                {
                    //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_组菜单修改, db);
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

                MessageBox.Show("保存权限成功！", "提示");
            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                MessageBox.Show("保存权限失败：\n" + err.Message, "错误");
            }
        }
        /// <summary>
        /// 用递归的方法遍历权限树保存组权限
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="groupID"></param>
        private void RecursionSave(TreeNodeCollection nodes, int groupID)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                int sysMenuId = Convert.ToInt32(nodes[i].Tag);
                if ((nodes[i].ImageIndex != NONACCESSIMAGEINDEX) || (nodes[i].ImageIndex == ALLACCESSIMAGEINDEX))	//3、4代表子、明细功能
                {
                    string sql = @"insert into pub_group_menu(group_id,system_menu_id) values (" + groupID + "," + sysMenuId + ")";
                    db.DoCommand(sql);
                }
                if (nodes[i].Nodes.Count > 0)
                {
                    RecursionSave(nodes[i].Nodes, groupID);
                }
            }
        }

        /// <summary>
        /// 添加新组
        /// </summary>
        /// <param name="AdminFlag">管理员组标志:1-管理员，0-普通组</param>
        private void AddGroup(int AdminFlag)
        {
            try
            {
                string text = "请输入用户组名称";
                string caption = "添加普通组";
                if (AdminFlag == 1)
                {
                    text = "请输入管理员组名称";
                    caption = "添加管理员组";
                }
                DlgInputBox dlg = new DlgInputBox("", text, caption);
                dlg.ShowDialog();
                if (DlgInputBox.DlgResult)
                {
                    string groupName = DlgInputBox.DlgValue;
                    if (groupName.Trim() != "")
                    {
                        ParameterEx[] paras = new ParameterEx[4];
                        #region ...
                        paras[0].Text = "@GroupId";
                        paras[0].ParaSize = 10;
                        paras[0].ParaDirection = ParameterDirection.InputOutput;
                        paras[0].Value = 0;

                        paras[1].Text = "@Name";
                        paras[1].Value = groupName.Trim();

                        paras[2].Text = "@Admin";
                        paras[2].Value = AdminFlag;

                        paras[3].Text = "@Errmsg";
                        paras[3].ParaSize = 100;
                        paras[3].ParaDirection = ParameterDirection.Output;
                        #endregion
                        IDbCommand cmd = db.GetCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "up_AddGroupInfo";
                        db.SetParameters(cmd, paras);
                        object obj;
                        
                        try
                        {
                            //定义多院操作日志 Modify By Tany 2010-01-29
                            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                            Guid log_djid = Guid.Empty;

                            db.BeginTransaction();

                            db.InsertRecord(cmd, out obj);

                            if (((IDataParameter)cmd.Parameters[3]).Value.ToString().Trim() != "")
                            {
                                db.RollbackTransaction();
                                MessageBox.Show(((IDataParameter)cmd.Parameters[3]).Value.ToString().Trim(), "错误",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                            string cznr = "增加用户组:【" + groupName.Trim() + "】";
                            ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, cznr, "pub_group", "id", Convert.ToInt32(obj).ToString(), jgbm, -999, "", out log_djid, db);

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
                        catch(Exception err)
                        {
                            db.RollbackTransaction();
                            throw err;
                        }

                        ListViewItem item = new ListViewItem();
                        item.Text = groupName;
                        item.Tag = Convert.ToInt32(obj);
                        this.lvwGroup.Items.Add(item);
                        this.lvwGroup.SelectedItems.Clear();
                        item.Selected = true;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /********************************以下为窗体控件响应事件****************************************************/

        private void btRemoveUser_Click(object sender, System.EventArgs e)
        {
            if (lvwUser.Tag == null)
            {
                MessageBox.Show("请选择用户组！", "提示");
                return;
            }
            if (lvwUser.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要删除的用户！", "提示");
                return;
            }
            if (MessageBox.Show("是否确定将该用户从该组删除？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int groupId = Convert.ToInt32(lvwGroup.SelectedItems[0].Tag);
                int userId = Convert.ToInt32(lvwUser.SelectedItems[0].Tag);
                ParameterEx[] paras = new ParameterEx[2];
                #region ...
                paras[0].Text = "@UserId";
                paras[0].Value = userId;
                paras[1].Text = "@GroupId";
                paras[1].Value = groupId;
                #endregion
                IDbCommand cmd = db.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "up_DeleteUserFormGroup";
                db.SetParameters(cmd, paras);

                try
                {
                    //定义多院操作日志 Modify By Tany 2010-01-29
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    Guid log_djid = Guid.Empty;

                    db.BeginTransaction();

                    db.DoCommand(cmd);

                    //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                    string cznr = "删除组用户信息:【从组 " + lvwGroup.SelectedItems[0].Text.Trim() + " 删除用户 " + lvwUser.SelectedItems[0].Text.Trim() + "】";
                    ts.Save_log(ts_HospData_Share.czlx.jc_用户修改, cznr, "pub_user", "id", userId.ToString(), jgbm, -999, "", out log_djid, db);

                    db.CommitTransaction();

                    try
                    {
                        //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                        string errtext = "";
                        ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_用户修改, db);
                        if (ty.Bzx == 1 && log_djid != Guid.Empty)
                        {
                            //立即执行该操作 Modify By Tany 2010-01-25
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

                    ViewGroupMember(Convert.ToInt32(lvwUser.Tag));
                }
                catch (Exception err)
                {
                    db.RollbackTransaction();
                    MessageBox.Show(err.Message);
                }
            }
        }
        private void btAddUser_Click(object sender, System.EventArgs e)
        {
            if (lvwGroup.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择用户组！", "提示");
                dtgrdMain.SelectCurrentRow();
                return;
            }
            DataView dv = (DataView)dtgrdMain.DataSource;
            if (dv.Count > 0)
            {
                int userId = Convert.IsDBNull(dv[dtgrdMain.CurrentRowIndex]["user_id"]) ? 0 : Convert.ToInt32(dv[dtgrdMain.CurrentRowIndex]["user_id"]);
                int groupId = Convert.ToInt32(lvwGroup.SelectedItems[0].Tag);
                int employeeId = Convert.ToInt32(dv[dtgrdMain.CurrentRowIndex]["employee_id"]);
                string userCode = dv[dtgrdMain.CurrentRowIndex]["Code"].ToString().Trim();
                //判断是否在该组已添加该用户
                for (int i = 0; i < lvwUser.Items.Count; i++)
                {
                    if (Convert.ToInt32(lvwUser.Items[i].Tag) == userId)
                    {
                        MessageBox.Show("该用户组已经添加该用户！", "提示");
                        dtgrdMain.SelectCurrentRow();
                        return;
                    }
                }
                #region 如果选择的人员没有分配用户名，弹出用户设置对话框
                if (userCode.Trim() == "")
                {
                    FrmAddUser addUser = new FrmAddUser(employeeId);
                    addUser.ShowDialog();
                    if (addUser.DialogResult != DialogResult.Cancel)
                    {
                        LoadAllUser();
                        ViewGroupMember(groupId);
                    }
                    return;
                }
                #endregion

                ParameterEx[] paras = new ParameterEx[5];
                #region ...
                paras[0].Text = "@UserId";
                paras[0].ParaSize = 100;
                paras[0].ParaDirection = ParameterDirection.InputOutput;
                paras[0].Value = userId;

                paras[1].Text = "@EmployeeId";
                paras[1].Value = employeeId;

                paras[2].Text = "@Code";
                paras[2].Value = userCode.Trim();

                paras[3].Text = "@GroupId";
                paras[3].Value = groupId;

                paras[4].Text = "@Errmsg";
                paras[4].ParaSize = 100;
                paras[4].ParaDirection = ParameterDirection.Output;
                #endregion
                IDbCommand cmd = db.GetCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "up_AddUserToGroup";
                db.SetParameters(cmd, paras);

                try
                {
                    //定义多院操作日志 Modify By Tany 2010-01-29
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    Guid log_djid = Guid.Empty;

                    db.BeginTransaction();

                    db.DoCommand(cmd);
                    if (((IDataParameter)cmd.Parameters[4]).Value.ToString().Trim() != "")
                    {
                        db.RollbackTransaction();
                        MessageBox.Show(((IDataParameter)cmd.Parameters[4]).Value.ToString().Trim(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                    string cznr = "增加组用户信息:【往组 " + lvwGroup.SelectedItems[0].Text.Trim() + " 增加用户 " + dv[dtgrdMain.CurrentRowIndex]["name"].ToString().Trim() + "】";
                    ts.Save_log(ts_HospData_Share.czlx.jc_用户修改, cznr, "pub_user", "id", userId.ToString(), jgbm, -999, "", out log_djid, db);

                    db.CommitTransaction();

                    try
                    {
                        //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                        string errtext = "";
                        ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_用户修改, db);
                        if (ty.Bzx == 1 && log_djid != Guid.Empty)
                        {
                            //立即执行该操作 Modify By Tany 2010-01-25
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

                    LoadAllUser();
                    ViewGroupMember(groupId);
                }
                catch (Exception err)
                {
                    db.RollbackTransaction();
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void lvwGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            lvwGroup_Click(null, null);
        }

        private void tvwAccess_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //MessageBox.Show(e.Node.Tag.ToString());
        }

        private void btAllow_Click(object sender, System.EventArgs e)
        {
            if (tvwAccess.SelectedNode == null)
            {
                MessageBox.Show("请选择具体项！", "提示");
                return;
            }
            tvwAccess.SelectedNode.ImageIndex = ALLACCESSIMAGEINDEX;
            tvwAccess.SelectedNode.SelectedImageIndex = ALLACCESSIMAGEINDEX;
            SetParentNodeStatus(tvwAccess.SelectedNode);
            SetNodeCheckStatus(tvwAccess.SelectedNode, true);
        }

        private void btForbidden_Click(object sender, System.EventArgs e)
        {
            if (tvwAccess.SelectedNode == null)
            {
                MessageBox.Show("请选择具体项！", "提示");
                return;
            }
            tvwAccess.SelectedNode.ImageIndex = NONACCESSIMAGEINDEX;
            tvwAccess.SelectedNode.SelectedImageIndex = NONACCESSIMAGEINDEX;
            SetParentNodeStatus(tvwAccess.SelectedNode);
            SetNodeCheckStatus(tvwAccess.SelectedNode, false);
        }

        private void btnSaveAccess_Click(object sender, System.EventArgs e)
        {
            SaveGroupAccess();
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Tag.ToString().ToUpper())
            {
                case "ADD_GROUP":
                    break;
                case "REFRESH":
                    LoadAllGroup();
                    LoadAllUser();
                    lvwUser.Items.Clear();
                    LoadAllSystemMenuStruct();
                    lvwGroup.SelectedItems.Clear();
                    break;
                case "CLOSE":
                    this.Close();
                    break;
                case "EDIT_GROUP":
                    EditGroupName();
                    break;
                case "DELETEGROUP":
                    if (this.lvwGroup.SelectedItems.Count == 1)
                    {
                        string groupId = this.lvwGroup.SelectedItems[0].Tag.ToString();
                        DataTable tb = db.GetDataTable("select * from pub_group_user where group_id=" + groupId + " and user_id in (select id from pub_user where delete_bit=0)");
                        if (tb.Rows.Count > 0)
                        {
                            MessageBox.Show("该组下还有用户,不能删除");
                            return;
                        }
                        if (MessageBox.Show("确定要删除组吗", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            try
                            {
                                //定义多院操作日志 Modify By Tany 2010-01-29
                                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                                Guid log_djid = Guid.Empty;

                                db.BeginTransaction();
                                db.DoCommand("update pub_group set delete_bit=1 where id=" + groupId);
                                db.DoCommand("delete from pub_group_menu where group_id=" + groupId);

                                //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                                string cznr = "删除用户组:【" + this.lvwGroup.SelectedItems[0].Text.Trim() + "】";
                                ts.Save_log(ts_HospData_Share.czlx.jc_组删除, cznr, "pub_group", "id", groupId.ToString(), jgbm, -999, "", out log_djid, db);
                                db.CommitTransaction();

                                try
                                {
                                    //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                                    string errtext = "";
                                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_组删除, db);
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

                                lvwGroup.Items.Remove(this.lvwGroup.SelectedItems[0]);
                            }
                            catch(Exception err)
                            {
                                db.RollbackTransaction();
                                MessageBox.Show(err.Message);
                            }
                        }
                    }
                    break;
            }
        }

        private void mnuAddAdminGroup_Click(object sender, System.EventArgs e)
        {
            AddGroup(1);
        }

        private void mnuAddCommonGroup_Click(object sender, System.EventArgs e)
        {
            AddGroup(0);
        }

        private void EditGroupName()
        {
            string newCode = "";
            string sql = "";

            newCode = DlgInputBoxStatic.InputBox("请输入新的组名", "修改组名", this.lvwGroup.SelectedItems[0].Text);
            if (DlgInputBoxStatic.dlgResult == DialogResult.Cancel) return;

            sql = "select * from pub_group where upper(name)='" + newCode.Trim().ToUpper() + "' and id <>" + this.lvwGroup.SelectedItems[0].Tag.ToString();
            DataRow dr = db.GetDataRow(sql);
            while (dr != null)
            {
                newCode = DlgInputBoxStatic.InputBox("输入的组名[ " + newCode + " ]已经存在，请重新输入", "修改组名", this.lvwGroup.SelectedItems[0].Text);
                if (DlgInputBoxStatic.dlgResult == DialogResult.Cancel) return;
                sql = "select * from pub_group where upper(name)='" + newCode.Trim().ToUpper() + "' and id <>" + this.lvwGroup.SelectedItems[0].Tag.ToString();
                dr = db.GetDataRow(sql);
            }

            try
            {
                //定义多院操作日志 Modify By Tany 2010-01-29
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                Guid log_djid = Guid.Empty;

                db.BeginTransaction();

                sql = "update pub_group set [name] = '" + newCode.Trim() + "' where id=" + this.lvwGroup.SelectedItems[0].Tag.ToString();
                db.DoCommand(sql);

                //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                string cznr = "修改用户组:【原名称:" + this.lvwGroup.SelectedItems[0].Text.Trim() + " 新名称:" + newCode.Trim() + "】";
                ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, cznr, "pub_group", "id", this.lvwGroup.SelectedItems[0].Tag.ToString(), jgbm, -999, "", out log_djid, db);

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

                this.lvwGroup.SelectedItems[0].Text = newCode;
            }
            catch (Exception err)
            {
                db.RollbackTransaction();
                MessageBox.Show(err.Message);
            }
        }

        private void lvwGroup_Click(object sender, System.EventArgs e)
        {
            if (lvwGroup.SelectedItems.Count == 0) return;
            int groupId = Convert.ToInt32(lvwGroup.SelectedItems[0].Tag);
            //显示组成员
            ViewGroupMember(groupId);
            Clear();
            //显示组菜单
            
            DisplayGroupAccessMenu(groupId);
            
        }

        private void Clear()
        {
            foreach (TreeNode node in this.tvwAccess.Nodes)
            {
                node.ImageIndex = NONACCESSIMAGEINDEX;
                ClearSubNode(node);
            }
        }
        private void ClearSubNode(TreeNode node)
        {
            foreach (TreeNode subNode in node.Nodes)
            {
                subNode.ImageIndex = NONACCESSIMAGEINDEX;
                ClearSubNode(subNode);
            }
        }

        private void lvwGroup_DoubleClick(object sender, EventArgs e)
        {
            //comment by wangzhi 2010-10-20
            //以增加了消息权限管理机制，该处已不用
            //try
            //{
            //    if (lvwGroup.SelectedItems.Count == 0)
            //    {
            //        return;
            //    }
            //    if (lvwGroup.SelectedItems[0].SubItems[2].Text == "")
            //        lvwGroup.SelectedItems[0].SubItems[2].Text = "*";
            //    else
            //        lvwGroup.SelectedItems[0].SubItems[2].Text = "";

            //    string sVal = "";
            //    foreach (ListViewItem item in lvwGroup.Items)
            //    {
            //        if (item.SubItems[2].Text != "")
            //        {
            //            sVal = sVal + item.Tag.ToString() + ",";
            //        }
            //    }
            //    if (sVal != "")
            //    {
            //        sVal = sVal.Remove(sVal.Length - 1);
            //    }
            //    string sql = "update jc_config set config ='" + sVal + "' where id=0006";
            //    db.DoCommand(sql);
                
                
                
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
        }

    }
}
