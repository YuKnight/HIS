using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using Trasen.Editor;

namespace ClientConfig
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class FrmMain : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.TabControl tbctrlDataSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbServerName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblUser;
        private Trasen.Editor.TextEdit txtPassword;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtProtocol;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.Label lblDataName;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblProtocol;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.RadioButton rbDataSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchPath;
        private System.Windows.Forms.TextBox txtLocalDBPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCustomDirectory;
        private System.Windows.Forms.TabPage tbpgIbmDb2;
        private System.Windows.Forms.TabPage tbpgLocalAccess;
        private System.Windows.Forms.TabPage tbpgSqlServer;
        private System.Windows.Forms.TabPage tbpgOther;
        private Trasen.Editor.TextEdit txtPasswordSql;
        private System.Windows.Forms.TextBox txtUserIDSql;
        private System.Windows.Forms.TextBox txtDatabaseSql;
        private System.Windows.Forms.TextBox txtHostNameSql;
        private System.Windows.Forms.Label lblDataNamesql;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSqlType;
        private System.Windows.Forms.ListBox lstDb2Type;
        private System.Windows.Forms.Button btAddSql;
        private System.Windows.Forms.Button btDelSql;
        private System.Windows.Forms.Button btDelDb2;
        private System.Windows.Forms.Button btAddDb2;
        private System.Windows.Forms.Button btColse;
        private System.Windows.Forms.Label lblSqlType;
        private System.Windows.Forms.Label lblDb2Type;
        private System.Windows.Forms.Button btDelAccess;
        private System.Windows.Forms.Button btAddAccess;
        private System.Windows.Forms.ListBox lstAccessType;
        private System.Windows.Forms.Label lblAccessType;
        private System.Windows.Forms.TabPage tbpgOracle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btDelOracle;
        private System.Windows.Forms.Button btAddOracle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Trasen.Editor.TextEdit txtPasswordOracle;
        private System.Windows.Forms.TextBox txtUserIDOracle;
        private System.Windows.Forms.TextBox txtDataSourceOracle;
        private System.Windows.Forms.ListBox lstOracleType;
        private System.Windows.Forms.Button btnSetServer;
        private Label label8;
        private Label lblCurrentServer;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;


        private bool _IsDebugVersion = false;

        public FrmMain()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btColse = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.tbctrlDataSource = new System.Windows.Forms.TabControl();
            this.tbpgSqlServer = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCurrentServer = new System.Windows.Forms.Label();
            this.btDelSql = new System.Windows.Forms.Button();
            this.btAddSql = new System.Windows.Forms.Button();
            this.lstSqlType = new System.Windows.Forms.ListBox();
            this.lblSqlType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPasswordSql = new Trasen.Editor.TextEdit();
            this.txtUserIDSql = new System.Windows.Forms.TextBox();
            this.txtDatabaseSql = new System.Windows.Forms.TextBox();
            this.txtHostNameSql = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbpgIbmDb2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btDelDb2 = new System.Windows.Forms.Button();
            this.btAddDb2 = new System.Windows.Forms.Button();
            this.lstDb2Type = new System.Windows.Forms.ListBox();
            this.lblDb2Type = new System.Windows.Forms.Label();
            this.rbServerName = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtPassword = new Trasen.Editor.TextEdit();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtProtocol = new System.Windows.Forms.TextBox();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.lblDataName = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.rbDataSource = new System.Windows.Forms.RadioButton();
            this.tbpgLocalAccess = new System.Windows.Forms.TabPage();
            this.btDelAccess = new System.Windows.Forms.Button();
            this.btAddAccess = new System.Windows.Forms.Button();
            this.lstAccessType = new System.Windows.Forms.ListBox();
            this.lblAccessType = new System.Windows.Forms.Label();
            this.btnSearchPath = new System.Windows.Forms.Button();
            this.txtLocalDBPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbpgOracle = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPasswordOracle = new Trasen.Editor.TextEdit();
            this.txtUserIDOracle = new System.Windows.Forms.TextBox();
            this.txtDataSourceOracle = new System.Windows.Forms.TextBox();
            this.btDelOracle = new System.Windows.Forms.Button();
            this.btAddOracle = new System.Windows.Forms.Button();
            this.lstOracleType = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbpgOther = new System.Windows.Forms.TabPage();
            this.txtCustomDirectory = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblDataNamesql = new System.Windows.Forms.Label();
            this.btnSetServer = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbctrlDataSource.SuspendLayout();
            this.tbpgSqlServer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tbpgIbmDb2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbpgLocalAccess.SuspendLayout();
            this.tbpgOracle.SuspendLayout();
            this.tbpgOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // btColse
            // 
            this.btColse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btColse.Location = new System.Drawing.Point(394, 308);
            this.btColse.Name = "btColse";
            this.btColse.Size = new System.Drawing.Size(75, 26);
            this.btColse.TabIndex = 1;
            this.btColse.Text = "关闭(&C)";
            this.btColse.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btOK
            // 
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOK.Location = new System.Drawing.Point(290, 308);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 26);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "保存(&O)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btTest
            // 
            this.btTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btTest.Location = new System.Drawing.Point(170, 308);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(90, 26);
            this.btTest.TabIndex = 16;
            this.btTest.Text = "测试连接(&T)";
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // tbctrlDataSource
            // 
            this.tbctrlDataSource.Controls.Add(this.tbpgSqlServer);
            this.tbctrlDataSource.Controls.Add(this.tbpgIbmDb2);
            this.tbctrlDataSource.Controls.Add(this.tbpgLocalAccess);
            this.tbctrlDataSource.Controls.Add(this.tbpgOracle);
            this.tbctrlDataSource.Controls.Add(this.tbpgOther);
            this.tbctrlDataSource.Location = new System.Drawing.Point(0, 5);
            this.tbctrlDataSource.Name = "tbctrlDataSource";
            this.tbctrlDataSource.SelectedIndex = 0;
            this.tbctrlDataSource.Size = new System.Drawing.Size(504, 264);
            this.tbctrlDataSource.TabIndex = 17;
            // 
            // tbpgSqlServer
            // 
            this.tbpgSqlServer.Controls.Add(this.groupBox3);
            this.tbpgSqlServer.Location = new System.Drawing.Point(4, 21);
            this.tbpgSqlServer.Name = "tbpgSqlServer";
            this.tbpgSqlServer.Size = new System.Drawing.Size(496, 239);
            this.tbpgSqlServer.TabIndex = 3;
            this.tbpgSqlServer.Tag = "0";
            this.tbpgSqlServer.Text = "SQL SERVER";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCurrentServer);
            this.groupBox3.Controls.Add(this.btDelSql);
            this.groupBox3.Controls.Add(this.btAddSql);
            this.groupBox3.Controls.Add(this.lstSqlType);
            this.groupBox3.Controls.Add(this.lblSqlType);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtPasswordSql);
            this.groupBox3.Controls.Add(this.txtUserIDSql);
            this.groupBox3.Controls.Add(this.txtDatabaseSql);
            this.groupBox3.Controls.Add(this.txtHostNameSql);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(496, 239);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // lblCurrentServer
            // 
            this.lblCurrentServer.AutoSize = true;
            this.lblCurrentServer.Location = new System.Drawing.Point(89, 20);
            this.lblCurrentServer.Name = "lblCurrentServer";
            this.lblCurrentServer.Size = new System.Drawing.Size(0, 12);
            this.lblCurrentServer.TabIndex = 52;
            // 
            // btDelSql
            // 
            this.btDelSql.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDelSql.Location = new System.Drawing.Point(82, 199);
            this.btDelSql.Name = "btDelSql";
            this.btDelSql.Size = new System.Drawing.Size(50, 23);
            this.btDelSql.TabIndex = 51;
            this.btDelSql.Text = "删除";
            this.btDelSql.Click += new System.EventHandler(this.btDelSql_Click);
            // 
            // btAddSql
            // 
            this.btAddSql.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAddSql.Location = new System.Drawing.Point(10, 199);
            this.btAddSql.Name = "btAddSql";
            this.btAddSql.Size = new System.Drawing.Size(50, 23);
            this.btAddSql.TabIndex = 50;
            this.btAddSql.Text = "添加";
            this.btAddSql.Click += new System.EventHandler(this.btAddSql_Click);
            // 
            // lstSqlType
            // 
            this.lstSqlType.ItemHeight = 12;
            this.lstSqlType.Location = new System.Drawing.Point(10, 48);
            this.lstSqlType.Name = "lstSqlType";
            this.lstSqlType.Size = new System.Drawing.Size(120, 148);
            this.lstSqlType.TabIndex = 49;
            this.lstSqlType.SelectedIndexChanged += new System.EventHandler(this.lstSqlType_SelectedIndexChanged);
            // 
            // lblSqlType
            // 
            this.lblSqlType.AutoSize = true;
            this.lblSqlType.Location = new System.Drawing.Point(10, 20);
            this.lblSqlType.Name = "lblSqlType";
            this.lblSqlType.Size = new System.Drawing.Size(65, 12);
            this.lblSqlType.TabIndex = 48;
            this.lblSqlType.Text = "服务器类别";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "数据库名：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "登录密码：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(148, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 45;
            this.label11.Text = "登录用户：";
            // 
            // txtPasswordSql
            // 
            this.txtPasswordSql.Location = new System.Drawing.Point(276, 162);
            this.txtPasswordSql.Name = "txtPasswordSql";
            this.txtPasswordSql.PasswordChar = '*';
            this.txtPasswordSql.PassWordInput = true;
            this.txtPasswordSql.Size = new System.Drawing.Size(210, 21);
            this.txtPasswordSql.TabIndex = 44;
            // 
            // txtUserIDSql
            // 
            this.txtUserIDSql.Location = new System.Drawing.Point(276, 126);
            this.txtUserIDSql.Name = "txtUserIDSql";
            this.txtUserIDSql.Size = new System.Drawing.Size(210, 21);
            this.txtUserIDSql.TabIndex = 43;
            // 
            // txtDatabaseSql
            // 
            this.txtDatabaseSql.Location = new System.Drawing.Point(276, 90);
            this.txtDatabaseSql.Name = "txtDatabaseSql";
            this.txtDatabaseSql.Size = new System.Drawing.Size(210, 21);
            this.txtDatabaseSql.TabIndex = 42;
            // 
            // txtHostNameSql
            // 
            this.txtHostNameSql.Location = new System.Drawing.Point(276, 56);
            this.txtHostNameSql.Name = "txtHostNameSql";
            this.txtHostNameSql.Size = new System.Drawing.Size(210, 21);
            this.txtHostNameSql.TabIndex = 39;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(148, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 12);
            this.label15.TabIndex = 35;
            this.label15.Text = "服务器名称（或IP）：";
            // 
            // tbpgIbmDb2
            // 
            this.tbpgIbmDb2.Controls.Add(this.groupBox1);
            this.tbpgIbmDb2.Location = new System.Drawing.Point(4, 21);
            this.tbpgIbmDb2.Name = "tbpgIbmDb2";
            this.tbpgIbmDb2.Size = new System.Drawing.Size(496, 239);
            this.tbpgIbmDb2.TabIndex = 0;
            this.tbpgIbmDb2.Tag = "1";
            this.tbpgIbmDb2.Text = "IBM DB2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btDelDb2);
            this.groupBox1.Controls.Add(this.btAddDb2);
            this.groupBox1.Controls.Add(this.lstDb2Type);
            this.groupBox1.Controls.Add(this.lblDb2Type);
            this.groupBox1.Controls.Add(this.rbServerName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblPwd);
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUserID);
            this.groupBox1.Controls.Add(this.txtDatabase);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtProtocol);
            this.groupBox1.Controls.Add(this.txtHostName);
            this.groupBox1.Controls.Add(this.lblDataName);
            this.groupBox1.Controls.Add(this.lblPort);
            this.groupBox1.Controls.Add(this.lblProtocol);
            this.groupBox1.Controls.Add(this.lblServerName);
            this.groupBox1.Controls.Add(this.rbDataSource);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btDelDb2
            // 
            this.btDelDb2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDelDb2.Location = new System.Drawing.Point(82, 198);
            this.btDelDb2.Name = "btDelDb2";
            this.btDelDb2.Size = new System.Drawing.Size(50, 23);
            this.btDelDb2.TabIndex = 53;
            this.btDelDb2.Text = "删除";
            this.btDelDb2.Click += new System.EventHandler(this.btDelDb2_Click);
            // 
            // btAddDb2
            // 
            this.btAddDb2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAddDb2.Location = new System.Drawing.Point(10, 198);
            this.btAddDb2.Name = "btAddDb2";
            this.btAddDb2.Size = new System.Drawing.Size(50, 23);
            this.btAddDb2.TabIndex = 52;
            this.btAddDb2.Text = "添加";
            this.btAddDb2.Click += new System.EventHandler(this.btAddDb2_Click);
            // 
            // lstDb2Type
            // 
            this.lstDb2Type.ItemHeight = 12;
            this.lstDb2Type.Location = new System.Drawing.Point(10, 48);
            this.lstDb2Type.Name = "lstDb2Type";
            this.lstDb2Type.Size = new System.Drawing.Size(120, 148);
            this.lstDb2Type.TabIndex = 51;
            this.lstDb2Type.SelectedIndexChanged += new System.EventHandler(this.lstDb2Type_SelectedIndexChanged);
            // 
            // lblDb2Type
            // 
            this.lblDb2Type.AutoSize = true;
            this.lblDb2Type.Location = new System.Drawing.Point(10, 20);
            this.lblDb2Type.Name = "lblDb2Type";
            this.lblDb2Type.Size = new System.Drawing.Size(65, 12);
            this.lblDb2Type.TabIndex = 50;
            this.lblDb2Type.Text = "服务器类别";
            // 
            // rbServerName
            // 
            this.rbServerName.Checked = true;
            this.rbServerName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbServerName.Location = new System.Drawing.Point(276, 11);
            this.rbServerName.Name = "rbServerName";
            this.rbServerName.Size = new System.Drawing.Size(112, 24);
            this.rbServerName.TabIndex = 49;
            this.rbServerName.TabStop = true;
            this.rbServerName.Text = "直接服务器连接";
            this.rbServerName.CheckedChanged += new System.EventHandler(this.rbServerName_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 47;
            this.label7.Text = "连接类型：";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(148, 204);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(65, 12);
            this.lblPwd.TabIndex = 46;
            this.lblPwd.Text = "登录密码：";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(148, 171);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(65, 12);
            this.lblUser.TabIndex = 45;
            this.lblUser.Text = "登录用户：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(276, 201);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PassWordInput = true;
            this.txtPassword.Size = new System.Drawing.Size(210, 21);
            this.txtPassword.TabIndex = 44;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(276, 168);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(210, 21);
            this.txtUserID.TabIndex = 43;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(276, 134);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(210, 21);
            this.txtDatabase.TabIndex = 42;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(276, 103);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(210, 21);
            this.txtPort.TabIndex = 41;
            // 
            // txtProtocol
            // 
            this.txtProtocol.Location = new System.Drawing.Point(276, 73);
            this.txtProtocol.Name = "txtProtocol";
            this.txtProtocol.Size = new System.Drawing.Size(210, 21);
            this.txtProtocol.TabIndex = 40;
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(276, 41);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(210, 21);
            this.txtHostName.TabIndex = 39;
            // 
            // lblDataName
            // 
            this.lblDataName.AutoSize = true;
            this.lblDataName.Location = new System.Drawing.Point(148, 136);
            this.lblDataName.Name = "lblDataName";
            this.lblDataName.Size = new System.Drawing.Size(65, 12);
            this.lblDataName.TabIndex = 38;
            this.lblDataName.Text = "数据库名：";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(148, 105);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(41, 12);
            this.lblPort.TabIndex = 37;
            this.lblPort.Text = "端口：";
            // 
            // lblProtocol
            // 
            this.lblProtocol.AutoSize = true;
            this.lblProtocol.Location = new System.Drawing.Point(148, 75);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(41, 12);
            this.lblProtocol.TabIndex = 36;
            this.lblProtocol.Text = "协议：";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(148, 42);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(125, 12);
            this.lblServerName.TabIndex = 35;
            this.lblServerName.Text = "服务器名称（或IP）：";
            // 
            // rbDataSource
            // 
            this.rbDataSource.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbDataSource.Location = new System.Drawing.Point(398, 11);
            this.rbDataSource.Name = "rbDataSource";
            this.rbDataSource.Size = new System.Drawing.Size(88, 24);
            this.rbDataSource.TabIndex = 48;
            this.rbDataSource.Text = "数据源连接";
            // 
            // tbpgLocalAccess
            // 
            this.tbpgLocalAccess.Controls.Add(this.btDelAccess);
            this.tbpgLocalAccess.Controls.Add(this.btAddAccess);
            this.tbpgLocalAccess.Controls.Add(this.lstAccessType);
            this.tbpgLocalAccess.Controls.Add(this.lblAccessType);
            this.tbpgLocalAccess.Controls.Add(this.btnSearchPath);
            this.tbpgLocalAccess.Controls.Add(this.txtLocalDBPath);
            this.tbpgLocalAccess.Controls.Add(this.label2);
            this.tbpgLocalAccess.Location = new System.Drawing.Point(4, 21);
            this.tbpgLocalAccess.Name = "tbpgLocalAccess";
            this.tbpgLocalAccess.Size = new System.Drawing.Size(496, 239);
            this.tbpgLocalAccess.TabIndex = 1;
            this.tbpgLocalAccess.Tag = "2";
            this.tbpgLocalAccess.Text = "本地ACCESS";
            // 
            // btDelAccess
            // 
            this.btDelAccess.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDelAccess.Location = new System.Drawing.Point(82, 198);
            this.btDelAccess.Name = "btDelAccess";
            this.btDelAccess.Size = new System.Drawing.Size(50, 23);
            this.btDelAccess.TabIndex = 57;
            this.btDelAccess.Text = "删除";
            this.btDelAccess.Click += new System.EventHandler(this.btDelAccess_Click);
            // 
            // btAddAccess
            // 
            this.btAddAccess.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAddAccess.Location = new System.Drawing.Point(10, 198);
            this.btAddAccess.Name = "btAddAccess";
            this.btAddAccess.Size = new System.Drawing.Size(50, 23);
            this.btAddAccess.TabIndex = 56;
            this.btAddAccess.Text = "添加";
            this.btAddAccess.Click += new System.EventHandler(this.btAddAccess_Click);
            // 
            // lstAccessType
            // 
            this.lstAccessType.ItemHeight = 12;
            this.lstAccessType.Location = new System.Drawing.Point(10, 48);
            this.lstAccessType.Name = "lstAccessType";
            this.lstAccessType.Size = new System.Drawing.Size(120, 148);
            this.lstAccessType.TabIndex = 55;
            this.lstAccessType.SelectedIndexChanged += new System.EventHandler(this.lstAccessType_SelectedIndexChanged);
            // 
            // lblAccessType
            // 
            this.lblAccessType.AutoSize = true;
            this.lblAccessType.Location = new System.Drawing.Point(10, 20);
            this.lblAccessType.Name = "lblAccessType";
            this.lblAccessType.Size = new System.Drawing.Size(65, 12);
            this.lblAccessType.TabIndex = 54;
            this.lblAccessType.Text = "服务器类别";
            // 
            // btnSearchPath
            // 
            this.btnSearchPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchPath.Location = new System.Drawing.Point(468, 48);
            this.btnSearchPath.Name = "btnSearchPath";
            this.btnSearchPath.Size = new System.Drawing.Size(22, 20);
            this.btnSearchPath.TabIndex = 2;
            this.btnSearchPath.Text = "…";
            this.btnSearchPath.Click += new System.EventHandler(this.btnSearchPath_Click);
            // 
            // txtLocalDBPath
            // 
            this.txtLocalDBPath.Location = new System.Drawing.Point(134, 48);
            this.txtLocalDBPath.Name = "txtLocalDBPath";
            this.txtLocalDBPath.Size = new System.Drawing.Size(333, 21);
            this.txtLocalDBPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "本机数据库路径：";
            // 
            // tbpgOracle
            // 
            this.tbpgOracle.Controls.Add(this.label4);
            this.tbpgOracle.Controls.Add(this.label5);
            this.tbpgOracle.Controls.Add(this.label6);
            this.tbpgOracle.Controls.Add(this.txtPasswordOracle);
            this.tbpgOracle.Controls.Add(this.txtUserIDOracle);
            this.tbpgOracle.Controls.Add(this.txtDataSourceOracle);
            this.tbpgOracle.Controls.Add(this.btDelOracle);
            this.tbpgOracle.Controls.Add(this.btAddOracle);
            this.tbpgOracle.Controls.Add(this.lstOracleType);
            this.tbpgOracle.Controls.Add(this.label3);
            this.tbpgOracle.Location = new System.Drawing.Point(4, 21);
            this.tbpgOracle.Name = "tbpgOracle";
            this.tbpgOracle.Size = new System.Drawing.Size(496, 239);
            this.tbpgOracle.TabIndex = 6;
            this.tbpgOracle.Tag = "3";
            this.tbpgOracle.Text = "ORACLE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 63;
            this.label4.Text = "数据源名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 62;
            this.label5.Text = "登录密码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 61;
            this.label6.Text = "登录用户：";
            // 
            // txtPasswordOracle
            // 
            this.txtPasswordOracle.Location = new System.Drawing.Point(276, 146);
            this.txtPasswordOracle.Name = "txtPasswordOracle";
            this.txtPasswordOracle.PasswordChar = '*';
            this.txtPasswordOracle.PassWordInput = true;
            this.txtPasswordOracle.Size = new System.Drawing.Size(210, 21);
            this.txtPasswordOracle.TabIndex = 60;
            // 
            // txtUserIDOracle
            // 
            this.txtUserIDOracle.Location = new System.Drawing.Point(276, 110);
            this.txtUserIDOracle.Name = "txtUserIDOracle";
            this.txtUserIDOracle.Size = new System.Drawing.Size(210, 21);
            this.txtUserIDOracle.TabIndex = 59;
            // 
            // txtDataSourceOracle
            // 
            this.txtDataSourceOracle.Location = new System.Drawing.Point(276, 74);
            this.txtDataSourceOracle.Name = "txtDataSourceOracle";
            this.txtDataSourceOracle.Size = new System.Drawing.Size(210, 21);
            this.txtDataSourceOracle.TabIndex = 58;
            // 
            // btDelOracle
            // 
            this.btDelOracle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDelOracle.Location = new System.Drawing.Point(81, 197);
            this.btDelOracle.Name = "btDelOracle";
            this.btDelOracle.Size = new System.Drawing.Size(50, 23);
            this.btDelOracle.TabIndex = 57;
            this.btDelOracle.Text = "删除";
            this.btDelOracle.Click += new System.EventHandler(this.btDelOracle_Click);
            // 
            // btAddOracle
            // 
            this.btAddOracle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAddOracle.Location = new System.Drawing.Point(10, 197);
            this.btAddOracle.Name = "btAddOracle";
            this.btAddOracle.Size = new System.Drawing.Size(50, 23);
            this.btAddOracle.TabIndex = 56;
            this.btAddOracle.Text = "添加";
            this.btAddOracle.Click += new System.EventHandler(this.btAddOracle_Click);
            // 
            // lstOracleType
            // 
            this.lstOracleType.ItemHeight = 12;
            this.lstOracleType.Location = new System.Drawing.Point(10, 47);
            this.lstOracleType.Name = "lstOracleType";
            this.lstOracleType.Size = new System.Drawing.Size(120, 148);
            this.lstOracleType.TabIndex = 55;
            this.lstOracleType.SelectedIndexChanged += new System.EventHandler(this.lstOracleType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "服务器类别";
            // 
            // tbpgOther
            // 
            this.tbpgOther.Controls.Add(this.txtCustomDirectory);
            this.tbpgOther.Controls.Add(this.label14);
            this.tbpgOther.Location = new System.Drawing.Point(4, 21);
            this.tbpgOther.Name = "tbpgOther";
            this.tbpgOther.Size = new System.Drawing.Size(496, 239);
            this.tbpgOther.TabIndex = 5;
            this.tbpgOther.Tag = "4";
            this.tbpgOther.Text = "其他配置";
            // 
            // txtCustomDirectory
            // 
            this.txtCustomDirectory.Location = new System.Drawing.Point(6, 36);
            this.txtCustomDirectory.Name = "txtCustomDirectory";
            this.txtCustomDirectory.Size = new System.Drawing.Size(402, 21);
            this.txtCustomDirectory.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "客户端自定义路径：";
            // 
            // lblDataNamesql
            // 
            this.lblDataNamesql.Location = new System.Drawing.Point(0, 0);
            this.lblDataNamesql.Name = "lblDataNamesql";
            this.lblDataNamesql.Size = new System.Drawing.Size(100, 23);
            this.lblDataNamesql.TabIndex = 0;
            // 
            // btnSetServer
            // 
            this.btnSetServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetServer.Location = new System.Drawing.Point(26, 308);
            this.btnSetServer.Name = "btnSetServer";
            this.btnSetServer.Size = new System.Drawing.Size(112, 26);
            this.btnSetServer.TabIndex = 18;
            this.btnSetServer.Text = "设置为当前服务器";
            this.btnSetServer.Click += new System.EventHandler(this.btnSetServer_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(12, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(485, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "注意：LIS和PACS服务器的连接名称必须是“LIS”和“PACS”，其它连接请不要使用该名称";
            // 
            // FrmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(506, 351);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSetServer);
            this.Controls.Add(this.tbctrlDataSource);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.btColse);
            this.Controls.Add(this.btOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户端配置";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tbctrlDataSource.ResumeLayout(false);
            this.tbpgSqlServer.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tbpgIbmDb2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbpgLocalAccess.ResumeLayout(false);
            this.tbpgLocalAccess.PerformLayout();
            this.tbpgOracle.ResumeLayout(false);
            this.tbpgOracle.PerformLayout();
            this.tbpgOther.ResumeLayout(false);
            this.tbpgOther.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new FrmMain());
        }
        #region 方法
        /// <summary>
        /// 获取INI信息
        /// </summary>
        /// <param name="type">类型0、SQL SERVER 1、IBM DB2</param>
        /// <param name="applicationName">INI文件中段(SECTION)名称</param>
        private void GetIniInformation(int type, string applicationName)
        {
            string strCnnType = "";
            switch (type)
            {
                case 0:		//SQL SERVER
                    txtHostNameSql.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "HOSTNAME", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtHostNameSql.Tag = txtHostNameSql.Text;
                    txtDatabaseSql.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtUserIDSql.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "USER_ID", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtPasswordSql.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "PASSWORD", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    break;
                case 1:		//IBM DB2
                    txtHostName.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "HOSTNAME", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtHostName.Tag = txtHostName.Text;
                    txtProtocol.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "PROTOCOL", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtProtocol.Tag = txtProtocol.Text;
                    txtPort.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "PORT", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtPort.Tag = txtPort.Text;
                    txtDatabase.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtUserID.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "USER_ID", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtPassword.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "PASSWORD", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    strCnnType = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "CONNECTIONTYPE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    if (strCnnType == "1")
                    {
                        rbDataSource.Checked = true;
                    }
                    break;
                case 2:		//本机ACCESS
                    txtLocalDBPath.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    break;
                case 3:		//SQL SERVER
                    txtDataSourceOracle.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtUserIDOracle.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "USER_ID", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtPasswordOracle.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "PASSWORD", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    break;
                case 4:		//其他设置
                    txtCustomDirectory.Text = Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "DIRECTORY", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                    txtCustomDirectory.Tag = txtCustomDirectory.Text;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 清空信息
        /// </summary>
        /// <param name="type"></param>
        private void ClearInformation(int type)
        {
            switch (type)
            {
                case 0:		//SQL SERVER
                    txtHostNameSql.Text = "";
                    txtHostNameSql.Tag = null;
                    txtDatabaseSql.Text = "";
                    txtUserIDSql.Text = "";
                    txtPasswordSql.Text = "";
                    break;
                case 1:		//IBM DB2
                    txtHostName.Text = "";
                    txtHostName.Tag = null;
                    txtProtocol.Text = "";
                    txtProtocol.Tag = null;
                    txtPort.Text = "";
                    txtPort.Tag = null;
                    txtDatabase.Text = "";
                    txtUserID.Text = "";
                    txtPassword.Text = "";
                    break;
                case 2:		//本机ACCESS
                    txtLocalDBPath.Text = "";
                    break;
                case 3:		//Oracle
                    txtDataSourceOracle.Text = "";
                    txtUserIDOracle.Text = "";
                    txtPasswordOracle.Text = "";
                    break;
                case 4:		//其他设置
                    txtCustomDirectory.Text = "";
                    txtCustomDirectory.Tag = null;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 事件
        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            #region 正式版和调试版的设置,将原来编译时修改改为配置ini
            string strDebug = ApiFunction.GetIniString( "Enviroment" , "IsDebugVersion" , Application.StartupPath + "\\ClientConfig.ini" );
            if ( string.IsNullOrEmpty( strDebug ) )
                ApiFunction.WriteIniString( "Enviroment" , "IsDebugVersion" , "false" , Application.StartupPath + "\\ClientConfig.ini" );
            strDebug = ApiFunction.GetIniString( "Enviroment" , "IsDebugVersion" , Application.StartupPath + "\\ClientConfig.ini" );
            try
            {
                _IsDebugVersion = Convert.ToBoolean( strDebug );
            }
            catch
            {
                _IsDebugVersion = false;
            }
            #endregion

            //获取INI配置信息
            //SQLSERVER服务器类别
            string sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("SQLSERVERTYPE", "TYPE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
            string[] type = sqlType.Split('|');
            Item item = null;
            if (type.Length > 0)
            {
                for (int i = 0; i < type.Length && type[i].Trim() != ""; i++)
                {
                    item = new Item();
                    item.Text = Convert.ToString(i + 1) + "、" + type[i].Trim();
                    item.Value = type[i].Trim();
                    lstSqlType.Items.Add(item);
                }
                if (lstSqlType.Items.Count > 0)
                {
                    lstSqlType.SelectedIndex = 0;
                }
            }
            //IBMDB2服务器类别
            sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("IBMDB2TYPE", "TYPE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
            type = sqlType.Split('|');
            if (type.Length > 0)
            {
                for (int i = 0; i < type.Length && type[i].Trim() != ""; i++)
                {
                    item = new Item();
                    item.Text = Convert.ToString(i + 1) + "、" + type[i].Trim();
                    item.Value = type[i].Trim();
                    lstDb2Type.Items.Add(item);
                }
                if (lstDb2Type.Items.Count > 0)
                {
                    lstDb2Type.SelectedIndex = 0;
                }
            }
            //MSACCESS
            sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("MSACCESSTYPE", "TYPE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
            type = sqlType.Split('|');
            if (type.Length > 0)
            {
                for (int i = 0; i < type.Length && type[i].Trim() != ""; i++)
                {
                    item = new Item();
                    item.Text = Convert.ToString(i + 1) + "、" + type[i].Trim();
                    item.Value = type[i].Trim();
                    lstAccessType.Items.Add(item);
                }
                if (lstAccessType.Items.Count > 0)
                {
                    lstAccessType.SelectedIndex = 0;
                }
            }
            //ORACLE
            sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("ORACLETYPE", "TYPE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
            type = sqlType.Split('|');
            if (type.Length > 0)
            {
                for (int i = 0; i < type.Length && type[i].Trim() != ""; i++)
                {
                    item = new Item();
                    item.Text = Convert.ToString(i + 1) + "、" + type[i].Trim();
                    item.Value = type[i].Trim();
                    lstOracleType.Items.Add(item);
                }
                if (lstOracleType.Items.Count > 0)
                {
                    lstOracleType.SelectedIndex = 0;
                }
            }
            //其他设置
            GetIniInformation(4, "CUSTOMDIRRECTORY");
            item = null;

            //显示当前服务器
            lblCurrentServer.Text = "(当前服务器：" + ApiFunction.GetIniString( "SERVER_NAME" , "NAME" ,  Constant.ApplicationDirectory + "\\ClientConfig.ini" ) + ")";
        }

        private void btClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btOK_Click(object sender, System.EventArgs e)
        {
            //设置数据库连接信息
            //SQL SERVER
            string sqlType = "";
            for (int i = 0; i < lstSqlType.Items.Count; i++)
            {
                if (i == lstSqlType.Items.Count - 1)
                {
                    sqlType += ((Item)lstSqlType.Items[i]).Value.ToString();
                }
                else
                {
                    sqlType += ((Item)lstSqlType.Items[i]).Value.ToString() + "|";
                }
            }
            if (sqlType != "")
            {
                ApiFunction.WriteIniString("SQLSERVERTYPE", "TYPE", Crypto.Instance().Encrypto(sqlType), Constant.ApplicationDirectory + "\\ClientConfig.ini");

                if (Convertor.IsNull(lblSqlType.Tag, "") != "")
                {
                    if ( txtUserIDSql.Text.Trim().ToLower() == "sa" && !_IsDebugVersion )
                    {
                        MessageBox.Show( "“sa”不能使用在客户端的配置中，请改用别的用户名" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        return;
                    }

                    ApiFunction.WriteIniString(lblSqlType.Tag.ToString(), "HOSTNAME", Crypto.Instance().Encrypto(txtHostNameSql.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    ApiFunction.WriteIniString(lblSqlType.Tag.ToString(), "DATASOURCE", Crypto.Instance().Encrypto(txtDatabaseSql.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    ApiFunction.WriteIniString(lblSqlType.Tag.ToString(), "USER_ID", Crypto.Instance().Encrypto(txtUserIDSql.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    ApiFunction.WriteIniString(lblSqlType.Tag.ToString(), "PASSWORD", Crypto.Instance().Encrypto(txtPasswordSql.TextPass.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                }
            }
            //IBM DB2
            sqlType = "";
            for (int i = 0; i < lstDb2Type.Items.Count; i++)
            {
                if (i == lstDb2Type.Items.Count - 1)
                {
                    sqlType += ((Item)lstDb2Type.Items[i]).Value.ToString();
                }
                else
                {
                    sqlType += ((Item)lstDb2Type.Items[i]).Value.ToString() + "|";
                }
            }
            if (sqlType != "")
            {
                ApiFunction.WriteIniString("IBMDB2TYPE", "TYPE", Crypto.Instance().Encrypto(sqlType), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                if (Convertor.IsNull(lblDb2Type.Tag, "") != "")
                {
                    ApiFunction.WriteIniString(lblDb2Type.Tag.ToString(), "HOSTNAME", Crypto.Instance().Encrypto(txtHostName.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    ApiFunction.WriteIniString(lblDb2Type.Tag.ToString(), "PROTOCOL", Crypto.Instance().Encrypto(txtProtocol.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    ApiFunction.WriteIniString(lblDb2Type.Tag.ToString(), "PORT", Crypto.Instance().Encrypto(txtPort.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    ApiFunction.WriteIniString(lblDb2Type.Tag.ToString(), "DATASOURCE", Crypto.Instance().Encrypto(txtDatabase.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    ApiFunction.WriteIniString(lblDb2Type.Tag.ToString(), "USER_ID", Crypto.Instance().Encrypto(txtUserID.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    ApiFunction.WriteIniString(lblDb2Type.Tag.ToString(), "PASSWORD", Crypto.Instance().Encrypto(txtPassword.TextPass.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    ApiFunction.WriteIniString(lblDb2Type.Tag.ToString(), "CONNECTIONTYPE", Crypto.Instance().Encrypto(rbServerName.Checked ? "0" : "1"), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                }
            }
            //本机 ACCESS
            sqlType = "";
            for (int i = 0; i < lstAccessType.Items.Count; i++)
            {
                if (i == lstAccessType.Items.Count - 1)
                {
                    sqlType += ((Item)lstAccessType.Items[i]).Value.ToString();
                }
                else
                {
                    sqlType += ((Item)lstAccessType.Items[i]).Value.ToString() + "|";
                }
            }
            if (sqlType != "")
            {
                ApiFunction.WriteIniString("MSACCESSTYPE", "TYPE", Crypto.Instance().Encrypto(sqlType), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                ApiFunction.WriteIniString(lblAccessType.Tag.ToString(), "DATASOURCE", Crypto.Instance().Encrypto(txtLocalDBPath.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
            }
            //ORACLE
            sqlType = "";
            for (int i = 0; i < lstOracleType.Items.Count; i++)
            {
                if (i == lstOracleType.Items.Count - 1)
                {
                    sqlType += ((Item)lstOracleType.Items[i]).Value.ToString();
                }
                else
                {
                    sqlType += ((Item)lstOracleType.Items[i]).Value.ToString() + "|";
                }
            }
            if (sqlType != "")
            {
                ApiFunction.WriteIniString("ORACLETYPE", "TYPE", Crypto.Instance().Encrypto(sqlType), Constant.ApplicationDirectory + "\\ClientConfig.ini");

                if (Convertor.IsNull(lstOracleType.Tag, "") != "")
                {
                    ApiFunction.WriteIniString(lstOracleType.Tag.ToString(), "DATASOURCE", Crypto.Instance().Encrypto(txtDataSourceOracle.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    ApiFunction.WriteIniString(lstOracleType.Tag.ToString(), "USER_ID", Crypto.Instance().Encrypto(txtUserIDOracle.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    ApiFunction.WriteIniString(lstOracleType.Tag.ToString(), "PASSWORD", Crypto.Instance().Encrypto(txtPasswordOracle.TextPass.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                }
            }
            //其他设置
            if (txtCustomDirectory.Text.Trim() != Convertor.IsNull(txtCustomDirectory.Tag, ""))
            {
                ApiFunction.WriteIniString("CUSTOMDIRRECTORY", "DIRECTORY", Crypto.Instance().Encrypto(txtCustomDirectory.Text.Trim()), Constant.ApplicationDirectory + "\\ClientConfig.ini");
            }

            MessageBox.Show("当前设置保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btTest_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string userId = "";
                string cnnString = "";
                switch (Convert.ToInt32(tbctrlDataSource.SelectedTab.Tag))
                {
                    case 0://SQL SERVER
                        userId = txtUserIDSql.Text;
                        cnnString = @"packet size=4096;user id=" + txtUserIDSql.Text.Trim() + ";password=" + txtPasswordSql.TextPass.Trim() + ";data source=" + txtHostNameSql.Text.Trim() + ";persist security info=True;initial catalog=" + txtDatabaseSql.Text.Trim();
                        break;
                    case 1://IBM DB2
                        userId = txtUserID.Text;
                        if (rbServerName.Checked)
                            cnnString = @"Provider=IBMDADB2;Database=" + txtDatabase.Text.Trim() + ";HostName=" + txtHostName.Text.Trim() + ";Protocol=" + txtProtocol.Text.Trim() + ";Port=" + txtPort.Text.Trim() + ";User ID=" + txtUserID.Text.Trim() + ";Password=" + txtPassword.TextPass.Trim();
                        else
                            cnnString = @"Provider=IBMDADB2.1;User ID=" + txtUserID.Text.Trim() + ";Password=" + txtPassword.TextPass.Trim() + ";Data Source=" + txtDatabase.Text.Trim() + ";Mode=ReadWrite;Extended Properties=";
                        break;
                    case 2://本机登录
                        cnnString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=" + txtLocalDBPath.Text.Trim() + ";Mode=Share Deny None;Jet OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
                        break;
                    case 3://ORACEL
                        userId = txtUserIDOracle.Text;
                        //cnnString=@"Data Source="+txtDataSourceOracle.Text.Trim()+";User Id="+txtUserIDOracle.Text.Trim()+";Password="+txtPasswordOracle.Text.Trim();
                        cnnString = @"Provider=msdaora;Data Source=" + txtDataSourceOracle.Text.Trim() + ";User Id=" + txtUserIDOracle.Text.Trim() + ";Password=" + txtPasswordOracle.TextPass.Trim() + ";";
                        break;
                    default:
                        break;

                }

                if ( userId.ToLower() == "sa" && !_IsDebugVersion )
                {
                    MessageBox.Show( "“sa”不能使用在客户端的配置中，请改用别的用户名" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }

                if (cnnString == "")
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (Convert.ToInt32(tbctrlDataSource.SelectedTab.Tag) == 0)		//SQL SERVER
                {
                    try
                    {
                        //获得连接
                        SqlConnection sqlcnn = new SqlConnection(cnnString);
                        sqlcnn.Open();
                        sqlcnn.Close();
                        sqlcnn.Dispose();
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("数据库连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException err)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("数据库连接失败：\n" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (Convert.ToInt32(tbctrlDataSource.SelectedTab.Tag) == 3)	//ORACLE
                {
                    try
                    {
                        //获得连接
                        //						OracleConnection oraclecnn=new OracleConnection(cnnString);
                        OleDbConnection oraclecnn = new OleDbConnection(cnnString);
                        oraclecnn.Open();
                        oraclecnn.Close();
                        oraclecnn.Dispose();
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("数据库连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (OleDbException err)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("数据库连接失败：\n" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else  //DB2 \ACCESS
                {
                    try
                    {
                        //获得连接
                        OleDbConnection cnn = new OleDbConnection(cnnString);
                        cnn.Open();
                        cnn.Close();
                        cnn.Dispose();
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("数据库连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (OleDbException err)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("数据库连接失败：\n" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception er)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("测试连接失败：\n" + er.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rbServerName_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbServerName.Checked)
            {
                txtHostName.Enabled = true;
                txtHostName.Text = Convert.ToString(txtHostName.Tag);
                txtProtocol.Enabled = true;
                txtProtocol.Text = Convert.ToString(txtProtocol.Tag);
                txtPort.Enabled = true;
                txtPort.Text = Convert.ToString(txtPort.Tag);
                lblDataName.Text = "数据库名：";
            }
            else
            {
                txtHostName.Enabled = false;
                txtHostName.Text = "";
                txtProtocol.Enabled = false;
                txtProtocol.Text = "";
                txtPort.Enabled = false;
                txtPort.Text = "";
                lblDataName.Text = "数据源名：";
            }
        }

        private void btnSearchPath_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Access数据库(*.mdb)|*.mdb";
            f.Title = "请选择数据库文件";
            f.Multiselect = false;
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtLocalDBPath.Text = f.FileName;
            }
        }

        #region 添加删除按钮
        private void btAddSql_Click(object sender, System.EventArgs e)
        {
            string newServer = DlgInputBoxStatic.InputBox("请输入新增服务器的名称：", "新增", "SQLSERVER");
            for (int i = 0; i < lstSqlType.Items.Count; i++)
            {
                if (((Item)lstSqlType.Items[i]).Value.ToString() == newServer)
                {
                    MessageBox.Show("名称重复，请重新添加!", "错误");
                    return;
                }
            }
            if (newServer != null && newServer != "")
            {
                Item item = new Item();
                item.Text = Convert.ToString(lstSqlType.Items.Count + 1) + "、" + newServer;
                item.Value = newServer;
                lstSqlType.Items.Add(item);
                item = null;
                if (lstSqlType.Items.Count == 1)
                {
                    lstSqlType.SelectedIndex = 0;
                }
            }
        }
        private void btDelSql_Click(object sender, System.EventArgs e)
        {
            if (lstSqlType.SelectedItem == null)
            {
                MessageBox.Show("请选择具体项目!", "提示");
            }
            else
            {
                if (MessageBox.Show("确定要删除该项吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ApiFunction.DeleteIniString(((Item)lstSqlType.SelectedItem).Value.ToString(), Constant.ApplicationDirectory + "\\ClientConfig.ini");
                    lstSqlType.Items.Remove(lstSqlType.SelectedItem);
                    if (lstSqlType.Items.Count > 0)
                    {
                        lstSqlType.SelectedIndex = 0;
                    }
                    else
                    {
                        ClearInformation(0);
                    }
                }
            }
        }
        private void btAddDb2_Click(object sender, System.EventArgs e)
        {
            string newServer = DlgInputBoxStatic.InputBox("请输入新增服务器的名称：", "新增", "IBMDB2");
            for (int i = 0; i < lstDb2Type.Items.Count; i++)
            {
                if (((Item)lstDb2Type.Items[i]).Value.ToString() == newServer)
                {
                    MessageBox.Show("名称重复,请重新添加!", "错误");
                    return;
                }
            }
            if (newServer != null && newServer != "")
            {
                Item item = new Item();
                item.Text = Convert.ToString(lstDb2Type.Items.Count + 1) + "、" + newServer;
                item.Value = newServer;
                lstDb2Type.Items.Add(item);
                if (lstDb2Type.Items.Count == 1)
                {
                    lstDb2Type.SelectedIndex = 0;
                }
                item = null;
            }
        }

        private void btDelDb2_Click(object sender, System.EventArgs e)
        {
            if (lstDb2Type.SelectedItem == null)
            {
                MessageBox.Show("请选择具体项目!", "提示");
            }
            else
            {
                if (MessageBox.Show("确定要删除该项吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    lstDb2Type.Items.Remove(lstDb2Type.SelectedItem);
                    if (lstDb2Type.Items.Count > 0)
                    {
                        lstDb2Type.SelectedIndex = 0;
                    }
                    else
                    {
                        ClearInformation(1);
                    }
                }
            }
        }

        private void btAddAccess_Click(object sender, System.EventArgs e)
        {
            string newServer = DlgInputBoxStatic.InputBox("请输入新增服务器的名称：", "新增", "MSACCESS");
            for (int i = 0; i < lstAccessType.Items.Count; i++)
            {
                if (((Item)lstAccessType.Items[i]).Value.ToString() == newServer)
                {
                    MessageBox.Show("名称重复,请重新添加!", "错误");
                    return;
                }
            }
            if (newServer != null && newServer != "")
            {
                Item item = new Item();
                item.Text = Convert.ToString(lstAccessType.Items.Count + 1) + "、" + newServer;
                item.Value = newServer;
                lstAccessType.Items.Add(item);
                if (lstAccessType.Items.Count == 1)
                {
                    lstAccessType.SelectedIndex = 0;
                }
                item = null;
            }
        }

        private void btDelAccess_Click(object sender, System.EventArgs e)
        {
            if (lstAccessType.SelectedItem == null)
            {
                MessageBox.Show("请选择具体项目!", "提示");
            }
            else
            {
                if (MessageBox.Show("确定要删除该项吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    lstAccessType.Items.Remove(lstAccessType.SelectedItem);
                    if (lstAccessType.Items.Count > 0)
                    {
                        lstAccessType.SelectedIndex = 0;
                    }
                    else
                    {
                        ClearInformation(2);
                    }
                }
            }
        }
        private void btAddOracle_Click(object sender, System.EventArgs e)
        {
            string newServer = DlgInputBoxStatic.InputBox("请输入新增服务器的名称：", "新增", "ORACLE");
            for (int i = 0; i < lstOracleType.Items.Count; i++)
            {
                if (((Item)lstOracleType.Items[i]).Value.ToString() == newServer)
                {
                    MessageBox.Show("名称重复，请重新添加!", "错误");
                    return;
                }
            }
            if (newServer != null && newServer != "")
            {
                Item item = new Item();
                item.Text = Convert.ToString(lstOracleType.Items.Count + 1) + "、" + newServer;
                item.Value = newServer;
                lstOracleType.Items.Add(item);
                if (lstOracleType.Items.Count == 1)
                {
                    lstOracleType.SelectedIndex = 0;
                }
                item = null;
            }
        }

        private void btDelOracle_Click(object sender, System.EventArgs e)
        {
            if (lstOracleType.SelectedItem == null)
            {
                MessageBox.Show("请选择具体项目!", "提示");
            }
            else
            {
                if (MessageBox.Show("确定要删除该项吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    lstOracleType.Items.Remove(lstOracleType.SelectedItem);
                    if (lstOracleType.Items.Count > 0)
                    {
                        lstOracleType.SelectedIndex = 0;
                    }
                    else
                    {
                        ClearInformation(3);
                    }
                }
            }
        }
        #endregion

        #region 服务器类别列表框
        private void lstDb2Type_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lstDb2Type.SelectedItem != null)
            {
                lblDb2Type.Tag = ((Item)lstDb2Type.SelectedItem).Value.ToString();
                GetIniInformation(1, lblDb2Type.Tag.ToString());
            }
        }

        private void lstSqlType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lstSqlType.SelectedItem != null)
            {
                lblSqlType.Tag = ((Item)lstSqlType.SelectedItem).Value.ToString();
                GetIniInformation(0, lblSqlType.Tag.ToString());
            }
        }

        private void lstAccessType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lstAccessType.SelectedItem != null)
            {
                lblAccessType.Tag = ((Item)lstAccessType.SelectedItem).Value.ToString();
                GetIniInformation(2, lblAccessType.Tag.ToString());
            }
        }
        private void lstOracleType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lstOracleType.SelectedItem != null)
            {
                lstOracleType.Tag = ((Item)lstOracleType.SelectedItem).Value.ToString();
                GetIniInformation(3, lstOracleType.Tag.ToString());
            }
        }
        #endregion

        private void btnSetServer_Click(object sender, System.EventArgs e)
        {
            string server_name = "";
            int start = 0;
            int len = 0;
            switch (Convert.ToInt32(tbctrlDataSource.SelectedTab.Tag))
            {
                case 0://SQL SERVER
                    server_name = lstSqlType.SelectedItem.ToString();
                    start = server_name.IndexOf("、") + 1;
                    len = server_name.Length - start;
                    server_name = server_name.Substring(start, len);
                    break;
                case 1://IBM DB2
                    server_name = lstDb2Type.SelectedItem.ToString();
                    start = server_name.IndexOf("、") + 1;
                    len = server_name.Length - start;
                    server_name = server_name.Substring(start, len);
                    break;
                case 2://本机登录
                    break;
                case 3://ORACEL
                    server_name = lstOracleType.SelectedItem.ToString();
                    start = server_name.IndexOf("、") + 1;
                    len = server_name.Length - start;
                    server_name = server_name.Substring(start, len);
                    break;
                default:
                    break;

            }
            ApiFunction.WriteIniString("SERVER_NAME", "NAME", server_name, Constant.ApplicationDirectory + "\\ClientConfig.ini");
            //显示当前服务器
            lblCurrentServer.Text = "(当前服务器：" + ApiFunction.GetIniString( "SERVER_NAME" , "NAME" , Constant.ApplicationDirectory + "\\ClientConfig.ini" ) + ")";
        }

        #endregion


    }
}