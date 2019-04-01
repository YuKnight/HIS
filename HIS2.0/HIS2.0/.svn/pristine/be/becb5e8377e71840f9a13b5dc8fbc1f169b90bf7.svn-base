using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using Ts_zyys_public;
using ts_mz_class;
using ClsWsMzTy;

namespace ts_yf_mzty
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class Frmmzty : System.Windows.Forms.Form
    {
        private string _Fyckh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridTextBoxColumn XH;
        private System.Windows.Forms.DataGridTextBoxColumn fph;
        private System.Windows.Forms.DataGridTextBoxColumn je;
        private System.Windows.Forms.DataGridTextBoxColumn xm;
        private System.Windows.Forms.DataGridTextBoxColumn brxm;
        private System.Windows.Forms.DataGridTextBoxColumn SFRQ;
        private System.Windows.Forms.DataGridTextBoxColumn sfy;
        private System.Windows.Forms.DataGridTextBoxColumn PYR;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid2;
        private System.Windows.Forms.ComboBox cmbpyr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rdoytycf;
        private System.Windows.Forms.RadioButton rdoytywtfcf;
        private System.Windows.Forms.RadioButton rdodtycf;
        private System.Windows.Forms.RadioButton rdoall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Button butfy;
        private System.Windows.Forms.ComboBox cmbph;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Button butqxfy;
        private System.Windows.Forms.Button butquit;
        //private decimal _zje=0;
        private Guid _fyid = Guid.Empty;
        private System.Windows.Forms.CheckBox chkprrintView;
        private System.Windows.Forms.Button buttjs;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.CheckBox chkxp;
        private System.Windows.Forms.Label lblzd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblks;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblnl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblxb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblxm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtfph;
        private System.Windows.Forms.Label label4;
        private YpConfig s;
        private ComboBox cmbklx;
        private TextBox txttmk;
        private Label label5;
        private TextBox txtlsh;
        private Label label6;
        private TextBox txtmzh;
        private Label label8;
        private SystemCfg cfg8025 = new SystemCfg( 8025 );
        private SystemCfg cfg8001 = new SystemCfg( 8001 );
        private bool bpcgl = true; //是否进行批次管理

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frmmzty( MenuTag menuTag , string chineseName , Form mdiParent )
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName.Trim();
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            s = new YpConfig( InstanceForm.BCurrentDept.DeptId , InstanceForm.BDatabase );
            if ( s.门诊发药和退药时默认打印小票 == true )
                this.chkxp.Checked = true;
            else
                this.chkxp.Checked = false;

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( components != null )
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
            this.XH = new System.Windows.Forms.DataGridTextBoxColumn();
            this.fph = new System.Windows.Forms.DataGridTextBoxColumn();
            this.je = new System.Windows.Forms.DataGridTextBoxColumn();
            this.xm = new System.Windows.Forms.DataGridTextBoxColumn();
            this.brxm = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SFRQ = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sfy = new System.Windows.Forms.DataGridTextBoxColumn();
            this.PYR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtmzh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtlsh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbklx = new System.Windows.Forms.ComboBox();
            this.txttmk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblzd = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblks = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblnl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblxb = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblxm = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtfph = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoytywtfcf = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoytycf = new System.Windows.Forms.RadioButton();
            this.rdodtycf = new System.Windows.Forms.RadioButton();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttjs = new System.Windows.Forms.Button();
            this.cmbph = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkxp = new System.Windows.Forms.CheckBox();
            this.chkprrintView = new System.Windows.Forms.CheckBox();
            this.butqxfy = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.butfy = new System.Windows.Forms.Button();
            this.cmbpyr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid1 ) ).BeginInit();
            this.panel3.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid2 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel2 ) ).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // XH
            // 
            this.XH.Format = "";
            this.XH.FormatInfo = null;
            this.XH.HeaderText = "序号";
            this.XH.NullText = "";
            this.XH.ReadOnly = true;
            this.XH.Width = 50;
            // 
            // fph
            // 
            this.fph.Format = "";
            this.fph.FormatInfo = null;
            this.fph.HeaderText = "发票号";
            this.fph.NullText = "";
            this.fph.ReadOnly = true;
            this.fph.Width = 60;
            // 
            // je
            // 
            this.je.Format = "";
            this.je.FormatInfo = null;
            this.je.HeaderText = "金额";
            this.je.NullText = "";
            this.je.ReadOnly = true;
            this.je.Width = 60;
            // 
            // xm
            // 
            this.xm.Format = "";
            this.xm.FormatInfo = null;
            this.xm.HeaderText = "项目";
            this.xm.NullText = "";
            this.xm.ReadOnly = true;
            this.xm.Width = 0;
            // 
            // brxm
            // 
            this.brxm.Format = "";
            this.brxm.FormatInfo = null;
            this.brxm.HeaderText = "姓名";
            this.brxm.NullText = "";
            this.brxm.ReadOnly = true;
            this.brxm.Width = 60;
            // 
            // SFRQ
            // 
            this.SFRQ.Format = "";
            this.SFRQ.FormatInfo = null;
            this.SFRQ.HeaderText = "收费日期";
            this.SFRQ.NullText = "";
            this.SFRQ.ReadOnly = true;
            this.SFRQ.Width = 70;
            // 
            // sfy
            // 
            this.sfy.Format = "";
            this.sfy.FormatInfo = null;
            this.sfy.HeaderText = "收费员";
            this.sfy.NullText = "";
            this.sfy.ReadOnly = true;
            this.sfy.Width = 50;
            // 
            // PYR
            // 
            this.PYR.Format = "";
            this.PYR.FormatInfo = null;
            this.PYR.HeaderText = "配药人";
            this.PYR.NullText = "";
            this.PYR.ReadOnly = true;
            this.PYR.Width = 50;
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.txtmzh );
            this.panel1.Controls.Add( this.label8 );
            this.panel1.Controls.Add( this.txtlsh );
            this.panel1.Controls.Add( this.label6 );
            this.panel1.Controls.Add( this.cmbklx );
            this.panel1.Controls.Add( this.txttmk );
            this.panel1.Controls.Add( this.label5 );
            this.panel1.Controls.Add( this.lblzd );
            this.panel1.Controls.Add( this.label16 );
            this.panel1.Controls.Add( this.lblks );
            this.panel1.Controls.Add( this.label14 );
            this.panel1.Controls.Add( this.lblnl );
            this.panel1.Controls.Add( this.label12 );
            this.panel1.Controls.Add( this.lblxb );
            this.panel1.Controls.Add( this.label10 );
            this.panel1.Controls.Add( this.lblxm );
            this.panel1.Controls.Add( this.label7 );
            this.panel1.Controls.Add( this.txtfph );
            this.panel1.Controls.Add( this.label4 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0 , 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 1027 , 68 );
            this.panel1.TabIndex = 0;
            // 
            // txtmzh
            // 
            this.txtmzh.BackColor = System.Drawing.Color.White;
            this.txtmzh.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtmzh.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.txtmzh.Location = new System.Drawing.Point( 697 , 12 );
            this.txtmzh.Name = "txtmzh";
            this.txtmzh.Size = new System.Drawing.Size( 112 , 21 );
            this.txtmzh.TabIndex = 53;
            this.txtmzh.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtfph_KeyPress );
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point( 649 , 15 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 56 , 17 );
            this.label8.TabIndex = 54;
            this.label8.Text = "门诊号";
            // 
            // txtlsh
            // 
            this.txtlsh.BackColor = System.Drawing.Color.White;
            this.txtlsh.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtlsh.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.txtlsh.Location = new System.Drawing.Point( 540 , 12 );
            this.txtlsh.Name = "txtlsh";
            this.txtlsh.Size = new System.Drawing.Size( 93 , 21 );
            this.txtlsh.TabIndex = 51;
            this.txtlsh.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtfph_KeyPress );
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point( 482 , 15 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 57 , 17 );
            this.label6.TabIndex = 52;
            this.label6.Text = "流水号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbklx
            // 
            this.cmbklx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbklx.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.cmbklx.Location = new System.Drawing.Point( 248 , 11 );
            this.cmbklx.Name = "cmbklx";
            this.cmbklx.Size = new System.Drawing.Size( 72 , 22 );
            this.cmbklx.TabIndex = 50;
            // 
            // txttmk
            // 
            this.txttmk.BackColor = System.Drawing.Color.White;
            this.txttmk.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txttmk.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.txttmk.Location = new System.Drawing.Point( 322 , 12 );
            this.txttmk.Name = "txttmk";
            this.txttmk.Size = new System.Drawing.Size( 153 , 21 );
            this.txttmk.TabIndex = 48;
            this.txttmk.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtfph_KeyPress );
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point( 162 , 15 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 87 , 17 );
            this.label5.TabIndex = 49;
            this.label5.Text = "卡类型/卡号";
            // 
            // lblzd
            // 
            this.lblzd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzd.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblzd.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.lblzd.Location = new System.Drawing.Point( 642 , 40 );
            this.lblzd.Name = "lblzd";
            this.lblzd.Size = new System.Drawing.Size( 168 , 21 );
            this.lblzd.TabIndex = 47;
            this.lblzd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblzd.Visible = false;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point( 604 , 42 );
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size( 55 , 17 );
            this.label16.TabIndex = 46;
            this.label16.Text = "诊断";
            this.label16.Visible = false;
            // 
            // lblks
            // 
            this.lblks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblks.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblks.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.lblks.Location = new System.Drawing.Point( 467 , 40 );
            this.lblks.Name = "lblks";
            this.lblks.Size = new System.Drawing.Size( 128 , 21 );
            this.lblks.TabIndex = 45;
            this.lblks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblks.Visible = false;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point( 428 , 42 );
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size( 57 , 17 );
            this.label14.TabIndex = 44;
            this.label14.Text = "科室";
            this.label14.Visible = false;
            // 
            // lblnl
            // 
            this.lblnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblnl.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblnl.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.lblnl.Location = new System.Drawing.Point( 260 , 40 );
            this.lblnl.Name = "lblnl";
            this.lblnl.Size = new System.Drawing.Size( 69 , 21 );
            this.lblnl.TabIndex = 43;
            this.lblnl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point( 226 , 42 );
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size( 57 , 17 );
            this.label12.TabIndex = 42;
            this.label12.Text = "年龄";
            // 
            // lblxb
            // 
            this.lblxb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxb.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblxb.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.lblxb.Location = new System.Drawing.Point( 185 , 40 );
            this.lblxb.Name = "lblxb";
            this.lblxb.Size = new System.Drawing.Size( 37 , 21 );
            this.lblxb.TabIndex = 41;
            this.lblxb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point( 152 , 42 );
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size( 56 , 17 );
            this.label10.TabIndex = 40;
            this.label10.Text = "性别";
            // 
            // lblxm
            // 
            this.lblxm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxm.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.lblxm.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.lblxm.Location = new System.Drawing.Point( 59 , 40 );
            this.lblxm.Name = "lblxm";
            this.lblxm.Size = new System.Drawing.Size( 92 , 21 );
            this.lblxm.TabIndex = 39;
            this.lblxm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point( 2 , 42 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 56 , 17 );
            this.label7.TabIndex = 38;
            this.label7.Text = "姓名";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtfph
            // 
            this.txtfph.BackColor = System.Drawing.Color.White;
            this.txtfph.Font = new System.Drawing.Font( "宋体" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 134 ) ) );
            this.txtfph.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.txtfph.Location = new System.Drawing.Point( 59 , 12 );
            this.txtfph.Name = "txtfph";
            this.txtfph.Size = new System.Drawing.Size( 93 , 21 );
            this.txtfph.TabIndex = 36;
            this.txtfph.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.txtfph_KeyPress );
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point( 1 , 15 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 57 , 17 );
            this.label4.TabIndex = 37;
            this.label4.Text = "发票号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.myDataGrid1 );
            this.panel2.Controls.Add( this.panel3 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point( 0 , 68 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 312 , 672 );
            this.panel2.TabIndex = 1;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font( "Tahoma" , 8.25F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.myDataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.CaptionText = "处方头";
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point( 0 , 64 );
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size( 312 , 608 );
            this.myDataGrid1.TabIndex = 1;
            this.myDataGrid1.TableStyles.AddRange( new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1} );
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler( this.myDataGrid1_CurrentCellChanged );
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add( this.rdoytywtfcf );
            this.panel3.Controls.Add( this.button5 );
            this.panel3.Controls.Add( this.dtp2 );
            this.panel3.Controls.Add( this.label3 );
            this.panel3.Controls.Add( this.dtp1 );
            this.panel3.Controls.Add( this.label2 );
            this.panel3.Controls.Add( this.rdoytycf );
            this.panel3.Controls.Add( this.rdodtycf );
            this.panel3.Controls.Add( this.rdoall );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point( 0 , 0 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 312 , 64 );
            this.panel3.TabIndex = 0;
            this.panel3.Visible = false;
            // 
            // rdoytywtfcf
            // 
            this.rdoytywtfcf.Location = new System.Drawing.Point( 184 , 0 );
            this.rdoytywtfcf.Name = "rdoytywtfcf";
            this.rdoytywtfcf.Size = new System.Drawing.Size( 128 , 24 );
            this.rdoytywtfcf.TabIndex = 3;
            this.rdoytywtfcf.Text = "已退药未退费";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
            this.button5.Location = new System.Drawing.Point( 270 , 30 );
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size( 48 , 24 );
            this.button5.TabIndex = 8;
            this.button5.Text = "刷新";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler( this.button5_Click );
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point( 154 , 33 );
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size( 110 , 21 );
            this.dtp2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 138 , 37 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 48 , 16 );
            this.label3.TabIndex = 6;
            this.label3.Text = "到";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point( 32 , 33 );
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size( 105 , 21 );
            this.dtp1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 2 , 36 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 48 , 16 );
            this.label2.TabIndex = 4;
            this.label2.Text = "日期";
            // 
            // rdoytycf
            // 
            this.rdoytycf.Location = new System.Drawing.Point( 120 , 0 );
            this.rdoytycf.Name = "rdoytycf";
            this.rdoytycf.Size = new System.Drawing.Size( 88 , 24 );
            this.rdoytycf.TabIndex = 2;
            this.rdoytycf.Text = "已退药";
            // 
            // rdodtycf
            // 
            this.rdodtycf.Location = new System.Drawing.Point( 56 , 0 );
            this.rdodtycf.Name = "rdodtycf";
            this.rdodtycf.Size = new System.Drawing.Size( 88 , 24 );
            this.rdodtycf.TabIndex = 1;
            this.rdodtycf.Text = "待退药";
            // 
            // rdoall
            // 
            this.rdoall.Checked = true;
            this.rdoall.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 0 ) ) ) ) , ( (int)( ( (byte)( 192 ) ) ) ) );
            this.rdoall.Location = new System.Drawing.Point( 8 , 0 );
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size( 56 , 24 );
            this.rdoall.TabIndex = 0;
            this.rdoall.TabStop = true;
            this.rdoall.Text = "全部";
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.myDataGrid2.CaptionFont = new System.Drawing.Font( "Tahoma" , 10.5F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.myDataGrid2.CaptionForeColor = System.Drawing.Color.Navy;
            this.myDataGrid2.CaptionText = "处方明细 ";
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.Font = new System.Drawing.Font( "宋体" , 10.5F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ) );
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point( 0 , 0 );
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ParentRowsBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 224 ) ) ) ) , ( (int)( ( (byte)( 224 ) ) ) ) , ( (int)( ( (byte)( 224 ) ) ) ) );
            this.myDataGrid2.RowHeaderWidth = 20;
            this.myDataGrid2.Size = new System.Drawing.Size( 713 , 584 );
            this.myDataGrid2.TabIndex = 2;
            this.myDataGrid2.TableStyles.AddRange( new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2} );
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler( this.myDataGrid2_CurrentCellChanged );
            this.myDataGrid2.Click += new System.EventHandler( this.myDataGrid2_Click );
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.RowHeaderWidth = 20;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point( 312 , 68 );
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size( 2 , 672 );
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point( 314 , 716 );
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange( new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2} );
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size( 713 , 24 );
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 180;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "要取消退药时，请在网格的 [选] 列上打钩";
            this.statusBarPanel2.Width = 1000;
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.panel6 );
            this.panel4.Controls.Add( this.panel5 );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point( 314 , 68 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 713 , 648 );
            this.panel4.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add( this.buttjs );
            this.panel6.Controls.Add( this.cmbph );
            this.panel6.Controls.Add( this.myDataGrid2 );
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point( 0 , 64 );
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size( 713 , 584 );
            this.panel6.TabIndex = 1;
            // 
            // buttjs
            // 
            this.buttjs.Location = new System.Drawing.Point( 280 , 2 );
            this.buttjs.Name = "buttjs";
            this.buttjs.Size = new System.Drawing.Size( 104 , 22 );
            this.buttjs.TabIndex = 4;
            this.buttjs.Text = "输入退中药剂数";
            this.buttjs.Click += new System.EventHandler( this.buttjs_Click );
            // 
            // cmbph
            // 
            this.cmbph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbph.Location = new System.Drawing.Point( 104 , 96 );
            this.cmbph.Name = "cmbph";
            this.cmbph.Size = new System.Drawing.Size( 80 , 20 );
            this.cmbph.TabIndex = 3;
            this.cmbph.Visible = false;
            this.cmbph.SelectedIndexChanged += new System.EventHandler( this.cmbph_SelectedIndexChanged );
            this.cmbph.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.cmbph_KeyPress );
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add( this.chkxp );
            this.panel5.Controls.Add( this.chkprrintView );
            this.panel5.Controls.Add( this.butqxfy );
            this.panel5.Controls.Add( this.butquit );
            this.panel5.Controls.Add( this.button2 );
            this.panel5.Controls.Add( this.butfy );
            this.panel5.Controls.Add( this.cmbpyr );
            this.panel5.Controls.Add( this.label1 );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point( 0 , 0 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 713 , 64 );
            this.panel5.TabIndex = 0;
            // 
            // chkxp
            // 
            this.chkxp.Location = new System.Drawing.Point( 174 , 34 );
            this.chkxp.Name = "chkxp";
            this.chkxp.Size = new System.Drawing.Size( 100 , 18 );
            this.chkxp.TabIndex = 37;
            this.chkxp.Text = "默认打印小票";
            // 
            // chkprrintView
            // 
            this.chkprrintView.Location = new System.Drawing.Point( 175 , 8 );
            this.chkprrintView.Name = "chkprrintView";
            this.chkprrintView.Size = new System.Drawing.Size( 79 , 24 );
            this.chkprrintView.TabIndex = 8;
            this.chkprrintView.Text = "打印预览";
            // 
            // butqxfy
            // 
            this.butqxfy.Location = new System.Drawing.Point( 368 , 16 );
            this.butqxfy.Name = "butqxfy";
            this.butqxfy.Size = new System.Drawing.Size( 88 , 32 );
            this.butqxfy.TabIndex = 7;
            this.butqxfy.Text = "取消退药(&C)";
            this.butqxfy.Click += new System.EventHandler( this.butqxfy_Click );
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point( 544 , 16 );
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size( 88 , 32 );
            this.butquit.TabIndex = 6;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler( this.butquit_Click );
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point( 456 , 16 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 88 , 32 );
            this.button2.TabIndex = 5;
            this.button2.Text = "打印(&P)";
            this.button2.Click += new System.EventHandler( this.butprint_Click );
            // 
            // butfy
            // 
            this.butfy.Location = new System.Drawing.Point( 280 , 16 );
            this.butfy.Name = "butfy";
            this.butfy.Size = new System.Drawing.Size( 88 , 32 );
            this.butfy.TabIndex = 4;
            this.butfy.Text = "退药确认(&O)";
            this.butfy.Click += new System.EventHandler( this.butfy_Click );
            // 
            // cmbpyr
            // 
            this.cmbpyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyr.Location = new System.Drawing.Point( 64 , 22 );
            this.cmbpyr.Name = "cmbpyr";
            this.cmbpyr.Size = new System.Drawing.Size( 104 , 20 );
            this.cmbpyr.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point( 24 , 26 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 48 , 16 );
            this.label1.TabIndex = 2;
            this.label1.Text = "配药人";
            // 
            // Frmmzty
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 6 , 14 );
            this.ClientSize = new System.Drawing.Size( 1027 , 740 );
            this.Controls.Add( this.panel4 );
            this.Controls.Add( this.statusBar1 );
            this.Controls.Add( this.splitter1 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.panel1 );
            this.KeyPreview = true;
            this.Name = "Frmmzty";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler( this.Frmmzfy_Load );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid1 ) ).EndInit();
            this.panel3.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.myDataGrid2 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.statusBarPanel2 ) ).EndInit();
            this.panel4.ResumeLayout( false );
            this.panel6.ResumeLayout( false );
            this.panel5.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion


        private void Frmmzfy_Load( object sender , System.EventArgs e )
        {
            FunAddComboBox.AddKlx( false , 0 , cmbklx , InstanceForm.BDatabase );
            CshMyGrid1( this.myDataGrid1 );
            CshMyGrid2( this.myDataGrid2 );

            //发药窗口
            ///////_Fyckh=MZYF.SeekFychk(PubStaticFun.GetMacAddress());

            //添加配药人
            Yp.AddcmbPyr( InstanceForm.BCurrentDept.DeptId , this.cmbpyr , InstanceForm.BDatabase );

            this.dtp1.Value = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase );
            this.dtp2.Value = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase );

            if ( _menuTag.Function_Name.Trim() != "Fun_ts_yf_mzty" && _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
            {
                this.label1.Visible = false;
                this.cmbpyr.Visible = false;
            }

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString( "医院健康卡" , "设备型号" , Constant.ApplicationDirectory + "//ClientWindow.ini" );
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall( sbxh );
            if ( ReadCard != null )
                ReadCard.AutoReadCard( _menuTag.Function_Name , cmbklx , txttmk );

            int deptid = InstanceForm.BCurrentDept.DeptId; //库房id
            bpcgl = Yp.BPcgl( deptid , InstanceForm.BDatabase );                         //是否进行批次管理
        }


        #region 初始化网格列
        private void CshMyGrid1( TrasenClasses.GeneralControls.ButtonDataGridEx dataGrid )
        {
            #region 添加明细的列
            string[] HeaderText ={ "序号" , "状态" , "发票号" , "金额" , "病历号" , "姓名" , "性别" , "年龄" , "项目" , "记帐金额" , "优惠金额" , "自付金额" , "科室" , "医生" , "剂数" , "收费日期" , "收费员" , "配药人" , "配药窗口" , "发药日期" , "发药人" , "jssjh" , "xh" , "patid" , "ysdm" , "ksdm" , "sky" , "pyckh" , "cflx" , "id" };
            string[] MappingName ={ "序号" , "状态" , "发票号" , "金额" , "病历号" , "姓名" , "性别" , "年龄" , "项目" , "记帐金额" , "优惠金额" , "自付金额" , "科室" , "医生" , "剂数" , "收费日期" , "收费员" , "配药人" , "配药窗口" , "发药日期" , "发药人" , "jssjh" , "xh" , "patid" , "ysdm" , "ksdm" , "sky" , "pyckh" , "cflx" , "id" };
            int[] ColWidth ={ 35 , 50 , 60 , 55 , 0 , 55 , 40 , 40 , 55 , 0 , 0 , 0 , 70 , 55 , 45 , 100 , 55 , 55 , 0 , 100 , 55 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 };
            bool[] ColReadOnly ={ true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true };
            bool[] ColBool ={ false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false };
            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tb";

            for ( int j = 0 ; j <= HeaderText.Length - 1 ; j++ )
            {
                //DataGridEnableBoolColumn
                if ( ColBool[j] == false )
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn( j );
                    colText.HeaderText = HeaderText[j];
                    colText.MappingName = MappingName[j];
                    colText.Width = ColWidth[j];
                    colText.NullText = "";
                    colText.ReadOnly = ColReadOnly[j];
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler( colText_CheckCellEnabled );

                    dataGrid.TableStyles[0].GridColumnStyles.Add( colText );
                    DataColumn datacol;
                    if ( MappingName[j] == "金额" )
                        datacol = new DataColumn( MappingName[j] , Type.GetType( "System.Decimal" ) );
                    else
                        datacol = new DataColumn( MappingName[j] );

                    dtTmp.Columns.Add( datacol );
                }
                else
                {
                    DataGridEnableBoolColumn colText = new DataGridEnableBoolColumn( j );
                    colText.HeaderText = HeaderText[j];
                    colText.MappingName = MappingName[j];
                    colText.Width = ColWidth[j];
                    colText.NullText = "0";
                    colText.AllowNull = false;
                    colText.NullValue = ( (short)( 0 ) );
                    colText.FalseValue = ( (short)( 0 ) );
                    colText.TrueValue = ( (short)( 1 ) );
                    colText.ReadOnly = ColReadOnly[j];
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableBoolColumn.EnableCellEventHandler( colText_CheckCellEnabled );

                    dataGrid.TableStyles[0].GridColumnStyles.Add( colText );
                    dtTmp.Columns.Add( MappingName[j] , Type.GetType( "System.Int16" ) );

                }

            }

            dataGrid.DataSource = dtTmp;
            dataGrid.TableStyles[0].MappingName = "tb";
            #endregion

        }

        private void CshMyGrid2( TrasenClasses.GeneralControls.ButtonDataGridEx dataGrid )
        {
            #region 添加明细的列
            string[] HeaderText ={ "序号" , "选" , "皮试" , "发票号" , "药品名称" , "规格" , "厂家" , "批发价" , "零售价" , "用量" , "剂数" , "批号" , "退用量" , "退剂数" , "单位" , "批发金额" , "零售金额" , "cfxh" , "ypid" , "ydwbl" , "货号" , "调价差额" , "cfts" , "id" , "fyid" , "tyid" , "deptid" , "cfmxid" , "用法" , "嘱托" , "批次号" , "效期" , "kcid" , "进价" , "进货金额" , "byscf" };
            string[] MappingName ={ "序号" , "选" , "皮试" , "发票号" , "药品名称" , "规格" , "厂家" , "批发价" , "零售价" , "用量" , "剂数" , "批号" , "退用量" , "退剂数" , "单位" , "批发金额" , "零售金额" , "cfxh" , "ypid" , "ydwbl" , "货号" , "调价差额" , "cfts" , "id" , "fyid" , "tyid" , "deptid" , "cfmxid" , "用法" , "嘱托" , "批次号" , "效期" , "kcid" , "进价" , "进货金额" , "byscf" };
            int[] ColWidth ={ 35 , 25 , 50 , 0 , 100 , 100 , 0 , 0 , 55 , 50 , 50 , 70 , 55 , 35 , 0 , 0 , 65 , 0 , 0 , 0 , 60 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 100 , 50 , 95 , 60 , 0 , 0 , 0 , 0 };
            bool[] ColReadOnly ={ true , false , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true , true };
            bool[] ColBool ={ false , true , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , false , true };
            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";

            for ( int j = 0 ; j <= HeaderText.Length - 1 ; j++ )
            {
                if ( ColBool[j] == false )
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn( j );
                    colText.HeaderText = HeaderText[j];
                    colText.MappingName = MappingName[j];
                    colText.Width = ColWidth[j];
                    colText.NullText = "";
                    colText.ReadOnly = ColReadOnly[j];
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler( myDataGrid2_CheckCellEnabled );

                    dataGrid.TableStyles[0].GridColumnStyles.Add( colText );
                    DataColumn datacol;
                    if ( MappingName[j] == "零售金额" )
                        datacol = new DataColumn( MappingName[j] , Type.GetType( "System.Decimal" ) );
                    else
                        datacol = new DataColumn( MappingName[j] );

                    dtTmp.Columns.Add( datacol );
                }
                else
                {
                    DataGridEnableBoolColumn colText = new DataGridEnableBoolColumn( j );
                    colText.HeaderText = HeaderText[j];
                    colText.MappingName = MappingName[j];
                    colText.Width = ColWidth[j];
                    colText.NullText = "0";
                    colText.AllowNull = false;
                    colText.NullValue = ( (short)( 0 ) );
                    colText.FalseValue = ( (short)( 0 ) );
                    colText.TrueValue = ( (short)( 1 ) );
                    colText.ReadOnly = ColReadOnly[j];
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableBoolColumn.EnableCellEventHandler( myDataGrid2_CheckCellEnabled );

                    dataGrid.TableStyles[0].GridColumnStyles.Add( colText );
                    dtTmp.Columns.Add( MappingName[j] , Type.GetType( "System.Int16" ) );

                }
            }

            dataGrid.DataSource = dtTmp;
            dataGrid.TableStyles[0].MappingName = "tbmx";
            #endregion

            if ( !bpcgl )
            {

            }
        }

        #endregion

        #region 网格颜色改变事件
        //列颜色改变事件
        private void myDataGrid2_CheckCellEnabled( object sender , DataGridEnableEventArgs e )
        {
            try
            {
                e.BackColor = Color.White;
                DataTable tb;
                if ( sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn" )
                {
                    DataGridEnableBoolColumn column = (DataGridEnableBoolColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                else
                {
                    DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                if ( e.Row > tb.Rows.Count - 1 )
                    return;

                if ( Convertor.IsNull( tb.Rows[e.Row]["fyid"] , Guid.Empty.ToString() ) == Guid.Empty.ToString() && tb.Rows[e.Row]["序号"].ToString().Trim() != "小计" )
                    e.ForeColor = Color.Blue;
                if ( Convertor.IsNull( tb.Rows[e.Row]["fyid"] , Guid.Empty.ToString() ) != Guid.Empty.ToString() )
                    e.ForeColor = Color.Black;
                if ( tb.Rows[e.Row]["byscf"].ToString().Trim() == "1" )
                    e.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 240 ) ) ) ) , ( (int)( ( (byte)( 248 ) ) ) ) , ( (int)( ( (byte)( 255 ) ) ) ) );
                else
                    e.BackColor = Color.White;

            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message );
            }
        }

        #endregion

        #region 病人控件回车事件
        private void patientInfo1_IDTextBoxKeyPress( object sender , System.Windows.Forms.KeyPressEventArgs e )
        {
            //			try
            //			{
            //
            //				DataTable tb2=(DataTable)this.myDataGrid2.DataSource;
            //				tb2.Rows.Clear();
            //
            //				if (Convert.ToInt32(e.KeyChar)!=13)return;
            //				if (this.patientInfo1.PatientID<=0) return;
            //
            //				this.Cursor=PubStaticFun.WaitCursor();
            //				//查询类型
            //				int cxtype=Convert.ToInt32(patientInfo1.SearchIDType);
            //				//查询值
            //				string values=patientInfo1.PatientInvoiceID;
            //				//病人ID
            //				long ghxh=patientInfo1.PatientRegisterID;
            //				
            //
            //				
            //				DataTable tb=MZYF.Select_TY_Cf(InstanceForm.BCurrentDept.DeptId,ghxh,1,cxtype,values);
            //				tb.TableName="tb";
            //				this.myDataGrid1.DataSource=tb;
            //				this.myDataGrid1.TableStyles[0].MappingName="tb";
            //
            //				if (tb.Rows.Count==0) return;
            //				
            //				_fyid=Convert.ToInt64(tb.Rows[0]["id"]);
            //
            //				//查找处方明细
            //				SelectCf_Cfmx(Convert.ToInt64(tb.Rows[0]["xh"]),Convert.ToInt64(tb.Rows[0]["发票号"]),0,Convert.ToDecimal(tb.Rows[0]["金额"]));
            //
            //				//控制列的宽度和可读性
            //				
            //				string _cflx=tb.Rows[0]["cflx"].ToString().Trim();
            //				ControlVisble(_cflx);

            //			}
            //			catch(System.Exception err)
            //			{
            //
            //				DataTable tb1=(DataTable)this.myDataGrid2.DataSource;
            //				tb1.Rows.Clear();
            //				MessageBox.Show("发生错误"+err.Message);
            //			}
            //			finally
            //			{
            //				this.Cursor=Cursors.Arrow;
            //			}

        }

        #endregion

        private void ControlVisble( string _cflx )
        {
            DataTable tb = (DataTable)myDataGrid2.DataSource;
            if ( tb.Rows.Count != 0 )
            {

                string hh = tb.Rows[0]["货号"].ToString().Trim().Length >= 2 ? tb.Rows[0]["货号"].ToString().Trim().Substring( 0 , 2 ) : "";
                if ( hh.Trim() == "ZY" )
                    _cflx = "03";
            }
            if ( _cflx == "03" )
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退用量"].Width = 0;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退用量"].ReadOnly = true;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].Width = 55;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].ReadOnly = true;
                if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_ys" )
                    this.buttjs.Visible = true;
                else
                    this.buttjs.Visible = true;
                myDataGrid2.Refresh();
            }
            else
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退用量"].Width = 55;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退用量"].ReadOnly = false;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].Width = 0;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].ReadOnly = true;
                this.buttjs.Visible = false;
            }
        }

        #region 方法
        //查询处方明细
        private void SelectCf_Cfmx( string cflx , Guid cfxh , long fph , Guid fyid , decimal _zje )
        {
            DataTable tbmx = (DataTable)this.myDataGrid2.DataSource;
            tbmx.Rows.Clear();
            DataTable tb1 = MZYF.Select_TY_Cfmx( cfxh , fph , fyid , InstanceForm.BDatabase );
            decimal sumlsje = 0;

            for ( int j = 0 ; j <= tb1.Rows.Count - 1 ; j++ )
            {
                DataRow myrow = tbmx.NewRow();
                myrow["序号"] = Convert.ToString( j + 1 ).ToString();
                if ( _zje >= 0 )
                    myrow["选"] = (short)( 0 );
                else
                    myrow["选"] = (short)( 1 );

                myrow["皮试"] = tb1.Rows[j]["皮试"];
                myrow["发票号"] = fph.ToString();
                myrow["药品名称"] = tb1.Rows[j]["药品名称"];
                myrow["规格"] = tb1.Rows[j]["规格"];
                myrow["厂家"] = tb1.Rows[j]["厂家"];
                myrow["批发价"] = tb1.Rows[j]["批发价"];
                myrow["零售价"] = tb1.Rows[j]["零售价"];
                myrow["用量"] = tb1.Rows[j]["用量"];
                Guid _fymxid = Guid.Empty;
                _fymxid = new Guid( tb1.Rows[j]["id"].ToString() );

                if ( !bpcgl )//不进行批次管理时 去yf_fymx_ph表中查询批号信息
                {
                    myrow["批号"] = MZYF.SeekFymxPh( _fymxid , InstanceForm.BCurrentDept.DeptId , InstanceForm.BDatabase );
                    if ( myrow["批号"].ToString().Trim() == "" )
                        myrow["批号"] = "无批号";
                }
                else
                {
                    myrow["批号"] = tb1.Rows[j]["批号"];
                    myrow["效期"] = tb1.Rows[j]["效期"];
                    myrow["批次号"] = tb1.Rows[j]["批次号"];
                    myrow["kcid"] = tb1.Rows[j]["kcid"];
                    myrow["进价"] = tb1.Rows[j]["进价"];
                    myrow["进货金额"] = tb1.Rows[j]["进货金额"];
                }

                #region 无用代码
                //if (Convert.ToDecimal(tb1.Rows[j]["cfts"])>1)
                //{
                //    myrow["退剂数"]=tb1.Rows[j]["cfts"];
                //    //myrow["退用量"] = tb1.Rows[j]["用量"];
                //}
                //else
                //{
                //    myrow["退剂数"]="1";
                //    //myrow["退用量"] = tb1.Rows[j]["用量"];
                //}
                #endregion

                if ( Convert.ToDecimal( tb1.Rows[j]["零售金额"] ) >= 0 )
                {
                    if ( cflx == "03" )
                    {
                        myrow["退剂数"] = tb1.Rows[j]["cfts"];
                        myrow["退用量"] = tb1.Rows[j]["用量"];
                    }
                    else
                    {
                        myrow["退剂数"] = "1";
                        myrow["退用量"] = tb1.Rows[j]["tysl"];
                    }
                }

                if ( cfg8025.Config == "1" && _menuTag.Function_Name != "Fun_ts_yf_mzty_ys" )
                {

                    if ( cflx == "03" )
                    {
                        myrow["退剂数"] = "";
                        myrow["退用量"] = "";
                    }
                    else
                    {
                        myrow["退剂数"] = "1";
                        myrow["退用量"] = "";
                    }

                }

                myrow["剂数"] = tb1.Rows[j]["cfts"];
                myrow["单位"] = tb1.Rows[j]["单位"];
                myrow["批发金额"] = tb1.Rows[j]["批发金额"];
                myrow["零售金额"] = tb1.Rows[j]["零售金额"];
                myrow["调价差额"] = tb1.Rows[j]["调价差额"];
                myrow["cfxh"] = tb1.Rows[j]["cfxh"];
                myrow["ypid"] = tb1.Rows[j]["ypid"];
                myrow["ydwbl"] = tb1.Rows[j]["ydwbl"];
                myrow["货号"] = tb1.Rows[j]["货号"];
                myrow["id"] = tb1.Rows[j]["id"];
                myrow["FYid"] = tb1.Rows[j]["FYid"];
                myrow["tyid"] = tb1.Rows[j]["tyid"];
                myrow["deptid"] = tb1.Rows[j]["deptid"];
                myrow["cfmxid"] = tb1.Rows[j]["cfmxid"];
                //myrow["退用量"]=tb1.Rows[j]["tysl"];
                myrow["用法"] = tb1.Rows[j]["用法"];
                myrow["嘱托"] = tb1.Rows[j]["嘱托"];
                myrow["byscf"] = tb1.Rows[j]["byscf"];
                tbmx.Rows.Add( myrow );
                sumlsje = sumlsje + Convert.ToDecimal( tb1.Rows[j]["零售金额"] );
            }

            DataRow sumrow = tbmx.NewRow();
            sumrow["序号"] = "小计";
            sumrow["选"] = (short)( 0 );
            sumrow["零售金额"] = sumlsje.ToString( "0.000" );
            tbmx.Rows.Add( sumrow );

            #region 无用代码
            //////			if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim()=="Fun_ts_yf_mzty_eyf")
            //////			{
            //////				bool bflag=false;
            //////				for(int x=0;x<=tb1.Rows.Count-1;x++)
            //////				{
            //////					if (Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[x]["用量"],"0"))<0)
            //////					{
            //////						bflag=true;
            //////					}
            //////				}
            //////				if (bflag==true)
            //////				{
            //////					for(int x=0;x<=tbmx.Rows.Count-1;x++)
            //////					{
            //////						tbmx.Rows[x]["退用量"]="";
            //////					}
            //////				}
            //////			}
            #endregion

        }


        //打印方法
        private void PrintCf( DataRow row )
        {
            DataTable tb2 = (DataTable)this.myDataGrid2.DataSource;
            string cftsname = "";
            cftsname = Convert.ToString( row["项目"] ).Trim() == "中草药" ? "中药付数" : "";
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow;
            for ( int i = 0 ; i <= tb2.Rows.Count - 1 ; i++ )
            {
                if ( tb2.Rows[i]["序号"].ToString().Trim() != "小计" )
                {
                    myrow = Dset.病人处方清单.NewRow();
                    myrow["xh"] = Convert.ToInt32( tb2.Rows[i]["序号"] );
                    myrow["ypmc"] = Convert.ToString( tb2.Rows[i]["药品名称"] );
                    myrow["ypgg"] = Convert.ToString( tb2.Rows[i]["规格"] );
                    myrow["sccj"] = Convert.ToString( tb2.Rows[i]["厂家"] );
                    myrow["lsj"] = Convert.ToDecimal( Convertor.IsNull( tb2.Rows[i]["零售价"] , "0" ) );
                    myrow["ypsl"] = Convert.ToDecimal( Convertor.IsNull( tb2.Rows[i]["用量"] , "0" ) );
                    myrow["ypdw"] = Convert.ToString( tb2.Rows[i]["单位"] );
                    myrow["cfts"] = Convert.ToString( row["项目"] ).Trim() == "中草药" ? tb2.Rows[i]["剂数"] + "剂" : "";
                    myrow["lsje"] = Convert.ToDecimal( Convertor.IsNull( tb2.Rows[i]["零售金额"] , "0" ) );
                    //					myrow["yf"]=Convert.ToString(tb2.Rows[i]["用法"])+"  "+ BaseFun.SeekPc(Convert.ToInt32(Convertor.IsNull(tb2.Rows[i]["PCDM"],"0")));
                    //					myrow["pc"]= BaseFun.SeekPc(Convert.ToInt32(Convertor.IsNull(tb2.Rows[i]["PCDM"],"0")));
                    //					myrow["syjl"]="";
                    //					myrow["zt"]=Convert.ToString(tb2.Rows[i]["嘱托"]);
                    myrow["shh"] = Convert.ToString( tb2.Rows[i]["货号"] );
                    myrow["ksname"] = Convert.ToString( row["科室"] );//+"  费别:"+this.patientInfo1.FeeTypeName;
                    myrow["ysname"] = Convert.ToString( row["医生"] );
                    myrow["Pyck"] = row["配药窗口"].ToString();
                    myrow["fph"] = Convert.ToString( row["发票号"] );
                    myrow["hzxm"] = Convert.ToString( row["姓名"] );
                    myrow["sex"] = Convert.ToString( row["性别"] );
                    myrow["age"] = Convert.ToString( row["年龄"] );
                    myrow["blh"] = Convert.ToString( row["病历号"] );
                    myrow["sfrq"] = Convert.ToString( row["收费日期"] );
                    myrow["pyr"] = this.cmbpyr.Text.Trim();
                    ;
                    myrow["fyr"] = InstanceForm.BCurrentUser.Name;
                    Dset.病人处方清单.Rows.Add( myrow );
                }

            }

            DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;

            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Text = "cfts";
            parameters[0].Value = cftsname;
            parameters[1].Text = "zje";
            parameters[1].Value = Convert.ToDecimal( Convertor.IsNull( row["金额"] , "0" ) );
            parameters[2].Text = "TITLETEXT";
            parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + "处方退药清单";
            parameters[3].Text = "text1";
            parameters[3].Value = "退药单位:" + InstanceForm.BCurrentDept.DeptName + "     诊断:" + this.lblzd.Text + "       原处方金额:" + tb1.Rows[0]["金额"].ToString();
            bool bview = this.chkprrintView.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView( Dset.病人处方清单 , Constant.ApplicationDirectory + "\\Report\\YF_病人退药清单.rpt" , parameters , bview );

            if ( f.LoadReportSuccess )
                f.Show();
            else
                f.Dispose();

        }


        //验证退药信息的合法性
        private bool DataTrueFalse()
        {
            DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;
            DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
            bool values = true;

            for ( int i = 0 ; i <= myTb.Rows.Count - 1 ; i++ )
            {
                if ( new SystemCfg( 8020 ).Config == "0" && _menuTag.Function_Name != "Fun_ts_yf_mzty_ys" )
                {
                    if ( myTb.Rows[0]["deptid"].ToString() != InstanceForm.BCurrentDept.DeptId.ToString() )
                    {
                        MessageBox.Show( "该处方非本药房发出,请到 [" + Yp.SeekDeptName( Convert.ToInt32( myTb.Rows[0]["deptid"] ) , InstanceForm.BDatabase ) + "] 办理退药 " , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        values = false;
                        break;
                    }
                }
                if ( myTb.Rows[i]["id"].ToString().Trim() != "" && ( Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["退用量"] , "0" ) ) > 0 && Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["退剂数"] , "0" ) ) > 0 ) )
                {
                    decimal yyl = Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["用量"] , "0" ) );//原用量
                    decimal yjs = Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["剂数"] , "0" ) );//原剂数
                    decimal ytyl = 0;//已退用量
                    decimal ytjs = 0;//已退剂数
                    decimal dqtyl = Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["退用量"] , "0" ) );//当前退用量
                    decimal dqtjs = Convert.ToDecimal( Convertor.IsNull( myTb.Rows[i]["退剂数"] , "0" ) );//当前退剂数

                    string _cflx = tb1.Rows[this.myDataGrid1.CurrentCell.RowNumber]["cflx"].ToString().Trim();

                    //计算已退药量
                    DataTable tb = MZYF.SelectYtyl( new Guid( myTb.Rows[i]["id"].ToString() ) , Convert.ToInt64( myTb.Rows[i]["发票号"] ) , InstanceForm.BDatabase );
                    if ( tb.Rows.Count > 0 )
                    {
                        ytyl = Convert.ToDecimal( Convertor.IsNull( tb.Rows[0]["tyl"] , "0" ) ) * ( -1 );
                        ytjs = Convert.ToDecimal( Convertor.IsNull( tb.Rows[0]["tjs"] , "0" ) );
                    }

                    //当前退药量大于可退药量
                    if ( dqtyl > ( yyl - ytyl ) && _cflx != "03" )
                    {
                        MessageBox.Show( "当前退药量大于可退药量，请修改退药量" );
                        myTb.Rows[i]["退用量"] = "0";
                        values = false;
                    }

                    if ( this.myDataGrid1.CurrentCell.RowNumber > ( tb1.Rows.Count - 1 ) )
                        values = false;
                    //当前退剂数如果大于可退剂数

                    if ( _cflx == "03" )
                    {
                        if ( dqtjs > ( yjs - ytjs ) )
                        {
                            MessageBox.Show( "当前退剂数大于可退剂数，请修改退剂数" );
                            myTb.Rows[i]["退剂数"] = "0";
                            values = false;
                        }
                    }

                    if ( !bpcgl )//不进行批次管理时,要到yf_fymx_ph表中验证该批号是否存在
                    {
                        //确定库存中是否存在该退药批号
                        if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
                        {
                            DataTable tbkc = MZYF.Selectkcph( Convert.ToInt32( Convertor.IsNull( myTb.Rows[i]["ypid"] , "0" ) ) , InstanceForm.BCurrentDept.DeptId , _menuTag.Function_Name.Trim() , InstanceForm.BDatabase );
                            bool byes = false;
                            for ( int j = 0 ; j <= tbkc.Rows.Count - 1 ; j++ )
                            {
                                if ( tbkc.Rows[j]["ypph"].ToString().Trim() == myTb.Rows[i]["批号"].ToString().Trim() )
                                {
                                    byes = true;
                                }
                            }
                            if ( byes == false )
                            {
                                MessageBox.Show( myTb.Rows[i]["药品名称"].ToString().Trim() + " 在库存中没有 [" + myTb.Rows[i]["批号"].ToString().Trim() + "] 这个库存批号" );
                                values = false;
                            }
                        }
                    }

                    //如果该药品是输液基数必须由输液科室退药


                }
            }
            return values;
        }

        #endregion

        #region 事件
        /// <summary>
        /// 取消退药
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butqxfy_Click( object sender , System.EventArgs e )
        {

            //身份的再次确认
            string dlgvalue = DlgPW.Show();
            string pwStr = dlgvalue; //YS.Password;
            bool bOk = InstanceForm.BCurrentUser.CheckPassword( pwStr );
            if ( !bOk )
            {
                TrasenFrame.Forms.FrmMessageBox.Show( "你没有通过权限确认，不能进行此操作！" , new Font( "宋体" , 12f ) , Color.Red , "Sorry！" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }


            int err_code = -1;
            string err_text = "";
            Guid fymxid = Guid.Empty;
            string sDate = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToString();
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            DataTable tbmx = (DataTable)this.myDataGrid2.DataSource;

            string _pronamefy = "";
            string _pronamefymx = "";

            _pronamefy = "sp_yf_fy";
            _pronamefymx = "sp_yf_fymx";

            //如果为二药房退药
            if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
            {
                _pronamefy = "sp_yk_fy";
                _pronamefymx = "sp_yk_fymx";
            }

            #region 取消退药金额
            decimal sumtyje = 0;
            for ( int i = 0 ; i <= tbmx.Rows.Count - 1 ; i++ )
            {
                if ( tbmx.Rows[i]["序号"].ToString().Trim() != "小计" && Convert.ToBoolean( tbmx.Rows[i]["选"] ) == true && Convert.ToDecimal( tbmx.Rows[i]["用量"] ) < 0 )
                {
                    sumtyje = sumtyje + Convert.ToDecimal( tbmx.Rows[i]["零售金额"] );
                }
            }
            if ( sumtyje >= 0 )
            {
                MessageBox.Show( "取消退药金额为零，请确认" );
                this.butqxfy.Enabled = true;
                return;
            }
            if ( MessageBox.Show( "当前取消退药金额为 " + Convert.ToString( Math.Abs( sumtyje ) ) + " 您确定要取消吗 ？" , "询问窗" , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button2 ) == DialogResult.No )
                return;

            #endregion

            this.butqxfy.Enabled = false;
            this.Cursor = PubStaticFun.WaitCursor();

            try
            {
                //门诊连接
                InstanceForm.BDatabase.BeginTransaction();

                for ( int i = 0 ; i <= tbmx.Rows.Count - 1 ; i++ )
                {

                    if ( tbmx.Rows[i]["序号"].ToString().Trim() != "小计" && Convert.ToBoolean( tbmx.Rows[i]["选"] ) == true && Convert.ToDecimal( tbmx.Rows[i]["用量"] ) < 0 )
                    {
                        Guid fyid = new Guid( Convertor.IsNull( tbmx.Rows[i]["fyid"] , Guid.Empty.ToString() ) );

                        //判断此处方是否已退费和上传
                        if ( fyid != Guid.Empty && _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_ys" )
                        {
                            throw new Exception( "药房已确认退药，您不能取消" );
                        }

                        if ( fyid != Guid.Empty )
                            MZYF.SelectYpzt( fyid , InstanceForm.BDatabase );

                        //取消大输液退药记录
                        ////////MZYF.Delete_mzdsyckb(Convert.ToInt64(Convertor.IsNull(tbmx.Rows[i]["id"],"0")),InstanceForm.BCurrentUser.EmployeeId,sDate);

                        MZYF.DeleteTymx( new Guid( Convertor.IsNull( tbmx.Rows[i]["id"] , Guid.Empty.ToString() ) ) , 1 , out err_code , out err_text , InstanceForm.BDatabase );
                        if ( err_code != 0 )
                            throw new Exception( err_text );


                        if ( fyid != Guid.Empty )
                        {
                            MZYF.DeleteTy( fyid , Convert.ToDecimal( tbmx.Rows[i]["零售金额"] ) , out err_code , out err_text , InstanceForm.BDatabase );
                            if ( err_code != 0 )
                                throw new Exception( err_text );

                            #region 更新库存
                            MZYF.SaveFymx( fyid ,//该fyid为零在取消时不用更新库存，只有大于零才表示已退过药后才取消
                                Convert.ToInt64( Convertor.IsNull( tbmx.Rows[i]["发票号"] , "0" ) ) ,
                                new Guid( Convertor.IsNull( tbmx.Rows[i]["cfxh"] , Guid.Empty.ToString() ) ) ,
                                Convert.ToInt32( Convertor.IsNull( tbmx.Rows[i]["ypid"] , "0" ) ) ,
                                tbmx.Rows[i]["货号"].ToString() ,
                                tbmx.Rows[i]["药品名称"].ToString() ,
                                tbmx.Rows[i]["药品名称"].ToString() ,
                                tbmx.Rows[i]["规格"].ToString() ,
                                tbmx.Rows[i]["厂家"].ToString() ,
                                tbmx.Rows[i]["单位"].ToString() ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["ydwbl"] , "0" ) ) ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["用量"] , "0" ) ) * ( -1 ) ,
                                Convert.ToInt32( Convertor.IsNull( tbmx.Rows[i]["剂数"] , "0" ) ) ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["批发价"] , "0" ) ) ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["批发金额"] , "0" ) ) * ( -1 ) ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["零售价"] , "0" ) ) ,
                                Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["零售金额"] , "0" ) ) * ( -1 ) ,
                                0 ,
                                0 ,
                                InstanceForm.BCurrentDept.DeptId ,
                                new Guid( tbmx.Rows[i]["tyid"].ToString() ) ,
                                tbmx.Rows[i]["批号"].ToString() ,
                                new Guid( tbmx.Rows[i]["id"].ToString() ) ,//该参数大于零时，后台不插入明细
                                new Guid( Convertor.IsNull( tbmx.Rows[i]["cfmxid"] , Guid.Empty.ToString() ) ) ,
                                "" ,
                                "" ,
                                "" ,
                                "" ,
                                "" ,
                                "" ,
                                "" ,
                                0 ,
                                0 ,
                                0 ,
                                _pronamefymx ,
                                out fymxid ,
                                out err_code ,
                                out err_text

                                , 0 , 0 , "" , "" , Guid.Empty ,

                                InstanceForm.BDatabase ,
                                false );
                            if ( err_code != 0 )
                            {
                                throw new System.Exception( err_text );
                            }

                            #endregion
                        }
                    }

                }
                InstanceForm.BDatabase.CommitTransaction();


                //重新显示该发票
                //				_zje=0;
                _fyid = Guid.Empty;
                //this.patientInfo1_IDTextBoxKeyPress(sender,new KeyPressEventArgs((char)13));
                this.txtfph.Focus();
                this.txtfph_KeyPress( txtfph , new KeyPressEventArgs( (char)13 ) );
                this.myDataGrid2.CurrentCell = new DataGridCell( 0 , 4 );

                MessageBox.Show( "取消退药成功" );
                butqxfy.Enabled = true;

            }
            catch ( System.Exception err )
            {
                butqxfy.Enabled = true;
                InstanceForm.BDatabase.RollbackTransaction();

                MessageBox.Show( err.Message );
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// 发药
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butfy_Click( object sender , System.EventArgs e )
        {
            //如果是药房操作员
            if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" )
            {
                YpConfig s = new YpConfig( InstanceForm.BCurrentDept.DeptId , InstanceForm.BDatabase );
                if ( s.系统启用 == false )
                {
                    MessageBox.Show( "系统未启用" );
                    return;
                }
                if ( s.禁用系统 == true )
                {
                    MessageBox.Show( "系统被管理员禁用" );
                    return;
                }
                if ( cmbpyr.Text.Trim() == "" )
                {
                    MessageBox.Show( "请选择配药人" );
                    return;
                }
            }


            string _pronamefy = "";
            string _pronamefymx = "";

            _pronamefy = "sp_yf_fy";
            _pronamefymx = "sp_yf_fymx";

            //如果为二药房退药
            if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
            {
                _pronamefy = "sp_yk_fy";
                _pronamefymx = "sp_yk_fymx";
            }


            string sDate = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).ToString();
            Guid fyid = Guid.Empty;
            Guid fymxid = Guid.Empty;
            int err_code = -1;
            string err_text = "";

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            DataTable tbmx = (DataTable)this.myDataGrid2.DataSource;
            if ( tb.Rows.Count == 0 )
            {
                MessageBox.Show( "请输入要退药的发票号并按回车键" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            if ( tbmx.Rows.Count == 0 )
            {
                MessageBox.Show( "没有可退的药品" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
            Frmtyyy tyyy = new Frmtyyy();
            DialogResult dr = tyyy.ShowDialog();
            if ( string.IsNullOrEmpty( tyyy.ResultValue.Value ) )
            {
                return;
            }


            //身份的再次确认
            string dlgvalue = DlgPW.Show();
            string pwStr = dlgvalue; //YS.Password;
            bool bOk = InstanceForm.BCurrentUser.CheckPassword( pwStr );
            if ( !bOk )
            {
                TrasenFrame.Forms.FrmMessageBox.Show( "你没有通过权限确认，不能进行此操作！" , new Font( "宋体" , 12f ) , Color.Red , "Sorry！" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                return;
            }


            //退药信息合法性验证
            if ( DataTrueFalse() == false )
                return;


            //退药剂数
            int ypjs = Convert.ToInt32( Convertor.IsNull( tbmx.Rows[0]["退剂数"] , "0" ) );

            #region 计算退药金额 tyzje
            decimal tyzje = 0;
            decimal tjzje = 0;
            decimal tyhje = 0;
            decimal tzfje = 0;
            decimal tyzjhje = 0;
            for ( int i = 0 ; i <= tbmx.Rows.Count - 1 ; i++ )
            {
                if ( tbmx.Rows[i]["id"].ToString().Trim() != "" )
                {
                    //准备退药金额
                    if ( Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["零售金额"] , "0" ) ) > 0 )
                    {
                        decimal _tyl = 0;
                        _tyl = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["退用量"] , "0" ) );
                        tyzje = tyzje + Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["零售价"] , "0" ) ) * _tyl * ypjs * ( -1 );

                        tyzjhje = tyzjhje + Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["进价"] , "0" ) ) * _tyl * ypjs * ( -1 );
                    }
                    //已确认输入的退药金额
                    if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
                    {
                        if ( Convertor.IsNull( tbmx.Rows[i]["fyid"] , Guid.Empty.ToString() ) == Guid.Empty.ToString() )
                        {
                            tyzje = tyzje + Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["零售金额"] , "0" ) );
                            tyzjhje = tyzjhje + Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[i]["进货金额"] , "0" ) );
                        }
                    }
                }

            }
            if ( tyzje >= 0 )
            {
                //MessageBox.Show( "退药金额为零，请确认" );
                //this.butfy.Enabled = true;
                //return;
                if ( MessageBox.Show( "退药金额为零，是否继续操作?" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                {
                    this.butfy.Enabled = true;
                    return;
                }

            }
            if ( MessageBox.Show( "当前退药金额为 " + Convert.ToString( Math.Abs( tyzje ) ) + " 您确定要退药吗 ？" , "询问窗" , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button2 ) == DialogResult.No )
                return;
            #endregion


            try
            {

                InstanceForm.BDatabase.BeginTransaction();


                #region 判断头表行(cfrow)的位置
                Guid cfxh = Guid.Empty;
                if ( tbmx.Rows.Count > 0 )
                    cfxh = new Guid( tbmx.Rows[0]["cfxh"].ToString() );
                int cfrow = -1;
                for ( int i = 0 ; i <= tb.Rows.Count - 1 ; i++ )
                {
                    if ( new Guid( Convertor.IsNull( tb.Rows[i]["xh"] , Guid.Empty.ToString() ) ) == cfxh )
                        cfrow = i;
                }
                #endregion

                #region 如果是医保处方则必须全退  暂时关闭
                //				decimal cfje=0;
                //				if (Convert.ToDecimal(Convertor.IsNull(tb.Rows[cfrow]["金额"],"0"))!=Convert.ToDecimal(Convertor.IsNull(tb.Rows[cfrow]["自付金额"],"0")))
                //				{
                //					for(int i=0;i<=tbmx.Rows.Count-1;i++)
                //					{
                //						if (Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[i]["id"],"0"))>0)
                //							cfje=cfje+Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[i]["零售金额"],"0"));
                //					}
                //
                ////					decimal Cfje=Math.Abs(cfje);
                ////					decimal Tyzje=Math.Abs(tyzje);
                ////					if (Math.Round(Math.Abs(cfje),1)!=Math.Round(Math.Abs(tyzje),1))
                ////					{
                ////						throw new Exception("该处方记帐部分（医保处方）或优惠,必须全部退药");
                ////					}
                //					
                //					tjzje=Convert.ToDecimal(Convertor.IsNull(tb.Rows[cfrow]["记帐金额"],"0"))*(-1);
                //					tyhje=Convert.ToDecimal(Convertor.IsNull(tb.Rows[cfrow]["优惠金额"],"0"))*(-1);
                //					tzfje=Convert.ToDecimal(Convertor.IsNull(tb.Rows[cfrow]["自付金额"],"0"))*(-1);
                //				}
                //				else
                //				{
                //					tjzje=0;
                //					tyhje=0;
                //					tzfje=tyzje;
                //				}

                #endregion

                #region 如果是药房退药则插入头表
                if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
                {
                    //插入退药头记录
                    MZYF.SaveFy( tb.Rows[cfrow]["cflx"].ToString() ,
                        Convert.ToDecimal( Convertor.IsNull( tb.Rows[cfrow]["jssjh"] , "0" ) ) ,
                        Convert.ToInt64( Convertor.IsNull( tb.Rows[cfrow]["发票号"] , "0" ) ) ,
                        tyzje ,
                        tjzje ,
                        tyhje ,
                        tzfje ,
                        ypjs ,
                        new Guid( tb.Rows[cfrow]["xh"].ToString() ) ,
                        new Guid( Convertor.IsNull( tb.Rows[cfrow]["patid"] , Guid.Empty.ToString() ) ) ,
                        tb.Rows[cfrow]["病历号"].ToString().Trim() ,
                        tb.Rows[cfrow]["姓名"].ToString() ,
                        Convert.ToInt32( Convertor.IsNull( tb.Rows[cfrow]["ysdm"] , "0" ) ) ,
                        Convert.ToInt32( Convertor.IsNull( tb.Rows[cfrow]["ksdm"] , "0" ) ) ,
                        tb.Rows[cfrow]["收费日期"].ToString() ,
                        Convert.ToInt32( Convertor.IsNull( tb.Rows[cfrow]["sky"] , "0" ) ) ,
                        sDate ,
                        InstanceForm.BCurrentUser.EmployeeId ,
                        Convert.ToInt32( cmbpyr.SelectedValue ) ,
                        Convertor.IsNull( tb.Rows[cfrow]["pyckh"] , "0" ) ,
                        _Fyckh ,
                        InstanceForm.BCurrentDept.DeptId , 1 , _menuTag.FunctionTag , 0 , _pronamefy , out fyid , out err_code , out err_text , InstanceForm._menuTag.Jgbm , InstanceForm.BDatabase , tyyy.ResultValue.Value );

                    if ( err_code != 0 || fyid == Guid.Empty )
                    {
                        throw new System.Exception( err_text );
                    }
                }
                #endregion

                for ( int j = 0 ; j <= tbmx.Rows.Count - 1 ; j++ )
                {
                    #region 取得变量值 id,tyl、tjs、pfj、lsj
                    Guid id = Guid.Empty;
                    int tjs = 0;
                    decimal tyl = 0;
                    decimal pfj = 0;
                    decimal lsj = 0;
                    decimal jhj = 0;

                    //如果是已经输入的退药
                    if ( new Guid( Convertor.IsNull( tbmx.Rows[j]["fyid"].ToString() , Guid.Empty.ToString() ) ) == Guid.Empty )
                    {
                        id = new Guid( Convertor.IsNull( tbmx.Rows[j]["id"].ToString() , Guid.Empty.ToString() ) );
                        tyl = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["用量"] , "0" ) );
                        tjs = Convert.ToInt32( Convertor.IsNull( tbmx.Rows[j]["剂数"] , "0" ) );
                        pfj = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["批发价"] , "0" ) );
                        lsj = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["零售价"] , "0" ) );
                        jhj = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["进价"] , "0" ) );
                    }
                    //如果是正在输入的退药
                    else
                    {

                        id = Guid.Empty;
                        if ( Convert.ToInt32( Convertor.IsNull( tbmx.Rows[j]["剂数"] , "0" ) ) == 1 )
                        {
                            tyl = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["退用量"] , "0" ) ) * ( -1 );
                            tjs = 1;
                        }
                        else
                        {
                            tyl = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["用量"] , "0" ) ) * ( -1 );
                            tjs = Convert.ToInt32( Convertor.IsNull( tbmx.Rows[j]["退剂数"] , "0" ) );
                        }

                        pfj = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["批发价"] , "0" ) );
                        lsj = Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["零售价"] , "0" ) );
                        jhj = Convert.ToDecimal(Convertor.IsNull(tbmx.Rows[j]["进价"], "0"));//Add By Tany 2018-01-25
                    }
                    #endregion

                    #region 插入明细表、更新库存
                    if ( new Guid( Convertor.IsNull( tbmx.Rows[j]["id"].ToString() , Guid.Empty.ToString() ) ) != Guid.Empty)// && tyl * tjs != 0 )
                    {
                        long fyksid = 0;
                        if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
                            fyksid = InstanceForm.BCurrentDept.DeptId;
                        else
                            fyksid = Convert.ToInt64( Convertor.IsNull( tbmx.Rows[j]["deptid"] , "0" ) );
                        //插入退药明细
                        MZYF.SaveFymx( fyid ,
                            Convert.ToInt64( Convertor.IsNull( tbmx.Rows[j]["发票号"] , "0" ) ) ,
                            new Guid( Convertor.IsNull( tbmx.Rows[j]["cfxh"] , Guid.Empty.ToString() ) ) ,
                            Convert.ToInt32( Convertor.IsNull( tbmx.Rows[j]["ypid"] , "0" ) ) ,
                            tbmx.Rows[j]["货号"].ToString() ,
                            tbmx.Rows[j]["药品名称"].ToString() ,
                            tbmx.Rows[j]["药品名称"].ToString() ,
                            tbmx.Rows[j]["规格"].ToString() ,
                            tbmx.Rows[j]["厂家"].ToString() ,
                            tbmx.Rows[j]["单位"].ToString() ,
                            Convert.ToDecimal( Convertor.IsNull( tbmx.Rows[j]["ydwbl"] , "0" ) ) ,
                            tyl ,
                            tjs ,
                            pfj ,
                            Math.Round( Convert.ToDecimal( pfj * tyl * tjs ) , 3 ) ,
                            lsj ,
                            Math.Round( lsj * tyl * tjs , 3 ) ,
                            0 ,
                            0 ,
                            fyksid ,
                            new Guid( tbmx.Rows[j]["id"].ToString() ) ,
                            tbmx.Rows[j]["批号"].ToString() ,
                            id ,
                            new Guid( Convertor.IsNull( tbmx.Rows[j]["cfmxid"] , Guid.Empty.ToString() ) ) ,
                            tbmx.Rows[j]["皮试"].ToString() ,
                            tbmx.Rows[j]["用法"].ToString() ,
                            tbmx.Rows[j]["嘱托"].ToString() ,
                               "" ,
                                "" ,
                                "" ,
                                "" ,
                                0 ,
                                0 ,
                                0 ,
                            _pronamefymx ,
                            out fymxid ,
                            out err_code ,
                            out err_text
                            , Convert.ToDecimal( tbmx.Rows[j]["进价"] )
                            //, Math.Round( Convert.ToDecimal( pfj * tyl * tjs ) , 3 )
                            , Math.Round(Convert.ToDecimal(jhj * tyl * tjs), 3)//Modify By Tany 2018-01-25
                            , tbmx.Rows[j]["效期"].ToString()//?
                            , tbmx.Rows[j]["批次号"].ToString()
                            , new Guid( tbmx.Rows[j]["kcid"].ToString() ) ,
                            InstanceForm.BDatabase , bpcgl );

                        if ( err_code != 0 )
                        {
                            throw new System.Exception( err_text );
                        }


                        //回填FYID
                        if ( fyid != Guid.Empty && new Guid( Convertor.IsNull( tbmx.Rows[j]["fyid"] , Guid.Empty.ToString() ) ) == Guid.Empty )
                        {
                            MZYF.UpdateFymx_Fyid( id , fyid , out err_code , out err_text , InstanceForm.BDatabase );
                            if ( err_code != 0 )
                            {
                                throw new System.Exception( err_text );
                            }
                        }

                        //将预备退药的记录 插入大输液出库表 
                        ////////						if (Convert.ToDecimal(tbmx.Rows[j]["用量"])>0 && fymxid>0)
                        ////////						{
                        ////////							string ssql="insert into yf_mzdsyckb(fph,hzxm,cfxh,cfmxid,hjcfmxid,ggid,cjid,ypmc,ypgg,ypsl,cfts,ypdw,dwbl,lsj,lsje,execdeptid,ksdm,ysdm,djrq,djy,sqdjh,qytybz,bdel,fyid,fymxid)"+
                        ////////								"select top 1 fph,hzxm,cfxh,cfmxid,hjcfmxid,ggid,cjid,ypmc,ypgg,"+tyl+","+tjs+",ypdw,dwbl,lsj,"+lsj*tyl*tjs+",execdeptid,ksdm,ysdm,'"+sDate+"',"+InstanceForm.BCurrentUser.EmployeeId+",0,0,0,"+fyid+","+fymxid+" from yf_mzdsyckb"+
                        ////////								" where cfmxid="+Convert.ToInt64(Convertor.IsNull(tbmx.Rows[j]["cfmxid"],"0"))+" and ypsl>0 and bdel=0 order by id ";
                        ////////							int ncount=InstanceForm.BDatabase.DoCommand(ssql);
                        ////////
                        ////////						}
                        fymxid = Guid.Empty;

                    }
                    #endregion

                }

                string ssql = string.Format( " update yf_fy set jhje={0},TYYY = '{2}' where id='{1}'" , tyzjhje , fyid , tyyy.ResultValue.Value );
                if ( InstanceForm.BDatabase.DoCommand( ssql ) <= 0 )
                {
                    throw new Exception( "更新发药头表进货金额失败！" );
                }


                //////////				if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim()=="Fun_ts_yf_mzty_eyf")
                //////////					MZYF_DSYTL.Update_Mzdsyckb_QYTYBZ(Convert.ToInt64(Convertor.IsNull(tb.Rows[cfrow]["发票号"],"0")),_fyid,cmd);
                //////////				cmd.Parameters.Clear();


                InstanceForm.BDatabase.CommitTransaction();


                //同步老his退药状态
                try
                {
                    ClsMzTy.DoMzTY(cfxh.ToString());
                }
                catch (System.Exception err)
                {
                    this.butfy.Enabled = true;
                    MessageBox.Show("发生错误" + err.Message);
                }


                //				#region 清除页面
                //				DataTable tb2=(DataTable)this.myDataGrid1.DataSource;
                //				DataTable tb3=(DataTable)this.myDataGrid2.DataSource;
                //				tb2.Rows.Clear();
                //				tb3.Rows.Clear();

                this.butfy.Enabled = true;
                //				#endregion 

                //重新显示该发票
                //				_zje=0;
                //				_fyid=0;
                //				this.patientInfo1_IDTextBoxKeyPress(sender,new KeyPressEventArgs((char)13));


                //this.patientInfo1_IDTextBoxKeyPress(sender,new KeyPressEventArgs((char)13));
                this.txtfph.Focus();
                this.txtfph_KeyPress( txtfph , new System.Windows.Forms.KeyPressEventArgs( (char)13 ) );
                DataTable tbt = (DataTable)this.myDataGrid1.DataSource;
                if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_eyf" )
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell( tbt.Rows.Count - 1 , 1 );
                    this.myDataGrid2.CurrentCell = new DataGridCell( 0 , 4 );
                }



            }
            catch ( System.Exception err )
            {
                this.butfy.Enabled = true;
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show( "发生错误" + err.Message );
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butquit_Click( object sender , System.EventArgs e )
        {
            this.Close();
        }

        private void cmbph_KeyPress( object sender , System.Windows.Forms.KeyPressEventArgs e )
        {
            if ( Convert.ToInt32( e.KeyChar ) == 13 )
            {
                int nrow = this.myDataGrid2.CurrentCell.RowNumber;
                int ncol = this.myDataGrid2.CurrentCell.ColumnNumber;
                string columnName = this.myDataGrid2.TableStyles[0].GridColumnStyles[ncol].HeaderText.Trim();
                if ( columnName.Trim() == "批号" )
                {
                    DataTable tb = (DataTable)this.myDataGrid2.DataSource;
                    tb.Rows[nrow][ncol] = cmbph.Text;
                    this.myDataGrid2.CurrentCell = new DataGridCell( nrow , ncol + 1 );
                    return;
                }
                this.cmbph.Visible = false;
            }
        }

        private void cmbph_VisibleChanged( object sender , System.EventArgs e )
        {
            cmbph.Focus();
        }

        private void butprint_Click( object sender , System.EventArgs e )
        {
            try
            {



                DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
                if ( tb2.Rows.Count == 0 )
                {
                    MessageBox.Show( "没有可以打印的处方" );
                    return;
                }
                DataTable tb3 = (DataTable)this.myDataGrid2.DataSource;
                if ( tb3.Rows.Count <= 1 )
                {
                    MessageBox.Show( "没有可以打印的处方明细" );
                    return;
                }
                if ( this.myDataGrid2.CurrentCell.RowNumber > tb2.Rows.Count - 1 )
                    return;

                if ( Convert.ToDecimal( tb2.Rows[this.myDataGrid1.CurrentCell.RowNumber]["金额"] ) > 0 )
                {
                    MessageBox.Show( "请选择退药记录后再打印" );
                    return;
                }

                if ( chkxp.Checked == true )
                {
                    this.PrintCfXP();
                    return;
                }

                PrintCf( tb2.Rows[this.myDataGrid1.CurrentCell.RowNumber] );

            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message );
            }
        }

        private void PrintCfXP()
        {
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            DataTable tb1 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows = tb.Select( "用量<>''" );
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;


            if ( rows.Length == 0 )
                return;
            string cftsname = "";
            //cftsname=Convert.ToString(tb1.Rows[nrow]["项目"]).Trim()=="中草药"?"中药付数":"";
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow;
            for ( int i = 0 ; i <= rows.Length - 1 ; i++ )
            {
                //string[] HeaderText	={"序号","选","发票号","药品名称","规格","厂家","批发价","零售价","用量","剂数","批号","退用量","退剂数","单位","批发金额","零售金额","cfxh","ypid","ydwbl","货号","调价差额","cfts","id","fyid","tyid","deptid","cfmxid"};
                myrow = Dset.病人处方清单.NewRow();
                //myrow["xh"]=Convert.ToInt32(rows[i]["序号"]);
                myrow["ypmc"] = Convert.ToString( rows[i]["药品名称"] );
                myrow["ypgg"] = Convert.ToString( rows[i]["规格"] );
                myrow["sccj"] = Convert.ToString( rows[i]["厂家"] );
                myrow["lsj"] = Convert.ToDecimal( Convertor.IsNull( rows[i]["零售价"] , "0" ) );
                myrow["zje"] = Convert.ToDecimal( Convertor.IsNull( tb1.Rows[nrow]["金额"] , "0" ) );
                myrow["ypsl"] = Convertor.IsNull( rows[i]["用量"] , "0" );
                myrow["ypdw"] = Convert.ToString( rows[i]["单位"] );
                myrow["cfts"] = Convert.ToString( tb1.Rows[nrow]["项目"] ).Trim() == "中草药" ? rows[i]["剂数"] + "剂" : "";
                myrow["lsje"] = Convert.ToDecimal( Convertor.IsNull( rows[i]["零售金额"] , "0" ) );
                //				string UserEat="";
                //				UserEat=rows[i]["频次"].ToString().Trim()==""?"":Convert.ToDouble(rows[i]["剂量"]).ToString()+rows[i]["剂量单位"].ToString().Trim()+"/每次";
                //				myrow["yf"]=Convert.ToString(rows[i]["用法"])+"  "+rows[i]["使用频次"].ToString().Trim()+" "+UserEat;
                //				myrow["pc"]= rows[i]["使用频次"].ToString().Trim();
                //				myrow["syjl"]="";
                //				myrow["zt"]=Convert.ToString(rows[i]["嘱托"]);
                //				myrow["shh"]=Convert.ToString(rows[i]["货号"]);
                //				myrow["ksname"]=Convert.ToString(rows[i]["科室"]);//+"  费别:"+this.patientInfo1.FeeTypeName;
                //				string ysqm="";
                //				//if (Convert.ToString(row["医生签名"]).Trim()!="")  ysqm="   医生签名:"+Convert.ToString(rows[i]["医生签名"]);
                //				myrow["ysname"]=Convert.ToString(rows[i]["医生"])+ysqm;
                //				myrow["Pyck"]=rows[i]["皮试"].ToString();
                myrow["fph"] = Convert.ToString( tb1.Rows[nrow]["发票号"] );
                myrow["hzxm"] = Convert.ToString( tb1.Rows[nrow]["姓名"] );
                //				myrow["sex"]=Convert.ToString(rows[i]["性别"]);
                //				myrow["age"]=Convert.ToString(rows[i]["年龄"]);
                //				myrow["blh"]=Convert.ToString(rows[i]["门诊号"]);
                myrow["sfrq"] = Convert.ToString( tb1.Rows[nrow]["收费日期"] );
                //				myrow["pyr"]=this.cmbpyr.Text.Trim();;
                //				myrow["fyr"]=InstanceForm.BCurrentUser.Name;
                Dset.病人处方清单.Rows.Add( myrow );
            }

            ParameterEx[] parameters = new ParameterEx[1];
            parameters[0].Text = "TITLETEXT";
            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "退药明细单";
            bool bview = this.chkprrintView.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView( Dset.病人处方清单 , Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单列表_小票.rpt" , parameters , bview );
            if ( f.LoadReportSuccess )
                f.Show();
            else
                f.Dispose();

        }

        private void myDataGrid2_CurrentCellChanged( object sender , System.EventArgs e )
        {
            DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            int ncol = this.myDataGrid2.CurrentCell.ColumnNumber;
            if ( nrow >= myTb.Rows.Count )
                return;
            if ( myTb.Rows[nrow]["序号"].ToString().Trim() == "小计" )
                return;

            if ( !bpcgl ) //不进行批次管理
            {
                #region 查询当前药品可用的批号
                string ss = "   ";
                DataTable tab = MZYF.Selectkcph( Convert.ToInt32( Convertor.IsNull( myTb.Rows[nrow]["ypid"] , "0" ) ) , InstanceForm.BCurrentDept.DeptId , _menuTag.Function_Name.Trim() , InstanceForm.BDatabase );
                cmbph.DataSource = tab;
                cmbph.DisplayMember = "YPPH";

                string columnName = this.myDataGrid2.TableStyles[0].GridColumnStyles[ncol].HeaderText.Trim();
                this.cmbph.Visible = false;
                if ( columnName.Trim() == "批号" )
                {
                    if ( nrow > myTb.Rows.Count - 1 )
                        return;
                    this.cmbph.Left = this.myDataGrid2.GetCellBounds( nrow , ncol ).Left + this.myDataGrid2.Left;
                    this.cmbph.Top = this.myDataGrid2.GetCellBounds( nrow , ncol ).Top + this.myDataGrid2.Top;
                    this.cmbph.Width = this.myDataGrid2.GetCellBounds( nrow , ncol ).Width;

                    string ypph = myTb.Rows[nrow]["批号"].ToString().Trim();
                    if ( ypph != "" )
                        cmbph.Text = ypph.Trim();

                    this.cmbph.Visible = true;
                    return;
                }
                #endregion
            }

            //如果是医生
            if ( _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzty_ys" )
            {
                if ( new Guid( Convertor.IsNull( myTb.Rows[nrow]["fyid"].ToString() , Guid.Empty.ToString() ) ) == Guid.Empty )
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["选"].ReadOnly = false;
                else
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["选"].ReadOnly = true;
            }
            else
            {
                if ( Convertor.IsNull( myTb.Rows[nrow]["fyid"] , Guid.Empty.ToString() ) != Guid.Empty.ToString() && Convert.ToDecimal( myTb.Rows[nrow]["用量"] ) < 0 )
                {
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["选"].ReadOnly = true;
                }
                else
                    this.myDataGrid2.TableStyles[0].GridColumnStyles["选"].ReadOnly = true;
            }


            ////			if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_mzty_ys")
            ////			{
            ////				if (Convert.ToDecimal(Convertor.IsNull(myTb.Rows[nrow]["用量"],"0"))>=0)
            ////				{
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["退用量"].ReadOnly=false;
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].ReadOnly=false;
            ////				}
            ////				else
            ////				{
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["退用量"].ReadOnly=true;
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].ReadOnly=true;
            ////				}
            ////			}
            ////			else
            ////			{
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["退用量"].ReadOnly=true;
            ////					this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].ReadOnly=true;
            ////			}

            if ( cfg8001.Config == "1" )
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退用量"].ReadOnly = false;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].ReadOnly = false;
            }
            else
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退用量"].ReadOnly = true;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].ReadOnly = true;
            }
            if ( Convert.ToDecimal( Convertor.IsNull( myTb.Rows[nrow]["用量"] , "0" ) ) <= 0 )
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退用量"].ReadOnly = true;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].ReadOnly = true;
            }

            if ( cfg8025.Config == "1" && _menuTag.Function_Name != "Fun_ts_yf_mzty_ys" )
            {
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退用量"].ReadOnly = true;
                this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].ReadOnly = true;
            }
            this.myDataGrid2.TableStyles[0].GridColumnStyles["退剂数"].ReadOnly = true;
        }

        private void myDataGrid1_CurrentCellChanged( object sender , System.EventArgs e )
        {
            DataTable tbmx = (DataTable)this.myDataGrid2.DataSource;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;

            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if ( nrow >= tb.Rows.Count )
                return;

            //this.patientInfo1.LoadPatient(tb.Rows[nrow]["发票号"].ToString().Trim());
            Guid _xh = new Guid( Convertor.IsNull( tb.Rows[nrow]["xh"].ToString() , Guid.Empty.ToString() ) );
            Guid _fyid = new Guid( tb.Rows[nrow]["id"].ToString() );
            long _fph = Convert.ToInt64( tb.Rows[nrow]["发票号"] );
            //查找处方明细

            string _cflx = tb.Rows[nrow]["cflx"].ToString().Trim();
            SelectCf_Cfmx( _cflx , _xh , _fph , _fyid , Convert.ToDecimal( tb.Rows[nrow]["金额"] ) );

            //控制列的宽度和可读性

            ControlVisble( _cflx );

        }

        private void colText_CheckCellEnabled( object sender , DataGridEnableEventArgs e )
        {
            try
            {
                e.BackColor = Color.White;
                DataTable tb;
                if ( sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn" )
                {
                    DataGridEnableBoolColumn column = (DataGridEnableBoolColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                else
                {
                    DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                if ( e.Row > tb.Rows.Count - 1 )
                    return;

                if ( Convert.ToDecimal( Convertor.IsNull( tb.Rows[e.Row]["金额"] , "0" ) ) < 0 )
                    e.ForeColor = Color.Red;
                else
                    e.ForeColor = Color.Black;
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message );
                return;
            }
        }

        private void cmbph_SelectedIndexChanged( object sender , System.EventArgs e )
        {

        }


        #endregion

        private void buttjs_Click( object sender , System.EventArgs e )
        {

            int torow = 0;
            TrasenFrame.Forms.DlgInputBox f = new TrasenFrame.Forms.DlgInputBox( "0" , "请输入要退中药的剂数 " , "退剂数" );
            f.NumCtrl = true;
            f.ShowDialog();
            if ( TrasenFrame.Forms.DlgInputBox.DlgResult == true )
                torow = Convert.ToInt32( TrasenFrame.Forms.DlgInputBox.DlgValue );
            else
                return;

            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            if ( Convertor.IsNumeric( torow.ToString() ) == false )
            {
                MessageBox.Show( "请输入数字" );
                return;
            }

            for ( int i = 0 ; i <= tb.Rows.Count - 1 ; i++ )
            {
                if ( Convert.ToDecimal( Convertor.IsNull( tb.Rows[i]["用量"] , "0" ) ) > 0 && Convertor.IsNull( tb.Rows[i]["cfmxid"] , Guid.Empty.ToString() ) != Guid.Empty.ToString() )
                {
                    tb.Rows[i]["退剂数"] = torow.ToString();
                }
            }
        }


        private void txtfph_KeyPress( object sender , System.Windows.Forms.KeyPressEventArgs e )
        {
            try
            {
                Control control = (Control)sender;
                int nkey = Convert.ToInt32( e.KeyChar );
                if ( nkey == 13 )
                {
                    if ( control.Name == "txtlsh" && ( txtlsh.Text == "0" || ( Convertor.IsNumeric( txtlsh.Text ) == false && txtlsh.Text.Trim() != "" ) ) )
                    {
                        MessageBox.Show( "流水号请输入数字" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        return;
                    }
                    if ( control.Name == "txtfph" && ( txtfph.Text == "0" || ( Convertor.IsNumeric( txtfph.Text ) == false && txtfph.Text.Trim() != "" ) ) )
                    {
                        MessageBox.Show( "发票号请输入数字" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        return;
                    }

                    DataTable mytb_mx = (DataTable)this.myDataGrid2.DataSource;
                    mytb_mx.Rows.Clear();

                    DataTable mytb = (DataTable)this.myDataGrid1.DataSource;
                    mytb.Rows.Clear();


                    ts_mz_brxx.MzGhxx ghxx = null;
                    ts_mz_brxx.MzBrxx brxx = null;
                    if ( control.Name == "txtmzh" )
                        txtmzh.Text = FunBase.returnMzh( txtmzh.Text , InstanceForm.BDatabase , InstanceForm._menuTag.Jgbm );

                    Guid _brxxid = Guid.Empty;
                    string _mzh = txtmzh.Text;
                    long _dnlsh = Convert.ToInt64( Convertor.IsNull( txtlsh.Text , "0" ) );
                    string _fph = Convertor.IsNull( txtfph.Text , "0" );
                    Guid _fyid = Guid.Empty;
                    string _cfrq1 = "";
                    string _cfrq2 = "";



                    if ( ( control.Name == "txttmk" && control.Text.Trim() != "" ) || ( _mzh == "" && _dnlsh == 0 && _fph == "0" ) )
                    {
                        //txttmk.Text = Fun.returnKh( Convert.ToInt32( Convertor.IsNull( cmbklx.SelectedValue , "0" ) ) , txttmk.Text , InstanceForm.BDatabase );
                        ReadCard card = new ReadCard( Convert.ToInt32( Convertor.IsNull( cmbklx.SelectedValue , "0" ) ) , txttmk.Text , InstanceForm.BDatabase );
                        _brxxid = card.brxxid;
                        _cfrq1 = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).AddDays( -3 ).ToShortDateString() + " 00:00:00";
                        _cfrq2 = DateManager.ServerDateTimeByDBType( InstanceForm.BDatabase ).AddDays( 0 ).ToShortDateString() + " 23:59:59";
                        if ( _brxxid == Guid.Empty )
                            return;
                    }


                    DataTable tb = MZYF.Select_TY_Cf( InstanceForm.BCurrentDept.DeptId , _brxxid , _cfrq1 , _cfrq2 , _mzh , _dnlsh , _fph , _fyid , InstanceForm.BDatabase );
                    DataTable tbcopy = tb.Clone();
                    if ( tb.Rows.Count == 1 )
                        tbcopy.ImportRow( tb.Rows[0] );
                    else
                    {
                        FrmSel f = new FrmSel( _brxxid , _cfrq1 , _cfrq2 , _mzh , _dnlsh , _fph );
                        f.Left = 500;
                        f.Top = 500;
                        if ( _cfrq1 != "" )
                        {
                            f.chkcfrq.Checked = true;
                            f.dtprq1.Value = Convert.ToDateTime( _cfrq1 );
                            f.dtprq2.Value = Convert.ToDateTime( _cfrq2 );
                        }
                        DataTable tbx = (DataTable)f.dataGridView1.DataSource;
                        int x = 0;
                        for ( int i = 0 ; i <= tb.Rows.Count - 1 ; i++ )
                        {
                            DataRow row = tbx.NewRow();
                            x = x + 1;
                            row["序号"] = x.ToString();
                            row["选择"] = ( control.Name == "txtfph" || control.Name == "txtlsh" ) == true ? true : false;
                            row["门诊号"] = tb.Rows[i]["病历号"];
                            row["发票号"] = tb.Rows[i]["发票号"];
                            row["流水号"] = tb.Rows[i]["jssjh"];
                            row["姓名"] = tb.Rows[i]["姓名"];
                            row["金额"] = tb.Rows[i]["金额"];
                            row["发药科室"] = tb.Rows[i]["发药科室"];
                            row["发药日期"] = tb.Rows[i]["发药日期"];
                            row["id"] = tb.Rows[i]["id"];
                            tbx.Rows.Add( row );
                        }
                        f.ShowDialog();
                        if ( f.Bok == true )
                        {
                            /*
                             * update code by pengy 7-31
                             */
                            if (tb == null || tb.Rows.Count == 0)
                                tb = f.RetDataList;
                            DataRow[] rows = tbx.Select( "选择=true" );
                            for ( int i = 0 ; i <= rows.Length - 1 ; i++ )
                            {                                
                                DataRow[] selrow = tb.Select( "id='" + rows[i]["id"].ToString() + "'" );
                                if ( selrow.Length > 0 )
                                    tbcopy.ImportRow( selrow[0] );
                            }
                        }
                    }
                    if ( tbcopy.Rows.Count > 0 )
                    {
                        _brxxid = new Guid( tbcopy.Rows[0]["patid"].ToString() );
                        brxx = new ts_mz_brxx.MzBrxx( _brxxid , 0 , "" , "" , 0 , InstanceForm.BDatabase );
                        this.lblxm.Text = brxx.姓名;
                        this.lblxb.Text = brxx.性别;
                        this.lblnl.Text = brxx.年龄;
                        txtlsh.Text = tb.Rows[0]["jssjh"].ToString();
                    }



                    //if (control.Name=="txtfph")
                    //{
                    //    DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, "", Convert.ToInt64(Convertor.IsNull(txtfph.Text, "0")), 0, InstanceForm.BDatabase);
                    //    if (tbghxx.Rows.Count==0){MessageBox.Show("没有找到病人，请重新输入","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);return;}
                    //    ghxx=new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                    //    brxx = new ts_mz_brxx.MzBrxx(ghxx.binid, 0, "", "", 0, InstanceForm.BDatabase);
                    //}



                    //this.lblks.Text=ghxx.挂号科室名称;
                    //this.lblzd.Text=ghxx.诊断名称;


                    this.Cursor = PubStaticFun.WaitCursor();



                    //DataTable tb = MZYF.Select_TY_Cf(InstanceForm.BCurrentDept.DeptId, Guid.Empty, 1, 0, txtfph.Text, InstanceForm.BDatabase);
                    tbcopy.TableName = "tbcopy";
                    this.myDataGrid1.DataSource = tbcopy;
                    this.myDataGrid1.TableStyles[0].MappingName = "tbcopy";

                    if ( tbcopy.Rows.Count == 0 )
                        return;

                    _fyid = new Guid( tbcopy.Rows[0]["id"].ToString() );

                    //查找处方明细
                    string _cflx = tbcopy.Rows[0]["cflx"].ToString().Trim();
                    SelectCf_Cfmx( _cflx , new Guid( tbcopy.Rows[0]["xh"].ToString() ) , Convert.ToInt64( tbcopy.Rows[0]["发票号"] ) , _fyid , Convert.ToDecimal( tbcopy.Rows[0]["金额"] ) );

                    //控制列的宽度和可读性


                    ControlVisble( _cflx );


                }
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message );
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }


        }

        private void button5_Click( object sender , EventArgs e )
        {

        }

        private void myDataGrid2_Click( object sender , EventArgs e )
        {
            try
            {
                DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
                int nrow = this.myDataGrid2.CurrentCell.RowNumber;
                int ncol = this.myDataGrid2.CurrentCell.ColumnNumber;
                if ( nrow >= myTb.Rows.Count )
                    return;
                if ( myTb.Rows[nrow]["序号"].ToString().Trim() == "小计" )
                    return;

                if ( Convertor.IsNull( myTb.Rows[nrow]["fyid"] , Guid.Empty.ToString() ) == Guid.Empty.ToString()
                    && Convert.ToDecimal( myTb.Rows[nrow]["用量"] ) < 0 && _menuTag.Function_Name == "Fun_ts_yf_mzty_ys" )
                {
                    if ( Convert.ToBoolean( myTb.Rows[nrow]["选"] ) == true )
                        myTb.Rows[nrow]["选"] = false;
                    else
                        myTb.Rows[nrow]["选"] = true;
                }
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }

        }

    }
}
