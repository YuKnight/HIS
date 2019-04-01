using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using YpClass;
using ts_mz_class;
using System.Threading;
using System.Text;
using Ts_Hlyy_Interface;
using System.Collections.Generic;
using ts_call;
using ts_yf_mzkf;
using System.IO;
using System.Net;
using System.Data.SqlClient;
//using TrasenMainWindow;




namespace ts_yf_mzfy
{
    /// <summary>
    /// Frmcffy 的摘要说明。
    /// </summary>
    public class Frmcffy : System.Windows.Forms.Form, IMessageFilter
    {
        private DateTime PrintRq;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbpyr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button butfy;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butcfcx;
        private System.Windows.Forms.RadioButton rdols;
        private System.Windows.Forms.RadioButton rdodq;
        private System.Windows.Forms.CheckBox chkrq;
        private System.Windows.Forms.DateTimePicker dtprq2;
        private System.Windows.Forms.DateTimePicker dtprq1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid1;
        private System.Windows.Forms.CheckBox chkall;
        private System.Windows.Forms.CheckBox chkprintview;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.CheckBox chkprint;
        private System.Windows.Forms.RadioButton rdo1;
        private System.Windows.Forms.RadioButton rdo2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtmzh;
        private System.Windows.Forms.TextBox txttmk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtfph;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblxm;
        private System.Windows.Forms.Label lblxb;
        private System.Windows.Forms.Label lblnl;
        private System.Windows.Forms.Label lblks;
        private System.Windows.Forms.Label lblzd;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private YpConfig s;
        private string IPAddRess;
        private System.Windows.Forms.CheckBox chkxp;
        public string _Fyckh;
        public string _Fyckmc;
        private string kflx;
        private RadioButton rdo3;
        private Button butqhfyck;
        private TextBox _textBox;
        private Label label8;
        private TextBox txtxm;
        private ComboBox cmbklx;
        private Panel panel4;
        private CheckBox chkqd;
        private CheckBox chkcf;
        private CheckBox chkzsd;
        private TextBox txtlsh;
        private Label label6;
        private bool _ClickQuit = false;
        //定义报价器显示对象
        private ts_call.Icall _call;
        private Panel panel7;
        private Splitter splitter3;
        private Panel panel_left;
        private Panel panel5;
        private DataGridView dataGridView1;
        private Panel panel9;
        private Button button_ref;
        private Panel panel10;
        private DateTimePicker dtprq_ref;
        private Button buthj;
        //定义报价器显示的线程
        Thread thCall = null;
        private DataGridViewButtonColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn 发票号;
        private DataGridViewTextBoxColumn 金额;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn 打印;
        private DataGridViewTextBoxColumn fpid;
        private DataGridViewTextBoxColumn bfybz;
        private ComboBox cmbyf;
        private Label label9;
        private string cfg8027 = "0";
        private string cfghlyytype = "0";
        private HlyyInterface hlyyjk;
        private string hlyytype = "";

        private bool bpcgl = false; //是否进行批次管理 
        private string pcglfs = "0"; //0先进先出 1近效期先出
        private bool btjhj = false;
        private Button btnPy; //调进货价 

        ts_yf_mzkf.IMzkf kf = null;
        private Button btnhqcf;
        private Button btnReadCard;
        private Label label11;
        private ComboBox cmbFylb;
        private Label label13;
        private Button btnFpCk;
        private Button btnCancerOver;
        private Button btnOver;
        /// <summary>
        /// 是否启用快发
        /// </summary>
        private bool bqyyfkf = false;
        private CheckBox chkmj;
        private CheckBox chkJ2; //是否启用快发

        private string strFyKFCkFlag = "1";
        private CheckBox chkDJ;//此处添加发药窗口是否进行快发发药（424 中有的窗口用快发，但是不用快发发药的情况）

        //评价器 Add by zhujh 2017-0511
        YongTai yongtai = null;

        private class InventoryNotEnoughException : Exception
        {
            private object data;
            public object Data
            {
                get
                {
                    return data;
                }
                set
                {
                    data = value;
                }
            }
        }

        public Frmcffy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);


            //合理用药提示，lidan add 2013-09-16
            cfghlyytype = (new SystemCfg(8040)).Config;//8040参数，0代表不使用合理用药提示，1：大通

            hlyytype = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("hlyy", "name", System.Windows.Forms.Application.StartupPath + "\\Hlyy.ini");
            if (cfghlyytype != "0" && cfghlyytype != "")
            {
                hlyyjk = Ts_Hlyy_Interface.HlyyFactory.Hlyy("大通");
                hlyyjk.RegisterServer_fun(null);//打开四灯
                //hlyyjk.Refresh();//刷新四灯
            }



            if (s.门诊发药和退药时默认打印小票 == true)
                this.chkxp.Checked = true;
            else
                this.chkxp.Checked = false;
            //网址地址
            IPAddRess = PubStaticFun.GetMacAddress();
            try
            {
                kflx = ApiFunction.GetIniString("药房快发设置", "类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
            }
            catch
            { }


            try
            {
                // 1为真 表示走快发发药  0表示不走快发发药
                strFyKFCkFlag = ApiFunction.GetIniString("药房发药是否走快发程序设置", "设置开关", Constant.ApplicationDirectory + "//ClientWindow.ini");
            }
            catch
            { }

            if (strFyKFCkFlag == "")
            {
                strFyKFCkFlag = "1";
            }
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            //Add by Zhujh 2017-05-10
            yongtai = new YongTai();
            int intYongTai = yongtai.OpinionInit(1);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmcffy));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkrq = new System.Windows.Forms.CheckBox();
            this.dtprq2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtprq1 = new System.Windows.Forms.DateTimePicker();
            this.rdols = new System.Windows.Forms.RadioButton();
            this.rdodq = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnCancerOver = new System.Windows.Forms.Button();
            this.btnOver = new System.Windows.Forms.Button();
            this.btnFpCk = new System.Windows.Forms.Button();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.btnPy = new System.Windows.Forms.Button();
            this.cmbyf = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buthj = new System.Windows.Forms.Button();
            this.txtlsh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbklx = new System.Windows.Forms.ComboBox();
            this.txtxm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.butqhfyck = new System.Windows.Forms.Button();
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
            this.txttmk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butcfcx = new System.Windows.Forms.Button();
            this.txtmzh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.cmbpyr = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbFylb = new System.Windows.Forms.ComboBox();
            this.btnhqcf = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkDJ = new System.Windows.Forms.CheckBox();
            this.chkJ2 = new System.Windows.Forms.CheckBox();
            this.chkmj = new System.Windows.Forms.CheckBox();
            this.chkqd = new System.Windows.Forms.CheckBox();
            this.chkcf = new System.Windows.Forms.CheckBox();
            this.chkzsd = new System.Windows.Forms.CheckBox();
            this.chkxp = new System.Windows.Forms.CheckBox();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.chkprint = new System.Windows.Forms.CheckBox();
            this.chkprintview = new System.Windows.Forms.CheckBox();
            this.butfy = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.rdo3 = new System.Windows.Forms.RadioButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.发票号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.打印 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fpid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bfybz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button_ref = new System.Windows.Forms.Button();
            this.dtprq_ref = new System.Windows.Forms.DateTimePicker();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel_left.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkrq
            // 
            this.chkrq.AutoSize = true;
            this.chkrq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkrq.ForeColor = System.Drawing.Color.Black;
            this.chkrq.Location = new System.Drawing.Point(5, 63);
            this.chkrq.Name = "chkrq";
            this.chkrq.Size = new System.Drawing.Size(82, 18);
            this.chkrq.TabIndex = 12;
            this.chkrq.Text = "处方日期";
            this.chkrq.CheckedChanged += new System.EventHandler(this.chkrq_CheckedChanged);
            // 
            // dtprq2
            // 
            this.dtprq2.Enabled = false;
            this.dtprq2.Location = new System.Drawing.Point(236, 62);
            this.dtprq2.Name = "dtprq2";
            this.dtprq2.Size = new System.Drawing.Size(110, 21);
            this.dtprq2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(211, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "到";
            // 
            // dtprq1
            // 
            this.dtprq1.Enabled = false;
            this.dtprq1.Location = new System.Drawing.Point(93, 62);
            this.dtprq1.Name = "dtprq1";
            this.dtprq1.Size = new System.Drawing.Size(112, 21);
            this.dtprq1.TabIndex = 7;
            // 
            // rdols
            // 
            this.rdols.AutoSize = true;
            this.rdols.ForeColor = System.Drawing.Color.Black;
            this.rdols.Location = new System.Drawing.Point(752, 73);
            this.rdols.Name = "rdols";
            this.rdols.Size = new System.Drawing.Size(47, 16);
            this.rdols.TabIndex = 11;
            this.rdols.Text = "历史";
            // 
            // rdodq
            // 
            this.rdodq.AutoSize = true;
            this.rdodq.Checked = true;
            this.rdodq.ForeColor = System.Drawing.Color.Black;
            this.rdodq.Location = new System.Drawing.Point(752, 56);
            this.rdodq.Name = "rdodq";
            this.rdodq.Size = new System.Drawing.Size(47, 16);
            this.rdodq.TabIndex = 10;
            this.rdodq.TabStop = true;
            this.rdodq.Text = "当前";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(242, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "配药人";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.btnCancerOver);
            this.panel8.Controls.Add(this.btnOver);
            this.panel8.Controls.Add(this.btnFpCk);
            this.panel8.Controls.Add(this.btnReadCard);
            this.panel8.Controls.Add(this.btnPy);
            this.panel8.Controls.Add(this.cmbyf);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.buthj);
            this.panel8.Controls.Add(this.txtlsh);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.cmbklx);
            this.panel8.Controls.Add(this.txtxm);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.butqhfyck);
            this.panel8.Controls.Add(this.lblzd);
            this.panel8.Controls.Add(this.label16);
            this.panel8.Controls.Add(this.lblks);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Controls.Add(this.lblnl);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.lblxb);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.lblxm);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.txtfph);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.txttmk);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.butcfcx);
            this.panel8.Controls.Add(this.txtmzh);
            this.panel8.Controls.Add(this.dtprq1);
            this.panel8.Controls.Add(this.dtprq2);
            this.panel8.Controls.Add(this.chkrq);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.rdols);
            this.panel8.Controls.Add(this.rdodq);
            this.panel8.Controls.Add(this.butquit);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1147, 91);
            this.panel8.TabIndex = 1;
            // 
            // btnCancerOver
            // 
            this.btnCancerOver.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancerOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancerOver.ForeColor = System.Drawing.Color.Navy;
            this.btnCancerOver.Location = new System.Drawing.Point(920, 31);
            this.btnCancerOver.Name = "btnCancerOver";
            this.btnCancerOver.Size = new System.Drawing.Size(80, 24);
            this.btnCancerOver.TabIndex = 50;
            this.btnCancerOver.Text = "取消过号";
            this.btnCancerOver.UseVisualStyleBackColor = false;
            this.btnCancerOver.Visible = false;
            this.btnCancerOver.Click += new System.EventHandler(this.btnCancerOver_Click);
            // 
            // btnOver
            // 
            this.btnOver.BackColor = System.Drawing.SystemColors.Control;
            this.btnOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOver.ForeColor = System.Drawing.Color.Navy;
            this.btnOver.Location = new System.Drawing.Point(805, 31);
            this.btnOver.Name = "btnOver";
            this.btnOver.Size = new System.Drawing.Size(109, 24);
            this.btnOver.TabIndex = 49;
            this.btnOver.Text = "过号";
            this.btnOver.UseVisualStyleBackColor = false;
            this.btnOver.Visible = false;
            this.btnOver.Click += new System.EventHandler(this.btnOver_Click);
            // 
            // btnFpCk
            // 
            this.btnFpCk.BackColor = System.Drawing.SystemColors.Control;
            this.btnFpCk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFpCk.ForeColor = System.Drawing.Color.Navy;
            this.btnFpCk.Location = new System.Drawing.Point(652, 31);
            this.btnFpCk.Name = "btnFpCk";
            this.btnFpCk.Size = new System.Drawing.Size(75, 24);
            this.btnFpCk.TabIndex = 48;
            this.btnFpCk.Text = "转一楼药房";
            this.btnFpCk.UseVisualStyleBackColor = false;
            this.btnFpCk.Click += new System.EventHandler(this.btnFpCk_Click);
            // 
            // btnReadCard
            // 
            this.btnReadCard.BackColor = System.Drawing.SystemColors.Control;
            this.btnReadCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReadCard.ForeColor = System.Drawing.Color.Navy;
            this.btnReadCard.Location = new System.Drawing.Point(480, 5);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(38, 24);
            this.btnReadCard.TabIndex = 47;
            this.btnReadCard.Text = "读卡";
            this.btnReadCard.UseVisualStyleBackColor = false;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // btnPy
            // 
            this.btnPy.BackColor = System.Drawing.SystemColors.Control;
            this.btnPy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPy.ForeColor = System.Drawing.Color.Navy;
            this.btnPy.Location = new System.Drawing.Point(726, 31);
            this.btnPy.Name = "btnPy";
            this.btnPy.Size = new System.Drawing.Size(80, 24);
            this.btnPy.TabIndex = 46;
            this.btnPy.Text = "配药(F12)";
            this.btnPy.UseVisualStyleBackColor = false;
            this.btnPy.Click += new System.EventHandler(this.btnPy_Click);
            // 
            // cmbyf
            // 
            this.cmbyf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyf.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbyf.Location = new System.Drawing.Point(576, 61);
            this.cmbyf.Name = "cmbyf";
            this.cmbyf.Size = new System.Drawing.Size(168, 22);
            this.cmbyf.TabIndex = 45;
            this.cmbyf.SelectedIndexChanged += new System.EventHandler(this.cmbyf_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(521, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 44;
            this.label9.Text = "药  房";
            // 
            // buthj
            // 
            this.buthj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buthj.ForeColor = System.Drawing.Color.Navy;
            this.buthj.Location = new System.Drawing.Point(921, 31);
            this.buthj.Name = "buthj";
            this.buthj.Size = new System.Drawing.Size(80, 24);
            this.buthj.TabIndex = 43;
            this.buthj.Text = "呼叫(&F9)";
            this.buthj.Click += new System.EventHandler(this.buthj_Click);
            // 
            // txtlsh
            // 
            this.txtlsh.BackColor = System.Drawing.Color.White;
            this.txtlsh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtlsh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtlsh.Location = new System.Drawing.Point(805, 6);
            this.txtlsh.Name = "txtlsh";
            this.txtlsh.Size = new System.Drawing.Size(196, 21);
            this.txtlsh.TabIndex = 41;
            this.txtlsh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(750, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 42;
            this.label6.Text = "流水号";
            // 
            // cmbklx
            // 
            this.cmbklx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbklx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbklx.Location = new System.Drawing.Point(275, 6);
            this.cmbklx.Name = "cmbklx";
            this.cmbklx.Size = new System.Drawing.Size(57, 22);
            this.cmbklx.TabIndex = 40;
            // 
            // txtxm
            // 
            this.txtxm.BackColor = System.Drawing.Color.White;
            this.txtxm.Enabled = false;
            this.txtxm.Location = new System.Drawing.Point(393, 62);
            this.txtxm.Name = "txtxm";
            this.txtxm.Size = new System.Drawing.Size(122, 21);
            this.txtxm.TabIndex = 39;
            this.txtxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtxm_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(352, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 38;
            this.label8.Text = "姓名";
            // 
            // butqhfyck
            // 
            this.butqhfyck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butqhfyck.ForeColor = System.Drawing.Color.Navy;
            this.butqhfyck.Location = new System.Drawing.Point(811, 31);
            this.butqhfyck.Name = "butqhfyck";
            this.butqhfyck.Size = new System.Drawing.Size(103, 24);
            this.butqhfyck.TabIndex = 36;
            this.butqhfyck.Text = "切换发药窗口";
            this.butqhfyck.Click += new System.EventHandler(this.butqhfyck_Click);
            // 
            // lblzd
            // 
            this.lblzd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblzd.Location = new System.Drawing.Point(576, 32);
            this.lblzd.Name = "lblzd";
            this.lblzd.Size = new System.Drawing.Size(75, 22);
            this.lblzd.TabIndex = 35;
            this.lblzd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(521, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 14);
            this.label16.TabIndex = 34;
            this.label16.Text = "诊  断";
            // 
            // lblks
            // 
            this.lblks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblks.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblks.Location = new System.Drawing.Point(393, 31);
            this.lblks.Name = "lblks";
            this.lblks.Size = new System.Drawing.Size(121, 22);
            this.lblks.TabIndex = 33;
            this.lblks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(352, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 14);
            this.label14.TabIndex = 32;
            this.label14.Text = "科室";
            // 
            // lblnl
            // 
            this.lblnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblnl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblnl.Location = new System.Drawing.Point(274, 31);
            this.lblnl.Name = "lblnl";
            this.lblnl.Size = new System.Drawing.Size(72, 22);
            this.lblnl.TabIndex = 31;
            this.lblnl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(233, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 30;
            this.label12.Text = "年龄";
            // 
            // lblxb
            // 
            this.lblxb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblxb.Location = new System.Drawing.Point(190, 31);
            this.lblxb.Name = "lblxb";
            this.lblxb.Size = new System.Drawing.Size(37, 22);
            this.lblxb.TabIndex = 29;
            this.lblxb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(149, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 28;
            this.label10.Text = "性别";
            // 
            // lblxm
            // 
            this.lblxm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblxm.Location = new System.Drawing.Point(59, 32);
            this.lblxm.Name = "lblxm";
            this.lblxm.Size = new System.Drawing.Size(84, 22);
            this.lblxm.TabIndex = 27;
            this.lblxm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(5, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 26;
            this.label7.Text = "姓  名";
            // 
            // txtfph
            // 
            this.txtfph.BackColor = System.Drawing.Color.White;
            this.txtfph.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfph.Location = new System.Drawing.Point(576, 6);
            this.txtfph.Name = "txtfph";
            this.txtfph.Size = new System.Drawing.Size(168, 21);
            this.txtfph.TabIndex = 0;
            this.txtfph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            this.txtfph.Enter += new System.EventHandler(this.txttmk_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(521, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 23;
            this.label4.Text = "发票号";
            // 
            // txttmk
            // 
            this.txttmk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttmk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txttmk.Location = new System.Drawing.Point(333, 6);
            this.txttmk.Name = "txttmk";
            this.txttmk.Size = new System.Drawing.Size(146, 21);
            this.txttmk.TabIndex = 2;
            this.txttmk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            this.txttmk.Enter += new System.EventHandler(this.txttmk_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(185, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "卡类型/卡号";
            // 
            // butcfcx
            // 
            this.butcfcx.Enabled = false;
            this.butcfcx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butcfcx.ForeColor = System.Drawing.Color.Navy;
            this.butcfcx.Location = new System.Drawing.Point(805, 63);
            this.butcfcx.Name = "butcfcx";
            this.butcfcx.Size = new System.Drawing.Size(109, 24);
            this.butcfcx.TabIndex = 19;
            this.butcfcx.Text = "查询(&F)";
            this.butcfcx.Click += new System.EventHandler(this.butcfcx_Click);
            // 
            // txtmzh
            // 
            this.txtmzh.BackColor = System.Drawing.Color.White;
            this.txtmzh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmzh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtmzh.Location = new System.Drawing.Point(59, 6);
            this.txtmzh.Name = "txtmzh";
            this.txtmzh.Size = new System.Drawing.Size(120, 21);
            this.txtmzh.TabIndex = 0;
            this.txtmzh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            this.txtmzh.Enter += new System.EventHandler(this.txttmk_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "门诊号";
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.Control;
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(921, 62);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(80, 24);
            this.butquit.TabIndex = 15;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkall.ForeColor = System.Drawing.Color.Black;
            this.chkall.Location = new System.Drawing.Point(179, 8);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(56, 18);
            this.chkall.TabIndex = 20;
            this.chkall.Text = "全选";
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // cmbpyr
            // 
            this.cmbpyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyr.Location = new System.Drawing.Point(289, 8);
            this.cmbpyr.Name = "cmbpyr";
            this.cmbpyr.Size = new System.Drawing.Size(89, 20);
            this.cmbpyr.TabIndex = 11;
            this.cmbpyr.SelectedIndexChanged += new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
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
            this.imageList1.Images.SetKeyName(5, "无灯.jpg");
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.panel17);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1149, 48);
            this.panel6.TabIndex = 10;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel17.Controls.Add(this.label13);
            this.panel17.Controls.Add(this.label11);
            this.panel17.Controls.Add(this.cmbFylb);
            this.panel17.Controls.Add(this.btnhqcf);
            this.panel17.Controls.Add(this.panel4);
            this.panel17.Controls.Add(this.rdo2);
            this.panel17.Controls.Add(this.rdo1);
            this.panel17.Controls.Add(this.chkprint);
            this.panel17.Controls.Add(this.chkprintview);
            this.panel17.Controls.Add(this.butfy);
            this.panel17.Controls.Add(this.butprint);
            this.panel17.Controls.Add(this.cmbpyr);
            this.panel17.Controls.Add(this.label5);
            this.panel17.Controls.Add(this.chkall);
            this.panel17.Controls.Add(this.rdo3);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1149, 48);
            this.panel17.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(272, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 12);
            this.label13.TabIndex = 42;
            this.label13.Text = "(中草药上传选择)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(97, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 41;
            this.label11.Text = "发药类别";
            // 
            // cmbFylb
            // 
            this.cmbFylb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFylb.Enabled = false;
            this.cmbFylb.FormattingEnabled = true;
            this.cmbFylb.Location = new System.Drawing.Point(153, 27);
            this.cmbFylb.Name = "cmbFylb";
            this.cmbFylb.Size = new System.Drawing.Size(116, 20);
            this.cmbFylb.TabIndex = 40;
            // 
            // btnhqcf
            // 
            this.btnhqcf.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnhqcf.ForeColor = System.Drawing.Color.Navy;
            this.btnhqcf.Location = new System.Drawing.Point(726, 3);
            this.btnhqcf.Name = "btnhqcf";
            this.btnhqcf.Size = new System.Drawing.Size(99, 42);
            this.btnhqcf.TabIndex = 39;
            this.btnhqcf.Text = " 获取老系      统处方(&G)";
            this.btnhqcf.Click += new System.EventHandler(this.btnhqcf_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkDJ);
            this.panel4.Controls.Add(this.chkJ2);
            this.panel4.Controls.Add(this.chkmj);
            this.panel4.Controls.Add(this.chkqd);
            this.panel4.Controls.Add(this.chkcf);
            this.panel4.Controls.Add(this.chkzsd);
            this.panel4.Controls.Add(this.chkxp);
            this.panel4.Location = new System.Drawing.Point(385, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 44);
            this.panel4.TabIndex = 38;
            // 
            // chkDJ
            // 
            this.chkDJ.AutoSize = true;
            this.chkDJ.Checked = true;
            this.chkDJ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDJ.Location = new System.Drawing.Point(102, 23);
            this.chkDJ.Name = "chkDJ";
            this.chkDJ.Size = new System.Drawing.Size(48, 16);
            this.chkDJ.TabIndex = 39;
            this.chkDJ.Text = "毒剧";
            this.chkDJ.UseVisualStyleBackColor = true;
            // 
            // chkJ2
            // 
            this.chkJ2.AutoSize = true;
            this.chkJ2.Checked = true;
            this.chkJ2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJ2.Location = new System.Drawing.Point(177, 22);
            this.chkJ2.Name = "chkJ2";
            this.chkJ2.Size = new System.Drawing.Size(48, 16);
            this.chkJ2.TabIndex = 38;
            this.chkJ2.Text = "精二";
            this.chkJ2.UseVisualStyleBackColor = true;
            // 
            // chkmj
            // 
            this.chkmj.AutoSize = true;
            this.chkmj.Location = new System.Drawing.Point(176, 2);
            this.chkmj.Name = "chkmj";
            this.chkmj.Size = new System.Drawing.Size(72, 16);
            this.chkmj.TabIndex = 37;
            this.chkmj.Text = "麻、精一";
            this.chkmj.UseVisualStyleBackColor = true;
            // 
            // chkqd
            // 
            this.chkqd.AutoSize = true;
            this.chkqd.Location = new System.Drawing.Point(3, 3);
            this.chkqd.Name = "chkqd";
            this.chkqd.Size = new System.Drawing.Size(72, 16);
            this.chkqd.TabIndex = 31;
            this.chkqd.Text = "门诊清单";
            this.chkqd.UseVisualStyleBackColor = true;
            // 
            // chkcf
            // 
            this.chkcf.AutoSize = true;
            this.chkcf.Location = new System.Drawing.Point(102, 2);
            this.chkcf.Name = "chkcf";
            this.chkcf.Size = new System.Drawing.Size(72, 16);
            this.chkcf.TabIndex = 30;
            this.chkcf.Text = "门诊处方";
            this.chkcf.UseVisualStyleBackColor = true;
            // 
            // chkzsd
            // 
            this.chkzsd.AutoSize = true;
            this.chkzsd.Checked = true;
            this.chkzsd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkzsd.Location = new System.Drawing.Point(3, 24);
            this.chkzsd.Name = "chkzsd";
            this.chkzsd.Size = new System.Drawing.Size(96, 16);
            this.chkzsd.TabIndex = 29;
            this.chkzsd.Text = "门诊注射处方";
            this.chkzsd.UseVisualStyleBackColor = true;
            // 
            // chkxp
            // 
            this.chkxp.Checked = true;
            this.chkxp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkxp.Location = new System.Drawing.Point(102, 24);
            this.chkxp.Name = "chkxp";
            this.chkxp.Size = new System.Drawing.Size(97, 17);
            this.chkxp.TabIndex = 36;
            this.chkxp.Text = "默认打印小票";
            this.chkxp.Visible = false;
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Location = new System.Drawing.Point(91, 9);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(83, 16);
            this.rdo2.TabIndex = 20;
            this.rdo2.Text = "已发药处方";
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point(3, 9);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(83, 16);
            this.rdo1.TabIndex = 19;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "未发药处方";
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // chkprint
            // 
            this.chkprint.AutoSize = true;
            this.chkprint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkprint.Location = new System.Drawing.Point(939, 28);
            this.chkprint.Name = "chkprint";
            this.chkprint.Size = new System.Drawing.Size(84, 16);
            this.chkprint.TabIndex = 18;
            this.chkprint.Text = "发药时打印";
            // 
            // chkprintview
            // 
            this.chkprintview.AutoSize = true;
            this.chkprintview.Location = new System.Drawing.Point(939, 9);
            this.chkprintview.Name = "chkprintview";
            this.chkprintview.Size = new System.Drawing.Size(84, 16);
            this.chkprintview.TabIndex = 17;
            this.chkprintview.Text = "打印时预览";
            // 
            // butfy
            // 
            this.butfy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butfy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butfy.ForeColor = System.Drawing.Color.Navy;
            this.butfy.Location = new System.Drawing.Point(638, 3);
            this.butfy.Name = "butfy";
            this.butfy.Size = new System.Drawing.Size(81, 42);
            this.butfy.TabIndex = 13;
            this.butfy.Text = "发药(&O)";
            this.butfy.UseVisualStyleBackColor = false;
            this.butfy.Click += new System.EventHandler(this.butfy_Click);
            // 
            // butprint
            // 
            this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprint.ForeColor = System.Drawing.Color.Navy;
            this.butprint.Location = new System.Drawing.Point(832, 3);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(99, 42);
            this.butprint.TabIndex = 14;
            this.butprint.Text = "打印处方(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // rdo3
            // 
            this.rdo3.AutoSize = true;
            this.rdo3.Location = new System.Drawing.Point(3, 31);
            this.rdo3.Name = "rdo3";
            this.rdo3.Size = new System.Drawing.Size(71, 16);
            this.rdo3.TabIndex = 37;
            this.rdo3.Text = "退药处方";
            this.rdo3.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 48);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 468);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(2, 492);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1147, 24);
            this.statusBar1.TabIndex = 15;
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
            this.statusBarPanel2.Width = 180;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 770;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1147, 444);
            this.panel2.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 444);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.splitter3);
            this.panel3.Controls.Add(this.panel_left);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1147, 353);
            this.panel3.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.myDataGrid1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(249, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(898, 353);
            this.panel7.TabIndex = 3;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.GridLineColor = System.Drawing.Color.SeaGreen;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myDataGrid1.Size = new System.Drawing.Size(898, 353);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.DataSourceChanged += new System.EventHandler(this.myDataGrid1_DataSourceChanged);
            this.myDataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.myDataGrid1_Paint);
            this.myDataGrid1.BindingContextChanged += new System.EventHandler(this.myDataGrid1_BindingContextChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridLineColor = System.Drawing.Color.Silver;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 0;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(244, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(5, 353);
            this.splitter3.TabIndex = 2;
            this.splitter3.TabStop = false;
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.panel5);
            this.panel_left.Controls.Add(this.panel9);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(244, 353);
            this.panel_left.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(244, 329);
            this.panel5.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.发票号,
            this.金额,
            this.Column3,
            this.打印,
            this.fpid,
            this.bfybz});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(244, 329);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "序号";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "姓名";
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 55;
            // 
            // 发票号
            // 
            this.发票号.DataPropertyName = "发票号";
            this.发票号.HeaderText = "发票号";
            this.发票号.Name = "发票号";
            this.发票号.ReadOnly = true;
            this.发票号.Width = 70;
            // 
            // 金额
            // 
            this.金额.DataPropertyName = "金额";
            this.金额.HeaderText = "金额";
            this.金额.Name = "金额";
            this.金额.ReadOnly = true;
            this.金额.Width = 55;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "brxxid";
            this.Column3.HeaderText = "brxxid";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // 打印
            // 
            this.打印.DataPropertyName = "打印";
            this.打印.HeaderText = "打印";
            this.打印.Name = "打印";
            this.打印.ReadOnly = true;
            this.打印.Visible = false;
            // 
            // fpid
            // 
            this.fpid.DataPropertyName = "fpid";
            this.fpid.HeaderText = "fpid";
            this.fpid.Name = "fpid";
            this.fpid.ReadOnly = true;
            this.fpid.Visible = false;
            // 
            // bfybz
            // 
            this.bfybz.DataPropertyName = "bfybz";
            this.bfybz.HeaderText = "bfybz";
            this.bfybz.Name = "bfybz";
            this.bfybz.ReadOnly = true;
            this.bfybz.Visible = false;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.dtprq_ref);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(244, 24);
            this.panel9.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.button_ref);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(112, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(132, 24);
            this.panel10.TabIndex = 2;
            // 
            // button_ref
            // 
            this.button_ref.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ref.Location = new System.Drawing.Point(0, 0);
            this.button_ref.Name = "button_ref";
            this.button_ref.Size = new System.Drawing.Size(132, 24);
            this.button_ref.TabIndex = 0;
            this.button_ref.Text = "刷新(&F5)";
            this.button_ref.UseVisualStyleBackColor = true;
            this.button_ref.Click += new System.EventHandler(this.button_ref_Click);
            // 
            // dtprq_ref
            // 
            this.dtprq_ref.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtprq_ref.Location = new System.Drawing.Point(0, 0);
            this.dtprq_ref.Name = "dtprq_ref";
            this.dtprq_ref.Size = new System.Drawing.Size(112, 21);
            this.dtprq_ref.TabIndex = 1;
            // 
            // Frmcffy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1149, 516);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel6);
            this.KeyPreview = true;
            this.Name = "Frmcffy";
            this.Text = "门诊发药";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmcffy_Load);
            this.Activated += new System.EventHandler(this.Frmcffy_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frmcffy_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frmcffy_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frmcffy_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frmcffy_KeyDown);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel_left.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        //加载窗口
        private void Frmcffy_Load(object sender, System.EventArgs e)
        {
            btnFpCk.Visible = false;
            btnFpCk.Visible = InstanceForm.BCurrentDept.DeptId == 424;

            Application.AddMessageFilter(this);

            cmbpyr.SelectedIndexChanged -= new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
            Yp.AddcmbPyr(InstanceForm.BCurrentDept.DeptId, cmbpyr, InstanceForm.BDatabase);
            cmbpyr.SelectedValue = Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId);
            //cmbpyr.SelectedValue = DBNull.Value;
            cmbpyr.SelectedIndexChanged += new System.EventHandler(this.cmbpyr_SelectedIndexChanged);

            CshMxGrid(this.myDataGrid1);
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            this.dtprq1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//.AddDays(-3);
            this.dtprq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            this.chkrq.Checked = false;

            IPAddRess = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
            butqhfyck.Text = butqhfyck.Text + "(" + _Fyckh.Trim() + "窗)";
            if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_cx")
                this.butfy.Visible = false;
            this.txtmzh.Focus();

            Yp.AddcmbYjks(false, cmbyf, DeptType.药房, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
            cmbyf.SelectedValue = InstanceForm.BCurrentDept.DeptId.ToString();

            if ((new SystemCfg(8006)).Config == "0")
                this.myDataGrid1.TableStyles[0].GridColumnStyles["医生"].Width = 0;



            //string cfgs = new SystemCfg(8010).Config;
            //if (cfgs == "1") rdocfgs.Checked = true;
            //if (cfgs == "0") rdoqdgs.Checked = true;
            //if (cfgs == "2") rdoall.Checked = true;
            if (s.门诊发药时打印处方 == true)
                chkcf.Checked = true;
            if (s.门诊发药时打印清单 == true)
                chkqd.Checked = true;
            if (s.门诊发药时打印注射单 == true)
                chkzsd.Checked = true;

            if (s.门诊发药时默认打印处方 == true)
                chkprint.Checked = true;

            //增加药房快发控制
            if (s.药房快发 == true)
                bqyyfkf = true;


            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txttmk);

            try
            {
                string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                _call = ts_call.CallFactory.NewCall(bjqxh);
            }
            catch (System.Exception err)
            {
            }

            cfg8027 = (new SystemCfg(8027)).Config;
            if (cfg8027 == "0")
                panel_left.Visible = false;
            if (cfg8027 == "2")
            {
                发票号.Visible = false;
                Column2.Width = Column2.Width + 15;
                金额.Width = 金额.Width + 15;
                panel_left.Width = panel_left.Width - 发票号.Width + 20;
            }
            if (cfg8027 != "0")
                button_ref_Click(sender, e);


            //打开灯
            if (cfghlyytype != "0" && cfghlyytype != "")
            {
                hlyyjk = Ts_Hlyy_Interface.HlyyFactory.Hlyy("大通");
                hlyyjk.RegisterServer_fun(null);//打开四灯
                hlyyjk.Refresh();
            }

            SystemCfg cfg8051 = new SystemCfg(8051);
            pcglfs = cfg8051.Config;

            //调进货价
            SystemCfg cfg8056 = new SystemCfg(8056);
            if (cfg8056.Config == "1")
            {
                btjhj = true;
            }

            SetDefaultFocuse();

            //增加ini设置
            IsVisable();

            SystemCfg sc = new SystemCfg(10025);
            if (sc != null && !string.IsNullOrEmpty(sc.Config) && sc.Config.Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
            {
                btnPy.Visible = true;
            }
            else
            {
                btnPy.Visible = false;
                lblzd.Width += btnPy.Width;
            }

            if (bqyyfkf)
            {
                string bjqxh = ApiFunction.GetIniString("药房快发设置", "类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
                kf = ts_yf_mzkf.CallFactory.NewMzkf(bjqxh);//
            }

            if (kf is IMzkf)
            {
                //如果启用门诊快发,不支持多个病人同时配药和发药
                chkall.Visible = false;
            }

            //Modify by jchl
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "-1", "全部" });
                dt.Rows.Add(new object[] { "1", "本科室发药" });
                dt.Rows.Add(new object[] { "2", "待上传外包" });

                Addcmb(cmbFylb, dt, "id", "name");

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_ZCY")
                {
                    cmbFylb.SelectedIndex = 2;
                    //rdCydy.Visible = false;
                    //rdCffy.Checked = true;
                }
                else if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_YFFY")
                {
                    cmbFylb.SelectedIndex = 1;

                    //过号 取消过号设置
                    btnOver.Visible = true;
                    btnCancerOver.Visible = true;
                    butqhfyck.Visible = false;
                    btnFpCk.Visible = false;
                    buthj.Visible = false;
                }
                else
                {
                    cmbFylb.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private void SetDefaultFocuse()
        {
            /*
             * 门诊配发药要求参数控制光标定位至卡号框
             * update code by py 7-1 19:25
            */
            string iniPath = string.Format("{0}\\ClientWindow.ini", Application.StartupPath);
            if (System.IO.File.Exists(iniPath))
            {
                string iniConfig = ApiFunction.GetIniString("门诊发药", "卡号优先获得焦点", iniPath);
                if (string.IsNullOrEmpty(iniConfig))
                    ApiFunction.WriteIniString("门诊发药", "卡号优先获得焦点", "true", iniPath);
                iniConfig = ApiFunction.GetIniString("门诊发药", "卡号优先获得焦点", iniPath);
                if (!string.IsNullOrEmpty(iniConfig))
                {
                    try
                    {
                        if (Convert.ToBoolean(iniConfig))
                        {
                            txttmk.Focus();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        #region 原来的列创建
        //private void CshMxGridA(TrasenClasses.GeneralControls.ButtonDataGridEx xcjwDataGrid)
        //{
        //    #region 添加明细的列

        //    //string[] HeaderText ={ "序号", "发药", "皮试", "发票号", "项目", "总金额", "姓名", "剂型", "商品名", "品名", "用量", "单位", "规格", "厂家", "单价", "库存", "剂数", "金额", "门诊号", "性别", "年龄", "诊断", "科室", "医生", "煎药", "用法", "频次", "剂量", "剂量单位", "天数", "组标志", "排序序号", "录入日期", "录入员", "收费日期", "记费员", "发药日期", "发药员", "配药员", "处方号", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "配药窗口", "发药窗口", "记帐金额", "优惠金额", "自付金额", "YPID", "YDWBL", "cfmxid", "嘱托", "批发价", "批发金额", "使用频次", "货号", "单位规格", "zsyp", "fpid", "发票流水号", "中药备注", "备注2", "备注3" };
        //    //string[] MappingName ={ "序号", "发药", "皮试", "发票号", "项目", "总金额", "姓名", "剂型", "商品名", "品名", "用量", "单位", "规格", "厂家", "单价", "库存", "剂数", "金额", "门诊号", "性别", "年龄", "诊断", "科室", "医生", "煎药", "用法", "频次", "剂量", "剂量单位", "天数", "组标志", "排序序号", "录入日期", "录入员", "收费日期", "记费员", "发药日期", "发药员", "配药员", "处方号", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "配药窗口", "发药窗口", "记帐金额", "优惠金额", "自付金额", "YPID", "YDWBL", "cfmxid", "嘱托", "批发价", "批发金额", "使用频次", "货号", "单位规格", "zsyp", "fpid", "发票流水号", "中药备注", "备注2", "备注3" };
        //    //int[] ColWidth ={ 40, 30, 30, 60, 0, 0, 60, 0, 110, 110, 50/*ypsl*/, 40, 90, 90, 60, 0, 40, 65, 70, 40, 40, 70, 0, 50, 0, 0/*userage*/, 0, 0, 0, 0, 0, 0, 90, 60, 90/*发费日期*/, 0, 90, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 80,0,90,150 ,50,50};
        //    //bool[] ColReadOnly ={ true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true,true,true,true,true,true,true };
        //    //bool[] ColBool ={ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

        //    //ncq 2014-04-16 添加tycfmxid 
        //    string[] HeaderText ={ "序号", "警示灯", "发药", "皮试", "项目", "总金额", "姓名", "商品名", "品名", "规格", "单位", "用量", "剂数", "用法", "频次", "单价", "金额", "库存", "医生", "科室", "发票号", "门诊号", "性别", "年龄", "剂型", "厂家", "诊断", "煎药", "剂量", "剂量单位", "天数", "组标志", "排序序号", "录入员", "录入日期", "收费日期", "记费员", "发药日期", "发药员", "配药员", "处方号", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "配药窗口", "发药窗口", "记帐金额", "优惠金额", "自付金额", "YPID", "YDWBL", "cfmxid", "嘱托", "批发价", "批发金额", "使用频次", "货号", "单位规格", "zsyp", "fpid", "发票流水号", "中药备注", "备注2", "备注3", "tyid", "dwbl", "批号", "效期", "批次号", "ypsl", "hwmc", "byscf" };
        //    string[] MappingName ={ "序号", "警示灯", "发药", "皮试", "项目", "总金额", "姓名", "商品名", "品名", "规格", "单位", "用量", "剂数", "用法", "频次", "单价", "金额", "库存", "医生", "科室", "发票号", "门诊号", "性别", "年龄", "剂型", "厂家", "诊断", "煎药", "剂量", "剂量单位", "天数", "组标志", "排序序号", "录入员", "录入日期", "收费日期", "记费员", "发药日期", "发药员", "配药员", "处方号", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "配药窗口", "发药窗口", "记帐金额", "优惠金额", "自付金额", "YPID", "YDWBL", "cfmxid", "嘱托", "批发价", "批发金额", "使用频次", "货号", "单位规格", "zsyp", "fpid", "发票流水号", "中药备注", "备注2", "备注3", "tyid", "dwbl", "批号", "效期", "批次号", "ypsl", "hwmc", "byscf" };
        //    int[] ColWidth ={ 40, 30, 30, 30, 0, 0, 60, 60, 150, 110, 50/*ypsl*/, 40, 50, 50, 60, 60, 60, 65, 90, 90, 90, 90, 40, 70, 0, 50, 50, 50/*userage*/, 50, 0, 0, 0, 0, 60, 90, 90, 90/*发费日期*/, 60, 90, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 80, 0, 90, 150, 50, 50, 0, 0, 60, 60, 95, 0, 0, 100 };
        //    bool[] ColReadOnly ={ true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        //    bool[] ColBool ={ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

        //    DataTable dtTmp = new DataTable();
        //    dtTmp.TableName = "tbmx";
        //    SystemCfg cfg8032 = new SystemCfg(8032);
        //    for (int j = 0; j <= HeaderText.Length - 1; j++)
        //    {
        //        //DataGridEnableBoolColumn
        //        if (ColBool[j] == false)
        //        {
        //            if (HeaderText[j].ToString() != "警示灯")
        //            {
        //                DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(j);
        //                colText.HeaderText = HeaderText[j];
        //                colText.MappingName = MappingName[j];
        //                colText.Width = ColWidth[j];
        //                colText.NullText = "";
        //                colText.ReadOnly = ColReadOnly[j];
        //                //colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
        //                colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
        //                colText.TextBox.TextChanged += new EventHandler(TextBox_TextChanged);
        //                xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
        //            }
        //            else
        //            {
        //                MydataGirdImageColumn mycol = new MydataGirdImageColumn();
        //                mycol.HeaderText = HeaderText[j];
        //                mycol.MappingName = MappingName[j];
        //                mycol.Width = ColWidth[j];
        //                mycol.NullText = "";
        //                mycol.ReadOnly = ColReadOnly[j];
        //                mycol.ONCurrentChange += new DelCurrentChage(mycol_ONCurrentChange);
        //                xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(mycol);
        //                if (cfg8032.Config == "0")
        //                    mycol.Width = 0;
        //            }

        //            DataColumn datacol;
        //            if (MappingName[j].Trim() == "ypsl" || MappingName[j] == "金额")
        //                datacol = new DataColumn(MappingName[j], Type.GetType("System.Decimal"));
        //            else
        //                datacol = new DataColumn(MappingName[j]);

        //            dtTmp.Columns.Add(datacol);
        //        }
        //        else
        //        {
        //            DataGridButtonColumn btnCol = new DataGridButtonColumn(j);
        //            btnCol.HeaderText = HeaderText[j];
        //            btnCol.MappingName = MappingName[j];
        //            btnCol.Width = ColWidth[j];
        //            btnCol.CellButtonClicked += new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
        //            xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);
        //            this.myDataGrid1.MouseDown += new MouseEventHandler(btnCol.HandleMouseDown);
        //            this.myDataGrid1.MouseUp += new MouseEventHandler(btnCol.HandleMouseUp);
        //            DataColumn datacol;
        //            datacol = new DataColumn(MappingName[j]);
        //            dtTmp.Columns.Add(datacol);
        //        }
        //    }
        //    xcjwDataGrid.DataSource = dtTmp;
        //    xcjwDataGrid.TableStyles[0].MappingName = "tbmx";
        //    if (s.网络内容显示商品名 == true)
        //        xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width = 100;
        //    else
        //        xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width = 0;
        //    #endregion
        //}
        #endregion

        private bool IsVisable(string columnName, bool defaultVisable)
        {
            string strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("门诊处方发药网格列", columnName, Application.StartupPath + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(strVal))
                TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("门诊处方发药网格列", columnName, defaultVisable ? "1" : "0", Application.StartupPath + "\\ClientWindow.ini");
            strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("门诊处方发药网格列", columnName, Application.StartupPath + "\\ClientWindow.ini");
            return strVal == "1" ? true : false;
        }

        private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx xcjwDataGrid)
        {
            #region 添加明细的列

            List<ColumnDefine> columns = new List<ColumnDefine>();
            #region 列定义
            columns.Add(ColumnDefine.NewColumnDefine("序号", "序号", 40, true, 1));
            columns.Add(ColumnDefine.NewColumnDefine("警示灯", "警示灯", 30, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发药", "发药", 30, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("皮试", "皮试", 30, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("项目", "项目", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("总金额", "总金额", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("姓名", "姓名", 60, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("商品名", "商品名", 150, true, 0));  //
            columns.Add(ColumnDefine.NewColumnDefine("品名", "品名", (IsVisable("品名", true) ? 150 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("规格", "规格", (IsVisable("规格", true) ? 110 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("单位", "单位", (IsVisable("单位", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("用量", "用量", (IsVisable("用量", true) ? 40 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("剂数", "剂数", (IsVisable("剂数", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("用法", "用法", (IsVisable("用法", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("频次", "频次", (IsVisable("频次", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("单价", "单价", (IsVisable("单价", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("金额", "金额", (IsVisable("金额", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("库存", "库存", (IsVisable("库存", true) ? 65 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("医生", "医生", (IsVisable("医生", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("科室", "科室", (IsVisable("科室", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发票号", "发票号", (IsVisable("发票号", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("门诊号", "门诊号", (IsVisable("门诊号", true) ? 105 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("性别", "性别", (IsVisable("性别", true) ? 40 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("年龄", "年龄", (IsVisable("年龄", true) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("剂型", "剂型", (IsVisable("剂型", false) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("厂家", "厂家", (IsVisable("厂家", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("诊断", "诊断", (IsVisable("诊断", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("煎药", "煎药", (IsVisable("煎药", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("剂量", "剂量", (IsVisable("剂量", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("剂量单位", "剂量单位", (IsVisable("剂量单位", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("天数", "天数", (IsVisable("天数", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("组标志", "组标志", (IsVisable("组标志", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("排序序号", "排序序号", (IsVisable("排序序号", false) ? 30 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("录入员", "录入员", (IsVisable("录入员", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("录入日期", "录入日期", (IsVisable("录入日期", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("收费日期", "收费日期", (IsVisable("收费日期", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("记费员", "记费员", (IsVisable("记费员", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发药日期", "发药日期", (IsVisable("发药日期", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发药员", "发药员", (IsVisable("发药员", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("配药员", "配药员", (IsVisable("配药员", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("处方号", "处方号", (IsVisable("处方号", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("CFLX", "CFLX", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("JSSJH", "JSSJH", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("CFXH", "CFXH", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("PATID", "PATID", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("YSDM", "YSDM", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("KSDM", "KSDM", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("sfczy", "sfczy", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("qrczyh", "qrczyh", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("pyczyh", "pyczyh", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("配药窗口", "配药窗口", (IsVisable("配药窗口", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发药窗口", "发药窗口", (IsVisable("发药窗口", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("记帐金额", "记帐金额", (IsVisable("记帐金额", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("优惠金额", "优惠金额", (IsVisable("优惠金额", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("自付金额", "自付金额", (IsVisable("自付金额", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("YPID", "YPID", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("YDWBL", "YDWBL", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("cfmxid", "cfmxid", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("嘱托", "嘱托", (IsVisable("嘱托", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("批发价", "批发价", (IsVisable("批发价", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("批发金额", "批发金额", (IsVisable("批发金额", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("使用频次", "使用频次", (IsVisable("使用频次", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("货号", "货号", (IsVisable("货号", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("单位规格", "单位规格", (IsVisable("单位规格", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("zsyp", "zsyp", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("fpid", "fpid", (IsVisable("fpid", true) ? 80 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发票流水号", "发票流水号", (IsVisable("发票流水号", false) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("中药备注", "中药备注", (IsVisable("中药备注", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("备注2", "备注2", (IsVisable("备注2", true) ? 150 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("备注3", "备注3", (IsVisable("备注3", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("特殊用法", "tsyf", 150, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("tyid", "tyid", (IsVisable("tyid", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("批号", "批号", (IsVisable("批号", false) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("效期", "效期", (IsVisable("效期", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("批次号", "批次号", (IsVisable("批次号", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("ypsl", "ypsl", (IsVisable("ypsl", true) ? 95 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("hwmc", "hwmc", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("byscf", "byscf", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("剂量单位数量", "剂量单位数量", 0, true, 0));
            #endregion

            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";
            SystemCfg cfg8032 = new SystemCfg(8032);
            #region 创建列
            int j = 0;
            foreach (ColumnDefine define in columns)
            {
                //DataGridEnableBoolColumn
                if (define.ColBoolButton == 0)
                {
                    if (define.HeaderText != "警示灯")
                    {
                        DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(j);
                        colText.HeaderText = define.HeaderText;
                        colText.MappingName = define.MappingName;
                        colText.Width = define.ColWidth;
                        colText.NullText = "";
                        colText.ReadOnly = define.ColReadOnly;
                        //colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
                        colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
                        colText.TextBox.TextChanged += new EventHandler(TextBox_TextChanged);
                        xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    }
                    else
                    {
                        MydataGirdImageColumn mycol = new MydataGirdImageColumn();
                        mycol.HeaderText = define.HeaderText;
                        mycol.MappingName = define.MappingName;
                        mycol.Width = define.ColWidth;
                        mycol.NullText = "";
                        mycol.ReadOnly = define.ColReadOnly;
                        mycol.ONCurrentChange += new DelCurrentChage(mycol_ONCurrentChange);
                        xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(mycol);
                        if (cfg8032.Config == "0")
                            mycol.Width = 0;
                    }

                    DataColumn datacol;
                    if (define.MappingName.Trim() == "ypsl" || define.MappingName == "金额")
                        datacol = new DataColumn(define.MappingName, Type.GetType("System.Decimal"));
                    else
                        datacol = new DataColumn(define.MappingName);

                    dtTmp.Columns.Add(datacol);
                }
                else
                {
                    DataGridButtonColumn btnCol = new DataGridButtonColumn(j);
                    btnCol.HeaderText = define.HeaderText;
                    btnCol.MappingName = define.MappingName;
                    btnCol.Width = define.ColWidth;
                    btnCol.CellButtonClicked += new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);
                    this.myDataGrid1.MouseDown += new MouseEventHandler(btnCol.HandleMouseDown);
                    this.myDataGrid1.MouseUp += new MouseEventHandler(btnCol.HandleMouseUp);
                    DataColumn datacol;
                    datacol = new DataColumn(define.MappingName);
                    dtTmp.Columns.Add(datacol);
                }
                j++;
            }
            #endregion
            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbmx";
            //if (s.网络内容显示商品名 == true)
            xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width = 150;
            //else
            //    xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width = 0;
            #endregion
        }

        void mycol_ONCurrentChange(int CurIndex)
        {
            try
            {

                string hlyytype = ApiFunction.GetIniString("hlyy", "name", System.Windows.Forms.Application.StartupPath + "\\Hlyy.ini");
                DataTable tbmx = (DataTable)myDataGrid1.DataSource;
                int nrow = myDataGrid1.CurrentCell.RowNumber;
                int ncol = myDataGrid1.CurrentCell.ColumnNumber;
                if (tbmx.Columns[ncol].Caption != "警示灯")
                    return;
                Guid ghxxid = new Guid(tbmx.Rows[nrow]["patid"].ToString());
                string mzh = tbmx.Rows[nrow]["门诊号"].ToString();
                string xb = tbmx.Rows[nrow]["性别"].ToString();
                object brxxid = InstanceForm.BDatabase.GetDataResult("select top 1 brxxid from mz_ghxx where ghxxid='" + ghxxid + "'", 30);

                //MessageBox.Show(brxxid.ToString());
                //Add hlyy by Zj 2012-02-13
                YY_BRXX brxx = new YY_BRXX(new Guid(Convertor.IsNull(brxxid, Guid.Empty.ToString())), InstanceForm.BDatabase);
                string username = InstanceForm.BCurrentUser.EmployeeId.ToString() + "/" + InstanceForm.BCurrentUser.Name;
                string ksname = InstanceForm.BCurrentDept.DeptId.ToString() + "/" + InstanceForm.BCurrentDept.DeptName;
                ts_mz_class.ts_mz_hlyy.InitializationHLYY(username, ksname, Convert.ToInt32(TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId), mzh, 0, brxx.Brxm, xb, brxx.Csrq);

                //MessageBox.Show("实例化搞完了");

                DateTime severtime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                Ts_Hlyy_Interface.HlyyInterface hl = Ts_Hlyy_Interface.HlyyFactory.Hlyy(hlyytype);

                string ss = tbmx.Rows[nrow]["YPID"].ToString() + "," + tbmx.Rows[nrow]["品名"].ToString() + "," + tbmx.Rows[nrow]["单位"].ToString() + "," + tbmx.Rows[nrow]["用法"].ToString();
                DataTable Tab_hlyy = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, ghxxid, "",
                     "", 0,
                    "", "", 0, 2, "", "", "", 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                Ts_Hlyy_Interface.CfInfo[] cfinfo = new Ts_Hlyy_Interface.CfInfo[Tab_hlyy.Rows.Count];
                int result = 0;
                //MessageBox.Show("开始FOR了,一共"+cfinfo.Length.ToString()+"行");
                for (int i = 0; i <= cfinfo.Length - 1; i++)
                {
                    cfinfo[i].dwmc = Tab_hlyy.Rows[i]["剂量单位"].ToString();
                    cfinfo[i].jl = Tab_hlyy.Rows[i]["剂量"].ToString();
                    cfinfo[i].kyzsj = severtime;
                    cfinfo[i].kyzsj = Convert.ToDateTime(severtime);
                    cfinfo[i].kyzysid = Tab_hlyy.Rows[i]["ysdm"].ToString();
                    cfinfo[i].kyzysmc = Tab_hlyy.Rows[i]["医生"].ToString();
                    cfinfo[i].pc = Tab_hlyy.Rows[i]["频次"].ToString().Trim();
                    cfinfo[i].Tyzsj = Convert.ToDateTime(severtime);
                    cfinfo[i].xmid = Tab_hlyy.Rows[i]["YPID"].ToString();
                    cfinfo[i].xmly = 1;
                    cfinfo[i].yf = Tab_hlyy.Rows[i]["用法"].ToString();
                    cfinfo[i].yzid = Tab_hlyy.Rows[i]["cfmxid"].ToString();
                    cfinfo[i].yzmc = Tab_hlyy.Rows[i]["品名"].ToString();
                    cfinfo[i].Yztype = 1;
                    if (-1 > 0)
                        cfinfo[i].zh = result;
                    else
                    {
                        cfinfo[i].zh = result;
                        result++;
                    }
                }
                //MessageBox.Show("FOR完了");
                hl.recipe_check(3, null, severtime, 1, ref cfinfo, 0);

                //MessageBox.Show("成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("调用错误!原因:" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        void TextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            ImageList im = new ImageList();
            string dd = control.Text;
            //im.Images.Add(this.imageList1.Images[
            //control.Controls.Add(
        }

        void colText_WidthChanged(object sender, EventArgs e)
        {

        }

        //列颜色改变事件
        private void myDataGrid1_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            try
            {
                e.BackColor = Color.White;
                DataTable tb;
                if (sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn")
                {
                    DataGridEnableBoolColumn column = (DataGridEnableBoolColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                else
                {
                    DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                if (e.Row > tb.Rows.Count - 1)
                    return;
                //				if (tb.Rows[e.Row]["cjid"].ToString().Trim()=="")
                //					e.BackColor=Color.Azure;

                if (tb.Rows[e.Row]["发药"].ToString().Trim() == "◆")
                    e.ForeColor = Color.Blue;
                if (tb.Rows[e.Row]["发药"].ToString().Trim() == "")
                    e.ForeColor = Color.Black;
                if (tb.Rows[e.Row]["发药"].ToString().Trim() == "√")
                    e.ForeColor = Color.Gray;
                if (tb.Rows[e.Row]["byscf"].ToString().Trim() == "1")
                    e.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(222)))), ((int)(((byte)(255))))); //System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
                else
                    e.BackColor = Color.White;



                //Modify by jchl
                if (tb.Rows[e.Row]["剂型"].ToString().Trim() == "颗粒剂" && tb.Rows[e.Row]["cflx"].ToString().Trim() == "03")
                {
                    e.BackColor = Color.LightGreen;
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            //			
        }

        //查询处方按钮事件
        private void butcfcx_Click(object sender, System.EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            try
            {
                #region 报价器 20110307
                string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqybjq == "true" && _menuTag.Function_Name == "Fun_ts_yf_mzfy")
                {
                    try
                    {
                        if (this._call != null && this._call.CurrentThread != null)
                            this._call.CurrentThread.Abort();
                        this._call.Call(ts_call.DmType.清除, "", 0);
                    }
                    catch
                    {
                    }
                }
                #endregion


                DataTable tb = new DataTable();

                //string rq1=chkrq.Checked==true?dtprq1.Value.ToShortDateString():"";
                //string rq2=chkrq.Checked==true?dtprq2.Value.ToShortDateString():"";
                int bk = this.rdodq.Checked == true ? 0 : 1;
                int fybz = 0;
                if (rdo2.Checked == true)
                    fybz = 1;
                if (rdo3.Checked == true)
                    fybz = 2;

                string sfrq1 = "";
                string sfrq2 = "";
                string fyrq1 = "";
                string fyrq2 = "";

                if (rdo1.Checked == true)
                {
                    sfrq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                    sfrq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                    fyrq1 = "";
                    fyrq2 = "";
                }
                else
                {
                    sfrq1 = "";
                    sfrq2 = "";
                    fyrq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                    fyrq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                }

                if (txtxm.Text.Trim() == "" && txtmzh.Text.Trim() == "" && txttmk.Text.Trim() == "" && txtfph.Text.Trim() == "" && chkrq.Checked == false && rdo2.Checked == true)
                {
                    MessageBox.Show("请选择一定的查询条件");
                    return;
                }

                tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, txtxm.Text.Trim(),
                     "", 0,
                    fyrq1, fyrq2, 0, fybz, "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);

                this.AddPresc(tb);

                chkall.Checked = false;

                firstXm = string.Empty;
                //setButtionState = 0;
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

        //添加处方记录
        private void AddPresc(DataTable tbcf)
        {

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();

            if (tbcf.Rows.Count == 0)
                return;

            tbcf = DoFilFylb(tbcf);

            if (tbcf.Rows.Count == 0)
                return;

            string _prescNo = tbcf.Rows[0]["处方号"].ToString().Trim();
            int _PrescRowNo = 0;
            decimal _PrescJe = 0;

            if (tbcf.Rows.Count > 0)
            {
                cmbpyr.SelectedIndexChanged -= new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
                //cmbpyr.Text = tbcf.Rows[0]["配药员"].ToString().Trim();
                cmbpyr.SelectedIndexChanged += new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
            }
            for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            {
                if (tbcf.Rows[i]["处方号"].ToString().Trim() != _prescNo)
                {
                    DataRow row = tb.NewRow();
                    row["序号"] = "小计";
                    row["金额"] = _PrescJe.ToString("0.00");
                    row["处方号"] = _prescNo;
                    _prescNo = tbcf.Rows[i]["处方号"].ToString().Trim();
                    _PrescRowNo = 0;
                    _PrescJe = 0;
                    tb.Rows.Add(row);

                    DataRow row1 = tb.NewRow();
                    tb.Rows.Add(row1);
                }

                if (tbcf.Rows[i]["处方号"].ToString().Trim() == _prescNo)
                {
                    _PrescRowNo = _PrescRowNo + 1;
                    tbcf.Rows[i]["序号"] = _PrescRowNo.ToString();
                    //					if (this.tabControl1.SelectedTab==this.tabPage2) tbcf.Rows[i]["发药"]="√";
                    tb.ImportRow(tbcf.Rows[i]);
                    _PrescJe = _PrescJe + Convert.ToDecimal(tbcf.Rows[i]["金额"]);

                    //wxz

                    //wxz
                }

                _prescNo = tbcf.Rows[i]["处方号"].ToString().Trim();

            }

            //添加最后一张处方的合计
            DataRow endrow = tb.NewRow();
            endrow["序号"] = "小计";
            endrow["金额"] = _PrescJe.ToString("0.00");
            endrow["处方号"] = _prescNo;
            tb.Rows.Add(endrow);

            //if (tb.Rows.Count > 1)
            //    myDataGrid1.CurrentCell =null;
        }

        #region 一般控制

        private void chkrq_CheckedChanged(object sender, System.EventArgs e)
        {
            dtprq1.Enabled = this.chkrq.Checked == true ? true : false;
            dtprq2.Enabled = this.chkrq.Checked == true ? true : false;
            this.butcfcx.Enabled = this.chkrq.Checked == true ? true : false;
            txtxm.Enabled = this.chkrq.Checked == true ? true : false;
        }


        string firstXm = string.Empty;
        //int setButtionState = 0;
        //明细列的按钮事件
        private void btnCol_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (this.rdo2.Checked == true)
                return;

            //int cfdcount = 1;
            //if (!string.IsNullOrEmpty(firstXm))
            //{
            //    List<string> cfxhList = new List<string>();
            //    DataRow[] retRows = tb.Select(string.Format(" 姓名 = '{0}'", firstXm));
            //    if (retRows != null && retRows.Length > 0)
            //    {
            //        foreach (DataRow row in retRows)
            //        {
            //            if (cfxhList.Count == 0)
            //                cfxhList.Add(row["cfxh"].ToString().Trim());
            //            else if (!cfxhList.Contains(row["cfxh"].ToString().Trim()))
            //            {
            //                cfxhList.Add(row["cfxh"].ToString().Trim());
            //            }
            //        }
            //    }
            //    cfdcount = cfxhList.Count;
            //}
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (tb.Rows[i]["处方号"].ToString().Trim() == tb.Rows[e.RowIndex]["处方号"].ToString().Trim() && tb.Rows[i]["处方号"].ToString().Trim() != "" && tb.Rows[i]["发药"].ToString().Trim() != "√")
                {
                    if (tb.Rows[i]["发药"].ToString().Trim() == "")
                    {
                        object xm = tb.Rows[i]["姓名"];
                        if (string.IsNullOrEmpty(firstXm))
                            firstXm = xm != null ? xm.ToString().Trim() : string.Empty;
                        if (kf != null)
                        {
                            if (firstXm == xm.ToString().Trim())
                            {
                                tb.Rows[i]["发药"] = "◆";
                            }

                            if (tb.Rows[i][0] != null && tb.Rows[i][0].ToString().Trim() == "小计")  //&& setButtionState <= cfdcount)
                            {
                                if (xm == DBNull.Value && tb.Rows[i - 1]["姓名"].ToString().Trim() == firstXm)
                                {
                                    //setButtionState++;
                                    tb.Rows[i]["发药"] = "◆";
                                }
                            }
                        }
                        else
                        {
                            tb.Rows[i]["发药"] = "◆";
                        }

                    }
                    else
                    {
                        tb.Rows[i]["发药"] = "";
                        if (!string.IsNullOrEmpty(firstXm))
                        {
                            DataRow[] retRows = tb.Select(string.Format(" 姓名 = '{0}' and 发药 = '◆'", firstXm));
                            if (retRows == null || retRows.Length <= 0)
                            {
                                firstXm = string.Empty;
                                //setButtionState = 0;
                            }
                        }
                    }
                }
            }
            myDataGrid1.Refresh();
        }

        //全选
        private void chkall_CheckedChanged(object sender, System.EventArgs e)
        {
            //			if (this.tabControl1.SelectedTab!=this.tabPage1) return;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (tb.Rows[i]["处方号"].ToString().Trim() != "" && tb.Rows[i]["发药"].ToString().Trim() != "√")
                {
                    if (chkall.Checked == true)
                        tb.Rows[i]["发药"] = "◆";
                    else
                        tb.Rows[i]["发药"] = "";
                }
            }
        }


        #endregion

        private void DoZcyJyFy()
        {
            try
            {

                string hosCode = "990002";
                string hosName = "武汉市中心医院";

                string sFre = string.Format(@"select EXECNUM,* from JC_FREQUENCY ");
                DataTable dtFre = InstanceForm.BDatabase.GetDataTable(sFre);

                if (true)
                {
                    DateTime _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                    int NN = 0;
                    int YY = 0;

                    //处方发药、中草药、待煎
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;

                    //分组处方
                    //emr同步过来    用法为  待煎则发送处方
                    DataRow[] selrow = tb.Select("发药='◆' and ypid<>'' and 用法='代煎'");
                    DataTable tbsel = tb.Clone();
                    for (int w = 0; w <= selrow.Length - 1; w++)
                        tbsel.ImportRow(selrow[w]);

                    string[] GroupbyField ={ "jssjh", "发票号", "总金额", "记帐金额", "优惠金额", "自付金额", "cfxh", "patid", "门诊号", "姓名", "ysdm", "ksdm", "收费日期", "sfczy", "配药窗口", "性别", "年龄", "医生", "科室", "剂数" };
                    string[] ComputeField ={ "金额" };
                    string[] CField ={ "sum" };
                    DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                    if (tbcf.Rows.Count == 0)
                    {
                        MessageBox.Show("没有要发药的药品记录");
                        SetDefaultFocuse();
                        return;
                    }
                    else if (tbcf.Rows.Count > 1)
                    {
                        MessageBox.Show("中草药煎药处方只能单张发送");
                        SetDefaultFocuse();
                        return;
                    }

                    //门诊处方发药有：中草药、待煎
                    if (tbcf.Rows.Count > 0)
                    {
                        for (int i = 0; i < tbcf.Rows.Count; i++)
                        //for (int i = 0; i < 1; i++)
                        {
                            bool bThisPresSuc = false;

                            DataRow[] rows = tb.Select("发票号='" + tbcf.Rows[i]["发票号"].ToString() + "' and ypid<>'' and 门诊号='" + tbcf.Rows[i]["门诊号"].ToString() + "' AND CFXH='" + tbcf.Rows[i]["CFXH"].ToString() + "'", "序号");

                            string _presc_no = Convert.ToString(tbcf.Rows[i]["CFXH"]); //处方号 
                            decimal _sumzje = Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["总金额"], "0")); //金额
                            int _cfts = 0;// Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["剂数"], "0")); //剂数
                            _cfts = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["剂数"], "0")); //剂数
                            Guid _inpatient_id = new Guid(Convertor.IsNull(tbcf.Rows[i]["patid"], Guid.Empty.ToString()));//ghxxid

                            string _inpatient_no = Convert.ToString(tbcf.Rows[i]["门诊号"]);//门诊号
                            string _hzxm = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["姓名"], ""));//姓名
                            string _hzxb = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["性别"], ""));//性别
                            string _hznl = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["年龄"], ""));//年龄
                            string _jtdz = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["家庭地址"], ""));//家庭地址
                            string _lxfs = "";// Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["联系方式"], ""));//联系方式
                            string _blh = "门诊" + _inpatient_no;

                            string wardCode = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["科室"], ""));//门诊看诊科室【待修改讨论】
                            string bedNo = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["床号"], ""));//床号

                            //ClsZcyJy.ClsJyInterFace
                            string _ts = "2"; //贴数是一天几次【频率的执行次数】
                            string _fs = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["剂数"], ""));//付数是剂数; //付数是剂数

                            string fre = ""; // Convert.ToString(Convertor.IsNull(rows[j]["频次"], ""));
                            string _yyfs = ""; //用药方式【用法】
                            string _jyfs = "2";//煎药方式【写死：待修改讨论】
                            string _allWgt = "";//总重量【待定我暂时传空】
                            string packvolume = "200";//包装重量【写死默认200】

                            string _dept_id = Convertor.IsNull(tbcf.Rows[i]["KSDM"], "0");//科室
                            string _doc_id = Convertor.IsNull(tbcf.Rows[i]["YSDM"], "-1");//医生
                            Guid _fyid = Guid.Empty;//发药ID

                            //修改上传 的 付数与贴数
                            FrmZcyTsFs frmFsTs = new FrmZcyTsFs(_fs, _ts);
                            frmFsTs.ShowDialog();

                            if (frmFsTs.save)
                            {
                                _ts = frmFsTs.Ts;
                                _fs = frmFsTs.Fs;
                            }

                            DateTime dtScTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//上传时间

                            string buyUnit = "KG";

                            string doc = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["医生"].ToString(), ""));////Convert.ToString(Convertor.IsNull(rows[j]["医生"], ""));


                            //轮询发送该处方明细到 煎药系统 
                            decimal sumjhje = 0;//总进货金额
                            NN = 0;//明细数量
                            string strMsg = "";
                            bool bDel = false;

                            //上传之前先删除处方明细
                            try
                            {
                                //上传之前先删除处方明细
                                bDel = ClsZcyJy.ClsJyInterFace.DeletePres(hosCode, _presc_no, out strMsg);



                            }
                            catch (Exception ex)
                            {
                                //log
                                //明细上传失败   本处方上传停止  下组处方开始
                                TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
*** 【门诊中草药上传】 begin ***
*** Local Time : '{0}' ***
*** Pres_no    : '{1}' ***
*** Inp_id     : '{2}' ***
*** Err_info   : '{3}' ***
*** 中草药上传 end ***",
                                DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);

                                continue;
                            }

                            for (int j = 0; j <= rows.Length - 1; j++)
                            {

                                //if (string.IsNullOrEmpty(fre))
                                //{
                                //    //fre = Convert.ToString(Convertor.IsNull(rows[j]["频次"], ""));
                                //    fre = "bid";//草药约定写死    门诊EMR给不了
                                //    if (!string.IsNullOrEmpty(fre))
                                //    {
                                //        _ts = ClsZcyJy.ClsJyInterFace.GetFreqExecNum(dtFre, fre);

                                //        if (_ts.Equals("-1"))
                                //        {
                                //            return;
                                //        }
                                //    }
                                //}

                                //if (string.IsNullOrEmpty(_fs))
                                //{
                                //    _fs = Convert.ToString(Convertor.IsNull(rows[j]["剂数"], ""));
                                //    _cfts = Convert.ToInt32(Convertor.IsNull(rows[i]["剂数"], "0")); //剂数
                                //}

                                if (string.IsNullOrEmpty(_yyfs))
                                {
                                    _yyfs = Convert.ToString(Convertor.IsNull(rows[j]["用法"], ""));
                                }

                                string cjid = rows[j]["YPID"].ToString();
                                string spm = rows[j]["品名"].ToString();
                                string gg = rows[j]["规格"].ToString();
                                string sccj = rows[j]["厂家"].ToString();

                                int _yl = Convert.ToInt32(rows[j]["用量"]);
                                int _js = Convert.ToInt32(rows[j]["剂数"]);
                                int _sl = (_yl * _js);
                                string sl = _sl.ToString();
                                string yldw = rows[j]["单位"].ToString(); //Convert.ToInt32(rows[j]["单位"]);
                                string jldwsl = rows[j]["剂量单位数量"].ToString(); //Convert.ToInt32(rows[j]["单位"]);

                                string jl = rows[j]["剂量"].ToString();
                                string jldw = rows[j]["剂量单位"].ToString();
                                string lsdj = rows[j]["单价"].ToString();
                                decimal lsje = decimal.Parse(Convertor.IsNull(rows[j]["金额"].ToString(), "0"));
                                string tsyf = Convertor.IsNull(rows[j]["tsyf"], "");

                                string pfdj = rows[j]["批发价"].ToString();
                                decimal pfje = decimal.Parse(Convertor.IsNull(rows[j]["批发金额"].ToString(), "0"));


                                //------------------add by wangzhi at 2014-08-01 与门诊相同的处理,(写发药明细的单位与库存单位一致)------------------  
                                //js = 1;  //强制剂数为1
                                //sl = ypsl; //数量直接取拆分结果
                                //pfj_cfmx = Convert.ToDecimal(rows[j]["批发价"]) * dwbl_cfmx / dwbl_kc; //使批发价所使用的单位与进货价所使用的单位保持一致
                                //lsj_cfmx = Convert.ToDecimal(rows[j]["单价"]) * dwbl_cfmx / dwbl_kc;   //同上
                                //------------------end modify by wangzhi at 2014-08-01------------------
                                strMsg = "";
                                //

                                bool bMedSuc = false;
                                try
                                {
                                    bMedSuc = ClsZcyJy.ClsJyInterFace.His_DrugInfo(_presc_no, hosCode, hosName, cjid, spm, gg, sccj, jldwsl, _yl.ToString(), jldwsl, lsdj, lsje.ToString("0.00"), jldw, tsyf, out strMsg);

                                    ////循环上传明细
                                    //bMedSuc = ClsZcyJy.ClsJyInterFace.His_DrugInfo(_presc_no, hosCode, hosName, cjid, spm, gg, sccj, sl, yl, sl, lsdj, lsje, jldw, tsyf, out strMsg);

                                }
                                catch (Exception ex)
                                {
                                    //log
                                    //明细上传失败   本处方上传停止  下组处方开始
                                    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
*** 【门诊中草药上传】 begin ***
*** Local Time : '{0}' ***
*** Pres_no    : '{1}' ***
*** Inp_id     : '{2}' ***
*** Err_info   : '{3}' ***
*** 中草药上传 end ***",
                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);

                                    break;
                                }

                                if (bMedSuc)
                                {
                                    NN = NN + 1;
                                }
                                else
                                {
                                    //log
                                    //明细上传失败   本处方上传停止  下组处方开始
                                    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
*** 【门诊中草药上传】 begin ***
*** Local Time : '{0}' ***
*** Pres_no    : '{1}' ***
*** Inp_id     : '{2}' ***
*** Err_info   : '{3}' ***
*** 中草药上传 end ***",
                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,strMsg) }, false);

                                    break;
                                }

                                sumjhje += lsje;
                            }

                            string ret = "";
                            if (NN == rows.Length)
                            {
                                //
                                //bThisPresSuc = ClsZcyJy.ClsJyInterFace.His_UserRecipe(hosCode, hosName, _hzxm, _hzxb, _hznl, _jtdz, _lxfs, _presc_no, _blh,
                                //    wardCode, bedNo, _ts, _fs, _yyfs, _jyfs, _allWgt, packvolume);

                                //
                                bThisPresSuc = ClsZcyJy.ClsJyInterFace.His_UserRecipe(hosCode, hosName, _hzxm, _hzxb, _hznl, _jtdz, _lxfs, _presc_no, "", _blh,
                                    bedNo, _ts, _fs, _yyfs, _jyfs, _allWgt, packvolume, dtScTime, doc, dtScTime.ToString("yyyy-MM-dd HH:mm:ss"), buyUnit, wardCode, sumjhje.ToString("0.00"), dtScTime.ToString("yyyy-MM-dd HH:mm:ss"), "", "", out ret);

                                if (!bThisPresSuc)
                                {
                                    //log
                                    //处方信息上传出错  本处方上传停止,    继续下组处方开始
                                    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
*** 【住院中草药上传】 begin ***
*** Local Time : '{0}' ***
*** Pres_no    : '{1}' ***
*** Inp_id     : '{2}' ***
*** Err_info   : '{3}' ***
*** 中草药上传 end ***",
                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ret) }, false);

                                    continue;
                                }
                            }


                            //接口传输成功
                            if (bThisPresSuc)
                            {


                                InstanceForm.BDatabase.BeginTransaction();
                                try
                                {
                                    //更新：CHARGE_BIT,FY_BIT,FY_DATE,FY_USER
                                    string strCySql = string.Format(@"update MZ_CFB set bfybz=1,FYRQ='{1}' ,FYR='{2}'
                                                            where CFID='{0}' ", _presc_no, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), InstanceForm.BCurrentUser.EmployeeId);

                                    InstanceForm.BDatabase.DoCommand(strCySql);

                                    strCySql = string.Format(@"update yf_zcyfy_sc set del_bit=1 where CFXH='{0}' ", _presc_no);

                                    InstanceForm.BDatabase.DoCommand(strCySql);

                                    strCySql = string.Format(@"insert into yf_zcyfy_sc(
                                                        id,jgbm,cflx,JSSJH,FPH,
                                                        zje,cfts,CFXH,PATID,PATIENTNO,HZXM,YSDM,KSDM,
                                                        SKRQ,SKY,FYRQ,FYR,PYR,PYCKH,FYCKH,DEPTID,JZCFBZ,TFBZ,YWLX,wkdz)  
                                                        values('{0}','{1}','{2}','{3}','{4}',
                                                        '{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',
                                                        '{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}');  ",
                                                        Guid.NewGuid(), InstanceForm._menuTag.Jgbm, "1", "0", "02",
                                                        _sumzje, _cfts, _presc_no, _inpatient_id, _inpatient_no, _hzxm, _doc_id, _dept_id,
                                                        _sDate, InstanceForm.BCurrentUser.EmployeeId, _sDate, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.EmployeeId,
                                                        "", "", InstanceForm.BCurrentDept.DeptId, "1", 0, _menuTag.FunctionTag, PubStaticFun.GetMacAddress());

                                    InstanceForm.BDatabase.DoCommand(strCySql);

                                    InstanceForm.BDatabase.CommitTransaction();
                                }
                                catch (Exception ex)
                                {
                                    InstanceForm.BDatabase.RollbackTransaction();
                                    //log
                                    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
*** 【门诊中草药上传】 begin ***
*** Local Time : '{0}' ***
*** Pres_no    : '{1}' ***
*** Inp_id     : '{2}' ***
*** Err_info   : '{3}' ***
*** 中草药上传 end ***",
                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);

                                    throw ex;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    #region 更新网格数据为已发药状态


                    MessageBox.Show("发药成功！\n\n", "发药", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CallNumber(2); //清空药房叫号显示屏

                    SetDefaultFocuse();
                    this.butfy.Enabled = true;
                    try
                    {
                        DataRow[] rows_ref = null;
                        DataView dv = (DataView)dataGridView1.DataSource;
                        if (dv != null)
                        {
                            DataTable tbref = dv.Table;
                            if (cfg8027 == "1")
                                rows_ref = tbref.Select("发票号='" + tbcf.Rows[0]["发票号"].ToString() + "' and 姓名='" + tbcf.Rows[0]["姓名"].ToString() + "'");
                            if (cfg8027 == "2")
                                rows_ref = tbref.Select("姓名='" + tbcf.Rows[0]["姓名"].ToString() + "'");
                            if (rows_ref != null)
                            {
                                if (rows_ref.Length > 0)
                                    tbref.Rows.Remove(rows_ref[0]);
                            }
                            if (cfg8027 != "0" && tbref.Rows.Count == 0)
                                button_ref_Click(null, null);
                        }

                        if (_textBox != null)
                        {
                            _textBox.Focus();
                            _textBox.SelectAll();
                        }
                        else
                        {
                            txtmzh.Focus();
                            txtmzh.SelectAll();
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion

                    //打印处方
                    try
                    {
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            if (tb.Rows[i]["发药"].ToString().Trim() == "◆")
                                tb.Rows[i]["发药"] = "√";
                        }

                        //打印并清除网格
                        if (chkprint.Checked == true)
                        {
                            this.butprint_Click(null, null);
                        }
                        //this.butprint_Click(sender, e);
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show("打印处方时发生错误" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("上传出错" + ex.Message, "提示");
            }
            finally
            {
                //this.Cursor = Cursors.Arrow;
                SetDefaultFocuse();
                //Add by Zhujh 2017-05-10 评价器
                yongtai.PlzOpinion();
            }

            //string bqypjq = ApiFunction.GetIniString("评价器", "启用评价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
            //string pjqxh = ApiFunction.GetIniString("评价器", "评价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            //if (bqypjq == "true")
            //{
            //    ts_pjq.ipjq ipjq = ts_pjq.PjqFactory.Newpjq(pjqxh);
            //    string perr_text = "";
            //    int perr_code = 0;
            //    ipjq.Pj(InstanceForm.BCurrentUser.LoginCode.ToString(), InstanceForm.BCurrentUser.Name, InstanceForm.BCurrentDept.DeptId.ToString(), InstanceForm.BCurrentDept.DeptName, out perr_code, out perr_text);
            //    if (perr_code != 0)
            //        throw new Exception("评价器调用出错!" + perr_text);
            //}
        }

        protected bool getTimeSpan(string timeStr,string Str_start,string str_End)
        {
            //判断当前时间是否在工作时间段内
           // string _strWorkingDayAM = "08:30";//工作时间上午08:30
           // string _strWorkingDayPM = "17:30";

            string _strWorkingDayAM = Str_start;//工作时间上午08:30
            string _strWorkingDayPM = str_End;
            TimeSpan dspWorkingDayAM = DateTime.Parse(_strWorkingDayAM).TimeOfDay;
            TimeSpan dspWorkingDayPM = DateTime.Parse(_strWorkingDayPM).TimeOfDay;

            //string time1 = "2017-2-17 8:10:00";
            DateTime t1 = Convert.ToDateTime(timeStr);

            TimeSpan dspNow = t1.TimeOfDay;
            if (dspNow > dspWorkingDayAM && dspNow < dspWorkingDayPM)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 点击发药按钮所发生的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butfy_Click(object sender, System.EventArgs e)
        {
            string str_GHXXID = "";//挂号信息ID
            string str_PATID = "";//病人信息ID
            string str_HHkf_settingValue = ApiFunction.GetIniString("药房快发设置", "类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
            string str_HH_Flag = "";
            if (str_HHkf_settingValue.Equals("北院使用南院相同门诊快发"))
            {
                str_HH_Flag = "1";
            }


            //是否进行扫条形码进行强制判断

            //**************************************************
            #region

            string str_SMFlag = ApiFunction.GetIniString("强制条形码扫码发药", "强制类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
            //[强制条形码扫码发药] 强制类型=1  为1表示强制控制，否则不进行强制控制
            if (str_SMFlag == "1")
            {
                bool str_flag = false;
                SystemCfg str_TimeFlag = new SystemCfg(19006);
                if (str_TimeFlag != null && !string.IsNullOrEmpty(str_TimeFlag.Config) )
                {
                    //如果有配置
                    if (str_TimeFlag.Config.Contains("-"))
                    {
                        //18:00:00-23:00:00 时间格式 
                        //string time=convert.tostring(DateTime.Today).split( new char []{' '});    
                        //textbox1.text=time[0]; 以空格作为分界点;
                        string strtime = str_TimeFlag.Config.ToString();
                        string[] time = strtime.Split(new char[]{'-'});
                        string str_Start = time[0].ToString();
                        string str_StrEnd = time[1].ToString();
                       
                      string str_serTime= DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//服务器时间
                      str_flag = getTimeSpan(str_serTime, str_Start, str_StrEnd);

                      if (str_flag)
                      {
                          string str_YPIDall = get_fy_YPID_All(); //得到药品ID的组合字符串 
                          // MessageBox.Show(str_YPIDall);
                          CheckDrugTxm_List FW = new CheckDrugTxm_List();
                          FW.FillDj(str_YPIDall);
                          FW.ShowDialog();
                          //if (FW.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                         
                        // if (FW.ShowDialog() != DialogResult.OK)
                          if(FW.ReturnValue!="0")
                          {
                              return ;
                          } 
                      }

                    }
                    else
                    {
                        MessageBox.Show("条形码核对发药处方信息时间段格式，设置不正确，请设置格式如：18:00-23:00");
                    }
                }               
            }
          

            #endregion


            string validSql = string.Format(@"select count(1) as num from V_JC_YP_ZCYSC where dept_id='{0}'", InstanceForm.BCurrentDept.DeptId);

            int iRet = int.Parse(InstanceForm.BDatabase.GetDataResult(validSql).ToString());

            if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_ZCY" && iRet > 0)
            {
                DoZcyJyFy();
            }
            else
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource; //处方明细集合
                //if (s.配药模式==true && this._Fyckh.Trim()==""){MessageBox.Show("系统当前处于配药模式，当前窗口必须设置！","发药",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return;};
                if (s.系统启用 == false)
                {
                    MessageBox.Show("系统未启用");
                    return;
                }
                if (s.禁用系统 == true)
                {
                    MessageBox.Show("系统被管理员禁用");
                    return;
                }

                //int dd = tb.Rows.Count;

                string _pronamefy = "";
                string _pronamefymx = "";
                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_YFFY")
                {
                    _pronamefy = "sp_yf_fy";
                    _pronamefymx = "sp_yf_fymx";
                }
                else
                {
                    _pronamefy = "sp_yk_fy";
                    _pronamefymx = "sp_yk_fymx";
                }

                if (cmbpyr.Text.Trim() == "")
                {
                    MessageBox.Show("请选择配药人！", "发药", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                string brxm = string.Empty;
                string brxxid = string.Empty;
                try
                {
                    //if (dataGridView1.CurrentRow != null)
                    //{
                    //    DataView dv = dataGridView1.DataSource as DataView;
                    //    int nrow = dataGridView1.CurrentRow.Index;
                    //    brxm = dv[nrow]["姓名"] != null ? dv[nrow]["姓名"].ToString() : "";
                    //    brxxid = dv[nrow]["brxxid"].ToString();
                    //}
                    //else
                    //{
                    object objXm = tb.Rows[0]["姓名"] ?? "";
                    object objbrxxid = InstanceForm.BDatabase.GetDataResult("select BRXXID from MZ_GHXX where GHXXID='" + tb.Rows[0]["patid"].ToString() + "' ");
                    brxm = objXm.ToString();
                    brxxid = objbrxxid != null ? objbrxxid.ToString() : "";

                    //下面为了推送到电子健康卡号到卡管中心用到
                    str_GHXXID = tb.Rows[0]["patid"].ToString();//挂号信息ID
                    str_PATID = brxxid;//病人信息ID
                    //}                  

                }
                catch
                { }

                Guid fyid = Guid.Empty;
                Guid fymxid = Guid.Empty;
                int err_code = -1;
                string err_text = "";
                try
                {
                    this.Cursor = PubStaticFun.WaitCursor();
                    //分组处方
                    DataRow[] selrow = tb.Select("发药='◆' and ypid<>''");
                    DataTable tbsel = tb.Clone();
                    for (int w = 0; w <= selrow.Length - 1; w++)
                        tbsel.ImportRow(selrow[w]);

                    #region 合理用药
                    try
                    {
                        if (cfghlyytype != "0" && cfghlyytype != "")
                        {
                            switch (cfghlyytype)
                            {
                                case "1":
                                    #region 大通合理用药 Add By lidan 2013-09-16
                                    object objbrxxid = InstanceForm.BDatabase.GetDataResult("select BRXXID from MZ_GHXX where GHXXID='" + tbsel.Rows[0]["patid"].ToString() + "' ");
                                    string strbrxxid = objbrxxid != null ? objbrxxid.ToString() : "";

                                    YY_BRXX brxx = new YY_BRXX(new Guid(strbrxxid), InstanceForm.BDatabase);
                                    string birth = brxx.Csrq;
                                    string patname = brxx.Brxm;

                                    int gh = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;// InstanceForm.BCurrentUser.EmployeeId;
                                    string cfrq = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
                                    string employeename = TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;
                                    int ksdm = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
                                    string ksmc = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
                                    string mzh = tbsel.Rows[0]["门诊号"].ToString();
                                    string brxmhlyy = tbsel.Rows[0]["姓名"].ToString();
                                    string xb = tbsel.Rows[0]["性别"].ToString();
                                    DataTable tb1 = tbsel;
                                    string icd = tbsel.Rows[0]["诊断"].ToString();
                                    int hfresult = hlyyjk.RegisterServer_fun(null);//打开四灯

                                    hlyyjk.Refresh();
                                    StringBuilder sss = new StringBuilder(ts_mz_hlyy.GetXml(gh, cfrq, employeename, ksdm, ksmc, mzh, birth, brxmhlyy, xb, tb1, icd));

                                    hfresult = hlyyjk.DrugAnalysis(sss, 1);

                                    if (hfresult >= 2)
                                    {
                                        if (MessageBox.Show("警告!处方中可能存在不合理的用药,您要继续发药吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                            return;
                                        hfresult = hlyyjk.SaveDrug(sss, 1);
                                    }

                                    hlyyjk.SaveXml(sss);


                                    //YpClass.Ypcj cj = new YpClass.Ypcj(Convert.ToInt32(tb1.Rows[0]["ypid"].ToString()), InstanceForm.BDatabase);
                                    //string str5 = " <safe><general_name>" + cj.S_YPPM+ "</general_name><license_number>" + cj.GGID.ToString() + "</license_number><type>0</type></safe>";
                                    //hlyyjk.ShowPoint(new StringBuilder(str5));

                                    //if (hfresult >= 2)
                                    //{
                                    //    if (MessageBox.Show("警告!处方中可能存在不合理的用药,您要继续保存吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                    //        return;
                                    //    hfresult = hf.SaveDrug(sss, 1);
                                    //}

                                    #endregion
                                    break;
                                //case "2":
                                //    #region 美康
                                //    #endregion
                                //    break;
                                default:
                                    MessageBox.Show(cfghlyytype + "该合理用药接口不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("PASS错误!原因:" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    #endregion

                    //string[] GroupbyField ={"jssjh","发票号","总金额","记帐金额","优惠金额","自付金额","剂数","cfxh","patid","门诊号","姓名","ysdm","ksdm","收费日期","sfczy","配药窗口"};
                    string[] GroupbyField ={ "jssjh", "发票号", "总金额", "记帐金额", "优惠金额", "自付金额", "cfxh", "patid", "门诊号", "姓名", "ysdm", "ksdm", "收费日期", "sfczy", "配药窗口" };
                    string[] ComputeField ={ "金额" };
                    string[] CField ={ "sum" };
                    DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                    if (tbcf.Rows.Count == 0)
                    {
                        MessageBox.Show("没有要发药的药品记录");
                        SetDefaultFocuse();
                        return;
                    }

                    InstanceForm.DebugView(tbcf);

                    #region ..库存量判断,如果开了不是本库房的药，并且本库房没有这种药的情况 by wangzhi 2014-07-08
                    DataRow[] __rows = tb.Select("发药='◆' and ypid<> ''");
                    DataTable dtInvalid = new DataTable();
                    dtInvalid.Columns.Add("YP");
                    foreach (DataRow r in __rows)
                    {
                        decimal yl = Convert.ToDecimal(Convertor.IsNull(r["用量"], "0"));
                        decimal je = Convert.ToDecimal(Convertor.IsNull(r["金额"], "0"));
                        int ypid = Convert.ToInt32(r["YPID"]);
                        string ypmc = Convertor.IsNull(r["商品名"], "");
                        string ypgg = Convertor.IsNull(r["规格"], "");
                        decimal kcl = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(string.Format("select kcl from YF_KCMX where cjid = {0} and deptid={1}", ypid, InstanceForm.BCurrentDept.DeptId)), "0"));
                        if (kcl <= 0 && (yl != 0 || je != 0))
                        {
                            dtInvalid.Rows.Add(new object[] { ypmc + ypgg });
                        }
                    }
                    if (dtInvalid.Rows.Count > 0)
                    {
                        InventoryNotEnoughException exception = new InventoryNotEnoughException();
                        exception.Data = dtInvalid;
                        throw exception;
                    }
                    #endregion

                    //Add by zhujh 2017-06-26  新增需求：发药的时候先提示：请盖“工伤药品标识”专用章
                    foreach (DataRow item in tb.Rows)
                    {
                        if (Convertor.IsNull(item["中药备注"], "").Contains("工伤"))
                        {
                            MessageBox.Show("请盖“工伤药品标识”专用章", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }

                    if (MessageBox.Show("是否发药？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        SetDefaultFocuse();
                        return;
                    }                  


                    ////Add by zhujh 2017-05-27 新增耗时监控
                    //ExecTimeLogger logger = ExecTimeLogger.Run("药房发药");

                    InstanceForm.DebugView(tb);
                    int cfcount = 0;
                    this.butfy.Enabled = false;
                    //add by wangzhi
                    decimal sumje = 0;
                    //string brxm = "";
                    string _Bz = "";//发药明细备注
                    //end add

                    Dictionary<string, string> updatePyrInfo = new Dictionary<string, string>();
                    if (!bpcgl) //不进行批次管理
                    {
                        InstanceForm.BDatabase.BeginTransaction();

                        #region 插入yf_fy yf_fymx
                        for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                        {
                            DataRow[] rows = tb.Select("发票号='" + tbcf.Rows[i]["发票号"].ToString() + "' and ypid<>'' and 门诊号='" + tbcf.Rows[i]["门诊号"].ToString() + "' AND CFXH='" + tbcf.Rows[i]["CFXH"].ToString() + "'", "序号");

                            #region 插入发药头表
                            MZYF.SaveFy(rows[0]["cflx"].ToString().Trim(),
                                Convert.ToDecimal(tbcf.Rows[i]["jssjh"]),
                                Convert.ToInt64(Convertor.IsNull(tbcf.Rows[i]["发票号"], "0")),
                                Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["总金额"], "0")),
                                Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["记帐金额"], "0")),
                                Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["优惠金额"], "0")),
                                Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["自付金额"], "0")),
                                Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["剂数"], "0")),
                                new Guid(tbcf.Rows[i]["cfxh"].ToString()),
                                new Guid(Convertor.IsNull(tbcf.Rows[i]["patid"], Guid.Empty.ToString())),
                                tbcf.Rows[i]["门诊号"].ToString(),
                                tbcf.Rows[i]["姓名"].ToString(),
                                Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ysdm"], "0")),
                                Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ksdm"], "0")),
                                tbcf.Rows[i]["收费日期"].ToString(),
                                Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["sfczy"], "0")),
                                sDate,
                                InstanceForm.BCurrentUser.EmployeeId,
                             // Convert.ToInt32(cmbpyr.SelectedValue),
                              Convert.ToInt32(GetKF_NY_HH_PYR(tbcf.Rows[i]["cfxh"].ToString())),//此处更改 从快发机得到对应处方的配药员ID Add by hyd 2017-11-30 
                                Convertor.IsNull(tbcf.Rows[i]["配药窗口"], "0"),
                                _Fyckh,
                                InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, 0, _pronamefy, out fyid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase, string.Empty);
                            if (err_code != 0 || fyid == Guid.Empty)
                            {
                                throw new System.Exception(err_text);
                            }
                            this.butfy.Tag = fyid.ToString();
                            #endregion

                            string updateMzcfSql = "update MZ_CFB set PYR = {0},PYRXM = '{1}',PYRQ = '{2}',hxpyr = 1 where cfid = '" + tbcf.Rows[i]["cfxh"].ToString() + "'";
                            string updateYffySql = "update yf_FY set PYR = {0},pyrq = '{1}' where ID = '" + fyid.ToString() + "' ";
                            updatePyrInfo.Add(updateMzcfSql, updateYffySql);

                            #region 插入发药明细
                            for (int j = 0; j <= rows.Length - 1; j++)
                            {
                                string UserEat = rows[j]["频次"].ToString().Trim() == "" ? "" : Convert.ToDouble(rows[j]["剂量"]).ToString() + rows[j]["剂量单位"].ToString().Trim() + "/每次";
                                string yf = Convert.ToString(rows[j]["用法"]) + "  " + rows[j]["使用频次"].ToString().Trim() + " " + UserEat;
                                string zt = Convert.ToString(rows[j]["嘱托"]);
                                MZYF.SaveFymx(fyid,
                                    Convert.ToInt64(Convertor.IsNull(rows[j]["发票号"], "0")),
                                    new Guid(Convertor.IsNull(rows[j]["cfxh"], Guid.Empty.ToString())),
                                    Convert.ToInt32(Convertor.IsNull(rows[j]["ypid"], "0")),
                                    rows[j]["货号"].ToString(),
                                    rows[j]["品名"].ToString(),
                                    rows[j]["商品名"].ToString(),
                                    rows[j]["规格"].ToString(),
                                    rows[j]["厂家"].ToString(),
                                    rows[j]["单位"].ToString(),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["ydwbl"], "0")),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["用量"], "0")),//
                                    Convert.ToInt32(Convertor.IsNull(rows[j]["剂数"], "0")),//
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["批发价"], "0")),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["批发金额"], "0")),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["单价"], "0")),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["金额"], "0")),
                                    0,
                                    0,
                                    InstanceForm.BCurrentDept.DeptId,
                                    Guid.Empty,
                                    "",
                                    Guid.Empty,
                                    new Guid(Convertor.IsNull(rows[j]["cfmxid"], Guid.Empty.ToString())),
                                    rows[j]["皮试"].ToString(),
                                    yf.Trim(),
                                    zt.Trim(),
                                    Convertor.IsNull(rows[j]["用法"], ""),
                                    Convertor.IsNull(rows[j]["频次"], ""),
                                    Convertor.IsNull(rows[j]["剂量"], ""),
                                    Convertor.IsNull(rows[j]["剂量单位"], ""),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["天数"], "0")),
                                    Convert.ToInt32(Convertor.IsNull(rows[j]["组标志"], "0")),
                                    Convert.ToInt32(Convertor.IsNull(rows[j]["排序序号"], "0")),
                                    _pronamefymx,
                                    out fymxid,
                                    out err_code,
                                    out err_text,
                                    0, 0, "", "", Guid.Empty,
                                    InstanceForm.BDatabase, bpcgl);
                                if (err_code != 0)
                                {
                                    throw new System.Exception(err_text);
                                }
                                cfcount = cfcount + 1;


                                string ssql = "select '[" + rows[j]["品名"].ToString() + "] 库存量:'+cast(cast(round(kcl/dwbl,3) as float) as varchar(50))+rtrim(dbo.fun_yp_ypdw(nypdw))+',低于下限值:' +cast(cast(kcxx as float) as varchar(30))+rtrim(dbo.fun_yp_ypdw(nypdw)) as bz from yf_kcmx a,yp_kcsxx b where a.cjid=b.cjid and a.deptid=b.deptid and round(kcl/dwbl,3)<kcxx  and kcxx>0 and a.cjid=" + Convert.ToInt32(Convertor.IsNull(rows[j]["ypid"], "0")) + " and a.deptid=" + InstanceForm.BCurrentDept.DeptId + " ";
                                DataTable tbsxx = InstanceForm.BDatabase.GetDataTable(ssql);
                                if (tbsxx.Rows.Count > 0)
                                    _Bz = _Bz + Convertor.IsNull(tbsxx.Rows[0][0], "") + "\n";
                            }

                            #endregion

                            //add by wangzhi
                            sumje += Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["总金额"], "0"));
                            //brxm = tbcf.Rows[i]["姓名"].ToString().Trim();
                            //end add   
                        }

                        if (selrow.Length != cfcount)
                        {
                            throw new Exception("发生错误,后台更新的行数不等于您当前选择发药的行数");
                        }

                        #endregion
                    }
                    else
                    {
                        #region
                        DataRow[] rows_cfmx = tb.Select("发药='◆' and ypid<>''", "cfxh,序号");
                        DataTable tbkcph = InstanceForm.BDatabase.GetDataTable(@"select ID kcid,yppch,CJID,YPPH,YPXQ,JHJ,KCL,0 
                            as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj,dbo.fun_yp_ypdw(zxdw) as kcdw from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and kcl>0 and bdelete = 0 ");


                        #region 添加列
                        if (!tb.Columns.Contains("YPPCH2"))
                        {
                            tb.Columns.Add(new DataColumn("YPPCH2", Type.GetType("System.String")));
                        }

                        if (!tb.Columns.Contains("YPPH2"))
                        {
                            tb.Columns.Add(new DataColumn("YPPH2", Type.GetType("System.String")));
                        }
                        if (!tb.Columns.Contains("YPXQ2"))
                        {
                            tb.Columns.Add(new DataColumn("YPXQ2", Type.GetType("System.String")));
                        }
                        if (!tb.Columns.Contains("KCID2"))
                        {
                            tb.Columns.Add(new DataColumn("KCID2", Type.GetType("System.String")));
                        }
                        if (!tb.Columns.Contains("JHJ2"))
                        {
                            tb.Columns.Add(new DataColumn("JHJ2", Type.GetType("System.Decimal")));
                        }
                        if (!tb.Columns.Contains("JHJE2"))
                        {
                            tb.Columns.Add(new DataColumn("JHJE2", Type.GetType("System.Decimal")));
                        }
                        if (!tb.Columns.Contains("KDSl"))
                        {
                            tb.Columns.Add(new DataColumn("KDSl", Type.GetType("System.Decimal")));//可抵数量
                        }
                        #endregion

                        DataTable tb_temp = tb.Clone();//待分配明细
                        DataRow[] rows_sel = tb.Select("发药='◆' and ypid<>''", "cfxh,序号");



                        decimal sumlsje = 0;//零售金额合计
                        decimal sumpfje = 0;//批发金额合计
                        decimal _sumlsje = 0;
                        decimal _sumpfje = 0;
                        for (int i = 0; i < rows_sel.Length; i++)
                        {
                            //decimal lsje = Convert.ToDecimal(rows_sel[i]["金额"]);
                            //sumlsje += lsje;
                            //decimal pfje = Convert.ToDecimal(rows_sel[i]["批发金额"]);
                            //sumpfje += pfje;

                            decimal yl = Convert.ToDecimal(rows_sel[i]["用量"]);
                            decimal js = Convert.ToDecimal(rows_sel[i]["剂数"]);
                            decimal lsj = Convert.ToDecimal(rows_sel[i]["单价"]);
                            decimal pfj = Convert.ToDecimal(rows_sel[i]["批发价"]);
                            decimal lsje = Convert.ToDecimal(yl * js * lsj);//零售金额
                            decimal pfje = Convert.ToDecimal(yl * js * pfj);//批发金额
                            sumlsje += lsje;
                            sumpfje += pfje;

                            tb_temp.ImportRow(rows_sel[i]);
                        }
                        DataTable tb_pcmx = tb.Clone();
                        DataTable tb_pcmx_fs = tb.Clone();
                        DataTable tb_pcmx_zs_wfp = tb.Clone();

                        try
                        {
                            #region 分配批次

                            //第一步：正负明细先抵销,被抵消的正负明细分配第一个库存批次,如果找不到库存，就去找最近的库存批次
                            DataRow[] rows_fs = tb_temp.Select("发药='◆' and ypid<>'' and ypsl<0", "cfxh,序号");
                            DataRow[] rows_zs;
                            #region
                            for (int i = 0; i < rows_fs.Length; i++)
                            {
                                int dwbl_fs = Convert.ToInt32(rows_fs[i]["dwbl"]);
                                DataRow row_fs = rows_fs[i];
                                decimal ypsl_fs = Convert.ToDecimal(row_fs["ypsl"]);//待处理负数数量
                                rows_zs = tb_temp.Select("发药='◆' and ypid<>'' and cfmxid='" + row_fs["tyid"] + "'", "cfxh,序号");
                                for (int j = 0; j < rows_zs.Length; j++)
                                {
                                    int dwbl_zs = Convert.ToInt32(rows_zs[j]["dwbl"]);
                                    if (dwbl_zs != dwbl_fs)
                                    {
                                        throw new Exception("单位比例发生错误,退药明细中单位比例与原单位比例不一致");
                                    }
                                    DataRow row_zs = rows_zs[j];
                                    decimal ypsl_zs = Convert.ToDecimal(row_zs["ypsl"]);
                                    if (ypsl_zs <= 0)
                                        continue;
                                    if (ypsl_fs == 0)
                                        break;
                                    decimal cksl = 0;//出库数 负数
                                    decimal temp = ypsl_fs + ypsl_zs;
                                    if (temp >= 0)//正数明细数量 大于 待处理负数数量
                                    {
                                        cksl = ypsl_fs;
                                        ypsl_fs = 0;
                                    }
                                    else//正数明细数量小于 待处理负数数量
                                    {
                                        cksl = ypsl_zs * (-1);
                                        ypsl_fs = ypsl_fs + ypsl_zs;
                                    }

                                    //填入批次信息
                                    DataRow[] rows_kcph = new DataRow[] { };
                                    if (pcglfs == "0")//先进先出
                                        rows_kcph = tbkcph.Select("cjid=" + row_fs["ypid"].ToString() + "", "djsj asc");
                                    else//近效期先出
                                        rows_kcph = tbkcph.Select("cjid=" + row_fs["ypid"].ToString() + "", "ypxq asc");
                                    if (rows_kcph.Length == 0)
                                        rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row_fs["cjid"].ToString() + " order by djsj desc ").Select();

                                    if (rows_kcph.Length <= 0)
                                        throw new Exception("库存中不存在记录！");

                                    //负数明细部分
                                    DataRow rowkcph = rows_kcph[0];
                                    DataRow newrow_fs = tb_temp.NewRow();
                                    newrow_fs = row_fs;
                                    newrow_fs["yppch2"] = rowkcph["yppch"];
                                    newrow_fs["ypph2"] = rowkcph["ypph"];
                                    newrow_fs["ypxq2"] = rowkcph["ypxq"];
                                    newrow_fs["kcid2"] = rowkcph["kcid"];
                                    decimal jhj_kc = Convert.ToDecimal(rowkcph["jhj"]);//库存进价
                                    //int dwbl_kc = Convert.ToInt32(rowkcph["dwbl"]);
                                    decimal jhj = Convert.ToDecimal(jhj_kc / dwbl_fs);
                                    newrow_fs["jhj2"] = jhj;
                                    newrow_fs["ypsl"] = cksl;//数量
                                    newrow_fs["jhje2"] = Convert.ToDecimal(cksl * jhj);//进货金额
                                    newrow_fs["kdsl"] = 0;//可抵数量
                                    tb_pcmx.ImportRow(newrow_fs);

                                    //正数明细部分
                                    DataRow newrow_zs = tb_temp.NewRow();
                                    newrow_zs = row_zs;
                                    newrow_zs["yppch2"] = rowkcph["yppch"];
                                    newrow_zs["ypph2"] = rowkcph["ypph"];
                                    newrow_zs["ypxq2"] = rowkcph["ypxq"];
                                    newrow_zs["kcid2"] = rowkcph["kcid"];
                                    newrow_zs["jhj2"] = jhj;
                                    newrow_zs["jhje2"] = Convert.ToDecimal(cksl * jhj * (-1));//进货金额
                                    newrow_zs["ypsl"] = Convert.ToDecimal(cksl * (-1));//数量
                                    newrow_zs["kdsl"] = 0;//可抵数量
                                    tb_pcmx.ImportRow(newrow_zs);

                                    //decimal mmmmm = Convert.ToDecimal(row_zs["ypsl"]);
                                    //row_zs["ypsl"] = Convert.ToDecimal(row_zs["ypsl"]) + cksl;//改变正数


                                    row_fs["ypsl"] = ypsl_fs;//改变负数
                                    row_zs["ypsl"] = ypsl_zs + cksl;
                                }

                            }
                            #endregion
                            //InstanceForm.DebugView( tb_temp );
                            //第二步：分配正数批次
                            //DataRow[] rows_mx = tb_temp.Select( "发药='◆' and ypid<>'' and ypsl>0" , "cfxh,序号" ); //comment by wangzhi by 2014-07-11
                            DataRow[] rows_mx = tb_temp.Select("发药='◆' and ypid<>'' and ( ypsl>=0 or ypsl is null)", "cfxh,序号");

                            int mm = rows_mx.Length;

                            #region
                            for (int i = 0; i < rows_mx.Length; i++)
                            {
                                #region 分配库存
                                DataRow row = rows_mx[i];
                                DataRow[] rows_kcph;
                                if (pcglfs == "0")
                                    rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 and cjid=" + row["ypid"].ToString() + "", "djsj asc,yppch asc ");
                                else
                                    rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 and cjid=" + row["ypid"].ToString() + "", "ypxq asc");

                                //单位比例比较
                                if (rows_kcph.Length > 0)
                                {
                                    int dwbl_kc = Convert.ToInt32(rows_kcph[0]["dwbl"]);
                                    int dwbl_mx = Convert.ToInt32(row["dwbl"]);
                                    if (dwbl_kc != dwbl_mx)
                                    {
                                        throw new Exception("单位比例发生变化,请刷新数据后重试！");
                                    }
                                }

                                decimal sysl = Convert.ToDecimal(row["ypsl"]);//剩余数量

                                //配合数量为零。且没有库存的药品做特别处理。是指的门诊大输液药品 2014-07-11
                                if (sysl == 0 && rows_kcph.Length == 0)
                                {
                                    DataTable tbkcph_ex = InstanceForm.BDatabase.GetDataTable(@"select dbo.FUN_GETEMPTYGUID() kcid,'11111111111' yppch,CJID,'' as YPPH,'2014-07-11' as YPXQ, 0 JHJ,100 KCL,0 
                            as CKL,YPDW,1 DWBL,0 BDELETE,0 ykbdelete,djsj from vi_yp_ypcd where CJID=" + rows_mx[i]["ypid"] + "   ");
                                    rows_kcph = tbkcph_ex.Select(" kcl>0 and bdelete = 0 and cjid=" + row["ypid"].ToString() + "", "ypxq asc");
                                }

                                for (int j = 0; j < rows_kcph.Length; j++)//批号库存行
                                {
                                    DataRow row1 = rows_kcph[j];
                                    decimal cksl = 0;//本次出库量
                                    decimal kcl = Convert.ToDecimal(row1["kcl"]);//批次库存量
                                    if (kcl == 0)
                                        continue;
                                    if (sysl < 0)  //if ( sysl == 0 )//wangzhi 2014-07-11
                                        break;
                                    if (kcl > sysl)//库存量大于剩余数量
                                    {
                                        cksl = sysl;
                                        sysl = 0;
                                    }
                                    else//库存量小于剩余数量
                                    {
                                        cksl = kcl;
                                        sysl = sysl - kcl;
                                    }
                                    //回填批次相关信息
                                    DataRow newrow = tb_temp.NewRow();
                                    newrow = row;
                                    newrow["yppch2"] = row1["yppch"];
                                    newrow["ypph2"] = row1["ypph"];
                                    newrow["ypxq2"] = row1["ypxq"];
                                    newrow["kcid2"] = row1["kcid"];
                                    decimal jhj = Math.Round(Convert.ToDecimal(row1["jhj"]) / Convert.ToInt32(row1["dwbl"]), 4);
                                    newrow["jhj2"] = jhj;
                                    newrow["jhje2"] = Math.Round(jhj * cksl, 3);
                                    newrow["ypsl"] = cksl;
                                    //decimal pfj = Convert.ToDecimal(row["批发价"]);
                                    //newrow["批发价"] = pfj;
                                    //newrow["批发金额"] = Convert.ToDecimal(pfj * cksl);
                                    newrow["KCID2"] = row1["kcid"];
                                    newrow["KDSL"] = 0;//可抵数量
                                    tb_pcmx.ImportRow(newrow);
                                    row1["kcl"] = kcl - cksl;//将批次库存减掉
                                    if (sysl == 0)//如果剩余数量等于0 跳出当前批次库存循环
                                    {
                                        break;
                                    }
                                }
                                #endregion

                                #region 未分配的正数 如果剩余数量仍然>0
                                if (sysl > 0)
                                {
                                    row["ypsl"] = sysl;
                                    if (Convert.ToDecimal(row["ypsl"]) > 0)
                                    {
                                        DataRow row_zs = tb_temp.NewRow();
                                        row_zs = row;
                                        tb_pcmx_zs_wfp.ImportRow(row);
                                    }
                                }
                                #endregion
                            }
                            #endregion

                            //第三步：分配剩下的负数明细 用第一个批次明细   
                            rows_mx = tb_temp.Select("发药='◆' and ypid<>'' and ypsl<0", "cfxh,序号");
                            for (int i = 0; i < rows_mx.Length; i++)
                            {
                                DataRow row = rows_mx[i];

                                #region 批次分解
                                decimal ypsl = Convert.ToDecimal(row["ypsl"]);
                                DataRow[] rows_kcph = new DataRow[] { };

                                if (pcglfs == "0")
                                    rows_kcph = tbkcph.Select("cjid=" + row["ypid"].ToString() + "", "djsj asc");
                                else
                                    rows_kcph = tbkcph.Select("cjid=" + row["ypid"].ToString() + "", "ypxq asc");
                                if (rows_kcph.Length == 0)
                                {
                                    if (pcglfs == "0")
                                    {
                                        rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by djsj desc,yppch desc ").Select();
                                    }
                                    else
                                    {
                                        rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by ypxq desc ").Select();
                                    }
                                }
                                if (rows_kcph.Length < 0)
                                    throw new Exception("找不到库存批次记录！");

                                //回填批次相关信息  
                                DataRow row1 = rows_kcph[0];
                                DataRow newrow = tb_temp.NewRow();
                                newrow = row;
                                newrow["yppch2"] = row1["yppch"];
                                newrow["ypph2"] = row1["ypph"];
                                newrow["ypxq2"] = row1["ypxq"];
                                newrow["kcid2"] = row1["kcid"];
                                decimal jhj_kc = Convert.ToDecimal(row1["jhj"]);
                                decimal dwbl_fs = Convert.ToInt32(row1["dwbl"]);
                                decimal jhj = Convert.ToDecimal(jhj_kc / dwbl_fs);//进价
                                newrow["jhj2"] = jhj;
                                newrow["jhje2"] = Math.Round(jhj * ypsl, 3);
                                newrow["ypsl"] = ypsl;
                                decimal pfj = Convert.ToDecimal(row["批发价"]);
                                //newrow["批发价"] = pfj;
                                //newrow["批发金额"] = Math.Round(pfj * ypsl, 2);
                                newrow["KDSL"] = ypsl * (-1);//可抵数量
                                tb_pcmx_fs.ImportRow(newrow);
                                //将批次库存减掉
                                row1["kcl"] = Convert.ToDecimal(row1["kcl"]) - ypsl;

                                #endregion
                            }

                            //第四步：处理未能未分配的正数，去已经分配的负数中去抵消  
                            foreach (DataRow row_zs in tb_pcmx_zs_wfp.Rows)
                            {
                                #region 批次分解
                                decimal sysl = Convert.ToDecimal(row_zs["ypsl"]);
                                int dwbl_zs = Convert.ToInt32(row_zs["dwbl"]);

                                rows_fs = tb_pcmx_fs.Select(" kdsl>0 and ypid=" + row_zs["ypid"].ToString());
                                for (int i = 0; i < rows_fs.Length; i++)
                                {

                                    decimal cks = 0;
                                    DataRow row_fs = rows_fs[i];
                                    int dwbl_fs = Convert.ToInt32(rows_fs[i]["dwbl"]);

                                    if (dwbl_fs != dwbl_zs)
                                    {
                                        throw new Exception("单位比例发生变化，请刷新数据后重试！");
                                    }

                                    decimal kdsl = Convert.ToDecimal(row_fs["kdsl"]);
                                    if (kdsl == 0)
                                        continue;

                                    if (kdsl >= sysl)
                                    {
                                        kdsl = kdsl - sysl;
                                        cks = sysl;
                                        sysl = 0;
                                    }
                                    else
                                    {
                                        cks = kdsl;
                                        kdsl = 0;
                                        sysl -= cks;
                                    }
                                    row_fs["kdsl"] = kdsl;

                                    DataRow newrow = tb_temp.NewRow();
                                    newrow = row_zs;
                                    newrow["yppch2"] = row_fs["yppch2"];//批次号
                                    newrow["ypph2"] = row_fs["ypph2"];//批号
                                    newrow["ypxq2"] = row_fs["ypxq2"];//效期
                                    newrow["kcid2"] = row_fs["kcid2"];//kcid
                                    newrow["jhj2"] = row_fs["jhj2"];
                                    newrow["jhje2"] = Convert.ToDecimal(Convert.ToDecimal(row_fs["jhj2"]) * cks);
                                    newrow["ypsl"] = cks;

                                    tb_pcmx.ImportRow(newrow);
                                    row_zs["ypsl"] = sysl;

                                    if (sysl == 0)
                                    {
                                        break;
                                    }
                                    if (kdsl == 0)
                                    {
                                        continue;
                                    }
                                }
                                #endregion
                            }
                            foreach (DataRow row in tb_pcmx_fs.Rows)
                            {
                                tb_pcmx.ImportRow(row);
                            }
                            //第五步：如果还有未分配的正数，则报错
                            DataRow[] rows_zs_wfp = tb_pcmx_zs_wfp.Select("ypsl>0");
                            if (rows_zs_wfp.Length > 0)
                            {
                                throw new Exception(string.Format("{0} {1} 可用库存量不足！", rows_zs_wfp[0]["品名"], rows_zs_wfp[0]["规格"]));
                            }
                            #endregion

                            //string str = "批次明细：\n";
                            //foreach (DataRow row in tb_pcmx.Rows)
                            //{
                            //    str += row["品名"].ToString().Trim() + " " + row["规格"].ToString().Trim() + " " + row["ypsl"].ToString().Trim() + " " + row["yppch2"].ToString() + row["jhj2"].ToString() + ">>\n";
                            //}
                            //MessageBox.Show(str);
                            //return;

                        }
                        catch (Exception err_pc)
                        {
                            MessageBox.Show("分配库存批次时发生错误：" + err_pc.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            butfy.Enabled = true;
                            return;
                        }
                        //MessageBox.Show("ok");
                        //butfy.Enabled = true;
                        //return;


                        //汇总批次明细

                        //string[] GroupbyField ={"jssjh","发票号","总金额","记帐金额","优惠金额","自付金额","剂数","cfxh",
                        //                         "patid","门诊号","姓名","ysdm","ksdm","收费日期","sfczy","配药窗口"};
                        //string[] ComputeField ={ "ypsl" };
                        //string[] CField ={ "sum" };
                        //DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);

                        InstanceForm.DebugView(tb_pcmx);

                        InstanceForm.BDatabase.BeginTransaction();

                        #region 插入yf_fy yf_fymx
                        for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                        {
                            //DataRow[] rowssss = tbcf.Select("");

                            //int cflx = 0;//处方类型  如果进行批次管理 对类型为03(中药)需特殊处理
                            string strFilter = string.Format("发票号='{0}' and ypid<>'' and 门诊号='{1}' AND CFXH='{2}'", tbcf.Rows[i]["发票号"], tbcf.Rows[i]["门诊号"], tbcf.Rows[i]["CFXH"]);
                            //InstanceForm.DebugView( tb_pcmx );
                            DataRow[] rows = tb_pcmx.Select(strFilter, "序号");

                            int count = rows.Length;
                            if (count == 0)
                                throw new Exception("检索明细失败，条件:" + strFilter);


                            #region 插入发药表头
                            MZYF.SaveFy(rows[0]["cflx"].ToString().Trim(),
                              Convert.ToDecimal(tbcf.Rows[i]["jssjh"]),
                              Convert.ToInt64(Convertor.IsNull(tbcf.Rows[i]["发票号"], "0")),
                              Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["总金额"], "0")),
                              Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["记帐金额"], "0")),
                              Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["优惠金额"], "0")),
                              Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["自付金额"], "0")),
                              Convert.ToInt32(Convertor.IsNull(tb_pcmx.Rows[0]["剂数"], "0")),
                              new Guid(tbcf.Rows[i]["cfxh"].ToString()),
                              new Guid(Convertor.IsNull(tbcf.Rows[i]["patid"], Guid.Empty.ToString())),
                              tbcf.Rows[i]["门诊号"].ToString(),
                              tbcf.Rows[i]["姓名"].ToString(),
                              Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ysdm"], "0")),
                              Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ksdm"], "0")),
                              tbcf.Rows[i]["收费日期"].ToString(),
                              Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["sfczy"], "0")),
                              sDate,
                              InstanceForm.BCurrentUser.EmployeeId,
                            //  Convert.ToInt32(cmbpyr.SelectedValue),
                            Convert.ToInt32(GetKF_NY_HH_PYR(tbcf.Rows[i]["cfxh"].ToString())),//此处进行更改从快发机得到处方对应的配药员     Add by hyd 2017-11-30                        
                              Convertor.IsNull(tbcf.Rows[i]["配药窗口"], "0"),
                              _Fyckh,
                              InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, 0,
                              _pronamefy, out fyid, out err_code, out err_text,
                              InstanceForm._menuTag.Jgbm,
                              InstanceForm.BDatabase, string.Empty);
                            if (err_code != 0 || fyid == Guid.Empty)
                            {
                                throw new System.Exception(err_text);
                            }
                            this.butfy.Tag = fyid.ToString();

                            
                            string updateMzcfSql = "update MZ_CFB set PYR = {0},PYRXM = '{1}',PYRQ = '{2}',hxpyr = 1 where cfid = '" + tbcf.Rows[i]["cfxh"].ToString() + "'";
                            string updateYffySql = "update yf_FY set PYR = {0},pyrq = '{1}' where ID = '" + fyid.ToString() + "' ";
                            updatePyrInfo.Add(updateMzcfSql, updateYffySql);
                            #endregion

                            #region  老的插入发药明细 对于中药 拆用量而不拆剂数 用量必须特殊处理
                            //decimal sumjhje = 0;//总进货金额
                            //DataRow[] rows_pc = tb_pcmx.Select("cfxh='"+tbcf.Rows[i]["cfxh"]+"'");
                            ////DataRow[] rows_pc = tb.Select("发票号='" + tbcf.Rows[i]["发票号"].ToString() + "' and ypid<>'' and 门诊号='" + tbcf.Rows[i]["门诊号"].ToString() + "' AND CFXH='" + tbcf.Rows[i]["CFXH"].ToString() + "'", "序号");
                            //for (int m = 0; m < rows_pc.Length; m++)
                            //{
                            //    DataRow rowpc = rows_pc[m];
                            //    string UserEat = rowpc["频次"].ToString().Trim() == "" ? "" : Convert.ToDouble(rowpc["剂量"]).ToString() + rowpc["剂量单位"].ToString().Trim() + "/每次";
                            //    string yf = Convert.ToString(rowpc["用法"]) + "  " + rowpc["使用频次"].ToString().Trim() + " " + UserEat;
                            //    string zt = Convert.ToString(rowpc["嘱托"]);

                            //    int dwbl = Convert.ToInt32(rowpc["dwbl"]) ;     //库存dwbl
                            //    decimal ypsl = Convert.ToDecimal(rowpc["ypsl"]);
                            //    decimal jhj = Convert.ToDecimal(rowpc["jhj2"]); //进价
                            //    decimal jhje = Convert.ToDecimal(jhj * ypsl);   //进货金额
                            //    string ypph = rowpc["ypph2"].ToString();
                            //    string ypxq = rowpc["ypxq2"].ToString();
                            //    string yppch = rowpc["yppch2"].ToString();
                            //    Guid kcid = new Guid(rowpc["kcid2"].ToString());

                            //    int dwbl_cfmx = Convert.ToInt32(rowpc["ydwbl"]);//处方明细dwbl
                            //    int js_cfmx = Convert.ToInt32(rowpc["剂数"]);
                            //    //decimal ypsl_cfmx =Convert.ToDecimal( ypsl * dwbl / dwbl_cfmx);//处方明细中数量
                            //    //Modify by dyw 2014/6/30
                            //    decimal ypsl_cfmx = Convert.ToDecimal(ypsl * dwbl_cfmx/ dwbl);//处方明细中数量 
                            //    decimal yl_cfmx = Convert.ToDecimal( ypsl_cfmx / js_cfmx);//处方明细中用量
                            //    decimal jhj_cfmx =Convert.ToDecimal( jhj * dwbl_cfmx /dwbl);//处方明细中进价？
                            //    decimal jhje_cfmx = jhje;

                            //    decimal pfj_cfmx = Convert.ToDecimal(rowpc["批发价"]);//处方明细批发价
                            //    decimal pfje_cfmx = Convert.ToDecimal(pfj_cfmx*ypsl_cfmx);//处方明细批发金额

                            //    decimal lsj_cfmx = Convert.ToDecimal(rowpc["单价"]);//处方明细零售价
                            //    decimal lsje_cfmx = Convert.ToDecimal(lsj_cfmx*ypsl_cfmx);//处方明细零售金额

                            //    _sumlsje += lsje_cfmx;
                            //    _sumpfje += pfje_cfmx;

                            //    #region 插入发药明细
                            //    MZYF.SaveFymx(fyid,
                            //                    Convert.ToInt64(Convertor.IsNull(rowpc["发票号"], "0")),
                            //                    new Guid(Convertor.IsNull(rowpc["cfxh"], Guid.Empty.ToString())),
                            //                    Convert.ToInt32(Convertor.IsNull(rowpc["ypid"], "0")),
                            //                    rowpc["货号"].ToString(),
                            //                    rowpc["品名"].ToString(),
                            //                    rowpc["商品名"].ToString(),
                            //                    rowpc["规格"].ToString(),
                            //                    rowpc["厂家"].ToString(),
                            //                    rowpc["单位"].ToString(),
                            //                    dwbl_cfmx,                  //单位比例
                            //                    yl_cfmx,                    //用量
                            //                    js_cfmx,                    //剂数
                            //                    pfj_cfmx,                   //批发价
                            //                    pfje_cfmx,                  //批发金额
                            //                    lsj_cfmx,                   //零售价
                            //                    lsje_cfmx,                  //零售金额
                            //                    0,
                            //                    0,
                            //                    InstanceForm.BCurrentDept.DeptId,
                            //                    new Guid(Convertor.IsNull(rowpc["tyid"],Guid.Empty.ToString())),
                            //                    ypph,
                            //                    Guid.Empty,
                            //                    new Guid(Convertor.IsNull(rowpc["cfmxid"], Guid.Empty.ToString())),
                            //                    rowpc["皮试"].ToString(),
                            //                    yf.Trim(),                                                    //用法
                            //                    zt.Trim(),                                                    //嘱托
                            //                    Convertor.IsNull(rowpc["用法"], ""),                          //用法
                            //                    Convertor.IsNull(rowpc["频次"], ""),                          //频次
                            //                    Convertor.IsNull(rowpc["剂量"], ""),                          //剂量
                            //                    Convertor.IsNull(rowpc["剂量单位"], ""),                      //剂量单位
                            //                    Convert.ToDecimal(Convertor.IsNull(rowpc["天数"], "0")),      //天数
                            //                    Convert.ToInt32(Convertor.IsNull(rowpc["组标志"], "0")),      //组标志
                            //                    Convert.ToInt32(Convertor.IsNull(rowpc["排序序号"], "0")),    //排序标志
                            //                    _pronamefymx,                                                 //存储过程明
                            //                    out fymxid,                                                   //fymxid
                            //                    out err_code,
                            //                    out err_text,
                            //                    jhj_cfmx,           //进价
                            //                    jhje_cfmx,          //进货金额
                            //                    ypxq,               //效期       
                            //                    yppch,              //批次号
                            //                    kcid,               //kcid
                            //                    InstanceForm.BDatabase,
                            //                    bpcgl);

                            //        if (err_code != 0)
                            //        {
                            //            throw new System.Exception(err_text);
                            //        }
                            //    #endregion
                            //    sumjhje += jhje;     //进货金额
                            //}

                            #endregion

                            #region 插入发药明细 对于中药 拆用量而不拆剂数 用量必须特殊处理
                            decimal sumjhje = 0;//总进货金额
                            DataRow[] rows_pc = tb_pcmx.Select("cfxh='" + tbcf.Rows[i]["cfxh"] + "'");
                            //DataRow[] rows_pc = tb.Select("发票号='" + tbcf.Rows[i]["发票号"].ToString() + "' and ypid<>'' and 门诊号='" + tbcf.Rows[i]["门诊号"].ToString() + "' AND CFXH='" + tbcf.Rows[i]["CFXH"].ToString() + "'", "序号");
                            for (int m = 0; m < rows_pc.Length; m++)
                            {
                                DataRow rowpc = rows_pc[m];
                                string UserEat = rowpc["频次"].ToString().Trim() == "" ? "" : Convert.ToDouble(rowpc["剂量"]).ToString() + rowpc["剂量单位"].ToString().Trim() + "/每次";
                                string yf = Convert.ToString(rowpc["用法"]) + "  " + rowpc["使用频次"].ToString().Trim() + " " + UserEat;
                                string zt = Convert.ToString(rowpc["嘱托"]);
                                int dwbl = Convert.ToInt32(rowpc["dwbl"]);     //库存dwbl
                                decimal ypsl = Convert.ToDecimal(Convertor.IsNull(rowpc["ypsl"], "0"));//按库存单位比例算的
                                decimal jhj = Convert.ToDecimal(rowpc["jhj2"]); //库存单位进价
                                decimal jhje = Math.Round(Convert.ToDecimal(jhj * ypsl), 4);   //进货金额=库存单位进价*库存单位数量
                                string ypph = rowpc["ypph2"].ToString();
                                string ypxq = rowpc["ypxq2"].ToString();
                                string yppch = rowpc["yppch2"].ToString();
                                Guid kcid = new Guid(rowpc["kcid2"].ToString());
                                int dwbl_cfmx = Convert.ToInt32(rowpc["ydwbl"]);//处方明细dwbl
                                int js_cfmx = Convert.ToInt32(rowpc["剂数"]);
                                decimal ypsl_cfmx = Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl);//处方明细数量 

                                //-- comment by wangzhi
                                //decimal yl_cfmx = Convert.ToDecimal( ypsl_cfmx / js_cfmx );
                                //decimal jhj_cfmx = Convert.ToDecimal( jhj * dwbl / dwbl_cfmx );//处方明细中进价  将库存的进货价反算明细的进货价
                                //decimal pfj_cfmx = Convert.ToDecimal( rowpc["批发价"] );//处方明细批发价 (划价时的批发价)
                                //decimal pfje_cfmx = Math.Round( Convert.ToDecimal( pfj_cfmx * yl_cfmx * js_cfmx ) , 4 );//处方明细批发金额=处方明细批发价*处方明细用量*处方明细剂数
                                //decimal lsj_cfmx = Convert.ToDecimal( rowpc["单价"] );//处方明细零售价
                                //decimal lsje_cfmx = Math.Round( Convert.ToDecimal( lsj_cfmx * yl_cfmx * js_cfmx ) , 4 );//处方明细零售金额=处方明细零售价*处方明细用量*处方明细剂数
                                //-- end comment

                                //------------------modify by wangzhi at 2014-08-01------------------                            
                                decimal yl_cfmx = decimal.Round(ypsl_cfmx / js_cfmx, 6);
                                string cfmxdw = rowpc["单位"].ToString();  //处方中的单位，注意：可能是大单位，也可能是小单位
                                string ss = kcid.ToString();
                                InstanceForm.DebugView(tbkcph);
                                string kcdw = cfmxdw;
                                if (kcid != Guid.Empty)
                                    kcdw = tbkcph.Select(string.Format("kcid='{0}'", kcid))[0]["kcdw"].ToString().Trim();
                                string fydw = cfmxdw;//发药单位先默认处方中的单位
                                decimal fyjhj = jhj; //发药的进价
                                decimal fypfj = 0;
                                decimal fylsj = 0;
                                int fy_dwbl = dwbl; //写发药表的单位比例先默认库存单位比例
                                yl_cfmx = ypsl; //强制用量为数量，ypsl处方中的真实数量，(这里的数量已经在前面批次拆分时按库存单位算好了,单位为库存单位)
                                js_cfmx = 1;    //强制剂数为 1                            
                                fydw = kcdw;   //写发药表的单位先默认库存单位

                                decimal jhj_cfmx = Convert.ToDecimal(jhj * dwbl / dwbl_cfmx);//处方明细中进价  将库存的进货价反算明细的进货价
                                fyjhj = jhj;
                                decimal jhje_cfmx = jhje;

                                //批发价及金额
                                decimal pfj_cfmx = Convert.ToDecimal(rowpc["批发价"]);//处方明细批发价 (划价时的批发价)
                                decimal pfje_cfmx = Math.Round(Convert.ToDecimal(pfj_cfmx * yl_cfmx * js_cfmx), 4);//处方明细批发金额=处方明细批发价*处方明细用量*处方明细剂数
                                //如果划价时的单位和库存最小单位不一致，则将价格和金额转为和库存单位保持一致
                                pfj_cfmx = Math.Round(Convert.ToDecimal(rowpc["批发价"]) * dwbl_cfmx / dwbl, 4);
                                pfje_cfmx = Math.Round(Convert.ToDecimal(pfj_cfmx * yl_cfmx * js_cfmx), 4);

                                //零售价及金额
                                decimal lsj_cfmx = Convert.ToDecimal(rowpc["单价"]);//处方明细零售价
                                decimal lsje_cfmx = Math.Round(Convert.ToDecimal(lsj_cfmx * yl_cfmx * js_cfmx), 4);//处方明细零售金额=处方明细零售价*处方明细用量*处方明细剂数
                                lsj_cfmx = Math.Round(Convert.ToDecimal(rowpc["单价"]) * dwbl_cfmx / dwbl, 4);
                                lsje_cfmx = Math.Round(Convert.ToDecimal(lsj_cfmx * yl_cfmx * js_cfmx), 4);
                                //------------------end modify by wangzhi at 2014-08-01------------------

                                //lsje_cfmx = Convert.ToDecimal( Convertor.IsNull( rowpc["金额"] , "0" ) );
                                _sumlsje += lsje_cfmx;
                                _sumpfje += pfje_cfmx;
                                #region 插入发药明细
                                MZYF.SaveFymx(fyid,
                                                Convert.ToInt64(Convertor.IsNull(rowpc["发票号"], "0")),
                                                new Guid(Convertor.IsNull(rowpc["cfxh"], Guid.Empty.ToString())),
                                                Convert.ToInt32(Convertor.IsNull(rowpc["ypid"], "0")),
                                                rowpc["货号"].ToString(),
                                                rowpc["品名"].ToString(),
                                                rowpc["商品名"].ToString(),
                                                rowpc["规格"].ToString(),
                                                rowpc["厂家"].ToString(),
                                                fydw,//rowpc["单位"].ToString() ,
                                                fy_dwbl, // dwbl_cfmx ,                  //单位比例
                                                yl_cfmx,                    //用量
                                                js_cfmx,                    //剂数
                                                pfj_cfmx,                   //批发价
                                                pfje_cfmx,                  //批发金额
                                                lsj_cfmx,                   //零售价
                                                lsje_cfmx,                  //零售金额
                                                0,
                                                0,
                                                InstanceForm.BCurrentDept.DeptId,
                                                new Guid(Convertor.IsNull(rowpc["tyid"], Guid.Empty.ToString())),
                                                ypph,
                                                Guid.Empty,
                                                new Guid(Convertor.IsNull(rowpc["cfmxid"], Guid.Empty.ToString())),
                                                rowpc["皮试"].ToString(),
                                                yf.Trim(),                                                    //用法
                                                zt.Trim(),                                                    //嘱托
                                                Convertor.IsNull(rowpc["用法"], ""),                          //用法
                                                Convertor.IsNull(rowpc["频次"], ""),                          //频次
                                                Convertor.IsNull(rowpc["剂量"], ""),                          //剂量
                                                Convertor.IsNull(rowpc["剂量单位"], ""),                      //剂量单位
                                                Convert.ToDecimal(Convertor.IsNull(rowpc["天数"], "0")),      //天数
                                                Convert.ToInt32(Convertor.IsNull(rowpc["组标志"], "0")),      //组标志
                                                Convert.ToInt32(Convertor.IsNull(rowpc["排序序号"], "0")),    //排序标志
                                                _pronamefymx,                                                 //存储过程明
                                                out fymxid,                                                   //fymxid
                                                out err_code,
                                                out err_text,
                                                fyjhj, //jhj_cfmx ,           //进价
                                                jhje_cfmx,          //进货金额
                                                ypxq,               //效期       
                                                yppch,              //批次号
                                                kcid,               //kcid
                                                InstanceForm.BDatabase,
                                                bpcgl);

                                if (err_code != 0)
                                {
                                    throw new System.Exception(err_text);
                                }
                                #endregion
                                sumjhje += jhje;     //进货金额
                            }
                            #endregion


                            #region 更新发药头表中的进货金额
                            string ssql = string.Format(" update yf_fy set jhje={0} where id='{1}'", sumjhje, fyid);
                            if (InstanceForm.BDatabase.DoCommand(ssql) <= 0)
                            {
                                throw new Exception("更新进货金额失败");
                            }
                            #endregion

                        }
                        #endregion

                        #region 金额验证
                        //if ( Math.Abs( sumlsje - _sumlsje ) > Convert.ToDecimal( 0.05 ) )
                        //{
                        //    throw new Exception( string.Format( "金额发生错误,处方明细中金额合计：{0},发药明细中金额合计{1}" , sumlsje , _sumlsje ) );
                        //}
                        //if ( Math.Abs( sumpfje - _sumpfje ) > Convert.ToDecimal( 0.05 ) )
                        //{
                        //    throw new Exception( string.Format( "批发金额发生错误,处方明细中批发金额合计：{0},发药明细中批发金额合计{1}" , sumpfje , _sumpfje ) );
                        //}
                        #endregion

                        if (err_code != 0)
                        {
                            throw new Exception(string.Format("提示：{0}", err_text));
                        }
                        #endregion
                    }

                    //分组处方
                    DataTable tbsel_hj = tb.Clone();
                    for (int w = 0; w <= selrow.Length - 1; w++)
                        tbsel_hj.ImportRow(selrow[w]);
                    string[] GroupbyField_hj ={ "FPID" };
                    string[] ComputeField_hj ={ "金额" };
                    string[] CField_hj ={ "sum" };
                    DataTable tbcf_hj = FunBase.GroupbyDataTable(tbsel_hj, GroupbyField_hj, ComputeField_hj, CField_hj, null);
                    for (int i = 0; i <= tbcf_hj.Rows.Count - 1; i++)
                    {
                        string ssql = "update yf_fyjh set bfybz=1,FYRQ='" + sDate + "' where fpid='" + tbcf_hj.Rows[i]["fpid"].ToString() + "'";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }

                    //提交事务
                    InstanceForm.BDatabase.CommitTransaction();

                    ////Add by zhujh 2017-05-27 耗时监控停止
                    //logger.Stop();


                    ////Add by zhujh 2017-05-27 新增耗时监控
                    //ExecTimeLogger logger2 = ExecTimeLogger.Run("药房发药快发");

                    //此处只有北院与南院部分科室进行启用 此处做成参数化 北院快发发药
                    if (rdo1.Checked && InstanceForm.BCurrentDept.DeptId == 207)
                    {
                        //判断是否使用相同的快发接口发药
                        if (str_HH_Flag.Equals("1"))
                        {
                            #region 如果等于1 则表示北院使用南院相同的快发接口
                            if (strFyKFCkFlag == "1")
                            {
                                string retValue_HH = "";
                                retValue_HH = EndClinicInfo(tb, brxm, brxxid, str_HH_Flag);
                                if (Convert.ToInt32(retValue_HH) == 1)
                                {
                                    // MessageBox.Show("药品快发发药成功！");
                                }
                                else
                                {
                                    MessageBox.Show("药品快发发药失败！");
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region 否则北院使用原来的老快发接口，此处为了兼容保留原来的不动
                            string pyrInfo = EndClinicInfo(tb, brxm, brxxid, str_HH_Flag);

                            if (!string.IsNullOrEmpty(pyrInfo) && pyrInfo.Contains(",") && updatePyrInfo.Count > 0)
                            {
                                string[] pyrData = pyrInfo.Split(new string[] { "," }, StringSplitOptions.None);
                                if (pyrData != null && pyrData.Length > 2)
                                {
                                    string sql = string.Empty;
                                    foreach (KeyValuePair<string, string> tmp in updatePyrInfo)
                                    {
                                        if (!string.IsNullOrEmpty(pyrData[0]) && !string.IsNullOrEmpty(pyrData[1]) && !string.IsNullOrEmpty(pyrData[2]))
                                        {
                                            sql = string.Format(tmp.Key, pyrData[0], pyrData[1], pyrData[2]);
                                            InstanceForm.BDatabase.DoCommand(sql);
                                        }

                                        if (!string.IsNullOrEmpty(pyrData[0]) && !string.IsNullOrEmpty(pyrData[2]))
                                        {
                                            sql = string.Format(tmp.Value, pyrData[0], pyrData[2]);
                                            InstanceForm.BDatabase.DoCommand(sql);
                                        }
                                    }
                                }
                            }
                            #endregion 
                        }
                    }


                    //南院快发发药
                    #region 南院快发发药
                    string retValue = "";
                    if (rdo1.Checked && InstanceForm.BCurrentDept.DeptId == 424)
                    {
                        if (strFyKFCkFlag == "1")
                        {
                            retValue = EndClinicInfo(tb, brxm, brxxid, str_HH_Flag);
                            if (Convert.ToInt32(retValue) == 1)
                            {
                                // MessageBox.Show("药品快发发药成功！");
                            }
                            else
                            {
                                MessageBox.Show("药品快发发药失败！");
                            }
                        }
                    }
                    #endregion 

                    #region 原来的方法没有用到暂时屏蔽
                    /* Modify By Zhujh 2017-02-17 屏蔽
                    #region 报价器   20110307
                    //如果是南院叫号
                    if (this._call is ts_call_whzxyymz)
                    {
                        try
                        {
                            DataRow[] selrowX = tb.Select("发药='◆' and ypid<>''");
                            DataTable tbselX = tb.Clone();
                            for (int w = 0; w <= selrowX.Length - 1; w++)
                                tbselX.ImportRow(selrowX[w]);

                            string[] GroupbyFieldX ={ "姓名" };
                            string[] ComputeFieldX ={ "金额" };
                            string[] CFieldX ={ "sum" };
                            DataTable tbcfX = FunBase.GroupbyDataTable(tbselX, GroupbyFieldX, ComputeFieldX, CFieldX, null);
                            if (tbcfX.Rows.Count == 1)
                            {

                                ts_call.CFMX[] cfmx = new ts_call.CFMX[selrow.Length];
                                for (int i = 0; i <= selrow.Length - 1; i++)
                                {
                                    cfmx[i].PM = Convertor.IsNull(selrow[i]["品名"], "");
                                    cfmx[i].GG = Convertor.IsNull(selrow[i]["规格"], "");
                                    cfmx[i].DJ = Convert.ToDecimal(Convertor.IsNull(selrow[i]["单价"], "0"));
                                    cfmx[i].SL = Convert.ToDecimal(Convertor.IsNull(selrow[i]["用量"], "0"));
                                    cfmx[i].DW = Convertor.IsNull(selrow[i]["单位"], "0");
                                    cfmx[i].JE = Convert.ToDecimal(Convertor.IsNull(selrow[i]["金额"], "0"));
                                    cfmx[i].fyck = _Fyckmc;
                                    cfmx[i].deptid = InstanceForm.BCurrentDept.DeptId;
                                    cfmx[i].brxm = Convertor.IsNull(selrow[i]["姓名"], "");
                                    cfmx[i].fph = Convertor.IsNull(selrow[i]["发票号"], "");
                                }
                                string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                                if (bqybjq == "true" && (_menuTag.Function_Name == "Fun_ts_yf_mzfy" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_YFFY"))
                                {
                                    Caller call = new Caller(brxm, sumje, cfmx, this._call);
                                    thCall = new Thread(new ThreadStart(call.call));
                                    call.Thread = thCall;
                                    thCall.Start();
                                }
                            }
                        }
                        catch (System.Exception err)
                        {
                        }
                    }
                    #endregion
                    */
                    #endregion 

                    //Add by zhujh 2017-05-27 耗时监控停止
                    //logger2.Stop();

                    MessageBox.Show("发药成功！\n\n" + _Bz, "发药", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CallNumber(2); //清空药房叫号显示屏

                    SetDefaultFocuse();
                    this.butfy.Enabled = true;
                    try
                    {
                        DataRow[] rows_ref = null;
                        DataView dv = (DataView)dataGridView1.DataSource;
                        if (dv != null)
                        {
                            DataTable tbref = dv.Table;
                            if (cfg8027 == "1")
                                rows_ref = tbref.Select("发票号='" + tbcf.Rows[0]["发票号"].ToString() + "' and 姓名='" + tbcf.Rows[0]["姓名"].ToString() + "'");
                            if (cfg8027 == "2")
                                rows_ref = tbref.Select("姓名='" + tbcf.Rows[0]["姓名"].ToString() + "'");
                            if (rows_ref != null)
                            {
                                if (rows_ref.Length > 0)
                                    tbref.Rows.Remove(rows_ref[0]);
                            }
                            if (cfg8027 != "0" && tbref.Rows.Count == 0)
                                button_ref_Click(sender, e);
                        }

                        if (_textBox != null)
                        {
                            _textBox.Focus();
                            _textBox.SelectAll();
                        }
                        else
                        {
                            txtmzh.Focus();
                            txtmzh.SelectAll();
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("111:" + error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (InventoryNotEnoughException exception)
                {
                    DataTable dt = (DataTable)exception.Data;
                    string message = "";
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                        message = message + dt.Rows[i]["YP"].ToString() + "\r\n";
                    message = message + dt.Rows[dt.Rows.Count - 1]["YP"].ToString();
                    message = string.Format("以下药品\r\n{0}\r\n在当前库房没有库存，不能发药", message);
                    this.butfy.Enabled = true;
                    MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (System.Exception err)
                {
                    this.butfy.Enabled = true;
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show("222:" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                    SetDefaultFocuse();
                    //Add by Zhujh 2017-05-10 评价器
                    yongtai.PlzOpinion();
                }

                //此处增加电子健康卡事件记录
                Add_DJJKKXX_ToEventLogMZ(str_PATID,str_GHXXID);

                //打印处方
                try
                {
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        if (tb.Rows[i]["发药"].ToString().Trim() == "◆")
                            tb.Rows[i]["发药"] = "√";
                    }

                    //打印并清除网格
                    if (chkprint.Checked == true)
                        this.butprint_Click(sender, e);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("打印处方时发生错误" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string bqypjq = ApiFunction.GetIniString("评价器", "启用评价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string pjqxh = ApiFunction.GetIniString("评价器", "评价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqypjq == "true")
                {
                    ts_pjq.ipjq ipjq = ts_pjq.PjqFactory.Newpjq(pjqxh);
                    string perr_text = "";
                    int perr_code = 0;
                    ipjq.Pj(InstanceForm.BCurrentUser.LoginCode.ToString(), InstanceForm.BCurrentUser.Name, InstanceForm.BCurrentDept.DeptId.ToString(), InstanceForm.BCurrentDept.DeptName, out perr_code, out perr_text);
                    if (perr_code != 0)
                        throw new Exception("评价器调用出错!" + perr_text);
                }


            }

        }

        /// <summary>
        /// 显示药品明细的对象
        /// </summary>
        private class Caller
        {
            string _name;
            decimal _je;
            ts_call.CFMX[] _cfmx;
            Thread _thread;
            ts_call.Icall _call;


            public Thread Thread
            {
                get
                {
                    return _thread;
                }
                set
                {
                    _thread = value;
                }
            }
            public Caller(string name, decimal je, ts_call.CFMX[] cfmx, ts_call.Icall call)
            {
                _name = name;
                _je = je;
                _cfmx = cfmx;
                _call = call;
            }
            public void call()
            {
                try
                {
                    if (_call != null && _call.CurrentThread != null)
                    {
                        _call.CurrentThread.Abort();
                    }
                    _call.CurrentThread = _thread;
                    _call.Call(ts_call.DmType.发药, _name, Convert.ToDouble(_je), _cfmx);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            public void call_hj()
            {
                if (_call != null && _call.CurrentThread != null)
                {
                    _call.CurrentThread.Abort();
                }
                _call.CurrentThread = _thread;
                _call.Call(ts_call.DmType.发药呼叫, _name, Convert.ToDouble(_je), _cfmx);
            }
        }

        private class VoiceCaller
        {
            string _name;
            Thread _thread;
            ts_VoiceCall.Icall __voiceCall;


            public Thread Thread
            {
                get
                {
                    return _thread;
                }
                set
                {
                    _thread = value;
                }
            }
            public VoiceCaller(string name, ts_VoiceCall.Icall call)
            {
                _name = name;
                __voiceCall = call;
            }
            public void VoiceCall()
            {
                if (__voiceCall != null && __voiceCall.CurrentThread != null)
                {
                    __voiceCall.CurrentThread.Abort();
                }
                __voiceCall.CurrentThread = _thread;
                __voiceCall.Call(_name);
            }
        }

        private void butquit_Click(object sender, System.EventArgs e)
        {
            _ClickQuit = true;
            this.Close();
        }

        private void butprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                //八医院改处方日期
                //FrmselRq frmselrq = new FrmselRq();
                //frmselrq.ShowDialog();
                //if (frmselrq.bok == true)
                //{
                //    PrintRq = frmselrq.rq;
                //}
                //else
                //    return;

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                butprint.Enabled = false;

                YpConfig ypconfig = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

                //Add by zhujh 2017-06-26  新增需求：发药的时候先提示：请盖“工伤药品标识”专用章
                foreach (DataRow item in tb.Rows)
                {
                    if (Convertor.IsNull(item["中药备注"], "").Contains("工伤"))
                    {
                        MessageBox.Show("请盖“工伤药品标识”专用章", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }


                //分组处方
                DataRow[] selrow;
                if (ypconfig.门诊发药后才能打印处方 == true)
                    selrow = tb.Select("( 发药='√') and ypid<>''");
                else
                    selrow = tb.Select("(发药='◆' or  发药='√') and ypid<>''");
                DataTable tbsel = tb.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);

                DataTable tbcf;
                if (rdo1.Checked == true) //如果为未发药就取总金额，已发药则取求和值
                {
                    string[] GroupbyField ={ "cfxh", "发票号", "总金额", "诊断", "门诊号" };
                    string[] ComputeField ={ };
                    string[] CField ={ };
                    tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                }
                else
                {
                    string[] GroupbyField ={ "cfxh", "发票号", "诊断", "门诊号" };
                    string[] ComputeField ={ "金额" };
                    string[] CField ={ "sum" };
                    tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                }

                if (chkxp.Checked == true)
                {
                    this.PrintCfXP();
                    return;
                }

                SystemCfg cfg8035 = new SystemCfg(8035);

                //门诊发药与配药时,处方和清单的打印顺序。 1先打印处方后打印清单,2先打印清单后打印处方
                if (cfg8035.Config == "1")
                {
                    //处方
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkcf.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 1);
                    }
                    //注射单


                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkzsd.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 2);
                    }

                    //清单
                    //分组处方
                    if (chkqd.Checked == true)
                    {
                        DataTable tbselqd = tb.Clone();
                        for (int w = 0; w <= selrow.Length - 1; w++)
                            tbselqd.ImportRow(selrow[w]);

                        DataTable tbcfqd;
                        string[] GroupbyFieldqd ={ "fpid" };
                        string[] ComputeFieldqd ={ };
                        string[] CFieldqd ={ };
                        tbcfqd = FunBase.GroupbyDataTable(tbselqd, GroupbyFieldqd, ComputeFieldqd, CFieldqd, null);
                        for (int i = 0; i <= tbcfqd.Rows.Count - 1; i++)
                        {
                            this.PrintCf(tbcfqd.Rows[i]["fpid"].ToString());
                        }
                    }
                }
                else
                {
                    //清单
                    //分组处方
                    if (chkqd.Checked == true)
                    {
                        DataTable tbselqd = tb.Clone();
                        for (int w = 0; w <= selrow.Length - 1; w++)
                            tbselqd.ImportRow(selrow[w]);

                        DataTable tbcfqd;
                        string[] GroupbyFieldqd ={ "fpid" };
                        string[] ComputeFieldqd ={ };
                        string[] CFieldqd ={ };
                        tbcfqd = FunBase.GroupbyDataTable(tbselqd, GroupbyFieldqd, ComputeFieldqd, CFieldqd, null);
                        for (int i = 0; i <= tbcfqd.Rows.Count - 1; i++)
                        {
                            this.PrintCf(tbcfqd.Rows[i]["fpid"].ToString());
                        }
                    }

                    //处方
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkcf.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 1);
                    }

                    //注射单

                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkzsd.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 2);
                    }

                }

                //麻醉精神处方打印
                if (chkmj.Checked == true)
                {
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        this.PrintMJ(tbcf.Rows[i]);
                    }
                }
                //毒剧药品处方打印
                if (chkDJ.Checked == true)
                {
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        this.PrintDJ(tbcf.Rows[i]);
                    }
                }

                //精二处方打印
                if (chkJ2.Checked == true)
                {
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        this.PrintJ2(tbcf.Rows[i]);
                    }
                }

                if (chkcf.Checked == true)
                {
                    //分组处方
                    DataRow[] selrow_dy = tb.Select("发药='◆' and ypid<>''");
                    DataTable tbsel_dy = tb.Clone();
                    for (int w = 0; w <= selrow_dy.Length - 1; w++)
                        tbsel_dy.ImportRow(selrow_dy[w]);
                    string[] GroupbyField_dy ={ "FPID", "姓名", "发票号", "门诊号" };
                    string[] ComputeField_dy ={ "金额" };
                    string[] CField_dy ={ "sum" };
                    DataTable tbcf_dy = FunBase.GroupbyDataTable(tbsel_dy, GroupbyField_dy, ComputeField_dy, CField_dy, null);

                    for (int i = 0; i <= tbcf_dy.Rows.Count - 1; i++)
                    {
                        ParameterEx[] parameters = new ParameterEx[11];
                        parameters[0].Text = "@FPID";
                        parameters[0].DataType = System.Data.DbType.Guid;
                        parameters[0].Value = tbcf_dy.Rows[i]["fpid"].ToString();

                        parameters[1].Text = "@FPH";
                        parameters[1].Value = tbcf_dy.Rows[i]["发票号"].ToString();

                        parameters[2].Text = "@ZJE";
                        parameters[2].DataType = System.Data.DbType.Decimal;
                        parameters[2].Value = tbcf_dy.Rows[i]["金额"].ToString();

                        parameters[3].Text = "@BRXM";
                        parameters[3].Value = tbcf_dy.Rows[i]["姓名"].ToString();

                        parameters[4].Text = "@BLH";
                        parameters[4].Value = tbcf_dy.Rows[i]["门诊号"].ToString();

                        parameters[5].Text = "@LYCK";
                        parameters[5].Value = _Fyckh;

                        parameters[6].Text = "@LYCKMC";
                        parameters[6].Value = _Fyckmc;

                        parameters[7].Text = "@DEPTID";
                        parameters[7].DataType = System.Data.DbType.Int32;
                        parameters[7].Value = InstanceForm.BCurrentDept.DeptId;

                        parameters[8].Text = "@DEPTNAME";
                        parameters[8].Value = InstanceForm.BCurrentDept.DeptName;

                        parameters[9].Text = "@DJY";
                        parameters[9].Value = InstanceForm.BCurrentUser.EmployeeId;

                        parameters[10].Text = "@jhlx";
                        parameters[10].Value = "print";

                        int iii = InstanceForm.BDatabase.DoCommand("SP_YF_FYJH", parameters, 60);


                        DataView dv = (DataView)dataGridView1.DataSource;
                        DataTable tbfp = dv.Table;
                        DataRow[] rows = tbfp.Select("fpid='" + tbcf_dy.Rows[i]["fpid"].ToString() + "'");
                        if (rows.Length == 1)
                            rows[0]["打印"] = "1";
                    }

                }

                butprint.Enabled = true;
            }
            catch (System.Exception err)
            {
                butprint.Enabled = true;
                MessageBox.Show(err.Message);
            }
        }

        private void PrintCf(DataRow row)
        {
            //DataTable tb=(DataTable)this.myDataGrid1.DataSource;

            //DataRow[] rows;
            //rows=tb.Select("( 发药='√' or 发药='◆') and 发票号='"+row["发票号"]+"' ");
            //if (rows.Length==0) return;
            //string cftsname="";
            //cftsname=Convert.ToString(rows[0]["项目"]).Trim()=="中草药"?"中药付数":"";
            //ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();

            //DataRow myrow = null;
            //int yzzh = 0;
            //int xxx = 0;

            //for(int i=0;i<=rows.Length-1;i++)
            //{
            //        //myrow=Dset.病人处方清单.NewRow();
            //        //myrow["xh"]=Convert.ToInt32(rows[i]["序号"]);
            //        //myrow["ypmc"]=Convert.ToString(rows[i]["品名"]);
            //        //myrow["ypgg"]=Convert.ToString(rows[i]["规格"]);
            //        //myrow["sccj"]=Convert.ToString(rows[i]["厂家"]);
            //        //myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"],"0"));
            //        //myrow["ypsl"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["用量"],"0"));
            //        //myrow["ypdw"]=Convert.ToString(rows[i]["单位"]);
            //        //myrow["cfts"]=Convert.ToString(rows[i]["项目"]).Trim()=="中草药"?rows[i]["剂数"]+"剂":"";
            //        //myrow["lsje"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"],"0"));
            //        //string UserEat="";
            //        //UserEat=rows[i]["频次"].ToString().Trim()==""?"":Convert.ToDouble(rows[i]["剂量"]).ToString()+rows[i]["剂量单位"].ToString().Trim()+"/每次";
            //        //myrow["yf"]=Convert.ToString(rows[i]["用法"])+"  "+rows[i]["使用频次"].ToString().Trim()+" "+UserEat;
            //        //myrow["pc"]= rows[i]["使用频次"].ToString().Trim();
            //        //myrow["syjl"]="";
            //        //myrow["zt"]=Convert.ToString(rows[i]["嘱托"]);
            //        //myrow["shh"]=Convert.ToString(rows[i]["货号"]);
            //        //myrow["ksname"]=Convert.ToString(rows[i]["科室"]);//+"  费别:"+this.patientInfo1.FeeTypeName;
            //        //string ysqm="";
            //        ////if (Convert.ToString(row["医生签名"]).Trim()!="")  ysqm="   医生签名:"+Convert.ToString(rows[i]["医生签名"]);
            //        //myrow["ysname"]=Convert.ToString(rows[i]["医生"])+ysqm;
            //        //myrow["Pyck"]=rows[i]["皮试"].ToString();
            //        //myrow["fph"]=Convert.ToString(rows[i]["发票号"]);
            //        //myrow["hzxm"]=Convert.ToString(rows[i]["姓名"]);
            //        //myrow["sex"]=Convert.ToString(rows[i]["性别"]);
            //        //myrow["age"]=Convert.ToString(rows[i]["年龄"]);
            //        //myrow["blh"]=Convert.ToString(rows[i]["门诊号"]);
            //        //myrow["sfrq"]=Convert.ToString(rows[i]["收费日期"]);
            //        //myrow["pyr"]=this.cmbpyr.Text.Trim();;
            //        //myrow["fyr"]=InstanceForm.BCurrentUser.Name;
            //        //Dset.病人处方清单.Rows.Add(myrow);


            //        if (Convert.ToString(rows[0]["cflx"]) == "03" && rdocfgs.Checked == true)
            //        {
            //            #region 中药处方格式
            //            if (xxx == 2)
            //            {
            //                Dset.病人处方清单.Rows.Add(myrow);
            //                myrow = Dset.病人处方清单.NewRow();
            //                xxx = 0;
            //            }
            //            if (i == 0)
            //                myrow = Dset.病人处方清单.NewRow();

            //            xxx = xxx + 1;
            //            string s = "                                                         ";
            //            string zt = Convertor.IsNull(rows[i]["嘱托"], "").Trim() == "" ? "" : "(" + Convertor.IsNull(rows[i]["嘱托"], "").Trim() + ")";
            //            string _ypmc = rows[i]["品名"].ToString().Trim() + zt.Trim() + s;
            //            _ypmc = _ypmc.Replace("@", "");
            //            _ypmc = _ypmc.Replace("%", "");
            //            _ypmc = _ypmc.Replace("*", "");
            //            _ypmc = new String(System.Text.Encoding.Default.GetChars(System.Text.Encoding.Default.GetBytes(_ypmc), 0, 15));
            //            string _yl = rows[i]["用量"].ToString() + rows[i]["单位"].ToString().Trim();
            //            _yl = _yl + s;
            //            _yl = new String(System.Text.Encoding.Default.GetChars(System.Text.Encoding.Default.GetBytes(_yl), 0, 6));
            //            myrow["ypmc"] = myrow["ypmc"] + _ypmc + " " + _yl + "     ";

            //            myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
            //            myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
            //            myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
            //            myrow["ypsl"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["用量"], "0"));
            //            myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
            //            myrow["cfts"] = Convert.ToString(rows[i]["项目"]).Trim() == "中草药" ? rows[i]["剂数"] + "剂" : "";
            //            myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
            //            string UserEat = "";
            //            UserEat = rows[i]["频次"].ToString().Trim() == "" ? "" : Convert.ToDouble(rows[i]["剂量"]).ToString() + rows[i]["剂量单位"].ToString().Trim() + "/每次";
            //            myrow["yf"] = Convert.ToString(rows[i]["用法"]) + "  " + rows[i]["使用频次"].ToString().Trim() + " " + UserEat;
            //            myrow["pc"] = rows[i]["使用频次"].ToString().Trim();
            //            myrow["syjl"] = "";
            //            myrow["zt"] = " " + Convert.ToString(rows[i]["嘱托"]);
            //            myrow["shh"] = Convert.ToString(rows[i]["货号"]);
            //            myrow["ksname"] = Convert.ToString(rows[i]["科室"]);//+"  费别:"+this.patientInfo1.FeeTypeName;
            //            string ysqm = "";
            //            //if (Convert.ToString(row["医生签名"]).Trim()!="")  ysqm="   医生签名:"+Convert.ToString(rows[i]["医生签名"]);
            //            myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim() + Convertor.IsNull(ysqm, "");
            //            myrow["Pyck"] = rows[i]["皮试"].ToString();
            //            myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
            //            myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
            //            myrow["sex"] = Convert.ToString(rows[i]["性别"]);
            //            myrow["age"] = Convert.ToString(rows[i]["年龄"]);
            //            myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
            //            myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
            //            if (Convert.ToString(rows[i]["配药员"]).Trim() == "")
            //                myrow["pyr"] = this.cmbpyr.Text.Trim(); 
            //            else
            //                myrow["pyr"] = Convert.ToString(rows[i]["配药员"]).Trim();
            //            myrow["fyr"] = "";
            //            myrow["pyckdm"] = Convert.ToString(rows[i]["配药窗口"]); ;
            //            myrow["fyckdm"] = Convert.ToString(rows[i]["发药窗口"]);
            //            myrow["zdmc"] = Convert.ToString(rows[i]["诊断"]);
            //            //myrow["syff"] = Convert.ToString(rows[i]["用法"]);
            //            //myrow["sypc"] = Convert.ToString(rows[i]["频次"]);
            //            //myrow["jl"] = Convert.ToString(rows[i]["剂量"]);
            //            //myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
            //            //myrow["ts"] = Convert.ToDecimal(rows[i]["天数"]);
            //            if (rows[i]["组标志"].ToString() == "1")
            //                yzzh = yzzh + 1;
            //            myrow["yzzh"] = yzzh;
            //            myrow["pxxh"] = Convert.ToInt32(rows[i]["排序序号"]);

            //            if (i == rows.Length - 1)
            //                Dset.病人处方清单.Rows.Add(myrow);


            //            #endregion 中药处方格式

            //        }
            //        else
            //        {
            //            #region  非中药处方格式
            //            myrow = Dset.病人处方清单.NewRow();
            //            myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
            //            myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
            //            myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
            //            myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
            //            myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
            //            myrow["ypsl"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["用量"], "0"));
            //            myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
            //            myrow["cfts"] = Convert.ToString(rows[i]["项目"]).Trim() == "中草药" ? rows[i]["剂数"] + "剂" : "";
            //            myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
            //            string UserEat = "";
            //            UserEat = rows[i]["频次"].ToString().Trim() == "" ? "" : Convert.ToDouble(rows[i]["剂量"]).ToString() + rows[i]["剂量单位"].ToString().Trim() + "/每次";
            //            myrow["yf"] = Convert.ToString(rows[i]["用法"]) + "  " + rows[i]["使用频次"].ToString().Trim() + " " + UserEat;
            //            myrow["pc"] = rows[i]["使用频次"].ToString().Trim();
            //            myrow["syjl"] = "";
            //            myrow["zt"] = " " + Convert.ToString(rows[i]["嘱托"]);
            //            myrow["shh"] = Convert.ToString(rows[i]["货号"]);
            //            myrow["ksname"] = Convert.ToString(rows[i]["科室"]);//+"  费别:"+this.patientInfo1.FeeTypeName;
            //            string ysqm = "";
            //            //if (Convert.ToString(row["医生签名"]).Trim()!="")  ysqm="   医生签名:"+Convert.ToString(rows[i]["医生签名"]);
            //            myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim() + Convertor.IsNull(ysqm, "");
            //            myrow["Pyck"] = rows[i]["皮试"].ToString();
            //            myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
            //            myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
            //            myrow["sex"] = Convert.ToString(rows[i]["性别"]);
            //            myrow["age"] = Convert.ToString(rows[i]["年龄"]);
            //            myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
            //            myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
            //            if (Convert.ToString(rows[i]["配药员"]).Trim() == "")
            //                myrow["pyr"] = this.cmbpyr.Text.Trim();
            //            else
            //                myrow["pyr"] = Convert.ToString(rows[i]["配药员"]).Trim();
            //            myrow["fyr"] = "";
            //            myrow["pyckdm"] = Convert.ToString(rows[i]["配药窗口"]);
            //            myrow["fyckdm"] = Convert.ToString(rows[i]["发药窗口"]);
            //            myrow["zdmc"] = Convert.ToString(rows[i]["诊断"]);
            //            //myrow["syff"] = Convert.ToString(rows[i]["用法"]);
            //            //myrow["sypc"] = Convert.ToString(rows[i]["频次"]);
            //            //myrow["jl"] = Convert.ToString(rows[i]["剂量"]);
            //            //myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
            //            //myrow["ts"] = Convert.ToDecimal(rows[i]["天数"]);
            //            if (rows[i]["组标志"].ToString() == "1")
            //                yzzh = yzzh + 1;
            //            myrow["yzzh"] = yzzh;
            //            myrow["pxxh"] = Convert.ToInt32(rows[i]["排序序号"]);

            //            if (rdocfgs.Checked == true && Convert.ToString(rows[0]["cflx"]) != "03")
            //            {
            //                if (rows[i]["组标志"].ToString() == "1")
            //                    myrow["ypmc"] = "┌" + myrow["ypmc"];
            //                if (rows[i]["组标志"].ToString() == "-1")
            //                    myrow["ypmc"] = "└" + myrow["ypmc"];
            //                if (rows[i]["组标志"].ToString() != "1" && rows[i]["组标志"].ToString() != "-1")
            //                    myrow["ypmc"] = "│" + myrow["ypmc"];

            //                myrow["ypmc"] = myrow["ypmc"] + " " + rows[i]["单位规格"].ToString().Trim();//;+ "*" + rows[i]["用量"].ToString() + rows[i]["单位"].ToString();
            //                myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();

            //            }
            //            Dset.病人处方清单.Rows.Add(myrow);

            //            if (rdocfgs.Checked == true && Convert.ToString(rows[0]["cflx"]) != "03")
            //            {
            //                DataRow myrow1;
            //                string ps = "";
            //                string ss = " ";
            //                if (Convert.ToString(rows[i]["皮试"]).Trim() != "")
            //                    ps = " (" + Convert.ToString(rows[i]["皮试"]).Trim() + ")";
            //                if (i < rows.Length - 1)
            //                {
            //                    if (rows[i]["组标志"].ToString() != "-1" && yzzh>0) ss = "│";
            //                }
            //                myrow1 = Dset.病人处方清单.NewRow();
            //                myrow1["ypmc"] = ss + "      用法:" + rows[i]["剂量"].ToString() + rows[i]["剂量单位"].ToString().Trim()
            //                    + Convert.ToString(rows[i]["嘱托"]) + " " + Convert.ToString(rows[i]["用法"]) +
            //                    " " + rows[i]["使用频次"].ToString().Trim() + ps;
            //                if (Convert.ToString(rows[i]["用法"]).Trim() == "")
            //                    myrow1["ypmc"] = "       用法:";

            //                myrow1["yzzh"] = yzzh;
            //                myrow1["ysname"] = Convert.ToString(rows[i]["医生"]).Trim() + Convertor.IsNull(ysqm, "");
            //                myrow1["pyr"] = myrow["pyr"];
            //                Dset.病人处方清单.Rows.Add(myrow1);
            //            }
            //            #endregion
            //        }
            //}

            ////ParameterEx[] parameters=new ParameterEx[4];
            ////parameters[0].Text="cfts";
            ////parameters[0].Value=cftsname;
            ////parameters[1].Text="zje";
            ////if (rdo1.Checked==true) //如果为未发药就取总金额，已发药则取求和值
            ////    parameters[1].Value=Convert.ToDecimal(Convertor.IsNull(row["总金额"],"0"));
            ////else
            ////    parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(row["金额"], "0"));
            ////parameters[2].Text="TITLETEXT";
            ////parameters[2].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+"处方明细单";
            ////parameters[3].Text="text1";
            ////parameters[3].Value="发药单位:"+InstanceForm.BCurrentDept.DeptName+"    诊断:"+row["诊断"].ToString();
            ////bool bview=this.chkprintview.Checked==true?false:true;
            ////TrasenFrame.Forms.FrmReportView f;

            ////if (Convert.ToString(rows[0]["项目"]).Trim()!="中草药")
            ////    f=new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单,Constant.ApplicationDirectory+"\\Report\\YF_病人处方清单.rpt",parameters,bview);
            ////else
            ////    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单_中药处方.rpt", parameters, bview);

            ////if (f.LoadReportSuccess) f.Show();else  f.Dispose();

            //if (Convert.ToString(rows[0]["cflx"]) == "03" && rdocfgs.Checked == true)
            //{
            //    myrow = Dset.病人处方清单.NewRow();
            //    myrow["ypmc"] = "      用法:" + Convert.ToString(rows[0]["用法"]) + " " + Convert.ToString(rows[0]["嘱托"]) + " " + rows[0]["使用频次"].ToString().Trim() + "       处方剂数: " + rows[0]["剂数"] + "剂";
            //    myrow["yzzh"] = yzzh;
            //    myrow["ysname"] = Convert.ToString(rows[0]["医生"]).Trim();
            //    Dset.病人处方清单.Rows.Add(myrow);
            //}

            //ParameterEx[] parameters = new ParameterEx[7];
            //parameters[0].Text = "cfts";
            //parameters[0].Value = cftsname;
            //parameters[1].Text = "zje";
            //parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(rows[0]["总金额"], "0"));
            //parameters[2].Text = "TITLETEXT";
            //if (rdocfgs.Checked == true)
            //    parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "门诊处方笺";
            //else
            //    parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + "处方明细单";
            //parameters[3].Text = "text1";
            //parameters[3].Value = "发药单位:" + InstanceForm.BCurrentDept.DeptName + "    诊断:" + rows[0]["诊断"].ToString();

            //parameters[4].Text = "xyf";
            //if (Convert.ToString(rows[0]["cflx"]) != "03")
            //    parameters[4].Value = Convert.ToDecimal(rows[0]["总金额"]);
            //else
            //    parameters[4].Value = 0;
            //parameters[5].Text = "zyf";
            //if (Convert.ToString(rows[0]["cflx"]) == "03")
            //    parameters[5].Value = Convert.ToDecimal(rows[0]["总金额"]);
            //else
            //    parameters[5].Value = 0;
            //parameters[6].Text = "yfmc";
            //parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            //bool bview = true;
            //if (chkprintview.Checked == true) bview = false;
            //TrasenFrame.Forms.FrmReportView f;
            //if (rdocfgs.Checked == true)
            //    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单(处方格式).rpt", parameters, bview);
            //else
            //{
            //    if (Convert.ToString(rows[0]["cflx"]) == "03")
            //        f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单_中药处方.rpt", parameters, bview);
            //    else
            //        f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单.rpt", parameters, bview);
            //}
            //if (f.LoadReportSuccess) f.Show(); else f.Dispose();


        }

        private void PrintCf(string fpid)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows;

            string where = "(发药='◆' or  发药='√') and ypid<>''";
            if (fpid != "")
                where = where + " and fpid='" + fpid + "'";
            rows = tb2.Select(where);
            if (rows.Length == 0)
                return;

            string jtdz = "";
            string grlxdh = "";
            string sfzh = "";
            string ssql = "select * from yy_brxx a inner join mz_cfb b on a.brxxid=b.brxxid where b.cfid='" + rows[0]["cfxh"].ToString() + "'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                jtdz = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
                grlxdh = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
                sfzh = Convertor.IsNull(tb.Rows[0]["sfzh"], "");
            }

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;
            decimal sumje = 0;
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                #region  非中药处方格式
                myrow = Dset.病人处方清单.NewRow();
                myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                myrow["cfts"] = rows[i]["剂数"].ToString();
                myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                sumje = sumje + Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "");

                //Modify by jchl
                //myrow["pc"] = Convertor.IsNull(rows[i]["使用频次"], "");
                myrow["pc"] = Convertor.IsNull(rows[i]["频次"], "");

                myrow["syjl"] = "";
                myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                myrow["ksname"] = Convert.ToString(rows[i]["科室"]).Trim();
                myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim();
                myrow["PSZT"] = rows[i]["皮试"].ToString();
                myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                myrow["pyr"] = this.cmbpyr.Text.Trim();

                myrow["fyr"] = Convert.ToString(rows[i]["发药员"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["发药员"]);
                myrow["pyckdm"] = Convertor.IsNull(rows[i]["配药窗口"], "") == "" ? "" : Convertor.IsNull(rows[i]["配药窗口"], "");
                myrow["fyckdm"] = Convertor.IsNull(rows[i]["发药窗口"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["发药窗口"], "");
                myrow["zdmc"] = Convertor.IsNull(rows[i]["诊断"], "");
                myrow["syff"] = Convert.ToString(rows[i]["用法"]);
                myrow["sypc"] = Convert.ToString(rows[i]["使用频次"]);
                myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");
                if (rows[i]["组标志"].ToString() == "1")
                {
                    yzzh = yzzh + 1;
                }
                myrow["yzzh"] = yzzh;
                myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                myrow["fzbz"] = rows[i]["组标志"].ToString();

                myrow["JTDZ"] = jtdz;
                myrow["LXDH"] = grlxdh;
                myrow["SFZH"] = sfzh;
                myrow["bz1"] = Convertor.IsNull(rows[i]["中药备注"], "");
                myrow["bz2"] = Convertor.IsNull(rows[i]["备注2"], "");
                myrow["bz3"] = Convertor.IsNull(rows[i]["备注3"], "");
                myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                myrow["dyr"] = InstanceForm.BCurrentUser.Name;

                myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                Dset.病人处方清单.Rows.Add(myrow);
                #endregion
            }

            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Text = "cfts";
            parameters[0].Value = rows[0]["剂数"].ToString();
            parameters[1].Text = "zje";
            parameters[1].Value = sumje;
            parameters[2].Text = "TITLETEXT";
            parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "";
            parameters[3].Text = "text1";
            parameters[3].Value = "发药单位:" + InstanceForm.BCurrentDept.DeptName + "    诊断:" + rows[0]["诊断"].ToString();

            parameters[4].Text = "xyf";
            if (Convert.ToString(rows[0]["cflx"]).Trim() != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]).Trim() == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            bool bview = true;
            if (chkprintview.Checked == true)
                bview = false;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单.rpt", parameters, bview);
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();
        }

        private void PrintCf(DataRow row, int cfgs)
        {

            //Modify by Zhujh 2017-02-17 
            // string[] arry = new string[] { "普通胰岛素(诺和灵R笔芯）", "普通胰岛素(诺和灵R）", "低精蛋白锌(诺和灵N芯）胰岛素", "低精蛋白锌(诺和灵N）胰岛素","预混胰岛素(诺和灵30R笔芯）","预混胰岛素(诺和灵50R笔芯）","门冬胰岛素50针","门冬胰岛素30针(诺和锐30笔芯)","门冬胰岛素针(诺和锐笔芯)",
            //"普通胰岛素(甘舒霖R笔芯）" ,"低精蛋白锌(甘舒霖N芯)胰岛素","预混胰岛素(甘舒霖30R笔芯）","甘精胰岛素针(预填充)","优泌乐25","优泌乐50","优泌乐","预混胰岛素（混合优泌林针70/30）","普通胰岛素针（常规优泌林笔芯）",
            // "胰岛素针（因苏林）","白蛋白针","静注人免疫球蛋白（PH4)","唑来膦酸针（密固达）","利拉鲁肽注射液（预填充）"};//胡亚斌 11.28  不能打印的药品


            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows;
            if (cfgs == 1)
            { rows = tb2.Select(" cfxh='" + row["cfxh"] + "' "); }
            else
            {
                //查询维护的药品品种视图，在指定视图里面的则不打印
                DataTable dtYpCjid = GetYpCjidList();

                rows = tb2.Select(" cfxh='" + row["cfxh"] + "' and zsyp=1 ");
                if (rows.Length == 0)
                    return;

                for (int m = 0; m <= rows.Length - 1; m++)//Modify by Zhujh  2017-02-17 查看是否属于指定的药品
                {
                    for (int j = 0; j < dtYpCjid.Rows.Count; j++)
                    {
                        if (rows[m]["厂家"].ToString().Trim() == dtYpCjid.Rows[j]["cjid"].ToString().Trim())
                        {
                            return;
                        }
                    }
                }

                /* Modify by Zhujh 2017-02-17 注释
                for (int m = 0; m <= rows.Length - 1; m++)//胡亚斌  11.28 查看是否属于指定的药品
                {
                    string pinming = Convert.ToString(rows[m]["品名"]);
                    for (int j = 0; j < arry.Length; j++)
                    {
                        if (pinming.IndexOf(arry[j].ToString().Trim()) >= 0)
                        {
                            return;
                        }
                    }
                }
                */
            }

            if (rows.Length == 0)
                return;

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;

            string jtdz = "";
            string grlxdh = "";
            string sfzh = "";
            string ssql = "select * from yy_brxx a inner join mz_cfb b on a.brxxid=b.brxxid where b.cfid='" + row["cfxh"].ToString() + "'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                jtdz = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
                grlxdh = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
                sfzh = Convertor.IsNull(tb.Rows[0]["sfzh"], "");
            }
            if (cfgs == 2)
            {
                //Modify By Zhujh 2017-02-17
                //判断用法是否在维护用法视图里面
                DataTable dtYpyf = GetYpYFList();
                DataTable dt = null;
                bool PTCF = true;
                rows = tb2.Select(" cfxh='" + row["cfxh"] + "' ");
                string strsql = @"SELECT d.JSYP,d.MZYP,d.DJYP FROM dbo.MZ_CFB AS a JOIN dbo.MZ_CFB_MX AS b ON a.CFID = b.CFID
                                JOIN YP_YPCJD AS c ON b.BM = c.CJID
                                JOIN dbo.YP_YPGGD AS d ON c.GGID = d.GGID
                                JOIN dbo.YY_BRXX as f ON a.BRXXID = f.BRXXID
                                WHERE a.CFID='" + row["cfxh"] + "'";
                dt = InstanceForm.BDatabase.GetDataTable(strsql, 30);

                //2.判断药品是否是麻醉药品与精神药品，精神药物分类属于一类的药品，则不进行打印
                if (dt == null || dt.Rows.Count <= 0) return;
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    if (dt.Rows[i]["JSYP"].ToString() == "True" || dt.Rows[i]["DJYP"].ToString() == "True" || dt.Rows[i]["MZYP"].ToString() == "True")
                    {
                        PTCF = false;
                    }
                }
                if (PTCF)
                {
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        string yf = Convert.ToString(rows[i]["用法"]);//胡亚斌  11.28 查看是否属于注射药品
                        for (int j = 0; j < dtYpyf.Rows.Count; j++)
                        {
                            //if (yf == "iv drip" || yf == "iv" || yf == "im" || yf == "ih" || yf == "H") //Modify by Zhujh 2017-02-17注释
                            if (yf == dtYpyf.Rows[j]["yf"].ToString())
                            {
                                #region  非中药处方格式
                                myrow = Dset.病人处方清单.NewRow();
                                myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                                myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                                myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                                myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                                myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));

                                //Modify by zhujh 2017-03-03
                                if (Convertor.IsNull(rows[i]["用量"], "0") == "0")
                                {
                                    string strSqlsl = "select a.SL from MZ_CFB_MX a inner join MZ_CFB b on a.CFID=b.CFID where b.FPH='" + Convert.ToString(rows[i]["发票号"]) + "' AND a.BM=" + Convert.ToString(rows[i]["ypid"]);
                                    DataTable dtsl = InstanceForm.BDatabase.GetDataTable(strSqlsl);
                                    if (dtsl == null || dtsl.Rows.Count <= 0)
                                    {
                                        myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();

                                    }
                                    else
                                    {
                                        myrow["ypsl"] = Convert.ToDouble(dtsl.Rows[0]["sl"]).ToString();
                                    }
                                }
                                else
                                {
                                    myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                                }
                                myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                                myrow["cfts"] = rows[i]["剂数"].ToString();
                                myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                                myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "");

                                //Modify by jchl
                                //myrow["pc"] = Convertor.IsNull(rows[i]["使用频次"], "");
                                myrow["pc"] = Convertor.IsNull(rows[i]["频次"], "");

                                myrow["syjl"] = "";
                                myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                                myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                                myrow["ksname"] = Convert.ToString(rows[i]["科室"]).Trim();
                                myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim();
                                myrow["PSZT"] = rows[i]["皮试"].ToString();
                                myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                                myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                                myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                                myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                                myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                                myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                                myrow["pyr"] = GetImageByte((Convertor.IsNull(cmbpyr.SelectedValue, "0")));
                                myrow["imgfyr"] = GetImageByte((Convertor.IsNull(rows[i]["qrczyh"], "0")));
                                myrow["imgpyr"] = GetImageByte((Convertor.IsNull(rows[i]["pyczyh"], "0"))); //this.cmbpyr.Text.Trim(); modify by jchl
                                ;
                                myrow["fyr"] = Convert.ToString(rows[i]["发药员"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["发药员"]);
                                myrow["pyckdm"] = Convertor.IsNull(rows[i]["配药窗口"], "") == "" ? "" : Convertor.IsNull(rows[i]["配药窗口"], "");
                                myrow["fyckdm"] = Convertor.IsNull(rows[i]["发药窗口"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["发药窗口"], "");
                                myrow["zdmc"] = Convertor.IsNull(rows[i]["诊断"], "");

                                myrow["syff"] = Convert.ToString(rows[i]["用法"]);
                                myrow["sypc"] = Convert.ToString(rows[i]["使用频次"]);
                                myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                                myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                                myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                                myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");

                                if (rows[i]["组标志"].ToString() == "1")
                                {
                                    yzzh = yzzh + 1;
                                }
                                myrow["yzzh"] = yzzh;
                                myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                                myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                                myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                                myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                                //myrow["sfrq"] = PrintRq.ToLongDateString();
                                //myrow["cfrq"] = PrintRq.ToLongDateString();
                                //myrow["blh"] =PrintRq.Year.ToString()+"0"+PrintRq.Month.ToString()+PrintRq.Day.ToString()+ Convert.ToString(rows[i]["门诊号"]).Substring(8,Convert.ToString(rows[i]["门诊号"]).Length-8);
                                myrow["fzbz"] = rows[i]["组标志"].ToString();

                                myrow["JTDZ"] = jtdz;
                                myrow["LXDH"] = grlxdh;
                                myrow["SFZH"] = sfzh;
                                myrow["bz1"] = Convertor.IsNull(rows[i]["中药备注"], "");
                                myrow["bz2"] = Convertor.IsNull(rows[i]["备注2"], "");
                                myrow["bz3"] = Convertor.IsNull(rows[i]["备注3"], "");
                                myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                                myrow["dyr"] = InstanceForm.BCurrentUser.Name;
                                myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                                myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                                Dset.病人处方清单.Rows.Add(myrow);
                                #endregion
                            }
                        }
                    }

                }
            }
            else
            {

                for (int i = 0; i <= rows.Length - 1; i++)
                {

                    #region  非中药处方格式
                    myrow = Dset.病人处方清单.NewRow();
                    myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                    myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                    myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                    myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                    myrow["cfts"] = rows[i]["剂数"].ToString();
                    myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                    myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "");

                    //Modify by jchl
                    //myrow["pc"] = Convertor.IsNull(rows[i]["使用频次"], "");
                    myrow["pc"] = Convertor.IsNull(rows[i]["频次"], "");

                    myrow["syjl"] = "";
                    myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                    myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                    myrow["ksname"] = Convert.ToString(rows[i]["科室"]).Trim();
                    myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim();
                    myrow["PSZT"] = rows[i]["皮试"].ToString();
                    myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                    myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                    myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                    myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                    myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                    myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                    myrow["pyr"] = GetImageByte((Convertor.IsNull(cmbpyr.SelectedValue, "0")));
                    myrow["imgfyr"] = GetImageByte((Convertor.IsNull(rows[i]["qrczyh"], "0")));
                    myrow["imgpyr"] = GetImageByte((Convertor.IsNull(rows[i]["pyczyh"], "0"))); //this.cmbpyr.Text.Trim(); modify by jchl
                    ;
                    myrow["fyr"] = Convert.ToString(rows[i]["发药员"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["发药员"]);
                    myrow["pyckdm"] = Convertor.IsNull(rows[i]["配药窗口"], "") == "" ? "" : Convertor.IsNull(rows[i]["配药窗口"], "");
                    myrow["fyckdm"] = Convertor.IsNull(rows[i]["发药窗口"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["发药窗口"], "");
                    myrow["zdmc"] = Convertor.IsNull(rows[i]["诊断"], "");
                    myrow["syff"] = Convert.ToString(rows[i]["用法"]);
                    myrow["sypc"] = Convert.ToString(rows[i]["使用频次"]);
                    myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                    myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                    myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                    myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");

                    if (rows[i]["组标志"].ToString() == "1")
                    {
                        yzzh = yzzh + 1;
                    }
                    myrow["yzzh"] = yzzh;
                    myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                    myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                    myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                    myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                    //myrow["sfrq"] = PrintRq.ToLongDateString();
                    //myrow["cfrq"] = PrintRq.ToLongDateString();
                    //myrow["blh"] =PrintRq.Year.ToString()+"0"+PrintRq.Month.ToString()+PrintRq.Day.ToString()+ Convert.ToString(rows[i]["门诊号"]).Substring(8,Convert.ToString(rows[i]["门诊号"]).Length-8);
                    myrow["fzbz"] = rows[i]["组标志"].ToString();

                    myrow["JTDZ"] = jtdz;
                    myrow["LXDH"] = grlxdh;
                    myrow["SFZH"] = sfzh;
                    myrow["bz1"] = Convertor.IsNull(rows[i]["中药备注"], "");
                    myrow["bz2"] = Convertor.IsNull(rows[i]["备注2"], "");
                    myrow["bz3"] = Convertor.IsNull(rows[i]["备注3"], "");
                    myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                    myrow["dyr"] = InstanceForm.BCurrentUser.Name;
                    myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                    myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                    Dset.病人处方清单.Rows.Add(myrow);
                    #endregion
                }


            }

            if (Dset.病人处方清单.Rows.Count <= 0)
            {
                return;
            }

            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Text = "cfts";
            parameters[0].Value = rows[0]["剂数"].ToString();
            parameters[1].Text = "zje";
            parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(rows[0]["总金额"], "0"));
            parameters[2].Text = "TITLETEXT";
            parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "";
            parameters[3].Text = "text1";
            parameters[3].Value = "发药单位:" + InstanceForm.BCurrentDept.DeptName + "    诊断:" + rows[0]["诊断"].ToString();

            parameters[4].Text = "xyf";
            if (Convert.ToString(rows[0]["cflx"]).Trim() != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]).Trim() == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            bool bview = true;
            if (chkprintview.Checked == true)
                bview = false;
            TrasenFrame.Forms.FrmReportView f;
            if (cfgs == 1)
            {
                if (Convert.ToString(rows[0]["cflx"]).Trim() == "03")
                    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单_中药处方.rpt", parameters, bview);

                else
                    //f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单(处方格式).rpt", parameters, bview);
                    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_快发病人处方清单(处方格式).rpt", parameters, bview);
            }
            else
            {
                if (Convert.ToString(rows[0]["cflx"]).Trim() == "03")
                    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单_中药处方.rpt", parameters, bview);

                else
                    //f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单(处方格式).rpt", parameters, bview);
                    f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_快发病人处方清单(处方格式).rpt", parameters, bview);
                // f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单(注射单).rpt", parameters, bview);
            }
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();
        }

        private void PrintCfXP()
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;

            DataRow[] rows;
            rows = tb.Select("( 发药='√' or 发药='◆')  and 用量<>''");
            if (rows.Length == 0)
                return;
            string cftsname = "";
            cftsname = Convert.ToString(rows[0]["项目"]).Trim() == "中草药" ? "中药付数" : "";
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow;
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                myrow = Dset.病人处方清单.NewRow();
                //myrow["xh"]=Convert.ToInt32(rows[i]["序号"]);
                myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                myrow["zje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["总金额"], "0"));
                myrow["ypsl"] = Convertor.IsNull(rows[i]["用量"], "0");
                myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                myrow["cfts"] = Convert.ToString(rows[i]["项目"]).Trim() == "中草药" ? rows[i]["剂数"] + "剂" : "";
                myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                string UserEat = "";
                UserEat = rows[i]["频次"].ToString().Trim() == "" ? "" : Convert.ToDouble(rows[i]["剂量"]).ToString() + rows[i]["剂量单位"].ToString().Trim() + "/每次";
                myrow["yf"] = Convert.ToString(rows[i]["用法"]) + "  " + rows[i]["使用频次"].ToString().Trim() + " " + UserEat;


                //Modify by jchl
                //myrow["pc"] = Convertor.IsNull(rows[i]["使用频次"], "");
                myrow["pc"] = Convertor.IsNull(rows[i]["频次"], "");
                //myrow["pc"] = rows[i]["使用频次"].ToString().Trim();

                myrow["syjl"] = "";
                myrow["zt"] = Convert.ToString(rows[i]["嘱托"]);
                myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                myrow["ksname"] = Convert.ToString(rows[i]["科室"]);//+"  费别:"+this.patientInfo1.FeeTypeName;
                string ysqm = "";
                //if (Convert.ToString(row["医生签名"]).Trim()!="")  ysqm="   医生签名:"+Convert.ToString(rows[i]["医生签名"]);
                myrow["ysname"] = Convert.ToString(rows[i]["医生"]) + ysqm;
                myrow["Pyck"] = rows[i]["皮试"].ToString();
                myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                myrow["pyr"] = this.cmbpyr.Text.Trim();
                ;
                myrow["fyr"] = InstanceForm.BCurrentUser.Name;
                Dset.病人处方清单.Rows.Add(myrow);
            }

            ParameterEx[] parameters = new ParameterEx[1];
            parameters[0].Text = "TITLETEXT";
            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "处方明细单";
            bool bview = this.chkprintview.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView(Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单列表_小票.rpt", parameters, bview);
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();

        }

        /// <summary>
        /// 精麻处方打印
        /// </summary>
        /// <param name="dr"></param>
        private void PrintMJ(DataRow row)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows = tb2.Select(" cfxh='" + row["cfxh"] + "' ");

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;
            decimal sumje = 0;
            DataTable dt = null;
            bool jmcf = false;
            //1.查询药品规格信息
            string strsql = @"SELECT d.JSYP,d.MZYP,d.JSYPFL,f.SFZH FROM dbo.MZ_CFB AS a JOIN dbo.MZ_CFB_MX AS b ON a.CFID = b.CFID
                                JOIN YP_YPCJD AS c ON b.BM = c.CJID
                                JOIN dbo.YP_YPGGD AS d ON c.GGID = d.GGID
                                JOIN dbo.YY_BRXX as f ON a.BRXXID = f.BRXXID
                                WHERE a.CFID='" + row["cfxh"] + "'";
            dt = InstanceForm.BDatabase.GetDataTable(strsql, 30);
            //2.判断药品是否是麻醉药品与精神药品，精神药物分类属于一类的药品，则进行打印
            if (dt == null || dt.Rows.Count <= 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((dt.Rows[i]["JSYP"].ToString() == "True" && dt.Rows[i]["JSYPFL"].ToString() == "1") || dt.Rows[i]["MZYP"].ToString() == "True")
                {
                    jmcf=true;
                }
            }
            if(jmcf)
            {
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    myrow = Dset.门诊精麻处方单.NewRow();
                    myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                    myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                    myrow["gg"] = Convert.ToString(rows[i]["规格"]);
                    //myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                    //myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                    myrow["sl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                    myrow["dw"] = Convert.ToString(rows[i]["单位"]);
                    //myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                    sumje = sumje + Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                    //myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "");

                    myrow["pl"] = Convertor.IsNull(rows[i]["频次"], "");
                    myrow["ysimage"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));

                    //myrow["syjl"] = "";
                    //myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                    //myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                    //myrow["ksname"] = Convert.ToString(rows[i]["科室"]).Trim();
                    //myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim();
                    //myrow["PSZT"] = rows[i]["皮试"].ToString();
                    myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                    //myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                    //myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                    //myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                    //myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                    //myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                    //myrow["pyr"] = this.cmbpyr.Text.Trim();

                    //myrow["fyr"] = Convert.ToString(rows[i]["发药员"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["发药员"]);
                    //myrow["pyckdm"] = Convertor.IsNull(rows[i]["配药窗口"], "") == "" ? "" : Convertor.IsNull(rows[i]["配药窗口"], "");
                    //myrow["fyckdm"] = Convertor.IsNull(rows[i]["发药窗口"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["发药窗口"], "");
                    //myrow["zdmc"] = Convertor.IsNull(rows[i]["诊断"], "");
                    myrow["ypyf"] = Convert.ToString(rows[i]["用法"]);
                    //myrow["pl"] = Convert.ToString(rows[i]["使用频次"]);
                    myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                    myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                    //myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                    //myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");
                    //if (rows[i]["组标志"].ToString() == "1")
                    //{
                    //    yzzh = yzzh + 1;
                    //}
                    //myrow["yzzh"] = yzzh;
                    //myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                    //myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                    //myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                    //myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                    //myrow["fzbz"] = rows[i]["组标志"].ToString();

                    ////myrow["JTDZ"] = jtdz;
                    ////myrow["LXDH"] = grlxdh;
                    ////myrow["SFZH"] = sfzh;
                    //myrow["bz1"] = Convertor.IsNull(rows[i]["中药备注"], "");
                    //myrow["bz2"] = Convertor.IsNull(rows[i]["备注2"], "");
                    //myrow["bz3"] = Convertor.IsNull(rows[i]["备注3"], "");
                    //myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                    //myrow["dyr"] = InstanceForm.BCurrentUser.Name;

                    //myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                    //myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                    Dset.门诊精麻处方单.Rows.Add(myrow);
                }
            }

            
            if (Dset.门诊精麻处方单.Rows.Count <= 0) return;
            ParameterEx[] parameters = new ParameterEx[11];
            parameters[0].Text = "xm";
            parameters[0].Value = Convert.ToString(rows[0]["姓名"]);
            parameters[1].Text = "xb";
            parameters[1].Value = Convert.ToString(rows[0]["性别"]);
            parameters[2].Text = "nl";
            parameters[2].Value = Convert.ToString(rows[0]["年龄"]);
            parameters[3].Text = "ks";
            parameters[3].Value = Convert.ToString(rows[0]["科室"]).Trim();
            parameters[4].Text = "bq";
            parameters[4].Value = "";
            parameters[5].Text = "ch";
            parameters[5].Value = "";
            parameters[6].Text = "zd";
            parameters[6].Value = Convertor.IsNull(rows[0]["诊断"], "");
            parameters[7].Text = "hzsfzh";
            parameters[7].Value = dt.Rows[0]["SFZH"].ToString();
            parameters[8].Text = "zyh";
            parameters[8].Value = Convert.ToString(rows[0]["门诊号"]);
            parameters[9].Text = "rq";
            //parameters[9].Value = DateTime.Now.ToString();
            parameters[9].Value = Convert.ToString(rows[0]["录入日期"]);
            parameters[10].Text = "yf";
            parameters[10].Value = sumje;

            bool bview = true;
            if (chkprintview.Checked == true)
                bview = false;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView(Dset.门诊精麻处方单, Constant.ApplicationDirectory + "\\Report\\MZYF_发药麻精一处方清单.rpt", parameters, bview);
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();

        }
        /// <summary>
        /// 毒剧药品处方打印   add by chenli  2017-08-21
        /// </summary>
        /// <param name="row"></param>
        private void PrintDJ(DataRow row)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows = tb2.Select(" cfxh='" + row["cfxh"] + "' ");

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;
            decimal sumje = 0;
            DataTable dt = null;
            bool djcf = false;
            //1.查询药品规格信息
            string strsql = @"SELECT d.DJYP,d.JSYP,d.MZYP,d.JSYPFL,f.SFZH FROM dbo.MZ_CFB AS a JOIN dbo.MZ_CFB_MX AS b ON a.CFID = b.CFID
                                JOIN YP_YPCJD AS c ON b.BM = c.CJID
                                JOIN dbo.YP_YPGGD AS d ON c.GGID = d.GGID
                                JOIN dbo.YY_BRXX as f ON a.BRXXID = f.BRXXID
                                WHERE a.CFID='" + row["cfxh"] + "'";
            dt = InstanceForm.BDatabase.GetDataTable(strsql, 30);
            //2.判断药品是否是精神药品，精神药物分类属于二类的药品，则进行打印
            if (dt == null || dt.Rows.Count <= 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["DJYP"].ToString() == "True")
                {
                   djcf=true;
                }

            }
            if(djcf)
            {
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    myrow = Dset.精二.NewRow();
                    myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                    myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                    myrow["gg"] = Convert.ToString(rows[i]["规格"]);
                    myrow["sl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                    myrow["dw"] = Convert.ToString(rows[i]["单位"]);
                    sumje = sumje + Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));

                    myrow["pl"] = Convertor.IsNull(rows[i]["频次"], "");
                    myrow["ysimage"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));

                    myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                    myrow["ypyf"] = Convert.ToString(rows[i]["用法"]);
                    myrow["bzl"] = Convertor.IsNull(rows[i]["中药备注"], "");
                    myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                    //myrow["pl"] = Convert.ToString(rows[i]["使用频次"]);
                    myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                    myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                    //myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                    //myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");
                    //if (rows[i]["组标志"].ToString() == "1")
                    //{
                    //    yzzh = yzzh + 1;
                    //}
                    //myrow["yzzh"] = yzzh;
                    //myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                    //myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                    //myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                    //myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                    //myrow["fzbz"] = rows[i]["组标志"].ToString();

                    ////myrow["JTDZ"] = jtdz;
                    ////myrow["LXDH"] = grlxdh;
                    ////myrow["SFZH"] = sfzh;

                    //myrow["bz2"] = Convertor.IsNull(rows[i]["备注2"], "");
                    //myrow["bz3"] = Convertor.IsNull(rows[i]["备注3"], "");
                    //myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                    //myrow["dyr"] = InstanceForm.BCurrentUser.Name;

                    //myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                    //myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                    Dset.精二.Rows.Add(myrow);
                }
            }
                
                if (Dset.精二.Rows.Count <= 0) return;
                ParameterEx[] parameters = new ParameterEx[11];
                parameters[0].Text = "xm";
                parameters[0].Value = Convert.ToString(rows[0]["姓名"]);
                parameters[1].Text = "xb";
                parameters[1].Value = Convert.ToString(rows[0]["性别"]);
                parameters[2].Text = "nl";
                parameters[2].Value = Convert.ToString(rows[0]["年龄"]);
                parameters[3].Text = "ks";
                parameters[3].Value = Convert.ToString(rows[0]["科室"]).Trim();
                parameters[4].Text = "bq";
                parameters[4].Value = "";
                parameters[5].Text = "ch";
                parameters[5].Value = "";
                parameters[6].Text = "zd";
                parameters[6].Value = Convertor.IsNull(rows[0]["诊断"], "");
                parameters[7].Text = "hzsfzh";
                parameters[7].Value = dt.Rows[0]["SFZH"].ToString();
                parameters[8].Text = "zyh";
                parameters[8].Value = Convert.ToString(rows[0]["门诊号"]);
                parameters[9].Text = "rq";
                //parameters[9].Value = DateTime.Now.ToString();
                parameters[9].Value = Convert.ToString(rows[0]["录入日期"]);
                parameters[10].Text = "yf";
                parameters[10].Value = sumje;

                bool bview = true;
                if (chkprintview.Checked == true)
                    bview = false;
                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset.精二, Constant.ApplicationDirectory + "\\Report\\MZYF_发药毒剧处方清单.rpt", parameters, bview);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            
        }

        /// <summary>
        /// 精2处方打印
        /// </summary>
        /// <param name="dr"></param>
        private void PrintJ2(DataRow row)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows = tb2.Select(" cfxh='" + row["cfxh"] + "' ");

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;
            decimal sumje = 0;
            DataTable dt = null;
            bool j2cf = false;
            //1.查询药品规格信息
            string strsql = @"SELECT d.DJYP,d.JSYP,d.MZYP,d.JSYPFL,f.SFZH FROM dbo.MZ_CFB AS a JOIN dbo.MZ_CFB_MX AS b ON a.CFID = b.CFID
                                JOIN YP_YPCJD AS c ON b.BM = c.CJID
                                JOIN dbo.YP_YPGGD AS d ON c.GGID = d.GGID
                                JOIN dbo.YY_BRXX as f ON a.BRXXID = f.BRXXID
                                WHERE a.CFID='" + row["cfxh"] + "'";
            dt = InstanceForm.BDatabase.GetDataTable(strsql, 30);
            //2.判断药品是否是精神药品，精神药物分类属于二类的药品，则进行打印
            if (dt == null || dt.Rows.Count <= 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["JSYPFL"].ToString() == "2")
                {
                    j2cf=true;
                }

            }
            if (j2cf)
            {
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    myrow = Dset.精二.NewRow();
                    myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                    myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                    myrow["gg"] = Convert.ToString(rows[i]["规格"]);
                    myrow["sl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                    myrow["dw"] = Convert.ToString(rows[i]["单位"]);
                    sumje = sumje + Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));

                    myrow["pl"] = Convertor.IsNull(rows[i]["频次"], "");
                    myrow["ysimage"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));

                    myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                    myrow["ypyf"] = Convert.ToString(rows[i]["用法"]);
                    myrow["bzl"] = Convertor.IsNull(rows[i]["中药备注"], "");
                    myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                    //myrow["pl"] = Convert.ToString(rows[i]["使用频次"]);
                    myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                    myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                    //myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                    //myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");
                    //if (rows[i]["组标志"].ToString() == "1")
                    //{
                    //    yzzh = yzzh + 1;
                    //}
                    //myrow["yzzh"] = yzzh;
                    //myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                    //myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                    //myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                    //myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                    //myrow["fzbz"] = rows[i]["组标志"].ToString();

                    ////myrow["JTDZ"] = jtdz;
                    ////myrow["LXDH"] = grlxdh;
                    ////myrow["SFZH"] = sfzh;

                    //myrow["bz2"] = Convertor.IsNull(rows[i]["备注2"], "");
                    //myrow["bz3"] = Convertor.IsNull(rows[i]["备注3"], "");
                    //myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                    //myrow["dyr"] = InstanceForm.BCurrentUser.Name;

                    //myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                    //myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                    Dset.精二.Rows.Add(myrow);
                }
            }

            
            if (Dset.精二.Rows.Count <= 0) return;
            ParameterEx[] parameters = new ParameterEx[11];
            parameters[0].Text = "xm";
            parameters[0].Value = Convert.ToString(rows[0]["姓名"]);
            parameters[1].Text = "xb";
            parameters[1].Value = Convert.ToString(rows[0]["性别"]);
            parameters[2].Text = "nl";
            parameters[2].Value = Convert.ToString(rows[0]["年龄"]);
            parameters[3].Text = "ks";
            parameters[3].Value = Convert.ToString(rows[0]["科室"]).Trim();
            parameters[4].Text = "bq";
            parameters[4].Value = "";
            parameters[5].Text = "ch";
            parameters[5].Value = "";
            parameters[6].Text = "zd";
            parameters[6].Value = Convertor.IsNull(rows[0]["诊断"], "");
            parameters[7].Text = "hzsfzh";
            parameters[7].Value = dt.Rows[0]["SFZH"].ToString();
            parameters[8].Text = "zyh";
            parameters[8].Value = Convert.ToString(rows[0]["门诊号"]);
            parameters[9].Text = "rq";
            //parameters[9].Value = DateTime.Now.ToString();
            parameters[9].Value = Convert.ToString(rows[0]["录入日期"]);
            parameters[10].Text = "yf";
            parameters[10].Value = sumje;

            bool bview = true;
            if (chkprintview.Checked == true)
                bview = false;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView(Dset.精二, Constant.ApplicationDirectory + "\\Report\\MZYF_发药精二处方清单.rpt", parameters, bview);
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();

        }

        //查询病人
        private void txtghxh_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                int nkey = Convert.ToInt32(e.KeyChar);
                if (nkey == 13)
                {
                    //if (rdo1.Checked && bqyyfkf && !string.IsNullOrEmpty(kflx))
                    //{
                    //    if (string.IsNullOrEmpty(_Fyckh))
                    //    {
                    //        MessageBox.Show("您没有选择发药窗口,请选择后重试", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //}
                    DataTable mytb = (DataTable)this.myDataGrid1.DataSource;
                    mytb.Rows.Clear();

                    Control control = (Control)sender;
                    ts_mz_brxx.MzGhxx ghxx = null;
                    ts_mz_brxx.MzBrxx brxx = null;

                    string sfrq1 = "";
                    string sfrq2 = "";
                    string fyrq1 = "";
                    string fyrq2 = "";
                    decimal jslsh = Convert.ToDecimal(Convertor.IsNull(txtlsh.Text, "0"));

                    if (rdo1.Checked == true)
                    {
                        sfrq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                        sfrq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                        fyrq1 = "";
                        fyrq2 = "";
                    }
                    else
                    {
                        sfrq1 = "";
                        sfrq2 = "";
                        fyrq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                        fyrq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                    }

                    DataTable tb = null;
                    if (control.Name == "txtmzh")
                    {
                        this.txtmzh.Text = FunBase.returnMzh(this.txtmzh.Text, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                        DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, txtmzh.Text.Trim(), 0, 0, InstanceForm.BDatabase);
                        if (tbghxx.Rows.Count == 0)
                            tbghxx = tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, txtmzh.Text.Trim(), 0, 1, InstanceForm.BDatabase);
                        if (tbghxx.Rows.Count == 0)
                        {
                            MessageBox.Show("没有找到病人，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                        brxx = new ts_mz_brxx.MzBrxx(ghxx.binid, 0, "", "", Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), ghxx.ghxh, "",
                            "", 0,
                            fyrq1, fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                        this.txttmk.Text = "";
                        jslsh = 0;
                        //this.txtghxh.Text="";
                        this.txtfph.Text = "";
                        _textBox = txtmzh;

                    }
                    if (control.Name == "txttmk")
                    {
                        int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));

                        //txttmk.Text = Fun.returnKh(klx, txttmk.Text, InstanceForm.BDatabase);

                        brxx = new ts_mz_brxx.MzBrxx(Guid.Empty, klx, txttmk.Text.Trim(), "", Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        if (brxx.binid == Guid.Empty)
                        {
                            MessageBox.Show("没有找到病人，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(brxx.binid, Guid.Empty, "", 0, Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        Guid ghxxid = Guid.Empty;
                        if (tbghxx.Rows.Count > 0)
                        {
                            ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                            ghxxid = ghxx.ghxh;
                        }
                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, "",
                            "", 0,
                            fyrq1, fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0,
                            Guid.Empty, brxx.binid, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                        this.txtmzh.Text = "";
                        this.txtfph.Text = "";
                        jslsh = 0;
                        _textBox = txttmk;
                    }
                    if (control.Name == "txtlsh")
                    {
                        //DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, new Guid(Convertor.IsNull(txtghxh.Text, Guid.Empty.ToString())), "", 0, Convert.ToInt16(this.rdols.Checked));
                        //if (tbghxx.Rows.Count == 0) { MessageBox.Show("没有找到病人，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        DataRow row = null;
                        //ghxx = new ts_mz_brxx.MzGhxx(row);
                        //brxx = new ts_mz_brxx.MzBrxx(Guid.Empty, 0, "","", Convert.ToInt16(this.rdols.Checked),InstanceForm.BDatabase);

                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, "",
                            Convertor.IsNull(txtfph.Text, "0"), jslsh,
                            fyrq1, fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                        this.txtmzh.Text = "";
                        this.txttmk.Text = "";
                        this.txtfph.Text = "";
                        _textBox = txtlsh;
                    }

                    bool bBMYF = false;
                    if (control.Name == "txtfph")
                    {

                        if (Convertor.IsNumeric(txtfph.Text) == false)
                        {
                            MessageBox.Show("发票号请输入数字，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        //未发药是否是便民药房的药品 Modify by jchl
                        if (Convert.ToInt16(this.rdo2.Checked) != 1)
                        {
                            string strSql = string.Format(@"select COUNT(1) as Num from MZ_CFB where FPH='{0}' and ZXKS in (841)", Convert.ToInt64(Convertor.IsNull(txtfph.Text, "0")));
                            int iNum = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(strSql).ToString());
                            if (iNum > 0)
                            {
                                MessageBox.Show("该发票执行科室为【便民药房】,不能发药!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }
                        }

                        DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, "", Convert.ToInt64(Convertor.IsNull(txtfph.Text, "0")), Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        //if (tbghxx.Rows.Count==0){MessageBox.Show("没有找到病人，请重新输入","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);return;}
                        if (tbghxx.Rows.Count > 0)
                        {
                            ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                            brxx = new ts_mz_brxx.MzBrxx(ghxx.binid, 0, "", "", Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        }



                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, "",
                            Convertor.IsNull(txtfph.Text, "0"), 0,
                            fyrq1, fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                        this.txtmzh.Text = "";
                        this.txttmk.Text = "";
                        jslsh = 0;
                        //this.txtghxh.Text="";
                        _textBox = txtfph;
                    }

                    this.chkall.Checked = false;
                    //if (rdo1.Checked)
                    //{
                    //    //快发设置
                    //    SendClinicInfo(tb);
                    //}

                    this.AddPresc(tb);

                    if (this.rdo1.Checked == true)
                    {
                        if (tb.Rows.Count > 0)
                            this.chkall.Checked = true;
                        else
                            this.chkall.Checked = false;
                    }

                    lblxm.Text = "";
                    lblxb.Text = "";
                    lblnl.Text = "";
                    lblks.Text = "";
                    lblzd.Text = "";
                    if (tb.Rows.Count > 0)
                    {
                        lblxm.Text = tb.Rows[0]["姓名"].ToString();
                        lblxb.Text = tb.Rows[0]["性别"].ToString();
                        lblnl.Text = tb.Rows[0]["年龄"].ToString();
                        lblks.Text = tb.Rows[0]["科室"].ToString();
                        lblzd.Text = tb.Rows[0]["诊断"].ToString();

                        firstXm = string.Empty;
                        //setButtionState = 0;
                    }

                    //if ( brxx != null )
                    //{
                    //    this.lblxm.Text = Convertor.IsNull( brxx.姓名 , "" );
                    //    this.lblxb.Text = Convertor.IsNull( brxx.性别 , "" );
                    //    this.lblnl.Text = Convertor.IsNull( brxx.年龄 , "" );
                    //    this.lblks.Text = ghxx == null ? "" : Convertor.IsNull( ghxx.挂号科室名称 , "" );
                    //    this.lblzd.Text = ghxx == null ? "" : Convertor.IsNull( ghxx.诊断名称 , "" );
                    //}
                    //else
                    //{
                    //    this.lblxm.Text = "";
                    //    this.lblxb.Text = "";
                    //    this.lblnl.Text = "";
                    //    this.lblks.Text = ghxx == null ? "" : Convertor.IsNull( ghxx.挂号科室名称 , "" );
                    //    this.lblzd.Text = ghxx == null ? "" : Convertor.IsNull( ghxx.诊断名称 , "" );
                    //}

                    if (tb.Rows.Count != 0 && this.rdo1.Checked == true && s.门诊发药按钮是否立即获得焦点 == true)
                        this.butfy.Focus();
                    else
                    {
                        TextBox control1 = (TextBox)sender;
                        control1.SelectAll();
                        control1.Focus();
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtmzh_Move(object sender, System.EventArgs e)
        {
            txtmzh.Focus();
            txtmzh.Select(0, txtmzh.Text.Length);
        }

        private void txtmzh_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Control control = (Control)sender;
            if (control.Name == "txtmzh")
            {
                txtmzh.Focus();
                txtmzh.Select(0, txtmzh.Text.Length);
            }
            if (control.Name == "txttmk")
            {
                txttmk.Focus();
                txttmk.Select(0, txttmk.Text.Length);
            }
            if (control.Name == "txtghxh")
            {
                //txtghxh.Focus();
                //txtghxh.Select(0,txtghxh.Text.Length);
            }
            if (control.Name == "txtfph")
            {
                txtfph.Focus();
                txtfph.Select(0, txtfph.Text.Length);
            }
        }

        private void rdo2_CheckedChanged(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
            this.chkall.Checked = false;
            this.chkall.Enabled = this.rdo1.Checked == true ? true : false;
            this.butfy.Enabled = this.rdo1.Checked == true ? true : false;

            if (rdo2.Checked == true)
                myDataGrid1.TableStyles[0].GridColumnStyles["警示灯"].Width = 0;
            else
                myDataGrid1.TableStyles[0].GridColumnStyles["警示灯"].Width = 25;
            button_ref_Click(sender, e);

        }

        private void butprinthz_Click(object sender, System.EventArgs e)
        {

        }

        private void Frmcffy_Activated(object sender, System.EventArgs e)
        {
            this.txtmzh.Focus();
            string khjd = ApiFunction.GetIniString("门诊发药", "卡号优先获得焦点", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (khjd == "true")
                txttmk.Focus();
        }

        private void Frmcffy_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SERVER_NAME", "NAME", Constant.ApplicationDirectory + "\\ClientConfig.ini");
                string connectionString = WorkStaticFun.GetConnnectionString(ConnectionType.SQLSERVER, serverName);
                //Modify By Tany 2016-02-17
                //戴岳文当时屏蔽以下代码是为了武汉中心医院叫号，不清除网卡地址，现在放开，修改Update_fyck方法
                RelationalDatabase database = FunBase.Database(ConnectionType.SQLSERVER, connectionString);
                MZYF.Update_fyck(IPAddRess, _Fyckh, 0, database);
                database.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butqhfyck_Click(object sender, EventArgs e)
        {
            this.Close();
            Frmpyck f = new Frmpyck(_menuTag, _chineseName, _mdiParent);
            f.ShowDialog();
        }


        private void txtxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                butcfcx_Click(sender, null);
        }

        private void txttmk_Enter(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Name == "txtfph")
                chkrq.Checked = false;
            if (control.Name == "txttmk")
            {
                //dtprq1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(-1);
                //dtprq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                chkrq.Checked = true;
            }
            if (control.Name == "txtmzh" && rdo2.Checked == true)
                chkrq.Checked = false;
        }

        private void button_ref_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Value = _menuTag.Function_Name.Trim();
                parameters[1].Value = InstanceForm.BCurrentDept.DeptId;
                parameters[2].Value = dtprq_ref.Value.ToShortDateString() + "";
                parameters[3].Value = dtprq_ref.Value.ToShortDateString() + "";
                parameters[4].Value = _Fyckh;
                parameters[5].Value = rdodq.Checked == true ? 0 : 1;
                parameters[6].Value = rdo1.Checked == true ? 0 : 1;

                parameters[0].Text = "@functionName";
                parameters[1].Text = "@deptid";
                parameters[2].Text = "@rq1";
                parameters[3].Text = "@rq2";
                parameters[4].Text = "@FYCK";
                parameters[5].Text = "@bk";
                parameters[6].Text = "@fybz";

                DataTable tb = InstanceForm.BDatabase.GetDataTable("sp_yf_select_MZCF_REF", parameters, 30);
                FunBase.AddRowtNo(tb);

                this.dataGridView1.DataSource = tb.DefaultView;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataView dv = (DataView)dataGridView1.DataSource;
            if (dataGridView1.CurrentCell == null)
                return;
            if (dv.Table.Rows.Count == 0)
                return;
            this.Cursor = PubStaticFun.WaitCursor();
            //if (rdo1.Checked && bqyyfkf && !string.IsNullOrEmpty(kflx))
            //{
            //    if (string.IsNullOrEmpty(_Fyckh))
            //    {
            //        MessageBox.Show("您没有选择发药窗口,请选择后重试", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}            
            try
            {
                int nrow = dataGridView1.CurrentCell.RowIndex;
                int bk = this.rdodq.Checked == true ? 0 : 1;
                int fybz = rdo1.Checked == true ? 0 : 1;
                string sfrq1 = "";
                string sfrq2 = "";
                string fyrq1 = "";
                string fyrq2 = "";
                string brxxid = dv[nrow]["brxxid"].ToString();
                string fph = dv[nrow]["发票号"].ToString();

                sfrq1 = chkrq.Checked == true ? dtprq_ref.Value.ToShortDateString() : "";
                sfrq2 = chkrq.Checked == true ? dtprq_ref.Value.ToShortDateString() : "";
                fyrq1 = "";
                fyrq2 = "";

                DataTable tb = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, Guid.Empty, txtxm.Text.Trim(), fph, 0,
                     fyrq1, fyrq2, 0, fybz, "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, new Guid(brxxid), Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                lblxm.Text = "";
                lblxb.Text = "";
                lblnl.Text = "";
                lblks.Text = "";
                lblzd.Text = "";
                if (tb.Rows.Count > 0)
                {
                    lblxm.Text = tb.Rows[0]["姓名"].ToString();
                    lblxb.Text = tb.Rows[0]["性别"].ToString();
                    lblnl.Text = tb.Rows[0]["年龄"].ToString();
                    lblks.Text = tb.Rows[0]["科室"].ToString();
                    lblzd.Text = tb.Rows[0]["诊断"].ToString();
                }
                //if (rdo1.Checked)
                //{
                //    //快发设置
                //    SendClinicInfo(tb);
                //}
                this.AddPresc(tb);
                if (rdo1.Checked == true)
                {
                    chkall.Checked = false;
                    chkall.Checked = true;
                }
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

        private void Frmcffy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                button_ref_Click(sender, e);
            }
            if (e.KeyData == Keys.F9)
            {
                buthj_Click(sender, e);
            }
        }

        private void buthj_Click(object sender, EventArgs e)
        {
            try
            {
                string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (Convertor.IsNull(_Fyckh, "") == "")
                {
                    MessageBox.Show("您没有选择发药窗口,请选择后重试", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable tb = (DataTable)myDataGrid1.DataSource;
                DataRow[] selrow;
                if (rdo1.Checked == true)
                    selrow = tb.Select("发药='◆' and ypid<>''");
                else
                    selrow = tb.Select("发药='√' and ypid<>''");

                if (selrow.Length == 0)
                {
                    MessageBox.Show("请选择病人处方后再呼叫", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string inpid = selrow[0]["PATID"].ToString();//ghxxid
                string brxm = selrow[0]["姓名"].ToString();// tb.Rows[0]["姓名"].ToString();改为选择的病人

                decimal sumje;
                if (rdo1.Checked == true)
                    sumje = Convert.ToDecimal(tb.Compute("sum(金额)", "发药='◆'"));
                else
                    sumje = Convert.ToDecimal(tb.Compute("sum(金额)", "发药='√'"));

                ts_call.CFMX[] cfmx = new ts_call.CFMX[selrow.Length];
                for (int i = 0; i <= selrow.Length - 1; i++)
                {
                    cfmx[i].PM = Convertor.IsNull(selrow[i]["品名"], "");
                    cfmx[i].GG = Convertor.IsNull(selrow[i]["规格"], "");
                    cfmx[i].DJ = Convert.ToDecimal(Convertor.IsNull(selrow[i]["单价"], "0"));
                    cfmx[i].SL = Convert.ToDecimal(Convertor.IsNull(selrow[i]["用量"], "0"));
                    cfmx[i].DW = Convertor.IsNull(selrow[i]["单位"], "0");
                    cfmx[i].JE = Convert.ToDecimal(Convertor.IsNull(selrow[i]["金额"], "0"));
                    cfmx[i].fyck = _Fyckmc;
                    cfmx[i].deptid = InstanceForm.BCurrentDept.DeptId;
                    cfmx[i].brxm = Convertor.IsNull(selrow[i]["姓名"], "");
                    cfmx[i].fph = Convertor.IsNull(selrow[i]["发票号"], "");
                }

                //分组处方
                DataTable tbsel = tb.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);
                string[] GroupbyField ={ "FPID", "姓名", "发票号", "门诊号" };
                string[] ComputeField ={ "金额" };
                string[] CField ={ "sum" };
                DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                if (tbcf.Rows.Count == 0)
                {
                    MessageBox.Show("没有要发药的药品记录");
                    return;
                }
                string brkh = string.Empty;
                for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                {
                    ParameterEx[] parameters = new ParameterEx[11];
                    parameters[0].Text = "@FPID";
                    parameters[0].DataType = System.Data.DbType.Guid;
                    parameters[0].Value = tbcf.Rows[i]["fpid"].ToString();

                    parameters[1].Text = "@FPH";
                    parameters[1].Value = tbcf.Rows[i]["发票号"].ToString();

                    parameters[2].Text = "@ZJE";
                    parameters[2].DataType = System.Data.DbType.Decimal;
                    parameters[2].Value = tbcf.Rows[i]["金额"].ToString();

                    parameters[3].Text = "@BRXM";
                    parameters[3].Value = tbcf.Rows[i]["姓名"].ToString();

                    parameters[4].Text = "@BLH";
                    parameters[4].Value = tbcf.Rows[i]["门诊号"].ToString();
                    brkh = tbcf.Rows[i]["门诊号"].ToString();

                    parameters[5].Text = "@LYCK";
                    parameters[5].Value = _Fyckh;

                    parameters[6].Text = "@LYCKMC";
                    parameters[6].Value = _Fyckmc;

                    parameters[7].Text = "@DEPTID";
                    parameters[7].DataType = System.Data.DbType.Int32;
                    parameters[7].Value = InstanceForm.BCurrentDept.DeptId;

                    parameters[8].Text = "@DEPTNAME";
                    parameters[8].Value = InstanceForm.BCurrentDept.DeptName;

                    parameters[9].Text = "@DJY";
                    parameters[9].Value = InstanceForm.BCurrentUser.EmployeeId;

                    parameters[10].Text = "@jhlx";
                    parameters[10].Value = "call";

                    int iii = InstanceForm.BDatabase.DoCommand("SP_YF_FYJH", parameters, 60);

                    if (rdo2.Checked)
                    {
                        break;
                    }
                }

                if (bqybjq == "true" && _menuTag.Function_Name == "Fun_ts_yf_mzfy")
                {
                    if (!string.IsNullOrEmpty(_Fyckh) && !string.IsNullOrEmpty(brkh) && _call is ts_call_whzxyybymz)
                    {
                        (_call as ts_call_whzxyybymz).Brkh = brkh;
                        (_call as ts_call_whzxyybymz).Qyzt = 1;
                        (_call as ts_call_whzxyybymz).WindowNum = _Fyckh;
                    }

                    Caller call = new Caller(brxm, sumje, cfmx, this._call);
                    thCall = new Thread(new ThreadStart(call.call_hj));
                    call.Thread = thCall;
                    thCall.Start();
                }

                //2013-08-08
                string bqyyy = ApiFunction.GetIniString("语音配置", "启用语音", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string byyxh = ApiFunction.GetIniString("语音配置", "启用型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqyyy == "true" && _menuTag.Function_Name == "Fun_ts_yf_mzfy")
                {
                    ts_VoiceCall.Icall _voiceCaller = ts_VoiceCall.CallFactory.NewCall(byyxh);
                    string ss = "请" + brxm + "到" + _Fyckmc + "来取药";
                    _voiceCaller.Call(ss);

                    VoiceCaller call = new VoiceCaller(ss, _voiceCaller);
                    thCall = new Thread(new ThreadStart(call.VoiceCall));
                    call.Thread = thCall;
                    thCall.Start();
                    //string strSqlBrxxid = string.Format("select BRXXID from MZ_GHXX where GHXXID='{0}'", inpid);
                    //inpid = InstanceForm.BDatabase.GetDataResult(strSqlBrxxid).ToString();

                    //ClsMzCall.CallInp.CallInpatient(_Fyckmc, brxm, inpid);

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                if (Convert.ToInt64(Convertor.IsNull(dgv.Cells["打印"].Value, "0")) > 0)
                {
                    dgv.DefaultCellStyle.BackColor = Color.SkyBlue;
                }

                if (rdo2.Checked == true)
                {
                    dgv.DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
        }

        private void myDataGrid1_BindingContextChanged(object sender, EventArgs e)
        {


        }

        private void myDataGrid1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbyf_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptid = Convert.ToInt32(Convertor.IsNull(cmbyf.SelectedValue, "0")); //库房id
            bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);                        //是否进行批次管理
        }

        private int uid_pyr = 0;
        private void cmbpyr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbpyr.SelectedValue == null || cmbpyr.SelectedValue == DBNull.Value || cmbpyr.SelectedValue.ToString().Equals("-1"))
                    return;

                int uid_sel = Convert.ToInt32(cmbpyr.SelectedValue);//选择用户
                int uid_cur = InstanceForm.BCurrentUser.EmployeeId;//当前用户
                SystemCfg cfg8059 = new SystemCfg(8059);
                //if (cfg8059.Config == "1")

                if (true)
                {
                    //if (uid_sel != uid_cur && uid_pyr != 0)
                    if (uid_sel != uid_cur)
                    {
                        //身份的再次确认
                        string dlgvalue = Ts_zyys_public.DlgPW.Show();
                        string pwStr = dlgvalue; //YS.Password;

                        string strSql = string.Format("select Id as userid from Pub_User where Employee_Id={0} ", uid_sel);
                        int userid = int.Parse(Convertor.IsNull(InstanceForm.BCurrentUser.Database.GetDataResult(strSql), uid_sel.ToString()));

                        bool bOk = new User(userid, InstanceForm.BDatabase).CheckPassword(pwStr);

                        if (!bOk)
                        {
                            TrasenFrame.Forms.FrmMessageBox.Show("你没有通过权限确认，不能进行此操作！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbpyr.SelectedValue = "-1";
                            return;
                        }
                    }

                }
                uid_pyr = Convert.ToInt32(cmbpyr.SelectedValue);
            }
            catch { }
        }

        private byte[] GetImageByte(string strEmployeeId)
        {
            string ss = "select sign from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID=" + strEmployeeId + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ss);
            if (tb == null || tb.Rows.Count == 0 || tb.Rows[0]["sign"].GetType().ToString() == "System.DBNull")
                return null;
            else
                return ((byte[])tb.Rows[0]["sign"]);
        }


        #region 门诊快发控制
        /// <summary>
        ///ClientWindow.ini设置快发的类型
        /// </summary>
        /// <returns></returns>
        private bool IsVisable()
        {
            string strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("药房快发设置", "类型", Application.StartupPath + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(strVal))
                TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("药房快发设置", "类型", "", Application.StartupPath + "\\ClientWindow.ini");
            strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("药房快发设置", "类型", Application.StartupPath + "\\ClientWindow.ini");
            return strVal == "1" ? true : false;
        }


        /// <summary>
        /// 处方开始发送 
        /// </summary>
        /// <param name="tbInfo"></param>
        /// <param name="strWinid">窗口号</param>
        /// <param name="strManno">操作员</param>
        /// <param name="strManname">操作员编号</param>
        /// <param name="strIP">IP地址</param>
        private int SendClinicInfo(DataTable tbInfo, string brxm, string brxxid, string str_HH_Flag)
        {
            //窗口号/操作员编号/操作员/IP地址
            int ret = 0;
            string retMsg = string.Empty;
            try
            {
                if (bqyyfkf)
                {
                    if (kf != null)
                    {
                        kf.DataBase = InstanceForm.BDatabase;
                        kf.Brxm = brxm;
                        kf.Brxxid = brxxid;
                        ret = kf.SendMedicine(tbInfo, this._Fyckh, InstanceForm.BCurrentUser.EmployeeId.ToString(), InstanceForm.BCurrentUser.Name.Trim(), this.IPAddRess, InstanceForm.BCurrentDept.DeptId, str_HH_Flag);

                        if (ret == 200) //此处返回值?
                        {
                            MessageBox.Show("发药机正在配药中,请稍后!", "提示");
                            return 0;
                        }
                    }
                    else
                    {

                        retMsg = "kf为NULL,导致未调用SendMedicine接口";
                    }
                }
                else
                {
                    retMsg = "是否启用快发发药的bqyyfkf参数为false,导致未调用SendMedicine接口";
                }


                if (!string.IsNullOrEmpty(retMsg))
                {
                    ThrowTechError(retMsg, 1, new List<string>(), _Fyckh, this.WanIp, brxm, brxxid);
                }
            }
            catch (Exception err)
            {
                retMsg = string.Format("执行SendClinicInfo方法出现异常:{0}", err.Message);
                ThrowTechError(retMsg, 1, new List<string>(), _Fyckh, this.WanIp, brxm, brxxid);
            }
            return ret;
        }

        /// <summary>
        /// 处方结束发药
        /// </summary>
        /// <param name="tbInfo"></param>
        private string EndClinicInfo(DataTable tbInfo, string brxm, string brxxid, string str_HH_Flag)
        {
            string retMsg = string.Empty;
            string ret = "0";
            try
            {
                if (kf != null)
                {
                    if (bqyyfkf)
                    {
                        kf.DataBase = InstanceForm.BDatabase;
                        kf.Brxm = brxm;
                        kf.Brxxid = brxxid;
                        ret = kf.EndToMedicine(tbInfo, this._Fyckh, InstanceForm.BCurrentUser.EmployeeId.ToString(), InstanceForm.BCurrentUser.Name.Trim(), this.IPAddRess, InstanceForm.BCurrentDept.DeptId, str_HH_Flag);

                        string msg = string.Empty;

                        if (ret == "101") //返回的参数值？
                            msg = "输入参数为空!";
                        else if (ret == "102" || ret == "103")
                            msg = "cfid对应whzxyy_mz_cfb_zb单号为空";

                        if (string.IsNullOrEmpty(msg)) //如果没有异常  update code  py  2016-7-5
                        {
                            if (!string.IsNullOrEmpty(ret) && ret.Contains(","))
                            {
                                return ret;
                            }
                        }
                    }
                    else
                    {
                        retMsg = "结束发药时bqyyfkf参数为false,导致未调用EndToMedicine接口";
                    }
                }
                else
                {
                    retMsg = "kf为NULL,导致未调用EndToMedicine接口";
                }

                if (!string.IsNullOrEmpty(retMsg))
                {
                    ThrowTechError(retMsg, 2, new List<string>(), _Fyckh, this.WanIp, brxm, brxxid);
                }
            }
            catch (Exception err)
            {
                retMsg = string.Format("执行EndClinicInfo方法出现异常:{0}", err.Message);
                ThrowTechError(retMsg, 2, new List<string>(), _Fyckh, this.WanIp, brxm, brxxid);
            }
            return ret;
        }

        /// <summary>
        /// 记录错误的记录日志
        /// </summary>
        /// <param name="error"></param>
        /// <param name="type"></param>
        /// <param name="cfList"></param>
        /// <param name="fyckh"></param>
        /// <param name="execIp"></param>
        /// <param name="Brxm"></param>
        /// <param name="Brxxid"></param>
        void ThrowTechError(string error, int type, List<string> cfList, string fyckh, string execIp, string Brxm, string Brxxid)
        {
            if (kf != null && kf is ts_whzxyy_mzkf)
            {
                string remark = string.Empty;
                object[] param = null;
                try
                {
                    string ErrPath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, "门诊快发日志");
                    if (!Directory.Exists(ErrPath))
                    {
                        Directory.CreateDirectory(ErrPath);
                    }
                    StreamWriter txtWriter = new StreamWriter(string.Format(@"{0}\{1}-log.txt", ErrPath, DateTime.Now.ToString("yyyy-MM-dd")), true);
                    param = new object[] { Brxm ?? "",
                                   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                   type == 1 ? "开始发药" : "结束发药", 
                                   type == 1 ? "sendMedToWillach" : "endSendMedToWillach", 
                                   error };
                    remark = string.Format("{0}在{1}{2},调用华润{3}接口返回:{4}", param);
                    txtWriter.WriteLine(remark);
                    if (cfList != null && cfList.Count > 0)
                    {
                        foreach (string s in cfList)
                            txtWriter.WriteLine(s);
                    }
                    txtWriter.WriteLine();
                    txtWriter.Close();
                }
                catch
                {
                    MessageBox.Show("本地日志记录失败!", "提示");
                }

                try
                {
                    param = new object[] { Guid.NewGuid().ToString(), Brxxid, Brxm, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), type, error, remark, execIp, string.IsNullOrEmpty(fyckh) ? "Null" : fyckh, InstanceForm.BCurrentDept.DeptId };
                    string sql = string.Format(@"insert into mz_mzkflog(ID,BRXXID,BRXM,CREATEDATE,KFTYPE,EXECRESULT,REMARK,EXECIP,FYCKH,DEPTID) VALUES(
                               '{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}',{8},{9})", param);
                    InstanceForm.BDatabase.DoCommand(sql);
                }
                catch (Exception err)
                {
                    MessageBox.Show(string.Format("数据库日志记录失败!{0}", err.Message), "提示");
                }
            }
        }

        private string WanIp
        {
            get
            {
                try
                {
                    System.Net.IPAddress addr;
                    addr = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
                    return addr.ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
        }


        #endregion

        /// <summary>
        /// 点击配药按钮进行配药 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPy_Click(object sender, EventArgs e)
        {
            if (rdo1.Checked == false)
            {
                MessageBox.Show("只能对未发药的病人配药!");
                return;
            }
            if (rdo1.Checked && bqyyfkf && !string.IsNullOrEmpty(kflx))
            {
                if (string.IsNullOrEmpty(_Fyckh))
                {
                    MessageBox.Show("您没有选择发药窗口,请选择后重试", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DataTable tb = myDataGrid1.DataSource as DataTable;
            if (tb == null || tb.Rows.Count == 0)
            {
                MessageBox.Show("没有找到病人及处方信息", "提示");
                return;
            }
            object objXm = tb.Rows[0]["姓名"] ?? "";
            object objbrxxid = InstanceForm.BDatabase.GetDataResult("select BRXXID from MZ_GHXX where GHXXID='" + tb.Rows[0]["patid"].ToString() + "' ");
            string brxm = objXm.ToString();
            string brxxid = objbrxxid != null ? objbrxxid.ToString() : "";
            string msg = string.Format("确定要为{0}执行配药操作吗？", brxm);
            this.Cursor = PubStaticFun.WaitCursor();

            //Add by zhujh 2017-05-27 新增耗时监控开始
          //  ExecTimeLogger logger = ExecTimeLogger.Run("药房配药");

            try
            {
                int bk = this.rdodq.Checked == true ? 0 : 1;
                int fybz = rdo1.Checked == true ? 0 : 1;
                string sfrq1 = "";
                string sfrq2 = "";
                string fyrq1 = "";
                string fyrq2 = "";
                string fph = ""; //tb.Rows[0]["发票号"].ToString();

                sfrq1 = chkrq.Checked == true ? dtprq_ref.Value.ToShortDateString() : "";
                sfrq2 = chkrq.Checked == true ? dtprq_ref.Value.ToShortDateString() : "";
                fyrq1 = "";
                fyrq2 = "";

                int num = 0;
                DataTable table = null;
            Label001:
                {

                    table = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, Guid.Empty, txtxm.Text.Trim(), fph, 0, fyrq1, fyrq2, 0, fybz,
                        "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, new Guid(brxxid), Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                }

                if (rdo1.Checked)
                {
                    if (num <= 3)
                    {
                        if (table == null || table.Rows.Count == 0)
                        {
                            num++;
                            Thread.Sleep(2000);
                            goto Label001;
                        }
                    }
                    // 快发配药
                    //Add by zhujh 2017-05-27 新增耗时监控开始
                    //ExecTimeLogger logger = ExecTimeLogger.Run("药房配药");
                    //北院南院使用相同门诊快发

                    string str_HHkf_settingValue = ApiFunction.GetIniString("药房快发设置", "类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    string str_HH_Flag = "";
                    if (str_HHkf_settingValue.Equals("北院使用南院相同门诊快发"))
                    {
                        str_HH_Flag = "1";
                    }

                    int ret = SendClinicInfo(table, brxm, brxxid, str_HH_Flag);

                    //Add by zhujh 2017-05-27 新增耗时监控结束
                    //logger.Stop();

                    if (ret == 0)
                    {
                        MessageBox.Show("药品快发配药未成功！");
                    }
                    if (ret == 1)
                    {
                       //  MessageBox.Show("药品快发配药成功！");
                    }
                    if (ret == 2)
                    {
                        MessageBox.Show("药品快发未找到处方！");
                    }
                    if (ret == 3)
                    {
                        MessageBox.Show("药品快发已经点击配药！");
                    }
                    if (ret == 4)
                    {
                        MessageBox.Show("药品快发已经点击配药！");
                    }
                    if (ret == 5)
                    {
                        MessageBox.Show("隔日处方，请发送重新调配指令！");
                    }
                }

                lblxm.Text = "";
                lblxb.Text = "";
                lblnl.Text = "";
                lblks.Text = "";
                lblzd.Text = "";
                if (table.Rows.Count > 0)
                {
                    lblxm.Text = table.Rows[0]["姓名"].ToString();
                    lblxb.Text = table.Rows[0]["性别"].ToString();
                    lblnl.Text = table.Rows[0]["年龄"].ToString();
                    lblks.Text = table.Rows[0]["科室"].ToString();
                    lblzd.Text = table.Rows[0]["诊断"].ToString();
                }
                this.AddPresc(table);
                if (rdo1.Checked == true)
                {
                    chkall.Checked = false;
                    chkall.Checked = true;
                }

                //CallNumber(1);

                //Modify by Zhujh 2017-02-15
                /*
                #region 处方打印
                string pydy = ApiFunction.GetIniString("北院实时窗口打印", "启动配药时打印", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (InstanceForm.BCurrentDept.DeptId == 207)
                {
                    if (!string.IsNullOrEmpty(pydy) && Convert.ToBoolean(pydy))
                    {
                        string sql = string.Format("select kh from YY_KDJB where brxxid = '{0}'", brxxid);
                        DataTable brxxTable = InstanceForm.BDatabase.GetDataTable(sql);
                        string kh = string.Empty;
                        if (brxxTable != null && brxxTable.Rows.Count > 0)
                        {
                            kh = brxxTable.Rows[0][0].ToString().Trim();
                            string resultMsg = string.Empty;

                            ts_PrintProcess.PrescriptionPrint p = new ts_PrintProcess.PrescriptionPrint();
                            p.Print(kh, InstanceForm.BCurrentDept.DeptId, out resultMsg);
                        }
                    }
                }
                #endregion
                */
                //Add by zhujh 2017-05-27 新增耗时监控开始
                //ExecTimeLogger logger2 = ExecTimeLogger.Run("药房配药打印");

                //打印处方 Modify by Zhujh 2017-02-15
                this.butprint_Click(sender, e);

                //Add by zhujh 2017-05-27 新增耗时监控结束
                //logger2.Stop();
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



        /// <summary>
        /// 叫号
        /// </summary>
        /// <param name="Qyzt">1呼叫 2清空显示屏</param>
        private void CallNumber(int Qyzt)
        {
            if (_call is ts_call_whzxyybymz)
            {
                string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (Convertor.IsNull(_Fyckh, "") == "")
                {
                    return;
                }
                DataTable rettable = (DataTable)myDataGrid1.DataSource;
                DataRow[] selrow;
                if (rdo1.Checked == true)
                    selrow = rettable.Select("发药='◆' and ypid<>''");
                else
                    selrow = rettable.Select("发药='√' and ypid<>''");

                if (selrow.Length == 0)
                {
                    return;
                }
                string brName = selrow[0]["姓名"].ToString();// tb.Rows[0]["姓名"].ToString();改为选择的病人
                decimal sumje;
                if (rdo1.Checked == true)
                    sumje = Convert.ToDecimal(rettable.Compute("sum(金额)", "发药='◆'"));
                else
                    sumje = Convert.ToDecimal(rettable.Compute("sum(金额)", "发药='√'"));

                ts_call.CFMX[] cfmx = new ts_call.CFMX[selrow.Length];
                for (int i = 0; i <= selrow.Length - 1; i++)
                {
                    cfmx[i].PM = Convertor.IsNull(selrow[i]["品名"], "");
                    cfmx[i].GG = Convertor.IsNull(selrow[i]["规格"], "");
                    cfmx[i].DJ = Convert.ToDecimal(Convertor.IsNull(selrow[i]["单价"], "0"));
                    cfmx[i].SL = Convert.ToDecimal(Convertor.IsNull(selrow[i]["用量"], "0"));
                    cfmx[i].DW = Convertor.IsNull(selrow[i]["单位"], "0");
                    cfmx[i].JE = Convert.ToDecimal(Convertor.IsNull(selrow[i]["金额"], "0"));
                    cfmx[i].fyck = _Fyckmc;
                    cfmx[i].deptid = InstanceForm.BCurrentDept.DeptId;
                    cfmx[i].brxm = Convertor.IsNull(selrow[i]["姓名"], "");
                    cfmx[i].fph = Convertor.IsNull(selrow[i]["发票号"], "");
                }

                //分组处方
                DataTable tbsel = rettable.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);
                string[] GroupbyField ={ "FPID", "姓名", "发票号", "门诊号" };
                string[] ComputeField ={ "金额" };
                string[] CField ={ "sum" };
                DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                if (tbcf.Rows.Count == 0)
                {
                    //MessageBox.Show("没有要发药的药品记录");
                    return;
                }

                string brkh = string.Empty;
                for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                {
                    ParameterEx[] parameters = new ParameterEx[11];
                    parameters[0].Text = "@FPID";
                    parameters[0].DataType = System.Data.DbType.Guid;
                    parameters[0].Value = tbcf.Rows[i]["fpid"].ToString();

                    parameters[1].Text = "@FPH";
                    parameters[1].Value = tbcf.Rows[i]["发票号"].ToString();

                    parameters[2].Text = "@ZJE";
                    parameters[2].DataType = System.Data.DbType.Decimal;
                    parameters[2].Value = tbcf.Rows[i]["金额"].ToString();

                    parameters[3].Text = "@BRXM";
                    parameters[3].Value = tbcf.Rows[i]["姓名"].ToString();

                    parameters[4].Text = "@BLH";
                    parameters[4].Value = tbcf.Rows[i]["门诊号"].ToString();
                    brkh = tbcf.Rows[i]["门诊号"].ToString();

                    parameters[5].Text = "@LYCK";
                    parameters[5].Value = _Fyckh;

                    parameters[6].Text = "@LYCKMC";
                    parameters[6].Value = _Fyckmc;

                    parameters[7].Text = "@DEPTID";
                    parameters[7].DataType = System.Data.DbType.Int32;
                    parameters[7].Value = InstanceForm.BCurrentDept.DeptId;

                    parameters[8].Text = "@DEPTNAME";
                    parameters[8].Value = InstanceForm.BCurrentDept.DeptName;

                    parameters[9].Text = "@DJY";
                    parameters[9].Value = InstanceForm.BCurrentUser.EmployeeId;

                    parameters[10].Text = "@jhlx";
                    parameters[10].Value = "call";

                    int iii = InstanceForm.BDatabase.DoCommand("SP_YF_FYJH", parameters, 60);

                    if (rdo2.Checked)
                    {
                        break;
                    }
                }

                if (bqybjq == "true" && _menuTag.Function_Name == "Fun_ts_yf_mzfy")
                {
                    if (!string.IsNullOrEmpty(_Fyckh) && !string.IsNullOrEmpty(brkh) && _call is ts_call_whzxyybymz)
                    {
                        (_call as ts_call_whzxyybymz).Brkh = brkh;
                        (_call as ts_call_whzxyybymz).Qyzt = Qyzt;
                        (_call as ts_call_whzxyybymz).WindowNum = _Fyckh;

                        Caller call = new Caller(brName, sumje, cfmx, this._call);
                        thCall = new Thread(new ThreadStart(call.call_hj));
                        call.Thread = thCall;
                        thCall.Start();
                    }
                }
            }
        }

        private void myDataGrid1_DataSourceChanged(object sender, EventArgs e)
        {
            firstXm = string.Empty;
            //setButtionState = 0;
        }

        private void btnhqcf_Click(object sender, EventArgs e)
        {
            if (txttmk.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入病人卡号!");
                return;
            }
            if (txtfph.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入发票号!");
                return;
            }


            //原来的方法
            #region 原来的方法
            /*
            string postString = string.Format(@"<examReqInfoType><examReqId>{0}</examReqId><id>{1}</id></examReqInfoType>", txtfph.Text.Trim(), txttmk.Text.Trim());
            TrasenWs.TrasenWS ws = new ts_yf_mzfy.TrasenWs.TrasenWS();
            string reslut = ws.ExeWebService("SaveMzcf", postString);
            if (!string.IsNullOrEmpty(reslut))
            {
                if (reslut.Contains("重复键"))
                {
                    //MessageBox.Show("该病人处方信息已存在!");
                    // exec SP_WHZXYY_mz_cfb '368100012696', @errcode output, @errtext output,905466454  

                    ParameterEx[] parameters1 = new ParameterEx[3];

                    parameters1[0].Text = "@err_code";
                    parameters1[0].ParaDirection = ParameterDirection.Output;
                    parameters1[0].DataType = System.Data.DbType.Int32;
                    parameters1[0].ParaSize = 100;

                    parameters1[1].Text = "@err_text";
                    parameters1[1].ParaDirection = ParameterDirection.Output;
                    parameters1[1].ParaSize = 100;

                    parameters1[2].Text = "@id";
                    parameters1[2].Value = txttmk.Text.Trim();
                    int ret = InstanceForm.BDatabase.DoCommand("SP_WHZXYY_mz_brxx", parameters1, 30);

                    ParameterEx[] parameters = new ParameterEx[4];
                    parameters[0].Text = "@jsdjh";
                    parameters[0].Value = txtfph.Text.Trim();

                    parameters[1].Text = "@err_code";
                    parameters[1].ParaDirection = ParameterDirection.Output;
                    parameters[1].DataType = System.Data.DbType.Int32;
                    parameters[1].ParaSize = 100;

                    parameters[2].Text = "@err_text";
                    parameters[2].ParaDirection = ParameterDirection.Output;
                    parameters[2].ParaSize = 100;

                    parameters[3].Text = "@id";
                    parameters[3].Value = txttmk.Text.Trim();
                    ret = InstanceForm.BDatabase.DoCommand("SP_WHZXYY_mz_cfb", parameters, 30);
                    if (ret <= 0)
                        MessageBox.Show("该病人处方信息已存在!");
                    else
                        MessageBox.Show("操作成功!");
                }
                else if (reslut.Contains("保存成功"))
                    button_ref_Click(button_ref, new EventArgs());
            }
            */
            
            #endregion

            //新添加的获取老系统处方的方法

            #region 新添加的获取老系统处方的方法 Add By HYD 2017-11-20
            
            YFZLWebSevice.TrasenWS ws = new ts_yf_mzfy.YFZLWebSevice.TrasenWS();
            string reslut = ws.ExeWebService("v3tv2PrescInfoForDrugDirect", txtfph.Text.Trim());
            if (!string.IsNullOrEmpty(reslut))
            {
                MessageBox.Show(reslut);
            }
             
            #endregion 


        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            ts_ReadCard.ICard iCard = ts_ReadCard.CardFactory.CreateInstance(ts_ReadCard.CardType.武汉中心医院居民健康卡, null);
            if (iCard != null)
            {
                object obj = iCard.ReadCard(null);
                txttmk.Text = obj != null ? obj.ToString() : string.Empty;
            }
            if (txttmk.Text.Trim() != string.Empty)
                txtghxh_KeyPress(txttmk, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void Frmcffy_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Frmcffy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
            {
                btnPy_Click(null, null);
            }
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        //Add by jchl【天剂外包发药：根据发药类别过滤处方】
        private DataTable DoFilFylb(DataTable tb)
        {
            try
            {
                //Modify by jchl【处方发药：根据发药类型判断-1：全部  1：本药房发药  2：用法(水煎服)煎药(待煎)过滤】
                DataTable dtCffy = tb.Clone();
                if (cmbFylb.SelectedValue.ToString().Trim().Equals("1"))
                {
                    DataRow[] drs = tb.Select("用法<>'代煎'");

                    for (int i = 0; i < drs.Length; i++)
                    {
                        dtCffy.Rows.Add(drs[i].ItemArray);
                    }
                }
                else if (cmbFylb.SelectedValue.ToString().Trim().Equals("2"))
                {
                    // 
                    DataRow[] drs = tb.Select("用法='代煎'");

                    for (int i = 0; i < drs.Length; i++)
                    {
                        dtCffy.Rows.Add(drs[i].ItemArray);
                    }
                }
                else if (cmbFylb.SelectedValue.ToString().Trim().Equals("-1"))
                {
                    return tb;
                }

                return dtCffy;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 转发13窗口程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFpCk_Click(object sender, EventArgs e)
        {
            //未发药按钮选择上
            if (rdo1.Checked == true)
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource; //处方明细集合

                // this.Cursor = PubStaticFun.WaitCursor();
                //分组处方
                DataRow[] selrow = tb.Select("发药='◆' and ypid<>''");
                DataTable tbsel = tb.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);


                string[] GroupbyField ={ "jssjh", "发票号", "总金额", "记帐金额", "优惠金额", "自付金额", "cfxh", "patid", "门诊号", "姓名", "ysdm", "ksdm", "收费日期", "sfczy", "配药窗口" };
                string[] ComputeField ={ "金额" };
                string[] CField ={ "sum" };
                DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                if (tbcf.Rows.Count == 0)
                {
                    MessageBox.Show("没有要发药的药品记录需要【转一楼药房窗口】取药！");
                    // SetDefaultFocuse();
                    return;
                }

                if (MessageBox.Show("是否【转一楼药房窗口】取药？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    // SetDefaultFocuse();
                    return;
                }

                //转到一楼药房
                Hashtable ht = new Hashtable();
                string str_Fphtemp = "";
                string str_Fph = "";
                if (tbcf.Rows.Count > 0)
                {
                    str_Fphtemp = tbcf.Rows[0]["发票号"].ToString();
                    ht.Add(0, str_Fphtemp);
                }
                for (int i = 0; i < tbcf.Rows.Count; i++)
                {
                    str_Fph = tbcf.Rows[i]["发票号"].ToString();
                    if (i > 0)
                    {
                        if (!str_Fphtemp.Equals(str_Fph))
                        {
                            str_Fphtemp = str_Fph;
                            ht.Add(i, str_Fph);
                        }
                    }
                }

              //  WebOldHisService.n_yygh oldhisSer = new WebOldHisService.n_yygh();//调用老系统提供的WebService 服务 add by HYD 2016-09-12
               // TrasenWs.TrasenWS ws = new ts_yf_mzfy.TrasenWs.TrasenWS(); // Add BY HYD 2017-08-18 启用新系统收费
               
                KFCommSer.WebService ws = new ts_yf_mzfy.KFCommSer.WebService();
                string WinNo = string.Empty;

                foreach (DictionaryEntry de in ht)
                {
                    string strerr = "";
                   // string strMess = oldhisSer.mzjs_get_fyckh(de.Value.ToString(), "001", ref strerr);
                   //string strMess = ws.ExeWebService("GetKF_FYCKH", de.Value.ToString());//通过发票号得到收费时的快发窗口号 Add BY HYD 2017-08-18 启用新系统收费

                    //<message><code>200</code><msg>15</msg></message>

                    //调用新的服务方法调用南院快发201服务
                    string str_KFComm = "<root><AreaId>" + "1001" + "</AreaId><SerialNo>" + de.Value.ToString() + "</SerialNo><UserID>" + InstanceForm.BCurrentUser.EmployeeId.ToString() + "</UserID></root>";
                    string strMess = ws.ExecuteWS("Execute_201", str_KFComm);// Add BY HYD 2017-09-27                   

                    System.Xml.XmlDocument document = new System.Xml.XmlDocument();
                    document.LoadXml(strMess);
                    System.Xml.XmlNode ndCode = document.SelectSingleNode("message/msg");
                    WinNo = ndCode.InnerText;

                    if (WinNo.Length > 0)
                    {
                        try
                        {
                            int tmp = int.Parse(WinNo);

                            if (tmp > 0)
                            {
                                MessageBox.Show("请告知病人到一楼【" + tmp + "】窗口取药！");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("快发服务返回的数据不正确！");
                        }
                    }

                }
                //转发13窗口发药提示
                /* string err = "";
                 * string str_Fph=tbcf.Rows[i]["发票号"].ToString();
                 WebReference.n_yygh p = new WebReference.n_yygh();
                 string s1 = p.mzjs_get_fyckh("637100001772", "001", ref err);
                 *  MessageBox.Show(s1);
                 //Response.Write(s1); */
            }
            else
            {
                MessageBox.Show("只能选择【未发药】的队列进行转发窗口发药！");
            }

            #region 原来转发13窗口的程序
            /****************************以下是原来的方法************************************************************
            ////写死13
            ////发药窗口
            DataTable tb = (DataTable)this.myDataGrid1.DataSource; //处方明细集合

            this.Cursor = PubStaticFun.WaitCursor();
            //分组处方
            DataRow[] selrow = tb.Select("发药='◆' and ypid<>''");
            DataTable tbsel = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel.ImportRow(selrow[w]);

            //string[] GroupbyField ={"jssjh","发票号","总金额","记帐金额","优惠金额","自付金额","剂数","cfxh","patid","门诊号","姓名","ysdm","ksdm","收费日期","sfczy","配药窗口"};
            string[] GroupbyField ={ "jssjh", "发票号", "总金额", "记帐金额", "优惠金额", "自付金额", "cfxh", "patid", "门诊号", "姓名", "ysdm", "ksdm", "收费日期", "sfczy", "配药窗口" };
            string[] ComputeField ={ "金额" };
            string[] CField ={ "sum" };
            DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
            if (tbcf.Rows.Count == 0)
            {
                MessageBox.Show("没有要发药的药品记录需要【转13发药窗口】");
                SetDefaultFocuse();
                return;
            }

            if (MessageBox.Show("是否【转13号窗口】发药？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                SetDefaultFocuse();
                return;
            }

            InstanceForm.BDatabase.BeginTransaction();

            try
            {
                for (int i = 0; i < tbcf.Rows.Count; i++)
                {
                    string cfid = tbcf.Rows[i]["cfxh"].ToString();
                    string ssql = string.Format(@"update MZ_CFB set FYCK='{0}' where CFID='{1}'", 13, cfid);
                    InstanceForm.BDatabase.DoCommand(ssql);                 


                }

                //提交事务
                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("操作成功", "发药", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                InstanceForm.BDatabase.RollbackTransaction();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                SetDefaultFocuse();
            }
            **********************************************************/
            #endregion
        }

        #region IMessageFilter 成员

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 522)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private void btnOver_Click(object sender, EventArgs e)
        {
            try
            {
                if (InstanceForm.BCurrentDept.DeptId != 417)
                {
                    MessageBox.Show("暂未开放此功能");
                    return;
                }

                DataTable tb = (DataTable)myDataGrid1.DataSource;
                DataRow[] selrow;
                if (rdo1.Checked == true)
                    selrow = tb.Select("发药='◆' and ypid<>''");
                else
                    selrow = tb.Select("发药='√' and ypid<>''");

                if (selrow.Length == 0)
                {
                    MessageBox.Show("请选择病人处方后再呼叫", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string inpid = selrow[0]["PATID"].ToString();//ghxxid
                string brxm = selrow[0]["姓名"].ToString();// tb.Rows[0]["姓名"].ToString();改为选择的病人
                string ip = PubStaticFun.GetIPAddress();//webservice写死  中草药房前置机
                string type = "0";

                ClsMzCall.ClsMzZcyCall.CallInpatient(brxm, inpid, ip, type);
            }
            catch
            { }
        }

        private void btnCancerOver_Click(object sender, EventArgs e)
        {
            try
            {
                if (InstanceForm.BCurrentDept.DeptId != 417)
                {
                    MessageBox.Show("暂未开放此功能");
                    return;
                }

                DataTable tb = (DataTable)myDataGrid1.DataSource;
                DataRow[] selrow;
                if (rdo1.Checked == true)
                    selrow = tb.Select("发药='◆' and ypid<>''");
                else
                    selrow = tb.Select("发药='√' and ypid<>''");

                if (selrow.Length == 0)
                {
                    MessageBox.Show("请选择病人处方后再呼叫", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string inpid = selrow[0]["PATID"].ToString();//ghxxid
                string brxm = selrow[0]["姓名"].ToString();// tb.Rows[0]["姓名"].ToString();改为选择的病人
                string ip = PubStaticFun.GetIPAddress();//webservice写死中草药房前置机
                string type = "1";

                ClsMzCall.ClsMzZcyCall.CallInpatient(brxm, inpid, ip, type);
            }
            catch
            { }
        }

        /// <summary>
        /// 获取维护的药品品种列表
        /// </summary>
        private DataTable GetYpCjidList()
        {
            string strSql = "SELECT cjid FROM V_MZFY_PM ";
            return InstanceForm.BDatabase.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取维护的用法列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetYpYFList()
        {
            string strSql = "SELECT yf FROM V_MZFY_YF ";
            return InstanceForm.BDatabase.GetDataTable(strSql);
        }

        public string get_fy_YPID_All()
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource; //处方明细集合
            DataRow[] selrow = tb.Select("发药='◆' and ypid<>''");
            DataTable tbsel = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel.ImportRow(selrow[w]);
            string str_ypid = string.Empty;
            string str_tmpid = string.Empty;


            if (tbsel.Rows.Count > 0)
            {
                for (int m = 0; m < tbsel.Rows.Count; m++)
                {
                    str_ypid = tbsel.Rows[m]["YPID"].ToString();
                    str_tmpid += str_ypid + ",";
                }

                str_tmpid = str_tmpid.Substring(0, str_tmpid.Length - 1);  
            }

            str_ypid = str_tmpid;
            return str_ypid;
        }


        /// <summary>
        /// 为了配合陈老师，依陈老师要求此处从快发机取数据
        /// </summary>
        /// <param name="str_CFXH"></param>
        /// <returns></returns>
        public string GetKF_NY_HH_PYR(string str_CFXH)
        {
            string str_Pyr = string.Empty;//配药员

            //南院一楼药房与北院一楼药房时从快发机取数据,其它药房从界面中取配药人   add by hyd 2017-11-30 快发升级应信息科要求
            if (("207,424").Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
            {

                SqlConnection conn = null;
                SqlCommand cmd = null;
                DataTable dt = new DataTable();
                string str_SQL = "";
                if (("424").Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
                {
                    //访问南京路的
                    conn = new SqlConnection("uid=Led;pwd=Led;server=192.168.0.44;database=Mis9whszxyybyDB");
                    str_SQL = string.Format(@"select winno, presc_no, patient_id, patient_name, opmanuserno2, opman2, processdate2 from 
                                              dbo.HIS_CONSIS_PRESC_FINISHOPMAN2VW where presc_no='{0}';", str_CFXH);
                    cmd = new SqlCommand(str_SQL, conn);
                }

                if (("207").Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
                {
                    //访问后湖的
                    conn = new SqlConnection("uid=Led;pwd=Led;server=192.168.100.171;database=Mis9whzxyyhhDB");
                    str_SQL = string.Format(@"select winno, presc_no, patient_id, patient_name, opmanuserno2, opman2, processdate2 from 
                                              dbo.HIS_CONSIS_PRESC_FINISHOPMAN2VW where presc_no='{0}';", str_CFXH);
                    cmd = new SqlCommand(str_SQL, conn);
                }
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        str_Pyr = dt.Rows[0]["opmanuserno2"].ToString();//配药员ID
                        if (str_Pyr == "")
                        {
                            str_Pyr = cmbpyr.SelectedValue.ToString();//当发隔天处方时，配药人从界面上取值，因为快发只保留一天的数据
                        }

                    }
                    else
                    {                        
                        str_Pyr = cmbpyr.SelectedValue.ToString();//当发隔天处方时，配药人从界面上取值，因为快发只保留一天的数据
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            else
            {
                str_Pyr = cmbpyr.SelectedValue.ToString();//当是其它科室进行发药时，配药还是从界面上取值
            }
            return str_Pyr;
        }


        private void Add_DJJKKXX_ToEventLogMZ(string strPATID,string strGHXXID)
        {
            DataTable tab_DJJK = null;
            bool str_Flag = false;
            string str_ZFZH = "";//身份证号
            string str_KH = "";//病人卡号

            //通过病人信息ID找到病人有没有电子健康卡
            string sql = string.Format(@"select KH,SFZH from YY_KDJB AS A INNER JOIN YY_BRXX AS B ON A.BRXXID=B.BRXXID where A.KLX=8 and A.BRXXID='{0}'  order by A.DJSJ DESC ", strPATID);

            try
            {
                tab_DJJK = InstanceForm.BDatabase.GetDataTable(sql);
                if (tab_DJJK != null && tab_DJJK.Rows.Count > 0)
                {
                    //表示此人有电子健康卡存在
                    str_Flag = true;
                    str_ZFZH = tab_DJJK.Rows[0]["SFZH"].ToString();//病人身份证号
                    str_KH = tab_DJJK.Rows[0]["KH"].ToString();//病人电子健康卡号

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(string.Format("电子健康卡数据库信息查询失败!{0}", err.Message), "提示");
            }

            if (str_Flag)
            {
                try
                {

                   // sql = string.Format(@"insert into EVENTLOG_MZ(EVENT,CATEGORY,BIZID)  VALUES('{0}','{1}','{2}')", "DJJKKMZFYXX.HIS", "YF_FY", str_ZFZH);
                    sql = string.Format(@"insert into EVENTLOG_MZ(EVENT,CATEGORY,BIZID)  VALUES('{0}','{1}','{2}')", "DJJKKMZFYXX.HIS", "YF_FY", str_KH);
                    InstanceForm.BDatabase.DoCommand(sql);
                }
                catch (Exception err)
                {
                    MessageBox.Show(string.Format("电子健康卡数据库日志记录失败!{0}", err.Message), "提示");
                }
            }        

           
        }


    }
}
