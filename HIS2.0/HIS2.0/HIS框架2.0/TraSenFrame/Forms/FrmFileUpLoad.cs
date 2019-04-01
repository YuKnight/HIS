using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using System.Data;
using System.Data.Common;
using TrasenClasses.DatabaseAccess;

namespace TrasenFrame.Forms
{
    // jianqg 2013-2-22 增加 文件夹上传
    /// <summary>
    ///系统升级文件上传对话框
    /// </summary>
    public class FrmFileUpLoad : System.Windows.Forms.Form
    {
        /// <summary>
        /// 本窗体的数据库连接
        /// </summary>
        private RelationalDatabase db;//Add By Tany 2010-01-27
        /// <summary>
        /// 本窗体连接的机构编码
        /// </summary>
        private int jgbm;//Add By Tany 2010-01-27
        /// <summary>
        /// 是否升级到所有服务器
        /// </summary>
        private bool isUpdateAll;//Add By Tany 2010-02-22

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ListView lvwHistory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ProgressBar pbTotal;
        private System.Windows.Forms.ContextMenu cmenuDelete;
        private System.Windows.Forms.MenuItem menuDel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private Label label4;
        private Label label3;
        private TextBox txt_file;
        private TabPage tabPage3;
        private TrasenClasses.GeneralControls.DataGridEx dataGridSQl;
        private DataGridTableStyle dataGridTableStyle1;
        private DataGridTextBoxColumn col_ID;
        private DataGridTextBoxColumn col_Version;
        private DataGridTextBoxColumn col_Type_name;
        private DataGridTextBoxColumn col_Update_Time;
        private DataGridTextBoxColumn col_Update_File_Count;
        private DataGridTextBoxColumn col_Update_User;
        private TextBox txt_sqlTime;
        private Label label5;
        private Label label6;
        private TextBox txt_sqlVersion;
        private Button btnSqlRefresh;
        private TextBox txt_sqlType;
        private Label label7;
        private ComboBox txt_version;
        private Label lbl_version;
        private Label label8;
        private DataGridView dgvFiles;
        private Button btnChangeFolder;
        private Button btnRemove;
        private RadioButton rdByFile;
        private RadioButton rdByFolder;
        private Label label2;
        private Button btnOpen;
        private Label label9;
        private DataGridViewTextBoxColumn COL_FILE_NAME;
        private DataGridViewTextBoxColumn COL_CURRENT_VERSION;
        private DataGridViewTextBoxColumn COL_FILE_TYPE;
        private DataGridViewTextBoxColumn COL_SOURCE_PATH;
        private DataGridViewCheckBoxColumn COL_REPLACE;
        private DataGridViewTextBoxColumn COL_DOWNLOAD_PATH;
        private DataGridViewTextBoxColumn COL_SELECT_FOLDER;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmFileUpLoad(bool _isUpdateAll)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            
            //Modify By Tany 2010-02-22 是否升级到所有服务器
            isUpdateAll = _isUpdateAll;

            //Modify By Tany 2010-01-27 使用本窗体自己的数据连接
            //如果设置了中心机构编码并且中心机构编码不等于当前连接的机构编码，则重新实例化本地连接为中心数据库连接
            //Modify By Tany 2010-02-22 增加判断是不是需要发布到所有服务器
            if (FrmMdiMain.ZxJgbm != -1 && FrmMdiMain.ZxJgbm != FrmMdiMain.Jgbm && _isUpdateAll)
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOpen = new System.Windows.Forms.Button();
            this.rdByFile = new System.Windows.Forms.RadioButton();
            this.rdByFolder = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbTotal = new System.Windows.Forms.ProgressBar();
            this.btnUpload = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_version = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lvwHistory = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.cmenuDelete = new System.Windows.Forms.ContextMenu();
            this.menuDel = new System.Windows.Forms.MenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_version = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_file = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_sqlType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_sqlTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_sqlVersion = new System.Windows.Forms.TextBox();
            this.btnSqlRefresh = new System.Windows.Forms.Button();
            this.dataGridSQl = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.col_ID = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_Version = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_Type_name = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_Update_Time = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_Update_File_Count = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_Update_User = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.COL_FILE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_CURRENT_VERSION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_FILE_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SOURCE_PATH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_REPLACE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COL_DOWNLOAD_PATH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_SELECT_FOLDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvFiles ) ).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridSQl ) ).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Controls.Add( this.tabPage2 );
            this.tabControl1.Controls.Add( this.tabPage3 );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point( 0 , 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 1018 , 496 );
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.label9 );
            this.tabPage1.Controls.Add( this.btnOpen );
            this.tabPage1.Controls.Add( this.rdByFile );
            this.tabPage1.Controls.Add( this.rdByFolder );
            this.tabPage1.Controls.Add( this.label2 );
            this.tabPage1.Controls.Add( this.btnRemove );
            this.tabPage1.Controls.Add( this.btnChangeFolder );
            this.tabPage1.Controls.Add( this.dgvFiles );
            this.tabPage1.Controls.Add( this.txtVersion );
            this.tabPage1.Controls.Add( this.label1 );
            this.tabPage1.Controls.Add( this.pbTotal );
            this.tabPage1.Controls.Add( this.btnUpload );
            this.tabPage1.Location = new System.Drawing.Point( 4 , 22 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size( 1010 , 470 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "升级文件上传";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpen.Location = new System.Drawing.Point( 653 , 437 );
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size( 75 , 23 );
            this.btnOpen.TabIndex = 16;
            this.btnOpen.Text = "打开";
            this.btnOpen.Click += new System.EventHandler( this.btnOpen_Click );
            // 
            // rdByFile
            // 
            this.rdByFile.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.rdByFile.AutoSize = true;
            this.rdByFile.Checked = true;
            this.rdByFile.Location = new System.Drawing.Point( 588 , 440 );
            this.rdByFile.Name = "rdByFile";
            this.rdByFile.Size = new System.Drawing.Size( 59 , 16 );
            this.rdByFile.TabIndex = 15;
            this.rdByFile.TabStop = true;
            this.rdByFile.Text = "按文件";
            this.rdByFile.UseVisualStyleBackColor = true;
            // 
            // rdByFolder
            // 
            this.rdByFolder.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.rdByFolder.AutoSize = true;
            this.rdByFolder.Location = new System.Drawing.Point( 511 , 440 );
            this.rdByFolder.Name = "rdByFolder";
            this.rdByFolder.Size = new System.Drawing.Size( 71 , 16 );
            this.rdByFolder.TabIndex = 14;
            this.rdByFolder.Text = "按文件夹";
            this.rdByFolder.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 395 , 442 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 101 , 12 );
            this.label2.TabIndex = 13;
            this.label2.Text = "上传文件选择方式";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Location = new System.Drawing.Point( 734 , 437 );
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size( 72 , 23 );
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "移除";
            this.btnRemove.Click += new System.EventHandler( this.btnRemove_Click );
            // 
            // btnChangeFolder
            // 
            this.btnChangeFolder.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnChangeFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangeFolder.Location = new System.Drawing.Point( 812 , 437 );
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.Size = new System.Drawing.Size( 109 , 23 );
            this.btnChangeFolder.TabIndex = 11;
            this.btnChangeFolder.Text = "更改下载目录";
            this.btnChangeFolder.Click += new System.EventHandler( this.btnChangeFolder_Click );
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.BackgroundColor = System.Drawing.Color.White;
            this.dgvFiles.ColumnHeadersHeight = 30;
            this.dgvFiles.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_FILE_NAME,
            this.COL_CURRENT_VERSION,
            this.COL_FILE_TYPE,
            this.COL_SOURCE_PATH,
            this.COL_REPLACE,
            this.COL_DOWNLOAD_PATH,
            this.COL_SELECT_FOLDER} );
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvFiles.Location = new System.Drawing.Point( 0 , 0 );
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFiles.RowTemplate.Height = 23;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size( 1010 , 404 );
            this.dgvFiles.TabIndex = 8;
            this.dgvFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler( this.dgvFiles_CellContentClick );
            // 
            // txtVersion
            // 
            this.txtVersion.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.txtVersion.Location = new System.Drawing.Point( 816 , 410 );
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size( 188 , 21 );
            this.txtVersion.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label1.Location = new System.Drawing.Point( 720 , 414 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 92 , 14 );
            this.label1.TabIndex = 5;
            this.label1.Text = "本次上传版本：";
            // 
            // pbTotal
            // 
            this.pbTotal.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.pbTotal.Location = new System.Drawing.Point( 3 , 410 );
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Size = new System.Drawing.Size( 712 , 18 );
            this.pbTotal.TabIndex = 4;
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpload.Location = new System.Drawing.Point( 927 , 437 );
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size( 75 , 23 );
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "上传";
            this.btnUpload.Click += new System.EventHandler( this.btnUpload_Click );
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.panel3 );
            this.tabPage2.Controls.Add( this.panel2 );
            this.tabPage2.Location = new System.Drawing.Point( 4 , 22 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size( 1010 , 470 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "历史上传文件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.lbl_version );
            this.panel3.Controls.Add( this.label8 );
            this.panel3.Controls.Add( this.lvwHistory );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point( 0 , 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 1010 , 444 );
            this.panel3.TabIndex = 3;
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point( 103 , 9 );
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size( 71 , 12 );
            this.lbl_version.TabIndex = 6;
            this.lbl_version.Text = "lbl_version";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point( 8 , 9 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 77 , 12 );
            this.label8.TabIndex = 5;
            this.label8.Text = "当前版本号：";
            // 
            // lvwHistory
            // 
            this.lvwHistory.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.lvwHistory.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader3,
            this.columnHeader4} );
            this.lvwHistory.ContextMenu = this.cmenuDelete;
            this.lvwHistory.FullRowSelect = true;
            this.lvwHistory.Location = new System.Drawing.Point( 0 , 29 );
            this.lvwHistory.Name = "lvwHistory";
            this.lvwHistory.Size = new System.Drawing.Size( 1010 , 414 );
            this.lvwHistory.TabIndex = 0;
            this.lvwHistory.UseCompatibleStateImageBehavior = false;
            this.lvwHistory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 207;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "版本";
            this.columnHeader2.Width = 125;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "类型";
            this.columnHeader5.Width = 48;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "上传时间";
            this.columnHeader3.Width = 174;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "有效";
            this.columnHeader4.Width = 47;
            // 
            // cmenuDelete
            // 
            this.cmenuDelete.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.menuDel} );
            // 
            // menuDel
            // 
            this.menuDel.Index = 0;
            this.menuDel.Text = "删除(DEL)";
            this.menuDel.Click += new System.EventHandler( this.menuDel_Click );
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.txt_version );
            this.panel2.Controls.Add( this.label4 );
            this.panel2.Controls.Add( this.label3 );
            this.panel2.Controls.Add( this.txt_file );
            this.panel2.Controls.Add( this.btnDelete );
            this.panel2.Controls.Add( this.btnRefresh );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point( 0 , 444 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 1010 , 26 );
            this.panel2.TabIndex = 2;
            // 
            // txt_version
            // 
            this.txt_version.FormattingEnabled = true;
            this.txt_version.Location = new System.Drawing.Point( 333 , 4 );
            this.txt_version.Name = "txt_version";
            this.txt_version.Size = new System.Drawing.Size( 155 , 20 );
            this.txt_version.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 286 , 7 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 41 , 12 );
            this.label4.TabIndex = 4;
            this.label4.Text = "版本号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 8 , 7 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 95 , 12 );
            this.label3.TabIndex = 3;
            this.label3.Text = "刷新条件:文件名";
            // 
            // txt_file
            // 
            this.txt_file.Location = new System.Drawing.Point( 105 , 3 );
            this.txt_file.Name = "txt_file";
            this.txt_file.Size = new System.Drawing.Size( 175 , 21 );
            this.txt_file.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point( 494 , 2 );
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size( 75 , 23 );
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "置无效";
            this.btnDelete.Click += new System.EventHandler( this.btnDelete_Click );
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Location = new System.Drawing.Point( 572 , 2 );
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size( 75 , 23 );
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler( this.btnRefresh_Click );
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add( this.txt_sqlType );
            this.tabPage3.Controls.Add( this.label7 );
            this.tabPage3.Controls.Add( this.txt_sqlTime );
            this.tabPage3.Controls.Add( this.label5 );
            this.tabPage3.Controls.Add( this.label6 );
            this.tabPage3.Controls.Add( this.txt_sqlVersion );
            this.tabPage3.Controls.Add( this.btnSqlRefresh );
            this.tabPage3.Controls.Add( this.dataGridSQl );
            this.tabPage3.Location = new System.Drawing.Point( 4 , 22 );
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage3.Size = new System.Drawing.Size( 1010 , 470 );
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "历史SQL更新";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_sqlType
            // 
            this.txt_sqlType.Location = new System.Drawing.Point( 455 , 444 );
            this.txt_sqlType.Name = "txt_sqlType";
            this.txt_sqlType.Size = new System.Drawing.Size( 101 , 21 );
            this.txt_sqlType.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point( 422 , 448 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 29 , 12 );
            this.label7.TabIndex = 11;
            this.label7.Text = "类型";
            // 
            // txt_sqlTime
            // 
            this.txt_sqlTime.Location = new System.Drawing.Point( 317 , 444 );
            this.txt_sqlTime.Name = "txt_sqlTime";
            this.txt_sqlTime.Size = new System.Drawing.Size( 101 , 21 );
            this.txt_sqlTime.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 282 , 448 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 29 , 12 );
            this.label5.TabIndex = 9;
            this.label5.Text = "时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 4 , 448 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 83 , 12 );
            this.label6.TabIndex = 8;
            this.label6.Text = "刷新条件:版本";
            // 
            // txt_sqlVersion
            // 
            this.txt_sqlVersion.Location = new System.Drawing.Point( 88 , 444 );
            this.txt_sqlVersion.Name = "txt_sqlVersion";
            this.txt_sqlVersion.Size = new System.Drawing.Size( 188 , 21 );
            this.txt_sqlVersion.TabIndex = 7;
            // 
            // btnSqlRefresh
            // 
            this.btnSqlRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSqlRefresh.Location = new System.Drawing.Point( 571 , 443 );
            this.btnSqlRefresh.Name = "btnSqlRefresh";
            this.btnSqlRefresh.Size = new System.Drawing.Size( 75 , 23 );
            this.btnSqlRefresh.TabIndex = 6;
            this.btnSqlRefresh.Text = "刷新";
            this.btnSqlRefresh.Click += new System.EventHandler( this.btnSqlRefresh_Click );
            // 
            // dataGridSQl
            // 
            this.dataGridSQl.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.dataGridSQl.CaptionVisible = false;
            this.dataGridSQl.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridSQl.DataMember = "";
            this.dataGridSQl.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridSQl.Location = new System.Drawing.Point( 6 , 6 );
            this.dataGridSQl.Name = "dataGridSQl";
            this.dataGridSQl.ReadOnly = true;
            this.dataGridSQl.RowHeadersVisible = false;
            this.dataGridSQl.RowHeaderWidth = 0;
            this.dataGridSQl.Size = new System.Drawing.Size( 996 , 431 );
            this.dataGridSQl.TabIndex = 0;
            this.dataGridSQl.TableStyles.AddRange( new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1} );
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dataGridSQl;
            this.dataGridTableStyle1.GridColumnStyles.AddRange( new System.Windows.Forms.DataGridColumnStyle[] {
            this.col_ID,
            this.col_Version,
            this.col_Type_name,
            this.col_Update_Time,
            this.col_Update_File_Count,
            this.col_Update_User} );
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // col_ID
            // 
            this.col_ID.Format = "";
            this.col_ID.FormatInfo = null;
            this.col_ID.MappingName = "ID";
            this.col_ID.ReadOnly = true;
            this.col_ID.Width = 0;
            // 
            // col_Version
            // 
            this.col_Version.Format = "";
            this.col_Version.FormatInfo = null;
            this.col_Version.HeaderText = "版本";
            this.col_Version.MappingName = "Version";
            this.col_Version.NullText = "";
            this.col_Version.ReadOnly = true;
            this.col_Version.Width = 250;
            // 
            // col_Type_name
            // 
            this.col_Type_name.Format = "";
            this.col_Type_name.FormatInfo = null;
            this.col_Type_name.HeaderText = "类型";
            this.col_Type_name.MappingName = "Type_name";
            this.col_Type_name.NullText = "";
            this.col_Type_name.ReadOnly = true;
            this.col_Type_name.Width = 80;
            // 
            // col_Update_Time
            // 
            this.col_Update_Time.Format = "";
            this.col_Update_Time.FormatInfo = null;
            this.col_Update_Time.HeaderText = "更新时间";
            this.col_Update_Time.MappingName = "updateDate";
            this.col_Update_Time.NullText = "";
            this.col_Update_Time.ReadOnly = true;
            this.col_Update_Time.Width = 120;
            // 
            // col_Update_File_Count
            // 
            this.col_Update_File_Count.Format = "";
            this.col_Update_File_Count.FormatInfo = null;
            this.col_Update_File_Count.HeaderText = "更新文件数";
            this.col_Update_File_Count.MappingName = "Update_File_Count";
            this.col_Update_File_Count.NullText = "";
            this.col_Update_File_Count.ReadOnly = true;
            this.col_Update_File_Count.Width = 75;
            // 
            // col_Update_User
            // 
            this.col_Update_User.Format = "";
            this.col_Update_User.FormatInfo = null;
            this.col_Update_User.HeaderText = "更新者";
            this.col_Update_User.MappingName = "Update_User";
            this.col_Update_User.NullText = "";
            this.col_Update_User.ReadOnly = true;
            this.col_Update_User.Width = 75;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point( 932 , 498 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75 , 23 );
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point( 6 , 433 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 381 , 33 );
            this.label9.TabIndex = 17;
            this.label9.Text = "注：1、“..”时RPT文件自动默认到Report文件夹\r\n    2、Shift/Ctrl+鼠标左键可多选则多行\r\n";
            // 
            // COL_FILE_NAME
            // 
            this.COL_FILE_NAME.HeaderText = "文件名";
            this.COL_FILE_NAME.Name = "COL_FILE_NAME";
            this.COL_FILE_NAME.ReadOnly = true;
            this.COL_FILE_NAME.Width = 150;
            // 
            // COL_CURRENT_VERSION
            // 
            this.COL_CURRENT_VERSION.HeaderText = "文件版本";
            this.COL_CURRENT_VERSION.Name = "COL_CURRENT_VERSION";
            this.COL_CURRENT_VERSION.ReadOnly = true;
            // 
            // COL_FILE_TYPE
            // 
            this.COL_FILE_TYPE.HeaderText = "类型";
            this.COL_FILE_TYPE.Name = "COL_FILE_TYPE";
            this.COL_FILE_TYPE.ReadOnly = true;
            this.COL_FILE_TYPE.Width = 40;
            // 
            // COL_SOURCE_PATH
            // 
            this.COL_SOURCE_PATH.HeaderText = "源路径";
            this.COL_SOURCE_PATH.Name = "COL_SOURCE_PATH";
            this.COL_SOURCE_PATH.ReadOnly = true;
            this.COL_SOURCE_PATH.Width = 200;
            // 
            // COL_REPLACE
            // 
            this.COL_REPLACE.HeaderText = "替换在用报表";
            this.COL_REPLACE.Name = "COL_REPLACE";
            this.COL_REPLACE.ReadOnly = true;
            this.COL_REPLACE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_REPLACE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COL_REPLACE.Width = 50;
            // 
            // COL_DOWNLOAD_PATH
            // 
            this.COL_DOWNLOAD_PATH.HeaderText = "下载路径       (“..”代表运行目录)";
            this.COL_DOWNLOAD_PATH.Name = "COL_DOWNLOAD_PATH";
            this.COL_DOWNLOAD_PATH.ReadOnly = true;
            this.COL_DOWNLOAD_PATH.Width = 400;
            // 
            // COL_SELECT_FOLDER
            // 
            this.COL_SELECT_FOLDER.HeaderText = "";
            this.COL_SELECT_FOLDER.Name = "COL_SELECT_FOLDER";
            this.COL_SELECT_FOLDER.ReadOnly = true;
            this.COL_SELECT_FOLDER.Visible = false;
            // 
            // FrmFileUpLoad
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 6 , 14 );
            this.ClientSize = new System.Drawing.Size( 1018 , 525 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.tabControl1 );
            this.Name = "FrmFileUpLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统升级文件上传";
            this.Load += new System.EventHandler( this.FrmFileUpLoad_Load );
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.tabPage1.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvFiles ) ).EndInit();
            this.tabPage2.ResumeLayout( false );
            this.panel3.ResumeLayout( false );
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout( false );
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout( false );
            this.tabPage3.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridSQl ) ).EndInit();
            this.ResumeLayout( false );

        }
        #endregion
        #region sql日志刷新
        /// <summary>
        /// sql日志刷新 jianqg 2012-6-29
        /// </summary>
        /// <param name="where"></param>
        private void LoadAllUpdatedSQl(string where)
        {

            string sql1 = @"select * ,convert( varchar(50),GETDATE(),112)+REPLACE( convert( varchar(8),GETDATE(),114),':','') as updateDate
            from Pub_SystemUpdate_SQL where Update_Time is not null 
                " + where + " order by Update_Time";
            DataTable tb_sql = db.GetDataTable(sql1);
            dataGridSQl.DataSource = tb_sql;
        }
        #endregion
        #region 方法
        /// <summary>
        /// 加载所有已上传文件及版本信息
        /// </summary>
        private void LoadAllUpdatedFiles(string where)
        {
            string sql = @"select id, name,type,version,update_time,delete_bit from Pub_SystemUpdate 
						where delete_bit=0  " + where + " order by type,name";
            DataTable tb = db.GetDataTable(sql);
            this.lvwHistory.Items.Clear();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = tb.Rows[i]["name"].ToString().Trim();
                item.SubItems.Add(tb.Rows[i]["version"].ToString().Trim());
                item.SubItems.Add(tb.Rows[i]["type"].ToString().Trim());
                item.SubItems.Add(tb.Rows[i]["update_time"].ToString());
                item.SubItems.Add(tb.Rows[i]["delete_bit"].ToString());
                item.Tag = Convert.ToInt32(tb.Rows[i]["id"]);
                this.lvwHistory.Items.Add(item);
            }
            // jianqg 2012-9-24 增加当前版本号显示
            txt_version.Items.Clear();

            BindingSource dtTmp = new BindingSource();
            dtTmp.DataSource= tb.Copy();
            dtTmp.Sort = "version desc";
            lbl_version.Text = "";
            for (int i = 0; i < dtTmp.Count ; i++)
            {
               // ((System.Data.DataView)(((System.Windows.Forms.BindingSource)(dtTmp.CurrencyManager.List)).List))
                string strTmp=(((System.Data.DataView)(((System.Windows.Forms.BindingSource)(dtTmp.CurrencyManager.List)).List)))[i]["version"].ToString();
                if (i == 0) lbl_version.Text =strTmp;


                if (txt_version.Items.Contains(strTmp) == false) txt_version.Items.Add(strTmp);
                if (txt_version.Items.Count >= 20) return;
            }



        }

        private string GetFileLength(long len)
        {
            int i = (int)(len / 1024);
            if (i * 1024 < len)
            {
                i++;
            }
            return i.ToString() + " KB";
        }
        /// <summary>
        /// 上传文件（将文件以字节方式保存在数据库）
        /// </summary>
        /// <returns></returns>        
        private void UploadNewFiles()
        {
            bool beginTransaction = false;
            try
            {
                if ( dgvFiles.Rows.Count == 0 )
                {
                    MessageBox.Show( "请选择需要上传的文件！" , "提示" );
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;
                pbTotal.Maximum = dgvFiles.Rows.Count;
                pbTotal.Value = 0;

                string sql = "select * from Pub_SystemUpdate where 1=2 ";//and delete_bit=0 Modify By Tany 2009-11-19 只需要结构，不需要里面的数据
                DataSet dataSet = new DataSet();

                //定义多院操作日志 Modify By Tany 2010-01-29
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                Guid log_djid = Guid.Empty;

                //开始事务
                db.BeginTransaction();
                beginTransaction = true;
                //主表适配器
                DbDataAdapter ada0 = db.GetAdapter( sql );
                db.CreateCommandBuilder( ada0 );

                ada0.Fill( dataSet , "SystemUpdate" );

                for ( int i = 0 ; i < dgvFiles.Rows.Count ; i++ )
                {
                    string sFilePath = dgvFiles.Rows[i].Cells[COL_SOURCE_PATH.Name].Value.ToString();
                    string sFileName = dgvFiles.Rows[i].Cells[COL_FILE_NAME.Name].Value.ToString();
                    string sFileVersion = dgvFiles.Rows[i].Cells[COL_CURRENT_VERSION.Name].Value.ToString();
                    int flag = dgvFiles.Rows[i].Cells[COL_REPLACE.Name].Value == null ? 0 : Convert.ToInt32( dgvFiles.Rows[i].Cells[COL_REPLACE.Name].Value );
                    string downloadFolder = dgvFiles.Rows[i].Cells[COL_DOWNLOAD_PATH.Name].Value.ToString();

                    DataRow row = dataSet.Tables["SystemUpdate"].NewRow();

                    FileStream fs = new FileStream( sFilePath , FileMode.OpenOrCreate , FileAccess.Read );
                    byte[] theData = new byte[fs.Length];
                    fs.Read( theData , 0 , System.Convert.ToInt32( fs.Length ) );
                    fs.Close();
                    row["File_Value"] = theData;

                    row["Type"] = 0;
                    row["Name"] = sFileName;
                    row["Update_Time"] = DateTime.Now;
                    row["Delete_Bit"] = 0;
                    row["Version"] = sFileVersion;
                    row["DelLocalReport"] = flag;
                    row["Download_Folder"] = downloadFolder; //add by wangzhi 2013-02-27

                    dataSet.Tables["SystemUpdate"].Rows.Add( row );
                    pbTotal.PerformStep();
                }
                //更新数据
                ada0.Update( dataSet , "SystemUpdate" );

                //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                string cznr = "上传升级文件:【版本[" + txtVersion.Text + "]】";
                ts.Save_log( ts_HospData_Share.czlx.jc_修改升级文件 , cznr , "pub_systemupdate" , "Version" , txtVersion.Text.ToString() , jgbm , 0 , "" , out log_djid , db );

                //提交事务
                db.CommitTransaction();

                try
                {
                    //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type( (int)ts_HospData_Share.czlx.jc_修改升级文件 , db );
                    if ( ty.Bzx == 1 && log_djid != Guid.Empty )
                    {
                        //立即执行该操作 Modify By Tany 2010-01-29
                        ts.Pexec_log( log_djid , db , out errtext );
                    }
                    if ( errtext != "" )
                    {
                        throw new Exception( errtext );
                    }
                }
                catch ( Exception err )
                {
                    MessageBox.Show( "发生错误：" + err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                }

                MessageBox.Show( "上传完毕！" , "提示" );

                ada0.Dispose();
                dataSet.Dispose();
                pbTotal.Value = 0;
                Cursor.Current = Cursors.Default;
                return;
            }
            catch ( Exception err )
            {
                if ( beginTransaction )
                {
                    //回滚事务
                    db.RollbackTransaction();
                }
                Cursor.Current = Cursors.Default;
                MessageBox.Show( err.Message , "错误" );
                return;
            }
        }        
        #endregion

        #region 主窗体事件
        private void FrmFileUpLoad_Load(object sender, System.EventArgs e)
        {
            LoadAllUpdatedFiles("");
            LoadAllUpdatedSQl("");
            this.txtVersion.Text = TrasenClasses.GeneralClasses.DateManager.ServerDateTimeByDBType(db).ToString("yyyyMMddHHmmss");

            
            this.Left = 0;
        }
        #endregion

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        
        private void ForeachFolderFiles( string path , ref DataTable tbFileList )
        {
            DirectoryInfo curDir = new DirectoryInfo( path );
            FileInfo[] files = curDir.GetFiles();
            foreach ( FileInfo fi in files )
                tbFileList.Rows.Add( new object[] { fi.Name , fi.Directory.ToString() , "" } );

            DirectoryInfo[] subDirs = curDir.GetDirectories();
            foreach ( DirectoryInfo subdir in subDirs )
                ForeachFolderFiles( subdir.FullName , ref tbFileList );
        }

        private void btnUpload_Click(object sender, System.EventArgs e)
        {
            if (txtVersion.Text.Trim() != "")
            {
                string ss = "";
                if (isUpdateAll)
                {
                    ss = "所有服务器【" + jgbm + "】";
                }
                else
                {
                    ss = "本地服务器【" + jgbm + "】";
                }

                if (MessageBox.Show("本次升级将向 " + ss + " 发布升级文件，确认要这样做吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                foreach ( DataGridViewRow row in this.dgvFiles.Rows )
                {
                    row.Cells[COL_CURRENT_VERSION.Name].Value = txtVersion.Text.Trim();
                    //将相同文件的当前版本号置为无效
                    string sql = "update pub_systemupdate set delete_bit=1 where name='" + row.Cells[COL_FILE_NAME.Name].Value.ToString() + "'";
                    db.DoCommand( sql );
                }

                this.UploadNewFiles();
            }
            else
            {
                MessageBox.Show("请输入本次升级的版本号（默认格式YYYYMMDDHHMMSS）");
            }
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            foreach ( DataGridViewRow row in dgvFiles.SelectedRows )
                dgvFiles.Rows.Remove( row );
        }

        private void menuDel_Click(object sender, System.EventArgs e)
        {
            if (this.lvwHistory.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvwHistory.SelectedItems)
                {
                    
                    try
                    {
                        //定义多院操作日志 Modify By Tany 2010-01-29
                        ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                        Guid log_djid = Guid.Empty;

                        db.BeginTransaction();

                        string sql = "update pub_systemupdate set delete_bit=1 where id =" + item.Tag.ToString();
                        db.DoCommand(sql);

                        //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                        string cznr = "删除升级文件:【" + item.SubItems[0].Text + "[" + item.SubItems[1].Text + "]】";
                        ts.Save_log(ts_HospData_Share.czlx.jc_删除升级文件, cznr, "pub_systemupdate", "id", item.Tag.ToString(), jgbm, 0, "", out log_djid, db);

                        db.CommitTransaction();

                        try
                        {
                            //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                            string errtext = "";
                            ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_删除升级文件, db);
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

                        lvwHistory.Items.Remove(item);
                    }
                    catch (Exception err)
                    {
                        db.RollbackTransaction();
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            string strWhere = "";
            if (txt_file.Text.Trim() != "") strWhere += " and name like '%" + txt_file.Text.Trim().Replace("*","%") + "%'";
            if (txt_version.Text.Trim() != "") strWhere += " and version like '" + txt_version.Text.Trim() + "%'";

            LoadAllUpdatedFiles(strWhere);
        }
        #region sql日志刷新
        /// <summary>
        /// sql日志刷新 jianqg 2012-6-29
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSqlRefresh_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            if (txt_sqlVersion.Text.Trim() != "") strWhere += " and version like '%" + txt_sqlVersion.Text.Trim().Replace("*", "%") + "%'";
            if (txt_sqlType.Text.Trim() != "") strWhere += " and Type_name like '%" + txt_sqlType.Text.Trim() + "%'";
            if (txt_sqlTime.Text.Trim() != "") strWhere += " and convert( varchar(50),GETDATE(),112)+REPLACE( convert( varchar(8),GETDATE(),114),':','') like '" + txt_sqlTime.Text.Trim() + "%'";
            
            LoadAllUpdatedSQl(strWhere);
        }
        #endregion 
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (lvwHistory.SelectedItems.Count > 0)
            {
                try
                {
                    //定义多院操作日志 Modify By Tany 2010-01-29
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    Guid log_djid = Guid.Empty;

                    db.BeginTransaction();

                    string sql = "update pub_systemupdate set delete_bit=1 where id = " + lvwHistory.SelectedItems[0].Tag.ToString();
                    db.DoCommand(sql);

                    //处理多院数据处理，首先插入操作日志 Modify By Tany 2010-01-29
                    string cznr = "删除升级文件:【" + lvwHistory.SelectedItems[0].SubItems[0].Text + "[" + lvwHistory.SelectedItems[0].SubItems[1].Text + "]】";
                    ts.Save_log(ts_HospData_Share.czlx.jc_删除升级文件, cznr, "pub_systemupdate", "id", lvwHistory.SelectedItems[0].Tag.ToString(), jgbm, 0, "", out log_djid, db);

                    db.CommitTransaction();

                    try
                    {
                        //查看该类型操作是否属于立即执行 Modify By Tany 2010-01-29
                        string errtext = "";
                        ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_删除升级文件, db);
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

                    lvwHistory.SelectedItems[0].SubItems[4].Text = "1";
                }
                catch (Exception err)
                {
                    db.RollbackTransaction();
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void btnSelectFolder_Click( object sender , EventArgs e )
        {
            FolderBrowserDialog dirDlg = new FolderBrowserDialog();
            dirDlg.Description = "选择升级文件目录";
            dirDlg.ShowNewFolderButton = false;
            try
            {
                if ( btnOpen.Tag != null )
                    dirDlg.SelectedPath = btnOpen.Tag.ToString();
            }
            catch
            {
            }
            DialogResult dlgresult = dirDlg.ShowDialog();
            if ( dlgresult != DialogResult.OK )
            {
                return;
            }


            if ( dirDlg.SelectedPath == "" )
                return;
            string dirPath = dirDlg.SelectedPath;
            btnOpen.Tag = dirPath;
            DirectoryInfo dirinfo = new DirectoryInfo( dirPath );
            if ( dirinfo.Exists )
            {
                DataTable dtFiles = new DataTable();
                dtFiles.Columns.Add( "FILE_NAME" );
                dtFiles.Columns.Add( "SOURCE_FOLDER" );
                dtFiles.Columns.Add( "DOWNLOAD_FOLDER" );

                //wangzhi 2013-3-4 遍历指定的文件夹，获取到该文件夹下所有的文件
                ForeachFolderFiles( dirinfo.FullName , ref dtFiles );

                foreach ( DataRow row in dtFiles.Rows )
                {
                    string filePath = row["SOURCE_FOLDER"].ToString() + "\\" + row["FILE_NAME"].ToString();
                    AddSourceFile( filePath , dirPath , ".." );
                }
            }
        }

        private void btnSelectFile_Click( object sender , EventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.dll|*.dll|*.rpt|*.rpt|*.exe|*.exe|*.*|*.*";
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.Multiselect = true;
            if ( dlg.ShowDialog() == DialogResult.OK )
            {
                if ( dlg.FileNames.Length > 0 )
                {
                    for ( int i = 0 ; i < dlg.FileNames.Length ; i++ )
                    {
                        string filePath = dlg.FileNames[i];
                        string folder = ( new FileInfo( filePath ) ).Directory.ToString();
                        this.AddSourceFile( filePath , folder, ".." ); //jianqg 2013-2-22 调用公共过程
                        
                    }
                }
            }
        }

        private void btnChangeFolder_Click( object sender , EventArgs e )
        {
            FrmDownloadOption frmOption = new FrmDownloadOption();
            if ( frmOption.ShowDialog( this ) == DialogResult.Cancel )
                return;

            foreach ( DataGridViewRow row in dgvFiles.SelectedRows )
            {
                string dirPath = row.Cells[COL_SELECT_FOLDER.Name].Value.ToString();//点击打开文件夹或文件按钮时的所选择的的目录
                string downloadPath = row.Cells[COL_DOWNLOAD_PATH.Name].Value.ToString(); //期望下载的目录
                string fileFullName = row.Cells[COL_SOURCE_PATH.Name].Value.ToString(); //要上传的源文件路径
                string fileFolder = ( new FileInfo( fileFullName ) ).Directory.ToString();//源文件所在的文件夹

                if ( frmOption.DownLoadToHisDir )
                {
                    if ( frmOption.DownloadWithStruct )
                    {
                        string parPath = dirPath;
                        if ( frmOption.IncludeRoot ) //如果包含文件夹,替换路径时不需要包含该文件夹名
                            parPath = ( new DirectoryInfo( dirPath ) ).Parent.FullName;
                        downloadPath = fileFolder.Replace( parPath , ".." );
                        row.Cells[COL_DOWNLOAD_PATH.Name].Value = downloadPath;

                    }
                    else
                    {
                        row.Cells[COL_DOWNLOAD_PATH.Name].Value = "..";
                    }
                }
                else
                {
                    if ( frmOption.DownloadWithStruct )
                    {
                        string parPath = dirPath;
                        if ( frmOption.IncludeRoot )
                            parPath = ( new DirectoryInfo( dirPath ) ).Parent.FullName;
                        downloadPath = fileFolder.Replace( parPath , frmOption.CustomFolder );
                        row.Cells[COL_DOWNLOAD_PATH.Name].Value = downloadPath;

                    }
                    else
                    {
                        row.Cells[COL_DOWNLOAD_PATH.Name].Value = frmOption.CustomFolder;
                    }
                }
            }
        }

        private void AddSourceFile( string filePath ,string dirPath, string downloadPath )
        {
            if ( File.Exists( filePath ) )
            {                
                FileInfo f = new FileInfo( filePath );

                foreach ( DataGridViewRow row in dgvFiles.Rows )
                {
                    if ( row.Cells[COL_FILE_NAME.Name].Value.ToString().ToUpper() == f.Name.ToUpper() )
                        return;
                }

                int rowIndex = dgvFiles.Rows.Add();
                dgvFiles[COL_FILE_NAME.Name , rowIndex].Value = f.Name;
                dgvFiles[COL_FILE_TYPE.Name , rowIndex].Value = f.Extension;
                dgvFiles[COL_CURRENT_VERSION.Name , rowIndex].Value = txtVersion.Text.Trim();
                dgvFiles[COL_SOURCE_PATH.Name , rowIndex].Value = filePath;
                dgvFiles[COL_DOWNLOAD_PATH.Name , rowIndex].Value = downloadPath;              
                dgvFiles[COL_SELECT_FOLDER.Name , rowIndex].Value = dirPath;

            }
        }

        private void dgvFiles_CellContentClick( object sender , DataGridViewCellEventArgs e )
        {
            if ( e.ColumnIndex >= 0 && e.RowIndex >= 0 )
            {
                if ( dgvFiles.Columns[e.ColumnIndex].Name == COL_REPLACE.Name )
                {
                    string temp = dgvFiles[COL_FILE_TYPE.Name , e.RowIndex].Value.ToString();
                    if ( temp.ToUpper() == ".RPT" )
                    {
                        int sel = dgvFiles[COL_REPLACE.Name , e.RowIndex].Value == null ? 0 : Convert.ToInt32( dgvFiles[COL_REPLACE.Name , e.RowIndex].Value );
                        dgvFiles[COL_REPLACE.Name , e.RowIndex].Value = ( sel == 1 ? 0 : 1 );
                    }
                }
            }
        }

        private void btnOpen_Click( object sender , EventArgs e )
        {
            if ( rdByFolder.Checked )
            {
                btnSelectFolder_Click( null , null );
            }
            else if ( rdByFile.Checked )
            {
                btnSelectFile_Click( null , null );
            }
        }


        
    }
}
